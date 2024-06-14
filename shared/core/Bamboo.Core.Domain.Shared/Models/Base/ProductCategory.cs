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
public partial class ProductCategory: Entity<long>, IEntityDto<long>
{
    [Key]
    [Column("id")]
    public long Id { get => base.Id; set => base.Id = value; }

    [Column("parent_id")]
    public long? ParentId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("complete_name")]
    public string? CompleteName { get; set; }

    [Column("parent_path")]
    public string? ParentPath { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("removal_strategy_id")]
    public Guid? RemovalStrategyId { get; set; }

    [Column("packaging_reserve_method")]
    public string? PackagingReserveMethod { get; set; }

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
    public virtual ICollection<AccountAnalyticApplicability> AccountAnalyticApplicabilities { get; } = new List<AccountAnalyticApplicability>();

    //[InverseProperty("ProductCateg")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticDistributionModel> AccountAnalyticDistributionModels { get; } = new List<AccountAnalyticDistributionModel>();

    //[InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<ProductCategory> InverseParent { get; } = new List<ProductCategory>();

    //[InverseProperty("Categ")]
    [NotMapped]
    public virtual ICollection<ProductPricelistItem> ProductPricelistItems { get; } = new List<ProductPricelistItem>();

    //[InverseProperty("Categ")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> ProductTemplates { get; } = new List<ProductTemplate>();

    //[InverseProperty("Category")]
    [NotMapped]
    public virtual ICollection<StockPutawayRule> StockPutawayRules { get; } = new List<StockPutawayRule>();

    //[InverseProperty("ProductCategory")]
    [NotMapped]
    public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoints { get; } = new List<StockWarehouseOrderpoint>();

    [ForeignKey("CategId")]
    //[InverseProperty("Categs")]
    [NotMapped]
    public virtual ICollection<StockRoute> Routes { get; } = new List<StockRoute>();
}
