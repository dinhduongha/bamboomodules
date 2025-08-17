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
public partial class StockScrap: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("production_id")]
    public Guid? ProductionId { get; set; }

    [Column("workorder_id")]
    public Guid? WorkorderId { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("StockScrap")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("StockScrapCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("LocationId")]
    // [InverseProperty("StockScrapLocation")] //Many2one
    public virtual StockLocation? Location { get; set; }

    // [Many2one]
    [ForeignKey("LotId")]
    // [InverseProperty("StockScrap")] //Many2one
    public virtual StockLot? Lot { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("StockScrap")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("MoveId")]
    // [InverseProperty("StockScrap")] //Many2one
    public virtual StockMove? Move { get; set; }

    // [Many2one]
    [ForeignKey("OwnerId")]
    // [InverseProperty("StockScrap")] //Many2one
    public virtual ResPartner? Owner { get; set; }

    // [Many2one]
    [ForeignKey("PackageId")]
    // [InverseProperty("StockScrap")] //Many2one
    public virtual StockQuantPackage? Package { get; set; }

    // [Many2one]
    [ForeignKey("PickingId")]
    // [InverseProperty("StockScrap")] //Many2one
    public virtual StockPicking? Picking { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("StockScrap")] //Many2one
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [ForeignKey("ProductUomId")]
    // [InverseProperty("StockScrap")] //Many2one
    public virtual UomUom? ProductUom { get; set; }

    // [Many2one]
    [ForeignKey("ProductionId")]
    // [InverseProperty("StockScrap")] //Many2one
    public virtual MrpProduction? Production { get; set; }

    // [Many2one]
    [ForeignKey("ScrapLocationId")]
    // [InverseProperty("StockScrapScrapLocation")] //Many2one
    public virtual StockLocation? ScrapLocation { get; set; }

    // [One2many]
    [ForeignKey("ScrapId")]
    [InverseProperty("Scrap")]
    public virtual ICollection<StockWarnInsufficientQtyScrap> StockWarnInsufficientQtyScrap { get; set; }

    // [Many2one]
    [ForeignKey("WorkorderId")]
    // [InverseProperty("StockScrap")] //Many2one
    public virtual MrpWorkorder? Workorder { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("StockScrapWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
