using System;
using System.Threading.Tasks;
using System.Collections.Generic;
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
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Services
{
    public partial class MailMessageScheduleAppService
    {

        protected async Task<MailMessageSchedule> GroupByModelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message_schedule.py, METHOD: _group_by_model) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailMessageSchedule> SendMessageNotificationsInternalAsync(object messages, object default_notify_kwargs)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message_schedule.py, METHOD: _send_message_notifications) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailMessageSchedule> SendNotificationsCronInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message_schedule.py, METHOD: _send_notifications_cron) ---
            */
            return default;
        }

        protected async Task<MailMessageSchedule> SendNotificationsInternalAsync(object default_notify_kwargs)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message_schedule.py, METHOD: _send_notifications) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailMessageSchedule> UpdateMessageScheduledDatetimeInternalAsync(object messages, object new_datetime)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message_schedule.py, METHOD: _update_message_scheduled_datetime) ---
            */
            return default;
        }
    }
}