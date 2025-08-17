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

[Table("stock_quant")]
//[Index("LocationId", Name = "stock_quant_location_id_index")]
//[Index("LotId", Name = "stock_quant_lot_id_index")]
//[Index("PackageId", Name = "stock_quant_package_id_index")]
//[Index("ProductId", Name = "stock_quant_product_id_index")]
public partial class StockQuant: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("location_id")]
    public Guid? LocationId { get; set; }

    [Column("storage_category_id")]
    public Guid? StorageCategoryId { get; set; }

    [Column("lot_id")]
    public Guid? LotId { get; set; }

    [Column("package_id")]
    public Guid? PackageId { get; set; }

    [Column("owner_id")]
    public Guid? OwnerId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("inventory_date")]
    public DateTime? InventoryDate { get; set; }

    [Column("quantity")]
    public decimal? Quantity { get; set; }

    [Column("reserved_quantity")]
    public decimal? ReservedQuantity { get; set; }

    [Column("inventory_quantity")]
    public decimal? InventoryQuantity { get; set; }

    [Column("inventory_diff_quantity")]
    public decimal? InventoryDiffQuantity { get; set; }

    [Column("inventory_quantity_set")]
    public bool? InventoryQuantitySet { get; set; }

    [Column("in_date", TypeName = "timestamp without time zone")]
    public DateTime? InDate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("accounting_date")]
    public DateTime? AccountingDate { get; set; }

    [Column("removal_date", TypeName = "timestamp without time zone")]
    public DateTime? RemovalDate { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("StockQuant")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("StockQuantCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("LocationId")]
    // [InverseProperty("StockQuant")] //Many2one
    public virtual StockLocation? Location { get; set; }

    // [Many2one]
    [ForeignKey("LotId")]
    // [InverseProperty("StockQuant")] //Many2one
    public virtual StockLot? Lot { get; set; }

    // [Many2one]
    [ForeignKey("OwnerId")]
    // [InverseProperty("StockQuant")] //Many2one
    public virtual ResPartner? Owner { get; set; }

    // [Many2one]
    [ForeignKey("PackageId")]
    // [InverseProperty("StockQuant")] //Many2one
    public virtual StockQuantPackage? Package { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("StockQuant")] //Many2one
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [ForeignKey("StorageCategoryId")]
    // [InverseProperty("StockQuant")] //Many2one
    public virtual StockStorageCategory? StorageCategory { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("StockQuantUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("StockQuantWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockQuantId")]
    // [InverseProperty("StockQuant")]
    // public virtual ICollection<StockInventoryAdjustmentName> StockInventoryAdjustmentName { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockQuantId")]
    // [InverseProperty("StockQuant")]
    // public virtual ICollection<StockInventoryConflict> StockInventoryConflict { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockQuantId")]
    // [InverseProperty("StockQuantNavigation")]
    // public virtual ICollection<StockInventoryConflict> StockInventoryConflictNavigation { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockQuantId")]
    // [InverseProperty("StockQuant")]
    // public virtual ICollection<StockInventoryWarning> StockInventoryWarning { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockQuantId")]
    // [InverseProperty("StockQuant")]
    // public virtual ICollection<StockRequestCount> StockRequestCount { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockQuantId")]
    // [InverseProperty("StockQuant")]
    // public virtual ICollection<StockTrackConfirmation> StockTrackConfirmation { get; set; }
}
