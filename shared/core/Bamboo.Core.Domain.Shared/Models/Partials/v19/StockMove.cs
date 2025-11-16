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

public partial class StockMove
{
    [Column("packaging_uom_id")]
    public Guid? PackagingUomId { get; set; }

    [Column("inventory_name")]
    public string? InventoryName { get; set; }

    [Column("description_picking_manual")]
    public string? DescriptionPickingManual { get; set; }

    [Column("packaging_uom_qty")]
    public double? PackagingUomQty { get; set; }

    [Column("production_group_id")]
    public Guid? ProductionGroupId { get; set; }

    [Column("account_move_id")]
    public Guid? AccountMoveId { get; set; }

    [Column("value")]
    public decimal? Value { get; set; }

    [Column("is_in")]
    public bool? IsIn { get; set; }

    [Column("is_out")]
    public bool? IsOut { get; set; }

    [Column("is_dropship")]
    public bool? IsDropship { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountMoveId")]
    public virtual AccountMove? AccountMove { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PackagingUomId")]
    public virtual UomUom? PackagingUom { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MoveId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Move")] // One2many
    public virtual ICollection<ProductValue> ProductValue { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductionGroupId")]
    public virtual MrpProductionGroup? ProductionGroup { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("MoveId")] // Many2many // Normal
    // [InverseProperty("Move")] // Many2many // Normal
    public virtual ICollection<StockReference> ReferenceNavigation { get; set; }

}