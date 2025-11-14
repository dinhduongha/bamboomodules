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

//[Table("mail_compose_message")]
public partial class MailComposeMessage
{
    [Column("res_id")]
    public Guid? ResId { get; set; }

    [Column("active_domain")]
    public string? ActiveDomain { get; set; }

    [Column("use_active_domain")]
    public bool? UseActiveDomain { get; set; }

    [Column("is_log")]
    public bool? IsLog { get; set; }

    [Column("notify")]
    public bool? Notify { get; set; }

    [Column("auto_delete_message")]
    public bool? AutoDeleteMessage { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ComposerId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Composer")] // One2many
    public virtual ICollection<AccountInvoiceSend> AccountInvoiceSend { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Peer relationship (IrAttachment) is commented out
    // [ForeignKey("WizardId")] // Many2many // Normal
    // [InverseProperty("Wizard")] // Many2many // Normal
    // public virtual ICollection<IrAttachment> Attachment { get; set; }
}
