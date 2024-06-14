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

[Table("stock_picking")]
//[Index("TenantId", Name = "stock_picking_company_id_index")]
//[Index("Name", "TenantId", Name = "stock_picking_name_uniq", IsUnique = true)]
//[Index("PickingTypeId", Name = "stock_picking_picking_type_id_index")]
//[Index("ScheduledDate", Name = "stock_picking_scheduled_date_index")]
//[Index("State", Name = "stock_picking_state_index")]
public partial class StockPicking: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("backorder_id")]
    public Guid? BackorderId { get; set; }

    [Column("group_id")]
    public Guid? GroupId { get; set; }

    [Column("location_id")]
    public Guid? LocationId { get; set; }

    [Column("location_dest_id")]
    public Guid? LocationDestId { get; set; }

    [Column("picking_type_id")]
    public Guid? PickingTypeId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("owner_id")]
    public Guid? OwnerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("origin")]
    public string? Origin { get; set; }

    [Column("move_type")]
    public string? MoveType { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("priority")]
    public string? Priority { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("has_deadline_issue")]
    public bool? HasDeadlineIssue { get; set; }

    [Column("printed")]
    public bool? Printed { get; set; }

    [Column("is_locked")]
    public bool? IsLocked { get; set; }

    [Column("immediate_transfer")]
    public bool? ImmediateTransfer { get; set; }

    [Column("scheduled_date", TypeName = "timestamp without time zone")]
    public DateTime? ScheduledDate { get; set; }

    [Column("date_deadline", TypeName = "timestamp without time zone")]
    public DateTime? DateDeadline { get; set; }

    [Column("date", TypeName = "timestamp without time zone")]
    public DateTime? Date { get; set; }

    [Column("date_done", TypeName = "timestamp without time zone")]
    public DateTime? DateDone { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("pos_session_id")]
    public Guid? PosSessionId { get; set; }

    [Column("pos_order_id")]
    public Guid? PosOrderId { get; set; }

    [Column("sale_id")]
    public Guid? SaleId { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [ForeignKey("BackorderId")]
    //[InverseProperty("InverseBackorder")]
    [NotMapped]
    public virtual StockPicking? Backorder { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("StockPickings")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("StockPickingCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("GroupId")]
    //[InverseProperty("StockPickings")]
    [NotMapped]
    public virtual ProcurementGroup? Group { get; set; }

    [ForeignKey("LocationId")]
    //[InverseProperty("StockPickingLocations")]
    [NotMapped]
    public virtual StockLocation? Location { get; set; }

    [ForeignKey("LocationDestId")]
    //[InverseProperty("StockPickingLocationDests")]
    [NotMapped]
    public virtual StockLocation? LocationDest { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("StockPickings")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("OwnerId")]
    //[InverseProperty("StockPickingOwners")]
    [NotMapped]
    public virtual ResPartner? Owner { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("StockPickingPartners")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("PickingTypeId")]
    //[InverseProperty("StockPickings")]
    [NotMapped]
    public virtual StockPickingType? PickingType { get; set; }

    [ForeignKey("PosOrderId")]
    //[InverseProperty("StockPickings")]
    [NotMapped]
    public virtual PosOrder? PosOrder { get; set; }

    [ForeignKey("PosSessionId")]
    //[InverseProperty("StockPickings")]
    [NotMapped]
    public virtual PosSession? PosSession { get; set; }

    [ForeignKey("SaleId")]
    //[InverseProperty("StockPickings")]
    [NotMapped]
    public virtual SaleOrder? Sale { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("StockPickingUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("WebsiteId")]
    //[InverseProperty("StockPickings")]
    [NotMapped]
    public virtual Website? Website { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("StockPickingWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Backorder")]
    [NotMapped]
    public virtual ICollection<StockPicking> InverseBackorder { get; } = new List<StockPicking>();

    //[InverseProperty("Picking")]
    [NotMapped]
    public virtual ICollection<RepairOrder> RepairOrders { get; } = new List<RepairOrder>();

    //[InverseProperty("Picking")]
    [NotMapped]
    public virtual ICollection<StockBackorderConfirmationLine> StockBackorderConfirmationLines { get; } = new List<StockBackorderConfirmationLine>();

    //[InverseProperty("Picking")]
    [NotMapped]
    public virtual ICollection<StockImmediateTransferLine> StockImmediateTransferLines { get; } = new List<StockImmediateTransferLine>();

    //[InverseProperty("Picking")]
    [NotMapped]
    public virtual ICollection<StockMoveLine> StockMoveLines { get; } = new List<StockMoveLine>();

    //[InverseProperty("Picking")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoves { get; } = new List<StockMove>();

    //[InverseProperty("Picking")]
    [NotMapped]
    public virtual ICollection<StockPackageDestination> StockPackageDestinations { get; } = new List<StockPackageDestination>();

    //[InverseProperty("Picking")]
    [NotMapped]
    public virtual ICollection<StockPackageLevel> StockPackageLevels { get; } = new List<StockPackageLevel>();

    //[InverseProperty("Picking")]
    [NotMapped]
    public virtual ICollection<StockReturnPicking> StockReturnPickings { get; } = new List<StockReturnPicking>();

    //[InverseProperty("Picking")]
    [NotMapped]
    public virtual ICollection<StockScrap> StockScraps { get; } = new List<StockScrap>();

    [ForeignKey("StockPickingId")]
    //[InverseProperty("StockPickings")]
    [NotMapped]
    public virtual ICollection<ConfirmStockSm> ConfirmStockSms { get; } = new List<ConfirmStockSm>();

    [ForeignKey("StockPickingId")]
    //[InverseProperty("StockPickings")]
    [NotMapped]
    public virtual ICollection<LotLabelLayout> LotLabelLayouts { get; } = new List<LotLabelLayout>();

    [ForeignKey("StockPickingId")]
    //[InverseProperty("StockPickings")]
    [NotMapped]
    public virtual ICollection<PickingLabelType> PickingLabelTypes { get; } = new List<PickingLabelType>();

    [ForeignKey("StockPickingId")]
    //[InverseProperty("StockPickings")]
    [NotMapped]
    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; } = new List<PurchaseOrder>();

    [ForeignKey("StockPickingId")]
    //[InverseProperty("StockPickings")]
    [NotMapped]
    public virtual ICollection<StockBackorderConfirmation> StockBackorderConfirmations { get; } = new List<StockBackorderConfirmation>();

    [ForeignKey("StockPickingId")]
    //[InverseProperty("StockPickings")]
    [NotMapped]
    public virtual ICollection<StockImmediateTransfer> StockImmediateTransfers { get; } = new List<StockImmediateTransfer>();
}
