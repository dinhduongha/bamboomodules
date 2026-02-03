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
// 2. DmsRouteLine
[Table("dms_route_line")]
public partial class DmsRouteLine : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("route_id")]
    public Guid? RouteId { get; set; }

    [Column("stock_picking_id")]
    public Guid? StockPickingId { get; set; }

    [Column("sequence")]
    public int Sequence { get; set; }

    [Column("estimated_arrival_time")]
    public DateTimeOffset? EstimatedArrivalTime { get; set; }

    [Column("actual_arrival_time")]
    public DateTimeOffset? ActualArrivalTime { get; set; }

    [Column("h3_center")]
    public string? H3Center { get; set; }  // hex trung tâm của route

    [Column("geom_start")]
    public NetTopologySuite.Geometries.Point? GeomStartPoint { get; set; }

    [Column("geojson_start", TypeName = "jsonb")]
    public string? GeoJsonStartPoint { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("RouteId")]
    public virtual DmsRoute? Route { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("StockPickingId")]
    public virtual StockPicking? StockPicking { get; set; }
}
