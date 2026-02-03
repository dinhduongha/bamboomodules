using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

public partial class ResPartner
{
    [Column("shop_code")]
    public string? ShopCode { get; set; } // unique per tenant

    [Column("shop_type")]
    public string? ShopType { get; set; } = "tap_hoa"; // enum string: "tap_hoa", "minimart", "sieu_thi_nho", ...

    [Column("channel_type")]
    public string? ChannelType { get; set; } = "gt"; // "gt", "mt"

    [Column("visit_frequency_days")]
    public int? VisitFrequencyDays { get; set; } = 7;

    [Column("last_visit_date")]
    public DateTimeOffset? LastVisitDate { get; set; }

    [Column("delivery_zone_id")]
    public Guid? DeliveryZoneId { get; set; }

    [Column("last_no_sale_date")]
    public DateTimeOffset? LastNoSaleDate { get; set; }

    [Column("is_key_account")]
    public bool? IsKeyAccount { get; set; } = false;

    [Column("expiry_date_tracking")]
    public bool? ExpiryDateTracking { get; set; } = false;

    [Column("last_posm_check_date")]
    public DateTimeOffset? LastPOSMCheckDate { get; set; }

    [Column("geofence_radius_meters")]
    public long? GeofenceRadiusMeters { get; set; }

    [Column("h3_index")]
    public string? H3Index { get; set; }  // h3index level 10: 70-80m

    [Column("geofence_id")]
    public Guid? GeofenceId { get; set; }

    [Column("geo_latitude")]
    public decimal? GeoLatitude { get; set; }

    [Column("geo_longitude")]
    public decimal? GeoLongitude { get; set; }

    [Column("geom_point")]
    public NetTopologySuite.Geometries.Point? GeomPoint { get; set; }  // geography(POINT, 4326)

    [Column("geom_polygon")]
    public NetTopologySuite.Geometries.Polygon? GeomPolygon { get; set; }  // geography(POLYGON, 4326)

    [Column("geojson_point", TypeName = "jsonb")]
    public string? GeoJsonPoint { get; set; }  // thay cho lat/lng

    [Column("geojson_polygon", TypeName = "jsonb")]
    public string? GeoJsonPolygon { get; set; }

    [Column("no_sale_reasons", TypeName = "jsonb")]
    public Dictionary<string, object>? NoSaleReasons { get; set; }

    [Column("last_inventory_qty", TypeName = "jsonb")]
    public Dictionary<string, object>? LastInventoryQty { get; set; }

    [Column("posm_photos", TypeName = "jsonb")]
    public Dictionary<string, object>? POSMPhotos { get; set; }

    // Navigation properties mới
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("DeliveryZoneId")]
    public virtual DmsDeliveryZone? DeliveryZone { get; set; }
}