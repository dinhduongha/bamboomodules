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
    [Module("resource", Category = "Misc", Depends = new[] { "base", "web" })]
    public partial class ResourceMixinAppService : ApplicationService, IResourceMixinAppService
    {

        public ResourceMixinAppService() 
        {

        }

        public async Task<TEntity> ActionArchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_archive) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: action_archive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateUserAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_create_user) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateUsersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_create_users) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateUsersConfirmationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_create_users_confirmation) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenAllocationWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_open_allocation_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenVersionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_open_versions) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRelatedContactsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_related_contacts) ---
            */
            return default;
        }

        public async Task<TEntity> ActionShowOperationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: action_show_operations) ---
            */
            return default;
        }

        public async Task<TEntity> ActionTogglePrimaryBankAccountTrustAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_toggle_primary_bank_account_trust) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnarchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_unarchive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionWorkOrderAlternativesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: action_work_order_alternatives) ---
            */
            return default;
        }

        public async Task<TEntity> ActionWorkOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: action_work_order) ---
            */
            return default;
        }

        public async Task<TEntity> AdjustToCalendarInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object end) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_mixin.py, METHOD: _adjust_to_calendar) ---
            */
            return default;
        }

        public async Task<TEntity> CheckAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object operation) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _check_access) ---
            */
            return default;
        }

        public async Task<TEntity> CheckAlternativeWorkcenterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _check_alternative_workcenter) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckFieldAccessRightsAsync<TEntity>(IEnumerable<TEntity> entities, object operation, object field_names) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: check_field_access_rights) ---
            */
            return default;
        }

        public async Task<TEntity> CheckNoExistingContractAsync<TEntity>(IEnumerable<TEntity> entities, object date) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: check_no_existing_contract) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPrivateFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_names) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _check_private_fields) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSalaryDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _check_salary_distribution) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1024InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_avatar_1024) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar128InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_avatar_128) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1920InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_avatar_1920) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar256InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_avatar_256) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar512InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_avatar_512) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatarInternalAsync<TEntity>(IEnumerable<TEntity> entities, object avatar_field, object image_field) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_avatar) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBirthdayPublicDisplayStringInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_birthday_public_display_string) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBlockedTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_blocked_time) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCoachInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_coach) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrentVersionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_current_version_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasMultipleBankAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_has_multiple_bank_accounts) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasRoutingLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_has_routing_lines) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsTrustedBankAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_is_trusted_bank_account) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeKanbanDashboardGraphInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_kanban_dashboard_graph) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLastActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_last_activity) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLegalNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_legal_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNewlyHiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_newly_hired) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_oee) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePerformanceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_performance) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePresenceIconInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_presence_icon) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePresenceStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_presence_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePrimaryBankAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_primary_bank_account_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductiveTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_productive_time) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRelatedPartnersCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_related_partners_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVersionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_version_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVersionsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_versions_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkContactDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_work_contact_details) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkLocationNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_work_location_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkLocationTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_work_location_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkPermitNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_work_permit_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkingStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_working_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkorderCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_workorder_count) ---
            */
            return default;
        }

        public async Task<TEntity> CopyCacheFromInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @public, object field_names) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _copy_cache_from) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_mixin.py, METHOD: copy_data) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: resource, FILE: resource_mixin.py, METHOD: create) ---
            */
            return default;
        }

        public async Task<TEntity> CreateContractAsync<TEntity>(IEnumerable<TEntity> entities, object date) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: create_contract) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data_list) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _create) ---
            */
            return default;
        }

        public async Task<TEntity> CreateVersionAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: create_version) ---
            */
            return default;
        }

        public async Task<TEntity> CreateWorkContactsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _create_work_contacts) ---
            */
            return default;
        }

        public async Task<TEntity> CronUpdateCurrentVersionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _cron_update_current_version_id) ---
            */
            return default;
        }

        public async Task<TEntity> EmployeeAttendanceIntervalsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object stop, object lunch) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _employee_attendance_intervals) ---
            */
            return default;
        }

        public async Task<TEntity> FetchAsync<TEntity>(IEnumerable<TEntity> entities, object field_names) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: fetch) ---
            */
            return default;
        }

        public async Task<object> FieldToSqlInternalAsync<TEntity>(IEnumerable<TEntity> entities, string @alias, string field_expr, object query) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _field_to_sql) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateRandomBarcodeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: generate_random_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccountsWithFixedAllocationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_accounts_with_fixed_allocations) ---
            */
            return default;
        }

        public async Task<TEntity> GetAgeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_date) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_age) ---
            */
            return default;
        }

        public async Task<TEntity> GetAllContractDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_all_contract_dates) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAllVersionsWithContractOverlapWithPeriodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_all_versions_with_contract_overlap_with_period) ---
            */
            return default;
        }

        public async Task<TEntity> GetAvatarCardDataAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_avatar_card_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetBankAccountSalaryAllocationAsync<TEntity>(IEnumerable<TEntity> entities, Guid account_id) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_bank_account_salary_allocation) ---
            */
            return default;
        }

        public async Task<TEntity> GetCalendarAttendancesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_calendar_attendances) ---
            */
            return default;
        }

        public async Task<TEntity> GetCalendarPeriodsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object stop, object check_contract) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_calendar_periods) ---
            */
            return default;
        }

        public async Task<TEntity> GetCalendarTzBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object dt) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_calendar_tz_batch) ---
            */
            return default;
        }

        public async Task<TEntity> GetCalendarsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_calendars) ---
            --- METHOD SOURCE (MODULE: resource, FILE: resource_mixin.py, METHOD: _get_calendars) ---
            */
            return default;
        }

        public async Task<TEntity> GetCapacityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product, object unit, object default_capacity) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _get_capacity) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetCertificateSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_certificate_selection) ---
            */
            return default;
        }

        public async Task<TEntity> GetContractDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_contract_dates) ---
            */
            return default;
        }

        public async Task<TEntity> GetContractVersionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_start, object date_end, object domain) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_contract_versions) ---
            */
            return default;
        }

        public async Task<TEntity> GetContractsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_start, object date_end, object use_latest_version, object domain) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_contracts) ---
            */
            return default;
        }

        public async Task<TEntity> GetDepartureDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_departure_date) ---
            */
            return default;
        }

        public async Task<TEntity> GetEmployeeM2oToEmptyOnArchivedEmployeesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_employee_m2o_to_empty_on_archived_employees) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEmployeeWorkingNowInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_employee_working_now) ---
            */
            return default;
        }

        public async Task<TEntity> GetExpectedAttendancesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_expected_attendances) ---
            */
            return default;
        }

        public async Task<TEntity> GetFirstAvailableSlotInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_datetime, object duration, object forward, object leaves_to_ignore, object extra_leaves_slots) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _get_first_available_slot) ---
            */
            return default;
        }

        public async Task<TEntity> GetFirstVersionDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object no_gap) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_first_version_date) ---
            */
            return default;
        }

        public async Task<TEntity> GetFirstVersionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_first_versions) ---
            */
            return default;
        }

        public async Task<TEntity> GetFormviewActionAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_formview_action) ---
            */
            return default;
        }

        public async Task<TEntity> GetFormviewIdAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_formview_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_import_templates) ---
            */
            return default;
        }

        public async Task<TEntity> GetLeaveDaysDataBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object from_datetime, object to_datetime, object calendar, object domain) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_mixin.py, METHOD: _get_leave_days_data_batch) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetNewHireFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_new_hire_field) ---
            */
            return default;
        }

        public async Task<TEntity> GetPartnerCountDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_partner_count_depends) ---
            */
            return default;
        }

        public async Task<TEntity> GetRelatedPartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_related_partners) ---
            */
            return default;
        }

        public async Task<TEntity> GetRemainingPercentageAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_remaining_percentage) ---
            */
            return default;
        }

        public async Task<TEntity> GetStoreAvatarCardFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_store_avatar_card_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetTzBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_tz_batch) ---
            */
            return default;
        }

        public async Task<TEntity> GetTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_tz) ---
            */
            return default;
        }

        public async Task<TEntity> GetUnavailabilityIntervalsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_datetime, object end_datetime) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _get_unavailability_intervals) ---
            */
            return default;
        }

        public async Task<TEntity> GetUnusualDaysInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_unusual_days) ---
            */
            return default;
        }

        public async Task<TEntity> GetUserM2oToEmptyOnArchivedEmployeesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_user_m2o_to_empty_on_archived_employees) ---
            */
            return default;
        }

        public async Task<TEntity> GetVersionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_version) ---
            */
            return default;
        }

        public async Task<TEntity> GetVersionPeriodsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object stop, object field, object check_contract) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_version_periods) ---
            */
            return default;
        }

        public async Task<TEntity> GetVersionsWithContractOverlapWithPeriodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_versions_with_contract_overlap_with_period) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_view) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewsAsync<TEntity>(IEnumerable<TEntity> entities, object views, object options) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_views) ---
            */
            return default;
        }

        public async Task<TEntity> GetWeekRangeAndFirstLastDaysInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _get_week_range_and_first_last_days) ---
            */
            return default;
        }

        public async Task<TEntity> GetWorkDaysDataBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object from_datetime, object to_datetime, object compute_leaves, object calendar, object domain) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_mixin.py, METHOD: _get_work_days_data_batch) ---
            */
            return default;
        }

        public async Task<TEntity> GetWorkcenterLoadPerWeekInternalAsync<TEntity>(IEnumerable<TEntity> entities, object week_range, object date_start, object date_stop) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _get_workcenter_load_per_week) ---
            */
            return default;
        }

        public async Task<TEntity> HasFieldAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, object operation) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _has_field_access) ---
            */
            return default;
        }

        public async Task<TEntity> InverseWorkContactDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _inverse_work_contact_details) ---
            */
            return default;
        }

        public async Task<TEntity> IsInContractInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _is_in_contract) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LangGetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _lang_get) ---
            */
            return default;
        }

        public async Task<TEntity> ListLeavesAsync<TEntity>(IEnumerable<TEntity> entities, object from_datetime, object to_datetime, object calendar, object domain) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_mixin.py, METHOD: list_leaves) ---
            */
            return default;
        }

        public async Task<TEntity> ListWorkTimePerDayInternalAsync<TEntity>(IEnumerable<TEntity> entities, object from_datetime, object to_datetime, object calendar, object domain) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_mixin.py, METHOD: _list_work_time_per_day) ---
            */
            return default;
        }

        public async Task<TEntity> LoadDemoDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _load_demo_data) ---
            */
            return default;
        }

        public async Task<TEntity> LoadScenarioInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _load_scenario) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnerFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _mail_get_partner_fields) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NewAsync<TEntity>(IEnumerable<TEntity> entities, object values, object origin, object @ref) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: new) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NotifyExpiringContractWorkPermitAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: notify_expiring_contract_work_permit) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeContractDateStartInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_contract_date_start) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeContractTemplateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_contract_template_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePhoneValidationEmployeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_phone_validation_employee) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePrivateStateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_private_state_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTimezoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_timezone) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_user) ---
            */
            return default;
        }

        public async Task<TEntity> PhoneGetNumberFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _phone_get_number_fields) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareCreateValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _prepare_create_values) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareGraphDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object load_data, object week_range) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _prepare_graph_data) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareResourceValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object tz) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _prepare_resource_values) ---
            --- METHOD SOURCE (MODULE: resource, FILE: resource_mixin.py, METHOD: _prepare_resource_values) ---
            */
            return default;
        }

        public async Task<TEntity> RemoveWorkContactIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user, object employee_company) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _remove_work_contact_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchFetchAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object field_names, object offset, object limit, object order) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: search_fetch) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object offset, object limit, object order) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _search) ---
            */
            return default;
        }

        public async Task<TEntity> SearchNewlyHiredInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _search_newly_hired) ---
            */
            return default;
        }

        public async Task<TEntity> SearchVersionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _search_version_id) ---
            */
            return default;
        }

        public async Task<TEntity> SyncSalaryDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _sync_salary_distribution) ---
            */
            return default;
        }

        public async Task<TEntity> SyncUserInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user, object employee_has_image) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _sync_user) ---
            */
            return default;
        }

        public async Task<TEntity> UnblockAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: unblock) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> VerifyBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _verify_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> VerifyPinInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _verify_pin) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: write) ---
            */
            return default;
        }
    }
}