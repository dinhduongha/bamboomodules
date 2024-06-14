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

[Table("account_partial_reconcile")]
//[Index("CreditMoveId", Name = "account_partial_reconcile_credit_move_id_index")]
//[Index("DebitMoveId", Name = "account_partial_reconcile_debit_move_id_index")]
public partial class AccountPartialReconcile: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("debit_move_id")]
    public Guid? DebitMoveId { get; set; }

    [Column("credit_move_id")]
    public Guid? CreditMoveId { get; set; }

    [Column("full_reconcile_id")]
    public Guid? FullReconcileId { get; set; }

    [Column("exchange_move_id")]
    public Guid? ExchangeMoveId { get; set; }

    [Column("debit_currency_id")]
    public long? DebitCurrencyId { get; set; }

    [Column("credit_currency_id")]
    public long? CreditCurrencyId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("max_date")]
    public DateTime? MaxDate { get; set; }

    [Column("amount")]
    public decimal? Amount { get; set; }

    [Column("debit_amount_currency")]
    public decimal? DebitAmountCurrency { get; set; }

    [Column("credit_amount_currency")]
    public decimal? CreditAmountCurrency { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("AccountPartialReconciles")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountPartialReconcileCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CreditCurrencyId")]
    //[InverseProperty("AccountPartialReconcileCreditCurrencies")]
    [NotMapped]
    public virtual ResCurrency? CreditCurrency { get; set; }

    [ForeignKey("CreditMoveId")]
    //[InverseProperty("AccountPartialReconcileCreditMoves")]
    [NotMapped]
    public virtual AccountMoveLine? CreditMove { get; set; }

    [ForeignKey("DebitCurrencyId")]
    //[InverseProperty("AccountPartialReconcileDebitCurrencies")]
    [NotMapped]
    public virtual ResCurrency? DebitCurrency { get; set; }

    [ForeignKey("DebitMoveId")]
    //[InverseProperty("AccountPartialReconcileDebitMoves")]
    [NotMapped]
    public virtual AccountMoveLine? DebitMove { get; set; }

    [ForeignKey("ExchangeMoveId")]
    //[InverseProperty("AccountPartialReconciles")]
    [NotMapped]
    public virtual AccountMove? ExchangeMove { get; set; }

    [ForeignKey("FullReconcileId")]
    //[InverseProperty("AccountPartialReconciles")]
    [NotMapped]
    public virtual AccountFullReconcile? FullReconcile { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountPartialReconcileWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("TaxCashBasisRec")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMoves { get; } = new List<AccountMove>();


}
