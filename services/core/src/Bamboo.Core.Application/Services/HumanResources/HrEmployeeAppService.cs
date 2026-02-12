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
    [Module("Hr", Category = "HumanResources", Depends = new[] { "base_setup", "digest", "phone_validation", "resource_mail", "web" })]
    public partial class HrEmployeeAppService : GenericAppService<HrEmployee>, IHrEmployeeAppService
    {
        protected readonly IAvatarMixinAppService _avatarMixinAppService;
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadMainAttachmentAppService _mailThreadMainAttachmentAppService;
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        protected readonly IResourceMixinAppService _resourceMixinAppService;
        public HrEmployeeAppService(IRepository<HrEmployee, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IAvatarMixinAppService avatarMixinAppService, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadMainAttachmentAppService mailThreadMainAttachmentAppService, IPosLoadMixinAppService posLoadMixinAppService, IResourceMixinAppService resourceMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _avatarMixinAppService = avatarMixinAppService;
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadMainAttachmentAppService = mailThreadMainAttachmentAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
            _resourceMixinAppService = resourceMixinAppService;
        }

        public async Task<HrEmployee> ArchiveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_archive) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> CheckNoExistingContractAsync(HrEmployeeCheckNoExistingContractRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: check_no_existing_contract) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<HrEmployee> CreateAsync(CreateRequestDto<HrEmployee> input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_employee.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: hr_employee.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<HrEmployee> CreateContractAsync(HrEmployeeCreateContractRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: create_contract) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> CreateUserAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_create_user) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> CreateUsersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_create_users) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> CreateUsersConfirmationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_create_users_confirmation) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> CreateVersionAsync(HrEmployeeCreateVersionRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: create_version) ---
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_employee.py, METHOD: create_version) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public override async Task<HrEmployee> DefaultGetAsync(DefaultGetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_employee.py, METHOD: default_get) ---
            */
            return await base.DefaultGetAsync(input);
        }

        public async Task<HrEmployee> FetchAsync(HrEmployeeFetchRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: fetch) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> GenerateRandomBarcodeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: generate_random_barcode) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> GenerateWorkEntriesAsync(HrEmployeeGenerateWorkEntriesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_employee.py, METHOD: generate_work_entries) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> GetAccountsWithFixedAllocationsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_accounts_with_fixed_allocations) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<HrEmployee> GetAllocationRequestsAmountAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py, METHOD: get_allocation_requests_amount) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> GetAvatarCardDataAsync(HrEmployeeGetAvatarCardDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_avatar_card_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> GetBankAccountSalaryAllocationAsync(HrEmployeeGetBankAccountSalaryAllocationRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_bank_account_salary_allocation) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> GetBarcodesAndPinHashedAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_hr, FILE: hr_employee.py, METHOD: get_barcodes_and_pin_hashed) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> GetFormviewActionAsync(HrEmployeeGetFormviewActionRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_formview_action) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> GetFormviewIdAsync(HrEmployeeGetFormviewIdRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_formview_id) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<HrEmployee> GetImportTemplatesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_import_templates) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<HrEmployee> GetInternalResumeLinesAsync(HrEmployeeGetInternalResumeLinesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee.py, METHOD: get_internal_resume_lines) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> GetMandatoryDaysAsync(HrEmployeeGetMandatoryDaysRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py, METHOD: get_mandatory_days) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<HrEmployee> GetMandatoryDaysDataAsync(HrEmployeeGetMandatoryDaysDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py, METHOD: get_mandatory_days_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<HrEmployee> GetOvertimeDataAsync(HrEmployeeGetOvertimeDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py, METHOD: get_overtime_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> GetOvertimeDataByEmployeeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_employee.py, METHOD: get_overtime_data_by_employee) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> GetPresenceServerDataAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py, METHOD: get_presence_server_action_data) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<HrEmployee> GetPublicHolidaysDataAsync(HrEmployeeGetPublicHolidaysDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py, METHOD: get_public_holidays_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> GetRemainingPercentageAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_remaining_percentage) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<HrEmployee> GetSpecialDaysDataAsync(HrEmployeeGetSpecialDaysDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py, METHOD: get_special_days_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<HrEmployee> GetTimeOffDashboardDataAsync(HrEmployeeGetTimeOffDashboardDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py, METHOD: get_time_off_dashboard_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<HrEmployee> GetViewAsync(HrEmployeeGetViewRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_view) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<HrEmployee> GetViewsAsync(HrEmployeeGetViewsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_views) ---
            --- METHOD SOURCE (MODULE: hr_homeworking, FILE: hr_employee.py, METHOD: get_views) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<HrEmployee> NewAsync(HrEmployeeNewRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: new) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<HrEmployee> NotifyExpiringContractWorkPermitAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: notify_expiring_contract_work_permit) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> OpenAllocationWizardAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_open_allocation_wizard) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> OpenBarcodeScannerAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py, METHOD: open_barcode_scanner) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> OpenCoursesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills_slides, FILE: hr_employee.py, METHOD: action_open_courses) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> OpenEmployeeCarsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_fleet, FILE: employee.py, METHOD: action_open_employee_cars) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> OpenLastMonthAttendancesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py, METHOD: action_open_last_month_attendances) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> OpenLeaveRequestAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py, METHOD: action_open_leave_request) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> OpenVersionsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_open_versions) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> OpenWorkEntriesAsync(HrEmployeeOpenWorkEntriesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_employee.py, METHOD: action_open_work_entries) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> RelatedContactsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_related_contacts) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<HrEmployee> SearchFetchAsync(HrEmployeeSearchFetchRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: search_fetch) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> SendLogAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py, METHOD: action_send_log) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> SendSmsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py, METHOD: action_send_sms) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> SetAbsentAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py, METHOD: action_set_absent) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> SetPresentAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py, METHOD: action_set_present) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> TimeOffDashboardAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py, METHOD: action_time_off_dashboard) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> TimesheetFromEmployeeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_employee.py, METHOD: action_timesheet_from_employee) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> TogglePrimaryBankAccountTrustAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_toggle_primary_bank_account_trust) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> UnarchiveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_unarchive) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployee> UnlinkWizardAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_employee.py, METHOD: action_unlink_wizard) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<HrEmployee> input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_fleet, FILE: employee.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: hr_employee.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}