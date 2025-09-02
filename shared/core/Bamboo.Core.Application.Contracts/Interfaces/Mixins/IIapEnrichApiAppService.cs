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
    public interface IIapEnrichApiAppService : IMixinAppService
    {
        Task<TEntity> ContactIapInternalAsync<TEntity>(IEnumerable<TEntity> entities, object local_endpoint, object @params) where TEntity : IEntity<Guid>, IIapEnrichApiable;
        Task<TEntity> RequestEnrichInternalAsync<TEntity>(IEnumerable<TEntity> entities, object lead_emails) where TEntity : IEntity<Guid>, IIapEnrichApiable;
    }
}