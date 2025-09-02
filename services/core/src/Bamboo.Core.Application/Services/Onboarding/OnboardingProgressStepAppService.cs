using Bamboo.Core.Application.Contracts.DTOs;
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
    [Module("Onboarding", Depends = new[] { "web" })]
    public class OnboardingProgressStepAppService : GenericApplicationService<OnboardingProgressStep>, IOnboardingProgressStepAppService
    {

        public OnboardingProgressStepAppService(IRepository<OnboardingProgressStep, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<OnboardingProgressStep> ConsolidateJustDoneAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: onboarding, FILE: onboarding_progress_step.py) ---
            // def action_consolidate_just_done(self):
            // was_just_done = self.filtered(lambda progress: progress.step_state == 'just_done')
            // was_just_done.step_state = 'done'
            // return was_just_done
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<OnboardingProgressStep> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: onboarding, FILE: onboarding_progress_step.py) ---
            // def init(self):
            // """Make sure there aren't multiple records for the same onboarding step and company."""
            // # not in _sql_constraint because COALESCE is not supported for PostgreSQL constraint
            // self.env.cr.execute("""
            //     CREATE UNIQUE INDEX IF NOT EXISTS onboarding_progress_step_company_uniq
            //     ON onboarding_progress_step (step_id, COALESCE(company_id, 0))
            // """)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<OnboardingProgressStep> SetJustDoneAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: onboarding, FILE: onboarding_progress_step.py) ---
            // def action_set_just_done(self):
            // not_done = self.filtered_domain([('step_state', '=', 'not_done')])
            // not_done.step_state = 'just_done'
            // return not_done
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}