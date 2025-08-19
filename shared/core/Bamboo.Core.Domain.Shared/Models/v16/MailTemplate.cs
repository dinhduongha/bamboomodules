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

    [Column("report_template")]
    public Guid? ReportTemplate { get; set; }

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

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [JsonField]
    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [JsonField]
    [Column("subject", TypeName = "jsonb")]
    public string? Subject { get; set; }

    [JsonField]
    [Column("body_html", TypeName = "jsonb")]
    public string? BodyHtml { get; set; }

    [JsonField]
    [Column("report_name", TypeName = "jsonb")]
    public string? ReportName { get; set; }

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
    [ForeignKey("TemplateId")]
    [InverseProperty("Template")]
    public virtual ICollection<AccountInvoiceSend> AccountInvoiceSend { get; set; }

    // [One2many]
    [ForeignKey("MailTemplateId")]
    [InverseProperty("MailTemplate")]
    public virtual ICollection<AccountMoveSendWizard> AccountMoveSendWizard { get; set; }

    // [One2many]
    [ForeignKey("TemplateId")]
    [InverseProperty("Template")]
    public virtual ICollection<ApplicantGetRefuseReason> ApplicantGetRefuseReason { get; set; }

    // [One2many]
    [ForeignKey("TemplateId")]
    [InverseProperty("Template")]
    public virtual ICollection<ApplicantSendMail> ApplicantSendMail { get; set; }

    // [One2many]
    [ForeignKey("MailTemplateId")]
    [InverseProperty("MailTemplate")]
    public virtual ICollection<CalendarAlarm> CalendarAlarm { get; set; }

    // [One2many]
    [ForeignKey("TemplateId")]
    [InverseProperty("Template")]
    public virtual ICollection<CandidateSendMail> CandidateSendMail { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("MailTemplateCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("MailTemplateId")]
    [InverseProperty("MailTemplate")]
    public virtual ICollection<EventTrackStage> EventTrackStage { get; set; }

    // [One2many]
    [ForeignKey("TemplateId")]
    [InverseProperty("Template")]
    public virtual ICollection<FleetVehicleSendMail> FleetVehicleSendMail { get; set; }

    // [One2many]
    [ForeignKey("EmailTemplateId")]
    [InverseProperty("EmailTemplate")]
    public virtual ICollection<FollowupLine> FollowupLine { get; set; }

    // [One2many]
    [ForeignKey("ReportTemplateId")]
    [InverseProperty("ReportTemplate")]
    public virtual ICollection<GamificationChallenge> GamificationChallenge { get; set; }

    // [One2many]
    [ForeignKey("TemplateId")]
    [InverseProperty("Template")]
    public virtual ICollection<HrApplicantRefuseReason> HrApplicantRefuseReason { get; set; }

    // [One2many]
    [ForeignKey("TemplateId")]
    [InverseProperty("Template")]
    public virtual ICollection<HrRecruitmentStage> HrRecruitmentStage { get; set; }

    // [One2many]
    [ForeignKey("TemplateId")]
    [InverseProperty("Template")]
    public virtual ICollection<IrActServer> IrActServer { get; set; }

    // [One2many]
    [ForeignKey("MailTemplateId")]
    [InverseProperty("MailTemplate")]
    public virtual ICollection<LoyaltyMail> LoyaltyMail { get; set; }

    // [One2many]
    [ForeignKey("TemplateId")]
    [InverseProperty("Template")]
    public virtual ICollection<MailComposeMessage> MailComposeMessage { get; set; }

    // [Many2one]
    [ForeignKey("MailServerId")]
    // [InverseProperty("MailTemplate")] //Many2one
    public virtual IrMailServer? MailServer { get; set; }

    // [One2many]
    [ForeignKey("MailTemplateId")]
    [InverseProperty("MailTemplate")]
    public virtual ICollection<MailTemplatePreview> MailTemplatePreview { get; set; }

    // [Many2one]
    [ForeignKey("ModelId")]
    // [InverseProperty("MailTemplate")] //Many2one
    public virtual IrModel? ModelNavigation { get; set; }

    // [One2many]
    [ForeignKey("EmailTemplateId")]
    [InverseProperty("EmailTemplate")]
    public virtual ICollection<ProductTemplate> ProductTemplate { get; set; }

    // [One2many]
    [ForeignKey("MailTemplateId")]
    [InverseProperty("MailTemplate")]
    public virtual ICollection<ProjectProjectStage> ProjectProjectStage { get; set; }

    // [One2many]
    [ForeignKey("MailTemplateId")]
    [InverseProperty("MailTemplate")]
    public virtual ICollection<ProjectTaskType> ProjectTaskTypeMailTemplate { get; set; }

    // [One2many]
    [ForeignKey("RatingTemplateId")]
    [InverseProperty("RatingTemplate")]
    public virtual ICollection<ProjectTaskType> ProjectTaskTypeRatingTemplate { get; set; }

    // [Many2one]
    [ForeignKey("RefIrActWindow")]
    // [InverseProperty("MailTemplate")] //Many2one
    public virtual IrActWindow? RefIrActWindowNavigation { get; set; }

    // [Many2one]
    [ForeignKey("ReportTemplate")]
    // [InverseProperty("MailTemplate")] //Many2one
    public virtual IrActReportXml? ReportTemplateNavigation { get; set; }

    // [One2many]
    [ForeignKey("StockMailConfirmationTemplateId")]
    [InverseProperty("StockMailConfirmationTemplate")]
    public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [One2many]
    [ForeignKey("InvoiceMailTemplateId")]
    [InverseProperty("InvoiceMailTemplate")]
    public virtual ICollection<ResConfigSettings> ResConfigSettings { get; set; }

    // [One2many]
    [ForeignKey("PendingEmailTemplateId")]
    [InverseProperty("PendingEmailTemplate")]
    public virtual ICollection<SaleOrder> SaleOrder { get; set; }

    // [One2many]
    [ForeignKey("TemplateId")]
    [InverseProperty("Template")]
    public virtual ICollection<SaleOrderCancel> SaleOrderCancel { get; set; }

    // [One2many]
    [ForeignKey("MailTemplateId")]
    [InverseProperty("MailTemplate")]
    public virtual ICollection<SaleOrderTemplate> SaleOrderTemplate { get; set; }

    // [One2many]
    [ForeignKey("CompletedTemplateId")]
    [InverseProperty("CompletedTemplate")]
    public virtual ICollection<SlideChannel> SlideChannelCompletedTemplate { get; set; }

    // [One2many]
    [ForeignKey("TemplateId")]
    [InverseProperty("Template")]
    public virtual ICollection<SlideChannelInvite> SlideChannelInvite { get; set; }

    // [One2many]
    [ForeignKey("PublishTemplateId")]
    [InverseProperty("PublishTemplate")]
    public virtual ICollection<SlideChannel> SlideChannelPublishTemplate { get; set; }

    // [One2many]
    [ForeignKey("ShareChannelTemplateId")]
    [InverseProperty("ShareChannelTemplate")]
    public virtual ICollection<SlideChannel> SlideChannelShareChannelTemplate { get; set; }

    // [One2many]
    [ForeignKey("ShareSlideTemplateId")]
    [InverseProperty("ShareSlideTemplate")]
    public virtual ICollection<SlideChannel> SlideChannelShareSlideTemplate { get; set; }

    // [One2many]
    [ForeignKey("TemplateId")]
    [InverseProperty("Template")]
    public virtual ICollection<SurveyInvite> SurveyInvite { get; set; }

    // [One2many]
    [ForeignKey("CertificationMailTemplateId")]
    [InverseProperty("CertificationMailTemplate")]
    public virtual ICollection<SurveySurvey> SurveySurvey { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("MailTemplateUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [One2many]
    [ForeignKey("CartRecoveryMailTemplateId")]
    [InverseProperty("CartRecoveryMailTemplate")]
    public virtual ICollection<Website> Website { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("MailTemplateWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("EmailTemplateId")] //Many2many
    // [InverseProperty("EmailTemplate")] //Many2many
    public virtual ICollection<IrAttachment> Attachment { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("MailTemplateId")] //Many2many
    // [InverseProperty("MailTemplate")] //Many2many
    public virtual ICollection<IrActReportXml> IrActionsReport { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("MailTemplateId")]
    // [InverseProperty("MailTemplate")]
    public virtual ICollection<MailActivityType> MailActivityType { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("MailTemplateId")]
    // [InverseProperty("MailTemplate")]
    public virtual ICollection<MailTemplateReset> MailTemplateReset { get; set; }
}
