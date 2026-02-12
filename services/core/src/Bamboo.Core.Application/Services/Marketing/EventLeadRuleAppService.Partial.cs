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
    public partial class EventLeadRuleAppService
    {

        protected async Task<EventLeadRule> FilterRegistrationsInternalAsync(object registrations)
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_lead_rule.py, METHOD: _filter_registrations) ---
            */
            return default;
        }

        protected async Task<EventLeadRule> OnchangeLeadSalesTeamIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_lead_rule.py, METHOD: _onchange_lead_sales_team_id) ---
            */
            return default;
        }

        protected async Task<EventLeadRule> RunOnRegistrationsInternalAsync(object registrations)
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_lead_rule.py, METHOD: _run_on_registrations) ---
            */
            return default;
        }
    }
}