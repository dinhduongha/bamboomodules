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

[Table("product_template_attribute_value")]
//[Index("AttributeId", Name = "product_template_attribute_value__attribute_id_index")]
//[Index("AttributeLineId", Name = "product_template_attribute_value__attribute_line_id_index")]
//[Index("ProductAttributeValueId", Name = "product_template_attribute_value__product_attribute_va_63041d9e")]
//[Index("ProductTmplId", Name = "product_template_attribute_value__product_tmpl_id_index")]
//[Index("AttributeLineId", "ProductAttributeValueId", Name = "product_template_attribute_value_attribute_value_unique", IsUnique = true)]
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
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AttributeId")]
    public virtual ProductAttribute? Attribute { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AttributeLineId")]
    public virtual ProductTemplateAttributeLine? AttributeLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CustomProductTemplateAttributeValueId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("CustomProductTemplateAttributeValue")] // One2many
    public virtual ICollection<ProductAttributeCustomValue> ProductAttributeCustomValue { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductAttributeValueId")]
    public virtual ProductAttributeValue? ProductAttributeValue { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProductTemplateAttributeValueId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ProductTemplateAttributeValueNavigation")] // One2many
    public virtual ICollection<ProductTemplateAttributeExclusion> ProductTemplateAttributeExclusionNavigation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductTmplId")]
    public virtual ProductTemplate? ProductTmpl { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("TemplateAttributeValueId")] //Many2many // Hidden
    // [InverseProperty("TemplateAttributeValue")] //Many2many // Hidden
    public virtual ICollection<StockMove> Move { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductTemplateAttributeValueId")] //Many2many // Hidden
    // [InverseProperty("ProductTemplateAttributeValue")] //Many2many // Hidden
    public virtual ICollection<MrpBomByproduct> MrpBomByproduct { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductTemplateAttributeValueId")] //Many2many // Hidden
    // [InverseProperty("ProductTemplateAttributeValue")] //Many2many // Hidden
    public virtual ICollection<MrpBomLine> MrpBomLine { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductTemplateAttributeValueId")] //Many2many // Hidden
    // [InverseProperty("ProductTemplateAttributeValue")] //Many2many // Hidden
    public virtual ICollection<MrpRoutingWorkcenter> MrpRoutingWorkcenter { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductTemplateAttributeValueId")] //Many2many // Hidden
    // [InverseProperty("ProductTemplateAttributeValue")] //Many2many // Hidden
    public virtual ICollection<PosOrderLine> PosOrderLine { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

    [NotMapped] //Many2many // Hidden // Peer relationship (ProductProduct) is commented out
    // [ForeignKey("ProductTemplateAttributeValueId")] //Many2many // Hidden
    // [InverseProperty("ProductTemplateAttributeValue")] //Many2many // Hidden
    public virtual ICollection<ProductProduct> ProductProduct { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductTemplateAttributeValueId")] //Many2many // Hidden
    // [InverseProperty("ProductTemplateAttributeValue")] //Many2many // Hidden
    public virtual ICollection<ProductTemplateAttributeExclusion> ProductTemplateAttributeExclusion { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("TemplateAttributeValueId")] //Many2many // Hidden
    // [InverseProperty("TemplateAttributeValue")] //Many2many // Hidden
    public virtual ICollection<MrpProduction> Production { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductTemplateAttributeValueId")] //Many2many // Hidden
    // [InverseProperty("ProductTemplateAttributeValue")] //Many2many // Hidden
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLine { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductTemplateAttributeValueId")] //Many2many // Hidden
    // [InverseProperty("ProductTemplateAttributeValue")] //Many2many // Hidden
    public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }
}
