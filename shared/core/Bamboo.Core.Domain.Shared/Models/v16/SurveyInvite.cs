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

    [Column("template_id")]
    public Guid? TemplateId { get; set; }

    [Column("author_id")]
    public Guid? AuthorId { get; set; }

    [Column("mail_server_id")]
    public Guid? MailServerId { get; set; }

    [Column("survey_id")]
    public Guid? SurveyId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

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
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("AuthorId")]
    //[InverseProperty("SurveyInvites")]
    [NotMapped]
    public virtual ResPartner? Author { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SurveyInviteCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MailServerId")]
    //[InverseProperty("SurveyInvites")]
    [NotMapped]
    public virtual IrMailServer? MailServer { get; set; }

    [ForeignKey("SurveyId")]
    //[InverseProperty("SurveyInvites")]
    [NotMapped]
    public virtual SurveySurvey? Survey { get; set; }

    [ForeignKey("TemplateId")]
    //[InverseProperty("SurveyInvites")]
    [NotMapped]
    public virtual MailTemplate? Template { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SurveyInviteWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("WizardId")]
    //[InverseProperty("Wizards1")]
    [NotMapped]
    public virtual ICollection<IrAttachment> Attachments { get; set; } = new List<IrAttachment>();

    [ForeignKey("InviteId")]
    //[InverseProperty("Invites")]
    [NotMapped]
    public virtual ICollection<ResPartner> Partners { get; set; } = new List<ResPartner>();
}
