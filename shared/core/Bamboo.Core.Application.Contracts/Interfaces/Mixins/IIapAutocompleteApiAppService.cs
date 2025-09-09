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
    public interface IIapAutocompleteApiAppService : IMixinAppService
    {
        Task<TEntity> ContactIapInternalAsync<TEntity>(IEnumerable<TEntity> entities, object local_endpoint, object action, object @params, object timeout) where TEntity : IEntity<Guid>, IIapAutocompleteApiable;
        Task<TEntity> RequestPartnerAutocompleteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object action, object @params, object timeout) where TEntity : IEntity<Guid>, IIapAutocompleteApiable;
    }
}