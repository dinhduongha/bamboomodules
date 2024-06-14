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

[Table("uom_uom")]
public partial class UomUom: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("category_id")]
    public long? CategoryId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("uom_type")]
    public string? UomType { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("factor")]
    public decimal? Factor { get; set; }

    [Column("rounding")]
    public decimal? Rounding { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CategoryId")]
    //[InverseProperty("UomUoms")]
    [NotMapped]
    public virtual UomCategory? Category { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("UomUomCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("UomUomWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLines { get; } = new List<AccountAnalyticLine>();

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLines { get; } = new List<AccountMoveLine>();

    //[InverseProperty("AssociatedUom")]
    [NotMapped]
    public virtual ICollection<BarcodeRule> BarcodeRules { get; } = new List<BarcodeRule>();

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<HrExpense> HrExpenses { get; } = new List<HrExpense>();

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<MrpBomByproduct> MrpBomByproducts { get; } = new List<MrpBomByproduct>();

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<MrpBomLine> MrpBomLines { get; } = new List<MrpBomLine>();

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<MrpBom> MrpBoms { get; } = new List<MrpBom>();

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<MrpProduction> MrpProductions { get; } = new List<MrpProduction>();

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<MrpUnbuild> MrpUnbuilds { get; } = new List<MrpUnbuild>();

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<MrpWorkorder> MrpWorkorders { get; } = new List<MrpWorkorder>();

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<ProductReplenish> ProductReplenishes { get; } = new List<ProductReplenish>();

    //[InverseProperty("UomPo")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> ProductTemplateUomPos { get; } = new List<ProductTemplate>();

    //[InverseProperty("Uom")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> ProductTemplateUoms { get; } = new List<ProductTemplate>();

    //[InverseProperty("ProductUomNavigation")]
    [NotMapped]
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; } = new List<PurchaseOrderLine>();

    //[InverseProperty("ProductUomNavigation")]
    [NotMapped]
    public virtual ICollection<RepairFee> RepairFees { get; } = new List<RepairFee>();

    //[InverseProperty("ProductUomNavigation")]
    [NotMapped]
    public virtual ICollection<RepairLine> RepairLines { get; } = new List<RepairLine>();

    //[InverseProperty("ProductUomNavigation")]
    [NotMapped]
    public virtual ICollection<RepairOrder> RepairOrders { get; } = new List<RepairOrder>();

    //[InverseProperty("ProductUomNavigation")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> SaleOrderLines { get; } = new List<SaleOrderLine>();

    //[InverseProperty("Uom")]
    [NotMapped]
    public virtual ICollection<SaleOrderOption> SaleOrderOptions { get; } = new List<SaleOrderOption>();

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplateLine> SaleOrderTemplateLines { get; } = new List<SaleOrderTemplateLine>();

    //[InverseProperty("Uom")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplateOption> SaleOrderTemplateOptions { get; } = new List<SaleOrderTemplateOption>();

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<StockLot> StockLots { get; } = new List<StockLot>();

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<StockMoveLine> StockMoveLines { get; } = new List<StockMoveLine>();

    //[InverseProperty("ProductUomNavigation")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoves { get; } = new List<StockMove>();

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<StockScrap> StockScraps { get; } = new List<StockScrap>();

}
