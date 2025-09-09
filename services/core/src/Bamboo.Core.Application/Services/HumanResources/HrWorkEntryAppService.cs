using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Services;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;

namespace Bamboo.Core.Application.Services
{
    [Module("HrWorkEntryModule", Depends = new[] { "hr" })]
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
            //     # Already confirmed once
            //     if self.leave_id.state == 'validate1':
            //         self.leave_id.action_validate()
            //     # Still in confirmed state
            //     else:
            //         self.leave_id.action_approve()
            //         # If double validation, still have to validate it again
            //         if self.leave_id.validation_type == 'both':
            //             self.leave_id.action_validate()
            */
            var entity = await Repository.GetAsync(id); return entity;
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
            // conflict = self._mark_conflicting_work_entries(min(self.mapped('date_start')), max(self.mapped('date_stop')))
            // return undefined_type or conflict
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_work_entry.py) ---
            // def _check_if_error(self):
            // res = super()._check_if_error()
            // outside_calendar = self._mark_leaves_outside_schedule()
            // return res or outside_calendar
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_work_entry.py) ---
            // def _check_if_error(self):
            // res = super()._check_if_error()
            // conflict_with_leaves = self._compute_conflicts_leaves_to_approve()
            // return res or conflict_with_leaves
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

        protected async Task<HrWorkEntry> ComputeConflictsLeavesToApproveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_work_entry.py) ---
            // def _compute_conflicts_leaves_to_approve(self):
            // if not self:
            //     return False
            // 
            // self.flush_recordset(['date_start', 'date_stop', 'employee_id', 'active'])
            // self.env['hr.leave'].flush_model(['date_from', 'date_to', 'state', 'employee_id'])
            // 
            // query = """
            //     SELECT
            //         b.id AS work_entry_id,
            //         l.id AS leave_id
            //     FROM hr_work_entry b
            //     INNER JOIN hr_leave l ON b.employee_id = l.employee_id
            //     WHERE
            //         b.active = TRUE AND
            //         b.id IN %s AND
            //         l.date_from < b.date_stop AND
            //         l.date_to > b.date_start AND
            //         l.state IN ('confirm', 'validate1');
            // """
            // self.env.cr.execute(query, [tuple(self.ids)])
            // conflicts = self.env.cr.dictfetchall()
            // for res in conflicts:
            //     self.browse(res.get('work_entry_id')).write({
            //         'state': 'conflict',
            //         'leave_id': res.get('leave_id')
            //     })
            // return bool(conflicts)
            */
            return default;
        }

        protected async Task<HrWorkEntry> ComputeDateStopInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py) ---
            // def _compute_date_stop(self):
            // for work_entry in self.filtered(lambda w: w.date_start and w.duration):
            //     work_entry.date_stop = work_entry.date_start + relativedelta(hours=work_entry.duration)
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_work_entry.py) ---
            // def _compute_date_stop(self):
            // for work_entry in self:
            //     if work_entry._get_duration_is_valid():
            //         calendar = work_entry.contract_id.resource_calendar_id
            //         if not calendar:
            //             continue
            //         work_entry.date_stop = calendar.plan_hours(work_entry.duration, work_entry.date_start, compute_leaves=True)
            //         continue
            //     super(HrWorkEntry, work_entry)._compute_date_stop()
            */
            return default;
        }

        protected async Task<HrWorkEntry> ComputeDurationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py) ---
            // def _compute_duration(self):
            // durations = self._get_duration_batch()
            // for work_entry in self:
            //     work_entry.duration = durations[work_entry.id]
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

        public override async Task<HrWorkEntry> CreateAsync(HrWorkEntry entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py) ---
            // def create(self, vals_list):
            // company_by_employee_id = {}
            // for vals in vals_list:
            //     if vals.get('company_id'):
            //         continue
            //     if vals['employee_id'] not in company_by_employee_id:
            //         employee = self.env['hr.employee'].browse(vals['employee_id'])
            //         company_by_employee_id[employee.id] = employee.company_id.id
            //     vals['company_id'] = company_by_employee_id[vals['employee_id']]
            // work_entries = super().create(vals_list)
            // work_entries._check_if_error()
            // return work_entries
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_work_entry.py) ---
            // def create(self, vals_list):
            // vals_list = [self._set_current_contract(vals) for vals in vals_list]
            // work_entries = super().create(vals_list)
            // return work_entries
            */
            return await base.CreateAsync(entity, fields);
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
            //     start = start or min(self.mapped('date_start'), default=False)
            //     stop = stop or max(self.mapped('date_stop'), default=False)
            //     if not skip and start and stop:
            //         domain = [
            //             ('date_start', '<', stop),
            //             ('date_stop', '>', start),
            //             ('state', 'not in', ('validated', 'cancelled')),
            //         ]
            //         if employee_ids:
            //             domain = expression.AND([domain, [('employee_id', 'in', list(employee_ids))]])
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
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_work_entry.py) ---
            // def _from_intervals(self, intervals):
            // return self.browse(chain.from_iterable(recs.ids for start, end, recs in intervals))
            */
            return default;
        }

        protected async Task<HrWorkEntry> GetDurationBatchInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py) ---
            // def _get_duration_batch(self):
            // result = {}
            // cached_periods = defaultdict(float)
            // for work_entry in self:
            //     date_start = work_entry.date_start
            //     date_stop = work_entry.date_stop
            //     if not date_start or not date_stop:
            //         result[work_entry.id] = 0.0
            //         continue
            //     if (date_start, date_stop) in cached_periods:
            //         result[work_entry.id] = cached_periods[(date_start, date_stop)]
            //     else:
            //         dt = date_stop - date_start
            //         duration = round(dt.total_seconds()) / 3600  # Number of hours
            //         cached_periods[(date_start, date_stop)] = duration
            //         result[work_entry.id] = duration
            // return result
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_work_entry.py) ---
            // def _get_duration_batch(self):
            // super_work_entries = self.env['hr.work.entry']
            // result = {}
            // # {(date_start, date_stop): {calendar: employees}}
            // mapped_periods = defaultdict(lambda: defaultdict(lambda: self.env['hr.employee']))
            // for work_entry in self:
            //     if not work_entry.date_start or not work_entry.date_stop or not work_entry._is_duration_computed_from_calendar() or not work_entry.employee_id:
            //         super_work_entries |= work_entry
            //         continue
            //     date_start = work_entry.date_start
            //     date_stop = work_entry.date_stop
            //     calendar = work_entry.contract_id.resource_calendar_id
            //     if not calendar:
            //         result[work_entry.id] = 0.0
            //         continue
            //     employee = work_entry.contract_id.employee_id
            //     mapped_periods[(date_start, date_stop)][calendar] |= employee
            // 
            // # {(date_start, date_stop): {calendar: {'hours': foo}}}
            // mapped_contract_data = defaultdict(lambda: defaultdict(lambda: {'hours': 0.0}))
            // for (date_start, date_stop), employees_by_calendar in mapped_periods.items():
            //     for calendar, employees in employees_by_calendar.items():
            //         mapped_contract_data[(date_start, date_stop)][calendar] = employees._get_work_days_data_batch(
            //             date_start, date_stop, compute_leaves=False, calendar=calendar)
            // result = super(HrWorkEntry, super_work_entries)._get_duration_batch()
            // for work_entry in self - super_work_entries:
            //     date_start = work_entry.date_start
            //     date_stop = work_entry.date_stop
            //     calendar = work_entry.contract_id.resource_calendar_id
            //     employee = work_entry.contract_id.employee_id
            //     result[work_entry.id] = mapped_contract_data[(date_start, date_stop)][calendar][employee.id]['hours'] if calendar else 0.0
            // return result
            */
            return default;
        }

        protected async Task<HrWorkEntry> GetDurationIsValidInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_work_entry.py) ---
            // def _get_duration_is_valid(self):
            // return self.work_entry_type_id and self.work_entry_type_id.is_leave
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
            //     ('date_start', '>=', date_from),
            //     ('date_stop', '<=', date_to),
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
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_work_entry.py) ---
            // def _get_leaves_entries_outside_schedule(self):
            // return self.filtered(lambda w: w.work_entry_type_id.is_leave and w.state not in ('validated', 'cancelled'))
            */
            return default;
        }

        public async Task<HrWorkEntry> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py) ---
            // def init(self):
            // tools.create_index(self._cr, "hr_work_entry_date_start_date_stop_index", self._table, ["date_start", "date_stop"])
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_work_entry.py) ---
            // def init(self):
            // # FROM 7s by query to 2ms (with 2.6 millions entries)
            // self.env.cr.execute("""
            //     CREATE INDEX IF NOT EXISTS hr_work_entry_contract_date_start_stop_idx
            //     ON hr_work_entry(contract_id, date_start, date_stop)
            //     WHERE state in ('draft', 'validated');
            // """)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrWorkEntry> InitColumnInternalAsync(object column_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_work_entry.py) ---
            // def _init_column(self, column_name):
            // if column_name != 'contract_id':
            //     super()._init_column(column_name)
            // else:
            //     self.env.cr.execute("""
            //         UPDATE hr_work_entry AS _hwe
            //         SET contract_id = result.contract_id
            //         FROM (
            //             SELECT
            //                 hc.id AS contract_id,
            //                 array_agg(hwe.id) AS entry_ids
            //             FROM
            //                 hr_work_entry AS hwe
            //             LEFT JOIN
            //                 hr_contract AS hc
            //             ON
            //                 hwe.employee_id=hc.employee_id AND
            //                 hc.state in ('open', 'close') AND
            //                 hwe.date_start >= hc.date_start AND
            //                 hwe.date_stop < COALESCE(hc.date_end + integer '1', '9999-12-31 23:59:59')
            //             WHERE
            //                 hwe.contract_id IS NULL
            //             GROUP BY
            //                 hwe.employee_id, hc.id
            //         ) AS result
            //         WHERE _hwe.id = ANY(result.entry_ids)
            //     """)
            */
            return default;
        }

        protected async Task<HrWorkEntry> IsDurationComputedFromCalendarInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_work_entry.py) ---
            // def _is_duration_computed_from_calendar(self):
            // self.ensure_one()
            // return self._get_duration_is_valid()
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_work_entry.py) ---
            // def _is_duration_computed_from_calendar(self):
            // return super()._is_duration_computed_from_calendar() or bool(not self.work_entry_type_id and self.leave_id)
            */
            return default;
        }

        protected async Task<HrWorkEntry> MarkConflictingWorkEntriesInternalAsync(object start, object stop)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py) ---
            // def _mark_conflicting_work_entries(self, start, stop):
            // """
            // Set `state` to `conflict` for overlapping work entries
            // between two dates.
            // If `self.ids` is truthy then check conflicts with the corresponding work entries.
            // Return True if overlapping work entries were detected.
            // """
            // # Use the postgresql range type `tsrange` which is a range of timestamp
            // # It supports the intersection operator (&&) useful to detect overlap.
            // # use '()' to exlude the lower and upper bounds of the range.
            // # Filter on date_start and date_stop (both indexed) in the EXISTS clause to
            // # limit the resulting set size and fasten the query.
            // self.flush_model(['date_start', 'date_stop', 'employee_id', 'active'])
            // query = """
            //     SELECT b1.id,
            //            b2.id
            //       FROM hr_work_entry b1
            //       JOIN hr_work_entry b2
            //         ON b1.employee_id = b2.employee_id
            //        AND b1.id <> b2.id
            //      WHERE b1.date_start <= %(stop)s
            //        AND b1.date_stop >= %(start)s
            //        AND b1.active = TRUE
            //        AND b2.active = TRUE
            //        AND tsrange(b1.date_start, b1.date_stop, '()') && tsrange(b2.date_start, b2.date_stop, '()')
            //        AND {}
            // """.format("b2.id IN %(ids)s" if self.ids else "b2.date_start <= %(stop)s AND b2.date_stop >= %(start)s")
            // self.env.cr.execute(query, {"stop": stop, "start": start, "ids": tuple(self.ids)})
            // conflicts = set(itertools.chain.from_iterable(self.env.cr.fetchall()))
            // self.browse(conflicts).write({
            //     'state': 'conflict',
            // })
            // return bool(conflicts)
            */
            return default;
        }

        protected async Task<HrWorkEntry> MarkLeavesOutsideScheduleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_work_entry.py) ---
            // def _mark_leaves_outside_schedule(self):
            // """
            // Check leave work entries in `self` which are completely outside
            // the contract's theoretical calendar schedule. Mark them as conflicting.
            // :return: leave work entries completely outside the contract's calendar
            // """
            // work_entries = self._get_leaves_entries_outside_schedule()
            // entries_by_calendar = defaultdict(lambda: self.env['hr.work.entry'])
            // for work_entry in work_entries:
            //     calendar = work_entry.contract_id.resource_calendar_id
            //     entries_by_calendar[calendar] |= work_entry
            // 
            // outside_entries = self.env['hr.work.entry']
            // for calendar, entries in entries_by_calendar.items():
            //     if calendar.flexible_hours:
            //         continue
            //     datetime_start = min(entries.mapped('date_start'))
            //     datetime_stop = max(entries.mapped('date_stop'))
            // 
            //     calendar_intervals = calendar._attendance_intervals_batch(pytz.utc.localize(datetime_start), pytz.utc.localize(datetime_stop))[False]
            //     entries_intervals = entries._to_intervals()
            //     overlapping_entries = self._from_intervals(entries_intervals & calendar_intervals)
            //     outside_entries |= entries - overlapping_entries
            // outside_entries.write({'state': 'conflict'})
            // return bool(outside_entries)
            */
            return default;
        }

        protected async Task<HrWorkEntry> OnchangeContractIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_work_entry.py) ---
            // def _onchange_contract_id(self):
            // vals = {
            //     'employee_id': self.employee_id.id,
            //     'date_start': self.date_start,
            //     'date_stop': self.date_stop,
            // }
            // try:
            //     res = self._set_current_contract(vals)
            // except ValidationError:
            //     return
            // if res.get('contract_id'):
            //     self.contract_id = res.get('contract_id')
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
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_work_entry.py) ---
            // def _set_current_contract(self, vals):
            // if not vals.get('contract_id') and vals.get('date_start') and vals.get('date_stop') and vals.get('employee_id'):
            //     contract_start = fields.Datetime.to_datetime(vals.get('date_start')).date()
            //     contract_end = fields.Datetime.to_datetime(vals.get('date_stop')).date()
            //     employee = self.env['hr.employee'].browse(vals.get('employee_id'))
            //     contracts = employee._get_contracts(contract_start, contract_end, states=['open', 'pending', 'close'])
            //     if not contracts:
            //         raise ValidationError(_(
            //             "%(employee)s does not have a contract from %(date_start)s to %(date_end)s.",
            //             employee=employee.name,
            //             date_start=contract_start,
            //             date_end=contract_end,
            //         ))
            //     elif len(contracts) > 1:
            //         raise ValidationError(_("%(employee)s has multiple contracts from %(date_start)s to %(date_end)s. A work entry cannot overlap multiple contracts.",
            //                                 employee=employee.name, date_start=contract_start, date_end=contract_end))
            //     return dict(vals, contract_id=contracts[0].id)
            // return vals
            */
            return default;
        }

        protected async Task<HrWorkEntry> ToIntervalsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_work_entry.py) ---
            // def _to_intervals(self):
            // return WorkIntervals((w.date_start.replace(tzinfo=pytz.utc), w.date_stop.replace(tzinfo=pytz.utc), w) for w in self)
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
            // skip_check = not bool({'date_start', 'date_stop', 'employee_id', 'work_entry_type_id', 'active'} & vals.keys())
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
            //     return super(HrWorkEntry, self).write(vals)
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