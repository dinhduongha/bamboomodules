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
    [Module("Mail", Category = "Productivity", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public partial class MailMessageAppService : GenericAppService<MailMessage>, IMailMessageAppService
    {
        protected readonly IBusListenerMixinAppService _busListenerMixinAppService;
        public MailMessageAppService(IRepository<MailMessage, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IBusListenerMixinAppService busListenerMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _busListenerMixinAppService = busListenerMixinAppService;
        }

        public async Task<MailMessage> CancelLetterAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: mail_message.py, METHOD: cancel_letter) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailMessage> ExportDataAsync(MailMessageExportDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: export_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailMessage> FetchAsync(MailMessageFetchRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: fetch) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<MailMessage> MarkAllAsReadAsync(MailMessageMarkAllAsReadRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: mark_all_as_read) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailMessage> OpenDocumentAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: action_open_document) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailMessage> PortalMessageFormatAsync(MailMessagePortalMessageFormatRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: portal, FILE: mail_message.py, METHOD: portal_message_format) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailMessage> SendLetterAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: mail_message.py, METHOD: send_letter) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailMessage> SetMessageDoneAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: set_message_done) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailMessage> ToggleMessageStarredAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: toggle_message_starred) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<MailMessage> UnstarAllAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: unstar_all) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<MailMessage> input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: mail_message.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}