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
    public interface IIrWebsocketAppService : IMixinAppService
    {
        Task<TEntity> BuildBusChannelListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object channels) where TEntity : IEntity<Guid>, IIrWebsocketable;
        Task<TEntity> BuildPresenceChannelListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object presences) where TEntity : IEntity<Guid>, IIrWebsocketable;
        Task<TEntity> GetMissedPresencesBusTargetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrWebsocketable;
        Task<TEntity> GetMissedPresencesIdentityDomainsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object presence_channels) where TEntity : IEntity<Guid>, IIrWebsocketable;
        Task<TEntity> OnWebsocketClosedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object cookies) where TEntity : IEntity<Guid>, IIrWebsocketable;
        Task<TEntity> PrepareSubscribeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object channels, object last) where TEntity : IEntity<Guid>, IIrWebsocketable;
        Task<TEntity> SubscribeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object og_data) where TEntity : IEntity<Guid>, IIrWebsocketable;
        Task<TEntity> UpdateBusPresenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object inactivity_period, object im_status_ids_by_model) where TEntity : IEntity<Guid>, IIrWebsocketable;
    }
}