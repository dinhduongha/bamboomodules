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

[Table("hr_skill")]
public partial class HrSkill : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("sequence", TypeName = "bigserial")]
    public long? Sequence { get; set; }

    [Column("skill_type_id")]
    public Guid? SkillTypeId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    // v16-Compat json
    //[Column("name")]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrSkillCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("SkillTypeId")]
    //[InverseProperty("HrSkills")]
    [NotMapped]
    public virtual HrSkillType? SkillType { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrSkillWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Skill")]
    [NotMapped]
    public virtual ICollection<HrApplicantSkill> HrApplicantSkills { get; set; } = new List<HrApplicantSkill>();

    //[InverseProperty("Skill")]
    [NotMapped]
    public virtual ICollection<HrEmployeeSkillLog> HrEmployeeSkillLogs { get; set; } = new List<HrEmployeeSkillLog>();

    //[InverseProperty("Skill")]
    [NotMapped]
    public virtual ICollection<HrEmployeeSkill> HrEmployeeSkills { get; set; } = new List<HrEmployeeSkill>();

    [ForeignKey("HrSkillId")]
    //[InverseProperty("HrSkills")]
    [NotMapped]
    public virtual ICollection<HrApplicant> HrApplicants { get; set; } = new List<HrApplicant>();

    [ForeignKey("HrSkillId")]
    //[InverseProperty("HrSkills")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployees { get; set; } = new List<HrEmployee>();

    [ForeignKey("HrSkillId")]
    //[InverseProperty("HrSkills")]
    [NotMapped]
    public virtual ICollection<HrJob> HrJobs { get; set; } = new List<HrJob>();
}
