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
    public partial class HrCandidateAppService : GenericAppService<HrCandidate>, IHrCandidateAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadBlacklistAppService _mailThreadBlacklistAppService;
        protected readonly IMailThreadCcAppService _mailThreadCcAppService;
        protected readonly IMailThreadMainAttachmentAppService _mailThreadMainAttachmentAppService;
        protected readonly IMailThreadPhoneAppService _mailThreadPhoneAppService;
        public HrCandidateAppService(IRepository<HrCandidate, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadBlacklistAppService mailThreadBlacklistAppService, IMailThreadCcAppService mailThreadCcAppService, IMailThreadMainAttachmentAppService mailThreadMainAttachmentAppService, IMailThreadPhoneAppService mailThreadPhoneAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadBlacklistAppService = mailThreadBlacklistAppService;
            _mailThreadCcAppService = mailThreadCcAppService;
            _mailThreadMainAttachmentAppService = mailThreadMainAttachmentAppService;
            _mailThreadPhoneAppService = mailThreadPhoneAppService;
        }

        public async Task<HrCandidate> CreateApplicationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_candidate.py, METHOD: action_create_application) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrCandidate> CreateEmployeeFromCandidateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py, METHOD: create_employee_from_candidate) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrCandidate> CreateMeetingAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py, METHOD: action_create_meeting) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrCandidate> InitAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py, METHOD: init) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrCandidate> OpenApplicationsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py, METHOD: action_open_applications) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrCandidate> OpenAttachmentsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py, METHOD: action_open_attachments) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrCandidate> OpenEmployeeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py, METHOD: action_open_employee) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrCandidate> OpenSimilarCandidatesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py, METHOD: action_open_similar_candidates) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrCandidate> SendEmailAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py, METHOD: action_send_email) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}