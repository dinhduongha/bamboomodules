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

[Table("mrp_production_split")]
public partial class MrpProductionSplit: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("production_split_multi_id")]
    public Guid? ProductionSplitMultiId { get; set; }

    [Column("production_id")]
    public Guid? ProductionId { get; set; }

    [Column("counter")]
    public long? Counter { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MrpProductionSplitCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ProductionId")]
    //[InverseProperty("MrpProductionSplits")]
    [NotMapped]
    public virtual MrpProduction? Production { get; set; }

    [ForeignKey("ProductionSplitMultiId")]
    //[InverseProperty("MrpProductionSplits")]
    [NotMapped]
    public virtual MrpProductionSplitMulti? ProductionSplitMulti { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MrpProductionSplitWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("MrpProductionSplit")]
    [NotMapped]
    public virtual ICollection<MrpProductionSplitLine> MrpProductionSplitLines { get; } = new List<MrpProductionSplitLine>();

}
