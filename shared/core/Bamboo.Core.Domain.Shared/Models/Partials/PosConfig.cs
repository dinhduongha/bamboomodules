using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("pos_config")]
public partial class PosConfig
{
    [Column("iface_start_categ_id")]
    public Guid? IfaceStartCategId { get; set; }

    [Column("limited_products_amount")]
    public long? LimitedProductsAmount { get; set; }

    [Column("limited_partners_amount")]
    public long? LimitedPartnersAmount { get; set; }

    [Column("iface_customer_facing_display_via_proxy")]
    public bool? IfaceCustomerFacingDisplayViaProxy { get; set; }

    [Column("iface_customer_facing_display_local")]
    public bool? IfaceCustomerFacingDisplayLocal { get; set; }

    [Column("start_category")]
    public bool? StartCategory { get; set; }

    [Column("module_pos_mercury")]
    public bool? ModulePosMercury { get; set; }

    [Column("limited_products_loading")]
    public bool? LimitedProductsLoading { get; set; }

    [Column("product_load_background")]
    public bool? ProductLoadBackground { get; set; }

    [Column("limited_partners_loading")]
    public bool? LimitedPartnersLoading { get; set; }

    [Column("partner_load_background")]
    public bool? PartnerLoadBackground { get; set; }

    [Column("gift_card_settings")]
    public string? GiftCardSettings { get; set; }

    [Column("iface_orderline_notes")]
    public bool? IfaceOrderlineNotes { get; set; }

    [Column("is_table_management")]
    public bool? IsTableManagement { get; set; }

    // [Column("is_order_printer")]
    // public bool? IsOrderPrinter { get; set; }

    // [Column("set_tip_after_payment")]
    // public bool? SetTipAfterPayment { get; set; }

    // [Many2one]
    [ForeignKey("IfaceStartCategId")]
    public virtual PosCategory? IfaceStartCateg { get; set; }

    // v16-Compat
    // [One2many]
    // [One2many] [ForeignKey("PosConfigId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PosConfig")] // One2many
    // public virtual ICollection<RestaurantFloor> RestaurantFloor { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ConfigId")] // Many2many // Normal
    // [InverseProperty("Config")] // Many2many // Normal
    // public virtual ICollection<RestaurantPrinter> Printer { get; set; }
}
