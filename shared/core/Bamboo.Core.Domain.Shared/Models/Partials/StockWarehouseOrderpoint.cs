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

//[Table("stock_warehouse_orderpoint")]
//[Index("CompanyId", Name = "stock_warehouse_orderpoint__company_id_index")]
//[Index("LocationId", Name = "stock_warehouse_orderpoint__location_id_index")]
//[Index("ProductId", "LocationId", "CompanyId", Name = "stock_warehouse_orderpoint_product_location_check", IsUnique = true)]
//[Index("WarehouseId", Name = "stock_warehouse_orderpoint_warehouse_id_index")]
public partial class StockWarehouseOrderpoint
{
    [Column("qty_to_order")]
    public decimal? QtyToOrder { get; set; }
}
