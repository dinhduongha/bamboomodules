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
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Fleet", Category = "HumanResources", Depends = new[] { "base", "mail" })]
    public partial class FleetVehicleAppService : GenericApplicationService<FleetVehicle>, IFleetVehicleAppService
    {
        private readonly IAvatarMixinAppService _avatarMixinAppService;
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        public FleetVehicleAppService(IRepository<FleetVehicle, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IAvatarMixinAppService avatarMixinAppService, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
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

        protected async Task<FleetVehicle> ComputeCategoryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_category(self):
            // self._load_fields_from_model(['category_id'])
            */
            return default;
        }

        protected async Task<FleetVehicle> ComputeCo2EmissionUnitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_co2_emission_unit(self):
            // for record in self:
            //     if record.range_unit == 'km':
            //         record.co2_emission_unit = 'g/km'
            //     else:
            //         record.co2_emission_unit = 'g/mi'
            */
            return default;
        }

        protected async Task<FleetVehicle> ComputeCo2InternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_co2(self):
            // self._load_fields_from_model(['co2'])
            */
            return default;
        }

        protected async Task<FleetVehicle> ComputeCo2StandardInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_co2_standard(self):
            // self._load_fields_from_model(['co2_standard'])
            */
            return default;
        }

        protected async Task<FleetVehicle> ComputeColorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_color(self):
            // self._load_fields_from_model(['color'])
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

        protected async Task<FleetVehicle> ComputeDoorsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_doors(self):
            // self._load_fields_from_model(['doors'])
            */
            return default;
        }

        protected async Task<FleetVehicle> ComputeDriverEmployeeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_fleet, FILE: fleet_vehicle.py) ---
            // def _compute_driver_employee_id(self):
            // employees_by_partner_id_and_company_id = self.env['hr.employee']._read_group(
            //     domain=[('work_contact_id', 'in', self.driver_id.ids)],
            //     groupby=['work_contact_id', 'company_id'],
            //     aggregates=['id:recordset']
            // )
            // employees_by_partner_id_and_company_id = {
            //     (partner, company): employee for partner, company, employee in employees_by_partner_id_and_company_id
            // }
            // for vehicle in self:
            //     employees = employees_by_partner_id_and_company_id.get((vehicle.driver_id, vehicle.company_id))
            //     vehicle.driver_employee_id = employees[0] if employees else False
            */
            return default;
        }

        protected async Task<FleetVehicle> ComputeElectricAssistanceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_electric_assistance(self):
            // self._load_fields_from_model(['electric_assistance'])
            */
            return default;
        }

        protected async Task<FleetVehicle> ComputeFuelTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_fuel_type(self):
            // self._load_fields_from_model(['fuel_type'])
            */
            return default;
        }

        protected async Task<FleetVehicle> ComputeFutureDriverEmployeeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_fleet, FILE: fleet_vehicle.py) ---
            // def _compute_future_driver_employee_id(self):
            // employees_by_partner_id_and_company_id = self.env['hr.employee']._read_group(
            //     domain=[('work_contact_id', 'in', self.future_driver_id.ids)],
            //     groupby=['work_contact_id', 'company_id'],
            //     aggregates=['id:recordset']
            // )
            // employees_by_partner_id_and_company_id = {
            //     (partner, company): employee for partner, company, employee in employees_by_partner_id_and_company_id
            // }
            // for vehicle in self:
            //     employees = employees_by_partner_id_and_company_id.get((vehicle.future_driver_id, vehicle.company_id))
            //     vehicle.future_driver_employee_id = employees[0] if employees else False
            */
            return default;
        }

        protected async Task<FleetVehicle> ComputeHorsepowerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_horsepower(self):
            // self._load_fields_from_model(['horsepower'])
            */
            return default;
        }

        protected async Task<FleetVehicle> ComputeHorsepowerTaxInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_horsepower_tax(self):
            // self._load_fields_from_model(['horsepower_tax'])
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

        protected async Task<FleetVehicle> ComputeModelYearInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_model_year(self):
            // self._load_fields_from_model(['model_year'])
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

        protected async Task<FleetVehicle> ComputePowerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_power(self):
            // self._load_fields_from_model(['power'])
            */
            return default;
        }

        protected async Task<FleetVehicle> ComputeRangeUnitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_range_unit(self):
            // self._load_fields_from_model(['range_unit'])
            */
            return default;
        }

        protected async Task<FleetVehicle> ComputeSeatsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_seats(self):
            // self._load_fields_from_model(['seats'])
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

        protected async Task<FleetVehicle> ComputeTrailerHookInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_trailer_hook(self):
            // self._load_fields_from_model(['trailer_hook'])
            */
            return default;
        }

        protected async Task<FleetVehicle> ComputeTransmissionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_transmission(self):
            // self._load_fields_from_model(['transmission'])
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

        protected async Task<FleetVehicle> ComputeVehicleRangeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_vehicle_range(self):
            // self._load_fields_from_model(['vehicle_range'])
            */
            return default;
        }

        public override async Task<FleetVehicle> CreateAsync(FleetVehicle entity, List<string> fields)
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
            //     vehicle_odometer = FleetVehicalOdometer.search([('vehicle_id', 'in', record.ids)], limit=1, order='value desc')
            //     if vehicle_odometer:
            //         record.odometer = vehicle_odometer.value
            //     else:
            //         record.odometer = 0
            */
            return default;
        }

        protected async Task<FleetVehicle> GetYearSelectionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _get_year_selection(self):
            // current_year = datetime.now().year
            // return [(str(i), i) for i in range(1970, current_year + 1)]
            */
            return default;
        }

        protected async Task<FleetVehicle> LoadFieldsFromModelInternalAsync(object fields_to_load)
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

        public async Task<FleetVehicle> OpenOdometerReportAsync(Guid id)
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

        protected async Task<FleetVehicle> SearchGetOverdueContractReminderInternalAsync(object @operator, object @value)
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