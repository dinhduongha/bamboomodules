using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;

namespace Bamboo.AdminExtensions.Dtos;

public class ResetUserPasswordDto : EntityDto<Guid>
{
    //public Guid Id { get; set; }

    //[DisableAuditing]
    public string Password { get; set; } = string.Empty;
    public ResetUserPasswordDto()
    { 
    }
}