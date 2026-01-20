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
    public partial class WebsiteMenuAppService : GenericApplicationService<WebsiteMenu>, IWebsiteMenuAppService
    {

        public WebsiteMenuAppService(IRepository<WebsiteMenu, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        protected async Task<WebsiteMenu> CleanUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_menu.py) ---
            // def _clean_url(self):
            // # clean the url with heuristic
            // url = self.url
            // if url and not self.url.startswith("/"):
            //     if "@" in self.url:
            //         if not self.url.startswith("mailto"):
            //             url = "mailto:%s" % self.url
            //     elif not self.url.startswith("http"):
            //         url = "/%s" % self.url
            // return url
            */
            return default;
        }

        protected async Task<WebsiteMenu> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_menu.py) ---
            // def _compute_display_name(self):
            // if not self.env.context.get('display_website') and not self.env.user.has_group('website.group_multi_website'):
            //     return super()._compute_display_name()
            // 
            // for menu in self:
            //     menu_name = menu.name or ""
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

        protected async Task<WebsiteMenu> ComputeUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_menu.py) ---
            // def _compute_url(self):
            // for menu in self:
            //     if menu.is_mega_menu or menu.child_id:
            //         menu.url = "#"
            //     else:
            //         menu.url = (menu.page_id.url if menu.page_id else menu.url) or "#"
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
            // shop_menus = self.filtered(lambda m: m.url[:5] == '/shop')
            // for menu in shop_menus:
            //     menu.is_visible = menu.website_id.has_ecommerce_access()
            // 
            // return super(WebsiteMenu, self - shop_menus)._compute_visible()
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
            //     menu_node = {
            //         'fields': {
            //             'id': node.id,
            //             'name': node.name,
            //             'url': node.url,
            //             'new_window': node.new_window,
            //             'is_mega_menu': node.is_mega_menu,
            //             'sequence': node.sequence,
            //             'parent_id': node.parent_id.id,
            //         },
            //         'children': [],
            //         'is_homepage': node.url == (website.homepage_url or '/'),
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
            //     menu_url = url_parse(self._clean_url())
            //     unslug_url = self.env['ir.http']._unslug_url
            //     if unslug_url(menu_url.path) == unslug_url(request_url.path):
            //         # By default we compare the unslug version of the current URL
            //         # with the menu URL but if the menu is linked to a page we don't
            //         # consider it active if the paths don't match exactly.
            //         if self.page_id and menu_url.path != request_url.path:
            //             return False
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
            //     if '#' in menu['url']:
            //         # Multiple case possible
            //         # 1. `#` => menu container (dropdown, ..)
            //         # 2. `#anchor` => anchor on current page
            //         # 3. `/url#something` => valid internal URL
            //         # 4. https://google.com#smth => valid external URL
            //         if menu_id.page_id:
            //             menu_id.page_id = None
            //         if request and menu['url'].startswith('#') and len(menu['url']) > 1:
            //             # Working on case 2.: prefix anchor with referer URL
            //             referer_url = werkzeug.urls.url_parse(request.httprequest.headers.get('Referer', '')).path
            //             menu['url'] = referer_url + menu['url']
            //     else:
            //         domain = self.env["website"].browse(website_id).website_domain() & (
            //             Domain("url", "=", menu["url"])
            //             | Domain("url", "=", "/" + menu["url"])
            //         )
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
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: website_menu.py) ---
            // def save(self, website_id, data):
            // """
            // Method context:
            // 
            // This method takes a data argument that follows the following format:
            //  [
            //    { 'id': 4, url: '/mypage' },
            //    { 'id': 'menu_xxx_...', url: '/anotherpage' }
            //  ]
            // 
            //  The new menu entries are identified by their ID being a string and not an integer value.
            //  Note that when going through super() call, those id entries are replaced by their created
            //  menu ID (integer), so we need to identify new menu entries before calling super.
            // 
            //  Override purpose:
            // 
            //  All sub-menus of an event are children of a 'main' website.menu, linking to the event main page.
            // 
            //  We abuse that information to determine if the added menu is part of an event or not:
            //  If we find a website.event.menu item that has the same parent as the menu we just created
            //  -> it means that we just created a menu inside an event.
            // 
            //  Once we have identified that, we force its URL to be part of the event pages, and we create
            //  a matching website.event.menu record for it. """
            // 
            // old_menu_ids = [menu['id'] for menu in data['data'] if isinstance(menu['id'], int)]
            // has_new_menus = any(isinstance(menu['id'], str) for menu in data['data'])
            // res = super().save(website_id, data)
            // 
            // if not has_new_menus:
            //     return res
            // 
            // menus_by_parent_id = {}
            // for menu in data['data']:
            //     if not menu.get('parent_id'):
            //         continue
            //     if not menus_by_parent_id.get(menu['parent_id']):
            //         menus_by_parent_id[menu['parent_id']] = []
            // 
            //     menus_by_parent_id[menu['parent_id']].append(menu)
            // 
            // for parent_id, menus in menus_by_parent_id.items():
            //     new_menus = filter(lambda menu: menu['id'] not in old_menu_ids, menus)
            //     if not new_menus:
            //         continue
            // 
            //     parent = self.env['website.menu'].browse(parent_id)
            //     while parent.parent_id:  # get the top-most parent to handle sub-menus
            //         parent = parent.parent_id
            // 
            //     if parent_event_menu := self.env['website.event.menu'].search([
            //         ('menu_id.parent_id', '=', parent.id)
            //     ], limit=1):
            //         event_url = parent_event_menu.event_id.website_url.rstrip('/')
            //         event_menu_values = []
            //         for new_menu in new_menus:
            //             menu_record = self.env['website.menu'].browse(new_menu['id'])
            //             menu_record_url = menu_record.url.lstrip("/")
            //             if not menu_record_url or menu_record_url == '#':
            //                 # prevent blank URLs, use 't' prefix to avoid slug syntax
            //                 menu_record_url = f"t{int(datetime.now().timestamp())}"
            // 
            //             menu_record.write({
            //                 'url': f'{event_url}/page/{menu_record_url}'
            //             })
            //             event_menu_values.append({
            //                 'menu_id': menu_record.id,
            //                 'event_id': parent_event_menu.event_id.id,
            //                 'menu_type': 'other',
            //             })
            // 
            //         # if the current user can create website.menu, then he should be able to
            //         # create website.event.menu (e.g: website designer group)
            //         self.env['website.event.menu'].sudo().create(event_menu_values)
            // 
            // return res
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
            // return super(WebsiteMenu, menus_to_remove).unlink()
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
            // unlinked_menus = self
            // 
            // if website_event_menus:
            //     # Manually remove website_event_menus to call their ``unlink`` method. Otherwise
            //     # super unlinks at db level and skip model-specific behavior.
            //     # Since website.event.menu unlink removes:
            //     # - the related ir.ui.view records
            //     # - which cascade deletes the website.page records
            //     # - which cascade deletes the website.menu records
            //     # -> we only call super unlink on the remaining website.menu records
            //     cascaded_menus = website_event_menus.view_id.page_ids.menu_ids
            //     unlinked_menus = self - cascaded_menus
            //     website_event_menus.unlink()
            // 
            // res = super(WebsiteMenu, unlinked_menus).unlink()
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

        protected async Task<WebsiteMenu> ValidateParentMenuInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_menu.py) ---
            // def _validate_parent_menu(self):
            // """
            // Ensure valid menu hierarchy and mega menu constraints.
            // 
            // Rules enforced:
            // - Menus must not exceed two levels of nesting.
            // - A mega menu must not have a parent or child.
            // - Menus with children cannot be added as a submenu under another menu.
            // """
            // for record in self:
            //     parent_menu = record.parent_id.sudo() if record.parent_id else None
            // 
            //     # Check hierarchy level
            //     level = 0
            //     current_menu = parent_menu
            //     while current_menu:
            //         level += 1
            //         current_menu = current_menu.parent_id
            //         if level > 2:
            //             raise UserError(_("Menus cannot have more than two levels of hierarchy."))
            // 
            //     if parent_menu:
            //         # Mega menu constraint
            //         if parent_menu.is_mega_menu or (record.is_mega_menu and (parent_menu.parent_id or record.child_id)):
            //             raise UserError(_("A mega menu cannot have a parent or child menu."))
            // 
            //         # Submenu structure constraint
            //         if record.child_id and (parent_menu.parent_id or record.child_id.child_id):
            //             raise UserError(_("Menus with child menus cannot be added as a submenu."))
            */
            return default;
        }
    }
}