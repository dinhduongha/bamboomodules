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
//[Index("DateLastStageUpdate", Name = "hr_applicant_date_last_stage_update_index")]
//[Index("JobId", Name = "hr_applicant_job_id_index")]
//[Index("StageId", Name = "hr_applicant_stage_id_index")]
public partial class HrApplicant: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

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
    
    // v16-Compat
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

    // v16-Compat
    [Column("type_id")]
    public Guid? TypeId { get; set; }

    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

    // v16-Compat
    [Column("color")]
    public long? Color { get; set; }

    // v16-Compat
    [Column("emp_id")]
    public Guid? EmpId { get; set; }

    [Column("refuse_reason_id")]
    public Guid? RefuseReasonId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("email_cc")]
    public string? EmailCc { get; set; }

    // v16-Compat
    [Column("name")]
    public string? Name { get; set; }

    // v16-Compat
    [Column("email_from")]
    public string? EmailFrom { get; set; }

    [Column("priority")]
    public string? Priority { get; set; }

    [Column("salary_proposed_extra")]
    public string? SalaryProposedExtra { get; set; }

    [Column("salary_expected_extra")]
    public string? SalaryExpectedExtra { get; set; }

    // v16-Compat
    [Column("partner_name")]
    public string? PartnerName { get; set; }

    // v16-Compat
    [Column("partner_phone")]
    public string? PartnerPhone { get; set; }

    // v16-Compat
    [Column("partner_mobile")]
    public string? PartnerMobile { get; set; }

    [Column("kanban_state")]
    public string? KanbanState { get; set; }

    [JsonField]
    [Column("applicant_properties", TypeName = "jsonb")]
    public string? ApplicantProperties { get; set; }

    [Column("applicant_notes")]
    public string? ApplicantNotes { get; set; }

    // v16-Compat
    [Column("linkedin_profile")]
    public string? LinkedinProfile { get; set; }

    // v16-Compat
    [Column("availability")]
    public DateTime? Availability { get; set; }

    // v16-Compat
    [Column("description")]
    public string? Description { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

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

    //[InverseProperty("Applicant")]
    // [NotMapped]
    // public virtual ICollection<CalendarEvent> CalendarEvents { get; set; } = new List<CalendarEvent>();

    [ForeignKey("CampaignId")]
    //[InverseProperty("HrApplicants")]
    [NotMapped]
    public virtual UtmCampaign? Campaign { get; set; }

    [ForeignKey("CandidateId")]
    //[InverseProperty("HrApplicants")]
    [NotMapped]
    public virtual HrCandidate? Candidate { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("HrApplicants")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrApplicantCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("DepartmentId")]
    //[InverseProperty("HrApplicants")]
    [NotMapped]
    public virtual HrDepartment? Department { get; set; }

    [ForeignKey("EmpId")]
    //[InverseProperty("HrApplicants")]
    [NotMapped]
    public virtual HrEmployee? Emp { get; set; }

    [ForeignKey("JobId")]
    //[InverseProperty("HrApplicants")]
    [NotMapped]
    public virtual HrJob? Job { get; set; }

    [ForeignKey("LastStageId")]
    //[InverseProperty("HrApplicantLastStages")]
    [NotMapped]
    public virtual HrRecruitmentStage? LastStage { get; set; }

    [ForeignKey("MediumId")]
    //[InverseProperty("HrApplicants")]
    [NotMapped]
    public virtual UtmMedium? Medium { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("HrApplicants")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("HrApplicants")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("RefuseReasonId")]
    //[InverseProperty("HrApplicants")]
    [NotMapped]
    public virtual HrApplicantRefuseReason? RefuseReason { get; set; }

    [ForeignKey("SourceId")]
    //[InverseProperty("HrApplicants")]
    [NotMapped]
    public virtual UtmSource? Source { get; set; }

    [ForeignKey("StageId")]
    //[InverseProperty("HrApplicantStages")]
    [NotMapped]
    public virtual HrRecruitmentStage? Stage { get; set; }

    [ForeignKey("TypeId")]
    //[InverseProperty("HrApplicants")]
    [NotMapped]
    public virtual HrRecruitmentDegree? Type { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("HrApplicantUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrApplicantWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Applicant")]
    [NotMapped]
    public virtual ICollection<CalendarEvent> CalendarEvents { get; set; } = new List<CalendarEvent>();

    //[InverseProperty("Applicant")]
    [NotMapped]
    public virtual ICollection<HrApplicantSkill> HrApplicantSkills { get; set; } = new List<HrApplicantSkill>();

    [ForeignKey("HrApplicantId")]
    //[InverseProperty("HrApplicants")]
    [NotMapped]
    public virtual ICollection<ApplicantGetRefuseReason> ApplicantGetRefuseReasons { get; set; } = new List<ApplicantGetRefuseReason>();

    [ForeignKey("HrApplicantId")]
    //[InverseProperty("HrApplicants")]
    [NotMapped]
    public virtual ICollection<ApplicantSendMail> ApplicantSendMails { get; set; } = new List<ApplicantSendMail>();

    [ForeignKey("HrApplicantId")]
    //[InverseProperty("HrApplicants")]
    [NotMapped]
    public virtual ICollection<HrApplicantCategory> HrApplicantCategories { get; set; } = new List<HrApplicantCategory>();

    [ForeignKey("HrApplicantId")]
    //[InverseProperty("HrApplicants")]
    [NotMapped]
    public virtual ICollection<HrSkill> HrSkills { get; set; } = new List<HrSkill>();

    [ForeignKey("HrApplicantId")]
    //[InverseProperty("HrApplicants")]
    [NotMapped]
    public virtual ICollection<ResUser> ResUsers { get; set; } = new List<ResUser>();
}
