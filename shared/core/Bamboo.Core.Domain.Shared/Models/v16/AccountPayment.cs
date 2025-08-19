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

[Table("account_payment")]
//[Index("MoveId", Name = "account_payment__move_id_index")]
//[Index("JournalId", "CompanyId", Name = "account_payment_journal_id_company_id_idx")]
public partial class AccountPayment: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("move_id")]
    public Guid? MoveId { get; set; }

    [Column("journal_id")]
    public Guid? JournalId { get; set; }

    [Column("partner_bank_id")]
    public Guid? PartnerBankId { get; set; }

    [Column("paired_internal_transfer_payment_id")]
    public Guid? PairedInternalTransferPaymentId { get; set; }

    [Column("payment_method_line_id")]
    public Guid? PaymentMethodLineId { get; set; }

    [Column("payment_method_id")]
    public Guid? PaymentMethodId { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("outstanding_account_id")]
    public Guid? OutstandingAccountId { get; set; }

    [Column("destination_account_id")]
    public Guid? DestinationAccountId { get; set; }

    [Column("destination_journal_id")]
    public Guid? DestinationJournalId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("payment_type")]
    public string? PaymentType { get; set; }

    [Column("partner_type")]
    public string? PartnerType { get; set; }

    [Column("memo")]
    public string? Memo { get; set; }

    [Column("payment_reference")]
    public string? PaymentReference { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("amount")]
    public decimal? Amount { get; set; }

    [Column("amount_company_currency_signed")]
    public decimal? AmountCompanyCurrencySigned { get; set; }

    [Column("is_reconciled")]
    public bool? IsReconciled { get; set; }

    [Column("is_matched")]
    public bool? IsMatched { get; set; }

    [Column("is_sent")]
    public bool? IsSent { get; set; }

    [Column("is_internal_transfer")]
    public bool? IsInternalTransfer { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("payment_transaction_id")]
    public Guid? PaymentTransactionId { get; set; }

    [Column("payment_token_id")]
    public Guid? PaymentTokenId { get; set; }

    [Column("source_payment_id")]
    public Guid? SourcePaymentId { get; set; }

    [Column("pos_payment_method_id")]
    public Guid? PosPaymentMethodId { get; set; }

    [Column("force_outstanding_account_id")]
    public Guid? ForceOutstandingAccountId { get; set; }

    [Column("pos_session_id")]
    public Guid? PosSessionId { get; set; }

    [Column("pos_order_id")]
    public Guid? PosOrderId { get; set; }

    // [One2many]
    [ForeignKey("OriginPaymentId")]
    [InverseProperty("OriginPayment")]
    public virtual ICollection<AccountMove> AccountMove { get; set; }

    // v16-Compat
    // [One2many]
    //[ForeignKey("PaymentId")]
    //[InverseProperty("Payment")]
    //public virtual ICollection<AccountMove> AccountMove { get; set; }

    // [One2many]
    [ForeignKey("PaymentId")]
    [InverseProperty("Payment")]
    public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("AccountPayment")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("AccountPaymentCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CurrencyId")]
    // [InverseProperty("AccountPayment")] //Many2one
    public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    [ForeignKey("DestinationAccountId")]
    // [InverseProperty("AccountPaymentDestinationAccount")] //Many2one
    public virtual AccountAccount? DestinationAccount { get; set; }

    // [Many2one]
    [ForeignKey("DestinationJournalId")]
    // [InverseProperty("AccountPayment")] //Many2one
    public virtual AccountJournal? DestinationJournal { get; set; }

    // [Many2one]
    [ForeignKey("ForceOutstandingAccountId")]
    // [InverseProperty("AccountPaymentForceOutstandingAccount")] //Many2one
    public virtual AccountAccount? ForceOutstandingAccount { get; set; }

    // [One2many]
    [ForeignKey("PairedInternalTransferPaymentId")]
    [InverseProperty("PairedInternalTransferPayment")]
    public virtual ICollection<AccountPayment> InversePairedInternalTransferPayment { get; set; }

    // [One2many]
    [ForeignKey("SourcePaymentId")]
    [InverseProperty("SourcePayment")]
    public virtual ICollection<AccountPayment> InverseSourcePayment { get; set; }

    // [Many2one]
    [ForeignKey("JournalId")]
    // [InverseProperty("AccountPayment")] //Many2one
    public virtual AccountJournal? Journal { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("AccountPayment")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("MoveId")]
    // [InverseProperty("AccountPayment")] //Many2one
    public virtual AccountMove? Move { get; set; }

    // [Many2one]
    [ForeignKey("OutstandingAccountId")]
    // [InverseProperty("AccountPaymentOutstandingAccount")] //Many2one
    public virtual AccountAccount? OutstandingAccount { get; set; }

    // [Many2one]
    [ForeignKey("PairedInternalTransferPaymentId")]
    // [InverseProperty("InversePairedInternalTransferPayment")] //Many2one
    public virtual AccountPayment? PairedInternalTransferPayment { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("AccountPayment")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("PartnerBankId")]
    // [InverseProperty("AccountPayment")] //Many2one
    public virtual ResPartnerBank? PartnerBank { get; set; }

    // [Many2one]
    [ForeignKey("PaymentMethodId")]
    // [InverseProperty("AccountPayment")] //Many2one
    public virtual AccountPaymentMethod? PaymentMethod { get; set; }

    // [Many2one]
    [ForeignKey("PaymentMethodLineId")]
    // [InverseProperty("AccountPayment")] //Many2one
    public virtual AccountPaymentMethodLine? PaymentMethodLine { get; set; }

    // [One2many]
    [ForeignKey("PaymentId")]
    [InverseProperty("Payment")]
    public virtual ICollection<PaymentRefundWizard> PaymentRefundWizard { get; set; }

    // [Many2one]
    [ForeignKey("PaymentTokenId")]
    // [InverseProperty("AccountPayment")] //Many2one
    public virtual PaymentToken? PaymentToken { get; set; }

    // [Many2one]
    [ForeignKey("PaymentTransactionId")]
    // [InverseProperty("AccountPayment")] //Many2one
    public virtual PaymentTransaction? PaymentTransaction { get; set; }

    // [One2many]
    [ForeignKey("PaymentId")]
    [InverseProperty("Payment")]
    public virtual ICollection<PaymentTransaction> PaymentTransactionNavigation { get; set; }

    // [Many2one]
    [ForeignKey("PosOrderId")]
    // [InverseProperty("AccountPayment")] //Many2one
    public virtual PosOrder? PosOrder { get; set; }

    // [One2many]
    [ForeignKey("OnlineAccountPaymentId")]
    [InverseProperty("OnlineAccountPayment")]
    public virtual ICollection<PosPayment> PosPayment { get; set; }

    // [Many2one]
    [ForeignKey("PosPaymentMethodId")]
    // [InverseProperty("AccountPayment")] //Many2one
    public virtual PosPaymentMethod? PosPaymentMethod { get; set; }

    // [Many2one]
    [ForeignKey("PosSessionId")]
    // [InverseProperty("AccountPayment")] //Many2one
    public virtual PosSession? PosSession { get; set; }

    // [One2many]
    [ForeignKey("PaymentId")]
    [InverseProperty("Payment")]
    public virtual ICollection<RecurringPaymentLine> RecurringPaymentLine { get; set; }

    // [Many2one]
    [ForeignKey("SourcePaymentId")]
    // [InverseProperty("InverseSourcePayment")] //Many2one
    public virtual AccountPayment? SourcePayment { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("AccountPaymentWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountPaymentId")]
    // [InverseProperty("AccountPayment")]
    public virtual ICollection<AccountBankStatementLine> AccountBankStatementLine { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("PaymentId")]
    // [InverseProperty("Payment")]
    public virtual ICollection<AccountMove> Invoice { get; set; }
}
