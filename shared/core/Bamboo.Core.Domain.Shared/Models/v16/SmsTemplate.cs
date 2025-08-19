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

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [JsonField]
    [Column("body", TypeName = "jsonb")]
    public string? Body { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many]
    [ForeignKey("SmsTemplateId")]
    [InverseProperty("SmsTemplate")]
    public virtual ICollection<CalendarAlarm> CalendarAlarm { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("SmsTemplateCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("SmsTemplateId")]
    [InverseProperty("SmsTemplate")]
    public virtual ICollection<IrActServer> IrActServer { get; set; }

    // [One2many]
    [ForeignKey("SmsTemplateId")]
    [InverseProperty("SmsTemplate")]
    public virtual ICollection<MailingMailing> MailingMailing { get; set; }

    // [Many2one]
    [ForeignKey("ModelId")]
    // [InverseProperty("SmsTemplate")] //Many2one
    public virtual IrModel? ModelNavigation { get; set; }

    // [One2many]
    [ForeignKey("SmsTemplateId")]
    [InverseProperty("SmsTemplate")]
    public virtual ICollection<ProjectProjectStage> ProjectProjectStage { get; set; }

    // [One2many]
    [ForeignKey("SmsTemplateId")]
    [InverseProperty("SmsTemplate")]
    public virtual ICollection<ProjectTaskType> ProjectTaskType { get; set; }

    // [One2many]
    [ForeignKey("StockSmsConfirmationTemplateId")]
    [InverseProperty("StockSmsConfirmationTemplate")]
    public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [Many2one]
    [ForeignKey("SidebarActionId")]
    // [InverseProperty("SmsTemplate")] //Many2one
    public virtual IrActWindow? SidebarAction { get; set; }

    // [One2many]
    [ForeignKey("TemplateId")]
    [InverseProperty("Template")]
    public virtual ICollection<SmsComposer> SmsComposer { get; set; }

    // [One2many]
    [ForeignKey("SmsTemplateId")]
    [InverseProperty("SmsTemplate")]
    public virtual ICollection<SmsTemplatePreview> SmsTemplatePreview { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("SmsTemplateWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("SmsTemplateId")]
    // [InverseProperty("SmsTemplate")]
    public virtual ICollection<SmsTemplateReset> SmsTemplateReset { get; set; }
}
