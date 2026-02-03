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
// 3. DmsDeliveryZone
[Table("dms_delivery_zone")]
public partial class DmsDeliveryZone : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("zone_code")]
    public string ZoneCode { get; set; } = null!;

    [Column("zone_name")]
    public string? ZoneName { get; set; } = null;

    [Column("priority")]
    public int Priority { get; set; }

    [Column("h3_indexes")]
    public string[]? H3Indexes { get; set; }  // mảng h3index bao phủ polygon (level 7-9)

    [Column("geojson_center", TypeName = "jsonb")]
    public string? GeoJsonCenter { get; set; }

    [Column("geojson_polygon", TypeName = "jsonb")]
    public string? GeoJsonPolygon { get; set; }

    [Column("geom_center")]
    public NetTopologySuite.Geometries.Point? GeomCenter { get; set; }  // tâm vùng (tính từ polygon)

    [Column("geom_polygon")]
    public NetTopologySuite.Geometries.Polygon? GeomPolygon { get; set; }  // geography(POLYGON, 4326)

    // Navigation nếu cần (ví dụ: danh sách outlet trong zone)
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public virtual ICollection<ResPartner> OutletsInZone { get; set; } = new List<ResPartner>();

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("OrganizationUnitId")]
    public virtual ResOrganization? Organization { get; set; }

}
