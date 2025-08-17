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

[Table("procurement_group")]
public partial class ProcurementGroup: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("move_type")]
    public string? MoveType { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("pos_order_id")]
    public Guid? PosOrderId { get; set; }

    [Column("sale_id")]
    public Guid? SaleId { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ProcurementGroupCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("ProcurementGroupId")]
    [InverseProperty("ProcurementGroup")]
    public virtual ICollection<MrpProduction> MrpProduction { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("ProcurementGroup")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [One2many]
    [ForeignKey("ProcurementGroupId")]
    [InverseProperty("ProcurementGroup")]
    public virtual ICollection<PosOrder> PosOrder { get; set; }

    // [Many2one]
    [ForeignKey("PosOrderId")]
    // [InverseProperty("ProcurementGroupNavigation")] //Many2one
    public virtual PosOrder? PosOrderNavigation { get; set; }

    // [One2many]
    [ForeignKey("GroupId")]
    [InverseProperty("Group")]
    public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }

    // [Many2one]
    [ForeignKey("SaleId")]
    // [InverseProperty("ProcurementGroup")] //Many2one
    public virtual SaleOrder? Sale { get; set; }

    // [One2many]
    [ForeignKey("ProcurementGroupId")]
    [InverseProperty("ProcurementGroupNavigation")]
    public virtual ICollection<SaleOrder> SaleOrder { get; set; }

    // [One2many]
    [ForeignKey("GroupId")]
    [InverseProperty("Group")]
    public virtual ICollection<StockMove> StockMove { get; set; }

    // [One2many]
    [ForeignKey("GroupId")]
    [InverseProperty("Group")]
    public virtual ICollection<StockPicking> StockPicking { get; set; }

    // [One2many]
    [ForeignKey("GroupId")]
    [InverseProperty("Group")]
    public virtual ICollection<StockRule> StockRule { get; set; }

    // [One2many]
    [ForeignKey("GroupId")]
    [InverseProperty("Group")]
    public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoint { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ProcurementGroupWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
