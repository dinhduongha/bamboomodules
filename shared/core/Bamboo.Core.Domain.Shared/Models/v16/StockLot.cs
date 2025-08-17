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

[Table("stock_lot")]
//[Index("CompanyId", Name = "stock_lot_company_id_index")]
//[Index("ProductId", Name = "stock_lot_product_id_index")]
public partial class StockLot: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_uom_id")]
    public Guid? ProductUomId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("ref")]
    public string? Ref { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("product_expiry_reminded")]
    public bool? ProductExpiryReminded { get; set; }

    [Column("expiration_date", TypeName = "timestamp without time zone")]
    public DateTime? ExpirationDate { get; set; }

    [Column("use_date", TypeName = "timestamp without time zone")]
    public DateTime? UseDate { get; set; }

    [Column("removal_date", TypeName = "timestamp without time zone")]
    public DateTime? RemovalDate { get; set; }

    [Column("alert_date", TypeName = "timestamp without time zone")]
    public DateTime? AlertDate { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("StockLot")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("StockLotCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("StockLot")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [One2many]
    [ForeignKey("LotProducingId")]
    [InverseProperty("LotProducing")]
    public virtual ICollection<MrpProduction> MrpProduction { get; set; }

    // [One2many]
    [ForeignKey("LotId")]
    [InverseProperty("Lot")]
    public virtual ICollection<MrpUnbuild> MrpUnbuild { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("StockLot")] //Many2one
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [ForeignKey("ProductUomId")]
    // [InverseProperty("StockLot")] //Many2one
    public virtual UomUom? ProductUom { get; set; }

    // [One2many]
    [ForeignKey("LotId")]
    [InverseProperty("Lot")]
    public virtual ICollection<RepairLine> RepairLine { get; set; }

    // [One2many]
    [ForeignKey("LotId")]
    [InverseProperty("Lot")]
    public virtual ICollection<RepairOrder> RepairOrder { get; set; }

    // [One2many]
    [ForeignKey("OrderFinishedLotId")]
    [InverseProperty("OrderFinishedLot")]
    public virtual ICollection<StockMove> StockMove { get; set; }

    // [One2many]
    [ForeignKey("LotId")]
    [InverseProperty("Lot")]
    public virtual ICollection<StockMoveLine> StockMoveLine { get; set; }

    // [One2many]
    [ForeignKey("LotId")]
    [InverseProperty("Lot")]
    public virtual ICollection<StockQuant> StockQuant { get; set; }

    // [One2many]
    [ForeignKey("LotId")]
    [InverseProperty("Lot")]
    public virtual ICollection<StockScrap> StockScrap { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("StockLotWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockLotId")]
    // [InverseProperty("StockLot")]
    // public virtual ICollection<ExpiryPickingConfirmation> ExpiryPickingConfirmation { get; set; }
}
