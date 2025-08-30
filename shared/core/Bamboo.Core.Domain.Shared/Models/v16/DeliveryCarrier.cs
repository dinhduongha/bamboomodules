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

[Table("delivery_carrier")]
//[Index("IsPublished", Name = "delivery_carrier__is_published_index")]
//[Index("WebsiteId", Name = "delivery_carrier__website_id_index")]
public partial class DeliveryCarrier: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("shipping_insurance")]
    public long? ShippingInsurance { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("delivery_type")]
    public string? DeliveryType { get; set; }

    [Column("integration_level")]
    public string? IntegrationLevel { get; set; }

    [Column("tracking_url")]
    public string? TrackingUrl { get; set; }

    [Column("invoice_policy")]
    public string? InvoicePolicy { get; set; }

    [JsonField(IsSparse = false)] // Name
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [JsonField(IsSparse = false)] // CarrierDescription
    [Column("carrier_description", TypeName = "jsonb")]
    public StringDictionary? CarrierDescription { get; set; }

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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

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

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CarrierId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Carrier")] // One2many
    public virtual ICollection<ChooseDeliveryCarrier> ChooseDeliveryCarrier { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CarrierId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Carrier")] // One2many
    public virtual ICollection<DeliveryPriceRule> DeliveryPriceRule { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductId")]
    public virtual ProductProduct? Product { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CarrierId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Carrier")] // One2many
    public virtual ICollection<SaleOrder> SaleOrder { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CarrierId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Carrier")] // One2many
    public virtual ICollection<StockMoveLine> StockMoveLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CarrierId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Carrier")] // One2many
    public virtual ICollection<StockPicking> StockPicking { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("WebsiteId")]
    public virtual Website? Website { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (ResCountry) is commented out
    // [ForeignKey("CarrierId")] // Many2many // Normal
    // [InverseProperty("Carrier")] // Many2many // Normal
    public virtual ICollection<ResCountry> Country { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("DeliveryCarrierId")] // Many2many // Normal
    // [InverseProperty("DeliveryCarrier")] // Many2many // Normal
    public virtual ICollection<ProductTag> ProductTag { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("DeliveryCarrierId")] // Many2many // Normal
    // [InverseProperty("DeliveryCarrierNavigation")] // Many2many // Normal
    public virtual ICollection<ProductTag> ProductTagNavigation { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ShippingId")] // Many2many // Normal
    // [InverseProperty("Shipping")] // Many2many // Normal
    public virtual ICollection<StockRoute> Route { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (ResCountryState) is commented out
    // [ForeignKey("CarrierId")] // Many2many // Normal
    // [InverseProperty("Carrier")] // Many2many // Normal
    public virtual ICollection<ResCountryState> State { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("DeliveryCarrierId")] // Many2many // Normal
    // [InverseProperty("DeliveryCarrier")] // Many2many // Normal
    public virtual ICollection<StockWarehouse> StockWarehouse { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("CarrierId")] // Many2many // Normal
    // [InverseProperty("Carrier")] // Many2many // Normal
    public virtual ICollection<DeliveryZipPrefix> ZipPrefix { get; set; }
}
