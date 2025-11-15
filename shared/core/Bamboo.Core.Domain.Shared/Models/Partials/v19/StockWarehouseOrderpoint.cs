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

public partial class StockWarehouseOrderpoint
{
    [Column("replenishment_uom_id")]
    public Guid? ReplenishmentUomId { get; set; }

    [Column("deadline_date")]
    public DateTime? DeadlineDate { get; set; }

    [Column("qty_to_order_computed")]
    public decimal? QtyToOrderComputed { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ReplenishmentUomId")]
    public virtual UomUom? ReplenishmentUom { get; set; }

}