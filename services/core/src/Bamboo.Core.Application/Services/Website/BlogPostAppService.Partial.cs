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
    public partial class BlogPostAppService
    {

        protected async Task<BlogPost> CheckForPublicationInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _check_for_publication) ---
            */
            return default;
        }

        protected async Task<BlogPost> ComputePostDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _compute_post_date) ---
            */
            return default;
        }

        protected async Task<BlogPost> ComputeTeaserInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _compute_teaser) ---
            */
            return default;
        }

        protected async Task<BlogPost> ComputeWebsiteUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _compute_website_url) ---
            */
            return default;
        }

        protected async Task<BlogPost> DefaultContentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _default_content) ---
            */
            return default;
        }

        protected async Task<BlogPost> DefaultWebsiteMetaInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _default_website_meta) ---
            */
            return default;
        }

        protected async Task<BlogPost> GetAccessActionInternalAsync(object access_uid, object force_website)
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _get_access_action) ---
            */
            return default;
        }

        protected async Task<BlogPost> NotifyGetRecipientsGroupsInternalAsync(object message, object model_description, object msg_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _notify_get_recipients_groups) ---
            */
            return default;
        }

        protected async Task<BlogPost> NotifyThreadByInboxInternalAsync(object message, object recipients_data, object msg_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _notify_thread_by_inbox) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<BlogPost> SearchGetDetailInternalAsync(object website, object order, object options)
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _search_get_detail) ---
            */
            return default;
        }

        protected async Task<BlogPost> SetPostDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _set_post_date) ---
            */
            return default;
        }

        protected async Task<BlogPost> SetTeaserInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _set_teaser) ---
            */
            return default;
        }
    }
}