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

public partial class MrpBom
{
    [Column("batch_size")]
    public decimal? BatchSize { get; set; }

    [Column("enable_batch_size")]
    public bool? EnableBatchSize { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("MrpBomId")] //Many2many // Hidden
    // [InverseProperty("MrpBom")] //Many2many // Hidden
    public virtual ICollection<StockReplenishmentInfo> StockReplenishmentInfo { get; set; }

}