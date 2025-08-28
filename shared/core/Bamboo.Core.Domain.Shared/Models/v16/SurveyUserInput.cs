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

[Table("survey_user_input")]
//[Index("SurveyId", Name = "survey_user_input__survey_id_index")]
//[Index("AccessToken", Name = "survey_user_input_unique_token", IsUnique = true)]
public partial class SurveyUserInput: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("last_displayed_page_id")]
    public Guid? LastDisplayedPageId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("access_token")]
    public string? AccessToken { get; set; }

    [Column("invite_token")]
    public string? InviteToken { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("nickname")]
    public string? Nickname { get; set; }

    [Column("scoring_total")]
    public decimal? ScoringTotal { get; set; }

    [Column("test_entry")]
    public bool? TestEntry { get; set; }

    [Column("scoring_success")]
    public bool? ScoringSuccess { get; set; }

    [Column("survey_first_submitted")]
    public bool? SurveyFirstSubmitted { get; set; }

    [Column("is_session_answer")]
    public bool? IsSessionAnswer { get; set; }

    [Column("start_datetime", TypeName = "timestamp without time zone")]
    public DateTime? StartDatetime { get; set; }

    [Column("end_datetime", TypeName = "timestamp without time zone")]
    public DateTime? EndDatetime { get; set; }

    [Column("deadline", TypeName = "timestamp without time zone")]
    public DateTime? Deadline { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("scoring_percentage")]
    public double? ScoringPercentage { get; set; }

    [Column("slide_id")]
    public Guid? SlideId { get; set; }

    [Column("slide_partner_id")]
    public Guid? SlidePartnerId { get; set; }

    [Column("applicant_id")]
    public Guid? ApplicantId { get; set; }

    // [Many2one]
    [ForeignKey("ApplicantId")]
    public virtual HrApplicant? Applicant { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("LastDisplayedPageId")]
    public virtual SurveyQuestion? LastDisplayedPage { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("SlideId")]
    public virtual SlideSlide? Slide { get; set; }

    // [Many2one]
    [ForeignKey("SlidePartnerId")]
    public virtual SlideSlidePartner? SlidePartner { get; set; }

    // [Many2one]
    [ForeignKey("SurveyId")]
    public virtual SurveySurvey? Survey { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("UserInputId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("UserInput")] // One2many
    public virtual ICollection<SurveyUserInputLine> SurveyUserInputLine { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("SurveyUserInputId")] // Many2many // Normal
    // [InverseProperty("SurveyUserInput")] // Many2many // Normal
    public virtual ICollection<SurveyQuestion> SurveyQuestion { get; set; }
}
