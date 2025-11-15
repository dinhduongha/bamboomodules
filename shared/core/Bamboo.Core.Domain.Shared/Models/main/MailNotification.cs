using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

[Table("mail_notification")]
//[Index("IsRead", Name = "mail_notification__is_read_index")]
//[Index("MailMailId", Name = "mail_notification__mail_mail_id_index")]
//[Index("MailMessageId", Name = "mail_notification__mail_message_id_index")]
//[Index("NotificationStatus", Name = "mail_notification__notification_status_index")]
//[Index("NotificationType", Name = "mail_notification__notification_type_index")]
//[Index("ResPartnerId", Name = "mail_notification__res_partner_id_index")]
//[Index("ResPartnerId", "IsRead", "NotificationStatus", "MailMessageId", Name = "mail_notification_res_partner_id_is_read_notification_status_ma")]
public partial class MailNotification : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

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

    [Column("sms_number")]
    public string? SmsNumber { get; set; }

    [Column("letter_id")]
    public Guid? LetterId { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AuthorId")]
    public virtual ResPartner? Author { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LetterId")]
    public virtual SnailmailLetter? Letter { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("MailMailId")]
    public virtual MailMail? MailMail { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("MailMessageId")]
    public virtual MailMessage? MailMessage { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("NotificationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Notification")] // One2many
    public virtual ICollection<MailResendPartner> MailResendPartner { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ResPartnerId")]
    public virtual ResPartner? ResPartner { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("NotificationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Notification")] // One2many
    public virtual ICollection<SmsResendRecipient> SmsResendRecipient { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MailNotificationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailNotification")] // One2many
    public virtual ICollection<SmsTracker> SmsTracker { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("MailNotificationId")] //Many2many // Hidden
    // [InverseProperty("MailNotification")] //Many2many // Hidden
    public virtual ICollection<MailResendMessage> MailResendMessage { get; set; }
}
