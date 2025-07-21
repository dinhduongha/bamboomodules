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

[Table("hr_candidate")]
//[Index("Active", Name = "hr_candidate__active_index")]
//[Index("EmailNormalized", "PartnerPhoneSanitized", Name = "hr_candidate_email_partner_phone_mobile")]
public partial class HrCandidate: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("message_bounce")]
    public long? MessageBounce { get; set; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("type_id")]
    public Guid? TypeId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("phone_sanitized")]
    public string? PhoneSanitized { get; set; }

    [Column("email_normalized")]
    public string? EmailNormalized { get; set; }

    [Column("email_cc")]
    public string? EmailCc { get; set; }

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

    [Column("priority")]
    public string? Priority { get; set; }

    [Column("availability")]
    public DateTime? Availability { get; set; }

    [JsonField]
    [Column("candidate_properties", TypeName = "jsonb")]
    public string? CandidateProperties { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    //[InverseProperty("Candidate")]
    [NotMapped]
    public virtual ICollection<CalendarEvent> CalendarEvents { get; set; } = new List<CalendarEvent>();

    [ForeignKey("CompanyId")]
    //[InverseProperty("HrCandidates")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrCandidateCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("EmployeeId")]
    //[InverseProperty("HrCandidates")]
    [NotMapped]
    public virtual HrEmployee? Employee { get; set; }

    //[InverseProperty("Candidate")]
    [NotMapped]
    public virtual ICollection<HrApplicant> HrApplicants { get; set; } = new List<HrApplicant>();

    //[InverseProperty("Candidate")]
    [NotMapped]
    public virtual ICollection<HrCandidateSkill> HrCandidateSkills { get; set; } = new List<HrCandidateSkill>();

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("HrCandidates")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("HrCandidates")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("TypeId")]
    //[InverseProperty("HrCandidates")]
    [NotMapped]
    public virtual HrRecruitmentDegree? Type { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("HrCandidateUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrCandidateWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("HrCandidateId")]
    //[InverseProperty("HrCandidates")]
    [NotMapped]
    public virtual ICollection<CandidateSendMail> CandidateSendMails { get; set; } = new List<CandidateSendMail>();

    [ForeignKey("HrCandidateId")]
    //[InverseProperty("HrCandidates")]
    [NotMapped]
    public virtual ICollection<HrApplicantCategory> HrApplicantCategories { get; set; } = new List<HrApplicantCategory>();

    [ForeignKey("HrCandidateId")]
    //[InverseProperty("HrCandidates")]
    [NotMapped]
    public virtual ICollection<HrSkill> HrSkills { get; set; } = new List<HrSkill>();
}
