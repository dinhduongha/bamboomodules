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

[Table("calendar_recurrence")]
public partial class CalendarRecurrence: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("base_event_id")]
    public Guid? BaseEventId { get; set; }

    [Column("interval")]
    public long? Interval { get; set; }

    [Column("count")]
    public long? Count { get; set; }

    [Column("day")]
    public long? Day { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("event_tz")]
    public string? EventTz { get; set; }

    [Column("rrule")]
    public string? Rrule { get; set; }

    [Column("rrule_type")]
    public string? RruleType { get; set; }

    [Column("end_type")]
    public string? EndType { get; set; }

    [Column("month_by")]
    public string? MonthBy { get; set; }

    [Column("weekday")]
    public string? Weekday { get; set; }

    [Column("byday")]
    public string? Byday { get; set; }

    [Column("until")]
    public DateTime? Until { get; set; }

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

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("BaseEventId")]
    //[InverseProperty("CalendarRecurrences")]
    [NotMapped]
    public virtual CalendarEvent? BaseEvent { get; set; }

    //[InverseProperty("Recurrence")]
    [NotMapped]
    public virtual ICollection<CalendarEvent> CalendarEvents { get; } = new List<CalendarEvent>();

    [ForeignKey("CreatorId")]
    //[InverseProperty("CalendarRecurrenceCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("CalendarRecurrenceWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
