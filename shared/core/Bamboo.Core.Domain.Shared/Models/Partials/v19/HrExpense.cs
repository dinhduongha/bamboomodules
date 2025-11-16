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

public partial class HrExpense
{
    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

    [Column("manager_id")]
    public Guid? ManagerId { get; set; }

    [Column("split_expense_origin_id")]
    public Guid? SplitExpenseOriginId { get; set; }

    [Column("payment_method_line_id")]
    public Guid? PaymentMethodLineId { get; set; }

    [Column("account_move_id")]
    public Guid? AccountMoveId { get; set; }

    [Column("former_sheet_id")]
    public Guid? FormerSheetId { get; set; }

    [Column("approval_state")]
    public string? ApprovalState { get; set; }

    // [Column("total_amount")]
    // public decimal? TotalAmount { get; set; }

    // [Column("untaxed_amount")]
    // public decimal? UntaxedAmount { get; set; }

    [Column("approval_date", TypeName = "timestamp without time zone")]
    public DateTime? ApprovalDate { get; set; }

    [Column("sale_order_line_id")]
    public Guid? SaleOrderLineId { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountMoveId")]
    public virtual AccountMove? AccountMove { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("DepartmentId")]
    public virtual HrDepartment? Department { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SplitExpenseOriginId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SplitExpenseOrigin")] // One2many
    public virtual ICollection<HrExpense> InverseSplitExpenseOrigin { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ManagerId")]
    public virtual ResUsers? Manager { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PaymentMethodLineId")]
    public virtual AccountPaymentMethodLine? PaymentMethodLine { get; set; }

    [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SaleOrderLineId")]
    public virtual SaleOrderLine? SaleOrderLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ExpenseId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Expense")] // One2many
    public virtual ICollection<SaleOrderLine> SaleOrderLineNavigation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SplitExpenseOriginId")]
    public virtual HrExpense? SplitExpenseOrigin { get; set; }


    // [Many2many] // Hidden
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] //Many2many // Hidden
    // // [ForeignKey("HrExpenseId")] //Many2many // Hidden
    // // [InverseProperty("HrExpense")] //Many2many // Hidden
    // public virtual ICollection<HrExpenseRefuseWizard> HrExpenseRefuseWizard { get; set; }

}