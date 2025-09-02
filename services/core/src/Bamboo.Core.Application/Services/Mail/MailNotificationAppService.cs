using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
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
    public class MailNotificationAppService : GenericApplicationService<MailNotification>, IMailNotificationAppService
    {

        public MailNotificationAppService(IRepository<MailNotification, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<MailNotification> ComputeSmsIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: mail_notification.py) ---
            // def _compute_sms_id(self):
            // self.sms_id = False
            // sms_notifications = self.filtered(lambda n: n.notification_type == 'sms' and bool(n.sms_id_int))
            // if not sms_notifications:
            //     return
            // existing_sms_ids = self.env['sms.sms'].sudo().search([
            //     ('id', 'in', sms_notifications.mapped('sms_id_int')), ('to_delete', '!=', True)
            // ]).ids
            // for sms_notification in sms_notifications.filtered(lambda n: n.sms_id_int in set(existing_sms_ids)):
            //     sms_notification.sms_id = sms_notification.sms_id_int
            */
            return default;
        }

        protected async Task<MailNotification> FilteredForWebClientInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_notification.py) ---
            // def _filtered_for_web_client(self):
            // """Returns only the notifications to show on the web client."""
            // def _filter_unimportant_notifications(notif):
            //     if notif.notification_status in ['bounce', 'exception', 'canceled'] \
            //             or notif.res_partner_id.partner_share:
            //         return True
            //     subtype = notif.mail_message_id.subtype_id
            //     return not subtype or subtype.track_recipients
            // 
            // return self.filtered(_filter_unimportant_notifications)
            */
            return default;
        }

        public async Task<MailNotification> FormatFailureReasonAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_notification.py) ---
            // def format_failure_reason(self):
            // self.ensure_one()
            // if self.failure_type != 'unknown':
            //     return dict(self._fields['failure_type'].selection).get(self.failure_type, _('No Error'))
            // else:
            //     if self.failure_reason:
            //         return _("Unknown error: %(error)s", error=self.failure_reason)
            //     return _("Unknown error")
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MailNotification> GcNotificationsInternalAsync(object max_age_days)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_notification.py) ---
            // def _gc_notifications(self, max_age_days=180):
            // domain = [
            //     ('is_read', '=', True),
            //     ('read_date', '<', fields.Datetime.now() - relativedelta(days=max_age_days)),
            //     ('res_partner_id.partner_share', '=', False),
            //     ('notification_status', 'in', ('sent', 'canceled'))
            // ]
            // records = self.search(domain, limit=models.GC_UNLINK_LIMIT)
            // if len(records) >= models.GC_UNLINK_LIMIT:
            //     self.env.ref('base.autovacuum_job')._trigger()
            // return records.unlink()
            */
            return default;
        }

        public async Task<MailNotification> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_notification.py) ---
            // def init(self):
            // self._cr.execute("""
            //     CREATE INDEX IF NOT EXISTS mail_notification_res_partner_id_is_read_notification_status_mail_message_id
            //                             ON mail_notification (res_partner_id, is_read, notification_status, mail_message_id);
            //     CREATE INDEX IF NOT EXISTS mail_notification_author_id_notification_status_failure
            //                             ON mail_notification (author_id, notification_status)
            //                          WHERE notification_status IN ('bounce', 'exception');
            // """)
            // self.env.cr.execute(
            //     """CREATE UNIQUE INDEX IF NOT EXISTS unique_mail_message_id_res_partner_id_if_set
            //                                       ON %s (mail_message_id, res_partner_id)
            //                                    WHERE res_partner_id IS NOT NULL""" % self._table
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MailNotification> ToStoreInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_notification.py) ---
            // def _to_store(self, store: Store, /):
            // """Returns the current notifications in the format expected by the web
            // client."""
            // for notif in self:
            //     data = notif._read_format(
            //         ["failure_type", "notification_status", "notification_type"], load=False
            //     )[0]
            //     data["message"] = Store.one(notif.mail_message_id, only_id=True)
            //     data["persona"] = Store.one(notif.res_partner_id, fields=["name"])
            //     store.add(notif, data)
            */
            return default;
        }
    }
}