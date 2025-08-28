using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("hr_recruitment_degree")]
//[Index("Name", Name = "hr_recruitment_degree_name_uniq", IsUnique = true)]
public partial class HrRecruitmentDegree
{
    // v16-Compat
    // [One2many]
    // [One2many] [ForeignKey("TypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Type")] // One2many
    // public virtual ICollection<HrApplicant> HrApplicant { get; set; }
}
