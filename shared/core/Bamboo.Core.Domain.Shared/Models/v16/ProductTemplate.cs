using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

[Table("product_template")]
//[Index("CompanyId", Name = "product_template__company_id_index")]
//[Index("IsPublished", Name = "product_template__is_published_index")]
//[Index("WebsiteId", Name = "product_template__website_id_index")]
//[Index("WebsiteSequence", Name = "product_template__website_sequence_index")]
public partial class ProductTemplate: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("categ_id")]
    public Guid? CategId { get; set; }

    [Column("uom_id")]
    public Guid? UomId { get; set; }

    [Column("uom_po_id")]
    public Guid? UomPoId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("type")]
    public string? Type { get; set; }

    [Column("service_tracking")]
    public string? ServiceTracking { get; set; }

    [Column("default_code")]
    public string? DefaultCode { get; set; }

    [JsonField(IsSparse = false)] // Name
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [JsonField(IsSparse = false)] // Description
    [Column("description", TypeName = "jsonb")]
    public StringDictionary? Description { get; set; }

    [JsonField(IsSparse = false)] // DescriptionPurchase
    [Column("description_purchase", TypeName = "jsonb")]
    public StringDictionary? DescriptionPurchase { get; set; }

    [JsonField(IsSparse = false)] // DescriptionSale
    [Column("description_sale", TypeName = "jsonb")]
    public StringDictionary? DescriptionSale { get; set; }

    [JsonField] // ProductProperties
    [Column("product_properties", TypeName = "jsonb")]
    public JsonElement? ProductProperties { get; set; }

    [Column("list_price")]
    public decimal? ListPrice { get; set; }

    [Column("volume")]
    public decimal? Volume { get; set; }

    [Column("weight")]
    public decimal? Weight { get; set; }

    [Column("sale_ok")]
    public bool? SaleOk { get; set; }

    [Column("purchase_ok")]
    public bool? PurchaseOk { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("can_image_1024_be_zoomed")]
    public bool? CanImage1024BeZoomed { get; set; }

    [Column("has_configurable_attributes")]
    public bool? HasConfigurableAttributes { get; set; }

    [Column("is_favorite")]
    public bool? IsFavorite { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [JsonField] // PropertyAccountIncomeId
    [Column("property_account_income_id", TypeName = "jsonb")]
    public JsonElement? PropertyAccountIncomeId { get; set; }

    [JsonField] // PropertyAccountExpenseId
    [Column("property_account_expense_id", TypeName = "jsonb")]
    public JsonElement? PropertyAccountExpenseId { get; set; }

    [Column("service_type")]
    public string? ServiceType { get; set; }

    [Column("sale_line_warn")]
    public string? SaleLineWarn { get; set; }

    [Column("expense_policy")]
    public string? ExpensePolicy { get; set; }

    [Column("invoice_policy")]
    public string? InvoicePolicy { get; set; }

    [Column("sale_line_warn_msg")]
    public string? SaleLineWarnMsg { get; set; }

    [Column("sale_delay")]
    public long? SaleDelay { get; set; }

    [Column("tracking")]
    public string? Tracking { get; set; }

    [JsonField] // ResponsibleId
    [Column("responsible_id", TypeName = "jsonb")]
    public JsonElement? ResponsibleId { get; set; }

    [JsonField] // PropertyStockProduction
    [Column("property_stock_production", TypeName = "jsonb")]
    public JsonElement? PropertyStockProduction { get; set; }

    [JsonField] // PropertyStockInventory
    [Column("property_stock_inventory", TypeName = "jsonb")]
    public JsonElement? PropertyStockInventory { get; set; }

    [JsonField(IsSparse = false)] // DescriptionPicking
    [Column("description_picking", TypeName = "jsonb")]
    public StringDictionary? DescriptionPicking { get; set; }

    [JsonField(IsSparse = false)] // DescriptionPickingout
    [Column("description_pickingout", TypeName = "jsonb")]
    public StringDictionary? DescriptionPickingout { get; set; }

    [JsonField(IsSparse = false)] // DescriptionPickingin
    [Column("description_pickingin", TypeName = "jsonb")]
    public StringDictionary? DescriptionPickingin { get; set; }

    [Column("is_storable")]
    public bool? IsStorable { get; set; }

    [Column("lot_valuated")]
    public bool? LotValuated { get; set; }

    [JsonField(IsSparse = false)] // PublicDescription
    [Column("public_description", TypeName = "jsonb")]
    public StringDictionary? PublicDescription { get; set; }

    [Column("available_in_pos")]
    public bool? AvailableInPos { get; set; }

    [Column("to_weight")]
    public bool? ToWeight { get; set; }

    [Column("self_order_available")]
    public bool? SelfOrderAvailable { get; set; }

    [Column("purchase_method")]
    public string? PurchaseMethod { get; set; }

    [Column("purchase_line_warn")]
    public string? PurchaseLineWarn { get; set; }

    [Column("purchase_line_warn_msg")]
    public string? PurchaseLineWarnMsg { get; set; }

    [JsonField] // PropertyAccountCreditorPriceDifference
    [Column("property_account_creditor_price_difference", TypeName = "jsonb")]
    public JsonElement? PropertyAccountCreditorPriceDifference { get; set; }

    [JsonField] // ServiceToPurchase
    [Column("service_to_purchase", TypeName = "jsonb")]
    public JsonElement? ServiceToPurchase { get; set; }

    [Column("create_repair")]
    public bool? CreateRepair { get; set; }

    [JsonField] // AssetCategoryId
    [Column("asset_category_id", TypeName = "jsonb")]
    public JsonElement? AssetCategoryId { get; set; }

    [JsonField] // DeferredRevenueCategoryId
    [Column("deferred_revenue_category_id", TypeName = "jsonb")]
    public JsonElement? DeferredRevenueCategoryId { get; set; }

    [Column("can_be_expensed")]
    public bool? CanBeExpensed { get; set; }

    [JsonField] // ProjectId
    [Column("project_id", TypeName = "jsonb")]
    public JsonElement? ProjectId { get; set; }

    [JsonField] // ProjectTemplateId
    [Column("project_template_id", TypeName = "jsonb")]
    public JsonElement? ProjectTemplateId { get; set; }

    [Column("country_of_origin")]
    public Guid? CountryOfOrigin { get; set; }

    [Column("hs_code")]
    public string? HsCode { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("website_size_x")]
    public long? WebsiteSizeX { get; set; }

    [Column("website_size_y")]
    public long? WebsiteSizeY { get; set; }

    [Column("website_ribbon_id")]
    public Guid? WebsiteRibbonId { get; set; }

    [Column("website_sequence")]
    public long? WebsiteSequence { get; set; }

    [Column("base_unit_id")]
    public Guid? BaseUnitId { get; set; }

    [Column("website_meta_og_img")]
    public string? WebsiteMetaOgImg { get; set; }

    [JsonField(IsSparse = false)] // WebsiteMetaTitle
    [Column("website_meta_title", TypeName = "jsonb")]
    public StringDictionary? WebsiteMetaTitle { get; set; }

    [JsonField(IsSparse = false)] // WebsiteMetaDescription
    [Column("website_meta_description", TypeName = "jsonb")]
    public StringDictionary? WebsiteMetaDescription { get; set; }

    [JsonField] // WebsiteMetaKeywords
    [Column("website_meta_keywords", TypeName = "jsonb")]
    public JsonElement? WebsiteMetaKeywords { get; set; }

    [JsonField(IsSparse = false)] // SeoName
    [Column("seo_name", TypeName = "jsonb")]
    public StringDictionary? SeoName { get; set; }

    [JsonField(IsSparse = false)] // WebsiteDescription
    [Column("website_description", TypeName = "jsonb")]
    public StringDictionary? WebsiteDescription { get; set; }

    [JsonField(IsSparse = false)] // DescriptionEcommerce
    [Column("description_ecommerce", TypeName = "jsonb")]
    public StringDictionary? DescriptionEcommerce { get; set; }

    [Column("compare_list_price")]
    public decimal? CompareListPrice { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    [Column("rating_last_value")]
    public double? RatingLastValue { get; set; }

    [Column("base_unit_count")]
    public double? BaseUnitCount { get; set; }

    [JsonField(IsSparse = false)] // OutOfStockMessage
    [Column("out_of_stock_message", TypeName = "jsonb")]
    public StringDictionary? OutOfStockMessage { get; set; }

    [Column("allow_out_of_stock_order")]
    public bool? AllowOutOfStockOrder { get; set; }

    [Column("show_availability")]
    public bool? ShowAvailability { get; set; }

    [Column("available_threshold")]
    public double? AvailableThreshold { get; set; }

    [Column("split_method_landed_cost")]
    public string? SplitMethodLandedCost { get; set; }

    [Column("landed_cost_ok")]
    public bool? LandedCostOk { get; set; }

    [Column("membership_date_from")]
    public DateTime? MembershipDateFrom { get; set; }

    [Column("membership_date_to")]
    public DateTime? MembershipDateTo { get; set; }

    [Column("membership")]
    public bool? Membership { get; set; }

    [Column("service_upsell_threshold")]
    public double? ServiceUpsellThreshold { get; set; }

    [Column("expiration_time")]
    public long? ExpirationTime { get; set; }

    [Column("use_time")]
    public long? UseTime { get; set; }

    [Column("removal_time")]
    public long? RemovalTime { get; set; }

    [Column("alert_time")]
    public long? AlertTime { get; set; }

    [Column("use_expiration_date")]
    public bool? UseExpirationDate { get; set; }

    [Column("product_add_mode")]
    public string? ProductAddMode { get; set; }

    [Column("email_template_id")]
    public Guid? EmailTemplateId { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("BaseUnitId")]
    public virtual WebsiteBaseUnit? BaseUnit { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CategId")]
    public virtual ProductCategory? Categ { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CountryOfOrigin")]
    public virtual ResCountry? CountryOfOriginNavigation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("EmailTemplateId")]
    public virtual MailTemplate? EmailTemplate { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProductTmplId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ProductTmpl")] // One2many
    public virtual ICollection<MrpBom> MrpBom { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProductTmplId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ProductTmpl")] // One2many
    public virtual ICollection<MrpBomLine> MrpBomLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProductTmplId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ProductTmpl")] // One2many
    public virtual ICollection<ProductImage> ProductImage { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProductTmplId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ProductTmpl")] // One2many
    public virtual ICollection<ProductPricelistItem> ProductPricelistItem { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProductTmplId")]
    [NotMapped] // One2many // Peer relationship (ProductProduct) is commented out
    // [InverseProperty("ProductTmpl")] // One2many
    public virtual ICollection<ProductProduct> ProductProduct { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProductTmplId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ProductTmpl")] // One2many
    public virtual ICollection<ProductReplenish> ProductReplenish { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProductTmplId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ProductTmpl")] // One2many
    public virtual ICollection<ProductSupplierinfo> ProductSupplierinfo { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProductTmplId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ProductTmpl")] // One2many
    public virtual ICollection<ProductTemplateAttributeExclusion> ProductTemplateAttributeExclusion { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProductTmplId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ProductTmpl")] // One2many
    public virtual ICollection<ProductTemplateAttributeLine> ProductTemplateAttributeLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProductTmplId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ProductTmpl")] // One2many
    public virtual ICollection<ProductTemplateAttributeValue> ProductTemplateAttributeValue { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProductTmplId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ProductTmpl")] // One2many
    public virtual ICollection<StockChangeProductQty> StockChangeProductQty { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProductTmplId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ProductTmpl")] // One2many
    public virtual ICollection<StockRulesReport> StockRulesReport { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UomId")]
    public virtual UomUom? Uom { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UomPoId")]
    public virtual UomUom? UomPo { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("WebsiteId")]
    public virtual Website? Website { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("WebsiteRibbonId")]
    public virtual ProductRibbon? WebsiteRibbon { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ProductTemplateId")] // Many2many // Normal
    // [InverseProperty("ProductTemplate")] // Many2many // Normal
    public virtual ICollection<AccountAccountTag> AccountAccountTag { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (ProductProduct) is commented out
    // [ForeignKey("SrcId")] // Many2many // Normal
    // [InverseProperty("Src")] // Many2many // Normal
    public virtual ICollection<ProductProduct> Dest { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("SrcId")] // Many2many // Normal
    // [InverseProperty("SrcNavigation")] // Many2many // Normal
    public virtual ICollection<ProductTemplate> Dest1 { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("SrcId")] // Many2many // Normal
    // [InverseProperty("Src")] // Many2many // Normal
    public virtual ICollection<ProductTemplate> DestNavigation { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ProductTemplateId")] // Many2many // Normal
    // [InverseProperty("ProductTemplate")] // Many2many // Normal
    public virtual ICollection<PosCategory> PosCategory { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductTemplateId")] //Many2many // Hidden
    // [InverseProperty("ProductTemplate")] //Many2many // Hidden
    public virtual ICollection<ProductAttribute> ProductAttribute { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ProductTemplateId")] // Many2many // Normal
    // [InverseProperty("ProductTemplate")] // Many2many // Normal
    public virtual ICollection<ProductCombo> ProductCombo { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductTemplateId")] //Many2many // Hidden
    // [InverseProperty("ProductTemplate")] //Many2many // Hidden
    public virtual ICollection<ProductLabelLayout> ProductLabelLayout { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductTemplateId")] //Many2many // Hidden
    // [InverseProperty("ProductTemplate")] //Many2many // Hidden
    public virtual ICollection<ProductPublicCategory> ProductPublicCategory { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ProductTemplateId")] // Many2many // Normal
    // [InverseProperty("ProductTemplate")] // Many2many // Normal
    public virtual ICollection<ProductTag> ProductTag { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductId")] //Many2many // Hidden
    // [InverseProperty("Product")] //Many2many // Hidden
    public virtual ICollection<StockRoute> Route { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("DestId")] // Many2many // Normal
    // [InverseProperty("DestNavigation")] // Many2many // Normal
    public virtual ICollection<ProductTemplate> Src { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("DestId")] // Many2many // Normal
    // [InverseProperty("Dest1")] // Many2many // Normal
    public virtual ICollection<ProductTemplate> SrcNavigation { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ProdId")] // Many2many // Normal
    // [InverseProperty("Prod")] // Many2many // Normal
    public virtual ICollection<AccountTax> Tax { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ProdId")] // Many2many // Normal
    // [InverseProperty("ProdNavigation")] // Many2many // Normal
    public virtual ICollection<AccountTax> TaxNavigation { get; set; }
}
