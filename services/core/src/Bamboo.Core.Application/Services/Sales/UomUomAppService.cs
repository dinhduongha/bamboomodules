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
    [Module("Uom", Category = "Sales", Depends = new[] { "base" })]
    public class UomUomAppService : GenericApplicationService<UomUom>, IUomUomAppService
    {
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public UomUomAppService(IRepository<UomUom, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        protected async Task<UomUom> AdjustUomQuantitiesInternalAsync(object qty, object quant_uom)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _adjust_uom_quantities(self, qty, quant_uom):
            // """ This method adjust the quantities of a procurement if its UoM isn't the same
            // as the one of the quant and the parameter 'propagate_uom' is not set.
            // """
            // procurement_uom = self
            // computed_qty = qty
            // get_param = self.env['ir.config_parameter'].sudo().get_param
            // if get_param('stock.propagate_uom') != '1':
            //     computed_qty = self._compute_quantity(qty, quant_uom, rounding_method='HALF-UP')
            //     procurement_uom = quant_uom
            // else:
            //     computed_qty = self._compute_quantity(qty, procurement_uom, rounding_method='HALF-UP')
            // return (computed_qty, procurement_uom)
            */
            return default;
        }

        protected async Task<UomUom> CheckFactorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: uom, FILE: uom_uom.py) ---
            // def _check_factor(self):
            // for uom in self:
            //     if not uom.relative_uom_id and uom.relative_factor != 1.0:
            //         raise UserError(_("Reference unit of measure is missing."))
            */
            return default;
        }

        protected async Task<UomUom> CheckQtyInternalAsync(object product_qty, Guid uom_id, object rounding_method)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: uom, FILE: uom_uom.py) ---
            // def _check_qty(self, product_qty, uom_id, rounding_method="HALF-UP"):
            // """Check if product_qty in given uom is a multiple of the packaging qty.
            // If not, rounding the product_qty to closest multiple of the packaging qty
            // according to the rounding_method "UP", "HALF-UP or "DOWN".
            // """
            // self.ensure_one()
            // packaging_qty = self._compute_quantity(1, uom_id)
            // # We do not use the modulo operator to check if qty is a mltiple of q. Indeed the quantity
            // # per package might be a float, leading to incorrect results. For example:
            // # 8 % 1.6 = 1.5999999999999996
            // # 5.4 % 1.8 = 2.220446049250313e-16
            // if product_qty and packaging_qty:
            //     product_qty = float_round(product_qty / packaging_qty, precision_rounding=1.0,
            //                           rounding_method=rounding_method) * packaging_qty
            // return product_qty
            */
            return default;
        }

        public async Task<UomUom> CompareAsync(Guid id, UomUomCompareRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: uom, FILE: uom_uom.py) ---
            // def compare(self, value1: float, value2: float) -> Literal[-1, 0, 1]:
            // """Compare two measures after rounding them with the 'Product Unit' precision
            // 
            // :param value1: origin value to compare
            // :param value2: value to compare to
            // :return: -1, 0 or 1, if ``value1`` is lower than, equal to, or greater than ``value2``.
            // """
            // self.ensure_one()
            // digits = self.env['decimal.precision'].precision_get('Product Unit')
            // return tools.float_compare(value1, value2, precision_digits=digits)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<UomUom> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: uom, FILE: uom_uom.py) ---
            // def _compute_display_name(self):
            // super()._compute_display_name()
            // for uom in self:
            //     if uom.env.context.get('formatted_display_name') and uom.relative_uom_id:
            //         uom.display_name = f"{uom.name}\t--{uom.relative_factor} {uom.relative_uom_id.name}--"
            */
            return default;
        }

        protected async Task<UomUom> ComputeFactorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: uom, FILE: uom_uom.py) ---
            // def _compute_factor(self):
            // for uom in self:
            //     if uom.relative_uom_id:
            //         uom.factor = uom.relative_factor * uom.relative_uom_id.factor
            //     else:
            //         uom.factor = uom.relative_factor
            */
            return default;
        }

        protected async Task<UomUom> ComputeFiscalCountryCodesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: uom_uom.py) ---
            // def _compute_fiscal_country_codes(self):
            // for record in self:
            //     record.fiscal_country_codes = ",".join(self.env.companies.mapped("account_fiscal_country_id.code"))
            */
            return default;
        }

        protected async Task<float> ComputePriceInternalAsync(float price, object to_unit)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: uom, FILE: uom_uom.py) ---
            // def _compute_price(self, price: float, to_unit: Self) -> float:
            // self.ensure_one()
            // if not self or not price or not to_unit or self == to_unit:
            //     return price
            // amount = price * to_unit.factor
            // if to_unit:
            //     amount = amount / self.factor
            // return amount
            */
            return default;
        }

        protected async Task<float> ComputeQuantityInternalAsync(float qty, object to_unit, bool round, object rounding_method, bool raise_if_failure)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: uom, FILE: uom_uom.py) ---
            // def _compute_quantity(
            //     self,
            //     qty: float,
            //     to_unit: Self,
            //     round: bool = True,
            //     rounding_method: RoundingMethod = 'UP',
            //     raise_if_failure: bool = True,
            // ) -> float:
            //     """ Convert the given quantity from the current UoM `self` into a given one
            //         :param qty: the quantity to convert
            //         :param to_unit: the destination UomUom record (uom.uom)
            //         :param raise_if_failure: only if the conversion is not possible
            //             - if true, raise an exception if the conversion is not possible (different UomUom category),
            //             - otherwise, return the initial quantity
            //     """
            //     if not self or not qty:
            //         return qty
            //     self.ensure_one()
            // 
            //     if self == to_unit:
            //         amount = qty
            //     else:
            //         amount = qty * self.factor
            //         if to_unit:
            //             amount = amount / to_unit.factor
            // 
            //     if to_unit and round:
            //         amount = tools.float_round(amount, precision_rounding=to_unit.rounding, rounding_method=rounding_method)
            // 
            //     return amount
            */
            return default;
        }

        protected async Task<UomUom> ComputeRoundingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: uom, FILE: uom_uom.py) ---
            // def _compute_rounding(self):
            // """ All Units of Measure share the same rounding precision defined in 'Product Unit'.
            //     Set in a compute to ensure compatibility with previous calls to `uom.rounding`.
            // """
            // decimal_precision = self.env['decimal.precision'].precision_get('Product Unit')
            // self.rounding = 10 ** -decimal_precision
            */
            return default;
        }

        protected async Task<UomUom> ComputeSequenceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: uom, FILE: uom_uom.py) ---
            // def _compute_sequence(self):
            // for uom in self:
            //     if uom.id and uom.sequence:
            //         # Only set a default sequence before the record creation, or on module update if
            //         # there is no value.
            //         continue
            //     uom.sequence = min(int(uom.relative_factor * 100.0), 1000)
            */
            return default;
        }

        protected async Task<UomUom> DomainProductUomsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: uom_uom.py) ---
            // def _domain_product_uoms(self):
            // domain = []
            // if self.env.context.get("product_id"):
            //     domain.append(Domain('product_id', '=', self.env.context['product_id']))
            // if self.env.context.get("product_ids"):
            //     domain.append(Domain('product_id', 'in', self.env.context['product_ids']))
            // return Domain.OR(domain) if domain else Domain.TRUE
            */
            return default;
        }

        protected async Task<UomUom> FilterProtectedUomsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: uom, FILE: uom_uom.py) ---
            // def _filter_protected_uoms(self):
            // """Verifies self does not contain protected uoms."""
            // linked_model_data = self.env['ir.model.data'].sudo().search([
            //     ('model', '=', self._name),
            //     ('res_id', 'in', self.ids),
            //     ('module', '=', 'uom'),
            //     ('name', 'not in', self._unprotected_uom_xml_ids()),
            // ])
            // if not linked_model_data:
            //     return self.browse()
            // else:
            //     return self.browse(set(linked_model_data.mapped('res_id')))
            */
            return default;
        }

        protected async Task<UomUom> GetUneceCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: uom_uom.py) ---
            // def _get_unece_code(self):
            // """ Returns the UNECE code used for international trading for corresponding to the UoM as per
            // https://unece.org/fileadmin/DAM/cefact/recommendations/rec20/rec20_rev3_Annex2e.pdf"""
            // xml_ids = self._get_external_ids().get(self.id, [])
            // matches = list(set(xml_ids) & set(UOM_TO_UNECE_CODE.keys()))
            // return matches and UOM_TO_UNECE_CODE[matches[0]] or 'C62'
            */
            return default;
        }

        protected async Task<UomUom> GetUomFromUneceCodeInternalAsync(object unece_code)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: uom_uom.py) ---
            // def _get_uom_from_unece_code(self, unece_code):
            // unece_code_to_uom = {v: k for k, v in UOM_TO_UNECE_CODE.items()}
            // uom_xmlid = unece_code_to_uom.get(unece_code, 'uom.product_uom_unit')
            // return self.env.ref(uom_xmlid, raise_if_not_found=False)
            */
            return default;
        }

        protected async Task<bool> HasCommonReferenceInternalAsync(object other_uom)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: uom, FILE: uom_uom.py) ---
            // def _has_common_reference(self, other_uom: Self) -> bool:
            // """ Check if `self` and `other_uom` have a common reference unit """
            // self.ensure_one()
            // other_uom.ensure_one()
            // self_path = self.parent_path.split('/')
            // other_path = other_uom.parent_path.split('/')
            // common_path = []
            // for self_parent, other_parent in zip(self_path, other_path):
            //     if self_parent == other_parent:
            //         common_path.append(self_parent)
            //     else:
            //         break
            // return bool(common_path)
            */
            return default;
        }

        public async Task<bool> IsZeroAsync(Guid id, UomUomIsZeroRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: uom, FILE: uom_uom.py) ---
            // def is_zero(self, value: float) -> bool:
            // """Check if the value is zero after rounding with the 'Product Unit' precision"""
            // self.ensure_one()
            // digits = self.env['decimal.precision'].precision_get('Product Unit')
            // return tools.float_is_zero(value, precision_digits=digits)
            */
            var entity = await Repository.GetAsync(id); return default;
        }

        protected async Task<UomUom> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: uom.py) ---
            // def _load_pos_data_fields(self, config):
            // taxes = self.env['account.tax'].search(self.env['account.tax']._check_company_domain(config.company_id.id))
            // product_uom_fields = taxes._eval_taxes_computation_prepare_product_uom_fields()
            // return list(product_uom_fields.union({'id', 'name', 'factor', 'is_pos_groupable', 'parent_path', 'rounding'}))
            */
            return default;
        }

        protected async Task<UomUom> OnchangeCriticalFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: uom, FILE: uom_uom.py) ---
            // def _onchange_critical_fields(self):
            // if self._filter_protected_uoms() and self.create_date < (fields.Datetime.now() - timedelta(days=1)):
            //     return {
            //         'warning': {
            //             'title': _("Warning for %s", self.name),
            //             'message': _(
            //                 "Some critical fields have been modified on %s.\n"
            //                 "Note that existing data WON'T be updated by this change.\n\n"
            //                 "As units of measure impact the whole system, this may cause critical issues.\n"
            //                 "Therefore, changing core units of measure in a running database is not recommended.",
            //                 self.name,
            //             )
            //         }
            //     }
            */
            return default;
        }

        public async Task<UomUom> OpenPackagingBarcodesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: uom_uom.py) ---
            // def action_open_packaging_barcodes(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Packaging Barcodes'),
            //     'res_model': 'product.uom',
            //     'view_mode': 'list',
            //     'view_id': self.env.ref('product.product_uom_list_view').id,
            //     'domain': [('uom_id', '=', self.id)],
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<float> RoundAsync(Guid id, UomUomRoundRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: uom, FILE: uom_uom.py) ---
            // def round(self, value: float, rounding_method: RoundingMethod = 'HALF-UP') -> float:
            // """Round the value using the 'Product Unit' precision"""
            // self.ensure_one()
            // digits = self.env['decimal.precision'].precision_get('Product Unit')
            // return tools.float_round(value, precision_digits=digits, rounding_method=rounding_method)
            */
            var entity = await Repository.GetAsync(id); return default;
        }

        protected async Task<UomUom> UnlinkExceptMasterDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: uom, FILE: uom_uom.py) ---
            // def _unlink_except_master_data(self):
            // locked_uoms = self._filter_protected_uoms()
            // if locked_uoms:
            //     raise UserError(_(
            //         "The following units of measure are used by the system and cannot be deleted: %s\nYou can archive them instead.",
            //         ", ".join(locked_uoms.mapped('name')),
            //     ))
            */
            return default;
        }

        protected async Task<UomUom> UnprotectedUomXmlIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: uom_uom.py) ---
            // def _unprotected_uom_xml_ids(self):
            // # Override
            // # When timesheet App is installed, we also need to protect the hour UoM
            // # from deletion (and warn in case of modification)
            // return [
            //     "product_uom_dozen",
            //     "product_uom_pack_6",
            // ]
            --- ODOO METHOD SOURCE (MODULE: uom, FILE: uom_uom.py) ---
            // def _unprotected_uom_xml_ids(self):
            // """ Return a list of UoM XML IDs that are not protected by default.
            // Note: Some of these may be protected via overrides in other modules.
            // """
            // return [
            //     "product_uom_hour",
            //     "product_uom_dozen",
            //     "product_uom_pack_6",
            // ]
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, UomUom entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def write(self, vals):
            // # Users can not update the factor if open stock moves are based on it
            // keys_to_protect = {'factor', 'relative_factor', 'relative_uom_id'}
            // if any(key in vals for key in keys_to_protect):
            //     changed = self.filtered(
            //         lambda u: any(
            //             f in vals and u[f] != vals[f]
            //             for f in ('factor', 'relative_factor')
            //         ) or ('relative_uom_id' in vals and u.relative_uom_id.id != int(vals['relative_uom_id']))
            //     )
            //     if changed:
            //         error_msg = _(
            //             "You cannot change the ratio of this unit of measure"
            //             " as some products with this UoM have already been moved"
            //             " or are currently reserved."
            //         )
            //         if self.env['stock.move'].sudo().search_count([
            //             ('product_uom', 'in', changed.ids),
            //             ('state', 'not in', ('cancel', 'done'))
            //         ]):
            //             raise UserError(error_msg)
            //         if self.env['stock.move.line'].sudo().search_count([
            //             ('product_uom_id', 'in', changed.ids),
            //             ('state', 'not in', ('cancel', 'done')),
            //         ]):
            //             raise UserError(error_msg)
            //         if self.env['stock.quant'].sudo().search_count([
            //             ('product_id.product_tmpl_id.uom_id', 'in', changed.ids),
            //             ('quantity', '!=', 0),
            //         ]):
            //             raise UserError(error_msg)
            // return super().write(vals)
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}