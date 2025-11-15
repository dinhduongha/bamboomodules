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

[Table("mail_compose_message")]
public partial class MailComposeMessage : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("template_id")]
    public Guid? TemplateId { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("author_id")]
    public Guid? AuthorId { get; set; }

    [Column("res_domain_user_id")]
    public Guid? ResDomainUserId { get; set; }

    [Column("record_alias_domain_id")]
    public Guid? RecordAliasDomainId { get; set; }

    [Column("record_company_id")]
    public Guid? RecordCompanyId { get; set; }

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

    [Column("scheduled_date")]
    public string? ScheduledDate { get; set; }

    [Column("template_name")]
    public string? TemplateName { get; set; }

    [Column("body")]
    public string? Body { get; set; }

    [Column("res_ids")]
    public string? ResIds { get; set; }

    [Column("res_domain")]
    public string? ResDomain { get; set; }

    [Column("email_add_signature")]
    public bool? EmailAddSignature { get; set; }

    [Column("reply_to_force_new")]
    public bool? ReplyToForceNew { get; set; }

    [Column("auto_delete")]
    public bool? AutoDelete { get; set; }

    [Column("auto_delete_keep_log")]
    public bool? AutoDeleteKeepLog { get; set; }

    [Column("force_send")]
    public bool? ForceSend { get; set; }

    [Column("use_exclusion_list")]
    public bool? UseExclusionList { get; set; }

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

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AuthorId")]
    public virtual ResPartner? Author { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CampaignId")]
    public virtual UtmCampaign? Campaign { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("MailActivityTypeId")]
    public virtual MailActivityType? MailActivityType { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("MailServerId")]
    public virtual IrMailServer? MailServer { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("MassMailingId")]
    public virtual MailingMailing? MassMailing { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ParentId")]
    public virtual MailMessage? Parent { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("RecordAliasDomainId")]
    public virtual MailAliasDomain? RecordAliasDomain { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("RecordCompanyId")]
    public virtual ResCompany? RecordCompany { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ResDomainUserId")]
    public virtual ResUsers? ResDomainUser { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SubtypeId")]
    public virtual MailMessageSubtype? Subtype { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TemplateId")]
    public virtual MailTemplate? Template { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (IrAttachment) is commented out
    // [ForeignKey("WizardId")] // Many2many // Normal
    // [InverseProperty("WizardNavigation")] // Many2many // Normal
    public virtual ICollection<IrAttachment> Attachment { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("MailComposeMessageId")] // Many2many // Normal
    // [InverseProperty("MailComposeMessage")] // Many2many // Normal
    public virtual ICollection<MailingList> MailingList { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (ResPartner) is commented out
    // [ForeignKey("WizardId")] // Many2many // Normal
    // [InverseProperty("Wizard")] // Many2many // Normal
    public virtual ICollection<ResPartner> Partner { get; set; }
}
