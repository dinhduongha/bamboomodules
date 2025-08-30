using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

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

    [Column("request_date_from_period")]
    public string? RequestDateFromPeriod { get; set; }

    [Column("request_date_from")]
    public DateTime? RequestDateFrom { get; set; }

    [Column("request_date_to")]
    public DateTime? RequestDateTo { get; set; }

    [Column("notes")]
    public string? Notes { get; set; }

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

    [Column("request_hour_from")]
    public double? RequestHourFrom { get; set; }

    [Column("request_hour_to")]
    public double? RequestHourTo { get; set; }

    [Column("overtime_id")]
    public Guid? OvertimeId { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("HolidayId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Holiday")] // One2many
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("DepartmentId")]
    public virtual HrDepartment? Department { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("EmployeeId")]
    public virtual HrEmployee? Employee { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("EmployeeCompanyId")]
    public virtual ResCompany? EmployeeCompany { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("FirstApproverId")]
    public virtual HrEmployee? FirstApprover { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("HolidayStatusId")]
    public virtual HrLeaveType? HolidayStatus { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LeaveId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Leave")] // One2many
    public virtual ICollection<HrHolidaysCancelLeave> HrHolidaysCancelLeave { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LeaveId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Leave")] // One2many
    public virtual ICollection<HrWorkEntry> HrWorkEntry { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ManagerId")]
    public virtual HrEmployee? Manager { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("MeetingId")]
    public virtual CalendarEvent? Meeting { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("OvertimeId")]
    public virtual HrAttendanceOvertime? Overtime { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ResourceCalendarId")]
    public virtual ResourceCalendar? ResourceCalendar { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("HolidayId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Holiday")] // One2many
    public virtual ICollection<ResourceCalendarLeaves> ResourceCalendarLeaves { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SecondApproverId")]
    public virtual HrEmployee? SecondApprover { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
