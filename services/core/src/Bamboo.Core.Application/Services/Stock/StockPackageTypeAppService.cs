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
    [Module("Stock", Depends = new[] { "product", "barcodes_gs1_nomenclature", "digest" })]
    public class StockPackageTypeAppService : GenericApplicationService<StockPackageType>, IStockPackageTypeAppService
    {

        public StockPackageTypeAppService(IRepository<StockPackageType, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

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
            // super(PackageType, package_without_carrier)._compute_length_uom_name()
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