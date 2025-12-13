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
using Microsoft.AspNetCore.Authorization;

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
    public bool IsOwner { get; set; } = false;
    public DateTime? TenantCreatorAt { get; set; }
    public Guid? TenantCreatorId { get; set; }
}

[Authorize]
public class IndexModel : AbpPageModel
{
    [BindProperty]
    public PagedResultDto<WorkspaceDto> Workspaces { get; set; }
    public int TotalPages => (int)Math.Ceiling(decimal.Divide(Workspaces?.TotalCount ?? 0, PageSize));

    [BindProperty(SupportsGet = true)]
    public string ReturnUrl { get; set; }

    [BindProperty(SupportsGet = true)]
    public string ReturnUrlHash { get; set; }

    [BindProperty(SupportsGet = true)]
    public string Filter { get; set; }

    [BindProperty(SupportsGet = true)]
    public int CurrentPage { get; set; } = 1;

    [BindProperty(SupportsGet = true)]
    public int PageSize { get; set; } = 10; // 10 dòng mỗi trang

    [BindProperty]
    public string SessionHandle { get; set; }

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
        _roleRepository = roleRepository;
        _dataFilter = dataFilter;
    }

    public async Task OnGetAsync()
    {
        if (!CurrentUser.Id.HasValue)
        {
            RedirectToPage("/Account/Login", new { returnUrl = ReturnUrl });
        }

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
                            Tenant = tenant,
                            TenantName = tenant.Name,
                            Roles = (from memberRole in member.Roles
                                     join role in roles on memberRole.RoleId equals role.Id
                                     select new { Name = role.Name, Id = role.Id }).ToList()
                        };
            if (!Filter.IsNullOrWhiteSpace())
            {
                query = query.Where(x => x.Tenant.Name.Contains(Filter));
            }
            query = query.OrderByDescending(x => x.Member.AcceptedAt ?? x.Member.CreationTime);

            var totalCount = await AsyncExecuter.CountAsync(query);
            query = query.Skip(CurrentPage - 1).Take(PageSize);
            var result = await AsyncExecuter.ToListAsync(query);

            var items = result.Select(x =>
            {
                return new WorkspaceDto
                {
                    Id = x.Member.Id,
                    TenantId = x.Member.TenantId.Value,
                    TenantName = x.TenantName,
                    Status = x.Member.Status,
                    InviteStatus = x.Member.InviteStatus,
                    Roles = x.Roles.Select(r => r.Name).ToList(),
                    IsOwner = x.Member.IsOwner,
                    TenantCreatorAt = x.Tenant.CreationTime,
                    TenantCreatorId = x.Tenant.CreatorId,
                    JoinedDate = x.Member.AcceptedAt ?? x.Member.CreationTime
                };
            }).ToList();
            Workspaces = new PagedResultDto<WorkspaceDto>(totalCount, items);
        }
    }

    public async Task<IActionResult> OnPostAcceptAsync(Guid invitationId)
    {
        if (!CurrentUser.Id.HasValue)
        {
            RedirectToPage("/Account/Login", new { returnUrl = ReturnUrl });
        }
        using (_dataFilter.Disable<IMultiTenant>())
        {
            var invitation = await _tenantMemberRepository.GetAsync(invitationId);
            if (invitation.UserId != CurrentUser.GetId())
            {
                return Forbid();
            }
            invitation.AcceptInvitation();
            invitation.IsActive = true;
            invitation.Status = TenantMemberStatus.Active;
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
            invitation.Status = TenantMemberStatus.Leaved;
            await _tenantMemberRepository.UpdateAsync(invitation);
        }
        return RedirectToPage();
    }
}