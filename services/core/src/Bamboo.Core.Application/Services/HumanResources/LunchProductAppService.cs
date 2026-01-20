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
    [Module("Lunch", Category = "HumanResources", Depends = new[] { "mail" })]
    public partial class LunchProductAppService : GenericApplicationService<LunchProduct>, ILunchProductAppService
    {
        private readonly IImageMixinAppService _imageMixinAppService;
        public LunchProductAppService(IRepository<LunchProduct, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IImageMixinAppService imageMixinAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
            _imageMixinAppService = imageMixinAppService;
        }

        protected async Task<LunchProduct> ComputeIsAvailableAtInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py) ---
            // def _compute_is_available_at(self):
            // """
            //     Is available_at is always false when browsing it
            //     this field is there only to search (see _search_is_available_at)
            // """
            // for product in self:
            //     product.is_available_at = False
            */
            return default;
        }

        protected async Task<LunchProduct> ComputeIsFavoriteInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py) ---
            // def _compute_is_favorite(self):
            // for product in self:
            //     product.is_favorite = self.env.user in product.favorite_user_ids
            */
            return default;
        }

        protected async Task<LunchProduct> ComputeIsNewInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py) ---
            // def _compute_is_new(self):
            // today = fields.Date.context_today(self)
            // for product in self:
            //     if product.new_until:
            //         product.is_new = today <= product.new_until
            //     else:
            //         product.is_new = False
            */
            return default;
        }

        protected async Task<LunchProduct> ComputeLastOrderDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py) ---
            // def _compute_last_order_date(self):
            // all_orders = self.env['lunch.order'].search([
            //     ('user_id', '=', self.env.user.id),
            //     ('product_id', 'in', self.ids),
            // ])
            // mapped_orders = defaultdict(lambda: self.env['lunch.order'])
            // for order in all_orders:
            //     mapped_orders[order.product_id] |= order
            // for product in self:
            //     if not mapped_orders[product]:
            //         product.last_order_date = False
            //     else:
            //         product.last_order_date = max(mapped_orders[product].mapped('date'))
            */
            return default;
        }

        protected async Task<LunchProduct> ComputeProductImageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py) ---
            // def _compute_product_image(self):
            // for product in self:
            //     product.product_image = product.image_128 or product.category_id.image_128
            */
            return default;
        }

        protected async Task<LunchProduct> InverseIsFavoriteInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py) ---
            // def _inverse_is_favorite(self):
            // """ Handled in the write() """
            // return
            */
            return default;
        }

        protected async Task<LunchProduct> SearchIsAvailableAtInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py) ---
            // def _search_is_available_at(self, operator, value):
            // supported_operators = ['in', 'not in', '=', '!=']
            // 
            // if not operator in supported_operators:
            //     return expression.TRUE_DOMAIN
            // 
            // if isinstance(value, int):
            //     value = [value]
            // 
            // if operator in expression.NEGATIVE_TERM_OPERATORS:
            //     return expression.AND([[('supplier_id.available_location_ids', 'not in', value)], [('supplier_id.available_location_ids', '!=', False)]])
            // 
            // return expression.OR([[('supplier_id.available_location_ids', 'in', value)], [('supplier_id.available_location_ids', '=', False)]])
            */
            return default;
        }

        protected async Task<LunchProduct> SyncActiveFromRelatedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py) ---
            // def _sync_active_from_related(self):
            // """ Archive/unarchive product after related field is archived/unarchived """
            // return self.filtered(lambda p: (p.category_id.active and p.supplier_id.active) != p.active).toggle_active()
            */
            return default;
        }

        public async Task<LunchProduct> ToggleActiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py) ---
            // def toggle_active(self):
            // invalid_products = self.filtered(lambda product: not product.active and not product.category_id.active)
            // if invalid_products:
            //     raise UserError(_("The following product categories are archived. You should either unarchive the categories or change the category of the product.\n%s", '\n'.join(invalid_products.category_id.mapped('name'))))
            // invalid_products = self.filtered(lambda product: not product.active and not product.supplier_id.active)
            // if invalid_products:
            //     raise UserError(_("The following suppliers are archived. You should either unarchive the suppliers or change the supplier of the product.\n%s", '\n'.join(invalid_products.supplier_id.mapped('name'))))
            // return super().toggle_active()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}