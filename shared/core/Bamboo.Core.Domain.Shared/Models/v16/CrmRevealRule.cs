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

[Table("crm_reveal_rule")]
public partial class CrmRevealRule: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("company_size_min")]
    public long? CompanySizeMin { get; set; }

    [Column("company_size_max")]
    public long? CompanySizeMax { get; set; }

    [Column("preferred_role_id")]
    public Guid? PreferredRoleId { get; set; }

    [Column("seniority_id")]
    public Guid? SeniorityId { get; set; }

    [Column("extra_contacts")]
    public long? ExtraContacts { get; set; }

    [Column("team_id")]
    public Guid? TeamId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("regex_url")]
    public string? RegexUrl { get; set; }

    [Column("contact_filter_type")]
    public string? ContactFilterType { get; set; }

    [Column("lead_for")]
    public string? LeadFor { get; set; }

    [Column("lead_type")]
    public string? LeadType { get; set; }

    [Column("suffix")]
    public string? Suffix { get; set; }

    [Column("priority")]
    public string? Priority { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("filter_on_size")]
    public bool? FilterOnSize { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("CrmRevealRuleCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("RevealRuleId")]
    [InverseProperty("RevealRule")]
    public virtual ICollection<CrmLead> CrmLead { get; set; }

    // [One2many]
    [ForeignKey("RevealRuleId")]
    [InverseProperty("RevealRule")]
    public virtual ICollection<CrmRevealView> CrmRevealView { get; set; }

    // [Many2one]
    [ForeignKey("PreferredRoleId")]
    // [InverseProperty("CrmRevealRuleNavigation")] //Many2one
    public virtual CrmIapLeadRole? PreferredRole { get; set; }

    // [Many2one]
    [ForeignKey("SeniorityId")]
    // [InverseProperty("CrmRevealRule")] //Many2one
    public virtual CrmIapLeadSeniority? Seniority { get; set; }

    // [Many2one]
    [ForeignKey("TeamId")]
    // [InverseProperty("CrmRevealRule")] //Many2one
    public virtual CrmTeam? Team { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("CrmRevealRuleUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("WebsiteId")]
    // [InverseProperty("CrmRevealRule")] //Many2one
    public virtual Website? Website { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("CrmRevealRuleWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("CrmRevealRuleId")] //Many2many
    // [InverseProperty("CrmRevealRule")] //Many2many
    public virtual ICollection<CrmIapLeadIndustry> CrmIapLeadIndustry { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("CrmRevealRuleId")] //Many2many
    // [InverseProperty("CrmRevealRule")] //Many2many
    public virtual ICollection<CrmIapLeadRole> CrmIapLeadRole { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("CrmRevealRuleId")] //Many2many
    // [InverseProperty("CrmRevealRule")] //Many2many
    public virtual ICollection<CrmTag> CrmTag { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("CrmRevealRuleId")] //Many2many
    // [InverseProperty("CrmRevealRule")] //Many2many
    public virtual ICollection<ResCountry> ResCountry { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("CrmRevealRuleId")] //Many2many
    // [InverseProperty("CrmRevealRule")] //Many2many
    public virtual ICollection<ResCountryState> ResCountryState { get; set; }
}
