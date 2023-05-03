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

[Table("ir_act_window_view")]
//[Index("ActWindowId", "ViewMode", Name = "act_window_view_unique_mode_per_action", IsUnique = true)]
public partial class IrActWindowView: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("view_id")]
    public Guid? ViewId { get; set; }

    [Column("act_window_id")]
    public Guid? ActWindowId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("view_mode")]
    public string? ViewMode { get; set; }

    [Column("multi")]
    public bool? Multi { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("ActWindowId")]
    //[InverseProperty("IrActWindowViews")]
    [NotMapped]
    public virtual IrActWindow? ActWindow { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("IrActWindowViewCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ViewId")]
    //[InverseProperty("IrActWindowViewsNavigation")]
    [NotMapped]
    public virtual IrUiView? View { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("IrActWindowViewWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
