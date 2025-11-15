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

[Table("pos_payment")]
//[Index("EmployeeId", Name = "pos_payment__employee_id_index")]
//[Index("PosOrderId", Name = "pos_payment__pos_order_id_index")]
//[Index("SessionId", Name = "pos_payment__session_id_index")]
public partial class PosPayment : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("pos_order_id")]
    public Guid? PosOrderId { get; set; }

    [Column("payment_method_id")]
    public Guid? PaymentMethodId { get; set; }

    [Column("session_id")]
    public Guid? SessionId { get; set; }

    [Column("account_move_id")]
    public Guid? AccountMoveId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("card_type")]
    public string? CardType { get; set; }

    [Column("card_brand")]
    public string? CardBrand { get; set; }

    [Column("card_no")]
    public string? CardNo { get; set; }

    [Column("cardholder_name")]
    public string? CardholderName { get; set; }

    [Column("payment_ref_no")]
    public string? PaymentRefNo { get; set; }

    [Column("payment_method_authcode")]
    public string? PaymentMethodAuthcode { get; set; }

    [Column("payment_method_issuer_bank")]
    public string? PaymentMethodIssuerBank { get; set; }

    [Column("payment_method_payment_mode")]
    public string? PaymentMethodPaymentMode { get; set; }

    [Column("transaction_id")]
    public string? TransactionId { get; set; }

    [Column("payment_status")]
    public string? PaymentStatus { get; set; }

    [Column("ticket")]
    public string? Ticket { get; set; }

    [Column("uuid")]
    public string? Uuid { get; set; }

    [Column("amount")]
    public decimal? Amount { get; set; }

    [Column("is_change")]
    public bool? IsChange { get; set; }

    [Column("payment_date", TypeName = "timestamp without time zone")]
    public DateTime? PaymentDate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("online_account_payment_id")]
    public Guid? OnlineAccountPaymentId { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountMoveId")]
    public virtual AccountMove? AccountMove { get; set; }

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
    [ForeignKey("EmployeeId")]
    public virtual HrEmployee? Employee { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("OnlineAccountPaymentId")]
    public virtual AccountPayment? OnlineAccountPayment { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PaymentMethodId")]
    public virtual PosPaymentMethod? PaymentMethod { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PosOrderId")]
    public virtual PosOrder? PosOrder { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SessionId")]
    public virtual PosSession? Session { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
