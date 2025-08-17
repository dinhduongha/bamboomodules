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

[Table("ir_cron_trigger")]
//[Index("CronId", Name = "ir_cron_trigger__cron_id_index")]
public partial class IrCronTrigger: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("cron_id")]
    public Guid? CronId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("call_at", TypeName = "timestamp without time zone")]
    public DateTime? CallAt { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many]
    [ForeignKey("TriggerId")]
    [InverseProperty("Trigger")]
    public virtual ICollection<CalendarRecurrence> CalendarRecurrence { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("IrCronTriggerCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CronId")]
    // [InverseProperty("IrCronTrigger")] //Many2one
    public virtual IrCron? Cron { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("IrCronTriggerWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
