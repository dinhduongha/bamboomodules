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
    public interface IIrQwebFieldContactAppService : IMixinAppService
    {
        Task<TEntity> AttributesAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field_name, object options, object values) where TEntity : IEntity<Guid>, IIrQwebFieldContactable;
        Task<TEntity> GetAvailableOptionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrQwebFieldContactable;
        Task<TEntity> GetRecordToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> contact_ids, object options) where TEntity : IEntity<Guid>, IIrQwebFieldContactable;
        Task<TEntity> ValueToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object @value, object options) where TEntity : IEntity<Guid>, IIrQwebFieldContactable;
    }
}