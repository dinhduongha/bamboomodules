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
    [Module("Account", Category = "Accounting", Depends = new[] { "base_setup", "onboarding", "product", "analytic", "portal", "digest" })]
    public partial class AccountFiscalPositionAppService : GenericApplicationService<AccountFiscalPosition>, IAccountFiscalPositionAppService
    {
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public AccountFiscalPositionAppService(IRepository<AccountFiscalPosition, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public async Task<AccountFiscalPosition> ArchiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: account_fiscal_position.py) ---
            // def action_archive(self):
            // configs = self.env['pos.config'].search([('default_fiscal_position_id', 'in', self.ids)])
            // configs.default_fiscal_position_id = False
            // return super().action_archive()
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

        protected async Task<AccountFiscalPosition> ComputeIsDomesticInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _compute_is_domestic(self):
            // for position in self:
            //     position.is_domestic = position == position.company_id.domestic_fiscal_position_id
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
            //     for dest_tax in position.tax_ids:
            //         for src_tax in dest_tax.original_tax_ids:
            //             tax_map[src_tax.id].append(dest_tax.id)
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
            // created_records = self.env["account.chart.template"]._instantiate_foreign_taxes(self.country_id, self.company_id)
            // created_records.get('account.tax', self.env['account.tax']).fiscal_position_ids += self
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountFiscalPosition> GetFirstMatchingFposInternalAsync(object partner)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _get_first_matching_fpos(self, partner):
            // sorted_fpos = self.sorted(key=lambda f: (-len(f.company_id.parent_ids), f.sequence))  # company specific first, then sequence
            // for fpos in sorted_fpos:
            //     if all(fn(fpos) for fn in self._get_fpos_validation_functions(partner)):
            //         return fpos
            // return self.env['account.fiscal.position']
            */
            return default;
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
            // all_auto_apply_fpos = self.search(self._check_company_domain(self.env.company) + [('auto_apply', '=', True)])
            // 
            // return all_auto_apply_fpos._get_first_matching_fpos(delivery)
            */
            return default;
        }

        protected async Task<AccountFiscalPosition> GetFposValidationFunctionsInternalAsync(object partner)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _get_fpos_validation_functions(self, partner):
            // """ Returns a list of functions to validate fiscal positions against a partner.
            // """
            // return [
            //     # vat required
            //     lambda fpos: (
            //         not fpos.vat_required or partner._get_vat_required_valid(company=self.env.company)
            //     ),
            //     # zip code
            //     lambda fpos:(
            //         not (fpos.zip_from and fpos.zip_to)
            //         or (partner.zip and (fpos.zip_from <= partner.zip <= fpos.zip_to))
            //     ),
            //     # state
            //     lambda fpos: (
            //         not fpos.state_ids
            //         or (partner.state_id in fpos.state_ids)
            //     ),
            //     # country
            //     lambda fpos: (
            //         not fpos.country_id
            //         or (partner.country_id == fpos.country_id)
            //     ),
            //     # country group
            //     lambda fpos: (
            //         not fpos.country_group_id
            //         or (partner.country_id in fpos.country_group_id.country_ids and
            //             (not partner.state_id or partner.state_id not in fpos.country_group_id.exclude_state_ids))
            //     ),
            // ]
            */
            return default;
        }

        protected async Task<AccountFiscalPosition> InverseForeignVatInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _inverse_foreign_vat(self):
            // for record in self:
            //     if not record.foreign_vat:
            //         continue
            // 
            //     if record.country_id:
            //         fp_label = _("fiscal position [%s]", record.name)
            //         record.foreign_vat, _country_code = self.env['res.partner']._run_vat_checks(record.country_id, record.foreign_vat, partner_name=fp_label)
            */
            return default;
        }

        protected async Task<AccountFiscalPosition> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: account_fiscal_position.py) ---
            // def _load_pos_data_domain(self, data, config):
            // fp_ids = [preset['fiscal_position_id'] for preset in data['pos.preset']]
            // partner_fp_ids = list({partner['fiscal_position_id'] for partner in data['res.partner'] if partner['fiscal_position_id']}) if 'res.partner' in data.keys() else []
            // return [('id', 'in', config.fiscal_position_ids.ids + fp_ids + partner_fp_ids)]
            */
            return default;
        }

        protected async Task<AccountFiscalPosition> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: account_fiscal_position.py) ---
            // def _load_pos_data_fields(self, config):
            // return ['id', 'name', 'display_name', 'tax_map', 'tax_ids']
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
            // if not self:
            //     return taxes
            // if not self.tax_ids:  # empty fiscal positions (like those created by tax units) remove all taxes
            //     return self.env['account.tax']
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

        protected async Task<AccountFiscalPosition> OnchangeForeignVatInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _onchange_foreign_vat(self):
            // self.foreign_vat, _country_code = self.env['res.partner']._run_vat_checks(self.country_id, self.foreign_vat, validation=False)
            */
            return default;
        }

        public async Task<AccountFiscalPosition> OpenRelatedTaxesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def action_open_related_taxes(self):
            // return self.tax_ids._get_records_action(name=_("%s taxes", self.display_name))
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
            //         if not record.country_id:
            //             raise ValidationError(_("The country of the foreign VAT number could not be detected. Please assign a country to the fiscal position."))
            //         if record.country_id == record.company_id.account_fiscal_country_id:
            //             if not record.state_ids:
            //                 if record.company_id.account_fiscal_country_id.state_ids:
            //                     raise ValidationError(_("You cannot create a fiscal position with a foreign VAT within your fiscal country without assigning it a state."))
            //         if record.country_group_id and record.country_id:
            //             if record.country_id not in record.country_group_id.country_ids:
            //                 raise ValidationError(_("You cannot create a fiscal position with a country outside of the selected country group."))
            // 
            //         similar_fpos_count = self.env['account.fiscal.position'].search_count([
            //             *self.env['account.fiscal.position']._check_company_domain(record.company_id),
            //             ('foreign_vat', 'not in', (False, record.foreign_vat)),
            //             ('id', '!=', record.id),
            //             ('country_id', '=', record.country_id.id),
            //         ])
            //         if similar_fpos_count:
            //             raise ValidationError(_("A fiscal position with a foreign VAT already exists in this country."))
            */
            return default;
        }
    }
}