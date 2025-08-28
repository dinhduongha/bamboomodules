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

//[Table("sale_order_line")]
//[Index("CompanyId", Name = "sale_order_line__company_id_index")]
//[Index("LinkedLineId", Name = "sale_order_line__linked_line_id_index")]
//[Index("OrderId", Name = "sale_order_line__order_id_index")]
//[Index("OrderPartnerId", Name = "sale_order_line__order_partner_id_index")]
//[Index("ProjectId", Name = "sale_order_line__project_id_index")]
//[Index("TaskId", Name = "sale_order_line__task_id_index")]
public partial class SaleOrderLine
{
 
    [Column("price_reduce")]
    public decimal? PriceReduce { get; set; }
}
