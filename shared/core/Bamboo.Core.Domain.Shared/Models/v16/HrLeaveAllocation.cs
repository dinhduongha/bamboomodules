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

[Table("hr_leave_allocation")]
//[Index("DateFrom", Name = "hr_leave_allocation__date_from_index")]
//[Index("EmployeeId", Name = "hr_leave_allocation__employee_id_index")]
public partial class HrLeaveAllocation: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("holiday_status_id")]
    public Guid? HolidayStatusId { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("employee_company_id")]
    public Guid? EmployeeCompanyId { get; set; }

    [Column("manager_id")]
    public Guid? ManagerId { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("approver_id")]
    public Guid? ApproverId { get; set; }

    [Column("second_approver_id")]
    public Guid? SecondApproverId { get; set; }

    [Column("mode_company_id")]
    public Guid? ModeCompanyId { get; set; }

    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

    [Column("category_id")]
    public Guid? CategoryId { get; set; }

    [Column("accrual_plan_id")]
    public Guid? AccrualPlanId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("private_name")]
    public string? PrivateName { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("holiday_type")]
    public string? HolidayType { get; set; }

    [Column("allocation_type")]
    public string? AllocationType { get; set; }

    [Column("date_from")]
    public DateTime? DateFrom { get; set; }

    [Column("date_to")]
    public DateTime? DateTo { get; set; }

    [Column("last_executed_carryover_date")]
    public DateTime? LastExecutedCarryoverDate { get; set; }

    [Column("lastcall")]
    public DateTime? Lastcall { get; set; }

    [Column("actual_lastcall")]
    public DateTime? ActualLastcall { get; set; }

    [Column("nextcall")]
    public DateTime? Nextcall { get; set; }

    [Column("carried_over_days_expiration_date")]
    public DateTime? CarriedOverDaysExpirationDate { get; set; }

    [Column("notes")]
    public string? Notes { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("already_accrued")]
    public bool? AlreadyAccrued { get; set; }
    [Column("multi_employee")]
    public bool? MultiEmployee { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("number_of_days")]
    public double? NumberOfDays { get; set; }

    [Column("number_of_hours_display")]
    public double? NumberOfHoursDisplay { get; set; }

    [Column("yearly_accrued_amount")]
    public double? YearlyAccruedAmount { get; set; }

    [Column("expiring_carryover_days")]
    public double? ExpiringCarryoverDays { get; set; }

    [Column("overtime_id")]
    public Guid? OvertimeId { get; set; }

    // [Many2one]
    [ForeignKey("AccrualPlanId")]
    // [InverseProperty("HrLeaveAllocation")] //Many2one
    public virtual HrLeaveAccrualPlan? AccrualPlan { get; set; }

    // [Many2one]
    [ForeignKey("ApproverId")]
    // [InverseProperty("HrLeaveAllocationApprover")] //Many2one
    public virtual HrEmployee? Approver { get; set; }

    // [Many2one]
    [ForeignKey("CategoryId")]
    // [InverseProperty("HrLeaveAllocation")] //Many2one
    public virtual HrEmployeeCategory? Category { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("HrLeaveAllocationCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("DepartmentId")]
    // [InverseProperty("HrLeaveAllocation")] //Many2one
    public virtual HrDepartment? Department { get; set; }

    // [Many2one]
    [ForeignKey("EmployeeId")]
    // [InverseProperty("HrLeaveAllocationEmployee")] //Many2one
    public virtual HrEmployee? Employee { get; set; }

    // [Many2one]
    [ForeignKey("EmployeeCompanyId")]
    // [InverseProperty("HrLeaveAllocationEmployeeCompany")] //Many2one
    // [InverseProperty("HrLeaveAllocation")] //Many2one
    public virtual ResCompany? EmployeeCompany { get; set; }

    // [Many2one]
    [ForeignKey("HolidayStatusId")]
    // [InverseProperty("HrLeaveAllocation")] //Many2one
    public virtual HrLeaveType? HolidayStatus { get; set; }

    // [One2many]
    [ForeignKey("HolidayAllocationId")]
    [InverseProperty("HolidayAllocation")]
    public virtual ICollection<HrLeave> HrLeave { get; set; }

    // [One2many]
    [ForeignKey("ParentId")]
    [InverseProperty("Parent")]
    public virtual ICollection<HrLeaveAllocation> InverseParent { get; set; }

    // [Many2one]
    [ForeignKey("ManagerId")]
    // [InverseProperty("HrLeaveAllocationManager")] //Many2one
    public virtual HrEmployee? Manager { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("HrLeaveAllocation")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("ModeCompanyId")]
    // [InverseProperty("HrLeaveAllocationModeCompany")] //Many2one
    public virtual ResCompany? ModeCompany { get; set; }

    // [Many2one]
    [ForeignKey("OvertimeId")]
    // [InverseProperty("HrLeaveAllocation")] //Many2one
    public virtual HrAttendanceOvertime? Overtime { get; set; }

    // [Many2one]
    [ForeignKey("ParentId")]
    // [InverseProperty("InverseParent")] //Many2one
    public virtual HrLeaveAllocation? Parent { get; set; }

    // [Many2one]
    [ForeignKey("SecondApproverId")]
    // [InverseProperty("HrLeaveAllocationSecondApprover")] //Many2one
    public virtual HrEmployee? SecondApprover { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("HrLeaveAllocationWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("HrLeaveAllocationId")] //Many2many
    // [InverseProperty("HrLeaveAllocation")] //Many2many
    public virtual ICollection<HrEmployee> HrEmployee { get; set; }
}
