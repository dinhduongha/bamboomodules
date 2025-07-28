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
public partial class AccountAccountTemplate : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("chart_template_id")]
    public Guid? ChartTemplateId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [JsonField]
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
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("ChartTemplateId")]
    //[InverseProperty("AccountAccountTemplates")]
    [NotMapped]
    public virtual AccountChartTemplate? ChartTemplate { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountAccountTemplateCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CurrencyId")]
    //[InverseProperty("AccountAccountTemplates")]
    [NotMapped]
    public virtual ResCurrency? Currency { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("AccountAccountTemplates")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountAccountTemplateWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("AccountJournalEarlyPayDiscountGainAccount")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateAccountJournalEarlyPayDiscountGainAccounts { get; set; } 

    //[InverseProperty("AccountJournalEarlyPayDiscountLossAccount")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateAccountJournalEarlyPayDiscountLossAccounts { get; set; } 

    //[InverseProperty("AccountJournalPaymentCreditAccount")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateAccountJournalPaymentCreditAccounts { get; set; } 

    //[InverseProperty("AccountJournalPaymentDebitAccount")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateAccountJournalPaymentDebitAccounts { get; set; } 

    //[InverseProperty("AccountJournalSuspenseAccount")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateAccountJournalSuspenseAccounts { get; set; } 

    //[InverseProperty("DefaultCashDifferenceExpenseAccount")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateDefaultCashDifferenceExpenseAccounts { get; set; } 

    //[InverseProperty("DefaultCashDifferenceIncomeAccount")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateDefaultCashDifferenceIncomeAccounts { get; set; } 

    //[InverseProperty("DefaultPosReceivableAccount")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateDefaultPosReceivableAccounts { get; set; } 

    //[InverseProperty("ExpenseCurrencyExchangeAccount")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateExpenseCurrencyExchangeAccounts { get; set; } 

    //[InverseProperty("IncomeCurrencyExchangeAccount")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateIncomeCurrencyExchangeAccounts { get; set; } 

    //[InverseProperty("PropertyAccountExpenseCateg")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyAccountExpenseCategs { get; set; } 

    //[InverseProperty("PropertyAccountExpense")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyAccountExpenses { get; set; } 

    //[InverseProperty("PropertyAccountIncomeCateg")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyAccountIncomeCategs { get; set; } 

    //[InverseProperty("PropertyAccountIncome")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyAccountIncomes { get; set; } 

    //[InverseProperty("PropertyAccountPayable")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyAccountPayables { get; set; } 

    //[InverseProperty("PropertyAccountReceivable")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyAccountReceivables { get; set; } 

    //[InverseProperty("PropertyAdvanceTaxPaymentAccount")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyAdvanceTaxPaymentAccounts { get; set; } 

    //[InverseProperty("PropertyCashBasisBaseAccount")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyCashBasisBaseAccounts { get; set; } 

    //[InverseProperty("PropertyStockAccountInputCateg")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyStockAccountInputCategs { get; set; } 

    //[InverseProperty("PropertyStockAccountOutputCateg")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyStockAccountOutputCategs { get; set; } 

    //[InverseProperty("PropertyStockValuationAccount")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyStockValuationAccounts { get; set; } 

    //[InverseProperty("PropertyTaxPayableAccount")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyTaxPayableAccounts { get; set; } 

    //[InverseProperty("PropertyTaxReceivableAccount")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplatePropertyTaxReceivableAccounts { get; set; } 

    //[InverseProperty("AccountDest")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionAccountTemplate> AccountFiscalPositionAccountTemplateAccountDests { get; set; } 

    //[InverseProperty("AccountSrc")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionAccountTemplate> AccountFiscalPositionAccountTemplateAccountSrcs { get; set; } 

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelLineTemplate> AccountReconcileModelLineTemplates { get; set; } 

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<AccountTaxRepartitionLineTemplate> AccountTaxRepartitionLineTemplates { get; set; } 

    //[InverseProperty("CashBasisTransitionAccount")]
    [NotMapped]
    public virtual ICollection<AccountTaxTemplate> AccountTaxTemplates { get; set; } 

    [ForeignKey("AccountAccountTemplateId")]
    //[InverseProperty("AccountAccountTemplates")]
    [NotMapped]
    public virtual ICollection<AccountAccountTag> AccountAccountTags { get; set; } 

    [ForeignKey("AccountId")]
    //[InverseProperty("Accounts")]
    [NotMapped]
    public virtual ICollection<AccountTaxTemplate> Taxes { get; set; } 
}
