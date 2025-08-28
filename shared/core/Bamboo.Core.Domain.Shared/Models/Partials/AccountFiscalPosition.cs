using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("account_fiscal_position")]
public partial class AccountFiscalPosition
{
    // [One2many]
    // [One2many] [ForeignKey("DefaultFiscalPositionId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("DefaultFiscalPosition")] // One2many
    public virtual ICollection<PosConfig> PosConfigNavigation { get; set; }
}
