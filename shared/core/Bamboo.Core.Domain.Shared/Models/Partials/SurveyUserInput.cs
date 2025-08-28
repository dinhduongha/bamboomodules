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

//[Table("survey_user_input")]
//[Index("AccessToken", Name = "survey_user_input_unique_token", IsUnique = true)]
public partial class SurveyUserInput
{
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    // [Column("scoring_total")]
    // public double? ScoringTotal { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ResponseId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Response")] // One2many
    public virtual ICollection<HrApplicant> HrApplicant { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }
}
