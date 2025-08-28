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

//[Table("product_pricelist")]
public partial class ProductPricelist
{
    [Column("discount_policy")]
    public string? DiscountPolicy { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("PricelistId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Pricelist")] // One2many
    public virtual ICollection<RepairOrder> RepairOrder { get; set; }
}
