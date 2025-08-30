using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("mail_notification")]
//[Index("IsRead", Name = "mail_notification__is_read_index")]
//[Index("MailMailId", Name = "mail_notification__mail_mail_id_index")]
//[Index("MailMessageId", Name = "mail_notification__mail_message_id_index")]
//[Index("NotificationStatus", Name = "mail_notification__notification_status_index")]
//[Index("NotificationType", Name = "mail_notification__notification_type_index")]
//[Index("ResPartnerId", Name = "mail_notification__res_partner_id_index")]
//[Index("ResPartnerId", "IsRead", "NotificationStatus", "MailMessageId", Name = "mail_notification_res_partner_id_is_read_notification_status_ma")]
public partial class MailNotification
{
    [Column("sms_id")]
    public Guid? SmsId { get; set; }

    // [Many2one]
    [ForeignKey("SmsId")]
    public virtual SmsSms? Sms { get; set; }
}
