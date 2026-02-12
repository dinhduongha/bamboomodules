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
    public partial class AvatarMixinAppService : ApplicationService, IAvatarMixinAppService
    {

        public AvatarMixinAppService() 
        {

        }

        public async Task<TEntity> ActShowLogCostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: act_show_log_cost) ---
            */
            return default;
        }

        public async Task<TEntity> ActionAcceptDriverChangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: action_accept_driver_change) ---
            */
            return default;
        }

        public async Task<TEntity> ActionArchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_archive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateUserAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_create_user) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateUsersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_create_users) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateUsersConfirmationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_create_users_confirmation) ---
            */
            return default;
        }

        public async Task<TEntity> ActionModelVehicleAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py, METHOD: action_model_vehicle) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenAllocationWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_open_allocation_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenOdometerReportAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: action_open_odometer_report) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenVersionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_open_versions) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRelatedContactsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_related_contacts) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendEmailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: action_send_email) ---
            */
            return default;
        }

        public async Task<TEntity> ActionTogglePrimaryBankAccountTrustAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_toggle_primary_bank_account_trust) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnarchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_unarchive) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AddressFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _address_fields) ---
            */
            return default;
        }

        public async Task<TEntity> AddressGetAsync<TEntity>(IEnumerable<TEntity> entities, object adr_pref) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: address_get) ---
            */
            return default;
        }

        public async Task<TEntity> AvatarGenerateSvgInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py, METHOD: _avatar_generate_svg) ---
            */
            return default;
        }

        public async Task<TEntity> AvatarGetPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py, METHOD: _avatar_get_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> AvatarGetPlaceholderPathInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py, METHOD: _avatar_get_placeholder_path) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _avatar_get_placeholder_path) ---
            */
            return default;
        }

        public async Task<TEntity> CheckAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object operation) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _check_access) ---
            */
            return default;
        }

        public async Task<TEntity> CheckBarcodeUnicityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_barcode_unicity) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckFieldAccessRightsAsync<TEntity>(IEnumerable<TEntity> entities, object operation, object field_names) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: check_field_access_rights) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckImportConsistencyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_import_consistency) ---
            */
            return default;
        }

        public async Task<TEntity> CheckNoExistingContractAsync<TEntity>(IEnumerable<TEntity> entities, object date) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: check_no_existing_contract) ---
            */
            return default;
        }

        public async Task<TEntity> CheckParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPartnerCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_partner_company) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPrivateFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_names) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _check_private_fields) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSalaryDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _check_salary_distribution) ---
            */
            return default;
        }

        public async Task<TEntity> ChildrenSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _children_sync) ---
            */
            return default;
        }

        public async Task<TEntity> CleanWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _clean_website) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _commercial_fields) ---
            */
            return default;
        }

        public async Task<TEntity> CommercialSyncFromCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _commercial_sync_from_company) ---
            */
            return default;
        }

        public async Task<TEntity> CommercialSyncToDescendantsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields_to_sync) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _commercial_sync_to_descendants) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CompanyDependentCommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _company_dependent_commercial_fields) ---
            */
            return default;
        }

        public async Task<TEntity> CompanyDependentCommercialSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _company_dependent_commercial_sync) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeActiveLangCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_active_lang_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationStatisticsHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_application_statistics_hook) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_application_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1024InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_avatar_1024) ---
            --- METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py, METHOD: _compute_avatar_1024) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_1024) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar128InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_avatar_128) ---
            --- METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py, METHOD: _compute_avatar_128) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_128) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1920InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_avatar_1920) ---
            --- METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py, METHOD: _compute_avatar_1920) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_1920) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar256InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_avatar_256) ---
            --- METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py, METHOD: _compute_avatar_256) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_256) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar512InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_avatar_512) ---
            --- METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py, METHOD: _compute_avatar_512) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_512) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatarInternalAsync<TEntity>(IEnumerable<TEntity> entities, object avatar_field, object image_field) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_avatar) ---
            --- METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py, METHOD: _compute_avatar) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBirthdayPublicDisplayStringInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_birthday_public_display_string) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_category) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCo2EmissionUnitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_co2_emission_unit) ---
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py, METHOD: _compute_co2_emission_unit) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCo2InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_co2) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCo2StandardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_co2_standard) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCoachInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_coach) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_color) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialCompanyNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_commercial_company_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_commercial_partner) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_registry) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_registry_label) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_registry_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompleteNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_complete_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeContactAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_contact_address) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeContractReminderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_contract_reminder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCountAllInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_count_all) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrentVersionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_current_version_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDoorsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_doors) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeElectricAssistanceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_electric_assistance) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailFormattedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_email_formatted) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFuelTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_fuel_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeGetIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_get_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasMultipleBankAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_has_multiple_bank_accounts) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHorsepowerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_horsepower) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHorsepowerTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_horsepower_tax) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeImStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_guest.py, METHOD: _compute_im_status) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPublicInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_is_public) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsTrustedBankAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_is_trusted_bank_account) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_lang) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLastActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_last_activity) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLegalNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_legal_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMainUserIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_main_user_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeModelYearInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_model_year) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNewlyHiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_newly_hired) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerShareInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_partner_share) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePowerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_power) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePresenceIconInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_presence_icon) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePresenceStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_presence_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePrimaryBankAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_primary_bank_account_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRangeUnitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_range_unit) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRelatedPartnersCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_related_partners_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSameVatPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_same_vat_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSeatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_seats) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeServiceActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_service_activity) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTrailerHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_trailer_hook) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTransmissionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_transmission) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTypeAddressLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_type_address_label) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTzOffsetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_tz_offset) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_user_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVatLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_vat_label) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVehicleCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py, METHOD: _compute_vehicle_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVehicleNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_vehicle_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVehicleRangeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_vehicle_range) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVersionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_version_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVersionsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_versions_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkContactDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_work_contact_details) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkLocationNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_work_location_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkLocationTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_work_location_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkPermitNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_work_permit_name) ---
            */
            return default;
        }

        public async Task<TEntity> ConvertFieldsToValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_names) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _convert_fields_to_values) ---
            */
            return default;
        }

        public async Task<TEntity> CopyCacheFromInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @public, object field_names) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _copy_cache_from) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: copy_data) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: create) ---
            */
            return default;
        }

        public async Task<TEntity> CreateCompanyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: create_company) ---
            */
            return default;
        }

        public async Task<TEntity> CreateContactParentCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _create_contact_parent_company) ---
            */
            return default;
        }

        public async Task<TEntity> CreateContractAsync<TEntity>(IEnumerable<TEntity> entities, object date) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: create_contract) ---
            */
            return default;
        }

        public async Task<TEntity> CreateDriverHistoryAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: create_driver_history) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data_list) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _create) ---
            */
            return default;
        }

        public async Task<TEntity> CreateVersionAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: create_version) ---
            */
            return default;
        }

        public async Task<TEntity> CreateWorkContactsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _create_work_contacts) ---
            */
            return default;
        }

        public async Task<TEntity> CronUpdateCurrentVersionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _cron_update_current_version_id) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _default_category) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: default_get) ---
            */
            return default;
        }

        public async Task<TEntity> DisplayAddressDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _display_address_depends) ---
            */
            return default;
        }

        public async Task<TEntity> DisplayAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object without_company) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _display_address) ---
            */
            return default;
        }

        public async Task<TEntity> EmployeeAttendanceIntervalsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object stop, object lunch) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _employee_attendance_intervals) ---
            */
            return default;
        }

        public async Task<TEntity> FetchAsync<TEntity>(IEnumerable<TEntity> entities, object field_names) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: fetch) ---
            */
            return default;
        }

        public async Task<TEntity> FieldStoreReprInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_guest.py, METHOD: _field_store_repr) ---
            */
            return default;
        }

        public async Task<object> FieldToSqlInternalAsync<TEntity>(IEnumerable<TEntity> entities, string @alias, string field_expr, object query) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _field_to_sql) ---
            */
            return default;
        }

        public async Task<TEntity> FieldsSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _fields_sync) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FindOrCreateAsync<TEntity>(IEnumerable<TEntity> entities, object email, object assert_valid_email) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: find_or_create) ---
            */
            return default;
        }

        public async Task<TEntity> FormatAuthCookieInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_guest.py, METHOD: _format_auth_cookie) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FormattingAddressFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _formatting_address_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateRandomBarcodeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: generate_random_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccountsWithFixedAllocationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_accounts_with_fixed_allocations) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAddressFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_address_format) ---
            */
            return default;
        }

        public async Task<TEntity> GetAddressValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_address_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetAgeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_date) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_age) ---
            */
            return default;
        }

        public async Task<TEntity> GetAllAddrInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_all_addr) ---
            */
            return default;
        }

        public async Task<TEntity> GetAllContractDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_all_contract_dates) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAllVersionsWithContractOverlapWithPeriodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_all_versions_with_contract_overlap_with_period) ---
            */
            return default;
        }

        public async Task<TEntity> GetAnalyticNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _get_analytic_name) ---
            */
            return default;
        }

        public async Task<TEntity> GetAvatar128AccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py, METHOD: _get_avatar_128_access_token) ---
            */
            return default;
        }

        public async Task<TEntity> GetAvatarCardDataAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_avatar_card_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetBankAccountSalaryAllocationAsync<TEntity>(IEnumerable<TEntity> entities, Guid account_id) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_bank_account_salary_allocation) ---
            */
            return default;
        }

        public async Task<TEntity> GetCalendarAttendancesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_calendar_attendances) ---
            */
            return default;
        }

        public async Task<TEntity> GetCalendarPeriodsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object stop, object check_contract) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_calendar_periods) ---
            */
            return default;
        }

        public async Task<TEntity> GetCalendarTzBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object dt) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_calendar_tz_batch) ---
            */
            return default;
        }

        public async Task<TEntity> GetCalendarsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_calendars) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetCertificateSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_certificate_selection) ---
            */
            return default;
        }

        public async Task<TEntity> GetCommercialValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_commercial_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompanyRegistryLabelsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_company_registry_labels) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompleteNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_complete_name) ---
            */
            return default;
        }

        public async Task<TEntity> GetContractDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_contract_dates) ---
            */
            return default;
        }

        public async Task<TEntity> GetContractVersionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_start, object date_end, object domain) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_contract_versions) ---
            */
            return default;
        }

        public async Task<TEntity> GetContractsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_start, object date_end, object use_latest_version, object domain) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_contracts) ---
            */
            return default;
        }

        public async Task<TEntity> GetCountryNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_country_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultAddressFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_default_address_format) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _get_default_state) ---
            */
            return default;
        }

        public async Task<TEntity> GetDepartureDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_departure_date) ---
            */
            return default;
        }

        public async Task<TEntity> GetDriverHistoryDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _get_driver_history_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetEmployeeM2oToEmptyOnArchivedEmployeesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_employee_m2o_to_empty_on_archived_employees) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEmployeeWorkingNowInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_employee_working_now) ---
            */
            return default;
        }

        public async Task<TEntity> GetExpectedAttendancesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_expected_attendances) ---
            */
            return default;
        }

        public async Task<TEntity> GetFirstVersionDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object no_gap) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_first_version_date) ---
            */
            return default;
        }

        public async Task<TEntity> GetFirstVersionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_first_versions) ---
            */
            return default;
        }

        public async Task<TEntity> GetFormviewActionAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_formview_action) ---
            */
            return default;
        }

        public async Task<TEntity> GetFormviewIdAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_formview_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetGuestFromContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_guest.py, METHOD: _get_guest_from_context) ---
            */
            return default;
        }

        public async Task<TEntity> GetGuestFromTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object token) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_guest.py, METHOD: _get_guest_from_token) ---
            */
            return default;
        }

        public async Task<TEntity> GetImStatusAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_guest.py, METHOD: _get_im_status_access_token) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_import_templates) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: get_import_templates) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetNewHireFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_new_hire_field) ---
            */
            return default;
        }

        public async Task<TEntity> GetOdometerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _get_odometer) ---
            */
            return default;
        }

        public async Task<TEntity> GetOrCreateGuestInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_guest.py, METHOD: _get_or_create_guest) ---
            */
            return default;
        }

        public async Task<TEntity> GetPartnerCountDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_partner_count_depends) ---
            */
            return default;
        }

        public async Task<TEntity> GetRelatedPartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_related_partners) ---
            */
            return default;
        }

        public async Task<TEntity> GetRemainingPercentageAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_remaining_percentage) ---
            */
            return default;
        }

        public async Task<TEntity> GetStoreAvatarCardFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_store_avatar_card_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetStreetSplitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_street_split) ---
            */
            return default;
        }

        public async Task<TEntity> GetSyncedCommercialValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_synced_commercial_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetTimezoneFromRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_guest.py, METHOD: _get_timezone_from_request) ---
            */
            return default;
        }

        public async Task<TEntity> GetTzBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_tz_batch) ---
            */
            return default;
        }

        public async Task<TEntity> GetTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_tz) ---
            */
            return default;
        }

        public async Task<TEntity> GetUnusualDaysInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_unusual_days) ---
            */
            return default;
        }

        public async Task<TEntity> GetUserM2oToEmptyOnArchivedEmployeesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_user_m2o_to_empty_on_archived_employees) ---
            */
            return default;
        }

        public async Task<TEntity> GetVersionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_version) ---
            */
            return default;
        }

        public async Task<TEntity> GetVersionPeriodsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object stop, object field, object check_contract) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_version_periods) ---
            */
            return default;
        }

        public async Task<TEntity> GetVersionsWithContractOverlapWithPeriodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_versions_with_contract_overlap_with_period) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_view) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewsAsync<TEntity>(IEnumerable<TEntity> entities, object views, object options) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_views) ---
            */
            return default;
        }

        public async Task<TEntity> GetYearSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _get_year_selection) ---
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py, METHOD: _get_year_selection) ---
            */
            return default;
        }

        public async Task<TEntity> HandleFirstContactCreationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _handle_first_contact_creation) ---
            */
            return default;
        }

        public async Task<TEntity> HasFieldAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, object operation) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _has_field_access) ---
            */
            return default;
        }

        public async Task<TEntity> InverseWorkContactDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _inverse_work_contact_details) ---
            */
            return default;
        }

        public async Task<TEntity> IsInContractInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _is_in_contract) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LangGetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _lang_get) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_guest.py, METHOD: _lang_get) ---
            */
            return default;
        }

        public async Task<TEntity> LoadDemoDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _load_demo_data) ---
            */
            return default;
        }

        public async Task<TEntity> LoadFieldsFromModelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields_to_load) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _load_fields_from_model) ---
            */
            return default;
        }

        public async Task<TEntity> LoadRecordsCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _load_records_create) ---
            */
            return default;
        }

        public async Task<TEntity> LoadScenarioInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _load_scenario) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnerFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _mail_get_partner_fields) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NameCreateAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: name_create) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NewAsync<TEntity>(IEnumerable<TEntity> entities, object values, object origin, object @ref) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: new) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NotifyExpiringContractWorkPermitAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: notify_expiring_contract_work_permit) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_company_id) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _onchange_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: onchange_company_type) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeContractDateStartInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_contract_date_start) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeContractTemplateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_contract_template_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCountryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _onchange_country_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeParentIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: onchange_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePhoneValidationEmployeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_phone_validation_employee) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePrivateStateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_private_state_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _onchange_state) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTimezoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_timezone) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_user) ---
            */
            return default;
        }

        public async Task<TEntity> OpenAssignationLogsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: open_assignation_logs) ---
            */
            return default;
        }

        public async Task<TEntity> OpenCommercialEntityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: open_commercial_entity) ---
            */
            return default;
        }

        public async Task<TEntity> PhoneGetNumberFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _phone_get_number_fields) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareCreateValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _prepare_create_values) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareDisplayAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object without_company) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _prepare_display_address) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareResourceValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object tz) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _prepare_resource_values) ---
            */
            return default;
        }

        public async Task<TEntity> RemoveWorkContactIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user, object employee_company) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _remove_work_contact_id) ---
            */
            return default;
        }

        public async Task<TEntity> ReturnActionToOpenAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: return_action_to_open) ---
            */
            return default;
        }

        public async Task<TEntity> SearchContractRenewalDueSoonInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _search_contract_renewal_due_soon) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py, METHOD: _search_display_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchFetchAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object field_names, object offset, object limit, object order) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: search_fetch) ---
            */
            return default;
        }

        public async Task<TEntity> SearchGetOverdueContractReminderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _search_get_overdue_contract_reminder) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object offset, object limit, object order) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _search) ---
            */
            return default;
        }

        public async Task<TEntity> SearchNewlyHiredInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _search_newly_hired) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchVehicleCountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py, METHOD: _search_vehicle_count) ---
            */
            return default;
        }

        public async Task<TEntity> SearchVersionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _search_version_id) ---
            */
            return default;
        }

        public async Task<TEntity> SetAuthCookieInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_guest.py, METHOD: _set_auth_cookie) ---
            */
            return default;
        }

        public async Task<TEntity> SetOdometerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _set_odometer) ---
            */
            return default;
        }

        public async Task<TEntity> SyncSalaryDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _sync_salary_distribution) ---
            */
            return default;
        }

        public async Task<TEntity> SyncUserInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user, object employee_has_image) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _sync_user) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SyncedCommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _synced_commercial_fields) ---
            */
            return default;
        }

        public async Task<TEntity> ToStoreDefaultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_guest.py, METHOD: _to_store_defaults) ---
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _unlink_except_user) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _update_address) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_guest.py, METHOD: _update_name) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateTimezoneInternalAsync<TEntity>(IEnumerable<TEntity> entities, object timezone) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_guest.py, METHOD: _update_timezone) ---
            */
            return default;
        }

        public async Task<TEntity> VerifyBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _verify_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> VerifyPinInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _verify_pin) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ViewHeaderGetAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: view_header_get) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: write) ---
            */
            return default;
        }

        public async Task<TEntity> WriteCompanyTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _write_company_type) ---
            */
            return default;
        }
    }
}