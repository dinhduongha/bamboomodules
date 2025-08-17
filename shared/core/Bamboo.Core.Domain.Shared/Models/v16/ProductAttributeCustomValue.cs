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

[Table("product_attribute_custom_value")]
//[Index("CustomProductTemplateAttributeValueId", "SaleOrderLineId", Name = "product_attribute_custom_value_sol_custom_value_unique", IsUnique = true)]
public partial class ProductAttributeCustomValue: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("custom_product_template_attribute_value_id")]
    public Guid? CustomProductTemplateAttributeValueId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("custom_value")]
    public string? CustomValue { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("sale_order_line_id")]
    public Guid? SaleOrderLineId { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ProductAttributeCustomValueCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CustomProductTemplateAttributeValueId")]
    // [InverseProperty("ProductAttributeCustomValue")] //Many2one
    public virtual ProductTemplateAttributeValue? CustomProductTemplateAttributeValue { get; set; }

    // [Many2one]
    [ForeignKey("SaleOrderLineId")]
    // [InverseProperty("ProductAttributeCustomValue")] //Many2one
    public virtual SaleOrderLine? SaleOrderLine { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ProductAttributeCustomValueWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
