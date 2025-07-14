using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;

[Table("data_recycle_model")]
public partial class DataRecycleModel: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("res_model_id")]
    public Guid? ResModelId { get; set; }

    [Column("time_field_id")]
    public Guid? TimeFieldId { get; set; }

    [Column("time_field_delta")]
    public long? TimeFieldDelta { get; set; }

    [Column("notify_frequency")]
    public long? NotifyFrequency { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("DataRecycleModelCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("RecycleModel")]
    [NotMapped]
    public virtual ICollection<DataRecycleRecord> DataRecycleRecords { get; set; } = new List<DataRecycleRecord>();

    [ForeignKey("ResModelId")]
    //[InverseProperty("DataRecycleModels")]
    [NotMapped]
    public virtual IrModel? ResModel { get; set; }

    [ForeignKey("TimeFieldId")]
    //[InverseProperty("DataRecycleModels")]
    [NotMapped]
    public virtual IrModelField? TimeField { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("DataRecycleModelWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("DataRecycleModelId")]
    //[InverseProperty("DataRecycleModels")]
    [NotMapped]
    public virtual ICollection<ResUser> ResUsers { get; set; } = new List<ResUser>();
}
