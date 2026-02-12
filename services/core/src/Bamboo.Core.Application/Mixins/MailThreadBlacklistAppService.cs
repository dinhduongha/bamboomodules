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
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("mail", Category = "Productivity", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public partial class MailThreadBlacklistAppService : ApplicationService, IMailThreadBlacklistAppService
    {

        public MailThreadBlacklistAppService() 
        {

        }

        public async Task<TEntity> ActionAddToMailingListAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py, METHOD: action_add_to_mailing_list) ---
            */
            return default;
        }

        public async Task<TEntity> ActionArchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_archive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateMeetingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_create_meeting) ---
            */
            return default;
        }

        public async Task<TEntity> ActionDoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: action_done) ---
            */
            return default;
        }

        public async Task<TEntity> ActionEventViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_partner.py, METHOD: action_event_view) ---
            */
            return default;
        }

        public async Task<TEntity> ActionImportAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py, METHOD: action_import) ---
            */
            return default;
        }

        public async Task<TEntity> ActionJobAddApplicantsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_job_add_applicants) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenApplicationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_open_applications) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenAttachmentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_open_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenBusinessDocAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: action_open_business_doc) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenEmployeeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_open_employee) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenEmployeesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner.py, METHOD: action_open_employees) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPrivacyLookupAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: privacy_lookup, FILE: res_partner.py, METHOD: action_privacy_lookup) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRescheduleMeetingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_reschedule_meeting) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRestoreAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_restore) ---
            */
            return default;
        }

        public async Task<TEntity> ActionScheduleMeetingAsync<TEntity>(IEnumerable<TEntity> entities, object smart_calendar) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_schedule_meeting) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendEmailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_send_email) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetAutomatedProbabilityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_set_automated_probability) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetLostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_set_lost) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetWonAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_set_won) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetWonRainbowmanAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_set_won_rainbowman) ---
            */
            return default;
        }

        public async Task<TEntity> ActionShowInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner.py, METHOD: _action_show) ---
            */
            return default;
        }

        public async Task<TEntity> ActionShowPotentialDuplicatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_show_potential_duplicates) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSignupPrepareAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: action_signup_prepare) ---
            */
            return default;
        }

        public async Task<TEntity> ActionTalentPoolAddApplicantsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_talent_pool_add_applicants) ---
            */
            return default;
        }

        public async Task<TEntity> ActionTalentPoolStatButtonAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_talent_pool_stat_button) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnarchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_unarchive) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_unarchive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewCertificationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: res_partner.py, METHOD: action_view_certifications) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewCoursesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py, METHOD: action_view_courses) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewLivechatSessionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: action_view_livechat_sessions) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewLoyaltyCardsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: res_partner.py, METHOD: action_view_loyalty_cards) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewOpportunityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: res_partner.py, METHOD: action_view_opportunity) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewPartnerInvoicesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: action_view_partner_invoices) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewPosOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: action_view_pos_order) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewStockSerialAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_partner.py, METHOD: action_view_stock_serial) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: res_partner.py, METHOD: action_view_tasks) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AddToListAsync<TEntity>(IEnumerable<TEntity> entities, object name, Guid list_id) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py, METHOD: add_to_list) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AddressFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py, METHOD: _address_fields) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _address_fields) ---
            */
            return default;
        }

        public async Task<TEntity> AddressGetAsync<TEntity>(IEnumerable<TEntity> entities, object adr_pref) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: address_get) ---
            */
            return default;
        }

        public async Task<TEntity> ArchiveApplicantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: archive_applicant) ---
            */
            return default;
        }

        public async Task<TEntity> AssertPrimaryEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread_blacklist.py, METHOD: _assert_primary_email) ---
            */
            return default;
        }

        public async Task<TEntity> AssetDifferenceSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object account_type, object @operator, object operand) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _asset_difference_search) ---
            */
            return default;
        }

        public async Task<TEntity> AssignUserlessLeadInTeamInternalAsync<TEntity>(IEnumerable<TEntity> entities, string creation_source) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _assign_userless_lead_in_team) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AutocompleteByNameAsync<TEntity>(IEnumerable<TEntity> entities, object query, Guid query_country_id, object timeout) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: autocomplete_by_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AutocompleteByVatAsync<TEntity>(IEnumerable<TEntity> entities, object vat, Guid query_country_id, object timeout) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: autocomplete_by_vat) ---
            */
            return default;
        }

        public async Task<TEntity> AvatarGetPlaceholderPathInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: res_partner.py, METHOD: _avatar_get_placeholder_path) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _avatar_get_placeholder_path) ---
            */
            return default;
        }

        public async Task<TEntity> BuildErrorPeppolEndpointInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eas, object endpoint) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _build_error_peppol_endpoint) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> BuildVatErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country_code, object wrong_vat, object record_label) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _build_vat_error_message) ---
            */
            return default;
        }

        public async Task<TEntity> BuildVcardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: res_partner.py, METHOD: _build_vcard) ---
            */
            return default;
        }

        public async Task<TEntity> BusSendHistoryMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object channel, object page_history) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: _bus_send_history_message) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonAccountPeppolCheckPartnerEndpointAsync<TEntity>(IEnumerable<TEntity> entities, object company) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: button_account_peppol_check_partner_endpoint) ---
            */
            return default;
        }

        public async Task<TEntity> CanBeEditedByCurrentCustomerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: res_partner.py, METHOD: _can_be_edited_by_current_customer) ---
            --- METHOD SOURCE (MODULE: portal, FILE: res_partner.py, METHOD: _can_be_edited_by_current_customer) ---
            */
            return default;
        }

        public async Task<TEntity> CanEditCountryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _can_edit_country) ---
            --- METHOD SOURCE (MODULE: portal, FILE: res_partner.py, METHOD: _can_edit_country) ---
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: _can_edit_country) ---
            */
            return default;
        }

        public async Task<TEntity> CanEditVatAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: can_edit_vat) ---
            --- METHOD SOURCE (MODULE: portal, FILE: res_partner.py, METHOD: can_edit_vat) ---
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: can_edit_vat) ---
            */
            return default;
        }

        public async Task<TEntity> CheckBarcodeUnicityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_barcode_unicity) ---
            */
            return default;
        }

        public async Task<TEntity> CheckDocumentTypeSupportInternalAsync<TEntity>(IEnumerable<TEntity> entities, object participant_info, object ubl_cii_format, object process_type) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _check_document_type_support) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckImportConsistencyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_import_consistency) ---
            */
            return default;
        }

        public async Task<TEntity> CheckInterviewerAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _check_interviewer_access) ---
            */
            return default;
        }

        public async Task<TEntity> CheckParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPartnerCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_partner_company) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPeppolFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _check_peppol_fields) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckPeppolParticipantExistsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object participant_info, object edi_identification) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _check_peppol_participant_exists) ---
            */
            return default;
        }

        public async Task<TEntity> CheckTalentPoolRequiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _check_talent_pool_required) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatAlAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_al) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatBrAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_br) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatChAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ch) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatCrAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_cr) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatDeAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_de) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatDoAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_do) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatEcAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ec) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatGrAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_gr) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatGtAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_gt) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatHuAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_hu) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatIdAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatIeAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ie) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatIlAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_il) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatInAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_in) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object validation) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _check_vat) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatJpAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_jp) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatMaAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ma) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatMxAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_mx) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatNoAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_no) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckVatNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country_code, object vat_number) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _check_vat_number) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatPeAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_pe) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatPhAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ph) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatRoAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ro) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatRsAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_rs) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatRuAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ru) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatSaAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_sa) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatThAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_th) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatTrAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_tr) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatTwAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_tw) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatUaAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ua) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatUyAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_uy) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatVeAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ve) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatVnAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_vn) ---
            */
            return default;
        }

        public async Task<TEntity> CheckWonValidityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _check_won_validity) ---
            */
            return default;
        }

        public async Task<TEntity> ChildrenSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _children_sync) ---
            */
            return default;
        }

        public async Task<TEntity> CleanWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _clean_website) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ClearRemovedEdiFormatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _clear_removed_edi_formats) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _commercial_fields) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _commercial_fields) ---
            */
            return default;
        }

        public async Task<TEntity> CommercialSyncFromCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _commercial_sync_from_company) ---
            */
            return default;
        }

        public async Task<TEntity> CommercialSyncToDescendantsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields_to_sync) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _commercial_sync_to_descendants) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CompanyDependentCommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _company_dependent_commercial_fields) ---
            */
            return default;
        }

        public async Task<TEntity> CompanyDependentCommercialSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _company_dependent_commercial_sync) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccountMoveCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_account_move_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeActiveLangCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_active_lang_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_application_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationStatisticsHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_application_statistics_hook) ---
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: _compute_application_statistics_hook) ---
            --- METHOD SOURCE (MODULE: crm, FILE: res_partner.py, METHOD: _compute_application_statistics_hook) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _compute_application_statistics_hook) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: res_partner.py, METHOD: _compute_application_statistics_hook) ---
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: _compute_application_statistics_hook) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_application_statistics_hook) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_application_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_application_status) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailableInvoiceTemplatePdfReportIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_available_invoice_template_pdf_report_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailablePeppolEasInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _compute_available_peppol_eas) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _compute_available_peppol_eas) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailablePeppolEdiFormatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _compute_available_peppol_edi_formats) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailablePeppolSendingMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _compute_available_peppol_sending_methods) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1024InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_1024) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar128InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_128) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1920InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_1920) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar256InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_256) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar512InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_512) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatarInternalAsync<TEntity>(IEnumerable<TEntity> entities, object avatar_field, object image_field) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBankCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_bank_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBomIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py, METHOD: _compute_bom_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCertificationsCompanyCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: res_partner.py, METHOD: _compute_certifications_company_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCertificationsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: res_partner.py, METHOD: _compute_certifications_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialCompanyNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_commercial_company_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_commercial_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_commercial_partner) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_company_currency) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_company) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_registry) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_registry_label) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_registry_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompleteNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_complete_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeContactAddressInlineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _compute_contact_address_inline) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeContactAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_contact_address) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeContactNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_contact_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCountActiveCardsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: res_partner.py, METHOD: _compute_count_active_cards) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCreditToInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_credit_to_invoice) ---
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: _compute_credit_to_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateClosedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_date_closed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateLastStageUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_date_last_stage_update) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateOpenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_date_open) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDayCloseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_day_close) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_day) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDayOpenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_day_open) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDaysSalesOutstandingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_days_sales_outstanding) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDelayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_delay) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDepartmentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_department) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailDomainCriterionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_email_domain_criterion) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailFormattedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_email_formatted) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailFromInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_email_from) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailNormalizedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread_blacklist.py, METHOD: _compute_email_normalized) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_email_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner.py, METHOD: _compute_employee) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner.py, METHOD: _compute_employees_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_partner.py, METHOD: _compute_event_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFiscalCountryCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_fiscal_country_codes) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFiscalCountryGroupCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_fiscal_country_group_codes) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFiscalPositionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _compute_fiscal_position_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFunctionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_function) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeGetIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_get_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeImStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _compute_im_status) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeImplementedPartnerCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py, METHOD: _compute_implemented_partner_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_invoice_edi_format) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceEmailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _compute_invoice_emails) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsApplicantInPoolInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_is_applicant_in_pool) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsAutomatedProbabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_is_automated_probability) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsBlacklistedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread_blacklist.py, METHOD: _compute_is_blacklisted) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsInCallInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _compute_is_in_call) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMondialrelayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: res_partner.py, METHOD: _compute_is_mondialrelay) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPartnerVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_is_partner_visible) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPeppolEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _compute_is_peppol_edi_format) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPoolInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_is_pool) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPublicInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_is_public) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsSubcontractorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py, METHOD: _compute_is_subcontractor) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsUblFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _compute_is_ubl_format) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLangActiveCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_lang_active_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLangIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_lang_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_lang) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLeaveDateToInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: res_partner.py, METHOD: _compute_leave_date_to) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatChannelCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: _compute_livechat_channel_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMainUserIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_main_user_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMeetingCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: _compute_meeting_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMeetingDisplayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_meeting_display) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_meeting_display) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMeetingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: _compute_meeting) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_name) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py, METHOD: _compute_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOnTimeRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: res_partner.py, METHOD: _compute_on_time_rate) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOpportunityCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: res_partner.py, METHOD: _compute_opportunity_count) ---
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py, METHOD: _compute_opportunity_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOptOutInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py, METHOD: _compute_opt_out) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerAddressValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_partner_address_values) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerCompanyRegistryPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_partner_company_registry_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerEmailUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_partner_email_update) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerIapInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_plugin, FILE: res_partner.py, METHOD: _compute_partner_iap_info) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_partner_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerPhoneEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_partner_phone_email) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerPhoneSanitizedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_partner_phone_sanitized) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerPhoneUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_partner_phone_update) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerShareInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_partner_share) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerVatPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_partner_vat_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerWeightInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py, METHOD: _compute_partner_weight) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentTokenCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: res_partner.py, METHOD: _compute_payment_token_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePeppolEasInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _compute_peppol_eas) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePeppolEndpointInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _compute_peppol_endpoint) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePerformViesValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _compute_perform_vies_validation) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_phone) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePhoneStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_phone_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePickingIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py, METHOD: _compute_picking_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePosContactAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _compute_pos_contact_address) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePosOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _compute_pos_order) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePotentialLeadDuplicatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_potential_lead_duplicates) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProbabilitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_probabilities) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductPricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: res_partner.py, METHOD: _compute_product_pricelist) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py, METHOD: _compute_production_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProratedRevenueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_prorated_revenue) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePurchaseOrderCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: res_partner.py, METHOD: _compute_purchase_order_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurringRevenueMonthlyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_recurring_revenue_monthly) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurringRevenueMonthlyProratedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_recurring_revenue_monthly_prorated) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurringRevenueProratedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_recurring_revenue_prorated) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSaleOrderCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: _compute_sale_order_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSameVatPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_same_vat_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowCreditLimitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_show_credit_limit) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideChannelCompanyCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py, METHOD: _compute_slide_channel_company_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideChannelValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py, METHOD: _compute_slide_channel_values) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_stage_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_stage) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStaticMapUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_partner.py, METHOD: _compute_static_map_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStaticMapUrlIsValidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_partner.py, METHOD: _compute_static_map_url_is_valid) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStreetDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py, METHOD: _compute_street_data) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSupplierInvoiceCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_supplier_invoice_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTalentPoolCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_talent_pool_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: res_partner.py, METHOD: _compute_task_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTeamIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_team_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTypeAddressLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_type_address_label) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTzOffsetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_tz_offset) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUsePartnerCreditLimitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_use_partner_credit_limit) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserCompanyIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_user_company_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_user_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_user) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserLivechatUsernameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: _compute_user_livechat_username) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVatLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_vat_label) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeViesValidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _compute_vies_valid) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_website) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: website_partner, FILE: res_partner.py, METHOD: _compute_website_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWonStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_won_status) ---
            */
            return default;
        }

        public async Task<TEntity> ConvertFieldsToValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_names) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _convert_fields_to_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ConvertHuLocalToEuVatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object local_vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _convert_hu_local_to_eu_vat) ---
            */
            return default;
        }

        public async Task<TEntity> ConvertOpportunityAsync<TEntity>(IEnumerable<TEntity> entities, object partner, List<Guid> user_ids, Guid team_id) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: convert_opportunity) ---
            */
            return default;
        }

        public async Task<TEntity> ConvertOpportunityDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, Guid team_id) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _convert_opportunity_data) ---
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py, METHOD: copy) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: copy_data) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py, METHOD: create) ---
            */
            return default;
        }

        public async Task<TEntity> CreateCompanyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: create_company) ---
            */
            return default;
        }

        public async Task<TEntity> CreateContactParentCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _create_contact_parent_company) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _create_contact_parent_company) ---
            */
            return default;
        }

        public async Task<TEntity> CreateCustomerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_parent) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _create_customer) ---
            */
            return default;
        }

        public async Task<TEntity> CreateEmployeeFromApplicantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: create_employee_from_applicant) ---
            */
            return default;
        }

        public async Task<TEntity> CreatePortalUsersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: res_partner.py, METHOD: _create_portal_users) ---
            */
            return default;
        }

        public async Task<TEntity> CreationMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _creation_message) ---
            */
            return default;
        }

        public async Task<TEntity> CreationSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _creation_subtype) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _creation_subtype) ---
            */
            return default;
        }

        public async Task<TEntity> CreditDebitGetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _credit_debit_get) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreditSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _credit_search) ---
            */
            return default;
        }

        public async Task<TEntity> CronUpdateAutomatedProbabilitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _cron_update_automated_probabilities) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DebitSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _debit_search) ---
            */
            return default;
        }

        public async Task<TEntity> DeduceCountryCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _deduce_country_code) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _default_category) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultDisplayInvoiceTemplatePdfReportIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _default_display_invoice_template_pdf_report_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py, METHOD: default_get) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DetectLoopSenderDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_from_normalized) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread_blacklist.py, METHOD: _detect_loop_sender_domain) ---
            */
            return default;
        }

        public async Task<TEntity> DisplayAddressDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _display_address_depends) ---
            */
            return default;
        }

        public async Task<TEntity> DisplayAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object without_company) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _display_address) ---
            */
            return default;
        }

        public async Task<TEntity> DoButtonPrintAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: do_button_print) ---
            */
            return default;
        }

        public async Task<TEntity> DoPartnerMailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: do_partner_mail) ---
            */
            return default;
        }

        public async Task<TEntity> DoPartnerManualActionAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: do_partner_manual_action) ---
            */
            return default;
        }

        public async Task<TEntity> DoPartnerManualActionDermanordAsync<TEntity>(IEnumerable<TEntity> entities, object followup_line) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: do_partner_manual_action_dermanord) ---
            */
            return default;
        }

        public async Task<TEntity> DoPartnerPrintAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> wizard_partner_ids, object data) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: do_partner_print) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> EnrichByDomainAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object timeout) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: enrich_by_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> EnrichByDunsAsync<TEntity>(IEnumerable<TEntity> entities, object duns, object timeout) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: enrich_by_duns) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> EnrichByGstAsync<TEntity>(IEnumerable<TEntity> entities, object gst, object timeout) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: enrich_by_gst) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureSameCompanyThanProjectsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: res_partner.py, METHOD: _ensure_same_company_than_projects) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureSameCompanyThanTasksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: res_partner.py, METHOD: _ensure_same_company_than_tasks) ---
            */
            return default;
        }

        public async Task<TEntity> FetchChildrenPartnersForHierarchyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: res_partner.py, METHOD: _fetch_children_partners_for_hierarchy) ---
            */
            return default;
        }

        public async Task<TEntity> FieldStoreReprInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _field_store_repr) ---
            */
            return default;
        }

        public async Task<object> FieldToSqlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @alias, object field_expr, object query) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _field_to_sql) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FieldsGetAsync<TEntity>(IEnumerable<TEntity> entities, object allfields, object attributes) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py, METHOD: fields_get) ---
            */
            return default;
        }

        public async Task<TEntity> FieldsSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _fields_sync) ---
            */
            return default;
        }

        public async Task<TEntity> FieldsViewGetAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type, object toolbar, object submenu) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: fields_view_get) ---
            */
            return default;
        }

        public async Task<TEntity> FindAccountingPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _find_accounting_partner) ---
            */
            return default;
        }

        public async Task<TEntity> FindMatchingPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _find_matching_partner) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FindOrCreateAsync<TEntity>(IEnumerable<TEntity> entities, object email, object assert_valid_email) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: find_or_create) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FindOrCreateFromEmailsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object emails, object ban_emails, object filter_found, object additional_values, object no_create, object sort_key, object sort_reverse) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _find_or_create_from_emails) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FormatDataCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object iap_data) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: _format_data_company) ---
            */
            return default;
        }

        public async Task<TEntity> FormatPropertiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _format_properties) ---
            */
            return default;
        }

        public async Task<TEntity> FormatVatChAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_ch) ---
            */
            return default;
        }

        public async Task<TEntity> FormatVatClAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_cl) ---
            */
            return default;
        }

        public async Task<TEntity> FormatVatCoAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_co) ---
            */
            return default;
        }

        public async Task<TEntity> FormatVatEuAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_eu) ---
            */
            return default;
        }

        public async Task<TEntity> FormatVatHuAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_hu) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FormatVatNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country_code, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _format_vat_number) ---
            */
            return default;
        }

        public async Task<TEntity> FormatVatSmAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_sm) ---
            */
            return default;
        }

        public async Task<TEntity> FormatVatVnAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_vn) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FormattingAddressFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _formatting_address_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GelatoPrepareAddressPayloadInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: res_partner.py, METHOD: _gelato_prepare_address_payload) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateSignupTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expiration) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _generate_signup_token) ---
            */
            return default;
        }

        public async Task<TEntity> GeoLocalizeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_geolocalize, FILE: res_partner.py, METHOD: geo_localize) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GeoLocalizeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object street, object zip, object city, object state, object country) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_geolocalize, FILE: res_partner.py, METHOD: _geo_localize) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccountStatisticsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _get_account_statistics_count) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAddressFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: res_partner.py, METHOD: _get_address_format) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_address_format) ---
            */
            return default;
        }

        public async Task<TEntity> GetAddressValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_address_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetAllAddrInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner.py, METHOD: _get_all_addr) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_all_addr) ---
            */
            return default;
        }

        public async Task<TEntity> GetAmountsAndDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _get_amounts_and_date) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttachmentNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _get_attachment_number) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttendeeDetailAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> meeting_ids) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: get_attendee_detail) ---
            */
            return default;
        }

        public async Task<TEntity> GetBackendMenuIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: website_customer, FILE: res_partner.py, METHOD: get_backend_menu_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetBackendRootMenuIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: contacts, FILE: res_partner.py, METHOD: _get_backend_root_menu_ids) ---
            */
            return default;
        }

        public async Task<TEntity> GetBusyCalendarEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_datetime, object end_datetime) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: _get_busy_calendar_events) ---
            */
            return default;
        }

        public async Task<TEntity> GetCommercialValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_commercial_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompanyCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _get_company_currency) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompanyRegistryLabelsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_company_registry_labels) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompleteNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_complete_name) ---
            */
            return default;
        }

        public async Task<TEntity> GetContactOpportunitiesDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: res_partner.py, METHOD: _get_contact_opportunities_domain) ---
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py, METHOD: _get_contact_opportunities_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetCountryNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: res_partner.py, METHOD: _get_country_name) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_country_name) ---
            */
            return default;
        }

        public async Task<TEntity> GetCurrentPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: portal, FILE: res_partner.py, METHOD: _get_current_partner) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: res_partner.py, METHOD: _get_current_partner) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetCurrentPersonaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_current_persona) ---
            */
            return default;
        }

        public async Task<TEntity> GetCustomerInformationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_customer_information) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _get_customer_information) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultAddressFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_default_address_format) ---
            */
            return default;
        }

        public async Task<TEntity> GetDeliveryAddressDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: res_partner.py, METHOD: _get_delivery_address_domain) ---
            --- METHOD SOURCE (MODULE: portal, FILE: res_partner.py, METHOD: _get_delivery_address_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetDurationFromTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object trackings) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _get_duration_from_tracking) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEdiBuilderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_edi_format) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_edi_builder) ---
            */
            return default;
        }

        public async Task<TEntity> GetEmployeeCreateValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _get_employee_create_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetEmployeesFromAttendeesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object everybody) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_calendar, FILE: res_partner.py, METHOD: _get_employees_from_attendees) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEmptyListHelpAsync<TEntity>(IEnumerable<TEntity> entities, object help_message) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: get_empty_list_help) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: get_empty_list_help) ---
            */
            return default;
        }

        public async Task<TEntity> GetFollowupOverdueQueryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object args, object overdue_only) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _get_followup_overdue_query) ---
            */
            return default;
        }

        public async Task<TEntity> GetFollowupTableHtmlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: get_followup_table_html) ---
            */
            return default;
        }

        public async Task<TEntity> GetFrontendWritableFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _get_frontend_writable_fields) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _get_frontend_writable_fields) ---
            --- METHOD SOURCE (MODULE: portal, FILE: res_partner.py, METHOD: _get_frontend_writable_fields) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: res_partner.py, METHOD: _get_frontend_writable_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetImStatusAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_im_status_access_token) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: get_import_templates) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py, METHOD: get_import_templates) ---
            */
            return default;
        }

        public async Task<TEntity> GetLatestInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _get_latest) ---
            */
            return default;
        }

        public async Task<TEntity> GetLeadDuplicatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object email, object include_lost) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_lead_duplicates) ---
            */
            return default;
        }

        public async Task<TEntity> GetLoginDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _get_login_date) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMentionSuggestionsAsync<TEntity>(IEnumerable<TEntity> entities, object search, object limit) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: get_mention_suggestions) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMentionSuggestionsDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object search) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_mention_suggestions_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMentionSuggestionsFromChannelAsync<TEntity>(IEnumerable<TEntity> entities, Guid channel_id, object search, object limit) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: get_mention_suggestions_from_channel) ---
            */
            return default;
        }

        public async Task<TEntity> GetMentionTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_mention_token) ---
            */
            return default;
        }

        public async Task<TEntity> GetNeedactionCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_needaction_count) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetNewPartnerAsync<TEntity>(IEnumerable<TEntity> entities, Guid config_id, object domain, object offset) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: get_new_partner) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetOnLeaveIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: res_partner.py, METHOD: _get_on_leave_ids) ---
            */
            return default;
        }

        public async Task<TEntity> GetOpportunityMeetingViewParametersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_opportunity_meeting_view_parameters) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetParticipantInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object edi_identification) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _get_participant_info) ---
            */
            return default;
        }

        public async Task<TEntity> GetPartnerEmailUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_void) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_partner_email_update) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPartnerFromTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object token) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _get_partner_from_token) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPartnerLocalisationFieldsRequiredToInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, Guid country_id) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: get_partner_localisation_fields_required_to_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPhoneUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_void) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_partner_phone_update) ---
            */
            return default;
        }

        public async Task<TEntity> GetPartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _get_partners) ---
            */
            return default;
        }

        public async Task<TEntity> GetPeppolEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_peppol_edi_format) ---
            */
            return default;
        }

        public async Task<TEntity> GetPeppolEndpointValueInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country_code, object field, object eas) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_peppol_endpoint_value) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPeppolFormatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_peppol_formats) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPeppolVerificationStateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object peppol_endpoint, object peppol_eas, object invoice_edi_format, object process_type) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _get_peppol_verification_state) ---
            */
            return default;
        }

        public async Task<TEntity> GetRainbowmanMessageAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: get_rainbowman_message) ---
            */
            return default;
        }

        public async Task<TEntity> GetRainbowmanMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_rainbowman_message) ---
            */
            return default;
        }

        public async Task<TEntity> GetRottingDependsFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_rotting_depends_fields) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _get_rotting_depends_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetRottingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_rotting_domain) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _get_rotting_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetSaleOrderDomainCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: _get_sale_order_domain_count) ---
            */
            return default;
        }

        public async Task<TEntity> GetScheduleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_period, object stop_period, object everybody, object merge) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_calendar, FILE: res_partner.py, METHOD: _get_schedule) ---
            */
            return default;
        }

        public async Task<TEntity> GetSignupUrlForActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object url, object action, object view_type, Guid menu_id, Guid res_id, object model) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _get_signup_url_for_action) ---
            */
            return default;
        }

        public async Task<TEntity> GetSignupUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _get_signup_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetSimilarApplicantsDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object ignore_talent, object only_talent) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _get_similar_applicants_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetStoreAvatarCardFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_store_avatar_card_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetStoreLivechatUsernameFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: _get_store_livechat_username_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetStoreMentionFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_store_mention_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetStreetSplitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py, METHOD: _get_street_split) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_street_split) ---
            */
            return default;
        }

        public async Task<TEntity> GetSuggestedInvoiceEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _get_suggested_invoice_edi_format) ---
            */
            return default;
        }

        public async Task<TEntity> GetSuggestedPeppolEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_suggested_peppol_edi_format) ---
            */
            return default;
        }

        public async Task<TEntity> GetSuggestedUblCiiEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_suggested_ubl_cii_edi_format) ---
            */
            return default;
        }

        public async Task<TEntity> GetSyncedCommercialValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_synced_commercial_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetUblCiiFormatsByCountryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_ubl_cii_formats_by_country) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetUblCiiFormatsInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_ubl_cii_formats_info) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetUblCiiFormatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_ubl_cii_formats) ---
            */
            return default;
        }

        public async Task<TEntity> GetVatRequiredValidInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _get_vat_required_valid) ---
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _get_vat_required_valid) ---
            */
            return default;
        }

        public async Task<TEntity> GetVcardFileInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: res_partner.py, METHOD: _get_vcard_file) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: get_view) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewCacheKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_view_cache_key) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: _get_view) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetWorkingHoursForAllAttendeesAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attendee_ids, object date_from, object date_to, object everybody) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_calendar, FILE: res_partner.py, METHOD: get_working_hours_for_all_attendees) ---
            */
            return default;
        }

        public async Task<TEntity> GetWorklocationAsync<TEntity>(IEnumerable<TEntity> entities, object start_date, object end_date) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_homeworking_calendar, FILE: res_partner.py, METHOD: get_worklocation) ---
            */
            return default;
        }

        public async Task<TEntity> GoogleMapImgAsync<TEntity>(IEnumerable<TEntity> entities, object zoom, object width, object height) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_partner.py, METHOD: google_map_img) ---
            */
            return default;
        }

        public async Task<TEntity> GoogleMapLinkAsync<TEntity>(IEnumerable<TEntity> entities, object zoom) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_partner.py, METHOD: google_map_link) ---
            */
            return default;
        }

        public async Task<TEntity> GoogleMapSignedImgInternalAsync<TEntity>(IEnumerable<TEntity> entities, object zoom, object width, object height) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_partner.py, METHOD: _google_map_signed_img) ---
            */
            return default;
        }

        public async Task<TEntity> HandleFirstContactCreationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _handle_first_contact_creation) ---
            */
            return default;
        }

        public async Task<TEntity> HandlePartnerAssignmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid force_partner_id, object create_missing, object with_parent) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _handle_partner_assignment) ---
            */
            return default;
        }

        public async Task<TEntity> HandleSalesmenAssignmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> user_ids, Guid team_id) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _handle_salesmen_assignment) ---
            */
            return default;
        }

        public async Task<TEntity> HandleWonLostInternalAsync<TEntity>(IEnumerable<TEntity> entities, object old_status_by_lead, object new_status_by_lead) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _handle_won_lost) ---
            */
            return default;
        }

        public async Task<TEntity> HasInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner_domain) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _has_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> HasOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner_domain) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: _has_order) ---
            */
            return default;
        }

        public async Task<TEntity> IapPartnerAutocompleteGetTagIdsAsync<TEntity>(IEnumerable<TEntity> entities, object unspsc_codes) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: iap_partner_autocomplete_get_tag_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> IapReplaceIndustryCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object iap_data) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: _iap_replace_industry_code) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> IapReplaceLanguageCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object iap_data) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: _iap_replace_language_codes) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> IapReplaceLocationCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object iap_data) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: _iap_replace_location_codes) ---
            */
            return default;
        }

        public async Task<TEntity> IeCheckCharInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _ie_check_char) ---
            */
            return default;
        }

        public async Task<TEntity> IncreaseRankInternalAsync<TEntity>(IEnumerable<TEntity> entities, string field, int n) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _increase_rank) ---
            */
            return default;
        }

        public async Task<TEntity> IntervalToBusinessHoursInternalAsync<TEntity>(IEnumerable<TEntity> entities, object working_intervals) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_calendar, FILE: res_partner.py, METHOD: _interval_to_business_hours) ---
            */
            return default;
        }

        public async Task<TEntity> InverseEmailFromInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _inverse_email_from) ---
            */
            return default;
        }

        public async Task<TEntity> InverseInvoiceEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _inverse_invoice_edi_format) ---
            */
            return default;
        }

        public async Task<TEntity> InversePartnerEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _inverse_partner_email) ---
            */
            return default;
        }

        public async Task<TEntity> InversePhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _inverse_phone) ---
            */
            return default;
        }

        public async Task<TEntity> InverseProductPricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: res_partner.py, METHOD: _inverse_product_pricelist) ---
            */
            return default;
        }

        public async Task<TEntity> InverseStreetDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py, METHOD: _inverse_street_data) ---
            */
            return default;
        }

        public async Task<TEntity> InverseUsePartnerCreditLimitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _inverse_use_partner_credit_limit) ---
            */
            return default;
        }

        public async Task<TEntity> InverseVatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _inverse_vat) ---
            */
            return default;
        }

        public async Task<TEntity> InvoiceTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _invoice_total) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> IsNameSplitActivatedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py, METHOD: _is_name_split_activated) ---
            */
            return default;
        }

        public async Task<TEntity> IsRuleBasedAssignmentActivatedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _is_rule_based_assignment_activated) ---
            */
            return default;
        }

        public async Task<TEntity> IsValidRucEcAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: is_valid_ruc_ec) ---
            */
            return default;
        }

        public async Task<TEntity> LinkApplicantToTalentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: link_applicant_to_talent) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object config) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _load_pos_data_fields) ---
            --- METHOD SOURCE (MODULE: pos_sale, FILE: res_partner.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosSelfDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: res_partner.py, METHOD: _load_pos_self_data_domain) ---
            */
            return default;
        }

        public async Task<TEntity> LoadRecordsCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _load_records_create) ---
            */
            return default;
        }

        public async Task<TEntity> LogMeetingAsync<TEntity>(IEnumerable<TEntity> entities, object meeting) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: log_meeting) ---
            */
            return default;
        }

        public async Task<TEntity> LogVerificationStateUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object old_value, object new_value) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _log_verification_state_update) ---
            */
            return default;
        }

        public async Task<TEntity> MailActionBlacklistRemoveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread_blacklist.py, METHOD: mail_action_blacklist_remove) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _mail_get_partners) ---
            */
            return default;
        }

        public async Task<TEntity> MergeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fnames) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_data) ---
            */
            return default;
        }

        public async Task<TEntity> MergeDependencesAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_dependences_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> MergeDependencesCalendarEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_dependences_calendar_events) ---
            */
            return default;
        }

        public async Task<TEntity> MergeDependencesHistoryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_dependences_history) ---
            */
            return default;
        }

        public async Task<TEntity> MergeDependencesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_dependences) ---
            */
            return default;
        }

        public async Task<TEntity> MergeFollowersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_followers) ---
            #endif
            return default;
        }

        public async Task<TEntity> MergeGetFieldsAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_get_fields_address) ---
            */
            return default;
        }

        public async Task<TEntity> MergeGetFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_get_fields) ---
            */
            return default;
        }

        public async Task<TEntity> MergeGetFieldsSpecificInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_get_fields_specific) ---
            */
            return default;
        }

        public async Task<TEntity> MergeLogSummaryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object merged_followers, object opportunities_tail) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_log_summary) ---
            */
            return default;
        }

        public async Task<TEntity> MergeMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object destination, object source) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _merge_method) ---
            */
            return default;
        }

        public async Task<TEntity> MergeOpportunityAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id, Guid team_id, object auto_unlink) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: merge_opportunity) ---
            */
            return default;
        }

        public async Task<TEntity> MergeOpportunityInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id, Guid team_id, object auto_unlink, object max_length) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_opportunity) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MessageNewAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object custom_values) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: message_new) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: message_new) ---
            */
            return default;
        }

        public async Task<TEntity> MessagePostAfterHookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _message_post_after_hook) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _message_post_after_hook) ---
            */
            return default;
        }

        public async Task<TEntity> MessageReceiveBounceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email, object partner) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread_blacklist.py, METHOD: _message_receive_bounce) ---
            */
            return default;
        }

        public async Task<TEntity> MessageResetBounceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread_blacklist.py, METHOD: _message_reset_bounce) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MondialrelaySearchOrCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: res_partner.py, METHOD: _mondialrelay_search_or_create) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NameCreateAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py, METHOD: name_create) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyByEmailPrepareRenderingContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals, object model_description, object force_email_company, object force_email_lang, object force_record_name) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _notify_by_email_prepare_rendering_context) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetReplyToInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @default, Guid author_id) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _notify_get_reply_to) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _notify_get_reply_to) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCityIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py, METHOD: _onchange_city_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCommercialPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _onchange_commercial_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _onchange_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: onchange_company_type) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCountryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py, METHOD: _onchange_country_id) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _onchange_country_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeParentIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: onchange_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePhoneValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _onchange_phone_validation) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePropertyProductPricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: res_partner.py, METHOD: _onchange_property_product_pricelist) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _onchange_state) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeVatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _onchange_vat) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeVerifyPeppolStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _onchange_verify_peppol_status) ---
            */
            return default;
        }

        public async Task<TEntity> OpenCommercialEntityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: open_commercial_entity) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: open_commercial_entity) ---
            */
            return default;
        }

        public async Task<TEntity> OrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _order) ---
            */
            return default;
        }

        public async Task<TEntity> PaymentDueSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _payment_due_search) ---
            */
            return default;
        }

        public async Task<TEntity> PaymentEarliestDateSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _payment_earliest_date_search) ---
            */
            return default;
        }

        public async Task<TEntity> PaymentOverdueSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _payment_overdue_search) ---
            */
            return default;
        }

        public async Task<TEntity> PeppolEasEndpointDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _peppol_eas_endpoint_depends) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PeppolLookupParticipantInternalAsync<TEntity>(IEnumerable<TEntity> entities, object edi_identification) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _peppol_lookup_participant) ---
            */
            return default;
        }

        public async Task<TEntity> PhoneGetNumberFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _phone_get_number_fields) ---
            */
            return default;
        }

        public async Task<TEntity> PlsGetLeadPlsValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_get_lead_pls_values) ---
            */
            return default;
        }

        public async Task<TEntity> PlsGetNaiveBayesProbabilitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object batch_mode, object is_tooltip) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_get_naive_bayes_probabilities) ---
            */
            return default;
        }

        public async Task<TEntity> PlsGetSafeFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_get_safe_fields) ---
            */
            return default;
        }

        public async Task<TEntity> PlsGetSafeStartDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_get_safe_start_date) ---
            */
            return default;
        }

        public async Task<TEntity> PlsGetWonLostTotalCountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object team_results) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_get_won_lost_total_count) ---
            */
            return default;
        }

        public async Task<TEntity> PlsIncrementFrequenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object from_state, object to_state) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_increment_frequencies) ---
            */
            return default;
        }

        public async Task<TEntity> PlsIncrementFrequencyDictInternalAsync<TEntity>(IEnumerable<TEntity> entities, object frequencies, object field, object @value, object won, object lost) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_increment_frequency_dict) ---
            */
            return default;
        }

        public async Task<TEntity> PlsPrepareFrequenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object lead_values, object leads_pls_fields, object target_state) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_prepare_frequencies) ---
            */
            return default;
        }

        public async Task<TEntity> PlsPrepareUpdateFrequencyTableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object rebuild, object target_state) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_prepare_update_frequency_table) ---
            */
            return default;
        }

        public async Task<TEntity> PlsUpdateFrequencyTableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_frequencies_by_team, object step, object existing_frequencies_by_team) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_update_frequency_table) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareAddressValuesFromPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _prepare_address_values_from_partner) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareContactNameFromPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _prepare_contact_name_from_partner) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareCustomerValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner_name, object is_company, Guid parent_id) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _prepare_customer_values) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareDisplayAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object without_company) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _prepare_display_address) ---
            */
            return default;
        }

        public async Task<TEntity> PreparePartnerNameFromPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _prepare_partner_name_from_partner) ---
            */
            return default;
        }

        public async Task<TEntity> PreparePlsTooltipDataAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: prepare_pls_tooltip_data) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareValuesFromPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _prepare_values_from_partner) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ProcessEnrichedResponseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object response, object error) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: _process_enriched_response) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ReadGroupStageIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stages, object domain) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _read_group_stage_ids) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _read_group_stage_ids) ---
            */
            return default;
        }

        public async Task<TEntity> RebuildPlsFrequencyTableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _rebuild_pls_frequency_table) ---
            */
            return default;
        }

        public async Task<TEntity> RedirectLeadOpportunityViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: redirect_lead_opportunity_view) ---
            */
            return default;
        }

        public async Task<TEntity> ResetApplicantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: reset_applicant) ---
            */
            return default;
        }

        public async Task<TEntity> RetrievePartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, object phone, object email, object vat, object domain, object company) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _retrieve_partner) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RetrievePartnerWithNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, object extra_domain) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _retrieve_partner_with_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RetrievePartnerWithPhoneEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object phone, object email, object extra_domain) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _retrieve_partner_with_phone_email) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RetrievePartnerWithVatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vat, object extra_domain) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _retrieve_partner_with_vat) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RunVatChecksInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country, object vat, object partner_name, object validation) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _run_vat_checks) ---
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _run_vat_checks) ---
            */
            return default;
        }

        public async Task<TEntity> ScheduleMeetingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: schedule_meeting) ---
            */
            return default;
        }

        public async Task<TEntity> SearchApplicationStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _search_application_status) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchFetchAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object field_names, object offset, object limit, object order) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: search_fetch) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchForChannelInviteAsync<TEntity>(IEnumerable<TEntity> entities, object search_term, Guid channel_id, object limit) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: search_for_channel_invite) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchForChannelInviteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object store, object search_term, Guid channel_id, object limit) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _search_for_channel_invite) ---
            */
            return default;
        }

        public async Task<TEntity> SearchForChannelInviteToStoreInternalAsync<TEntity>(IEnumerable<TEntity> entities, object store, object channel) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: _search_for_channel_invite_to_store) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _search_for_channel_invite_to_store) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsApplicantInPoolInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _search_is_applicant_in_pool) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchIsBlacklistedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread_blacklist.py, METHOD: _search_is_blacklisted) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsSubcontractorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py, METHOD: _search_is_subcontractor) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchMentionSuggestionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object limit, object extra_domain) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _search_mention_suggestions) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchOptOutInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py, METHOD: _search_opt_out) ---
            */
            return default;
        }

        public async Task<TEntity> SearchSlideChannelCompletedIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py, METHOD: _search_slide_channel_completed_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchSlideChannelIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py, METHOD: _search_slide_channel_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SetCalendarLastNotifAckInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: _set_calendar_last_notif_ack) ---
            */
            return default;
        }

        public async Task<TEntity> SignupCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: signup_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> SignupGetAuthParamAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: signup_get_auth_param) ---
            */
            return default;
        }

        public async Task<TEntity> SignupPrepareAsync<TEntity>(IEnumerable<TEntity> entities, object signup_type) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: signup_prepare) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SignupRetrieveInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object token) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _signup_retrieve_info) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SignupRetrievePartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object token, object check_validity, object raise_exception) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _signup_retrieve_partner) ---
            */
            return default;
        }

        public async Task<TEntity> SortByConfidenceLevelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reverse) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _sort_by_confidence_level) ---
            */
            return default;
        }

        public async Task<TEntity> SplitVatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _split_vat) ---
            */
            return default;
        }

        public async Task<TEntity> StageFindInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid team_id, object domain, object order, object limit) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _stage_find) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SyncedCommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: res_partner.py, METHOD: _synced_commercial_fields) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _synced_commercial_fields) ---
            */
            return default;
        }

        public async Task<TEntity> ToStoreDefaultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _to_store_defaults) ---
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _track_subtype) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        public async Task<TEntity> TrackTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changes) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _track_template) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkContactRelEmployeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner.py, METHOD: _unlink_contact_rel_employee) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _unlink_except_user) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkIfPartnerInAccountMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _unlink_if_partner_in_account_move) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkIfPosNoOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _unlink_if_pos_no_orders) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _update_address) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateAutomatedProbabilitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _update_automated_probabilities) ---
            */
            return default;
        }

        public async Task<TEntity> UpdatePeppolStatePerCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _update_peppol_state_per_company) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ViewHeaderGetAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: view_header_get) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: write) ---
            */
            return default;
        }

        public async Task<TEntity> WriteCompanyTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _write_company_type) ---
            */
            return default;
        }
    }
}