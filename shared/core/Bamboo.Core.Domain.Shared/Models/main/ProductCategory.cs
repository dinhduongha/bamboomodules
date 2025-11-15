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

[Table("product_category")]
//[Index("ParentId", Name = "product_category__parent_id_index")]
//[Index("ParentPath", Name = "product_category__parent_path_index")]
public partial class ProductCategory : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("complete_name")]
    public string? CompleteName { get; set; }

    [Column("parent_path")]
    public string? ParentPath { get; set; }

    [JsonField] // ProductPropertiesDefinition
    [Column("product_properties_definition", TypeName = "jsonb")]
    public JsonElement? ProductPropertiesDefinition { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [JsonField] // PropertyAccountIncomeCategId
    [Column("property_account_income_categ_id", TypeName = "jsonb")]
    public JsonElement? PropertyAccountIncomeCategId { get; set; }

    [JsonField] // PropertyAccountExpenseCategId
    [Column("property_account_expense_categ_id", TypeName = "jsonb")]
    public JsonElement? PropertyAccountExpenseCategId { get; set; }

    [JsonField] // PropertyAccountDownpaymentCategId
    [Column("property_account_downpayment_categ_id", TypeName = "jsonb")]
    public JsonElement? PropertyAccountDownpaymentCategId { get; set; }

    [Column("removal_strategy_id")]
    public Guid? RemovalStrategyId { get; set; }

    [Column("packaging_reserve_method")]
    public string? PackagingReserveMethod { get; set; }

    [JsonField] // PropertyValuation
    [Column("property_valuation", TypeName = "jsonb")]
    public JsonElement? PropertyValuation { get; set; }

    [JsonField] // PropertyCostMethod
    [Column("property_cost_method", TypeName = "jsonb")]
    public JsonElement? PropertyCostMethod { get; set; }

    [JsonField] // PropertyStockJournal
    [Column("property_stock_journal", TypeName = "jsonb")]
    public JsonElement? PropertyStockJournal { get; set; }

    [JsonField] // PropertyStockAccountInputCategId
    [Column("property_stock_account_input_categ_id", TypeName = "jsonb")]
    public JsonElement? PropertyStockAccountInputCategId { get; set; }

    [JsonField] // PropertyStockAccountOutputCategId
    [Column("property_stock_account_output_categ_id", TypeName = "jsonb")]
    public JsonElement? PropertyStockAccountOutputCategId { get; set; }

    [JsonField] // PropertyStockValuationAccountId
    [Column("property_stock_valuation_account_id", TypeName = "jsonb")]
    public JsonElement? PropertyStockValuationAccountId { get; set; }

    [JsonField] // PropertyAccountCreditorPriceDifferenceCateg
    [Column("property_account_creditor_price_difference_categ", TypeName = "jsonb")]
    public JsonElement? PropertyAccountCreditorPriceDifferenceCateg { get; set; }

    [JsonField] // PropertyStockAccountProductionCostId
    [Column("property_stock_account_production_cost_id", TypeName = "jsonb")]
    public JsonElement? PropertyStockAccountProductionCostId { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProductCategId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ProductCateg")] // One2many
    public virtual ICollection<AccountAnalyticApplicability> AccountAnalyticApplicability { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProductCategId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ProductCateg")] // One2many
    public virtual ICollection<AccountAnalyticDistributionModel> AccountAnalyticDistributionModel { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ParentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Parent")] // One2many
    public virtual ICollection<ProductCategory> InverseParent { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DiscountProductCategoryId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("DiscountProductCategory")] // One2many
    public virtual ICollection<LoyaltyReward> LoyaltyReward { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProductCategoryId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ProductCategory")] // One2many
    public virtual ICollection<LoyaltyRule> LoyaltyRule { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ParentId")]
    public virtual ProductCategory? Parent { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CategId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Categ")] // One2many
    public virtual ICollection<ProductPricelistItem> ProductPricelistItem { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CategId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Categ")] // One2many
    public virtual ICollection<ProductTemplate> ProductTemplate { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("RemovalStrategyId")]
    public virtual ProductRemoval? RemovalStrategy { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CategoryId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Category")] // One2many
    public virtual ICollection<StockPutawayRule> StockPutawayRule { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CategId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Categ")] // One2many
    public virtual ICollection<StockValuationLayer> StockValuationLayer { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProductCategoryId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ProductCategory")] // One2many
    public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoint { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("CategId")] //Many2many // Hidden
    // [InverseProperty("Categ")] //Many2many // Hidden
    public virtual ICollection<StockRoute> Route { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductCategoryId")] //Many2many // Hidden
    // [InverseProperty("ProductCategory")] //Many2many // Hidden
    public virtual ICollection<StockPickingType> StockPickingType { get; set; }
}
