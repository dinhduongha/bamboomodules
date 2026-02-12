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
    public partial class LinkTrackerAppService
    {

        protected async Task<LinkTracker> CheckUnicityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py, METHOD: _check_unicity) ---
            */
            return default;
        }

        protected async Task<LinkTracker> ComputeAbsoluteUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py, METHOD: _compute_absolute_url) ---
            */
            return default;
        }

        protected async Task<LinkTracker> ComputeCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py, METHOD: _compute_code) ---
            */
            return default;
        }

        protected async Task<LinkTracker> ComputeCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py, METHOD: _compute_count) ---
            */
            return default;
        }

        protected async Task<LinkTracker> ComputeRedirectedUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py, METHOD: _compute_redirected_url) ---
            */
            return default;
        }

        protected async Task<LinkTracker> ComputeShortUrlHostInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py, METHOD: _compute_short_url_host) ---
            --- METHOD SOURCE (MODULE: website_links, FILE: link_tracker.py, METHOD: _compute_short_url_host) ---
            */
            return default;
        }

        protected async Task<LinkTracker> ComputeShortUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py, METHOD: _compute_short_url) ---
            */
            return default;
        }

        protected async Task<LinkTracker> ConvertLinksTextInternalAsync(object body, object vals, object blacklist)
        {
            /*
            --- METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py, METHOD: _convert_links_text) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<LinkTracker> GetTitleFromUrlInternalAsync(object url)
        {
            /*
            --- METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py, METHOD: _get_title_from_url) ---
            */
            return default;
        }

        protected async Task<LinkTracker> InverseCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py, METHOD: _inverse_code) ---
            */
            return default;
        }
    }
}