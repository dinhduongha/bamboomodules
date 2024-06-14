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
public partial class CalendarProviderConfig: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("CalendarProviderConfigCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("CalendarProviderConfigWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
