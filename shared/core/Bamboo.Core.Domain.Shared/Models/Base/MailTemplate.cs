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
//[Index("Model", Name = "mail_template_model_index")]
public partial class MailTemplate: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("model_id")]
    public Guid? ModelId { get; set; }

    [Column("report_template")]
    public Guid? ReportTemplate { get; set; }

    [Column("mail_server_id")]
    public Guid? MailServerId { get; set; }

    [Column("ref_ir_act_window")]
    public Guid? RefIrActWindow { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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

    [Column("scheduled_date")]
    public string? ScheduledDate { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [Column("subject", TypeName = "jsonb")]
    public string? Subject { get; set; }

    [Column("body_html", TypeName = "jsonb")]
    public string? BodyHtml { get; set; }

    [Column("report_name", TypeName = "jsonb")]
    public string? ReportName { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("use_default_to")]
    public bool? UseDefaultTo { get; set; }

    [Column("auto_delete")]
    public bool? AutoDelete { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailTemplateCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MailServerId")]
    //[InverseProperty("MailTemplates")]
    [NotMapped]
    public virtual IrMailServer? MailServer { get; set; }

    [ForeignKey("ModelId")]
    //[InverseProperty("MailTemplates")]
    [NotMapped]
    public virtual IrModel? ModelNavigation { get; set; }

    [ForeignKey("RefIrActWindow")]
    //[InverseProperty("MailTemplates")]
    [NotMapped]
    public virtual IrActWindow? RefIrActWindowNavigation { get; set; }

    [ForeignKey("ReportTemplate")]
    //[InverseProperty("MailTemplates")]
    [NotMapped]
    public virtual IrActReportXml? ReportTemplateNavigation { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailTemplateWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Template")]
    [NotMapped]
    public virtual ICollection<AccountInvoiceSend> AccountInvoiceSends { get; } = new List<AccountInvoiceSend>();

    //[InverseProperty("Template")]
    [NotMapped]
    public virtual ICollection<ApplicantGetRefuseReason> ApplicantGetRefuseReasons { get; } = new List<ApplicantGetRefuseReason>();

    //[InverseProperty("Template")]
    [NotMapped]
    public virtual ICollection<ApplicantSendMail> ApplicantSendMails { get; } = new List<ApplicantSendMail>();

    //[InverseProperty("MailTemplate")]
    [NotMapped]
    public virtual ICollection<CalendarAlarm> CalendarAlarms { get; } = new List<CalendarAlarm>();

    //[InverseProperty("EmailTemplate")]
    [NotMapped]
    public virtual ICollection<FollowupLine> FollowupLines { get; } = new List<FollowupLine>();

    //[InverseProperty("Template")]
    [NotMapped]
    public virtual ICollection<HrApplicantRefuseReason> HrApplicantRefuseReasons { get; } = new List<HrApplicantRefuseReason>();

    //[InverseProperty("Template")]
    [NotMapped]
    public virtual ICollection<HrRecruitmentStage> HrRecruitmentStages { get; } = new List<HrRecruitmentStage>();

    //[InverseProperty("Template")]
    [NotMapped]
    public virtual ICollection<IrActServer> IrActServers { get; } = new List<IrActServer>();

    //[InverseProperty("Template")]
    [NotMapped]
    public virtual ICollection<MailComposeMessage> MailComposeMessages { get; } = new List<MailComposeMessage>();

    //[InverseProperty("MailTemplate")]
    [NotMapped]
    public virtual ICollection<MailTemplatePreview> MailTemplatePreviews { get; } = new List<MailTemplatePreview>();

    //[InverseProperty("MailTemplate")]
    [NotMapped]
    public virtual ICollection<ProjectProjectStage> ProjectProjectStages { get; } = new List<ProjectProjectStage>();

    //[InverseProperty("MailTemplate")]
    [NotMapped]
    public virtual ICollection<ProjectTaskType> ProjectTaskTypeMailTemplates { get; } = new List<ProjectTaskType>();

    //[InverseProperty("RatingTemplate")]
    [NotMapped]
    public virtual ICollection<ProjectTaskType> ProjectTaskTypeRatingTemplates { get; } = new List<ProjectTaskType>();

    //[InverseProperty("StockMailConfirmationTemplate")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanies { get; } = new List<ResCompany>();

    //[InverseProperty("InvoiceMailTemplate")]
    [NotMapped]
    public virtual ICollection<ResConfigSetting> ResConfigSettings { get; } = new List<ResConfigSetting>();

    //[InverseProperty("Template")]
    [NotMapped]
    public virtual ICollection<SaleOrderCancel> SaleOrderCancels { get; } = new List<SaleOrderCancel>();

    //[InverseProperty("MailTemplate")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplate> SaleOrderTemplates { get; } = new List<SaleOrderTemplate>();

    //[InverseProperty("CartRecoveryMailTemplate")]
    [NotMapped]
    public virtual ICollection<Website> Websites { get; } = new List<Website>();

    [ForeignKey("EmailTemplateId")]
    //[InverseProperty("EmailTemplates")]
    [NotMapped]
    public virtual ICollection<IrAttachment> Attachments { get; } = new List<IrAttachment>();

    [ForeignKey("MailTemplateId")]
    //[InverseProperty("MailTemplates")]
    [NotMapped]
    public virtual ICollection<MailActivityType> MailActivityTypes { get; } = new List<MailActivityType>();

    [ForeignKey("MailTemplateId")]
    //[InverseProperty("MailTemplates")]
    [NotMapped]
    public virtual ICollection<MailTemplateReset> MailTemplateResets { get; } = new List<MailTemplateReset>();
}
