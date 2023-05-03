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

[Table("hr_attendance")]
//[Index("EmployeeId", Name = "hr_attendance_employee_id_index")]
public partial class HrAttendance: Entity<Guid>, IEntityDto<Guid>
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

    [Column("check_in", TypeName = "timestamp without time zone")]
    public DateTime? CheckIn { get; set; }

    [Column("check_out", TypeName = "timestamp without time zone")]
    public DateTime? CheckOut { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("worked_hours")]
    public double? WorkedHours { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrAttendanceCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("EmployeeId")]
    //[InverseProperty("HrAttendances")]
    [NotMapped]
    public virtual HrEmployee? Employee { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrAttendanceWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("LastAttendance")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployees { get; } = new List<HrEmployee>();

}
