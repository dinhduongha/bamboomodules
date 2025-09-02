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
    [Module("Mail", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public class MailTrackingValueAppService : GenericApplicationService<MailTrackingValue>, IMailTrackingValueAppService
    {

        public MailTrackingValueAppService(IRepository<MailTrackingValue, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<MailTrackingValue> CreateTrackingValuesInternalAsync(object initial_value, object new_value, object col_name, object col_info, object record)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_tracking_value.py) ---
            // def _create_tracking_values(self, initial_value, new_value, col_name, col_info, record):
            // """ Prepare values to create a mail.tracking.value. It prepares old and
            // new value according to the field type.
            // 
            // :param initial_value: field value before the change, could be text, int,
            //   date, datetime, ...;
            // :param new_value: field value after the change, could be text, int,
            //   date, datetime, ...;
            // :param str col_name: technical field name, column name (e.g. 'user_id);
            // :param dict col_info: result of fields_get(col_name);
            // :param <record> record: record on which tracking is performed, used for
            //   related computation e.g. finding currency of monetary fields;
            // 
            // :return: a dict values valid for 'mail.tracking.value' creation;
            // """
            // field = self.env['ir.model.fields']._get(record._name, col_name)
            // if not field:
            //     raise ValueError(f'Unknown field {col_name} on model {record._name}')
            // 
            // values = {'field_id': field.id}
            // 
            // if col_info['type'] in {'integer', 'float', 'char', 'text', 'datetime'}:
            //     values.update({
            //         f'old_value_{col_info["type"]}': initial_value,
            //         f'new_value_{col_info["type"]}': new_value
            //     })
            // elif col_info['type'] == 'monetary':
            //     values.update({
            //         'currency_id': record[col_info['currency_field']].id,
            //         'old_value_float': initial_value,
            //         'new_value_float': new_value
            //     })
            // elif col_info['type'] == 'date':
            //     values.update({
            //         'old_value_datetime': initial_value and fields.Datetime.to_string(datetime.combine(fields.Date.from_string(initial_value), datetime.min.time())) or False,
            //         'new_value_datetime': new_value and fields.Datetime.to_string(datetime.combine(fields.Date.from_string(new_value), datetime.min.time())) or False,
            //     })
            // elif col_info['type'] == 'boolean':
            //     values.update({
            //         'old_value_integer': initial_value,
            //         'new_value_integer': new_value
            //     })
            // elif col_info['type'] == 'selection':
            //     values.update({
            //         'old_value_char': initial_value and dict(col_info['selection']).get(initial_value, initial_value) or '',
            //         'new_value_char': new_value and dict(col_info['selection'])[new_value] or ''
            //     })
            // elif col_info['type'] == 'many2one':
            //     values.update({
            //         'old_value_integer': initial_value.id if initial_value else 0,
            //         'new_value_integer': new_value.id if new_value else 0,
            //         'old_value_char': initial_value.display_name if initial_value else '',
            //         'new_value_char': new_value.display_name if new_value else ''
            //     })
            // elif col_info['type'] in {'one2many', 'many2many'}:
            //     values.update({
            //         'old_value_char': ', '.join(initial_value.mapped('display_name')) if initial_value else '',
            //         'new_value_char': ', '.join(new_value.mapped('display_name')) if new_value else '',
            //     })
            // else:
            //     raise NotImplementedError(f'Unsupported tracking on field {field.name} (type {col_info["type"]}')
            // 
            // return values
            */
            return default;
        }

        protected async Task<MailTrackingValue> ExceptAuditLogInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: mail_tracking_value.py) ---
            // def _except_audit_log(self):
            // self.mail_message_id._except_audit_log()
            */
            return default;
        }

        protected async Task<MailTrackingValue> FilterFreeFieldAccessInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_tracking_value.py) ---
            // def _filter_free_field_access(self):
            // """ Return the subset of self which is available for all users: trackings
            // linked to an existing field without access group. It is used notably
            // when sending tracking summary through notifications. """
            // 
            // def has_free_access(tracking):
            //     if not tracking.field_id:
            //         return False
            //     model_field = self.env[tracking.field_id.model]._fields.get(tracking.field_id.name)
            //     return model_field and not model_field.groups
            // 
            // return self.filtered(has_free_access)
            */
            return default;
        }

        protected async Task<MailTrackingValue> FilterHasFieldAccessInternalAsync(object env)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_tracking_value.py) ---
            // def _filter_has_field_access(self, env):
            // """ Return the subset of self for which the user in env has access. As
            // this model is admin-only, it is generally accessed as sudo and we need
            // to distinguish context environment from tracking values environment.
            // 
            // If tracking is linked to a field, user should have access to the field.
            // Otherwise only members of "base.group_system" can access it. """
            // 
            // def has_field_access(tracking):
            //     if not tracking.field_id:
            //         return env.is_system()
            //     model_field = env[tracking.field_id.model]._fields.get(tracking.field_id.name)
            //     return model_field.is_accessible(env) if model_field else False
            // 
            // return self.filtered(has_field_access)
            */
            return default;
        }

        protected async Task<MailTrackingValue> FormatDisplayValueInternalAsync(object field_type, object @new)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_tracking_value.py) ---
            // def _format_display_value(self, field_type, new=True):
            // """ Format value of 'mail.tracking.value', according to the field type.
            // 
            // :param str field_type: Odoo field type;
            // :param bool new: if True, display the 'new' value. Otherwise display
            //   the 'old' one.
            // """
            // field_mapping = {
            //     'boolean': ('old_value_integer', 'new_value_integer'),
            //     'date': ('old_value_datetime', 'new_value_datetime'),
            //     'datetime': ('old_value_datetime', 'new_value_datetime'),
            //     'char': ('old_value_char', 'new_value_char'),
            //     'float': ('old_value_float', 'new_value_float'),
            //     'integer': ('old_value_integer', 'new_value_integer'),
            //     'monetary': ('old_value_float', 'new_value_float'),
            //     'text': ('old_value_text', 'new_value_text'),
            // }
            // 
            // result = []
            // for record in self:
            //     value_fname = field_mapping.get(
            //         field_type, ('old_value_char', 'new_value_char')
            //     )[bool(new)]
            //     value = record[value_fname]
            // 
            //     if field_type in {'integer', 'float', 'char', 'text', 'monetary'}:
            //         result.append(value)
            //     elif field_type in {'date', 'datetime'}:
            //         if not record[value_fname]:
            //             result.append(value)
            //         elif field_type == 'date':
            //             result.append(fields.Date.to_string(value))
            //         else:
            //             result.append(f'{value}Z')
            //     elif field_type == 'boolean':
            //         result.append(bool(value))
            //     else:
            //         result.append(value)
            // return result
            */
            return default;
        }

        protected async Task<MailTrackingValue> TrackingValueFormatInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_tracking_value.py) ---
            // def _tracking_value_format(self):
            // """ Return structure and formatted data structure to be used by chatter
            // to display tracking values. Order it according to asked display, aka
            // ascending sequence (and field name).
            // 
            // :return list: for each tracking value in self, their formatted display
            //   values given as a dict;
            // """
            // model_map = {}
            // for tracking in self:
            //     model = tracking.field_id.model or tracking.mail_message_id.model
            //     model_map.setdefault(model, self.browse())
            //     model_map[model] += tracking
            // formatted = []
            // for model, trackings in model_map.items():
            //     formatted += trackings._tracking_value_format_model(model)
            // return formatted
            */
            return default;
        }

        protected async Task<MailTrackingValue> TrackingValueFormatModelInternalAsync(object model)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_tracking_value.py) ---
            // def _tracking_value_format_model(self, model):
            // """ Return structure and formatted data structure to be used by chatter
            // to display tracking values. Order it according to asked display, aka
            // ascending sequence (and field name).
            // 
            // :return list: for each tracking value in self, their formatted display
            //   values given as a dict;
            // """
            // if not self:
            //     return []
            // 
            // # fetch model-based information
            // if model:
            //     TrackedModel = self.env[model]
            //     tracked_fields = TrackedModel.fields_get(self.field_id.mapped('name'), attributes={'digits', 'string', 'type'})
            //     model_sequence_info = dict(TrackedModel._mail_track_order_fields(tracked_fields)) if model else {}
            // else:
            //     tracked_fields, model_sequence_info = {}, {}
            // 
            // # generate sequence of trackings
            // fields_sequence_map = dict(
            //     {
            //         tracking.field_info['name']: tracking.field_info.get('sequence', 100)
            //         for tracking in self.filtered('field_info')
            //     },
            //     **model_sequence_info,
            // )
            // # generate dict of field information, if available
            // fields_col_info = (
            //     tracked_fields.get(tracking.field_id.name) or {
            //         'string': tracking.field_info['desc'] if tracking.field_info else self.env._('Unknown'),
            //         'type': tracking.field_info['type'] if tracking.field_info else 'char',
            //     } for tracking in self
            // )
            // 
            // formatted = [
            //     {
            //         'changedField': col_info['string'],
            //         'id': tracking.id,
            //         'fieldName': tracking.field_id.name or (tracking.field_info['name'] if tracking.field_info else 'unknown'),
            //         'fieldType': col_info['type'],
            //         'newValue': {
            //             'currencyId': tracking.currency_id.id,
            //             'floatPrecision': col_info.get('digits'),
            //             'value': tracking._format_display_value(col_info['type'], new=True)[0],
            //         },
            //         'oldValue': {
            //             'currencyId': tracking.currency_id.id,
            //             'floatPrecision': col_info.get('digits'),
            //             'value': tracking._format_display_value(col_info['type'], new=False)[0],
            //         },
            //     }
            //     for tracking, col_info in zip(self, fields_col_info)
            // ]
            // formatted.sort(
            //     key=lambda info: (fields_sequence_map.get(info['fieldName'], 100), info['fieldName']),
            //     reverse=False,
            // )
            // return formatted
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, MailTrackingValue entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: mail_tracking_value.py) ---
            // def write(self, vals):
            // self._except_audit_log()
            // return super().write(vals)
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}