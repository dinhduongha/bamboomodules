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
    public interface IIrWebsocketAppService : IMixinAppService
    {
        Task<TEntity> AfterSubscribeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IIrWebsocketable;
        Task<TEntity> BuildBusChannelListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object channels) where TEntity : IEntity<Guid>, IIrWebsocketable;
        Task<TEntity> OnWebsocketClosedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object cookies) where TEntity : IEntity<Guid>, IIrWebsocketable;
        Task<TEntity> PrepareSubscribeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object channels, object last) where TEntity : IEntity<Guid>, IIrWebsocketable;
        Task<TEntity> ServeIrWebsocketInternalAsync<TEntity>(IEnumerable<TEntity> entities, object event_name, object data) where TEntity : IEntity<Guid>, IIrWebsocketable;
        Task<TEntity> SubscribeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object og_data) where TEntity : IEntity<Guid>, IIrWebsocketable;
        Task<TEntity> UpdateMailPresenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object inactivity_period) where TEntity : IEntity<Guid>, IIrWebsocketable;
    }
}