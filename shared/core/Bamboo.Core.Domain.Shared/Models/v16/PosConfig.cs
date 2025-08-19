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

[Table("pos_config")]
public partial class PosConfig: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("picking_type_id")]
    public Guid? PickingTypeId { get; set; }

    [Column("journal_id")]
    public Guid? JournalId { get; set; }

    [Column("invoice_journal_id")]
    public Guid? InvoiceJournalId { get; set; }

    [Column("iface_start_categ_id")]
    public Guid? IfaceStartCategId { get; set; }

    [Column("sequence_id")]
    public Guid? SequenceId { get; set; }

    [Column("sequence_line_id")]
    public Guid? SequenceLineId { get; set; }

    [Column("pricelist_id")]
    public Guid? PricelistId { get; set; }

    [Column("group_pos_manager_id")]
    public Guid? GroupPosManagerId { get; set; }

    [Column("group_pos_user_id")]
    public Guid? GroupPosUserId { get; set; }

    [Column("tip_product_id")]
    public Guid? TipProductId { get; set; }

    [Column("default_fiscal_position_id")]
    public Guid? DefaultFiscalPositionId { get; set; }

    [Column("rounding_method")]
    public Guid? RoundingMethod { get; set; }

    [Column("warehouse_id")]
    public Guid? WarehouseId { get; set; }

    [Column("route_id")]
    public Guid? RouteId { get; set; }

    [Column("limited_products_amount")]
    public long? LimitedProductsAmount { get; set; }

    [Column("limited_partners_amount")]
    public long? LimitedPartnersAmount { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("access_token")]
    public string? AccessToken { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("iface_tax_included")]
    public string? IfaceTaxIncluded { get; set; }

    [Column("customer_display_type")]
    public string? CustomerDisplayType { get; set; }

    [Column("customer_display_bg_img_name")]
    public string? CustomerDisplayBgImgName { get; set; }

    [Column("proxy_ip")]
    public string? ProxyIp { get; set; }

    [Column("uuid")]
    public string? Uuid { get; set; }

    [Column("picking_policy")]
    public string? PickingPolicy { get; set; }

    [Column("receipt_header")]
    public string? ReceiptHeader { get; set; }

    [Column("receipt_footer")]
    public string? ReceiptFooter { get; set; }

    [Column("is_order_printer")]
    public bool? IsOrderPrinter { get; set; }

    [Column("iface_cashdrawer")]
    public bool? IfaceCashdrawer { get; set; }

    [Column("iface_electronic_scale")]
    public bool? IfaceElectronicScale { get; set; }

    [Column("iface_customer_facing_display_via_proxy")]
    public bool? IfaceCustomerFacingDisplayViaProxy { get; set; }

    [Column("iface_customer_facing_display_local")]
    public bool? IfaceCustomerFacingDisplayLocal { get; set; }

    [Column("iface_print_via_proxy")]
    public bool? IfacePrintViaProxy { get; set; }

    [Column("iface_scan_via_proxy")]
    public bool? IfaceScanViaProxy { get; set; }

    [Column("iface_big_scrollbars")]
    public bool? IfaceBigScrollbars { get; set; }

    [Column("iface_print_auto")]
    public bool? IfacePrintAuto { get; set; }

    [Column("iface_print_skip_screen")]
    public bool? IfacePrintSkipScreen { get; set; }

    [Column("restrict_price_control")]
    public bool? RestrictPriceControl { get; set; }

    [Column("is_margins_costs_accessible_to_every_user")]
    public bool? IsMarginsCostsAccessibleToEveryUser { get; set; }

    [Column("set_maximum_difference")]
    public bool? SetMaximumDifference { get; set; }

    [Column("basic_receipt")]
    public bool? BasicReceipt { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("iface_tipproduct")]
    public bool? IfaceTipproduct { get; set; }

    [Column("use_pricelist")]
    public bool? UsePricelist { get; set; }

    [Column("tax_regime_selection")]
    public bool? TaxRegimeSelection { get; set; }

    [Column("start_category")]
    public bool? StartCategory { get; set; }

    [Column("limit_categories")]
    public bool? LimitCategories { get; set; }

    [Column("module_pos_restaurant")]
    public bool? ModulePosRestaurant { get; set; }

    [Column("module_pos_avatax")]
    public bool? ModulePosAvatax { get; set; }

    [Column("module_pos_discount")]
    public bool? ModulePosDiscount { get; set; }

    [Column("module_pos_mercury")]
    public bool? ModulePosMercury { get; set; }

    [Column("is_posbox")]
    public bool? IsPosbox { get; set; }

    [Column("is_header_or_footer")]
    public bool? IsHeaderOrFooter { get; set; }

    [Column("module_pos_hr")]
    public bool? ModulePosHr { get; set; }

    [Column("other_devices")]
    public bool? OtherDevices { get; set; }

    [Column("cash_rounding")]
    public bool? CashRounding { get; set; }

    [Column("only_round_cash_method")]
    public bool? OnlyRoundCashMethod { get; set; }

    [Column("manual_discount")]
    public bool? ManualDiscount { get; set; }

    [Column("ship_later")]
    public bool? ShipLater { get; set; }

    [Column("auto_validate_terminal_payment")]
    public bool? AutoValidateTerminalPayment { get; set; }

    [Column("show_product_images")]
    public bool? ShowProductImages { get; set; }

    [Column("show_category_images")]
    public bool? ShowCategoryImages { get; set; }

    [Column("module_pos_sms")]
    public bool? ModulePosSms { get; set; }

    [Column("is_closing_entry_by_product")]
    public bool? IsClosingEntryByProduct { get; set; }

    [Column("order_edit_tracking")]
    public bool? OrderEditTracking { get; set; }

    [Column("orderlines_sequence_in_cart_by_category")]
    public bool? OrderlinesSequenceInCartByCategory { get; set; }

    [Column("limited_products_loading")]
    public bool? LimitedProductsLoading { get; set; }

    [Column("product_load_background")]
    public bool? ProductLoadBackground { get; set; }

    [Column("limited_partners_loading")]
    public bool? LimitedPartnersLoading { get; set; }

    [Column("partner_load_background")]
    public bool? PartnerLoadBackground { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("amount_authorized_diff")]
    public double? AmountAuthorizedDiff { get; set; }

    [Column("epson_printer_ip")]
    public string? EpsonPrinterIp { get; set; }

    [Column("crm_team_id")]
    public Guid? CrmTeamId { get; set; }

    [Column("down_payment_product_id")]
    public Guid? DownPaymentProductId { get; set; }

    [Column("gift_card_settings")]
    public string? GiftCardSettings { get; set; }

    [Column("takeaway_fp_id")]
    public Guid? TakeawayFpId { get; set; }

    [Column("iface_splitbill")]
    public bool? IfaceSplitbill { get; set; }

    [Column("iface_printbill")]
    public bool? IfacePrintbill { get; set; }

    [Column("iface_orderline_notes")]
    public bool? IfaceOrderlineNotes { get; set; }

    [Column("is_table_management")]
    public bool? IsTableManagement { get; set; }

    // [Column("is_order_printer")]
    // public bool? IsOrderPrinter { get; set; }

    [Column("set_tip_after_payment")]
    public bool? SetTipAfterPayment { get; set; }

    [Column("module_pos_restaurant_appointment")]
    public bool? ModulePosRestaurantAppointment { get; set; }

    [Column("takeaway")]
    public bool? Takeaway { get; set; }

    [Column("self_ordering_default_language_id")]
    public Guid? SelfOrderingDefaultLanguageId { get; set; }

    [Column("self_ordering_default_user_id")]
    public Guid? SelfOrderingDefaultUserId { get; set; }

    [Column("self_ordering_mode")]
    public string? SelfOrderingMode { get; set; }

    [Column("self_ordering_service_mode")]
    public string? SelfOrderingServiceMode { get; set; }

    [Column("self_ordering_pay_after")]
    public string? SelfOrderingPayAfter { get; set; }

    [Column("self_ordering_image_brand_name")]
    public string? SelfOrderingImageBrandName { get; set; }

    [Column("self_ordering_takeaway")]
    public bool? SelfOrderingTakeaway { get; set; }

    [Column("has_paper")]
    public bool? HasPaper { get; set; }

    [Column("self_order_online_payment_method_id")]
    public Guid? SelfOrderOnlinePaymentMethodId { get; set; }

    [Column("discount_product_id")]
    public Guid? DiscountProductId { get; set; }

    [Column("iface_discount")]
    public bool? IfaceDiscount { get; set; }

    [Column("discount_pc")]
    public double? DiscountPc { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("PosConfig")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("PosConfigCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CrmTeamId")]
    // [InverseProperty("PosConfig")] //Many2one
    public virtual CrmTeam? CrmTeam { get; set; }

    // [Many2one]
    [ForeignKey("DefaultFiscalPositionId")]
    // [InverseProperty("PosConfigNavigation")] //Many2one
    // [InverseProperty("PosConfigDefaultFiscalPosition")] //Many2one
    public virtual AccountFiscalPosition? DefaultFiscalPosition { get; set; }

    // [Many2one]
    [ForeignKey("DiscountProductId")]
    // [InverseProperty("PosConfigDiscountProduct")] //Many2one
    public virtual ProductProduct? DiscountProduct { get; set; }

    // [Many2one]
    [ForeignKey("DownPaymentProductId")]
    // [InverseProperty("PosConfigDownPaymentProduct")] //Many2one
    public virtual ProductProduct? DownPaymentProduct { get; set; }

    // [Many2one]
    [ForeignKey("GroupPosManagerId")]
    // [InverseProperty("PosConfigGroupPosManager")] //Many2one
    public virtual ResGroups? GroupPosManager { get; set; }

    // [Many2one]
    [ForeignKey("GroupPosUserId")]
    // [InverseProperty("PosConfigGroupPosUser")] //Many2one
    public virtual ResGroups? GroupPosUser { get; set; }

    // [Many2one]
    [ForeignKey("IfaceStartCategId")]
    // [InverseProperty("PosConfigNavigation")] //Many2one
    public virtual PosCategory? IfaceStartCateg { get; set; }

    // [Many2one]
    [ForeignKey("InvoiceJournalId")]
    // [InverseProperty("PosConfigInvoiceJournal")] //Many2one
    public virtual AccountJournal? InvoiceJournal { get; set; }

    // [Many2one]
    [ForeignKey("JournalId")]
    // [InverseProperty("PosConfigJournal")] //Many2one
    public virtual AccountJournal? Journal { get; set; }

    // [Many2one]
    [ForeignKey("PickingTypeId")]
    // [InverseProperty("PosConfig")] //Many2one
    public virtual StockPickingType? PickingType { get; set; }

    // [One2many]
    [ForeignKey("ConfigId")]
    [InverseProperty("Config")]
    public virtual ICollection<PosMakePayment> PosMakePayment { get; set; }

    // [One2many]
    [ForeignKey("ConfigId")]
    [InverseProperty("Config")]
    public virtual ICollection<PosOrder> PosOrder { get; set; }

    // [One2many]
    [ForeignKey("ConfigId")]
    [InverseProperty("Config")]
    public virtual ICollection<PosSession> PosSession { get; set; }

    // [Many2one]
    [ForeignKey("PricelistId")]
    // [InverseProperty("PosConfig")] //Many2one
    public virtual ProductPricelist? Pricelist { get; set; }

    // [One2many]
    [ForeignKey("PosConfigId")]
    [InverseProperty("PosConfig")]
    public virtual ICollection<ResConfigSettings> ResConfigSettings { get; set; }

    // v16-Compat
    // [One2many]
    //[ForeignKey("PosConfigId")]
    //[InverseProperty("PosConfig")]
    //public virtual ICollection<RestaurantFloor> RestaurantFloor { get; set; }

    // [Many2one]
    [ForeignKey("RoundingMethod")]
    // [InverseProperty("PosConfig")] //Many2one
    public virtual AccountCashRounding? RoundingMethodNavigation { get; set; }

    // [Many2one]
    [ForeignKey("RouteId")]
    // [InverseProperty("PosConfig")] //Many2one
    public virtual StockRoute? Route { get; set; }

    // [Many2one]
    [ForeignKey("SelfOrderOnlinePaymentMethodId")]
    // [InverseProperty("PosConfig")] //Many2one
    public virtual PosPaymentMethod? SelfOrderOnlinePaymentMethod { get; set; }

    // [Many2one]
    [ForeignKey("SelfOrderingDefaultLanguageId")]
    // [InverseProperty("PosConfig")] //Many2one
    public virtual ResLang? SelfOrderingDefaultLanguage { get; set; }

    // [Many2one]
    [ForeignKey("SelfOrderingDefaultUserId")]
    // [InverseProperty("PosConfigSelfOrderingDefaultUser")] //Many2one
    public virtual ResUsers? SelfOrderingDefaultUser { get; set; }

    // [Many2one]
    [ForeignKey("SequenceId")]
    // [InverseProperty("PosConfigSequence")] //Many2one
    public virtual IrSequence? Sequence { get; set; }

    // [Many2one]
    [ForeignKey("SequenceLineId")]
    // [InverseProperty("PosConfigSequenceLine")] //Many2one
    public virtual IrSequence? SequenceLine { get; set; }

    // [Many2one]
    [ForeignKey("TakeawayFpId")]
    // [InverseProperty("PosConfigTakeawayFp")] //Many2one
    public virtual AccountFiscalPosition? TakeawayFp { get; set; }

    // [Many2one]
    [ForeignKey("TipProductId")]
    // [InverseProperty("PosConfigTipProduct")] //Many2one
    public virtual ProductProduct? TipProduct { get; set; }

    // [Many2one]
    [ForeignKey("WarehouseId")]
    // [InverseProperty("PosConfig")] //Many2one
    public virtual StockWarehouse? Warehouse { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("PosConfigWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("PosConfigId")] //Many2many
    // [InverseProperty("PosConfig")] //Many2many
    public virtual ICollection<AccountFiscalPosition> AccountFiscalPosition { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("PosConfigId")] //Many2many
    // [InverseProperty("PosConfig")] //Many2many
    public virtual ICollection<HrEmployee> HrEmployee { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("PosConfigId")] //Many2many
    // [InverseProperty("PosConfigNavigation")] //Many2many
    public virtual ICollection<HrEmployee> HrEmployeeNavigation { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("PosConfigId")] //Many2many
    // [InverseProperty("PosConfig")] //Many2many
    public virtual ICollection<IrAttachment> IrAttachment { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("IsTrusting")] //Many2many
    // [InverseProperty("IsTrusting")] //Many2many
    public virtual ICollection<PosConfig> IsTrusted { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("IsTrusted")] //Many2many
    // [InverseProperty("IsTrusted")] //Many2many
    public virtual ICollection<PosConfig> IsTrusting { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("PosConfigId")]
    // [InverseProperty("PosConfig")]
    public virtual ICollection<LoyaltyProgram> LoyaltyProgram { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("PosConfigId")] //Many2many
    // [InverseProperty("PosConfig")] //Many2many
    public virtual ICollection<PosBill> PosBill { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("PosConfigId")] //Many2many
    // [InverseProperty("PosConfig")] //Many2many
    public virtual ICollection<PosCategory> PosCategory { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("PosConfigId")]
    // [InverseProperty("PosConfig")]
    public virtual ICollection<PosDetailsWizard> PosDetailsWizard { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("PosConfigId")] //Many2many
    // [InverseProperty("PosConfig")] //Many2many
    public virtual ICollection<PosNote> PosNote { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("PosConfigId")] //Many2many
    // [InverseProperty("PosConfigNavigation")] //Many2many
    public virtual ICollection<PosPaymentMethod> PosPaymentMethod { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("PosConfigId")]
    // [InverseProperty("PosConfig")]
    public virtual ICollection<PosSelfOrderCustomLink> PosSelfOrderCustomLink { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ConfigId")] //Many2many
    // [InverseProperty("Config")] //Many2many
    public virtual ICollection<PosPrinter> Printer { get; set; }

    // v16-Compat
    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ConfigId")] //Many2many
    // [InverseProperty("Config")] //Many2many
    //public virtual ICollection<RestaurantPrinter> Printer { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("PosConfigId")] //Many2many
    // [InverseProperty("PosConfigNavigation")] //Many2many
    public virtual ICollection<ProductPricelist> ProductPricelist { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("PosConfigId")] //Many2many
    // [InverseProperty("PosConfigNavigation")] //Many2many
    public virtual ICollection<ResLang> ResLang { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    [ForeignKey("PosConfigId")] //Many2many
    [InverseProperty("PosConfig")] //Many2many
    public virtual ICollection<RestaurantFloor> RestaurantFloor { get; set; }
}
