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
    public interface IBaseGeocoderAppService : IMixinAppService
    {
        Task<TEntity> CallGooglemapInternalAsync<TEntity>(IEnumerable<TEntity> entities, object addr) where TEntity : IEntity<Guid>, IBaseGeocoderable;
        Task<TEntity> CallOpenstreetmapInternalAsync<TEntity>(IEnumerable<TEntity> entities, object addr) where TEntity : IEntity<Guid>, IBaseGeocoderable;
        Task<TEntity> GeoFindAsync<TEntity>(IEnumerable<TEntity> entities, object addr) where TEntity : IEntity<Guid>, IBaseGeocoderable;
        Task<TEntity> GeoQueryAddressAsync<TEntity>(IEnumerable<TEntity> entities, object street, object zip, object city, object state, object country) where TEntity : IEntity<Guid>, IBaseGeocoderable;
        Task<TEntity> GeoQueryAddressDefaultInternalAsync<TEntity>(IEnumerable<TEntity> entities, object street, object zip, object city, object state, object country) where TEntity : IEntity<Guid>, IBaseGeocoderable;
        Task<TEntity> GeoQueryAddressGooglemapInternalAsync<TEntity>(IEnumerable<TEntity> entities, object street, object zip, object city, object state, object country) where TEntity : IEntity<Guid>, IBaseGeocoderable;
        Task<TEntity> GetProviderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseGeocoderable;
        Task<TEntity> RaiseQueryErrorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object error) where TEntity : IEntity<Guid>, IBaseGeocoderable;
    }
}