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
    [Module("HrHolidays", Category = "HumanResources", Depends = new[] { "hr", "calendar", "resource" })]
    public partial class HrLeaveAppService : GenericAppService<HrLeave>, IHrLeaveAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadMainAttachmentAppService _mailThreadMainAttachmentAppService;
        public HrLeaveAppService(IRepository<HrLeave, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadMainAttachmentAppService mailThreadMainAttachmentAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadMainAttachmentAppService = mailThreadMainAttachmentAppService;
        }

        public async Task<HrLeave> ActivityUpdateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: activity_update) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrLeave> AddFollowerAsync(HrLeaveAddFollowerRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: add_follower) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrLeave> ApproveAsync(HrLeaveApproveRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: action_approve) ---
            --- METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave.py, METHOD: action_approve) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrLeave> BackToApprovalAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: action_back_to_approval) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrLeave> CancelAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: action_cancel) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrLeave> CopyDataAsync(HrLeaveCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<HrLeave> CreateAsync(CreateRequestDto<HrLeave> input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_leave.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<HrLeave> DocumentsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: action_documents) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<HrLeave> GetUnusualDaysAsync(HrLeaveGetUnusualDaysRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: get_unusual_days) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrLeave> MessageSubscribeAsync(HrLeaveMessageSubscribeRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: message_subscribe) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<HrLeave> OpenPendingRequestsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: open_pending_requests) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrLeave> RefuseAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: action_refuse) ---
            --- METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave.py, METHOD: action_refuse) ---
            --- METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_leave.py, METHOD: action_refuse) ---
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: hr_leave.py, METHOD: action_refuse) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrLeave> ResetConfirmAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave.py, METHOD: action_reset_confirm) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<HrLeave> input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_leave.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: hr_leave.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}