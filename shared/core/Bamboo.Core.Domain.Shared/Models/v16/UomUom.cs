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
    public override Guid? LastModifierId { get; set; }

    [Column("uom_type")]
    public string? UomType { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [Column("factor")]
    public decimal? Factor { get; set; }

    [Column("rounding")]
    public decimal? Rounding { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

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
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLines { get; set; } 

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLines { get; set; } 

    //[InverseProperty("AssociatedUom")]
    [NotMapped]
    public virtual ICollection<BarcodeRule> BarcodeRules { get; set; } 

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<HrExpense> HrExpenses { get; set; } 

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<MrpBomByproduct> MrpBomByproducts { get; set; } 

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<MrpBomLine> MrpBomLines { get; set; } 

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<MrpBom> MrpBoms { get; set; } 

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<MrpProduction> MrpProductions { get; set; } 

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<MrpUnbuild> MrpUnbuilds { get; set; } 

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<MrpWorkorder> MrpWorkorders { get; set; } 

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<ProductReplenish> ProductReplenishes { get; set; } 

    //[InverseProperty("UomPo")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> ProductTemplateUomPos { get; set; } 

    //[InverseProperty("Uom")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> ProductTemplateUoms { get; set; } 

    //[InverseProperty("ProductUomNavigation")]
    [NotMapped]
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; } 

    //[InverseProperty("ProductUomNavigation")]
    [NotMapped]
    public virtual ICollection<RepairFee> RepairFees { get; set; } 

    //[InverseProperty("ProductUomNavigation")]
    [NotMapped]
    public virtual ICollection<RepairLine> RepairLines { get; set; } 

    //[InverseProperty("ProductUomNavigation")]
    [NotMapped]
    public virtual ICollection<RepairOrder> RepairOrders { get; set; } 

    //[InverseProperty("ProductUomNavigation")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> SaleOrderLines { get; set; } 

    //[InverseProperty("Uom")]
    [NotMapped]
    public virtual ICollection<SaleOrderOption> SaleOrderOptions { get; set; } 

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplateLine> SaleOrderTemplateLines { get; set; } 

    //[InverseProperty("Uom")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplateOption> SaleOrderTemplateOptions { get; set; } 

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<StockLot> StockLots { get; set; } 

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<StockMoveLine> StockMoveLines { get; set; } 

    //[InverseProperty("ProductUomNavigation")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoves { get; set; } 

    //[InverseProperty("ProductUom")]
    [NotMapped]
    public virtual ICollection<StockScrap> StockScraps { get; set; } 

}
