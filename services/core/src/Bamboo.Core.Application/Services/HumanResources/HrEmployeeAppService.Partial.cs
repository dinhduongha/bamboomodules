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
    public partial class HrEmployeeAppService
    {

        protected async Task<HrEmployee> ActionSetManualPresenceInternalAsync(object state)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py, METHOD: _action_set_manual_presence) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrEmployee> AddCertificationActivityToEmployeesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee.py, METHOD: _add_certification_activity_to_employees) ---
            */
            return default;
        }

        protected async Task<HrEmployee> AttendanceActionChangeInternalAsync(object geo_information)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py, METHOD: _attendance_action_change) ---
            */
            return default;
        }

        protected async Task<HrEmployee> CheckAccessInternalAsync(object operation)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _check_access) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrEmployee> CheckPresenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py, METHOD: _check_presence) ---
            */
            return default;
        }

        protected async Task<HrEmployee> CheckPrivateFieldsInternalAsync(object field_names)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _check_private_fields) ---
            */
            return default;
        }

        protected async Task<HrEmployee> CheckSalaryDistributionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _check_salary_distribution) ---
            */
            return default;
        }

        protected async Task<HrEmployee> CheckWorkContactIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_fleet, FILE: employee.py, METHOD: _check_work_contact_id) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeAllocationCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py, METHOD: _compute_allocation_count) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeAllocationRemainingDisplayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py, METHOD: _compute_allocation_remaining_display) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeAttendanceStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py, METHOD: _compute_attendance_state) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeAvatar1024InternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_avatar_1024) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeAvatar128InternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_avatar_128) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeAvatar1920InternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_avatar_1920) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeAvatar256InternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_avatar_256) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeAvatar512InternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_avatar_512) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeAvatarInternalAsync(object avatar_field, object image_field)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_avatar) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeBirthdayPublicDisplayStringInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_birthday_public_display_string) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeCertificationIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee.py, METHOD: _compute_certification_ids) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeChildCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_org_chart, FILE: hr_org_chart_mixin.py, METHOD: _compute_child_count) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeCoachInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_coach) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeCoursesCompletionTextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills_slides, FILE: hr_employee.py, METHOD: _compute_courses_completion_text) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeCurrentEmployeeSkillIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee.py, METHOD: _compute_current_employee_skill_ids) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeCurrentLeaveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py, METHOD: _compute_current_leave) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeCurrentVersionIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_current_version_id) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeDisplayCertificationPageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee.py, METHOD: _compute_display_certification_page) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_employee.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeEmployeeBadgesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_gamification, FILE: hr_employee.py, METHOD: _compute_employee_badges) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeEmployeeCarsCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_fleet, FILE: employee.py, METHOD: _compute_employee_cars_count) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeEmployeeGoalsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_gamification, FILE: hr_employee.py, METHOD: _compute_employee_goals) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeEquipmentCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_maintenance, FILE: hr_employee.py, METHOD: _compute_equipment_count) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeExceptionalLocationIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_homeworking, FILE: hr_employee.py, METHOD: _compute_exceptional_location_id) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeExpenseManagerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_employee.py, METHOD: _compute_expense_manager) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeHasMultipleBankAccountsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_has_multiple_bank_accounts) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeHasTimesheetInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_employee.py, METHOD: _compute_has_timesheet) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeHasWorkEntriesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_employee.py, METHOD: _compute_has_work_entries) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeHoursLastMonthInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py, METHOD: _compute_hours_last_month) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeHoursTodayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py, METHOD: _compute_hours_today) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeIsSubordinateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_org_chart, FILE: hr_org_chart_mixin.py, METHOD: _compute_is_subordinate) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeIsTrustedBankAccountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_is_trusted_bank_account) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeLastActivityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_last_activity) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeLastAttendanceIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py, METHOD: _compute_last_attendance_id) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeLeaveManagerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py, METHOD: _compute_leave_manager) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeLeaveStatusInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py, METHOD: _compute_leave_status) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeLegalNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_legal_name) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeLicensePlateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_fleet, FILE: employee.py, METHOD: _compute_license_plate) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeNewlyHiredInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_newly_hired) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputePresenceIconInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_presence_icon) ---
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py, METHOD: _compute_presence_icon) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py, METHOD: _compute_presence_icon) ---
            --- METHOD SOURCE (MODULE: hr_holidays_homeworking, FILE: hr_employee.py, METHOD: _compute_presence_icon) ---
            --- METHOD SOURCE (MODULE: hr_homeworking, FILE: hr_employee.py, METHOD: _compute_presence_icon) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputePresenceStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_presence_state) ---
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py, METHOD: _compute_presence_state) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py, METHOD: _compute_presence_state) ---
            --- METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py, METHOD: _compute_presence_state) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputePrimaryBankAccountIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_primary_bank_account_id) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeRelatedPartnersCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_related_partners_count) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeShowLeavesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py, METHOD: _compute_show_leaves) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeSkillIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee.py, METHOD: _compute_skill_ids) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeSubordinatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_org_chart, FILE: hr_org_chart_mixin.py, METHOD: _compute_subordinates) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeTotalOvertimeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py, METHOD: _compute_total_overtime) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeVersionIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_version_id) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeVersionsCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_versions_count) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeWorkContactDetailsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_work_contact_details) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeWorkLocationNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_work_location_name) ---
            --- METHOD SOURCE (MODULE: hr_homeworking, FILE: hr_employee.py, METHOD: _compute_work_location_name) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeWorkLocationTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_work_location_type) ---
            --- METHOD SOURCE (MODULE: hr_homeworking, FILE: hr_employee.py, METHOD: _compute_work_location_type) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ComputeWorkPermitNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_work_permit_name) ---
            */
            return default;
        }

        protected async Task<HrEmployee> CopyCacheFromInternalAsync(object @public, object field_names)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _copy_cache_from) ---
            */
            return default;
        }

        protected async Task<HrEmployee> CreateFuturePublicHolidaysTimesheetsInternalAsync(object employees)
        {
            /*
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: hr_employee.py, METHOD: _create_future_public_holidays_timesheets) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrEmployee> CreateInternalAsync(object data_list)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _create) ---
            */
            return default;
        }

        protected async Task<HrEmployee> CreateWorkContactsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _create_work_contacts) ---
            */
            return default;
        }

        protected async Task<HrEmployee> CronUpdateCurrentVersionIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _cron_update_current_version_id) ---
            */
            return default;
        }

        protected async Task<HrEmployee> DeleteFuturePublicHolidaysTimesheetsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: hr_employee.py, METHOD: _delete_future_public_holidays_timesheets) ---
            */
            return default;
        }

        protected async Task<HrEmployee> EmployeeAttendanceIntervalsInternalAsync(object start, object stop, object lunch)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _employee_attendance_intervals) ---
            */
            return default;
        }

        protected async Task<object> FieldToSqlInternalAsync(string @alias, string field_expr, object query)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _field_to_sql) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetAgeInternalAsync(object target_date)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_age) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetAllContractDatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_all_contract_dates) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrEmployee> GetAllVersionsWithContractOverlapWithPeriodInternalAsync(object date_from, object date_to)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_all_versions_with_contract_overlap_with_period) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetCalendarAttendancesInternalAsync(object date_from, object date_to)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_calendar_attendances) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetCalendarPeriodsInternalAsync(object start, object stop, object check_contract)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_calendar_periods) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetCalendarTzBatchInternalAsync(object dt)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_calendar_tz_batch) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetCalendarsInternalAsync(object date_from)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_calendars) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrEmployee> GetCertificateSelectionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_certificate_selection) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetConsumedLeavesInternalAsync(object leave_types, object target_date, object ignore_future)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py, METHOD: _get_consumed_leaves) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrEmployee> GetContextualEmployeeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py, METHOD: _get_contextual_employee) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetContractDatesInternalAsync(object date)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_contract_dates) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetContractVersionsInternalAsync(object date_start, object date_end, object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_contract_versions) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetContractsInternalAsync(object date_start, object date_end, object use_latest_version, object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_contracts) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrEmployee> GetCurrentDayLocationFieldInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_homeworking, FILE: hr_employee.py, METHOD: _get_current_day_location_field) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetDepartureDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_departure_date) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetEmployeeM2oToEmptyOnArchivedEmployeesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_employee_m2o_to_empty_on_archived_employees) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrEmployee> GetEmployeeWorkingNowInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_employee_working_now) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetExpectedAttendancesInternalAsync(object date_from, object date_to)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_expected_attendances) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetFirstVersionDateInternalAsync(object no_gap)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_first_version_date) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetFirstVersionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_first_versions) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetFirstWorkingIntervalInternalAsync(object dt)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py, METHOD: _get_first_working_interval) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetHoursPerDayInternalAsync(object date_from)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py, METHOD: _get_hours_per_day) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetMandatoryDaysInternalAsync(object start_date, object end_date)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py, METHOD: _get_mandatory_days) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrEmployee> GetNewHireFieldInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_new_hire_field) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetPartnerCountDependsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_partner_count_depends) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_employee.py, METHOD: _get_partner_count_depends) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetPublicHolidaysInternalAsync(object date_start, object date_end)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py, METHOD: _get_public_holidays) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetRelatedPartnersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_related_partners) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_employee.py, METHOD: _get_related_partners) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetSchedulesByEmployeeByWorkTypeInternalAsync(object start, object stop, object version_periods_by_employee)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py, METHOD: _get_schedules_by_employee_by_work_type) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetStoreAvatarCardFieldsInternalAsync(object target)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_store_avatar_card_fields) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py, METHOD: _get_store_avatar_card_fields) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetSubordinatesInternalAsync(object parents)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_org_chart, FILE: hr_org_chart_mixin.py, METHOD: _get_subordinates) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetTzBatchInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_tz_batch) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetTzInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_tz) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetUnusualDaysInternalAsync(object date_from, object date_to)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_unusual_days) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetUserM2oToEmptyOnArchivedEmployeesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_user_m2o_to_empty_on_archived_employees) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_employee.py, METHOD: _get_user_m2o_to_empty_on_archived_employees) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py, METHOD: _get_user_m2o_to_empty_on_archived_employees) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetVersionInternalAsync(object date)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_version) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetVersionPeriodsInternalAsync(object start, object stop, object field, object check_contract)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_version_periods) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetVersionsWithContractOverlapWithPeriodInternalAsync(object date_from, object date_to)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_versions_with_contract_overlap_with_period) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GetWorklocationInternalAsync(object start_date, object end_date)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_homeworking_calendar, FILE: hr_employee.py, METHOD: _get_worklocation) ---
            */
            return default;
        }

        protected async Task<HrEmployee> GroupHrExpenseUserDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_employee.py, METHOD: _group_hr_expense_user_domain) ---
            */
            return default;
        }

        protected async Task<HrEmployee> HasFieldAccessInternalAsync(object field, object operation)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _has_field_access) ---
            */
            return default;
        }

        protected async Task<HrEmployee> InverseWorkContactDetailsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _inverse_work_contact_details) ---
            */
            return default;
        }

        protected async Task<HrEmployee> IsInContractInternalAsync(object date)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _is_in_contract) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrEmployee> LangGetInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _lang_get) ---
            */
            return default;
        }

        protected async Task<HrEmployee> LoadDemoDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _load_demo_data) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrEmployee> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_hr, FILE: hr_employee.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrEmployee> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_hr, FILE: hr_employee.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrEmployee> LoadPosDataReadInternalAsync(object records, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_hr, FILE: hr_employee.py, METHOD: _load_pos_data_read) ---
            */
            return default;
        }

        protected async Task<HrEmployee> LoadScenarioInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _load_scenario) ---
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee.py, METHOD: _load_scenario) ---
            */
            return default;
        }

        protected async Task<HrEmployee> MailGetPartnerFieldsInternalAsync(object introspect_fields)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _mail_get_partner_fields) ---
            */
            return default;
        }

        protected async Task<HrEmployee> OnchangeCompanyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_company_id) ---
            */
            return default;
        }

        protected async Task<HrEmployee> OnchangeContractDateStartInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_contract_date_start) ---
            */
            return default;
        }

        protected async Task<HrEmployee> OnchangeContractTemplateIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_contract_template_id) ---
            */
            return default;
        }

        protected async Task<HrEmployee> OnchangePhoneValidationEmployeeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_phone_validation_employee) ---
            */
            return default;
        }

        protected async Task<HrEmployee> OnchangePrivateStateIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_private_state_id) ---
            */
            return default;
        }

        protected async Task<HrEmployee> OnchangeTimezoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_timezone) ---
            */
            return default;
        }

        protected async Task<HrEmployee> OnchangeUserInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_user) ---
            */
            return default;
        }

        protected async Task<HrEmployee> PhoneGetNumberFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _phone_get_number_fields) ---
            */
            return default;
        }

        protected async Task<HrEmployee> PrepareCreateValuesInternalAsync(object vals_list)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _prepare_create_values) ---
            */
            return default;
        }

        protected async Task<HrEmployee> PrepareResourceValuesInternalAsync(object vals, object tz)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _prepare_resource_values) ---
            */
            return default;
        }

        protected async Task<HrEmployee> RemoveWorkContactIdInternalAsync(object user, object employee_company)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _remove_work_contact_id) ---
            */
            return default;
        }

        protected async Task<HrEmployee> SearchAbsentEmployeeInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py, METHOD: _search_absent_employee) ---
            */
            return default;
        }

        protected async Task<HrEmployee> SearchFilterForExpenseInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_employee.py, METHOD: _search_filter_for_expense) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrEmployee> SearchInternalAsync(object domain, object offset, object limit, object order)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _search) ---
            */
            return default;
        }

        protected async Task<HrEmployee> SearchIsSubordinateInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_org_chart, FILE: hr_org_chart_mixin.py, METHOD: _search_is_subordinate) ---
            */
            return default;
        }

        protected async Task<HrEmployee> SearchLicensePlateInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_fleet, FILE: employee.py, METHOD: _search_license_plate) ---
            */
            return default;
        }

        protected async Task<HrEmployee> SearchNewlyHiredInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _search_newly_hired) ---
            */
            return default;
        }

        protected async Task<HrEmployee> SearchVersionIdInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _search_version_id) ---
            */
            return default;
        }

        protected async Task<HrEmployee> ServerDateToDomainInternalAsync(object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_hr, FILE: hr_employee.py, METHOD: _server_date_to_domain) ---
            */
            return default;
        }

        protected async Task<HrEmployee> SyncSalaryDistributionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _sync_salary_distribution) ---
            */
            return default;
        }

        protected async Task<HrEmployee> SyncUserInternalAsync(object user, object employee_has_image)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _sync_user) ---
            */
            return default;
        }

        protected async Task<HrEmployee> UnlinkExceptActivePosSessionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_hr, FILE: hr_employee.py, METHOD: _unlink_except_active_pos_session) ---
            */
            return default;
        }

        protected async Task<HrEmployee> VerifyBarcodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _verify_barcode) ---
            */
            return default;
        }

        protected async Task<HrEmployee> VerifyPinInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _verify_pin) ---
            */
            return default;
        }
    }
}