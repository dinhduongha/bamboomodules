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
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Sms", Category = "Sales", Depends = new[] { "base", "iap_mail", "mail", "phone_validation" })]
    public partial class SmsSmsAppService : GenericApplicationService<SmsSms>, ISmsSmsAppService
    {

        public SmsSmsAppService(IRepository<SmsSms, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        protected async Task<SmsSms> ComputeSmsTrackerIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_sms.py) ---
            // def _compute_sms_tracker_id(self):
            // self.sms_tracker_id = False
            // existing_trackers = self.env['sms.tracker'].search([('sms_uuid', 'in', self.filtered('uuid').mapped('uuid'))])
            // tracker_ids_by_sms_uuid = {tracker.sms_uuid: tracker.id for tracker in existing_trackers}
            // for sms in self.filtered(lambda s: s.uuid in tracker_ids_by_sms_uuid):
            //     sms.sms_tracker_id = tracker_ids_by_sms_uuid[sms.uuid]
            */
            return default;
        }

        public override async Task<SmsSms> CreateAsync(SmsSms entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_sms.py) ---
            // def create(self, vals_list):
            // self.env.ref('sms.ir_cron_sms_scheduler_action')._trigger()
            // return super().create(vals_list)
            --- ODOO METHOD SOURCE (MODULE: sms_twilio, FILE: sms_sms.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     vals['record_company_id'] = vals.get('record_company_id') or self.env.company.id  # TODO RIGR in master: move this field to SmsSms, and populate it via vals_list from all flows
            // return super().create(vals_list)
            */
            return await base.CreateAsync(entity, fields);
        }

        public override async Task<Dictionary<string, Dictionary<string, object>>> FieldsGetAsync(List<string> fields = null, Dictionary<string, List<string>> attributes = null)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms_twilio, FILE: sms_sms.py) ---
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
            // updated_stable = {'twilio_from_missing', 'twilio_from_to'}
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

        protected async Task<SmsSms> GcDeviceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_sms.py) ---
            // def _gc_device(self):
            // self.env.cr.execute("DELETE FROM sms_sms WHERE to_delete = TRUE")
            // _logger.info("GC'd %d sms marked for deletion", self.env.cr.rowcount)
            */
            return default;
        }

        protected async Task<SmsSms> GetSendBatchSizeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_sms.py) ---
            // def _get_send_batch_size(self):
            // return int(self.env['ir.config_parameter'].sudo().get_param('sms.session.batch.size', 500))
            --- ODOO METHOD SOURCE (MODULE: sms_twilio, FILE: sms_sms.py) ---
            // def _get_send_batch_size(self):
            // companies = self._get_sms_company()
            // if companies and any(company.sms_provider == 'twilio' for company in companies):
            //     return int(self.env['ir.config_parameter'].sudo().get_param('sms_twilio.session.batch.size', 10))
            // return super()._get_send_batch_size()
            */
            return default;
        }

        protected async Task<SmsSms> GetSmsCompanyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_sms.py) ---
            // def _get_sms_company(self):
            // return self.mail_message_id.record_company_id or self.env.company
            --- ODOO METHOD SOURCE (MODULE: sms_twilio, FILE: sms_sms.py) ---
            // def _get_sms_company(self):
            // return self.mail_message_id.record_company_id or self.record_company_id or super()._get_sms_company()
            */
            return default;
        }

        protected async Task<SmsSms> HandleCallResultHookInternalAsync(object results)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_sms.py) ---
            // def _handle_call_result_hook(self, results):
            // """Further process SMS sending API results."""
            // pass
            --- ODOO METHOD SOURCE (MODULE: sms_twilio, FILE: sms_sms.py) ---
            // def _handle_call_result_hook(self, results):
            // """
            // Store the sid of Twilio on the SMS tracking record (as SMS will be deleted)
            // :param results: a list of dict in the form [{
            //     'uuid': Odoo's id of the SMS,
            //     'state': State of the SMS in Odoo,
            //     'sms_twilio_sid': Twilio's id of the SMS,
            // }, ...]
            // """
            // twilio_sms = self.filtered(lambda s: s._get_sms_company().sms_provider == 'twilio')
            // grouped_twilio_sms = twilio_sms.grouped("uuid")
            // for result in results:
            //     sms = grouped_twilio_sms.get(result.get('uuid'))
            //     if sms and sms.sms_tracker_id and result.get('sms_twilio_sid'):
            //         sms.sms_tracker_id.sms_twilio_sid = result['sms_twilio_sid']
            // super(SmsSms, self - twilio_sms)._handle_call_result_hook(results)
            */
            return default;
        }

        protected async Task<SmsSms> ProcessQueueInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_sms.py) ---
            // def _process_queue(self):
            // """ CRON job to send queued SMS messages. """
            // domain = [('state', '=', 'outgoing'), ('to_delete', '!=', True)]
            // 
            // batch_size = self._get_send_batch_size()
            // records = self.search(domain, limit=batch_size, order='id').try_lock_for_update()
            // if not records:
            //     return
            // 
            // records._send(unlink_failed=False, unlink_sent=True, raise_exception=False)
            // self.env['ir.cron']._commit_progress(len(records), remaining=self.search_count(domain) if len(records) == batch_size else 0)
            */
            return default;
        }

        public async Task<SmsSms> ResendFailedAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_sms.py) ---
            // def resend_failed(self):
            // sms_to_send = self.filtered(lambda sms: sms.state == 'error' and not sms.to_delete)
            // sms_to_send.state = 'outgoing'
            // notification_title = _('Warning')
            // notification_type = 'danger'
            // 
            // if sms_to_send:
            //     sms_to_send.send()
            //     success_sms = len(sms_to_send) - len(sms_to_send.exists())
            //     if success_sms > 0:
            //         notification_title = _('Success')
            //         notification_type = 'success'
            //         notification_message = _('%(count)s out of the %(total)s selected SMS Text Messages have successfully been resent.', count=success_sms, total=len(self))
            //     else:
            //         notification_message = _('The SMS Text Messages could not be resent.')
            // else:
            //     notification_message = _('There are no SMS Text Messages to resend.')
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'title': notification_title,
            //         'message': notification_message,
            //         'type': notification_type,
            //     }
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<SmsSms> SendAsync(Guid id, SmsSmsSendRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_sms.py) ---
            // def send(self, unlink_failed=False, unlink_sent=True, raise_exception=False):
            // """ Main API method to send SMS.
            // 
            // This contacts an external server. If the transaction fails, it may be
            // retried which can result in sending multiple SMS messages!
            // 
            //   :param unlink_failed: unlink failed SMS after IAP feedback;
            //   :param unlink_sent: unlink sent SMS after IAP feedback;
            //   :param raise_exception: raise if there is an issue contacting IAP;
            // """
            // domain = [('state', '=', 'outgoing'), ('to_delete', '!=', True)]
            // to_send = self.try_lock_for_update().filtered_domain(domain)
            // 
            // for sms_api, sms in to_send._split_by_api():
            //     for batch_ids in sms._split_batch():
            //         self.browse(batch_ids).with_context(sms_api=sms_api)._send(
            //             unlink_failed=unlink_failed,
            //             unlink_sent=unlink_sent,
            //             raise_exception=raise_exception,
            //         )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<SmsSms> SendInternalAsync(object unlink_failed, object unlink_sent, object raise_exception)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_sms.py) ---
            // def _send(self, unlink_failed=False, unlink_sent=True, raise_exception=False):
            // """Send SMS after checking the number (presence and formatting)."""
            // sms_api = self.env.context.get('sms_api')
            // if not sms_api:
            //     company = self._get_sms_company()
            //     company.ensure_one()  # This should always be the case since the grouping is done in `send`
            //     sms_api = company._get_sms_api_class()(self.env)
            // 
            // return self._send_with_api(
            //     sms_api,
            //     unlink_failed=unlink_failed,
            //     unlink_sent=unlink_sent,
            //     raise_exception=raise_exception,
            // )
            */
            return default;
        }

        protected async Task<SmsSms> SendWithApiInternalAsync(object sms_api, object unlink_failed, object unlink_sent, object raise_exception)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_sms.py) ---
            // def _send_with_api(self, sms_api, unlink_failed=False, unlink_sent=True, raise_exception=False):
            // """Send SMS after checking the number (presence and formatting)."""
            // messages = [{
            //     'content': body,
            //     'numbers': [{'number': sms.number, 'uuid': sms.uuid} for sms in body_sms_records],
            // } for body, body_sms_records in self.grouped('body').items()]
            // 
            // delivery_reports_url = url_join(self[0].get_base_url(), '/sms/status')
            // try:
            //     results = sms_api._send_sms_batch(messages, delivery_reports_url=delivery_reports_url)
            // except Exception as e:
            //     _logger.info('Sent batch %s SMS: %s: failed with exception %s', len(self.ids), self.ids, e)
            //     if raise_exception:
            //         raise
            //     results = [{'uuid': sms.uuid, 'state': 'server_error'} for sms in self]
            // else:
            //     _logger.info('Send batch %s SMS: %s: gave %s', len(self.ids), self.ids, results)
            // 
            // results_uuids = [result['uuid'] for result in results]
            // all_sms_sudo = self.env['sms.sms'].sudo().search([('uuid', 'in', results_uuids)]).with_context(sms_skip_msg_notification=True)
            // 
            // for (iap_state, failure_reason), results_group in tools.groupby(results, key=lambda result: (result['state'], result.get('failure_reason'))):
            //     sms_sudo = all_sms_sudo.filtered(lambda s: s.uuid in {result['uuid'] for result in results_group})
            //     if success_state := self.IAP_TO_SMS_STATE_SUCCESS.get(iap_state):
            //         sms_sudo.sms_tracker_id._action_update_from_sms_state(success_state)
            //         to_delete = {'to_delete': True} if unlink_sent else {}
            //         sms_sudo.write({'state': success_state, 'failure_type': False, **to_delete})
            //     else:
            //         failure_type = sms_api.PROVIDER_TO_SMS_FAILURE_TYPE.get(iap_state, 'unknown')
            //         if failure_type != 'unknown':
            //             sms_sudo.sms_tracker_id._action_update_from_sms_state('error', failure_type=failure_type, failure_reason=failure_reason)
            //         else:
            //             sms_sudo.sms_tracker_id.with_context(sms_known_failure_reason=failure_reason)._action_update_from_provider_error(iap_state)
            //         to_delete = {'to_delete': True} if unlink_failed else {}
            //         sms_sudo.write({'state': 'error', 'failure_type': failure_type, **to_delete})
            // 
            // all_sms_sudo._handle_call_result_hook(results)
            // all_sms_sudo.mail_message_id._notify_message_notification_update()
            */
            return default;
        }

        public async Task<SmsSms> SetCanceledAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_sms.py) ---
            // def action_set_canceled(self):
            // self._update_sms_state_and_trackers('canceled')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<SmsSms> SetErrorAsync(Guid id, SmsSmsSetErrorRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_sms.py) ---
            // def action_set_error(self, failure_type):
            // self._update_sms_state_and_trackers('error', failure_type=failure_type)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<SmsSms> SetOutgoingAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_sms.py) ---
            // def action_set_outgoing(self):
            // self._update_sms_state_and_trackers('outgoing', failure_type=False)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<SmsSms> SplitBatchInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_sms.py) ---
            // def _split_batch(self):
            // batch_size = self._get_send_batch_size()
            // yield from tools.split_every(batch_size, self.ids)
            */
            return default;
        }

        protected async Task<SmsSms> SplitByApiInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_sms.py) ---
            // def _split_by_api(self):
            // yield SmsApi(self.env), self
            --- ODOO METHOD SOURCE (MODULE: sms_twilio, FILE: sms_sms.py) ---
            // def _split_by_api(self):
            // # override to handle twilio or IAP choice, which is company dependent
            // # even twilio accounts may differ between companies
            // sms_by_company = defaultdict(lambda: self.env['sms.sms'])  # TODO RIGR: in master, let's be smarter and group by provider/twilio account (e.g.: IAP/twilio1/twilio2)
            // todo_via_super = self.browse()
            // for sms in self:
            //     sms_by_company[sms._get_sms_company()] += sms
            // for company, company_sms in sms_by_company.items():
            //     if company.sms_provider == "twilio":
            //         sms_api = company._get_sms_api_class()(self.env)
            //         sms_api._set_company(company)
            //         yield sms_api, company_sms
            //     else:
            //         todo_via_super += company_sms
            // if todo_via_super:
            //     yield from super(SmsSms, todo_via_super)._split_by_api()
            */
            return default;
        }

        protected async Task<SmsSms> UpdateBodyShortLinksInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: sms_sms.py) ---
            // def _update_body_short_links(self):
            // """ Override to tweak shortened URLs by adding statistics ids, allowing to
            // find customer back once clicked. """
            // res = dict.fromkeys(self.ids, False)
            // for sms in self:
            //     if not sms.mailing_id or not sms.body:
            //         res[sms.id] = sms.body
            //         continue
            // 
            //     body = sms.body
            //     for url in set(re.findall(TEXT_URL_REGEX, body)):
            //         if url.startswith(sms.get_base_url() + '/r/'):
            //             body = re.sub(re.escape(url) + r'(?![\w@:%.+&~#=/-])', url + f'/s/{sms.id}', body)
            //     res[sms.id] = body
            // return res
            */
            return default;
        }

        protected async Task<SmsSms> UpdateSmsStateAndTrackersInternalAsync(object new_state, object failure_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_sms.py) ---
            // def _update_sms_state_and_trackers(self, new_state, failure_type=None):
            // """Update sms state update and related tracking records (notifications, traces)."""
            // self.write({'state': new_state, 'failure_type': failure_type})
            // # Use sudo on mail.notification to allow writing other users' notifications; rights are already checked by sms write
            // self.sms_tracker_id.sudo()._action_update_from_sms_state(new_state, failure_type=failure_type)
            */
            return default;
        }
    }
}