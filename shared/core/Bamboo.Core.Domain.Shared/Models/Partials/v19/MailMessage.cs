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

public partial class MailMessage
{
    [Column("incoming_email_cc")]
    public string? IncomingEmailCc { get; set; }

    [Column("outgoing_email_to")]
    public string? OutgoingEmailTo { get; set; }

    [Column("incoming_email_to")]
    public string? IncomingEmailTo { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public virtual DiscussCallHistory? DiscussCallHistory { get; set; }

    // // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [One2many] [ForeignKey("MailMessageId")]
    // // [NotMapped] // One2many // Normal
    // // [InverseProperty("MailMessage")] // One2many
    // public virtual ICollection<MailMail> MailMail { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MessageId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Message")] // One2many
    public virtual ICollection<MailMessageLinkPreview> MailMessageLinkPreview { get; set; }


}