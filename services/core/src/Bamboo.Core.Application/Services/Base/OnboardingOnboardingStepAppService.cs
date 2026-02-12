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
    public partial class OnboardingOnboardingStepAppService : GenericAppService<OnboardingOnboardingStep>, IOnboardingOnboardingStepAppService
    {

        public OnboardingOnboardingStepAppService(IRepository<OnboardingOnboardingStep, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<OnboardingOnboardingStep> CheckStepOnOnboardingHasActionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: onboarding, FILE: onboarding_onboarding_step.py, METHOD: check_step_on_onboarding_has_action) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<OnboardingOnboardingStep> OpenStepBankAccountAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: onboarding_onboarding_step.py, METHOD: action_open_step_bank_account) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<OnboardingOnboardingStep> OpenStepBaseDocumentLayoutAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: onboarding_onboarding_step.py, METHOD: action_open_step_base_document_layout) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<OnboardingOnboardingStep> OpenStepChartOfAccountsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: onboarding_onboarding_step.py, METHOD: action_open_step_chart_of_accounts) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<OnboardingOnboardingStep> OpenStepCompanyDataAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: onboarding_onboarding_step.py, METHOD: action_open_step_company_data) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<OnboardingOnboardingStep> OpenStepCreateInvoiceAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: onboarding_onboarding_step.py, METHOD: action_open_step_create_invoice) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<OnboardingOnboardingStep> OpenStepFiscalYearAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: onboarding_onboarding_step.py, METHOD: action_open_step_fiscal_year) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<OnboardingOnboardingStep> OpenStepSalesTaxAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: onboarding_onboarding_step.py, METHOD: action_open_step_sales_tax) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<OnboardingOnboardingStep> SetJustDoneAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: onboarding, FILE: onboarding_onboarding_step.py, METHOD: action_set_just_done) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<OnboardingOnboardingStep> ValidateStepAsync(OnboardingOnboardingStepValidateStepRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: onboarding, FILE: onboarding_onboarding_step.py, METHOD: action_validate_step) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<OnboardingOnboardingStep> ValidateStepBaseDocumentLayoutAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: onboarding_onboarding_step.py, METHOD: action_validate_step_base_document_layout) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}