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

//[Table("account_move_line")]
//[Index("CompanyId", Name = "account_move_line__company_id_index")]
//[Index("DateMaturity", Name = "account_move_line__date_maturity_index")]
//[Index("JournalId", Name = "account_move_line__journal_id_index")]
//[Index("MoveId", Name = "account_move_line__move_id_index")]
//[Index("MoveName", Name = "account_move_line__move_name_index")]
//[Index("AccountId", Name = "account_move_line_account_id_index")]
//[Index("Date", "MoveName", "Id", Name = "account_move_line_date_name_id_idx", IsDescending = new[] { true, true, false })]
//[Index("PartnerId", "Ref", Name = "account_move_line_partner_id_ref_idx")]
public partial class AccountMoveLine
{

    [Column("account_root_id")]
    public Guid? AccountRootId { get; set; }

    [Column("tax_audit")]
    public string? TaxAudit { get; set; }

    [Column("blocked")]
    public bool? Blocked { get; set; }

    [Column("discount_percentage")]
    public double? DiscountPercentage { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("InvoiceLineId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("InvoiceLine")] // One2many
    public virtual ICollection<RepairFee> RepairFee { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("InvoiceLineId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("InvoiceLine")] // One2many
    public virtual ICollection<RepairLine> RepairLine { get; set; }

}
