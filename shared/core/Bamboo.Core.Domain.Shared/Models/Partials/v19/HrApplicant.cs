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

public partial class HrApplicant
{
    [Column("message_bounce")]
    public long? MessageBounce { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("type_id")]
    public Guid? TypeId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("pool_applicant_id")]
    public Guid? PoolApplicantId { get; set; }

    [Column("phone_sanitized")]
    public string? PhoneSanitized { get; set; }

    [Column("email_normalized")]
    public string? EmailNormalized { get; set; }

    [Column("partner_name")]
    public string? PartnerName { get; set; }

    [Column("email_from")]
    public string? EmailFrom { get; set; }

    [Column("partner_phone")]
    public string? PartnerPhone { get; set; }

    [Column("partner_phone_sanitized")]
    public string? PartnerPhoneSanitized { get; set; }

    [Column("linkedin_profile")]
    public string? LinkedinProfile { get; set; }

    [Column("availability")]
    public DateTime? Availability { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("EmployeeId")]
    public virtual HrEmployee? Employee { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ApplicantId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Applicant")] // One2many
    public virtual ICollection<HrApplicantSkill> HrApplicantSkill { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PoolApplicantId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PoolApplicant")] // One2many
    public virtual ICollection<HrApplicant> InversePoolApplicant { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PoolApplicantId")]
    public virtual HrApplicant? PoolApplicant { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TypeId")]
    public virtual HrRecruitmentDegree? Type { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrApplicantId")] //Many2many // Hidden
    // [InverseProperty("HrApplicantNavigation")] //Many2many // Hidden
    public virtual ICollection<ApplicantGetRefuseReason> ApplicantGetRefuseReasonNavigation { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("HrApplicantId")] // Many2many // Normal
    // [InverseProperty("HrApplicant")] // Many2many // Normal
    public virtual ICollection<HrSkill> HrSkill { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("HrApplicantId")] // Many2many // Normal
    // [InverseProperty("HrApplicant")] // Many2many // Normal
    public virtual ICollection<HrTalentPool> HrTalentPool { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrApplicantId")] //Many2many // Hidden
    // [InverseProperty("HrApplicant")] //Many2many // Hidden
    public virtual ICollection<JobAddApplicants> JobAddApplicants { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrApplicantId")] //Many2many // Hidden
    // [InverseProperty("HrApplicant")] //Many2many // Hidden
    public virtual ICollection<TalentPoolAddApplicants> TalentPoolAddApplicants { get; set; }

}