using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;

[Table("survey_question")]
public partial class SurveyQuestion: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("survey_id")]
    public Guid? SurveyId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("random_questions_count")]
    public long? RandomQuestionsCount { get; set; }

    [Column("page_id")]
    public Guid? PageId { get; set; }

    [Column("scale_min")]
    public long? ScaleMin { get; set; }

    [Column("scale_max")]
    public long? ScaleMax { get; set; }

    [Column("time_limit")]
    public long? TimeLimit { get; set; }

    [Column("validation_length_min")]
    public long? ValidationLengthMin { get; set; }

    [Column("validation_length_max")]
    public long? ValidationLengthMax { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("question_type")]
    public string? QuestionType { get; set; }

    [Column("matrix_subtype")]
    public string? MatrixSubtype { get; set; }

    [Column("answer_date")]
    public DateOnly? AnswerDate { get; set; }

    [Column("validation_min_date")]
    public DateOnly? ValidationMinDate { get; set; }

    [Column("validation_max_date")]
    public DateOnly? ValidationMaxDate { get; set; }

    [Column("title", TypeName = "jsonb")]
    public string? Title { get; set; }

    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [Column("question_placeholder", TypeName = "jsonb")]
    public string? QuestionPlaceholder { get; set; }

    [Column("scale_min_label", TypeName = "jsonb")]
    public string? ScaleMinLabel { get; set; }

    [Column("scale_mid_label", TypeName = "jsonb")]
    public string? ScaleMidLabel { get; set; }

    [Column("scale_max_label", TypeName = "jsonb")]
    public string? ScaleMaxLabel { get; set; }

    [Column("comments_message", TypeName = "jsonb")]
    public string? CommentsMessage { get; set; }

    [Column("validation_error_msg", TypeName = "jsonb")]
    public string? ValidationErrorMsg { get; set; }

    [Column("constr_error_msg", TypeName = "jsonb")]
    public string? ConstrErrorMsg { get; set; }

    [Column("is_page")]
    public bool? IsPage { get; set; }

    [Column("is_scored_question")]
    public bool? IsScoredQuestion { get; set; }

    [Column("save_as_email")]
    public bool? SaveAsEmail { get; set; }

    [Column("save_as_nickname")]
    public bool? SaveAsNickname { get; set; }

    [Column("is_time_limited")]
    public bool? IsTimeLimited { get; set; }

    [Column("is_time_customized")]
    public bool? IsTimeCustomized { get; set; }

    [Column("comments_allowed")]
    public bool? CommentsAllowed { get; set; }

    [Column("comment_count_as_answer")]
    public bool? CommentCountAsAnswer { get; set; }

    [Column("validation_required")]
    public bool? ValidationRequired { get; set; }

    [Column("validation_email")]
    public bool? ValidationEmail { get; set; }

    [Column("constr_mandatory")]
    public bool? ConstrMandatory { get; set; }

    [Column("answer_datetime", TypeName = "timestamp without time zone")]
    public DateTime? AnswerDatetime { get; set; }

    [Column("validation_min_datetime", TypeName = "timestamp without time zone")]
    public DateTime? ValidationMinDatetime { get; set; }

    [Column("validation_max_datetime", TypeName = "timestamp without time zone")]
    public DateTime? ValidationMaxDatetime { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("answer_numerical_box")]
    public double? AnswerNumericalBox { get; set; }

    [Column("answer_score")]
    public double? AnswerScore { get; set; }

    [Column("validation_min_float_value")]
    public double? ValidationMinFloatValue { get; set; }

    [Column("validation_max_float_value")]
    public double? ValidationMaxFloatValue { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SurveyQuestionCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("Page")]
    [NotMapped]
    public virtual ICollection<SurveyQuestion> InversePage { get; set; } = new List<SurveyQuestion>();

    [ForeignKey("PageId")]
    //[InverseProperty("InversePage")]
    [NotMapped]
    public virtual SurveyQuestion? Page { get; set; }

    [ForeignKey("SurveyId")]
    //[InverseProperty("SurveyQuestions")]
    [NotMapped]
    public virtual SurveySurvey? Survey { get; set; }

    //[InverseProperty("MatrixQuestion")]
    [NotMapped]
    public virtual ICollection<SurveyQuestionAnswer> SurveyQuestionAnswerMatrixQuestions { get; set; } = new List<SurveyQuestionAnswer>();

    //[InverseProperty("Question")]
    [NotMapped]
    public virtual ICollection<SurveyQuestionAnswer> SurveyQuestionAnswerQuestions { get; set; } = new List<SurveyQuestionAnswer>();

    //[InverseProperty("SessionQuestion")]
    [NotMapped]
    public virtual ICollection<SurveySurvey> SurveySurveys { get; set; } = new List<SurveySurvey>();

    //[InverseProperty("Question")]
    [NotMapped]
    public virtual ICollection<SurveyUserInputLine> SurveyUserInputLines { get; set; } = new List<SurveyUserInputLine>();

    //[InverseProperty("LastDisplayedPage")]
    [NotMapped]
    public virtual ICollection<SurveyUserInput> SurveyUserInputsNavigation { get; set; } = new List<SurveyUserInput>();

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SurveyQuestionWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("SurveyQuestionId")]
    //[InverseProperty("SurveyQuestions")]
    [NotMapped]
    public virtual ICollection<SurveyQuestionAnswer> SurveyQuestionAnswers { get; set; } = new List<SurveyQuestionAnswer>();

    [ForeignKey("SurveyQuestionId")]
    //[InverseProperty("SurveyQuestions")]
    [NotMapped]
    public virtual ICollection<SurveyUserInput> SurveyUserInputs { get; set; } = new List<SurveyUserInput>();
}
