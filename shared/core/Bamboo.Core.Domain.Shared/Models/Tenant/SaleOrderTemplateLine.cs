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

[Table("sale_order_template_line")]
//[Index("TenantId", Name = "sale_order_template_line_company_id_index")]
//[Index("SaleOrderTemplateId", Name = "sale_order_template_line_sale_order_template_id_index")]
public partial class SaleOrderTemplateLine: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("sale_order_template_id")]
    public Guid? SaleOrderTemplateId { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_uom_id")]
    public Guid? ProductUomId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("display_type")]
    public string? DisplayType { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("product_uom_qty")]
    public decimal? ProductUomQty { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("SaleOrderTemplateLines")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SaleOrderTemplateLineCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("SaleOrderTemplateLines")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("ProductUomId")]
    //[InverseProperty("SaleOrderTemplateLines")]
    [NotMapped]
    public virtual UomUom? ProductUom { get; set; }

    [ForeignKey("SaleOrderTemplateId")]
    //[InverseProperty("SaleOrderTemplateLines")]
    [NotMapped]
    public virtual SaleOrderTemplate? SaleOrderTemplate { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SaleOrderTemplateLineWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
