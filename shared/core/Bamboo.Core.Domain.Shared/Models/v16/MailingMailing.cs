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
//[Index("CampaignId", Name = "mailing_mailing__campaign_id_index")]
public partial class MailingMailing: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    // v16-Compat
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("source_id")]
    public Guid? SourceId { get; set; }

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
    public Guid? CreatorId { get; set; }

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

    [Column("ab_testing_enabled")]
    public bool? AbTestingEnabled { get; set; }

    [Column("ab_testing_completed")]
    public bool? AbTestingCompleted { get; set; }

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
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("card_campaign_id")]
    public Guid? CardCampaignId { get; set; }

    [Column("sms_template_id")]
    public Guid? SmsTemplateId { get; set; }

    [Column("body_plaintext")]
    public string? BodyPlaintext { get; set; }

    [Column("sms_force_send")]
    public bool? SmsForceSend { get; set; }

    [Column("sms_allow_unsubscribe")]
    public bool? SmsAllowUnsubscribe { get; set; }

    [ForeignKey("CampaignId")]
    //[InverseProperty("MailingMailings")]
    [NotMapped]
    public virtual UtmCampaign? Campaign { get; set; }

    [ForeignKey("CardCampaignId")]
    //[InverseProperty("MailingMailings")]
    [NotMapped]
    public virtual CardCampaign? CardCampaign { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailingMailingCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    // v16-Compat
    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("...")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    //[InverseProperty("MassMailing")]
    [NotMapped]
    public virtual ICollection<LinkTrackerClick> LinkTrackerClicks { get; set; } 

    //[InverseProperty("MassMailing")]
    [NotMapped]
    public virtual ICollection<LinkTracker> LinkTrackers { get; set; } 

    //[InverseProperty("MassMailing")]
    [NotMapped]
    public virtual ICollection<MailComposeMessage> MailComposeMessages { get; set; } 

    //[InverseProperty("Mailing")]
    [NotMapped]
    public virtual ICollection<MailMail> MailMails { get; set; } 

    [ForeignKey("MailServerId")]
    //[InverseProperty("MailingMailings")]
    [NotMapped]
    public virtual IrMailServer? MailServer { get; set; }

    [ForeignKey("MailingFilterId")]
    //[InverseProperty("MailingMailings")]
    [NotMapped]
    public virtual MailingFilter? MailingFilter { get; set; }

    //[InverseProperty("MassMailing")]
    [NotMapped]
    public virtual ICollection<MailingMailingScheduleDate> MailingMailingScheduleDates { get; set; } 

    //[InverseProperty("MassMailing")]
    [NotMapped]
    public virtual ICollection<MailingMailingTest> MailingMailingTests { get; set; } 

    [ForeignKey("MailingModelId")]
    //[InverseProperty("MailingMailings")]
    [NotMapped]
    public virtual IrModel? MailingModel { get; set; }

    //[InverseProperty("Mailing")]
    [NotMapped]
    public virtual ICollection<MailingSmsTest> MailingSmsTests { get; set; } 

    //[InverseProperty("MassMailing")]
    [NotMapped]
    public virtual ICollection<MailingTrace> MailingTraces { get; set; } 

    [ForeignKey("MediumId")]
    //[InverseProperty("MailingMailings")]
    [NotMapped]
    public virtual UtmMedium? Medium { get; set; }

    //[InverseProperty("Mailing")]
    [NotMapped]
    public virtual ICollection<SmsComposer> SmsComposers { get; set; } 

    //[InverseProperty("Mailing")]
    [NotMapped]
    public virtual ICollection<SmsSms> SmsSms { get; set; } 

    [ForeignKey("SmsTemplateId")]
    //[InverseProperty("MailingMailings")]
    [NotMapped]
    public virtual SmsTemplate? SmsTemplate { get; set; }

    [ForeignKey("SourceId")]
    //[InverseProperty("MailingMailings")]
    [NotMapped]
    public virtual UtmSource? Source { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("MailingMailingUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    //[InverseProperty("AbTestingWinnerMailing")]
    [NotMapped]
    public virtual ICollection<UtmCampaign> UtmCampaigns { get; set; } 

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailingMailingWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("MassMailingId")]
    //[InverseProperty("MassMailings")]
    [NotMapped]
    public virtual ICollection<IrAttachment> Attachments { get; set; } 

    [ForeignKey("MailingMailingId")]
    //[InverseProperty("MailingMailings")]
    [NotMapped]
    public virtual ICollection<MailingList> MailingLists { get; set; } 
}
