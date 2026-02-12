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
    public partial class CrmIapLeadMiningRequestAppService
    {

        protected async Task<CrmIapLeadMiningRequest> ComputeAvailableStateIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py, METHOD: _compute_available_state_ids) ---
            */
            return default;
        }

        protected async Task<CrmIapLeadMiningRequest> ComputeLeadCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py, METHOD: _compute_lead_count) ---
            */
            return default;
        }

        protected async Task<CrmIapLeadMiningRequest> ComputeTeamIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py, METHOD: _compute_team_id) ---
            */
            return default;
        }

        protected async Task<CrmIapLeadMiningRequest> ComputeTooltipInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py, METHOD: _compute_tooltip) ---
            */
            return default;
        }

        protected async Task<CrmIapLeadMiningRequest> CreateLeadsFromResponseInternalAsync(object result)
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py, METHOD: _create_leads_from_response) ---
            */
            return default;
        }

        protected async Task<CrmIapLeadMiningRequest> DefaultCountryIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py, METHOD: _default_country_ids) ---
            */
            return default;
        }

        protected async Task<CrmIapLeadMiningRequest> DefaultLeadTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py, METHOD: _default_lead_type) ---
            */
            return default;
        }

        protected async Task<CrmIapLeadMiningRequest> IapContactMiningInternalAsync(object @params, object timeout)
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py, METHOD: _iap_contact_mining) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CrmIapLeadMiningRequest> LeadValsFromResponseInternalAsync(object data)
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py, METHOD: _lead_vals_from_response) ---
            */
            return default;
        }

        protected async Task<CrmIapLeadMiningRequest> OnchangeAvailableStateIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py, METHOD: _onchange_available_state_ids) ---
            */
            return default;
        }

        protected async Task<CrmIapLeadMiningRequest> OnchangeCompanySizeMaxInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py, METHOD: _onchange_company_size_max) ---
            */
            return default;
        }

        protected async Task<CrmIapLeadMiningRequest> OnchangeCompanySizeMinInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py, METHOD: _onchange_company_size_min) ---
            */
            return default;
        }

        protected async Task<CrmIapLeadMiningRequest> OnchangeContactNumberInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py, METHOD: _onchange_contact_number) ---
            */
            return default;
        }

        protected async Task<CrmIapLeadMiningRequest> OnchangeCountryIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py, METHOD: _onchange_country_ids) ---
            */
            return default;
        }

        protected async Task<CrmIapLeadMiningRequest> OnchangeLeadNumberInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py, METHOD: _onchange_lead_number) ---
            */
            return default;
        }

        protected async Task<CrmIapLeadMiningRequest> PerformRequestInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py, METHOD: _perform_request) ---
            */
            return default;
        }

        protected async Task<CrmIapLeadMiningRequest> PrepareIapPayloadInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py, METHOD: _prepare_iap_payload) ---
            */
            return default;
        }
    }
}