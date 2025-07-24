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
public partial class ProductTag : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("visible_on_ecommerce")]
    public bool? VisibleOnEcommerce { get; set; }

    // v16-Compat
    [Column("ribbon_id")]
    public Guid? RibbonId { get; set; }

    // v16-Compat
    [ForeignKey("TenantId")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ProductTagCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    // v16-Compat
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
    public virtual ICollection<ProductProduct> ProductProducts { get; set; } = new List<ProductProduct>();

    [ForeignKey("ProductTagId")]
    //[InverseProperty("ProductTags")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> ProductTemplates { get; set; } = new List<ProductTemplate>();
}
