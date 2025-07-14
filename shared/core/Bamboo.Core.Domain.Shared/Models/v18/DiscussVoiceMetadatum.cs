using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;

[Table("discuss_voice_metadata")]
//[Index("AttachmentId", Name = "discuss_voice_metadata__attachment_id_index")]
public partial class DiscussVoiceMetadatum: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("attachment_id")]
    public Guid? AttachmentId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("AttachmentId")]
    //[InverseProperty("DiscussVoiceMetadata")]
    [NotMapped]
    public virtual IrAttachment? Attachment { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("DiscussVoiceMetadatumCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("DiscussVoiceMetadatumWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
