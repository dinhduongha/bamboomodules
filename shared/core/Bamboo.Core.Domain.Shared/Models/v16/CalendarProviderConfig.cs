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

[Table("calendar_provider_config")]
public partial class CalendarProviderConfig: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("external_calendar_provider")]
    public string? ExternalCalendarProvider { get; set; }

    [Column("cal_client_id")]
    public string? CalClientId { get; set; }

    [Column("cal_client_secret")]
    public string? CalClientSecret { get; set; }

    [Column("microsoft_outlook_client_identifier")]
    public string? MicrosoftOutlookClientIdentifier { get; set; }

    [Column("microsoft_outlook_client_secret")]
    public string? MicrosoftOutlookClientSecret { get; set; }

    [Column("cal_sync_paused")]
    public bool? CalSyncPaused { get; set; }

    [Column("microsoft_outlook_sync_paused")]
    public bool? MicrosoftOutlookSyncPaused { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
