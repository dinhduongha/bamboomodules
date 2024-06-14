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

[Table("pos_payment")]
//[Index("SessionId", Name = "pos_payment_session_id_index")]
public partial class PosPayment: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("pos_order_id")]
    public Guid? PosOrderId { get; set; }

    [Column("payment_method_id")]
    public Guid? PaymentMethodId { get; set; }

    [Column("session_id")]
    public Guid? SessionId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("account_move_id")]
    public Guid? AccountMoveId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("card_type")]
    public string? CardType { get; set; }

    [Column("cardholder_name")]
    public string? CardholderName { get; set; }

    [Column("transaction_id")]
    public string? TransactionId { get; set; }

    [Column("payment_status")]
    public string? PaymentStatus { get; set; }

    [Column("ticket")]
    public string? Ticket { get; set; }

    [Column("amount")]
    public decimal? Amount { get; set; }

    [Column("is_change")]
    public bool? IsChange { get; set; }

    [Column("payment_date", TypeName = "timestamp without time zone")]
    public DateTime? PaymentDate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("AccountMoveId")]
    //[InverseProperty("PosPayments")]
    [NotMapped]
    public virtual AccountMove? AccountMove { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("PosPayments")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("PosPaymentCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("PaymentMethodId")]
    //[InverseProperty("PosPayments")]
    [NotMapped]
    public virtual PosPaymentMethod? PaymentMethod { get; set; }

    [ForeignKey("PosOrderId")]
    //[InverseProperty("PosPayments")]
    [NotMapped]
    public virtual PosOrder? PosOrder { get; set; }

    [ForeignKey("SessionId")]
    //[InverseProperty("PosPayments")]
    [NotMapped]
    public virtual PosSession? Session { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("PosPaymentWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
