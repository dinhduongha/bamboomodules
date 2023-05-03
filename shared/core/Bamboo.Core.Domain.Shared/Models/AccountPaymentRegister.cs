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

[Table("account_payment_register")]
public partial class AccountPaymentRegister: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("currency_id")]
    public long? CurrencyId { get; set; }

    [Column("journal_id")]
    public Guid? JournalId { get; set; }

    [Column("partner_bank_id")]
    public Guid? PartnerBankId { get; set; }

    [Column("source_currency_id")]
    public long? SourceCurrencyId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("payment_method_line_id")]
    public Guid? PaymentMethodLineId { get; set; }

    [Column("writeoff_account_id")]
    public Guid? WriteoffAccountId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("communication")]
    public string? Communication { get; set; }

    [Column("payment_type")]
    public string? PaymentType { get; set; }

    [Column("partner_type")]
    public string? PartnerType { get; set; }

    [Column("payment_difference_handling")]
    public string? PaymentDifferenceHandling { get; set; }

    [Column("writeoff_label")]
    public string? WriteoffLabel { get; set; }

    [Column("payment_date")]
    public DateTime? PaymentDate { get; set; }

    [Column("amount")]
    public decimal? Amount { get; set; }

    [Column("source_amount")]
    public decimal? SourceAmount { get; set; }

    [Column("source_amount_currency")]
    public decimal? SourceAmountCurrency { get; set; }

    [Column("group_payment")]
    public bool? GroupPayment { get; set; }

    [Column("can_edit_wizard")]
    public bool? CanEditWizard { get; set; }

    [Column("can_group_payments")]
    public bool? CanGroupPayments { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("payment_token_id")]
    public Guid? PaymentTokenId { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("AccountPaymentRegisters")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountPaymentRegisterCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CurrencyId")]
    //[InverseProperty("AccountPaymentRegisterCurrencies")]
    [NotMapped]
    public virtual ResCurrency? Currency { get; set; }

    [ForeignKey("JournalId")]
    //[InverseProperty("AccountPaymentRegisters")]
    [NotMapped]
    public virtual AccountJournal? Journal { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("AccountPaymentRegisters")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("PartnerBankId")]
    //[InverseProperty("AccountPaymentRegisters")]
    [NotMapped]
    public virtual ResPartnerBank? PartnerBank { get; set; }

    [ForeignKey("PaymentMethodLineId")]
    //[InverseProperty("AccountPaymentRegisters")]
    [NotMapped]
    public virtual AccountPaymentMethodLine? PaymentMethodLine { get; set; }

    [ForeignKey("PaymentTokenId")]
    //[InverseProperty("AccountPaymentRegisters")]
    [NotMapped]
    public virtual PaymentToken? PaymentToken { get; set; }

    [ForeignKey("SourceCurrencyId")]
    //[InverseProperty("AccountPaymentRegisterSourceCurrencies")]
    [NotMapped]
    public virtual ResCurrency? SourceCurrency { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountPaymentRegisterWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("WriteoffAccountId")]
    //[InverseProperty("AccountPaymentRegisters")]
    [NotMapped]
    public virtual AccountAccount? WriteoffAccount { get; set; }

    [ForeignKey("WizardId")]
    //[InverseProperty("Wizards")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> Lines { get; } = new List<AccountMoveLine>();
}
