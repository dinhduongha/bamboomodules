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

[Table("mailing_subscription")]
//[Index("ContactId", "ListId", Name = "mailing_subscription_unique_contact_list", IsUnique = true)]
public partial class MailingSubscription: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("contact_id")]
    public Guid? ContactId { get; set; }

    [Column("list_id")]
    public Guid? ListId { get; set; }

    [Column("opt_out_reason_id")]
    public Guid? OptOutReasonId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("opt_out")]
    public bool? OptOut { get; set; }

    [Column("opt_out_datetime", TypeName = "timestamp without time zone")]
    public DateTime? OptOutDatetime { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("ContactId")]
    //[InverseProperty("MailingSubscriptions")]
    [NotMapped]
    public virtual MailingContact? Contact { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailingSubscriptionCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ListId")]
    //[InverseProperty("MailingSubscriptions")]
    [NotMapped]
    public virtual MailingList? List { get; set; }

    [ForeignKey("OptOutReasonId")]
    //[InverseProperty("MailingSubscriptions")]
    [NotMapped]
    public virtual MailingSubscriptionOptout? OptOutReason { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailingSubscriptionWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
