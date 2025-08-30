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

//[Table("account_move")]
//[Index("CompanyId", Name = "account_move_company_id_index")]
//[Index("Date", Name = "account_move_date_index")]
//[Index("InvoiceDateDue", Name = "account_move_invoice_date_due_index")]
//[Index("InvoiceDate", Name = "account_move_invoice_date_index")]
//[Index("MoveType", Name = "account_move_move_type_index")]
//[Index("PartnerId", Name = "account_move_partner_id_index")]
//[Index("SecureSequenceNumber", Name = "account_move_secure_sequence_number_index")]
//[Index("JournalId", "State", "PaymentState", "MoveType", "Date", Name = "account_move_payment_idx")]
//[Index("JournalId", "SequencePrefix", "SequenceNumber", "Name", Name = "account_move_sequence_index", IsDescending = new[] { false, true, true, false })]
//[Index("JournalId", "Id", "SequencePrefix", Name = "account_move_sequence_index2", IsDescending = new[] { false, true, false })]
public partial class AccountMove
{
    [Column("payment_id")]
    public Guid? PaymentId { get; set; }

    [Column("to_check")]
    public bool? ToCheck { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AccountMoveId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("AccountMove")] // One2many
    public virtual ICollection<HrExpenseSheet> HrExpenseSheet { get; set; }

    // [Many2one]
    // [ForeignKey("PaymentId")]
    // public virtual AccountPayment? Payment { get; set; }

    // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AccountMove")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AccountMoveNavigation")] // One2many
    // public virtual ICollection<PosOrder> PosOrder { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("InvoiceId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Invoice")] // One2many
    public virtual ICollection<RepairOrder> RepairOrder { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountMoveId")] //Many2many // Hidden
    // [InverseProperty("AccountMove")] //Many2many // Hidden
    public virtual ICollection<AccountInvoiceSend> AccountInvoiceSend { get; set; }
}
