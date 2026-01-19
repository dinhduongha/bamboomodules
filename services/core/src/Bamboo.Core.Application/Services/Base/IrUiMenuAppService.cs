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
    public partial class IrUiMenuAppService : GenericApplicationService<IrUiMenu>, IIrUiMenuAppService
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
            //     raise ValidationError(self.env._('Error! You cannot create recursive menus.'))
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
            // """ Returns the image associated to ``web_icon``.
            // 
            // :param str web_icon: a comma-separated value string for either:
            // 
            //   * an image icon: ``f"{module},{path}"``
            //   * a built icon: ``f"{icon_class},{icon_color},{background_color}"``
            // 
            // The ``web_icon_data`` computed field uses :meth:`_read_image` for image
            // web icons, and is ``False`` for built icons.
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
            // :return: the best menu root id or None if not found
            // :rtype: int
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
            // menuitems = self.env['ir.model.data'].sudo().search_fetch(
            //     [('res_id', 'in', self.ids), ('model', '=', 'ir.ui.menu')],
            //     ['res_id', 'complete_name'],
            // )
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
            // return self.search([('parent_id', '=', False)])._filter_visible_menus()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrUiMenu> LoadMenusAsync(Guid id, IrUiMenuLoadMenusRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_menu.py) ---
            // def load_menus(self, debug):
            // blacklisted_menu_ids = self._load_menus_blacklist()
            // visible_menus = self.search_fetch(
            //     [('id', 'not in', blacklisted_menu_ids)],
            //     ['name', 'parent_id', 'action', 'web_icon'],
            // )._filter_visible_menus()
            // 
            // children_dict = defaultdict(list)  # {parent_id: []} / parent_id == False for root menus
            // for menu in visible_menus:
            //     children_dict[menu.parent_id.id].append(menu.id)
            // 
            // app_info = {}
            // # recursively set app ids to related children
            // def _set_app_id(menu_app_id, menu_id):
            //     app_info[menu_id] = menu_app_id
            //     for child_id in children_dict[menu_id]:
            //         _set_app_id(menu_app_id, child_id)
            // 
            // for root_menu_id in children_dict[False]:
            //     _set_app_id(root_menu_id, root_menu_id)
            // 
            // # Filter out menus not related to an app (+ keep root menu), it happens when
            // # some parent menu are not visible for group.
            // visible_menus = visible_menus.filtered(lambda menu: menu.id in app_info)
            // 
            // xmlids = visible_menus._get_menuitems_xmlids()
            // icon_attachments = self.env['ir.attachment'].sudo().search_read(
            //     domain=[('res_model', '=', 'ir.ui.menu'),
            //             ('res_id', 'in', visible_menus._ids),
            //             ('res_field', '=', 'web_icon_data')],
            //     fields=['res_id', 'datas', 'mimetype'])
            // icon_attachments_res_id = {attachment['res_id']: attachment for attachment in icon_attachments}
            // 
            // menus_dict = {}
            // action_ids_by_type = defaultdict(list)
            // for menu in visible_menus:
            // 
            //     menu_id = menu.id
            //     attachment = icon_attachments_res_id.get(menu_id)
            // 
            //     if action := menu.action:
            //         action_model = action._name
            //         action_id = action.id
            //         action_ids_by_type[action_model].append(action_id)
            //     else:
            //         action_model = False
            //         action_id = False
            // 
            //     menus_dict[menu_id] = {
            //         'id': menu_id,
            //         'name': menu.name,
            //         'app_id': app_info[menu_id],
            //         'action_model': action_model,
            //         'action_id': action_id,
            //         'web_icon': menu.web_icon,
            //         'web_icon_data': attachment['datas'].decode() if attachment else False,
            //         'web_icon_data_mimetype': attachment['mimetype'] if attachment else False,
            //         'xmlid': xmlids.get(menu_id, ""),
            //     }
            // 
            // # prefetch action.path
            // for model_name, action_ids in action_ids_by_type.items():
            //     self.env[model_name].sudo().browse(action_ids).fetch(['path'])
            // 
            // # set children + model_path
            // for menu_dict in menus_dict.values():
            //     if menu_dict['action_model']:
            //         menu_dict['action_path'] = self.env[menu_dict['action_model']].sudo().browse(menu_dict['action_id']).path
            //     else:
            //         menu_dict['action_path'] = False
            //     menu_dict['children'] = children_dict[menu_dict['id']]
            // 
            // menus_dict['root'] = {
            //     'id': False,
            //     'name': 'root',
            //     'children': children_dict[False],
            // }
            // return menus_dict
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrUiMenu> LoadMenusBlacklistInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: ir_ui_menu.py) ---
            // def _load_menus_blacklist(self):
            // res = super()._load_menus_blacklist()
            // if self.env.user.has_group('hr.group_hr_user') and (emp_menu := self.env.ref('hr.menu_hr_employee', raise_if_not_found=False)):
            //     res.append(emp_menu.id)
            // else:
            //     is_department_manager = bool(self.env["hr.department"].search_count([
            //         ('manager_id', 'in', self.env.user.employee_ids.ids)
            //     ], limit=1))
            //     if not is_department_manager and (dep_menu := self.env.ref('hr.menu_hr_department_kanban', raise_if_not_found=False)):
            //         res.append(dep_menu.id)
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: ir_ui_menu.py) ---
            // def _load_menus_blacklist(self):
            // res = super()._load_menus_blacklist()
            // if not (
            //     self.env.user.has_group('hr_attendance.group_hr_attendance_manager') and
            //     self.env.user.has_group('hr_holidays.group_hr_holidays_user')
            // ):
            //     res.append(self.env.ref('hr_holidays_attendance.hr_leave_attendance_report').id)
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: ir_ui_menu.py) ---
            // def _load_menus_blacklist(self):
            // res = super()._load_menus_blacklist()
            // is_interviewer = self.env.user.has_group('hr_recruitment.group_hr_recruitment_interviewer')
            // if not is_interviewer and (job_menu := self.env.ref('hr.menu_view_hr_job', raise_if_not_found=False)):
            //     res.append(job_menu.id)
            // elif (
            //     is_interviewer
            //     and not self.env.user.has_group('hr_recruitment.group_hr_recruitment_user')
            //     and (pos_menu := self.env.ref('hr_recruitment.menu_hr_job_position', raise_if_not_found=False))
            // ):
            //     res.append(pos_menu.id)
            // elif int_menu := self.env.ref('hr_recruitment.menu_hr_job_position_interviewer', raise_if_not_found=False):
            //     res.append(int_menu.id)
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: ir_ui_menu.py) ---
            // def _load_menus_blacklist(self):
            // res = super()._load_menus_blacklist()
            // if self.env.user.has_group('hr_timesheet.group_hr_timesheet_approver') and (time_menu := self.env.ref('hr_timesheet.timesheet_menu_activity_user', raise_if_not_found=False)):
            //     res.append(time_menu.id)
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet_attendance, FILE: ir_ui_menu.py) ---
            // def _load_menus_blacklist(self):
            // res = super()._load_menus_blacklist()
            // if not self.env.user.has_group('hr_timesheet.group_hr_timesheet_user') and (att_menu := self.env.ref('hr_timesheet_attendance.menu_hr_timesheet_attendance_report', raise_if_not_found=False)):
            //     res.append(att_menu.id)
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
            //         action_id = menu['action_id']
            //         action_model = menu['action_model']
            //         action_path = menu['action_path']
            //         web_icon = menu['web_icon']
            //         web_icon_data = menu['web_icon_data']
            // 
            //         if menu['id'] == menu['app_id']:
            //             # if it's an app take action of first (sub)child having one defined
            //             child = menu
            //             while child and not action_id:
            //                 action_id = child['action_id']
            //                 action_model = child['action_model']
            //                 action_path = child['action_path']
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

        protected async Task<IrUiMenu> VisibleMenuIdsInternalAsync(object debug)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_menu.py) ---
            // def _visible_menu_ids(self, debug=False):
            // """ Return the ids of the menu items visible to the user. """
            // group_ids = set(self.env.user._get_group_ids())
            // if not debug:
            //     group_ids.discard(self.env['ir.model.data']._xmlid_to_res_id('base.group_no_one', raise_if_not_found=False))
            // 
            // # retrieve menus with a domain to filter out menus with groups the user does not have.
            // # It will be used to determine which ones are visible
            // menus = self.with_context({}).search_fetch(
            //     # Don't use 'any' operator in the domain to avoid ir.rule
            //     ['|', ('group_ids', '=', False), ('group_ids', 'in', tuple(group_ids))],
            //     ['parent_id', 'action'], order='id',
            // ).sudo()
            // 
            // # take apart menus that have an action
            // action_ids_by_model = defaultdict(list)
            // for action in menus.mapped('action'):
            //     if action:
            //         action_ids_by_model[action._name].append(action.id)
            // 
            // MODEL_BY_TYPE = {
            //     'ir.actions.act_window': 'res_model',
            //     'ir.actions.report': 'model',
            //     'ir.actions.server': 'model_name',
            // }
            // def exists_actions(model_name, action_ids):
            //     """ Return existing actions and fetch model name field if exists"""
            //     if model_name not in MODEL_BY_TYPE:
            //         return self.env[model_name].browse(action_ids).exists()
            //     records = self.env[model_name].sudo().with_context(active_test=False).search_fetch(
            //         [('id', 'in', action_ids)], [MODEL_BY_TYPE[model_name]], order='id',
            //     )
            //     if model_name == 'ir.actions.server':
            //         # Because it is computed, `search_fetch` doesn't fill the cache for it
            //         records.mapped('model_name')
            //     return records
            // 
            // existing_actions = {
            //     action
            //     for model_name, action_ids in action_ids_by_model.items()
            //     for action in exists_actions(model_name, action_ids)
            // }
            // menu_ids = set(menus._ids)
            // visible_ids = set()
            // access = self.env['ir.model.access']
            // # process action menus, check whether their action is allowed
            // for menu in menus:
            //     action = menu.action
            //     if not action or action not in existing_actions:
            //         continue
            //     model_fname = MODEL_BY_TYPE.get(action._name)
            //     # action[model_fname] has been fetched in batch in `exists_actions`
            //     if model_fname and not access.check(action[model_fname], 'read', False):
            //         continue
            //     # make menu visible, and its folder ancestors, too
            //     menu_id = menu.id
            //     while menu_id not in visible_ids and menu_id in menu_ids:
            //         visible_ids.add(menu_id)
            //         menu = menu.parent_id
            //         menu_id =  menu.id
            // 
            // return frozenset(visible_ids)
            */
            return default;
        }
    }
}