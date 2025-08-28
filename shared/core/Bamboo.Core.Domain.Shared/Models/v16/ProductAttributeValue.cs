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
//[Index("AttributeId", Name = "product_attribute_value__attribute_id_index")]
//[Index("Sequence", Name = "product_attribute_value__sequence_index")]
public partial class ProductAttributeValue: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("attribute_id")]
    public Guid? AttributeId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("html_color")]
    public string? HtmlColor { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("is_custom")]
    public bool? IsCustom { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("default_extra_price")]
    public double? DefaultExtraPrice { get; set; }

    // [Many2one]
    [ForeignKey("AttributeId")]
    public virtual ProductAttribute? Attribute { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ProductAttributeValueId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ProductAttributeValue")] // One2many
    public virtual ICollection<ProductTemplateAttributeValue> ProductTemplateAttributeValue { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("AttributeValueId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AttributeValue")] // One2many
    public virtual ICollection<UpdateProductAttributeValue> UpdateProductAttributeValue { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ProductAttributeValueId")] // Many2many // Normal
    // [InverseProperty("ProductAttributeValue")] // Many2many // Normal
    public virtual ICollection<ProductTemplateAttributeLine> ProductTemplateAttributeLine { get; set; }
}
