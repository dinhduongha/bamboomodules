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

//[Table("pos_payment_method")]
public partial class PosPaymentMethod
{
    // [Many2many] // Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("PosPaymentMethodId")] //Many2many // Hidden
    // [InverseProperty("PosPaymentMethod")] //Many2many // Hidden
    // public virtual ICollection<PosConfig> PosConfig { get; set; }
}
