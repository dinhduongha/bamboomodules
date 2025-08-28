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

[Table("event_lead_request")]
//[Index("EventId", Name = "event_lead_request_uniq_event", IsUnique = true)]
public partial class EventLeadRequest: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("event_id")]
    public Guid? EventId { get; set; }

    [Column("processed_registration_id")]
    public Guid? ProcessedRegistrationId { get; set; }

    // [Many2one]
    [ForeignKey("EventId")]
    public virtual EventEvent? Event { get; set; }
}
