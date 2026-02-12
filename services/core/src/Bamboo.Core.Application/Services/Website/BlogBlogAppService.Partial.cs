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
    public partial class BlogBlogAppService
    {

        protected async Task<BlogBlog> ComputeBlogPostCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _compute_blog_post_count) ---
            */
            return default;
        }

        protected async Task<BlogBlog> DefaultSequenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _default_sequence) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<BlogBlog> SearchGetDetailInternalAsync(object website, object order, object options)
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _search_get_detail) ---
            */
            return default;
        }

        protected async Task<BlogBlog> SearchRenderResultsInternalAsync(object fetch_fields, object mapping, object icon, object limit)
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _search_render_results) ---
            */
            return default;
        }
    }
}