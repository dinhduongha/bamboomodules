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
    public class WebsiteMenuAppService : GenericApplicationService<WebsiteMenu>, IWebsiteMenuAppService
    {

        public WebsiteMenuAppService(IRepository<WebsiteMenu, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<WebsiteMenu> CleanUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_menu.py) ---
            // def _clean_url(self):
            // # clean the url with heuristic
            // if self.page_id:
            //     url = self.page_id.sudo().url
            // else:
            //     url = self.url
            //     if url and not self.url.startswith('/'):
            //         if '@' in self.url:
            //             if not self.url.startswith('mailto'):
            //                 url = 'mailto:%s' % self.url
            //         elif not self.url.startswith('http'):
            //             url = '/%s' % self.url
            // return url
            */
            return default;
        }

        protected async Task<WebsiteMenu> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_menu.py) ---
            // def _compute_display_name(self):
            // if not self._context.get('display_website') and not self.env.user.has_group('website.group_multi_website'):
            //     return super()._compute_display_name()
            // 
            // for menu in self:
            //     menu_name = menu.name
            //     if menu.website_id:
            //         menu_name += f' [{menu.website_id.name}]'
            //     menu.display_name = menu_name
            */
            return default;
        }

        protected async Task<WebsiteMenu> ComputeFieldIsMegaMenuInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_menu.py) ---
            // def _compute_field_is_mega_menu(self):
            // for menu in self:
            //     menu.is_mega_menu = bool(menu.mega_menu_content)
            */
            return default;
        }

        protected async Task<WebsiteMenu> ComputeVisibleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_menu.py) ---
            // def _compute_visible(self):
            // for menu in self:
            //     visible = True
            //     if menu.page_id and not menu.env.user._is_internal():
            //         page_sudo = menu.page_id.sudo()
            //         if (not page_sudo.is_visible
            //             or (not page_sudo.view_id._handle_visibility(do_raise=False)
            //                 and page_sudo.view_id._get_cached_visibility() != "password")):
            //             visible = False
            // 
            //     if menu.controller_page_id and not menu.env.user._is_internal():
            //         controller_page_sudo = menu.controller_page_id.sudo()
            //         if (not controller_page_sudo.is_published
            //             or (not controller_page_sudo.view_id._handle_visibility(do_raise=False)
            //                 and controller_page_sudo.view_id._get_cached_visibility() != "password")):
            //             visible = False
            // 
            //     menu.is_visible = visible
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: website_menu.py) ---
            // def _compute_visible(self):
            // """ Hide '/shop' menus to the public user if only logged-in users can access it. """
            // shop_menus = self.filtered(lambda m: m.url and m.url[:5] == '/shop')
            // for menu in shop_menus:
            //     menu.is_visible = menu.website_id.has_ecommerce_access()
            // 
            // return super(Menu, self - shop_menus)._compute_visible()
            */
            return default;
        }

        protected async Task<WebsiteMenu> DefaultSequenceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_menu.py) ---
            // def _default_sequence(self):
            // menu = self.search([], limit=1, order="sequence DESC")
            // return menu.sequence or 0
            */
            return default;
        }

        public async Task<WebsiteMenu> GetTreeAsync(Guid id, WebsiteMenuGetTreeRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_menu.py) ---
            // def get_tree(self, website_id, menu_id=None):
            // website = self.env['website'].browse(website_id)
            // 
            // def make_tree(node):
            //     menu_url = node.page_id.url if node.page_id else node.url
            //     menu_node = {
            //         'fields': {
            //             'id': node.id,
            //             'name': node.name,
            //             'url': menu_url,
            //             'new_window': node.new_window,
            //             'is_mega_menu': node.is_mega_menu,
            //             'sequence': node.sequence,
            //             'parent_id': node.parent_id.id,
            //         },
            //         'children': [],
            //         'is_homepage': menu_url == (website.homepage_url or '/'),
            //     }
            //     for child in node.child_id:
            //         menu_node['children'].append(make_tree(child))
            //     return menu_node
            // 
            // menu = menu_id and self.browse(menu_id) or website.menu_id
            // return make_tree(menu)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<WebsiteMenu> IsActiveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_menu.py) ---
            // def _is_active(self):
            // """ To be considered active, a menu should either:
            // 
            // - have its URL matching the request's URL and have no children
            // - or have a children menu URL matching the request's URL
            // 
            // Matching an URL means, either:
            // 
            // - be equal, eg ``/contact/on-site`` vs ``/contact/on-site``
            // - be equal after unslug, eg ``/shop/1`` and ``/shop/my-super-product-1``
            // 
            // Note that saving a menu URL with an anchor or a query string is
            // considered a corner case, and the following applies:
            // 
            // - anchor/fragment are ignored during the comparison (it would be
            //   impossible to compare anyway as the client is not sending the anchor
            //   to the server as per RFC)
            // - query string parameters should be the same to be considered equal, as
            //   those could drasticaly alter a page result
            // """
            // if not request or self.is_mega_menu:
            //     # There is no notion of `active` if we don't have a request to
            //     # compare the url to.
            //     # Also, mega menu are never considered active.
            //     return False
            // 
            // request_url = url_parse(request.httprequest.url)
            // 
            // if not self.child_id:
            //     # Don't compare to `url` as it could be shadowed by the linked
            //     # website page's URL
            //     menu_url = self._clean_url()
            //     if not menu_url:
            //         return False
            // 
            //     menu_url = url_parse(menu_url)
            //     unslug_url = self.env['ir.http']._unslug_url
            //     if unslug_url(menu_url.path) == unslug_url(request_url.path):
            //         if not (
            //             set(menu_url.decode_query().items(multi=True))
            //             <= set(request_url.decode_query().items(multi=True))
            //         ):
            //             # correct path but query arguments does not match
            //             return False
            //         if menu_url.netloc and menu_url.netloc != request_url.netloc:
            //             # correct path but not correct domain
            //             return False
            //         return True
            // else:
            //     # Child match (dropdown menu), `self` is just a parent/container,
            //     # don't check its URL, consider only its children
            //     if any(child._is_active() for child in self.child_id):
            //         return True
            // 
            // return False
            */
            return default;
        }

        public async Task<WebsiteMenu> SaveAsync(Guid id, WebsiteMenuSaveRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_menu.py) ---
            // def save(self, website_id, data):
            // def replace_id(old_id, new_id):
            //     for menu in data['data']:
            //         if menu['id'] == old_id:
            //             menu['id'] = new_id
            //         if menu['parent_id'] == old_id:
            //             menu['parent_id'] = new_id
            // to_delete = data.get('to_delete')
            // if to_delete:
            //     self.browse(to_delete).unlink()
            // for menu in data['data']:
            //     mid = menu['id']
            //     # new menu are prefixed by new-
            //     if isinstance(mid, str):
            //         new_menu = self.create({'name': menu['name'], 'website_id': website_id})
            //         replace_id(mid, new_menu.id)
            // for menu in data['data']:
            //     menu_id = self.browse(menu['id'])
            //     # Check if the url match a website.page (to set the m2o relation),
            //     # except if the menu url contains '#', we then unset the page_id
            //     if not menu['url'] or '#' in menu['url']:
            //         # Multiple case possible
            //         # 1. `#` => menu container (dropdown, ..)
            //         # 2. `#anchor` => anchor on current page
            //         # 3. `/url#something` => valid internal URL
            //         # 4. https://google.com#smth => valid external URL
            //         if menu_id.page_id:
            //             menu_id.page_id = None
            //         if request and menu['url'] and menu['url'].startswith('#') and len(menu['url']) > 1:
            //             # Working on case 2.: prefix anchor with referer URL
            //             referer_url = werkzeug.urls.url_parse(request.httprequest.headers.get('Referer', '')).path
            //             menu['url'] = referer_url + menu['url']
            //     else:
            //         domain = self.env["website"].website_domain(website_id) + [
            //             "|",
            //             ("url", "=", menu["url"]),
            //             ("url", "=", "/" + menu["url"]),
            //         ]
            //         page = self.env["website.page"].search(domain, limit=1)
            //         if page:
            //             menu['page_id'] = page.id
            //             menu['url'] = page.url
            //             if isinstance(menu.get('parent_id'), str):
            //                 # Avoid failure if parent_id is sent as a string from a customization.
            //                 menu['parent_id'] = int(menu['parent_id'])
            //         elif menu_id.page_id:
            //             try:
            //                 # a page shouldn't have the same url as a controller
            //                 self.env['ir.http']._match(menu['url'])
            //                 menu_id.page_id = None
            //             except werkzeug.exceptions.NotFound:
            //                 menu_id.page_id.write({'url': menu['url']})
            //     menu_id.write(menu)
            // 
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<WebsiteMenu> SetFieldIsMegaMenuInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_menu.py) ---
            // def _set_field_is_mega_menu(self):
            // for menu in self:
            //     if menu.is_mega_menu:
            //         if not menu.mega_menu_content:
            //             menu.mega_menu_content = self.env['ir.ui.view']._render_template('website.s_mega_menu_odoo_menu')
            //     else:
            //         menu.mega_menu_content = False
            //         menu.mega_menu_classes = False
            */
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_menu.py) ---
            // def unlink(self):
            // self.env.registry.clear_cache('templates')
            // default_menu = self.env.ref('website.main_menu', raise_if_not_found=False)
            // menus_to_remove = self
            // for menu in self.filtered(lambda m: default_menu and m.parent_id.id == default_menu.id):
            //     menus_to_remove |= self.env['website.menu'].search([('url', '=', menu.url),
            //                                                         ('website_id', '!=', False),
            //                                                         ('id', '!=', menu.id)])
            // return super(Menu, menus_to_remove).unlink()
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: website_menu.py) ---
            // def unlink(self):
            // """ Override to synchronize event configuration fields with menu deletion. """
            // event_updates = {}
            // website_event_menus = self.env['website.event.menu'].search([('menu_id', 'in', self.ids)])
            // for event_menu in website_event_menus:
            //     to_update = event_updates.setdefault(event_menu.event_id, list())
            //     for menu_type, fname in event_menu.event_id._get_menu_type_field_matching().items():
            //         if event_menu.menu_type == menu_type:
            //             to_update.append(fname)
            // 
            // # manually remove website_event_menus to call their ``unlink`` method. Otherwise
            // # super unlinks at db level and skip model-specific behavior.
            // website_event_menus.unlink()
            // res = super(WebsiteMenu, self).unlink()
            // 
            // # update events
            // for event, to_update in event_updates.items():
            //     if to_update:
            //         event.write(dict((fname, False) for fname in to_update))
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: website_menu.py) ---
            // def unlink(self):
            // """ Override to synchronize event configuration fields with menu deletion.
            // This should be cleaned in upcoming versions. """    
            // event_updates = {}
            // website_event_menus = self.env['website.event.menu'].search([('menu_id', 'in', self.ids)])
            // for event_menu in website_event_menus:
            //     to_update = event_updates.setdefault(event_menu.event_id, list())
            //     # specifically check for /track in menu URL; to avoid unchecking track field when removing
            //     # agenda page that has also menu_type='track'
            //     if event_menu.menu_type == 'track' and '/track' in event_menu.menu_id.url:
            //         to_update.append('website_track')
            // 
            // # call super that resumes the unlink of menus entries (including website event menus)
            // res = super(WebsiteMenu, self).unlink()
            // 
            // # update events
            // for event, to_update in event_updates.items():
            //     if to_update:
            //         event.write(dict((fname, False) for fname in to_update))
            // 
            // return res
            */
            return await base.UnlinkAsync(ids);
        }

        protected async Task<WebsiteMenu> UnlinkExceptMasterTagsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_menu.py) ---
            // def _unlink_except_master_tags(self):
            // main_menu = self.env.ref('website.main_menu', raise_if_not_found=False)
            // if main_menu and main_menu in self:
            //     raise UserError(_("You cannot delete this website menu as this serves as the default parent menu for new websites (e.g., /shop, /event, ...)."))
            */
            return default;
        }
    }
}