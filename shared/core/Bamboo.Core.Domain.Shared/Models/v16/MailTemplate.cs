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

[Table("mail_template")]
//[Index("Model", Name = "mail_template__model_index")]
public partial class MailTemplate: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("model_id")]
    public Guid? ModelId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("mail_server_id")]
    public Guid? MailServerId { get; set; }

    [Column("ref_ir_act_window")]
    public Guid? RefIrActWindow { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("template_fs")]
    public string? TemplateFs { get; set; }

    [Column("lang")]
    public string? Lang { get; set; }

    [Column("model")]
    public string? Model { get; set; }

    [Column("email_from")]
    public string? EmailFrom { get; set; }

    [Column("email_to")]
    public string? EmailTo { get; set; }

    [Column("partner_to")]
    public string? PartnerTo { get; set; }

    [Column("email_cc")]
    public string? EmailCc { get; set; }

    [Column("reply_to")]
    public string? ReplyTo { get; set; }

    [Column("email_layout_xmlid")]
    public string? EmailLayoutXmlid { get; set; }

    [Column("scheduled_date")]
    public string? ScheduledDate { get; set; }

    [JsonField(IsSparse = false)] // Name
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [JsonField(IsSparse = false)] // Description
    [Column("description", TypeName = "jsonb")]
    public StringDictionary? Description { get; set; }

    [JsonField] // Subject
    [Column("subject", TypeName = "jsonb")]
    public JsonElement? Subject { get; set; }

    [JsonField] // BodyHtml
    [Column("body_html", TypeName = "jsonb")]
    public JsonElement? BodyHtml { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("use_default_to")]
    public bool? UseDefaultTo { get; set; }

    [Column("auto_delete")]
    public bool? AutoDelete { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MailTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailTemplate")] // One2many
    public virtual ICollection<AccountMoveSendWizard> AccountMoveSendWizard { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Template")] // One2many
    public virtual ICollection<ApplicantGetRefuseReason> ApplicantGetRefuseReason { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Template")] // One2many
    public virtual ICollection<ApplicantSendMail> ApplicantSendMail { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MailTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailTemplate")] // One2many
    public virtual ICollection<CalendarAlarm> CalendarAlarm { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Template")] // One2many
    public virtual ICollection<CandidateSendMail> CandidateSendMail { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MailTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailTemplate")] // One2many
    public virtual ICollection<EventTrackStage> EventTrackStage { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Template")] // One2many
    public virtual ICollection<FleetVehicleSendMail> FleetVehicleSendMail { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EmailTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("EmailTemplate")] // One2many
    public virtual ICollection<FollowupLine> FollowupLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ReportTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ReportTemplate")] // One2many
    public virtual ICollection<GamificationChallenge> GamificationChallenge { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Template")] // One2many
    public virtual ICollection<HrApplicantRefuseReason> HrApplicantRefuseReason { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Template")] // One2many
    public virtual ICollection<HrRecruitmentStage> HrRecruitmentStage { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Template")] // One2many
    public virtual ICollection<IrActServer> IrActServer { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MailTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailTemplate")] // One2many
    public virtual ICollection<LoyaltyMail> LoyaltyMail { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Template")] // One2many
    public virtual ICollection<MailComposeMessage> MailComposeMessage { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("MailServerId")]
    public virtual IrMailServer? MailServer { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MailTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailTemplate")] // One2many
    public virtual ICollection<MailTemplatePreview> MailTemplatePreview { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ModelId")]
    public virtual IrModel? ModelNavigation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EmailTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("EmailTemplate")] // One2many
    public virtual ICollection<ProductTemplate> ProductTemplate { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MailTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailTemplate")] // One2many
    public virtual ICollection<ProjectProjectStage> ProjectProjectStage { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MailTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailTemplate")] // One2many
    public virtual ICollection<ProjectTaskType> ProjectTaskTypeMailTemplate { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("RatingTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("RatingTemplate")] // One2many
    public virtual ICollection<ProjectTaskType> ProjectTaskTypeRatingTemplate { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("RefIrActWindow")]
    public virtual IrActWindow? RefIrActWindowNavigation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("StockMailConfirmationTemplateId")]
    [NotMapped] // One2many // Peer relationship (ResCompany) is commented out
    // [InverseProperty("StockMailConfirmationTemplate")] // One2many
    public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("InvoiceMailTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("InvoiceMailTemplate")] // One2many
    public virtual ICollection<ResConfigSettings> ResConfigSettings { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PendingEmailTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PendingEmailTemplate")] // One2many
    public virtual ICollection<SaleOrder> SaleOrder { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Template")] // One2many
    public virtual ICollection<SaleOrderCancel> SaleOrderCancel { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MailTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailTemplate")] // One2many
    public virtual ICollection<SaleOrderTemplate> SaleOrderTemplate { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CompletedTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("CompletedTemplate")] // One2many
    public virtual ICollection<SlideChannel> SlideChannelCompletedTemplate { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Template")] // One2many
    public virtual ICollection<SlideChannelInvite> SlideChannelInvite { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PublishTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PublishTemplate")] // One2many
    public virtual ICollection<SlideChannel> SlideChannelPublishTemplate { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ShareChannelTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ShareChannelTemplate")] // One2many
    public virtual ICollection<SlideChannel> SlideChannelShareChannelTemplate { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ShareSlideTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ShareSlideTemplate")] // One2many
    public virtual ICollection<SlideChannel> SlideChannelShareSlideTemplate { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Template")] // One2many
    public virtual ICollection<SurveyInvite> SurveyInvite { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CertificationMailTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("CertificationMailTemplate")] // One2many
    public virtual ICollection<SurveySurvey> SurveySurvey { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CartRecoveryMailTemplateId")]
    [NotMapped] // One2many // Peer relationship (Website) is commented out
    // [InverseProperty("CartRecoveryMailTemplate")] // One2many
    public virtual ICollection<Website> Website { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (IrAttachment) is commented out
    // [ForeignKey("EmailTemplateId")] // Many2many // Normal
    // [InverseProperty("EmailTemplate")] // Many2many // Normal
    public virtual ICollection<IrAttachment> Attachment { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("MailTemplateId")] // Many2many // Normal
    // [InverseProperty("MailTemplate")] // Many2many // Normal
    public virtual ICollection<IrActReportXml> IrActionsReport { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("MailTemplateId")] //Many2many // Hidden
    // [InverseProperty("MailTemplate")] //Many2many // Hidden
    public virtual ICollection<MailActivityType> MailActivityType { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("MailTemplateId")] //Many2many // Hidden
    // [InverseProperty("MailTemplate")] //Many2many // Hidden
    public virtual ICollection<MailTemplateReset> MailTemplateReset { get; set; }
}
