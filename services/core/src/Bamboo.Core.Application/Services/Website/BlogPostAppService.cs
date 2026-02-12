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
    [Module("WebsiteBlog", Category = "Website", Depends = new[] { "website_mail", "website_partner", "html_builder" })]
    public partial class BlogPostAppService : GenericAppService<BlogPost>, IBlogPostAppService
    {
        protected readonly IMailThreadAppService _mailThreadAppService;
        protected readonly IWebsiteCoverPropertiesMixinAppService _websiteCoverPropertiesMixinAppService;
        protected readonly IWebsitePageVisibilityOptionsMixinAppService _websitePageVisibilityOptionsMixinAppService;
        protected readonly IWebsitePublishedMultiMixinAppService _websitePublishedMultiMixinAppService;
        protected readonly IWebsiteSearchableMixinAppService _websiteSearchableMixinAppService;
        protected readonly IWebsiteSeoMetadataAppService _websiteSeoMetadataAppService;
        public BlogPostAppService(IRepository<BlogPost, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailThreadAppService mailThreadAppService, IWebsiteCoverPropertiesMixinAppService websiteCoverPropertiesMixinAppService, IWebsitePageVisibilityOptionsMixinAppService websitePageVisibilityOptionsMixinAppService, IWebsitePublishedMultiMixinAppService websitePublishedMultiMixinAppService, IWebsiteSearchableMixinAppService websiteSearchableMixinAppService, IWebsiteSeoMetadataAppService websiteSeoMetadataAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailThreadAppService = mailThreadAppService;
            _websiteCoverPropertiesMixinAppService = websiteCoverPropertiesMixinAppService;
            _websitePageVisibilityOptionsMixinAppService = websitePageVisibilityOptionsMixinAppService;
            _websitePublishedMultiMixinAppService = websitePublishedMultiMixinAppService;
            _websiteSearchableMixinAppService = websiteSearchableMixinAppService;
            _websiteSeoMetadataAppService = websiteSeoMetadataAppService;
        }

        public async Task<BlogPost> CopyDataAsync(BlogPostCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}