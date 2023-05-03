using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Table("sale_advance_payment_inv")]
public partial class SaleAdvancePaymentInv: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("currency_id")]
    public long? CurrencyId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("deposit_account_id")]
    public Guid? DepositAccountId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("advance_payment_method")]
    public string? AdvancePaymentMethod { get; set; }

    [Column("fixed_amount")]
    public decimal? FixedAmount { get; set; }

    [Column("deduct_down_payments")]
    public bool? DeductDownPayments { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("amount")]
    public double? Amount { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("SaleAdvancePaymentInvs")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SaleAdvancePaymentInvCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CurrencyId")]
    //[InverseProperty("SaleAdvancePaymentInvs")]
    [NotMapped]
    public virtual ResCurrency? Currency { get; set; }

    [ForeignKey("DepositAccountId")]
    //[InverseProperty("SaleAdvancePaymentInvs")]
    [NotMapped]
    public virtual AccountAccount? DepositAccount { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("SaleAdvancePaymentInvs")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SaleAdvancePaymentInvWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("SaleAdvancePaymentInvId")]
    //[InverseProperty("SaleAdvancePaymentInvs")]
    [NotMapped]
    public virtual ICollection<AccountTax> AccountTaxes { get; } = new List<AccountTax>();

    [ForeignKey("SaleAdvancePaymentInvId")]
    //[InverseProperty("SaleAdvancePaymentInvs")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrders { get; } = new List<SaleOrder>();
}
