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

//[Table("stock_move_line")]
//[Index("CompanyId", Name = "stock_move_line__company_id_index")]
//[Index("MoveId", Name = "stock_move_line__move_id_index")]
//[Index("PickingId", Name = "stock_move_line__picking_id_index")]
//[Index("ProductId", Name = "stock_move_line__product_id_index")]
public partial class StockMoveLine
{
    [Column("product_category_name")]
    public string? ProductCategoryName { get; set; }

    [Column("reserved_qty")]
    public decimal? ReservedQty { get; set; }

    [Column("reserved_uom_qty")]
    public decimal? ReservedUomQty { get; set; }

    [Column("qty_done")]
    public decimal? QtyDone { get; set; }

    [JsonField(IsSparse = false)] // CarrierName
    [Column("carrier_name", TypeName = "jsonb")]
    public StringDictionary? CarrierName { get; set; }

    // [Many2many] // Normal
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ConsumeLineId")] // Many2many // Normal
    // [InverseProperty("ConsumeLine")] // Many2many // Normal
    // public virtual ICollection<StockMoveLine> ProduceLine { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockMoveLineId")] //Many2many // Hidden
    // [InverseProperty("StockMoveLine")] //Many2many // Hidden
    public virtual ICollection<ProductLabelLayout> ProductLabelLayout { get; set; }
}
