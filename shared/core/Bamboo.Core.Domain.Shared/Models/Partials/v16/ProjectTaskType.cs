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

//[Table("project_task_type")]
//[Index("UserId", Name = "project_task_type__user_id_index")]
public partial class ProjectTaskType
{
    [JsonField(IsSparse = false)] // Description
    [Column("description", TypeName = "jsonb")]
    public StringDictionary? Description { get; set; }

    [JsonField]
    [Column("legend_blocked", TypeName = "jsonb")]
    public JsonElement? LegendBlocked { get; set; }

    [JsonField]
    [Column("legend_done", TypeName = "jsonb")]
    public JsonElement? LegendDone { get; set; }

    [JsonField]
    [Column("legend_normal", TypeName = "jsonb")]
    public JsonElement? LegendNormal { get; set; }

    [Column("auto_validation_kanban_state")]
    public bool? AutoValidationKanbanState { get; set; }

    // [Many2many] // Normal
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("TypeId")] // Many2many // Normal
    // [InverseProperty("Type")] // Many2many // Normal
    // public virtual ICollection<ProjectProject> Project { get; set; }

}
