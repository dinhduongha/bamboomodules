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
    [Module("Hr", Category = "HumanResources", Depends = new[] { "base_setup", "digest", "phone_validation", "resource_mail", "web" })]
    public partial class HrJobAppService : GenericAppService<HrJob>, IHrJobAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailAliasMixinAppService _mailAliasMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        protected readonly IWebsitePublishedMultiMixinAppService _websitePublishedMultiMixinAppService;
        protected readonly IWebsiteSearchableMixinAppService _websiteSearchableMixinAppService;
        protected readonly IWebsiteSeoMetadataAppService _websiteSeoMetadataAppService;
        public HrJobAppService(IRepository<HrJob, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailAliasMixinAppService mailAliasMixinAppService, IMailThreadAppService mailThreadAppService, IWebsitePublishedMultiMixinAppService websitePublishedMultiMixinAppService, IWebsiteSearchableMixinAppService websiteSearchableMixinAppService, IWebsiteSeoMetadataAppService websiteSeoMetadataAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailAliasMixinAppService = mailAliasMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _websitePublishedMultiMixinAppService = websitePublishedMultiMixinAppService;
            _websiteSearchableMixinAppService = websiteSearchableMixinAppService;
            _websiteSeoMetadataAppService = websiteSeoMetadataAppService;
        }

        public async Task<HrJob> ArchiveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: action_archive) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrJob> CopyDataAsync(HrJobCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_job.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<HrJob> CreateAsync(CreateRequestDto<HrJob> input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_job.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_job.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<HrJob> GetBackendMenuIdAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: get_backend_menu_id) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrJob> NewSurveyAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_survey, FILE: hr_job.py, METHOD: action_new_survey) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrJob> OpenActivitiesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: action_open_activities) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrJob> OpenAttachmentsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: action_open_attachments) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrJob> OpenEmployeesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: action_open_employees) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrJob> SearchMatchingApplicantsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_job.py, METHOD: action_search_matching_applicants) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrJob> SetOpenAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: set_open) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrJob> TestSurveyAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_survey, FILE: hr_job.py, METHOD: action_test_survey) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<HrJob> input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_job.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_job.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}