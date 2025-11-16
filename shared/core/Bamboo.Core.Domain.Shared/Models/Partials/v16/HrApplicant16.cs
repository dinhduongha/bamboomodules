using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("hr_applicant")]
//[Index("DateLastStageUpdate", Name = "hr_applicant__date_last_stage_update_index")]
//[Index("JobId", Name = "hr_applicant__job_id_index")]
//[Index("StageId", Name = "hr_applicant__stage_id_index")]
public partial class HrApplicant16
{
    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("type_id")]
    public Guid? TypeId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("emp_id")]
    public Guid? EmpId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("email_from")]
    public string? EmailFrom { get; set; }

    [Column("partner_name")]
    public string? PartnerName { get; set; }

    [Column("partner_phone")]
    public string? PartnerPhone { get; set; }

    [Column("partner_mobile")]
    public string? PartnerMobile { get; set; }

    [Column("linkedin_profile")]
    public string? LinkedinProfile { get; set; }

    [Column("availability")]
    public DateTime? Availability { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("response_id")]
    public Guid? ResponseId { get; set; }

    // [Many2one]
    [ForeignKey("EmpId")]
    public virtual HrEmployee? Emp { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ApplicantId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Applicant")] // One2many
    public virtual ICollection<HrApplicantSkill> HrApplicantSkill { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("ResponseId")]
    public virtual SurveyUserInput? Response { get; set; }

    // [Many2one]
    [ForeignKey("TypeId")]
    public virtual HrRecruitmentDegree? Type { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("HrApplicantId")] // Many2many // Normal
    // [InverseProperty("HrApplicant")] // Many2many // Normal
    public virtual ICollection<HrSkill> HrSkill { get; set; }
}
