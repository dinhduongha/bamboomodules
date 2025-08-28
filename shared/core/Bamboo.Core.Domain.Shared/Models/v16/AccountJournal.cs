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
//[Index("CompanyId", Name = "account_journal__company_id_index")]
//[Index("CompanyId", "Code", Name = "account_journal_code_company_uniq", IsUnique = true)]
public partial class AccountJournal: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("alias_id")]
    public Guid? AliasId { get; set; }

    [Column("default_account_id")]
    public Guid? DefaultAccountId { get; set; }

    [Column("suspense_account_id")]
    public Guid? SuspenseAccountId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("profit_account_id")]
    public Guid? ProfitAccountId { get; set; }

    [Column("loss_account_id")]
    public Guid? LossAccountId { get; set; }

    [Column("bank_account_id")]
    public Guid? BankAccountId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("access_token")]
    public string? AccessToken { get; set; }

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

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("sequence_override_regex")]
    public string? SequenceOverrideRegex { get; set; }

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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("debit_sequence")]
    public bool? DebitSequence { get; set; }

    [Column("is_peppol_journal")]
    public bool? IsPeppolJournal { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("JournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Journal")] // One2many
    public virtual ICollection<AccountAccruedOrdersWizard> AccountAccruedOrdersWizard { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("JournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Journal")] // One2many
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLine { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("JournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Journal")] // One2many
    public virtual ICollection<AccountAssetCategory> AccountAssetCategory { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("JournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Journal")] // One2many
    public virtual ICollection<AccountBankStatement> AccountBankStatement { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("JournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Journal")] // One2many
    public virtual ICollection<AccountBankStatementLine> AccountBankStatementLine { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("JournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Journal")] // One2many
    public virtual ICollection<AccountDebitNote> AccountDebitNote { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("JournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Journal")] // One2many
    public virtual ICollection<AccountMove> AccountMove { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("JournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Journal")] // One2many
    public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("JournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Journal")] // One2many
    public virtual ICollection<AccountMoveReversal> AccountMoveReversal { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("JournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Journal")] // One2many
    public virtual ICollection<AccountPayment> AccountPayment { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("JournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Journal")] // One2many
    public virtual ICollection<AccountPaymentMethodLine> AccountPaymentMethodLine { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("JournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Journal")] // One2many
    public virtual ICollection<AccountPaymentRegister> AccountPaymentRegister { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("JournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Journal")] // One2many
    public virtual ICollection<AccountReconcileModelLine> AccountReconcileModelLine { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("JournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Journal")] // One2many
    public virtual ICollection<AccountRecurringTemplate> AccountRecurringTemplate { get; set; }

    // [Many2one]
    [ForeignKey("AliasId")]
    public virtual MailAlias? Alias { get; set; }

    // [Many2one]
    [ForeignKey("BankAccountId")]
    public virtual ResPartnerBank? BankAccount { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CurrencyId")]
    public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    [ForeignKey("DefaultAccountId")]
    public virtual AccountAccount? DefaultAccount { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("JournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Journal")] // One2many
    public virtual ICollection<HrContract> HrContract { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("EmployeeJournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("EmployeeJournal")] // One2many
    public virtual ICollection<HrExpenseSheet> HrExpenseSheetEmployeeJournal { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("JournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Journal")] // One2many
    public virtual ICollection<HrExpenseSheet> HrExpenseSheetJournal { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("JournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Journal")] // One2many
    public virtual ICollection<HrPayslip> HrPayslip { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("JournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Journal")] // One2many
    public virtual ICollection<HrPayslipRun> HrPayslipRun { get; set; }

    // [Many2one]
    [ForeignKey("LossAccountId")]
    public virtual AccountAccount? LossAccount { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("JournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Journal")] // One2many
    public virtual ICollection<MrpAccountWipAccounting> MrpAccountWipAccounting { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("InvoiceJournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("InvoiceJournal")] // One2many
    public virtual ICollection<PosConfig> PosConfigInvoiceJournal { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("JournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Journal")] // One2many
    public virtual ICollection<PosConfig> PosConfigJournal { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("SaleJournal")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SaleJournalNavigation")] // One2many
    public virtual ICollection<PosOrder> PosOrder { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("JournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Journal")] // One2many
    public virtual ICollection<PosPaymentMethod> PosPaymentMethod { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("CashJournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("CashJournal")] // One2many
    public virtual ICollection<PosSession> PosSession { get; set; }

    // [Many2one]
    [ForeignKey("ProfitAccountId")]
    public virtual AccountAccount? ProfitAccount { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("JournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Journal")] // One2many
    public virtual ICollection<RecurringPaymentLine> RecurringPaymentLine { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("AutomaticEntryDefaultJournalId")]
    [NotMapped] // One2many // Peer relationship (ResCompany) is commented out
    // [InverseProperty("AutomaticEntryDefaultJournal")] // One2many
    public virtual ICollection<ResCompany> ResCompanyAutomaticEntryDefaultJournal { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("CurrencyExchangeJournalId")]
    [NotMapped] // One2many // Peer relationship (ResCompany) is commented out
    // [InverseProperty("CurrencyExchangeJournal")] // One2many
    public virtual ICollection<ResCompany> ResCompanyCurrencyExchangeJournal { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ExpenseJournalId")]
    [NotMapped] // One2many // Peer relationship (ResCompany) is commented out
    // [InverseProperty("ExpenseJournal")] // One2many
    public virtual ICollection<ResCompany> ResCompanyExpenseJournal { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("LcJournalId")]
    [NotMapped] // One2many // Peer relationship (ResCompany) is commented out
    // [InverseProperty("LcJournal")] // One2many
    public virtual ICollection<ResCompany> ResCompanyLcJournal { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("PeppolPurchaseJournalId")]
    [NotMapped] // One2many // Peer relationship (ResCompany) is commented out
    // [InverseProperty("PeppolPurchaseJournal")] // One2many
    public virtual ICollection<ResCompany> ResCompanyPeppolPurchaseJournal { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("TaxCashBasisJournalId")]
    [NotMapped] // One2many // Peer relationship (ResCompany) is commented out
    // [InverseProperty("TaxCashBasisJournal")] // One2many
    public virtual ICollection<ResCompany> ResCompanyTaxCashBasisJournal { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("JournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Journal")] // One2many
    public virtual ICollection<SaleOrder> SaleOrder { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("AccountJournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AccountJournal")] // One2many
    public virtual ICollection<StockLandedCost> StockLandedCost { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("AccountJournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AccountJournal")] // One2many
    public virtual ICollection<StockValuationLayerRevaluation> StockValuationLayerRevaluation { get; set; }

    // [Many2one]
    [ForeignKey("SuspenseAccountId")]
    public virtual AccountAccount? SuspenseAccount { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("JournalId")] //Many2many // Hidden
    // [InverseProperty("Journal")] //Many2many // Hidden
    public virtual ICollection<AccountBalanceReport> Account { get; set; }

    // [Many2many] // Normal
    [NotMapped] // Many2many // Peer relationship (AccountAccount) is commented out
    // [ForeignKey("JournalId")] // Many2many // Normal
    // [InverseProperty("Journal")] // Many2many // Normal
    public virtual ICollection<AccountAccount> Account1 { get; set; }

    // [Many2many] // Hidden

    [NotMapped] //Many2many // Hidden // Peer relationship (AccountAccount) is commented out
    // [ForeignKey("AccountJournalId")] //Many2many // Hidden
    // [InverseProperty("AccountJournal")] //Many2many // Hidden
    public virtual ICollection<AccountAccount> AccountAccount { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")] //Many2many // Hidden
    // [InverseProperty("AccountJournal")] //Many2many // Hidden
    public virtual ICollection<AccountAgedTrialBalance> AccountAgedTrialBalance { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")] //Many2many // Hidden
    // [InverseProperty("AccountJournal")] //Many2many // Hidden
    public virtual ICollection<AccountBankbookReport> AccountBankbookReport { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")] //Many2many // Hidden
    // [InverseProperty("AccountJournal")] //Many2many // Hidden
    public virtual ICollection<AccountCashbookReport> AccountCashbookReport { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")] //Many2many // Hidden
    // [InverseProperty("AccountJournal")] //Many2many // Hidden
    public virtual ICollection<AccountCommonAccountReport> AccountCommonAccountReport { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")] //Many2many // Hidden
    // [InverseProperty("AccountJournal")] //Many2many // Hidden
    public virtual ICollection<AccountCommonJournalReport> AccountCommonJournalReport { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")] //Many2many // Hidden
    // [InverseProperty("AccountJournal")] //Many2many // Hidden
    public virtual ICollection<AccountCommonPartnerReport> AccountCommonPartnerReport { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")] //Many2many // Hidden
    // [InverseProperty("AccountJournal")] //Many2many // Hidden
    public virtual ICollection<AccountCommonReport> AccountCommonReport { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")] //Many2many // Hidden
    // [InverseProperty("AccountJournal")] //Many2many // Hidden
    public virtual ICollection<AccountDaybookReport> AccountDaybookReport { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("AccountJournalId")] // Many2many // Normal
    // [InverseProperty("AccountJournal")] // Many2many // Normal
    public virtual ICollection<AccountEdiFormat> AccountEdiFormat { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")] //Many2many // Hidden
    // [InverseProperty("AccountJournal")] //Many2many // Hidden
    public virtual ICollection<AccountJournalGroup> AccountJournalGroup { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("JournalId")] //Many2many // Hidden
    // [InverseProperty("Journal")] //Many2many // Hidden
    public virtual ICollection<AccountReportGeneralLedger> AccountNavigation { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")] //Many2many // Hidden
    // [InverseProperty("AccountJournal")] //Many2many // Hidden
    public virtual ICollection<AccountPrintJournal> AccountPrintJournal { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")] //Many2many // Hidden
    // [InverseProperty("AccountJournal")] //Many2many // Hidden
    public virtual ICollection<AccountReconcileModel> AccountReconcileModel { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")] //Many2many // Hidden
    // [InverseProperty("AccountJournal")] //Many2many // Hidden
    public virtual ICollection<AccountReportPartnerLedger> AccountReportPartnerLedger { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")] //Many2many // Hidden
    // [InverseProperty("AccountJournal")] //Many2many // Hidden
    public virtual ICollection<AccountTaxReportWizard> AccountTaxReportWizard { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")] //Many2many // Hidden
    // [InverseProperty("AccountJournal")] //Many2many // Hidden
    public virtual ICollection<AccountingReport> AccountingReport { get; set; }
}
