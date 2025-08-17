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
//[Index("CompanyId", Name = "crm_team_company_id_index")]
public partial class CrmTeam: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("use_quotations")]
    public bool? UseQuotations { get; set; }

    [Column("invoiced_target")]
    public double? InvoicedTarget { get; set; }

    [Column("alias_id")]
    public Guid? AliasId { get; set; }

    [Column("assignment_domain")]
    public string? AssignmentDomain { get; set; }

    [JsonField]
    [Column("lead_properties_definition", TypeName = "jsonb")]
    public string? LeadPropertiesDefinition { get; set; }

    [Column("use_leads")]
    public bool? UseLeads { get; set; }

    [Column("use_opportunities")]
    public bool? UseOpportunities { get; set; }

    [Column("assignment_optout")]
    public bool? AssignmentOptout { get; set; }

    // [One2many]
    [ForeignKey("TeamId")]
    [InverseProperty("Team")]
    public virtual ICollection<AccountMove> AccountMove { get; set; }

    // [Many2one]
    [ForeignKey("AliasId")]
    // [InverseProperty("CrmTeam")] //Many2one
    public virtual MailAlias? Alias { get; set; }

    // [One2many]
    [ForeignKey("CrmTeamId")]
    [InverseProperty("CrmTeam")]
    public virtual ICollection<ChatbotScriptStep> ChatbotScriptStep { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("CrmTeam")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("CrmTeamCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("TeamId")]
    [InverseProperty("Team")]
    public virtual ICollection<CrmIapLeadMiningRequest> CrmIapLeadMiningRequest { get; set; }

    // [One2many]
    [ForeignKey("TeamId")]
    [InverseProperty("Team")]
    public virtual ICollection<CrmLead> CrmLead { get; set; }

    // [One2many]
    [ForeignKey("TeamId")]
    [InverseProperty("Team")]
    public virtual ICollection<CrmLead2opportunityPartner> CrmLead2opportunityPartner { get; set; }

    // [One2many]
    [ForeignKey("TeamId")]
    [InverseProperty("Team")]
    public virtual ICollection<CrmLead2opportunityPartnerMass> CrmLead2opportunityPartnerMass { get; set; }

    // [One2many]
    [ForeignKey("TeamId")]
    [InverseProperty("Team")]
    public virtual ICollection<CrmLeadScoringFrequency> CrmLeadScoringFrequency { get; set; }

    // [One2many]
    [ForeignKey("TeamId")]
    [InverseProperty("Team")]
    public virtual ICollection<CrmMergeOpportunity> CrmMergeOpportunity { get; set; }

    // [One2many]
    [ForeignKey("TeamId")]
    [InverseProperty("Team")]
    public virtual ICollection<CrmRevealRule> CrmRevealRule { get; set; }

    // [One2many]
    [ForeignKey("TeamId")]
    [InverseProperty("Team")]
    public virtual ICollection<CrmStage> CrmStage { get; set; }

    // [One2many]
    [ForeignKey("CrmTeamId")]
    [InverseProperty("CrmTeam")]
    public virtual ICollection<CrmTeamMember> CrmTeamMember { get; set; }

    // [One2many]
    [ForeignKey("LeadSalesTeamId")]
    [InverseProperty("LeadSalesTeam")]
    public virtual ICollection<EventLeadRule> EventLeadRule { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("CrmTeam")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [One2many]
    [ForeignKey("CrmTeamId")]
    [InverseProperty("CrmTeam")]
    public virtual ICollection<PosConfig> PosConfig { get; set; }

    // [One2many]
    [ForeignKey("CrmTeamId")]
    [InverseProperty("CrmTeam")]
    public virtual ICollection<PosOrder> PosOrder { get; set; }

    // [One2many]
    [ForeignKey("TeamId")]
    [InverseProperty("Team")]
    public virtual ICollection<ResPartner> ResPartner { get; set; }

    // [One2many]
    [ForeignKey("SaleTeamId")]
    [InverseProperty("SaleTeam")]
    public virtual ICollection<ResUsers> ResUsers { get; set; }

    // [One2many]
    [ForeignKey("TeamId")]
    [InverseProperty("Team")]
    public virtual ICollection<SaleOrder> SaleOrder { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("CrmTeamUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [One2many]
    [ForeignKey("CrmDefaultTeamId")]
    [InverseProperty("CrmDefaultTeam")]
    public virtual ICollection<Website> WebsiteCrmDefaultTeam { get; set; }

    // [One2many]
    [ForeignKey("SalesteamId")]
    [InverseProperty("Salesteam")]
    public virtual ICollection<Website> WebsiteSalesteam { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("CrmTeamWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("TeamId")] //Many2many
    // [InverseProperty("Team")] //Many2many
    public virtual ICollection<ResUsers> UserNavigation { get; set; }
}
