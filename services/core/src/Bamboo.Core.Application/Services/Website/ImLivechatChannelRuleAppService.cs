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
    public partial class ImLivechatChannelRuleAppService : GenericAppService<ImLivechatChannelRule>, IImLivechatChannelRuleAppService
    {

        public ImLivechatChannelRuleAppService(IRepository<ImLivechatChannelRule, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<ImLivechatChannelRule> MatchRuleAsync(ImLivechatChannelRuleMatchRuleRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: match_rule) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}