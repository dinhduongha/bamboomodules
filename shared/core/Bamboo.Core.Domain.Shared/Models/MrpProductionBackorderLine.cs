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

[Table("mrp_production_backorder_line")]
public partial class MrpProductionBackorderLine: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("mrp_production_backorder_id")]
    public Guid? MrpProductionBackorderId { get; set; }

    [Column("mrp_production_id")]
    public Guid? MrpProductionId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("to_backorder")]
    public bool? ToBackorder { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MrpProductionBackorderLineCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MrpProductionId")]
    //[InverseProperty("MrpProductionBackorderLines")]
    [NotMapped]
    public virtual MrpProduction? MrpProduction { get; set; }

    [ForeignKey("MrpProductionBackorderId")]
    //[InverseProperty("MrpProductionBackorderLines")]
    [NotMapped]
    public virtual MrpProductionBackorder? MrpProductionBackorder { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MrpProductionBackorderLineWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
