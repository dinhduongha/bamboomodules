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
    public partial class ResCurrencyRateAppService
    {

        protected async Task<ResCurrencyRate> CheckCompanyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: _check_company_id) ---
            */
            return default;
        }

        protected async Task<ResCurrencyRate> ComputeCompanyRateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: _compute_company_rate) ---
            */
            return default;
        }

        protected async Task<ResCurrencyRate> ComputeInverseCompanyRateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: _compute_inverse_company_rate) ---
            */
            return default;
        }

        protected async Task<ResCurrencyRate> ComputeRateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: _compute_rate) ---
            */
            return default;
        }

        protected async Task<ResCurrencyRate> GetLastRatesForCompaniesInternalAsync(object companies)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: _get_last_rates_for_companies) ---
            */
            return default;
        }

        protected async Task<ResCurrencyRate> GetLatestRateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: _get_latest_rate) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCurrencyRate> GetRateForSpreadsheetInternalAsync(object currency_from_code, object currency_to_code, object date, Guid company_id)
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet, FILE: res_currency_rate.py, METHOD: _get_rate_for_spreadsheet) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCurrencyRate> GetViewCacheKeyInternalAsync(Guid view_id, object view_type)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: _get_view_cache_key) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCurrencyRate> GetViewInternalAsync(Guid view_id, object view_type)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: _get_view) ---
            */
            return default;
        }

        protected async Task<ResCurrencyRate> InverseCompanyRateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: _inverse_company_rate) ---
            */
            return default;
        }

        protected async Task<ResCurrencyRate> InverseInverseCompanyRateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: _inverse_inverse_company_rate) ---
            */
            return default;
        }

        protected async Task<ResCurrencyRate> OnchangeRateWarningInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: _onchange_rate_warning) ---
            */
            return default;
        }

        protected async Task<ResCurrencyRate> SanitizeValsInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: _sanitize_vals) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCurrencyRate> SearchDisplayNameInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_currency.py, METHOD: _search_display_name) ---
            */
            return default;
        }
    }
}