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
    [Module("base", Category = "Base")]
    public partial class FormatAddressMixinAppService : ApplicationService, IFormatAddressMixinAppService
    {

        public FormatAddressMixinAppService() 
        {

        }

        public async Task<TEntity> AccessibleBranchesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _accessible_branches) ---
            */
            return default;
        }

        public async Task<TEntity> ActionAllCompanyBranchesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: action_all_company_branches) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRescheduleMeetingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_reschedule_meeting) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRestoreAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_restore) ---
            */
            return default;
        }

        public async Task<TEntity> ActionScheduleMeetingAsync<TEntity>(IEnumerable<TEntity> entities, object smart_calendar) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_schedule_meeting) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetAutomatedProbabilityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_set_automated_probability) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetLostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_set_lost) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetWonAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_set_won) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetWonRainbowmanAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_set_won_rainbowman) ---
            */
            return default;
        }

        public async Task<TEntity> ActionShowPotentialDuplicatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_show_potential_duplicates) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnarchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_unarchive) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AddressFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _address_fields) ---
            */
            return default;
        }

        public async Task<TEntity> AddressGetAsync<TEntity>(IEnumerable<TEntity> entities, object adr_pref) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: address_get) ---
            */
            return default;
        }

        public async Task<TEntity> AllBranchesSelectedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _all_branches_selected) ---
            */
            return default;
        }

        public async Task<TEntity> AssignUserlessLeadInTeamInternalAsync<TEntity>(IEnumerable<TEntity> entities, string creation_source) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _assign_userless_lead_in_team) ---
            */
            return default;
        }

        public async Task<TEntity> AvatarGetPlaceholderPathInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _avatar_get_placeholder_path) ---
            */
            return default;
        }

        public async Task<TEntity> CacheInvalidationFieldsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: cache_invalidation_fields) ---
            */
            return default;
        }

        public async Task<TEntity> CheckActiveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _check_active) ---
            */
            return default;
        }

        public async Task<TEntity> CheckBarcodeUnicityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_barcode_unicity) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckImportConsistencyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_import_consistency) ---
            */
            return default;
        }

        public async Task<TEntity> CheckParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPartnerCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_partner_company) ---
            */
            return default;
        }

        public async Task<TEntity> CheckRootDelegatedFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _check_root_delegated_fields) ---
            */
            return default;
        }

        public async Task<TEntity> CheckWonValidityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _check_won_validity) ---
            */
            return default;
        }

        public async Task<TEntity> ChildrenSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _children_sync) ---
            */
            return default;
        }

        public async Task<TEntity> CleanWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _clean_website) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _commercial_fields) ---
            */
            return default;
        }

        public async Task<TEntity> CommercialSyncFromCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _commercial_sync_from_company) ---
            */
            return default;
        }

        public async Task<TEntity> CommercialSyncToDescendantsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields_to_sync) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _commercial_sync_to_descendants) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CompanyDependentCommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _company_dependent_commercial_fields) ---
            */
            return default;
        }

        public async Task<TEntity> CompanyDependentCommercialSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _company_dependent_commercial_sync) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeActiveLangCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_active_lang_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _compute_address) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationStatisticsHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_application_statistics_hook) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_application_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1024InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_1024) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar128InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_128) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1920InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_1920) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar256InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_256) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar512InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_512) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatarInternalAsync<TEntity>(IEnumerable<TEntity> entities, object avatar_field, object image_field) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _compute_color) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialCompanyNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_commercial_company_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_commercial_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_commercial_partner) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_company_currency) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_registry) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_registry_label) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_registry_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompleteNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_complete_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeContactAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_contact_address) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeContactNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_contact_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateLastStageUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_date_last_stage_update) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateOpenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_date_open) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDayCloseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_day_close) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDayOpenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_day_open) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailDomainCriterionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_email_domain_criterion) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailFormattedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_email_formatted) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailFromInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_email_from) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_email_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmptyCompanyDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _compute_empty_company_details) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFunctionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_function) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeGetIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_get_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsAutomatedProbabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_is_automated_probability) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPartnerVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_is_partner_visible) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPublicInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_is_public) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLangActiveCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_lang_active_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLangIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_lang_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_lang) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLogoWebInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _compute_logo_web) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMainUserIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_main_user_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMeetingDisplayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_meeting_display) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeParentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _compute_parent_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerAddressValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_partner_address_values) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerEmailUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_partner_email_update) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_partner_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerPhoneUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_partner_phone_update) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerShareInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_partner_share) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_phone) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePhoneStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_phone_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePotentialLeadDuplicatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_potential_lead_duplicates) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProbabilitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_probabilities) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProratedRevenueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_prorated_revenue) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurringRevenueMonthlyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_recurring_revenue_monthly) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurringRevenueMonthlyProratedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_recurring_revenue_monthly_prorated) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurringRevenueProratedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_recurring_revenue_prorated) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSameVatPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_same_vat_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_stage_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTeamIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_team_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTypeAddressLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_type_address_label) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTzOffsetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_tz_offset) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUninstalledL10nModuleIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _compute_uninstalled_l10n_module_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserCompanyIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_user_company_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_user_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUsesDefaultLogoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _compute_uses_default_logo) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVatLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_vat_label) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_website) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWonStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_won_status) ---
            */
            return default;
        }

        public async Task<TEntity> ConvertFieldsToValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_names) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _convert_fields_to_values) ---
            */
            return default;
        }

        public async Task<TEntity> ConvertOpportunityAsync<TEntity>(IEnumerable<TEntity> entities, object partner, List<Guid> user_ids, Guid team_id) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: convert_opportunity) ---
            */
            return default;
        }

        public async Task<TEntity> ConvertOpportunityDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, Guid team_id) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _convert_opportunity_data) ---
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: copy) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: copy_data) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: create) ---
            */
            return default;
        }

        public async Task<TEntity> CreateCompanyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: create_company) ---
            */
            return default;
        }

        public async Task<TEntity> CreateContactParentCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _create_contact_parent_company) ---
            */
            return default;
        }

        public async Task<TEntity> CreateCustomerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_parent) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _create_customer) ---
            */
            return default;
        }

        public async Task<TEntity> CreationMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _creation_message) ---
            */
            return default;
        }

        public async Task<TEntity> CreationSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _creation_subtype) ---
            */
            return default;
        }

        public async Task<TEntity> CronUpdateAutomatedProbabilitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _cron_update_automated_probabilities) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _default_category) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _default_currency_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: default_get) ---
            */
            return default;
        }

        public async Task<TEntity> DisplayAddressDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _display_address_depends) ---
            */
            return default;
        }

        public async Task<TEntity> DisplayAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object without_company) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _display_address) ---
            */
            return default;
        }

        public async Task<TEntity> ExtractFieldsFromAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object address_line) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _extract_fields_from_address) ---
            */
            return default;
        }

        public async Task<object> FieldToSqlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @alias, object field_expr, object query) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _field_to_sql) ---
            */
            return default;
        }

        public async Task<TEntity> FieldsSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _fields_sync) ---
            */
            return default;
        }

        public async Task<TEntity> FindMatchingPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _find_matching_partner) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FindOrCreateAsync<TEntity>(IEnumerable<TEntity> entities, object email, object assert_valid_email) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: find_or_create) ---
            */
            return default;
        }

        public async Task<TEntity> FormatPropertiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _format_properties) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FormattingAddressFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _formatting_address_fields) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAddressFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_address_format) ---
            */
            return default;
        }

        public async Task<TEntity> GetAddressValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_address_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetAllAddrInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_all_addr) ---
            */
            return default;
        }

        public async Task<TEntity> GetCommercialValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_commercial_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompanyAddressFieldNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _get_company_address_field_names) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompanyAddressUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _get_company_address_update) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompanyRegistryLabelsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_company_registry_labels) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompanyRootDelegatedFieldNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _get_company_root_delegated_field_names) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompleteNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_complete_name) ---
            */
            return default;
        }

        public async Task<TEntity> GetCountryNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_country_name) ---
            */
            return default;
        }

        public async Task<TEntity> GetCustomerInformationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_customer_information) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultAddressFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_default_address_format) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEmptyListHelpAsync<TEntity>(IEnumerable<TEntity> entities, object help_message) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: get_empty_list_help) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: get_import_templates) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: get_import_templates) ---
            */
            return default;
        }

        public async Task<TEntity> GetLeadDuplicatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object email, object include_lost) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_lead_duplicates) ---
            */
            return default;
        }

        public async Task<TEntity> GetLogoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _get_logo) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMainCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _get_main_company) ---
            */
            return default;
        }

        public async Task<TEntity> GetOpportunityMeetingViewParametersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_opportunity_meeting_view_parameters) ---
            */
            return default;
        }

        public async Task<TEntity> GetPartnerEmailUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_void) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_partner_email_update) ---
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPhoneUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_void) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_partner_phone_update) ---
            */
            return default;
        }

        public async Task<TEntity> GetPublicUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _get_public_user) ---
            */
            return default;
        }

        public async Task<TEntity> GetRainbowmanMessageAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: get_rainbowman_message) ---
            */
            return default;
        }

        public async Task<TEntity> GetRainbowmanMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_rainbowman_message) ---
            */
            return default;
        }

        public async Task<TEntity> GetRottingDependsFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_rotting_depends_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetRottingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_rotting_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetStreetSplitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_street_split) ---
            */
            return default;
        }

        public async Task<TEntity> GetSyncedCommercialValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_synced_commercial_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewCacheKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_view_cache_key) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _get_view) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_view) ---
            */
            return default;
        }

        public async Task<TEntity> HandleFirstContactCreationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _handle_first_contact_creation) ---
            */
            return default;
        }

        public async Task<TEntity> HandlePartnerAssignmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid force_partner_id, object create_missing, object with_parent) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _handle_partner_assignment) ---
            */
            return default;
        }

        public async Task<TEntity> HandleSalesmenAssignmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> user_ids, Guid team_id) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _handle_salesmen_assignment) ---
            */
            return default;
        }

        public async Task<TEntity> HandleWonLostInternalAsync<TEntity>(IEnumerable<TEntity> entities, object old_status_by_lead, object new_status_by_lead) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _handle_won_lost) ---
            */
            return default;
        }

        public async Task<TEntity> InitAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: init) ---
            */
            return default;
        }

        public async Task<TEntity> InstallL10nModulesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: install_l10n_modules) ---
            */
            return default;
        }

        public async Task<TEntity> InverseCityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _inverse_city) ---
            */
            return default;
        }

        public async Task<TEntity> InverseColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _inverse_color) ---
            */
            return default;
        }

        public async Task<TEntity> InverseCountryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _inverse_country) ---
            */
            return default;
        }

        public async Task<TEntity> InverseEmailFromInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _inverse_email_from) ---
            */
            return default;
        }

        public async Task<TEntity> InversePhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _inverse_phone) ---
            */
            return default;
        }

        public async Task<TEntity> InverseStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _inverse_state) ---
            */
            return default;
        }

        public async Task<TEntity> InverseStreet2InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _inverse_street2) ---
            */
            return default;
        }

        public async Task<TEntity> InverseStreetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _inverse_street) ---
            */
            return default;
        }

        public async Task<TEntity> InverseZipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _inverse_zip) ---
            */
            return default;
        }

        public async Task<TEntity> IsRuleBasedAssignmentActivatedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _is_rule_based_assignment_activated) ---
            */
            return default;
        }

        public async Task<TEntity> LoadRecordsCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _load_records_create) ---
            */
            return default;
        }

        public async Task<TEntity> LogMeetingAsync<TEntity>(IEnumerable<TEntity> entities, object meeting) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: log_meeting) ---
            */
            return default;
        }

        public async Task<TEntity> MergeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fnames) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_data) ---
            */
            return default;
        }

        public async Task<TEntity> MergeDependencesAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_dependences_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> MergeDependencesCalendarEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_dependences_calendar_events) ---
            */
            return default;
        }

        public async Task<TEntity> MergeDependencesHistoryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_dependences_history) ---
            */
            return default;
        }

        public async Task<TEntity> MergeDependencesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_dependences) ---
            */
            return default;
        }

        public async Task<TEntity> MergeFollowersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_followers) ---
            #endif
            return default;
        }

        public async Task<TEntity> MergeGetFieldsAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_get_fields_address) ---
            */
            return default;
        }

        public async Task<TEntity> MergeGetFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_get_fields) ---
            */
            return default;
        }

        public async Task<TEntity> MergeGetFieldsSpecificInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_get_fields_specific) ---
            */
            return default;
        }

        public async Task<TEntity> MergeLogSummaryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object merged_followers, object opportunities_tail) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_log_summary) ---
            */
            return default;
        }

        public async Task<TEntity> MergeOpportunityAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id, Guid team_id, object auto_unlink) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: merge_opportunity) ---
            */
            return default;
        }

        public async Task<TEntity> MergeOpportunityInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id, Guid team_id, object auto_unlink, object max_length) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_opportunity) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MessageNewAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object custom_values) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: message_new) ---
            */
            return default;
        }

        public async Task<TEntity> MessagePostAfterHookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _message_post_after_hook) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NameCreateAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: name_create) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyByEmailPrepareRenderingContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals, object model_description, object force_email_company, object force_email_lang, object force_record_name) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _notify_by_email_prepare_rendering_context) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetReplyToInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @default, Guid author_id) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _notify_get_reply_to) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCommercialPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _onchange_commercial_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _onchange_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: onchange_company_type) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCountryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _onchange_country_id) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _onchange_country_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeParentIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: onchange_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _onchange_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePhoneValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _onchange_phone_validation) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _onchange_state) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _onchange_state) ---
            */
            return default;
        }

        public async Task<TEntity> OpenCommercialEntityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: open_commercial_entity) ---
            */
            return default;
        }

        public async Task<TEntity> PlsGetLeadPlsValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_get_lead_pls_values) ---
            */
            return default;
        }

        public async Task<TEntity> PlsGetNaiveBayesProbabilitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object batch_mode, object is_tooltip) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_get_naive_bayes_probabilities) ---
            */
            return default;
        }

        public async Task<TEntity> PlsGetSafeFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_get_safe_fields) ---
            */
            return default;
        }

        public async Task<TEntity> PlsGetSafeStartDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_get_safe_start_date) ---
            */
            return default;
        }

        public async Task<TEntity> PlsGetWonLostTotalCountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object team_results) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_get_won_lost_total_count) ---
            */
            return default;
        }

        public async Task<TEntity> PlsIncrementFrequenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object from_state, object to_state) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_increment_frequencies) ---
            */
            return default;
        }

        public async Task<TEntity> PlsIncrementFrequencyDictInternalAsync<TEntity>(IEnumerable<TEntity> entities, object frequencies, object field, object @value, object won, object lost) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_increment_frequency_dict) ---
            */
            return default;
        }

        public async Task<TEntity> PlsPrepareFrequenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object lead_values, object leads_pls_fields, object target_state) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_prepare_frequencies) ---
            */
            return default;
        }

        public async Task<TEntity> PlsPrepareUpdateFrequencyTableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object rebuild, object target_state) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_prepare_update_frequency_table) ---
            */
            return default;
        }

        public async Task<TEntity> PlsUpdateFrequencyTableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_frequencies_by_team, object step, object existing_frequencies_by_team) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_update_frequency_table) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareAddressValuesFromPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _prepare_address_values_from_partner) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareContactNameFromPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _prepare_contact_name_from_partner) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareCustomerValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner_name, object is_company, Guid parent_id) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _prepare_customer_values) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareDisplayAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object without_company) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _prepare_display_address) ---
            */
            return default;
        }

        public async Task<TEntity> PreparePartnerNameFromPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _prepare_partner_name_from_partner) ---
            */
            return default;
        }

        public async Task<TEntity> PreparePlsTooltipDataAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: prepare_pls_tooltip_data) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareValuesFromPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _prepare_values_from_partner) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ReadGroupStageIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stages, object domain) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _read_group_stage_ids) ---
            */
            return default;
        }

        public async Task<TEntity> RebuildPlsFrequencyTableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _rebuild_pls_frequency_table) ---
            */
            return default;
        }

        public async Task<TEntity> RedirectLeadOpportunityViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: redirect_lead_opportunity_view) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _search_display_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchFetchAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object field_names, object offset, object limit, object order) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: search_fetch) ---
            */
            return default;
        }

        public async Task<TEntity> SortByConfidenceLevelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reverse) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _sort_by_confidence_level) ---
            */
            return default;
        }

        public async Task<TEntity> StageFindInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid team_id, object domain, object order, object limit) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _stage_find) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SyncedCommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _synced_commercial_fields) ---
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _unlink_except_user) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _update_address) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateAutomatedProbabilitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _update_automated_probabilities) ---
            */
            return default;
        }

        public async Task<TEntity> ViewGetAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object arch) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _view_get_address) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ViewHeaderGetAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: view_header_get) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: write) ---
            */
            return default;
        }

        public async Task<TEntity> WriteCompanyTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _write_company_type) ---
            */
            return default;
        }

        public async Task<TEntity> _AccessibleBranchesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: __accessible_branches) ---
            */
            return default;
        }
    }
}