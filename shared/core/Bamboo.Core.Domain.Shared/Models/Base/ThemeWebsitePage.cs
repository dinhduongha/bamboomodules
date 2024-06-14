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

[Table("theme_website_page")]
public partial class ThemeWebsitePage: Entity<long>, IEntityDto<long>
{
    [Key]
    [Column("id")]
    public long Id { get => base.Id; set => base.Id = value; }

    [Column("view_id")]
    public long? ViewId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("url")]
    public string? Url { get; set; }

    [Column("header_color")]
    public string? HeaderColor { get; set; }

    [Column("website_indexed")]
    public bool? WebsiteIndexed { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    [Column("header_overlay")]
    public bool? HeaderOverlay { get; set; }

    [Column("header_visible")]
    public bool? HeaderVisible { get; set; }

    [Column("footer_visible")]
    public bool? FooterVisible { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ThemeWebsitePageCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ViewId")]
    //[InverseProperty("ThemeWebsitePages")]
    [NotMapped]
    public virtual ThemeIrUiView? View { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ThemeWebsitePageWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Page")]
    [NotMapped]
    public virtual ICollection<ThemeWebsiteMenu> ThemeWebsiteMenus { get; } = new List<ThemeWebsiteMenu>();

    //[InverseProperty("ThemeTemplate")]
    [NotMapped]
    public virtual ICollection<WebsitePage> WebsitePages { get; } = new List<WebsitePage>();

}
