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
public partial class IrActWindowView: FullAuditedEntity<Guid>, IEntityDto<Guid>, IAuditedObject
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
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("view_mode")]
    public string? ViewMode { get; set; }

    [Column("multi")]
    public bool? Multi { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("ActWindowId")]
    // [InverseProperty("IrActWindowView")] //Many2one
    public virtual IrActWindow? ActWindow { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("IrActWindowViewCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("ViewId")]
    // [InverseProperty("IrActWindowViewNavigation")] //Many2one
    public virtual IrUiView? View { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("IrActWindowViewWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
