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

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("stage_id")]
    public Guid? StageId { get; set; }

    [Column("last_stage_id")]
    public Guid? LastStageId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("job_id")]
    public Guid? JobId { get; set; }

    [Column("type_id")]
    public Guid? TypeId { get; set; }

    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("emp_id")]
    public Guid? EmpId { get; set; }

    [Column("refuse_reason_id")]
    public Guid? RefuseReasonId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("email_cc")]
    public string? EmailCc { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("email_from")]
    public string? EmailFrom { get; set; }

    [Column("priority")]
    public string? Priority { get; set; }

    [Column("salary_proposed_extra")]
    public string? SalaryProposedExtra { get; set; }

    [Column("salary_expected_extra")]
    public string? SalaryExpectedExtra { get; set; }

    [Column("partner_name")]
    public string? PartnerName { get; set; }

    [Column("partner_phone")]
    public string? PartnerPhone { get; set; }

    [Column("partner_mobile")]
    public string? PartnerMobile { get; set; }

    [Column("kanban_state")]
    public string? KanbanState { get; set; }

    [JsonField]
    [Column("applicant_properties", TypeName = "jsonb")]
    public string? ApplicantProperties { get; set; }

    [Column("applicant_notes")]
    public string? ApplicantNotes { get; set; }


    [Column("linkedin_profile")]
    public string? LinkedinProfile { get; set; }

    [Column("availability")]
    public DateTime? Availability { get; set; }

    [Column("description")]
    public string? Description { get; set; }

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

    [Column("response_id")]
    public Guid? ResponseId { get; set; }

    // [One2many]
    [ForeignKey("ApplicantId")]
    [InverseProperty("Applicant")]
    public virtual ICollection<CalendarEvent> CalendarEvent { get; set; }

    // [Many2one]
    [ForeignKey("CampaignId")]
    // [InverseProperty("HrApplicant")] //Many2one
    public virtual UtmCampaign? Campaign { get; set; }

    // [Many2one]
    [ForeignKey("CandidateId")]
    // [InverseProperty("HrApplicant")] //Many2one
    public virtual HrCandidate? Candidate { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("HrApplicant")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("HrApplicantCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("DepartmentId")]
    // [InverseProperty("HrApplicant")] //Many2one
    public virtual HrDepartment? Department { get; set; }

    // [Many2one]
    [ForeignKey("EmpId")]
    // [InverseProperty("HrApplicant")] //Many2one
    public virtual HrEmployee? Emp { get; set; }

    // [One2many]
    [ForeignKey("ApplicantId")]
    [InverseProperty("Applicant")]
    public virtual ICollection<HrApplicantSkill> HrApplicantSkill { get; set; }

    // [Many2one]
    [ForeignKey("JobId")]
    // [InverseProperty("HrApplicant")] //Many2one
    public virtual HrJob? Job { get; set; }

    // [Many2one]
    [ForeignKey("LastStageId")]
    // [InverseProperty("HrApplicantLastStage")] //Many2one
    public virtual HrRecruitmentStage? LastStage { get; set; }

    // [Many2one]
    [ForeignKey("MediumId")]
    // [InverseProperty("HrApplicant")] //Many2one
    public virtual UtmMedium? Medium { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("HrApplicant")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("HrApplicant")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("RefuseReasonId")]
    // [InverseProperty("HrApplicant")] //Many2one
    public virtual HrApplicantRefuseReason? RefuseReason { get; set; }

    // [Many2one]
    [ForeignKey("ResponseId")]
    // [InverseProperty("HrApplicant")] //Many2one
    public virtual SurveyUserInput? Response { get; set; }

    // [Many2one]
    [ForeignKey("SourceId")]
    // [InverseProperty("HrApplicant")] //Many2one
    public virtual UtmSource? Source { get; set; }

    // [Many2one]
    [ForeignKey("StageId")]
    // [InverseProperty("HrApplicantStage")] //Many2one
    public virtual HrRecruitmentStage? Stage { get; set; }

    // [One2many]
    [ForeignKey("ApplicantId")]
    [InverseProperty("Applicant")]
    public virtual ICollection<SurveyInvite> SurveyInvite { get; set; }

    // [One2many]
    [ForeignKey("ApplicantId")]
    [InverseProperty("Applicant")]
    public virtual ICollection<SurveyUserInput> SurveyUserInput { get; set; }

    // [Many2one]
    [ForeignKey("TypeId")]
    // [InverseProperty("HrApplicant")] //Many2one
    public virtual HrRecruitmentDegree? Type { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("HrApplicantUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("HrApplicantWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrApplicantId")]
    // [InverseProperty("HrApplicant")]
    public virtual ICollection<ApplicantGetRefuseReason> ApplicantGetRefuseReason { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrApplicantId")]
    // [InverseProperty("HrApplicant")]
    public virtual ICollection<ApplicantSendMail> ApplicantSendMail { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("HrApplicantId")] //Many2many
    // [InverseProperty("HrApplicant")] //Many2many
    public virtual ICollection<HrApplicantCategory> HrApplicantCategory { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("HrApplicantId")] //Many2many
    // [InverseProperty("HrApplicant")] //Many2many
    public virtual ICollection<HrSkill> HrSkill { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("HrApplicantId")] //Many2many
    // [InverseProperty("HrApplicant")] //Many2many
    public virtual ICollection<ResUsers> ResUsers { get; set; }
}
