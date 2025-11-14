using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

[Table("data_recycle_model")]
public partial class DataRecycleModel: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("res_model_id")]
    public Guid? ResModelId { get; set; }

    [Column("time_field_id")]
    public Guid? TimeFieldId { get; set; }

    [Column("time_field_delta")]
    public long? TimeFieldDelta { get; set; }

    [Column("notify_frequency")]
    public long? NotifyFrequency { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("res_model_name")]
    public string? ResModelName { get; set; }

    [Column("recycle_mode")]
    public string? RecycleMode { get; set; }

    [Column("recycle_action")]
    public string? RecycleAction { get; set; }

    [Column("domain")]
    public string? Domain { get; set; }

    [Column("time_field_delta_unit")]
    public string? TimeFieldDeltaUnit { get; set; }

    [Column("notify_frequency_period")]
    public string? NotifyFrequencyPeriod { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("include_archived")]
    public bool? IncludeArchived { get; set; }

    [Column("last_notification", TypeName = "timestamp without time zone")]
    public DateTime? LastNotification { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("RecycleModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("RecycleModel")] // One2many
    public virtual ICollection<DataRecycleRecord> DataRecycleRecord { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ResModelId")]
    public virtual IrModel? ResModel { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TimeFieldId")]
    public virtual IrModelFields? TimeField { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (ResUsers) is commented out
    // [ForeignKey("DataRecycleModelId")] // Many2many // Normal
    // [InverseProperty("DataRecycleModel")] // Many2many // Normal
    public virtual ICollection<ResUsers> ResUsers { get; set; }
}
