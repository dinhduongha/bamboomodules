using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bamboo.Core.Domain.Shared.Attributes;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Module("base")]
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
    public override Guid? LastModifierId { get; set; }

    [Column("model")]
    public string? Model { get; set; }

    [Column("order")]
    public string? Order { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [Column("info")]
    public string? Info { get; set; }

    [Column("transient")]
    public bool? Transient { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

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


    [ForeignKey("CreatorId")]
    //[InverseProperty("IrModelCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("WebsiteFormDefaultFieldId")]
    //[InverseProperty("IrModels")]
    [NotMapped]
    public virtual IrModelFields? WebsiteFormDefaultField { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("IrModelWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Model")]
    [NotMapped]
    public virtual ICollection<BaseLanguageExport> BaseLanguageExports { get; set; } 

    //[InverseProperty("ResModelNavigation")]
    [NotMapped]
    public virtual ICollection<CalendarEvent> CalendarEvents { get; set; } 

    //[InverseProperty("ResModel")]
    [NotMapped]
    public virtual ICollection<DataRecycleModel> DataRecycleModels { get; set; } 

    //[InverseProperty("ResModel")]
    [NotMapped]
    public virtual ICollection<DataRecycleRecord> DataRecycleRecords { get; set; } 

    //[InverseProperty("Model")]
    [NotMapped]
    public virtual ICollection<GamificationGoalDefinition> GamificationGoalDefinitions { get; set; } 

    //[InverseProperty("Object")]
    [NotMapped]
    public virtual ICollection<FetchmailServer> FetchmailServers { get; set; } 

    //[InverseProperty("BindingModel")]
    [NotMapped]
    public virtual ICollection<IrActClient> IrActClients { get; set; } 

    //[InverseProperty("BindingModel")]
    [NotMapped]
    public virtual ICollection<IrActReportXml> IrActReportXmls { get; set; } 

    //[InverseProperty("BindingModel")]
    [NotMapped]
    public virtual ICollection<IrActServer> IrActServerBindingModels { get; set; } 

    //[InverseProperty("CrudModel")]
    [NotMapped]
    public virtual ICollection<IrActServer> IrActServerCrudModels { get; set; } 

    //[InverseProperty("Model")]
    [NotMapped]
    public virtual ICollection<IrActServer> IrActServerModels { get; set; } 

    //[InverseProperty("UpdateRelatedModel")]
    [NotMapped]
    public virtual ICollection<IrActServer> IrActServerUpdateRelatedModels { get; set; } 

    //[InverseProperty("BindingModel")]
    [NotMapped]
    public virtual ICollection<IrActUrl> IrActUrls { get; set; } 

    //[InverseProperty("BindingModel")]
    [NotMapped]
    public virtual ICollection<IrActWindow> IrActWindows { get; set; } 

    //[InverseProperty("BindingModel")]
    [NotMapped]
    public virtual ICollection<IrAction> IrActions { get; set; } 

    //[InverseProperty("Model")]
    [NotMapped]
    public virtual ICollection<IrModelAccess> IrModelAccesses { get; set; } 

    //[InverseProperty("ModelNavigation")]
    [NotMapped]
    public virtual ICollection<IrModelConstraint> IrModelConstraints { get; set; } 

    //[InverseProperty("ModelNavigation")]
    [NotMapped]
    public virtual ICollection<IrModelFields> IrModelFields { get; set; } 

    //[InverseProperty("Model")]
    [NotMapped]
    public virtual ICollection<IrModelInherit> IrModelInheritModels { get; set; } 

    //[InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<IrModelInherit> IrModelInheritParents { get; set; } 

    //[InverseProperty("ModelNavigation")]
    [NotMapped]
    public virtual ICollection<IrModelRelation> IrModelRelations { get; set; } 

    //[InverseProperty("Model")]
    [NotMapped]
    public virtual ICollection<IrRule> IrRules { get; set; } 

    //[InverseProperty("ResModelNavigation")]
    [NotMapped]
    public virtual ICollection<MailActivity> MailActivities { get; set; } 

    //[InverseProperty("ResModelNavigation")]
    [NotMapped]
    public virtual ICollection<MailActivityPlan> MailActivityPlans { get; set; } 

    //[InverseProperty("ResModelNavigation")]
    [NotMapped]
    public virtual ICollection<MailActivitySchedule> MailActivitySchedules { get; set; } 

    //[InverseProperty("AliasModel")]
    [NotMapped]
    public virtual ICollection<MailAlias> MailAliasAliasModels { get; set; } 

    //[InverseProperty("AliasParentModel")]
    [NotMapped]
    public virtual ICollection<MailAlias> MailAliasAliasParentModels { get; set; } 

    //[InverseProperty("ModelNavigation")]
    [NotMapped]
    public virtual ICollection<MailTemplate> MailTemplates { get; set; } 

    //[InverseProperty("MailingModel")]
    [NotMapped]
    public virtual ICollection<MailingFilter> MailingFilters { get; set; } 

    //[InverseProperty("MailingModel")]
    [NotMapped]
    public virtual ICollection<MailingMailing> MailingMailings { get; set; } 

    // v16-Compat
    //[InverseProperty("CallbackModel")]
    [NotMapped]
    public virtual ICollection<PaymentTransaction> PaymentTransactions { get; set; } 

    //[InverseProperty("ResModelNavigation")]
    [NotMapped]
    public virtual ICollection<PrivacyLookupWizardLine> PrivacyLookupWizardLines { get; set; } 

    //[InverseProperty("ParentResModelNavigation")]
    [NotMapped]
    public virtual ICollection<RatingRating> RatingRatingParentResModelNavigations { get; set; } 

    //[InverseProperty("ResModelNavigation")]
    [NotMapped]
    public virtual ICollection<RatingRating> RatingRatingResModelNavigations { get; set; } 

    //[InverseProperty("ModelNavigation")]
    [NotMapped]
    public virtual ICollection<SmsTemplate> SmsTemplates { get; set; } 


    [ForeignKey("IrModelId")]
    //[InverseProperty("IrModels")]
    [NotMapped]
    public virtual ICollection<SpreadsheetDashboard> SpreadsheetDashboards { get; set; } 
}
