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
    public interface IIapAutocompleteApiAppService : IMixinAppService
    {
        Task<TEntity> ContactIapInternalAsync<TEntity>(IEnumerable<TEntity> entities, object local_endpoint, object action, object @params, object timeout) where TEntity : IEntity<Guid>, IIapAutocompleteApiable;
        Task<TEntity> RequestPartnerAutocompleteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object action, object @params, object timeout) where TEntity : IEntity<Guid>, IIapAutocompleteApiable;
    }
}