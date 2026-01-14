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

[Table("ir_cron")]
public partial class IrCron: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("ir_actions_server_id")]
    public Guid? IrActionsServerId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("interval_number")]
    public long? IntervalNumber { get; set; }

    [Column("priority")]
    public long? Priority { get; set; }

    [Column("failure_count")]
    public long? FailureCount { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("cron_name")]
    public string? CronName { get; set; }

    [Column("interval_type")]
    public string? IntervalType { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("nextcall", TypeName = "timestamp without time zone")]
    public DateTime? Nextcall { get; set; }

    [Column("lastcall", TypeName = "timestamp without time zone")]
    public DateTime? Lastcall { get; set; }

    [Column("first_failure_date", TypeName = "timestamp without time zone")]
    public DateTime? FirstFailureDate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("IrActionsServerId")]
    public virtual IrActServer? IrActionsServer { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CronId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Cron")] // One2many
    public virtual ICollection<IrCronProgress> IrCronProgress { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CronId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Cron")] // One2many
    public virtual ICollection<IrCronTrigger> IrCronTrigger { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CronId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Cron")] // One2many
    public virtual ICollection<LunchAlert> LunchAlert { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CronId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Cron")] // One2many
    public virtual ICollection<LunchSupplier> LunchSupplier { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
