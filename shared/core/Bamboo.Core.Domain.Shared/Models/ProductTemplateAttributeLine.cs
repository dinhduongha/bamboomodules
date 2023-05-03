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

[Table("product_template_attribute_line")]
//[Index("AttributeId", Name = "product_template_attribute_line_attribute_id_index")]
//[Index("ProductTmplId", Name = "product_template_attribute_line_product_tmpl_id_index")]
public partial class ProductTemplateAttributeLine: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("product_tmpl_id")]
    public Guid? ProductTmplId { get; set; }

    [Column("attribute_id")]
    public long? AttributeId { get; set; }

    [Column("value_count")]
    public long? ValueCount { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("AttributeId")]
    //[InverseProperty("ProductTemplateAttributeLines")]
    [NotMapped]
    public virtual ProductAttribute? Attribute { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ProductTemplateAttributeLineCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ProductTmplId")]
    //[InverseProperty("ProductTemplateAttributeLines")]
    [NotMapped]
    public virtual ProductTemplate? ProductTmpl { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ProductTemplateAttributeLineWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("AttributeLine")]
    [NotMapped]
    public virtual ICollection<ProductTemplateAttributeValue> ProductTemplateAttributeValues { get; } = new List<ProductTemplateAttributeValue>();

    [ForeignKey("ProductTemplateAttributeLineId")]
    //[InverseProperty("ProductTemplateAttributeLines")]
    [NotMapped]
    public virtual ICollection<ProductAttributeValue> ProductAttributeValues { get; } = new List<ProductAttributeValue>();
}
