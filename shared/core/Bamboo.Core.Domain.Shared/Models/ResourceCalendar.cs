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
public partial class ResourceCalendar: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("tz")]
    public string? Tz { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("two_weeks_calendar")]
    public bool? TwoWeeksCalendar { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("hours_per_day")]
    public double? HoursPerDay { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("ResourceCalendars")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ResourceCalendarCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ResourceCalendarWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("ResourceCalendar")]
    [NotMapped]
    public virtual ICollection<HrContract> HrContracts { get; } = new List<HrContract>();

    //[InverseProperty("ResourceCalendar")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployees { get; } = new List<HrEmployee>();

    //[InverseProperty("ResourceCalendar")]
    [NotMapped]
    public virtual ICollection<HrLeaveStressDay> HrLeaveStressDays { get; } = new List<HrLeaveStressDay>();

    //[InverseProperty("DefaultResourceCalendar")]
    [NotMapped]
    public virtual ICollection<HrPayrollStructureType> HrPayrollStructureTypes { get; } = new List<HrPayrollStructureType>();

    //[InverseProperty("ResourceCalendar")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenter> MrpWorkcenters { get; } = new List<MrpWorkcenter>();

    //[InverseProperty("ResourceCalendar")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanies { get; } = new List<ResCompany>();

    //[InverseProperty("Calendar")]
    [NotMapped]
    public virtual ICollection<ResourceCalendarAttendance> ResourceCalendarAttendances { get; } = new List<ResourceCalendarAttendance>();

    //[InverseProperty("Calendar")]
    [NotMapped]
    public virtual ICollection<ResourceCalendarLeaf> ResourceCalendarLeaves { get; } = new List<ResourceCalendarLeaf>();

    //[InverseProperty("Calendar")]
    [NotMapped]
    public virtual ICollection<ResourceResource> ResourceResources { get; } = new List<ResourceResource>();

}
