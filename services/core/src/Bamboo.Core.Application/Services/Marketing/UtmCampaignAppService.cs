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
    [Module("Utm", Category = "Marketing", Depends = new[] { "base", "web" })]
    public partial class UtmCampaignAppService : GenericAppService<UtmCampaign>, IUtmCampaignAppService
    {

        public UtmCampaignAppService(IRepository<UtmCampaign, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<UtmCampaign> CreateMassSmsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: utm.py, METHOD: action_create_mass_sms) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<UtmCampaign> RedirectToInvoicedAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: utm_campaign.py, METHOD: action_redirect_to_invoiced) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<UtmCampaign> RedirectToLeadsOpportunitiesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: utm.py, METHOD: action_redirect_to_leads_opportunities) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<UtmCampaign> RedirectToMailingSmsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: utm.py, METHOD: action_redirect_to_mailing_sms) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<UtmCampaign> RedirectToQuotationsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: utm_campaign.py, METHOD: action_redirect_to_quotations) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}