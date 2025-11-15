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

[Table("account_chart_template")]
public partial class AccountChartTemplate : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

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

    [JsonField(IsSparse = false)] // Name
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

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
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ChartTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ChartTemplate")] // One2many
    public virtual ICollection<AccountAccountTemplate> AccountAccountTemplate { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ChartTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ChartTemplate")] // One2many
    public virtual ICollection<AccountFiscalPositionTemplate> AccountFiscalPositionTemplate { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ChartTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ChartTemplate")] // One2many
    public virtual ICollection<AccountGroupTemplate> AccountGroupTemplate { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountJournalEarlyPayDiscountGainAccountId")]
    public virtual AccountAccountTemplate? AccountJournalEarlyPayDiscountGainAccount { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountJournalEarlyPayDiscountLossAccountId")]
    public virtual AccountAccountTemplate? AccountJournalEarlyPayDiscountLossAccount { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountJournalPaymentCreditAccountId")]
    public virtual AccountAccountTemplate? AccountJournalPaymentCreditAccount { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountJournalPaymentDebitAccountId")]
    public virtual AccountAccountTemplate? AccountJournalPaymentDebitAccount { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountJournalSuspenseAccountId")]
    public virtual AccountAccountTemplate? AccountJournalSuspenseAccount { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ChartTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ChartTemplate")] // One2many
    public virtual ICollection<AccountReconcileModelTemplate> AccountReconcileModelTemplate { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ChartTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ChartTemplate")] // One2many
    public virtual ICollection<AccountReport> AccountReport { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ChartTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ChartTemplate")] // One2many
    public virtual ICollection<AccountTaxTemplate> AccountTaxTemplate { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CountryId")]
    public virtual ResCountry? Country { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CurrencyId")]
    public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("DefaultCashDifferenceExpenseAccountId")]
    public virtual AccountAccountTemplate? DefaultCashDifferenceExpenseAccount { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("DefaultCashDifferenceIncomeAccountId")]
    public virtual AccountAccountTemplate? DefaultCashDifferenceIncomeAccount { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("DefaultPosReceivableAccountId")]
    public virtual AccountAccountTemplate? DefaultPosReceivableAccount { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ExpenseCurrencyExchangeAccountId")]
    public virtual AccountAccountTemplate? ExpenseCurrencyExchangeAccount { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("IncomeCurrencyExchangeAccountId")]
    public virtual AccountAccountTemplate? IncomeCurrencyExchangeAccount { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ParentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Parent")] // One2many
    public virtual ICollection<AccountChartTemplate> InverseParent { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ParentId")]
    public virtual AccountChartTemplate? Parent { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PropertyAccountExpenseId")]
    public virtual AccountAccountTemplate? PropertyAccountExpense { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PropertyAccountExpenseCategId")]
    public virtual AccountAccountTemplate? PropertyAccountExpenseCateg { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PropertyAccountIncomeId")]
    public virtual AccountAccountTemplate? PropertyAccountIncome { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PropertyAccountIncomeCategId")]
    public virtual AccountAccountTemplate? PropertyAccountIncomeCateg { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PropertyAccountPayableId")]
    public virtual AccountAccountTemplate? PropertyAccountPayable { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PropertyAccountReceivableId")]
    public virtual AccountAccountTemplate? PropertyAccountReceivable { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PropertyAdvanceTaxPaymentAccountId")]
    public virtual AccountAccountTemplate? PropertyAdvanceTaxPaymentAccount { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PropertyCashBasisBaseAccountId")]
    public virtual AccountAccountTemplate? PropertyCashBasisBaseAccount { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PropertyStockAccountInputCategId")]
    public virtual AccountAccountTemplate? PropertyStockAccountInputCateg { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PropertyStockAccountOutputCategId")]
    public virtual AccountAccountTemplate? PropertyStockAccountOutputCateg { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PropertyStockValuationAccountId")]
    public virtual AccountAccountTemplate? PropertyStockValuationAccount { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PropertyTaxPayableAccountId")]
    public virtual AccountAccountTemplate? PropertyTaxPayableAccount { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PropertyTaxReceivableAccountId")]
    public virtual AccountAccountTemplate? PropertyTaxReceivableAccount { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ChartTemplateId")]
    [NotMapped] // One2many // Peer relationship (ResCompany) is commented out
    // [InverseProperty("ChartTemplate")] // One2many
    public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ChartTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ChartTemplate")] // One2many
    public virtual ICollection<ResConfigSettings> ResConfigSettings { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
