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

[Table("stock_scrap")]
public partial class StockScrap: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_uom_id")]
    public Guid? ProductUomId { get; set; }

    [Column("lot_id")]
    public Guid? LotId { get; set; }

    [Column("package_id")]
    public Guid? PackageId { get; set; }

    [Column("owner_id")]
    public Guid? OwnerId { get; set; }

    [Column("move_id")]
    public Guid? MoveId { get; set; }

    [Column("picking_id")]
    public Guid? PickingId { get; set; }

    [Column("location_id")]
    public Guid? LocationId { get; set; }

    [Column("scrap_location_id")]
    public Guid? ScrapLocationId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("origin")]
    public string? Origin { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("scrap_qty")]
    public decimal? ScrapQty { get; set; }

    [Column("date_done", TypeName = "timestamp without time zone")]
    public DateTime? DateDone { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("production_id")]
    public Guid? ProductionId { get; set; }

    [Column("workorder_id")]
    public Guid? WorkorderId { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("StockScraps")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("StockScrapCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LocationId")]
    //[InverseProperty("StockScrapLocations")]
    [NotMapped]
    public virtual StockLocation? Location { get; set; }

    [ForeignKey("LotId")]
    //[InverseProperty("StockScraps")]
    [NotMapped]
    public virtual StockLot? Lot { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("StockScraps")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("MoveId")]
    //[InverseProperty("StockScraps")]
    [NotMapped]
    public virtual StockMove? Move { get; set; }

    [ForeignKey("OwnerId")]
    //[InverseProperty("StockScraps")]
    [NotMapped]
    public virtual ResPartner? Owner { get; set; }

    [ForeignKey("PackageId")]
    //[InverseProperty("StockScraps")]
    [NotMapped]
    public virtual StockQuantPackage? Package { get; set; }

    [ForeignKey("PickingId")]
    //[InverseProperty("StockScraps")]
    [NotMapped]
    public virtual StockPicking? Picking { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("StockScraps")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("ProductUomId")]
    //[InverseProperty("StockScraps")]
    [NotMapped]
    public virtual UomUom? ProductUom { get; set; }

    [ForeignKey("ProductionId")]
    //[InverseProperty("StockScraps")]
    [NotMapped]
    public virtual MrpProduction? Production { get; set; }

    [ForeignKey("ScrapLocationId")]
    //[InverseProperty("StockScrapScrapLocations")]
    [NotMapped]
    public virtual StockLocation? ScrapLocation { get; set; }

    [ForeignKey("WorkorderId")]
    //[InverseProperty("StockScraps")]
    [NotMapped]
    public virtual MrpWorkorder? Workorder { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("StockScrapWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Scrap")]
    [NotMapped]
    public virtual ICollection<StockWarnInsufficientQtyScrap> StockWarnInsufficientQtyScraps { get; } = new List<StockWarnInsufficientQtyScrap>();


}
