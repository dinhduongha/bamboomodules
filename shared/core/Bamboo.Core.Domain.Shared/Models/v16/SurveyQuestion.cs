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

[Table("survey_question")]
public partial class SurveyQuestion: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

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
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("question_type")]
    public string? QuestionType { get; set; }

    [Column("matrix_subtype")]
    public string? MatrixSubtype { get; set; }

    [Column("answer_date")]
    public DateTime? AnswerDate { get; set; }

    [Column("validation_min_date")]
    public DateTime? ValidationMinDate { get; set; }

    [Column("validation_max_date")]
    public DateTime? ValidationMaxDate { get; set; }

    [JsonField]
    [Column("title", TypeName = "jsonb")]
    public string? Title { get; set; }

    [JsonField]
    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [JsonField]
    [Column("question_placeholder", TypeName = "jsonb")]
    public string? QuestionPlaceholder { get; set; }

    [JsonField]
    [Column("scale_min_label", TypeName = "jsonb")]
    public string? ScaleMinLabel { get; set; }

    [JsonField]
    [Column("scale_mid_label", TypeName = "jsonb")]
    public string? ScaleMidLabel { get; set; }

    [JsonField]
    [Column("scale_max_label", TypeName = "jsonb")]
    public string? ScaleMaxLabel { get; set; }

    [JsonField]
    [Column("comments_message", TypeName = "jsonb")]
    public string? CommentsMessage { get; set; }

    [JsonField]
    [Column("validation_error_msg", TypeName = "jsonb")]
    public string? ValidationErrorMsg { get; set; }

    [JsonField]
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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("answer_numerical_box")]
    public double? AnswerNumericalBox { get; set; }

    [Column("answer_score")]
    public double? AnswerScore { get; set; }

    [Column("validation_min_float_value")]
    public double? ValidationMinFloatValue { get; set; }

    [Column("validation_max_float_value")]
    public double? ValidationMaxFloatValue { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("PageId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Page")] // One2many
    public virtual ICollection<SurveyQuestion> InversePage { get; set; }

    // [Many2one]
    [ForeignKey("PageId")]
    public virtual SurveyQuestion? Page { get; set; }

    // [Many2one]
    [ForeignKey("SurveyId")]
    public virtual SurveySurvey? Survey { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MatrixQuestionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MatrixQuestion")] // One2many
    public virtual ICollection<SurveyQuestionAnswer> SurveyQuestionAnswerMatrixQuestion { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("QuestionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Question")] // One2many
    public virtual ICollection<SurveyQuestionAnswer> SurveyQuestionAnswerQuestion { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("SessionQuestionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SessionQuestion")] // One2many
    public virtual ICollection<SurveySurvey> SurveySurvey { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("QuestionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Question")] // One2many
    public virtual ICollection<SurveyUserInputLine> SurveyUserInputLine { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("LastDisplayedPageId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("LastDisplayedPage")] // One2many
    public virtual ICollection<SurveyUserInput> SurveyUserInputNavigation { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("SurveyQuestionId")] // Many2many // Normal
    // [InverseProperty("SurveyQuestion")] // Many2many // Normal
    public virtual ICollection<SurveyQuestionAnswer> SurveyQuestionAnswer { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("SurveyQuestionId")] //Many2many // Hidden
    // [InverseProperty("SurveyQuestion")] //Many2many // Hidden
    public virtual ICollection<SurveyUserInput> SurveyUserInput { get; set; }
}
