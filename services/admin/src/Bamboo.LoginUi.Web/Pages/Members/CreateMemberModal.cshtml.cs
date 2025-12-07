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

public class CreateMemberModalModel : AbpPageModel
{
    [BindProperty]
    public CreateMemberViewModel Member { get; set; }

    public List<SelectListItem> Roles { get; set; }
    public List<SelectListItem> Tenants { get; set; }

    private readonly IRepository<TenantMember, Guid> _tenantMemberRepository;
    private readonly IReadOnlyRepository<IdentityRole, Guid> _roleRepository;
    private readonly IReadOnlyRepository<Tenant, Guid> _tenantRepository;
    private readonly IDataFilter _dataFilter;
    public ICurrentTenant CurrentTenant { get; }

    public CreateMemberModalModel(
        IRepository<TenantMember, Guid> tenantMemberRepository,
        IReadOnlyRepository<IdentityRole, Guid> roleRepository,
        IReadOnlyRepository<Tenant, Guid> tenantRepository,
        IDataFilter dataFilter,
        ICurrentTenant currentTenant)
    {
        _tenantMemberRepository = tenantMemberRepository;
        _roleRepository = roleRepository;
        _tenantRepository = tenantRepository;
        _dataFilter = dataFilter;
        CurrentTenant = currentTenant;
    }

    public async Task OnGetAsync()
    {
        Member = new CreateMemberViewModel();
        if (CurrentTenant.IsAvailable)
        {
            var roles = await _roleRepository.GetListAsync();
            Roles = roles.Select(r => new SelectListItem(r.Name, r.Name)).ToList();
        }
        else
        {

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

        if (await _tenantMemberRepository.AnyAsync(x => x.TenantId == tenantId.Value && x.UserId == Member.UserId))
        {
            throw new Volo.Abp.UserFriendlyException(L["UserIsAlreadyAMember"]);
        }

        var newMember = new TenantMember(GuidGenerator.Create(), tenantId.Value, Member.UserId, TenantMemberStatus.Active);

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

public class CreateMemberViewModel
{
    [Required] public Guid UserId { get; set; }
    public Guid? TenantId { get; set; }
    public List<string> Roles { get; set; } = new();
    [Required]
    [EmailAddress]
    [Display(Name = "EmailAddress")]
    public string Email { get; set; }

}
