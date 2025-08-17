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

[Table("account_account_template")]
public partial class AccountAccountTemplate: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("chart_template_id")]
    public Guid? ChartTemplateId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

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
    [ForeignKey("AccountJournalEarlyPayDiscountGainAccountId")]
    [InverseProperty("AccountJournalEarlyPayDiscountGainAccount")]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateAccountJournalEarlyPayDiscountGainAccount { get; set; }

    // [One2many]
    [ForeignKey("AccountJournalEarlyPayDiscountLossAccountId")]
    [InverseProperty("AccountJournalEarlyPayDiscountLossAccount")]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateAccountJournalEarlyPayDiscountLossAccount { get; set; }

    // [One2many]
    [ForeignKey("AccountJournalPaymentCreditAccountId")]
    [InverseProperty("AccountJournalPaymentCreditAccount")]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateAccountJournalPaymentCreditAccount { get; set; }

    // [One2many]
    [ForeignKey("AccountJournalPaymentDebitAccountId")]
    [InverseProperty("AccountJournalPaymentDebitAccount")]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateAccountJournalPaymentDebitAccount { get; set; }

    // [One2many]
    [ForeignKey("AccountJournalSuspenseAccountId")]
    [InverseProperty("AccountJournalSuspenseAccount")]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateAccountJournalSuspenseAccount { get; set; }

    // [One2many]
    [ForeignKey("DefaultCashDifferenceExpenseAccountId")]
    [InverseProperty("DefaultCashDifferenceExpenseAccount")]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateDefaultCashDifferenceExpenseAccount { get; set; }

    // [One2many]
    [ForeignKey("DefaultCashDifferenceIncomeAccountId")]
    [InverseProperty("DefaultCashDifferenceIncomeAccount")]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateDefaultCashDifferenceIncomeAccount { get; set; }

    // [One2many]
    [ForeignKey("DefaultPosReceivableAccountId")]
    [InverseProperty("DefaultPosReceivableAccount")]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateDefaultPosReceivableAccount { get; set; }

    // [One2many]
    [ForeignKey("ExpenseCurrencyExchangeAccountId")]
    [InverseProperty("ExpenseCurrencyExchangeAccount")]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateExpenseCurrencyExchangeAccount { get; set; }

    // [One2many]
    [ForeignKey("IncomeCurrencyExchangeAccountId")]
    [InverseProperty("IncomeCurrencyExchangeAccount")]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateIncomeCurrencyExchangeAccount { get; set; }

    // [One2many]
    [ForeignKey("PropertyAccountExpenseId")]
    [InverseProperty("PropertyAccountExpense")]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyAccountExpense { get; set; }

    // [One2many]
    [ForeignKey("PropertyAccountExpenseCategId")]
    [InverseProperty("PropertyAccountExpenseCateg")]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyAccountExpenseCateg { get; set; }

    // [One2many]
    [ForeignKey("PropertyAccountIncomeId")]
    [InverseProperty("PropertyAccountIncome")]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyAccountIncome { get; set; }

    // [One2many]
    [ForeignKey("PropertyAccountIncomeCategId")]
    [InverseProperty("PropertyAccountIncomeCateg")]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyAccountIncomeCateg { get; set; }

    // [One2many]
    [ForeignKey("PropertyAccountPayableId")]
    [InverseProperty("PropertyAccountPayable")]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyAccountPayable { get; set; }

    // [One2many]
    [ForeignKey("PropertyAccountReceivableId")]
    [InverseProperty("PropertyAccountReceivable")]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyAccountReceivable { get; set; }

    // [One2many]
    [ForeignKey("PropertyAdvanceTaxPaymentAccountId")]
    [InverseProperty("PropertyAdvanceTaxPaymentAccount")]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyAdvanceTaxPaymentAccount { get; set; }

    // [One2many]
    [ForeignKey("PropertyCashBasisBaseAccountId")]
    [InverseProperty("PropertyCashBasisBaseAccount")]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyCashBasisBaseAccount { get; set; }

    // [One2many]
    [ForeignKey("PropertyStockAccountInputCategId")]
    [InverseProperty("PropertyStockAccountInputCateg")]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyStockAccountInputCateg { get; set; }

    // [One2many]
    [ForeignKey("PropertyStockAccountOutputCategId")]
    [InverseProperty("PropertyStockAccountOutputCateg")]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyStockAccountOutputCateg { get; set; }

    // [One2many]
    [ForeignKey("PropertyStockValuationAccountId")]
    [InverseProperty("PropertyStockValuationAccount")]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyStockValuationAccount { get; set; }

    // [One2many]
    [ForeignKey("PropertyTaxPayableAccountId")]
    [InverseProperty("PropertyTaxPayableAccount")]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyTaxPayableAccount { get; set; }

    // [One2many]
    [ForeignKey("PropertyTaxReceivableAccountId")]
    [InverseProperty("PropertyTaxReceivableAccount")]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyTaxReceivableAccount { get; set; }

    // [One2many]
    [ForeignKey("AccountDestId")]
    [InverseProperty("AccountDest")]
    public virtual ICollection<AccountFiscalPositionAccountTemplate> AccountFiscalPositionAccountTemplateAccountDest { get; set; }

    // [One2many]
    [ForeignKey("AccountSrcId")]
    [InverseProperty("AccountSrc")]
    public virtual ICollection<AccountFiscalPositionAccountTemplate> AccountFiscalPositionAccountTemplateAccountSrc { get; set; }

    // [One2many]
    [ForeignKey("AccountId")]
    [InverseProperty("Account")]
    public virtual ICollection<AccountReconcileModelLineTemplate> AccountReconcileModelLineTemplate { get; set; }

    // [One2many]
    [ForeignKey("AccountId")]
    [InverseProperty("Account")]
    public virtual ICollection<AccountTaxRepartitionLineTemplate> AccountTaxRepartitionLineTemplate { get; set; }

    // [One2many]
    [ForeignKey("CashBasisTransitionAccountId")]
    [InverseProperty("CashBasisTransitionAccount")]
    public virtual ICollection<AccountTaxTemplate> AccountTaxTemplate { get; set; }

    // [Many2one]
    [ForeignKey("ChartTemplateId")]
    // [InverseProperty("AccountAccountTemplate")] //Many2one
    public virtual AccountChartTemplate? ChartTemplate { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("AccountAccountTemplateCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CurrencyId")]
    // [InverseProperty("AccountAccountTemplate")] //Many2one
    public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("AccountAccountTemplate")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("AccountAccountTemplateWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("AccountAccountTemplateId")] //Many2many
    // [InverseProperty("AccountAccountTemplate")] //Many2many
    public virtual ICollection<AccountAccountTag> AccountAccountTag { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("AccountId")] //Many2many
    // [InverseProperty("Account")] //Many2many
    public virtual ICollection<AccountTaxTemplate> Tax { get; set; }
}
