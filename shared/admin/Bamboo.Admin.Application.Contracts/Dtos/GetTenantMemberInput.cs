using System;
using Volo.Abp.Application.Dtos;

namespace Bamboo.Admin.Application.Dtos;

public class GetTenantMembersInput : PagedAndSortedResultRequestDto
{
    public Guid? TenantId { get; set; }
    public string? Filter { get; set; }

    public int CurrentPage
    {
        get => (SkipCount / MaxResultCount) + 1;
        set => SkipCount = (value > 0 ? value - 1 : 0) * MaxResultCount;
    }
}

