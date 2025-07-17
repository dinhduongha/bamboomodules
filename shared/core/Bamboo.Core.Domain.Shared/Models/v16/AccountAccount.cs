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
//[Index("Code", "TenantId", Name = "account_account_code_company_uniq", IsUnique = true)]
public partial class AccountAccount: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    // v16-Compat
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    // v16-Compat
    [Column("group_id")]
    public Guid? GroupId { get; set; }

    // v16-Compat
    [Column("root_id")]
    public Guid? RootId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("account_type")]
    public string? AccountType { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    // v16-Compat
    [Column("code")]
    public string? Code { get; set; }

    [Column("code_store", TypeName = "jsonb")]
    public string? CodeStore { get; set; }

    // v16-Compat
    [Column("internal_group")]
    public string? InternalGroup { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("deprecated")]
    public bool? Deprecated { get; set; }

    // v16-Compat
    [Column("include_initial_balance")]
    public bool? IncludeInitialBalance { get; set; }

    [Column("reconcile")]
    public bool? Reconcile { get; set; }

    // v16-Compat
    [Column("is_off_balance")]
    public bool? IsOffBalance { get; set; }

    [Column("non_trade")]
    public bool? NonTrade { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    // v16-Compat
    [ForeignKey("TenantId")]
    //[InverseProperty("AccountAccounts")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    // v16-Compat
    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountAccountCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    // v16-Compat
    [ForeignKey("CurrencyId")]
    //[InverseProperty("AccountAccounts")]
    [NotMapped]
    public virtual ResCurrency? Currency { get; set; }

    // v16-Compat
    [ForeignKey("GroupId")]
    //[InverseProperty("AccountAccounts")]
    [NotMapped]
    public virtual AccountGroup? Group { get; set; }

    // v16-Compat
    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("AccountAccounts")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // v16-Compat
    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountAccountWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    // v16-Compat
    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<HrExpense> HrExpenses { get; set; } = new List<HrExpense>();

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<AccountAccruedOrdersWizard> AccountAccruedOrdersWizards { get; set; } = new List<AccountAccruedOrdersWizard>();

    //[InverseProperty("GeneralAccount")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLines { get; set; } = new List<AccountAnalyticLine>();

    //[InverseProperty("AccountAsset")]
    [NotMapped]
    public virtual ICollection<AccountAssetCategory> AccountAssetCategoryAccountAssets { get; set; } = new List<AccountAssetCategory>();

    //[InverseProperty("AccountDepreciationExpense")]
    [NotMapped]
    public virtual ICollection<AccountAssetCategory> AccountAssetCategoryAccountDepreciationExpenses { get; set; } = new List<AccountAssetCategory>();

    //[InverseProperty("AccountDepreciation")]
    [NotMapped]
    public virtual ICollection<AccountAssetCategory> AccountAssetCategoryAccountDepreciations { get; set; } = new List<AccountAssetCategory>();

    //[InverseProperty("DestinationAccount")]
    [NotMapped]
    public virtual ICollection<AccountAutomaticEntryWizard> AccountAutomaticEntryWizards { get; set; } = new List<AccountAutomaticEntryWizard>();

    //[InverseProperty("AccountDest")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionAccount> AccountFiscalPositionAccountAccountDests { get; set; } = new List<AccountFiscalPositionAccount>();

    //[InverseProperty("AccountSrc")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionAccount> AccountFiscalPositionAccountAccountSrcs { get; set; } = new List<AccountFiscalPositionAccount>();

    //[InverseProperty("DefaultAccount")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournalDefaultAccounts { get; set; } = new List<AccountJournal>();

    //[InverseProperty("LossAccount")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournalLossAccounts { get; set; } = new List<AccountJournal>();

    //[InverseProperty("ProfitAccount")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournalProfitAccounts { get; set; } = new List<AccountJournal>();

    //[InverseProperty("SuspenseAccount")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournalSuspenseAccounts { get; set; } = new List<AccountJournal>();

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<AccountMergeWizardLine> AccountMergeWizardLines { get; set; } = new List<AccountMergeWizardLine>();

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLines { get; set; } = new List<AccountMoveLine>();

    //[InverseProperty("DestinationAccount")]
    [NotMapped]
    public virtual ICollection<AccountPayment> AccountPaymentDestinationAccounts { get; set; } = new List<AccountPayment>();

    //[InverseProperty("ForceOutstandingAccount")]
    [NotMapped]
    public virtual ICollection<AccountPayment> AccountPaymentForceOutstandingAccounts { get; set; } = new List<AccountPayment>();

    //[InverseProperty("PaymentAccount")]
    [NotMapped]
    public virtual ICollection<AccountPaymentMethodLine> AccountPaymentMethodLines { get; set; } = new List<AccountPaymentMethodLine>();

    //[InverseProperty("OutstandingAccount")]
    [NotMapped]
    public virtual ICollection<AccountPayment> AccountPaymentOutstandingAccounts { get; set; } = new List<AccountPayment>();

    //[InverseProperty("WriteoffAccount")]
    [NotMapped]
    public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisters { get; set; } = new List<AccountPaymentRegister>();

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelLine> AccountReconcileModelLines { get; set; } = new List<AccountReconcileModelLine>();

    //[InverseProperty("AdvanceTaxPaymentAccount")]
    [NotMapped]
    public virtual ICollection<AccountTaxGroup> AccountTaxGroupAdvanceTaxPaymentAccounts { get; set; } = new List<AccountTaxGroup>();

    //[InverseProperty("TaxPayableAccount")]
    [NotMapped]
    public virtual ICollection<AccountTaxGroup> AccountTaxGroupTaxPayableAccounts { get; set; } = new List<AccountTaxGroup>();

    //[InverseProperty("TaxReceivableAccount")]
    [NotMapped]
    public virtual ICollection<AccountTaxGroup> AccountTaxGroupTaxReceivableAccounts { get; set; } = new List<AccountTaxGroup>();

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<AccountTaxRepartitionLine> AccountTaxRepartitionLines { get; set; } = new List<AccountTaxRepartitionLine>();

    //[InverseProperty("CashBasisTransitionAccount")]
    [NotMapped]
    public virtual ICollection<AccountTax> AccountTaxes { get; set; } = new List<AccountTax>();

    // [ForeignKey("CreatorId")]
    // //[InverseProperty("AccountAccountCreateUs")]
    // [NotMapped]
    // public virtual ResUser? CreateU { get; set; }

    // [ForeignKey("CurrencyId")]
    // //[InverseProperty("AccountAccounts")]
    // [NotMapped]
    // public virtual ResCurrency? Currency { get; set; }

    // //[InverseProperty("Account")]
    // [NotMapped]
    // public virtual ICollection<HrExpense> HrExpenses { get; set; } = new List<HrExpense>();

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<MrpAccountWipAccountingLine> MrpAccountWipAccountingLines { get; set; } = new List<MrpAccountWipAccountingLine>();

    //[InverseProperty("ExpenseAccount")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenter> MrpWorkcenters { get; set; } = new List<MrpWorkcenter>();

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<PosCloseSessionWizard> PosCloseSessionWizards { get; set; } = new List<PosCloseSessionWizard>();

    //[InverseProperty("OutstandingAccount")]
    [NotMapped]
    public virtual ICollection<PosPaymentMethod> PosPaymentMethodOutstandingAccounts { get; set; } = new List<PosPaymentMethod>();

    //[InverseProperty("ReceivableAccount")]
    [NotMapped]
    public virtual ICollection<PosPaymentMethod> PosPaymentMethodReceivableAccounts { get; set; } = new List<PosPaymentMethod>();

    //[InverseProperty("AccountCashBasisBaseAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountCashBasisBaseAccounts { get; set; } = new List<ResCompany>();

    //[InverseProperty("AccountDefaultPosReceivableAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountDefaultPosReceivableAccounts { get; set; } = new List<ResCompany>();

    //[InverseProperty("AccountDiscountExpenseAllocation")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountDiscountExpenseAllocations { get; set; } = new List<ResCompany>();

    //[InverseProperty("AccountDiscountIncomeAllocation")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountDiscountIncomeAllocations { get; set; } = new List<ResCompany>();

    //[InverseProperty("AccountJournalEarlyPayDiscountGainAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountJournalEarlyPayDiscountGainAccounts { get; set; } = new List<ResCompany>();

    //[InverseProperty("AccountJournalEarlyPayDiscountLossAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountJournalEarlyPayDiscountLossAccounts { get; set; } = new List<ResCompany>();

    //[InverseProperty("AccountJournalSuspenseAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountJournalSuspenseAccounts { get; set; } = new List<ResCompany>();

    //[InverseProperty("AccountProductionWipAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountProductionWipAccounts { get; set; } = new List<ResCompany>();

    //[InverseProperty("AccountProductionWipOverheadAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountProductionWipOverheadAccounts { get; set; } = new List<ResCompany>();

    // v16-Compat
    //[InverseProperty("AccountJournalPaymentCreditAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountJournalPaymentCreditAccounts { get; set; } = new List<ResCompany>();

    // v16-Compat
    //[InverseProperty("AccountJournalPaymentDebitAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountJournalPaymentDebitAccounts { get; set; } = new List<ResCompany>();


    //[InverseProperty("DefaultCashDifferenceExpenseAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyDefaultCashDifferenceExpenseAccounts { get; set; } = new List<ResCompany>();

    //[InverseProperty("DefaultCashDifferenceIncomeAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyDefaultCashDifferenceIncomeAccounts { get; set; } = new List<ResCompany>();

    //[InverseProperty("ExpenseAccrualAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyExpenseAccrualAccounts { get; set; } = new List<ResCompany>();

    //[InverseProperty("ExpenseCurrencyExchangeAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyExpenseCurrencyExchangeAccounts { get; set; } = new List<ResCompany>();

    //[InverseProperty("ExpenseOutstandingAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyExpenseOutstandingAccounts { get; set; } = new List<ResCompany>();

    //[InverseProperty("IncomeCurrencyExchangeAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyIncomeCurrencyExchangeAccounts { get; set; } = new List<ResCompany>();

    // v16-Compat
    //[InverseProperty("PropertyStockAccountInputCateg")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyPropertyStockAccountInputCategs { get; set; } = new List<ResCompany>();

    // v16-Compat
    //[InverseProperty("PropertyStockAccountOutputCateg")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyPropertyStockAccountOutputCategs { get; set; } = new List<ResCompany>();

    // v16-Compat
    //[InverseProperty("PropertyStockValuationAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyPropertyStockValuationAccounts { get; set; } = new List<ResCompany>();

    //[InverseProperty("RevenueAccrualAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyRevenueAccrualAccounts { get; set; } = new List<ResCompany>();

    //[InverseProperty("TransferAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyTransferAccounts { get; set; } = new List<ResCompany>();

    // v16-Compat
    //[InverseProperty("DepositAccount")]
    [NotMapped]
    public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInvs { get; set; } = new List<SaleAdvancePaymentInv>();

    //[InverseProperty("ValuationInAccount")]
    [NotMapped]
    public virtual ICollection<StockLocation> StockLocationValuationInAccounts { get; set; } = new List<StockLocation>();

    //[InverseProperty("ValuationOutAccount")]
    [NotMapped]
    public virtual ICollection<StockLocation> StockLocationValuationOutAccounts { get; set; } = new List<StockLocation>();

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<StockValuationLayerRevaluation> StockValuationLayerRevaluations { get; set; } = new List<StockValuationLayerRevaluation>();


    [ForeignKey("AccountAccountId")]
    //[InverseProperty("AccountAccounts")]
    [NotMapped]
    public virtual ICollection<AccountAccountTag> AccountAccountTags { get; set; } = new List<AccountAccountTag>();

    [ForeignKey("AccountAccountId")]
    //[InverseProperty("AccountAccounts")]
    [NotMapped]
    public virtual ICollection<AccountBalanceReport> AccountBalanceReports { get; set; } = new List<AccountBalanceReport>();

    [ForeignKey("AccountAccountId")]
    //[InverseProperty("AccountAccounts")]
    [NotMapped]
    public virtual ICollection<AccountCommonAccountReport> AccountCommonAccountReports { get; set; } = new List<AccountCommonAccountReport>();

    [ForeignKey("AccountAccountId")]
    //[InverseProperty("AccountAccounts")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournals { get; set; } = new List<AccountJournal>();

    [ForeignKey("AccountAccountId")]
    //[InverseProperty("AccountAccounts")]
    [NotMapped]
    public virtual ICollection<AccountMergeWizard> AccountMergeWizards { get; set; } = new List<AccountMergeWizard>();

    [ForeignKey("AccountAccountId")]
    //[InverseProperty("AccountAccounts")]
    [NotMapped]
    public virtual ICollection<AccountReportGeneralLedger> AccountReportGeneralLedgers { get; set; } = new List<AccountReportGeneralLedger>();

    [ForeignKey("AccountId")]
    //[InverseProperty("Accounts")]
    [NotMapped]
    public virtual ICollection<AccountBudgetPost> Budgets { get; set; } = new List<AccountBudgetPost>();

    [ForeignKey("AccountId")]
    //[InverseProperty("Accounts1")]
    [NotMapped]
    public virtual ICollection<AccountJournal> Journals { get; set; } = new List<AccountJournal>();

    [ForeignKey("AccountId")]
    //[InverseProperty("Accounts")]
    [NotMapped]
    public virtual ICollection<AccountBankbookReport> ReportLines { get; set; } = new List<AccountBankbookReport>();

    [ForeignKey("AccountId")]
    //[InverseProperty("Accounts")]
    [NotMapped]
    public virtual ICollection<AccountDaybookReport> ReportLines1 { get; set; } = new List<AccountDaybookReport>();

    [ForeignKey("AccountId")]
    //[InverseProperty("Accounts")]
    [NotMapped]
    public virtual ICollection<AccountFinancialReport> ReportLines2 { get; set; } = new List<AccountFinancialReport>();

    [ForeignKey("AccountId")]
    //[InverseProperty("Accounts")]
    [NotMapped]
    public virtual ICollection<AccountCashbookReport> ReportLinesNavigation { get; set; } = new List<AccountCashbookReport>();

    [ForeignKey("AccountAccountId")]
    //[InverseProperty("AccountAccounts")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanies { get; set; } = new List<ResCompany>();

    [ForeignKey("AccountId")]
    //[InverseProperty("Accounts")]
    [NotMapped]
    public virtual ICollection<AccountTax> Taxes { get; set; } = new List<AccountTax>();
}
