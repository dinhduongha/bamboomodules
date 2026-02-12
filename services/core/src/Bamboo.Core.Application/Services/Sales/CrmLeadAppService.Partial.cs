using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Services
{
    public partial class CrmLeadAppService
    {

        protected async Task<CrmLead> AssertPortalWriteAccessInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py, METHOD: _assert_portal_write_access) ---
            */
            return default;
        }

        protected async Task<CrmLead> AssignUserlessLeadInTeamInternalAsync(string creation_source)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _assign_userless_lead_in_team) ---
            */
            return default;
        }

        protected async Task<CrmLead> CheckWonValidityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _check_won_validity) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeCommercialPartnerIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_commercial_partner_id) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeCompanyCurrencyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_company_currency) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeCompanyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_company_id) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeContactNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_contact_name) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeDateLastStageUpdateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_date_last_stage_update) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeDateOpenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_date_open) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeDatePartnerAssignInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py, METHOD: _compute_date_partner_assign) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeDayCloseInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_day_close) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeDayOpenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_day_open) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeEmailDomainCriterionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_email_domain_criterion) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeEmailFromInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_email_from) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeEmailStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_email_state) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeFunctionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_function) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeIsAutomatedProbabilityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_is_automated_probability) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeIsPartnerVisibleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_is_partner_visible) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeLangActiveCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_lang_active_count) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeLangIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_lang_id) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeMeetingDisplayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_meeting_display) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_name) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputePartnerAddressValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_partner_address_values) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputePartnerEmailUpdateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_partner_email_update) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputePartnerNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_partner_name) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputePartnerPhoneUpdateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_partner_phone_update) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputePhoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_phone) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputePhoneStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_phone_state) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputePotentialLeadDuplicatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_potential_lead_duplicates) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeProbabilitiesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_probabilities) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeProratedRevenueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_prorated_revenue) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeRecurringRevenueMonthlyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_recurring_revenue_monthly) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeRecurringRevenueMonthlyProratedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_recurring_revenue_monthly_prorated) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeRecurringRevenueProratedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_recurring_revenue_prorated) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeRegistrationCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: crm_lead.py, METHOD: _compute_registration_count) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeSaleDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_crm, FILE: crm_lead.py, METHOD: _compute_sale_data) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeShowEnrichButtonInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_enrich, FILE: crm_lead.py, METHOD: _compute_show_enrich_button) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeStageIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_stage_id) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeTeamIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_team_id) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeUserCompanyIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_user_company_ids) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeVisitorPageCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm, FILE: crm_lead.py, METHOD: _compute_visitor_page_count) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeVisitorSessionsCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_livechat, FILE: crm_lead.py, METHOD: _compute_visitor_sessions_count) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeWebsiteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_website) ---
            */
            return default;
        }

        protected async Task<CrmLead> ComputeWonStatusInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_won_status) ---
            */
            return default;
        }

        protected async Task<CrmLead> ConvertOpportunityDataInternalAsync(object customer, Guid team_id)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _convert_opportunity_data) ---
            */
            return default;
        }

        protected async Task<CrmLead> CreateCustomerInternalAsync(object with_parent)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _create_customer) ---
            */
            return default;
        }

        protected async Task<CrmLead> CreationMessageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _creation_message) ---
            */
            return default;
        }

        protected async Task<CrmLead> CreationSubtypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _creation_subtype) ---
            */
            return default;
        }

        protected async Task<CrmLead> CronUpdateAutomatedProbabilitiesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _cron_update_automated_probabilities) ---
            */
            return default;
        }

        protected async Task<object> FieldToSqlInternalAsync(object @alias, object field_expr, object query)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _field_to_sql) ---
            */
            return default;
        }

        protected async Task<CrmLead> FindMatchingPartnerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _find_matching_partner) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CrmLead> FormViewAutoFillInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm_mail_plugin, FILE: crm_lead.py, METHOD: _form_view_auto_fill) ---
            */
            return default;
        }

        protected async Task<CrmLead> FormatPropertiesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _format_properties) ---
            */
            return default;
        }

        protected async Task<CrmLead> GetAccessActionInternalAsync(object access_uid, object force_website)
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py, METHOD: _get_access_action) ---
            */
            return default;
        }

        protected async Task<CrmLead> GetActionViewSaleQuotationDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_crm, FILE: crm_lead.py, METHOD: _get_action_view_sale_quotation_domain) ---
            */
            return default;
        }

        protected async Task<CrmLead> GetCustomerInformationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_customer_information) ---
            */
            return default;
        }

        protected async Task<CrmLead> GetLeadDuplicatesInternalAsync(object partner, object email, object include_lost)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_lead_duplicates) ---
            */
            return default;
        }

        protected async Task<CrmLead> GetLeadQuotationDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_crm, FILE: crm_lead.py, METHOD: _get_lead_quotation_domain) ---
            */
            return default;
        }

        protected async Task<CrmLead> GetLeadSaleOrderDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_crm, FILE: crm_lead.py, METHOD: _get_lead_sale_order_domain) ---
            */
            return default;
        }

        protected async Task<CrmLead> GetOpportunityMeetingViewParametersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_opportunity_meeting_view_parameters) ---
            */
            return default;
        }

        protected async Task<CrmLead> GetPartnerEmailUpdateInternalAsync(object force_void)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_partner_email_update) ---
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py, METHOD: _get_partner_email_update) ---
            */
            return default;
        }

        protected async Task<CrmLead> GetPartnerPhoneUpdateInternalAsync(object force_void)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_partner_phone_update) ---
            */
            return default;
        }

        protected async Task<CrmLead> GetRainbowmanMessageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_rainbowman_message) ---
            */
            return default;
        }

        protected async Task<CrmLead> GetRottingDependsFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_rotting_depends_fields) ---
            */
            return default;
        }

        protected async Task<CrmLead> GetRottingDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_rotting_domain) ---
            */
            return default;
        }

        protected async Task<CrmLead> HandlePartnerAssignmentInternalAsync(Guid force_partner_id, object create_missing, object with_parent)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _handle_partner_assignment) ---
            */
            return default;
        }

        protected async Task<CrmLead> HandleSalesmenAssignmentInternalAsync(List<Guid> user_ids, Guid team_id)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _handle_salesmen_assignment) ---
            */
            return default;
        }

        protected async Task<CrmLead> HandleWonLostInternalAsync(object old_status_by_lead, object new_status_by_lead)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _handle_won_lost) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CrmLead> IapEnrichFromResponseInternalAsync(object iap_response)
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_enrich, FILE: crm_lead.py, METHOD: _iap_enrich_from_response) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CrmLead> IapEnrichLeadsCronInternalAsync(object enrich_hours_delay, object batch_size)
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_enrich, FILE: crm_lead.py, METHOD: _iap_enrich_leads_cron) ---
            */
            return default;
        }

        protected async Task<CrmLead> InverseEmailFromInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _inverse_email_from) ---
            */
            return default;
        }

        protected async Task<CrmLead> InversePhoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _inverse_phone) ---
            */
            return default;
        }

        protected async Task<CrmLead> IsRuleBasedAssignmentActivatedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _is_rule_based_assignment_activated) ---
            */
            return default;
        }

        protected async Task<CrmLead> MergeDataInternalAsync(object fnames)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_data) ---
            */
            return default;
        }

        protected async Task<CrmLead> MergeDependencesAttachmentsInternalAsync(object opportunities)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_dependences_attachments) ---
            */
            return default;
        }

        protected async Task<CrmLead> MergeDependencesCalendarEventsInternalAsync(object opportunities)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_dependences_calendar_events) ---
            */
            return default;
        }

        protected async Task<CrmLead> MergeDependencesHistoryInternalAsync(object opportunities)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_dependences_history) ---
            */
            return default;
        }

        protected async Task<CrmLead> MergeDependencesInternalAsync(object opportunities)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_dependences) ---
            --- METHOD SOURCE (MODULE: event_crm, FILE: crm_lead.py, METHOD: _merge_dependences) ---
            */
            return default;
        }

        protected async Task<CrmLead> MergeFollowersInternalAsync(object opportunities)
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_followers) ---
            #endif
            return default;
        }

        protected async Task<CrmLead> MergeGetFieldsAddressInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_get_fields_address) ---
            */
            return default;
        }

        protected async Task<CrmLead> MergeGetFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_get_fields) ---
            --- METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_lead.py, METHOD: _merge_get_fields) ---
            --- METHOD SOURCE (MODULE: event_crm, FILE: crm_lead.py, METHOD: _merge_get_fields) ---
            --- METHOD SOURCE (MODULE: iap_crm, FILE: crm_lead.py, METHOD: _merge_get_fields) ---
            --- METHOD SOURCE (MODULE: website_crm_iap_reveal, FILE: crm_lead.py, METHOD: _merge_get_fields) ---
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py, METHOD: _merge_get_fields) ---
            */
            return default;
        }

        protected async Task<CrmLead> MergeGetFieldsSpecificInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_get_fields_specific) ---
            --- METHOD SOURCE (MODULE: crm_iap_enrich, FILE: crm_lead.py, METHOD: _merge_get_fields_specific) ---
            --- METHOD SOURCE (MODULE: sale_crm, FILE: crm_lead.py, METHOD: _merge_get_fields_specific) ---
            --- METHOD SOURCE (MODULE: website_crm, FILE: crm_lead.py, METHOD: _merge_get_fields_specific) ---
            */
            return default;
        }

        protected async Task<CrmLead> MergeLogSummaryInternalAsync(object merged_followers, object opportunities_tail)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_log_summary) ---
            */
            return default;
        }

        protected async Task<CrmLead> MergeOpportunityInternalAsync(Guid user_id, Guid team_id, object auto_unlink, object max_length)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_opportunity) ---
            */
            return default;
        }

        protected async Task<CrmLead> MessagePostAfterHookInternalAsync(object message, object msg_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _message_post_after_hook) ---
            */
            return default;
        }

        protected async Task<CrmLead> NotifyByEmailPrepareRenderingContextInternalAsync(object message, object msg_vals, object model_description, object force_email_company, object force_email_lang, object force_record_name)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _notify_by_email_prepare_rendering_context) ---
            */
            return default;
        }

        protected async Task<CrmLead> NotifyGetReplyToInternalAsync(object @default, Guid author_id)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _notify_get_reply_to) ---
            */
            return default;
        }

        protected async Task<CrmLead> OnchangeCommercialPartnerIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _onchange_commercial_partner_id) ---
            */
            return default;
        }

        protected async Task<CrmLead> OnchangePhoneValidationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _onchange_phone_validation) ---
            */
            return default;
        }

        protected async Task<CrmLead> PlsGetLeadPlsValuesInternalAsync(object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_get_lead_pls_values) ---
            */
            return default;
        }

        protected async Task<CrmLead> PlsGetNaiveBayesProbabilitiesInternalAsync(object batch_mode, object is_tooltip)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_get_naive_bayes_probabilities) ---
            */
            return default;
        }

        protected async Task<CrmLead> PlsGetSafeFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_get_safe_fields) ---
            */
            return default;
        }

        protected async Task<CrmLead> PlsGetSafeStartDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_get_safe_start_date) ---
            */
            return default;
        }

        protected async Task<CrmLead> PlsGetWonLostTotalCountInternalAsync(object team_results)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_get_won_lost_total_count) ---
            */
            return default;
        }

        protected async Task<CrmLead> PlsIncrementFrequenciesInternalAsync(object from_state, object to_state)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_increment_frequencies) ---
            */
            return default;
        }

        protected async Task<CrmLead> PlsIncrementFrequencyDictInternalAsync(object frequencies, object field, object @value, object won, object lost)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_increment_frequency_dict) ---
            */
            return default;
        }

        protected async Task<CrmLead> PlsPrepareFrequenciesInternalAsync(object lead_values, object leads_pls_fields, object target_state)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_prepare_frequencies) ---
            */
            return default;
        }

        protected async Task<CrmLead> PlsPrepareUpdateFrequencyTableInternalAsync(object rebuild, object target_state)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_prepare_update_frequency_table) ---
            */
            return default;
        }

        protected async Task<CrmLead> PlsUpdateFrequencyTableInternalAsync(object new_frequencies_by_team, object step, object existing_frequencies_by_team)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_update_frequency_table) ---
            */
            return default;
        }

        protected async Task<CrmLead> PrepareAddressValuesFromPartnerInternalAsync(object partner)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _prepare_address_values_from_partner) ---
            */
            return default;
        }

        protected async Task<CrmLead> PrepareContactNameFromPartnerInternalAsync(object partner)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _prepare_contact_name_from_partner) ---
            */
            return default;
        }

        protected async Task<CrmLead> PrepareCustomerValuesInternalAsync(object partner_name, object is_company, Guid parent_id)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _prepare_customer_values) ---
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py, METHOD: _prepare_customer_values) ---
            */
            return default;
        }

        protected async Task<CrmLead> PrepareOpportunityQuotationContextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_crm, FILE: crm_lead.py, METHOD: _prepare_opportunity_quotation_context) ---
            */
            return default;
        }

        protected async Task<CrmLead> PreparePartnerNameFromPartnerInternalAsync(object partner)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _prepare_partner_name_from_partner) ---
            */
            return default;
        }

        protected async Task<CrmLead> PrepareValuesFromPartnerInternalAsync(object partner)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _prepare_values_from_partner) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CrmLead> ReadGroupStageIdsInternalAsync(object stages, object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _read_group_stage_ids) ---
            */
            return default;
        }

        protected async Task<CrmLead> RebuildPlsFrequencyTableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _rebuild_pls_frequency_table) ---
            */
            return default;
        }

        protected async Task<CrmLead> SortByConfidenceLevelInternalAsync(object reverse)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _sort_by_confidence_level) ---
            */
            return default;
        }

        protected async Task<CrmLead> StageFindInternalAsync(Guid team_id, object domain, object order, object limit)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _stage_find) ---
            */
            return default;
        }

        protected async Task<CrmLead> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        protected async Task<CrmLead> UpdateAutomatedProbabilitiesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _update_automated_probabilities) ---
            */
            return default;
        }

        protected async Task<CrmLead> UpdateRevenuesFromSoInternalAsync(object order)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_crm, FILE: crm_lead.py, METHOD: _update_revenues_from_so) ---
            */
            return default;
        }
    }
}