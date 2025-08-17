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
public partial class HrExpense: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_uom_id")]
    public Guid? ProductUomId { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("account_id")]
    public Guid? AccountId { get; set; }

    [Column("sheet_id")]
    public Guid? SheetId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

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

    [JsonField]
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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("sale_order_id")]
    public Guid? SaleOrderId { get; set; }

    // [Many2one]
    [ForeignKey("AccountId")]
    // [InverseProperty("HrExpense")] //Many2one
    public virtual AccountAccount? Account { get; set; }

    // [One2many]
    [ForeignKey("ExpenseId")]
    [InverseProperty("Expense")]
    public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("HrExpense")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("HrExpenseCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CurrencyId")]
    // [InverseProperty("HrExpense")] //Many2one
    public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    [ForeignKey("EmployeeId")]
    // [InverseProperty("HrExpense")] //Many2one
    public virtual HrEmployee? Employee { get; set; }

    // [One2many]
    [ForeignKey("ExpenseId")]
    [InverseProperty("Expense")]
    public virtual ICollection<HrExpenseSplit> HrExpenseSplit { get; set; }

    // [One2many]
    [ForeignKey("ExpenseId")]
    [InverseProperty("Expense")]
    public virtual ICollection<HrExpenseSplitWizard> HrExpenseSplitWizard { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("HrExpense")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("HrExpense")] //Many2one
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [ForeignKey("ProductUomId")]
    // [InverseProperty("HrExpense")] //Many2one
    public virtual UomUom? ProductUom { get; set; }

    // [Many2one]
    [ForeignKey("SaleOrderId")]
    // [InverseProperty("HrExpense")] //Many2one
    public virtual SaleOrder? SaleOrder { get; set; }

    // [One2many]
    [ForeignKey("ExpenseId")]
    [InverseProperty("Expense")]
    public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }

    // [Many2one]
    [ForeignKey("SheetId")]
    // [InverseProperty("HrExpense")] //Many2one
    public virtual HrExpenseSheet? Sheet { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("HrExpenseWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrExpenseId")]
    // [InverseProperty("HrExpense")]
    // public virtual ICollection<HrExpenseApproveDuplicate> HrExpenseApproveDuplicate { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrExpenseId")]
    // [InverseProperty("HrExpense")]
    // public virtual ICollection<HrExpenseRefuseWizard> HrExpenseRefuseWizard { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ExpenseId")] //Many2many
    // [InverseProperty("Expense")] //Many2many
    public virtual ICollection<AccountTax> Tax { get; set; }
}
