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

public partial class AccountPaymentRegister
{

    // // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [One2many] [ForeignKey("PaymentRegisterId")]
    // // [NotMapped] // One2many // Normal
    // // [InverseProperty("PaymentRegister")] // One2many
    // public virtual ICollection<AccountPaymentRegisterWithholdingLine> AccountPaymentRegisterWithholdingLine { get; set; }

    [Column("withholding_outstanding_account_id")]
    public Guid? WithholdingOutstandingAccountId { get; set; }

    [Column("withholding_net_amount")]
    public decimal? WithholdingNetAmount { get; set; }

    [Column("should_withhold_tax")]
    public bool? ShouldWithholdTax { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PaymentRegisterId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PaymentRegister")] // One2many
    public virtual ICollection<AccountPaymentRegisterWithholdingLine> AccountPaymentRegisterWithholdingLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PaymentRegisterId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PaymentRegister")] // One2many
    public virtual ICollection<L10nLatamPaymentRegisterCheck> L10nLatamPaymentRegisterCheck { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("WithholdingOutstandingAccountId")]
    public virtual AccountAccount? WithholdingOutstandingAccount { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("AccountPaymentRegisterId")] // Many2many // Normal
    // [InverseProperty("AccountPaymentRegister")] // Many2many // Normal
    public virtual ICollection<L10nLatamCheck> L10nLatamCheck { get; set; }


}