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
    public interface ICalendarAlarmManagerAppService : IMixinAppService
    {
        Task<TEntity> DoCheckAlarmForOneDateAsync<TEntity>(IEnumerable<TEntity> entities, object one_date, object @event, object event_maxdelta, object in_the_next_X_seconds, object alarm_type, object after, object missing) where TEntity : IEntity<Guid>, ICalendarAlarmManagerable;
        Task<TEntity> DoNotifReminderAsync<TEntity>(IEnumerable<TEntity> entities, object alert) where TEntity : IEntity<Guid>, ICalendarAlarmManagerable;
        Task<TEntity> GetEventsByAlarmToNotifyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object alarm_type) where TEntity : IEntity<Guid>, ICalendarAlarmManagerable;
        Task<TEntity> GetNextNotifAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ICalendarAlarmManagerable;
        Task<TEntity> GetNextPotentialLimitAlarmInternalAsync<TEntity>(IEnumerable<TEntity> entities, object alarm_type, object seconds, object partners) where TEntity : IEntity<Guid>, ICalendarAlarmManagerable;
        Task<TEntity> GetNotifyAlertExtraConditionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ICalendarAlarmManagerable;
        Task<TEntity> NotifyNextAlarmInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, ICalendarAlarmManagerable;
        Task<TEntity> SendReminderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ICalendarAlarmManagerable;
    }
}