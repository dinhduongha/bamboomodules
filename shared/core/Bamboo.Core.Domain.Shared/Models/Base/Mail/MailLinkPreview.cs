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

[Table("mail_link_preview")]
//[Index("CreationTime", Name = "mail_link_preview_create_date_index")]
//[Index("MessageId", Name = "mail_link_preview_message_id_index")]
public partial class MailLinkPreview: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("message_id")]
    public Guid? MessageId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("source_url")]
    public string? SourceUrl { get; set; }

    [Column("og_type")]
    public string? OgType { get; set; }

    [Column("og_title")]
    public string? OgTitle { get; set; }

    [Column("og_image")]
    public string? OgImage { get; set; }

    [Column("og_mimetype")]
    public string? OgMimetype { get; set; }

    [Column("image_mimetype")]
    public string? ImageMimetype { get; set; }

    [Column("og_description")]
    public string? OgDescription { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailLinkPreviewCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MessageId")]
    //[InverseProperty("MailLinkPreviews")]
    [NotMapped]
    public virtual MailMessage? Message { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailLinkPreviewWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
