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

[Table("mrp_routing_workcenter")]
//[Index("BomId", Name = "mrp_routing_workcenter_bom_id_index")]
public partial class MrpRoutingWorkcenter: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("workcenter_id")]
    public Guid? WorkcenterId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("bom_id")]
    public Guid? BomId { get; set; }

    [Column("time_mode_batch")]
    public long? TimeModeBatch { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("worksheet_type")]
    public string? WorksheetType { get; set; }

    [Column("worksheet_google_slide")]
    public string? WorksheetGoogleSlide { get; set; }

    [Column("time_mode")]
    public string? TimeMode { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("time_cycle_manual")]
    public double? TimeCycleManual { get; set; }

    // [Many2one]
    [ForeignKey("BomId")]
    // [InverseProperty("MrpRoutingWorkcenter")] //Many2one
    public virtual MrpBom? Bom { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("MrpRoutingWorkcenterCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("OperationId")]
    [InverseProperty("Operation")]
    public virtual ICollection<MrpBomByproduct> MrpBomByproduct { get; set; }

    // [One2many]
    [ForeignKey("OperationId")]
    [InverseProperty("Operation")]
    public virtual ICollection<MrpBomLine> MrpBomLine { get; set; }

    // [One2many]
    [ForeignKey("OperationId")]
    [InverseProperty("Operation")]
    public virtual ICollection<MrpWorkorder> MrpWorkorder { get; set; }

    // [One2many]
    [ForeignKey("OperationId")]
    [InverseProperty("Operation")]
    public virtual ICollection<StockMove> StockMove { get; set; }

    // [Many2one]
    [ForeignKey("WorkcenterId")]
    // [InverseProperty("MrpRoutingWorkcenter")] //Many2one
    public virtual MrpWorkcenter? Workcenter { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("MrpRoutingWorkcenterWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("OperationId")] //Many2many
    // [InverseProperty("Operation")] //Many2many
    public virtual ICollection<MrpRoutingWorkcenter> BlockedBy { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("BlockedById")] //Many2many
    // [InverseProperty("BlockedBy")] //Many2many
    public virtual ICollection<MrpRoutingWorkcenter> Operation { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("MrpRoutingWorkcenterId")] //Many2many
    // [InverseProperty("MrpRoutingWorkcenter")] //Many2many
    public virtual ICollection<ProductTemplateAttributeValue> ProductTemplateAttributeValue { get; set; }
}
