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

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

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
    [ForeignKey("ModelId")]
    [InverseProperty("Model")]
    public virtual ICollection<BaseAutomation> BaseAutomation { get; set; }

    // [One2many]
    [ForeignKey("ModelId")]
    [InverseProperty("Model")]
    public virtual ICollection<BaseLanguageExport> BaseLanguageExport { get; set; }

    // [One2many]
    [ForeignKey("ResModelId")]
    [InverseProperty("ResModelNavigation")]
    public virtual ICollection<CalendarEvent> CalendarEvent { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("IrModelCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("ResModelId")]
    [InverseProperty("ResModel")]
    public virtual ICollection<DataRecycleModel> DataRecycleModel { get; set; }

    // [One2many]
    [ForeignKey("ResModelId")]
    [InverseProperty("ResModel")]
    public virtual ICollection<DataRecycleRecord> DataRecycleRecord { get; set; }

    // [One2many]
    [ForeignKey("ObjectId")]
    [InverseProperty("Object")]
    public virtual ICollection<FetchmailServer> FetchmailServer { get; set; }

    // [One2many]
    [ForeignKey("ModelId")]
    [InverseProperty("Model")]
    public virtual ICollection<GamificationGoalDefinition> GamificationGoalDefinition { get; set; }

    // [One2many]
    [ForeignKey("BindingModelId")]
    [InverseProperty("BindingModel")]
    public virtual ICollection<IrActClient> IrActClient { get; set; }

    // [One2many]
    [ForeignKey("BindingModelId")]
    [InverseProperty("BindingModel")]
    public virtual ICollection<IrActReportXml> IrActReportXml { get; set; }

    // [One2many]
    [ForeignKey("BindingModelId")]
    [InverseProperty("BindingModel")]
    public virtual ICollection<IrActServer> IrActServerBindingModel { get; set; }

    // [One2many]
    [ForeignKey("CrudModelId")]
    [InverseProperty("CrudModel")]
    public virtual ICollection<IrActServer> IrActServerCrudModel { get; set; }

    // [One2many]
    [ForeignKey("ModelId")]
    [InverseProperty("Model")]
    public virtual ICollection<IrActServer> IrActServerModel { get; set; }

    // [One2many]
    [ForeignKey("UpdateRelatedModelId")]
    [InverseProperty("UpdateRelatedModel")]
    public virtual ICollection<IrActServer> IrActServerUpdateRelatedModel { get; set; }

    // [One2many]
    [ForeignKey("BindingModelId")]
    [InverseProperty("BindingModel")]
    public virtual ICollection<IrActionsActUrl> IrActionsActUrl { get; set; }

    // [One2many]
    [ForeignKey("BindingModelId")]
    [InverseProperty("BindingModel")]
    public virtual ICollection<IrActWindow> IrActWindow { get; set; }

    // [One2many]
    [ForeignKey("BindingModelId")]
    [InverseProperty("BindingModel")]
    public virtual ICollection<IrActions> IrActions { get; set; }

    // [One2many]
    [ForeignKey("ModelId")]
    [InverseProperty("Model")]
    public virtual ICollection<IrModelAccess> IrModelAccess { get; set; }

    // [One2many]
    [ForeignKey("Model")]
    [InverseProperty("ModelNavigation")]
    public virtual ICollection<IrModelConstraint> IrModelConstraint { get; set; }

    // [One2many]
    [ForeignKey("ModelId")]
    [InverseProperty("ModelNavigation")]
    public virtual ICollection<IrModelFields> IrModelFields { get; set; }

    // [One2many]
    [ForeignKey("ModelId")]
    [InverseProperty("Model")]
    public virtual ICollection<IrModelInherit> IrModelInheritModel { get; set; }

    // [One2many]
    [ForeignKey("ParentId")]
    [InverseProperty("Parent")]
    public virtual ICollection<IrModelInherit> IrModelInheritParent { get; set; }

    // [One2many]
    [ForeignKey("Model")]
    [InverseProperty("ModelNavigation")]
    public virtual ICollection<IrModelRelation> IrModelRelation { get; set; }

    // [One2many]
    [ForeignKey("ModelId")]
    [InverseProperty("Model")]
    public virtual ICollection<IrRule> IrRule { get; set; }

    // [One2many]
    [ForeignKey("ResModelId")]
    [InverseProperty("ResModelNavigation")]
    public virtual ICollection<MailActivity> MailActivity { get; set; }

    // [One2many]
    [ForeignKey("ResModelId")]
    [InverseProperty("ResModelNavigation")]
    public virtual ICollection<MailActivityPlan> MailActivityPlan { get; set; }

    // [One2many]
    [ForeignKey("ResModelId")]
    [InverseProperty("ResModelNavigation")]
    public virtual ICollection<MailActivitySchedule> MailActivitySchedule { get; set; }

    // [One2many]
    [ForeignKey("AliasModelId")]
    [InverseProperty("AliasModel")]
    public virtual ICollection<MailAlias> MailAliasAliasModel { get; set; }

    // [One2many]
    [ForeignKey("AliasParentModelId")]
    [InverseProperty("AliasParentModel")]
    public virtual ICollection<MailAlias> MailAliasAliasParentModel { get; set; }

    // [One2many]
    [ForeignKey("ModelId")]
    [InverseProperty("ModelNavigation")]
    public virtual ICollection<MailTemplate> MailTemplate { get; set; }

    // [One2many]
    [ForeignKey("MailingModelId")]
    [InverseProperty("MailingModel")]
    public virtual ICollection<MailingFilter> MailingFilter { get; set; }

    // [One2many]
    [ForeignKey("MailingModelId")]
    [InverseProperty("MailingModel")]
    public virtual ICollection<MailingMailing> MailingMailing { get; set; }

    // [One2many]
    [ForeignKey("CallbackModelId")]
    [InverseProperty("CallbackModel")]
    public virtual ICollection<PaymentTransaction> PaymentTransaction { get; set; }

    // [One2many]
    [ForeignKey("ResModelId")]
    [InverseProperty("ResModelNavigation")]
    public virtual ICollection<PrivacyLookupWizardLine> PrivacyLookupWizardLine { get; set; }

    // [One2many]
    [ForeignKey("ParentResModelId")]
    [InverseProperty("ParentResModelNavigation")]
    public virtual ICollection<RatingRating> RatingRatingParentResModelNavigation { get; set; }

    // [One2many]
    [ForeignKey("ResModelId")]
    [InverseProperty("ResModelNavigation")]
    public virtual ICollection<RatingRating> RatingRatingResModelNavigation { get; set; }

    // [One2many]
    [ForeignKey("ModelId")]
    [InverseProperty("ModelNavigation")]
    public virtual ICollection<SmsTemplate> SmsTemplate { get; set; }

    // [Many2one]
    [ForeignKey("WebsiteFormDefaultFieldId")]
    // [InverseProperty("IrModel")] //Many2one
    public virtual IrModelFields? WebsiteFormDefaultField { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("IrModelWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("IrModelId")]
    // [InverseProperty("IrModel")]
    // public virtual ICollection<SpreadsheetDashboard> SpreadsheetDashboard { get; set; }
}
