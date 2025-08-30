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

namespace Bamboo.Core.Models;

//[Table("hr_expense_sheet")]
//[Index("State", Name = "hr_expense_sheet__state_index")]
public partial class HrExpenseSheet
{
    [Column("address_id")]
    public Guid? AddressId { get; set; }

    [Column("bank_journal_id")]
    public Guid? BankJournalId { get; set; }

    [Column("account_move_id")]
    public Guid? AccountMoveId { get; set; }

    [Column("total_amount_taxes")]
    public decimal? TotalAmountTaxes { get; set; }

    // [Many2one]
    //[ForeignKey("AccountMoveId")]
    //public virtual AccountMove? AccountMove { get; set; }

    // [Many2one]
    [ForeignKey("AddressId")]
    public virtual ResPartner? Address { get; set; }

    // [Many2one]
    [ForeignKey("BankJournalId")]
    public virtual AccountJournal? BankJournal { get; set; }

    // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("HrExpenseSheetId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("HrExpenseSheet")] // One2many
    // public virtual ICollection<HrExpenseRefuseWizard> HrExpenseRefuseWizard { get; set; }
}
