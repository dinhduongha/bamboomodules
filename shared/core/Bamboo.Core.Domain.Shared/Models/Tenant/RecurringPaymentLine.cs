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

[Table("recurring_payment_line")]
public partial class RecurringPaymentLine: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("recurring_payment_id")]
    public Guid? RecurringPaymentId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("journal_id")]
    public Guid? JournalId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("payment_id")]
    public Guid? PaymentId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("amount")]
    public decimal? Amount { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("RecurringPaymentLines")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("RecurringPaymentLineCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("JournalId")]
    //[InverseProperty("RecurringPaymentLines")]
    [NotMapped]
    public virtual AccountJournal? Journal { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("RecurringPaymentLines")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("PaymentId")]
    //[InverseProperty("RecurringPaymentLines")]
    [NotMapped]
    public virtual AccountPayment? Payment { get; set; }

    [ForeignKey("RecurringPaymentId")]
    //[InverseProperty("RecurringPaymentLines")]
    [NotMapped]
    public virtual RecurringPayment? RecurringPayment { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("RecurringPaymentLineWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
