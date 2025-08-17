using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

//[Keyless]
public partial class ReportProjectTaskUser: Entity<Guid>, IMultiTenant
{
    [Column("nbr")]
    public int? Nbr { get; set; }

    [Column("id")]
    public Guid? Id { get; set; }

    [Column("task_id")]
    public Guid? TaskId { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreateDate { get; set; }

    [Column("date_assign", TypeName = "timestamp without time zone")]
    public DateTime? DateAssign { get; set; }

    [Column("date_end", TypeName = "timestamp without time zone")]
    public DateTime? DateEnd { get; set; }

    [Column("date_last_stage_update", TypeName = "timestamp without time zone")]
    public DateTime? DateLastStageUpdate { get; set; }

    [Column("date_deadline")]
    public DateTime? DateDeadline { get; set; }

    [Column("project_id")]
    public Guid? ProjectId { get; set; }

    [Column("priority", TypeName = "character varying")]
    public string? Priority { get; set; }

    [Column("name", TypeName = "character varying")]
    public string? Name { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("ancestor_id")]
    public Guid? AncestorId { get; set; }

    [Column("stage_id")]
    public Guid? StageId { get; set; }

    [Column("is_closed")]
    public bool? IsClosed { get; set; }

    [Column("state", TypeName = "character varying")]
    public string? State { get; set; }

    [Column("milestone_id")]
    public Guid? MilestoneId { get; set; }

    [Column("milestone_reached")]
    public bool? MilestoneReached { get; set; }

    [Column("milestone_deadline")]
    public DateTime? MilestoneDeadline { get; set; }

    [Column("rating_last_value")]
    public double? RatingLastValue { get; set; }

    [Column("rating_avg")]
    public double? RatingAvg { get; set; }

    [Column("working_days_close")]
    public double? WorkingDaysClose { get; set; }

    [Column("working_days_open")]
    public double? WorkingDaysOpen { get; set; }

    [Column("working_hours_open")]
    public decimal? WorkingHoursOpen { get; set; }

    [Column("working_hours_close")]
    public decimal? WorkingHoursClose { get; set; }

    [Column("delay_endings_days")]
    public decimal? DelayEndingsDays { get; set; }

    [Column("sale_line_id")]
    public Guid? SaleLineId { get; set; }

    [Column("sale_order_id")]
    public Guid? SaleOrderId { get; set; }
}
