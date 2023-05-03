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
public partial class IrActServer: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("binding_model_id")]
    public Guid? BindingModelId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("type")]
    public string? Type { get; set; }

    [Column("binding_type")]
    public string? BindingType { get; set; }

    [Column("binding_view_types")]
    public string? BindingViewTypes { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("help", TypeName = "jsonb")]
    public string? Help { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("model_id")]
    public Guid? ModelId { get; set; }

    [Column("crud_model_id")]
    public Guid? CrudModelId { get; set; }

    [Column("link_field_id")]
    public Guid? LinkFieldId { get; set; }

    [Column("usage")]
    public string? Usage { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("model_name")]
    public string? ModelName { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("template_id")]
    public Guid? TemplateId { get; set; }

    [Column("activity_type_id")]
    public long? ActivityTypeId { get; set; }

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

    [ForeignKey("ActivityTypeId")]
    //[InverseProperty("IrActServers")]
    [NotMapped]
    public virtual MailActivityType? ActivityType { get; set; }

    [ForeignKey("ActivityUserId")]
    //[InverseProperty("IrActServerActivityUsers")]
    [NotMapped]
    public virtual ResUser? ActivityUser { get; set; }

    [ForeignKey("BindingModelId")]
    //[InverseProperty("IrActServerBindingModels")]
    [NotMapped]
    public virtual IrModel? BindingModel { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("IrActServerCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CrudModelId")]
    //[InverseProperty("IrActServerCrudModels")]
    [NotMapped]
    public virtual IrModel? CrudModel { get; set; }

    [ForeignKey("LinkFieldId")]
    //[InverseProperty("IrActServers")]
    [NotMapped]
    public virtual IrModelField? LinkField { get; set; }

    [ForeignKey("ModelId")]
    //[InverseProperty("IrActServerModels")]
    [NotMapped]
    public virtual IrModel? Model { get; set; }

    [ForeignKey("SmsTemplateId")]
    //[InverseProperty("IrActServers")]
    [NotMapped]
    public virtual SmsTemplate? SmsTemplate { get; set; }

    [ForeignKey("TemplateId")]
    //[InverseProperty("IrActServers")]
    [NotMapped]
    public virtual MailTemplate? Template { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("IrActServerWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("IrActionsServer")]
    [NotMapped]
    public virtual ICollection<IrCron> IrCrons { get; } = new List<IrCron>();

    //[InverseProperty("Server")]
    [NotMapped]
    public virtual ICollection<IrServerObjectLine> IrServerObjectLines { get; } = new List<IrServerObjectLine>();

    //[InverseProperty("ActionServer")]
    [NotMapped]
    public virtual ICollection<WebsiteSnippetFilter> WebsiteSnippetFilters { get; } = new List<WebsiteSnippetFilter>();

    [ForeignKey("ServerId")]
    //[InverseProperty("Servers")]
    [NotMapped]
    public virtual ICollection<IrActServer> Actions { get; } = new List<IrActServer>();

    [ForeignKey("ActId")]
    //[InverseProperty("Acts")]
    [NotMapped]
    public virtual ICollection<ResGroup> Gids { get; } = new List<ResGroup>();

    [ForeignKey("IrActServerId")]
    //[InverseProperty("IrActServers")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartners { get; } = new List<ResPartner>();

    [ForeignKey("ActionId")]
    //[InverseProperty("Actions")]
    [NotMapped]
    public virtual ICollection<IrActServer> Servers { get; } = new List<IrActServer>();
}
