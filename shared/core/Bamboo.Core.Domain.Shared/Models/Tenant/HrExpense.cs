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

[Table("hr_expense")]
//[Index("State", Name = "hr_expense_state_index")]
public partial class HrExpense: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_uom_id")]
    public Guid? ProductUomId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("currency_id")]
    public long? CurrencyId { get; set; }

    [Column("account_id")]
    public Guid? AccountId { get; set; }

    [Column("sheet_id")]
    public Guid? SheetId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("payment_mode")]
    public string? PaymentMode { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("reference")]
    public string? Reference { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("accounting_date")]
    public DateTime? AccountingDate { get; set; }

    [Column("analytic_distribution", TypeName = "jsonb")]
    public string? AnalyticDistribution { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("unit_amount")]
    public decimal? UnitAmount { get; set; }

    [Column("quantity")]
    public decimal? Quantity { get; set; }

    [Column("amount_tax")]
    public decimal? AmountTax { get; set; }

    [Column("amount_tax_company")]
    public decimal? AmountTaxCompany { get; set; }

    [Column("total_amount")]
    public decimal? TotalAmount { get; set; }

    [Column("untaxed_amount")]
    public decimal? UntaxedAmount { get; set; }

    [Column("total_amount_company")]
    public decimal? TotalAmountCompany { get; set; }

    [Column("is_refused")]
    public bool? IsRefused { get; set; }

    [Column("sample")]
    public bool? Sample { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("sale_order_id")]
    public Guid? SaleOrderId { get; set; }

    [ForeignKey("AccountId")]
    //[InverseProperty("HrExpenses")]
    [NotMapped]
    public virtual AccountAccount? Account { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("HrExpenses")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrExpenseCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CurrencyId")]
    //[InverseProperty("HrExpenses")]
    [NotMapped]
    public virtual ResCurrency? Currency { get; set; }

    [ForeignKey("EmployeeId")]
    //[InverseProperty("HrExpenses")]
    [NotMapped]
    public virtual HrEmployee? Employee { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("HrExpenses")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("HrExpenses")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("ProductUomId")]
    //[InverseProperty("HrExpenses")]
    [NotMapped]
    public virtual UomUom? ProductUom { get; set; }

    [ForeignKey("SaleOrderId")]
    //[InverseProperty("HrExpenses")]
    [NotMapped]
    public virtual SaleOrder? SaleOrder { get; set; }

    [ForeignKey("SheetId")]
    //[InverseProperty("HrExpenses")]
    [NotMapped]
    public virtual HrExpenseSheet? Sheet { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrExpenseWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Expense")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLines { get; } = new List<AccountMoveLine>();

    //[InverseProperty("Expense")]
    [NotMapped]
    public virtual ICollection<HrExpenseSplitWizard> HrExpenseSplitWizards { get; } = new List<HrExpenseSplitWizard>();

    //[InverseProperty("Expense")]
    [NotMapped]
    public virtual ICollection<HrExpenseSplit> HrExpenseSplits { get; } = new List<HrExpenseSplit>();

    [ForeignKey("HrExpenseId")]
    //[InverseProperty("HrExpenses")]
    [NotMapped]
    public virtual ICollection<HrExpenseApproveDuplicate> HrExpenseApproveDuplicates { get; } = new List<HrExpenseApproveDuplicate>();

    [ForeignKey("HrExpenseId")]
    //[InverseProperty("HrExpenses")]
    [NotMapped]
    public virtual ICollection<HrExpenseRefuseWizard> HrExpenseRefuseWizards { get; } = new List<HrExpenseRefuseWizard>();

    [ForeignKey("ExpenseId")]
    //[InverseProperty("Expenses")]
    [NotMapped]
    public virtual ICollection<AccountTax> Taxes { get; } = new List<AccountTax>();
}
