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
using AutoMapper;

namespace Bamboo.Admin.Application.Services;

public class TenantMemberAppService :
    CrudAppService<
        TenantMember,
        TenantMemberDto,
        Guid,
        GetTenantMembersInput,
        CreateTenantMemberDto,
        UpdateTenantMemberDto>,
    ITenantMemberAppService
{
    private readonly ICurrentTenant _currentTenant;
    private readonly IDataFilter _dataFilter;

    private readonly IReadOnlyRepository<IdentityUser, Guid> _userRepository;
    private readonly IReadOnlyRepository<Tenant, Guid> _tenantRepository;
    private readonly IReadOnlyRepository<IdentityRole, Guid> _roleRepository;
    private readonly IMapper _mapper;
    public TenantMemberAppService(
        IDataFilter dataFilter,
        IMapper mapper,
        ICurrentTenant currentTenant,
        IRepository<TenantMember, Guid> repository,
        IReadOnlyRepository<Tenant, Guid> tenantRepository,
        IReadOnlyRepository<IdentityRole, Guid> roleRepository,
        IReadOnlyRepository<IdentityUser, Guid> userRepository)
        : base(repository)
    {
        _currentTenant = currentTenant;
        _userRepository = userRepository;
        _dataFilter = dataFilter;
        _tenantRepository = tenantRepository;
        _roleRepository = roleRepository;
        _mapper = mapper;
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

    public override async Task<PagedResultDto<TenantMemberDto>> GetListAsync(GetTenantMembersInput input)
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
            var dto = _mapper.Map<TenantMember, TenantMemberDto>(x.tenantMember);
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
        //var tenantId = _currentTenant.Id.HasValue ? _currentTenant.Id.Value : (input.TenantId.HasValue ? input.TenantId.Value : Guid.Empty);
        var tenantId = CurrentTenant.Id ?? input.TenantId;
        if (!tenantId.HasValue)
        {
            throw new Volo.Abp.UserFriendlyException(L["TenantIsRequired"]);
        }
        using (_dataFilter.Disable<IMultiTenant>())
        {
            var tenant = await _tenantRepository.FirstOrDefaultAsync(x => x.Id == tenantId.Value);
            if (tenant == null)
            {
                throw new Volo.Abp.UserFriendlyException(L["TenantIsRequired"]);
            }
        }
        Volo.Abp.Identity.IdentityUser? user;
        using (CurrentTenant.Change(null))
        {
            if (input.UserId.HasValue)
            {
                user = await _userRepository.FirstOrDefaultAsync(x => x.Id == input.UserId);
            }
            else if (!string.IsNullOrWhiteSpace(input.UserName))
            {
                user = await _userRepository.FirstOrDefaultAsync(x => x.UserName == input.UserName);
            }
            else
            {
                throw new Volo.Abp.UserFriendlyException(L["InvalidUserInput"]);
            }
        }
        if (user == null)
        {
            throw new Volo.Abp.UserFriendlyException(L["UserNotFound"]);
        }
        // 1. Tìm user 
        // var user = await _userRepository.GetAsync(input.UserId);
        // if (user == null)
        // {
        //     // Tùy chọn: Tự động tạo user mới hoặc báo lỗi
        //     throw new UserFriendlyException($"User with email {input.UserId} not found.");
        // }

        // 2. Kiểm tra xem đã mời chưa
        if (await Repository.AnyAsync(x => x.TenantId == tenantId.Value && x.UserId == user.Id))
        {
            throw new UserFriendlyException("This user has already been invited or is a member.");
        }

        // 3. Tạo lời mời với trạng thái Pending
        var invitation = new TenantMember(GuidGenerator.Create(), tenantId.Value, user.Id, input.Status, input.InviteStatus);
        invitation.InvitedAt = DateTimeOffset.Now;
        invitation.Description = input.Description;
        using (_dataFilter.Disable<IMultiTenant>())
        {
            if (input.Roles.Any())
            {
                var roles = await _roleRepository.GetListAsync(r => r.TenantId == tenantId.Value && input.Roles.Contains(r.Name));
                foreach (var role in roles)
                {
                    invitation.AddRole(role.Id, GuidGenerator);
                }
            }
        }

        invitation = await Repository.InsertAsync(invitation);
        // Tùy chọn: Gửi email thông báo cho người dùng
        // await _emailSender.SendAsync(...)

        return _mapper.Map<TenantMember, TenantMemberDto>(invitation);
    }

    public async Task<PagedResultDto<TenantMemberDto>> GetMyWorkspacesAsync()
    {
        if (!CurrentUser.Id.HasValue)
        {
            throw new UserFriendlyException("Login requred.");
        }
        using (_dataFilter.Disable<IMultiTenant>())
        {
            var userId = CurrentUser.GetId();

            var membersQueryable = await Repository.GetQueryableAsync();
            var tenantsQueryable = await _tenantRepository.GetQueryableAsync();
            var rolesQueryable = await _roleRepository.GetQueryableAsync();

            var query = from member in membersQueryable
                        join tenant in tenantsQueryable on member.TenantId equals tenant.Id
                        where member.UserId == userId && member.IsActive != false
                        select new
                        {
                            Member = member,
                            Tenant = tenant,
                            TenantName = tenant.Name,
                            Roles = (from memberRole in member.Roles
                                     join role in rolesQueryable on memberRole.RoleId equals role.Id
                                     select role.Name).ToList()
                        };

            var result = await AsyncExecuter.ToListAsync(query);

            var dtos = result.Select(x =>
            {
                var dto = _mapper.Map<TenantMember, TenantMemberDto>(x.Member);
                dto.TenantName = x.Tenant.Name;
                dto.Roles = x.Roles;
                dto.UserName = CurrentUser.UserName;
                return dto;
            }).ToList();
            return new PagedResultDto<TenantMemberDto>(dtos.Count, dtos);
        }
    }

    public async Task AcceptInvitationAsync(Guid invitationId)
    {
        using (_dataFilter.Disable<IMultiTenant>())
        {
            var invitation = await Repository.GetAsync(invitationId);
            // Đảm bảo chỉ đúng người được mời mới có thể Accept
            if (invitation.UserId != CurrentUser.GetId())
            {
                throw new UserFriendlyException("You are not authorized to accept this invitation.");
            }
            if (invitation.InviteStatus == InvitationStatus.Pending && invitation.IsActive != false)
            {
                invitation.AcceptInvitation();
                await Repository.UpdateAsync(invitation);
            }
        }
    }

    public async Task RejectInvitationAsync(Guid invitationId)
    {
        using (_dataFilter.Disable<IMultiTenant>())
        {
            var invitation = await Repository.GetAsync(invitationId);
            // Đảm bảo chỉ đúng người được mời mới có thể Accept
            if (invitation.UserId != CurrentUser.GetId())
            {
                throw new UserFriendlyException("You are not authorized to accept this invitation.");
            }
            if (invitation.InviteStatus == InvitationStatus.Pending && invitation.IsActive != false)
            {
                invitation.RejectInvitation();
                await Repository.UpdateAsync(invitation);
            }
        }
    }
}