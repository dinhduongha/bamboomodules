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

public partial class CrmStage
{
    [Column("rotting_threshold_days")]
    public long? RottingThresholdDays { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("CrmStageId")] // Many2many // Normal
    // [InverseProperty("CrmStage")] // Many2many // Normal
    public virtual ICollection<CrmTeam> CrmTeam { get; set; }
}