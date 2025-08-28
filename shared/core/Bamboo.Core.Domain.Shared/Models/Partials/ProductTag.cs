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

//[Table("product_tag")]
//[Index("WebsiteId", Name = "product_tag__website_id_index")]
//[Index("Name", Name = "product_tag_name_uniq", IsUnique = true)]
public partial class ProductTag
{
    [Column("ribbon_id")]
    public Guid? RibbonId { get; set; }

    // [Many2one]
    [ForeignKey("RibbonId")]
    public virtual ProductRibbon? Ribbon { get; set; }
}
