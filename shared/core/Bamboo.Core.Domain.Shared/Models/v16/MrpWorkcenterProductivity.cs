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

[Table("mrp_workcenter_productivity")]
//[Index("CompanyId", Name = "mrp_workcenter_productivity_company_id_index")]
//[Index("WorkcenterId", Name = "mrp_workcenter_productivity_workcenter_id_index")]
//[Index("WorkorderId", Name = "mrp_workcenter_productivity_workorder_id_index")]
public partial class MrpWorkcenterProductivity: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("workorder_id")]
    public Guid? WorkorderId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("loss_id")]
    public Guid? LossId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("loss_type")]
    public string? LossType { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("date_start", TypeName = "timestamp without time zone")]
    public DateTime? DateStart { get; set; }

    [Column("date_end", TypeName = "timestamp without time zone")]
    public DateTime? DateEnd { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("duration")]
    public double? Duration { get; set; }

    [Column("cost_already_recorded")]
    public bool? CostAlreadyRecorded { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("MrpWorkcenterProductivity")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("MrpWorkcenterProductivityCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("LossId")]
    // [InverseProperty("MrpWorkcenterProductivity")] //Many2one
    public virtual MrpWorkcenterProductivityLoss? Loss { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("MrpWorkcenterProductivityUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("WorkcenterId")]
    // [InverseProperty("MrpWorkcenterProductivity")] //Many2one
    public virtual MrpWorkcenter? Workcenter { get; set; }

    // [Many2one]
    [ForeignKey("WorkorderId")]
    // [InverseProperty("MrpWorkcenterProductivity")] //Many2one
    public virtual MrpWorkorder? Workorder { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("MrpWorkcenterProductivityWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
