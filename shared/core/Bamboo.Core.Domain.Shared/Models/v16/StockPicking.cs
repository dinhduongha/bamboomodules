using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

[Table("stock_picking")]
//[Index("BatchId", Name = "stock_picking__batch_id_index")]
//[Index("CompanyId", Name = "stock_picking__company_id_index")]
//[Index("PickingTypeId", Name = "stock_picking__picking_type_id_index")]
//[Index("PosOrderId", Name = "stock_picking__pos_order_id_index")]
//[Index("PosSessionId", Name = "stock_picking__pos_session_id_index")]
//[Index("ScheduledDate", Name = "stock_picking__scheduled_date_index")]
//[Index("State", Name = "stock_picking__state_index")]
//[Index("Name", "CompanyId", Name = "stock_picking_name_uniq", IsUnique = true)]
public partial class StockPicking: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("backorder_id")]
    public Guid? BackorderId { get; set; }

    [Column("return_id")]
    public Guid? ReturnId { get; set; }

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

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("owner_id")]
    public Guid? OwnerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

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

    [JsonField] // PickingProperties
    [Column("picking_properties", TypeName = "jsonb")]
    public JsonElement? PickingProperties { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("has_deadline_issue")]
    public bool? HasDeadlineIssue { get; set; }

    [Column("printed")]
    public bool? Printed { get; set; }

    [Column("is_locked")]
    public bool? IsLocked { get; set; }

    [Column("scheduled_date", TypeName = "timestamp without time zone")]
    public DateTime? ScheduledDate { get; set; }

    [Column("date_deadline", TypeName = "timestamp without time zone")]
    public DateTime? DateDeadline { get; set; }

    [Column("date", TypeName = "timestamp without time zone")]
    public DateTime? Date { get; set; }

    [Column("date_done", TypeName = "timestamp without time zone")]
    public DateTime? DateDone { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("pos_session_id")]
    public Guid? PosSessionId { get; set; }

    [Column("pos_order_id")]
    public Guid? PosOrderId { get; set; }

    [Column("sale_id")]
    public Guid? SaleId { get; set; }

    [Column("project_id")]
    public Guid? ProjectId { get; set; }

    [Column("carrier_id")]
    public Guid? CarrierId { get; set; }

    [Column("carrier_tracking_ref")]
    public string? CarrierTrackingRef { get; set; }

    [Column("weight")]
    public decimal? Weight { get; set; }

    [Column("carrier_price")]
    public double? CarrierPrice { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("batch_id")]
    public Guid? BatchId { get; set; }

    [Column("batch_sequence")]
    public long? BatchSequence { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("BackorderId")]
    public virtual StockPicking? Backorder { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("BatchId")]
    public virtual StockPickingBatch? Batch { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CarrierId")]
    public virtual DeliveryCarrier? Carrier { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PickingId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Picking")] // One2many
    public virtual ICollection<ChooseDeliveryPackage> ChooseDeliveryPackage { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("GroupId")]
    public virtual ProcurementGroup? Group { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("BackorderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Backorder")] // One2many
    public virtual ICollection<StockPicking> InverseBackorder { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ReturnId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Return")] // One2many
    public virtual ICollection<StockPicking> InverseReturn { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LocationId")]
    public virtual StockLocation? Location { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LocationDestId")]
    public virtual StockLocation? LocationDest { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("OwnerId")]
    public virtual ResPartner? Owner { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PickingTypeId")]
    public virtual StockPickingType? PickingType { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PosOrderId")]
    public virtual PosOrder? PosOrder { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PosSessionId")]
    public virtual PosSession? PosSession { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProjectId")]
    public virtual ProjectProject? Project { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PickingId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Picking")] // One2many
    public virtual ICollection<RepairOrder> RepairOrder { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ReturnId")]
    public virtual StockPicking? Return { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SaleId")]
    public virtual SaleOrder? Sale { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PickingId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Picking")] // One2many
    public virtual ICollection<StockBackorderConfirmationLine> StockBackorderConfirmationLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PickingId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Picking")] // One2many
    public virtual ICollection<StockMove> StockMove { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PickingId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Picking")] // One2many
    public virtual ICollection<StockMoveLine> StockMoveLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PickingId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Picking")] // One2many
    public virtual ICollection<StockPackageDestination> StockPackageDestination { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PickingId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Picking")] // One2many
    public virtual ICollection<StockPackageLevel> StockPackageLevel { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PickingId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Picking")] // One2many
    public virtual ICollection<StockReturnPicking> StockReturnPicking { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PickingId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Picking")] // One2many
    public virtual ICollection<StockScrap> StockScrap { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("WebsiteId")]
    public virtual Website? Website { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockPickingId")] //Many2many // Hidden
    // [InverseProperty("StockPicking")] //Many2many // Hidden
    public virtual ICollection<ConfirmStockSms> ConfirmStockSms { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockPickingId")] //Many2many // Hidden
    // [InverseProperty("StockPicking")] //Many2many // Hidden
    public virtual ICollection<ExpiryPickingConfirmation> ExpiryPickingConfirmation { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockPickingId")] //Many2many // Hidden
    // [InverseProperty("StockPicking")] //Many2many // Hidden
    public virtual ICollection<PickingLabelType> PickingLabelType { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockPickingId")] //Many2many // Hidden
    // [InverseProperty("StockPicking")] //Many2many // Hidden
    public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockPickingId")] //Many2many // Hidden
    // [InverseProperty("StockPicking")] //Many2many // Hidden
    public virtual ICollection<StockAddToWave> StockAddToWave { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockPickingId")] //Many2many // Hidden
    // [InverseProperty("StockPicking")] //Many2many // Hidden
    public virtual ICollection<StockBackorderConfirmation> StockBackorderConfirmation { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockPickingId")] //Many2many // Hidden
    // [InverseProperty("StockPicking")] //Many2many // Hidden
    public virtual ICollection<StockLandedCost> StockLandedCost { get; set; }
}
