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

    [Column("numbercall")]
    public long? Numbercall { get; set; }

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

    // v16-Compat - Removed
    //[JsonField]
    //[Column("cron_name", TypeName = "jsonb")]
    //public string? CronName { get; set; }

    [Column("interval_type")]
    public string? IntervalType { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("doall")]
    public bool? Doall { get; set; }

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
    [ForeignKey("CreatorId")]
    // [InverseProperty("IrCronCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("IrActionsServerId")]
    // [InverseProperty("IrCron")] //Many2one
    public virtual IrActServer? IrActionsServer { get; set; }

    // [One2many]
    [ForeignKey("CronId")]
    [InverseProperty("Cron")]
    public virtual ICollection<IrCronProgress> IrCronProgress { get; set; }

    // [One2many]
    [ForeignKey("CronId")]
    [InverseProperty("Cron")]
    public virtual ICollection<IrCronTrigger> IrCronTrigger { get; set; }

    // [One2many]
    [ForeignKey("CronId")]
    [InverseProperty("Cron")]
    public virtual ICollection<LunchAlert> LunchAlert { get; set; }

    // [One2many]
    [ForeignKey("CronId")]
    [InverseProperty("Cron")]
    public virtual ICollection<LunchSupplier> LunchSupplier { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("IrCronUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("IrCronWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
