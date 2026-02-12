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
    public partial class WebsiteSnippetFilterAppService : GenericAppService<WebsiteSnippetFilter>, IWebsiteSnippetFilterAppService
    {
        protected readonly IWebsitePublishedMultiMixinAppService _websitePublishedMultiMixinAppService;
        public WebsiteSnippetFilterAppService(IRepository<WebsiteSnippetFilter, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IWebsitePublishedMultiMixinAppService websitePublishedMultiMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _websitePublishedMultiMixinAppService = websitePublishedMultiMixinAppService;
        }

        [ApiModel]
        public override async Task<WebsiteSnippetFilter> DefaultGetAsync(DefaultGetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_snippet_filter.py, METHOD: default_get) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: website_snippet_filter.py, METHOD: default_get) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: website_snippet_filter.py, METHOD: default_get) ---
            */
            return await base.DefaultGetAsync(input);
        }
    }
}