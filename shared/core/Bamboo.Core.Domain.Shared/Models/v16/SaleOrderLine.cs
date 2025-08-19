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

[Table("sale_order_line")]
//[Index("CompanyId", Name = "sale_order_line__company_id_index")]
//[Index("LinkedLineId", Name = "sale_order_line__linked_line_id_index")]
//[Index("OrderId", Name = "sale_order_line__order_id_index")]
//[Index("OrderPartnerId", Name = "sale_order_line__order_partner_id_index")]
//[Index("ProjectId", Name = "sale_order_line__project_id_index")]
//[Index("TaskId", Name = "sale_order_line__task_id_index")]
public partial class SaleOrderLine: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("order_id")]
    public Guid? OrderId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("order_partner_id")]
    public Guid? OrderPartnerId { get; set; }

    [Column("salesman_id")]
    public Guid? SalesmanId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_uom")]
    public Guid? ProductUom { get; set; }

    [Column("linked_line_id")]
    public Guid? LinkedLineId { get; set; }

    [Column("combo_item_id")]
    public Guid? ComboItemId { get; set; }

    [Column("product_packaging_id")]
    public Guid? ProductPackagingId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("display_type")]
    public string? DisplayType { get; set; }

    [Column("virtual_id")]
    public string? VirtualId { get; set; }

    [Column("linked_virtual_id")]
    public string? LinkedVirtualId { get; set; }

    [Column("qty_delivered_method")]
    public string? QtyDeliveredMethod { get; set; }

    [Column("invoice_status")]
    public string? InvoiceStatus { get; set; }

    [JsonField]
    [Column("analytic_distribution", TypeName = "jsonb")]
    public string? AnalyticDistribution { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("product_uom_qty")]
    public decimal? ProductUomQty { get; set; }

    [Column("price_unit")]
    public decimal? PriceUnit { get; set; }

    [Column("discount")]
    public decimal? Discount { get; set; }

    [Column("price_reduce")]
    public decimal? PriceReduce { get; set; }

    [Column("price_subtotal")]
    public decimal? PriceSubtotal { get; set; }

    [Column("price_total")]
    public decimal? PriceTotal { get; set; }

    [Column("price_reduce_taxexcl")]
    public decimal? PriceReduceTaxexcl { get; set; }

    [Column("price_reduce_taxinc")]
    public decimal? PriceReduceTaxinc { get; set; }

    [Column("qty_delivered")]
    public decimal? QtyDelivered { get; set; }

    [Column("qty_invoiced")]
    public decimal? QtyInvoiced { get; set; }

    [Column("qty_to_invoice")]
    public decimal? QtyToInvoice { get; set; }

    [Column("untaxed_amount_invoiced")]
    public decimal? UntaxedAmountInvoiced { get; set; }

    [Column("untaxed_amount_to_invoice")]
    public decimal? UntaxedAmountToInvoice { get; set; }

    [Column("is_downpayment")]
    public bool? IsDownpayment { get; set; }

    [Column("is_expense")]
    public bool? IsExpense { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("technical_price_unit")]
    public double? TechnicalPriceUnit { get; set; }

    [Column("price_tax")]
    public double? PriceTax { get; set; }

    [Column("product_packaging_qty")]
    public double? ProductPackagingQty { get; set; }

    [Column("customer_lead")]
    public double? CustomerLead { get; set; }

    [Column("route_id")]
    public Guid? RouteId { get; set; }

    [Column("warehouse_id")]
    public Guid? WarehouseId { get; set; }

    [Column("is_service")]
    public bool? IsService { get; set; }

    [Column("project_id")]
    public Guid? ProjectId { get; set; }

    [Column("task_id")]
    public Guid? TaskId { get; set; }

    [Column("is_delivery")]
    public bool? IsDelivery { get; set; }

    [Column("shop_warning")]
    public string? ShopWarning { get; set; }

    [Column("event_id")]
    public Guid? EventId { get; set; }

    [Column("event_ticket_id")]
    public Guid? EventTicketId { get; set; }

    [Column("event_booth_category_id")]
    public Guid? EventBoothCategoryId { get; set; }

    [Column("reward_id")]
    public Guid? RewardId { get; set; }

    [Column("coupon_id")]
    public Guid? CouponId { get; set; }

    [Column("reward_identifier_code")]
    public string? RewardIdentifierCode { get; set; }

    [Column("points_cost")]
    public double? PointsCost { get; set; }

    [Column("margin")]
    public decimal? Margin { get; set; }

    [Column("purchase_price")]
    public decimal? PurchasePrice { get; set; }

    [Column("margin_percent")]
    public double? MarginPercent { get; set; }

    [Column("expense_id")]
    public Guid? ExpenseId { get; set; }

    [Column("has_displayed_warning_upsell")]
    public bool? HasDisplayedWarningUpsell { get; set; }

    [Column("remaining_hours")]
    public double? RemainingHours { get; set; }

    // [One2many]
    [ForeignKey("SoLine")]
    [InverseProperty("SoLineNavigation")]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLine { get; set; }

    // [Many2one]
    [ForeignKey("ComboItemId")]
    // [InverseProperty("SaleOrderLine")] //Many2one
    public virtual ProductComboItem? ComboItem { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("SaleOrderLine")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CouponId")]
    // [InverseProperty("SaleOrderLine")] //Many2one
    public virtual LoyaltyCard? Coupon { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("SaleOrderLineCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CurrencyId")]
    // [InverseProperty("SaleOrderLine")] //Many2one
    public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    [ForeignKey("EventId")]
    // [InverseProperty("SaleOrderLine")] //Many2one
    public virtual EventEvent? Event { get; set; }

    // [One2many]
    [ForeignKey("SaleOrderLineId")]
    [InverseProperty("SaleOrderLine")]
    public virtual ICollection<EventBooth> EventBooth { get; set; }

    // [Many2one]
    [ForeignKey("EventBoothCategoryId")]
    // [InverseProperty("SaleOrderLine")] //Many2one
    public virtual EventBoothCategory? EventBoothCategory { get; set; }

    // [One2many]
    [ForeignKey("SaleOrderLineId")]
    [InverseProperty("SaleOrderLine")]
    public virtual ICollection<EventBoothConfigurator> EventBoothConfigurator { get; set; }

    // [One2many]
    [ForeignKey("SaleOrderLineId")]
    [InverseProperty("SaleOrderLine")]
    public virtual ICollection<EventBoothRegistration> EventBoothRegistration { get; set; }

    // [One2many]
    [ForeignKey("SaleOrderLineId")]
    [InverseProperty("SaleOrderLine")]
    public virtual ICollection<EventRegistration> EventRegistration { get; set; }

    // [Many2one]
    [ForeignKey("EventTicketId")]
    // [InverseProperty("SaleOrderLine")] //Many2one
    public virtual EventEventTicket? EventTicket { get; set; }

    // [Many2one]
    [ForeignKey("ExpenseId")]
    // [InverseProperty("SaleOrderLine")] //Many2one
    public virtual HrExpense? Expense { get; set; }

    // [One2many]
    [ForeignKey("LinkedLineId")]
    [InverseProperty("LinkedLine")]
    public virtual ICollection<SaleOrderLine> InverseLinkedLine { get; set; }

    // [Many2one]
    [ForeignKey("LinkedLineId")]
    // [InverseProperty("InverseLinkedLine")] //Many2one
    public virtual SaleOrderLine? LinkedLine { get; set; }

    // [One2many]
    [ForeignKey("SaleLineId")]
    [InverseProperty("SaleLine")]
    public virtual ICollection<MrpProduction> MrpProduction { get; set; }

    // [Many2one]
    [ForeignKey("OrderId")]
    // [InverseProperty("SaleOrderLine")] //Many2one
    public virtual SaleOrder? Order { get; set; }

    // [Many2one]
    [ForeignKey("OrderPartnerId")]
    // [InverseProperty("SaleOrderLine")] //Many2one
    public virtual ResPartner? OrderPartner { get; set; }

    // [One2many]
    [ForeignKey("SaleOrderLineId")]
    [InverseProperty("SaleOrderLine")]
    public virtual ICollection<PosOrderLine> PosOrderLine { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("SaleOrderLine")] //Many2one
    public virtual ProductProduct? Product { get; set; }

    // [One2many]
    [ForeignKey("SaleOrderLineId")]
    [InverseProperty("SaleOrderLine")]
    public virtual ICollection<ProductAttributeCustomValue> ProductAttributeCustomValue { get; set; }

    // [Many2one]
    [ForeignKey("ProductPackagingId")]
    // [InverseProperty("SaleOrderLine")] //Many2one
    public virtual ProductPackaging? ProductPackaging { get; set; }

    // [Many2one]
    [ForeignKey("ProductUom")]
    // [InverseProperty("SaleOrderLine")] //Many2one
    public virtual UomUom? ProductUomNavigation { get; set; }

    // [Many2one]
    [ForeignKey("ProjectId")]
    // [InverseProperty("SaleOrderLine")] //Many2one
    public virtual ProjectProject? Project { get; set; }

    // [One2many]
    [ForeignKey("SaleLineId")]
    [InverseProperty("SaleLine")]
    public virtual ICollection<ProjectMilestone> ProjectMilestone { get; set; }

    // [One2many]
    [ForeignKey("SaleLineId")]
    [InverseProperty("SaleLine")]
    public virtual ICollection<ProjectProject> ProjectProject { get; set; }

    // [One2many]
    [ForeignKey("SaleLineId")]
    [InverseProperty("SaleLine")]
    public virtual ICollection<ProjectSaleLineEmployeeMap> ProjectSaleLineEmployeeMap { get; set; }

    // [One2many]
    [ForeignKey("SaleLineId")]
    [InverseProperty("SaleLine")]
    public virtual ICollection<ProjectTask> ProjectTask { get; set; }

    // [One2many]
    [ForeignKey("SaleLineId")]
    [InverseProperty("SaleLine")]
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLine { get; set; }

    // [One2many]
    [ForeignKey("SaleOrderLineId")]
    [InverseProperty("SaleOrderLine")]
    public virtual ICollection<RegistrationEditorLine> RegistrationEditorLine { get; set; }

    // [One2many]
    [ForeignKey("SaleOrderLineId")]
    [InverseProperty("SaleOrderLine")]
    public virtual ICollection<RepairOrder> RepairOrder { get; set; }

    // [Many2one]
    [ForeignKey("RewardId")]
    // [InverseProperty("SaleOrderLine")] //Many2one
    public virtual LoyaltyReward? Reward { get; set; }

    // [Many2one]
    [ForeignKey("RouteId")]
    // [InverseProperty("SaleOrderLine")] //Many2one
    public virtual StockRoute? Route { get; set; }

    // [One2many]
    [ForeignKey("LineId")]
    [InverseProperty("Line")]
    public virtual ICollection<SaleOrderOption> SaleOrderOption { get; set; }

    // [Many2one]
    [ForeignKey("SalesmanId")]
    // [InverseProperty("SaleOrderLineSalesman")] //Many2one
    public virtual ResUsers? Salesman { get; set; }

    // [One2many]
    [ForeignKey("SaleLineId")]
    [InverseProperty("SaleLine")]
    public virtual ICollection<StockMove> StockMove { get; set; }

    // [Many2one]
    [ForeignKey("TaskId")]
    // [InverseProperty("SaleOrderLine")] //Many2one
    public virtual ProjectTask? Task { get; set; }

    // [Many2one]
    [ForeignKey("WarehouseId")]
    // [InverseProperty("SaleOrderLine")] //Many2one
    public virtual StockWarehouse? Warehouse { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("SaleOrderLineWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("SaleOrderLineId")] //Many2many
    // [InverseProperty("SaleOrderLine")] //Many2many
    public virtual ICollection<AccountTax> AccountTax { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("OrderLineId")]
    // [InverseProperty("OrderLine")]
    public virtual ICollection<AccountMoveLine> InvoiceLine { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("SaleOrderLineId")] //Many2many
    // [InverseProperty("SaleOrderLine")] //Many2many
    public virtual ICollection<ProductDocument> ProductDocument { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("SaleOrderLineId")] //Many2many
    // [InverseProperty("SaleOrderLine")] //Many2many
    public virtual ICollection<ProductTemplateAttributeValue> ProductTemplateAttributeValue { get; set; }
}
