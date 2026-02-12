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
    public partial class WebsiteMenuAppService : GenericAppService<WebsiteMenu>, IWebsiteMenuAppService
    {

        public WebsiteMenuAppService(IRepository<WebsiteMenu, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        [ApiModel]
        public async Task<WebsiteMenu> GetTreeAsync(WebsiteMenuGetTreeRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_menu.py, METHOD: get_tree) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<WebsiteMenu> SaveAsync(WebsiteMenuSaveRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_menu.py, METHOD: save) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: website_menu.py, METHOD: save) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_menu.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: website_menu.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: website_menu.py, METHOD: unlink) ---
            */
            return await base.UnlinkAsync(ids);
        }
    }
}