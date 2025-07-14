using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;

[Table("hr_leave_generate_multi_wizard")]
public partial class HrLeaveGenerateMultiWizard: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("allocation_mode")]
    public string? AllocationMode { get; set; }

    [Column("date_from")]
    public DateOnly? DateFrom { get; set; }

    [Column("date_to")]
    public DateOnly? DateTo { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CategoryId")]
    //[InverseProperty("HrLeaveGenerateMultiWizards")]
    [NotMapped]
    public virtual HrEmployeeCategory? Category { get; set; }

    [ForeignKey("CompanyId")]
    //[InverseProperty("HrLeaveGenerateMultiWizards")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrLeaveGenerateMultiWizardCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("DepartmentId")]
    //[InverseProperty("HrLeaveGenerateMultiWizards")]
    [NotMapped]
    public virtual HrDepartment? Department { get; set; }

    [ForeignKey("HolidayStatusId")]
    //[InverseProperty("HrLeaveGenerateMultiWizards")]
    [NotMapped]
    public virtual HrLeaveType? HolidayStatus { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrLeaveGenerateMultiWizardWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("HrLeaveGenerateMultiWizardId")]
    //[InverseProperty("HrLeaveGenerateMultiWizards")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployees { get; set; } = new List<HrEmployee>();
}
