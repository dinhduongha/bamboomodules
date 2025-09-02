using Volo.Abp.Application.Services;
using System.Linq;
using Volo.Abp.Domain.Entities;
using System.Collections.Generic;
using Bamboo.Core.Domain.Shared.Interfaces;
using System;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using System.Threading.Tasks;
namespace Bamboo.Core.Application.Contracts.Interfaces.Mixins
{
    public interface IIrBinaryAppService : IMixinAppService
    {
        Task<TEntity> FindRecordCheckAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object access_token, object field) where TEntity : IEntity<Guid>, IIrBinaryable;
        Task<TEntity> FindRecordInternalAsync<TEntity>(IEnumerable<TEntity> entities, object xmlid, object res_model, Guid res_id, object access_token, object field) where TEntity : IEntity<Guid>, IIrBinaryable;
        Task<TEntity> GetImageStreamFromInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field_name, object filename, object filename_field, object mimetype, object default_mimetype, object placeholder, object width, object height, object crop, object quality) where TEntity : IEntity<Guid>, IIrBinaryable;
        Task<TEntity> GetPlaceholderStreamInternalAsync<TEntity>(IEnumerable<TEntity> entities, object path) where TEntity : IEntity<Guid>, IIrBinaryable;
        Task<TEntity> GetStreamFromInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field_name, object filename, object filename_field, object mimetype, object default_mimetype) where TEntity : IEntity<Guid>, IIrBinaryable;
        Task<TEntity> PlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object path) where TEntity : IEntity<Guid>, IIrBinaryable;
        Task<TEntity> RecordToStreamInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field_name) where TEntity : IEntity<Guid>, IIrBinaryable;
    }
}