using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;

namespace Bamboo.AdminExtensions.Dtos;
public class ScopeDto : EntityDto<Guid>
{
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public string Resources { get; set; }
    public string Properties { get; set; }
}
