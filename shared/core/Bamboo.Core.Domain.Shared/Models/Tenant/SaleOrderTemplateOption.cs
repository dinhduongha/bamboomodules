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

[Table("sale_order_template_option")]
//[Index("TenantId", Name = "sale_order_template_option_company_id_index")]
//[Index("SaleOrderTemplateId", Name = "sale_order_template_option_sale_order_template_id_index")]
public partial class SaleOrderTemplateOption: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("sale_order_template_id")]
    public Guid? SaleOrderTemplateId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("uom_id")]
    public Guid? UomId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("quantity")]
    public decimal? Quantity { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("SaleOrderTemplateOptions")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SaleOrderTemplateOptionCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("SaleOrderTemplateOptions")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("SaleOrderTemplateId")]
    //[InverseProperty("SaleOrderTemplateOptions")]
    [NotMapped]
    public virtual SaleOrderTemplate? SaleOrderTemplate { get; set; }

    [ForeignKey("UomId")]
    //[InverseProperty("SaleOrderTemplateOptions")]
    [NotMapped]
    public virtual UomUom? Uom { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SaleOrderTemplateOptionWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
