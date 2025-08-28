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

//[Table("stock_warehouse")]
//[Index("Code", "CompanyId", Name = "stock_warehouse_warehouse_code_uniq", IsUnique = true)]
//[Index("Name", "CompanyId", Name = "stock_warehouse_warehouse_name_uniq", IsUnique = true)]
public partial class StockWarehouse
{
    [Column("return_type_id")]
    public Guid? ReturnTypeId { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("WarehouseId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Warehouse")] // One2many
    // public virtual ICollection<DeliveryCarrier> DeliveryCarrier { get; set; }

    // [Many2one]
    [ForeignKey("ReturnTypeId")]
    public virtual StockPickingType? ReturnType { get; set; }
}
