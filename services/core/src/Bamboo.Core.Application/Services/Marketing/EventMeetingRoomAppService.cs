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
    [Module("WebsiteEventMeet", Category = "Marketing", Depends = new[] { "website_event_jitsi" })]
    public partial class EventMeetingRoomAppService : GenericAppService<EventMeetingRoom>, IEventMeetingRoomAppService
    {
        protected readonly IChatRoomMixinAppService _chatRoomMixinAppService;
        protected readonly IWebsitePublishedMixinAppService _websitePublishedMixinAppService;
        public EventMeetingRoomAppService(IRepository<EventMeetingRoom, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IChatRoomMixinAppService chatRoomMixinAppService, IWebsitePublishedMixinAppService websitePublishedMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _chatRoomMixinAppService = chatRoomMixinAppService;
            _websitePublishedMixinAppService = websitePublishedMixinAppService;
        }

        public async Task<EventMeetingRoom> OpenWebsiteUrlAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_meet, FILE: event_meeting_room.py, METHOD: open_website_url) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}