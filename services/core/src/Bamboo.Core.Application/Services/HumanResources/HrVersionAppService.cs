using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Hr", Category = "HumanResources", Depends = new[] { "base_setup", "digest", "phone_validation", "resource_mail", "web" })]
    public class HrVersionAppService : GenericApplicationService<HrVersion>, IHrVersionAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        public HrVersionAppService(IRepository<HrVersion, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        protected async Task<HrVersion> CancelWorkEntriesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def _cancel_work_entries(self):
            // if not self:
            //     return
            // domains = []
            // for version in self:
            //     date_start = fields.Datetime.to_datetime(version.date_start)
            //     version_domain = Domain([
            //         ('version_id', '=', version.id),
            //         ('date', '>=', date_start),
            //     ])
            //     if version.date_end:
            //         date_end = datetime.combine(version.date_end, datetime.max.time())
            //         version_domain &= Domain('date', '<=', date_end)
            //     domains.append(version_domain)
            // domain = Domain.OR(domains) & Domain('state', '!=', 'validated')
            // work_entries = self.env['hr.work.entry'].sudo().search(domain)
            // if work_entries:
            //     work_entries.unlink()
            */
            return default;
        }

        public async Task<HrVersion> CheckContractFinishedAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def check_contract_finished(self):
            // if self.contract_date_start and not self.contract_date_end:
            //     raise ValidationError(self.env._("Before creating a new contract, close the current one by setting an end date."))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrVersion> CheckContractsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_version.py) ---
            // def _check_contracts(self):
            // self._get_leaves()._check_contracts()
            */
            return default;
        }

        protected async Task<HrVersion> CheckDatesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _check_dates(self):
            // version_read_group = self.env['hr.version'].sudo()._read_group(
            //     [
            //         ('id', 'not in', self.ids),
            //         ('employee_id', 'in', self.employee_id.ids),
            //         ('contract_date_start', '!=', False),
            //     ],
            //     ['employee_id', 'contract_date_start:day', 'contract_date_end:day'],
            //     ['id:recordset'],
            // )
            // dates_per_employee = defaultdict(list)
            // for employee, date_start, date_end, versions in version_read_group:
            //     dates_per_employee[employee].append((date_start, date_end, versions))
            // for version in self.sudo():  # sudo needed to read contract dates
            //     if not version.contract_date_start or not version.employee_id:
            //         continue
            //     if version.contract_date_end and version.contract_date_start > version.contract_date_end:
            //         raise ValidationError(self.env._(
            //             'Start date (%(start)s) must be earlier than contract end date (%(end)s).',
            //             start=version.contract_date_start, end=version.contract_date_end,
            //         ))
            //     if not version.active:
            //         continue
            //     contract_date_end = version.contract_date_end or date.max
            //     contract_period_exists = False
            //     for date_start, date_end, versions in dates_per_employee[version.employee_id]:
            //         date_to = date_end or date.max
            //         if date_start == version.contract_date_start and date_to == contract_date_end:
            //             contract_period_exists = True
            //             continue
            //         if date_start <= contract_date_end and version.contract_date_start <= date_to:
            //             raise ValidationError(self.env._(
            //                 "%s already has a contract running during the selected period.\n\n"
            //                 "Please either:\n\n"
            //                 "- Change the start date so that it doesn't overlap with the existing contract, or\n"
            //                 "- Create a new employee if this employee should have multiple active contracts.",
            //                 version.employee_id.display_name))
            //     if not contract_period_exists:
            //         dates_per_employee[version.employee_id].append((version.contract_date_start, version.contract_date_end, version))
            */
            return default;
        }

        protected async Task<HrVersion> CheckOverlappingContractInternalAsync(object leave)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_version.py) ---
            // def _check_overlapping_contract(self, leave):
            // # Get all overlapping contracts but exclude draft contracts that are not included in this transaction.
            // overlapping_contracts = leave._get_overlapping_contracts().sorted(
            //     key=lambda c: c.contract_date_start)
            // if len(overlapping_contracts.resource_calendar_id) <= 1:
            //     if overlapping_contracts:
            //         first_overlapping_contract = next(iter(overlapping_contracts), overlapping_contracts)
            //         if leave.resource_calendar_id != first_overlapping_contract.resource_calendar_id:
            //             leave.resource_calendar_id = first_overlapping_contract.resource_calendar_id
            //     return False
            // return overlapping_contracts
            */
            return default;
        }

        protected async Task<HrVersion> CheckSsnidInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _check_ssnid(self):
            // # By default, a Social Security Number is always valid, but each localization
            // # may want to add its own constraints
            // pass
            */
            return default;
        }

        protected async Task<HrVersion> ComputeAllowedCountryStateIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _compute_allowed_country_state_ids(self):
            // states = self.env["res.country.state"].search([])
            // for version in self:
            //     if version.private_country_id:
            //         version.allowed_country_state_ids = version.private_country_id.state_ids
            //     else:
            //         version.allowed_country_state_ids = states
            */
            return default;
        }

        protected async Task<HrVersion> ComputeCompanyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _compute_company_id(self):
            // for version in self:
            //     if version.employee_id:
            //         version.company_id = version.employee_id.company_id
            */
            return default;
        }

        protected async Task<HrVersion> ComputeContractWageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _compute_contract_wage(self):
            // for version in self:
            //     version.contract_wage = version._get_contract_wage()
            */
            return default;
        }

        protected async Task<HrVersion> ComputeDatesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _compute_dates(self):
            // for version in self:
            //     version.date_start = max(version.date_version, version.contract_date_start) \
            //         if version.contract_date_start \
            //         else version.date_version
            // 
            //     next_version = self.env['hr.version'].search([
            //         ('employee_id', 'in', version.employee_id.ids),
            //         ('date_version', '>', version.date_version)], limit=1)
            //     date_version_end = next_version.date_version + relativedelta(days=-1) if next_version else False
            // 
            //     if date_version_end and version.contract_date_end:
            //         version.date_end = min(date_version_end, version.contract_date_end)
            //     elif date_version_end:
            //         version.date_end = date_version_end
            //     else:
            //         version.date_end = version.contract_date_end
            */
            return default;
        }

        protected async Task<HrVersion> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _compute_display_name(self):
            // for version in self:
            //     version.display_name = version.name if not version.employee_id else format_date_abbr(version.env, version.date_version)
            */
            return default;
        }

        protected async Task<HrVersion> ComputeIsCurrentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _compute_is_current(self):
            // today = fields.Date.today()
            // for version in self:
            //     version.is_current = version.date_start <= today and (not version.date_end or version.date_end >= today)
            */
            return default;
        }

        protected async Task<HrVersion> ComputeIsCustomJobTitleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _compute_is_custom_job_title(self):
            // for version in self.filtered('job_id'):
            //     if version._origin.job_id != version.job_id:
            //         version.is_custom_job_title = False
            */
            return default;
        }

        protected async Task<HrVersion> ComputeIsFlexibleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _compute_is_flexible(self):
            // for version in self:
            //     version.is_fully_flexible = version._is_fully_flexible()
            //     version.is_flexible = version.is_fully_flexible or version.resource_calendar_id.flexible_hours
            */
            return default;
        }

        protected async Task<HrVersion> ComputeIsFutureInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _compute_is_future(self):
            // today = fields.Date.today()
            // for version in self:
            //     version.is_future = version.date_start > today
            */
            return default;
        }

        protected async Task<HrVersion> ComputeIsInContractInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _compute_is_in_contract(self):
            // for version in self:
            //     version.is_in_contract = version._is_in_contract()
            */
            return default;
        }

        protected async Task<HrVersion> ComputeIsPastInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _compute_is_past(self):
            // today = fields.Date.today()
            // for version in self:
            //     version.is_past = version.date_end and version.date_end < today
            */
            return default;
        }

        protected async Task<HrVersion> ComputeJobTitleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _compute_job_title(self):
            // for version in self.filtered('job_id'):
            //     if version._origin.job_id != version.job_id or not version.is_custom_job_title:
            //         version.job_title = version.job_id.name
            */
            return default;
        }

        protected async Task<HrVersion> ComputeKmHomeWorkInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _compute_km_home_work(self):
            // for version in self:
            //     version.km_home_work = version.distance_home_work * 1.609 if version.distance_home_work_unit == "miles" else version.distance_home_work
            */
            return default;
        }

        protected async Task<HrVersion> ComputePartOfDepartmentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _compute_part_of_department(self):
            // user_employee = self._get_valid_employee_for_user()
            // active_department = user_employee.department_id
            // if not active_department:
            //     self.member_of_department = False
            // else:
            //     def get_all_children(department):
            //         children = department.child_ids
            //         if not children:
            //             return self.env['hr.department']
            //         return children + get_all_children(children)
            // 
            //     child_departments = active_department + get_all_children(active_department)
            //     for version in self:
            //         version.member_of_department = version.department_id in child_departments
            */
            return default;
        }

        protected async Task<HrVersion> ComputeStructureTypeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _compute_structure_type_id(self):
            // 
            // default_structure_by_country = {}
            // 
            // def _default_salary_structure(country_id):
            //     default_structure = default_structure_by_country.get(country_id)
            //     if default_structure is None:
            //         default_structure = default_structure_by_country[country_id] = (
            //             self.env['hr.payroll.structure.type'].search([('country_id', '=', country_id)], limit=1)
            //             or self.env['hr.payroll.structure.type'].search([('country_id', '=', False)], limit=1)
            //         )
            //     return default_structure
            // 
            // for version in self:
            //     if not version.structure_type_id or (version.structure_type_id.country_id and version.structure_type_id.country_id != version.company_id.country_id):
            //         version.structure_type_id = _default_salary_structure(version.company_id.country_id.id)
            */
            return default;
        }

        protected async Task<HrVersion> ComputeWorkEntrySourceCalendarInvalidInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def _compute_work_entry_source_calendar_invalid(self):
            // for version in self:
            //     version.work_entry_source_calendar_invalid = version.work_entry_source == 'calendar' and not version.resource_calendar_id
            */
            return default;
        }

        protected async Task<HrVersion> CreateAllNewLeaveInternalAsync(object all_new_leave_origin, object all_new_leave_vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_version.py) ---
            // def _create_all_new_leave(self, all_new_leave_origin, all_new_leave_vals):
            // new_leaves = self.env['hr.leave'].with_context(
            //     tracking_disable=True,
            //     mail_activity_automation_skip=True,
            //     leave_fast_create=True,
            //     leave_skip_state_check=True
            // ).create(all_new_leave_vals)
            // new_leaves.filtered(lambda l: l.state in 'validate')._validate_leave_request()
            // for index, new_leave in enumerate(new_leaves):
            //     new_leave.message_post_with_source(
            //         'mail.message_origin_link',
            //         render_values={'self': new_leave, 'origin': all_new_leave_origin[index]},
            //         subtype_xmlid='mail.mt_note',
            //     )
            */
            return default;
        }

        public override async Task<HrVersion> CreateAsync(HrVersion entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def create(self, vals_list):
            // Version = self.env['hr.version']
            // for vals in vals_list:
            //     if 'contract_template_id' in vals:
            //         contract_vals = Version.get_values_from_contract_template(Version.browse(vals['contract_template_id']))
            //         # take vals from template, but priority given to the original vals
            //         vals.update({**contract_vals, **vals})
            // return super().create(vals_list)
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_version.py) ---
            // def create(self, vals_list):
            // all_new_leave_origin = []
            // all_new_leave_vals = []
            // leaves_state = {}
            // created_versions = self.env['hr.version']
            // for vals in vals_list:
            //     if not 'employee_id' in vals or not 'resource_calendar_id' in vals:
            //         created_versions |= super().create(vals)
            //         continue
            //     leaves = self._get_leaves_from_vals(vals)
            //     is_created = False
            //     for leave in leaves:
            //         leaves_state = self._refuse_leave(leave, leaves_state)
            //         if not is_created:
            //             created_versions |= super().create([vals])
            //             is_created = True
            //         overlapping_contracts = self._check_overlapping_contract(leave)
            //         if not overlapping_contracts:
            //             continue
            //         all_new_leave_origin, all_new_leave_vals = self._populate_all_new_leave_vals_from_split_leave(
            //             all_new_leave_origin, all_new_leave_vals, overlapping_contracts, leave, leaves_state)
            //     # TODO FIXME
            //     # to keep creation order, not ideal but ok for now.
            //     if not is_created:
            //         created_versions |= super().create([vals])
            // try:
            //     if all_new_leave_vals:
            //         self._create_all_new_leave(all_new_leave_origin, all_new_leave_vals)
            // except ValidationError:
            //     # In case a validation error is thrown due to holiday creation with the new resource calendar (which can
            //     # increase their duration), we catch this error to display a more meaningful error message.
            //     raise ValidationError(
            //         self.env._("Changing the contract on this employee changes their working schedule in a period "
            //                    "they already took leaves. Changing this working schedule changes the duration of "
            //                    "these leaves in such a way the employee no longer has the required allocation for "
            //                    "them. Please review these leaves and/or allocations before changing the contract."))
            // return created_versions
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<HrVersion> CronGenerateMissingWorkEntriesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def _cron_generate_missing_work_entries(self):
            // # retrieve versions for the current month
            // today = fields.Date.today()
            // start = datetime.combine(today + relativedelta(day=1), time.min)
            // stop = datetime.combine(today + relativedelta(months=1, day=31), time.max)
            // all_versions = self.env['hr.employee']._get_all_versions_with_contract_overlap_with_period(start.date(), stop.date())
            // # determine versions to do (the ones whose generated dates have open periods this month)
            // versions_todo = all_versions.filtered(
            //     lambda v:
            //     (v.date_generated_from > start or v.date_generated_to < stop) and
            //     (not v.last_generation_date or v.last_generation_date < today))
            // if not versions_todo:
            //     return
            // version_todo_count = len(versions_todo)
            // # Filter versions by company, work entries generation is not supposed to be called on
            // # versions from differents companies, as we will retrieve the resource.calendar.leave
            // # and we don't want to mix everything up. The other versions will be treated when the
            // # cron is re-triggered
            // versions_todo = versions_todo.filtered(lambda v: v.company_id == versions_todo[0].company_id)
            // # generate a batch of work entries
            // BATCH_SIZE = 100
            // # Since attendance based are more volatile for their work entries generation
            // # it can happen that the date_generated_from and date_generated_to fields are not
            // # pushed to start and stop
            // # It is more interesting for batching to process statically generated work entries first
            // # since we get benefits from having multiple versions on the same calendar
            // versions_todo = versions_todo.sorted(key=lambda v: 1 if v.has_static_work_entries() else 100)
            // versions_todo = versions_todo[:BATCH_SIZE].generate_work_entries(start.date(), stop.date(), False)
            // # if necessary, retrigger the cron to generate more work entries
            // if version_todo_count > BATCH_SIZE:
            //     self.env.ref('hr_work_entry.ir_cron_generate_missing_work_entries')._trigger()
            */
            return default;
        }

        protected async Task<HrVersion> DefaultSalaryStructureInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _default_salary_structure(self):
            // return (
            //         self.env['hr.payroll.structure.type'].sudo().search([('country_id', '=', self.env.company.country_id.id)], limit=1)
            //         or self.env['hr.payroll.structure.type'].sudo().search([('country_id', '=', False)], limit=1)
            // )
            */
            return default;
        }

        protected async Task<HrVersion> DomainCurrentCountriesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_version.py) ---
            // def _domain_current_countries(self):
            // return ['|',
            //     ('country_id', '=', False),
            //     ('country_id', 'in', self.env.companies.country_id.ids),
            // ]
            */
            return default;
        }

        public async Task<HrVersion> GenerateWorkEntriesAsync(Guid id, HrVersionGenerateWorkEntriesRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def generate_work_entries(self, date_start, date_stop, force=False):
            // # Generate work entries between 2 dates (datetime.date)
            // # To correctly englobe the period, the start and end periods are converted
            // # using the calendar timezone.
            // assert not isinstance(date_start, datetime)
            // assert not isinstance(date_stop, datetime)
            // 
            // date_start = datetime.combine(fields.Datetime.to_datetime(date_start), datetime.min.time())
            // date_stop = datetime.combine(fields.Datetime.to_datetime(date_stop), datetime.max.time())
            // 
            // versions_by_company_tz = defaultdict(lambda: self.env['hr.version'])
            // for version in self:
            //     versions_by_company_tz[
            //         version.company_id,
            //         (version.resource_calendar_id or version.employee_id).tz,
            //     ] += version
            // utc = pytz.timezone('UTC')
            // new_work_entries = self.env['hr.work.entry']
            // for (company, version_tz), versions in versions_by_company_tz.items():
            //     tz = pytz.timezone(version_tz) if version_tz else utc
            //     date_start_tz = tz.localize(date_start).astimezone(utc).replace(tzinfo=None)
            //     date_stop_tz = tz.localize(date_stop).astimezone(utc).replace(tzinfo=None)
            //     new_work_entries += versions.with_user(SUPERUSER_ID).with_company(company)._generate_work_entries(
            //         date_start_tz, date_stop_tz, force=force)
            // return new_work_entries
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrVersion> GenerateWorkEntriesInternalAsync(object date_start, object date_stop, object force)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def _generate_work_entries(self, date_start, date_stop, force=False):
            // # Generate work entries between 2 dates (datetime.datetime)
            // # This method considers that the dates are correctly localized
            // # based on the target timezone
            // assert isinstance(date_start, datetime)
            // assert isinstance(date_stop, datetime)
            // self = self.with_context(tracking_disable=True)  # noqa: PLW0642
            // vals_list = []
            // self.write({'last_generation_date': fields.Date.today()})
            // 
            // intervals_to_generate = defaultdict(lambda: self.env['hr.version'])
            // # In case the date_generated_from == date_generated_to, move it to the date_start to
            // # avoid trying to generate several months/years of history for old versions for which
            // # we've never generated the work entries.
            // self.filtered(lambda c: c.date_generated_from == c.date_generated_to).write({
            //     'date_generated_from': date_start,
            //     'date_generated_to': date_start,
            // })
            // domain_to_nullify = Domain(False)
            // work_entry_null_vals = {field: False for field in self.env["hr.work.entry.regeneration.wizard"]._work_entry_fields_to_nullify()}
            // 
            // for tz, versions in self.grouped("tz").items():
            //     tz = pytz.timezone(tz) if tz else pytz.utc
            //     for version in versions:
            //         version_start = tz.localize(fields.Datetime.to_datetime(version.date_start)).astimezone(pytz.utc).replace(tzinfo=None)
            //         version_stop = tz.localize(datetime.combine(fields.Datetime.to_datetime(version.date_end or date_stop),
            //                                          datetime.max.time())).astimezone(pytz.utc).replace(tzinfo=None)
            //         if version_stop < date_start:
            //             continue
            //         if version_stop < date_stop:
            //             if version.date_generated_from != version.date_generated_to:
            //                 domain_to_nullify |= Domain([
            //                     ('version_id', '=', version.id),
            //                     ('date', '>', version_stop.astimezone(tz)),
            //                     ('date', '<=', date_stop.astimezone(tz)),
            //                     ('state', '!=', 'validated'),
            //                 ])
            //         if date_start > version_stop or date_stop < version_start:
            //             continue
            //         date_start_work_entries = max(date_start, version_start)
            //         date_stop_work_entries = min(date_stop, version_stop)
            //         if force:
            //             domain_to_nullify |= Domain([
            //                 ('version_id', '=', version.id),
            //                 ('date', '>=', date_start_work_entries.astimezone(tz).date()),
            //                 ('date', '<=', date_stop_work_entries.astimezone(tz).date()),
            //                 ('state', '!=', 'validated'),
            //             ])
            //             intervals_to_generate[date_start_work_entries, date_stop_work_entries] |= version
            //             continue
            // 
            //         # For each version, we found each interval we must generate
            //         # In some cases we do not want to set the generated dates beforehand, since attendance based work entries
            //         #  is more dynamic, we want to update the dates within the _get_work_entries_values function
            //         last_generated_from = min(version.date_generated_from, version_stop)
            //         if last_generated_from > date_start_work_entries:
            //             version.date_generated_from = date_start_work_entries
            //             intervals_to_generate[date_start_work_entries, last_generated_from] |= version
            // 
            //         last_generated_to = max(version.date_generated_to, version_start)
            //         if last_generated_to < date_stop_work_entries:
            //             version.date_generated_to = date_stop_work_entries
            //             intervals_to_generate[last_generated_to, date_stop_work_entries] |= version
            // 
            // for interval, versions in intervals_to_generate.items():
            //     date_from, date_to = interval
            //     vals_list.extend(versions._get_work_entries_values(date_from, date_to))
            // 
            // if domain_to_nullify != Domain.FALSE:
            //     work_entries_to_nullify = self.env['hr.work.entry'].search(domain_to_nullify)
            //     work_entries_to_nullify.write(work_entry_null_vals)
            // 
            // if not vals_list:
            //     return self.env['hr.work.entry']
            // 
            // vals_list = self._generate_work_entries_postprocess(vals_list)
            // return self.env['hr.work.entry'].create(vals_list)
            */
            return default;
        }

        protected async Task<HrVersion> GenerateWorkEntriesPostprocessAdaptToCalendarInternalAsync(object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def _generate_work_entries_postprocess_adapt_to_calendar(self, vals):
            // if 'work_entry_type_id' not in vals:
            //     return False
            // return self.env['hr.work.entry.type'].browse(vals['work_entry_type_id']).is_leave
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_version.py) ---
            // def _generate_work_entries_postprocess_adapt_to_calendar(self, vals):
            // res = super()._generate_work_entries_postprocess_adapt_to_calendar(vals)
            // return res or (not 'work_entry_type_id' not in vals and vals.get('leave_id'))
            */
            return default;
        }

        protected async Task<HrVersion> GenerateWorkEntriesPostprocessInternalAsync(object vals_list)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def _generate_work_entries_postprocess(self, vals_list):
            // # Convert date_start/date_stop to date/duration
            // # Split work entries over 2 days due to timezone conversion
            // # Regroup work entries of the same type
            // mapped_periods = defaultdict(lambda: defaultdict(lambda: self.env['hr.employee']))
            // cached_periods = defaultdict(float)
            // tz_by_version = {}
            // 
            // def _get_tz(version_id):
            //     if version_id in tz_by_version:
            //         return tz_by_version[version_id]
            //     version = self.env['hr.version'].browse(version_id)
            //     tz = version.resource_calendar_id.tz or version.employee_id.resource_calendar_id.tz or version.company_id.resource_calendar_id.tz
            //     if not tz:
            //         raise UserError(_('Missing timezone for work entries generation.'))
            //     tz = pytz.timezone(tz)
            //     tz_by_version[version_id] = tz
            //     return tz
            // 
            // new_vals_list = []
            // for vals in vals_list:
            //     new_vals = vals.copy()
            //     if not new_vals.get('date_start') or not new_vals.get('date_stop'):
            //         new_vals.pop('date_start', False)
            //         new_vals.pop('date_stop', False)
            //         if 'duration' not in new_vals or 'date' not in new_vals:
            //             raise UserError(_('Missing date or duration on work entry'))
            //         new_vals_list.append(new_vals)
            //         continue
            // 
            //     date_start_utc = new_vals['date_start'] if new_vals['date_start'].tzinfo else pytz.UTC.localize(new_vals['date_start'])
            //     date_stop_utc = new_vals['date_stop'] if new_vals['date_stop'].tzinfo else pytz.UTC.localize(new_vals['date_stop'])
            // 
            //     tz = _get_tz(new_vals['version_id'])
            //     local_start = date_start_utc.astimezone(tz)
            //     local_stop = date_stop_utc.astimezone(tz)
            // 
            //     # Handle multi-local-day spans
            //     current = local_start + timedelta(microseconds=1) if local_start.time() == datetime.max.time() else local_start
            //     while current < local_stop:
            //         next_local_midnight = tz.localize(datetime.combine(current.date() + timedelta(days=1), time.min) - timedelta(microseconds=1))
            //         segment_end = min(local_stop, next_local_midnight)
            // 
            //         partial_vals = new_vals.copy()
            // 
            //         # Convert partial segment back to UTC for consistency
            //         partial_vals['date_start'] = current.astimezone(pytz.UTC)
            //         partial_vals['date_stop'] = segment_end.astimezone(pytz.UTC)
            // 
            //         new_vals_list.append(partial_vals)
            // 
            //         current = segment_end + timedelta(microseconds=1)
            // 
            // vals_list = new_vals_list
            // 
            // for vals in vals_list:
            //     if not vals.get('date_start') or not vals.get('date_stop'):
            //         continue
            //     date_start = vals['date_start']
            //     date_stop = vals['date_stop']
            //     tz = _get_tz(vals['version_id'])
            //     if not self._generate_work_entries_postprocess_adapt_to_calendar(vals):
            //         vals['date'] = date_start.astimezone(tz).date()
            //         if 'duration' in vals:
            //             continue
            //         elif (date_start, date_stop) in cached_periods:
            //             vals['duration'] = cached_periods[date_start, date_stop]
            //         else:
            //             dt = date_stop - date_start
            //             duration = round(dt.total_seconds()) / 3600  # Number of hours
            //             cached_periods[date_start, date_stop] = duration
            //             vals['duration'] = duration
            //         continue
            //     version = self.env['hr.version'].browse(vals['version_id'])
            //     calendar = version.resource_calendar_id
            //     if not calendar:
            //         vals['date'] = date_start.astimezone(tz).date()
            //         vals['duration'] = 0.0
            //         continue
            //     employee = version.employee_id
            //     mapped_periods[date_start, date_stop][calendar] |= employee
            // 
            // # {(date_start, date_stop): {calendar: {'hours': foo}}}
            // mapped_version_data = defaultdict(lambda: defaultdict(lambda: {'hours': 0.0}))
            // for (date_start, date_stop), employees_by_calendar in mapped_periods.items():
            //     for calendar, employees in employees_by_calendar.items():
            //         mapped_version_data[date_start, date_stop][calendar] = employees._get_work_days_data_batch(
            //             date_start, date_stop, compute_leaves=False, calendar=calendar)
            // 
            // for vals in vals_list:
            //     if 'duration' not in vals:
            //         date_start = vals['date_start']
            //         date_stop = vals['date_stop']
            //         version = self.env['hr.version'].browse(vals['version_id'])
            //         calendar = version.resource_calendar_id
            //         employee = version.employee_id
            //         tz = _get_tz(vals['version_id'])
            //         vals['date'] = date_start.astimezone(tz).date()
            //         vals['duration'] = mapped_version_data[date_start, date_stop][calendar][employee.id]['hours'] if calendar else 0.0
            //     vals.pop('date_start', False)
            //     vals.pop('date_stop', False)
            // 
            // # Now merge similar work entries on the same day
            // merged_vals = {}
            // for vals in vals_list:
            //     if float_is_zero(vals['duration'], 3):
            //         continue
            //     key = (
            //         vals['date'],
            //         vals.get('work_entry_type_id', False),
            //         vals['employee_id'],
            //         vals['version_id'],
            //         vals.get('company_id', False),
            //     )
            //     if key in merged_vals:
            //         merged_vals[key]['duration'] += vals.get('duration', 0.0)
            //     else:
            //         merged_vals[key] = vals.copy()
            // return list(merged_vals.values())
            */
            return default;
        }

        protected async Task<HrVersion> GetAttendanceIntervalsInternalAsync(object start_dt, object end_dt)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def _get_attendance_intervals(self, start_dt, end_dt):
            // assert start_dt.tzinfo and end_dt.tzinfo, "function expects localized date"
            // # {resource: intervals}
            // employees_by_calendar = defaultdict(lambda: self.env['hr.employee'])
            // for version in self:
            //     if version.work_entry_source != 'calendar':
            //         continue
            //     employees_by_calendar[version.resource_calendar_id] |= version.employee_id
            // result = dict()
            // for calendar, employees in employees_by_calendar.items():
            //     if not calendar:
            //         for employee in employees:
            //             result.update({employee.resource_id.id: Intervals([(start_dt, end_dt, self.env['resource.calendar.attendance'])])})
            //     else:
            //         result.update(calendar._attendance_intervals_batch(
            //             start_dt,
            //             end_dt,
            //             resources=employees.resource_id,
            //             tz=pytz.timezone(calendar.tz) if calendar.tz else pytz.utc
            //         ))
            // return result
            */
            return default;
        }

        protected async Task<HrVersion> GetBypassingWorkEntryTypeCodesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def _get_bypassing_work_entry_type_codes(self):
            // return []
            */
            return default;
        }

        protected async Task<HrVersion> GetContractWageFieldInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _get_contract_wage_field(self):
            // self.ensure_one()
            // return 'wage'
            */
            return default;
        }

        protected async Task<HrVersion> GetContractWageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _get_contract_wage(self):
            // if not self:
            //     return 0
            // self.ensure_one()
            // return self[self._get_contract_wage_field()]
            */
            return default;
        }

        protected async Task<HrVersion> GetDefaultAddressIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _get_default_address_id(self):
            // address = self.env.company.partner_id.address_get(['default'])
            // return address['default'] if address else False
            */
            return default;
        }

        protected async Task<HrVersion> GetDefaultWorkEntryTypeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def _get_default_work_entry_type_id(self):
            // attendance = self.env.ref('hr_work_entry.work_entry_type_attendance', raise_if_not_found=False)
            // return attendance.id if attendance else False
            */
            return default;
        }

        protected async Task<HrVersion> GetDefaultWorkEntryTypeOvertimeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def _get_default_work_entry_type_overtime_id(self):
            // attendance = self.env.ref('hr_work_entry.work_entry_type_overtime', raise_if_not_found=False)
            // return attendance.id if attendance else False
            */
            return default;
        }

        protected async Task<HrVersion> GetFieldsThatRecomputeWeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def _get_fields_that_recompute_we(self):
            // # Returns the fields that should recompute the work entries
            // return ['resource_calendar_id', 'work_entry_source']
            */
            return default;
        }

        public async Task<HrVersion> GetFormviewActionAsync(Guid id, HrVersionGetFormviewActionRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def get_formview_action(self, access_uid=None):
            // """
            // Override this method in order to redirect many2one towards the right model
            //     - Contract template -> hr.version
            //     - Employee record -> hr.employee(.public) with version_id in context
            // """
            // res = super().get_formview_action(access_uid=access_uid)
            // context = res.get('context', {})
            // if self.employee_id:
            //     user = self.env.user
            //     if access_uid:
            //         user = self.env['res.users'].browse(access_uid)
            //     res['res_model'] = 'hr.employee' if user.has_group('hr.group_hr_user') else 'hr.employee.public'
            //     res['res_id'] = self.employee_id.id
            //     res['context'] = dict(context, version_id=self.id)
            // else:
            //     if not context.get('form_view_ref', False):
            //         res['context'] = dict(context, form_view_ref='hr.hr_contract_template_form_view')
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrVersion> GetHrResponsibleDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _get_hr_responsible_domain(self):
            // return "[('share', '=', False), ('company_ids', 'in', company_id), ('all_group_ids', 'in', %s)]" % self.env.ref('hr.group_hr_user').id
            */
            return default;
        }

        protected async Task<HrVersion> GetIntervalLeaveWorkEntryTypeInternalAsync(object interval, object leaves, object bypassing_codes)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def _get_interval_leave_work_entry_type(self, interval, leaves, bypassing_codes):
            // # returns the work entry time related to the leave that
            // # includes the whole interval.
            // # Overriden in hr_work_entry_holiday to select the
            // # global time off first (eg: Public Holiday > Home Working)
            // self.ensure_one()
            // for leave in leaves:
            //     if interval[0] >= leave[0] and interval[1] <= leave[1] and leave[2]:
            //         interval_start = interval[0].astimezone(pytz.utc).replace(tzinfo=None)
            //         interval_stop = interval[1].astimezone(pytz.utc).replace(tzinfo=None)
            //         return self._get_leave_work_entry_type_dates(leave[2], interval_start, interval_stop, self.employee_id)
            // return self.env.ref('hr_work_entry.work_entry_type_leave')
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_version.py) ---
            // def _get_interval_leave_work_entry_type(self, interval, leaves, bypassing_codes):
            // # returns the work entry time related to the leave that
            // # includes the whole interval.
            // # Overriden in hr_work_entry_holiday to select the
            // # global time off first (eg: Public Holiday > Home Working)
            // self.ensure_one()
            // if 'work_entry_type_id' in interval[2]:
            //     work_entry_types = interval[2].work_entry_type_id
            //     if work_entry_types and work_entry_types[:1].code in bypassing_codes:
            //         return work_entry_types[:1]
            // 
            // interval_start = interval[0].astimezone(pytz.utc).replace(tzinfo=None)
            // interval_stop = interval[1].astimezone(pytz.utc).replace(tzinfo=None)
            // including_rcleaves = [l[2] for l in leaves if l[2] and interval_start >= l[2].date_from and interval_stop <= l[2].date_to]
            // including_global_rcleaves = [l for l in including_rcleaves if not l.holiday_id]
            // including_holiday_rcleaves = [l for l in including_rcleaves if l.holiday_id]
            // rc_leave = False
            // 
            // # Example: In CP200: Long term sick > Public Holidays (which is global)
            // if bypassing_codes:
            //     bypassing_rc_leave = [l for l in including_holiday_rcleaves if l.holiday_id.holiday_status_id.work_entry_type_id.code in bypassing_codes]
            // else:
            //     bypassing_rc_leave = []
            // 
            // if bypassing_rc_leave:
            //     rc_leave = bypassing_rc_leave[0]
            // elif including_global_rcleaves:
            //     rc_leave = including_global_rcleaves[0]
            // elif including_holiday_rcleaves:
            //     rc_leave = including_holiday_rcleaves[0]
            // if rc_leave:
            //     return self._get_leave_work_entry_type_dates(rc_leave, interval_start, interval_stop, self.employee_id)
            // return self.env.ref('hr_work_entry.work_entry_type_leave')
            */
            return default;
        }

        protected async Task<HrVersion> GetIntervalWorkEntryTypeInternalAsync(object interval)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def _get_interval_work_entry_type(self, interval):
            // self.ensure_one()
            // if 'work_entry_type_id' in interval[2] and interval[2].work_entry_type_id[:1]:
            //     return interval[2].work_entry_type_id[:1]
            // return self.env['hr.work.entry.type'].browse(self._get_default_work_entry_type_id())
            */
            return default;
        }

        protected async Task<HrVersion> GetLeaveDomainInternalAsync(object start_dt, object end_dt)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def _get_leave_domain(self, start_dt, end_dt):
            // domain = Domain([
            //     ('resource_id', 'in', [False] + self.employee_id.resource_id.ids),
            //     ('date_from', '<=', end_dt.replace(tzinfo=None)),
            //     ('date_to', '>=', start_dt.replace(tzinfo=None)),
            //     ('company_id', 'in', [False] + self.env.companies.ids),
            // ])
            // return domain & self._get_sub_leave_domain()
            */
            return default;
        }

        protected async Task<HrVersion> GetLeaveWorkEntryTypeDatesInternalAsync(object leave, object date_from, object date_to, object employee)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def _get_leave_work_entry_type_dates(self, leave, date_from, date_to, employee):
            // return self._get_leave_work_entry_type(leave)
            */
            return default;
        }

        protected async Task<HrVersion> GetLeaveWorkEntryTypeInternalAsync(object leave)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def _get_leave_work_entry_type(self, leave):
            // return leave.work_entry_type_id
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_version.py) ---
            // def _get_leave_work_entry_type(self, leave):
            // if leave.holiday_id:
            //     return leave.holiday_id.holiday_status_id.work_entry_type_id
            // else:
            //     return leave.work_entry_type_id
            */
            return default;
        }

        protected async Task<HrVersion> GetLeavesFromValsInternalAsync(object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_version.py) ---
            // def _get_leaves_from_vals(self, vals):
            // domain = [
            //     ('state', '!=', 'refuse'),
            //     ('employee_id', 'in', vals['employee_id']),
            //     ('date_to', '>=', fields.Date.from_string(vals.get('contract_date_start', vals.get('date_version', fields.Date.today())))),
            //     ('resource_calendar_id', '!=', vals.get('resource_calendar_id')),
            // ]
            // if vals.get('contract_date_end'):
            //     domain = Domain.AND([domain, [('date_from', '<=', fields.Date.from_string(vals['contract_date_end']))]])
            // return self.env['hr.leave'].search(domain)
            */
            return default;
        }

        protected async Task<HrVersion> GetLeavesInternalAsync(object extra_domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_version.py) ---
            // def _get_leaves(self, extra_domain=None):
            // domain = [
            //     ('state', '!=', 'refuse'),
            //     ('employee_id', 'in', self.mapped('employee_id.id')),
            //     ('date_from', '<=', max(end or date.max for end in self.sudo().mapped('contract_date_end'))),
            //     ('date_to', '>=', min(self.sudo().mapped('contract_date_start'))),
            // ]
            // if extra_domain:
            //     domain = Domain.AND([domain, extra_domain])
            // return self.env['hr.leave'].search(domain)
            */
            return default;
        }

        protected async Task<HrVersion> GetLunchIntervalsInternalAsync(object start_dt, object end_dt)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def _get_lunch_intervals(self, start_dt, end_dt):
            // # {resource: intervals}
            // employees_by_calendar = defaultdict(lambda: self.env['hr.employee'])
            // for version in self:
            //     employees_by_calendar[version.resource_calendar_id] |= version.employee_id
            // result = {}
            // for calendar, employees in employees_by_calendar.items():
            //     if not calendar:
            //         continue
            //     result.update(calendar._attendance_intervals_batch(
            //         start_dt,
            //         end_dt,
            //         resources=employees.resource_id,
            //         tz=pytz.timezone(calendar.tz),
            //         lunch=True,
            //     ))
            // return result
            */
            return default;
        }

        protected async Task<HrVersion> GetMaritalStatusSelectionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _get_marital_status_selection(self):
            // return [
            //     ('single', self.env._('Single')),
            //     ('married', self.env._('Married')),
            //     ('cohabitant', self.env._('Legal Cohabitant')),
            //     ('widower', self.env._('Widower')),
            //     ('divorced', self.env._('Divorced')),
            // ]
            */
            return default;
        }

        protected async Task<HrVersion> GetMoreValsAttendanceIntervalInternalAsync(object interval)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def _get_more_vals_attendance_interval(self, interval):
            // return []
            */
            return default;
        }

        protected async Task<HrVersion> GetMoreValsLeaveIntervalInternalAsync(object interval, object leaves)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def _get_more_vals_leave_interval(self, interval, leaves):
            // return []
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_version.py) ---
            // def _get_more_vals_leave_interval(self, interval, leaves):
            // result = super()._get_more_vals_leave_interval(interval, leaves)
            // for leave in leaves:
            //     if interval[0] >= leave[0] and interval[1] <= leave[1]:
            //         if leave[2].holiday_id.id:
            //             result.append(('leave_id', leave[2].holiday_id.id))
            //             break
            // return result
            */
            return default;
        }

        protected async Task<HrVersion> GetNormalizedWageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _get_normalized_wage(self):
            // """ This method is overridden in hr_payroll, as without that module, nothing allows to know
            // there's no way to determine the employee's pay frequency.
            // """
            // wage = self._get_contract_wage()
            // # without payroll installed, we suppose that the employee with a specific schedule has a monthly salary
            // if self.resource_calendar_id:
            //     if not self.resource_calendar_id.hours_per_week:
            //         return 0
            //     return wage * 12 / 52 / self.resource_calendar_id.hours_per_week
            // # without any calendar, the employee has a fully flexible schedule and is supposedly working on an hourly wage
            // return wage
            */
            return default;
        }

        protected async Task<HrVersion> GetRealAttendanceWorkEntryValsInternalAsync(object intervals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def _get_real_attendance_work_entry_vals(self, intervals):
            // self.ensure_one()
            // vals = []
            // employee = self.employee_id
            // for interval in intervals:
            //     work_entry_type = self._get_interval_work_entry_type(interval)
            //     # All benefits generated here are using datetimes converted from the employee's timezone
            //     vals += [dict([
            //               ('name', "%s: %s" % (work_entry_type.name, employee.name)),
            //               ('date_start', interval[0].astimezone(pytz.utc).replace(tzinfo=None)),
            //               ('date_stop', interval[1].astimezone(pytz.utc).replace(tzinfo=None)),
            //               ('work_entry_type_id', work_entry_type.id),
            //               ('employee_id', employee.id),
            //               ('version_id', self.id),
            //               ('company_id', self.company_id.id),
            //           ] + self._get_more_vals_attendance_interval(interval))]
            // return vals
            */
            return default;
        }

        protected async Task<HrVersion> GetRealAttendancesInternalAsync(object attendances, object leaves, object worked_leaves)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def _get_real_attendances(self, attendances, leaves, worked_leaves):
            // return attendances - leaves - worked_leaves
            */
            return default;
        }

        protected async Task<HrVersion> GetResourceCalendarLeavesInternalAsync(object start_dt, object end_dt)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def _get_resource_calendar_leaves(self, start_dt, end_dt):
            // return self.env['resource.calendar.leaves'].search(self._get_leave_domain(start_dt, end_dt))
            */
            return default;
        }

        protected async Task<HrVersion> GetSalaryCostsFactorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _get_salary_costs_factor(self):
            // self.ensure_one()
            // return 12.0
            */
            return default;
        }

        protected async Task<HrVersion> GetSubLeaveDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def _get_sub_leave_domain(self):
            // return Domain('calendar_id', 'in', [False] + self.resource_calendar_id.ids)
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_version.py) ---
            // def _get_sub_leave_domain(self):
            // # see https://github.com/odoo/enterprise/pull/15091
            // return super()._get_sub_leave_domain() | Domain('holiday_id.employee_id', 'in', self.employee_id.ids)
            */
            return default;
        }

        protected async Task<HrVersion> GetTzInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _get_tz(self):
            // if self.resource_calendar_id and self.resource_calendar_id.tz:
            //     return self.resource_calendar_id.tz
            // else:
            //     return self.tz
            */
            return default;
        }

        protected async Task<HrVersion> GetValidEmployeeForUserInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _get_valid_employee_for_user(self):
            // user = self.env.user
            // # retrieve the employee of the current active company for the user
            // employee = user.employee_id
            // if not employee:
            //     # search for all employees as superadmin to not get blocked by multi-company rules
            //     user_employees = user.employee_id.sudo().search([
            //         ('user_id', '=', user.id)
            //     ])
            //     # the default company employee is most likely the correct one, but fallback to the first if not available
            //     employee = user_employees.filtered(lambda r: r.company_id == user.company_id) or user_employees[:1]
            // return employee
            */
            return default;
        }

        protected async Task<HrVersion> GetValidLeaveIntervalsInternalAsync(object attendances, object interval)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def _get_valid_leave_intervals(self, attendances, interval):
            // self.ensure_one()
            // return [interval]
            */
            return default;
        }

        public async Task<HrVersion> GetValuesFromContractTemplateAsync(Guid id, HrVersionGetValuesFromContractTemplateRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def get_values_from_contract_template(self, contract_template_id):
            // if not contract_template_id:
            //     return {}
            // company = contract_template_id.company_id or self.env.company
            // whitelist = self.with_company(company)._get_whitelist_fields_from_template()
            // contract_template_vals = contract_template_id.copy_data()[0]
            // return {
            //     field: value
            //         for field, value in contract_template_vals.items()
            //         if field in whitelist and not self.env['hr.version']._fields[field].related
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrVersion> GetVersionWorkEntriesValuesInternalAsync(object date_start, object date_stop)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def _get_version_work_entries_values(self, date_start, date_stop):
            // start_dt = pytz.utc.localize(date_start) if not date_start.tzinfo else date_start
            // end_dt = pytz.utc.localize(date_stop) if not date_stop.tzinfo else date_stop
            // version_vals = []
            // bypassing_work_entry_type_codes = self._get_bypassing_work_entry_type_codes()
            // 
            // attendances_by_resource = self.sudo()._get_attendance_intervals(start_dt, end_dt)
            // 
            // resource_calendar_leaves = self._get_resource_calendar_leaves(start_dt, end_dt)
            // # {resource: resource_calendar_leaves}
            // leaves_by_resource = defaultdict(lambda: self.env['resource.calendar.leaves'])
            // for leave in resource_calendar_leaves:
            //     leaves_by_resource[leave.resource_id.id] |= leave
            // 
            // tz_dates = {}
            // for version in self:
            //     employee = version.employee_id
            //     calendar = version.resource_calendar_id
            //     resource = employee.resource_id
            //     # if the version is fully flexible, we refer to the employee's timezone
            //     tz = pytz.timezone(resource.tz) if version._is_fully_flexible() else pytz.timezone(calendar.tz)
            //     attendances = attendances_by_resource[resource.id]
            // 
            //     # Other calendars: In case the employee has declared time off in another calendar
            //     # Example: Take a time off, then a credit time.
            //     resources_list = [self.env['resource.resource'], resource]
            //     leave_result = defaultdict(list)
            //     work_result = defaultdict(list)
            //     for leave in itertools.chain(leaves_by_resource[False], leaves_by_resource[resource.id]):
            //         for resource in resources_list:
            //             # Global time off is not for this calendar, can happen with multiple calendars in self
            //             if resource and leave.calendar_id and leave.calendar_id != calendar and not leave.resource_id:
            //                 continue
            //             tz = tz if tz else pytz.timezone((resource or version).tz)
            //             if (tz, start_dt) in tz_dates:
            //                 start = tz_dates[tz, start_dt]
            //             else:
            //                 start = start_dt.astimezone(tz)
            //                 tz_dates[tz, start_dt] = start
            //             if (tz, end_dt) in tz_dates:
            //                 end = tz_dates[tz, end_dt]
            //             else:
            //                 end = end_dt.astimezone(tz)
            //                 tz_dates[tz, end_dt] = end
            //             dt0 = leave.date_from.astimezone(tz)
            //             dt1 = leave.date_to.astimezone(tz)
            //             leave_start_dt = max(start, dt0)
            //             leave_end_dt = min(end, dt1)
            //             leave_interval = (leave_start_dt, leave_end_dt, leave)
            //             leave_interval = version._get_valid_leave_intervals(attendances, leave_interval)
            //             if leave_interval:
            //                 if leave.time_type == 'leave':
            //                     leave_result[resource.id] += leave_interval
            //                 else:
            //                     work_result[resource.id] += leave_interval
            //     mapped_leaves = {r.id: Intervals(leave_result[r.id], keep_distinct=True) for r in resources_list}
            //     mapped_worked_leaves = {r.id: Intervals(work_result[r.id], keep_distinct=True) for r in resources_list}
            // 
            //     leaves = mapped_leaves[resource.id]
            //     worked_leaves = mapped_worked_leaves[resource.id]
            // 
            //     real_attendances = attendances - leaves - worked_leaves
            //     if not calendar:
            //         real_leaves = leaves
            //         real_worked_leaves = worked_leaves
            //     elif calendar.flexible_hours:
            //         # Flexible hours case
            //         # For multi day leaves, we want them to occupy the virtual working schedule 12 AM to average working days
            //         # For one day leaves, we want them to occupy exactly the time it was taken, for a time off in days
            //         # this will mean the virtual schedule and for time off in hours the chosen hours
            //         one_day_leaves = Intervals([l for l in leaves if l[0].date() == l[1].date()], keep_distinct=True)
            //         one_day_worked_leaves = Intervals([l for l in worked_leaves if l[0].date() == l[1].date()], keep_distinct=True)
            //         multi_day_leaves = leaves - one_day_leaves
            //         multi_day_worked_leaves = worked_leaves - one_day_worked_leaves
            //         static_attendances = calendar._attendance_intervals_batch(
            //             start_dt, end_dt, resources=resource, tz=tz)[resource.id]
            //         real_leaves = (static_attendances & multi_day_leaves) | one_day_leaves
            //         real_worked_leaves = (static_attendances & multi_day_worked_leaves) | one_day_worked_leaves
            // 
            //     elif version.has_static_work_entries() or not leaves:
            //         # Empty leaves means empty real_leaves
            //         real_worked_leaves = attendances - real_attendances - leaves
            //         real_leaves = attendances - real_attendances - real_worked_leaves
            //     else:
            //         # In the case of attendance based versions use regular attendances to generate leave intervals
            //         static_attendances = calendar._attendance_intervals_batch(
            //             start_dt, end_dt, resources=resource, tz=tz)[resource.id]
            //         real_leaves = static_attendances & leaves
            //         real_worked_leaves = static_attendances & worked_leaves
            // 
            //     real_attendances = self._get_real_attendances(attendances, leaves, worked_leaves)
            // 
            //     if not version.has_static_work_entries():
            //         # An attendance based version might have an invalid planning, by definition it may not happen with
            //         # static work entries.
            //         # Creating overlapping slots for example might lead to a single work entry.
            //         # In that case we still create both work entries to indicate a problem (conflicting W E).
            //         split_attendances = []
            //         for attendance in real_attendances:
            //             if attendance[2] and len(attendance[2]) > 1:
            //                 split_attendances += [(attendance[0], attendance[1], a) for a in attendance[2]]
            //             else:
            //                 split_attendances += [attendance]
            //         real_attendances = split_attendances
            // 
            //     # A leave period can be linked to several resource.calendar.leave
            //     split_leaves = []
            //     for leave_interval in leaves:
            //         if leave_interval[2] and len(leave_interval[2]) > 1:
            //             split_leaves += [(leave_interval[0], leave_interval[1], l) for l in leave_interval[2]]
            //         else:
            //             split_leaves += [(leave_interval[0], leave_interval[1], leave_interval[2])]
            //     leaves = split_leaves
            // 
            //     split_worked_leaves = []
            //     for worked_leave_interval in real_worked_leaves:
            //         if worked_leave_interval[2] and len(worked_leave_interval[2]) > 1:
            //             split_worked_leaves += [(worked_leave_interval[0], worked_leave_interval[1], l) for l in worked_leave_interval[2]]
            //         else:
            //             split_worked_leaves += [(worked_leave_interval[0], worked_leave_interval[1], worked_leave_interval[2])]
            //     real_worked_leaves = split_worked_leaves
            // 
            //     # Attendances
            //     version_vals += version._get_real_attendance_work_entry_vals(real_attendances)
            // 
            //     for interval in real_worked_leaves:
            //         work_entry_type = version._get_interval_leave_work_entry_type(interval, worked_leaves, bypassing_work_entry_type_codes)
            //         # All benefits generated here are using datetimes converted from the employee's timezone
            //         version_vals += [dict([
            //             ('name', "%s: %s" % (work_entry_type.name, employee.name)),
            //             ('date_start', interval[0].astimezone(pytz.utc).replace(tzinfo=None)),
            //             ('date_stop', interval[1].astimezone(pytz.utc).replace(tzinfo=None)),
            //             ('work_entry_type_id', work_entry_type.id),
            //             ('employee_id', employee.id),
            //             ('version_id', version.id),
            //             ('company_id', version.company_id.id),
            //             ('state', 'draft'),
            //         ] + version._get_more_vals_leave_interval(interval, worked_leaves))]
            // 
            //     leaves_over_attendances = Intervals(leaves, keep_distinct=True) & real_leaves
            //     for interval in real_leaves:
            //         # Could happen when a leave is configured on the interface on a day for which the
            //         # employee is not supposed to work, i.e. no attendance_ids on the calendar.
            //         # In that case, do try to generate an empty work entry, as this would raise a
            //         # sql constraint error
            //         if interval[0] == interval[1]:  # if start == stop
            //             continue
            //         leaves_over_interval = [l for l in leaves_over_attendances if l[0] >= interval[0] and l[1] <= interval[1]]
            //         for leave_interval in [(l[0], l[1], interval[2]) for l in leaves_over_interval]:
            //             leave_entry_type = version._get_interval_leave_work_entry_type(leave_interval, leaves, bypassing_work_entry_type_codes)
            //             interval_leaves = [leave for leave in leaves if leave[2].work_entry_type_id.id == leave_entry_type.id]
            //             if not interval_leaves:
            //                 # Maybe the computed leave type is not found. In that case, we use all leaves
            //                 interval_leaves = leaves
            //             interval_start = leave_interval[0].astimezone(pytz.utc).replace(tzinfo=None)
            //             interval_stop = leave_interval[1].astimezone(pytz.utc).replace(tzinfo=None)
            //             version_vals += [dict([
            //                 ('name', "%s%s" % (leave_entry_type.name + ": " if leave_entry_type else "", employee.name)),
            //                 ('date_start', interval_start),
            //                 ('date_stop', interval_stop),
            //                 ('work_entry_type_id', leave_entry_type.id),
            //                 ('employee_id', employee.id),
            //                 ('company_id', version.company_id.id),
            //                 ('version_id', version.id),
            //             ] + version._get_more_vals_leave_interval(interval, interval_leaves))]
            // return version_vals
            */
            return default;
        }

        protected async Task<HrVersion> GetVersionsByEmployeeAndDateInternalAsync(object employee_dates)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_version.py) ---
            // def _get_versions_by_employee_and_date(self, employee_dates):
            // # for `employee_dates` a dict[employee] -> dates
            // # Generate a 2 level dict[employee][date] -> version
            // employees = self.env['hr.employee'].union(*employee_dates.keys())
            // all_dates = [date for dates in employee_dates.values() for date in dates]
            // if not all_dates:
            //     return {}
            // date_to = max(all_dates)
            // all_versions = self.env['hr.version'].search([
            //     ('employee_id', 'in', employees.ids),
            //     ('date_version', '<=', date_to),
            //     # note: no check on date_from because we don't store the version date end
            // ])
            // versions_by_employee = all_versions.grouped('employee_id')
            // version_by_employee_and_date = {employee: {} for employee in employees}
            // 
            // for employee, dates in employee_dates.items():
            //     if not (versions := versions_by_employee.get(employee)):
            //         continue
            //     version_index = 0
            //     for date in sorted(dates):
            //         if version_index + 1 < len(versions) and date >= versions[version_index + 1].date_version:
            //             version_index += 1
            //         version_by_employee_and_date[employee][date] = versions[version_index]
            // return version_by_employee_and_date
            */
            return default;
        }

        protected async Task<HrVersion> GetWhitelistFieldsFromTemplateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _get_whitelist_fields_from_template(self):
            // # Add here any field that you want to copy from a contract template
            // # Those fields should have tracking=True in hr.version to see the change
            // return ['job_id', 'department_id', 'contract_type_id', 'structure_type_id', 'wage', 'resource_calendar_id', 'hr_responsible_id']
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def _get_whitelist_fields_from_template(self):
            // return super()._get_whitelist_fields_from_template() + ['work_entry_source']
            */
            return default;
        }

        protected async Task<HrVersion> GetWorkEntriesValuesInternalAsync(object date_start, object date_stop)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def _get_work_entries_values(self, date_start, date_stop):
            // """
            // Generate a work_entries list between date_start and date_stop for one version.
            // :return: list of dictionnary.
            // """
            // if isinstance(date_start, datetime):
            //     version_vals = self._get_version_work_entries_values(date_start, date_stop)
            // else:
            //     version_vals = []
            //     versions_by_tz = defaultdict(lambda: self.env['hr.version'])
            //     for version in self:
            //         versions_by_tz[version.resource_calendar_id.tz] += version
            //     for version_tz, versions in versions_by_tz.items():
            //         tz = pytz.timezone(version_tz) if version_tz else pytz.utc
            //         version_vals += versions._get_version_work_entries_values(
            //             tz.localize(date_start),
            //             tz.localize(date_stop))
            // 
            // # {version_id: ([dates_start], [dates_stop])}
            // mapped_version_dates = defaultdict(lambda: ([], []))
            // for x in version_vals:
            //     mapped_version_dates[x['version_id']][0].append(x['date_start'])
            //     mapped_version_dates[x['version_id']][1].append(x['date_stop'])
            // 
            // for version in self:
            //     # If we generate work_entries which exceeds date_start or date_stop, we change boundaries on version
            //     if version_vals:
            //         # Handle empty work entries for certain versions, could happen on an attendance based version
            //         # NOTE: this does not handle date_stop or date_start not being present in vals
            //         dates_stop = mapped_version_dates[version.id][1]
            //         if dates_stop:
            //             date_stop_max = max(dates_stop)
            //             if date_stop_max > version.date_generated_to:
            //                 version.date_generated_to = date_stop_max
            // 
            //         dates_start = mapped_version_dates[version.id][0]
            //         if dates_start:
            //             date_start_min = min(dates_start)
            //             if date_start_min < version.date_generated_from:
            //                 version.date_generated_from = date_start_min
            // 
            // return version_vals
            */
            return default;
        }

        public async Task<HrVersion> HasStaticWorkEntriesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def has_static_work_entries(self):
            // # Static work entries as in the same are to be generated each month
            // # Useful to differentiate attendance based versions from regular ones
            // self.ensure_one()
            // return self.work_entry_source == 'calendar'
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrVersion> InverseJobTitleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _inverse_job_title(self):
            // for version in self:
            //     version.is_custom_job_title = version.job_title != version.job_id.name
            */
            return default;
        }

        protected async Task<HrVersion> InverseKmHomeWorkInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _inverse_km_home_work(self):
            // for version in self:
            //     version.distance_home_work = version.km_home_work / 1.609 if version.distance_home_work_unit == "miles" else version.km_home_work
            */
            return default;
        }

        protected async Task<HrVersion> InverseResourceCalendarIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _inverse_resource_calendar_id(self):
            // for employee, versions in self.grouped('employee_id').items():
            //     current_version = employee.current_version_id
            //     for version in versions:
            //         if version == current_version and employee.resource_id.calendar_id != version.resource_calendar_id:
            //             employee.resource_id.calendar_id = version.resource_calendar_id
            */
            return default;
        }

        protected async Task<HrVersion> IsFullyFlexibleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _is_fully_flexible(self):
            // """ return True if the version has a fully flexible working calendar """
            // self.ensure_one()
            // return not self.resource_calendar_id
            */
            return default;
        }

        protected async Task<HrVersion> IsInContractInternalAsync(object date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _is_in_contract(self, date=fields.Date.today()):
            // # Return True if the employee is in contract on a given date
            // if not self.contract_date_start:
            //     return False
            // return self.date_start <= date and (not self.date_end or self.date_end >= date)
            */
            return default;
        }

        protected async Task<HrVersion> IsOverlappingPeriodInternalAsync(object date_from, object date_to)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _is_overlapping_period(self, date_from, date_to):
            // """
            // Return True if the employee is at least in contract one day during the period given
            // :param date date_from: the start of the period
            // :param date date_to: the stop of the period
            // """
            // if not (self.contract_date_start and date_from and date_to):
            //     return False
            // period_start = date_from or date.min
            // period_end = date_to or date.max
            // contract_end = self.date_end or date.max
            // return period_start <= contract_end and self.date_start <= period_end
            */
            return default;
        }

        protected async Task<HrVersion> IsStructFromCountryInternalAsync(object country_code)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _is_struct_from_country(self, country_code):
            // self.ensure_one()
            // self_sudo = self.sudo()
            // return self_sudo.structure_type_id and self_sudo.structure_type_id.country_id.code == country_code
            */
            return default;
        }

        public async Task<HrVersion> OpenVersionAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def action_open_version(self):
            // self.ensure_one()
            // 
            // return {
            //     'type': "ir.actions.act_window",
            //     'res_model': "hr.employee",
            //     'res_id': self.employee_id.id,
            //     'views': [[False, "form"]],
            //     'target': "current",
            //     'context': {
            //         'version_id': self.id,
            //     },
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrVersion> PopulateAllNewLeaveValsFromSplitLeaveInternalAsync(object all_new_leave_origin, object all_new_leave_vals, object overlapping_contracts, object leave, object leaves_state)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_version.py) ---
            // def _populate_all_new_leave_vals_from_split_leave(self, all_new_leave_origin, all_new_leave_vals, overlapping_contracts, leave, leaves_state):
            // for overlapping_contract in overlapping_contracts:
            //     new_request_date_from = max(leave.request_date_from, overlapping_contract.contract_date_start)
            //     new_request_date_to = min(leave.request_date_to, overlapping_contract.contract_date_end or date.max)
            //     new_leave_vals = leave.copy_data({
            //         'request_date_from': new_request_date_from,
            //         'request_date_to': new_request_date_to,
            //         'state': leaves_state[leave.id],
            //     })[0]
            //     new_leave = self.env['hr.leave'].new(new_leave_vals)
            //     new_leave._compute_date_from_to()
            //     new_leave._compute_duration()
            //     # Could happen for part-time contract, that time off is not necessary
            //     # anymore.
            //     if new_leave.date_from < new_leave.date_to:
            //         all_new_leave_origin.append(leave)
            //         all_new_leave_vals.append(new_leave._convert_to_write(new_leave._cache))
            // return all_new_leave_origin, all_new_leave_vals
            */
            return default;
        }

        protected async Task<HrVersion> RecomputeWorkEntriesInternalAsync(object date_from, object date_to)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def _recompute_work_entries(self, date_from, date_to):
            // self.ensure_one()
            // if self.employee_id:
            //     wizard = self.env['hr.work.entry.regeneration.wizard'].create({
            //         'employee_ids': [Command.set(self.employee_id.ids)],
            //         'date_from': date_from,
            //         'date_to': date_to,
            //     })
            //     wizard.with_context(work_entry_skip_validation=True, active_test=False).regenerate_work_entries()
            */
            return default;
        }

        protected async Task<HrVersion> RefuseLeaveInternalAsync(object leave, object leaves_state)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_version.py) ---
            // def _refuse_leave(self, leave, leaves_state):
            // if leave.id not in leaves_state:
            //     leaves_state[leave.id] = leave.state
            // if leave.state != 'refuse':
            //     leave.action_refuse()
            // return leaves_state
            */
            return default;
        }

        protected async Task<HrVersion> RemoveWorkEntriesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def _remove_work_entries(self):
            // ''' Remove all work_entries that are outside contract period (function used after writing new start or/and end date) '''
            // all_we_to_unlink = self.env['hr.work.entry']
            // for version in self:
            //     date_start = fields.Datetime.to_datetime(version.date_start)
            //     if version.date_generated_from < date_start:
            //         we_to_remove = self.env['hr.work.entry'].search([('date', '<', date_start), ('version_id', '=', version.id)])
            //         if we_to_remove:
            //             version.date_generated_from = date_start
            //             all_we_to_unlink |= we_to_remove
            //     if not version.date_end:
            //         continue
            //     date_end = datetime.combine(version.date_end, datetime.max.time())
            //     if version.date_generated_to > date_end:
            //         we_to_remove = self.env['hr.work.entry'].search([('date', '>', date_end), ('version_id', '=', version.id)])
            //         if we_to_remove:
            //             version.date_generated_to = date_end
            //             all_we_to_unlink |= we_to_remove
            // all_we_to_unlink.unlink()
            */
            return default;
        }

        protected async Task<HrVersion> SearchEndDateInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _search_end_date(self, operator, value):
            // return [('contract_date_end', operator, value)]
            */
            return default;
        }

        protected async Task<HrVersion> SearchPartOfDepartmentInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _search_part_of_department(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // 
            // user_employee = self._get_valid_employee_for_user()
            // if not user_employee.department_id:
            //     return [('id', 'in', user_employee.ids)]
            // return [('department_id', 'child_of', user_employee.department_id.ids)]
            */
            return default;
        }

        protected async Task<HrVersion> SearchStartDateInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _search_start_date(self, operator, value):
            // return [('contract_date_start', operator, value)]
            */
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def unlink(self):
            // self._cancel_work_entries()
            // return super().unlink()
            */
            return await base.UnlinkAsync(ids);
        }

        protected async Task<HrVersion> UnlinkExceptLastVersionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def _unlink_except_last_version(self):
            // for employee_id, versions in self.grouped('employee_id').items():
            //     if employee_id.version_ids == versions:
            //         raise ValidationError(
            //             self.env._('Employee %s must always have at least one active version.') % employee_id.name
            //         )
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, HrVersion entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_version.py) ---
            // def write(self, vals):
            // # Employee Versions Validation
            // if 'employee_id' in vals:
            //     if self.filtered(lambda v: v.employee_id and v.employee_id.version_ids <= self and vals['employee_id'] != v.employee_id.id):
            //         raise ValidationError(self.env._("Cannot unassign all the active versions of an employee."))
            // if 'active' in vals and not vals['active']:
            //     if self.filtered(lambda v: v.employee_id and v.employee_id.version_ids <= self):
            //         raise ValidationError(self.env._("Cannot archive all the active versions of an employee."))
            // 
            // if self.env.context.get('sync_contract_dates') or ("contract_date_start" not in vals and "contract_date_end" not in vals):
            //     return super().write(vals)
            // 
            // for versions_by_employee in self.grouped('employee_id').values():
            //     if len(versions_by_employee.grouped('contract_date_start').keys()) > 1:
            //         raise ValidationError(self.env._("Cannot modify multiple versions contract dates with different contracts at once."))
            // 
            // multiple_versions = self
            // if vals.get("contract_date_start"):
            //     unique_versions = multiple_versions.filtered(lambda v: len(v.employee_id.version_ids) == 1)
            //     multiple_versions -= unique_versions
            //     if len(unique_versions):
            //         unique_versions.with_context(sync_contract_dates=True).write({
            //             **vals,
            //             "date_version": vals["contract_date_start"]
            //         })
            // 
            // if not any(multiple_versions.mapped('contract_date_start')):
            //     return super(HrVersion, multiple_versions).write(vals)
            // 
            // new_vals = {
            //     f_name: f_value
            //     for f_name, f_value in vals.items()
            //     if (f_name != 'contract_date_start' or not f_value) and f_name != 'contract_date_end'
            // }
            // for employee, versions in multiple_versions.grouped('employee_id').items():
            // 
            //     dates_vals = {}
            //     first_version = next(iter(versions), versions)
            // 
            //     if "contract_date_start" in vals:
            //         dates_vals["contract_date_start"] = fields.Date.to_date(vals.get('contract_date_start'))
            //     else:
            //         dates_vals["contract_date_start"] = first_version.contract_date_start
            //     if "contract_date_end" in vals:
            //         dates_vals["contract_date_end"] = fields.Date.to_date(vals.get('contract_date_end'))
            //     else:
            //         dates_vals["contract_date_end"] = first_version.contract_date_end
            // 
            //     if first_version.contract_date_start:
            //         versions_to_sync = employee._get_contract_versions(
            //             date_start=first_version.contract_date_start,
            //             date_end=first_version.contract_date_end,
            //         )
            //         all_versions_to_sync = self.env['hr.version']
            //         for contract_versions in versions_to_sync.values():
            //             all_versions_to_sync |= next(iter(contract_versions.values()))
            // 
            //         if all_versions_to_sync:
            //             all_versions_to_sync.with_context(sync_contract_dates=True).write(dates_vals)
            // 
            //     else:
            //         versions.with_context(sync_contract_dates=True).write(dates_vals)
            // 
            // return super(HrVersion, multiple_versions).write(new_vals)
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_version.py) ---
            // def write(self, vals):
            // specific_contracts = self.env['hr.version']
            // if any(field in vals for field in ['contract_date_start', 'contract_date_end', 'date_version', 'resource_calendar_id']):
            //     all_new_leave_origin = []
            //     all_new_leave_vals = []
            //     leaves_state = {}
            //     try:
            //         for contract in self:
            //             resource_calendar_id = vals.get('resource_calendar_id', contract.resource_calendar_id.id)
            //             extra_domain = [('resource_calendar_id', '!=', resource_calendar_id)] if resource_calendar_id else None
            //             leaves = contract._get_leaves(
            //                 extra_domain=extra_domain
            //             )
            //             for leave in leaves:
            //                 overlapping_contracts = self._check_overlapping_contract(leave)
            //                 if not overlapping_contracts:
            //                     continue
            //                 leaves_state = self._refuse_leave(leave, leaves_state)
            //                 super(HrVersion, contract).write(vals)
            //                 specific_contracts += contract
            //                 all_new_leave_origin, all_new_leave_vals = self._populate_all_new_leave_vals_from_split_leave(
            //                     all_new_leave_origin, all_new_leave_vals, overlapping_contracts, leave, leaves_state)
            //         if all_new_leave_vals:
            //             self._create_all_new_leave(all_new_leave_origin, all_new_leave_vals)
            //     except ValidationError:
            //         # In case a validation error is thrown due to holiday creation with the new resource calendar (which can
            //         # increase their duration), we catch this error to display a more meaningful error message.
            //         raise ValidationError(self.env._("Changing the contract on this employee changes their working schedule in a period "
            //                                 "they already took leaves. Changing this working schedule changes the duration of "
            //                                 "these leaves in such a way the employee no longer has the required allocation for "
            //                                 "them. Please review these leaves and/or allocations before changing the contract."))
            // return super(HrVersion, self - specific_contracts).write(vals)
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py) ---
            // def write(self, vals):
            // result = super().write(vals)
            // if self.env.context.get('salary_simulation'):
            //     return result
            // if vals.get('contract_date_end') or vals.get('contract_date_start') or vals.get('date_version'):
            //     self.sudo()._remove_work_entries()
            // dependent_fields = self._get_fields_that_recompute_we()
            // if any(key in dependent_fields for key in vals):
            //     for version_sudo in self.sudo():
            //         date_from = max(version_sudo.date_start, version_sudo.date_generated_from.date())
            //         date_to = min(version_sudo.date_end or date.max, version_sudo.date_generated_to.date())
            //         if date_from != date_to and self.employee_id:
            //             version_sudo._recompute_work_entries(date_from, date_to)
            // return result
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}