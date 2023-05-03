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
//[Index("MailMessageId", Name = "mail_mail_mail_message_id_index")]
public partial class MailMail: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("mail_message_id")]
    public Guid? MailMessageId { get; set; }

    [Column("fetchmail_server_id")]
    public Guid? FetchmailServerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailMailCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("FetchmailServerId")]
    //[InverseProperty("MailMails")]
    [NotMapped]
    public virtual FetchmailServer? FetchmailServer { get; set; }

    [ForeignKey("MailMessageId")]
    //[InverseProperty("MailMails")]
    [NotMapped]
    public virtual MailMessage? MailMessage { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailMailWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("MailMail")]
    [NotMapped]
    public virtual ICollection<MailNotification> MailNotifications { get; } = new List<MailNotification>();

    [ForeignKey("MailMailId")]
    //[InverseProperty("MailMails")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartners { get; } = new List<ResPartner>();
}
