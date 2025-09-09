using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Services;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;

namespace Bamboo.Core.Application.Services
{
    [Module("WebsiteModule", Depends = new[] { "digest", "web", "web_editor", "html_editor", "http_routing", "portal", "social_media", "auth_signup", "mail", "google_recaptcha", "utm" })]
    public class WebsitePageAppService : GenericApplicationService<WebsitePage>, IWebsitePageAppService
    {
        private readonly IWebsitePublishedMultiMixinAppService _websitePublishedMultiMixinAppService;
        private readonly IWebsiteSearchableMixinAppService _websiteSearchableMixinAppService;
        public WebsitePageAppService(IRepository<WebsitePage, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IWebsitePublishedMultiMixinAppService websitePublishedMultiMixinAppService, IWebsiteSearchableMixinAppService websiteSearchableMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _websitePublishedMultiMixinAppService = websitePublishedMultiMixinAppService;
            _websiteSearchableMixinAppService = websiteSearchableMixinAppService;
        }

        public async Task<WebsitePage> ClonePageAsync(Guid id, WebsitePageClonePageRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def clone_page(self, page_id, page_name=None, clone_menu=True):
            // """ Clone a page, given its identifier
            //     :param page_id : website.page identifier
            // """
            // page = self.browse(int(page_id))
            // copy_param = dict(name=page_name or page.name, website_id=self.env['website'].get_current_website().id)
            // if page_name:
            //     url = '/' + self.env['ir.http']._slugify(page_name, max_length=1024, path=True)
            //     copy_param['url'] = self.env['website'].get_unique_path(url)
            // 
            // new_page = page.copy(copy_param)
            // # Should not clone menu if the page was cloned from one website to another
            // # Eg: Cloning a generic page (no website) will create a page with a website, we can't clone menu (not same container)
            // if clone_menu and new_page.website_id == page.website_id:
            //     menu = self.env['website.menu'].search([('page_id', '=', page_id)], limit=1)
            //     if menu:
            //         # If the page being cloned has a menu, clone it too
            //         menu.copy({'url': new_page.url, 'name': new_page.name, 'page_id': new_page.id})
            // 
            // return new_page.url
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<WebsitePage> ComputeCanPublishInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _compute_can_publish(self):
            // if self.env.user.has_group('website.group_website_designer'):
            //     for record in self:
            //         record.can_publish = True
            // # FIXME this makes it so no-rights internal users *see* the publish
            // # button for website pages (although they cannot use it)
            // else:
            //     super()._compute_can_publish()
            */
            return default;
        }

        protected async Task<WebsitePage> ComputeIsHomepageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _compute_is_homepage(self):
            // website = self.env['website'].get_current_website()
            // for page in self:
            //     page.is_homepage = page.url == (website.homepage_url or page.website_id == website and '/')
            */
            return default;
        }

