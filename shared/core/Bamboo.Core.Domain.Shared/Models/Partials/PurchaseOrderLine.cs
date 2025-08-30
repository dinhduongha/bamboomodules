using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("purchase_order_line")]
//[Index("DatePlanned", Name = "purchase_order_line__date_planned_index")]
//[Index("OrderId", Name = "purchase_order_line__order_id_index")]
public partial class PurchaseOrderLine
{
    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CreatedPurchaseLineId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("CreatedPurchaseLine")] // One2many
    public virtual ICollection<StockMove> StockMoveCreatedPurchaseLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PurchaseLineId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("PurchaseLine")] // One2many
    public virtual ICollection<StockMove> StockMovePurchaseLine { get; set; }
}
