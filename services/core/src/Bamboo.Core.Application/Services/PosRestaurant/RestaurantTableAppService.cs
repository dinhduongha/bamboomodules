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
    [Module("PosRestaurant", Depends = new[] { "point_of_sale" })]
    public class RestaurantTableAppService : GenericApplicationService<RestaurantTable>, IRestaurantTableAppService
    {
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public RestaurantTableAppService(IRepository<RestaurantTable, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public async Task<RestaurantTable> AreOrdersStillInDraftAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_restaurant.py) ---
            // def are_orders_still_in_draft(self):
            // draft_orders_count = self.env['pos.order'].search_count([('table_id', 'in', self.ids), ('state', '=', 'draft')])
            // 
            // if draft_orders_count > 0:
            //     raise UserError(_("You cannot delete a table when orders are still in draft for this table."))
            // 
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<RestaurantTable> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_restaurant.py) ---
            // def _compute_display_name(self):
            // for table in self:
            //     table.display_name = f"{table.floor_id.name}, {table.table_number}"
            */
            return default;
        }

        protected async Task<RestaurantTable> GetIdentifierInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_restaurant.py) ---
            // def _get_identifier():
            // return uuid.uuid4().hex[:8]
            */
            return default;
        }

        protected async Task<RestaurantTable> LoadPosDataDomainInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_restaurant.py) ---
            // def _load_pos_data_domain(self, data):
            // return [('active', '=', True), ('floor_id', 'in', [floor['id'] for floor in data['restaurant.floor']['data']])]
            */
            return default;
        }

        protected async Task<RestaurantTable> LoadPosDataFieldsInternalAsync(Guid config_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_restaurant.py) ---
            // def _load_pos_data_fields(self, config_id):
            // return ['table_number', 'width', 'height', 'position_h', 'position_v', 'parent_id', 'shape', 'floor_id', 'color', 'seats', 'active']
            */
            return default;
        }

        protected async Task<RestaurantTable> LoadPosSelfDataDomainInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_restaurant.py) ---
            // def _load_pos_self_data_domain(self, data):
            // return [('floor_id', 'in', [floor['id'] for floor in data['restaurant.floor']['data']])]
            */
            return default;
        }

        protected async Task<RestaurantTable> LoadPosSelfDataFieldsInternalAsync(Guid config_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_restaurant.py) ---
            // def _load_pos_self_data_fields(self, config_id):
            // return ['table_number', 'identifier', 'floor_id']
            */
            return default;
        }

        protected async Task<RestaurantTable> UnlinkExceptActivePosSessionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_restaurant.py) ---
            // def _unlink_except_active_pos_session(self):
            // confs = self.mapped('floor_id.pos_config_ids').filtered(lambda c: c.module_pos_restaurant)
            // opened_session = self.env['pos.session'].search([('config_id', 'in', confs.ids), ('state', '!=', 'closed')])
            // if opened_session:
            //     error_msg = _("You cannot remove a table that is used in a PoS session, close the session(s) first.")
            //     if confs:
            //         raise UserError(error_msg)
            */
            return default;
        }

        protected async Task<RestaurantTable> UpdateIdentifierInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_restaurant.py) ---
            // def _update_identifier(self):
            // tables = self.env["restaurant.table"].search([])
            // for table in tables:
            //     table.identifier = self._get_identifier()
            */
            return default;
        }
    }
}