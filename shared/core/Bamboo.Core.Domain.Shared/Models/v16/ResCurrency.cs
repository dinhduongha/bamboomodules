using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bamboo.Core.Domain.Shared.Attributes;
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
    public virtual ICollection<AccountAccountTemplate> AccountAccountTemplates { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountAccount> AccountAccounts { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountAccruedOrdersWizard> AccountAccruedOrdersWizards { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLines { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountAssetAsset> AccountAssetAssets { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountBankStatementLine> AccountBankStatementLineCurrencies { get; set; } 

    //[InverseProperty("ForeignCurrency")]
    [NotMapped]
    public virtual ICollection<AccountBankStatementLine> AccountBankStatementLineForeignCurrencies { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplates { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournals { get; set; } 

    //[InverseProperty("CompanyCurrency")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLineCompanyCurrencies { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLineCurrencies { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMoves { get; set; } 

    //[InverseProperty("CreditCurrency")]
    [NotMapped]
    public virtual ICollection<AccountPartialReconcile> AccountPartialReconcileCreditCurrencies { get; set; } 

    //[InverseProperty("DebitCurrency")]
    [NotMapped]
    public virtual ICollection<AccountPartialReconcile> AccountPartialReconcileDebitCurrencies { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisterCurrencies { get; set; } 

    //[InverseProperty("SourceCurrency")]
    [NotMapped]
    public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisterSourceCurrencies { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<AccountPayment> AccountPayments { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsComplex> BaseImportTestsModelsComplexes { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsFloat> BaseImportTestsModelsFloats { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<HrExpenseSheet> HrExpenseSheets { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<HrExpenseSplit> HrExpenseSplits { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<HrExpense> HrExpenses { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<LunchCashmove> LunchCashmoves { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<LunchOrder> LunchOrders { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<MailTrackingValue> MailTrackingValues { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<PaymentLinkWizard> PaymentLinkWizards { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<PaymentTransaction> PaymentTransactions { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<ProductPricelistItem> ProductPricelistItems { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<ProductPricelist> ProductPricelists { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<ProductSupplierinfo> ProductSupplierinfos { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanies { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<ResCountry> ResCountries { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<ResCurrencyRate> ResCurrencyRates { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<ResPartnerBank> ResPartnerBanks { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInvs { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> SaleOrderLines { get; set; } 

    //[InverseProperty("Currency")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrders { get; set; } 
    
    [ForeignKey("CurrencyId")]
    //[InverseProperty("Currencies")]
    [NotMapped]
    public virtual ICollection<PaymentProvider> PaymentProviders { get; set; } 

}
