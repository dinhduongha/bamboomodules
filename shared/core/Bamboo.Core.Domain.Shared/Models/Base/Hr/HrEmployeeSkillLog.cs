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

[Table("hr_employee_skill_log")]
//[Index("EmployeeId", "DepartmentId", "SkillId", "Date", Name = "hr_employee_skill_log__unique_skill_log", IsUnique = true)]
public partial class HrEmployeeSkillLog : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

    [Column("skill_id")]
    public Guid? SkillId { get; set; }

    [Column("skill_level_id")]
    public Guid? SkillLevelId { get; set; }

    [Column("skill_type_id")]
    public Guid? SkillTypeId { get; set; }

    [Column("level_progress")]
    public long? LevelProgress { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrEmployeeSkillLogCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("DepartmentId")]
    //[InverseProperty("HrEmployeeSkillLogs")]
    [NotMapped]
    public virtual HrDepartment? Department { get; set; }

    [ForeignKey("EmployeeId")]
    //[InverseProperty("HrEmployeeSkillLogs")]
    [NotMapped]
    public virtual HrEmployee? Employee { get; set; }

    [ForeignKey("SkillId")]
    //[InverseProperty("HrEmployeeSkillLogs")]
    [NotMapped]
    public virtual HrSkill? Skill { get; set; }

    [ForeignKey("SkillLevelId")]
    //[InverseProperty("HrEmployeeSkillLogs")]
    [NotMapped]
    public virtual HrSkillLevel? SkillLevel { get; set; }

    [ForeignKey("SkillTypeId")]
    //[InverseProperty("HrEmployeeSkillLogs")]
    [NotMapped]
    public virtual HrSkillType? SkillType { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrEmployeeSkillLogWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
