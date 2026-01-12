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
    public interface IKpiProviderAppService : IMixinAppService
    {
        Task<TEntity> GetAccountKpiSummaryAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IKpiProviderable;
        Task<TEntity> GetKpiSummaryAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IKpiProviderable;
    }
}