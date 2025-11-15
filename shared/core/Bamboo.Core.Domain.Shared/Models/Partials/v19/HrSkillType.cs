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

public partial class HrSkillType
{
    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("levels_count")]
    public long? LevelsCount { get; set; }

    [Column("is_certification")]
    public bool? IsCertification { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SkillTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SkillType")] // One2many
    public virtual ICollection<HrApplicantSkill> HrApplicantSkill { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SkillTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SkillType")] // One2many
    public virtual ICollection<HrJobSkill> HrJobSkill { get; set; }


}