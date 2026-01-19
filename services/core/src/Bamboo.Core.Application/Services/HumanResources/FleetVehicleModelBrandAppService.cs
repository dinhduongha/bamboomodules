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
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Fleet", Category = "HumanResources", Depends = new[] { "base", "mail" })]
    public partial class FleetVehicleModelBrandAppService : GenericApplicationService<FleetVehicleModelBrand>, IFleetVehicleModelBrandAppService
    {

        public FleetVehicleModelBrandAppService(IRepository<FleetVehicleModelBrand, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<FleetVehicleModelBrand> BrandModelAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model_brand.py) ---
            // def action_brand_model(self):
            // self.ensure_one()
            // view = {
            //     'name': _('Models'),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'list,form',
            //     'res_model': 'fleet.vehicle.model',
            //     'context': {'search_default_brand_id': self.id, 'default_brand_id': self.id}
            // }
            // 
            // return view
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<FleetVehicleModelBrand> ComputeModelCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model_brand.py) ---
            // def _compute_model_count(self):
            // model_data = self.env['fleet.vehicle.model']._read_group([
            //     ('brand_id', 'in', self.ids), ('active', '=', 'true')
            // ], ['brand_id'], ['__count'])
            // models_brand = {brand.id: count for brand, count in model_data}
            // 
            // for record in self:
            //     record.model_count = models_brand.get(record.id, 0)
            */
            return default;
        }

        public async Task<FleetVehicleModelBrand> OpenBrandFormAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model_brand.py) ---
            // def action_open_brand_form(self):
            // self.ensure_one()
            // return {
            //     'name': _('Manufacturer'),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'fleet.vehicle.model.brand',
            //     'res_id': self.id
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}