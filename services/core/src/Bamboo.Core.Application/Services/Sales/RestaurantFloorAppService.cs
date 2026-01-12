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
    [Module("PosRestaurant", Category = "Sales", Depends = new[] { "point_of_sale" })]
    public class RestaurantFloorAppService : GenericApplicationService<RestaurantFloor>, IRestaurantFloorAppService
    {
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public RestaurantFloorAppService(IRepository<RestaurantFloor, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public async Task<RestaurantFloor> DeactivateFloorAsync(Guid id, RestaurantFloorDeactivateFloorRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_restaurant.py) ---
            // def deactivate_floor(self, session_id):
            // draft_orders = self.env['pos.order'].search([('session_id', '=', session_id), ('state', '=', 'draft'), ('table_id.floor_id', '=', self.id)])
            // if draft_orders:
            //     raise UserError(_("You cannot delete a floor when orders are still in draft for this floor."))
            // for table in self.table_ids:
            //     table.active = False
            // self.active = False
            // 
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<RestaurantFloor> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_restaurant.py) ---
            // def _load_pos_data_domain(self, data, config):
            // return [('pos_config_ids', '=', config.id)]
            */
            return default;
        }

        protected async Task<RestaurantFloor> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_restaurant.py) ---
            // def _load_pos_data_fields(self, config):
            // return ['name', 'background_color', 'table_ids', 'sequence', 'pos_config_ids', 'floor_background_image']
            */
            return default;
        }

        protected async Task<RestaurantFloor> LoadPosSelfDataDomainInternalAsync(object data, object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_restaurant.py) ---
            // def _load_pos_self_data_domain(self, data, config):
            // return [('id', 'in', config.floor_ids.ids)]
            */
            return default;
        }

        protected async Task<RestaurantFloor> LoadPosSelfDataFieldsInternalAsync(object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_restaurant.py) ---
            // def _load_pos_self_data_fields(self, config):
            // return ['name', 'table_ids']
            */
            return default;
        }

        public async Task<RestaurantFloor> RenameFloorAsync(Guid id, RestaurantFloorRenameFloorRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_restaurant.py) ---
            // def rename_floor(self, new_name):
            // for floor in self:
            //     floor.name = new_name
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<RestaurantFloor> SyncFromUiAsync(Guid id, RestaurantFloorSyncFromUiRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_restaurant.py) ---
            // def sync_from_ui(self, name, background_color, config_id):
            // floor_fields = {
            //     "name": name,
            //     "background_color": background_color,
            // }
            // pos_floor = self.create(floor_fields)
            // pos_floor.pos_config_ids = [Command.link(config_id)]
            // return {
            //     'id': pos_floor.id,
            //     'name': pos_floor.name,
            //     'background_color': pos_floor.background_color,
            //     'table_ids': [],
            //     'sequence': pos_floor.sequence,
            //     'tables': [],
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<RestaurantFloor> UnlinkExceptActivePosSessionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_restaurant.py) ---
            // def _unlink_except_active_pos_session(self):
            // confs = self.mapped('pos_config_ids').filtered(lambda c: c.module_pos_restaurant)
            // opened_session = self.env['pos.session'].search([('config_id', 'in', confs.ids), ('state', '!=', 'closed')])
            // if opened_session and confs:
            //     error_msg = _("You cannot remove a floor that is used in a PoS session, close the session(s) first: \n")
            //     for floor in self:
            //         for session in opened_session:
            //             if floor in session.config_id.floor_ids:
            //                 error_msg += _("Floor: %(floor)s - PoS Config: %(config)s \n", floor=floor.name, config=session.config_id.name)
            //     raise UserError(error_msg)
            */
            return default;
        }
    }
}