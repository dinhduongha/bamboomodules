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

[Table("sms_template")]
//[Index("Model", Name = "sms_template__model_index")]
public partial class SmsTemplate: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("model_id")]
    public Guid? ModelId { get; set; }

    [Column("sidebar_action_id")]
    public Guid? SidebarActionId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("template_fs")]
    public string? TemplateFs { get; set; }

    [Column("lang")]
    public string? Lang { get; set; }

    [Column("model")]
    public string? Model { get; set; }

    [JsonField(IsSparse = false)] // Name
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [JsonField] // Body
    [Column("body", TypeName = "jsonb")]
    public JsonElement? Body { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SmsTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SmsTemplate")] // One2many
    public virtual ICollection<CalendarAlarm> CalendarAlarm { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SmsTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SmsTemplate")] // One2many
    public virtual ICollection<IrActServer> IrActServer { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SmsTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SmsTemplate")] // One2many
    public virtual ICollection<MailingMailing> MailingMailing { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ModelId")]
    public virtual IrModel? ModelNavigation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SmsTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SmsTemplate")] // One2many
    public virtual ICollection<ProjectProjectStage> ProjectProjectStage { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SmsTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SmsTemplate")] // One2many
    public virtual ICollection<ProjectTaskType> ProjectTaskType { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("StockSmsConfirmationTemplateId")]
    [NotMapped] // One2many // Peer relationship (ResCompany) is commented out
    // [InverseProperty("StockSmsConfirmationTemplate")] // One2many
    public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SidebarActionId")]
    public virtual IrActWindow? SidebarAction { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Template")] // One2many
    public virtual ICollection<SmsComposer> SmsComposer { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SmsTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SmsTemplate")] // One2many
    public virtual ICollection<SmsTemplatePreview> SmsTemplatePreview { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("SmsTemplateId")] //Many2many // Hidden
    // [InverseProperty("SmsTemplate")] //Many2many // Hidden
    public virtual ICollection<SmsTemplateReset> SmsTemplateReset { get; set; }
}
