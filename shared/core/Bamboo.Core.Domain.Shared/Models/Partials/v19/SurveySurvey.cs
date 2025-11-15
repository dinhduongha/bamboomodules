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

public partial class SurveySurvey
{
    [Column("team_id")]
    public Guid? TeamId { get; set; }

    [Column("generate_lead")]
    public bool? GenerateLead { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OriginSurveyId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("OriginSurvey")] // One2many
    public virtual ICollection<CrmLead> CrmLead { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TeamId")]
    public virtual CrmTeam? Team { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("SurveySurveyId")] // Many2many // Normal
    // [InverseProperty("SurveySurvey")] // Many2many // Normal
    public virtual ICollection<ResLang> ResLang { get; set; }

}