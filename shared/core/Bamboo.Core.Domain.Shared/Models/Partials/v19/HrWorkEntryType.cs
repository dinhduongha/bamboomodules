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

public partial class HrWorkEntryType
{
    [JsonField] // DisplayCode
    [Column("display_code", TypeName = "jsonb")]
    public JsonElement? DisplayCode { get; set; }

    [Column("is_extra_hours")]
    public bool? IsExtraHours { get; set; }

    [Column("amount_rate")]
    public double? AmountRate { get; set; }

}