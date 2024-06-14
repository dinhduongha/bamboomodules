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
public partial class IrModel: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

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
    public DateTime? CreationTime { get; set; }

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

    [ForeignKey("CreatorId")]
    //[InverseProperty("IrModelCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("WebsiteFormDefaultFieldId")]
    //[InverseProperty("IrModels")]
    [NotMapped]
    public virtual IrModelField? WebsiteFormDefaultField { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("IrModelWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("ResModelNavigation")]
    [NotMapped]
    public virtual ICollection<CalendarEvent> CalendarEvents { get; } = new List<CalendarEvent>();

    //[InverseProperty("Object")]
    [NotMapped]
    public virtual ICollection<FetchmailServer> FetchmailServers { get; } = new List<FetchmailServer>();

    //[InverseProperty("BindingModel")]
    [NotMapped]
    public virtual ICollection<IrActClient> IrActClients { get; } = new List<IrActClient>();

    //[InverseProperty("BindingModel")]
    [NotMapped]
    public virtual ICollection<IrActReportXml> IrActReportXmls { get; } = new List<IrActReportXml>();

    //[InverseProperty("BindingModel")]
    [NotMapped]
    public virtual ICollection<IrActServer> IrActServerBindingModels { get; } = new List<IrActServer>();

    //[InverseProperty("CrudModel")]
    [NotMapped]
    public virtual ICollection<IrActServer> IrActServerCrudModels { get; } = new List<IrActServer>();

    //[InverseProperty("Model")]
    [NotMapped]
    public virtual ICollection<IrActServer> IrActServerModels { get; } = new List<IrActServer>();

    //[InverseProperty("BindingModel")]
    [NotMapped]
    public virtual ICollection<IrActUrl> IrActUrls { get; } = new List<IrActUrl>();

    //[InverseProperty("BindingModel")]
    [NotMapped]
    public virtual ICollection<IrActWindow> IrActWindows { get; } = new List<IrActWindow>();

    //[InverseProperty("BindingModel")]
    [NotMapped]
    public virtual ICollection<IrAction> IrActions { get; } = new List<IrAction>();

    //[InverseProperty("Model")]
    [NotMapped]
    public virtual ICollection<IrModelAccess> IrModelAccesses { get; } = new List<IrModelAccess>();

    //[InverseProperty("ModelNavigation")]
    [NotMapped]
    public virtual ICollection<IrModelConstraint> IrModelConstraints { get; } = new List<IrModelConstraint>();

    //[InverseProperty("ModelNavigation")]
    [NotMapped]
    public virtual ICollection<IrModelField> IrModelFields { get; } = new List<IrModelField>();

    //[InverseProperty("ModelNavigation")]
    [NotMapped]
    public virtual ICollection<IrModelRelation> IrModelRelations { get; } = new List<IrModelRelation>();

    //[InverseProperty("Model")]
    [NotMapped]
    public virtual ICollection<IrRule> IrRules { get; } = new List<IrRule>();

    //[InverseProperty("ResModelNavigation")]
    [NotMapped]
    public virtual ICollection<MailActivity> MailActivities { get; } = new List<MailActivity>();

    //[InverseProperty("AliasModel")]
    [NotMapped]
    public virtual ICollection<MailAlias> MailAliasAliasModels { get; } = new List<MailAlias>();

    //[InverseProperty("AliasParentModel")]
    [NotMapped]
    public virtual ICollection<MailAlias> MailAliasAliasParentModels { get; } = new List<MailAlias>();

    //[InverseProperty("ModelNavigation")]
    [NotMapped]
    public virtual ICollection<MailTemplate> MailTemplates { get; } = new List<MailTemplate>();

    //[InverseProperty("CallbackModel")]
    [NotMapped]
    public virtual ICollection<PaymentTransaction> PaymentTransactions { get; } = new List<PaymentTransaction>();

    //[InverseProperty("ResModelNavigation")]
    [NotMapped]
    public virtual ICollection<PrivacyLookupWizardLine> PrivacyLookupWizardLines { get; } = new List<PrivacyLookupWizardLine>();

    //[InverseProperty("ParentResModelNavigation")]
    [NotMapped]
    public virtual ICollection<RatingRating> RatingRatingParentResModelNavigations { get; } = new List<RatingRating>();

    //[InverseProperty("ResModelNavigation")]
    [NotMapped]
    public virtual ICollection<RatingRating> RatingRatingResModelNavigations { get; } = new List<RatingRating>();

    //[InverseProperty("ModelNavigation")]
    [NotMapped]
    public virtual ICollection<SmsTemplate> SmsTemplates { get; } = new List<SmsTemplate>();

}
