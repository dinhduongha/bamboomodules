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
//[Index("TenantId", Name = "sale_order_line_company_id_index")]
//[Index("LinkedLineId", Name = "sale_order_line_linked_line_id_index")]
//[Index("OrderId", Name = "sale_order_line_order_id_index")]
//[Index("OrderPartnerId", Name = "sale_order_line_order_partner_id_index")]
//[Index("ProjectId", Name = "sale_order_line_project_id_index")]
//[Index("TaskId", Name = "sale_order_line_task_id_index")]
public partial class SaleOrderLine: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("order_id")]
    public Guid? OrderId { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("currency_id")]
    public long? CurrencyId { get; set; }

    [Column("order_partner_id")]
    public Guid? OrderPartnerId { get; set; }

    [Column("salesman_id")]
    public Guid? SalesmanId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_uom")]
    public Guid? ProductUom { get; set; }

    [Column("product_packaging_id")]
    public Guid? ProductPackagingId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("display_type")]
    public string? DisplayType { get; set; }

    [Column("qty_delivered_method")]
    public string? QtyDeliveredMethod { get; set; }

    [Column("invoice_status")]
    public string? InvoiceStatus { get; set; }

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
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("price_tax")]
    public double? PriceTax { get; set; }

    [Column("product_packaging_qty")]
    public double? ProductPackagingQty { get; set; }

    [Column("customer_lead")]
    public double? CustomerLead { get; set; }

    [Column("route_id")]
    public Guid? RouteId { get; set; }

    [Column("is_service")]
    public bool? IsService { get; set; }

    [Column("project_id")]
    public Guid? ProjectId { get; set; }

    [Column("task_id")]
    public Guid? TaskId { get; set; }

    [Column("linked_line_id")]
    public Guid? LinkedLineId { get; set; }

    [Column("shop_warning")]
    public string? ShopWarning { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("SaleOrderLines")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SaleOrderLineCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CurrencyId")]
    //[InverseProperty("SaleOrderLines")]
    [NotMapped]
    public virtual ResCurrency? Currency { get; set; }

    [ForeignKey("LinkedLineId")]
    //[InverseProperty("InverseLinkedLine")]
    [NotMapped]
    public virtual SaleOrderLine? LinkedLine { get; set; }

    [ForeignKey("OrderId")]
    //[InverseProperty("SaleOrderLines")]
    [NotMapped]
    public virtual SaleOrder? Order { get; set; }

    [ForeignKey("OrderPartnerId")]
    //[InverseProperty("SaleOrderLines")]
    [NotMapped]
    public virtual ResPartner? OrderPartner { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("SaleOrderLines")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("ProductPackagingId")]
    //[InverseProperty("SaleOrderLines")]
    [NotMapped]
    public virtual ProductPackaging? ProductPackaging { get; set; }

    [ForeignKey("ProductUom")]
    //[InverseProperty("SaleOrderLines")]
    [NotMapped]
    public virtual UomUom? ProductUomNavigation { get; set; }

    [ForeignKey("ProjectId")]
    //[InverseProperty("SaleOrderLines")]
    [NotMapped]
    public virtual ProjectProject? Project { get; set; }

    [ForeignKey("RouteId")]
    //[InverseProperty("SaleOrderLines")]
    [NotMapped]
    public virtual StockRoute? Route { get; set; }

    [ForeignKey("SalesmanId")]
    //[InverseProperty("SaleOrderLineSalesmen")]
    [NotMapped]
    public virtual ResUser? Salesman { get; set; }

    [ForeignKey("TaskId")]
    //[InverseProperty("SaleOrderLines")]
    [NotMapped]
    public virtual ProjectTask? Task { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SaleOrderLineWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("SoLineNavigation")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLines { get; } = new List<AccountAnalyticLine>();

    //[InverseProperty("LinkedLine")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> InverseLinkedLine { get; } = new List<SaleOrderLine>();

    //[InverseProperty("SaleOrderLine")]
    [NotMapped]
    public virtual ICollection<PosOrderLine> PosOrderLines { get; } = new List<PosOrderLine>();

    //[InverseProperty("SaleOrderLine")]
    [NotMapped]
    public virtual ICollection<ProductAttributeCustomValue> ProductAttributeCustomValues { get; } = new List<ProductAttributeCustomValue>();

    //[InverseProperty("SaleLine")]
    [NotMapped]
    public virtual ICollection<ProjectMilestone> ProjectMilestones { get; } = new List<ProjectMilestone>();

    //[InverseProperty("SaleLine")]
    [NotMapped]
    public virtual ICollection<ProjectProject> ProjectProjects { get; } = new List<ProjectProject>();

    //[InverseProperty("SaleLine")]
    [NotMapped]
    public virtual ICollection<ProjectTask> ProjectTasks { get; } = new List<ProjectTask>();

    //[InverseProperty("SaleLine")]
    [NotMapped]
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; } = new List<PurchaseOrderLine>();

    //[InverseProperty("Line")]
    [NotMapped]
    public virtual ICollection<SaleOrderOption> SaleOrderOptions { get; } = new List<SaleOrderOption>();

    //[InverseProperty("SaleLine")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoves { get; } = new List<StockMove>();

    [ForeignKey("SaleOrderLineId")]
    //[InverseProperty("SaleOrderLines")]
    [NotMapped]
    public virtual ICollection<AccountTax> AccountTaxes { get; } = new List<AccountTax>();

    [ForeignKey("OrderLineId")]
    //[InverseProperty("OrderLines")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> InvoiceLines { get; } = new List<AccountMoveLine>();

    [ForeignKey("SaleOrderLineId")]
    //[InverseProperty("SaleOrderLines")]
    [NotMapped]
    public virtual ICollection<ProductTemplateAttributeValue> ProductTemplateAttributeValues { get; } = new List<ProductTemplateAttributeValue>();
}
