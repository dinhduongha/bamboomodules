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
    [Module("Stock", Category = "SupplyChain", Depends = new[] { "product", "barcodes_gs1_nomenclature", "digest" })]
    public partial class StockPackageTypeAppService : GenericApplicationService<StockPackageType>, IStockPackageTypeAppService
    {

        public StockPackageTypeAppService(IRepository<StockPackageType, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        protected async Task<StockPackageType> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_package_type.py) ---
            // def _compute_display_name(self):
            // packages_to_process_ids = []
            // for package in self:
            //     if package.env.context.get('formatted_display_name') and package.packaging_length and package.width and package.height:
            //         package.display_name = f"{package.name}\t--{package.packaging_length} x {package.width} x {package.height}--"
            //     else:
            //         packages_to_process_ids.append(package.id)
            // if packages_to_process_ids:
            //     super(StockPackageType, self.env['stock.package.type'].browse(packages_to_process_ids))._compute_display_name()
            */
            return default;
        }

        protected async Task<StockPackageType> ComputeHasQuantsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_package_type.py) ---
            // def _compute_has_quants(self):
            // pack_type_quants = dict(self.env['stock.package']._read_group(
            //     domain=[('quant_ids', '!=', False), ('package_type_id', 'in', self.ids)], groupby=['package_type_id'], aggregates=['__count']))
            // 
            // for package_type in self:
            //     package_type.has_quants = pack_type_quants.get(package_type, 0) > 0
            */
            return default;
        }

        protected async Task<StockPackageType> ComputeLengthUomNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_package_type.py) ---
            // def _compute_length_uom_name(self):
            // for package_type in self:
            //     package_type.length_uom_name = self.env['product.template']._get_length_uom_name_from_ir_config_parameter()
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: stock_package_type.py) ---
            // def _compute_length_uom_name(self):
            // package_without_carrier = self.env['stock.package.type']
            // for package in self:
            //     if package.package_carrier_type and package.package_carrier_type != 'none':
            //         # FIXME This variable does not impact any logic, it is only used for the packaging display on the form view.
            //         #  However, it generates some confusion for the users since this UoM will be ignored when sending the requests
            //         #  to the carrier server: the dimensions will be expressed with another UoM and there won't be any conversion.
            //         #  For instance, with Fedex, the UoM used with the package dimensions will depend on the UoM of
            //         #  `fedex_weight_unit`. With UPS, we will use the UoM defined on `ups_package_dimension_unit`
            //         package.length_uom_name = ""
            //     else:
            //         package_without_carrier |= package
            // super(StockPackageType, package_without_carrier)._compute_length_uom_name()
            */
            return default;
        }

        protected async Task<StockPackageType> ComputeWeightUomNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_package_type.py) ---
            // def _compute_weight_uom_name(self):
            // for package_type in self:
            //     package_type.weight_uom_name = self.env['product.template']._get_weight_uom_name_from_ir_config_parameter()
            */
            return default;
        }

        public async Task<StockPackageType> CopyDataAsync(Guid id, StockPackageTypeCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_package_type.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, name=self.env._("%s (copy)", package_type.name)) for package_type, vals in zip(self, vals_list)]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockPackageType> GetDefaultLengthUomInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_package_type.py) ---
            // def _get_default_length_uom(self):
            // return self.env['product.template']._get_length_uom_name_from_ir_config_parameter()
            */
            return default;
        }

        protected async Task<StockPackageType> GetDefaultWeightUomInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_package_type.py) ---
            // def _get_default_weight_uom(self):
            // return self.env['product.template']._get_weight_uom_name_from_ir_config_parameter()
            */
            return default;
        }

        protected async Task<StockPackageType> GetNextNameBySequenceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_package_type.py) ---
            // def _get_next_name_by_sequence(self):
            // if len(self) == 1 and self.sequence_id:
            //     return self.sequence_id.next_by_id()
            // return self.env['ir.sequence'].next_by_code('stock.package')
            */
            return default;
        }

        protected async Task<StockPackageType> OnchangeCarrierTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_delivery, FILE: stock_package_type.py) ---
            // def _onchange_carrier_type(self):
            // carrier_id = self.env['delivery.carrier'].search([('delivery_type', '=', self.package_carrier_type)], limit=1)
            // if carrier_id:
            //     self.shipper_package_code = carrier_id._get_default_custom_package_code()
            // else:
            //     self.shipper_package_code = False
            */
            return default;
        }
    }
}