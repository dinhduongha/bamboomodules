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
//[Index("CombinationIndices", Name = "product_product__combination_indices_index")]
//[Index("DefaultCode", Name = "product_product__default_code_index")]
//[Index("ProductTmplId", Name = "product_product__product_tmpl_id_index")]
public partial class ProductProduct: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("product_tmpl_id")]
    public Guid? ProductTmplId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

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

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [JsonField]
    [Column("lot_properties_definition", TypeName = "jsonb")]
    public string? LotPropertiesDefinition { get; set; }

    [Column("variant_ribbon_id")]
    public Guid? VariantRibbonId { get; set; }

    [Column("base_unit_id")]
    public Guid? BaseUnitId { get; set; }

    [Column("base_unit_count")]
    public double? BaseUnitCount { get; set; }

    [Column("image_fetch_pending")]
    public bool? ImageFetchPending { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (AccountAnalyticDistributionModel) is commented out
    // public virtual ICollection<AccountAnalyticDistributionModel> AccountAnalyticDistributionModel { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (AccountAnalyticLine) is commented out
    // public virtual ICollection<AccountAnalyticLine> AccountAnalyticLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (AccountMoveLine) is commented out
    // public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

    // [Many2one]
    [ForeignKey("BaseUnitId")]
    public virtual WebsiteBaseUnit? BaseUnit { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (DeliveryCarrier) is commented out
    // public virtual ICollection<DeliveryCarrier> DeliveryCarrier { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (EventBoothCategory) is commented out
    // public virtual ICollection<EventBoothCategory> EventBoothCategory { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (EventBoothConfigurator) is commented out
    // public virtual ICollection<EventBoothConfigurator> EventBoothConfigurator { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (EventEventConfigurator) is commented out
    // public virtual ICollection<EventEventConfigurator> EventEventConfigurator { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (EventEventTicket) is commented out
    // public virtual ICollection<EventEventTicket> EventEventTicket { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (EventTypeTicket) is commented out
    // public virtual ICollection<EventTypeTicket> EventTypeTicket { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (HrExpense) is commented out
    // public virtual ICollection<HrExpense> HrExpense { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (HrExpenseSplit) is commented out
    // public virtual ICollection<HrExpenseSplit> HrExpenseSplit { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("DiscountLineProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("DiscountLineProduct")] // One2many // Peer relationship (LoyaltyReward) is commented out
    // public virtual ICollection<LoyaltyReward> LoyaltyRewardDiscountLineProduct { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("RewardProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("RewardProduct")] // One2many // Peer relationship (LoyaltyReward) is commented out
    // public virtual ICollection<LoyaltyReward> LoyaltyRewardRewardProduct { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (MembershipInvoice) is commented out
    // public virtual ICollection<MembershipInvoice> MembershipInvoice { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("MembershipId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Membership")] // One2many // Peer relationship (MembershipMembershipLine) is commented out
    // public virtual ICollection<MembershipMembershipLine> MembershipMembershipLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (MrpBom) is commented out
    // public virtual ICollection<MrpBom> MrpBom { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (MrpBomByproduct) is commented out
    // public virtual ICollection<MrpBomByproduct> MrpBomByproduct { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (MrpBomLine) is commented out
    // public virtual ICollection<MrpBomLine> MrpBomLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (MrpConsumptionWarningLine) is commented out
    // public virtual ICollection<MrpConsumptionWarningLine> MrpConsumptionWarningLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (MrpProduction) is commented out
    // public virtual ICollection<MrpProduction> MrpProduction { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (MrpUnbuild) is commented out
    // public virtual ICollection<MrpUnbuild> MrpUnbuild { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (MrpWorkcenterCapacity) is commented out
    // public virtual ICollection<MrpWorkcenterCapacity> MrpWorkcenterCapacity { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (MrpWorkorder) is commented out
    // public virtual ICollection<MrpWorkorder> MrpWorkorder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("DiscountProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("DiscountProduct")] // One2many // Peer relationship (PosConfig) is commented out
    // public virtual ICollection<PosConfig> PosConfigDiscountProduct { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("DownPaymentProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("DownPaymentProduct")] // One2many // Peer relationship (PosConfig) is commented out
    // public virtual ICollection<PosConfig> PosConfigDownPaymentProduct { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("TipProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("TipProduct")] // One2many // Peer relationship (PosConfig) is commented out
    // public virtual ICollection<PosConfig> PosConfigTipProduct { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (PosOrderLine) is commented out
    // public virtual ICollection<PosOrderLine> PosOrderLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (ProductComboItem) is commented out
    // public virtual ICollection<ProductComboItem> ProductComboItem { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductVariantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ProductVariant")] // One2many // Peer relationship (ProductImage) is commented out
    // public virtual ICollection<ProductImage> ProductImage { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (ProductPackaging) is commented out
    // public virtual ICollection<ProductPackaging> ProductPackaging { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (ProductPricelistItem) is commented out
    // public virtual ICollection<ProductPricelistItem> ProductPricelistItem { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (ProductReplenish) is commented out
    // public virtual ICollection<ProductReplenish> ProductReplenish { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (ProductSupplierinfo) is commented out
    // public virtual ICollection<ProductSupplierinfo> ProductSupplierinfo { get; set; }

    // [Many2one]
    [ForeignKey("ProductTmplId")]
    public virtual ProductTemplate? ProductTmpl { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (ProductWishlist) is commented out
    // public virtual ICollection<ProductWishlist> ProductWishlist { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("TimesheetProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("TimesheetProduct")] // One2many // Peer relationship (ProjectProject) is commented out
    // public virtual ICollection<ProjectProject> ProjectProject { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (PurchaseOrderLine) is commented out
    // public virtual ICollection<PurchaseOrderLine> PurchaseOrderLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (PurchaseRequisitionLine) is commented out
    // public virtual ICollection<PurchaseRequisitionLine> PurchaseRequisitionLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (RepairOrder) is commented out
    // public virtual ICollection<RepairOrder> RepairOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("SaleDiscountProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("SaleDiscountProduct")] // One2many
    // public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("PosDiscountProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("PosDiscountProduct")] // One2many // Peer relationship (ResConfigSettings) is commented out
    // public virtual ICollection<ResConfigSettings> ResConfigSettingsPosDiscountProduct { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("PosTipProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("PosTipProduct")] // One2many // Peer relationship (ResConfigSettings) is commented out
    // public virtual ICollection<ResConfigSettings> ResConfigSettingsPosTipProduct { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("SelectedProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("SelectedProduct")] // One2many // Peer relationship (SaleLoyaltyRewardWizard) is commented out
    // public virtual ICollection<SaleLoyaltyRewardWizard> SaleLoyaltyRewardWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (SaleOrderLine) is commented out
    // public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (SaleOrderOption) is commented out
    // public virtual ICollection<SaleOrderOption> SaleOrderOption { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (SaleOrderTemplateLine) is commented out
    // public virtual ICollection<SaleOrderTemplateLine> SaleOrderTemplateLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (SaleOrderTemplateOption) is commented out
    // public virtual ICollection<SaleOrderTemplateOption> SaleOrderTemplateOption { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (SlideChannel) is commented out
    // public virtual ICollection<SlideChannel> SlideChannel { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (StockChangeProductQty) is commented out
    // public virtual ICollection<StockChangeProductQty> StockChangeProductQty { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (StockLandedCostLines) is commented out
    // public virtual ICollection<StockLandedCostLines> StockLandedCostLines { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (StockLot) is commented out
    // public virtual ICollection<StockLot> StockLot { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (StockMove) is commented out
    // public virtual ICollection<StockMove> StockMove { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (StockMoveLine) is commented out
    // public virtual ICollection<StockMoveLine> StockMoveLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (StockPutawayRule) is commented out
    // public virtual ICollection<StockPutawayRule> StockPutawayRule { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (StockQuant) is commented out
    // public virtual ICollection<StockQuant> StockQuant { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (StockReplenishmentOption) is commented out
    // public virtual ICollection<StockReplenishmentOption> StockReplenishmentOption { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (StockReturnPickingLine) is commented out
    // public virtual ICollection<StockReturnPickingLine> StockReturnPickingLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (StockRulesReport) is commented out
    // public virtual ICollection<StockRulesReport> StockRulesReport { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (StockScrap) is commented out
    // public virtual ICollection<StockScrap> StockScrap { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (StockStorageCategoryCapacity) is commented out
    // public virtual ICollection<StockStorageCategoryCapacity> StockStorageCategoryCapacity { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (StockTrackLine) is commented out
    // public virtual ICollection<StockTrackLine> StockTrackLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (StockValuationAdjustmentLines) is commented out
    // public virtual ICollection<StockValuationAdjustmentLines> StockValuationAdjustmentLines { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (StockValuationLayer) is commented out
    // public virtual ICollection<StockValuationLayer> StockValuationLayer { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (StockValuationLayerRevaluation) is commented out
    // public virtual ICollection<StockValuationLayerRevaluation> StockValuationLayerRevaluation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (StockWarehouseOrderpoint) is commented out
    // public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoint { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (StockWarnInsufficientQtyRepair) is commented out
    // public virtual ICollection<StockWarnInsufficientQtyRepair> StockWarnInsufficientQtyRepair { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (StockWarnInsufficientQtyScrap) is commented out
    // public virtual ICollection<StockWarnInsufficientQtyScrap> StockWarnInsufficientQtyScrap { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (StockWarnInsufficientQtyUnbuild) is commented out
    // public virtual ICollection<StockWarnInsufficientQtyUnbuild> StockWarnInsufficientQtyUnbuild { get; set; }

    // [Many2one]
    [ForeignKey("VariantRibbonId")]
    public virtual ProductRibbon? VariantRibbon { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (WebsiteTrack) is commented out
    // public virtual ICollection<WebsiteTrack> WebsiteTrack { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductProductId")] //Many2many // Hidden
    // [InverseProperty("ProductProduct")] //Many2many // Hidden
    public virtual ICollection<LoyaltyReward> LoyaltyReward { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductProductId")] //Many2many // Hidden
    // [InverseProperty("ProductProduct")] //Many2many // Hidden
    public virtual ICollection<LoyaltyRule> LoyaltyRule { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductProductId")] //Many2many // Hidden
    // [InverseProperty("ProductProduct")] //Many2many // Hidden
    public virtual ICollection<ProductFetchImageWizard> ProductFetchImageWizard { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductProductId")] //Many2many // Hidden
    // [InverseProperty("ProductProduct")] //Many2many // Hidden
    public virtual ICollection<ProductLabelLayout> ProductLabelLayout { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ProductProductId")] // Many2many // Normal
    // [InverseProperty("ProductProduct")] // Many2many // Normal
    public virtual ICollection<ProductTag> ProductTag { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ProductProductId")] // Many2many // Normal
    // [InverseProperty("ProductProduct")] // Many2many // Normal
    public virtual ICollection<ProductTemplateAttributeValue> ProductTemplateAttributeValue { get; set; }

    // [Many2many] // Normal
    [NotMapped] // Many2many // Peer relationship (ResPartner) is commented out
    // [ForeignKey("ProductProductId")] // Many2many // Normal
    // [InverseProperty("ProductProduct")] // Many2many // Normal
    public virtual ICollection<ResPartner> ResPartner { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("DestId")] //Many2many // Hidden
    // [InverseProperty("Dest")] //Many2many // Hidden
    public virtual ICollection<ProductTemplate> Src { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductProductId")] //Many2many // Hidden
    // [InverseProperty("ProductProduct")] //Many2many // Hidden
    public virtual ICollection<StockTrackConfirmation> StockTrackConfirmation { get; set; }
}
