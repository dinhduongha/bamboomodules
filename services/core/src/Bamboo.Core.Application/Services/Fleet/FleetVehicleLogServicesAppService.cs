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
    public class FleetVehicleLogServicesAppService : GenericApplicationService<FleetVehicleLogServices>, IFleetVehicleLogServicesAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        public FleetVehicleLogServicesAppService(IRepository<FleetVehicleLogServices, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        protected async Task<FleetVehicleLogServices> ComputeAmountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_fleet, FILE: fleet_vehicle_log_services.py) ---
            // def _compute_amount(self):
            // for log_service in self:
            //     log_service.amount = log_service.account_move_line_id.debit
            */
            return default;
        }

        protected async Task<FleetVehicleLogServices> ComputePurchaserEmployeeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_fleet, FILE: fleet_vehicle_log_services.py) ---
            // def _compute_purchaser_employee_id(self):
            // for service in self:
            //     service.purchaser_employee_id = service.vehicle_id.driver_employee_id
            */
            return default;
        }

        protected async Task<FleetVehicleLogServices> ComputePurchaserIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_services.py) ---
            // def _compute_purchaser_id(self):
            // for service in self:
            //     service.purchaser_id = service.vehicle_id.driver_id
            --- ODOO METHOD SOURCE (MODULE: hr_fleet, FILE: fleet_vehicle_log_services.py) ---
            // def _compute_purchaser_id(self):
            // internals = self.filtered(lambda r: r.purchaser_employee_id)
            // super(FleetVehicleLogServices, (self - internals))._compute_purchaser_id()
            // for service in internals:
            //     service.purchaser_id = service.purchaser_employee_id.work_contact_id
            */
            return default;
        }

        protected async Task<FleetVehicleLogServices> ComputeVehicleIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_fleet, FILE: fleet_vehicle_log_services.py) ---
            // def _compute_vehicle_id(self):
            // for service in self:
            //     # We avoid emptying the vehicle_id as it is a required field
            //     if not service.account_move_line_id.vehicle_id:
            //         continue
            //     service.vehicle_id = service.account_move_line_id.vehicle_id
            */
            return default;
        }

        protected async Task<FleetVehicleLogServices> GetOdometerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_services.py) ---
            // def _get_odometer(self):
            // self.odometer = 0
            // for record in self:
            //     if record.odometer_id:
            //         record.odometer = record.odometer_id.value
            */
            return default;
        }

        protected async Task<FleetVehicleLogServices> InverseAmountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_fleet, FILE: fleet_vehicle_log_services.py) ---
            // def _inverse_amount(self):
            // if any(service.account_move_line_id for service in self):
            //     raise UserError(_("You cannot modify amount of services linked to an account move line. Do it on the related accounting entry instead."))
            */
            return default;
        }

        public async Task<FleetVehicleLogServices> OpenAccountMoveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_fleet, FILE: fleet_vehicle_log_services.py) ---
            // def action_open_account_move(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'account.move',
            //     'target': 'current',
            //     'name': _('Bill'),
            //     'res_id': self.account_move_line_id.move_id.id,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<FleetVehicleLogServices> SetOdometerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_services.py) ---
            // def _set_odometer(self):
            // for record in self:
            //     if not record.odometer:
            //         raise UserError(_('Emptying the odometer value of a vehicle is not allowed.'))
            //     odometer = self.env['fleet.vehicle.odometer'].create({
            //         'value': record.odometer,
            //         'date': record.date or fields.Date.context_today(record),
            //         'vehicle_id': record.vehicle_id.id
            //     })
            //     self.odometer_id = odometer
            */
            return default;
        }

        protected async Task<FleetVehicleLogServices> UnlinkIfNoLinkedBillInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_fleet, FILE: fleet_vehicle_log_services.py) ---
            // def _unlink_if_no_linked_bill(self):
            // if self.env.context.get('ignore_linked_bill_constraint'):
            //     return
            // if any(log_service.account_move_line_id for log_service in self):
            //     raise UserError(_("You cannot delete log services records because one or more of them were bill created."))
            */
            return default;
        }
    }
}