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

[Table("hr_applicant_skill")]
//[Index("ApplicantId", "SkillId", Name = "hr_applicant_skill__unique_skill", IsUnique = true)]
public partial class HrApplicantSkill: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("applicant_id")]
    public Guid? ApplicantId { get; set; }

    [Column("skill_id")]
    public Guid? SkillId { get; set; }

    [Column("skill_level_id")]
    public Guid? SkillLevelId { get; set; }

    [Column("skill_type_id")]
    public Guid? SkillTypeId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("ApplicantId")]
    // [InverseProperty("HrApplicantSkill")] //Many2one
    public virtual HrApplicant? Applicant { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("HrApplicantSkillCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("SkillId")]
    // [InverseProperty("HrApplicantSkill")] //Many2one
    public virtual HrSkill? Skill { get; set; }

    // [Many2one]
    [ForeignKey("SkillLevelId")]
    // [InverseProperty("HrApplicantSkill")] //Many2one
    public virtual HrSkillLevel? SkillLevel { get; set; }

    // [Many2one]
    [ForeignKey("SkillTypeId")]
    // [InverseProperty("HrApplicantSkill")] //Many2one
    public virtual HrSkillType? SkillType { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("HrApplicantSkillWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
