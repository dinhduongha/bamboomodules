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
public partial class IrActWindow: FullAuditedEntity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("binding_model_id")]
    public Guid? BindingModelId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public StringDictionary? Name { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Help { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

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

    [ForeignKey("BindingModelId")]
    //[InverseProperty("IrActWindows")]
    [NotMapped]
    public virtual IrModel? BindingModel { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("IrActWindowCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    // v16-Compat
    //[InverseProperty("CustomAuditAction")]
    [NotMapped]
    public virtual ICollection<AccountReportColumn> AccountReportColumns { get; set; } = new List<AccountReportColumn>();

    //[InverseProperty("Action")]
    [NotMapped]
    public virtual ICollection<GamificationGoalDefinition> GamificationGoalDefinitions { get; set; } = new List<GamificationGoalDefinition>();

    // v16-Compat
    //[InverseProperty("ActWindow")]
    [NotMapped]
    public virtual ICollection<IrActWindowView> IrActWindowViews { get; set; } = new List<IrActWindowView>();

    //[InverseProperty("ParentAction")]
    [NotMapped]
    public virtual ICollection<IrEmbeddedAction> IrEmbeddedActions { get; set; } = new List<IrEmbeddedAction>();

    // v16-Compat
    //[InverseProperty("RefIrActWindowNavigation")]
    [NotMapped]
    public virtual ICollection<MailTemplate> MailTemplates { get; set; } = new List<MailTemplate>();

    [ForeignKey("SearchViewId")]
    //[InverseProperty("IrActWindowSearchViews")]
    [NotMapped]
    public virtual IrUiView? SearchView { get; set; }

    // v16-Compat
    //[InverseProperty("SidebarAction")]
    [NotMapped]
    public virtual ICollection<SmsTemplate> SmsTemplates { get; set; } = new List<SmsTemplate>();

    [ForeignKey("ViewId")]
    //[InverseProperty("IrActWindowViews")]
    [NotMapped]
    public virtual IrUiView? View { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("IrActWindowWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("ActId")]
    //[InverseProperty("ActsNavigation")]
    [NotMapped]
    public virtual ICollection<ResGroup> Gids { get; set; } = new List<ResGroup>();
}
