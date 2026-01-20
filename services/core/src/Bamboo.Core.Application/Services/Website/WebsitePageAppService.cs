using Volo.Abp.ObjectMapping;
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
    [Module("WebsiteModule", Category = "Website", Depends = new[] { "digest", "web", "html_editor", "http_routing", "portal", "social_media", "auth_signup", "mail", "google_recaptcha", "utm", "html_builder" })]
    public partial class WebsitePageAppService : GenericApplicationService<WebsitePage>, IWebsitePageAppService
    {
        private readonly IWebsitePageOptionsMixinAppService _websitePageOptionsMixinAppService;
        private readonly IWebsitePublishedMultiMixinAppService _websitePublishedMultiMixinAppService;
        private readonly IWebsiteSearchableMixinAppService _websiteSearchableMixinAppService;
        public WebsitePageAppService(IRepository<WebsitePage, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IWebsitePageOptionsMixinAppService websitePageOptionsMixinAppService, IWebsitePublishedMultiMixinAppService websitePublishedMultiMixinAppService, IWebsiteSearchableMixinAppService websiteSearchableMixinAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
            _websitePageOptionsMixinAppService = websitePageOptionsMixinAppService;
            _websitePublishedMultiMixinAppService = websitePublishedMultiMixinAppService;
            _websiteSearchableMixinAppService = websiteSearchableMixinAppService;
        }

        protected async Task<WebsitePage> AllowCacheInsertionInternalAsync(object layout)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _allow_cache_insertion(self, layout):
            // """ Determines whether a page is allowed to be served from the cache
            // based on the current request, URL, or session.
            // """
            // return True
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website_page.py) ---
            // def _allow_cache_insertion(self, layout):
            // return ' data-order-id=' not in layout and super()._allow_cache_insertion(layout)
            */
            return default;
        }

        protected async Task<WebsitePage> AllowToUseCacheInternalAsync(object request)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _allow_to_use_cache(self, request):
            // """ Checks if the generated HTML content is eligible for caching. This
            // is useful for preventing sensitive or dynamic content from being stored.
            // """
            // return (
            //     request.httprequest.method == "GET"
            //     and not request.params  # because the parameters are not part of the cache key
            //     and request.env.user._is_public()  # only cache for unlogged user
            //     and not self._get_page_info(request)['group_ids']  # do not cache elements dependent on security access
            // )
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: website_page.py) ---
            // def _allow_to_use_cache(self, request):
            // if request.httprequest.path == '/job-thank-you':
            //     return False
            // return super()._allow_to_use_cache(request)
            --- ODOO METHOD SOURCE (MODULE: website_project, FILE: website_page.py) ---
            // def _allow_to_use_cache(self, request):
            // if request.httprequest.path == '/your-task-has-been-submitted':
            //     return False
            // return super()._allow_to_use_cache(request)
            */
            return default;
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
            // # Note: this `if`'s purpose it to optimize the way this is computed for
            // # multiple records.
            // if self.env.user.has_group('website.group_website_designer'):
            //     for record in self:
            //         record.can_publish = True
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

        protected async Task<WebsitePage> GetCacheKeyInternalAsync(object request)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _get_cache_key(self, request):
            // """ Allows for supplementing the base cache key with custom components
            // (e.g., from the URL or session). This is essential for ensuring that
            // the cache serves the correct version of a page based on specific
            // parameters like user language or currency.
            // """
            // return (request.website.id, request.lang.code, request.httprequest.path, request.session.debug)
            */
            return default;
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
            //     self.env['website'].browse(self.env.context.get('website_id')).website_domain()
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

        protected async Task<WebsitePage> GetPageInfoInternalAsync(object request)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _get_page_info(self, request) -> dict | None:
            // req_page = request.httprequest.path
            // 
            // # specific page first
            // page_domain = Domain('url', '=', req_page) & request.website.website_domain()
            // page = self.sudo().search_fetch(page_domain, order='website_id asc', limit=1)
            // 
            // # case insensitive search
            // if not page:
            //     page_domain = Domain('url', '=ilike', req_page) & request.website.website_domain()
            //     page = self.sudo().search_fetch(page_domain, order='website_id asc', limit=1)
            // 
            // if page:
            //     return {
            //         'id': page.id,
            //         'url': page.url,
            //         'view_id': page.view_id.id,
            //         'group_ids': page.group_ids.ids,
            //     }
            */
            return default;
        }

        protected async Task<WebsitePage> GetResponseCachedInternalAsync(object request)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _get_response_cached(self, request) -> tuple[http.Response, int, str]:
            // """ Returns the response corresponding to the request.
            // If the response exists and `_allow_cache_insertio` return True, this
            // response is cached.
            // """
            // cache_key = self._get_cache_key(request)
            // response = self._get_response_raw(request)
            // result = response, cache_key
            // 
            // if not response:
            //     raise PageCannotBeCached(result)
            // 
            // response.flatten()
            // if not self._allow_cache_insertion(response.response[-1]):
            //     raise PageCannotBeCached(result)
            // 
            // return result
            */
            return default;
        }

        protected async Task<WebsitePage> GetResponseInternalAsync(object request)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _get_response(self, request):
            // """ Returns the response corresponding to the request.
            // The response may or may not come from the cache.
            // 
            // The management and logic for this cache are placed directly on the
            // `website.page` model, as it is the source of the HTML response for these
            // records. This approach makes it easy to control caching behavior through
            // a few new, overridable methods:
            // -  `_allow_to_use_cache`
            // -  `_allow_cache_insertion`
            // -  `_post_process_response_from_cache`
            // - `_get_cache_key`
            // 
            // The cache is an ORM cache from `_get_response_cached` with an added
            // mechanism to update its values. After a certain period, the system will
            // fetch the true response from `_get_response_raw` and update the cached
            // value. This approach reduces the need for frequent `clear_caches` for
            // non-critical changes while ensuring that the cached data remains
            // accurate over time.
            // """
            // self.ensure_one()
            // if self._allow_to_use_cache(request):
            //     try:
            //         response, cache_key = self._get_response_cached(request)
            //     except PageCannotBeCached as notCache:
            //         if notCache.result:
            //             return notCache.result[0]
            // 
            //     if time.time() < response.time + self._CACHE_DURATION:
            //         resp = http.Response(
            //             headers=response.headers.copy(),
            //             mimetype=response.mimetype,
            //             content_type=response.content_type,
            //             status=response.status,
            //             response=[response.response[0]],
            //         )
            //         self._post_process_response_from_cache(request, resp)
            //         return resp
            // 
            //     # The cached response is too old and considered out-of-date. Get it
            //     # from scratch and update the cache accordingly.
            //     response = self._get_response_raw(request)
            //     self._get_response_cached.__cache__.add_value(self, request, cache_value=(response, cache_key))
            //     return response
            // 
            // return self._get_response_raw(request)
            */
            return default;
        }

        protected async Task<WebsitePage> GetResponseRawInternalAsync(object request)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _get_response_raw(self, request) -> http.Response | None:
            // """ Returns the raw response associated with the current request.
            // This method is called by `_get_response_cached`, which handles caching
            // the result. It is also called directly by `_get_response` if
            // `_allow_to_use_cache` returns False.
            // """
            // req_page = request.httprequest.path
            // 
            // # fetch all prefetchable fields to get all data at once. If we use the
            // # default fetch(), another query is necessary to get the page fields
            // # like 'website_meta'.
            // fields_to_fetch = [name for name, field in self._fields.items() if field.prefetch]
            // self.fetch(fields_to_fetch)
            // 
            // fields_to_fetch = [name for name, field in self.view_id._fields.items() if field.prefetch]
            // self.view_id.fetch(fields_to_fetch)
            // 
            // if (
            //     (self.env.user.has_group('website.group_website_designer') or self.is_visible)
            //     and (
            //         # If a generic page (niche case) has been COWed and that COWed
            //         # page received a URL change, it should not let you access the
            //         # generic page anymore, despite having a different URL.
            //         self.website_id
            //         or self.view_id.id == self.env['ir.ui.view'].with_context(website_id=request.website.id)._get_cached_template_info(self.view_id.key)['id']
            //     )
            // ):
            //     _, ext = os.path.splitext(req_page)
            //     response = request.render(self.view_id.id, {
            //         'main_object': self,
            //     }, mimetype=EXTENSION_TO_WEB_MIMETYPES.get(ext, 'text/html'))
            //     response.time = time.time()
            //     return response
            // 
            // return None
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

        protected async Task<WebsitePage> PostProcessResponseFromCacheInternalAsync(object request, object response)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _post_process_response_from_cache(self, request: http.Request, response: http.Response) -> None:
            // """ A hook called after a response is retrieved from the cache. This
            // method allows for post-processing, such as incrementing counters or
            // modifying HTTP headers, without regenerating the entire page.
            // """
            // csrf_token = request.csrf_token(None)
            // html = response.response[0]
            // html = re.sub(r'csrf_token: "[^"]+"', f'csrf_token: {csrf_token!r}', html)
            // html = re.sub(r'name="csrf_token" value="[^"]+"', f'name="csrf_token" value={csrf_token!r}', html)
            // response.response = [html]
            // 
            // # used for _register_website_track
            // response._cached_view_id = self._get_page_info(request)['view_id']
            // response._cached_page = self
            --- ODOO METHOD SOURCE (MODULE: website_livechat, FILE: website_page.py) ---
            // def _post_process_response_from_cache(self, request, response):
            // super()._post_process_response_from_cache(request, response)
            // request.website._get_livechat_channel_info()
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website_page.py) ---
            // def _post_process_response_from_cache(self, request, response):
            // super()._post_process_response_from_cache(request, response)
            // 
            // order_id = request.session.get('sale_order_id', '')
            // quantity = request.session.get('website_sale_cart_quantity', 0)
            // if not order_id or not quantity:
            //     return
            // 
            // # update generated html from "webiste_sale.header_cart_link" used on all page
            // 
            // my_cart_quantity_re = re.compile(r"""
            //     <sup\s
            //     class="(?P<classname>my_cart_quantity[^"]*)"
            //     (?P<attributes>[^>]*?)
            //     >
            //     (?P<quantity>[^<]*)
            //     </sup>
            //     """, re.VERBOSE)
            // 
            // html = response.response[0]
            // cache_quantity = re.search(my_cart_quantity_re, html)
            // classname = cache_quantity.group('classname').replace('d-none', '') + ('' if quantity else 'd-none')
            // attributes = cache_quantity.group('attributes') + (f' data-order-id="{order_id}"' if quantity else '')
            // html_quantity = f'''<sup class="{classname}"{attributes}>{quantity}</sup>'''
            // html = html.replace(cache_quantity.group(0), html_quantity)
            // 
            // response.response = [html]
            */
            return default;
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
            // base_domain = Domain.AND(search_detail['base_domain'])
            // domain = self._search_build_domain([base_domain], search, fields, search_detail.get('search_extra'))
            // most_specific_pages = self.env['website']._get_website_pages(
            //     domain=base_domain, order=order
            // )
            // results = most_specific_pages.filtered_domain(domain)  # already sudo
            // v_arch_db = self.env['ir.ui.view']._field_to_sql('v', 'arch_db')
            // 
            // if with_description and search and most_specific_pages:
            //     # Perform search in translations
            //     # TODO Remove when domains will support xml_translate fields
            //     rows = self.env.execute_query(SQL(
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
            //     ids = {row[0] for row in rows}
            //     if ids:
            //         ids.update(results.ids)
            //         domain = base_domain & Domain('id', 'in', ids)
            //         model = self.sudo() if search_detail.get('requires_sudo') else self
            //         results = model.search(
            //             domain,
            //             limit=len(ids),
            //             order=search_detail.get('order', order)
            //         )
            // 
            // def filter_page(search, page, all_pages):
            //     # Exclude pages that do not pass ACL.
            //     Rule = page.env['ir.rule'].sudo(False)
            //     if not page.filtered_domain(Rule._compute_domain('website.page', 'read')):
            //         return False
            //     if not page.view_id.filtered_domain(Rule._compute_domain('ir.ui.view', 'read')):
            //         return False
            //     if search and with_description:
            //         # Search might have matched words in the xml tags and parameters therefore we make
            //         # sure the terms actually appear inside the text.
            //         text = '%s %s %s' % (page.name, page.url, text_from_html(page.arch))
            //         pattern = '|'.join([re.escape(search_term) for search_term in search.split()])
            //         return re.findall('(%s)' % pattern, text, flags=re.I) if pattern else False
            //     return True
            // results = results.filtered(lambda result: filter_page(search, result, results))
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
            //     domain.append([
            //         ('website_published', '=', True),
            //         ('website_indexed', '=', True),
            //     ])
            //     # Prevent accessing unaccessible pages
            //     domain.append([('visibility', '!=', 'password')])
            //     if website.is_public_user():
            //         domain.append([('visibility', '!=', 'connected')])
            //     domain.append(Domain.OR([
            //         [('group_ids', '=', False)], [('group_ids', 'in', self.env.user.group_ids.ids)]
            //     ]))
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