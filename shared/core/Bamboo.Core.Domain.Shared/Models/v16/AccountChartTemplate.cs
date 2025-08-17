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

[Table("account_chart_template")]
public partial class AccountChartTemplate: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("code_digits")]
    public long? CodeDigits { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("income_currency_exchange_account_id")]
    public Guid? IncomeCurrencyExchangeAccountId { get; set; }

    [Column("expense_currency_exchange_account_id")]
    public Guid? ExpenseCurrencyExchangeAccountId { get; set; }

    [Column("country_id")]
    public Guid? CountryId { get; set; }

    [Column("account_journal_suspense_account_id")]
    public Guid? AccountJournalSuspenseAccountId { get; set; }

    [Column("account_journal_payment_debit_account_id")]
    public Guid? AccountJournalPaymentDebitAccountId { get; set; }

    [Column("account_journal_payment_credit_account_id")]
    public Guid? AccountJournalPaymentCreditAccountId { get; set; }

    [Column("default_cash_difference_income_account_id")]
    public Guid? DefaultCashDifferenceIncomeAccountId { get; set; }

    [Column("default_cash_difference_expense_account_id")]
    public Guid? DefaultCashDifferenceExpenseAccountId { get; set; }

    [Column("default_pos_receivable_account_id")]
    public Guid? DefaultPosReceivableAccountId { get; set; }

    [Column("account_journal_early_pay_discount_loss_account_id")]
    public Guid? AccountJournalEarlyPayDiscountLossAccountId { get; set; }

    [Column("account_journal_early_pay_discount_gain_account_id")]
    public Guid? AccountJournalEarlyPayDiscountGainAccountId { get; set; }

    [Column("property_account_receivable_id")]
    public Guid? PropertyAccountReceivableId { get; set; }

    [Column("property_account_payable_id")]
    public Guid? PropertyAccountPayableId { get; set; }

    [Column("property_account_expense_categ_id")]
    public Guid? PropertyAccountExpenseCategId { get; set; }

    [Column("property_account_income_categ_id")]
    public Guid? PropertyAccountIncomeCategId { get; set; }

    [Column("property_account_expense_id")]
    public Guid? PropertyAccountExpenseId { get; set; }

    [Column("property_account_income_id")]
    public Guid? PropertyAccountIncomeId { get; set; }

    [Column("property_stock_account_input_categ_id")]
    public Guid? PropertyStockAccountInputCategId { get; set; }

    [Column("property_stock_account_output_categ_id")]
    public Guid? PropertyStockAccountOutputCategId { get; set; }

    [Column("property_stock_valuation_account_id")]
    public Guid? PropertyStockValuationAccountId { get; set; }

    [Column("property_tax_payable_account_id")]
    public Guid? PropertyTaxPayableAccountId { get; set; }

    [Column("property_tax_receivable_account_id")]
    public Guid? PropertyTaxReceivableAccountId { get; set; }

    [Column("property_advance_tax_payment_account_id")]
    public Guid? PropertyAdvanceTaxPaymentAccountId { get; set; }

    [Column("property_cash_basis_base_account_id")]
    public Guid? PropertyCashBasisBaseAccountId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("bank_account_code_prefix")]
    public string? BankAccountCodePrefix { get; set; }

    [Column("cash_account_code_prefix")]
    public string? CashAccountCodePrefix { get; set; }

    [Column("transfer_account_code_prefix")]
    public string? TransferAccountCodePrefix { get; set; }

    [Column("visible")]
    public bool? Visible { get; set; }

    [Column("use_anglo_saxon")]
    public bool? UseAngloSaxon { get; set; }

    [Column("use_storno_accounting")]
    public bool? UseStornoAccounting { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("spoken_languages")]
    public string? SpokenLanguages { get; set; }

    // [One2many]
    [ForeignKey("ChartTemplateId")]
    [InverseProperty("ChartTemplate")]
    public virtual ICollection<AccountAccountTemplate> AccountAccountTemplate { get; set; }

    // [One2many]
    [ForeignKey("ChartTemplateId")]
    [InverseProperty("ChartTemplate")]
    public virtual ICollection<AccountFiscalPositionTemplate> AccountFiscalPositionTemplate { get; set; }

    // [One2many]
    [ForeignKey("ChartTemplateId")]
    [InverseProperty("ChartTemplate")]
    public virtual ICollection<AccountGroupTemplate> AccountGroupTemplate { get; set; }

    // [Many2one]
    [ForeignKey("AccountJournalEarlyPayDiscountGainAccountId")]
    // [InverseProperty("AccountChartTemplateAccountJournalEarlyPayDiscountGainAccount")] //Many2one
    public virtual AccountAccountTemplate? AccountJournalEarlyPayDiscountGainAccount { get; set; }

    // [Many2one]
    [ForeignKey("AccountJournalEarlyPayDiscountLossAccountId")]
    // [InverseProperty("AccountChartTemplateAccountJournalEarlyPayDiscountLossAccount")] //Many2one
    public virtual AccountAccountTemplate? AccountJournalEarlyPayDiscountLossAccount { get; set; }

    // [Many2one]
    [ForeignKey("AccountJournalPaymentCreditAccountId")]
    // [InverseProperty("AccountChartTemplateAccountJournalPaymentCreditAccount")] //Many2one
    public virtual AccountAccountTemplate? AccountJournalPaymentCreditAccount { get; set; }

    // [Many2one]
    [ForeignKey("AccountJournalPaymentDebitAccountId")]
    // [InverseProperty("AccountChartTemplateAccountJournalPaymentDebitAccount")] //Many2one
    public virtual AccountAccountTemplate? AccountJournalPaymentDebitAccount { get; set; }

    // [Many2one]
    [ForeignKey("AccountJournalSuspenseAccountId")]
    // [InverseProperty("AccountChartTemplateAccountJournalSuspenseAccount")] //Many2one
    public virtual AccountAccountTemplate? AccountJournalSuspenseAccount { get; set; }

    // [One2many]
    [ForeignKey("ChartTemplateId")]
    [InverseProperty("ChartTemplate")]
    public virtual ICollection<AccountReconcileModelTemplate> AccountReconcileModelTemplate { get; set; }

    // [One2many]
    [ForeignKey("ChartTemplateId")]
    [InverseProperty("ChartTemplate")]
    public virtual ICollection<AccountReport> AccountReport { get; set; }

    // [One2many]
    [ForeignKey("ChartTemplateId")]
    [InverseProperty("ChartTemplate")]
    public virtual ICollection<AccountTaxTemplate> AccountTaxTemplate { get; set; }

    // [Many2one]
    [ForeignKey("CountryId")]
    // [InverseProperty("AccountChartTemplate")] //Many2one
    public virtual ResCountry? Country { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("AccountChartTemplateCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CurrencyId")]
    // [InverseProperty("AccountChartTemplate")] //Many2one
    public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    [ForeignKey("DefaultCashDifferenceExpenseAccountId")]
    // [InverseProperty("AccountChartTemplateDefaultCashDifferenceExpenseAccount")] //Many2one
    public virtual AccountAccountTemplate? DefaultCashDifferenceExpenseAccount { get; set; }

    // [Many2one]
    [ForeignKey("DefaultCashDifferenceIncomeAccountId")]
    // [InverseProperty("AccountChartTemplateDefaultCashDifferenceIncomeAccount")] //Many2one
    public virtual AccountAccountTemplate? DefaultCashDifferenceIncomeAccount { get; set; }

    // [Many2one]
    [ForeignKey("DefaultPosReceivableAccountId")]
    // [InverseProperty("AccountChartTemplateDefaultPosReceivableAccount")] //Many2one
    public virtual AccountAccountTemplate? DefaultPosReceivableAccount { get; set; }

    // [Many2one]
    [ForeignKey("ExpenseCurrencyExchangeAccountId")]
    // [InverseProperty("AccountChartTemplateExpenseCurrencyExchangeAccount")] //Many2one
    public virtual AccountAccountTemplate? ExpenseCurrencyExchangeAccount { get; set; }

    // [Many2one]
    [ForeignKey("IncomeCurrencyExchangeAccountId")]
    // [InverseProperty("AccountChartTemplateIncomeCurrencyExchangeAccount")] //Many2one
    public virtual AccountAccountTemplate? IncomeCurrencyExchangeAccount { get; set; }

    // [One2many]
    [ForeignKey("ParentId")]
    [InverseProperty("Parent")]
    public virtual ICollection<AccountChartTemplate> InverseParent { get; set; }

    // [Many2one]
    [ForeignKey("ParentId")]
    // [InverseProperty("InverseParent")] //Many2one
    public virtual AccountChartTemplate? Parent { get; set; }

    // [Many2one]
    [ForeignKey("PropertyAccountExpenseId")]
    // [InverseProperty("AccountChartTemplatePropertyAccountExpense")] //Many2one
    public virtual AccountAccountTemplate? PropertyAccountExpense { get; set; }

    // [Many2one]
    [ForeignKey("PropertyAccountExpenseCategId")]
    // [InverseProperty("AccountChartTemplatePropertyAccountExpenseCateg")] //Many2one
    public virtual AccountAccountTemplate? PropertyAccountExpenseCateg { get; set; }

    // [Many2one]
    [ForeignKey("PropertyAccountIncomeId")]
    // [InverseProperty("AccountChartTemplatePropertyAccountIncome")] //Many2one
    public virtual AccountAccountTemplate? PropertyAccountIncome { get; set; }

    // [Many2one]
    [ForeignKey("PropertyAccountIncomeCategId")]
    // [InverseProperty("AccountChartTemplatePropertyAccountIncomeCateg")] //Many2one
    public virtual AccountAccountTemplate? PropertyAccountIncomeCateg { get; set; }

    // [Many2one]
    [ForeignKey("PropertyAccountPayableId")]
    // [InverseProperty("AccountChartTemplatePropertyAccountPayable")] //Many2one
    public virtual AccountAccountTemplate? PropertyAccountPayable { get; set; }

    // [Many2one]
    [ForeignKey("PropertyAccountReceivableId")]
    // [InverseProperty("AccountChartTemplatePropertyAccountReceivable")] //Many2one
    public virtual AccountAccountTemplate? PropertyAccountReceivable { get; set; }

    // [Many2one]
    [ForeignKey("PropertyAdvanceTaxPaymentAccountId")]
    // [InverseProperty("AccountChartTemplatePropertyAdvanceTaxPaymentAccount")] //Many2one
    public virtual AccountAccountTemplate? PropertyAdvanceTaxPaymentAccount { get; set; }

    // [Many2one]
    [ForeignKey("PropertyCashBasisBaseAccountId")]
    // [InverseProperty("AccountChartTemplatePropertyCashBasisBaseAccount")] //Many2one
    public virtual AccountAccountTemplate? PropertyCashBasisBaseAccount { get; set; }

    // [Many2one]
    [ForeignKey("PropertyStockAccountInputCategId")]
    // [InverseProperty("AccountChartTemplatePropertyStockAccountInputCateg")] //Many2one
    public virtual AccountAccountTemplate? PropertyStockAccountInputCateg { get; set; }

    // [Many2one]
    [ForeignKey("PropertyStockAccountOutputCategId")]
    // [InverseProperty("AccountChartTemplatePropertyStockAccountOutputCateg")] //Many2one
    public virtual AccountAccountTemplate? PropertyStockAccountOutputCateg { get; set; }

    // [Many2one]
    [ForeignKey("PropertyStockValuationAccountId")]
    // [InverseProperty("AccountChartTemplatePropertyStockValuationAccount")] //Many2one
    public virtual AccountAccountTemplate? PropertyStockValuationAccount { get; set; }

    // [Many2one]
    [ForeignKey("PropertyTaxPayableAccountId")]
    // [InverseProperty("AccountChartTemplatePropertyTaxPayableAccount")] //Many2one
    public virtual AccountAccountTemplate? PropertyTaxPayableAccount { get; set; }

    // [Many2one]
    [ForeignKey("PropertyTaxReceivableAccountId")]
    // [InverseProperty("AccountChartTemplatePropertyTaxReceivableAccount")] //Many2one
    public virtual AccountAccountTemplate? PropertyTaxReceivableAccount { get; set; }

    // [One2many]
    [ForeignKey("ChartTemplateId")]
    [InverseProperty("ChartTemplate")]
    public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [One2many]
    [ForeignKey("ChartTemplateId")]
    [InverseProperty("ChartTemplate")]
    public virtual ICollection<ResConfigSettings> ResConfigSettings { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("AccountChartTemplateWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
