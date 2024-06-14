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
public partial class HrSkill: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("sequence", TypeName = "bigserial")]
    public long Sequence { get; set; }

    [Column("skill_type_id")]
    public long? SkillTypeId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

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
    public virtual ICollection<HrApplicantSkill> HrApplicantSkills { get; } = new List<HrApplicantSkill>();

    //[InverseProperty("Skill")]
    [NotMapped]
    public virtual ICollection<HrEmployeeSkillLog> HrEmployeeSkillLogs { get; } = new List<HrEmployeeSkillLog>();

    //[InverseProperty("Skill")]
    [NotMapped]
    public virtual ICollection<HrEmployeeSkill> HrEmployeeSkills { get; } = new List<HrEmployeeSkill>();

    [ForeignKey("HrSkillId")]
    //[InverseProperty("HrSkills")]
    [NotMapped]
    public virtual ICollection<HrApplicant> HrApplicants { get; } = new List<HrApplicant>();

    [ForeignKey("HrSkillId")]
    //[InverseProperty("HrSkills")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployees { get; } = new List<HrEmployee>();
}
