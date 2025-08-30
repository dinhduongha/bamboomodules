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

[Table("hr_applicant")]
//[Index("Active", Name = "hr_applicant__active_index")]
//[Index("CandidateId", Name = "hr_applicant__candidate_id_index")]
//[Index("DateLastStageUpdate", Name = "hr_applicant__date_last_stage_update_index")]
//[Index("JobId", Name = "hr_applicant__job_id_index")]
//[Index("StageId", Name = "hr_applicant__stage_id_index")]
public partial class HrApplicant: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("campaign_id")]
    public Guid? CampaignId { get; set; }

    [Column("source_id")]
    public Guid? SourceId { get; set; }

    [Column("medium_id")]
    public Guid? MediumId { get; set; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("candidate_id")]
    public Guid? CandidateId { get; set; }

    [Column("stage_id")]
    public Guid? StageId { get; set; }

    [Column("last_stage_id")]
    public Guid? LastStageId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("job_id")]
    public Guid? JobId { get; set; }

    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

    [Column("refuse_reason_id")]
    public Guid? RefuseReasonId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("email_cc")]
    public string? EmailCc { get; set; }

    [Column("priority")]
    public string? Priority { get; set; }

    [Column("salary_proposed_extra")]
    public string? SalaryProposedExtra { get; set; }

    [Column("salary_expected_extra")]
    public string? SalaryExpectedExtra { get; set; }

    [Column("kanban_state")]
    public string? KanbanState { get; set; }

    [JsonField] // ApplicantProperties
    [Column("applicant_properties", TypeName = "jsonb")]
    public JsonElement? ApplicantProperties { get; set; }

    [Column("applicant_notes")]
    public string? ApplicantNotes { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("date_closed", TypeName = "timestamp without time zone")]
    public DateTime? DateClosed { get; set; }

    [Column("date_open", TypeName = "timestamp without time zone")]
    public DateTime? DateOpen { get; set; }

    [Column("date_last_stage_update", TypeName = "timestamp without time zone")]
    public DateTime? DateLastStageUpdate { get; set; }

    [Column("refuse_date", TypeName = "timestamp without time zone")]
    public DateTime? RefuseDate { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("probability")]
    public double? Probability { get; set; }

    [Column("salary_proposed")]
    public double? SalaryProposed { get; set; }

    [Column("salary_expected")]
    public double? SalaryExpected { get; set; }

    [Column("delay_close")]
    public double? DelayClose { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ApplicantId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Applicant")] // One2many
    public virtual ICollection<CalendarEvent> CalendarEvent { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CampaignId")]
    public virtual UtmCampaign? Campaign { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CandidateId")]
    public virtual HrCandidate? Candidate { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("DepartmentId")]
    public virtual HrDepartment? Department { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("JobId")]
    public virtual HrJob? Job { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastStageId")]
    public virtual HrRecruitmentStage? LastStage { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("MediumId")]
    public virtual UtmMedium? Medium { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("RefuseReasonId")]
    public virtual HrApplicantRefuseReason? RefuseReason { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SourceId")]
    public virtual UtmSource? Source { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("StageId")]
    public virtual HrRecruitmentStage? Stage { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ApplicantId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Applicant")] // One2many
    public virtual ICollection<SurveyInvite> SurveyInvite { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ApplicantId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Applicant")] // One2many
    public virtual ICollection<SurveyUserInput> SurveyUserInput { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrApplicantId")] //Many2many // Hidden
    // [InverseProperty("HrApplicant")] //Many2many // Hidden
    public virtual ICollection<ApplicantGetRefuseReason> ApplicantGetRefuseReason { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrApplicantId")] //Many2many // Hidden
    // [InverseProperty("HrApplicant")] //Many2many // Hidden
    public virtual ICollection<ApplicantSendMail> ApplicantSendMail { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("HrApplicantId")] // Many2many // Normal
    // [InverseProperty("HrApplicant")] // Many2many // Normal
    public virtual ICollection<HrApplicantCategory> HrApplicantCategory { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (ResUsers) is commented out
    // [ForeignKey("HrApplicantId")] // Many2many // Normal
    // [InverseProperty("HrApplicant")] // Many2many // Normal
    public virtual ICollection<ResUsers> ResUsers { get; set; }
}
