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

//[Table("survey_question")]
public partial class SurveyQuestion
{
    [Column("triggering_question_id")]
    public Guid? TriggeringQuestionId { get; set; }

    [Column("triggering_answer_id")]
    public Guid? TriggeringAnswerId { get; set; }

    [Column("is_conditional")]
    public bool? IsConditional { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("TriggeringQuestionId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("TriggeringQuestion")] // One2many
    public virtual ICollection<SurveyQuestion> InverseTriggeringQuestion { get; set; }

    // [Many2one]
    [ForeignKey("TriggeringAnswerId")]
    public virtual SurveyQuestionAnswer? TriggeringAnswer { get; set; }

    // [Many2one]
    [ForeignKey("TriggeringQuestionId")]
    public virtual SurveyQuestion? TriggeringQuestion { get; set; }
}
