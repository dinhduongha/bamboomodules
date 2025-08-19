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

[Table("website_track")]
//[Index("PageId", Name = "website_track__page_id_index")]
//[Index("Url", Name = "website_track__url_index")]
//[Index("VisitorId", Name = "website_track__visitor_id_index")]
public partial class WebsiteTrack: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

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
    [ForeignKey("PageId")]
    // [InverseProperty("WebsiteTrack")] //Many2one
    public virtual WebsitePage? Page { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("WebsiteTrack")] //Many2one
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [ForeignKey("VisitorId")]
    // [InverseProperty("WebsiteTrack")] //Many2one
    public virtual WebsiteVisitor? Visitor { get; set; }
}
