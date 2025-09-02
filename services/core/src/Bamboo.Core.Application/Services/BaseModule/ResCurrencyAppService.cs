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
    public class ResCurrencyAppService : GenericApplicationService<ResCurrency>, IResCurrencyAppService
    {
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public ResCurrencyAppService(IRepository<ResCurrency, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        protected async Task<ResCurrency> ActivateGroupMultiCurrencyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: res_currency.py) ---
            // def _activate_group_multi_currency(self):
            // # for Sale/ POS - Multi currency flows require pricelists
            // super()._activate_group_multi_currency()
            // if not self.env.user.has_group('product.group_product_pricelist'):
            //     group_user = self.env.ref('base.group_user').sudo()
            //     group_user._apply_group(self.env.ref('product.group_product_pricelist'))
            //     self.env['res.company']._activate_or_create_pricelists()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def _activate_group_multi_currency(self):
            // group_user = self.env.ref('base.group_user', raise_if_not_found=False)
            // group_mc = self.env.ref('base.group_multi_currency', raise_if_not_found=False)
            // if group_user and group_mc:
            //     group_user.sudo()._apply_group(group_mc)
            */
            return default;
        }

        public async Task<ResCurrency> AmountToTextAsync(Guid id, ResCurrencyAmountToTextRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def amount_to_text(self, amount):
            // self.ensure_one()
            // def _num2words(number, lang):
            //     try:
            //         return num2words(number, lang=lang).title()
            //     except NotImplementedError:
            //         return num2words(number, lang='en').title()
            // 
            // if num2words is None:
            //     logging.getLogger(__name__).warning("The library 'num2words' is missing, cannot render textual amounts.")
            //     return ""
            // 
            // integral, _sep, fractional = f"{amount:.{self.decimal_places}f}".partition('.')
            // integer_value = int(integral)
            // lang = tools.get_lang(self.env)
            // if self.is_zero(amount - integer_value):
            //     return _(
            //         '%(integral_amount)s %(currency_unit)s',
            //         integral_amount=_num2words(integer_value, lang=lang.iso_code),
            //         currency_unit=self.currency_unit_label,
            //     )
            // else:
            //     return _(
            //         '%(integral_amount)s %(currency_unit)s and %(fractional_amount)s %(currency_subunit)s',
            //         integral_amount=_num2words(integer_value, lang=lang.iso_code),
            //         currency_unit=self.currency_unit_label,
            //         fractional_amount=_num2words(int(fractional or 0), lang=lang.iso_code),
            //         currency_subunit=self.currency_subunit_label,
            //     )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResCurrency> CheckCompanyCurrencyStaysActiveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def _check_company_currency_stays_active(self):
            // if self._context.get('install_mode') or self._context.get('force_deactivate'):
            //     # install_mode : At install, when this check is run, the "active" field of a currency added to a company will
            //     #                still be evaluated as False, despite it's automatically set at True when added to the company.
            //     # force_deactivate : Allows deactivation of a currency in tests to enable non multi_currency behaviors
            //     return
            // 
            // currencies = self.filtered(lambda c: not c.active)
            // if self.env['res.company'].search_count([('currency_id', 'in', currencies.ids)], limit=1):
            //     raise UserError(_("This currency is set on a company and therefore cannot be deactivated."))
            */
            return default;
        }

        protected async Task<ResCurrency> CheckCurrencyTableMonocurrencyInternalAsync(object companies)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_currency.py) ---
            // def _check_currency_table_monocurrency(self, companies):
            // """ Returns whether displaying the data of the provided companies can be done with a monocurrency currency table.
            // If it can, calling _get_monocurrency_currency_table_sql is enough to join the currency table (which actually consists of a bunch of VALUES
            // directly injected in the join).
            // Else, a full-flegdge temporary table will be needed, that will have to be generated by a call to _create_currency_table.
            // """
            // return len(companies.currency_id) == 1
            */
            return default;
        }

        public async Task<ResCurrency> CompareAmountsAsync(Guid id, ResCurrencyCompareAmountsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def compare_amounts(self, amount1, amount2):
            // """Compare ``amount1`` and ``amount2`` after rounding them according to the
            //    given currency's precision..
            //    An amount is considered lower/greater than another amount if their rounded
            //    value is different. This is not the same as having a non-zero difference!
            // 
            //    For example 1.432 and 1.431 are equal at 2 digits precision,
            //    so this method would return 0.
            //    However 0.006 and 0.002 are considered different (returns 1) because
            //    they respectively round to 0.01 and 0.0, even though
            //    0.006-0.002 = 0.004 which would be considered zero at 2 digits precision.
            // 
            //    :param float amount1: first amount to compare
            //    :param float amount2: second amount to compare
            //    :return: (resp.) -1, 0 or 1, if ``amount1`` is (resp.) lower than,
            //             equal to, or greater than ``amount2``, according to
            //             ``currency``'s rounding.
            // 
            //    With the new API, call it like: ``currency.compare_amounts(amount1, amount2)``.
            // """
            // self.ensure_one()
            // return tools.float_compare(amount1, amount2, precision_rounding=self.rounding)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResCurrency> ComputeCurrentRateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def _compute_current_rate(self):
            // date = self._context.get('date') or fields.Date.context_today(self)
            // company = self.env['res.company'].browse(self._context.get('company_id')) or self.env.company
            // to_currency = self.browse(self.env.context.get('to_currency')) or company.currency_id
            // # the subquery selects the last rate before 'date' for the given currency/company
            // currency_rates = (self + to_currency)._get_rates(self.env.company, date)
            // for currency in self:
            //     currency.rate = (currency_rates.get(currency.id) or 1.0) / currency_rates.get(to_currency.id)
            //     currency.inverse_rate = 1 / currency.rate
            //     if currency != company.currency_id:
            //         currency.rate_string = '1 %s = %.6f %s' % (to_currency.name, currency.rate, currency.name)
            //     else:
            //         currency.rate_string = ''
            */
            return default;
        }

        protected async Task<ResCurrency> ComputeDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def _compute_date(self):
            // for currency in self:
            //     currency.date = currency.rate_ids[:1].name
            */
            return default;
        }

        protected async Task<ResCurrency> ComputeDecimalPlacesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def _compute_decimal_places(self):
            // for currency in self:
            //     if 0 < currency.rounding < 1:
            //         currency.decimal_places = int(math.ceil(math.log10(1/currency.rounding)))
            //     else:
            //         currency.decimal_places = 0
            */
            return default;
        }

        protected async Task<ResCurrency> ComputeDisplayRoundingWarningInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_currency.py) ---
            // def _compute_display_rounding_warning(self):
            // for record in self:
            //     record.display_rounding_warning = record.id \
            //                                       and record._origin.rounding != record.rounding \
            //                                       and record._origin._has_accounting_entries()
            */
            return default;
        }

        protected async Task<ResCurrency> ComputeIsCurrentCompanyCurrencyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def _compute_is_current_company_currency(self):
            // for currency in self:
            //     currency.is_current_company_currency = self.env.company.currency_id == currency
            */
            return default;
        }

        protected async Task<ResCurrency> ConvertInternalAsync(object from_amount, object to_currency, object company, object date, object round)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def _convert(self, from_amount, to_currency, company=None, date=None, round=True):  # noqa: A002 builtin-argument-shadowing
            // """Returns the converted amount of ``from_amount``` from the currency
            //    ``self`` to the currency ``to_currency`` for the given ``date`` and
            //    company.
            // 
            //    :param company: The company from which we retrieve the convertion rate
            //    :param date: The nearest date from which we retriev the conversion rate.
            //    :param round: Round the result or not
            // """
            // self, to_currency = self or to_currency, to_currency or self
            // assert self, "convert amount from unknown currency"
            // assert to_currency, "convert amount to unknown currency"
            // # apply conversion rate
            // if from_amount:
            //     to_amount = from_amount * self._get_conversion_rate(self, to_currency, company, date)
            // else:
            //     return 0.0
            // 
            // # apply rounding
            // return to_currency.round(to_amount) if round else to_amount
            */
            return default;
        }

        protected async Task<ResCurrency> CreateCurrencyTableInternalAsync(object companies, object date_periods, object use_cta_rates)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_currency.py) ---
            // def _create_currency_table(self, companies, date_periods, use_cta_rates=False):
            // """ Creates a temporary table containing the currency rates to be used in order to aggregate amounts belonging to companies
            // with different main currencies in a reporting query.
            // These rates are computed from the res.currrency.rate objects defined for self.env.company.
            // 
            // The currency table consists of the following columns:
            //     - company_id: The id of the company whose amounts can be converted with this rate.
            //     - period_key: The key corresponding to the period this rate is valid for. (see params list)
            //     - date_from: Only set for rate_type 'historical'. The starting date for this rate.
            //     - date_next: Only set for rate_type 'historical'. The date of the next rate. So, the rate applies until one day before date_next.
            //     - rate_type: 'historical', 'current' or 'average'
            //                     - 'historical' means the rate is to be used to convert operations at the date they were made; they each
            //                        directly correspond to the res.currency.rate objects of the active company
            //                     - 'current' means this rate is the most recent rate within the period. This rate is unique per (company_id, period_key).
            //                     - 'average' means this rate is the average rate for the period. This rate is unique per (company_id, period_key).
            //     - rate: The rate to apply, as a decimal factor to apply directly to the value to convert, provided it is expressed in the
            //             main currency of the company referred to by company_id.
            // 
            // 
            // :param companies: The res.company objects to generate rates for.
            // :param date_periods: List of tuples in the form (period_key, date_from, date_to), containing each of the periods to generate rates for, where:
            //                      - period_key is a unique string identifier used to differentiate the periods
            //                      - date_from is the date the period starts at ; it can be None if the period want to consider everything from the beginning
            //                      - date_to is the date the periods ends at
            // :param use_cta_rates: Boolean parameter, enabling the computation of CTA rates. If True, 'current', 'average' and 'historical' rates will be
            //                 computed for all companies, for all periods. Else, only 'current' will be computed.
            // """
            // main_company = self.env.company
            // domestic_currency_companies = companies.filtered(lambda x: x.currency_id == main_company.currency_id)
            // other_companies = companies - domestic_currency_companies
            // 
            // table_builders = []
            // if domestic_currency_companies:
            //     table_builders += [self._get_table_builder_domestic_currency(domestic_currency_companies, use_cta_rates)]
            // 
            // last_date_to = None
            // for period_key, date_from, date_to in date_periods:
            //     main_company_unit_factor = main_company.currency_id._get_rates(main_company, date_to)[main_company.currency_id.id]
            // 
            //     if use_cta_rates:
            //         table_builders += [
            //             self._get_table_builder_closing(period_key, main_company, other_companies, date_to, main_company_unit_factor),
            //             self._get_table_builder_historical(main_company, other_companies, date_to, main_company_unit_factor, last_date_to),
            //             self._get_table_builder_average(period_key, main_company, other_companies, date_from, date_to, main_company_unit_factor),
            //         ]
            //     else:
            //         table_builders += [self._get_table_builder_current(period_key, main_company, other_companies, date_to, main_company_unit_factor)]
            // 
            //     last_date_to = date_to
            // 
            // self._cr.execute(SQL(
            //     """
            //         -- Tests may call this function multiple times within the same transaction; we then need to delete an regenerate the currency table
            //         DROP TABLE IF EXISTS account_currency_table;
            // 
            //         -- Create a temporary table
            //         CREATE TEMPORARY TABLE
            //         account_currency_table (company_id, period_key, date_from, date_next, rate_type, rate)
            //         ON COMMIT DROP
            //         AS (%(currency_table_build_query)s);
            // 
            //         -- Create a supporting index to avoid seq.scans
            //         CREATE INDEX account_currency_table_index ON account_currency_table (company_id, rate_type, date_from, date_next);
            //         -- Update statistics for correct planning
            //         ANALYZE account_currency_table;
            //     """,
            //     currency_table_build_query=SQL(" UNION ALL ").join(SQL('(%s)', builder) for builder in table_builders),
            // ))
            */
            return default;
        }

        protected async Task<ResCurrency> DeactivateGroupMultiCurrencyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def _deactivate_group_multi_currency(self):
            // group_user = self.env.ref('base.group_user', raise_if_not_found=False)
            // group_mc = self.env.ref('base.group_multi_currency', raise_if_not_found=False)
            // if group_user and group_mc:
            //     group_user.sudo()._remove_group(group_mc.sudo())
            */
            return default;
        }

        public async Task<ResCurrency> FormatAsync(Guid id, ResCurrencyFormatRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def format(self, amount):
            // """Return ``amount`` formatted according to ``self``'s rounding rules, symbols and positions.
            // 
            //    Also take care of removing the minus sign when 0.0 is negative
            // 
            //    :param float amount: the amount to round
            //    :return: formatted str
            // """
            // self.ensure_one()
            // return tools.format_amount(self.env, amount + 0.0, self)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResCurrency> GetCompanyCurrencyForSpreadsheetAsync(Guid id, ResCurrencyGetCompanyCurrencyForSpreadsheetRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet, FILE: res_currency.py) ---
            // def get_company_currency_for_spreadsheet(self, company_id=None):
            // """
            // Returns the currency structure for the currency of the company.
            // This function is meant to be called by the spreadsheet js lib,
            // hence the formatting of the result.
            // 
            // :company_id int: Id of the company
            // :return: dict of the form `{ "code": str, "symbol": str, "decimalPlaces": int, "position":str }`
            // """
            // company = self.env["res.company"].browse(company_id) if company_id else self.env.company
            // if not company.exists():
            //     return False
            // currency = company.currency_id
            // return {
            //     "code": currency.name,
            //     "symbol": currency.symbol,
            //     "decimalPlaces": currency.decimal_places,
            //     "position": currency.position,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResCurrency> GetConversionRateInternalAsync(object from_currency, object to_currency, object company, object date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def _get_conversion_rate(self, from_currency, to_currency, company=None, date=None):
            // if from_currency == to_currency:
            //     return 1
            // company = company or self.env.company
            // date = date or fields.Date.context_today(self)
            // return from_currency.with_company(company).with_context(to_currency=to_currency.id, date=str(date)).inverse_rate
            */
            return default;
        }

        protected async Task<ResCurrency> GetCurrencyTableFiscalYearBoundsInternalAsync(object main_company)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_currency.py) ---
            // def _get_currency_table_fiscal_year_bounds(self, main_company):
            // today_fiscal_year = main_company.compute_fiscalyear_dates(fields.Date.today())
            // first_rate = self.env['res.currency.rate'].search(self.env['res.currency.rate']._check_company_domain(main_company), order="name ASC", limit=1)
            // fiscal_year_bounds = []
            // if first_rate:
            //     first_rate_fiscal_year = main_company.compute_fiscalyear_dates(first_rate.name)
            //     fiscal_year_bounds = [(None, first_rate_fiscal_year['date_from'] - relativedelta(days=1))]  # Initialized to have a value for everything before the first rate
            //     for civil_year in range(first_rate_fiscal_year['date_from'].year, today_fiscal_year['date_from'].year):
            //         year_delta = relativedelta(years=civil_year - first_rate_fiscal_year['date_from'].year)
            //         fiscal_year_bounds.append((first_rate_fiscal_year['date_from'] + year_delta, first_rate_fiscal_year['date_to'] + year_delta))
            // 
            // # The current fiscal year is not closed yet, so we need to use its rates for everything after it
            // fiscal_year_bounds.append((today_fiscal_year['date_from'], None))
            // 
            // return fiscal_year_bounds
            */
            return default;
        }

        protected async Task<ResCurrency> GetFiscalCountryCodesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_currency.py) ---
            // def _get_fiscal_country_codes(self):
            // return ','.join(self.env.companies.mapped('account_fiscal_country_id.code'))
            */
            return default;
        }

        protected async Task<ResCurrency> GetMonocurrencyCurrencyTableSqlInternalAsync(object companies, object use_cta_rates)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_currency.py) ---
            // def _get_monocurrency_currency_table_sql(self, companies, use_cta_rates=False):
            // """ Returns a simplified currency table, faster to generate, for cases were all the data to convert are expressed in the same currency,
            // to be use in a JOIN. It actually just consists of a few VALUES ; no temporary table is created in this case.
            // 
            // All the rates in this currency table are equal to 1 (since everything is in the same currency). This is useful so that the queries can
            // be written exactly in the same way, joining the currency table returned by some function, for both mono and multi currency cases.
            // """
            // unit_rates = [
            //     SQL("(%(company_id)s, CAST(NULL AS VARCHAR), CAST(NULL AS DATE), CAST(NULL AS DATE), %(rate_type)s, 1)", company_id=company.id, rate_type=rate_type)
            //     for company in companies
            //     for rate_type in (('historical', 'current', 'average') if use_cta_rates else ('current',))
            // ]
            // return SQL('(VALUES %s) AS account_currency_table(company_id, period_key, date_from, date_next, rate_type, rate)', SQL(',').join(unit_rates))
            */
            return default;
        }

        protected async Task<ResCurrency> GetRatesInternalAsync(object company, object date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def _get_rates(self, company, date):
            // if not self.ids:
            //     return {}
            // currency_query = self.env['res.currency']._where_calc([
            //     ('id', 'in', self.ids),
            // ], active_test=False)
            // currency_id = self.env['res.currency']._field_to_sql(currency_query.table, 'id')
            // rate_query = self.env['res.currency.rate']._search([
            //     ('name', '<=', date),
            //     ('company_id', 'in', (False, company.root_id.id)),
            //     ('currency_id', '=', currency_id),
            // ], order='company_id.id, name DESC', limit=1)
            // rate_fallback = self.env['res.currency.rate']._search([
            //     ('company_id', 'in', (False, company.root_id.id)),
            //     ('currency_id', '=', currency_id),
            // ], order='company_id.id, name ASC', limit=1)
            // rate = self.env['res.currency.rate']._field_to_sql(rate_query.table, 'rate')
            // return dict(self.env.execute_query(currency_query.select(
            //     currency_id,
            //     SQL("COALESCE((%s), (%s), 1.0)", rate_query.select(rate), rate_fallback.select(rate))
            // )))
            */
            return default;
        }

        protected async Task<object> GetSimpleCurrencyTableInternalAsync(object companies)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_currency.py) ---
            // def _get_simple_currency_table(self, companies) -> SQL:
            // """ Helper creating the currency table and returning its definition for basic cases of Odoo reports needing to convert amounts using only the
            // current rates, in a single period.
            // """
            // if self._check_currency_table_monocurrency(companies):
            //     return self._get_monocurrency_currency_table_sql(companies)
            // 
            // self._create_currency_table(companies, [('period', None, fields.Date.today())])
            // return SQL('account_currency_table')
            */
            return default;
        }

        protected async Task<object> GetTableBuilderAverageInternalAsync(object period_key, object main_company, object other_companies, object date_from, object date_to, object main_company_unit_factor)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_currency.py) ---
            // def _get_table_builder_average(self, period_key, main_company, other_companies, date_from, date_to, main_company_unit_factor) -> SQL:
            // if not date_from:
            //     # When there is no start date, we want to compute the average rate on the current year only
            //     date_from = date_utils.start_of(fields.Date.from_string(date_to), 'year')
            // 
            // return SQL(
            //     """
            //         SELECT
            //             rate_with_days.other_company_id,
            //             %(period_key)s,
            //             CAST(NULL AS DATE),
            //             CAST(NULL AS DATE),
            //             'average',
            //             SUM(%(main_company_unit_factor)s / rate_with_days.rate * rate_with_days.number_of_days) / SUM(rate_with_days.number_of_days)
            //         FROM (
            //             SELECT
            //                 other_company.id as other_company_id,
            //                 rate.rate AS rate,
            //                 EXTRACT (
            //                     'Day' FROM COALESCE(
            //                         LEAD(rate.name, 1) OVER (PARTITION BY other_company.id, rate.currency_id ORDER BY rate.name ASC)::TIMESTAMP,
            //                         %(date_to)s::TIMESTAMP + INTERVAL '1' DAY
            //                     ) - rate.name::TIMESTAMP
            //                 ) AS number_of_days
            //             FROM res_company other_company
            //             JOIN res_currency_rate rate
            //                 ON rate.currency_id = other_company.currency_id
            //             WHERE
            //             rate.name <= %(date_to)s
            //             AND rate.name >= %(date_from)s
            //             AND other_company.id IN %(other_company_ids)s
            //             AND rate.company_id = %(main_company_id)s
            // 
            //             UNION ALL
            // 
            //             (
            //                 SELECT DISTINCT ON (other_company.id)
            //                     other_company.id as other_company_id,
            //                     COALESCE(out_period_rate.rate, 1.0) AS rate,
            //                     EXTRACT('Day' FROM COALESCE(in_period_rate.name::TIMESTAMP, %(date_to)s::TIMESTAMP + INTERVAL '1' DAY) - %(date_from)s::TIMESTAMP) AS number_of_days
            // 
            //                 FROM res_company other_company
            // 
            //                 LEFT JOIN res_currency_rate in_period_rate
            //                     ON in_period_rate.currency_id = other_company.currency_id
            //                     AND in_period_rate.name <= %(date_to)s
            //                     AND in_period_rate.name >= %(date_from)s
            //                     AND in_period_rate.company_id = %(main_company_id)s
            // 
            //                 LEFT JOIN res_currency_rate out_period_rate
            //                     ON out_period_rate.currency_id = other_company.currency_id
            //                     AND out_period_rate.company_id = %(main_company_id)s
            //                     AND out_period_rate.name < %(date_from)s
            // 
            //                 WHERE
            //                 other_company.id IN %(other_company_ids)s
            //                 ORDER BY other_company.id, in_period_rate.name ASC, out_period_rate.name DESC
            //             )
            //         ) rate_with_days
            //         GROUP BY rate_with_days.other_company_id
            //     """,
            //     period_key=period_key,
            //     main_company_id=main_company.root_id.id,
            //     other_company_ids=tuple(other_companies.ids),
            //     date_from=date_from,
            //     date_to=date_to,
            //     main_company_unit_factor=main_company_unit_factor,
            // )
            */
            return default;
        }

        protected async Task<object> GetTableBuilderClosingInternalAsync(object period_key, object main_company, object other_companies, object date_to, object main_company_unit_factor)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_currency.py) ---
            // def _get_table_builder_closing(self, period_key, main_company, other_companies, date_to, main_company_unit_factor) -> SQL:
            // fiscal_year_bounds = self._get_currency_table_fiscal_year_bounds(main_company)
            // 
            // return SQL(
            //     """
            //         SELECT DISTINCT ON (other_company.id, fiscal_year_bounds.date_from, fiscal_year_bounds.date_to)
            //             other_company.id,
            //             %(period_key)s,
            //             fiscal_year_bounds.date_from,
            //             CAST(fiscal_year_bounds.date_to::TIMESTAMP + INTERVAL '1' DAY AS DATE),
            //             'closing',
            //             CASE WHEN rate.id IS NOT NULL THEN %(main_company_unit_factor)s / rate.rate ELSE 1 END
            //         FROM res_company other_company
            //         LEFT JOIN res_currency_rate rate
            //             ON rate.currency_id = other_company.currency_id
            //             AND rate.name <= %(date_to)s
            //             AND rate.company_id = %(main_company_id)s
            //         JOIN (VALUES %(fiscal_year_bounds_values)s) AS fiscal_year_bounds(date_from, date_to)
            //             ON fiscal_year_bounds.date_to IS NULL
            //             OR fiscal_year_bounds.date_to >= rate.name
            //         WHERE
            //             other_company.id IN %(other_company_ids)s
            //         ORDER BY other_company.id, fiscal_year_bounds.date_from, fiscal_year_bounds.date_to, rate.name DESC
            //     """,
            //     period_key=period_key,
            //     main_company_id=main_company.root_id.id,
            //     fiscal_year_bounds_values=SQL(",").join(SQL("(%(fy_from)s::date,%(fy_to)s::date)", fy_from=fy_from, fy_to=fy_to) for fy_from, fy_to in fiscal_year_bounds),
            //     other_company_ids=tuple(other_companies.ids),
            //     date_to=date_to,
            //     main_company_unit_factor=main_company_unit_factor,
            // )
            */
            return default;
        }

        protected async Task<object> GetTableBuilderCurrentInternalAsync(object period_key, object main_company, object other_companies, object date_to, object main_company_unit_factor)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_currency.py) ---
            // def _get_table_builder_current(self, period_key, main_company, other_companies, date_to, main_company_unit_factor) -> SQL:
            // return SQL(
            //     """
            //         SELECT DISTINCT ON (other_company.id)
            //             other_company.id,
            //             %(period_key)s,
            //             CAST(NULL AS DATE),
            //             CAST(NULL AS DATE),
            //             'current',
            //             CASE WHEN rate.id IS NOT NULL THEN %(main_company_unit_factor)s / rate.rate ELSE 1 END
            //         FROM res_company other_company
            //         LEFT JOIN res_currency_rate rate
            //             ON rate.currency_id = other_company.currency_id
            //             AND rate.name <= %(date_to)s
            //             AND rate.company_id = %(main_company_id)s
            //         WHERE
            //             other_company.id IN %(other_company_ids)s
            //         ORDER BY other_company.id, rate.name DESC
            //     """,
            //     period_key=period_key,
            //     main_company_id=main_company.root_id.id,
            //     other_company_ids=tuple(other_companies.ids),
            //     date_to=date_to,
            //     main_company_unit_factor=main_company_unit_factor,
            // )
            */
            return default;
        }

        protected async Task<object> GetTableBuilderDomesticCurrencyInternalAsync(object companies, object use_cta_rates)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_currency.py) ---
            // def _get_table_builder_domestic_currency(self, companies, use_cta_rates) -> SQL:
            // """ Returns a query building one rate of each appropriate type equal to 1 for each of the provided companies. Those companies should be
            // the ones sharing the same currency as self.env.company.
            // """
            // rate_values = []
            // for company in companies:
            //     if use_cta_rates:
            //         rate_values += [
            //             SQL("(%s, CAST(NULL AS VARCHAR), CAST(NULL AS DATE), CAST(NULL AS DATE), 'average', 1)", company.id),
            //             SQL("(%s, CAST(NULL AS VARCHAR), CAST(NULL AS DATE), CAST(NULL AS DATE), 'historical', 1)", company.id),
            //             SQL("(%s, CAST(NULL AS VARCHAR), CAST(NULL AS DATE), CAST(NULL AS DATE), 'closing', 1)", company.id),
            //         ]
            //     else:
            //         rate_values.append(SQL("(%s, CAST(NULL AS VARCHAR), CAST(NULL AS DATE), CAST(NULL AS DATE), 'current', 1)", company.id))
            // 
            // return SQL(
            //     """
            //         SELECT *
            //         FROM ( VALUES
            //             %(rate_values)s
            //         ) values
            //     """,
            //     rate_values=SQL(", ").join(rate_values)
            // )
            */
            return default;
        }

        protected async Task<object> GetTableBuilderHistoricalInternalAsync(object main_company, object other_companies, object date_to, object main_company_unit_factor, object date_exclude)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_currency.py) ---
            // def _get_table_builder_historical(self, main_company, other_companies, date_to, main_company_unit_factor, date_exclude) -> SQL:
            // return SQL(
            //     """
            //         SELECT
            //             other_company.id,
            //             CAST(NULL AS VARCHAR),
            //             rate.name,
            //             LAG(rate.name, 1) OVER (PARTITION BY other_company.id, rate.currency_id ORDER BY rate.name DESC),
            //             'historical',
            //             %(main_company_unit_factor)s / rate.rate
            //         FROM res_company other_company
            //         JOIN res_currency_rate rate
            //             ON rate.currency_id = other_company.currency_id
            //         WHERE
            //             other_company.id IN %(other_company_ids)s
            //             AND rate.company_id = %(main_company_id)s
            //             AND rate.name <= %(date_to)s
            //             %(exclusion_condition)s
            //     """,
            //     main_company_id=main_company.root_id.id,
            //     other_company_ids=tuple(other_companies.ids),
            //     main_company_unit_factor=main_company_unit_factor,
            //     date_to=date_to,
            //     exclusion_condition=SQL("AND rate.name > %(date_exclude)s", date_exclude=date_exclude) if date_exclude else SQL(),
            // )
            */
            return default;
        }

        protected async Task<ResCurrency> GetViewCacheKeyInternalAsync(Guid view_id, object view_type)
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

        protected async Task<ResCurrency> GetViewInternalAsync(Guid view_id, object view_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def _get_view(self, view_id=None, view_type='form', **options):
            // arch, view = super()._get_view(view_id, view_type, **options)
            // if view_type in ('list', 'form'):
            //     currency_name = (self.env['res.company'].browse(self._context.get('company_id')) or self.env.company).currency_id.name
            //     fields_maps = [
            //         [['company_rate', 'rate'], _('Unit per %s', currency_name)],
            //         [['inverse_company_rate', 'inverse_rate'], _('%s per Unit', currency_name)],
            //     ]
            //     for fnames, label in fields_maps:
            //         xpath_expression = '//list//field[' + " or ".join(f"@name='{f}'" for f in fnames) + "][1]"
            //         node = arch.xpath(xpath_expression)
            //         if node:
            //             node[0].set('string', label)
            // return arch, view
            */
            return default;
        }

        protected async Task<ResCurrency> HasAccountingEntriesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_currency.py) ---
            // def _has_accounting_entries(self):
            // """ Returns True iff this currency has been used to generate (hence, round)
            // some move lines (either as their foreign currency, or as the main currency).
            // """
            // self.ensure_one()
            // return bool(self.env['account.move.line'].sudo().search_count(['|', ('currency_id', '=', self.id), ('company_currency_id', '=', self.id)]))
            */
            return default;
        }

        public async Task<ResCurrency> IsZeroAsync(Guid id, ResCurrencyIsZeroRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def is_zero(self, amount):
            // """Returns true if ``amount`` is small enough to be treated as
            //    zero according to current currency's rounding rules.
            //    Warning: ``is_zero(amount1-amount2)`` is not always equivalent to
            //    ``compare_amounts(amount1,amount2) == 0``, as the former will round after
            //    computing the difference, while the latter will round before, giving
            //    different results for e.g. 0.006 and 0.002 at 2 digits precision.
            // 
            //    :param float amount: amount to compare with currency's zero
            // 
            //    With the new API, call it like: ``currency.is_zero(amount)``.
            // """
            // self.ensure_one()
            // return tools.float_is_zero(amount, precision_rounding=self.rounding)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResCurrency> LoadPosDataDomainInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: res_currency.py) ---
            // def _load_pos_data_domain(self, data):
            // company_currency_id = self.env['res.company'].browse(data['pos.config']['data'][0]['company_id']).currency_id.id
            // if company_currency_id != data['pos.config']['data'][0]['currency_id']:
            //     return [('id', 'in', [company_currency_id, data['pos.config']['data'][0]['currency_id']])]
            // return [('id', '=', data['pos.config']['data'][0]['currency_id'])]
            */
            return default;
        }

        protected async Task<ResCurrency> LoadPosDataFieldsInternalAsync(Guid config_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: res_currency.py) ---
            // def _load_pos_data_fields(self, config_id):
            // return ['id', 'name', 'symbol', 'position', 'rounding', 'rate', 'decimal_places', 'iso_numeric']
            */
            return default;
        }

        public async Task<ResCurrency> RoundAsync(Guid id, ResCurrencyRoundRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def round(self, amount):
            // """Return ``amount`` rounded  according to ``self``'s rounding rules.
            // 
            //    :param float amount: the amount to round
            //    :return: rounded float
            // """
            // self.ensure_one()
            // return tools.float_round(amount, precision_rounding=self.rounding)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResCurrency> SelectCompaniesRatesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def _select_companies_rates(self):
            // return """
            //     SELECT
            //         r.currency_id,
            //         COALESCE(r.company_id, c.id) as company_id,
            //         r.rate,
            //         r.name AS date_start,
            //         (SELECT name FROM res_currency_rate r2
            //          WHERE r2.name > r.name AND
            //                r2.currency_id = r.currency_id AND
            //                (r2.company_id is null or r2.company_id = c.id)
            //          ORDER BY r2.name ASC
            //          LIMIT 1) AS date_end
            //     FROM res_currency_rate r
            //     JOIN res_company c ON (r.company_id is null or r.company_id = c.id)
            // """
            */
            return default;
        }

        protected async Task<ResCurrency> ToggleGroupMultiCurrencyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def _toggle_group_multi_currency(self):
            // """
            // Automatically activate group_multi_currency if there is more than 1 active currency; deactivate it otherwise
            // """
            // active_currency_count = self.search_count([('active', '=', True)])
            // if active_currency_count > 1:
            //     self._activate_group_multi_currency()
            // elif active_currency_count <= 1:
            //     self._deactivate_group_multi_currency()
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, ResCurrency entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_currency.py) ---
            // def write(self, vals):
            // if 'rounding' in vals:
            //     rounding_val = vals['rounding']
            //     for record in self:
            //         if (rounding_val > record.rounding or rounding_val == 0) and record._has_accounting_entries():
            //             raise UserError(_("You cannot reduce the number of decimal places of a currency which has already been used to make accounting entries."))
            // 
            // return super(ResCurrency, self).write(vals)
            --- ODOO METHOD SOURCE (MODULE: product, FILE: res_currency.py) ---
            // def write(self, vals):
            // """ Archive pricelist when the linked currency is archived. """
            // res = super().write(vals)
            // 
            // if self and 'active' in vals and not vals['active']:
            //     self.env['product.pricelist'].search([('currency_id', 'in', self.ids)]).action_archive()
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_currency.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // if vals.keys() & {'active', 'digits', 'position', 'symbol'}:
            //     # Currency info is cached to reduce the number of SQL queries when building the session
            //     # info. See `ir_http.get_currencies`.
            //     self.env.registry.clear_cache()
            // if 'active' not in vals:
            //     return res
            // self._toggle_group_multi_currency()
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}