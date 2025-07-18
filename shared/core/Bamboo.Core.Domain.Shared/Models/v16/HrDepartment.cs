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

[Table("hr_department")]
//[Index("TenantId", Name = "hr_department_company_id_index")]
//[Index("ParentId", Name = "hr_department_parent_id_index")]
//[Index("ParentPath", Name = "hr_department_parent_path_index")]
public partial class HrDepartment: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    // v16-Compat
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("manager_id")]
    public Guid? ManagerId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("master_department_id")]
    public Guid? MasterDepartmentId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    // v16-Compat json
    //[Column("name")]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("complete_name")]
    public string? CompleteName { get; set; }

    [Column("parent_path")]
    public string? ParentPath { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("HrDepartments")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrDepartmentCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ManagerId")]
    //[InverseProperty("HrDepartments")]
    [NotMapped]
    public virtual HrEmployee? Manager { get; set; }

    [ForeignKey("MasterDepartmentId")]
    //[InverseProperty("InverseMasterDepartment")]
    [NotMapped]
    public virtual HrDepartment? MasterDepartment { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("HrDepartments")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("ParentId")]
    //[InverseProperty("InverseParent")]
    [NotMapped]
    public virtual HrDepartment? Parent { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrDepartmentWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Department")]
    [NotMapped]
    public virtual ICollection<HrApplicant> HrApplicants { get; set; } = new List<HrApplicant>();

    //[InverseProperty("Department")]
    [NotMapped]
    public virtual ICollection<HrContract> HrContracts { get; set; } = new List<HrContract>();

    //[InverseProperty("Department")]
    [NotMapped]
    public virtual ICollection<HrEmployeeSkillLog> HrEmployeeSkillLogs { get; set; } = new List<HrEmployeeSkillLog>();

    //[InverseProperty("Department")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployees { get; set; } = new List<HrEmployee>();

    //[InverseProperty("Department")]
    [NotMapped]
    public virtual ICollection<HrExpenseSheet> HrExpenseSheets { get; set; } = new List<HrExpenseSheet>();

    //[InverseProperty("Department")]
    [NotMapped]
    public virtual ICollection<HrJob> HrJobs { get; set; } = new List<HrJob>();

    //[InverseProperty("Department")]
    [NotMapped]
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocations { get; set; } = new List<HrLeaveAllocation>();

    //[InverseProperty("Department")]
    [NotMapped]
    public virtual ICollection<HrLeave> HrLeaves { get; set; } = new List<HrLeave>();

    //[InverseProperty("Department")]
    [NotMapped]
    public virtual ICollection<HrPlan> HrPlans { get; set; } = new List<HrPlan>();

    //[InverseProperty("MasterDepartment")]
    [NotMapped]
    public virtual ICollection<HrDepartment> InverseMasterDepartment { get; set; } = new List<HrDepartment>();

    //[InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<HrDepartment> InverseParent { get; set; } = new List<HrDepartment>();

    //[InverseProperty("Department")]
    [NotMapped]
    public virtual ICollection<MaintenanceEquipment> MaintenanceEquipments { get; set; } = new List<MaintenanceEquipment>();

    [ForeignKey("HrDepartmentId")]
    //[InverseProperty("HrDepartments")]
    [NotMapped]
    public virtual ICollection<HrLeaveStressDay> HrLeaveStressDays { get; set; } = new List<HrLeaveStressDay>();

    [ForeignKey("HrDepartmentId")]
    //[InverseProperty("HrDepartments")]
    [NotMapped]
    public virtual ICollection<MailChannel> MailChannels { get; set; } = new List<MailChannel>();
}
