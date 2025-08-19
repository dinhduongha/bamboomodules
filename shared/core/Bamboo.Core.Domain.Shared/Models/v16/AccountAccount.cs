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

[Table("account_account")]
//[Index("AccountType", Name = "account_account__account_type_index")]
//[Index("Code", "CompanyId", Name = "account_account_code_company_uniq", IsUnique = true)]
public partial class AccountAccount: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("group_id")]
    public Guid? GroupId { get; set; }

    [Column("root_id")]
    public Guid? RootId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("account_type")]
    public string? AccountType { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [JsonField]
    [Column("code_store", TypeName = "jsonb")]
    public string? CodeStore { get; set; }

    [Column("internal_group")]
    public string? InternalGroup { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("deprecated")]
    public bool? Deprecated { get; set; }

    [Column("include_initial_balance")]
    public bool? IncludeInitialBalance { get; set; }

    [Column("reconcile")]
    public bool? Reconcile { get; set; }

    [Column("is_off_balance")]
    public bool? IsOffBalance { get; set; }

    [Column("non_trade")]
    public bool? NonTrade { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountId")]
    // [InverseProperty("Account")]
    // public virtual ICollection<AccountAccruedOrdersWizard> AccountAccruedOrdersWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("GeneralAccountId")]
    // [InverseProperty("GeneralAccount")]
    // public virtual ICollection<AccountAnalyticLine> AccountAnalyticLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountAssetId")]
    // [InverseProperty("AccountAsset")]
    // public virtual ICollection<AccountAssetCategory> AccountAssetCategoryAccountAsset { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountDepreciationId")]
    // [InverseProperty("AccountDepreciation")]
    // public virtual ICollection<AccountAssetCategory> AccountAssetCategoryAccountDepreciation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountDepreciationExpenseId")]
    // [InverseProperty("AccountDepreciationExpense")]
    // public virtual ICollection<AccountAssetCategory> AccountAssetCategoryAccountDepreciationExpense { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("DestinationAccountId")]
    // [InverseProperty("DestinationAccount")]
    // public virtual ICollection<AccountAutomaticEntryWizard> AccountAutomaticEntryWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountDestId")]
    // [InverseProperty("AccountDest")]
    // public virtual ICollection<AccountFiscalPositionAccount> AccountFiscalPositionAccountAccountDest { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountSrcId")]
    // [InverseProperty("AccountSrc")]
    // public virtual ICollection<AccountFiscalPositionAccount> AccountFiscalPositionAccountAccountSrc { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("DefaultAccountId")]
    // [InverseProperty("DefaultAccount")]
    // public virtual ICollection<AccountJournal> AccountJournalDefaultAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("LossAccountId")]
    // [InverseProperty("LossAccount")]
    // public virtual ICollection<AccountJournal> AccountJournalLossAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("ProfitAccountId")]
    // [InverseProperty("ProfitAccount")]
    // public virtual ICollection<AccountJournal> AccountJournalProfitAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("SuspenseAccountId")]
    // [InverseProperty("SuspenseAccount")]
    // public virtual ICollection<AccountJournal> AccountJournalSuspenseAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountId")]
    // [InverseProperty("Account")]
    // public virtual ICollection<AccountMergeWizardLine> AccountMergeWizardLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountId")]
    // [InverseProperty("Account")]
    // public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("DestinationAccountId")]
    // [InverseProperty("DestinationAccount")]
    // public virtual ICollection<AccountPayment> AccountPaymentDestinationAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("ForceOutstandingAccountId")]
    // [InverseProperty("ForceOutstandingAccount")]
    // public virtual ICollection<AccountPayment> AccountPaymentForceOutstandingAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("PaymentAccountId")]
    // [InverseProperty("PaymentAccount")]
    // public virtual ICollection<AccountPaymentMethodLine> AccountPaymentMethodLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("OutstandingAccountId")]
    // [InverseProperty("OutstandingAccount")]
    // public virtual ICollection<AccountPayment> AccountPaymentOutstandingAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("WriteoffAccountId")]
    // [InverseProperty("WriteoffAccount")]
    // public virtual ICollection<AccountPaymentRegister> AccountPaymentRegister { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountId")]
    // [InverseProperty("Account")]
    // public virtual ICollection<AccountReconcileModelLine> AccountReconcileModelLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("CashBasisTransitionAccountId")]
    // [InverseProperty("CashBasisTransitionAccount")]
    // public virtual ICollection<AccountTax> AccountTax { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AdvanceTaxPaymentAccountId")]
    // [InverseProperty("AdvanceTaxPaymentAccount")]
    // public virtual ICollection<AccountTaxGroup> AccountTaxGroupAdvanceTaxPaymentAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("TaxPayableAccountId")]
    // [InverseProperty("TaxPayableAccount")]
    // public virtual ICollection<AccountTaxGroup> AccountTaxGroupTaxPayableAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("TaxReceivableAccountId")]
    // [InverseProperty("TaxReceivableAccount")]
    // public virtual ICollection<AccountTaxGroup> AccountTaxGroupTaxReceivableAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountId")]
    // [InverseProperty("Account")]
    // public virtual ICollection<AccountTaxRepartitionLine> AccountTaxRepartitionLine { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("AccountAccount")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("AccountAccountCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CurrencyId")]
    // [InverseProperty("AccountAccount")] //Many2one
    public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    [ForeignKey("GroupId")]
    // [InverseProperty("AccountAccount")] //Many2one
    public virtual AccountGroup? Group { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountId")]
    // [InverseProperty("Account")]
    // public virtual ICollection<HrExpense> HrExpense { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountCredit")]
    // [InverseProperty("AccountCreditNavigation")]
    // public virtual ICollection<HrPayslipLine> HrPayslipLineAccountCreditNavigation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountDebit")]
    // [InverseProperty("AccountDebitNavigation")]
    // public virtual ICollection<HrPayslipLine> HrPayslipLineAccountDebitNavigation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountCredit")]
    // [InverseProperty("AccountCreditNavigation")]
    // public virtual ICollection<HrSalaryRule> HrSalaryRuleAccountCreditNavigation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountDebit")]
    // [InverseProperty("AccountDebitNavigation")]
    // public virtual ICollection<HrSalaryRule> HrSalaryRuleAccountDebitNavigation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountId")]
    // [InverseProperty("Account")]
    // public virtual ICollection<MrpAccountWipAccountingLine> MrpAccountWipAccountingLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("ExpenseAccountId")]
    // [InverseProperty("ExpenseAccount")]
    // public virtual ICollection<MrpWorkcenter> MrpWorkcenter { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("AccountAccount")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountId")]
    // [InverseProperty("Account")]
    // public virtual ICollection<PosCloseSessionWizard> PosCloseSessionWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("OutstandingAccountId")]
    // [InverseProperty("OutstandingAccount")]
    // public virtual ICollection<PosPaymentMethod> PosPaymentMethodOutstandingAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("ReceivableAccountId")]
    // [InverseProperty("ReceivableAccount")]
    // public virtual ICollection<PosPaymentMethod> PosPaymentMethodReceivableAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountCashBasisBaseAccountId")]
    // [InverseProperty("AccountCashBasisBaseAccount")]
    // public virtual ICollection<ResCompany> ResCompanyAccountCashBasisBaseAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountDefaultPosReceivableAccountId")]
    // [InverseProperty("AccountDefaultPosReceivableAccount")]
    // public virtual ICollection<ResCompany> ResCompanyAccountDefaultPosReceivableAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountDiscountExpenseAllocationId")]
    // [InverseProperty("AccountDiscountExpenseAllocation")]
    // public virtual ICollection<ResCompany> ResCompanyAccountDiscountExpenseAllocation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountDiscountIncomeAllocationId")]
    // [InverseProperty("AccountDiscountIncomeAllocation")]
    // public virtual ICollection<ResCompany> ResCompanyAccountDiscountIncomeAllocation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountJournalEarlyPayDiscountGainAccountId")]
    // [InverseProperty("AccountJournalEarlyPayDiscountGainAccount")]
    // public virtual ICollection<ResCompany> ResCompanyAccountJournalEarlyPayDiscountGainAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountJournalEarlyPayDiscountLossAccountId")]
    // [InverseProperty("AccountJournalEarlyPayDiscountLossAccount")]
    // public virtual ICollection<ResCompany> ResCompanyAccountJournalEarlyPayDiscountLossAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountJournalSuspenseAccountId")]
    // [InverseProperty("AccountJournalSuspenseAccount")]
    // public virtual ICollection<ResCompany> ResCompanyAccountJournalSuspenseAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountProductionWipAccountId")]
    // [InverseProperty("AccountProductionWipAccount")]
    // public virtual ICollection<ResCompany> ResCompanyAccountProductionWipAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountProductionWipOverheadAccountId")]
    // [InverseProperty("AccountProductionWipOverheadAccount")]
    // public virtual ICollection<ResCompany> ResCompanyAccountProductionWipOverheadAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountJournalPaymentCreditAccountId")]
    // [InverseProperty("AccountJournalPaymentCreditAccount")]
    // public virtual ICollection<ResCompany> ResCompanyAccountJournalPaymentCreditAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountJournalPaymentDebitAccountId")]
    // [InverseProperty("AccountJournalPaymentDebitAccount")]
    // public virtual ICollection<ResCompany> ResCompanyAccountJournalPaymentDebitAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountJournalSuspenseAccountId")]
    // [InverseProperty("AccountJournalSuspenseAccount")]
    // public virtual ICollection<ResCompany> ResCompanyAccountJournalSuspenseAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("DefaultCashDifferenceExpenseAccountId")]
    // [InverseProperty("DefaultCashDifferenceExpenseAccount")]
    // public virtual ICollection<ResCompany> ResCompanyDefaultCashDifferenceExpenseAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("DefaultCashDifferenceIncomeAccountId")]
    // [InverseProperty("DefaultCashDifferenceIncomeAccount")]
    // public virtual ICollection<ResCompany> ResCompanyDefaultCashDifferenceIncomeAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("ExpenseAccrualAccountId")]
    // [InverseProperty("ExpenseAccrualAccount")]
    // public virtual ICollection<ResCompany> ResCompanyExpenseAccrualAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("ExpenseCurrencyExchangeAccountId")]
    // [InverseProperty("ExpenseCurrencyExchangeAccount")]
    // public virtual ICollection<ResCompany> ResCompanyExpenseCurrencyExchangeAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("ExpenseOutstandingAccountId")]
    // [InverseProperty("ExpenseOutstandingAccount")]
    // public virtual ICollection<ResCompany> ResCompanyExpenseOutstandingAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("IncomeCurrencyExchangeAccountId")]
    // [InverseProperty("IncomeCurrencyExchangeAccount")]
    // public virtual ICollection<ResCompany> ResCompanyIncomeCurrencyExchangeAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("PropertyStockAccountInputCategId")]
    // [InverseProperty("PropertyStockAccountInputCateg")]
    // public virtual ICollection<ResCompany> ResCompanyPropertyStockAccountInputCateg { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("PropertyStockAccountOutputCategId")]
    // [InverseProperty("PropertyStockAccountOutputCateg")]
    // public virtual ICollection<ResCompany> ResCompanyPropertyStockAccountOutputCateg { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("PropertyStockValuationAccountId")]
    // [InverseProperty("PropertyStockValuationAccount")]
    // public virtual ICollection<ResCompany> ResCompanyPropertyStockValuationAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("RevenueAccrualAccountId")]
    // [InverseProperty("RevenueAccrualAccount")]
    // public virtual ICollection<ResCompany> ResCompanyRevenueAccrualAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("TransferAccountId")]
    // [InverseProperty("TransferAccount")]
    // public virtual ICollection<ResCompany> ResCompanyTransferAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("DepositAccountId")]
    // [InverseProperty("DepositAccount")]
    // public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInv { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountId")]
    // [InverseProperty("Account")]
    // public virtual ICollection<StockLandedCostLines> StockLandedCostLines { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("ValuationInAccountId")]
    // [InverseProperty("ValuationInAccount")]
    // public virtual ICollection<StockLocation> StockLocationValuationInAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("ValuationOutAccountId")]
    // [InverseProperty("ValuationOutAccount")]
    // public virtual ICollection<StockLocation> StockLocationValuationOutAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [ForeignKey("AccountId")]
    // [InverseProperty("Account")]
    // public virtual ICollection<StockValuationLayerRevaluation> StockValuationLayerRevaluation { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("AccountAccountWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("AccountAccountId")] //Many2many
    // [InverseProperty("AccountAccount")] //Many2many
    public virtual ICollection<AccountAccountTag> AccountAccountTag { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountAccountId")]
    // [InverseProperty("AccountAccount")]
    public virtual ICollection<AccountBalanceReport> AccountBalanceReport { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountAccountId")]
    // [InverseProperty("AccountAccount")]
    public virtual ICollection<AccountCommonAccountReport> AccountCommonAccountReport { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("AccountAccountId")] //Many2many
    // [InverseProperty("AccountAccount")] //Many2many
    public virtual ICollection<AccountJournal> AccountJournal { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountAccountId")]
    // [InverseProperty("AccountAccount")]
    public virtual ICollection<AccountMergeWizard> AccountMergeWizard { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountAccountId")]
    // [InverseProperty("AccountAccount")]
    public virtual ICollection<AccountReportGeneralLedger> AccountReportGeneralLedger { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountId")]
    // [InverseProperty("Account")]
    public virtual ICollection<AccountBudgetPost> Budget { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountId")]
    // [InverseProperty("Account1")]
    public virtual ICollection<AccountJournal> Journal { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountId")]
    // [InverseProperty("Account")]
    public virtual ICollection<AccountBankbookReport> ReportLine { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountId")]
    // [InverseProperty("Account")]
    public virtual ICollection<AccountDaybookReport> ReportLine1 { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountId")]
    // [InverseProperty("Account")]
    public virtual ICollection<AccountFinancialReport> ReportLine2 { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountId")]
    // [InverseProperty("Account")]
    public virtual ICollection<AccountCashbookReport> ReportLineNavigation { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("AccountAccountId")] //Many2many
    // [InverseProperty("AccountAccount")] //Many2many
    public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("AccountId")] //Many2many
    // [InverseProperty("Account")] //Many2many
    public virtual ICollection<AccountTax> Tax { get; set; }
}
