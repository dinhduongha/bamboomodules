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
//[Index("DateFrom", Name = "hr_leave__date_from_index")]
//[Index("EmployeeId", Name = "hr_leave__employee_id_index")]
//[Index("UserId", Name = "hr_leave__user_id_index")]
//[Index("DateTo", "DateFrom", Name = "hr_leave_date_to_date_from_index")]
public partial class HrLeave: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

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

    [Column("resource_calendar_id")]
    public Guid? ResourceCalendarId { get; set; }

    [Column("meeting_id")]
    public Guid? MeetingId { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("category_id")]
    public Guid? CategoryId { get; set; }

    [Column("mode_company_id")]
    public Guid? ModeCompanyId { get; set; }

    [Column("first_approver_id")]
    public Guid? FirstApproverId { get; set; }

    [Column("second_approver_id")]
    public Guid? SecondApproverId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("number_of_days")]
    public double? NumberOfDays { get; set; }

    [Column("number_of_hours")]
    public double? NumberOfHours { get; set; }

    // [Column("request_hour_from")]
    // public double? RequestHourFrom { get; set; }

    // [Column("request_hour_to")]
    // public double? RequestHourTo { get; set; }

    [Column("overtime_id")]
    public Guid? OvertimeId { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("HolidayId")]
    [InverseProperty("Holiday")]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLine { get; set; }

    // [Many2one]
    [ForeignKey("CategoryId")]
    // [InverseProperty("HrLeave")] //Many2one
    public virtual HrEmployeeCategory? Category { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("HrLeaveCompany")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("HrLeaveCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("DepartmentId")]
    // [InverseProperty("HrLeave")] //Many2one
    public virtual HrDepartment? Department { get; set; }

    // [Many2one]
    [ForeignKey("EmployeeId")]
    // [InverseProperty("HrLeaveEmployee")] //Many2one
    public virtual HrEmployee? Employee { get; set; }

    // [Many2one]
    [ForeignKey("EmployeeCompanyId")]
    // [InverseProperty("HrLeaveEmployeeCompany")] //Many2one
    public virtual ResCompany? EmployeeCompany { get; set; }

    // [Many2one]
    [ForeignKey("FirstApproverId")]
    // [InverseProperty("HrLeaveFirstApprover")] //Many2one
    public virtual HrEmployee? FirstApprover { get; set; }

    // [Many2one]
    [ForeignKey("HolidayAllocationId")]
    // [InverseProperty("HrLeave")] //Many2one
    public virtual HrLeaveAllocation? HolidayAllocation { get; set; }

    // [Many2one]
    [ForeignKey("HolidayStatusId")]
    // [InverseProperty("HrLeave")] //Many2one
    public virtual HrLeaveType? HolidayStatus { get; set; }

    // [One2many]
    [ForeignKey("LeaveId")]
    [InverseProperty("Leave")]
    public virtual ICollection<HrHolidaysCancelLeave> HrHolidaysCancelLeave { get; set; }

    // [One2many]
    [ForeignKey("LeaveId")]
    [InverseProperty("Leave")]
    public virtual ICollection<HrWorkEntry> HrWorkEntry { get; set; }

    // [One2many]
    [ForeignKey("ParentId")]
    [InverseProperty("Parent")]
    public virtual ICollection<HrLeave> InverseParent { get; set; }

    // [Many2one]
    [ForeignKey("ManagerId")]
    // [InverseProperty("HrLeaveManager")] //Many2one
    public virtual HrEmployee? Manager { get; set; }

    // [Many2one]
    [ForeignKey("MeetingId")]
    // [InverseProperty("HrLeave")] //Many2one
    public virtual CalendarEvent? Meeting { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("HrLeave")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("ModeCompanyId")]
    // [InverseProperty("HrLeaveModeCompany")] //Many2one
    public virtual ResCompany? ModeCompany { get; set; }

    // [Many2one]
    [ForeignKey("OvertimeId")]
    // [InverseProperty("HrLeave")] //Many2one
    public virtual HrAttendanceOvertime? Overtime { get; set; }

    // [Many2one]
    [ForeignKey("ParentId")]
    // [InverseProperty("InverseParent")] //Many2one
    public virtual HrLeave? Parent { get; set; }

    // [Many2one]
    [ForeignKey("ResourceCalendarId")]
    // [InverseProperty("HrLeave")] //Many2one
    public virtual ResourceCalendar? ResourceCalendar { get; set; }

    // [One2many]
    [ForeignKey("HolidayId")]
    [InverseProperty("Holiday")]
    public virtual ICollection<ResourceCalendarLeaves> ResourceCalendarLeaves { get; set; }

    // [Many2one]
    [ForeignKey("SecondApproverId")]
    // [InverseProperty("HrLeaveSecondApprover")] //Many2one
    public virtual HrEmployee? SecondApprover { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("HrLeaveUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("HrLeaveWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("HrLeaveId")] //Many2many
    // [InverseProperty("HrLeave")] //Many2many
    public virtual ICollection<HrEmployee> HrEmployee { get; set; }
}
