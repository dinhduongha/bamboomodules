using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("account_tax")]
//[Index("Name", "CompanyId", "TypeTaxUse", "TaxScope", Name = "account_tax_name_company_uniq", IsUnique = true)]
public partial class AccountTax
{
    [Column("price_include")]
    public bool? PriceInclude { get; set; }

    [Column("real_amount")]
    public double? RealAmount { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("InvoiceTaxId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("InvoiceTax")] // One2many
    public virtual ICollection<AccountTaxRepartitionLine> AccountTaxRepartitionLineInvoiceTax { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("RefundTaxId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("RefundTax")] // One2many
    public virtual ICollection<AccountTaxRepartitionLine> AccountTaxRepartitionLineRefundTax { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("TaxId")] //Many2many // Hidden
    // [InverseProperty("Tax")] //Many2many // Hidden
    public virtual ICollection<RepairFee> RepairFeeLine { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("TaxId")] //Many2many // Hidden
    // [InverseProperty("Tax")] //Many2many // Hidden
    public virtual ICollection<RepairLine> RepairOperationLine { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountTaxId")] //Many2many // Hidden
    // [InverseProperty("AccountTax")] //Many2many // Hidden
    public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInv { get; set; }
}
