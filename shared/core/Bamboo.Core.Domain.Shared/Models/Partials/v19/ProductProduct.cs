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

public partial class ProductProduct
{
    [Column("is_favorite")]
    public bool? IsFavorite { get; set; }

    [Column("is_in_selected_section_of_order")]
    public bool? IsInSelectedSectionOfOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (ProductUom) is commented out
    // public virtual ICollection<ProductUom> ProductUom { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (ProductValue) is commented out
    // public virtual ICollection<ProductValue> ProductValue { get; set; }

    // // [Many2many] // Hidden
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] //Many2many // Hidden
    // // [ForeignKey("DestId")] //Many2many // Hidden
    // // [InverseProperty("DestNavigation")] //Many2many // Hidden
    // public virtual ICollection<ProductTemplate> Src { get; set; }
}