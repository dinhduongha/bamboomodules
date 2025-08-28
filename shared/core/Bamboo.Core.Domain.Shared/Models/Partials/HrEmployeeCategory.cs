using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("hr_employee_category")]
//[Index("Name", Name = "hr_employee_category_name_uniq", IsUnique = true)]
public partial class HrEmployeeCategory
{
    // [One2many]
    // [One2many] [ForeignKey("CategoryId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Category")] // One2many
    public virtual ICollection<HrLeave> HrLeave { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("CategoryId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Category")] // One2many
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocation { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("CategoryId")] //Many2many // Hidden
    // [InverseProperty("Category")] //Many2many // Hidden
    public virtual ICollection<HrEmployee> Emp { get; set; }
}
