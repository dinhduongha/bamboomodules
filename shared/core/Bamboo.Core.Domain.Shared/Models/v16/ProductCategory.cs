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

[Table("product_category")]
//[Index("ParentId", Name = "product_category_parent_id_index")]
//[Index("ParentPath", Name = "product_category_parent_path_index")]
public partial class ProductCategory : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("complete_name")]
    public string? CompleteName { get; set; }

    [Column("parent_path")]
    public string? ParentPath { get; set; }

    [JsonField]
    [Column("product_properties_definition", TypeName = "jsonb")]
    public string? ProductPropertiesDefinition { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [JsonField]
    [Column("property_account_income_categ_id", TypeName = "jsonb")]
    public string? PropertyAccountIncomeCategId { get; set; }

    [JsonField]
    [Column("property_account_expense_categ_id", TypeName = "jsonb")]
    public string? PropertyAccountExpenseCategId { get; set; }

    [JsonField]
    [Column("property_account_downpayment_categ_id", TypeName = "jsonb")]
    public string? PropertyAccountDownpaymentCategId { get; set; }

    [Column("removal_strategy_id")]
    public Guid? RemovalStrategyId { get; set; }

    [Column("packaging_reserve_method")]
    public string? PackagingReserveMethod { get; set; }

    [JsonField]
    [Column("property_valuation", TypeName = "jsonb")]
    public string? PropertyValuation { get; set; }

    [JsonField]
    [Column("property_cost_method", TypeName = "jsonb")]
    public string? PropertyCostMethod { get; set; }

    [JsonField]
    [Column("property_stock_journal", TypeName = "jsonb")]
    public string? PropertyStockJournal { get; set; }

    [JsonField]
    [Column("property_stock_account_input_categ_id", TypeName = "jsonb")]
    public string? PropertyStockAccountInputCategId { get; set; }

    [JsonField]
    [Column("property_stock_account_output_categ_id", TypeName = "jsonb")]
    public string? PropertyStockAccountOutputCategId { get; set; }

    [JsonField]
    [Column("property_stock_valuation_account_id", TypeName = "jsonb")]
    public string? PropertyStockValuationAccountId { get; set; }

    [JsonField]
    [Column("property_account_creditor_price_difference_categ", TypeName = "jsonb")]
    public string? PropertyAccountCreditorPriceDifferenceCateg { get; set; }

    [JsonField]
    [Column("property_stock_account_production_cost_id", TypeName = "jsonb")]
    public string? PropertyStockAccountProductionCostId { get; set; }

    [ForeignKey("TenantId")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ProductCategoryCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ParentId")]
    //[InverseProperty("InverseParent")]
    [NotMapped]
    public virtual ProductCategory? Parent { get; set; }

    [ForeignKey("RemovalStrategyId")]
    //[InverseProperty("ProductCategories")]
    [NotMapped]
    public virtual ProductRemoval? RemovalStrategy { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ProductCategoryWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("ProductCateg")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticApplicability> AccountAnalyticApplicabilities { get; set; } 

    //[InverseProperty("ProductCateg")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticDistributionModel> AccountAnalyticDistributionModels { get; set; } 

    //[InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<ProductCategory> InverseParent { get; set; } 

    //[InverseProperty("Categ")]
    [NotMapped]
    public virtual ICollection<ProductPricelistItem> ProductPricelistItems { get; set; } 

    //[InverseProperty("Categ")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> ProductTemplates { get; set; } 

    //[InverseProperty("Category")]
    [NotMapped]
    public virtual ICollection<StockPutawayRule> StockPutawayRules { get; set; } 

    //[InverseProperty("ProductCategory")]
    [NotMapped]
    public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoints { get; set; } 

    [ForeignKey("CategId")]
    //[InverseProperty("Categs")]
    [NotMapped]
    public virtual ICollection<StockRoute> Routes { get; set; } 
}
