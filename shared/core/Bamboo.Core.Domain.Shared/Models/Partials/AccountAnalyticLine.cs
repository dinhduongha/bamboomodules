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

//[Table("account_analytic_line")]
//[Index("AccountId", Name = "account_analytic_line_account_id_index")]
//[Index("Date", Name = "account_analytic_line_date_index")]
//[Index("MoveLineId", Name = "account_analytic_line_move_line_id_index")]
//[Index("OrderId", Name = "account_analytic_line_order_id_index")]
//[Index("ProjectId", Name = "account_analytic_line_project_id_index")]
//[Index("UserId", Name = "account_analytic_line_user_id_index")]
public partial class AccountAnalyticLine
{

    [Column("plan_id")]
    public Guid? PlanId { get; set; }

    [Column("ancestor_task_id")]
    public Guid? AncestorTaskId { get; set; }

    // [Many2one]
    [ForeignKey("AncestorTaskId")]
    public virtual ProjectTask? AncestorTask { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MoAnalyticAccountLineId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("MoAnalyticAccountLine")] // One2many
    public virtual ICollection<MrpWorkorder> MrpWorkorderMoAnalyticAccountLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("WcAnalyticAccountLineId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("WcAnalyticAccountLine")] // One2many
    public virtual ICollection<MrpWorkorder> MrpWorkorderWcAnalyticAccountLine { get; set; }

    // [Many2one]
    [ForeignKey("PlanId")]
    public virtual AccountAnalyticPlan? Plan { get; set; }

    // v16-Compat
    // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AnalyticAccountLineId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AnalyticAccountLine")] // One2many
    // public virtual ICollection<StockMove> StockMove { get; set; }

}
