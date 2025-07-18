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
//[Index("TenantId", Name = "sale_order_company_id_index")]
//[Index("CreationTime", Name = "sale_order_create_date_index")]
//[Index("DateOrder", "Id", Name = "sale_order_date_order_id_idx", AllDescending = true)]
//[Index("PartnerId", Name = "sale_order_partner_id_index")]
//[Index("State", Name = "sale_order_state_index")]
//[Index("UserId", Name = "sale_order_user_id_index")]
public partial class SaleOrder: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("campaign_id")]
    public Guid? CampaignId { get; set; }

    [Column("source_id")]
    public Guid? SourceId { get; set; }

    [Column("medium_id")]
    public Guid? MediumId { get; set; }

    // v16-Compat
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

    // v16-Compat
    [Column("analytic_account_id")]
    public Guid? AnalyticAccountId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateTime CreationTime { get; set; }

    [Column("commitment_date", TypeName = "timestamp without time zone")]
    public DateTime? CommitmentDate { get; set; }

    [Column("date_order", TypeName = "timestamp without time zone")]
    public DateTime? DateOrder { get; set; }

    [Column("signed_on", TypeName = "timestamp without time zone")]
    public DateTime? SignedOn { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("prepayment_percent")]
    public double? PrepaymentPercent { get; set; }

    [Column("pending_email_template_id")]
    public Guid? PendingEmailTemplateId { get; set; }

    [Column("opportunity_id")]
    public Guid? OpportunityId { get; set; }

    [Column("sale_order_template_id")]
    public Guid? SaleOrderTemplateId { get; set; }

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

    // v16-Compat
    // [Column("opportunity_id")]
    // public Guid? OpportunityId { get; set; }

    [Column("project_id")]
    public Guid? ProjectId { get; set; }

    [Column("carrier_id")]
    public Guid? CarrierId { get; set; }

    [Column("delivery_message")]
    public string? DeliveryMessage { get; set; }

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

    // v16-Compat
    [ForeignKey("AnalyticAccountId")]
    //[InverseProperty("SaleOrders")]
    [NotMapped]
    public virtual AccountAnalyticAccount? AnalyticAccount { get; set; }

    [ForeignKey("CampaignId")]
    //[InverseProperty("SaleOrders")]
    [NotMapped]
    public virtual UtmCampaign? Campaign { get; set; }

    [ForeignKey("CarrierId")]
    //[InverseProperty("SaleOrders")]
    [NotMapped]
    public virtual DeliveryCarrier? Carrier { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("SaleOrders")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SaleOrderCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CurrencyId")]
    //[InverseProperty("SaleOrders")]
    [NotMapped]
    public virtual ResCurrency? Currency { get; set; }

    [ForeignKey("FiscalPositionId")]
    //[InverseProperty("SaleOrders")]
    [NotMapped]
    public virtual AccountFiscalPosition? FiscalPosition { get; set; }

    [ForeignKey("Incoterm")]
    //[InverseProperty("SaleOrders")]
    [NotMapped]
    public virtual AccountIncoterm? IncotermNavigation { get; set; }

    [ForeignKey("MediumId")]
    //[InverseProperty("SaleOrders")]
    [NotMapped]
    public virtual UtmMedium? Medium { get; set; }

    [ForeignKey("JournalId")]
    //[InverseProperty("SaleOrders")]
    [NotMapped]
    public virtual AccountJournal? Journal { get; set; }

    // v16-Compat
    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("SaleOrders")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("OpportunityId")]
    //[InverseProperty("SaleOrders")]
    [NotMapped]
    public virtual CrmLead? Opportunity { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("SaleOrderPartners")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("PartnerInvoiceId")]
    //[InverseProperty("SaleOrderPartnerInvoices")]
    [NotMapped]
    public virtual ResPartner? PartnerInvoice { get; set; }

    [ForeignKey("PartnerShippingId")]
    //[InverseProperty("SaleOrderPartnerShippings")]
    [NotMapped]
    public virtual ResPartner? PartnerShipping { get; set; }

    [ForeignKey("PaymentTermId")]
    //[InverseProperty("SaleOrders")]
    [NotMapped]
    public virtual AccountPaymentTerm? PaymentTerm { get; set; }

    [ForeignKey("PendingEmailTemplateId")]
    //[InverseProperty("SaleOrders")]
    [NotMapped]
    public virtual MailTemplate? PendingEmailTemplate { get; set; }

    [ForeignKey("PricelistId")]
    //[InverseProperty("SaleOrders")]
    [NotMapped]
    public virtual ProductPricelist? Pricelist { get; set; }

    [ForeignKey("ProcurementGroupId")]
    //[InverseProperty("SaleOrders")]
    [NotMapped]
    public virtual ProcurementGroup? ProcurementGroup { get; set; }

    [ForeignKey("ProjectId")]
    //[InverseProperty("SaleOrders")]
    [NotMapped]
    public virtual ProjectProject? Project { get; set; }

    [ForeignKey("SaleOrderTemplateId")]
    //[InverseProperty("SaleOrders")]
    [NotMapped]
    public virtual SaleOrderTemplate? SaleOrderTemplate { get; set; }

    [ForeignKey("SourceId")]
    //[InverseProperty("SaleOrders")]
    [NotMapped]
    public virtual UtmSource? Source { get; set; }

    [ForeignKey("TeamId")]
    //[InverseProperty("SaleOrders")]
    [NotMapped]
    public virtual CrmTeam? Team { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("SaleOrderUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("WarehouseId")]
    //[InverseProperty("SaleOrders")]
    [NotMapped]
    public virtual StockWarehouse? Warehouse { get; set; }

    [ForeignKey("WebsiteId")]
    //[InverseProperty("SaleOrders")]
    [NotMapped]
    public virtual Website? Website { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SaleOrderWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    /// TODO: DISABLE INVERSE COLLECTIONS
    //[InverseProperty("SaleOrder")]
    [NotMapped]
    public virtual ICollection<HrExpenseSplit> HrExpenseSplits { get; set; } = new List<HrExpenseSplit>();

    //[InverseProperty("SaleOrder")]
    [NotMapped]
    public virtual ICollection<HrExpense> HrExpenses { get; set; } = new List<HrExpense>();

    //[InverseProperty("SaleOrderOrigin")]
    [NotMapped]
    public virtual ICollection<PosOrderLine> PosOrderLines { get; set; } = new List<PosOrderLine>();

    //[InverseProperty("Sale")]
    [NotMapped]
    public virtual ICollection<ProcurementGroup> ProcurementGroups { get; set; } = new List<ProcurementGroup>();

    //[InverseProperty("SaleOrder")]
    [NotMapped]
    public virtual ICollection<ProjectTask> ProjectTasks { get; set; } = new List<ProjectTask>();

    //[InverseProperty("SaleOrder")]
    [NotMapped]
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; } = new List<PurchaseOrderLine>();

    //[InverseProperty("SaleOrder")]
    [NotMapped]
    public virtual ICollection<RepairOrder> RepairOrders { get; set; } = new List<RepairOrder>();

    //[InverseProperty("Order")]
    [NotMapped]
    public virtual ICollection<SaleOrderCancel> SaleOrderCancels { get; set; } = new List<SaleOrderCancel>();

    //[InverseProperty("SaleOrder")]
    [NotMapped]
    public virtual ICollection<SaleOrderDiscount> SaleOrderDiscounts { get; set; } = new List<SaleOrderDiscount>();

    //[InverseProperty("Order")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> SaleOrderLines { get; set; } = new List<SaleOrderLine>();

    //[InverseProperty("Order")]
    [NotMapped]
    public virtual ICollection<SaleOrderOption> SaleOrderOptions { get; set; } = new List<SaleOrderOption>();

    //[InverseProperty("Sale")]
    [NotMapped]
    public virtual ICollection<StockPicking> StockPickings { get; set; } = new List<StockPicking>();

    [ForeignKey("SaleOrderId")]
    //[InverseProperty("SaleOrders")]
    [NotMapped]
    public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInvs { get; set; } = new List<SaleAdvancePaymentInv>();

    [ForeignKey("OrderId")]
    //[InverseProperty("Orders")]
    [NotMapped]
    public virtual ICollection<CrmTag> Tags { get; set; } = new List<CrmTag>();

    [ForeignKey("SaleOrderId")]
    //[InverseProperty("SaleOrders")]
    [NotMapped]
    public virtual ICollection<PaymentTransaction> Transactions { get; set; } = new List<PaymentTransaction>();
}
