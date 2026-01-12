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
    [Module("HrWorkEntryModule", Category = "HumanResources", Depends = new[] { "hr" })]
    public class HrWorkEntryAppService : GenericApplicationService<HrWorkEntry>, IHrWorkEntryAppService
    {

        public HrWorkEntryAppService(IRepository<HrWorkEntry, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<HrWorkEntry> ApproveLeaveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_work_entry.py) ---
            // def action_approve_leave(self):
            // self.ensure_one()
            // if self.leave_id:
            //     self.leave_id.action_approve()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrWorkEntry> CheckDurationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py) ---
            // def _check_duration(self):
            // for work_entry in self:
            //     if float_compare(work_entry.duration, 0, 3) <= 0 or float_compare(work_entry.duration, 24, 3) > 0:
            //         raise ValidationError(self.env._("Duration must be positive and cannot exceed 24 hours."))
            */
            return default;
        }

        protected async Task<HrWorkEntry> CheckIfErrorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py) ---
            // def _check_if_error(self):
            // if not self:
            //     return False
            // undefined_type = self.filtered(lambda b: not b.work_entry_type_id)
            // undefined_type.write({'state': 'conflict'})
            // conflict = self._mark_conflicting_work_entries(min(self.mapped('date')), max(self.mapped('date')))
            // outside_calendar = self._mark_leaves_outside_schedule()
            // already_validated_days = self._mark_already_validated_days()
            // return undefined_type or conflict or outside_calendar or already_validated_days
            */
            return default;
        }

        protected async Task<HrWorkEntry> ComputeConflictInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py) ---
            // def _compute_conflict(self):
            // for rec in self:
            //     rec.conflict = rec.state == 'conflict'
            */
            return default;
        }

        protected async Task<HrWorkEntry> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py) ---
            // def _compute_display_name(self):
            // for work_entry in self:
            //     duration = str(timedelta(hours=work_entry.duration)).split(":")
            //     work_entry.display_name = "%s - %sh%s" % (work_entry.work_entry_type_id.name, duration[0], duration[1])
            */
            return default;
        }

        protected async Task<HrWorkEntry> ComputeNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py) ---
            // def _compute_name(self):
            // for work_entry in self:
            //     if not work_entry.employee_id:
            //         work_entry.name = _('Undefined')
            //     else:
            //         work_entry.name = "%s: %s" % (work_entry.work_entry_type_id.name or _('Undefined Type'), work_entry.employee_id.name)
            */
            return default;
        }

        protected async Task<HrWorkEntry> ErrorCheckingInternalAsync(object start, object stop, object skip, List<Guid> employee_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py) ---
            // def _error_checking(self, start=None, stop=None, skip=False, employee_ids=False):
            // """
            // Context manager used for conflicts checking.
            // When exiting the context manager, conflicts are checked
            // for all work entries within a date range. By default, the start and end dates are
            // computed according to `self` (min and max respectively) but it can be overwritten by providing
            // other values as parameter.
            // :param start: datetime to overwrite the default behaviour
            // :param stop: datetime to overwrite the default behaviour
            // :param skip: If True, no error checking is done
            // """
            // try:
            //     skip = skip or self.env.context.get('hr_work_entry_no_check', False)
            //     start = start or min(self.mapped('date'), default=False)
            //     stop = stop or max(self.mapped('date'), default=False)
            //     if not skip and start and stop:
            //         domain = (
            //             Domain('date', '<=', stop)
            //             & Domain('date', '>=', start)
            //             & Domain('state', 'not in', ('validated', 'cancelled'))
            //         )
            //         if employee_ids:
            //             domain &= Domain('employee_id', 'in', list(employee_ids))
            //         work_entries = self.sudo().with_context(hr_work_entry_no_check=True).search(domain)
            //         work_entries._reset_conflicting_state()
            //     yield
            // except OperationalError:
            //     # the cursor is dead, do not attempt to use it or we will shadow the root exception
            //     # with a "psycopg2.InternalError: current transaction is aborted, ..."
            //     skip = True
            //     raise
            // finally:
            //     if not skip and start and stop:
            //         # New work entries are handled in the create method,
            //         # no need to reload work entries.
            //         work_entries.exists()._check_if_error()
            */
            return default;
        }

        protected async Task<HrWorkEntry> FromIntervalsInternalAsync(object intervals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py) ---
            // def _from_intervals(self, intervals):
            // return self.browse(chain.from_iterable(recs.ids for start, end, recs in intervals))
            */
            return default;
        }

        protected async Task<HrWorkEntry> GetLeavesDurationBetweenTwoDatesInternalAsync(Guid employee_id, object date_from, object date_to)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_work_entry.py) ---
            // def _get_leaves_duration_between_two_dates(self, employee_id, date_from, date_to):
            // date_from += relativedelta(hour=0, minute=0, second=0)
            // date_to += relativedelta(hour=23, minute=59, second=59)
            // leaves_work_entries = self.env['hr.work.entry'].search([
            //     ('employee_id', '=', employee_id.id),
            //     ('date', '>=', date_from),
            //     ('date', '<=', date_to),
            //     ('state', '!=', 'cancelled'),
            //     ('leave_id', '!=', False),
            //     ('leave_state', '=', 'validate'),
            // ])
            // entries_by_leave_type = defaultdict(lambda: self.env['hr.work.entry'])
            // for work_entry in leaves_work_entries:
            //     entries_by_leave_type[work_entry.leave_id.holiday_status_id] |= work_entry
            // 
            // durations_by_leave_type = {}
            // for leave_type, work_entries in entries_by_leave_type.items():
            //     durations_by_leave_type[leave_type] = sum(work_entries.mapped('duration'))
            // return durations_by_leave_type
            */
            return default;
        }

        protected async Task<HrWorkEntry> GetLeavesEntriesOutsideScheduleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py) ---
            // def _get_leaves_entries_outside_schedule(self):
            // return self.filtered(lambda w: w.work_entry_type_id.is_leave and w.state not in ('validated', 'cancelled'))
            */
            return default;
        }

        public async Task<HrWorkEntry> GetUnusualDaysAsync(Guid id, HrWorkEntryGetUnusualDaysRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py) ---
            // def get_unusual_days(self, date_from, date_to=None):
            // return self.env.company.resource_calendar_id._get_unusual_days(
            //     datetime.combine(fields.Date.from_string(date_from), time.min).replace(tzinfo=pytz.utc),
            //     datetime.combine(fields.Date.from_string(date_to), time.max).replace(tzinfo=pytz.utc),
            //     self.company_id,
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrWorkEntry> GetWorkEntryTypeDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py) ---
            // def _get_work_entry_type_domain(self):
            // if len(self.env.companies.country_id.ids) > 1:
            //     return [('country_id', '=', False)]
            // return ['|', ('country_id', '=', False), ('country_id', 'in', self.env.companies.country_id.ids)]
            */
            return default;
        }

        protected async Task<HrWorkEntry> MarkAlreadyValidatedDaysInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py) ---
            // def _mark_already_validated_days(self):
            // invalid_entries = self.env['hr.work.entry']
            // validated_work_entries = self.env["hr.work.entry"].search([
            //     ('state', '=', 'validated'),
            //     ('date', '<=', max(self.mapped('date'))),
            //     ('date', '>=', min(self.mapped('date'))),
            //     ('company_id', '=', self.env.company.id)
            // ])
            // validated_entries_by_employee_date = defaultdict(lambda: self.env['hr.work.entry'])
            // for entry in validated_work_entries:
            //     validated_entries_by_employee_date[entry.employee_id, entry.date] += entry
            // 
            // for entry in self:
            //     if validated_entries_by_employee_date[entry.employee_id, entry.date]:
            //         invalid_entries += entry
            // invalid_entries.write({'state': 'conflict'})
            // return bool(invalid_entries)
            */
            return default;
        }

        protected async Task<HrWorkEntry> MarkConflictingWorkEntriesInternalAsync(object start, object stop)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py) ---
            // def _mark_conflicting_work_entries(self, start, stop):
            // """
            // Set `state` to `conflict` for work entries where, for the same employee and day,
            // the total duration exceeds 24 hours.
            // Return True if such entries are found.
            // """
            // self.flush_model(['date', 'duration', 'employee_id', 'active'])
            // query = """
            //     WITH excessive_days AS (
            //         SELECT employee_id, date
            //         FROM hr_work_entry
            //         WHERE active = TRUE
            //           AND date BETWEEN %(start)s AND %(stop)s
            //           AND employee_id IN %(employee_ids)s
            //         GROUP BY employee_id, date
            //         HAVING 0 >= SUM(duration) OR SUM(duration) > 24
            //     )
            //     SELECT we.id
            //     FROM hr_work_entry we
            //     JOIN excessive_days ed
            //       ON we.employee_id = ed.employee_id
            //      AND we.date = ed.date
            //     WHERE we.active = TRUE
            // """
            // self.env.cr.execute(query, {
            //     "start": start,
            //     "stop": stop,
            //     'employee_ids': tuple(self.employee_id.ids),
            // })
            // conflict_ids = [row[0] for row in self.env.cr.fetchall()]
            // self.browse(conflict_ids).write({'state': 'conflict'})
            // return bool(conflict_ids)
            */
            return default;
        }

        protected async Task<HrWorkEntry> MarkLeavesOutsideScheduleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py) ---
            // def _mark_leaves_outside_schedule(self):
            // """
            // Check leave work entries in `self` which are completely outside
            // the contract's theoretical calendar schedule. Mark them as conflicting.
            // :return: leave work entries completely outside the contract's calendar
            // """
            // work_entries = self._get_leaves_entries_outside_schedule()
            // entries_by_calendar = defaultdict(lambda: self.env['hr.work.entry'])
            // for work_entry in work_entries:
            //     calendar = work_entry.version_id.resource_calendar_id
            //     entries_by_calendar[calendar] |= work_entry
            // 
            // outside_entries = self.env['hr.work.entry']
            // for calendar, entries in entries_by_calendar.items():
            //     if not calendar or calendar.flexible_hours:
            //         continue
            //     datetime_start = datetime.combine(min(entries.mapped('date')), time.min)
            //     datetime_stop = datetime.combine(max(entries.mapped('date')), time.max)
            // 
            //     if calendar:
            //         calendar_intervals = calendar._attendance_intervals_batch(pytz.utc.localize(datetime_start), pytz.utc.localize(datetime_stop))[False]
            //     else:
            //         calendar_intervals = Intervals([(pytz.utc.localize(datetime_start), pytz.utc.localize(datetime_stop), self.env['resource.calendar.attendance'])])
            //     entries_intervals = entries._to_intervals()
            //     overlapping_entries = self._from_intervals(entries_intervals & calendar_intervals)
            //     outside_entries |= entries - overlapping_entries
            // outside_entries.write({'state': 'conflict'})
            // return bool(outside_entries)
            */
            return default;
        }

        protected async Task<HrWorkEntry> OnchangeVersionIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py) ---
            // def _onchange_version_id(self):
            // vals = {
            //     'employee_id': self.employee_id.id,
            //     'date': self.date,
            // }
            // try:
            //     res = self._set_current_contract(vals)
            // except ValidationError:
            //     return
            // if version_id := res.get('version_id'):
            //     self.version_id = version_id
            */
            return default;
        }

        public async Task<HrWorkEntry> RefuseLeaveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_work_entry.py) ---
            // def action_refuse_leave(self):
            // self.ensure_one()
            // leave_sudo = self.leave_id.sudo()
            // if leave_sudo:
            //     leave_sudo.action_refuse()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrWorkEntry> ResetConflictingStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py) ---
            // def _reset_conflicting_state(self):
            // self.filtered(lambda w: w.state == 'conflict').write({'state': 'draft'})
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_work_entry.py) ---
            // def _reset_conflicting_state(self):
            // super()._reset_conflicting_state()
            // attendances = self.filtered(lambda w: w.work_entry_type_id and not w.work_entry_type_id.is_leave)
            // attendances.write({'leave_id': False})
            */
            return default;
        }

        protected async Task<HrWorkEntry> SetCurrentContractInternalAsync(object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py) ---
            // def _set_current_contract(self, vals):
            // if not vals.get('version_id') and vals.get('date') and vals.get('employee_id'):
            //     contract_start = fields.Datetime.to_datetime(vals.get('date'))
            //     contract_end = contract_start
            //     employee = self.env['hr.employee'].browse(vals.get('employee_id'))
            //     contracts = employee._get_versions_with_contract_overlap_with_period(contract_start, contract_end)
            //     if not contracts:
            //         raise ValidationError(_(
            //             "%(employee)s does not have a contract on %(date)s.",
            //             employee=employee.name,
            //             date=contract_start,
            //         ))
            //     return dict(vals, version_id=contracts[0].id)
            // return vals
            */
            return default;
        }

        public async Task<HrWorkEntry> SplitAsync(Guid id, HrWorkEntrySplitRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py) ---
            // def action_split(self, vals):
            // self.ensure_one()
            // if self.duration < 1:
            //     raise UserError(self.env._("You can't split a work entry with less than 1 hour."))
            // split_duration = vals['duration']
            // if self.duration <= split_duration:
            //     raise UserError(
            //         self.env._(
            //             "Split work entry duration has to be less than the existing work entry duration."
            //         )
            //     )
            // self.duration -= split_duration
            // split_work_entry = self.copy()
            // split_work_entry.write(vals)
            // return split_work_entry.id
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrWorkEntry> ToIntervalsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py) ---
            // def _to_intervals(self):
            // return Intervals(
            //     ((datetime.combine(w.date, time.min).replace(tzinfo=pytz.utc), datetime.combine(w.date, time.max).replace(tzinfo=pytz.utc), w) for w in self),
            //     keep_distinct=True)
            */
            return default;
        }

        protected async Task<HrWorkEntry> UnlinkExceptValidatedWorkEntriesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py) ---
            // def _unlink_except_validated_work_entries(self):
            // if any(w.state == 'validated' for w in self):
            //     raise UserError(_("This work entry is validated. You can't delete it."))
            */
            return default;
        }

        public async Task<HrWorkEntry> ValidateAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py) ---
            // def action_validate(self):
            // """
            // Try to validate work entries.
            // If some errors are found, set `state` to conflict for conflicting work entries
            // and validation fails.
            // :return: True if validation succeeded
            // """
            // work_entries = self.filtered(lambda work_entry: work_entry.state != 'validated')
            // if not work_entries._check_if_error():
            //     work_entries.write({'state': 'validated'})
            //     return True
            // return False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, HrWorkEntry entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py) ---
            // def write(self, vals):
            // skip_check = not bool({'date', 'duration', 'employee_id', 'work_entry_type_id', 'active'} & vals.keys())
            // if 'state' in vals:
            //     if vals['state'] == 'draft':
            //         vals['active'] = True
            //     elif vals['state'] == 'cancelled':
            //         vals['active'] = False
            //         skip_check &= all(self.mapped(lambda w: w.state != 'conflict'))
            // 
            // if 'active' in vals:
            //     vals['state'] = 'draft' if vals['active'] else 'cancelled'
            // 
            // employee_ids = self.employee_id.ids
            // if 'employee_id' in vals and vals['employee_id']:
            //     employee_ids += [vals['employee_id']]
            // with self._error_checking(skip=skip_check, employee_ids=employee_ids):
            //     return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_work_entry.py) ---
            // def write(self, vals):
            // if 'state' in vals and vals['state'] == 'cancelled':
            //     self.mapped('leave_id').filtered(lambda l: l.state != 'refuse').action_refuse()
            // return super().write(vals)
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}