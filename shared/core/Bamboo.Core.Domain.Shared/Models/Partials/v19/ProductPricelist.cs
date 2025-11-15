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

public partial class ProductPricelist
{
    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PricelistId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Pricelist")] // One2many
    public virtual ICollection<PosPreset> PosPreset { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PricelistId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Pricelist")] // One2many
    public virtual ICollection<ProductFeed> ProductFeed { get; set; }


    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DefaultPricelistId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("DefaultPricelist")] // One2many
    public virtual ICollection<ResPartnerGrade> ResPartnerGrade { get; set; }


}