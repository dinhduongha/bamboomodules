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

[Table("hr_candidate_skill")]
//[Index("CandidateId", "SkillId", Name = "hr_candidate_skill__unique_skill", IsUnique = true)]
public partial class HrCandidateSkill: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("candidate_id")]
    public Guid? CandidateId { get; set; }

    [Column("skill_id")]
    public Guid? SkillId { get; set; }

    [Column("skill_level_id")]
    public Guid? SkillLevelId { get; set; }

    [Column("skill_type_id")]
    public Guid? SkillTypeId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("CandidateId")]
    //[InverseProperty("HrCandidateSkills")]
    [NotMapped]
    public virtual HrCandidate? Candidate { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrCandidateSkillCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("SkillId")]
    //[InverseProperty("HrCandidateSkills")]
    [NotMapped]
    public virtual HrSkill? Skill { get; set; }

    [ForeignKey("SkillLevelId")]
    //[InverseProperty("HrCandidateSkills")]
    [NotMapped]
    public virtual HrSkillLevel? SkillLevel { get; set; }

    [ForeignKey("SkillTypeId")]
    //[InverseProperty("HrCandidateSkills")]
    [NotMapped]
    public virtual HrSkillType? SkillType { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrCandidateSkillWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
