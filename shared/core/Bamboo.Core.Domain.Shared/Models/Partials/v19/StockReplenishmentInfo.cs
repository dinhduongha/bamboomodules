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

public partial class StockReplenishmentInfo
{
    [Column("percent_factor")]
    public long? PercentFactor { get; set; }

    [Column("based_on")]
    public string? BasedOn { get; set; }


    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("StockReplenishmentInfoId")] // Many2many // Normal
    // [InverseProperty("StockReplenishmentInfo")] // Many2many // Normal
    public virtual ICollection<MrpBom> MrpBom { get; set; }

}