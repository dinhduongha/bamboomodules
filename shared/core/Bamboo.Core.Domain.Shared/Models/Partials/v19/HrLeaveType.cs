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

public partial class HrLeaveType
{
    [Column("country_id")]
    public Guid? CountryId { get; set; }

    [Column("hide_on_dashboard")]
    public bool? HideOnDashboard { get; set; }

    [Column("allow_request_on_top")]
    public bool? AllowRequestOnTop { get; set; }

    [Column("elligible_for_accrual_rate")]
    public bool? ElligibleForAccrualRate { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CountryId")]
    public virtual ResCountry? Country { get; set; }

}