using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Bamboo.Core.Application.Services
{
    [Module("WebsiteEventMeet", Depends = new[] { "website_event_jitsi" })]
    public class EventMeetingRoomAppService : GenericApplicationService<EventMeetingRoom>, IEventMeetingRoomAppService
    {
        private readonly IChatRoomMixinAppService _chatRoomMixinAppService;
        private readonly IWebsitePublishedMixinAppService _websitePublishedMixinAppService;
        public EventMeetingRoomAppService(IRepository<EventMeetingRoom, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IChatRoomMixinAppService chatRoomMixinAppService, IWebsitePublishedMixinAppService websitePublishedMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _chatRoomMixinAppService = chatRoomMixinAppService;
            _websitePublishedMixinAppService = websitePublishedMixinAppService;
        }

        protected async Task<EventMeetingRoom> ArchiveMeetingRoomsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_meet, FILE: event_meeting_room.py) ---
            // def _archive_meeting_rooms(self):
            // """Archive all non-pinned room with 0 participant if nobody has joined it for a moment."""
            // self.sudo().search([
            //     ("is_pinned", "=", False),
            //     ("active", "=", True),
            //     ("room_participant_count", "=", 0),
            //     ("room_last_activity", "<", fields.Datetime.now() - self._DELAY_CLEAN),
            // ]).active = False
            */
            return default;
        }

        protected async Task<EventMeetingRoom> ComputeWebsiteUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_meet, FILE: event_meeting_room.py) ---
            // def _compute_website_url(self):
            // super(EventMeetingRoom, self)._compute_website_url()
            // for meeting_room in self:
            //     if meeting_room.id:
            //         base_url = meeting_room.event_id.get_base_url()
            //         meeting_room.website_url = '%s/event/%s/meeting_room/%s' % (base_url, self.env["ir.http"]._slug(meeting_room.event_id), self.env["ir.http"]._slug(meeting_room))
            */
            return default;
        }

        public async Task<EventMeetingRoom> OpenWebsiteUrlAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_meet, FILE: event_meeting_room.py) ---
            // def open_website_url(self):
            // """ Overridden to use a relative URL instead of an absolute when website_id is False. """
            // if self.event_id.website_id:
            //     return super().open_website_url()
            // return self.env['website'].get_client_action(f'/event/{self.env["ir.http"]._slug(self.event_id)}/meeting_room/{self.env["ir.http"]._slug(self)}')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}