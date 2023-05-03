using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Table("product_tag")]
//[Index("Name", Name = "product_tag_name_uniq", IsUnique = true)]
//[Index("WebsiteId", Name = "product_tag_website_id_index")]
public partial class ProductTag: Entity<long>, IEntityDto<long>
{
    [Key]
    [Column("id")]
    public long Id { get => base.Id; set => base.Id = value; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("ribbon_id")]
    public Guid? RibbonId { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ProductTagCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("RibbonId")]
    //[InverseProperty("ProductTags")]
    [NotMapped]
    public virtual ProductRibbon? Ribbon { get; set; }

    [ForeignKey("WebsiteId")]
    //[InverseProperty("ProductTags")]
    [NotMapped]
    public virtual Website? Website { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ProductTagWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("ProductTagId")]
    //[InverseProperty("ProductTags")]
    [NotMapped]
    public virtual ICollection<ProductProduct> ProductProducts { get; } = new List<ProductProduct>();

    [ForeignKey("ProductTagId")]
    //[InverseProperty("ProductTags")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> ProductTemplates { get; } = new List<ProductTemplate>();
}
