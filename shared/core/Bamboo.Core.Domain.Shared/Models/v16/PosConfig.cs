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
public partial class PosConfig: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("picking_type_id")]
    public Guid? PickingTypeId { get; set; }

    [Column("journal_id")]
    public Guid? JournalId { get; set; }

    [Column("invoice_journal_id")]
    public Guid? InvoiceJournalId { get; set; }

    // v16-Compat
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

    // v16-Compat
    [Column("limited_products_amount")]
    public long? LimitedProductsAmount { get; set; }

    // v16-Compat
    [Column("limited_partners_amount")]
    public long? LimitedPartnersAmount { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

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

    // v16-Compat
    [Column("iface_customer_facing_display_via_proxy")]
    public bool? IfaceCustomerFacingDisplayViaProxy { get; set; }

    // v16-Compat
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

    // v16-Compat
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

    // v16-Compat
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

    // v16-Compat
    [Column("limited_products_loading")]
    public bool? LimitedProductsLoading { get; set; }

    // v16-Compat
    [Column("product_load_background")]
    public bool? ProductLoadBackground { get; set; }

    // v16-Compat
    [Column("limited_partners_loading")]
    public bool? LimitedPartnersLoading { get; set; }

    // v16-Compat
    [Column("partner_load_background")]
    public bool? PartnerLoadBackground { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

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

    [Column("takeaway_fp_id")]
    public Guid? TakeawayFpId { get; set; }

    [Column("iface_splitbill")]
    public bool? IfaceSplitbill { get; set; }

    [Column("iface_printbill")]
    public bool? IfacePrintbill { get; set; }

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

    [ForeignKey("TenantId")]
    //[InverseProperty("PosConfigs")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("PosConfigCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CrmTeamId")]
    //[InverseProperty("PosConfigs")]
    [NotMapped]
    public virtual CrmTeam? CrmTeam { get; set; }

    [ForeignKey("DefaultFiscalPositionId")]
    //[InverseProperty("PosConfigsNavigation")]
    [NotMapped]
    public virtual AccountFiscalPosition? DefaultFiscalPosition { get; set; }

    [ForeignKey("DownPaymentProductId")]
    //[InverseProperty("PosConfigDownPaymentProducts")]
    [NotMapped]
    public virtual ProductProduct? DownPaymentProduct { get; set; }

    [ForeignKey("GroupPosManagerId")]
    //[InverseProperty("PosConfigGroupPosManagers")]
    [NotMapped]
    public virtual ResGroup? GroupPosManager { get; set; }

    [ForeignKey("GroupPosUserId")]
    //[InverseProperty("PosConfigGroupPosUsers")]
    [NotMapped]
    public virtual ResGroup? GroupPosUser { get; set; }

    [ForeignKey("IfaceStartCategId")]
    //[InverseProperty("PosConfigsNavigation")]
    [NotMapped]
    public virtual PosCategory? IfaceStartCateg { get; set; }

    [ForeignKey("InvoiceJournalId")]
    //[InverseProperty("PosConfigInvoiceJournals")]
    [NotMapped]
    public virtual AccountJournal? InvoiceJournal { get; set; }

    [ForeignKey("JournalId")]
    //[InverseProperty("PosConfigJournals")]
    [NotMapped]
    public virtual AccountJournal? Journal { get; set; }

    [ForeignKey("PickingTypeId")]
    //[InverseProperty("PosConfigs")]
    [NotMapped]
    public virtual StockPickingType? PickingType { get; set; }

    [ForeignKey("PricelistId")]
    //[InverseProperty("PosConfigs")]
    [NotMapped]
    public virtual ProductPricelist? Pricelist { get; set; }

    [ForeignKey("RoundingMethod")]
    //[InverseProperty("PosConfigs")]
    [NotMapped]
    public virtual AccountCashRounding? RoundingMethodNavigation { get; set; }

    [ForeignKey("RouteId")]
    //[InverseProperty("PosConfigs")]
    [NotMapped]
    public virtual StockRoute? Route { get; set; }

    [ForeignKey("SequenceId")]
    //[InverseProperty("PosConfigSequences")]
    [NotMapped]
    public virtual IrSequence? Sequence { get; set; }

    [ForeignKey("SequenceLineId")]
    //[InverseProperty("PosConfigSequenceLines")]
    [NotMapped]
    public virtual IrSequence? SequenceLine { get; set; }

    [ForeignKey("TipProductId")]
    //[InverseProperty("PosConfigTipProducts")]
    [NotMapped]
    public virtual ProductProduct? TipProduct { get; set; }

    [ForeignKey("WarehouseId")]
    //[InverseProperty("PosConfigs")]
    [NotMapped]
    public virtual StockWarehouse? Warehouse { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("PosConfigWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Config")]
    [NotMapped]
    public virtual ICollection<PosMakePayment> PosMakePayments { get; set; } = new List<PosMakePayment>();

    //[InverseProperty("Config")]
    [NotMapped]
    public virtual ICollection<PosSession> PosSessions { get; set; } = new List<PosSession>();

    //[InverseProperty("PosConfig")]
    [NotMapped]
    public virtual ICollection<ResConfigSetting> ResConfigSettings { get; set; } = new List<ResConfigSetting>();

    [ForeignKey("PosConfigId")]
    //[InverseProperty("PosConfigs")]
    [NotMapped]
    public virtual ICollection<IrAttachment> IrAttachments { get; set; } = new List<IrAttachment>();

    [ForeignKey("IsTrusting")]
    //[InverseProperty("IsTrustings")]
    [NotMapped]
    public virtual ICollection<PosConfig> IsTrusteds { get; set; } = new List<PosConfig>();

    [ForeignKey("IsTrusted")]
    //[InverseProperty("IsTrusteds")]
    [NotMapped]
    public virtual ICollection<PosConfig> IsTrustings { get; set; } = new List<PosConfig>();


    [ForeignKey("PosConfigId")]
    //[InverseProperty("PosConfigs")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPosition> AccountFiscalPositions { get; set; } = new List<AccountFiscalPosition>();

    [ForeignKey("PosConfigId")]
    //[InverseProperty("PosConfigs")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployees { get; set; } = new List<HrEmployee>();

    [ForeignKey("PosConfigId")]
    //[InverseProperty("PosConfigs")]
    [NotMapped]
    public virtual ICollection<PosBill> PosBills { get; set; } = new List<PosBill>();

    [ForeignKey("PosConfigId")]
    //[InverseProperty("PosConfigs")]
    [NotMapped]
    public virtual ICollection<PosCategory> PosCategories { get; set; } = new List<PosCategory>();

    [ForeignKey("PosConfigId")]
    //[InverseProperty("PosConfigs")]
    [NotMapped]
    public virtual ICollection<PosDetailsWizard> PosDetailsWizards { get; set; } = new List<PosDetailsWizard>();

    [ForeignKey("PosConfigId")]
    //[InverseProperty("PosConfigs")]
    [NotMapped]
    public virtual ICollection<PosPaymentMethod> PosPaymentMethods { get; set; } = new List<PosPaymentMethod>();

    [ForeignKey("PosConfigId")]
    //[InverseProperty("PosConfigsNavigation")]
    [NotMapped]
    public virtual ICollection<ProductPricelist> ProductPricelists { get; set; } = new List<ProductPricelist>();
}
