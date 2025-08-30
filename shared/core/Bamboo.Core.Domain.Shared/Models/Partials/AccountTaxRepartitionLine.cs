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

//[Table("account_tax_repartition_line")]
public partial class AccountTaxRepartitionLine
{
    [Column("invoice_tax_id")]
    public Guid? InvoiceTaxId { get; set; }

    [Column("refund_tax_id")]
    public Guid? RefundTaxId { get; set; }

    // [Many2one]
    [ForeignKey("InvoiceTaxId")]
    public virtual AccountTax? InvoiceTax { get; set; }

    // [Many2one]
    [ForeignKey("RefundTaxId")]
    public virtual AccountTax? RefundTax { get; set; }

}
