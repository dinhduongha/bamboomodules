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
//[Index("TenantId", Name = "mrp_unbuild_company_id_index")]
public partial class MrpUnbuild: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

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
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("product_qty")]
    public double? ProductQty { get; set; }

    [ForeignKey("BomId")]
    //[InverseProperty("MrpUnbuilds")]
    [NotMapped]
    public virtual MrpBom? Bom { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("MrpUnbuilds")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MrpUnbuildCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LocationId")]
    //[InverseProperty("MrpUnbuildLocations")]
    [NotMapped]
    public virtual StockLocation? Location { get; set; }

    [ForeignKey("LocationDestId")]
    //[InverseProperty("MrpUnbuildLocationDests")]
    [NotMapped]
    public virtual StockLocation? LocationDest { get; set; }

    [ForeignKey("LotId")]
    //[InverseProperty("MrpUnbuilds")]
    [NotMapped]
    public virtual StockLot? Lot { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("MrpUnbuilds")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("MoId")]
    //[InverseProperty("MrpUnbuilds")]
    [NotMapped]
    public virtual MrpProduction? Mo { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("MrpUnbuilds")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("ProductUomId")]
    //[InverseProperty("MrpUnbuilds")]
    [NotMapped]
    public virtual UomUom? ProductUom { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MrpUnbuildWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("ConsumeUnbuild")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoveConsumeUnbuilds { get; } = new List<StockMove>();

    //[InverseProperty("Unbuild")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoveUnbuilds { get; } = new List<StockMove>();

    //[InverseProperty("Unbuild")]
    [NotMapped]
    public virtual ICollection<StockWarnInsufficientQtyUnbuild> StockWarnInsufficientQtyUnbuilds { get; } = new List<StockWarnInsufficientQtyUnbuild>();

}
