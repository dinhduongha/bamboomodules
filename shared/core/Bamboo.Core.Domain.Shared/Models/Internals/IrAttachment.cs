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

[Table("ir_attachment")]
//[Index("StoreFname", Name = "ir_attachment__store_fname_index")]
//[Index("ResModel", "ResId", Name = "ir_attachment_res_idx")]
public partial class IrAttachment: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("res_id")]
    public Guid? ResId { get; set; }

    [Column("file_size")]
    public long? FileSize { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("res_model")]
    public string? ResModel { get; set; }

    [Column("res_field")]
    public string? ResField { get; set; }

    [Column("type")]
    public string? Type { get; set; }

    [Column("url")]
    public string? Url { get; set; }

    [Column("access_token")]
    public string? AccessToken { get; set; }

    [Column("store_fname")]
    public string? StoreFname { get; set; }

    [Column("checksum")]
    public string? Checksum { get; set; }

    [Column("mimetype")]
    public string? Mimetype { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("index_content")]
    public string? IndexContent { get; set; }

    [Column("public")]
    public bool? Public { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("db_datas")]
    public byte[]? DbDatas { get; set; }

    [Column("original_id")]
    public Guid? OriginalId { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("theme_template_id")]
    public Guid? ThemeTemplateId { get; set; }

    [Column("key")]
    public string? Key { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("AttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Attachment")] // One2many // Peer relationship (AccountEdiDocument) is commented out
    // public virtual ICollection<AccountEdiDocument> AccountEdiDocument { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (AccountMove) is commented out
    // public virtual ICollection<AccountMove> AccountMove { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (AccountPayment) is commented out
    // public virtual ICollection<AccountPayment> AccountPayment { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("AttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Attachment")] // One2many // Peer relationship (DiscussVoiceMetadata) is commented out
    // public virtual ICollection<DiscussVoiceMetadata> DiscussVoiceMetadata { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (HrApplicant) is commented out
    // public virtual ICollection<HrApplicant> HrApplicant { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (HrCandidate) is commented out
    // public virtual ICollection<HrCandidate> HrCandidate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (HrEmployee) is commented out
    // public virtual ICollection<HrEmployee> HrEmployee { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (HrExpense) is commented out
    // public virtual ICollection<HrExpense> HrExpense { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (HrExpenseSheet) is commented out
    // public virtual ICollection<HrExpenseSheet> HrExpenseSheet { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (HrLeave) is commented out
    // public virtual ICollection<HrLeave> HrLeave { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("IconId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Icon")] // One2many // Peer relationship (HrLeaveType) is commented out
    // public virtual ICollection<HrLeaveType> HrLeaveType { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("OriginalId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Original")] // One2many
    // public virtual ICollection<IrAttachment> InverseOriginal { get; set; }

    // [Many2one]
    [ForeignKey("OriginalId")]
    public virtual IrAttachment? Original { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("IrAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("IrAttachment")] // One2many // Peer relationship (ProductDocument) is commented out
    // public virtual ICollection<ProductDocument> ProductDocument { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("DisplayedImageId")]
    // [NotMapped] // One2many 
    // [InverseProperty("DisplayedImage")] // One2many // Peer relationship (ProjectTask) is commented out
    // public virtual ICollection<ProjectTask> ProjectTask { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("IrAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("IrAttachment")] // One2many // Peer relationship (QuotationDocument) is commented out
    // public virtual ICollection<QuotationDocument> QuotationDocument { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("AttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Attachment")] // One2many // Peer relationship (SnailmailLetter) is commented out
    // public virtual ICollection<SnailmailLetter> SnailmailLetter { get; set; }

    // [Many2one]
    [ForeignKey("ThemeTemplateId")]
    public virtual ThemeIrAttachment? ThemeTemplate { get; set; }

    // [Many2one]
    [ForeignKey("WebsiteId")]
    public virtual Website? Website { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("IrAttachmentId")] //Many2many // Hidden
    // [InverseProperty("IrAttachment")] //Many2many // Hidden
    public virtual ICollection<AccountBankStatement> AccountBankStatement { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AttachmentId")] //Many2many // Hidden
    // [InverseProperty("Attachment")] //Many2many // Hidden
    public virtual ICollection<MailActivity> Activity { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("IrAttachmentId")] //Many2many // Hidden
    // [InverseProperty("IrAttachment")] //Many2many // Hidden
    public virtual ICollection<ApplicantSendMail> ApplicantSendMail { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("IrAttachmentId")] //Many2many // Hidden
    // [InverseProperty("IrAttachment")] //Many2many // Hidden
    public virtual ICollection<CandidateSendMail> CandidateSendMail { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AttachmentId")] //Many2many // Hidden
    // [InverseProperty("Attachment")] //Many2many // Hidden
    public virtual ICollection<MailTemplate> EmailTemplate { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AttachmentId")] //Many2many // Hidden
    // [InverseProperty("Attachment")] //Many2many // Hidden
    public virtual ICollection<MailingMailing> MassMailing { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AttachmentId")] //Many2many // Hidden
    // [InverseProperty("Attachment")] //Many2many // Hidden
    public virtual ICollection<MailMessage> Message { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("IrAttachmentId")] //Many2many // Hidden
    // [InverseProperty("IrAttachment")] //Many2many // Hidden
    public virtual ICollection<PosConfig> PosConfig { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AttachmentId")] //Many2many // Hidden
    // [InverseProperty("Attachment")] //Many2many // Hidden
    public virtual ICollection<MailScheduledMessage> ScheduledMessage { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("IrAttachmentId")] //Many2many // Hidden
    // [InverseProperty("IrAttachment")] //Many2many // Hidden
    public virtual ICollection<SlideChannelInvite> SlideChannelInvite { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AttachmentId")] //Many2many // Hidden
    // [InverseProperty("Attachment")] //Many2many // Hidden
    public virtual ICollection<FleetVehicleSendMail> Wizard { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AttachmentId")] //Many2many // Hidden
    // [InverseProperty("Attachment")] //Many2many // Hidden
    public virtual ICollection<SurveyInvite> Wizard1 { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AttachmentId")] //Many2many // Hidden
    // [InverseProperty("Attachment")] //Many2many // Hidden
    public virtual ICollection<MailComposeMessage> WizardNavigation { get; set; }
}
