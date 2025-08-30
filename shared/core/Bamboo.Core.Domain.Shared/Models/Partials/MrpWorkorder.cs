using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("mrp_workorder")]
//[Index("State", Name = "mrp_workorder__state_index")]
public partial class MrpWorkorder
{
    [Column("date_planned_start", TypeName = "timestamp without time zone")]
    public DateTime? DatePlannedStart { get; set; }

    [Column("date_planned_finished", TypeName = "timestamp without time zone")]
    public DateTime? DatePlannedFinished { get; set; }

    [Column("mo_analytic_account_line_id")]
    public Guid? MoAnalyticAccountLineId { get; set; }

    [Column("wc_analytic_account_line_id")]
    public Guid? WcAnalyticAccountLineId { get; set; }

    // [Many2one]
    [ForeignKey("MoAnalyticAccountLineId")]
    public virtual AccountAnalyticLine? MoAnalyticAccountLine { get; set; }

    // [Many2one]
    [ForeignKey("WcAnalyticAccountLineId")]
    public virtual AccountAnalyticLine? WcAnalyticAccountLine { get; set; }
}
