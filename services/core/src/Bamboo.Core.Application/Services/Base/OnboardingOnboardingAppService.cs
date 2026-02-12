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
    [Module("Onboarding", Category = "Base", Depends = new[] { "web" })]
    public partial class OnboardingOnboardingAppService : GenericAppService<OnboardingOnboarding>, IOnboardingOnboardingAppService
    {

        public OnboardingOnboardingAppService(IRepository<OnboardingOnboarding, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<OnboardingOnboarding> CloseAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: onboarding, FILE: onboarding_onboarding.py, METHOD: action_close) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<OnboardingOnboarding> ClosePanelAccountDashboardAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: onboarding_onboarding.py, METHOD: action_close_panel_account_dashboard) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<OnboardingOnboarding> ClosePanelAccountInvoiceAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: onboarding_onboarding.py, METHOD: action_close_panel_account_invoice) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<OnboardingOnboarding> ClosePanelAsync(OnboardingOnboardingClosePanelRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: onboarding, FILE: onboarding_onboarding.py, METHOD: action_close_panel) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<OnboardingOnboarding> RefreshProgressIdsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: onboarding, FILE: onboarding_onboarding.py, METHOD: action_refresh_progress_ids) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<OnboardingOnboarding> ToggleVisibilityAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: onboarding, FILE: onboarding_onboarding.py, METHOD: action_toggle_visibility) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}