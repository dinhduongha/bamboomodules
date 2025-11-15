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

public partial class FetchmailServer
{
    [Column("error_message")]
    public string? ErrorMessage { get; set; }

    [Column("error_date", TypeName = "timestamp without time zone")]
    public DateTime? ErrorDate { get; set; }

    [Column("microsoft_outlook_access_token_expiration")]
    public long? MicrosoftOutlookAccessTokenExpiration { get; set; }

    [JsonIgnore]
    [Column("microsoft_outlook_refresh_token")]
    public string? MicrosoftOutlookRefreshToken { get; set; }

    [JsonIgnore]
    [Column("microsoft_outlook_access_token")]
    public string? MicrosoftOutlookAccessToken { get; set; }

}