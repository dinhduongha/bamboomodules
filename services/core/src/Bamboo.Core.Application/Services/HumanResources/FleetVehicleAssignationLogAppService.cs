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
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Fleet", Category = "HumanResources", Depends = new[] { "base", "mail" })]
    public partial class FleetVehicleAssignationLogAppService : GenericApplicationService<FleetVehicleAssignationLog>, IFleetVehicleAssignationLogAppService
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
            // employees_by_partner_id_and_company_id = self.env['hr.employee']._read_group(
            //     domain=[('work_contact_id', 'in', self.driver_id.ids)],
            //     groupby=['work_contact_id', 'company_id'],
            //     aggregates=['id:recordset']
            // )
            // employees_by_partner_id_and_company_id = {
            //     (partner, company): employee for partner, company, employee in employees_by_partner_id_and_company_id
            // }
            // for log in self:
            //     employees = employees_by_partner_id_and_company_id.get((log.driver_id, log.vehicle_id.company_id))
            //     log.driver_employee_id = employees[0] if employees else False
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