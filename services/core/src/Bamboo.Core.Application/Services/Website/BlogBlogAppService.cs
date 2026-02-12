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
    public partial class BlogBlogAppService : GenericAppService<BlogBlog>, IBlogBlogAppService
    {
        protected readonly IMailThreadAppService _mailThreadAppService;
        protected readonly IWebsiteCoverPropertiesMixinAppService _websiteCoverPropertiesMixinAppService;
        protected readonly IWebsiteMultiMixinAppService _websiteMultiMixinAppService;
        protected readonly IWebsiteSearchableMixinAppService _websiteSearchableMixinAppService;
        protected readonly IWebsiteSeoMetadataAppService _websiteSeoMetadataAppService;
        public BlogBlogAppService(IRepository<BlogBlog, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailThreadAppService mailThreadAppService, IWebsiteCoverPropertiesMixinAppService websiteCoverPropertiesMixinAppService, IWebsiteMultiMixinAppService websiteMultiMixinAppService, IWebsiteSearchableMixinAppService websiteSearchableMixinAppService, IWebsiteSeoMetadataAppService websiteSeoMetadataAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailThreadAppService = mailThreadAppService;
            _websiteCoverPropertiesMixinAppService = websiteCoverPropertiesMixinAppService;
            _websiteMultiMixinAppService = websiteMultiMixinAppService;
            _websiteSearchableMixinAppService = websiteSearchableMixinAppService;
            _websiteSeoMetadataAppService = websiteSeoMetadataAppService;
        }

        public async Task<BlogBlog> AllTagsAsync(BlogBlogAllTagsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: all_tags) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<BlogBlog> MessagePostAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: message_post) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}