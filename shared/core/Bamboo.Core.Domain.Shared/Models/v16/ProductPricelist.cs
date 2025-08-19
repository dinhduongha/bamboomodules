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

[Table("product_pricelist")]
public partial class ProductPricelist: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("discount_policy")]
    public string? DiscountPolicy { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("selectable")]
    public bool? Selectable { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("ProductPricelist")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ProductPricelistCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CurrencyId")]
    // [InverseProperty("ProductPricelist")] //Many2one
    public virtual ResCurrency? Currency { get; set; }

    // [One2many]
    [ForeignKey("PricelistId")]
    [InverseProperty("Pricelist")]
    public virtual ICollection<PosConfig> PosConfig { get; set; }

    // [One2many]
    [ForeignKey("PricelistId")]
    [InverseProperty("Pricelist")]
    public virtual ICollection<PosOrder> PosOrder { get; set; }

    // [One2many]
    [ForeignKey("PricelistId")]
    [InverseProperty("Pricelist")]
    public virtual ICollection<ProductLabelLayout> ProductLabelLayout { get; set; }

    // [One2many]
    [ForeignKey("BasePricelistId")]
    [InverseProperty("BasePricelist")]
    public virtual ICollection<ProductPricelistItem> ProductPricelistItemBasePricelist { get; set; }

    // [One2many]
    [ForeignKey("PricelistId")]
    [InverseProperty("Pricelist")]
    public virtual ICollection<ProductPricelistItem> ProductPricelistItemPricelist { get; set; }

    // [One2many]
    [ForeignKey("PricelistId")]
    [InverseProperty("Pricelist")]
    public virtual ICollection<ProductWishlist> ProductWishlist { get; set; }

    // [One2many]
    [ForeignKey("PricelistId")]
    [InverseProperty("Pricelist")]
    public virtual ICollection<RepairOrder> RepairOrder { get; set; }

    // [One2many]
    [ForeignKey("PosPricelistId")]
    [InverseProperty("PosPricelist")]
    public virtual ICollection<ResConfigSettings> ResConfigSettingsNavigation { get; set; }

    // [One2many]
    [ForeignKey("PricelistId")]
    [InverseProperty("Pricelist")]
    public virtual ICollection<SaleOrder> SaleOrder { get; set; }

    // [Many2one]
    [ForeignKey("WebsiteId")]
    // [InverseProperty("ProductPricelist")] //Many2one
    public virtual Website? Website { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ProductPricelistWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductPricelistId")]
    // [InverseProperty("ProductPricelist")]
    public virtual ICollection<LoyaltyProgram> LoyaltyProgram { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductPricelistId")]
    // [InverseProperty("ProductPricelist")]
    public virtual ICollection<PosConfig> PosConfigNavigation { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductPricelistId")]
    // [InverseProperty("ProductPricelist")]
    public virtual ICollection<ResConfigSettings> ResConfigSettings { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("PricelistId")] //Many2many
    // [InverseProperty("Pricelist")] //Many2many
    public virtual ICollection<ResCountryGroup> ResCountryGroup { get; set; }
}
