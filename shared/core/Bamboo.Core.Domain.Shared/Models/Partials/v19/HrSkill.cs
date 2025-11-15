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

public partial class HrSkill
{
    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SkillId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Skill")] // One2many
    public virtual ICollection<HrApplicantSkill> HrApplicantSkill { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SkillId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Skill")] // One2many
    public virtual ICollection<HrJobSkill> HrJobSkill { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrSkillId")] //Many2many // Hidden
    // [InverseProperty("HrSkill")] //Many2many // Hidden
    public virtual ICollection<HrApplicant> HrApplicant { get; set; }

}