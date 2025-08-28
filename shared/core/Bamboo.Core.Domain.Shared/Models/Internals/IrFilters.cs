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

[Table("ir_filters")]
//[Index("ModelId", "UserId", "ActionId", "EmbeddedActionId", "EmbeddedParentResId", "Name", Name = "ir_filters_name_model_uid_unique", IsUnique = true)]
public partial class IrFilters: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("action_id")]
    public Guid? ActionId { get; set; }

    [Column("embedded_action_id")]
    public Guid? EmbeddedActionId { get; set; }

    [Column("embedded_parent_res_id")]
    public Guid? EmbeddedParentResId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("sort")]
    public string? Sort { get; set; }

    [Column("model_id")]
    public string? ModelId { get; set; }

    [Column("domain")]
    public string? Domain { get; set; }

    [Column("context")]
    public string? Context { get; set; }

    [Column("is_default")]
    public bool? IsDefault { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("EmbeddedActionId")]
    public virtual IrEmbeddedActions? EmbeddedAction { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("FilterId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Filter")] // One2many
    public virtual ICollection<WebsiteSnippetFilter> WebsiteSnippetFilter { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
