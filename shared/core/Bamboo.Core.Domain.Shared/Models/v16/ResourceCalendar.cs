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
    public decimal? HoursPerDay { get; set; }

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
    // [One2many] [ForeignKey("TrgDateCalendarId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("TrgDateCalendar")] // One2many
    public virtual ICollection<BaseAutomation> BaseAutomation { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ResourceCalendarId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ResourceCalendar")] // One2many
    public virtual ICollection<HrContract> HrContract { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ResourceCalendarId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ResourceCalendar")] // One2many
    public virtual ICollection<HrEmployee> HrEmployee { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ResourceCalendarId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ResourceCalendar")] // One2many
    public virtual ICollection<HrLeave> HrLeave { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ResourceCalendarId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ResourceCalendar")] // One2many
    public virtual ICollection<HrLeaveMandatoryDay> HrLeaveMandatoryDay { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("DefaultResourceCalendarId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("DefaultResourceCalendar")] // One2many
    public virtual ICollection<HrPayrollStructureType> HrPayrollStructureType { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ResourceCalendarId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ResourceCalendar")] // One2many
    public virtual ICollection<MrpWorkcenter> MrpWorkcenter { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ResourceCalendarId")]
    [NotMapped] // One2many // Peer relationship (ResCompany) is commented out
    // [InverseProperty("ResourceCalendar")] // One2many
    public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("CalendarId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Calendar")] // One2many
    public virtual ICollection<ResourceCalendarAttendance> ResourceCalendarAttendance { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("CalendarId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Calendar")] // One2many
    public virtual ICollection<ResourceCalendarLeaves> ResourceCalendarLeaves { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("CalendarId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Calendar")] // One2many
    public virtual ICollection<ResourceResource> ResourceResource { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("OpeningHours")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("OpeningHoursNavigation")] // One2many
    public virtual ICollection<StockWarehouse> StockWarehouse { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
