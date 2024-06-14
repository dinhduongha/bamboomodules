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

[Table("res_currency")]
//[Index("Name", Name = "res_currency_unique_name", IsUnique = true)]
public partial class ResCurrency: Entity<long>, IEntityDto<long>
{
    [Key]
    [Column("id")]
    public long Id { get => base.Id; set => base.Id = value; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("symbol")]
    public string? Symbol { get; set; }

    [Column("decimal_places")]
    public long? DecimalPlaces { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("full_name")]
    public string? FullName { get; set; }

    [Column("position")]
    public string? Position { get; set; }

    [Column("currency_unit_label")]
    public string? CurrencyUnitLabel { get; set; }

    [Column("currency_subunit_label")]
    public string? CurrencySubunitLabel { get; set; }

    [Column("rounding")]
    public decimal? Rounding { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

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
    public virtual ICollection<AccountAccountTemplate> AccountAccountTemplates { get; } = new List<AccountAccountTemplate>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountAccount> AccountAccounts { get; } = new List<AccountAccount>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountAccruedOrdersWizard> AccountAccruedOrdersWizards { get; } = new List<AccountAccruedOrdersWizard>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLines { get; } = new List<AccountAnalyticLine>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountAssetAsset> AccountAssetAssets { get; } = new List<AccountAssetAsset>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountBankStatementLine> AccountBankStatementLineCurrencies { get; } = new List<AccountBankStatementLine>();

    //[InverseProperty("ForeignCurrency")]
    [NotMapped]
    public virtual ICollection<AccountBankStatementLine> AccountBankStatementLineForeignCurrencies { get; } = new List<AccountBankStatementLine>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplates { get; } = new List<AccountChartTemplate>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournals { get; } = new List<AccountJournal>();

    //[InverseProperty("CompanyCurrency")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLineCompanyCurrencies { get; } = new List<AccountMoveLine>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLineCurrencies { get; } = new List<AccountMoveLine>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMoves { get; } = new List<AccountMove>();

    //[InverseProperty("CreditCurrency")]
    [NotMapped]
    public virtual ICollection<AccountPartialReconcile> AccountPartialReconcileCreditCurrencies { get; } = new List<AccountPartialReconcile>();

    //[InverseProperty("DebitCurrency")]
    [NotMapped]
    public virtual ICollection<AccountPartialReconcile> AccountPartialReconcileDebitCurrencies { get; } = new List<AccountPartialReconcile>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisterCurrencies { get; } = new List<AccountPaymentRegister>();

    //[InverseProperty("SourceCurrency")]
    [NotMapped]
    public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisterSourceCurrencies { get; } = new List<AccountPaymentRegister>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountPayment> AccountPayments { get; } = new List<AccountPayment>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsComplex> BaseImportTestsModelsComplexes { get; } = new List<BaseImportTestsModelsComplex>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsFloat> BaseImportTestsModelsFloats { get; } = new List<BaseImportTestsModelsFloat>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<HrExpenseSheet> HrExpenseSheets { get; } = new List<HrExpenseSheet>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<HrExpenseSplit> HrExpenseSplits { get; } = new List<HrExpenseSplit>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<HrExpense> HrExpenses { get; } = new List<HrExpense>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<LunchCashmove> LunchCashmoves { get; } = new List<LunchCashmove>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<LunchOrder> LunchOrders { get; } = new List<LunchOrder>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<MailTrackingValue> MailTrackingValues { get; } = new List<MailTrackingValue>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<PaymentLinkWizard> PaymentLinkWizards { get; } = new List<PaymentLinkWizard>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<PaymentTransaction> PaymentTransactions { get; } = new List<PaymentTransaction>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<ProductPricelistItem> ProductPricelistItems { get; } = new List<ProductPricelistItem>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<ProductPricelist> ProductPricelists { get; } = new List<ProductPricelist>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<ProductSupplierinfo> ProductSupplierinfos { get; } = new List<ProductSupplierinfo>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; } = new List<PurchaseOrderLine>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; } = new List<PurchaseOrder>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanies { get; } = new List<ResCompany>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<ResCountry> ResCountries { get; } = new List<ResCountry>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<ResCurrencyRate> ResCurrencyRates { get; } = new List<ResCurrencyRate>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<ResPartnerBank> ResPartnerBanks { get; } = new List<ResPartnerBank>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInvs { get; } = new List<SaleAdvancePaymentInv>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> SaleOrderLines { get; } = new List<SaleOrderLine>();

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrders { get; } = new List<SaleOrder>();

}
