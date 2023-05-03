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
//[Index("TenantId", Name = "mrp_workcenter_productivity_company_id_index")]
//[Index("WorkcenterId", Name = "mrp_workcenter_productivity_workcenter_id_index")]
//[Index("WorkorderId", Name = "mrp_workcenter_productivity_workorder_id_index")]
public partial class MrpWorkcenterProductivity: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("workcenter_id")]
    public Guid? WorkcenterId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("workorder_id")]
    public Guid? WorkorderId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("loss_id")]
    public Guid? LossId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("loss_type")]
    public string? LossType { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("date_start", TypeName = "timestamp without time zone")]
    public DateTime? DateStart { get; set; }

    [Column("date_end", TypeName = "timestamp without time zone")]
    public DateTime? DateEnd { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("duration")]
    public double? Duration { get; set; }

    [Column("cost_already_recorded")]
    public bool? CostAlreadyRecorded { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("MrpWorkcenterProductivities")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MrpWorkcenterProductivityCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LossId")]
    //[InverseProperty("MrpWorkcenterProductivities")]
    [NotMapped]
    public virtual MrpWorkcenterProductivityLoss? Loss { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("MrpWorkcenterProductivityUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("WorkcenterId")]
    //[InverseProperty("MrpWorkcenterProductivities")]
    [NotMapped]
    public virtual MrpWorkcenter? Workcenter { get; set; }

    [ForeignKey("WorkorderId")]
    //[InverseProperty("MrpWorkcenterProductivities")]
    [NotMapped]
    public virtual MrpWorkorder? Workorder { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MrpWorkcenterProductivityWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
