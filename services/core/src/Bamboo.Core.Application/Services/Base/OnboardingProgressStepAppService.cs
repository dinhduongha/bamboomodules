using Volo.Abp.ObjectMapping;
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
    [Module("Onboarding", Category = "Base", Depends = new[] { "web" })]
    public partial class OnboardingProgressStepAppService : GenericAppService<OnboardingProgressStep>, IOnboardingProgressStepAppService
    {

        public OnboardingProgressStepAppService(IRepository<OnboardingProgressStep, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        public async Task<OnboardingProgressStep> ConsolidateJustDoneAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: onboarding, FILE: onboarding_progress_step.py) ---
            // def action_consolidate_just_done(self):
            // was_just_done = self.filtered(lambda progress: progress.step_state == 'just_done')
            // was_just_done.step_state = 'done'
            // return was_just_done
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<OnboardingProgressStep> SetJustDoneAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: onboarding, FILE: onboarding_progress_step.py) ---
            // def action_set_just_done(self):
            // not_done = self.filtered_domain([('step_state', '=', 'not_done')])
            // not_done.step_state = 'just_done'
            // return not_done
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}