using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Services;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Models;

namespace Bamboo.Core.Application.Services
{
    [Module("SaleManagement", Depends = new[] { "sale", "digest" })]
    public class SaleOrderOptionAppService : GenericApplicationService<SaleOrderOption>, ISaleOrderOptionAppService
    {

        public SaleOrderOptionAppService(IRepository<SaleOrderOption, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<SaleOrderOption> AddOptionToOrderAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_management, FILE: sale_order_option.py) ---
            // def add_option_to_order(self):
            // self.ensure_one()
            // 
            // if not self.order_id._can_be_edited_on_portal():
            //     raise UserError(_('You cannot add options to a confirmed order.'))
            // 
            // values = self._get_values_to_add_to_order()
            // order_line = self.env['sale.order.line'].create(values)
            // 
            // self.write({'line_id': order_line.id})
            // 
            // return order_line
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<SaleOrderOption> ButtonAddToOrderAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_management, FILE: sale_order_option.py) ---
            // def button_add_to_order(self):
            // self.add_option_to_order()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<SaleOrderOption> ComputeDiscountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_management, FILE: sale_order_option.py) ---
            // def _compute_discount(self):
            // for option in self:
            //     if not option.product_id:
            //         continue
            //     # To compute the discount a so line is created in cache
            //     values = option._get_values_to_add_to_order()
            //     new_sol = self.env['sale.order.line'].new(values)
            //     new_sol._compute_discount()
            //     option.discount = new_sol.discount
            //     # Avoid attaching the new line when called on template change
            //     new_sol.order_id = False
            */
            return default;
        }

        protected async Task<SaleOrderOption> ComputeIsPresentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_management, FILE: sale_order_option.py) ---
            // def _compute_is_present(self):
            // # NOTE: this field cannot be stored as the line_id is usually removed
            // # through cascade deletion, which means the compute would be false
            // for option in self:
            //     option.is_present = bool(option.order_id.order_line.filtered(lambda l: l.product_id == option.product_id))
            */
            return default;
        }

        protected async Task<SaleOrderOption> ComputeNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_management, FILE: sale_order_option.py) ---
            // def _compute_name(self):
            // for option in self:
            //     if not option.product_id:
            //         continue
            //     product_lang = option.product_id.with_context(lang=option.order_id.partner_id.lang)
            //     option.name = product_lang.get_product_multiline_description_sale()
            */
            return default;
        }

        protected async Task<SaleOrderOption> ComputePriceUnitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_management, FILE: sale_order_option.py) ---
            // def _compute_price_unit(self):
            // for option in self:
            //     if not option.product_id:
            //         continue
            //     # To compute the price_unit a so line is created in cache
            //     values = option._get_values_to_add_to_order()
            //     new_sol = self.env['sale.order.line'].new(values)
            //     new_sol._compute_price_unit()
            //     option.price_unit = new_sol.price_unit
            //     # Avoid attaching the new line when called on template change
            //     new_sol.order_id = False
            */
            return default;
        }

        protected async Task<SaleOrderOption> ComputeUomIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_management, FILE: sale_order_option.py) ---
            // def _compute_uom_id(self):
            // for option in self:
            //     if not option.product_id or option.uom_id:
            //         continue
            //     option.uom_id = option.product_id.uom_id
            */
            return default;
        }

        protected async Task<SaleOrderOption> GetValuesToAddToOrderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_management, FILE: sale_order_option.py) ---
            // def _get_values_to_add_to_order(self):
            // self.ensure_one()
            // return {
            //     'order_id': self.order_id.id,
            //     'price_unit': self.price_unit,
            //     'technical_price_unit': self.price_unit,
            //     'name': self.name,
            //     'product_id': self.product_id.id,
            //     'product_uom_qty': self.quantity,
            //     'product_uom': self.uom_id.id,
            //     'discount': self.discount,
            //     'sequence': max(self.order_id.order_line.mapped('sequence'), default=0) + 1
            // }
            */
            return default;
        }

        protected async Task<SaleOrderOption> ProductIdDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_management, FILE: sale_order_option.py) ---
            // def _product_id_domain(self):
            // """ Returns the domain of the products that can be added as a sale order option. """
            // return [('sale_ok', '=', True)]
            */
            return default;
        }

        protected async Task<SaleOrderOption> SearchIsPresentInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_management, FILE: sale_order_option.py) ---
            // def _search_is_present(self, operator, value):
            // if (operator, value) in [('=', True), ('!=', False)]:
            //     return [('line_id', '=', False)]
            // return [('line_id', '!=', False)]
            */
            return default;
        }
    }
}