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
    public interface IMaintenanceMixinAppService : IMixinAppService
    {
        Task<TEntity> ActionOpenMatchedSerialAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMaintenanceMixinable;
        Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMaintenanceMixinable;
        Task<TEntity> ComputeMaintenanceCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMaintenanceMixinable;
        Task<TEntity> ComputeMaintenanceRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMaintenanceMixinable;
        Task<TEntity> ComputeMaintenanceTeamIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMaintenanceMixinable;
        Task<TEntity> ComputeMatchSerialInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMaintenanceMixinable;
        Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMaintenanceMixinable;
        Task<TEntity> OnchangeCategoryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMaintenanceMixinable;
        Task<TEntity> ReadGroupCategoryIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object categories, object domain) where TEntity : IEntity<Guid>, IMaintenanceMixinable;
        Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IMaintenanceMixinable;
        Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMaintenanceMixinable;
    }
}