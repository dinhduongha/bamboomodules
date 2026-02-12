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
    public partial class ImLivechatChannelAppService : GenericAppService<ImLivechatChannel>, IImLivechatChannelAppService
    {
        protected readonly IRatingParentMixinAppService _ratingParentMixinAppService;
        public ImLivechatChannelAppService(IRepository<ImLivechatChannel, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IRatingParentMixinAppService ratingParentMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _ratingParentMixinAppService = ratingParentMixinAppService;
        }

        public override async Task<ImLivechatChannel> CreateAsync(CreateRequestDto<ImLivechatChannel> input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_livechat, FILE: im_livechat_channel.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<ImLivechatChannel> GetLivechatInfoAsync(ImLivechatChannelGetLivechatInfoRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: get_livechat_info) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ImLivechatChannel> JoinAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: action_join) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ImLivechatChannel> QuitAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: action_quit) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ImLivechatChannel> ViewChatbotScriptsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: action_view_chatbot_scripts) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ImLivechatChannel> ViewRatingAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: action_view_rating) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<List<Dictionary<string, object>>> WebReadAsync(ImLivechatChannelWebReadRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: web_read) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}