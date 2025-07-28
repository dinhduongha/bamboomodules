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

[Module("base")]
[Table("ir_embedded_actions")]
public partial class IrEmbeddedAction: FullAuditedEntity<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

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
    public Guid? CreatorId { get; set; }

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
    public StringDictionary? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("IrEmbeddedActionCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("EmbeddedAction")]
    [NotMapped]
    public virtual ICollection<IrFilter> IrFilters { get; set; } = new List<IrFilter>();

    [ForeignKey("ParentActionId")]
    //[InverseProperty("IrEmbeddedActions")]
    [NotMapped]
    public virtual IrActWindow? ParentAction { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("IrEmbeddedActionUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("IrEmbeddedActionWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("IrEmbeddedActionsId")]
    //[InverseProperty("IrEmbeddedActions")]
    [NotMapped]
    public virtual ICollection<ResGroup> ResGroups { get; set; } = new List<ResGroup>();
}
