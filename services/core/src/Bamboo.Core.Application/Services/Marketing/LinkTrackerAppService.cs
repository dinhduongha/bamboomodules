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
    [Module("LinkTrackerModule", Category = "Marketing", Depends = new[] { "utm", "mail" })]
    public partial class LinkTrackerAppService : GenericAppService<LinkTracker>, ILinkTrackerAppService
    {
        protected readonly IUtmMixinAppService _utmMixinAppService;
        public LinkTrackerAppService(IRepository<LinkTracker, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IUtmMixinAppService utmMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _utmMixinAppService = utmMixinAppService;
        }

        [ApiModel]
        public async Task<LinkTracker> ConvertLinksAsync(LinkTrackerConvertLinksRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py, METHOD: convert_links) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<LinkTracker> GetUrlFromCodeAsync(LinkTrackerGetUrlFromCodeRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py, METHOD: get_url_from_code) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<LinkTracker> RecentLinksAsync(LinkTrackerRecentLinksRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py, METHOD: recent_links) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<LinkTracker> SearchOrCreateAsync(LinkTrackerSearchOrCreateRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py, METHOD: search_or_create) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<LinkTracker> ViewStatisticsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py, METHOD: action_view_statistics) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<LinkTracker> VisitPageAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py, METHOD: action_visit_page) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<LinkTracker> VisitPageStatisticsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_links, FILE: link_tracker.py, METHOD: action_visit_page_statistics) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}