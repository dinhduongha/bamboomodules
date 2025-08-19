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

[Table("mail_notification")]
//[Index("IsRead", Name = "mail_notification__is_read_index")]
//[Index("MailMailId", Name = "mail_notification__mail_mail_id_index")]
//[Index("MailMessageId", Name = "mail_notification__mail_message_id_index")]
//[Index("NotificationStatus", Name = "mail_notification__notification_status_index")]
//[Index("NotificationType", Name = "mail_notification__notification_type_index")]
//[Index("ResPartnerId", Name = "mail_notification__res_partner_id_index")]
//[Index("ResPartnerId", "IsRead", "NotificationStatus", "MailMessageId", Name = "mail_notification_res_partner_id_is_read_notification_status_ma")]
public partial class MailNotification: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("author_id")]
    public Guid? AuthorId { get; set; }

    [Column("mail_message_id")]
    public Guid? MailMessageId { get; set; }

    [Column("mail_mail_id")]
    public Guid? MailMailId { get; set; }

    [Column("res_partner_id")]
    public Guid? ResPartnerId { get; set; }

    [Column("notification_type")]
    public string? NotificationType { get; set; }

    [Column("notification_status")]
    public string? NotificationStatus { get; set; }

    [Column("failure_type")]
    public string? FailureType { get; set; }

    [Column("failure_reason")]
    public string? FailureReason { get; set; }

    [Column("is_read")]
    public bool? IsRead { get; set; }

    [Column("read_date", TypeName = "timestamp without time zone")]
    public DateTime? ReadDate { get; set; }

    [Column("sms_id_int")]
    public Guid? SmsIdInt { get; set; }

    [Column("sms_id")]
    public Guid? SmsId { get; set; }

    [Column("sms_number")]
    public string? SmsNumber { get; set; }

    [Column("letter_id")]
    public Guid? LetterId { get; set; }

    // [Many2one]
    [ForeignKey("AuthorId")]
    // [InverseProperty("MailNotificationAuthor")] //Many2one
    public virtual ResPartner? Author { get; set; }

    // [Many2one]
    [ForeignKey("LetterId")]
    // [InverseProperty("MailNotification")] //Many2one
    public virtual SnailmailLetter? Letter { get; set; }

    // [Many2one]
    [ForeignKey("MailMailId")]
    // [InverseProperty("MailNotification")] //Many2one
    public virtual MailMail? MailMail { get; set; }

    // [Many2one]
    [ForeignKey("MailMessageId")]
    // [InverseProperty("MailNotification")] //Many2one
    public virtual MailMessage? MailMessage { get; set; }

    // [One2many]
    [ForeignKey("NotificationId")]
    [InverseProperty("Notification")]
    public virtual ICollection<MailResendPartner> MailResendPartner { get; set; }

    // [Many2one]
    [ForeignKey("ResPartnerId")]
    // [InverseProperty("MailNotificationResPartner")] //Many2one
    public virtual ResPartner? ResPartner { get; set; }

    // [Many2one]
    [ForeignKey("SmsId")]
    // [InverseProperty("MailNotification")] //Many2one
    public virtual SmsSms? Sms { get; set; }

    // [One2many]
    [ForeignKey("NotificationId")]
    [InverseProperty("Notification")]
    public virtual ICollection<SmsResendRecipient> SmsResendRecipient { get; set; }

    // [One2many]
    [ForeignKey("MailNotificationId")]
    [InverseProperty("MailNotification")]
    public virtual ICollection<SmsTracker> SmsTracker { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("MailNotificationId")]
    // [InverseProperty("MailNotification")]
    public virtual ICollection<MailResendMessage> MailResendMessage { get; set; }
}
