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
    [Module("MailGroupModule", Category = "Misc", Depends = new[] { "mail", "portal" })]
    public partial class MailGroupMessageAppService : GenericAppService<MailGroupMessage>, IMailGroupMessageAppService
    {

        public MailGroupMessageAppService(IRepository<MailGroupMessage, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<MailGroupMessage> CopyDataAsync(MailGroupMessageCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group_message.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailGroupMessage> ModerateAcceptAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group_message.py, METHOD: action_moderate_accept) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailGroupMessage> ModerateAllowAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group_message.py, METHOD: action_moderate_allow) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailGroupMessage> ModerateBanAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group_message.py, METHOD: action_moderate_ban) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailGroupMessage> ModerateBanWithCommentAsync(MailGroupMessageModerateBanWithCommentRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group_message.py, METHOD: action_moderate_ban_with_comment) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailGroupMessage> ModerateRejectAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group_message.py, METHOD: action_moderate_reject) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailGroupMessage> ModerateRejectWithCommentAsync(MailGroupMessageModerateRejectWithCommentRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group_message.py, METHOD: action_moderate_reject_with_comment) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}