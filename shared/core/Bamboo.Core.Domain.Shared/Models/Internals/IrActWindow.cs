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

[Table("ir_act_window")]
//[Index("Path", Name = "ir_act_window_path_unique", IsUnique = true)]
public partial class IrActWindow: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("binding_model_id")]
    public Guid? BindingModelId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("type")]
    public string? Type { get; set; }

    [Column("path")]
    public string? Path { get; set; }

    [Column("binding_type")]
    public string? BindingType { get; set; }

    [Column("binding_view_types")]
    public string? BindingViewTypes { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [JsonField]
    [Column("help", TypeName = "jsonb")]
    public string? Help { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("view_id")]
    public Guid? ViewId { get; set; }

    [Column("res_id")]
    public Guid? ResId { get; set; }

    [Column("limit")]
    public long? Limit { get; set; }

    [Column("search_view_id")]
    public Guid? SearchViewId { get; set; }

    [Column("domain")]
    public string? Domain { get; set; }

    [Column("context")]
    public string? Context { get; set; }

    [Column("res_model")]
    public string? ResModel { get; set; }

    [Column("target")]
    public string? Target { get; set; }

    [Column("view_mode")]
    public string? ViewMode { get; set; }

    [Column("mobile_view_mode")]
    public string? MobileViewMode { get; set; }

    [Column("usage")]
    public string? Usage { get; set; }

    [Column("filter")]
    public bool? Filter { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("CustomAuditActionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("CustomAuditAction")] // One2many
    public virtual ICollection<AccountReportColumn> AccountReportColumn { get; set; }

    // [Many2one]
    [ForeignKey("BindingModelId")]
    public virtual IrModel? BindingModel { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ActionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Action")] // One2many
    public virtual ICollection<GamificationGoalDefinition> GamificationGoalDefinition { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ActWindowId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ActWindow")] // One2many
    public virtual ICollection<IrActWindowView> IrActWindowView { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ParentActionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ParentAction")] // One2many
    public virtual ICollection<IrEmbeddedActions> IrEmbeddedActions { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("RefIrActWindow")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("RefIrActWindowNavigation")] // One2many
    public virtual ICollection<MailTemplate> MailTemplate { get; set; }

    // [Many2one]
    [ForeignKey("SearchViewId")]
    public virtual IrUiView? SearchView { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("SidebarActionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SidebarAction")] // One2many
    public virtual ICollection<SmsTemplate> SmsTemplate { get; set; }

    // [Many2one]
    [ForeignKey("ViewId")]
    public virtual IrUiView? View { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ActId")] // Many2many // Normal
    // [InverseProperty("ActNavigation")] // Many2many // Normal
    public virtual ICollection<ResGroups> Gid { get; set; }
}
