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
    [Module("HrContractModule", Category = "HumanResources", Depends = new[] { "hr" })]
    public class HrContractAppService : GenericApplicationService<HrContract>, IHrContractAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        public HrContractAppService(IRepository<HrContract, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        protected async Task<HrContract> AssignOpenContractInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py) ---
            // def _assign_open_contract(self):
            // for contract in self:
            //     vals = contract._get_employee_vals_to_update()
            //     contract.employee_id.sudo().write(vals)
            */
            return default;
        }

        protected async Task<HrContract> CancelWorkEntriesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py) ---
            // def _cancel_work_entries(self):
            // if not self:
            //     return
            // domain = [('state', '!=', 'validated')]
            // for contract in self:
            //     date_start = fields.Datetime.to_datetime(contract.date_start)
            //     contract_domain = [
            //         ('contract_id', '=', contract.id),
            //         ('date_start', '>=', date_start),
            //     ]
            //     if contract.date_end:
            //         date_end = datetime.combine(contract.date_end, datetime.max.time())
            //         contract_domain += [('date_stop', '<=', date_end)]
            //     domain = expression.AND([domain, contract_domain])
            // work_entries = self.env['hr.work.entry'].sudo().search(domain)
            // if work_entries:
            //     work_entries.sudo().unlink()
            */
            return default;
        }

        protected async Task<HrContract> CheckContractsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays_contract, FILE: hr_contract.py) ---
            // def _check_contracts(self):
            // self._get_leaves()._check_contracts()
            */
            return default;
        }

        protected async Task<HrContract> CheckCurrentContractInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py) ---
            // def _check_current_contract(self):
            // """ Two contracts in state [incoming | open | close] cannot overlap """
            // for contract in self.filtered(lambda c: (c.state not in ['draft', 'cancel'] or c.state == 'draft' and c.kanban_state == 'done') and c.employee_id):
            //     domain = [
            //         ('id', '!=', contract.id),
            //         ('employee_id', '=', contract.employee_id.id),
            //         ('company_id', '=', contract.company_id.id),
            //         '|',
            //             ('state', 'in', ['open', 'close']),
            //             '&',
            //                 ('state', '=', 'draft'),
            //                 ('kanban_state', '=', 'done') # replaces incoming
            //     ]
            // 
            //     if not contract.date_end:
            //         start_domain = []
            //         end_domain = ['|', ('date_end', '>=', contract.date_start), ('date_end', '=', False)]
            //     else:
            //         start_domain = [('date_start', '<=', contract.date_end)]
            //         end_domain = ['|', ('date_end', '>', contract.date_start), ('date_end', '=', False)]
            // 
            //     domain = expression.AND([domain, start_domain, end_domain])
            //     if self.search_count(domain):
            //         raise ValidationError(
            //             _(
            //                 'An employee can only have one contract at the same time. (Excluding Draft and Cancelled contracts).\n\nEmployee: %(employee_name)s',
            //                 employee_name=contract.employee_id.name
            //             )
            //         )
            */
            return default;
        }

        protected async Task<HrContract> CheckDatesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py) ---
            // def _check_dates(self):
            // for contract in self:
            //     if contract.date_end and contract.date_start > contract.date_end:
            //         raise ValidationError(_(
            //             'Contract %(contract)s: start date (%(start)s) must be earlier than contract end date (%(end)s).',
            //             contract=contract.name, start=contract.date_start, end=contract.date_end,
            //         ))
            */
            return default;
        }

        protected async Task<HrContract> ComputeCalendarMismatchInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py) ---
            // def _compute_calendar_mismatch(self):
            // for contract in self:
            //     contract.calendar_mismatch = contract.resource_calendar_id != contract.employee_id.resource_calendar_id
            */
            return default;
        }

        protected async Task<HrContract> ComputeContractWageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py) ---
            // def _compute_contract_wage(self):
            // for contract in self:
            //     contract.contract_wage = contract._get_contract_wage()
            */
            return default;
        }

        protected async Task<HrContract> ComputeEmployeeContractInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py) ---
            // def _compute_employee_contract(self):
            // for contract in self.filtered('employee_id'):
            //     contract.job_id = contract.employee_id.job_id
            //     contract.department_id = contract.employee_id.department_id
            //     contract.resource_calendar_id = contract.employee_id.resource_calendar_id
            //     contract.company_id = contract.employee_id.company_id
            */
            return default;
        }

        protected async Task<HrContract> ComputeStructureTypeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py) ---
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
            // for contract in self:
            //     if not contract.structure_type_id or (contract.structure_type_id.country_id and contract.structure_type_id.country_id != contract.company_id.country_id):
            //         contract.structure_type_id = _default_salary_structure(contract.company_id.country_id.id)
            */
            return default;
        }

        protected async Task<HrContract> ComputeWorkEntrySourceCalendarInvalidInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py) ---
            // def _compute_work_entry_source_calendar_invalid(self):
            // for contract in self:
            //     contract.work_entry_source_calendar_invalid = contract.work_entry_source == 'calendar' and not contract.resource_calendar_id
            */
            return default;
        }

        protected async Task<HrContract> CronGenerateMissingWorkEntriesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py) ---
            // def _cron_generate_missing_work_entries(self):
            // # retrieve contracts for the current month
            // today = fields.Date.today()
            // start = datetime.combine(today + relativedelta(day=1), time.min)
            // stop = datetime.combine(today + relativedelta(months=1, day=31), time.max)
            // all_contracts = self.env['hr.employee']._get_all_contracts(
            //     start, stop, states=['open', 'close'])
            // # determine contracts to do (the ones whose generated dates have open periods this month)
            // contracts_todo = all_contracts.filtered(lambda c:\
            //     (c.date_generated_from > start or c.date_generated_to < stop) and\
            //     (not c.last_generation_date or c.last_generation_date < today))
            // if not contracts_todo:
            //     return
            // countract_todo_count = len(contracts_todo)
            // # Filter contracts by company, work entries generation is not supposed to be called on
            // # contracts from differents companies, as we will retrieve the resource.calendar.leave
            // # and we don't want to mix everything up. The other contracts will be treated when the
            // # cron is re-triggered
            // contracts_todo = contracts_todo.filtered(lambda c: c.company_id == contracts_todo[0].company_id)
            // # generate a batch of work entries
            // BATCH_SIZE = 100
            // # Since attendance based are more volatile for their work entries generation
            // # it can happen that the date_generated_from and date_generated_to fields are not
            // # pushed to start and stop
            // # It is more interesting for batching to process statically generated work entries first
            // # since we get benefits from having multiple contracts on the same calendar
            // contracts_todo = contracts_todo.sorted(key=lambda c: 1 if c.has_static_work_entries() else 100)
            // contracts_todo = contracts_todo[:BATCH_SIZE].generate_work_entries(
            //     start.date(), stop.date(), False)
            // # if necessary, retrigger the cron to generate more work entries
            // if countract_todo_count > BATCH_SIZE:
            //     self.env.ref('hr_work_entry_contract.ir_cron_generate_missing_work_entries')._trigger()
            */
            return default;
        }

        public async Task<HrContract> GenerateWorkEntriesAsync(Guid id, HrContractGenerateWorkEntriesRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py) ---
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
            // contracts_by_company_tz = defaultdict(lambda: self.env['hr.contract'])
            // for contract in self:
            //     contracts_by_company_tz[(
            //         contract.company_id,
            //         (contract.resource_calendar_id or contract.employee_id.resource_calendar_id).tz
            //     )] += contract
            // utc = pytz.timezone('UTC')
            // new_work_entries = self.env['hr.work.entry']
            // for (company, contract_tz), contracts in contracts_by_company_tz.items():
            //     tz = pytz.timezone(contract_tz) if contract_tz else pytz.utc
            //     date_start_tz = tz.localize(date_start).astimezone(utc).replace(tzinfo=None)
            //     date_stop_tz = tz.localize(date_stop).astimezone(utc).replace(tzinfo=None)
            //     new_work_entries += contracts.with_company(company).sudo()._generate_work_entries(
            //         date_start_tz, date_stop_tz, force=force)
            // return new_work_entries
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrContract> GenerateWorkEntriesInternalAsync(object date_start, object date_stop, object force)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py) ---
            // def _generate_work_entries(self, date_start, date_stop, force=False):
            // # Generate work entries between 2 dates (datetime.datetime)
            // # This method considers that the dates are correctly localized
            // # based on the target timezone
            // assert isinstance(date_start, datetime)
            // assert isinstance(date_stop, datetime)
            // self = self.with_context(tracking_disable=True)
            // canceled_contracts = self.filtered(lambda c: c.state == 'cancel')
            // if canceled_contracts:
            //     raise UserError(
            //         _("Sorry, generating work entries from cancelled contracts is not allowed.")
            //         + "\n%s" % (format_list(self.env, canceled_contracts.mapped("name"))),
            //     )
            // vals_list = []
            // self.write({'last_generation_date': fields.Date.today()})
            // 
            // intervals_to_generate = defaultdict(lambda: self.env['hr.contract'])
            // # In case the date_generated_from == date_generated_to, move it to the date_start to
            // # avoid trying to generate several months/years of history for old contracts for which
            // # we've never generated the work entries.
            // self.filtered(lambda c: c.date_generated_from == c.date_generated_to).write({
            //     'date_generated_from': date_start,
            //     'date_generated_to': date_start,
            // })
            // utc = pytz.timezone('UTC')
            // for contract in self:
            //     contract_tz = (contract.resource_calendar_id or contract.employee_id.resource_calendar_id).tz
            //     tz = pytz.timezone(contract_tz) if contract_tz else pytz.utc
            //     contract_start = tz.localize(fields.Datetime.to_datetime(contract.date_start)).astimezone(utc).replace(tzinfo=None)
            //     contract_stop = datetime.combine(fields.Datetime.to_datetime(contract.date_end or datetime.max.date()),
            //                                      datetime.max.time())
            //     if contract.date_end:
            //         contract_stop = tz.localize(contract_stop).astimezone(utc).replace(tzinfo=None)
            //     if date_start > contract_stop or date_stop < contract_start:
            //         continue
            //     date_start_work_entries = max(date_start, contract_start)
            //     date_stop_work_entries = min(date_stop, contract_stop)
            //     if force:
            //         intervals_to_generate[(date_start_work_entries, date_stop_work_entries)] |= contract
            //         continue
            // 
            //     # For each contract, we found each interval we must generate
            //     # In some cases we do not want to set the generated dates beforehand, since attendance based work entries
            //     #  is more dynamic, we want to update the dates within the _get_work_entries_values function
            //     last_generated_from = min(contract.date_generated_from, contract_stop)
            //     if last_generated_from > date_start_work_entries:
            //         contract.date_generated_from = date_start_work_entries
            //         intervals_to_generate[(date_start_work_entries, last_generated_from)] |= contract
            // 
            //     last_generated_to = max(contract.date_generated_to, contract_start)
            //     if last_generated_to < date_stop_work_entries:
            //         contract.date_generated_to = date_stop_work_entries
            //         intervals_to_generate[(last_generated_to, date_stop_work_entries)] |= contract
            // 
            // for interval, contracts in intervals_to_generate.items():
            //     date_from, date_to = interval
            //     vals_list.extend(contracts._get_work_entries_values(date_from, date_to))
            // 
            // if not vals_list:
            //     return self.env['hr.work.entry']
            // 
            // return self.env['hr.work.entry'].create(vals_list)
            */
            return default;
        }

        public async Task<HrContract> GetAllStructuresAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_contract.py) ---
            // def get_all_structures(self):
            // """
            // @return: the structures linked to the given contracts, ordered by hierachy (parent=False first,
            //          then first level children and so on) and without duplicata
            // """
            // structures = self.mapped('struct_id')
            // if not structures:
            //     return []
            // # YTI TODO return browse records
            // return list(set(structures._get_parent_structure().ids))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrContract> GetAttendanceIntervalsInternalAsync(object start_dt, object end_dt)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py) ---
            // def _get_attendance_intervals(self, start_dt, end_dt):
            // # {resource: intervals}
            // employees_by_calendar = defaultdict(lambda: self.env['hr.employee'])
            // for contract in self:
            //     if contract.work_entry_source != 'calendar':
            //         continue
            //     employees_by_calendar[contract.resource_calendar_id] |= contract.employee_id
            // result = dict()
            // for calendar, employees in employees_by_calendar.items():
            //     result.update(calendar._attendance_intervals_batch(
            //         start_dt,
            //         end_dt,
            //         resources=employees.resource_id,
            //         tz=pytz.timezone(calendar.tz)
            //     ))
            // return result
            */
            return default;
        }

        public async Task<HrContract> GetAttributeAsync(Guid id, HrContractGetAttributeRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_contract.py) ---
            // def get_attribute(self, code, attribute):
            // return self.env['hr.contract.advantage.template'].search([('code', '=', code)], limit=1)[attribute]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrContract> GetBypassingWorkEntryTypeCodesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py) ---
            // def _get_bypassing_work_entry_type_codes(self):
            // return []
            */
            return default;
        }

        protected async Task<HrContract> GetContractWageFieldInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py) ---
            // def _get_contract_wage_field(self):
            // self.ensure_one()
            // return 'wage'
            */
            return default;
        }

        protected async Task<HrContract> GetContractWageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py) ---
            // def _get_contract_wage(self):
            // if not self:
            //     return 0
            // self.ensure_one()
            // return self[self._get_contract_wage_field()]
            */
            return default;
        }

        protected async Task<HrContract> GetContractWorkEntriesValuesInternalAsync(object date_start, object date_stop)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py) ---
            // def _get_contract_work_entries_values(self, date_start, date_stop):
            // start_dt = pytz.utc.localize(date_start) if not date_start.tzinfo else date_start
            // end_dt = pytz.utc.localize(date_stop) if not date_stop.tzinfo else date_stop
            // contract_vals = []
            // bypassing_work_entry_type_codes = self._get_bypassing_work_entry_type_codes()
            // 
            // attendances_by_resource = self._get_attendance_intervals(start_dt, end_dt)
            // 
            // resource_calendar_leaves = self._get_resource_calendar_leaves(start_dt, end_dt)
            // # {resource: resource_calendar_leaves}
            // leaves_by_resource = defaultdict(lambda: self.env['resource.calendar.leaves'])
            // for leave in resource_calendar_leaves:
            //     leaves_by_resource[leave.resource_id.id] |= leave
            // 
            // tz_dates = {}
            // for contract in self:
            //     employee = contract.employee_id
            //     calendar = contract.resource_calendar_id
            //     resource = employee.resource_id
            //     # if the contract is fully flexible, we refer to the employee's timezone
            //     tz = pytz.timezone(resource.tz) if contract._is_fully_flexible() else pytz.timezone(calendar.tz)
            //     attendances = attendances_by_resource[resource.id]
            // 
            //     # Other calendars: In case the employee has declared time off in another calendar
            //     # Example: Take a time off, then a credit time.
            //     resources_list = [self.env['resource.resource'], resource]
            //     result = defaultdict(lambda: [])
            //     for leave in itertools.chain(leaves_by_resource[False], leaves_by_resource[resource.id]):
            //         for resource in resources_list:
            //             # Global time off is not for this calendar, can happen with multiple calendars in self
            //             if resource and leave.calendar_id and leave.calendar_id != calendar and not leave.resource_id:
            //                 continue
            //             tz = tz if tz else pytz.timezone((resource or contract).tz)
            //             if (tz, start_dt) in tz_dates:
            //                 start = tz_dates[(tz, start_dt)]
            //             else:
            //                 start = start_dt.astimezone(tz)
            //                 tz_dates[(tz, start_dt)] = start
            //             if (tz, end_dt) in tz_dates:
            //                 end = tz_dates[(tz, end_dt)]
            //             else:
            //                 end = end_dt.astimezone(tz)
            //                 tz_dates[(tz, end_dt)] = end
            //             dt0 = string_to_datetime(leave.date_from).astimezone(tz)
            //             dt1 = string_to_datetime(leave.date_to).astimezone(tz)
            //             leave_start_dt = max(start, dt0)
            //             leave_end_dt = min(end, dt1)
            //             leave_interval = (leave_start_dt, leave_end_dt, leave)
            //             leave_interval = contract._get_valid_leave_intervals(attendances, leave_interval)
            //             if leave_interval:
            //                 result[resource.id] += leave_interval
            //     mapped_leaves = {r.id: WorkIntervals(result[r.id]) for r in resources_list}
            //     leaves = mapped_leaves[resource.id]
            // 
            //     real_attendances = attendances - leaves
            // 
            //     if not calendar:
            //         real_leaves = leaves
            //     elif calendar.flexible_hours:
            //         # Flexible hours case
            //         # For multi day leaves, we want them to occupy the virtual working schedule 12 AM to average working days
            //         # For one day leaves, we want them to occupy exactly the time it was taken, for a time off in days
            //         # this will mean the virtual schedule and for time off in hours the chosen hours
            //         one_day_leaves = WorkIntervals([l for l in leaves if l[0].date() == l[1].date()])
            //         multi_day_leaves = leaves - one_day_leaves
            //         static_attendances = calendar._attendance_intervals_batch(
            //             start_dt, end_dt, resources=resource, tz=tz)[resource.id]
            //         real_leaves = (static_attendances & multi_day_leaves) | one_day_leaves
            // 
            //     elif contract.has_static_work_entries() or not leaves:
            //         # Empty leaves means empty real_leaves
            //         real_leaves = attendances - real_attendances
            //     else:
            //         # In the case of attendance based contracts use regular attendances to generate leave intervals
            //         static_attendances = calendar._attendance_intervals_batch(
            //             start_dt, end_dt, resources=resource, tz=tz)[resource.id]
            //         real_leaves = static_attendances & leaves
            // 
            //     if not contract.has_static_work_entries():
            //         # An attendance based contract might have an invalid planning, by definition it may not happen with
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
            //     # Attendances
            //     for interval in real_attendances:
            //         work_entry_type = contract._get_interval_work_entry_type(interval)
            //         # All benefits generated here are using datetimes converted from the employee's timezone
            //         contract_vals += [dict([
            //             ('name', "%s: %s" % (work_entry_type.name, employee.name)),
            //             ('date_start', interval[0].astimezone(pytz.utc).replace(tzinfo=None)),
            //             ('date_stop', interval[1].astimezone(pytz.utc).replace(tzinfo=None)),
            //             ('work_entry_type_id', work_entry_type.id),
            //             ('employee_id', employee.id),
            //             ('contract_id', contract.id),
            //             ('company_id', contract.company_id.id),
            //             ('state', 'draft'),
            //         ] + contract._get_more_vals_attendance_interval(interval))]
            // 
            //     leaves_over_attendances = WorkIntervals(leaves) & real_leaves
            //     for interval in real_leaves:
            //         # Could happen when a leave is configured on the interface on a day for which the
            //         # employee is not supposed to work, i.e. no attendance_ids on the calendar.
            //         # In that case, do try to generate an empty work entry, as this would raise a
            //         # sql constraint error
            //         if interval[0] == interval[1]:  # if start == stop
            //             continue
            //         leaves_over_interval = [l for l in leaves_over_attendances if l[0] >= interval[0] and l[1] <= interval[1]]
            //         for leave_interval in [(l[0], l[1], interval[2]) for l in leaves_over_interval]:
            //             leave_entry_type = contract._get_interval_leave_work_entry_type(leave_interval, leaves, bypassing_work_entry_type_codes)
            //             interval_leaves = [leave for leave in leaves if leave[2].work_entry_type_id.id == leave_entry_type.id]
            //             interval_start = leave_interval[0].astimezone(pytz.utc).replace(tzinfo=None)
            //             interval_stop = leave_interval[1].astimezone(pytz.utc).replace(tzinfo=None)
            //             contract_vals += [dict([
            //                 ('name', "%s%s" % (leave_entry_type.name + ": " if leave_entry_type else "", employee.name)),
            //                 ('date_start', interval_start),
            //                 ('date_stop', interval_stop),
            //                 ('work_entry_type_id', leave_entry_type.id),
            //                 ('employee_id', employee.id),
            //                 ('company_id', contract.company_id.id),
            //                 ('state', 'draft'),
            //                 ('contract_id', contract.id),
            //             ] + contract._get_more_vals_leave_interval(interval, interval_leaves))]
            // return contract_vals
            */
            return default;
        }

        protected async Task<HrContract> GetDefaultWorkEntryTypeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py) ---
            // def _get_default_work_entry_type_id(self):
            // attendance = self.env.ref('hr_work_entry.work_entry_type_attendance', raise_if_not_found=False)
            // return attendance.id if attendance else False
            */
            return default;
        }

        protected async Task<HrContract> GetEmployeeValsToUpdateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py) ---
            // def _get_employee_vals_to_update(self):
            // self.ensure_one()
            // vals = {'contract_id': self.id}
            // if self.job_id and self.job_id != self.employee_id.job_id:
            //     vals['job_id'] = self.job_id.id
            // if self.department_id:
            //     vals['department_id'] = self.department_id.id
            // return vals
            */
            return default;
        }

        protected async Task<HrContract> GetFieldsThatRecomputeWeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py) ---
            // def _get_fields_that_recompute_we(self):
            // # Returns the fields that should recompute the work entries
            // return ['resource_calendar_id', 'work_entry_source']
            */
            return default;
        }

        protected async Task<HrContract> GetHrResponsibleDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py) ---
            // def _get_hr_responsible_domain(self):
            // return "[('share', '=', False), ('company_ids', 'in', company_id), ('groups_id', 'in', %s)]" % self.env.ref('hr.group_hr_user').id
            */
            return default;
        }

        protected async Task<HrContract> GetIntervalLeaveWorkEntryTypeInternalAsync(object interval, object leaves, object bypassing_codes)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py) ---
            // def _get_interval_leave_work_entry_type(self, interval, leaves, bypassing_codes):
            // # returns the work entry time related to the leave that
            // # includes the whole interval.
            // # Overriden in hr_work_entry_contract_holiday to select the
            // # global time off first (eg: Public Holiday > Home Working)
            // self.ensure_one()
            // for leave in leaves:
            //     if interval[0] >= leave[0] and interval[1] <= leave[1] and leave[2]:
            //         interval_start = interval[0].astimezone(pytz.utc).replace(tzinfo=None)
            //         interval_stop = interval[1].astimezone(pytz.utc).replace(tzinfo=None)
            //         return self._get_leave_work_entry_type_dates(leave[2], interval_start, interval_stop, self.employee_id)
            // return self.env.ref('hr_work_entry_contract.work_entry_type_leave')
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_contract.py) ---
            // def _get_interval_leave_work_entry_type(self, interval, leaves, bypassing_codes):
            // # returns the work entry time related to the leave that
            // # includes the whole interval.
            // # Overriden in hr_work_entry_contract_holiday to select the
            // # global time off first (eg: Public Holiday > Home Working)
            // self.ensure_one()
            // if 'work_entry_type_id' in interval[2] and interval[2].work_entry_type_id.code in bypassing_codes:
            //     return interval[2].work_entry_type_id
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
            // return self.env.ref('hr_work_entry_contract.work_entry_type_leave')
            */
            return default;
        }

        protected async Task<HrContract> GetIntervalWorkEntryTypeInternalAsync(object interval)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py) ---
            // def _get_interval_work_entry_type(self, interval):
            // self.ensure_one()
            // if 'work_entry_type_id' in interval[2] and interval[2].work_entry_type_id[:1]:
            //     return interval[2].work_entry_type_id[:1]
            // return self.env['hr.work.entry.type'].browse(self._get_default_work_entry_type_id())
            */
            return default;
        }

        protected async Task<HrContract> GetLeaveDomainInternalAsync(object start_dt, object end_dt)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py) ---
            // def _get_leave_domain(self, start_dt, end_dt):
            // domain = [
            //     ('resource_id', 'in', [False] + self.employee_id.resource_id.ids),
            //     ('date_from', '<=', end_dt),
            //     ('date_to', '>=', start_dt),
            //     ('company_id', 'in', [False, self.company_id.id]),
            // ]
            // return expression.AND([domain, self._get_sub_leave_domain()])
            */
            return default;
        }

        protected async Task<HrContract> GetLeaveWorkEntryTypeDatesInternalAsync(object leave, object date_from, object date_to, object employee)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py) ---
            // def _get_leave_work_entry_type_dates(self, leave, date_from, date_to, employee):
            // return self._get_leave_work_entry_type(leave)
            */
            return default;
        }

        protected async Task<HrContract> GetLeaveWorkEntryTypeInternalAsync(object leave)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py) ---
            // def _get_leave_work_entry_type(self, leave):
            // return leave.work_entry_type_id
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_contract.py) ---
            // def _get_leave_work_entry_type(self, leave):
            // if leave.holiday_id:
            //     return leave.holiday_id.holiday_status_id.work_entry_type_id
            // else:
            //     return leave.work_entry_type_id
            */
            return default;
        }

        protected async Task<HrContract> GetLeavesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays_contract, FILE: hr_contract.py) ---
            // def _get_leaves(self):
            // return self.env['hr.leave'].search([
            //     ('state', '!=', 'refuse'),
            //     ('employee_id', 'in', self.mapped('employee_id.id')),
            //     ('date_from', '<=', max([end or date.max for end in self.mapped('date_end')])),
            //     ('date_to', '>=', min(self.mapped('date_start'))),
            // ])
            */
            return default;
        }

        protected async Task<HrContract> GetLunchIntervalsInternalAsync(object start_dt, object end_dt)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py) ---
            // def _get_lunch_intervals(self, start_dt, end_dt):
            // # {resource: intervals}
            // employees_by_calendar = defaultdict(lambda: self.env['hr.employee'])
            // for contract in self:
            //     employees_by_calendar[contract.resource_calendar_id] |= contract.employee_id
            // result = {}
            // for calendar, employees in employees_by_calendar.items():
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

        protected async Task<HrContract> GetMoreValsAttendanceIntervalInternalAsync(object interval)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py) ---
            // def _get_more_vals_attendance_interval(self, interval):
            // return []
            */
            return default;
        }

        protected async Task<HrContract> GetMoreValsLeaveIntervalInternalAsync(object interval, object leaves)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py) ---
            // def _get_more_vals_leave_interval(self, interval, leaves):
            // return []
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_contract.py) ---
            // def _get_more_vals_leave_interval(self, interval, leaves):
            // result = super()._get_more_vals_leave_interval(interval, leaves)
            // for leave in leaves:
            //     if interval[0] >= leave[0] and interval[1] <= leave[1]:
            //         result.append(('leave_id', leave[2].holiday_id.id))
            // return result
            */
            return default;
        }

        protected async Task<HrContract> GetResourceCalendarLeavesInternalAsync(object start_dt, object end_dt)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py) ---
            // def _get_resource_calendar_leaves(self, start_dt, end_dt):
            // return self.env['resource.calendar.leaves'].search(self._get_leave_domain(start_dt, end_dt))
            */
            return default;
        }

        protected async Task<HrContract> GetSalaryCostsFactorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py) ---
            // def _get_salary_costs_factor(self):
            // self.ensure_one()
            // return 12.0
            */
            return default;
        }

        protected async Task<HrContract> GetSubLeaveDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py) ---
            // def _get_sub_leave_domain(self):
            // return [('calendar_id', 'in', [False] + self.resource_calendar_id.ids)]
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_contract.py) ---
            // def _get_sub_leave_domain(self):
            // domain = super()._get_sub_leave_domain()
            // return OR([
            //     domain,
            //     [('holiday_id.employee_id', 'in', self.employee_id.ids)] # see https://github.com/odoo/enterprise/pull/15091
            // ])
            */
            return default;
        }

        protected async Task<HrContract> GetValidLeaveIntervalsInternalAsync(object attendances, object interval)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py) ---
            // def _get_valid_leave_intervals(self, attendances, interval):
            // self.ensure_one()
            // return [interval]
            */
            return default;
        }

        protected async Task<HrContract> GetWorkEntriesValuesInternalAsync(object date_start, object date_stop)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py) ---
            // def _get_work_entries_values(self, date_start, date_stop):
            // """
            // Generate a work_entries list between date_start and date_stop for one contract.
            // :return: list of dictionnary.
            // """
            // if isinstance(date_start, datetime):
            //     contract_vals = self._get_contract_work_entries_values(date_start, date_stop)
            // else:
            //     contract_vals = []
            //     contracts_by_tz = defaultdict(lambda: self.env['hr.contract'])
            //     for contract in self:
            //         contracts_by_tz[contract.resource_calendar_id.tz] += contract
            //     for contract_tz, contracts in contracts_by_tz.items():
            //         tz = pytz.timezone(contract_tz) if contract_tz else pytz.utc
            //         contract_vals += contracts._get_contract_work_entries_values(
            //             tz.localize(date_start),
            //             tz.localize(date_stop))
            // 
            // # {contract_id: ([dates_start], [dates_stop])}
            // mapped_contract_dates = defaultdict(lambda: ([], []))
            // for x in contract_vals:
            //     mapped_contract_dates[x['contract_id']][0].append(x['date_start'])
            //     mapped_contract_dates[x['contract_id']][1].append(x['date_stop'])
            // 
            // for contract in self:
            //     # If we generate work_entries which exceeds date_start or date_stop, we change boundaries on contract
            //     if contract_vals:
            //         #Handle empty work entries for certain contracts, could happen on an attendance based contract
            //         #NOTE: this does not handle date_stop or date_start not being present in vals
            //         dates_stop = mapped_contract_dates[contract.id][1]
            //         if dates_stop:
            //             date_stop_max = max(dates_stop)
            //             if date_stop_max > contract.date_generated_to:
            //                 contract.date_generated_to = date_stop_max
            // 
            //         dates_start = mapped_contract_dates[contract.id][0]
            //         if dates_start:
            //             date_start_min = min(dates_start)
            //             if date_start_min < contract.date_generated_from:
            //                 contract.date_generated_from = date_start_min
            // 
            // return contract_vals
            */
            return default;
        }

        public async Task<HrContract> HasStaticWorkEntriesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py) ---
            // def has_static_work_entries(self):
            // # Static work entries as in the same are to be generated each month
            // # Useful to differentiate attendance based contracts from regular ones
            // self.ensure_one()
            // return self.work_entry_source == 'calendar'
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrContract> IsFullyFlexibleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py) ---
            // def _is_fully_flexible(self):
            // """ return True if contract has a fully flexible working calendar """
            // self.ensure_one()
            // return not self.resource_calendar_id
            */
            return default;
        }

        protected async Task<HrContract> IsStructFromCountryInternalAsync(object country_code)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py) ---
            // def _is_struct_from_country(self, country_code):
            // self.ensure_one()
            // self_sudo = self.sudo()
            // return self_sudo.structure_type_id and self_sudo.structure_type_id.country_id.code == country_code
            */
            return default;
        }

        protected async Task<HrContract> OnchangeStructureTypeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py) ---
            // def _onchange_structure_type_id(self):
            // default_calendar = self.structure_type_id.default_resource_calendar_id
            // if default_calendar and default_calendar.company_id == self.company_id:
            //     # If the form was opened from the action_open_contract action,
            //     # suggest current employee's calendar for the new contract instead of the default_calendar.
            //     if self.env.context.get('from_action_open_contract'):
            //         return
            //     self.resource_calendar_id = default_calendar
            */
            return default;
        }

        public async Task<HrContract> OpenContractFormAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py) ---
            // def action_open_contract_form(self):
            // self.ensure_one()
            // action = self.env['ir.actions.actions']._for_xml_id('hr_contract.action_hr_contract')
            // action.update({
            //     'view_mode': 'form',
            //     'view_id': self.env.ref('hr_contract.hr_contract_view_form').id,
            //     'views': [(self.env.ref('hr_contract.hr_contract_view_form').id, 'form')],
            //     'res_id': self.id,
            // })
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrContract> OpenContractHistoryAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py) ---
            // def action_open_contract_history(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id('hr_contract.hr_contract_history_view_form_action')
            // action['res_id'] = self.employee_id.id
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrContract> OpenContractListAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py) ---
            // def action_open_contract_list(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id('hr_contract.action_hr_contract')
            // action.update({'domain': [('employee_id', '=', self.employee_id.id)],
            //               'views':  [[False, 'list'], [False, 'kanban'], [False, 'activity'], [False, 'form']],
            //                'context': {'default_employee_id': self.employee_id.id}})
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrContract> RecomputeWorkEntriesInternalAsync(object date_from, object date_to)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py) ---
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

        protected async Task<HrContract> RemoveWorkEntriesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py) ---
            // def _remove_work_entries(self):
            // ''' Remove all work_entries that are outside contract period (function used after writing new start or/and end date) '''
            // all_we_to_unlink = self.env['hr.work.entry']
            // for contract in self:
            //     date_start = fields.Datetime.to_datetime(contract.date_start)
            //     if contract.date_generated_from < date_start:
            //         we_to_remove = self.env['hr.work.entry'].search([('date_stop', '<=', date_start), ('contract_id', '=', contract.id)])
            //         if we_to_remove:
            //             contract.date_generated_from = date_start
            //             all_we_to_unlink |= we_to_remove
            //     if not contract.date_end:
            //         continue
            //     date_end = datetime.combine(contract.date_end, datetime.max.time())
            //     if contract.date_generated_to > date_end:
            //         we_to_remove = self.env['hr.work.entry'].search([('date_start', '>=', date_end), ('contract_id', '=', contract.id)])
            //         if we_to_remove:
            //             contract.date_generated_to = date_end
            //             all_we_to_unlink |= we_to_remove
            // all_we_to_unlink.unlink()
            */
            return default;
        }

        protected async Task<HrContract> SafeWriteForCronInternalAsync(object vals, object from_cron)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py) ---
            // def _safe_write_for_cron(self, vals, from_cron=False):
            // if from_cron:
            //     auto_commit = not getattr(threading.current_thread(), 'testing', False)
            //     for contract in self:
            //         try:
            //             with self.env.cr.savepoint():
            //                 contract.write(vals)
            //         except ValidationError as e:
            //             _logger.warning(e)
            //         else:
            //             if auto_commit:
            //                 self.env.cr.commit()
            // else:
            //     self.write(vals)
            */
            return default;
        }

        public async Task<HrContract> SetAttributeValueAsync(Guid id, HrContractSetAttributeValueRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_contract.py) ---
            // def set_attribute_value(self, code, active):
            // for contract in self:
            //     if active:
            //         value = self.env['hr.contract.advantage.template'].search([('code', '=', code)], limit=1).default_value
            //         contract[code] = value
            //     else:
            //         contract[code] = 0.0
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrContract> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // if 'state' in init_values and self.state == 'open' and 'kanban_state' in init_values and self.kanban_state == 'blocked':
            //     return self.env.ref('hr_contract.mt_contract_pending')
            // elif 'state' in init_values and self.state == 'close':
            //     return self.env.ref('hr_contract.mt_contract_close')
            // return super(Contract, self)._track_subtype(init_values)
            */
            return default;
        }

        public async Task<HrContract> UpdateStateAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py) ---
            // def update_state(self):
            // from_cron = 'from_cron' in self.env.context
            // companies = self.env['res.company'].search([])
            // contracts = self.env['hr.contract']
            // work_permit_contracts = self.env['hr.contract']
            // for company in companies:
            //     contracts += self.search([
            //         ('state', '=', 'open'), ('kanban_state', '!=', 'blocked'), ('company_id', '=', company.id),
            //         '&',
            //         ('date_end', '<=', fields.date.today() + relativedelta(days=company.contract_expiration_notice_period)),
            //         ('date_end', '>=', fields.date.today() + relativedelta(days=1)),
            //     ])
            // 
            //     work_permit_contracts += self.search([
            //         ('state', '=', 'open'), ('kanban_state', '!=', 'blocked'), ('company_id', '=', company.id),
            //         '&',
            //         ('employee_id.work_permit_expiration_date', '<=', fields.date.today() + relativedelta(days=company.work_permit_expiration_notice_period)),
            //         ('employee_id.work_permit_expiration_date', '>=', fields.date.today() + relativedelta(days=1)),
            //     ])
            // 
            // for contract in contracts:
            //     contract.with_context(mail_activity_quick_update=True).activity_schedule(
            //         'mail.mail_activity_data_todo', contract.date_end,
            //         _("The contract of %s is about to expire.", contract.employee_id.name),
            //         user_id=contract.hr_responsible_id.id or self.env.uid)
            //     contract.message_post(
            //         body=_(
            //             "According to the contract's end date, this contract has been put in red on the %s. Please advise and correct.",
            //             fields.Date.today()
            //         )
            //     )
            // 
            // for contract in work_permit_contracts:
            //     contract.with_context(mail_activity_quick_update=True).activity_schedule(
            //         'mail.mail_activity_data_todo', contract.date_end,
            //         _("The work permit of %s is about to expire.", contract.employee_id.name),
            //         user_id=contract.hr_responsible_id.id or self.env.uid)
            //     contract.message_post(
            //         body=_(
            //             "According to Employee's Working Permit Expiration Date, this contract has been put in red on the %s. Please advise and correct.",
            //             fields.Date.today()
            //         )
            //     )
            // 
            // if contracts:
            //     contracts._safe_write_for_cron({'kanban_state': 'blocked'}, from_cron)
            // if work_permit_contracts:
            //     work_permit_contracts._safe_write_for_cron({'kanban_state': 'blocked'}, from_cron)
            // 
            // contracts_to_close = self.search([
            //     ('state', '=', 'open'),
            //     '|',
            //     ('date_end', '<=', fields.Date.to_string(date.today())),
            //     ('employee_id.work_permit_expiration_date', '<=', fields.Date.to_string(date.today())),
            // ])
            // 
            // if contracts_to_close:
            //     contracts_to_close._safe_write_for_cron({'state': 'close'}, from_cron)
            // 
            // contracts_to_open = self.search([('state', '=', 'draft'), ('kanban_state', '=', 'done'), ('date_start', '<=', fields.Date.to_string(date.today())),])
            // 
            // if contracts_to_open:
            //     contracts_to_open._safe_write_for_cron({'state': 'open'}, from_cron)
            // 
            // contract_ids = self.search([('date_end', '=', False), ('state', '=', 'close'), ('employee_id', '!=', False)])
            // # Ensure all closed contract followed by a new contract have a end date.
            // # If closed contract has no closed date, the work entries will be generated for an unlimited period.
            // for contract in contract_ids:
            //     next_contract = self.search([
            //         ('employee_id', '=', contract.employee_id.id),
            //         ('state', 'not in', ['cancel', 'draft']),
            //         ('date_start', '>', contract.date_start)
            //     ], order="date_start asc", limit=1)
            //     if next_contract:
            //         contract._safe_write_for_cron({'date_end': next_contract.date_start - relativedelta(days=1)}, from_cron)
            //         continue
            //     next_contract = self.search([
            //         ('employee_id', '=', contract.employee_id.id),
            //         ('date_start', '>', contract.date_start)
            //     ], order="date_start asc", limit=1)
            //     if next_contract:
            //         contract._safe_write_for_cron({'date_end': next_contract.date_start - relativedelta(days=1)}, from_cron)
            // 
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, HrContract entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py) ---
            // def write(self, vals):
            // old_state = {c.id: c.state for c in self}
            // res = super(Contract, self).write(vals)
            // new_state = {c.id: c.state for c in self}
            // if vals.get('state') == 'open':
            //     self._assign_open_contract()
            // today = fields.Date.today()
            // for contract in self:
            //     if contract == contract.sudo().employee_id.contract_id \
            //         and old_state[contract.id] == 'open' \
            //         and new_state[contract.id] != 'open':
            //         running_contract = self.env['hr.contract'].search([
            //             ('employee_id', '=', contract.employee_id.id),
            //             ('company_id', '=', contract.company_id.id),
            //             ('state', '=', 'open'),
            //         ]).filtered(lambda c: c.date_start <= today and (not c.date_end or c.date_end >= today))
            //         if running_contract:
            //             contract.employee_id.sudo().contract_id = running_contract[0]
            // if vals.get('state') == 'close':
            //     for contract in self.filtered(lambda c: not c.date_end):
            //         contract.date_end = max(date.today(), contract.date_start)
            // date_end = vals.get('date_end')
            // if self.env.context.get('close_contract', True) and date_end and fields.Date.from_string(date_end) < fields.Date.context_today(self):
            //     for contract in self.filtered(lambda c: c.state == 'open'):
            //         contract.state = 'close'
            // 
            // if 'resource_calendar_id' in vals:
            //     calendar = vals['resource_calendar_id']
            //     self.filtered(
            //         lambda c: c.state == 'open' or (c.state == 'draft' and c.kanban_state == 'done' and c.employee_id.contracts_count == 1)
            //     ).employee_id.resource_calendar_id = calendar
            // 
            // if 'state' in vals and 'kanban_state' not in vals:
            //     self.write({'kanban_state': 'normal'})
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_holidays_contract, FILE: hr_contract.py) ---
            // def write(self, vals):
            // # Special case when setting a contract as running:
            // # If there is already a validated time off over another contract
            // # with a different schedule, split the time off, before the
            // # _check_contracts raises an issue.
            // # If there are existing leaves that are spanned by this new
            // # contract, update their resource calendar to the current one.
            // if not (vals.get("state") == 'open' or vals.get('kanban_state') == 'done'):
            //     return super().write(vals)
            // 
            // specific_contracts = self.env['hr.contract']
            // all_new_leave_origin = []
            // all_new_leave_vals = []
            // leaves_state = {}
            // # In case a validation error is thrown due to holiday creation with the new resource calendar (which can
            // # increase their duration), we catch this error to display a more meaningful error message.
            // try:
            //     for contract in self:
            //         if vals.get('state') != 'open' and contract.state != 'draft':
            //             # In case the current contract is not in the draft state, the kanban_state transition does not
            //             # cause any leave changes.
            //             continue
            //         leaves = contract._get_leaves()
            //         for leave in leaves:
            //             # Get all overlapping contracts but exclude draft contracts that are not included in this transaction.
            //             overlapping_contracts = leave._get_overlapping_contracts(contract_states=[
            //                 ('state', '!=', 'cancel'),
            //                 ('resource_calendar_id', '!=', False),
            //                 '|', '|', ('id', 'in', self.ids),
            //                           ('state', '!=', 'draft'),
            //                      ('kanban_state', '=', 'done'),
            //             ]).sorted(key=lambda c: {'open': 1, 'close': 2, 'draft': 3, 'cancel': 4}[c.state])
            //             if len(overlapping_contracts.resource_calendar_id) <= 1:
            //                 if overlapping_contracts and leave.resource_calendar_id != overlapping_contracts[0].resource_calendar_id:
            //                     leave.resource_calendar_id = overlapping_contracts[0].resource_calendar_id
            //                 continue
            //             if leave.id not in leaves_state:
            //                 leaves_state[leave.id] = leave.state
            //             if leave.state != 'refuse':
            //                 leave.action_refuse()
            //             super(HrContract, contract).write(vals)
            //             specific_contracts += contract
            //             for overlapping_contract in overlapping_contracts:
            //                 new_request_date_from = max(leave.request_date_from, overlapping_contract.date_start)
            //                 new_request_date_to = min(leave.request_date_to, overlapping_contract.date_end or date.max)
            //                 new_leave_vals = leave.copy_data({
            //                     'request_date_from': new_request_date_from,
            //                     'request_date_to': new_request_date_to,
            //                     'state': leaves_state[leave.id],
            //                 })[0]
            //                 new_leave = self.env['hr.leave'].new(new_leave_vals)
            //                 new_leave._compute_date_from_to()
            //                 new_leave._compute_duration()
            //                 # Could happen for part-time contract, that time off is not necessary
            //                 # anymore.
            //                 if new_leave.date_from < new_leave.date_to:
            //                     all_new_leave_origin.append(leave)
            //                     all_new_leave_vals.append(new_leave._convert_to_write(new_leave._cache))
            //     if all_new_leave_vals:
            //         new_leaves = self.env['hr.leave'].with_context(
            //             tracking_disable=True,
            //             mail_activity_automation_skip=True,
            //             leave_fast_create=True,
            //             leave_skip_state_check=True
            //         ).create(all_new_leave_vals)
            //         new_leaves.filtered(lambda l: l.state in 'validate')._validate_leave_request()
            //         for index, new_leave in enumerate(new_leaves):
            //             new_leave.message_post_with_source(
            //                 'mail.message_origin_link',
            //                 render_values={'self': new_leave, 'origin': all_new_leave_origin[index]},
            //                 subtype_xmlid='mail.mt_note',
            //             )
            // except ValidationError:
            //     raise ValidationError(_("Changing the contract on this employee changes their working schedule in a period "
            //                             "they already took leaves. Changing this working schedule changes the duration of "
            //                             "these leaves in such a way the employee no longer has the required allocation for "
            //                             "them. Please review these leaves and/or allocations before changing the contract."))
            // return super(HrContract, self - specific_contracts).write(vals)
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py) ---
            // def write(self, vals):
            // result = super(HrContract, self).write(vals)
            // if vals.get('date_end') or vals.get('date_start'):
            //     self.sudo()._remove_work_entries()
            // if vals.get('state') in ['draft', 'cancel']:
            //     self._cancel_work_entries()
            // dependendant_fields = self._get_fields_that_recompute_we()
            // salary_simulation = self.env.context.get('salary_simulation')
            // if not salary_simulation and any(key in dependendant_fields for key in vals.keys()):
            //     for contract in self:
            //         date_from = max(contract.date_start, contract.date_generated_from.date())
            //         date_to = min(contract.date_end or date.max, contract.date_generated_to.date())
            //         if date_from != date_to and self.employee_id:
            //             contract._recompute_work_entries(date_from, date_to)
            // return result
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}