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

[Table("mrp_immediate_production_line")]
public partial class MrpImmediateProductionLine : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("immediate_production_id")]
    public Guid? ImmediateProductionId { get; set; }

    [Column("production_id")]
    public Guid? ProductionId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("to_immediate")]
    public bool? ToImmediate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MrpImmediateProductionLineCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ImmediateProductionId")]
    //[InverseProperty("MrpImmediateProductionLines")]
    [NotMapped]
    public virtual MrpImmediateProduction? ImmediateProduction { get; set; }

    [ForeignKey("ProductionId")]
    //[InverseProperty("MrpImmediateProductionLines")]
    [NotMapped]
    public virtual MrpProduction? Production { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MrpImmediateProductionLineWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
