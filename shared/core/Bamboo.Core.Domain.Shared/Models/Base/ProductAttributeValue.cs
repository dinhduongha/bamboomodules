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

[Table("product_attribute_value")]
//[Index("AttributeId", Name = "product_attribute_value_attribute_id_index")]
//[Index("Sequence", Name = "product_attribute_value_sequence_index")]
//[Index("Name", "AttributeId", Name = "product_attribute_value_value_company_uniq", IsUnique = true)]
public partial class ProductAttributeValue: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("attribute_id")]
    public long? AttributeId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("html_color")]
    public string? HtmlColor { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("is_custom")]
    public bool? IsCustom { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("AttributeId")]
    //[InverseProperty("ProductAttributeValues")]
    [NotMapped]
    public virtual ProductAttribute? Attribute { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ProductAttributeValueCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ProductAttributeValueWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("ProductAttributeValue")]
    [NotMapped]
    public virtual ICollection<ProductTemplateAttributeValue> ProductTemplateAttributeValues { get; } = new List<ProductTemplateAttributeValue>();

    [ForeignKey("ProductAttributeValueId")]
    //[InverseProperty("ProductAttributeValues")]
    [NotMapped]
    public virtual ICollection<ProductTemplateAttributeLine> ProductTemplateAttributeLines { get; } = new List<ProductTemplateAttributeLine>();
}
