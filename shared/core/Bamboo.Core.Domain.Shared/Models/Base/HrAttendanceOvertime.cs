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

[Table("hr_attendance_overtime")]
//[Index("EmployeeId", Name = "hr_attendance_overtime_employee_id_index")]
public partial class HrAttendanceOvertime: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("adjustment")]
    public bool? Adjustment { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("duration")]
    public double? Duration { get; set; }

    [Column("duration_real")]
    public double? DurationReal { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrAttendanceOvertimeCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("EmployeeId")]
    //[InverseProperty("HrAttendanceOvertimes")]
    [NotMapped]
    public virtual HrEmployee? Employee { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrAttendanceOvertimeWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Overtime")]
    [NotMapped]
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocations { get; } = new List<HrLeaveAllocation>();

    //[InverseProperty("Overtime")]
    [NotMapped]
    public virtual ICollection<HrLeave> HrLeaves { get; } = new List<HrLeave>();

}
