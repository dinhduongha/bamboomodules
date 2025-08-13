using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
//[Index("IsPublished", Name = "delivery_carrier_is_published_index")]
//[Index("WebsiteId", Name = "delivery_carrier_website_id_index")]
public partial class DeliveryCarrier : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("invoice_policy")]
    public string? InvoicePolicy { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

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

    [Column("margin")]
    public double? Margin { get; set; }

    [Column("amount")]
    public double? Amount { get; set; }

    [Column("fixed_price")]
    public double? FixedPrice { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    [Column("warehouse_id")]
    public Guid? WarehouseId { get; set; }


    // [Many2many]
    //[NotMapped] // Many2many
    // [InverseProperty("Carrier")] // Many2many
    //public virtual ICollection<ChooseDeliveryCarrier> ChooseDeliveryCarrier { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("DeliveryCarrier")] // [Many2one]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("DeliveryCarrierCreateU")] // [Many2one]
    public virtual ResUser? CreateU { get; set; }


    // [Many2many]
    [NotMapped] // Many2many
    // [InverseProperty("Carrier")] // Many2many
    public virtual ICollection<DeliveryPriceRule> DeliveryPriceRule { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("DeliveryCarrier")] // [Many2one]
    public virtual ProductProduct? Product { get; set; }


    // [Many2many]
    [NotMapped] // Many2many
    // [InverseProperty("Carrier")] // Many2many
    public virtual ICollection<SaleOrder> SaleOrder { get; set; }


    // [Many2many]
    [NotMapped] // Many2many
    // [InverseProperty("Carrier")] // Many2many
    public virtual ICollection<StockPicking> StockPicking { get; set; }

    // [Many2one]
    [ForeignKey("WarehouseId")]
    // [InverseProperty("DeliveryCarrier")] // [Many2one]
    public virtual StockWarehouse? Warehouse { get; set; }

    // [Many2one]
    [ForeignKey("WebsiteId")]
    // [InverseProperty("DeliveryCarrier")] // [Many2one]
    public virtual Website? Website { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("DeliveryCarrierWriteU")] // [Many2one]
    public virtual ResUser? WriteU { get; set; }

    // [One2many]
    [ForeignKey("CarrierId")]
    // [NotMapped] // One2many
    // [InverseProperty("Carrier")]  //[One2many]
    public virtual ICollection<ResCountry> Country { get; set; }

    // [One2many]
    [ForeignKey("CarrierId")]
    // [NotMapped] // One2many
    // [InverseProperty("Carrier")]  //[One2many]
    public virtual ICollection<ResCountryState> State { get; set; }

    // [One2many]
    [ForeignKey("CarrierId")]
    // [NotMapped] // One2many
    // [InverseProperty("Carrier")]  //[One2many]
    public virtual ICollection<DeliveryZipPrefix> ZipPrefix { get; set; }
}
