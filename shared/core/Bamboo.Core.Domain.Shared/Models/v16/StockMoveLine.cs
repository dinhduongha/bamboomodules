using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Table("stock_move_line")]
//[Index("CompanyId", Name = "stock_move_line__company_id_index")]
//[Index("MoveId", Name = "stock_move_line__move_id_index")]
//[Index("PickingId", Name = "stock_move_line__picking_id_index")]
//[Index("ProductId", Name = "stock_move_line__product_id_index")]
public partial class StockMoveLine: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("picking_id")]
    public Guid? PickingId { get; set; }

    [Column("move_id")]
    public Guid? MoveId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_uom_id")]
    public Guid? ProductUomId { get; set; }

    [Column("package_id")]
    public Guid? PackageId { get; set; }

    [Column("package_level_id")]
    public Guid? PackageLevelId { get; set; }

    [Column("lot_id")]
    public Guid? LotId { get; set; }

    [Column("result_package_id")]
    public Guid? ResultPackageId { get; set; }

    [Column("owner_id")]
    public Guid? OwnerId { get; set; }

    [Column("location_id")]
    public Guid? LocationId { get; set; }

    [Column("location_dest_id")]
    public Guid? LocationDestId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("product_category_name")]
    public string? ProductCategoryName { get; set; }

    [Column("lot_name")]
    public string? LotName { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("reference")]
    public string? Reference { get; set; }

    [Column("description_picking")]
    public string? DescriptionPicking { get; set; }

    [Column("quantity")]
    public decimal? Quantity { get; set; }

    [Column("quantity_product_uom")]
    public decimal? QuantityProductUom { get; set; }

    [Column("picked")]
    public bool? Picked { get; set; }
    [Column("reserved_qty")]
    public decimal? ReservedQty { get; set; }

    [Column("reserved_uom_qty")]
    public decimal? ReservedUomQty { get; set; }

    [Column("qty_done")]
    public decimal? QtyDone { get; set; }

    [Column("date", TypeName = "timestamp without time zone")]
    public DateTime? Date { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("workorder_id")]
    public Guid? WorkorderId { get; set; }

    [Column("production_id")]
    public Guid? ProductionId { get; set; }

    [Column("carrier_id")]
    public Guid? CarrierId { get; set; }

    [JsonField]
    [Column("carrier_name", TypeName = "jsonb")]
    public string? CarrierName { get; set; }

    [Column("batch_id")]
    public Guid? BatchId { get; set; }

    [Column("expiration_date", TypeName = "timestamp without time zone")]
    public DateTime? ExpirationDate { get; set; }

    // [Many2one]
    [ForeignKey("BatchId")]
    // [InverseProperty("StockMoveLine")] //Many2one
    public virtual StockPickingBatch? Batch { get; set; }

    // [Many2one]
    [ForeignKey("CarrierId")]
    // [InverseProperty("StockMoveLine")] //Many2one
    public virtual DeliveryCarrier? Carrier { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("StockMoveLine")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("StockMoveLineCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("LocationId")]
    // [InverseProperty("StockMoveLineLocation")] //Many2one
    public virtual StockLocation? Location { get; set; }

    // [Many2one]
    [ForeignKey("LocationDestId")]
    // [InverseProperty("StockMoveLineLocationDest")] //Many2one
    public virtual StockLocation? LocationDest { get; set; }

    // [Many2one]
    [ForeignKey("LotId")]
    // [InverseProperty("StockMoveLine")] //Many2one
    public virtual StockLot? Lot { get; set; }

    // [Many2one]
    [ForeignKey("MoveId")]
    // [InverseProperty("StockMoveLine")] //Many2one
    public virtual StockMove? Move { get; set; }

    // [Many2one]
    [ForeignKey("OwnerId")]
    // [InverseProperty("StockMoveLine")] //Many2one
    public virtual ResPartner? Owner { get; set; }

    // [Many2one]
    [ForeignKey("PackageId")]
    // [InverseProperty("StockMoveLinePackage")] //Many2one
    public virtual StockQuantPackage? Package { get; set; }

    // [Many2one]
    [ForeignKey("PackageLevelId")]
    // [InverseProperty("StockMoveLine")] //Many2one
    public virtual StockPackageLevel? PackageLevel { get; set; }

    // [Many2one]
    [ForeignKey("PickingId")]
    // [InverseProperty("StockMoveLine")] //Many2one
    public virtual StockPicking? Picking { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("StockMoveLine")] //Many2one
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [ForeignKey("ProductUomId")]
    // [InverseProperty("StockMoveLine")] //Many2one
    public virtual UomUom? ProductUom { get; set; }

    // [Many2one]
    [ForeignKey("ProductionId")]
    // [InverseProperty("StockMoveLine")] //Many2one
    public virtual MrpProduction? Production { get; set; }

    // [Many2one]
    [ForeignKey("ResultPackageId")]
    // [InverseProperty("StockMoveLineResultPackage")] //Many2one
    public virtual StockQuantPackage? ResultPackage { get; set; }

    // [Many2one]
    [ForeignKey("WorkorderId")]
    // [InverseProperty("StockMoveLine")] //Many2one
    public virtual MrpWorkorder? Workorder { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("StockMoveLineWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ProduceLineId")] //Many2many
    // [InverseProperty("ProduceLine")] //Many2many
    public virtual ICollection<StockMoveLine> ConsumeLine { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockMoveLineId")]
    // [InverseProperty("StockMoveLine")]
    public virtual ICollection<LotLabelLayout> LotLabelLayout { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ConsumeLineId")] //Many2many
    // [InverseProperty("ConsumeLine")] //Many2many
    public virtual ICollection<StockMoveLine> ProduceLine { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockMoveLineId")]
    // [InverseProperty("StockMoveLine")]
    public virtual ICollection<ProductLabelLayout> ProductLabelLayout { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockMoveLineId")]
    // [InverseProperty("StockMoveLine")]
    public virtual ICollection<StockAddToWave> StockAddToWave { get; set; }
}
