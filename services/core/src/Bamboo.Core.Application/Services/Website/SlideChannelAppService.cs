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
    [Module("WebsiteSlides", Category = "Website", Depends = new[] { "portal_rating", "website", "website_mail", "website_profile" })]
    public partial class SlideChannelAppService : GenericAppService<SlideChannel>, ISlideChannelAppService
    {
        protected readonly IImageMixinAppService _imageMixinAppService;
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IRatingMixinAppService _ratingMixinAppService;
        protected readonly IWebsiteCoverPropertiesMixinAppService _websiteCoverPropertiesMixinAppService;
        protected readonly IWebsitePublishedMultiMixinAppService _websitePublishedMultiMixinAppService;
        protected readonly IWebsiteSearchableMixinAppService _websiteSearchableMixinAppService;
        protected readonly IWebsiteSeoMetadataAppService _websiteSeoMetadataAppService;
        public SlideChannelAppService(IRepository<SlideChannel, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IImageMixinAppService imageMixinAppService, IMailActivityMixinAppService mailActivityMixinAppService, IRatingMixinAppService ratingMixinAppService, IWebsiteCoverPropertiesMixinAppService websiteCoverPropertiesMixinAppService, IWebsitePublishedMultiMixinAppService websitePublishedMultiMixinAppService, IWebsiteSearchableMixinAppService websiteSearchableMixinAppService, IWebsiteSeoMetadataAppService websiteSeoMetadataAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _imageMixinAppService = imageMixinAppService;
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _ratingMixinAppService = ratingMixinAppService;
            _websiteCoverPropertiesMixinAppService = websiteCoverPropertiesMixinAppService;
            _websitePublishedMultiMixinAppService = websitePublishedMultiMixinAppService;
            _websiteSearchableMixinAppService = websiteSearchableMixinAppService;
            _websiteSeoMetadataAppService = websiteSeoMetadataAppService;
        }

        public async Task<SlideChannel> ArchiveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_archive) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SlideChannel> ChannelEnrollAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_channel_enroll) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SlideChannel> ChannelInviteAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_channel_invite) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SlideChannel> CopyDataAsync(SlideChannelCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<SlideChannel> CreateAsync(CreateRequestDto<SlideChannel> input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_slides, FILE: slide_channel.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_slides_forum, FILE: slide_channel.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<SlideChannel> GetBackendMenuIdAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: get_backend_menu_id) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SlideChannel> GrantAccessAsync(SlideChannelGrantAccessRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_grant_access) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SlideChannel> MassMailingAttendeesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_slides, FILE: slide_channel.py, METHOD: action_mass_mailing_attendees) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SlideChannel> MessagePostAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: message_post) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SlideChannel> RedirectToCertifiedMembersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides_survey, FILE: slide_channel.py, METHOD: action_redirect_to_certified_members) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SlideChannel> RedirectToCompletedMembersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_redirect_to_completed_members) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SlideChannel> RedirectToEngagedMembersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_redirect_to_engaged_members) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SlideChannel> RedirectToForumAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides_forum, FILE: slide_channel.py, METHOD: action_redirect_to_forum) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SlideChannel> RedirectToInvitedMembersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_redirect_to_invited_members) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SlideChannel> RedirectToMembersAsync(SlideChannelRedirectToMembersRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_redirect_to_members) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SlideChannel> RefuseAccessAsync(SlideChannelRefuseAccessRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_refuse_access) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SlideChannel> RequestAccessAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_request_access) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SlideChannel> UnarchiveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_unarchive) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SlideChannel> ViewRatingsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_view_ratings) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SlideChannel> ViewSalesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_slides, FILE: slide_channel.py, METHOD: action_view_sales) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SlideChannel> ViewSlidesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_view_slides) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<SlideChannel> input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_slides, FILE: slide_channel.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_slides_forum, FILE: slide_channel.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}