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
    public interface IIrQwebFieldImageAppService : IMixinAppService
    {
        Task<TEntity> FromHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object element) where TEntity : IEntity<Guid>, IIrQwebFieldImageable;
        Task<TEntity> GetSrcDataB64InternalAsync<TEntity>(IEnumerable<TEntity> entities, object @value, object options) where TEntity : IEntity<Guid>, IIrQwebFieldImageable;
        Task<TEntity> GetSrcUrlsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field_name, object options) where TEntity : IEntity<Guid>, IIrQwebFieldImageable;
        Task<TEntity> LoadLocalUrlAsync<TEntity>(IEnumerable<TEntity> entities, object url) where TEntity : IEntity<Guid>, IIrQwebFieldImageable;
        Task<TEntity> LoadRemoteUrlAsync<TEntity>(IEnumerable<TEntity> entities, object url) where TEntity : IEntity<Guid>, IIrQwebFieldImageable;
        Task<TEntity> RecordToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field_name, object options) where TEntity : IEntity<Guid>, IIrQwebFieldImageable;
        Task<TEntity> ValueToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object @value, object options) where TEntity : IEntity<Guid>, IIrQwebFieldImageable;
    }
}