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

[Table("purchase_order_line")]
//[Index("DatePlanned", Name = "purchase_order_line__date_planned_index")]
//[Index("OrderId", Name = "purchase_order_line__order_id_index")]
public partial class PurchaseOrderLine: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("product_uom")]
    public Guid? ProductUom { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("order_id")]
    public Guid? OrderId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("product_packaging_id")]
    public Guid? ProductPackagingId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("qty_received_method")]
    public string? QtyReceivedMethod { get; set; }

    [Column("display_type")]
    public string? DisplayType { get; set; }

    [JsonField] // AnalyticDistribution
    [Column("analytic_distribution", TypeName = "jsonb")]
    public JsonElement? AnalyticDistribution { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("product_qty")]
    public decimal? ProductQty { get; set; }

    [Column("discount")]
    public decimal? Discount { get; set; }

    [Column("price_unit")]
    public decimal? PriceUnit { get; set; }

    [Column("price_subtotal")]
    public decimal? PriceSubtotal { get; set; }

    [Column("price_total")]
    public decimal? PriceTotal { get; set; }

    [Column("qty_invoiced")]
    public decimal? QtyInvoiced { get; set; }

    [Column("qty_received")]
    public decimal? QtyReceived { get; set; }

    [Column("qty_received_manual")]
    public decimal? QtyReceivedManual { get; set; }

    [Column("qty_to_invoice")]
    public decimal? QtyToInvoice { get; set; }

    [Column("is_downpayment")]
    public bool? IsDownpayment { get; set; }

    [Column("date_planned", TypeName = "timestamp without time zone")]
    public DateTime? DatePlanned { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("product_uom_qty")]
    public double? ProductUomQty { get; set; }

    [Column("price_tax")]
    public double? PriceTax { get; set; }

    [Column("product_packaging_qty")]
    public double? ProductPackagingQty { get; set; }

    [Column("orderpoint_id")]
    public Guid? OrderpointId { get; set; }

    [Column("location_final_id")]
    public Guid? LocationFinalId { get; set; }

    [Column("group_id")]
    public Guid? GroupId { get; set; }

    [Column("product_description_variants")]
    public string? ProductDescriptionVariants { get; set; }

    [Column("propagate_cancel")]
    public bool? PropagateCancel { get; set; }

    [Column("sale_order_id")]
    public Guid? SaleOrderId { get; set; }

    [Column("sale_line_id")]
    public Guid? SaleLineId { get; set; }

    [Column("price_total_cc")]
    public decimal? PriceTotalCc { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PurchaseLineId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PurchaseLine")] // One2many
    public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

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

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("GroupId")]
    public virtual ProcurementGroup? Group { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LocationFinalId")]
    public virtual StockLocation? LocationFinal { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("OrderId")]
    public virtual PurchaseOrder? Order { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("OrderpointId")]
    public virtual StockWarehouseOrderpoint? Orderpoint { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductId")]
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductPackagingId")]
    public virtual ProductPackaging? ProductPackaging { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductUom")]
    public virtual UomUom? ProductUomNavigation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SaleLineId")]
    public virtual SaleOrderLine? SaleLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SaleOrderId")]
    public virtual SaleOrder? SaleOrder { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PurchaseLineId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PurchaseLine")] // One2many
    public virtual ICollection<StockMove> StockMove { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("PurchaseOrderLineId")] // Many2many // Normal
    // [InverseProperty("PurchaseOrderLine")] // Many2many // Normal
    public virtual ICollection<AccountTax> AccountTax { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("CreatedPurchaseLineId")] // Many2many // Normal
    // [InverseProperty("CreatedPurchaseLine")] // Many2many // Normal
    public virtual ICollection<StockMove> Move { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("PurchaseOrderLineId")] // Many2many // Normal
    // [InverseProperty("PurchaseOrderLine")] // Many2many // Normal
    public virtual ICollection<ProductTemplateAttributeValue> ProductTemplateAttributeValue { get; set; }
}
