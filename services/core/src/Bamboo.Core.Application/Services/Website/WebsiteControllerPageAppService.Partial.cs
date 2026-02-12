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
    public partial class WebsiteControllerPageAppService
    {

        protected async Task<WebsiteControllerPage> CheckUserHasModelAccessInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_controller_page.py, METHOD: _check_user_has_model_access) ---
            */
            return default;
        }

        protected async Task<WebsiteControllerPage> ComputeNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_controller_page.py, METHOD: _compute_name) ---
            */
            return default;
        }

        protected async Task<WebsiteControllerPage> ComputeNameSlugifiedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_controller_page.py, METHOD: _compute_name_slugified) ---
            */
            return default;
        }

        protected async Task<WebsiteControllerPage> ComputeUrlDemoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_controller_page.py, METHOD: _compute_url_demo) ---
            */
            return default;
        }

        protected async Task<WebsiteControllerPage> DefaultIsPublishedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_controller_page.py, METHOD: _default_is_published) ---
            */
            return default;
        }

        protected async Task<WebsiteControllerPage> InverseNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_controller_page.py, METHOD: _inverse_name) ---
            */
            return default;
        }

        protected async Task<WebsiteControllerPage> InverseNameSlugifiedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_controller_page.py, METHOD: _inverse_name_slugified) ---
            */
            return default;
        }
    }
}