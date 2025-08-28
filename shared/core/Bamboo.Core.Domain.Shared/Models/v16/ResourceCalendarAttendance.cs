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

[Table("resource_calendar_attendance")]
//[Index("Dayofweek", Name = "resource_calendar_attendance__dayofweek_index")]
//[Index("HourFrom", Name = "resource_calendar_attendance__hour_from_index")]
public partial class ResourceCalendarAttendance: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("calendar_id")]
    public Guid? CalendarId { get; set; }

    [Column("resource_id")]
    public Guid? ResourceId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("dayofweek")]
    public string? Dayofweek { get; set; }

    [Column("day_period")]
    public string? DayPeriod { get; set; }

    [Column("week_type")]
    public string? WeekType { get; set; }

    [Column("display_type")]
    public string? DisplayType { get; set; }

    [Column("date_from")]
    public DateTime? DateFrom { get; set; }

    [Column("date_to")]
    public DateTime? DateTo { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("hour_from")]
    public double? HourFrom { get; set; }

    [Column("hour_to")]
    public double? HourTo { get; set; }

    [Column("duration_days")]
    public double? DurationDays { get; set; }

    [Column("work_entry_type_id")]
    public Guid? WorkEntryTypeId { get; set; }

    // [Many2one]
    [ForeignKey("CalendarId")]
    public virtual ResourceCalendar? Calendar { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("ResourceId")]
    public virtual ResourceResource? Resource { get; set; }

    // [Many2one]
    [ForeignKey("WorkEntryTypeId")]
    public virtual HrWorkEntryType? WorkEntryType { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
