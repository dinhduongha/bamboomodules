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
public partial class HrLeaveAllocation: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("holiday_status_id")]
    public Guid? HolidayStatusId { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("employee_company_id")]
    public Guid? EmployeeCompanyId { get; set; }

    [Column("manager_id")]
    public Guid? ManagerId { get; set; }

    [Column("approver_id")]
    public Guid? ApproverId { get; set; }

    [Column("second_approver_id")]
    public Guid? SecondApproverId { get; set; }

    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

    [Column("accrual_plan_id")]
    public Guid? AccrualPlanId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("state")]
    public string? State { get; set; }

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

    [Column("already_accrued")]
    public bool? AlreadyAccrued { get; set; }

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
    public virtual HrLeaveAccrualPlan? AccrualPlan { get; set; }

    // [Many2one]
    [ForeignKey("ApproverId")]
    public virtual HrEmployee? Approver { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("DepartmentId")]
    public virtual HrDepartment? Department { get; set; }

    // [Many2one]
    [ForeignKey("EmployeeId")]
    public virtual HrEmployee? Employee { get; set; }

    // [Many2one]
    [ForeignKey("EmployeeCompanyId")]
    public virtual ResCompany? EmployeeCompany { get; set; }

    // [Many2one]
    [ForeignKey("HolidayStatusId")]
    public virtual HrLeaveType? HolidayStatus { get; set; }

    // [Many2one]
    [ForeignKey("ManagerId")]
    public virtual HrEmployee? Manager { get; set; }

    // [Many2one]
    [ForeignKey("OvertimeId")]
    public virtual HrAttendanceOvertime? Overtime { get; set; }

    // [Many2one]
    [ForeignKey("SecondApproverId")]
    public virtual HrEmployee? SecondApprover { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
