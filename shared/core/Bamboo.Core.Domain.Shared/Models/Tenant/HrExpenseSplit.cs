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
public partial class HrExpenseSplit: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("wizard_id")]
    public Guid? WizardId { get; set; }

    [Column("expense_id")]
    public Guid? ExpenseId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("currency_id")]
    public long? CurrencyId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("analytic_distribution", TypeName = "jsonb")]
    public string? AnalyticDistribution { get; set; }

    [Column("total_amount")]
    public decimal? TotalAmount { get; set; }

    [Column("product_has_cost")]
    public bool? ProductHasCost { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("sale_order_id")]
    public Guid? SaleOrderId { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("HrExpenseSplits")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrExpenseSplitCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CurrencyId")]
    //[InverseProperty("HrExpenseSplits")]
    [NotMapped]
    public virtual ResCurrency? Currency { get; set; }

    [ForeignKey("EmployeeId")]
    //[InverseProperty("HrExpenseSplits")]
    [NotMapped]
    public virtual HrEmployee? Employee { get; set; }

    [ForeignKey("ExpenseId")]
    //[InverseProperty("HrExpenseSplits")]
    [NotMapped]
    public virtual HrExpense? Expense { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("HrExpenseSplits")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("SaleOrderId")]
    //[InverseProperty("HrExpenseSplits")]
    [NotMapped]
    public virtual SaleOrder? SaleOrder { get; set; }

    [ForeignKey("WizardId")]
    //[InverseProperty("HrExpenseSplits")]
    [NotMapped]
    public virtual HrExpenseSplitWizard? Wizard { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrExpenseSplitWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("HrExpenseSplitId")]
    //[InverseProperty("HrExpenseSplits")]
    [NotMapped]
    public virtual ICollection<AccountTax> AccountTaxes { get; } = new List<AccountTax>();
}
