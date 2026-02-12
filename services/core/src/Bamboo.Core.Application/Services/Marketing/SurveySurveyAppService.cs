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
    public partial class SurveySurveyAppService : GenericAppService<SurveySurvey>, ISurveySurveyAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        public SurveySurveyAppService(IRepository<SurveySurvey, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<SurveySurvey> ArchiveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_archive) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SurveySurvey> CheckValidityAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: check_validity) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SurveySurvey> CopyDataAsync(SurveySurveyCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SurveySurvey> EndSessionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_end_session) ---
            --- METHOD SOURCE (MODULE: survey_crm, FILE: survey_survey.py, METHOD: action_end_session) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SurveySurvey> GetFormviewIdAsync(SurveySurveyGetFormviewIdRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_survey, FILE: survey_survey.py, METHOD: get_formview_id) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SurveySurvey> GetPrintUrlAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: get_print_url) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SurveySurvey> GetStartShortUrlAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: get_start_short_url) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SurveySurvey> GetStartUrlAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: get_start_url) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<SurveySurvey> GetSurveyTemplatesDataAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: get_survey_templates_data) ---
            --- METHOD SOURCE (MODULE: survey_crm, FILE: survey_survey.py, METHOD: get_survey_templates_data) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<SurveySurvey> LoadSampleCustomAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_load_sample_custom) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<SurveySurvey> LoadSurveyTemplateSampleAsync(SurveySurveyLoadSurveyTemplateSampleRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_load_survey_template_sample) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SurveySurvey> OpenSessionManagerAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_open_session_manager) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SurveySurvey> PrintSurveyAsync(SurveySurveyPrintSurveyRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_print_survey) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SurveySurvey> ResultSurveyAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_result_survey) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SurveySurvey> SendSurveyAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_send_survey) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SurveySurvey> ShowSampleAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_show_sample) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SurveySurvey> StartSessionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_start_session) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SurveySurvey> StartSurveyAsync(SurveySurveyStartSurveyRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_start_survey) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SurveySurvey> SurveyPreviewCertificationTemplateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_survey_preview_certification_template) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SurveySurvey> SurveySeeLeadsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: survey_crm, FILE: survey_survey.py, METHOD: action_survey_see_leads) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SurveySurvey> SurveyUserInputAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_survey_user_input) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SurveySurvey> SurveyUserInputCertifiedAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_survey_user_input_certified) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SurveySurvey> SurveyUserInputCompletedAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_survey, FILE: survey_survey.py, METHOD: action_survey_user_input_completed) ---
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_survey_user_input_completed) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SurveySurvey> SurveyViewSlideChannelsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides_survey, FILE: survey_survey.py, METHOD: action_survey_view_slide_channels) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SurveySurvey> TestSurveyAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_test_survey) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SurveySurvey> UnarchiveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_unarchive) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}