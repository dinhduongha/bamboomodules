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

[Table("website_page")]
//[Index("IsPublished", Name = "website_page_is_published_index")]
//[Index("WebsiteId", Name = "website_page_website_id_index")]
public partial class WebsitePage: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("view_id")]
    public Guid? ViewId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("theme_template_id")]
    public Guid? ThemeTemplateId { get; set; }

    [Column("url")]
    public string? Url { get; set; }

    [Column("header_color")]
    public string? HeaderColor { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    [Column("website_indexed")]
    public bool? WebsiteIndexed { get; set; }

    [Column("header_overlay")]
    public bool? HeaderOverlay { get; set; }

    [Column("header_visible")]
    public bool? HeaderVisible { get; set; }

    [Column("footer_visible")]
    public bool? FooterVisible { get; set; }

    [Column("date_publish", TypeName = "timestamp without time zone")]
    public DateTime? DatePublish { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("WebsitePageCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("ThemeTemplateId")]
    // [InverseProperty("WebsitePage")] //Many2one
    public virtual ThemeWebsitePage? ThemeTemplate { get; set; }

    // [Many2one]
    [ForeignKey("ViewId")]
    // [InverseProperty("WebsitePage")] //Many2one
    public virtual IrUiView? View { get; set; }

    // [Many2one]
    [ForeignKey("WebsiteId")]
    // [InverseProperty("WebsitePage")] //Many2one
    public virtual Website? Website { get; set; }

    // [One2many]
    [ForeignKey("PageId")]
    [InverseProperty("Page")]
    public virtual ICollection<WebsiteMenu> WebsiteMenu { get; set; }

    // [One2many]
    [ForeignKey("PageId")]
    [InverseProperty("Page")]
    public virtual ICollection<WebsiteTrack> WebsiteTrack { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("WebsitePageWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
