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
public partial class HrSkillLevel: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("skill_type_id")]
    public Guid? SkillTypeId { get; set; }

    [Column("level_progress")]
    public long? LevelProgress { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("default_level")]
    public bool? DefaultLevel { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("HrSkillLevelCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("SkillLevelId")]
    [InverseProperty("SkillLevel")]
    public virtual ICollection<HrApplicantSkill> HrApplicantSkill { get; set; }

    // [One2many]
    [ForeignKey("SkillLevelId")]
    [InverseProperty("SkillLevel")]
    public virtual ICollection<HrEmployeeSkill> HrEmployeeSkill { get; set; }

    // [One2many]
    [ForeignKey("SkillLevelId")]
    [InverseProperty("SkillLevel")]
    public virtual ICollection<HrEmployeeSkillLog> HrEmployeeSkillLog { get; set; }

    // [Many2one]
    [ForeignKey("SkillTypeId")]
    // [InverseProperty("HrSkillLevel")] //Many2one
    public virtual HrSkillType? SkillType { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("HrSkillLevelWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
