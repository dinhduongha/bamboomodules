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
    [Module("Account", Depends = new[] { "base_setup", "onboarding", "product", "analytic", "portal", "digest" })]
    public class AccountFiscalPositionAppService : GenericApplicationService<AccountFiscalPosition>, IAccountFiscalPositionAppService
    {
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public AccountFiscalPositionAppService(IRepository<AccountFiscalPosition, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public async Task<AccountFiscalPosition> AdjustValsCountryIdAsync(Guid id, AccountFiscalPositionAdjustValsCountryIdRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: account_fiscal_position.py) ---
            // def adjust_vals_country_id(self, vals):
            // foreign_vat = vals.get('foreign_vat')
            // country_group_id = vals.get('country_group_id')
            // if foreign_vat and country_group_id and not (self.country_id or vals.get('country_id')):
            //     vals['country_id'] = self.env['res.country.group'].browse(country_group_id).country_ids.filtered(lambda c: c.code == foreign_vat[:2].upper()).id or False
            // return vals
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountFiscalPosition> CheckZipInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _check_zip(self):
            // for position in self:
            //     if bool(position.zip_from) != bool(position.zip_to) or position.zip_from > position.zip_to:
            //         raise ValidationError(_('Invalid "Zip Range", You have to configure both "From" and "To" values for the zip range and "To" should be greater than "From".'))
            */
            return default;
        }

        protected async Task<AccountFiscalPosition> ComputeAccountMapInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _compute_account_map(self):
            // for position in self:
            //     position.account_map = {al.account_src_id.id: al.account_dest_id.id for al in position.account_ids}
            */
            return default;
        }

        protected async Task<AccountFiscalPosition> ComputeForeignVatHeaderModeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _compute_foreign_vat_header_mode(self):
            // for fiscal_position in self:
            //     if (
            //             not fiscal_position.foreign_vat
            //             or not fiscal_position.country_id
            //             or self.env['account.tax'].search([('country_id', '=', fiscal_position.country_id.id)], limit=1)
            //     ):
            //         fiscal_position.foreign_vat_header_mode = False
            //     else:
            //         template_code = self.env['account.chart.template']._guess_chart_template(fiscal_position.country_id)
            //         template = self.env['account.chart.template']._get_chart_template_mapping()[template_code]
            //         # 'no_template' kept for compatibility in stable. To remove in master
            //         fiscal_position.foreign_vat_header_mode = 'templates_found' if template['installed'] else 'no_template'
            */
            return default;
        }

        protected async Task<AccountFiscalPosition> ComputeStatesCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _compute_states_count(self):
            // for position in self:
            //     position.states_count = len(position.country_id.state_ids)
            */
            return default;
        }

        protected async Task<AccountFiscalPosition> ComputeTaxMapInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _compute_tax_map(self):
            // for position in self:
            //     tax_map = defaultdict(list)
            //     for tl in position.tax_ids:
            //         if tl.tax_dest_id:
            //             tax_map[tl.tax_src_id.id].append(tl.tax_dest_id.id)
            //         else:
            //             tax_map[tl.tax_src_id.id]  # map to an empty list
            //     position.tax_map = dict(tax_map)
            */
            return default;
        }

        protected async Task<AccountFiscalPosition> ConvertZipValuesInternalAsync(object zip_from, object zip_to)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _convert_zip_values(self, zip_from='', zip_to=''):
            // if zip_from and zip_to:
            //     max_length = max(len(zip_from), len(zip_to))
            //     if zip_from.isdigit():
            //         zip_from = zip_from.rjust(max_length, '0')
            //     if zip_to.isdigit():
            //         zip_to = zip_to.rjust(max_length, '0')
            // return zip_from, zip_to
            */
            return default;
        }

        public override async Task<AccountFiscalPosition> CreateAsync(AccountFiscalPosition entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     zip_from = vals.get('zip_from')
            //     zip_to = vals.get('zip_to')
            //     if zip_from and zip_to:
            //         vals['zip_from'], vals['zip_to'] = self._convert_zip_values(zip_from, zip_to)
            // return super().create(vals_list)
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: account_fiscal_position.py) ---
            // def create(self, vals_list):
            // new_vals = []
            // for vals in vals_list:
            //     new_vals.append(self.adjust_vals_country_id(vals))
            // return super().create(new_vals)
            */
            return await base.CreateAsync(entity, fields);
        }

        public async Task<AccountFiscalPosition> CreateForeignTaxesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def action_create_foreign_taxes(self):
            // self.ensure_one()
            // template_code = self.env['account.chart.template']._guess_chart_template(self.country_id)
            // template = self.env['account.chart.template']._get_chart_template_mapping()[template_code]
            // if not template['installed']:
            //     localization_module = self.env['ir.module.module'].search([('name', '=', template['module'])])
            //     localization_module.sudo().button_immediate_install()
            // self.env["account.chart.template"]._instantiate_foreign_taxes(self.country_id, self.company_id)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountFiscalPosition> GetFiscalPositionInternalAsync(object partner, object delivery)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _get_fiscal_position(self, partner, delivery=None):
            // """
            // :return: fiscal position found (recordset)
            // :rtype: :class:`account.fiscal.position`
            // """
            // if not partner:
            //     return self.env['account.fiscal.position']
            // 
            // company = self.env.company
            // intra_eu = vat_exclusion = False
            // if company.vat and partner.vat:
            //     eu_country_codes = set(self.env.ref('base.europe').country_ids.mapped('code'))
            //     intra_eu = company.vat[:2] in eu_country_codes and partner.vat[:2] in eu_country_codes
            //     vat_exclusion = company.vat[:2] == partner.vat[:2]
            // 
            // # If company and partner have the same vat prefix (and are both within the EU), use invoicing
            // if not delivery or (intra_eu and vat_exclusion):
            //     delivery = partner
            // 
            // # partner manually set fiscal position always win
            // manual_fiscal_position = (
            //     delivery.with_company(company).property_account_position_id
            //     or partner.with_company(company).property_account_position_id
            // )
            // if manual_fiscal_position:
            //     return manual_fiscal_position
            // 
            // if not partner.country_id:
            //     return self.env['account.fiscal.position']
            // 
            // # Search for a auto applied fiscal position matching the partner
            // ranking_subfunctions = self._get_fpos_ranking_functions(delivery)
            // def ranking_function(fpos):
            //     return tuple(rank[1](fpos) for rank in ranking_subfunctions)
            // 
            // all_auto_apply_fpos = self.search(self._check_company_domain(self.env.company) + [('auto_apply', '=', True)])
            // fpo_with_ranking = ((fpos, ranking_function(fpos)) for fpos in all_auto_apply_fpos)
            // valid_auto_apply_fpos = filter(lambda x: all(x[1]), fpo_with_ranking)
            // return max(
            //     valid_auto_apply_fpos,
            //     key=lambda x: x[1],
            //     default=(self.env['account.fiscal.position'], False)
            // )[0]
            */
            return default;
        }

        protected async Task<AccountFiscalPosition> GetFposRankingFunctionsInternalAsync(object partner)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _get_fpos_ranking_functions(self, partner):
            // """Get comparison functions to rank fiscal positions.
            // 
            // All functions are applied to the fiscal position and return a value.
            // These values are taken in order to build a tuple that will be the comparator
            // value between fiscal positions.
            // 
            // If the value returned by one of the function is falsy, the fiscal position is
            // filtered out and not even considered for the ranking.
            // 
            // :param partner: the partner to consider for the ranking of the fiscal positions
            // :type partner: :class:`res.partner`
            // :return: a list of tuples with a name and the function to apply. The name is only
            //     used to facilitate extending the comparators.
            // :rtype: list[tuple[str, function]
            // """
            // return [
            //     ('vat_required', lambda fpos: (
            //         not fpos.vat_required
            //         or (self._get_vat_valid(partner, self.env.company) and 2)
            //     )),
            //     ('company_id', lambda fpos: len(fpos.company_id.parent_ids)),
            //     ('zipcode', lambda fpos:(
            //         not (fpos.zip_from and fpos.zip_to)
            //         or (partner.zip and (fpos.zip_from <= partner.zip <= fpos.zip_to) and 2)
            //     )),
            //     ('state_id', lambda fpos: (
            //         not fpos.state_ids
            //         or (partner.state_id in fpos.state_ids and 2)
            //     )),
            //     ('country_id', lambda fpos: (
            //         not fpos.country_id
            //         or (partner.country_id == fpos.country_id and 2)
            //     )),
            //     ('country_group', lambda fpos: (
            //         not fpos.country_group_id
            //         or (partner.country_id in fpos.country_group_id.country_ids and 2)
            //     )),
            //     ('sequence', lambda fpos: -(fpos.sequence or 0.1)),  # do not filter out sequence=0, priority to lowest sequence in `max` method
            // ]
            */
            return default;
        }

        protected async Task<AccountFiscalPosition> GetVatValidInternalAsync(object delivery, object company)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _get_vat_valid(self, delivery, company=None):
            // """ Hook for determining VAT validity with more complex VAT requirements """
            // return bool(delivery.vat)
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: account_fiscal_position.py) ---
            // def _get_vat_valid(self, delivery, company=None):
            // eu_countries = self.env.ref('base.europe').country_ids
            // 
            // # If VIES validation does not apply to this partner (e.g. they
            // # are in the same country as the partner), then skip.
            // if not (company and delivery.with_company(company).perform_vies_validation):
            //     return super()._get_vat_valid(delivery, company)
            // 
            // # If the company has a fiscal position with a foreign vat in Europe, in the same country as the partner, then the VIES validity applies
            // if self.search_count([
            //         *self._check_company_domain(company),
            //         ('foreign_vat', '!=', False),
            //         ('country_id', '=', delivery.country_id.id),
            // ]) or company.country_id in eu_countries:
            //     return super()._get_vat_valid(delivery, company) and delivery.vies_valid
            // 
            // return super()._get_vat_valid(delivery, company)
            */
            return default;
        }

        protected async Task<AccountFiscalPosition> InverseForeignVatInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _inverse_foreign_vat(self):
            // # Hook for extension
            // pass
            */
            return default;
        }

        protected async Task<AccountFiscalPosition> LoadPosDataDomainInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: account_fiscal_position.py) ---
            // def _load_pos_data_domain(self, data):
            // return [('id', 'in', data['pos.config']['data'][0]['fiscal_position_ids'])]
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: account_fiscal_position.py) ---
            // def _load_pos_data_domain(self, data):
            // params = super()._load_pos_data_domain(data)
            // params = OR([params, [('id', '=', data['pos.config']['data'][0]['takeaway_fp_id'])]])
            // return params
            */
            return default;
        }

        protected async Task<AccountFiscalPosition> LoadPosDataFieldsInternalAsync(Guid config_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: account_fiscal_position.py) ---
            // def _load_pos_data_fields(self, config_id):
            // return ['id', 'name', 'display_name', 'tax_map']
            */
            return default;
        }

        protected async Task<AccountFiscalPosition> LoadPosSelfDataInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: account_fiscal_position.py) ---
            // def _load_pos_self_data(self, data):
            // return self._load_pos_data(data)
            */
            return default;
        }

        public async Task<AccountFiscalPosition> MapAccountAsync(Guid id, AccountFiscalPositionMapAccountRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def map_account(self, account):
            // return self.env['account.account'].browse((self.account_map or {}).get(account.id, account.id))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountFiscalPosition> MapTaxAsync(Guid id, AccountFiscalPositionMapTaxRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def map_tax(self, taxes):
            // return self.env['account.tax'].browse(unique(
            //     tax_id
            //     for tax in taxes
            //     for tax_id in (self.tax_map or {}).get(tax.id, [tax.id])
            // ))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountFiscalPosition> OnchangeCountryGroupIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _onchange_country_group_id(self):
            // if self.country_group_id:
            //     self.zip_from = self.zip_to = False
            //     self.state_ids = [(5,)]
            */
            return default;
        }

        protected async Task<AccountFiscalPosition> OnchangeCountryIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _onchange_country_id(self):
            // if self.country_id:
            //     self.zip_from = self.zip_to = False
            //     self.state_ids = [(5,)]
            //     self.states_count = len(self.country_id.state_ids)
            */
            return default;
        }

        public async Task<AccountFiscalPosition> RaiseVatErrorMessageAsync(Guid id, AccountFiscalPositionRaiseVatErrorMessageRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: account_fiscal_position.py) ---
            // def raise_vat_error_message(self, country=False):
            // fp_label = _("fiscal position [%s]", self.name)
            // country_code = country.code.lower() if country else self.country_id.code.lower()
            // error_message = self.env['res.partner']._build_vat_error_message(country_code, self.foreign_vat, fp_label)
            // raise ValidationError(error_message)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountFiscalPosition> ValidateForeignVatCountryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _validate_foreign_vat_country(self):
            // for record in self:
            //     if record.foreign_vat:
            //         if record.country_id == record.company_id.account_fiscal_country_id:
            //             if not record.state_ids:
            //                 if record.company_id.account_fiscal_country_id.state_ids:
            //                     raise ValidationError(_("You cannot create a fiscal position with a foreign VAT within your fiscal country without assigning it a state."))
            //         if record.country_group_id and record.country_id:
            //             if record.country_id not in record.country_group_id.country_ids:
            //                 raise ValidationError(_("You cannot create a fiscal position with a country outside of the selected country group."))
            // 
            //         similar_fpos_domain = [
            //             *self.env['account.fiscal.position']._check_company_domain(record.company_id),
            //             ('foreign_vat', '!=', False),
            //             ('id', '!=', record.id),
            //         ]
            // 
            //         if record.country_group_id:
            //             foreign_vat_country = self.country_group_id.country_ids.filtered(lambda c: c.code == record.foreign_vat[:2].upper())
            //             if not foreign_vat_country:
            //                 raise ValidationError(_("The country code of the foreign VAT number does not match any country in the group."))
            //             similar_fpos_domain += [('country_group_id', '=', record.country_group_id.id), ('country_id', '=', foreign_vat_country.id)]
            //         elif record.country_id:
            //             similar_fpos_domain += [('country_id', '=', record.country_id.id), ('country_group_id', '=', False)]
            // 
            //         if record.state_ids:
            //             similar_fpos_domain.append(('state_ids', 'in', record.state_ids.ids))
            //         else:
            //             similar_fpos_domain.append(('state_ids', '=', False))
            // 
            //         similar_fpos_count = self.env['account.fiscal.position'].search_count(similar_fpos_domain)
            //         if similar_fpos_count:
            //             raise ValidationError(_("A fiscal position with a foreign VAT already exists in this region."))
            */
            return default;
        }

        protected async Task<AccountFiscalPosition> ValidateForeignVatInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: account_fiscal_position.py) ---
            // def _validate_foreign_vat(self):
            // for record in self:
            //     if not record.foreign_vat:
            //         continue
            // 
            //     if record.country_group_id:
            //         # Checks the foreign vat is a VAT Number linked to a country of the country group
            //         foreign_vat_country = self.country_group_id.country_ids.filtered(lambda c: c.code == record.foreign_vat[:2].upper())
            //         if not foreign_vat_country:
            //             raise ValidationError(_("The country detected for this foreign VAT number does not match any of the countries composing the country group set on this fiscal position."))
            //         if record.country_id:
            //             checked_country_code = self.env['res.partner']._run_vat_test(record.foreign_vat, record.country_id) or self.env['res.partner']._run_vat_test(record.foreign_vat, foreign_vat_country)
            //             if not checked_country_code:
            //                 record.raise_vat_error_message(foreign_vat_country)
            //         else:
            //             checked_country_code = self.env['res.partner']._run_vat_test(record.foreign_vat, foreign_vat_country)
            //             if not checked_country_code:
            //                 record.raise_vat_error_message(record.country_id)
            //     elif record.country_id:
            //         foreign_vat_country = self.env['res.country'].search([('code', '=', record.foreign_vat[:2].upper())], limit=1)
            //         checked_country_code = self.env['res.partner']._run_vat_test(record.foreign_vat, foreign_vat_country or record.country_id)
            //         if not checked_country_code:
            //             record.raise_vat_error_message()
            // 
            //     if record.foreign_vat and not record.country_id and not record.country_group_id:
            //         raise ValidationError(_("The country of the foreign VAT number could not be detected. Please assign a country to the fiscal position or set a country group"))
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, AccountFiscalPosition entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def write(self, vals):
            // zip_from = vals.get('zip_from')
            // zip_to = vals.get('zip_to')
            // if zip_from or zip_to:
            //     for rec in self:
            //         vals['zip_from'], vals['zip_to'] = self._convert_zip_values(zip_from or rec.zip_from, zip_to or rec.zip_to)
            // return super(AccountFiscalPosition, self).write(vals)
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: account_fiscal_position.py) ---
            // def write(self, vals):
            // vals = self.adjust_vals_country_id(vals)
            // return super().write(vals)
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}