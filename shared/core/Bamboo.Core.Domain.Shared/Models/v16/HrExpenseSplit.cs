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

[Table("hr_expense_split")]
public partial class HrExpenseSplit: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("wizard_id")]
    public Guid? WizardId { get; set; }

    [Column("expense_id")]
    public Guid? ExpenseId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [JsonField]
    [Column("analytic_distribution", TypeName = "jsonb")]
    public string? AnalyticDistribution { get; set; }

    [Column("total_amount")]
    public decimal? TotalAmount { get; set; }

    [Column("product_has_cost")]
    public bool? ProductHasCost { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("sale_order_id")]
    public Guid? SaleOrderId { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("HrExpenseSplit")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("HrExpenseSplitCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CurrencyId")]
    // [InverseProperty("HrExpenseSplit")] //Many2one
    public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    [ForeignKey("EmployeeId")]
    // [InverseProperty("HrExpenseSplit")] //Many2one
    public virtual HrEmployee? Employee { get; set; }

    // [Many2one]
    [ForeignKey("ExpenseId")]
    // [InverseProperty("HrExpenseSplit")] //Many2one
    public virtual HrExpense? Expense { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("HrExpenseSplit")] //Many2one
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [ForeignKey("SaleOrderId")]
    // [InverseProperty("HrExpenseSplit")] //Many2one
    public virtual SaleOrder? SaleOrder { get; set; }

    // [Many2one]
    [ForeignKey("WizardId")]
    // [InverseProperty("HrExpenseSplit")] //Many2one
    public virtual HrExpenseSplitWizard? Wizard { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("HrExpenseSplitWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("HrExpenseSplitId")] //Many2many
    // [InverseProperty("HrExpenseSplit")] //Many2many
    public virtual ICollection<AccountTax> AccountTax { get; set; }
}
