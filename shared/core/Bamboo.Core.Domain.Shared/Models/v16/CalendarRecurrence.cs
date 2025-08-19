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
//[Index("MicrosoftId", Name = "calendar_recurrence__microsoft_id_index")]
//[Index("MsUniversalEventId", Name = "calendar_recurrence__ms_universal_event_id_index")]
public partial class CalendarRecurrence: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("base_event_id")]
    public Guid? BaseEventId { get; set; }

    [Column("interval")]
    public long? Interval { get; set; }

    [Column("count")]
    public long? Count { get; set; }

    [Column("day")]
    public long? Day { get; set; }

    [Column("trigger_id")]
    public Guid? TriggerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("google_id")]
    public string? GoogleId { get; set; }

    [Column("need_sync")]
    public bool? NeedSync { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("microsoft_id")]
    public string? MicrosoftId { get; set; }

    [Column("ms_universal_event_id")]
    public string? MsUniversalEventId { get; set; }

    [Column("need_sync_m")]
    public bool? NeedSyncM { get; set; }

    // [Many2one]
    [ForeignKey("BaseEventId")]
    // [InverseProperty("CalendarRecurrence")] //Many2one
    public virtual CalendarEvent? BaseEvent { get; set; }

    // [One2many]
    [ForeignKey("RecurrenceId")]
    [InverseProperty("Recurrence")]
    public virtual ICollection<CalendarEvent> CalendarEvent { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("CalendarRecurrenceCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("TriggerId")]
    // [InverseProperty("CalendarRecurrence")] //Many2one
    public virtual IrCronTrigger? Trigger { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("CalendarRecurrenceWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
