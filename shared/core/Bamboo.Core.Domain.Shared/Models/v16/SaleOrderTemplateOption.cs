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
//[Index("CompanyId", Name = "sale_order_template_option_company_id_index")]
//[Index("SaleOrderTemplateId", Name = "sale_order_template_option_sale_order_template_id_index")]
public partial class SaleOrderTemplateOption: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("sale_order_template_id")]
    public Guid? SaleOrderTemplateId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("uom_id")]
    public Guid? UomId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("quantity")]
    public decimal? Quantity { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("SaleOrderTemplateOption")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("SaleOrderTemplateOptionCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("SaleOrderTemplateOption")] //Many2one
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [ForeignKey("SaleOrderTemplateId")]
    // [InverseProperty("SaleOrderTemplateOption")] //Many2one
    public virtual SaleOrderTemplate? SaleOrderTemplate { get; set; }

    // [Many2one]
    [ForeignKey("UomId")]
    // [InverseProperty("SaleOrderTemplateOption")] //Many2one
    public virtual UomUom? Uom { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("SaleOrderTemplateOptionWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
