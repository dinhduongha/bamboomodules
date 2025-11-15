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

public partial class IrMailServer
{

    [Column("owner_user_id")]
    public Guid? OwnerUserId { get; set; }

    [Column("owner_limit_count")]
    public long? OwnerLimitCount { get; set; }

    [Column("owner_limit_time", TypeName = "timestamp without time zone")]
    public DateTime? OwnerLimitTime { get; set; }

    [Column("microsoft_outlook_access_token_expiration")]
    public long? MicrosoftOutlookAccessTokenExpiration { get; set; }

    [Column("microsoft_outlook_refresh_token")]
    public string? MicrosoftOutlookRefreshToken { get; set; }

    [Column("microsoft_outlook_access_token")]
    public string? MicrosoftOutlookAccessToken { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("OwnerUserId")]
    public virtual ResUsers? OwnerUser { get; set; }

}