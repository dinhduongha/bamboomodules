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

[Table("repair_order")]
//[Index("InvoiceMethod", Name = "repair_order_invoice_method_index")]
//[Index("CompanyId", Name = "repair_order__company_id_index")]
//[Index("LocationId", Name = "repair_order__location_id_index")]
//[Index("Name", Name = "repair_order_name", IsUnique = true)]
//[Index("PartnerId", Name = "repair_order__partner_id_index")]
public partial class RepairOrder: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("move_id")]
    public Guid? MoveId { get; set; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_uom")]
    public Guid? ProductUom { get; set; }

    [Column("lot_id")]
    public Guid? LotId { get; set; }

    // [Column("partner_id")]
    // public Guid? PartnerId { get; set; }

    [Column("picking_type_id")]
    public Guid? PickingTypeId { get; set; }

    [Column("procurement_group_id")]
    public Guid? ProcurementGroupId { get; set; }

    [Column("address_id")]
    public Guid? AddressId { get; set; }

    [Column("location_id")]
    public Guid? LocationId { get; set; }

    [Column("product_location_src_id")]
    public Guid? ProductLocationSrcId { get; set; }

    [Column("product_location_dest_id")]
    public Guid? ProductLocationDestId { get; set; }

    [Column("location_dest_id")]
    public Guid? LocationDestId { get; set; }

    [Column("parts_location_id")]
    public Guid? PartsLocationId { get; set; }

    [Column("recycle_location_id")]
    public Guid? RecycleLocationId { get; set; }

    [Column("pricelist_id")]
    public Guid? PricelistId { get; set; }

    [Column("partner_invoice_id")]
    public Guid? PartnerInvoiceId { get; set; }

    [Column("invoice_id")]
    public Guid? InvoiceId { get; set; }


    [Column("sale_order_id")]
    public Guid? SaleOrderId { get; set; }

    [Column("sale_order_line_id")]
    public Guid? SaleOrderLineId { get; set; }

    [Column("picking_id")]
    public Guid? PickingId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("invoice_method")]
    public string? InvoiceMethod { get; set; }

    [Column("priority")]
    public string? Priority { get; set; }

    [JsonField]
    [Column("repair_properties", TypeName = "jsonb")]
    public string? RepairProperties { get; set; }

    [Column("schedule_date")]
    public DateTime? ScheduleDate { get; set; }

    [Column("guarantee_limit")]
    public DateTime? GuaranteeLimit { get; set; }

    [Column("internal_notes")]
    public string? InternalNotes { get; set; }

    [Column("quotation_notes")]
    public string? QuotationNotes { get; set; }

    [Column("product_qty")]
    public decimal? ProductQty { get; set; }

    [Column("under_warranty")]
    public bool? UnderWarranty { get; set; }

    [Column("is_parts_available")]
    public bool? IsPartsAvailable { get; set; }

    [Column("is_parts_late")]
    public bool? IsPartsLate { get; set; }

    // [Column("schedule_date", TypeName = "timestamp without time zone")]
    // public DateTime? ScheduleDate { get; set; }

    [Column("invoiced")]
    public bool? Invoiced { get; set; }

    [Column("repaired")]
    public bool? Repaired { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("amount_untaxed")]
    public double? AmountUntaxed { get; set; }

    [Column("amount_tax")]
    public double? AmountTax { get; set; }

    [Column("amount_total")]
    public double? AmountTotal { get; set; }

    // [Many2one]
    [ForeignKey("AddressId")]
    // [InverseProperty("RepairOrderAddress")] //Many2one
    public virtual ResPartner? Address { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("RepairOrder")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("RepairOrderCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("InvoiceId")]
    // [InverseProperty("RepairOrder")] //Many2one
    public virtual AccountMove? Invoice { get; set; }

    // [Many2one]
    [ForeignKey("LocationId")]
    // [InverseProperty("RepairOrder")] //Many2one
    // [InverseProperty("RepairOrderLocation")] //Many2one
    public virtual StockLocation? Location { get; set; }

    // [Many2one]
    [ForeignKey("LocationDestId")]
    // [InverseProperty("RepairOrderLocationDest")] //Many2one
    public virtual StockLocation? LocationDest { get; set; }

    // [Many2one]
    [ForeignKey("LotId")]
    // [InverseProperty("RepairOrder")] //Many2one
    public virtual StockLot? Lot { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("RepairOrder")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("MoveId")]
    // [InverseProperty("RepairOrder")] //Many2one
    public virtual StockMove? Move { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("RepairOrderPartner")] //Many2one
    // [InverseProperty("RepairOrder")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("PartnerInvoiceId")]
    // [InverseProperty("RepairOrderPartnerInvoice")] //Many2one
    public virtual ResPartner? PartnerInvoice { get; set; }

    // [Many2one]
    [ForeignKey("PartsLocationId")]
    // [InverseProperty("RepairOrderPartsLocation")] //Many2one
    public virtual StockLocation? PartsLocation { get; set; }

    // [Many2one]
    [ForeignKey("PickingId")]
    // [InverseProperty("RepairOrder")] //Many2one
    public virtual StockPicking? Picking { get; set; }

    // [Many2one]
    [ForeignKey("PickingTypeId")]
    // [InverseProperty("RepairOrder")] //Many2one
    public virtual StockPickingType? PickingType { get; set; }

    // [Many2one]
    [ForeignKey("PricelistId")]
    // [InverseProperty("RepairOrder")] //Many2one
    public virtual ProductPricelist? Pricelist { get; set; }

    // [Many2one]
    [ForeignKey("ProcurementGroupId")]
    // [InverseProperty("RepairOrder")] //Many2one
    public virtual ProcurementGroup? ProcurementGroup { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("RepairOrder")] //Many2one
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [ForeignKey("ProductLocationDestId")]
    // [InverseProperty("RepairOrderProductLocationDest")] //Many2one
    public virtual StockLocation? ProductLocationDest { get; set; }

    // [Many2one]
    [ForeignKey("ProductLocationSrcId")]
    // [InverseProperty("RepairOrderProductLocationSrc")] //Many2one
    public virtual StockLocation? ProductLocationSrc { get; set; }

    // [Many2one]
    [ForeignKey("ProductUom")]
    // [InverseProperty("RepairOrder")] //Many2one
    public virtual UomUom? ProductUomNavigation { get; set; }

    // [Many2one]
    [ForeignKey("RecycleLocationId")]
    // [InverseProperty("RepairOrderRecycleLocation")] //Many2one
    public virtual StockLocation? RecycleLocation { get; set; }

    // [One2many]
    [ForeignKey("RepairId")]
    [InverseProperty("Repair")]
    public virtual ICollection<RepairFee> RepairFee { get; set; }

    // [One2many]
    [ForeignKey("RepairId")]
    [InverseProperty("Repair")]
    public virtual ICollection<RepairLine> RepairLine { get; set; }

    // [Many2one]
    [ForeignKey("SaleOrderId")]
    // [InverseProperty("RepairOrder")] //Many2one
    public virtual SaleOrder? SaleOrder { get; set; }

    // [Many2one]
    [ForeignKey("SaleOrderLineId")]
    // [InverseProperty("RepairOrder")] //Many2one
    public virtual SaleOrderLine? SaleOrderLine { get; set; }

    // [One2many]
    [ForeignKey("RepairId")]
    [InverseProperty("Repair")]
    public virtual ICollection<StockMove> StockMove { get; set; }

    // [One2many]
    [ForeignKey("RepairId")]
    [InverseProperty("Repair")]
    public virtual ICollection<StockWarnInsufficientQtyRepair> StockWarnInsufficientQtyRepair { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("RepairOrderUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("RepairOrderWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("RepairOrderId")] //Many2many
    // [InverseProperty("RepairOrder")] //Many2many
    public virtual ICollection<RepairTags> RepairTags { get; set; }
}
