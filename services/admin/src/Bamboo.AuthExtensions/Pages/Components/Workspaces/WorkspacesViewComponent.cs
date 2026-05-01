using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Linq;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;
using Volo.Abp.Users;

using Bamboo.Abp.LoginUi.Web.Pages.Account.Workspaces;
using Bamboo.Admin;
using Volo.Abp.ObjectMapping;

namespace Bamboo.Abp.LoginUi.Web.Pages.Account.Components.Workspaces;

public class WorkspacesViewComponent : AbpViewComponent
{
    private readonly IRepository<TenantMember, Guid> _tenantMemberRepository;
    private readonly IReadOnlyRepository<Tenant, Guid> _tenantRepository;
    private readonly IReadOnlyRepository<IdentityRole, Guid> _roleRepository;
    private readonly IDataFilter _dataFilter;
    private readonly ICurrentUser _currentUser;
    private readonly IAsyncQueryableExecuter _asyncExecuter;

    public WorkspacesViewComponent(
        IRepository<TenantMember, Guid> tenantMemberRepository,
        IReadOnlyRepository<Tenant, Guid> tenantRepository,
        IReadOnlyRepository<IdentityRole, Guid> roleRepository,
        IDataFilter dataFilter,
        ICurrentUser currentUser,
        IAsyncQueryableExecuter asyncExecuter)
    {
        _tenantMemberRepository = tenantMemberRepository;
        _tenantRepository = tenantRepository;
        _roleRepository = roleRepository;
        _dataFilter = dataFilter;
        _currentUser = currentUser;
        _asyncExecuter = asyncExecuter;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        List<WorkspaceDto> workspaces;
        using (_dataFilter.Disable<IMultiTenant>())
        {
            var userId = _currentUser.GetId();

            // Tối ưu hóa: Lấy IQueryable trước khi xây dựng câu lệnh join
            var membersQueryable = await _tenantMemberRepository.GetQueryableAsync();
            var tenantsQueryable = await _tenantRepository.GetQueryableAsync();
            var rolesQueryable = await _roleRepository.GetQueryableAsync();

            var query = from member in membersQueryable
                        join tenant in tenantsQueryable on member.TenantId equals tenant.Id
                        where member.UserId == userId
                        select new
                        {
                            Member = member,
                            TenantName = tenant.Name,
                            Roles = (from memberRole in member.Roles
                                     join role in rolesQueryable on memberRole.RoleId equals role.Id
                                     select role.Name).ToList()
                        };

            var result = await _asyncExecuter.ToListAsync(query);

            // Sửa lỗi: Chuyển đổi thủ công từ kết quả truy vấn sang DTO
            workspaces = result.Select(x => new WorkspaceDto
            {
                Id = x.Member.Id,
                TenantId = x.Member.TenantId.Value,
                TenantName = x.TenantName,
                Status = x.Member.Status,
                InviteStatus = x.Member.InviteStatus,
                Roles = x.Roles,
                JoinedDate = x.Member.AcceptedAt ?? x.Member.CreationTime
            }).ToList();
        }

        return View("~/Pages/Account/Components/Workspaces/Default.cshtml", workspaces);
    }
}