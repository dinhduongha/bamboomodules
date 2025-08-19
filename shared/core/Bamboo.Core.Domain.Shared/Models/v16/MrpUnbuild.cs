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

[Table("mrp_unbuild")]
//[Index("CompanyId", Name = "mrp_unbuild__company_id_index")]
public partial class MrpUnbuild: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("bom_id")]
    public Guid? BomId { get; set; }

    [Column("mo_id")]
    public Guid? MoId { get; set; }

    [Column("lot_id")]
    public Guid? LotId { get; set; }

    [Column("location_id")]
    public Guid? LocationId { get; set; }

    [Column("location_dest_id")]
    public Guid? LocationDestId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("product_qty")]
    public double? ProductQty { get; set; }

    // [Many2one]
    [ForeignKey("BomId")]
    // [InverseProperty("MrpUnbuild")] //Many2one
    public virtual MrpBom? Bom { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("MrpUnbuild")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("MrpUnbuildCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("LocationId")]
    // [InverseProperty("MrpUnbuildLocation")] //Many2one
    public virtual StockLocation? Location { get; set; }

    // [Many2one]
    [ForeignKey("LocationDestId")]
    // [InverseProperty("MrpUnbuildLocationDest")] //Many2one
    public virtual StockLocation? LocationDest { get; set; }

    // [Many2one]
    [ForeignKey("LotId")]
    // [InverseProperty("MrpUnbuild")] //Many2one
    public virtual StockLot? Lot { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MrpUnbuild")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("MoId")]
    // [InverseProperty("MrpUnbuild")] //Many2one
    public virtual MrpProduction? Mo { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("MrpUnbuild")] //Many2one
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [ForeignKey("ProductUomId")]
    // [InverseProperty("MrpUnbuild")] //Many2one
    public virtual UomUom? ProductUom { get; set; }

    // [One2many]
    [ForeignKey("ConsumeUnbuildId")]
    [InverseProperty("ConsumeUnbuild")]
    public virtual ICollection<StockMove> StockMoveConsumeUnbuild { get; set; }

    // [One2many]
    [ForeignKey("UnbuildId")]
    [InverseProperty("Unbuild")]
    public virtual ICollection<StockMove> StockMoveUnbuild { get; set; }

    // [One2many]
    [ForeignKey("UnbuildId")]
    [InverseProperty("Unbuild")]
    public virtual ICollection<StockWarnInsufficientQtyUnbuild> StockWarnInsufficientQtyUnbuild { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("MrpUnbuildWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
