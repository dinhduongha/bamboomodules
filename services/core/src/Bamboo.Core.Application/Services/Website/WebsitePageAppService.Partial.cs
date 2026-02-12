using System;
using System.Threading.Tasks;
using System.Collections.Generic;
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
    public partial class WebsitePageAppService
    {

        [ApiModel]
        protected async Task<WebsitePage> AllowCacheInsertionInternalAsync(object layout)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _allow_cache_insertion) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: website_page.py, METHOD: _allow_cache_insertion) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<WebsitePage> AllowToUseCacheInternalAsync(object request)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _allow_to_use_cache) ---
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: website_page.py, METHOD: _allow_to_use_cache) ---
            --- METHOD SOURCE (MODULE: website_project, FILE: website_page.py, METHOD: _allow_to_use_cache) ---
            */
            return default;
        }

        protected async Task<WebsitePage> ComputeCanPublishInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _compute_can_publish) ---
            */
            return default;
        }

        protected async Task<WebsitePage> ComputeIsHomepageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _compute_is_homepage) ---
            */
            return default;
        }

        protected async Task<WebsitePage> ComputeVisibleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _compute_visible) ---
            */
            return default;
        }

        protected async Task<WebsitePage> ComputeWebsiteMenuInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _compute_website_menu) ---
            */
            return default;
        }

        protected async Task<WebsitePage> ComputeWebsiteUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _compute_website_url) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<WebsitePage> GetCacheKeyInternalAsync(object request)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _get_cache_key) ---
            */
            return default;
        }

        protected async Task<WebsitePage> GetMostSpecificPagesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _get_most_specific_pages) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<WebsitePage> GetPageInfoInternalAsync(object request)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _get_page_info) ---
            */
            return default;
        }

        protected async Task<WebsitePage> GetResponseCachedInternalAsync(object request)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _get_response_cached) ---
            */
            return default;
        }

        protected async Task<WebsitePage> GetResponseInternalAsync(object request)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _get_response) ---
            */
            return default;
        }

        protected async Task<WebsitePage> GetResponseRawInternalAsync(object request)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _get_response_raw) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<WebsitePage> PostProcessResponseFromCacheInternalAsync(object request, object response)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _post_process_response_from_cache) ---
            --- METHOD SOURCE (MODULE: website_livechat, FILE: website_page.py, METHOD: _post_process_response_from_cache) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: website_page.py, METHOD: _post_process_response_from_cache) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<WebsitePage> SearchFetchInternalAsync(object search_detail, object search, object limit, object order)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _search_fetch) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<WebsitePage> SearchGetDetailInternalAsync(object website, object order, object options)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _search_get_detail) ---
            */
            return default;
        }
    }
}