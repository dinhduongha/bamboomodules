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
//[Index("CompanyId", Name = "hr_department__company_id_index")]
//[Index("ParentId", Name = "hr_department__parent_id_index")]
//[Index("ParentPath", Name = "hr_department__parent_path_index")]
public partial class HrDepartment: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("manager_id")]
    public Guid? ManagerId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("master_department_id")]
    public Guid? MasterDepartmentId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("complete_name")]
    public string? CompleteName { get; set; }

    [Column("parent_path")]
    public string? ParentPath { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    // v16-Compat
    //[Column("name")]
    //public string? Name { get; set; }


    [Column("note")]
    public string? Note { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many]
    [ForeignKey("DepartmentId")]
    [InverseProperty("Department")]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLine { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("HrDepartment")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("HrDepartmentCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("DepartmentId")]
    [InverseProperty("Department")]
    public virtual ICollection<HrApplicant> HrApplicant { get; set; }

    // [One2many]
    [ForeignKey("DepartmentId")]
    [InverseProperty("Department")]
    public virtual ICollection<HrContract> HrContract { get; set; }

    // [One2many]
    [ForeignKey("DepartmentId")]
    [InverseProperty("Department")]
    public virtual ICollection<HrEmployee> HrEmployee { get; set; }

    // [One2many]
    [ForeignKey("DepartmentId")]
    [InverseProperty("Department")]
    public virtual ICollection<HrEmployeeSkillLog> HrEmployeeSkillLog { get; set; }

    // [One2many]
    [ForeignKey("DepartmentId")]
    [InverseProperty("Department")]
    public virtual ICollection<HrExpenseSheet> HrExpenseSheet { get; set; }

    // [One2many]
    [ForeignKey("DepartmentId")]
    [InverseProperty("Department")]
    public virtual ICollection<HrJob> HrJob { get; set; }

    // [One2many]
    [ForeignKey("DepartmentId")]
    [InverseProperty("Department")]
    public virtual ICollection<HrLeave> HrLeave { get; set; }

    // [One2many]
    [ForeignKey("DepartmentId")]
    [InverseProperty("Department")]
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocation { get; set; }

    // [One2many]
    [ForeignKey("DepartmentId")]
    [InverseProperty("Department")]
    public virtual ICollection<HrLeaveAllocationGenerateMultiWizard> HrLeaveAllocationGenerateMultiWizard { get; set; }

    // [One2many]
    [ForeignKey("DepartmentId")]
    [InverseProperty("Department")]
    public virtual ICollection<HrLeaveGenerateMultiWizard> HrLeaveGenerateMultiWizard { get; set; }

    // [One2many]
    [ForeignKey("DepartmentId")]
    [InverseProperty("Department")]
    public virtual ICollection<HrResumeLine> HrResumeLine { get; set; }

    // [One2many]
    [ForeignKey("DepartmentId")]
    [InverseProperty("Department")]
    public virtual ICollection<HrPlan> HrPlan { get; set; }

    // [One2many]
    [ForeignKey("DepartmentId")]
    [InverseProperty("Department")]
    public virtual ICollection<HrWorkEntry> HrWorkEntry { get; set; }

    // [One2many]
    [ForeignKey("MasterDepartmentId")]
    [InverseProperty("MasterDepartment")]
    public virtual ICollection<HrDepartment> InverseMasterDepartment { get; set; }

    // [One2many]
    [ForeignKey("ParentId")]
    [InverseProperty("Parent")]
    public virtual ICollection<HrDepartment> InverseParent { get; set; }

    // [One2many]
    [ForeignKey("DepartmentId")]
    [InverseProperty("Department")]
    public virtual ICollection<MailActivityPlan> MailActivityPlan { get; set; }

    // [One2many]
    [ForeignKey("DepartmentId")]
    [InverseProperty("Department")]
    public virtual ICollection<MaintenanceEquipment> MaintenanceEquipment { get; set; }

    // [Many2one]
    [ForeignKey("ManagerId")]
    // [InverseProperty("HrDepartment")] //Many2one
    public virtual HrEmployee? Manager { get; set; }

    // [Many2one]
    [ForeignKey("MasterDepartmentId")]
    // [InverseProperty("InverseMasterDepartment")] //Many2one
    public virtual HrDepartment? MasterDepartment { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("HrDepartment")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("ParentId")]
    // [InverseProperty("InverseParent")] //Many2one
    public virtual HrDepartment? Parent { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("HrDepartmentWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrDepartmentId")]
    // [InverseProperty("HrDepartment")]
    public virtual ICollection<DiscussChannel> DiscussChannel { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrDepartmentId")]
    // [InverseProperty("HrDepartment")]
    public virtual ICollection<HrLeaveMandatoryDay> HrLeaveMandatoryDay { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrDepartmentId")]
    // [InverseProperty("HrDepartment")]
    public virtual ICollection<HrLeaveStressDay> HrLeaveStressDay { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrDepartmentId")]
    // [InverseProperty("HrDepartment")]
    public virtual ICollection<MailChannel> MailChannel { get; set; }
}
