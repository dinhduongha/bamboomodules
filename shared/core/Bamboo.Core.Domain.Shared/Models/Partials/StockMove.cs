using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("stock_move")]
//[Index("CompanyId", Name = "stock_move__company_id_index")]
//[Index("CreatedProductionId", Name = "stock_move__created_production_id_index")]
//[Index("Date", Name = "stock_move__date_index")]
//[Index("GroupId", Name = "stock_move__group_id_index")]
//[Index("LocationDestId", Name = "stock_move__location_dest_id_index")]
//[Index("LocationId", Name = "stock_move__location_id_index")]
//[Index("OrderpointId", Name = "stock_move__orderpoint_id_index")]
//[Index("OriginReturnedMoveId", Name = "stock_move__origin_returned_move_id_index")]
//[Index("PickingId", Name = "stock_move__picking_id_index")]
//[Index("ProductId", Name = "stock_move__product_id_index")]
//[Index("State", Name = "stock_move__state_index")]
//[Index("ProductId", "LocationId", "LocationDestId", "CompanyId", "State", Name = "stock_move_product_location_index")]
public partial class StockMove
{
    [Column("quantity_done")]
    public decimal? QuantityDone { get; set; }

    [Column("analytic_account_line_id")]
    public Guid? AnalyticAccountLineId { get; set; }

    [Column("created_purchase_line_id")]
    public Guid? CreatedPurchaseLineId { get; set; }

    // [Many2one]
    [ForeignKey("AnalyticAccountLineId")]
    public virtual AccountAnalyticLine? AnalyticAccountLine { get; set; }

    // [Many2one]
    //[ForeignKey("CreatedPurchaseLineId")]
    //public virtual PurchaseOrderLine? CreatedPurchaseLine { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MoveId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Move")] // One2many
    public virtual ICollection<RepairLine> RepairLine { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MoveId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Move")] // One2many
    public virtual ICollection<StockAssignSerial> StockAssignSerial { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MoveId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Move")] // One2many
    public virtual ICollection<StockScrap> StockScrap { get; set; }

}
