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
    public class FleetVehicleAssignationLogAppService : GenericApplicationService<FleetVehicleAssignationLog>, IFleetVehicleAssignationLogAppService
    {

        public FleetVehicleAssignationLogAppService(IRepository<FleetVehicleAssignationLog, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<FleetVehicleAssignationLog> ComputeAttachmentNumberInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_fleet, FILE: fleet_vehicle_assignation_log.py) ---
            // def _compute_attachment_number(self):
            // attachment_data = self.env['ir.attachment']._read_group([
            //     ('res_model', '=', 'fleet.vehicle.assignation.log'),
            //     ('res_id', 'in', self.ids)], ['res_id'], ['__count'])
            // attachment = dict(attachment_data)
            // for doc in self:
            //     doc.attachment_number = attachment.get(doc.id, 0)
            */
            return default;
        }

        protected async Task<FleetVehicleAssignationLog> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_assignation_log.py) ---
            // def _compute_display_name(self):
            // for rec in self:
            //     rec.display_name = f'{rec.vehicle_id.name} - {rec.driver_id.name}'
            */
            return default;
        }

        protected async Task<FleetVehicleAssignationLog> ComputeDriverEmployeeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_fleet, FILE: fleet_vehicle_assignation_log.py) ---
            // def _compute_driver_employee_id(self):
            // employees = self.env['hr.employee'].search([('work_contact_id', 'in', self.driver_id.ids)])
            // 
            // for log in self:
            //     employee = employees.filtered(lambda e: e.work_contact_id.id == log.driver_id.id)
            //     log.driver_employee_id = employee and employee[0] or False
            */
            return default;
        }

        public async Task<FleetVehicleAssignationLog> GetAttachmentViewAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_fleet, FILE: fleet_vehicle_assignation_log.py) ---
            // def action_get_attachment_view(self):
            // self.ensure_one()
            // res = self.env['ir.actions.act_window']._for_xml_id('base.action_attachment')
            // res['views'] = [[self.env.ref('hr_fleet.view_attachment_kanban_inherit_hr').id, 'kanban']]
            // res['domain'] = [('res_model', '=', 'fleet.vehicle.assignation.log'), ('res_id', 'in', self.ids)]
            // res['context'] = {'default_res_model': 'fleet.vehicle.assignation.log', 'default_res_id': self.id}
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}