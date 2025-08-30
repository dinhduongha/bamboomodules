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

//[Table("mail_message")]
//[Index("AuthorId", Name = "mail_message__author_id_index")]
//[Index("MailActivityTypeId", Name = "mail_message_mail_activity_type_id_index")]
//[Index("MessageId", Name = "mail_message__message_id_index")]
//[Index("SubtypeId", Name = "mail_message__subtype_id_index")]
//[Index("Model", "ResId", "Id", Name = "mail_message_model_res_id_id_idx")]
//[Index("Model", "ResId", Name = "mail_message_model_res_id_idx")]
public partial class MailMessage
{
    // v16-Compat    
    // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ParentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Parent")] // One2many
    // public virtual ICollection<MailMessage> InverseParent { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("FetchedMessageId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("FetchedMessage")] // One2many
    public virtual ICollection<MailChannelMember> MailChannelMemberFetchedMessage { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SeenMessageId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("SeenMessage")] // One2many
    public virtual ICollection<MailChannelMember> MailChannelMemberSeenMessage { get; set; }
}
