using System;
using System.Threading.Tasks;
using System.Collections.Generic;
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
    public partial class ImLivechatChannelRuleAppService
    {

        protected async Task<ImLivechatChannelRule> IsBotConfiguredInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _is_bot_configured) ---
            */
            return default;
        }

        protected async Task<ImLivechatChannelRule> ToStoreDefaultsInternalAsync(object target)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _to_store_defaults) ---
            */
            return default;
        }
    }
}