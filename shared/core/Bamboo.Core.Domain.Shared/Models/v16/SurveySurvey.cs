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

[Table("survey_survey")]
//[Index("AccessToken", Name = "survey_survey_access_token_unique", IsUnique = true)]
//[Index("CertificationBadgeId", Name = "survey_survey_badge_uniq", IsUnique = true)]
//[Index("SessionCode", Name = "survey_survey_session_code_unique", IsUnique = true)]
public partial class SurveySurvey: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    // v16-Compat
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

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
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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

    [Column("title", TypeName = "jsonb")]
    public string? Title { get; set; }

    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [Column("description_done", TypeName = "jsonb")]
    public string? DescriptionDone { get; set; }

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
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("scoring_success_min")]
    public double? ScoringSuccessMin { get; set; }

    [Column("time_limit")]
    public double? TimeLimit { get; set; }

    [Column("certification_validity_months")]
    public long? CertificationValidityMonths { get; set; }

    [ForeignKey("CertificationBadgeId")]
    //[InverseProperty("SurveySurvey")]
    [NotMapped]
    public virtual GamificationBadge? CertificationBadge { get; set; }

    [ForeignKey("CertificationMailTemplateId")]
    //[InverseProperty("SurveySurveys")]
    [NotMapped]
    public virtual MailTemplate? CertificationMailTemplate { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SurveySurveyCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    // v16-Compat
    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("...")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }


    //[InverseProperty("Survey")]
    [NotMapped]
    public virtual ICollection<GamificationBadge> GamificationBadges { get; set; } = new List<GamificationBadge>();

    //[InverseProperty("Survey")]
    [NotMapped]
    public virtual ICollection<HrResumeLine> HrResumeLines { get; set; } = new List<HrResumeLine>();

    [ForeignKey("SessionQuestionId")]
    //[InverseProperty("SurveySurveys")]
    [NotMapped]
    public virtual SurveyQuestion? SessionQuestion { get; set; }

    //[InverseProperty("Survey")]
    [NotMapped]
    public virtual ICollection<SlideSlide> SlideSlides { get; set; } = new List<SlideSlide>();

    //[InverseProperty("Survey")]
    [NotMapped]
    public virtual ICollection<SurveyInvite> SurveyInvites { get; set; } = new List<SurveyInvite>();

    //[InverseProperty("Survey")]
    [NotMapped]
    public virtual ICollection<SurveyQuestion> SurveyQuestions { get; set; } = new List<SurveyQuestion>();

    //[InverseProperty("Survey")]
    [NotMapped]
    public virtual ICollection<SurveyUserInputLine> SurveyUserInputLines { get; set; } = new List<SurveyUserInputLine>();

    //[InverseProperty("Survey")]
    [NotMapped]
    public virtual ICollection<SurveyUserInput> SurveyUserInputs { get; set; } = new List<SurveyUserInput>();

    [ForeignKey("UserId")]
    //[InverseProperty("SurveySurveyUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SurveySurveyWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("SurveySurveyId")]
    //[InverseProperty("SurveySurveys")]
    [NotMapped]
    public virtual ICollection<ResUser> ResUsers { get; set; } = new List<ResUser>();
}
