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
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("BaseModule", Category = "Base")]
    public class IrUiMenuAppService : GenericApplicationService<IrUiMenu>, IIrUiMenuAppService
    {

        public IrUiMenuAppService(IRepository<IrUiMenu, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<IrUiMenu> CheckParentIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_menu.py) ---
            // def _check_parent_id(self):
            // if self._has_cycle():
            //     raise ValidationError(_('Error! You cannot create recursive menus.'))
            */
            return default;
        }

        protected async Task<IrUiMenu> ComputeCompleteNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_menu.py) ---
            // def _compute_complete_name(self):
            // for menu in self:
            //     menu.complete_name = menu._get_full_name()
            */
            return default;
        }

        protected async Task<IrUiMenu> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_menu.py) ---
            // def _compute_display_name(self):
            // for menu in self:
            //     menu.display_name = menu._get_full_name()
            */
            return default;
        }

        protected async Task<IrUiMenu> ComputeWebIconDataInternalAsync(object web_icon)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_menu.py) ---
            // def _compute_web_icon_data(self, web_icon):
            // """ Returns the image associated to `web_icon`.
            //     `web_icon` can either be:
            //       - an image icon [module, path]
            //       - a built icon [icon_class, icon_color, background_color]
            //     and it only has to call `_read_image` if it's an image.
            // """
            // if web_icon and len(web_icon.split(',')) == 2:
            //     return self._read_image(web_icon)
            */
            return default;
        }

        protected async Task<IrUiMenu> FilterVisibleMenusInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_menu.py) ---
            // def _filter_visible_menus(self):
            // """ Filter `self` to only keep the menu items that should be visible in
            //     the menu hierarchy of the current user.
            //     Uses a cache for speeding up the computation.
            // """
            // visible_ids = self._visible_menu_ids(request.session.debug if request else False)
            // return self.filtered(lambda menu: menu.id in visible_ids)
            */
            return default;
        }

        protected async Task<IrUiMenu> GetBestBackendRootMenuIdForModelInternalAsync(object res_model)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_ui_menu.py) ---
            // def _get_best_backend_root_menu_id_for_model(self, res_model):
            // """Get the best menu root id for the given res_model and the access
            // rights of the user.
            // 
            // When a link to a model was sent to a user it was targeting a page without
            // menu, so it was hard for the user to act on it.
            // The goal of this method is to find the best suited menu to display on a
            // page of a given model.
            // 
            // Technically, the method tries to find a menu root which has a sub menu
            // visible to the user that has an action linked to the given model.
            // If there is more than one possibility, it chooses the preferred one based
            // on the following preference function that determine the sub-menu from which
            // the root menu is extracted:
            // - favor the sub-menu linked to an action having a path as it probably indicates
            // a "major" action
            // - then favor the sub-menu with the smallest menu id as it probably indicates
            // that it belongs to the main module of the model and not a sub-one.
            // 
            // :param str res_model: the model name for which we want to find the best
            //     menu root id
            // :return (int): the best menu root id or None if not found
            // """
            // with contextlib.suppress(AccessError):  # if no access to the menu, return None
            //     visible_menu_ids = self._visible_menu_ids()
            //     # Try first to get a menu root from the model implementation (take the less specialized i.e. the first one)
            //     menu_root_candidates = self.env[res_model]._get_backend_root_menu_ids()
            //     menu_root_id = next((m_id for m_id in menu_root_candidates if m_id in visible_menu_ids), None)
            //     if menu_root_id:
            //         return menu_root_id
            // 
            //     # No menu root could be found by interrogating the model so fall back to a simple heuristic
            //     # Prefetch menu fields and all menu's actions of type act_window
            //     menus = self.env['ir.ui.menu'].browse(visible_menu_ids)
            //     self.env['ir.actions.act_window'].sudo().browse([
            //         int(menu['action'].split(',')[1])
            //         for menu in menus.read(['action', 'parent_path'])
            //         if menu['action'] and menu['action'].startswith('ir.actions.act_window,')
            //     ]).filtered('res_model')
            // 
            //     def _menu_sort_key(menu_action):
            //         menu, action = menu_action
            //         return 1 if action.path else 0, -menu.id
            // 
            //     menu_sudo = max((
            //         (menu, action) for menu in menus.sudo() for action in (menu.action,)
            //         if action and action.type == 'ir.actions.act_window' and action.res_model == res_model
            //            and all(int(menu_id) in visible_menu_ids for menu_id in menu.parent_path.split('/') if menu_id)
            //     ), key=_menu_sort_key, default=(None, None))[0]
            //     return int(menu_sudo.parent_path[:menu_sudo.parent_path.index('/')]) if menu_sudo else None
            */
            return default;
        }

        protected async Task<IrUiMenu> GetFullNameInternalAsync(object level)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_menu.py) ---
            // def _get_full_name(self, level=6):
            // """ Return the full name of ``self`` (up to a certain level). """
            // if level <= 0:
            //     return '...'
            // if self.parent_id:
            //     return (self.parent_id._get_full_name(level - 1) or "") + MENU_ITEM_SEPARATOR + (self.name or "")
            // else:
            //     return self.name
            */
            return default;
        }

        protected async Task<IrUiMenu> GetMenuitemsXmlidsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_menu.py) ---
            // def _get_menuitems_xmlids(self):
            // menuitems = self.env['ir.model.data'].sudo().search([
            //         ('res_id', 'in', self.ids),
            //         ('model', '=', 'ir.ui.menu')
            //     ])
            // 
            // return {
            //     menu.res_id: menu.complete_name
            //     for menu in menuitems
            // }
            */
            return default;
        }

        public async Task<IrUiMenu> GetUserRootsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_menu.py) ---
            // def get_user_roots(self):
            // """ Return all root menu ids visible for the user.
            // 
            // :return: the root menu ids
            // :rtype: list(int)
            // """
            // return self.search([('parent_id', '=', False)])
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrUiMenu> LoadMenusAsync(Guid id, IrUiMenuLoadMenusRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_menu.py) ---
            // def load_menus(self, debug):
            // """ Loads all menu items (all applications and their sub-menus).
            // 
            // :return: the menu root
            // :rtype: dict('children': menu_nodes)
            // """
            // fields = ['name', 'sequence', 'parent_id', 'action', 'web_icon']
            // menu_roots = self.get_user_roots()
            // menu_roots_data = menu_roots.read(fields) if menu_roots else []
            // menu_root = {
            //     'id': False,
            //     'name': 'root',
            //     'parent_id': [-1, ''],
            //     'children': [menu['id'] for menu in menu_roots_data],
            // }
            // 
            // all_menus = {'root': menu_root}
            // 
            // if not menu_roots_data:
            //     return all_menus
            // 
            // # menus are loaded fully unlike a regular tree view, cause there are a
            // # limited number of items (752 when all 6.1 addons are installed)
            // menus_domain = [('id', 'child_of', menu_roots.ids)]
            // blacklisted_menu_ids = self._load_menus_blacklist()
            // if blacklisted_menu_ids:
            //     menus_domain = expression.AND([menus_domain, [('id', 'not in', blacklisted_menu_ids)]])
            // menus = self.search(menus_domain)
            // menu_items = menus.read(fields)
            // xmlids = (menu_roots + menus)._get_menuitems_xmlids()
            // 
            // # add roots at the end of the sequence, so that they will overwrite
            // # equivalent menu items from full menu read when put into id:item
            // # mapping, resulting in children being correctly set on the roots.
            // menu_items.extend(menu_roots_data)
            // 
            // mi_attachments = self.env['ir.attachment'].sudo().search_read(
            //     domain=[('res_model', '=', 'ir.ui.menu'),
            //             ('res_id', 'in', [menu_item['id'] for menu_item in menu_items if menu_item['id']]),
            //             ('res_field', '=', 'web_icon_data')],
            //     fields=['res_id', 'datas', 'mimetype'])
            // 
            // mi_attachment_by_res_id = {attachment['res_id']: attachment for attachment in mi_attachments}
            // 
            // # set children ids and xmlids
            // menu_items_map = {menu_item["id"]: menu_item for menu_item in menu_items}
            // for menu_item in menu_items:
            //     menu_item.setdefault('children', [])
            //     parent = menu_item['parent_id'] and menu_item['parent_id'][0]
            //     menu_item['xmlid'] = xmlids.get(menu_item['id'], "")
            //     if parent in menu_items_map:
            //         menu_items_map[parent].setdefault(
            //             'children', []).append(menu_item['id'])
            //     attachment = mi_attachment_by_res_id.get(menu_item['id'])
            //     if attachment:
            //         menu_item['web_icon_data'] = attachment['datas'].decode()
            //         menu_item['web_icon_data_mimetype'] = attachment['mimetype']
            //     else:
            //         menu_item['web_icon_data'] = False
            //         menu_item['web_icon_data_mimetype'] = False
            // all_menus.update(menu_items_map)
            // 
            // # sort by sequence
            // for menu_id in all_menus:
            //     all_menus[menu_id]['children'].sort(key=lambda id: all_menus[id]['sequence'])
            // 
            // # recursively set app ids to related children
            // def _set_app_id(app_id, menu):
            //     menu['app_id'] = app_id
            //     for child_id in menu['children']:
            //         _set_app_id(app_id, all_menus[child_id])
            // 
            // for app in menu_roots_data:
            //     app_id = app['id']
            //     _set_app_id(app_id, all_menus[app_id])
            // 
            // # filter out menus not related to an app (+ keep root menu)
            // all_menus = {menu['id']: menu for menu in all_menus.values() if menu.get('app_id')}
            // all_menus['root'] = menu_root
            // 
            // return all_menus
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrUiMenu> LoadMenusBlacklistInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: ir_ui_menu.py) ---
            // def _load_menus_blacklist(self):
            // res = super()._load_menus_blacklist()
            // menu = self.env.ref('account.account_audit_trail_menu', raise_if_not_found=False)
            // if menu and not any(company.check_account_audit_trail for company in self.env.user.company_ids):
            //     res.append(menu.id)
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: ir_ui_menu.py) ---
            // def _load_menus_blacklist(self):
            // res = super()._load_menus_blacklist()
            // if self.env.user.has_group('hr.group_hr_user'):
            //     res.append(self.env.ref('hr.menu_hr_employee').id)
            // else:
            //     is_department_manager = bool(self.env["hr.department"].search_count([
            //         ('manager_id', 'in', self.env.user.employee_ids.ids)
            //     ]))
            //     if not is_department_manager:
            //         res.append(self.env.ref('hr.menu_hr_department_kanban').id)
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: ir_ui_menu.py) ---
            // def _load_menus_blacklist(self):
            // res = super()._load_menus_blacklist()
            // is_contract_employee_manager = self.env.user.has_group('hr_contract.group_hr_contract_employee_manager')
            // is_employee_officer = self.env.user.has_group('hr.group_hr_user')
            // if not is_contract_employee_manager or is_employee_officer:
            //     res.append(self.env.ref('hr_contract.menu_hr_employee_contracts').id)
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: ir_ui_menu.py) ---
            // def _load_menus_blacklist(self):
            // res = super()._load_menus_blacklist()
            // is_interviewer = self.env.user.has_group('hr_recruitment.group_hr_recruitment_interviewer')
            // is_user = self.env.user.has_group('hr_recruitment.group_hr_recruitment_user')
            // if not is_interviewer:
            //     res.append(self.env.ref('hr.menu_view_hr_job').id)
            // elif is_interviewer and not is_user:
            //     res.append(self.env.ref('hr_recruitment.menu_hr_job_position').id)
            // else:
            //     res.append(self.env.ref('hr_recruitment.menu_hr_job_position_interviewer').id)
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: ir_ui_menu.py) ---
            // def _load_menus_blacklist(self):
            // res = super()._load_menus_blacklist()
            // if self.env.user.has_group('hr_timesheet.group_hr_timesheet_approver'):
            //     res.append(self.env.ref('hr_timesheet.timesheet_menu_activity_user').id)
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet_attendance, FILE: ir_ui_menu.py) ---
            // def _load_menus_blacklist(self):
            // res = super()._load_menus_blacklist()
            // if not (self.env.user.has_group('hr_timesheet.group_hr_timesheet_user')):
            //     res.append(self.env.ref('hr_timesheet_attendance.menu_hr_timesheet_attendance_report').id)
            // return res
            --- ODOO METHOD SOURCE (MODULE: project, FILE: ir_ui_menu.py) ---
            // def _load_menus_blacklist(self):
            // res = super()._load_menus_blacklist()
            // if not self.env.user.has_group('project.group_project_manager'):
            //     res.append(self.env.ref('project.rating_rating_menu_project').id)
            // if self.env.user.has_group('project.group_project_stages'):
            //     res.append(self.env.ref('project.menu_projects').id)
            //     res.append(self.env.ref('project.menu_projects_config').id)
            // return res
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_menu.py) ---
            // def _load_menus_blacklist(self):
            // return []
            */
            return default;
        }

        public async Task<IrUiMenu> LoadMenusRootAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_menu.py) ---
            // def load_menus_root(self):
            // root_menus = super().load_menus_root()
            // if self.env.context.get('force_action'):
            //     web_menus = self.load_web_menus(request.session.debug if request else False)
            //     for menu in root_menus['children']:
            //         # Force the action.
            //         if (
            //             not menu['action']
            //             and web_menus[menu['id']]['actionModel']
            //             and web_menus[menu['id']]['actionID']
            //         ):
            //             menu['action'] = f"{web_menus[menu['id']]['actionModel']},{web_menus[menu['id']]['actionID']}"
            // 
            // return root_menus
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_menu.py) ---
            // def load_menus_root(self):
            // fields = ['name', 'sequence', 'parent_id', 'action', 'web_icon_data']
            // menu_roots = self.get_user_roots()
            // menu_roots_data = menu_roots.read(fields) if menu_roots else []
            // 
            // menu_root = {
            //     'id': False,
            //     'name': 'root',
            //     'parent_id': [-1, ''],
            //     'children': menu_roots_data,
            //     'all_menu_ids': menu_roots.ids,
            // }
            // 
            // xmlids = menu_roots._get_menuitems_xmlids()
            // for menu in menu_roots_data:
            //     menu['xmlid'] = xmlids.get(menu['id'], '')
            // 
            // return menu_root
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrUiMenu> LoadWebMenusAsync(Guid id, IrUiMenuLoadWebMenusRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: ir_ui_menu.py) ---
            // def load_web_menus(self, debug):
            // """ Loads all menu items (all applications and their sub-menus) and
            // processes them to be used by the webclient. Mainly, it associates with
            // each application (top level menu) the action of its first child menu
            // that is associated with an action (recursively), i.e. with the action
            // to execute when the opening the app.
            // 
            // :return: the menus (including the images in Base64)
            // """
            // menus = self.load_menus(debug)
            // 
            // web_menus = {}
            // for menu in menus.values():
            //     if not menu['id']:
            //         # special root menu case
            //         web_menus['root'] = {
            //             "id": 'root',
            //             "name": menu['name'],
            //             "children": menu['children'],
            //             "appID": False,
            //             "xmlid": "",
            //             "actionID": False,
            //             "actionModel": False,
            //             "actionPath": False,
            //             "webIcon": None,
            //             "webIconData": None,
            //             "webIconDataMimetype": None,
            //             "backgroundImage": menu.get('backgroundImage'),
            //         }
            //     else:
            //         action = menu['action']
            //         web_icon = menu['web_icon']
            //         web_icon_data = menu['web_icon_data']
            // 
            //         if menu['id'] == menu['app_id']:
            //             # if it's an app take action of first (sub)child having one defined
            //             child = menu
            //             while child and not action:
            //                 action = child['action']
            //                 child = menus[child['children'][0]] if child['children'] else False
            // 
            //             webIcon = menu.get('web_icon', '')
            //             webIconlist = webIcon and webIcon.split(',')
            //             iconClass = color = backgroundColor = None
            //             if webIconlist:
            //                 if len(webIconlist) >= 2:
            //                     iconClass, color = webIconlist[:2]
            //                 if len(webIconlist) == 3:
            //                     backgroundColor = webIconlist[2]
            // 
            //             if menu.get('web_icon_data'):
            //                 web_icon_data = re.sub(r'\s/g', "", ('data:%s;base64,%s' % (menu['web_icon_data_mimetype'], menu['web_icon_data'])))
            //             elif backgroundColor is not None:  # Could split in three parts?
            //                 web_icon = ",".join([iconClass or "", color or "", backgroundColor])
            //             else:
            //                 web_icon_data = '/web/static/img/default_icon_app.png'
            // 
            //         action_model, action_id = action.split(',') if action else (False, False)
            //         action_id = int(action_id) if action_id else False
            //         if action_model and action_id:
            //             action_path = self.env[action_model].browse(action_id).sudo().path
            //         else:
            //             action_path = False
            // 
            //         web_menus[menu['id']] = {
            //             "id": menu['id'],
            //             "name": menu['name'],
            //             "children": menu['children'],
            //             "appID": menu['app_id'],
            //             "xmlid": menu['xmlid'],
            //             "actionID": action_id,
            //             "actionModel": action_model,
            //             "actionPath": action_path,
            //             "webIcon": web_icon,
            //             "webIconData": web_icon_data,
            //             "webIconDataMimetype": menu['web_icon_data_mimetype'],
            //         }
            // 
            // return web_menus
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrUiMenu> ReadImageInternalAsync(object path)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_menu.py) ---
            // def _read_image(self, path):
            // if not path:
            //     return False
            // path_info = path.split(',')
            // icon_path = opj(path_info[0], path_info[1])
            // try:
            //     with tools.file_open(icon_path, 'rb', filter_ext=('.png', '.gif', '.ico', '.jfif', '.jpeg', '.jpg', '.svg', '.webp')) as icon_file:
            //         return base64.encodebytes(icon_file.read())
            // except FileNotFoundError:
            //     return False
            */
            return default;
        }

        public async Task<IrUiMenu> SearchCountAsync(Guid id, IrUiMenuSearchCountRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_menu.py) ---
            // def search_count(self, domain, limit=None):
            // # to be consistent with search() above
            // return len(self.search(domain, limit=limit))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrUiMenu> SearchFetchAsync(Guid id, IrUiMenuSearchFetchRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_menu.py) ---
            // def search_fetch(self, domain, field_names, offset=0, limit=None, order=None):
            // menus = super().search_fetch(domain, field_names, order=order)
            // if menus:
            //     # menu filtering is done only on main menu tree, not other menu lists
            //     if not self._context.get('ir.ui.menu.full_list'):
            //         menus = menus._filter_visible_menus()
            //     if offset:
            //         menus = menus[offset:]
            //     if limit:
            //         menus = menus[:limit]
            // return menus
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrUiMenu> VisibleMenuIdsInternalAsync(object debug)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_menu.py) ---
            // def _visible_menu_ids(self, debug=False):
            // """ Return the ids of the menu items visible to the user. """
            // # retrieve all menus, and determine which ones are visible
            // context = {'ir.ui.menu.full_list': True}
            // menus = self.with_context(context).search_fetch([], ['action', 'parent_id']).sudo()
            // 
            // # first discard all menus with groups the user does not have
            // group_ids = set(self.env.user._get_group_ids())
            // if not debug:
            //     group_ids = group_ids - {self.env['ir.model.data']._xmlid_to_res_id('base.group_no_one', raise_if_not_found=False)}
            // menus = menus.filtered(
            //     lambda menu: not (menu.groups_id and group_ids.isdisjoint(menu.groups_id._ids)))
            // 
            // # take apart menus that have an action
            // actions_by_model = defaultdict(set)
            // for action in menus.mapped('action'):
            //     if action:
            //         actions_by_model[action._name].add(action.id)
            // existing_actions = {
            //     action
            //     for model_name, action_ids in actions_by_model.items()
            //     for action in self.env[model_name].browse(action_ids).exists()
            // }
            // action_menus = menus.filtered(lambda m: m.action and m.action in existing_actions)
            // folder_menus = menus - action_menus
            // visible = self.browse()
            // 
            // # process action menus, check whether their action is allowed
            // access = self.env['ir.model.access']
            // MODEL_BY_TYPE = {
            //     'ir.actions.act_window': 'res_model',
            //     'ir.actions.report': 'model',
            //     'ir.actions.server': 'model_name',
            // }
            // 
            // # performance trick: determine the ids to prefetch by type
            // prefetch_ids = defaultdict(list)
            // for action in action_menus.mapped('action'):
            //     prefetch_ids[action._name].append(action.id)
            // 
            // for menu in action_menus:
            //     action = menu.action
            //     action = action.with_prefetch(prefetch_ids[action._name])
            //     model_name = action._name in MODEL_BY_TYPE and action[MODEL_BY_TYPE[action._name]]
            //     if not model_name or access.check(model_name, 'read', False):
            //         # make menu visible, and its folder ancestors, too
            //         visible += menu
            //         menu = menu.parent_id
            //         while menu and menu in folder_menus and menu not in visible:
            //             visible += menu
            //             menu = menu.parent_id
            // 
            // return set(visible.ids)
            */
            return default;
        }
    }
}