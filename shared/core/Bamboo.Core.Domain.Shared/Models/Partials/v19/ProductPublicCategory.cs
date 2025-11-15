using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

public partial class ProductPublicCategory
{
    [Column("is_seo_optimized")]
    public bool? IsSeoOptimized { get; set; }

    [Column("show_category_title")]
    public bool? ShowCategoryTitle { get; set; }

    [Column("show_category_description")]
    public bool? ShowCategoryDescription { get; set; }

    [Column("align_category_content")]
    public bool? AlignCategoryContent { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductPublicCategoryId")] //Many2many // Hidden
    // [InverseProperty("ProductPublicCategory")] //Many2many // Hidden
    public virtual ICollection<ProductFeed> ProductFeed { get; set; }


}