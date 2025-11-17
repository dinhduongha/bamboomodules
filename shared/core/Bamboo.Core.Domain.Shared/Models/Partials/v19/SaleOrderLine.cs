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

public partial class SaleOrderLine
{

    [Column("product_uom_id")]
    public Guid? ProductUomId { get; set; }

    [JsonField] // ExtraTaxData
    [Column("extra_tax_data", TypeName = "jsonb")]
    public JsonElement? ExtraTaxData { get; set; }

    [Column("collapse_prices")]
    public bool? CollapsePrices { get; set; }

    [Column("collapse_composition")]
    public bool? CollapseComposition { get; set; }

    [Column("is_optional")]
    public bool? IsOptional { get; set; }

    [Column("event_slot_id")]
    public Guid? EventSlotId { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("EventSlotId")]
    public virtual EventSlot? EventSlot { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SaleOrderLineId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SaleOrderLine")] // One2many
    public virtual ICollection<HrExpense> HrExpense { get; set; }

    // CONFLICK-V19: Name conflick
    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductUomId")]
    public virtual UomUom? ProductUom { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("SaleOrderLineId")] // Many2many // Normal
    // [InverseProperty("SaleOrderLine")] // Many2many // Normal
    public virtual ICollection<StockRoute> StockRoute { get; set; }

}