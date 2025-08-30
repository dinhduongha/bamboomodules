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

//[Table("product_pricelist_item")]
//[Index("ComputePrice", Name = "product_pricelist_item__compute_price_index")]
//[Index("PricelistId", Name = "product_pricelist_item__pricelist_id_index")]
public partial class ProductPricelistItem
{
    [Column("active")]
    public bool? Active { get; set; }
}
