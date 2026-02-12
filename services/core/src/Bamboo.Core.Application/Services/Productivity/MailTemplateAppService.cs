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
    public partial class MailTemplateAppService : GenericAppService<MailTemplate>, IMailTemplateAppService
    {
        protected readonly IMailRenderMixinAppService _mailRenderMixinAppService;
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        protected readonly ITemplateResetMixinAppService _templateResetMixinAppService;
        public MailTemplateAppService(IRepository<MailTemplate, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailRenderMixinAppService mailRenderMixinAppService, IPosLoadMixinAppService posLoadMixinAppService, ITemplateResetMixinAppService templateResetMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailRenderMixinAppService = mailRenderMixinAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
            _templateResetMixinAppService = templateResetMixinAppService;
        }

        public async Task<MailTemplate> CopyDataAsync(MailTemplateCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailTemplate> CreateActionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: create_action) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailTemplate> OpenMailPreviewAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: action_open_mail_preview) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailTemplate> SendMailAsync(MailTemplateSendMailRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: send_mail) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailTemplate> SendMailBatchAsync(MailTemplateSendMailBatchRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: send_mail_batch) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailTemplate> UnlinkActionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: unlink_action) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: mail_template.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: unlink) ---
            */
            return await base.UnlinkAsync(ids);
        }
    }
}