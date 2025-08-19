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

[Table("product_pricelist_item")]
//[Index("ComputePrice", Name = "product_pricelist_item__compute_price_index")]
//[Index("PricelistId", Name = "product_pricelist_item__pricelist_id_index")]
public partial class ProductPricelistItem: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("pricelist_id")]
    public Guid? PricelistId { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("categ_id")]
    public Guid? CategId { get; set; }

    [Column("product_tmpl_id")]
    public Guid? ProductTmplId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("base_pricelist_id")]
    public Guid? BasePricelistId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("applied_on")]
    public string? AppliedOn { get; set; }

    [Column("display_applied_on")]
    public string? DisplayAppliedOn { get; set; }

    [Column("base")]
    public string? Base { get; set; }

    [Column("compute_price")]
    public string? ComputePrice { get; set; }

    [Column("min_quantity")]
    public decimal? MinQuantity { get; set; }

    [Column("fixed_price")]
    public decimal? FixedPrice { get; set; }

    [Column("price_discount")]
    public decimal? PriceDiscount { get; set; }

    [Column("price_round")]
    public decimal? PriceRound { get; set; }

    [Column("price_surcharge")]
    public decimal? PriceSurcharge { get; set; }

    [Column("price_markup")]
    public decimal? PriceMarkup { get; set; }

    [Column("price_min_margin")]
    public decimal? PriceMinMargin { get; set; }

    [Column("price_max_margin")]
    public decimal? PriceMaxMargin { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("date_start", TypeName = "timestamp without time zone")]
    public DateTime? DateStart { get; set; }

    [Column("date_end", TypeName = "timestamp without time zone")]
    public DateTime? DateEnd { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("percent_price")]
    public double? PercentPrice { get; set; }

    // [Many2one]
    [ForeignKey("BasePricelistId")]
    // [InverseProperty("ProductPricelistItemBasePricelist")] //Many2one
    public virtual ProductPricelist? BasePricelist { get; set; }

    // [Many2one]
    [ForeignKey("CategId")]
    // [InverseProperty("ProductPricelistItem")] //Many2one
    public virtual ProductCategory? Categ { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("ProductPricelistItem")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ProductPricelistItemCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CurrencyId")]
    // [InverseProperty("ProductPricelistItem")] //Many2one
    public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    [ForeignKey("PricelistId")]
    // [InverseProperty("ProductPricelistItemPricelist")] //Many2one
    public virtual ProductPricelist? Pricelist { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("ProductPricelistItem")] //Many2one
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [ForeignKey("ProductTmplId")]
    // [InverseProperty("ProductPricelistItem")] //Many2one
    public virtual ProductTemplate? ProductTmpl { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ProductPricelistItemWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
