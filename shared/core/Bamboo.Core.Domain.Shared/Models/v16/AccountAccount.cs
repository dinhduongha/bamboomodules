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
    public override Guid? LastModifierId { get; set; }

    [Column("account_type")]
    public string? AccountType { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    // v16-Compat json
    //[Column("code")]
    [JsonField]
    [Column("code_store", TypeName = "jsonb")]
    public string? Code { get; set; }

    [JsonField]
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
    public override DateTime? LastModificationTime { get; set; }

    // v16-Compat
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

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountAccountWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }


    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<AccountAccruedOrdersWizard> AccountAccruedOrdersWizards { get; set; } 

    //[InverseProperty("GeneralAccount")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLines { get; set; } 

    //[InverseProperty("AccountAsset")]
    [NotMapped]
    public virtual ICollection<AccountAssetCategory> AccountAssetCategoryAccountAssets { get; set; } 

    //[InverseProperty("AccountDepreciationExpense")]
    [NotMapped]
    public virtual ICollection<AccountAssetCategory> AccountAssetCategoryAccountDepreciationExpenses { get; set; } 

    //[InverseProperty("AccountDepreciation")]
    [NotMapped]
    public virtual ICollection<AccountAssetCategory> AccountAssetCategoryAccountDepreciations { get; set; } 

    //[InverseProperty("DestinationAccount")]
    [NotMapped]
    public virtual ICollection<AccountAutomaticEntryWizard> AccountAutomaticEntryWizards { get; set; } 

    //[InverseProperty("AccountDest")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionAccount> AccountFiscalPositionAccountAccountDests { get; set; } 

    //[InverseProperty("AccountSrc")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionAccount> AccountFiscalPositionAccountAccountSrcs { get; set; } 

    //[InverseProperty("DefaultAccount")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournalDefaultAccounts { get; set; } 

    //[InverseProperty("LossAccount")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournalLossAccounts { get; set; } 

    //[InverseProperty("ProfitAccount")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournalProfitAccounts { get; set; } 

    //[InverseProperty("SuspenseAccount")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournalSuspenseAccounts { get; set; } 

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<AccountMergeWizardLine> AccountMergeWizardLines { get; set; } 

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLines { get; set; } 

    //[InverseProperty("DestinationAccount")]
    [NotMapped]
    public virtual ICollection<AccountPayment> AccountPaymentDestinationAccounts { get; set; } 

    //[InverseProperty("ForceOutstandingAccount")]
    [NotMapped]
    public virtual ICollection<AccountPayment> AccountPaymentForceOutstandingAccounts { get; set; } 

    //[InverseProperty("PaymentAccount")]
    [NotMapped]
    public virtual ICollection<AccountPaymentMethodLine> AccountPaymentMethodLines { get; set; } 

    //[InverseProperty("OutstandingAccount")]
    [NotMapped]
    public virtual ICollection<AccountPayment> AccountPaymentOutstandingAccounts { get; set; } 

    //[InverseProperty("WriteoffAccount")]
    [NotMapped]
    public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisters { get; set; } 

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelLine> AccountReconcileModelLines { get; set; } 

    //[InverseProperty("AdvanceTaxPaymentAccount")]
    [NotMapped]
    public virtual ICollection<AccountTaxGroup> AccountTaxGroupAdvanceTaxPaymentAccounts { get; set; } 

    //[InverseProperty("TaxPayableAccount")]
    [NotMapped]
    public virtual ICollection<AccountTaxGroup> AccountTaxGroupTaxPayableAccounts { get; set; } 

    //[InverseProperty("TaxReceivableAccount")]
    [NotMapped]
    public virtual ICollection<AccountTaxGroup> AccountTaxGroupTaxReceivableAccounts { get; set; } 

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<AccountTaxRepartitionLine> AccountTaxRepartitionLines { get; set; } 

    //[InverseProperty("CashBasisTransitionAccount")]
    [NotMapped]
    public virtual ICollection<AccountTax> AccountTaxes { get; set; } 

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<HrExpense> HrExpenses { get; set; } 

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<MrpAccountWipAccountingLine> MrpAccountWipAccountingLines { get; set; } 

    //[InverseProperty("ExpenseAccount")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenter> MrpWorkcenters { get; set; } 

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<PosCloseSessionWizard> PosCloseSessionWizards { get; set; } 

    //[InverseProperty("OutstandingAccount")]
    [NotMapped]
    public virtual ICollection<PosPaymentMethod> PosPaymentMethodOutstandingAccounts { get; set; } 

    //[InverseProperty("ReceivableAccount")]
    [NotMapped]
    public virtual ICollection<PosPaymentMethod> PosPaymentMethodReceivableAccounts { get; set; } 

    //[InverseProperty("AccountCashBasisBaseAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountCashBasisBaseAccounts { get; set; } 

    //[InverseProperty("AccountDefaultPosReceivableAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountDefaultPosReceivableAccounts { get; set; } 

    //[InverseProperty("AccountDiscountExpenseAllocation")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountDiscountExpenseAllocations { get; set; } 

    //[InverseProperty("AccountDiscountIncomeAllocation")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountDiscountIncomeAllocations { get; set; } 

    //[InverseProperty("AccountJournalEarlyPayDiscountGainAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountJournalEarlyPayDiscountGainAccounts { get; set; } 

    //[InverseProperty("AccountJournalEarlyPayDiscountLossAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountJournalEarlyPayDiscountLossAccounts { get; set; } 

    //[InverseProperty("AccountJournalSuspenseAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountJournalSuspenseAccounts { get; set; } 

    //[InverseProperty("AccountProductionWipAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountProductionWipAccounts { get; set; } 

    //[InverseProperty("AccountProductionWipOverheadAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountProductionWipOverheadAccounts { get; set; } 

    // v16-Compat
    //[InverseProperty("AccountJournalPaymentCreditAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountJournalPaymentCreditAccounts { get; set; } 

    // v16-Compat
    //[InverseProperty("AccountJournalPaymentDebitAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountJournalPaymentDebitAccounts { get; set; } 


    //[InverseProperty("DefaultCashDifferenceExpenseAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyDefaultCashDifferenceExpenseAccounts { get; set; } 

    //[InverseProperty("DefaultCashDifferenceIncomeAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyDefaultCashDifferenceIncomeAccounts { get; set; } 

    //[InverseProperty("ExpenseAccrualAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyExpenseAccrualAccounts { get; set; } 

    //[InverseProperty("ExpenseCurrencyExchangeAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyExpenseCurrencyExchangeAccounts { get; set; } 

    //[InverseProperty("ExpenseOutstandingAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyExpenseOutstandingAccounts { get; set; } 

    //[InverseProperty("IncomeCurrencyExchangeAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyIncomeCurrencyExchangeAccounts { get; set; } 

    // v16-Compat
    //[InverseProperty("PropertyStockAccountInputCateg")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyPropertyStockAccountInputCategs { get; set; } 

    // v16-Compat
    //[InverseProperty("PropertyStockAccountOutputCateg")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyPropertyStockAccountOutputCategs { get; set; } 

    // v16-Compat
    //[InverseProperty("PropertyStockValuationAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyPropertyStockValuationAccounts { get; set; } 

    //[InverseProperty("RevenueAccrualAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyRevenueAccrualAccounts { get; set; } 

    //[InverseProperty("TransferAccount")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyTransferAccounts { get; set; } 

    // v16-Compat
    //[InverseProperty("DepositAccount")]
    [NotMapped]
    public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInvs { get; set; } 

    //[InverseProperty("ValuationInAccount")]
    [NotMapped]
    public virtual ICollection<StockLocation> StockLocationValuationInAccounts { get; set; } 

    //[InverseProperty("ValuationOutAccount")]
    [NotMapped]
    public virtual ICollection<StockLocation> StockLocationValuationOutAccounts { get; set; } 

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<StockValuationLayerRevaluation> StockValuationLayerRevaluations { get; set; } 

    [ForeignKey("AccountAccountId")]
    //[InverseProperty("AccountAccounts")]
    [NotMapped]
    public virtual ICollection<AccountAccountTag> AccountAccountTags { get; set; } 

    [ForeignKey("AccountAccountId")]
    //[InverseProperty("AccountAccounts")]
    [NotMapped]
    public virtual ICollection<AccountBalanceReport> AccountBalanceReports { get; set; } 

    [ForeignKey("AccountAccountId")]
    //[InverseProperty("AccountAccounts")]
    [NotMapped]
    public virtual ICollection<AccountCommonAccountReport> AccountCommonAccountReports { get; set; } 

    [ForeignKey("AccountAccountId")]
    //[InverseProperty("AccountAccounts")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournals { get; set; } 

    [ForeignKey("AccountAccountId")]
    //[InverseProperty("AccountAccounts")]
    [NotMapped]
    public virtual ICollection<AccountMergeWizard> AccountMergeWizards { get; set; } 

    [ForeignKey("AccountAccountId")]
    //[InverseProperty("AccountAccounts")]
    [NotMapped]
    public virtual ICollection<AccountReportGeneralLedger> AccountReportGeneralLedgers { get; set; } 

    [ForeignKey("AccountId")]
    //[InverseProperty("Accounts")]
    [NotMapped]
    public virtual ICollection<AccountBudgetPost> Budgets { get; set; } 

    [ForeignKey("AccountId")]
    //[InverseProperty("Accounts1")]
    [NotMapped]
    public virtual ICollection<AccountJournal> Journals { get; set; } 

    [ForeignKey("AccountId")]
    //[InverseProperty("Accounts")]
    [NotMapped]
    public virtual ICollection<AccountBankbookReport> ReportLines { get; set; } 

    [ForeignKey("AccountId")]
    //[InverseProperty("Accounts")]
    [NotMapped]
    public virtual ICollection<AccountDaybookReport> ReportLines1 { get; set; } 

    [ForeignKey("AccountId")]
    //[InverseProperty("Accounts")]
    [NotMapped]
    public virtual ICollection<AccountFinancialReport> ReportLines2 { get; set; } 

    [ForeignKey("AccountId")]
    //[InverseProperty("Accounts")]
    [NotMapped]
    public virtual ICollection<AccountCashbookReport> ReportLinesNavigation { get; set; } 

    [ForeignKey("AccountAccountId")]
    //[InverseProperty("AccountAccounts")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanies { get; set; } 

    [ForeignKey("AccountId")]
    //[InverseProperty("Accounts")]
    [NotMapped]
    public virtual ICollection<AccountTax> Taxes { get; set; } 
}
