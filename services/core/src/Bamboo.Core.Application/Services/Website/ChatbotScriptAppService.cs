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
    [Module("ImLivechat", Category = "Website", Depends = new[] { "mail", "rating", "digest", "utm" })]
    public partial class ChatbotScriptAppService : GenericAppService<ChatbotScript>, IChatbotScriptAppService
    {
        protected readonly IImageMixinAppService _imageMixinAppService;
        protected readonly IUtmSourceMixinAppService _utmSourceMixinAppService;
        public ChatbotScriptAppService(IRepository<ChatbotScript, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IImageMixinAppService imageMixinAppService, IUtmSourceMixinAppService utmSourceMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _imageMixinAppService = imageMixinAppService;
            _utmSourceMixinAppService = utmSourceMixinAppService;
        }

        public async Task<ChatbotScript> CopyDataAsync(ChatbotScriptCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ChatbotScript> TestScriptAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_livechat, FILE: chatbot_script.py, METHOD: action_test_script) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ChatbotScript> ViewLeadsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm_livechat, FILE: chatbot_script.py, METHOD: action_view_leads) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ChatbotScript> ViewLivechatChannelsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: action_view_livechat_channels) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}