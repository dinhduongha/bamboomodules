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

[Table("mail_compose_message")]
public partial class MailComposeMessage: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("template_id")]
    public Guid? TemplateId { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("author_id")]
    public Guid? AuthorId { get; set; }

    [Column("res_id")]
    public Guid? ResId { get; set; }

    [Column("subtype_id")]
    public Guid? SubtypeId { get; set; }

    [Column("mail_activity_type_id")]
    public Guid? MailActivityTypeId { get; set; }

    [Column("mail_server_id")]
    public Guid? MailServerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("lang")]
    public string? Lang { get; set; }

    [Column("subject")]
    public string? Subject { get; set; }

    [Column("email_layout_xmlid")]
    public string? EmailLayoutXmlid { get; set; }

    [Column("email_from")]
    public string? EmailFrom { get; set; }

    [Column("composition_mode")]
    public string? CompositionMode { get; set; }

    [Column("model")]
    public string? Model { get; set; }

    [Column("record_name")]
    public string? RecordName { get; set; }

    [Column("message_type")]
    public string? MessageType { get; set; }

    [Column("reply_to")]
    public string? ReplyTo { get; set; }

    [Column("body")]
    public string? Body { get; set; }

    [Column("active_domain")]
    public string? ActiveDomain { get; set; }

    [Column("email_add_signature")]
    public bool? EmailAddSignature { get; set; }

    [Column("use_active_domain")]
    public bool? UseActiveDomain { get; set; }

    [Column("is_log")]
    public bool? IsLog { get; set; }

    [Column("notify")]
    public bool? Notify { get; set; }

    [Column("reply_to_force_new")]
    public bool? ReplyToForceNew { get; set; }

    [Column("auto_delete")]
    public bool? AutoDelete { get; set; }

    [Column("auto_delete_message")]
    public bool? AutoDeleteMessage { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("mass_mailing_id")]
    public Guid? MassMailingId { get; set; }

    [Column("campaign_id")]
    public Guid? CampaignId { get; set; }

    [Column("mass_mailing_name")]
    public string? MassMailingName { get; set; }

    // [One2many]
    [ForeignKey("ComposerId")]
    [InverseProperty("Composer")]
    public virtual ICollection<AccountInvoiceSend> AccountInvoiceSend { get; set; }

    // [Many2one]
    [ForeignKey("AuthorId")]
    // [InverseProperty("MailComposeMessage")] //Many2one
    public virtual ResPartner? Author { get; set; }

    // [Many2one]
    [ForeignKey("CampaignId")]
    // [InverseProperty("MailComposeMessage")] //Many2one
    public virtual UtmCampaign? Campaign { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("MailComposeMessageCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("MailActivityTypeId")]
    // [InverseProperty("MailComposeMessage")] //Many2one
    public virtual MailActivityType? MailActivityType { get; set; }

    // [Many2one]
    [ForeignKey("MailServerId")]
    // [InverseProperty("MailComposeMessage")] //Many2one
    public virtual IrMailServer? MailServer { get; set; }

    // [Many2one]
    [ForeignKey("MassMailingId")]
    // [InverseProperty("MailComposeMessage")] //Many2one
    public virtual MailingMailing? MassMailing { get; set; }

    // [Many2one]
    [ForeignKey("ParentId")]
    // [InverseProperty("MailComposeMessage")] //Many2one
    public virtual MailMessage? Parent { get; set; }

    // [Many2one]
    [ForeignKey("SubtypeId")]
    // [InverseProperty("MailComposeMessage")] //Many2one
    public virtual MailMessageSubtype? Subtype { get; set; }

    // [Many2one]
    [ForeignKey("TemplateId")]
    // [InverseProperty("MailComposeMessage")] //Many2one
    public virtual MailTemplate? Template { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("MailComposeMessageWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("WizardId")] //Many2many
    // [InverseProperty("Wizard")] //Many2many
    public virtual ICollection<IrAttachment> Attachment { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("MailComposeMessageId")] //Many2many
    // [InverseProperty("MailComposeMessage")] //Many2many
    public virtual ICollection<MailingList> MailingList { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("WizardId")] //Many2many
    // [InverseProperty("Wizard")] //Many2many
    public virtual ICollection<ResPartner> Partner { get; set; }
}
