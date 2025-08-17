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

[Table("event_lead_rule")]
public partial class EventLeadRule: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("lead_sales_team_id")]
    public Guid? LeadSalesTeamId { get; set; }

    [Column("lead_user_id")]
    public Guid? LeadUserId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("lead_creation_basis")]
    public string? LeadCreationBasis { get; set; }

    [Column("lead_creation_trigger")]
    public string? LeadCreationTrigger { get; set; }

    [Column("lead_type")]
    public string? LeadType { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("event_registration_filter")]
    public string? EventRegistrationFilter { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("EventLeadRule")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("EventLeadRuleCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("EventLeadRuleId")]
    [InverseProperty("EventLeadRule")]
    public virtual ICollection<CrmLead> CrmLead { get; set; }

    // [Many2one]
    [ForeignKey("EventId")]
    // [InverseProperty("EventLeadRule")] //Many2one
    public virtual EventEvent? Event { get; set; }

    // [Many2one]
    [ForeignKey("LeadSalesTeamId")]
    // [InverseProperty("EventLeadRule")] //Many2one
    public virtual CrmTeam? LeadSalesTeam { get; set; }

    // [Many2one]
    [ForeignKey("LeadUserId")]
    // [InverseProperty("EventLeadRuleLeadUser")] //Many2one
    public virtual ResUsers? LeadUser { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("EventLeadRuleWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("EventLeadRuleId")] //Many2many
    // [InverseProperty("EventLeadRule")] //Many2many
    public virtual ICollection<CrmTag> CrmTag { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("EventLeadRuleId")] //Many2many
    // [InverseProperty("EventLeadRule")] //Many2many
    public virtual ICollection<EventType> EventType { get; set; }
}
