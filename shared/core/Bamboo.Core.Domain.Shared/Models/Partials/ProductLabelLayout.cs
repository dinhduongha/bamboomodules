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

//[Table("product_label_layout")]
public partial class ProductLabelLayout
{
    [Column("picking_quantity")]
    public string? PickingQuantity { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ProductLabelLayoutId")] // Many2many // Normal
    // [InverseProperty("ProductLabelLayout")] // Many2many // Normal
    public virtual ICollection<StockMoveLine> StockMoveLine { get; set; }
}
