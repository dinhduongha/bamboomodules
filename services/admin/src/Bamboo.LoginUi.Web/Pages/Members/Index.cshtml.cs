using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Linq;
using Volo.Abp.MultiTenancy;

using Volo.Abp.TenantManagement;
using Bamboo.Admin;
using Bamboo.Admin.Domain.Shared.Enums;
using Volo.Abp.Data;

namespace Bamboo.Abp.LoginUi.Web.Pages.Admin.Members;

public class IndexModel : AbpPageModel
{
    [BindProperty(SupportsGet = true)]
    public string Filter { get; set; }

    [BindProperty(SupportsGet = true)]
    public Guid? TenantId { get; set; }

    public PagedResultDto<MemberDto> Members { get; set; }

    private readonly ICurrentTenant _currentTenant;
    private readonly IRepository<TenantMember, Guid> _tenantMemberRepository;
    private readonly IReadOnlyRepository<IdentityUser, Guid> _userRepository;
    private readonly IReadOnlyRepository<Tenant, Guid> _tenantRepository;
    private readonly IReadOnlyRepository<IdentityRole, Guid> _roleRepository;
    private readonly IAsyncQueryableExecuter _asyncExecuter;
    private readonly IDataFilter _dataFilter;

    public IndexModel(
        ICurrentTenant currentTenant,
        IRepository<TenantMember, Guid> tenantMemberRepository,
        IReadOnlyRepository<IdentityUser, Guid> userRepository,
        IReadOnlyRepository<Tenant, Guid> tenantRepository,
        IReadOnlyRepository<IdentityRole, Guid> roleRepository,
        IAsyncQueryableExecuter asyncExecuter,
        IDataFilter dataFilter)
    {
        _currentTenant = currentTenant;
        _tenantMemberRepository = tenantMemberRepository;
        _userRepository = userRepository;
        _tenantRepository = tenantRepository;
        _roleRepository = roleRepository;
        _asyncExecuter = asyncExecuter;
        _dataFilter = dataFilter;
        Members = new PagedResultDto<MemberDto>();
    }

    public async Task OnGetAsync(int currentPage = 1, int pageSize = 10)
    {
        var tenantId = _currentTenant.Id ?? TenantId;

        using (_currentTenant.IsAvailable ? null : _dataFilter.Disable<IMultiTenant>())
        {
            var memberQueryable = await _tenantMemberRepository.GetQueryableAsync();
            var userQueryable = await _userRepository.GetQueryableAsync();
            var tenantQueryable = await _tenantRepository.GetQueryableAsync();
            var roleQueryable = await _roleRepository.GetQueryableAsync();

            var query = from member in memberQueryable
                        join user in userQueryable on member.UserId equals user.Id
                        join tenant in tenantQueryable on member.TenantId equals tenant.Id
                        where !tenantId.HasValue || member.TenantId == tenantId.Value
                        select new { Member = member, User = user, Tenant = tenant };

            if (!Filter.IsNullOrWhiteSpace())
            {
                query = query.Where(x => x.User.UserName.Contains(Filter) || x.User.Email.Contains(Filter));
            }

            var totalCount = await _asyncExecuter.CountAsync(query);

            var pagedQuery = query.OrderByDescending(x => x.Member.CreationTime)
                                    .PageBy(currentPage, pageSize);

            var queryResult = await _asyncExecuter.ToListAsync(pagedQuery);

            var memberDtos = queryResult.Select(x =>
            {
                // Lấy danh sách vai trò cho từng thành viên
                // Cần thực hiện trong vòng lặp vì navigation property 'Roles' của TenantMember không được tải sẵn
                var roles = (from memberRole in x.Member.Roles
                             join role in roleQueryable on memberRole.RoleId equals role.Id
                             select role.Name).ToList();

                return new MemberDto
                {
                    Id = x.Member.Id,
                    UserId = x.User.Id,
                    UserName = x.User.UserName,
                    Email = x.User.Email,
                    Status = x.Member.Status,
                    TenantName = x.Tenant.Name,
                    JoinedDate = x.Member.AcceptedAt ?? x.Member.CreationTime,
                    Roles = roles
                };
            }).ToList();

            Members = new PagedResultDto<MemberDto>(totalCount, memberDtos);
        }
    }

    public class MemberDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string TenantName { get; set; }
        public List<string> Roles { get; set; } = new();
        public TenantMemberStatus Status { get; set; }
        public DateTimeOffset? JoinedDate { get; set; }
    }
}