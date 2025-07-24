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
public partial class WebsitePage: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }
    
    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("view_id")]
    public Guid? ViewId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("theme_template_id")]
    public Guid? ThemeTemplateId { get; set; }

    [Column("url")]
    public string? Url { get; set; }

    [Column("header_color")]
    public string? HeaderColor { get; set; }

    [Column("header_text_color")]
    public string? HeaderTextColor { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    [Column("website_indexed")]
    public bool? WebsiteIndexed { get; set; }

    [Column("is_new_page_template")]
    public bool? IsNewPageTemplate { get; set; }

    [Column("header_overlay")]
    public bool? HeaderOverlay { get; set; }

    [Column("header_visible")]
    public bool? HeaderVisible { get; set; }

    [Column("footer_visible")]
    public bool? FooterVisible { get; set; }

    [Column("date_publish", TypeName = "timestamp without time zone")]
    public DateTime? DatePublish { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("WebsitePageCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ThemeTemplateId")]
    //[InverseProperty("WebsitePages")]
    [NotMapped]
    public virtual ThemeWebsitePage? ThemeTemplate { get; set; }

    [ForeignKey("ViewId")]
    //[InverseProperty("WebsitePages")]
    [NotMapped]
    public virtual IrUiView? View { get; set; }

    [ForeignKey("WebsiteId")]
    //[InverseProperty("WebsitePages")]
    [NotMapped]
    public virtual Website? Website { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("WebsitePageWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Page")]
    [NotMapped]
    public virtual ICollection<WebsiteMenu> WebsiteMenus { get; set; } = new List<WebsiteMenu>();

    //[InverseProperty("TargetModel")]
    [NotMapped]
    public virtual ICollection<WebsitePageProperty> WebsitePageProperties { get; set; } = new List<WebsitePageProperty>();

    //[InverseProperty("Page")]
    [NotMapped]
    public virtual ICollection<WebsiteTrack> WebsiteTracks { get; set; } = new List<WebsiteTrack>();

}
