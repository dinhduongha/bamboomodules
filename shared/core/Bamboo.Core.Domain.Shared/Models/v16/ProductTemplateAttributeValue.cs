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
public partial class ProductTemplateAttributeValue: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("product_attribute_value_id")]
    public Guid? ProductAttributeValueId { get; set; }

    [Column("attribute_line_id")]
    public Guid? AttributeLineId { get; set; }

    [Column("product_tmpl_id")]
    public Guid? ProductTmplId { get; set; }

    [Column("attribute_id")]
    public Guid? AttributeId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("price_extra")]
    public decimal? PriceExtra { get; set; }

    [Column("ptav_active")]
    public bool? PtavActive { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("AttributeId")]
    // [InverseProperty("ProductTemplateAttributeValue")] //Many2one
    public virtual ProductAttribute? Attribute { get; set; }

    // [Many2one]
    [ForeignKey("AttributeLineId")]
    // [InverseProperty("ProductTemplateAttributeValue")] //Many2one
    public virtual ProductTemplateAttributeLine? AttributeLine { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ProductTemplateAttributeValueCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("CustomProductTemplateAttributeValueId")]
    [InverseProperty("CustomProductTemplateAttributeValue")]
    public virtual ICollection<ProductAttributeCustomValue> ProductAttributeCustomValue { get; set; }

    // [Many2one]
    [ForeignKey("ProductAttributeValueId")]
    // [InverseProperty("ProductTemplateAttributeValue")] //Many2one
    public virtual ProductAttributeValue? ProductAttributeValue { get; set; }

    // [One2many]
    [ForeignKey("ProductTemplateAttributeValueId")]
    [InverseProperty("ProductTemplateAttributeValueNavigation")]
    public virtual ICollection<ProductTemplateAttributeExclusion> ProductTemplateAttributeExclusionNavigation { get; set; }

    // [Many2one]
    [ForeignKey("ProductTmplId")]
    // [InverseProperty("ProductTemplateAttributeValue")] //Many2one
    public virtual ProductTemplate? ProductTmpl { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ProductTemplateAttributeValueWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductTemplateAttributeValueId")]
    // [InverseProperty("ProductTemplateAttributeValue")]
    // public virtual ICollection<MrpBomByproduct> MrpBomByproduct { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductTemplateAttributeValueId")]
    // [InverseProperty("ProductTemplateAttributeValue")]
    // public virtual ICollection<MrpBomLine> MrpBomLine { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductTemplateAttributeValueId")]
    // [InverseProperty("ProductTemplateAttributeValue")]
    // public virtual ICollection<MrpRoutingWorkcenter> MrpRoutingWorkcenter { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductTemplateAttributeValueId")]
    // [InverseProperty("ProductTemplateAttributeValue")]
    // public virtual ICollection<ProductProduct> ProductProduct { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductTemplateAttributeValueId")]
    // [InverseProperty("ProductTemplateAttributeValue")]
    // public virtual ICollection<ProductTemplateAttributeExclusion> ProductTemplateAttributeExclusion { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductTemplateAttributeValueId")]
    // [InverseProperty("ProductTemplateAttributeValue")]
    // public virtual ICollection<PurchaseOrderLine> PurchaseOrderLine { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductTemplateAttributeValueId")]
    // [InverseProperty("ProductTemplateAttributeValue")]
    // public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }
}
