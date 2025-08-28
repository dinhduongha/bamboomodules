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

[Table("ir_act_server")]
//[Index("ModelId", Name = "ir_act_server__model_id_index")]
//[Index("Path", Name = "ir_act_server_path_unique", IsUnique = true)]
public partial class IrActServer: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IAuditedObject
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

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("model_id")]
    public Guid? ModelId { get; set; }

    [Column("crud_model_id")]
    public Guid? CrudModelId { get; set; }

    [Column("link_field_id")]
    public Guid? LinkFieldId { get; set; }

    [Column("update_field_id")]
    public Guid? UpdateFieldId { get; set; }

    [Column("update_related_model_id")]
    public Guid? UpdateRelatedModelId { get; set; }

    [Column("selection_value")]
    public Guid? SelectionValue { get; set; }

    [Column("usage")]
    public string? Usage { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("model_name")]
    public string? ModelName { get; set; }

    [Column("update_path")]
    public string? UpdatePath { get; set; }

    [Column("update_m2m_operation")]
    public string? UpdateM2mOperation { get; set; }

    [Column("update_boolean_value")]
    public string? UpdateBooleanValue { get; set; }

    [Column("evaluation_type")]
    public string? EvaluationType { get; set; }

    [Column("resource_ref")]
    public string? ResourceRef { get; set; }

    [Column("webhook_url")]
    public string? WebhookUrl { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("value")]
    public string? Value { get; set; }

    [Column("template_id")]
    public Guid? TemplateId { get; set; }

    [Column("activity_type_id")]
    public Guid? ActivityTypeId { get; set; }

    [Column("activity_date_deadline_range")]
    public long? ActivityDateDeadlineRange { get; set; }

    [Column("activity_user_id")]
    public Guid? ActivityUserId { get; set; }

    [Column("mail_post_method")]
    public string? MailPostMethod { get; set; }

    [Column("activity_summary")]
    public string? ActivitySummary { get; set; }

    [Column("activity_date_deadline_range_type")]
    public string? ActivityDateDeadlineRangeType { get; set; }

    [Column("activity_user_type")]
    public string? ActivityUserType { get; set; }

    [Column("activity_user_field_name")]
    public string? ActivityUserFieldName { get; set; }

    [Column("activity_note")]
    public string? ActivityNote { get; set; }

    [Column("mail_post_autofollow")]
    public bool? MailPostAutofollow { get; set; }

    [Column("sms_template_id")]
    public Guid? SmsTemplateId { get; set; }

    [Column("sms_method")]
    public string? SmsMethod { get; set; }

    [Column("website_path")]
    public string? WebsitePath { get; set; }

    [Column("website_published")]
    public bool? WebsitePublished { get; set; }

    [Column("base_automation_id")]
    public Guid? BaseAutomationId { get; set; }

    // [Many2one]
    [ForeignKey("ActivityTypeId")]
    public virtual MailActivityType? ActivityType { get; set; }

    // [Many2one]
    [ForeignKey("ActivityUserId")]
    public virtual ResUsers? ActivityUser { get; set; }

    // [Many2one]
    [ForeignKey("BaseAutomationId")]
    public virtual BaseAutomation? BaseAutomation { get; set; }

    // [Many2one]
    [ForeignKey("BindingModelId")]
    public virtual IrModel? BindingModel { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CrudModelId")]
    public virtual IrModel? CrudModel { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("IrActionsServerId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("IrActionsServer")] // One2many
    public virtual ICollection<IrCron> IrCron { get; set; }

    // [Many2one]
    [ForeignKey("LinkFieldId")]
    public virtual IrModelFields? LinkField { get; set; }

    // [Many2one]
    [ForeignKey("ModelId")]
    public virtual IrModel? Model { get; set; }

    // [Many2one]
    [ForeignKey("SelectionValue")]
    public virtual IrModelFieldsSelection? SelectionValueNavigation { get; set; }

    // [Many2one]
    [ForeignKey("SmsTemplateId")]
    public virtual SmsTemplate? SmsTemplate { get; set; }

    // [Many2one]
    [ForeignKey("TemplateId")]
    public virtual MailTemplate? Template { get; set; }

    // [Many2one]
    [ForeignKey("UpdateFieldId")]
    public virtual IrModelFields? UpdateField { get; set; }

    // [Many2one]
    [ForeignKey("UpdateRelatedModelId")]
    public virtual IrModel? UpdateRelatedModel { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ActionServerId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ActionServer")] // One2many
    public virtual ICollection<WebsiteSnippetFilter> WebsiteSnippetFilter { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ServerId")] // Many2many // Normal
    // [InverseProperty("Server")] // Many2many // Normal
    public virtual ICollection<IrActServer> Action { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ServerId")] // Many2many // Normal
    // [InverseProperty("Server")] // Many2many // Normal
    public virtual ICollection<IrModelFields> Field { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ActId")] // Many2many // Normal
    // [InverseProperty("Act")] // Many2many // Normal
    public virtual ICollection<ResGroups> Gid { get; set; }

    // [Many2many] // Normal
    [NotMapped] // Many2many // Peer relationship (ResPartner) is commented out
    // [ForeignKey("IrActServerId")] // Many2many // Normal
    // [InverseProperty("IrActServer")] // Many2many // Normal
    public virtual ICollection<ResPartner> ResPartner { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ActionId")] // Many2many // Normal
    // [InverseProperty("Action")] // Many2many // Normal
    public virtual ICollection<IrActServer> Server { get; set; }
}
