using Bamboo.Core.Application.Contracts.DTOs;
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
    [Module("BaseModule")]
    public class IrUiViewAppService : GenericApplicationService<IrUiView>, IIrUiViewAppService
    {
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        private readonly IWebsiteSeoMetadataAppService _websiteSeoMetadataAppService;
        public IrUiViewAppService(IRepository<IrUiView, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IPosLoadMixinAppService posLoadMixinAppService, IWebsiteSeoMetadataAppService websiteSeoMetadataAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
            _websiteSeoMetadataAppService = websiteSeoMetadataAppService;
        }

        protected async Task<IrUiView> AddMissingFieldsInternalAsync(object node, object name_manager)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _add_missing_fields(self, node, name_manager):
            // """ Add the fields required for evaluating expressions in the view given by ``node``. """
            // root = node
            // missing_fields = name_manager.get_missing_fields()
            // for name, (missing_groups, reasons) in missing_fields.items():
            //     if name not in name_manager.field_info:
            //         continue
            // 
            //     # If the available fields have different groups then to avoid it being missing for
            //     # certain users, we virtually add a field with common groups.
            //     name_manager.available_fields[name].setdefault('info', {})
            //     name_manager.available_fields[name].setdefault('groups', []).append(missing_groups)
            //     name_manager.available_names.add(name)
            // 
            //     # If the field is not in the view without any group restriction,
            //     # add the field node with all mandatory groups (or without group if
            //     # the mandatory field does not have groups).
            //     attrs = {
            //         'name': name,
            //         'invisible' if root.tag != 'list' else 'column_invisible': 'True',
            //         'readonly': 'True',
            //         'data-used-by': '; '.join(
            //             f"{attr}={expr!r} ({node.tag},{node.get('name')})"
            //             for _groups, (attr, expr), node in reasons
            //         ),
            //     }
            // 
            //     if missing_groups is not False:
            //         subset_groups = missing_groups.invert_intersect(name_manager.model_groups)
            //         if subset_groups is None:
            //             subset_groups = missing_groups
            //         if not subset_groups.is_universal():
            //             attrs['__groups_key__'] = subset_groups.key
            // 
            //     item = etree.Element('field', attrs)
            //     item.tail = '\n'
            //     root.append(item)
            // return missing_fields
            */
            return default;
        }

        protected async Task<IrUiView> AddValidationFlagInternalAsync(object combined_arch, object view, object arch)
        {
            #if PYTHON_CODE
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _add_validation_flag(self, combined_arch, view=None, arch=None):
            // """ Add a validation flag on elements in ``combined_arch`` or ``arch``.
            // This is part of the partial validation of views.
            // 
            // :param Element combined_arch: the architecture to be modified by ``arch``
            // :param view: an optional view inheriting ``self``
            // :param Element arch: an optional modifying architecture from inheriting
            //     view ``view``
            // """
            // # validate_view_ids is either falsy (no validation), True (full
            // # validation) or a collection of ids (partial validation)
            // validate_view_ids = self.env.context.get('validate_view_ids')
            // if not validate_view_ids:
            //     return
            // 
            // if validate_view_ids is True or self.id in validate_view_ids:
            //     # optimization, flag the root node
            //     combined_arch.set('__validate__', '1')
            //     return
            // 
            // if view is None or view.id not in validate_view_ids:
            //     return
            // 
            // for node in arch.xpath('//*[@position]'):
            //     if node.get('position') in ('after', 'before', 'inside'):
            //         # validate the elements being inserted, except the ones that
            //         # specify a move, as in:
            //         #   <field name="foo" position="after">
            //         #       <field name="bar" position="move"/>
            //         #   </field>
            //         for child in node.iterchildren(tag=etree.Element):
            //             if not child.get('position'):
            //                 child.set('__validate__', '1')
            //     if node.get('position') == 'replace':
            //         # validate everything, since this impacts the whole arch
            //         combined_arch.set('__validate__', '1')
            //         break
            //     if node.get('position') == 'attributes':
            //         # validate the element being modified by adding
            //         # attribute "__validate__" on it:
            //         #   <field name="foo" position="attributes">
            //         #       <attribute name="readonly">1</attribute>
            //         #       <attribute name="__validate__">1</attribute>    <!-- add this -->
            //         #   </field>
            //         node.append(E.attribute('1', name='__validate__'))
            #endif
            return default;
        }

        public async Task<IrUiView> ApplyInheritanceSpecsAsync(Guid id, IrUiViewApplyInheritanceSpecsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def apply_inheritance_specs(self, source, specs_tree, pre_locate=lambda s: True):
            // """ Apply an inheriting view (a descendant of the base view)
            // 
            // Apply to a source architecture all the spec nodes (i.e. nodes
            // describing where and what changes to apply to some parent
            // architecture) given by an inheriting view.
            // 
            // :param Element source: a parent architecture to modify
            // :param Element specs_tree: a modifying architecture in an inheriting view
            // :param (optional) pre_locate: function that is execute before locating a node.
            //                                 This function receives an arch as argument.
            // :return: a modified source where the specs are applied
            // :rtype: Element
            // """
            // # Queue of specification nodes (i.e. nodes describing where and
            // # changes to apply to some parent architecture).
            // try:
            //     source = apply_inheritance_specs(
            //         source, specs_tree,
            //         inherit_branding=self._context.get('inherit_branding'),
            //         pre_locate=pre_locate,
            //     )
            // except ValueError as e:
            //     self._raise_view_error(str(e), specs_tree)
            // return source
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrUiView> AreArchsEqualInternalAsync(object arch1, object arch2)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_ui_view.py) ---
            // def _are_archs_equal(self, arch1, arch2):
            // # Note that comparing the strings would not be ok as attributes order
            // # must not be relevant
            // if arch1.tag != arch2.tag:
            //     return False
            // if arch1.text != arch2.text:
            //     return False
            // if arch1.tail != arch2.tail:
            //     return False
            // if arch1.attrib != arch2.attrib:
            //     return False
            // if len(arch1) != len(arch2):
            //     return False
            // return all(self._are_archs_equal(arch1, arch2) for arch1, arch2 in zip(arch1, arch2))
            */
            return default;
        }

        protected async Task<IrUiView> AutoInitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _auto_init(self):
            // res = super(View, self)._auto_init()
            // tools.create_index(self._cr, 'ir_ui_view_model_type_inherit_id',
            //                    self._table, ['model', 'inherit_id'])
            // return res
            */
            return default;
        }

        protected async Task<IrUiView> BuildHierarchyDatastructureInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def _build_hierarchy_datastructure(self):
            // inherit_children = []
            // for child in self.inherit_children_ids:
            //     inherit_children.append(child._build_hierarchy_datastructure())
            // return {
            //     'id': self.id,
            //     'name': self.name,
            //     'inherit_children': inherit_children,
            //     'arch_updated': self.arch_updated,
            //     'website_name': self.website_id.name if self.website_id else False,
            //     'active': self.active,
            //     'key': self.key,
            // }
            */
            return default;
        }

        protected async Task<IrUiView> Check000InheritanceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _check_000_inheritance(self):
            // # NOTE: constraints methods are check alphabetically. Always ensure this method will be
            // #       called before other constraint methods to avoid infinite loop in `_get_combined_arch`.
            // if self._has_cycle('inherit_id'):
            //     raise ValidationError(_('You cannot create recursive inherited views.'))
            */
            return default;
        }

        protected async Task<IrUiView> CheckDropdownMenuInternalAsync(object node)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _check_dropdown_menu(self, node):
            // # ('calendar', 'form', 'graph', 'kanban', 'pivot', 'search', 'list', 'activity')
            // if any('dropdown-menu' in node.get(cl, '') for cl in att_names('class')):
            //     if node.get('role') != 'menu':
            //         msg = 'dropdown-menu class must have menu role'
            //         self._log_view_warning(msg, node)
            */
            return default;
        }

        protected async Task<IrUiView> CheckFieldPathsInternalAsync(object node, object field_paths, object model_name, object use)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _check_field_paths(self, node, field_paths, model_name, use):
            // """ Check whether the given field paths (dot-separated field names)
            // correspond to actual sequences of fields on the given model.
            // """
            // for field_path in field_paths:
            //     names = field_path.split('.')
            //     Model = self.pool[model_name]
            //     if names[0] == 'parent':
            //         continue
            //     for index, name in enumerate(names):
            //         if Model is None:
            //             msg = _(
            //                 'Non-relational field “%(field)s” in path “%(field_path)s” in %(use)s)',
            //                 field=names[index - 1], field_path=field_path, use=use,
            //             )
            //             self._raise_view_error(msg, node)
            //         try:
            //             field = Model._fields[name]
            //         except KeyError:
            //             msg = _(
            //                 'Unknown field "%(model)s.%(field)s" in %(use)s)',
            //                 model=Model._name, field=name, use=use,
            //             )
            //             self._raise_view_error(msg, node)
            //         if not field._description_searchable:
            //             msg = _(
            //                 'Unsearchable field “%(field)s” in path “%(field_path)s” in %(use)s)',
            //                 field=name, field_path=field_path, use=use,
            //             )
            //             self._raise_view_error(msg, node)
            //         Model = self.pool.get(field.comodel_name)
            */
            return default;
        }

        protected async Task<IrUiView> CheckGroupsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _check_groups(self):
            // for view in self:
            //     if (view.groups_id and
            //         view.inherit_id and
            //         view.mode != 'primary'):
            //         raise ValidationError(_("Inherited view cannot have 'Groups' define on the record. Use 'groups' attributes inside the view definition"))
            */
            return default;
        }

        protected async Task<IrUiView> CheckProgressBarInternalAsync(object node)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _check_progress_bar(self, node):
            // if any('o_progressbar' in node.get(cl, '') for cl in att_names('class')):
            //     if node.get('role') != 'progressbar':
            //         msg = 'o_progressbar class must have progressbar role'
            //         self._log_view_warning(msg, node)
            //     if not any(node.get(at) for at in att_names('aria-valuenow')):
            //         msg = 'o_progressbar class must have aria-valuenow attribute'
            //         self._log_view_warning(msg, node)
            //     if not any(node.get(at) for at in att_names('aria-valuemin')):
            //         msg = 'o_progressbar class must have aria-valuemin attribute'
            //         self._log_view_warning(msg, node)
            //     if not any(node.get(at) for at in att_names('aria-valuemax')):
            //         msg = 'o_progressbar class must have aria-valuemaxattribute'
            //         self._log_view_warning(msg, node)
            */
            return default;
        }

        protected async Task<IrUiView> CheckViewAccessInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _check_view_access(self):
            // """ Verify that a view is accessible by the current user based on the
            // groups attribute. Views with no groups are considered private.
            // """
            // if self.inherit_id and self.mode != 'primary':
            //     return self.inherit_id._check_view_access()
            // if self.groups_id & self.env.user.groups_id:
            //     return True
            // if self.groups_id:
            //     error = _(
            //         "View '%(name)s' accessible only to groups %(groups)s ",
            //         name=self.key,
            //         groups=", ".join([g.name for g in self.groups_id]
            //     ))
            // else:
            //     error = _("View '%(name)s' is private", name=self.key)
            // raise AccessError(error)
            */
            return default;
        }

        protected async Task<IrUiView> CheckXmlInternalAsync()
        {
            #if PYTHON_CODE
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _check_xml(self):
            // # Sanity checks: the view should not break anything upon rendering!
            // # Any exception raised below will cause a transaction rollback.
            // partial_validation = self.env.context.get('ir_ui_view_partial_validation')
            // self = self.with_context(validate_view_ids=(self._ids if partial_validation else True))
            // 
            // for view in self:
            //     try:
            //         # verify the view is valid xml and that the inheritance resolves
            //         if view.inherit_id:
            //             view_arch = etree.fromstring(view.arch or '<data/>')
            //             view._valid_inheritance(view_arch)
            //         combined_arch = view._get_combined_arch()
            //         if view.type == 'qweb':
            //             continue
            //     except (etree.ParseError, ValueError) as e:
            //         err = ValidationError(_(
            //             "Error while parsing or validating view:\n\n%(error)s",
            //             error=e,
            //             view=view.key or view.id,
            //         )).with_traceback(e.__traceback__)
            //         err.context = getattr(e, 'context', None)
            //         raise err from None
            // 
            //     try:
            //         # verify that all fields used are valid, etc.
            //         view._validate_view(combined_arch, view.model)
            //         combined_archs = [combined_arch]
            // 
            //         if combined_arch.xpath('//*[@attrs]') or combined_arch.xpath('//*[@states]'):
            //             view_name = f'{view.name} ({view.xml_id})' if view.xml_id else view.name
            //             err = ValidationError(_('Since 17.0, the "attrs" and "states" attributes are no longer used.\nView: %(name)s in %(file)s',
            //                 name=view_name, file=view.arch_fs
            //             ))
            //             err.context = {'name': 'invalid view'}
            //             raise err
            // 
            //         if combined_archs[0].tag == 'data':
            //             # A <data> element is a wrapper for multiple root nodes
            //             combined_archs = combined_archs[0]
            //         for view_arch in combined_archs:
            //             for node in view_arch.xpath('//*[@__validate__]'):
            //                 del node.attrib['__validate__']
            //             check = valid_view(view_arch, env=self.env, model=view.model)
            //             if not check:
            //                 view_name = f'{view.name} ({view.xml_id})' if view.xml_id else view.name
            //                 raise ValidationError(_(
            //                     'Invalid view %(name)s definition in %(file)s',
            //                     name=view_name, file=view.arch_fs
            //                 ))
            //     except ValueError as e:
            //         if hasattr(e, 'context'):
            //             lines = etree.tostring(combined_arch, encoding='unicode').splitlines(keepends=True)
            //             fivelines = "".join(lines[max(0, e.context["line"]-3):e.context["line"]+2])
            //             err = ValidationError(_(
            //                 "Error while validating view near:\n\n%(fivelines)s\n%(error)s",
            //                 fivelines=fivelines, error=e,
            //             ))
            //             err.context = e.context
            //             raise err.with_traceback(e.__traceback__) from None
            //         elif e.__context__:
            //             err = ValidationError(_(
            //                 "Error while validating view (%(view)s):\n\n%(error)s", view=view.key or view.id, error=e.__context__,
            //             ))
            //             err.context = {'name': 'invalid view'}
            //             raise err.with_traceback(e.__context__.__traceback__) from None
            //         else:
            //             raise ValidationError(_(
            //                 "Error while validating view (%(view)s):\n\n%(error)s", view=view.key or view.id, error=e,
            //             ))
            // 
            // return True
            #endif
            return default;
        }

        protected async Task<IrUiView> CombineInternalAsync(Dictionary<string, object> hierarchy)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _combine(self, hierarchy: dict):
            // """
            // Return self's arch combined with its inherited views archs.
            // 
            // :param hierarchy: mapping from parent views to their child views
            // :return: combined architecture
            // :rtype: Element
            // """
            // self.ensure_one()
            // assert self.mode == 'primary'
            // 
            // # We achieve a pre-order depth-first hierarchy traversal where
            // # primary views (and their children) are traversed after all the
            // # extensions for the current primary view have been visited.
            // #
            // # https://en.wikipedia.org/wiki/Tree_traversal#Depth-first_search_of_binary_tree
            // #
            // # Example:                  hierarchy = {
            // #                               1: [2, 3],  # primary view
            // #             1*                2: [4, 5],
            // #            / \                3: [],
            // #           2   3               4: [6],     # primary view
            // #          / \                  5: [7, 8],
            // #         4*  5                 6: [],
            // #        /   / \                7: [],
            // #       6   7   8               8: [],
            // #                           }
            // #
            // # Tree traversal order (`view` and `queue` at the `while` stmt):
            // #   1 [2, 3]
            // #   2 [5, 3, 4]
            // #   5 [7, 8, 3, 4]
            // #   7 [8, 3, 4]
            // #   8 [3, 4]
            // #   3 [4]
            // #   4 [6]
            // #   6 []
            // combined_arch = etree.fromstring(self.arch)
            // if self.env.context.get('inherit_branding'):
            //     combined_arch.attrib.update({
            //         'data-oe-model': 'ir.ui.view',
            //         'data-oe-id': str(self.id),
            //         'data-oe-field': 'arch',
            //     })
            // self._add_validation_flag(combined_arch)
            // 
            // # The depth-first traversal is implemented with a double-ended queue.
            // # The queue is traversed from left to right, and after each view in the
            // # queue is processed, its children are pushed at the left of the queue,
            // # so that they are traversed in order.  The queue is therefore mostly
            // # used as a stack.  An exception is made for primary views, which are
            // # pushed at the other end of the queue, so that they are applied after
            // # all extensions have been applied.
            // queue = collections.deque(sorted(hierarchy[self], key=lambda v: v.mode))
            // while queue:
            //     view = queue.popleft()
            //     arch = etree.fromstring(view.arch or '<data/>')
            //     if view.env.context.get('inherit_branding'):
            //         view.inherit_branding(arch)
            //     self._add_validation_flag(combined_arch, view, arch)
            //     combined_arch = view.apply_inheritance_specs(combined_arch, arch)
            // 
            //     for child_view in reversed(hierarchy[view]):
            //         if child_view.mode == 'primary':
            //             queue.append(child_view)
            //         else:
            //             queue.appendleft(child_view)
            // 
            // return combined_arch
            */
            return default;
        }

        protected async Task<IrUiView> ComputeArchBaseInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _compute_arch_base(self):
            // # 'arch_base' is the same as 'arch' without translation
            // for view, view_wo_lang in zip(self, self.with_context(lang=None)):
            //     view.arch_base = view_wo_lang.arch
            */
            return default;
        }

        protected async Task<IrUiView> ComputeArchInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _compute_arch(self):
            // def resolve_external_ids(arch_fs, view_xml_id):
            //     def replacer(m):
            //         xmlid = m.group('xmlid')
            //         if '.' not in xmlid:
            //             xmlid = '%s.%s' % (view_xml_id.split('.')[0], xmlid)
            //         return m.group('prefix') + str(self.env['ir.model.data']._xmlid_to_res_id(xmlid))
            //     return re.sub(r'(?P<prefix>[^%])%\((?P<xmlid>.*?)\)[ds]', replacer, arch_fs)
            // 
            // lang = self.env.lang or 'en_US'
            // env_en = self.with_context(edit_translations=None, lang='en_US').env
            // env_lang = self.with_context(lang=lang).env
            // field_arch_db = self._fields['arch_db']
            // for view in self:
            //     arch_fs = None
            //     read_file = self._context.get('read_arch_from_file') or \
            //         ('xml' in config['dev_mode'] and not view.arch_updated)
            //     if read_file and view.arch_fs and (view.xml_id or view.key):
            //         xml_id = view.xml_id or view.key
            //         # It is safe to split on / herebelow because arch_fs is explicitely stored with '/'
            //         try:
            //             fullpath = file_path(view.arch_fs)
            //         except FileNotFoundError:
            //             _logger.warning("View %s: Full path [%s] cannot be found.", xml_id, view.arch_fs)
            //             arch_fs = False
            //             continue
            // 
            //         arch_fs = get_view_arch_from_file(fullpath, xml_id)
            //         # replace %(xml_id)s, %(xml_id)d, %%(xml_id)s, %%(xml_id)d by the res_id
            //         if arch_fs:
            //             arch_fs = resolve_external_ids(arch_fs, xml_id).replace('%%', '%')
            //             translation_dictionary = field_arch_db.get_translation_dictionary(
            //                 view.with_env(env_en).arch_db, {lang: view.with_env(env_lang).arch_db}
            //             )
            //             arch_fs = field_arch_db.translate(
            //                 lambda term: translation_dictionary[term][lang],
            //                 arch_fs
            //             )
            //     view.arch = arch_fs or view.arch_db
            */
            return default;
        }

        protected async Task<IrUiView> ComputeDefaultsInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _compute_defaults(self, values):
            // if 'inherit_id' in values:
            //     # Do not automatically change the mode if the view already has an inherit_id,
            //     # and the user change it to another.
            //     if not values['inherit_id'] or all(not view.inherit_id for view in self):
            //         values.setdefault('mode', 'extension' if values['inherit_id'] else 'primary')
            // return values
            */
            return default;
        }

        protected async Task<IrUiView> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def _compute_display_name(self):
            // if not (self._context.get('display_key') or self._context.get('display_website')):
            //     return super()._compute_display_name()
            // 
            // for view in self:
            //     view_name = view.name
            //     if self._context.get('display_key'):
            //         view_name += ' <%s>' % view.key
            //     if self._context.get('display_website') and view.website_id:
            //         view_name += ' [%s]' % view.website_id.name
            //     view.display_name = view_name
            */
            return default;
        }

        protected async Task<IrUiView> ComputeFirstPageIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def _compute_first_page_id(self):
            // for view in self:
            //     view.first_page_id = self.env['website.page'].search([('view_id', '=', view.id)], limit=1)
            */
            return default;
        }

        protected async Task<IrUiView> ComputeModelDataIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _compute_model_data_id(self):
            // # get the first ir_model_data record corresponding to self
            // for view in self:
            //     view.model_data_id = False
            // domain = [('model', '=', 'ir.ui.view'), ('res_id', 'in', self.ids)]
            // for data in self.env['ir.model.data'].sudo().search_read(domain, ['res_id'], order='id desc'):
            //     view = self.browse(data['res_id'])
            //     view.model_data_id = data['id']
            */
            return default;
        }

        protected async Task<IrUiView> ComputeModelIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _compute_model_id(self):
            // for record in self:
            //     record.model_id = self.env['ir.model']._get(record.model)
            */
            return default;
        }

        protected async Task<IrUiView> ComputeWarningInfoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _compute_warning_info(self):
            // for view in self:
            //     view.warning_info = ''
            //     try:
            //         if view.inherit_id:
            //             view_arch = etree.fromstring(view.arch)
            //             view._valid_inheritance(view_arch)
            //         combined_arch = view._get_combined_arch()
            //         if view.type != 'qweb':
            //             view._postprocess_view(combined_arch, view.model, is_compute_warning_info=True)
            //     except (etree.ParseError, ValueError) as e:
            //         view.warning_info = str(e)
            */
            return default;
        }

        protected async Task<IrUiView> ComputeXmlIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _compute_xml_id(self):
            // xml_ids = collections.defaultdict(list)
            // domain = [('model', '=', 'ir.ui.view'), ('res_id', 'in', self.ids)]
            // for data in self.env['ir.model.data'].sudo().search_read(domain, ['module', 'name', 'res_id']):
            //     xml_ids[data['res_id']].append("%s.%s" % (data['module'], data['name']))
            // for view in self:
            //     view.xml_id = xml_ids.get(view.id, [''])[0]
            */
            return default;
        }

        protected async Task<IrUiView> ContainsBrandedInternalAsync(object node)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _contains_branded(self, node):
            // return node.tag == 't'\
            //     or 't-raw' in node.attrib\
            //     or 't-call' in node.attrib\
            //     or any(self.is_node_branded(child) for child in node.iterdescendants())
            */
            return default;
        }

        protected async Task<IrUiView> CopyCustomSnippetTranslationsInternalAsync(object record, object html_field)
        {
            #if PYTHON_CODE
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_ui_view.py) ---
            // def _copy_custom_snippet_translations(self, record, html_field):
            // """ Given a ``record`` and its HTML ``field``, detect any
            // usage of a custom snippet and copy its translations.
            // """
            // lang_value = record[html_field]
            // if not lang_value:
            //     return
            // 
            // tree = html.fromstring(lang_value)
            // for custom_snippet_el in tree.xpath('//*[hasclass("s_custom_snippet")]'):
            //     custom_snippet_name = custom_snippet_el.get('data-name')
            //     custom_snippet_view = self.search([('name', '=', custom_snippet_name)], limit=1)
            //     if custom_snippet_view:
            //         self._copy_field_terms_translations(custom_snippet_view, 'arch_db', record, html_field)
            #endif
            return default;
        }

        public async Task<IrUiView> CopyDataAsync(Guid id, IrUiViewCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def copy_data(self, default=None):
            // has_default_without_key = default and 'key' not in default
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // for view, vals in zip(self, vals_list):
            //     if view.key and has_default_without_key:
            //         vals['key'] = default.get('key', view.key + '_%s' % str(uuid.uuid4())[:6])
            // return vals_list
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrUiView> CopyFieldTermsTranslationsInternalAsync(object records_from, object name_field_from, object record_to, object name_field_to)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_ui_view.py) ---
            // def _copy_field_terms_translations(self, records_from, name_field_from, record_to, name_field_to):
            // """ Copy model terms translations from ``records_from.name_field_from``
            // to ``record_to.name_field_to`` for all activated languages if the term
            // in ``record_to.name_field_to`` is untranslated (the term matches the
            // one in the current language).
            // 
            // For instance, copy the translations of a
            // ``product.template.html_description`` field to a ``ir.ui.view.arch_db``
            // field.
            // 
            // The method takes care of read and write access of both records/fields.
            // """
            // record_to.check_access('write')
            // record_to.check_field_access_rights('write', [name_field_to])
            // 
            // field_from = records_from._fields[name_field_from]
            // field_to = record_to._fields[name_field_to]
            // error_callable_msg = "'translate' property of field %r is not callable"
            // if not callable(field_from.translate):
            //     raise ValueError(error_callable_msg % field_from)
            // if not callable(field_to.translate):
            //     raise ValueError(error_callable_msg % field_to)
            // if not field_to.store:
            //     raise ValueError("Field %r is not stored" % field_to)
            // 
            // # This will also implicitly check for `read` access rights
            // if not record_to[name_field_to] or not any(records_from.mapped(name_field_from)):
            //     return
            // 
            // lang_env = self.env.lang or 'en_US'
            // langs = set(lang for lang, _ in self.env['res.lang'].get_installed())
            // 
            // # 1. Get translations
            // records_from.flush_model([name_field_from])
            // existing_translation_dictionary = field_to.get_translation_dictionary(
            //     record_to[name_field_to],
            //     {lang: record_to.with_context(prefetch_langs=True, lang=lang)[name_field_to] for lang in langs if lang != lang_env}
            // )
            // extra_translation_dictionary = {}
            // for record_from in records_from:
            //     extra_translation_dictionary.update(field_from.get_translation_dictionary(
            //         record_from[name_field_from],
            //         {lang: record_from.with_context(prefetch_langs=True, lang=lang)[name_field_from] for lang in langs if lang != lang_env}
            //     ))
            // for term, extra_translation_values in extra_translation_dictionary.items():
            //     existing_translation_values = existing_translation_dictionary.setdefault(term, {})
            //     # Update only default translation values that aren't customized by the user.
            //     for lang, extra_translation in extra_translation_values.items():
            //         if existing_translation_values.get(lang, term) == term:
            //             existing_translation_values[lang] = extra_translation
            // translation_dictionary = existing_translation_dictionary
            // 
            // # The `en_US` jsonb value should always be set, even if english is not
            // # installed. If we don't do this, the custom snippet `arch_db` will only
            // # have a `fr_BE` key but no `en_US` key.
            // langs.add('en_US')
            // 
            // # 2. Set translations
            // new_value = {
            //     lang: field_to.translate(lambda term: translation_dictionary.get(term, {}).get(lang), record_to[name_field_to])
            //     for lang in langs
            // }
            // record_to.env.cache.update_raw(record_to, field_to, [new_value], dirty=True)
            // # Call `write` to trigger compute etc (`modified()`)
            // record_to[name_field_to] = new_value[lang_env]
            */
            return default;
        }

        protected async Task<IrUiView> CreateAllSpecificViewsInternalAsync(object processed_modules)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def _create_all_specific_views(self, processed_modules):
            // """ When creating a generic child view, we should
            //     also create that view under specific view trees (COW'd).
            //     Top level view (no inherit_id) do not need that behavior as they
            //     will be shared between websites since there is no specific yet.
            // """
            // # Only for the modules being processed
            // regex = '^(%s)[.]' % '|'.join(processed_modules)
            // # Retrieve the views through a SQl query to avoid ORM queries inside of for loop
            // # Retrieves all the views that are missing their specific counterpart with all the
            // # specific view parent id and their website id in one query
            // query = """
            //     SELECT generic.id, ARRAY[array_agg(spec_parent.id), array_agg(spec_parent.website_id)]
            //       FROM ir_ui_view generic
            // INNER JOIN ir_ui_view generic_parent ON generic_parent.id = generic.inherit_id
            // INNER JOIN ir_ui_view spec_parent ON spec_parent.key = generic_parent.key
            //  LEFT JOIN ir_ui_view specific ON specific.key = generic.key AND specific.website_id = spec_parent.website_id
            //      WHERE generic.type='qweb'
            //        AND generic.website_id IS NULL
            //        AND generic.key ~ %s
            //        AND spec_parent.website_id IS NOT NULL
            //        AND specific.id IS NULL
            //   GROUP BY generic.id
            // """
            // self.env.cr.execute(query, (regex, ))
            // result = dict(self.env.cr.fetchall())
            // 
            // for record in self.browse(result.keys()):
            //     specific_parent_view_ids, website_ids = result[record.id]
            //     for specific_parent_view_id, website_id in zip(specific_parent_view_ids, website_ids):
            //         record.with_context(website_id=website_id).write({
            //             'inherit_id': specific_parent_view_id,
            //         })
            // super(View, self)._create_all_specific_views(processed_modules)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _create_all_specific_views(self, processed_modules):
            // """To be overriden and have specific view behaviour on create"""
            // pass
            */
            return default;
        }

        public override async Task<IrUiView> CreateAsync(IrUiView entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def create(self, vals_list):
            // """
            // SOC for ir.ui.view creation. If a view is created without a website_id,
            // it should get one if one is present in the context. Also check that
            // an explicit website_id in create values matches the one in the context.
            // """
            // website_id = self.env.context.get('website_id', False)
            // if not website_id:
            //     return super().create(vals_list)
            // 
            // for vals in vals_list:
            //     if 'website_id' not in vals:
            //         # Automatic addition of website ID during view creation if not
            //         # specified but present in the context
            //         vals['website_id'] = website_id
            //     else:
            //         # If website ID specified, automatic check that it is the same as
            //         # the one in the context. Otherwise raise an error.
            //         new_website_id = vals['website_id']
            //         if not new_website_id:
            //             raise ValueError(f"Trying to create a generic view from a website {website_id} environment")
            //         elif new_website_id != website_id:
            //             raise ValueError(f"Trying to create a view for website {new_website_id} from a website {website_id} environment")
            // return super().create(vals_list)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def create(self, vals_list):
            // for values in vals_list:
            //     if 'arch_db' in values and not values['arch_db']:
            //         # delete empty arch_db to avoid triggering _check_xml before _inverse_arch_base is called
            //         del values['arch_db']
            // 
            //     if not values.get('type'):
            //         if values.get('inherit_id'):
            //             values['type'] = self.browse(values['inherit_id']).type
            //         else:
            // 
            //             try:
            //                 if not values.get('arch') and not values.get('arch_base'):
            //                     raise ValidationError(_('Missing view architecture.'))
            //                 values['type'] = etree.fromstring(values.get('arch') or values.get('arch_base')).tag
            //             except LxmlError:
            //                 # don't raise here, the constraint that runs `self._check_xml` will
            //                 # do the job properly.
            //                 pass
            //     if not values.get('key') and values.get('type') == 'qweb':
            //         values['key'] = "gen_key.%s" % str(uuid.uuid4())[:6]
            //     if not values.get('name'):
            //         values['name'] = "%s %s" % (values.get('model'), values['type'])
            //     # Create might be called with either `arch` (xml files), `arch_base` (form view) or `arch_db`.
            //     values['arch_prev'] = values.get('arch_base') or values.get('arch_db') or values.get('arch')
            //     # write on arch: bypass _inverse_arch()
            //     if 'arch' in values:
            //         values['arch_db'] = values.pop('arch')
            //         if 'install_filename' in self._context:
            //             # we store the relative path to the resource instead of the absolute path, if found
            //             # (it will be missing e.g. when importing data-only modules using base_import_module)
            //             path_info = get_resource_from_path(self._context['install_filename'])
            //             if path_info:
            //                 values['arch_fs'] = '/'.join(path_info[0:2])
            //                 values['arch_updated'] = False
            //     values.update(self._compute_defaults(values))
            // 
            // self.env.registry.clear_cache('templates')
            // result = super(View, self.with_context(ir_ui_view_partial_validation=True)).create(vals_list)
            // return result.with_env(self.env)
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<IrUiView> CreateWebsiteSpecificPagesForViewInternalAsync(object new_view, object website)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def _create_website_specific_pages_for_view(self, new_view, website):
            // for page in self.page_ids:
            //     # create new pages for this view
            //     new_page = page.copy({
            //         'view_id': new_view.id,
            //         'is_published': page.is_published,
            //     })
            //     page.menu_ids.filtered(lambda m: m.website_id.id == website.id).page_id = new_page.id
            */
            return default;
        }

        public async Task<IrUiView> DefaultViewAsync(Guid id, IrUiViewDefaultViewRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def default_view(self, model, view_type):
            // """ Fetches the default view for the provided (model, view_type) pair:
            //  primary view with the lowest priority.
            // 
            // :param str model:
            // :param int view_type:
            // :return: id of the default view of False if none found
            // :rtype: int
            // """
            // domain = [('model', '=', model), ('type', '=', view_type), ('mode', '=', 'primary')]
            // return self.search(domain, limit=1).id
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrUiView> DeleteSnippetAsync(Guid id, IrUiViewDeleteSnippetRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_ui_view.py) ---
            // def delete_snippet(self, view_id, template_key):
            // snippet_view = self.browse(view_id)
            // key = snippet_view.key.split('.')[1]
            // custom_key = self._get_snippet_addition_view_key(template_key, key)
            // snippet_addition_view = self.search([('key', '=', custom_key)])
            // (snippet_addition_view | snippet_view).unlink()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrUiView> DistributeBrandingAsync(Guid id, IrUiViewDistributeBrandingRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def distribute_branding(self, e, branding=None, parent_xpath='',
            //                     index_map=ConstantMapping(1)):
            // if e.get('t-ignore') or e.tag == 'head':
            //     # remove any view branding possibly injected by inheritance
            //     attrs = set(MOVABLE_BRANDING)
            //     for descendant in e.iterdescendants(tag=etree.Element):
            //         if not attrs.intersection(descendant.attrib):
            //             continue
            //         self._pop_view_branding(descendant)
            // 
            //     # Remove the processing instructions indicating where nodes were
            //     # removed (see apply_inheritance_specs)
            //     for descendant in e.iterdescendants(tag=etree.ProcessingInstruction):
            //         if descendant.target == 'apply-inheritance-specs-node-removal':
            //             descendant.getparent().remove(descendant)
            //     return
            // 
            // node_path = e.get('data-oe-xpath')
            // if node_path is None:
            //     # Handle special case for jump points defined by the magic template
            //     # <t>$0</t>. No branding is allowed in this case since it points to
            //     # a generic template.
            //     if e.get('data-oe-no-branding'):
            //         e.attrib.pop('data-oe-no-branding')
            //         return
            //     node_path = "%s/%s[%d]" % (parent_xpath, e.tag, index_map[e.tag])
            // if branding:
            //     if e.get('t-field'):
            //         e.set('data-oe-xpath', node_path)
            //     elif not e.get('data-oe-model'):
            //         e.attrib.update(branding)
            //         e.set('data-oe-xpath', node_path)
            // if not e.get('data-oe-model'):
            //     return
            // 
            // if {'t-esc', 't-raw', 't-out'}.intersection(e.attrib):
            //     # nodes which fully generate their content and have no reason to
            //     # be branded because they can not sensibly be edited
            //     self._pop_view_branding(e)
            // elif self._contains_branded(e):
            //     # if a branded element contains branded elements distribute own
            //     # branding to children unless it's t-raw, then just remove branding
            //     # on current element
            //     distributed_branding = self._pop_view_branding(e)
            // 
            //     if 't-raw' not in e.attrib:
            //         # TODO: collections.Counter if remove p2.6 compat
            //         # running index by tag type, for XPath query generation
            //         indexes = collections.defaultdict(lambda: 0)
            //         for child in e.iterchildren(etree.Element, etree.ProcessingInstruction):
            //             if child.get('data-oe-xpath'):
            //                 # injected by view inheritance, skip otherwise
            //                 # generated xpath is incorrect
            //                 self.distribute_branding(child)
            //             elif child.tag is etree.ProcessingInstruction:
            //                 # If a node is known to have been replaced during
            //                 # applying an inheritance, increment its index to
            //                 # compute an accurate xpath for subsequent nodes
            //                 if child.target == 'apply-inheritance-specs-node-removal':
            //                     indexes[child.text] += 1
            //                     e.remove(child)
            //             else:
            //                 indexes[child.tag] += 1
            //                 self.distribute_branding(
            //                     child, distributed_branding,
            //                     parent_xpath=node_path, index_map=indexes)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrUiView> EditableNodeInternalAsync(object node, object name_manager)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _editable_node(self, node, name_manager):
            // """ Return whether the given node must be considered editable. """
            // func = getattr(self, f"_editable_tag_{node.tag}", None)
            // if func is not None:
            //     return func(node, name_manager)
            // # by default views are non-editable
            // return node.tag not in (item[0] for item in self._fields['type'].selection)
            */
            return default;
        }

        protected async Task<IrUiView> EditableTagFieldInternalAsync(object node, object name_manager)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _editable_tag_field(self, node, name_manager):
            // field = name_manager.model._fields.get(node.get('name'))
            // return field is None or field.is_editable() and node.get('readonly') not in ('1', 'True')
            */
            return default;
        }

        protected async Task<IrUiView> EditableTagFormInternalAsync(object node, object name_manager)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _editable_tag_form(self, node, name_manager):
            // return True
            */
            return default;
        }

        protected async Task<IrUiView> EditableTagListInternalAsync(object node, object name_manager)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _editable_tag_list(self, node, name_manager):
            // return node.get('editable') or node.get('multi_edit')
            */
            return default;
        }

        public async Task<IrUiView> ExtractEmbeddedFieldsAsync(Guid id, IrUiViewExtractEmbeddedFieldsRequestDto input)
        {
            #if PYTHON_CODE
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_ui_view.py) ---
            // def extract_embedded_fields(self, arch):
            // return arch.xpath('//*[@data-oe-model != "ir.ui.view"]')
            #endif
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrUiView> ExtractOeStructuresAsync(Guid id, IrUiViewExtractOeStructuresRequestDto input)
        {
            #if PYTHON_CODE
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_ui_view.py) ---
            // def extract_oe_structures(self, arch):
            // return arch.xpath('//*[hasclass("oe_structure")][contains(@id, "oe_structure")]')
            #endif
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrUiView> FilterDuplicateAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def filter_duplicate(self):
            // """ Filter current recordset only keeping the most suitable view per distinct key.
            //     Every non-accessible view will be removed from the set:
            //       * In non website context, every view with a website will be removed
            //       * In a website context, every view from another website
            // """
            // current_website_id = self._context.get('website_id')
            // most_specific_views = self.env['ir.ui.view']
            // if not current_website_id:
            //     return self.filtered(lambda view: not view.website_id)
            // 
            // for view in self:
            //     # specific view: add it if it's for the current website and ignore
            //     # it if it's for another website
            //     if view.website_id and view.website_id.id == current_website_id:
            //         most_specific_views |= view
            //     # generic view: add it only if, for the current website, there is no
            //     # specific view for this view (based on the same `key` attribute)
            //     elif not view.website_id and not any(view.key == view2.key and view2.website_id and view2.website_id.id == current_website_id for view2 in self):
            //         most_specific_views |= view
            // 
            // return most_specific_views
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrUiView> FilterLoadedViewsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _filter_loaded_views(self):
            // """
            // During the module upgrade phase it may happen that a view is
            // present in the database but the fields it relies on are not
            // fully loaded yet. This method only considers views that belong
            // to modules whose code is already loaded. Custom views defined
            // directly in the database are loaded only after the module
            // initialization phase is completely finished.
            // """
            // # check that all found ids have a corresponding xml_id in a loaded module
            // check_view_ids = set(self.env.context['check_view_ids'])
            // ids_to_check = [vid for vid in self.ids if vid not in check_view_ids]
            // if not ids_to_check:
            //     return self
            // loaded_modules = tuple(self.pool._init_modules) + (self._context.get('install_module'),)
            // query = self._get_filter_xmlid_query()
            // sql = SQL(query, res_ids=tuple(ids_to_check), modules=loaded_modules)
            // valid_view_ids = {id_ for id_, in self.env.execute_query(sql)} | check_view_ids
            // return self.browse(vid for vid in self.ids if vid in valid_view_ids)
            */
            return default;
        }

        protected async Task<IrUiView> FindAvailableNameInternalAsync(object name, object used_names)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_ui_view.py) ---
            // def _find_available_name(self, name, used_names):
            // attempt = 1
            // candidate_name = name
            // while candidate_name in used_names:
            //     attempt += 1
            //     candidate_name = f"{name} ({attempt})"
            // return candidate_name
            */
            return default;
        }

        protected async Task<IrUiView> GetAllowedRootAttrsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_ui_view.py) ---
            // def _get_allowed_root_attrs(self):
            // return ['style', 'class', 'target', 'href']
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def _get_allowed_root_attrs(self):
            // # Related to these options:
            // # background-video, background-shapes, parallax, visibility
            // return super()._get_allowed_root_attrs() + [
            //     'data-bg-video-src', 'data-shape', 'data-scroll-background-ratio',
            //     'data-visibility', 'data-visibility-id', 'data-visibility-selectors',
            // ] + [
            //     'data-visibility-value-' + param + suffix
            //     for param in ('country', 'lang', 'logged', 'utm-campaign', 'utm-medium', 'utm-source')
            //     for suffix in ('', '-rule')
            // ]
            */
            return default;
        }

        protected async Task<IrUiView> GetBaseLangInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def _get_base_lang(self):
            // """ Returns the default language of the website as the base language if the record is bound to it """
            // self.ensure_one()
            // website = self.website_id
            // if website:
            //     return website.default_lang_id.code
            // return super()._get_base_lang()
            */
            return default;
        }

        protected async Task<IrUiView> GetCachedVisibilityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def _get_cached_visibility(self):
            // return self.visibility
            */
            return default;
        }

        protected async Task<IrUiView> GetCleanedNonEditingAttributesInternalAsync(object attributes)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_ui_view.py) ---
            // def _get_cleaned_non_editing_attributes(self, attributes):
            // """
            // Returns a new mapping of attributes -> value without the parts that are
            // not meant to be saved (branding, editing classes, ...). Note that
            // classes are meant to be cleaned on the client side before saving as
            // mostly linked to the related options (so we are not supposed to know
            // which to remove here).
            // 
            // :param attributes: a mapping of attributes -> value
            // :return: a new mapping of attributes -> value
            // """
            // attributes = {k: v for k, v in attributes if k not in EDITING_ATTRIBUTES}
            // if 'class' in attributes:
            //     classes = attributes['class'].split()
            //     attributes['class'] = ' '.join([c for c in classes if c != 'o_editable'])
            // if attributes.get('contenteditable') == 'true':
            //     del attributes['contenteditable']
            // return attributes
            */
            return default;
        }

        public async Task<IrUiView> GetCombinedArchAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def get_combined_arch(self):
            // """ Return the arch of ``self`` (as a string) combined with its inherited views. """
            // return etree.tostring(self._get_combined_arch(), encoding='unicode')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrUiView> GetCombinedArchInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def _get_combined_arch(self):
            // root = super()._get_combined_arch()
            // add_form_signature(root, self.sudo().env)
            // return root
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _get_combined_arch(self):
            // """ Return the arch of ``self`` (as an etree) combined with its inherited views. """
            // root = self
            // view_ids = []
            // while True:
            //     view_ids.append(root.id)
            //     if not root.inherit_id:
            //         break
            //     root = root.inherit_id
            // 
            // views = self.browse(view_ids)
            // 
            // # Add inherited views to the list of loading forced views
            // # Otherwise, inherited views could not find elements created in
            // # their direct parents if that parent is defined in the same module
            // # introduce check_view_ids in context
            // if 'check_view_ids' not in views.env.context:
            //     views = views.with_context(check_view_ids=[])
            // views.env.context['check_view_ids'].extend(view_ids)
            // 
            // # Map each node to its children nodes. Note that all children nodes are
            // # part of a single prefetch set, which is all views to combine.
            // tree_views = views._get_inheriting_views()
            // hierarchy = collections.defaultdict(list)
            // for view in tree_views:
            //     hierarchy[view.inherit_id].append(view)
            // 
            // # optimization: make root part of the prefetch set, too
            // arch = root.with_prefetch(tree_views._prefetch_ids)._combine(hierarchy)
            // return arch
            */
            return default;
        }

        public async Task<IrUiView> GetDefaultLangCodeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_ui_view.py) ---
            // def get_default_lang_code(self):
            // return False
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def get_default_lang_code(self):
            // website_id = self.env.context.get('website_id')
            // if website_id:
            //     lang_code = self.env['website'].browse(website_id).default_lang_id.code
            //     return lang_code
            // else:
            //     return super(View, self).get_default_lang_code()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrUiView> GetFilterXmlidQueryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def _get_filter_xmlid_query(self):
            // """This method add some specific view that do not have XML ID
            // """
            // if not self._context.get('website_id'):
            //     return super()._get_filter_xmlid_query()
            // else:
            //     return """SELECT res_id
            //             FROM   ir_model_data
            //             WHERE  res_id IN %(res_ids)s
            //                 AND model = 'ir.ui.view'
            //                 AND module  IN %(modules)s
            //             UNION
            //             SELECT sview.id
            //             FROM   ir_ui_view sview
            //                 INNER JOIN ir_ui_view oview USING (key)
            //                 INNER JOIN ir_model_data d
            //                         ON oview.id = d.res_id
            //                             AND d.model = 'ir.ui.view'
            //                             AND d.module  IN %(modules)s
            //             WHERE  sview.id IN %(res_ids)s
            //                 AND sview.website_id IS NOT NULL
            //                 AND oview.website_id IS NULL;
            //             """
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _get_filter_xmlid_query(self):
            // """This method is meant to be overridden by other modules.
            // """
            // return """SELECT res_id FROM ir_model_data
            //           WHERE res_id IN %(res_ids)s AND model = 'ir.ui.view' AND module IN %(modules)s
            //        """
            */
            return default;
        }

        protected async Task<IrUiView> GetInheritingViewsDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def _get_inheriting_views_domain(self):
            // domain = super(View, self)._get_inheriting_views_domain()
            // current_website = self.env['website'].browse(self._context.get('website_id'))
            // website_views_domain = current_website.website_domain()
            // # when rendering for the website we have to include inactive views
            // # we will prefer inactive website-specific views over active generic ones
            // if current_website:
            //     domain = [leaf for leaf in domain if 'active' not in leaf]
            // return expression.AND([website_views_domain, domain])
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _get_inheriting_views_domain(self):
            // """ Return a domain to filter the sub-views to inherit from. """
            // return [('active', '=', True)]
            */
            return default;
        }

        protected async Task<IrUiView> GetInheritingViewsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def _get_inheriting_views(self):
            // if not self._context.get('website_id'):
            //     return super(View, self)._get_inheriting_views()
            // 
            // views = super(View, self.with_context(active_test=False))._get_inheriting_views()
            // # prefer inactive website-specific views over active generic ones
            // return views.filter_duplicate().filtered('active')
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _get_inheriting_views(self):
            // """
            // Determine the views that inherit from the current recordset, and return
            // them as a recordset, ordered by priority then by id.
            // """
            // if not self.ids:
            //     return self.browse()
            // self.browse().check_access('read')
            // domain = self._get_inheriting_views_domain()
            // e = expression(domain, self.env['ir.ui.view'])
            // where_clause = e.query.where_clause
            // assert e.query.from_clause == SQL.identifier('ir_ui_view'), f"Unexpected from clause: {e.query.from_clause}"
            // 
            // self.flush_model(['inherit_id', 'priority', 'model', 'mode'])
            // query = SQL("""
            //     WITH RECURSIVE ir_ui_view_inherits AS (
            //         SELECT id, inherit_id, priority, mode, model
            //         FROM ir_ui_view
            //         WHERE id IN %(ids)s AND (%(where_clause)s)
            //     UNION
            //         SELECT ir_ui_view.id, ir_ui_view.inherit_id, ir_ui_view.priority,
            //                ir_ui_view.mode, ir_ui_view.model
            //         FROM ir_ui_view
            //         INNER JOIN ir_ui_view_inherits parent ON parent.id = ir_ui_view.inherit_id
            //         WHERE coalesce(ir_ui_view.model, '') = coalesce(parent.model, '')
            //               AND ir_ui_view.mode = 'extension'
            //               AND (%(where_clause)s)
            //     )
            //     SELECT
            //         v.id, v.inherit_id, v.mode
            //     FROM ir_ui_view_inherits v
            //     ORDER BY v.priority, v.id
            // """, ids=tuple(self.ids), where_clause=where_clause)
            // # ORDER BY v.priority, v.id:
            // # 1/ sort by priority: abritrary value set by developers on some
            // #    views to solve "dependency hell" problems and force a view
            // #    to be combined earlier or later. e.g. all views created via
            // #    studio have a priority=99 to be loaded last.
            // # 2/ sort by view id: the order the views were inserted in the
            // #    database. e.g. base views are placed before stock ones.
            // 
            // rows = self.env.execute_query(query)
            // views = self.browse(row[0] for row in rows)
            // 
            // # optimization: fill in cache of inherit_id and mode
            // self.env.cache.update(views, self._fields['inherit_id'], [row[1] for row in rows])
            // self.env.cache.update(views, self._fields['mode'], [row[2] for row in rows])
            // 
            // # During an upgrade, we can only use the views that have been
            // # fully upgraded already.
            // if self.pool._init and not self._context.get('load_all_views'):
            //     views = views._filter_loaded_views()
            // 
            // return views
            */
            return default;
        }

        protected async Task<IrUiView> GetInternalAsync(object view_ref)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _get(self, view_ref):
            // """ Return the view corresponding to ``view_ref``, which may be a
            // view ID or an XML ID.
            // """
            // return self.browse(self._get_view_id(view_ref))
            */
            return default;
        }

        protected async Task<IrUiView> GetPwdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def _get_pwd(self):
            // for r in self:
            //     r.visibility_password_display = r.sudo().visibility_password and '********' or ''
            */
            return default;
        }

        public async Task<IrUiView> GetRelatedViewsAsync(Guid id, IrUiViewGetRelatedViewsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_ui_view.py) ---
            // def get_related_views(self, key, bundles=False):
            // """ Get inherit view's informations of the template ``key``.
            //     returns templates info (which can be active or not)
            //     ``bundles=True`` returns also the asset bundles
            // """
            // user_groups = set(self.env.user.groups_id)
            // new_context = {
            //     **self._context,
            //     'active_test': False,
            // }
            // new_context.pop('lang', None)
            // View = self.with_context(new_context)
            // views = View._views_get(key, bundles=bundles)
            // return views.filtered(lambda v: not v.groups_id or len(user_groups.intersection(v.groups_id)))
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def get_related_views(self, key, bundles=False):
            // '''Make this only return most specific views for website.'''
            // # get_related_views can be called through website=False routes
            // # (e.g. /web_editor/get_assets_editor_resources), so website
            // # dispatch_parameters may not be added. Manually set
            // # website_id. (It will then always fallback on a website, this
            // # method should never be called in a generic context, even for
            // # tests)
            // current_website = self.env['website'].get_current_website()
            // return super(View, self.with_context(
            //     website_id=current_website.id
            // )).get_related_views(key, bundles=bundles).with_context(
            //     lang=current_website.default_lang_id.code,
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrUiView> GetSnippetAdditionViewKeyInternalAsync(object template_key, object key)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_ui_view.py) ---
            // def _get_snippet_addition_view_key(self, template_key, key):
            // return '%s.%s' % (template_key, key)
            */
            return default;
        }

        protected async Task<IrUiView> GetSpecificViewsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _get_specific_views(self):
            // """ Given a view, return a record set containing all the specific views
            //     for that view's key.
            // """
            // self.ensure_one()
            // # Only qweb views have a specific conterpart
            // if self.type != 'qweb':
            //     return self.env['ir.ui.view']
            // # A specific view can have a xml_id if exported/imported but it will not be equals to it's key (only generic view will).
            // return self.with_context(active_test=False).search([('key', '=', self.key)]).filtered(lambda r: not r.xml_id == r.key)
            */
            return default;
        }

        public async Task<IrUiView> GetViewHierarchyAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def get_view_hierarchy(self):
            // self.ensure_one()
            // top_level_view = self
            // while top_level_view.inherit_id:
            //     top_level_view = top_level_view.inherit_id
            // top_level_view = top_level_view.with_context(active_test=False)
            // sibling_views = top_level_view.search_read([('key', '=', top_level_view.key), ('id', '!=', top_level_view.id)])
            // return {
            //     'sibling_views': sibling_views,
            //     'hierarchy': top_level_view._build_hierarchy_datastructure()
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrUiView> GetViewIdInternalAsync(object template)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def _get_view_id(self, xml_id):
            // """If a website_id is in the context and the given xml_id is not an int
            // then try to get the id of the specific view for that website, but
            // fallback to the id of the generic view if there is no specific.
            // 
            // If no website_id is in the context, it might randomly return the generic
            // or the specific view, so it's probably not recommanded to use this
            // method. `viewref` is probably more suitable.
            // 
            // Archived views are ignored (unless the active_test context is set, but
            // then the ormcache will not work as expected).
            // """
            // website_id = self._context.get('website_id')
            // if website_id and not isinstance(xml_id, int):
            //     current_website = self.env['website'].browse(int(website_id))
            //     domain = ['&', ('key', '=', xml_id)] + current_website.website_domain()
            // 
            //     view = self.sudo().search(domain, order='website_id', limit=1)
            //     if not view:
            //         _logger.warning("Could not find view object with xml_id '%s'", xml_id)
            //         raise ValueError('View %r in website %r not found' % (xml_id, self._context['website_id']))
            //     return view.id
            // return super(View, self.sudo())._get_view_id(xml_id)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _get_view_id(self, template):
            // """ Return the view ID corresponding to ``template``, which may be a
            // view ID or an XML ID. Note that this method may be overridden for other
            // kinds of template values.
            // """
            // if isinstance(template, int):
            //     return template
            // if '.' not in template:
            //     raise ValueError('Invalid template id: %r' % template)
            // view = self.sudo().search([('key', '=', template)], limit=1)
            // if view:
            //     return view.id
            // res_model, res_id = self.env['ir.model.data']._xmlid_to_res_model_res_id(template, raise_if_not_found=True)
            // assert res_model == self._name, "Call _get_view_id, expected %r, got %r" % (self._name, res_model)
            // return res_id
            */
            return default;
        }

        public async Task<IrUiView> GetViewInfoAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: ir_ui_view.py) ---
            // def get_view_info(self):
            // _view_info = self._get_view_info()
            // return {
            //     type_: {
            //         'display_name': display_name,
            //         'icon': _view_info[type_]['icon'],
            //         'multi_record': _view_info[type_].get('multi_record', True),
            //     }
            //     for (type_, display_name)
            //     in self.fields_get(['type'], ['selection'])['type']['selection']
            //     if type_ != 'qweb'
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrUiView> GetViewInfoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_ui_view.py) ---
            // def _get_view_info(self):
            // return {'activity': {'icon': 'fa fa-clock-o'}} | super()._get_view_info()
            --- ODOO METHOD SOURCE (MODULE: web, FILE: ir_ui_view.py) ---
            // def _get_view_info(self):
            // return {
            //     'list': {'icon': 'oi oi-view-list'},
            //     'form': {'icon': 'fa fa-address-card', 'multi_record': False},
            //     'graph': {'icon': 'fa fa-area-chart'},
            //     'pivot': {'icon': 'oi oi-view-pivot'},
            //     'kanban': {'icon': 'oi oi-view-kanban'},
            //     'calendar': {'icon': 'fa fa-calendar'},
            //     'search': {'icon': 'oi oi-search'},
            // }
            --- ODOO METHOD SOURCE (MODULE: web_hierarchy, FILE: ir_ui_view.py) ---
            // def _get_view_info(self):
            // return {'hierarchy': {'icon': 'fa fa-share-alt fa-rotate-90'}} | super()._get_view_info()
            */
            return default;
        }

        protected async Task<IrUiView> GetViewRefsInternalAsync(object node)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _get_view_refs(self, node):
            // """ Extract the `[view_type]_view_ref` keys and values from the node context attribute,
            // giving the views to use for a field node.
            // 
            // :param node: the field node as an etree
            // :return: a dictonary mapping the `[view_type]_view_ref` key to the xmlid of the view to use for that view type.
            // """
            // if not node.get('context'):
            //     return {}
            // return {
            //     m.group('view_type'): m.group('view_id')
            //     for m in ref_re.finditer(node.get('context'))
            // }
            */
            return default;
        }

        protected async Task<IrUiView> GetX2manyMissingViewArchsInternalAsync(object field, object field_node, object node_info)
        {
            #if PYTHON_CODE
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _get_x2many_missing_view_archs(self, field, field_node, node_info):
            // """
            // For x2many fields that require to have some multi-record arch (kanban or list) to display the records
            // be available, this function fetches all arch that are needed and return them.
            // The caller function is responsible to do what it needs with them.
            // """
            // current_view_types = [el.tag for el in field_node.xpath("./*[descendant::field]")]
            // missing_view_types = []
            // if not any(view_type in current_view_types for view_type in field_node.get('mode', 'kanban,list').split(',')):
            //     missing_view_types.append(
            //         field_node.get('mode', 'kanban' if node_info.get('mobile') else 'list').split(',')[0]
            //     )
            // 
            // if not missing_view_types:
            //     return []
            // 
            // comodel = self.env[field.comodel_name].sudo(False)
            // refs = self._get_view_refs(field_node)
            // # Do not propagate <view_type>_view_ref of parent call to `_get_view`
            // comodel = comodel.with_context(**{
            //     f'{view_type}_view_ref': refs.get(f'{view_type}_view_ref')
            //     for view_type in missing_view_types
            // })
            // 
            // return [comodel._get_view(view_type=view_type) for view_type in missing_view_types]
            #endif
            return default;
        }

        protected async Task<IrUiView> HandleVisibilityInternalAsync(object do_raise)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def _handle_visibility(self, do_raise=True):
            // """ Check the visibility set on the main view and raise 403 if you should not have access.
            //     Order is: Public, Connected, Has group, Password
            // 
            //     It only check the visibility on the main content, others views called stay available in rpc.
            // """
            // error = False
            // 
            // self = self.sudo()
            // 
            // visibility = self._get_cached_visibility()
            // 
            // if visibility and not request.env.user.has_group('website.group_website_designer'):
            //     if (visibility == 'connected' and request.website.is_public_user()):
            //         error = werkzeug.exceptions.Forbidden()
            //     elif visibility == 'password' and \
            //             (request.website.is_public_user() or self.id not in request.session.get('views_unlock', [])):
            //         pwd = request.params.get('visibility_password')
            //         if pwd and self.env.user._crypt_context().verify(
            //                 pwd, self.visibility_password):
            //             request.session.setdefault('views_unlock', list()).append(self.id)
            //         else:
            //             error = werkzeug.exceptions.Forbidden('website_visibility_password_required')
            // 
            //     if visibility not in ('password', 'connected'):
            //         try:
            //             self._check_view_access()
            //         except AccessError:
            //             error = werkzeug.exceptions.Forbidden()
            // 
            // if error:
            //     if do_raise:
            //         raise error
            //     else:
            //         return False
            // return True
            */
            return default;
        }

        public async Task<IrUiView> InheritBrandingAsync(Guid id, IrUiViewInheritBrandingRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def inherit_branding(self, specs_tree):
            // for node in specs_tree.iterchildren(tag=etree.Element):
            //     xpath = node.getroottree().getpath(node)
            //     if node.tag == 'data' or node.tag == 'xpath' or node.get('position'):
            //         self.inherit_branding(node)
            //     elif node.get('t-field'):
            //         node.set('data-oe-xpath', xpath)
            //         self.inherit_branding(node)
            //     else:
            //         node.set('data-oe-id', str(self.id))
            //         node.set('data-oe-xpath', xpath)
            //         node.set('data-oe-model', 'ir.ui.view')
            //         node.set('data-oe-field', 'arch')
            // return specs_tree
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrUiView> InverseArchBaseInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _inverse_arch_base(self):
            // for view, view_wo_lang in zip(self, self.with_context(lang=None)):
            //     view_wo_lang.arch = view.arch_base
            */
            return default;
        }

        protected async Task<IrUiView> InverseArchInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _inverse_arch(self):
            // for view in self:
            //     data = dict(arch_db=view.arch)
            //     if 'install_filename' in self._context:
            //         # we store the relative path to the resource instead of the absolute path, if found
            //         # (it will be missing e.g. when importing data-only modules using base_import_module)
            //         path_info = get_resource_from_path(self._context['install_filename'])
            //         if path_info:
            //             data['arch_fs'] = '/'.join(path_info[0:2])
            //             data['arch_updated'] = False
            //     view.write(data)
            //     # the xml_translate will clean the arch_db when write (e.g. ('<div>') -> ('<div></div>'))
            //     # view.arch should be reassigned here
            //     view.arch = view.arch_db
            // # the field 'arch' depends on the context and has been implicitly
            // # modified in all languages; the invalidation below ensures that the
            // # field does not keep an old value in another environment
            // self.invalidate_recordset(['arch'])
            */
            return default;
        }

        protected async Task<IrUiView> InverseComputeModelIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _inverse_compute_model_id(self):
            // for record in self:
            //     record.model = record.model_id.model
            */
            return default;
        }

        public async Task<IrUiView> IsNodeBrandedAsync(Guid id, IrUiViewIsNodeBrandedRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def is_node_branded(self, node):
            // """ Finds out whether a node is branded or qweb-active (bears a
            // @data-oe-model or a @t-* *which is not t-field* as t-field does not
            // section out views)
            // 
            // :param node: an etree-compatible element to test
            // :type node: etree._Element
            // :rtype: boolean
            // """
            // return any(
            //     (attr in ('data-oe-model', 'groups') or (attr.startswith('t-')))
            //     for attr in node.attrib
            // ) or (
            //     node.tag is etree.ProcessingInstruction
            //     and node.target == 'apply-inheritance-specs-node-removal'
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrUiView> IsQwebBasedViewInternalAsync(object view_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_ui_view.py) ---
            // def _is_qweb_based_view(self, view_type):
            // return view_type == "activity" or super()._is_qweb_based_view(view_type)
            --- ODOO METHOD SOURCE (MODULE: web_hierarchy, FILE: ir_ui_view.py) ---
            // def _is_qweb_based_view(self, view_type):
            // return super()._is_qweb_based_view(view_type) or view_type == "hierarchy"
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _is_qweb_based_view(self, view_type):
            // return view_type == 'kanban'
            */
            return default;
        }

        protected async Task<IrUiView> LoadPosDataFieldsInternalAsync(Guid config_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: ir_ui_view.py) ---
            // def _load_pos_data_fields(self, config_id):
            // return ['id', 'name']
            */
            return default;
        }

        protected async Task<IrUiView> LoadPosDataInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: ir_ui_view.py) ---
            // def _load_pos_data(self, data):
            // fields = self._load_pos_data_fields(data['pos.config']['data'][0]['id'])
            // return {
            //     'data': self.env.ref('base.view_partner_form').sudo().read(fields),
            //     'fields': fields
            // }
            */
            return default;
        }

        protected async Task<IrUiView> LoadRecordsWriteInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _load_records_write(self, values):
            // """ During module update, when updating a generic view, we should also
            //     update its specific views (COW'd).
            //     Note that we will only update unmodified fields. That will mimic the
            //     noupdate behavior on views having an ir.model.data.
            // """
            // if self.type == 'qweb':
            //     for cow_view in self._get_specific_views():
            //         authorized_vals = {}
            //         for key in values:
            //             if key != 'inherit_id' and cow_view[key] == self[key]:
            //                 authorized_vals[key] = values[key]
            //         # if inherit_id update, replicate change on cow view but
            //         # only if that cow view inherit_id wasn't manually changed
            //         inherit_id = values.get('inherit_id')
            //         if inherit_id and self.inherit_id.id != inherit_id and \
            //            cow_view.inherit_id.key == self.inherit_id.key:
            //             self._load_records_write_on_cow(cow_view, inherit_id, authorized_vals)
            //         else:
            //             cow_view.with_context(no_cow=True).write(authorized_vals)
            // super(View, self)._load_records_write(values)
            */
            return default;
        }

        protected async Task<IrUiView> LoadRecordsWriteOnCowInternalAsync(object cow_view, Guid inherit_id, object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def _load_records_write_on_cow(self, cow_view, inherit_id, values):
            // inherit_id = self.search([
            //     ('key', '=', self.browse(inherit_id).key),
            //     ('website_id', 'in', (False, cow_view.website_id.id)),
            // ], order='website_id', limit=1).id
            // values['inherit_id'] = inherit_id
            // cow_view.with_context(no_cow=True).write(values)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _load_records_write_on_cow(self, cow_view, inherit_id, values):
            // # for modules updated before `website`, we need to
            // # store the change to replay later on cow views
            // if not hasattr(self.pool, 'website_views_to_adapt'):
            //     self.pool.website_views_to_adapt = []
            // self.pool.website_views_to_adapt.append((
            //     cow_view.id,
            //     inherit_id,
            //     values,
            // ))
            */
            return default;
        }

        public async Task<IrUiView> LocateNodeAsync(Guid id, IrUiViewLocateNodeRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def locate_node(self, arch, spec):
            // """ Locate a node in a source (parent) architecture.
            // 
            // Given a complete source (parent) architecture (i.e. the field
            // `arch` in a view), and a 'spec' node (a node in an inheriting
            // view that specifies the location in the source view of what
            // should be changed), return (if it exists) the node in the
            // source view matching the specification.
            // 
            // :param arch: a parent architecture to modify
            // :param spec: a modifying node in an inheriting view
            // :return: a node in the source matching the spec
            // """
            // return locate_node(arch, spec)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrUiView> LogViewWarningInternalAsync(object message, object node)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _log_view_warning(self, message, node):
            // """ Handle a view issue by logging a warning.
            // 
            // :param str message: message to raise or log, augmented with contextual
            //                     view information
            // :param node: the lxml element where the error is located (if any)
            // """
            // error_context = {
            //     'view': self,
            //     'name': getattr(self, 'name', None),
            //     'xmlid': self.env.context.get('install_xmlid') or self.xml_id,
            //     'view.model': self.model,
            //     'view.parent': self.inherit_id,
            //     'file': self.env.context.get('install_filename'),
            //     'line': node.sourceline if node is not None else 1,
            // }
            // _logger.warning(
            //     "%s\nView error context:\n%s",
            //     message, pprint.pformat(error_context)
            // )
            */
            return default;
        }

        protected async Task<IrUiView> ModifiersFromModelInternalAsync(object node)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _modifiers_from_model(self, node):
            // modifier_names = []
            // if node.tag in ('kanban', 'list', 'form'):
            //     modifier_names += ['readonly', 'required']
            // return modifier_names
            */
            return default;
        }

        protected async Task<IrUiView> OnchangeAbleViewFormInternalAsync(object node)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _onchange_able_view_form(self, node):
            // return True
            */
            return default;
        }

        protected async Task<IrUiView> OnchangeAbleViewInternalAsync(object node)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _onchange_able_view(self, node):
            // func = getattr(self, f"_onchange_able_view_{node.tag}", None)
            // if func is not None:
            //     return func(node)
            */
            return default;
        }

        protected async Task<IrUiView> OnchangeAbleViewKanbanInternalAsync(object node)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _onchange_able_view_kanban(self, node):
            // return True
            */
            return default;
        }

        protected async Task<IrUiView> OnchangeAbleViewListInternalAsync(object node)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _onchange_able_view_list(self, node):
            // return True
            */
            return default;
        }

        protected async Task<IrUiView> PopViewBrandingInternalAsync(object element)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _pop_view_branding(self, element):
            // distributed_branding = dict(
            //     (attribute, element.attrib.pop(attribute))
            //     for attribute in MOVABLE_BRANDING
            //     if element.get(attribute))
            // return distributed_branding
            */
            return default;
        }

        protected async Task<IrUiView> PostprocessAccessRightsInternalAsync(object tree)
        {
            #if PYTHON_CODE
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _postprocess_access_rights(self, tree):
            // """
            // Apply group restrictions: elements with a 'groups' attribute should
            // be removed from the view to people who are not members.
            // 
            // Compute and set on node access rights based on view type. Specific
            // views can add additional specific rights like creating columns for
            // many2one-based grouping views.
            // """
            // group_definitions = self.env['res.groups']._get_group_definitions()
            // 
            // user_group_ids = self.env.user._get_group_ids()
            // # The 'base.group_no_one' is not actually involved by any other group because it is session dependent.
            // group_no_one_id = group_definitions.get_id('base.group_no_one')
            // if group_no_one_id in user_group_ids and not (request and request.session.debug):
            //     user_group_ids = [g for g in user_group_ids if g != group_no_one_id]
            // 
            // # check the read/visibility access
            // @functools.cache
            // def has_access(groups_key):
            //     groups = group_definitions.from_key(groups_key)
            //     return groups.matches(user_group_ids)
            // 
            // # check the read/visibility access
            // for node in tree.xpath('//*[@__groups_key__]'):
            //     if not has_access(node.attrib.pop('__groups_key__')):
            //         node.getparent().remove(node)
            //     elif node.tag == 't' and not node.attrib:
            //         # Move content of <t groups=""> blocks
            //         # and remove the <t> node.
            //         # This is to keep the structure
            //         # <group>
            //         #   <field name="foo"/>
            //         #   <field name="bar"/>
            //         # <group>
            //         # so the web client adds the label as expected.
            //         # This is also to avoid having <t> nodes in list views
            //         # e.g.
            //         # <list>
            //         #   <field name="foo"/>
            //         #   <t groups="foo">
            //         #     <field name="bar" groups="bar"/>
            //         #   </t>
            //         # </list>
            //         for child in reversed(node):
            //             node.addnext(child)
            //         node.getparent().remove(node)
            // 
            // # check the create and write access
            // base_model = tree.get('model_access_rights')
            // for node in tree.xpath('//*[@model_access_rights]'):
            //     model = self.env[node.attrib.pop('model_access_rights')]
            //     if node.tag == 'field':
            //         can_create = model.has_access('create')
            //         can_write = model.has_access('write')
            //         node.set('can_create', str(bool(can_create)))
            //         node.set('can_write', str(bool(can_write)))
            //     else:
            //         is_base_model = base_model == model._name
            //         for action, operation in (('create', 'create'), ('delete', 'unlink'), ('edit', 'write')):
            //             if not node.get(action) and not model.has_access(operation):
            //                 node.set(action, 'False')
            //         if node.tag == 'kanban':
            //             group_by_name = node.get('default_group_by')
            //             group_by_field = model._fields.get(group_by_name)
            //             if group_by_field and group_by_field.type == 'many2one':
            //                 group_by_model = model.env[group_by_field.comodel_name]
            //                 for action, operation in (('group_create', 'create'), ('group_delete', 'unlink'), ('group_edit', 'write')):
            //                     if not node.get(action) and not group_by_model.has_access(operation):
            //                         node.set(action, 'False')
            // 
            // return tree
            #endif
            return default;
        }

        public async Task<IrUiView> PostprocessAndFieldsAsync(Guid id, IrUiViewPostprocessAndFieldsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def postprocess_and_fields(self, node, model=None, **options):
            // """ Return an architecture and a description of all the fields.
            // 
            // The field description combines the result of fields_get() and
            // postprocess().
            // 
            // :param self: the view to postprocess
            // :param node: the architecture as an etree
            // :param model: the view's reference model name
            // :return: a tuple (arch, fields) where arch is the given node as a
            //     string and fields is the description of all the fields.
            // 
            // """
            // self and self.ensure_one()      # self is at most one view
            // 
            // name_manager = self._postprocess_view(node, model or self.model, **options)
            // arch = etree.tostring(node, encoding="unicode").replace('\t', '')
            // 
            // models = {}
            // name_managers = [name_manager]
            // for name_manager in name_managers:
            //     models.setdefault(name_manager.model._name, set()).update(name_manager.available_fields)
            //     name_managers.extend(name_manager.children)
            // 
            // return arch, models
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrUiView> PostprocessAttributesInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _postprocess_attributes(self, node, name_manager, node_info):
            // # get mandatory fields
            // for attr, expr in node.items():
            //     if attr in VIEW_MODIFIERS or attr.startswith('decoration-'):
            //         vnames = get_expression_field_names(expr)
            //         name_manager.must_have_fields(node, vnames, node_info, (attr, expr))
            //     elif attr == 'groups':
            //         node.attrib.pop('groups')
            */
            return default;
        }

        protected async Task<IrUiView> PostprocessOnChangeInternalAsync(object arch, object model)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _postprocess_on_change(self, arch, model):
            // """ Add attribute on_change="1" on fields that are dependencies of
            //     computed fields on the same view.
            // """
            // # map each field object to its corresponding nodes in arch
            // field_nodes = collections.defaultdict(list)
            // 
            // def collect(node, model):
            //     if node.tag == 'field':
            //         field = model._fields.get(node.get('name'))
            //         if field:
            //             field_nodes[field].append(node)
            //             if field.relational:
            //                 model = self.env[field.comodel_name]
            //     for child in node:
            //         collect(child, model)
            // 
            // collect(arch, model)
            // 
            // for field, nodes in field_nodes.items():
            //     # if field should trigger an onchange, add on_change="1" on the
            //     # nodes referring to field
            //     model = self.env[field.model_name]
            //     if model._has_onchange(field, field_nodes):
            //         for node in nodes:
            //             if not node.get('on_change'):
            //                 node.set('on_change', '1')
            */
            return default;
        }

        protected async Task<IrUiView> PostprocessTagCalendarInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _postprocess_tag_calendar(self, node, name_manager, node_info):
            // for additional_field in ('date_start', 'date_delay', 'date_stop', 'color', 'all_day'):
            //     if fnames := node.get(additional_field):
            //         name_manager.has_field(node, fnames.split('.', 1)[0], node_info)
            // for f in node:
            //     if f.tag == 'filter':
            //         name_manager.has_field(node, f.get('name'), node_info)
            */
            return default;
        }

        protected async Task<IrUiView> PostprocessTagFieldInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _postprocess_tag_field(self, node, name_manager, node_info):
            // name = node.get('name')
            // if not name:
            //     return
            // 
            // attrs = {'id': node.get('id'), 'select': node.get('select')}
            // field = name_manager.model._fields.get(name)
            // 
            // if field:
            //     if field.groups:
            //         group_definitions = self.env['res.groups']._get_group_definitions()
            //         node_info['model_groups'] &= group_definitions.parse(field.groups, raise_if_not_found=False)
            //     if (
            //         node_info.get('view_type') == 'form'
            //         and field.type in ('one2many', 'many2many')
            //         and not node.get('widget')
            //         and node.get('invisible') not in ('1', 'True')
            //         and not name_manager.parent
            //     ):
            //         # Embed kanban/list/form views for visible x2many fields in form views
            //         # if no widget or the widget requires it.
            //         # So the web client doesn't have to call `get_views` for x2many fields not embedding their view
            //         # in the main form view.
            //         for arch, _view in self._get_x2many_missing_view_archs(field, node, node_info):
            //             node.append(arch)
            // 
            //     if field.relational:
            //         domain = (
            //             node.get('domain')
            //             or node_info['editable'] and field._description_domain(self.env)
            //         )
            //         if isinstance(domain, str):
            //             vnames = get_expression_field_names(domain)
            //             name_manager.must_have_fields(node, vnames, node_info, ('domain', domain))
            //     if field.type == 'properties':
            //         name_manager.must_have_fields(node, [field.definition_record], node_info, ('fieldname', field.name))
            //     context = node.get('context')
            //     if context:
            //         vnames = get_expression_field_names(context)
            //         name_manager.must_have_fields(node, vnames, node_info, ('context', context))
            // 
            //     for child in node:
            //         if child.tag in ('form', 'list', 'graph', 'kanban', 'calendar'):
            //             node_info['children'] = []
            //             self._postprocess_view(child, field.comodel_name, editable=node_info['editable'], node_info=node_info)
            // 
            //     if node_info['editable'] and field.type in ('many2one', 'many2many'):
            //         node.set('model_access_rights', field.comodel_name)
            // 
            // name_manager.has_field(node, name, node_info, attrs)
            */
            return default;
        }

        protected async Task<IrUiView> PostprocessTagFormInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _postprocess_tag_form(self, node, name_manager, node_info):
            // result = name_manager.model.view_header_get(False, node.tag)
            // if result:
            //     node.set('string', result)
            */
            return default;
        }

        protected async Task<IrUiView> PostprocessTagGroupbyInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _postprocess_tag_groupby(self, node, name_manager, node_info):
            // # groupby nodes should be considered as nested view because they may
            // # contain fields on the comodel
            // name = node.get('name')
            // field = name_manager.model._fields.get(name)
            // if not field or not field.comodel_name:
            //     return
            // # post-process the node as a nested view, and associate it to the field
            // node_info['children'] = []
            // self._postprocess_view(node, field.comodel_name, editable=False, node_info=node_info)
            // name_manager.has_field(node, name, node_info)
            */
            return default;
        }

        protected async Task<IrUiView> PostprocessTagLabelInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _postprocess_tag_label(self, node, name_manager, node_info):
            // if not node.get('for'):
            //     return
            // field = name_manager.model._fields.get(node.get('for'))
            // if field and field.groups:
            //     group_definitions = self.env['res.groups']._get_group_definitions()
            //     node_info['model_groups'] &= group_definitions.parse(field.groups, raise_if_not_found=False)
            */
            return default;
        }

        protected async Task<IrUiView> PostprocessTagListInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _postprocess_tag_list(self, node, name_manager, node_info):
            // # reuse form view post-processing
            // self._postprocess_tag_form(node, name_manager, node_info)
            */
            return default;
        }

        protected async Task<IrUiView> PostprocessTagSearchInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _postprocess_tag_search(self, node, name_manager, node_info):
            // searchpanel = [child for child in node if child.tag == 'searchpanel']
            // if searchpanel:
            //     self._postprocess_view(searchpanel[0], name_manager.model._name, editable=False, node_info=node_info)
            //     node_info['children'] = [child for child in node if child.tag != 'searchpanel']
            */
            return default;
        }

        protected async Task<IrUiView> PostprocessViewInternalAsync(object node, object model_name, object editable, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _postprocess_view(self, node, model_name, editable=True, node_info=None, **options):
            // """ Process the given architecture, modifying it in-place to add and
            // remove stuff.
            // 
            // :param self: the optional view to postprocess
            // :param node: the combined architecture as an etree
            // :param model_name: the view's reference model name
            // :param editable: whether the view is considered editable
            // :return: the processed architecture's NameManager
            // """
            // root = node
            // 
            // if model_name not in self.env:
            //     self._raise_view_error(_('Model not found: %(model)s', model=model_name), root)
            // model = self.env[model_name]
            // 
            // group_definitions = self.env['res.groups']._get_group_definitions()
            // 
            // # model_groups/view_groups: access groups for the model/view
            // model_groups = node_info['model_groups'] if node_info else group_definitions.universe
            // view_groups = node_info['view_groups'] if node_info else group_definitions.universe
            // parent_name_manager = node_info['name_manager'] if node_info else None
            // 
            // # combine model access groups with this model's access groups
            // model_groups &= self.env['ir.model.access']._get_access_groups(model_name)
            // 
            // name_manager = NameManager(model, parent=parent_name_manager, model_groups=model_groups)
            // 
            // root_info = {
            //     'view_type': root.tag,
            //     'view_editable': editable and self._editable_node(root, name_manager),
            //     'mobile': options.get('mobile'),
            //     'model_groups': model_groups,
            //     'view_groups': view_groups,
            //     'name_manager': name_manager,
            // }
            // 
            // is_compute_warning_info = options.get('is_compute_warning_info')
            // 
            // # use a stack to recursively traverse the tree
            // stack = [(root, view_groups, editable)]
            // while stack:
            //     node, view_groups, editable = stack.pop()
            // 
            //     # compute default
            //     tag = node.tag
            //     had_parent = node.getparent() is not None
            //     node_info = dict(root_info, view_groups=view_groups, editable=editable and self._editable_node(node, name_manager))
            // 
            //     node_groups = node.get('groups')
            //     if node_groups:
            //         node_info['view_groups'] &= group_definitions.parse(node_groups, raise_if_not_found=False)
            // 
            //     # tag-specific postprocessing
            //     postprocessor = getattr(self, f"_postprocess_tag_{tag}", None)
            //     if postprocessor is not None:
            //         postprocessor(node, name_manager, node_info)
            //         if had_parent and node.getparent() is None:
            //             # the node has been removed, stop processing here
            //             continue
            // 
            //     # if present, iterate on node_info['children'] instead of node
            //     for child in reversed(node_info.get('children', node)):
            //         stack.append((child, node_info['view_groups'], node_info['editable']))
            // 
            //     if node_groups or root_info['model_groups'] != node_info['model_groups']:
            //         groups = node_info['model_groups'] & node_info['view_groups']
            //         node.set('__groups_key__', groups.key)
            // 
            //     self._postprocess_attributes(node, name_manager, node_info)
            // 
            //     if node_groups and is_compute_warning_info:
            //         # reset the groups attributes to display in log
            //         node.attrib['groups'] = node_groups
            // 
            // missing_fields = self._add_missing_fields(root, name_manager)
            // 
            // if is_compute_warning_info:
            //     for name, (missing_groups, reasons) in missing_fields.items():
            //         error_message = name_manager._error_message_group_inconsistency(name, missing_groups, reasons)[0]
            //         if error_message:
            //             if self.warning_info:
            //                 self.warning_info += Markup('<br/>\n<br/>\n')
            //             self.warning_info += error_message.replace('\n', Markup('<br/>\n'))
            // 
            // name_manager.update_available_fields()
            // 
            // root.set('model_access_rights', model._name)
            // 
            // if self._onchange_able_view(root):
            //     self._postprocess_on_change(root, model)
            // 
            // return name_manager
            */
            return default;
        }

        protected async Task<IrUiView> RaiseViewErrorInternalAsync(object message, object node)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _raise_view_error(self, message, node=None, *, from_exception=None, from_traceback=None):
            // """ Handle a view error by raising an exception.
            // 
            // :param str message: message to raise or log, augmented with contextual
            //                     view information
            // :param node: the lxml element where the error is located (if any)
            // :param BaseException from_exception:
            //     when raising an exception, chain it to the provided one (default:
            //     disable chaining)
            // :param types.TracebackType from_traceback:
            //     when raising an exception, start with this traceback (default: start
            //     at exception creation)
            // """
            // err = ValueError(message).with_traceback(from_traceback)
            // err.context = {
            //     'view': self,
            //     'name': getattr(self, 'name', None),
            //     'xmlid': self.env.context.get('install_xmlid') or self.xml_id,
            //     'view.model': self.model,
            //     'view.parent': self.inherit_id,
            //     'file': self.env.context.get('install_filename'),
            //     'line': node.sourceline if node is not None else 1,
            // }
            // raise err from from_exception
            */
            return default;
        }

        protected async Task<IrUiView> ReadTemplateInternalAsync(Guid view_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _read_template(self, view_id):
            // arch_tree = self.browse(view_id)._get_combined_arch()
            // self.distribute_branding(arch_tree)
            // return etree.tostring(arch_tree, encoding='unicode')
            */
            return default;
        }

        protected async Task<IrUiView> ReadTemplateKeysInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def _read_template_keys(self):
            // return super(View, self)._read_template_keys() + ['website_id']
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _read_template_keys(self):
            // """ Return the list of context keys to use for caching ``_read_template``. """
            // return ['lang', 'inherit_branding', 'edit_translations']
            */
            return default;
        }

        public async Task<IrUiView> RenameSnippetAsync(Guid id, IrUiViewRenameSnippetRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_ui_view.py) ---
            // def rename_snippet(self, name, view_id, template_key):
            // snippet_view = self.browse(view_id)
            // key = snippet_view.key.split('.')[1]
            // custom_key = self._get_snippet_addition_view_key(template_key, key)
            // snippet_addition_view = self.search([('key', '=', custom_key)])
            // if snippet_addition_view:
            //     snippet_addition_view.name = name + ' Block'
            // snippet_view.name = name
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrUiView> RenderPublicAssetAsync(Guid id, IrUiViewRenderPublicAssetRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def render_public_asset(self, template, values=None):
            // template_sudo = self._get(template).sudo()
            // template_sudo._check_view_access()
            // return self.env['ir.qweb'].sudo()._render(template, values)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrUiView> RenderTemplateInternalAsync(object template, object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def _render_template(self, template, values=None):
            // """ Render the template. If website is enabled on request, then extend rendering context with website values. """
            // view = self._get(template).sudo()
            // view._handle_visibility(do_raise=True)
            // if values is None:
            //     values = {}
            // if 'main_object' not in values:
            //     values['main_object'] = view
            // return super()._render_template(template, values=values)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _render_template(self, template, values=None):
            // return self.env['ir.qweb']._render(template, values)
            */
            return default;
        }

        public async Task<IrUiView> ReplaceArchSectionAsync(Guid id, IrUiViewReplaceArchSectionRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_ui_view.py) ---
            // def replace_arch_section(self, section_xpath, replacement, replace_tail=False):
            // # the root of the arch section shouldn't actually be replaced as it's
            // # not really editable itself, only the content truly is editable.
            // self.ensure_one()
            // arch = etree.fromstring(self.arch.encode('utf-8'))
            // # => get the replacement root
            // if not section_xpath:
            //     root = arch
            // else:
            //     # ensure there's only one match
            //     [root] = arch.xpath(section_xpath)
            // 
            // root.text = replacement.text
            // 
            // # We need to replace some attrib for styles changes on the root element
            // for attribute in self._get_allowed_root_attrs():
            //     if attribute in replacement.attrib:
            //         root.attrib[attribute] = replacement.attrib[attribute]
            //     elif attribute in root.attrib:
            //         del root.attrib[attribute]
            // 
            // # Note: after a standard edition, the tail *must not* be replaced
            // if replace_tail:
            //     root.tail = replacement.tail
            // # replace all children
            // del root[:]
            // for child in replacement:
            //     root.append(copy.deepcopy(child))
            // 
            // return arch
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrUiView> ResetArchAsync(Guid id, IrUiViewResetArchRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def reset_arch(self, mode='soft'):
            // """ Reset the view arch to its previous arch (soft) or its XML file arch
            // if exists (hard).
            // """
            // for view in self:
            //     arch = False
            //     if mode == 'soft':
            //         arch = view.arch_prev
            //         write_dict = {'arch_db': arch}
            //     elif mode == 'hard' and view.arch_fs:
            //         arch = view.with_context(read_arch_from_file=True, lang=None).arch
            //         write_dict = {'arch_db': arch, 'arch_prev': False, 'arch_updated': False}
            //     if arch:
            //         # Don't save current arch in previous since we reset, this arch is probably broken
            //         view.with_context(no_save_prev=True, lang=None).write(write_dict)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrUiView> SaveAsync(Guid id, IrUiViewSaveRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_ui_view.py) ---
            // def save(self, value, xpath=None):
            // """ Update a view section. The view section may embed fields to write
            // 
            // Note that `self` record might not exist when saving an embed field
            // 
            // :param str xpath: valid xpath to the tag to replace
            // """
            // self.ensure_one()
            // 
            // arch_section = html.fromstring(
            //     value, parser=html.HTMLParser(encoding='utf-8'))
            // 
            // if xpath is None:
            //     # value is an embedded field on its own, not a view section
            //     self.save_embedded_field(arch_section)
            //     return
            // 
            // for el in self.extract_embedded_fields(arch_section):
            //     self.save_embedded_field(el)
            // 
            //     # transform embedded field back to t-field
            //     el.getparent().replace(el, self.to_field_ref(el))
            // 
            // for el in self.extract_oe_structures(arch_section):
            //     if self.save_oe_structure(el):
            //         # empty oe_structure in parent view
            //         empty = self.to_empty_oe_structure(el)
            //         if el == arch_section:
            //             arch_section = empty
            //         else:
            //             el.getparent().replace(el, empty)
            // 
            // new_arch = self.replace_arch_section(xpath, arch_section)
            // old_arch = etree.fromstring(self.arch.encode('utf-8'))
            // if not self._are_archs_equal(old_arch, new_arch):
            //     self._set_noupdate()
            //     self.write({'arch': etree.tostring(new_arch, encoding='unicode')})
            //     self._copy_custom_snippet_translations(self, 'arch_db')
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def save(self, value, xpath=None):
            // self.ensure_one()
            // current_website = self.env['website'].get_current_website()
            // # xpath condition is important to be sure we are editing a view and not
            // # a field as in that case `self` might not exist (check commit message)
            // if xpath and self.key and current_website:
            //     # The first time a generic view is edited, if multiple editable parts
            //     # were edited at the same time, multiple call to this method will be
            //     # done but the first one may create a website specific view. So if there
            //     # already is a website specific view, we need to divert the super to it.
            //     website_specific_view = self.env['ir.ui.view'].search([
            //         ('key', '=', self.key),
            //         ('website_id', '=', current_website.id)
            //     ], limit=1)
            //     if website_specific_view:
            //         self = website_specific_view
            // super(View, self).save(value, xpath=xpath)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrUiView> SaveEmbeddedFieldAsync(Guid id, IrUiViewSaveEmbeddedFieldRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_ui_view.py) ---
            // def save_embedded_field(self, el):
            // Model = self.env[el.get('data-oe-model')]
            // field = el.get('data-oe-field')
            // 
            // model = 'ir.qweb.field.' + el.get('data-oe-type')
            // converter = self.env[model] if model in self.env else self.env['ir.qweb.field']
            // 
            // try:
            //     value = converter.from_html(Model, Model._fields[field], el)
            //     if value is not None:
            //         # TODO: batch writes?
            //         record = Model.browse(int(el.get('data-oe-id')))
            //         if not self.env.context.get('lang') and self.get_default_lang_code():
            //             record.with_context(lang=self.get_default_lang_code()).write({field: value})
            //         else:
            //             record.write({field: value})
            // 
            //         if callable(Model._fields[field].translate):
            //             self._copy_custom_snippet_translations(record, field)
            // 
            // except (ValueError, TypeError):
            //     raise ValidationError(_(
            //         "Invalid field value for %(field_name)s: %(value)s",
            //         field_name=Model._fields[field].string,
            //         value=el.text_content().strip(),
            //     ))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrUiView> SaveOeStructureAsync(Guid id, IrUiViewSaveOeStructureRequestDto input)
        {
            #if PYTHON_CODE
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_ui_view.py) ---
            // def save_oe_structure(self, el):
            // self.ensure_one()
            // 
            // if el.get('id') in self.key:
            //     # Do not inherit if the oe_structure already has its own inheriting view
            //     return False
            // 
            // arch = etree.Element('data')
            // xpath = etree.Element('xpath', expr="//*[hasclass('oe_structure')][@id='{}']".format(el.get('id')), position="replace")
            // arch.append(xpath)
            // attributes = self._get_cleaned_non_editing_attributes(el.attrib.items())
            // structure = etree.Element(el.tag, attrib=attributes)
            // structure.text = el.text
            // xpath.append(structure)
            // for child in el.iterchildren(tag=etree.Element):
            //     structure.append(copy.deepcopy(child))
            // 
            // vals = {
            //     'inherit_id': self.id,
            //     'name': '%s (%s)' % (self.name, el.get('id')),
            //     'arch': etree.tostring(arch, encoding='unicode'),
            //     'key': '%s_%s' % (self.key, el.get('id')),
            //     'type': 'qweb',
            //     'mode': 'extension',
            // }
            // vals.update(self._save_oe_structure_hook())
            // oe_structure_view = self.env['ir.ui.view'].create(vals)
            // self._copy_custom_snippet_translations(oe_structure_view, 'arch_db')
            // 
            // return True
            #endif
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrUiView> SaveOeStructureHookInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_ui_view.py) ---
            // def _save_oe_structure_hook(self):
            // return {}
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def _save_oe_structure_hook(self):
            // res = super(View, self)._save_oe_structure_hook()
            // res['website_id'] = self.env['website'].get_current_website().id
            // return res
            */
            return default;
        }

        public async Task<IrUiView> SaveSnippetAsync(Guid id, IrUiViewSaveSnippetRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_ui_view.py) ---
            // def save_snippet(self, name, arch, template_key, snippet_key, thumbnail_url):
            // """
            // Saves a new snippet arch so that it appears with the given name when
            // using the given snippets template.
            // 
            // :param name: the name of the snippet to save
            // :param arch: the html structure of the snippet to save
            // :param template_key: the key of the view regrouping all snippets in
            //     which the snippet to save is meant to appear
            // :param snippet_key: the key (without module part) to identify
            //     the snippet from which the snippet to save originates
            // :param thumbnail_url: the url of the thumbnail to use when displaying
            //     the snippet to save
            // """
            // app_name = template_key.split('.')[0]
            // snippet_key = '%s_%s' % (snippet_key, uuid.uuid4().hex)
            // full_snippet_key = '%s.%s' % (app_name, snippet_key)
            // 
            // # find available name
            // current_website = self.env['website'].browse(self._context.get('website_id'))
            // website_domain = current_website.website_domain()
            // used_names = self.search(expression.AND([
            //     [('name', '=like', '%s%%' % name)], website_domain
            // ])).mapped('name')
            // name = self._find_available_name(name, used_names)
            // 
            // # html to xml to add '/' at the end of self closing tags like br, ...
            // arch_tree = html.fromstring(arch)
            // attributes = self._get_cleaned_non_editing_attributes(arch_tree.attrib.items())
            // for attr in arch_tree.attrib:
            //     if attr in attributes:
            //         arch_tree.attrib[attr] = attributes[attr]
            //     else:
            //         del arch_tree.attrib[attr]
            // xml_arch = etree.tostring(arch_tree, encoding='utf-8')
            // new_snippet_view_values = {
            //     'name': name,
            //     'key': full_snippet_key,
            //     'type': 'qweb',
            //     'arch': xml_arch,
            // }
            // new_snippet_view_values.update(self._snippet_save_view_values_hook())
            // custom_snippet_view = self.create(new_snippet_view_values)
            // model = self._context.get('model')
            // field = self._context.get('field')
            // if field == 'arch':
            //     # Special case for `arch` which is a kind of related (through a
            //     # compute) to `arch_db` but which is hosting XML/HTML content while
            //     # being a char field.. Which is then messing around with the
            //     # `get_translation_dictionary` call, returning XML instead of
            //     # strings
            //     field = 'arch_db'
            // res_id = self._context.get('resId')
            // if model and field and res_id:
            //     self._copy_field_terms_translations(
            //         self.env[model].browse(int(res_id)),
            //         field,
            //         custom_snippet_view,
            //         'arch_db',
            //     )
            // 
            // custom_section = self.search([('key', '=', template_key)])
            // snippet_addition_view_values = {
            //     'name': name + ' Block',
            //     'key': self._get_snippet_addition_view_key(template_key, snippet_key),
            //     'inherit_id': custom_section.id,
            //     'type': 'qweb',
            //     'arch': """
            //         <data inherit_id="%s">
            //             <xpath expr="//snippets[@id='snippet_custom']" position="inside">
            //                 <t t-snippet="%s" t-thumbnail="%s"/>
            //             </xpath>
            //         </data>
            //     """ % (template_key, full_snippet_key, thumbnail_url),
            // }
            // snippet_addition_view_values.update(self._snippet_save_view_values_hook())
            // self.create(snippet_addition_view_values)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrUiView> SearchModelDataIdInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _search_model_data_id(self, operator, value):
            // name = 'name' if isinstance(value, str) else 'id'
            // domain = [('model', '=', 'ir.ui.view'), (name, operator, value)]
            // data = self.env['ir.model.data'].sudo().search(domain)
            // return [('id', 'in', data.mapped('res_id'))]
            */
            return default;
        }

        protected async Task<IrUiView> SetNoupdateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_ui_view.py) ---
            // def _set_noupdate(self):
            // self.sudo().mapped('model_data_id').write({'noupdate': True})
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def _set_noupdate(self):
            // '''If website is installed, any call to `save` from the frontend will
            // actually write on the specific view (or create it if not exist yet).
            // In that case, we don't want to flag the generic view as noupdate.
            // '''
            // if not self._context.get('website_id'):
            //     super(View, self)._set_noupdate()
            */
            return default;
        }

        protected async Task<IrUiView> SetPwdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def _set_pwd(self):
            // crypt_context = self.env.user._crypt_context()
            // for r in self:
            //     if r.type == 'qweb':
            //         r.sudo().visibility_password = (r.visibility_password_display and crypt_context.hash(r.visibility_password_display)) or ''
            //         r.visibility = r.visibility
            */
            return default;
        }

        protected async Task<IrUiView> SnippetSaveViewValuesHookInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_ui_view.py) ---
            // def _snippet_save_view_values_hook(self):
            // return {}
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def _snippet_save_view_values_hook(self):
            // res = super()._snippet_save_view_values_hook()
            // website_id = self.env.context.get('website_id')
            // if website_id:
            //     res['website_id'] = website_id
            // return res
            */
            return default;
        }

        public async Task<IrUiView> ToEmptyOeStructureAsync(Guid id, IrUiViewToEmptyOeStructureRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_ui_view.py) ---
            // def to_empty_oe_structure(self, el):
            // out = html.html_parser.makeelement(el.tag, attrib=el.attrib)
            // out.tail = el.tail
            // return out
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrUiView> ToFieldRefAsync(Guid id, IrUiViewToFieldRefRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_ui_view.py) ---
            // def to_field_ref(self, el):
            // # filter out meta-information inserted in the document
            // attributes = {k: v for k, v in el.attrib.items()
            //                    if not k.startswith('data-oe-')}
            // attributes['t-field'] = el.get('data-oe-expression')
            // 
            // out = html.html_parser.makeelement(el.tag, attrib=attributes)
            // out.tail = el.tail
            // return out
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def unlink(self):
            // '''This implements COU (copy-on-unlink). When deleting a generic page
            // website-specific pages will be created so only the current
            // website is affected.
            // '''
            // current_website_id = self._context.get('website_id')
            // 
            // if current_website_id and not self._context.get('no_cow'):
            //     for view in self.filtered(lambda view: not view.website_id):
            //         for w in self.env['website'].search([('id', '!=', current_website_id)]):
            //             # reuse the COW mechanism to create
            //             # website-specific copies, it will take
            //             # care of creating pages and menus.
            //             view.with_context(website_id=w.id).write({'name': view.name})
            // 
            // specific_views = self.env['ir.ui.view']
            // if self and self.pool._init:
            //     for view in self.filtered(lambda view: not view.website_id):
            //         specific_views += view._get_specific_views()
            // 
            // result = super(View, self + specific_views).unlink()
            // self.env.registry.clear_cache('templates')
            // return result
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def unlink(self):
            // # if in uninstall mode and has children views, emulate an ondelete cascade
            // if self.env.context.get('_force_unlink', False) and self.inherit_children_ids:
            //     self.inherit_children_ids.unlink()
            // self.env.registry.clear_cache('templates')
            // return super(View, self).unlink()
            */
            return await base.UnlinkAsync(ids);
        }

        protected async Task<IrUiView> UpdateFieldTranslationsInternalAsync(object fname, object translations, object digest, object source_lang)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def _update_field_translations(self, fname, translations, digest=None, source_lang=None):
            // return super(View, self.with_context(no_cow=True))._update_field_translations(fname, translations, digest=digest, source_lang=source_lang)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _update_field_translations(self, fname, translations, digest=None, source_lang=None):
            // return super(View, self.with_context(no_save_prev=True))._update_field_translations(fname, translations, digest=digest, source_lang=source_lang)
            */
            return default;
        }

        protected async Task<IrUiView> ValidInheritanceInternalAsync(object arch)
        {
            #if PYTHON_CODE
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _valid_inheritance(self, arch):
            // """ Check whether view inheritance is based on translated attribute. """
            // for node in arch.xpath('//*[@position]'):
            //     # inheritance may not use a translated attribute as selector
            //     if node.tag == 'xpath':
            //         match = TRANSLATED_ATTRS_RE.search(node.get('expr', ''))
            //         if match:
            //             message = "View inheritance may not use attribute %r as a selector." % match.group(1)
            //             self._raise_view_error(message, node)
            //         if WRONGCLASS.search(node.get('expr', '')):
            //             _logger.warning(
            //                 "Error-prone use of @class in view %s (%s): use the "
            //                 "hasclass(*classes) function to filter elements by "
            //                 "their classes", self.name, self.xml_id
            //             )
            //     else:
            //         for attr in TRANSLATED_ATTRS:
            //             if node.get(attr):
            //                 message = "View inheritance may not use attribute %r as a selector." % attr
            //                 self._raise_view_error(message, node)
            // return True
            #endif
            return default;
        }

        protected async Task<IrUiView> ValidateAttributesInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _validate_attributes(self, node, name_manager, node_info):
            // """ Generic validation of node attributes. """
            // 
            // # python expression used in for readonly, invisible, ...
            // # and thus are only executed client side
            // for attr in VIEW_MODIFIERS:
            //     py_expression = node.attrib.get(attr)
            //     if py_expression:
            //         self._validate_expression(node, name_manager, py_expression, f"modifier {attr!r}", node_info)
            // 
            // for attr, expr in node.items():
            //     if attr in ('class', 't-att-class', 't-attf-class'):
            //         self._validate_classes(node, expr)
            // 
            //     elif attr == 'context':
            //         try:
            //             vnames = get_expression_field_names(expr)
            //         except SyntaxError as e:
            //             message = _('Invalid context: “%(expr)s” is not a valid Python expression \n\n %(error)s', expr=expr, error=e)
            //             self._raise_view_error(message)
            //         if vnames:
            //             name_manager.must_have_fields(node, vnames, node_info, f"context ({expr})")
            //         for key, val_ast in get_dict_asts(expr).items():
            //             if key == 'group_by':  # only in context
            //                 if not isinstance(val_ast, ast.Constant) or not isinstance(val_ast.value, str):
            //                     msg = _(
            //                         '"group_by" value must be a string %(attribute)s=“%(value)s”',
            //                         attribute=attr, value=expr,
            //                     )
            //                     self._raise_view_error(msg, node)
            //                 group_by = val_ast.value
            //                 fname = group_by.split(':')[0]
            //                 if fname not in name_manager.model._fields:
            //                     msg = _(
            //                         'Unknown field “%(field)s” in "group_by" value in %(attribute)s=“%(value)s”',
            //                         field=fname, attribute=attr, value=expr,
            //                     )
            //                     self._raise_view_error(msg, node)
            // 
            //     elif attr in ('col', 'colspan'):
            //         # col check is mainly there for the tag 'group', but previous
            //         # check was generic in view form
            //         if not expr.isdigit():
            //             self._raise_view_error(
            //                 _('“%(attribute)s” value must be an integer (%(value)s)',
            //                   attribute=attr, value=expr),
            //                 node,
            //             )
            // 
            //     elif attr.startswith('decoration-'):
            //         vnames = get_expression_field_names(expr)
            //         if vnames:
            //             name_manager.must_have_fields(node, vnames, node_info, f"{attr}={expr!r}")
            // 
            //     elif attr == 'data-bs-toggle' and expr == 'tab':
            //         if node.get('role') != 'tab':
            //             msg = 'tab link (data-bs-toggle="tab") must have "tab" role'
            //             self._log_view_warning(msg, node)
            //         aria_control = node.get('aria-controls') or node.get('t-att-aria-controls')
            //         if not aria_control and not node.get('t-attf-aria-controls'):
            //             msg = 'tab link (data-bs-toggle="tab") must have "aria_control" defined'
            //             self._log_view_warning(msg, node)
            //         if aria_control and '#' in aria_control:
            //             msg = 'aria-controls in tablink cannot contains "#"'
            //             self._log_view_warning(msg, node)
            // 
            //     elif attr == "role" and expr in ('presentation', 'none'):
            //         msg = ("A role cannot be `none` or `presentation`. "
            //             "All your elements must be accessible with screen readers, describe it.")
            //         self._log_view_warning(msg, node)
            // 
            //     elif attr == 'group':
            //         msg = "attribute 'group' is not valid.  Did you mean 'groups'?"
            //         self._log_view_warning(msg, node)
            // 
            //     elif (re.match(r'^(t\-att\-|t\-attf\-)?data-tooltip(-template|-info)?$', attr)):
            //         self._raise_view_error(_("Forbidden attribute used in arch (%s).", attr), node)
            // 
            //     elif (attr.startswith("t-")):
            //         self._validate_qweb_directive(node, attr, node_info["view_type"])
            //         if (re.search(COMP_REGEX, expr)):
            //             self._raise_view_error(_("Forbidden use of `__comp__` in arch."), node)
            */
            return default;
        }

        protected async Task<IrUiView> ValidateClassesInternalAsync(object node, object expr)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _validate_classes(self, node, expr):
            // """ Validate the classes present on node. """
            // classes = set(expr.split(' '))
            // # Be careful: not always true if it is an expression
            // # example: <div t-attf-class="{{!selection_mode ? 'oe_kanban_color_' + kanban_getcolor(record.color.raw_value) : ''}} oe_kanban_card oe_kanban_global_click oe_applicant_kanban oe_semantic_html_override">
            // if 'modal' in classes and node.get('role') != 'dialog':
            //     msg = '"modal" class should only be used with "dialog" role'
            //     self._log_view_warning(msg, node)
            // 
            // if 'modal-header' in classes and node.tag != 'header':
            //     msg = '"modal-header" class should only be used in "header" tag'
            //     self._log_view_warning(msg, node)
            // 
            // if 'modal-body' in classes and node.tag != 'main':
            //     msg = '"modal-body" class should only be used in "main" tag'
            //     self._log_view_warning(msg, node)
            // 
            // if 'modal-footer' in classes and node.tag != 'footer':
            //     msg = '"modal-footer" class should only be used in "footer" tag'
            //     self._log_view_warning(msg, node)
            // 
            // if 'tab-pane' in classes and node.get('role') != 'tabpanel':
            //     msg = '"tab-pane" class should only be used with "tabpanel" role'
            //     self._log_view_warning(msg, node)
            // 
            // if 'nav-tabs' in classes and node.get('role') != 'tablist':
            //     msg = 'A tab list with class nav-tabs must have role="tablist"'
            //     self._log_view_warning(msg, node)
            // 
            // if any(klass.startswith('alert-') for klass in classes):
            //     if (
            //         node.get('role') not in ('alert', 'alertdialog', 'status')
            //         and 'alert-link' not in classes
            //     ):
            //         msg = ("An alert (class alert-*) must have an alert, alertdialog or "
            //                 "status role or an alert-link class. Please use alert and "
            //                 "alertdialog only for what expects to stop any activity to "
            //                 "be read immediately.")
            //         self._log_view_warning(msg, node)
            // 
            // if any(klass.startswith('fa-') for klass in classes):
            //     description = 'A <%s> with fa class (%s)' % (node.tag, expr)
            //     self._validate_fa_class_accessibility(node, description)
            // 
            // if any(klass.startswith('btn') for klass in classes):
            //     if node.tag in ('a', 'button', 'select'):
            //         pass
            //     elif node.tag == 'input' and node.get('type') in ('button', 'submit', 'reset'):
            //         pass
            //     elif any(klass in classes for klass in ('btn-group', 'btn-toolbar', 'btn-addr')):
            //         pass
            //     elif node.tag == 'field' and node.get('widget') == 'url':
            //         pass
            //     else:
            //         msg = ("A simili button must be in tag a/button/select or tag `input` "
            //                 "with type button/submit/reset or have class in "
            //                 "btn-group/btn-toolbar/btn-addr")
            //         self._log_view_warning(msg, node)
            */
            return default;
        }

        protected async Task<IrUiView> ValidateCustomViewsInternalAsync(object model)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_import_module, FILE: ir_ui_view.py) ---
            // def _validate_custom_views(self, model):
            // # views from imported modules should be considered as custom views
            // result = super(IrUiView, self)._validate_custom_views(model)
            // 
            // self._cr.execute("""
            //     SELECT max(v.id)
            //        FROM ir_ui_view v
            //   LEFT JOIN ir_model_data md ON (md.model = 'ir.ui.view' AND md.res_id = v.id)
            //   LEFT JOIN ir_module_module m ON (m.name = md.module)
            //       WHERE m.imported = true
            //         AND v.model = %s
            //         AND v.active = true
            //    GROUP BY coalesce(v.inherit_id, v.id)
            // """, [model])
            // 
            // ids = (row[0] for row in self._cr.fetchall())
            // views = self.with_context(load_all_views=True).browse(ids)
            // return views._check_xml() and result
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _validate_custom_views(self, model):
            // """Validate architecture of custom views (= without xml id) for a given model.
            //     This method is called at the end of registry update.
            // """
            // rec = self.browse(id_ for id_, in self.env.execute_query(SQL("""
            //            SELECT max(v.id)
            //              FROM ir_ui_view v
            //         LEFT JOIN ir_model_data md ON (md.model = 'ir.ui.view' AND md.res_id = v.id)
            //             WHERE md.module IN (SELECT name FROM ir_module_module) IS NOT TRUE
            //               AND v.model = %s
            //               AND v.active = true
            //          GROUP BY coalesce(v.inherit_id, v.id)
            //          """, model)))
            // return rec.with_context({'load_all_views': True})._check_xml()
            */
            return default;
        }

        protected async Task<IrUiView> ValidateDomainIdentifiersInternalAsync(object node, object name_manager, object domain, object use, object target_model, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _validate_domain_identifiers(self, node, name_manager, domain, use, target_model, node_info):
            // try:
            //     fnames, vnames = get_domain_value_names(domain)
            // except (SyntaxError, ValueError, AttributeError) as e:
            //     msg = _("Invalid %(use)s: “%(expr)s”\n%(error)s", use=use, expr=domain, error=e)
            //     self._raise_view_error(msg, node, from_exception=e)
            // 
            // self._check_field_paths(node, fnames, target_model, f"{use} ({domain})")
            // name_manager.must_have_fields(node, vnames, node_info, f"{use} ({domain})")
            */
            return default;
        }

        protected async Task<IrUiView> ValidateExpressionInternalAsync(object node, object name_manager, object py_expression, object use, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _validate_expression(self, node, name_manager, py_expression, use, node_info):
            // try:
            //     if py_expression.lower() in ("0", "false", "1", "true"):
            //         # most (~95%) elements are 1/True/0/False
            //         return
            //     fnames = get_expression_field_names(py_expression)
            // except (SyntaxError, ValueError, AttributeError) as e:
            //     msg = _("Invalid %(use)s: “%(expr)s”\n%(error)s", use=use, expr=py_expression, error=e)
            //     self._raise_view_error(msg, node, from_exception=e)
            // name_manager.must_have_fields(node, fnames, node_info, f"{use} ({py_expression})")
            */
            return default;
        }

        protected async Task<IrUiView> ValidateFaClassAccessibilityInternalAsync(object node, object description)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _validate_fa_class_accessibility(self, node, description):
            // valid_aria_attrs = {
            //     *att_names('title'), *att_names('aria-label'), *att_names('aria-labelledby'),
            // }
            // valid_t_attrs = {'t-value', 't-raw', 't-field', 't-esc', 't-out'}
            // 
            // ## Following or preceding text
            // if (node.tail or '').strip() or (node.getparent().text or '').strip():
            //     # text<i class="fa-..."/> or <i class="fa-..."/>text or
            //     return
            // 
            // ## Following or preceding text in span
            // def has_text(elem):
            //     if elem is None:
            //         return False
            //     if elem.tag == 'span' and elem.text:
            //         return True
            //     if elem.tag in ['field', 'label'] and elem.get('string'):
            //         return True
            //     if elem.tag == 't' and (elem.get('t-esc') or elem.get('t-raw')):
            //         return True
            //     return False
            // 
            // if has_text(node.getnext()) or has_text(node.getprevious()):
            //     return
            // 
            // def has_title_or_aria_label(node):
            //     return any(node.get(attr) for attr in valid_aria_attrs)
            // 
            // ## Aria label can be on ancestors
            // if any(map(has_title_or_aria_label, node.iterancestors())):
            //     return
            // 
            // if node.get('string'):
            //     return
            // 
            // ## And we ignore all elements with describing in children
            // def contains_description(node, depth=0):
            //     if depth > 2:
            //         _logger.warning('excessive depth in fa')
            //     if any(node.get(attr) for attr in valid_t_attrs):
            //         return True
            //     if has_title_or_aria_label(node):
            //         return True
            //     if node.tag in ('label', 'field'):
            //         return True
            //     if node.text:  # not sure, does it match *[text()]
            //         return True
            //     return any(contains_description(child, depth+1) for child in node)
            // 
            // if contains_description(node):
            //     return
            // 
            // msg = '%s must have title in its tag, parents, descendants or have text'
            // self._log_view_warning(msg % description, node)
            */
            return default;
        }

        protected async Task<IrUiView> ValidateModuleViewsInternalAsync(object module)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _validate_module_views(self, module):
            // """ Validate the architecture of all the views of a given module that
            //     are impacted by view updates, but have not been checked yet.
            // """
            // assert self.pool._init
            // 
            // # only validate the views that still exist...
            // prefix = module + '.'
            // prefix_len = len(prefix)
            // names = tuple(
            //     xmlid[prefix_len:]
            //     for xmlid in self.pool.loaded_xmlids
            //     if xmlid.startswith(prefix)
            // )
            // if not names:
            //     return
            // 
            // # retrieve the views with an XML id that has not been checked yet, i.e.,
            // # the views with noupdate=True on their xml id
            // views = self.browse(id_ for id_, in self.env.execute_query(SQL("""
            //     SELECT v.id
            //     FROM ir_ui_view v
            //     JOIN ir_model_data md ON (md.model = 'ir.ui.view' AND md.res_id = v.id)
            //     WHERE md.module = %s AND md.name IN %s AND md.noupdate
            // """, module, names)))
            // 
            // for view in views:
            //     view._check_xml()
            */
            return default;
        }

        protected async Task<IrUiView> ValidateQwebDirectiveInternalAsync(object node, object directive, object view_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _validate_qweb_directive(self, node, directive, view_type):
            // """Some views (e.g. kanban, form) generate owl templates from the archs.
            // However, we don't want to see owl directives directly written in archs.
            // There are exceptions though, e.g. the kanban arch defines qweb templates.
            // We thus here validate that the given directive is allowed, according to the view_type.
            // """
            // allowed_directives = ["t-translation"]
            // if self._is_qweb_based_view(view_type):
            //     allowed_directives.extend([
            //         "t-name",
            //         "t-esc",
            //         "t-out",
            //         "t-set",
            //         "t-value",
            //         "t-if",
            //         "t-else",
            //         "t-elif",
            //         "t-foreach",
            //         "t-as",
            //         "t-key",
            //         "t-att.*",
            //         "t-call",
            //         "t-debug",
            //     ])
            // if (not next(filter(lambda regex: re.match(regex, directive), allowed_directives), None)):
            //     self._raise_view_error(_("Forbidden owl directive used in arch (%s).", directive), node)
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagAInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _validate_tag_a(self, node, name_manager, node_info):
            // # ('calendar', 'form', 'graph', 'kanban', 'pivot', 'search', 'list', 'activity')
            // if node_info['validate'] and any('btn' in node.get(cl, '') for cl in att_names('class')):
            //     if node.get('role') != 'button':
            //         msg = '"<a>" tag with "btn" class must have "button" role'
            //         self._log_view_warning(msg, node)
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagButtonInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _validate_tag_button(self, node, name_manager, node_info):
            // if not node_info['validate']:
            //     return
            // name = node.get('name')
            // special = node.get('special')
            // type_ = node.get('type')
            // if special:
            //     if special not in ('cancel', 'save', 'add'):
            //         self._raise_view_error(_("Invalid special '%(value)s' in button", value=special), node)
            // elif type_:
            //     if type_ == 'edit': # list_renderer, used in kanban view
            //         return
            //     elif not name:
            //         self._raise_view_error(_("Button must have a name"), node)
            //     elif type_ == 'object':
            //         func = getattr(name_manager.model, name, None)
            //         if not func:
            //             msg = _(
            //                 "%(action_name)s is not a valid action on %(model_name)s",
            //                 action_name=name, model_name=name_manager.model._name,
            //             )
            //             self._raise_view_error(msg, node)
            //         try:
            //             get_public_method(name_manager.model, name)
            //         except (AttributeError, AccessError):
            //             msg = _(
            //                 "%(method)s on %(model)s is private and cannot be called from a button",
            //                 method=name, model=name_manager.model._name,
            //             )
            //             self._raise_view_error(msg, node)
            //         try:
            //             inspect.signature(func).bind()
            //         except TypeError:
            //             msg = "%s on %s has parameters and cannot be called from a button"
            //             self._log_view_warning(msg % (name, name_manager.model._name), node)
            //     elif type_ == 'action':
            //         name_manager.must_exist_action(name, node)
            // 
            //     name_manager.has_action(name)
            // 
            // if node.get('icon'):
            //     description = 'A button with icon attribute (%s)' % node.get('icon')
            //     self._validate_fa_class_accessibility(node, description)
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagCalendarInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _validate_tag_calendar(self, node, name_manager, node_info):
            // for additional_field in ('date_start', 'date_delay', 'date_stop', 'color', 'all_day'):
            //     if fnames := node.get(additional_field):
            //         name_manager.has_field(node, fnames.split('.', 1)[0], node_info)
            // for f in node:
            //     if f.tag == 'filter':
            //         name_manager.has_field(node, f.get('name'), node_info)
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagDivInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _validate_tag_div(self, node, name_manager, node_info):
            // if node_info['validate']:
            //     self._check_dropdown_menu(node)
            //     self._check_progress_bar(node)
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagFieldInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _validate_tag_field(self, node, name_manager, node_info):
            // validate = node_info['validate']
            // 
            // name = node.get('name')
            // if not name:
            //     self._raise_view_error(_("Field tag must have a \"name\" attribute defined"), node)
            // 
            // field = name_manager.model._fields.get(name)
            // if field:
            //     if field.groups:
            //         group_definitions = self.env['res.groups']._get_group_definitions()
            //         node_info['model_groups'] &= group_definitions.parse(field.groups, raise_if_not_found=False)
            // 
            //     if validate and field.relational:
            //         domain = (
            //             node.get('domain')
            //             or node_info['editable'] and field._description_domain(self.env)
            //         )
            //         if isinstance(domain, str):
            //             # dynamic domain: in [('foo', '=', bar)], field 'foo' must
            //             # exist on the comodel and field 'bar' must be in the view
            //             desc = (f'domain of <field name="{name}">' if node.get('domain')
            //                     else f"domain of python field {name!r}")
            //             try:
            //                 self._validate_domain_identifiers(node, name_manager, domain, desc, field.comodel_name, node_info)
            //             except ValueError as e:
            //                 if 'Modifier must be a domain' in str(e):
            //                     warnings.warn(f"Non-domain syntaxes are deprecated for attribute 'domain': {desc}\n{domain!r}", DeprecationWarning, 2)
            //                 else:
            //                     raise
            // 
            //     elif validate and node.get('domain'):
            //         msg = _(
            //             'Domain on non-relational field "%(name)s" makes no sense (domain:%(domain)s)',
            //             name=name, domain=node.get('domain'),
            //         )
            //         self._raise_view_error(msg, node)
            // 
            //     if field.type == 'properties' and node_info['view_type'] != 'search':
            //         name_manager.must_have_fields(node, {field._description_definition_record}, node_info, use=f"definition record of {field.name}")
            // 
            //     for child in node:
            //         if child.tag not in ('form', 'list', 'graph', 'kanban', 'calendar'):
            //             continue
            //         node.remove(child)
            //         self._validate_view(
            //             child, field.comodel_name, view_type=child.tag, editable=node_info['editable'],
            //             node_info=node_info,
            //         )
            // 
            // elif validate and name not in name_manager.field_info:
            //     msg = _(
            //         'Field "%(field_name)s" does not exist in model "%(model_name)s"',
            //         field_name=name, model_name=name_manager.model._name,
            //     )
            //     self._raise_view_error(msg, node)
            // 
            // name_manager.has_field(node, name, node_info, {'id': node.get('id'), 'select': node.get('select')})
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagFilterInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _validate_tag_filter(self, node, name_manager, node_info):
            // if not node_info['validate']:
            //     return
            // domain = node.get('domain')
            // if domain:
            //     name = node.get('name')
            //     desc = f'domain of <filter name="{name}">' if name else 'domain of <filter>'
            //     self._validate_domain_identifiers(node, name_manager, domain, desc, name_manager.model._name, node_info)
            // if node.get("date") and (default_periods := node.get("default_period")):
            //     custom_options = {f'custom_{child.attrib["name"]}' for child in node.getchildren()}
            //     for default_period in default_periods.split(","):
            //         if not re.fullmatch(r"(year|month)((-|\+)[1-9]\d*)?", default_period)\
            //             and default_period not in custom_options | {"first_quarter", "second_quarter", "third_quarter", "fourth_quarter"}:
            //             msg = _(
            //                 "Invalid default period %(default_period)s for date filter",
            //                 default_period=default_period,
            //             )
            //             self._raise_view_error(msg, node)
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagFormInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _validate_tag_form(self, node, name_manager, node_info):
            // self._validate_tag_kanban(node, name_manager, node_info)
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagGraphInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _validate_tag_graph(self, node, name_manager, node_info):
            // if not node_info['validate']:
            //     return
            // for child in node.iterchildren(tag=etree.Element):
            //     if child.tag != 'field' and not isinstance(child, etree._Comment):
            //         msg = _('A <graph> can only contains <field> nodes, found a <%s>', child.tag)
            //         self._raise_view_error(msg, child)
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagGroupbyInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _validate_tag_groupby(self, node, name_manager, node_info):
            // # groupby nodes should be considered as nested view because they may
            // # contain fields on the comodel
            // name = node.get('name')
            // if not name:
            //     return
            // field = name_manager.model._fields.get(name)
            // if field:
            //     if node_info['validate']:
            //         if field.type != 'many2one':
            //             msg = _(
            //                 "Field '%(name)s' found in 'groupby' node can only be of type many2one, found %(type)s",
            //                 name=field.name, type=field.type,
            //             )
            //             self._raise_view_error(msg, node)
            //         domain = node_info['editable'] and field._description_domain(self.env)
            //         if isinstance(domain, str):
            //             desc = f"domain of python field '{name}'"
            //             self._validate_domain_identifiers(node, name_manager, domain, desc, field.comodel_name, node_info)
            // 
            //     # move all children nodes into a new node <groupby>
            //     groupby_node = E.groupby(*node)
            //     # validate the node as a nested view
            //     self._validate_view(
            //         groupby_node, field.comodel_name, view_type="groupby", editable=False,
            //         node_info=node_info,
            //     )
            //     name_manager.has_field(node, name, node_info)
            // 
            // elif node_info['validate']:
            //     msg = _(
            //         "Field '%(field)s' found in 'groupby' node does not exist in model %(model)s",
            //         field=name, model=name_manager.model._name,
            //     )
            //     self._raise_view_error(msg, node)
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagHierarchyInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_hierarchy, FILE: ir_ui_view.py) ---
            // def _validate_tag_hierarchy(self, node, name_manager, node_info):
            // if not node_info['validate']:
            //     return
            // 
            // templates_count = 0
            // for child in node.iterchildren(tag=etree.Element):
            //     if child.tag == 'templates':
            //         if not templates_count:
            //             templates_count += 1
            //         else:
            //             msg = _('Hierarchy view can contain only one templates tag')
            //             self._raise_view_error(msg, child)
            //     elif child.tag != 'field':
            //         msg = _('Hierarchy child can only be field or template, got %s', child.tag)
            //         self._raise_view_error(msg, child)
            // 
            // remaining = set(node.attrib) - HIERARCHY_VALID_ATTRIBUTES
            // if remaining:
            //     msg = _(
            //         "Invalid attributes (%(invalid_attributes)s) in hierarchy view. Attributes must be in (%(valid_attributes)s)",
            //         invalid_attributes=format_list(self.env, remaining),
            //         valid_attributes=format_list(self.env, HIERARCHY_VALID_ATTRIBUTES),
            //     )
            //     self._raise_view_error(msg, node)
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagImgInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _validate_tag_img(self, node, name_manager, node_info):
            // if node_info['validate'] and not any(node.get(alt) for alt in att_names('alt')):
            //     self._log_view_warning('<img> tag must contain an alt attribute', node)
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagKanbanInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _validate_tag_kanban(self, node, name_manager, node_info):
            // if node.xpath("//t[@t-name='kanban-box']"):
            //     _logger.warning("'kanban-box' is deprecated, define a 'card' template instead")
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagLabelInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _validate_tag_label(self, node, name_manager, node_info):
            // if not node_info['validate']:
            //     return
            // # replace return not arch.xpath('//label[not(@for) and not(descendant::input)]')
            // for_ = node.get('for')
            // if not for_:
            //     msg = _('Label tag must contain a "for". To match label style '
            //             'without corresponding field or button, use \'class="o_form_label"\'.')
            //     self._raise_view_error(msg, node)
            // else:
            //     name_manager.must_have_name(for_, '<label for="...">')
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagListInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _validate_tag_list(self, node, name_manager, node_info):
            // # reuse form view validation
            // self._validate_tag_form(node, name_manager, node_info)
            // if not node_info['validate']:
            //     return
            // # inline list views inside form views aren't rng validated, so we must validate the
            // # editable attribute in python
            // editable_attr = node.get("editable")
            // if editable_attr and editable_attr not in ["top", "bottom"]:
            //     msg = _(
            //         'The "editable" attribute of list views must be "top" or "bottom", received %(value)s',
            //         value=editable_attr,
            //     )
            //     self._raise_view_error(msg, node)
            // allowed_tags = ('field', 'button', 'control', 'groupby', 'widget', 'header')
            // for child in node.iterchildren(tag=etree.Element):
            //     if child.tag not in allowed_tags and not isinstance(child, etree._Comment):
            //         msg = _(
            //             'List child can only have one of %(tags)s tag (not %(wrong_tag)s)',
            //             tags=', '.join(allowed_tags), wrong_tag=child.tag,
            //         )
            //         self._raise_view_error(msg, child)
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagPageInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _validate_tag_page(self, node, name_manager, node_info):
            // if not node_info['validate']:
            //     return
            // if node.getparent() is None or node.getparent().tag != 'notebook':
            //     self._raise_view_error(_('Page direct ancestor must be notebook'), node)
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagSearchInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _validate_tag_search(self, node, name_manager, node_info):
            // if node_info['validate'] and not node.iterdescendants(tag="field"):
            //     # the field of the search view may be within a group node, which is why we must check
            //     # for all descendants containing a node with a field tag, if this is not the case
            //     # then a search is not possible.
            //     self._log_view_warning('Search tag requires at least one field element', node)
            // 
            // searchpanels = [child for child in node if child.tag == 'searchpanel']
            // if searchpanels:
            //     if len(searchpanels) > 1:
            //         self._raise_view_error(_('Search tag can only contain one search panel'), node)
            //     node.remove(searchpanels[0])
            //     self._validate_view(searchpanels[0], name_manager.model._name, view_type="searchpanel",
            //                         node_info=node_info, editable=False)
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagSearchpanelInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _validate_tag_searchpanel(self, node, name_manager, node_info):
            // if not node_info['validate']:
            //     return
            // for child in node.iterchildren(tag=etree.Element):
            //     if child.get('domain') and child.get('select') != 'multi':
            //         msg = _('Searchpanel item with select multi cannot have a domain.')
            //         self._raise_view_error(msg, child)
            */
            return default;
        }

        protected async Task<IrUiView> ValidateTagUlInternalAsync(object node, object name_manager, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _validate_tag_ul(self, node, name_manager, node_info):
            // if node_info['validate']:
            //     # was applied to all nodes, but in practice only used on div and ul
            //     self._check_dropdown_menu(node)
            */
            return default;
        }

        protected async Task<IrUiView> ValidateViewInternalAsync(object node, object model_name, object view_type, object editable, object node_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _validate_view(self, node, model_name, view_type=None, editable=True, node_info=None):
            // """ Validate the given architecture node, and return its corresponding
            // NameManager.
            // 
            // :param self: the view being validated
            // :param node: the combined architecture as an etree
            // :param model_name: the reference model name for the given architecture
            // :param editable: whether the view is considered editable
            // :param full: whether the whole view must be validated
            // :return: the combined architecture's NameManager
            // """
            // self.ensure_one()
            // 
            // view_type = view_type or self.type
            // if node.tag != view_type:
            //     self._raise_view_error(_(
            //         'The root node of a %(view_type)s view should be a <%(view_type)s>, not a <%(tag)s>',
            //         view_type=view_type, tag=node.tag,
            //     ), node)
            // 
            // if model_name not in self.env:
            //     self._raise_view_error(_('Model not found: %(model)s', model=model_name), node)
            // 
            // group_definitions = self.env['res.groups']._get_group_definitions()
            // 
            // # model_groups/view_groups: access groups for the model/view
            // validate = node_info['validate'] if node_info else False
            // model_groups = node_info['model_groups'] if node_info else group_definitions.universe
            // view_groups = node_info['view_groups'] if node_info else group_definitions.universe
            // parent_name_manager = node_info['name_manager'] if node_info else None
            // 
            // # combine model access groups with this model's access groups
            // model_groups &= self.env['ir.model.access']._get_access_groups(model_name)
            // 
            // # fields_get() optimization: validation does not require translations
            // model = self.env[model_name].with_context(lang=None)
            // name_manager = NameManager(model, parent=parent_name_manager, model_groups=model_groups)
            // 
            // view_type = node.tag
            // # use a stack to recursively traverse the tree
            // stack = [(node, view_groups, editable, validate)]
            // while stack:
            //     node, view_groups, editable, validate = stack.pop()
            // 
            //     # compute default
            //     tag = node.tag
            //     validate = validate or node.get('__validate__')
            //     node_info = {
            //         'editable': editable and self._editable_node(node, name_manager),
            //         'validate': validate,
            //         'view_type': view_type,
            //         'model_groups': model_groups,
            //         'view_groups': view_groups,
            //         'name_manager': name_manager,
            //     }
            // 
            //     if groups := node.get('groups'):
            //         for group_name in groups.replace('!', '').split(','):
            //             name_manager.must_exist_group(group_name, node)
            //         node_info['view_groups'] &= group_definitions.parse(groups, raise_if_not_found=False)
            // 
            //     # tag-specific validation
            //     validator = getattr(self, f"_validate_tag_{tag}", None)
            //     if validator is not None:
            //         validator(node, name_manager, node_info)
            // 
            //     if validate:
            //         self._validate_attributes(node, name_manager, node_info)
            // 
            //     for child in reversed(node):
            //         stack.append((child, node_info['view_groups'], node_info['editable'], validate))
            // 
            // name_manager.check(self)
            // 
            // return name_manager
            */
            return default;
        }

        protected async Task<IrUiView> ViewGetInheritedChildrenInternalAsync(object view)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_ui_view.py) ---
            // def _view_get_inherited_children(self, view):
            // if self._context.get('no_primary_children', False):
            //     original_hierarchy = self._context.get('__views_get_original_hierarchy', [])
            //     return view.inherit_children_ids.filtered(lambda extension: extension.mode != 'primary' or extension.id in original_hierarchy)
            // return view.inherit_children_ids
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def _view_get_inherited_children(self, view):
            // extensions = super(View, self)._view_get_inherited_children(view)
            // return extensions.filter_duplicate()
            */
            return default;
        }

        protected async Task<IrUiView> ViewObjInternalAsync(Guid view_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_ui_view.py) ---
            // def _view_obj(self, view_id):
            // if isinstance(view_id, str):
            //     return self.search([('key', '=', view_id)], limit=1) or self.env.ref(view_id)
            // elif isinstance(view_id, int):
            //     return self.browse(view_id)
            // # It can already be a view object when called by '_views_get()' that is calling '_view_obj'
            // # for it's inherit_children_ids, passing them directly as object record.
            // return view_id
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def _view_obj(self, view_id):
            // ''' Given an xml_id or a view_id, return the corresponding view record.
            //     In case of website context, return the most specific one.
            //     :param view_id: either a string xml_id or an integer view_id
            //     :return: The view record or empty recordset
            // '''
            // if isinstance(view_id, str) or isinstance(view_id, int):
            //     return self.env['website'].viewref(view_id)
            // else:
            //     # It can already be a view object when called by '_views_get()' that is calling '_view_obj'
            //     # for it's inherit_children_ids, passing them directly as object record. (Note that it might
            //     # be a view_id from another website but it will be filtered in 'get_related_views()')
            //     return view_id if view_id._name == 'ir.ui.view' else self.env['ir.ui.view']
            */
            return default;
        }

        protected async Task<IrUiView> ViewsGetInternalAsync(Guid view_id, object get_children, object bundles, object root, object visited)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_ui_view.py) ---
            // def _views_get(self, view_id, get_children=True, bundles=False, root=True, visited=None):
            // """ For a given view ``view_id``, should return:
            //         * the view itself (starting from its top most parent)
            //         * all views inheriting from it, enabled or not
            //           - but not the optional children of a non-enabled child
            //         * all views called from it (via t-call)
            //     :returns recordset of ir.ui.view
            // """
            // try:
            //     view = self._view_obj(view_id)
            // except ValueError:
            //     _logger.warning("Could not find view object with view_id '%s'", view_id)
            //     return self.env['ir.ui.view']
            // 
            // if visited is None:
            //     visited = []
            // original_hierarchy = self._context.get('__views_get_original_hierarchy', [])
            // while root and view.inherit_id:
            //     original_hierarchy.append(view.id)
            //     view = view.inherit_id
            // 
            // views_to_return = view
            // 
            // node = etree.fromstring(view.arch)
            // xpath = "//t[@t-call]"
            // if bundles:
            //     xpath += "| //t[@t-call-assets]"
            // for child in node.xpath(xpath):
            //     try:
            //         called_view = self._view_obj(child.get('t-call', child.get('t-call-assets')))
            //     except ValueError:
            //         continue
            //     if called_view and called_view not in views_to_return and called_view.id not in visited:
            //         views_to_return += self._views_get(called_view, get_children=get_children, bundles=bundles, visited=visited + views_to_return.ids)
            // 
            // if not get_children:
            //     return views_to_return
            // 
            // extensions = self._view_get_inherited_children(view)
            // 
            // # Keep children in a deterministic order regardless of their applicability
            // for extension in extensions.sorted(key=lambda v: v.id):
            //     # only return optional grandchildren if this child is enabled
            //     if extension.id not in visited:
            //         for ext_view in self._views_get(extension, get_children=extension.active, root=False, visited=visited + views_to_return.ids):
            //             if ext_view not in views_to_return:
            //                 views_to_return += ext_view
            // return views_to_return
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, IrUiView entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py) ---
            // def write(self, vals):
            // '''COW for ir.ui.view. This way editing websites does not impact other
            // websites. Also this way newly created websites will only
            // contain the default views.
            // '''
            // current_website_id = self.env.context.get('website_id')
            // if not current_website_id or self.env.context.get('no_cow'):
            //     return super(View, self).write(vals)
            // 
            // # We need to consider inactive views when handling multi-website cow
            // # feature (to copy inactive children views, to search for specific
            // # views, ...)
            // # Website-specific views need to be updated first because they might
            // # be relocated to new ids by the cow if they are involved in the
            // # inheritance tree.
            // for view in self.with_context(active_test=False).sorted(key='website_id', reverse=True):
            //     # Make sure views which are written in a website context receive
            //     # a value for their 'key' field
            //     if not view.key and not vals.get('key'):
            //         view.with_context(no_cow=True).key = 'website.key_%s' % str(uuid.uuid4())[:6]
            // 
            //     pages = view.page_ids
            // 
            //     # No need of COW if the view is already specific
            //     if view.website_id:
            //         super(View, view).write(vals)
            //         continue
            // 
            //     # Ensure the cache of the pages stay consistent when doing COW.
            //     # This is necessary when writing view fields from a page record
            //     # because the generic page will put the given values on its cache
            //     # but in reality the values were only meant to go on the specific
            //     # page. Invalidate all fields and not only those in vals because
            //     # other fields could have been changed implicitly too.
            //     pages.flush_recordset()
            //     pages.invalidate_recordset()
            // 
            //     # If already a specific view for this generic view, write on it
            //     website_specific_view = view.search([
            //         ('key', '=', view.key),
            //         ('website_id', '=', current_website_id)
            //     ], limit=1)
            //     if website_specific_view:
            //         super(View, website_specific_view).write(vals)
            //         continue
            // 
            //     # Set key to avoid copy() to generate an unique key as we want the
            //     # specific view to have the same key
            //     copy_vals = {'website_id': current_website_id, 'key': view.key}
            //     # Copy with the 'inherit_id' field value that will be written to
            //     # ensure the copied view's validation works
            //     if vals.get('inherit_id'):
            //         copy_vals['inherit_id'] = vals['inherit_id']
            //     website_specific_view = view.copy(copy_vals)
            // 
            //     view._create_website_specific_pages_for_view(website_specific_view,
            //                                                  view.env['website'].browse(current_website_id))
            // 
            //     for inherit_child in view.inherit_children_ids.filter_duplicate().sorted(key=lambda v: (v.priority, v.id)):
            //         if inherit_child.website_id.id == current_website_id:
            //             # In the case the child was already specific to the current
            //             # website, we cannot just reattach it to the new specific
            //             # parent: we have to copy it there and remove it from the
            //             # original tree. Indeed, the order of children 'id' fields
            //             # must remain the same so that the inheritance is applied
            //             # in the same order in the copied tree.
            //             child = inherit_child.copy({'inherit_id': website_specific_view.id, 'key': inherit_child.key})
            //             inherit_child.inherit_children_ids.write({'inherit_id': child.id})
            //             inherit_child.unlink()
            //         else:
            //             # Trigger COW on inheriting views
            //             inherit_child.write({'inherit_id': website_specific_view.id})
            // 
            //     super(View, website_specific_view).write(vals)
            // 
            // return True
            --- ODOO METHOD SOURCE (MODULE: website, FILE: theme_models.py) ---
            // def write(self, vals):
            // # During a theme module update, theme views' copies receiving an arch
            // # update should not be considered as `arch_updated`, as this is not a
            // # user made change.
            // test_mode = getattr(threading.current_thread(), 'testing', False)
            // if not (test_mode or self.pool._init):
            //     return super().write(vals)
            // no_arch_updated_views = other_views = self.env['ir.ui.view']
            // for record in self:
            //     # Do not mark the view as user updated if original view arch is similar
            //     arch = vals.get('arch', vals.get('arch_base'))
            //     if record.theme_template_id and record.theme_template_id.arch == arch:
            //         no_arch_updated_views += record
            //     else:
            //         other_views += record
            // res = super(IrUiView, other_views).write(vals)
            // if no_arch_updated_views:
            //     vals['arch_updated'] = False
            //     res &= super(IrUiView, no_arch_updated_views).write(vals)
            // return res
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def write(self, vals):
            // # Keep track if view was modified. That will be useful for the --dev mode
            // # to prefer modified arch over file arch.
            // if 'arch_updated' not in vals and ('arch' in vals or 'arch_base' in vals) and 'install_filename' not in self._context:
            //     vals['arch_updated'] = True
            // 
            // # drop the corresponding view customizations (used for dashboards for example), otherwise
            // # not all users would see the updated views
            // custom_view = self.env['ir.ui.view.custom'].sudo().search([('ref_id', 'in', self.ids)])
            // if custom_view:
            //     custom_view.unlink()
            // 
            // self.env.registry.clear_cache('templates')
            // if 'arch_db' in vals and not self.env.context.get('no_save_prev'):
            //     vals['arch_prev'] = self.arch_db
            // 
            // res = super(View, self).write(self._compute_defaults(vals))
            // 
            // # Check the xml of the view if it gets re-activated.
            // # Ideally, `active` shoud have been added to the `api.constrains` of `_check_xml`,
            // # but the ORM writes and validates regular field (such as `active`) before inverse fields (such as `arch`),
            // # and therefore when writing `active` and `arch` at the same time, `_check_xml` is called twice,
            // # and the first time it tries to validate the view without the modification to the arch,
            // # which is problematic if the user corrects the view at the same time he re-enables it.
            // if vals.get('active'):
            //     # Call `_validate_fields` instead of `_check_xml` to have the regular constrains error dialog
            //     # instead of the traceback dialog.
            //     self._validate_fields(['arch_db'])
            // 
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}