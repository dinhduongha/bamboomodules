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
public partial class ResourceCalendar: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("tz")]
    public string? Tz { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("two_weeks_calendar")]
    public bool? TwoWeeksCalendar { get; set; }

    [Column("flexible_hours")]
    public bool? FlexibleHours { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("hours_per_day")]
    public decimal? HoursPerDay { get; set; }

    [Column("full_time_required_hours")]
    public double? FullTimeRequiredHours { get; set; }

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
    public virtual ICollection<HrContract> HrContracts { get; set; } 

    //[InverseProperty("ResourceCalendar")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployees { get; set; } 

    //[InverseProperty("ResourceCalendar")]
    [NotMapped]
    public virtual ICollection<HrLeaveStressDay> HrLeaveStressDays { get; set; } 

    //[InverseProperty("DefaultResourceCalendar")]
    [NotMapped]
    public virtual ICollection<HrPayrollStructureType> HrPayrollStructureTypes { get; set; } 

    //[InverseProperty("ResourceCalendar")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenter> MrpWorkcenters { get; set; } 

    //[InverseProperty("ResourceCalendar")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanies { get; set; } 

    //[InverseProperty("Calendar")]
    [NotMapped]
    public virtual ICollection<ResourceCalendarAttendance> ResourceCalendarAttendances { get; set; } 

    //[InverseProperty("Calendar")]
    [NotMapped]
    public virtual ICollection<ResourceCalendarLeaves> ResourceCalendarLeaves { get; set; } 

    //[InverseProperty("Calendar")]
    [NotMapped]
    public virtual ICollection<ResourceResource> ResourceResources { get; set; } 

}
