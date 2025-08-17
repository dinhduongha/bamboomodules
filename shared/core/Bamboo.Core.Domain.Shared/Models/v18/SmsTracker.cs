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

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("mail_notification_id")]
    public Guid? MailNotificationId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("sms_uuid")]
    public string? SmsUuid { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("mailing_trace_id")]
    public Guid? MailingTraceId { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("SmsTrackerCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("MailNotificationId")]
    // [InverseProperty("SmsTracker")] //Many2one
    public virtual MailNotification? MailNotification { get; set; }

    // [Many2one]
    [ForeignKey("MailingTraceId")]
    // [InverseProperty("SmsTracker")] //Many2one
    public virtual MailingTrace? MailingTrace { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("SmsTrackerWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
