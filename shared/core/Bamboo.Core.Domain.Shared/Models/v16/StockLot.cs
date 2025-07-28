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
//[Index("TenantId", Name = "stock_lot_company_id_index")]
//[Index("ProductId", Name = "stock_lot_product_id_index")]
public partial class StockLot: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    // v16-Compat
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_uom_id")]
    public Guid? ProductUomId { get; set; }

    [Column("location_id")]
    public Guid? LocationId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("ref")]
    public string? Ref { get; set; }

    [JsonField]
    [Column("lot_properties", TypeName = "jsonb")]
    public string? LotProperties { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [JsonField]
    [Column("standard_price", TypeName = "jsonb")]
    public string? StandardPrice { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("StockLots")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("StockLotCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LocationId")]
    //[InverseProperty("StockLots")]
    [NotMapped]
    public virtual StockLocation? Location { get; set; }

    // v16-Compat
    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("StockLots")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("StockLots")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("ProductUomId")]
    //[InverseProperty("StockLots")]
    [NotMapped]
    public virtual UomUom? ProductUom { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("StockLotWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    /// TODO: DISABLE INVERSE COLLECTIONS
    //[InverseProperty("LotProducing")]
    [NotMapped]
    public virtual ICollection<MrpProduction> MrpProductions { get; set; } 

    //[InverseProperty("Lot")]
    [NotMapped]
    public virtual ICollection<MrpUnbuild> MrpUnbuilds { get; set; } 

    //[InverseProperty("Lot")]
    [NotMapped]
    public virtual ICollection<RepairLine> RepairLines { get; set; } 

    //[InverseProperty("Lot")]
    [NotMapped]
    public virtual ICollection<RepairOrder> RepairOrders { get; set; } 

    //[InverseProperty("Lot")]
    [NotMapped]
    public virtual ICollection<StockMoveLine> StockMoveLines { get; set; } 

    //[InverseProperty("OrderFinishedLot")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoves { get; set; } 

    //[InverseProperty("Lot")]
    [NotMapped]
    public virtual ICollection<StockQuant> StockQuants { get; set; } 

    //[InverseProperty("Lot")]
    [NotMapped]
    public virtual ICollection<StockScrap> StockScraps { get; set; } 

}
