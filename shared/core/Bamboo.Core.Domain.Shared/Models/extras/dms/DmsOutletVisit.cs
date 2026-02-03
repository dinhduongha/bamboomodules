
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
// 4. DmsOutletVisit
[Table("dms_outlet_visit")]
public partial class DmsOutletVisit : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("partner_id")]
    public Guid PartnerId { get; set; }

    [Column("visit_date_time")]
    public DateTimeOffset? VisitDateTime { get; set; }

    [Column("visit_status")]
    public string? VisitStatus { get; set; } = "pending";

    [Column("check_in_h3")]
    public string? CheckInH3 { get; set; }

    [Column("check_in_latitude")]
    public decimal? CheckInLatitude { get; set; }

    [Column("check_in_longitude")]
    public decimal? CheckInLongitude { get; set; }

    [Column("check_in_accuracy")]
    public decimal? CheckInAccuracy { get; set; }

    [Column("geo_status")]
    public string? GeoStatus { get; set; } = "inside";

    [Column("duration_minutes")]
    public long? DurationMinutes { get; set; }

    [Column("geom_check_in")]
    public NetTopologySuite.Geometries.Point? GeomCheckInPoint { get; set; }

    [Column("geom_check_out")]
    public NetTopologySuite.Geometries.Point? GeomCheckOutPoint { get; set; }

    [Column("check_out_latitude")]
    public decimal? CheckOutLatitude { get; set; }

    [Column("check_out_longitude")]
    public decimal? CheckOutLongitude { get; set; }

    [Column("photos", TypeName = "jsonb")]
    public Dictionary<string, object>? Photos { get; set; }

    [Column("order_created")]
    public bool? OrderCreated { get; set; }

    [Column("no_sale_reason_id")]
    public Guid? NoSaleReasonId { get; set; }

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
    [NotMapped]
    public virtual ResUsers? CreateU { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]

    [NotMapped]
    public virtual ResUsers? WriteU { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? ResPartner { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("OrganizationUnitId")]
    public virtual ResOrganization? Organization { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TeamId")]
    public virtual ResTeam? Team { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

}
