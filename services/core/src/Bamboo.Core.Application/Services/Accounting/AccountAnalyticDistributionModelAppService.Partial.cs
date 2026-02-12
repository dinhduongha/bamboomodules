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
    public partial class AccountAnalyticDistributionModelAppService
    {

        protected async Task<AccountAnalyticDistributionModel> CheckCompanyAccountsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_distribution_model.py, METHOD: _check_company_accounts) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticDistributionModel> ComputePrefixPlaceholderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_analytic_distribution_model.py, METHOD: _compute_prefix_placeholder) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticDistributionModel> CreateDomainInternalAsync(object fname, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_analytic_distribution_model.py, METHOD: _create_domain) ---
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_distribution_model.py, METHOD: _create_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountAnalyticDistributionModel> GetApplicableModelsInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_analytic_distribution_model.py, METHOD: _get_applicable_models) ---
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_distribution_model.py, METHOD: _get_applicable_models) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountAnalyticDistributionModel> GetDefaultSearchDomainValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_analytic_distribution_model.py, METHOD: _get_default_search_domain_vals) ---
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_distribution_model.py, METHOD: _get_default_search_domain_vals) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountAnalyticDistributionModel> GetDistributionInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_distribution_model.py, METHOD: _get_distribution) ---
            */
            return default;
        }
    }
}