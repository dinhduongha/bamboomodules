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
    public partial class OnboardingOnboardingAppService
    {

        protected async Task<OnboardingOnboarding> ComputeCurrentProgressInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: onboarding, FILE: onboarding_onboarding.py, METHOD: _compute_current_progress) ---
            */
            return default;
        }

        protected async Task<OnboardingOnboarding> ComputeIsPerCompanyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: onboarding, FILE: onboarding_onboarding.py, METHOD: _compute_is_per_company) ---
            */
            return default;
        }

        protected async Task<OnboardingOnboarding> CreateProgressInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: onboarding, FILE: onboarding_onboarding.py, METHOD: _create_progress) ---
            */
            return default;
        }

        protected async Task<OnboardingOnboarding> PrepareRenderingValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: onboarding_onboarding.py, METHOD: _prepare_rendering_values) ---
            --- METHOD SOURCE (MODULE: onboarding, FILE: onboarding_onboarding.py, METHOD: _prepare_rendering_values) ---
            */
            return default;
        }

        protected async Task<OnboardingOnboarding> SearchOrCreateProgressInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: onboarding, FILE: onboarding_onboarding.py, METHOD: _search_or_create_progress) ---
            */
            return default;
        }
    }
}