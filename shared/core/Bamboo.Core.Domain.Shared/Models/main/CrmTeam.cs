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

[Table("crm_team")]
//[Index("CompanyId", Name = "crm_team__company_id_index")]
public partial class CrmTeam: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

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

    [JsonField(IsSparse = false)] // Name
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("invoiced_target")]
    public double? InvoicedTarget { get; set; }

    [Column("alias_id")]
    public Guid? AliasId { get; set; }

    [Column("assignment_domain")]
    public string? AssignmentDomain { get; set; }

    [JsonField] // LeadPropertiesDefinition
    [Column("lead_properties_definition", TypeName = "jsonb")]
    public JsonElement? LeadPropertiesDefinition { get; set; }

    [Column("use_leads")]
    public bool? UseLeads { get; set; }

    [Column("use_opportunities")]
    public bool? UseOpportunities { get; set; }

    [Column("assignment_optout")]
    public bool? AssignmentOptout { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TeamId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Team")] // One2many
    public virtual ICollection<AccountMove> AccountMove { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AliasId")]
    public virtual MailAlias? Alias { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CrmTeamId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("CrmTeam")] // One2many
    public virtual ICollection<ChatbotScriptStep> ChatbotScriptStep { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TeamId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Team")] // One2many
    public virtual ICollection<CrmIapLeadMiningRequest> CrmIapLeadMiningRequest { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TeamId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Team")] // One2many
    public virtual ICollection<CrmLead> CrmLead { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TeamId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Team")] // One2many
    public virtual ICollection<CrmLead2opportunityPartner> CrmLead2opportunityPartner { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TeamId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Team")] // One2many
    public virtual ICollection<CrmLead2opportunityPartnerMass> CrmLead2opportunityPartnerMass { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TeamId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Team")] // One2many
    public virtual ICollection<CrmLeadScoringFrequency> CrmLeadScoringFrequency { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TeamId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Team")] // One2many
    public virtual ICollection<CrmMergeOpportunity> CrmMergeOpportunity { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TeamId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Team")] // One2many
    public virtual ICollection<CrmRevealRule> CrmRevealRule { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TeamId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Team")] // One2many
    public virtual ICollection<CrmStage> CrmStage { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CrmTeamId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("CrmTeam")] // One2many
    public virtual ICollection<CrmTeamMember> CrmTeamMember { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LeadSalesTeamId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("LeadSalesTeam")] // One2many
    public virtual ICollection<EventLeadRule> EventLeadRule { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CrmTeamId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("CrmTeam")] // One2many
    public virtual ICollection<PosConfig> PosConfig { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CrmTeamId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("CrmTeam")] // One2many
    public virtual ICollection<PosOrder> PosOrder { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SaleTeamId")]
    [NotMapped] // One2many // Peer relationship (ResUsers) is commented out
    // [InverseProperty("SaleTeam")] // One2many
    public virtual ICollection<ResUsers> ResUsers { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TeamId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Team")] // One2many
    public virtual ICollection<SaleOrder> SaleOrder { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CrmDefaultTeamId")]
    [NotMapped] // One2many // Peer relationship (Website) is commented out
    // [InverseProperty("CrmDefaultTeam")] // One2many
    public virtual ICollection<Website> WebsiteCrmDefaultTeam { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SalesteamId")]
    [NotMapped] // One2many // Peer relationship (Website) is commented out
    // [InverseProperty("Salesteam")] // One2many
    public virtual ICollection<Website> WebsiteSalesteam { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (ResUsers) is commented out
    // [ForeignKey("TeamId")] // Many2many // Normal
    // [InverseProperty("Team")] // Many2many // Normal
    public virtual ICollection<ResUsers> UserNavigation { get; set; }
}
