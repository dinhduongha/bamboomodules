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

//[Table("payment_provider")]
//[Index("CompanyId", Name = "payment_provider__company_id_index")]
public partial class PaymentProvider
{
    [Column("module_state")]
    public string? ModuleState { get; set; }

    [JsonField]
    [Column("display_as", TypeName = "jsonb")]
    public string? DisplayAs { get; set; }

    [Column("fees_active")]
    public bool? FeesActive { get; set; }

    [Column("fees_dom_fixed")]
    public double? FeesDomFixed { get; set; }

    [Column("fees_dom_var")]
    public double? FeesDomVar { get; set; }

    [Column("fees_int_fixed")]
    public double? FeesIntFixed { get; set; }

    [Column("fees_int_var")]
    public double? FeesIntVar { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("PaymentProviderId")] // Many2many // Normal
    // [InverseProperty("PaymentProvider")] // Many2many // Normal
    public virtual ICollection<PaymentIcon> PaymentIcon { get; set; }
}
