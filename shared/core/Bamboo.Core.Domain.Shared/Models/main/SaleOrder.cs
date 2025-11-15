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

[Table("sale_order")]
//[Index("CompanyId", Name = "sale_order__company_id_index")]
//[Index("CreateDate", Name = "sale_order__create_date_index")]
//[Index("PartnerId", Name = "sale_order__partner_id_index")]
//[Index("State", Name = "sale_order__state_index")]
//[Index("UserId", Name = "sale_order__user_id_index")]
//[Index("DateOrder", "Id", Name = "sale_order_date_order_id_idx", AllDescending = true)]
public partial class SaleOrder : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("campaign_id")]
    public Guid? CampaignId { get; set; }

    [Column("source_id")]
    public Guid? SourceId { get; set; }

    [Column("medium_id")]
    public Guid? MediumId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("journal_id")]
    public Guid? JournalId { get; set; }

    [Column("partner_invoice_id")]
    public Guid? PartnerInvoiceId { get; set; }

    [Column("partner_shipping_id")]
    public Guid? PartnerShippingId { get; set; }

    [Column("fiscal_position_id")]
    public Guid? FiscalPositionId { get; set; }

    [Column("payment_term_id")]
    public Guid? PaymentTermId { get; set; }

    [Column("pricelist_id")]
    public Guid? PricelistId { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("team_id")]
    public Guid? TeamId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("access_token")]
    public string? AccessToken { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("client_order_ref")]
    public string? ClientOrderRef { get; set; }

    [Column("origin")]
    public string? Origin { get; set; }

    [Column("reference")]
    public string? Reference { get; set; }

    [Column("signed_by")]
    public string? SignedBy { get; set; }

    [Column("invoice_status")]
    public string? InvoiceStatus { get; set; }

    [Column("validity_date")]
    public DateTime? ValidityDate { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("currency_rate")]
    public decimal? CurrencyRate { get; set; }

    [Column("amount_untaxed")]
    public decimal? AmountUntaxed { get; set; }

    [Column("amount_tax")]
    public decimal? AmountTax { get; set; }

    [Column("amount_total")]
    public decimal? AmountTotal { get; set; }

    [Column("locked")]
    public bool? Locked { get; set; }

    [Column("require_signature")]
    public bool? RequireSignature { get; set; }

    [Column("require_payment")]
    public bool? RequirePayment { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("commitment_date", TypeName = "timestamp without time zone")]
    public DateTime? CommitmentDate { get; set; }

    [Column("date_order", TypeName = "timestamp without time zone")]
    public DateTime? DateOrder { get; set; }

    [Column("signed_on", TypeName = "timestamp without time zone")]
    public DateTime? SignedOn { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("prepayment_percent")]
    public double? PrepaymentPercent { get; set; }

    [Column("pending_email_template_id")]
    public Guid? PendingEmailTemplateId { get; set; }

    [Column("sale_order_template_id")]
    public Guid? SaleOrderTemplateId { get; set; }

    [JsonField] // CustomizablePdfFormFields
    [Column("customizable_pdf_form_fields", TypeName = "jsonb")]
    public JsonElement? CustomizablePdfFormFields { get; set; }

    [Column("incoterm")]
    public Guid? Incoterm { get; set; }

    [Column("warehouse_id")]
    public Guid? WarehouseId { get; set; }

    [Column("procurement_group_id")]
    public Guid? ProcurementGroupId { get; set; }

    [Column("incoterm_location")]
    public string? IncotermLocation { get; set; }

    [Column("picking_policy")]
    public string? PickingPolicy { get; set; }

    [Column("delivery_status")]
    public string? DeliveryStatus { get; set; }

    [Column("effective_date", TypeName = "timestamp without time zone")]
    public DateTime? EffectiveDate { get; set; }

    [Column("amount_unpaid")]
    public decimal? AmountUnpaid { get; set; }

    [Column("opportunity_id")]
    public Guid? OpportunityId { get; set; }

    [Column("project_id")]
    public Guid? ProjectId { get; set; }

    [Column("carrier_id")]
    public Guid? CarrierId { get; set; }

    [Column("delivery_message")]
    public string? DeliveryMessage { get; set; }

    [JsonField] // PickupLocationData
    [Column("pickup_location_data", TypeName = "jsonb")]
    public JsonElement? PickupLocationData { get; set; }

    [Column("recompute_delivery_price")]
    public bool? RecomputeDeliveryPrice { get; set; }

    [Column("shipping_weight")]
    public double? ShippingWeight { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("shop_warning")]
    public string? ShopWarning { get; set; }

    [Column("cart_recovery_email_sent")]
    public bool? CartRecoveryEmailSent { get; set; }

    [Column("margin")]
    public decimal? Margin { get; set; }

    [Column("margin_percent")]
    public double? MarginPercent { get; set; }

    [Column("report_grids")]
    public bool? ReportGrids { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OrderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Order")] // One2many
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CampaignId")]
    public virtual UtmCampaign? Campaign { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CarrierId")]
    public virtual DeliveryCarrier? Carrier { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OrderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Order")] // One2many
    public virtual ICollection<ChooseDeliveryCarrier> ChooseDeliveryCarrier { get; set; }

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
    // [One2many] [ForeignKey("SaleOrderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SaleOrder")] // One2many
    public virtual ICollection<EventBooth> EventBooth { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SaleOrderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SaleOrder")] // One2many
    public virtual ICollection<EventRegistration> EventRegistration { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("FiscalPositionId")]
    public virtual AccountFiscalPosition? FiscalPosition { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SaleOrderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SaleOrder")] // One2many
    public virtual ICollection<HrExpense> HrExpense { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SaleOrderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SaleOrder")] // One2many
    public virtual ICollection<HrExpenseSplit> HrExpenseSplit { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("Incoterm")]
    public virtual AccountIncoterms? IncotermNavigation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("JournalId")]
    public virtual AccountJournal? Journal { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OrderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Order")] // One2many
    public virtual ICollection<LoyaltyCard> LoyaltyCard { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("MediumId")]
    public virtual UtmMedium? Medium { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("OpportunityId")]
    public virtual CrmLead? Opportunity { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PartnerInvoiceId")]
    public virtual ResPartner? PartnerInvoice { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PartnerShippingId")]
    public virtual ResPartner? PartnerShipping { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PaymentTermId")]
    public virtual AccountPaymentTerm? PaymentTerm { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PendingEmailTemplateId")]
    public virtual MailTemplate? PendingEmailTemplate { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SaleOrderOriginId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SaleOrderOrigin")] // One2many
    public virtual ICollection<PosOrderLine> PosOrderLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PricelistId")]
    public virtual ProductPricelist? Pricelist { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SaleId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Sale")] // One2many
    public virtual ICollection<ProcurementGroup> ProcurementGroup { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProcurementGroupId")]
    public virtual ProcurementGroup? ProcurementGroupNavigation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProjectId")]
    public virtual ProjectProject? Project { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SaleOrderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SaleOrder")] // One2many
    public virtual ICollection<ProjectCreateInvoice> ProjectCreateInvoice { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ReinvoicedSaleOrderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ReinvoicedSaleOrder")] // One2many
    public virtual ICollection<ProjectProject> ProjectProject { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SaleOrderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SaleOrder")] // One2many
    public virtual ICollection<ProjectTask> ProjectTask { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SaleOrderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SaleOrder")] // One2many
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SaleOrderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SaleOrder")] // One2many
    public virtual ICollection<RegistrationEditor> RegistrationEditor { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SaleOrderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SaleOrder")] // One2many
    public virtual ICollection<RepairOrder> RepairOrder { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OrderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Order")] // One2many
    public virtual ICollection<SaleLoyaltyCouponWizard> SaleLoyaltyCouponWizard { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OrderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Order")] // One2many
    public virtual ICollection<SaleLoyaltyRewardWizard> SaleLoyaltyRewardWizard { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OrderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Order")] // One2many
    public virtual ICollection<SaleOrderCancel> SaleOrderCancel { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OrderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Order")] // One2many
    public virtual ICollection<SaleOrderCouponPoints> SaleOrderCouponPoints { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SaleOrderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SaleOrder")] // One2many
    public virtual ICollection<SaleOrderDiscount> SaleOrderDiscount { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OrderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Order")] // One2many
    public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OrderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Order")] // One2many
    public virtual ICollection<SaleOrderOption> SaleOrderOption { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SaleOrderTemplateId")]
    public virtual SaleOrderTemplate? SaleOrderTemplate { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SourceId")]
    public virtual UtmSource? Source { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SaleId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Sale")] // One2many
    public virtual ICollection<StockPicking> StockPicking { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TeamId")]
    public virtual CrmTeam? Team { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("WarehouseId")]
    public virtual StockWarehouse? Warehouse { get; set; }

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
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("SaleOrderId")] // Many2many // Normal
    // [InverseProperty("SaleOrder")] // Many2many // Normal
    public virtual ICollection<LoyaltyCard> LoyaltyCardNavigation { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("SaleOrderId")] // Many2many // Normal
    // [InverseProperty("SaleOrder")] // Many2many // Normal
    public virtual ICollection<LoyaltyReward> LoyaltyReward { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("SaleOrderId")] // Many2many // Normal
    // [InverseProperty("SaleOrder")] // Many2many // Normal
    public virtual ICollection<LoyaltyRule> LoyaltyRule { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("SaleOrderId")] // Many2many // Normal
    // [InverseProperty("SaleOrder")] // Many2many // Normal
    public virtual ICollection<QuotationDocument> QuotationDocument { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("SaleOrderId")] //Many2many // Hidden
    // [InverseProperty("SaleOrder")] //Many2many // Hidden
    public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInv { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("SaleOrderId")] //Many2many // Hidden
    // [InverseProperty("SaleOrder")] //Many2many // Hidden
    public virtual ICollection<SaleMassCancelOrders> SaleMassCancelOrders { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("OrderId")] // Many2many // Normal
    // [InverseProperty("Order")] // Many2many // Normal
    public virtual ICollection<CrmTag> Tag { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("SaleOrderId")] //Many2many // Hidden
    // [InverseProperty("SaleOrder")] //Many2many // Hidden
    public virtual ICollection<PaymentTransaction> Transaction { get; set; }
}
