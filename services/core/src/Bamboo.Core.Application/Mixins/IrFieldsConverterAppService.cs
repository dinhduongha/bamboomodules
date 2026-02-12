using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
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
    [Module("base", Category = "Base")]
    public partial class IrFieldsConverterAppService : ApplicationService, IIrFieldsConverterAppService
    {

        public IrFieldsConverterAppService() 
        {

        }

        [ApiModel]
        public async Task<TEntity> DbIdForAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object subfield, object @value, object savepoint) where TEntity : IEntity<Guid>, IIrFieldsConverterable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_fields.py, METHOD: db_id_for) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ForModelAsync<TEntity>(IEnumerable<TEntity> entities, object model, object fromtype) where TEntity : IEntity<Guid>, IIrFieldsConverterable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_fields.py, METHOD: for_model) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FormatImportErrorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object error_type, object error_msg, object error_params, object error_args) where TEntity : IEntity<Guid>, IIrFieldsConverterable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_fields.py, METHOD: _format_import_error) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetBooleanTranslationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object src) where TEntity : IEntity<Guid>, IIrFieldsConverterable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_fields.py, METHOD: _get_boolean_translations) ---
            */
            return default;
        }

        public async Task<TEntity> GetImportFieldPathInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, object @value) where TEntity : IEntity<Guid>, IIrFieldsConverterable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_fields.py, METHOD: _get_import_field_path) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetSelectionTranslationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, object src) where TEntity : IEntity<Guid>, IIrFieldsConverterable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_fields.py, METHOD: _get_selection_translations) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> InputTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrFieldsConverterable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_fields.py, METHOD: _input_tz) ---
            */
            return default;
        }

        public async Task<TEntity> ReferencingSubfieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record) where TEntity : IEntity<Guid>, IIrFieldsConverterable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_fields.py, METHOD: _referencing_subfield) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> StrIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object @value, object savepoint) where TEntity : IEntity<Guid>, IIrFieldsConverterable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_fields.py, METHOD: _str_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> StrToBooleanInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object @value, object savepoint) where TEntity : IEntity<Guid>, IIrFieldsConverterable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_fields.py, METHOD: _str_to_boolean) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> StrToDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object @value, object savepoint) where TEntity : IEntity<Guid>, IIrFieldsConverterable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_fields.py, METHOD: _str_to_date) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> StrToDatetimeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object @value, object savepoint) where TEntity : IEntity<Guid>, IIrFieldsConverterable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_fields.py, METHOD: _str_to_datetime) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> StrToFloatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object @value, object savepoint) where TEntity : IEntity<Guid>, IIrFieldsConverterable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_fields.py, METHOD: _str_to_float) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> StrToIntegerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object @value, object savepoint) where TEntity : IEntity<Guid>, IIrFieldsConverterable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_fields.py, METHOD: _str_to_integer) ---
            */
            return default;
        }

        public async Task<TEntity> StrToJsonInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object @value, object savepoint) where TEntity : IEntity<Guid>, IIrFieldsConverterable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_fields.py, METHOD: _str_to_json) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> StrToMany2manyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object @value, object savepoint) where TEntity : IEntity<Guid>, IIrFieldsConverterable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_fields.py, METHOD: _str_to_many2many) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> StrToMany2oneInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object values, object savepoint) where TEntity : IEntity<Guid>, IIrFieldsConverterable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_fields.py, METHOD: _str_to_many2one) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> StrToMany2oneReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object @value, object savepoint) where TEntity : IEntity<Guid>, IIrFieldsConverterable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_fields.py, METHOD: _str_to_many2one_reference) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> StrToOne2manyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object records, object savepoint) where TEntity : IEntity<Guid>, IIrFieldsConverterable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_fields.py, METHOD: _str_to_one2many) ---
            */
            return default;
        }

        public async Task<TEntity> StrToPropertiesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object @value, object savepoint) where TEntity : IEntity<Guid>, IIrFieldsConverterable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_fields.py, METHOD: _str_to_properties) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> StrToSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object @value, object savepoint) where TEntity : IEntity<Guid>, IIrFieldsConverterable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_fields.py, METHOD: _str_to_selection) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ToFieldAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object fromtype) where TEntity : IEntity<Guid>, IIrFieldsConverterable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_fields.py, METHOD: to_field) ---
            */
            return default;
        }

        public async Task<TEntity> XmlidToRecordIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object xmlid, object model) where TEntity : IEntity<Guid>, IIrFieldsConverterable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_fields.py, METHOD: _xmlid_to_record_id) ---
            */
            return default;
        }
    }
}