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
public partial class ResCurrency: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("symbol")]
    public string? Symbol { get; set; }

    [Column("iso_numeric")]
    public long? IsoNumeric { get; set; }

    [Column("decimal_places")]
    public long? DecimalPlaces { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("full_name")]
    public string? FullName { get; set; }

    [Column("position")]
    public string? Position { get; set; }

    // v16-Compat
    //[Column("currency_unit_label")]
    //public string? CurrencyUnitLabel { get; set; }

    [JsonField]
    [Column("currency_unit_label", TypeName = "jsonb")]
    public string? CurrencyUnitLabel { get; set; }

    // v16-Compat
    //[Column("currency_subunit_label")]
    //public string? CurrencySubunitLabel { get; set; }

    [JsonField]
    [Column("currency_subunit_label", TypeName = "jsonb")]
    public string? CurrencySubunitLabel { get; set; }

    [Column("rounding")]
    public decimal? Rounding { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<AccountAccount> AccountAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<AccountAccountTemplate> AccountAccountTemplate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<AccountAccruedOrdersWizard> AccountAccruedOrdersWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<AccountAnalyticLine> AccountAnalyticLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<AccountAssetAsset> AccountAssetAsset { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<AccountBankStatementLine> AccountBankStatementLineCurrency { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("ForeignCurrencyId")]
    // [InverseProperty("ForeignCurrency")]
    // public virtual ICollection<AccountBankStatementLine> AccountBankStatementLineForeignCurrency { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<AccountChartTemplate> AccountChartTemplate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<AccountJournal> AccountJournal { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<AccountMove> AccountMove { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CompanyCurrencyId")]
    // [InverseProperty("CompanyCurrency")]
    // public virtual ICollection<AccountMoveLine> AccountMoveLineCompanyCurrency { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<AccountMoveLine> AccountMoveLineCurrency { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CreditCurrencyId")]
    // [InverseProperty("CreditCurrency")]
    // public virtual ICollection<AccountPartialReconcile> AccountPartialReconcileCreditCurrency { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("DebitCurrencyId")]
    // [InverseProperty("DebitCurrency")]
    // public virtual ICollection<AccountPartialReconcile> AccountPartialReconcileDebitCurrency { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<AccountPayment> AccountPayment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisterCurrency { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CustomUserCurrencyId")]
    // [InverseProperty("CustomUserCurrency")]
    // public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisterCustomUserCurrency { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("SourceCurrencyId")]
    // [InverseProperty("SourceCurrency")]
    // public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisterSourceCurrency { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<BaseImportTestsModelsComplex> BaseImportTestsModelsComplex { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<BaseImportTestsModelsFloat> BaseImportTestsModelsFloat { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ResCurrencyCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<HrExpense> HrExpense { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<HrExpenseSheet> HrExpenseSheet { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<HrExpenseSplit> HrExpenseSplit { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<LoyaltyProgram> LoyaltyProgram { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<LunchCashmove> LunchCashmove { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<LunchOrder> LunchOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<MailTrackingValue> MailTrackingValue { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<MrpAccountWipAccountingLine> MrpAccountWipAccountingLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<PaymentLinkWizard> PaymentLinkWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<PaymentTransaction> PaymentTransaction { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<ProductPricelist> ProductPricelist { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<ProductPricelistItem> ProductPricelistItem { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<ProductSupplierinfo> ProductSupplierinfo { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<ProjectCreateSaleOrderLine> ProjectCreateSaleOrderLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<ProjectSaleLineEmployeeMap> ProjectSaleLineEmployeeMap { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<PurchaseOrderLine> PurchaseOrderLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<PurchaseRequisition> PurchaseRequisition { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<ResCountry> ResCountry { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<ResCurrencyRate> ResCurrencyRate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<ResPartnerBank> ResPartnerBank { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInv { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<SaleOrder> SaleOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ResCurrencyWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResCurrencyId")]
    // [InverseProperty("ResCurrency")]
    // public virtual ICollection<PaymentMethod> PaymentMethod { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("CurrencyId")]
    // [InverseProperty("Currency")]
    // public virtual ICollection<PaymentProvider> PaymentProvider { get; set; }
}
