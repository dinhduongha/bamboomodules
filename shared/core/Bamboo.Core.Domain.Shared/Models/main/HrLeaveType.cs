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

[Table("hr_leave_type")]
public partial class HrLeaveType : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("icon_id")]
    public Guid? IconId { get; set; }

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

    [JsonField(IsSparse = false)] // Name
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

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
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AllocationNotifSubtypeId")]
    public virtual MailMessageSubtype? AllocationNotifSubtype { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("HolidayStatusId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("HolidayStatus")] // One2many
    public virtual ICollection<HrLeave> HrLeave { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TimeOffTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("TimeOffType")] // One2many
    public virtual ICollection<HrLeaveAccrualPlan> HrLeaveAccrualPlan { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("HolidayStatusId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("HolidayStatus")] // One2many
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("HolidayStatusId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("HolidayStatus")] // One2many
    public virtual ICollection<HrLeaveAllocationGenerateMultiWizard> HrLeaveAllocationGenerateMultiWizard { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("HolidayStatusId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("HolidayStatus")] // One2many
    public virtual ICollection<HrLeaveGenerateMultiWizard> HrLeaveGenerateMultiWizard { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("IconId")]
    public virtual IrAttachment? Icon { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LeaveNotifSubtypeId")]
    public virtual MailMessageSubtype? LeaveNotifSubtype { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TimesheetProjectId")]
    public virtual ProjectProject? TimesheetProject { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TimesheetTaskId")]
    public virtual ProjectTask? TimesheetTask { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("WorkEntryTypeId")]
    public virtual HrWorkEntryType? WorkEntryType { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (ResUsers) is commented out
    // [ForeignKey("HrLeaveTypeId")] // Many2many // Normal
    // [InverseProperty("HrLeaveType")] // Many2many // Normal
    public virtual ICollection<ResUsers> ResUsers { get; set; }
}
