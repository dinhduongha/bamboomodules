using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

[Table("website_track")]
//[Index("PageId", Name = "website_track__page_id_index")]
//[Index("Url", Name = "website_track__url_index")]
//[Index("VisitorId", Name = "website_track__visitor_id_index")]
public partial class WebsiteTrack : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("visitor_id")]
    public Guid? VisitorId { get; set; }

    [Column("page_id")]
    public Guid? PageId { get; set; }

    [Column("url")]
    public string? Url { get; set; }

    [Column("visit_datetime", TypeName = "timestamp without time zone")]
    public DateTime? VisitDatetime { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PageId")]
    public virtual WebsitePage? Page { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductId")]
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("VisitorId")]
    public virtual WebsiteVisitor? Visitor { get; set; }
}
