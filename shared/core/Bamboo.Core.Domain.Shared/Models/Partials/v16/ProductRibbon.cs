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

//[Table("product_ribbon")]
public partial class ProductRibbon
{
    [Column("html_class")]
    public string? HtmlClass { get; set; }

    [JsonField]
    [Column("html", TypeName = "jsonb")]
    public string? Html { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("RibbonId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Ribbon")] // One2many
    public virtual ICollection<ProductTag> ProductTag { get; set; }
}
