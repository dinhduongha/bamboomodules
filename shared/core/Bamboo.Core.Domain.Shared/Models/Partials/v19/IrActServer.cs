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

public partial class IrActServer
{
    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("sequence_id")]
    public Guid? SequenceId { get; set; }

    [Column("automated_name")]
    public string? AutomatedName { get; set; }

    [Column("html_value")]
    public string? HtmlValue { get; set; }

    [Column("followers_type")]
    public string? FollowersType { get; set; }

    [Column("followers_partner_field_name")]
    public string? FollowersPartnerFieldName { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ParentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Parent")] // One2many
    public virtual ICollection<IrActServer> InverseParent { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ActionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Action")] // One2many
    public virtual ICollection<IrActionsServerHistory> IrActionsServerHistory { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ParentId")]
    public virtual IrActServer? Parent { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SequenceId")]
    public virtual IrSequence? SequenceNavigation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ActionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Action")] // One2many
    public virtual ICollection<ServerActionHistoryWizard> ServerActionHistoryWizard { get; set; }

}