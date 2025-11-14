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

//[Table("pos_category")]
//[Index("ParentId", Name = "pos_category__parent_id_index")]
public partial class PosCategory
{
    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("IfaceStartCategId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("IfaceStartCateg")] // One2many
    public virtual ICollection<PosConfig> PosConfigNavigation { get; set; }

    // v16-Compat
    // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PosCategId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PosCateg")] // One2many
    // public virtual ICollection<ProductTemplate> ProductTemplate { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PosIfaceStartCategId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("PosIfaceStartCateg")] // One2many
    public virtual ICollection<ResConfigSettings> ResConfigSettingsNavigation { get; set; }

    // [Many2many] // Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("CategoryId")] //Many2many // Hidden
    // [InverseProperty("Category")] //Many2many // Hidden
    // public virtual ICollection<RestaurantPrinter> Printer { get; set; }
}
