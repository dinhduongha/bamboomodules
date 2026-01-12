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
    public class IrModelAppService : GenericApplicationService<IrModel>, IIrModelAppService
    {

        public IrModelAppService(IRepository<IrModel, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<IrModel> CheckFoldNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _check_fold_name(self):
            // for model in self:
            //     if model.fold_name and model.fold_name not in model.field_id.mapped('name'):
            //         raise ValidationError(_("The value of 'Fold Field' should be a field name of the model."))
            */
            return default;
        }

        protected async Task<IrModel> CheckManualNameInternalAsync(object name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _check_manual_name(self, name):
            // if not self._is_manual_name(name):
            //     raise ValidationError(_("The model name must start with 'x_'."))
            */
            return default;
        }

        protected async Task<IrModel> CheckModelNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _check_model_name(self):
            // for model in self:
            //     if model.state == 'manual':
            //         self._check_manual_name(model.model)
            //     if not models.check_object_name(model.model):
            //         raise ValidationError(_("The model name can only contain lowercase characters, digits, underscores and dots."))
            */
            return default;
        }

        protected async Task<IrModel> CheckOrderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _check_order(self):
            // for model in self:
            //     try:
            //         model._check_qorder(model.order)  # regex check for the whole clause ('is it valid sql?')
            //     except UserError as e:
            //         raise ValidationError(str(e))
            //     # add MAGIC_COLUMNS to 'stored_fields' in case 'model' has not been
            //     # initialized yet, or 'field_id' is not up-to-date in cache
            //     stored_fields = set(
            //         model.field_id.filtered('store').mapped('name') + models.MAGIC_COLUMNS
            //     )
            //     if model.model in self.env:
            //         # add fields inherited from models specified via code if they are already loaded
            //         stored_fields.update(
            //             fname
            //             for fname, fval in self.env[model.model]._fields.items()
            //             if fval.inherited and fval.base_field.store
            //         )
            // 
            //     order_fields = RE_ORDER_FIELDS.findall(model.order)
            //     for field in order_fields:
            //         if field not in stored_fields:
            //             raise ValidationError(_("Unable to order by %s: fields used for ordering must be present on the model and stored.", field))
            */
            return default;
        }

        protected async Task<IrModel> ComputeCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _compute_count(self):
            // self.count = 0
            // for model in self:
            //     records = self.env.get(model.model)
            //     if records is not None and not records._abstract and records._auto:
            //         [[count]] = self.env.execute_query(SQL("SELECT COUNT(*) FROM %s", SQL.identifier(records._table)))
            //         model.count = count
            */
            return default;
        }

        protected async Task<IrModel> ComputeIsMailThreadSmsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: ir_model.py) ---
            // def _compute_is_mail_thread_sms(self):
            // for model in self:
            //     if model.is_mail_thread:
            //         ModelObject = self.env[model.model]
            //         potential_fields = ModelObject._phone_get_number_fields() + ModelObject._mail_get_partner_fields()
            //         if any(fname in ModelObject._fields for fname in potential_fields):
            //             model.is_mail_thread_sms = True
            //             continue
            //     model.is_mail_thread_sms = False
            */
            return default;
        }

        protected async Task<IrModel> ComputeIsMailingEnabledInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: ir_model.py) ---
            // def _compute_is_mailing_enabled(self):
            // for model in self:
            //     model.is_mailing_enabled = getattr(self.env[model.model], '_mailing_enabled', False)
            */
            return default;
        }

        protected async Task<IrModel> DefaultFieldIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _default_field_id(self):
            // if self.env.context.get('install_mode'):
            //     return []                   # no default field when importing
            // return [Command.create({'name': 'x_name', 'field_description': 'Name', 'ttype': 'char', 'copied': True})]
            */
            return default;
        }

        protected async Task<IrModel> DeleteLinkedCampaignsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: marketing_card, FILE: ir_model.py) ---
            // def _delete_linked_campaigns(self):
            // """Remove campaigns on removed models."""
            // self.env['card.campaign'].search([
            //     ('res_model', 'in', self.mapped('model'))
            // ]).unlink()
            */
            return default;
        }

        public async Task<IrModel> DisplayNameForAsync(Guid id, IrModelDisplayNameForRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: ir_model.py) ---
            // def display_name_for(self, models):
            // """
            // Returns the display names from provided models which the current user can access.
            // The result is the same whether someone tries to access an inexistent model or a model they cannot access.
            // :models list(str): list of technical model names to lookup (e.g. `["res.partner"]`)
            // :return: list of dicts of the form `{ "model", "display_name" }` (e.g. `{ "model": "res_partner", "display_name": "Contact"}`)
            // """
            // # Store accessible models in a temporary list in order to execute only one SQL query
            // accessible_models = []
            // not_accessible_models = []
            // for model in models:
            //     if self._is_valid_for_model_selector(model):
            //         accessible_models.append(model)
            //     else:
            //         not_accessible_models.append({"display_name": model, "model": model})
            // return self._display_name_for(accessible_models) + not_accessible_models
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrModel> DisplayNameForInternalAsync(object models)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: ir_model.py) ---
            // def _display_name_for(self, models):
            // records = self.sudo().search_read([("model", "in", models)], ["name", "model"])
            // return [{
            //     "display_name": model["name"],
            //     "model": model["model"],
            // } for model in records]
            */
            return default;
        }

        protected async Task<IrModel> DropTableInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _drop_table(self):
            // for model in self:
            //     current_model = self.env.get(model.model)
            //     if current_model is not None:
            //         if current_model._abstract:
            //             continue
            // 
            //         table = current_model._table
            //         kind = sql.table_kind(self.env.cr, table)
            //         if kind == sql.TableKind.View:
            //             self.env.cr.execute(SQL('DROP VIEW %s', SQL.identifier(table)))
            //         elif kind == sql.TableKind.Regular:
            //             self.env.cr.execute(SQL('DROP TABLE %s CASCADE', SQL.identifier(table)))
            //         elif kind is not None:
            //             _logger.warning(
            //                 "Unable to drop table %r of model %r: unmanaged or unknown tabe type %r",
            //                 table, model.model, kind
            //             )
            //     else:
            //         _logger.runbot('The model %s could not be dropped because it did not exist in the registry.', model.model)
            // return True
            */
            return default;
        }

        public async Task<IrModel> GetAuthorizedFieldsAsync(Guid id, IrModelGetAuthorizedFieldsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_form.py) ---
            // def get_authorized_fields(self, model_name, property_origins):
            // """ Return the fields of the given model name as a mapping like method `fields_get`. """
            // model = self.env[model_name]
            // fields_get = model.fields_get()
            // 
            // for val in model._inherits.values():
            //     fields_get.pop(val, None)
            // 
            // # Unrequire fields with default values
            // default_values = model.with_user(SUPERUSER_ID).default_get(list(fields_get))
            // for field in [f for f in fields_get if f in default_values]:
            //     fields_get[field]['required'] = False
            // 
            // # Remove readonly, JSON, and magic fields
            // # Remove string domains which are supposed to be evaluated
            // # (e.g. "[('product_id', '=', product_id)]")
            // # Expand properties fields
            // for field in list(fields_get):
            //     if 'domain' in fields_get[field] and isinstance(fields_get[field]['domain'], str):
            //         del fields_get[field]['domain']
            //     if fields_get[field].get('readonly') or field in models.MAGIC_COLUMNS or \
            //             fields_get[field]['type'] in ('many2one_reference', 'json'):
            //         del fields_get[field]
            //     elif fields_get[field]['type'] == 'properties':
            //         property_field = fields_get[field]
            //         del fields_get[field]
            //         if property_origins:
            //             # Add property pseudo-fields
            //             # The properties of a property field are defined in a
            //             # definition record (e.g. properties inside a project.task
            //             # are defined inside its related project.project)
            //             definition_record = property_field['definition_record']
            //             if definition_record in property_origins:
            //                 definition_record_field = property_field['definition_record_field']
            //                 relation_field = fields_get[definition_record]
            //                 definition_model = self.env[relation_field['relation']]
            //                 if not property_origins[definition_record].isdigit():
            //                     # Do not fail on malformed forms.
            //                     continue
            //                 definition_record = definition_model.browse(int(property_origins[definition_record]))
            //                 properties_definitions = definition_record[definition_record_field]
            //                 for property_definition in properties_definitions:
            //                     if ((
            //                         property_definition['type'] in ['many2one', 'many2many']
            //                         and 'comodel' not in property_definition
            //                     ) or (
            //                         property_definition['type'] == 'selection'
            //                         and not property_definition['selection']
            //                     ) or (
            //                         property_definition['type'] == 'tags'
            //                         and not property_definition['tags']
            //                     ) or (property_definition['type'] == 'separator')):
            //                         # Ignore non-fully defined properties
            //                         continue
            //                     property_definition['_property'] = {
            //                         'field': field,
            //                     }
            //                     property_definition['required'] = False
            //                     if 'domain' in property_definition and isinstance(property_definition['domain'], str):
            //                         property_definition['domain'] = literal_eval(property_definition['domain'])
            //                         try:
            //                             property_definition['domain'] = list(Domain(property_definition['domain']))
            //                         except Exception:
            //                             # Ignore non-fully defined properties
            //                             continue
            //                     fields_get[property_definition.get('name')] = property_definition
            // 
            // return fields_get
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrModel> GetAvailableModelsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: ir_model.py) ---
            // def get_available_models(self):
            // """
            // Return the list of models the current user has access to, with their
            // corresponding display name.
            // """
            // accessible_models = [model for model in self.pool if self._is_valid_for_model_selector(model)]
            // return self._display_name_for(accessible_models)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrModel> GetCompatibleFormModelsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_form.py) ---
            // def get_compatible_form_models(self):
            // if not self.env.user.has_group('website.group_website_restricted_editor'):
            //     return []
            // return self.sudo().search_read(
            //     [('website_form_access', '=', True)],
            //     ['id', 'model', 'name', 'website_form_label', 'website_form_key'],
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrModel> GetDefinitionsInternalAsync(object model_names)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_model.py) ---
            // def _get_definitions(self, model_names):
            // model_definitions = super()._get_definitions(model_names)
            // for model_name, model_definition in model_definitions.items():
            //     model = self.env[model_name]
            //     tracked_field_names = model._track_get_fields() if 'mail.thread' in model._inherit else []
            //     for fname in tracked_field_names:
            //         if fname in model_definition["fields"]:
            //             model_definition["fields"][fname]["tracking"] = True
            //     if isinstance(self.env[model_name], self.env.registry['mail.activity.mixin']):
            //         model_definition["has_activities"] = True
            // return model_definitions
            --- ODOO METHOD SOURCE (MODULE: web, FILE: ir_model.py) ---
            // def _get_definitions(self, model_names):
            // model_definitions = {}
            // for model_name in model_names:
            //     model = self.env[model_name]
            //     # get fields, relational fields are kept only if the related model is in model_names
            //     fields_data_by_fname = {
            //         fname: field_data
            //         for fname, field_data in model.fields_get(
            //             attributes={
            //                 'definition_record_field', 'definition_record', 'aggregator',
            //                 'name', 'readonly', 'related', 'relation', 'required', 'searchable',
            //                 'selection', 'sortable', 'store', 'string', 'tracking', 'type',
            //             },
            //         ).items()
            //         if field_data.get('selectable', True) and (
            //             not field_data.get('relation') or field_data['relation'] in model_names
            //         )
            //     }
            //     fields_data_by_fname = {
            //         fname: field_data
            //         for fname, field_data in fields_data_by_fname.items()
            //         if not field_data.get('related') or field_data['related'].split('.')[0] in fields_data_by_fname
            //     }
            //     for fname, field_data in fields_data_by_fname.items():
            //         if fname in model._fields:
            //             inverse_fields = [
            //                 field for field in model.pool.field_inverses[model._fields[fname]]
            //                 if field.model_name in model_names
            //                 and model.env[field.model_name]._has_field_access(field, 'read')
            //             ]
            //             if inverse_fields:
            //                 field_data['inverse_fname_by_model_name'] = {field.model_name: field.name for field in inverse_fields}
            //             if field_data['type'] == 'many2one_reference':
            //                 field_data['model_name_ref_fname'] = model._fields[fname].model_field
            //     model_definitions[model_name] = {
            //         'description': model._description,
            //         'fields': fields_data_by_fname,
            //         'inherit': [model_name for model_name in model._inherit_module if model_name in model_names],
            //         'order': model._order,
            //         'parent_name': model._parent_name,
            //         'rec_name': model._rec_name,
            //     }
            // return model_definitions
            */
            return default;
        }

        protected async Task<IrModel> GetFormWritableFieldsInternalAsync(object property_origins)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_form.py) ---
            // def _get_form_writable_fields(self, property_origins=None):
            // """
            // Restriction of "authorized fields" (fields which can be used in the
            // form builders) to fields which have actually been opted into form
            // builders and are writable. By default no field is writable by the
            // form builder.
            // """
            // if self.model == "mail.mail":
            //     included = {'email_from', 'email_to', 'email_cc', 'email_bcc', 'body', 'reply_to', 'subject'}
            // else:
            //     included = {
            //         field.name
            //         for field in self.env['ir.model.fields'].sudo().search([
            //             ('model_id', '=', self.id),
            //             ('website_form_blacklisted', '=', False)
            //         ])
            //     }
            // return {
            //     k: v for k, v in self.get_authorized_fields(self.model, property_origins).items()
            //     if k in included or '_property' in v and v['_property']['field'] in included
            // }
            */
            return default;
        }

        protected async Task<IrModel> GetIdInternalAsync(object name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _get_id(self, name):
            // self.env.cr.execute("SELECT id FROM ir_model WHERE model=%s", (name,))
            // result = self.env.cr.fetchone()
            // return result and result[0]
            */
            return default;
        }

        protected async Task<IrModel> GetInternalAsync(object name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _get(self, name):
            // """ Return the (sudoed) `ir.model` record with the given name.
            // The result may be an empty recordset if the model is not found.
            // """
            // model_id = self._get_id(name) if name else False
            // return self.sudo().browse(model_id)
            */
            return default;
        }

        protected async Task<IrModel> GetModelDefinitionsInternalAsync(object model_names_to_fetch)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: bus, FILE: ir_model.py) ---
            // def _get_model_definitions(self, model_names_to_fetch):
            // model_definitions = {}
            // for model_name in model_names_to_fetch:
            //     model = self.env[model_name]
            //     # get fields, relational fields are kept only if the related model is in model_names_to_fetch
            //     fields_data_by_fname = {
            //         fname: field_data
            //         for fname, field_data in model.fields_get(
            //             attributes={
            //                 'name', 'type', 'relation', 'required', 'readonly', 'selection',
            //                 'string', 'definition_record', 'definition_record_field', 'model_field',
            //             },
            //         ).items()
            //         if not field_data.get('relation') or field_data['relation'] in model_names_to_fetch
            //     }
            //     for fname, field_data in fields_data_by_fname.items():
            //         if fname in model._fields:
            //             inverse_fields = [
            //                 field for field in model.pool.field_inverses[model._fields[fname]]
            //                 if field.model_name in model_names_to_fetch
            //                 and model.env[field.model_name]._has_field_access(field, 'read')
            //             ]
            //             if inverse_fields:
            //                 field_data['inverse_fname_by_model_name'] = {field.model_name: field.name for field in inverse_fields}
            //             if field_data['type'] == 'many2one_reference':
            //                 field_data['model_name_ref_fname'] = model._fields[fname].model_field
            //     model_definitions[model_name] = {"fields": fields_data_by_fname}
            // return model_definitions
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_model.py) ---
            // def _get_model_definitions(self, model_names_to_fetch):
            // model_definitions = super()._get_model_definitions(model_names_to_fetch)
            // for model_name, model_definition in model_definitions.items():
            //     model = self.env[model_name]
            //     tracked_field_names = model._track_get_fields() if 'mail.thread' in model._inherit else []
            //     for fname, field in model_definition["fields"].items():
            //         if fname in tracked_field_names:
            //             field['tracking'] = True
            //     if isinstance(self.env[model_name], self.env.registry['mail.activity.mixin']):
            //         model_definition["has_activities"] = True
            // return model_definitions
            */
            return default;
        }

        public async Task<IrModel> HasSearchableParentRelationAsync(Guid id, IrModelHasSearchableParentRelationRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet, FILE: ir_model.py) ---
            // def has_searchable_parent_relation(self, model_names):
            // result = {}
            // for model_name in model_names:
            //     model = self.env.get(model_name)
            //     if model is None or not model.has_access("read"):
            //         result[model_name] = False
            //     else:
            //         # we consider only stored parent relationships were meant to
            //         # be searched
            //         result[model_name] = model._parent_store and model._parent_name in model._fields
            // return result
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrModel> InModulesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _in_modules(self):
            // installed_modules = self.env['ir.module.module'].search([('state', '=', 'installed')])
            // installed_names = set(installed_modules.mapped('name'))
            // xml_ids = models.Model._get_external_ids(self)
            // for model in self:
            //     module_names = set(xml_id.split('.')[0] for xml_id in xml_ids[model.id])
            //     model.modules = ", ".join(sorted(installed_names & module_names))
            */
            return default;
        }

        protected async Task<IrModel> InheritedModelsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _inherited_models(self):
            // self.inherited_model_ids = False
            // for model in self:
            //     records = self.env.get(model.model)
            //     if records is not None:
            //         model.inherited_model_ids = self.search([('model', 'in', list(records._inherits))])
            */
            return default;
        }

        protected async Task<IrModel> InstanciateAttrsInternalAsync(object model_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_model.py) ---
            // def _instanciate_attrs(self, model_data):
            // attrs = super()._instanciate_attrs(model_data)
            // if model_data.get('is_mail_blacklist') and attrs['_name'] != 'mail.thread.blacklist':
            //     parents = attrs.get('_inherit') or []
            //     parents = [parents] if isinstance(parents, str) else parents
            //     attrs['_inherit'] = parents + ['mail.thread.blacklist']
            //     if attrs['_custom']:
            //         attrs['_primary_email'] = 'x_email'
            // elif model_data.get('is_mail_thread') and attrs['_name'] != 'mail.thread':
            //     parents = attrs.get('_inherit') or []
            //     parents = [parents] if isinstance(parents, str) else parents
            //     attrs['_inherit'] = parents + ['mail.thread']
            // if model_data.get('is_mail_activity') and attrs['_name'] != 'mail.activity.mixin':
            //     parents = attrs.get('_inherit') or []
            //     parents = [parents] if isinstance(parents, str) else parents
            //     attrs['_inherit'] = parents + ['mail.activity.mixin']
            // return attrs
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _instanciate_attrs(self, model_data):
            // """ Return the attributes to instanciate a custom model definition class
            //     corresponding to ``model_data``.
            // """
            // return {
            //     '_name': model_data['model'],
            //     '_description': model_data['name'],
            //     '_module': False,
            //     '_custom': True,
            //     '_abstract': bool(model_data['abstract']),
            //     '_transient': bool(model_data['transient']),
            //     '_order': model_data['order'],
            //     '_fold_name': model_data['fold_name'],
            //     '__doc__': model_data['info'],
            // }
            */
            return default;
        }

        protected async Task<IrModel> IsManualNameInternalAsync(object name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _is_manual_name(self, name):
            // return name.startswith('x_')
            */
            return default;
        }

        protected async Task<IrModel> IsValidForModelSelectorInternalAsync(object model)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: ir_model.py) ---
            // def _is_valid_for_model_selector(self, model):
            // model = self.env.get(model)
            // return (
            //     self.env.user._is_internal()
            //     and model is not None
            //     and model.has_access("read")
            //     and not model._transient
            //     and not model._abstract
            // )
            */
            return default;
        }

        protected async Task<IrModel> ReflectModelParamsInternalAsync(object model)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_model.py) ---
            // def _reflect_model_params(self, model):
            // vals = super(IrModel, self)._reflect_model_params(model)
            // vals['is_mail_thread'] = isinstance(model, self.pool['mail.thread'])
            // vals['is_mail_activity'] = isinstance(model, self.pool['mail.activity.mixin'])
            // vals['is_mail_blacklist'] = isinstance(model, self.pool['mail.thread.blacklist'])
            // return vals
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _reflect_model_params(self, model):
            // """ Return the values to write to the database for the given model. """
            // return {
            //     'model': model._name,
            //     'name': model._description,
            //     'order': model._order,
            //     'info': next(cls.__doc__ for cls in self.env.registry[model._name].mro() if cls.__doc__),
            //     'state': 'manual' if model._custom else 'base',
            //     'abstract': model._abstract,
            //     'transient': model._transient,
            //     'fold_name': model._fold_name,
            // }
            */
            return default;
        }

        protected async Task<IrModel> ReflectModelsInternalAsync(object model_names)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _reflect_models(self, model_names):
            // """ Reflect the given models. """
            // # determine expected and existing rows
            // rows = [
            //     self._reflect_model_params(self.env[model_name])
            //     for model_name in model_names
            // ]
            // cols = list(unique(['model'] + list(rows[0])))
            // expected = [tuple(row[col] for col in cols) for row in rows]
            // 
            // model_ids = {}
            // existing = {}
            // for row in select_en(self, ['id'] + cols, model_names):
            //     model_ids[row[1]] = row[0]
            //     existing[row[1]] = row[1:]
            // 
            // # create or update rows
            // rows = [row for row in expected if existing.get(row[0]) != row]
            // if rows:
            //     ids = upsert_en(self, cols, rows, ['model'])
            //     for row, id_ in zip(rows, ids):
            //         model_ids[row[0]] = id_
            //     self.pool.post_init(mark_modified, self.browse(ids), cols[1:])
            // 
            // # update their XML id
            // module = self.env.context.get('module')
            // if not module:
            //     return
            // 
            // data_list = []
            // for model_name, model_id in model_ids.items():
            //     model = self.env[model_name]
            //     if model._module == module:
            //         # model._module is the name of the module that last extended model
            //         xml_id = model_xmlid(module, model_name)
            //         record = self.browse(model_id)
            //         data_list.append({'xml_id': xml_id, 'record': record})
            // self.env['ir.model.data']._update_xmlids(data_list)
            */
            return default;
        }

        protected async Task<IrModel> SearchIsMailThreadSmsInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: ir_model.py) ---
            // def _search_is_mail_thread_sms(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // thread_models = self.search([('is_mail_thread', '=', True)])
            // valid_models = self.env['ir.model']
            // for model in thread_models:
            //     if model.model not in self.env:
            //         continue
            //     ModelObject = self.env[model.model]
            //     potential_fields = ModelObject._phone_get_number_fields() + ModelObject._mail_get_partner_fields()
            //     if any(fname in ModelObject._fields for fname in potential_fields):
            //         valid_models |= model
            // 
            // return [('id', 'in', valid_models.ids)]
            */
            return default;
        }

        protected async Task<IrModel> SearchIsMailingEnabledInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: ir_model.py) ---
            // def _search_is_mailing_enabled(self, operator, value):
            // if operator not in ('in', 'not in'):
            //     return NotImplemented
            // 
            // valid_models = self.search([]).filtered(
            //     lambda model: model.model in self.env
            //     and not model.is_transient()
            //     and getattr(self.env[model.model], '_mailing_enabled', False)
            // )
            // 
            // return [('id', operator, valid_models.ids)]
            */
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_model.py) ---
            // def unlink(self):
            // """ Delete mail data (followers, messages, activities) associated with
            // the models being deleted.
            // """
            // if not self:
            //     return True
            // 
            // # Delete followers, messages and attachments for models that will be unlinked.
            // mail_models = self.search([
            //     ('model', 'in', ('mail.activity', 'mail.activity.type', 'mail.followers', 'mail.message'))
            // ], order='id')
            // 
            // if not (self & mail_models):
            //     models = tuple(self.mapped('model'))
            //     model_ids = tuple(self.ids)
            // 
            //     query = "DELETE FROM mail_activity WHERE res_model_id IN %s"
            //     self.env.cr.execute(query, [model_ids])
            // 
            //     query = "DELETE FROM mail_activity_type WHERE res_model IN %s"
            //     self.env.cr.execute(query, [models])
            // 
            //     query = "DELETE FROM mail_followers WHERE res_model IN %s"
            //     self.env.cr.execute(query, [models])
            // 
            //     query = "DELETE FROM mail_message WHERE model in %s"
            //     self.env.cr.execute(query, [models])
            // 
            // # Get files attached solely to the models being deleted (and none other)
            // models = tuple(self.mapped('model'))
            // query = """
            //     SELECT DISTINCT store_fname
            //     FROM ir_attachment
            //     WHERE res_model IN %s
            //     EXCEPT
            //     SELECT store_fname
            //     FROM ir_attachment
            //     WHERE res_model not IN %s;
            // """
            // self.env.cr.execute(query, [models, models])
            // fnames = self.env.cr.fetchall()
            // 
            // query = """DELETE FROM ir_attachment WHERE res_model in %s"""
            // self.env.cr.execute(query, [models])
            // 
            // for (fname,) in fnames:
            //     self.env['ir.attachment']._file_delete(fname)
            // 
            // return super(IrModel, self).unlink()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def unlink(self):
            // # prevent screwing up fields that depend on these models' fields
            // manual_models = self.filtered(lambda model: model.state == 'manual')
            // manual_models.field_id.filtered(lambda f: f.state == 'manual')._prepare_update()
            // (self - manual_models).field_id._prepare_update()
            // 
            // # delete fields whose comodel is being removed
            // self.env['ir.model.fields'].search([('relation', 'in', self.mapped('model'))]).unlink()
            // 
            // # delete ir_crons created by user
            // crons = self.env['ir.cron'].with_context(active_test=False).search([('model_id', 'in', self.ids)])
            // if crons:
            //     crons.unlink()
            // 
            // # delete related ir_model_data
            // model_data = self.env['ir.model.data'].search([('model', 'in', self.mapped('model'))])
            // if model_data:
            //     model_data.unlink()
            // 
            // self._drop_table()
            // res = super().unlink()
            // 
            // # Reload registry for normal unlink only. For module uninstall, the
            // # reload is done independently in odoo.modules.loading.
            // if not self.env.context.get(MODULE_UNINSTALL_FLAG):
            //     # setup models; this automatically removes model from registry
            //     self.env.flush_all()
            //     self.pool._setup_models__(self.env.cr)
            // 
            // return res
            */
            return await base.UnlinkAsync(ids);
        }

        protected async Task<IrModel> UnlinkIfManualInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _unlink_if_manual(self):
            // # Prevent manual deletion of module tables
            // for model in self:
            //     if model.state != 'manual':
            //         raise UserError(_("Model “%s” contains module data and cannot be removed.", model.name))
            */
            return default;
        }

        protected async Task<IrModel> ViewIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _view_ids(self):
            // for model in self:
            //     model.view_ids = self.env['ir.ui.view'].search([('model', '=', model.model)])
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, IrModel entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_model.py) ---
            // def write(self, vals):
            // if self and ('is_mail_thread' in vals or 'is_mail_activity' in vals or 'is_mail_blacklist' in vals):
            //     if any(rec.state != 'manual' for rec in self):
            //         raise UserError(_('Only custom models can be modified.'))
            //     if 'is_mail_thread' in vals and any(rec.is_mail_thread > vals['is_mail_thread'] for rec in self):
            //         raise UserError(_('Field "Mail Thread" cannot be changed to "False".'))
            //     if 'is_mail_activity' in vals and any(rec.is_mail_activity > vals['is_mail_activity'] for rec in self):
            //         raise UserError(_('Field "Mail Activity" cannot be changed to "False".'))
            //     if 'is_mail_blacklist' in vals and any(rec.is_mail_blacklist > vals['is_mail_blacklist'] for rec in self):
            //         raise UserError(_('Field "Mail Blacklist" cannot be changed to "False".'))
            //     res = super(IrModel, self).write(vals)
            //     self.env.flush_all()
            //     # setup models; this reloads custom models in registry
            //     model_names = self.mapped('model')
            //     self.pool._setup_models__(self.env.cr, model_names)
            //     # update database schema of models
            //     model_names = self.pool.descendants(model_names, '_inherits')
            //     self.pool.init_models(self.env.cr, model_names, dict(self.env.context, update_custom_fields=True))
            // else:
            //     res = super(IrModel, self).write(vals)
            // return res
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def write(self, vals):
            // for unmodifiable_field in ('model', 'state', 'abstract', 'transient'):
            //     if unmodifiable_field in vals and any(rec[unmodifiable_field] != vals[unmodifiable_field] for rec in self):
            //         raise UserError(_('Field %s cannot be modified on models.', self._fields[unmodifiable_field]._description_string(self.env)))
            // # Filter out operations 4 from field id, because the web client always
            // # writes (4,id,False) even for non dirty items.
            // if 'field_id' in vals:
            //     vals['field_id'] = [op for op in vals['field_id'] if op[0] != 4]
            // res = super().write(vals)
            // # ordering has been changed, reload registry to reflect update + signaling
            // if 'order' in vals or 'fold_name' in vals:
            //     self.env.flush_all()  # _setup_models__ need to fetch the updated values from the db
            //     # incremental setup will reload custom models
            //     self.pool._setup_models__(self.env.cr, [])
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}