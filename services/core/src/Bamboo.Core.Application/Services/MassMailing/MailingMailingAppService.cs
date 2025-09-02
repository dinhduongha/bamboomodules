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
    [Module("MassMailing", Depends = new[] { "contacts", "mail", "utm", "link_tracker", "web_editor", "social_media", "web_tour", "digest" })]
    public class MailingMailingAppService : GenericApplicationService<MailingMailing>, IMailingMailingAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailRenderMixinAppService _mailRenderMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        private readonly IUtmSourceMixinAppService _utmSourceMixinAppService;
        public MailingMailingAppService(IRepository<MailingMailing, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailRenderMixinAppService mailRenderMixinAppService, IMailThreadAppService mailThreadAppService, IUtmSourceMixinAppService utmSourceMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailRenderMixinAppService = mailRenderMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _utmSourceMixinAppService = utmSourceMixinAppService;
        }

        protected async Task<MailingMailing> ActionSendMailInternalAsync(List<Guid> res_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _action_send_mail(self, res_ids=None):
            // author_id = self.env.user.partner_id.id
            // 
            // for mailing in self:
            //     context_user = mailing.user_id or mailing.write_uid or self.env.user
            //     mailing = mailing.with_context(
            //         **self.env['res.users'].with_user(context_user).context_get()
            //     )
            //     mailing_res_ids = res_ids or mailing._get_remaining_recipients()
            //     if not mailing_res_ids:
            //         raise UserError(_('There are no recipients selected.'))
            // 
            //     composer_values = {
            //         'auto_delete': not mailing.keep_archives,
            //         # email-mode: keep original message for routing
            //         'auto_delete_keep_log': mailing.reply_to_mode == 'update',
            //         'author_id': author_id,
            //         'attachment_ids': [(4, attachment.id) for attachment in mailing.attachment_ids],
            //         'body': mailing._prepend_preview(mailing.body_html or '', mailing.preview),
            //         'composition_mode': 'mass_mail',
            //         'email_from': mailing.email_from,
            //         'mail_server_id': mailing.mail_server_id.id,
            //         'mailing_list_ids': [(4, l.id) for l in mailing.contact_list_ids],
            //         'mass_mailing_id': mailing.id,
            //         'model': mailing.mailing_model_real,
            //         'record_name': False,
            //         'reply_to_force_new': mailing.reply_to_mode == 'new',
            //         'subject': mailing.subject,
            //         'template_id': False,
            //     }
            //     if mailing.reply_to_mode == 'new':
            //         composer_values['reply_to'] = mailing.reply_to
            // 
            //     composer = self.env['mail.compose.message'].with_context(
            //         active_ids=mailing_res_ids,
            //         default_composition_mode='mass_mail',
            //         **mailing._get_mass_mailing_context()
            //     ).create(composer_values)
            // 
            //     # auto-commit except in testing mode
            //     auto_commit = not getattr(threading.current_thread(), 'testing', False)
            //     composer._action_send_mail(auto_commit=auto_commit)
            // 
            //     mailing.write({
            //         'state': 'done',
            //         'sent_date': fields.Datetime.now(),
            //         # send the KPI mail only if it's the first sending
            //         'kpi_mail_required': not mailing.sent_date,
            //     })
            // 
            //     # ensure mailing state update after auto-commit
            //     if auto_commit is True:
            //         self.env.cr.commit()
            // 
            // return True
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py) ---
            // def _action_send_mail(self, res_ids=None):
            // mass_sms = self.filtered(lambda m: m.mailing_type == 'sms')
            // if mass_sms:
            //     mass_sms.action_send_sms(res_ids=res_ids)
            // return super(Mailing, self - mass_sms)._action_send_mail(res_ids=res_ids)
            */
            return default;
        }

        protected async Task<MailingMailing> ActionSendStatisticsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _action_send_statistics(self):
            // """Send an email to the responsible of each finished mailing with the statistics."""
            // self.kpi_mail_required = False
            // 
            // mails_sudo = self.env['mail.mail'].sudo()
            // for mailing in self:
            //     if mailing.user_id:
            //         mailing = mailing.with_user(mailing.user_id).with_context(
            //             lang=mailing.user_id.lang or self._context.get('lang')
            //         )
            //     mailing_type = mailing._get_pretty_mailing_type()
            //     mail_user = mailing.user_id or self.env.user
            //     mail_company = mail_user.company_id
            // 
            //     link_trackers = self.env['link.tracker'].search(
            //         [('mass_mailing_id', '=', mailing.id)]
            //     ).sorted('count', reverse=True)
            //     link_trackers_body = self.env['ir.qweb']._render(
            //         'mass_mailing.mass_mailing_kpi_link_trackers',
            //         {
            //             'company': self.env.user.company_id,
            //             'object': mailing,
            //             'link_trackers': link_trackers,
            //             'mailing_type': mailing_type,
            //         },
            //     )
            //     rendering_data = {
            //         'body': tools.html_sanitize(link_trackers_body),
            //         'company': mail_company,
            //         'user': mail_user,
            //         'display_mobile_banner': True,
            //         ** mailing._prepare_statistics_email_values(),
            //     }
            //     if mail_user.has_group('mass_mailing.group_mass_mailing_user'):
            //         rendering_data['mailing_report_token'] = self._generate_mailing_report_token(mail_user.id)
            //         rendering_data['user_id'] = mail_user.id
            // 
            //     rendered_body = self.env['ir.qweb']._render(
            //         'digest.digest_mail_main',
            //         rendering_data
            //     )
            // 
            //     full_mail = self.env['mail.render.mixin']._render_encapsulate(
            //         'digest.digest_mail_layout',
            //         rendered_body,
            //     )
            // 
            //     mail_values = {
            //         'auto_delete': True,
            //         'author_id': mail_user.partner_id.id,
            //         'email_from': mail_user.email_formatted,
            //         'email_to': mail_user.email_formatted,
            //         'body_html': full_mail,
            //         'reply_to': mail_company.email_formatted or mail_user.email_formatted,
            //         'state': 'outgoing',
            //         'subject': _('24H Stats of %(mailing_type)s "%(mailing_name)s"',
            //                      mailing_type=mailing._get_pretty_mailing_type(),
            //                      mailing_name=mailing.subject
            //                     ),
            //     }
            //     mails_sudo += self.env['mail.mail'].sudo().create(mail_values)
            // return mails_sudo
            */
            return default;
        }

        protected async Task<MailingMailing> ActionViewDocumentsFilteredInternalAsync(object view_filter)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _action_view_documents_filtered(self, view_filter):
            // def _fetch_trace_res_ids(trace_domain):
            //     trace_domain = expression.AND([
            //         trace_domain,
            //         [('mass_mailing_id', '=', self.id)],
            //     ])
            //     result = self.env['mailing.trace'].search_read(domain=trace_domain, fields=['res_id'])
            //     return [line['res_id'] for line in result]
            // 
            // model_name = self.env['ir.model']._get(self.mailing_model_real).display_name
            // helper_header = None
            // helper_message = None
            // if view_filter == 'reply':
            //     res_ids = _fetch_trace_res_ids([('trace_status', '=', 'reply')])
            //     helper_header = _("No %s replied to your mailing yet!", model_name)
            //     helper_message = _("To track how many replies this mailing gets, make sure "
            //                        "its reply-to address belongs to this database.")
            // elif view_filter == 'bounce':
            //     res_ids = _fetch_trace_res_ids([('trace_status', '=', 'bounce')])
            //     helper_header = _("No %s address bounced yet!", model_name)
            //     helper_message = _("Bounce happens when a mailing cannot be delivered (fake address, "
            //                        "server issues, ...). Check each record to see what went wrong.")
            // elif view_filter == 'clicked':
            //     res_ids = _fetch_trace_res_ids([('links_click_ids', '!=', False)])
            //     helper_header = _("No %s clicked your mailing yet!", model_name)
            //     helper_message = _(
            //         "Come back once your mailing has been sent to track who clicked on the embedded links.")
            // elif view_filter == 'open':
            //     res_ids = _fetch_trace_res_ids([('trace_status', 'in', ('open', 'reply'))])
            //     helper_header = _("No %s opened your mailing yet!", model_name)
            //     helper_message = _("Come back once your mailing has been sent to track who opened your mailing.")
            // elif view_filter == 'delivered':
            //     res_ids = _fetch_trace_res_ids([('trace_status', 'in', ('sent', 'open', 'reply'))])
            //     helper_header = _("No %s received your mailing yet!", model_name)
            //     helper_message = _("Wait until your mailing has been sent to check how many recipients you managed to reach.")
            // elif view_filter == 'sent':
            //     res_ids = _fetch_trace_res_ids([('sent_datetime', '!=', False)])
            // else:
            //     res_ids = []
            // 
            // action = {
            //     'name': model_name,
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'list,form',
            //     'res_model': self.mailing_model_real,
            //     'domain': [('id', 'in', res_ids)],
            //     'context': dict(self._context, create=False),
            // }
            // if helper_header and helper_message:
            //     action['help'] = Markup('<p class="o_view_nocontent_smiling_face">%s</p><p>%s</p>') % (
            //         helper_header, helper_message,
            //     ),
            // return action
            */
            return default;
        }

        protected async Task<MailingMailing> ActionViewTracesFilteredInternalAsync(object view_filter)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _action_view_traces_filtered(self, view_filter):
            // action = self.env["ir.actions.actions"]._for_xml_id("mass_mailing.mailing_trace_action")
            // action['name'] = _('Sent Mailings')
            // action['context'] = {'search_default_mass_mailing_id': self.id,}
            // filter_key = 'search_default_filter_%s' % (view_filter)
            // action['context'][filter_key] = True
            // action['views'] = [
            //     (self.env.ref('mass_mailing.mailing_trace_view_tree_mail').id, 'list'),
            //     (self.env.ref('mass_mailing.mailing_trace_view_form').id, 'form')
            // ]
            // return action
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py) ---
            // def _action_view_traces_filtered(self, view_filter):
            // action = super(Mailing, self)._action_view_traces_filtered(view_filter)
            // if self.mailing_type == 'sms':
            //     action['views'] = [(self.env.ref('mass_mailing_sms.mailing_trace_view_tree_sms').id, 'list'),
            //                        (self.env.ref('mass_mailing_sms.mailing_trace_view_form_sms').id, 'form')]
            // return action
            */
            return default;
        }

        public async Task<MailingMailing> BuySmsCreditsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py) ---
            // def action_buy_sms_credits(self):
            // url = self.env['iap.account'].get_credits_url(service_name='sms')
            // return {
            //     'type': 'ir.actions.act_url',
            //     'url': url,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingMailing> CancelAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_cancel(self):
            // self.write({'state': 'draft', 'schedule_date': False, 'schedule_type': 'now', 'next_departure': False})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MailingMailing> CheckMailingDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: marketing_card, FILE: mailing_mailing.py) ---
            // def _check_mailing_domain(self):
            // for mailing in self:
            //     if mailing.card_campaign_id:
            //         if mailing.sudo().mailing_model_id.model != mailing.card_campaign_id.res_model:
            //             raise exceptions.ValidationError(_(
            //                 "Card Campaign Mailing should target model %(model_name)s",
            //                 model_name=self.env['ir.model']._get(mailing.card_campaign_id.res_model).display_name
            //             ))
            */
            return default;
        }

        protected async Task<MailingMailing> CheckMailingFilterModelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _check_mailing_filter_model(self):
            // """Check that if the favorite filter is set, it must contain the same recipient model as mailing"""
            // for mailing in self:
            //     if mailing.mailing_filter_id and mailing.mailing_model_id != mailing.mailing_filter_id.mailing_model_id:
            //         raise ValidationError(
            //             _("The saved filter targets different recipients and is incompatible with this mailing.")
            //         )
            */
            return default;
        }

        public async Task<MailingMailing> CompareVersionsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_compare_versions(self):
            // self.ensure_one()
            // if not self.campaign_id:
            //     raise ValueError(_("No mailing campaign has been found"))
            // return {
            //     'name': _('A/B Tests'),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'list,kanban,form,calendar,graph',
            //     'res_model': 'mailing.mailing',
            //     'domain': expression.AND([
            //         [('campaign_id', '=', self.campaign_id.id)],
            //         [('ab_testing_enabled', '=', True)],
            //         [('mailing_type', '=', self.mailing_type)]
            //     ]),
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MailingMailing> ComputeAbTestingDescriptionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_ab_testing_description(self):
            // mailing_ab_test = self.filtered('ab_testing_enabled')
            // (self - mailing_ab_test).ab_testing_description = False
            // for mailing in mailing_ab_test:
            //     mailing.ab_testing_description = self.env['ir.qweb']._render(
            //         'mass_mailing.ab_testing_description',
            //         mailing._get_ab_testing_description_values()
            //     )
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeAbTestingIsWinnerMailingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_ab_testing_is_winner_mailing(self):
            // for mailing in self:
            //     mailing.ab_testing_is_winner_mailing = mailing.campaign_id.ab_testing_winner_mailing_id == mailing
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeBodyPlaintextInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py) ---
            // def _compute_body_plaintext(self):
            // for mailing in self:
            //     if mailing.mailing_type == 'sms' and mailing.sms_template_id:
            //         mailing.body_plaintext = mailing.sms_template_id.body
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeCalendarDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_calendar_date(self):
            // for mailing in self:
            //     if mailing.state == 'done':
            //         mailing.calendar_date = mailing.sent_date
            //     elif mailing.state == 'in_queue':
            //         mailing.calendar_date = mailing.next_departure
            //     elif mailing.state == 'sending':
            //         mailing.calendar_date = fields.Datetime.now()
            //     else:
            //         mailing.calendar_date = False
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeCardRequiresSyncCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: marketing_card, FILE: mailing_mailing.py) ---
            // def _compute_card_requires_sync_count(self):
            // """Check if there's any missing or outdated card."""
            // self.card_requires_sync_count = 0
            // # no point in updating sent mailings
            // card_mailings = self.filtered(lambda mailing: mailing.card_campaign_id and mailing.state == 'draft')
            // for mailing in card_mailings:
            //     recipients = self.env[mailing.mailing_model_real].search(self._parse_mailing_domain())
            //     out_of_date_count = self.env['card.card'].search_count([
            //         ('campaign_id', '=', mailing.card_campaign_id.id),
            //         ('res_id', 'in', recipients.ids),
            //         ('requires_sync', '=', False)
            //     ])
            //     mailing.card_requires_sync_count = len(recipients) - out_of_date_count
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeClicksRatioInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_clicks_ratio(self):
            // self.env.cr.execute("""
            //     SELECT COUNT(DISTINCT(stats.id)) AS nb_mails, COUNT(DISTINCT(clicks.mailing_trace_id)) AS nb_clicks, stats.mass_mailing_id AS id
            //     FROM mailing_trace AS stats
            //     LEFT OUTER JOIN link_tracker_click AS clicks ON clicks.mailing_trace_id = stats.id
            //     WHERE stats.mass_mailing_id IN %s
            //     AND stats.trace_status not in ('bounce', 'cancel', 'error')
            //     GROUP BY stats.mass_mailing_id
            // """, [tuple(self.ids) or (None,)])
            // mass_mailing_data = self.env.cr.dictfetchall()
            // mapped_data = dict([(m['id'], float_round(100 * m['nb_clicks'] / m['nb_mails'], precision_digits=2)) for m in mass_mailing_data])
            // for mass_mailing in self:
            //     mass_mailing.clicks_ratio = mapped_data.get(mass_mailing.id, 0)
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeCrmLeadCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_crm, FILE: mailing_mailing.py) ---
            // def _compute_crm_lead_count(self):
            // lead_data = self.env['crm.lead'].with_context(active_test=False).sudo()._read_group(
            //     [('source_id', 'in', self.source_id.ids)],
            //     ['source_id'], ['__count'],
            // )
            // mapped_data = {source.id: count for source, count in lead_data}
            // for mass_mailing in self:
            //     mass_mailing.crm_lead_count = mapped_data.get(mass_mailing.source_id.id, 0)
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeEmailFromInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_email_from(self):
            // notification_email = self.env['ir.mail_server']._get_default_from_address()
            // 
            // for mailing in self:
            //     user_email = mailing.create_uid.email_formatted or self.env.user.email_formatted
            //     server = mailing.mail_server_id
            //     if not server:
            //         mailing.email_from = mailing.email_from or user_email
            //     elif mailing.email_from and server._match_from_filter(mailing.email_from, server.from_filter):
            //         mailing.email_from = mailing.email_from
            //     elif server._match_from_filter(user_email, server.from_filter):
            //         mailing.email_from = user_email
            //     elif server._match_from_filter(notification_email, server.from_filter):
            //         mailing.email_from = notification_email
            //     else:
            //         mailing.email_from = mailing.email_from or user_email
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeFavoriteDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_favorite_date(self):
            // favorited = self.filtered('favorite')
            // (self - favorited).favorite_date = False
            // favorited.filtered(lambda mailing: not mailing.favorite_date).favorite_date = fields.Datetime.now()
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeIsAbTestSentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_is_ab_test_sent(self):
            // for rec in self:
            //     ab_testing_mailings = rec._get_ab_testing_siblings_mailings()
            //     selected_mailings = ab_testing_mailings.filtered(lambda m: m.state == 'done')
            //     rec.is_ab_test_sent = bool(selected_mailings)
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeIsBodyEmptyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_is_body_empty(self):
            // for mailing in self:
            //     mailing.is_body_empty = tools.is_html_empty(mailing.body_arch)
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeLinkTrackersCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_link_trackers_count(self):
            // result = self.env["link.tracker"].sudo()._read_group(
            //     domain=[("mass_mailing_id", "in", self.ids)],
            //     groupby=["mass_mailing_id"],
            //     aggregates=["id:count"],
            // )
            // self.link_trackers_count = 0
            // for mailing, count in result:
            //     mailing.link_trackers_count = count
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeMailServerAvailableInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_mail_server_available(self):
            // self.mail_server_available = self.env['ir.config_parameter'].sudo().get_param('mass_mailing.outgoing_mail_server')
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeMailingDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_mailing_domain(self):
            // for mailing in self:
            //     if not mailing.mailing_model_id:
            //         mailing.mailing_domain = ''
            //     elif mailing.mailing_filter_id:
            //         mailing.mailing_domain = mailing.mailing_filter_id.mailing_domain
            //     else:
            //         mailing.mailing_domain = repr(mailing._get_default_mailing_domain())
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeMailingFilterCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_mailing_filter_count(self):
            // filter_data = self.env['mailing.filter']._read_group([
            //     ('mailing_model_id', 'in', self.mailing_model_id.ids)
            // ], ['mailing_model_id'], ['__count'])
            // mapped_data = {mailing_model.id: count for mailing_model, count in filter_data}
            // for mailing in self:
            //     mailing.mailing_filter_count = mapped_data.get(mailing.mailing_model_id.id, 0)
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeMailingFilterIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_mailing_filter_id(self):
            // for mailing in self:
            //     mailing.mailing_filter_id = False
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeMailingModelIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: marketing_card, FILE: mailing_mailing.py) ---
            // def _compute_mailing_model_id(self):
            // for mailing in self.filtered('card_campaign_id'):
            //     mailing.mailing_model_id = self.env['ir.model']._get_id(mailing.card_campaign_id.res_model)
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeMailingModelRealInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_mailing_model_real(self):
            // for mailing in self:
            //     mailing.mailing_model_real = 'mailing.contact' if mailing.mailing_model_id.model == 'mailing.list' else mailing.mailing_model_id.model
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeMailingOnMailingListInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_mailing_on_mailing_list(self):
            // mailing_list_model_id = self.env['ir.model']._get('mailing.list')
            // self.mailing_on_mailing_list = False
            // self.filtered(lambda m: m.mailing_model_id == mailing_list_model_id).mailing_on_mailing_list = True
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeMailingTypeDescriptionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_mailing_type_description(self):
            // for mailing in self:
            //     mailing.mailing_type_description = dict(self._fields.get('mailing_type').selection).get(mailing.mailing_type)
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeMediumIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_medium_id(self):
            // for mailing in self:
            //     if mailing.mailing_type == 'mail' and not mailing.medium_id:
            //         mailing.medium_id = self.env['utm.medium']._fetch_or_create_utm_medium('email').id
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py) ---
            // def _compute_medium_id(self):
            // super(Mailing, self)._compute_medium_id()
            // for mailing in self:
            //     if mailing.mailing_type == 'sms' and (not mailing.medium_id or mailing.medium_id == self.env['utm.medium']._fetch_or_create_utm_medium('email')):
            //         mailing.medium_id = self.env['utm.medium']._fetch_or_create_utm_medium("sms", module="mass_mailing_sms").id
            //     elif mailing.mailing_type == 'mail' and (not mailing.medium_id or mailing.medium_id == self.env['utm.medium']._fetch_or_create_utm_medium("sms", module="mass_mailing_sms")):
            //         mailing.medium_id = self.env['utm.medium']._fetch_or_create_utm_medium('email').id
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeNextDepartureInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_next_departure(self):
            // # Schedule_date should only be False if schedule_type = "now" or
            // # mass_mailing is canceled.
            // # A cron.trigger is created when mailing is put "in queue"
            // # so we can reasonably expect that the cron worker will
            // # execute this based on the cron.trigger's call_at which should
            // # be now() when clicking "Send" or schedule_date if scheduled
            // 
            // # If the departure time has passed but mailing is still in queue, this compute field
            // # will be used to display warning with reload button on a mailing form view.
            // for mass_mailing in self:
            //     if mass_mailing.schedule_date:
            //         # max in case the user schedules a date in the past
            //         mass_mailing.next_departure = max(mass_mailing.schedule_date, fields.datetime.now())
            //     else:
            //         mass_mailing.next_departure = fields.datetime.now()
            // past = self.filtered(
            //     lambda mailing: mailing.state == 'in_queue' and mailing.next_departure < fields.Datetime.now()
            // )
            // past.next_departure_is_past = True
            // (self - past).next_departure_is_past = False
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeRenderModelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_render_model(self):
            // for mailing in self:
            //     mailing.render_model = mailing.mailing_model_real
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeReplyToInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_reply_to(self):
            // for mailing in self:
            //     if mailing.reply_to_mode == 'new' and not mailing.reply_to:
            //         mailing.reply_to = self.env.user.email_formatted
            //     elif mailing.reply_to_mode == 'update':
            //         mailing.reply_to = False
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeReplyToModeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_reply_to_mode(self):
            // """ For main models not really using chatter to gather answers (contacts
            // and mailing contacts), set reply-to as email-based. Otherwise answers
            // by default go on the original discussion thread (business document). Note
            // that mailing_model being mailing.list means contacting mailing.contact
            // (see mailing_model_name versus mailing_model_real). """
            // for mailing in self:
            //     if mailing.mailing_model_id.model in ['res.partner', 'mailing.list', 'mailing.contact']:
            //         mailing.reply_to_mode = 'new'
            //     else:
            //         mailing.reply_to_mode = 'update'
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeSaleInvoicedAmountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sale, FILE: mailing_mailing.py) ---
            // def _compute_sale_invoiced_amount(self):
            // domain = expression.AND([
            //     [('source_id', 'in', self.source_id.ids)],
            //     [('state', 'not in', ['draft', 'cancel'])]
            // ])
            // moves_data = self.env['account.move'].sudo()._read_group(
            //     domain, ['source_id'], ['amount_untaxed_signed:sum'],
            // )
            // mapped_data = {source.id: amount_untaxed_signed for source, amount_untaxed_signed in moves_data}
            // for mass_mailing in self:
            //     mass_mailing.sale_invoiced_amount = mapped_data.get(mass_mailing.source_id.id, 0)
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeSaleQuotationCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sale, FILE: mailing_mailing.py) ---
            // def _compute_sale_quotation_count(self):
            // quotation_data = self.env['sale.order'].sudo()._read_group(
            //     [('source_id', 'in', self.source_id.ids), ('order_line', '!=', False)],
            //     ['source_id'], ['__count'],
            // )
            // mapped_data = {source.id: count for source, count in quotation_data}
            // for mass_mailing in self:
            //     mass_mailing.sale_quotation_count = mapped_data.get(mass_mailing.source_id.id, 0)
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeScheduleDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_schedule_date(self):
            // for mailing in self:
            //     if mailing.schedule_type == 'now' or not mailing.schedule_date:
            //         mailing.schedule_date = False
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeSmsHasIapFailureInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py) ---
            // def _compute_sms_has_iap_failure(self):
            // self.sms_has_insufficient_credit = self.sms_has_unregistered_account = False
            // traces = self.env['mailing.trace'].sudo()._read_group([
            //             ('mass_mailing_id', 'in', self.ids),
            //             ('trace_type', '=', 'sms'),
            //             ('failure_type', 'in', ['sms_acc', 'sms_credit'])
            // ], ['mass_mailing_id', 'failure_type'])
            // 
            // for mass_mailing, failure_type in traces:
            //     if failure_type == 'sms_credit':
            //         mass_mailing.sms_has_insufficient_credit = True
            //     elif failure_type == 'sms_acc':
            //         mass_mailing.sms_has_unregistered_account = True
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeStatisticsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_statistics(self):
            // """ Compute statistics of the mass mailing """
            // for key in (
            //     'scheduled', 'expected', 'canceled', 'sent', 'pending', 'delivered', 'opened',
            //     'process', 'clicked', 'replied', 'bounced', 'failed', 'received_ratio',
            //     'opened_ratio', 'replied_ratio', 'bounced_ratio',
            // ):
            //     self[key] = False
            // 
            // result = self.env["mailing.trace"].sudo()._read_group(
            //     [("mass_mailing_id", "in", self.ids)],
            //     ['mass_mailing_id', 'trace_status'],
            //     ['__count', 'links_click_datetime:count', 'sent_datetime:count'])
            // 
            // result_per_mailing = defaultdict(lambda: defaultdict(int))
            // for mailing, trace_status, count, links_click_datetime, sent_datetime in result:
            //     result_per_mailing[mailing][trace_status] = count
            //     result_per_mailing[mailing]['links_click_datetime'] += links_click_datetime
            //     result_per_mailing[mailing]['sent_datetime'] += sent_datetime
            // 
            // for mailing in self:
            //     line = result_per_mailing[mailing]
            //     values = {
            //         'scheduled': line['outgoing'],
            //         'expected': sum(v for k, v in line.items() if k not in ('links_click_datetime', 'sent_datetime')),
            //         'canceled': line['cancel'],
            //         'pending': line['pending'],
            //         'delivered': line['sent'] + line['open'] + line['reply'],
            //         'opened': line['open'] + line['reply'],
            //         'replied': line['reply'],
            //         'bounced': line['bounce'],
            //         'failed': line['error'],
            //         'clicked': line['links_click_datetime'],
            //         'sent': line['sent_datetime'],
            //     }
            //     total = (values['expected'] - values['canceled']) or 1
            //     total_no_error = (values['expected'] - values['canceled'] - values['bounced'] - values['failed']) or 1
            //     total_sent = (values['expected'] - values['canceled'] - values['failed']) or 1
            //     values['received_ratio'] = float_round(100.0 * values['delivered'] / total, precision_digits=2)
            //     values['opened_ratio'] = float_round(100.0 * values['opened'] / total_no_error, precision_digits=2)
            //     values['replied_ratio'] = float_round(100.0 * values['replied'] / total_no_error, precision_digits=2)
            //     values['bounced_ratio'] = float_round(100.0 * values['bounced'] / total_sent, precision_digits=2)
            //     mailing.update(values)
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeTotalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_total(self):
            // for mass_mailing in self:
            //     total = self.env[mass_mailing.mailing_model_real].search_count(mass_mailing._get_recipients_domain())
            //     if total and mass_mailing.ab_testing_enabled and mass_mailing.ab_testing_pc < 100:
            //         total = max(int(total / 100.0 * mass_mailing.ab_testing_pc), 1)
            //     mass_mailing.total = total
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeUseLeadsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_crm, FILE: mailing_mailing.py) ---
            // def _compute_use_leads(self):
            // self.use_leads = self.env.user.has_group('crm.group_use_lead')
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeWarningMessageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_warning_message(self):
            // self.warning_message = False
            // for mailing in self.filtered(lambda mailing: mailing.mailing_type == "mail"):
            //     mail_server = mailing.mail_server_id
            //     if mail_server and not mail_server._match_from_filter(mailing.email_from, mail_server.from_filter):
            //         mailing.warning_message = _(
            //             'This email from can not be used with this mail server.\n'
            //             'Your emails might be marked as spam on the mail clients.'
            //         )
            //     else:
            //         mailing.warning_message = False
            */
            return default;
        }

        protected async Task<MailingMailing> ConvertInlineImagesToUrlsInternalAsync(object html_content)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _convert_inline_images_to_urls(self, html_content):
            // """
            // Find inline base64 encoded images, make an attachement out of
            // them and replace the inline image with an url to the attachement.
            // Find VML v:image elements, crop their source images, make an attachement
            // out of them and replace their source with an url to the attachement.
            // """
            // root = lxml.html.fromstring(html_content)
            // did_modify_body = False
            // 
            // conversion_info = []  # list of tuples (image: base64 image, node: lxml node, old_url: string or None, original_id))
            // with requests.Session() as session:
            //     for node in root.iter(lxml.etree.Element, lxml.etree.Comment):
            //         if node.tag == 'img':
            //             # Convert base64 images in img tags to attachments.
            //             match = image_re.match(node.attrib.get('src', ''))
            //             if match:
            //                 image = match.group(2).encode()  # base64 image as bytes
            //                 conversion_info.append((image, node, None, int(node.attrib.get('data-original-id') or "0")))
            //         elif 'base64' in (node.attrib.get('style') or ''):
            //             # Convert base64 images in inline styles to attachments.
            //             for match in re.findall(r'data:image/[A-Za-z]+;base64,.+?(?=&\#34;|\"|\'|&quot;|\))', node.attrib.get('style')):
            //                 image = re.sub(r'data:image/[A-Za-z]+;base64,', '', match).encode()  # base64 image as bytes
            //                 conversion_info.append((image, node, match, int(node.attrib.get('data-original-id') or "0")))
            //         elif mso_re.match(node.text or ''):
            //             # Convert base64 images (in img tags or inline styles) in mso comments to attachments.
            //             base64_in_element_regex = re.compile(r"""
            //                 (?:(?!^)|<)[^<>]*?(data:image/[A-Za-z]+;base64,[^<]+?)(?=&\#34;|\"|'|&quot;|\))(?=[^<]+>)
            //             """, re.VERBOSE)
            //             for match in re.findall(base64_in_element_regex, node.text):
            //                 image = re.sub(r'data:image/[A-Za-z]+;base64,', '', match).encode()  # base64 image as bytes
            //                 conversion_info.append((image, node, match, int(node.attrib.get('data-original-id') or "0")))
            //             # Crop VML images.
            //             for match in re.findall(r'<v:image[^>]*>', node.text):
            //                 url = re.search(r'src=\s*\"([^\"]+)\"', match)[1]
            //                 # Make sure we have an absolute URL by adding a scheme and host if needed.
            //                 absolute_url = url if '//' in url else f"{self.get_base_url()}{url if url.startswith('/') else f'/{url}'}"
            //                 target_width_match = re.search(r'width:\s*([0-9\.]+)\s*px', match)
            //                 target_height_match = re.search(r'height:\s*([0-9\.]+)\s*px', match)
            //                 if target_width_match and target_height_match:
            //                     target_width = float(target_width_match[1])
            //                     target_height = float(target_height_match[1])
            //                     try:
            //                         image = self._get_image_by_url(absolute_url, session)
            //                     except (ImportValidationError, UnidentifiedImageError):
            //                         # Url invalid or doesn't resolve to a valid image.
            //                         # Note: We choose to ignore errors so as not to
            //                         # break the entire process just for one image's
            //                         # responsive cropping behavior).
            //                         pass
            //                     else:
            //                         image_processor = ImageProcess(image)
            //                         image = image_processor.crop_resize(target_width, target_height, 0, 0)
            //                         conversion_info.append((base64.b64encode(image.source), node, url, int(node.attrib.get('data-original-id') or "0")))
            // 
            // # Apply the changes.
            // urls = self._create_attachments_from_inline_images([(image, original_id) for (image, _, _, original_id) in conversion_info])
            // for ((image, node, old_url, original_id), new_url) in zip(conversion_info, urls):
            //     did_modify_body = True
            //     if node.tag == 'img':
            //         node.attrib['src'] = new_url
            //     elif 'base64' in (node.attrib.get('style') or ''):
            //         node.attrib['style'] = node.attrib['style'].replace(old_url, new_url)
            //     else:
            //         node.text = node.text.replace(old_url, new_url)
            // 
            // if did_modify_body:
            //     return lxml.html.tostring(root, encoding='unicode')
            // return html_content
            */
            return default;
        }

        public async Task<MailingMailing> ConvertLinksAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def convert_links(self):
            // res = {}
            // for mass_mailing in self:
            //     html = mass_mailing.body_html if mass_mailing.body_html else ''
            // 
            //     vals = {'mass_mailing_id': mass_mailing.id}
            // 
            //     if mass_mailing.campaign_id:
            //         vals['campaign_id'] = mass_mailing.campaign_id.id
            //     if mass_mailing.source_id:
            //         vals['source_id'] = mass_mailing.source_id.id
            //     if mass_mailing.medium_id:
            //         vals['medium_id'] = mass_mailing.medium_id.id
            // 
            //     res[mass_mailing.id] = mass_mailing._shorten_links(html, vals, blacklist=['/unsubscribe_from_list', '/view', '/cards/'])
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py) ---
            // def convert_links(self):
            // sms_mailings = self.filtered(lambda m: m.mailing_type == 'sms')
            // res = {}
            // for mailing in sms_mailings:
            //     tracker_values = mailing._get_link_tracker_values()
            //     body = mailing._shorten_links_text(mailing.body_plaintext, tracker_values)
            //     res[mailing.id] = body
            // res.update(super(Mailing, self - sms_mailings).convert_links())
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingMailing> CopyDataAsync(Guid id, MailingMailingCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default)
            // for mailing, vals in zip(self, vals_list):
            //     vals['contact_list_ids'] = mailing.contact_list_ids.ids
            //     if mailing.mail_server_id and not mailing.mail_server_id.active:
            //         vals['mail_server_id'] = self._get_default_mail_server_id()
            //     if mailing.ab_testing_enabled:
            //         vals['ab_testing_schedule_datetime'] = mailing.ab_testing_schedule_datetime
            // return vals_list
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MailingMailing> CreateAbTestingUtmCampaignsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _create_ab_testing_utm_campaigns(self):
            // """ Creates the A/B test campaigns for the mailings that do not have campaign set already """
            // campaign_vals = [
            //     mailing._get_default_ab_testing_campaign_values()
            //     for mailing in self.filtered(lambda mailing: mailing.ab_testing_enabled and not mailing.campaign_id)
            // ]
            // return self.env['utm.campaign'].create(campaign_vals)
            */
            return default;
        }

        public override async Task<MailingMailing> CreateAsync(MailingMailing entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def create(self, vals_list):
            // ab_testing_cron = self.env.ref('mass_mailing.ir_cron_mass_mailing_ab_testing').sudo()
            // for values in vals_list:
            //     if values.get('ab_testing_schedule_datetime'):
            //         at = fields.Datetime.from_string(values['ab_testing_schedule_datetime'])
            //         ab_testing_cron._trigger(at=at)
            // mailings = super().create(vals_list)
            // mailings._create_ab_testing_utm_campaigns()
            // mailings._fix_attachment_ownership()
            // 
            // for values, mailing in zip(vals_list, mailings):
            //     if values.get('body_arch'):
            //         mailing.body_arch = mailing._convert_inline_images_to_urls(mailing.body_arch)
            //     if values.get('body_html'):
            //         mailing.body_html = mailing._convert_inline_images_to_urls(mailing.body_html)
            // return mailings
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     # Get subject from "sms_subject" field when SMS installed (used to
            //     # build the name of record in the super 'create' method)
            //     if vals.get('mailing_type') == 'sms' and vals.get('sms_subject'):
            //         vals['subject'] = vals['sms_subject']
            // return super().create(vals_list)
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<MailingMailing> CreateAttachmentsFromInlineImagesInternalAsync(object b64images)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _create_attachments_from_inline_images(self, b64images):
            // if not b64images:
            //     return []
            // 
            // IrAttachment = self.env['ir.attachment']
            // existing_attachments = dict(IrAttachment.search([
            //     ('res_model', '=', 'mailing.mailing'),
            //     ('res_id', '=', self.id),
            // ]).mapped(lambda record: (record.checksum, record)))
            // 
            // attachments, vals_for_attachs, checksums = [], [], []
            // checksums_set, checksum_original_id, new_attachment_by_checksum = set(), {}, {}
            // next_img_id = len(existing_attachments)
            // for (b64image, original_id) in b64images:
            //     checksum = IrAttachment._compute_checksum(base64.b64decode(b64image))
            //     checksums.append(checksum)
            //     existing_attach = existing_attachments.get(checksum)
            //     # Existing_attach can be None, in which case it acts as placeholder
            //     # for attachment to be created.
            //     attachments.append(existing_attach)
            //     if original_id:
            //         checksum_original_id[checksum] = original_id
            //     if not existing_attach and not checksum in checksums_set:
            //         # We create only one attachment per checksum
            //         vals_for_attachs.append({
            //             'datas': b64image,
            //             'name': f"image_mailing_{self.id}_{next_img_id}",
            //             'type': 'binary',
            //             'res_id': self.id,
            //             'res_model': 'mailing.mailing',
            //             'checksum': checksum,
            //         })
            //         checksums_set.add(checksum)
            //         next_img_id += 1
            // for vals in vals_for_attachs:
            //     if vals['checksum'] in checksum_original_id:
            //         vals['original_id'] = checksum_original_id[vals['checksum']]
            //     del vals['checksum']
            // 
            // new_attachments = iter(IrAttachment.create(vals_for_attachs))
            // checksum_iter = iter(checksums)
            // # Replace None entries by newly created attachments.
            // for i in range(len(attachments)):
            //     checksum = next(checksum_iter)
            //     if attachments[i]:
            //         continue
            //     if checksum in new_attachment_by_checksum:
            //         attachments[i] = new_attachment_by_checksum[checksum]
            //     else:
            //         attachments[i] = next(new_attachments)
            //         new_attachment_by_checksum[checksum] = attachments[i]
            // 
            // urls = []
            // for attachment in attachments:
            //     attachment.generate_access_token()
            //     urls.append('/web/image/%s?access_token=%s' % (attachment.id, attachment.access_token))
            // 
            // return urls
            */
            return default;
        }

        public override async Task<MailingMailing> DefaultGetAsync(List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def default_get(self, fields_list):
            // vals = super(MassMailing, self).default_get(fields_list)
            // 
            // # field sent by the calendar view when clicking on a date block
            // # we use it to setup the scheduled date of the created mailing.mailing
            // default_calendar_date = self.env.context.get('default_calendar_date')
            // if default_calendar_date and ('schedule_type' in fields_list and 'schedule_date' in fields_list) \
            //    and fields.Datetime.from_string(default_calendar_date) > fields.Datetime.now():
            //     vals.update({
            //         'schedule_type': 'scheduled',
            //         'schedule_date': default_calendar_date
            //     })
            // 
            // if 'contact_list_ids' in fields_list and not vals.get('contact_list_ids') and vals.get('mailing_model_id'):
            //     if vals.get('mailing_model_id') == self.env['ir.model']._get_id('mailing.list'):
            //         mailing_list = self.env['mailing.list'].search([], limit=2)
            //         if len(mailing_list) == 1:
            //             vals['contact_list_ids'] = [(6, 0, [mailing_list.id])]
            // return vals
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py) ---
            // def default_get(self, fields):
            // res = super(Mailing, self).default_get(fields)
            // if fields is not None and 'keep_archives' in fields and res.get('mailing_type') == 'sms':
            //     res['keep_archives'] = True
            // return res
            */
            return await base.DefaultGetAsync(fields);
        }

        public async Task<MailingMailing> DuplicateAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_duplicate(self):
            // self.ensure_one()
            // if mass_mailing_copy := self.copy():
            //     return {
            //         'type': 'ir.actions.act_window',
            //         'view_mode': 'form',
            //         'res_model': 'mailing.mailing',
            //         'res_id': mass_mailing_copy.id,
            //         'context': dict(self.env.context),
            //     }
            // return False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingMailing> FetchFavoritesAsync(Guid id, MailingMailingFetchFavoritesRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_fetch_favorites(self, extra_domain=None):
            // """Return all mailings set as favorite and skip mailings with empty body.
            // 
            // Return archived mailing templates as well, so the user can archive the templates
            // while keeping using it, without cluttering the Kanban view if they're a lot of
            // templates.
            // """
            // domain = [('favorite', '=', True)]
            // if extra_domain:
            //     domain = expression.AND([domain, extra_domain])
            // 
            // values_list = self.with_context(active_test=False).search_read(
            //     domain=domain,
            //     fields=['id', 'subject', 'body_arch', 'user_id', 'mailing_model_id'],
            //     order='favorite_date DESC',
            // )
            // 
            // values_list = [
            //     values for values in values_list
            //     if not tools.is_html_empty(values['body_arch'])
            // ]
            // 
            // # You see first the mailings without responsible, then your mailings and then the others
            // values_list.sort(
            //     key=lambda values:
            //     values['user_id'][0] != self.env.user.id if values['user_id'] else -1
            // )
            // 
            // return values_list
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MailingMailing> FixAttachmentOwnershipInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _fix_attachment_ownership(self):
            // for record in self:
            //     record.attachment_ids.write({'res_model': record._name, 'res_id': record.id})
            // return self
            */
            return default;
        }

        protected async Task<MailingMailing> GenerateMailingRecipientTokenInternalAsync(Guid document_id, object email)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _generate_mailing_recipient_token(self, document_id, email):
            // """Generate a secure token for a given mailing and recipient (based on
            // their email). This allows notably to unsubscribe from the mailing or
            // to blacklist their email entirely without need of a user account.
            // 
            // :param int document_id: ID of the business document on which mailing
            //   is performed;
            // :param str email: recipient email, used to unsubscribe / blacklist;
            // """
            // self.ensure_one()
            // assert isinstance(email, str)
            // secret = self.env["ir.config_parameter"].sudo().get_param("database.secret")
            // token = (self.env.cr.dbname, self.id, int(document_id), email)
            // return hmac.new(secret.encode('utf-8'), repr(token).encode('utf-8'), hashlib.sha512).hexdigest()
            */
            return default;
        }

        protected async Task<MailingMailing> GenerateMailingReportTokenInternalAsync(Guid user_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _generate_mailing_report_token(self, user_id):
            // """Generate a secure token for this user. It allows to opt out from
            // mailing reports while keeping some security in that process. """
            // return tools.hmac(self.env(su=True), 'mailing-report-deactivated', user_id)
            */
            return default;
        }

        protected async Task<MailingMailing> GetAbTestingDescriptionModifyingFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _get_ab_testing_description_modifying_fields(self):
            // return ['ab_testing_enabled', 'ab_testing_pc', 'ab_testing_schedule_datetime', 'ab_testing_winner_selection', 'campaign_id']
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py) ---
            // def _get_ab_testing_description_modifying_fields(self):
            // fields_list = super()._get_ab_testing_description_modifying_fields()
            // return fields_list + ['ab_testing_sms_winner_selection']
            */
            return default;
        }

        protected async Task<MailingMailing> GetAbTestingDescriptionValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _get_ab_testing_description_values(self):
            // self.ensure_one()
            // return {
            //     'mailing': self,
            //     'ab_testing_count': self.ab_testing_mailings_count,
            //     'ab_testing_winner_selection_description': self._get_ab_testing_winner_selection()['description'],
            //     'total_ab_testing_pc': sum([
            //         mailing.ab_testing_pc for mailing in self._get_ab_testing_siblings_mailings()
            //     ]),
            // }
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py) ---
            // def _get_ab_testing_description_values(self):
            // values = super()._get_ab_testing_description_values()
            // if self.mailing_type == 'sms':
            //     values.update({
            //         'ab_testing_count': self.ab_testing_mailings_sms_count,
            //         'ab_testing_winner_selection': self.ab_testing_sms_winner_selection,
            //     })
            // return values
            */
            return default;
        }

        protected async Task<MailingMailing> GetAbTestingSiblingsMailingsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _get_ab_testing_siblings_mailings(self):
            // return self.campaign_id.mailing_mail_ids.filtered(lambda m: m.ab_testing_enabled)
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py) ---
            // def _get_ab_testing_siblings_mailings(self):
            // mailings = super()._get_ab_testing_siblings_mailings()
            // if self.mailing_type == 'sms':
            //     mailings = self.campaign_id.mailing_sms_ids.filtered('ab_testing_enabled')
            // return mailings
            */
            return default;
        }

        protected async Task<MailingMailing> GetAbTestingWinnerSelectionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _get_ab_testing_winner_selection(self):
            // ab_testing_winner_selection_description = dict(
            //     self._fields.get('ab_testing_winner_selection').related_field.selection
            // ).get(self.ab_testing_winner_selection)
            // return {
            //     'value': self.ab_testing_winner_selection,
            //     'description': ab_testing_winner_selection_description,
            // }
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py) ---
            // def _get_ab_testing_winner_selection(self):
            // result = super()._get_ab_testing_winner_selection()
            // if self.mailing_type == 'sms':
            //     ab_testing_winner_selection_description = dict(
            //         self._fields.get('ab_testing_sms_winner_selection').related_field.selection
            //     ).get(self.ab_testing_sms_winner_selection)
            //     result.update({
            //         'value': self.campaign_id.ab_testing_sms_winner_selection,
            //         'description': ab_testing_winner_selection_description
            //     })
            // return result
            */
            return default;
        }

        protected async Task<MailingMailing> GetDefaultAbTestingCampaignValuesInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _get_default_ab_testing_campaign_values(self, values=None):
            // values = values or dict()
            // return {
            //     'ab_testing_schedule_datetime': values.get('ab_testing_schedule_datetime') or self.ab_testing_schedule_datetime,
            //     'ab_testing_winner_selection': values.get('ab_testing_winner_selection') or self.ab_testing_winner_selection,
            //     'mailing_mail_ids': self.ids,
            //     'name': _('A/B Test: %s', values.get('subject') or self.subject or fields.Datetime.now()),
            //     'user_id': values.get('user_id') or self.user_id.id or self.env.user.id,
            // }
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py) ---
            // def _get_default_ab_testing_campaign_values(self, values=None):
            // campaign_values = super()._get_default_ab_testing_campaign_values(values)
            // values = values or dict()
            // if self.mailing_type == 'sms':
            //     sms_subject = values.get('sms_subject') or self.sms_subject
            //     if sms_subject:
            //         campaign_values['name'] = _("A/B Test: %s", sms_subject)
            //     campaign_values['ab_testing_sms_winner_selection'] = self.ab_testing_sms_winner_selection
            // return campaign_values
            */
            return default;
        }

        protected async Task<MailingMailing> GetDefaultMailServerIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _get_default_mail_server_id(self):
            // server_id = self.env['ir.config_parameter'].sudo().get_param('mass_mailing.mail_server_id')
            // try:
            //     server_id = literal_eval(server_id) if server_id else False
            //     return self.env['ir.mail_server'].search([('id', '=', server_id)]).id
            // except ValueError:
            //     return False
            */
            return default;
        }

        protected async Task<MailingMailing> GetDefaultMailingDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _get_default_mailing_domain(self):
            // mailing_domain = []
            // if hasattr(self.env[self.mailing_model_name], '_mailing_get_default_domain'):
            //     mailing_domain = self.env[self.mailing_model_name]._mailing_get_default_domain(self)
            // 
            // if self.mailing_type == 'mail' and 'is_blacklisted' in self.env[self.mailing_model_name]._fields:
            //     mailing_domain = expression.AND([[('is_blacklisted', '=', False)], mailing_domain])
            // 
            // return mailing_domain
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py) ---
            // def _get_default_mailing_domain(self):
            // mailing_domain = super(Mailing, self)._get_default_mailing_domain()
            // if self.mailing_type == 'sms' and 'phone_sanitized_blacklisted' in self.env[self.mailing_model_name]._fields:
            //     mailing_domain = expression.AND([mailing_domain, [('phone_sanitized_blacklisted', '=', False)]])
            // 
            // return mailing_domain
            */
            return default;
        }

        protected async Task<MailingMailing> GetImageByUrlInternalAsync(object url, object session)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _get_image_by_url(self, url, session):
            // maxsize = int(tools.config.get("import_image_maxbytes", DEFAULT_IMAGE_MAXBYTES))
            // _logger.debug("Trying to import image from URL: %s", url)
            // try:
            //     response = session.get(url, timeout=int(tools.config.get("import_image_timeout", DEFAULT_IMAGE_TIMEOUT)))
            //     response.raise_for_status()
            // 
            //     if response.headers.get('Content-Length') and int(response.headers['Content-Length']) > maxsize:
            //         raise ImportValidationError(
            //             _("File size exceeds configured maximum (%s bytes)", maxsize)
            //         )
            // 
            //     content = bytearray()
            //     for chunk in response.iter_content(DEFAULT_IMAGE_CHUNK_SIZE):
            //         content += chunk
            //         if len(content) > maxsize:
            //             raise ImportValidationError(
            //                 _("File size exceeds configured maximum (%s bytes)", maxsize)
            //             )
            // 
            //     image = Image.open(io.BytesIO(content))
            //     w, h = image.size
            //     if w * h > 42e6:
            //         raise ImportValidationError(
            //             _("Image size excessive, imported images must be smaller than 42 million pixel")
            //         )
            // 
            //     return content
            // except UnidentifiedImageError:
            //     _logger.warning('This file could not be decoded as an image file.', exc_info=True)
            //     raise
            // except Exception as e:
            //     _logger.exception(e)
            //     raise ImportValidationError(_("Could not retrieve URL: %s", url)) from e
            */
            return default;
        }

        protected async Task<MailingMailing> GetLinkTrackerValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _get_link_tracker_values(self):
            // self.ensure_one()
            // vals = {'mass_mailing_id': self.id}
            // 
            // if self.campaign_id:
            //     vals['campaign_id'] = self.campaign_id.id
            // if self.source_id:
            //     vals['source_id'] = self.source_id.id
            // if self.medium_id:
            //     vals['medium_id'] = self.medium_id.id
            // return vals
            */
            return default;
        }

        protected async Task<MailingMailing> GetMassMailingContextInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _get_mass_mailing_context(self):
            // """Returns extra context items with pre-filled blacklist and seen list for massmailing"""
            // return {
            //     'post_convert_links': self._get_link_tracker_values(),
            // }
            */
            return default;
        }

        protected async Task<MailingMailing> GetOptOutListInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _get_opt_out_list(self):
            // """ Give list of opt-outed emails, depending on specific model-based
            // computation if available.
            // 
            // :return list: opt-outed emails, preferably normalized (aka not records)
            // """
            // self.ensure_one()
            // opt_out = {}
            // target = self.env[self.mailing_model_real]
            // if hasattr(self.env[self.mailing_model_name], '_mailing_get_opt_out_list'):
            //     opt_out = self.env[self.mailing_model_name]._mailing_get_opt_out_list(self)
            //     _logger.info(
            //         "Mass-mailing %s targets %s, blacklist: %s emails",
            //         self, target._name, len(opt_out))
            // else:
            //     _logger.info("Mass-mailing %s targets %s, no opt out list available", self, target._name)
            // return opt_out
            */
            return default;
        }

        protected async Task<MailingMailing> GetOptOutListSmsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py) ---
            // def _get_opt_out_list_sms(self):
            // """ Give list of opt-outed records, depending on specific model-based
            // computation if available.
            // 
            // :return list: opt-outed record IDs
            // """
            // self.ensure_one()
            // opt_out = []
            // target = self.env[self.mailing_model_real]
            // if hasattr(self.env[self.mailing_model_name], '_mailing_get_opt_out_list_sms'):
            //     opt_out = self.env[self.mailing_model_name]._mailing_get_opt_out_list_sms(self)
            //     _logger.info("Mass SMS %s targets %s: optout: %s contacts", self, target._name, len(opt_out))
            // else:
            //     _logger.info("Mass SMS %s targets %s: no opt out list available", self, target._name)
            // return opt_out
            */
            return default;
        }

        protected async Task<MailingMailing> GetPrettyMailingTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _get_pretty_mailing_type(self):
            // return _('Emails')
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py) ---
            // def _get_pretty_mailing_type(self):
            // if self.mailing_type == 'sms':
            //     return _('SMS Text Message')
            // return super(Mailing, self)._get_pretty_mailing_type()
            */
            return default;
        }

        protected async Task<MailingMailing> GetRecipientsDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: marketing_card, FILE: mailing_mailing.py) ---
            // def _get_recipients_domain(self):
            // """Domain with an additional condition that the card must exist for the records."""
            // domain = super()._get_recipients_domain()
            // if self.card_campaign_id:
            //     res_ids = self.env['card.card'].search_fetch([('campaign_id', '=', self.card_campaign_id.id)], ['res_id']).mapped('res_id')
            //     domain = osv.expression.AND([domain, [('id', 'in', res_ids)]])
            // return domain
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _get_recipients_domain(self):
            // """Overridable getter used to get the domain of the recipients at the time of sending."""
            // return self._parse_mailing_domain()
            */
            return default;
        }

        protected async Task<MailingMailing> GetRecipientsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _get_recipients(self):
            // mailing_domain = self._get_recipients_domain()
            // res_ids = self.env[self.mailing_model_real].search(mailing_domain).ids
            // 
            // # randomly choose a fragment
            // if self.ab_testing_enabled and not self.ab_testing_is_winner_mailing:
            //     contact_nbr = self.env[self.mailing_model_real].search_count(mailing_domain)
            //     topick = 0
            //     if contact_nbr:
            //         topick = max(int(contact_nbr / 100.0 * self.ab_testing_pc), 1)
            //     if self.campaign_id and self.ab_testing_enabled:
            //         already_mailed = self.campaign_id._get_mailing_recipients()[self.campaign_id.id]
            //     else:
            //         already_mailed = set([])
            //     remaining = set(res_ids).difference(already_mailed)
            //     if topick > len(remaining) or (len(remaining) > 0 and topick == 0):
            //         topick = len(remaining)
            //     res_ids = random.sample(sorted(remaining), topick)
            // return res_ids
            */
            return default;
        }

        protected async Task<MailingMailing> GetRemainingRecipientsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _get_remaining_recipients(self):
            // res_ids = self._get_recipients()
            // trace_domain = [('model', '=', self.mailing_model_real)]
            // if self.ab_testing_enabled and self.ab_testing_is_winner_mailing:
            //     trace_domain = expression.AND([trace_domain, [('mass_mailing_id', 'in', self._get_ab_testing_siblings_mailings().ids)]])
            // else:
            //     trace_domain = expression.AND([trace_domain, [
            //         ('res_id', 'in', res_ids),
            //         ('mass_mailing_id', '=', self.id),
            //     ]])
            // already_mailed = self.env['mailing.trace'].search_read(trace_domain, ['res_id'])
            // done_res_ids = {record['res_id'] for record in already_mailed}
            // return [rid for rid in res_ids if rid not in done_res_ids]
            */
            return default;
        }

        protected async Task<MailingMailing> GetSeenListExtraInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _get_seen_list_extra(self):
            // return ('', '')
            */
            return default;
        }

        protected async Task<MailingMailing> GetSeenListInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _get_seen_list(self):
            // """Returns a set of emails already targeted by current mailing/campaign (no duplicates)"""
            // self.ensure_one()
            // target = self.env[self.mailing_model_real]
            // 
            // query = """
            //     SELECT s.email
            //       FROM mailing_trace s
            //       JOIN %(target)s t ON (s.res_id = t.id)
            //       %(join_domain)s
            //      WHERE s.email IS NOT NULL
            //       %(where_domain)s
            // """
            // 
            // if self.ab_testing_enabled:
            //     query += """
            //        AND s.campaign_id = %%(mailing_campaign_id)s;
            //     """
            // else:
            //     query += """
            //        AND s.mass_mailing_id = %%(mailing_id)s
            //        AND s.model = %%(target_model)s;
            //     """
            // join_domain, where_domain = self._get_seen_list_extra()
            // query = query % {'target': target._table, 'join_domain': join_domain, 'where_domain': where_domain}
            // params = {'mailing_id': self.id, 'mailing_campaign_id': self.campaign_id.id, 'target_model': self.mailing_model_real}
            // self._cr.execute(query, params)
            // seen_list = set(m[0] for m in self._cr.fetchall())
            // _logger.info(
            //     "Mass-mailing %s has already reached %s %s emails", self, len(seen_list), target._name)
            // return seen_list
            */
            return default;
        }

        protected async Task<MailingMailing> GetSeenListSmsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py) ---
            // def _get_seen_list_sms(self):
            // """Returns a set of emails already targeted by current mailing/campaign (no duplicates)"""
            // self.ensure_one()
            // target = self.env[self.mailing_model_real]
            // 
            // partner_fields = []
            // if isinstance(target, self.pool['mail.thread.phone']):
            //     phone_fields = ['phone_sanitized']
            // else:
            //     phone_fields = [
            //         fname for fname in target._phone_get_number_fields()
            //         if fname in target._fields and target._fields[fname].store
            //     ]
            //     partner_fields = target._mail_get_partner_fields()
            // partner_field = next(
            //     (fname for fname in partner_fields if target._fields[fname].store and target._fields[fname].type == 'many2one'),
            //     False
            // )
            // if not phone_fields and not partner_field:
            //     raise UserError(_("Unsupported %s for mass SMS", self.mailing_model_id.name))
            // 
            // query = """
            //     SELECT %(select_query)s
            //       FROM mailing_trace trace
            //       JOIN %(target_table)s target ON (trace.res_id = target.id)
            //       %(join_add_query)s
            //      WHERE (%(where_query)s)
            //        AND trace.mass_mailing_id = %%(mailing_id)s
            //        AND trace.model = %%(target_model)s
            // """
            // if phone_fields:
            //     # phone fields are checked on target mailed model
            //     select_query = 'target.id, ' + ', '.join('target.%s' % fname for fname in phone_fields)
            //     where_query = ' OR '.join('target.%s IS NOT NULL' % fname for fname in phone_fields)
            //     join_add_query = ''
            // else:
            //     # phone fields are checked on res.partner model
            //     partner_phone_fields = ['mobile', 'phone']
            //     select_query = 'target.id, ' + ', '.join('partner.%s' % fname for fname in partner_phone_fields)
            //     where_query = ' OR '.join('partner.%s IS NOT NULL' % fname for fname in partner_phone_fields)
            //     join_add_query = 'JOIN res_partner partner ON (target.%s = partner.id)' % partner_field
            // 
            // query = query % {
            //     'select_query': select_query,
            //     'where_query': where_query,
            //     'target_table': target._table,
            //     'join_add_query': join_add_query,
            // }
            // params = {'mailing_id': self.id, 'target_model': self.mailing_model_real}
            // self._cr.execute(query, params)
            // query_res = self._cr.fetchall()
            // seen_list = set(number for item in query_res for number in item[1:] if number)
            // seen_ids = set(item[0] for item in query_res)
            // _logger.info("Mass SMS %s targets %s: already reached %s SMS", self, target._name, len(seen_list))
            // return list(seen_ids), list(seen_list)
            */
            return default;
        }

        public async Task<MailingMailing> GetSmsLinkReplacementsPlaceholdersAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py) ---
            // def get_sms_link_replacements_placeholders(self):
            // """Get placeholders for replaced links in sms widget for accurate computation of sms counts.
            // 
            // Reminders and assumptions:
            //   * Links wille be transformed to the format "[base_url]/r/[link_tracker_code]/s/[sms_id]".
            //   * unsubscribe is formatted as: "\nSTOP SMS : [base_url]/sms/[mailing_id]/[trace_code]".
            // 
            // :return: Character counts used for links, formatted as `{link: str, unsubscribe: str}`.
            // """
            // if self:
            //     self.ensure_one()
            // 
            // self.check_access('write')
            // 
            // max_sms = self.env['sms.sms'].sudo().search_read([], ['id'], order='id desc', limit=1)
            // sms_id_length = max(len(str(max_sms[0]['id'])), 5) if max_sms else 5  # Assumes a mailing won't be more than 10⁵ sms at once
            // max_code = self.env['link.tracker.code'].sudo().search_read([], ['code'], order='id DESC', limit=1)
            // code_length = len(max_code[0]['code']) + 1 if max_code else LINK_TRACKER_MIN_CODE_LENGTH
            // 
            // if self.id:
            //     mailing_id_placeholder_length = len(str(self.id))
            // else:
            //     max_mailing = self.env['mailing.mailing'].sudo().search_read([], ['id'], order='id DESC', limit=1)
            //     mailing_id_placeholder_length = len(str(max_mailing[0]['id'] + 1)) if max_mailing else 1
            // mailing_id_placeholder = 'x' * mailing_id_placeholder_length
            // 
            // base_url = self.get_base_url()
            // opt_out_url = urljoin(base_url, f"sms/{mailing_id_placeholder}/{'x' * self.env['mailing.trace'].CODE_SIZE}")
            // return {
            //     'link': urljoin(base_url, f"r/{'x' * code_length}/s/{'x' * sms_id_length}"),
            //     'unsubscribe': f"\n{self.env['sms.composer']._get_unsubscribe_info(opt_out_url)}"
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MailingMailing> GetUnsubscribeOneclickUrlInternalAsync(object email_to, Guid res_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _get_unsubscribe_oneclick_url(self, email_to, res_id):
            // url = werkzeug.urls.url_join(
            //     self.get_base_url(), 'mailing/%(mailing_id)s/unsubscribe_oneclick?%(params)s' % {
            //         'mailing_id': self.id,
            //         'params': werkzeug.urls.url_encode({
            //             'document_id': res_id,
            //             'email': email_to,
            //             'hash_token': self._generate_mailing_recipient_token(res_id, email_to),
            //         }),
            //     }
            // )
            // return url
            */
            return default;
        }

        protected async Task<MailingMailing> GetUnsubscribeUrlInternalAsync(object email_to, Guid res_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _get_unsubscribe_url(self, email_to, res_id):
            // url = werkzeug.urls.url_join(
            //     self.get_base_url(), 'mailing/%(mailing_id)s/confirm_unsubscribe?%(params)s' % {
            //         'mailing_id': self.id,
            //         'params': werkzeug.urls.url_encode({
            //             'document_id': res_id,
            //             'email': email_to,
            //             'hash_token': self._generate_mailing_recipient_token(res_id, email_to),
            //         }),
            //     }
            // )
            // return url
            */
            return default;
        }

        protected async Task<MailingMailing> GetViewUrlInternalAsync(object email_to, Guid res_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _get_view_url(self, email_to, res_id):
            // url = werkzeug.urls.url_join(
            //     self.get_base_url(), 'mailing/%(mailing_id)s/view?%(params)s' % {
            //         'mailing_id': self.id,
            //         'params': werkzeug.urls.url_encode({
            //             'document_id': res_id,
            //             'email': email_to,
            //             'hash_token': self._generate_mailing_recipient_token(res_id, email_to),
            //         }),
            //     }
            // )
            // return url
            */
            return default;
        }

        public async Task<MailingMailing> LaunchAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_launch(self):
            // self.write({'schedule_type': 'now'})
            // return self.action_put_in_queue()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MailingMailing> ParseMailingDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _parse_mailing_domain(self):
            // self.ensure_one()
            // try:
            //     mailing_domain = literal_eval(self.mailing_domain)
            // except Exception:
            //     mailing_domain = [('id', 'in', [])]
            // return mailing_domain
            */
            return default;
        }

        protected async Task<MailingMailing> PrepareStatisticsEmailValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _prepare_statistics_email_values(self):
            // """Return some statistics that will be displayed in the mailing statistics email.
            // 
            // Each item in the returned list will be displayed as a table, with a title and
            // 1, 2 or 3 columns.
            // """
            // self.ensure_one()
            // mailing_type = self._get_pretty_mailing_type()
            // kpi = {}
            // if self.mailing_type == 'mail':
            //     kpi = {
            //         'kpi_fullname': _('Engagement on %(expected)i %(mailing_type)s Sent',
            //                           expected=self.expected,
            //                           mailing_type=mailing_type
            //                          ),
            //         'kpi_col1': {
            //             'value': f'{self.received_ratio}%',
            //             'col_subtitle': _('RECEIVED (%i)', self.delivered),
            //         },
            //         'kpi_col2': {
            //             'value': f'{self.opened_ratio}%',
            //             'col_subtitle': _('OPENED (%i)', self.opened),
            //         },
            //         'kpi_col3': {
            //             'value': f'{self.replied_ratio}%',
            //             'col_subtitle': _('REPLIED (%i)', self.replied),
            //         },
            //         'kpi_action': None,
            //         'kpi_name': self.mailing_type,
            //     }
            // 
            // random_tip = self.env['digest.tip'].search(
            //     [('group_id.category_id', '=', self.env.ref('base.module_category_marketing_email_marketing').id)]
            // )
            // if random_tip:
            //     random_tip = random.choice(random_tip).tip_description
            // 
            // formatted_date = tools.format_datetime(
            //     self.env, self.sent_date, self.user_id.tz, 'MMM dd, YYYY', self.user_id.lang
            // ) if self.sent_date else False
            // 
            // web_base_url = self.get_base_url()
            // 
            // return {
            //     'title': _('24H Stats of %(mailing_type)s "%(mailing_name)s"',
            //                mailing_type=mailing_type,
            //                mailing_name=self.subject
            //                ),
            //     'top_button_label': _('More Info'),
            //     'top_button_url': url_join(web_base_url, f'/odoo/mailing.mailing/{self.id}'),
            //     'kpi_data': [
            //         kpi,
            //         {
            //             'kpi_fullname': _('Business Benefits on %(expected)i %(mailing_type)s Sent',
            //                               expected=self.expected,
            //                               mailing_type=mailing_type
            //                              ),
            //             'kpi_action': None,
            //             'kpi_col1': {},
            //             'kpi_col2': {},
            //             'kpi_col3': {},
            //             'kpi_name': 'trace',
            //         },
            //     ],
            //     'tips': [random_tip] if random_tip else False,
            //     'formatted_date': formatted_date,
            // }
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_crm, FILE: mailing_mailing.py) ---
            // def _prepare_statistics_email_values(self):
            // self.ensure_one()
            // values = super(MassMailing, self)._prepare_statistics_email_values()
            // if not self.user_id:
            //     return values
            // if not self.env['crm.lead'].has_access('read'):
            //     return values
            // values['kpi_data'][1]['kpi_col1'] = {
            //     'value': tools.misc.format_decimalized_number(self.crm_lead_count, decimal=0),
            //     'col_subtitle': _('LEADS'),
            // }
            // values['kpi_data'][1]['kpi_name'] = 'lead'
            // return values
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sale, FILE: mailing_mailing.py) ---
            // def _prepare_statistics_email_values(self):
            // self.ensure_one()
            // values = super(MassMailing, self)._prepare_statistics_email_values()
            // if not self.user_id:
            //     return values
            // 
            // self_with_company = self.with_company(self.user_id.company_id)
            // currency = self.user_id.company_id.currency_id
            // formated_amount = tools.misc.format_decimalized_amount(self_with_company.sale_invoiced_amount, currency)
            // 
            // values['kpi_data'][1]['kpi_col2'] = {
            //     'value': self.sale_quotation_count,
            //     'col_subtitle': _('QUOTATIONS'),
            // }
            // values['kpi_data'][1]['kpi_col3'] = {
            //     'value': formated_amount,
            //     'col_subtitle': _('INVOICED'),
            // }
            // values['kpi_data'][1]['kpi_name'] = 'sale'
            // return values
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py) ---
            // def _prepare_statistics_email_values(self):
            // """Return some statistics that will be displayed in the mailing statistics email.
            // 
            // Each item in the returned list will be displayed as a table, with a title and
            // 1, 2 or 3 columns.
            // """
            // values = super(Mailing, self)._prepare_statistics_email_values()
            // if self.mailing_type == 'sms':
            //     mailing_type = self._get_pretty_mailing_type()
            //     values['title'] = _('24H Stats of %(mailing_type)s "%(mailing_name)s"',
            //                         mailing_type=mailing_type,
            //                         mailing_name=self.subject
            //                        )
            //     values['kpi_data'][0] = {
            //         'kpi_fullname': _('Report for %(expected)i %(mailing_type)s Sent',
            //                           expected=self.expected,
            //                           mailing_type=mailing_type
            //                          ),
            //         'kpi_col1': {
            //             'value': f'{self.received_ratio}%',
            //             'col_subtitle': _('RECEIVED (%i)', self.delivered),
            //         },
            //         'kpi_col2': {
            //             'value': f'{self.clicks_ratio}%',
            //             'col_subtitle': _('CLICKED (%i)', self.clicked),
            //         },
            //         'kpi_col3': {
            //             'value': f'{self.bounced_ratio}%',
            //             'col_subtitle': _('BOUNCED (%i)', self.bounced),
            //         },
            //         'kpi_action': None,
            //         'kpi_name': self.mailing_type,
            //     }
            // return values
            */
            return default;
        }

        protected async Task<MailingMailing> ProcessMassMailingQueueInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _process_mass_mailing_queue(self):
            // mass_mailings = self.search([('state', 'in', ('in_queue', 'sending')), '|', ('schedule_date', '<', fields.Datetime.now()), ('schedule_date', '=', False)])
            // count_total = len(mass_mailings)
            // for count_done, mass_mailing in enumerate(mass_mailings, start=1):
            //     context_user = mass_mailing.user_id or mass_mailing.write_uid or self.env.user
            //     mass_mailing = mass_mailing.with_context(
            //         **self.env['res.users'].with_user(context_user).context_get()
            //     )
            //     if len(mass_mailing._get_remaining_recipients()) > 0:
            //         mass_mailing.state = 'sending'
            //         mass_mailing._action_send_mail()
            //     else:
            //         mass_mailing.write({
            //             'state': 'done',
            //             'sent_date': fields.Datetime.now(),
            //             # send the KPI mail only if it's the first sending
            //             'kpi_mail_required': not mass_mailing.sent_date,
            //         })
            //     self.env['ir.cron']._notify_progress(done=count_done, remaining=count_total - count_done)
            // 
            // if self.env['ir.config_parameter'].sudo().get_param('mass_mailing.mass_mailing_reports'):
            //     mailings = self.env['mailing.mailing'].search([
            //         ('kpi_mail_required', '=', True),
            //         ('state', '=', 'done'),
            //         ('sent_date', '<=', fields.Datetime.now() - relativedelta(days=1)),
            //         ('sent_date', '>=', fields.Datetime.now() - relativedelta(days=5)),
            //     ])
            //     if mailings:
            //         mailings._action_send_statistics()
            */
            return default;
        }

        public async Task<MailingMailing> PutInQueueAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: marketing_card, FILE: mailing_mailing.py) ---
            // def action_put_in_queue(self):
            // """Detect mismatches before scheduling."""
            // for mailing in self.filtered('card_campaign_id'):
            //     if mailing.card_requires_sync_count:
            //         raise exceptions.UserError(_(
            //             'You should update all the cards for %(mailing)s before scheduling a mailing.',
            //             mailing=mailing.display_name
            //         ))
            // super().action_put_in_queue()
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_put_in_queue(self):
            // self.write({'state': 'in_queue'})
            // cron = self.env.ref('mass_mailing.ir_cron_mass_mailing_queue')
            // cron._trigger(
            //     schedule_date or fields.Datetime.now()
            //     for schedule_date in self.mapped('schedule_date')
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingMailing> RedirectToInvoicedAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sale, FILE: mailing_mailing.py) ---
            // def action_redirect_to_invoiced(self):
            // domain = expression.AND([
            //     [('source_id', '=', self.source_id.id)],
            //     [('state', 'not in', ['draft', 'cancel'])]
            // ])
            // moves = self.env['account.move'].search(domain)
            // helper_header = _("No Revenues yet!")
            // helper_message = _("Revenues will appear here once orders are turned into invoices.")
            // return {
            //     'context': {
            //         'create': False,
            //         'edit': False,
            //         'view_no_maturity': True,
            //         'search_default_group_by_invoice_date_week': True,
            //         'invoice_report_view_hide_invoice_date': True,
            //     },
            //     'domain': [('move_id', 'in', moves.ids)],
            //     'help': Markup('<p class="o_view_nocontent_smiling_face">%s</p><p>%s</p>') % (
            //         helper_header, helper_message,
            //     ),
            //     'name': _("Invoices Analysis"),
            //     'res_model': 'account.invoice.report',
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'list,pivot,graph,form',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingMailing> RedirectToLeadsAndOpportunitiesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_crm, FILE: mailing_mailing.py) ---
            // def action_redirect_to_leads_and_opportunities(self):
            // text = _("Leads") if self.use_leads else _("Opportunities")
            // helper_header = _("No %s yet!", text)
            // helper_message = _("Note that Odoo cannot track replies if they are sent towards email addresses to this database.")
            // return {
            //     'context': {
            //         'active_test': False,
            //         'create': False,
            //         'search_default_group_by_create_date_day': True,
            //         'crm_lead_view_hide_month': True,
            //     },
            //     'domain': [('source_id', 'in', self.source_id.ids)],
            //     'help': Markup('<p class="o_view_nocontent_smiling_face">%s</p><p>%s</p>') % (
            //         helper_header, helper_message,
            //     ),
            //     'name': _("Leads Analysis"),
            //     'res_model': 'crm.lead',
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'list,pivot,graph,form',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingMailing> RedirectToQuotationsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sale, FILE: mailing_mailing.py) ---
            // def action_redirect_to_quotations(self):
            // helper_header = _("No Quotations yet!")
            // helper_message = _("Quotations will appear here once your customers add "
            //                    "products to their Carts or when your sales reps assign this mailing.")
            // return {
            //     'context': {
            //         'create': False,
            //         'search_default_group_by_date_day': True,
            //         'sale_report_view_hide_date': True,
            //     },
            //     'domain': [('source_id', '=', self.source_id.id)],
            //     'help': Markup('<p class="o_view_nocontent_smiling_face">%s</p><p>%s</p>') % (
            //         helper_header, helper_message,
            //     ),
            //     'name': _("Sales Analysis"),
            //     'res_model': 'sale.report',
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'list,pivot,graph,form',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingMailing> ReloadAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_reload(self):
            // pass
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingMailing> RemoveFavoriteAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_remove_favorite(self):
            // """Remove the current mailing from the favorites list."""
            // self.favorite = False
            // 
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'message': _(
            //             'Design removed from the %s Templates!',
            //             ', '.join(self.mapped('mailing_model_id.name')),
            //         ),
            //         'next': {'type': 'ir.actions.act_window_close'},
            //         'sticky': False,
            //         'type': 'info',
            //     }
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingMailing> RetryFailedAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_retry_failed(self):
            // failed_mails = self.env['mail.mail'].sudo().search([
            //     ('mailing_id', 'in', self.ids),
            //     ('state', '=', 'exception')
            // ])
            // failed_mails.mapped('mailing_trace_ids').unlink()
            // failed_mails.unlink()
            // self.action_put_in_queue()
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py) ---
            // def action_retry_failed(self):
            // mass_sms = self.filtered(lambda m: m.mailing_type == 'sms')
            // if mass_sms:
            //     mass_sms.action_retry_failed_sms()
            // return super(Mailing, self - mass_sms).action_retry_failed()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingMailing> RetryFailedSmsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py) ---
            // def action_retry_failed_sms(self):
            // failed_sms = self.env['sms.sms'].sudo().search([
            //     ('mailing_id', 'in', self.ids),
            //     ('state', '=', 'error')
            // ])
            // failed_sms.mapped('mailing_trace_ids').unlink()
            // failed_sms.unlink()
            // self.action_put_in_queue()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingMailing> ScheduleAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_schedule(self):
            // self.ensure_one()
            // if self.schedule_date and self.schedule_date > fields.Datetime.now():
            //     return self.action_put_in_queue()
            // action = self.env["ir.actions.actions"]._for_xml_id("mass_mailing.mailing_mailing_schedule_date_action")
            // action['context'] = dict(self.env.context, default_mass_mailing_id=self.id, dialog_size='medium')
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingMailing> SelectAsWinnerAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_select_as_winner(self):
            // self.ensure_one()
            // if not self.ab_testing_enabled:
            //     raise ValueError(_("A/B test option has not been enabled"))
            // final_mailing = self.copy({
            //     'ab_testing_pc': 100,
            //     'name': _(" %(subject)s (final)", subject=self.name)  # Add suffix on name to show it's the final mailing
            // })
            // self.campaign_id.ab_testing_winner_mailing_id = final_mailing
            // final_mailing.action_launch()
            // action = self.env['ir.actions.act_window']._for_xml_id('mass_mailing.action_ab_testing_open_winner_mailing')
            // action['res_id'] = final_mailing.id
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingMailing> SendMailAsync(Guid id, MailingMailingSendMailRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: marketing_card, FILE: mailing_mailing.py) ---
            // def action_send_mail(self, res_ids=None):
            // for mailing in self.filtered('card_campaign_id'):
            //     if mailing.card_requires_sync_count:
            //         raise exceptions.UserError(_(
            //             'You should update all the cards for %(mailing)s before scheduling a mailing.',
            //             mailing=mailing.display_name
            //         ))
            // return super().action_send_mail(res_ids)
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_send_mail(self, res_ids=None):
            // return self._action_send_mail(res_ids)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingMailing> SendSmsAsync(Guid id, MailingMailingSendSmsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py) ---
            // def action_send_sms(self, res_ids=None):
            // for mailing in self:
            //     if not res_ids:
            //         res_ids = mailing._get_remaining_recipients()
            //     if res_ids:
            //         composer = self.env['sms.composer'].with_context(active_id=False).create(mailing._send_sms_get_composer_values(res_ids))
            //         composer._action_send_sms()
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MailingMailing> SendSmsGetComposerValuesInternalAsync(List<Guid> res_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py) ---
            // def _send_sms_get_composer_values(self, res_ids):
            // return {
            //     # content
            //     'body': self.body_plaintext,
            //     'template_id': self.sms_template_id.id,
            //     'res_model': self.mailing_model_real,
            //     'res_ids': repr(res_ids),
            //     # options
            //     'composition_mode': 'mass',
            //     'mailing_id': self.id,
            //     'mass_keep_log': self.keep_archives,
            //     'mass_force_send': self.sms_force_send,
            //     'mass_sms_allow_unsubscribe': self.sms_allow_unsubscribe,
            // }
            */
            return default;
        }

        public async Task<MailingMailing> SendWinnerMailingAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_send_winner_mailing(self):
            // """Send the winner mailing based on the winner selection field.
            // This action is used in 2 cases:
            //     - When the user clicks on a button to send the winner mailing. There is only one mailing in self
            //     - When the cron is executed to send winner mailing based on the A/B testing schedule datetime. In this
            //     case 'self' contains all the mailing for the campaigns so we just need to take the first to determine the
            //     winner.
            // If the winner mailing is computed automatically, we sudo the mailings of the campaign in order to sort correctly
            // the mailings based on the selection that can be used with sub-modules like CRM and Sales
            // """
            // if len(self.campaign_id) != 1:
            //     raise ValueError(_("To send the winner mailing the same campaign should be used by the mailings"))
            // if any(mailing.ab_testing_completed for mailing in self):
            //     raise ValueError(_("To send the winner mailing the campaign should not have been completed."))
            // final_mailing = self[0]
            // sorted_by = final_mailing._get_ab_testing_winner_selection()['value']
            // if sorted_by != 'manual':
            //     ab_testing_mailings = final_mailing._get_ab_testing_siblings_mailings().sudo()
            //     selected_mailings = ab_testing_mailings.filtered(lambda m: m.state == 'done').sorted(sorted_by, reverse=True)
            //     if selected_mailings:
            //         final_mailing = selected_mailings[0]
            //     else:
            //         raise ValidationError(_("No mailing for this A/B testing campaign has been sent yet! Send one first and try again later."))
            // return final_mailing.action_select_as_winner()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingMailing> SetFavoriteAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_set_favorite(self):
            // """Add the current mailing in the favorites list."""
            // self.favorite = True
            // 
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'message': _(
            //             'Design added to the %s Templates!',
            //             ', '.join(self.mapped('mailing_model_id.name')),
            //         ),
            //         'next': {'type': 'ir.actions.act_window_close'},
            //         'sticky': False,
            //         'type': 'info',
            //     }
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingMailing> TestAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_test(self):
            // self.ensure_one()
            // ctx = dict(self.env.context, default_mass_mailing_id=self.id, dialog_size='medium')
            // return {
            //     'name': _('Test Mailing'),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'mailing.mailing.test',
            //     'target': 'new',
            //     'context': ctx,
            // }
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py) ---
            // def action_test(self):
            // if self.mailing_type == 'sms':
            //     ctx = dict(self.env.context, default_mailing_id=self.id, dialog_size='medium')
            //     return {
            //         'name': _('Test Mailing'),
            //         'type': 'ir.actions.act_window',
            //         'view_mode': 'form',
            //         'res_model': 'mailing.sms.test',
            //         'target': 'new',
            //         'context': ctx,
            //     }
            // return super(Mailing, self).action_test()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingMailing> UpdateCardsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: marketing_card, FILE: mailing_mailing.py) ---
            // def action_update_cards(self):
            // """Update the cards in batches, commiting after each batch."""
            // for campaign in self.filtered(lambda mailing: mailing.state == 'draft').card_campaign_id:
            //     campaign._update_cards(self._parse_mailing_domain(), auto_commit=True)
            // return {
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'mailing.mailing',
            //     'res_id': self[0].id,
            //     'view_mode': 'form',
            //     'target': 'current',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingMailing> ViewBouncedAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_bounced(self):
            // return self._action_view_documents_filtered('bounce')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingMailing> ViewClickedAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_clicked(self):
            // return self._action_view_documents_filtered('clicked')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingMailing> ViewDeliveredAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_delivered(self):
            // return self._action_view_documents_filtered('delivered')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingMailing> ViewLinkTrackersAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_link_trackers(self):
            // model_name = self.env['ir.model']._get('link.tracker').display_name
            // recipient = self.env['ir.model']._get(self.mailing_model_real).display_name
            // helper_header = _("No Link Tracker for that mailing!")
            // helper_message = _("Link Trackers will measure how many times each link is clicked as well as "
            //                    "the proportion of %s who clicked at least once in your mailing.", recipient)
            // return {
            //     'name': model_name,
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'list,form',
            //     'res_model': 'link.tracker',
            //     'domain': [('mass_mailing_id', '=', self.id)],
            //     'help': Markup('<p class="o_view_nocontent_smiling_face">%s</p><p>%s</p>') % (
            //         helper_header, helper_message,
            //     ),
            //     'context': dict(self._context, create=False)
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingMailing> ViewMailingContactsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_mailing_contacts(self):
            // """Show the mailing contacts who are in a mailing list selected for this mailing."""
            // self.ensure_one()
            // action = self.env['ir.actions.actions']._for_xml_id('mass_mailing.action_view_mass_mailing_contacts')
            // if self.contact_list_ids:
            //     action['context'] = {
            //         'default_mailing_list_ids': self.contact_list_ids[0].ids,
            //         'default_subscription_ids': [(0, 0, {'list_id': self.contact_list_ids[0].id})],
            //     }
            // action['domain'] = [('list_ids', 'in', self.contact_list_ids.ids)]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingMailing> ViewOpenedAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_opened(self):
            // return self._action_view_documents_filtered('open')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingMailing> ViewRepliedAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_replied(self):
            // return self._action_view_documents_filtered('reply')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingMailing> ViewTracesCanceledAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_traces_canceled(self):
            // return self._action_view_traces_filtered('canceled')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingMailing> ViewTracesFailedAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_traces_failed(self):
            // return self._action_view_traces_filtered('failed')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingMailing> ViewTracesProcessAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_traces_process(self):
            // return self._action_view_traces_filtered('process')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingMailing> ViewTracesScheduledAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_traces_scheduled(self):
            // return self._action_view_traces_filtered('scheduled')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingMailing> ViewTracesSentAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_traces_sent(self):
            // return self._action_view_traces_filtered('sent')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}