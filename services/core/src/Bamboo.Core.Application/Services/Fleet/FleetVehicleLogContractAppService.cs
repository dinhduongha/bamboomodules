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
    public class FleetVehicleLogContractAppService : GenericApplicationService<FleetVehicleLogContract>, IFleetVehicleLogContractAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        public FleetVehicleLogContractAppService(IRepository<FleetVehicleLogContract, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<FleetVehicleLogContract> CloseAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py) ---
            // def action_close(self):
            // self.write({'state': 'closed'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<FleetVehicleLogContract> ComputeContractNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py) ---
            // def _compute_contract_name(self):
            // for record in self:
            //     name = record.vehicle_id.name
            //     if name and record.cost_subtype_id.name:
            //         name = record.cost_subtype_id.name + ' ' + name
            //     record.name = name
            */
            return default;
        }

        protected async Task<FleetVehicleLogContract> ComputeDaysLeftInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py) ---
            // def _compute_days_left(self):
            // """return a dict with as value for each contract an integer
            // if contract is in an open state and is overdue, return 0
            // if contract is in a closed state, return -1
            // otherwise return the number of days before the contract expires
            // """
            // today = fields.Date.from_string(fields.Date.today())
            // for record in self:
            //     if record.expiration_date and record.state in ['open', 'expired']:
            //         renew_date = fields.Date.from_string(record.expiration_date)
            //         diff_time = (renew_date - today).days
            //         record.days_left = diff_time if diff_time > 0 else 0
            //         record.expires_today = diff_time == 0
            //     else:
            //         record.days_left = -1
            //         record.expires_today = False
            */
            return default;
        }

        protected async Task<FleetVehicleLogContract> ComputeHasOpenContractInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py) ---
            // def _compute_has_open_contract(self):
            // today = fields.Date.today()
            // open_contracts = self.env['fleet.vehicle.log.contract'].search([
            //     ('vehicle_id', 'in', self.vehicle_id.ids),
            //     ('state', '=', 'open'),
            //     ('expiration_date', '>=', today)
            // ])
            // for log_contract in self:
            //     log_contract.has_open_contract = log_contract.vehicle_id in open_contracts.vehicle_id
            */
            return default;
        }

        public async Task<FleetVehicleLogContract> ComputeNextYearDateAsync(Guid id, FleetVehicleLogContractComputeNextYearDateRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py) ---
            // def compute_next_year_date(self, strdate):
            // oneyear = relativedelta(years=1)
            // start_date = fields.Date.from_string(strdate)
            // return fields.Date.to_string(start_date + oneyear)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<FleetVehicleLogContract> DraftAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py) ---
            // def action_draft(self):
            // self.write({'state': 'futur'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<FleetVehicleLogContract> ExpireAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py) ---
            // def action_expire(self):
            // self.write({'state': 'expired'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<FleetVehicleLogContract> OpenAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py) ---
            // def action_open(self):
            // self.write({'state': 'open'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<FleetVehicleLogContract> OpenEmployeeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_fleet, FILE: fleet_vehicle_log_contract.py) ---
            // def action_open_employee(self):
            // self.ensure_one()
            // return {
            //     'name': _('Related Employee'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'hr.employee',
            //     'view_mode': 'form',
            //     'res_id': self.purchaser_employee_id.id,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<FleetVehicleLogContract> RunSchedulerAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py) ---
            // def run_scheduler(self):
            // self.scheduler_manage_contract_expiration()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<FleetVehicleLogContract> SchedulerManageContractExpirationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py) ---
            // def scheduler_manage_contract_expiration(self):
            // # This method is called by a cron task
            // # It manages the state of a contract, possibly by posting a message on the vehicle concerned and updating its status
            // params = self.env['ir.config_parameter'].sudo()
            // delay_alert_contract = int(params.get_param('hr_fleet.delay_alert_contract', default=30))
            // date_today = fields.Date.from_string(fields.Date.today())
            // outdated_days = fields.Date.to_string(date_today + relativedelta(days=+delay_alert_contract))
            // reminder_activity_type = self.env.ref('fleet.mail_act_fleet_contract_to_renew')
            // nearly_expired_contracts = self.search([
            //     ('state', '=', 'open'),
            //     ('expiration_date', '<', outdated_days),
            //     ('user_id', '!=', False)
            // ]
            // ).filtered(
            //     lambda nec: reminder_activity_type not in nec.activity_ids.activity_type_id
            // )
            // 
            // for contract in nearly_expired_contracts:
            //     contract.activity_schedule(
            //         'fleet.mail_act_fleet_contract_to_renew', contract.expiration_date,
            //         user_id=contract.user_id.id)
            // 
            // expired_contracts = self.search([('state', 'not in', ['expired', 'closed']), ('expiration_date', '<',fields.Date.today() )])
            // expired_contracts.action_expire()
            // 
            // futur_contracts = self.search([('state', 'not in', ['futur', 'closed']), ('start_date', '>', fields.Date.today())])
            // futur_contracts.action_draft()
            // 
            // now_running_contracts = self.search([('state', '=', 'futur'), ('start_date', '<=', fields.Date.today())])
            // now_running_contracts.action_open()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}