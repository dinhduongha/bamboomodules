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
    public partial class OnboardingProgressAppService
    {

        protected async Task<OnboardingProgress> ComputeOnboardingStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: onboarding, FILE: onboarding_progress.py, METHOD: _compute_onboarding_state) ---
            */
            return default;
        }

        protected async Task<OnboardingProgress> GetAndUpdateOnboardingStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: onboarding, FILE: onboarding_progress.py, METHOD: _get_and_update_onboarding_state) ---
            */
            return default;
        }

        protected async Task<OnboardingProgress> RecomputeProgressStepIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: onboarding, FILE: onboarding_progress.py, METHOD: _recompute_progress_step_ids) ---
            */
            return default;
        }
    }
}