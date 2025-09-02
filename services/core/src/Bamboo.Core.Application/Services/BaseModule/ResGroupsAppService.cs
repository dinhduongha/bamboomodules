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
    public class ResGroupsAppService : GenericApplicationService<ResGroups>, IResGroupsAppService
    {
        private readonly IBusListenerMixinAppService _busListenerMixinAppService;
        public ResGroupsAppService(IRepository<ResGroups, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IBusListenerMixinAppService busListenerMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _busListenerMixinAppService = busListenerMixinAppService;
        }

        protected async Task<ResGroups> ActivateGroupAccountSecuredInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_users.py) ---
            // def _activate_group_account_secured(self):
            // group_account_secured = self.env.ref('account.group_account_secured', raise_if_not_found=False)
            // if not group_account_secured:
            //     return
            // groups_with_access = [
            //     'account.group_account_readonly',
            //     'account.group_account_invoice',
            // ]
            // for group_name in groups_with_access:
            //     group = self.env.ref(group_name, raise_if_not_found=False)
            //     if group:
            //         group.sudo()._apply_group(group_account_secured)
            */
            return default;
        }

        protected async Task<ResGroups> ApplyGroupInternalAsync(object implied_group)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _apply_group(self, implied_group):
            // """ Add the given group to the groups implied by the current group
            // :param implied_group: the implied group to add
            // """
            // groups = self.filtered(lambda g: implied_group not in g.implied_ids)
            // groups.write({'implied_ids': [Command.link(implied_group.id)]})
            */
            return default;
        }

        protected async Task<ResGroups> CheckOneUserTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _check_one_user_type(self):
            // self.users._check_one_user_type()
            */
            return default;
        }

        protected async Task<ResGroups> ComputeFullNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _compute_full_name(self):
            // # Important: value must be stored in environment of group, not group1!
            // for group, group1 in zip(self, self.sudo()):
            //     if group1.category_id:
            //         group.full_name = '%s / %s' % (group1.category_id.name, group1.name)
            //     else:
            //         group.full_name = group1.name
            */
            return default;
        }

        protected async Task<ResGroups> ComputeTransImpliedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _compute_trans_implied(self):
            // # Compute the transitive closure recursively. Note that the performance
            // # is good, because the record cache behaves as a memo (the field is
            // # never computed twice on a given group.)
            // for g in self:
            //     g.trans_implied_ids = g.implied_ids | g.implied_ids.trans_implied_ids
            */
            return default;
        }

        public async Task<ResGroups> CopyDataAsync(Guid id, ResGroupsCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // for group, vals in zip(self, vals_list):
            //     vals['name'] = default.get('name') or _('%s (copy)', group.name)
            // return vals_list
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<ResGroups> CreateAsync(ResGroups entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def create(self, vals_list):
            // user_ids_list = [vals.pop('users', None) for vals in vals_list]
            // groups = super(GroupsImplied, self).create(vals_list)
            // for group, user_ids in zip(groups, user_ids_list):
            //     if user_ids:
            //         # delegate addition of users to add implied groups
            //         group.write({'users': user_ids})
            // self.env.registry.clear_cache('groups')
            // return groups
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def create(self, vals_list):
            // groups = super().create(vals_list)
            // self._update_user_groups_view()
            // # actions.get_bindings() depends on action records
            // self.env.registry.clear_cache()
            // return groups
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<ResGroups> EnsureXmlIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _ensure_xml_id(self):
            // """Return the groups external identifiers, creating the external identifier for groups missing one"""
            // result = self.get_external_id()
            // missings = {group_id: f'__custom__.group_{group_id}' for group_id, ext_id in result.items() if not ext_id}
            // if missings:
            //     self.env['ir.model.data'].sudo().create(
            //         [
            //             {
            //                 'name': name.split('.')[1],
            //                 'model': 'res.groups',
            //                 'res_id': group_id,
            //                 'module': name.split('.')[0],
            //             }
            //             for group_id, name in missings.items()
            //         ]
            //     )
            //     result.update(missings)
            // 
            // return result
            */
            return default;
        }

        public async Task<ResGroups> GetApplicationGroupsAsync(Guid id, ResGroupsGetApplicationGroupsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_users.py) ---
            // def get_application_groups(self, domain):
            // # Overridden in order to remove 'Show Full Accounting Features' and
            // # 'Show Full Accounting Features - Readonly' in the 'res.users' form view to prevent confusion
            // group_account_user = self.env.ref('account.group_account_user', raise_if_not_found=False)
            // if group_account_user and group_account_user.category_id.xml_id == 'base.module_category_hidden':
            //     domain += [('id', '!=', group_account_user.id)]
            // group_account_readonly = self.env.ref('account.group_account_readonly', raise_if_not_found=False)
            // if group_account_readonly and group_account_readonly.category_id.xml_id == 'base.module_category_hidden':
            //     domain += [('id', '!=', group_account_readonly.id)]
            // group_account_basic = self.env.ref('account.group_account_basic', raise_if_not_found=False)
            // if group_account_basic and group_account_basic.category_id.xml_id == 'base.module_category_hidden':
            //     domain += [('id', '!=', group_account_basic.id)]
            // return super().get_application_groups(domain)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def get_application_groups(self, domain):
            // """ Return the non-share groups that satisfy ``domain``. """
            // return self.search(domain + [('share', '=', False)])
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResGroups> GetGroupDefinitionsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _get_group_definitions(self):
            // """ Return the definition of all the groups as a :class:`~odoo.tools.SetDefinitions`. """
            // groups = self.sudo().search([], order='id')
            // id_to_ref = groups.get_external_id()
            // 
            // # The 'base.group_no_one' is not actually involved by any other group because it is session dependent.
            // group_no_one_id = {gid for gid, ref in id_to_ref.items() if ref == 'base.group_no_one'}
            // 
            // data = {
            //     group.id: {
            //         'ref': id_to_ref[group.id] or str(group.id),
            //         'supersets': set(group.implied_ids.ids) - group_no_one_id,
            //     }
            //     for group in groups
            // }
            // 
            // # determine exclusive groups (will be disjoint for the set expression)
            // user_types_category_id = self.env['ir.model.data']._xmlid_to_res_id('base.module_category_user_type', raise_if_not_found=False)
            // if user_types_category_id:
            //     user_type_ids = self.sudo().search([('category_id', '=', user_types_category_id)]).ids
            //     for user_type_id in user_type_ids:
            //         data[user_type_id]['disjoints'] = set(user_type_ids) - {user_type_id}
            // 
            // return SetDefinitions(data)
            */
            return default;
        }

        public async Task<ResGroups> GetGroupsByApplicationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def get_groups_by_application(self):
            // """ Return all groups classified by application (module category), as a list::
            // 
            //         [(app, kind, groups), ...],
            // 
            //     where ``app`` and ``groups`` are recordsets, and ``kind`` is either
            //     ``'boolean'`` or ``'selection'``. Applications are given in sequence
            //     order.  If ``kind`` is ``'selection'``, ``groups`` are given in
            //     reverse implication order.
            // """
            // def linearize(app, gs, category_name):
            //     # 'User Type' is an exception
            //     if app.xml_id == 'base.module_category_user_type':
            //         return (app, 'selection', gs.sorted('id'), category_name)
            //     # determine sequence order: a group appears after its implied groups
            //     order = {g: len(g.trans_implied_ids & gs) for g in gs}
            //     # We want a selection for Accounting too. Auditor and Invoice are both
            //     # children of Accountant, but the two of them make a full accountant
            //     # so it makes no sense to have checkboxes.
            //     if app.xml_id == 'base.module_category_accounting_accounting':
            //         return (app, 'selection', gs.sorted(key=order.get), category_name)
            //     # check whether order is total, i.e., sequence orders are distinct
            //     if len(set(order.values())) == len(gs):
            //         return (app, 'selection', gs.sorted(key=order.get), category_name)
            //     else:
            //         return (app, 'boolean', gs, (100, 'Other'))
            // 
            // # classify all groups by application
            // by_app, others = defaultdict(self.browse), self.browse()
            // for g in self.get_application_groups([]):
            //     if g.category_id:
            //         by_app[g.category_id] += g
            //     else:
            //         others += g
            // # build the result
            // res = []
            // for app, gs in sorted(by_app.items(), key=lambda it: it[0].sequence or 0):
            //     if app.parent_id:
            //         res.append(linearize(app, gs, (app.parent_id.sequence, app.parent_id.name)))
            //     else:
            //         res.append(linearize(app, gs, (100, 'Other')))
            // 
            // if others:
            //     res.append((self.env['ir.module.category'], 'boolean', others, (100,'Other')))
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResGroups> GetHiddenExtraCategoriesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _get_hidden_extra_categories(self):
            // return ['base.module_category_hidden', 'base.module_category_extra', 'base.module_category_usability']
            */
            return default;
        }

        protected async Task<ResGroups> RemoveGroupInternalAsync(object implied_group)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _remove_group(self, implied_group):
            // """ Remove the given group from the implied groups of the current group
            // :param implied_group: the implied group to remove
            // """
            // groups = self.filtered(lambda g: implied_group in g.implied_ids)
            // if groups:
            //     groups.write({'implied_ids': [Command.unlink(implied_group.id)]})
            //     # if user belongs to implied_group thanks to another group, don't remove him
            //     # this avoids readding the template user and triggering the mechanism at 121cd0d6084cb28
            //     users_to_unlink = [
            //         user
            //         for user in groups.with_context(active_test=False).users
            //         if implied_group not in (user.groups_id - implied_group).trans_implied_ids
            //     ]
            //     if users_to_unlink:
            //         # do not remove inactive users (e.g. default)
            //         implied_group.with_context(active_test=False).write(
            //             {'users': [Command.unlink(user.id) for user in users_to_unlink]})
            */
            return default;
        }

        protected async Task<ResGroups> SearchFullNameInternalAsync(object @operator, object operand)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _search_full_name(self, operator, operand):
            // lst = True
            // if isinstance(operand, bool):
            //     return [('name', operator, operand)]
            // if isinstance(operand, str):
            //     lst = False
            //     operand = [operand]
            // where_domains = []
            // for group in operand:
            //     values = [v for v in group.split('/') if v]
            //     group_name = values.pop().strip() if values else ''
            //     category_name = values and '/'.join(values).strip() or group_name
            //     group_domain = [('name', operator, lst and [group_name] or group_name)]
            //     category_ids = self.env['ir.module.category'].sudo()._search(
            //         [('name', operator, [category_name] if lst else category_name)])
            //     category_domain = [('category_id', 'in', category_ids)]
            //     if operator in expression.NEGATIVE_TERM_OPERATORS and not values:
            //         category_domain = expression.OR([category_domain, [('category_id', '=', False)]])
            //     if (operator in expression.NEGATIVE_TERM_OPERATORS) == (not values):
            //         where = expression.AND([group_domain, category_domain])
            //     else:
            //         where = expression.OR([group_domain, category_domain])
            //     where_domains.append(where)
            // if operator in expression.NEGATIVE_TERM_OPERATORS:
            //     return expression.AND(where_domains)
            // else:
            //     return expression.OR(where_domains)
            */
            return default;
        }

        protected async Task<ResGroups> SearchInternalAsync(object domain, object offset, object limit, object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _search(self, domain, offset=0, limit=None, order=None):
            // # add explicit ordering if search is sorted on full_name
            // if order and order.startswith('full_name'):
            //     groups = super().search(domain)
            //     groups = groups.sorted('full_name', reverse=order.endswith('DESC'))
            //     groups = groups[offset:offset+limit] if limit else groups[offset:]
            //     return groups._as_query(order)
            // return super()._search(domain, offset, limit, order)
            */
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def unlink(self):
            // res = super().unlink()
            // self.env.registry.clear_cache('groups')
            // return res
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def unlink(self):
            // res = super(GroupsView, self).unlink()
            // self._update_user_groups_view()
            // # actions.get_bindings() depends on action records
            // self.env.registry.clear_cache()
            // return res
            */
            return await base.UnlinkAsync(ids);
        }

        protected async Task<ResGroups> UnlinkExceptSettingsGroupInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _unlink_except_settings_group(self):
            // classified = self.env['res.config.settings']._get_classified_fields()
            // for _name, _groups, implied_group in classified['group']:
            //     if implied_group.id in self.ids:
            //         raise ValidationError(_('You cannot delete a group linked with a settings field.'))
            */
            return default;
        }

        protected async Task<ResGroups> UpdateUserGroupsViewInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _update_user_groups_view(self):
            // """ Modify the view with xmlid ``base.user_groups_view``, which inherits
            //     the user form view, and introduces the reified group fields.
            // """
            // # remove the language to avoid translations, it will be handled at the view level
            // self = self.with_context(lang=None)
            // 
            // # We have to try-catch this, because at first init the view does not
            // # exist but we are already creating some basic groups.
            // view = self.env.ref('base.user_groups_view', raise_if_not_found=False)
            // if not (view and view._name == 'ir.ui.view'):
            //     return
            // 
            // if self._context.get('install_filename') or self._context.get(MODULE_UNINSTALL_FLAG):
            //     # use a dummy view during install/upgrade/uninstall
            //     xml = E.field(name="groups_id", position="after")
            // 
            // else:
            //     group_no_one = view.env.ref('base.group_no_one')
            //     group_employee = view.env.ref('base.group_user')
            //     xml0, xml1, xml2, xml3, xml4 = [], [], [], [], []
            //     xml_by_category = {}
            //     xml1.append(E.separator(string='User Type', colspan="2", groups='base.group_no_one'))
            // 
            //     user_type_field_name = ''
            //     user_type_readonly = str({})
            //     sorted_tuples = sorted(self.get_groups_by_application(),
            //                            key=lambda t: t[0].xml_id != 'base.module_category_user_type')
            // 
            //     invisible_information = "All fields linked to groups must be present in the view due to the overwrite of create and write. The implied groups are calculated using this values."
            // 
            //     for app, kind, gs, category_name in sorted_tuples:  # we process the user type first
            //         attrs = {}
            //         # hide groups in categories 'Hidden' and 'Extra' (except for group_no_one)
            //         if app.xml_id in self._get_hidden_extra_categories():
            //             attrs['groups'] = 'base.group_no_one'
            // 
            //         # User type (employee, portal or public) is a separated group. This is the only 'selection'
            //         # group of res.groups without implied groups (with each other).
            //         if app.xml_id == 'base.module_category_user_type':
            //             # application name with a selection field
            //             field_name = name_selection_groups(gs.ids)
            //             # test_reified_groups, put the user category type in invisible
            //             # as it's used in domain of attrs of other fields,
            //             # and the normal user category type field node is wrapped in a `groups="base.no_one"`,
            //             # and is therefore removed when not in debug mode.
            //             xml0.append(E.field(name=field_name, invisible="True", on_change="1"))
            //             xml0.append(etree.Comment(invisible_information))
            //             user_type_field_name = field_name
            //             user_type_readonly = f'{user_type_field_name} != {group_employee.id}'
            //             attrs['widget'] = 'radio'
            //             # Trigger the on_change of this "virtual field"
            //             attrs['on_change'] = '1'
            //             xml1.append(E.field(name=field_name, **attrs))
            //             xml1.append(E.newline())
            // 
            //         elif kind == 'selection':
            //             # application name with a selection field
            //             field_name = name_selection_groups(gs.ids)
            //             attrs['readonly'] = user_type_readonly
            //             attrs['on_change'] = '1'
            //             if category_name not in xml_by_category:
            //                 xml_by_category[category_name] = []
            //                 xml_by_category[category_name].append(E.newline())
            //             xml_by_category[category_name].append(E.field(name=field_name, **attrs))
            //             xml_by_category[category_name].append(E.newline())
            //             # add duplicate invisible field so default values are saved on create
            //             if attrs.get('groups') == 'base.group_no_one':
            //                 xml0.append(E.field(name=field_name, **dict(attrs, invisible="True", groups='!base.group_no_one')))
            //                 xml0.append(etree.Comment(invisible_information))
            // 
            //         else:
            //             # application separator with boolean fields
            //             app_name = app.name or 'Other'
            //             xml4.append(E.separator(string=app_name, **attrs))
            //             left_group, right_group = [], []
            //             attrs['readonly'] = user_type_readonly
            //             # we can't use enumerate, as we sometime skip groups
            //             group_count = 0
            //             for g in gs:
            //                 field_name = name_boolean_group(g.id)
            //                 dest_group = left_group if group_count % 2 == 0 else right_group
            //                 if g == group_no_one:
            //                     # make the group_no_one invisible in the form view
            //                     dest_group.append(E.field(name=field_name, invisible="True", **attrs))
            //                     dest_group.append(etree.Comment(invisible_information))
            //                 else:
            //                     dest_group.append(E.field(name=field_name, **attrs))
            //                 # add duplicate invisible field so default values are saved on create
            //                 xml0.append(E.field(name=field_name, **dict(attrs, invisible="True", groups='!base.group_no_one')))
            //                 xml0.append(etree.Comment(invisible_information))
            //                 group_count += 1
            //             xml4.append(E.group(*left_group))
            //             xml4.append(E.group(*right_group))
            // 
            //     xml4.append({'class': "o_label_nowrap"})
            //     user_type_invisible = f'{user_type_field_name} != {group_employee.id}' if user_type_field_name else ''
            // 
            //     for xml_cat in sorted(xml_by_category.keys(), key=lambda it: it[0]):
            //         master_category_name = xml_cat[1]
            //         xml3.append(E.group(*(xml_by_category[xml_cat]), string=master_category_name))
            // 
            //     field_name = 'user_group_warning'
            //     user_group_warning_xml = E.div({
            //         'class': "alert alert-warning",
            //         'role': "alert",
            //         'colspan': "2",
            //         'invisible': f'not {field_name}',
            //     })
            //     user_group_warning_xml.append(E.label({
            //         'for': field_name,
            //         'string': "Access Rights Mismatch",
            //         'class': "text text-warning fw-bold",
            //     }))
            //     user_group_warning_xml.append(E.field(name=field_name))
            //     xml2.append(user_group_warning_xml)
            // 
            //     xml = E.field(
            //         *(xml0),
            //         E.group(*(xml1), groups="base.group_no_one"),
            //         E.group(*(xml2), invisible=user_type_invisible),
            //         E.group(*(xml3), invisible=user_type_invisible),
            //         E.group(*(xml4), invisible=user_type_invisible, groups="base.group_no_one"), name="groups_id", position="replace")
            //     xml.addprevious(etree.Comment("GENERATED AUTOMATICALLY BY GROUPS"))
            // 
            // # serialize and update the view
            // xml_content = etree.tostring(xml, pretty_print=True, encoding="unicode")
            // if xml_content != view.arch:  # avoid useless xml validation if no change
            //     new_context = dict(view._context)
            //     new_context.pop('install_filename', None)  # don't set arch_fs for this computed view
            //     new_context['lang'] = None
            //     view.with_context(new_context).write({'arch': xml_content})
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, ResGroups entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_groups.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // if vals.get("users"):
            //     self.env["discuss.channel"].search([("group_ids", "in", self._ids)])._subscribe_users_automatically()
            // return res
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: res_groups.py) ---
            // def write(self, vals):
            // """ Automatically subscribe new users to linked slide channels """
            // write_res = super(UserGroup, self).write(vals)
            // if vals.get('users'):
            //     # TDE FIXME: maybe directly check users and subscribe them
            //     self.env['slide.channel'].sudo().search([('enroll_group_ids', 'in', self._ids)])._add_groups_members()
            // return write_res
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def write(self, vals):
            // if 'name' in vals:
            //     if vals['name'].startswith('-'):
            //         raise UserError(_('The name of the group can not start with "-"'))
            // # invalidate caches before updating groups, since the recomputation of
            // # field 'share' depends on method has_group()
            // # DLE P139
            // if self.ids:
            //     self.env['ir.model.access'].call_cache_clearing_methods()
            // return super(Groups, self).write(vals)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def write(self, values):
            // res = super(GroupsImplied, self).write(values)
            // if values.get('users') or values.get('implied_ids'):
            //     # add all implied groups (to all users of each group)
            //     updated_group_ids = OrderedSet()
            //     updated_user_ids = OrderedSet()
            //     for group in self:
            //         self._cr.execute("""
            //             WITH RECURSIVE group_imply(gid, hid) AS (
            //                 SELECT gid, hid
            //                   FROM res_groups_implied_rel
            //                  UNION
            //                 SELECT i.gid, r.hid
            //                   FROM res_groups_implied_rel r
            //                   JOIN group_imply i ON (i.hid = r.gid)
            //             )
            //             INSERT INTO res_groups_users_rel (gid, uid)
            //                  SELECT i.hid, r.uid
            //                    FROM group_imply i, res_groups_users_rel r
            //                   WHERE r.gid = i.gid
            //                     AND i.gid = %(gid)s
            //                  EXCEPT
            //                  SELECT r.gid, r.uid
            //                    FROM res_groups_users_rel r
            //                    JOIN group_imply i ON (r.gid = i.hid)
            //                   WHERE i.gid = %(gid)s
            //             RETURNING gid, uid
            //         """, dict(gid=group.id))
            //         updated = self.env.cr.fetchall()
            //         gids, uids = zip(*updated) if updated else ([], [])
            //         updated_group_ids.update(gids)
            //         updated_user_ids.update(uids)
            //     # notify the ORM about the updated users and groups
            //     updated_groups = self.env['res.groups'].browse(updated_group_ids)
            //     updated_groups.invalidate_recordset(['users'])
            //     updated_groups.modified(['users'])
            //     updated_users = self.env['res.users'].browse(updated_user_ids)
            //     updated_users.invalidate_recordset(['groups_id'])
            //     updated_users.modified(['groups_id'])
            //     # explicitly check constraints
            //     updated_groups._validate_fields(['users'])
            //     updated_users._validate_fields(['groups_id'])
            //     self._check_one_user_type()
            // if 'implied_ids' in values:
            //     self.env.registry.clear_cache('groups')
            // return res
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def write(self, values):
            // # determine which values the "user groups view" depends on
            // VIEW_DEPS = ('category_id', 'implied_ids')
            // view_values0 = [g[name] for name in VIEW_DEPS if name in values for g in self]
            // res = super(GroupsView, self).write(values)
            // # update the "user groups view" only if necessary
            // view_values1 = [g[name] for name in VIEW_DEPS if name in values for g in self]
            // if view_values0 != view_values1:
            //     self._update_user_groups_view()
            // # actions.get_bindings() depends on action records
            // self.env.registry.clear_cache()
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}