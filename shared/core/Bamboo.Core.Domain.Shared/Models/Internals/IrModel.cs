using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

[Table("ir_model")]
//[Index("Model", Name = "ir_model_obj_name_uniq", IsUnique = true)]
public partial class IrModel: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("model")]
    public string? Model { get; set; }

    [Column("order")]
    public string? Order { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [JsonField(IsSparse = false)] // Name
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [Column("info")]
    public string? Info { get; set; }

    [Column("transient")]
    public bool? Transient { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("is_mail_thread")]
    public bool? IsMailThread { get; set; }

    [Column("is_mail_activity")]
    public bool? IsMailActivity { get; set; }

    [Column("is_mail_blacklist")]
    public bool? IsMailBlacklist { get; set; }

    [Column("website_form_default_field_id")]
    public Guid? WebsiteFormDefaultFieldId { get; set; }

    [Column("website_form_label")]
    public string? WebsiteFormLabel { get; set; }

    [Column("website_form_key")]
    public string? WebsiteFormKey { get; set; }

    [Column("website_form_access")]
    public bool? WebsiteFormAccess { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Model")] // One2many
    public virtual ICollection<BaseAutomation> BaseAutomation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Model")] // One2many
    public virtual ICollection<BaseLanguageExport> BaseLanguageExport { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ResModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ResModelNavigation")] // One2many
    public virtual ICollection<CalendarEvent> CalendarEvent { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ResModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ResModel")] // One2many
    public virtual ICollection<DataRecycleModel> DataRecycleModel { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ResModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ResModel")] // One2many
    public virtual ICollection<DataRecycleRecord> DataRecycleRecord { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ObjectId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Object")] // One2many
    public virtual ICollection<FetchmailServer> FetchmailServer { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Model")] // One2many
    public virtual ICollection<GamificationGoalDefinition> GamificationGoalDefinition { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("BindingModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("BindingModel")] // One2many
    public virtual ICollection<IrActClient> IrActClient { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("BindingModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("BindingModel")] // One2many
    public virtual ICollection<IrActReportXml> IrActReportXml { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("BindingModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("BindingModel")] // One2many
    public virtual ICollection<IrActServer> IrActServerBindingModel { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CrudModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("CrudModel")] // One2many
    public virtual ICollection<IrActServer> IrActServerCrudModel { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Model")] // One2many
    public virtual ICollection<IrActServer> IrActServerModel { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("UpdateRelatedModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("UpdateRelatedModel")] // One2many
    public virtual ICollection<IrActServer> IrActServerUpdateRelatedModel { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("BindingModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("BindingModel")] // One2many
    public virtual ICollection<IrActUrl> IrActUrl { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("BindingModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("BindingModel")] // One2many
    public virtual ICollection<IrActWindow> IrActWindow { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("BindingModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("BindingModel")] // One2many
    public virtual ICollection<IrActions> IrActions { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Model")] // One2many
    public virtual ICollection<IrModelAccess> IrModelAccess { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("Model")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ModelNavigation")] // One2many
    public virtual ICollection<IrModelConstraint> IrModelConstraint { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ModelNavigation")] // One2many
    public virtual ICollection<IrModelFields> IrModelFields { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Model")] // One2many
    public virtual ICollection<IrModelInherit> IrModelInheritModel { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ParentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Parent")] // One2many
    public virtual ICollection<IrModelInherit> IrModelInheritParent { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("Model")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ModelNavigation")] // One2many
    public virtual ICollection<IrModelRelation> IrModelRelation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Model")] // One2many
    public virtual ICollection<IrRule> IrRule { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ResModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ResModelNavigation")] // One2many
    public virtual ICollection<MailActivity> MailActivity { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ResModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ResModelNavigation")] // One2many
    public virtual ICollection<MailActivityPlan> MailActivityPlan { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ResModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ResModelNavigation")] // One2many
    public virtual ICollection<MailActivitySchedule> MailActivitySchedule { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AliasModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AliasModel")] // One2many
    public virtual ICollection<MailAlias> MailAliasAliasModel { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AliasParentModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AliasParentModel")] // One2many
    public virtual ICollection<MailAlias> MailAliasAliasParentModel { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ModelNavigation")] // One2many
    public virtual ICollection<MailTemplate> MailTemplate { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MailingModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailingModel")] // One2many
    public virtual ICollection<MailingFilter> MailingFilter { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MailingModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailingModel")] // One2many
    public virtual ICollection<MailingMailing> MailingMailing { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ResModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ResModelNavigation")] // One2many
    public virtual ICollection<PrivacyLookupWizardLine> PrivacyLookupWizardLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ParentResModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ParentResModelNavigation")] // One2many
    public virtual ICollection<RatingRating> RatingRatingParentResModelNavigation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ResModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ResModelNavigation")] // One2many
    public virtual ICollection<RatingRating> RatingRatingResModelNavigation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ModelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ModelNavigation")] // One2many
    public virtual ICollection<SmsTemplate> SmsTemplate { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("WebsiteFormDefaultFieldId")]
    public virtual IrModelFields? WebsiteFormDefaultField { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("IrModelId")] //Many2many // Hidden
    // [InverseProperty("IrModel")] //Many2many // Hidden
    public virtual ICollection<SpreadsheetDashboard> SpreadsheetDashboard { get; set; }
}
