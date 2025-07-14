using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Table("survey_user_input_line")]
//[Index("QuestionId", Name = "survey_user_input_line__question_id_index")]
//[Index("UserInputId", Name = "survey_user_input_line__user_input_id_index")]
public partial class SurveyUserInputLine: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

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
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("value_numerical_box")]
    public double? ValueNumericalBox { get; set; }

    [Column("answer_score")]
    public double? AnswerScore { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SurveyUserInputLineCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MatrixRowId")]
    //[InverseProperty("SurveyUserInputLineMatrixRows")]
    [NotMapped]
    public virtual SurveyQuestionAnswer? MatrixRow { get; set; }

    [ForeignKey("QuestionId")]
    //[InverseProperty("SurveyUserInputLines")]
    [NotMapped]
    public virtual SurveyQuestion? Question { get; set; }

    [ForeignKey("SuggestedAnswerId")]
    //[InverseProperty("SurveyUserInputLineSuggestedAnswers")]
    [NotMapped]
    public virtual SurveyQuestionAnswer? SuggestedAnswer { get; set; }

    [ForeignKey("SurveyId")]
    //[InverseProperty("SurveyUserInputLines")]
    [NotMapped]
    public virtual SurveySurvey? Survey { get; set; }

    [ForeignKey("UserInputId")]
    //[InverseProperty("SurveyUserInputLines")]
    [NotMapped]
    public virtual SurveyUserInput? UserInput { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SurveyUserInputLineWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
