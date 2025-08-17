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

[Table("product_attribute")]
//[Index("CategoryId", Name = "product_attribute_category_id_index")]
//[Index("Sequence", Name = "product_attribute_sequence_index")]
public partial class ProductAttribute: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("create_variant")]
    public string? CreateVariant { get; set; }

    [Column("display_type")]
    public string? DisplayType { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("visibility")]
    public string? Visibility { get; set; }

    [Column("category_id")]
    public Guid? CategoryId { get; set; }

    // [Many2one]
    [ForeignKey("CategoryId")]
    // [InverseProperty("ProductAttribute")] //Many2one
    public virtual ProductAttributeCategory? Category { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ProductAttributeCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("AttributeId")]
    [InverseProperty("Attribute")]
    public virtual ICollection<ProductAttributeValue> ProductAttributeValue { get; set; }

    // [One2many]
    [ForeignKey("AttributeId")]
    [InverseProperty("Attribute")]
    public virtual ICollection<ProductTemplateAttributeLine> ProductTemplateAttributeLine { get; set; }

    // [One2many]
    [ForeignKey("AttributeId")]
    [InverseProperty("Attribute")]
    public virtual ICollection<ProductTemplateAttributeValue> ProductTemplateAttributeValue { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ProductAttributeWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ProductAttributeId")] //Many2many
    // [InverseProperty("ProductAttribute")] //Many2many
    public virtual ICollection<ProductTemplate> ProductTemplate { get; set; }
}
