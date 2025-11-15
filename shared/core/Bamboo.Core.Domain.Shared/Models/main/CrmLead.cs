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

[Table("crm_lead")]
//[Index("CompanyId", Name = "crm_lead__company_id_index")]
//[Index("DateLastStageUpdate", Name = "crm_lead__date_last_stage_update_index")]
//[Index("LostReasonId", Name = "crm_lead__lost_reason_id_index")]
//[Index("PartnerId", Name = "crm_lead__partner_id_index")]
//[Index("Priority", Name = "crm_lead__priority_index")]
//[Index("StageId", Name = "crm_lead__stage_id_index")]
//[Index("TeamId", Name = "crm_lead__team_id_index")]
//[Index("Type", Name = "crm_lead__type_index")]
//[Index("UserId", Name = "crm_lead__user_id_index")]
//[Index("CreateDate", "TeamId", Name = "crm_lead_create_date_team_id_idx")]
//[Index("UserId", "TeamId", "Type", Name = "crm_lead_user_id_team_id_type_index")]
public partial class CrmLead : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("campaign_id")]
    public Guid? CampaignId { get; set; }

    [Column("source_id")]
    public Guid? SourceId { get; set; }

    [Column("medium_id")]
    public Guid? MediumId { get; set; }

    [Column("message_bounce")]
    public long? MessageBounce { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("team_id")]
    public Guid? TeamId { get; set; }

    [Column("stage_id")]
    public Guid? StageId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("recurring_plan")]
    public Guid? RecurringPlan { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("title")]
    public Guid? Title { get; set; }

    [Column("lang_id")]
    public Guid? LangId { get; set; }

    [Column("state_id")]
    public Guid? StateId { get; set; }

    [Column("country_id")]
    public Guid? CountryId { get; set; }

    [Column("lost_reason_id")]
    public Guid? LostReasonId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("phone_sanitized")]
    public string? PhoneSanitized { get; set; }

    [Column("email_normalized")]
    public string? EmailNormalized { get; set; }

    [Column("email_cc")]
    public string? EmailCc { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("referred")]
    public string? Referred { get; set; }

    [Column("type")]
    public string? Type { get; set; }

    [Column("priority")]
    public string? Priority { get; set; }

    [Column("contact_name")]
    public string? ContactName { get; set; }

    [Column("partner_name")]
    public string? PartnerName { get; set; }

    [Column("function")]
    public string? Function { get; set; }

    [Column("email_from")]
    public string? EmailFrom { get; set; }

    [Column("email_domain_criterion")]
    public string? EmailDomainCriterion { get; set; }

    [Column("phone")]
    public string? Phone { get; set; }

    [Column("mobile")]
    public string? Mobile { get; set; }

    [Column("phone_state")]
    public string? PhoneState { get; set; }

    [Column("email_state")]
    public string? EmailState { get; set; }

    [Column("website")]
    public string? Website { get; set; }

    [Column("street")]
    public string? Street { get; set; }

    [Column("street2")]
    public string? Street2 { get; set; }

    [Column("zip")]
    public string? Zip { get; set; }

    [Column("city")]
    public string? City { get; set; }

    [Column("date_deadline")]
    public DateTime? DateDeadline { get; set; }

    [JsonField] // LeadProperties
    [Column("lead_properties", TypeName = "jsonb")]
    public JsonElement? LeadProperties { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("expected_revenue")]
    public decimal? ExpectedRevenue { get; set; }

    [Column("prorated_revenue")]
    public decimal? ProratedRevenue { get; set; }

    [Column("recurring_revenue")]
    public decimal? RecurringRevenue { get; set; }

    [Column("recurring_revenue_monthly")]
    public decimal? RecurringRevenueMonthly { get; set; }

    [Column("recurring_revenue_monthly_prorated")]
    public decimal? RecurringRevenueMonthlyProrated { get; set; }

    [Column("recurring_revenue_prorated")]
    public decimal? RecurringRevenueProrated { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("date_closed", TypeName = "timestamp without time zone")]
    public DateTime? DateClosed { get; set; }

    [Column("date_automation_last", TypeName = "timestamp without time zone")]
    public DateTime? DateAutomationLast { get; set; }

    [Column("date_open", TypeName = "timestamp without time zone")]
    public DateTime? DateOpen { get; set; }

    [Column("date_last_stage_update", TypeName = "timestamp without time zone")]
    public DateTime? DateLastStageUpdate { get; set; }

    [Column("date_conversion", TypeName = "timestamp without time zone")]
    public DateTime? DateConversion { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("day_open")]
    public double? DayOpen { get; set; }

    [Column("day_close")]
    public double? DayClose { get; set; }

    [Column("probability")]
    public double? Probability { get; set; }

    [Column("automated_probability")]
    public double? AutomatedProbability { get; set; }

    [Column("reveal_id")]
    public string? RevealId { get; set; }

    [Column("iap_enrich_done")]
    public bool? IapEnrichDone { get; set; }

    [Column("lead_mining_request_id")]
    public Guid? LeadMiningRequestId { get; set; }

    [Column("event_lead_rule_id")]
    public Guid? EventLeadRuleId { get; set; }

    [Column("event_id")]
    public Guid? EventId { get; set; }

    [Column("reveal_iap_credits")]
    public long? RevealIapCredits { get; set; }

    [Column("reveal_rule_id")]
    public Guid? RevealRuleId { get; set; }

    [Column("reveal_ip")]
    public string? RevealIp { get; set; }

    [Column("partner_assigned_id")]
    public Guid? PartnerAssignedId { get; set; }

    [Column("date_partner_assign")]
    public DateTime? DatePartnerAssign { get; set; }

    [Column("partner_latitude")]
    public decimal? PartnerLatitude { get; set; }

    [Column("partner_longitude")]
    public decimal? PartnerLongitude { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OpportunityId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Opportunity")] // One2many
    public virtual ICollection<CalendarEvent> CalendarEvent { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CampaignId")]
    public virtual UtmCampaign? Campaign { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CountryId")]
    public virtual ResCountry? Country { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LeadId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Lead")] // One2many
    public virtual ICollection<CrmLead2opportunityPartner> CrmLead2opportunityPartner { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LeadId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Lead")] // One2many
    public virtual ICollection<CrmLead2opportunityPartnerMass> CrmLead2opportunityPartnerMassNavigation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LeadId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Lead")] // One2many
    public virtual ICollection<CrmLeadAssignation> CrmLeadAssignation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LeadId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Lead")] // One2many
    public virtual ICollection<CrmQuotationPartner> CrmQuotationPartner { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("EventId")]
    public virtual EventEvent? Event { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("EventLeadRuleId")]
    public virtual EventLeadRule? EventLeadRule { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LangId")]
    public virtual ResLang? Lang { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LeadMiningRequestId")]
    public virtual CrmIapLeadMiningRequest? LeadMiningRequest { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LostReasonId")]
    public virtual CrmLostReason? LostReason { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("MediumId")]
    public virtual UtmMedium? Medium { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PartnerAssignedId")]
    public virtual ResPartner? PartnerAssigned { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("RecurringPlan")]
    public virtual CrmRecurringPlan? RecurringPlanNavigation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("RevealRuleId")]
    public virtual CrmRevealRule? RevealRule { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OpportunityId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Opportunity")] // One2many
    public virtual ICollection<SaleOrder> SaleOrder { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SourceId")]
    public virtual UtmSource? Source { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("StageId")]
    public virtual CrmStage? Stage { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("StateId")]
    public virtual ResCountryState? State { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TeamId")]
    public virtual CrmTeam? Team { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("Title")]
    public virtual ResPartnerTitle? TitleNavigation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("CrmLeadId")] //Many2many // Hidden
    // [InverseProperty("CrmLead")] //Many2many // Hidden
    public virtual ICollection<CrmLead2opportunityPartnerMass> CrmLead2opportunityPartnerMass { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("CrmLeadId")] //Many2many // Hidden
    // [InverseProperty("CrmLeadNavigation")] //Many2many // Hidden
    public virtual ICollection<CrmLead2opportunityPartnerMass> CrmLead2opportunityPartnerMass1 { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("CrmLeadId")] //Many2many // Hidden
    // [InverseProperty("CrmLead")] //Many2many // Hidden
    public virtual ICollection<CrmLead2opportunityPartner> CrmLead2opportunityPartnerNavigation { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("CrmLeadId")] //Many2many // Hidden
    // [InverseProperty("CrmLead")] //Many2many // Hidden
    public virtual ICollection<CrmLeadLost> CrmLeadLost { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("CrmLeadId")] // Many2many // Normal
    // [InverseProperty("CrmLead")] // Many2many // Normal
    public virtual ICollection<EventRegistration> EventRegistration { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("OpportunityId")] //Many2many // Hidden
    // [InverseProperty("Opportunity")] //Many2many // Hidden
    public virtual ICollection<CrmMergeOpportunity> Merge { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (ResPartner) is commented out
    // [ForeignKey("LeadId")] // Many2many // Normal
    // [InverseProperty("Lead")] // Many2many // Normal
    public virtual ICollection<ResPartner> PartnerNavigation { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("LeadId")] // Many2many // Normal
    // [InverseProperty("Lead")] // Many2many // Normal
    public virtual ICollection<CrmTag> Tag { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("CrmLeadId")] // Many2many // Normal
    // [InverseProperty("CrmLead")] // Many2many // Normal
    public virtual ICollection<WebsiteVisitor> WebsiteVisitor { get; set; }
}
