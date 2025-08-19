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
//[Index("ParentId", Name = "website_menu__parent_id_index")]
//[Index("ParentPath", Name = "website_menu__parent_path_index")]
public partial class WebsiteMenu: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("page_id")]
    public Guid? PageId { get; set; }

    [Column("controller_page_id")]
    public Guid? ControllerPageId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("theme_template_id")]
    public Guid? ThemeTemplateId { get; set; }

    [Column("url")]
    public string? Url { get; set; }

    [Column("parent_path")]
    public string? ParentPath { get; set; }

    [Column("mega_menu_classes")]
    public string? MegaMenuClasses { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [JsonField]
    [Column("mega_menu_content", TypeName = "jsonb")]
    public string? MegaMenuContent { get; set; }

    [Column("new_window")]
    public bool? NewWindow { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("ControllerPageId")]
    // [InverseProperty("WebsiteMenu")] //Many2one
    public virtual WebsiteControllerPage? ControllerPage { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("WebsiteMenuCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("MenuId")]
    [InverseProperty("Menu")]
    public virtual ICollection<EventEvent> EventEvent { get; set; }

    // [One2many]
    [ForeignKey("MenuId")]
    [InverseProperty("Menu")]
    public virtual ICollection<ForumForum> ForumForum { get; set; }

    // [One2many]
    [ForeignKey("ParentId")]
    [InverseProperty("Parent")]
    public virtual ICollection<WebsiteMenu> InverseParent { get; set; }

    // [Many2one]
    [ForeignKey("PageId")]
    // [InverseProperty("WebsiteMenu")] //Many2one
    public virtual WebsitePage? Page { get; set; }

    // [Many2one]
    [ForeignKey("ParentId")]
    // [InverseProperty("InverseParent")] //Many2one
    public virtual WebsiteMenu? Parent { get; set; }

    // [Many2one]
    [ForeignKey("ThemeTemplateId")]
    // [InverseProperty("WebsiteMenu")] //Many2one
    public virtual ThemeWebsiteMenu? ThemeTemplate { get; set; }

    // [Many2one]
    [ForeignKey("WebsiteId")]
    // [InverseProperty("WebsiteMenu")] //Many2one
    public virtual Website? Website { get; set; }

    // [One2many]
    [ForeignKey("MenuId")]
    [InverseProperty("Menu")]
    public virtual ICollection<WebsiteEventMenu> WebsiteEventMenu { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("WebsiteMenuWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("WebsiteMenuId")] //Many2many
    // [InverseProperty("WebsiteMenu")] //Many2many
    public virtual ICollection<ResGroups> ResGroups { get; set; }
}
