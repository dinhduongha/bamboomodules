using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;

[Table("survey_question_answer")]
public partial class SurveyQuestionAnswer: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("question_id")]
    public Guid? QuestionId { get; set; }

    [Column("matrix_question_id")]
    public Guid? MatrixQuestionId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("value_image_filename")]
    public string? ValueImageFilename { get; set; }

    [Column("value", TypeName = "jsonb")]
    public string? Value { get; set; }

    [Column("is_correct")]
    public bool? IsCorrect { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("answer_score")]
    public double? AnswerScore { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SurveyQuestionAnswerCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MatrixQuestionId")]
    //[InverseProperty("SurveyQuestionAnswerMatrixQuestions")]
    [NotMapped]
    public virtual SurveyQuestion? MatrixQuestion { get; set; }

    [ForeignKey("QuestionId")]
    //[InverseProperty("SurveyQuestionAnswerQuestions")]
    [NotMapped]
    public virtual SurveyQuestion? Question { get; set; }

    //[InverseProperty("MatrixRow")]
    [NotMapped]
    public virtual ICollection<SurveyUserInputLine> SurveyUserInputLineMatrixRows { get; set; } = new List<SurveyUserInputLine>();

    //[InverseProperty("SuggestedAnswer")]
    [NotMapped]
    public virtual ICollection<SurveyUserInputLine> SurveyUserInputLineSuggestedAnswers { get; set; } = new List<SurveyUserInputLine>();

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SurveyQuestionAnswerWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("SurveyQuestionAnswerId")]
    //[InverseProperty("SurveyQuestionAnswers")]
    [NotMapped]
    public virtual ICollection<SurveyQuestion> SurveyQuestions { get; set; } = new List<SurveyQuestion>();
}
