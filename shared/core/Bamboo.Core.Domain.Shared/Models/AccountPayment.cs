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
public partial class AccountPayment: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("move_id")]
    public Guid? MoveId { get; set; }

    [Column("partner_bank_id")]
    public Guid? PartnerBankId { get; set; }

    [Column("paired_internal_transfer_payment_id")]
    public Guid? PairedInternalTransferPaymentId { get; set; }

    [Column("payment_method_line_id")]
    public Guid? PaymentMethodLineId { get; set; }

    [Column("payment_method_id")]
    public Guid? PaymentMethodId { get; set; }

    [Column("currency_id")]
    public long? CurrencyId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("outstanding_account_id")]
    public Guid? OutstandingAccountId { get; set; }

    [Column("destination_account_id")]
    public Guid? DestinationAccountId { get; set; }

    [Column("destination_journal_id")]
    public Guid? DestinationJournalId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("payment_type")]
    public string? PaymentType { get; set; }

    [Column("partner_type")]
    public string? PartnerType { get; set; }

    [Column("payment_reference")]
    public string? PaymentReference { get; set; }

    [Column("amount")]
    public decimal? Amount { get; set; }

    [Column("amount_company_currency_signed")]
    public decimal? AmountCompanyCurrencySigned { get; set; }

    [Column("is_reconciled")]
    public bool? IsReconciled { get; set; }

    [Column("is_matched")]
    public bool? IsMatched { get; set; }

    [Column("is_internal_transfer")]
    public bool? IsInternalTransfer { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

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

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountPaymentCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CurrencyId")]
    //[InverseProperty("AccountPayments")]
    [NotMapped]
    public virtual ResCurrency? Currency { get; set; }

    [ForeignKey("DestinationAccountId")]
    //[InverseProperty("AccountPaymentDestinationAccounts")]
    [NotMapped]
    public virtual AccountAccount? DestinationAccount { get; set; }

    [ForeignKey("DestinationJournalId")]
    //[InverseProperty("AccountPayments")]
    [NotMapped]
    public virtual AccountJournal? DestinationJournal { get; set; }

    [ForeignKey("ForceOutstandingAccountId")]
    //[InverseProperty("AccountPaymentForceOutstandingAccounts")]
    [NotMapped]
    public virtual AccountAccount? ForceOutstandingAccount { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("AccountPayments")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("MoveId")]
    //[InverseProperty("AccountPayments")]
    [NotMapped]
    public virtual AccountMove? Move { get; set; }

    [ForeignKey("OutstandingAccountId")]
    //[InverseProperty("AccountPaymentOutstandingAccounts")]
    [NotMapped]
    public virtual AccountAccount? OutstandingAccount { get; set; }

    [ForeignKey("PairedInternalTransferPaymentId")]
    //[InverseProperty("InversePairedInternalTransferPayment")]
    [NotMapped]
    public virtual AccountPayment? PairedInternalTransferPayment { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("AccountPayments")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("PartnerBankId")]
    //[InverseProperty("AccountPayments")]
    [NotMapped]
    public virtual ResPartnerBank? PartnerBank { get; set; }

    [ForeignKey("PaymentMethodId")]
    //[InverseProperty("AccountPayments")]
    [NotMapped]
    public virtual AccountPaymentMethod? PaymentMethod { get; set; }

    [ForeignKey("PaymentMethodLineId")]
    //[InverseProperty("AccountPayments")]
    [NotMapped]
    public virtual AccountPaymentMethodLine? PaymentMethodLine { get; set; }

    [ForeignKey("PaymentTokenId")]
    //[InverseProperty("AccountPayments")]
    [NotMapped]
    public virtual PaymentToken? PaymentToken { get; set; }

    [ForeignKey("PaymentTransactionId")]
    //[InverseProperty("AccountPayments")]
    [NotMapped]
    public virtual PaymentTransaction? PaymentTransaction { get; set; }

    [ForeignKey("PosPaymentMethodId")]
    //[InverseProperty("AccountPayments")]
    [NotMapped]
    public virtual PosPaymentMethod? PosPaymentMethod { get; set; }

    [ForeignKey("PosSessionId")]
    //[InverseProperty("AccountPayments")]
    [NotMapped]
    public virtual PosSession? PosSession { get; set; }

    [ForeignKey("SourcePaymentId")]
    //[InverseProperty("InverseSourcePayment")]
    [NotMapped]
    public virtual AccountPayment? SourcePayment { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountPaymentWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Payment")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLines { get; } = new List<AccountMoveLine>();

    //[InverseProperty("Payment")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMoves { get; } = new List<AccountMove>();

    //[InverseProperty("PairedInternalTransferPayment")]
    [NotMapped]
    public virtual ICollection<AccountPayment> InversePairedInternalTransferPayment { get; } = new List<AccountPayment>();

    //[InverseProperty("SourcePayment")]
    [NotMapped]
    public virtual ICollection<AccountPayment> InverseSourcePayment { get; } = new List<AccountPayment>();

    //[InverseProperty("Payment")]
    [NotMapped]
    public virtual ICollection<PaymentRefundWizard> PaymentRefundWizards { get; } = new List<PaymentRefundWizard>();

    //[InverseProperty("Payment")]
    [NotMapped]
    public virtual ICollection<PaymentTransaction> PaymentTransactions { get; } = new List<PaymentTransaction>();

    //[InverseProperty("Payment")]
    [NotMapped]
    public virtual ICollection<RecurringPaymentLine> RecurringPaymentLines { get; } = new List<RecurringPaymentLine>();

    [ForeignKey("AccountPaymentId")]
    //[InverseProperty("AccountPayments")]
    [NotMapped]
    public virtual ICollection<AccountBankStatementLine> AccountBankStatementLines { get; } = new List<AccountBankStatementLine>();
}
