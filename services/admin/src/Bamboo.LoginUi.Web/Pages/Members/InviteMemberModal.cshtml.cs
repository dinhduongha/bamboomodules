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
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Data;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;

namespace Bamboo.Abp.LoginUi.Web.Pages.Admin.Members;

public class InviteMemberModalModel : AbpPageModel
{
    [BindProperty]
    public InviteMemberViewModel Member { get; set; }

    public List<SelectListItem> Roles { get; set; }
    public List<SelectListItem> Tenants { get; set; }

    private readonly IRepository<TenantMember, Guid> _tenantMemberRepository;
    private readonly IReadOnlyRepository<IdentityRole, Guid> _roleRepository;
    private readonly IReadOnlyRepository<Tenant, Guid> _tenantRepository;
    private readonly IDataFilter _dataFilter;
    public ICurrentTenant CurrentTenant { get; }

    public InviteMemberModalModel(
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
        Member = new InviteMemberViewModel();
        if (CurrentTenant.IsAvailable)
        {
            // Nếu là admin của tenant, tải sẵn danh sách vai trò
            var roles = await _roleRepository.GetListAsync();
            Roles = roles.Select(r => new SelectListItem(r.Name, r.Name)).ToList();
            Member.RoleName = "group_user";
        }
        else
        {
            // Host: Tải danh sách tenant, vai trò sẽ được tải sau
            Roles = new List<SelectListItem>();

            // Tải danh sách tenants cho Host
            using (_dataFilter.Disable<IMultiTenant>())
            {
                var tenants = await _tenantRepository.GetListAsync();
                Tenants = tenants.Select(t => new SelectListItem(t.Name, t.Id.ToString())).ToList();
            }
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        // Host sẽ gửi TenantId từ form, admin của tenant sẽ dùng Id của tenant hiện tại
        var tenantId = CurrentTenant.Id ?? Member.TenantId;
        if (!tenantId.HasValue)
        {
            throw new Volo.Abp.UserFriendlyException(L["TenantIsRequired"]);
        }

        // Tìm người dùng bằng email
        var user = await LazyServiceProvider.LazyGetRequiredService<IIdentityUserRepository>().FindByNormalizedEmailAsync(Member.Email.ToUpperInvariant());
        if (user == null)
        {
            throw new Volo.Abp.UserFriendlyException(L["UserWithEmailNotFound", Member.Email]);
        }

        // Kiểm tra xem người dùng đã được mời hoặc đã là thành viên chưa
        if (await _tenantMemberRepository.AnyAsync(x => x.TenantId == tenantId.Value && x.UserId == user.Id))
        {
            throw new Volo.Abp.UserFriendlyException(L["UserIsAlreadyAMember"]);
        }

        // Tạo một thực thể TenantMember mới với trạng thái mời là Pending
        var invitation = new TenantMember(GuidGenerator.Create(), tenantId.Value, user.Id, TenantMemberStatus.Pending);

        // Gán vai trò cho lời mời
        // Cần tắt bộ lọc IMultiTenant để Host có thể query role của tenant khác
        using (_dataFilter.Disable<IMultiTenant>())
        {
            if (Member.Roles.Any())
            {
                var roles = await _roleRepository.GetListAsync(r => r.TenantId == tenantId.Value && Member.Roles.Contains(r.Name));
                foreach (var role in roles)
                {
                    invitation.AddRole(role.Id, GuidGenerator);
                }
            }
        }

        await _tenantMemberRepository.InsertAsync(invitation);

        return NoContent();
    }

    public async Task<JsonResult> OnGetRolesAsync(Guid? tenantId)
    {
        // Tắt bộ lọc đa tenant để có thể truy vấn vai trò của tenant bất kỳ (hoặc host)
        using (_dataFilter.Disable<IMultiTenant>())
        {
            // Lấy các vai trò có TenantId khớp, hoặc là null (cho Host)
            var roles = await _roleRepository.GetListAsync(r => r.TenantId == tenantId);
            // Trả về Name làm value để khớp với asp-for="Member.RoleName"
            return new JsonResult(roles.Select(r => new SelectListItem(r.Name, r.Name)).ToList());
        }
    }
}

public class InviteMemberViewModel
{
    public Guid? UserId { get; set; }

    public Guid? RoleId { get; set; }

    [EmailAddress]
    [Display(Name = "EmailAddress")]
    public string? Email { get; set; }

    public string? RoleName { get; set; }

    public Guid? TenantId { get; set; }
    public List<string> Roles { get; set; } = new();
}