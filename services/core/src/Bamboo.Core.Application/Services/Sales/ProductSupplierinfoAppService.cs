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
    [Module("Product", Category = "Sales", Depends = new[] { "base", "mail", "uom" })]
    public partial class ProductSupplierinfoAppService : GenericApplicationService<ProductSupplierinfo>, IProductSupplierinfoAppService
    {

        public ProductSupplierinfoAppService(IRepository<ProductSupplierinfo, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<ProductSupplierinfo> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: product.py) ---
            // def _compute_display_name(self):
            // if self.env.context.get('use_simplified_supplier_name'):
            //     super()._compute_display_name()
            // else:
            //     for supplier in self:
            //         price_str = formatLang(self.env, supplier.price, currency_obj=supplier.currency_id)
            //         supplier.display_name = f'{supplier.partner_id.display_name} ({supplier.min_qty} {supplier.product_uom_id.name} - {price_str})'
            */
            return default;
        }

        protected async Task<ProductSupplierinfo> ComputeIsSubcontractorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: product.py) ---
            // def _compute_is_subcontractor(self):
            // for supplier in self:
            //     boms = supplier.product_id.variant_bom_ids
            //     boms |= supplier.product_tmpl_id.bom_ids.filtered(lambda b: not b.product_id or b.product_id in (supplier.product_id or supplier.product_tmpl_id.product_variant_ids))
            //     supplier.is_subcontractor = supplier.partner_id in boms.subcontractor_ids
            */
            return default;
        }

        protected async Task<ProductSupplierinfo> ComputeLastPurchaseDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: product.py) ---
            // def _compute_last_purchase_date(self):
            // self.last_purchase_date = False
            // purchases = self.env['purchase.order'].search([
            //     ('state', '=', 'purchase'),
            //     ('order_line.product_id', 'in',
            //      self.product_tmpl_id.product_variant_ids.ids),
            //     ('partner_id', 'in', self.partner_id.ids),
            // ], order='date_order desc')
            // for supplier in self:
            //     products = supplier.product_tmpl_id.product_variant_ids
            //     for purchase in purchases:
            //         if purchase.partner_id != supplier.partner_id:
            //             continue
            //         if not (products & purchase.order_line.product_id):
            //             continue
            //         supplier.last_purchase_date = purchase.date_order
            //         break
            */
            return default;
        }

        protected async Task<ProductSupplierinfo> ComputePriceDiscountedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_supplierinfo.py) ---
            // def _compute_price_discounted(self):
            // for rec in self:
            //     product_uom = (rec.product_id or rec.product_tmpl_id).uom_id
            //     rec.price_discounted = rec.product_uom_id._compute_price(rec.price, product_uom) * (1 - rec.discount / 100)
            */
            return default;
        }

        protected async Task<ProductSupplierinfo> ComputePriceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_supplierinfo.py) ---
            // def _compute_price(self):
            // for rec in self:
            //     rec.price = rec.product_id.standard_price if rec.product_id else rec.product_tmpl_id.standard_price if rec.product_tmpl_id else 0.0
            */
            return default;
        }

        protected async Task<ProductSupplierinfo> ComputeProductIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_supplierinfo.py) ---
            // def _compute_product_id(self):
            // for rec in self:
            //     if self.env.get('default_product_id'):
            //         rec.product_id = self.env.get('default_product_id')
            //     elif not rec.product_id and rec.product_variant_count == 1:
            //         rec.product_id = rec.product_tmpl_id.product_variant_id
            */
            return default;
        }

        protected async Task<ProductSupplierinfo> ComputeProductTmplIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_supplierinfo.py) ---
            // def _compute_product_tmpl_id(self):
            // for rec in self:
            //     if rec.product_id:
            //         rec.product_tmpl_id = rec.product_id.product_tmpl_id
            */
            return default;
        }

        protected async Task<ProductSupplierinfo> ComputeProductUomIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_supplierinfo.py) ---
            // def _compute_product_uom_id(self):
            // for rec in self:
            //     if not rec.product_uom_id:
            //         rec.product_uom_id = rec.product_id.uom_id if rec.product_id else rec.product_tmpl_id.uom_id
            */
            return default;
        }

        protected async Task<ProductSupplierinfo> ComputeShowSetSupplierButtonInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: product.py) ---
            // def _compute_show_set_supplier_button(self):
            // self.show_set_supplier_button = True
            // orderpoint_id = self.env.context.get('orderpoint_id', self.env.context.get('default_orderpoint_id'))
            // if orderpoint_id:
            //     orderpoint = self.env['stock.warehouse.orderpoint'].browse(orderpoint_id)
            //     self.filtered(
            //         lambda s: s.id == orderpoint.supplier_id.id
            //     ).show_set_supplier_button = False
            */
            return default;
        }

        protected async Task<ProductSupplierinfo> GetFilteredSupplierInternalAsync(Guid company_id, Guid product_id, object @params)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_supplierinfo.py) ---
            // def _get_filtered_supplier(self, company_id, product_id, params=False):
            // return self.filtered(lambda s: (not s.company_id or s.company_id.id == company_id.id) and (s.partner_id.active and (not s.product_id or s.product_id == product_id)))
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: product.py) ---
            // def _get_filtered_supplier(self, company_id, product_id, params=False):
            // if params and 'order_id' in params and params['order_id'].company_id:
            //     company_id = params['order_id'].company_id
            // return super()._get_filtered_supplier(company_id, product_id, params)
            */
            return default;
        }

        public async Task<ProductSupplierinfo> GetImportTemplatesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_supplierinfo.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Vendor Pricelists'),
            //     'template': '/product/static/xls/product_supplierinfo.xls'
            // }]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductSupplierinfo> OnchangePartnerIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: product.py) ---
            // def _onchange_partner_id(self):
            // self.currency_id = self.partner_id.property_purchase_currency_id.id or self.env.company.currency_id.id
            */
            return default;
        }

        protected async Task<ProductSupplierinfo> OnchangeProductTmplIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_supplierinfo.py) ---
            // def _onchange_product_tmpl_id(self):
            // """Clear product variant if it no longer matches the product template."""
            // if self.product_id and self.product_id not in self.product_tmpl_id.product_variant_ids:
            //     self.product_id = False
            */
            return default;
        }

        protected async Task<ProductSupplierinfo> SanitizeValsInternalAsync(object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_supplierinfo.py) ---
            // def _sanitize_vals(self, vals):
            // """Sanitize vals to sync product variant & template on read/write."""
            // # add product's product_tmpl_id if none present in vals
            // if  vals.get('product_id') and not vals.get('product_tmpl_id'):
            //     product = self.env['product.product'].browse(vals['product_id'])
            //     vals['product_tmpl_id'] = product.product_tmpl_id.id
            */
            return default;
        }

        public async Task<ProductSupplierinfo> SetSupplierAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: product.py) ---
            // def action_set_supplier(self):
            // self.ensure_one()
            // orderpoint_id = self.env.context.get('orderpoint_id')
            // if not orderpoint_id:
            //     return
            // orderpoint = self.env['stock.warehouse.orderpoint'].browse(orderpoint_id)
            // if 'buy' not in orderpoint.route_id.rule_ids.mapped('action'):
            //     domain = Domain.AND([
            //         [('action', '=', 'buy')],
            //         Domain.OR([
            //             [('company_id', '=', orderpoint.company_id.id)],
            //             [('company_id', '=', False)],
            //         ]),
            //     ])
            //     orderpoint.route_id = self.env['stock.rule'].search(domain, limit=1).route_id.id
            // orderpoint.supplier_id = self
            // supplier_min_qty = self.product_uom_id._compute_quantity(self.min_qty, orderpoint.product_id.uom_id)
            // if orderpoint.qty_to_order < supplier_min_qty:
            //     orderpoint.qty_to_order = supplier_min_qty
            // if self.env.context.get('replenish_id'):
            //     replenish = self.env['product.replenish'].browse(self.env.context.get('replenish_id'))
            //     replenish.supplier_id = self
            //     return {
            //         'type': 'ir.actions.act_window',
            //         'name': 'Replenish',
            //         'res_model': 'product.replenish',
            //         'res_id': replenish.id,
            //         'target': 'new',
            //         'view_mode': 'form',
            //     }
            // return orderpoint.action_stock_replenishment_info()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}