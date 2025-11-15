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

public partial class PurchaseOrder
{
    [Column("reminder_date_before_receipt")]
    public long? ReminderDateBeforeReceipt { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("locked")]
    public bool? Locked { get; set; }

    [Column("acknowledged")]
    public bool? Acknowledged { get; set; }

    [Column("receipt_reminder_email")]
    public bool? ReceiptReminderEmail { get; set; }


    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("PurchaseId")] // Many2many // Normal
    // [InverseProperty("Purchase")] // Many2many // Normal
    public virtual ICollection<StockReference> Reference { get; set; }

}