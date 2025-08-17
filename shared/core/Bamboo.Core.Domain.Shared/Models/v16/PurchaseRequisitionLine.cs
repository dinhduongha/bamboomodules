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

[Table("purchase_requisition_line")]
public partial class PurchaseRequisitionLine: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_uom_id")]
    public Guid? ProductUomId { get; set; }

    [Column("requisition_id")]
    public Guid? RequisitionId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("product_description_variants")]
    public string? ProductDescriptionVariants { get; set; }

    [Column("schedule_date")]
    public DateTime? ScheduleDate { get; set; }

    [JsonField]
    [Column("analytic_distribution", TypeName = "jsonb")]
    public string? AnalyticDistribution { get; set; }

    [Column("product_qty")]
    public decimal? ProductQty { get; set; }

    [Column("price_unit")]
    public decimal? PriceUnit { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("move_dest_id")]
    public Guid? MoveDestId { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("PurchaseRequisitionLine")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("PurchaseRequisitionLineCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("MoveDestId")]
    // [InverseProperty("PurchaseRequisitionLine")] //Many2one
    public virtual StockMove? MoveDest { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("PurchaseRequisitionLine")] //Many2one
    public virtual ProductProduct? Product { get; set; }

    // [One2many]
    [ForeignKey("PurchaseRequisitionLineId")]
    [InverseProperty("PurchaseRequisitionLine")]
    public virtual ICollection<ProductSupplierinfo> ProductSupplierinfo { get; set; }

    // [Many2one]
    [ForeignKey("ProductUomId")]
    // [InverseProperty("PurchaseRequisitionLine")] //Many2one
    public virtual UomUom? ProductUom { get; set; }

    // [Many2one]
    [ForeignKey("RequisitionId")]
    // [InverseProperty("PurchaseRequisitionLine")] //Many2one
    public virtual PurchaseRequisition? Requisition { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("PurchaseRequisitionLineWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
