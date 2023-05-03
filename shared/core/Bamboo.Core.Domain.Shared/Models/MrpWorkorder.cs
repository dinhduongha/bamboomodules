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

[Table("mrp_workorder")]
public partial class MrpWorkorder: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

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
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

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

    [Column("date_planned_start", TypeName = "timestamp without time zone")]
    public DateTime? DatePlannedStart { get; set; }

    [Column("date_planned_finished", TypeName = "timestamp without time zone")]
    public DateTime? DatePlannedFinished { get; set; }

    [Column("date_start", TypeName = "timestamp without time zone")]
    public DateTime? DateStart { get; set; }

    [Column("date_finished", TypeName = "timestamp without time zone")]
    public DateTime? DateFinished { get; set; }

    [Column("production_date", TypeName = "timestamp without time zone")]
    public DateTime? ProductionDate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("duration")]
    public double? Duration { get; set; }

    [Column("duration_unit")]
    public double? DurationUnit { get; set; }

    [Column("costs_hour")]
    public double? CostsHour { get; set; }

    [Column("mo_analytic_account_line_id")]
    public Guid? MoAnalyticAccountLineId { get; set; }

    [Column("wc_analytic_account_line_id")]
    public Guid? WcAnalyticAccountLineId { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MrpWorkorderCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LeaveId")]
    //[InverseProperty("MrpWorkorders")]
    [NotMapped]
    public virtual ResourceCalendarLeaf? Leave { get; set; }

    [ForeignKey("MoAnalyticAccountLineId")]
    //[InverseProperty("MrpWorkorderMoAnalyticAccountLines")]
    [NotMapped]
    public virtual AccountAnalyticLine? MoAnalyticAccountLine { get; set; }

    [ForeignKey("OperationId")]
    //[InverseProperty("MrpWorkorders")]
    [NotMapped]
    public virtual MrpRoutingWorkcenter? Operation { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("MrpWorkorders")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("ProductUomId")]
    //[InverseProperty("MrpWorkorders")]
    [NotMapped]
    public virtual UomUom? ProductUom { get; set; }

    [ForeignKey("ProductionId")]
    //[InverseProperty("MrpWorkorders")]
    [NotMapped]
    public virtual MrpProduction? Production { get; set; }

    [ForeignKey("WcAnalyticAccountLineId")]
    //[InverseProperty("MrpWorkorderWcAnalyticAccountLines")]
    [NotMapped]
    public virtual AccountAnalyticLine? WcAnalyticAccountLine { get; set; }

    [ForeignKey("WorkcenterId")]
    //[InverseProperty("MrpWorkorders")]
    [NotMapped]
    public virtual MrpWorkcenter? Workcenter { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MrpWorkorderWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Workorder")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterProductivity> MrpWorkcenterProductivities { get; } = new List<MrpWorkcenterProductivity>();

    //[InverseProperty("Workorder")]
    [NotMapped]
    public virtual ICollection<StockMoveLine> StockMoveLines { get; } = new List<StockMoveLine>();

    //[InverseProperty("Workorder")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoves { get; } = new List<StockMove>();

    //[InverseProperty("Workorder")]
    [NotMapped]
    public virtual ICollection<StockScrap> StockScraps { get; } = new List<StockScrap>();

    [ForeignKey("WorkorderId")]
    //[InverseProperty("Workorders")]
    [NotMapped]
    public virtual ICollection<MrpWorkorder> BlockedBies { get; } = new List<MrpWorkorder>();

    [ForeignKey("BlockedById")]
    //[InverseProperty("BlockedBies")]
    [NotMapped]
    public virtual ICollection<MrpWorkorder> Workorders { get; } = new List<MrpWorkorder>();
}
