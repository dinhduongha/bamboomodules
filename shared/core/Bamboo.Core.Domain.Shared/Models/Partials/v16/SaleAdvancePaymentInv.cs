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

//[Table("sale_advance_payment_inv")]
public partial class SaleAdvancePaymentInv
{
    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("deposit_account_id")]
    public Guid? DepositAccountId { get; set; }

    // [Many2one]
    [ForeignKey("DepositAccountId")]
    public virtual AccountAccount? DepositAccount { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    public virtual ProductProduct? Product { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("SaleAdvancePaymentInvId")] // Many2many // Normal
    // [InverseProperty("SaleAdvancePaymentInv")] // Many2many // Normal
    public virtual ICollection<AccountTax> AccountTax { get; set; }

}
