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
public partial class AccountPaymentRegister: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("journal_id")]
    public Guid? JournalId { get; set; }

    [Column("partner_bank_id")]
    public Guid? PartnerBankId { get; set; }

    [Column("custom_user_currency_id")]
    public Guid? CustomUserCurrencyId { get; set; }

    [Column("source_currency_id")]
    public Guid? SourceCurrencyId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("payment_method_line_id")]
    public Guid? PaymentMethodLineId { get; set; }

    [Column("writeoff_account_id")]
    public Guid? WriteoffAccountId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("communication")]
    public string? Communication { get; set; }

    [Column("installments_mode")]
    public string? InstallmentsMode { get; set; }

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

    [Column("custom_user_amount")]
    public decimal? CustomUserAmount { get; set; }

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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("payment_token_id")]
    public Guid? PaymentTokenId { get; set; }

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
    [ForeignKey("CustomUserCurrencyId")]
    public virtual ResCurrency? CustomUserCurrency { get; set; }

    // [Many2one]
    [ForeignKey("JournalId")]
    public virtual AccountJournal? Journal { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("PartnerBankId")]
    public virtual ResPartnerBank? PartnerBank { get; set; }

    // [Many2one]
    [ForeignKey("PaymentMethodLineId")]
    public virtual AccountPaymentMethodLine? PaymentMethodLine { get; set; }

    // [Many2one]
    [ForeignKey("PaymentTokenId")]
    public virtual PaymentToken? PaymentToken { get; set; }

    // [Many2one]
    [ForeignKey("SourceCurrencyId")]
    public virtual ResCurrency? SourceCurrency { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2one]
    [ForeignKey("WriteoffAccountId")]
    public virtual AccountAccount? WriteoffAccount { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("WizardId")] // Many2many // Normal
    // [InverseProperty("Wizard")] // Many2many // Normal
    public virtual ICollection<AccountMoveLine> Line { get; set; }
}
