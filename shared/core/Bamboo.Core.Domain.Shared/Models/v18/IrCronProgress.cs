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

[Table("ir_cron_progress")]
//[Index("CronId", Name = "ir_cron_progress__cron_id_index")]
public partial class IrCronProgress: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("cron_id")]
    public Guid? CronId { get; set; }

    [Column("remaining")]
    public long? Remaining { get; set; }

    [Column("done")]
    public long? Done { get; set; }

    [Column("timed_out_counter")]
    public long? TimedOutCounter { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("deactivate")]
    public bool? Deactivate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("IrCronProgressCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CronId")]
    //[InverseProperty("IrCronProgresses")]
    [NotMapped]
    public virtual IrCron? Cron { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("IrCronProgressWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
