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

[Table("recurring_payment")]
public partial class RecurringPayment: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("template_id")]
    public Guid? TemplateId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("payment_type")]
    public string? PaymentType { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("date_begin")]
    public DateTime? DateBegin { get; set; }

    [Column("date_end")]
    public DateTime? DateEnd { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("amount")]
    public decimal? Amount { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("RecurringPayments")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("RecurringPaymentCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("RecurringPayments")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("TemplateId")]
    //[InverseProperty("RecurringPayments")]
    [NotMapped]
    public virtual AccountRecurringTemplate? Template { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("RecurringPaymentWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("RecurringPayment")]
    [NotMapped]
    public virtual ICollection<RecurringPaymentLine> RecurringPaymentLines { get; } = new List<RecurringPaymentLine>();
}
