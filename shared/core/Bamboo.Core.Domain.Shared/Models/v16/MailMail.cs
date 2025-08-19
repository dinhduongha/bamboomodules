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

[Table("mail_mail")]
//[Index("MailMessageId", Name = "mail_mail__mail_message_id_index")]
public partial class MailMail: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("mail_message_id")]
    public Guid? MailMessageId { get; set; }

    [Column("fetchmail_server_id")]
    public Guid? FetchmailServerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("email_cc")]
    public string? EmailCc { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("failure_type")]
    public string? FailureType { get; set; }

    [Column("body_html")]
    public string? BodyHtml { get; set; }

    [Column("references")]
    public string? References { get; set; }

    [Column("headers")]
    public string? Headers { get; set; }

    [Column("email_to")]
    public string? EmailTo { get; set; }

    [Column("failure_reason")]
    public string? FailureReason { get; set; }

    [Column("is_notification")]
    public bool? IsNotification { get; set; }

    [Column("auto_delete")]
    public bool? AutoDelete { get; set; }

    [Column("to_delete")]
    public bool? ToDelete { get; set; }

    [Column("scheduled_date", TypeName = "timestamp without time zone")]
    public DateTime? ScheduledDate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("mailing_id")]
    public Guid? MailingId { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("MailMailCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("FetchmailServerId")]
    // [InverseProperty("MailMail")] //Many2one
    public virtual FetchmailServer? FetchmailServer { get; set; }

    // [Many2one]
    [ForeignKey("MailMessageId")]
    // [InverseProperty("MailMail")] //Many2one
    public virtual MailMessage? MailMessage { get; set; }

    // [One2many]
    [ForeignKey("MailMailId")]
    [InverseProperty("MailMail")]
    public virtual ICollection<MailNotification> MailNotification { get; set; }

    // [Many2one]
    [ForeignKey("MailingId")]
    // [InverseProperty("MailMail")] //Many2one
    public virtual MailingMailing? Mailing { get; set; }

    // [One2many]
    [ForeignKey("MailMailId")]
    [InverseProperty("MailMail")]
    public virtual ICollection<MailingTrace> MailingTrace { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("MailMailWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("MailMailId")] //Many2many
    // [InverseProperty("MailMail")] //Many2many
    public virtual ICollection<ResPartner> ResPartner { get; set; }
}
