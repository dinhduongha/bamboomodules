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

[Table("hr_leave")]
//[Index("DateFrom", Name = "hr_leave_date_from_index")]
//[Index("DateTo", "DateFrom", Name = "hr_leave_date_to_date_from_index")]
//[Index("EmployeeId", Name = "hr_leave_employee_id_index")]
//[Index("UserId", Name = "hr_leave_user_id_index")]
public partial class HrLeave: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("manager_id")]
    public Guid? ManagerId { get; set; }

    [Column("holiday_status_id")]
    public Guid? HolidayStatusId { get; set; }

    [Column("holiday_allocation_id")]
    public Guid? HolidayAllocationId { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("employee_company_id")]
    public Guid? EmployeeCompanyId { get; set; }

    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

    [Column("meeting_id")]
    public Guid? MeetingId { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("category_id")]
    public long? CategoryId { get; set; }

    [Column("mode_company_id")]
    public Guid? ModeCompanyId { get; set; }

    [Column("first_approver_id")]
    public Guid? FirstApproverId { get; set; }

    [Column("second_approver_id")]
    public Guid? SecondApproverId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("private_name")]
    public string? PrivateName { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("duration_display")]
    public string? DurationDisplay { get; set; }

    [Column("holiday_type")]
    public string? HolidayType { get; set; }

    [Column("request_hour_from")]
    public string? RequestHourFrom { get; set; }

    [Column("request_hour_to")]
    public string? RequestHourTo { get; set; }

    [Column("request_date_from_period")]
    public string? RequestDateFromPeriod { get; set; }

    [Column("request_date_from")]
    public DateTime? RequestDateFrom { get; set; }

    [Column("request_date_to")]
    public DateTime? RequestDateTo { get; set; }

    [Column("report_note")]
    public string? ReportNote { get; set; }

    [Column("notes")]
    public string? Notes { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("multi_employee")]
    public bool? MultiEmployee { get; set; }

    [Column("request_unit_half")]
    public bool? RequestUnitHalf { get; set; }

    [Column("request_unit_hours")]
    public bool? RequestUnitHours { get; set; }

    [Column("date_from", TypeName = "timestamp without time zone")]
    public DateTime? DateFrom { get; set; }

    [Column("date_to", TypeName = "timestamp without time zone")]
    public DateTime? DateTo { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("number_of_days")]
    public double? NumberOfDays { get; set; }

    [Column("overtime_id")]
    public Guid? OvertimeId { get; set; }

    [ForeignKey("CategoryId")]
    //[InverseProperty("HrLeaves")]
    [NotMapped]
    public virtual HrEmployeeCategory? Category { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrLeaveCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("DepartmentId")]
    //[InverseProperty("HrLeaves")]
    [NotMapped]
    public virtual HrDepartment? Department { get; set; }

    [ForeignKey("EmployeeId")]
    //[InverseProperty("HrLeaveEmployees")]
    [NotMapped]
    public virtual HrEmployee? Employee { get; set; }

    [ForeignKey("EmployeeCompanyId")]
    //[InverseProperty("HrLeaveEmployeeCompanies")]
    [NotMapped]
    public virtual ResCompany? EmployeeCompany { get; set; }

    [ForeignKey("FirstApproverId")]
    //[InverseProperty("HrLeaveFirstApprovers")]
    [NotMapped]
    public virtual HrEmployee? FirstApprover { get; set; }

    [ForeignKey("HolidayAllocationId")]
    //[InverseProperty("HrLeaves")]
    [NotMapped]
    public virtual HrLeaveAllocation? HolidayAllocation { get; set; }

    [ForeignKey("HolidayStatusId")]
    //[InverseProperty("HrLeaves")]
    [NotMapped]
    public virtual HrLeaveType? HolidayStatus { get; set; }

    [ForeignKey("ManagerId")]
    //[InverseProperty("HrLeaveManagers")]
    [NotMapped]
    public virtual HrEmployee? Manager { get; set; }

    [ForeignKey("MeetingId")]
    //[InverseProperty("HrLeaves")]
    [NotMapped]
    public virtual CalendarEvent? Meeting { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("HrLeaves")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("ModeCompanyId")]
    //[InverseProperty("HrLeaveModeCompanies")]
    [NotMapped]
    public virtual ResCompany? ModeCompany { get; set; }

    [ForeignKey("OvertimeId")]
    //[InverseProperty("HrLeaves")]
    [NotMapped]
    public virtual HrAttendanceOvertime? Overtime { get; set; }

    [ForeignKey("ParentId")]
    //[InverseProperty("InverseParent")]
    [NotMapped]
    public virtual HrLeave? Parent { get; set; }

    [ForeignKey("SecondApproverId")]
    //[InverseProperty("HrLeaveSecondApprovers")]
    [NotMapped]
    public virtual HrEmployee? SecondApprover { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("HrLeaveUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrLeaveWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Leave")]
    [NotMapped]
    public virtual ICollection<HrHolidaysCancelLeave> HrHolidaysCancelLeaves { get; } = new List<HrHolidaysCancelLeave>();

    //[InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<HrLeave> InverseParent { get; } = new List<HrLeave>();

    //[InverseProperty("Holiday")]
    [NotMapped]
    public virtual ICollection<ResourceCalendarLeaf> ResourceCalendarLeaves { get; } = new List<ResourceCalendarLeaf>();

    [ForeignKey("HrLeaveId")]
    //[InverseProperty("HrLeaves")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployees { get; } = new List<HrEmployee>();
}
