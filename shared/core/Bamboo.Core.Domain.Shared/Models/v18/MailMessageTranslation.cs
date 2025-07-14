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

[Table("mail_message_translation")]
//[Index("CreateDate", Name = "mail_message_translation__create_date_index")]
//[Index("MessageId", "TargetLang", Name = "mail_message_translation_unique", IsUnique = true)]
public partial class MailMessageTranslation: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("message_id")]
    public Guid? MessageId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("source_lang")]
    public string? SourceLang { get; set; }

    [Column("target_lang")]
    public string? TargetLang { get; set; }

    [Column("body")]
    public string? Body { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailMessageTranslationCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MessageId")]
    //[InverseProperty("MailMessageTranslations")]
    [NotMapped]
    public virtual MailMessage? Message { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailMessageTranslationWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
