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
public partial class AccountAccount: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("currency_id")]
    public long? CurrencyId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("group_id")]
    public Guid? GroupId { get; set; }

    [Column("root_id")]
    public Guid? RootId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("account_type")]
    public string? AccountType { get; set; }

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
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("AccountAccounts")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountAccountCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CurrencyId")]
    //[InverseProperty("AccountAccounts")]
    [NotMapped]
    public virtual ResCurrency? Currency { get; set; }

    [ForeignKey("GroupId")]
    //[InverseProperty("AccountAccounts")]
    [NotMapped]
    public virtual AccountGroup? Group { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("AccountAccounts")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountAccountWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<HrExpense> HrExpenses { get; } = new List<HrExpense>();

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<AccountAccruedOrdersWizard> AccountAccruedOrdersWizards { get; } = new List<AccountAccruedOrdersWizard>();

    //[InverseProperty("GeneralAccount")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLines { get; } = new List<AccountAnalyticLine>();

    //[InverseProperty("AccountAsset")]
    [NotMapped]
    public virtual ICollection<AccountAssetCategory> AccountAssetCategoryAccountAssets { get; } = new List<AccountAssetCategory>();

    //[InverseProperty("AccountDepreciationExpense")]
    [NotMapped]
    public virtual ICollection<AccountAssetCategory> AccountAssetCategoryAccountDepreciationExpenses { get; } = new List<AccountAssetCategory>();

    //[InverseProperty("AccountDepreciation")]
    [NotMapped]
    public virtual ICollection<AccountAssetCategory> AccountAssetCategoryAccountDepreciations { get; } = new List<AccountAssetCategory>();

    //[InverseProperty("DestinationAccount")]
    [NotMapped]
    public virtual ICollection<AccountAutomaticEntryWizard> AccountAutomaticEntryWizards { get; } = new List<AccountAutomaticEntryWizard>();

    //[InverseProperty("AccountDest")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionAccount> AccountFiscalPositionAccountAccountDests { get; } = new List<AccountFiscalPositionAccount>();

    //[InverseProperty("AccountSrc")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionAccount> AccountFiscalPositionAccountAccountSrcs { get; } = new List<AccountFiscalPositionAccount>();

    //[InverseProperty("DefaultAccount")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournalDefaultAccounts { get; } = new List<AccountJournal>();

    //[InverseProperty("LossAccount")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournalLossAccounts { get; } = new List<AccountJournal>();

    //[InverseProperty("ProfitAccount")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournalProfitAccounts { get; } = new List<AccountJournal>();

    //[InverseProperty("SuspenseAccount")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournalSuspenseAccounts { get; } = new List<AccountJournal>();

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLines { get; } = new List<AccountMoveLine>();

    //[InverseProperty("DestinationAccount")]
    [NotMapped]
    public virtual ICollection<AccountPayment> AccountPaymentDestinationAccounts { get; } = new List<AccountPayment>();

    //[InverseProperty("ForceOutstandingAccount")]
    [NotMapped]
    public virtual ICollection<AccountPayment> AccountPaymentForceOutstandingAccounts { get; } = new List<AccountPayment>();

    //[InverseProperty("PaymentAccount")]
    [NotMapped]
    public virtual ICollection<AccountPaymentMethodLine> AccountPaymentMethodLines { get; } = new List<AccountPaymentMethodLine>();

    //[InverseProperty("OutstandingAccount")]
    [NotMapped]
    public virtual ICollection<AccountPayment> AccountPaymentOutstandingAccounts { get; } = new List<AccountPayment>();

    //[InverseProperty("WriteoffAccount")]
    [NotMapped]
    public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisters { get; } = new List<AccountPaymentRegister>();

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelLine> AccountReconcileModelLines { get; } = new List<AccountReconcileModelLine>();

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<AccountTaxRepartitionLine> AccountTaxRepartitionLines { get; } = new List<AccountTaxRepartitionLine>();

    //[InverseProperty("CashBasisTransitionAccount")]
    [NotMapped]
    public virtual ICollection<AccountTax> AccountTaxes { get; } = new List<AccountTax>();

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<PosCloseSessionWizard> PosCloseSessionWizards { get; } = new List<PosCloseSessionWizard>();

    //[InverseProperty("OutstandingAccount")]
    [NotMapped]
    public virtual ICollection<PosPaymentMethod> PosPaymentMethodOutstandingAccounts { get; } = new List<PosPaymentMethod>();

    //[InverseProperty("ReceivableAccount")]
    [NotMapped]
    public virtual ICollection<PosPaymentMethod> PosPaymentMethodReceivableAccounts { get; } = new List<PosPaymentMethod>();

    //[InverseProperty("AccountCashBasisBaseAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountCashBasisBaseAccounts { get; } = new List<ResCompany>();

    //[InverseProperty("AccountDefaultPosReceivableAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountDefaultPosReceivableAccounts { get; } = new List<ResCompany>();

    //[InverseProperty("AccountJournalEarlyPayDiscountGainAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountJournalEarlyPayDiscountGainAccounts { get; } = new List<ResCompany>();

    //[InverseProperty("AccountJournalEarlyPayDiscountLossAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountJournalEarlyPayDiscountLossAccounts { get; } = new List<ResCompany>();

    //[InverseProperty("AccountJournalPaymentCreditAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountJournalPaymentCreditAccounts { get; } = new List<ResCompany>();

    //[InverseProperty("AccountJournalPaymentDebitAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountJournalPaymentDebitAccounts { get; } = new List<ResCompany>();

    //[InverseProperty("AccountJournalSuspenseAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountJournalSuspenseAccounts { get; } = new List<ResCompany>();

    //[InverseProperty("DefaultCashDifferenceExpenseAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyDefaultCashDifferenceExpenseAccounts { get; } = new List<ResCompany>();

    //[InverseProperty("DefaultCashDifferenceIncomeAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyDefaultCashDifferenceIncomeAccounts { get; } = new List<ResCompany>();

    //[InverseProperty("ExpenseAccrualAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyExpenseAccrualAccounts { get; } = new List<ResCompany>();

    //[InverseProperty("ExpenseCurrencyExchangeAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyExpenseCurrencyExchangeAccounts { get; } = new List<ResCompany>();

    //[InverseProperty("IncomeCurrencyExchangeAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyIncomeCurrencyExchangeAccounts { get; } = new List<ResCompany>();

    //[InverseProperty("PropertyStockAccountInputCateg")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyPropertyStockAccountInputCategs { get; } = new List<ResCompany>();

    //[InverseProperty("PropertyStockAccountOutputCateg")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyPropertyStockAccountOutputCategs { get; } = new List<ResCompany>();

    //[InverseProperty("PropertyStockValuationAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyPropertyStockValuationAccounts { get; } = new List<ResCompany>();

    //[InverseProperty("RevenueAccrualAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyRevenueAccrualAccounts { get; } = new List<ResCompany>();

    //[InverseProperty("TransferAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyTransferAccounts { get; } = new List<ResCompany>();

    //[InverseProperty("DepositAccount")]
    [NotMapped]
    public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInvs { get; } = new List<SaleAdvancePaymentInv>();

    //[InverseProperty("ValuationInAccount")]
    [NotMapped]
    public virtual ICollection<StockLocation> StockLocationValuationInAccounts { get; } = new List<StockLocation>();

    //[InverseProperty("ValuationOutAccount")]
    [NotMapped]
    public virtual ICollection<StockLocation> StockLocationValuationOutAccounts { get; } = new List<StockLocation>();

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<StockValuationLayerRevaluation> StockValuationLayerRevaluations { get; } = new List<StockValuationLayerRevaluation>();


    [ForeignKey("AccountAccountId")]
    //[InverseProperty("AccountAccounts")] 
    [NotMapped]
    public virtual ICollection<AccountAccountTag> AccountAccountTags { get; } = new List<AccountAccountTag>();

    [ForeignKey("AccountAccountId")]
    //[InverseProperty("AccountAccounts")]
    [NotMapped]
    public virtual ICollection<AccountBalanceReport> AccountBalanceReports { get; } = new List<AccountBalanceReport>();

    [ForeignKey("AccountAccountId")]
    //[InverseProperty("AccountAccounts")]
    [NotMapped]
    public virtual ICollection<AccountCommonAccountReport> AccountCommonAccountReports { get; } = new List<AccountCommonAccountReport>();

    [ForeignKey("AccountAccountId")]
    //[InverseProperty("AccountAccounts")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournals { get; } = new List<AccountJournal>();

    [ForeignKey("AccountAccountId")]
    //[InverseProperty("AccountAccounts")]
    [NotMapped]
    public virtual ICollection<AccountReportGeneralLedger> AccountReportGeneralLedgers { get; } = new List<AccountReportGeneralLedger>();

    [ForeignKey("AccountId")]
    //[InverseProperty("Accounts")]
    [NotMapped]
    public virtual ICollection<AccountBudgetPost> Budgets { get; } = new List<AccountBudgetPost>();

    [ForeignKey("AccountId")]
    //[InverseProperty("Accounts1")]
    [NotMapped]
    public virtual ICollection<AccountJournal> Journals { get; } = new List<AccountJournal>();

    [ForeignKey("AccountId")]
    //[InverseProperty("Accounts")]
    [NotMapped]
    public virtual ICollection<AccountBankbookReport> ReportLines { get; } = new List<AccountBankbookReport>();

    [ForeignKey("AccountId")]
    //[InverseProperty("Accounts")]
    [NotMapped]
    public virtual ICollection<AccountDaybookReport> ReportLines1 { get; } = new List<AccountDaybookReport>();

    [ForeignKey("AccountId")]
    //[InverseProperty("Accounts")]
    [NotMapped]
    public virtual ICollection<AccountFinancialReport> ReportLines2 { get; } = new List<AccountFinancialReport>();

    [ForeignKey("AccountId")]
    //[InverseProperty("Accounts")]
    [NotMapped]
    public virtual ICollection<AccountCashbookReport> ReportLinesNavigation { get; } = new List<AccountCashbookReport>();

    [ForeignKey("AccountId")]
    //[InverseProperty("Accounts")]
    [NotMapped]
    public virtual ICollection<AccountTax> Taxes { get; } = new List<AccountTax>();
}
