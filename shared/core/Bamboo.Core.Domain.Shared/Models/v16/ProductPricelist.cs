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
public partial class ProductPricelist: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    // v16-Compat
    [Column("discount_policy")]
    public string? DiscountPolicy { get; set; }

    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("selectable")]
    public bool? Selectable { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("ProductPricelists")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ProductPricelistCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CurrencyId")]
    //[InverseProperty("ProductPricelists")]
    [NotMapped]
    public virtual ResCurrency? Currency { get; set; }

    [ForeignKey("WebsiteId")]
    //[InverseProperty("ProductPricelists")]
    [NotMapped]
    public virtual Website? Website { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ProductPricelistWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Pricelist")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigs { get; set; } = new List<PosConfig>();

    //[InverseProperty("Pricelist")]
    [NotMapped]
    public virtual ICollection<PosOrder> PosOrders { get; set; } = new List<PosOrder>();

    //[InverseProperty("BasePricelist")]
    [NotMapped]
    public virtual ICollection<ProductPricelistItem> ProductPricelistItemBasePricelists { get; set; } = new List<ProductPricelistItem>();

    //[InverseProperty("Pricelist")]
    [NotMapped]
    public virtual ICollection<ProductPricelistItem> ProductPricelistItemPricelists { get; set; } = new List<ProductPricelistItem>();

    //[InverseProperty("Pricelist")]
    [NotMapped]
    public virtual ICollection<RepairOrder> RepairOrders { get; set; } = new List<RepairOrder>();

    //[InverseProperty("PosPricelist")]
    [NotMapped]
    public virtual ICollection<ResConfigSetting> ResConfigSettingsNavigation { get; set; } = new List<ResConfigSetting>();

    //[InverseProperty("Pricelist")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrders { get; set; } = new List<SaleOrder>();

    [ForeignKey("ProductPricelistId")]
    //[InverseProperty("ProductPricelists")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigsNavigation { get; set; } = new List<PosConfig>();

    [ForeignKey("ProductPricelistId")]
    //[InverseProperty("ProductPricelists")]
    [NotMapped]
    public virtual ICollection<ResConfigSetting> ResConfigSettings { get; set; } = new List<ResConfigSetting>();

    [ForeignKey("PricelistId")]
    //[InverseProperty("Pricelists")]
    [NotMapped]
    public virtual ICollection<ResCountryGroup> ResCountryGroups { get; set; } = new List<ResCountryGroup>();
}
