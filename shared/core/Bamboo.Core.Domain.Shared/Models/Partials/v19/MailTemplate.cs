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

public partial class MailTemplate
{
    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Template")] // One2many
    public virtual ICollection<AccountMoveSendWizard> AccountMoveSendWizard { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Template")] // One2many
    public virtual ICollection<CalendarPopoverDeleteWizard> CalendarPopoverDeleteWizard { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MailTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailTemplate")] // One2many
    public virtual ICollection<PosPreset> PosPreset { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CartRecoveryMailTemplateId")]
    [NotMapped] // One2many // Peer relationship (Website) is commented out
    // [InverseProperty("CartRecoveryMailTemplate")] // One2many
    public virtual ICollection<Website> WebsiteCartRecoveryMailTemplate { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ConfirmationEmailTemplateId")]
    [NotMapped] // One2many // Peer relationship (Website) is commented out
    // [InverseProperty("ConfirmationEmailTemplate")] // One2many
    public virtual ICollection<Website> WebsiteConfirmationEmailTemplate { get; set; }


}