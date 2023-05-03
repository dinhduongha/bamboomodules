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
public partial class MailComposeMessage: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("template_id")]
    public Guid? TemplateId { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("author_id")]
    public Guid? AuthorId { get; set; }

    [Column("res_id")]
    public Guid? ResId { get; set; }

    [Column("subtype_id")]
    public long? SubtypeId { get; set; }

    [Column("mail_activity_type_id")]
    public long? MailActivityTypeId { get; set; }

    [Column("mail_server_id")]
    public Guid? MailServerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("AuthorId")]
    //[InverseProperty("MailComposeMessages")]
    [NotMapped]
    public virtual ResPartner? Author { get; set; }

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
    public virtual ICollection<AccountInvoiceSend> AccountInvoiceSends { get; } = new List<AccountInvoiceSend>();

    [ForeignKey("WizardId")]
    //[InverseProperty("Wizards")]
    [NotMapped]
    public virtual ICollection<IrAttachment> Attachments { get; } = new List<IrAttachment>();

    [ForeignKey("WizardId")]
    //[InverseProperty("Wizards")]
    [NotMapped]
    public virtual ICollection<ResPartner> Partners { get; } = new List<ResPartner>();
}
