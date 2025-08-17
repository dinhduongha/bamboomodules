using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

//[Keyless]
public partial class CrmActivityReport: Entity<Guid>, IMultiTenant
{
    [Column("id")]
    public Guid? Id { get; set; }

    [Column("lead_create_date", TypeName = "timestamp without time zone")]
    public DateTime? LeadCreateDate { get; set; }

    [Column("date_conversion", TypeName = "timestamp without time zone")]
    public DateTime? DateConversion { get; set; }

    [Column("date_deadline")]
    public DateTime? DateDeadline { get; set; }

    [Column("date_closed", TypeName = "timestamp without time zone")]
    public DateTime? DateClosed { get; set; }

    [Column("subtype_id")]
    public Guid? SubtypeId { get; set; }

    [Column("mail_activity_type_id")]
    public Guid? MailActivityTypeId { get; set; }

    [Column("author_id")]
    public Guid? AuthorId { get; set; }

    [Column("date", TypeName = "timestamp without time zone")]
    public DateTime? Date { get; set; }

    [Column("body")]
    public string? Body { get; set; }

    [Column("lead_id")]
    public Guid? LeadId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("team_id")]
    public Guid? TeamId { get; set; }

    [Column("country_id")]
    public Guid? CountryId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("stage_id")]
    public Guid? StageId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("lead_type", TypeName = "character varying")]
    public string? LeadType { get; set; }

    [Column("active")]
    public bool? Active { get; set; }
}
