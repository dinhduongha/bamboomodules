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

[Module("base")]
[Table("res_currency")]
//[Index("Name", Name = "res_currency_unique_name", IsUnique = true)]
public partial class ResCurrency : FullAuditedEntity<Guid>, IEntityDto<Guid>, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    //[Column("company_id")]
    //public Guid? TenantId { get; set; }

    [Column("sequence", TypeName = "bigserial")]
    public long? Sequence { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("symbol")]
    public string? Symbol { get; set; }

    [Column("iso_numeric")]
    public long? IsoNumeric { get; set; }

    [Column("decimal_places")]
    public long? DecimalPlaces { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("full_name")]
    public string? FullName { get; set; }

    [Column("position")]
    public string? Position { get; set; }

    // v16-Compat json
    //[Column("currency_unit_label")]
    [JsonField]
    [Column("currency_unit_label", TypeName = "jsonb")]
    public string? CurrencyUnitLabel { get; set; }

    // v16-Compat json
    //[Column("currency_subunit_label")]
    [JsonField]
    [Column("currency_subunit_label", TypeName = "jsonb")]
    public string? CurrencySubunitLabel { get; set; }

    [Column("rounding")]
    public decimal? Rounding { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ResCurrencyCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ResCurrencyWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    /// TODO: DISABLE INVERSE
    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountAccountTemplate> AccountAccountTemplates { get; set; } = new List<AccountAccountTemplate>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountAccount> AccountAccounts { get; set; } = new List<AccountAccount>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountAccruedOrdersWizard> AccountAccruedOrdersWizards { get; set; } = new List<AccountAccruedOrdersWizard>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLines { get; set; } = new List<AccountAnalyticLine>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountAssetAsset> AccountAssetAssets { get; set; } = new List<AccountAssetAsset>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountBankStatementLine> AccountBankStatementLineCurrencies { get; set; } = new List<AccountBankStatementLine>();

    //[InverseProperty("ForeignCurrency")]
    [NotMapped]
    public virtual ICollection<AccountBankStatementLine> AccountBankStatementLineForeignCurrencies { get; set; } = new List<AccountBankStatementLine>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplates { get; set; } = new List<AccountChartTemplate>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournals { get; set; } = new List<AccountJournal>();

    //[InverseProperty("CompanyCurrency")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLineCompanyCurrencies { get; set; } = new List<AccountMoveLine>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLineCurrencies { get; set; } = new List<AccountMoveLine>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMoves { get; set; } = new List<AccountMove>();

    //[InverseProperty("CreditCurrency")]
    [NotMapped]
    public virtual ICollection<AccountPartialReconcile> AccountPartialReconcileCreditCurrencies { get; set; } = new List<AccountPartialReconcile>();

    //[InverseProperty("DebitCurrency")]
    [NotMapped]
    public virtual ICollection<AccountPartialReconcile> AccountPartialReconcileDebitCurrencies { get; set; } = new List<AccountPartialReconcile>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisterCurrencies { get; set; } = new List<AccountPaymentRegister>();

    //[InverseProperty("SourceCurrency")]
    [NotMapped]
    public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisterSourceCurrencies { get; set; } = new List<AccountPaymentRegister>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountPayment> AccountPayments { get; set; } = new List<AccountPayment>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsComplex> BaseImportTestsModelsComplexes { get; set; } = new List<BaseImportTestsModelsComplex>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsFloat> BaseImportTestsModelsFloats { get; set; } = new List<BaseImportTestsModelsFloat>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<HrExpenseSheet> HrExpenseSheets { get; set; } = new List<HrExpenseSheet>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<HrExpenseSplit> HrExpenseSplits { get; set; } = new List<HrExpenseSplit>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<HrExpense> HrExpenses { get; set; } = new List<HrExpense>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<LunchCashmove> LunchCashmoves { get; set; } = new List<LunchCashmove>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<LunchOrder> LunchOrders { get; set; } = new List<LunchOrder>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<MailTrackingValue> MailTrackingValues { get; set; } = new List<MailTrackingValue>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<PaymentLinkWizard> PaymentLinkWizards { get; set; } = new List<PaymentLinkWizard>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<PaymentTransaction> PaymentTransactions { get; set; } = new List<PaymentTransaction>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<ProductPricelistItem> ProductPricelistItems { get; set; } = new List<ProductPricelistItem>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<ProductPricelist> ProductPricelists { get; set; } = new List<ProductPricelist>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<ProductSupplierinfo> ProductSupplierinfos { get; set; } = new List<ProductSupplierinfo>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; } = new List<PurchaseOrderLine>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanies { get; set; } = new List<ResCompany>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<ResCountry> ResCountries { get; set; } = new List<ResCountry>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<ResCurrencyRate> ResCurrencyRates { get; set; } = new List<ResCurrencyRate>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<ResPartnerBank> ResPartnerBanks { get; set; } = new List<ResPartnerBank>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInvs { get; set; } = new List<SaleAdvancePaymentInv>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> SaleOrderLines { get; set; } = new List<SaleOrderLine>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrders { get; set; } = new List<SaleOrder>();
    
    [ForeignKey("CurrencyId")]
    //[InverseProperty("Currencies")]
    [NotMapped]
    public virtual ICollection<PaymentProvider> PaymentProviders { get; set; } = new List<PaymentProvider>();

}
