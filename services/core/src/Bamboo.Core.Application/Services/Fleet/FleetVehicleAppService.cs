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
    [Module("Fleet", Depends = new[] { "base", "mail" })]
    public class FleetVehicleAppService : GenericApplicationService<FleetVehicle>, IFleetVehicleAppService
    {
        private readonly IAvatarMixinAppService _avatarMixinAppService;
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        public FleetVehicleAppService(IRepository<FleetVehicle, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IAvatarMixinAppService avatarMixinAppService, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _avatarMixinAppService = avatarMixinAppService;
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<FleetVehicle> AcceptDriverChangeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def action_accept_driver_change(self):
            // # Find all the vehicles of the same type for which the driver is the future_driver_id
            // # remove their driver_id and close their history using current date
            // vehicles = self.search([('driver_id', 'in', self.mapped('future_driver_id').ids), ('vehicle_type', '=', self.vehicle_type)])
            // vehicles.write({'driver_id': False})
            // 
            // for vehicle in self:
            //     if vehicle.vehicle_type == 'bike':
            //         vehicle.future_driver_id.sudo().write({'plan_to_change_bike': False})
            //     if vehicle.vehicle_type == 'car':
            //         vehicle.future_driver_id.sudo().write({'plan_to_change_car': False})
            //     vehicle.driver_id = vehicle.future_driver_id
            //     vehicle.future_driver_id = False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<FleetVehicle> ActShowLogCostAsync(Guid id)
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
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<FleetVehicle> CleanValsInternalUserInternalAsync(object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _clean_vals_internal_user(self, vals):
            // # Fleet administrator may not have rights to write on partner
            // # related fields when the driver_id is a res.user.
            // # This trick is used to prevent access right error.
            // su_vals = {}
            // if self.env.su:
            //     return su_vals
            // if 'plan_to_change_car' in vals:
            //     su_vals['plan_to_change_car'] = vals.pop('plan_to_change_car')
            // if 'plan_to_change_bike' in vals:
            //     su_vals['plan_to_change_bike'] = vals.pop('plan_to_change_bike')
            // return su_vals
            */
            return default;
        }

        protected async Task<FleetVehicle> ComputeContractReminderInternalAsync()
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

        protected async Task<FleetVehicle> ComputeCountAllInternalAsync()
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

        protected async Task<FleetVehicle> ComputeDriverEmployeeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_fleet, FILE: fleet_vehicle.py) ---
            // def _compute_driver_employee_id(self):
            // for vehicle in self:
            //     if vehicle.driver_id:
            //         vehicle.driver_employee_id = self.env['hr.employee'].search([
            //             *self.env['hr.employee']._check_company_domain(self.env.companies),
            //             ('work_contact_id', '=', vehicle.driver_id.id),
            //         ], limit=1)
            //     else:
            //         vehicle.driver_employee_id = False
            */
            return default;
        }

        protected async Task<FleetVehicle> ComputeFutureDriverEmployeeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_fleet, FILE: fleet_vehicle.py) ---
            // def _compute_future_driver_employee_id(self):
            // for vehicle in self:
            //     if vehicle.future_driver_id:
            //         vehicle.future_driver_employee_id = self.env['hr.employee'].search([
            //             *self.env['hr.employee']._check_company_domain(self.env.companies),
            //             ('work_contact_id', '=', vehicle.future_driver_id.id),
            //         ], limit=1)
            //     else:
            //         vehicle.future_driver_employee_id = False
            */
            return default;
        }

        protected async Task<FleetVehicle> ComputeMobilityCardInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_fleet, FILE: fleet_vehicle.py) ---
            // def _compute_mobility_card(self):
            // for vehicle in self:
            //     employee = self.env['hr.employee']
            //     if vehicle.driver_id:
            //         employee = employee.search([('work_contact_id', '=', vehicle.driver_id.id)], limit=1)
            //         if not employee:
            //             employee = employee.search([('user_id.partner_id', '=', vehicle.driver_id.id)], limit=1)
            //     vehicle.mobility_card = employee.mobility_card
            */
            return default;
        }

        protected async Task<FleetVehicle> ComputeModelFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_model_fields(self):
            // '''
            // Copies all the related fields from the model to the vehicle
            // '''
            // model_values = dict()
            // for vehicle in self.filtered('model_id'):
            //     if vehicle.model_id.id in model_values:
            //         write_vals = model_values[vehicle.model_id.id]
            //     else:
            //         # copy if value is truthy
            //         write_vals = {MODEL_FIELDS_TO_VEHICLE[key]: vehicle.model_id[key] for key in MODEL_FIELDS_TO_VEHICLE\
            //             if vehicle.model_id[key]}
            //         model_values[vehicle.model_id.id] = write_vals
            //     vehicle.update(write_vals)
            */
            return default;
        }

        protected async Task<FleetVehicle> ComputeMoveIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_fleet, FILE: fleet_vehicle.py) ---
            // def _compute_move_ids(self):
            // if not self.env.user.has_group('account.group_account_readonly'):
            //     self.account_move_ids = False
            //     self.bill_count = 0
            //     return
            // 
            // moves = self.env['account.move.line']._read_group(
            //     domain=[
            //         ('vehicle_id', 'in', self.ids),
            //         ('parent_state', '!=', 'cancel'),
            //         ('move_id.move_type', 'in', self.env['account.move'].get_purchase_types())
            //     ],
            //     groupby=['vehicle_id'],
            //     aggregates=['move_id:array_agg'],
            // )
            // vehicle_move_mapping = {vehicle.id: set(move_ids) for vehicle, move_ids in moves}
            // for vehicle in self:
            //     vehicle.account_move_ids = [Command.set(vehicle_move_mapping.get(vehicle.id, []))]
            //     vehicle.bill_count = len(vehicle.account_move_ids)
            */
            return default;
        }

        protected async Task<FleetVehicle> ComputeServiceActivityInternalAsync()
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

        protected async Task<FleetVehicle> ComputeVehicleNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_vehicle_name(self):
            // for record in self:
            //     record.name = (record.model_id.brand_id.name or '') + '/' + (record.model_id.name or '') + '/' + (record.license_plate or _('No Plate'))
            */
            return default;
        }

        public override async Task<FleetVehicle> CreateAsync(FleetVehicle entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def create(self, vals_list):
            // ptc_values = [self._clean_vals_internal_user(vals) for vals in vals_list]
            // vehicles = super().create(vals_list)
            // for vehicle, vals, ptc_value in zip(vehicles, vals_list, ptc_values):
            //     if ptc_value:
            //         vehicle.sudo().write(ptc_value)
            //     if 'driver_id' in vals and vals['driver_id']:
            //         vehicle.create_driver_history(vals)
            //     if 'future_driver_id' in vals and vals['future_driver_id']:
            //         state_waiting_list = self.env.ref('fleet.fleet_vehicle_state_waiting_list', raise_if_not_found=False)
            //         states = vehicle.mapped('state_id').ids
            //         if not state_waiting_list or state_waiting_list.id not in states:
            //             future_driver = self.env['res.partner'].browse(vals['future_driver_id'])
            //             if self.vehicle_type == 'bike':
            //                 future_driver.sudo().write({'plan_to_change_bike': True})
            //             if self.vehicle_type == 'car':
            //                 future_driver.sudo().write({'plan_to_change_car': True})
            // return vehicles
            --- ODOO METHOD SOURCE (MODULE: hr_fleet, FILE: fleet_vehicle.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     self._update_create_write_vals(vals)
            // return super().create(vals_list)
            */
            return await base.CreateAsync(entity, fields);
        }

        public async Task<FleetVehicle> CreateDriverHistoryAsync(Guid id, FleetVehicleCreateDriverHistoryRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def create_driver_history(self, vals):
            // for vehicle in self:
            //     self.env['fleet.vehicle.assignation.log'].create(
            //         vehicle._get_driver_history_data(vals),
            //     )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<FleetVehicle> GetAnalyticNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _get_analytic_name(self):
            // # This function is used in fleet_account and is overrided in l10n_be_hr_payroll_fleet
            // return self.license_plate or _('No plate')
            */
            return default;
        }

        protected async Task<FleetVehicle> GetDefaultStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _get_default_state(self):
            // state = self.env.ref('fleet.fleet_vehicle_state_new_request', raise_if_not_found=False)
            // return state if state and state.id else False
            */
            return default;
        }

        protected async Task<FleetVehicle> GetDriverHistoryDataInternalAsync(object vals)
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

        protected async Task<FleetVehicle> GetOdometerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _get_odometer(self):
            // FleetVehicalOdometer = self.env['fleet.vehicle.odometer']
            // for record in self:
            //     vehicle_odometer = FleetVehicalOdometer.search([('vehicle_id', '=', record.id)], limit=1, order='value desc')
            //     if vehicle_odometer:
            //         record.odometer = vehicle_odometer.value
            //     else:
            //         record.odometer = 0
            */
            return default;
        }

        public async Task<FleetVehicle> OpenAssignationLogsAsync(Guid id)
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
            --- ODOO METHOD SOURCE (MODULE: hr_fleet, FILE: fleet_vehicle.py) ---
            // def open_assignation_logs(self):
            // action = super().open_assignation_logs()
            // action['views'] = [[self.env.ref('hr_fleet.fleet_vehicle_assignation_log_view_list').id, 'list']]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<FleetVehicle> OpenEmployeeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_fleet, FILE: fleet_vehicle.py) ---
            // def action_open_employee(self):
            // self.ensure_one()
            // return {
            //     'name': _('Related Employee'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'hr.employee',
            //     'view_mode': 'form',
            //     'res_id': self.driver_employee_id.id,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<FleetVehicle> ReturnToOpenAsync(Guid id)
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
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<FleetVehicle> SearchContractRenewalDueSoonInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _search_contract_renewal_due_soon(self, operator, value):
            // params = self.env['ir.config_parameter'].sudo()
            // delay_alert_contract = int(params.get_param('hr_fleet.delay_alert_contract', default=30))
            // res = []
            // assert operator in ('=', '!=', '<>') and value in (True, False), 'Operation not supported'
            // if (operator == '=' and value is True) or (operator in ('<>', '!=') and value is False):
            //     search_operator = 'in'
            // else:
            //     search_operator = 'not in'
            // today = fields.Date.context_today(self)
            // datetime_today = fields.Datetime.from_string(today)
            // limit_date = fields.Datetime.to_string(datetime_today + relativedelta(days=+delay_alert_contract))
            // res_ids = self.env['fleet.vehicle.log.contract'].search([
            //     ('expiration_date', '>', today),
            //     ('expiration_date', '<', limit_date),
            //     ('state', 'in', ['open', 'expired'])
            // ]).mapped('vehicle_id').ids
            // res.append(('id', search_operator, res_ids))
            // return res
            */
            return default;
        }

        protected async Task<FleetVehicle> SearchGetOverdueContractReminderInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _search_get_overdue_contract_reminder(self, operator, value):
            // res = []
            // assert operator in ('=', '!=', '<>') and value in (True, False), 'Operation not supported'
            // if (operator == '=' and value is True) or (operator in ('<>', '!=') and value is False):
            //     search_operator = 'in'
            // else:
            //     search_operator = 'not in'
            // today = fields.Date.context_today(self)
            // # get the id of vehicles that have overdue contracts
            // # but exclude those for which a new contract has already been created for them
            // vehicle_ids = self.env['fleet.vehicle']._search([
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
            // ])
            // res.append(('id', search_operator, vehicle_ids))
            // return res
            */
            return default;
        }

        public async Task<FleetVehicle> SendEmailAsync(Guid id)
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
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<FleetVehicle> SetOdometerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _set_odometer(self):
            // for record in self:
            //     if record.odometer:
            //         date = fields.Date.context_today(record)
            //         data = {'value': record.odometer, 'date': date, 'vehicle_id': record.id}
            //         self.env['fleet.vehicle.odometer'].create(data)
            */
            return default;
        }

        protected async Task<FleetVehicle> TrackSubtypeInternalAsync(object init_values)
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

        protected async Task<FleetVehicle> UpdateCreateWriteValsInternalAsync(object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_fleet, FILE: fleet_vehicle.py) ---
            // def _update_create_write_vals(self, vals):
            // if 'driver_employee_id' in vals:
            //     partner = False
            //     if vals['driver_employee_id']:
            //         employee = self.env['hr.employee'].sudo().browse(vals['driver_employee_id'])
            //         partner = employee.work_contact_id.id
            //     vals['driver_id'] = partner
            // elif 'driver_id' in vals:
            //     # Reverse the process if we can find a single employee
            //     employee = False
            //     if vals['driver_id']:
            //         # Limit to 2, we only care about the first one if he is the only one
            //         employee_ids = self.env['hr.employee'].sudo().search([
            //             ('work_contact_id', '=', vals['driver_id'])
            //         ], limit=2)
            //         if len(employee_ids) == 1:
            //             employee = employee_ids[0].id
            //     vals['driver_employee_id'] = employee
            // 
            // # Same for future driver
            // if 'future_driver_employee_id' in vals:
            //     partner = False
            //     if vals['future_driver_employee_id']:
            //         employee = self.env['hr.employee'].sudo().browse(vals['future_driver_employee_id'])
            //         partner = employee.work_contact_id.id
            //     vals['future_driver_id'] = partner
            // elif 'future_driver_id' in vals:
            //     # Reverse the process if we can find a single employee
            //     employee = False
            //     if vals['future_driver_id']:
            //         # Limit to 2, we only care about the first one if he is the only one
            //         employee_ids = self.env['hr.employee'].sudo().search([
            //             ('work_contact_id', '=', vals['future_driver_id'])
            //         ], limit=2)
            //         if len(employee_ids) == 1:
            //             employee = employee_ids[0].id
            //     vals['future_driver_employee_id'] = employee
            */
            return default;
        }

        public async Task<FleetVehicle> ViewBillsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_fleet, FILE: fleet_vehicle.py) ---
            // def action_view_bills(self):
            // self.ensure_one()
            // 
            // form_view_ref = self.env.ref('account.view_move_form', False)
            // list_view_ref = self.env.ref('account_fleet.account_move_view_tree', False)
            // 
            // result = self.env['ir.actions.act_window']._for_xml_id('account.action_move_in_invoice_type')
            // result.update({
            //     'domain': [('id', 'in', self.account_move_ids.ids)],
            //     'views': [(list_view_ref.id, 'list'), (form_view_ref.id, 'form')],
            // })
            // return result
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, FleetVehicle entity, List<string> fields)
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
            //     state_waiting_list = self.env.ref('fleet.fleet_vehicle_state_waiting_list', raise_if_not_found=False)
            //     states = self.mapped('state_id').ids if 'state_id' not in vals else [vals['state_id']]
            //     if not state_waiting_list or state_waiting_list.id not in states:
            //         future_driver = self.env['res.partner'].browse(vals['future_driver_id'])
            //         if self.vehicle_type == 'bike':
            //             future_driver.sudo().write({'plan_to_change_bike': True})
            //         if self.vehicle_type == 'car':
            //             future_driver.sudo().write({'plan_to_change_car': True})
            // 
            // if 'active' in vals and not vals['active']:
            //     self.env['fleet.vehicle.log.contract'].search([('vehicle_id', 'in', self.ids)]).active = False
            //     self.env['fleet.vehicle.log.services'].search([('vehicle_id', 'in', self.ids)]).active = False
            // 
            // su_vals = self._clean_vals_internal_user(vals)
            // if su_vals:
            //     self.sudo().write(su_vals)
            // res = super(FleetVehicle, self).write(vals)
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_fleet, FILE: fleet_vehicle.py) ---
            // def write(self, vals):
            // self._update_create_write_vals(vals)
            // if 'driver_employee_id' in vals:
            //     for vehicle in self:
            //         if vehicle.driver_employee_id and vehicle.driver_employee_id.id != vals['driver_employee_id']:
            //             partners_to_unsubscribe = vehicle.driver_id.ids
            //             employee = vehicle.driver_employee_id
            //             if employee and employee.user_id.partner_id:
            //                 partners_to_unsubscribe.append(employee.user_id.partner_id.id)
            //             vehicle.message_unsubscribe(partner_ids=partners_to_unsubscribe)
            // return super().write(vals)
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}