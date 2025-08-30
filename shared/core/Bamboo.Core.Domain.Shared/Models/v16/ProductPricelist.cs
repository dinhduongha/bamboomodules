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

    [JsonField(IsSparse = false)] // Name
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

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
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CurrencyId")]
    public virtual ResCurrency? Currency { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PricelistId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Pricelist")] // One2many
    public virtual ICollection<PosConfig> PosConfig { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PricelistId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Pricelist")] // One2many
    public virtual ICollection<PosOrder> PosOrder { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PricelistId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Pricelist")] // One2many
    public virtual ICollection<ProductLabelLayout> ProductLabelLayout { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("BasePricelistId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("BasePricelist")] // One2many
    public virtual ICollection<ProductPricelistItem> ProductPricelistItemBasePricelist { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PricelistId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Pricelist")] // One2many
    public virtual ICollection<ProductPricelistItem> ProductPricelistItemPricelist { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PricelistId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Pricelist")] // One2many
    public virtual ICollection<ProductWishlist> ProductWishlist { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PosPricelistId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PosPricelist")] // One2many
    public virtual ICollection<ResConfigSettings> ResConfigSettingsNavigation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PricelistId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Pricelist")] // One2many
    public virtual ICollection<SaleOrder> SaleOrder { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("WebsiteId")]
    public virtual Website? Website { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductPricelistId")] //Many2many // Hidden
    // [InverseProperty("ProductPricelist")] //Many2many // Hidden
    public virtual ICollection<LoyaltyProgram> LoyaltyProgram { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductPricelistId")] //Many2many // Hidden
    // [InverseProperty("ProductPricelist")] //Many2many // Hidden
    public virtual ICollection<PosConfig> PosConfigNavigation { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductPricelistId")] //Many2many // Hidden
    // [InverseProperty("ProductPricelist")] //Many2many // Hidden
    public virtual ICollection<ResConfigSettings> ResConfigSettings { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("PricelistId")] // Many2many // Normal
    // [InverseProperty("Pricelist")] // Many2many // Normal
    public virtual ICollection<ResCountryGroup> ResCountryGroup { get; set; }
}
