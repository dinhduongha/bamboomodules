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
    [Module("Survey", Category = "Marketing", Depends = new[] { "auth_signup", "http_routing", "mail", "web_tour", "gamification" })]
    public partial class SurveyUserInputAppService : GenericAppService<SurveyUserInput>, ISurveyUserInputAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        public SurveyUserInputAppService(IRepository<SurveyUserInput, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        public override async Task<SurveyUserInput> CreateAsync(CreateRequestDto<SurveyUserInput> input)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_slides_survey, FILE: survey_user.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<SurveyUserInput> GetPrintUrlAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: get_print_url) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SurveyUserInput> GetStartUrlAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: get_start_url) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SurveyUserInput> PrintAnswersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: action_print_answers) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SurveyUserInput> RedirectLeadAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: survey_crm, FILE: survey_user_input.py, METHOD: action_redirect_lead) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SurveyUserInput> RedirectToAttemptsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: action_redirect_to_attempts) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SurveyUserInput> ResendAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: action_resend) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<SurveyUserInput> input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides_survey, FILE: survey_user.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}