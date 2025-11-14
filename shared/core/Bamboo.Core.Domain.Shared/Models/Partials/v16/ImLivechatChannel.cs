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

//[Table("im_livechat_channel")]
//[Index("IsPublished", Name = "im_livechat_channel__is_published_index")]
public partial class ImLivechatChannelIAuditedObject
{

    //[Column("button_text")]
    //public string? ButtonText { get; set; }

    //[Column("default_message")]
    //public string? DefaultMessage { get; set; }

    //[Column("input_placeholder")]
    //public string? InputPlaceholder { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ChannelId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Channel")] // One2many
    public virtual ICollection<ImLivechatChannelRule> ImLivechatChannelRule { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LivechatChannelId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("LivechatChannel")] // One2many
    public virtual ICollection<MailChannel> MailChannel { get; set; }

}
