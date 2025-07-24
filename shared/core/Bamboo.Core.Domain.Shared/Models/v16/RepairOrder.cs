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
//[Index("TenantId", Name = "repair_order_company_id_index")]
//[Index("InvoiceMethod", Name = "repair_order_invoice_method_index")]
//[Index("LocationId", Name = "repair_order_location_id_index")]
//[Index("Name", Name = "repair_order_name", IsUnique = true)]
//[Index("PartnerId", Name = "repair_order_partner_id_index")]
public partial class RepairOrder : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    // v16-Compat
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("move_id")]
    public Guid? MoveId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_uom")]
    public Guid? ProductUom { get; set; }

    [Column("lot_id")]
    public Guid? LotId { get; set; }

    [Column("picking_type_id")]
    public Guid? PickingTypeId { get; set; }

    [Column("procurement_group_id")]
    public Guid? ProcurementGroupId { get; set; }

    // v16-Compat
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

    // v16-Compat
    [Column("pricelist_id")]
    public Guid? PricelistId { get; set; }

    // v16-Compat
    [Column("partner_invoice_id")]
    public Guid? PartnerInvoiceId { get; set; }

    // v16-Compat
    [Column("invoice_id")]
    public Guid? InvoiceId { get; set; }

    // v16-Compat
    // [Column("move_id")]
    // public Guid? MoveId { get; set; }

    [Column("sale_order_id")]
    public Guid? SaleOrderId { get; set; }

    [Column("sale_order_line_id")]
    public Guid? SaleOrderLineId { get; set; }

    [Column("picking_id")]
    public Guid? PickingId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    // v16-Compat
    [Column("description")]
    public string? Description { get; set; }

    [Column("state")]
    public string? State { get; set; }

    // v16-Compat
    [Column("invoice_method")]
    public string? InvoiceMethod { get; set; }

    [Column("priority")]
    public string? Priority { get; set; }

    [JsonField]
    [Column("repair_properties", TypeName = "jsonb")]
    public string? RepairProperties { get; set; }

    // v16-Compat
    // [Column("schedule_date")]
    // public DateTime? ScheduleDate { get; set; }

    // v16-Compat
    [Column("guarantee_limit")]
    public DateTime? GuaranteeLimit { get; set; }

    [Column("internal_notes")]
    public string? InternalNotes { get; set; }

    // v16-Compat
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

    [Column("schedule_date", TypeName = "timestamp without time zone")]
    public DateTime? ScheduleDate { get; set; }

    // v16-Compat
    [Column("invoiced")]
    public bool? Invoiced { get; set; }

    // v16-Compat
    [Column("repaired")]
    public bool? Repaired { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // v16-Compat
    [Column("amount_untaxed")]
    public double? AmountUntaxed { get; set; }

    // v16-Compat
    [Column("amount_tax")]
    public double? AmountTax { get; set; }

    // v16-Compat
    [Column("amount_total")]
    public double? AmountTotal { get; set; }

    [ForeignKey("AddressId")]
    //[InverseProperty("RepairOrderAddresses")]
    [NotMapped]
    public virtual ResPartner? Address { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("RepairOrders")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("RepairOrderCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("InvoiceId")]
    //[InverseProperty("RepairOrders")]
    [NotMapped]
    public virtual AccountMove? Invoice { get; set; }

    [ForeignKey("LocationId")]
    //[InverseProperty("RepairOrders")]
    [NotMapped]
    public virtual StockLocation? Location { get; set; }

    [ForeignKey("LotId")]
    //[InverseProperty("RepairOrders")]
    [NotMapped]
    public virtual StockLot? Lot { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("RepairOrders")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("MoveId")]
    //[InverseProperty("RepairOrders")]
    [NotMapped]
    public virtual StockMove? Move { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("RepairOrderPartners")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("PartnerInvoiceId")]
    //[InverseProperty("RepairOrderPartnerInvoices")]
    [NotMapped]
    public virtual ResPartner? PartnerInvoice { get; set; }

    [ForeignKey("PickingId")]
    //[InverseProperty("RepairOrders")]
    [NotMapped]
    public virtual StockPicking? Picking { get; set; }

    [ForeignKey("PricelistId")]
    //[InverseProperty("RepairOrders")]
    [NotMapped]
    public virtual ProductPricelist? Pricelist { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("RepairOrders")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("ProductUom")]
    //[InverseProperty("RepairOrders")]
    [NotMapped]
    public virtual UomUom? ProductUomNavigation { get; set; }

    [ForeignKey("SaleOrderId")]
    //[InverseProperty("RepairOrders")]
    [NotMapped]
    public virtual SaleOrder? SaleOrder { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("RepairOrderUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("RepairOrderWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Repair")]
    [NotMapped]
    public virtual ICollection<RepairFee> RepairFees { get; set; } = new List<RepairFee>();

    //[InverseProperty("Repair")]
    [NotMapped]
    public virtual ICollection<RepairLine> RepairLines { get; set; } = new List<RepairLine>();

    //[InverseProperty("Repair")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoves { get; set; } = new List<StockMove>();

    //[InverseProperty("Repair")]
    [NotMapped]
    public virtual ICollection<StockWarnInsufficientQtyRepair> StockWarnInsufficientQtyRepairs { get; set; } = new List<StockWarnInsufficientQtyRepair>();

    [ForeignKey("RepairOrderId")]
    //[InverseProperty("RepairOrders")]
    [NotMapped]
    public virtual ICollection<RepairTag> RepairTags { get; set; } = new List<RepairTag>();
}
