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

[Table("sms_template")]
//[Index("Model", Name = "sms_template_model_index")]
public partial class SmsTemplate : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("model_id")]
    public Guid? ModelId { get; set; }

    [Column("sidebar_action_id")]
    public Guid? SidebarActionId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("template_fs")]
    public string? TemplateFs { get; set; }

    [Column("lang")]
    public string? Lang { get; set; }

    [Column("model")]
    public string? Model { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [JsonField]
    [Column("body", TypeName = "jsonb")]
    public string? Body { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SmsTemplateCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ModelId")]
    //[InverseProperty("SmsTemplates")]
    [NotMapped]
    public virtual IrModel? ModelNavigation { get; set; }

    [ForeignKey("SidebarActionId")]
    //[InverseProperty("SmsTemplates")]
    [NotMapped]
    public virtual IrActWindow? SidebarAction { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SmsTemplateWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    /// TODO: DISABLE INVERSE COLLECTIONS
    //[InverseProperty("SmsTemplate")]
    [NotMapped]
    public virtual ICollection<CalendarAlarm> CalendarAlarms { get; set; } = new List<CalendarAlarm>();

    //[InverseProperty("SmsTemplate")]
    [NotMapped]
    public virtual ICollection<IrActServer> IrActServers { get; set; } = new List<IrActServer>();

    //[InverseProperty("SmsTemplate")]
    [NotMapped]
    public virtual ICollection<ProjectProjectStage> ProjectProjectStages { get; set; } = new List<ProjectProjectStage>();

    //[InverseProperty("SmsTemplate")]
    [NotMapped]
    public virtual ICollection<ProjectTaskType> ProjectTaskTypes { get; set; } = new List<ProjectTaskType>();

    //[InverseProperty("StockSmsConfirmationTemplate")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanies { get; set; } = new List<ResCompany>();

    //[InverseProperty("Template")]
    [NotMapped]
    public virtual ICollection<SmsComposer> SmsComposers { get; set; } = new List<SmsComposer>();

    //[InverseProperty("SmsTemplate")]
    [NotMapped]
    public virtual ICollection<SmsTemplatePreview> SmsTemplatePreviews { get; set; } = new List<SmsTemplatePreview>();

    [ForeignKey("SmsTemplateId")]
    //[InverseProperty("SmsTemplates")]
    [NotMapped]
    public virtual ICollection<SmsTemplateReset> SmsTemplateResets { get; set; } = new List<SmsTemplateReset>();
}
