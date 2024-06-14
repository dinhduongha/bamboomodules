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

[Table("mrp_workcenter_productivity_loss")]
public partial class MrpWorkcenterProductivityLoss: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("loss_id")]
    public long? LossId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("loss_type")]
    public string? LossType { get; set; }

    [Column("manual")]
    public bool? Manual { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MrpWorkcenterProductivityLossCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LossId")]
    //[InverseProperty("MrpWorkcenterProductivityLosses")]
    [NotMapped]
    public virtual MrpWorkcenterProductivityLossType? Loss { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MrpWorkcenterProductivityLossWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Loss")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterProductivity> MrpWorkcenterProductivities { get; } = new List<MrpWorkcenterProductivity>();

}
