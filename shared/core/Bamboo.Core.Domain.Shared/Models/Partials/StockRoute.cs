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

//[Table("stock_route")]
//[Index("CompanyId", Name = "stock_route__company_id_index")]
public partial class StockRoute
{
    // [Many2many] // Hidden
    //[NotMapped] //Many2many // Hidden
    // [ForeignKey("StockRouteId")] //Many2many // Hidden
    // [InverseProperty("StockRoute")] //Many2many // Hidden
    //public virtual ICollection<ProductReplenish> ProductReplenish { get; set; }
}
