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

[Table("hr_skill_type")]
public partial class HrSkillType: Entity<long>, IEntityDto<long>
{
    [Key]
    [Column("id")]
    public long Id { get => base.Id; set => base.Id = value; }

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
    //[InverseProperty("HrSkillTypeCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrSkillTypeWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("SkillType")]
    [NotMapped]
    public virtual ICollection<HrApplicantSkill> HrApplicantSkills { get; } = new List<HrApplicantSkill>();

    //[InverseProperty("SkillType")]
    [NotMapped]
    public virtual ICollection<HrEmployeeSkillLog> HrEmployeeSkillLogs { get; } = new List<HrEmployeeSkillLog>();

    //[InverseProperty("SkillType")]
    [NotMapped]
    public virtual ICollection<HrEmployeeSkill> HrEmployeeSkills { get; } = new List<HrEmployeeSkill>();

    //[InverseProperty("SkillType")]
    [NotMapped]
    public virtual ICollection<HrSkillLevel> HrSkillLevels { get; } = new List<HrSkillLevel>();

    //[InverseProperty("SkillType")]
    [NotMapped]
    public virtual ICollection<HrSkill> HrSkills { get; } = new List<HrSkill>();

}
