using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Index("AccountType", Name = "account_account__account_type_index")]
//[Index("Code", "CompanyId", Name = "account_account_code_company_uniq", IsUnique = true)]
public partial class AccountAccount
{

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("group_id")]
    public Guid? GroupId { get; set; }

    [Column("root_id")]
    public Guid? RootId { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("internal_group")]
    public string? InternalGroup { get; set; }

    [Column("include_initial_balance")]
    public bool? IncludeInitialBalance { get; set; }

    [Column("is_off_balance")]
    public bool? IsOffBalance { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("GroupId")]
    public virtual AccountGroup? Group { get; set; }

    [Many2one("IrAttachment")]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountJournalPaymentCreditAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("AccountJournalPaymentCreditAccount")] // One2many
    // public virtual ICollection<ResCompany> ResCompanyAccountJournalPaymentCreditAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountJournalPaymentDebitAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("AccountJournalPaymentDebitAccount")] // One2many
    // public virtual ICollection<ResCompany> ResCompanyAccountJournalPaymentDebitAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("PropertyStockAccountInputCategId")]
    // [NotMapped] // One2many 
    // [InverseProperty("PropertyStockAccountInputCateg")] // One2many
    // public virtual ICollection<ResCompany> ResCompanyPropertyStockAccountInputCateg { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("PropertyStockAccountOutputCategId")]
    // [NotMapped] // One2many 
    // [InverseProperty("PropertyStockAccountOutputCateg")] // One2many
    // public virtual ICollection<ResCompany> ResCompanyPropertyStockAccountOutputCateg { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("PropertyStockValuationAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("PropertyStockValuationAccount")] // One2many
    // public virtual ICollection<ResCompany> ResCompanyPropertyStockValuationAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("DepositAccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("DepositAccount")] // One2many // Peer relationship (SaleAdvancePaymentInv) is commented out
    // public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInv { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'AccountAccount'
    // [One2many] [ForeignKey("AccountId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Account")] // One2many // Peer relationship (StockLandedCostLines) is commented out
    // public virtual ICollection<StockLandedCostLines> StockLandedCostLines { get; set; }

}
