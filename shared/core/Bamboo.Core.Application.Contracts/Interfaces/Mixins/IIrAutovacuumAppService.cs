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
    public interface IIrAutovacuumAppService : IMixinAppService
    {
        Task<TEntity> RunVacuumCleanerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrAutovacuumable;
    }
}