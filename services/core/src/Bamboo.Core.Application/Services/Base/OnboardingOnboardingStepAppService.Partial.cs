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
    public partial class OnboardingOnboardingStepAppService
    {

        protected async Task<OnboardingOnboardingStep> ComputeCurrentProgressInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: onboarding, FILE: onboarding_onboarding_step.py, METHOD: _compute_current_progress) ---
            */
            return default;
        }

        protected async Task<OnboardingOnboardingStep> CreateProgressStepsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: onboarding, FILE: onboarding_onboarding_step.py, METHOD: _create_progress_steps) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<OnboardingOnboardingStep> GetPlaceholderFilenameInternalAsync(object field)
        {
            /*
            --- METHOD SOURCE (MODULE: onboarding, FILE: onboarding_onboarding_step.py, METHOD: _get_placeholder_filename) ---
            */
            return default;
        }
    }
}