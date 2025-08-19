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

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

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

    [Column("sale_activity_type_id")]
    public Guid? SaleActivityTypeId { get; set; }

    [Column("sale_activity_user_id")]
    public Guid? SaleActivityUserId { get; set; }

    // [Column("alias_id")]
    // public Guid? AliasId { get; set; }

    [Column("secure_sequence_id")]
    public Guid? SecureSequenceId { get; set; }

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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("debit_sequence")]
    public bool? DebitSequence { get; set; }

    [Column("is_peppol_journal")]
    public bool? IsPeppolJournal { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("JournalId")]
    // [InverseProperty("Journal")]
    public virtual ICollection<AccountAccruedOrdersWizard> AccountAccruedOrdersWizard { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("JournalId")]
    // [InverseProperty("Journal")]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLine { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("JournalId")]
    // [InverseProperty("Journal")]
    public virtual ICollection<AccountAssetCategory> AccountAssetCategory { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("JournalId")]
    // [InverseProperty("Journal")]
    public virtual ICollection<AccountBankStatement> AccountBankStatement { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("JournalId")]
    // [InverseProperty("Journal")]
    public virtual ICollection<AccountBankStatementLine> AccountBankStatementLine { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("JournalId")]
    // [InverseProperty("Journal")]
    public virtual ICollection<AccountBankStatementImportJournalCreation> AccountBankStatementImportJournalCreation { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("JournalId")]
    // [InverseProperty("Journal")]
    public virtual ICollection<AccountDebitNote> AccountDebitNote { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("JournalId")]
    // [InverseProperty("Journal")]
    public virtual ICollection<AccountMove> AccountMove { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("JournalId")]
    // [InverseProperty("Journal")]
    public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("JournalId")]
    // [InverseProperty("Journal")]
    public virtual ICollection<AccountMoveReversal> AccountMoveReversal { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("JournalId")]
    // [InverseProperty("Journal")]
    public virtual ICollection<AccountPayment> AccountPayment { get; set; }


    // v16-Compat
    // [One2many]
    // [NotMapped] // [One2many]
    // [ForeignKey("DestinationJournalId")]
    // [InverseProperty("DestinationJournal")]
    // public virtual ICollection<AccountPayment> AccountPayment { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("JournalId")]
    // [InverseProperty("Journal")]
    public virtual ICollection<AccountPaymentMethodLine> AccountPaymentMethodLine { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("JournalId")]
    // [InverseProperty("Journal")]
    public virtual ICollection<AccountPaymentRegister> AccountPaymentRegister { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("JournalId")]
    // [InverseProperty("Journal")]
    public virtual ICollection<AccountReconcileModelLine> AccountReconcileModelLine { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("JournalId")]
    // [InverseProperty("Journal")]
    public virtual ICollection<AccountRecurringTemplate> AccountRecurringTemplate { get; set; }

    // [Many2one]
    [ForeignKey("AliasId")]
    // [InverseProperty("AccountJournal")] //Many2one
    public virtual MailAlias? Alias { get; set; }

    // [Many2one]
    [ForeignKey("BankAccountId")]
    // [InverseProperty("AccountJournal")] //Many2one
    public virtual ResPartnerBank? BankAccount { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("AccountJournal")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("AccountJournalCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CurrencyId")]
    // [InverseProperty("AccountJournal")] //Many2one
    public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    [ForeignKey("DefaultAccountId")]
    // [InverseProperty("AccountJournalDefaultAccount")] //Many2one
    public virtual AccountAccount? DefaultAccount { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("JournalId")]
    // [InverseProperty("Journal")]
    public virtual ICollection<HrContract> HrContract { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("EmployeeJournalId")]
    [InverseProperty("EmployeeJournal")]
    public virtual ICollection<HrExpenseSheet> HrExpenseSheetEmployeeJournal { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("BankJournalId")]
    [InverseProperty("BankJournal")]
    public virtual ICollection<HrExpenseSheet> HrExpenseSheetBankJournal { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("JournalId")]
    [InverseProperty("Journal")]
    public virtual ICollection<HrExpenseSheet> HrExpenseSheetJournal { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("JournalId")]
    // [InverseProperty("Journal")]
    public virtual ICollection<HrPayslip> HrPayslip { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("JournalId")]
    // [InverseProperty("Journal")]
    public virtual ICollection<HrPayslipRun> HrPayslipRun { get; set; }

    // [Many2one]
    [ForeignKey("LossAccountId")]
    // [InverseProperty("AccountJournalLossAccount")] //Many2one
    public virtual AccountAccount? LossAccount { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("AccountJournal")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("JournalId")]
    // [InverseProperty("Journal")]
    public virtual ICollection<MrpAccountWipAccounting> MrpAccountWipAccounting { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("InvoiceJournalId")]
    // [InverseProperty("InvoiceJournal")]
    public virtual ICollection<PosConfig> PosConfigInvoiceJournal { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("JournalId")]
    // [InverseProperty("Journal")]
    public virtual ICollection<PosConfig> PosConfigJournal { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("SaleJournal")]
    // [InverseProperty("SaleJournalNavigation")]
    public virtual ICollection<PosOrder> PosOrder { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("JournalId")]
    // [InverseProperty("Journal")]
    public virtual ICollection<PosPaymentMethod> PosPaymentMethod { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("CashJournalId")]
    // [InverseProperty("CashJournal")]
    public virtual ICollection<PosSession> PosSession { get; set; }

    // [Many2one]
    [ForeignKey("ProfitAccountId")]
    // [InverseProperty("AccountJournalProfitAccount")] //Many2one
    public virtual AccountAccount? ProfitAccount { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("JournalId")]
    // [InverseProperty("Journal")]
    public virtual ICollection<RecurringPaymentLine> RecurringPaymentLine { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("AutomaticEntryDefaultJournalId")]
    [InverseProperty("AutomaticEntryDefaultJournal")]
    public virtual ICollection<ResCompany> ResCompanyAutomaticEntryDefaultJournal { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("CompanyExpenseJournalId")]
    //[InverseProperty("CompanyExpenseJournal")]
    public virtual ICollection<ResCompany> ResCompanyCompanyExpenseJournal { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("CurrencyExchangeJournalId")]
    //[InverseProperty("CurrencyExchangeJournal")]
    public virtual ICollection<ResCompany> ResCompanyCurrencyExchangeJournal { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("ExpenseJournalId")]
    //[InverseProperty("ExpenseJournal")]
    public virtual ICollection<ResCompany> ResCompanyExpenseJournal { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("LcJournalId")]
    //[InverseProperty("LcJournal")]
    public virtual ICollection<ResCompany> ResCompanyLcJournal { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("PeppolPurchaseJournalId")]
    //[InverseProperty("PeppolPurchaseJournal")]
    public virtual ICollection<ResCompany> ResCompanyPeppolPurchaseJournal { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("TaxCashBasisJournalId")]
    //[InverseProperty("TaxCashBasisJournal")]
    public virtual ICollection<ResCompany> ResCompanyTaxCashBasisJournal { get; set; }

    // [Many2one]
    [ForeignKey("SaleActivityTypeId")]
    // [InverseProperty("AccountJournal")] //Many2one
    public virtual MailActivityType? SaleActivityType { get; set; }

    // [Many2one]
    [ForeignKey("SaleActivityUserId")]
    // [InverseProperty("AccountJournalSaleActivityUser")] //Many2one
    public virtual ResUsers? SaleActivityUser { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("JournalId")]
    // [InverseProperty("Journal")]
    public virtual ICollection<SaleOrder> SaleOrder { get; set; }

    // [Many2one]
    [ForeignKey("SecureSequenceId")]
    // [InverseProperty("AccountJournal")] //Many2one
    public virtual IrSequence? SecureSequence { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("AccountJournalId")]
    // [InverseProperty("AccountJournal")]
    public virtual ICollection<StockLandedCost> StockLandedCost { get; set; }

    // [One2many]
    [NotMapped] // [One2many]
    // [ForeignKey("AccountJournalId")]
    // [InverseProperty("AccountJournal")]
    public virtual ICollection<StockValuationLayerRevaluation> StockValuationLayerRevaluation { get; set; }

    // [Many2one]
    [ForeignKey("SuspenseAccountId")]
    // [InverseProperty("AccountJournalSuspenseAccount")] //Many2one
    public virtual AccountAccount? SuspenseAccount { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("AccountJournalWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("JournalId")]
    // [InverseProperty("Journal")]
    public virtual ICollection<AccountBalanceReport> Account { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("JournalId")] //Many2many
    // [InverseProperty("Journal")] //Many2many
    public virtual ICollection<AccountAccount> Account1 { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")]
    // [InverseProperty("AccountJournal")]
    public virtual ICollection<AccountAccount> AccountAccount { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")]
    // [InverseProperty("AccountJournal")]
    public virtual ICollection<AccountAgedTrialBalance> AccountAgedTrialBalance { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")]
    // [InverseProperty("AccountJournal")]
    public virtual ICollection<AccountBankbookReport> AccountBankbookReport { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")]
    // [InverseProperty("AccountJournal")]
    public virtual ICollection<AccountCashbookReport> AccountCashbookReport { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")]
    // [InverseProperty("AccountJournal")]
    public virtual ICollection<AccountCommonAccountReport> AccountCommonAccountReport { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")]
    // [InverseProperty("AccountJournal")]
    public virtual ICollection<AccountCommonJournalReport> AccountCommonJournalReport { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")]
    // [InverseProperty("AccountJournal")]
    public virtual ICollection<AccountCommonPartnerReport> AccountCommonPartnerReport { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")]
    // [InverseProperty("AccountJournal")]
    public virtual ICollection<AccountCommonReport> AccountCommonReport { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")]
    // [InverseProperty("AccountJournal")]
    public virtual ICollection<AccountDaybookReport> AccountDaybookReport { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("AccountJournalId")] //Many2many
    // [InverseProperty("AccountJournal")] //Many2many
    public virtual ICollection<AccountEdiFormat> AccountEdiFormat { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")]
    // [InverseProperty("AccountJournal")]
    public virtual ICollection<AccountJournalGroup> AccountJournalGroup { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("JournalId")]
    // [InverseProperty("Journal")]
    public virtual ICollection<AccountReportGeneralLedger> AccountNavigation { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")]
    // [InverseProperty("AccountJournal")]
    public virtual ICollection<AccountPrintJournal> AccountPrintJournal { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")]
    // [InverseProperty("AccountJournal")]
    public virtual ICollection<AccountReconcileModel> AccountReconcileModel { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")]
    // [InverseProperty("AccountJournal")]
    public virtual ICollection<AccountReconcileModelTemplate> AccountReconcileModelTemplate { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")]
    // [InverseProperty("AccountJournal")]
    public virtual ICollection<AccountReportPartnerLedger> AccountReportPartnerLedger { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")]
    // [InverseProperty("AccountJournal")]
    public virtual ICollection<AccountTaxReportWizard> AccountTaxReportWizard { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")]
    // [InverseProperty("AccountJournal")]
    public virtual ICollection<AccountingReport> AccountingReport { get; set; }
}
