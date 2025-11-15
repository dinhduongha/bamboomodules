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

public partial class RestaurantTable
{

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SelfOrderingTableId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SelfOrderingTable")] // One2many
    public virtual ICollection<PosOrder> PosOrderSelfOrderingTable { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TableId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Table")] // One2many
    public virtual ICollection<PosOrder> PosOrderTable { get; set; }

}