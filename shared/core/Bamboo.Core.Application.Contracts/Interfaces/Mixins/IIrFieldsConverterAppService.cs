using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
namespace Bamboo.Core.Application.Contracts.Interfaces.Mixins
{
    public interface IIrFieldsConverterAppService : IMixinAppService
    {
        Task<TEntity> DbIdForAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object subfield, object @value) where TEntity : IEntity<Guid>, IIrFieldsConverterable;
        Task<TEntity> ForModelAsync<TEntity>(IEnumerable<TEntity> entities, object model, object fromtype) where TEntity : IEntity<Guid>, IIrFieldsConverterable;
        Task<TEntity> FormatImportErrorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object error_type, object error_msg, object error_params, object error_args) where TEntity : IEntity<Guid>, IIrFieldsConverterable;
        Task<TEntity> GetBooleanTranslationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object src) where TEntity : IEntity<Guid>, IIrFieldsConverterable;
        Task<TEntity> GetImportFieldPathInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, object @value) where TEntity : IEntity<Guid>, IIrFieldsConverterable;
        Task<TEntity> GetSelectionTranslationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, object src) where TEntity : IEntity<Guid>, IIrFieldsConverterable;
        Task<TEntity> InputTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrFieldsConverterable;
        Task<TEntity> ReferencingSubfieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record) where TEntity : IEntity<Guid>, IIrFieldsConverterable;
        Task<TEntity> StrIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object @value) where TEntity : IEntity<Guid>, IIrFieldsConverterable;
        Task<TEntity> StrToBooleanInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object @value) where TEntity : IEntity<Guid>, IIrFieldsConverterable;
        Task<TEntity> StrToDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object @value) where TEntity : IEntity<Guid>, IIrFieldsConverterable;
        Task<TEntity> StrToDatetimeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object @value) where TEntity : IEntity<Guid>, IIrFieldsConverterable;
        Task<TEntity> StrToFloatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object @value) where TEntity : IEntity<Guid>, IIrFieldsConverterable;
        Task<TEntity> StrToIntegerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object @value) where TEntity : IEntity<Guid>, IIrFieldsConverterable;
        Task<TEntity> StrToJsonInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object @value) where TEntity : IEntity<Guid>, IIrFieldsConverterable;
        Task<TEntity> StrToMany2manyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object @value) where TEntity : IEntity<Guid>, IIrFieldsConverterable;
        Task<TEntity> StrToMany2oneInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object values) where TEntity : IEntity<Guid>, IIrFieldsConverterable;
        Task<TEntity> StrToMany2oneReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object @value) where TEntity : IEntity<Guid>, IIrFieldsConverterable;
        Task<TEntity> StrToOne2manyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object records) where TEntity : IEntity<Guid>, IIrFieldsConverterable;
        Task<TEntity> StrToPropertiesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object @value) where TEntity : IEntity<Guid>, IIrFieldsConverterable;
        Task<TEntity> StrToSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object @value) where TEntity : IEntity<Guid>, IIrFieldsConverterable;
        Task<TEntity> ToFieldAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object fromtype) where TEntity : IEntity<Guid>, IIrFieldsConverterable;
        Task<TEntity> XmlidToRecordIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object xmlid, object model) where TEntity : IEntity<Guid>, IIrFieldsConverterable;
    }
}