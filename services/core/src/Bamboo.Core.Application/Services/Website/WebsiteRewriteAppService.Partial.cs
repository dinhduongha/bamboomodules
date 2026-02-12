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
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Services
{
    public partial class WebsiteRewriteAppService
    {

        protected async Task<WebsiteRewrite> CheckUrlToInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_rewrite.py, METHOD: _check_url_to) ---
            */
            return default;
        }

        protected async Task<WebsiteRewrite> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_rewrite.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<WebsiteRewrite> InvalidateRoutingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_rewrite.py, METHOD: _invalidate_routing) ---
            */
            return default;
        }

        protected async Task<WebsiteRewrite> OnchangeRouteIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_rewrite.py, METHOD: _onchange_route_id) ---
            */
            return default;
        }
    }
}