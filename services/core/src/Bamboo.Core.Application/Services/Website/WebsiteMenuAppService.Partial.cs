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
    public partial class WebsiteMenuAppService
    {

        protected async Task<WebsiteMenu> CleanUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_menu.py, METHOD: _clean_url) ---
            */
            return default;
        }

        protected async Task<WebsiteMenu> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_menu.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<WebsiteMenu> ComputeFieldIsMegaMenuInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_menu.py, METHOD: _compute_field_is_mega_menu) ---
            */
            return default;
        }

        protected async Task<WebsiteMenu> ComputeUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_menu.py, METHOD: _compute_url) ---
            */
            return default;
        }

        protected async Task<WebsiteMenu> ComputeVisibleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_menu.py, METHOD: _compute_visible) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: website_menu.py, METHOD: _compute_visible) ---
            */
            return default;
        }

        protected async Task<WebsiteMenu> DefaultSequenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_menu.py, METHOD: _default_sequence) ---
            */
            return default;
        }

        protected async Task<WebsiteMenu> IsActiveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_menu.py, METHOD: _is_active) ---
            */
            return default;
        }

        protected async Task<WebsiteMenu> SetFieldIsMegaMenuInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_menu.py, METHOD: _set_field_is_mega_menu) ---
            */
            return default;
        }

        protected async Task<WebsiteMenu> UnlinkExceptMasterTagsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_menu.py, METHOD: _unlink_except_master_tags) ---
            */
            return default;
        }

        protected async Task<WebsiteMenu> ValidateParentMenuInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_menu.py, METHOD: _validate_parent_menu) ---
            */
            return default;
        }
    }
}