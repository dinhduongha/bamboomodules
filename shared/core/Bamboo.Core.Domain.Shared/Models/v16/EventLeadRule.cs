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
public partial class EventLeadRule: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("event_id")]
    public Guid? EventId { get; set; }

    [Column("lead_sales_team_id")]
    public Guid? LeadSalesTeamId { get; set; }

    [Column("lead_user_id")]
    public Guid? LeadUserId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("lead_creation_basis")]
    public string? LeadCreationBasis { get; set; }

    [Column("lead_creation_trigger")]
    public string? LeadCreationTrigger { get; set; }

    [Column("lead_type")]
    public string? LeadType { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [Column("event_registration_filter")]
    public string? EventRegistrationFilter { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CompanyId")]
    //[InverseProperty("EventLeadRules")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("EventLeadRuleCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("EventLeadRule")]
    [NotMapped]
    public virtual ICollection<CrmLead> CrmLeads { get; set; } = new List<CrmLead>();

    [ForeignKey("EventId")]
    //[InverseProperty("EventLeadRules")]
    [NotMapped]
    public virtual EventEvent? Event { get; set; }

    [ForeignKey("LeadSalesTeamId")]
    //[InverseProperty("EventLeadRules")]
    [NotMapped]
    public virtual CrmTeam? LeadSalesTeam { get; set; }

    [ForeignKey("LeadUserId")]
    //[InverseProperty("EventLeadRuleLeadUsers")]
    [NotMapped]
    public virtual ResUser? LeadUser { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("EventLeadRuleWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("EventLeadRuleId")]
    //[InverseProperty("EventLeadRules")]
    [NotMapped]
    public virtual ICollection<CrmTag> CrmTags { get; set; } = new List<CrmTag>();

    [ForeignKey("EventLeadRuleId")]
    //[InverseProperty("EventLeadRules")]
    [NotMapped]
    public virtual ICollection<EventType> EventTypes { get; set; } = new List<EventType>();
}
