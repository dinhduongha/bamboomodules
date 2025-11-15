using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

[Table("account_payment")]
//[Index("MoveId", Name = "account_payment__move_id_index")]
//[Index("JournalId", "CompanyId", Name = "account_payment_journal_id_company_id_idx")]
public partial class AccountPayment : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

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
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OriginPaymentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("OriginPayment")] // One2many
    public virtual ICollection<AccountMove> AccountMove { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PaymentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Payment")] // One2many
    public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CurrencyId")]
    public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("DestinationAccountId")]
    public virtual AccountAccount? DestinationAccount { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ForceOutstandingAccountId")]
    public virtual AccountAccount? ForceOutstandingAccount { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PairedInternalTransferPaymentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PairedInternalTransferPayment")] // One2many
    public virtual ICollection<AccountPayment> InversePairedInternalTransferPayment { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SourcePaymentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SourcePayment")] // One2many
    public virtual ICollection<AccountPayment> InverseSourcePayment { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("JournalId")]
    public virtual AccountJournal? Journal { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("MoveId")]
    public virtual AccountMove? Move { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("OutstandingAccountId")]
    public virtual AccountAccount? OutstandingAccount { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PairedInternalTransferPaymentId")]
    public virtual AccountPayment? PairedInternalTransferPayment { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PartnerBankId")]
    public virtual ResPartnerBank? PartnerBank { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PaymentMethodId")]
    public virtual AccountPaymentMethod? PaymentMethod { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PaymentMethodLineId")]
    public virtual AccountPaymentMethodLine? PaymentMethodLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PaymentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Payment")] // One2many
    public virtual ICollection<PaymentRefundWizard> PaymentRefundWizard { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PaymentTokenId")]
    public virtual PaymentToken? PaymentToken { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PaymentTransactionId")]
    public virtual PaymentTransaction? PaymentTransaction { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PaymentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Payment")] // One2many
    public virtual ICollection<PaymentTransaction> PaymentTransactionNavigation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PosOrderId")]
    public virtual PosOrder? PosOrder { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OnlineAccountPaymentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("OnlineAccountPayment")] // One2many
    public virtual ICollection<PosPayment> PosPayment { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PosPaymentMethodId")]
    public virtual PosPaymentMethod? PosPaymentMethod { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PosSessionId")]
    public virtual PosSession? PosSession { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PaymentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Payment")] // One2many
    public virtual ICollection<RecurringPaymentLine> RecurringPaymentLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SourcePaymentId")]
    public virtual AccountPayment? SourcePayment { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountPaymentId")] //Many2many // Hidden
    // [InverseProperty("AccountPayment")] //Many2many // Hidden
    public virtual ICollection<AccountBankStatementLine> AccountBankStatementLine { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("PaymentId")] //Many2many // Hidden
    // [InverseProperty("Payment")] //Many2many // Hidden
    public virtual ICollection<AccountMove> Invoice { get; set; }
}
