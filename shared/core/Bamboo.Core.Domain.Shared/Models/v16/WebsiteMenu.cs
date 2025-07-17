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

[Table("website_menu")]
//[Index("ParentId", Name = "website_menu_parent_id_index")]
//[Index("ParentPath", Name = "website_menu_parent_path_index")]
public partial class WebsiteMenu: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("page_id")]
    public Guid? PageId { get; set; }

    [Column("controller_page_id")]
    public Guid? ControllerPageId { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("theme_template_id")]
    public Guid? ThemeTemplateId { get; set; }

    [Column("url")]
    public string? Url { get; set; }

    [Column("parent_path")]
    public string? ParentPath { get; set; }

    [Column("mega_menu_classes")]
    public string? MegaMenuClasses { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("mega_menu_content", TypeName = "jsonb")]
    public string? MegaMenuContent { get; set; }

    [Column("new_window")]
    public bool? NewWindow { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("ControllerPageId")]
    //[InverseProperty("WebsiteMenus")]
    [NotMapped]
    public virtual WebsiteControllerPage? ControllerPage { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("WebsiteMenuCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("PageId")]
    //[InverseProperty("WebsiteMenus")]
    [NotMapped]
    public virtual WebsitePage? Page { get; set; }

    [ForeignKey("ParentId")]
    //[InverseProperty("InverseParent")]
    [NotMapped]
    public virtual WebsiteMenu? Parent { get; set; }

    [ForeignKey("ThemeTemplateId")]
    //[InverseProperty("WebsiteMenus")]
    [NotMapped]
    public virtual ThemeWebsiteMenu? ThemeTemplate { get; set; }

    [ForeignKey("WebsiteId")]
    //[InverseProperty("WebsiteMenus")]
    [NotMapped]
    public virtual Website? Website { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("WebsiteMenuWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<WebsiteMenu> InverseParent { get; set; } = new List<WebsiteMenu>();

}
