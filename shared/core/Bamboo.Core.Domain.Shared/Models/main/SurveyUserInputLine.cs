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

[Table("survey_user_input_line")]
//[Index("QuestionId", Name = "survey_user_input_line__question_id_index")]
//[Index("UserInputId", Name = "survey_user_input_line__user_input_id_index")]
public partial class SurveyUserInputLine : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("user_input_id")]
    public Guid? UserInputId { get; set; }

    [Column("survey_id")]
    public Guid? SurveyId { get; set; }

    [Column("question_id")]
    public Guid? QuestionId { get; set; }

    [Column("question_sequence")]
    public long? QuestionSequence { get; set; }

    [Column("value_scale")]
    public long? ValueScale { get; set; }

    [Column("suggested_answer_id")]
    public Guid? SuggestedAnswerId { get; set; }

    [Column("matrix_row_id")]
    public Guid? MatrixRowId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("answer_type")]
    public string? AnswerType { get; set; }

    [Column("value_char_box")]
    public string? ValueCharBox { get; set; }

    [Column("value_date")]
    public DateTime? ValueDate { get; set; }

    [Column("value_text_box")]
    public string? ValueTextBox { get; set; }

    [Column("skipped")]
    public bool? Skipped { get; set; }

    [Column("answer_is_correct")]
    public bool? AnswerIsCorrect { get; set; }

    [Column("value_datetime", TypeName = "timestamp without time zone")]
    public DateTime? ValueDatetime { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("value_numerical_box")]
    public double? ValueNumericalBox { get; set; }

    [Column("answer_score")]
    public double? AnswerScore { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("MatrixRowId")]
    public virtual SurveyQuestionAnswer? MatrixRow { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("QuestionId")]
    public virtual SurveyQuestion? Question { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SuggestedAnswerId")]
    public virtual SurveyQuestionAnswer? SuggestedAnswer { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SurveyId")]
    public virtual SurveySurvey? Survey { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UserInputId")]
    public virtual SurveyUserInput? UserInput { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
