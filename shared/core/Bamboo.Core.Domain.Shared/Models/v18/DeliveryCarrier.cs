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

[Table("delivery_carrier")]
//[Index("IsPublished", Name = "delivery_carrier__is_published_index")]
//[Index("WebsiteId", Name = "delivery_carrier__website_id_index")]
public partial class DeliveryCarrier: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("shipping_insurance")]
    public long? ShippingInsurance { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("delivery_type")]
    public string? DeliveryType { get; set; }

    [Column("integration_level")]
    public string? IntegrationLevel { get; set; }

    [Column("tracking_url")]
    public string? TrackingUrl { get; set; }

    [Column("invoice_policy")]
    public string? InvoicePolicy { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [JsonField]
    [Column("carrier_description", TypeName = "jsonb")]
    public string? CarrierDescription { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("prod_environment")]
    public bool? ProdEnvironment { get; set; }

    [Column("debug_logging")]
    public bool? DebugLogging { get; set; }

    [Column("free_over")]
    public bool? FreeOver { get; set; }

    [Column("return_label_on_delivery")]
    public bool? ReturnLabelOnDelivery { get; set; }

    [Column("get_return_label_from_portal")]
    public bool? GetReturnLabelFromPortal { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("max_weight")]
    public double? MaxWeight { get; set; }

    [Column("max_volume")]
    public double? MaxVolume { get; set; }

    [Column("margin")]
    public double? Margin { get; set; }

    [Column("fixed_margin")]
    public double? FixedMargin { get; set; }

    [Column("amount")]
    public double? Amount { get; set; }

    [Column("fixed_price")]
    public double? FixedPrice { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    //[InverseProperty("Carrier")]
    [NotMapped]
    public virtual ICollection<ChooseDeliveryCarrier> ChooseDeliveryCarriers { get; set; } = new List<ChooseDeliveryCarrier>();

    [ForeignKey("CompanyId")]
    //[InverseProperty("DeliveryCarriers")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("DeliveryCarrierCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("Carrier")]
    [NotMapped]
    public virtual ICollection<DeliveryPriceRule> DeliveryPriceRules { get; set; } = new List<DeliveryPriceRule>();

    [ForeignKey("ProductId")]
    //[InverseProperty("DeliveryCarriers")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    //[InverseProperty("Carrier")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrders { get; set; } = new List<SaleOrder>();

    //[InverseProperty("Carrier")]
    [NotMapped]
    public virtual ICollection<StockMoveLine> StockMoveLines { get; set; } = new List<StockMoveLine>();

    //[InverseProperty("Carrier")]
    [NotMapped]
    public virtual ICollection<StockPicking> StockPickings { get; set; } = new List<StockPicking>();

    [ForeignKey("WebsiteId")]
    //[InverseProperty("DeliveryCarriers")]
    [NotMapped]
    public virtual Website? Website { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("DeliveryCarrierWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("CarrierId")]
    //[InverseProperty("Carriers")]
    [NotMapped]
    public virtual ICollection<ResCountry> Countries { get; set; } = new List<ResCountry>();

    //[ForeignKey("DeliveryCarrierId")]
    //[InverseProperty("DeliveryCarriers")]
    [NotMapped]
    public virtual ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();

    //[ForeignKey("DeliveryCarrierId")]
    //[InverseProperty("DeliveryCarriersNavigation")]
    [NotMapped]
    public virtual ICollection<ProductTag> ProductTagsNavigation { get; set; } = new List<ProductTag>();

    [ForeignKey("ShippingId")]
    //[InverseProperty("Shippings")]
    [NotMapped]
    public virtual ICollection<StockRoute> Routes { get; set; } = new List<StockRoute>();

    [ForeignKey("CarrierId")]
    //[InverseProperty("Carriers")]
    [NotMapped]
    public virtual ICollection<ResCountryState> States { get; set; } = new List<ResCountryState>();

    [ForeignKey("CarrierId")]
    //[InverseProperty("Carriers")]
    [NotMapped]
    public virtual ICollection<DeliveryZipPrefix> ZipPrefixes { get; set; } = new List<DeliveryZipPrefix>();
}
