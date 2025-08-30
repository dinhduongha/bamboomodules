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

//[Table("chatbot_message")]
//[Index("MailMessageId", Name = "chatbot_message__unique_mail_message_id", IsUnique = true)]
public partial class ChatbotMessage
{
    [Column("mail_channel_id")]
    public Guid? MailChannelId { get; set; }

    // [Many2one]
    [ForeignKey("MailChannelId")]
    public virtual MailChannel? MailChannel { get; set; }

}
