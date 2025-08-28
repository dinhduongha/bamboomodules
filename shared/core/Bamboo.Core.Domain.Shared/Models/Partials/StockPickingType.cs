using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("stock_picking_type")]
//[Index("CompanyId", Name = "stock_picking_type__company_id_index")]
public partial class StockPickingType
{
    [Column("show_reserved")]
    public bool? ShowReserved { get; set; }

    [Column("use_auto_consume_components_lots")]
    public bool? UseAutoConsumeComponentsLots { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ReturnTypeId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("ReturnType")] // One2many
    public virtual ICollection<StockWarehouse> StockWarehouseReturnType { get; set; }
}
