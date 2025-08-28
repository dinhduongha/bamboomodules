using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Table("account_account")]
//[Index("AccountType", Name = "account_account__account_type_index")]
public partial class AccountAccount: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("account_type")]
    public string? AccountType { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [JsonField]
    [Column("code_store", TypeName = "jsonb")]
    public string? CodeStore { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("deprecated")]
    public bool? Deprecated { get; set; }

    [Column("reconcile")]
    public bool? Reconcile { get; set; }

    [Column("non_trade")]
    public bool? NonTrade { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Account")] // One2many // Peer relationship (AccountAccruedOrdersWizard) is commented out
    // public virtual ICollection<AccountAccruedOrdersWizard> AccountAccruedOrdersWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("GeneralAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("GeneralAccount")] // One2many // Peer relationship (AccountAnalyticLine) is commented out
    // public virtual ICollection<AccountAnalyticLine> AccountAnalyticLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountAssetId")]
    // [NotMapped] // One2many 
    // [InverseProperty("AccountAsset")] // One2many // Peer relationship (AccountAssetCategory) is commented out
    // public virtual ICollection<AccountAssetCategory> AccountAssetCategoryAccountAsset { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountDepreciationId")]
    // [NotMapped] // One2many 
    // [InverseProperty("AccountDepreciation")] // One2many // Peer relationship (AccountAssetCategory) is commented out
    // public virtual ICollection<AccountAssetCategory> AccountAssetCategoryAccountDepreciation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountDepreciationExpenseId")]
    // [NotMapped] // One2many 
    // [InverseProperty("AccountDepreciationExpense")] // One2many // Peer relationship (AccountAssetCategory) is commented out
    // public virtual ICollection<AccountAssetCategory> AccountAssetCategoryAccountDepreciationExpense { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("DestinationAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("DestinationAccount")] // One2many // Peer relationship (AccountAutomaticEntryWizard) is commented out
    // public virtual ICollection<AccountAutomaticEntryWizard> AccountAutomaticEntryWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountDestId")]
    // [NotMapped] // One2many 
    // [InverseProperty("AccountDest")] // One2many // Peer relationship (AccountFiscalPositionAccount) is commented out
    // public virtual ICollection<AccountFiscalPositionAccount> AccountFiscalPositionAccountAccountDest { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountSrcId")]
    // [NotMapped] // One2many 
    // [InverseProperty("AccountSrc")] // One2many // Peer relationship (AccountFiscalPositionAccount) is commented out
    // public virtual ICollection<AccountFiscalPositionAccount> AccountFiscalPositionAccountAccountSrc { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("DefaultAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("DefaultAccount")] // One2many // Peer relationship (AccountJournal) is commented out
    // public virtual ICollection<AccountJournal> AccountJournalDefaultAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("LossAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("LossAccount")] // One2many // Peer relationship (AccountJournal) is commented out
    // public virtual ICollection<AccountJournal> AccountJournalLossAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("ProfitAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ProfitAccount")] // One2many // Peer relationship (AccountJournal) is commented out
    // public virtual ICollection<AccountJournal> AccountJournalProfitAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("SuspenseAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("SuspenseAccount")] // One2many // Peer relationship (AccountJournal) is commented out
    // public virtual ICollection<AccountJournal> AccountJournalSuspenseAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Account")] // One2many // Peer relationship (AccountMergeWizardLine) is commented out
    // public virtual ICollection<AccountMergeWizardLine> AccountMergeWizardLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Account")] // One2many // Peer relationship (AccountMoveLine) is commented out
    // public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("DestinationAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("DestinationAccount")] // One2many // Peer relationship (AccountPayment) is commented out
    // public virtual ICollection<AccountPayment> AccountPaymentDestinationAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("ForceOutstandingAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ForceOutstandingAccount")] // One2many // Peer relationship (AccountPayment) is commented out
    // public virtual ICollection<AccountPayment> AccountPaymentForceOutstandingAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("PaymentAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("PaymentAccount")] // One2many // Peer relationship (AccountPaymentMethodLine) is commented out
    // public virtual ICollection<AccountPaymentMethodLine> AccountPaymentMethodLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("OutstandingAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("OutstandingAccount")] // One2many // Peer relationship (AccountPayment) is commented out
    // public virtual ICollection<AccountPayment> AccountPaymentOutstandingAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("WriteoffAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteoffAccount")] // One2many // Peer relationship (AccountPaymentRegister) is commented out
    // public virtual ICollection<AccountPaymentRegister> AccountPaymentRegister { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Account")] // One2many // Peer relationship (AccountReconcileModelLine) is commented out
    // public virtual ICollection<AccountReconcileModelLine> AccountReconcileModelLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("CashBasisTransitionAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CashBasisTransitionAccount")] // One2many // Peer relationship (AccountTax) is commented out
    // public virtual ICollection<AccountTax> AccountTax { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AdvanceTaxPaymentAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("AdvanceTaxPaymentAccount")] // One2many // Peer relationship (AccountTaxGroup) is commented out
    // public virtual ICollection<AccountTaxGroup> AccountTaxGroupAdvanceTaxPaymentAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("TaxPayableAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("TaxPayableAccount")] // One2many // Peer relationship (AccountTaxGroup) is commented out
    // public virtual ICollection<AccountTaxGroup> AccountTaxGroupTaxPayableAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("TaxReceivableAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("TaxReceivableAccount")] // One2many // Peer relationship (AccountTaxGroup) is commented out
    // public virtual ICollection<AccountTaxGroup> AccountTaxGroupTaxReceivableAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Account")] // One2many // Peer relationship (AccountTaxRepartitionLine) is commented out
    // public virtual ICollection<AccountTaxRepartitionLine> AccountTaxRepartitionLine { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CurrencyId")]
    public virtual ResCurrency? Currency { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Account")] // One2many // Peer relationship (HrExpense) is commented out
    // public virtual ICollection<HrExpense> HrExpense { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountCredit")]
    // [NotMapped] // One2many 
    // [InverseProperty("AccountCreditNavigation")] // One2many // Peer relationship (HrPayslipLine) is commented out
    // public virtual ICollection<HrPayslipLine> HrPayslipLineAccountCreditNavigation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountDebit")]
    // [NotMapped] // One2many 
    // [InverseProperty("AccountDebitNavigation")] // One2many // Peer relationship (HrPayslipLine) is commented out
    // public virtual ICollection<HrPayslipLine> HrPayslipLineAccountDebitNavigation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountCredit")]
    // [NotMapped] // One2many 
    // [InverseProperty("AccountCreditNavigation")] // One2many // Peer relationship (HrSalaryRule) is commented out
    // public virtual ICollection<HrSalaryRule> HrSalaryRuleAccountCreditNavigation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountDebit")]
    // [NotMapped] // One2many 
    // [InverseProperty("AccountDebitNavigation")] // One2many // Peer relationship (HrSalaryRule) is commented out
    // public virtual ICollection<HrSalaryRule> HrSalaryRuleAccountDebitNavigation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Account")] // One2many // Peer relationship (MrpAccountWipAccountingLine) is commented out
    // public virtual ICollection<MrpAccountWipAccountingLine> MrpAccountWipAccountingLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("ExpenseAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ExpenseAccount")] // One2many // Peer relationship (MrpWorkcenter) is commented out
    // public virtual ICollection<MrpWorkcenter> MrpWorkcenter { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Account")] // One2many // Peer relationship (PosCloseSessionWizard) is commented out
    // public virtual ICollection<PosCloseSessionWizard> PosCloseSessionWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("OutstandingAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("OutstandingAccount")] // One2many // Peer relationship (PosPaymentMethod) is commented out
    // public virtual ICollection<PosPaymentMethod> PosPaymentMethodOutstandingAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("ReceivableAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ReceivableAccount")] // One2many // Peer relationship (PosPaymentMethod) is commented out
    // public virtual ICollection<PosPaymentMethod> PosPaymentMethodReceivableAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountCashBasisBaseAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("AccountCashBasisBaseAccount")] // One2many
    // public virtual ICollection<ResCompany> ResCompanyAccountCashBasisBaseAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountDefaultPosReceivableAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("AccountDefaultPosReceivableAccount")] // One2many
    // public virtual ICollection<ResCompany> ResCompanyAccountDefaultPosReceivableAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountDiscountExpenseAllocationId")]
    // [NotMapped] // One2many 
    // [InverseProperty("AccountDiscountExpenseAllocation")] // One2many
    // public virtual ICollection<ResCompany> ResCompanyAccountDiscountExpenseAllocation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountDiscountIncomeAllocationId")]
    // [NotMapped] // One2many 
    // [InverseProperty("AccountDiscountIncomeAllocation")] // One2many
    // public virtual ICollection<ResCompany> ResCompanyAccountDiscountIncomeAllocation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountJournalEarlyPayDiscountGainAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("AccountJournalEarlyPayDiscountGainAccount")] // One2many
    // public virtual ICollection<ResCompany> ResCompanyAccountJournalEarlyPayDiscountGainAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountJournalEarlyPayDiscountLossAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("AccountJournalEarlyPayDiscountLossAccount")] // One2many
    // public virtual ICollection<ResCompany> ResCompanyAccountJournalEarlyPayDiscountLossAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountJournalSuspenseAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("AccountJournalSuspenseAccount")] // One2many
    // public virtual ICollection<ResCompany> ResCompanyAccountJournalSuspenseAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountProductionWipAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("AccountProductionWipAccount")] // One2many
    // public virtual ICollection<ResCompany> ResCompanyAccountProductionWipAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountProductionWipOverheadAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("AccountProductionWipOverheadAccount")] // One2many
    // public virtual ICollection<ResCompany> ResCompanyAccountProductionWipOverheadAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("DefaultCashDifferenceExpenseAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("DefaultCashDifferenceExpenseAccount")] // One2many
    // public virtual ICollection<ResCompany> ResCompanyDefaultCashDifferenceExpenseAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("DefaultCashDifferenceIncomeAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("DefaultCashDifferenceIncomeAccount")] // One2many
    // public virtual ICollection<ResCompany> ResCompanyDefaultCashDifferenceIncomeAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("ExpenseAccrualAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ExpenseAccrualAccount")] // One2many
    // public virtual ICollection<ResCompany> ResCompanyExpenseAccrualAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("ExpenseCurrencyExchangeAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ExpenseCurrencyExchangeAccount")] // One2many
    // public virtual ICollection<ResCompany> ResCompanyExpenseCurrencyExchangeAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("ExpenseOutstandingAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ExpenseOutstandingAccount")] // One2many
    // public virtual ICollection<ResCompany> ResCompanyExpenseOutstandingAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("IncomeCurrencyExchangeAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("IncomeCurrencyExchangeAccount")] // One2many
    // public virtual ICollection<ResCompany> ResCompanyIncomeCurrencyExchangeAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("RevenueAccrualAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("RevenueAccrualAccount")] // One2many
    // public virtual ICollection<ResCompany> ResCompanyRevenueAccrualAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("TransferAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("TransferAccount")] // One2many
    // public virtual ICollection<ResCompany> ResCompanyTransferAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Account")] // One2many // Peer relationship (StockLandedCostLines) is commented out
    // public virtual ICollection<StockLandedCostLines> StockLandedCostLines { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("ValuationInAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ValuationInAccount")] // One2many // Peer relationship (StockLocation) is commented out
    // public virtual ICollection<StockLocation> StockLocationValuationInAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("ValuationOutAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ValuationOutAccount")] // One2many // Peer relationship (StockLocation) is commented out
    // public virtual ICollection<StockLocation> StockLocationValuationOutAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Account")] // One2many // Peer relationship (StockValuationLayerRevaluation) is commented out
    // public virtual ICollection<StockValuationLayerRevaluation> StockValuationLayerRevaluation { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("AccountAccountId")] // Many2many // Normal
    // [InverseProperty("AccountAccount")] // Many2many // Normal
    public virtual ICollection<AccountAccountTag> AccountAccountTag { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountAccountId")] //Many2many // Hidden
    // [InverseProperty("AccountAccount")] //Many2many // Hidden
    public virtual ICollection<AccountBalanceReport> AccountBalanceReport { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountAccountId")] //Many2many // Hidden
    // [InverseProperty("AccountAccount")] //Many2many // Hidden
    public virtual ICollection<AccountCommonAccountReport> AccountCommonAccountReport { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("AccountAccountId")] // Many2many // Normal
    // [InverseProperty("AccountAccount")] // Many2many // Normal
    public virtual ICollection<AccountJournal> AccountJournal { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountAccountId")] //Many2many // Hidden
    // [InverseProperty("AccountAccount")] //Many2many // Hidden
    public virtual ICollection<AccountMergeWizard> AccountMergeWizard { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountAccountId")] //Many2many // Hidden
    // [InverseProperty("AccountAccount")] //Many2many // Hidden
    public virtual ICollection<AccountReportGeneralLedger> AccountReportGeneralLedger { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountId")] //Many2many // Hidden
    // [InverseProperty("Account")] //Many2many // Hidden
    public virtual ICollection<AccountBudgetPost> Budget { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountId")] //Many2many // Hidden
    // [InverseProperty("Account1")] //Many2many // Hidden
    public virtual ICollection<AccountJournal> Journal { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountId")] //Many2many // Hidden
    // [InverseProperty("Account")] //Many2many // Hidden
    public virtual ICollection<AccountBankbookReport> ReportLine { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountId")] //Many2many // Hidden
    // [InverseProperty("Account")] //Many2many // Hidden
    public virtual ICollection<AccountDaybookReport> ReportLine1 { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountId")] //Many2many // Hidden
    // [InverseProperty("Account")] //Many2many // Hidden
    public virtual ICollection<AccountFinancialReport> ReportLine2 { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountId")] //Many2many // Hidden
    // [InverseProperty("Account")] //Many2many // Hidden
    public virtual ICollection<AccountCashbookReport> ReportLineNavigation { get; set; }


    // [Many2many] // Normal
    [NotMapped] // Many2many // Peer relationship (ResCompany) is commented out
    // [ForeignKey("AccountAccountId")] // Many2many // Normal
    // [InverseProperty("AccountAccount")] // Many2many // Normal
    
    public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("AccountId")] // Many2many // Normal
    // [InverseProperty("Account")] // Many2many // Normal
    public virtual ICollection<AccountTax> Tax { get; set; }
}
