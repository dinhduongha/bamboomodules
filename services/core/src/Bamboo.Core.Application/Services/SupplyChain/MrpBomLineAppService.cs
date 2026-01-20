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
    [Module("Mrp", Category = "SupplyChain", Depends = new[] { "product", "stock", "resource" })]
    public partial class MrpBomLineAppService : GenericApplicationService<MrpBomLine>, IMrpBomLineAppService
    {

        public MrpBomLineAppService(IRepository<MrpBomLine, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        public async Task<MrpBomLine> AddFromCatalogAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def action_add_from_catalog(self):
            // bom = self.env['mrp.bom'].browse(self.env.context.get('order_id'))
            // return bom.with_context(child_field='bom_line_ids').action_add_from_catalog()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MrpBomLine> ComputeAttachmentsCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _compute_attachments_count(self):
            // for line in self:
            //     nbr_attach = self.env['product.document'].search_count([
            //         '&', '&', ('attached_on_mrp', '=', 'bom'), ('active', '=', 't'),
            //         '|',
            //         '&', ('res_model', '=', 'product.product'), ('res_id', '=', line.product_id.id),
            //         '&', ('res_model', '=', 'product.template'), ('res_id', '=', line.product_tmpl_id.id)])
            //     line.attachments_count = nbr_attach
            */
            return default;
        }

        protected async Task<MrpBomLine> ComputeChildBomIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _compute_child_bom_id(self):
            // products = self.product_id
            // bom_by_product = self.env['mrp.bom']._bom_find(products)
            // for line in self:
            //     if not line.product_id:
            //         line.child_bom_id = False
            //     else:
            //         line.child_bom_id = bom_by_product.get(line.product_id, False)
            */
            return default;
        }

        protected async Task<MrpBomLine> ComputeChildLineIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _compute_child_line_ids(self):
            // """ If the BOM line refers to a BOM, return the ids of the child BOM lines """
            // for line in self:
            //     line.child_line_ids = line.child_bom_id.bom_line_ids.ids or False
            */
            return default;
        }

        protected async Task<MrpBomLine> GetCostShareInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_mrp, FILE: mrp_bom.py) ---
            // def _get_cost_share(self):
            // self.ensure_one()
            // product = self.env.context.get('bom_variant_id', self.env['product.product'])
            // variant_bom_lines = self.bom_id.bom_line_ids.filtered(lambda bl: not bl._skip_bom_line(product) and not bl.product_uom_id.is_zero(bl.product_qty))
            // if not float_is_zero(self.cost_share, precision_digits=2) or not len(variant_bom_lines) or not all(float_is_zero(bom_line.cost_share, precision_digits=2) for bom_line in variant_bom_lines):
            //     return self.cost_share / 100
            // return 1 / len(variant_bom_lines)
            */
            return default;
        }

        protected async Task<MrpBomLine> GetDefaultProductUomIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _get_default_product_uom_id(self):
            // return self.env['uom.uom'].search([], limit=1, order='id').id
            */
            return default;
        }

        protected async Task<MrpBomLine> GetLineCostShareInternalAsync(object product, object boms_done)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_mrp, FILE: mrp_bom.py) ---
            // def _get_line_cost_share(self, product, boms_done):
            // if not self:
            //     return 100.0
            // self.ensure_one()
            // parent_cost_share = next((vals.get('bom_cost_share', 100.0) for bom, vals in reversed(boms_done) if bom == self.bom_id), 100)
            // line_cost_share = parent_cost_share * self.with_context(bom_variant_id=product)._get_cost_share()
            // return line_cost_share
            */
            return default;
        }

        protected async Task<MrpBomLine> GetProductCatalogLinesDataInternalAsync(object @default)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _get_product_catalog_lines_data(self, default=False, **kwargs):
            // if self and not default:
            //     self.product_id.ensure_one()
            //     return {
            //         **self[0].bom_id._get_product_price_and_data(self[0].product_id),
            //         'quantity': sum(
            //             self.mapped(
            //                 lambda line: line.product_uom_id._compute_quantity(
            //                     qty=line.product_qty,
            //                     to_unit=line.product_uom_id,
            //                 )
            //             )
            //         ),
            //         'readOnly': len(self) > 1,
            //         'uomDisplayName': len(self) == 1 and self.product_uom_id.display_name or self.product_id.uom_id.display_name,
            //     }
            // return {
            //     'quantity': 0,
            // }
            */
            return default;
        }

        public async Task<MrpBomLine> OnchangeProductIdAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def onchange_product_id(self):
            // if self.product_id:
            //     self.product_uom_id = self.product_id.uom_id.id
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MrpBomLine> PrepareBomDoneValuesInternalAsync(object quantity, object product, object original_quantity, object boms_done)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _prepare_bom_done_values(self, quantity, product, original_quantity, boms_done):
            // return {'qty': quantity, 'product': product, 'original_qty': original_quantity, 'parent_line': self}
            --- ODOO METHOD SOURCE (MODULE: purchase_mrp, FILE: mrp_bom.py) ---
            // def _prepare_bom_done_values(self, quantity, product, original_quantity, boms_done):
            // result = super()._prepare_bom_done_values(quantity, product, original_quantity, boms_done)
            // result['bom_cost_share'] = self._get_line_cost_share(product, boms_done)
            // return result
            */
            return default;
        }

        protected async Task<MrpBomLine> PrepareLineDoneValuesInternalAsync(object quantity, object product, object original_quantity, object parent_line, object boms_done)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _prepare_line_done_values(self, quantity, product, original_quantity, parent_line, boms_done):
            // return {'qty': quantity, 'product': product, 'original_qty': original_quantity, 'parent_line': parent_line}
            --- ODOO METHOD SOURCE (MODULE: purchase_mrp, FILE: mrp_bom.py) ---
            // def _prepare_line_done_values(self, quantity, product, original_quantity, parent_line, boms_done):
            // result = super()._prepare_line_done_values(quantity, product, original_quantity, parent_line, boms_done)
            // result['line_cost_share'] = float_round(self._get_line_cost_share(product, boms_done), precision_digits=2)
            // return result
            */
            return default;
        }

        public async Task<MrpBomLine> SeeAttachmentsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def action_see_attachments(self):
            // domain = [
            //     '&', ('attached_on_mrp', '=', 'bom'),
            //     '|',
            //     '&', ('res_model', '=', 'product.product'), ('res_id', '=', self.product_id.id),
            //     '&', ('res_model', '=', 'product.template'), ('res_id', '=', self.product_id.product_tmpl_id.id)]
            // attachments = self.env['product.document'].search(domain)
            // nbr_product_attach = len(attachments.filtered(lambda a: a.res_model == 'product.product'))
            // nbr_template_attach = len(attachments.filtered(lambda a: a.res_model == 'product.template'))
            // context = {'default_res_model': 'product.product',
            //     'default_res_id': self.product_id.id,
            //     'default_company_id': self.company_id.id,
            //     'attached_on_bom': True,
            //     'search_default_context_variant': not (nbr_product_attach == 0 and nbr_template_attach > 0) if self.env.user.has_group('product.group_product_variant') else False
            // }
            // 
            // return {
            //     'name': _('Attachments'),
            //     'domain': domain,
            //     'res_model': 'product.document',
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'kanban,list,form',
            //     'target': 'current',
            //     'help': _('''<p class="o_view_nocontent_smiling_face">
            //                 Upload files to your product
            //             </p><p>
            //                 Use this feature to store any files, like drawings or specifications.
            //             </p>'''),
            //     'limit': 80,
            //     'context': context,
            //     'search_view_id': self.env.ref('product.product_document_search').ids
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MrpBomLine> SkipBomLineInternalAsync(object product, object never_attribute_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _skip_bom_line(self, product, never_attribute_values=False):
            // """ Control if a BoM line should be produced, can be inherited to add custom control.
            //     cases:
            //         - no_variant:
            //             1. attribute present on the line
            //                 => need to be at least one attribute value matching between the one passed as args and the ones one the line
            //             2. attribute not present on the line
            //                 => valid if the line has no attribute value selected for that attribute
            //         - always and dynamic: match_all_variant_values()
            // """
            // self.ensure_one()
            // if not product or product._name == 'product.template':
            //     return False
            // 
            // return self.env['mrp.bom']._skip_for_no_variant(product, self.bom_product_template_attribute_value_ids, never_attribute_values)
            */
            return default;
        }
    }
}