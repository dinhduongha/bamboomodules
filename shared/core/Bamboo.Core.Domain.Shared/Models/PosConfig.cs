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
public partial class PosConfig: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("picking_type_id")]
    public Guid? PickingTypeId { get; set; }

    [Column("journal_id")]
    public Guid? JournalId { get; set; }

    [Column("invoice_journal_id")]
    public Guid? InvoiceJournalId { get; set; }

    [Column("iface_start_categ_id")]
    public long? IfaceStartCategId { get; set; }

    [Column("sequence_id")]
    public Guid? SequenceId { get; set; }

    [Column("sequence_line_id")]
    public Guid? SequenceLineId { get; set; }

    [Column("pricelist_id")]
    public Guid? PricelistId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

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
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("iface_tax_included")]
    public string? IfaceTaxIncluded { get; set; }

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

    [Column("limited_products_loading")]
    public bool? LimitedProductsLoading { get; set; }

    [Column("product_load_background")]
    public bool? ProductLoadBackground { get; set; }

    [Column("limited_partners_loading")]
    public bool? LimitedPartnersLoading { get; set; }

    [Column("partner_load_background")]
    public bool? PartnerLoadBackground { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("amount_authorized_diff")]
    public double? AmountAuthorizedDiff { get; set; }

    [Column("epson_printer_ip")]
    public string? EpsonPrinterIp { get; set; }

    [Column("crm_team_id")]
    public Guid? CrmTeamId { get; set; }

    [Column("down_payment_product_id")]
    public Guid? DownPaymentProductId { get; set; }

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
    public virtual ICollection<PosMakePayment> PosMakePayments { get; } = new List<PosMakePayment>();

    //[InverseProperty("Config")]
    [NotMapped]
    public virtual ICollection<PosSession> PosSessions { get; } = new List<PosSession>();

    //[InverseProperty("PosConfig")]
    [NotMapped]
    public virtual ICollection<ResConfigSetting> ResConfigSettings { get; } = new List<ResConfigSetting>();

    [ForeignKey("PosConfigId")]
    //[InverseProperty("PosConfigs")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPosition> AccountFiscalPositions { get; } = new List<AccountFiscalPosition>();

    [ForeignKey("PosConfigId")]
    //[InverseProperty("PosConfigs")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployees { get; } = new List<HrEmployee>();

    [ForeignKey("PosConfigId")]
    //[InverseProperty("PosConfigs")]
    [NotMapped]
    public virtual ICollection<PosBill> PosBills { get; } = new List<PosBill>();

    [ForeignKey("PosConfigId")]
    //[InverseProperty("PosConfigs")]
    [NotMapped]
    public virtual ICollection<PosCategory> PosCategories { get; } = new List<PosCategory>();

    [ForeignKey("PosConfigId")]
    //[InverseProperty("PosConfigs")]
    [NotMapped]
    public virtual ICollection<PosDetailsWizard> PosDetailsWizards { get; } = new List<PosDetailsWizard>();

    [ForeignKey("PosConfigId")]
    //[InverseProperty("PosConfigs")]
    [NotMapped]
    public virtual ICollection<PosPaymentMethod> PosPaymentMethods { get; } = new List<PosPaymentMethod>();

    [ForeignKey("PosConfigId")]
    //[InverseProperty("PosConfigsNavigation")]
    [NotMapped]
    public virtual ICollection<ProductPricelist> ProductPricelists { get; } = new List<ProductPricelist>();
}
