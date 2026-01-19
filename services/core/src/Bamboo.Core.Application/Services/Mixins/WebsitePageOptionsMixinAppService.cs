using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("website", Category = "Website", Depends = new[] { "digest", "web", "html_editor", "http_routing", "portal", "social_media", "auth_signup", "mail", "google_recaptcha", "utm", "html_builder" })]
    public partial class WebsitePageOptionsMixinAppService : ApplicationService, IWebsitePageOptionsMixinAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public WebsitePageOptionsMixinAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ActionPageDebugViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
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
            return default;
        }

        public async Task<TEntity> AllowCacheInsertionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object layout) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _allow_cache_insertion(self, layout):
            // """ Determines whether a page is allowed to be served from the cache
            // based on the current request, URL, or session.
            // """
            // return True
            */
            return default;
        }

        public async Task<TEntity> AllowToUseCacheInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
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
            */
            return default;
        }

        public async Task<TEntity> ClonePageAsync<TEntity>(IEnumerable<TEntity> entities, Guid page_id, object page_name, object clone_menu) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
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
            return default;
        }

        public async Task<TEntity> ComputeCanPublishInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
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

        public async Task<TEntity> ComputeIsHomepageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
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

        public async Task<TEntity> ComputeVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
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

        public async Task<TEntity> ComputeWebsiteMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _compute_website_menu(self):
            // for page in self:
            //     page.is_in_menu = bool(page.menu_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _compute_website_url(self):
            // for page in self:
            //     page.website_url = page.url
            */
            return default;
        }

        public async Task<TEntity> ConvertToBaseModelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: theme_models.py) ---
            // def _convert_to_base_model(self, website, **kwargs):
            // self.ensure_one()
            // view_id = self.view_id.copy_ids.filtered(lambda x: x.website_id == website)
            // if not view_id:
            //     # inherit_id not yet created, add to the queue
            //     return False
            // 
            // new_page = {
            //     'url': self.url,
            //     'view_id': view_id.id,
            //     'website_indexed': self.website_indexed,
            //     'is_published': self.is_published,
            //     'is_new_page_template': self.is_new_page_template,
            //     'header_overlay': self.header_overlay,
            //     'header_color': self.header_color,
            //     'header_text_color': self.header_text_color,
            //     'header_visible': self.header_visible,
            //     'footer_visible': self.footer_visible,
            //     'theme_template_id': self.id,
            // }
            // return new_page
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
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
            return default;
        }

        public async Task<TEntity> GetCacheKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
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

        public async Task<TEntity> GetMostSpecificPagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
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

        public async Task<TEntity> GetPageInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
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

        public async Task<TEntity> GetResponseCachedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
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

        public async Task<TEntity> GetResponseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
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

        public async Task<TEntity> GetResponseRawInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
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

        public async Task<TEntity> GetWebsiteMetaAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def get_website_meta(self):
            // self.ensure_one()
            // return self.view_id.get_website_meta()
            */
            return default;
        }

        public async Task<TEntity> PostProcessResponseFromCacheInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request, object response) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
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
            */
            return default;
        }

        public async Task<TEntity> SearchFetchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object search_detail, object search, object limit, object order) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
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

        public async Task<TEntity> SearchGetDetailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website, object order, object options) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
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

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def unlink(self):
            // # When a website_page is deleted, the ORM does not delete its
            // # ir_ui_view. So we got to delete it ourself, but only if the
            // # ir_ui_view is not used by another website_page.
            // views_to_delete = self.view_id.filtered(
            //     lambda v: v.page_ids <= self and not v.inherit_children_ids
            // )
            // # Rebind self to avoid unlink already deleted records from `ondelete="cascade"`
            // self = self - views_to_delete.page_ids
            // views_to_delete.unlink()
            // 
            // # Make sure website.is_menu_cache_disabled() will be recomputed
            // if self:
            //     self.env.registry.clear_cache('templates')
            // return super().unlink()
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IWebsitePageOptionsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def write(self, vals):
            // for page in self:
            //     website_id = False
            //     if vals.get('website_id') or page.website_id:
            //         website_id = vals.get('website_id') or page.website_id.id
            // 
            //     # If URL has been edited, slug it
            //     if 'url' in vals:
            //         url = vals['url'] or ''
            //         url = '/' + self.env['ir.http']._slugify(url, max_length=1024, path=True)
            //         if page.url != url:
            //             url = self.env['website'].with_context(website_id=website_id).get_unique_path(url)
            //             page.menu_ids.write({'url': url})
            //             # Sync website's homepage URL
            //             website = self.env['website'].get_current_website()
            //             page_url_normalized = {'homepage_url': page.url}
            //             website._handle_homepage_url(page_url_normalized)
            //             if website.homepage_url == page_url_normalized['homepage_url']:
            //                 website.homepage_url = url
            //         vals['url'] = url
            // 
            //     # If name has changed, check for key uniqueness
            //     if 'name' in vals and page.name != vals['name']:
            //         vals['key'] = self.env['website'].with_context(website_id=website_id).get_unique_key(self.env['ir.http']._slugify(vals['name'] or ''))
            //     if 'visibility' in vals:
            //         if vals['visibility'] != 'restricted_group':
            //             vals['group_ids'] = False
            // 
            // if 'url' in vals or 'visibility' in vals or 'group_ids' in vals:
            //     self.env.registry.clear_cache('templates')   # Clear cache because the response depends on the path and the rendering of the view changes.
            // 
            // return super().write(vals)
            */
            return default;
        }
    }
}