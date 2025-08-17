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

[Table("website_snippet_filter")]
//[Index("IsPublished", Name = "website_snippet_filter_is_published_index")]
//[Index("WebsiteId", Name = "website_snippet_filter_website_id_index")]
public partial class WebsiteSnippetFilter: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("action_server_id")]
    public Guid? ActionServerId { get; set; }

    [Column("filter_id")]
    public Guid? FilterId { get; set; }

    [Column("limit")]
    public long? Limit { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("field_names")]
    public string? FieldNames { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("product_cross_selling")]
    public bool? ProductCrossSelling { get; set; }

    // [Many2one]
    [ForeignKey("ActionServerId")]
    // [InverseProperty("WebsiteSnippetFilter")] //Many2one
    public virtual IrActServer? ActionServer { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("WebsiteSnippetFilterCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("FilterId")]
    // [InverseProperty("WebsiteSnippetFilter")] //Many2one
    public virtual IrFilters? Filter { get; set; }

    // [Many2one]
    [ForeignKey("WebsiteId")]
    // [InverseProperty("WebsiteSnippetFilter")] //Many2one
    public virtual Website? Website { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("WebsiteSnippetFilterWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
