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
    [Module("WebsiteModule", Category = "Website", Depends = new[] { "digest", "web", "html_editor", "http_routing", "portal", "social_media", "auth_signup", "mail", "google_recaptcha", "utm", "html_builder" })]
    public partial class WebsitePageAppService : GenericAppService<WebsitePage>, IWebsitePageAppService
    {
        protected readonly IWebsitePageOptionsMixinAppService _websitePageOptionsMixinAppService;
        protected readonly IWebsitePublishedMultiMixinAppService _websitePublishedMultiMixinAppService;
        protected readonly IWebsiteSearchableMixinAppService _websiteSearchableMixinAppService;
        public WebsitePageAppService(IRepository<WebsitePage, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IWebsitePageOptionsMixinAppService websitePageOptionsMixinAppService, IWebsitePublishedMultiMixinAppService websitePublishedMultiMixinAppService, IWebsiteSearchableMixinAppService websiteSearchableMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _websitePageOptionsMixinAppService = websitePageOptionsMixinAppService;
            _websitePublishedMultiMixinAppService = websitePublishedMultiMixinAppService;
            _websiteSearchableMixinAppService = websiteSearchableMixinAppService;
        }

        [ApiModel]
        public async Task<WebsitePage> ClonePageAsync(WebsitePageClonePageRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: clone_page) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<WebsitePage> CopyDataAsync(WebsitePageCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<WebsitePage> GetWebsiteMetaAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: get_website_meta) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<WebsitePage> PageDebugViewAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: action_page_debug_view) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}