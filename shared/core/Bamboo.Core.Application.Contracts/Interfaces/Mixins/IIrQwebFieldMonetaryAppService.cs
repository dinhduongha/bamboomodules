using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
namespace Bamboo.Core.Application.Contracts.Interfaces.Mixins
{
    public interface IIrQwebFieldMonetaryAppService : IMixinAppService
    {
        Task<TEntity> FromHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object element) where TEntity : IEntity<Guid>, IIrQwebFieldMonetaryable;
        Task<TEntity> GetAvailableOptionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrQwebFieldMonetaryable;
        Task<TEntity> RecordToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field_name, object options) where TEntity : IEntity<Guid>, IIrQwebFieldMonetaryable;
        Task<TEntity> ValueToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object @value, object options) where TEntity : IEntity<Guid>, IIrQwebFieldMonetaryable;
    }
}