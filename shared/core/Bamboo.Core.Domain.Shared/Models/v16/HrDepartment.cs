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

    [JsonField(IsSparse = false)] // Name
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DepartmentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Department")] // One2many
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLine { get; set; }

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
    // [One2many] [ForeignKey("DepartmentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Department")] // One2many
    public virtual ICollection<HrApplicant> HrApplicant { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DepartmentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Department")] // One2many
    public virtual ICollection<HrContract> HrContract { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DepartmentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Department")] // One2many
    public virtual ICollection<HrEmployee> HrEmployee { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DepartmentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Department")] // One2many
    public virtual ICollection<HrEmployeeSkillLog> HrEmployeeSkillLog { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DepartmentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Department")] // One2many
    public virtual ICollection<HrExpenseSheet> HrExpenseSheet { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DepartmentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Department")] // One2many
    public virtual ICollection<HrJob> HrJob { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DepartmentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Department")] // One2many
    public virtual ICollection<HrLeave> HrLeave { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DepartmentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Department")] // One2many
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DepartmentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Department")] // One2many
    public virtual ICollection<HrLeaveAllocationGenerateMultiWizard> HrLeaveAllocationGenerateMultiWizard { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DepartmentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Department")] // One2many
    public virtual ICollection<HrLeaveGenerateMultiWizard> HrLeaveGenerateMultiWizard { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DepartmentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Department")] // One2many
    public virtual ICollection<HrResumeLine> HrResumeLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DepartmentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Department")] // One2many
    public virtual ICollection<HrWorkEntry> HrWorkEntry { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MasterDepartmentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MasterDepartment")] // One2many
    public virtual ICollection<HrDepartment> InverseMasterDepartment { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ParentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Parent")] // One2many
    public virtual ICollection<HrDepartment> InverseParent { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DepartmentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Department")] // One2many
    public virtual ICollection<MailActivityPlan> MailActivityPlan { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DepartmentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Department")] // One2many
    public virtual ICollection<MaintenanceEquipment> MaintenanceEquipment { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ManagerId")]
    public virtual HrEmployee? Manager { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("MasterDepartmentId")]
    public virtual HrDepartment? MasterDepartment { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ParentId")]
    public virtual HrDepartment? Parent { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrDepartmentId")] //Many2many // Hidden
    // [InverseProperty("HrDepartment")] //Many2many // Hidden
    public virtual ICollection<DiscussChannel> DiscussChannel { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrDepartmentId")] //Many2many // Hidden
    // [InverseProperty("HrDepartment")] //Many2many // Hidden
    public virtual ICollection<HrLeaveMandatoryDay> HrLeaveMandatoryDay { get; set; }
}
