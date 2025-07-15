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
public partial class IrModel: FullAuditedEntity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("model")]
    public string? Model { get; set; }

    [Column("order")]
    public string? Order { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("info")]
    public string? Info { get; set; }

    [Column("transient")]
    public bool? Transient { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

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

    //[InverseProperty("Model")]
    [NotMapped]
    public virtual ICollection<BaseLanguageExport> BaseLanguageExports { get; set; } = new List<BaseLanguageExport>();

    //[InverseProperty("ResModelNavigation")]
    [NotMapped]
    public virtual ICollection<CalendarEvent> CalendarEvents { get; set; } = new List<CalendarEvent>();

    [ForeignKey("CreatorId")]
    //[InverseProperty("IrModelCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("ResModel")]
    [NotMapped]
    public virtual ICollection<DataRecycleModel> DataRecycleModels { get; set; } = new List<DataRecycleModel>();

    //[InverseProperty("ResModel")]
    [NotMapped]
    public virtual ICollection<DataRecycleRecord> DataRecycleRecords { get; set; } = new List<DataRecycleRecord>();

    //[InverseProperty("Model")]
    [NotMapped]
    public virtual ICollection<GamificationGoalDefinition> GamificationGoalDefinitions { get; set; } = new List<GamificationGoalDefinition>();

    //[InverseProperty("Object")]
    [NotMapped]
    public virtual ICollection<FetchmailServer> FetchmailServers { get; set; } = new List<FetchmailServer>();

    //[InverseProperty("BindingModel")]
    [NotMapped]
    public virtual ICollection<IrActClient> IrActClients { get; set; } = new List<IrActClient>();

    //[InverseProperty("BindingModel")]
    [NotMapped]
    public virtual ICollection<IrActReportXml> IrActReportXmls { get; set; } = new List<IrActReportXml>();

    //[InverseProperty("BindingModel")]
    [NotMapped]
    public virtual ICollection<IrActServer> IrActServerBindingModels { get; set; } = new List<IrActServer>();

    //[InverseProperty("CrudModel")]
    [NotMapped]
    public virtual ICollection<IrActServer> IrActServerCrudModels { get; set; } = new List<IrActServer>();

    //[InverseProperty("Model")]
    [NotMapped]
    public virtual ICollection<IrActServer> IrActServerModels { get; set; } = new List<IrActServer>();

    //[InverseProperty("UpdateRelatedModel")]
    [NotMapped]
    public virtual ICollection<IrActServer> IrActServerUpdateRelatedModels { get; set; } = new List<IrActServer>();

    //[InverseProperty("BindingModel")]
    [NotMapped]
    public virtual ICollection<IrActUrl> IrActUrls { get; set; } = new List<IrActUrl>();

    //[InverseProperty("BindingModel")]
    [NotMapped]
    public virtual ICollection<IrActWindow> IrActWindows { get; set; } = new List<IrActWindow>();

    //[InverseProperty("BindingModel")]
    [NotMapped]
    public virtual ICollection<IrAction> IrActions { get; set; } = new List<IrAction>();

    //[InverseProperty("Model")]
    [NotMapped]
    public virtual ICollection<IrModelAccess> IrModelAccesses { get; set; } = new List<IrModelAccess>();

    //[InverseProperty("ModelNavigation")]
    [NotMapped]
    public virtual ICollection<IrModelConstraint> IrModelConstraints { get; set; } = new List<IrModelConstraint>();

    //[InverseProperty("ModelNavigation")]
    [NotMapped]
    public virtual ICollection<IrModelField> IrModelFields { get; set; } = new List<IrModelField>();

    //[InverseProperty("Model")]
    [NotMapped]
    public virtual ICollection<IrModelInherit> IrModelInheritModels { get; set; } = new List<IrModelInherit>();

    //[InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<IrModelInherit> IrModelInheritParents { get; set; } = new List<IrModelInherit>();

    //[InverseProperty("ModelNavigation")]
    [NotMapped]
    public virtual ICollection<IrModelRelation> IrModelRelations { get; set; } = new List<IrModelRelation>();

    //[InverseProperty("Model")]
    [NotMapped]
    public virtual ICollection<IrRule> IrRules { get; set; } = new List<IrRule>();

    //[InverseProperty("ResModelNavigation")]
    [NotMapped]
    public virtual ICollection<MailActivity> MailActivities { get; set; } = new List<MailActivity>();

    //[InverseProperty("ResModelNavigation")]
    [NotMapped]
    public virtual ICollection<MailActivityPlan> MailActivityPlans { get; set; } = new List<MailActivityPlan>();

    //[InverseProperty("ResModelNavigation")]
    [NotMapped]
    public virtual ICollection<MailActivitySchedule> MailActivitySchedules { get; set; } = new List<MailActivitySchedule>();

    //[InverseProperty("AliasModel")]
    [NotMapped]
    public virtual ICollection<MailAlias> MailAliasAliasModels { get; set; } = new List<MailAlias>();

    //[InverseProperty("AliasParentModel")]
    [NotMapped]
    public virtual ICollection<MailAlias> MailAliasAliasParentModels { get; set; } = new List<MailAlias>();

    //[InverseProperty("ModelNavigation")]
    [NotMapped]
    public virtual ICollection<MailTemplate> MailTemplates { get; set; } = new List<MailTemplate>();

    //[InverseProperty("MailingModel")]
    [NotMapped]
    public virtual ICollection<MailingFilter> MailingFilters { get; set; } = new List<MailingFilter>();

    //[InverseProperty("MailingModel")]
    [NotMapped]
    public virtual ICollection<MailingMailing> MailingMailings { get; set; } = new List<MailingMailing>();

    // v16-Compat
    //[InverseProperty("CallbackModel")]
    [NotMapped]
    public virtual ICollection<PaymentTransaction> PaymentTransactions { get; set; } = new List<PaymentTransaction>();

    //[InverseProperty("ResModelNavigation")]
    [NotMapped]
    public virtual ICollection<PrivacyLookupWizardLine> PrivacyLookupWizardLines { get; set; } = new List<PrivacyLookupWizardLine>();

    //[InverseProperty("ParentResModelNavigation")]
    [NotMapped]
    public virtual ICollection<RatingRating> RatingRatingParentResModelNavigations { get; set; } = new List<RatingRating>();

    //[InverseProperty("ResModelNavigation")]
    [NotMapped]
    public virtual ICollection<RatingRating> RatingRatingResModelNavigations { get; set; } = new List<RatingRating>();

    //[InverseProperty("ModelNavigation")]
    [NotMapped]
    public virtual ICollection<SmsTemplate> SmsTemplates { get; set; } = new List<SmsTemplate>();

    [ForeignKey("WebsiteFormDefaultFieldId")]
    //[InverseProperty("IrModels")]
    [NotMapped]
    public virtual IrModelField? WebsiteFormDefaultField { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("IrModelWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("IrModelId")]
    //[InverseProperty("IrModels")]
    [NotMapped]
    public virtual ICollection<SpreadsheetDashboard> SpreadsheetDashboards { get; set; } = new List<SpreadsheetDashboard>();
}
