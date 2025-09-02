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
    public interface IStockReplenishMixinAppService : IMixinAppService
    {
        Task<TEntity> ComputeAllowedRouteIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IStockReplenishMixinable;
        Task<TEntity> ComputeShowBomInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IStockReplenishMixinable;
        Task<TEntity> ComputeShowVendorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IStockReplenishMixinable;
        Task<TEntity> GetAllowedRouteDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IStockReplenishMixinable;
        Task<TEntity> GetShowBomInternalAsync<TEntity>(IEnumerable<TEntity> entities, object route) where TEntity : IEntity<Guid>, IStockReplenishMixinable;
        Task<TEntity> GetShowVendorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object route) where TEntity : IEntity<Guid>, IStockReplenishMixinable;
    }
}