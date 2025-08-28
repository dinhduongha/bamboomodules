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

[Table("website_controller_page")]
//[Index("IsPublished", Name = "website_controller_page__is_published_index")]
//[Index("WebsiteId", Name = "website_controller_page__website_id_index")]
//[Index("NameSlugified", Name = "website_controller_page_unique_name_slugified", IsUnique = true)]
public partial class WebsiteControllerPage: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("record_view_id")]
    public Guid? RecordViewId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("name_slugified")]
    public string? NameSlugified { get; set; }

    [Column("record_domain")]
    public string? RecordDomain { get; set; }

    [Column("default_layout")]
    public string? DefaultLayout { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("RecordViewId")]
    public virtual IrUiView? RecordView { get; set; }

    // [Many2one]
    [ForeignKey("ViewId")]
    public virtual IrUiView? View { get; set; }

    // [Many2one]
    [ForeignKey("WebsiteId")]
    public virtual Website? Website { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ControllerPageId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ControllerPage")] // One2many
    public virtual ICollection<WebsiteMenu> WebsiteMenu { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
