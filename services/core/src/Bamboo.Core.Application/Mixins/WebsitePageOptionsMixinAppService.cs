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
    [Module("website", Category = "Website", Depends = new[] { "digest", "web", "html_editor", "http_routing", "portal", "social_media", "auth_signup", "mail", "google_recaptcha", "utm", "html_builder" })]
    public partial class WebsitePageOptionsMixinAppService : ApplicationService, IWebsitePageOptionsMixinAppService
    {

        public WebsitePageOptionsMixinAppService() 
        {

        }

        public async Task<TEntity> ActionPageDebugViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: action_page_debug_view) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AllowCacheInsertionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object layout) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _allow_cache_insertion) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AllowToUseCacheInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _allow_to_use_cache) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ClonePageAsync<TEntity>(IEnumerable<TEntity> entities, Guid page_id, object page_name, object clone_menu) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: clone_page) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanPublishInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _compute_can_publish) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsHomepageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _compute_is_homepage) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _compute_visible) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _compute_website_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _compute_website_url) ---
            */
            return default;
        }

        public async Task<TEntity> ConvertToBaseModelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: theme_models.py, METHOD: _convert_to_base_model) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: copy_data) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetCacheKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _get_cache_key) ---
            */
            return default;
        }

        public async Task<TEntity> GetMostSpecificPagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _get_most_specific_pages) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPageInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _get_page_info) ---
            */
            return default;
        }

        public async Task<TEntity> GetResponseCachedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _get_response_cached) ---
            */
            return default;
        }

        public async Task<TEntity> GetResponseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _get_response) ---
            */
            return default;
        }

        public async Task<TEntity> GetResponseRawInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _get_response_raw) ---
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteMetaAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: get_website_meta) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PostProcessResponseFromCacheInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request, object response) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _post_process_response_from_cache) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchFetchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object search_detail, object search, object limit, object order) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _search_fetch) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchGetDetailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website, object order, object options) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _search_get_detail) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: write) ---
            */
            return default;
        }
    }
}