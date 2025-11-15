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

public partial class HrDepartment
{
    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DepartmentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Department")] // One2many
    public virtual ICollection<HrExpense> HrExpense { get; set; }

    // // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [One2many] [ForeignKey("DepartmentId")]
    // // [NotMapped] // One2many // Normal
    // // [InverseProperty("Department")] // One2many
    // public virtual ICollection<HrJob> HrJob { get; set; }

    // // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [One2many] [ForeignKey("DepartmentId")]
    // // [NotMapped] // One2many // Normal
    // // [InverseProperty("Department")] // One2many
    // public virtual ICollection<HrLeave> HrLeave { get; set; }

    // // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [One2many] [ForeignKey("DepartmentId")]
    // // [NotMapped] // One2many // Normal
    // // [InverseProperty("Department")] // One2many
    // public virtual ICollection<HrLeaveAllocation> HrLeaveAllocation { get; set; }

    // // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [One2many] [ForeignKey("DepartmentId")]
    // // [NotMapped] // One2many // Normal
    // // [InverseProperty("Department")] // One2many
    // public virtual ICollection<HrLeaveAllocationGenerateMultiWizard> HrLeaveAllocationGenerateMultiWizard { get; set; }

    // // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [One2many] [ForeignKey("DepartmentId")]
    // // [NotMapped] // One2many // Normal
    // // [InverseProperty("Department")] // One2many
    // public virtual ICollection<HrLeaveGenerateMultiWizard> HrLeaveGenerateMultiWizard { get; set; }

    // // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [One2many] [ForeignKey("DepartmentId")]
    // // [NotMapped] // One2many // Normal
    // // [InverseProperty("Department")] // One2many
    // public virtual ICollection<HrResumeLine> HrResumeLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DepartmentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Department")] // One2many
    public virtual ICollection<HrVersion> HrVersion { get; set; }

}