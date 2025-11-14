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

//[Index("Code", Name = "account_analytic_account__code_index")]
public partial class AccountAnalyticAccount
{

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AccountId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Account")] // One2many
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLine { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AnalyticAccountId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("AnalyticAccount")] // One2many
    public virtual ICollection<ProjectProject> ProjectProject { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AnalyticAccountId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("AnalyticAccount")] // One2many
    public virtual ICollection<ProjectTask> ProjectTask { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AnalyticAccountId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("AnalyticAccount")] // One2many
    public virtual ICollection<SaleOrder> SaleOrder { get; set; }
   
}
