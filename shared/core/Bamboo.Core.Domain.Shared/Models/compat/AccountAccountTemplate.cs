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

[Table("account_account_template")]
public partial class AccountAccountTemplate : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("chart_template_id")]
    public Guid? ChartTemplateId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [JsonField(IsSparse = false)] // Name
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("account_type")]
    public string? AccountType { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("reconcile")]
    public bool? Reconcile { get; set; }

    [Column("nocreate")]
    public bool? Nocreate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AccountJournalEarlyPayDiscountGainAccountId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AccountJournalEarlyPayDiscountGainAccount")] // One2many
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateAccountJournalEarlyPayDiscountGainAccount { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AccountJournalEarlyPayDiscountLossAccountId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AccountJournalEarlyPayDiscountLossAccount")] // One2many
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateAccountJournalEarlyPayDiscountLossAccount { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AccountJournalPaymentCreditAccountId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AccountJournalPaymentCreditAccount")] // One2many
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateAccountJournalPaymentCreditAccount { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AccountJournalPaymentDebitAccountId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AccountJournalPaymentDebitAccount")] // One2many
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateAccountJournalPaymentDebitAccount { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AccountJournalSuspenseAccountId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AccountJournalSuspenseAccount")] // One2many
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateAccountJournalSuspenseAccount { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DefaultCashDifferenceExpenseAccountId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("DefaultCashDifferenceExpenseAccount")] // One2many
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateDefaultCashDifferenceExpenseAccount { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DefaultCashDifferenceIncomeAccountId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("DefaultCashDifferenceIncomeAccount")] // One2many
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateDefaultCashDifferenceIncomeAccount { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DefaultPosReceivableAccountId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("DefaultPosReceivableAccount")] // One2many
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateDefaultPosReceivableAccount { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ExpenseCurrencyExchangeAccountId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ExpenseCurrencyExchangeAccount")] // One2many
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateExpenseCurrencyExchangeAccount { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("IncomeCurrencyExchangeAccountId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("IncomeCurrencyExchangeAccount")] // One2many
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateIncomeCurrencyExchangeAccount { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PropertyAccountExpenseId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PropertyAccountExpense")] // One2many
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyAccountExpense { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PropertyAccountExpenseCategId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PropertyAccountExpenseCateg")] // One2many
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyAccountExpenseCateg { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PropertyAccountIncomeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PropertyAccountIncome")] // One2many
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyAccountIncome { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PropertyAccountIncomeCategId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PropertyAccountIncomeCateg")] // One2many
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyAccountIncomeCateg { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PropertyAccountPayableId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PropertyAccountPayable")] // One2many
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyAccountPayable { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PropertyAccountReceivableId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PropertyAccountReceivable")] // One2many
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyAccountReceivable { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PropertyAdvanceTaxPaymentAccountId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PropertyAdvanceTaxPaymentAccount")] // One2many
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyAdvanceTaxPaymentAccount { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PropertyCashBasisBaseAccountId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PropertyCashBasisBaseAccount")] // One2many
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyCashBasisBaseAccount { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PropertyStockAccountInputCategId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PropertyStockAccountInputCateg")] // One2many
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyStockAccountInputCateg { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PropertyStockAccountOutputCategId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PropertyStockAccountOutputCateg")] // One2many
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyStockAccountOutputCateg { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PropertyStockValuationAccountId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PropertyStockValuationAccount")] // One2many
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyStockValuationAccount { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PropertyTaxPayableAccountId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PropertyTaxPayableAccount")] // One2many
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyTaxPayableAccount { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PropertyTaxReceivableAccountId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PropertyTaxReceivableAccount")] // One2many
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyTaxReceivableAccount { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AccountDestId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AccountDest")] // One2many
    public virtual ICollection<AccountFiscalPositionAccountTemplate> AccountFiscalPositionAccountTemplateAccountDest { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AccountSrcId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AccountSrc")] // One2many
    public virtual ICollection<AccountFiscalPositionAccountTemplate> AccountFiscalPositionAccountTemplateAccountSrc { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AccountId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Account")] // One2many
    public virtual ICollection<AccountReconcileModelLineTemplate> AccountReconcileModelLineTemplate { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AccountId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Account")] // One2many
    public virtual ICollection<AccountTaxRepartitionLineTemplate> AccountTaxRepartitionLineTemplate { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CashBasisTransitionAccountId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("CashBasisTransitionAccount")] // One2many
    public virtual ICollection<AccountTaxTemplate> AccountTaxTemplate { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ChartTemplateId")]
    public virtual AccountChartTemplate? ChartTemplate { get; set; }

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
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("AccountAccountTemplateId")] // Many2many // Normal
    // [InverseProperty("AccountAccountTemplate")] // Many2many // Normal
    public virtual ICollection<AccountAccountTag> AccountAccountTag { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("AccountId")] // Many2many // Normal
    // [InverseProperty("Account")] // Many2many // Normal
    public virtual ICollection<AccountTaxTemplate> Tax { get; set; }
}
