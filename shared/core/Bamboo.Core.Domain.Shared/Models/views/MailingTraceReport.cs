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
//[Keyless]
public partial class MailingTraceReport: Entity<Guid>, IMultiTenant
{
    [Column("id")]
    public Guid? Id { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }
    
    [Column("name", TypeName = "character varying")]
    public string? Name { get; set; }

    [Column("mailing_type", TypeName = "character varying")]
    public string? MailingType { get; set; }

    [Column("campaign", TypeName = "character varying")]
    public string? Campaign { get; set; }

    [Column("scheduled_date", TypeName = "timestamp without time zone")]
    public DateTime? ScheduledDate { get; set; }

    [Column("state", TypeName = "character varying")]
    public string? State { get; set; }

    [Column("email_from", TypeName = "character varying")]
    public string? EmailFrom { get; set; }

    [Column("scheduled")]
    public long? Scheduled { get; set; }

    [Column("sent")]
    public long? Sent { get; set; }

    [Column("delivered")]
    public long? Delivered { get; set; }

    [Column("error")]
    public long? Error { get; set; }

    [Column("bounced")]
    public long? Bounced { get; set; }

    [Column("canceled")]
    public long? Canceled { get; set; }

    [Column("opened")]
    public long? Opened { get; set; }

    [Column("replied")]
    public long? Replied { get; set; }

    [Column("clicked")]
    public long? Clicked { get; set; }
}
