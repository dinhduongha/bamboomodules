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

//[Table("sms_sms")]
//[Index("MailMessageId", Name = "sms_sms__mail_message_id_index")]
public partial class SmsSms
{
    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SmsId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Sms")] // One2many
    public virtual ICollection<MailNotification> MailNotification { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SmsSmsId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("SmsSms")] // One2many
    public virtual ICollection<MailingTrace> MailingTrace { get; set; }
}
