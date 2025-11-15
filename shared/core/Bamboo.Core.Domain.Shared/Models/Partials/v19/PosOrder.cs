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

public partial class PosOrder
{
    [Column("preset_id")]
    public Guid? PresetId { get; set; }

    [Column("tracking_number")]
    public string? TrackingNumber { get; set; }

    [Column("source")]
    public string? Source { get; set; }

    [Column("general_customer_note")]
    public string? GeneralCustomerNote { get; set; }

    [Column("internal_note")]
    public string? InternalNote { get; set; }

    [Column("is_refund")]
    public bool? IsRefund { get; set; }

    [Column("preset_time", TypeName = "timestamp without time zone")]
    public DateTime? PresetTime { get; set; }


    [Column("self_ordering_table_id")]
    public Guid? SelfOrderingTableId { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PresetId")]
    public virtual PosPreset? Preset { get; set; }

    // // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("PricelistId")]
    // public virtual ProductPricelist? Pricelist { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OrderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Order")] // One2many
    public virtual ICollection<RestaurantOrderCourse> RestaurantOrderCourse { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SelfOrderingTableId")]
    public virtual RestaurantTable? SelfOrderingTable { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("PosOrderId")] // Many2many // Normal
    // [InverseProperty("PosOrder")] // Many2many // Normal
    public virtual ICollection<StockReference> Reference { get; set; }


}