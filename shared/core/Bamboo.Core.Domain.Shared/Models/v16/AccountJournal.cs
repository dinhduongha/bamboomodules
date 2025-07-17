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

[Table("account_journal")]
//[Index("TenantId", "Code", Name = "account_journal_code_company_uniq", IsUnique = true)]
//[Index("TenantId", Name = "account_journal_company_id_index")]
public partial class AccountJournal: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("default_account_id")]
    public Guid? DefaultAccountId { get; set; }

    [Column("suspense_account_id")]
    public Guid? SuspenseAccountId { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("profit_account_id")]
    public Guid? ProfitAccountId { get; set; }

    [Column("loss_account_id")]
    public Guid? LossAccountId { get; set; }

    [Column("bank_account_id")]
    public Guid? BankAccountId { get; set; }

    [Column("sale_activity_type_id")]
    public Guid? SaleActivityTypeId { get; set; }

    [Column("sale_activity_user_id")]
    public Guid? SaleActivityUserId { get; set; }

    [Column("alias_id")]
    public Guid? AliasId { get; set; }

    [Column("secure_sequence_id")]
    public Guid? SecureSequenceId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("access_token")]
    public string? AccessToken { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("type")]
    public string? Type { get; set; }

    [Column("invoice_reference_type")]
    public string? InvoiceReferenceType { get; set; }

    [Column("invoice_reference_model")]
    public string? InvoiceReferenceModel { get; set; }

    [Column("bank_statements_source")]
    public string? BankStatementsSource { get; set; }

    [Column("sequence_override_regex")]
    public string? SequenceOverrideRegex { get; set; }

    [Column("sale_activity_note")]
    public string? SaleActivityNote { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("autocheck_on_post")]
    public bool? AutocheckOnPost { get; set; }

    [Column("restrict_mode_hash_table")]
    public bool? RestrictModeHashTable { get; set; }

    [Column("refund_sequence")]
    public bool? RefundSequence { get; set; }

    [Column("payment_sequence")]
    public bool? PaymentSequence { get; set; }

    [Column("show_on_dashboard")]
    public bool? ShowOnDashboard { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("AliasId")]
    //[InverseProperty("AccountJournals")]
    [NotMapped]
    public virtual MailAlias? Alias { get; set; }

    [ForeignKey("BankAccountId")]
    //[InverseProperty("AccountJournals")]
    [NotMapped]
    public virtual ResPartnerBank? BankAccount { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("AccountJournals")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountJournalCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CurrencyId")]
    //[InverseProperty("AccountJournals")]
    [NotMapped]
    public virtual ResCurrency? Currency { get; set; }

    [ForeignKey("DefaultAccountId")]
    //[InverseProperty("AccountJournalDefaultAccounts")]
    [NotMapped]
    public virtual AccountAccount? DefaultAccount { get; set; }

    [ForeignKey("LossAccountId")]
    //[InverseProperty("AccountJournalLossAccounts")]
    [NotMapped]
    public virtual AccountAccount? LossAccount { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("AccountJournals")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("ProfitAccountId")]
    //[InverseProperty("AccountJournalProfitAccounts")]
    [NotMapped]
    public virtual AccountAccount? ProfitAccount { get; set; }

    [ForeignKey("SaleActivityTypeId")]
    //[InverseProperty("AccountJournals")]
    [NotMapped]
    public virtual MailActivityType? SaleActivityType { get; set; }

    [ForeignKey("SaleActivityUserId")]
    //[InverseProperty("AccountJournalSaleActivityUsers")]
    [NotMapped]
    public virtual ResUser? SaleActivityUser { get; set; }

    [ForeignKey("SecureSequenceId")]
    //[InverseProperty("AccountJournals")]
    [NotMapped]
    public virtual IrSequence? SecureSequence { get; set; }

    [ForeignKey("SuspenseAccountId")]
    //[InverseProperty("AccountJournalSuspenseAccounts")]
    [NotMapped]
    public virtual AccountAccount? SuspenseAccount { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountJournalWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Journal")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLines { get; set; } = new List<AccountAnalyticLine>();

    //[InverseProperty("Journal")]
    [NotMapped]
    public virtual ICollection<AccountAssetCategory> AccountAssetCategories { get; set; } = new List<AccountAssetCategory>();

    //[InverseProperty("Journal")]
    [NotMapped]
    public virtual ICollection<AccountBankStatementImportJournalCreation> AccountBankStatementImportJournalCreations { get; set; } = new List<AccountBankStatementImportJournalCreation>();

    //[InverseProperty("Journal")]
    [NotMapped]
    public virtual ICollection<AccountBankStatement> AccountBankStatements { get; set; } = new List<AccountBankStatement>();

    //[InverseProperty("Journal")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLines { get; set; } = new List<AccountMoveLine>();

    //[InverseProperty("Journal")]
    [NotMapped]
    public virtual ICollection<AccountMoveReversal> AccountMoveReversals { get; set; } = new List<AccountMoveReversal>();

    //[InverseProperty("Journal")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMoves { get; set; } = new List<AccountMove>();

    //[InverseProperty("Journal")]
    [NotMapped]
    public virtual ICollection<AccountPaymentMethodLine> AccountPaymentMethodLines { get; set; } = new List<AccountPaymentMethodLine>();

    //[InverseProperty("Journal")]
    [NotMapped]
    public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisters { get; set; } = new List<AccountPaymentRegister>();

    //[InverseProperty("DestinationJournal")]
    [NotMapped]
    public virtual ICollection<AccountPayment> AccountPayments { get; set; } = new List<AccountPayment>();

    //[InverseProperty("Journal")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelLine> AccountReconcileModelLines { get; set; } = new List<AccountReconcileModelLine>();

    //[InverseProperty("Journal")]
    [NotMapped]
    public virtual ICollection<AccountRecurringTemplate> AccountRecurringTemplates { get; set; } = new List<AccountRecurringTemplate>();

    //[InverseProperty("BankJournal")]
    [NotMapped]
    public virtual ICollection<HrExpenseSheet> HrExpenseSheetBankJournals { get; set; } = new List<HrExpenseSheet>();

    //[InverseProperty("Journal")]
    [NotMapped]
    public virtual ICollection<HrExpenseSheet> HrExpenseSheetJournals { get; set; } = new List<HrExpenseSheet>();

    //[InverseProperty("InvoiceJournal")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigInvoiceJournals { get; set; } = new List<PosConfig>();

    //[InverseProperty("Journal")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigJournals { get; set; } = new List<PosConfig>();

    //[InverseProperty("SaleJournalNavigation")]
    [NotMapped]
    public virtual ICollection<PosOrder> PosOrders { get; set; } = new List<PosOrder>();

    //[InverseProperty("Journal")]
    [NotMapped]
    public virtual ICollection<PosPaymentMethod> PosPaymentMethods { get; set; } = new List<PosPaymentMethod>();

    //[InverseProperty("CashJournal")]
    [NotMapped]
    public virtual ICollection<PosSession> PosSessions { get; set; } = new List<PosSession>();

    //[InverseProperty("Journal")]
    [NotMapped]
    public virtual ICollection<RecurringPaymentLine> RecurringPaymentLines { get; set; } = new List<RecurringPaymentLine>();

    //[InverseProperty("AutomaticEntryDefaultJournal")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAutomaticEntryDefaultJournals { get; set; } = new List<ResCompany>();

    //[InverseProperty("CompanyExpenseJournal")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyCompanyExpenseJournals { get; set; } = new List<ResCompany>();

    //[InverseProperty("CurrencyExchangeJournal")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyCurrencyExchangeJournals { get; set; } = new List<ResCompany>();

    //[InverseProperty("ExpenseJournal")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyExpenseJournals { get; set; } = new List<ResCompany>();

    //[InverseProperty("TaxCashBasisJournal")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyTaxCashBasisJournals { get; set; } = new List<ResCompany>();

    //[InverseProperty("AccountJournal")]
    [NotMapped]
    public virtual ICollection<StockValuationLayerRevaluation> StockValuationLayerRevaluations { get; set; } = new List<StockValuationLayerRevaluation>();

    [ForeignKey("AccountJournalId")]
    //[InverseProperty("AccountJournals")]
    [NotMapped]
    public virtual ICollection<AccountAccount> AccountAccounts { get; set; } = new List<AccountAccount>();

    [ForeignKey("AccountJournalId")]
    //[InverseProperty("AccountJournals")]
    [NotMapped]
    public virtual ICollection<AccountAgedTrialBalance> AccountAgedTrialBalances { get; set; } = new List<AccountAgedTrialBalance>();

    [ForeignKey("AccountJournalId")]
    //[InverseProperty("AccountJournals")]
    [NotMapped]
    public virtual ICollection<AccountBankbookReport> AccountBankbookReports { get; set; } = new List<AccountBankbookReport>();

    [ForeignKey("AccountJournalId")]
    //[InverseProperty("AccountJournals")]
    [NotMapped]
    public virtual ICollection<AccountCashbookReport> AccountCashbookReports { get; set; } = new List<AccountCashbookReport>();

    [ForeignKey("AccountJournalId")]
    //[InverseProperty("AccountJournals")]
    [NotMapped]
    public virtual ICollection<AccountCommonAccountReport> AccountCommonAccountReports { get; set; } = new List<AccountCommonAccountReport>();

    [ForeignKey("AccountJournalId")]
    //[InverseProperty("AccountJournals")]
    [NotMapped]
    public virtual ICollection<AccountCommonJournalReport> AccountCommonJournalReports { get; set; } = new List<AccountCommonJournalReport>();

    [ForeignKey("AccountJournalId")]
    //[InverseProperty("AccountJournals")]
    [NotMapped]
    public virtual ICollection<AccountCommonPartnerReport> AccountCommonPartnerReports { get; set; } = new List<AccountCommonPartnerReport>();

    [ForeignKey("AccountJournalId")]
    //[InverseProperty("AccountJournals")]
    [NotMapped]
    public virtual ICollection<AccountCommonReport> AccountCommonReports { get; set; } = new List<AccountCommonReport>();

    [ForeignKey("AccountJournalId")]
    //[InverseProperty("AccountJournals")]
    [NotMapped]
    public virtual ICollection<AccountDaybookReport> AccountDaybookReports { get; set; } = new List<AccountDaybookReport>();

    [ForeignKey("AccountJournalId")]
    //[InverseProperty("AccountJournals")]
    [NotMapped]
    public virtual ICollection<AccountEdiFormat> AccountEdiFormats { get; set; } = new List<AccountEdiFormat>();

    [ForeignKey("AccountJournalId")]
    //[InverseProperty("AccountJournals")]
    [NotMapped]
    public virtual ICollection<AccountJournalGroup> AccountJournalGroups { get; set; } = new List<AccountJournalGroup>();

    [ForeignKey("AccountJournalId")]
    //[InverseProperty("AccountJournals")]
    [NotMapped]
    public virtual ICollection<AccountPrintJournal> AccountPrintJournals { get; set; } = new List<AccountPrintJournal>();

    [ForeignKey("AccountJournalId")]
    //[InverseProperty("AccountJournals")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelTemplate> AccountReconcileModelTemplates { get; set; } = new List<AccountReconcileModelTemplate>();

    [ForeignKey("AccountJournalId")]
    //[InverseProperty("AccountJournals")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModel> AccountReconcileModels { get; set; } = new List<AccountReconcileModel>();

    [ForeignKey("AccountJournalId")]
    //[InverseProperty("AccountJournals")]
    [NotMapped]
    public virtual ICollection<AccountReportPartnerLedger> AccountReportPartnerLedgers { get; set; } = new List<AccountReportPartnerLedger>();

    [ForeignKey("AccountJournalId")]
    //[InverseProperty("AccountJournals")]
    [NotMapped]
    public virtual ICollection<AccountTaxReportWizard> AccountTaxReportWizards { get; set; } = new List<AccountTaxReportWizard>();

    [ForeignKey("AccountJournalId")]
    //[InverseProperty("AccountJournals")]
    [NotMapped]
    public virtual ICollection<AccountingReport> AccountingReports { get; set; } = new List<AccountingReport>();

    [ForeignKey("JournalId")]
    //[InverseProperty("Journals")]
    [NotMapped]
    public virtual ICollection<AccountBalanceReport> Accounts { get; set; } = new List<AccountBalanceReport>();

    [ForeignKey("JournalId")]
    //[InverseProperty("Journals")]
    [NotMapped]
    public virtual ICollection<AccountAccount> Accounts1 { get; set; } = new List<AccountAccount>();

    [ForeignKey("JournalId")]
    //[InverseProperty("Journals")]
    [NotMapped]
    public virtual ICollection<AccountReportGeneralLedger> AccountsNavigation { get; set; } = new List<AccountReportGeneralLedger>();
}
