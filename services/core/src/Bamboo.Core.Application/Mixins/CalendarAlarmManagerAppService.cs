using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("calendar", Category = "Productivity", Depends = new[] { "base", "mail" })]
    public partial class CalendarAlarmManagerAppService : ApplicationService, ICalendarAlarmManagerAppService
    {

        public CalendarAlarmManagerAppService() 
        {

        }

        public async Task<TEntity> DoCheckAlarmForOneDateAsync<TEntity>(IEnumerable<TEntity> entities, object one_date, object @event, object event_maxdelta, object in_the_next_X_seconds, object alarm_type, object after, object missing) where TEntity : IEntity<Guid>, ICalendarAlarmManagerable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_alarm_manager.py, METHOD: do_check_alarm_for_one_date) ---
            */
            return default;
        }

        public async Task<TEntity> DoNotifReminderAsync<TEntity>(IEnumerable<TEntity> entities, object alert) where TEntity : IEntity<Guid>, ICalendarAlarmManagerable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_alarm_manager.py, METHOD: do_notif_reminder) ---
            */
            return default;
        }

        public async Task<TEntity> GetEventsByAlarmToNotifyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object alarm_type) where TEntity : IEntity<Guid>, ICalendarAlarmManagerable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_alarm_manager.py, METHOD: _get_events_by_alarm_to_notify) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetNextNotifAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ICalendarAlarmManagerable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_alarm_manager.py, METHOD: get_next_notif) ---
            */
            return default;
        }

        public async Task<TEntity> GetNextPotentialLimitAlarmInternalAsync<TEntity>(IEnumerable<TEntity> entities, object alarm_type, object seconds, object partners) where TEntity : IEntity<Guid>, ICalendarAlarmManagerable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_alarm_manager.py, METHOD: _get_next_potential_limit_alarm) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetNotifyAlertExtraConditionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ICalendarAlarmManagerable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_alarm_manager.py, METHOD: _get_notify_alert_extra_conditions) ---
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar_alarm_manager.py, METHOD: _get_notify_alert_extra_conditions) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_alarm_manager.py, METHOD: _get_notify_alert_extra_conditions) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyNextAlarmInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, ICalendarAlarmManagerable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_alarm_manager.py, METHOD: _notify_next_alarm) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SendReminderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ICalendarAlarmManagerable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_alarm_manager.py, METHOD: _send_reminder) ---
            --- METHOD SOURCE (MODULE: calendar_sms, FILE: calendar_alarm_manager.py, METHOD: _send_reminder) ---
            */
            return default;
        }
    }
}