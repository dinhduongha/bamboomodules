using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;
using Volo.Abp.Users;

using Bamboo.Admin;
using Bamboo.Admin.Application.Dtos;
using Bamboo.Admin.Domain.Shared.Enums;
using Volo.Abp.Linq;

namespace Bamboo.Abp.LoginUi.Web.Pages.Account.Workspaces;

public class WorkspaceDto
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public string TenantName { get; set; }
    public TenantMemberStatus Status { get; set; }
    public InvitationStatus InviteStatus { get; set; }
    public List<string> Roles { get; set; } = new();
    public DateTimeOffset? JoinedDate { get; set; }
}

public class IndexModel : AbpPageModel
{
    [BindProperty]
    public List<WorkspaceDto> Workspaces { get; set; }

    private readonly IRepository<TenantMember, Guid> _tenantMemberRepository;
    private readonly IReadOnlyRepository<Tenant, Guid> _tenantRepository;
    private readonly IReadOnlyRepository<IdentityRole, Guid> _roleRepository;
    private readonly IDataFilter _dataFilter;
    protected IAsyncQueryableExecuter AsyncExecuter => LazyServiceProvider.LazyGetRequiredService<IAsyncQueryableExecuter>();

    public IndexModel(
        IRepository<TenantMember, Guid> tenantMemberRepository,
        IReadOnlyRepository<Tenant, Guid> tenantRepository,
        IReadOnlyRepository<IdentityRole, Guid> roleRepository,
        IDataFilter dataFilter)
    {
        _tenantMemberRepository = tenantMemberRepository;
        _tenantRepository = tenantRepository;
        _dataFilter = dataFilter;
        _roleRepository = roleRepository;
    }

    public async Task OnGetAsync()
    {
        // Tắt bộ lọc MultiTenancy để có thể truy vấn dữ liệu từ các tenant khác.
        using (_dataFilter.Disable<IMultiTenant>())
        {
            var userId = CurrentUser.GetId();
            var roles = await _roleRepository.GetQueryableAsync();
            var query = from member in await _tenantMemberRepository.GetQueryableAsync()
                        join tenant in await _tenantRepository.GetQueryableAsync() on member.TenantId equals tenant.Id
                        where member.UserId == userId
                        select new
                        {
                            Member = member,
                            TenantName = tenant.Name,
                            Roles = (from memberRole in member.Roles
                                     join role in roles on memberRole.RoleId equals role.Id
                                     select role.Name).ToList()
                        };

            var result = await AsyncExecuter.ToListAsync(query);

            Workspaces = result.Select(x =>
            {
                return new WorkspaceDto
                {
                    Id = x.Member.Id,
                    TenantId = x.Member.TenantId.Value,
                    TenantName = x.TenantName,
                    Status = x.Member.Status,
                    InviteStatus = x.Member.InviteStatus,
                    Roles = x.Roles,
                    JoinedDate = x.Member.AcceptedAt ?? x.Member.CreationTime
                };
            }).ToList();
        }
    }

    public async Task<IActionResult> OnPostAcceptAsync(Guid invitationId)
    {
        using (_dataFilter.Disable<IMultiTenant>())
        {
            var invitation = await _tenantMemberRepository.GetAsync(invitationId);
            if (invitation.UserId != CurrentUser.GetId())
            {
                return Forbid();
            }
            invitation.AcceptInvitation();
            await _tenantMemberRepository.UpdateAsync(invitation);
        }
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostRejectAsync(Guid invitationId)
    {
        using (_dataFilter.Disable<IMultiTenant>())
        {
            var invitation = await _tenantMemberRepository.GetAsync(invitationId);
            if (invitation.UserId != CurrentUser.GetId())
            {
                return Forbid();
            }
            invitation.RejectInvitation();
            invitation.Status = TenantMemberStatus.Rejected;
            await _tenantMemberRepository.UpdateAsync(invitation);
        }
        return RedirectToPage();
    }
}