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
    [Module("hr", Category = "HumanResources", Depends = new[] { "base_setup", "digest", "phone_validation", "resource_mail", "web" })]
    public partial class HrEmployeeBaseAppService : ApplicationService, IHrEmployeeBaseAppService
    {

        public HrEmployeeBaseAppService() 
        {

        }

        public async Task<TEntity> ActionCreateUserAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_create_user) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenLeaveRequestAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py, METHOD: action_open_leave_request) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRelatedContactsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_related_contacts) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendLogAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py, METHOD: action_send_log) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendSmsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py, METHOD: action_send_sms) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetAbsentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py, METHOD: action_set_absent) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetManualPresenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object state) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py, METHOD: _action_set_manual_presence) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetPresentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py, METHOD: action_set_present) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckFieldAccessRightsAsync<TEntity>(IEnumerable<TEntity> entities, object operation, object field_names) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: check_field_access_rights) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckPresenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py, METHOD: _check_presence) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPrivateFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_names) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _check_private_fields) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSsnidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _check_ssnid) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAddressIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py, METHOD: _compute_address_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllocationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_base.py, METHOD: _compute_allocation_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllocationRemainingDisplayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_base.py, METHOD: _compute_allocation_remaining_display) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1024InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_avatar_1024) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar128InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_avatar_128) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1920InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_avatar_1920) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar256InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_avatar_256) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar512InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_avatar_512) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatarInternalAsync<TEntity>(IEnumerable<TEntity> entities, object avatar_field, object image_field) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_avatar) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeChildCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_org_chart, FILE: hr_org_chart_mixin.py, METHOD: _compute_child_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCoachInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py, METHOD: _compute_coach) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeeBadgesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_gamification, FILE: hr_employee.py, METHOD: _compute_employee_badges) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeeGoalsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_gamification, FILE: hr_employee.py, METHOD: _compute_employee_goals) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py, METHOD: _compute_employee_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeExceptionalLocationIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_homeworking, FILE: hr_employee.py, METHOD: _compute_exceptional_location_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsFlexibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py, METHOD: _compute_is_flexible) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsManagerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py, METHOD: _compute_is_manager) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsSubordinateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_org_chart, FILE: hr_org_chart_mixin.py, METHOD: _compute_is_subordinate) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeJobTitleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py, METHOD: _compute_job_title) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeKmHomeWorkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_km_home_work) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLastActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py, METHOD: _compute_last_activity) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLeaveManagerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_base.py, METHOD: _compute_leave_manager) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLeaveStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_base.py, METHOD: _compute_leave_status) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeManagerOnlyFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py, METHOD: _compute_manager_only_fields) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNewlyHiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py, METHOD: _compute_newly_hired) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py, METHOD: _compute_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartOfDepartmentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py, METHOD: _compute_part_of_department) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePhonesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py, METHOD: _compute_phones) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePresenceIconInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py, METHOD: _compute_presence_icon) ---
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee_base.py, METHOD: _compute_presence_icon) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_base.py, METHOD: _compute_presence_icon) ---
            --- METHOD SOURCE (MODULE: hr_homeworking, FILE: hr_employee.py, METHOD: _compute_presence_icon) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePresenceStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py, METHOD: _compute_presence_state) ---
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee_base.py, METHOD: _compute_presence_state) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_base.py, METHOD: _compute_presence_state) ---
            --- METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee_base.py, METHOD: _compute_presence_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRelatedPartnersCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_related_partners_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRemainingLeavesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_base.py, METHOD: _compute_remaining_leaves) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowLeavesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_base.py, METHOD: _compute_show_leaves) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSubordinatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_org_chart, FILE: hr_org_chart_mixin.py, METHOD: _compute_subordinates) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkContactDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py, METHOD: _compute_work_contact_details) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkLocationNameTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py, METHOD: _compute_work_location_name_type) ---
            --- METHOD SOURCE (MODULE: hr_homeworking, FILE: hr_employee.py, METHOD: _compute_work_location_name_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkPermitNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_work_permit_name) ---
            */
            return default;
        }

        public async Task<TEntity> CopyCacheFromInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @public, object field_names) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _copy_cache_from) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_base.py, METHOD: create) ---
            */
            return default;
        }

        public async Task<TEntity> CreateWorkContactsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py, METHOD: _create_work_contacts) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CronCheckWorkPermitValidityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _cron_check_work_permit_validity) ---
            */
            return default;
        }

        public async Task<TEntity> EmployeeAttendanceIntervalsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object stop, object lunch) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _employee_attendance_intervals) ---
            */
            return default;
        }

        public async Task<TEntity> FetchAsync<TEntity>(IEnumerable<TEntity> entities, object field_names) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: fetch) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateRandomBarcodeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: generate_random_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> GetAgeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_date) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_age) ---
            */
            return default;
        }

        public async Task<TEntity> GetAvatarCardDataAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py, METHOD: get_avatar_card_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetCalendarAttendancesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_calendar_attendances) ---
            */
            return default;
        }

        public async Task<TEntity> GetCalendarPeriodsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object stop) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py, METHOD: _get_calendar_periods) ---
            */
            return default;
        }

        public async Task<TEntity> GetConsumedLeavesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object leave_types, object target_date, object ignore_future) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_base.py, METHOD: _get_consumed_leaves) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetContextualEmployeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_base.py, METHOD: _get_contextual_employee) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetCurrentDayLocationFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_homeworking, FILE: hr_employee.py, METHOD: _get_current_day_location_field) ---
            */
            return default;
        }

        public async Task<TEntity> GetEmployeeM2oToEmptyOnArchivedEmployeesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_employee_m2o_to_empty_on_archived_employees) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEmployeeWorkingNowInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py, METHOD: _get_employee_working_now) ---
            */
            return default;
        }

        public async Task<TEntity> GetExpectedAttendancesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_expected_attendances) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py, METHOD: _get_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetFirstWorkingIntervalInternalAsync<TEntity>(IEnumerable<TEntity> entities, object dt) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_base.py, METHOD: _get_first_working_interval) ---
            */
            return default;
        }

        public async Task<TEntity> GetFormviewActionAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_formview_action) ---
            */
            return default;
        }

        public async Task<TEntity> GetFormviewIdAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_formview_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_import_templates) ---
            */
            return default;
        }

        public async Task<TEntity> GetManagerOnlyFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py, METHOD: _get_manager_only_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetMaritalStatusSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_marital_status_selection) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetNewHireFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py, METHOD: _get_new_hire_field) ---
            --- METHOD SOURCE (MODULE: hr_contract, FILE: hr_employee.py, METHOD: _get_new_hire_field) ---
            */
            return default;
        }

        public async Task<TEntity> GetPartnerCountDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_partner_count_depends) ---
            */
            return default;
        }

        public async Task<TEntity> GetPresenceServerActionDataAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py, METHOD: get_presence_server_action_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetRelatedPartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_related_partners) ---
            */
            return default;
        }

        public async Task<TEntity> GetRemainingLeavesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_base.py, METHOD: _get_remaining_leaves) ---
            */
            return default;
        }

        public async Task<TEntity> GetSubordinatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parents) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_org_chart, FILE: hr_org_chart_mixin.py, METHOD: _get_subordinates) ---
            */
            return default;
        }

        public async Task<TEntity> GetTzBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_tz_batch) ---
            */
            return default;
        }

        public async Task<TEntity> GetTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_tz) ---
            */
            return default;
        }

        public async Task<TEntity> GetUnusualDaysInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_unusual_days) ---
            */
            return default;
        }

        public async Task<TEntity> GetUserM2oToEmptyOnArchivedEmployeesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_user_m2o_to_empty_on_archived_employees) ---
            */
            return default;
        }

        public async Task<TEntity> GetValidEmployeeForUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py, METHOD: _get_valid_employee_for_user) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_view) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewsAsync<TEntity>(IEnumerable<TEntity> entities, object views, object options) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_views) ---
            --- METHOD SOURCE (MODULE: hr_homeworking, FILE: hr_employee.py, METHOD: get_views) ---
            */
            return default;
        }

        public async Task<TEntity> GetWorklocationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_date, object end_date) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_homeworking_calendar, FILE: hr_employee.py, METHOD: _get_worklocation) ---
            */
            return default;
        }

        public async Task<TEntity> InitAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py, METHOD: init) ---
            */
            return default;
        }

        public async Task<TEntity> InverseKmHomeWorkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _inverse_km_home_work) ---
            */
            return default;
        }

        public async Task<TEntity> InverseWorkContactDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py, METHOD: _inverse_work_contact_details) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LangGetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _lang_get) ---
            */
            return default;
        }

        public async Task<TEntity> LoadScenarioInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _load_scenario) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnerFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _mail_get_partner_fields) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTimezoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_timezone) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_user) ---
            */
            return default;
        }

        public async Task<TEntity> PhoneGetNumberFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _phone_get_number_fields) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareResourceValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object tz) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _prepare_resource_values) ---
            */
            return default;
        }

        public async Task<TEntity> RemoveWorkContactIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user, object employee_company) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _remove_work_contact_id) ---
            */
            return default;
        }

        public async Task<TEntity> SearchAbsentEmployeeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_base.py, METHOD: _search_absent_employee) ---
            */
            return default;
        }

        public async Task<TEntity> SearchEmployeeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py, METHOD: _search_employee_id) ---
            */
            return default;
        }

        public async Task<TEntity> SearchFetchAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object field_names, object offset, object limit, object order) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: search_fetch) ---
            */
            return default;
        }

        public async Task<TEntity> SearchFilterForExpenseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_employee.py, METHOD: _search_filter_for_expense) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object offset, object limit, object order) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _search) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsSubordinateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_org_chart, FILE: hr_org_chart_mixin.py, METHOD: _search_is_subordinate) ---
            */
            return default;
        }

        public async Task<TEntity> SearchNewlyHiredInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py, METHOD: _search_newly_hired) ---
            */
            return default;
        }

        public async Task<TEntity> SearchPartOfDepartmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py, METHOD: _search_part_of_department) ---
            */
            return default;
        }

        public async Task<TEntity> SyncUserInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user, object employee_has_image) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _sync_user) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleActiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: toggle_active) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> VerifyBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _verify_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> VerifyPinInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _verify_pin) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_base.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_holidays_contract, FILE: hr_employee_base.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py, METHOD: write) ---
            */
            return default;
        }
    }
}