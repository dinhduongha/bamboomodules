using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;

using Bamboo.Admin;
using Bamboo.Admin.Domain.Shared.Enums;

namespace Bamboo.Abp.LoginUi.Web.Pages.Admin.Members;

public class EditMemberModalModel : AbpPageModel
{
    [BindProperty]
    public EditMemberViewModel Member { get; set; }

    public List<SelectListItem> AllRoles { get; set; }
    public List<SelectListItem> AllStatuses { get; set; }

    private readonly IRepository<TenantMember, Guid> _tenantMemberRepository;
    private readonly IReadOnlyRepository<IdentityUser, Guid> _userRepository;
    private readonly IReadOnlyRepository<IdentityRole, Guid> _roleRepository;
    private readonly IDataFilter _dataFilter;

    public EditMemberModalModel(
        IRepository<TenantMember, Guid> tenantMemberRepository,
        IReadOnlyRepository<IdentityUser, Guid> userRepository,
        IReadOnlyRepository<IdentityRole, Guid> roleRepository,
        IDataFilter dataFilter)
    {
        _tenantMemberRepository = tenantMemberRepository;
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _dataFilter = dataFilter;
    }

    public async Task OnGetAsync(Guid id)
    {
        var member = await _tenantMemberRepository.GetAsync(id, includeDetails: true);
        var user = await _userRepository.GetAsync(member.UserId.Value);

        Member = new EditMemberViewModel
        {
            Id = member.Id,
            UserName = user.UserName,
            Status = member.Status,
            Description = member.Description,
            SelectedRoles = member.Roles.Select(r => r.RoleId).ToList()
        };

        using (_dataFilter.Disable<IMultiTenant>())
        {
            var roles = await _roleRepository.GetListAsync(r => r.TenantId == member.TenantId);
            AllRoles = roles.Select(r => new SelectListItem(r.Name, r.Id.ToString())).ToList();
        }

        AllStatuses = Enum.GetValues(typeof(TenantMemberStatus))
            .Cast<TenantMemberStatus>()
            .Select(s => new SelectListItem(L[$"Enum:TenantMemberStatus.{s}"], ((int)s).ToString()))
            .ToList();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var member = await _tenantMemberRepository.GetAsync(Member.Id, includeDetails: true);

        member.Status = Member.Status;
        member.Description = Member.Description;

        member.Roles.Clear();
        foreach (var roleId in Member.SelectedRoles)
        {
            member.AddRole(roleId, GuidGenerator);
        }

        await _tenantMemberRepository.UpdateAsync(member);

        return NoContent();
    }
}

public class EditMemberViewModel
{
    [HiddenInput]
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public List<Guid> SelectedRoles { get; set; } = new();
    [Display(Name = "IsActive")]
    public bool IsActive { get; set; }
    [Display(Name = "Status")]
    public TenantMemberStatus Status { get; set; }
    [Display(Name = "Description")]
    public string Description { get; set; }
}