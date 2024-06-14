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
public partial class ProductAttributeCustomValue: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("custom_product_template_attribute_value_id")]
    public Guid? CustomProductTemplateAttributeValueId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("custom_value")]
    public string? CustomValue { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("sale_order_line_id")]
    public Guid? SaleOrderLineId { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ProductAttributeCustomValueCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CustomProductTemplateAttributeValueId")]
    //[InverseProperty("ProductAttributeCustomValues")]
    [NotMapped]
    public virtual ProductTemplateAttributeValue? CustomProductTemplateAttributeValue { get; set; }

    [ForeignKey("SaleOrderLineId")]
    //[InverseProperty("ProductAttributeCustomValues")]
    [NotMapped]
    public virtual SaleOrderLine? SaleOrderLine { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ProductAttributeCustomValueWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
