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
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Services
{
    public partial class CrmRevealRuleAppService
    {

        protected async Task<CrmRevealRule> AddToCountryInternalAsync(object country_rules, object country, object rule_index)
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_iap_reveal, FILE: crm_reveal_rule.py, METHOD: _add_to_country) ---
            */
            return default;
        }

        protected async Task<CrmRevealRule> CheckRegexUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_iap_reveal, FILE: crm_reveal_rule.py, METHOD: _check_regex_url) ---
            */
            return default;
        }

        protected async Task<CrmRevealRule> ComputeLeadCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_iap_reveal, FILE: crm_reveal_rule.py, METHOD: _compute_lead_count) ---
            */
            return default;
        }

        protected async Task<CrmRevealRule> CreateLeadFromResponseInternalAsync(object result)
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_iap_reveal, FILE: crm_reveal_rule.py, METHOD: _create_lead_from_response) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CrmRevealRule> GetActiveRulesInternalAsync()
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: website_crm_iap_reveal, FILE: crm_reveal_rule.py, METHOD: _get_active_rules) ---
            #endif
            return default;
        }

        [ApiModel]
        protected async Task<CrmRevealRule> GetRevealViewsToProcessInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_iap_reveal, FILE: crm_reveal_rule.py, METHOD: _get_reveal_views_to_process) ---
            */
            return default;
        }

        protected async Task<CrmRevealRule> GetRulesPayloadInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_iap_reveal, FILE: crm_reveal_rule.py, METHOD: _get_rules_payload) ---
            */
            return default;
        }

        protected async Task<CrmRevealRule> IapContactRevealInternalAsync(object @params, object timeout)
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_iap_reveal, FILE: crm_reveal_rule.py, METHOD: _iap_contact_reveal) ---
            */
            return default;
        }

        protected async Task<CrmRevealRule> LeadValsFromResponseInternalAsync(object result)
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_iap_reveal, FILE: crm_reveal_rule.py, METHOD: _lead_vals_from_response) ---
            */
            return default;
        }

        protected async Task<CrmRevealRule> MatchUrlInternalAsync(Guid website_id, object url, object country_code, object state_code, object rules_excluded)
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_iap_reveal, FILE: crm_reveal_rule.py, METHOD: _match_url) ---
            */
            return default;
        }

        protected async Task<CrmRevealRule> PerformRevealServiceInternalAsync(object server_payload)
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_iap_reveal, FILE: crm_reveal_rule.py, METHOD: _perform_reveal_service) ---
            */
            return default;
        }

        protected async Task<CrmRevealRule> PrepareIapPayloadInternalAsync(object pgv)
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_iap_reveal, FILE: crm_reveal_rule.py, METHOD: _prepare_iap_payload) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CrmRevealRule> ProcessLeadGenerationInternalAsync(object autocommit)
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_iap_reveal, FILE: crm_reveal_rule.py, METHOD: _process_lead_generation) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CrmRevealRule> UnlinkUnrelevantRevealViewInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_iap_reveal, FILE: crm_reveal_rule.py, METHOD: _unlink_unrelevant_reveal_view) ---
            */
            return default;
        }
    }
}