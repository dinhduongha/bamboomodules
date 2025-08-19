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

[Table("sale_order")]
//[Index("CompanyId", Name = "sale_order__company_id_index")]
//[Index("CreateDate", Name = "sale_order__create_date_index")]
//[Index("PartnerId", Name = "sale_order__partner_id_index")]
//[Index("State", Name = "sale_order__state_index")]
//[Index("UserId", Name = "sale_order__user_id_index")]
//[Index("DateOrder", "Id", Name = "sale_order_date_order_id_idx", AllDescending = true)]
public partial class SaleOrder: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("campaign_id")]
    public Guid? CampaignId { get; set; }

    [Column("source_id")]
    public Guid? SourceId { get; set; }

    [Column("medium_id")]
    public Guid? MediumId { get; set; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

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

    [Column("analytic_account_id")]
    public Guid? AnalyticAccountId { get; set; }

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

    [JsonField]
    [Column("customizable_pdf_form_fields", TypeName = "jsonb")]
    public string? CustomizablePdfFormFields { get; set; }

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

    [JsonField]
    [Column("pickup_location_data", TypeName = "jsonb")]
    public string? PickupLocationData { get; set; }

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

    // [Column("carrier_id")]
    // public Guid? CarrierId { get; set; }

    // [Column("delivery_message")]
    // public string? DeliveryMessage { get; set; }

    [Column("delivery_rating_success")]
    public bool? DeliveryRatingSuccess { get; set; }

    // [Column("recompute_delivery_price")]
    // public bool? RecomputeDeliveryPrice { get; set; }

    [Column("amount_delivery")]
    public decimal? AmountDelivery { get; set; }

    // [One2many]
    [ForeignKey("OrderId")]
    [InverseProperty("Order")]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLine { get; set; }

    // [Many2one]
    [ForeignKey("AnalyticAccountId")]
    // [InverseProperty("SaleOrder")] //Many2one
    public virtual AccountAnalyticAccount? AnalyticAccount { get; set; }

    // [Many2one]
    [ForeignKey("CampaignId")]
    // [InverseProperty("SaleOrder")] //Many2one
    public virtual UtmCampaign? Campaign { get; set; }

    // [Many2one]
    [ForeignKey("CarrierId")]
    // [InverseProperty("SaleOrder")] //Many2one
    public virtual DeliveryCarrier? Carrier { get; set; }

    // [One2many]
    [ForeignKey("OrderId")]
    [InverseProperty("Order")]
    public virtual ICollection<ChooseDeliveryCarrier> ChooseDeliveryCarrier { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("SaleOrder")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("SaleOrderCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CurrencyId")]
    // [InverseProperty("SaleOrder")] //Many2one
    public virtual ResCurrency? Currency { get; set; }

    // [One2many]
    [ForeignKey("SaleOrderId")]
    [InverseProperty("SaleOrder")]
    public virtual ICollection<EventBooth> EventBooth { get; set; }

    // [One2many]
    [ForeignKey("SaleOrderId")]
    [InverseProperty("SaleOrder")]
    public virtual ICollection<EventRegistration> EventRegistration { get; set; }

    // [Many2one]
    [ForeignKey("FiscalPositionId")]
    // [InverseProperty("SaleOrder")] //Many2one
    public virtual AccountFiscalPosition? FiscalPosition { get; set; }

    // [One2many]
    [ForeignKey("SaleOrderId")]
    [InverseProperty("SaleOrder")]
    public virtual ICollection<HrExpense> HrExpense { get; set; }

    // [One2many]
    [ForeignKey("SaleOrderId")]
    [InverseProperty("SaleOrder")]
    public virtual ICollection<HrExpenseSplit> HrExpenseSplit { get; set; }

    // [Many2one]
    [ForeignKey("Incoterm")]
    // [InverseProperty("SaleOrder")] //Many2one
    public virtual AccountIncoterms? IncotermNavigation { get; set; }

    // [Many2one]
    [ForeignKey("JournalId")]
    // [InverseProperty("SaleOrder")] //Many2one
    public virtual AccountJournal? Journal { get; set; }

    // [One2many]
    [ForeignKey("OrderId")]
    [InverseProperty("Order")]
    public virtual ICollection<LoyaltyCard> LoyaltyCard { get; set; }

    // [Many2one]
    [ForeignKey("MediumId")]
    // [InverseProperty("SaleOrder")] //Many2one
    public virtual UtmMedium? Medium { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("SaleOrder")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("OpportunityId")]
    // [InverseProperty("SaleOrder")] //Many2one
    public virtual CrmLead? Opportunity { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("SaleOrderPartner")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("PartnerInvoiceId")]
    // [InverseProperty("SaleOrderPartnerInvoice")] //Many2one
    public virtual ResPartner? PartnerInvoice { get; set; }

    // [Many2one]
    [ForeignKey("PartnerShippingId")]
    // [InverseProperty("SaleOrderPartnerShipping")] //Many2one
    public virtual ResPartner? PartnerShipping { get; set; }

    // [Many2one]
    [ForeignKey("PaymentTermId")]
    // [InverseProperty("SaleOrder")] //Many2one
    public virtual AccountPaymentTerm? PaymentTerm { get; set; }

    // [Many2one]
    [ForeignKey("PendingEmailTemplateId")]
    // [InverseProperty("SaleOrder")] //Many2one
    public virtual MailTemplate? PendingEmailTemplate { get; set; }

    // [One2many]
    [ForeignKey("SaleOrderOriginId")]
    [InverseProperty("SaleOrderOrigin")]
    public virtual ICollection<PosOrderLine> PosOrderLine { get; set; }

    // [Many2one]
    [ForeignKey("PricelistId")]
    // [InverseProperty("SaleOrder")] //Many2one
    public virtual ProductPricelist? Pricelist { get; set; }

    // [One2many]
    [ForeignKey("SaleId")]
    [InverseProperty("Sale")]
    public virtual ICollection<ProcurementGroup> ProcurementGroup { get; set; }

    // [Many2one]
    [ForeignKey("ProcurementGroupId")]
    // [InverseProperty("SaleOrder")] //Many2one
    public virtual ProcurementGroup? ProcurementGroupNavigation { get; set; }

    // [Many2one]
    [ForeignKey("ProjectId")]
    // [InverseProperty("SaleOrder")] //Many2one
    public virtual ProjectProject? Project { get; set; }

    // [One2many]
    [ForeignKey("SaleOrderId")]
    [InverseProperty("SaleOrder")]
    public virtual ICollection<ProjectCreateInvoice> ProjectCreateInvoice { get; set; }

    // [One2many]
    [ForeignKey("SaleOrderId")]
    [InverseProperty("SaleOrder")]
    public virtual ICollection<ProjectCreateSaleOrder> ProjectCreateSaleOrder { get; set; }

    // [One2many]
    [ForeignKey("ReinvoicedSaleOrderId")]
    [InverseProperty("ReinvoicedSaleOrder")]
    public virtual ICollection<ProjectProject> ProjectProject { get; set; }

    // [One2many]
    [ForeignKey("SaleOrderId")]
    [InverseProperty("SaleOrder")]
    public virtual ICollection<ProjectTask> ProjectTask { get; set; }

    // [One2many]
    [ForeignKey("SaleOrderId")]
    [InverseProperty("SaleOrder")]
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLine { get; set; }

    // [One2many]
    [ForeignKey("SaleOrderId")]
    [InverseProperty("SaleOrder")]
    public virtual ICollection<RegistrationEditor> RegistrationEditor { get; set; }

    // [One2many]
    [ForeignKey("SaleOrderId")]
    [InverseProperty("SaleOrder")]
    public virtual ICollection<RepairOrder> RepairOrder { get; set; }

    // [One2many]
    [ForeignKey("OrderId")]
    [InverseProperty("Order")]
    public virtual ICollection<SaleLoyaltyCouponWizard> SaleLoyaltyCouponWizard { get; set; }

    // [One2many]
    [ForeignKey("OrderId")]
    [InverseProperty("Order")]
    public virtual ICollection<SaleLoyaltyRewardWizard> SaleLoyaltyRewardWizard { get; set; }

    // [One2many]
    [ForeignKey("OrderId")]
    [InverseProperty("Order")]
    public virtual ICollection<SaleOrderCancel> SaleOrderCancel { get; set; }

    // [One2many]
    [ForeignKey("OrderId")]
    [InverseProperty("Order")]
    public virtual ICollection<SaleOrderCouponPoints> SaleOrderCouponPoints { get; set; }

    // [One2many]
    [ForeignKey("SaleOrderId")]
    [InverseProperty("SaleOrder")]
    public virtual ICollection<SaleOrderDiscount> SaleOrderDiscount { get; set; }

    // [One2many]
    [ForeignKey("OrderId")]
    [InverseProperty("Order")]
    public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }

    // [One2many]
    [ForeignKey("OrderId")]
    [InverseProperty("Order")]
    public virtual ICollection<SaleOrderOption> SaleOrderOption { get; set; }

    // [Many2one]
    [ForeignKey("SaleOrderTemplateId")]
    // [InverseProperty("SaleOrder")] //Many2one
    public virtual SaleOrderTemplate? SaleOrderTemplate { get; set; }

    // [Many2one]
    [ForeignKey("SourceId")]
    // [InverseProperty("SaleOrder")] //Many2one
    public virtual UtmSource? Source { get; set; }

    // [One2many]
    [ForeignKey("SaleId")]
    [InverseProperty("Sale")]
    public virtual ICollection<StockPicking> StockPicking { get; set; }

    // [Many2one]
    [ForeignKey("TeamId")]
    // [InverseProperty("SaleOrder")] //Many2one
    public virtual CrmTeam? Team { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("SaleOrderUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("WarehouseId")]
    // [InverseProperty("SaleOrder")] //Many2one
    public virtual StockWarehouse? Warehouse { get; set; }

    // [Many2one]
    [ForeignKey("WebsiteId")]
    // [InverseProperty("SaleOrder")] //Many2one
    public virtual Website? Website { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("SaleOrderWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("SaleOrderId")] //Many2many
    // [InverseProperty("SaleOrder")] //Many2many
    public virtual ICollection<LoyaltyCard> LoyaltyCardNavigation { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("SaleOrderId")] //Many2many
    // [InverseProperty("SaleOrder")] //Many2many
    public virtual ICollection<LoyaltyReward> LoyaltyReward { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("SaleOrderId")] //Many2many
    // [InverseProperty("SaleOrder")] //Many2many
    public virtual ICollection<LoyaltyRule> LoyaltyRule { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("SaleOrderId")] //Many2many
    // [InverseProperty("SaleOrder")] //Many2many
    public virtual ICollection<QuotationDocument> QuotationDocument { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("SaleOrderId")]
    // [InverseProperty("SaleOrder")]
    public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInv { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("SaleOrderId")]
    // [InverseProperty("SaleOrder")]
    public virtual ICollection<SaleMassCancelOrders> SaleMassCancelOrders { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("OrderId")] //Many2many
    // [InverseProperty("Order")] //Many2many
    public virtual ICollection<CrmTag> Tag { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("SaleOrderId")]
    // [InverseProperty("SaleOrder")]
    public virtual ICollection<PaymentTransaction> Transaction { get; set; }
}
