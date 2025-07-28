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

[Table("product_product")]
//[Index("CombinationIndices", Name = "product_product_combination_indices_index")]
//[Index("DefaultCode", Name = "product_product_default_code_index")]
//[Index("ProductTmplId", Name = "product_product_product_tmpl_id_index")]
public partial class ProductProduct : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    // v16-Compat
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("product_tmpl_id")]
    public Guid? ProductTmplId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("default_code")]
    public string? DefaultCode { get; set; }

    [Column("barcode")]
    public string? Barcode { get; set; }

    [Column("combination_indices")]
    public string? CombinationIndices { get; set; }

    [JsonField]
    [Column("standard_price", TypeName = "jsonb")]
    public string? StandardPrice { get; set; }

    [Column("volume")]
    public decimal? Volume { get; set; }

    [Column("weight")]
    public decimal? Weight { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("can_image_variant_1024_be_zoomed")]
    public bool? CanImageVariant1024BeZoomed { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [JsonField]
    [Column("lot_properties_definition", TypeName = "jsonb")]
    public string? LotPropertiesDefinition { get; set; }

    [Column("variant_ribbon_id")]
    public Guid? VariantRibbonId { get; set; }

    [Column("base_unit_id")]
    public Guid? BaseUnitId { get; set; }

    [Column("base_unit_count")]
    public double? BaseUnitCount { get; set; }

    [ForeignKey("TenantId")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("BaseUnitId")]
    //[InverseProperty("ProductProducts")]
    [NotMapped]
    public virtual WebsiteBaseUnit? BaseUnit { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ProductProductCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("ProductProducts")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("ProductTmplId")]
    //[InverseProperty("ProductProducts")]
    [NotMapped]
    public virtual ProductTemplate? ProductTmpl { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ProductProductWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticDistributionModel> AccountAnalyticDistributionModels { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLines { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLines { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<HrExpenseSplit> HrExpenseSplits { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<HrExpense> HrExpenses { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<MrpBomByproduct> MrpBomByproducts { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<MrpBomLine> MrpBomLines { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<MrpBom> MrpBoms { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<MrpConsumptionWarningLine> MrpConsumptionWarningLines { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<MrpProduction> MrpProductions { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<MrpUnbuild> MrpUnbuilds { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterCapacity> MrpWorkcenterCapacities { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<MrpWorkorder> MrpWorkorders { get; set; } 

    //[InverseProperty("DownPaymentProduct")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigDownPaymentProducts { get; set; } 

    //[InverseProperty("TipProduct")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigTipProducts { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<PosOrderLine> PosOrderLines { get; set; } 

    //[InverseProperty("ProductVariant")]
    [NotMapped]
    public virtual ICollection<ProductImage> ProductImages { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<ProductPackaging> ProductPackagings { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<ProductPricelistItem> ProductPricelistItems { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<ProductReplenish> ProductReplenishes { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<ProductSupplierinfo> ProductSupplierinfos { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<RepairFee> RepairFees { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<RepairLine> RepairLines { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<RepairOrder> RepairOrders { get; set; } 

    //[InverseProperty("DepositDefaultProduct")]
    [NotMapped]
    public virtual ICollection<ResConfigSetting> ResConfigSettingDepositDefaultProducts { get; set; } 

    //[InverseProperty("PosTipProduct")]
    [NotMapped]
    public virtual ICollection<ResConfigSetting> ResConfigSettingPosTipProducts { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInvs { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> SaleOrderLines { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<SaleOrderOption> SaleOrderOptions { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplateLine> SaleOrderTemplateLines { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplateOption> SaleOrderTemplateOptions { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockChangeProductQty> StockChangeProductQties { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockLot> StockLots { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockMoveLine> StockMoveLines { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoves { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockPutawayRule> StockPutawayRules { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockQuant> StockQuants { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockReplenishmentOption> StockReplenishmentOptions { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockReturnPickingLine> StockReturnPickingLines { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockRulesReport> StockRulesReports { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockScrap> StockScraps { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockStorageCategoryCapacity> StockStorageCategoryCapacities { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockTrackLine> StockTrackLines { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockValuationLayerRevaluation> StockValuationLayerRevaluations { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockValuationLayer> StockValuationLayers { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoints { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockWarnInsufficientQtyRepair> StockWarnInsufficientQtyRepairs { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockWarnInsufficientQtyScrap> StockWarnInsufficientQtyScraps { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockWarnInsufficientQtyUnbuild> StockWarnInsufficientQtyUnbuilds { get; set; } 

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<WebsiteTrack> WebsiteTracks { get; set; } 

    [ForeignKey("ProductProductId")]
    //[InverseProperty("ProductProducts")]
    [NotMapped]
    public virtual ICollection<ProductLabelLayout> ProductLabelLayouts { get; set; } 

    [ForeignKey("ProductProductId")]
    //[InverseProperty("ProductProducts")]
    [NotMapped]
    public virtual ICollection<ProductTag> ProductTags { get; set; } 

    [ForeignKey("ProductProductId")]
    //[InverseProperty("ProductProducts")]
    [NotMapped]
    public virtual ICollection<ProductTemplateAttributeValue> ProductTemplateAttributeValues { get; set; } 

    [ForeignKey("ProductProductId")]
    //[InverseProperty("ProductProducts")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartners { get; set; } 

    [ForeignKey("DestId")]
    //[InverseProperty("Dests")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> Srcs { get; set; } 

    [ForeignKey("ProductProductId")]
    //[InverseProperty("ProductProducts")]
    [NotMapped]
    public virtual ICollection<StockTrackConfirmation> StockTrackConfirmations { get; set; } 
}
