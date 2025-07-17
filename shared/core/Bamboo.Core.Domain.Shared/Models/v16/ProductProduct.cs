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
    public Guid? LastModifierId { get; set; }

    [Column("default_code")]
    public string? DefaultCode { get; set; }

    [Column("barcode")]
    public string? Barcode { get; set; }

    [Column("combination_indices")]
    public string? CombinationIndices { get; set; }

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
    public DateTime? LastModificationTime { get; set; }

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
    public virtual ICollection<AccountAnalyticDistributionModel> AccountAnalyticDistributionModels { get; set; } = new List<AccountAnalyticDistributionModel>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLines { get; set; } = new List<AccountAnalyticLine>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLines { get; set; } = new List<AccountMoveLine>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<HrExpenseSplit> HrExpenseSplits { get; set; } = new List<HrExpenseSplit>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<HrExpense> HrExpenses { get; set; } = new List<HrExpense>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<MrpBomByproduct> MrpBomByproducts { get; set; } = new List<MrpBomByproduct>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<MrpBomLine> MrpBomLines { get; set; } = new List<MrpBomLine>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<MrpBom> MrpBoms { get; set; } = new List<MrpBom>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<MrpConsumptionWarningLine> MrpConsumptionWarningLines { get; set; } = new List<MrpConsumptionWarningLine>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<MrpProduction> MrpProductions { get; set; } = new List<MrpProduction>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<MrpUnbuild> MrpUnbuilds { get; set; } = new List<MrpUnbuild>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterCapacity> MrpWorkcenterCapacities { get; set; } = new List<MrpWorkcenterCapacity>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<MrpWorkorder> MrpWorkorders { get; set; } = new List<MrpWorkorder>();

    //[InverseProperty("DownPaymentProduct")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigDownPaymentProducts { get; set; } = new List<PosConfig>();

    //[InverseProperty("TipProduct")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigTipProducts { get; set; } = new List<PosConfig>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<PosOrderLine> PosOrderLines { get; set; } = new List<PosOrderLine>();

    //[InverseProperty("ProductVariant")]
    [NotMapped]
    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<ProductPackaging> ProductPackagings { get; set; } = new List<ProductPackaging>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<ProductPricelistItem> ProductPricelistItems { get; set; } = new List<ProductPricelistItem>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<ProductReplenish> ProductReplenishes { get; set; } = new List<ProductReplenish>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<ProductSupplierinfo> ProductSupplierinfos { get; set; } = new List<ProductSupplierinfo>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; } = new List<PurchaseOrderLine>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<RepairFee> RepairFees { get; set; } = new List<RepairFee>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<RepairLine> RepairLines { get; set; } = new List<RepairLine>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<RepairOrder> RepairOrders { get; set; } = new List<RepairOrder>();

    //[InverseProperty("DepositDefaultProduct")]
    [NotMapped]
    public virtual ICollection<ResConfigSetting> ResConfigSettingDepositDefaultProducts { get; set; } = new List<ResConfigSetting>();

    //[InverseProperty("PosTipProduct")]
    [NotMapped]
    public virtual ICollection<ResConfigSetting> ResConfigSettingPosTipProducts { get; set; } = new List<ResConfigSetting>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInvs { get; set; } = new List<SaleAdvancePaymentInv>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> SaleOrderLines { get; set; } = new List<SaleOrderLine>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<SaleOrderOption> SaleOrderOptions { get; set; } = new List<SaleOrderOption>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplateLine> SaleOrderTemplateLines { get; set; } = new List<SaleOrderTemplateLine>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplateOption> SaleOrderTemplateOptions { get; set; } = new List<SaleOrderTemplateOption>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockChangeProductQty> StockChangeProductQties { get; set; } = new List<StockChangeProductQty>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockLot> StockLots { get; set; } = new List<StockLot>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockMoveLine> StockMoveLines { get; set; } = new List<StockMoveLine>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoves { get; set; } = new List<StockMove>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockPutawayRule> StockPutawayRules { get; set; } = new List<StockPutawayRule>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockQuant> StockQuants { get; set; } = new List<StockQuant>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockReplenishmentOption> StockReplenishmentOptions { get; set; } = new List<StockReplenishmentOption>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockReturnPickingLine> StockReturnPickingLines { get; set; } = new List<StockReturnPickingLine>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockRulesReport> StockRulesReports { get; set; } = new List<StockRulesReport>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockScrap> StockScraps { get; set; } = new List<StockScrap>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockStorageCategoryCapacity> StockStorageCategoryCapacities { get; set; } = new List<StockStorageCategoryCapacity>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockTrackLine> StockTrackLines { get; set; } = new List<StockTrackLine>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockValuationLayerRevaluation> StockValuationLayerRevaluations { get; set; } = new List<StockValuationLayerRevaluation>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockValuationLayer> StockValuationLayers { get; set; } = new List<StockValuationLayer>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoints { get; set; } = new List<StockWarehouseOrderpoint>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockWarnInsufficientQtyRepair> StockWarnInsufficientQtyRepairs { get; set; } = new List<StockWarnInsufficientQtyRepair>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockWarnInsufficientQtyScrap> StockWarnInsufficientQtyScraps { get; set; } = new List<StockWarnInsufficientQtyScrap>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockWarnInsufficientQtyUnbuild> StockWarnInsufficientQtyUnbuilds { get; set; } = new List<StockWarnInsufficientQtyUnbuild>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<WebsiteTrack> WebsiteTracks { get; set; } = new List<WebsiteTrack>();

    [ForeignKey("ProductProductId")]
    //[InverseProperty("ProductProducts")]
    [NotMapped]
    public virtual ICollection<ProductLabelLayout> ProductLabelLayouts { get; set; } = new List<ProductLabelLayout>();

    [ForeignKey("ProductProductId")]
    //[InverseProperty("ProductProducts")]
    [NotMapped]
    public virtual ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();

    [ForeignKey("ProductProductId")]
    //[InverseProperty("ProductProducts")]
    [NotMapped]
    public virtual ICollection<ProductTemplateAttributeValue> ProductTemplateAttributeValues { get; set; } = new List<ProductTemplateAttributeValue>();

    [ForeignKey("ProductProductId")]
    //[InverseProperty("ProductProducts")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartners { get; set; } = new List<ResPartner>();

    [ForeignKey("DestId")]
    //[InverseProperty("Dests")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> Srcs { get; set; } = new List<ProductTemplate>();

    [ForeignKey("ProductProductId")]
    //[InverseProperty("ProductProducts")]
    [NotMapped]
    public virtual ICollection<StockTrackConfirmation> StockTrackConfirmations { get; set; } = new List<StockTrackConfirmation>();
}
