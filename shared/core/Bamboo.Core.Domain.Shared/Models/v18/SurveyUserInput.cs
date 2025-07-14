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
public partial class SurveyUserInput: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("survey_id")]
    public Guid? SurveyId { get; set; }

    [Column("last_displayed_page_id")]
    public Guid? LastDisplayedPageId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("scoring_percentage")]
    public double? ScoringPercentage { get; set; }

    [Column("slide_id")]
    public Guid? SlideId { get; set; }

    [Column("slide_partner_id")]
    public Guid? SlidePartnerId { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SurveyUserInputCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastDisplayedPageId")]
    //[InverseProperty("SurveyUserInputsNavigation")]
    [NotMapped]
    public virtual SurveyQuestion? LastDisplayedPage { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("SurveyUserInputs")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("SlideId")]
    //[InverseProperty("SurveyUserInputs")]
    [NotMapped]
    public virtual SlideSlide? Slide { get; set; }

    [ForeignKey("SlidePartnerId")]
    //[InverseProperty("SurveyUserInputs")]
    [NotMapped]
    public virtual SlideSlidePartner? SlidePartner { get; set; }

    [ForeignKey("SurveyId")]
    //[InverseProperty("SurveyUserInputs")]
    [NotMapped]
    public virtual SurveySurvey? Survey { get; set; }

    //[InverseProperty("UserInput")]
    [NotMapped]
    public virtual ICollection<SurveyUserInputLine> SurveyUserInputLines { get; set; } = new List<SurveyUserInputLine>();

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SurveyUserInputWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("SurveyUserInputId")]
    //[InverseProperty("SurveyUserInputs")]
    [NotMapped]
    public virtual ICollection<SurveyQuestion> SurveyQuestions { get; set; } = new List<SurveyQuestion>();
}
