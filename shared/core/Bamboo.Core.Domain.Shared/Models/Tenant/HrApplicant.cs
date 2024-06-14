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
public partial class HrApplicant: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("campaign_id")]
    public Guid? CampaignId { get; set; }

    [Column("source_id")]
    public Guid? SourceId { get; set; }

    [Column("medium_id")]
    public Guid? MediumId { get; set; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("stage_id")]
    public long? StageId { get; set; }

    [Column("last_stage_id")]
    public long? LastStageId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("job_id")]
    public Guid? JobId { get; set; }

    [Column("type_id")]
    public long? TypeId { get; set; }

    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("emp_id")]
    public Guid? EmpId { get; set; }

    [Column("refuse_reason_id")]
    public Guid? RefuseReasonId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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

    [Column("linkedin_profile")]
    public string? LinkedinProfile { get; set; }

    [Column("availability")]
    public DateTime? Availability { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("date_closed", TypeName = "timestamp without time zone")]
    public DateTime? DateClosed { get; set; }

    [Column("date_open", TypeName = "timestamp without time zone")]
    public DateTime? DateOpen { get; set; }

    [Column("date_last_stage_update", TypeName = "timestamp without time zone")]
    public DateTime? DateLastStageUpdate { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("probability")]
    public double? Probability { get; set; }

    [Column("salary_proposed")]
    public double? SalaryProposed { get; set; }

    [Column("salary_expected")]
    public double? SalaryExpected { get; set; }

    [Column("delay_close")]
    public double? DelayClose { get; set; }

    [ForeignKey("CampaignId")]
    //[InverseProperty("HrApplicants")]
    [NotMapped]
    public virtual UtmCampaign? Campaign { get; set; }

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
    public virtual ICollection<CalendarEvent> CalendarEvents { get; } = new List<CalendarEvent>();

    //[InverseProperty("Applicant")]
    [NotMapped]
    public virtual ICollection<HrApplicantSkill> HrApplicantSkills { get; } = new List<HrApplicantSkill>();

    [ForeignKey("HrApplicantId")]
    //[InverseProperty("HrApplicants")]
    [NotMapped]
    public virtual ICollection<ApplicantGetRefuseReason> ApplicantGetRefuseReasons { get; } = new List<ApplicantGetRefuseReason>();

    [ForeignKey("HrApplicantId")]
    //[InverseProperty("HrApplicants")]
    [NotMapped]
    public virtual ICollection<ApplicantSendMail> ApplicantSendMails { get; } = new List<ApplicantSendMail>();

    [ForeignKey("HrApplicantId")]
    //[InverseProperty("HrApplicants")]
    [NotMapped]
    public virtual ICollection<HrApplicantCategory> HrApplicantCategories { get; } = new List<HrApplicantCategory>();

    [ForeignKey("HrApplicantId")]
    //[InverseProperty("HrApplicants")]
    [NotMapped]
    public virtual ICollection<HrSkill> HrSkills { get; } = new List<HrSkill>();

    [ForeignKey("HrApplicantId")]
    //[InverseProperty("HrApplicants")]
    [NotMapped]
    public virtual ICollection<ResUser> ResUsers { get; } = new List<ResUser>();
}
