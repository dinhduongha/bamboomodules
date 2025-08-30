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

//[Table("delivery_carrier")]
//[Index("IsPublished", Name = "delivery_carrier__is_published_index")]
//[Index("WebsiteId", Name = "delivery_carrier__website_id_index")]
public partial class DeliveryCarrier
{
    [Column("warehouse_id")]
    public Guid? WarehouseId { get; set; }

    // [Many2one]
    [ForeignKey("WarehouseId")]
    public virtual StockWarehouse? Warehouse { get; set; }
}
