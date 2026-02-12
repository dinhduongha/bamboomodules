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
    public partial class EventRegistrationAppService
    {

        protected async Task<EventRegistration> ApplyLeadGenerationRulesInternalAsync(object event_lead_rules)
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py, METHOD: _apply_lead_generation_rules) ---
            */
            return default;
        }

        protected async Task<EventRegistration> CheckEventSlotInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _check_event_slot) ---
            */
            return default;
        }

        protected async Task<EventRegistration> CheckEventTicketInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _check_event_ticket) ---
            */
            return default;
        }

        protected async Task<EventRegistration> CheckSeatsAvailabilityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _check_seats_availability) ---
            */
            return default;
        }

        protected async Task<EventRegistration> ComputeCompanyNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _compute_company_name) ---
            */
            return default;
        }

        protected async Task<EventRegistration> ComputeDateClosedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _compute_date_closed) ---
            */
            return default;
        }

        protected async Task<EventRegistration> ComputeDateRangeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _compute_date_range) ---
            */
            return default;
        }

        protected async Task<EventRegistration> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<EventRegistration> ComputeEmailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _compute_email) ---
            */
            return default;
        }

        protected async Task<EventRegistration> ComputeEventBeginDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _compute_event_begin_date) ---
            */
            return default;
        }

        protected async Task<EventRegistration> ComputeEventEndDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _compute_event_end_date) ---
            */
            return default;
        }

        protected async Task<EventRegistration> ComputeFieldValueInternalAsync(object field)
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: event_registration.py, METHOD: _compute_field_value) ---
            */
            return default;
        }

        protected async Task<EventRegistration> ComputeLeadCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py, METHOD: _compute_lead_count) ---
            */
            return default;
        }

        protected async Task<EventRegistration> ComputeNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _compute_name) ---
            */
            return default;
        }

        protected async Task<EventRegistration> ComputePhoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _compute_phone) ---
            */
            return default;
        }

        protected async Task<EventRegistration> ComputeRegistrationStatusInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_product, FILE: event_registration.py, METHOD: _compute_registration_status) ---
            --- METHOD SOURCE (MODULE: event_sale, FILE: event_registration.py, METHOD: _compute_registration_status) ---
            --- METHOD SOURCE (MODULE: pos_event, FILE: event_registration.py, METHOD: _compute_registration_status) ---
            --- METHOD SOURCE (MODULE: pos_event_sale, FILE: event_registration.py, METHOD: _compute_registration_status) ---
            */
            return default;
        }

        protected async Task<EventRegistration> ComputeUtmCampaignIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: event_registration.py, METHOD: _compute_utm_campaign_id) ---
            */
            return default;
        }

        protected async Task<EventRegistration> ComputeUtmMediumIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: event_registration.py, METHOD: _compute_utm_medium_id) ---
            */
            return default;
        }

        protected async Task<EventRegistration> ComputeUtmSourceIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: event_registration.py, METHOD: _compute_utm_source_id) ---
            */
            return default;
        }

        protected async Task<EventRegistration> ConvertValueInternalAsync(object @value, object field_name)
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py, METHOD: _convert_value) ---
            */
            return default;
        }

        protected async Task<EventRegistration> FindFirstNotnullInternalAsync(object field_name)
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py, METHOD: _find_first_notnull) ---
            */
            return default;
        }

        protected async Task<EventRegistration> GetEventRegistrationIdsFromOrderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: event_registration.py, METHOD: _get_event_registration_ids_from_order) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<EventRegistration> GetLeadContactFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py, METHOD: _get_lead_contact_fields) ---
            */
            return default;
        }

        protected async Task<EventRegistration> GetLeadContactValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py, METHOD: _get_lead_contact_values) ---
            */
            return default;
        }

        protected async Task<EventRegistration> GetLeadDescriptionFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py, METHOD: _get_lead_description_fields) ---
            --- METHOD SOURCE (MODULE: website_event_crm, FILE: event_registration.py, METHOD: _get_lead_description_fields) ---
            */
            return default;
        }

        protected async Task<EventRegistration> GetLeadDescriptionInternalAsync(object prefix, object line_counter, object line_suffix)
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py, METHOD: _get_lead_description) ---
            */
            return default;
        }

        protected async Task<EventRegistration> GetLeadDescriptionRegistrationInternalAsync(object line_suffix)
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py, METHOD: _get_lead_description_registration) ---
            --- METHOD SOURCE (MODULE: website_event_crm, FILE: event_registration.py, METHOD: _get_lead_description_registration) ---
            */
            return default;
        }

        protected async Task<EventRegistration> GetLeadGroupingInternalAsync(object rules, object rule_to_new_regs)
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py, METHOD: _get_lead_grouping) ---
            --- METHOD SOURCE (MODULE: event_crm_sale, FILE: event_registration.py, METHOD: _get_lead_grouping) ---
            */
            return default;
        }

        protected async Task<EventRegistration> GetLeadTrackedValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py, METHOD: _get_lead_tracked_values) ---
            */
            return default;
        }

        protected async Task<EventRegistration> GetLeadValuesInternalAsync(object rule)
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py, METHOD: _get_lead_values) ---
            --- METHOD SOURCE (MODULE: website_event_crm, FILE: event_registration.py, METHOD: _get_lead_values) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<EventRegistration> GetRandomBarcodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _get_random_barcode) ---
            */
            return default;
        }

        protected async Task<EventRegistration> GetRegistrationSummaryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _get_registration_summary) ---
            --- METHOD SOURCE (MODULE: event_sale, FILE: event_registration.py, METHOD: _get_registration_summary) ---
            */
            return default;
        }

        protected async Task<EventRegistration> GetWebsiteRegistrationAllowedFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_registration.py, METHOD: _get_website_registration_allowed_fields) ---
            */
            return default;
        }

        protected async Task<EventRegistration> HasOrderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_product, FILE: event_registration.py, METHOD: _has_order) ---
            --- METHOD SOURCE (MODULE: event_sale, FILE: event_registration.py, METHOD: _has_order) ---
            --- METHOD SOURCE (MODULE: pos_event, FILE: event_registration.py, METHOD: _has_order) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<EventRegistration> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_event, FILE: event_registration.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<EventRegistration> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_event, FILE: event_registration.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        protected async Task<EventRegistration> LoadRecordsCreateInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py, METHOD: _load_records_create) ---
            */
            return default;
        }

        protected async Task<EventRegistration> LoadRecordsWriteInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py, METHOD: _load_records_write) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<EventRegistration> MailTemplateDefaultValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _mail_template_default_values) ---
            */
            return default;
        }

        protected async Task<EventRegistration> MailingGetDefaultDomainInternalAsync(object mailing)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_event, FILE: event_registration.py, METHOD: _mailing_get_default_domain) ---
            */
            return default;
        }

        protected async Task<EventRegistration> MessageAddDefaultRecipientsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _message_add_default_recipients) ---
            */
            return default;
        }

        protected async Task<EventRegistration> MessageComputeSubjectInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _message_compute_subject) ---
            */
            return default;
        }

        protected async Task<EventRegistration> MessagePostAfterHookInternalAsync(object message, object msg_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _message_post_after_hook) ---
            */
            return default;
        }

        protected async Task<EventRegistration> OnchangeEventInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _onchange_event) ---
            */
            return default;
        }

        protected async Task<EventRegistration> OnchangePhoneValidationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _onchange_phone_validation) ---
            */
            return default;
        }

        protected async Task<EventRegistration> SaleOrderRegistrationDataChangeNotifyInternalAsync(object new_record_field, object new_record)
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: event_registration.py, METHOD: _sale_order_registration_data_change_notify) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<EventRegistration> SearchEventBeginDateInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _search_event_begin_date) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<EventRegistration> SearchEventEndDateInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _search_event_end_date) ---
            */
            return default;
        }

        protected async Task<EventRegistration> SynchronizePartnerValuesInternalAsync(object partner, object fnames)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _synchronize_partner_values) ---
            */
            return default;
        }

        protected async Task<EventRegistration> SynchronizeSoLineValuesInternalAsync(object so_line)
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: event_registration.py, METHOD: _synchronize_so_line_values) ---
            */
            return default;
        }

        protected async Task<EventRegistration> UpdateAvailableSeatInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_event, FILE: event_registration.py, METHOD: _update_available_seat) ---
            */
            return default;
        }

        protected async Task<EventRegistration> UpdateLeadsInternalAsync(object new_vals, object lead_tracked_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_registration.py, METHOD: _update_leads) ---
            */
            return default;
        }

        protected async Task<EventRegistration> UpdateMailSchedulersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _update_mail_schedulers) ---
            */
            return default;
        }
    }
}