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
    [Module("ImLivechat", Category = "Website", Depends = new[] { "mail", "rating", "digest", "utm" })]
    public partial class ImLivechatChannelMemberHistoryAppService : GenericAppService<ImLivechatChannelMemberHistory>, IImLivechatChannelMemberHistoryAppService
    {

        public ImLivechatChannelMemberHistoryAppService(IRepository<ImLivechatChannelMemberHistory, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        [ApiModel]
        public async Task<ImLivechatChannelMemberHistory> OpenDiscussChannelViewAsync(ImLivechatChannelMemberHistoryOpenDiscussChannelViewRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel_member_history.py, METHOD: action_open_discuss_channel_view) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}