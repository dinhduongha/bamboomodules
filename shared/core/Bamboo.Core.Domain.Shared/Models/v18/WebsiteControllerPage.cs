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
public partial class WebsiteControllerPage: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("record_view_id")]
    public Guid? RecordViewId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("WebsiteControllerPageCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("RecordViewId")]
    //[InverseProperty("WebsiteControllerPageRecordViews")]
    [NotMapped]
    public virtual IrUiView? RecordView { get; set; }

    [ForeignKey("ViewId")]
    //[InverseProperty("WebsiteControllerPageViews")]
    [NotMapped]
    public virtual IrUiView? View { get; set; }

    [ForeignKey("WebsiteId")]
    //[InverseProperty("WebsiteControllerPages")]
    [NotMapped]
    public virtual Website? Website { get; set; }

    //[InverseProperty("ControllerPage")]
    [NotMapped]
    public virtual ICollection<WebsiteMenu> WebsiteMenus { get; set; } = new List<WebsiteMenu>();

    [ForeignKey("LastModifierId")]
    //[InverseProperty("WebsiteControllerPageWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
