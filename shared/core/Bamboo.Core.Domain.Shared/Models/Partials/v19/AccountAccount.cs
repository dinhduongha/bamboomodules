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

public partial class AccountAccount
{
    [JsonField(IsSparse = false)] // Description
    [Column("description", TypeName = "jsonb")]
    public StringDictionary? Description { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("account_stock_variation_id")]
    public Guid? AccountStockVariationId { get; set; }

    [Column("account_stock_expense_id")]
    public Guid? AccountStockExpenseId { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("NonDeductibleAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("NonDeductibleAccount")] // One2many // Peer relationship (AccountJournal) is commented out
    // public virtual ICollection<AccountJournal> AccountJournalNonDeductibleAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Account")] // One2many // Peer relationship (AccountPaymentRegisterWithholdingLine) is commented out
    // public virtual ICollection<AccountPaymentRegisterWithholdingLine> AccountPaymentRegisterWithholdingLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("WithholdingOutstandingAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WithholdingOutstandingAccount")] // One2many // Peer relationship (AccountPaymentRegister) is commented out
    // public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisterWithholdingOutstandingAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("WriteoffAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteoffAccount")] // One2many // Peer relationship (AccountPaymentRegister) is commented out
    // public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisterWriteoffAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Account")] // One2many // Peer relationship (AccountPaymentWithholdingLine) is commented out
    // public virtual ICollection<AccountPaymentWithholdingLine> AccountPaymentWithholdingLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountStockExpenseId")]
    public virtual AccountAccount? AccountStockExpense { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountStockVariationId")]
    public virtual AccountAccount? AccountStockVariation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountStockExpenseId")]
    // [NotMapped] // One2many 
    // [InverseProperty("AccountStockExpense")] // One2many
    // public virtual ICollection<AccountAccount> InverseAccountStockExpense { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountStockVariationId")]
    // [NotMapped] // One2many 
    // [InverseProperty("AccountStockVariation")] // One2many
    // public virtual ICollection<AccountAccount> InverseAccountStockVariation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountStockValuationId")]
    // [NotMapped] // One2many 
    // [InverseProperty("AccountStockValuation")] // One2many
    // public virtual ICollection<ResCompany> ResCompanyAccountStockValuation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("DownpaymentAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("DownpaymentAccount")] // One2many
    // public virtual ICollection<ResCompany> ResCompanyDownpaymentAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("ExpenseAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ExpenseAccount")] // One2many
    // public virtual ICollection<ResCompany> ResCompanyExpenseAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("IncomeAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("IncomeAccount")] // One2many
    // public virtual ICollection<ResCompany> ResCompanyIncomeAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("PriceDifferenceAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("PriceDifferenceAccount")] // One2many
    // public virtual ICollection<ResCompany> ResCompanyPriceDifferenceAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("WithholdingTaxBaseAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WithholdingTaxBaseAccount")] // One2many
    // public virtual ICollection<ResCompany> ResCompanyWithholdingTaxBaseAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("ValuationAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ValuationAccount")] // One2many // Peer relationship (StockLocation) is commented out
    // public virtual ICollection<StockLocation> StockLocation { get; set; }

}