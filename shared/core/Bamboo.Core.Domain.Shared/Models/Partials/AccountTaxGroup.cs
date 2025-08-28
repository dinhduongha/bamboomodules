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

//[Table("account_tax_group")]
public partial class AccountTaxGroup
{

    // [Column("preceding_subtotal")]
    // public string? PrecedingSubtotal { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("TaxGroupId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("TaxGroup")] // One2many
    public virtual ICollection<AccountTaxTemplate> AccountTaxTemplate { get; set; }

}
