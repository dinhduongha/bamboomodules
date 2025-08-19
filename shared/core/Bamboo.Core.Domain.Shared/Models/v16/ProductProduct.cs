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
    

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

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
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<AccountAnalyticDistributionModel> AccountAnalyticDistributionModel { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<AccountAnalyticLine> AccountAnalyticLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

    // [Many2one]
    [ForeignKey("BaseUnitId")]
    // [InverseProperty("ProductProduct")] //Many2one
    public virtual WebsiteBaseUnit? BaseUnit { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ProductProductCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<DeliveryCarrier> DeliveryCarrier { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<EventBoothCategory> EventBoothCategory { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<EventBoothConfigurator> EventBoothConfigurator { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<EventEventConfigurator> EventEventConfigurator { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<EventEventTicket> EventEventTicket { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<EventTypeTicket> EventTypeTicket { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<HrExpense> HrExpense { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<HrExpenseSplit> HrExpenseSplit { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("DiscountLineProductId")]
    // [InverseProperty("DiscountLineProduct")]
    // public virtual ICollection<LoyaltyReward> LoyaltyRewardDiscountLineProduct { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("RewardProductId")]
    // [InverseProperty("RewardProduct")]
    // public virtual ICollection<LoyaltyReward> LoyaltyRewardRewardProduct { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<MembershipInvoice> MembershipInvoice { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("MembershipId")]
    // [InverseProperty("Membership")]
    // public virtual ICollection<MembershipMembershipLine> MembershipMembershipLine { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("ProductProduct")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<MrpBom> MrpBom { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<MrpBomByproduct> MrpBomByproduct { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<MrpBomLine> MrpBomLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<MrpConsumptionWarningLine> MrpConsumptionWarningLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<MrpProduction> MrpProduction { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<MrpUnbuild> MrpUnbuild { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<MrpWorkcenterCapacity> MrpWorkcenterCapacity { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<MrpWorkorder> MrpWorkorder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("DiscountProductId")]
    // [InverseProperty("DiscountProduct")]
    // public virtual ICollection<PosConfig> PosConfigDiscountProduct { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("DownPaymentProductId")]
    // [InverseProperty("DownPaymentProduct")]
    // public virtual ICollection<PosConfig> PosConfigDownPaymentProduct { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("TipProductId")]
    // [InverseProperty("TipProduct")]
    // public virtual ICollection<PosConfig> PosConfigTipProduct { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<PosOrderLine> PosOrderLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<ProductComboItem> ProductComboItem { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    [ForeignKey("ProductVariantId")]
    [InverseProperty("ProductVariant")]
    public virtual ICollection<ProductImage> ProductImage { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<ProductPackaging> ProductPackaging { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<ProductPricelistItem> ProductPricelistItem { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<ProductReplenish> ProductReplenish { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<ProductSupplierinfo> ProductSupplierinfo { get; set; }

    // [Many2one]
    [ForeignKey("ProductTmplId")]
    // [InverseProperty("ProductProduct")] //Many2one
    public virtual ProductTemplate? ProductTmpl { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<ProductWishlist> ProductWishlist { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<ProjectCreateSaleOrderLine> ProjectCreateSaleOrderLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("TimesheetProductId")]
    // [InverseProperty("TimesheetProduct")]
    // public virtual ICollection<ProjectProject> ProjectProject { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<PurchaseOrderLine> PurchaseOrderLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<PurchaseRequisitionLine> PurchaseRequisitionLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<RepairFee> RepairFee { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<RepairLine> RepairLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<RepairOrder> RepairOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("DepositDefaultProductId")]
    // [InverseProperty("DepositDefaultProduct")]
    // public virtual ICollection<ResConfigSettings> ResConfigSettingsDepositDefaultProduct { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("SaleDiscountProductId")]
    // [InverseProperty("SaleDiscountProduct")]
    // public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("PosDiscountProductId")]
    // [InverseProperty("PosDiscountProduct")]
    // public virtual ICollection<ResConfigSettings> ResConfigSettingsPosDiscountProduct { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("PosTipProductId")]
    // [InverseProperty("PosTipProduct")]
    // public virtual ICollection<ResConfigSettings> ResConfigSettingsPosTipProduct { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInv { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("SelectedProductId")]
    // [InverseProperty("SelectedProduct")]
    // public virtual ICollection<SaleLoyaltyRewardWizard> SaleLoyaltyRewardWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<SaleOrderOption> SaleOrderOption { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<SaleOrderTemplateLine> SaleOrderTemplateLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<SaleOrderTemplateOption> SaleOrderTemplateOption { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<SlideChannel> SlideChannel { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<StockChangeProductQty> StockChangeProductQty { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<StockLandedCostLines> StockLandedCostLines { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<StockLot> StockLot { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<StockMove> StockMove { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<StockMoveLine> StockMoveLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<StockPutawayRule> StockPutawayRule { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<StockQuant> StockQuant { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<StockReplenishmentOption> StockReplenishmentOption { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<StockReturnPickingLine> StockReturnPickingLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<StockRulesReport> StockRulesReport { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<StockScrap> StockScrap { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<StockStorageCategoryCapacity> StockStorageCategoryCapacity { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<StockTrackLine> StockTrackLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<StockValuationAdjustmentLines> StockValuationAdjustmentLines { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<StockValuationLayer> StockValuationLayer { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<StockValuationLayerRevaluation> StockValuationLayerRevaluation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoint { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<StockWarnInsufficientQtyRepair> StockWarnInsufficientQtyRepair { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<StockWarnInsufficientQtyScrap> StockWarnInsufficientQtyScrap { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<StockWarnInsufficientQtyUnbuild> StockWarnInsufficientQtyUnbuild { get; set; }

    // [Many2one]
    [ForeignKey("VariantRibbonId")]
    // [InverseProperty("ProductProduct")] //Many2one
    public virtual ProductRibbon? VariantRibbon { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [ForeignKey("ProductId")]
    // [InverseProperty("Product")]
    // public virtual ICollection<WebsiteTrack> WebsiteTrack { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ProductProductWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductProductId")]
    // [InverseProperty("ProductProduct")]
    public virtual ICollection<LoyaltyReward> LoyaltyReward { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductProductId")]
    // [InverseProperty("ProductProduct")]
    public virtual ICollection<LoyaltyRule> LoyaltyRule { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductProductId")]
    // [InverseProperty("ProductProduct")]
    public virtual ICollection<ProductFetchImageWizard> ProductFetchImageWizard { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductProductId")]
    // [InverseProperty("ProductProduct")]
    public virtual ICollection<ProductLabelLayout> ProductLabelLayout { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ProductProductId")] //Many2many
    // [InverseProperty("ProductProduct")] //Many2many
    public virtual ICollection<ProductTag> ProductTag { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ProductProductId")] //Many2many
    // [InverseProperty("ProductProduct")] //Many2many
    public virtual ICollection<ProductTemplateAttributeValue> ProductTemplateAttributeValue { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ProductProductId")] //Many2many
    // [InverseProperty("ProductProduct")] //Many2many
    public virtual ICollection<ResPartner> ResPartner { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("DestId")]
    // [InverseProperty("Dest")]
    public virtual ICollection<ProductTemplate> Src { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductProductId")]
    // [InverseProperty("ProductProduct")]
    public virtual ICollection<StockTrackConfirmation> StockTrackConfirmation { get; set; }
}
