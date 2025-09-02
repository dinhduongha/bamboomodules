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