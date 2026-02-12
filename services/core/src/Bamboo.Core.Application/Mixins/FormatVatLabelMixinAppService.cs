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
    public partial class FormatVatLabelMixinAppService : ApplicationService, IFormatVatLabelMixinAppService
    {

        public FormatVatLabelMixinAppService() 
        {

        }

        public async Task<TEntity> AccessibleBranchesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _accessible_branches) ---
            */
            return default;
        }

        public async Task<TEntity> ActionAllCompanyBranchesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: action_all_company_branches) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AddressFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _address_fields) ---
            */
            return default;
        }

        public async Task<TEntity> AddressGetAsync<TEntity>(IEnumerable<TEntity> entities, object adr_pref) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: address_get) ---
            */
            return default;
        }

        public async Task<TEntity> AllBranchesSelectedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _all_branches_selected) ---
            */
            return default;
        }

        public async Task<TEntity> AvatarGetPlaceholderPathInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _avatar_get_placeholder_path) ---
            */
            return default;
        }

        public async Task<TEntity> CacheInvalidationFieldsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: cache_invalidation_fields) ---
            */
            return default;
        }

        public async Task<TEntity> CheckActiveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _check_active) ---
            */
            return default;
        }

        public async Task<TEntity> CheckBarcodeUnicityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_barcode_unicity) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckImportConsistencyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_import_consistency) ---
            */
            return default;
        }

        public async Task<TEntity> CheckParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPartnerCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_partner_company) ---
            */
            return default;
        }

        public async Task<TEntity> CheckRootDelegatedFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _check_root_delegated_fields) ---
            */
            return default;
        }

        public async Task<TEntity> ChildrenSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _children_sync) ---
            */
            return default;
        }

        public async Task<TEntity> CleanWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _clean_website) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _commercial_fields) ---
            */
            return default;
        }

        public async Task<TEntity> CommercialSyncFromCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _commercial_sync_from_company) ---
            */
            return default;
        }

        public async Task<TEntity> CommercialSyncToDescendantsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields_to_sync) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _commercial_sync_to_descendants) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CompanyDependentCommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _company_dependent_commercial_fields) ---
            */
            return default;
        }

        public async Task<TEntity> CompanyDependentCommercialSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _company_dependent_commercial_sync) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeActiveLangCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_active_lang_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _compute_address) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationStatisticsHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_application_statistics_hook) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_application_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1024InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_1024) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar128InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_128) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1920InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_1920) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar256InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_256) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar512InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_512) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatarInternalAsync<TEntity>(IEnumerable<TEntity> entities, object avatar_field, object image_field) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _compute_color) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialCompanyNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_commercial_company_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_commercial_partner) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_registry) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_registry_label) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_registry_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompleteNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_complete_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeContactAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_contact_address) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailFormattedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_email_formatted) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmptyCompanyDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _compute_empty_company_details) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeGetIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_get_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPublicInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_is_public) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_lang) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLogoWebInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _compute_logo_web) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMainUserIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_main_user_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeParentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _compute_parent_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerShareInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_partner_share) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSameVatPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_same_vat_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTypeAddressLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_type_address_label) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTzOffsetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_tz_offset) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUninstalledL10nModuleIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _compute_uninstalled_l10n_module_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_user_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUsesDefaultLogoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _compute_uses_default_logo) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVatLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_vat_label) ---
            */
            return default;
        }

        public async Task<TEntity> ConvertFieldsToValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_names) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _convert_fields_to_values) ---
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: copy) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: copy_data) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: create) ---
            */
            return default;
        }

        public async Task<TEntity> CreateCompanyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: create_company) ---
            */
            return default;
        }

        public async Task<TEntity> CreateContactParentCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _create_contact_parent_company) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _default_category) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _default_currency_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: default_get) ---
            */
            return default;
        }

        public async Task<TEntity> DisplayAddressDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _display_address_depends) ---
            */
            return default;
        }

        public async Task<TEntity> DisplayAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object without_company) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _display_address) ---
            */
            return default;
        }

        public async Task<TEntity> FieldsSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _fields_sync) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FindOrCreateAsync<TEntity>(IEnumerable<TEntity> entities, object email, object assert_valid_email) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: find_or_create) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FormattingAddressFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _formatting_address_fields) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAddressFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_address_format) ---
            */
            return default;
        }

        public async Task<TEntity> GetAddressValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_address_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetAllAddrInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_all_addr) ---
            */
            return default;
        }

        public async Task<TEntity> GetCommercialValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_commercial_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompanyAddressFieldNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _get_company_address_field_names) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompanyAddressUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _get_company_address_update) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompanyRegistryLabelsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_company_registry_labels) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompanyRootDelegatedFieldNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _get_company_root_delegated_field_names) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompleteNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_complete_name) ---
            */
            return default;
        }

        public async Task<TEntity> GetCountryNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_country_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultAddressFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_default_address_format) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: get_import_templates) ---
            */
            return default;
        }

        public async Task<TEntity> GetLogoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _get_logo) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMainCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _get_main_company) ---
            */
            return default;
        }

        public async Task<TEntity> GetPublicUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _get_public_user) ---
            */
            return default;
        }

        public async Task<TEntity> GetStreetSplitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_street_split) ---
            */
            return default;
        }

        public async Task<TEntity> GetSyncedCommercialValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_synced_commercial_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _get_view) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_view) ---
            */
            return default;
        }

        public async Task<TEntity> HandleFirstContactCreationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _handle_first_contact_creation) ---
            */
            return default;
        }

        public async Task<TEntity> InitAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: init) ---
            */
            return default;
        }

        public async Task<TEntity> InstallL10nModulesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: install_l10n_modules) ---
            */
            return default;
        }

        public async Task<TEntity> InverseCityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _inverse_city) ---
            */
            return default;
        }

        public async Task<TEntity> InverseColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _inverse_color) ---
            */
            return default;
        }

        public async Task<TEntity> InverseCountryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _inverse_country) ---
            */
            return default;
        }

        public async Task<TEntity> InverseStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _inverse_state) ---
            */
            return default;
        }

        public async Task<TEntity> InverseStreet2InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _inverse_street2) ---
            */
            return default;
        }

        public async Task<TEntity> InverseStreetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _inverse_street) ---
            */
            return default;
        }

        public async Task<TEntity> InverseZipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _inverse_zip) ---
            */
            return default;
        }

        public async Task<TEntity> LoadRecordsCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _load_records_create) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NameCreateAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: name_create) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _onchange_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: onchange_company_type) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCountryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _onchange_country_id) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _onchange_country_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeParentIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: onchange_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _onchange_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _onchange_state) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _onchange_state) ---
            */
            return default;
        }

        public async Task<TEntity> OpenCommercialEntityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: open_commercial_entity) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareDisplayAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object without_company) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _prepare_display_address) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _search_display_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SyncedCommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _synced_commercial_fields) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _unlink_except_user) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _update_address) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ViewHeaderGetAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: view_header_get) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: write) ---
            */
            return default;
        }

        public async Task<TEntity> WriteCompanyTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _write_company_type) ---
            */
            return default;
        }

        public async Task<TEntity> _AccessibleBranchesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: __accessible_branches) ---
            */
            return default;
        }
    }
}