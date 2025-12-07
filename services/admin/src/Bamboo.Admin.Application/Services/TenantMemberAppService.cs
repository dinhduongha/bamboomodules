using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.Users;

using Bamboo.Admin.Domain.Shared.Enums;
using Bamboo.Admin.Application.Dtos;
using Volo.Abp.TenantManagement;

namespace Bamboo.Admin.Application.Services;

[Authorize(Roles = "superadmin,admin")]
public class TenantMemberAppService :
    CrudAppService<
        TenantMember,
        TenantMemberDto,
        Guid,
        GetTenantMemberListInput,
        CreateTenantMemberDto,
        UpdateTenantMemberDto>,
    ITenantMemberAppService
{
    private readonly ICurrentTenant _currentTenant;
    private readonly IDataFilter _dataFilter;

    private readonly IReadOnlyRepository<IdentityUser, Guid> _userRepository;
    private readonly IReadOnlyRepository<Tenant, Guid> _tenantRepository;
    public TenantMemberAppService(
        IDataFilter dataFilter,
        IRepository<TenantMember, Guid> repository,
        ICurrentTenant currentTenant,
        IReadOnlyRepository<Tenant, Guid> tenantRepository,
        IReadOnlyRepository<IdentityUser, Guid> userRepository)
        : base(repository)
    {
        _currentTenant = currentTenant;
        _userRepository = userRepository;
        _dataFilter = dataFilter;
        _tenantRepository = tenantRepository;
        if (!_currentTenant.IsAvailable)
        {
            _dataFilter.Disable<IMultiTenant>();
        }
    }

    public override async Task<TenantMemberDto> CreateAsync(CreateTenantMemberDto input)
    {
        // Chỉ cho phép tạo member trong tenant hiện tại
        // if (!_currentTenant.IsAvailable)
        // {
        //     throw new UserFriendlyException("This action can only be performed within a tenant context.");
        // }

        var tenantId = _currentTenant.Id.HasValue ? _currentTenant.Id.Value : (input.TenantId.HasValue ? input.TenantId.Value : Guid.Empty);
        if (tenantId == Guid.Empty)
        {
            throw new UserFriendlyException("This action can only be performed within a tenant context.");
        }

        // Kiểm tra user đã là member chưa
        if (await Repository.AnyAsync(x => x.TenantId == tenantId && x.UserId == input.UserId))
        {
            throw new UserFriendlyException("User is already a member of this tenant.");
        }

        var tenantMember = new TenantMember(GuidGenerator.Create(), tenantId, input.UserId);
        if (input.Role != null)
            tenantMember.Role = input.Role;
        if (input.Status != null)
            tenantMember.Status = (TenantMemberStatus)input.Status;
        if (input.IsOwner != null)
            tenantMember.IsOwner = (bool)input.IsOwner;
        if (input.IsActive != null)
            tenantMember.IsActive = (bool)input.IsActive;
        await Repository.InsertAsync(tenantMember);
        return await MapToGetOutputDtoAsync(tenantMember);
    }

    public override async Task<TenantMemberDto> UpdateAsync(Guid id, UpdateTenantMemberDto input)
    {
        var tenantMember = await Repository.GetAsync(id);
        if (tenantMember != null)
        {
            if (input.Role != null)
                tenantMember.Role = input.Role;
            if (input.Status != null)
                tenantMember.Status = (TenantMemberStatus)input.Status;
            if (input.IsOwner != null)
                tenantMember.IsOwner = (bool)input.IsOwner;
            if (input.IsActive != null)
                tenantMember.IsActive = (bool)input.IsActive;
            tenantMember = await Repository.UpdateAsync(tenantMember);
        }
        return await MapToGetOutputDtoAsync(tenantMember);
    }

    public override async Task<PagedResultDto<TenantMemberDto>> GetListAsync(GetTenantMemberListInput input)
    {
        // Chỉ lấy danh sách member của tenant hiện tại
        var tenantId = _currentTenant.Id.HasValue ? _currentTenant.Id.Value : (input.TenantId.HasValue ? input.TenantId.Value : Guid.Empty);
        if (tenantId == Guid.Empty)
        {
            return new PagedResultDto<TenantMemberDto>();
        }

        //var tenantId = _currentTenant.Id.Value;
        var userRepository = await _userRepository.GetQueryableAsync();

        var query = from tenantMember in await Repository.GetQueryableAsync()
                    join user in userRepository on tenantMember.UserId equals user.Id
                    where tenantMember.TenantId == tenantId
                    // Lọc theo tên user nếu có
                    where input.Filter.IsNullOrWhiteSpace() || user.UserName.Contains(input.Filter)
                    select new { tenantMember, user };

        var totalCount = await AsyncExecuter.CountAsync(query);

        var sortedQuery = query
            .OrderBy(NormalizeSorting(input.Sorting))
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount);

        var queryResult = await AsyncExecuter.ToListAsync(sortedQuery);

        var dtos = queryResult.Select(x =>
        {
            var dto = ObjectMapper.Map<TenantMember, TenantMemberDto>(x.tenantMember);
            dto.UserName = x.user.UserName;
            return dto;
        }).ToList();

        return new PagedResultDto<TenantMemberDto>(totalCount, dtos);
    }

    private static string NormalizeSorting(string sorting)
    {
        if (sorting.IsNullOrEmpty()) { return $"tenantMember.{nameof(TenantMember.CreationTime)} DESC"; }
        // Replace "userName" with "user.UserName" for sorting on the joined table
        if (sorting.Contains("userName", StringComparison.OrdinalIgnoreCase)) { return sorting.Replace("userName", "user.UserName", StringComparison.OrdinalIgnoreCase); }
        return $"tenantMember.{sorting}";
    }

    public async Task<TenantMemberDto> InviteAsync(InviteMemberDto input)
    {
        var tenantId = _currentTenant.Id.HasValue ? _currentTenant.Id.Value : (input.TenantId.HasValue ? input.TenantId.Value : Guid.Empty);

        // 1. Tìm user bằng email
        var user = await _userRepository.GetAsync(input.UserId);
        if (user == null)
        {
            // Tùy chọn: Tự động tạo user mới hoặc báo lỗi
            throw new UserFriendlyException($"User with email {input.UserId} not found.");
        }

        // 2. Kiểm tra xem đã mời chưa
        if (await Repository.AnyAsync(x => x.TenantId == input.TenantId && x.UserId == user.Id))
        {
            throw new UserFriendlyException("This user has already been invited or is a member.");
        }

        // 3. Tạo lời mời với trạng thái Pending
        var invitation = new TenantMember(GuidGenerator.Create(), tenantId, user.Id);
        //invitation.SetRoles(input.Roles);

        await Repository.InsertAsync(invitation);

        // Tùy chọn: Gửi email thông báo cho người dùng
        // await _emailSender.SendAsync(...)

        return ObjectMapper.Map<TenantMember, TenantMemberDto>(invitation);
    }

    public async Task<ListResultDto<TenantMemberDto>> GetMyInvitationsAsync()
    {
        using (_dataFilter.Disable<IMultiTenant>())
        {
            var userId = CurrentUser.GetId();

            var query = from invitation in await Repository.GetQueryableAsync()
                        join tenant in await _tenantRepository.GetQueryableAsync() on invitation.TenantId equals tenant.Id
                        where invitation.UserId == userId
                        select new { invitation, tenant };

            var result = await AsyncExecuter.ToListAsync(query);

            var dtos = result.Select(x =>
            {
                var dto = ObjectMapper.Map<TenantMember, TenantMemberDto>(x.invitation);
                dto.TenantName = x.tenant.Name;
                return dto;
            }).ToList();
            return new ListResultDto<TenantMemberDto>(dtos);
        }
    }

    public async Task AcceptInvitationAsync(Guid invitationId)
    {
        var invitation = await Repository.GetAsync(invitationId);
        // Đảm bảo chỉ đúng người được mời mới có thể Accept
        if (invitation.UserId != CurrentUser.GetId())
        {
            throw new UserFriendlyException("You are not authorized to accept this invitation.");
        }
        invitation.AcceptInvitation();
        await Repository.UpdateAsync(invitation);
    }

    public async Task RejectInvitationAsync(Guid invitationId)
    {
        var invitation = await Repository.GetAsync(invitationId);
        // Đảm bảo chỉ đúng người được mời mới có thể Accept
        if (invitation.UserId != CurrentUser.GetId())
        {
            throw new UserFriendlyException("You are not authorized to accept this invitation.");
        }
        invitation.RejectInvitation();
        invitation.Status = TenantMemberStatus.Rejected;
        await Repository.UpdateAsync(invitation);
    }
}