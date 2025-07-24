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
//[Index("DateFrom", Name = "hr_leave_allocation_date_from_index")]
//[Index("EmployeeId", Name = "hr_leave_allocation_employee_id_index")]
public partial class HrLeaveAllocation : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    // v16-Compat
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

    // v16-Compat
    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("approver_id")]
    public Guid? ApproverId { get; set; }

    [Column("second_approver_id")]
    public Guid? SecondApproverId { get; set; }

    // v16-Compat
    [Column("mode_company_id")]
    public Guid? ModeCompanyId { get; set; }

    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

    // v16-Compat
    [Column("category_id")]
    public Guid? CategoryId { get; set; }

    [Column("accrual_plan_id")]
    public Guid? AccrualPlanId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    // v16-Compat
    [Column("private_name")]
    public string? PrivateName { get; set; }

    [Column("state")]
    public string? State { get; set; }

    // v16-Compat
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

    [Column("already_accrued")]
    public bool? AlreadyAccrued { get; set; }

    // v16-Compat
    [Column("active")]
    public bool? Active { get; set; }

    // v16-Compat
    [Column("multi_employee")]
    public bool? MultiEmployee { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

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

    // v16-Compat
    [ForeignKey("TenantId")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("AccrualPlanId")]
    //[InverseProperty("HrLeaveAllocations")]
    [NotMapped]
    public virtual HrLeaveAccrualPlan? AccrualPlan { get; set; }

    [ForeignKey("ApproverId")]
    //[InverseProperty("HrLeaveAllocationApprovers")]
    [NotMapped]
    public virtual HrEmployee? Approver { get; set; }

    [ForeignKey("CategoryId")]
    //[InverseProperty("HrLeaveAllocations")]
    [NotMapped]
    public virtual HrEmployeeCategory? Category { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrLeaveAllocationCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("DepartmentId")]
    //[InverseProperty("HrLeaveAllocations")]
    [NotMapped]
    public virtual HrDepartment? Department { get; set; }

    [ForeignKey("EmployeeId")]
    //[InverseProperty("HrLeaveAllocationEmployees")]
    [NotMapped]
    public virtual HrEmployee? Employee { get; set; }

    [ForeignKey("EmployeeCompanyId")]
    //[InverseProperty("HrLeaveAllocationEmployeeCompanies")]
    [NotMapped]
    public virtual ResCompany? EmployeeCompany { get; set; }

    [ForeignKey("HolidayStatusId")]
    //[InverseProperty("HrLeaveAllocations")]
    [NotMapped]
    public virtual HrLeaveType? HolidayStatus { get; set; }

    [ForeignKey("ManagerId")]
    //[InverseProperty("HrLeaveAllocationManagers")]
    [NotMapped]
    public virtual HrEmployee? Manager { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("HrLeaveAllocations")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("ModeCompanyId")]
    //[InverseProperty("HrLeaveAllocationModeCompanies")]
    [NotMapped]
    public virtual ResCompany? ModeCompany { get; set; }

    [ForeignKey("OvertimeId")]
    //[InverseProperty("HrLeaveAllocations")]
    [NotMapped]
    public virtual HrAttendanceOvertime? Overtime { get; set; }

    [ForeignKey("ParentId")]
    //[InverseProperty("InverseParent")]
    [NotMapped]
    public virtual HrLeaveAllocation? Parent { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrLeaveAllocationWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("HolidayAllocation")]
    [NotMapped]
    public virtual ICollection<HrLeave> HrLeaves { get; set; } = new List<HrLeave>();

    //[InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<HrLeaveAllocation> InverseParent { get; set; } = new List<HrLeaveAllocation>();

    [ForeignKey("HrLeaveAllocationId")]
    //[InverseProperty("HrLeaveAllocations")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployees { get; set; } = new List<HrEmployee>();
}
