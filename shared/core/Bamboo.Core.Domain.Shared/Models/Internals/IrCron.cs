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
public partial class IrCron: FullAuditedEntity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("ir_actions_server_id")]
    public Guid? IrActionsServerId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("interval_number")]
    public long? IntervalNumber { get; set; }

    // v16-Compat
    [Column("numbercall")]
    public long? Numbercall { get; set; }

    [Column("priority")]
    public long? Priority { get; set; }

    [Column("failure_count")]
    public long? FailureCount { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    // v16-Compat json=>character varying
    [Column("cron_name")]
    public string? CronName { get; set; }

    [Column("interval_type")]
    public string? IntervalType { get; set; }

    // v16-Compat
    // [Column("cron_name", TypeName = "jsonb")]
    // public string? CronName { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    // v16-Compat
    [Column("doall")]
    public bool? Doall { get; set; }

    [Column("nextcall", TypeName = "timestamp without time zone")]
    public DateTime? Nextcall { get; set; }

    [Column("lastcall", TypeName = "timestamp without time zone")]
    public DateTime? Lastcall { get; set; }

    [Column("first_failure_date", TypeName = "timestamp without time zone")]
    public DateTime? FirstFailureDate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("IrCronCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("IrActionsServerId")]
    //[InverseProperty("IrCrons")]
    [NotMapped]
    public virtual IrActServer? IrActionsServer { get; set; }

    //[InverseProperty("Cron")]
    [NotMapped]
    public virtual ICollection<IrCronProgress> IrCronProgresses { get; set; } = new List<IrCronProgress>();

    //[InverseProperty("Cron")]
    [NotMapped]
    public virtual ICollection<IrCronTrigger> IrCronTriggers { get; set; } = new List<IrCronTrigger>();

    //[InverseProperty("Cron")]
    [NotMapped]
    public virtual ICollection<LunchAlert> LunchAlerts { get; set; } = new List<LunchAlert>();

    //[InverseProperty("Cron")]
    [NotMapped]
    public virtual ICollection<LunchSupplier> LunchSuppliers { get; set; } = new List<LunchSupplier>();

    [ForeignKey("UserId")]
    //[InverseProperty("IrCronUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("IrCronWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
