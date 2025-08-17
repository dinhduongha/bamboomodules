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
    [Module("Mrp", Depends = new[] { "product", "stock", "resource" })]
    public class MrpBomByproductAppService : GenericApplicationService<MrpBomByproduct>, IMrpBomByproductAppService
    {

        public MrpBomByproductAppService(IRepository<MrpBomByproduct, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<MrpBomByproduct> AddFromCatalogAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def action_add_from_catalog(self):
            // bom = self.env['mrp.bom'].browse(self.env.context.get('order_id'))
            // return bom.with_context(child_field='byproduct_ids').action_add_from_catalog()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MrpBomByproduct> ComputeProductUomIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _compute_product_uom_id(self):
            // """ Changes UoM if product_id changes. """
            // for record in self:
            //     record.product_uom_id = record.product_id.uom_id.id
            */
            return default;
        }

        protected async Task<MrpBomByproduct> GetProductCatalogLinesDataInternalAsync(object @default)
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
            //         'readOnly': len(self) > 1
            //     }
            // return {
            //     'quantity': 0,
            // }
            */
            return default;
        }

        protected async Task<MrpBomByproduct> SkipByproductLineInternalAsync(object product)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py) ---
            // def _skip_byproduct_line(self, product):
            // """ Control if a byproduct line should be produced, can be inherited to add
            // custom control.
            // """
            // self.ensure_one()
            // if not product or product._name == 'product.template':
            //     return False
            // 
            // never_attribute_values = self.env.context.get('never_attribute_ids')
            // return self.env['mrp.bom']._skip_for_no_variant(product, self.bom_product_template_attribute_value_ids, never_attribute_values)
            */
            return default;
        }
    }
}