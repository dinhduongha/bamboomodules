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

public partial class AccountTax
{
    // [JsonField] // InvoiceLegalNotes
    // [Column("invoice_legal_notes", TypeName = "jsonb")]
    // public JsonElement? InvoiceLegalNotes { get; set; }

    [Column("is_domestic")]
    public bool? IsDomestic { get; set; }

    // [Column("formula")]
    // public string? Formula { get; set; }

    [Column("withholding_sequence_id")]
    public Guid? WithholdingSequenceId { get; set; }

    [Column("is_withholding_tax_on_payment")]
    public bool? IsWithholdingTaxOnPayment { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SourceTaxId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SourceTax")] // One2many
    public virtual ICollection<AccountPaymentRegisterWithholdingLine> AccountPaymentRegisterWithholdingLineSourceTax { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TaxId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Tax")] // One2many
    public virtual ICollection<AccountPaymentRegisterWithholdingLine> AccountPaymentRegisterWithholdingLineTax { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SourceTaxId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SourceTax")] // One2many
    public virtual ICollection<AccountPaymentWithholdingLine> AccountPaymentWithholdingLineSourceTax { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TaxId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Tax")] // One2many
    public virtual ICollection<AccountPaymentWithholdingLine> AccountPaymentWithholdingLineTax { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("WithholdingSequenceId")]
    public virtual IrSequence? WithholdingSequence { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountTaxId")] //Many2many // Hidden
    // [InverseProperty("AccountTax")] //Many2many // Hidden
    public virtual ICollection<AccountFiscalPosition> AccountFiscalPosition { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("SrcTaxId")] // Many2many // Normal
    // [InverseProperty("SrcTax")] // Many2many // Normal
    public virtual ICollection<AccountTax> DestTax { get; set; }

    // [Many2many] // Hidden
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] //Many2many // Hidden
    // // [ForeignKey("AccountTaxId")] //Many2many // Hidden
    // // [InverseProperty("AccountTax")] //Many2many // Hidden
    // public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("DestTaxId")] // Many2many // Normal
    // [InverseProperty("DestTax")] // Many2many // Normal
    public virtual ICollection<AccountTax> SrcTax { get; set; }
}