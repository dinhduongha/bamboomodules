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
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Pagination;
using Bamboo.Admin.Application.Dtos;

namespace Bamboo.Abp.LoginUi.Web.Pages.Admin.Members;

[Authorize(Roles = "superadmin,admin")]
public class IndexModel : AbpPageModel
{
    [BindProperty(SupportsGet = true)]
    public GetTenantMembersInput Input { get; set; }
    public PagerModel PagerModel { get; set; }

    // [BindProperty(SupportsGet = true)]
    // public string Filter { get; set; }

    // [BindProperty(SupportsGet = true)]
    // public Guid? TenantId { get; set; }

    [BindProperty(SupportsGet = true)]
    public string ReturnUrl { get; set; }

    [BindProperty(SupportsGet = true)]
    public string ReturnUrlHash { get; set; }

    [BindProperty]
    public string SessionHandle { get; set; }

    // public int SkipCount => (CurrentPage - 1) * MaxResultCount;

    //[BindProperty(SupportsGet = true)]
    //public int CurrentPage { get; set; } = 1;

    // [BindProperty(SupportsGet = true)]
    // public int MaxResultCount { get; set; } = 10;

    public PagedResultDto<MemberDto> Members { get; set; }
    //public int TotalPages => (int)Math.Ceiling(decimal.Divide(Members?.TotalCount ?? 0, MaxResultCount));

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

    public async Task OnGetAsync()
    {
        if (!CurrentUser.Id.HasValue)
        {
            RedirectToPage("/Account/Login", new { returnUrl = ReturnUrl });
        }
        if (Input.MaxResultCount < 1) Input.MaxResultCount = 10;
        //if (CurrentPage < 1) CurrentPage = 1;
        //Input.SkipCount = (Input.CurrentPage - 1) * Input.MaxResultCount;

        if (Input.SkipCount < 0) Input.SkipCount = 0;
        var tenantId = _currentTenant.Id ?? Input.TenantId;

        using (_dataFilter.Disable<IMultiTenant>())
        {
            var memberQueryable = await _tenantMemberRepository.WithDetailsAsync(x => x.Roles, x => x.OrganizationUnits);
            var userQueryable = await _userRepository.GetQueryableAsync();
            var tenantQueryable = await _tenantRepository.GetQueryableAsync();
            var roleQueryable = await _roleRepository.GetQueryableAsync();
            if (_currentTenant.IsAvailable)
            {
                memberQueryable = memberQueryable.Where(x => x.TenantId == _currentTenant.Id);
                tenantQueryable = tenantQueryable.Where(x => x.Id == _currentTenant.Id);
                roleQueryable = roleQueryable.Where(x => x.TenantId == _currentTenant.Id);
            }


            var query = from member in memberQueryable
                        join user in userQueryable on member.UserId equals user.Id
                        join tenant in tenantQueryable on member.TenantId equals tenant.Id
                        where !tenantId.HasValue || member.TenantId == tenantId.Value
                        select new { Member = member, User = user, Tenant = tenant };

            if (!Input.Filter.IsNullOrWhiteSpace())
            {
                query = query.Where(x => x.Tenant.Name.Contains(Input.Filter) || x.User.UserName.Contains(Input.Filter) || x.User.Email.Contains(Input.Filter));
            }

            var totalCount = await _asyncExecuter.CountAsync(query);

            var pagedQuery = query.OrderByDescending(x => x.Member.CreationTime)
                                    .PageBy(Input.SkipCount, Input.MaxResultCount);

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
                    TenantId = x.Member.TenantId,
                    UserName = x.User.UserName,
                    Email = x.User.Email,
                    Status = x.Member.Status,
                    InviteStatus = x.Member.InviteStatus,
                    TenantName = x.Tenant.Name,
                    Role = x.Member.Role,
                    JoinedDate = x.Member.AcceptedAt ?? x.Member.CreationTime,
                    Roles = roles
                };
            }).ToList();

            Members = new PagedResultDto<MemberDto>(totalCount, memberDtos);
            var currentPage = (Input.SkipCount / Input.MaxResultCount) + 1;
            PagerModel = new PagerModel(
                totalCount: Members.TotalCount,
                shownItemsCount: Members.Items.Count,
                currentPage: Input.CurrentPage,
                pageSize: Input.MaxResultCount,
                //pageUrl: Url.Page(null, new { Input.Filter, Input.TenantId, Input.MaxResultCount })
                pageUrl: this.GetPagedUrl(Input) // Tự động giữ các tham số filter
            );
        }
    }


}