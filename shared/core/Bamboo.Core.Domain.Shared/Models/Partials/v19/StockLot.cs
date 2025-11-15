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

public partial class StockLot
{
    [Column("avg_cost")]
    public decimal? AvgCost { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LotId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Lot")] // One2many
    public virtual ICollection<ProductValue> ProductValue { get; set; }

    // // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [One2many] [ForeignKey("LotId")]
    // // [NotMapped] // One2many // Normal
    // // [InverseProperty("Lot")] // One2many
    // public virtual ICollection<RepairOrder> RepairOrder { get; set; }

    // // [Many2many] // Hidden
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] //Many2many // Hidden
    // // [ForeignKey("StockLotId")] //Many2many // Hidden
    // // [InverseProperty("StockLot")] //Many2many // Hidden
    // public virtual ICollection<MrpProduction> MrpProduction { get; set; }
}