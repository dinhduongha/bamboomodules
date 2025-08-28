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

[Table("mail_activity_type")]
//[Index("CreateUid", Name = "mail_activity_type__create_uid_index")]
public partial class MailActivityType: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("delay_count")]
    public long? DelayCount { get; set; }

    [Column("triggered_next_type_id")]
    public Guid? TriggeredNextTypeId { get; set; }

    [Column("default_user_id")]
    public Guid? DefaultUserId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("delay_unit")]
    public string? DelayUnit { get; set; }

    [Column("delay_from")]
    public string? DelayFrom { get; set; }

    [Column("icon")]
    public string? Icon { get; set; }

    [Column("decoration_type")]
    public string? DecorationType { get; set; }

    [Column("res_model")]
    public string? ResModel { get; set; }

    [Column("chaining_type")]
    public string? ChainingType { get; set; }

    [Column("category")]
    public string? Category { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [JsonField]
    [Column("summary", TypeName = "jsonb")]
    public string? Summary { get; set; }

    [JsonField]
    [Column("default_note", TypeName = "jsonb")]
    public string? DefaultNote { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("keep_done")]
    public bool? KeepDone { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("DefaultUserId")]
    public virtual ResUsers? DefaultUser { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("TriggeredNextTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("TriggeredNextType")] // One2many
    public virtual ICollection<MailActivityType> InverseTriggeredNextType { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ActivityTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ActivityType")] // One2many
    public virtual ICollection<IrActServer> IrActServer { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ActivityTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ActivityType")] // One2many
    public virtual ICollection<MailActivity> MailActivityActivityType { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ActivityTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ActivityType")] // One2many
    public virtual ICollection<MailActivityPlanTemplate> MailActivityPlanTemplate { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("PreviousActivityTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PreviousActivityType")] // One2many
    public virtual ICollection<MailActivity> MailActivityPreviousActivityType { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("RecommendedActivityTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("RecommendedActivityType")] // One2many
    public virtual ICollection<MailActivity> MailActivityRecommendedActivityType { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ActivityTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ActivityType")] // One2many
    public virtual ICollection<MailActivitySchedule> MailActivitySchedule { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MailActivityTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailActivityType")] // One2many
    public virtual ICollection<MailComposeMessage> MailComposeMessage { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MailActivityTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailActivityType")] // One2many
    public virtual ICollection<MailMessage> MailMessage { get; set; }

    // [Many2one]
    [ForeignKey("TriggeredNextTypeId")]
    public virtual MailActivityType? TriggeredNextType { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("RecommendedId")] // Many2many // Normal
    // [InverseProperty("Recommended")] // Many2many // Normal
    public virtual ICollection<MailActivityType> Activity { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("MailActivityTypeId")] // Many2many // Normal
    // [InverseProperty("MailActivityType")] // Many2many // Normal
    public virtual ICollection<MailTemplate> MailTemplate { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ActivityId")] // Many2many // Normal
    // [InverseProperty("Activity")] // Many2many // Normal
    public virtual ICollection<MailActivityType> Recommended { get; set; }
}
