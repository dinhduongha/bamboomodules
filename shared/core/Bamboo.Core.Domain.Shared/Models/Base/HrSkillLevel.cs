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

[Table("hr_skill_level")]
public partial class HrSkillLevel: Entity<long>, IEntityDto<long>
{
    [Key]
    [Column("id")]
    public long Id { get => base.Id; set => base.Id = value; }

    [Column("skill_type_id")]
    public long? SkillTypeId { get; set; }

    [Column("level_progress")]
    public long? LevelProgress { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("default_level")]
    public bool? DefaultLevel { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrSkillLevelCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("SkillTypeId")]
    //[InverseProperty("HrSkillLevels")]
    [NotMapped]
    public virtual HrSkillType? SkillType { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrSkillLevelWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("SkillLevel")]
    [NotMapped]
    public virtual ICollection<HrApplicantSkill> HrApplicantSkills { get; } = new List<HrApplicantSkill>();

    //[InverseProperty("SkillLevel")]
    [NotMapped]
    public virtual ICollection<HrEmployeeSkillLog> HrEmployeeSkillLogs { get; } = new List<HrEmployeeSkillLog>();

    //[InverseProperty("SkillLevel")]
    [NotMapped]
    public virtual ICollection<HrEmployeeSkill> HrEmployeeSkills { get; } = new List<HrEmployeeSkill>();

}
