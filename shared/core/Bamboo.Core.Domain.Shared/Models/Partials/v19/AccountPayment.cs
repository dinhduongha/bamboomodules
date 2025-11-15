using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

public partial class AccountPayment
{
    [Column("check_number")]
    public string? CheckNumber { get; set; }

    [Column("check_amount_in_words")]
    public string? CheckAmountInWords { get; set; }

    [Column("should_withhold_tax")]
    public bool? ShouldWithholdTax { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PaymentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Payment")] // One2many
    public virtual ICollection<AccountPaymentWithholdingLine> AccountPaymentWithholdingLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PaymentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Payment")] // One2many
    public virtual ICollection<L10nLatamCheck> L10nLatamCheck { get; set; }


    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("PaymentId")] // Many2many // Normal
    // [InverseProperty("PaymentNavigation")] // Many2many // Normal
    public virtual ICollection<L10nLatamCheck> Check { get; set; }

}