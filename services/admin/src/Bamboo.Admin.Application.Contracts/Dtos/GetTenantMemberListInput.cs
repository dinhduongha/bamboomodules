using System;
using Volo.Abp.Application.Dtos;

namespace Bamboo.Admin.Application.Dtos;

public class GetTenantMemberListInput : PagedAndSortedResultRequestDto
{
    public Guid? TenantId { get; set; }
    public string Filter { get; set; }
}
