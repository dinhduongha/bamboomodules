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

[Table("mail_resend_partner")]
public partial class MailResendPartner: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("notification_id")]
    public Guid? NotificationId { get; set; }

    [Column("resend_wizard_id")]
    public Guid? ResendWizardId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("message")]
    public string? Message { get; set; }

    [Column("resend")]
    public bool? Resend { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("NotificationId")]
    public virtual MailNotification? Notification { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ResendWizardId")]
    public virtual MailResendMessage? ResendWizard { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
