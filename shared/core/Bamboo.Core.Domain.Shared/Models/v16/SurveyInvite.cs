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

[Table("survey_invite")]
//[Index("AuthorId", Name = "survey_invite__author_id_index")]
public partial class SurveyInvite: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("template_id")]
    public Guid? TemplateId { get; set; }

    [Column("author_id")]
    public Guid? AuthorId { get; set; }

    [Column("mail_server_id")]
    public Guid? MailServerId { get; set; }

    [Column("survey_id")]
    public Guid? SurveyId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("lang")]
    public string? Lang { get; set; }

    [Column("subject")]
    public string? Subject { get; set; }

    [Column("email_from")]
    public string? EmailFrom { get; set; }

    [Column("existing_mode")]
    public string? ExistingMode { get; set; }

    [Column("body")]
    public string? Body { get; set; }

    [Column("emails")]
    public string? Emails { get; set; }

    [Column("deadline", TypeName = "timestamp without time zone")]
    public DateTime? Deadline { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("applicant_id")]
    public Guid? ApplicantId { get; set; }

    // [Many2one]
    [ForeignKey("ApplicantId")]
    // [InverseProperty("SurveyInvite")] //Many2one
    public virtual HrApplicant? Applicant { get; set; }

    // [Many2one]
    [ForeignKey("AuthorId")]
    // [InverseProperty("SurveyInvite")] //Many2one
    public virtual ResPartner? Author { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("SurveyInviteCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("MailServerId")]
    // [InverseProperty("SurveyInvite")] //Many2one
    public virtual IrMailServer? MailServer { get; set; }

    // [Many2one]
    [ForeignKey("SurveyId")]
    // [InverseProperty("SurveyInvite")] //Many2one
    public virtual SurveySurvey? Survey { get; set; }

    // [Many2one]
    [ForeignKey("TemplateId")]
    // [InverseProperty("SurveyInvite")] //Many2one
    public virtual MailTemplate? Template { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("SurveyInviteWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("WizardId")] //Many2many
    // [InverseProperty("WizardNavigation")] //Many2many
    // [InverseProperty("Wizard1")] //Many2many
    public virtual ICollection<IrAttachment> Attachment { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("InviteId")] //Many2many
    // [InverseProperty("Invite")] //Many2many
    public virtual ICollection<ResPartner> Partner { get; set; }
}
