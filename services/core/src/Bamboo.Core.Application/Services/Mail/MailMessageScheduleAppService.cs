using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Bamboo.Core.Application.Services
{
    [Module("Mail", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public class MailMessageScheduleAppService : GenericApplicationService<MailMessageSchedule>, IMailMessageScheduleAppService
    {

        public MailMessageScheduleAppService(IRepository<MailMessageSchedule, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<MailMessageSchedule> ForceSendAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message_schedule.py) ---
            // def force_send(self):
            // """ Launch notification process independently from the expected date. """
            // return self._send_notifications()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MailMessageSchedule> GroupByModelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message_schedule.py) ---
            // def _group_by_model(self):
            // grouped = {}
            // for schedule in self:
            //     model = schedule.mail_message_id.model if schedule.mail_message_id.model and schedule.mail_message_id.res_id else False
            //     if model not in grouped:
            //         grouped[model] = schedule
            //     else:
            //         grouped[model] += schedule
            // return grouped
            */
            return default;
        }

        protected async Task<MailMessageSchedule> SendMessageNotificationsInternalAsync(object messages, object default_notify_kwargs)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message_schedule.py) ---
            // def _send_message_notifications(self, messages, default_notify_kwargs=None):
            // """ Send scheduled notification for given messages.
            // 
            // :param <mail.message> messages: scheduled sending related to those messages
            //   will be sent now;
            // :param dict default_notify_kwargs: optional parameters to propagate to
            //   ``notify_thread``. Those are default values overridden by content of
            //   ``notification_parameters`` field.
            // 
            // :return bool: False if no schedule has been found, True otherwise
            // """
            // messages_scheduled = self.search(
            //     [('mail_message_id', 'in', messages.ids)]
            // )
            // if not messages_scheduled:
            //     return False
            // 
            // messages_scheduled._send_notifications(default_notify_kwargs=default_notify_kwargs)
            // return True
            */
            return default;
        }

        protected async Task<MailMessageSchedule> SendNotificationsCronInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message_schedule.py) ---
            // def _send_notifications_cron(self):
            // messages_scheduled = self.env['mail.message.schedule'].search(
            //     [('scheduled_datetime', '<=', datetime.utcnow())]
            // )
            // if messages_scheduled:
            //     _logger.info('Send %s scheduled messages', len(messages_scheduled))
            //     messages_scheduled._send_notifications()
            */
            return default;
        }

        protected async Task<MailMessageSchedule> SendNotificationsInternalAsync(object default_notify_kwargs)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message_schedule.py) ---
            // def _send_notifications(self, default_notify_kwargs=None):
            // """ Send notification for scheduled messages.
            // 
            // :param dict default_notify_kwargs: optional parameters to propagate to
            //   ``notify_thread``. Those are default values overridden by content of
            //   ``notification_parameters`` field.
            // """
            // for model, schedules in self._group_by_model().items():
            //     if model:
            //         records = self.env[model].browse(schedules.mapped('mail_message_id.res_id'))
            //     else:
            //         records = [self.env['mail.thread']] * len(schedules)
            // 
            //     for record, schedule in zip(records, schedules):
            //         notify_kwargs = dict(default_notify_kwargs or {}, skip_existing=True)
            //         try:
            //             schedule_notify_kwargs = json.loads(schedule.notification_parameters)
            //         except Exception:
            //             pass
            //         else:
            //             schedule_notify_kwargs.pop('scheduled_date', None)
            //             notify_kwargs.update(schedule_notify_kwargs)
            // 
            //         record._notify_thread(schedule.mail_message_id, msg_vals=False, **notify_kwargs)
            // 
            // self.unlink()
            // return True
            */
            return default;
        }

        protected async Task<MailMessageSchedule> UpdateMessageScheduledDatetimeInternalAsync(object messages, object new_datetime)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message_schedule.py) ---
            // def _update_message_scheduled_datetime(self, messages, new_datetime):
            // """ Update scheduled datetime for scheduled sending related to messages.
            // 
            // :param <mail.message> messages: scheduled sending related to those messages
            //   will be updated. Missing one are skipped;
            // :param datetime new_datetime: new datetime for sending. New triggers
            //   are created based on it;
            // 
            // :return bool: False if no schedule has been found, True otherwise
            // """
            // messages_scheduled = self.search(
            //     [('mail_message_id', 'in', messages.ids)]
            // )
            // if not messages_scheduled:
            //     return False
            // 
            // messages_scheduled.scheduled_datetime = new_datetime
            // self.env.ref('mail.ir_cron_send_scheduled_message')._trigger(new_datetime)
            // return True
            */
            return default;
        }
    }
}