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

[Table("base_automation")]
public partial class BaseAutomation: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("action_server_id")]
    public Guid? ActionServerId { get; set; }

    [Column("model_id")]
    public Guid? ModelId { get; set; }

    [Column("trg_selection_field_id")]
    public Guid? TrgSelectionFieldId { get; set; }

    [Column("trg_field_ref")]
    public Guid? TrgFieldRef { get; set; }

    [Column("trg_date_id")]
    public Guid? TrgDateId { get; set; }

    [Column("trg_date_range")]
    public long? TrgDateRange { get; set; }

    [Column("trg_date_calendar_id")]
    public Guid? TrgDateCalendarId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("webhook_uuid")]
    public string? WebhookUuid { get; set; }

    [Column("record_getter")]
    public string? RecordGetter { get; set; }

    [Column("trigger")]
    public string? Trigger { get; set; }

    [Column("trg_date_range_type")]
    public string? TrgDateRangeType { get; set; }

    [Column("filter_pre_domain")]
    public string? FilterPreDomain { get; set; }

    [Column("filter_domain")]
    public string? FilterDomain { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("log_webhook_calls")]
    public bool? LogWebhookCalls { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("last_run", TypeName = "timestamp without time zone")]
    public DateTime? LastRun { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("ActionServerId")]
    // [InverseProperty("BaseAutomation")] //Many2one
    public virtual IrActServer? ActionServer { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("BaseAutomationCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("BaseAutomationId")]
    [InverseProperty("BaseAutomation")]
    public virtual ICollection<IrActServer> IrActServer { get; set; }

    // [Many2one]
    [ForeignKey("ModelId")]
    // [InverseProperty("BaseAutomation")] //Many2one
    public virtual IrModel? Model { get; set; }

    // [Many2one]
    [ForeignKey("TrgDateId")]
    // [InverseProperty("BaseAutomation")] //Many2one
    public virtual IrModelFields? TrgDate { get; set; }

    // [Many2one]
    [ForeignKey("TrgDateCalendarId")]
    // [InverseProperty("BaseAutomation")] //Many2one
    public virtual ResourceCalendar? TrgDateCalendar { get; set; }

    // [Many2one]
    [ForeignKey("TrgSelectionFieldId")]
    // [InverseProperty("BaseAutomation")] //Many2one
    public virtual IrModelFieldsSelection? TrgSelectionField { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("BaseAutomationWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("BaseAutomationId")] //Many2many
    // [InverseProperty("BaseAutomationNavigation")] //Many2many
    public virtual ICollection<IrModelFields> IrModelFields { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("BaseAutomationId")] //Many2many
    // [InverseProperty("BaseAutomation1")] //Many2many
    public virtual ICollection<IrModelFields> IrModelFieldsNavigation { get; set; }
}
