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

[Table("crm_iap_lead_mining_request")]
public partial class CrmIapLeadMiningRequest: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("lead_number")]
    public long? LeadNumber { get; set; }

    [Column("team_id")]
    public Guid? TeamId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("company_size_min")]
    public long? CompanySizeMin { get; set; }

    [Column("company_size_max")]
    public long? CompanySizeMax { get; set; }

    [Column("contact_number")]
    public long? ContactNumber { get; set; }

    [Column("preferred_role_id")]
    public Guid? PreferredRoleId { get; set; }

    [Column("seniority_id")]
    public Guid? SeniorityId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("search_type")]
    public string? SearchType { get; set; }

    [Column("error_type")]
    public string? ErrorType { get; set; }

    [Column("lead_type")]
    public string? LeadType { get; set; }

    [Column("contact_filter_type")]
    public string? ContactFilterType { get; set; }

    [Column("filter_on_size")]
    public bool? FilterOnSize { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LeadMiningRequestId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("LeadMiningRequest")] // One2many
    public virtual ICollection<CrmLead> CrmLead { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PreferredRoleId")]
    public virtual CrmIapLeadRole? PreferredRole { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SeniorityId")]
    public virtual CrmIapLeadSeniority? Seniority { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TeamId")]
    public virtual CrmTeam? Team { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("CrmIapLeadMiningRequestId")] // Many2many // Normal
    // [InverseProperty("CrmIapLeadMiningRequest")] // Many2many // Normal
    public virtual ICollection<CrmIapLeadIndustry> CrmIapLeadIndustry { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("CrmIapLeadMiningRequestId")] // Many2many // Normal
    // [InverseProperty("CrmIapLeadMiningRequestNavigation")] // Many2many // Normal
    public virtual ICollection<CrmIapLeadRole> CrmIapLeadRole { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("CrmIapLeadMiningRequestId")] // Many2many // Normal
    // [InverseProperty("CrmIapLeadMiningRequest")] // Many2many // Normal
    public virtual ICollection<CrmTag> CrmTag { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (ResCountry) is commented out
    // [ForeignKey("CrmIapLeadMiningRequestId")] // Many2many // Normal
    // [InverseProperty("CrmIapLeadMiningRequest")] // Many2many // Normal
    public virtual ICollection<ResCountry> ResCountry { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (ResCountryState) is commented out
    // [ForeignKey("CrmIapLeadMiningRequestId")] // Many2many // Normal
    // [InverseProperty("CrmIapLeadMiningRequest")] // Many2many // Normal
    public virtual ICollection<ResCountryState> ResCountryState { get; set; }
}
