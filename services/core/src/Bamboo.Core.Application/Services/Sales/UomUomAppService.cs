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
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;

namespace Bamboo.Core.Application.Services
{
    [Module("Uom", Depends = new[] { "base" })]
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

        protected async Task<UomUom> CheckCategoryReferenceUniquenessInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: uom, FILE: uom_uom.py) ---
            // def _check_category_reference_uniqueness(self):
            // categ_res = self.with_context(active_test=False).read_group(
            //     [("category_id", "in", self.category_id.ids)],
            //     ["category_id", "uom_type"],
            //     ["category_id", "uom_type"],
            //     lazy=False,
            // )
            // uom_by_category = defaultdict(int)
            // ref_by_category = {}
            // for res in categ_res:
            //     uom_by_category[res["category_id"][0]] += res["__count"]
            //     if res["uom_type"] == "reference":
            //         ref_by_category[res["category_id"][0]] = res["__count"]
            // 
            // for category in self.category_id:
            //     reference_count = ref_by_category.get(category.id, 0)
            //     if reference_count > 1:
            //         raise ValidationError(_("UoM category %s should only have one reference unit of measure.", category.name))
            //     elif reference_count == 0 and uom_by_category.get(category.id, 0) > 0:
            //         raise ValidationError(_("UoM category %s should have a reference unit of measure.", category.name))
            */
            return default;
        }

        protected async Task<UomUom> ComputeColorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: uom, FILE: uom_uom.py) ---
            // def _compute_color(self):
            // for uom in self:
            //     if uom.uom_type == 'reference':
            //         uom.color = 7
            //     else:
            //         uom.color = 0
            */
            return default;
        }

        protected async Task<UomUom> ComputeFactorInvInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: uom, FILE: uom_uom.py) ---
            // def _compute_factor_inv(self):
            // for uom in self:
            //     uom.factor_inv = uom.factor and (1.0 / uom.factor) or 0.0
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

        protected async Task<UomUom> ComputePriceInternalAsync(object price, object to_unit)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: uom, FILE: uom_uom.py) ---
            // def _compute_price(self, price, to_unit):
            // self.ensure_one()
            // if not self or not price or not to_unit or self == to_unit:
            //     return price
            // if self.category_id.id != to_unit.category_id.id:
            //     return price
            // amount = price * self.factor
            // if to_unit:
            //     amount = amount / to_unit.factor
            // return amount
            */
            return default;
        }

        protected async Task<UomUom> ComputeQuantityInternalAsync(object qty, object to_unit, object round, object rounding_method, object raise_if_failure)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: uom, FILE: uom_uom.py) ---
            // def _compute_quantity(self, qty, to_unit, round=True, rounding_method='UP', raise_if_failure=True):
            // """ Convert the given quantity from the current UoM `self` into a given one
            //     :param qty: the quantity to convert
            //     :param to_unit: the destination UoM record (uom.uom)
            //     :param raise_if_failure: only if the conversion is not possible
            //         - if true, raise an exception if the conversion is not possible (different UoM category),
            //         - otherwise, return the initial quantity
            // """
            // if not self or not qty:
            //     return qty
            // self.ensure_one()
            // 
            // if self != to_unit and self.category_id.id != to_unit.category_id.id:
            //     if raise_if_failure:
            //         raise UserError(_(
            //             'The unit of measure %(unit)s defined on the order line doesn\'t belong to the same category as the unit of measure %(product_unit)s defined on the product. Please correct the unit of measure defined on the order line or on the product. They should belong to the same category.',
            //             unit=self.name, product_unit=to_unit.name))
            //     else:
            //         return qty
            // 
            // if self == to_unit:
            //     amount = qty
            // else:
            //     amount = qty / self.factor
            //     if to_unit:
            //         amount = amount * to_unit.factor
            // 
            // if to_unit and round:
            //     amount = tools.float_round(amount, precision_rounding=to_unit.rounding, rounding_method=rounding_method)
            // 
            // return amount
            */
            return default;
        }

        protected async Task<UomUom> ComputeRatioInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: uom, FILE: uom_uom.py) ---
            // def _compute_ratio(self):
            // for uom in self:
            //     if uom.uom_type == 'reference':
            //         uom.ratio = 1
            //     elif uom.uom_type == 'bigger':
            //         uom.ratio = uom.factor_inv
            //     else:
            //         uom.ratio = uom.factor
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
            // mapping = {
            //     'uom.product_uom_unit': 'C62',
            //     'uom.product_uom_dozen': 'DZN',
            //     'uom.product_uom_kgm': 'KGM',
            //     'uom.product_uom_gram': 'GRM',
            //     'uom.product_uom_day': 'DAY',
            //     'uom.product_uom_hour': 'HUR',
            //     'uom.product_uom_ton': 'TNE',
            //     'uom.product_uom_meter': 'MTR',
            //     'uom.product_uom_km': 'KMT',
            //     'uom.product_uom_cm': 'CMT',
            //     'uom.product_uom_litre': 'LTR',
            //     'uom.product_uom_lb': 'LBR',
            //     'uom.product_uom_oz': 'ONZ',
            //     'uom.product_uom_inch': 'INH',
            //     'uom.product_uom_foot': 'FOT',
            //     'uom.product_uom_mile': 'SMI',
            //     'uom.product_uom_floz': 'OZA',
            //     'uom.product_uom_qt': 'QT',
            //     'uom.product_uom_gal': 'GLL',
            //     'uom.product_uom_cubic_meter': 'MTQ',
            //     'uom.product_uom_cubic_inch': 'INQ',
            //     'uom.product_uom_cubic_foot': 'FTQ',
            //     'uom.uom_square_meter': 'MTK',
            //     'uom.uom_square_foot': 'FTK',
            //     'uom.product_uom_yard': 'YRD',
            //     'uom.product_uom_millimeter': 'MMT',
            // }
            // xml_ids = self._get_external_ids().get(self.id, [])
            // matches = list(set(xml_ids) & set(mapping.keys()))
            // return matches and mapping[matches[0]] or 'C62'
            */
            return default;
        }

        protected async Task<UomUom> LoadPosDataFieldsInternalAsync(Guid config_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product.py) ---
            // def _load_pos_data_fields(self, config_id):
            // return ['id', 'name', 'category_id', 'factor_inv', 'factor', 'is_pos_groupable', 'uom_type', 'rounding']
            */
            return default;
        }

        protected async Task<UomUom> LoadPosDataInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product.py) ---
            // def _load_pos_data(self, data):
            // domain = self._load_pos_data_domain(data)
            // fields = self._load_pos_data_fields(data['pos.config']['data'][0]['id'])
            // return {
            //     'data': self.with_context({**self.env.context}).search_read(domain, fields, load=False),
            //     'fields': fields,
            // }
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
            //                 "E.g. modifying the rounding could disturb your inventory balance.\n\n"
            //                 "Therefore, changing core units of measure in a running database is not recommended.",
            //                 self.name,
            //             )
            //         }
            //     }
            */
            return default;
        }

        protected async Task<UomUom> OnchangeRoundingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: uom_uom.py) ---
            // def _onchange_rounding(self):
            // precision = self.env['decimal.precision'].precision_get('Product Unit of Measure')
            // if self.rounding < 1.0 / 10.0**precision:
            //     return {'warning': {
            //         'title': _('Warning!'),
            //         'message': _(
            //             "This rounding precision is higher than the Decimal Accuracy"
            //             " (%(digits)s digits).\nThis may cause inconsistencies in computations.\n"
            //             "Please set a precision between %(min_precision)s and 1.",
            //             digits=precision, min_precision=1.0 / 10.0**precision),
            //     }}
            */
            return default;
        }

        protected async Task<UomUom> OnchangeUomTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: uom, FILE: uom_uom.py) ---
            // def _onchange_uom_type(self):
            // if self.uom_type == 'reference':
            //     self.factor = 1
            */
            return default;
        }

        protected async Task<UomUom> SetRatioInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: uom, FILE: uom_uom.py) ---
            // def _set_ratio(self):
            // if self.ratio == 0:
            //     raise ValidationError(_("The value of ratio could not be Zero"))
            // if self.uom_type == 'reference':
            //     self.factor = 1
            // elif self.uom_type == 'bigger':
            //     self.factor = 1 / self.ratio
            // else:
            //     self.factor = self.ratio
            */
            return default;
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
            // ]
            --- ODOO METHOD SOURCE (MODULE: uom, FILE: uom_uom.py) ---
            // def _unprotected_uom_xml_ids(self):
            // return [
            //     "product_uom_hour", # NOTE: this uom is protected when hr_timesheet is installed.
            //     "product_uom_dozen",
            // ]
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, UomUom entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def write(self, values):
            // # Users can not update the factor if open stock moves are based on it
            // if 'factor' in values or 'factor_inv' in values or 'category_id' in values:
            //     changed = self.filtered(
            //         lambda u: any(u[f] != values[f] if f in values else False
            //                       for f in {'factor', 'factor_inv'})) + self.filtered(
            //         lambda u: any(u[f].id != int(values[f]) if f in values else False
            //                       for f in {'category_id'}))
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
            // return super(UoM, self).write(values)
            --- ODOO METHOD SOURCE (MODULE: uom, FILE: uom_uom.py) ---
            // def write(self, values):
            // if 'factor_inv' in values:
            //     factor_inv = values.pop('factor_inv')
            //     values['factor'] = factor_inv and (1.0 / factor_inv) or 0.0
            // 
            // res = super(UoM, self).write(values)
            // if ('uom_type' not in values or values['uom_type'] != 'reference') and\
            //         not self.env.context.get('allow_to_change_reference'):
            //     self._check_category_reference_uniqueness()
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}