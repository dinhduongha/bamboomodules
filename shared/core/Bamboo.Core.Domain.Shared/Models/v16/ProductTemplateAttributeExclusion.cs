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

[Table("product_template_attribute_exclusion")]
//[Index("ProductTemplateAttributeValueId", Name = "product_template_attribute_exclusion__product_template_attribute")]
//[Index("ProductTmplId", Name = "product_template_attribute_exclusion__product_tmpl_id_index")]
public partial class ProductTemplateAttributeExclusion: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("product_template_attribute_value_id")]
    public Guid? ProductTemplateAttributeValueId { get; set; }

    [Column("product_tmpl_id")]
    public Guid? ProductTmplId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ProductTemplateAttributeExclusionCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("ProductTemplateAttributeValueId")]
    // [InverseProperty("ProductTemplateAttributeExclusionNavigation")] //Many2one
    public virtual ProductTemplateAttributeValue? ProductTemplateAttributeValueNavigation { get; set; }

    // [Many2one]
    [ForeignKey("ProductTmplId")]
    // [InverseProperty("ProductTemplateAttributeExclusion")] //Many2one
    public virtual ProductTemplate? ProductTmpl { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ProductTemplateAttributeExclusionWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ProductTemplateAttributeExclusionId")] //Many2many
    // [InverseProperty("ProductTemplateAttributeExclusion")] //Many2many
    public virtual ICollection<ProductTemplateAttributeValue> ProductTemplateAttributeValue { get; set; }
}