        protected async Task<WebsitePage> ComputeVisibleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _compute_visible(self):
            // for page in self:
            //     page.is_visible = page.website_published and (
            //         not page.date_publish or page.date_publish < fields.Datetime.now()
            //     )
            */
            return default;
        }

        protected async Task<WebsitePage> ComputeWebsiteMenuInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _compute_website_menu(self):
            // for page in self:
            //     page.is_in_menu = bool(page.menu_ids)
            */
            return default;
        }

        protected async Task<WebsitePage> ComputeWebsiteUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _compute_website_url(self):
            // for page in self:
            //     page.website_url = page.url
            */
            return default;
        }

        public async Task<WebsitePage> CopyDataAsync(Guid id, WebsitePageCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // if not default:
            //     return vals_list
            // for page, vals in zip(self, vals_list):
            //     if not default.get('view_id'):
            //         new_view = page.view_id.copy({'website_id': default.get('website_id')})
            //         vals['view_id'] = new_view.id
            //         vals['key'] = new_view.key
            //     vals['url'] = default.get('url', self.env['website'].get_unique_path(page.url))
            // return vals_list
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<WebsitePage> GetMostSpecificPagesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _get_most_specific_pages(self):
            // ''' Returns the most specific pages in self. '''
            // ids = []
            // previous_page = None
            // page_keys = self.sudo().search(
            //     self.env['website'].website_domain(website_id=self._context.get('website_id'))
            // ).mapped('key')
            // # Iterate a single time on the whole list sorted on specific-website first.
            // for page in self.sorted(key=lambda p: (p.url, not p.website_id)):
            //     if (
            //         (not previous_page or page.url != previous_page.url)
            //         # If a generic page (niche case) has been COWed and that COWed
            //         # page received a URL change, it should not let you access the
            //         # generic page anymore, despite having a different URL.
            //         and (page.website_id or page_keys.count(page.key) == 1)
            //     ):
            //         ids.append(page.id)
            //     previous_page = page
            // return self.browse(ids)
            */
            return default;
        }

        public async Task<WebsitePage> GetWebsiteMetaAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def get_website_meta(self):
            // self.ensure_one()
            // return self.view_id.get_website_meta()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<WebsitePage> PageDebugViewAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def action_page_debug_view(self):
            // return {
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'ir.ui.view',
            //     'res_id': self.view_id.id,
            //     'view_mode': 'form',
            //     'view_id': self.env.ref('website.view_view_form_extend').id,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<WebsitePage> SearchFetchInternalAsync(object search_detail, object search, object limit, object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _search_fetch(self, search_detail, search, limit, order):
            // with_description = 'description' in search_detail['mapping']
            // # Cannot rely on the super's _search_fetch because the search must be
            // # performed among the most specific pages only.
            // fields = search_detail['search_fields']
            // base_domain = search_detail['base_domain']
            // domain = self._search_build_domain(base_domain, search, fields, search_detail.get('search_extra'))
            // most_specific_pages = self.env['website']._get_website_pages(
            //     domain=expression.AND(base_domain), order=order
            // )
            // results = most_specific_pages.filtered_domain(domain)  # already sudo
            // v_arch_db = self.env['ir.ui.view']._field_to_sql('v', 'arch_db')
            // 
            // if with_description and search and most_specific_pages:
            //     # Perform search in translations
            //     # TODO Remove when domains will support xml_translate fields
            //     self.env.cr.execute(SQL(
            //         """
            //         SELECT DISTINCT %(table)s.id
            //         FROM %(table)s
            //         LEFT JOIN ir_ui_view v ON %(table)s.view_id = v.id
            //         WHERE (v.name ILIKE %(search)s
            //         OR %(v_arch_db)s ILIKE %(search)s)
            //         AND %(table)s.id IN %(ids)s
            //         LIMIT %(limit)s
            //         """,
            //         table=SQL.identifier(self._table),
            //         search=f"%{escape_psql(search)}%",
            //         v_arch_db=v_arch_db,
            //         ids=tuple(most_specific_pages.ids),
            //         limit=len(most_specific_pages.ids),
            //     ))
            //     ids = {row[0] for row in self.env.cr.fetchall()}
            //     if ids:
            //         ids.update(results.ids)
            //         domains = search_detail['base_domain'].copy()
            //         domains.append([('id', 'in', list(ids))])
            //         domain = expression.AND(domains)
            //         model = self.sudo() if search_detail.get('requires_sudo') else self
            //         results = model.search(
            //             domain,
            //             limit=len(ids),
            //             order=search_detail.get('order', order)
            //         )
            // 
            // def filter_page(search, page, all_pages):
            //     # Search might have matched words in the xml tags and parameters therefore we make
            //     # sure the terms actually appear inside the text.
            //     text = '%s %s %s' % (page.name, page.url, text_from_html(page.arch))
            //     pattern = '|'.join([re.escape(search_term) for search_term in search.split()])
            //     return re.findall('(%s)' % pattern, text, flags=re.I) if pattern else False
            // if search and with_description:
            //     results = results.filtered(lambda result: filter_page(search, result, results))
            // return results[:limit], len(results)
            */
            return default;
        }

        protected async Task<WebsitePage> SearchGetDetailInternalAsync(object website, object order, object options)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _search_get_detail(self, website, order, options):
            // with_description = options['displayDescription']
            // # Read access on website.page requires sudo.
            // requires_sudo = True
            // domain = [website.website_domain()]
            // if not self.env.user.has_group('website.group_website_designer'):
            //     # Rule must be reinforced because of sudo.
            //     domain.append([('website_published', '=', True)])
            // 
            // search_fields = ['name', 'url']
            // fetch_fields = ['id', 'name', 'url']
            // mapping = {
            //     'name': {'name': 'name', 'type': 'text', 'match': True},
            //     'website_url': {'name': 'url', 'type': 'text', 'truncate': False},
            // }
            // if with_description:
            //     search_fields.append('arch_db')
            //     fetch_fields.append('arch')
            //     mapping['description'] = {'name': 'arch', 'type': 'text', 'html': True, 'match': True}
            // return {
            //     'model': 'website.page',
            //     'base_domain': domain,
            //     'requires_sudo': requires_sudo,
            //     'search_fields': search_fields,
            //     'fetch_fields': fetch_fields,
            //     'mapping': mapping,
            //     'icon': 'fa-file-o',
            // }
            */
            return default;
        }
    }
}