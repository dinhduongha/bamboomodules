using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
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
    public partial class ResCurrencyAppService
    {

        [ApiModel]
        protected async Task<ResCurrency> ActivateGroupMultiCurrencyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: res_currency.py, METHOD: _activate_group_multi_currency) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: _activate_group_multi_currency) ---
            */
            return default;
        }

        protected async Task<ResCurrency> CheckCompanyCurrencyStaysActiveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: _check_company_currency_stays_active) ---
            */
            return default;
        }

        protected async Task<ResCurrency> CheckCurrencyTableMonocurrencyInternalAsync(object companies)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_currency.py, METHOD: _check_currency_table_monocurrency) ---
            */
            return default;
        }

        protected async Task<ResCurrency> ComputeCurrentRateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: _compute_current_rate) ---
            */
            return default;
        }

        protected async Task<ResCurrency> ComputeDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: _compute_date) ---
            */
            return default;
        }

        protected async Task<ResCurrency> ComputeDecimalPlacesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: _compute_decimal_places) ---
            */
            return default;
        }

        protected async Task<ResCurrency> ComputeDisplayRoundingWarningInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_currency.py, METHOD: _compute_display_rounding_warning) ---
            */
            return default;
        }

        protected async Task<ResCurrency> ComputeIsCurrentCompanyCurrencyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: _compute_is_current_company_currency) ---
            */
            return default;
        }

        protected async Task<ResCurrency> ConvertInternalAsync(object from_amount, object to_currency, object company, object date, object round)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: _convert) ---
            */
            return default;
        }

        protected async Task<ResCurrency> CreateCurrencyTableInternalAsync(object companies, object date_periods, object use_cta_rates)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_currency.py, METHOD: _create_currency_table) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCurrency> DeactivateGroupMultiCurrencyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: _deactivate_group_multi_currency) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCurrency> GetConversionRateInternalAsync(object from_currency, object to_currency, object company, object date)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: _get_conversion_rate) ---
            */
            return default;
        }

        protected async Task<ResCurrency> GetFiscalCountryCodesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_currency.py, METHOD: _get_fiscal_country_codes) ---
            */
            return default;
        }

        protected async Task<ResCurrency> GetMonocurrencyCurrencyTableSqlInternalAsync(object companies, object use_cta_rates)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_currency.py, METHOD: _get_monocurrency_currency_table_sql) ---
            */
            return default;
        }

        protected async Task<ResCurrency> GetRatesInternalAsync(object company, object date)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: _get_rates) ---
            */
            return default;
        }

        protected async Task<object> GetSimpleCurrencyTableInternalAsync(object companies)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_currency.py, METHOD: _get_simple_currency_table) ---
            */
            return default;
        }

        protected async Task<object> GetTableBuilderAverageInternalAsync(object period_key, object main_company, object other_companies, object date_from, object date_to, object main_company_unit_factor)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_currency.py, METHOD: _get_table_builder_average) ---
            */
            return default;
        }

        protected async Task<object> GetTableBuilderCurrentInternalAsync(object period_key, object main_company, object other_companies, object date_to, object main_company_unit_factor)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_currency.py, METHOD: _get_table_builder_current) ---
            */
            return default;
        }

        protected async Task<object> GetTableBuilderDomesticCurrencyInternalAsync(object companies, object use_cta_rates)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_currency.py, METHOD: _get_table_builder_domestic_currency) ---
            */
            return default;
        }

        protected async Task<object> GetTableBuilderHistoricalInternalAsync(object main_company, object other_companies, object date_to, object main_company_unit_factor, object date_exclude)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_currency.py, METHOD: _get_table_builder_historical) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCurrency> GetViewCacheKeyInternalAsync(Guid view_id, object view_type)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: _get_view_cache_key) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCurrency> GetViewInternalAsync(Guid view_id, object view_type)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: _get_view) ---
            */
            return default;
        }

        protected async Task<ResCurrency> HasAccountingEntriesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_currency.py, METHOD: _has_accounting_entries) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCurrency> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_currency.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCurrency> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_currency.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        protected async Task<ResCurrency> SelectCompaniesRatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: _select_companies_rates) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCurrency> ToggleGroupMultiCurrencyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: _toggle_group_multi_currency) ---
            */
            return default;
        }
    }
}