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
    [Module("MailGroupModule", Category = "Misc", Depends = new[] { "mail", "portal" })]
    public partial class MailGroupAppService : GenericAppService<MailGroup>, IMailGroupAppService
    {
        protected readonly IMailAliasMixinAppService _mailAliasMixinAppService;
        public MailGroupAppService(IRepository<MailGroup, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailAliasMixinAppService mailAliasMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailAliasMixinAppService = mailAliasMixinAppService;
        }

        public async Task<MailGroup> CloseAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: action_close) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailGroup> GoToWebsiteAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_mail_group, FILE: mail_group.py, METHOD: action_go_to_website) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailGroup> JoinAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: action_join) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailGroup> LeaveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: action_leave) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<MailGroup> MessageNewAsync(MailGroupMessageNewRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: message_new) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailGroup> MessagePostAsync(MailGroupMessagePostRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: message_post) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<MailGroup> MessageUpdateAsync(MailGroupMessageUpdateRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: message_update) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailGroup> OpenAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: action_open) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailGroup> SendGuidelinesAsync(MailGroupSendGuidelinesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: action_send_guidelines) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}