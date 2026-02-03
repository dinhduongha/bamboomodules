using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Table("dms_route_template_line")]
public partial class DmsRouteTemplateLine : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("team_id")]
    public Guid? TeamId { get; set; }

    [Column("template_id")]
    public Guid? TemplateId { get; set; }

    [Column("res_partner_id")]
    public Guid? ResPartnerId { get; set; }

    [Column("sequence")]
    public int Sequence { get; set; }

    [Column("estimated_time_minutes")]
    public int? EstimatedTimeMinutes { get; set; }

    [Column("estimated_distance_km")]
    public decimal? EstimatedDistanceKm { get; set; }

    [Column("h3_center")]
    public string? H3Center { get; set; }  // hex trung tâm của route

    [Column("geom_start")]
    public NetTopologySuite.Geometries.Point? GeomStartPoint { get; set; }

    [Column("geojson_start", TypeName = "jsonb")]
    public string? GeoJsonStartPoint { get; set; }

    // Navigation
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TemplateId")]
    public virtual DmsRouteTemplate Template { get; set; } = null!;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ResPartnerId")]
    public virtual ResPartner ResPartner { get; set; } = null!;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("OrganizationUnitId")]
    public virtual ResOrganization? Organization { get; set; }
}