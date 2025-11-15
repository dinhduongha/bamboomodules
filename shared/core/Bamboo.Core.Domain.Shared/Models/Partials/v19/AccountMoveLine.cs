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

public partial class AccountMoveLine
{
    [JsonField] // ExtraTaxData
    [Column("extra_tax_data", TypeName = "jsonb")]
    public JsonElement? ExtraTaxData { get; set; }

    [Column("is_storno")]
    public bool? IsStorno { get; set; }

    [Column("collapse_composition")]
    public bool? CollapseComposition { get; set; }

    [Column("collapse_prices")]
    public bool? CollapsePrices { get; set; }

    [Column("no_followup")]
    public bool? NoFollowup { get; set; }

    [Column("deductible_amount")]
    public double? DeductibleAmount { get; set; }

    [Column("l10n_latam_document_type_id")]
    public Guid? L10nLatamDocumentTypeId { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OutstandingLineId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("OutstandingLine")] // One2many
    public virtual ICollection<L10nLatamCheck> L10nLatamCheck { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("L10nLatamDocumentTypeId")]
    public virtual L10nLatamDocumentType? L10nLatamDocumentType { get; set; }

}