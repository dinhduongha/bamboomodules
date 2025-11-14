using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;
using System.Text.Json.Serialization;

namespace Bamboo.Core.Models;

//[Table("account_journal")]
//[Index("CompanyId", Name = "account_journal__company_id_index")]
//[Index("CompanyId", "Code", Name = "account_journal_code_company_uniq", IsUnique = true)]
public partial class AccountJournal
{
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("sale_activity_type_id")]
    public Guid? SaleActivityTypeId { get; set; }

    [Column("sale_activity_user_id")]
    public Guid? SaleActivityUserId { get; set; }

    [Column("secure_sequence_id")]
    public Guid? SecureSequenceId { get; set; }

    [Column("sale_activity_note")]
    public string? SaleActivityNote { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("JournalId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Journal")] // One2many
    public virtual ICollection<AccountBankStatementImportJournalCreation> AccountBankStatementImportJournalCreation { get; set; }

    // v16-Compat
    // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DestinationJournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("DestinationJournal")] // One2many
    // public virtual ICollection<AccountPayment> AccountPayment { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("BankJournalId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("BankJournal")] // One2many
    public virtual ICollection<HrExpenseSheet> HrExpenseSheetBankJournal { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CompanyExpenseJournalId")]
    [NotMapped] // One2many // Peer relationship (ResCompany) is commented out
    // [InverseProperty("CompanyExpenseJournal")] // One2many
    public virtual ICollection<ResCompany> ResCompanyCompanyExpenseJournal { get; set; }

    // [Many2one]
    [ForeignKey("SaleActivityTypeId")]
    public virtual MailActivityType? SaleActivityType { get; set; }

    // [Many2one]
    [ForeignKey("SaleActivityUserId")]
    public virtual ResUsers? SaleActivityUser { get; set; }

    // [Many2one]
    [ForeignKey("SecureSequenceId")]
    public virtual IrSequence? SecureSequence { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountJournalId")] //Many2many // Hidden
    // [InverseProperty("AccountJournal")] //Many2many // Hidden
    public virtual ICollection<AccountReconcileModelTemplate> AccountReconcileModelTemplate { get; set; }
}
