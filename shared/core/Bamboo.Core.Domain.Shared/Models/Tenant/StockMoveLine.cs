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
//[Index("TenantId", Name = "stock_move_line_company_id_index")]
//[Index("MoveId", Name = "stock_move_line_move_id_index")]
//[Index("PickingId", Name = "stock_move_line_picking_id_index")]
//[Index("ProductId", Name = "stock_move_line_product_id_index")]
public partial class StockMoveLine: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("picking_id")]
    public Guid? PickingId { get; set; }

    [Column("move_id")]
    public Guid? MoveId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

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
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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

    [Column("reserved_qty")]
    public decimal? ReservedQty { get; set; }

    [Column("reserved_uom_qty")]
    public decimal? ReservedUomQty { get; set; }

    [Column("qty_done")]
    public decimal? QtyDone { get; set; }

    [Column("date", TypeName = "timestamp without time zone")]
    public DateTime? Date { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("workorder_id")]
    public Guid? WorkorderId { get; set; }

    [Column("production_id")]
    public Guid? ProductionId { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("StockMoveLines")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("StockMoveLineCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LocationId")]
    //[InverseProperty("StockMoveLineLocations")]
    [NotMapped]
    public virtual StockLocation? Location { get; set; }

    [ForeignKey("LocationDestId")]
    //[InverseProperty("StockMoveLineLocationDests")]
    [NotMapped]
    public virtual StockLocation? LocationDest { get; set; }

    [ForeignKey("LotId")]
    //[InverseProperty("StockMoveLines")]
    [NotMapped]
    public virtual StockLot? Lot { get; set; }

    [ForeignKey("MoveId")]
    //[InverseProperty("StockMoveLines")]
    [NotMapped]
    public virtual StockMove? Move { get; set; }

    [ForeignKey("OwnerId")]
    //[InverseProperty("StockMoveLines")]
    [NotMapped]
    public virtual ResPartner? Owner { get; set; }

    [ForeignKey("PackageId")]
    //[InverseProperty("StockMoveLinePackages")]
    [NotMapped]
    public virtual StockQuantPackage? Package { get; set; }

    [ForeignKey("PackageLevelId")]
    //[InverseProperty("StockMoveLines")]
    [NotMapped]
    public virtual StockPackageLevel? PackageLevel { get; set; }

    [ForeignKey("PickingId")]
    //[InverseProperty("StockMoveLines")]
    [NotMapped]
    public virtual StockPicking? Picking { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("StockMoveLines")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("ProductUomId")]
    //[InverseProperty("StockMoveLines")]
    [NotMapped]
    public virtual UomUom? ProductUom { get; set; }

    [ForeignKey("ProductionId")]
    //[InverseProperty("StockMoveLines")]
    [NotMapped]
    public virtual MrpProduction? Production { get; set; }

    [ForeignKey("ResultPackageId")]
    //[InverseProperty("StockMoveLineResultPackages")]
    [NotMapped]
    public virtual StockQuantPackage? ResultPackage { get; set; }

    [ForeignKey("WorkorderId")]
    //[InverseProperty("StockMoveLines")]
    [NotMapped]
    public virtual MrpWorkorder? Workorder { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("StockMoveLineWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("ProduceLineId")]
    //[InverseProperty("ProduceLines")]
    [NotMapped]
    public virtual ICollection<StockMoveLine> ConsumeLines { get; } = new List<StockMoveLine>();

    [ForeignKey("ConsumeLineId")]
    //[InverseProperty("ConsumeLines")]
    [NotMapped]
    public virtual ICollection<StockMoveLine> ProduceLines { get; } = new List<StockMoveLine>();

    [ForeignKey("StockMoveLineId")]
    //[InverseProperty("StockMoveLines")]
    [NotMapped]
    public virtual ICollection<ProductLabelLayout> ProductLabelLayouts { get; } = new List<ProductLabelLayout>();
}
