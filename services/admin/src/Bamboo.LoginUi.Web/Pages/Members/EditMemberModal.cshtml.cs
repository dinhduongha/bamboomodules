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
using Volo.Abp.Linq;

namespace Bamboo.Abp.LoginUi.Web.Pages.Admin.Members;

public class EditMemberModalModel : AbpPageModel
{
    [BindProperty]
    public EditMemberViewModel Member { get; set; }

    public List<SelectListItem> AllRoles { get; set; }
    public List<SelectListItem> AllStatuses { get; set; }

    private readonly ICurrentTenant _currentTenant;
    private readonly IRepository<TenantMember, Guid> _tenantMemberRepository;
    private readonly IReadOnlyRepository<IdentityUser, Guid> _userRepository;
    private readonly IReadOnlyRepository<IdentityRole, Guid> _roleRepository;
    private readonly IDataFilter _dataFilter;
    private readonly IAsyncQueryableExecuter _asyncExecuter;

    public EditMemberModalModel(
        ICurrentTenant currentTenant,
        IRepository<TenantMember, Guid> tenantMemberRepository,
        IReadOnlyRepository<IdentityUser, Guid> userRepository,
        IReadOnlyRepository<IdentityRole, Guid> roleRepository,
        IAsyncQueryableExecuter asyncExecuter,
        IDataFilter dataFilter)
    {
        _currentTenant = currentTenant;
        _tenantMemberRepository = tenantMemberRepository;
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _asyncExecuter = asyncExecuter;
        _dataFilter = dataFilter;
        if (!currentTenant.IsAvailable)
        {
            _dataFilter.Disable<IMultiTenant>();
        }
    }

    public async Task OnGetAsync(Guid id)
    {
        var query = await _tenantMemberRepository.WithDetailsAsync(x => x.Roles, x => x.OrganizationUnits);
        query = query.Where(x => x.Id == id);
        var member = await _asyncExecuter.FirstOrDefaultAsync(query);

        using (_dataFilter.Disable<IMultiTenant>())
        {
            var user = await _userRepository.FindAsync(member.UserId.Value);
            var roles = await _roleRepository.GetListAsync(r => r.TenantId == member.TenantId && r.Name != "owner");
            AllRoles = roles.Select(r => new SelectListItem(r.Name, r.Id.ToString())).ToList();
            Member = new EditMemberViewModel
            {
                Id = member.Id,
                UserName = user.UserName,
                Status = member.Status,
                Description = member.Description,
                SelectedRoles = member.Roles.Select(r => r.RoleId).ToList()
            };
        }

        AllStatuses = Enum.GetValues(typeof(TenantMemberStatus))
            .Cast<TenantMemberStatus>()
            .Select(s => new SelectListItem(L[$"Enum:TenantMemberStatus.{s}"], ((int)s).ToString()))
            .ToList();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var tenantId = CurrentTenant.Id ?? null;
        TenantMember member;
        var query = await _tenantMemberRepository.WithDetailsAsync(x => x.Roles, x => x.OrganizationUnits);
        query = query.Where(x => x.Id == Member.Id);

        if (CurrentTenant.IsAvailable)
        {
            member = await _asyncExecuter.FirstOrDefaultAsync(query);

        }
        else
        {
            using (_dataFilter.Disable<IMultiTenant>())
            {
                member = await _asyncExecuter.FirstOrDefaultAsync(query);
                tenantId = member.TenantId;
            }
        }
        using (CurrentTenant.Change(tenantId))
        {
            member.Status = Member.Status;
            member.Description = Member.Description;

            var currentRoleIds = member.Roles.Select(r => r.RoleId).ToList();
            var selectedRoleIds = Member.SelectedRoles ?? new List<Guid>();

            var rolesToRemove = member.Roles.Where(r => !selectedRoleIds.Contains(r.RoleId)).ToList();
            foreach (var role in rolesToRemove)
            {
                member.Roles.Remove(role);
            }

            foreach (var roleId in selectedRoleIds.Where(id => !currentRoleIds.Contains(id)))
            {
                member.AddRole(roleId, GuidGenerator);
            }

            await _tenantMemberRepository.UpdateAsync(member);
        }
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