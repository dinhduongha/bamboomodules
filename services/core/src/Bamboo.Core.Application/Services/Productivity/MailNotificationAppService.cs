using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Mail", Category = "Productivity", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
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

        public override async Task<Dictionary<string, Dictionary<string, object>>> FieldsGetAsync(List<string> fields = null, Dictionary<string, List<string>> attributes = null)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms_twilio, FILE: mail_notification.py) ---
            // def fields_get(self, allfields=None, attributes=None):
            // # As we are adding keys in stable, better be sure no-one is getting crashes
            // # due to missing translations
            // # TODO: remove in master
            // res = super().fields_get(allfields=allfields, attributes=attributes)
            // 
            // existing_selection = res.get('failure_type', {}).get('selection')
            // if existing_selection is None:
            //     return res
            // 
            // updated_stable = {
            //     'twilio_authentication', 'twilio_callback',
            //     'twilio_from_missing', 'twilio_from_to',
            // }
            // need_update = updated_stable - set(dict(self._fields['failure_type'].selection))
            // if need_update:
            //     self.env['ir.model.fields'].invalidate_model(['selection_ids'])
            //     self.env['ir.model.fields.selection']._update_selection(
            //         self._name,
            //         'failure_type',
            //         self._fields['failure_type'].selection,
            //     )
            //     self.env.registry.clear_cache()
            //     return super().fields_get(allfields=allfields, attributes=attributes)
            // 
            // return res
            */
            return await base.FieldsGetAsync(fields, attributes);
        }

        protected async Task<MailNotification> FilteredForWebClientInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_notification.py) ---
            // def _filtered_for_web_client(self):
            // """Returns only the notifications to show on the web client."""
            // def _filter_unimportant_notifications(notif):
            //     if notif.notification_status in ['bounce', 'exception', 'canceled'] \
            //             or notif.res_partner_id.partner_share or notif.mail_email_address:
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
            // records = self.search(domain, limit=GC_UNLINK_LIMIT)
            // records.unlink()
            // return len(records), len(records) == GC_UNLINK_LIMIT
            */
            return default;
        }

        protected async Task<MailNotification> ToStoreDefaultsInternalAsync(object target)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_notification.py) ---
            // def _to_store_defaults(self, target):
            // return [
            //     "mail_email_address",
            //     "failure_type",
            //     "mail_message_id",
            //     "notification_status",
            //     "notification_type",
            //     Store.One(
            //         "res_partner_id",
            //         [
            //             "name",
            //             "email",
            //             Store.Attr("display_name", predicate=lambda p: not p.name),
            //         ],
            //     ),
            // ]
            */
            return default;
        }
    }
}