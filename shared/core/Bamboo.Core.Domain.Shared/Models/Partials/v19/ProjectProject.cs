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

public partial class ProjectProject
{

    [Column("is_template")]
    public bool? IsTemplate { get; set; }

    // // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [One2many] [ForeignKey("ProjectId")]
    // // [NotMapped] // One2many // Normal
    // // [InverseProperty("Project")] // One2many
    // public virtual ICollection<ProjectMilestone> ProjectMilestone { get; set; }

    // // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [One2many] [ForeignKey("ProjectId")]
    // // [NotMapped] // One2many // Normal
    // // [InverseProperty("Project")] // One2many
    // public virtual ICollection<ProjectSaleLineEmployeeMap> ProjectSaleLineEmployeeMap { get; set; }

    // // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [One2many] [ForeignKey("ProjectId")]
    // // [NotMapped] // One2many // Normal
    // // [InverseProperty("Project")] // One2many
    // public virtual ICollection<ProjectTask> ProjectTask { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Template")] // One2many
    public virtual ICollection<ProjectTemplateCreateWizard> ProjectTemplateCreateWizard { get; set; }

}