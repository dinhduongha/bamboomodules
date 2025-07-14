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

[Table("sms_tracker")]
//[Index("SmsUuid", Name = "sms_tracker_sms_uuid_unique", IsUnique = true)]
public partial class SmsTracker: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("mail_notification_id")]
    public Guid? MailNotificationId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("sms_uuid")]
    public string? SmsUuid { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("mailing_trace_id")]
    public Guid? MailingTraceId { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SmsTrackerCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MailNotificationId")]
    //[InverseProperty("SmsTrackers")]
    [NotMapped]
    public virtual MailNotification? MailNotification { get; set; }

    [ForeignKey("MailingTraceId")]
    //[InverseProperty("SmsTrackers")]
    [NotMapped]
    public virtual MailingTrace? MailingTrace { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SmsTrackerWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
