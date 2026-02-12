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
    [Module("Event", Category = "Marketing", Depends = new[] { "barcodes", "base_setup", "mail", "phone_validation", "portal", "utm" })]
    public partial class EventEventAppService : GenericAppService<EventEvent>, IEventEventAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        protected readonly IWebsiteCoverPropertiesMixinAppService _websiteCoverPropertiesMixinAppService;
        protected readonly IWebsitePageVisibilityOptionsMixinAppService _websitePageVisibilityOptionsMixinAppService;
        protected readonly IWebsitePublishedMultiMixinAppService _websitePublishedMultiMixinAppService;
        protected readonly IWebsiteSearchableMixinAppService _websiteSearchableMixinAppService;
        protected readonly IWebsiteSeoMetadataAppService _websiteSeoMetadataAppService;
        public EventEventAppService(IRepository<EventEvent, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService, IPosLoadMixinAppService posLoadMixinAppService, IWebsiteCoverPropertiesMixinAppService websiteCoverPropertiesMixinAppService, IWebsitePageVisibilityOptionsMixinAppService websitePageVisibilityOptionsMixinAppService, IWebsitePublishedMultiMixinAppService websitePublishedMultiMixinAppService, IWebsiteSearchableMixinAppService websiteSearchableMixinAppService, IWebsiteSeoMetadataAppService websiteSeoMetadataAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
            _websiteCoverPropertiesMixinAppService = websiteCoverPropertiesMixinAppService;
            _websitePageVisibilityOptionsMixinAppService = websitePageVisibilityOptionsMixinAppService;
            _websitePublishedMultiMixinAppService = websitePublishedMultiMixinAppService;
            _websiteSearchableMixinAppService = websiteSearchableMixinAppService;
            _websiteSeoMetadataAppService = websiteSeoMetadataAppService;
        }

        public override async Task<EventEvent> CopyAsync(CopyRequestDto<EventEvent> input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: copy) ---
            */
            return await base.CopyAsync(input);
        }

        public async Task<EventEvent> CopyDataAsync(EventEventCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<EventEvent> CopyEventMenusAsync(EventEventCopyEventMenusRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: copy_event_menus) ---
            --- METHOD SOURCE (MODULE: website_event_booth, FILE: event_event.py, METHOD: copy_event_menus) ---
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py, METHOD: copy_event_menus) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: copy_event_menus) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<EventEvent> CreateAsync(CreateRequestDto<EventEvent> input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<EventEvent> GenerateLeadsAsync(EventEventGenerateLeadsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_event.py, METHOD: action_generate_leads) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<EventEvent> GetBackendMenuIdAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: get_backend_menu_id) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<EventEvent> GetKioskUrlAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: get_kiosk_url) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<EventEvent> GetSlotTicketsAvailabilityPosAsync(EventEventGetSlotTicketsAvailabilityPosRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_event, FILE: event_event.py, METHOD: get_slot_tickets_availability_pos) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<EventEvent> GoogleMapLinkAsync(EventEventGoogleMapLinkRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: google_map_link) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<EventEvent> InviteContactsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_event, FILE: event_event.py, METHOD: action_invite_contacts) ---
            --- METHOD SOURCE (MODULE: mass_mailing_event_sms, FILE: event.py, METHOD: action_invite_contacts) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<EventEvent> MassMailingAttendeesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_event, FILE: event_event.py, METHOD: action_mass_mailing_attendees) ---
            --- METHOD SOURCE (MODULE: mass_mailing_event_sms, FILE: event.py, METHOD: action_mass_mailing_attendees) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<EventEvent> MassMailingTrackSpeakersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_event_track, FILE: event_event.py, METHOD: action_mass_mailing_track_speakers) ---
            --- METHOD SOURCE (MODULE: mass_mailing_event_track_sms, FILE: event.py, METHOD: action_mass_mailing_track_speakers) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<EventEvent> OpenSlotCalendarAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: action_open_slot_calendar) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<EventEvent> SetDoneAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: action_set_done) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<EventEvent> ToggleBoothMenuAsync(EventEventToggleBoothMenuRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_booth, FILE: event_event.py, METHOD: toggle_booth_menu) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<EventEvent> ToggleExhibitorMenuAsync(EventEventToggleExhibitorMenuRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py, METHOD: toggle_exhibitor_menu) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<EventEvent> ToggleWebsiteMenuAsync(EventEventToggleWebsiteMenuRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: toggle_website_menu) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<EventEvent> ToggleWebsiteTrackAsync(EventEventToggleWebsiteTrackRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: toggle_website_track) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<EventEvent> ToggleWebsiteTrackProposalAsync(EventEventToggleWebsiteTrackProposalRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: toggle_website_track_proposal) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<EventEvent> ViewLinkedOrdersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: event_event.py, METHOD: action_view_linked_orders) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<EventEvent> input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}