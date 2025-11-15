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

public partial class AccountMove
{
    [Column("taxable_supply_date")]
    public DateTime? TaxableSupplyDate { get; set; }

    // [Column("website_id")]
    // public Guid? WebsiteId { get; set; }

    // [Column("debit_origin_id")]
    // public Guid? DebitOriginId { get; set; }

    [Column("l10n_latam_document_type_id")]
    public Guid? L10nLatamDocumentTypeId { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AccountMoveId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AccountMove")] // One2many
    public virtual ICollection<HrExpense> HrExpense { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("L10nLatamDocumentTypeId")]
    public virtual L10nLatamDocumentType? L10nLatamDocumentType { get; set; }

    //CONFLICK
    // // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [One2many] [ForeignKey("AccountMoveId")]
    // // [NotMapped] // One2many // Normal
    // // [InverseProperty("AccountMove")] // One2many
    // public virtual ICollection<StockMove> StockMove { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("MoveId")] // Many2many // Normal
    // [InverseProperty("Move")] // Many2many // Normal
    public virtual ICollection<AccountMove> AdjustingEntryMove { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("AdjustingEntryMoveId")] // Many2many // Normal
    // [InverseProperty("AdjustingEntryMove")] // Many2many // Normal
    public virtual ICollection<AccountMove> Move { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("MoveId")] //Many2many // Hidden
    // [InverseProperty("Move")] //Many2many // Hidden
    public virtual ICollection<MrpProduction> Production { get; set; }

}