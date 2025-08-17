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

[Table("purchase_requisition")]
//[Index("ScheduleDate", Name = "purchase_requisition_schedule_date_index")]
public partial class PurchaseRequisition: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("vendor_id")]
    public Guid? VendorId { get; set; }

    [Column("type_id")]
    public Guid? TypeId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("origin")]
    public string? Origin { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("ordering_date")]
    public DateTime? OrderingDate { get; set; }

    [Column("schedule_date")]
    public DateTime? ScheduleDate { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("date_end", TypeName = "timestamp without time zone")]
    public DateTime? DateEnd { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("warehouse_id")]
    public Guid? WarehouseId { get; set; }

    [Column("picking_type_id")]
    public Guid? PickingTypeId { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("PurchaseRequisition")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("PurchaseRequisitionCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CurrencyId")]
    // [InverseProperty("PurchaseRequisition")] //Many2one
    public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("PurchaseRequisition")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("PickingTypeId")]
    // [InverseProperty("PurchaseRequisition")] //Many2one
    public virtual StockPickingType? PickingType { get; set; }

    // [One2many]
    [ForeignKey("RequisitionId")]
    [InverseProperty("Requisition")]
    public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }

    // [One2many]
    [ForeignKey("RequisitionId")]
    [InverseProperty("Requisition")]
    public virtual ICollection<PurchaseRequisitionLine> PurchaseRequisitionLine { get; set; }

    // [Many2one]
    [ForeignKey("TypeId")]
    // [InverseProperty("PurchaseRequisition")] //Many2one
    public virtual PurchaseRequisitionType? Type { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("PurchaseRequisitionUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("VendorId")]
    // [InverseProperty("PurchaseRequisition")] //Many2one
    public virtual ResPartner? Vendor { get; set; }

    // [Many2one]
    [ForeignKey("WarehouseId")]
    // [InverseProperty("PurchaseRequisition")] //Many2one
    public virtual StockWarehouse? Warehouse { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("PurchaseRequisitionWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
