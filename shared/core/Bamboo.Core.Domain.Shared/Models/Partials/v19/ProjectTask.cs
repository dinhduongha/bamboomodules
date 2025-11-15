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

public partial class ProjectTask
{

    [Column("is_template")]
    public bool? IsTemplate { get; set; }

    [Column("has_template_ancestor")]
    public bool? HasTemplateAncestor { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TaskId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Task")] // One2many
    public virtual ICollection<TaskShareWizard> TaskShareWizard { get; set; }


    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ProjectTaskId")] // Many2many // Normal
    // [InverseProperty("ProjectTask")] // Many2many // Normal
    public virtual ICollection<ProjectRole> ProjectRole { get; set; }

}