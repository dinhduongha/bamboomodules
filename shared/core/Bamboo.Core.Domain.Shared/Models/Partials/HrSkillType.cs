using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("hr_skill_type")]
public partial class HrSkillType
{
    // v16-Compat
    //[Column("name")]
    //public string? Name { get; set; }

    // v16-Compat
    // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SkillTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SkillType")] // One2many
    // public virtual ICollection<HrApplicantSkill> HrApplicantSkill { get; set; }

}
