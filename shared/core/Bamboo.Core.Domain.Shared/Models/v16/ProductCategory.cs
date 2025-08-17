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
public partial class ProductCategory: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

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

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("removal_strategy_id")]
    public Guid? RemovalStrategyId { get; set; }

    [Column("packaging_reserve_method")]
    public string? PackagingReserveMethod { get; set; }

    // [One2many]
    [ForeignKey("ProductCategId")]
    [InverseProperty("ProductCateg")]
    public virtual ICollection<AccountAnalyticApplicability> AccountAnalyticApplicability { get; set; }

    // [One2many]
    [ForeignKey("ProductCategId")]
    [InverseProperty("ProductCateg")]
    public virtual ICollection<AccountAnalyticDistributionModel> AccountAnalyticDistributionModel { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ProductCategoryCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("ParentId")]
    [InverseProperty("Parent")]
    public virtual ICollection<ProductCategory> InverseParent { get; set; }

    // [One2many]
    [ForeignKey("DiscountProductCategoryId")]
    [InverseProperty("DiscountProductCategory")]
    public virtual ICollection<LoyaltyReward> LoyaltyReward { get; set; }

    // [One2many]
    [ForeignKey("ProductCategoryId")]
    [InverseProperty("ProductCategory")]
    public virtual ICollection<LoyaltyRule> LoyaltyRule { get; set; }

    // [Many2one]
    [ForeignKey("ParentId")]
    // [InverseProperty("InverseParent")] //Many2one
    public virtual ProductCategory? Parent { get; set; }

    // [One2many]
    [ForeignKey("CategId")]
    [InverseProperty("Categ")]
    public virtual ICollection<ProductPricelistItem> ProductPricelistItem { get; set; }

    // [One2many]
    [ForeignKey("CategId")]
    [InverseProperty("Categ")]
    public virtual ICollection<ProductTemplate> ProductTemplate { get; set; }

    // [Many2one]
    [ForeignKey("RemovalStrategyId")]
    // [InverseProperty("ProductCategory")] //Many2one
    public virtual ProductRemoval? RemovalStrategy { get; set; }

    // [One2many]
    [ForeignKey("CategoryId")]
    [InverseProperty("Category")]
    public virtual ICollection<StockPutawayRule> StockPutawayRule { get; set; }

    // [One2many]
    [ForeignKey("ProductCategoryId")]
    [InverseProperty("ProductCategory")]
    public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoint { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ProductCategoryWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("CategId")]
    // [InverseProperty("Categ")]
    // public virtual ICollection<StockRoute> Route { get; set; }
}
