using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

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
    [ForeignKey("CreatorId")]
    // [InverseProperty("DataRecycleModelCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("RecycleModelId")]
    [InverseProperty("RecycleModel")]
    public virtual ICollection<DataRecycleRecord> DataRecycleRecord { get; set; }

    // [Many2one]
    [ForeignKey("ResModelId")]
    // [InverseProperty("DataRecycleModel")] //Many2one
    public virtual IrModel? ResModel { get; set; }

    // [Many2one]
    [ForeignKey("TimeFieldId")]
    // [InverseProperty("DataRecycleModel")] //Many2one
    public virtual IrModelFields? TimeField { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("DataRecycleModelWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("DataRecycleModelId")] //Many2many
    // [InverseProperty("DataRecycleModel")] //Many2many
    public virtual ICollection<ResUsers> ResUsers { get; set; }
}
