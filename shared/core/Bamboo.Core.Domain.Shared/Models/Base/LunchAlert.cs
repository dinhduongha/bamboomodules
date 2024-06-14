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

[Table("lunch_alert")]
public partial class LunchAlert: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("cron_id")]
    public Guid? CronId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("mode")]
    public string? Mode { get; set; }

    [Column("recipients")]
    public string? Recipients { get; set; }

    [Column("notification_moment")]
    public string? NotificationMoment { get; set; }

    [Column("tz")]
    public string? Tz { get; set; }

    [Column("until")]
    public DateTime? Until { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("message", TypeName = "jsonb")]
    public string? Message { get; set; }

    [Column("mon")]
    public bool? Mon { get; set; }

    [Column("tue")]
    public bool? Tue { get; set; }

    [Column("wed")]
    public bool? Wed { get; set; }

    [Column("thu")]
    public bool? Thu { get; set; }

    [Column("fri")]
    public bool? Fri { get; set; }

    [Column("sat")]
    public bool? Sat { get; set; }

    [Column("sun")]
    public bool? Sun { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("notification_time")]
    public double? NotificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("LunchAlertCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CronId")]
    //[InverseProperty("LunchAlerts")]
    [NotMapped]
    public virtual IrCron? Cron { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("LunchAlertWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("LunchAlertId")]
    //[InverseProperty("LunchAlerts")]
    [NotMapped]
    public virtual ICollection<LunchLocation> LunchLocations { get; } = new List<LunchLocation>();
}
