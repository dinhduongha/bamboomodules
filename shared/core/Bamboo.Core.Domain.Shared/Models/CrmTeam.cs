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

[Table("crm_team")]
//[Index("TenantId", Name = "crm_team_company_id_index")]
public partial class CrmTeam: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("use_quotations")]
    public bool? UseQuotations { get; set; }

    [Column("invoiced_target")]
    public double? InvoicedTarget { get; set; }

    [Column("alias_id")]
    public Guid? AliasId { get; set; }

    [Column("assignment_domain")]
    public string? AssignmentDomain { get; set; }

    [Column("lead_properties_definition", TypeName = "jsonb")]
    public string? LeadPropertiesDefinition { get; set; }

    [Column("use_leads")]
    public bool? UseLeads { get; set; }

    [Column("use_opportunities")]
    public bool? UseOpportunities { get; set; }

    [Column("assignment_optout")]
    public bool? AssignmentOptout { get; set; }

    [ForeignKey("AliasId")]
    //[InverseProperty("CrmTeams")]
    [NotMapped]
    public virtual MailAlias? Alias { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("CrmTeams")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("CrmTeamCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("CrmTeams")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("CrmTeamUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("CrmTeamWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Team")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMoves { get; } = new List<AccountMove>();

    //[InverseProperty("Team")]
    [NotMapped]
    public virtual ICollection<CrmIapLeadMiningRequest> CrmIapLeadMiningRequests { get; } = new List<CrmIapLeadMiningRequest>();

    //[InverseProperty("Team")]
    [NotMapped]
    public virtual ICollection<CrmLead2opportunityPartnerMass> CrmLead2opportunityPartnerMasses { get; } = new List<CrmLead2opportunityPartnerMass>();

    //[InverseProperty("Team")]
    [NotMapped]
    public virtual ICollection<CrmLead2opportunityPartner> CrmLead2opportunityPartners { get; } = new List<CrmLead2opportunityPartner>();

    //[InverseProperty("Team")]
    [NotMapped]
    public virtual ICollection<CrmLeadScoringFrequency> CrmLeadScoringFrequencies { get; } = new List<CrmLeadScoringFrequency>();

    //[InverseProperty("Team")]
    [NotMapped]
    public virtual ICollection<CrmLead> CrmLeads { get; } = new List<CrmLead>();

    //[InverseProperty("Team")]
    [NotMapped]
    public virtual ICollection<CrmMergeOpportunity> CrmMergeOpportunities { get; } = new List<CrmMergeOpportunity>();

    //[InverseProperty("Team")]
    [NotMapped]
    public virtual ICollection<CrmStage> CrmStages { get; } = new List<CrmStage>();

    //[InverseProperty("CrmTeam")]
    [NotMapped]
    public virtual ICollection<CrmTeamMember> CrmTeamMembers { get; } = new List<CrmTeamMember>();

    //[InverseProperty("CrmTeam")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigs { get; } = new List<PosConfig>();

    //[InverseProperty("CrmTeam")]
    [NotMapped]
    public virtual ICollection<PosOrder> PosOrders { get; } = new List<PosOrder>();

    //[InverseProperty("Team")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartners { get; } = new List<ResPartner>();

    //[InverseProperty("SaleTeam")]
    [NotMapped]
    public virtual ICollection<ResUser> ResUsers { get; } = new List<ResUser>();

    //[InverseProperty("Team")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrders { get; } = new List<SaleOrder>();

    //[InverseProperty("CrmDefaultTeam")]
    [NotMapped]
    public virtual ICollection<Website> WebsiteCrmDefaultTeams { get; } = new List<Website>();

    //[InverseProperty("Salesteam")]
    [NotMapped]
    public virtual ICollection<Website> WebsiteSalesteams { get; } = new List<Website>();

    [ForeignKey("TeamId")]
    //[InverseProperty("Teams")]
    [NotMapped]
    public virtual ICollection<ResUser> Users { get; } = new List<ResUser>();
}
