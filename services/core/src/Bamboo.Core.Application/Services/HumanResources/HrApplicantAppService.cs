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
    [Module("HrRecruitment", Category = "HumanResources", Depends = new[] { "hr", "calendar", "utm", "attachment_indexation", "web_tour", "digest" })]
    public partial class HrApplicantAppService : GenericAppService<HrApplicant>, IHrApplicantAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadBlacklistAppService _mailThreadBlacklistAppService;
        protected readonly IMailThreadCcAppService _mailThreadCcAppService;
        protected readonly IMailThreadMainAttachmentAppService _mailThreadMainAttachmentAppService;
        protected readonly IMailThreadPhoneAppService _mailThreadPhoneAppService;
        protected readonly IMailTrackingDurationMixinAppService _mailTrackingDurationMixinAppService;
        protected readonly IUtmMixinAppService _utmMixinAppService;
        public HrApplicantAppService(IRepository<HrApplicant, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadBlacklistAppService mailThreadBlacklistAppService, IMailThreadCcAppService mailThreadCcAppService, IMailThreadMainAttachmentAppService mailThreadMainAttachmentAppService, IMailThreadPhoneAppService mailThreadPhoneAppService, IMailTrackingDurationMixinAppService mailTrackingDurationMixinAppService, IUtmMixinAppService utmMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadBlacklistAppService = mailThreadBlacklistAppService;
            _mailThreadCcAppService = mailThreadCcAppService;
            _mailThreadMainAttachmentAppService = mailThreadMainAttachmentAppService;
            _mailThreadPhoneAppService = mailThreadPhoneAppService;
            _mailTrackingDurationMixinAppService = mailTrackingDurationMixinAppService;
            _utmMixinAppService = utmMixinAppService;
        }

        public async Task<HrApplicant> AddToJobAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_applicant.py, METHOD: action_add_to_job) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrApplicant> ArchiveApplicantAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: archive_applicant) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrApplicant> ArchiveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_archive) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrApplicant> CopyDataAsync(HrApplicantCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<HrApplicant> CreateAsync(CreateRequestDto<HrApplicant> input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_applicant.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<HrApplicant> CreateEmployeeFromApplicantAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: create_employee_from_applicant) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrApplicant> CreateMeetingAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_create_meeting) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<HrApplicant> GetEmptyListHelpAsync(HrApplicantGetEmptyListHelpRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: get_empty_list_help) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<HrApplicant> GetViewAsync(HrApplicantGetViewRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: get_view) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrApplicant> JobAddApplicantsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_job_add_applicants) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrApplicant> LinkApplicantToTalentAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: link_applicant_to_talent) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<HrApplicant> MessageNewAsync(HrApplicantMessageNewRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: message_new) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrApplicant> OpenApplicationsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_open_applications) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrApplicant> OpenAttachmentsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_open_attachments) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrApplicant> OpenEmployeeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_open_employee) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrApplicant> PrintSurveyAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_survey, FILE: hr_applicant.py, METHOD: action_print_survey) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrApplicant> ResetApplicantAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: reset_applicant) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrApplicant> SendEmailAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_send_email) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrApplicant> SendSmsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_sms, FILE: hr_applicant.py, METHOD: action_send_sms) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrApplicant> SendSurveyAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_survey, FILE: hr_applicant.py, METHOD: action_send_survey) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrApplicant> TalentPoolAddApplicantsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_talent_pool_add_applicants) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrApplicant> TalentPoolStatButtonAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_talent_pool_stat_button) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrApplicant> UnarchiveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_unarchive) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrApplicant> WebsiteFormInputFilterAsync(HrApplicantWebsiteFormInputFilterRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_applicant.py, METHOD: website_form_input_filter) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<HrApplicant> input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_applicant.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}