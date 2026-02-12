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
    [Module("Sms", Category = "Sales", Depends = new[] { "base", "iap_mail", "mail", "phone_validation" })]
    public partial class SmsTemplateAppService : GenericAppService<SmsTemplate>, ISmsTemplateAppService
    {
        protected readonly IMailRenderMixinAppService _mailRenderMixinAppService;
        protected readonly ITemplateResetMixinAppService _templateResetMixinAppService;
        public SmsTemplateAppService(IRepository<SmsTemplate, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailRenderMixinAppService mailRenderMixinAppService, ITemplateResetMixinAppService templateResetMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailRenderMixinAppService = mailRenderMixinAppService;
            _templateResetMixinAppService = templateResetMixinAppService;
        }

        public async Task<SmsTemplate> CopyDataAsync(SmsTemplateCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: sms_template.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SmsTemplate> CreateSidebarActionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: sms_template.py, METHOD: action_create_sidebar_action) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- METHOD SOURCE (MODULE: event_sms, FILE: sms_template.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: sms, FILE: sms_template.py, METHOD: unlink) ---
            */
            return await base.UnlinkAsync(ids);
        }

        public async Task<SmsTemplate> UnlinkSidebarActionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: sms_template.py, METHOD: action_unlink_sidebar_action) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}