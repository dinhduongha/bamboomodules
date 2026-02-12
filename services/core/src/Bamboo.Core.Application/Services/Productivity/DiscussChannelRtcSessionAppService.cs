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
    public partial class DiscussChannelRtcSessionAppService : GenericAppService<DiscussChannelRtcSession>, IDiscussChannelRtcSessionAppService
    {
        protected readonly IBusListenerMixinAppService _busListenerMixinAppService;
        public DiscussChannelRtcSessionAppService(IRepository<DiscussChannelRtcSession, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IBusListenerMixinAppService busListenerMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _busListenerMixinAppService = busListenerMixinAppService;
        }

        public override async Task<DiscussChannelRtcSession> CreateAsync(CreateRequestDto<DiscussChannelRtcSession> input)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_rtc_session.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<DiscussChannelRtcSession> DisconnectAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py, METHOD: action_disconnect) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}