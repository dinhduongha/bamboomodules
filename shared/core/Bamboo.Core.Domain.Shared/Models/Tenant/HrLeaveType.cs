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
public partial class HrLeaveType: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("sequence", TypeName = "bigserial")]
    public long Sequence { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("icon_id")]
    public Guid? IconId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("responsible_id")]
    public Guid? ResponsibleId { get; set; }

    [Column("leave_notif_subtype_id")]
    public long? LeaveNotifSubtypeId { get; set; }

    [Column("allocation_notif_subtype_id")]
    public long? AllocationNotifSubtypeId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("create_calendar_meeting")]
    public bool? CreateCalendarMeeting { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("unpaid")]
    public bool? Unpaid { get; set; }

    [Column("support_document")]
    public bool? SupportDocument { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("overtime_deductible")]
    public bool? OvertimeDeductible { get; set; }

    [ForeignKey("AllocationNotifSubtypeId")]
    //[InverseProperty("HrLeaveTypeAllocationNotifSubtypes")]
    [NotMapped]
    public virtual MailMessageSubtype? AllocationNotifSubtype { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("HrLeaveTypes")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrLeaveTypeCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("IconId")]
    //[InverseProperty("HrLeaveTypes")]
    [NotMapped]
    public virtual IrAttachment? Icon { get; set; }

    [ForeignKey("LeaveNotifSubtypeId")]
    //[InverseProperty("HrLeaveTypeLeaveNotifSubtypes")]
    [NotMapped]
    public virtual MailMessageSubtype? LeaveNotifSubtype { get; set; }

    [ForeignKey("ResponsibleId")]
    //[InverseProperty("HrLeaveTypeResponsibles")]
    [NotMapped]
    public virtual ResUser? Responsible { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrLeaveTypeWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    // ForeignKey???
    //[InverseProperty("TimeOffType")]
    [NotMapped]
    public virtual ICollection<HrLeaveAccrualPlan> HrLeaveAccrualPlans { get; } = new List<HrLeaveAccrualPlan>();

    // ForeignKey???
    //[InverseProperty("HolidayStatus")]
    [NotMapped]
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocations { get; } = new List<HrLeaveAllocation>();

    // ForeignKey???
    //[InverseProperty("HolidayStatus")]
    [NotMapped]
    public virtual ICollection<HrLeave> HrLeaves { get; } = new List<HrLeave>();

}
