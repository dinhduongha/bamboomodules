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
public partial class HrCandidate: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

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
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many]
    [ForeignKey("CandidateId")]
    [InverseProperty("Candidate")]
    public virtual ICollection<CalendarEvent> CalendarEvent { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("HrCandidate")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("HrCandidateCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("EmployeeId")]
    // [InverseProperty("HrCandidate")] //Many2one
    public virtual HrEmployee? Employee { get; set; }

    // [One2many]
    [ForeignKey("CandidateId")]
    [InverseProperty("Candidate")]
    public virtual ICollection<HrApplicant> HrApplicant { get; set; }

    // [One2many]
    [ForeignKey("CandidateId")]
    [InverseProperty("Candidate")]
    public virtual ICollection<HrCandidateSkill> HrCandidateSkill { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("HrCandidate")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("HrCandidate")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("TypeId")]
    // [InverseProperty("HrCandidate")] //Many2one
    public virtual HrRecruitmentDegree? Type { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("HrCandidateUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("HrCandidateWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [ForeignKey("HrCandidateId")] //Many2many
    // [InverseProperty("HrCandidate")] //Many2many
    [NotMapped] //Many2many // Hidden
    public virtual ICollection<CandidateSendMail> CandidateSendMail { get; set; }

    // [Many2many] // Normal
    // [ForeignKey("HrCandidateId")] //Many2many
    [InverseProperty("HrCandidate")] //Many2many
    // [NotMapped] //Many2many // Normal
    public virtual ICollection<HrApplicantCategory> HrApplicantCategory { get; set; }

    // [Many2many] // Normal
    // [ForeignKey("HrCandidateId")] //Many2many
    [InverseProperty("HrCandidate")] //Many2many
    // [NotMapped] //Many2many // Normal
    public virtual ICollection<HrSkill> HrSkill { get; set; }
}
