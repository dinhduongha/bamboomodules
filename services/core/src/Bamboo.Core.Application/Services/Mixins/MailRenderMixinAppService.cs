using Volo.Abp.ObjectMapping;
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
    [Module("mail", Category = "Productivity", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public class MailRenderMixinAppService : ApplicationService, IMailRenderMixinAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public MailRenderMixinAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ActionCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_cancel(self):
            // self.write({'state': 'draft', 'schedule_date': False, 'schedule_type': 'now', 'next_departure': False})
            */
            return default;
        }

        public async Task<TEntity> ActionCompareVersionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ActionCreateSidebarActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_template.py) ---
            // def action_create_sidebar_action(self):
            // ActWindow = self.env['ir.actions.act_window']
            // view = self.env.ref('sms.sms_composer_view_form')
            // 
            // for template in self:
            //     button_name = _('Send SMS (%s)', template.name)
            //     action = ActWindow.create({
            //         'name': button_name,
            //         'type': 'ir.actions.act_window',
            //         'res_model': 'sms.composer',
            //         # Add default_composition_mode to guess to determine if need to use mass or comment composer
            //         'context': "{'default_template_id' : %d, 'sms_composition_mode': 'guess', 'default_res_ids': active_ids, 'default_res_id': active_id}" % (template.id),
            //         'view_mode': 'form',
            //         'view_id': view.id,
            //         'target': 'new',
            //         'binding_model_id': template.model_id.id,
            //     })
            //     template.write({'sidebar_action_id': action.id})
            // return True
            */
            return default;
        }

        public async Task<TEntity> ActionDuplicateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ActionFetchFavoritesAsync<TEntity>(IEnumerable<TEntity> entities, object extra_domain) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ActionLaunchAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_launch(self):
            // self.write({'schedule_type': 'now'})
            // return self.action_put_in_queue()
            */
            return default;
        }

        public async Task<TEntity> ActionPreviewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py) ---
            // def action_preview(self):
            // self.ensure_one()
            // card = self.env['card.card'].with_context(active_test=False).search([
            //     ('campaign_id', '=', self.id),
            //     ('res_id', '=', self.preview_record_ref.id),
            // ])
            // if card:
            //     card.image = self.image_preview
            // else:
            //     card = self.env['card.card'].create({
            //         'campaign_id': self.id,
            //         'res_id': self.preview_record_ref.id,
            //         'image': self.image_preview,
            //         'active': False,
            //     })
            // return {'type': 'ir.actions.act_url', 'url': card._get_path('preview'), 'target': 'new'}
            */
            return default;
        }

        public async Task<TEntity> ActionPutInQueueAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ActionReloadAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_reload(self):
            // pass
            */
            return default;
        }

        public async Task<TEntity> ActionRemoveFavoriteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ActionRetryFailedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ActionScheduleAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ActionSelectAsWinnerAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ActionSendMailAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_send_mail(self, res_ids=None):
            // return self._action_send_mail(res_ids)
            */
            return default;
        }

        public async Task<TEntity> ActionSendMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ActionSendStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ActionSendWinnerMailingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ActionSetFavoriteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ActionShareAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py) ---
            // def action_share(self):
            //         self.ensure_one()
            //         return {
            //             'type': 'ir.actions.act_window',
            //             'name': _('Send Cards'),
            //             'res_model': 'mailing.mailing',
            //             'context': {
            //                 'default_subject': self.name,
            //                 'default_card_campaign_id': self.id,
            //                 'default_mailing_model_id': self.env['ir.model']._get_id(self.res_model),
            //                 'default_body_arch': f"""
            // <div class="o_layout oe_unremovable oe_unmovable bg-200 o_empty_theme" data-name="Mailing">
            // <style id="design-element"></style>
            // <div class="container o_mail_wrapper o_mail_regular oe_unremovable">
            // <div class="row">
            // <div class="col o_mail_no_options o_mail_wrapper_td bg-white oe_structure o_editable theme_selection_done">
            // 
            // <div class="s_text_block o_mail_snippet_general pt24 pb24" style="padding-left: 15px; padding-right: 15px;" data-snippet="s_text_block" data-name="Text">
            //     <div class="container s_allow_columns">
            //         <p class="o_default_snippet_text">Hello everyone</p>
            //         <p class="o_default_snippet_text">Here's the link to advertise your participation.
            //         <br> Your help with this promotion would be greatly appreciated!`</p>
            //         <p class="o_default_snippet_text">Many thanks</p>
            //     </div>
            // </div>
            // 
            // <div class="s_call_to_share_card o_mail_snippet_general" style="padding-top: 10px; padding-bottom: 10px;">
            //     <table width="100%" border="0" cellspacing="0" cellpadding="0">
            //         <tbody>
            //             <tr>
            //                 <td align="center">
            //                     <a href="/cards/{self.id}/preview" style="padding-left: 3px !important; padding-right: 3px !important">
            //                         <img src="/web/image/card.campaign/{self.id}/image_preview" alt="Card Preview" class="img-fluid" style="width: 540px;"/>
            //                     </a>
            //                 </td>
            //             </tr>
            //         </tbody>
            //     </table>
            // </div>
            // 
            // </div></div></div></div>
            // """,
            //             },
            //             'views': [[False, 'form']],
            //             'target': 'new',
            //         }
            */
            return default;
        }

        public async Task<TEntity> ActionTestAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ActionUnlinkSidebarActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_template.py) ---
            // def action_unlink_sidebar_action(self):
            // for template in self:
            //     if template.sidebar_action_id:
            //         template.sidebar_action_id.unlink()
            // return True
            */
            return default;
        }

        public async Task<TEntity> ActionViewBouncedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_bounced(self):
            // return self._action_view_documents_filtered('bounce')
            */
            return default;
        }

        public async Task<TEntity> ActionViewCardsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py) ---
            // def action_view_cards(self):
            // self.ensure_one()
            // return self.env["ir.actions.actions"]._for_xml_id("marketing_card.cards_card_action") | {
            //     'context': {},
            //     'domain': [('campaign_id', '=', self.id)],
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionViewCardsClickedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py) ---
            // def action_view_cards_clicked(self):
            // self.ensure_one()
            // return self.env["ir.actions.actions"]._for_xml_id("marketing_card.cards_card_action") | {
            //     'context': {'search_default_filter_visited': True},
            //     'domain': [('campaign_id', '=', self.id)],
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionViewCardsSharedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py) ---
            // def action_view_cards_shared(self):
            // self.ensure_one()
            // return self.env["ir.actions.actions"]._for_xml_id("marketing_card.cards_card_action") | {
            //     'context': {'search_default_filter_shared': True},
            //     'domain': [('campaign_id', '=', self.id)],
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionViewClickedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_clicked(self):
            // return self._action_view_documents_filtered('clicked')
            */
            return default;
        }

        public async Task<TEntity> ActionViewDeliveredAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_delivered(self):
            // return self._action_view_documents_filtered('delivered')
            */
            return default;
        }

        public async Task<TEntity> ActionViewDocumentsFilteredInternalAsync<TEntity>(IEnumerable<TEntity> entities, object view_filter) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ActionViewLinkTrackersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ActionViewMailingContactsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ActionViewMailingsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py) ---
            // def action_view_mailings(self):
            // self.ensure_one()
            // return {
            //     'name': _('%(card_campaign_name)s Mailings', card_campaign_name=self.name),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'mailing.mailing',
            //     'domain': [('card_campaign_id', '=', self.id)],
            //     'view_mode': 'list,form',
            //     'target': 'current',
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionViewOpenedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_opened(self):
            // return self._action_view_documents_filtered('open')
            */
            return default;
        }

        public async Task<TEntity> ActionViewRepliedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_replied(self):
            // return self._action_view_documents_filtered('reply')
            */
            return default;
        }

        public async Task<TEntity> ActionViewTracesCanceledAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_traces_canceled(self):
            // return self._action_view_traces_filtered('canceled')
            */
            return default;
        }

        public async Task<TEntity> ActionViewTracesFailedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_traces_failed(self):
            // return self._action_view_traces_filtered('failed')
            */
            return default;
        }

        public async Task<TEntity> ActionViewTracesFilteredInternalAsync<TEntity>(IEnumerable<TEntity> entities, object view_filter) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ActionViewTracesProcessAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_traces_process(self):
            // return self._action_view_traces_filtered('process')
            */
            return default;
        }

        public async Task<TEntity> ActionViewTracesScheduledAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_traces_scheduled(self):
            // return self._action_view_traces_filtered('scheduled')
            */
            return default;
        }

        public async Task<TEntity> ActionViewTracesSentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def action_view_traces_sent(self):
            // return self._action_view_traces_filtered('sent')
            */
            return default;
        }

        public async Task<TEntity> BuildExpressionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, object sub_field_name, object null_value) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py) ---
            // def _build_expression(self, field_name, sub_field_name, null_value):
            // """Returns a placeholder expression for use in a template field,
            // based on the values provided in the placeholder assistant.
            // 
            // :param field_name: main field name
            // :param sub_field_name: sub field name (M2O)
            // :param null_value: default value if the target value is empty
            // :return: final placeholder expression """
            // expression = ''
            // if field_name:
            //     expression = "{{ object." + field_name
            //     if sub_field_name:
            //         expression += "." + sub_field_name
            //     if null_value:
            //         expression += f" ||| {null_value}"
            //     expression += " }}"
            // return expression
            */
            return default;
        }

        public async Task<TEntity> CancelUnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def cancel_unlink(self):
            // return {
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_id': self.id,
            //     'res_model': self._name,
            //     'target': 'new',
            //     'context': {'dialog_size': 'large'},
            // }
            */
            return default;
        }

        public async Task<TEntity> CheckAbstractModelsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def _check_abstract_models(self, vals_list):
            // model_names = self.sudo().env['ir.model'].browse(filter(None, (
            //     vals.get('model_id') for vals in vals_list
            // ))).mapped('model')
            // for model in model_names:
            //     if self.env[model]._abstract:
            //         raise ValidationError(_('You may not define a template on an abstract model: %s', model))
            */
            return default;
        }

        public async Task<TEntity> CheckAccessRightDynamicTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py) ---
            // def _check_access_right_dynamic_template(self):
            // if not self.env.su and not self.env.user.has_group('mail.group_mail_template_editor') and self._has_unsafe_expression():
            //     group = self.env.ref('mail.group_mail_template_editor')
            //     raise AccessError(
            //         _('Only members of %(group_name)s group are allowed to edit templates containing sensible placeholders',
            //           group_name=group.name)
            //     )
            --- ODOO METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py) ---
            // def _check_access_right_dynamic_template(self):
            // """ `_unrestricted_rendering` being True means we trust the value on model
            // when rendering. This means once created, rendering is done without restriction.
            // But this attribute triggers a check at create / write / translation update that
            // current user is an admin or has full edition rights (group_mail_template_editor).
            // 
            //  However here a Marketing Card Manager must be able to edit the fields other
            //  than the rendering fields. The qweb rendered field `body_html` cannot be
            //  modified by users other than the `base.group_system` users, as
            // - it's a related field to `card.template.body`,
            // - store=False
            // - the model `card.template` can only be altered by `base.group_system`
            // 
            // Hence the security is delegated to the 'card.template' model, hence the
            // check done by `_check_access_right_dynamic_template` can be bypassed.
            // """
            // return
            */
            return default;
        }

        public async Task<TEntity> CheckMailingFilterModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ClassifyPerLangInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object engine) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py) ---
            // def _classify_per_lang(self, res_ids, engine='inline_template'):
            // """ Given some record ids, return for computed each lang a contextualized
            // template and its subset of res_ids.
            // 
            // :param list res_ids: list of ids of records (all belonging to same model
            //   defined by self.render_model)
            // :param string engine: inline_template, qweb, or qweb_view;
            // 
            // :return dict: {lang: (template with lang=lang_code if specific lang computed
            //   or template, res_ids targeted by that language}
            // """
            // self.ensure_one()
            // 
            // if self.env.context.get('template_preview_lang'):
            //     lang_to_res_ids = {self.env.context['template_preview_lang']: res_ids}
            // else:
            //     lang_to_res_ids = {}
            //     for res_id, lang in self._render_lang(res_ids, engine=engine).items():
            //         lang_to_res_ids.setdefault(lang, []).append(res_id)
            // 
            // return dict(
            //     (lang, (self.with_context(lang=lang) if lang else self, lang_res_ids))
            //     for lang, lang_res_ids in lang_to_res_ids.items()
            // )
            */
            return default;
        }

        public async Task<TEntity> ComputeAbTestingDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ComputeAbTestingIsWinnerMailingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_ab_testing_is_winner_mailing(self):
            // for mailing in self:
            //     mailing.ab_testing_is_winner_mailing = mailing.campaign_id.ab_testing_winner_mailing_id == mailing
            */
            return default;
        }

        public async Task<TEntity> ComputeBodyHasTemplateValueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py) ---
            // def _compute_body_has_template_value(self):
            // """ Computes if the current body is the same as the one from template.
            // Both real and sanitized values are considered, to avoid editor issues
            // as much as possible. """
            // for composer_mixin in self:
            //     if not tools.is_html_empty(composer_mixin.body) and composer_mixin.template_id:
            //         template_value = composer_mixin.template_id.body_html
            //         # matching email_outgoing sanitize level
            //         sanitize_vals = {
            //             'output_method': 'xml',
            //             'sanitize_attributes': False,
            //             'sanitize_conditional_comments': False,
            //             'sanitize_form': True,
            //             'sanitize_style': True,
            //             'sanitize_tags': False,
            //             'silent': True,
            //             'strip_classes': False,
            //             'strip_style': False,
            //         }
            //         sanitized_template_value = tools.html_sanitize(template_value, **sanitize_vals)
            //         composer_mixin.body_has_template_value = composer_mixin.body in (template_value,
            //             sanitized_template_value)
            //     else:
            //         composer_mixin.body_has_template_value = False
            */
            return default;
        }

        public async Task<TEntity> ComputeBodyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py) ---
            // def _compute_body(self):
            // """ Computation is coming either from template, either reset. When
            // having a template with a value set, copy it. When removing the
            // template, reset it. """
            // for composer_mixin in self:
            //     if not tools.is_html_empty(composer_mixin.template_id.body_html):
            //         composer_mixin.body = composer_mixin.template_id.body_html
            //     elif not composer_mixin.template_id:
            //         composer_mixin.body = False
            */
            return default;
        }

        public async Task<TEntity> ComputeCalendarDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ComputeCanEditBodyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py) ---
            // def _compute_can_edit_body(self):
            // for record in self:
            //     record.can_edit_body = (
            //         record.is_mail_template_editor
            //         or not record.template_id
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeCanWriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def _compute_can_write(self):
            // writable_templates = self._filtered_access('write')
            // for template in self:
            //     template.can_write = template in writable_templates
            */
            return default;
        }

        public async Task<TEntity> ComputeCardStatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py) ---
            // def _compute_card_stats(self):
            // cards_by_status_count = self.env['card.card']._read_group(
            //     domain=[('campaign_id', 'in', self.ids)],
            //     groupby=['campaign_id', 'share_status'],
            //     aggregates=['__count'],
            //     order='campaign_id ASC',
            // )
            // self.update({
            //     'card_count': 0,
            //     'card_click_count': 0,
            //     'card_share_count': 0,
            // })
            // for campaign, status, card_count in cards_by_status_count:
            //     # shared cards are implicitly visited
            //     if status == 'shared':
            //         campaign.card_share_count += card_count
            //     if status in ('shared', 'visited'):
            //         campaign.card_click_count += card_count
            //     campaign.card_count += card_count
            */
            return default;
        }

        public async Task<TEntity> ComputeClicksRatioInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ComputeEmailFromInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ComputeFavoriteDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ComputeImagePreviewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py) ---
            // def _compute_image_preview(self):
            // for campaign in self:
            //     if campaign.preview_record_ref and campaign.preview_record_ref.exists():
            //         image = campaign._get_image_b64(campaign.preview_record_ref)
            //     else:
            //         image = False
            //     campaign.image_preview = image
            */
            return default;
        }

        public async Task<TEntity> ComputeIsAbTestSentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ComputeIsBodyEmptyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_is_body_empty(self):
            // for mailing in self:
            //     mailing.is_body_empty = tools.is_html_empty(mailing.body_arch)
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMailTemplateEditorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py) ---
            // def _compute_is_mail_template_editor(self):
            // is_mail_template_editor = self.env.is_admin() or self.env.user.has_group('mail.group_mail_template_editor')
            // for record in self:
            //     record.is_mail_template_editor = is_mail_template_editor
            */
            return default;
        }

        public async Task<TEntity> ComputeIsTemplateEditorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def _compute_is_template_editor(self):
            // self.is_template_editor = self.env.user.has_group('mail.group_mail_template_editor')
            */
            return default;
        }

        public async Task<TEntity> ComputeLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py) ---
            // def _compute_lang(self):
            // """ Computation is coming either from template, either reset. When
            // having a template with a value set, copy it. When removing the
            // template, reset it. """
            // for composer_mixin in self:
            //     if composer_mixin.template_id.lang:
            //         composer_mixin.lang = composer_mixin.template_id.lang
            //     elif not composer_mixin.template_id:
            //         composer_mixin.lang = False
            */
            return default;
        }

        public async Task<TEntity> ComputeLinkTrackersCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ComputeMailServerAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_mail_server_available(self):
            // self.mail_server_available = self.env['ir.config_parameter'].sudo().get_param('mass_mailing.outgoing_mail_server')
            */
            return default;
        }

        public async Task<TEntity> ComputeMailingCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py) ---
            // def _compute_mailing_count(self):
            // self.mailing_count = 0
            // mailing_counts = self.env['mailing.mailing']._read_group(
            //     [('card_campaign_id', 'in', self.ids)], ['card_campaign_id'], ['__count']
            // )
            // for campaign, mailing_count in mailing_counts:
            //     campaign.mailing_count = mailing_count
            */
            return default;
        }

        public async Task<TEntity> ComputeMailingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ComputeMailingFilterCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ComputeMailingFilterIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_mailing_filter_id(self):
            // for mailing in self:
            //     mailing.mailing_filter_id = False
            */
            return default;
        }

        public async Task<TEntity> ComputeMailingModelRealInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_mailing_model_real(self):
            // for mailing in self:
            //     mailing.mailing_model_real = 'mailing.contact' if mailing.mailing_model_id.model == 'mailing.list' else mailing.mailing_model_id.model
            */
            return default;
        }

        public async Task<TEntity> ComputeMailingOnMailingListInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ComputeMailingTypeDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_mailing_type_description(self):
            // for mailing in self:
            //     mailing.mailing_type_description = dict(self._fields.get('mailing_type').selection).get(mailing.mailing_type)
            */
            return default;
        }

        public async Task<TEntity> ComputeMediumIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ComputeNextDepartureInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ComputeRenderModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py) ---
            // def _compute_render_model(self):
            // """ Give the target model for rendering. Void by default as models
            // inheriting from ``mail.render.mixin`` should define how to find this
            // model. """
            // self.render_model = False
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def _compute_render_model(self):
            // for template in self:
            //     template.render_model = template.model
            --- ODOO METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py) ---
            // def _compute_render_model(self):
            // """ override for mail.render.mixin """
            // for campaign in self:
            //     campaign.render_model = campaign.res_model
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _compute_render_model(self):
            // for mailing in self:
            //     mailing.render_model = mailing.mailing_model_real
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_template.py) ---
            // def _compute_render_model(self):
            // for template in self:
            //     template.render_model = template.model
            */
            return default;
        }

        public async Task<TEntity> ComputeReplyToInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ComputeReplyToModeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ComputeResModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py) ---
            // def _compute_res_model(self):
            // for campaign in self:
            //     preview_model = campaign.preview_record_ref and campaign.preview_record_ref._name
            //     campaign.res_model = preview_model or campaign.res_model or 'res.partner'
            */
            return default;
        }

        public async Task<TEntity> ComputeScheduleDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ComputeStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ComputeSubjectInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py) ---
            // def _compute_subject(self):
            // """ Computation is coming either from template, either reset. When
            // having a template with a value set, copy it. When removing the
            // template, reset it. """
            // for composer_mixin in self:
            //     if composer_mixin.template_id.subject:
            //         composer_mixin.subject = composer_mixin.template_id.subject
            //     elif not composer_mixin.template_id:
            //         composer_mixin.subject = False
            */
            return default;
        }

        public async Task<TEntity> ComputeTemplateCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def _compute_template_category(self):
            // """ Base templates (or master templates) are active templates having
            // a description and an XML ID. User defined templates (no xml id),
            // templates without description or archived templates are not
            // base templates anymore. """
            // deactivated = self.filtered(lambda template: not template.active)
            // if deactivated:
            //     deactivated.template_category = 'hidden_template'
            // remaining = self - deactivated
            // if remaining:
            //     template_external_ids = remaining.get_external_id()
            //     for template in remaining:
            //         if bool(template_external_ids[template.id]) and template.description:
            //             template.template_category = 'base_template'
            //         elif bool(template_external_ids[template.id]):
            //             template.template_category = 'hidden_template'
            //         else:
            //             template.template_category = 'custom_template'
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ComputeWarningMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ConvertInlineImagesToUrlsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object html_content) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ConvertLinksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, name=self.env._("%s (copy)", template.name)) for template, vals in zip(self, vals_list)]
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
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_template.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, name=self.env._("%s (copy)", template.name)) for template, vals in zip(self, vals_list)]
            */
            return default;
        }

        public async Task<TEntity> CreateAbTestingUtmCampaignsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> CreateActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def create_action(self):
            // ActWindow = self.env['ir.actions.act_window']
            // view = self.env.ref('mail.email_compose_message_wizard_form')
            // for template in self:
            //     context = {
            //         'default_composition_mode': 'mass_mail',
            //         'default_model': template.model,
            //         'default_template_id' : template.id,
            //     }
            //     button_name = _('Send Mail (%s)', template.name)
            //     action = ActWindow.create({
            //         'name': button_name,
            //         'type': 'ir.actions.act_window',
            //         'res_model': 'mail.compose.message',
            //         'context': repr(context),
            //         'view_mode': 'form,list',
            //         'view_id': view.id,
            //         'target': 'new',
            //         'binding_model_id': template.model_id.id,
            //     })
            //     template.write({'ref_ir_act_window': action.id})
            // 
            // return True
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py) ---
            // def create(self, values_list):
            // record = super().create(values_list)
            // if self._unrestricted_rendering:
            //     # If the rendering is unrestricted (e.g. mail.template),
            //     # check the user is part of the mail editor group to create a new template if the template is dynamic
            //     record._check_access_right_dynamic_template()
            // return record
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def create(self, vals_list):
            // self._check_abstract_models(vals_list)
            // return super().create(vals_list)\
            //     ._fix_attachment_ownership()
            --- ODOO METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py) ---
            // def create(self, create_vals):
            // utm_source = self.env.ref('marketing_card.utm_source_marketing_card', raise_if_not_found=False)
            // link_trackers = self.env['link.tracker'].sudo().create([
            //     {
            //         'url': vals.get('target_url') or self.env['card.campaign'].get_base_url(),
            //         'title': vals['name'],  # not having this will trigger a request in the create
            //         'source_id': utm_source.id if utm_source else None,
            //         'label': f"marketing_card_campaign_{vals.get('name', '')}_{fields.Datetime.now()}",
            //     }
            //     for vals in create_vals
            // ])
            // return super().create([{
            //     **vals,
            //     'link_tracker_id': link_tracker_id,
            // } for vals, link_tracker_id in zip(create_vals, link_trackers.ids)])
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
            */
            return default;
        }

        public async Task<TEntity> CreateAttachmentsFromInlineImagesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object b64images) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> DefaultCardTemplateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py) ---
            // def _default_card_template_id(self):
            // return self.env['card.template'].search([], limit=1)
            */
            return default;
        }

        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def default_get(self, fields):
            // res = super(MailTemplate, self).default_get(fields)
            // if res.get('model'):
            //     res['model_id'] = self.env['ir.model']._get(res.pop('model')).id
            // return res
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
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_template.py) ---
            // def default_get(self, fields):
            // res = super().default_get(fields)
            // if 'model_id' in fields and not res.get('model_id') and res.get('model'):
            //     res['model_id'] = self.env['ir.model']._get(res['model']).id
            // return res
            */
            return default;
        }

        public async Task<TEntity> FixAttachmentOwnershipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def _fix_attachment_ownership(self):
            // for record in self:
            //     record.attachment_ids.write({'res_model': record._name, 'res_id': record.id})
            // return self
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _fix_attachment_ownership(self):
            // for record in self:
            //     record.attachment_ids.write({'res_model': record._name, 'res_id': record.id})
            // return self
            */
            return default;
        }

        public async Task<TEntity> GenerateMailingRecipientTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid document_id, object email) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> GenerateMailingReportTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> GenerateTemplateAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object render_fields, object render_results) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def _generate_template_attachments(self, res_ids, render_fields,
            //                                render_results=None):
            // """ Render attachments of template 'self', returning values for records
            // given by 'res_ids'. Note that ``report_template_ids`` returns values for
            // 'attachments', as we have a list of tuple (report_name, base64 value)
            // for those reports. It is considered as being the job of callers to
            // transform those attachments into valid ``ir.attachment`` records.
            // 
            // :param list res_ids: list of record IDs on which template is rendered;
            // :param list render_fields: list of fields to render on template which
            //   are specific to attachments, e.g. attachment_ids or report_template_ids;
            // :param dict render_results: res_ids-based dictionary of render values.
            //   For each res_id, a dict of values based on render_fields is given
            // 
            // :return: updated (or new) render_results;
            // """
            // self.ensure_one()
            // if render_results is None:
            //     render_results = {}
            // 
            // # generating reports is done on a per-record basis, better ensure cache
            // # is filled up to avoid rendering and browsing in a loop
            // if res_ids and 'report_template_ids' in render_fields and self.report_template_ids:
            //     self.env[self.model].browse(res_ids)
            // 
            // for res_id in res_ids:
            //     values = render_results.setdefault(res_id, {})
            // 
            //     # link template attachments directly
            //     if 'attachment_ids' in render_fields:
            //         values['attachment_ids'] = self.attachment_ids.ids
            // 
            //     # generate attachments (reports)
            //     if 'report_template_ids' in render_fields and self.report_template_ids:
            //         for report in self.report_template_ids:
            //             # generate content
            //             if report.report_type in ['qweb-html', 'qweb-pdf']:
            //                 report_content, report_format = self.env['ir.actions.report']._render_qweb_pdf(report, [res_id])
            //             else:
            //                 render_res = self.env['ir.actions.report']._render(report, [res_id])
            //                 if not render_res:
            //                     raise UserError(_('Unsupported report type %s found.', report.report_type))
            //                 report_content, report_format = render_res
            //             report_content = base64.b64encode(report_content)
            //             # generate name
            //             if report.print_report_name:
            //                 report_name = safe_eval(
            //                     report.print_report_name,
            //                     {
            //                         'object': self.env[self.model].browse(res_id),
            //                         'time': time,
            //                     }
            //                 )
            //             else:
            //                 report_name = _('Report')
            //             extension = "." + report_format
            //             if not report_name.endswith(extension):
            //                 report_name += extension
            //             values.setdefault('attachments', []).append((report_name, report_content))
            //     elif 'report_template_ids' in render_fields:
            //         values['attachments'] = []
            // 
            // # hook for attachments-specific computation, used currently only for accounting
            // if hasattr(self.env[self.model], '_process_attachments_for_template_post'):
            //     records_attachments = self.env[self.model].browse(res_ids)._process_attachments_for_template_post(self)
            //     for res_id, additional_attachments in records_attachments.items():
            //         if not additional_attachments:
            //             continue
            //         if additional_attachments.get('attachment_ids'):
            //             render_results[res_id].setdefault('attachment_ids', []).extend(additional_attachments['attachment_ids'])
            //         if additional_attachments.get('attachments'):
            //             render_results[res_id].setdefault('attachments', []).extend(additional_attachments['attachments'])
            // 
            // return render_results
            */
            return default;
        }

        public async Task<TEntity> GenerateTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object render_fields, object find_or_create_partners) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def _generate_template(self, res_ids, render_fields,
            //                    find_or_create_partners=False):
            // """ Render values from template 'self' on records given by 'res_ids'.
            // Those values are generally used to create a mail.mail or a mail.message.
            // Model of records is the one defined on template.
            // 
            // :param list res_ids: list of record IDs on which template is rendered;
            // :param list render_fields: list of fields to render on template;
            // :param boolean find_or_create_partners: transform emails into partners
            //   (see ``_generate_template_recipients``);
            // 
            // :returns: a dict of (res_ids, values) where values contains all rendered
            //   fields asked in ``render_fields``. Asking for attachments adds an
            //   'attachments' key using the format [(report_name, data)] where data
            //   is base64 encoded. Asking for recipients adds a 'partner_ids' key.
            //   Note that 2many fields contain a list of IDs, not commands.
            // """
            // self.ensure_one()
            // render_fields_set = set(render_fields)
            // fields_specific = {
            //     'attachment_ids',  # attachments
            //     'email_cc',  # recipients
            //     'email_to',  # recipients
            //     'partner_to',  # recipients
            //     'report_template_ids',  # attachments
            //     'scheduled_date',  # specific
            //     # not rendered (static)
            //     'auto_delete',
            //     'email_layout_xmlid',
            //     'mail_server_id',
            //     'model',
            //     'res_id',
            // }
            // 
            // render_results = {}
            // for _lang, (template, template_res_ids) in self._classify_per_lang(res_ids).items():
            //     # render fields not rendered by sub methods
            //     fields_torender = {
            //         field for field in render_fields_set
            //         if field not in fields_specific
            //     }
            //     for field in fields_torender:
            //         generated_field_values = template._render_field(
            //             field, template_res_ids
            //         )
            //         for res_id, field_value in generated_field_values.items():
            //             render_results.setdefault(res_id, {})[field] = field_value
            // 
            //     # render recipients
            //     if render_fields_set & {'email_cc', 'email_to', 'partner_to'}:
            //         template._generate_template_recipients(
            //             template_res_ids, render_fields_set,
            //             render_results=render_results,
            //             find_or_create_partners=find_or_create_partners
            //         )
            // 
            //     # render scheduled_date
            //     if 'scheduled_date' in render_fields_set:
            //         template._generate_template_scheduled_date(
            //             template_res_ids,
            //             render_results=render_results
            //     )
            // 
            //     # add values static for all res_ids
            //     template._generate_template_static_values(
            //         template_res_ids,
            //         render_fields_set,
            //         render_results=render_results
            //     )
            // 
            //     # generate attachments if requested
            //     if render_fields_set & {'attachment_ids', 'report_template_ids'}:
            //         template._generate_template_attachments(
            //             template_res_ids,
            //             render_fields_set,
            //             render_results=render_results
            //         )
            // 
            // return render_results
            */
            return default;
        }

        public async Task<TEntity> GenerateTemplateRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object render_fields, object find_or_create_partners, object render_results) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def _generate_template_recipients(self, res_ids, render_fields,
            //                               find_or_create_partners=False,
            //                               render_results=None):
            // """ Render recipients of the template 'self', returning values for records
            // given by 'res_ids'. Default values can be generated instead of the template
            // values if requested by template (see 'use_default_to' field). Email fields
            // ('email_cc', 'email_to') are transformed into partners if requested
            // (finding or creating partners). 'partner_to' field is transformed into
            // 'partner_ids' field.
            // 
            // Note: for performance reason, information from records are transferred to
            // created partners no matter the company. For example, if we have a record of
            // company A and one of B with the same email and no related partner, a partner
            // will be created with company A or B but populated with information from the 2
            // records. So some info might be leaked from one company to the other through
            // the partner.
            // 
            // :param list res_ids: list of record IDs on which template is rendered;
            // :param list render_fields: list of fields to render on template which
            //   are specific to recipients, e.g. email_cc, email_to, partner_to);
            // :param boolean find_or_create_partners: transform emails into partners
            //   (calling ``find_or_create`` on partner model);
            // :param dict render_results: res_ids-based dictionary of render values.
            //   For each res_id, a dict of values based on render_fields is given;
            // 
            // :return: updated (or new) render_results. It holds a 'partner_ids' key
            //   holding partners given by ``_message_get_default_recipients`` and/or
            //   generated based on 'partner_to'. If ``find_or_create_partners`` is
            //   False emails are present, otherwise they are included as partners
            //   contained in ``partner_ids``.
            // """
            // self.ensure_one()
            // if render_results is None:
            //     render_results = {}
            // ModelSudo = self.env[self.model].with_prefetch(res_ids).sudo()
            // 
            // # if using default recipients -> ``_message_get_default_recipients`` gives
            // # values for email_to, email_cc and partner_ids
            // if self.use_default_to and self.model:
            //     default_recipients = ModelSudo.browse(res_ids)._message_get_default_recipients()
            //     for res_id, recipients in default_recipients.items():
            //         render_results.setdefault(res_id, {}).update(recipients)
            // # render fields dynamically which generates recipients
            // else:
            //     for field in set(render_fields) & {'email_cc', 'email_to', 'partner_to'}:
            //         generated_field_values = self._render_field(field, res_ids)
            //         for res_id in res_ids:
            //             render_results.setdefault(res_id, {})[field] = generated_field_values[res_id]
            // 
            // # create partners from emails if asked to
            // if find_or_create_partners:
            //     res_id_to_company = {}
            //     if self.model and 'company_id' in ModelSudo._fields:
            //         for read_record in ModelSudo.browse(res_ids).read(['company_id']):
            //             company_id = read_record['company_id'][0] if read_record['company_id'] else False
            //             res_id_to_company[read_record['id']] = company_id
            // 
            //     all_emails = []
            //     email_to_res_ids = {}
            //     email_to_company = {}
            //     for res_id in res_ids:
            //         record_values = render_results.setdefault(res_id, {})
            //         mails = tools.email_split(record_values.pop('email_to', '')) + \
            //                 tools.email_split(record_values.pop('email_cc', ''))
            //         all_emails += mails
            //         record_company = res_id_to_company.get(res_id)
            //         for mail in mails:
            //             email_to_res_ids.setdefault(mail, []).append(res_id)
            //             if record_company:
            //                 email_to_company[mail] = record_company
            // 
            //     if all_emails:
            //         customers_information = ModelSudo.browse(res_ids)._get_customer_information()
            //         partners = self.env['res.partner']._find_or_create_from_emails(
            //             all_emails,
            //             additional_values={
            //                 email: {
            //                     'company_id': email_to_company.get(email),
            //                     **customers_information.get(email, {}),
            //                 }
            //                 for email in itertools.chain(all_emails, [False])
            //             })
            //         for original_email, partner in zip(all_emails, partners):
            //             if not partner:
            //                 continue
            //             for res_id in email_to_res_ids[original_email]:
            //                 render_results[res_id].setdefault('partner_ids', []).append(partner.id)
            // 
            // # update 'partner_to' rendered value to 'partner_ids'
            // all_partner_to = {
            //     pid
            //     for record_values in render_results.values()
            //     for pid in self._parse_partner_to(record_values.get('partner_to', ''))
            // }
            // existing_pids = set()
            // if all_partner_to:
            //     existing_pids = set(self.env['res.partner'].sudo().browse(list(all_partner_to)).exists().ids)
            // for res_id, record_values in render_results.items():
            //     partner_to = record_values.pop('partner_to', '')
            //     if partner_to:
            //         tpl_partner_ids = set(self._parse_partner_to(partner_to)) & existing_pids
            //         record_values.setdefault('partner_ids', []).extend(tpl_partner_ids)
            // 
            // return render_results
            */
            return default;
        }

        public async Task<TEntity> GenerateTemplateScheduledDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object render_results) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def _generate_template_scheduled_date(self, res_ids, render_results=None):
            // """ Render scheduled date based on template 'self'. Specific parsing is
            // done to ensure value matches ORM expected value: UTC but without
            // timezone set in value.
            // 
            // :param list res_ids: list of record IDs on which template is rendered;
            // :param dict render_results: res_ids-based dictionary of render values.
            //   For each res_id, a dict of values based on render_fields is given;
            // 
            // :return: updated (or new) render_results;
            // """
            // self.ensure_one()
            // if render_results is None:
            //     render_results = {}
            // 
            // scheduled_dates = self._render_field('scheduled_date', res_ids)
            // for res_id in res_ids:
            //     scheduled_date = self._process_scheduled_date(scheduled_dates.get(res_id))
            //     render_results.setdefault(res_id, {})['scheduled_date'] = scheduled_date
            // 
            // return render_results
            */
            return default;
        }

        public async Task<TEntity> GenerateTemplateStaticValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object render_fields, object render_results) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def _generate_template_static_values(self, res_ids, render_fields, render_results=None):
            // """ Return values based on template 'self'. Those are not rendered nor
            // dynamic, just static values used for configuration of emails.
            // 
            // :param list res_ids: list of record IDs on which template is rendered;
            // :param list render_fields: list of fields to render, currently limited
            //   to a subset (i.e. auto_delete, mail_server_id, model, res_id);
            // :param dict render_results: res_ids-based dictionary of render values.
            //   For each res_id, a dict of values based on render_fields is given;
            // 
            // :return: updated (or new) render_results;
            // """
            // self.ensure_one()
            // if render_results is None:
            //     render_results = {}
            // 
            // for res_id in res_ids:
            //     values = render_results.setdefault(res_id, {})
            // 
            //     # technical settings
            //     if 'auto_delete' in render_fields:
            //         values['auto_delete'] = self.auto_delete
            //     if 'email_layout_xmlid' in render_fields:
            //         values['email_layout_xmlid'] = self.email_layout_xmlid
            //     if 'mail_server_id' in render_fields:
            //         values['mail_server_id'] = self.mail_server_id.id
            //     if 'model' in render_fields:
            //         values['model'] = self.model
            //     if 'res_id' in render_fields:
            //         values['res_id'] = res_id or False
            // 
            // return render_results
            */
            return default;
        }

        public async Task<TEntity> GetAbTestingDescriptionModifyingFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _get_ab_testing_description_modifying_fields(self):
            // return ['ab_testing_enabled', 'ab_testing_pc', 'ab_testing_schedule_datetime', 'ab_testing_winner_selection', 'campaign_id']
            */
            return default;
        }

        public async Task<TEntity> GetAbTestingDescriptionValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> GetAbTestingSiblingsMailingsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _get_ab_testing_siblings_mailings(self):
            // return self.campaign_id.mailing_mail_ids.filtered(lambda m: m.ab_testing_enabled)
            */
            return default;
        }

        public async Task<TEntity> GetAbTestingWinnerSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> GetCardElementValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py) ---
            // def _get_card_element_values(self, record):
            // """Helper to get the right value for dynamic fields."""
            // self.ensure_one()
            // result = {
            //     'image1': images[0] if (images := self.content_image1_path and self.content_image1_path in record and record.mapped(self.content_image1_path)) else False,
            //     'image2': images[0] if (images := self.content_image2_path and self.content_image2_path in record and record.mapped(self.content_image2_path)) else False,
            // }
            // campaign_text_element_fields = (
            //     ('header', 'content_header', 'content_header_dyn', 'content_header_path'),
            //     ('sub_header', 'content_sub_header', 'content_sub_header_dyn', 'content_sub_header_path'),
            //     ('section', 'content_section', 'content_section_dyn', 'content_section_path'),
            //     ('sub_section1', 'content_sub_section1', 'content_sub_section1_dyn', 'content_sub_section1_path'),
            //     ('sub_section2', 'content_sub_section2', 'content_sub_section2_dyn', 'content_sub_section2_path'),
            // )
            // for el, text_field, dyn_field, path_field in campaign_text_element_fields:
            //     if not self[dyn_field]:
            //         result[el] = self[text_field]
            //     else:
            //         try:
            //             m = record.mapped(self[path_field])
            //             result[el] = m and m[0] or False
            //         except (AttributeError, KeyError):
            //             # for generic image, or if field incorrect, return name of field
            //             result[el] = self[path_field]
            //         # force dates to their relevant timezone as that's what is usually wanted
            //         if (
            //             isinstance(result[el], (date, datetime))
            //             and (tz := record._mail_get_timezone_with_default(default_tz=None))
            //         ):
            //             result[el] = pytz.utc.localize(result[el]).astimezone(pytz.timezone(tz)).replace(tzinfo=None)
            // return result
            */
            return default;
        }

        public async Task<TEntity> GetDefaultAbTestingCampaignValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> GetDefaultMailServerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> GetDefaultMailingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> GetImageB64InternalAsync<TEntity>(IEnumerable<TEntity> entities, object record) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py) ---
            // def _get_image_b64(self, record):
            // if not self.card_template_id.body:
            //     return ''
            // 
            // image_bytes = self.env['ir.actions.report']._run_wkhtmltoimage(
            //     [self._render_field('body_html', record.ids, add_context={'card_campaign': self})[record.id]],
            //     *TEMPLATE_DIMENSIONS
            // )[0]
            // return image_bytes and base64.b64encode(image_bytes)
            */
            return default;
        }

        public async Task<TEntity> GetImageByUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object url, object session) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> GetLinkTrackerValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> GetMassMailingContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> GetModelSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py) ---
            // def _get_model_selection(self):
            // """Hardcoded list of models, checked against actually-present models."""
            // allowed_models = ['res.partner', 'event.track', 'event.booth', 'event.registration']
            // models = self.env['ir.model'].sudo().search_fetch([('model', 'in', allowed_models)], ['model', 'name'])
            // return [(model.model, model.name) for model in models]
            */
            return default;
        }

        public async Task<TEntity> GetOptOutListInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> GetPrettyMailingTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _get_pretty_mailing_type(self):
            // return _('Emails')
            */
            return default;
        }

        public async Task<TEntity> GetRecipientsDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _get_recipients_domain(self):
            // """Overridable getter used to get the domain of the recipients at the time of sending."""
            // return self._parse_mailing_domain()
            */
            return default;
        }

        public async Task<TEntity> GetRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> GetRemainingRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> GetRenderFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py) ---
            // def _get_render_fields(self):
            // return [
            //     'body_html', 'content_background', 'content_image1_path', 'content_image2_path', 'content_button', 'content_header',
            //     'content_header_dyn', 'content_header_path', 'content_header_color', 'content_sub_header',
            //     'content_sub_header_dyn', 'content_sub_header_path', 'content_section', 'content_section_dyn',
            //     'content_section_path', 'content_sub_section1', 'content_sub_section1_dyn', 'content_sub_header_color',
            //     'content_sub_section1_path', 'content_sub_section2', 'content_sub_section2_dyn', 'content_sub_section2_path',
            //     'card_template_id',
            // ]
            */
            return default;
        }

        public async Task<TEntity> GetSeenListExtraInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py) ---
            // def _get_seen_list_extra(self):
            // return ('', '')
            */
            return default;
        }

        public async Task<TEntity> GetSeenListInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> GetUnsubscribeOneclickUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_to, Guid res_id) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> GetUnsubscribeUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_to, Guid res_id) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> GetUrlFromResIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid res_id, object suffix) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py) ---
            // def _get_url_from_res_id(self, res_id, suffix='preview'):
            // card = self.env['card.card'].search([('campaign_id', '=', self.id), ('res_id', '=', res_id)])
            // return card and card._get_path(suffix) or self.target_url
            */
            return default;
        }

        public async Task<TEntity> GetViewUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_to, Guid res_id) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> HasUnsafeExpressionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py) ---
            // def _has_unsafe_expression(self):
            // for template in self.sudo():
            //     for fname, field in template._fields.items():
            //         engine = getattr(field, 'render_engine', 'inline_template')
            //         if engine in ('qweb', 'qweb_view'):
            //             if self._has_unsafe_expression_template_qweb(template[fname], template.render_model):
            //                 return True
            //         else:
            //             if self._has_unsafe_expression_template_inline_template(template[fname], template.render_model):
            //                 return True
            // return False
            */
            return default;
        }

        public async Task<TEntity> HasUnsafeExpressionTemplateInlineTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_txt, object model) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py) ---
            // def _has_unsafe_expression_template_inline_template(self, template_txt, model):
            // if template_txt:
            //     template_instructions = parse_inline_template(str(template_txt))
            //     expressions = [inst[1] for inst in template_instructions]
            //     if not all(self.env["ir.qweb"]._is_expression_allowed(e, model) for e in expressions if e):
            //         return True
            // return False
            */
            return default;
        }

        public async Task<TEntity> HasUnsafeExpressionTemplateQwebInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_src, object model) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py) ---
            // def _has_unsafe_expression_template_qweb(self, template_src, model):
            // if template_src:
            //     try:
            //         node = html.fragment_fromstring(template_src, create_parent='div')
            //         self.env["ir.qweb"].with_context(raise_on_forbidden_code_for_model=model)._generate_code(node)
            //     except QWebException as e:
            //         if isinstance(e.__cause__, PermissionError):
            //             return True
            //         raise
            // return False
            */
            return default;
        }

        public async Task<TEntity> OpenDeleteConfirmationModalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def open_delete_confirmation_modal(self):
            // return {
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_id': self.id,
            //     'res_model': self._name,
            //     'target': 'new',
            //     'view_id': self.env.ref('mail.mail_template_view_form_confirm_delete').id,
            //     'context': {'dialog_size': 'medium'},
            //     'name': _('Confirmation'),
            // }
            */
            return default;
        }

        public async Task<TEntity> ParseMailingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        protected async Task<object> ParsePartnerToInternalAsync(object partner_to)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def _parse_partner_to(cls, partner_to):
            // try:
            //     partner_to = literal_eval(partner_to or '[]')
            // except (ValueError, SyntaxError):
            //     partner_to = partner_to.split(',')
            // if not isinstance(partner_to, (list, tuple)):
            //     partner_to = [partner_to]
            // return [
            //     int(pid.strip()) if isinstance(pid, str) else int(pid) for pid in partner_to
            //     if (isinstance(pid, str) and pid.strip().isdigit()) or (pid and not isinstance(pid, str))
            // ]
            */
            return default;
        }

        public async Task<TEntity> PrepareStatisticsEmailValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> PrependPreviewInternalAsync<TEntity>(IEnumerable<TEntity> entities, object html, object preview) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py) ---
            // def _prepend_preview(self, html, preview):
            // """ Prepare the email body before sending. Add the text preview at the
            // beginning of the mail. The preview text is displayed bellow the mail
            // subject of most mail client (gmail, outlook...).
            // 
            // :param html: html content for which we want to prepend a preview
            // :param preview: the preview to add before the html content
            // :return: html with preprended preview
            // """
            // if preview:
            //     preview = preview.strip()
            // 
            // preview_markup = convert_inline_template_to_qweb(preview)
            // 
            // if preview:
            //     html_preview = Markup("""
            //         <div style="display:none;font-size:1px;height:0px;width:0px;opacity:0;">
            //             {}
            //         </div>
            //     """).format(preview_markup)
            //     return prepend_html_content(html, html_preview)
            // return html
            */
            return default;
        }

        public async Task<TEntity> ProcessMassMailingQueueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
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

        public async Task<TEntity> ProcessScheduledDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object scheduled_date) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py) ---
            // def _process_scheduled_date(self, scheduled_date):
            // if scheduled_date:
            //     # parse scheduled_date to make it timezone agnostic UTC as expected
            //     # by the ORM
            //     parsed_datetime = self.env['mail.mail']._parse_scheduled_datetime(scheduled_date)
            //     scheduled_date = parsed_datetime.replace(tzinfo=None) if parsed_datetime else False
            // return scheduled_date
            */
            return default;
        }

        public async Task<TEntity> RenderEncapsulateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object layout_xmlid, object html, object add_context, object context_record) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py) ---
            // def _render_encapsulate(self, layout_xmlid, html, add_context=None, context_record=None):
            // template_ctx = {
            //     'body': html,
            //     'record_name': context_record.display_name if context_record else '',
            //     'model_description': self.env['ir.model']._get(context_record._name).display_name if context_record else False,
            //     'company': context_record['company_id'] if (context_record and 'company_id' in context_record) else self.env.company,
            //     'record': context_record,
            // }
            // if add_context:
            //     template_ctx.update(**add_context)
            // 
            // html = self.env['ir.qweb']._render(layout_xmlid, template_ctx, minimal_qcontext=True, raise_if_not_found=False)
            // if not html:
            //     _logger.warning('QWeb template %s not found when rendering encapsulation template.' % (layout_xmlid))
            // html = self.env['mail.render.mixin']._replace_local_links(html)
            // return html
            */
            return default;
        }

        public async Task<TEntity> RenderEvalContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py) ---
            // def _render_eval_context(self):
            // """ Evaluation context used in all rendering engines. Contains
            // 
            //   * ``user``: current user browse record;
            //   * ``ctx```: current context;
            //   * various formatting tools;
            // """
            // render_context = {
            //     'ctx': self._context,
            //     'format_date': lambda date, date_format=False, lang_code=False: format_date(self.env, date, date_format, lang_code),
            //     'format_datetime': lambda dt, tz=False, dt_format=False, lang_code=False: format_datetime(self.env, dt, tz, dt_format, lang_code),
            //     'format_time': lambda time, tz=False, time_format=False, lang_code=False: format_time(self.env, time, tz, time_format, lang_code),
            //     'format_amount': lambda amount, currency, lang_code=False: tools.format_amount(self.env, amount, currency, lang_code),
            //     'format_duration': lambda value: tools.format_duration(value),
            //     'is_html_empty': is_html_empty,
            //     'slug': self.env['ir.http']._slug,
            //     'user': self.env.user,
            // }
            // render_context.update(copy.copy(template_env_globals))
            // return render_context
            */
            return default;
        }

        public async Task<TEntity> RenderFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, List<Guid> res_ids, object engine, object compute_lang, object set_lang, object add_context, object options) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py) ---
            // def _render_field(self, field, *args, **kwargs):
            // """ Render the given field on the given records. This method enters
            // sudo mode to allow qweb rendering (which is otherwise reserved for
            // the 'mail template editor' group') if we consider it safe. Safe
            // means content comes from the template which is a validated master
            // data. As a summary the heuristic is :
            // 
            //   * if no template, do not bypass the check;
            //   * if current user is a template editor, do not bypass the check;
            //   * if record value and template value are the same (or equals the
            //     sanitized value in case of an HTML field), bypass the check;
            //   * for body: if current user cannot edit it, force template value back
            //     then bypass the check;
            // 
            // Also provide support to fetch translations on the remote template.
            // Indeed translations are often done on the master template, not on the
            // specific composer itself. In that case we need to work on template
            // value when it has not been modified in the composer. """
            // if field not in self:
            //     raise ValueError(
            //         _('Rendering of %(field_name)s is not possible as not defined on template.',
            //           field_name=field
            //          )
            //     )
            // 
            // if not self.template_id:
            //     # Do not need to bypass the verification
            //     return super()._render_field(field, *args, **kwargs)
            // 
            // # template-based access check + translation check
            // template_field = {
            //     'body': 'body_html',
            // }.get(field, field)
            // if template_field not in self.template_id:
            //     raise ValueError(
            //         _('Rendering of %(field_name)s is not possible as no counterpart on template.',
            //           field_name=field
            //          )
            //     )
            // 
            // composer_value = self[field]
            // template_value = self.template_id[template_field]
            // translation_asked = kwargs.get('compute_lang') or kwargs.get('set_lang')
            // equality = self.body_has_template_value if field == 'body' else composer_value == template_value
            // 
            // call_sudo = False
            // if (not self.is_mail_template_editor and field == 'body' and
            //     (not self.can_edit_body or self.body_has_template_value)):
            //     call_sudo = True
            //     # take the previous body which we can trust without HTML editor reformatting
            //     self.body = self.template_id.body_html
            // if (not self.is_mail_template_editor and field != 'body' and
            //       composer_value == template_value):
            //     call_sudo = True
            // 
            // if translation_asked and equality:
            //     template = self.template_id.sudo() if call_sudo else self.template_id
            //     return template._render_field(
            //         template_field, *args, **kwargs,
            //     )
            // 
            // record = self.sudo() if call_sudo else self
            // return super(MailComposerMixin, record)._render_field(field, *args, **kwargs)
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py) ---
            // def _render_field(self, field, res_ids, engine='inline_template',
            //               compute_lang=False, set_lang=False,
            //               add_context=None, options=None):
            // """ Given some record ids, render a template located on field on all
            // records. ``field`` should be a field of self (i.e. ``body_html`` on
            // ``mail.template``). res_ids are record IDs linked to ``model`` field
            // on self.
            // 
            // :param field: a field name existing on self;
            // :param list res_ids: list of ids of records (all belonging to same model
            //   defined by ``self.render_model``)
            // :param string engine: inline_template, qweb, or qweb_view;
            // 
            // :param boolean compute_lang: compute language to render on translated
            //   version of the template instead of default (probably english) one.
            //   Language will be computed based on ``self.lang``;
            // :param string set_lang: force language for rendering. It should be a
            //   valid lang code matching an activate res.lang. Checked only if
            //   ``compute_lang`` is False;
            // 
            // :param dict add_context: additional context to give to renderer;
            // :param dict options: options for rendering. Use in this method and also
            //   propagated to rendering sub-methods. Base values come from the field
            //   (coming from ``render_options`` parameter) and are updated by this
            //   optional dictionary. May contain notably
            // 
            //     boolean post_process: perform a post processing on rendered result
            //     (notably html links management). See``_render_template_postprocess``;
            //     boolean preserve_comments: if set, comments are preserved. Default
            //     behavior is to remove them. It is used notably for browser-specific
            //     code implemented like comments;
            // 
            // :return dict: {res_id: string of rendered template based on record}
            // """
            // if field not in self:
            //     raise ValueError(
            //         _('Rendering of %(field_name)s is not possible as not defined on template.',
            //           field_name=field
            //          )
            //     )
            // if options is None:
            //     options = {}
            // 
            // self.ensure_one()
            // if compute_lang:
            //     templates_res_ids = self._classify_per_lang(res_ids)
            // elif set_lang:
            //     templates_res_ids = {set_lang: (self.with_context(lang=set_lang), res_ids)}
            // else:
            //     templates_res_ids = {self._context.get('lang'): (self, res_ids)}
            // 
            // # rendering options (update default defined on field by asked options)
            // engine = getattr(self._fields[field], 'render_engine', engine)
            // field_options = getattr(self._fields[field], 'render_options', {})
            // if options:
            //     field_options.update(**options)
            // 
            // return dict(
            //     (res_id, rendered)
            //     for lang, (template, tpl_res_ids) in templates_res_ids.items()
            //     for res_id, rendered in template._render_template(
            //         template[field],
            //         template.render_model,
            //         tpl_res_ids,
            //         engine=engine,
            //         add_context=add_context,
            //         options=field_options,
            //     ).items()
            // )
            */
            return default;
        }

        public async Task<TEntity> RenderLangInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object engine) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py) ---
            // def _render_lang(self, *args, **kwargs):
            // """ Given some record ids, return the lang for each record based on
            // lang field of template or through specific context-based key.
            // This method enters sudo mode to allow qweb rendering (which
            // is otherwise reserved for the 'mail template editor' group')
            // if we consider it safe. Safe means content comes from the template
            // which is a validated master data. As a summary the heuristic is :
            // 
            //   * if no template, do not bypass the check;
            //   * if record lang and template lang are the same, bypass the check;
            // """
            // 
            // if not self.template_id:
            //     # Do not need to bypass the verification
            //     return super()._render_lang(*args, **kwargs)
            // 
            // composer_value = self.lang
            // template_value = self.template_id.lang
            // 
            // call_sudo = False
            // if (not self.is_mail_template_editor and composer_value == template_value):
            //     call_sudo = True
            // 
            // record = self.sudo() if call_sudo else self
            // return super(MailComposerMixin, record)._render_lang(*args, **kwargs)
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py) ---
            // def _render_lang(self, res_ids, engine='inline_template'):
            // """ Given some record ids, return the lang for each record based on
            // lang field of template or through specific context-based key. Lang is
            // computed by performing a rendering on res_ids, based on self.render_model.
            // 
            // :param list res_ids: list of ids of records. All should belong to the
            //   Odoo model given by model;
            // :param string engine: inline_template or qweb_view;
            // 
            // :return dict: {res_id: lang code (i.e. en_US)}
            // """
            // self.ensure_one()
            // 
            // rendered_langs = self._render_template(self.lang, self.render_model, res_ids, engine=engine)
            // return dict(
            //     (res_id, lang)
            //     for res_id, lang in rendered_langs.items()
            // )
            */
            return default;
        }

        public async Task<TEntity> RenderTemplateInlineTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_txt, object model, List<Guid> res_ids, object add_context, object options) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py) ---
            // def _render_template_inline_template(self, template_txt, model, res_ids,
            //                                  add_context=None, options=None):
            // """ Render a string-based template on records given by a model and a list
            // of IDs, using inline_template.
            // 
            // In addition to the generic evaluation context available, some other
            // variables are added:
            //   * ``object``: record based on which the template is rendered;
            // 
            // :param str template_txt: template text to render
            // :param str model: see ``MailRenderMixin._render_template()``;
            // :param list res_ids: see ``MailRenderMixin._render_template()``;
            // 
            // :param dict add_context: additional context to give to renderer. It
            //   allows to add or update values to base rendering context generated
            //   by ``MailRenderMixin._render_inline_template_eval_context()``;
            // :param dict options: options for rendering (no options available
            //   currently);
            // 
            // :return dict: {res_id: string of rendered template based on record}
            // """
            // results = dict.fromkeys(res_ids, "")
            // if not template_txt or not res_ids:
            //     return results
            // 
            // if not self._has_unsafe_expression_template_inline_template(str(template_txt), model):
            //     # do not call the qweb engine
            //     return self._render_template_inline_template_regex(str(template_txt), model, res_ids)
            // 
            // if (not self._unrestricted_rendering
            //     and not self.env.is_admin()
            //     and not self.env.user.has_group('mail.group_mail_template_editor')):
            //     group = self.env.ref('mail.group_mail_template_editor')
            //     raise AccessError(
            //         _('Only members of %(group_name)s group are allowed to edit templates containing sensible placeholders',
            //           group_name=group.name)
            //     )
            // 
            // # prepare template variables
            // variables = self._render_eval_context()
            // if add_context:
            //     variables.update(**add_context)
            // 
            // for record in self.env[model].browse(res_ids):
            //     variables['object'] = record
            // 
            //     try:
            //         results[record.id] = render_inline_template(
            //             parse_inline_template(str(template_txt)),
            //             variables
            //         )
            //     except Exception as e:
            //         _logger.info("Failed to render inline_template: \n%s", str(template_txt), exc_info=True)
            //         raise UserError(
            //             _("Failed to render inline_template template: %(template_txt)s",
            //               template_txt=template_txt)
            //         ) from e
            // 
            // return results
            */
            return default;
        }

        public async Task<TEntity> RenderTemplateInlineTemplateRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_txt, object model, List<Guid> res_ids) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py) ---
            // def _render_template_inline_template_regex(self, template_txt, model, res_ids):
            // """Render the inline template in static mode, without calling safe eval."""
            // template = parse_inline_template(str(template_txt))
            // records = self.env[model].browse(res_ids)
            // result = {}
            // for record in records:
            //     renderer = []
            //     for string, expression, default in template:
            //         renderer.append(string)
            //         if expression:
            //             if not self.env['ir.qweb']._is_expression_allowed(expression, model):
            //                 raise SyntaxError(f"Invalid expression for the regex mode {expression!r}")
            //             try:
            //                 value = reduce(lambda rec, field: rec[field], expression.split('.')[1:], record) or default
            //             except KeyError:
            //                 value = default
            //             renderer.append(str(value))
            //     result[record.id] = ''.join(renderer)
            // return result
            */
            return default;
        }

        public async Task<TEntity> RenderTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_src, object model, List<Guid> res_ids, object engine, object add_context, object options) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py) ---
            // def _render_template(self, template_src, model, res_ids, engine='inline_template',
            //                  add_context=None, options=None):
            // """ Render the given string on records designed by model / res_ids using
            // the given rendering engine. Possible engine are small_web, qweb, or
            // qweb_view.
            // 
            // :param str template_src: template text to render or xml id of a qweb view;
            // :param str model: model name of records on which we want to perform
            //   rendering (aka 'crm.lead');
            // :param list res_ids: list of ids of records. All should belong to the
            //   Odoo model given by model;
            // :param string engine: inline_template, qweb or qweb_view;
            // 
            // :param dict add_context: additional context to give to renderer. It
            //   allows to add or update values to base rendering context generated
            //   by ``MailRenderMixin._render_<engine>_eval_context()``;
            // :param dict options: options for rendering. Use in this method and also
            //   propagated to rendering sub-methods. May contain notably
            // 
            //     boolean post_process: perform a post processing on rendered result
            //     (notably html links management). See``_render_template_postprocess``;
            //     boolean preserve_comments: if set, comments are preserved. Default
            //     behavior is to remove them. It is used notably for browser-specific
            //     code implemented like comments;
            // 
            // :return dict: {res_id: string of rendered template based on record}
            // """
            // if options is None:
            //     options = {}
            // 
            // if not isinstance(res_ids, (list, tuple)):
            //     raise ValueError(
            //         _('Template rendering should only be called with a list of IDs. Received “%(res_ids)s” instead.',
            //           res_ids=res_ids)
            //     )
            // if engine not in ('inline_template', 'qweb', 'qweb_view'):
            //     raise ValueError(
            //         _('Template rendering supports only inline_template, qweb, or qweb_view (view or raw); received %(engine)s instead.',
            //           engine=engine)
            //     )
            // valid_render_options = {'post_process', 'preserve_comments'}
            // if not set((options or {}).keys()) <= valid_render_options:
            //     raise ValueError(
            //         _('Those values are not supported as options when rendering: %(param_names)s',
            //           param_names=', '.join(set(options.keys()) - valid_render_options)
            //          )
            //     )
            // 
            // if engine == 'qweb_view':
            //     rendered = self._render_template_qweb_view(template_src, model, res_ids,
            //                                                add_context=add_context, options=options)
            // elif engine == 'qweb':
            //     rendered = self._render_template_qweb(template_src, model, res_ids,
            //                                           add_context=add_context, options=options)
            // else:
            //     rendered = self._render_template_inline_template(template_src, model, res_ids,
            //                                                      add_context=add_context, options=options)
            // 
            // if options.get('post_process'):
            //     rendered = self._render_template_postprocess(model, rendered)
            // 
            // return rendered
            */
            return default;
        }

        public async Task<TEntity> RenderTemplatePostprocessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object rendered) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py) ---
            // def _render_template_postprocess(self, model, rendered):
            // """ Tool method for post processing. In this method we ensure local
            // links ('/shop/Basil-1') are replaced by global links ('https://www.
            // mygarden.com/shop/Basil-1').
            // 
            // :param rendered: result of ``_render_template``;
            // 
            // :return dict: updated version of rendered per record ID;
            // """
            // res_ids = list(rendered.keys())
            // for res_id, rendered_html in rendered.items():
            //     base_url = None
            //     if model:
            //         base_url = self.env[model].browse(res_id).with_prefetch(res_ids).get_base_url()
            //     rendered[res_id] = self._replace_local_links(rendered_html, base_url)
            // return rendered
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mail_render_mixin.py) ---
            // def _render_template_postprocess(self, model, rendered):
            // # super will transform relative url to absolute
            // rendered = super()._render_template_postprocess(model, rendered)
            // 
            // # apply shortener after
            // if self.env.context.get('post_convert_links'):
            //     for res_id, html in rendered.items():
            //         rendered[res_id] = self._shorten_links(
            //             html,
            //             self.env.context['post_convert_links'],
            //             blacklist=['/unsubscribe_from_list', '/view', '/cards']
            //         )
            // return rendered
            */
            return default;
        }

        public async Task<TEntity> RenderTemplateQwebInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_src, object model, List<Guid> res_ids, object add_context, object options) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py) ---
            // def _render_template_qweb(self, template_src, model, res_ids,
            //                       add_context=None, options=None):
            // """ Render a raw QWeb template.
            // 
            // In addition to the generic evaluation context available, some other
            // variables are added:
            //   * ``object``: record based on which the template is rendered;
            // 
            // :param str template_src: raw QWeb template to render;
            // :param str model: see ``MailRenderMixin._render_template()``;
            // :param list res_ids: see ``MailRenderMixin._render_template()``;
            // 
            // :param dict add_context: additional context to give to renderer. It
            //   allows to add or update values to base rendering context generated
            //   by ``MailRenderMixin._render_eval_context()``;
            // :param dict options: options for rendering propagated to IrQweb render
            //   (see docstring for available options);
            // 
            // :return dict: {res_id: string of rendered template based on record}
            // """
            // results = dict.fromkeys(res_ids, u"")
            // if not template_src or not res_ids:
            //     return results
            // 
            // if not self._has_unsafe_expression_template_qweb(template_src, model):
            //     # do not call the qweb engine
            //     return self._render_template_qweb_regex(template_src, model, res_ids)
            // 
            // # prepare template variables
            // variables = self._render_eval_context()
            // if add_context:
            //     variables.update(**add_context)
            // 
            // is_restricted = not self._unrestricted_rendering and not self.env.is_admin() and not self.env.user.has_group('mail.group_mail_template_editor')
            // 
            // for record in self.env[model].browse(res_ids):
            //     variables['object'] = record
            //     options = options or {}
            //     if is_restricted:
            //         options['raise_on_forbidden_code_for_model'] = model
            //     try:
            //         render_result = self.env['ir.qweb']._render(
            //             html.fragment_fromstring(template_src, create_parent='div'),
            //             variables,
            //             **options,
            //         )
            //         # remove the rendered tag <div> that was added in order to wrap potentially multiples nodes into one.
            //         render_result = render_result[5:-6]
            //     except Exception as e:
            //         if isinstance(e, QWebException) and isinstance(e.__cause__, PermissionError):
            //             group = self.env.ref('mail.group_mail_template_editor')
            //             raise AccessError(
            //                 _('Only members of %(group_name)s group are allowed to edit templates containing sensible placeholders',
            //                    group_name=group.name)
            //             ) from e
            //         _logger.info("Failed to render template: %s", template_src, exc_info=True)
            //         raise UserError(
            //             _("Failed to render QWeb template: %(template_src)s\n\n%(template_traceback)s)",
            //               template_src=template_src,
            //               template_traceback=traceback.format_exc())
            //             ) from e
            //     results[record.id] = render_result
            // 
            // return results
            */
            return default;
        }

        public async Task<TEntity> RenderTemplateQwebRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_src, object model, List<Guid> res_ids) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py) ---
            // def _render_template_qweb_regex(self, template_src, model, res_ids):
            // """Render the template with regex instead of qweb to avoid `eval` call.
            // 
            // Supporting only QWeb allowed expressions, no custom variable in that mode.
            // """
            // records = self.env[model].browse(res_ids)
            // result = {}
            // for record in records:
            //     def replace(match):
            //         tag = match.group(1)
            //         expr = match.group(3)
            //         default = match.group(9)
            //         if not self.env['ir.qweb']._is_expression_allowed(expr, model):
            //             raise SyntaxError(f"Invalid expression for the regex mode {expr!r}")
            // 
            //         try:
            //             value = reduce(lambda rec, field: rec[field], expr.split('.')[1:], record) or default
            //         except KeyError:
            //             value = default
            // 
            //         value = escape(value or '')
            //         return value if tag.lower() == 't' else f"<{tag}>{value}</{tag}>"
            // 
            //     # normalize the HTML (add a parent div to avoid modification of the template
            //     # it will be removed by html_normalize)
            //     template_src = html_normalize(f'<div>{template_src}</div>')
            // 
            //     result[record.id] = Markup(re.sub(
            //         r'''<(\w+)[\s|\n]+t-out=[\s|\n]*(\'|\")((\w|\.)+)(\2)[\s|\n]*((\/>)|(>[\s|\n]*([^<>]*?))[\s|\n]*<\/\1>)''',
            //         replace,
            //         template_src,
            //         flags=re.DOTALL,
            //     ))
            // 
            // return result
            */
            return default;
        }

        public async Task<TEntity> RenderTemplateQwebViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, object view_ref, object model, List<Guid> res_ids, object add_context, object options) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py) ---
            // def _render_template_qweb_view(self, view_ref, model, res_ids,
            //                            add_context=None, options=None):
            // """ Render a QWeb template based on an ir.ui.view content.
            // 
            // In addition to the generic evaluation context available, some other
            // variables are added:
            //   * ``object``: record based on which the template is rendered;
            // 
            // :param str/int/record view_ref: source QWeb template. It should be an
            //   XmlID allowing to fetch an ``ir.ui.view``, or an ID of a view or
            //   an ``ir.ui.view`` record;
            // :param str model: see ``MailRenderMixin._render_template()``;
            // :param list res_ids: see ``MailRenderMixin._render_template()``;
            // 
            // :param dict add_context: additional context to give to renderer. It
            //   allows to add or update values to base rendering context generated
            //   by ``MailRenderMixin._render_eval_context()``;
            // :param dict options: options for rendering propagated to IrQweb render
            //   (see docstring for available options);
            // 
            // :return dict: {res_id: string of rendered template based on record}
            // """
            // results = {}
            // if not res_ids:
            //     return results
            // 
            // # prepare template variables
            // variables = self._render_eval_context()
            // if add_context:
            //     variables.update(**add_context)
            // 
            // view_ref = view_ref.id if isinstance(view_ref, models.BaseModel) else view_ref
            // for record in self.env[model].browse(res_ids):
            //     variables['object'] = record
            //     try:
            //         render_result = self.env['ir.qweb']._render(
            //             view_ref,
            //             variables,
            //             minimal_qcontext=True,
            //             raise_if_not_found=False,
            //             **(options or {})
            //         )
            //         results[record.id] = render_result
            //     except Exception as e:
            //         _logger.info("Failed to render template: %s", view_ref, exc_info=True)
            //         raise UserError(
            //             _("Failed to render template: %(view_ref)s", view_ref=view_ref)
            //         ) from e
            // 
            // return results
            */
            return default;
        }

        public async Task<TEntity> ReplaceLocalLinksInternalAsync<TEntity>(IEnumerable<TEntity> entities, object html, object base_url) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py) ---
            // def _replace_local_links(self, html, base_url=None):
            // """ Replace local links by absolute links. It is required in various
            // cases, for example when sending emails on chatter or sending mass
            // mailings. It replaces
            // 
            //  * href of links (mailto will not match the regex)
            //  * src of images/v:fill/v:image (base64 hardcoded data will not match the regex)
            //  * styling using url like background-image: url or background="url"
            // 
            // It is done using regex because it is shorter than using an html parser
            // to create a potentially complex soupe and hope to have a result that
            // has not been harmed.
            // """
            // if not html:
            //     return html
            // 
            // assert isinstance(html, str)
            // Wrapper = html.__class__
            // 
            // def _sub_relative2absolute(match):
            //     # compute here to do it only if really necessary + cache will ensure it is done only once
            //     # if not base_url
            //     if not _sub_relative2absolute.base_url:
            //         _sub_relative2absolute.base_url = self.env["ir.config_parameter"].sudo().get_param("web.base.url")
            //     return match.group(1) + urls.url_join(_sub_relative2absolute.base_url, match.group(2))
            // 
            // _sub_relative2absolute.base_url = base_url
            // html = re.sub(r"""(<(?:img|v:fill|v:image)(?=\s)[^>]*\ssrc=")(/[^/][^"]+)""", _sub_relative2absolute, html)
            // html = re.sub(r"""(<a(?=\s)[^>]*\shref=")(/[^/][^"]+)""", _sub_relative2absolute, html)
            // html = re.sub(r"""(<[\w-]+(?=\s)[^>]*\sbackground=")(/[^/][^"]+)""", _sub_relative2absolute, html)
            // html = re.sub(re.compile(
            //     r"""( # Group 1: element up to url in style
            //         <[^>]+\bstyle=" # Element with a style attribute
            //         [^"]+\burl\( # Style attribute contains "url(" style
            //         (?:&\#34;|'|&quot;|&\#39;)?) # url style may start with (escaped) quote: capture it
            //     ( # Group 2: url itself
            //         /(?:[^'")]|(?!&\#34;)|(?!&\#39;))+ # stop at the first closing quote
            // )""", re.VERBOSE), _sub_relative2absolute, html)
            // 
            // return Wrapper(html)
            */
            return default;
        }

        public async Task<TEntity> SearchTemplateCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def _search_template_category(self, operator, value):
            // if operator not in ['in', 'not in', '=', '!=']:
            //     raise NotImplementedError(_('Operation not supported'))
            // 
            // value = [value] if isinstance(value, str) else value
            // operator = 'in' if operator in ("in", "=") else 'not in'
            // 
            // templates_with_xmlid = self.env['ir.model.data'].sudo()._search([
            //     ('model', '=', 'mail.template'),
            //     ('module', '!=', '__export__')
            // ]).subselect('res_id')
            // 
            // domain = []
            // if 'hidden_template' in value:
            //     domain.append(['|', ('active', '=', False), '&', ('description', '=', False), ('id', 'in', templates_with_xmlid)])
            // 
            // if 'base_template' in value:
            //     domain.append(['&', ('description', '!=', False), ('id', 'in', templates_with_xmlid)])
            // 
            // if 'custom_template' in value:
            //     domain.append([('template_category', 'not in', ['base_template', 'hidden_template'])])
            // 
            // if operator == 'not in':
            //     for dom in domain:
            //         dom.insert(0, "!")
            // 
            // if len(domain) > 1:
            //     domain = (expression.OR if operator == 'in' else expression.AND)(domain)
            // else:
            //     domain = domain[0]
            // 
            // return domain
            */
            return default;
        }

        public async Task<TEntity> SendCheckAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def _send_check_access(self, res_ids):
            // records = self.env[self.model].browse(res_ids)
            // records.check_access('read')
            */
            return default;
        }

        public async Task<TEntity> SendMailAsync<TEntity>(IEnumerable<TEntity> entities, Guid res_id, object force_send, object raise_exception, object email_values, object email_layout_xmlid) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def send_mail(self, res_id, force_send=False, raise_exception=False, email_values=None,
            //           email_layout_xmlid=False):
            // """ Generates a new mail.mail. Template is rendered on record given by
            // res_id and model coming from template.
            // 
            // :param int res_id: id of the record to render the template
            // :param bool force_send: send email immediately; otherwise use the mail
            //     queue (recommended);
            // :param dict email_values: update generated mail with those values to further
            //     customize the mail;
            // :param str email_layout_xmlid: optional notification layout to encapsulate the
            //     generated email;
            // :returns: id of the mail.mail that was created """
            // 
            // # Grant access to send_mail only if access to related document
            // self.ensure_one()
            // return self.send_mail_batch(
            //     [res_id],
            //     force_send=force_send,
            //     raise_exception=raise_exception,
            //     email_values=email_values,
            //     email_layout_xmlid=email_layout_xmlid
            // )[0].id
            */
            return default;
        }

        public async Task<TEntity> SendMailBatchAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object force_send, object raise_exception, object email_values, object email_layout_xmlid) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def send_mail_batch(self, res_ids, force_send=False, raise_exception=False, email_values=None,
            //           email_layout_xmlid=False):
            // """ Generates new mail.mails. Batch version of 'send_mail'.'
            // 
            // :param list res_ids: IDs of modelrecords on which template will be rendered
            // 
            // :returns: newly created mail.mail
            // """
            // # Grant access to send_mail only if access to related document
            // self.ensure_one()
            // self._send_check_access(res_ids)
            // sending_email_layout_xmlid = email_layout_xmlid or self.email_layout_xmlid
            // 
            // mails_sudo = self.env['mail.mail'].sudo()
            // batch_size = int(
            //     self.env['ir.config_parameter'].sudo().get_param('mail.batch_size')
            // ) or 50  # be sure to not have 0, as otherwise no iteration is done
            // RecordModel = self.env[self.model].with_prefetch(res_ids)
            // record_ir_model = self.env['ir.model']._get(self.model)
            // 
            // for res_ids_chunk in tools.split_every(batch_size, res_ids):
            //     res_ids_values = self._generate_template(
            //         res_ids_chunk,
            //         ('attachment_ids',
            //          'auto_delete',
            //          'body_html',
            //          'email_cc',
            //          'email_from',
            //          'email_to',
            //          'mail_server_id',
            //          'model',
            //          'partner_to',
            //          'reply_to',
            //          'report_template_ids',
            //          'res_id',
            //          'scheduled_date',
            //          'subject',
            //         )
            //     )
            //     values_list = [res_ids_values[res_id] for res_id in res_ids_chunk]
            // 
            //     # get record in batch to use the prefetch
            //     records = RecordModel.browse(res_ids_chunk)
            //     attachments_list = []
            // 
            //     # lang and company is used for rendering layout
            //     res_ids_langs, res_ids_companies = {}, {}
            //     if sending_email_layout_xmlid:
            //         if self.lang:
            //             res_ids_langs = self._render_lang(res_ids_chunk)
            //         res_ids_companies = records._mail_get_companies(default=self.env.company)
            // 
            //     for record in records:
            //         values = res_ids_values[record.id]
            //         values['recipient_ids'] = [(4, pid) for pid in (values.get('partner_ids') or [])]
            //         values['attachment_ids'] = [(4, aid) for aid in (values.get('attachment_ids') or [])]
            //         values.update(email_values or {})
            // 
            //         # delegate attachments after creation due to ACL check
            //         attachments_list.append(values.pop('attachments', []))
            // 
            //         # add a protection against void email_from
            //         if 'email_from' in values and not values.get('email_from'):
            //             values.pop('email_from')
            // 
            //         # encapsulate body
            //         if not sending_email_layout_xmlid:
            //             values['body'] = values['body_html']
            //             continue
            // 
            //         lang = res_ids_langs.get(record.id) or False
            //         company = res_ids_companies.get(record.id) or self.env.company
            //         model_lang = record_ir_model.with_context(lang=lang) if lang else record_ir_model
            // 
            //         template_ctx = {
            //             # message
            //             'message': self.env['mail.message'].sudo().new(dict(body=values['body_html'], record_name=record.display_name)),
            //             'subtype': self.env['mail.message.subtype'].sudo(),
            //             # record
            //             'model_description': model_lang.display_name,
            //             'record': record,
            //             'record_name': False,
            //             'subtitles': False,
            //             # user / environment
            //             'company': company,
            //             'email_add_signature': False,
            //             'signature': '',
            //             'website_url': '',
            //             # tools
            //             'is_html_empty': is_html_empty,
            //         }
            //         body = model_lang.env['ir.qweb']._render(sending_email_layout_xmlid, template_ctx, minimal_qcontext=True, raise_if_not_found=False)
            //         if not body:
            //             _logger.warning(
            //                 'QWeb template %s not found when sending template %s. Sending without layout.',
            //                 sending_email_layout_xmlid,
            //                 self.name,
            //             )
            //             body = values['body_html']
            // 
            //         values['body_html'] = self.env['mail.render.mixin']._replace_local_links(body)
            //         values['body'] = values['body_html']
            // 
            //     mails = self.env['mail.mail'].sudo().create(values_list)
            // 
            //     # manage attachments
            //     for mail, attachments in zip(mails, attachments_list):
            //         if attachments:
            //             attachments_values = [
            //                 (0, 0, {
            //                     'name': name,
            //                     'datas': datas,
            //                     'type': 'binary',
            //                     'res_model': 'mail.message',
            //                     'res_id': mail.mail_message_id.id,
            //                 })
            //                 for (name, datas) in attachments
            //             ]
            //             mail.with_context(default_type=None).write({'attachment_ids': attachments_values})
            // 
            //     mails_sudo += mails
            // 
            // if force_send:
            //     mails_sudo.send(raise_exception=raise_exception)
            // return mails_sudo
            */
            return default;
        }

        public async Task<TEntity> ShortenLinksInternalAsync<TEntity>(IEnumerable<TEntity> entities, object html, object link_tracker_vals, object blacklist, object base_url) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: link_tracker, FILE: mail_render_mixin.py) ---
            // def _shorten_links(self, html, link_tracker_vals, blacklist=None, base_url=None):
            // """ Shorten links in an html content. It uses the '/r' short URL routing
            // introduced in this module. Using the standard Odoo regex local links are
            // found and replaced by global URLs (not including mailto, tel, sms).
            // 
            // TDE FIXME: could be great to have a record to enable website-based URLs
            // 
            // :param link_tracker_vals: values given to the created link.tracker, containing
            //   for example: campaign_id, medium_id, source_id, and any other relevant fields
            //   like mass_mailing_id in mass_mailing;
            // :param list blacklist: list of (local) URLs to not shorten (e.g.
            //   '/unsubscribe_from_list')
            // :param str base_url: either given, either based on config parameter
            // 
            // :return: updated html
            // """
            // if not html or is_html_empty(html):
            //     return html
            // base_url = base_url or self.env['ir.config_parameter'].sudo().get_param('web.base.url')
            // short_schema = base_url + '/r/'
            // 
            // root_node = lxml.html.fromstring(html)
            // link_nodes, urls_and_labels = find_links_with_urls_and_labels(
            //     root_node, base_url, skip_regex=rf'^{URL_SKIP_PROTOCOL_REGEX}', skip_prefix=short_schema,
            //     skip_list=blacklist)
            // if not link_nodes:
            //     return html
            // 
            // links_trackers = self.env['link.tracker'].search_or_create([
            //     dict(link_tracker_vals, **url_and_label) for url_and_label in urls_and_labels
            // ])
            // for node, link_tracker in zip(link_nodes, links_trackers):
            //     node.set("href", link_tracker.short_url)
            // 
            // new_html = lxml.html.tostring(root_node, encoding="unicode", method="xml")
            // if isinstance(html, markupsafe.Markup):
            //     new_html = markupsafe.Markup(new_html)
            // 
            // return new_html
            */
            return default;
        }

        public async Task<TEntity> ShortenLinksTextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object content, object link_tracker_vals, object blacklist, object base_url) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: link_tracker, FILE: mail_render_mixin.py) ---
            // def _shorten_links_text(self, content, link_tracker_vals, blacklist=None, base_url=None):
            // """ Shorten links in a string content. Works like ``_shorten_links`` but
            // targeting string content, not html.
            // 
            // :return: updated content
            // """
            // if not content:
            //     return content
            // base_url = base_url or self.env['ir.config_parameter'].sudo().get_param('web.base.url')
            // shortened_schema = base_url + '/r/'
            // unsubscribe_schema = base_url + '/sms/'
            // for original_url in set(re.findall(TEXT_URL_REGEX, content)):
            //     # don't shorten already-shortened links or links towards unsubscribe page
            //     if original_url.startswith(shortened_schema) or original_url.startswith(unsubscribe_schema):
            //         continue
            //     # support blacklist items in path, like /u/
            //     parsed = urls.url_parse(original_url, scheme='http')
            //     if blacklist and any(re.search(item + r'([#?/]|$)', parsed.path) for item in blacklist):
            //         continue
            // 
            //     create_vals = dict(link_tracker_vals, url=unescape(original_url))
            //     link = self.env['link.tracker'].search_or_create([create_vals])
            //     if link.short_url:
            //         # Ensures we only replace the same link and not a subpart of a longer one, multiple times if applicable
            //         content = re.sub(re.escape(original_url) + r'(?![\w@:%.+&~#=/-])', link.short_url, content)
            // 
            // return content
            */
            return default;
        }

        public async Task<TEntity> UnlinkActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def unlink_action(self):
            // for template in self:
            //     if template.ref_ir_act_window:
            //         template.ref_ir_act_window.unlink()
            // return True
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def unlink(self):
            // self.unlink_action()
            // return super(MailTemplate, self).unlink()
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_template.py) ---
            // def unlink(self):
            // self.sudo().mapped('sidebar_action_id').unlink()
            // return super(SMSTemplate, self).unlink()
            */
            return default;
        }

        public async Task<TEntity> UpdateCardsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object auto_commit) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py) ---
            // def _update_cards(self, domain, auto_commit=False):
            // """Create missing cards and update cards if necessary based for the domain."""
            // self.ensure_one()
            // TargetModel = self.env[self.res_model]
            // res_ids = TargetModel.search(domain).ids
            // cards = self.env['card.card'].with_context(active_test=False).search_fetch([
            //     ('campaign_id', '=', self.id),
            //     ('res_id', 'in', res_ids),
            // ], ['res_id', 'requires_sync'])
            // # update active and res_model for preview cards
            // cards.active = True
            // self.env['card.card'].create([
            //     {'campaign_id': self.id, 'res_id': res_id}
            //     for res_id in set(res_ids) - set(cards.mapped('res_id'))
            // ])
            // 
            // # render by batch of 100 to avoid losing progress in case of time out
            // updated_cards = self.env['card.card']
            // while cards := self.env['card.card'].search_fetch([
            //     ('requires_sync', '=', True),
            //     ('campaign_id', '=', self.id),
            //     ('res_id', 'in', res_ids),
            // ], ['res_id'], limit=100):
            //     # no need to autocommit if it can be done in one batch
            //     if auto_commit and updated_cards:
            //         self.env.cr.commit()
            //         # avoid keeping hundreds of jpegs in memory
            //         self.env['card.card'].invalidate_model(['image'])
            //     TargetModelPrefetch = TargetModel.with_prefetch(cards.mapped('res_id'))
            //     for card in cards.filtered('requires_sync'):
            //         card.write({
            //             'image': self._get_image_b64(TargetModelPrefetch.browse(card.res_id)),
            //             'requires_sync': False,
            //             'active': True,
            //         })
            //     cards.flush_recordset()
            //     updated_cards += cards
            // return updated_cards
            */
            return default;
        }

        public async Task<TEntity> UpdateFieldTranslationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname, object translations, object digest, object source_lang) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py) ---
            // def _update_field_translations(self, fname, translations, digest=None, source_lang=None):
            // res = super()._update_field_translations(fname, translations, digest=digest, source_lang=source_lang)
            // if self._unrestricted_rendering:
            //     for lang in translations:
            //         # If the rendering is unrestricted (e.g. mail.template),
            //         # check the user is part of the mail editor group to modify a template if the template is dynamic
            //         self.with_context(lang=lang)._check_access_right_dynamic_template()
            // return res
            */
            return default;
        }

        public async Task<TEntity> ValidFieldParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, object name) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py) ---
            // def _valid_field_parameter(self, field, name):
            // # allow specifying rendering options directly from field when using the render mixin
            // return name in ['render_engine', 'render_options'] or super()._valid_field_parameter(field, name)
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py) ---
            // def write(self, vals):
            // super().write(vals)
            // if self._unrestricted_rendering:
            //     # If the rendering is unrestricted (e.g. mail.template),
            //     # check the user is part of the mail editor group to modify a template if the template is dynamic
            //     self._check_access_right_dynamic_template()
            // return True
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_template.py) ---
            // def write(self, vals):
            // self._check_abstract_models([vals])
            // super().write(vals)
            // self._fix_attachment_ownership()
            // return True
            --- ODOO METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py) ---
            // def write(self, vals):
            // link_tracker_vals = {}
            // if vals.keys() & set(self._get_render_fields()):
            //     self.env['card.card'].search([('campaign_id', 'in', self.ids)]).requires_sync = True
            // if 'target_url' in vals:
            //     link_tracker_vals['url'] = vals['target_url'] or self.env['card.campaign'].get_base_url()
            // if link_tracker_vals:
            //     self.link_tracker_id.sudo().write(link_tracker_vals)
            // 
            // # write and detect model changes on actively-used campaigns
            // original_models = self.mapped('res_model')
            // 
            // write_res = super().write(vals)
            // 
            // updated_model_campaigns = self.env['card.campaign'].browse([
            //     campaign.id for campaign, new_model, old_model
            //     in zip(self, self.mapped('res_model'), original_models)
            //     if new_model != old_model
            // ])
            // for campaign in updated_model_campaigns:
            //     if campaign.card_count:
            //         raise exceptions.ValidationError(_(
            //             "Model of campaign %(campaign)s may not be changed as it already has cards",
            //             campaign=campaign.display_name,
            //         ))
            // return write_res
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
            */
            return default;
        }
    }
}