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

[Table("survey_survey")]
//[Index("AccessToken", Name = "survey_survey_access_token_unique", IsUnique = true)]
//[Index("CertificationBadgeId", Name = "survey_survey_badge_uniq", IsUnique = true)]
//[Index("SessionCode", Name = "survey_survey_session_code_unique", IsUnique = true)]
public partial class SurveySurvey: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("attempts_limit")]
    public long? AttemptsLimit { get; set; }

    [Column("certification_mail_template_id")]
    public Guid? CertificationMailTemplateId { get; set; }

    [Column("certification_badge_id")]
    public Guid? CertificationBadgeId { get; set; }

    [Column("session_question_id")]
    public Guid? SessionQuestionId { get; set; }

    [Column("session_speed_rating_time_limit")]
    public long? SessionSpeedRatingTimeLimit { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("survey_type")]
    public string? SurveyType { get; set; }

    [Column("questions_layout")]
    public string? QuestionsLayout { get; set; }

    [Column("questions_selection")]
    public string? QuestionsSelection { get; set; }

    [Column("progression_mode")]
    public string? ProgressionMode { get; set; }

    [Column("access_mode")]
    public string? AccessMode { get; set; }

    [Column("access_token")]
    public string? AccessToken { get; set; }

    [Column("scoring_type")]
    public string? ScoringType { get; set; }

    [Column("certification_report_layout")]
    public string? CertificationReportLayout { get; set; }

    [Column("session_state")]
    public string? SessionState { get; set; }

    [Column("session_code")]
    public string? SessionCode { get; set; }

    [JsonField(IsSparse = false)] // Title
    [Column("title", TypeName = "jsonb")]
    public StringDictionary? Title { get; set; }

    [JsonField(IsSparse = false)] // Description
    [Column("description", TypeName = "jsonb")]
    public StringDictionary? Description { get; set; }

    [JsonField(IsSparse = false)] // DescriptionDone
    [Column("description_done", TypeName = "jsonb")]
    public StringDictionary? DescriptionDone { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("users_login_required")]
    public bool? UsersLoginRequired { get; set; }

    [Column("users_can_go_back")]
    public bool? UsersCanGoBack { get; set; }

    [Column("is_attempts_limited")]
    public bool? IsAttemptsLimited { get; set; }

    [Column("is_time_limited")]
    public bool? IsTimeLimited { get; set; }

    [Column("certification")]
    public bool? Certification { get; set; }

    [Column("certification_give_badge")]
    public bool? CertificationGiveBadge { get; set; }

    [Column("session_speed_rating")]
    public bool? SessionSpeedRating { get; set; }

    [Column("session_start_time", TypeName = "timestamp without time zone")]
    public DateTime? SessionStartTime { get; set; }

    [Column("session_question_start_time", TypeName = "timestamp without time zone")]
    public DateTime? SessionQuestionStartTime { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("scoring_success_min")]
    public double? ScoringSuccessMin { get; set; }

    [Column("time_limit")]
    public double? TimeLimit { get; set; }

    [Column("certification_validity_months")]
    public long? CertificationValidityMonths { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CertificationBadgeId")]
    public virtual GamificationBadge? CertificationBadge { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CertificationMailTemplateId")]
    public virtual MailTemplate? CertificationMailTemplate { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SurveyId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Survey")] // One2many
    public virtual ICollection<GamificationBadge> GamificationBadge { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SurveyId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Survey")] // One2many
    public virtual ICollection<HrJob> HrJob { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SurveyId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Survey")] // One2many
    public virtual ICollection<HrResumeLine> HrResumeLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SessionQuestionId")]
    public virtual SurveyQuestion? SessionQuestion { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SurveyId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Survey")] // One2many
    public virtual ICollection<SlideSlide> SlideSlide { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SurveyId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Survey")] // One2many
    public virtual ICollection<SurveyInvite> SurveyInvite { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SurveyId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Survey")] // One2many
    public virtual ICollection<SurveyQuestion> SurveyQuestion { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SurveyId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Survey")] // One2many
    public virtual ICollection<SurveyUserInput> SurveyUserInput { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SurveyId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Survey")] // One2many
    public virtual ICollection<SurveyUserInputLine> SurveyUserInputLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (ResUsers) is commented out
    // [ForeignKey("SurveySurveyId")] // Many2many // Normal
    // [InverseProperty("SurveySurvey")] // Many2many // Normal
    public virtual ICollection<ResUsers> ResUsers { get; set; }
}
