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
    public string Type { get; set; } = "outlet";

    [Column("radius_meters")]
    public int? RadiusMeters { get; set; }

    [Column("polygon_geo_json")]
    public string? PolygonGeoJson { get; set; }

    [Column("center_latitude")]
    public decimal? CenterLatitude { get; set; }

    [Column("center_longitude")]
    public decimal? CenterLongitude { get; set; }

    [Column("is_active")]
    public bool IsActive { get; set; } = true;

    [Column("alert_on_enter")]
    public bool AlertOnEnter { get; set; } = true;

    [Column("alert_on_exit")]
    public bool AlertOnExit { get; set; } = true;

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }
}