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

public partial class ImLivechatChannel
{
    [Column("max_sessions")]
    public long? MaxSessions { get; set; }

    [Column("max_sessions_mode")]
    public string? MaxSessionsMode { get; set; }

    [Column("review_link")]
    public string? ReviewLink { get; set; }

    [Column("block_assignment_during_call")]
    public bool? BlockAssignmentDuringCall { get; set; }

    // [Many2many] // Hidden
    //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

    // [NotMapped] //Many2many // Hidden // Peer relationship (ResUsers) is commented out
    // // [ForeignKey("ChannelId")] //Many2many // Hidden
    // // [InverseProperty("Channel")] //Many2many // Hidden
    // public virtual ICollection<ResUsers> User { get; set; }
}