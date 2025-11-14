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

//[Table("account_payment")]
//[Index("MoveId", Name = "account_payment__move_id_index")]
public partial class AccountPayment
{

    [Column("destination_journal_id")]
    public Guid? DestinationJournalId { get; set; }

    [Column("is_internal_transfer")]
    public bool? IsInternalTransfer { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PaymentId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Payment")] // One2many
    // public virtual ICollection<AccountMove> AccountMove { get; set; }

    // [Many2one]
    [ForeignKey("DestinationJournalId")]
    public virtual AccountJournal? DestinationJournal { get; set; }
}
