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
    [Module("base", Category = "Base")]
    public class AvatarMixinAppService : ApplicationService, IAvatarMixinAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public AvatarMixinAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ActShowLogCostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def act_show_log_cost(self):
            // """ This opens log view to view and add new log for this vehicle, groupby default to only show effective costs
            //     @return: the costs log view
            // """
            // self.ensure_one()
            // copy_context = dict(self.env.context)
            // copy_context.pop('group_by', None)
            // res = self.env['ir.actions.act_window']._for_xml_id('fleet.fleet_vehicle_costs_action')
            // res.update(
            //     context=dict(copy_context, default_vehicle_id=self.id, search_default_parent_false=True),
            //     domain=[('vehicle_id', '=', self.id)]
            // )
            // return res
            */
            return default;
        }

        public async Task<TEntity> ActionAcceptDriverChangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def action_accept_driver_change(self):
            // # Find all the vehicles of the same type for which the driver is the future_driver_id
            // # remove their driver_id and close their history using current date
            // vehicles = self.search([('driver_id', 'in', self.mapped('future_driver_id').ids), ('vehicle_type', '=', self.vehicle_type)])
            // vehicles.write({
            //     'driver_id': False,
            //     'plan_to_change_car': False,
            //     'plan_to_change_bike': False,
            // })
            // 
            // for vehicle in self:
            //     vehicle.plan_to_change_bike = False
            //     vehicle.plan_to_change_car = False
            //     vehicle.driver_id = vehicle.future_driver_id
            //     vehicle.future_driver_id = False
            */
            return default;
        }

        public async Task<TEntity> ActionArchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def action_archive(self):
            // archived_employees = self.filtered('active')
            // res = super().action_archive()
            // if archived_employees:
            //     # Empty links to this employees (example: manager, coach, time off responsible, ...)
            //     employee_fields_to_empty = self._get_employee_m2o_to_empty_on_archived_employees()
            //     user_fields_to_empty = self._get_user_m2o_to_empty_on_archived_employees()
            //     employee_domain = Domain.OR(Domain(field, 'in', archived_employees.ids) for field in employee_fields_to_empty)
            //     user_domain = Domain.OR(Domain(field, 'in', archived_employees.user_id.ids) for field in user_fields_to_empty)
            //     employees = self.env['hr.employee'].search(employee_domain | user_domain)
            //     for employee in employees:
            //         for field in employee_fields_to_empty:
            //             if employee[field] in archived_employees:
            //                 employee[field] = False
            //         for field in user_fields_to_empty:
            //             if employee[field] in archived_employees.user_id:
            //                 employee[field] = False
            // 
            //     if len(archived_employees) == 1 and not self.env.context.get('no_wizard', False):
            //         return {
            //             'type': 'ir.actions.act_window',
            //             'name': _('Register Departure'),
            //             'res_model': 'hr.departure.wizard',
            //             'view_mode': 'form',
            //             'target': 'new',
            //             'context': {'active_id': self.id},
            //             'views': [[False, 'form']]
            //         }
            // return res
            */
            return default;
        }

        public async Task<TEntity> ActionCreateUserAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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
            //     'context': {
            //         **self.env.context,
            //         'default_create_employee_id': self.id,
            //         'default_name': self.name,
            //         'default_phone': self.work_phone,
            //         'default_mobile': self.mobile_phone,
            //         'default_login': self.work_email,
            //         'default_partner_id': self.work_contact_id.id,
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionCreateUsersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def action_create_users(self):
            // def _get_user_creation_notification_action(message, message_type, next_action):
            //     return {
            //             'type': 'ir.actions.client',
            //             'tag': 'display_notification',
            //             'params': {
            //                 'title': self.env._("User Creation Notification"),
            //                 'type': message_type,
            //                 'message': message,
            //                 'next': next_action
            //             }
            //         }
            // 
            // employee_emails = [
            //     normalized_email
            //     for employee in self
            //     for normalized_email in tools.mail.email_normalize_all(employee.work_email)
            // ]
            // conflicting_users = self.env['res.users']
            // if employee_emails:
            //     conflicting_users = self.env['res.users'].search([
            //         '|', ('email_normalized', 'in', employee_emails),
            //         ('login', 'in', employee_emails),
            //     ])
            // old_users = []
            // new_users = []
            // users_without_emails = []
            // users_with_invalid_emails = []
            // users_with_existing_email = []
            // for employee in self:
            //     if employee.user_id:
            //         old_users.append(employee.name)
            //         continue
            //     if not employee.work_email:
            //         users_without_emails.append(employee.name)
            //         continue
            //     if not tools.email_normalize(employee.work_email):
            //         users_with_invalid_emails.append(employee.name)
            //         continue
            //     if email_normalize(employee.work_email) in conflicting_users.mapped('email_normalized'):
            //         users_with_existing_email.append(employee.name)
            //         continue
            //     new_users.append({
            //         'create_employee_id': employee.id,
            //         'name': employee.name,
            //         'phone': employee.work_phone,
            //         'login': tools.email_normalize(employee.work_email),
            //         'partner_id': employee.work_contact_id.id,
            //     })
            // 
            // next_action = {'type': 'ir.actions.act_window_close'}
            // if new_users:
            //     self.env['res.users'].create(new_users)
            //     message = _('Users %s creation successful', ', '.join([user['name'] for user in new_users]))
            //     next_action = _get_user_creation_notification_action(message, 'success', {
            //         "type": "ir.actions.client",
            //         "tag": "soft_reload",
            //         "params": {"next": next_action},
            //     })
            // 
            // if old_users:
            //     message = _('User already exists for Those Employees %s', ', '.join(old_users))
            //     next_action = _get_user_creation_notification_action(message, 'warning', next_action)
            // 
            // if users_without_emails:
            //     message = _("You need to set the work email address for %s", ', '.join(users_without_emails))
            //     next_action = _get_user_creation_notification_action(message, 'danger', next_action)
            // 
            // if users_with_invalid_emails:
            //     message = _("You need to set a valid work email address for %s", ', '.join(users_with_invalid_emails))
            //     next_action = _get_user_creation_notification_action(message, 'danger', next_action)
            // 
            // if users_with_existing_email:
            //     message = _('User already exists with the same email for Employees %s', ', '.join(users_with_existing_email))
            //     next_action = _get_user_creation_notification_action(message, 'warning', next_action)
            // 
            // return next_action
            */
            return default;
        }

        public async Task<TEntity> ActionCreateUsersConfirmationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def action_create_users_confirmation(self):
            // raise RedirectWarning(
            //         message=_("You're about to invite new users. %s users will be created with the default user template's rights. "
            //         "Adding new users may increase your subscription cost. Do you wish to continue?", len(self.ids)),
            //         action=self.env.ref('hr.action_hr_employee_create_users').id,
            //         button_text=_('Confirm'),
            //         additional_context={
            //             'selected_ids': self.ids,
            //         },
            //     )
            */
            return default;
        }

        public async Task<TEntity> ActionModelVehicleAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py) ---
            // def action_model_vehicle(self):
            // self.ensure_one()
            // context = {'default_model_id': self.id}
            // if self.vehicle_count:
            //     view_mode = 'kanban,list,form'
            //     name = _('Vehicles')
            //     context['search_default_model_id'] = self.id
            // else:
            //     view_mode = 'form'
            //     name = _('Vehicle')
            // view = {
            //     'type': 'ir.actions.act_window',
            //     'view_mode': view_mode,
            //     'res_model': 'fleet.vehicle',
            //     'name': name,
            //     'context': context,
            // }
            // 
            // return view
            */
            return default;
        }

        public async Task<TEntity> ActionOpenAllocationWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def action_open_allocation_wizard(self):
            // self.ensure_one()
            // wizard = self.env['hr.bank.account.allocation.wizard'].create({
            //     'employee_id': self.id,
            // })
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': self.env._('Bank Account Allocation'),
            //     'res_model': 'hr.bank.account.allocation.wizard',
            //     'res_id': wizard.id,
            //     'view_mode': 'form',
            //     'target': 'new',
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionOpenOdometerReportAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def action_open_odometer_report(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id('fleet.fleet_vehicle_odometer_reporting_action')
            // action.update({
            //     'domain': [('vehicle_id', '=', self.id)],
            //     'context': {'search_default_groupby_date': True},
            // })
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionOpenVersionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def action_open_versions(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': self.employee_id.name + self.env._(' Records'),
            //     'path': 'versions',
            //     'res_model': 'hr.version',
            //     'view_mode': 'list,graph,pivot',
            //     'views': [(self.env.ref('hr.hr_version_list_view').id, 'list'), (False, 'graph'), (False, 'pivot')],
            //     'domain': [('employee_id', '=', self.employee_id.id)],
            //     'search_view_id': self.env.ref('hr.hr_version_search_view').id
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionRelatedContactsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> ActionSendEmailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def action_send_email(self):
            // return {
            //     'name': _('Send Email'),
            //     'type': 'ir.actions.act_window',
            //     'target': 'new',
            //     'view_mode': 'form',
            //     'res_model': 'fleet.vehicle.send.mail',
            //     'context': {
            //         'default_vehicle_ids': self.ids,
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionTogglePrimaryBankAccountTrustAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def action_toggle_primary_bank_account_trust(self):
            // self.ensure_one()
            // current_val = self.primary_bank_account_id.allow_out_payment
            // self.primary_bank_account_id.allow_out_payment = not current_val
            */
            return default;
        }

        public async Task<TEntity> ActionUnarchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def action_unarchive(self):
            // res = super().action_unarchive()
            // self.write({
            //     'departure_reason_id': False,
            //     'departure_description': False,
            //     'departure_date': False
            // })
            // return res
            */
            return default;
        }

        public async Task<TEntity> AddressFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _address_fields(self):
            // """Returns the list of address fields that are synced from the parent."""
            // return list(ADDRESS_FIELDS)
            */
            return default;
        }

        public async Task<TEntity> AddressGetAsync<TEntity>(IEnumerable<TEntity> entities, object adr_pref) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def address_get(self, adr_pref=None):
            // """ Find contacts/addresses of the right type(s) by doing a depth-first-search
            // through descendants within company boundaries (stop at entities flagged ``is_company``)
            // then continuing the search at the ancestors that are within the same company boundaries.
            // Defaults to partners of type ``'default'`` when the exact type is not found, or to the
            // provided partner itself if no type ``'default'`` is found either. """
            // adr_pref = set(adr_pref or [])
            // if 'contact' not in adr_pref:
            //     adr_pref.add('contact')
            // result = {}
            // visited = set()
            // for partner in self:
            //     current_partner = partner
            //     while current_partner:
            //         to_scan = [current_partner]
            //         # Scan descendants, DFS
            //         while to_scan:
            //             record = to_scan.pop(0)
            //             visited.add(record)
            //             if record.type in adr_pref and not result.get(record.type):
            //                 result[record.type] = record.id
            //             if len(result) == len(adr_pref):
            //                 return result
            //             to_scan = [c for c in record.child_ids
            //                          if c not in visited
            //                          if not c.is_company] + to_scan
            // 
            //         # Continue scanning at ancestor if current_partner is not a commercial entity
            //         if current_partner.is_company or not current_partner.parent_id:
            //             break
            //         current_partner = current_partner.parent_id
            // 
            // # default to type 'contact' or the partner itself
            // default = result.get('contact', self.id or False)
            // for adr_type in adr_pref:
            //     result[adr_type] = result.get(adr_type) or default
            // return result
            */
            return default;
        }

        public async Task<TEntity> AvatarGenerateSvgInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py) ---
            // def _avatar_generate_svg(self):
            // initial = html_escape(self[self._avatar_name_field][0].upper())
            // bgcolor = get_hsl_from_seed(self[self._avatar_name_field] + str(self.create_date.timestamp() if self.create_date else ""))
            // return b64encode((
            //     "<?xml version='1.0' encoding='UTF-8' ?>"
            //     "<svg height='180' width='180' xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink'>"
            //     f"<rect fill='{bgcolor}' height='180' width='180'/>"
            //     f"<text fill='#ffffff' font-size='96' text-anchor='middle' x='90' y='125' font-family='sans-serif'>{initial}</text>"
            //     "</svg>"
            // ).encode())
            */
            return default;
        }

        public async Task<TEntity> AvatarGetPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py) ---
            // def _avatar_get_placeholder(self):
            // with file_open(self._avatar_get_placeholder_path(), 'rb') as f:
            //     return f.read()
            */
            return default;
        }

        public async Task<TEntity> AvatarGetPlaceholderPathInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py) ---
            // def _avatar_get_placeholder_path(self):
            // return "base/static/img/avatar_grey.png"
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _avatar_get_placeholder_path(self):
            // if self.is_company:
            //     return "base/static/img/company_image.png"
            // if self.type == 'delivery':
            //     return "base/static/img/truck.png"
            // if self.type == 'invoice':
            //     return "base/static/img/bill.png"
            // if self.type == 'other':
            //     return "base/static/img/puzzle.png"
            // return super()._avatar_get_placeholder_path()
            */
            return default;
        }

        public async Task<TEntity> CheckAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object operation) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _check_access(self, operation):
            // # This method override provides read access to 'hr.employee' in some
            // # situations, like setting a many2many field to comodel 'hr.employee'.
            // # Since Odoo 19, one must have read access to the comodel to modify the
            // # relation.
            // if operation == 'read' and self.env.context.get('_allow_read_hr_employee') is _ALLOW_READ_HR_EMPLOYEE:
            //     return None
            // 
            // return super()._check_access(operation)
            */
            return default;
        }

        public async Task<TEntity> CheckBarcodeUnicityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _check_barcode_unicity(self):
            // for partner in self:
            //     if partner.barcode and self.env['res.partner'].search_count([('barcode', '=', partner.barcode)]) > 1:
            //         raise ValidationError(_('Another partner already has this barcode'))
            */
            return default;
        }

        public async Task<TEntity> CheckFieldAccessRightsAsync<TEntity>(IEnumerable<TEntity> entities, object operation, object field_names) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> CheckImportConsistencyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _check_import_consistency(self, vals_list):
            // """
            // The values created by an import are generated by a name search, field by field.
            // As a result there is no check that the field values are consistent with each others.
            // We check that if the state is given a value, it does belong to the given country, or we remove it.
            // """
            // States = self.env['res.country.state']
            // states_ids = {vals['state_id'] for vals in vals_list if vals.get('state_id')}
            // state_to_country = States.search_read([('id', 'in', list(states_ids))], ['country_id'])
            // for vals in vals_list:
            //     if vals.get('state_id'):
            //         country_id = next(c['country_id'][0] for c in state_to_country if c['id'] == vals.get('state_id'))
            //         state = States.browse(vals['state_id'])
            //         if state.country_id.id != country_id:
            //             state_domain = [('code', '=', state.code),
            //                             ('country_id', '=', country_id)]
            //             state = States.search(state_domain, limit=1)
            //             vals['state_id'] = state.id
            */
            return default;
        }

        public async Task<TEntity> CheckNoExistingContractAsync<TEntity>(IEnumerable<TEntity> entities, object date) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def check_no_existing_contract(self, date):
            // if isinstance(date, str):
            //     date = fields.Date.from_string(date)
            // if self._is_in_contract(date):
            //     raise ValidationError(self.env._("The employee is already in contract on %s. "
            //                                      "Please select a date outside existing contracts",
            //                                      format_date_abbr(self.env, date)))
            */
            return default;
        }

        public async Task<TEntity> CheckParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _check_parent_id(self):
            // if self._has_cycle():
            //     raise ValidationError(_('You cannot create recursive Partner hierarchies.'))
            */
            return default;
        }

        public async Task<TEntity> CheckPartnerCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _check_partner_company(self):
            // """
            // Check that for every partner which has a company,
            // if there exists a company linked to that partner,
            // the company_id set on the partner is that company
            // """
            // partners = self.filtered(lambda p: p.is_company and p.company_id)
            // companies = self.env['res.company'].search_fetch([('partner_id', 'in', partners.ids)], ['partner_id'])
            // for company in companies:
            //     if company != company.partner_id.company_id:
            //         raise ValidationError(_('The company assigned to this partner does not match the company this partner represents.'))
            */
            return default;
        }

        public async Task<TEntity> CheckPrivateFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_names) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> CheckSalaryDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _check_salary_distribution(self):
            // for employee in self:
            //     dist = employee.salary_distribution
            //     if not dist:
            //         continue
            // 
            //     total = 0
            //     check_total = False
            //     for ba_values in dist.values():
            //         amount = ba_values.get('amount')
            //         is_percentage = ba_values.get('amount_is_percentage', True)
            //         if is_percentage and (not isinstance(amount, (float, int)) or not (0 <= amount <= 100)):
            //             raise ValidationError(self.env._("Each amount percentage must be a number between 0 and 100."))
            //         if is_percentage:
            //             check_total = True
            //             total += amount
            // 
            //     if check_total and not float_is_zero(total - 100.0, precision_digits=4):
            //         raise ValidationError(self.env._("Total salary distribution on bank accounts must be exactly 100%."))
            */
            return default;
        }

        public async Task<TEntity> ChildrenSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _children_sync(self, values):
            // if not self.child_ids:
            //     return
            // # 2a. Commercial Fields: sync if commercial entity
            // if self.commercial_partner_id == self:
            //     fields_to_sync = values.keys() & self._commercial_fields()
            //     self.sudo()._commercial_sync_to_descendants(fields_to_sync)
            // # 2b. Address fields: sync if address changed
            // address_fields = self._address_fields()
            // if any(field in values for field in address_fields):
            //     contacts = self.child_ids.filtered(lambda c: c.type == 'contact')
            //     contacts._update_address(values)
            */
            return default;
        }

        public async Task<TEntity> CleanWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _clean_website(self, website):
            // url = urls.url_parse(website)
            // if not url.scheme:
            //     if not url.netloc:
            //         url = url.replace(netloc=url.path, path='')
            //     website = url.replace(scheme='http').to_url()
            // return website
            */
            return default;
        }

        public async Task<TEntity> CommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _commercial_fields(self):
            // """ Returns the list of fields that are managed by the commercial entity
            // to which a partner belongs. These fields are meant to be hidden on
            // partners that aren't `commercial entities` themselves, or synchronized
            // at update (if present in _synced_commercial_fields), and will be
            // delegated to the parent `commercial entity`. The list is meant to be
            // extended by inheriting classes. """
            // return self._synced_commercial_fields() + ['company_registry', 'industry_id']
            */
            return default;
        }

        public async Task<TEntity> CommercialSyncFromCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _commercial_sync_from_company(self):
            // """ Handle sync of commercial fields when a new parent commercial entity is set,
            // as if they were related fields """
            // commercial_partner = self.commercial_partner_id
            // if commercial_partner != self:
            //     sync_vals = commercial_partner._get_commercial_values()
            //     if sync_vals:
            //         self.write(sync_vals)
            //         self._commercial_sync_to_descendants()
            //     self._company_dependent_commercial_sync()
            */
            return default;
        }

        public async Task<TEntity> CommercialSyncToDescendantsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields_to_sync) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _commercial_sync_to_descendants(self, fields_to_sync=None):
            // """ Handle sync of commercial fields to descendants """
            // commercial_partner = self.commercial_partner_id
            // if fields_to_sync is None:
            //     fields_to_sync = self._commercial_fields()
            // sync_vals = commercial_partner._convert_fields_to_values(fields_to_sync)
            // sync_children = self.child_ids.filtered(lambda c: not c.is_company)
            // for child in sync_children:
            //     child._commercial_sync_to_descendants(fields_to_sync)
            // sync_children.write(sync_vals)
            */
            return default;
        }

        public async Task<TEntity> CompanyDependentCommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _company_dependent_commercial_fields(self):
            // return [
            //     fname for fname in self._commercial_fields()
            //     if self._fields[fname].company_dependent
            // ]
            */
            return default;
        }

        public async Task<TEntity> CompanyDependentCommercialSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _company_dependent_commercial_sync(self):
            // """ Propagate sync of company dependant commercial fields to other
            // commpanies. """
            // if not (fields_to_sync := self._company_dependent_commercial_fields()):
            //     return
            // 
            // for company_sudo in self.env['res.company'].sudo().search([]):
            //     if company_sudo == self.env.company:
            //         continue  # already handled by _commercial_sync_from_company
            //     self_in_company = self.with_company(company_sudo)
            //     self_in_company.write(
            //         self_in_company.commercial_partner_id._convert_fields_to_values(fields_to_sync)
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeActiveLangCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_active_lang_count(self):
            // lang_count = len(self.env['res.lang'].get_installed())
            // for partner in self:
            //     partner.active_lang_count = lang_count
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationStatisticsHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_application_statistics_hook(self):
            // """ Hook for override, as overriding compute method does not update
            // cache accordingly. All overrides receive False instead of previously
            // assigned value. """
            // return defaultdict(list)
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_application_statistics(self):
            // result = self._compute_application_statistics_hook()
            // for p in self:
            //     p.application_statistics = result.get(p.id, [])
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1024InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar_1024(self):
            // super()._compute_avatar_1024()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py) ---
            // def _compute_avatar_1024(self):
            // self._compute_avatar('avatar_1024', 'image_1024')
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_1024(self):
            // super()._compute_avatar_1024()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar128InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar_128(self):
            // super()._compute_avatar_128()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py) ---
            // def _compute_avatar_128(self):
            // self._compute_avatar('avatar_128', 'image_128')
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_128(self):
            // super()._compute_avatar_128()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1920InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar_1920(self):
            // super()._compute_avatar_1920()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py) ---
            // def _compute_avatar_1920(self):
            // self._compute_avatar('avatar_1920', 'image_1920')
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_1920(self):
            // super()._compute_avatar_1920()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar256InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar_256(self):
            // super()._compute_avatar_256()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py) ---
            // def _compute_avatar_256(self):
            // self._compute_avatar('avatar_256', 'image_256')
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_256(self):
            // super()._compute_avatar_256()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar512InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar_512(self):
            // super()._compute_avatar_512()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py) ---
            // def _compute_avatar_512(self):
            // self._compute_avatar('avatar_512', 'image_512')
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_512(self):
            // super()._compute_avatar_512()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatarInternalAsync<TEntity>(IEnumerable<TEntity> entities, object avatar_field, object image_field) where TEntity : IEntity<Guid>, IAvatarMixinable
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
            // super(HrEmployee, employee_wo_user_and_image)._compute_avatar(avatar_field, image_field)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py) ---
            // def _compute_avatar(self, avatar_field, image_field):
            // for record in self:
            //     avatar = record[image_field]
            //     if not avatar:
            //         if record.id and record[record._avatar_name_field]:
            //             avatar = record._avatar_generate_svg()
            //         else:
            //             avatar = b64encode(record._avatar_get_placeholder())
            //     record[avatar_field] = avatar
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar(self, avatar_field, image_field):
            // partners_with_internal_user = self.filtered(
            //     lambda partner: partner.user_ids - partner.user_ids.filtered('share') or partner.type == 'contact')
            // super(ResPartner, partners_with_internal_user)._compute_avatar(avatar_field, image_field)
            // partners_without_image = (self - partners_with_internal_user).filtered(lambda p: not p[image_field])
            // for _, group in tools.groupby(partners_without_image, key=lambda p: p._avatar_get_placeholder_path()):
            //     group_partners = self.env['res.partner'].concat(*group)
            //     group_partners[avatar_field] = base64.b64encode(group_partners[0]._avatar_get_placeholder())
            // 
            // for partner in self - partners_with_internal_user - partners_without_image:
            //     partner[avatar_field] = partner[image_field]
            */
            return default;
        }

        public async Task<TEntity> ComputeBirthdayPublicDisplayStringInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_birthday_public_display_string(self):
            // for employee in self:
            //     if employee.birthday and employee.birthday_public_display:
            //         employee.birthday_public_display_string = datetime.strftime(employee.birthday, "%d %B")
            //     else:
            //         employee.birthday_public_display_string = "hidden"
            */
            return default;
        }

        public async Task<TEntity> ComputeCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_category(self):
            // self._load_fields_from_model(['category_id'])
            */
            return default;
        }

        public async Task<TEntity> ComputeCo2EmissionUnitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_co2_emission_unit(self):
            // for record in self:
            //     if record.range_unit == 'km':
            //         record.co2_emission_unit = 'g/km'
            //     else:
            //         record.co2_emission_unit = 'g/mi'
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py) ---
            // def _compute_co2_emission_unit(self):
            // for record in self:
            //     if record.range_unit == 'km':
            //         record.co2_emission_unit = 'g/km'
            //     else:
            //         record.co2_emission_unit = 'g/mi'
            */
            return default;
        }

        public async Task<TEntity> ComputeCo2InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_co2(self):
            // self._load_fields_from_model(['co2'])
            */
            return default;
        }

        public async Task<TEntity> ComputeCo2StandardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_co2_standard(self):
            // self._load_fields_from_model(['co2_standard'])
            */
            return default;
        }

        public async Task<TEntity> ComputeCoachInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_coach(self):
            // for version in self:
            //     manager = version.parent_id
            //     previous_manager = version._origin.parent_id
            //     if manager and (version.coach_id == previous_manager or not version.coach_id):
            //         version.coach_id = manager
            //     elif not version.coach_id:
            //         version.coach_id = False
            */
            return default;
        }

        public async Task<TEntity> ComputeColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_color(self):
            // self._load_fields_from_model(['color'])
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialCompanyNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_commercial_company_name(self):
            // for partner in self:
            //     p = partner.commercial_partner_id
            //     partner.commercial_company_name = p.is_company and p.name or partner.company_name
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_commercial_partner(self):
            // for partner in self:
            //     if partner.is_company or not partner.parent_id:
            //         partner.commercial_partner_id = partner
            //     else:
            //         partner.commercial_partner_id = partner.parent_id.commercial_partner_id
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_company_registry(self):
            // # exists to allow overrides
            // for company in self:
            //     company.company_registry = company.company_registry
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_company_registry_label(self):
            // label_by_country = self._get_company_registry_labels()
            // for company in self:
            //     country_code = company.country_id.code
            //     company.company_registry_label = label_by_country.get(country_code, _("Company ID"))
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_company_registry_placeholder(self):
            // self.company_registry_placeholder = False
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_company_type(self):
            // for partner in self:
            //     partner.company_type = 'company' if partner.is_company else 'person'
            */
            return default;
        }

        public async Task<TEntity> ComputeCompleteNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_complete_name(self):
            // for partner in self:
            //     partner.complete_name = partner.with_context({})._get_complete_name()
            */
            return default;
        }

        public async Task<TEntity> ComputeContactAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_contact_address(self):
            // for partner in self:
            //     partner.contact_address = partner._display_address()
            */
            return default;
        }

        public async Task<TEntity> ComputeContractReminderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_contract_reminder(self):
            // params = self.env['ir.config_parameter'].sudo()
            // delay_alert_contract = int(params.get_param('hr_fleet.delay_alert_contract', default=30))
            // current_date = fields.Date.context_today(self)
            // data = self.env['fleet.vehicle.log.contract']._read_group(
            //     domain=[('expiration_date', '!=', False), ('vehicle_id', 'in', self.ids), ('state', '!=', 'closed')],
            //     groupby=['vehicle_id', 'state'],
            //     aggregates=['expiration_date:max'])
            // 
            // prepared_data = {}
            // for vehicle_id, state, expiration_date in data:
            //     if prepared_data.get(vehicle_id.id):
            //         if prepared_data[vehicle_id.id]['expiration_date'] < expiration_date:
            //             prepared_data[vehicle_id.id]['expiration_date'] = expiration_date
            //             prepared_data[vehicle_id.id]['state'] = state
            //     else:
            //         prepared_data[vehicle_id.id] = {
            //             'state': state,
            //             'expiration_date': expiration_date,
            //         }
            // 
            // for record in self:
            //     vehicle_data = prepared_data.get(record.id)
            //     if vehicle_data:
            //         diff_time = (vehicle_data['expiration_date'] - current_date).days
            //         record.contract_renewal_overdue = diff_time < 0
            //         record.contract_renewal_due_soon = not record.contract_renewal_overdue and (diff_time < delay_alert_contract)
            //         record.contract_state = vehicle_data['state']
            //     else:
            //         record.contract_renewal_overdue = False
            //         record.contract_renewal_due_soon = False
            //         record.contract_state = ""
            */
            return default;
        }

        public async Task<TEntity> ComputeCountAllInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_count_all(self):
            // Odometer = self.env['fleet.vehicle.odometer']
            // LogService = self.env['fleet.vehicle.log.services'].with_context(active_test=False)
            // LogContract = self.env['fleet.vehicle.log.contract'].with_context(active_test=False)
            // History = self.env['fleet.vehicle.assignation.log']
            // odometers_data = Odometer._read_group([('vehicle_id', 'in', self.ids)], ['vehicle_id'], ['__count'])
            // services_data = LogService._read_group([('vehicle_id', 'in', self.ids)], ['vehicle_id', 'active'], ['__count'])
            // logs_data = LogContract._read_group([('vehicle_id', 'in', self.ids), ('state', '!=', 'closed')], ['vehicle_id', 'active'], ['__count'])
            // histories_data = History._read_group([('vehicle_id', 'in', self.ids)], ['vehicle_id'], ['__count'])
            // 
            // mapped_odometer_data = defaultdict(lambda: 0)
            // mapped_service_data = defaultdict(lambda: defaultdict(lambda: 0))
            // mapped_log_data = defaultdict(lambda: defaultdict(lambda: 0))
            // mapped_history_data = defaultdict(lambda: 0)
            // 
            // for vehicle, count in odometers_data:
            //     mapped_odometer_data[vehicle.id] = count
            // for vehicle, active, count in services_data:
            //     mapped_service_data[vehicle.id][active] = count
            // for vehicle, active, count in logs_data:
            //     mapped_log_data[vehicle.id][active] = count
            // for vehicle, count in histories_data:
            //     mapped_history_data[vehicle.id] = count
            // 
            // for vehicle in self:
            //     vehicle.odometer_count = mapped_odometer_data[vehicle.id]
            //     vehicle.service_count = mapped_service_data[vehicle.id][vehicle.active]
            //     vehicle.contract_count = mapped_log_data[vehicle.id][vehicle.active]
            //     vehicle.history_count = mapped_history_data[vehicle.id]
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrentVersionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_current_version_id(self):
            // for employee in self:
            //     version = self.env['hr.version'].search(
            //         [('employee_id', 'in', employee.ids), ('date_version', '<=', fields.Date.today())],
            //         order='date_version desc',
            //         limit=1,
            //     )
            //     new_current_version = False
            //     if version:
            //         new_current_version = version
            //     elif employee.version_ids:
            //         new_current_version = employee.version_ids[0]
            //     # To not trigger computed properties if still the same version
            //     if employee.current_version_id != new_current_version:
            //         employee.current_version_id = new_current_version
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py) ---
            // def _compute_display_name(self):
            // for record in self:
            //     name = record.name
            //     if record.brand_id.name:
            //         name = f"{record.brand_id.name}/{name}"
            //     record.display_name = name
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_display_name(self):
            // if self.browse().has_access('read'):
            //     return super()._compute_display_name()
            // for employee_private, employee_public in zip(self, self.env['hr.employee.public'].browse(self.ids)):
            //     employee_private.display_name = employee_public.display_name
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_display_name(self):
            // type_description = dict(self._fields['type']._description_selection(self.env))
            // for partner in self:
            //     if partner.env.context.get("formatted_display_name"):
            //         name = partner.name or ''
            //         if partner.parent_id or partner.company_name:
            //             name = (f"{partner.company_name or partner.parent_id.name} \t "
            //                     f"--{partner.name or type_description.get(partner.type, '')}--")
            // 
            //         if partner.env.context.get('show_email') and partner.email:
            //             name = f"{name} \t --{partner.email}--"
            //         elif partner.env.context.get('partner_show_db_id'):
            //             name = f"{name} \t --{partner.id}--"
            // 
            //     else:
            //         name = partner.with_context(lang=self.env.lang)._get_complete_name()
            //         if partner.env.context.get('partner_show_db_id'):
            //             name = f"{name} ({partner.id})"
            //         if partner.env.context.get('show_email') and partner.email:
            //             name = f"{name} <{partner.email}>"
            //         if partner.env.context.get('show_address'):
            //             name = name + "\n" + partner._display_address(without_company=True)
            // 
            //         if partner.env.context.get('show_vat') and partner.vat:
            //             if partner.env.context.get('show_address'):
            //                 name = f"{name} \n {partner.vat}"
            //             else:
            //                 name = f"{name} - {partner.vat}"
            // 
            //     # Remove extra empty lines
            //     name = re.sub(r'\s+\n', '\n', name)
            //     partner.display_name = name.strip()
            */
            return default;
        }

        public async Task<TEntity> ComputeDoorsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_doors(self):
            // self._load_fields_from_model(['doors'])
            */
            return default;
        }

        public async Task<TEntity> ComputeElectricAssistanceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_electric_assistance(self):
            // self._load_fields_from_model(['electric_assistance'])
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailFormattedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_email_formatted(self):
            // """ Compute formatted email for partner, using formataddr. Be defensive
            // in computation, notably
            // 
            //   * double format: if email already holds a formatted email like
            //     'Name' <email@domain.com> we should not use it as it to compute
            //     email formatted like "Name <'Name' <email@domain.com>>";
            //   * multi emails: sometimes this field is used to hold several addresses
            //     like email1@domain.com, email2@domain.com. We currently let this value
            //     untouched, but remove any formatting from multi emails;
            //   * invalid email: if something is wrong, keep it in email_formatted as
            //     this eases management and understanding of failures at mail.mail,
            //     mail.notification and mailing.trace level;
            //   * void email: email_formatted is False, as we cannot do anything with
            //     it;
            // """
            // self.email_formatted = False
            // for partner in self:
            //     emails_normalized = tools.email_normalize_all(partner.email)
            //     if emails_normalized:
            //         # note: multi-email input leads to invalid email like "Name" <email1, email2>
            //         # but this is current behavior in Odoo 14+ and some servers allow it
            //         partner.email_formatted = tools.formataddr((
            //             partner.name or u"False",
            //             ','.join(emails_normalized)
            //         ))
            //     elif partner.email:
            //         partner.email_formatted = tools.formataddr((
            //             partner.name or u"False",
            //             partner.email
            //         ))
            */
            return default;
        }

        public async Task<TEntity> ComputeFuelTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_fuel_type(self):
            // self._load_fields_from_model(['fuel_type'])
            */
            return default;
        }

        public async Task<TEntity> ComputeGetIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_get_ids(self):
            // for partner in self:
            //     partner.self = partner.id
            */
            return default;
        }

        public async Task<TEntity> ComputeHasMultipleBankAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_has_multiple_bank_accounts(self):
            // for employee in self:
            //     if employee.bank_account_ids and len(employee.bank_account_ids) > 1:
            //         employee.has_multiple_bank_accounts = True
            //     else:
            //         employee.has_multiple_bank_accounts = False
            */
            return default;
        }

        public async Task<TEntity> ComputeHorsepowerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_horsepower(self):
            // self._load_fields_from_model(['horsepower'])
            */
            return default;
        }

        public async Task<TEntity> ComputeHorsepowerTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_horsepower_tax(self):
            // self._load_fields_from_model(['horsepower_tax'])
            */
            return default;
        }

        public async Task<TEntity> ComputeImStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_guest.py) ---
            // def _compute_im_status(self):
            // for guest in self:
            //     guest.im_status = guest.presence_ids.status or "offline"
            //     guest.offline_since = (
            //         guest.presence_ids.last_poll
            //         if guest.im_status == "offline"
            //         else None
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPublicInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_is_public(self):
            // for partner in self.with_context(active_test=False):
            //     users = partner.user_ids
            //     partner.is_public = users and any(user._is_public() for user in users)
            */
            return default;
        }

        public async Task<TEntity> ComputeIsTrustedBankAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_is_trusted_bank_account(self):
            // for employee in self:
            //     employee.is_trusted_bank_account = employee.primary_bank_account_id.allow_out_payment
            */
            return default;
        }

        public async Task<TEntity> ComputeLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_lang(self):
            // """ While creating / updating child contact, take the parent lang by
            // default if any. 0therwise, fallback to default context / DB lang """
            // for partner in self.filtered('parent_id'):
            //     partner.lang = partner.parent_id.lang or self.default_get(['lang']).get('lang') or self.env.lang
            */
            return default;
        }

        public async Task<TEntity> ComputeLastActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_last_activity(self):
            // for employee in self:
            //     tz = employee.tz
            //     # sudo: res.users - can access presence of accessible user
            //     if last_presence := employee.user_id.sudo().presence_ids.last_presence:
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

        public async Task<TEntity> ComputeLegalNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_legal_name(self):
            // for employee in self:
            //     if not employee.legal_name:
            //         employee.legal_name = employee.name
            */
            return default;
        }

        public async Task<TEntity> ComputeMainUserIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_main_user_id(self):
            // for partner in self:
            //     if self.env.user.partner_id == partner:
            //         partner.main_user_id = self.env.user
            //         continue
            //     users = partner.user_ids.filtered(lambda u: u.active).with_prefetch(self.user_ids.ids)
            //     # Special case for OdooBot as its user might be archived.
            //     if not users and partner.id == self.env["ir.model.data"]._xmlid_to_res_id("base.partner_root"):
            //         partner.main_user_id = self.env["ir.model.data"]._xmlid_to_res_id("base.user_root")
            //         continue
            //     partner.main_user_id = users.sorted(
            //         lambda u: (not u.share, -u.id), reverse=True,
            //     )[:1]
            */
            return default;
        }

        public async Task<TEntity> ComputeModelYearInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_model_year(self):
            // self._load_fields_from_model(['model_year'])
            */
            return default;
        }

        public async Task<TEntity> ComputeNewlyHiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
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

        public async Task<TEntity> ComputePartnerShareInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_partner_share(self):
            // super_partner = self.env['res.users'].browse(api.SUPERUSER_ID).partner_id
            // if super_partner in self:
            //     super_partner.partner_share = False
            // for partner in self - super_partner:
            //     partner.partner_share = not partner.user_ids or not any(not user.share for user in partner.user_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputePowerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_power(self):
            // self._load_fields_from_model(['power'])
            */
            return default;
        }

        public async Task<TEntity> ComputePresenceIconInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_presence_icon(self):
            // """
            // This method compute the state defining the display icon in the kanban view.
            // It can be overriden to add other possibilities, like time off or attendances recordings.
            // """
            // for employee in self:
            //     employee.hr_icon_display = 'presence_' + employee.hr_presence_state
            //     employee.show_hr_icon_display = bool(employee.user_id)
            */
            return default;
        }

        public async Task<TEntity> ComputePresenceStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_presence_state(self):
            // """
            // This method is overritten in several other modules which add additional
            // presence criterions. e.g. hr_attendance, hr_holidays
            // """
            // # sudo: res.users - can access presence of accessible user
            // employee_to_check_working = self.filtered(
            //     lambda e: (e.user_id.sudo().presence_ids.status or "offline") == "offline"
            // )
            // working_now_list = employee_to_check_working._get_employee_working_now()
            // for employee in self:
            //     state = 'out_of_working_hour'
            //     if employee.company_id.sudo().hr_presence_control_login:
            //         # sudo: res.users - can access presence of accessible user
            //         presence_status = employee.user_id.sudo().presence_ids.status or "offline"
            //         if presence_status == "online":
            //             state = 'present'
            //         elif presence_status == "offline" and employee.id in working_now_list:
            //             state = 'absent'
            //     if not employee.active:
            //         state = 'archive'
            //     employee.hr_presence_state = state
            */
            return default;
        }

        public async Task<TEntity> ComputePrimaryBankAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_primary_bank_account_id(self):
            // for employee in self:
            //     if employee.bank_account_ids:
            //         primary_account = min(
            //             employee.bank_account_ids,
            //             key=lambda acc: employee.salary_distribution.get(str(acc.id), {}).get("sequence", float("inf")),
            //         )
            //         employee.primary_bank_account_id = primary_account
            //     else:
            //         employee.primary_bank_account_id = False
            */
            return default;
        }

        public async Task<TEntity> ComputeRangeUnitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_range_unit(self):
            // self._load_fields_from_model(['range_unit'])
            */
            return default;
        }

        public async Task<TEntity> ComputeRelatedPartnersCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_related_partners_count(self):
            // self.related_partners_count = len(self._get_related_partners())
            */
            return default;
        }

        public async Task<TEntity> ComputeSameVatPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_same_vat_partner_id(self):
            // for partner in self:
            //     # use _origin to deal with onchange()
            //     partner_id = partner._origin.id
            //     # active_test = False because if a partner has been deactivated you still want to raise the error,
            //     # so that you can reactivate it instead of creating a new one, which would lose its history.
            //     Partner = self.with_context(active_test=False).sudo()
            //     vats = [partner.vat]
            //     should_check_vat = partner.vat and len(partner.vat) != 1
            // 
            //     if should_check_vat and partner.country_id and 'EU_PREFIX' in partner.country_id.country_group_codes:
            //         if partner.vat[:2].isalpha():
            //             vats.append(partner.vat[2:])
            //         else:
            //             vats.append(partner.country_id.code + partner.vat)
            //             if new_code := EU_EXTRA_VAT_CODES.get(partner.country_id.code):
            //                 vats.append(new_code + partner.vat)
            //     domain = [
            //         ('vat', 'in', vats),
            //     ]
            //     if partner.country_id:
            //         domain += [('country_id', 'in', [partner.country_id.id, False])]
            //     if partner.company_id:
            //         domain += [('company_id', 'in', [False, partner.company_id.id])]
            //     if partner_id:
            //         domain += [('id', '!=', partner_id), '!', ('id', 'child_of', partner_id)]
            //     # For VAT number being only one character, we will skip the check just like the regular check_vat
            // 
            //     partner.same_vat_partner_id = should_check_vat and not partner.parent_id and Partner.search(domain, limit=1)
            //     # check company_registry
            //     domain = [
            //         ('company_registry', '=', partner.company_registry),
            //         ('company_id', 'in', [False, partner.company_id.id]),
            //     ]
            //     if partner_id:
            //         domain += [('id', '!=', partner_id), '!', ('id', 'child_of', partner_id)]
            //     partner.same_company_registry_partner_id = bool(partner.company_registry) and not partner.parent_id and Partner.search(domain, limit=1)
            */
            return default;
        }

        public async Task<TEntity> ComputeSeatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_seats(self):
            // self._load_fields_from_model(['seats'])
            */
            return default;
        }

        public async Task<TEntity> ComputeServiceActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_service_activity(self):
            // for vehicle in self:
            //     activities_state = set(state for state in vehicle.log_services.mapped('activity_state') if state and state != 'planned')
            //     vehicle.service_activity = sorted(activities_state)[0] if activities_state else 'none'
            */
            return default;
        }

        public async Task<TEntity> ComputeTrailerHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_trailer_hook(self):
            // self._load_fields_from_model(['trailer_hook'])
            */
            return default;
        }

        public async Task<TEntity> ComputeTransmissionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_transmission(self):
            // self._load_fields_from_model(['transmission'])
            */
            return default;
        }

        public async Task<TEntity> ComputeTypeAddressLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_type_address_label(self):
            // for partner in self:
            //     if partner.type == 'invoice':
            //         partner.type_address_label = _('Invoice Address')
            //     elif partner.type == 'delivery':
            //         partner.type_address_label = _('Delivery Address')
            //     elif partner.type == 'contact' and partner.parent_id:
            //         partner.type_address_label = _('Company Address')
            //     else:
            //         partner.type_address_label = _('Address')
            */
            return default;
        }

        public async Task<TEntity> ComputeTzOffsetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_tz_offset(self):
            // for partner in self:
            //     partner.tz_offset = datetime.datetime.now(pytz.timezone(partner.tz or 'GMT')).strftime('%z')
            */
            return default;
        }

        public async Task<TEntity> ComputeUserIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_user_id(self):
            // """ Synchronize sales rep with parent if partner is a person """
            // for partner in self.filtered(lambda partner: not partner.user_id and partner.company_type == 'person' and partner.parent_id.user_id):
            //     partner.user_id = partner.parent_id.user_id
            */
            return default;
        }

        public async Task<TEntity> ComputeVatLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_vat_label(self):
            // self.vat_label = self.env.company.country_id.vat_label or _("Tax ID")
            */
            return default;
        }

        public async Task<TEntity> ComputeVehicleCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py) ---
            // def _compute_vehicle_count(self):
            // group = self.env['fleet.vehicle']._read_group(
            //     [('model_id', 'in', self.ids)], ['model_id'], aggregates=['__count'],
            // )
            // count_by_model = {model.id: count for model, count in group}
            // for model in self:
            //     model.vehicle_count = count_by_model.get(model.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeVehicleNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_vehicle_name(self):
            // for record in self:
            //     record.name = (record.model_id.brand_id.name or '') + '/' + (record.model_id.name or '') + '/' + (record.license_plate or _('No Plate'))
            */
            return default;
        }

        public async Task<TEntity> ComputeVehicleRangeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_vehicle_range(self):
            // self._load_fields_from_model(['vehicle_range'])
            */
            return default;
        }

        public async Task<TEntity> ComputeVersionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_version_id(self):
            // context_version_id = self.env.context.get('version_id', False)
            // context_version = self.env['hr.version'].browse(context_version_id).exists() if context_version_id else self.env['hr.version']
            // 
            // for employee in self:
            //     if context_version.employee_id == self:
            //         version = context_version
            //     else:
            //         version = employee.current_version_id
            //     employee.version_id = version
            */
            return default;
        }

        public async Task<TEntity> ComputeVersionsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_versions_count(self):
            // version_count_per_employee = dict(
            //     self.env['hr.version']._read_group(
            //         [('employee_id', 'in', self.ids)],
            //         ['employee_id'],
            //         ['id:count'],
            //     ),
            // )
            // for employee in self:
            //     employee.versions_count = version_count_per_employee.get(employee, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkContactDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_work_contact_details(self):
            // for employee in self:
            //     if employee.work_contact_id:
            //         if len(employee.work_contact_id.employee_ids) <= 1:
            //             employee.work_phone = employee.work_contact_id.phone
            //             employee.work_email = employee.work_contact_id.email
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkLocationNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_work_location_name(self):
            // for employee in self:
            //     employee.work_location_name = employee.version_id.work_location_id.name or None
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkLocationTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_work_location_type(self):
            // for employee in self:
            //     employee.work_location_type = employee.version_id.work_location_id.location_type or 'other'
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkPermitNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> ConvertFieldsToValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_names) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _convert_fields_to_values(self, field_names):
            // """ Returns dict of write() values for synchronizing ``field_names`` """
            // if any(self._fields[fname].type == 'one2many' for fname in field_names):
            //     raise AssertionError(_('One2Many fields cannot be synchronized as part of `commercial_fields` or `address fields`'))
            // return self._convert_to_write({fname: self[fname] for fname in field_names})
            */
            return default;
        }

        public async Task<TEntity> CopyCacheFromInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @public, object field_names) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // if default.get('name'):
            //     return vals_list
            // return [dict(vals, name=self.env._("%s (copy)", partner.name)) for partner, vals in zip(self, vals_list)]
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def create(self, vals_list):
            // to_update_drivers_cars = set()
            // to_update_drivers_bikes = set()
            // state_waiting_list = self.env.ref('fleet.fleet_vehicle_state_waiting_list', raise_if_not_found=False)
            // for vals in vals_list:
            //     if vals.get('future_driver_id'):
            //         state_id = vals.get('state_id')
            //         if not state_waiting_list or state_waiting_list.id != state_id:
            //             future_driver = vals['future_driver_id']
            //             if vals.get('vehicle_type') == 'bike':
            //                 to_update_drivers_bikes.add(future_driver)
            //             elif vals.get('vehicle_type') == 'car':
            //                 to_update_drivers_cars.add(future_driver)
            // if to_update_drivers_cars:
            //     self.search([
            //         ('driver_id', 'in', to_update_drivers_cars),
            //         ('vehicle_type', '=', 'car'),
            //     ]).plan_to_change_car = True
            // if to_update_drivers_bikes:
            //     self.search([
            //         ('driver_id', 'in', to_update_drivers_bikes),
            //         ('vehicle_type', '=', 'bike'),
            //     ]).plan_to_change_bike = True
            // 
            // vehicles = super().create(vals_list)
            // 
            // for vehicle, vals in zip(vehicles, vals_list):
            //     if vals.get('driver_id'):
            //         vehicle.create_driver_history(vals)
            // return vehicles
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def create(self, vals_list):
            // vals_per_company = defaultdict(list)
            // for idx, vals in enumerate(vals_list):
            //     if vals.get('user_id'):
            //         user = self.env['res.users'].browse(vals['user_id'])
            //         vals.update(self._sync_user(user, bool(vals.get('image_1920'))))
            //         vals['name'] = vals.get('name', user.name)
            //         self._remove_work_contact_id(user, vals.get('company_id'))
            //     # Having one create per company is necessary to pass the company in the context to correctly set it in
            //     # the underlying version created by the framework
            //     vals_per_company[vals.get('company_id', self.env.company)].append((idx, vals))
            // index_per_employee = {}
            // employees = self.env['hr.employee']
            // for company, vals_list in vals_per_company.items():
            //     idxs, vals_list = zip(*vals_list)
            //     new_employees = super(HrEmployee, self.with_company(company)).create(vals_list)
            //     index_per_employee.update(dict(zip(new_employees, idxs)))
            //     employees |= new_employees
            // # As we do a custom batch by company, we must reorder the records to respect the original order.
            // employees = employees.sorted(key=lambda employee: index_per_employee[employee])
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
            // employees.invalidate_recordset()
            // return employees
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def create(self, vals_list):
            // if self.env.context.get('import_file'):
            //     self._check_import_consistency(vals_list)
            // for vals in vals_list:
            //     if vals.get('website'):
            //         vals['website'] = self._clean_website(vals['website'])
            //     if vals.get('parent_id'):
            //         vals['company_name'] = False
            // partners = super().create(vals_list)
            // # due to ir.default, compute is not called as there is a default value
            // # hence calling the compute manually
            // for partner, values in zip(partners, vals_list):
            //     if 'lang' not in values and partner.parent_id:
            //         partner._compute_lang()
            // 
            // if self.env.context.get('_partners_skip_fields_sync'):
            //     return partners
            // 
            // for partner, vals in zip(partners, vals_list):
            //     partner._fields_sync(vals)
            // return partners
            */
            return default;
        }

        public async Task<TEntity> CreateCompanyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def create_company(self):
            // self.ensure_one()
            // if (new_company := self._create_contact_parent_company()):
            //     # Set new company as my parent
            //     self.write({
            //         'parent_id': new_company.id,
            //         'child_ids': [Command.update(partner_id, dict(parent_id=new_company.id)) for partner_id in self.child_ids.ids]
            //     })
            // return True
            */
            return default;
        }

        public async Task<TEntity> CreateContactParentCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _create_contact_parent_company(self):
            // self.ensure_one()
            // if self.company_name:
            //     # Create parent company
            //     values = dict(name=self.company_name, is_company=True, vat=self.vat)
            //     values.update(self._convert_fields_to_values(self._address_fields()))
            //     return self.create(values)
            // return self.browse()
            */
            return default;
        }

        public async Task<TEntity> CreateContractAsync<TEntity>(IEnumerable<TEntity> entities, object date) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def create_contract(self, date):
            // # Here we can assume that there is no existing contract on the date given
            // self.ensure_one()
            // if date and isinstance(date, str):
            //     date = fields.Date.to_date(date)
            // 
            // contracts = self._get_contract_versions(date)[self.id]
            // future_contract_dates = [d for d in list(contracts.keys()) if d > date]
            // new_contract_date_end = min(future_contract_dates) + relativedelta(days=-1) if future_contract_dates else False
            // 
            // # There is already a version but with no contract defined on it so we simply write on it the dates
            // if version_same_date := self.version_ids.filtered(lambda v: v.date_version == date):
            //     version_same_date.write({
            //         'contract_date_start': date,
            //         'contract_date_end': new_contract_date_end
            //     })
            //     return version_same_date
            // 
            // return self.create_version({
            //     'date_version': date,
            //     'contract_date_start': date,
            //     'contract_date_end': new_contract_date_end
            // })
            */
            return default;
        }

        public async Task<TEntity> CreateDriverHistoryAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def create_driver_history(self, vals):
            // for vehicle in self:
            //     self.env['fleet.vehicle.assignation.log'].create(
            //         vehicle._get_driver_history_data(vals),
            //     )
            */
            return default;
        }

        public async Task<TEntity> CreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data_list) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _create(self, data_list):
            // versions = [vals['stored'].pop('version_id', None) for vals in data_list]
            // result = super()._create(data_list)
            // for (employee, version_id, vals) in zip(result, versions, data_list):
            //     version = self.env['hr.version'].browse(version_id)
            //     version.employee_id = employee.id
            //     version.write({**vals.get('inherited', {})['hr.version'], 'employee_id': employee.id})
            // return result
            */
            return default;
        }

        public async Task<TEntity> CreateVersionAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def create_version(self, values):
            // self.ensure_one()
            // 
            // date = values.get('date_version', False)
            // if not date:
            //     raise ValueError("date_version is required")
            // 
            // if isinstance(date, str):
            //     date = fields.Date.to_date(date)
            // elif isinstance(date, datetime):
            //     date = date.date()
            // 
            // version_to_copy = self._get_version(date)
            // if not version_to_copy:
            //     version_to_copy = self.env['hr.version'].search([('employee_id', '=', self.id)], limit=1)
            // if version_to_copy.date_version == date:
            //     return version_to_copy
            // 
            // date_from, date_to = self.sudo()._get_contract_dates(date)
            // contract_date_start = values.get('contract_date_start', date_from)
            // contract_date_end = values.get('contract_date_end', date_to)
            // employee_id = values.get('employee_id', self.id)
            // 
            // if isinstance(contract_date_start, str):
            //     contract_date_start = fields.Date.to_date(contract_date_start)
            // if isinstance(contract_date_end, str):
            //     contract_date_end = fields.Date.to_date(contract_date_end)
            // 
            // if contract_date_start == date_from and contract_date_end != date_to:
            //     versions_sudo_to_sync = self.env['hr.version'].with_context(sync_contract_dates=True).sudo().search([
            //         ('employee_id', '=', employee_id),
            //         ('contract_date_start', '=', date_from),
            //     ])
            //     if versions_sudo_to_sync:
            //         versions_sudo_to_sync.write({
            //             'contract_date_end': contract_date_end,
            //         })
            // self.check_access('write')
            // version_to_copy.check_access('write')
            // # to be sure even if the user has no access to certain fields, we can still copy the verison without any issues.
            // copy_vals = {
            //     'date_version': date,
            //     'employee_id': employee_id,
            //     'contract_date_start': contract_date_start,
            //     'contract_date_end': contract_date_end,
            // }
            // if 'active' in values:
            //     copy_vals['active'] = values['active']
            // if calendar_id := values.get('resource_calendar_id'):
            //     copy_vals['resource_calendar_id'] = calendar_id
            // # apply the changes on the new versions.
            // new_version_vals = {
            //     field_name: field_value
            //     for field_name, field_value in values.items()
            //     if field_name not in copy_vals
            // }
            // version_fields = self.env['hr.version']._fields
            // copy_vals = {
            //     k: v
            //     for k, v in version_to_copy.sudo().copy_data()[0].items()
            //     if not (k in new_version_vals and version_fields[k].type in ['one2many', 'many2many'])
            // } | copy_vals
            // new_version = self.env['hr.version'].sudo().create(copy_vals).sudo(False)
            // with self.env.protecting([f for f_name, f in version_fields.items() if f_name not in new_version_vals and f.copy], new_version):
            //     properties_fields_vals = {
            //         field_name: field_value
            //         for field_name, field_value in copy_vals.items()
            //         if version_fields[field_name].type == 'properties' and field_name not in new_version_vals
            //     }
            //     if properties_fields_vals:  # make sure properties vals are correctly copied.
            //         new_version.sudo().write(properties_fields_vals)
            //     new_version.write(new_version_vals)
            // return new_version
            */
            return default;
        }

        public async Task<TEntity> CreateWorkContactsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _create_work_contacts(self):
            // if any(employee.work_contact_id for employee in self):
            //     raise UserError(_('Some employee already have a work contact'))
            // work_contacts = self.env['res.partner'].create([{
            //     'email': employee.work_email,
            //     'phone': employee.work_phone,
            //     'name': employee.name,
            //     'image_1920': employee.image_1920,
            //     'company_id': employee.company_id.id
            // } for employee in self])
            // for employee, work_contact in zip(self, work_contacts):
            //     employee.work_contact_id = work_contact
            */
            return default;
        }

        public async Task<TEntity> CronUpdateCurrentVersionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _cron_update_current_version_id(self):
            // self.search([])._compute_current_version_id()
            */
            return default;
        }

        public async Task<TEntity> DefaultCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _default_category(self):
            // return self.env['res.partner.category'].browse(self.env.context.get('category_id'))
            */
            return default;
        }

        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def default_get(self, fields):
            // """Add the company of the parent as default if we are creating a child partner. """
            // values = super().default_get(fields)
            // if 'parent_id' in fields and values.get('parent_id'):
            //     parent = self.browse(values.get('parent_id'))
            //     values['company_id'] = parent.company_id.id
            // # protection for `default_type` values leaking from menu action context (e.g. for crm's email)
            // if 'type' in fields and values.get('type'):
            //     if values['type'] not in self._fields['type'].get_values(self.env):
            //         values['type'] = None
            // return values
            */
            return default;
        }

        public async Task<TEntity> DisplayAddressDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _display_address_depends(self):
            // # field dependencies of method _display_address()
            // return self._formatting_address_fields() + [
            //     'country_id', 'company_name', 'state_id',
            // ]
            */
            return default;
        }

        public async Task<TEntity> DisplayAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object without_company) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _display_address(self, without_company=False):
            // '''
            // The purpose of this function is to build and return an address formatted accordingly to the
            // standards of the country where it belongs.
            // 
            // :param without_company: if address contains company
            // :returns: the address formatted in a display that fit its country habits (or the default ones
            //     if not country is specified)
            // :rtype: string
            // '''
            // address_format, args = self._prepare_display_address(without_company)
            // return address_format % args
            */
            return default;
        }

        public async Task<TEntity> EmployeeAttendanceIntervalsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object stop, object lunch) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _employee_attendance_intervals(self, start, stop, lunch=False):
            // self.ensure_one()
            // if not lunch:
            //     return self._get_expected_attendances(start, stop)
            // else:
            //     valid_versions = self.sudo()._get_versions_with_contract_overlap_with_period(start.date(), stop.date())
            //     if not valid_versions:
            //         calendar = self.resource_calendar_id or self.company_id.resource_calendar_id
            //         return calendar._attendance_intervals_batch(start, stop, self.resource_id, lunch=True)[self.resource_id.id]
            //     employee_tz = timezone(self.tz) if self.tz else None
            //     duration_data = Intervals()
            //     for version in valid_versions:
            //         version_start = datetime.combine(version.date_start, time.min, employee_tz)
            //         version_end = datetime.combine(version.date_end or date.max, time.max, employee_tz)
            //         calendar = version.resource_calendar_id or version.company_id.resource_calendar_id
            //         lunch_intervals = calendar._attendance_intervals_batch(
            //             max(start, version_start),
            //             min(stop, version_end),
            //             resources=self.resource_id,
            //             lunch=True)[self.resource_id.id]
            //         duration_data = duration_data | lunch_intervals
            //     return duration_data
            */
            return default;
        }

        public async Task<TEntity> FetchAsync<TEntity>(IEnumerable<TEntity> entities, object field_names) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def fetch(self, field_names=None):
            // if self.browse().has_access('read'):
            //     return super().fetch(field_names)
            // 
            // # HACK: retrieve publicly available values from hr.employee.public and
            // # copy them to the cache of self; non-public data will be missing from
            // # cache, and interpreted as an access error
            // if field_names is None:
            //     field_names = [field.name for field in self._determine_fields_to_fetch()]
            // field_names = [f_name for f_name in field_names if f_name != 'current_version_id']
            // self._check_private_fields(field_names)
            // self.flush_recordset(field_names)
            // public = self.env['hr.employee.public'].browse(self._ids)
            // public.fetch(field_names)
            // # make sure all related fields from employee are in cache
            // for field_name in field_names:
            //     public_field = self.env['hr.employee.public']._fields[field_name]
            //     private_field = self.env['hr.employee']._fields[field_name]
            //     if (public_field.related and public_field.related_field.model_name == 'hr.employee'
            //             or private_field.inherited and private_field.inherited_field.model_name == 'hr.version'):
            //         public.mapped(field_name)
            // self._copy_cache_from(public, field_names)
            */
            return default;
        }

        public async Task<TEntity> FieldStoreReprInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_guest.py) ---
            // def _field_store_repr(self, field_name):
            // if field_name == "avatar_128":
            //     return [
            //         Store.Attr("avatar_128_access_token", lambda g: g._get_avatar_128_access_token()),
            //         "write_date",
            //     ]
            // if field_name == "im_status":
            //     return [
            //         "im_status",
            //         Store.Attr("im_status_access_token", lambda g: g._get_im_status_access_token()),
            //     ]
            // return [field_name]
            */
            return default;
        }

        public async Task<object> FieldToSqlInternalAsync<TEntity>(IEnumerable<TEntity> entities, string @alias, string field_expr, object query) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _field_to_sql(self, alias: str, field_expr: str, query: (Query | None) = None) -> SQL:
            // """This is required to search for the related fields of version_id as version_id is not stored"""
            // if field_expr == 'version_id':
            //     field_expr = 'current_version_id'
            // return super()._field_to_sql(alias, field_expr, query)
            */
            return default;
        }

        public async Task<TEntity> FieldsSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _fields_sync(self, values):
            // """ Sync commercial fields and address fields from company and to children.
            // Also synchronize address to parent. This somehow mimics related fields
            // to the parent, with more control. This method should be called after
            // updating values in cache e.g. self should contain new values.
            // 
            // :param dict values: updated values, triggering sync
            // """
            // # 1. From UPSTREAM: sync from parent
            // if values.get('parent_id') or values.get('type') == 'contact':
            //     # 1a. Commercial fields: sync if parent changed
            //     if values.get('parent_id'):
            //         self.sudo()._commercial_sync_from_company()
            //     # 1b. Address fields: sync if parent or use_parent changed *and* both are now set
            //     if self.parent_id and self.type == 'contact':
            //         if address_values := self.parent_id._get_address_values():
            //             self._update_address(address_values)
            // 
            // # 2. To UPSTREAM: sync parent address, as well as editable synchronized commercial fields
            // address_to_upstream = (
            //     # parent is set, potential address update as contact address = parent address
            //     bool(self.parent_id) and bool(self.type == 'contact') and
            //     # address updated, or parent updated
            //     (any(field in values for field in self._address_fields()) or 'parent_id' in values) and
            //     # something is actually updated
            //     any(self[fname] != self.parent_id[fname] for fname in self._address_fields())
            // )
            // if address_to_upstream:
            //     new_address = self._get_address_values()
            //     self.parent_id.write(new_address)  # is going to trigger _fields_sync again
            // commercial_to_upstream = (
            //     # has a parent and is not a commercial entity itself
            //     bool(self.parent_id) and (self.commercial_partner_id != self) and
            //     # actually updated, or parent updated
            //     (any(field in values for field in self._synced_commercial_fields()) or 'parent_id' in values) and
            //     # something is actually updated
            //     any(self[fname] != self.parent_id[fname] for fname in self._synced_commercial_fields())
            // )
            // if commercial_to_upstream:
            //     new_synced_commercials = self._get_synced_commercial_values()
            //     self.parent_id.write(new_synced_commercials)
            // 
            // # 3. To DOWNSTREAM: sync children
            // self._children_sync(values)
            */
            return default;
        }

        public async Task<TEntity> FindOrCreateAsync<TEntity>(IEnumerable<TEntity> entities, object email, object assert_valid_email) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def find_or_create(self, email, assert_valid_email=False):
            // """ Find a partner with the given ``email`` or use :meth:`name_create`
            // to create a new one.
            // 
            // :param str email: email-like string, which should contain at least one email,
            //     e.g. ``"Raoul Grosbedon <r.g@grosbedon.fr>"``
            // :param bool assert_valid_email: raise if no valid email is found
            // :return: newly created record
            // """
            // if not email:
            //     raise ValueError(_('An email is required for find_or_create to work'))
            // 
            // parsed_name, parsed_email_normalized = tools.parse_contact_from_email(email)
            // if not parsed_email_normalized and assert_valid_email:
            //     raise ValueError(_('A valid email is required for find_or_create to work properly.'))
            // 
            // if parsed_email_normalized:
            //     partners = self.search([('email', '=ilike', parsed_email_normalized)], limit=1)
            //     if partners:
            //         return partners
            // 
            // create_values = {self._rec_name: parsed_name or parsed_email_normalized}
            // if parsed_email_normalized:  # keep default_email in context
            //     create_values['email'] = parsed_email_normalized
            // return self.create(create_values)
            */
            return default;
        }

        public async Task<TEntity> FormatAuthCookieInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_guest.py) ---
            // def _format_auth_cookie(self):
            // """Format the cookie value for the given guest.
            // 
            // :return: formatted cookie value
            // :rtype: str
            // """
            // self.ensure_one()
            // return f"{self.id}{self._cookie_separator}{self.access_token}"
            */
            return default;
        }

        public async Task<TEntity> FormattingAddressFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _formatting_address_fields(self):
            // """Returns the list of address fields usable to format addresses."""
            // return self._address_fields()
            */
            return default;
        }

        public async Task<TEntity> GenerateRandomBarcodeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def generate_random_barcode(self):
            // for employee in self:
            //     employee.barcode = '041'+"".join(choice(digits) for i in range(9))
            */
            return default;
        }

        public async Task<TEntity> GetAccountsWithFixedAllocationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_accounts_with_fixed_allocations(self):
            // self.ensure_one()
            // return self.bank_account_ids.filtered(
            //     lambda a: not self.salary_distribution.get(str(a.id), {}).get('amount_is_percentage', True)
            // )
            */
            return default;
        }

        public async Task<TEntity> GetAddressFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_address_format(self):
            // return self.country_id.address_format or self._get_default_address_format()
            */
            return default;
        }

        public async Task<TEntity> GetAddressValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_address_values(self):
            // """ Get address values from record if at least one value is set. Otherwise
            // it is considered empty and nothing is returned. """
            // address_fields = self._address_fields()
            // if any(self[key] for key in address_fields):
            //     return self._convert_fields_to_values(address_fields)
            // return {}
            */
            return default;
        }

        public async Task<TEntity> GetAgeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_date) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> GetAllAddrInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_all_addr(self):
            // self.ensure_one()
            // return [{
            //     'contact_type': self.street,
            //     'street': self.street,
            //     'zip': self.zip,
            //     'city': self.city,
            //     'country': self.country_id.code,
            // }]
            */
            return default;
        }

        public async Task<TEntity> GetAllContractDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_all_contract_dates(self):
            // """
            // Return a list of intervals (date_from, date_to) where the employee is in contract.
            // For a permanent contract, the interval is (date_from, False).
            // """
            // self.ensure_one()
            // return self.env['hr.version']._read_group(
            //     [('employee_id', '=', self.id), ('contract_date_start', '!=', False)],
            //     ['contract_date_start:day', 'contract_date_end:day'])
            */
            return default;
        }

        public async Task<TEntity> GetAllVersionsWithContractOverlapWithPeriodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_all_versions_with_contract_overlap_with_period(self, date_from, date_to):
            // """
            // Returns the versions of all employees between date_from and date_to
            // that have at least 1 day in contract during that period
            // """
            // all_employees = self.search(['|', ('active', '=', True), ('active', '=', False)])
            // return all_employees._get_versions_with_contract_overlap_with_period(date_from, date_to)
            */
            return default;
        }

        public async Task<TEntity> GetAnalyticNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _get_analytic_name(self):
            // # This function is used in fleet_account and is overrided in l10n_be_hr_payroll_fleet
            // return self.license_plate or _('No plate')
            */
            return default;
        }

        public async Task<TEntity> GetAvatar128AccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py) ---
            // def _get_avatar_128_access_token(self):
            // """Return a scoped access token for the `avatar_128` field. The token can be
            // used with `ir_binary._find_record` to bypass access rights.
            // 
            // :rtype: str
            // """
            // self.ensure_one()
            // return limited_field_access_token(self, "avatar_128", scope="binary")
            */
            return default;
        }

        public async Task<TEntity> GetAvatarCardDataAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_avatar_card_data(self, fields):
            // return self.read(fields)
            */
            return default;
        }

        public async Task<TEntity> GetBankAccountSalaryAllocationAsync<TEntity>(IEnumerable<TEntity> entities, Guid account_id) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_bank_account_salary_allocation(self, account_id):
            // ba_info = self.salary_distribution.get(str(account_id), {})
            // return ba_info.get('amount', 0), ba_info.get('amount_is_percentage')
            */
            return default;
        }

        public async Task<TEntity> GetCalendarAttendancesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_calendar_attendances(self, date_from, date_to):
            // self.ensure_one()
            // valid_versions = self.sudo()._get_versions_with_contract_overlap_with_period(date_from.date(), date_to.date())
            // employee_tz = timezone(self.tz) if self.tz else None
            // if not valid_versions:
            //     calendar = self.resource_calendar_id or self.company_id.resource_calendar_id
            //     return calendar.with_context(employee_timezone=employee_tz).get_work_duration_data(
            //         date_from,
            //         date_to,
            //         domain=[('company_id', 'in', [False, self.company_id.id])])
            // duration_data = {'days': 0, 'hours': 0}
            // for version in valid_versions:
            //     version_start = datetime.combine(version.date_start, time.min, employee_tz)
            //     version_end = datetime.combine(version.date_end or date.max, time.max, employee_tz)
            //     calendar = version.resource_calendar_id or version.company_id.resource_calendar_id
            //     version_duration_data = calendar\
            //         .with_context(employee_timezone=employee_tz)\
            //         .get_work_duration_data(
            //             max(date_from, version_start),
            //             min(date_to, version_end),
            //             domain=[('company_id', 'in', [False, version.company_id.id])])
            //     duration_data['days'] += version_duration_data['days']
            //     duration_data['hours'] += version_duration_data['hours']
            // return duration_data
            */
            return default;
        }

        public async Task<TEntity> GetCalendarPeriodsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object stop, object check_contract) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_calendar_periods(self, start, stop, check_contract=True):
            // """
            // :param datetime start: the start of the period
            // :param datetime stop: the stop of the period
            // """
            // return self.sudo()._get_version_periods(start, stop, 'resource_calendar_id', check_contract)
            */
            return default;
        }

        public async Task<TEntity> GetCalendarTzBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object dt) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_calendar_tz_batch(self, dt=None):
            // """ Return a mapping { employee id : employee's effective schedule's (at dt) timezone }
            // """
            // employees_by_id = self.grouped('id')
            // if not dt:
            //     calendars = self._get_calendars()
            //     return {
            //         emp_id: calendar.sudo().tz or employees_by_id[emp_id].tz \
            //             for emp_id, calendar in calendars.items()
            //     }
            // 
            // employees_by_tz = self.grouped(lambda emp: emp._get_tz())
            // 
            // employee_timezones = {}
            // for tz, employee_ids in employees_by_tz.items():
            //     date_at = timezone(tz).localize(dt).date()
            //     calendars = self._get_calendars(date_at)
            //     employee_timezones |= {
            //         emp_id: cal.sudo().tz or employees_by_id[emp_id].tz \
            //             for emp_id, cal in calendars.items()
            //     }
            // return employee_timezones
            */
            return default;
        }

        public async Task<TEntity> GetCalendarsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_calendars(self, date_from=None):
            // res = super()._get_calendars(date_from=date_from)
            // if not date_from:
            //     return res
            // 
            // date_from = fields.Date.to_date(date_from)
            // for employee in self:
            //     employee_versions_sudo = employee.sudo().version_ids.filtered(lambda v: v._is_in_contract(date_from))
            //     if employee_versions_sudo:
            //         res[employee.id] = employee_versions_sudo[0].resource_calendar_id.sudo(False)
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetCertificateSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_certificate_selection(self):
            // return [
            //     ('graduate', self.env._('Graduate')),
            //     ('bachelor', self.env._('Bachelor')),
            //     ('master', self.env._('Master')),
            //     ('doctor', self.env._('Doctor')),
            //     ('other', self.env._('Other')),
            // ]
            */
            return default;
        }

        public async Task<TEntity> GetCommercialValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_commercial_values(self):
            // """ Get commercial values from record. Return only set values, as they
            // are considered individually, and only set values should be taken into
            // account. """
            // set_commercial_fields = [fname for fname in self._commercial_fields() if self[fname]]
            // if set_commercial_fields:
            //     return self._convert_fields_to_values(set_commercial_fields)
            // return {}
            */
            return default;
        }

        public async Task<TEntity> GetCompanyRegistryLabelsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_company_registry_labels(self):
            // return {}
            */
            return default;
        }

        public async Task<TEntity> GetCompleteNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_complete_name(self):
            // self.ensure_one()
            // 
            // displayed_types = self._complete_name_displayed_types
            // type_description = dict(self._fields['type']._description_selection(self.env))
            // 
            // name = self.name or ''
            // if self.company_name or self.parent_id:
            //     if not name and self.type in displayed_types:
            //         name = type_description[self.type]
            //     if not self.is_company and not self.env.context.get('partner_display_name_hide_company'):
            //         name = f"{self.commercial_company_name or self.sudo().parent_id.name}, {name}"
            // return name.strip()
            */
            return default;
        }

        public async Task<TEntity> GetContractDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_contract_dates(self, date):
            // """
            // Return a tuple (date_from, date_to) of the contract at the date given.
            // (False, False) if the employee is not in contract at that date.
            // """
            // self.ensure_one()
            // for date_from, date_to in self._get_all_contract_dates():
            //     if date_from <= date and (date_to is False or date_to >= date):
            //         return date_from, date_to
            // return False, False
            */
            return default;
        }

        public async Task<TEntity> GetContractVersionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_start, object date_end, object domain) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_contract_versions(self, date_start=None, date_end=None, domain=None):
            // """
            // Retrieves contract versions for employees within the specified date range and
            // domain. The function constructs a dynamic domain to filter contracts based on
            // the provided arguments and retrieves grouped results. The grouping ensures
            // organization by employee and date, and the results are stored in a structured
            // format for ease of use.
            // 
            // Args:
            //     date_start (datetime.date | None): The start date for filtering contracts.
            //     date_end (datetime.date | None): The end date for filtering contracts.
            //     domain (list | None): Additional domain constraints for filtering.
            // 
            // Returns:
            //     dict: A dictionary where keys are employee IDs and values are lists of
            //           contract version records organized by contract date start and date
            //           range.
            // """
            // version_domain = Domain('contract_date_start', '!=', False)
            // if self.ids:
            //     version_domain &= Domain('employee_id', 'in', self.ids)
            // elif not any(self._ids):  # onchange
            //     version_domain &= Domain('employee_id', 'in', self._origin.ids)
            // if date_start:
            //     version_domain &= Domain('contract_date_end', '=', False) | Domain('contract_date_end', '>=', date_start)
            // if date_end:
            //     version_domain &= Domain('contract_date_start', '<=', date_end)
            // if domain:
            //     version_domain &= domain
            // all_versions = self.env['hr.version']._read_group(
            //     domain=version_domain,
            //     groupby=['employee_id', 'date_version:day'],
            //     aggregates=['id:recordset'],
            // )
            // contract_versions_by_employee = defaultdict(lambda: defaultdict(lambda: self.env["hr.version"]))
            // for employee, _date_version, version in all_versions:
            //     first_version = next(iter(version), version)
            //     contract_versions_by_employee[employee.id][first_version.contract_date_start] |= version
            // return contract_versions_by_employee
            */
            return default;
        }

        public async Task<TEntity> GetContractsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_start, object date_end, object use_latest_version, object domain) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_contracts(self, date_start=None, date_end=None, use_latest_version=True, domain=None):
            // """
            // Retrieve the contracts for employees within a specified date range and based
            // on specified criteria, such as domain filtering and version selection.
            // 
            // This method is used to collect and organize employee contracts based on their
            // versions, date ranges, and other specified options. The resulting contracts are
            // grouped by employee, and their selection logic depends on whether the latest
            // version should be used or not. It supports flexibility in contract retrieval by
            // allowing optional filters for date range and domain.
            // 
            // Args:
            //     date_start (Optional[datetime.date]): The start date to filter the contracts
            //         by. If provided, only contract versions <= this date are considered
            //         based on the selection logic.
            //     date_end (Optional[datetime.date]): The end date to filter the contracts by.
            //         Only contract versions within the range will be retrieved. Defaults to
            //         None if not specified.
            //     domain (Optional[dict]): A dictionary representing additional filters or
            //         constraints to apply to the contract versions retrieved. Defaults to
            //         None.
            //     use_latest_version (bool): Indicates whether to retrieve the version
            //     effective at the end of the contract (or before the date_end) for each employee (True) or
            //     at the start of the contract (before the date_start) (False). Defaults to True.
            // 
            // Returns:
            //     collections.defaultdict: A dictionary mapping each employee's identifier
            //     (employee.id) to a set of their corresponding contracts. Each set contains
            //     version records retrieved and filtered based on the specified criteria.
            // """
            // contract_versions_by_employee = self._get_contract_versions(date_start, date_end, domain)
            // contracts_by_employee = defaultdict(lambda: self.env["hr.version"])
            // for employee_id in contract_versions_by_employee:
            //     for contract_versions in contract_versions_by_employee[employee_id].values():
            //         effective_date = date_end if use_latest_version else date_start
            //         if use_latest_version:
            //             if effective_date:
            //                 correct_versions = contract_versions.filtered(lambda v: v.date_version <= effective_date)
            //                 contracts_by_employee[employee_id] |= correct_versions[-1] if correct_versions else contract_versions[0]
            //             else:
            //                 contracts_by_employee[employee_id] |= contract_versions[-1] if use_latest_version else contract_versions[0]
            // return contracts_by_employee
            */
            return default;
        }

        public async Task<TEntity> GetCountryNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_country_name(self):
            // return self.country_id.name or ''
            */
            return default;
        }

        public async Task<TEntity> GetDefaultAddressFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_default_address_format(self):
            // return "%(street)s\n%(street2)s\n%(city)s %(state_code)s %(zip)s\n%(country_name)s"
            */
            return default;
        }

        public async Task<TEntity> GetDefaultStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _get_default_state(self):
            // state = self.env.ref('fleet.fleet_vehicle_state_new_request', raise_if_not_found=False)
            // return state if state and state.id else False
            */
            return default;
        }

        public async Task<TEntity> GetDepartureDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_departure_date(self):
            // # Primarily used in the archive wizard
            // # to pick a good default for the departure date
            // self.ensure_one()
            // if self.date_end and self.date_end < fields.Date.today():
            //     return self.departure_date
            // return False
            */
            return default;
        }

        public async Task<TEntity> GetDriverHistoryDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _get_driver_history_data(self, vals):
            // self.ensure_one()
            // return {
            //     'vehicle_id': self.id,
            //     'driver_id': vals['driver_id'],
            //     'date_start': fields.Date.today(),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEmployeeM2oToEmptyOnArchivedEmployeesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_employee_m2o_to_empty_on_archived_employees(self):
            // return ['parent_id', 'coach_id']
            */
            return default;
        }

        public async Task<TEntity> GetEmployeeWorkingNowInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_employee_working_now(self):
            // """ Sudo needed to get resource_calendar_id as its normally only accessible by hr_users on version model
            // (accessible on employee by inherits)."""
            // working_now = []
            // # We loop over all the employee tz and the resource calendar_id to detect working hours in batch.
            // all_employee_tz = set(self.mapped('tz'))
            // for tz in all_employee_tz:
            //     employee_ids = self.filtered(lambda e: e.tz == tz)
            //     resource_calendar_ids = employee_ids.sudo().mapped('resource_calendar_id')
            //     for calendar_id in resource_calendar_ids:
            //         res_employee_ids = employee_ids.sudo().filtered(lambda e: e.resource_calendar_id.id == calendar_id.id)
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

        public async Task<TEntity> GetExpectedAttendancesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_expected_attendances(self, date_from, date_to):
            // self.ensure_one()
            // valid_versions = self.sudo()._get_versions_with_contract_overlap_with_period(date_from.date(), date_to.date())
            // employee_tz = timezone(self.tz) if self.tz else None
            // if not valid_versions:
            //     calendar = self.resource_calendar_id or self.company_id.resource_calendar_id
            //     calendar_intervals = calendar._work_intervals_batch(
            //         date_from,
            //         date_to,
            //         tz=employee_tz,
            //         resources=self.resource_id,
            //         compute_leaves=True,
            //         domain=[('company_id', 'in', [False, self.company_id.id])])[self.resource_id.id]
            //     return calendar_intervals
            // duration_data = Intervals()
            // version_prev = datetime.combine(valid_versions[0].date_start, time.min, employee_tz)
            // for version in valid_versions:
            //     version_start = datetime.combine(version.date_start, time.min, employee_tz)
            //     contract_start = datetime.combine(version.contract_date_start, time.min, employee_tz)
            //     version_end = datetime.combine(version.date_end or date.max, time.max, employee_tz)
            //     calendar = version.resource_calendar_id or version.company_id.resource_calendar_id
            //     start_date = version_start if version_prev < version_start else contract_start
            //     version_intervals = calendar._work_intervals_batch(
            //                             max(date_from, start_date),
            //                             min(date_to, version_end),
            //                             tz=employee_tz,
            //                             resources=self.resource_id,
            //                             compute_leaves=True,
            //                             domain=[('company_id', 'in', [False, self.company_id.id]), ('time_type', '=', 'leave')])[self.resource_id.id]
            //     duration_data = duration_data | version_intervals
            // return duration_data
            */
            return default;
        }

        public async Task<TEntity> GetFirstVersionDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object no_gap) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_first_version_date(self, no_gap=True):
            // self.ensure_one()
            // if not self.env.su and not self.env.user.has_group("hr.group_hr_user"):
            //     raise AccessError(_("Only HR users can access first version date on an employee."))
            // 
            // def remove_gap(versions):
            //     # We do not consider a gap of more than 4 days to be a same occupation
            //     # versions are considered to be ordered correctly
            //     if not versions:
            //         return self.env['hr.version']
            //     if len(versions) == 1:
            //         return versions
            //     current_version = versions[0]
            //     older_versions = versions[1:]
            //     current_date = current_version.date_start
            //     for i, other_version in enumerate(older_versions):
            //         # Consider current_version.date_end being false as an error and cut the loop
            //         gap = (current_date - (other_version.date_end or date(2100, 1, 1))).days
            //         current_date = other_version.date_start
            //         if gap >= 4:
            //             return older_versions[0:i] + current_version
            //     return older_versions + current_version
            // 
            // versions = self._get_first_versions().sorted('date_start', reverse=True)
            // if no_gap:
            //     versions = remove_gap(versions)
            // return min(versions.mapped('date_start')) if versions else False
            */
            return default;
        }

        public async Task<TEntity> GetFirstVersionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_first_versions(self):
            // self.ensure_one()
            // versions = self.version_ids
            // if self.env.context.get('before_date'):
            //     versions = versions.filtered(lambda c: c.date_start <= self.env.context['before_date'])
            // return versions
            */
            return default;
        }

        public async Task<TEntity> GetFormviewActionAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_formview_action(self, access_uid=None):
            // """ Override this method in order to redirect many2one towards the right model depending on access_uid """
            // res = super().get_formview_action(access_uid=access_uid)
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

        public async Task<TEntity> GetFormviewIdAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid) where TEntity : IEntity<Guid>, IAvatarMixinable
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
            //     return super().get_formview_id(access_uid=access_uid)
            // # Hardcode the form view for public employee
            // return self.env.ref('hr.hr_employee_public_view_form').id
            */
            return default;
        }

        public async Task<TEntity> GetGuestFromContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_guest.py) ---
            // def _get_guest_from_context(self):
            // """Returns the current guest record from the context, if applicable."""
            // guest = self.env.context.get('guest')
            // if isinstance(guest, self.pool['mail.guest']):
            //     assert len(guest) <= 1, "Context guest should be empty or a single record."
            //     return guest.sudo(False).with_context(guest=guest)
            // return self.env['mail.guest']
            */
            return default;
        }

        public async Task<TEntity> GetGuestFromTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object token) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_guest.py) ---
            // def _get_guest_from_token(self, token=""):
            // """Returns the guest record for the given token, if applicable."""
            // guest = self.env["mail.guest"]
            // parts = token.split(self._cookie_separator)
            // if len(parts) == 2:
            //     guest_id, guest_access_token = parts
            //     # sudo: mail.guest: guests need sudo to read their access_token
            //     guest = self.browse(int(guest_id)).sudo().exists()
            //     if not guest or not guest.access_token or not consteq(guest.access_token, guest_access_token):
            //         guest = self.env["mail.guest"]
            // return guest.sudo(False)
            */
            return default;
        }

        public async Task<TEntity> GetImStatusAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_guest.py) ---
            // def _get_im_status_access_token(self):
            // """Return a scoped access token for the `im_status` field. The token is used in
            // `ir_websocket._prepare_subscribe_data` to grant access to presence channels.
            // 
            // :rtype: str
            // """
            // self.ensure_one()
            // return limited_field_access_token(self, "im_status", scope="mail.presence")
            */
            return default;
        }

        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Employees'),
            //     'template': '/hr/static/xls/hr_employee.xls'
            // }]
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Contacts'),
            //     'template': '/base/static/xls/contacts_import_template.xlsx',
            // }]
            */
            return default;
        }

        public async Task<TEntity> GetNewHireFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_new_hire_field(self):
            // return 'create_date'
            */
            return default;
        }

        public async Task<TEntity> GetOdometerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _get_odometer(self):
            // FleetVehicalOdometer = self.env['fleet.vehicle.odometer']
            // for record in self:
            //     vehicle_odometer = FleetVehicalOdometer.search([('vehicle_id', 'in', record.ids)], limit=1, order='value desc')
            //     if vehicle_odometer:
            //         record.odometer = vehicle_odometer.value
            //     else:
            //         record.odometer = 0
            */
            return default;
        }

        public async Task<TEntity> GetOrCreateGuestInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_guest.py) ---
            // def _get_or_create_guest(self, *, guest_name, country_code, timezone):
            // if not (guest := self._get_guest_from_context()):
            //     guest = self.create(
            //         {
            //             "country_id": self.env["res.country"].search([("code", "=", country_code)]).id,
            //             "lang": get_lang(self.env).code,
            //             "name": guest_name,
            //             "timezone": timezone,
            //         }
            //     )
            //     guest._set_auth_cookie()
            // return guest.sudo(False)
            */
            return default;
        }

        public async Task<TEntity> GetPartnerCountDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_partner_count_depends(self):
            // return ['user_id']
            */
            return default;
        }

        public async Task<TEntity> GetRelatedPartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_related_partners(self):
            // return self.work_contact_id | self.user_id.partner_id
            */
            return default;
        }

        public async Task<TEntity> GetRemainingPercentageAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_remaining_percentage(self):
            // self.ensure_one()
            // distribution = self.salary_distribution or {}
            // allocated = 0.0
            // 
            // for ba_id, vals in distribution.items():
            //     if vals.get('amount_is_percentage'):
            //         allocated += vals.get('amount', 0.0)
            // 
            // remaining = 100.0 - allocated
            // return max(0.0, remaining)
            */
            return default;
        }

        public async Task<TEntity> GetStoreAvatarCardFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_store_avatar_card_fields(self, target):
            // employee_fields = [
            //     "company_id",
            //     Store.One("department_id", ["name"]),
            //     "work_email",
            //     Store.One("work_location_id", ["location_type", "name"]),
            //     "work_phone",
            // ]
            // user = target.get_user(self.env)
            // if user.has_group("hr.group_hr_user"):
            //     # job_title is not a field of hr.employee.public, but it is a field of hr.employee
            //     employee_fields.append("job_title")
            // # HACK: fetch the employee fields from employees to retrieve hr.employee.public fields if no access to hr.employee
            // if len(self) > 0:
            //     self.fetch([
            //         field.field_name if isinstance(field, Store.Attr) else field
            //         for field in employee_fields
            //     ])
            // return employee_fields
            */
            return default;
        }

        public async Task<TEntity> GetStreetSplitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_street_split(self):
            // self.ensure_one()
            // return tools.street_split(self.street or '')
            */
            return default;
        }

        public async Task<TEntity> GetSyncedCommercialValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_synced_commercial_values(self):
            // """ Get synchronized commercial values from ercord. Return only set values
            // as for other commercial values. """
            // set_synced_fields = [fname for fname in self._synced_commercial_fields() if self[fname]]
            // if set_synced_fields:
            //     return self._convert_fields_to_values(set_synced_fields)
            // return {}
            */
            return default;
        }

        public async Task<TEntity> GetTimezoneFromRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_guest.py) ---
            // def _get_timezone_from_request(self, request):
            // timezone = request.cookies.get('tz')
            // return timezone if timezone in pytz.all_timezones else False
            */
            return default;
        }

        public async Task<TEntity> GetTzBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> GetTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_tz(self):
            // self.ensure_one()
            // return self.resource_calendar_id.tz or\
            //        self.tz or\
            //        self.company_id.resource_calendar_id.tz or\
            //        'UTC'
            */
            return default;
        }

        public async Task<TEntity> GetUnusualDaysInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_unusual_days(self, date_from, date_to=None):
            // date_from_date = datetime.strptime(date_from, '%Y-%m-%d %H:%M:%S').date()
            // date_to_date = datetime.strptime(date_to, '%Y-%m-%d %H:%M:%S').date() if date_to else None
            // employee_versions = self.env['hr.version'].sudo().search([('employee_id', '=', self.id)]).filtered(
            //     lambda v: v._is_overlapping_period(date_from_date, date_to_date))
            // if not employee_versions:
            //     # Checking the calendar directly allows to not grey out the leaves taken
            //     # by the employee or fallback to the company calendar
            //     return (self.resource_calendar_id or self.env.company.resource_calendar_id)._get_unusual_days(
            //         datetime.combine(fields.Date.from_string(date_from), time.min).replace(tzinfo=UTC),
            //         datetime.combine(fields.Date.from_string(date_to), time.max).replace(tzinfo=UTC),
            //         self.company_id,
            //     )
            // unusual_days = {}
            // for version in employee_versions:
            //     tmp_date_from = max(date_from_date, version.date_start)
            //     tmp_date_to = min(date_to_date, version.date_end) if version.date_end else date_to_date
            //     unusual_days.update(version.resource_calendar_id.sudo(False)._get_unusual_days(
            //         datetime.combine(fields.Date.from_string(tmp_date_from), time.min).replace(tzinfo=UTC),
            //         datetime.combine(fields.Date.from_string(tmp_date_to), time.max).replace(tzinfo=UTC),
            //         self.company_id,
            //     ))
            // return unusual_days
            */
            return default;
        }

        public async Task<TEntity> GetUserM2oToEmptyOnArchivedEmployeesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_user_m2o_to_empty_on_archived_employees(self):
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetVersionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_version(self, date=fields.Date.today()):
            // """
            // Return the version that should be used for the given date.
            // If no valid version is found, we return the very first version of the employee.
            // """
            // self.ensure_one()
            // versions = self.version_ids.filtered_domain([('date_version', '<=', date)])
            // return max(versions, key=lambda v: v.date_version) if versions else self.version_ids[0]
            */
            return default;
        }

        public async Task<TEntity> GetVersionPeriodsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object stop, object field, object check_contract) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_version_periods(self, start, stop, field=None, check_contract=False):
            // if field and field not in self:
            //     raise UserError(self.env._(
            //         "This field %(field_name)s doesn't exist on this model (hr.version).",
            //         field_name=field
            //     ))
            // version_periods_by_employee = defaultdict(list)
            // if check_contract:
            //     versions = self._get_versions_with_contract_overlap_with_period(start.date(), stop.date())
            // else:
            //     versions = self.version_ids.filtered_domain([
            //         ('date_start', '<=', stop),
            //         '|',
            //             ('date_end', '=', False),
            //             ('date_end', '>=', start)
            //     ])
            // for version in versions:
            //     # if employee is under fully flexible contract, use timezone of the employee
            //     calendar_tz = timezone(version.resource_calendar_id.tz) if version.resource_calendar_id else timezone(version.employee_id.resource_id.tz)
            //     date_start = datetime.combine(version.date_start, time.min).replace(tzinfo=calendar_tz).astimezone(utc)
            //     end_date = version.date_end
            //     if end_date:
            //         date_end = datetime.combine(
            //             end_date + relativedelta(days=1),
            //             time.min,
            //         ).replace(tzinfo=calendar_tz).astimezone(utc)
            //     else:
            //         date_end = stop
            //     version_periods_by_employee[version.employee_id].append(
            //         (max(date_start, start), min(date_end, stop), version[field] if field else version))
            // return version_periods_by_employee
            */
            return default;
        }

        public async Task<TEntity> GetVersionsWithContractOverlapWithPeriodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_versions_with_contract_overlap_with_period(self, date_from, date_to):
            // """
            // Returns the versions of the employee between date_from and date_to
            // that have at least 1 day in contract during that period
            // """
            // return self.version_ids.filtered_domain([
            //     ('contract_date_start', '!=', False), ('contract_date_start', '<=', date_to),
            //     '|', ('contract_date_end', '>=', date_from), ('contract_date_end', '=', False),
            // ])
            */
            return default;
        }

        public async Task<TEntity> GetViewAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> GetViewsAsync<TEntity>(IEnumerable<TEntity> entities, object views, object options) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_views(self, views, options=None):
            //         if self.browse().has_access('read'):
            //             return super().get_views(views, options)
            //         # returning public employee data would cause a traceback when building
            //         # the private employee xml view
            //         raise RedirectWarning(
            //             message=_(
            //             """You are not allowed to access "Employee" (hr.employee) records.
            // We can redirect you to the public employee list."""
            //             ),
            //             action=self.env.ref('hr.hr_employee_public_action').id,
            //             button_text=_("Employees profile"),
            //         )
            */
            return default;
        }

        public async Task<TEntity> GetYearSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _get_year_selection(self):
            // current_year = datetime.now().year
            // return [(str(i), i) for i in range(1970, current_year + 1)]
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py) ---
            // def _get_year_selection(self):
            // current_year = datetime.now().year
            // return [(str(i), i) for i in range(1970, current_year + 1)]
            */
            return default;
        }

        public async Task<TEntity> HandleFirstContactCreationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _handle_first_contact_creation(self):
            // """ On creation of first contact for a company (or root) that has no address, assume contact address
            // was meant to be company address """
            // parent = self.parent_id
            // address_fields = self._address_fields()
            // if (
            //     (parent.is_company or not parent.parent_id)
            //     and any(self[f] for f in address_fields)
            //     and not any(parent[f] for f in address_fields)
            //     and len(parent.child_ids) == 1
            // ):
            //     addr_vals = self._convert_fields_to_values(address_fields)
            //     parent._update_address(addr_vals)
            */
            return default;
        }

        public async Task<TEntity> HasFieldAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, object operation) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _has_field_access(self, field, operation):
            // # DISCLAIMER: Dirty hack to avoid having to create a bridge module to override only a
            // # groups on a field which is not prefetched (because not stored) but would crash anyway
            // # if we try to read them directly (very uncommon use case). Don't add your field on this
            // # list if you can specify the group on the field directly (as all the other fields).
            // return super()._has_field_access(field, operation) and (
            //     self.env.su
            //     or self.env.user.has_group("hr.group_hr_user")
            //     or field.name not in ('activity_calendar_event_id', 'rating_ids', 'website_message_ids', 'message_has_sms_error')
            // )
            */
            return default;
        }

        public async Task<TEntity> InverseWorkContactDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _inverse_work_contact_details(self):
            // employees_without_work_contact = self.env['hr.employee']
            // for employee in self:
            //     if not employee.work_contact_id:
            //         employees_without_work_contact += employee
            //     else:
            //         if len(employee.work_contact_id.employee_ids) <= 1:
            //             employee.work_contact_id.sudo().write({
            //                 'email': employee.work_email,
            //                 'phone': employee.work_phone,
            //             })
            // if employees_without_work_contact:
            //     employees_without_work_contact.sudo()._create_work_contacts()
            */
            return default;
        }

        public async Task<TEntity> IsInContractInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _is_in_contract(self, date):
            // return self._get_contract_dates(date) != (False, False)
            */
            return default;
        }

        public async Task<TEntity> LangGetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _lang_get(self):
            // return self.env['res.lang'].get_installed()
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_guest.py) ---
            // def _lang_get(self):
            // return self.env['res.lang'].get_installed()
            */
            return default;
        }

        public async Task<TEntity> LoadDemoDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _load_demo_data(self):
            // dep_rd = self.env.ref('hr.dep_rd', raise_if_not_found=False)
            // action_reload = {
            //     'type': 'ir.actions.client',
            //     'tag': 'reload',
            // }
            // if dep_rd:
            //     return action_reload
            // convert.convert_file(env=self.sudo().env, module='hr', filename='data/scenarios/hr_scenario.xml', idref=None, mode='init')
            // if 'resume_line_ids' in self:
            //     convert.convert_file(env=self.env, module='hr_skills', filename='data/scenarios/hr_skills_scenario.xml', idref=None, mode='init')
            // return action_reload
            */
            return default;
        }

        public async Task<TEntity> LoadFieldsFromModelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields_to_load) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _load_fields_from_model(self, fields_to_load):
            // '''
            // Copies the desired fields from the models to the vehicles
            // '''
            // model_values = dict()
            // for vehicle in self.filtered('model_id'):
            //     if vehicle.model_id.id in model_values:
            //         write_vals = model_values[vehicle.model_id.id]
            //     else:
            //         # Update only the desired fields from the model, only when the model has a truthy value.
            //         write_vals = \
            //             {
            //                 vehicle_field: vehicle.model_id[model_field] for model_field, vehicle_field in MODEL_FIELDS_TO_VEHICLE.items()
            //                 if vehicle_field in fields_to_load and vehicle.model_id[model_field]
            //             }
            //         model_values[vehicle.model_id.id] = write_vals
            //     vehicle.update(write_vals)
            */
            return default;
        }

        public async Task<TEntity> LoadRecordsCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _load_records_create(self, vals_list):
            // partners = super(ResPartner, self.with_context(_partners_skip_fields_sync=True))._load_records_create(vals_list)
            // 
            // # batch up first part of _fields_sync
            // # group partners by commercial_partner_id (if not self) and parent_id (if type == contact)
            // groups = collections.defaultdict(list)
            // for partner, vals in zip(partners, vals_list):
            //     cp_id = None
            //     if vals.get('parent_id') and partner.commercial_partner_id != partner:
            //         cp_id = partner.commercial_partner_id.id
            // 
            //     add_id = None
            //     if partner.parent_id and partner.type == 'contact':
            //         add_id = partner.parent_id.id
            //     groups[(cp_id, add_id)].append(partner.id)
            // 
            // for (cp_id, add_id), children in groups.items():
            //     # values from parents (commercial, regular) written to their common children
            //     to_write = {}
            //     # commercial fields from commercial partner
            //     if cp_id:
            //         to_write = self.browse(cp_id)._convert_fields_to_values(self._commercial_fields())
            //     # address fields from parent
            //     if add_id:
            //         parent = self.browse(add_id)
            //         for f in self._address_fields():
            //             v = parent[f]
            //             if v:
            //                 to_write[f] = v.id if isinstance(v, models.BaseModel) else v
            //     if to_write:
            //         self.sudo().browse(children).write(to_write)
            // 
            // # do the second half of _fields_sync the "normal" way
            // for partner, vals in zip(partners, vals_list):
            //     partner._children_sync(vals)
            //     partner._handle_first_contact_creation()
            // return partners
            */
            return default;
        }

        public async Task<TEntity> LoadScenarioInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _load_scenario(self):
            // demo_tag = self.env.ref('hr.employee_category_demo', raise_if_not_found=False)
            // if demo_tag:
            //     return
            // convert.convert_file(self.env, 'hr', 'data/scenarios/hr_scenario.xml', None, mode='init')
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnerFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _mail_get_partner_fields(self, introspect_fields=False):
            // return ['work_contact_id', 'user_partner_id']
            */
            return default;
        }

        public async Task<TEntity> NameCreateAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def name_create(self, name):
            // """ Override of orm's name_create method for partners. The purpose is
            //     to handle some basic formats to create partners using the
            //     name_create.
            //     If only an email address is received and that the regex cannot find
            //     a name, the name will have the email value.
            //     If 'force_email' key in context: must find the email address. """
            // default_type = self.env.context.get('default_type')
            // if default_type and default_type not in self._fields['type'].get_values(self.env):
            //     context = dict(self.env.context)
            //     context.pop('default_type')
            //     self = self.with_context(context)
            // name, email_normalized = tools.parse_contact_from_email(name)
            // if self.env.context.get('force_email') and not email_normalized:
            //     raise ValidationError(_("Couldn't create contact without email address!"))
            // 
            // create_values = {self._rec_name: name or email_normalized}
            // if email_normalized:  # keep default_email in context
            //     create_values['email'] = email_normalized
            // partner = self.create(create_values)
            // return partner.id, partner.display_name
            */
            return default;
        }

        public async Task<TEntity> NewAsync<TEntity>(IEnumerable<TEntity> entities, object values, object origin, object @ref) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def new(self, values=None, origin=None, ref=None):
            // if not values:
            //     values = {}
            // new_vals = values.copy()
            // version_vals = {val: new_vals.pop(val) for val in values if val in self._fields and self._fields[val].inherited}
            // 
            // employee = super().new(new_vals, origin, ref)
            // version_vals['employee_id'] = employee
            // self.env['hr.version'].new({
            //     f_name: value
            //     for f_name, value in version_vals.items()
            //     if self.env['hr.version']._has_field_access(self.env['hr.version']._fields[f_name], 'read')
            // })
            // return employee
            */
            return default;
        }

        public async Task<TEntity> NotifyExpiringContractWorkPermitAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def notify_expiring_contract_work_permit(self):
            // companies = self.env['res.company'].search([])
            // employees_contract_expiring = self.env['hr.employee']
            // employees_work_permit_expiring = self.env['hr.employee']
            // 
            // for company in companies:
            //     employees_contract_expiring += self.env['hr.employee'].search([
            //         ('company_id', '=', company.id),
            //         ('contract_date_start', '!=', False),
            //         ('contract_date_start', '<', fields.Date.today()),
            //         ('contract_date_end', '=', fields.Date.today() + relativedelta(days=company.contract_expiration_notice_period)),
            //     ])
            // 
            //     employees_work_permit_expiring += self.env['hr.employee'].search([
            //         ('company_id', '=', company.id),
            //         ('work_permit_expiration_date', '!=', False),
            //         ('work_permit_expiration_date', '=', fields.Date.today() + relativedelta(days=company.work_permit_expiration_notice_period)),
            //     ])
            // 
            // for employee in employees_contract_expiring:
            //     employee.with_context(mail_activity_quick_update=True).activity_schedule(
            //         'mail.mail_activity_data_todo', employee.contract_date_end,
            //         _("The contract of %s is about to expire.", employee.name),
            //         user_id=employee.hr_responsible_id.id or self.env.uid)
            // 
            // for employee in employees_work_permit_expiring:
            //     employee.with_context(mail_activity_quick_update=True).activity_schedule(
            //         'mail.mail_activity_data_todo', employee.work_permit_expiration_date,
            //         _("The work permit of %s is about to expire.", employee.name),
            //         user_id=employee.hr_responsible_id.id or self.env.uid)
            // 
            // return True
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _onchange_company_id(self):
            // if self._origin:
            //     return {'warning': {
            //         'title': _("Warning"),
            //         'message': _("To avoid multi company issues (losing the access to your previous contracts, leaves, ...), you should create another employee in the new company instead.")
            //     }}
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _onchange_company_id(self):
            // if self.parent_id:
            //     self.company_id = self.parent_id.company_id.id
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def onchange_company_type(self):
            // self.is_company = (self.company_type == 'company')
            */
            return default;
        }

        public async Task<TEntity> OnchangeContractDateStartInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _onchange_contract_date_start(self):
            // if not self.contract_date_start:
            //     self.contract_date_end = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeContractTemplateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _onchange_contract_template_id(self):
            // if self.contract_template_id:
            //     whitelist = self.env['hr.version']._get_whitelist_fields_from_template()
            //     for field in self.contract_template_id._fields:
            //         if field in whitelist and not self.env['hr.version']._fields[field].related:
            //             self[field] = self.contract_template_id[field]
            */
            return default;
        }

        public async Task<TEntity> OnchangeCountryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _onchange_country_id(self):
            // if self.country_id and self.country_id != self.state_id.country_id:
            //     self.state_id = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeParentIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def onchange_parent_id(self):
            // # return values in result, as this method is used by _fields_sync()
            // if not self.parent_id:
            //     return
            // result = {}
            // partner = self._origin
            // if (partner.type or self.type) == 'contact':
            //     # for contacts: copy the parent address, if set (aka, at least one
            //     # value is set in the address: otherwise, keep the one from the
            //     # contact)
            //     if address_values := self.parent_id._get_address_values():
            //         result['value'] = address_values
            // return result
            */
            return default;
        }

        public async Task<TEntity> OnchangePhoneValidationEmployeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _onchange_phone_validation_employee(self):
            // if self.work_phone:
            //     self.work_phone = self._phone_format(number=self.work_phone, force_format='INTERNATIONAL') or self.work_phone
            // if self.mobile_phone:
            //     self.mobile_phone = self._phone_format(number=self.mobile_phone, force_format='INTERNATIONAL') or self.mobile_phone
            */
            return default;
        }

        public async Task<TEntity> OnchangePrivateStateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _onchange_private_state_id(self):
            // if self.private_state_id:
            //     self.private_country_id = self.private_state_id.country_id
            */
            return default;
        }

        public async Task<TEntity> OnchangeStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _onchange_state(self):
            // if self.state_id.country_id and self.country_id != self.state_id.country_id:
            //     self.country_id = self.state_id.country_id
            */
            return default;
        }

        public async Task<TEntity> OnchangeTimezoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _onchange_timezone(self):
            // if self.resource_calendar_id and not self.tz:
            //     self.tz = self.resource_calendar_id.tz
            */
            return default;
        }

        public async Task<TEntity> OnchangeUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> OpenAssignationLogsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def open_assignation_logs(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': 'Assignment Logs',
            //     'view_mode': 'list',
            //     'res_model': 'fleet.vehicle.assignation.log',
            //     'domain': [('vehicle_id', '=', self.id)],
            //     'context': {'default_driver_id': self.driver_id.id, 'default_vehicle_id': self.id}
            // }
            */
            return default;
        }

        public async Task<TEntity> OpenCommercialEntityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def open_commercial_entity(self):
            // """ Utility method used to add an "Open Company" button in partner views """
            // self.ensure_one()
            // return {'type': 'ir.actions.act_window',
            //         'res_model': 'res.partner',
            //         'view_mode': 'form',
            //         'res_id': self.commercial_partner_id.id,
            //         'target': 'current',
            //         }
            */
            return default;
        }

        public async Task<TEntity> PhoneGetNumberFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _phone_get_number_fields(self):
            // return ['mobile_phone']
            */
            return default;
        }

        public async Task<TEntity> PrepareCreateValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _prepare_create_values(self, vals_list):
            // result = super()._prepare_create_values(vals_list)
            // new_vals_list = []
            // Version = self.env['hr.version']
            // version_fields = [fname for fname, field in Version._fields.items() if Version._has_field_access(field, 'write')]
            // for vals in result:
            //     employee_vals = {}
            //     version_vals = {}
            //     for fname, value in vals.items():
            //         employee_field = self._fields.get(fname)
            //         if not (employee_field and employee_field.inherited and employee_field.related_field.model_name == 'hr.version'):
            //             employee_vals[fname] = value
            //         else:
            //             version_vals[fname] = value
            //     new_vals_list.append({
            //         **employee_vals,
            //         **{k: v for k, v in version_vals.items() if k in version_fields},
            //     })
            // return new_vals_list
            */
            return default;
        }

        public async Task<TEntity> PrepareDisplayAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object without_company) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _prepare_display_address(self, without_company=False):
            // # get the information that will be injected into the display format
            // # get the address format
            // address_format = self._get_address_format()
            // args = defaultdict(str, {
            //     'state_code': self.state_id.code or '',
            //     'state_name': self.state_id.name or '',
            //     'country_code': self.country_id.code or '',
            //     'country_name': self._get_country_name(),
            //     'company_name': self.commercial_company_name or '',
            // })
            // for field in self._formatting_address_fields():
            //     args[field] = self[field] or ''
            // if without_company:
            //     args['company_name'] = ''
            // elif self.commercial_company_name:
            //     address_format = '%(company_name)s\n' + address_format
            // return address_format, args
            */
            return default;
        }

        public async Task<TEntity> PrepareResourceValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object tz) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> RemoveWorkContactIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user, object employee_company) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> ReturnActionToOpenAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def return_action_to_open(self):
            // """ This opens the xml view specified in xml_id for the current vehicle """
            // self.ensure_one()
            // xml_id = self.env.context.get('xml_id')
            // if xml_id:
            // 
            //     res = self.env['ir.actions.act_window']._for_xml_id('fleet.%s' % xml_id)
            //     res.update(
            //         context=dict(self.env.context, default_vehicle_id=self.id, group_by=False),
            //         domain=[('vehicle_id', '=', self.id)]
            //     )
            //     return res
            // return False
            */
            return default;
        }

        public async Task<TEntity> SearchContractRenewalDueSoonInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _search_contract_renewal_due_soon(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // params = self.env['ir.config_parameter'].sudo()
            // delay_alert_contract = int(params.get_param('hr_fleet.delay_alert_contract', default=30))
            // today = fields.Date.context_today(self)
            // datetime_today = fields.Datetime.from_string(today)
            // limit_date = fields.Datetime.to_string(datetime_today + relativedelta(days=+delay_alert_contract))
            // return [('log_contracts', 'any', [
            //     ('expiration_date', '>', today),
            //     ('expiration_date', '<', limit_date),
            //     ('state', 'in', ['open', 'expired']),
            // ])]
            */
            return default;
        }

        public async Task<TEntity> SearchDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py) ---
            // def _search_display_name(self, operator, value):
            // if operator in Domain.NEGATIVE_OPERATORS:
            //     return NotImplemented
            // return ['|', ('name', operator, value), ('brand_id.name', operator, value)]
            */
            return default;
        }

        public async Task<TEntity> SearchFetchAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object field_names, object offset, object limit, object order) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def search_fetch(self, domain, field_names=None, offset=0, limit=None, order=None):
            // if self.browse().has_access('read'):
            //     return super().search_fetch(domain, field_names, offset, limit, order)
            // 
            // # HACK: retrieve publicly available values from hr.employee.public and
            // # copy them to the cache of self; non-public data will be missing from
            // # cache, and interpreted as an access error
            // if field_names is None:
            //     field_names = [field.name for field in self._determine_fields_to_fetch()]
            // field_names = [f_name for f_name in field_names if f_name != 'current_version_id']
            // self._check_private_fields(field_names)
            // self.flush_model(field_names)
            // public = self.env['hr.employee.public'].search_fetch(domain, field_names, offset, limit, order)
            // employees = self.browse(public._ids)
            // employees._copy_cache_from(public, field_names)
            // return employees
            */
            return default;
        }

        public async Task<TEntity> SearchGetOverdueContractReminderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _search_get_overdue_contract_reminder(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // today = fields.Date.context_today(self)
            // # get the id of vehicles that have overdue contracts
            // # but exclude those for which a new contract has already been created for them
            // return [
            //     ("log_contracts", "any", [
            //         ('expiration_date', '!=', False),
            //         ('expiration_date', '<', today),
            //         ('state', 'in', ['open', 'expired'])
            //     ]),
            //     "!",
            //         ("log_contracts", "any", [
            //             ('expiration_date', '!=', False),
            //             ('expiration_date', '>=', today),
            //             ('state', 'in', ['open', 'futur'])
            //         ]),
            // ]
            */
            return default;
        }

        public async Task<TEntity> SearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object offset, object limit, object order) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _search(self, domain, offset=0, limit=None, order=None, *, bypass_access=False, **kwargs):
            // """
            //     We override the _search because it is the method that checks the access rights
            //     This is correct to override the _search. That way we enforce the fact that calling
            //     search on an hr.employee returns a hr.employee recordset, even if you don't have access
            //     to this model, as the result of _search (the ids of the public employees) is to be
            //     browsed on the hr.employee model. This can be trusted as the ids of the public
            //     employees exactly match the ids of the related hr.employee.
            // """
            // if self.browse().has_access('read') or bypass_access:
            //     return super()._search(domain, offset, limit, order, bypass_access=bypass_access, **kwargs)
            // domain = Domain(domain)
            // # HACK Some fields are inherited from the `current_version_id` and may have been already
            // # optimized, showing current_version_id in the domain, but public employee does not have
            // # that field and may have fields directly on the model, just change the condition to `id` in
            // # that case.
            // domain = domain.map_conditions(lambda cond: Domain('id', cond.operator, cond.value) if cond.field_expr == 'current_version_id' else cond)
            // try:
            //     ids = self.env['hr.employee.public']._search(domain, offset, limit, order, **kwargs)
            // except ValueError as e:
            //     raise AccessError(self.env._('You do not have access to this document.')) from e
            // # the result is expected from this table, so we should link tables
            // return super(HrEmployee, self.sudo())._search([('id', 'in', ids)], order=order)
            */
            return default;
        }

        public async Task<TEntity> SearchNewlyHiredInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _search_newly_hired(self, operator, value):
            // if operator not in ('in', 'not in'):
            //     return NotImplemented
            // new_hire_field = self._get_new_hire_field()
            // new_hires = self.env['hr.employee'].sudo().search([
            //     (new_hire_field, '>', fields.Datetime.now() - timedelta(days=90))
            // ])
            // return [('id', operator, new_hires.ids)]
            */
            return default;
        }

        public async Task<TEntity> SearchVehicleCountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py) ---
            // def _search_vehicle_count(self, operator, value):
            // fleet_models = self.env['fleet.vehicle.model'].search_fetch([], ['vehicle_count'])
            // fleet_models = fleet_models.filtered_domain([('vehicle_count', operator, value)])
            // return [('id', 'in', fleet_models.ids)]
            */
            return default;
        }

        public async Task<TEntity> SearchVersionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _search_version_id(self, operator, value):
            // if operator in ('any', 'any!'):
            //     return Domain('current_version_id', operator, value)
            // domain = Domain('id', operator, value)
            // return Domain('id', 'in', self.env['hr.version']._search(domain).select('employee_id'))
            */
            return default;
        }

        public async Task<TEntity> SetAuthCookieInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_guest.py) ---
            // def _set_auth_cookie(self):
            // """Add a cookie to the response to identify the guest. Every route
            // that expects a guest will make use of it to authenticate the guest
            // through `add_guest_to_context`.
            // """
            // self.ensure_one()
            // expiration_date = datetime.now() + timedelta(days=365)
            // request.future_response.set_cookie(
            //     self._cookie_name,
            //     self._format_auth_cookie(),
            //     httponly=True,
            //     expires=expiration_date,
            // )
            // request.update_context(guest=self.sudo(False))
            */
            return default;
        }

        public async Task<TEntity> SetOdometerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _set_odometer(self):
            // self.env['fleet.vehicle.odometer'].create([
            //     {
            //         'value': vehicle.odometer,
            //         'date': fields.Date.context_today(vehicle),
            //         'vehicle_id': vehicle.id,
            //         'driver_id': vehicle.driver_id.id
            //     } for vehicle in self if vehicle.odometer
            // ])
            */
            return default;
        }

        public async Task<TEntity> SyncSalaryDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _sync_salary_distribution(self):
            // for employee in self:
            //     current_salary_distribution = employee.salary_distribution or {}
            //     current_ids = set(map(int, current_salary_distribution.keys()))
            //     account_ids = set(employee.bank_account_ids.ids)
            // 
            //     added_ids = account_ids - current_ids
            //     removed_ids = current_ids - account_ids
            //     unchanged_ids = account_ids & current_ids
            // 
            //     # Preserve existing data and order
            //     ordered = sorted([
            //         (int(i), data) for i, data in current_salary_distribution.items()
            //         if int(i) in unchanged_ids
            //     ], key=lambda x: (not x[1].get('amount_is_percentage'), x[1].get('sequence', float('inf'))))
            // 
            //     new_salary_distribution = {str(i): data for i, data in ordered}
            // 
            //     # Redistribute removed % to first item
            //     removed_percentage = sum(current_salary_distribution[str(i)]['amount']
            //         for i in removed_ids if str(i) in current_salary_distribution and current_salary_distribution[str(i)]['amount_is_percentage'])
            //     if removed_percentage and ordered:
            //         first_id = str(ordered[0][0])
            //         if new_salary_distribution[first_id]['amount_is_percentage']:
            //             new_salary_distribution[first_id]['amount'] += removed_percentage
            // 
            //     # Add new entries with remaining %
            //     total_allocated = sum(d['amount'] for d in new_salary_distribution.values() if d['amount_is_percentage'])
            //     remaining = max(0.0, 100.0 - total_allocated)
            //     seq = max((d.get('sequence', 0) for d in new_salary_distribution.values()), default=0)
            //     amount = employee.currency_id.round(remaining / len(added_ids)) if added_ids else 0.0
            //     for i, new_id in enumerate(added_ids):
            //         seq += 1
            //         if i == len(added_ids) - 1:
            //             amount = remaining
            //         new_salary_distribution[str(new_id)] = {
            //             'amount': amount,
            //             'amount_is_percentage': True,
            //             'sequence': seq,
            //         }
            //         remaining -= amount
            // 
            //     employee.salary_distribution = new_salary_distribution
            */
            return default;
        }

        public async Task<TEntity> SyncUserInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user, object employee_has_image) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> SyncedCommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _synced_commercial_fields(self):
            // """ Returns the list of fields that are managed by the commercial entity
            // to which a partner belongs. When modified on a children, update is
            // propagated until the commercial entity. """
            // return ['vat']
            */
            return default;
        }

        public async Task<TEntity> ToStoreDefaultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_guest.py) ---
            // def _to_store_defaults(self, target):
            // return ["avatar_128", "im_status", "name"]
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // if 'driver_id' in init_values or 'future_driver_id' in init_values:
            //     return self.env.ref('fleet.mt_fleet_driver_updated')
            // return super(FleetVehicle, self)._track_subtype(init_values)
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def unlink(self):
            // resources = self.mapped('resource_id')
            // super().unlink()
            // return resources.unlink()
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _unlink_except_user(self):
            // users = self.env['res.users'].sudo().search([('partner_id', 'in', self.ids)])
            // if not users:
            //     return  # no linked user, operation is allowed
            // if self.env['res.users'].sudo(False).has_access('write'):
            //     error_msg = _('You cannot delete contacts linked to an active user.\n'
            //                   'You should rather archive them after archiving their associated user.\n\n'
            //                   'Linked active users : %(names)s', names=", ".join([u.display_name for u in users]))
            //     action_error = users._action_show()
            //     raise RedirectWarning(error_msg, action_error, _('Go to users'))
            // else:
            //     raise ValidationError(_('You cannot delete contacts linked to an active user.\n'
            //                             'Ask an administrator to archive their associated user first.\n\n'
            //                             'Linked active users :\n%(names)s', names=", ".join([u.display_name for u in users])))
            */
            return default;
        }

        public async Task<TEntity> UpdateAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _update_address(self, vals):
            // """ Filter values from vals that are liked to address definition, and
            // update recordset using super().write to avoid loops and side effects
            // due to synchronization of address fields through partner hierarchy. """
            // addr_vals = {key: vals[key] for key in self._address_fields() if key in vals}
            // if addr_vals:
            //     super().write(addr_vals)
            */
            return default;
        }

        public async Task<TEntity> UpdateNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_guest.py) ---
            // def _update_name(self, name):
            // self.ensure_one()
            // name = name.strip()
            // if len(name) < 1:
            //     raise UserError(_("Guest's name cannot be empty."))
            // if len(name) > 512:
            //     raise UserError(_("Guest's name is too long."))
            // self.name = name
            // for channel in self.channel_ids:
            //     Store(bus_channel=channel).add(self, ["avatar_128", "name"]).bus_send()
            // Store(bus_channel=self).add(self, ["avatar_128", "name"]).bus_send()
            */
            return default;
        }

        public async Task<TEntity> UpdateTimezoneInternalAsync<TEntity>(IEnumerable<TEntity> entities, object timezone) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_guest.py) ---
            // def _update_timezone(self, timezone):
            // query = """
            //     UPDATE mail_guest
            //     SET timezone = %s
            //     WHERE id IN (
            //         SELECT id FROM mail_guest WHERE id = %s
            //         FOR NO KEY UPDATE SKIP LOCKED
            //     )
            // """
            // self.env.cr.execute(query, (timezone, self.id))
            */
            return default;
        }

        public async Task<TEntity> VerifyBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> VerifyPinInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> ViewHeaderGetAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def view_header_get(self, view_id, view_type):
            // if self.env.context.get('category_id'):
            //     return  _(
            //         'Partners: %(category)s',
            //         category=self.env['res.partner.category'].browse(self.env.context['category_id']).name,
            //     )
            // return super().view_header_get(view_id, view_type)
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def write(self, vals):
            // if 'odometer' in vals and any(vehicle.odometer > vals['odometer'] for vehicle in self):
            //     raise UserError(_('The odometer value cannot be lower than the previous one.'))
            // 
            // if 'driver_id' in vals and vals['driver_id']:
            //     driver_id = vals['driver_id']
            //     for vehicle in self.filtered(lambda v: v.driver_id.id != driver_id):
            //         vehicle.create_driver_history(vals)
            //         if vehicle.driver_id:
            //             vehicle.activity_schedule(
            //                 'mail.mail_activity_data_todo',
            //                 user_id=vehicle.manager_id.id or self.env.user.id,
            //                 note=_('Specify the End date of %s', vehicle.driver_id.name))
            // 
            // if 'future_driver_id' in vals and vals['future_driver_id']:
            //     future_driver = vals['future_driver_id']
            //     state_waiting_list = self.env.ref('fleet.fleet_vehicle_state_waiting_list', raise_if_not_found=False)
            //     state_new_request = self.env.ref('fleet.fleet_vehicle_state_new_request', raise_if_not_found=False)
            //     vehicle_types = set(self.filtered(lambda vehicle: not state_waiting_list or\
            //                         vals.get('state_id', vehicle.state_id.id) not in [state_waiting_list.id, state_new_request.id]).mapped('vehicle_type'))
            //     if vehicle_types:
            //         vehicle_read_group = dict(self.env['fleet.vehicle']._read_group(
            //             domain=[('driver_id', '=', future_driver), ('vehicle_type', 'in', vehicle_types), ('id', 'not in', self.ids)],
            //             groupby=['vehicle_type'],
            //             aggregates=['id:recordset'])
            //         )
            //         if 'bike' in vehicle_read_group:
            //             vehicle_read_group['bike'].write({'plan_to_change_bike': True})
            //         if 'car' in vehicle_read_group:
            //             vehicle_read_group['car'].write({'plan_to_change_car': True})
            // 
            // if 'active' in vals and not vals['active']:
            //     self.env['fleet.vehicle.log.contract'].search([('vehicle_id', 'in', self.ids)]).active = False
            //     self.env['fleet.vehicle.log.services'].search([('vehicle_id', 'in', self.ids)]).active = False
            // 
            // res = super(FleetVehicle, self).write(vals)
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def write(self, vals):
            // if 'work_contact_id' in vals:
            //     self.message_unsubscribe(self.work_contact_id.ids)
            // if 'user_id' in vals:
            //     # Update the profile pictures with user, except if provided
            //     user = self.env['res.users'].browse(vals['user_id'])
            //     vals.update(self._sync_user(user, (bool(all(emp.image_1920 for emp in self)))))
            //     self._remove_work_contact_id(user, vals.get('company_id'))
            // if 'work_permit_expiration_date' in vals:
            //     vals['work_permit_scheduled_activity'] = False
            // if vals.get('tz'):
            //     users_to_update = self.env['res.users']
            //     for employee in self:
            //         if employee.user_id and employee.company_id == employee.user_id.company_id and vals['tz'] != employee.user_id.tz:
            //             users_to_update |= employee.user_id
            //     if users_to_update:
            //         users_to_update.write({'tz': vals['tz']})
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
            // # Only one write call for all the fields from hr.version
            // new_vals = vals.copy()
            // version_vals = {val: new_vals.pop(val) for val in vals if val in self._fields and self._fields[val].inherited}
            // res = super().write(new_vals)
            // if 'work_contact_id' in vals:
            //     account_ids = self.bank_account_ids.ids
            //     if account_ids:
            //         bank_accounts = self.env['res.partner.bank'].sudo().browse(account_ids)
            //         for bank_account in bank_accounts:
            //             if vals['work_contact_id'] != bank_account.partner_id.id:
            //                 if bank_account.allow_out_payment:
            //                     bank_account.allow_out_payment = False
            //                 if vals['work_contact_id']:
            //                     bank_account.partner_id = vals['work_contact_id']
            // if version_vals:
            //     version_vals['last_modified_date'] = fields.Datetime.now()
            //     version_vals['last_modified_uid'] = self.env.uid
            //     self.version_id.write(version_vals)
            // 
            //     for employee in self:
            //         employee._track_set_log_message(Markup("<b>Modified on the Version '%s'</b>") % employee.version_id.display_name)
            // if res and 'resource_calendar_id' in vals:
            //     resources_per_calendar_id = defaultdict(lambda: self.env['resource.resource'])
            //     for employee in self:
            //         if employee.version_id == employee.current_version_id:
            //             resources_per_calendar_id[employee.resource_calendar_id.id] += employee.resource_id
            //     for calendar_id, resources in resources_per_calendar_id.items():
            //         resources.write({'calendar_id': calendar_id})
            // return res
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def write(self, vals):
            // if vals.get('active') is False:
            //     # DLE: It should not be necessary to modify this to make work the ORM. The problem was just the recompute
            //     # of partner.user_ids when you create a new user for this partner, see test test_70_archive_internal_partners
            //     # You modified it in a previous commit, see original commit of this:
            //     # https://github.com/odoo/odoo/commit/9d7226371730e73c296bcc68eb1f856f82b0b4ed
            //     #
            //     # RCO: when creating a user for partner, the user is automatically added in partner.user_ids.
            //     # This is wrong if the user is not active, as partner.user_ids only returns active users.
            //     # Hence this temporary hack until the ORM updates inverse fields correctly.
            //     self.invalidate_recordset(['user_ids'])
            //     users = self.env['res.users'].sudo().search([('partner_id', 'in', self.ids)])
            //     if users:
            //         if self.env['res.users'].sudo(False).has_access('write'):
            //             error_msg = _('You cannot archive contacts linked to an active user.\n'
            //                           'You first need to archive their associated user.\n\n'
            //                           'Linked active users : %(names)s', names=", ".join([u.display_name for u in users]))
            //             action_error = users._action_show()
            //             raise RedirectWarning(error_msg, action_error, _('Go to users'))
            //         else:
            //             raise ValidationError(_('You cannot archive contacts linked to an active user.\n'
            //                                     'Ask an administrator to archive their associated user first.\n\n'
            //                                     'Linked active users :\n%(names)s', names=", ".join([u.display_name for u in users])))
            // if vals.get('website'):
            //     vals['website'] = self._clean_website(vals['website'])
            // if vals.get('parent_id'):
            //     vals['company_name'] = False
            // if vals.get('name'):
            //     for partner in self:
            //         for bank in partner.bank_ids:
            //             if bank.acc_holder_name == partner.name:
            //                 bank.acc_holder_name = vals['name']
            // 
            // # filter to keep only really updated values -> field synchronize goes through
            // # partner tree and we should avoid infinite loops in case same value is
            // # updated due to cycles. Use case: updating a property field, which updated
            // # a computed field, which has an inverse writing the same value on property
            // # field. Yay.
            // pre_values_list = [{fname: partner[fname] for fname in vals} for partner in self]
            // 
            // # res.partner must only allow to set the company_id of a partner if it
            // # is the same as the company of all users that inherit from this partner
            // # (this is to allow the code from res_users to write to the partner!) or
            // # if setting the company_id to False (this is compatible with any user
            // # company)
            // if 'company_id' in vals:
            //     company_id = vals['company_id']
            //     for partner in self:
            //         if company_id and partner.user_ids:
            //             company = self.env['res.company'].browse(company_id)
            //             companies = set(user.company_id for user in partner.user_ids)
            //             if len(companies) > 1 or company not in companies:
            //                 raise UserError(
            //                     self.env._("The selected company is not compatible with the companies of the related user(s)"))
            //         if partner.child_ids:
            //             partner.child_ids.write({'company_id': company_id})
            // result = True
            // # To write in SUPERUSER on field is_company and avoid access rights problems.
            // if 'is_company' in vals and not self.env.su and self.env.user.has_group('base.group_partner_manager'):
            //     result = super(ResPartner, self.sudo()).write({'is_company': vals.get('is_company')})
            //     del vals['is_company']
            // result = result and super().write(vals)
            // for partner, pre_values in zip(self, pre_values_list, strict=True):
            //     if internal_users := partner.user_ids.filtered(lambda u: u._is_internal() and u != self.env.user):
            //         internal_users.check_access('write')
            //     updated = {fname: fvalue for fname, fvalue in vals.items() if partner[fname] != pre_values[fname]}
            //     if updated:
            //         partner._fields_sync(updated)
            // return result
            */
            return default;
        }

        public async Task<TEntity> WriteCompanyTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _write_company_type(self):
            // for partner in self:
            //     partner.is_company = partner.company_type == 'company'
            */
            return default;
        }
    }
}