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
    [Module("BaseAutomationModule", Category = "Sales", Depends = new[] { "base", "digest", "resource", "mail", "sms" })]
    public partial class BaseAutomationAppService : GenericAppService<BaseAutomation>, IBaseAutomationAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        public BaseAutomationAppService(IRepository<BaseAutomation, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<BaseAutomation> OpenScheduledActionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: action_open_scheduled_action) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<BaseAutomation> RotateWebhookUuidAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: action_rotate_webhook_uuid) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<BaseAutomation> ViewWebhookLogsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: action_view_webhook_logs) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}