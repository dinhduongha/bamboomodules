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

[Table("mrp_workorder")]
//[Index("ProductionId", Name = "mrp_workorder__production_id_index")]
//[Index("State", Name = "mrp_workorder__state_index")]
public partial class MrpWorkorder : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("workcenter_id")]
    public Guid? WorkcenterId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_uom_id")]
    public Guid? ProductUomId { get; set; }

    [Column("production_id")]
    public Guid? ProductionId { get; set; }

    [Column("leave_id")]
    public Guid? LeaveId { get; set; }

    [Column("duration_percent")]
    public long? DurationPercent { get; set; }

    [Column("operation_id")]
    public Guid? OperationId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("barcode")]
    public string? Barcode { get; set; }

    [Column("production_availability")]
    public string? ProductionAvailability { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("qty_produced")]
    public decimal? QtyProduced { get; set; }

    [Column("duration_expected")]
    public decimal? DurationExpected { get; set; }

    [Column("qty_reported_from_previous_wo")]
    public decimal? QtyReportedFromPreviousWo { get; set; }

    [Column("date_start", TypeName = "timestamp without time zone")]
    public DateTime? DateStart { get; set; }

    [Column("date_finished", TypeName = "timestamp without time zone")]
    public DateTime? DateFinished { get; set; }

    [Column("production_date", TypeName = "timestamp without time zone")]
    public DateTime? ProductionDate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("duration")]
    public double? Duration { get; set; }

    [Column("duration_unit")]
    public double? DurationUnit { get; set; }

    [Column("costs_hour")]
    public double? CostsHour { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("WorkorderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Workorder")] // One2many
    public virtual ICollection<ExpiryPickingConfirmation> ExpiryPickingConfirmation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LeaveId")]
    public virtual ResourceCalendarLeaves? Leave { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("WorkorderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Workorder")] // One2many
    public virtual ICollection<MrpWorkcenterProductivity> MrpWorkcenterProductivity { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("OperationId")]
    public virtual MrpRoutingWorkcenter? Operation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductId")]
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductUomId")]
    public virtual UomUom? ProductUom { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductionId")]
    public virtual MrpProduction? Production { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("WorkorderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Workorder")] // One2many
    public virtual ICollection<StockMove> StockMove { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("WorkorderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Workorder")] // One2many
    public virtual ICollection<StockMoveLine> StockMoveLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("WorkorderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Workorder")] // One2many
    public virtual ICollection<StockScrap> StockScrap { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("WorkcenterId")]
    public virtual MrpWorkcenter? Workcenter { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("MrpWorkorderId")] // Many2many // Normal
    // [InverseProperty("MrpWorkorder")] // Many2many // Normal
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLine { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("MrpWorkorderId")] // Many2many // Normal
    // [InverseProperty("MrpWorkorderNavigation")] // Many2many // Normal
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLineNavigation { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("WorkorderId")] // Many2many // Normal
    // [InverseProperty("Workorder")] // Many2many // Normal
    public virtual ICollection<MrpWorkorder> BlockedBy { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("BlockedById")] // Many2many // Normal
    // [InverseProperty("BlockedBy")] // Many2many // Normal
    public virtual ICollection<MrpWorkorder> Workorder { get; set; }
}
