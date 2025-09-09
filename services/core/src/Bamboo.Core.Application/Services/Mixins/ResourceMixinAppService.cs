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
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("resource", Depends = new[] { "base", "web" })]
    public class ResourceMixinAppService : ApplicationService, IResourceMixinAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public ResourceMixinAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ActionArchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
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
            return default;
        }

        public async Task<TEntity> ActionCreateUserAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def action_create_user(self):
            // self.ensure_one()
            // if self.user_id:
            //     raise ValidationError(_("This employee already has an user."))
            // return {
            //     'name': _('Create User'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'res.users',
            //     'view_mode': 'form',
            //     'view_id': self.env.ref('hr.view_users_simple_form').id,
            //     'target': 'new',
            //     'context': dict(self._context, **{
            //         'default_create_employee_id': self.id,
            //         'default_name': self.name,
            //         'default_phone': self.work_phone,
            //         'default_mobile': self.mobile_phone,
            //         'default_login': self.work_email,
            //         'default_partner_id': self.work_contact_id.id,
            //     })
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionRelatedContactsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def action_related_contacts(self):
            // related_partners = self._get_related_partners()
            // action = {
            //     'name': _("Related Contacts"),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'res.partner',
            //     'view_mode': 'form',
            // }
            // if len(related_partners) > 1:
            //     action['view_mode'] = 'kanban,list,form'
            //     action['domain'] = [('id', 'in', related_partners.ids)]
            //     return action
            // else:
            //     action['res_id'] = related_partners.id
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionShowOperationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
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
            return default;
        }

        public async Task<TEntity> ActionWorkOrderAlternativesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def action_work_order_alternatives(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("mrp.mrp_workorder_todo")
            // action['domain'] = ['|', ('workcenter_id', 'in', self.alternative_workcenter_ids.ids),
            //                     ('workcenter_id.alternative_workcenter_ids', '=', self.id)]
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionWorkOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def action_work_order(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("mrp.action_work_orders")
            // return action
            */
            return default;
        }

        public async Task<TEntity> AdjustToCalendarInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object end) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_mixin.py) ---
            // def _adjust_to_calendar(self, start, end):
            // resource_results = self.resource_id._adjust_to_calendar(start, end)
            // # change dict keys from resources to associated records.
            // return {
            //     record: resource_results[record.resource_id]
            //     for record in self
            // }
            */
            return default;
        }

        public async Task<TEntity> CheckAlternativeWorkcenterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
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

        public async Task<TEntity> CheckCapacityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _check_capacity(self):
            // if any(workcenter.default_capacity <= 0.0 for workcenter in self):
            //     raise exceptions.UserError(_('The capacity must be strictly positive.'))
            */
            return default;
        }

        public async Task<TEntity> CheckFieldAccessRightsAsync<TEntity>(IEnumerable<TEntity> entities, object operation, object field_names) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def check_field_access_rights(self, operation, field_names):
            // # DISCLAIMER: Dirty hack to avoid having to create a bridge module to override only a
            // # groups on a field which is not prefetched (because not stored) but would crash anyway
            // # if we try to read them directly (very uncommon use case). Don't add your field on this
            // # list if you can specify the group on the field directly (as all the other fields).
            // result = super().check_field_access_rights(operation, field_names)
            // if not self.env.user.has_group("hr.group_hr_user"):
            //     result = [field for field in result if field not in ['activity_calendar_event_id', 'rating_ids', 'website_message_ids', 'message_has_sms_error']]
            // return result
            */
            return default;
        }

        public async Task<TEntity> CheckPrivateFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_names) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _check_private_fields(self, field_names):
            // """ Check whether ``field_names`` contain private fields. """
            // public_fields = self.env['hr.employee.public']._fields
            // private_fields = [fname for fname in field_names if fname not in public_fields]
            // if private_fields:
            //     raise AccessError(_('The fields “%s”, which you are trying to read, are not available for employee public profiles.', ','.join(private_fields)))
            */
            return default;
        }

        public async Task<TEntity> CheckSsnidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _check_ssnid(self):
            // # By default, an Social Security Number is always valid, but each localization
            // # may want to add its own constraints
            // pass
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1024InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar_1024(self):
            // super()._compute_avatar_1024()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar128InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar_128(self):
            // super()._compute_avatar_128()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1920InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar_1920(self):
            // super()._compute_avatar_1920()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar256InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar_256(self):
            // super()._compute_avatar_256()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar512InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar_512(self):
            // super()._compute_avatar_512()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatarInternalAsync<TEntity>(IEnumerable<TEntity> entities, object avatar_field, object image_field) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar(self, avatar_field, image_field):
            // employee_wo_user_and_image = self.env['hr.employee']
            // for employee in self:
            //     if not employee.user_id and not employee._origin[image_field]:
            //         employee_wo_user_and_image += employee
            //         continue
            //     avatar = employee._origin[image_field]
            //     if not avatar and employee.user_id:
            //         avatar = employee.user_id.sudo()[avatar_field]
            //     employee[avatar_field] = avatar
            // super(HrEmployeePrivate, employee_wo_user_and_image)._compute_avatar(avatar_field, image_field)
            */
            return default;
        }

        public async Task<TEntity> ComputeBlockedTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
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

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_display_name(self):
            // if self.browse().has_access('read'):
            //     return super()._compute_display_name()
            // for employee_private, employee_public in zip(self, self.env['hr.employee.public'].browse(self.ids)):
            //     employee_private.display_name = employee_public.display_name
            */
            return default;
        }

        public async Task<TEntity> ComputeHasRoutingLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _compute_has_routing_lines(self):
            // for workcenter in self:
            //     workcenter.has_routing_lines = self.env['mrp.routing.workcenter'].search_count([('workcenter_id', '=', workcenter.id)], limit=1)
            */
            return default;
        }

        public async Task<TEntity> ComputeKanbanDashboardGraphInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
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

        public async Task<TEntity> ComputeKmHomeWorkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_km_home_work(self):
            // for employee in self:
            //     employee.km_home_work = employee.distance_home_work * 1.609 if employee.distance_home_work_unit == "miles" else employee.distance_home_work
            */
            return default;
        }

        public async Task<TEntity> ComputeOeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
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

        public async Task<TEntity> ComputePerformanceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
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

        public async Task<TEntity> ComputeProductiveTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
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

        public async Task<TEntity> ComputeRelatedPartnersCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_related_partners_count(self):
            // self.related_partners_count = len(self._get_related_partners())
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkPermitNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_work_permit_name(self):
            // for employee in self:
            //     name = employee.name.replace(' ', '_') + '_' if employee.name else ''
            //     permit_no = '_' + employee.permit_no if employee.permit_no else ''
            //     employee.work_permit_name = "%swork_permit%s" % (name, permit_no)
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkingStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
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

        public async Task<TEntity> ComputeWorkorderCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
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

        public async Task<TEntity> CopyCacheFromInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @public, object field_names) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _copy_cache_from(self, public, field_names):
            // # HACK: retrieve publicly available values from hr.employee.public and
            // # copy them to the cache of self; non-public data will be missing from
            // # cache, and interpreted as an access error
            // for fname in field_names:
            //     values = self.env.cache.get_values(public, public._fields[fname])
            //     if self._fields[fname].translate:
            //         values = [(value.copy() if value else None) for value in values]
            //     self.env.cache.update_raw(self, self._fields[fname], values)
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_mixin.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // 
            // resource_default = {}
            // if 'company_id' in default:
            //     resource_default['company_id'] = default['company_id']
            // if 'resource_calendar_id' in default:
            //     resource_default['calendar_id'] = default['resource_calendar_id']
            // resources = [record.resource_id for record in self]
            // resources_to_copy = self.env['resource.resource'].concat(*resources)
            // new_resources = resources_to_copy.copy(resource_default)
            // for resource, vals in zip(new_resources, vals_list):
            //     vals['resource_id'] = resource.id
            //     vals['company_id'] = resource.company_id.id
            //     vals['resource_calendar_id'] = resource.calendar_id.id
            // return vals_list
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if vals.get('user_id'):
            //         user = self.env['res.users'].browse(vals['user_id'])
            //         vals.update(self._sync_user(user, bool(vals.get('image_1920'))))
            //         vals['name'] = vals.get('name', user.name)
            //         self._remove_work_contact_id(user, vals.get('company_id'))
            // employees = super().create(vals_list)
            // # Sudo in case HR officer doesn't have the Contact Creation group
            // employees.filtered(lambda e: not e.work_contact_id).sudo()._create_work_contacts()
            // for employee_sudo in employees.sudo():
            //     # creating 'svg/xml' attachments requires specific rights
            //     if not employee_sudo.image_1920 and self.env['ir.ui.view'].sudo(False).has_access('write'):
            //         employee_sudo.image_1920 = employee_sudo._avatar_generate_svg()
            //         employee_sudo.work_contact_id.image_1920 = employee_sudo.image_1920
            // if self.env.context.get('salary_simulation'):
            //     return employees
            // employee_departments = employees.department_id
            // if employee_departments:
            //     self.env['discuss.channel'].sudo().search([
            //         ('subscription_department_ids', 'in', employee_departments.ids)
            //     ])._subscribe_users_automatically()
            // onboarding_notes_bodies = {}
            // hr_root_menu = self.env.ref('hr.menu_hr_root')
            // for employee in employees:
            //     # Launch onboarding plans
            //     url = '/odoo/%s/action-hr.plan_wizard_action?active_model=hr.employee&menu_id=%s' % (employee.id, hr_root_menu.id)
            //     onboarding_notes_bodies[employee.id] = Markup(_(
            //         '<b>Congratulations!</b> May I recommend you to setup an <a href="%s">onboarding plan?</a>',
            //     )) % url
            // employees._message_log_batch(onboarding_notes_bodies)
            // return employees
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def create(self, vals_list):
            // # resource_type is 'human' by default. As we are not living in
            // # /r/latestagecapitalism, workcenters are 'material'
            // records = super(MrpWorkcenter, self.with_context(default_resource_type='material')).create(vals_list)
            // return records
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_mixin.py) ---
            // def create(self, vals_list):
            // resources_vals_list = []
            // calendar_ids = [vals['resource_calendar_id'] for vals in vals_list if vals.get('resource_calendar_id')]
            // calendars_tz = {calendar.id: calendar.tz for calendar in self.env['resource.calendar'].browse(calendar_ids)}
            // for vals in vals_list:
            //     if not vals.get('resource_id'):
            //         resources_vals_list.append(
            //             self._prepare_resource_values(
            //                 vals,
            //                 vals.pop('tz', False) or calendars_tz.get(vals.get('resource_calendar_id'))
            //             )
            //         )
            // if resources_vals_list:
            //     resources = self.env['resource.resource'].create(resources_vals_list)
            //     resources_iter = iter(resources.ids)
            //     for vals in vals_list:
            //         if not vals.get('resource_id'):
            //             vals['resource_id'] = next(resources_iter)
            // return super(ResourceMixin, self.with_context(check_idempotence=True)).create(vals_list)
            */
            return default;
        }

        public async Task<TEntity> CronCheckWorkPermitValidityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _cron_check_work_permit_validity(self):
            // # Called by a cron
            // # Schedule an activity 1 month before the work permit expires
            // outdated_days = fields.Date.today() + relativedelta(months=+1)
            // nearly_expired_work_permits = self.search([('work_permit_scheduled_activity', '=', False), ('work_permit_expiration_date', '<', outdated_days)])
            // employees_scheduled = self.env['hr.employee']
            // for employee in nearly_expired_work_permits.filtered(lambda employee: employee.parent_id):
            //     responsible_user_id = employee.parent_id.user_id.id
            //     if responsible_user_id:
            //         employees_scheduled |= employee
            //         lang = self.env['res.users'].browse(responsible_user_id).lang
            //         formated_date = format_date(employee.env, employee.work_permit_expiration_date, date_format="dd MMMM y", lang_code=lang)
            //         employee.activity_schedule(
            //             'mail.mail_activity_data_todo',
            //             note=_('The work permit of %(employee)s expires at %(date)s.',
            //                 employee=employee.name,
            //                 date=formated_date),
            //             user_id=responsible_user_id)
            // employees_scheduled.write({'work_permit_scheduled_activity': True})
            */
            return default;
        }

        public async Task<TEntity> EmployeeAttendanceIntervalsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object stop, object lunch) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _employee_attendance_intervals(self, start, stop, lunch=False):
            // self.ensure_one()
            // calendar = self.resource_calendar_id or self.company_id.resource_calendar_id
            // if not lunch:
            //     return self._get_expected_attendances(start, stop)
            // else:
            //     return calendar._attendance_intervals_batch(start, stop, self.resource_id, lunch=True)[self.resource_id.id]
            */
            return default;
        }

        public async Task<TEntity> FetchAsync<TEntity>(IEnumerable<TEntity> entities, object field_names) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def fetch(self, field_names):
            // if self.browse().has_access('read'):
            //     return super().fetch(field_names)
            // 
            // # HACK: retrieve publicly available values from hr.employee.public and
            // # copy them to the cache of self; non-public data will be missing from
            // # cache, and interpreted as an access error
            // self._check_private_fields(field_names)
            // self.flush_recordset(field_names)
            // public = self.env['hr.employee.public'].browse(self._ids)
            // public.fetch(field_names)
            // self._copy_cache_from(public, field_names)
            */
            return default;
        }

        public async Task<TEntity> GenerateRandomBarcodeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def generate_random_barcode(self):
            // for employee in self:
            //     employee.barcode = '041'+"".join(choice(digits) for i in range(9))
            */
            return default;
        }

        public async Task<TEntity> GetAgeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_date) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_age(self, target_date=None):
            // self.ensure_one()
            // if target_date is None:
            //     target_date = fields.Date.context_today(self.env.user)
            // return relativedelta(target_date, self.birthday).years if self.birthday else 0
            */
            return default;
        }

        public async Task<TEntity> GetCalendarAttendancesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_calendar_attendances(self, date_from, date_to):
            // self.ensure_one()
            // employee_timezone = timezone(self.tz) if self.tz else None
            // calendar = self.resource_calendar_id or self.company_id.resource_calendar_id
            // return calendar\
            //     .with_context(employee_timezone=employee_timezone)\
            //     .get_work_duration_data(
            //         date_from,
            //         date_to,
            //         domain=[('company_id', 'in', [False, self.company_id.id])])
            */
            return default;
        }

        public async Task<TEntity> GetCalendarsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_mixin.py) ---
            // def _get_calendars(self, date_from=None):
            // return { resource.id: resource.resource_calendar_id or False for resource in self }
            */
            return default;
        }

        public async Task<TEntity> GetCapacityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _get_capacity(self, product):
            // product_capacity = self.capacity_ids.filtered(lambda capacity: capacity.product_id == product)
            // return product_capacity.capacity if product_capacity else self.default_capacity
            */
            return default;
        }

        public async Task<TEntity> GetEmployeeM2oToEmptyOnArchivedEmployeesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_employee_m2o_to_empty_on_archived_employees(self):
            // return ['parent_id', 'coach_id']
            */
            return default;
        }

        public async Task<TEntity> GetExpectedAttendancesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_expected_attendances(self, date_from, date_to):
            // self.ensure_one()
            // employee_timezone = timezone(self.tz) if self.tz else None
            // calendar = self.resource_calendar_id or self.company_id.resource_calendar_id
            // calendar_intervals = calendar._work_intervals_batch(
            //                         date_from,
            //                         date_to,
            //                         tz=employee_timezone,
            //                         resources=self.resource_id,
            //                         compute_leaves=True,
            //                         domain=[('company_id', 'in', [False, self.company_id.id])])[self.resource_id.id]
            // return calendar_intervals
            */
            return default;
        }

        public async Task<TEntity> GetExpectedDurationInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid product_id) where TEntity : IEntity<Guid>, IResourceMixinable
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

        public async Task<TEntity> GetFirstAvailableSlotInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_datetime, object duration, object forward, object leaves_to_ignore, object extra_leaves_slots) where TEntity : IEntity<Guid>, IResourceMixinable
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

        public async Task<TEntity> GetFormviewActionAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_formview_action(self, access_uid=None):
            // """ Override this method in order to redirect many2one towards the right model depending on access_uid """
            // res = super(HrEmployeePrivate, self).get_formview_action(access_uid=access_uid)
            // user = self.env.user
            // if access_uid:
            //     user = self.env['res.users'].browse(access_uid).sudo()
            // 
            // if not user.has_group('hr.group_hr_user'):
            //     res['res_model'] = 'hr.employee.public'
            // 
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetFormviewIdAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_formview_id(self, access_uid=None):
            // """ Override this method in order to redirect many2one towards the right model depending on access_uid """
            // user = self.env.user
            // if access_uid:
            //     user = self.env['res.users'].browse(access_uid).sudo()
            // 
            // if user.has_group('hr.group_hr_user'):
            //     return super(HrEmployeePrivate, self).get_formview_id(access_uid=access_uid)
            // # Hardcode the form view for public employee
            // return self.env.ref('hr.hr_employee_public_view_form').id
            */
            return default;
        }

        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Employees'),
            //     'template': '/hr/static/xls/hr_employee.xls'
            // }]
            */
            return default;
        }

        public async Task<TEntity> GetLeaveDaysDataBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object from_datetime, object to_datetime, object calendar, object domain) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_mixin.py) ---
            // def _get_leave_days_data_batch(self, from_datetime, to_datetime, calendar=None, domain=None):
            // """
            //     By default the resource calendar is used, but it can be
            //     changed using the `calendar` argument.
            // 
            //     `domain` is used in order to recognise the leaves to take,
            //     None means default value ('time_type', '=', 'leave')
            // 
            //     Returns a dict {'days': n, 'hours': h} containing the number of leaves
            //     expressed as days and as hours.
            // """
            // resources = self.mapped('resource_id')
            // mapped_employees = {e.resource_id.id: e.id for e in self}
            // result = {}
            // 
            // # naive datetimes are made explicit in UTC
            // from_datetime = timezone_datetime(from_datetime)
            // to_datetime = timezone_datetime(to_datetime)
            // 
            // mapped_resources = defaultdict(lambda: self.env['resource.resource'])
            // for record in self:
            //     mapped_resources[calendar or record.resource_calendar_id] |= record.resource_id
            // 
            // for calendar, calendar_resources in mapped_resources.items():
            //     # handle fully flexible resources by returning the length of the whole interval
            //     # since we do not take into account leaves for fully flexible resources
            //     if not calendar:
            //         days = (to_datetime - from_datetime).days
            //         hours = (to_datetime - from_datetime).total_seconds() / 3600
            //         for calendar_resource in calendar_resources:
            //             result[calendar_resource.id] = {'days': days, 'hours': hours}
            //         continue
            // 
            //     # compute actual hours per day
            //     attendances = calendar._attendance_intervals_batch(from_datetime, to_datetime, calendar_resources)
            //     leaves = calendar._leave_intervals_batch(from_datetime, to_datetime, calendar_resources, domain)
            // 
            //     for calendar_resource in calendar_resources:
            //         result[calendar_resource.id] = calendar._get_attendance_intervals_days_data(
            //             attendances[calendar_resource.id] & leaves[calendar_resource.id]
            //         )
            // 
            // # convert "resource: result" into "employee: result"
            // return {mapped_employees[r.id]: result[r.id] for r in resources}
            */
            return default;
        }

        public async Task<TEntity> GetMaritalStatusSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_marital_status_selection(self):
            // return [
            //     ('single', _('Single')),
            //     ('married', _('Married')),
            //     ('cohabitant', _('Legal Cohabitant')),
            //     ('widower', _('Widower')),
            //     ('divorced', _('Divorced')),
            // ]
            */
            return default;
        }

        public async Task<TEntity> GetPartnerCountDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_partner_count_depends(self):
            // return ['user_id']
            */
            return default;
        }

        public async Task<TEntity> GetRelatedPartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_related_partners(self):
            // return self.work_contact_id | self.user_id.partner_id
            */
            return default;
        }

        public async Task<TEntity> GetTzBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_tz_batch(self):
            // # Finds the first valid timezone in his tz, his work hours tz,
            // #  the company calendar tz or UTC
            // # Returns a dict {employee_id: tz}
            // return {emp.id: emp._get_tz() for emp in self}
            */
            return default;
        }

        public async Task<TEntity> GetTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_tz(self):
            // # Finds the first valid timezone in his tz, his work hours tz,
            // #  the company calendar tz or UTC and returns it as a string
            // self.ensure_one()
            // return self.tz or\
            //        self.resource_calendar_id.tz or\
            //        self.company_id.resource_calendar_id.tz or\
            //        'UTC'
            */
            return default;
        }

        public async Task<TEntity> GetUnavailabilityIntervalsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_datetime, object end_datetime) where TEntity : IEntity<Guid>, IResourceMixinable
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

        public async Task<TEntity> GetUnusualDaysInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_unusual_days(self, date_from, date_to=None):
            // # Checking the calendar directly allows to not grey out the leaves taken
            // # by the employee or fallback to the company calendar
            // return (self.resource_calendar_id or self.env.company.resource_calendar_id)._get_unusual_days(
            //     datetime.combine(fields.Date.from_string(date_from), time.min).replace(tzinfo=UTC),
            //     datetime.combine(fields.Date.from_string(date_to), time.max).replace(tzinfo=UTC),
            //     self.company_id,
            // )
            */
            return default;
        }

        public async Task<TEntity> GetUserM2oToEmptyOnArchivedEmployeesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_user_m2o_to_empty_on_archived_employees(self):
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetViewAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_view(self, view_id=None, view_type='form', **options):
            // if self.browse().has_access('read'):
            //     return super().get_view(view_id, view_type, **options)
            // return self.env['hr.employee.public'].get_view(view_id, view_type, **options)
            */
            return default;
        }

        public async Task<TEntity> GetViewsAsync<TEntity>(IEnumerable<TEntity> entities, object views, object options) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_views(self, views, options=None):
            // if self.browse().has_access('read'):
            //     return super().get_views(views, options)
            // res = self.env['hr.employee.public'].get_views(views, options)
            // res['models'].update({'hr.employee': res['models']['hr.employee.public']})
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetWeekRangeAndFirstLastDaysInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
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

        public async Task<TEntity> GetWorkDaysDataBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object from_datetime, object to_datetime, object compute_leaves, object calendar, object domain) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_mixin.py) ---
            // def _get_work_days_data_batch(self, from_datetime, to_datetime, compute_leaves=True, calendar=None, domain=None):
            // """
            //     By default the resource calendar is used, but it can be
            //     changed using the `calendar` argument.
            // 
            //     `domain` is used in order to recognise the leaves to take,
            //     None means default value ('time_type', '=', 'leave')
            // 
            //     Returns a dict {'days': n, 'hours': h} containing the
            //     quantity of working time expressed as days and as hours.
            // """
            // resources = self.mapped('resource_id')
            // mapped_employees = {e.resource_id.id: e.id for e in self}
            // result = {}
            // 
            // # naive datetimes are made explicit in UTC
            // from_datetime = timezone_datetime(from_datetime)
            // to_datetime = timezone_datetime(to_datetime)
            // 
            // if calendar:
            //     mapped_resources = {calendar: self.resource_id}
            // else:
            //     calendar_by_resource = self._get_calendars(from_datetime)
            //     mapped_resources = defaultdict(lambda: self.env['resource.resource'])
            //     for resource in self:
            //         mapped_resources[calendar_by_resource[resource.id]] |= resource.resource_id
            // 
            // for calendar, calendar_resources in mapped_resources.items():
            //     if not calendar:
            //         for calendar_resource in calendar_resources:
            //             result[calendar_resource.id] = {'days': 0, 'hours': 0}
            //         continue
            // 
            //     # actual hours per day
            //     if compute_leaves:
            //         intervals = calendar._work_intervals_batch(from_datetime, to_datetime, calendar_resources, domain)
            //     else:
            //         intervals = calendar._attendance_intervals_batch(from_datetime, to_datetime, calendar_resources)
            // 
            //     for calendar_resource in calendar_resources:
            //         result[calendar_resource.id] = calendar._get_attendance_intervals_days_data(intervals[calendar_resource.id])
            // 
            // # convert "resource: result" into "employee: result"
            // return {mapped_employees[r.id]: result[r.id] for r in resources}
            */
            return default;
        }

        public async Task<TEntity> GetWorkDaysDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object from_datetime, object to_datetime, object compute_leaves, object calendar, object domain) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll, FILE: resource_mixin.py) ---
            // def _get_work_days_data(self, from_datetime, to_datetime, compute_leaves=True, calendar=None, domain=None):
            // """
            //     By default the resource calendar is used, but it can be
            //     changed using the `calendar` argument.
            // 
            //     `domain` is used in order to recognise the leaves to take,
            //     None means default value ('time_type', '=', 'leave')
            // 
            //     Returns a dict {'days': n, 'hours': h} containing the
            //     quantity of working time expressed as days and as hours.
            // """
            // resource = self.resource_id
            // calendar = calendar or self.resource_calendar_id
            // 
            // # naive datetimes are made explicit in UTC
            // if not from_datetime.tzinfo:
            //     from_datetime = from_datetime.replace(tzinfo=utc)
            // if not to_datetime.tzinfo:
            //     to_datetime = to_datetime.replace(tzinfo=utc)
            // 
            // # total hours per day: retrieve attendances with one extra day margin,
            // # in order to compute the total hours on the first and last days
            // from_full = from_datetime - timedelta(days=1)
            // to_full = to_datetime + timedelta(days=1)
            // intervals = calendar._attendance_intervals_batch(from_full, to_full, resource)
            // day_total = defaultdict(float)
            // for start, stop, meta in intervals[resource.id]:
            //     day_total[start.date()] += (stop - start).total_seconds() / 3600
            // 
            // # actual hours per day
            // if compute_leaves:
            //     intervals = calendar._work_intervals_batch(from_datetime, to_datetime, resource, domain)
            // else:
            //     intervals = calendar._attendance_intervals_batch(from_datetime, to_datetime, resource)
            // day_hours = defaultdict(float)
            // for start, stop, meta in intervals[resource.id]:
            //     day_hours[start.date()] += (stop - start).total_seconds() / 3600
            // 
            // # compute number of days as quarters
            // days = sum(
            //     float_utils.round(ROUNDING_FACTOR * day_hours[day] / day_total[day]) / ROUNDING_FACTOR
            //     for day in day_hours
            // )
            // return {
            //     'days': days,
            //     'hours': sum(day_hours.values()),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetWorkcenterLoadPerWeekInternalAsync<TEntity>(IEnumerable<TEntity> entities, object week_range, object date_start, object date_stop) where TEntity : IEntity<Guid>, IResourceMixinable
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

        public async Task<TEntity> InverseKmHomeWorkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _inverse_km_home_work(self):
            // for employee in self:
            //     employee.distance_home_work = employee.km_home_work / 1.609 if employee.distance_home_work_unit == "miles" else employee.km_home_work
            */
            return default;
        }

        public async Task<TEntity> LangGetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _lang_get(self):
            // return self.env['res.lang'].get_installed()
            */
            return default;
        }

        public async Task<TEntity> ListLeavesAsync<TEntity>(IEnumerable<TEntity> entities, object from_datetime, object to_datetime, object calendar, object domain) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_mixin.py) ---
            // def list_leaves(self, from_datetime, to_datetime, calendar=None, domain=None):
            // """
            //     By default the resource calendar is used, but it can be
            //     changed using the `calendar` argument.
            // 
            //     `domain` is used in order to recognise the leaves to take,
            //     None means default value ('time_type', '=', 'leave')
            // 
            //     Returns a list of tuples (day, hours, resource.calendar.leaves)
            //     for each leave in the calendar.
            // """
            // resource = self.resource_id
            // calendar = calendar or self.resource_calendar_id
            // 
            // # naive datetimes are made explicit in UTC
            // if not from_datetime.tzinfo:
            //     from_datetime = from_datetime.replace(tzinfo=utc)
            // if not to_datetime.tzinfo:
            //     to_datetime = to_datetime.replace(tzinfo=utc)
            // 
            // attendances = calendar._attendance_intervals_batch(from_datetime, to_datetime, resource)[resource.id]
            // leaves = calendar._leave_intervals_batch(from_datetime, to_datetime, resource, domain)[resource.id]
            // result = []
            // for start, stop, leave in (leaves & attendances):
            //     hours = (stop - start).total_seconds() / 3600
            //     result.append((start.date(), hours, leave))
            // return result
            */
            return default;
        }

        public async Task<TEntity> ListWorkTimePerDayInternalAsync<TEntity>(IEnumerable<TEntity> entities, object from_datetime, object to_datetime, object calendar, object domain) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_mixin.py) ---
            // def _list_work_time_per_day(self, from_datetime, to_datetime, calendar=None, domain=None):
            // """
            //     By default the resource calendar is used, but it can be
            //     changed using the `calendar` argument.
            // 
            //     `domain` is used in order to recognise the leaves to take,
            //     None means default value ('time_type', '=', 'leave')
            // 
            //     Returns a list of tuples (day, hours) for each day
            //     containing at least an attendance.
            // """
            // result = {}
            // records_by_calendar = defaultdict(lambda: self.env[self._name])
            // for record in self:
            //     records_by_calendar[calendar or record.resource_calendar_id or record.company_id.resource_calendar_id] += record
            // 
            // # naive datetimes are made explicit in UTC
            // if not from_datetime.tzinfo:
            //     from_datetime = from_datetime.replace(tzinfo=utc)
            // if not to_datetime.tzinfo:
            //     to_datetime = to_datetime.replace(tzinfo=utc)
            // compute_leaves = self.env.context.get('compute_leaves', True)
            // 
            // for calendar, records in records_by_calendar.items():
            //     resources = self.resource_id
            //     all_intervals = calendar._work_intervals_batch(from_datetime, to_datetime, resources, domain, compute_leaves=compute_leaves)
            //     for record in records:
            //         intervals = all_intervals[record.resource_id.id]
            //         record_result = defaultdict(float)
            //         for start, stop, meta in intervals:
            //             if calendar.flexible_hours:
            //                 record_result[start.date()] = meta.duration_hours
            //             else:
            //                 record_result[start.date()] += (stop - start).total_seconds() / 3600
            //         result[record.id] = sorted(record_result.items())
            // return result
            */
            return default;
        }

        public async Task<TEntity> LoadScenarioInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _load_scenario(self):
            // demo_tag = self.env.ref('hr.employee_category_demo', raise_if_not_found=False)
            // if demo_tag:
            //     return
            // convert.convert_file(self.env, 'hr', 'data/scenarios/hr_scenario.xml', None, mode='init', kind='data')
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnerFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _mail_get_partner_fields(self, introspect_fields=False):
            // return ['user_partner_id']
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _onchange_company_id(self):
            // if self._origin:
            //     return {'warning': {
            //         'title': _("Warning"),
            //         'message': _("To avoid multi company issues (losing the access to your previous contracts, leaves, ...), you should create another employee in the new company instead.")
            //     }}
            */
            return default;
        }

        public async Task<TEntity> OnchangeTimezoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _onchange_timezone(self):
            // if self.resource_calendar_id and not self.tz:
            //     self.tz = self.resource_calendar_id.tz
            */
            return default;
        }

        public async Task<TEntity> OnchangeUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _onchange_user(self):
            // self.update(self._sync_user(self.user_id, (bool(self.image_1920))))
            // if not self.name:
            //     self.name = self.user_id.name
            */
            return default;
        }

        public async Task<TEntity> PhoneGetNumberFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _phone_get_number_fields(self):
            // return ['mobile_phone']
            */
            return default;
        }

        public async Task<TEntity> PrepareGraphDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object load_data, object week_range) where TEntity : IEntity<Guid>, IResourceMixinable
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

        public async Task<TEntity> PrepareResourceValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object tz) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _prepare_resource_values(self, vals, tz):
            // resource_vals = super()._prepare_resource_values(vals, tz)
            // vals.pop('name')  # Already considered by super call but no popped
            // # We need to pop it to avoid useless resource update (& write) call
            // # on every newly created resource (with the correct name already)
            // user_id = vals.pop('user_id', None)
            // if user_id:
            //     resource_vals['user_id'] = user_id
            // active_status = vals.get('active')
            // if active_status is not None:
            //     resource_vals['active'] = active_status
            // return resource_vals
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_mixin.py) ---
            // def _prepare_resource_values(self, vals, tz):
            // resource_vals = {'name': vals.get(self._rec_name)}
            // if tz:
            //     resource_vals['tz'] = tz
            // company_id = vals.get('company_id', self.env.company.id)
            // if company_id:
            //     resource_vals['company_id'] = company_id
            // calendar_id = vals.get('resource_calendar_id')
            // if calendar_id:
            //     resource_vals['calendar_id'] = calendar_id
            // return resource_vals
            */
            return default;
        }

        public async Task<TEntity> RemoveWorkContactIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user, object employee_company) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _remove_work_contact_id(self, user, employee_company):
            // """ Remove work_contact_id for previous employee if the user is assigned to a new employee """
            // employee_company = employee_company or self.company_id.id
            // # For employees with a user_id, the constraint (user can't be linked to multiple employees) is triggered
            // old_partner_employee_ids = user.partner_id.employee_ids.filtered(lambda e:
            //     not e.user_id
            //     and e.company_id.id == employee_company
            //     and e != self
            // )
            // old_partner_employee_ids.work_contact_id = None
            */
            return default;
        }

        public async Task<TEntity> SearchFetchAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object field_names, object offset, object limit, object order) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def search_fetch(self, domain, field_names, offset=0, limit=None, order=None):
            // if self.browse().has_access('read'):
            //     return super().search_fetch(domain, field_names, offset, limit, order)
            // 
            // # HACK: retrieve publicly available values from hr.employee.public and
            // # copy them to the cache of self; non-public data will be missing from
            // # cache, and interpreted as an access error
            // self._check_private_fields(field_names)
            // self.flush_model(field_names)
            // public = self.env['hr.employee.public'].search_fetch(domain, field_names, offset, limit, order)
            // employees = self.browse(public._ids)
            // employees._copy_cache_from(public, field_names)
            // return employees
            */
            return default;
        }

        public async Task<TEntity> SearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object offset, object limit, object order) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _search(self, domain, offset=0, limit=None, order=None):
            // """
            //     We override the _search because it is the method that checks the access rights
            //     This is correct to override the _search. That way we enforce the fact that calling
            //     search on an hr.employee returns a hr.employee recordset, even if you don't have access
            //     to this model, as the result of _search (the ids of the public employees) is to be
            //     browsed on the hr.employee model. This can be trusted as the ids of the public
            //     employees exactly match the ids of the related hr.employee.
            // """
            // if self.browse().has_access('read'):
            //     return super()._search(domain, offset, limit, order)
            // try:
            //     ids = self.env['hr.employee.public']._search(domain, offset, limit, order)
            // except ValueError:
            //     raise AccessError(_('You do not have access to this document.'))
            // # the result is expected from this table, so we should link tables
            // return super(HrEmployeePrivate, self.sudo())._search([('id', 'in', ids)], order=order)
            */
            return default;
        }

        public async Task<TEntity> SyncUserInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user, object employee_has_image) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _sync_user(self, user, employee_has_image=False):
            // vals = dict(
            //     work_contact_id=user.partner_id.id if user else self.work_contact_id.id,
            //     user_id=user.id,
            // )
            // if not employee_has_image:
            //     vals['image_1920'] = user.image_1920
            // if user.tz:
            //     vals['tz'] = user.tz
            // return vals
            */
            return default;
        }

        public async Task<TEntity> ToggleActiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def toggle_active(self):
            // res = super(HrEmployeePrivate, self).toggle_active()
            // unarchived_employees = self.filtered(lambda employee: employee.active)
            // unarchived_employees.write({
            //     'departure_reason_id': False,
            //     'departure_description': False,
            //     'departure_date': False
            // })
            // 
            // archived_employees = self.filtered(lambda e: not e.active)
            // if archived_employees:
            //     # Empty links to this employees (example: manager, coach, time off responsible, ...)
            //     employee_fields_to_empty = self._get_employee_m2o_to_empty_on_archived_employees()
            //     user_fields_to_empty = self._get_user_m2o_to_empty_on_archived_employees()
            //     employee_domain = [[(field, 'in', archived_employees.ids)] for field in employee_fields_to_empty]
            //     user_domain = [[(field, 'in', archived_employees.user_id.ids)] for field in user_fields_to_empty]
            //     employees = self.env['hr.employee'].search(expression.OR(employee_domain + user_domain))
            //     for employee in employees:
            //         for field in employee_fields_to_empty:
            //             if employee[field] in archived_employees:
            //                 employee[field] = False
            //         for field in user_fields_to_empty:
            //             if employee[field] in archived_employees.user_id:
            //                 employee[field] = False
            // 
            // if len(self) == 1 and not self.active and not self.env.context.get('no_wizard', False):
            //     return {
            //         'type': 'ir.actions.act_window',
            //         'name': _('Register Departure'),
            //         'res_model': 'hr.departure.wizard',
            //         'view_mode': 'form',
            //         'target': 'new',
            //         'context': {'active_id': self.id},
            //         'views': [[False, 'form']]
            //     }
            // return res
            */
            return default;
        }

        public async Task<TEntity> UnblockAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
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
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def unlink(self):
            // resources = self.mapped('resource_id')
            // super(HrEmployeePrivate, self).unlink()
            // return resources.unlink()
            */
            return default;
        }

        public async Task<TEntity> VerifyBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _verify_barcode(self):
            // for employee in self:
            //     if employee.barcode:
            //         if not (re.match(r'^[A-Za-z0-9]+$', employee.barcode) and len(employee.barcode) <= 18):
            //             raise ValidationError(_("The Badge ID must be alphanumeric without any accents and no longer than 18 characters."))
            */
            return default;
        }

        public async Task<TEntity> VerifyPinInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _verify_pin(self):
            // for employee in self:
            //     if employee.pin and not employee.pin.isdigit():
            //         raise ValidationError(_("The PIN must be a sequence of digits."))
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IResourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def write(self, vals):
            // if 'work_contact_id' in vals:
            //     account_ids = vals.get('bank_account_id') or self.bank_account_id.ids
            //     if account_ids:
            //         bank_accounts = self.env['res.partner.bank'].sudo().browse(account_ids)
            //         for bank_account in bank_accounts:
            //             if vals['work_contact_id'] != bank_account.partner_id.id:
            //                 if bank_account.allow_out_payment:
            //                     bank_account.allow_out_payment = False
            //                 if vals['work_contact_id']:
            //                     bank_account.partner_id = vals['work_contact_id']
            //     self.message_unsubscribe(self.work_contact_id.ids)
            //     if vals['work_contact_id']:
            //         self._message_subscribe([vals['work_contact_id']])
            // if vals.get('user_id'):
            //     # Update the profile pictures with user, except if provided
            //     user = self.env['res.users'].browse(vals['user_id'])
            //     vals.update(self._sync_user(user, (bool(all(emp.image_1920 for emp in self)))))
            //     self._remove_work_contact_id(user, vals.get('company_id'))
            // if 'work_permit_expiration_date' in vals:
            //     vals['work_permit_scheduled_activity'] = False
            // res = super(HrEmployeePrivate, self).write(vals)
            // if vals.get('department_id') or vals.get('user_id'):
            //     department_id = vals['department_id'] if vals.get('department_id') else self[:1].department_id.id
            //     # When added to a department or changing user, subscribe to the channels auto-subscribed by department
            //     self.env['discuss.channel'].sudo().search([
            //         ('subscription_department_ids', 'in', department_id)
            //     ])._subscribe_users_automatically()
            // if vals.get('departure_description'):
            //     for employee in self:
            //         employee.message_post(body=_(
            //             'Additional Information: \n %(description)s',
            //             description=vals.get('departure_description')))
            // return res
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def write(self, vals):
            // if 'company_id' in vals:
            //     self.resource_id.company_id = vals['company_id']
            // return super(MrpWorkcenter, self).write(vals)
            */
            return default;
        }
    }
}