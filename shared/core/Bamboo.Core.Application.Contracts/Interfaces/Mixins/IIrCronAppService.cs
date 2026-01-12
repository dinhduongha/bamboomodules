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
    public interface IIrCronAppService : IMixinAppService
    {
        Task<TEntity> ActionOpenAutomationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrCronable;
        Task<TEntity> ActionOpenParentActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrCronable;
        Task<TEntity> ActionOpenScheduledActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrCronable;
        Task<TEntity> AddProgressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrCronable;
        Task<TEntity> CallbackInternalAsync<TEntity>(IEnumerable<TEntity> entities, object cron_name, Guid server_action_id) where TEntity : IEntity<Guid>, IIrCronable;
        Task<TEntity> ClearScheduleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object job) where TEntity : IEntity<Guid>, IIrCronable;
        Task<float> CommitProgressInternalAsync<TEntity>(IEnumerable<TEntity> entities, int processed) where TEntity : IEntity<Guid>, IIrCronable;
        Task<TEntity> ComputeCronNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrCronable;
        Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IIrCronable;
        Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IIrCronable;
        Task<TEntity> MethodDirectTriggerAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrCronable;
        Task<TEntity> NotifyAdminInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message) where TEntity : IEntity<Guid>, IIrCronable;
        Task<TEntity> NotifyProgressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrCronable;
        Task<TEntity> NotifydbInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrCronable;
        Task<TEntity> RescheduleAsapInternalAsync<TEntity>(IEnumerable<TEntity> entities, Dictionary<string, object> job) where TEntity : IEntity<Guid>, IIrCronable;
        Task<TEntity> RescheduleLaterInternalAsync<TEntity>(IEnumerable<TEntity> entities, Dictionary<string, object> job) where TEntity : IEntity<Guid>, IIrCronable;
        Task<TEntity> ToggleAsync<TEntity>(IEnumerable<TEntity> entities, object model, object domain) where TEntity : IEntity<Guid>, IIrCronable;
        Task<TEntity> TriggerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object at) where TEntity : IEntity<Guid>, IIrCronable;
        Task<TEntity> TriggerListInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<DateTime> at_list) where TEntity : IEntity<Guid>, IIrCronable;
        Task<TEntity> UnlinkUnlessRunningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrCronable;
        Task<TEntity> UpdateFailureCountInternalAsync<TEntity>(IEnumerable<TEntity> entities, Dictionary<string, object> job, object status) where TEntity : IEntity<Guid>, IIrCronable;
        Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IIrCronable;
    }
}