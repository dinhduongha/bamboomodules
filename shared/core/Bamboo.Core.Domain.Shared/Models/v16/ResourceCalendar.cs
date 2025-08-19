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

[Table("resource_calendar")]
public partial class ResourceCalendar: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("tz")]
    public string? Tz { get; set; }

    [Column("hours_per_day")]
    public double? HoursPerDay { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("two_weeks_calendar")]
    public bool? TwoWeeksCalendar { get; set; }

    [Column("flexible_hours")]
    public bool? FlexibleHours { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("full_time_required_hours")]
    public double? FullTimeRequiredHours { get; set; }

    // [One2many]
    [ForeignKey("TrgDateCalendarId")]
    [InverseProperty("TrgDateCalendar")]
    public virtual ICollection<BaseAutomation> BaseAutomation { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("ResourceCalendarNavigation")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ResourceCalendarCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("ResourceCalendarId")]
    [InverseProperty("ResourceCalendar")]
    public virtual ICollection<HrContract> HrContract { get; set; }

    // [One2many]
    [ForeignKey("ResourceCalendarId")]
    [InverseProperty("ResourceCalendar")]
    public virtual ICollection<HrEmployee> HrEmployee { get; set; }

    // [One2many]
    [ForeignKey("ResourceCalendarId")]
    [InverseProperty("ResourceCalendar")]
    public virtual ICollection<HrLeave> HrLeave { get; set; }

    // [One2many]
    [ForeignKey("ResourceCalendarId")]
    [InverseProperty("ResourceCalendar")]
    public virtual ICollection<HrLeaveMandatoryDay> HrLeaveMandatoryDay { get; set; }

    // [One2many]
    [ForeignKey("ResourceCalendarId")]
    [InverseProperty("ResourceCalendar")]
    public virtual ICollection<HrLeaveStressDay> HrLeaveStressDay { get; set; }

    // [One2many]
    [ForeignKey("DefaultResourceCalendarId")]
    [InverseProperty("DefaultResourceCalendar")]
    public virtual ICollection<HrPayrollStructureType> HrPayrollStructureType { get; set; }

    // [One2many]
    [ForeignKey("ResourceCalendarId")]
    [InverseProperty("ResourceCalendar")]
    public virtual ICollection<MrpWorkcenter> MrpWorkcenter { get; set; }

    // [One2many]
    [ForeignKey("ResourceCalendarId")]
    [InverseProperty("ResourceCalendar")]
    public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [One2many]
    [ForeignKey("CalendarId")]
    [InverseProperty("Calendar")]
    public virtual ICollection<ResourceCalendarAttendance> ResourceCalendarAttendance { get; set; }

    // [One2many]
    [ForeignKey("CalendarId")]
    [InverseProperty("Calendar")]
    public virtual ICollection<ResourceCalendarLeaves> ResourceCalendarLeaves { get; set; }

    // [One2many]
    [ForeignKey("CalendarId")]
    [InverseProperty("Calendar")]
    public virtual ICollection<ResourceResource> ResourceResource { get; set; }

    // [One2many]
    [ForeignKey("OpeningHours")]
    [InverseProperty("OpeningHoursNavigation")]
    public virtual ICollection<StockWarehouse> StockWarehouse { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ResourceCalendarWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
