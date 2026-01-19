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
    public string ZoneName { get; set; } = null!;

    [Column("priority")]
    public int Priority { get; set; }

    [Column("polygon_geo_json")]
    public string? PolygonGeoJson { get; set; }
}
