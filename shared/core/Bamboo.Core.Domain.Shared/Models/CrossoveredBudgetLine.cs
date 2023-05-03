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

[Table("crossovered_budget_lines")]
//[Index("CrossoveredBudgetId", Name = "crossovered_budget_lines_crossovered_budget_id_index")]
public partial class CrossoveredBudgetLine: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("crossovered_budget_id")]
    public Guid? CrossoveredBudgetId { get; set; }

    [Column("analytic_account_id")]
    public Guid? AnalyticAccountId { get; set; }

    [Column("general_budget_id")]
    public Guid? GeneralBudgetId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("crossovered_budget_state")]
    public string? CrossoveredBudgetState { get; set; }

    [Column("date_from")]
    public DateTime? DateFrom { get; set; }

    [Column("date_to")]
    public DateTime? DateTo { get; set; }

    [Column("paid_date")]
    public DateTime? PaidDate { get; set; }

    [Column("planned_amount")]
    public decimal? PlannedAmount { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("AnalyticAccountId")]
    //[InverseProperty("CrossoveredBudgetLines")]
    [NotMapped]
    public virtual AccountAnalyticAccount? AnalyticAccount { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("CrossoveredBudgetLines")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("CrossoveredBudgetLineCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CrossoveredBudgetId")]
    //[InverseProperty("CrossoveredBudgetLines")]
    [NotMapped]
    public virtual CrossoveredBudget? CrossoveredBudget { get; set; }

    [ForeignKey("GeneralBudgetId")]
    //[InverseProperty("CrossoveredBudgetLines")]
    [NotMapped]
    public virtual AccountBudgetPost? GeneralBudget { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("CrossoveredBudgetLineWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
