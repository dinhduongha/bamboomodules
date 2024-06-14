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

[Table("product_template_attribute_value")]
//[Index("AttributeId", Name = "product_template_attribute_value_attribute_id_index")]
//[Index("AttributeLineId", Name = "product_template_attribute_value_attribute_line_id_index")]
//[Index("AttributeLineId", "ProductAttributeValueId", Name = "product_template_attribute_value_attribute_value_unique", IsUnique = true)]
//[Index("ProductAttributeValueId", Name = "product_template_attribute_value_product_attribute_value_id_ind")]
//[Index("ProductTmplId", Name = "product_template_attribute_value_product_tmpl_id_index")]
public partial class ProductTemplateAttributeValue: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("product_attribute_value_id")]
    public Guid? ProductAttributeValueId { get; set; }

    [Column("attribute_line_id")]
    public Guid? AttributeLineId { get; set; }

    [Column("product_tmpl_id")]
    public Guid? ProductTmplId { get; set; }

    [Column("attribute_id")]
    public long? AttributeId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("price_extra")]
    public decimal? PriceExtra { get; set; }

    [Column("ptav_active")]
    public bool? PtavActive { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("AttributeId")]
    //[InverseProperty("ProductTemplateAttributeValues")]
    [NotMapped]
    public virtual ProductAttribute? Attribute { get; set; }

    [ForeignKey("AttributeLineId")]
    //[InverseProperty("ProductTemplateAttributeValues")]
    [NotMapped]
    public virtual ProductTemplateAttributeLine? AttributeLine { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ProductTemplateAttributeValueCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ProductAttributeValueId")]
    //[InverseProperty("ProductTemplateAttributeValues")]
    [NotMapped]
    public virtual ProductAttributeValue? ProductAttributeValue { get; set; }

    [ForeignKey("ProductTmplId")]
    //[InverseProperty("ProductTemplateAttributeValues")]
    [NotMapped]
    public virtual ProductTemplate? ProductTmpl { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ProductTemplateAttributeValueWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("CustomProductTemplateAttributeValue")]
    [NotMapped]
    public virtual ICollection<ProductAttributeCustomValue> ProductAttributeCustomValues { get; } = new List<ProductAttributeCustomValue>();

    //[InverseProperty("ProductTemplateAttributeValue")]
    [NotMapped]
    public virtual ICollection<ProductTemplateAttributeExclusion> ProductTemplateAttributeExclusionsNavigation { get; } = new List<ProductTemplateAttributeExclusion>();

    [ForeignKey("ProductTemplateAttributeValueId")]
    //[InverseProperty("ProductTemplateAttributeValues")]
    [NotMapped]
    public virtual ICollection<MrpBomByproduct> MrpBomByproducts { get; } = new List<MrpBomByproduct>();

    [ForeignKey("ProductTemplateAttributeValueId")]
    //[InverseProperty("ProductTemplateAttributeValues")]
    [NotMapped]
    public virtual ICollection<MrpBomLine> MrpBomLines { get; } = new List<MrpBomLine>();

    [ForeignKey("ProductTemplateAttributeValueId")]
    //[InverseProperty("ProductTemplateAttributeValues")]
    [NotMapped]
    public virtual ICollection<MrpRoutingWorkcenter> MrpRoutingWorkcenters { get; } = new List<MrpRoutingWorkcenter>();

    [ForeignKey("ProductTemplateAttributeValueId")]
    //[InverseProperty("ProductTemplateAttributeValues")]
    [NotMapped]
    public virtual ICollection<ProductProduct> ProductProducts { get; } = new List<ProductProduct>();

    [ForeignKey("ProductTemplateAttributeValueId")]
    //[InverseProperty("ProductTemplateAttributeValues")]
    [NotMapped]
    public virtual ICollection<ProductTemplateAttributeExclusion> ProductTemplateAttributeExclusions { get; } = new List<ProductTemplateAttributeExclusion>();

    [ForeignKey("ProductTemplateAttributeValueId")]
    //[InverseProperty("ProductTemplateAttributeValues")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> SaleOrderLines { get; } = new List<SaleOrderLine>();
}
