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

[Table("mailing_mailing")]
//[Index("CampaignId", Name = "mailing_mailing_campaign_id_index")]
public partial class MailingMailing: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("source_id")]
    public Guid? SourceId { get; set; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("campaign_id")]
    public Guid? CampaignId { get; set; }

    [Column("medium_id")]
    public Guid? MediumId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("mailing_model_id")]
    public Guid? MailingModelId { get; set; }

    [Column("mail_server_id")]
    public Guid? MailServerId { get; set; }

    [Column("mailing_filter_id")]
    public Guid? MailingFilterId { get; set; }

    [Column("ab_testing_pc")]
    public long? AbTestingPc { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("lang")]
    public string? Lang { get; set; }

    [Column("subject")]
    public string? Subject { get; set; }

    [Column("preview")]
    public string? Preview { get; set; }

    [Column("email_from")]
    public string? EmailFrom { get; set; }

    [Column("schedule_type")]
    public string? ScheduleType { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("mailing_type")]
    public string? MailingType { get; set; }

    [Column("reply_to_mode")]
    public string? ReplyToMode { get; set; }

    [Column("reply_to")]
    public string? ReplyTo { get; set; }

    [Column("mailing_domain")]
    public string? MailingDomain { get; set; }

    [Column("body_arch")]
    public string? BodyArch { get; set; }

    [Column("body_html")]
    public string? BodyHtml { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("favorite")]
    public bool? Favorite { get; set; }

    [Column("keep_archives")]
    public bool? KeepArchives { get; set; }

    [Column("ab_testing_completed")]
    public bool? AbTestingCompleted { get; set; }

    [Column("ab_testing_enabled")]
    public bool? AbTestingEnabled { get; set; }

    [Column("kpi_mail_required")]
    public bool? KpiMailRequired { get; set; }

    [Column("favorite_date", TypeName = "timestamp without time zone")]
    public DateTime? FavoriteDate { get; set; }

    [Column("sent_date", TypeName = "timestamp without time zone")]
    public DateTime? SentDate { get; set; }

    [Column("schedule_date", TypeName = "timestamp without time zone")]
    public DateTime? ScheduleDate { get; set; }

    [Column("calendar_date", TypeName = "timestamp without time zone")]
    public DateTime? CalendarDate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("sms_template_id")]
    public Guid? SmsTemplateId { get; set; }

    [Column("body_plaintext")]
    public string? BodyPlaintext { get; set; }

    [Column("sms_force_send")]
    public bool? SmsForceSend { get; set; }

    [Column("sms_allow_unsubscribe")]
    public bool? SmsAllowUnsubscribe { get; set; }

    // [Many2one]
    [ForeignKey("CampaignId")]
    // [InverseProperty("MailingMailing")] //Many2one
    public virtual UtmCampaign? Campaign { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("MailingMailingCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("MassMailingId")]
    [InverseProperty("MassMailing")]
    public virtual ICollection<LinkTracker> LinkTracker { get; set; }

    // [One2many]
    [ForeignKey("MassMailingId")]
    [InverseProperty("MassMailing")]
    public virtual ICollection<LinkTrackerClick> LinkTrackerClick { get; set; }

    // [One2many]
    [ForeignKey("MassMailingId")]
    [InverseProperty("MassMailing")]
    public virtual ICollection<MailComposeMessage> MailComposeMessage { get; set; }

    // [One2many]
    [ForeignKey("MailingId")]
    [InverseProperty("Mailing")]
    public virtual ICollection<MailMail> MailMail { get; set; }

    // [Many2one]
    [ForeignKey("MailServerId")]
    // [InverseProperty("MailingMailing")] //Many2one
    public virtual IrMailServer? MailServer { get; set; }

    // [Many2one]
    [ForeignKey("MailingFilterId")]
    // [InverseProperty("MailingMailing")] //Many2one
    public virtual MailingFilter? MailingFilter { get; set; }

    // [One2many]
    [ForeignKey("MassMailingId")]
    [InverseProperty("MassMailing")]
    public virtual ICollection<MailingMailingScheduleDate> MailingMailingScheduleDate { get; set; }

    // [One2many]
    [ForeignKey("MassMailingId")]
    [InverseProperty("MassMailing")]
    public virtual ICollection<MailingMailingTest> MailingMailingTest { get; set; }

    // [Many2one]
    [ForeignKey("MailingModelId")]
    // [InverseProperty("MailingMailing")] //Many2one
    public virtual IrModel? MailingModel { get; set; }

    // [One2many]
    [ForeignKey("MailingId")]
    [InverseProperty("Mailing")]
    public virtual ICollection<MailingSmsTest> MailingSmsTest { get; set; }

    // [One2many]
    [ForeignKey("MassMailingId")]
    [InverseProperty("MassMailing")]
    public virtual ICollection<MailingTrace> MailingTrace { get; set; }

    // [Many2one]
    [ForeignKey("MediumId")]
    // [InverseProperty("MailingMailing")] //Many2one
    public virtual UtmMedium? Medium { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MailingMailing")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [One2many]
    [ForeignKey("MailingId")]
    [InverseProperty("Mailing")]
    public virtual ICollection<SmsComposer> SmsComposer { get; set; }

    // [One2many]
    [ForeignKey("MailingId")]
    [InverseProperty("Mailing")]
    public virtual ICollection<SmsSms> SmsSms { get; set; }

    // [Many2one]
    [ForeignKey("SmsTemplateId")]
    // [InverseProperty("MailingMailing")] //Many2one
    public virtual SmsTemplate? SmsTemplate { get; set; }

    // [Many2one]
    [ForeignKey("SourceId")]
    // [InverseProperty("MailingMailing")] //Many2one
    public virtual UtmSource? Source { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("MailingMailingUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("MailingMailingWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("MassMailingId")] //Many2many
    // [InverseProperty("MassMailing")] //Many2many
    public virtual ICollection<IrAttachment> Attachment { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("MailingMailingId")]
    // [InverseProperty("MailingMailing")]
    // public virtual ICollection<MailingList> MailingList { get; set; }
}
