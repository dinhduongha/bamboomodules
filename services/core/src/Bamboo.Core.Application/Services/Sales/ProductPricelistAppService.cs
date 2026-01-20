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
    [Module("Product", Category = "Sales", Depends = new[] { "base", "mail", "uom" })]
    public partial class ProductPricelistAppService : GenericApplicationService<ProductPricelist>, IProductPricelistAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public ProductPricelistAppService(IRepository<ProductPricelist, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public async Task<ProductPricelist> ArchiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: product_pricelist.py) ---
            // def action_archive(self):
            // loyalty_programs = self.env['loyalty.program'].sudo().search([
            //     ('active', '=', True),
            //     ('pricelist_ids', 'in', self.ids)
            // ])
            // if loyalty_programs:
            //     raise UserError(_(
            //         "This pricelist may not be archived. "
            //         "It is being used for active promotion programs: %s",
            //         ', '.join(loyalty_programs.mapped('name'))
            //     ))
            // return super().action_archive()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductPricelist> BaseDomainItemIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_pricelist.py) ---
            // def _base_domain_item_ids(self):
            // return [
            //     '|', ('product_tmpl_id', '=', None), ('product_tmpl_id.active', '=', True),
            //     '|', ('product_id', '=', None), ('product_id.active', '=', True),
            // ]
            */
            return default;
        }

        protected async Task<ProductPricelist> CheckWebsitesInCompanyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_pricelist.py) ---
            // def _check_websites_in_company(self):
            // """ Prevent misconfiguration multi-website/multi-companies.
            // 
            // If the record has a company, the website should be from that company.
            // """
            // for record in self.filtered(lambda pl: pl.website_id and pl.company_id):
            //     if record.website_id.company_id != record.company_id:
            //         raise ValidationError(_(
            //             "Only the company's websites are allowed."
            //             "\nLeave the Company field empty or select a website from that company."
            //         ))
            */
            return default;
        }

        protected async Task<ProductPricelist> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_pricelist.py) ---
            // def _compute_display_name(self):
            // for pricelist in self:
            //     pricelist_name = pricelist.name and pricelist.name or _('New')
            //     pricelist.display_name = f'{pricelist_name} ({pricelist.currency_id.name})'
            */
            return default;
        }

        protected async Task<ProductPricelist> ComputePartnersCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partnership, FILE: product_pricelist.py) ---
            // def _compute_partners_count(self):
            // partners_data = self.env['res.partner']._read_group(
            //     domain=[('specific_property_product_pricelist', 'in', self.ids)],
            //     groupby=['specific_property_product_pricelist'],
            //     aggregates=['__count'],
            // )
            // mapped_data = {pricelist.id: count for pricelist, count in partners_data}
            // for pricelist in self:
            //     pricelist.partners_count = mapped_data.get(pricelist.id, 0)
            */
            return default;
        }

        protected async Task<ProductPricelist> ComputePriceRuleInternalAsync(object products, object quantity)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_pricelist.py) ---
            // def _compute_price_rule(
            //     self, products, quantity, *, currency=None, uom=None, date=False, compute_price=True,
            //     **kwargs
            // ):
            //     """ Low-level method - Mono pricelist, multi products
            //     Returns: dict{product_id: (price, suitable_rule) for the given pricelist}
            // 
            //     Note: self and self.ensure_one()
            // 
            //     :param products: recordset of products (product.product/product.template)
            //     :param float quantity: quantity of products requested (in given uom)
            //     :param currency: record of currency (res.currency)
            //                      note: currency.ensure_one()
            //     :param uom: unit of measure (uom.uom record)
            //         If not specified, prices returned are expressed in product uoms
            //     :param date: date to use for price computation and currency conversions
            //     :type date: date or datetime
            //     :param bool compute_price: whether the price should be computed (default: True)
            // 
            //     :returns: product_id: (price, pricelist_rule)
            //     :rtype: dict
            //     """
            //     self and self.ensure_one()  # self is at most one record
            // 
            //     currency = currency or self.currency_id or self.env.company.currency_id
            //     currency.ensure_one()
            // 
            //     if not products:
            //         return {}
            // 
            //     if not date:
            //         # Used to fetch pricelist rules and currency rates
            //         date = fields.Datetime.now()
            // 
            //     # Fetch all rules potentially matching specified products/templates/categories and date
            //     rules = self._get_applicable_rules(products, date, **kwargs)
            // 
            //     results = {}
            //     for product in products:
            //         suitable_rule = self.env['product.pricelist.item']
            // 
            //         product_uom = product.uom_id
            //         target_uom = uom or product_uom  # If no uom is specified, fall back on the product uom
            // 
            //         # Compute quantity in product uom because pricelist rules are specified
            //         # w.r.t product default UoM (min_quantity, price_surchage, ...)
            //         if target_uom != product_uom:
            //             qty_in_product_uom = target_uom._compute_quantity(
            //                 quantity, product_uom, raise_if_failure=False
            //             )
            //         else:
            //             qty_in_product_uom = quantity
            // 
            //         for rule in rules:
            //             if rule._is_applicable_for(product, qty_in_product_uom):
            //                 suitable_rule = rule
            //                 break
            // 
            //         if compute_price:
            //             price = suitable_rule._compute_price(
            //                 product, quantity, target_uom, date=date, currency=currency, **kwargs)
            //         else:
            //             # Skip price computation when only the rule is requested.
            //             price = 0.0
            // 
            //         results[product.id] = (price, suitable_rule.id)
            // 
            //     return results
            */
            return default;
        }

        protected async Task<ProductPricelist> ComputePriceRuleMultiInternalAsync(object products, object quantity, object uom, object date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_pricelist.py) ---
            // def _compute_price_rule_multi(self, products, quantity, uom=None, date=False, **kwargs):
            // """ Low-level method - Multi pricelist, multi products
            // Returns: dict{product_id: dict{pricelist_id: (price, suitable_rule)} }"""
            // if not self.ids:
            //     pricelists = self.search([])
            // else:
            //     pricelists = self
            // results = {}
            // for pricelist in pricelists:
            //     subres = pricelist._compute_price_rule(products, quantity, uom=uom, date=date, **kwargs)
            //     for product_id, price in subres.items():
            //         results.setdefault(product_id, {})
            //         results[product_id][pricelist.id] = price
            // return results
            */
            return default;
        }

        public async Task<ProductPricelist> CopyDataAsync(Guid id, ProductPricelistCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_pricelist.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // if 'name' not in default:
            //     for pricelist, vals in zip(self, vals_list):
            //         vals['name'] = _("%s (copy)", pricelist.name)
            // return vals_list
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<ProductPricelist> CreateAsync(ProductPricelist entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_pricelist.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if vals.get('company_id') and not vals.get('website_id'):
            //         # l10n modules install will change the company currency, creating a
            //         # pricelist for that currency. Do not use user's company in that
            //         # case as module install are done with OdooBot (company 1)
            //         # YTI FIXME: The fix is not at the correct place
            //         # It be set when we actually create the pricelist
            //         self = self.with_context(default_company_id=vals['company_id'])
            // pricelists = super().create(vals_list)
            // if pricelists:
            //     self.env.registry.clear_cache()
            // return pricelists
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<ProductPricelist> DefaultCurrencyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_pricelist.py) ---
            // def _default_currency_id(self):
            // return self.env.company.currency_id.id
            */
            return default;
        }

        protected async Task<ProductPricelist> DefaultWebsiteInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_pricelist.py) ---
            // def _default_website(self):
            // """ Find the first company's website, if there is one. """
            // company_id = self.env.company.id
            // 
            // if self.env.context.get('default_company_id'):
            //     company_id = self.env.context.get('default_company_id')
            // 
            // domain = [('company_id', '=', company_id)]
            // return self.env['website'].search(domain, limit=1)
            */
            return default;
        }

        protected async Task<ProductPricelist> DomainItemIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_pricelist.py) ---
            // def _domain_item_ids(self):
            // return self._base_domain_item_ids()
            */
            return default;
        }

        protected async Task<ProductPricelist> GetApplicableRulesDomainInternalAsync(object products, object date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_pricelist.py) ---
            // def _get_applicable_rules_domain(self, products, date, **kwargs):
            // self and self.ensure_one()  # self is at most one record
            // if products._name == 'product.template':
            //     templates_domain = ('product_tmpl_id', 'in', products.ids)
            //     products_domain = ('product_id.product_tmpl_id', 'in', products.ids)
            // else:
            //     templates_domain = ('product_tmpl_id', 'in', products.product_tmpl_id.ids)
            //     products_domain = ('product_id', 'in', products.ids)
            // 
            // return [
            //     ('pricelist_id', '=', self.id),
            //     '|', ('categ_id', '=', False), ('categ_id', 'parent_of', products.categ_id.ids),
            //     '|', ('product_tmpl_id', '=', False), templates_domain,
            //     '|', ('product_id', '=', False), products_domain,
            //     '|', ('date_start', '=', False), ('date_start', '<=', date),
            //     '|', ('date_end', '=', False), ('date_end', '>=', date),
            // ]
            */
            return default;
        }

        protected async Task<ProductPricelist> GetApplicableRulesInternalAsync(object products, object date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_pricelist.py) ---
            // def _get_applicable_rules(self, products, date, **kwargs):
            // self and self.ensure_one()  # self is at most one record
            // if not self:
            //     return self.env['product.pricelist.item']
            // 
            // return self.env['product.pricelist.item'].search(
            //     self._get_applicable_rules_domain(products=products, date=date, **kwargs)
            // )
            */
            return default;
        }

        public async Task<ProductPricelist> GetImportTemplatesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_pricelist.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Pricelists'),
            //     'template': '/product/static/xls/product_pricelist.xls'
            // }]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductPricelist> GetPartnerPricelistMultiFilterHookInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_pricelist.py) ---
            // def _get_partner_pricelist_multi_filter_hook(self):
            // return self.filtered('active')
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_pricelist.py) ---
            // def _get_partner_pricelist_multi_filter_hook(self):
            // res = super()._get_partner_pricelist_multi_filter_hook()
            // website = ir_http.get_request_website()
            // if website:
            //     res = res.filtered(lambda pl: pl._is_available_on_website(website))
            // return res
            */
            return default;
        }

        protected async Task<ProductPricelist> GetPartnerPricelistMultiInternalAsync(List<Guid> partner_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_pricelist.py) ---
            // def _get_partner_pricelist_multi(self, partner_ids):
            // """ Retrieve the applicable pricelist for given partners in a given company.
            // 
            // It will return the first found pricelist in this order:
            // First, the pricelist of the specific property (res_id set), this one
            //         is created when saving a pricelist on the partner form view.
            // Else, it will return the pricelist of the partner country group
            // Else, it will return the generic property (res_id not set)
            // Else, it will return the first available pricelist if any
            // 
            // :return: a dict {partner_id: pricelist}
            // """
            // ProductPricelist = self.env['product.pricelist']
            // 
            // if not self.env['res.groups']._is_feature_enabled('product.group_product_pricelist'):
            //     # Skip pricelist computation if pricelists are disabled.
            //     return defaultdict(lambda: ProductPricelist)
            // 
            // # `partner_ids` might be ID from inactive users. We should use active_test
            // # as we will do a search() later (real case for website public user).
            // Partner = self.env['res.partner'].with_context(active_test=False)
            // company_id = self.env.company.id
            // pl_domain = self._get_partner_pricelist_multi_search_domain_hook(company_id)
            // 
            // # if no specific property, try to find a fitting pricelist
            // result = {}
            // remaining_partner_ids = []
            // for partner in Partner.browse(partner_ids):
            //     if partner.specific_property_product_pricelist._get_partner_pricelist_multi_filter_hook():
            //         result[partner.id] = partner.specific_property_product_pricelist
            //     else:
            //         remaining_partner_ids.append(partner.id)
            // 
            // if remaining_partner_ids:
            //     IrConfigParameter = self.env['ir.config_parameter'].sudo()
            // 
            //     def convert_to_int(string_value):
            //         try:
            //             return int(string_value)
            //         except (TypeError, ValueError, OverflowError):
            //             return None
            //     # get fallback pricelist when no pricelist for a given country
            //     pl_fallback = (
            //         ProductPricelist.search(pl_domain + [('country_group_ids', '=', False)], limit=1) or
            //         # save data in ir.config_parameter instead of ir.default for
            //         # res.partner.property_product_pricelist
            //         # otherwise the data will become the default value while
            //         # creating without specifying the property_product_pricelist
            //         # however if the property_product_pricelist is not specified
            //         # the result of the previous line should have high priority
            //         # when computing
            //         ProductPricelist.browse(convert_to_int(IrConfigParameter.get_param(f'res.partner.property_product_pricelist_{company_id}'))) or
            //         ProductPricelist.browse(convert_to_int(IrConfigParameter.get_param('res.partner.property_product_pricelist'))) or
            //         ProductPricelist.search(pl_domain, limit=1)
            //     )
            //     # group partners by country, and find a pricelist for each country
            //     remaining_partners = self.env['res.partner'].browse(remaining_partner_ids)
            //     partners_by_country = remaining_partners.grouped('country_id')
            //     for country, partners in partners_by_country.items():
            //         if not country and (country_code := self.env.context.get('country_code')):
            //             country = self.env['res.country'].search([('code', '=', country_code)], limit=1)
            //         pl = ProductPricelist.search(pl_domain + [('country_group_ids.country_ids', '=', country.id if country else False)], limit=1)
            //         pl = pl or pl_fallback
            //         result.update(dict.fromkeys(partners._ids, pl))
            // 
            // return result
            */
            return default;
        }

        protected async Task<ProductPricelist> GetPartnerPricelistMultiSearchDomainHookInternalAsync(Guid company_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_pricelist.py) ---
            // def _get_partner_pricelist_multi_search_domain_hook(self, company_id):
            // return [
            //     ('active', '=', True),
            //     ('company_id', 'in', [company_id, False]),
            // ]
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_pricelist.py) ---
            // def _get_partner_pricelist_multi_search_domain_hook(self, company_id):
            // domain = super()._get_partner_pricelist_multi_search_domain_hook(company_id)
            // website = ir_http.get_request_website()
            // if website:
            //     domain += self._get_website_pricelists_domain(website)
            // return domain
            */
            return default;
        }

        protected async Task<ProductPricelist> GetProductPriceInternalAsync(object product)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_pricelist.py) ---
            // def _get_product_price(self, product, *args, **kwargs):
            // """Compute the pricelist price for the specified product, qty & uom.
            // 
            // Note: self and self.ensure_one()
            // 
            // :param product: product record (product.product/product.template)
            // :param float quantity: quantity of products requested (in given uom)
            // :param currency: record of currency (res.currency) (optional)
            // :param uom: unit of measure (uom.uom record) (optional)
            //     If not specified, prices returned are expressed in product uoms
            // :param date: date to use for price computation and currency conversions (optional)
            // :type date: date or datetime
            // 
            // :returns: unit price of the product, considering pricelist rules if any
            // :rtype: float
            // """
            // self and self.ensure_one()  # self is at most one record
            // return self._compute_price_rule(product, *args, **kwargs)[product.id][0]
            */
            return default;
        }

        protected async Task<ProductPricelist> GetProductPriceRuleInternalAsync(object product)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_pricelist.py) ---
            // def _get_product_price_rule(self, product, *args, **kwargs):
            // """Compute the pricelist price & rule for the specified product, qty & uom.
            // 
            // Note: self and self.ensure_one()
            // 
            // :param product: product record (product.product/product.template)
            // :param float quantity: quantity of products requested (in given uom)
            // :param currency: record of currency (res.currency) (optional)
            // :param uom: unit of measure (uom.uom record) (optional)
            //     If not specified, prices returned are expressed in product uoms
            // :param date: date to use for price computation and currency conversions (optional)
            // :type date: date or datetime
            // 
            // :returns: (product unit price, applied pricelist rule id)
            // :rtype: tuple(float, int)
            // """
            // self and self.ensure_one()  # self is at most one record
            // return self._compute_price_rule(product, *args, **kwargs)[product.id]
            */
            return default;
        }

        protected async Task<ProductPricelist> GetProductRuleInternalAsync(object product)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_pricelist.py) ---
            // def _get_product_rule(self, product, *args, **kwargs):
            // """Compute the pricelist price & rule for the specified product, qty & uom.
            // 
            // Note: self and self.ensure_one()
            // 
            // :param product: product record (product.product/product.template)
            // :param float quantity: quantity of products requested (in given uom)
            // :param currency: record of currency (res.currency) (optional)
            // :param uom: unit of measure (uom.uom record) (optional)
            //     If not specified, prices returned are expressed in product uoms
            // :param date: date to use for price computation and currency conversions (optional)
            // :type date: date or datetime
            // 
            // :returns: applied pricelist rule id
            // :rtype: int or False
            // """
            // self and self.ensure_one()  # self is at most one record
            // return self._compute_price_rule(product, *args, compute_price=False, **kwargs)[product.id][1]
            */
            return default;
        }

        protected async Task<ProductPricelist> GetProductsPriceInternalAsync(object products)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_pricelist.py) ---
            // def _get_products_price(self, products, *args, **kwargs):
            // """Compute the pricelist prices for the specified products, quantity & uom.
            // 
            // Note: self and self.ensure_one()
            // 
            // :param products: recordset of products (product.product/product.template)
            // :param float quantity: quantity of products requested (in given uom)
            // :param currency: record of currency (res.currency) (optional)
            // :param uom: unit of measure (uom.uom record) (optional)
            //     If not specified, prices returned are expressed in product uoms
            // :param date: date to use for price computation and currency conversions (optional)
            // :type date: date or datetime
            // 
            // :returns: {product_id: product price}, considering the current pricelist if any
            // :rtype: dict(int, float)
            // """
            // self and self.ensure_one()  # self is at most one record
            // return {
            //     product_id: res_tuple[0]
            //     for product_id, res_tuple in self._compute_price_rule(products, *args, **kwargs).items()
            // }
            */
            return default;
        }

        protected async Task<ProductPricelist> GetWebsitePricelistsDomainInternalAsync(object website)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_pricelist.py) ---
            // def _get_website_pricelists_domain(self, website):
            // ''' Check above `_is_available_on_website` for explanation.
            // Change in this method should be reflected in `_is_available_on_website`.
            // '''
            // return [
            //     ('active', '=', True),
            //     ('company_id', 'in', [False, website.company_id.id]),
            //     '|', ('website_id', '=', website.id),
            //     '&', ('website_id', '=', False),
            //     '|', ('selectable', '=', True), ('code', '!=', False),
            // ]
            */
            return default;
        }

        protected async Task<ProductPricelist> IsAvailableInCountryInternalAsync(object country_code)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_pricelist.py) ---
            // def _is_available_in_country(self, country_code):
            // self.ensure_one()
            // if not country_code or not self.country_group_ids:
            //     return True
            // return country_code in self.country_group_ids.country_ids.mapped('code')
            */
            return default;
        }

        protected async Task<ProductPricelist> IsAvailableOnWebsiteInternalAsync(object website)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_pricelist.py) ---
            // def _is_available_on_website(self, website):
            // """ To be able to be used on a website, a pricelist should either:
            // - Have its `website_id` set to current website (specific pricelist).
            // - Have no `website_id` set and should be `selectable` (generic pricelist)
            //   or should have a `code` (generic promotion).
            // - Have no `company_id` or a `company_id` matching its website one.
            // 
            // Note: A pricelist without a website_id, not selectable and without a
            //       code is a backend pricelist.
            // 
            // Change in this method should be reflected in `_get_website_pricelists_domain`.
            // """
            // self.ensure_one()
            // if self.company_id and self.company_id != website.company_id:
            //     return False
            // return self.active and self.website_id.id == website.id or (not self.website_id and (self.selectable or self.sudo().code))
            */
            return default;
        }

        protected async Task<ProductPricelist> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_pricelist.py) ---
            // def _load_pos_data_domain(self, data, config):
            // pricelist_ids = [preset['pricelist_id'] for preset in data['pos.preset']]
            // return [('id', 'in', config._get_available_pricelists().ids + pricelist_ids)]
            */
            return default;
        }

        protected async Task<ProductPricelist> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product_pricelist.py) ---
            // def _load_pos_data_fields(self, config):
            // return ['id', 'name', 'display_name', 'item_ids']
            */
            return default;
        }

        public async Task<ProductPricelist> OpenPricelistReportAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_pricelist.py) ---
            // def action_open_pricelist_report(self):
            // self.ensure_one()
            // return {
            //     'name': _("Pricelist Report Preview"),
            //     'type': 'ir.actions.client',
            //     'tag': 'generate_pricelist_report',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductPricelist> PriceGetInternalAsync(object product, object quantity)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_pricelist.py) ---
            // def _price_get(self, product, quantity, **kwargs):
            // """ Multi pricelist, mono product - returns price per pricelist """
            // return {
            //     key: price[0]
            //     for key, price in self._compute_price_rule_multi(product, quantity, **kwargs)[product.id].items()}
            */
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_pricelist.py) ---
            // def unlink(self):
            // res = super().unlink()
            // self and self.env.registry.clear_cache()
            // return res
            */
            return await base.UnlinkAsync(ids);
        }

        protected async Task<ProductPricelist> UnlinkExceptUsedAsRuleBaseInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_pricelist.py) ---
            // def _unlink_except_used_as_rule_base(self):
            // linked_items = self.env['product.pricelist.item'].sudo().search([
            //     ('base', '=', 'pricelist'),
            //     ('base_pricelist_id', 'in', self.ids),
            //     ('pricelist_id', 'not in', self.ids),
            // ])
            // if linked_items:
            //     raise UserError(_(
            //         'You cannot delete pricelist(s):\n(%(pricelists)s)\nThey are used within pricelist(s):\n%(other_pricelists)s',
            //         pricelists='\n'.join(linked_items.base_pricelist_id.mapped('display_name')),
            //         other_pricelists='\n'.join(linked_items.pricelist_id.mapped('display_name')),
            //     ))
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, ProductPricelist entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_pricelist.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // 
            // # Make sure that there is no multi-company issue in the existing rules after the company
            // # change.
            // if 'company_id' in vals and len(self) == 1:
            //     self.item_ids._check_company()
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_pricelist.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // self and self.env.registry.clear_cache()
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}