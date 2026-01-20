using Volo.Abp.ObjectMapping;
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
        private readonly IServiceProvider _serviceProvider;
        public HrEmployeeBaseAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ActionCreateUserAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> ActionOpenLeaveRequestAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py) ---
            // def action_open_leave_request(self):
            // if len(self) == 1:
            //     model = 'hr.leave'
            //     context = {'default_employee_id': self.id}
            // else:
            //     model = 'hr.leave.generate.multi.wizard'
            //     context = {
            //         'default_employee_ids': self.ids,
            //         'default_date_from': fields.Date.today(),
            //         'default_date_to': fields.Date.today(),
            //         'default_name': _('Unplanned Absence'),
            //     }
            // 
            // return {
            //     'type': 'ir.actions.act_window',
            //     'res_model': model,
            //     'views': [[False, 'form']],
            //     'view_mode': 'form',
            //     'context': context,
            //     'target': 'new',
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionRelatedContactsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> ActionSendLogAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py) ---
            // def action_send_log(self):
            // if not self.env.user.has_group('hr.group_hr_manager'):
            //     raise UserError(_("You don't have the right to do this. Please contact an Administrator."))
            // 
            // for employee in self:
            //     employee.message_post(body=_(
            //         "%(name)s has been noted as %(state)s today",
            //         name=employee.name,
            //         state=employee.hr_presence_state_display))
            */
            return default;
        }

        public async Task<TEntity> ActionSendSmsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py) ---
            // def action_send_sms(self):
            //         if not self.env.user.has_group('hr.group_hr_manager'):
            //             raise UserError(_("You don't have the right to do this. Please contact an Administrator."))
            // 
            //         context = dict(self.env.context)
            //         context.update(default_res_model='hr.employee', default_res_ids=self.ids, default_composition_mode='mass', default_number_field_name='mobile_phone', default_mass_keep_log=True)
            // 
            //         template = self.env.ref('hr_presence.sms_template_presence', False)
            //         if not template:
            //             context['default_body'] = _("""We hope this message finds you well. It has come to our attention that you are currently not present at work, and there is no record of a time off request from you. If this absence is due to an oversight on our part, we sincerely apologize for any confusion.
            // Please take the necessary steps to address this unplanned absence. Should you have any questions or need assistance, do not hesitate to reach out to your manager or the HR department at your earliest convenience.
            // Thank you for your prompt attention to this matter.""")
            //         else:
            //             context['default_template_id'] = template.id
            // 
            //         return {
            //             "type": "ir.actions.act_window",
            //             "res_model": "sms.composer",
            //             "view_mode": 'form',
            //             "context": context,
            //             "name": self.env._("Send SMS"),
            //             "target": "new",
            //         }
            */
            return default;
        }

        public async Task<TEntity> ActionSetAbsentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py) ---
            // def action_set_absent(self):
            // self._action_set_manual_presence(False)
            */
            return default;
        }

        public async Task<TEntity> ActionSetManualPresenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object state) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py) ---
            // def _action_set_manual_presence(self, state):
            // if not self.env.user.has_group('hr.group_hr_manager'):
            //     raise UserError(_("You don't have the right to do this. Please contact an Administrator."))
            // self.write({
            //     'manually_set_present': state,
            //     'manually_set_presence': True,
            //     "hr_presence_state_display": 'present' if state else 'absent',
            // })
            */
            return default;
        }

        public async Task<TEntity> ActionSetPresentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py) ---
            // def action_set_present(self):
            // self._action_set_manual_presence(True)
            */
            return default;
        }

        public async Task<TEntity> CheckFieldAccessRightsAsync<TEntity>(IEnumerable<TEntity> entities, object operation, object field_names) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> CheckPresenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py) ---
            // def _check_presence(self):
            // company = self.env.company
            // employees = self.env['hr.employee'].search([('company_id', '=', company.id)])
            // 
            // employees.write({
            //     'email_sent': False,
            //     'ip_connected': False,
            //     'manually_set_present': False,
            //     'manually_set_presence': False,
            // })
            // 
            // all_employees = employees
            // 
            // 
            // # Check on IP
            // if company.hr_presence_control_ip:
            //     ip_list = company.hr_presence_control_ip_list
            //     ip_list = ip_list.split(',') if ip_list else []
            //     ip_employees = self.env['hr.employee']
            //     for employee in employees:
            //         employee_ips = self.env['res.users.log'].sudo().search([
            //             ('create_uid', '=', employee.user_id.id),
            //             ('ip', '!=', False),
            //             ('create_date', '>=', Datetime.to_string(Datetime.now().replace(hour=0, minute=0, second=0, microsecond=0)))]
            //         ).mapped('ip')
            //         if any(ip in ip_list for ip in employee_ips):
            //             ip_employees |= employee
            //     ip_employees.write({'ip_connected': True})
            //     employees = employees - ip_employees
            // 
            // # Check on sent emails
            // if company.hr_presence_control_email:
            //     email_employees = self.env['hr.employee']
            //     threshold = company.hr_presence_control_email_amount
            //     for employee in employees:
            //         sent_emails = self.env['mail.message'].search_count([
            //             ('author_id', '=', employee.user_id.partner_id.id),
            //             ('date', '>=', Datetime.to_string(Datetime.now().replace(hour=0, minute=0, second=0, microsecond=0))),
            //             ('date', '<=', Datetime.to_string(Datetime.now()))])
            //         if sent_emails >= threshold:
            //             email_employees |= employee
            //     email_employees.write({'email_sent': True})
            //     employees = employees - email_employees
            // 
            // company.sudo().hr_presence_last_compute_date = Datetime.now()
            // 
            // for employee in all_employees:
            //     employee.hr_presence_state_display = employee.hr_presence_state
            */
            return default;
        }

        public async Task<TEntity> CheckPrivateFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_names) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> CheckSsnidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> ComputeAddressIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py) ---
            // def _compute_address_id(self):
            // for employee in self:
            //     address = employee.company_id.partner_id.address_get(['default'])
            //     employee.address_id = address['default'] if address else False
            */
            return default;
        }

        public async Task<TEntity> ComputeAllocationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_base.py) ---
            // def _compute_allocation_count(self):
            // # Don't get allocations that are expired
            // current_date = date.today()
            // data = self.env['hr.leave.allocation']._read_group([
            //     ('employee_id', 'in', self.ids),
            //     ('holiday_status_id.active', '=', True),
            //     ('holiday_status_id.requires_allocation', '=', 'yes'),
            //     ('state', '=', 'validate'),
            //     ('date_from', '<=', current_date),
            //     '|',
            //     ('date_to', '=', False),
            //     ('date_to', '>=', current_date),
            // ], ['employee_id'], ['__count', 'number_of_days:sum'])
            // rg_results = {employee.id: (count, days) for employee, count, days in data}
            // for employee in self:
            //     count, days = rg_results.get(employee.id, (0, 0))
            //     employee.allocation_count = float_round(days, precision_digits=2)
            //     employee.allocations_count = count
            */
            return default;
        }

        public async Task<TEntity> ComputeAllocationRemainingDisplayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_base.py) ---
            // def _compute_allocation_remaining_display(self):
            // current_date = date.today()
            // allocations = self.env['hr.leave.allocation'].search([('employee_id', 'in', self.ids)])
            // leaves_taken = self._get_consumed_leaves(allocations.holiday_status_id)[0]
            // for employee in self:
            //     employee_remaining_leaves = 0
            //     employee_max_leaves = 0
            //     for leave_type in leaves_taken[employee]:
            //         if leave_type.requires_allocation == 'no' or not leave_type.show_on_dashboard:
            //             continue
            //         for allocation in leaves_taken[employee][leave_type]:
            //             if allocation and allocation.date_from <= current_date\
            //                     and (not allocation.date_to or allocation.date_to >= current_date):
            //                 virtual_remaining_leaves = leaves_taken[employee][leave_type][allocation]['virtual_remaining_leaves']
            //                 employee_remaining_leaves += virtual_remaining_leaves\
            //                     if leave_type.request_unit in ['day', 'half_day']\
            //                     else virtual_remaining_leaves / (employee.resource_calendar_id.hours_per_day or HOURS_PER_DAY)
            //                 employee_max_leaves += allocation.number_of_days
            //     employee.allocation_remaining_display = "%g" % float_round(employee_remaining_leaves, precision_digits=2)
            //     employee.allocation_display = "%g" % float_round(employee_max_leaves, precision_digits=2)
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1024InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar_1024(self):
            // super()._compute_avatar_1024()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar128InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar_128(self):
            // super()._compute_avatar_128()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1920InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar_1920(self):
            // super()._compute_avatar_1920()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar256InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar_256(self):
            // super()._compute_avatar_256()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar512InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar_512(self):
            // super()._compute_avatar_512()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatarInternalAsync<TEntity>(IEnumerable<TEntity> entities, object avatar_field, object image_field) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> ComputeChildCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_org_chart, FILE: hr_org_chart_mixin.py) ---
            // def _compute_child_count(self):
            // employee_read_group = self._read_group(
            //     [('parent_id', 'in', self.ids)],
            //     ['parent_id'],
            //     ['id:count'],
            // )
            // child_count_per_parent_id = dict(employee_read_group)
            // for employee in self:
            //     employee.child_count = child_count_per_parent_id.get(employee._origin, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeCoachInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py) ---
            // def _compute_coach(self):
            // for employee in self:
            //     manager = employee.parent_id
            //     previous_manager = employee._origin.parent_id
            //     if manager and (employee.coach_id == previous_manager or not employee.coach_id):
            //         employee.coach_id = manager
            //     elif not employee.coach_id:
            //         employee.coach_id = False
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> ComputeEmployeeBadgesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_gamification, FILE: hr_employee.py) ---
            // def _compute_employee_badges(self):
            // for employee in self:
            //     badge_ids = self.env['gamification.badge.user'].search([
            //         '|', ('employee_id', 'in', employee.ids),
            //              '&', ('employee_id', '=', False),
            //                   ('user_id', 'in', employee.user_id.ids)
            //     ])
            //     employee.has_badges = bool(badge_ids)
            //     employee.badge_ids = badge_ids
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeeGoalsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_gamification, FILE: hr_employee.py) ---
            // def _compute_employee_goals(self):
            // for employee in self:
            //     employee.goal_ids = self.env['gamification.goal'].search([
            //         ('user_id', '=', employee.user_id.id),
            //         ('challenge_id.challenge_category', '=', 'hr'),
            //     ])
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py) ---
            // def _compute_employee_id(self):
            // for employee in self:
            //     employee.employee_id = self.env['hr.employee'].browse(employee.id)
            */
            return default;
        }

        public async Task<TEntity> ComputeExceptionalLocationIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_homeworking, FILE: hr_employee.py) ---
            // def _compute_exceptional_location_id(self):
            // today = fields.Date.today()
            // current_employee_locations = self.env['hr.employee.location'].search([
            //     ('employee_id', 'in', self.ids),
            //     ('date', '=', today),
            // ])
            // employee_work_locations = {l.employee_id.id: l.work_location_id for l in current_employee_locations}
            // 
            // for employee in self:
            //     employee.exceptional_location_id = employee_work_locations.get(employee.id, False)
            */
            return default;
        }

        public async Task<TEntity> ComputeIsFlexibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py) ---
            // def _compute_is_flexible(self):
            // for employee in self:
            //     employee.is_fully_flexible = not employee.resource_calendar_id
            //     employee.is_flexible = employee.is_fully_flexible or employee.resource_calendar_id.flexible_hours
            */
            return default;
        }

        public async Task<TEntity> ComputeIsManagerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py) ---
            // def _compute_is_manager(self):
            // all_reports = self.env['hr.employee.public'].search([('id', 'child_of', self.env.user.employee_id.id)]).ids
            // for employee in self:
            //     employee.is_manager = employee.id in all_reports
            */
            return default;
        }

        public async Task<TEntity> ComputeIsSubordinateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_org_chart, FILE: hr_org_chart_mixin.py) ---
            // def _compute_is_subordinate(self):
            // subordinates = self.env.user.employee_id.subordinate_ids
            // if not subordinates:
            //     self.is_subordinate = False
            // else:
            //     for employee in self:
            //         employee.is_subordinate = employee.id in subordinates.ids
            */
            return default;
        }

        public async Task<TEntity> ComputeJobTitleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py) ---
            // def _compute_job_title(self):
            // for employee in self.filtered('job_id'):
            //     employee.job_title = employee.job_id.name
            */
            return default;
        }

        public async Task<TEntity> ComputeKmHomeWorkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_km_home_work(self):
            // for employee in self:
            //     employee.km_home_work = employee.distance_home_work * 1.609 if employee.distance_home_work_unit == "miles" else employee.distance_home_work
            */
            return default;
        }

        public async Task<TEntity> ComputeLastActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py) ---
            // def _compute_last_activity(self):
            // presences = self.env['bus.presence'].search_read([('user_id', 'in', self.mapped('user_id').ids)], ['user_id', 'last_presence'])
            // # transform the result to a dict with this format {user.id: last_presence}
            // presences = {p['user_id'][0]: p['last_presence'] for p in presences}
            // 
            // for employee in self:
            //     tz = employee.tz
            //     last_presence = presences.get(employee.user_id.id, False)
            //     if last_presence:
            //         last_activity_datetime = last_presence.replace(tzinfo=UTC).astimezone(timezone(tz)).replace(tzinfo=None)
            //         employee.last_activity = last_activity_datetime.date()
            //         if employee.last_activity == fields.Date.today():
            //             employee.last_activity_time = format_time(self.env, last_presence, time_format='short')
            //         else:
            //             employee.last_activity_time = False
            //     else:
            //         employee.last_activity = False
            //         employee.last_activity_time = False
            */
            return default;
        }

        public async Task<TEntity> ComputeLeaveManagerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_base.py) ---
            // def _compute_leave_manager(self):
            // for employee in self:
            //     previous_manager = employee._origin.parent_id.user_id
            //     manager = employee.parent_id.user_id
            //     if manager and employee.leave_manager_id == previous_manager or not employee.leave_manager_id:
            //         employee.leave_manager_id = manager
            //     elif not employee.leave_manager_id:
            //         employee.leave_manager_id = False
            */
            return default;
        }

        public async Task<TEntity> ComputeLeaveStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_base.py) ---
            // def _compute_leave_status(self):
            // # Used SUPERUSER_ID to forcefully get status of other user's leave, to bypass record rule
            // holidays = self.env['hr.leave'].sudo().search([
            //     ('employee_id', 'in', self.ids),
            //     ('date_from', '<=', fields.Datetime.now()),
            //     ('date_to', '>=', fields.Datetime.now()),
            //     ('state', '=', 'validate'),
            // ])
            // leave_data = {}
            // for holiday in holidays:
            //     leave_data[holiday.employee_id.id] = {}
            //     leave_data[holiday.employee_id.id]['leave_date_from'] = holiday.date_from.date()
            //     back_on = holiday.employee_id._get_first_working_interval(holiday.date_to)
            //     leave_data[holiday.employee_id.id]['leave_date_to'] = back_on.date() if back_on else None
            //     leave_data[holiday.employee_id.id]['current_leave_state'] = holiday.state
            // 
            // for employee in self:
            //     employee.leave_date_from = leave_data.get(employee.id, {}).get('leave_date_from')
            //     employee.leave_date_to = leave_data.get(employee.id, {}).get('leave_date_to')
            //     employee.current_leave_state = leave_data.get(employee.id, {}).get('current_leave_state')
            //     employee.is_absent = leave_data.get(employee.id) and leave_data.get(employee.id).get('current_leave_state') == 'validate'
            */
            return default;
        }

        public async Task<TEntity> ComputeManagerOnlyFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py) ---
            // def _compute_manager_only_fields(self):
            // manager_fields = self._get_manager_only_fields()
            // for employee in self:
            //     if employee.is_manager:
            //         employee_sudo = employee.employee_id.sudo()
            //         for f in manager_fields:
            //             employee[f] = employee_sudo[f]
            //     else:
            //         for f in manager_fields:
            //             employee[f] = False
            */
            return default;
        }

        public async Task<TEntity> ComputeNewlyHiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py) ---
            // def _compute_newly_hired(self):
            // new_hire_field = self._get_new_hire_field()
            // new_hire_date = fields.Datetime.now() - timedelta(days=90)
            // for employee in self:
            //     if not employee[new_hire_field]:
            //         employee.newly_hired = False
            //     elif not isinstance(employee[new_hire_field], datetime):
            //         employee.newly_hired = employee[new_hire_field] > new_hire_date.date()
            //     else:
            //         employee.newly_hired = employee[new_hire_field] > new_hire_date
            */
            return default;
        }

        public async Task<TEntity> ComputeParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py) ---
            // def _compute_parent_id(self):
            // for employee in self.filtered('department_id.manager_id'):
            //     employee.parent_id = employee.department_id.manager_id
            */
            return default;
        }

        public async Task<TEntity> ComputePartOfDepartmentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py) ---
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
            //     for employee in self:
            //         employee.member_of_department = employee.department_id in child_departments
            */
            return default;
        }

        public async Task<TEntity> ComputePhonesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py) ---
            // def _compute_phones(self):
            // for employee in self:
            //     if employee.address_id and employee.address_id.phone:
            //         employee.work_phone = employee.address_id.phone
            //     else:
            //         employee.work_phone = False
            */
            return default;
        }

        public async Task<TEntity> ComputePresenceIconInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py) ---
            // def _compute_presence_icon(self):
            // """
            // This method compute the state defining the display icon in the kanban view.
            // It can be overriden to add other possibilities, like time off or attendances recordings.
            // """
            // for employee in self:
            //     employee.hr_icon_display = 'presence_' + employee.hr_presence_state
            //     employee.show_hr_icon_display = bool(employee.user_id)
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee_base.py) ---
            // def _compute_presence_icon(self):
            // res = super()._compute_presence_icon()
            // # All employee must chek in or check out. Everybody must have an icon
            // for employee in self:
            //     employee.show_hr_icon_display = employee.company_id.hr_presence_control_attendance or bool(employee.user_id)
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_base.py) ---
            // def _compute_presence_icon(self):
            // super()._compute_presence_icon()
            // employees_absent = self.filtered(
            //     lambda employee: employee.hr_presence_state != 'present' and employee.is_absent)
            // employees_absent.update({'hr_icon_display': 'presence_holiday_absent', 'show_hr_icon_display': True})
            // employees_present = self.filtered(
            //     lambda employee: employee.hr_presence_state == 'present' and employee.is_absent)
            // employees_present.update({'hr_icon_display': 'presence_holiday_present', 'show_hr_icon_display': True})
            --- ODOO METHOD SOURCE (MODULE: hr_homeworking, FILE: hr_employee.py) ---
            // def _compute_presence_icon(self):
            // super()._compute_presence_icon()
            // dayfield = self._get_current_day_location_field()
            // for employee in self:
            //     today_employee_location_id = employee.exceptional_location_id or employee[dayfield]
            //     if not today_employee_location_id or employee.hr_icon_display.startswith('presence_holiday'):
            //         continue
            //     employee.hr_icon_display = f'presence_{today_employee_location_id.location_type}'
            //     employee.show_hr_icon_display = True
            */
            return default;
        }

        public async Task<TEntity> ComputePresenceStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py) ---
            // def _compute_presence_state(self):
            // """
            // This method is overritten in several other modules which add additional
            // presence criterions. e.g. hr_attendance, hr_holidays
            // """
            // # Check on login
            // employee_to_check_working = self.filtered(lambda e: 'offline' in str(e.user_id.im_status))
            // working_now_list = employee_to_check_working._get_employee_working_now()
            // for employee in self:
            //     state = 'out_of_working_hour'
            //     if employee.company_id.hr_presence_control_login:
            //         if employee.user_id._is_user_available():
            //             state = 'present'
            //         elif 'offline' in str(employee.user_id.im_status) and employee.id in working_now_list:
            //             state = 'absent'
            //     if not employee.active:
            //         state = 'archive'
            //     employee.hr_presence_state = state
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee_base.py) ---
            // def _compute_presence_state(self):
            // """
            // Override to include checkin/checkout in the presence state
            // Attendance has the second highest priority after login
            // """
            // super()._compute_presence_state()
            // employees = self.filtered(lambda e: e.hr_presence_state != "present")
            // employee_to_check_working = self.filtered(lambda e: e.attendance_state == "checked_out"
            //                                                     and e.hr_presence_state == "out_of_working_hour")
            // working_now_list = employee_to_check_working._get_employee_working_now()
            // for employee in employees:
            //     if employee.attendance_state == "checked_out" and employee.hr_presence_state == "out_of_working_hour" and \
            //             employee.id in working_now_list:
            //         employee.hr_presence_state = "absent"
            //     elif employee.attendance_state == "checked_in":
            //         employee.hr_presence_state = "present"
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_base.py) ---
            // def _compute_presence_state(self):
            // super()._compute_presence_state()
            // employees = self.filtered(lambda employee: employee.hr_presence_state != 'present' and employee.is_absent)
            // employees.update({'hr_presence_state': 'absent'})
            --- ODOO METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee_base.py) ---
            // def _compute_presence_state(self):
            // super()._compute_presence_state()
            // company = self.env.company
            // working_now_list = self._get_employee_working_now()
            // for employee in self:
            //     if employee.manually_set_presence:
            //         employee.hr_presence_state = employee.hr_presence_state_display
            //         continue
            // 
            //     if not employee.company_id.hr_presence_control_email and not employee.company_id.hr_presence_control_ip:
            //         continue
            //     if company.hr_presence_last_compute_date and employee.id in working_now_list and \
            //             company.hr_presence_last_compute_date.day == fields.Datetime.now().day and \
            //             (employee.email_sent or employee.ip_connected or employee.manually_set_present):
            //         employee.hr_presence_state = 'present'
            //     elif employee.id in working_now_list and employee.is_absent and \
            //         not (employee.email_sent or employee.ip_connected or employee.manually_set_present):
            //         employee.hr_presence_state = 'absent'
            //     else:
            //         employee.hr_presence_state = 'out_of_working_hour'
            */
            return default;
        }

        public async Task<TEntity> ComputeRelatedPartnersCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_related_partners_count(self):
            // self.related_partners_count = len(self._get_related_partners())
            */
            return default;
        }

        public async Task<TEntity> ComputeRemainingLeavesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_base.py) ---
            // def _compute_remaining_leaves(self):
            // remaining = {}
            // if self.ids:
            //     remaining = self._get_remaining_leaves()
            // for employee in self:
            //     value = float_round(remaining.get(employee.id, 0.0), precision_digits=2)
            //     employee.leaves_count = value
            //     employee.remaining_leaves = value
            */
            return default;
        }

        public async Task<TEntity> ComputeShowLeavesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_base.py) ---
            // def _compute_show_leaves(self):
            // show_leaves = self.env.user.has_group('hr_holidays.group_hr_holidays_user')
            // for employee in self:
            //     if show_leaves or employee.user_id == self.env.user:
            //         employee.show_leaves = True
            //     else:
            //         employee.show_leaves = False
            */
            return default;
        }

        public async Task<TEntity> ComputeSubordinatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_org_chart, FILE: hr_org_chart_mixin.py) ---
            // def _compute_subordinates(self):
            // for employee in self:
            //     employee.subordinate_ids = employee._get_subordinates()
            //     employee.child_all_count = len(employee.subordinate_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkContactDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py) ---
            // def _compute_work_contact_details(self):
            // for employee in self:
            //     if employee.work_contact_id:
            //         employee.mobile_phone = employee.work_contact_id.mobile
            //         employee.work_email = employee.work_contact_id.email
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkLocationNameTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py) ---
            // def _compute_work_location_name_type(self):
            // for employee in self:
            //     employee.work_location_name = employee.work_location_id.name or None
            //     employee.work_location_type = employee.work_location_id.location_type or 'other'
            --- ODOO METHOD SOURCE (MODULE: hr_homeworking, FILE: hr_employee.py) ---
            // def _compute_work_location_name_type(self):
            // super()._compute_work_location_name_type()
            // dayfield = self._get_current_day_location_field()
            // for employee in self:
            //     current_location_id = employee.exceptional_location_id or employee[dayfield]
            //     employee.work_location_name = current_location_id.name or employee.work_location_name
            //     employee.work_location_type = current_location_id.location_type or employee.work_location_type
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkPermitNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> CopyCacheFromInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @public, object field_names) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_base.py) ---
            // def create(self, vals_list):
            // if self.env.context.get('salary_simulation'):
            //     return super().create(vals_list)
            // approver_group = self.env.ref('hr_holidays.group_hr_holidays_responsible', raise_if_not_found=False)
            // group_updates = []
            // for vals in vals_list:
            //     if 'parent_id' in vals:
            //         manager = self.env['hr.employee'].browse(vals['parent_id']).user_id
            //         vals['leave_manager_id'] = vals.get('leave_manager_id', manager.id)
            //     if approver_group and vals.get('leave_manager_id'):
            //         group_updates.append((4, vals['leave_manager_id']))
            // if group_updates:
            //     approver_group.sudo().write({'users': group_updates})
            // return super().create(vals_list)
            */
            return default;
        }

        public async Task<TEntity> CreateWorkContactsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py) ---
            // def _create_work_contacts(self):
            // if any(employee.work_contact_id for employee in self):
            //     raise UserError(_('Some employee already have a work contact'))
            // work_contacts = self.env['res.partner'].create([{
            //     'email': employee.work_email,
            //     'mobile': employee.mobile_phone,
            //     'name': employee.name,
            //     'image_1920': employee.image_1920,
            //     'company_id': employee.company_id.id
            // } for employee in self])
            // for employee, work_contact in zip(self, work_contacts):
            //     employee.work_contact_id = work_contact
            */
            return default;
        }

        public async Task<TEntity> CronCheckWorkPermitValidityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> EmployeeAttendanceIntervalsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object stop, object lunch) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> FetchAsync<TEntity>(IEnumerable<TEntity> entities, object field_names) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> GenerateRandomBarcodeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def generate_random_barcode(self):
            // for employee in self:
            //     employee.barcode = '041'+"".join(choice(digits) for i in range(9))
            */
            return default;
        }

        public async Task<TEntity> GetAgeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_date) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> GetAvatarCardDataAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py) ---
            // def get_avatar_card_data(self, fields):
            // return self._read_format(fields)
            */
            return default;
        }

        public async Task<TEntity> GetCalendarAttendancesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> GetCalendarPeriodsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object stop) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py) ---
            // def _get_calendar_periods(self, start, stop):
            // """
            // :param datetime start: the start of the period
            // :param datetime stop: the stop of the period
            // This method can be overridden in other modules where it's possible to have different resource calendars for an
            // employee depending on the date.
            // """
            // calendar_periods_by_employee = {}
            // for employee in self:
            //     calendar = employee.resource_calendar_id or employee.company_id.resource_calendar_id
            //     calendar_periods_by_employee[employee] = [(start, stop, calendar)]
            // return calendar_periods_by_employee
            */
            return default;
        }

        public async Task<TEntity> GetConsumedLeavesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object leave_types, object target_date, object ignore_future) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_base.py) ---
            // def _get_consumed_leaves(self, leave_types, target_date=False, ignore_future=False):
            // employees = self or self._get_contextual_employee()
            // leaves_domain = [
            //     ('holiday_status_id', 'in', leave_types.ids),
            //     ('employee_id', 'in', employees.ids),
            //     ('state', 'in', ['confirm', 'validate1', 'validate']),
            // ]
            // if self.env.context.get('ignored_leave_ids'):
            //     leaves_domain.append(('id', 'not in', self.env.context.get('ignored_leave_ids')))
            // 
            // if not target_date:
            //     target_date = fields.Date.today()
            // if ignore_future:
            //     leaves_domain.append(('date_from', '<=', target_date))
            // leaves = self.env['hr.leave'].search(leaves_domain)
            // leaves_per_employee_type = defaultdict(lambda: defaultdict(lambda: self.env['hr.leave']))
            // for leave in leaves:
            //     leaves_per_employee_type[leave.employee_id][leave.holiday_status_id] |= leave
            // 
            // allocations = self.env['hr.leave.allocation'].with_context(active_test=False).search([
            //     ('employee_id', 'in', employees.ids),
            //     ('holiday_status_id', 'in', leave_types.ids),
            //     ('state', '=', 'validate'),
            // ])
            // allocations_per_employee_type = defaultdict(lambda: defaultdict(lambda: self.env['hr.leave.allocation']))
            // for allocation in allocations:
            //     allocations_per_employee_type[allocation.employee_id][allocation.holiday_status_id] |= allocation
            // 
            // # _get_consumed_leaves returns a tuple of two dictionnaries.
            // # 1) The first is a dictionary to map the number of days/hours of leaves taken per allocation
            // # The structure is the following:
            // # - KEYS:
            // # allocation_leaves_consumed
            // #  |--employee_id
            // #      |--holiday_status_id
            // #          |--allocation
            // #              |--virtual_leaves_taken
            // #              |--leaves_taken
            // #              |--virtual_remaining_leaves
            // #              |--remaining_leaves
            // #              |--max_leaves
            // #              |--accrual_bonus
            // # - VALUES:
            // # Integer representing the number of (virtual) remaining leaves, (virtual) leaves taken or max leaves
            // # for each allocation.
            // # leaves_taken and remaining_leaves only take into account validated leaves, while the "virtual" equivalent are
            // # also based on leaves in "confirm" or "validate1" state.
            // # Accrual bonus gives the amount of additional leaves that will have been granted at the given
            // # target_date in comparison to today.
            // # The unit is in hour or days depending on the leave type request unit
            // # 2) The second is a dictionary mapping the remaining days per employee and per leave type that are either
            // # not taken into account by the allocations, mainly because accruals don't take future leaves into account.
            // # This is used to warn the user if the leaves they takes bring them above their available limit.
            // # - KEYS:
            // # allocation_leaves_consumed
            // #  |--employee_id
            // #      |--holiday_status_id
            // #          |--to_recheck_leaves
            // #          |--excess_days
            // #          |--exceeding_duration
            // # - VALUES:
            // # "to_recheck_leaves" stores every leave that is not yet taken into account by the "allocation_leaves_consumed" dictionary.
            // # "excess_days" represents the excess amount that somehow isn't taken into account by the first dictionary.
            // # "exceeding_duration" sum up the to_recheck_leaves duration and compares it to the maximum allocated for that time period.
            // allocations_leaves_consumed = defaultdict(lambda: defaultdict(lambda: defaultdict(lambda: defaultdict(lambda: 0))))
            // 
            // to_recheck_leaves_per_leave_type = defaultdict(lambda:
            //     defaultdict(lambda: {
            //         'excess_days': defaultdict(lambda: {
            //             'amount': 0,
            //             'is_virtual': True,
            //         }),
            //         'exceeding_duration': 0,
            //         'to_recheck_leaves': self.env['hr.leave']
            //     })
            // )
            // for allocation in allocations:
            //     allocation_data = allocations_leaves_consumed[allocation.employee_id][allocation.holiday_status_id][allocation]
            //     future_leaves = 0
            //     if allocation.allocation_type == 'accrual':
            //         future_leaves = allocation._get_future_leaves_on(target_date)
            //     max_leaves = allocation.number_of_hours_display\
            //         if allocation.holiday_status_id.request_unit in ['hour']\
            //         else allocation.number_of_days_display
            //     max_leaves += future_leaves
            //     allocation_data.update({
            //         'max_leaves': max_leaves,
            //         'accrual_bonus': future_leaves,
            //         'virtual_remaining_leaves': max_leaves,
            //         'remaining_leaves': max_leaves,
            //         'leaves_taken': 0,
            //         'virtual_leaves_taken': 0,
            //     })
            // 
            // for employee in employees:
            //     for leave_type in leave_types:
            //         allocations_with_date_to = self.env['hr.leave.allocation']
            //         allocations_without_date_to = self.env['hr.leave.allocation']
            //         for leave_allocation in allocations_per_employee_type[employee][leave_type]:
            //             if leave_allocation.date_to:
            //                 allocations_with_date_to |= leave_allocation
            //             else:
            //                 allocations_without_date_to |= leave_allocation
            //         sorted_leave_allocations = allocations_with_date_to.sorted(key='date_to') + allocations_without_date_to
            // 
            //         if leave_type.request_unit in ['day', 'half_day']:
            //             leave_duration_field = 'number_of_days'
            //             leave_unit = 'days'
            //         else:
            //             leave_duration_field = 'number_of_hours'
            //             leave_unit = 'hours'
            // 
            //         leave_type_data = allocations_leaves_consumed[employee][leave_type]
            //         for leave in leaves_per_employee_type[employee][leave_type].sorted('date_from'):
            //             leave_duration = leave[leave_duration_field]
            //             skip_excess = False
            // 
            //             if sorted_leave_allocations.filtered(lambda alloc: alloc.allocation_type == 'accrual') and leave.date_from.date() > target_date:
            //                 to_recheck_leaves_per_leave_type[employee][leave_type]['to_recheck_leaves'] |= leave
            //                 skip_excess = True
            //                 continue
            // 
            //             if leave_type.requires_allocation == 'yes':
            //                 for allocation in sorted_leave_allocations:
            //                     # We don't want to include future leaves linked to accruals into the total count of available leaves.
            //                     # However, we'll need to check if those leaves take more than what will be accrued in total of those days
            //                     # to give a warning if the total exceeds what will be accrued.
            //                     if allocation.date_from > leave.date_to.date() or (allocation.date_to and allocation.date_to < leave.date_from.date()):
            //                         continue
            //                     interval_start = max(
            //                         leave.date_from,
            //                         datetime.combine(allocation.date_from, time.min)
            //                     )
            //                     interval_end = min(
            //                         leave.date_to,
            //                         datetime.combine(allocation.date_to, time.max)
            //                         if allocation.date_to else leave.date_to
            //                     )
            //                     duration = leave[leave_duration_field]
            //                     if leave.date_from != interval_start or leave.date_to != interval_end:
            //                         duration_info = employee._get_calendar_attendances(interval_start.replace(tzinfo=pytz.UTC), interval_end.replace(tzinfo=pytz.UTC))
            //                         duration = duration_info['hours' if leave_unit == 'hours' else 'days']
            //                     max_allowed_duration = min(
            //                         duration,
            //                         leave_type_data[allocation]['virtual_remaining_leaves']
            //                     )
            // 
            //                     if not max_allowed_duration:
            //                         continue
            // 
            //                     allocated_time = min(max_allowed_duration, leave_duration)
            //                     leave_type_data[allocation]['virtual_leaves_taken'] += allocated_time
            //                     leave_type_data[allocation]['virtual_remaining_leaves'] -= allocated_time
            //                     if leave.state == 'validate':
            //                         leave_type_data[allocation]['leaves_taken'] += allocated_time
            //                         leave_type_data[allocation]['remaining_leaves'] -= allocated_time
            // 
            //                     leave_duration -= allocated_time
            //                     if not leave_duration:
            //                         break
            //                 if round(leave_duration, 2) > 0 and not skip_excess:
            //                     to_recheck_leaves_per_leave_type[employee][leave_type]['excess_days'][leave.date_to.date()] = {
            //                         'amount': leave_duration,
            //                         'is_virtual': leave.state != 'validate',
            //                         'leave_id': leave.id,
            //                     }
            //             else:
            //                 if leave_unit == 'hours':
            //                     allocated_time = leave.number_of_hours
            //                 else:
            //                     allocated_time = leave.number_of_days
            //                 leave_type_data[False]['virtual_leaves_taken'] += allocated_time
            //                 leave_type_data[False]['virtual_remaining_leaves'] = 0
            //                 leave_type_data[False]['remaining_leaves'] = 0
            //                 if leave.state == 'validate':
            //                     leave_type_data[False]['leaves_taken'] += allocated_time
            // 
            // for employee in to_recheck_leaves_per_leave_type:
            //     for leave_type in to_recheck_leaves_per_leave_type[employee]:
            //         content = to_recheck_leaves_per_leave_type[employee][leave_type]
            //         consumed_content = allocations_leaves_consumed[employee][leave_type]
            //         if content['to_recheck_leaves']:
            //             date_to_simulate = max(content['to_recheck_leaves'].mapped('date_from')).date()
            //             latest_accrual_bonus = 0
            //             date_accrual_bonus = 0
            //             virtual_remaining = 0
            //             additional_leaves_duration = 0
            //             for allocation in consumed_content:
            //                 latest_accrual_bonus += allocation and allocation._get_future_leaves_on(date_to_simulate)
            //                 date_accrual_bonus += consumed_content[allocation]['accrual_bonus']
            //                 virtual_remaining += consumed_content[allocation]['virtual_remaining_leaves']
            //             for leave in content['to_recheck_leaves']:
            //                 additional_leaves_duration += leave.number_of_hours if leave_type.request_unit == 'hours' else leave.number_of_days
            //             latest_remaining = virtual_remaining - date_accrual_bonus + latest_accrual_bonus
            //             content['exceeding_duration'] = round(min(0, latest_remaining - additional_leaves_duration), 2)
            // 
            // return (allocations_leaves_consumed, to_recheck_leaves_per_leave_type)
            */
            return default;
        }

        public async Task<TEntity> GetContextualEmployeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_base.py) ---
            // def _get_contextual_employee(self):
            // ctx = self.env.context
            // if self.env.context.get('employee_id') is not None:
            //     return self.browse(ctx.get('employee_id'))
            // if self.env.context.get('default_employee_id') is not None:
            //     return self.browse(ctx.get('default_employee_id'))
            // return self.env.user.employee_id
            */
            return default;
        }

        public async Task<TEntity> GetCurrentDayLocationFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_homeworking, FILE: hr_employee.py) ---
            // def _get_current_day_location_field(self):
            // return DAYS[fields.Date.today().weekday()]
            */
            return default;
        }

        public async Task<TEntity> GetEmployeeM2oToEmptyOnArchivedEmployeesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_employee_m2o_to_empty_on_archived_employees(self):
            // return ['parent_id', 'coach_id']
            */
            return default;
        }

        public async Task<TEntity> GetEmployeeWorkingNowInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py) ---
            // def _get_employee_working_now(self):
            // working_now = []
            // # We loop over all the employee tz and the resource calendar_id to detect working hours in batch.
            // all_employee_tz = set(self.mapped('tz'))
            // for tz in all_employee_tz:
            //     employee_ids = self.filtered(lambda e: e.tz == tz)
            //     resource_calendar_ids = employee_ids.mapped('resource_calendar_id')
            //     for calendar_id in resource_calendar_ids:
            //         res_employee_ids = employee_ids.filtered(lambda e: e.resource_calendar_id.id == calendar_id.id)
            //         start_dt = fields.Datetime.now()
            //         stop_dt = start_dt + timedelta(hours=1)
            //         from_datetime = utc.localize(start_dt).astimezone(timezone(tz or 'UTC'))
            //         to_datetime = utc.localize(stop_dt).astimezone(timezone(tz or 'UTC'))
            //         # Getting work interval of the first is working. Functions called on resource_calendar_id
            //         # are waiting for singleton
            //         work_interval = res_employee_ids[0].resource_calendar_id._work_intervals_batch(from_datetime, to_datetime)[False]
            //         # Employee that is not supposed to work have empty items.
            //         if len(work_interval._items) > 0:
            //             # The employees should be working now according to their work schedule
            //             working_now += res_employee_ids.ids
            // return working_now
            */
            return default;
        }

        public async Task<TEntity> GetExpectedAttendancesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> GetFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py) ---
            // def _get_fields(self):
            // return ','.join('emp.%s' % name for name, field in self._fields.items() if field.store and field.type not in ['many2many', 'one2many'])
            */
            return default;
        }

        public async Task<TEntity> GetFirstWorkingIntervalInternalAsync<TEntity>(IEnumerable<TEntity> entities, object dt) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_base.py) ---
            // def _get_first_working_interval(self, dt):
            // # find the first working interval after a given date
            // dt = dt.replace(tzinfo=timezone.utc)
            // lookahead_days = [7, 30, 90, 180, 365, 730]
            // work_intervals = None
            // for lookahead_day in lookahead_days:
            //     periods = self._get_calendar_periods(dt, dt + timedelta(days=lookahead_day))
            //     if not periods:
            //         calendar = self.resource_calendar_id or self.company_id.resource_calendar_id
            //         work_intervals = calendar._work_intervals_batch(
            //             dt, dt + timedelta(days=lookahead_day), resources=self.resource_id)
            //     else:
            //         for period in periods[self]:
            //             start, end, calendar = period
            //             work_intervals = calendar._work_intervals_batch(
            //                 start, end, resources=self.resource_id)
            //     if work_intervals.get(self.resource_id.id) and work_intervals[self.resource_id.id]._items:
            //         # return start time of the earliest interval
            //         return work_intervals[self.resource_id.id]._items[0][0]
            */
            return default;
        }

        public async Task<TEntity> GetFormviewActionAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> GetFormviewIdAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> GetManagerOnlyFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py) ---
            // def _get_manager_only_fields(self):
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetMaritalStatusSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> GetNewHireFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py) ---
            // def _get_new_hire_field(self):
            // return 'create_date'
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_employee.py) ---
            // def _get_new_hire_field(self):
            // return 'first_contract_date'
            */
            return default;
        }

        public async Task<TEntity> GetPartnerCountDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_partner_count_depends(self):
            // return ['user_id']
            */
            return default;
        }

        public async Task<TEntity> GetPresenceServerActionDataAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py) ---
            // def get_presence_server_action_data(self):
            // server_action_xmlids = [
            //     'action_hr_employee_presence_present',
            //     'action_hr_employee_presence_absent',
            //     'action_hr_employee_presence_log',
            //     'action_hr_employee_presence_sms',
            //     'action_hr_employee_presence_time_off',
            // ]
            // actions = self.env['ir.actions.server'].sudo()
            // for xmlid in server_action_xmlids:
            //     actions += actions.env.ref(f"hr_presence.{xmlid}")
            // return actions.read(['id', 'value'])
            */
            return default;
        }

        public async Task<TEntity> GetRelatedPartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_related_partners(self):
            // return self.work_contact_id | self.user_id.partner_id
            */
            return default;
        }

        public async Task<TEntity> GetRemainingLeavesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_base.py) ---
            // def _get_remaining_leaves(self):
            // """ Helper to compute the remaining leaves for the current employees
            //     :returns dict where the key is the employee id, and the value is the remain leaves
            // """
            // self._cr.execute("""
            //     SELECT
            //         sum(h.number_of_days) AS days,
            //         h.employee_id
            //     FROM
            //         (
            //             SELECT holiday_status_id, number_of_days,
            //                 state, employee_id
            //             FROM hr_leave_allocation
            //             UNION ALL
            //             SELECT holiday_status_id, (number_of_days * -1) as number_of_days,
            //                 state, employee_id
            //             FROM hr_leave
            //         ) h
            //         join hr_leave_type s ON (s.id=h.holiday_status_id)
            //     WHERE
            //         s.active = true AND h.state='validate' AND
            //         s.requires_allocation='yes' AND
            //         h.employee_id in %s
            //     GROUP BY h.employee_id""", (tuple(self.ids),))
            // return {row['employee_id']: row['days'] for row in self._cr.dictfetchall()}
            */
            return default;
        }

        public async Task<TEntity> GetSubordinatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parents) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_org_chart, FILE: hr_org_chart_mixin.py) ---
            // def _get_subordinates(self, parents=None):
            // """
            // Helper function to compute subordinates_ids.
            // Get all subordinates (direct and indirect) of an employee.
            // An employee can be a manager of his own manager (recursive hierarchy; e.g. the CEO is manager of everyone but is also
            // member of the RD department, managed by the CTO itself managed by the CEO).
            // In that case, the manager in not counted as a subordinate if it's in the 'parents' set.
            // """
            // if not parents:
            //     parents = self.env[self._name]
            // 
            // indirect_subordinates = self.env[self._name]
            // parents |= self
            // direct_subordinates = self.child_ids - parents
            // child_subordinates = direct_subordinates._get_subordinates(parents=parents) if direct_subordinates else self.browse()
            // indirect_subordinates |= child_subordinates
            // return indirect_subordinates | direct_subordinates
            */
            return default;
        }

        public async Task<TEntity> GetTzBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> GetTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> GetUnusualDaysInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> GetUserM2oToEmptyOnArchivedEmployeesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_user_m2o_to_empty_on_archived_employees(self):
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetValidEmployeeForUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py) ---
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

        public async Task<TEntity> GetViewAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> GetViewsAsync<TEntity>(IEnumerable<TEntity> entities, object views, object options) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_views(self, views, options=None):
            // if self.browse().has_access('read'):
            //     return super().get_views(views, options)
            // res = self.env['hr.employee.public'].get_views(views, options)
            // res['models'].update({'hr.employee': res['models']['hr.employee.public']})
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_homeworking, FILE: hr_employee.py) ---
            // def get_views(self, views, options=None):
            // res = super().get_views(views, options)
            // dayfield = self._get_current_day_location_field()
            // if 'search' in res['views']:
            //     res['views']['search']['arch'] = res['views']['search']['arch'].replace('today_location_name', dayfield)
            // if 'list' in res['views']:
            //     res['views']['list']['arch'] = res['views']['list']['arch'].replace('work_location_name', dayfield)
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetWorklocationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_date, object end_date) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_homeworking_calendar, FILE: hr_employee.py) ---
            // def _get_worklocation(self, start_date, end_date):
            // work_locations_by_employee = defaultdict(dict)
            // for employee in self:
            //     work_locations_by_employee[employee.id].update({
            //         "user_id": employee.user_id.id,
            //         "employee_id": employee.id,
            //         "partner_id": employee.user_partner_id.id or employee.work_contact_id.id,
            //         "employee_name": employee.name
            //     })
            // 
            //     for day in DAYS:
            //         work_locations_by_employee[employee.id][day] = {
            //             'location_type': employee[day]["location_type"],
            //             'location_name': employee[day]["name"],
            //             'work_location_id': employee[day].id,
            //         }
            // 
            // exceptions_for_period = self.env['hr.employee.location'].search_read([
            //     ('employee_id', 'in', self.ids),
            //     ('date', '>=', start_date),
            //     ('date', '<=', end_date)
            // ], ['employee_id', 'date', 'work_location_name', 'work_location_id', 'work_location_type'])
            // 
            // for exception in exceptions_for_period:
            //     date = exception["date"].strftime(DEFAULT_SERVER_DATE_FORMAT)
            //     exception_value = {
            //         'hr_employee_location_id': exception["id"],
            //         'location_type': exception['work_location_type'],
            //         'location_name': exception['work_location_name'],
            //         'work_location_id': exception['work_location_id'][0],
            //     }
            //     employee_id = exception["employee_id"][0]
            //     if "exceptions" not in work_locations_by_employee[employee_id]:
            //         work_locations_by_employee[employee_id]["exceptions"] = {}
            //     work_locations_by_employee[employee_id]["exceptions"][date] = exception_value
            // 
            // return work_locations_by_employee
            */
            return default;
        }

        public async Task<TEntity> InitAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py) ---
            // def init(self):
            // tools.drop_view_if_exists(self.env.cr, self._table)
            // self.env.cr.execute("""CREATE or REPLACE VIEW %s as (
            //     SELECT
            //         %s
            //     FROM hr_employee emp
            // )""" % (self._table, self._get_fields()))
            */
            return default;
        }

        public async Task<TEntity> InverseKmHomeWorkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _inverse_km_home_work(self):
            // for employee in self:
            //     employee.distance_home_work = employee.km_home_work / 1.609 if employee.distance_home_work_unit == "miles" else employee.km_home_work
            */
            return default;
        }

        public async Task<TEntity> InverseWorkContactDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py) ---
            // def _inverse_work_contact_details(self):
            // employees_without_work_contact = self.env['hr.employee']
            // for employee in self:
            //     if not employee.work_contact_id:
            //         employees_without_work_contact += employee
            //     else:
            //         employee.work_contact_id.sudo().write({
            //             'email': employee.work_email,
            //             'mobile': employee.mobile_phone,
            //         })
            // if employees_without_work_contact:
            //     employees_without_work_contact.sudo()._create_work_contacts()
            */
            return default;
        }

        public async Task<TEntity> LangGetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _lang_get(self):
            // return self.env['res.lang'].get_installed()
            */
            return default;
        }

        public async Task<TEntity> LoadScenarioInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> MailGetPartnerFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _mail_get_partner_fields(self, introspect_fields=False):
            // return ['user_partner_id']
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> OnchangeTimezoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _onchange_timezone(self):
            // if self.resource_calendar_id and not self.tz:
            //     self.tz = self.resource_calendar_id.tz
            */
            return default;
        }

        public async Task<TEntity> OnchangeUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> PhoneGetNumberFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _phone_get_number_fields(self):
            // return ['mobile_phone']
            */
            return default;
        }

        public async Task<TEntity> PrepareResourceValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object tz) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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
            */
            return default;
        }

        public async Task<TEntity> RemoveWorkContactIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user, object employee_company) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> SearchAbsentEmployeeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_base.py) ---
            // def _search_absent_employee(self, operator, value):
            // if operator not in ('=', '!=') or not isinstance(value, bool):
            //     raise UserError(_('Operation not supported'))
            // # This search is only used for the 'Absent Today' filter however
            // # this only returns employees that are absent right now.
            // today_date = datetime.now(timezone.utc).date()
            // today_start = fields.Datetime.to_string(today_date)
            // today_end = fields.Datetime.to_string(today_date + relativedelta(hours=23, minutes=59, seconds=59))
            // holidays = self.env['hr.leave'].sudo().search([
            //     ('employee_id', '!=', False),
            //     ('state', '=', 'validate'),
            //     ('date_from', '<=', today_end),
            //     ('date_to', '>=', today_start),
            // ])
            // operator = ['in', 'not in'][(operator == '=') != value]
            // return [('id', operator, holidays.mapped('employee_id').ids)]
            */
            return default;
        }

        public async Task<TEntity> SearchEmployeeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py) ---
            // def _search_employee_id(self, operator, value):
            // return [('id', operator, value)]
            */
            return default;
        }

        public async Task<TEntity> SearchFetchAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object field_names, object offset, object limit, object order) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> SearchFilterForExpenseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_employee.py) ---
            // def _search_filter_for_expense(self, operator, value):
            // assert operator == '=' and value, "Operation not supported"
            // 
            // res = [('id', '=', 0)]  # Nothing accepted by domain, by default
            // user = self.env.user
            // employee = user.employee_id
            // if user.has_groups('hr_expense.group_hr_expense_user') or user.has_groups('account.group_account_user'):
            //     res = ['|', ('company_id', '=', False), ('company_id', 'child_of', self.env.company.root_id.id)]  # Then, domain accepts everything
            // elif user.has_groups('hr_expense.group_hr_expense_team_approver') and user.employee_ids:
            //     res = [
            //         '|', '|', '|',
            //         ('department_id.manager_id', '=', employee.id),
            //         ('parent_id', '=', employee.id),
            //         ('id', '=', employee.id),
            //         ('expense_manager_id', '=', user.id),
            //         '|', ('company_id', '=', False), ('company_id', '=', employee.company_id.id),
            //     ]
            // elif user.employee_id:
            //     res = [('id', '=', employee.id), '|', ('company_id', '=', False), ('company_id', '=', employee.company_id.id)]
            // return res
            */
            return default;
        }

        public async Task<TEntity> SearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object offset, object limit, object order) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> SearchIsSubordinateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_org_chart, FILE: hr_org_chart_mixin.py) ---
            // def _search_is_subordinate(self, operator, value):
            // if operator not in ('=', '!=') or not isinstance(value, bool):
            //     raise UserError(_('Operation not supported'))
            // # Double negation
            // if not value:
            //     operator = '!=' if operator == '=' else '='
            // if not self.env.user.employee_id.subordinate_ids:
            //     return [('id', operator, self.env.user.employee_id.id)]
            // return (['!'] if operator == '!=' else []) + [('id', 'in', self.env.user.employee_id.subordinate_ids.ids)]
            */
            return default;
        }

        public async Task<TEntity> SearchNewlyHiredInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py) ---
            // def _search_newly_hired(self, operator, value):
            // new_hire_field = self._get_new_hire_field()
            // new_hires = self.env['hr.employee'].sudo().search([
            //     (new_hire_field, '>', fields.Datetime.now() - timedelta(days=90))
            // ])
            // 
            // op = 'in' if value and operator == '=' or not value and operator != '=' else 'not in'
            // return [('id', op, new_hires.ids)]
            */
            return default;
        }

        public async Task<TEntity> SearchPartOfDepartmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_base.py) ---
            // def _search_part_of_department(self, operator, value):
            // if operator not in ('=', '!=') or not isinstance(value, bool):
            //     raise UserError(_('Operation not supported'))
            // 
            // user_employee = self._get_valid_employee_for_user()
            // # Double negation
            // if not value:
            //     operator = '!=' if operator == '=' else '='
            // if not user_employee.department_id:
            //     return [('id', operator, user_employee.id)]
            // return (['!'] if operator == '!=' else []) + [('department_id', 'child_of', user_employee.department_id.id)]
            */
            return default;
        }

        public async Task<TEntity> SyncUserInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user, object employee_has_image) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> ToggleActiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> VerifyBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> VerifyPinInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IHrEmployeeBaseable
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
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_base.py) ---
            // def write(self, values):
            // if 'parent_id' in values:
            //     manager = self.env['hr.employee'].browse(values['parent_id']).user_id
            //     if manager:
            //         to_change = self.filtered(lambda e: e.leave_manager_id == e.parent_id.user_id or not e.leave_manager_id)
            //         to_change.write({'leave_manager_id': values.get('leave_manager_id', manager.id)})
            // 
            // old_managers = self.env['res.users']
            // if 'leave_manager_id' in values:
            //     old_managers = self.mapped('leave_manager_id')
            //     if values['leave_manager_id']:
            //         leave_manager = self.env['res.users'].browse(values['leave_manager_id'])
            //         old_managers -= leave_manager
            //         approver_group = self.env.ref('hr_holidays.group_hr_holidays_responsible', raise_if_not_found=False)
            //         if approver_group and not leave_manager.has_group('hr_holidays.group_hr_holidays_responsible'):
            //             leave_manager.sudo().write({'groups_id': [(4, approver_group.id)]})
            // 
            // res = super().write(values)
            // # remove users from the Responsible group if they are no longer leave managers
            // old_managers.sudo()._clean_leave_responsible_users()
            // 
            // # Change the resource calendar of the employee's leaves in the future
            // # Other modules can disable this behavior by setting the context key
            // # 'no_leave_resource_calendar_update'
            // if 'resource_calendar_id' in values and not self.env.context.get('no_leave_resource_calendar_update'):
            //     try:
            //         self.env['hr.leave'].search([
            //             ('employee_id', 'in', self.ids),
            //             ('resource_calendar_id', '!=', int(values['resource_calendar_id'])),
            //             ('date_from', '>', fields.Datetime.now())]).write({'resource_calendar_id': values['resource_calendar_id']})
            //     except ValidationError:
            //         raise ValidationError(_("Changing this working schedule results in the affected employee(s) not having enough "
            //                                 "leaves allocated to accomodate for their leaves already taken in the future. Please "
            //                                 "review this employee's leaves and adjust their allocation accordingly."))
            // 
            // if 'parent_id' in values or 'department_id' in values:
            //     today_date = fields.Datetime.now()
            //     hr_vals = {}
            //     if values.get('parent_id') is not None:
            //         hr_vals['manager_id'] = values['parent_id']
            //     if values.get('department_id') is not None:
            //         hr_vals['department_id'] = values['department_id']
            //     holidays = self.env['hr.leave'].sudo().search([
            //         '|',
            //         ('state', '=', 'confirm'),
            //         ('date_from', '>', today_date),
            //         ('employee_id', 'in', self.ids),
            //     ])
            //     holidays.write(hr_vals)
            //     allocations = self.env['hr.leave.allocation'].sudo().search([
            //         ('state', 'in', ['draft', 'confirm']),
            //         ('employee_id', 'in', self.ids),
            //     ])
            //     allocations.write(hr_vals)
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_holidays_contract, FILE: hr_employee_base.py) ---
            // def write(self, vals):
            // # Prevent the resource calendar of leaves to be updated by a write to
            // # employee. When this module is enabled the resource calendar of
            // # leaves are determined by those of the contracts.
            // return super(HrEmployeeBase, self.with_context(no_leave_resource_calendar_update=True)).write(vals)
            --- ODOO METHOD SOURCE (MODULE: hr_presence, FILE: hr_employee.py) ---
            // def write(self, vals):
            // if vals.get('hr_presence_state_display') == 'present':
            //     vals['manually_set_present'] = True
            // return super().write(vals)
            */
            return default;
        }
    }
}