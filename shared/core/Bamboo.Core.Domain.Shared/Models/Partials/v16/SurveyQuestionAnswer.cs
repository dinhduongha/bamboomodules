using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("survey_question_answer")]
public partial class SurveyQuestionAnswer
{
    // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TriggeringAnswerId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("TriggeringAnswer")] // One2many
    //public virtual ICollection<SurveyQuestion> SurveyQuestion { get; set; }
}
