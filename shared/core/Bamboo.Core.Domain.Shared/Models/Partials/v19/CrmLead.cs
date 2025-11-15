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

public partial class CrmLead
{

    [Column("won_status")]
    public string? WonStatus { get; set; }

    [Column("origin_channel_id")]
    public Guid? OriginChannelId { get; set; }

    [Column("origin_survey_id")]
    public Guid? OriginSurveyId { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("OriginChannelId")]
    public virtual DiscussChannel? OriginChannel { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("OriginSurveyId")]
    public virtual SurveySurvey? OriginSurvey { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LeadId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Lead")] // One2many
    public virtual ICollection<SurveyUserInput> SurveyUserInput { get; set; }


}