using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Bamboo.Core.Application.Services
{
    [Module("Mrp", Depends = new[] { "product", "stock", "resource" })]
    public class MrpWorkcenterAppService : GenericApplicationService<MrpWorkcenter>, IMrpWorkcenterAppService
    {
        private readonly IAnalyticMixinAppService _analyticMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        private readonly IResourceMixinAppService _resourceMixinAppService;
        public MrpWorkcenterAppService(IRepository<MrpWorkcenter, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IAnalyticMixinAppService analyticMixinAppService, IMailThreadAppService mailThreadAppService, IResourceMixinAppService resourceMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _analyticMixinAppService = analyticMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _resourceMixinAppService = resourceMixinAppService;
        }

        public async Task<MrpWorkcenter> ArchiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def action_archive(self):
            // res = super().action_archive()
            // filtered_workcenters = ", ".join(workcenter.name for workcenter in self.filtered('routing_line_ids'))
            // if filtered_workcenters:
            //     return {
            //         'type': 'ir.actions.client',
            //         'tag': 'display_notification',
            //         'params': {
            //         'title': _("Note that archived work center(s): '%s' is/are still linked to active Bill of Materials, which means that operations can still be planned on it/them. "
            //                    "To prevent this, deletion of the work center is recommended instead.", filtered_workcenters),
            //         'type': 'warning',
            //         'sticky': True,  #True/False will display for few seconds if false
            //         'next': {'type': 'ir.actions.act_window_close'},
            //         },
            //     }
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MrpWorkcenter> CheckAlternativeWorkcenterInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _check_alternative_workcenter(self):
            // for workcenter in self:
            //     if workcenter in workcenter.alternative_workcenter_ids:
            //         raise ValidationError(_("Workcenter %s cannot be an alternative of itself.", workcenter.name))
            */
            return default;
        }

        protected async Task<MrpWorkcenter> CheckCapacityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _check_capacity(self):
            // if any(workcenter.default_capacity <= 0.0 for workcenter in self):
            //     raise exceptions.UserError(_('The capacity must be strictly positive.'))
            */
            return default;
        }

        protected async Task<MrpWorkcenter> ComputeBlockedTimeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _compute_blocked_time(self):
            // # TDE FIXME: productivity loss type should be only losses, probably count other time logs differently ??
            // data = self.env['mrp.workcenter.productivity']._read_group([
            //     ('date_start', '>=', fields.Datetime.to_string(datetime.now() - relativedelta.relativedelta(months=1))),
            //     ('workcenter_id', 'in', self.ids),
            //     ('date_end', '!=', False),
            //     ('loss_type', '!=', 'productive')],
            //     ['workcenter_id'], ['duration:sum'])
            // count_data = {workcenter.id: duration for workcenter, duration in data}
            // for workcenter in self:
            //     workcenter.blocked_time = count_data.get(workcenter.id, 0.0) / 60.0
            */
            return default;
        }

        protected async Task<MrpWorkcenter> ComputeCostsHourAccountIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: mrp_workcenter.py) ---
            // def _compute_costs_hour_account_ids(self):
            // for record in self:
            //     record.costs_hour_account_ids = bool(record.analytic_distribution) and self.env['account.analytic.account'].browse(
            //         list({int(account_id) for ids in record.analytic_distribution for account_id in ids.split(",")})
            //     ).exists()
            */
            return default;
        }

        protected async Task<MrpWorkcenter> ComputeHasRoutingLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _compute_has_routing_lines(self):
            // for workcenter in self:
            //     workcenter.has_routing_lines = self.env['mrp.routing.workcenter'].search_count([('workcenter_id', '=', workcenter.id)], limit=1)
            */
            return default;
        }

        protected async Task<MrpWorkcenter> ComputeKanbanDashboardGraphInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _compute_kanban_dashboard_graph(self):
            // week_range, date_start, date_stop = self._get_week_range_and_first_last_days()
            // load_data = self._get_workcenter_load_per_week(week_range, date_start, date_stop)
            // load_graph_data = self._prepare_graph_data(load_data, week_range)
            // for wc in self:
            //     wc.kanban_dashboard_graph = json.dumps(load_graph_data[wc.id])
            */
            return default;
        }

        protected async Task<MrpWorkcenter> ComputeOeeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _compute_oee(self):
            // for order in self:
            //     if order.productive_time:
            //         order.oee = round(order.productive_time * 100.0 / (order.productive_time + order.blocked_time), 2)
            //     else:
            //         order.oee = 0.0
            */
            return default;
        }

        protected async Task<MrpWorkcenter> ComputePerformanceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _compute_performance(self):
            // wo_data = self.env['mrp.workorder']._read_group([
            //     ('date_start', '>=', fields.Datetime.to_string(datetime.now() - relativedelta.relativedelta(months=1))),
            //     ('workcenter_id', 'in', self.ids),
            //     ('state', '=', 'done')], ['workcenter_id'], ['duration_expected:sum', 'duration:sum'])
            // duration_expected = {workcenter.id: expected for workcenter, expected, __ in wo_data}
            // duration = {workcenter.id: duration for workcenter, __, duration in wo_data}
            // for workcenter in self:
            //     if duration.get(workcenter.id):
            //         workcenter.performance = 100 * duration_expected.get(workcenter.id, 0.0) / duration[workcenter.id]
            //     else:
            //         workcenter.performance = 0.0
            */
            return default;
        }

        protected async Task<MrpWorkcenter> ComputeProductiveTimeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _compute_productive_time(self):
            // # TDE FIXME: productivity loss type should be only losses, probably count other time logs differently
            // data = self.env['mrp.workcenter.productivity']._read_group([
            //     ('date_start', '>=', fields.Datetime.to_string(datetime.now() - relativedelta.relativedelta(months=1))),
            //     ('workcenter_id', 'in', self.ids),
            //     ('date_end', '!=', False),
            //     ('loss_type', '=', 'productive')],
            //     ['workcenter_id'], ['duration:sum'])
            // count_data = {workcenter.id: duration for workcenter, duration in data}
            // for workcenter in self:
            //     workcenter.productive_time = count_data.get(workcenter.id, 0.0) / 60.0
            */
            return default;
        }

        protected async Task<MrpWorkcenter> ComputeWorkingStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _compute_working_state(self):
            // for workcenter in self:
            //     # We search for a productivity line associated to this workcenter having no `date_end`.
            //     # If we do not find one, the workcenter is not currently being used. If we find one, according
            //     # to its `type_loss`, the workcenter is either being used or blocked.
            //     time_log = self.env['mrp.workcenter.productivity'].search([
            //         ('workcenter_id', '=', workcenter.id),
            //         ('date_end', '=', False)
            //     ], limit=1)
            //     if not time_log:
            //         # the workcenter is not being used
            //         workcenter.working_state = 'normal'
            //     elif time_log.loss_type in ('productive', 'performance'):
            //         # the productivity line has a `loss_type` that means the workcenter is being used
            //         workcenter.working_state = 'done'
            //     else:
            //         # the workcenter is blocked
            //         workcenter.working_state = 'blocked'
            */
            return default;
        }

        protected async Task<MrpWorkcenter> ComputeWorkorderCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _compute_workorder_count(self):
            // MrpWorkorder = self.env['mrp.workorder']
            // result = {wid: {} for wid in self._ids}
            // result_duration_expected = {wid: 0 for wid in self._ids}
            // # Count Late Workorder
            // data = MrpWorkorder._read_group(
            //     [('workcenter_id', 'in', self.ids), ('state', 'in', ('pending', 'waiting', 'ready')), ('date_start', '<', datetime.now().strftime('%Y-%m-%d'))],
            //     ['workcenter_id'], ['__count'])
            // count_data = {workcenter.id: count for workcenter, count in data}
            // # Count All, Pending, Ready, Progress Workorder
            // res = MrpWorkorder._read_group(
            //     [('workcenter_id', 'in', self.ids)],
            //     ['workcenter_id', 'state'], ['duration_expected:sum', '__count'])
            // for workcenter, state, duration_sum, count in res:
            //     result[workcenter.id][state] = count
            //     if state in ('pending', 'waiting', 'ready', 'progress'):
            //         result_duration_expected[workcenter.id] += duration_sum
            // for workcenter in self:
            //     workcenter.workorder_count = sum(count for state, count in result[workcenter.id].items() if state not in ('done', 'cancel'))
            //     workcenter.workorder_pending_count = result[workcenter.id].get('pending', 0)
            //     workcenter.workcenter_load = result_duration_expected[workcenter.id]
            //     workcenter.workorder_ready_count = result[workcenter.id].get('ready', 0)
            //     workcenter.workorder_progress_count = result[workcenter.id].get('progress', 0)
            //     workcenter.workorder_late_count = count_data.get(workcenter.id, 0)
            */
            return default;
        }

        protected async Task<MrpWorkcenter> GetCapacityInternalAsync(object product)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _get_capacity(self, product):
            // product_capacity = self.capacity_ids.filtered(lambda capacity: capacity.product_id == product)
            // return product_capacity.capacity if product_capacity else self.default_capacity
            */
            return default;
        }

        protected async Task<MrpWorkcenter> GetExpectedDurationInternalAsync(Guid product_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _get_expected_duration(self, product_id):
            // """Compute the expected duration when using this work-center
            // Always use the startup / clean-up time from specific capacity if defined.
            // """
            // capacity = self.capacity_ids.filtered(lambda p: p.product_id == product_id)
            // return capacity.time_start + capacity.time_stop if capacity else self.time_start + self.time_stop
            */
            return default;
        }

        protected async Task<MrpWorkcenter> GetFirstAvailableSlotInternalAsync(object start_datetime, object duration, object forward, object leaves_to_ignore, object extra_leaves_slots)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _get_first_available_slot(self, start_datetime, duration, forward=True, leaves_to_ignore=False, extra_leaves_slots=[]):
            // """Get the first available interval for the workcenter in `self`.
            // 
            // The available interval is disjoinct with all other workorders planned on this workcenter, but
            // can overlap the time-off of the related calendar (inverse of the working hours).
            // Return the first available interval (start datetime, end datetime) or,
            // if there is none before 700 days, a tuple error (False, 'error message').
            // 
            // :param duration: minutes needed to make the workorder (float)
            // :param start_datetime: begin the search at this datetime
            // :param forward: forward scheduling (search from start_datetime to 700 days after), or backward (from start_datetime to now)
            // :param leaves_to_ignore: typically, ignore allocated leave when re-planning a workorder
            // :param extra_leaves_slots: extra time slots (start, stop) to consider
            // :rtype: tuple
            // """
            // self.ensure_one()
            // resource = self.resource_id
            // start_datetime, revert = make_aware(start_datetime)
            // get_available_intervals = partial(self.resource_calendar_id._work_intervals_batch, resources=resource, tz=timezone(self.resource_calendar_id.tz))
            // workorder_intervals_leaves_domain = [('time_type', '=', 'other')]
            // if leaves_to_ignore:
            //     workorder_intervals_leaves_domain.append(('id', 'not in', leaves_to_ignore.ids))
            // get_workorder_intervals = partial(self.resource_calendar_id._leave_intervals_batch, domain=workorder_intervals_leaves_domain, resources=resource, tz=timezone(self.resource_calendar_id.tz))
            // extra_leaves_slots_intervals = Intervals([(make_aware(start)[0], make_aware(stop)[0], self.env['resource.calendar.attendance']) for start, stop in extra_leaves_slots])
            // 
            // remaining = duration
            // now = make_aware(datetime.now())[0]
            // delta = timedelta(days=14)
            // start_interval, stop_interval = None, None
            // for n in range(50):  # 50 * 14 = 700 days in advance (hardcoded)
            //     if forward:
            //         date_start = start_datetime + delta * n
            //         date_stop = date_start + delta
            //         available_intervals = get_available_intervals(date_start, date_stop)[resource.id]
            //         workorder_intervals = get_workorder_intervals(date_start, date_stop)[resource.id]
            //         for start, stop, _records in available_intervals:
            //             start_interval = start_interval or start
            //             interval_minutes = (stop - start).total_seconds() / 60
            //             while (interval := Intervals([(start_interval or start, start + timedelta(minutes=min(remaining, interval_minutes)), _records)])) \
            //               and (conflict := interval & workorder_intervals or interval & extra_leaves_slots_intervals):
            //                 (_start, start, _records) = conflict._items[0]  # restart available interval at conflicting interval stop
            //                 interval_minutes = (stop - start).total_seconds() / 60
            //                 start_interval, remaining = start if interval_minutes else None, duration
            //             if float_compare(interval_minutes, remaining, precision_digits=3) >= 0:
            //                 return revert(start_interval), revert(start + timedelta(minutes=remaining))
            //             remaining -= interval_minutes
            //     else:
            //         # same process but starting from end on reversed intervals
            //         date_stop = start_datetime - delta * n
            //         date_start = date_stop - delta
            //         available_intervals = get_available_intervals(date_start, date_stop)[resource.id]
            //         available_intervals = reversed(available_intervals)
            //         workorder_intervals = get_workorder_intervals(date_start, date_stop)[resource.id]
            //         for start, stop, _records in available_intervals:
            //             stop_interval = stop_interval or stop
            //             interval_minutes = (stop - start).total_seconds() / 60
            //             while (interval := Intervals([(stop - timedelta(minutes=min(remaining, interval_minutes)), stop_interval or stop, _records)])) \
            //               and (conflict := interval & workorder_intervals or interval & extra_leaves_slots_intervals):
            //                 (stop, _stop, _records) = conflict._items[0]  # restart available interval at conflicting interval start
            //                 interval_minutes = (stop - start).total_seconds() / 60
            //                 stop_interval, remaining = stop if interval_minutes else None, duration
            //             if float_compare(interval_minutes, remaining, precision_digits=3) >= 0:
            //                 return revert(stop - timedelta(minutes=remaining)), revert(stop_interval)
            //             remaining -= interval_minutes
            //         if date_start <= now:
            //             break
            // return False, 'No available slot 700 days after the planned start'
            */
            return default;
        }

        protected async Task<MrpWorkcenter> GetUnavailabilityIntervalsInternalAsync(object start_datetime, object end_datetime)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _get_unavailability_intervals(self, start_datetime, end_datetime):
            // """Get the unavailabilities intervals for the workcenters in `self`.
            // 
            // Return the list of unavailabilities (a tuple of datetimes) indexed
            // by workcenter id.
            // 
            // :param start_datetime: filter unavailability with only slots after this start_datetime
            // :param end_datetime: filter unavailability with only slots before this end_datetime
            // :rtype: dict
            // """
            // unavailability_ressources = self.resource_id._get_unavailable_intervals(start_datetime, end_datetime)
            // return {wc.id: unavailability_ressources.get(wc.resource_id.id, []) for wc in self}
            */
            return default;
        }

        protected async Task<MrpWorkcenter> GetWeekRangeAndFirstLastDaysInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _get_week_range_and_first_last_days(self):
            // """ We calculate the delta between today and the previous monday,
            // then add it to the delta between monday and the previous first day
            // of the week as configured in the language settings.
            // We use the result to calculate the modulo of 7 to make sure that
            // we do not take the previous first day of the week from 2 weeks ago.
            // 
            // E.g. today is Thursday, the first of a week is a Tuesday.
            // The delta between today and Monday is 3 days.
            // The delta between Monday and the previous Tuesday is 6 days.
            // (3 + 6) % 7 = 2, so from today, the first day of the current week is 2 days ago.
            // """
            // week_range = {}
            // locale = get_lang(self.env).code
            // today = datetime.today()
            // delta_from_monday_to_today = (today - start_of(today, 'week')).days
            // first_week_day = int(get_lang(self.env).week_start) - 1
            // day_offset = ((7 - first_week_day) + delta_from_monday_to_today) % 7
            // 
            // for delta in range(-7, 28, 7):
            //     week_start = start_of(today + relativedelta.relativedelta(days=delta - day_offset), 'day')
            //     week_end = week_start + relativedelta.relativedelta(days=6)
            //     short_name = (format_date(week_start, 'd - ', locale=locale)
            //                   + format_date(week_end, 'd MMM', locale=locale))
            //     if not delta:
            //         short_name = _('This Week')
            //     week_range[week_start] = short_name
            // date_start = start_of(today + relativedelta.relativedelta(days=-7 - day_offset), 'day')
            // date_stop = end_of(today + relativedelta.relativedelta(days=27 - day_offset), 'day')
            // return week_range, date_start, date_stop
            */
            return default;
        }

        protected async Task<MrpWorkcenter> GetWorkcenterLoadPerWeekInternalAsync(object week_range, object date_start, object date_stop)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _get_workcenter_load_per_week(self, week_range, date_start, date_stop):
            // load_data = {rec: {} for rec in self}
            // # demo data
            // if not self.order_ids:
            //     for wc in self:
            //         load_limit = 40     # default max load per week is 40 hours on a new workcenter
            //         load_data[wc] = {week_start: randint(0, int(load_limit * 2)) for week_start in week_range}
            //     return load_data
            // 
            // result = self.env['mrp.workorder']._read_group(
            //     [('workcenter_id', 'in', self.ids), ('state', 'in', ('pending', 'waiting', 'ready', 'progress')),
            //      ('production_date', '>=', date_start), ('production_date', '<=', date_stop)],
            //     ['workcenter_id', 'production_date:week'], ['duration_expected:sum'])
            // for r in result:
            //     load_in_hours = round(r[2] / 60, 1)
            //     load_data[r[0]].update({r[1]: load_in_hours})
            // return load_data
            */
            return default;
        }

        protected async Task<MrpWorkcenter> PrepareGraphDataInternalAsync(object load_data, object week_range)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _prepare_graph_data(self, load_data, week_range):
            // graph_data = {wid: [] for wid in self._ids}
            // for workcenter in self:
            //     load_limit = sum(workcenter.resource_calendar_id.attendance_ids.mapped('duration_hours'))
            //     wc_data = {'is_sample_data': not self.order_ids, 'labels': list(week_range.values())}
            //     load_bar = []
            //     excess_bar = []
            //     for week_start in week_range:
            //         load_bar.append(min(load_data[workcenter].get(week_start, 0), load_limit))
            //         excess_bar.append(max(float_round(load_data[workcenter].get(week_start, 0) - load_limit, precision_digits=1, rounding_method='HALF-UP'), 0))
            //     wc_data['values'] = [load_bar, load_limit, excess_bar]
            //     graph_data[workcenter.id].append(wc_data)
            // return graph_data
            */
            return default;
        }

        public async Task<MrpWorkcenter> ShowOperationsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def action_show_operations(self):
            // self.ensure_one()
            // action = self.env['ir.actions.actions']._for_xml_id('mrp.mrp_routing_action')
            // action['domain'] = [('workcenter_id', '=', self.id)]
            // action['context'] = {
            //     'default_workcenter_id': self.id,
            // }
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MrpWorkcenter> UnblockAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def unblock(self):
            // self.ensure_one()
            // if self.working_state != 'blocked':
            //     raise exceptions.UserError(_("It has already been unblocked."))
            // times = self.env['mrp.workcenter.productivity'].search([('workcenter_id', '=', self.id), ('date_end', '=', False)])
            // times.write({'date_end': datetime.now()})
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MrpWorkcenter> WorkOrderAlternativesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def action_work_order_alternatives(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("mrp.mrp_workorder_todo")
            // action['domain'] = ['|', ('workcenter_id', 'in', self.alternative_workcenter_ids.ids),
            //                     ('workcenter_id.alternative_workcenter_ids', '=', self.id)]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MrpWorkcenter> WorkOrderAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def action_work_order(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("mrp.action_work_orders")
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}