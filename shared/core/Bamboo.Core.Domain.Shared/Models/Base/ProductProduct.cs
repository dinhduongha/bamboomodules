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
public partial class ProductProduct: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

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

    [Column("volume")]
    public decimal? Volume { get; set; }

    [Column("weight")]
    public decimal? Weight { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("can_image_variant_1024_be_zoomed")]
    public bool? CanImageVariant1024BeZoomed { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("base_unit_id")]
    public Guid? BaseUnitId { get; set; }

    [Column("base_unit_count")]
    public double? BaseUnitCount { get; set; }

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
    public virtual ICollection<AccountAnalyticDistributionModel> AccountAnalyticDistributionModels { get; } = new List<AccountAnalyticDistributionModel>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLines { get; } = new List<AccountAnalyticLine>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLines { get; } = new List<AccountMoveLine>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<HrExpenseSplit> HrExpenseSplits { get; } = new List<HrExpenseSplit>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<HrExpense> HrExpenses { get; } = new List<HrExpense>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<MrpBomByproduct> MrpBomByproducts { get; } = new List<MrpBomByproduct>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<MrpBomLine> MrpBomLines { get; } = new List<MrpBomLine>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<MrpBom> MrpBoms { get; } = new List<MrpBom>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<MrpConsumptionWarningLine> MrpConsumptionWarningLines { get; } = new List<MrpConsumptionWarningLine>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<MrpProduction> MrpProductions { get; } = new List<MrpProduction>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<MrpUnbuild> MrpUnbuilds { get; } = new List<MrpUnbuild>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterCapacity> MrpWorkcenterCapacities { get; } = new List<MrpWorkcenterCapacity>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<MrpWorkorder> MrpWorkorders { get; } = new List<MrpWorkorder>();

    //[InverseProperty("DownPaymentProduct")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigDownPaymentProducts { get; } = new List<PosConfig>();

    //[InverseProperty("TipProduct")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigTipProducts { get; } = new List<PosConfig>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<PosOrderLine> PosOrderLines { get; } = new List<PosOrderLine>();

    //[InverseProperty("ProductVariant")]
    [NotMapped]
    public virtual ICollection<ProductImage> ProductImages { get; } = new List<ProductImage>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<ProductPackaging> ProductPackagings { get; } = new List<ProductPackaging>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<ProductPricelistItem> ProductPricelistItems { get; } = new List<ProductPricelistItem>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<ProductReplenish> ProductReplenishes { get; } = new List<ProductReplenish>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<ProductSupplierinfo> ProductSupplierinfos { get; } = new List<ProductSupplierinfo>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; } = new List<PurchaseOrderLine>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<RepairFee> RepairFees { get; } = new List<RepairFee>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<RepairLine> RepairLines { get; } = new List<RepairLine>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<RepairOrder> RepairOrders { get; } = new List<RepairOrder>();

    //[InverseProperty("DepositDefaultProduct")]
    [NotMapped]
    public virtual ICollection<ResConfigSetting> ResConfigSettingDepositDefaultProducts { get; } = new List<ResConfigSetting>();

    //[InverseProperty("PosTipProduct")]
    [NotMapped]
    public virtual ICollection<ResConfigSetting> ResConfigSettingPosTipProducts { get; } = new List<ResConfigSetting>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInvs { get; } = new List<SaleAdvancePaymentInv>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> SaleOrderLines { get; } = new List<SaleOrderLine>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<SaleOrderOption> SaleOrderOptions { get; } = new List<SaleOrderOption>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplateLine> SaleOrderTemplateLines { get; } = new List<SaleOrderTemplateLine>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplateOption> SaleOrderTemplateOptions { get; } = new List<SaleOrderTemplateOption>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockChangeProductQty> StockChangeProductQties { get; } = new List<StockChangeProductQty>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockLot> StockLots { get; } = new List<StockLot>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockMoveLine> StockMoveLines { get; } = new List<StockMoveLine>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoves { get; } = new List<StockMove>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockPutawayRule> StockPutawayRules { get; } = new List<StockPutawayRule>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockQuant> StockQuants { get; } = new List<StockQuant>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockReplenishmentOption> StockReplenishmentOptions { get; } = new List<StockReplenishmentOption>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockReturnPickingLine> StockReturnPickingLines { get; } = new List<StockReturnPickingLine>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockRulesReport> StockRulesReports { get; } = new List<StockRulesReport>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockScrap> StockScraps { get; } = new List<StockScrap>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockStorageCategoryCapacity> StockStorageCategoryCapacities { get; } = new List<StockStorageCategoryCapacity>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockTrackLine> StockTrackLines { get; } = new List<StockTrackLine>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockValuationLayerRevaluation> StockValuationLayerRevaluations { get; } = new List<StockValuationLayerRevaluation>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockValuationLayer> StockValuationLayers { get; } = new List<StockValuationLayer>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoints { get; } = new List<StockWarehouseOrderpoint>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockWarnInsufficientQtyRepair> StockWarnInsufficientQtyRepairs { get; } = new List<StockWarnInsufficientQtyRepair>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockWarnInsufficientQtyScrap> StockWarnInsufficientQtyScraps { get; } = new List<StockWarnInsufficientQtyScrap>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<StockWarnInsufficientQtyUnbuild> StockWarnInsufficientQtyUnbuilds { get; } = new List<StockWarnInsufficientQtyUnbuild>();

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<WebsiteTrack> WebsiteTracks { get; } = new List<WebsiteTrack>();

    [ForeignKey("ProductProductId")]
    //[InverseProperty("ProductProducts")]
    [NotMapped]
    public virtual ICollection<ProductLabelLayout> ProductLabelLayouts { get; } = new List<ProductLabelLayout>();

    [ForeignKey("ProductProductId")]
    //[InverseProperty("ProductProducts")]
    [NotMapped]
    public virtual ICollection<ProductTag> ProductTags { get; } = new List<ProductTag>();

    [ForeignKey("ProductProductId")]
    //[InverseProperty("ProductProducts")]
    [NotMapped]
    public virtual ICollection<ProductTemplateAttributeValue> ProductTemplateAttributeValues { get; } = new List<ProductTemplateAttributeValue>();

    [ForeignKey("ProductProductId")]
    //[InverseProperty("ProductProducts")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartners { get; } = new List<ResPartner>();

    [ForeignKey("DestId")]
    //[InverseProperty("Dests")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> Srcs { get; } = new List<ProductTemplate>();

    [ForeignKey("ProductProductId")]
    //[InverseProperty("ProductProducts")]
    [NotMapped]
    public virtual ICollection<StockTrackConfirmation> StockTrackConfirmations { get; } = new List<StockTrackConfirmation>();
}
