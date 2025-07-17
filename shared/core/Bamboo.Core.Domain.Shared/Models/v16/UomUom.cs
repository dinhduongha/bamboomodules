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
public partial class UomUom: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("category_id")]
    public Guid? CategoryId { get; set; }

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
    public DateTime CreationTime { get; set; }

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

    /// TODO: DISABLE INVERSE COLLECTIONS
    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLines { get; set; } = new List<AccountAnalyticLine>();

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLines { get; set; } = new List<AccountMoveLine>();

    //[InverseProperty("AssociatedUom")]
    [NotMapped]
    public virtual ICollection<BarcodeRule> BarcodeRules { get; set; } = new List<BarcodeRule>();

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<HrExpense> HrExpenses { get; set; } = new List<HrExpense>();

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<MrpBomByproduct> MrpBomByproducts { get; set; } = new List<MrpBomByproduct>();

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<MrpBomLine> MrpBomLines { get; set; } = new List<MrpBomLine>();

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<MrpBom> MrpBoms { get; set; } = new List<MrpBom>();

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<MrpProduction> MrpProductions { get; set; } = new List<MrpProduction>();

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<MrpUnbuild> MrpUnbuilds { get; set; } = new List<MrpUnbuild>();

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<MrpWorkorder> MrpWorkorders { get; set; } = new List<MrpWorkorder>();

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<ProductReplenish> ProductReplenishes { get; set; } = new List<ProductReplenish>();

    //[InverseProperty("UomPo")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> ProductTemplateUomPos { get; set; } = new List<ProductTemplate>();

    //[InverseProperty("Uom")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> ProductTemplateUoms { get; set; } = new List<ProductTemplate>();

    //[InverseProperty("ProductUomNavigation")]
    [NotMapped]
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; } = new List<PurchaseOrderLine>();

    //[InverseProperty("ProductUomNavigation")]
    [NotMapped]
    public virtual ICollection<RepairFee> RepairFees { get; set; } = new List<RepairFee>();

    //[InverseProperty("ProductUomNavigation")]
    [NotMapped]
    public virtual ICollection<RepairLine> RepairLines { get; set; } = new List<RepairLine>();

    //[InverseProperty("ProductUomNavigation")]
    [NotMapped]
    public virtual ICollection<RepairOrder> RepairOrders { get; set; } = new List<RepairOrder>();

    //[InverseProperty("ProductUomNavigation")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> SaleOrderLines { get; set; } = new List<SaleOrderLine>();

    //[InverseProperty("Uom")]
    [NotMapped]
    public virtual ICollection<SaleOrderOption> SaleOrderOptions { get; set; } = new List<SaleOrderOption>();

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplateLine> SaleOrderTemplateLines { get; set; } = new List<SaleOrderTemplateLine>();

    //[InverseProperty("Uom")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplateOption> SaleOrderTemplateOptions { get; set; } = new List<SaleOrderTemplateOption>();

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<StockLot> StockLots { get; set; } = new List<StockLot>();

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<StockMoveLine> StockMoveLines { get; set; } = new List<StockMoveLine>();

    //[InverseProperty("ProductUomNavigation")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoves { get; set; } = new List<StockMove>();

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<StockScrap> StockScraps { get; set; } = new List<StockScrap>();

}
