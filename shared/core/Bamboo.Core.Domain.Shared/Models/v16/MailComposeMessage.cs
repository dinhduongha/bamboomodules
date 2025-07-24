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
public partial class MailComposeMessage : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

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

    // v16-Compat
    [Column("res_id")]
    public Guid? ResId { get; set; }

    [Column("subtype_id")]
    public Guid? SubtypeId { get; set; }

    [Column("mail_activity_type_id")]
    public Guid? MailActivityTypeId { get; set; }

    [Column("mail_server_id")]
    public Guid? MailServerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

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

    // v16-Compat
    [Column("active_domain")]
    public string? ActiveDomain { get; set; }

    [Column("email_add_signature")]
    public bool? EmailAddSignature { get; set; }

    // v16-Compat
    [Column("use_active_domain")]
    public bool? UseActiveDomain { get; set; }

    // v16-Compat
    [Column("is_log")]
    public bool? IsLog { get; set; }

    // v16-Compat
    [Column("notify")]
    public bool? Notify { get; set; }

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

    // v16-Compat
    [Column("auto_delete_message")]
    public bool? AutoDeleteMessage { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("mass_mailing_id")]
    public Guid? MassMailingId { get; set; }

    [Column("campaign_id")]
    public Guid? CampaignId { get; set; }

    [Column("mass_mailing_name")]
    public string? MassMailingName { get; set; }

    [ForeignKey("AuthorId")]
    //[InverseProperty("MailComposeMessages")]
    [NotMapped]
    public virtual ResPartner? Author { get; set; }

    [ForeignKey("CampaignId")]
    //[InverseProperty("MailComposeMessages")]
    [NotMapped]
    public virtual UtmCampaign? Campaign { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailComposeMessageCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MailActivityTypeId")]
    //[InverseProperty("MailComposeMessages")]
    [NotMapped]
    public virtual MailActivityType? MailActivityType { get; set; }

    [ForeignKey("MailServerId")]
    //[InverseProperty("MailComposeMessages")]
    [NotMapped]
    public virtual IrMailServer? MailServer { get; set; }

    [ForeignKey("ParentId")]
    //[InverseProperty("MailComposeMessages")]
    [NotMapped]
    public virtual MailMessage? Parent { get; set; }

    [ForeignKey("SubtypeId")]
    //[InverseProperty("MailComposeMessages")]
    [NotMapped]
    public virtual MailMessageSubtype? Subtype { get; set; }

    [ForeignKey("TemplateId")]
    //[InverseProperty("MailComposeMessages")]
    [NotMapped]
    public virtual MailTemplate? Template { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailComposeMessageWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Composer")]
    [NotMapped]
    public virtual ICollection<AccountInvoiceSend> AccountInvoiceSends { get; set; } = new List<AccountInvoiceSend>();

    [ForeignKey("WizardId")]
    //[InverseProperty("Wizards")]
    [NotMapped]
    public virtual ICollection<IrAttachment> Attachments { get; set; } = new List<IrAttachment>();

    [ForeignKey("WizardId")]
    //[InverseProperty("Wizards")]
    [NotMapped]
    public virtual ICollection<ResPartner> Partners { get; set; } = new List<ResPartner>();
    
    [ForeignKey("MailComposeMessageId")]
    //[InverseProperty("MailComposeMessages")]
    [NotMapped]
    public virtual ICollection<MailingList> MailingLists { get; set; } = new List<MailingList>();

}
