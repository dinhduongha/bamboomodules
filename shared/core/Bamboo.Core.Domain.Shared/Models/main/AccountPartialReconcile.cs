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

[Table("account_partial_reconcile")]
//[Index("CreditMoveId", Name = "account_partial_reconcile__credit_move_id_index")]
//[Index("DebitMoveId", Name = "account_partial_reconcile__debit_move_id_index")]
public partial class AccountPartialReconcile : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("debit_move_id")]
    public Guid? DebitMoveId { get; set; }

    [Column("credit_move_id")]
    public Guid? CreditMoveId { get; set; }

    [Column("full_reconcile_id")]
    public Guid? FullReconcileId { get; set; }

    [Column("exchange_move_id")]
    public Guid? ExchangeMoveId { get; set; }

    [Column("debit_currency_id")]
    public Guid? DebitCurrencyId { get; set; }

    [Column("credit_currency_id")]
    public Guid? CreditCurrencyId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("max_date")]
    public DateTime? MaxDate { get; set; }

    [Column("amount")]
    public decimal? Amount { get; set; }

    [Column("debit_amount_currency")]
    public decimal? DebitAmountCurrency { get; set; }

    [Column("credit_amount_currency")]
    public decimal? CreditAmountCurrency { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TaxCashBasisRecId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("TaxCashBasisRec")] // One2many
    public virtual ICollection<AccountMove> AccountMove { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreditCurrencyId")]
    public virtual ResCurrency? CreditCurrency { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreditMoveId")]
    public virtual AccountMoveLine? CreditMove { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("DebitCurrencyId")]
    public virtual ResCurrency? DebitCurrency { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("DebitMoveId")]
    public virtual AccountMoveLine? DebitMove { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ExchangeMoveId")]
    public virtual AccountMove? ExchangeMove { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("FullReconcileId")]
    public virtual AccountFullReconcile? FullReconcile { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
