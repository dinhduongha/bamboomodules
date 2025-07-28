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

[Table("hr_leave_allocation_generate_multi_wizard")]
public partial class HrLeaveAllocationGenerateMultiWizard: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("holiday_status_id")]
    public Guid? HolidayStatusId { get; set; }

    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

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

    [Column("allocation_mode")]
    public string? AllocationMode { get; set; }

    [Column("allocation_type")]
    public string? AllocationType { get; set; }

    [Column("date_from")]
    public DateTime? DateFrom { get; set; }

    [Column("date_to")]
    public DateTime? DateTo { get; set; }

    [Column("notes")]
    public string? Notes { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("duration")]
    public double? Duration { get; set; }

    [ForeignKey("AccrualPlanId")]
    //[InverseProperty("HrLeaveAllocationGenerateMultiWizards")]
    [NotMapped]
    public virtual HrLeaveAccrualPlan? AccrualPlan { get; set; }

    [ForeignKey("CategoryId")]
    //[InverseProperty("HrLeaveAllocationGenerateMultiWizards")]
    [NotMapped]
    public virtual HrEmployeeCategory? Category { get; set; }

    [ForeignKey("CompanyId")]
    //[InverseProperty("HrLeaveAllocationGenerateMultiWizards")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrLeaveAllocationGenerateMultiWizardCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("DepartmentId")]
    //[InverseProperty("HrLeaveAllocationGenerateMultiWizards")]
    [NotMapped]
    public virtual HrDepartment? Department { get; set; }

    [ForeignKey("HolidayStatusId")]
    //[InverseProperty("HrLeaveAllocationGenerateMultiWizards")]
    [NotMapped]
    public virtual HrLeaveType? HolidayStatus { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrLeaveAllocationGenerateMultiWizardWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("HrLeaveAllocationGenerateMultiWizardId")]
    //[InverseProperty("HrLeaveAllocationGenerateMultiWizards")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployees { get; set; } 
}
