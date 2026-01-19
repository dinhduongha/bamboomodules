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
// 7. DmsDailyCheckpoint
[Table("dms_daily_checkpoint")]
public partial class DmsDailyCheckpoint : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("date")]
    public DateTime Date { get; set; }

    [Column("checkpoint_type")]
    public string CheckpointType { get; set; } = "start_at_warehouse";

    [Column("check_in_time")]
    public DateTime? CheckInTime { get; set; }

    [Column("geo_latitude")]
    public decimal? GeoLatitude { get; set; }

    [Column("geo_longitude")]
    public decimal? GeoLongitude { get; set; }

    [Column("status")]
    public string Status { get; set; } = "pending";

    [Column("notes")]
    public string? Notes { get; set; }

    [Column("photos_json")]
    public string? PhotosJson { get; set; }

    [Column("provision_picking_id")]
    public Guid? ProvisionPickingId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProvisionPickingId")]
    public virtual StockPicking? ProvisionPicking { get; set; }
}




