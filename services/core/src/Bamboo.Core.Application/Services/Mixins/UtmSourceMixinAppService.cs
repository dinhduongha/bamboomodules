using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("utm", Depends = new[] { "base", "web" })]
    public class UtmSourceMixinAppService : ApplicationService, IUtmSourceMixinAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public UtmSourceMixinAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ActionCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_cancel(self):
            // self.write({'state': 'draft', 'schedule_date': False, 'schedule_type': 'now', 'next_departure': False})
            */
            return default;
        }

        public async Task<TEntity> ActionCompareVersionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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
            return default;
        }

        public async Task<TEntity> ActionDuplicateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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
            return default;
        }

        public async Task<TEntity> ActionFetchFavoritesAsync<TEntity>(IEnumerable<TEntity> entities, object extra_domain) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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
            return default;
        }

        public async Task<TEntity> ActionLaunchAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_launch(self):
            // self.write({'schedule_type': 'now'})
            // return self.action_put_in_queue()
            */
            return default;
        }

        public async Task<TEntity> ActionPutInQueueAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_put_in_queue(self):
            // self.write({'state': 'in_queue'})
            // cron = self.env.ref('mass_mailing.ir_cron_mass_mailing_queue')
            // cron._trigger(
            //     schedule_date or fields.Datetime.now()
            //     for schedule_date in self.mapped('schedule_date')
            // )
            */
            return default;
        }

        public async Task<TEntity> ActionReloadAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_reload(self):
            // pass
            */
            return default;
        }

        public async Task<TEntity> ActionRemoveFavoriteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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
            return default;
        }

        public async Task<TEntity> ActionRetryFailedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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
            */
            return default;
        }

        public async Task<TEntity> ActionScheduleAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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
            return default;
        }

        public async Task<TEntity> ActionSelectAsWinnerAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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
            return default;
        }

        public async Task<TEntity> ActionSendMailAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_send_mail(self, res_ids=None):
            // return self._action_send_mail(res_ids)
            */
            return default;
        }

        public async Task<TEntity> ActionSendMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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
            */
            return default;
        }

        public async Task<TEntity> ActionSendStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> ActionSendWinnerMailingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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
            return default;
        }

        public async Task<TEntity> ActionSetFavoriteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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
            return default;
        }

        public async Task<TEntity> ActionTestAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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
            */
            return default;
        }

        public async Task<TEntity> ActionViewBouncedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_bounced(self):
            // return self._action_view_documents_filtered('bounce')
            */
            return default;
        }

        public async Task<TEntity> ActionViewClickedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_clicked(self):
            // return self._action_view_documents_filtered('clicked')
            */
            return default;
        }

        public async Task<TEntity> ActionViewDeliveredAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_delivered(self):
            // return self._action_view_documents_filtered('delivered')
            */
            return default;
        }

        public async Task<TEntity> ActionViewDocumentsFilteredInternalAsync<TEntity>(IEnumerable<TEntity> entities, object view_filter) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> ActionViewLinkTrackersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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
            return default;
        }

        public async Task<TEntity> ActionViewLivechatChannelsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py) ---
            // def action_view_livechat_channels(self):
            // self.ensure_one()
            // action = self.env['ir.actions.act_window']._for_xml_id('im_livechat.im_livechat_channel_action')
            // action['domain'] = [('rule_ids.chatbot_script_id', 'in', self.ids)]
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionViewMailingContactsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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
            return default;
        }

        public async Task<TEntity> ActionViewOpenedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_opened(self):
            // return self._action_view_documents_filtered('open')
            */
            return default;
        }

        public async Task<TEntity> ActionViewRepliedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_replied(self):
            // return self._action_view_documents_filtered('reply')
            */
            return default;
        }

        public async Task<TEntity> ActionViewTracesCanceledAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_traces_canceled(self):
            // return self._action_view_traces_filtered('canceled')
            */
            return default;
        }

        public async Task<TEntity> ActionViewTracesFailedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_traces_failed(self):
            // return self._action_view_traces_filtered('failed')
            */
            return default;
        }

        public async Task<TEntity> ActionViewTracesFilteredInternalAsync<TEntity>(IEnumerable<TEntity> entities, object view_filter) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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
            */
            return default;
        }

        public async Task<TEntity> ActionViewTracesProcessAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_traces_process(self):
            // return self._action_view_traces_filtered('process')
            */
            return default;
        }

        public async Task<TEntity> ActionViewTracesScheduledAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_traces_scheduled(self):
            // return self._action_view_traces_filtered('scheduled')
            */
            return default;
        }

        public async Task<TEntity> ActionViewTracesSentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_traces_sent(self):
            // return self._action_view_traces_filtered('sent')
            */
            return default;
        }

        public async Task<TEntity> CheckMailingFilterModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> CheckQuestionSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py) ---
            // def _check_question_selection(self):
            // for step in self.script_step_ids:
            //     if step.step_type == "question_selection" and not step.answer_ids:
            //         raise ValidationError(self.env._("Step of type 'Question' must have answers."))
            */
            return default;
        }

        public async Task<TEntity> ComputeAbTestingDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> ComputeAbTestingIsWinnerMailingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_ab_testing_is_winner_mailing(self):
            // for mailing in self:
            //     mailing.ab_testing_is_winner_mailing = mailing.campaign_id.ab_testing_winner_mailing_id == mailing
            */
            return default;
        }

        public async Task<TEntity> ComputeCalendarDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> ComputeClicksRatioInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> ComputeEmailFromInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> ComputeFavoriteDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> ComputeFirstStepWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py) ---
            // def _compute_first_step_warning(self):
            // for script in self:
            //     allowed_first_step_types = [
            //         'question_selection',
            //         'question_email',
            //         'question_phone',
            //         'free_input_single',
            //         'free_input_multi',
            //     ]
            //     welcome_steps = script.script_step_ids and script._get_welcome_steps()
            //     if welcome_steps and welcome_steps[-1].step_type == 'forward_operator':
            //         script.first_step_warning = 'first_step_operator'
            //     elif welcome_steps and welcome_steps[-1].step_type not in allowed_first_step_types:
            //         script.first_step_warning = 'first_step_invalid'
            //     else:
            //         script.first_step_warning = False
            */
            return default;
        }

        public async Task<TEntity> ComputeHasDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_recruitment_source.py) ---
            // def _compute_has_domain(self):
            // for source in self:
            //     if source.alias_id:
            //         source.has_domain = bool(source.alias_id.alias_domain_id)
            //     else:
            //         source.has_domain = bool(source.job_id.company_id.alias_domain_id
            //                                  or self.env.company.alias_domain_id)
            */
            return default;
        }

        public async Task<TEntity> ComputeIsAbTestSentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> ComputeIsBodyEmptyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_is_body_empty(self):
            // for mailing in self:
            //     mailing.is_body_empty = tools.is_html_empty(mailing.body_arch)
            */
            return default;
        }

        public async Task<TEntity> ComputeLinkTrackersCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> ComputeLivechatChannelCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py) ---
            // def _compute_livechat_channel_count(self):
            // channels_data = self.env['im_livechat.channel.rule']._read_group(
            //     [('chatbot_script_id', 'in', self.ids)], ['chatbot_script_id'], ['channel_id:count_distinct'])
            // mapped_channels = {chatbot_script.id: count_distinct for chatbot_script, count_distinct in channels_data}
            // for script in self:
            //     script.livechat_channel_count = mapped_channels.get(script.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeMailServerAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_mail_server_available(self):
            // self.mail_server_available = self.env['ir.config_parameter'].sudo().get_param('mass_mailing.outgoing_mail_server')
            */
            return default;
        }

        public async Task<TEntity> ComputeMailingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> ComputeMailingFilterCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> ComputeMailingFilterIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_mailing_filter_id(self):
            // for mailing in self:
            //     mailing.mailing_filter_id = False
            */
            return default;
        }

        public async Task<TEntity> ComputeMailingModelRealInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_mailing_model_real(self):
            // for mailing in self:
            //     mailing.mailing_model_real = 'mailing.contact' if mailing.mailing_model_id.model == 'mailing.list' else mailing.mailing_model_id.model
            */
            return default;
        }

        public async Task<TEntity> ComputeMailingOnMailingListInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> ComputeMailingTypeDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_mailing_type_description(self):
            // for mailing in self:
            //     mailing.mailing_type_description = dict(self._fields.get('mailing_type').selection).get(mailing.mailing_type)
            */
            return default;
        }

        public async Task<TEntity> ComputeMediumIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_medium_id(self):
            // for mailing in self:
            //     if mailing.mailing_type == 'mail' and not mailing.medium_id:
            //         mailing.medium_id = self.env['utm.medium']._fetch_or_create_utm_medium('email').id
            */
            return default;
        }

        public async Task<TEntity> ComputeNextDepartureInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> ComputeRenderModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_render_model(self):
            // for mailing in self:
            //     mailing.render_model = mailing.mailing_model_real
            */
            return default;
        }

        public async Task<TEntity> ComputeReplyToInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> ComputeReplyToModeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> ComputeScheduleDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> ComputeStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> ComputeTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> ComputeWarningMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> ConvertInlineImagesToUrlsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object html_content) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> ConvertLinksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py) ---
            // def copy(self, default=None):
            // """ Correctly copy the 'triggering_answer_ids' field from the original script_step_ids to the clone.
            // This needs to be done in post-processing to make sure we get references to the newly created
            // answers from the copy instead of references to the answers of the original.
            // 
            // This implementation assumes that the order of created steps and answers will be kept between
            // the original and the clone, using 'zip()' to match the records between the two. """
            // default = default or {}
            // new_scripts = super().copy(default=default)
            // if 'question_ids' in default:
            //     return new_scripts
            // 
            // for old_script, new_script in zip(self, new_scripts):
            //     original_steps = old_script.script_step_ids.sorted()
            //     clone_steps = new_script.script_step_ids.sorted()
            // 
            //     answers_map = {}
            //     for clone_step, original_step in zip(clone_steps, original_steps):
            //         for clone_answer, original_answer in zip(clone_step.answer_ids.sorted(), original_step.answer_ids.sorted()):
            //             answers_map[original_answer] = clone_answer
            // 
            //     for clone_step, original_step in zip(clone_steps, original_steps):
            //         clone_step.write({
            //             'triggering_answer_ids': [
            //                 (4, answer.id)
            //                 for answer in [
            //                     answers_map[original_answer]
            //                     for original_answer
            //                     in original_step.triggering_answer_ids
            //                 ]
            //             ]
            //         })
            // return new_scripts
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, title=self.env._("%s (copy)", script.title)) for script, vals in zip(self, vals_list)]
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
            --- ODOO METHOD SOURCE (MODULE: utm, FILE: utm_source.py) ---
            // def copy_data(self, default=None):
            // """Increment the counter when duplicating the source."""
            // default = default or {}
            // default_name = default.get('name')
            // vals_list = super().copy_data(default=default)
            // for source, vals in zip(self, vals_list):
            //     vals['name'] = self.env['utm.mixin']._get_unique_names("utm.source", [default_name or source.name])[0]
            // return vals_list
            */
            return default;
        }

        public async Task<TEntity> CreateAbTestingUtmCampaignsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> CreateAliasAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_recruitment_source.py) ---
            // def create_alias(self):
            // campaign = self.env.ref('hr_recruitment.utm_campaign_job')
            // medium = self.env['utm.medium']._fetch_or_create_utm_medium('email')
            // for source in self.filtered(lambda s: not s.alias_id):
            //     vals = {
            //         'alias_defaults': {
            //             'job_id': source.job_id.id,
            //             'campaign_id': campaign.id,
            //             'medium_id': medium.id,
            //             'source_id': source.source_id.id,
            //         },
            //         'alias_domain_id': source.job_id.company_id.alias_domain_id.id or self.env.company.alias_domain_id.id,
            //         'alias_model_id': self.env['ir.model']._get_id('hr.applicant'),
            //         'alias_name': f"{source.job_id.alias_name or source.job_id.name}+{source.name}",
            //         'alias_parent_thread_id': source.job_id.id,
            //         'alias_parent_model_id': self.env['ir.model']._get_id('hr.job'),
            //     }
            // 
            //     # check that you can create source before to call mail.alias in sudo with known/controlled vals
            //     source.check_access('create')
            //     source.alias_id = self.env['mail.alias'].sudo().create(vals)
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py) ---
            // def create(self, vals_list):
            // operator_partners_values = [{
            //     'name': vals['title'],
            //     'image_1920': vals.get('image_1920', False),
            //     'active': False,
            // } for vals in vals_list if 'operator_partner_id' not in vals and 'title' in vals]
            // 
            // operator_partners = self.env['res.partner'].create(operator_partners_values)
            // 
            // for vals, partner in zip(
            //     [vals for vals in vals_list if 'operator_partner_id' not in vals and 'title' in vals],
            //     operator_partners
            // ):
            //     vals['operator_partner_id'] = partner.id
            // 
            // return super().create(vals_list)
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
            --- ODOO METHOD SOURCE (MODULE: utm, FILE: utm_source.py) ---
            // def create(self, vals_list):
            // """Create the UTM sources if necessary, generate the name based on the content in batch."""
            // # Create all required <utm.source>
            // utm_sources = self.env['utm.source'].create([
            //     {
            //         'name': values.get('name')
            //         or self.env.context.get('default_name')
            //         or self.env['utm.source']._generate_name(self, values.get(self._rec_name)),
            //     }
            //     for values in vals_list
            //     if not values.get('source_id')
            // ])
            // 
            // # Update "vals_list" to add the ID of the newly created source
            // vals_list_missing_source = [values for values in vals_list if not values.get('source_id')]
            // for values, source in zip(vals_list_missing_source, utm_sources):
            //     values['source_id'] = source.id
            // 
            // for values in vals_list:
            //     if 'name' in values:
            //         del values['name']
            // 
            // return super().create(vals_list)
            */
            return default;
        }

        public async Task<TEntity> CreateAttachmentsFromInlineImagesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object b64images) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields_list) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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
            --- ODOO METHOD SOURCE (MODULE: utm, FILE: utm_source.py) ---
            // def default_get(self, fields_list):
            // # Exclude 'name' from fields_list to avoid retrieving it from context.
            // return super().default_get([field for field in fields_list if field != "name"])
            */
            return default;
        }

        public async Task<TEntity> FixAttachmentOwnershipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> FormatForFrontendInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py) ---
            // def _format_for_frontend(self):
            // """ Small utility method that formats the script into a dict usable by the frontend code. """
            // self.ensure_one()
            // 
            // return {
            //     'id': self.id,
            //     'name': self.title,
            //     'partner': {'id': self.operator_partner_id.id, 'type': 'partner', 'name': self.operator_partner_id.name},
            //     'welcomeSteps': [
            //         step._format_for_frontend()
            //         for step in self._get_welcome_steps()
            //     ]
            // }
            */
            return default;
        }

        public async Task<TEntity> GenerateMailingRecipientTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid document_id, object email) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> GenerateMailingReportTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> GetAbTestingDescriptionModifyingFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _get_ab_testing_description_modifying_fields(self):
            // return ['ab_testing_enabled', 'ab_testing_pc', 'ab_testing_schedule_datetime', 'ab_testing_winner_selection', 'campaign_id']
            */
            return default;
        }

        public async Task<TEntity> GetAbTestingDescriptionValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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
            */
            return default;
        }

        public async Task<TEntity> GetAbTestingSiblingsMailingsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _get_ab_testing_siblings_mailings(self):
            // return self.campaign_id.mailing_mail_ids.filtered(lambda m: m.ab_testing_enabled)
            */
            return default;
        }

        public async Task<TEntity> GetAbTestingWinnerSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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
            */
            return default;
        }

        public async Task<TEntity> GetChatbotLanguageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py) ---
            // def _get_chatbot_language(self):
            // return get_lang(
            //     self.env, lang_code=request and request.httprequest.cookies.get("frontend_lang")
            // ).code
            */
            return default;
        }

        public async Task<TEntity> GetDefaultAbTestingCampaignValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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
            */
            return default;
        }

        public async Task<TEntity> GetDefaultMailServerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> GetDefaultMailingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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
            */
            return default;
        }

        public async Task<TEntity> GetImageByUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object url, object session) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> GetLinkTrackerValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> GetMassMailingContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> GetOptOutListInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> GetPrettyMailingTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _get_pretty_mailing_type(self):
            // return _('Emails')
            */
            return default;
        }

        public async Task<TEntity> GetRecipientsDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _get_recipients_domain(self):
            // """Overridable getter used to get the domain of the recipients at the time of sending."""
            // return self._parse_mailing_domain()
            */
            return default;
        }

        public async Task<TEntity> GetRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> GetRemainingRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> GetSeenListExtraInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _get_seen_list_extra(self):
            // return ('', '')
            */
            return default;
        }

        public async Task<TEntity> GetSeenListInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> GetUnsubscribeOneclickUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_to, Guid res_id) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> GetUnsubscribeUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_to, Guid res_id) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> GetViewUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_to, Guid res_id) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> GetWelcomeStepsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py) ---
            // def _get_welcome_steps(self):
            // """ Returns a sub-set of script_step_ids that only contains the "welcoming steps".
            // We consider those as all the steps the bot will say before expecting a first answer from
            // the end user.
            // 
            // Example 1:
            // - step 1 (question_selection): What do you want to do? - Create a Lead, -Create a Ticket
            // - step 2 (text): Thank you for visiting our website!
            // -> The welcoming steps will only contain step 1, since directly after that we expect an
            // input from the user
            // 
            // Example 2:
            // - step 1 (text): Hello! I'm a bot!
            // - step 2 (text): I am here to help lost users.
            // - step 3 (question_selection): What do you want to do? - Create a Lead, -Create a Ticket
            // - step 4 (text): Thank you for visiting our website!
            // -> The welcoming steps will contain steps 1, 2 and 3.
            // Meaning the bot will have a small monologue with himself before expecting an input from the
            // end user.
            // 
            // This is important because we need to display those welcoming steps in a special fashion on
            // the frontend, since those are not inserted into the discuss.channel as actual mail.messages,
            // to avoid bloating the channels with bot messages if the end-user never interacts with it. """
            // self.ensure_one()
            // 
            // welcome_steps = self.env['chatbot.script.step']
            // for step in self.script_step_ids:
            //     welcome_steps += step
            //     if step.step_type != 'text':
            //         break
            // 
            // return welcome_steps
            */
            return default;
        }

        public async Task<TEntity> OnchangeScriptStepIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py) ---
            // def _onchange_script_step_ids(self):
            // for step in self.script_step_ids:
            //     if step.step_type != "question_selection" and step.answer_ids:
            //         step.answer_ids = [Command.clear()]
            */
            return default;
        }

        public async Task<TEntity> ParseMailingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> PostWelcomeStepsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object discuss_channel) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py) ---
            // def _post_welcome_steps(self, discuss_channel):
            // """ Welcome messages are only posted after the visitor's first interaction with the chatbot.
            // See 'chatbot.script#_get_welcome_steps()' for more details.
            // 
            // Side note: it is important to set the 'chatbot_current_step_id' on each iteration so that
            // it's correctly set when going into 'discuss_channel#_message_post_after_hook()'. """
            // 
            // self.ensure_one()
            // posted_messages = self.env['mail.message']
            // 
            // for welcome_step in self._get_welcome_steps():
            //     discuss_channel.chatbot_current_step_id = welcome_step.id
            // 
            //     if not is_html_empty(welcome_step.message):
            //         posted_messages += discuss_channel.with_context(mail_create_nosubscribe=True).message_post(
            //             author_id=self.operator_partner_id.id,
            //             body=plaintext2html(welcome_step.message),
            //             message_type='comment',
            //             subtype_xmlid='mail.mt_comment',
            //         )
            // 
            // return posted_messages
            */
            return default;
        }

        public async Task<TEntity> PrepareStatisticsEmailValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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
            */
            return default;
        }

        public async Task<TEntity> ProcessMassMailingQueueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
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

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_recruitment_source.py) ---
            // def unlink(self):
            // """ Cascade delete aliases to avoid useless / badly configured aliases. """
            // aliases = self.alias_id
            // res = super().unlink()
            // aliases.sudo().unlink()
            // return res
            */
            return default;
        }

        public async Task<TEntity> ValidateEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_address, object discuss_channel) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py) ---
            // def _validate_email(self, email_address, discuss_channel):
            // email_address = html2plaintext(email_address)
            // email_normalized = email_normalize(email_address)
            // 
            // posted_message = False
            // error_message = False
            // if not email_normalized:
            //     error_message = self.env._(
            //         "'%(input_email)s' does not look like a valid email. Can you please try again?",
            //         input_email=email_address
            //     )
            //     posted_message = discuss_channel._chatbot_post_message(self, plaintext2html(error_message))
            // 
            // return {
            //     'success': bool(email_normalized),
            //     'posted_message': posted_message,
            //     'error_message': error_message,
            // }
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // 
            // if 'title' in vals:
            //     self.operator_partner_id.write({'name': vals['title']})
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def write(self, values):
            // if values.get('body_arch'):
            //     values['body_arch'] = self._convert_inline_images_to_urls(values['body_arch'])
            // if values.get('body_html'):
            //     values['body_html'] = self._convert_inline_images_to_urls(values['body_html'])
            // # If ab_testing is already enabled on a mailing and the campaign is removed, we raise a ValidationError
            // if values.get('campaign_id') is False and any(mailing.ab_testing_enabled for mailing in self) and 'ab_testing_enabled' not in values:
            //     raise ValidationError(_("A campaign should be set when A/B test is enabled"))
            // 
            // result = super(MassMailing, self).write(values)
            // if values.get('ab_testing_enabled'):
            //     self._create_ab_testing_utm_campaigns()
            // self._fix_attachment_ownership()
            // 
            // if any(self.mapped('ab_testing_schedule_datetime')):
            //     schedule_date = min(m.ab_testing_schedule_datetime for m in self if m.ab_testing_schedule_datetime)
            //     ab_testing_cron = self.env.ref('mass_mailing.ir_cron_mass_mailing_ab_testing').sudo()
            //     ab_testing_cron._trigger(at=schedule_date)
            // 
            // return result
            --- ODOO METHOD SOURCE (MODULE: utm, FILE: utm_source.py) ---
            // def write(self, values):
            // if (values.get(self._rec_name) or values.get('name')) and len(self) > 1:
            //     raise ValueError(
            //         _('You cannot update multiple records with the same name. The name should be unique!')
            //     )
            // 
            // if values.get(self._rec_name) and not values.get('name'):
            //     values['name'] = self.env['utm.source']._generate_name(self, values[self._rec_name])
            // if values.get('name'):
            //     values['name'] = self.env['utm.mixin'].with_context(
            //         utm_check_skip_record_ids=self.source_id.ids
            //     )._get_unique_names("utm.source", [values['name']])[0]
            // 
            // return super().write(values)
            */
            return default;
        }
    }
}