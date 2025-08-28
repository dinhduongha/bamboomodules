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

    [JsonField]
    [Column("currency_unit_label", TypeName = "jsonb")]
    public string? CurrencyUnitLabel { get; set; }

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
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many
    // public virtual ICollection<AccountAccount> AccountAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (AccountAccruedOrdersWizard) is commented out
    // public virtual ICollection<AccountAccruedOrdersWizard> AccountAccruedOrdersWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (AccountAnalyticLine) is commented out
    // public virtual ICollection<AccountAnalyticLine> AccountAnalyticLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (AccountAssetAsset) is commented out
    // public virtual ICollection<AccountAssetAsset> AccountAssetAsset { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (AccountBankStatementLine) is commented out
    // public virtual ICollection<AccountBankStatementLine> AccountBankStatementLineCurrency { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("ForeignCurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ForeignCurrency")] // One2many // Peer relationship (AccountBankStatementLine) is commented out
    // public virtual ICollection<AccountBankStatementLine> AccountBankStatementLineForeignCurrency { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (AccountJournal) is commented out
    // public virtual ICollection<AccountJournal> AccountJournal { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (AccountMove) is commented out
    // public virtual ICollection<AccountMove> AccountMove { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CompanyCurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CompanyCurrency")] // One2many // Peer relationship (AccountMoveLine) is commented out
    // public virtual ICollection<AccountMoveLine> AccountMoveLineCompanyCurrency { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (AccountMoveLine) is commented out
    // public virtual ICollection<AccountMoveLine> AccountMoveLineCurrency { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CreditCurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreditCurrency")] // One2many // Peer relationship (AccountPartialReconcile) is commented out
    // public virtual ICollection<AccountPartialReconcile> AccountPartialReconcileCreditCurrency { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("DebitCurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("DebitCurrency")] // One2many // Peer relationship (AccountPartialReconcile) is commented out
    // public virtual ICollection<AccountPartialReconcile> AccountPartialReconcileDebitCurrency { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (AccountPayment) is commented out
    // public virtual ICollection<AccountPayment> AccountPayment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (AccountPaymentRegister) is commented out
    // public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisterCurrency { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CustomUserCurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CustomUserCurrency")] // One2many // Peer relationship (AccountPaymentRegister) is commented out
    // public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisterCustomUserCurrency { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("SourceCurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("SourceCurrency")] // One2many // Peer relationship (AccountPaymentRegister) is commented out
    // public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisterSourceCurrency { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (HrExpense) is commented out
    // public virtual ICollection<HrExpense> HrExpense { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (HrExpenseSheet) is commented out
    // public virtual ICollection<HrExpenseSheet> HrExpenseSheet { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (HrExpenseSplit) is commented out
    // public virtual ICollection<HrExpenseSplit> HrExpenseSplit { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (LoyaltyProgram) is commented out
    // public virtual ICollection<LoyaltyProgram> LoyaltyProgram { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (LunchCashmove) is commented out
    // public virtual ICollection<LunchCashmove> LunchCashmove { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (LunchOrder) is commented out
    // public virtual ICollection<LunchOrder> LunchOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (MailTrackingValue) is commented out
    // public virtual ICollection<MailTrackingValue> MailTrackingValue { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (MrpAccountWipAccountingLine) is commented out
    // public virtual ICollection<MrpAccountWipAccountingLine> MrpAccountWipAccountingLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (PaymentLinkWizard) is commented out
    // public virtual ICollection<PaymentLinkWizard> PaymentLinkWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (PaymentTransaction) is commented out
    // public virtual ICollection<PaymentTransaction> PaymentTransaction { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (ProductPricelist) is commented out
    // public virtual ICollection<ProductPricelist> ProductPricelist { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (ProductPricelistItem) is commented out
    // public virtual ICollection<ProductPricelistItem> ProductPricelistItem { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (ProductSupplierinfo) is commented out
    // public virtual ICollection<ProductSupplierinfo> ProductSupplierinfo { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (ProjectSaleLineEmployeeMap) is commented out
    // public virtual ICollection<ProjectSaleLineEmployeeMap> ProjectSaleLineEmployeeMap { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (PurchaseOrder) is commented out
    // public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (PurchaseOrderLine) is commented out
    // public virtual ICollection<PurchaseOrderLine> PurchaseOrderLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (PurchaseRequisition) is commented out
    // public virtual ICollection<PurchaseRequisition> PurchaseRequisition { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many
    // public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many
    // public virtual ICollection<ResCountry> ResCountry { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (ResCurrencyRate) is commented out
    // public virtual ICollection<ResCurrencyRate> ResCurrencyRate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (ResPartnerBank) is commented out
    // public virtual ICollection<ResPartnerBank> ResPartnerBank { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (SaleAdvancePaymentInv) is commented out
    // public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInv { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (SaleOrder) is commented out
    // public virtual ICollection<SaleOrder> SaleOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (SaleOrderLine) is commented out
    // public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResCurrencyId")] //Many2many // Hidden
    // [InverseProperty("ResCurrency")] //Many2many // Hidden
    public virtual ICollection<PaymentMethod> PaymentMethod { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("CurrencyId")] //Many2many // Hidden
    // [InverseProperty("Currency")] //Many2many // Hidden
    public virtual ICollection<PaymentProvider> PaymentProvider { get; set; }
}
