using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Bamboo.Core.Application.Services
{
    [Module("WebsiteBlog", Depends = new[] { "website_mail", "website_partner" })]
    public class BlogBlogAppService : GenericApplicationService<BlogBlog>, IBlogBlogAppService
    {
        private readonly IMailThreadAppService _mailThreadAppService;
        private readonly IWebsiteCoverPropertiesMixinAppService _websiteCoverPropertiesMixinAppService;
        private readonly IWebsiteMultiMixinAppService _websiteMultiMixinAppService;
        private readonly IWebsiteSearchableMixinAppService _websiteSearchableMixinAppService;
        private readonly IWebsiteSeoMetadataAppService _websiteSeoMetadataAppService;
        public BlogBlogAppService(IRepository<BlogBlog, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailThreadAppService mailThreadAppService, IWebsiteCoverPropertiesMixinAppService websiteCoverPropertiesMixinAppService, IWebsiteMultiMixinAppService websiteMultiMixinAppService, IWebsiteSearchableMixinAppService websiteSearchableMixinAppService, IWebsiteSeoMetadataAppService websiteSeoMetadataAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailThreadAppService = mailThreadAppService;
            _websiteCoverPropertiesMixinAppService = websiteCoverPropertiesMixinAppService;
            _websiteMultiMixinAppService = websiteMultiMixinAppService;
            _websiteSearchableMixinAppService = websiteSearchableMixinAppService;
            _websiteSeoMetadataAppService = websiteSeoMetadataAppService;
        }

        public async Task<BlogBlog> AllTagsAsync(Guid id, object @join, object min_limit)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def all_tags(self, join=False, min_limit=1):
            // BlogTag = self.env['blog.tag']
            // req = """
            //     SELECT
            //         p.blog_id, count(*), r.blog_tag_id
            //     FROM
            //         blog_post_blog_tag_rel r
            //             join blog_post p on r.blog_post_id=p.id
            //     WHERE
            //         p.blog_id in %s
            //     GROUP BY
            //         p.blog_id,
            //         r.blog_tag_id
            //     ORDER BY
            //         count(*) DESC
            // """
            // self._cr.execute(req, [tuple(self.ids)])
            // tag_by_blog = {i.id: [] for i in self}
            // all_tags = set()
            // for blog_id, freq, tag_id in self._cr.fetchall():
            //     if freq >= min_limit:
            //         if join:
            //             all_tags.add(tag_id)
            //         else:
            //             tag_by_blog[blog_id].append(tag_id)
            // 
            // if join:
            //     return BlogTag.browse(all_tags)
            // 
            // for blog_id in tag_by_blog:
            //     tag_by_blog[blog_id] = BlogTag.browse(tag_by_blog[blog_id])
            // 
            // return tag_by_blog
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<BlogBlog> ComputeBlogPostCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _compute_blog_post_count(self):
            // for record in self:
            //     record.blog_post_count = len(record.blog_post_ids)
            */
            return default;
        }

        public async Task<BlogBlog> MessagePostAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def message_post(self, *, parent_id=False, subtype_id=False, **kwargs):
            // """ Temporary workaround to avoid spam. If someone replies on a channel
            // through the 'Presentation Published' email, it should be considered as a
            // note as we don't want all channel followers to be notified of this answer. """
            // self.ensure_one()
            // if parent_id:
            //     parent_message = self.env['mail.message'].sudo().browse(parent_id)
            //     if parent_message.subtype_id and parent_message.subtype_id == self.env.ref('website_blog.mt_blog_blog_published'):
            //         subtype_id = self.env.ref('mail.mt_note').id
            // return super(Blog, self).message_post(parent_id=parent_id, subtype_id=subtype_id, **kwargs)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<BlogBlog> SearchGetDetailInternalAsync(object website, object order, object options)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _search_get_detail(self, website, order, options):
            // with_description = options['displayDescription']
            // search_fields = ['name']
            // fetch_fields = ['id', 'name']
            // mapping = {
            //     'name': {'name': 'name', 'type': 'text', 'match': True},
            //     'website_url': {'name': 'url', 'type': 'text', 'truncate': False},
            // }
            // if with_description:
            //     search_fields.append('subtitle')
            //     fetch_fields.append('subtitle')
            //     mapping['description'] = {'name': 'subtitle', 'type': 'text', 'match': True}
            // return {
            //     'model': 'blog.blog',
            //     'base_domain': [website.website_domain()],
            //     'search_fields': search_fields,
            //     'fetch_fields': fetch_fields,
            //     'mapping': mapping,
            //     'icon': 'fa-rss-square',
            //     'order': 'name desc, id desc' if 'name desc' in order else 'name asc, id desc',
            // }
            */
            return default;
        }

        protected async Task<BlogBlog> SearchRenderResultsInternalAsync(object fetch_fields, object mapping, object icon, object limit)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _search_render_results(self, fetch_fields, mapping, icon, limit):
            // results_data = super()._search_render_results(fetch_fields, mapping, icon, limit)
            // for data in results_data:
            //     data['url'] = '/blog/%s' % data['id']
            // return results_data
            */
            return default;
        }
    }
}