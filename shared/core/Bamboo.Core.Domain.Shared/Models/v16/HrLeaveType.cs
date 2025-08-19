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

[Table("hr_leave_type")]
public partial class HrLeaveType: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("icon_id")]
    public Guid? IconId { get; set; }

    [Column("responsible_id")]
    public Guid? ResponsibleId { get; set; }

    [Column("leave_notif_subtype_id")]
    public Guid? LeaveNotifSubtypeId { get; set; }

    [Column("allocation_notif_subtype_id")]
    public Guid? AllocationNotifSubtypeId { get; set; }

    [Column("max_allowed_negative")]
    public long? MaxAllowedNegative { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("color_name")]
    public string? ColorName { get; set; }

    [Column("leave_validation_type")]
    public string? LeaveValidationType { get; set; }

    [Column("requires_allocation")]
    public string? RequiresAllocation { get; set; }

    [Column("employee_requests")]
    public string? EmployeeRequests { get; set; }

    [Column("allocation_validation_type")]
    public string? AllocationValidationType { get; set; }

    [Column("time_type")]
    public string? TimeType { get; set; }

    [Column("request_unit")]
    public string? RequestUnit { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("create_calendar_meeting")]
    public bool? CreateCalendarMeeting { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("show_on_dashboard")]
    public bool? ShowOnDashboard { get; set; }

    [Column("unpaid")]
    public bool? Unpaid { get; set; }

    [Column("include_public_holidays_in_duration")]
    public bool? IncludePublicHolidaysInDuration { get; set; }

    [Column("support_document")]
    public bool? SupportDocument { get; set; }

    [Column("allows_negative")]
    public bool? AllowsNegative { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("overtime_deductible")]
    public bool? OvertimeDeductible { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("work_entry_type_id")]
    public Guid? WorkEntryTypeId { get; set; }

    [Column("timesheet_project_id")]
    public Guid? TimesheetProjectId { get; set; }

    [Column("timesheet_task_id")]
    public Guid? TimesheetTaskId { get; set; }

    [Column("timesheet_generate")]
    public bool? TimesheetGenerate { get; set; }

    // [Many2one]
    [ForeignKey("AllocationNotifSubtypeId")]
    // [InverseProperty("HrLeaveTypeAllocationNotifSubtype")] //Many2one
    public virtual MailMessageSubtype? AllocationNotifSubtype { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("HrLeaveType")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("HrLeaveTypeCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("HolidayStatusId")]
    [InverseProperty("HolidayStatus")]
    public virtual ICollection<HrLeave> HrLeave { get; set; }

    // [One2many]
    [ForeignKey("TimeOffTypeId")]
    [InverseProperty("TimeOffType")]
    public virtual ICollection<HrLeaveAccrualPlan> HrLeaveAccrualPlan { get; set; }

    // [One2many]
    [ForeignKey("HolidayStatusId")]
    [InverseProperty("HolidayStatus")]
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocation { get; set; }

    // [One2many]
    [ForeignKey("HolidayStatusId")]
    [InverseProperty("HolidayStatus")]
    public virtual ICollection<HrLeaveAllocationGenerateMultiWizard> HrLeaveAllocationGenerateMultiWizard { get; set; }

    // [One2many]
    [ForeignKey("HolidayStatusId")]
    [InverseProperty("HolidayStatus")]
    public virtual ICollection<HrLeaveGenerateMultiWizard> HrLeaveGenerateMultiWizard { get; set; }

    // [Many2one]
    [ForeignKey("IconId")]
    // [InverseProperty("HrLeaveType")] //Many2one
    public virtual IrAttachment? Icon { get; set; }

    // [Many2one]
    [ForeignKey("LeaveNotifSubtypeId")]
    // [InverseProperty("HrLeaveTypeLeaveNotifSubtype")] //Many2one
    public virtual MailMessageSubtype? LeaveNotifSubtype { get; set; }

    // [Many2one]
    [ForeignKey("ResponsibleId")]
    // [InverseProperty("HrLeaveTypeResponsible")] //Many2one
    public virtual ResUsers? Responsible { get; set; }

    // [Many2one]
    [ForeignKey("TimesheetProjectId")]
    // [InverseProperty("HrLeaveType")] //Many2one
    public virtual ProjectProject? TimesheetProject { get; set; }

    // [Many2one]
    [ForeignKey("TimesheetTaskId")]
    // [InverseProperty("HrLeaveType")] //Many2one
    public virtual ProjectTask? TimesheetTask { get; set; }

    // [Many2one]
    [ForeignKey("WorkEntryTypeId")]
    // [InverseProperty("HrLeaveType")] //Many2one
    public virtual HrWorkEntryType? WorkEntryType { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("HrLeaveTypeWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("HrLeaveTypeId")] //Many2many
    // [InverseProperty("HrLeaveType")] //Many2many
    public virtual ICollection<ResUsers> ResUsers { get; set; }
}
