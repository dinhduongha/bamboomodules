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

[Table("ir_embedded_actions")]
public partial class IrEmbeddedActions: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("parent_action_id")]
    public Guid? ParentActionId { get; set; }

    [Column("parent_res_id")]
    public Guid? ParentResId { get; set; }

    [Column("action_id")]
    public Guid? ActionId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("parent_res_model")]
    public string? ParentResModel { get; set; }

    [Column("python_method")]
    public string? PythonMethod { get; set; }

    [Column("default_view_mode")]
    public string? DefaultViewMode { get; set; }

    [Column("domain")]
    public string? Domain { get; set; }

    [Column("context")]
    public string? Context { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("IrEmbeddedActionsCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("EmbeddedActionId")]
    [InverseProperty("EmbeddedAction")]
    public virtual ICollection<IrFilters> IrFilters { get; set; }

    // [Many2one]
    [ForeignKey("ParentActionId")]
    // [InverseProperty("IrEmbeddedActions")] //Many2one
    public virtual IrActWindow? ParentAction { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("IrEmbeddedActionsUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("IrEmbeddedActionsWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("IrEmbeddedActionsId")] //Many2many
    // [InverseProperty("IrEmbeddedActions")] //Many2many
    public virtual ICollection<ResGroups> ResGroups { get; set; }
}
