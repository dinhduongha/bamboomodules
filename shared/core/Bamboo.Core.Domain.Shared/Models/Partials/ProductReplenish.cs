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

//[Table("product_replenish")]
public partial class ProductReplenish
{
    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ProductReplenishId")] // Many2many // Normal
    // [InverseProperty("ProductReplenish")] // Many2many // Normal
    public virtual ICollection<StockRoute> StockRoute { get; set; }
}
