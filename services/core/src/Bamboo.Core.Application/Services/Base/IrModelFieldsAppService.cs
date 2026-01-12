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
    public class IrModelFieldsAppService : GenericApplicationService<IrModelFields>, IIrModelFieldsAppService
    {

        public IrModelFieldsAppService(IRepository<IrModelFields, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<IrModelFields> AllManualFieldDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _all_manual_field_data(self):
            // cr = self.env.cr
            // # we cannot use self._fields to determine translated fields, as it has not been set up yet
            // cr.execute("""
            //     SELECT *, field_description->>'en_US' AS field_description, help->>'en_US' AS help
            //     FROM ir_model_fields
            //     WHERE state = 'manual'
            // """)
            // result = defaultdict(dict)
            // for row in cr.dictfetchall():
            //     result[row['model']][row['name']] = row
            // return result
            */
            return default;
        }

        protected async Task<IrModelFields> CheckCurrencyFieldInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _check_currency_field(self):
            // for rec in self:
            //     if rec.state == 'manual' and rec.ttype == 'monetary':
            //         if not rec.currency_field:
            //             currency_field = self._get(rec.model, 'currency_id') or self._get(rec.model, 'x_currency_id')
            //             if not currency_field:
            //                 raise ValidationError(_("Currency field is empty and there is no fallback field in the model"))
            //         else:
            //             currency_field = self._get(rec.model, rec.currency_field)
            //             if not currency_field:
            //                 raise ValidationError(_("Unknown field specified “%s” in currency_field", rec.currency_field))
            // 
            //         if currency_field.ttype != 'many2one':
            //             raise ValidationError(_("Currency field does not have type many2one"))
            //         if currency_field.relation != 'res.currency':
            //             raise ValidationError(_("Currency field should have a res.currency relation"))
            */
            return default;
        }

        protected async Task<IrModelFields> CheckDependsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _check_depends(self):
            // """ Check whether all fields in dependencies are valid. """
            // for record in self:
            //     if not record.depends:
            //         continue
            //     for seq in record.depends.split(","):
            //         if not seq.strip():
            //             raise UserError(_("Empty dependency in “%s”", record.depends))
            //         model = self.env[record.model]
            //         names = seq.strip().split(".")
            //         last = len(names) - 1
            //         for index, name in enumerate(names):
            //             if name == 'id':
            //                 raise UserError(_("Compute method cannot depend on field 'id'"))
            //             field = model._fields.get(name)
            //             if field is None:
            //                 raise UserError(_(
            //                     'Unknown field “%(field)s” in dependency “%(dependency)s”',
            //                     field=name,
            //                     dependency=seq.strip(),
            //                 ))
            //             if index < last and not field.relational:
            //                 raise UserError(_(
            //                     'Non-relational field “%(field)s” in dependency “%(dependency)s”',
            //                     field=name,
            //                     dependency=seq.strip(),
            //                 ))
            //             model = model[name]
            */
            return default;
        }

        protected async Task<IrModelFields> CheckDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _check_domain(self):
            // for field in self:
            //     try:
            //         safe_eval(field.domain or '[]')
            //     except ValueError as e:
            //         raise ValidationError(
            //             _("An error occurred while evaluating the domain:\n%(error)s", error=e)
            //         ) from e
            */
            return default;
        }

        protected async Task<IrModelFields> CheckIfUsedInWebsiteFormInternalAsync()
        {
            #if PYTHON_CODE
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_form.py) ---
            // def _check_if_used_in_website_form(self):
            // """Prevent field deletion if used in a website form."""
            // for field in self:
            //     for model_name, field_name in self.env['website']._get_html_fields():
            //         domain = [(field_name, 'ilike', f'data-model_name="{field.model}"')]
            //         records = self.env[model_name].with_context(active_test=False).search(domain)
            //         for record in records:
            //             arch_parsed = etree.fromstring(record[field_name])
            //             xpath_selector = f'//form[@data-model_name="{field.model}"]//*[@name="{field.name}"]'
            //             if arch_parsed.xpath(xpath_selector):
            //                 raise ValidationError(_(
            //                     "The field '%(field)s' cannot be deleted because it is referenced in a website view.\n"
            //                     "Model: %(model)s\n"
            //                     "View: %(view)s",
            //                     field=field.name,
            //                     model=field.model,
            //                     view=record.display_name,
            //                 ))
            #endif
            return default;
        }

        protected async Task<IrModelFields> CheckNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _check_name(self):
            // for field in self:
            //     try:
            //         models.check_pg_name(field.name)
            //     except ValidationError:
            //         msg = _("Field names can only contain characters, digits and underscores (up to 63).")
            //         raise ValidationError(msg)
            */
            return default;
        }

        protected async Task<IrModelFields> CheckOnDeleteRequiredM2oInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _check_on_delete_required_m2o(self):
            // for rec in self:
            //     if rec.ttype == 'many2one' and rec.required and rec.on_delete == 'set null':
            //         raise ValidationError(_(
            //             "The m2o field %s is required but declares its ondelete policy "
            //             "as being 'set null'. Only 'restrict' and 'cascade' make sense.", rec.name,
            //         ))
            */
            return default;
        }

        protected async Task<IrModelFields> CheckRelatedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _check_related(self):
            // for rec in self:
            //     if rec.state == 'manual' and rec.related:
            //         field = rec._related_field()
            //         if field.ttype != rec.ttype:
            //             raise ValidationError(_(
            //                 'Related field "%(related_field)s" does not have type "%(type)s"',
            //                 related_field=rec.related,
            //                 type=rec.ttype,
            //             ))
            //         if field.relation != rec.relation:
            //             raise ValidationError(_(
            //                 'Related field "%(related_field)s" does not have comodel "%(comodel)s"',
            //                 related_field=rec.related,
            //                 comodel=rec.relation,
            //             ))
            */
            return default;
        }

        protected async Task<IrModelFields> CheckRelationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _check_relation(self):
            // for rec in self:
            //     if rec.state == 'manual' and rec.relation and not rec.env['ir.model']._get_id(rec.relation):
            //         raise ValidationError(_("Unknown model name '%s' in Related Model", rec.relation))
            */
            return default;
        }

        protected async Task<IrModelFields> CheckRelationTableInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _check_relation_table(self):
            // for rec in self:
            //     if rec.relation_table:
            //         models.check_pg_name(rec.relation_table)
            */
            return default;
        }

        protected async Task<IrModelFields> ComputeCopiedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _compute_copied(self):
            // for rec in self:
            //     rec.copied = (rec.ttype != 'one2many') and not (rec.related or rec.compute)
            */
            return default;
        }

        protected async Task<IrModelFields> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _compute_display_name(self):
            // IrModel = self.env["ir.model"]
            // for field in self:
            //     if self.env.context.get('hide_model'):
            //         field.display_name = field.field_description
            //         continue
            //     model_string = IrModel._get(field.model).name
            //     field.display_name = f'{field.field_description} ({model_string})'
            */
            return default;
        }

        protected async Task<IrModelFields> ComputeRelatedFieldIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _compute_related_field_id(self):
            // for rec in self:
            //     if rec.state == 'manual' and rec.related:
            //         rec.related_field_id = rec._related_field()
            //     else:
            //         rec.related_field_id = False
            */
            return default;
        }

        protected async Task<IrModelFields> ComputeRelationFieldIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _compute_relation_field_id(self):
            // for rec in self:
            //     if rec.state == 'manual' and rec.relation_field:
            //         rec.relation_field_id = self._get(rec.relation, rec.relation_field)
            //     else:
            //         rec.relation_field_id = False
            */
            return default;
        }

        protected async Task<IrModelFields> ComputeSelectionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _compute_selection(self):
            // for rec in self:
            //     if rec.ttype in ('selection', 'reference'):
            //         rec.selection = str(self.env['ir.model.fields.selection']._get_selection(rec.id))
            //     else:
            //         rec.selection = False
            */
            return default;
        }

        protected async Task<IrModelFields> CustomMany2manyNamesInternalAsync(object model_name, object comodel_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _custom_many2many_names(self, model_name, comodel_name):
            // """ Return default names for the table and columns of a custom many2many field. """
            // rel1 = self.env[model_name]._table
            // rel2 = self.env[comodel_name]._table
            // table = 'x_%s_%s_rel' % tuple(sorted([rel1, rel2]))
            // if rel1 == rel2:
            //     return (table, 'id1', 'id2')
            // else:
            //     return (table, '%s_id' % rel1, '%s_id' % rel2)
            */
            return default;
        }

        protected async Task<IrModelFields> DropColumnInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _drop_column(self):
            // from odoo.orm.model_classes import pop_field
            // 
            // tables_to_drop = set()
            // 
            // for field in self:
            //     if field.name in models.MAGIC_COLUMNS:
            //         continue
            //     model = self.env.get(field.model)
            //     is_model = model is not None
            //     if field.store:
            //         # TODO: Refactor this brol in master
            //         if is_model and sql.column_exists(self.env.cr, model._table, field.name) and \
            //                 sql.table_kind(self.env.cr, model._table) == sql.TableKind.Regular:
            //             self.env.cr.execute(SQL('ALTER TABLE %s DROP COLUMN %s CASCADE',
            //                 SQL.identifier(model._table), SQL.identifier(field.name),
            //             ))
            //         if field.state == 'manual' and field.ttype == 'many2many':
            //             rel_name = field.relation_table or (is_model and model._fields[field.name].relation)
            //             tables_to_drop.add(rel_name)
            //     if field.state == 'manual' and is_model:
            //         model_cls = self.env.registry[model._name]
            //         pop_field(model_cls, field.name)
            // 
            // if tables_to_drop:
            //     # drop the relation tables that are not used by other fields
            //     self.env.cr.execute("""SELECT relation_table FROM ir_model_fields
            //                         WHERE relation_table IN %s AND id NOT IN %s""",
            //                      (tuple(tables_to_drop), tuple(self.ids)))
            //     tables_to_keep = {row[0] for row in self.env.cr.fetchall()}
            //     for rel_name in tables_to_drop - tables_to_keep:
            //         self.env.cr.execute(SQL('DROP TABLE %s', SQL.identifier(rel_name)))
            // 
            // return True
            */
            return default;
        }

        public async Task<IrModelFields> FormbuilderWhitelistAsync(Guid id, IrModelFieldsFormbuilderWhitelistRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_form.py) ---
            // def formbuilder_whitelist(self, model, fields):
            // """
            // :param str model: name of the model on which to whitelist fields
            // :param list(str) fields: list of fields to whitelist on the model
            // :return: nothing of import
            // """
            // # postgres does *not* like ``in [EMPTY TUPLE]`` queries
            // if not fields:
            //     return False
            // 
            // # only allow users who can change the website structure
            // if not self.env.user.has_group('website.group_website_designer'):
            //     return False
            // 
            // unexisting_fields = [field for field in fields if field not in self.env[model]._fields.keys()]
            // if unexisting_fields:
            //     raise ValueError("Unable to whitelist field(s) %r for model %r." % (unexisting_fields, model))
            // 
            // # the ORM only allows writing on custom fields and will trigger a
            // # registry reload once that's happened. We want to be able to
            // # whitelist non-custom fields and the registry reload absolutely
            // # isn't desirable, so go with a method and raw SQL
            // self.env.cr.execute(
            //     "UPDATE ir_model_fields"
            //     " SET website_form_blacklisted=false"
            //     " WHERE model=%s AND name in %s", (model, tuple(fields)))
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrModelFields> GetFieldHelpAsync(Guid id, IrModelFieldsGetFieldHelpRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def get_field_help(self, model_name):
            // """ Return the translation of fields help in the context's language.
            // Note that the result contains the available translations only.
            // 
            // :param model_name: the name of a model
            // :return: the model's fields' help as a dictionary `{field_name: field_help}`
            // """
            // return {
            //     field_name: values['help']
            //     for field_name, values in self._get_fields_cached(model_name).items()
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrModelFields> GetFieldSelectionAsync(Guid id, IrModelFieldsGetFieldSelectionRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def get_field_selection(self, model_name, field_name):
            // """ Return the translation of a field's selection in the context's language.
            // Note that the result contains the available translations only.
            // 
            // :param model_name: the name of the field's model
            // :param field_name: the name of the field
            // :return: the fields' selection as a list
            // """
            // return self._get_fields_cached(model_name).get(field_name, {}).get('selection', [])
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrModelFields> GetFieldStringAsync(Guid id, IrModelFieldsGetFieldStringRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def get_field_string(self, model_name):
            // """ Return the translation of fields strings in the context's language.
            // Note that the result contains the available translations only.
            // 
            // :param model_name: the name of a model
            // :return: the model's fields' strings as a dictionary `{field_name: field_string}`
            // """
            // return {
            //     field_name: values['field_description']
            //     for field_name, values in self._get_fields_cached(model_name).items()
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrModelFields> GetFieldsCachedInternalAsync(object model_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _get_fields_cached(self, model_name):
            // """ Return the translated information of all model field's in the context's language.
            // Note that the result contains the available translations only.
            // 
            // :param model_name: the name of the field's model
            // :return: {field_name: {id, help, field_description, [selection]}}
            // """
            // fields = self.sudo().browse(self._get_ids(model_name).values())
            // result = {
            //     field.name: {
            //         'id': field.id,
            //         'help': field.help,
            //         'field_description': field.field_description,
            //     }
            //     for field in fields
            // }
            // for field in fields.filtered(lambda field: field.ttype in ('selection', 'reference')):
            //     result[field.name]['selection'] = [
            //         (sel.value, sel.name) for sel in field.selection_ids
            //     ]
            // return frozendict(result)
            */
            return default;
        }

        protected async Task<IrModelFields> GetIdsInternalAsync(object model_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _get_ids(self, model_name):
            // cr = self.env.cr
            // cr.execute("SELECT name, id FROM ir_model_fields WHERE model=%s", [model_name])
            // return dict(cr.fetchall())
            */
            return default;
        }

        protected async Task<IrModelFields> GetInternalAsync(object model_name, object name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _get(self, model_name, name):
            // """ Return the (sudoed) `ir.model.fields` record with the given model and name.
            // The result may be an empty recordset if the model is not found.
            // """
            // field_id = model_name and name and self._get_ids(model_name).get(name)
            // return self.sudo().browse(field_id)
            */
            return default;
        }

        protected async Task<IrModelFields> GetManualFieldDataInternalAsync(object model_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _get_manual_field_data(self, model_name):
            // """ Return the given model's manual field data. """
            // return self._all_manual_field_data().get(model_name, {})
            */
            return default;
        }

        protected async Task<IrModelFields> InModulesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _in_modules(self):
            // installed_modules = self.env['ir.module.module'].search([('state', '=', 'installed')])
            // installed_names = set(installed_modules.mapped('name'))
            // xml_ids = models.Model._get_external_ids(self)
            // for field in self:
            //     module_names = set(xml_id.split('.')[0] for xml_id in xml_ids[field.id])
            //     field.modules = ", ".join(sorted(installed_names & module_names))
            */
            return default;
        }

        public async Task<IrModelFields> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_form.py) ---
            // def init(self):
            // # set all existing unset website_form_blacklisted fields to ``true``
            // #  (so that we can use it as a whitelist rather than a blacklist)
            // self.env.cr.execute('UPDATE ir_model_fields'
            //                  ' SET website_form_blacklisted=true'
            //                  ' WHERE website_form_blacklisted IS NULL')
            // # add an SQL-level default value on website_form_blacklisted to that
            // # pure-SQL ir.model.field creations (e.g. in _reflect) generate
            // # the right default value for a whitelist (aka fields should be
            // # blacklisted by default)
            // self.env.cr.execute('ALTER TABLE ir_model_fields '
            //                  ' ALTER COLUMN website_form_blacklisted SET DEFAULT true')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrModelFields> InstanciateAttrsInternalAsync(object field_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_sparse_field, FILE: models.py) ---
            // def _instanciate_attrs(self, field_data):
            // attrs = super(IrModelFields, self)._instanciate_attrs(field_data)
            // if attrs and field_data.get('serialization_field_id'):
            //     serialization_record = self.browse(field_data['serialization_field_id'])
            //     attrs['sparse'] = serialization_record.name
            // return attrs
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_model_fields.py) ---
            // def _instanciate_attrs(self, field_data):
            // attrs = super()._instanciate_attrs(field_data)
            // if attrs and field_data.get('tracking'):
            //     attrs['tracking'] = field_data['tracking']
            // return attrs
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _instanciate_attrs(self, field_data):
            // """ Return the parameters for a field instance for ``field_data``. """
            // attrs = {
            //     'manual': True,
            //     'string': field_data['field_description'],
            //     'help': field_data['help'],
            //     'index': bool(field_data['index']),
            //     'copy': bool(field_data['copied']),
            //     'related': field_data['related'],
            //     'required': bool(field_data['required']),
            //     'readonly': bool(field_data['readonly']),
            //     'store': bool(field_data['store']),
            //     'company_dependent': bool(field_data['company_dependent']),
            // }
            // if field_data['ttype'] in ('char', 'text', 'html'):
            //     attrs['translate'] = FIELD_TRANSLATE.get(
            //         field_data['translate'],
            //         True
            //     )
            //     if field_data['ttype'] == 'char':
            //         attrs['size'] = field_data['size'] or None
            //     elif field_data['ttype'] == 'html':
            //         attrs['sanitize'] = field_data['sanitize']
            //         attrs['sanitize_overridable'] = field_data['sanitize_overridable']
            //         attrs['sanitize_tags'] = field_data['sanitize_tags']
            //         attrs['sanitize_attributes'] = field_data['sanitize_attributes']
            //         attrs['sanitize_style'] = field_data['sanitize_style']
            //         attrs['sanitize_form'] = field_data['sanitize_form']
            //         attrs['strip_style'] = field_data['strip_style']
            //         attrs['strip_classes'] = field_data['strip_classes']
            // elif field_data['ttype'] in ('selection', 'reference'):
            //     attrs['selection'] = self.env['ir.model.fields.selection']._get_selection_data(field_data['id'])
            //     if field_data['ttype'] == 'selection':
            //         attrs['group_expand'] = field_data['group_expand']
            // elif field_data['ttype'] == 'many2one':
            //     if not self.pool.loaded and field_data['relation'] not in self.env:
            //         return
            //     attrs['comodel_name'] = field_data['relation']
            //     attrs['ondelete'] = field_data['on_delete']
            //     attrs['domain'] = safe_eval(field_data['domain'] or '[]')
            //     attrs['group_expand'] = '_read_group_expand_full' if field_data['group_expand'] else None
            // elif field_data['ttype'] == 'one2many':
            //     if not self.pool.loaded and not (
            //         field_data['relation'] in self.env and (
            //             field_data['relation_field'] in self.env[field_data['relation']]._fields or
            //             field_data['relation_field'] in self._get_manual_field_data(field_data['relation'])
            //     )):
            //         return
            //     attrs['comodel_name'] = field_data['relation']
            //     attrs['inverse_name'] = field_data['relation_field']
            //     attrs['domain'] = safe_eval(field_data['domain'] or '[]')
            // elif field_data['ttype'] == 'many2many':
            //     if not self.pool.loaded and field_data['relation'] not in self.env:
            //         return
            //     attrs['comodel_name'] = field_data['relation']
            //     rel, col1, col2 = self._custom_many2many_names(field_data['model'], field_data['relation'])
            //     attrs['relation'] = field_data['relation_table'] or rel
            //     attrs['column1'] = field_data['column1'] or col1
            //     attrs['column2'] = field_data['column2'] or col2
            //     attrs['domain'] = safe_eval(field_data['domain'] or '[]')
            // elif field_data['ttype'] == 'monetary':
            //     # be sure that custom monetary field are always instanciated
            //     if not self.pool.loaded and \
            //         field_data['currency_field'] and not self._is_manual_name(field_data['currency_field']):
            //         return
            //     attrs['currency_field'] = field_data['currency_field']
            // # add compute function if given
            // if field_data['compute']:
            //     attrs['compute'] = make_compute(field_data['compute'], field_data['depends'])
            // return attrs
            */
            return default;
        }

        protected async Task<IrModelFields> InverseSelectionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _inverse_selection(self):
            // for rec in self:
            //     selection = literal_eval(rec.selection or "[]")
            //     self.env['ir.model.fields.selection']._update_selection(rec.model, rec.name, selection)
            */
            return default;
        }

        protected async Task<IrModelFields> IsManualNameInternalAsync(object name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _is_manual_name(self, name):
            // return name.startswith('x_')
            */
            return default;
        }

        protected async Task<IrModelFields> OnchangeComputeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _onchange_compute(self):
            // if self.compute:
            //     self.readonly = True
            */
            return default;
        }

        protected async Task<IrModelFields> OnchangeRelatedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _onchange_related(self):
            // if self.related:
            //     try:
            //         field = self._related_field()
            //     except UserError as e:
            //         return {'warning': {'title': _("Warning"), 'message': e}}
            //     self.ttype = field.ttype
            //     self.relation = field.relation
            //     self.readonly = True
            */
            return default;
        }

        protected async Task<IrModelFields> OnchangeRelationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _onchange_relation(self):
            // try:
            //     self._check_relation()
            // except ValidationError as e:
            //     return {'warning': {'title': _("Model %s does not exist", self.relation), 'message': e}}
            */
            return default;
        }

        protected async Task<IrModelFields> OnchangeRelationTableInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _onchange_relation_table(self):
            // if self.relation_table:
            //     # check whether other fields use the same table
            //     others = self.search([('ttype', '=', 'many2many'),
            //                           ('relation_table', '=', self.relation_table),
            //                           ('id', 'not in', self.ids)])
            //     if others:
            //         for other in others:
            //             if (other.model, other.relation) == (self.relation, self.model):
            //                 # other is a candidate inverse field
            //                 self.column1 = other.column2
            //                 self.column2 = other.column1
            //                 return
            //         return {'warning': {
            //             'title': _("Warning"),
            //             'message': _("The table “%s” is used by another, possibly incompatible field(s).", self.relation_table),
            //         }}
            */
            return default;
        }

        protected async Task<IrModelFields> OnchangeTtypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _onchange_ttype(self):
            // if self.ttype == 'many2many' and self.model_id and self.relation:
            //     if self.relation not in self.env:
            //         return
            //     names = self._custom_many2many_names(self.model_id.model, self.relation)
            //     self.relation_table, self.column1, self.column2 = names
            // else:
            //     self.relation_table = False
            //     self.column1 = False
            //     self.column2 = False
            */
            return default;
        }

        protected async Task<IrModelFields> PrepareUpdateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _prepare_update(self):
            // """ Check whether the fields in ``self`` may be modified or removed.
            //     This method prevents the modification/deletion of many2one fields
            //     that have an inverse one2many, for instance.
            // """
            // from odoo.orm.model_classes import pop_field
            // 
            // uninstalling = self.env.context.get(MODULE_UNINSTALL_FLAG)
            // if not uninstalling and any(record.state != 'manual' for record in self):
            //     raise UserError(_("This column contains module data and cannot be removed!"))
            // 
            // records = self              # all the records to delete
            // fields_ = OrderedSet()      # all the fields corresponding to 'records'
            // failed_dependencies = []    # list of broken (field, dependent_field)
            // 
            // for record in self:
            //     model = self.env.get(record.model)
            //     if model is None:
            //         continue
            //     field = model._fields.get(record.name)
            //     if field is None:
            //         continue
            //     fields_.add(field)
            //     for dep in self.pool.get_dependent_fields(field):
            //         if dep.manual:
            //             failed_dependencies.append((field, dep))
            //         elif dep.inherited:
            //             fields_.add(dep)
            //             records |= self._get(dep.model_name, dep.name)
            // 
            // for field in fields_:
            //     for inverse in model.pool.field_inverses[field]:
            //         if inverse.manual and inverse.type == 'one2many':
            //             failed_dependencies.append((field, inverse))
            // 
            // self = records
            // 
            // if failed_dependencies:
            //     if not uninstalling:
            //         field, dep = failed_dependencies[0]
            //         raise UserError(_(
            //             "The field '%(field)s' cannot be removed because the field '%(other_field)s' depends on it.",
            //             field=field, other_field=dep,
            //         ))
            //     else:
            //         self = self.union(*[
            //             self._get(dep.model_name, dep.name)
            //             for field, dep in failed_dependencies
            //         ])
            // 
            // records = self.filtered(lambda record: record.state == 'manual')
            // if not records:
            //     return self
            // 
            // # remove pending write of this field
            // # DLE P16: if there are pending updates of the field we currently try to unlink, pop them out from the cache
            // # test `test_unlink_with_dependant`
            // for record in records:
            //     model = self.env.get(record.model)
            //     field = model and model._fields.get(record.name)
            //     if field:
            //         self.env._field_dirty.pop(field)
            // # remove fields from registry, and check that views are not broken
            // fields = [pop_field(self.env.registry[record.model], record.name) for record in records]
            // domain = Domain.OR([('arch_db', 'like', record.name)] for record in records)
            // views = self.env['ir.ui.view'].search(domain)
            // try:
            //     for view in views:
            //         view._check_xml()
            // except Exception:
            //     if not uninstalling:
            //         raise UserError(_(
            //             "Cannot rename/delete fields that are still present in views:\nFields: %(fields)s\nView: %(view)s",
            //             fields=fields,
            //             view=view.name,
            //         ))
            //     else:
            //         # uninstall mode
            //         _logger.warning(
            //             "The following fields were force-deleted to prevent a registry crash %s the following view might be broken %s",
            //             ", ".join(str(f) for f in fields),
            //             view.name)
            // finally:
            //     if not uninstalling:
            //         # the registry has been modified, restore it
            //         self.pool._setup_models__(self.env.cr)
            // 
            // return self
            */
            return default;
        }

        protected async Task<IrModelFields> ReflectFieldParamsInternalAsync(object field, Guid model_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_model_fields.py) ---
            // def _reflect_field_params(self, field, model_id):
            // """ Tracking value can be either a boolean enabling tracking mechanism
            // on field, either an integer giving the sequence. Default sequence is
            // set to 100. """
            // vals = super()._reflect_field_params(field, model_id)
            // tracking = getattr(field, 'tracking', None)
            // if tracking is True:
            //     tracking = 100
            // elif tracking is False:
            //     tracking = None
            // vals['tracking'] = tracking
            // return vals
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _reflect_field_params(self, field, model_id):
            // """ Return the values to write to the database for the given field. """
            // translate = next(k for k, v in FIELD_TRANSLATE.items() if v == field.translate)
            // return {
            //     'model_id': model_id,
            //     'model': field.model_name,
            //     'name': field.name,
            //     'field_description': field.string,
            //     'help': field.help or None,
            //     'ttype': field.type,
            //     'state': 'manual' if field.manual else 'base',
            //     'relation': field.comodel_name or None,
            //     'index': bool(field.index),
            //     'store': bool(field.store),
            //     'copied': bool(field.copy),
            //     'on_delete': field.ondelete if field.type == 'many2one' else None,
            //     'related': field.related or None,
            //     'readonly': bool(field.readonly),
            //     'required': bool(field.required),
            //     'selectable': bool(field.search or field.store),
            //     'size': getattr(field, 'size', None),
            //     'translate': translate,
            //     'company_dependent': bool(field.company_dependent),
            //     'relation_field': field.inverse_name if field.type == 'one2many' else None,
            //     'relation_table': field.relation if field.type == 'many2many' else None,
            //     'column1': field.column1 if field.type == 'many2many' else None,
            //     'column2': field.column2 if field.type == 'many2many' else None,
            //     'currency_field': field.currency_field if field.type == 'monetary' else None,
            //     # html sanitization attributes (useless for other fields)
            //     'sanitize': field.sanitize if field.type == 'html' else None,
            //     'sanitize_overridable': field.sanitize_overridable if field.type == 'html' else None,
            //     'sanitize_tags': field.sanitize_tags if field.type == 'html' else None,
            //     'sanitize_attributes': field.sanitize_attributes if field.type == 'html' else None,
            //     'sanitize_style': field.sanitize_style if field.type == 'html' else None,
            //     'sanitize_form': field.sanitize_form if field.type == 'html' else None,
            //     'strip_style': field.strip_style if field.type == 'html' else None,
            //     'strip_classes': field.strip_classes if field.type == 'html' else None,
            // }
            */
            return default;
        }

        protected async Task<IrModelFields> ReflectFieldsInternalAsync(object model_names)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_sparse_field, FILE: models.py) ---
            // def _reflect_fields(self, model_names):
            // super()._reflect_fields(model_names)
            // 
            // # set 'serialization_field_id' on sparse fields; it is done here to
            // # ensure that the serialized field is reflected already
            // cr = self.env.cr
            // 
            // # retrieve existing values
            // query = """
            //     SELECT model, name, id, serialization_field_id
            //     FROM ir_model_fields
            //     WHERE model IN %s
            // """
            // cr.execute(query, [tuple(model_names)])
            // existing = {row[:2]: row[2:] for row in cr.fetchall()}
            // 
            // # determine updates, grouped by value
            // updates = defaultdict(list)
            // for model_name in model_names:
            //     for field_name, field in self.env[model_name]._fields.items():
            //         field_id, current_value = existing[(model_name, field_name)]
            //         try:
            //             value = existing[(model_name, field.sparse)][0] if field.sparse else None
            //         except KeyError:
            //             raise UserError(_(
            //                 'Serialization field "%(serialization_field)s" not found for sparse field %(sparse_field)s!',
            //                 serialization_field=field.sparse,
            //                 sparse_field=field,
            //             ))
            //         if current_value != value:
            //             updates[value].append(field_id)
            // 
            // if not updates:
            //     return
            // 
            // # update fields
            // query = "UPDATE ir_model_fields SET serialization_field_id=%s WHERE id IN %s"
            // for value, ids in updates.items():
            //     cr.execute(query, [value, tuple(ids)])
            // 
            // records = self.browse(id_ for ids in updates.values() for id_ in ids)
            // self.pool.post_init(records.modified, ['serialization_field_id'])
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _reflect_fields(self, model_names):
            // """ Reflect the fields of the given models. """
            // cr = self.env.cr
            // 
            // for model_name in model_names:
            //     model = self.env[model_name]
            //     by_label = {}
            //     for field in model._fields.values():
            //         if field.string in by_label:
            //             other = by_label[field.string]
            //             _logger.warning('Two fields (%s, %s) of %s have the same label: %s. [Modules: %s and %s]',
            //                             field.name, other.name, model, field.string, field._module, other._module)
            //         else:
            //             by_label[field.string] = field
            // 
            // # determine expected and existing rows
            // rows = []
            // for model_name in model_names:
            //     model_id = self.env['ir.model']._get_id(model_name)
            //     for field in self.env[model_name]._fields.values():
            //         rows.append(self._reflect_field_params(field, model_id))
            // if not rows:
            //     return
            // cols = list(unique(['model', 'name'] + list(rows[0])))
            // expected = [tuple(row[col] for col in cols) for row in rows]
            // 
            // field_ids = {}
            // existing = {}
            // for row in select_en(self, ['id'] + cols, model_names):
            //     field_ids[row[1:3]] = row[0]
            //     existing[row[1:3]] = row[1:]
            // 
            // # create or update rows
            // rows = [row for row in expected if existing.get(row[:2]) != row]
            // if rows:
            //     ids = upsert_en(self, cols, rows, ['model', 'name'])
            //     for row, id_ in zip(rows, ids):
            //         field_ids[row[:2]] = id_
            //     self.pool.post_init(mark_modified, self.browse(ids), cols[2:])
            // 
            // # update their XML id
            // module = self.env.context.get('module')
            // if not module:
            //     return
            // 
            // data_list = []
            // for (field_model, field_name), field_id in field_ids.items():
            //     model = self.env[field_model]
            //     field = model._fields.get(field_name)
            //     if field and (
            //         module == model._original_module
            //         or module in field._modules
            //         or any(
            //             # module introduced field on model by inheritance
            //             field_name in self.env[parent]._fields
            //             for parent, parent_module in model._inherit_module.items()
            //             if module == parent_module
            //         )
            //     ):
            //         xml_id = field_xmlid(module, field_model, field_name)
            //         record = self.browse(field_id)
            //         data_list.append({'xml_id': xml_id, 'record': record})
            // self.env['ir.model.data']._update_xmlids(data_list)
            */
            return default;
        }

        protected async Task<IrModelFields> RelatedFieldInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _related_field(self):
            // """ Return the ``ir.model.fields`` record corresponding to ``self.related``. """
            // names = self.related.split(".")
            // last = len(names) - 1
            // model_name = self.model or self.model_id.model
            // for index, name in enumerate(names):
            //     field = self._get(model_name, name)
            //     if not field:
            //         raise UserError(_(
            //             'Unknown field name "%(field_name)s" in related field "%(related_field)s"',
            //             field_name=name,
            //             related_field=self.related,
            //         ))
            //     model_name = field.relation
            //     if index < last and not field.relation:
            //         raise UserError(_(
            //             'Non-relational field name "%(field_name)s" in related field "%(related_field)s"',
            //             field_name=name,
            //             related_field=self.related,
            //         ))
            // return field
            */
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_model_fields.py) ---
            // def unlink(self):
            // """ When unlinking fields populate tracking value table with relevant
            // information. That way if a field is removed (custom tracked, migration
            // or any other reason) we keep the tracking and its relevant information.
            // Do it only when unlinking fields so that we don't duplicate field
            // information for most tracking. """
            // tracked = self.filtered('tracking')
            // if tracked:
            //     tracking_values = self.env['mail.tracking.value'].search(
            //         [('field_id', 'in', tracked.ids)]
            //     )
            //     field_to_trackings = groupby(tracking_values, lambda track: track.field_id)
            //     for field, trackings in field_to_trackings:
            //         if field.model_id.model not in self.env:
            //             # Model is already deleted
            //             continue
            //         self.env['mail.tracking.value'].concat(*trackings).write({
            //             'field_info': {
            //                 'desc': field.field_description,
            //                 'name': field.name,
            //                 'sequence': self.env[field.model_id.model]._mail_track_get_field_sequence(field.name),
            //                 'type': field.ttype,
            //             }
            //         })
            // return super().unlink()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def unlink(self):
            // if not self:
            //     return True
            // 
            // # prevent screwing up fields that depend on these fields
            // self = self._prepare_update()
            // 
            // # determine registry fields corresponding to self
            // fields = OrderedSet()
            // for record in self:
            //     try:
            //         fields.add(self.pool[record.model]._fields[record.name])
            //     except KeyError:
            //         pass
            // 
            // # clean the registry from the fields to remove
            // self.pool.registry_invalidated = True
            // self.pool._discard_fields(fields)
            // 
            // # discard the removed fields from fields to compute
            // for field in fields:
            //     self.env.transaction.tocompute.pop(field, None)
            // 
            // model_names = self.mapped('model')
            // self._drop_column()
            // res = super(IrModelFields, self).unlink()
            // 
            // # The field we just deleted might be inherited, and the registry is
            // # inconsistent in this case; therefore we reload the registry.
            // if not self.env.context.get(MODULE_UNINSTALL_FLAG):
            //     # setup models; this re-initializes models in registry
            //     self.env.flush_all()
            //     self.pool._setup_models__(self.env.cr, model_names)
            //     # update database schema of model and its descendant models
            //     models = self.pool.descendants(model_names, '_inherits')
            //     self.pool.init_models(self.env.cr, models, dict(self.env.context, update_custom_fields=True))
            // 
            // return res
            */
            return await base.UnlinkAsync(ids);
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, IrModelFields entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_sparse_field, FILE: models.py) ---
            // def write(self, vals):
            // # Limitation: renaming a sparse field or changing the storing system is
            // # currently not allowed
            // if 'serialization_field_id' in vals or 'name' in vals:
            //     for field in self:
            //         if 'serialization_field_id' in vals and field.serialization_field_id.id != vals['serialization_field_id']:
            //             raise UserError(_('Changing the storing system for field "%s" is not allowed.', field.name))
            //         if field.serialization_field_id and (field.name != vals['name']):
            //             raise UserError(_('Renaming sparse field "%s" is not allowed', field.name))
            // 
            // return super(IrModelFields, self).write(vals)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def write(self, vals):
            // if not self:
            //     return True
            // 
            // # if set, *one* column can be renamed here
            // column_rename = None
            // 
            // # names of the models to patch
            // patched_models = set()
            // translate_only = all(self._fields[field_name].translate for field_name in vals)
            // if vals and self and not translate_only:
            //     for item in self:
            //         if item.state != 'manual':
            //             raise UserError(_('Properties of base fields cannot be altered in this manner! '
            //                               'Please modify them through Python code, '
            //                               'preferably through a custom addon!'))
            // 
            //         if vals.get('model_id', item.model_id.id) != item.model_id.id:
            //             raise UserError(_("Changing the model of a field is forbidden!"))
            // 
            //         if vals.get('ttype', item.ttype) != item.ttype:
            //             raise UserError(_("Changing the type of a field is not yet supported. "
            //                               "Please drop it and create it again!"))
            // 
            //         obj = self.pool.get(item.model)
            //         field = getattr(obj, '_fields', {}).get(item.name)
            // 
            //         if vals.get('name', item.name) != item.name:
            //             # We need to rename the field
            //             item._prepare_update()
            //             if item.ttype in ('one2many', 'many2many', 'binary'):
            //                 # those field names are not explicit in the database!
            //                 pass
            //             else:
            //                 if column_rename:
            //                     raise UserError(_('Can only rename one field at a time!'))
            //                 column_rename = (obj._table, item.name, vals['name'], item.index, item.store)
            // 
            //         # We don't check the 'state', because it might come from the context
            //         # (thus be set for multiple fields) and will be ignored anyway.
            //         if obj is not None and field is not None:
            //             patched_models.add(obj._name)
            // 
            // # These shall never be written (modified)
            // for column_name in ('model_id', 'model', 'state'):
            //     if column_name in vals:
            //         del vals[column_name]
            // 
            // if vals.get('translate') and not isinstance(vals['translate'], str):
            //     _logger.warning("Deprecated since Odoo 19, ir.model.fields.translate becomes Selection, the value should be a string")
            //     vals['translate'] = 'html_translate' if vals.get('ttype') == 'html' else 'standard'
            // 
            // res = super(IrModelFields, self).write(vals)
            // 
            // self.env.flush_all()
            // 
            // if column_rename:
            //     # rename column in database, and its corresponding index if present
            //     table, oldname, newname, index, stored = column_rename
            //     if stored:
            //         self.env.cr.execute(SQL(
            //             'ALTER TABLE %s RENAME COLUMN %s TO %s',
            //             SQL.identifier(table),
            //             SQL.identifier(oldname),
            //             SQL.identifier(newname)
            //         ))
            //         if index:
            //             self.env.cr.execute(SQL(
            //                 'ALTER INDEX %s RENAME TO %s',
            //                 SQL.identifier(f'{table}_{oldname}_index'),
            //                 SQL.identifier(f'{table}_{newname}_index'),
            //             ))
            // 
            // if column_rename or patched_models or translate_only:
            //     # setup models, this will reload all manual fields in registry
            //     self.env.flush_all()
            //     model_names = OrderedSet(self.mapped('model'))
            //     self.pool._setup_models__(self.env.cr, model_names)
            // 
            // if patched_models:
            //     # update the database schema of the models to patch
            //     models = self.pool.descendants(patched_models, '_inherits')
            //     self.pool.init_models(self.env.cr, models, dict(self.env.context, update_custom_fields=True))
            // 
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}