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

[Table("hr_expense_sheet")]
//[Index("State", Name = "hr_expense_sheet__state_index")]
public partial class HrExpenseSheet: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("address_id")]
    public Guid? AddressId { get; set; }

    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("employee_journal_id")]
    public Guid? EmployeeJournalId { get; set; }

    [Column("payment_method_line_id")]
    public Guid? PaymentMethodLineId { get; set; }

    [Column("journal_id")]
    public Guid? JournalId { get; set; }

    [Column("bank_journal_id")]
    public Guid? BankJournalId { get; set; }

    [Column("account_move_id")]
    public Guid? AccountMoveId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("approval_state")]
    public string? ApprovalState { get; set; }

    [Column("payment_state")]
    public string? PaymentState { get; set; }

    [Column("accounting_date")]
    public DateTime? AccountingDate { get; set; }

    [Column("total_amount")]
    public decimal? TotalAmount { get; set; }

    [Column("untaxed_amount")]
    public decimal? UntaxedAmount { get; set; }

    [Column("total_tax_amount")]
    public decimal? TotalTaxAmount { get; set; }

    [Column("total_amount_taxes")]
    public decimal? TotalAmountTaxes { get; set; }

    [Column("amount_residual")]
    public decimal? AmountResidual { get; set; }

    [Column("approval_date", TypeName = "timestamp without time zone")]
    public DateTime? ApprovalDate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many]
    [ForeignKey("ExpenseSheetId")]
    [InverseProperty("ExpenseSheet")]
    public virtual ICollection<AccountMove> AccountMove { get; set; }

    // v16-Compat
    // [Many2one]
    //[ForeignKey("AccountMoveId")]
    // [InverseProperty("HrExpenseSheet")] //Many2one
    //public virtual AccountMove? AccountMove { get; set; }

    // [Many2one]
    [ForeignKey("AddressId")]
    // [InverseProperty("HrExpenseSheet")] //Many2one
    public virtual ResPartner? Address { get; set; }

    // [Many2one]
    [ForeignKey("BankJournalId")]
    // [InverseProperty("HrExpenseSheetBankJournal")] //Many2one
    public virtual AccountJournal? BankJournal { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("HrExpenseSheet")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("HrExpenseSheetCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CurrencyId")]
    // [InverseProperty("HrExpenseSheet")] //Many2one
    public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    [ForeignKey("DepartmentId")]
    // [InverseProperty("HrExpenseSheet")] //Many2one
    public virtual HrDepartment? Department { get; set; }

    // [Many2one]
    [ForeignKey("EmployeeId")]
    // [InverseProperty("HrExpenseSheet")] //Many2one
    public virtual HrEmployee? Employee { get; set; }

    // [Many2one]
    [ForeignKey("EmployeeJournalId")]
    // [InverseProperty("HrExpenseSheetEmployeeJournal")] //Many2one
    public virtual AccountJournal? EmployeeJournal { get; set; }

    // [One2many]
    [ForeignKey("SheetId")]
    [InverseProperty("Sheet")]
    public virtual ICollection<HrExpense> HrExpense { get; set; }

    // v16-Compat
    // [One2many]
    //[ForeignKey("HrExpenseSheetId")]
    //[InverseProperty("HrExpenseSheet")]
    //public virtual ICollection<HrExpenseRefuseWizard> HrExpenseRefuseWizard { get; set; }

    // [Many2one]
    [ForeignKey("JournalId")]
    // [InverseProperty("HrExpenseSheetJournal")] //Many2one
    public virtual AccountJournal? Journal { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("HrExpenseSheet")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("PaymentMethodLineId")]
    // [InverseProperty("HrExpenseSheet")] //Many2one
    public virtual AccountPaymentMethodLine? PaymentMethodLine { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("HrExpenseSheetUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("HrExpenseSheetWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrExpenseSheetId")]
    // [InverseProperty("HrExpenseSheet")]
    public virtual ICollection<HrExpenseApproveDuplicate> HrExpenseApproveDuplicate { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrExpenseSheetId")]
    // [InverseProperty("HrExpenseSheet")]
    public virtual ICollection<HrExpenseRefuseWizard> HrExpenseRefuseWizards { get; set; }
}
