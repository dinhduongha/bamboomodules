using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Bamboo.Admin;
using Bamboo.Admin.Domain.Shared.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;

namespace Bamboo.Abp.LoginUi.Web.Pages.Admin.Members;

public class AddMemberModalModel : AbpPageModel
{
    [BindProperty]
    public AddMemberViewModel Member { get; set; }

    public List<SelectListItem> Roles { get; set; }
    public List<SelectListItem> Tenants { get; set; }

    private readonly IRepository<TenantMember, Guid> _tenantMemberRepository;
    private readonly IReadOnlyRepository<IdentityRole, Guid> _roleRepository;
    private readonly IReadOnlyRepository<Tenant, Guid> _tenantRepository;
    private readonly IReadOnlyRepository<IdentityUser, Guid> _userRepository;

    private readonly IDataFilter _dataFilter;
    public ICurrentTenant CurrentTenant { get; }

    public AddMemberModalModel(
        IRepository<TenantMember, Guid> tenantMemberRepository,
        IReadOnlyRepository<IdentityRole, Guid> roleRepository,
        IReadOnlyRepository<Tenant, Guid> tenantRepository,
        IReadOnlyRepository<IdentityUser, Guid> userRepository,
        IDataFilter dataFilter,
        ICurrentTenant currentTenant)
    {
        _tenantMemberRepository = tenantMemberRepository;
        _roleRepository = roleRepository;
        _tenantRepository = tenantRepository;
        _userRepository = userRepository;
        _dataFilter = dataFilter;
        CurrentTenant = currentTenant;
    }

    public async Task OnGetAsync()
    {
        Member = new AddMemberViewModel();
        if (CurrentTenant.IsAvailable)
        {
            // Tenant admin: Tải vai trò của tenant hiện tại
            var roles = await _roleRepository.GetListAsync(r => r.Name != "owner");
            Roles = roles.Select(r => new SelectListItem(r.Name, r.Id.ToString())).ToList();
            // Tìm Id của vai trò 'group_user' và đặt làm giá trị mặc định
            var defaultRole = roles.FirstOrDefault(r => r.Name == "group_user");
            if (defaultRole != null) { Member.RoleId = defaultRole.Id; }
        }
        else
        {
            // Host: Tải danh sách tenant, vai trò sẽ được tải sau
            Roles = new List<SelectListItem>();
            using (_dataFilter.Disable<IMultiTenant>())
            {
                var tenants = await _tenantRepository.GetListAsync();
                Tenants = tenants.Select(t => new SelectListItem(t.Name, t.Id.ToString())).ToList();
            }
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var tenantId = CurrentTenant.Id ?? Member.TenantId;
        if (!tenantId.HasValue)
        {
            throw new Volo.Abp.UserFriendlyException(L["TenantIsRequired"]);
        }
        using (_dataFilter.Disable<IMultiTenant>())
        {
            //user = await _userRepository.FirstOrDefaultAsync(x => x.Id == Member.UserId);
            var tenant = await _tenantRepository.FirstOrDefaultAsync(x => x.Id == tenantId.Value);
            if (tenant == null)
            {
                throw new Volo.Abp.UserFriendlyException(L["TenantIsRequired"]);
            }
        }
        Volo.Abp.Identity.IdentityUser user;
        using (CurrentTenant.Change(null))
        {
            user = await _userRepository.FirstOrDefaultAsync(x => x.Id == Member.UserId); ;
        }
        if (user == null)
        {
            throw new Volo.Abp.UserFriendlyException(L["UserNotFound", Member.Email]);
        }

        if (await _tenantMemberRepository.AnyAsync(x => x.TenantId == tenantId.Value && x.UserId == Member.UserId))
        {
            throw new Volo.Abp.UserFriendlyException(L["UserIsAlreadyAMember"]);
        }

        var newMember = new TenantMember(GuidGenerator.Create(), tenantId.Value, (Guid)Member.UserId, TenantMemberStatus.Active, InvitationStatus.Accepted);
        if (Member.RoleId != null)
        {
            newMember.AddRole((Guid)Member.RoleId, GuidGenerator);
        }

        using (_dataFilter.Disable<IMultiTenant>())
        {
            var roles = await _roleRepository.GetListAsync(r => r.TenantId == tenantId.Value && Member.Roles.Contains(r.Name));
            foreach (var role in roles)
            {
                newMember.AddRole(role.Id, GuidGenerator);
            }
        }

        await _tenantMemberRepository.InsertAsync(newMember);
        return NoContent();
    }
}

public class AddMemberViewModel
{
    public Guid? UserId { get; set; }
    public Guid? TenantId { get; set; }
    public List<string> Roles { get; set; } = new();

    [EmailAddress]
    [Display(Name = "EmailAddress")]
    public string? Email { get; set; }

    public string? RoleName { get; set; } = "group_user";

    public Guid? RoleId { get; set; }

}
