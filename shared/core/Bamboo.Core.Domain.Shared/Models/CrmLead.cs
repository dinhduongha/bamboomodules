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

[Table("crm_lead")]
//[Index("TenantId", Name = "crm_lead_company_id_index")]
//[Index("CreationTime", "TeamId", Name = "crm_lead_create_date_team_id_idx")]
//[Index("DateLastStageUpdate", Name = "crm_lead_date_last_stage_update_index")]
//[Index("LostReasonId", Name = "crm_lead_lost_reason_id_index")]
//[Index("PartnerId", Name = "crm_lead_partner_id_index")]
//[Index("Priority", Name = "crm_lead_priority_index")]
//[Index("StageId", Name = "crm_lead_stage_id_index")]
//[Index("TeamId", Name = "crm_lead_team_id_index")]
//[Index("Type", Name = "crm_lead_type_index")]
//[Index("UserId", Name = "crm_lead_user_id_index")]
//[Index("UserId", "TeamId", "Type", Name = "crm_lead_user_id_team_id_type_index")]
public partial class CrmLead: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("campaign_id")]
    public Guid? CampaignId { get; set; }

    [Column("source_id")]
    public Guid? SourceId { get; set; }

    [Column("medium_id")]
    public Guid? MediumId { get; set; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("message_bounce")]
    public long? MessageBounce { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("team_id")]
    public Guid? TeamId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("stage_id")]
    public long? StageId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("recurring_plan")]
    public Guid? RecurringPlan { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("title")]
    public long? Title { get; set; }

    [Column("lang_id")]
    public long? LangId { get; set; }

    [Column("state_id")]
    public long? StateId { get; set; }

    [Column("country_id")]
    public long? CountryId { get; set; }

    [Column("lost_reason_id")]
    public long? LostReasonId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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

    [Column("lead_properties", TypeName = "jsonb")]
    public string? LeadProperties { get; set; }

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

    [Column("active")]
    public bool? Active { get; set; }

    [Column("date_closed", TypeName = "timestamp without time zone")]
    public DateTime? DateClosed { get; set; }

    [Column("date_action_last", TypeName = "timestamp without time zone")]
    public DateTime? DateActionLast { get; set; }

    [Column("date_open", TypeName = "timestamp without time zone")]
    public DateTime? DateOpen { get; set; }

    [Column("date_last_stage_update", TypeName = "timestamp without time zone")]
    public DateTime? DateLastStageUpdate { get; set; }

    [Column("date_conversion", TypeName = "timestamp without time zone")]
    public DateTime? DateConversion { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

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

    [ForeignKey("CampaignId")]
    //[InverseProperty("CrmLeads")]
    [NotMapped]
    public virtual UtmCampaign? Campaign { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("CrmLeads")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CountryId")]
    //[InverseProperty("CrmLeads")]
    [NotMapped]
    public virtual ResCountry? Country { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("CrmLeadCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LangId")]
    //[InverseProperty("CrmLeads")]
    [NotMapped]
    public virtual ResLang? Lang { get; set; }

    [ForeignKey("LeadMiningRequestId")]
    //[InverseProperty("CrmLeads")]
    [NotMapped]
    public virtual CrmIapLeadMiningRequest? LeadMiningRequest { get; set; }

    [ForeignKey("LostReasonId")]
    //[InverseProperty("CrmLeads")]
    [NotMapped]
    public virtual CrmLostReason? LostReason { get; set; }

    [ForeignKey("MediumId")]
    //[InverseProperty("CrmLeads")]
    [NotMapped]
    public virtual UtmMedium? Medium { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("CrmLeads")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("CrmLeads")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("RecurringPlan")]
    //[InverseProperty("CrmLeads")]
    [NotMapped]
    public virtual CrmRecurringPlan? RecurringPlanNavigation { get; set; }

    [ForeignKey("SourceId")]
    //[InverseProperty("CrmLeads")]
    [NotMapped]
    public virtual UtmSource? Source { get; set; }

    [ForeignKey("StageId")]
    //[InverseProperty("CrmLeads")]
    [NotMapped]
    public virtual CrmStage? Stage { get; set; }

    [ForeignKey("StateId")]
    //[InverseProperty("CrmLeads")]
    [NotMapped]
    public virtual ResCountryState? State { get; set; }

    [ForeignKey("TeamId")]
    //[InverseProperty("CrmLeads")]
    [NotMapped]
    public virtual CrmTeam? Team { get; set; }

    [ForeignKey("Title")]
    //[InverseProperty("CrmLeads")]
    [NotMapped]
    public virtual ResPartnerTitle? TitleNavigation { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("CrmLeadUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("CrmLeadWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Opportunity")]
    [NotMapped]
    public virtual ICollection<CalendarEvent> CalendarEvents { get; } = new List<CalendarEvent>();

    //[InverseProperty("Lead")]
    [NotMapped]
    public virtual ICollection<CrmLead2opportunityPartnerMass> CrmLead2opportunityPartnerMassesNavigation { get; } = new List<CrmLead2opportunityPartnerMass>();

    //[InverseProperty("Lead")]
    [NotMapped]
    public virtual ICollection<CrmLead2opportunityPartner> CrmLead2opportunityPartners { get; } = new List<CrmLead2opportunityPartner>();

    //[InverseProperty("Lead")]
    [NotMapped]
    public virtual ICollection<CrmQuotationPartner> CrmQuotationPartners { get; } = new List<CrmQuotationPartner>();

    //[InverseProperty("Opportunity")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrders { get; } = new List<SaleOrder>();

    [ForeignKey("CrmLeadId")]
    //[InverseProperty("CrmLeads")]
    [NotMapped]
    public virtual ICollection<CrmLead2opportunityPartnerMass> CrmLead2opportunityPartnerMasses { get; } = new List<CrmLead2opportunityPartnerMass>();

    [ForeignKey("CrmLeadId")]
    //[InverseProperty("CrmLeadsNavigation")]
    [NotMapped]
    public virtual ICollection<CrmLead2opportunityPartnerMass> CrmLead2opportunityPartnerMasses1 { get; } = new List<CrmLead2opportunityPartnerMass>();

    [ForeignKey("CrmLeadId")]
    //[InverseProperty("CrmLeads")]
    [NotMapped]
    public virtual ICollection<CrmLead2opportunityPartner> CrmLead2opportunityPartnersNavigation { get; } = new List<CrmLead2opportunityPartner>();

    [ForeignKey("OpportunityId")]
    //[InverseProperty("Opportunities")]
    [NotMapped]
    public virtual ICollection<CrmMergeOpportunity> Merges { get; } = new List<CrmMergeOpportunity>();

    [ForeignKey("LeadId")]
    //[InverseProperty("Leads")]
    [NotMapped]
    public virtual ICollection<CrmTag> Tags { get; } = new List<CrmTag>();

    [ForeignKey("CrmLeadId")]
    //[InverseProperty("CrmLeads")]
    [NotMapped]
    public virtual ICollection<WebsiteVisitor> WebsiteVisitors { get; } = new List<WebsiteVisitor>();
}
