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
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("website_jitsi", Category = "Website", Depends = new[] { "website" })]
    public partial class ChatRoomMixinAppService : ApplicationService, IChatRoomMixinAppService
    {

        public ChatRoomMixinAppService() 
        {

        }

        public async Task<TEntity> ArchiveMeetingRoomsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_meet, FILE: event_meeting_room.py, METHOD: _archive_meeting_rooms) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCountryFlagUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_country_flag_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_email) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeImage512InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_image_512) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsInOpeningHoursInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_is_in_opening_hours) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMobileInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_mobile) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_phone) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_website_description) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteImageUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_website_image_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_event_meet, FILE: event_meeting_room.py, METHOD: _compute_website_url) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IChatRoomMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_jitsi, FILE: chat_room_mixin.py, METHOD: copy_data) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object values_list) where TEntity : IEntity<Guid>, IChatRoomMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_event_meet, FILE: event_meeting_room.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_jitsi, FILE: chat_room_mixin.py, METHOD: create) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultSponsorTypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _default_sponsor_type_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetBackendMenuIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: get_backend_menu_id) ---
            */
            return default;
        }

        public async Task<TEntity> JitsiSanitizeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IChatRoomMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_jitsi, FILE: chat_room_mixin.py, METHOD: _jitsi_sanitize_name) ---
            */
            return default;
        }

        public async Task<TEntity> MessageGetSuggestedRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _message_get_suggested_recipients) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeExhibitorTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _onchange_exhibitor_type) ---
            */
            return default;
        }

        public async Task<TEntity> OpenWebsiteUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: open_website_url) ---
            --- METHOD SOURCE (MODULE: website_event_meet, FILE: event_meeting_room.py, METHOD: open_website_url) ---
            */
            return default;
        }

        public async Task<TEntity> SynchronizeWithPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname) where TEntity : IEntity<Guid>, IChatRoomMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _synchronize_with_partner) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_jitsi, FILE: chat_room_mixin.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IChatRoomMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_jitsi, FILE: chat_room_mixin.py, METHOD: write) ---
            */
            return default;
        }
    }
}