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

[Table("dms_geofence")]
public partial class DmsGeofence : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("type")]
    public string? Type { get; set; } = "outlet";

    [Column("is_active")]
    public bool IsActive { get; set; } = true;

    [Column("alert_on_enter")]
    public bool AlertOnEnter { get; set; } = true;

    [Column("alert_on_exit")]
    public bool AlertOnExit { get; set; } = true;

    [Column("radius_meters")]
    public long? RadiusMeters { get; set; }

    [Column("h3_indexes")]
    public string[]? H3Indexes { get; set; }  // mảng h3index bao phủ polygon (level 7-9)

    [Column("center_latitude")]
    public decimal? CenterLatitude { get; set; }

    [Column("center_longitude")]
    public decimal? CenterLongitude { get; set; }

    [Column("geom_center")]
    public NetTopologySuite.Geometries.Point? GeomCenterPoint { get; set; }

    [Column("geom_polygon")]
    public NetTopologySuite.Geometries.Polygon? GeomPolygon { get; set; }  // geography(POLYGON, 4326)

    // Nếu dùng topology (tùy chọn)
    [Column("geom_topo")]
    public NetTopologySuite.Geometries.Geometry? GeomTopo { get; set; }  // chỉ nếu dùng topology

    [Column("_geojson_polygon", TypeName = "jsonb")]
    public string? GeoJsonPolygon { get; set; }

    [Column("_geojson_tôp", TypeName = "jsonb")]
    public string? GeoJsonTopo { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("OrganizationUnitId")]
    public virtual ResOrganization? Organization { get; set; }
}