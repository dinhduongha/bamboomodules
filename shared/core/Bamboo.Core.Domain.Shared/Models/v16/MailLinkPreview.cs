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
//[Index("CreateDate", Name = "mail_link_preview__create_date_index")]
//[Index("MessageId", Name = "mail_link_preview__message_id_index")]
public partial class MailLinkPreview: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("message_id")]
    public Guid? MessageId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("source_url")]
    public string? SourceUrl { get; set; }

    [Column("og_type")]
    public string? OgType { get; set; }

    [Column("og_title")]
    public string? OgTitle { get; set; }

    [Column("og_site_name")]
    public string? OgSiteName { get; set; }

    [Column("og_image")]
    public string? OgImage { get; set; }

    [Column("og_mimetype")]
    public string? OgMimetype { get; set; }

    [Column("image_mimetype")]
    public string? ImageMimetype { get; set; }

    [Column("og_description")]
    public string? OgDescription { get; set; }

    [Column("is_hidden")]
    public bool? IsHidden { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("MessageId")]
    public virtual MailMessage? Message { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
