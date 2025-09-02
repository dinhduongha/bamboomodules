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
    [Module("BaseModule")]
    public class ResCurrencyRateAppService : GenericApplicationService<ResCurrencyRate>, IResCurrencyRateAppService
    {

        public ResCurrencyRateAppService(IRepository<ResCurrencyRate, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<ResCurrencyRate> CheckCompanyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def _check_company_id(self):
            // for rate in self:
            //     if rate.company_id.sudo().parent_id:
            //         raise ValidationError("Currency rates should only be created for main companies")
            */
            return default;
        }

        protected async Task<ResCurrencyRate> ComputeCompanyRateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def _compute_company_rate(self):
            // last_rate = self.env['res.currency.rate']._get_last_rates_for_companies(self.company_id | self.env.company.root_id)
            // for currency_rate in self:
            //     company = currency_rate.company_id or self.env.company.root_id
            //     currency_rate.company_rate = (currency_rate.rate or currency_rate._get_latest_rate().rate or 1.0) / last_rate[company]
            */
            return default;
        }

        protected async Task<ResCurrencyRate> ComputeInverseCompanyRateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def _compute_inverse_company_rate(self):
            // for currency_rate in self:
            //     if not currency_rate.company_rate:
            //         currency_rate.company_rate = 1.0
            //     currency_rate.inverse_company_rate = 1.0 / currency_rate.company_rate
            */
            return default;
        }

        protected async Task<ResCurrencyRate> ComputeRateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def _compute_rate(self):
            // for currency_rate in self:
            //     currency_rate.rate = currency_rate.rate or currency_rate._get_latest_rate().rate or 1.0
            */
            return default;
        }

        protected async Task<ResCurrencyRate> GetLastRatesForCompaniesInternalAsync(object companies)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def _get_last_rates_for_companies(self, companies):
            // return {
            //     company: company.sudo().currency_id.rate_ids.filtered(lambda x: (
            //         x.rate
            //         and x.company_id == company or not x.company_id
            //     )).sorted('name')[-1:].rate or 1
            //     for company in companies
            // }
            */
            return default;
        }

        protected async Task<ResCurrencyRate> GetLatestRateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def _get_latest_rate(self):
            // # Make sure 'name' is defined when creating a new rate.
            // if not self.name:
            //     raise UserError(_("The name for the current rate is empty.\nPlease set it."))
            // return self.currency_id.rate_ids.sudo().filtered(lambda x: (
            //     x.rate
            //     and x.company_id == (self.company_id or self.env.company.root_id)
            //     and x.name < (self.name or fields.Date.today())
            // )).sorted('name')[-1:]
            */
            return default;
        }

        protected async Task<ResCurrencyRate> GetRateForSpreadsheetInternalAsync(object currency_from_code, object currency_to_code, object date, Guid company_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet, FILE: res_currency_rate.py) ---
            // def _get_rate_for_spreadsheet(self, currency_from_code, currency_to_code, date=None, company_id=None):
            // if not currency_from_code or not currency_to_code:
            //     return False
            // Currency = self.env["res.currency"].with_context({"active_test": False})
            // currency_from = Currency.search([("name", "=", currency_from_code)])
            // currency_to = Currency.search([("name", "=", currency_to_code)])
            // if not currency_from or not currency_to:
            //     return False
            // company = self.env["res.company"].browse(company_id) if company_id else self.env.company
            // date = fields.Date.from_string(date) if date else fields.Date.context_today(self)
            // return Currency._get_conversion_rate(currency_from, currency_to, company, date)
            */
            return default;
        }

        public async Task<ResCurrencyRate> GetRatesForSpreadsheetAsync(Guid id, ResCurrencyRateGetRatesForSpreadsheetRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet, FILE: res_currency_rate.py) ---
            // def get_rates_for_spreadsheet(self, requests):
            // result = []
            // for request in requests:
            //     record = request.copy()
            //     record.update(
            //         {
            //             "rate": self._get_rate_for_spreadsheet(
            //                 request["from"],
            //                 request["to"],
            //                 request.get("date"),
            //                 request.get("company_id"),
            //             ),
            //         }
            //     )
            //     result.append(record)
            // return result
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResCurrencyRate> GetViewCacheKeyInternalAsync(Guid view_id, object view_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def _get_view_cache_key(self, view_id=None, view_type='form', **options):
            // """The override of _get_view changing the rate field labels according to the company currency
            // makes the view cache dependent on the company currency"""
            // key = super()._get_view_cache_key(view_id, view_type, **options)
            // return key + ((self.env['res.company'].browse(self._context.get('company_id')) or self.env.company).currency_id.name,)
            */
            return default;
        }

        protected async Task<ResCurrencyRate> GetViewInternalAsync(Guid view_id, object view_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def _get_view(self, view_id=None, view_type='form', **options):
            // arch, view = super()._get_view(view_id, view_type, **options)
            // if view_type == 'list':
            //     names = {
            //         'company_currency_name': (self.env['res.company'].browse(self._context.get('company_id')) or self.env.company).currency_id.name,
            //         'rate_currency_name': self.env['res.currency'].browse(self._context.get('active_id')).name or 'Unit',
            //     }
            //     for name, label in [['company_rate', _('%(rate_currency_name)s per %(company_currency_name)s', **names)],
            //                         ['inverse_company_rate', _('%(company_currency_name)s per %(rate_currency_name)s', **names)]]:
            // 
            //         if (node := arch.find(f"./field[@name='{name}']")) is not None:
            //             node.set('string', label)
            // return arch, view
            */
            return default;
        }

        protected async Task<ResCurrencyRate> InverseCompanyRateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def _inverse_company_rate(self):
            // last_rate = self.env['res.currency.rate']._get_last_rates_for_companies(self.company_id | self.env.company.root_id)
            // for currency_rate in self:
            //     company = currency_rate.company_id or self.env.company.root_id
            //     currency_rate.rate = currency_rate.company_rate * last_rate[company]
            */
            return default;
        }

        protected async Task<ResCurrencyRate> InverseInverseCompanyRateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def _inverse_inverse_company_rate(self):
            // for currency_rate in self:
            //     if not currency_rate.inverse_company_rate:
            //         currency_rate.inverse_company_rate = 1.0
            //     currency_rate.company_rate = 1.0 / currency_rate.inverse_company_rate
            */
            return default;
        }

        protected async Task<ResCurrencyRate> OnchangeRateWarningInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def _onchange_rate_warning(self):
            // latest_rate = self._get_latest_rate()
            // if latest_rate:
            //     diff = (latest_rate.rate - self.rate) / latest_rate.rate
            //     if abs(diff) > 0.2:
            //         return {
            //             'warning': {
            //                 'title': _("Warning for %s", self.currency_id.name),
            //                 'message': _(
            //                     "The new rate is quite far from the previous rate.\n"
            //                     "Incorrect currency rates may cause critical problems, make sure the rate is correct!"
            //                 )
            //             }
            //         }
            */
            return default;
        }

        protected async Task<ResCurrencyRate> SanitizeValsInternalAsync(object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def _sanitize_vals(self, vals):
            // if 'inverse_company_rate' in vals and ('company_rate' in vals or 'rate' in vals):
            //     del vals['inverse_company_rate']
            // if 'company_rate' in vals and 'rate' in vals:
            //     del vals['company_rate']
            // return vals
            */
            return default;
        }

        protected async Task<ResCurrencyRate> SearchDisplayNameInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def _search_display_name(self, operator, value):
            // value = parse_date(self.env, value)
            // return super()._search_display_name(operator, value)
            */
            return default;
        }
    }
}