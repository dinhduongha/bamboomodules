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
    [Module("base", Category = "Base")]
    public class ImageMixinAppService : ApplicationService, IImageMixinAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public ImageMixinAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ActionAddMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_partners, object member_status, object raise_on_access) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _action_add_members(self, target_partners, member_status='joined', raise_on_access=False):
            // """ Adds the target_partners as attendees of the channel(s).
            //     Partners are added as follows, depending on the value of member_status:
            //     1) (Default) 'joined'. The partners will be added as enrolled attendees. This will make the content
            //         (slides) of the channel available to that partner. This can also happen when an invited attendee
            //         enrolls themself. The attendees are also subscribed to the chatter of the channel.
            //         :return: the union of previous partners re-enrolling, new attendees and invited ones enrolling.
            //     2) 'invited' : This is used when inviting partners. The partners are added as invited attendees
            //         This will make the channel accessible but not the slides until they enroll themselves.
            //         :return: returns the union of new records and the ones unarchived.
            // """
            // SlideChannelPartnerSudo = self.env['slide.channel.partner'].sudo()
            // allowed_channels = self._filter_add_members(target_partners, raise_on_access=raise_on_access)
            // if not allowed_channels or not target_partners:
            //     return SlideChannelPartnerSudo
            // 
            // existing_channel_partners = self.env['slide.channel.partner'].with_context(active_test=False).sudo().search([
            //     ('channel_id', 'in', allowed_channels.ids),
            //     ('partner_id', 'in', target_partners.ids)
            // ])
            // 
            // # Unarchive existing channel partners, recomputing their completion and updating member_status
            // archived_channel_partners = existing_channel_partners.filtered(lambda channel_partner: not channel_partner.active)
            // to_unarchived = SlideChannelPartnerSudo
            // if archived_channel_partners:
            //     archived_channel_partners.action_unarchive()
            //     to_unarchived = archived_channel_partners
            //     # Update member_status (and completion if enrolling)
            //     to_unarchived.member_status = member_status
            //     if member_status == 'joined':
            //         to_unarchived._recompute_completion()
            // 
            // existing_channel_partners_map = defaultdict(lambda: self.env['slide.channel.partner'])
            // for channel_partner in existing_channel_partners:
            //     existing_channel_partners_map[channel_partner.channel_id] += channel_partner
            // 
            // # Invited partners confirming their invitation by enrolling, or upgraded to 'joined'.
            // to_update_as_joined = SlideChannelPartnerSudo
            // to_create_channel_partners_values = []
            // 
            // for channel in allowed_channels:
            //     channel_partners = existing_channel_partners_map[channel]
            //     if member_status == 'joined':
            //         to_update_as_joined += channel_partners.filtered(lambda cp: cp.member_status == 'invited')
            //     for partner in target_partners - channel_partners.partner_id:
            //         to_create_channel_partners_values.append(dict(channel_id=channel.id, partner_id=partner.id, member_status=member_status))
            // 
            // new_slide_channel_partners = SlideChannelPartnerSudo.create(to_create_channel_partners_values)
            // to_update_as_joined.member_status = 'joined'
            // to_update_as_joined._recompute_completion()
            // 
            // # All fragments are in sudo.
            // result_channel_partners = to_unarchived + to_update_as_joined + new_slide_channel_partners
            // 
            // # Subscribe partners joining the course to the chatter.
            // if member_status == 'joined':
            //     result_channel_partners_map = defaultdict(list)
            //     for channel_partner in result_channel_partners:
            //         result_channel_partners_map[channel_partner.channel_id].append(channel_partner.partner_id.id)
            //     for channel, partner_ids in result_channel_partners_map.items():
            //         channel.message_subscribe(
            //             partner_ids=partner_ids,
            //             subtype_ids=[self.env.ref('website_slides.mt_channel_slide_published').id]
            //         )
            // return result_channel_partners
            */
            return default;
        }

        public async Task<TEntity> ActionChannelEnrollAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_channel_enroll(self):
            // template = self.env.ref('website_slides.mail_template_slide_channel_enroll', raise_if_not_found=False)
            // return self._action_channel_open_invite_wizard(template, enroll_mode=True)
            */
            return default;
        }

        public async Task<TEntity> ActionChannelInviteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_channel_invite(self):
            // template = self.env.ref('website_slides.mail_template_slide_channel_invite', raise_if_not_found=False)
            // return self._action_channel_open_invite_wizard(template)
            */
            return default;
        }

        public async Task<TEntity> ActionChannelOpenInviteWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mail_template, object enroll_mode) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _action_channel_open_invite_wizard(self, mail_template, enroll_mode=False):
            // """ Open the invitation wizard to invite and add attendees to the course(s) in self.
            // 
            // :param mail_template: mail.template used in the invite wizard.
            // :param enroll_mode: true if we want to enroll the attendees invited through the wizard.
            //     False otherwise, adding them as 'invited', e.g. when using "Invite" action."""
            // course_name = self.name if len(self) == 1 else ''
            // local_context = dict(
            //     self.env.context,
            //     default_channel_id=self.id if len(self) == 1 else False,
            //     default_email_layout_xmlid='website_slides.mail_notification_channel_invite',
            //     default_enroll_mode=enroll_mode,
            //     default_template_id=mail_template and mail_template.id or False,
            //     default_use_template=bool(mail_template),
            // )
            // if enroll_mode:
            //     name = _('Enroll Attendees to %(course_name)s', course_name=course_name or _('a course'))
            // else:
            //     name = _('Invite Attendees to %(course_name)s', course_name=course_name or _('a course'))
            // 
            // return {
            //     'type': 'ir.actions.act_window',
            //     'views': [[False, 'form']],
            //     'res_model': 'slide.channel.invite',
            //     'target': 'new',
            //     'context': local_context,
            //     'name': name,
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionDislikeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def action_dislike(self):
            // self.check_access('read')
            // return self._action_vote(upvote=False)
            */
            return default;
        }

        public async Task<TEntity> ActionGrantAccessAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_grant_access(self, partner_id):
            // partner = self.env['res.partner'].browse(partner_id).exists()
            // if partner:
            //     if self._action_add_members(partner):
            //         self.activity_search(
            //             ['website_slides.mail_activity_data_access_request'],
            //             user_id=self.user_id.id, additional_domain=[('request_partner_id', '=', partner.id)]
            //         ).action_feedback(feedback=_('Access Granted'))
            */
            return default;
        }

        public async Task<TEntity> ActionLikeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def action_like(self):
            // self.check_access('read')
            // return self._action_vote(upvote=True)
            */
            return default;
        }

        public async Task<TEntity> ActionMarkCompletedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def action_mark_completed(self):
            // if any(not slide.can_self_mark_completed for slide in self):
            //     raise UserError(_('You cannot mark a slide as completed if you are not among its members.'))
            // 
            // return self._action_mark_completed()
            */
            return default;
        }

        public async Task<TEntity> ActionMarkCompletedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _action_mark_completed(self):
            // uncompleted_slides = self.filtered(lambda slide: not slide.user_has_completed)
            // 
            // target_partner = self.env.user.partner_id
            // uncompleted_slides._action_set_quiz_done()
            // SlidePartnerSudo = self.env['slide.slide.partner'].sudo()
            // existing_sudo = SlidePartnerSudo.search([
            //     ('slide_id', 'in', uncompleted_slides.ids),
            //     ('partner_id', '=', target_partner.id)
            // ])
            // existing_sudo.write({'completed': True})
            // 
            // new_slides = uncompleted_slides.sudo() - existing_sudo.mapped('slide_id')
            // SlidePartnerSudo.create([{
            //     'slide_id': new_slide.id,
            //     'channel_id': new_slide.channel_id.id,
            //     'partner_id': target_partner.id,
            //     'vote': 0,
            //     'completed': True} for new_slide in new_slides])
            */
            return default;
        }

        public async Task<TEntity> ActionMarkUncompletedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def action_mark_uncompleted(self):
            // if any(not slide.can_self_mark_uncompleted for slide in self):
            //     raise UserError(_('You cannot mark a slide as uncompleted if you are not among its members.'))
            // 
            // completed_slides = self.filtered(lambda slide: slide.user_has_completed)
            // 
            // # Remove the Karma point gained
            // completed_slides._action_set_quiz_done(completed=False)
            // 
            // self.env['slide.slide.partner'].sudo().search([
            //     ('slide_id', 'in', completed_slides.ids),
            //     ('partner_id', '=', self.env.user.partner_id.id),
            // ]).completed = False
            */
            return default;
        }

        public async Task<TEntity> ActionOpenDocumentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def action_open_documents(self):
            // self.ensure_one()
            // return {
            //     'name': _('Documents'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'product.document',
            //     'view_mode': 'kanban,list,form',
            //     'context': {
            //         'default_res_model': self._name,
            //         'default_res_id': self.id,
            //         'default_company_id': self.company_id.id,
            //     },
            //     'domain': self._get_product_document_domain(),
            //     'target': 'current',
            //     'help': """
            //         <p class="o_view_nocontent_smiling_face">
            //             %s
            //         </p>
            //         <p>
            //             %s
            //             <br/>
            //             %s
            //         </p>
            //         <p>
            //             <a class="oe_link" href="https://www.odoo.com/documentation/18.0/_downloads/c2c6ce32294dfddffcfefcf2775f7a09/pdfquotebuilderexamples.zip">
            //             %s
            //             </a>
            //         </p>
            //     """ % (
            //         _("Upload files to your product"),
            //         _("Use this feature to store any files you would like to share with your customers"),
            //         _("(e.g: product description, ebook, legal notice, ...)."),
            //         _("Download examples")
            //     )
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionOpenLabelLayoutAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def action_open_label_layout(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('product.action_open_label_layout')
            // action['context'] = {'default_product_tmpl_ids': self.ids}
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToCompletedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_redirect_to_completed_members(self):
            // return self.action_redirect_to_members('completed')
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToEngagedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_redirect_to_engaged_members(self):
            // return self.action_redirect_to_members('engaged')
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToInvitedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_redirect_to_invited_members(self):
            // return self.action_redirect_to_members('invited')
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToMembersAsync<TEntity>(IEnumerable<TEntity> entities, object status_filter) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_redirect_to_members(self, status_filter=''):
            // """ Redirects to attendees of the course. If status_filter is set to 'invited' /
            // 'engaged' ('joined' + 'ongoing') / 'completed', attendees are filtered accordingly."""
            // action_ctx = {}
            // action = self.env["ir.actions.actions"]._for_xml_id("website_slides.slide_channel_partner_action")
            // if status_filter == 'engaged':
            //     action_ctx['search_default_filter_joined'] = 1
            //     action_ctx['search_default_filter_ongoing'] = 1
            // elif status_filter:
            //     action_ctx[f'search_default_filter_{status_filter}'] = 1
            // action['domain'] = [('channel_id', 'in', self.ids)]
            // action['sample'] = 1
            // if status_filter == 'completed':
            //     help_message = {
            //         'header_message': _("No Attendee has completed this course yet!"),
            //         'body_message': ""
            //     }
            // else:
            //     help_message = {
            //         'header_message': _("No Attendees Yet!"),
            //         'body_message': _("From here you'll be able to monitor attendees and to track their progress.")
            //     }
            // action['help'] = Markup("""<p class="o_view_nocontent_smiling_face">%(header_message)s</p><p>%(body_message)s</p>""") % help_message
            // if len(self) == 1:
            //     action['display_name'] = _('Attendees of %s', self.name)
            //     action_ctx['default_channel_id'] = self.id
            // action['context'] = action_ctx
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionRefuseAccessAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_refuse_access(self, partner_id):
            // partner = self.env['res.partner'].browse(partner_id).exists()
            // if partner:
            //     self.activity_search(
            //         ['website_slides.mail_activity_data_access_request'],
            //         user_id=self.user_id.id, additional_domain=[('request_partner_id', '=', partner.id)]
            //     ).action_feedback(feedback=_('Access Refused'))
            */
            return default;
        }

        public async Task<TEntity> ActionRequestAccessAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_request_access(self):
            // """ Request access to the channel. Returns a dict with keys being either 'error'
            // (specific error raised) or 'done' (request done or not). """
            // if self.env.user._is_public():
            //     return {'error': _('You have to sign in before')}
            // if not self.is_published:
            //     return {'error': _('Course not published yet')}
            // if self.is_member:
            //     return {'error': _('Already member')}
            // if self.enroll == 'invite':
            //     activities = self.sudo()._action_request_access(self.env.user.partner_id)
            //     if activities:
            //         return {'done': True}
            //     return {'error': _('Already Requested')}
            // return {'done': False}
            */
            return default;
        }

        public async Task<TEntity> ActionRequestAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _action_request_access(self, partner):
            // activities = self.env['mail.activity']
            // requested_cids = self.sudo().activity_search(
            //     ['website_slides.mail_activity_data_access_request'],
            //     additional_domain=[('request_partner_id', '=', partner.id)]
            // ).mapped('res_id')
            // for channel in self:
            //     if channel.id not in requested_cids and channel.user_id:
            //         activities += channel.activity_schedule(
            //             'website_slides.mail_activity_data_access_request',
            //             note=_('<b>%s</b> is requesting access to this course.', partner.name),
            //             user_id=channel.user_id.id,
            //             request_partner_id=partner.id
            //         )
            // return activities
            */
            return default;
        }

        public async Task<TEntity> ActionSetQuizDoneInternalAsync<TEntity>(IEnumerable<TEntity> entities, object completed) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _action_set_quiz_done(self, completed=True):
            // """Add or remove karma point related to the quiz.
            // 
            // :param completed:
            //     True if the quiz will be marked as completed (karma will be increased)
            //     If set to False, we will remove the karma instead of increasing it,
            //     so that the user can take the quiz multiple times but not gain karma infinitely
            // """
            // if any(not slide.channel_id.is_member or not slide.website_published for slide in self):
            //     raise UserError(
            //         _('You cannot mark a slide quiz as completed if you are not among its members or it is unpublished.') if completed
            //         else _('You cannot mark a slide quiz as not completed if you are not among its members or it is unpublished.')
            //     )
            // 
            // points = 0
            // for slide in self:
            //     user_membership_sudo = slide.user_membership_id.sudo()
            //     if not user_membership_sudo \
            //        or user_membership_sudo.completed == completed \
            //        or not user_membership_sudo.quiz_attempts_count \
            //        or not slide.question_ids:
            //         continue
            // 
            //     gains = [slide.quiz_first_attempt_reward,
            //              slide.quiz_second_attempt_reward,
            //              slide.quiz_third_attempt_reward,
            //              slide.quiz_fourth_attempt_reward]
            //     points = gains[min(user_membership_sudo.quiz_attempts_count, len(gains)) - 1]
            //     if points:
            //         if completed:
            //             reason = _('Quiz Completed')
            //         else:
            //             points *= -1
            //             reason = _('Quiz Set Uncompleted')
            //         self.env.user.sudo()._add_karma(points, slide, reason)
            // 
            // return True
            */
            return default;
        }

        public async Task<TEntity> ActionSetViewedAsync<TEntity>(IEnumerable<TEntity> entities, object quiz_attempts_inc) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def action_set_viewed(self, quiz_attempts_inc=False):
            // if any(not slide.channel_id.is_member for slide in self):
            //     raise UserError(_('You cannot mark a slide as viewed if you are not among its members.'))
            // 
            // return bool(self._action_set_viewed(self.env.user.partner_id, quiz_attempts_inc=quiz_attempts_inc))
            */
            return default;
        }

        public async Task<TEntity> ActionSetViewedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_partner, object quiz_attempts_inc) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _action_set_viewed(self, target_partner, quiz_attempts_inc=False):
            // self_sudo = self.sudo()
            // SlidePartnerSudo = self.env['slide.slide.partner'].sudo()
            // existing_sudo = SlidePartnerSudo.search([
            //     ('slide_id', 'in', self.ids),
            //     ('partner_id', '=', target_partner.id)
            // ])
            // if quiz_attempts_inc and existing_sudo:
            //     sql.increment_fields_skiplock(existing_sudo, 'quiz_attempts_count')
            //     existing_sudo.invalidate_recordset(['quiz_attempts_count'])
            // 
            // new_slides = self_sudo - existing_sudo.mapped('slide_id')
            // return SlidePartnerSudo.create([{
            //     'slide_id': new_slide.id,
            //     'channel_id': new_slide.channel_id.id,
            //     'partner_id': target_partner.id,
            //     'quiz_attempts_count': 1 if quiz_attempts_inc else 0,
            //     'vote': 0} for new_slide in new_slides])
            */
            return default;
        }

        public async Task<TEntity> ActionViewEmbedsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def action_view_embeds(self):
            // self.ensure_one()
            // 
            // action = self.env["ir.actions.actions"]._for_xml_id("website_slides.slide_embed_action")
            // action['context'] = {'search_default_slide_id': self.id}
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionViewLivechatChannelsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
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

        public async Task<TEntity> ActionViewRatingsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_view_ratings(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("website_slides.rating_rating_action_slide_channel")
            // action['name'] = _('Rating of %s', self.name)
            // action['domain'] = expression.AND([ast.literal_eval(action.get('domain', '[]')), [('res_id', 'in', self.ids)]])
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionViewSlidesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_view_slides(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("website_slides.slide_slide_action")
            // action['context'] = {
            //     'search_default_published': 1,
            //     'default_channel_id': self.id
            // }
            // action['domain'] = [('channel_id', "=", self.id), ('is_category', '=', False)]
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionVoteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object upvote) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _action_vote(self, upvote=True):
            // """ Private implementation of voting. It does not check for any real access
            // rights; public methods should grant access before calling this method.
            // 
            //   :param upvote: if True, is a like; if False, is a dislike
            // """
            // self_sudo = self.sudo()
            // SlidePartnerSudo = self.env['slide.slide.partner'].sudo()
            // slide_partners = SlidePartnerSudo.search([
            //     ('slide_id', 'in', self.ids),
            //     ('partner_id', '=', self.env.user.partner_id.id)
            // ])
            // slide_id = slide_partners.mapped('slide_id')
            // new_slides = self_sudo - slide_id
            // 
            // for slide_partner in slide_partners:
            //     if upvote:
            //         slide_partner.vote = 0 if slide_partner.vote == 1 else 1
            //     else:
            //         slide_partner.vote = 0 if slide_partner.vote == -1 else -1
            // 
            // for new_slide in new_slides:
            //     new_vote = 1 if upvote else -1
            //     new_slide.write({
            //         'slide_partner_ids': [(0, 0, {'vote': new_vote, 'partner_id': self.env.user.partner_id.id})]
            //     })
            */
            return default;
        }

        public async Task<TEntity> AddGroupsMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _add_groups_members(self):
            // for channel in self:
            //     channel._action_add_members(channel.mapped('enroll_group_ids.users.partner_id'))
            */
            return default;
        }

        public async Task<TEntity> AvatarGenerateSvgInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py) ---
            // def _avatar_generate_svg(self):
            // initial = html_escape(self[self._avatar_name_field][0].upper())
            // bgcolor = get_hsl_from_seed(self[self._avatar_name_field] + str(self.create_date.timestamp() if self.create_date else ""))
            // return b64encode((
            //     "<?xml version='1.0' encoding='UTF-8' ?>"
            //     "<svg height='180' width='180' xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink'>"
            //     f"<rect fill='{bgcolor}' height='180' width='180'/>"
            //     f"<text fill='#ffffff' font-size='96' text-anchor='middle' x='90' y='125' font-family='sans-serif'>{initial}</text>"
            //     "</svg>"
            // ).encode())
            */
            return default;
        }

        public async Task<TEntity> AvatarGetPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py) ---
            // def _avatar_get_placeholder(self):
            // return file_open(self._avatar_get_placeholder_path(), 'rb').read()
            */
            return default;
        }

        public async Task<TEntity> AvatarGetPlaceholderPathInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py) ---
            // def _avatar_get_placeholder_path(self):
            // return "base/static/img/avatar_grey.png"
            */
            return default;
        }

        public async Task<TEntity> CanGrantBadgeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_badge.py) ---
            // def _can_grant_badge(self):
            // """Check if a user can grant a badge to another user
            // 
            // :param uid: the id of the res.users trying to send the badge
            // :param badge_id: the granted badge id
            // :return: integer representing the permission.
            // """
            // if self.env.is_admin():
            //     return self.CAN_GRANT
            // 
            // if self.rule_auth == 'nobody':
            //     return self.NOBODY_CAN_GRANT
            // elif self.rule_auth == 'users' and self.env.user not in self.rule_auth_user_ids:
            //     return self.USER_NOT_VIP
            // elif self.rule_auth == 'having':
            //     all_user_badges = self.env['gamification.badge.user'].search([('user_id', '=', self.env.uid)]).mapped('badge_id')
            //     if self.rule_auth_badge_ids - all_user_badges:
            //         return self.BADGE_REQUIRED
            // 
            // if self.rule_max and self.stat_my_monthly_sending >= self.rule_max_number:
            //     return self.TOO_MANY
            // 
            // # badge.rule_auth == 'everyone' -> no check
            // return self.CAN_GRANT
            */
            return default;
        }

        public async Task<TEntity> CartesianProductInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_template_attribute_values_per_line, object parent_combination) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _cartesian_product(self, product_template_attribute_values_per_line, parent_combination):
            // """
            // Generate all possible combination for attributes values (aka cartesian product).
            // It is equivalent to itertools.product except it skips invalid partial combinations before they are complete.
            // 
            // Imagine the cartesian product of 'A', 'CD' and range(1_000_000) and let's say that 'A' and 'C' are incompatible.
            // If you use itertools.product or any normal cartesian product, you'll need to filter out of the final result
            // the 1_000_000 combinations that start with 'A' and 'C' . Instead, This implementation will test if 'A' and 'C' are
            // compatible before even considering range(1_000_000), skip it and and continue with combinations that start
            // with 'A' and 'D'.
            // 
            // It's necessary for performance reason because filtering out invalid combinations from standard Cartesian product
            // can be extremely slow
            // 
            // :param product_template_attribute_values_per_line: the values we want all the possibles combinations of.
            // One list of values by attribute line
            // :return: a generator of product template attribute value
            // """
            // if not product_template_attribute_values_per_line:
            //     return
            // 
            // all_exclusions = {self.env['product.template.attribute.value'].browse(k):
            //                   self.env['product.template.attribute.value'].browse(v) for k, v in
            //                   self._get_own_attribute_exclusions().items()}
            // # The following dict uses product template attribute values as keys
            // # 0 means the value is acceptable, greater than 0 means it's rejected, it cannot be negative
            // # Bear in mind that several values can reject the same value and the latter can only be included in the
            // #  considered combination if no value rejects it.
            // # This dictionary counts how many times each value is rejected.
            // # Each time a value is included in the considered combination, the values it rejects are incremented
            // # When a value is discarded from the considered combination, the values it rejects are decremented
            // current_exclusions = defaultdict(int)
            // for exclusion in self._get_parent_attribute_exclusions(parent_combination):
            //     current_exclusions[self.env['product.template.attribute.value'].browse(exclusion)] += 1
            // partial_combination = self.env['product.template.attribute.value']
            // 
            // # The following list reflects product_template_attribute_values_per_line
            // # For each line, instead of a list of values, it contains the index of the selected value
            // # -1 means no value has been picked for the line in the current (partial) combination
            // value_index_per_line = [-1] * len(product_template_attribute_values_per_line)
            // # determines which line line we're working on
            // line_index = 0
            // # determines which ptav we're working on
            // current_ptav = None
            // 
            // while True:
            //     current_line_values = product_template_attribute_values_per_line[line_index]
            //     current_ptav_index = value_index_per_line[line_index]
            // 
            //     # For multi-checkbox attribute, the list is empty as we want to start without any selected value
            //     if not current_line_values:
            //         if line_index == len(product_template_attribute_values_per_line) - 1:
            //             # submit combination if we're on the last line
            //             yield partial_combination
            //             # will break or continue further down as current_ptav_index is always -1 here
            //         else:
            //             line_index += 1
            //             continue
            //     else:
            //         current_ptav = current_line_values[current_ptav_index]
            // 
            //     # removing exclusions from current_ptav as we're removing it from partial_combination
            //     if current_ptav_index >= 0:
            //         for ptav_to_include_back in all_exclusions[current_ptav]:
            //             current_exclusions[ptav_to_include_back] -= 1
            //         partial_combination -= current_ptav
            // 
            //     if current_ptav_index < len(current_line_values) - 1:
            //         # go to next value of current line
            //         value_index_per_line[line_index] += 1
            //         current_line_values = product_template_attribute_values_per_line[line_index]
            //         current_ptav_index = value_index_per_line[line_index]
            //         current_ptav = current_line_values[current_ptav_index]
            //     elif line_index != 0:
            //         # reset current line, and then go to previous line
            //         value_index_per_line[line_index] = - 1
            //         line_index -= 1
            //         continue
            //     else:
            //         # we're done if we must reset first line
            //         break
            // 
            //     # adding exclusions from current_ptav as we're incorporating it in partial_combination
            //     for ptav_to_exclude in all_exclusions[current_ptav]:
            //         current_exclusions[ptav_to_exclude] += 1
            //     partial_combination += current_ptav
            // 
            //     # test if included values excludes current value or if current value exclude included values
            //     if current_exclusions[current_ptav] or \
            //             any(intersection in partial_combination for intersection in all_exclusions[current_ptav]):
            //         continue
            // 
            //     if line_index == len(product_template_attribute_values_per_line) - 1:
            //         # submit combination if we're on the last line
            //         yield partial_combination
            //     else:
            //         # else we go to the next line
            //         line_index += 1
            */
            return default;
        }

        public async Task<TEntity> CheckBarcodeUniquenessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _check_barcode_uniqueness(self):
            // for template in self:
            //     template.product_variant_ids._check_barcode_uniqueness()
            */
            return default;
        }

        public async Task<TEntity> CheckComboIdsNotEmptyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _check_combo_ids_not_empty(self):
            // for template in self:
            //     if template.type == 'combo' and not template.combo_ids:
            //         raise ValidationError(_("A combo product must contain at least 1 combo choice."))
            */
            return default;
        }

        public async Task<TEntity> CheckGrantingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_badge.py) ---
            // def check_granting(self):
            // """Check the user 'uid' can grant the badge 'badge_id' and raise the appropriate exception
            // if not
            // 
            // Do not check for SUPERUSER_ID
            // """
            // status_code = self._can_grant_badge()
            // if status_code == self.CAN_GRANT:
            //     return True
            // elif status_code == self.NOBODY_CAN_GRANT:
            //     raise exceptions.UserError(_('This badge can not be sent by users.'))
            // elif status_code == self.USER_NOT_VIP:
            //     raise exceptions.UserError(_('You are not in the user allowed list.'))
            // elif status_code == self.BADGE_REQUIRED:
            //     raise exceptions.UserError(_('You do not have the required badges.'))
            // elif status_code == self.TOO_MANY:
            //     raise exceptions.UserError(_('You have already sent this badge too many time this month.'))
            // else:
            //     _logger.error("Unknown badge status code: %s" % status_code)
            // return False
            */
            return default;
        }

        public async Task<TEntity> CheckParentIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py) ---
            // def check_parent_id(self):
            // if self._has_cycle():
            //     raise ValueError(self.env._("Error! You cannot create recursive categories."))
            */
            return default;
        }

        public async Task<TEntity> CheckQuestionSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
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

        public async Task<TEntity> CheckSaleComboIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _check_sale_combo_ids(self):
            // for template in self:
            //     if (
            //         template.type == 'combo'
            //         and template.sale_ok
            //         and any(
            //             not product.sale_ok for product in template.combo_ids.combo_item_ids.product_id
            //         )
            //     ):
            //         raise ValidationError(
            //             _("A sellable combo product can only contain sellable products.")
            //         )
            */
            return default;
        }

        public async Task<TEntity> CheckUomInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _check_uom(self):
            // if any(template.uom_id and template.uom_po_id and template.uom_id.category_id != template.uom_po_id.category_id for template in self):
            //     raise ValidationError(_('The default Unit of Measure and the purchase Unit of Measure must be in the same category.'))
            */
            return default;
        }

        public async Task<TEntity> CheckValidVideoUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_image.py) ---
            // def _check_valid_video_url(self):
            // for image in self:
            //     if image.video_url and not image.embed_code:
            //         raise ValidationError(_("Provided video URL for '%s' is not valid. Please enter a valid video URL.", image.name))
            */
            return default;
        }

        public async Task<TEntity> CompleteInverseExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object exclusions) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _complete_inverse_exclusions(self, exclusions):
            // """Will complete the dictionnary of exclusions with their respective inverse
            // e.g: Black excludes XL and L
            // -> XL excludes Black
            // -> L excludes Black"""
            // result = dict(exclusions)
            // for key, value in exclusions.items():
            //     for exclusion in value:
            //         if exclusion in result and key not in result[exclusion]:
            //             result[exclusion].append(key)
            //         else:
            //             result[exclusion] = [key]
            // 
            // return result
            */
            return default;
        }

        public async Task<TEntity> ComputeActionRightsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_action_rights(self):
            // user_karma = self.env.user.karma
            // for channel in self:
            //     if channel.can_publish:
            //         channel.can_vote = channel.can_comment = channel.can_review = True
            //     elif not channel.is_member:
            //         channel.can_vote = channel.can_comment = channel.can_review = False
            //     else:
            //         channel.can_review = user_karma >= channel.karma_review
            //         channel.can_comment = user_karma >= channel.karma_slide_comment
            //         channel.can_vote = user_karma >= channel.karma_slide_vote
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1024InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py) ---
            // def _compute_avatar_1024(self):
            // self._compute_avatar('avatar_1024', 'image_1024')
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar128InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py) ---
            // def _compute_avatar_128(self):
            // self._compute_avatar('avatar_128', 'image_128')
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1920InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py) ---
            // def _compute_avatar_1920(self):
            // self._compute_avatar('avatar_1920', 'image_1920')
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar256InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py) ---
            // def _compute_avatar_256(self):
            // self._compute_avatar('avatar_256', 'image_256')
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar512InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py) ---
            // def _compute_avatar_512(self):
            // self._compute_avatar('avatar_512', 'image_512')
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatarInternalAsync<TEntity>(IEnumerable<TEntity> entities, object avatar_field, object image_field) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py) ---
            // def _compute_avatar(self, avatar_field, image_field):
            // for record in self:
            //     avatar = record[image_field]
            //     if not avatar:
            //         if record.id and record[record._avatar_name_field]:
            //             avatar = record._avatar_generate_svg()
            //         else:
            //             avatar = b64encode(record._avatar_get_placeholder())
            //     record[avatar_field] = avatar
            */
            return default;
        }

        public async Task<TEntity> ComputeBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_barcode(self):
            // self._compute_template_field_from_variant_field('barcode')
            */
            return default;
        }

        public async Task<TEntity> ComputeCanImage1024BeZoomedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_can_image_1024_be_zoomed(self):
            // for template in self.with_context(bin_size=False):
            //     template.can_image_1024_be_zoomed = template.image_1920 and is_image_size_above(template.image_1920, template.image_1024)
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_image.py) ---
            // def _compute_can_image_1024_be_zoomed(self):
            // for image in self:
            //     image.can_image_1024_be_zoomed = image.image_1920 and is_image_size_above(image.image_1920, image.image_1024)
            */
            return default;
        }

        public async Task<TEntity> ComputeCanModerateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def _compute_can_moderate(self):
            // for forum in self:
            //     forum.can_moderate = self.env.user.karma >= forum.karma_moderate
            */
            return default;
        }

        public async Task<TEntity> ComputeCanPublishInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_can_publish(self):
            // """ For channels of type 'training', only the responsible (see user_id field) can publish slides.
            // The 'sudo' user needs to be handled because they are the one used for uploads done on the front-end when the
            // logged in user is not publisher but fulfills the upload_group_ids condition. Invited attendees can
            // preview the course as public and sudo. Prevent them from uploading."""
            // for record in self:
            //     if not record.can_upload:
            //         record.can_publish = False
            //     elif record.user_id == self.env.user:
            //         record.can_publish = True
            //     else:
            //         record.can_publish = self.env.user.has_group('website_slides.group_website_slides_manager')
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_can_publish(self):
            // for record in self:
            //     record.can_publish = record.channel_id.can_publish
            */
            return default;
        }

        public async Task<TEntity> ComputeCanUploadInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_can_upload(self):
            // for record in self:
            //     if record.user_id == self.env.user:
            //         record.can_upload = True
            //     elif record.upload_group_ids:
            //         record.can_upload = bool(record.upload_group_ids & self.env.user.groups_id)
            //     else:
            //         record.can_upload = self.env.user.has_group('website_slides.group_website_slides_manager')
            */
            return default;
        }

        public async Task<TEntity> ComputeCategoryAndSlideIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_category_and_slide_ids(self):
            // for channel in self:
            //     channel.slide_category_ids = channel.slide_ids.filtered(lambda slide: slide.is_category)
            //     channel.slide_content_ids = channel.slide_ids - channel.slide_category_ids
            */
            return default;
        }

        public async Task<TEntity> ComputeCategoryCompletedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_category_completed(self):
            // for slide in self:
            //     if not slide.category_id:
            //         slide.user_has_completed_category = False
            //     else:
            //         slide.user_has_completed_category = all(slide.category_id.slide_ids.mapped('user_has_completed'))
            */
            return default;
        }

        public async Task<TEntity> ComputeCategoryCompletionTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_category_completion_time(self):
            // # We don't use read_group() function, otherwise we will have issue with flushing the
            // # data as completion_time is recursive and when it'll try to flush data before it is calculated
            // for category in self.filtered(lambda slide: slide.is_category):
            //     filtered_slides = category.slide_ids.filtered(lambda slide: slide.is_published)
            //     category.completion_time = sum(filtered_slides.mapped("completion_time"))
            */
            return default;
        }

        public async Task<TEntity> ComputeCategoryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_category_id(self):
            // """ Will take all the slides of the channel for which the index is higher
            // than the index of this category and lower than the index of the next category.
            // 
            // Lists are manually sorted because when adding a new browse record order
            // will not be correct as the added slide would actually end up at the
            // first place no matter its sequence."""
            // self.category_id = False  # initialize whatever the state
            // 
            // channel_slides = {}
            // for slide in self:
            //     if slide.channel_id.id not in channel_slides:
            //         channel_slides[slide.channel_id.id] = slide.channel_id.slide_ids
            // 
            // for cid, slides in channel_slides.items():
            //     current_category = self.env['slide.slide']
            //     slide_list = list(slides)
            //     slide_list.sort(key=lambda s: (s.sequence, not s.is_category))
            //     for slide in slide_list:
            //         if slide.is_category:
            //             current_category = slide
            //         elif slide.category_id != current_category:
            //             slide.category_id = current_category.id
            */
            return default;
        }

        public async Task<TEntity> ComputeCommentsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_comments_count(self):
            // for slide in self:
            //     slide.comments_count = len(slide.website_message_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeCostCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_cost_currency_id(self):
            // env_currency_id = self.env.company.currency_id.id
            // for template in self:
            //     template.cost_currency_id = template.company_id.sudo().currency_id.id or env_currency_id
            */
            return default;
        }

        public async Task<TEntity> ComputeCountFlaggedPostsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def _compute_count_flagged_posts(self):
            // for forum in self:
            //     domain = [('forum_id', '=', forum.id), ('state', '=', 'flagged')]
            //     forum.count_flagged_posts = self.env['forum.post'].search_count(domain)
            */
            return default;
        }

        public async Task<TEntity> ComputeCountPostsWaitingValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def _compute_count_posts_waiting_validation(self):
            // for forum in self:
            //     domain = [('forum_id', '=', forum.id), ('state', '=', 'pending')]
            //     forum.count_posts_waiting_validation = self.env['forum.post'].search_count(domain)
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_currency_id(self):
            // main_company = self.env['res.company']._get_main_company()
            // for template in self:
            //     template.currency_id = template.company_id.sudo().currency_id.id or main_company.currency_id.id
            */
            return default;
        }

        public async Task<TEntity> ComputeDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_default_code(self):
            // self._compute_template_field_from_variant_field('default_code')
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_display_name(self):
            // for template in self:
            //     template.display_name = False if not template.name else (
            //         '{}{}'.format(
            //             template.default_code and '[%s] ' % template.default_code or '', template.name
            //         ))
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py) ---
            // def _compute_display_name(self):
            // for category in self:
            //     category.display_name = " / ".join(category.parents_and_self.mapped(
            //         lambda cat: cat.name or self.env._("New")
            //     ))
            */
            return default;
        }

        public async Task<TEntity> ComputeEmbedCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_image.py) ---
            // def _compute_embed_code(self):
            // for image in self:
            //     image.embed_code = get_video_embed_code(image.video_url) or False
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_embed_code(self):
            // request_base_url = request.httprequest.url_root if request else False
            // for slide in self:
            //     base_url = request_base_url or slide.get_base_url()
            //     if base_url[-1] == '/':
            //         base_url = base_url[:-1]
            // 
            //     embed_code = False
            //     embed_code_external = False
            //     if slide.slide_category == 'video':
            //         if slide.video_source_type == 'youtube':
            //             query_params = urls.url_parse(slide.video_url).query
            //             query_params = query_params + '&theme=light' if query_params else 'theme=light'
            //             embed_code = Markup('<iframe src="//www.youtube-nocookie.com/embed/%s?%s" allowFullScreen="true" frameborder="0" aria-label="%s"></iframe>') % (slide.youtube_id, query_params, _('YouTube'))
            //         elif slide.video_source_type == 'google_drive':
            //             embed_code = Markup('<iframe src="//drive.google.com/file/d/%s/preview" allowFullScreen="true" frameborder="0" aria-label="%s"></iframe>') % (slide.google_drive_id, _('Google Drive'))
            //         elif slide.video_source_type == 'vimeo':
            //             if '/' in slide.vimeo_id:
            //                 # in case of privacy 'with URL only', vimeo adds a token after the video ID
            //                 # the embed url needs to receive that token as a "h" parameter
            //                 [vimeo_id, vimeo_token] = slide.vimeo_id.split('/')
            //                 embed_code = Markup("""
            //                     <iframe src="https://player.vimeo.com/video/%s?h=%s&badge=0&amp;autopause=0&amp;player_id=0"
            //                         frameborder="0" allow="autoplay; fullscreen; picture-in-picture" allowfullscreen aria-label="%s"></iframe>""") % (
            //                         vimeo_id, vimeo_token, _('Vimeo'))
            //             else:
            //                 embed_code = Markup("""
            //                     <iframe src="https://player.vimeo.com/video/%s?badge=0&amp;autopause=0&amp;player_id=0"
            //                         frameborder="0" allow="autoplay; fullscreen; picture-in-picture" allowfullscreen aria-label="%s"></iframe>""") % (slide.vimeo_id, _('Vimeo'))
            //     elif slide.slide_category in ['infographic', 'document'] and slide.source_type == 'external' and slide.google_drive_id:
            //         embed_code = Markup('<iframe src="//drive.google.com/file/d/%s/preview" allowFullScreen="true" frameborder="0" aria-label="%s"></iframe>') % (slide.google_drive_id, _('Google Drive'))
            //     elif slide.slide_category == 'document' and slide.source_type == 'local_file':
            //         slide_url = base_url + self.env['ir.http']._url_for('/slides/embed/%s?page=1' % slide.id)
            //         slide_url_external = base_url + self.env['ir.http']._url_for('/slides/embed_external/%s?page=1' % slide.id)
            //         base_embed_code = Markup('<iframe src="%s" class="o_wslides_iframe_viewer" allowFullScreen="true" height="%s" width="%s" frameborder="0" aria-label="%s"></iframe>')
            //         iframe_aria_label = _('Embed code')
            //         embed_code = base_embed_code % (slide_url, 315, 420, iframe_aria_label)
            //         embed_code_external = base_embed_code % (slide_url_external, 315, 420, iframe_aria_label)
            // 
            //     slide.embed_code = embed_code
            //     slide.embed_code_external = embed_code_external or embed_code
            */
            return default;
        }

        public async Task<TEntity> ComputeEmbedCountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_embed_counts(self):
            // read_group_res = self.env['slide.embed']._read_group(
            //     [('slide_id', 'in', self.ids)],
            //     ['slide_id'],
            //     ['count_views:sum'],
            // )
            // mapped_data = {
            //     slide.id: count_views_sum
            //     for slide, count_views_sum in read_group_res
            // }
            // 
            // for slide in self:
            //     slide.embed_count = mapped_data.get(slide.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeEnrollInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_enroll(self):
            // self.filtered(lambda channel: channel.visibility == 'members').enroll = 'invite'
            */
            return default;
        }

        public async Task<TEntity> ComputeFirstStepWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
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

        public async Task<TEntity> ComputeForumStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def _compute_forum_statistics(self):
            // default_stats = {'total_posts': 0, 'total_views': 0, 'total_answers': 0, 'total_favorites': 0}
            // 
            // if not self.ids:
            //     self.update(default_stats)
            //     return
            // 
            // result = {cid: dict(default_stats) for cid in self.ids}
            // read_group_res = self.env['forum.post']._read_group(
            //     [('forum_id', 'in', self.ids), ('state', 'in', ('active', 'close')), ('parent_id', '=', False)],
            //     ['forum_id'],
            //     ['__count', 'views:sum', 'child_count:sum', 'favourite_count:sum'])
            // for forum, count, views_sum, child_count_sum, favourite_count_sum in read_group_res:
            //     stat_forum = result[forum.id]
            //     stat_forum['total_posts'] += count
            //     stat_forum['total_views'] += views_sum
            //     stat_forum['total_answers'] += child_count_sum
            //     stat_forum['total_favorites'] += 1 if favourite_count_sum else 0
            // 
            // for record in self:
            //     record.update(result[record.id])
            */
            return default;
        }

        public async Task<TEntity> ComputeGoogleDriveIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_google_drive_id(self):
            // """ Extracts the Google Drive ID from the url based on the slide category. """
            // 
            // for slide in self:
            //     url = slide.url or slide.document_google_url or slide.image_google_url or slide.video_url
            //     google_drive_id = False
            //     if url:
            //         match = re.match(self.GOOGLE_DRIVE_DOCUMENT_ID_REGEX, url)
            //         if match and len(match.groups()) == 2:
            //             google_drive_id = match.group(2)
            // 
            //     slide.google_drive_id = google_drive_id
            */
            return default;
        }

        public async Task<TEntity> ComputeHasConfigurableAttributesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_has_configurable_attributes(self):
            // """A product is considered configurable if:
            // - It has dynamic attributes
            // - It has any attribute line with at least 2 attribute values configured
            // - It has multi-checkbox display type
            // - It has at least one custom attribute value
            // """
            // for product in self:
            //     product.has_configurable_attributes = (
            //         product.has_dynamic_attributes() or any(
            //             ptal._is_configurable()
            //             for ptal in product.attribute_line_ids
            //         )
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeHasPendingPostInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def _compute_has_pending_post(self):
            // domain = [
            //     ('create_uid', '=', self.env.user.id),
            //     ('state', '=', 'pending'),
            //     ('parent_id', '=', False),
            // ]
            // pending_forums = self.env['forum.forum'].search([
            //     ('id', 'in', self.ids),
            //     ('post_ids', 'any', domain),
            // ])
            // pending_forums.has_pending_post = True
            // (self - pending_forums).has_pending_post = False
            */
            return default;
        }

        public async Task<TEntity> ComputeHasRequestedAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_has_requested_access(self):
            // requested_cids = self.sudo().activity_search(
            //     ['website_slides.mail_activity_data_access_request'],
            //     additional_domain=[('request_partner_id', '=', self.env.user.partner_id.id)]
            // ).mapped('res_id')
            // for channel in self:
            //     channel.has_requested_access = channel.id in requested_cids
            */
            return default;
        }

        public async Task<TEntity> ComputeImage1920InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_image_1920(self):
            // for slide in self:
            //     if slide.slide_category == 'infographic' and slide.source_type == 'local_file' and slide.image_binary_content:
            //         slide.image_1920 = slide.image_binary_content
            //     elif not slide.image_1920:
            //         slide.image_1920 = False
            */
            return default;
        }

        public async Task<TEntity> ComputeIsAvailableAtInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py) ---
            // def _compute_is_available_at(self):
            // """
            //     Is available_at is always false when browsing it
            //     this field is there only to search (see _search_is_available_at)
            // """
            // for product in self:
            //     product.is_available_at = False
            */
            return default;
        }

        public async Task<TEntity> ComputeIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py) ---
            // def _compute_is_favorite(self):
            // for product in self:
            //     product.is_favorite = self.env.user in product.favorite_user_ids
            */
            return default;
        }

        public async Task<TEntity> ComputeIsNewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py) ---
            // def _compute_is_new(self):
            // today = fields.Date.context_today(self)
            // for product in self:
            //     if product.new_until:
            //         product.is_new = today <= product.new_until
            //     else:
            //         product.is_new = False
            */
            return default;
        }

        public async Task<TEntity> ComputeIsNewSlideInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_is_new_slide(self):
            // for slide in self:
            //     slide.is_new_slide = slide.date_published > fields.Datetime.now() - relativedelta(days=7) if slide.is_published else False
            */
            return default;
        }

        public async Task<TEntity> ComputeIsProductVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_is_product_variant(self):
            // self.is_product_variant = False
            */
            return default;
        }

        public async Task<TEntity> ComputeItemCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_item_count(self):
            // for template in self:
            //     # Pricelist item count counts the rules applicable on current template or on its variants.
            //     template.pricelist_item_count = template.env['product.pricelist.item'].search_count([
            //         '&',
            //         '|', ('product_tmpl_id', '=', template.id), ('product_id', 'in', template.product_variant_ids.ids),
            //         ('pricelist_id.active', '=', True),
            //         ('compute_price', '=', 'fixed'),
            //     ])
            */
            return default;
        }

        public async Task<TEntity> ComputeLastOrderDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py) ---
            // def _compute_last_order_date(self):
            // all_orders = self.env['lunch.order'].search([
            //     ('user_id', '=', self.env.user.id),
            //     ('product_id', 'in', self.ids),
            // ])
            // mapped_orders = defaultdict(lambda: self.env['lunch.order'])
            // for order in all_orders:
            //     mapped_orders[order.product_id] |= order
            // for product in self:
            //     if not mapped_orders[product]:
            //         product.last_order_date = False
            //     else:
            //         product.last_order_date = max(mapped_orders[product].mapped('date'))
            */
            return default;
        }

        public async Task<TEntity> ComputeLastPostIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def _compute_last_post_id(self):
            // last_forums_posts = self.env['forum.post']._read_group(
            //     [('forum_id', 'in', self.ids), ('parent_id', '=', False), ('state', '=', 'active')],
            //     groupby=['forum_id'], aggregates=['id:max'],
            // )
            // forum_to_last_post_id = {forum.id: last_post_id for forum, last_post_id in last_forums_posts}
            // for forum in self:
            //     forum.last_post_id = forum_to_last_post_id.get(forum.id, False)
            */
            return default;
        }

        public async Task<TEntity> ComputeLikeInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_like_info(self):
            // rg_data = self.env['slide.slide.partner'].sudo()._read_group(
            //     [('slide_id', 'in', self.ids), ('vote', 'in', (-1, 1))],
            //     ['slide_id', 'vote'], ['__count'],
            // )
            // mapped_data = {
            //     (slide.id, vote): count
            //     for slide, vote, count in rg_data
            // }
            // 
            // for slide in self:
            //     slide.likes = mapped_data.get((slide.id, 1), 0)
            //     slide.dislikes = mapped_data.get((slide.id, -1), 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatChannelCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
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

        public async Task<TEntity> ComputeMarkCompleteActionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_mark_complete_actions(self):
            // """Determine if the slide can be marked as (un)completed.
            // 
            // We can't mark a slide with questions as completed manually because we need to
            // complete the quiz first. But we can mark as uncompleted a slide with questions,
            // and the answers will be reset, the karma removed, etc (see mark_uncompleted).
            // """
            // for slide in self:
            //     slide.can_self_mark_uncompleted = slide.website_published and slide.channel_id.is_member
            //     slide.can_self_mark_completed = (
            //         slide.website_published
            //         and slide.channel_id.is_member
            //         and slide.slide_category != 'quiz'
            //         and not slide.question_ids
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeMembersCountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_members_counts(self):
            // read_group_res = self.env['slide.channel.partner'].sudo()._read_group(
            //     domain=[('channel_id', 'in', self.ids)],
            //     groupby=['channel_id', 'member_status'],
            //     aggregates=['__count']
            // )
            // data = {(channel.id, member_status): count for channel, member_status, count in read_group_res}
            // for channel in self:
            //     channel.members_invited_count = data.get((channel.id, 'invited'), 0)
            //     channel.members_engaged_count = data.get((channel.id, 'joined'), 0) + data.get((channel.id, 'ongoing'), 0)
            //     channel.members_completed_count = data.get((channel.id, 'completed'), 0)
            //     channel.members_all_count = channel.members_invited_count + channel.members_engaged_count + channel.members_completed_count
            //     channel.members_count = channel.members_engaged_count + channel.members_completed_count
            */
            return default;
        }

        public async Task<TEntity> ComputeMembershipValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_membership_values(self):
            // if self.env.user._is_public():
            //     self.is_member = False
            //     self.is_member_invited = False
            //     return
            // data = {
            //     member_status: channel_ids
            //     for member_status, channel_ids in self.env['slide.channel.partner'].sudo()._read_group(
            //         [('partner_id', '=', self.env.user.partner_id.id), ('channel_id', 'in', self.ids), ('active', '=', True)],
            //         ['member_status'], ['channel_id:array_agg']
            //     )
            // }
            // active_channels_ids = data.get('joined', []) + data.get('ongoing', []) + data.get('completed', [])
            // invitation_pending_channels_ids = data.get('invited', [])
            // for channel in self:
            //     channel.is_member = channel.id in active_channels_ids
            //     channel.is_member_invited = channel.id in invitation_pending_channels_ids
            */
            return default;
        }

        public async Task<TEntity> ComputePackagingIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_packaging_ids(self):
            // for p in self:
            //     if len(p.product_variant_ids) == 1:
            //         p.packaging_ids = p.product_variant_ids.packaging_ids
            //     else:
            //         p.packaging_ids = False
            */
            return default;
        }

        public async Task<TEntity> ComputeParentsAndSelfInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py) ---
            // def _compute_parents_and_self(self):
            // for category in self:
            //     if category.parent_path:
            //         category.parents_and_self = self.env['product.public.category'].browse([int(p) for p in category.parent_path.split('/')[:-1]])
            //     else:
            //         category.parents_and_self = category
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerHasNewContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_partner_has_new_content(self):
            // new_published_slides = self.env['slide.slide'].sudo().search([
            //     ('is_published', '=', True),
            //     ('date_published', '>', fields.Datetime.now() - relativedelta(days=7)),
            //     ('channel_id', 'in', self.ids),
            //     ('is_category', '=', False)
            // ])
            // slide_partner_completed = self.env['slide.slide.partner'].sudo().search([
            //     ('channel_id', 'in', self.ids),
            //     ('partner_id', '=', self.env.user.partner_id.id),
            //     ('slide_id', 'in', new_published_slides.ids),
            //     ('completed', '=', True)
            // ]).mapped('slide_id')
            // for channel in self:
            //     new_slides = new_published_slides.filtered(lambda slide: slide.channel_id == channel)
            //     channel.partner_has_new_content = any(slide not in slide_partner_completed for slide in new_slides)
            */
            return default;
        }

        public async Task<TEntity> ComputePartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_partners(self):
            // data = {
            //     slide_channel: partner_ids
            //     for slide_channel, partner_ids in self.env['slide.channel.partner'].sudo()._read_group(
            //         [('channel_id', 'in', self.ids), ('member_status', '!=', 'invited')],
            //         ['channel_id'],
            //         aggregates=['partner_id:array_agg']
            //     )
            // }
            // for slide_channel in self:
            //     slide_channel.partner_ids = data.get(slide_channel, [])
            */
            return default;
        }

        public async Task<TEntity> ComputePrerequisiteUserHasCompletedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_prerequisite_user_has_completed(self):
            // completed_prerequisite_channels = self.env['slide.channel.partner'].sudo().search([
            //     ('partner_id', '=', self.env.user.partner_id.id),
            //     ('channel_id', 'in', self.prerequisite_channel_ids.ids),
            //     ('member_status', '=', 'completed'),
            // ]).mapped('channel_id')
            // for channel in self:
            //     channel.prerequisite_user_has_completed = all(
            //         channel in completed_prerequisite_channels for channel in channel.prerequisite_channel_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeProductCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_product_category.py) ---
            // def _compute_product_count(self):
            // product_data = self.env['lunch.product']._read_group([('category_id', 'in', self.ids)], ['category_id'], ['__count'])
            // data = {category.id: count for category, count in product_data}
            // for category in self:
            //     category.product_count = data.get(category.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeProductDocumentCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_product_document_count(self):
            // for template in self:
            //     template.product_document_count = template.env['product.document'].search_count(
            //         template._get_product_document_domain()
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeProductImageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py) ---
            // def _compute_product_image(self):
            // for product in self:
            //     product.product_image = product.image_128 or product.category_id.image_128
            */
            return default;
        }

        public async Task<TEntity> ComputeProductTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_product_tooltip(self):
            // self.product_tooltip = False
            // for template in self:
            //     template.product_tooltip = template._prepare_tooltip()
            */
            return default;
        }

        public async Task<TEntity> ComputeProductVariantCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_product_variant_count(self):
            // for template in self:
            //     template.product_variant_count = len(template.product_variant_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeProductVariantIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_product_variant_id(self):
            // for p in self:
            //     p.product_variant_id = p.product_variant_ids[:1].id
            */
            return default;
        }

        public async Task<TEntity> ComputePurchaseOkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_purchase_ok(self):
            // pass
            */
            return default;
        }

        public async Task<TEntity> ComputeQuestionsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_questions_count(self):
            // for slide in self:
            //     slide.questions_count = len(slide.question_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeQuizInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_partner, object quiz_done) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_quiz_info(self, target_partner, quiz_done=False):
            // result = dict.fromkeys(self.ids, False)
            // slide_partners = self.env['slide.slide.partner'].sudo().search([
            //     ('slide_id', 'in', self.ids),
            //     ('partner_id', '=', target_partner.id)
            // ])
            // slide_partners_map = dict((sp.slide_id.id, sp) for sp in slide_partners)
            // for slide in self:
            //     if not slide.question_ids:
            //         gains = [0]
            //     else:
            //         gains = [slide.quiz_first_attempt_reward,
            //                  slide.quiz_second_attempt_reward,
            //                  slide.quiz_third_attempt_reward,
            //                  slide.quiz_fourth_attempt_reward]
            //     result[slide.id] = {
            //         'quiz_karma_max': gains[0],  # what could be gained if succeed at first try
            //         'quiz_karma_gain': gains[0],  # what would be gained at next test
            //         'quiz_karma_won': 0,  # what has been gained
            //         'quiz_attempts_count': 0,  # number of attempts
            //     }
            //     slide_partner = slide_partners_map.get(slide.id)
            //     if slide.question_ids and slide_partner and slide_partner.quiz_attempts_count:
            //         result[slide.id]['quiz_karma_gain'] = gains[slide_partner.quiz_attempts_count] if slide_partner.quiz_attempts_count < len(gains) else gains[-1]
            //         result[slide.id]['quiz_attempts_count'] = slide_partner.quiz_attempts_count
            //         if quiz_done or slide_partner.completed:
            //             result[slide.id]['quiz_karma_won'] = gains[slide_partner.quiz_attempts_count-1] if slide_partner.quiz_attempts_count < len(gains) else gains[-1]
            // return result
            */
            return default;
        }

        public async Task<TEntity> ComputeRankUsersCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_karma_rank.py) ---
            // def _compute_rank_users_count(self):
            // requests_data = self.env['res.users']._read_group([('rank_id', '!=', False)], ['rank_id'], ['__count'])
            // requests_mapped_data = {rank.id: count for rank, count in requests_data}
            // for rank in self:
            //     rank.rank_users_count = requests_mapped_data.get(rank.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeRatingStatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_rating_stats(self):
            // super(Channel, self)._compute_rating_stats()
            // for record in self:
            //     record.rating_avg_stars = record.rating_avg
            */
            return default;
        }

        public async Task<TEntity> ComputeServiceTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_service_tracking(self):
            // self.filtered(lambda product: product.type != 'service').service_tracking = 'no'
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideIconClassInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_slide_icon_class(self):
            // icon_per_slide_type = {
            //     'image': 'fa-file-picture-o',
            //     'article': 'fa-file-text-o',
            //     'quiz': 'fa-question-circle-o',
            //     'pdf': 'fa-file-pdf-o',
            //     'sheet': 'fa-file-excel-o',
            //     'doc': 'fa-file-word-o',
            //     'slides': 'fa-file-powerpoint-o',
            //     'youtube_video': 'fa-youtube-play',
            //     'google_drive_video': 'fa-play-circle-o',
            //     'vimeo_video': 'fa-vimeo',
            // }
            // for slide in self:
            //     slide.slide_icon_class = icon_per_slide_type.get(slide.slide_type, 'fa-file-o')
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideLastUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_slide_last_update(self):
            // for record in self:
            //     record.slide_last_update = fields.Date.today()
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_slide_type(self):
            // """ For 'local content' or specific slide categories, the slide type is directly derived
            // from the slide category.
            // 
            // For external content, the slide type is determined from the metadata and the mime_type.
            // (See #_fetch_google_drive_metadata() for more details)."""
            // 
            // for slide in self:
            //     if slide.slide_category == 'document':
            //         if slide.source_type == 'local_file':
            //             slide.slide_type = 'pdf'
            //         elif slide.slide_type not in ['pdf', 'sheet', 'doc', 'slides']:
            //             slide.slide_type = False
            //     elif slide.slide_category == 'infographic':
            //         slide.slide_type = 'image'
            //     elif slide.slide_category == 'article':
            //         slide.slide_type = 'article'
            //     elif slide.slide_category == 'quiz':
            //         slide.slide_type = 'quiz'
            //     elif slide.slide_category == 'video' and slide.video_source_type == 'youtube':
            //         slide.slide_type = 'youtube_video'
            //     elif slide.slide_category == 'video' and slide.video_source_type == 'google_drive':
            //         slide.slide_type = 'google_drive_video'
            //     elif slide.slide_category == 'video' and slide.video_source_type == 'vimeo':
            //         slide.slide_type = 'vimeo_video'
            //     else:
            //         slide.slide_type = False
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideViewsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_slide_views(self):
            // # TODO awa: tried compute_sudo, for some reason it doesn't work in here...
            // read_group_res = self.env['slide.slide.partner'].sudo()._read_group(
            //     [('slide_id', 'in', self.ids)],
            //     ['slide_id'],
            //     aggregates=['__count'],
            // )
            // mapped_data = {slide.id: count for slide, count in read_group_res}
            // for slide in self:
            //     slide.slide_views = mapped_data.get(slide.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeSlidesStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_slides_statistics(self):
            // default_vals = dict(total_views=0, total_votes=0, total_time=0, total_slides=0)
            // keys = ['nbr_%s' % slide_category for slide_category in self.env['slide.slide']._fields['slide_category'].get_values(self.env)]
            // default_vals.update(dict((key, 0) for key in keys))
            // 
            // result = dict((cid, dict(default_vals)) for cid in self.ids)
            // read_group_res = self.env['slide.slide']._read_group(
            //     [('active', '=', True), ('is_published', '=', True), ('channel_id', 'in', self.ids), ('is_category', '=', False)],
            //     ['channel_id', 'slide_category'],
            //     aggregates=['__count', 'likes:sum', 'dislikes:sum', 'total_views:sum', 'completion_time:sum'])
            // for channel, slide_category, count, likes_sum, dislikes_sum, total_views_sum, completion_time_sum in read_group_res:
            //     channel_dict = result[channel.id]
            //     channel_dict['total_votes'] += likes_sum
            //     channel_dict['total_votes'] -= dislikes_sum
            //     channel_dict['total_views'] += total_views_sum
            //     channel_dict['total_time'] += completion_time_sum
            //     if slide_category:
            //         channel_dict[f'nbr_{slide_category}'] = count
            //         channel_dict['total_slides'] += count
            // 
            // for record in self:
            //     record.update(result.get(record.id, default_vals))
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_slides_statistics(self):
            // # Do not use dict.fromkeys(self.ids, dict()) otherwise it will use the same dictionnary for all keys.
            // # Therefore, when updating the dict of one key, it updates the dict of all keys.
            // keys = ['nbr_%s' % slide_category for slide_category in self.env['slide.slide']._fields['slide_category'].get_values(self.env)]
            // default_vals = dict((key, 0) for key in keys + ['total_slides'])
            // 
            // res = self.env['slide.slide']._read_group(
            //     [('is_published', '=', True), ('category_id', 'in', self.filtered('is_category').ids), ('is_category', '=', False)],
            //     ['category_id', 'slide_category'], ['__count'])
            // 
            // result = {category_id: dict(default_vals) for category_id in self.ids}
            // for category, slide_category, count in res:
            //     result[category.id][f'nbr_{slide_category}'] = count
            //     result[category.id]['total_slides'] += count
            // 
            // for record in self:
            //     record.update(result.get(record._origin.id, default_vals))
            */
            return default;
        }

        public async Task<TEntity> ComputeStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_standard_price(self):
            // # Depends on force_company context because standard_price is company_dependent
            // # on the product_product
            // self._compute_template_field_from_variant_field('standard_price')
            */
            return default;
        }

        public async Task<TEntity> ComputeTagIdsUsageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def _compute_tag_ids_usage(self):
            // forums_without_tags = self.filtered(lambda f: not f.tag_ids)
            // forums_without_tags.tag_most_used_ids = forums_without_tags.tag_unused_ids = False
            // forums_with_tags = self - forums_without_tags
            // if not forums_with_tags:
            //     return
            // 
            // tags_data = self.env['forum.tag'].search_read(
            //     [('forum_id', 'in', forums_with_tags.ids)],
            //     fields=['id', 'forum_id', 'posts_count'],
            //     order='forum_id, posts_count DESC, name, id',
            // )
            // current_forum_id = tags_data[0]['forum_id'][0]
            // forum_tags = defaultdict(lambda: {'most_used_ids': [], 'unused_ids': []})
            // 
            // for tag_data in tags_data:
            //     tag_id, tag_forum_id, posts_count = itemgetter('id', 'forum_id', 'posts_count')(tag_data)
            //     if tag_forum_id[0] != current_forum_id:
            //         current_forum_id = tag_forum_id[0]
            //     if not posts_count:  # Could be 0 or None
            //         forum_tags[current_forum_id]['unused_ids'].append(tag_id)
            //     elif len(forum_tags[current_forum_id]['most_used_ids']) < MOST_USED_TAGS_COUNT:
            //         forum_tags[current_forum_id]['most_used_ids'].append(tag_id)
            // 
            // for forum in forums_with_tags:
            //     forum.tag_most_used_ids = self.env['forum.tag'].browse(forum_tags[forum.id]['most_used_ids'])
            //     forum.tag_unused_ids = self.env['forum.tag'].browse(forum_tags[forum.id]['unused_ids'])
            */
            return default;
        }

        public async Task<TEntity> ComputeTeaserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def _compute_teaser(self):
            // for forum in self:
            //     forum.teaser = textwrap.shorten(forum.description, width=180, placeholder='...') if forum.description else ""
            */
            return default;
        }

        public async Task<TEntity> ComputeTemplateFieldFromVariantFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname, object @default) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_template_field_from_variant_field(self, fname, default=False):
            // """Sets the value of the given field based on the template variant values
            // 
            // Equals to product_variant_ids[fname] if it's a single variant product.
            // Otherwise, sets the value specified in ``default``.
            // It's used to compute fields like barcode, weight, volume..
            // 
            // :param str fname: name of the field to compute
            //     (field name must be identical between product.product & product.template models)
            // :param default: default value to set when there are multiple or no variants on the template
            // :return: None
            // """
            // for template in self:
            //     variant_count = len(template.product_variant_ids)
            //     if variant_count == 1:
            //         template[fname] = template.product_variant_ids[fname]
            //     elif variant_count == 0 and self.env.context.get("active_test", True):
            //         # If the product has no active variants, retry without the active_test
            //         template_ctx = template.with_context(active_test=False)
            //         template_ctx._compute_template_field_from_variant_field(fname, default=default)
            //     else:
            //         template[fname] = default
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_total(self):
            // for record in self:
            //     record.total_views = record.slide_views + record.public_views
            */
            return default;
        }

        public async Task<TEntity> ComputeUomPoIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_uom_po_id(self):
            // for template in self:
            //     if not template.uom_po_id or template.uom_id.category_id != template.uom_po_id.category_id:
            //         template.uom_po_id = template.uom_id
            */
            return default;
        }

        public async Task<TEntity> ComputeUserMembershipIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_user_membership_id(self):
            // slide_partners = self.env['slide.slide.partner'].sudo().search([
            //     ('slide_id', 'in', self.ids),
            //     ('partner_id', '=', self.env.user.partner_id.id),
            // ])
            // 
            // for record in self:
            //     record.user_membership_id = next(
            //         (slide_partner for slide_partner in slide_partners if slide_partner.slide_id == record),
            //         self.env['slide.slide.partner']
            //     )
            //     record.user_vote = record.user_membership_id.vote
            //     record.user_has_completed = record.user_membership_id.completed
            */
            return default;
        }

        public async Task<TEntity> ComputeUserStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_user_statistics(self):
            // current_user_info = self.env['slide.channel.partner'].sudo().search(
            //     [('channel_id', 'in', self.ids), ('partner_id', '=', self.env.user.partner_id.id)]
            // )
            // mapped_data = dict((info.channel_id.id, (info.member_status == 'completed', info.completed_slides_count)) for info in current_user_info)
            // for record in self:
            //     completed, completed_slides_count = mapped_data.get(record.id, (False, 0))
            //     record.completed = completed
            //     record.completion = 100.0 if completed else round(100.0 * completed_slides_count / (record.total_slides or 1))
            */
            return default;
        }

        public async Task<TEntity> ComputeValidProductTemplateAttributeLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_valid_product_template_attribute_line_ids(self):
            // """A product template attribute line is considered valid if it has at
            // least one possible value.
            // 
            // Those with only one value are considered valid, even though they should
            // not appear on the configurator itself (unless they have an is_custom
            // value to input), indeed single value attributes can be used to filter
            // products among others based on that attribute/value.
            // """
            // for record in self:
            //     record.valid_product_template_attribute_line_ids = record.attribute_line_ids.filtered(lambda ptal: ptal.value_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeVideoSourceTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_video_source_type(self):
            // for slide in self:
            //     video_source_type = False
            //     youtube_match = re.match(self.YOUTUBE_VIDEO_ID_REGEX, slide.video_url) if slide.video_url else False
            //     if youtube_match and len(youtube_match.groups()) == 2 and len(youtube_match.group(2)) == 11:
            //         video_source_type = 'youtube'
            //     if slide.video_url and not video_source_type and re.match(self.GOOGLE_DRIVE_DOCUMENT_ID_REGEX, slide.video_url):
            //         video_source_type = 'google_drive'
            //     vimeo_match = re.search(self.VIMEO_VIDEO_ID_REGEX, slide.video_url) if slide.video_url else False
            //     if not video_source_type and vimeo_match and len(vimeo_match.groups()) == 3:
            //         video_source_type = 'vimeo'
            // 
            //     slide.video_source_type = video_source_type
            */
            return default;
        }

        public async Task<TEntity> ComputeVimeoIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_vimeo_id(self):
            // for slide in self:
            //     if slide.video_url and slide.video_source_type == 'vimeo':
            //         match = re.search(self.VIMEO_VIDEO_ID_REGEX, slide.video_url)
            //         if match and len(match.groups()) == 3:
            //             if match.group(3):
            //                 # in case of privacy 'with URL only', vimeo adds a token after the video ID
            //                 # the share url is then 'vimeo_id/token'
            //                 # the token will be captured in the third group of the regex (if any)
            //                 slide.vimeo_id = '%s/%s' % (match.group(2), match.group(3))
            //             else:
            //                 # regular video, we just capture the vimeo_id
            //                 slide.vimeo_id = match.group(2)
            //     else:
            //         slide.vimeo_id = False
            */
            return default;
        }

        public async Task<TEntity> ComputeVolumeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_volume(self):
            // self._compute_template_field_from_variant_field('volume')
            */
            return default;
        }

        public async Task<TEntity> ComputeVolumeUomNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_volume_uom_name(self):
            // self.volume_uom_name = self._get_volume_uom_name_from_ir_config_parameter()
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteDefaultBackgroundImageUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_website_default_background_image_url(self):
            // for channel in self:
            //     channel.website_default_background_image_url = f'website_slides/static/src/img/channel-{channel.channel_type}-default.jpg'
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteShareUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_website_share_url(self):
            // self.website_share_url = False
            // for slide in self:
            //     if slide.id:  # ensure we can build the URL
            //         base_url = slide.channel_id.get_base_url()
            //         slide.website_share_url = '%s/slides/slide/%s/share' % (base_url, slide.id)
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def _compute_website_url(self):
            // if not self.id:
            //     return False
            // return f'/forum/{self.env["ir.http"]._slug(self)}'
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_website_url(self):
            // super(Channel, self)._compute_website_url()
            // for channel in self:
            //     if channel.id:  # avoid to perform a slug on a not yet saved record in case of an onchange.
            //         base_url = channel.get_base_url()
            //         channel.website_url = '%s/slides/%s' % (base_url, self.env['ir.http']._slug(channel))
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_website_url(self):
            // super(Slide, self)._compute_website_url()
            // for slide in self:
            //     if slide.id:  # avoid to perform a slug on a not yet saved record in case of an onchange.
            //         base_url = slide.channel_id.get_base_url()
            //         slide.website_url = '%s/slides/slide/%s' % (base_url, self.env['ir.http']._slug(slide))
            */
            return default;
        }

        public async Task<TEntity> ComputeWeightInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_weight(self):
            // self._compute_template_field_from_variant_field('weight')
            */
            return default;
        }

        public async Task<TEntity> ComputeWeightUomNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_weight_uom_name(self):
            // self.weight_uom_name = self._get_weight_uom_name_from_ir_config_parameter()
            */
            return default;
        }

        public async Task<TEntity> ComputeYoutubeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_youtube_id(self):
            // for slide in self:
            //     if slide.video_url and slide.video_source_type == 'youtube':
            //         match = re.match(self.YOUTUBE_VIDEO_ID_REGEX, slide.video_url)
            //         if match and len(match.groups()) == 2 and len(match.group(2)) == 11:
            //             slide.youtube_id = match.group(2)
            //         else:
            //             slide.youtube_id = False
            //     else:
            //         slide.youtube_id = False
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IImageMixinable
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
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def copy(self, default=None):
            // res = super().copy(default=default)
            // # Since we don't copy the product template attribute values, we need to match the extra prices.
            // for ptal, copied_ptal in zip(self.attribute_line_ids, res.attribute_line_ids):
            //     for ptav, copied_ptav in zip(ptal.product_template_value_ids, copied_ptal.product_template_value_ids):
            //         if not ptav.price_extra:
            //             continue
            //         # security check
            //         if ptav.attribute_id == copied_ptav.attribute_id and ptav.product_attribute_value_id == copied_ptav.product_attribute_value_id:
            //             copied_ptav.price_extra = ptav.price_extra
            // return res
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, title=self.env._("%s (copy)", script.title)) for script, vals in zip(self, vals_list)]
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // if 'name' not in default:
            //     for template, vals in zip(self, vals_list):
            //         vals['name'] = _("%s (copy)", template.name)
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // for channel, vals in zip(self, vals_list):
            //     if 'name' not in default:
            //         vals['name'] = f"{channel.name} ({_('copy')})"
            //     if 'enroll' not in default and channel.visibility == "members":
            //         vals['enroll'] = 'invite'
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def copy_data(self, default=None):
            // """Sets the sequence to zero so that it always lands at the beginning
            // of the newly selected course as an uncategorized slide"""
            // default = dict(default or {})
            // if 'slide.channel' not in self._context.get('__copy_data_seen', {}) and 'sequence' not in default:
            //     default['sequence'] = 0
            // return super().copy_data(default=default)
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_karma_rank.py) ---
            // def create(self, values_list):
            // res = super(KarmaRank, self).create(values_list)
            // if any(res.mapped('karma_min')) > 0:
            //     users = self.env['res.users'].sudo().search([('karma', '>=', max(min(res.mapped('karma_min')), 1))])
            //     if users:
            //         users._recompute_rank()
            // return res
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
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def create(self, vals_list):
            // ''' Store the initial standard price in order to be able to retrieve the cost of a product template for a given date'''
            // templates = super(ProductTemplate, self).create(vals_list)
            // if self._context.get("create_product_product", True):
            //     templates._create_variant_ids()
            // 
            // # This is needed to set given values to first variant after creation
            // for template, vals in zip(templates, vals_list):
            //     related_vals = {}
            //     for field_name in self._get_related_fields_variant_template():
            //         if vals.get(field_name):
            //             related_vals[field_name] = vals[field_name]
            //     if related_vals:
            //         template.write(related_vals)
            // 
            // return templates
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def create(self, vals_list):
            // forums = super(
            //     Forum,
            //     self.with_context(mail_create_nolog=True, mail_create_nosubscribe=True)
            // ).create(vals_list)
            // self.env['website'].sudo()._update_forum_count()
            // forums._set_default_faq()
            // return forums
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_image.py) ---
            // def create(self, vals_list):
            // """
            //     We don't want the default_product_tmpl_id from the context
            //     to be applied if we have a product_variant_id set to avoid
            //     having the variant images to show also as template images.
            //     But we want it if we don't have a product_variant_id set.
            // """
            // context_without_template = self.with_context({k: v for k, v in self.env.context.items() if k != 'default_product_tmpl_id'})
            // normal_vals = []
            // variant_vals_list = []
            // 
            // for vals in vals_list:
            //     if vals.get('product_variant_id') and 'default_product_tmpl_id' in self.env.context:
            //         variant_vals_list.append(vals)
            //     else:
            //         normal_vals.append(vals)
            // 
            // return super().create(normal_vals) + super(ProductImage, context_without_template).create(variant_vals_list)
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     # Ensure creator is member of its channel it is easier for them to manage it (unless it is odoobot)
            //     if not vals.get('channel_partner_ids') and not self.env.is_superuser():
            //         vals['channel_partner_ids'] = [(0, 0, {
            //             'partner_id': self.env.user.partner_id.id
            //         })]
            //     if not is_html_empty(vals.get('description')) and is_html_empty(vals.get('description_short')):
            //         vals['description_short'] = vals['description']
            // 
            // channels = super(Channel, self.with_context(mail_create_nosubscribe=True)).create(vals_list)
            // 
            // for channel in channels:
            //     if channel.user_id:
            //         channel._action_add_members(channel.user_id.partner_id)
            //     if channel.enroll_group_ids:
            //         channel._add_groups_members()
            // 
            // return channels
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def create(self, vals_list):
            // channel_ids = [vals['channel_id'] for vals in vals_list]
            // can_publish_channel_ids = self.env['slide.channel'].browse(channel_ids).filtered(lambda c: c.can_publish).ids
            // for vals in vals_list:
            //     # Do not publish slide if user has not publisher rights
            //     if vals['channel_id'] not in can_publish_channel_ids:
            //         # 'website_published' is handled by mixin
            //         vals['date_published'] = False
            // 
            //     if vals.get('is_category'):
            //         vals['is_preview'] = True
            //         vals['is_published'] = True
            //     if vals.get('is_published') and not vals.get('date_published'):
            //         vals['date_published'] = datetime.datetime.now()
            // 
            // slides = super().create(vals_list)
            // 
            // for slide, vals in zip(slides, vals_list):
            //     # avoid fetching external metadata when installing the module (i.e. for demo data)
            //     # we also support a context key if you don't want to fetch the metadata when creating a slide
            //     if any(vals.get(url_param) for url_param in ['url', 'video_url', 'document_google_url', 'image_google_url']) \
            //        and not self.env.context.get('install_mode') \
            //        and not self.env.context.get('website_slides_skip_fetch_metadata'):
            //         slide_metadata, _error = slide._fetch_external_metadata()
            //         if slide_metadata:
            //             # only update keys that are not set in the incoming vals
            //             slide.update({key: value for key, value in slide_metadata.items() if key not in vals.keys()})
            // 
            //     if 'completion_time' not in vals:
            //         slide._on_change_document_binary_content()
            // 
            //     if slide.is_published and not slide.is_category:
            //         slide._post_publication()
            //         slide.channel_id.channel_partner_ids._recompute_completion()
            // return slides
            */
            return default;
        }

        public async Task<TEntity> CreateFirstProductVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities, object log_warning) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _create_first_product_variant(self, log_warning=False):
            // """Create if necessary and possible and return the first product
            // variant for this template.
            // 
            // :param log_warning: whether a warning should be logged on fail
            // :type log_warning: bool
            // 
            // :return: the first product variant or none
            // :rtype: recordset of `product.product`
            // """
            // return self._create_product_variant(self._get_first_possible_combination(), log_warning)
            */
            return default;
        }

        public async Task<TEntity> CreateProductVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, object log_warning) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _create_product_variant(self, combination, log_warning=False):
            // """ Create if necessary and possible and return the product variant
            // matching the given combination for this template.
            // 
            // It is possible to create only if the template has dynamic attributes
            // and the combination itself is possible.
            // If we are in this case and the variant already exists but it is
            // archived, it is activated instead of being created again.
            // 
            // :param combination: the combination for which to get or create variant.
            //     The combination must contain all necessary attributes, including
            //     those of type no_variant. Indeed even though those attributes won't
            //     be included in the variant if newly created, they are needed when
            //     checking if the combination is possible.
            // :type combination: recordset of `product.template.attribute.value`
            // 
            // :param log_warning: whether a warning should be logged on fail
            // :type log_warning: bool
            // 
            // :return: the product variant matching the combination or none
            // :rtype: recordset of `product.product`
            // """
            // self.ensure_one()
            // 
            // Product = self.env['product.product']
            // 
            // product_variant = self._get_variant_for_combination(combination)
            // if product_variant:
            //     if not product_variant.active and self.has_dynamic_attributes() and self._is_combination_possible(combination):
            //         product_variant.active = True
            //     return product_variant
            // 
            // if not self.has_dynamic_attributes():
            //     if log_warning:
            //         _logger.warning('The user #%s tried to create a variant for the non-dynamic product %s.' % (self.env.user.id, self.id))
            //     return Product
            // 
            // if not self._is_combination_possible(combination):
            //     if log_warning:
            //         _logger.warning('The user #%s tried to create an invalid variant for the product %s.' % (self.env.user.id, self.id))
            //     return Product
            // 
            // return Product.sudo().create({
            //     'product_tmpl_id': self.id,
            //     'product_template_attribute_value_ids': [(6, 0, combination._without_no_variant_attributes().ids)]
            // })
            */
            return default;
        }

        public async Task<TEntity> CreateVariantIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _create_variant_ids(self):
            // if not self:
            //     return
            // self.env.flush_all()
            // Product = self.env["product.product"]
            // 
            // variants_to_create = []
            // variants_to_activate = Product
            // variants_to_unlink = Product
            // 
            // for tmpl_id in self:
            //     lines_without_no_variants = tmpl_id.valid_product_template_attribute_line_ids._without_no_variant_attributes()
            // 
            //     all_variants = tmpl_id.with_context(active_test=False).product_variant_ids.sorted(lambda p: (p.active, -p.id))
            // 
            //     current_variants_to_create = []
            //     current_variants_to_activate = Product
            // 
            //     # adding an attribute with only one value should not recreate product
            //     # write this attribute on every product to make sure we don't lose them
            //     single_value_lines = lines_without_no_variants.filtered(lambda ptal: len(ptal.product_template_value_ids._only_active()) == 1)
            //     if single_value_lines:
            //         for variant in all_variants:
            //             combination = variant.product_template_attribute_value_ids | single_value_lines.product_template_value_ids._only_active()
            //             # Do not add single value if the resulting combination would
            //             # be invalid anyway.
            //             if (
            //                 len(combination) == len(lines_without_no_variants) and
            //                 combination.attribute_line_id == lines_without_no_variants
            //             ):
            //                 variant.product_template_attribute_value_ids = combination
            // 
            //     # Set containing existing `product.template.attribute.value` combination
            //     existing_variants = {
            //         variant.product_template_attribute_value_ids: variant for variant in all_variants
            //     }
            // 
            //     # Determine which product variants need to be created based on the attribute
            //     # configuration. If any attribute is set to generate variants dynamically, skip the
            //     # process.
            //     # Technical note: if there is no attribute, a variant is still created because
            //     # 'not any([])' and 'set([]) not in set([])' are True.
            //     if not tmpl_id.has_dynamic_attributes():
            //         # Iterator containing all possible `product.template.attribute.value` combination
            //         # The iterator is used to avoid MemoryError in case of a huge number of combination.
            //         all_combinations = itertools.product(*[
            //             ptal.product_template_value_ids._only_active() for ptal in lines_without_no_variants
            //         ])
            //         # For each possible variant, create if it doesn't exist yet.
            //         for combination in tmpl_id._filter_combinations_impossible_by_config(
            //             all_combinations, ignore_no_variant=True,
            //         ):
            //             if combination in existing_variants:
            //                 current_variants_to_activate += existing_variants[combination]
            //             else:
            //                 current_variants_to_create.append(tmpl_id._prepare_variant_values(combination))
            //                 variant_limit = self.env['ir.config_parameter'].sudo().get_param('product.dynamic_variant_limit', 1000)
            //                 if len(current_variants_to_create) > int(variant_limit):
            //                     raise UserError(_(
            //                         'The number of variants to generate is above allowed limit. '
            //                         'You should either not generate variants for each combination or generate them on demand from the sales order. '
            //                         'To do so, open the form view of attributes and change the mode of *Create Variants*.'))
            //         variants_to_create += current_variants_to_create
            //         variants_to_activate += current_variants_to_activate
            // 
            //     elif existing_variants:
            //         variants_combinations = [variant.product_template_attribute_value_ids for variant in existing_variants.values()]
            //         current_variants_to_activate += Product.concat(*[existing_variants[possible_combination]
            //             for possible_combination in tmpl_id._filter_combinations_impossible_by_config(variants_combinations, ignore_no_variant=True)
            //         ])
            //         variants_to_activate += current_variants_to_activate
            // 
            //     variants_to_unlink += all_variants - current_variants_to_activate
            // 
            // if variants_to_activate:
            //     variants_to_activate.write({'active': True})
            // if variants_to_create:
            //     Product.create(variants_to_create)
            // if variants_to_unlink:
            //     variants_to_unlink._unlink_or_archive()
            //     # prevent change if exclusion deleted template by deleting last variant
            //     if self.exists() != self:
            //         raise UserError(_("This configuration of product attributes, values, and exclusions would lead to no possible variant. Please archive or delete your product directly if intended."))
            // for variant in variants_to_unlink:
            //     combo_items_to_unlink = self.env['product.combo.item'].search([
            //         ('product_id', '=', variant.id)
            //     ])
            //     # Unlink all combo items which reference unlinked variants.
            //     combo_items_to_unlink.unlink()
            // 
            // # prefetched o2m have to be reloaded (because of active_test)
            // # (eg. product.template: product_variant_ids)
            // # We can't rely on existing invalidate because of the savepoint
            // # in _unlink_or_archive.
            // self.env.flush_all()
            // self.env.invalidate_all()
            // return True
            */
            return default;
        }

        public async Task<TEntity> DefaultAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _default_access_token(self):
            // return str(uuid.uuid4())
            */
            return default;
        }

        public async Task<TEntity> DefaultCoverPropertiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _default_cover_properties(self):
            // """ Cover properties defaults are overridden to keep a consistent look for the slides
            // channels headers across Odoo versions (pre-customization, with purple gradient fitting the
            // homepage images, etc). Furthermore, as adding padding to the cover would not look great,
            // its height is set to fit to content (snippet option to change this also disabled on the view)."""
            // res = super()._default_cover_properties()
            // res.update({
            //     "background_color_class": "o_cc3",
            //     'background_color_style': (
            //         'background-color: rgba(0, 0, 0, 0); '
            //         'background-image: linear-gradient(120deg, #875A7B, #78516F);'
            //     ),
            //     'opacity': '0',
            //     'resize_class': 'cover_auto'
            // })
            // return res
            */
            return default;
        }

        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields_list) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def default_get(self, fields_list):
            // res = super().default_get(fields_list)
            // if 'uom_id' in fields_list and not res.get('uom_id') or self.env.context.get('default_uom_id') is False:
            //     res['uom_id'] = self._get_default_uom_id().id
            // return res
            */
            return default;
        }

        public async Task<TEntity> DefaultImageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_product_category.py) ---
            // def _default_image(self):
            // return base64.b64encode(file_open('lunch/static/img/lunch.png', 'rb').read())
            */
            return default;
        }

        public async Task<TEntity> DefaultSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py) ---
            // def _default_sequence(self):
            // cat = self.search([], limit=1, order='sequence DESC')
            // if cat:
            //     return cat.sequence + 5
            // return 10000
            */
            return default;
        }

        public async Task<TEntity> DefaultWebsiteMetaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _default_website_meta(self):
            // res = super(Slide, self)._default_website_meta()
            // res['default_opengraph']['og:title'] = res['default_twitter']['twitter:title'] = self.name
            // res['default_opengraph']['og:description'] = res['default_twitter']['twitter:description'] = html2plaintext(self.description)
            // res['default_opengraph']['og:image'] = res['default_twitter']['twitter:image'] = self.env['website'].image_url(self, 'image_1024')
            // res['default_meta_description'] = html2plaintext(self.description)
            // return res
            */
            return default;
        }

        public async Task<TEntity> DemoConfigureVariantsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _demo_configure_variants(self):
            // acoustic_bloc_screens = self.env.ref(
            //     'product.product_template_acoustic_bloc_screens', raise_if_not_found=False
            // )
            // if acoustic_bloc_screens:
            //     acoustic_bloc_screens.product_variant_ids[0].default_code = 'FURN_6666'
            //     acoustic_bloc_screens.product_variant_ids[1].default_code = 'FURN_6667'
            //     self.env['ir.model.data']._update_xmlids([{
            //         'xml_id': 'product.product_product_25',
            //         'record': acoustic_bloc_screens.product_variant_ids[1],
            //         'noupdate': True,
            //     }])
            */
            return default;
        }

        public async Task<TEntity> EmbedIncrementInternalAsync<TEntity>(IEnumerable<TEntity> entities, object url) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _embed_increment(self, url):
            // """ Increment the view count of the record we have based on the passed url.
            // If the url is empty, which typically happens if the browser does not pass the 'referer'
            // header properly, then we increment the entry that has 'False' as url value. """
            // 
            // self.ensure_one()
            // 
            // url_entry = url
            // if not urls.url_parse(url).netloc:
            //     url_entry = False
            // 
            // embed_entry = self.env['slide.embed'].search([
            //     ('url', '=', url_entry),
            //     ('slide_id', '=', self.id)
            // ], limit=1)
            // 
            // if embed_entry:
            //     embed_entry.count_views += 1
            // else:
            //     embed_entry = self.env['slide.embed'].create({
            //         'slide_id': self.id,
            //         'url': url_entry,
            //     })
            // 
            // return embed_entry
            */
            return default;
        }

        public async Task<TEntity> FetchExternalMetadataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object image_url_only) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _fetch_external_metadata(self, image_url_only=False):
            // self.ensure_one()
            // 
            // slide_metadata = {}
            // error = False
            // if self.slide_category == 'video' and self.video_source_type == 'youtube':
            //     slide_metadata, error = self._fetch_youtube_metadata(image_url_only)
            // elif self.slide_category == 'video' and self.video_source_type == 'google_drive':
            //     slide_metadata, error = self._fetch_google_drive_metadata(image_url_only)
            // elif self.slide_category == 'video' and self.video_source_type == 'vimeo':
            //     slide_metadata, error = self._fetch_vimeo_metadata(image_url_only)
            // elif self.slide_category in ['document', 'infographic'] and self.source_type == 'external':
            //     # external documents & google drive videos share the same method currently
            //     slide_metadata, error = self._fetch_google_drive_metadata(image_url_only)
            // 
            // return slide_metadata, error
            */
            return default;
        }

        public async Task<TEntity> FetchGoogleDriveMetadataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object image_url_only) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _fetch_google_drive_metadata(self, image_url_only=False):
            // """ Fetches document / video metadata from the Google Drive API.
            // 
            // Returns a dict containing metadata with the following keys (matching slide.slide fields):
            // - 'name' matching the external file title
            // - 'image_1920' binary data of the file thumbnail
            //   OR 'image_url' containing an external link to the thumbnail when 'image_url_only' param is True
            // - 'completion_time' which is computed for 2 types of files:
            //   - pdf files where we download the content and then use slide.slide#_get_completion_time_pdf()
            //   - videos where we use the 'videoMediaMetadata' to extract the 'durationMillis'
            // 
            // :param image_url_only: if True, will return 'image_url' instead of binary data
            //   Typically used when displaying a slide preview to the end user.
            // :return a tuple (values, error) containing the values of the slide and a potential error
            //   (e.g: 'File could not be found') """
            // 
            // params = {}
            // params['projection'] = 'BASIC'
            // if 'google.drive.config' in self.env:
            //     access_token = False
            //     try:
            //         access_token = self.env['google.drive.config'].get_access_token()
            //     except (RedirectWarning, UserError):
            //         pass  # ignore and use the 'key' fallback
            // 
            //     if access_token:
            //         params['access_token'] = access_token
            // 
            // if not params.get('access_token'):
            //     params['key'] = self.env['website'].get_current_website().sudo().website_slide_google_app_key
            // 
            // error_message = False
            // try:
            //     response = requests.get(
            //         'https://www.googleapis.com/drive/v2/files/%s' % self.google_drive_id,
            //         timeout=3,
            //         params=params
            //     )
            //     response.raise_for_status()
            // except requests.exceptions.HTTPError as e:
            //     error_message = e.response.content
            //     if 'application/json' in e.response.headers.get('content-type'):
            //         json_response = e.response.json()
            //         if json_response.get('error', {}).get('code') == 404:
            //             # in case we don't find the file on GDrive, we want to give some feedback to our user
            //             return {}, _('Your file could not be found on Google Drive, please check the link and/or privacy settings')
            // except requests.exceptions.ConnectionError as e:
            //     error_message = str(e)
            // 
            // if not error_message:
            //     response = response.json()
            //     if response.get('error'):
            //         error_message = response.get('error', {}).get('errors', [{}])[0].get('reason')
            // 
            // if error_message:
            //     _logger.warning('Could not fetch Google Drive metadata: %s', error_message)
            //     return {}, error_message
            // 
            // google_drive_values = response
            // slide_metadata = {
            //     'name': google_drive_values.get('title')
            // }
            // 
            // if google_drive_values.get('thumbnailLink'):
            //     # small trick, we remove '=s220' to get a higher definition
            //     thumbnail_url = google_drive_values['thumbnailLink'].replace('=s220', '')
            //     if image_url_only:
            //         slide_metadata['image_url'] = thumbnail_url
            //     else:
            //         slide_metadata['image_1920'] = base64.b64encode(
            //             requests.get(thumbnail_url, timeout=3).content
            //         )
            // 
            // if self.slide_category == 'document':
            //     sheet_mimetypes = [
            //         'application/vnd.ms-excel',
            //         'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet',
            //         'application/vnd.oasis.opendocument.spreadsheet',
            //         'application/vnd.google-apps.spreadsheet'
            //     ]
            // 
            //     doc_mimetypes = [
            //         'application/msword',
            //         'application/vnd.openxmlformats-officedocument.wordprocessingml.document',
            //         'application/vnd.oasis.opendocument.text',
            //         'application/vnd.google-apps.document'
            //     ]
            // 
            //     slides_mimetypes = [
            //         'application/vnd.ms-powerpoint',
            //         'application/vnd.openxmlformats-officedocument.presentationml.presentation',
            //         'application/vnd.oasis.opendocument.presentation',
            //         'application/vnd.google-apps.presentation'
            //     ]
            // 
            //     mime_type = google_drive_values.get('mimeType')
            //     if mime_type == 'application/pdf':
            //         slide_metadata['slide_type'] = 'pdf'
            //         if google_drive_values.get('downloadUrl'):
            //             # attempt to download PDF content to extract a completion_time based on the number of pages
            //             try:
            //                 pdf_response = requests.get(google_drive_values.get('downloadUrl'), timeout=5)
            //                 completion_time = self._get_completion_time_pdf(pdf_response.content)
            //                 if completion_time:
            //                     slide_metadata['completion_time'] = completion_time
            //             except Exception:
            //                 pass  # fail silently as this is nice to have
            //     elif mime_type in sheet_mimetypes:
            //         slide_metadata['slide_type'] = 'sheet'
            //     elif mime_type in doc_mimetypes:
            //         slide_metadata['slide_type'] = 'doc'
            //     elif mime_type in slides_mimetypes:
            //         slide_metadata['slide_type'] = 'slides'
            //     elif mime_type and mime_type.startswith('image/'):
            //         # image and videos should be input using another "slide_category" but let's be nice and
            //         # assign them a matching slide_type
            //         slide_metadata['slide_type'] = 'image'
            //     elif mime_type and mime_type.startswith('video/'):
            //         slide_metadata['slide_type'] = 'google_drive_video'
            // 
            // elif self.slide_category == 'video':
            //     completion_time = round(float(
            //         google_drive_values.get('videoMediaMetadata', {}).get('durationMillis', 0)
            //         ) / (60 * 1000)) / 60  # millis to hours conversion rounded to the minute
            //     if completion_time:
            //         slide_metadata['completion_time'] = completion_time
            // 
            // return slide_metadata, None
            */
            return default;
        }

        public async Task<TEntity> FetchVimeoMetadataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object image_url_only) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _fetch_vimeo_metadata(self, image_url_only=False):
            // """ Fetches video metadata from the Vimeo API.
            // See https://developer.vimeo.com/api/oembed/showcases for more information.
            // 
            // Returns a dict containing video metadata with the following keys (matching slide.slide fields):
            // - 'name' matching the video title
            // - 'description' matching the video description
            // - 'image_1920' binary data of the video thumbnail
            //   OR 'image_url' containing an external link to the thumbnail when 'fetch_image' param is False
            // - 'completion_time' matching the video duration
            // 
            // :param image_url_only: if False, will return 'image_url' instead of binary data
            //   Typically used when displaying a slide preview to the end user.
            // :return a tuple (values, error) containing the values of the slide and a potential error
            //   (e.g: 'Video could not be found') """
            // 
            // self.ensure_one()
            // error_message = False
            // try:
            //     response = requests.get(
            //         'https://vimeo.com/api/oembed.json?%s' % urls.url_encode({'url': self.video_url}),
            //         timeout=3
            //     )
            //     response.raise_for_status()
            // except requests.exceptions.HTTPError as e:
            //     error_message = e.response.content
            //     if e.response.status_code == 404:
            //         return {}, _('Your video could not be found on Vimeo, please check the link and/or privacy settings')
            // except requests.exceptions.ConnectionError as e:
            //     error_message = str(e)
            // 
            // if not error_message and 'application/json' in response.headers.get('content-type'):
            //     response = response.json()
            //     if response.get('error'):
            //         error_message = response.get('error', {}).get('errors', [{}])[0].get('reason')
            // 
            //     if not response:
            //         error_message = _('Please enter a valid Vimeo video link')
            // 
            // if error_message:
            //     _logger.warning('Could not fetch Vimeo metadata: %s', error_message)
            //     return {}, error_message
            // 
            // vimeo_values = response
            // slide_metadata = {'slide_type': 'vimeo_video'}
            // 
            // if vimeo_values.get('title'):
            //     slide_metadata['name'] = vimeo_values.get('title')
            // 
            // if vimeo_values.get('description'):
            //     slide_metadata['description'] = vimeo_values.get('description')
            // 
            // if vimeo_values.get('duration'):
            //     # seconds to hours conversion
            //     slide_metadata['completion_time'] = round(vimeo_values.get('duration') / 60) / 60
            // 
            // thumbnail_url = vimeo_values.get('thumbnail_url')
            // if thumbnail_url:
            //     if image_url_only:
            //         slide_metadata['image_url'] = thumbnail_url
            //     else:
            //         slide_metadata['image_1920'] = base64.b64encode(
            //             requests.get(thumbnail_url, timeout=3).content
            //         )
            // 
            // return slide_metadata, None
            */
            return default;
        }

        public async Task<TEntity> FetchYoutubeMetadataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object image_url_only) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _fetch_youtube_metadata(self, image_url_only=False):
            // """ Fetches video metadata from the YouTube API.
            // 
            // Returns a dict containing video metadata with the following keys (matching slide.slide fields):
            // - 'name' matching the video title
            // - 'description' matching the video description
            // - 'image_1920' binary data of the video thumbnail
            //   OR 'image_url' containing an external link to the thumbnail when 'image_url_only' param is True
            // - 'completion_time' matching the video duration
            //   The received duration is under a special format (e.g: PT1M21S15, meaning 1h 21m 15s).
            // 
            // :param image_url_only: if True, will return 'image_url' instead of binary data
            //   Typically used when displaying a slide preview to the end user.
            // :return a tuple (values, error) containing the values of the slide and a potential error
            //   (e.g: 'Video could not be found') """
            // 
            // self.ensure_one()
            // google_app_key = self.env['website'].get_current_website().sudo().website_slide_google_app_key
            // error_message = False
            // try:
            //     response = requests.get(
            //         'https://www.googleapis.com/youtube/v3/videos',
            //         timeout=3,
            //         params={
            //             'fields': 'items(id,snippet,contentDetails)',
            //             'id': self.youtube_id,
            //             'key': google_app_key,
            //             'part': 'snippet,contentDetails'
            //         }
            //     )
            //     response.raise_for_status()
            // except requests.exceptions.HTTPError as e:
            //     error_message = e.response.content
            //     if 'application/json' in e.response.headers.get('content-type'):
            //         json_response = e.response.json()
            //         if json_response.get('error', {}).get('code') == 404:
            //             return {}, _('Your video could not be found on YouTube, please check the link and/or privacy settings')
            // except requests.exceptions.ConnectionError as e:
            //     error_message = str(e)
            // 
            // if not error_message:
            //     response = response.json()
            //     if response.get('error'):
            //         error_message = response.get('error', {}).get('errors', [{}])[0].get('reason')
            // 
            //     if not response.get('items'):
            //         error_message = _('Your video could not be found on YouTube, please check the link and/or privacy settings')
            // 
            // if error_message:
            //     _logger.warning('Could not fetch YouTube metadata: %s', error_message)
            //     return {}, error_message
            // 
            // slide_metadata = {'slide_type': 'youtube_video'}
            // youtube_values = response.get('items')[0]
            // youtube_duration = youtube_values.get('contentDetails', {}).get('duration')
            // if youtube_duration:
            //     parsed_duration = re.search(r'^PT(?:(\d+)H)?(?:(\d+)M)?(?:(\d+)S)?$', youtube_duration)
            //     if parsed_duration:
            //         slide_metadata['completion_time'] = (int(parsed_duration.group(1) or 0)) + \
            //                                             (int(parsed_duration.group(2) or 0) / 60) + \
            //                                             (round(int(parsed_duration.group(3) or 0) /60) / 60)
            // 
            // if youtube_values.get('snippet'):
            //     snippet = youtube_values['snippet']
            //     slide_metadata.update({
            //         'name': snippet['title'],
            //         'description': snippet['description'],
            //     })
            // 
            //     thumbnail_url = snippet['thumbnails']['high']['url']
            //     if image_url_only:
            //         slide_metadata['image_url'] = thumbnail_url
            //     else:
            //         slide_metadata['image_1920'] = base64.b64encode(
            //             requests.get(thumbnail_url, timeout=3).content
            //         )
            // 
            // return slide_metadata, None
            */
            return default;
        }

        public async Task<TEntity> FilterAddMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_partners, object raise_on_access) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _filter_add_members(self, target_partners, raise_on_access=False):
            // allowed = self.filtered(lambda channel: channel.enroll == 'public')
            // on_invite = self.filtered(lambda channel: channel.enroll == 'invite')
            // if on_invite:
            //     if on_invite.has_access('write'):
            //         allowed |= on_invite
            //     elif raise_on_access:
            //         raise AccessError(_('You are not allowed to add members to this course. Please contact the course responsible or an administrator.'))
            // return allowed
            */
            return default;
        }

        public async Task<TEntity> FilterCombinationsImpossibleByConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination_tuples, object ignore_no_variant) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _filter_combinations_impossible_by_config(self, combination_tuples, ignore_no_variant=False):
            // """ Filter combination_tuples according to the config of attributes on the template
            // 
            // :return: iterator over possible combinations
            // :rtype: generator
            // """
            // self.ensure_one()
            // attribute_lines = self.valid_product_template_attribute_line_ids
            // attribute_lines_active_values = attribute_lines.product_template_value_ids._only_active()
            // if ignore_no_variant:
            //     attribute_lines = attribute_lines._without_no_variant_attributes()
            // attribute_lines_without_multi = attribute_lines.filtered(
            //     lambda l: l.attribute_id.display_type != 'multi')
            // exclusions = self._get_own_attribute_exclusions()
            // for combination_tuple in combination_tuples:
            //     combination = self.env['product.template.attribute.value'].concat(*combination_tuple)
            //     combination_without_multi = combination.filtered(
            //         lambda l: l.attribute_line_id.attribute_id.display_type != 'multi')
            //     if len(combination_without_multi) != len(attribute_lines_without_multi):
            //         # number of attribute values passed is different than the
            //         # configuration of attributes on the template
            //         continue
            //     if attribute_lines_without_multi != combination_without_multi.attribute_line_id:
            //         # combination has different attributes than the ones configured on the template
            //         continue
            //     if not (attribute_lines_active_values >= combination):
            //         # combination has different values than the ones configured on the template
            //         continue
            //     if exclusions:
            //         # exclude if the current value is in an exclusion,
            //         # and the value excluding it is also in the combination
            //         combination_ids = set(combination.ids)
            //         combination_excluded_ids = set(itertools.chain(*[exclusions.get(ptav_id) for ptav_id in combination.ids]))
            //         if combination_ids & combination_excluded_ids:
            //             continue
            //     yield combination
            */
            return default;
        }

        public async Task<TEntity> FormatForFrontendInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
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

        public async Task<TEntity> GenerateSignedTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _generate_signed_token(self, partner_id):
            // """ Lazy generate the acces_token and return it signed by the given partner_id
            //     :rtype tuple (string, int)
            //     :return (signed_token, partner_id)
            // """
            // if not self.access_token:
            //     self.write({'access_token': self._default_access_token()})
            // return self._sign_token(partner_id)
            */
            return default;
        }

        public async Task<TEntity> GetAccessActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid, object force_website) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _get_access_action(self, access_uid=None, force_website=False):
            // """ Instead of the classic form view, redirect to website if it is published. """
            // self.ensure_one()
            // if force_website or self.website_published:
            //     return {
            //         'type': 'ir.actions.act_url',
            //         'url': '%s' % self.website_url,
            //         'target': 'self',
            //         'target_type': 'public',
            //         'res_id': self.id,
            //     }
            // return super(Slide, self)._get_access_action(access_uid=access_uid, force_website=force_website)
            */
            return default;
        }

        public async Task<TEntity> GetAttributeExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination, object parent_name, List<Guid> combination_ids) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_attribute_exclusions(
            //     self, parent_combination=None, parent_name=None, combination_ids=None
            // ):
            //     """Return the list of attribute exclusions of a product.
            // 
            //     :param parent_combination: the combination from which
            //         `self` is an optional or accessory product. Indeed exclusions
            //         rules on one product can concern another product.
            //     :type parent_combination: recordset `product.template.attribute.value`
            //     :param parent_name: the name of the parent product combination.
            //     :type parent_name: str
            //     :param list combination: The combination of the product, as a
            //         list of `product.template.attribute.value` ids.
            // 
            //     :return: dict of exclusions
            //         - exclusions: from this product itself
            //         - archived_combinations: list of archived combinations
            //         - parent_combination: ids of the given parent_combination
            //         - parent_exclusions: from the parent_combination
            //        - parent_product_name: the name of the parent product if any, used in the interface
            //            to explain why some combinations are not available.
            //            (e.g: Not available with Customizable Desk (Legs: Steel))
            //        - mapped_attribute_names: the name of every attribute values based on their id,
            //            used to explain in the interface why that combination is not available
            //            (e.g: Not available with Color: Black)
            //     """
            //     self.ensure_one()
            //     parent_combination = parent_combination or self.env['product.template.attribute.value']
            //     archived_products = self.with_context(active_test=False).product_variant_ids.filtered(lambda l: not l.active)
            //     active_combinations = set(tuple(product.product_template_attribute_value_ids.ids) for product in self.product_variant_ids)
            //     return {
            //         'exclusions': self._complete_inverse_exclusions(
            //             self._get_own_attribute_exclusions(combination_ids=combination_ids)
            //         ),
            //         'archived_combinations': list(set(
            //             tuple(product.product_template_attribute_value_ids.ids)
            //             for product in archived_products
            //             if product.product_template_attribute_value_ids and all(
            //                 ptav.ptav_active or combination_ids and ptav.id in combination_ids
            //                 for ptav in product.product_template_attribute_value_ids
            //             )
            //         ) - active_combinations),
            //         'parent_exclusions': self._get_parent_attribute_exclusions(parent_combination),
            //         'parent_combination': parent_combination.ids,
            //         'parent_product_name': parent_name,
            //         'mapped_attribute_names': self._get_mapped_attribute_names(parent_combination),
            //     }
            */
            return default;
        }

        public async Task<TEntity> GetAttributesExtraPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_attributes_extra_price(self):
            // self.ensure_one()
            // 
            // return sum(self.env.context.get('current_attributes_price_extra', []))
            */
            return default;
        }

        public async Task<TEntity> GetBackendMenuIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def get_backend_menu_id(self):
            // return self.env.ref('website_slides.website_slides_menu_root').id
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def get_backend_menu_id(self):
            // return self.env.ref('website_slides.website_slides_menu_root').id
            */
            return default;
        }

        public async Task<TEntity> GetBadgeUserStatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_badge.py) ---
            // def _get_badge_user_stats(self):
            // """Return stats related to badge users"""
            // first_month_day = date.today().replace(day=1)
            // 
            // for badge in self:
            //     owners = badge.owner_ids
            //     badge.stat_my = sum(o.user_id == self.env.user for o in owners)
            //     badge.stat_this_month = sum(o.create_date.date() >= first_month_day for o in owners)
            //     badge.stat_my_this_month = sum(
            //         o.user_id == self.env.user and o.create_date.date() >= first_month_day
            //         for o in owners
            //     )
            //     badge.stat_my_monthly_sending = sum(
            //         o.create_uid == self.env.user and o.create_date.date() >= first_month_day
            //         for o in owners
            //     )
            */
            return default;
        }

        public async Task<TEntity> GetCanPublishErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _get_can_publish_error_message(self):
            // return _("Publishing is restricted to the responsible of training courses or members of the publisher group for documentation courses")
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _get_can_publish_error_message(self):
            // return _("Publishing is restricted to the responsible of training courses or members of the publisher group for documentation courses")
            */
            return default;
        }

        public async Task<TEntity> GetCategorizedSlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_domain, object order, object force_void, object limit, object offset) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _get_categorized_slides(self, base_domain, order, force_void=True, limit=False, offset=False):
            // """ Return an ordered structure of slides by categories within a given
            // base_domain that must fulfill slides. As a course structure is based on
            // its slides sequences, uncategorized slides must have the lowest sequences.
            // 
            // Example
            //   * category 1 (sequence 1), category 2 (sequence 3)
            //   * slide 1 (sequence 0), slide 2 (sequence 2)
            //   * course structure is: slide 1, category 1, slide 2, category 2
            //     * slide 1 is uncategorized,
            //     * category 1 has one slide : Slide 2
            //     * category 2 is empty.
            // 
            // Backend and frontend ordering is the same, uncategorized first. It
            // eases resequencing based on DOM / displayed order, notably when
            // drag n drop is involved. """
            // self.ensure_one()
            // all_categories = self.env['slide.slide'].sudo().search([('channel_id', '=', self.id), ('is_category', '=', True)])
            // all_slides = self.env['slide.slide'].sudo().search(base_domain, order=order)
            // category_data = []
            // 
            // # Prepare all categories by natural order
            // for category in all_categories:
            //     category_slides = all_slides.filtered(lambda slide: slide.category_id == category)
            //     if not category_slides and not force_void:
            //         continue
            //     category_data.append({
            //         'category': category, 'id': category.id,
            //         'name': category.name, 'slug_name': self.env['ir.http']._slug(category),
            //         'total_slides': len(category_slides),
            //         'slides': category_slides[(offset or 0):(limit + offset or len(category_slides))],
            //     })
            // 
            // # Add uncategorized slides in first position
            // uncategorized_slides = all_slides.filtered(lambda slide: not slide.category_id)
            // if uncategorized_slides or force_void:
            //     category_data.insert(0, {
            //         'category': False, 'id': False,
            //         'name': _('Uncategorized'), 'slug_name': _('Uncategorized'),
            //         'total_slides': len(uncategorized_slides),
            //         'slides': uncategorized_slides[(offset or 0):(offset + limit or len(uncategorized_slides))],
            //     })
            // 
            // return category_data
            */
            return default;
        }

        public async Task<TEntity> GetChatbotLanguageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
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

        public async Task<TEntity> GetClosestPossibleCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_closest_possible_combination(self, combination):
            // """See `_get_closest_possible_combinations` (one iteration).
            // 
            // This method return the same result (empty recordset) if no
            // combination is possible at all which would be considered a negative
            // result, or if there are no attribute lines on the template in which
            // case the "empty combination" is actually a possible combination.
            // Therefore the result of this method when empty should be tested
            // with `_is_combination_possible` if it's important to know if the
            // resulting empty combination is actually possible or not.
            // """
            // return next(self._get_closest_possible_combinations(combination), self.env['product.template.attribute.value'])
            */
            return default;
        }

        public async Task<TEntity> GetClosestPossibleCombinationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_closest_possible_combinations(self, combination):
            // """Generator returning the possible combinations that are the closest to
            // the given combination.
            // 
            // If the given combination is incomplete, try to complete it.
            // 
            // If the given combination is invalid, try to remove values from it before
            // completing it.
            // 
            // :param combination: the values to include if they are possible
            // :type combination: recordset `product.template.attribute.value`
            // 
            // :return: the possible combinations that are including as much
            //     elements as possible from the given combination.
            // :rtype: generator of recordset of product.template.attribute.value
            // """
            // while True:
            //     res = self._get_possible_combinations(necessary_values=combination)
            //     try:
            //         # If there is at least one result for the given combination
            //         # we consider that combination set, and we yield all the
            //         # possible combinations for it.
            //         yield(next(res))
            //         for cur in res:
            //             yield(cur)
            //         return _("There are no remaining closest combination.")
            //     except StopIteration:
            //         # There are no results for the given combination, we try to
            //         # progressively remove values from it.
            //         if not combination:
            //             return _("There are no possible combination.")
            //         combination = combination[:-1]
            */
            return default;
        }

        public async Task<TEntity> GetCompletionTimePdfInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data_bytes) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _get_completion_time_pdf(self, data_bytes):
            // """ For PDFs, we assume that it takes 5 minutes to read a page.
            // This method receives the data of the PDF as bytes. """
            // 
            // if data_bytes.startswith(b'%PDF-'):
            //     try:
            //         pdf = PdfFileReader(io.BytesIO(data_bytes), overwriteWarnings=False)
            //         return (5 * len(pdf.pages)) / 60
            //     except Exception:
            //         pass  # as this is a nice to have, fail silently
            // 
            // return False
            */
            return default;
        }

        public async Task<TEntity> GetContextualPriceAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def get_contextual_price(self, product=None):
            // return self._get_contextual_price(product=product)
            */
            return default;
        }

        public async Task<TEntity> GetContextualPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_contextual_price(self, product=None):
            // self.ensure_one()
            // pricelist = self._get_contextual_pricelist()
            // quantity = self.env.context.get('quantity', 1.0)
            // uom = self.env['uom.uom'].browse(self.env.context.get('uom'))
            // date = self.env.context.get('date')
            // return pricelist._get_product_price(product or self, quantity, uom=uom, date=date)
            */
            return default;
        }

        public async Task<TEntity> GetContextualPricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_contextual_pricelist(self):
            // """ Get the contextual pricelist
            // 
            // This method is meant to be overriden in other standard modules.
            // """
            // return self.env['product.pricelist'].browse(self.env.context.get('pricelist'))
            */
            return default;
        }

        public async Task<TEntity> GetDefaultCategoryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_default_category_id(self):
            // # Deletion forbidden (at least through unlink)
            // return self.env.ref('product.product_category_all')
            */
            return default;
        }

        public async Task<TEntity> GetDefaultEnrollMsgInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _get_default_enroll_msg(self):
            // return _('Contact Responsible')
            */
            return default;
        }

        public async Task<TEntity> GetDefaultUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_default_uom_id(self):
            // # Deletion forbidden (at least through unlink)
            // return self.env.ref('uom.product_uom_unit')
            */
            return default;
        }

        public async Task<TEntity> GetDefaultWelcomeMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def _get_default_welcome_message(self):
            // return Markup("""
            //         <h2 class="display-3-fs" style="text-align: center;clear-both;font-weight: bold;">%(message_intro)s</h2>
            //         <div class="text-white">
            //             <p class="lead o_default_snippet_text" style="text-align: center;">%(message_post)s</p>
            //             <p style="text-align: center;">
            //                 <a class="btn btn-primary forum_register_url" href="/web/login">%(register_text)s</a>
            //                 <button type="button" class="btn btn-light js_close_intro" aria-label="Dismiss message">
            //                     %(hide_text)s
            //                 </button>
            //             </p>
            //         </div>
            //     """) % {
            //     'message_intro': _("Welcome!"),
            //     'message_post': _(
            //         "Share and discuss the best content and new marketing ideas, build your professional profile and become"
            //         " a better marketer together."
            //     ),
            //     'hide_text': _('Dismiss'),
            //     'register_text': _('Sign up'),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEarnedKarmaInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _get_earned_karma(self, partner_ids):
            // """ Compute the number of karma earned by partners on a channel
            // Warning: this count will not be accurate if the configuration has been
            // modified after the completion of a course!
            // """
            // total_karma = defaultdict(list)
            // 
            // slide_completed = self.env['slide.slide.partner'].sudo().search([
            //     ('partner_id', 'in', partner_ids),
            //     ('channel_id', 'in', self.ids),
            //     ('completed', '=', True),
            //     ('quiz_attempts_count', '>', 0)
            // ])
            // for partner_slide in slide_completed:
            //     slide = partner_slide.slide_id
            //     if not slide.question_ids:
            //         continue
            //     gains = [
            //         slide.quiz_first_attempt_reward,
            //         slide.quiz_second_attempt_reward,
            //         slide.quiz_third_attempt_reward,
            //         slide.quiz_fourth_attempt_reward,
            //     ]
            //     attempts = min(partner_slide.quiz_attempts_count, len(gains))
            //     total_karma[partner_slide.partner_id.id].append({
            //         'karma': gains[attempts - 1],
            //         'channel_id': slide.channel_id,
            //     })
            // 
            // channel_completed = self.env['slide.channel.partner'].sudo().search([
            //     ('partner_id', 'in', partner_ids),
            //     ('channel_id', 'in', self.ids),
            //     ('member_status', '=', 'completed')
            // ])
            // for partner_channel in channel_completed:
            //     channel = partner_channel.channel_id
            //     total_karma[partner_channel.partner_id.id].append({
            //         'karma': channel.karma_gen_channel_finish,
            //         'channel_id': channel,
            //     })
            // 
            // return total_karma
            */
            return default;
        }

        public async Task<TEntity> GetEmptyListHelpAsync<TEntity>(IEnumerable<TEntity> entities, object help_message) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def get_empty_list_help(self, help_message):
            // self = self.with_context(
            //     empty_list_help_document_name=_("product"),
            // )
            // return super(ProductTemplate, self).get_empty_list_help(help_message)
            */
            return default;
        }

        public async Task<TEntity> GetFirstPossibleCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination, object necessary_values) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_first_possible_combination(self, parent_combination=None, necessary_values=None):
            // """See `_get_possible_combinations` (one iteration).
            // 
            // This method return the same result (empty recordset) if no
            // combination is possible at all which would be considered a negative
            // result, or if there are no attribute lines on the template in which
            // case the "empty combination" is actually a possible combination.
            // Therefore the result of this method when empty should be tested
            // with `_is_combination_possible` if it's important to know if the
            // resulting empty combination is actually possible or not.
            // """
            // return next(self._get_possible_combinations(parent_combination, necessary_values), self.env['product.template.attribute.value'])
            */
            return default;
        }

        public async Task<TEntity> GetFirstPossibleVariantIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_first_possible_variant_id(self):
            // """See `_create_first_product_variant`. This method returns an ID
            // so it can be cached."""
            // self.ensure_one()
            // return self._create_first_product_variant().id
            */
            return default;
        }

        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Products'),
            //     'template': '/product/static/xls/product_template.xls'
            // }]
            */
            return default;
        }

        public async Task<TEntity> GetLengthUomIdFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_length_uom_id_from_ir_config_parameter(self):
            // """ Get the unit of measure to interpret the `length`, 'width', 'height' field.
            // By default, we considerer that length are expressed in millimeters. Users can configure
            // to express them in feet by adding an ir.config_parameter record with "product.volume_in_cubic_feet"
            // as key and "1" as value.
            // """
            // product_length_in_feet_param = self.env['ir.config_parameter'].sudo().get_param('product.volume_in_cubic_feet')
            // if product_length_in_feet_param == '1':
            //     return self.env.ref('uom.product_uom_foot')
            // else:
            //     return self.env.ref('uom.product_uom_millimeter')
            */
            return default;
        }

        public async Task<TEntity> GetLengthUomNameFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_length_uom_name_from_ir_config_parameter(self):
            // return self._get_length_uom_id_from_ir_config_parameter().display_name
            */
            return default;
        }

        public async Task<TEntity> GetListPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_list_price(self, price):
            // """ Get the product sales price from a public price based on taxes defined on the product.
            // To be overridden in accounting module."""
            // self.ensure_one()
            // return price
            */
            return default;
        }

        public async Task<TEntity> GetMappedAttributeNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_mapped_attribute_names(self, parent_combination=None):
            // """ The name of every attribute values based on their id,
            // used to explain in the interface why that combination is not available
            // (e.g: Not available with Color: Black).
            // 
            // It contains both attribute value names from this product and from
            // the parent combination if provided.
            // """
            // self.ensure_one()
            // all_product_attribute_values = self.valid_product_template_attribute_line_ids.product_template_value_ids
            // if parent_combination:
            //     all_product_attribute_values |= parent_combination
            // 
            // return {
            //     attribute_value.id: attribute_value.display_name
            //     for attribute_value in all_product_attribute_values
            // }
            */
            return default;
        }

        public async Task<TEntity> GetNextCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _get_next_category(self):
            // channel_category_ids = self.channel_id.slide_category_ids.ids
            // if not channel_category_ids:
            //     return self.env['slide.slide']
            // # If current slide is uncategorized and all the channel uncategorized slides are completed, return the first category
            // if not self.category_id and all(self.channel_id.slide_ids.filtered(
            //     lambda s: not s.is_category and not s.category_id).mapped('user_has_completed')):
            //     return self.env['slide.slide'].browse(channel_category_ids[0])
            // # If current category is completed and current category is not the last one, get next category
            // elif self.user_has_completed_category and self.category_id.id in channel_category_ids and self.category_id.id != channel_category_ids[-1]:
            //     index_current_category = channel_category_ids.index(self.category_id.id)
            //     return self.env['slide.slide'].browse(channel_category_ids[index_current_category+1])
            // return self.env['slide.slide']
            */
            return default;
        }

        public async Task<TEntity> GetOwnAttributeExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> combination_ids) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_own_attribute_exclusions(self, combination_ids=None):
            // """Get exclusions coming from the current template.
            // 
            // :param list combination: The combination of the product, as a
            //     list of `product.template.attribute.value` ids.
            // Dictionnary, each product template attribute value is a key, and for each of them
            // the value is an array with the other ptav that they exclude (empty if no exclusion).
            // """
            // self.ensure_one()
            // product_template_attribute_values = self.valid_product_template_attribute_line_ids.product_template_value_ids
            // return {
            //     ptav.id: [
            //         value.id
            //         for filter_line in ptav.exclude_for.filtered(
            //             lambda filter_line: filter_line.product_tmpl_id == self
            //         ) for value in filter_line.value_ids if value.ptav_active
            //     ]
            //     for ptav in product_template_attribute_values if (
            //         ptav.ptav_active or combination_ids and ptav.id in combination_ids
            //     )
            // }
            */
            return default;
        }

        public async Task<TEntity> GetOwnersInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_badge.py) ---
            // def _get_owners_info(self):
            // """Return:
            //     the list of unique res.users ids having received this badge
            //     the total number of time this badge was granted
            //     the total number of users this badge was granted to
            // """
            // defaults = {
            //     'granted_count': 0,
            //     'granted_users_count': 0,
            //     'unique_owner_ids': [],
            // }
            // if not self.ids:
            //     self.update(defaults)
            //     return
            // 
            // Users = self.env["res.users"]
            // query = Users._where_calc([])
            // Users._apply_ir_rules(query)
            // badge_alias = query.join("res_users", "id", "gamification_badge_user", "user_id", "badges")
            // 
            // rows = self.env.execute_query(SQL(
            //     """
            //       SELECT %(badge_alias)s.badge_id, count(res_users.id) as stat_count,
            //              count(distinct(res_users.id)) as stat_count_distinct,
            //              array_agg(distinct(res_users.id)) as unique_owner_ids
            //         FROM %(from_clause)s
            //        WHERE %(where_clause)s
            //          AND %(badge_alias)s.badge_id IN %(ids)s
            //     GROUP BY %(badge_alias)s.badge_id
            //     """,
            //     from_clause=query.from_clause,
            //     where_clause=query.where_clause or SQL("TRUE"),
            //     badge_alias=SQL.identifier(badge_alias),
            //     ids=tuple(self.ids),
            // ))
            // 
            // mapping = {
            //     badge_id: {
            //         'granted_count': count,
            //         'granted_users_count': distinct_count,
            //         'unique_owner_ids': owner_ids,
            //     }
            //     for (badge_id, count, distinct_count, owner_ids) in rows
            // }
            // for badge in self:
            //     badge.update(mapping.get(badge.id, defaults))
            */
            return default;
        }

        public async Task<TEntity> GetParentAttributeExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_parent_attribute_exclusions(self, parent_combination):
            // """Get exclusions coming from the parent combination.
            // 
            // Dictionnary, each parent's ptav is a key, and for each of them the value is
            // an array with the other ptav that are excluded because of the parent.
            // """
            // self.ensure_one()
            // if not parent_combination:
            //     return {}
            // 
            // result = {}
            // for product_attribute_value in parent_combination:
            //     for filter_line in product_attribute_value.exclude_for.filtered(
            //         lambda filter_line: filter_line.product_tmpl_id == self
            //     ):
            //         # Some exclusions don't have attribute value. This means that the template is not
            //         # compatible with the parent combination. If such an exclusion is found, it means that all
            //         # attribute values are excluded.
            //         if filter_line.value_ids:
            //             result[product_attribute_value.id] = filter_line.value_ids.ids
            //         else:
            //             result[product_attribute_value.id] = filter_line.product_tmpl_id.mapped('attribute_line_ids.product_template_value_ids').ids
            // 
            // return result
            */
            return default;
        }

        public async Task<TEntity> GetPlaceholderFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_placeholder_filename(self, field):
            // image_fields = ['image_%s' % size for size in [1920, 1024, 512, 256, 128]]
            // if field in image_fields:
            //     return 'product/static/img/placeholder_thumbnail.png'
            // return super()._get_placeholder_filename(field)
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _get_placeholder_filename(self, field):
            // image_fields = ['image_%s' % size for size in [1920, 1024, 512, 256, 128]]
            // if field in image_fields:
            //     return self.website_default_background_image_url
            // return super()._get_placeholder_filename(field)
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _get_placeholder_filename(self, field):
            // return self.channel_id._get_placeholder_filename(field)
            */
            return default;
        }

        public async Task<TEntity> GetPossibleCombinationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination, object necessary_values) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_possible_combinations(self, parent_combination=None, necessary_values=None):
            // """Generator returning combinations that are possible, following the
            // sequence of attributes and values.
            // 
            // See `_is_combination_possible` for what is a possible combination.
            // 
            // When encountering an impossible combination, try to change the value
            // of attributes by starting with the further regarding their sequences.
            // 
            // Ignore attributes that have no values.
            // 
            // :param parent_combination: combination from which `self` is an
            //     optional or accessory product.
            // :type parent_combination: recordset `product.template.attribute.value`
            // 
            // :param necessary_values: values that must be in the returned combination
            // :type necessary_values: recordset of `product.template.attribute.value`
            // 
            // :return: the possible combinations
            // :rtype: generator of recordset of `product.template.attribute.value`
            // """
            // self.ensure_one()
            // 
            // if not self.active:
            //     return _("The product template is archived so no combination is possible.")
            // 
            // necessary_values = necessary_values or self.env['product.template.attribute.value']
            // necessary_attribute_lines = necessary_values.mapped('attribute_line_id')
            // attribute_lines = self.valid_product_template_attribute_line_ids.filtered(
            //     lambda ptal: ptal not in necessary_attribute_lines)
            // 
            // if not attribute_lines and self._is_combination_possible(necessary_values, parent_combination):
            //     yield necessary_values
            // 
            // product_template_attribute_values_per_line = []
            // for ptal in attribute_lines:
            //     if ptal.attribute_id.display_type != 'multi':
            //         values_to_add = ptal.product_template_value_ids._only_active()
            //     else:
            //         values_to_add = self.env['product.template.attribute.value']
            //     product_template_attribute_values_per_line.append(values_to_add)
            // 
            // for partial_combination in self._cartesian_product(product_template_attribute_values_per_line, parent_combination):
            //     combination = partial_combination + necessary_values
            //     if self._is_combination_possible(combination, parent_combination):
            //         yield combination
            // 
            // return _("There are no remaining possible combination.")
            */
            return default;
        }

        public async Task<TEntity> GetPossibleVariantsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_possible_variants(self, parent_combination=None):
            // """Return the existing variants that are possible.
            // 
            // For dynamic attributes, it will only return the variants that have been
            // created already.
            // 
            // If there are a lot of variants, this method might be slow. Even if there
            // aren't too many variants, for performance reasons, do not call this
            // method in a loop over the product templates.
            // 
            // Therefore this method has a very restricted reasonable use case and you
            // should strongly consider doing things differently if you consider using
            // this method.
            // 
            // :param parent_combination: combination from which `self` is an
            //     optional or accessory product.
            // :type parent_combination: recordset `product.template.attribute.value`
            // 
            // :return: the existing variants that are possible.
            // :rtype: recordset of `product.product`
            // """
            // self.ensure_one()
            // return self.product_variant_ids.filtered(lambda p: p._is_variant_possible(parent_combination))
            */
            return default;
        }

        public async Task<TEntity> GetProductDocumentDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_product_document_domain(self):
            // self.ensure_one()
            // return expression.OR([
            //     expression.AND([[('res_model', '=', 'product.template')], [('res_id', '=', self.id)]]),
            //     expression.AND([
            //         [('res_model', '=', 'product.product')],
            //         [('res_id', 'in', self.product_variant_ids.ids)],
            //     ])
            // ])
            */
            return default;
        }

        public async Task<TEntity> GetProductPriceContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_product_price_context(self, combination):
            // self.ensure_one()
            // res = {}
            // 
            // current_attributes_price_extra = [
            //     ptav.price_extra for ptav in combination.filtered(
            //         lambda ptav:
            //             ptav.price_extra
            //             and ptav.product_tmpl_id == self
            //     )
            // ]
            // if current_attributes_price_extra:
            //     res['current_attributes_price_extra'] = tuple(current_attributes_price_extra)
            // 
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetRelatedFieldsVariantTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_related_fields_variant_template(self):
            // """ Return a list of fields present on template and variants models and that are related"""
            // return ['barcode', 'default_code', 'standard_price', 'volume', 'weight', 'packaging_ids', 'product_properties']
            */
            return default;
        }

        public async Task<TEntity> GetSingleProductVariantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def get_single_product_variant(self):
            // """ Method used by the product configurator to check if the product is configurable or not.
            // 
            // We need to open the product configurator if the product:
            // - is configurable (see has_configurable_attributes)
            // - has optional products (method is extended in sale to return optional products info)
            // 
            // Note: self.ensure_one()
            // """
            // self.ensure_one()
            // if self.product_variant_count == 1 and not self.has_configurable_attributes:
            //     return {
            //         'product_id': self.product_variant_id.id,
            //         'product_name': self.product_variant_id.display_name,
            //     }
            // return {}
            */
            return default;
        }

        public async Task<TEntity> GetTagsFirstCharInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tags) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def _get_tags_first_char(self, tags=None):
            // """Get set of first letter of forum tags.
            // 
            // :param tags: tags recordset to further filter forum's tags that are also in these tags.
            // """
            // tag_ids = self.tag_ids if tags is None else (self.tag_ids & tags)
            // return sorted({tag.name[0].upper() for tag in tag_ids if len(tag.name)})
            */
            return default;
        }

        public async Task<TEntity> GetVariantForCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_variant_for_combination(self, combination):
            // """Get the variant matching the combination.
            // 
            // All of the values in combination must be present in the variant, and the
            // variant should not have more attributes. Ignore the attributes that are
            // not supposed to create variants.
            // 
            // :param combination: recordset of `product.template.attribute.value`
            // 
            // :return: the variant if found, else empty
            // :rtype: recordset `product.product`
            // """
            // self.ensure_one()
            // filtered_combination = combination._without_no_variant_attributes()
            // return self.env['product.product'].browse(self._get_variant_id_for_combination(filtered_combination))
            */
            return default;
        }

        public async Task<TEntity> GetVariantIdForCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object filtered_combination) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_variant_id_for_combination(self, filtered_combination):
            // """See `_get_variant_for_combination`. This method returns an ID
            // so it can be cached.
            // 
            // Use sudo because the same result should be cached for all users.
            // """
            // self.ensure_one()
            // domain = [('product_tmpl_id', '=', self.id)]
            // combination_indices_ids = filtered_combination._ids2str()
            // 
            // if combination_indices_ids:
            //     domain = expression.AND([domain, [('combination_indices', '=', combination_indices_ids)]])
            // else:
            //     domain = expression.AND([domain, [('combination_indices', 'in', ['', False])]])
            // 
            // return self.env['product.product'].sudo().with_context(active_test=False).search(domain, order='active DESC', limit=1).id
            */
            return default;
        }

        public async Task<TEntity> GetVolumeUomIdFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_volume_uom_id_from_ir_config_parameter(self):
            // """ Get the unit of measure to interpret the `volume` field. By default, we consider
            // that volumes are expressed in cubic meters. Users can configure to express them in cubic feet
            // by adding an ir.config_parameter record with "product.volume_in_cubic_feet" as key
            // and "1" as value.
            // """
            // product_length_in_feet_param = self.env['ir.config_parameter'].sudo().get_param('product.volume_in_cubic_feet')
            // if product_length_in_feet_param == '1':
            //     return self.env.ref('uom.product_uom_cubic_foot')
            // else:
            //     return self.env.ref('uom.product_uom_cubic_meter')
            */
            return default;
        }

        public async Task<TEntity> GetVolumeUomNameFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_volume_uom_name_from_ir_config_parameter(self):
            // return self._get_volume_uom_id_from_ir_config_parameter().display_name
            */
            return default;
        }

        public async Task<TEntity> GetWeightUomIdFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_weight_uom_id_from_ir_config_parameter(self):
            // """ Get the unit of measure to interpret the `weight` field. By default, we considerer
            // that weights are expressed in kilograms. Users can configure to express them in pounds
            // by adding an ir.config_parameter record with "product.product_weight_in_lbs" as key
            // and "1" as value.
            // """
            // product_weight_in_lbs_param = self.env['ir.config_parameter'].sudo().get_param('product.weight_in_lbs')
            // if product_weight_in_lbs_param == '1':
            //     return self.env.ref('uom.product_uom_lb')
            // else:
            //     return self.env.ref('uom.product_uom_kgm')
            */
            return default;
        }

        public async Task<TEntity> GetWeightUomNameFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_weight_uom_name_from_ir_config_parameter(self):
            // return self._get_weight_uom_id_from_ir_config_parameter().display_name
            */
            return default;
        }

        public async Task<TEntity> GetWelcomeStepsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
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

        public async Task<TEntity> GoToWebsiteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def go_to_website(self):
            // self.ensure_one()
            // website_url = self._compute_website_url()
            // if not website_url:
            //     return False
            // return self.env['website'].get_client_action(self._compute_website_url())
            */
            return default;
        }

        public async Task<TEntity> HasDynamicAttributesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def has_dynamic_attributes(self):
            // """Return whether this `product.template` has at least one dynamic
            // attribute.
            // 
            // :return: True if at least one dynamic attribute, False otherwise
            // :rtype: bool
            // """
            // self.ensure_one()
            // return any(a.create_variant == 'dynamic' for a in self.valid_product_template_attribute_line_ids.attribute_id)
            */
            return default;
        }

        public async Task<TEntity> InitColumnInternalAsync<TEntity>(IEnumerable<TEntity> entities, object column_name) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _init_column(self, column_name):
            // """ Initialize the value of the given column for existing rows.
            //     Overridden here because we need to generate different access tokens
            //     and by default _init_column calls the default method once and applies
            //     it for every record.
            // """
            // if column_name != 'access_token':
            //     super(Channel, self)._init_column(column_name)
            // else:
            //     query = """
            //         UPDATE %(table_name)s
            //         SET access_token = md5(md5(random()::varchar || id::varchar) || clock_timestamp()::varchar)::uuid::varchar
            //         WHERE access_token IS NULL
            //     """ % {'table_name': self._table}
            //     self.env.cr.execute(query)
            */
            return default;
        }

        public async Task<TEntity> InverseIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py) ---
            // def _inverse_is_favorite(self):
            // """ Handled in the write() """
            // return
            */
            return default;
        }

        public async Task<TEntity> IsCombinationPossibleByConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, object ignore_no_variant) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _is_combination_possible_by_config(self, combination, ignore_no_variant=False):
            // """Return whether the given combination is possible according to the config of attributes on the template
            // 
            // :param combination: the combination to check for possibility
            // :type combination: recordset `product.template.attribute.value`
            // 
            // :param ignore_no_variant: whether no_variant attributes should be ignored
            // :type ignore_no_variant: bool
            // 
            // :return: wether the given combination is possible according to the config of attributes on the template
            // :rtype: bool
            // """
            // self.ensure_one()
            // # Returns False on StopIteration. Empty combination should return True.
            // return isinstance(next(self._filter_combinations_impossible_by_config([combination], ignore_no_variant), False), models.BaseModel)
            */
            return default;
        }

        public async Task<TEntity> IsCombinationPossibleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, object parent_combination, object ignore_no_variant) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _is_combination_possible(self, combination, parent_combination=None, ignore_no_variant=False):
            // """
            // The combination is possible if it is not excluded by any rule
            // coming from the current template, not excluded by any rule from the
            // parent_combination (if given), and there should not be any archived
            // variant with the exact same combination.
            // 
            // If the template does not have any dynamic attribute, the combination
            // is also not possible if the matching variant has been deleted.
            // 
            // Moreover the attributes of the combination must excatly match the
            // attributes allowed on the template.
            // 
            // :param combination: the combination to check for possibility
            // :type combination: recordset `product.template.attribute.value`
            // 
            // :param ignore_no_variant: whether no_variant attributes should be ignored
            // :type ignore_no_variant: bool
            // 
            // :param parent_combination: combination from which `self` is an
            //     optional or accessory product.
            // :type parent_combination: recordset `product.template.attribute.value`
            // 
            // :return: whether the combination is possible
            // :rtype: bool
            // """
            // self.ensure_one()
            // 
            // if not self._is_combination_possible_by_config(combination, ignore_no_variant):
            //     return False
            // 
            // variant = self._get_variant_for_combination(combination)
            // 
            // if self.has_dynamic_attributes():
            //     if variant and not variant.active:
            //         # dynamic and the variant has been archived
            //         return False
            // else:
            //     if not variant or not variant.active:
            //         # not dynamic, the variant has been archived or deleted
            //         return False
            // 
            // parent_exclusions = self._get_parent_attribute_exclusions(parent_combination)
            // if parent_exclusions:
            //     # parent_exclusion are mapped by ptav but here we don't need to know
            //     # where the exclusion comes from so we loop directly on the dict values
            //     for exclusions_values in parent_exclusions.values():
            //         for exclusion in exclusions_values:
            //             if exclusion in combination.ids:
            //                 return False
            // 
            // return True
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnerFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _mail_get_partner_fields(self, introspect_fields=False):
            // return []
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _mail_get_partner_fields(self, introspect_fields=False):
            // return []
            */
            return default;
        }

        public async Task<TEntity> MessagePostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def message_post(self, *, parent_id=False, subtype_id=False, **kwargs):
            // """ Temporary workaround to avoid spam. If someone replies on a channel
            // through the 'Presentation Published' email, it should be considered as a
            // note as we don't want all channel followers to be notified of this answer.
            // Also make sure that only one review can be posted per course."""
            // self.ensure_one()
            // if kwargs.get('message_type') == 'comment' and not self.can_review:
            //     raise AccessError(_('Not enough karma to review'))
            // if parent_id:
            //     parent_message = self.env['mail.message'].sudo().browse(parent_id)
            //     if parent_message.subtype_id and parent_message.subtype_id == self.env.ref('website_slides.mt_channel_slide_published'):
            //         subtype_id = self.env.ref('mail.mt_note').id
            // message = super().message_post(parent_id=parent_id, subtype_id=subtype_id, **kwargs)
            // if self.env.user._is_internal() and not message.rating_value:
            //     return message
            // if message.subtype_id == self.env.ref("mail.mt_comment"):
            //     domain = [
            //         ("res_id", "=", self.id),
            //         ("author_id", "=", message.author_id.id),
            //         ("model", "=", "slide.channel"),
            //         ("subtype_id", "=", self.env.ref("mail.mt_comment").id),
            //     ]
            //     if self.env["mail.message"].search_count(domain, limit=2) > 1:
            //         raise ValidationError(_("Only a single review can be posted per course."))
            // if message.rating_value and message.is_current_user_or_guest_author:
            //     self.env.user._add_karma(self.karma_gen_channel_rank, self, _("Course Ranked"))
            // return message
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def message_post(self, *, message_type='notification', **kwargs):
            // self.ensure_one()
            // if message_type == 'comment' and not self.channel_id.can_comment:  # user comments have a restriction on karma
            //     raise AccessError(_('Not enough karma to comment'))
            // return super(Slide, self).message_post(message_type=message_type, **kwargs)
            */
            return default;
        }

        public async Task<TEntity> MoveCategorySlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object category, object new_category) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _move_category_slides(self, category, new_category):
            // if not category.slide_ids:
            //     return
            // truncated_slide_ids = [slide_id for slide_id in self.slide_ids.ids if slide_id not in category.slide_ids.ids]
            // if new_category:
            //     place_idx = truncated_slide_ids.index(new_category.id)
            //     ordered_slide_ids = truncated_slide_ids[:place_idx] + category.slide_ids.ids + truncated_slide_ids[place_idx]
            // else:
            //     ordered_slide_ids = category.slide_ids.ids + truncated_slide_ids
            // for index, slide_id in enumerate(ordered_slide_ids):
            //     self.env['slide.slide'].browse([slide_id]).sequence = index + 1
            */
            return default;
        }

        public async Task<TEntity> NameSearchAsync<TEntity>(IEnumerable<TEntity> entities, object name, object args, object @operator, object limit) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def name_search(self, name='', args=None, operator='ilike', limit=100):
            // # Only use the product.product heuristics if there is a search term and the domain
            // # does not specify a match on `product.template` IDs.
            // self_obj = self
            // if 'search_product_product' not in self.env.context and any(term[0] == 'id' for term in (args or [])):
            //     self_obj = self_obj.with_context(search_product_product=False)
            // return super(ProductTemplate, self_obj).name_search(name, args, operator, limit)
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=None):
            // """ Add access button to everyone if the document is active. """
            // groups = super()._notify_get_recipients_groups(
            //     message, model_description, msg_vals=msg_vals
            // )
            // if not self:
            //     return groups
            // 
            // self.ensure_one()
            // if self.website_published:
            //     for _group_name, _group_method, group_data in groups:
            //         group_data['has_button_access'] = True
            // 
            // return groups
            */
            return default;
        }

        public async Task<TEntity> OnChangeDocumentBinaryContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _on_change_document_binary_content(self):
            // if self.slide_category == 'document' and self.source_type == 'local_file' and self.document_binary_content:
            //     completion_time = self._get_completion_time_pdf(base64.b64decode(self.document_binary_content))
            //     if completion_time:
            //         self.completion_time = completion_time
            */
            return default;
        }

        public async Task<TEntity> OnChangeSlideCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _on_change_slide_category(self):
            // """ Prevents mis-match when ones uploads an image and then a pdf without saving the form. """
            // if self.slide_category != 'infographic' and self.image_binary_content:
            //     self.image_binary_content = False
            // elif self.slide_category != 'document' and self.document_binary_content:
            //     self.document_binary_content = False
            */
            return default;
        }

        public async Task<TEntity> OnChangeUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _on_change_url(self):
            // """ Keeping a 'onchange' because we want this behavior for the frontend.
            // Changing the document / video external URL will populate some metadata on the form view.
            // We only populate the field that are empty to avoid overriding user assigned values.
            // The slide metadata are also fetched in create / write overrides to ensure consistency. """
            // 
            // self.ensure_one()
            // if self.url or self.document_google_url or self.image_google_url or self.video_url:
            //     slide_metadata, _error = self._fetch_external_metadata()
            //     if slide_metadata:
            //         self.update({
            //             key: value
            //             for key, value in slide_metadata.items()
            //             if not self[key]
            //         })
            */
            return default;
        }

        public async Task<TEntity> OnchangeDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _onchange_default_code(self):
            // if not self.default_code:
            //     return
            // 
            // domain = [('default_code', '=', self.default_code)]
            // if self.id.origin:
            //     domain.append(('id', '!=', self.id.origin))
            // 
            // if self.env['product.template'].search_count(domain, limit=1):
            //     return {'warning': {
            //         'title': _("Note:"),
            //         'message': _("The Internal Reference '%s' already exists.", self.default_code),
            //     }}
            */
            return default;
        }

        public async Task<TEntity> OnchangeScriptStepIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
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

        public async Task<TEntity> OnchangeTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _onchange_type(self):
            // if self.type == 'combo':
            //     if self.attribute_line_ids:
            //         raise UserError(_("Combo products can't have attributes."))
            //     combo_items = self.env['product.combo.item'].sudo().search([
            //         ('product_id', 'in', self.product_variant_ids.ids)
            //     ])
            //     if combo_items:
            //         raise UserError(_(
            //             "This product is part of a combo, so its type can't be changed to \"combo\"."
            //         ))
            //     self.purchase_ok = False
            // return {}
            */
            return default;
        }

        public async Task<TEntity> OnchangeUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _onchange_uom_id(self):
            // if self.uom_id:
            //     self.uom_po_id = self.uom_id.id
            */
            return default;
        }

        public async Task<TEntity> OnchangeVideoUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_image.py) ---
            // def _onchange_video_url(self):
            // if not self.image_1920:
            //     thumbnail = get_video_thumbnail(self.video_url)
            //     self.image_1920 = thumbnail and base64.b64encode(thumbnail) or False
            */
            return default;
        }

        public async Task<TEntity> OpenPricelistRulesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def open_pricelist_rules(self):
            // self.ensure_one()
            // domain = ['|',
            //     ('product_tmpl_id', '=', self.id),
            //     ('product_id', 'in', self.product_variant_ids.ids),
            //     ('compute_price', '=', 'fixed'),
            // ]
            // return {
            //     'name': _('Price Rules'),
            //     'view_mode': 'list,form',
            //     'views': [(self.env.ref('product.product_pricelist_item_tree_view_from_product').id, 'list')],
            //     'res_model': 'product.pricelist.item',
            //     'type': 'ir.actions.act_window',
            //     'target': 'current',
            //     'domain': domain,
            //     'context': {
            //         'default_product_tmpl_id': self.id,
            //         'default_applied_on': '1_product',
            //         'product_without_variants': self.product_variant_count == 1,
            //         'search_default_visible': True,
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> OpenWebsiteUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def open_website_url(self):
            // """ Overridden to use a relative URL instead of an absolute when website_id is False. """
            // if self.website_id:
            //     return super().open_website_url()
            // return self.env['website'].get_client_action(f'/slides/{self.env["ir.http"]._slug(self)}')
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def open_website_url(self):
            // """ Overridden to use a relative URL instead of an absolute when website_id is False. """
            // if self.website_id:
            //     return super().open_website_url()
            // return self.env['website'].get_client_action(f'/slides/slide/{self.env["ir.http"]._slug(self)}')
            */
            return default;
        }

        public async Task<TEntity> PostPublicationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _post_publication(self):
            // for slide in self.filtered(lambda slide: slide.website_published and slide.channel_id.publish_template_id):
            //     publish_template = slide.channel_id.publish_template_id
            //     html_body = publish_template.with_context(base_url=slide.get_base_url())._render_field('body_html', slide.ids)[slide.id]
            //     subject = publish_template._render_field('subject', slide.ids)[slide.id]
            //     # We want to use the 'reply_to' of the template if set. However, `mail.message` will check
            //     # if the key 'reply_to' is in the kwargs before calling _get_reply_to. If the value is
            //     # falsy, we don't include it in the 'message_post' call.
            //     kwargs = {}
            //     reply_to = publish_template._render_field('reply_to', slide.ids)[slide.id]
            //     if reply_to:
            //         kwargs['reply_to'] = reply_to
            //     slide.channel_id.with_context(mail_create_nosubscribe=True).message_post(
            //         subject=subject,
            //         body=html_body,
            //         subtype_xmlid='website_slides.mt_channel_slide_published',
            //         email_layout_xmlid='mail.mail_notification_light',
            //         **kwargs,
            //     )
            // return True
            */
            return default;
        }

        public async Task<TEntity> PostWelcomeStepsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object discuss_channel) where TEntity : IEntity<Guid>, IImageMixinable
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

        public async Task<TEntity> PrepareTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _prepare_tooltip(self):
            // self.ensure_one()
            // tooltip = ""
            // if self.type == 'combo':
            //     tooltip = _(
            //         "Combos allow to choose one product amongst a selection of choices per category."
            //     )
            // return tooltip
            */
            return default;
        }

        public async Task<TEntity> PrepareVariantValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _prepare_variant_values(self, combination):
            // self.ensure_one()
            // return {
            //     'product_tmpl_id': self.id,
            //     'product_template_attribute_value_ids': [(6, 0, combination.ids)],
            //     'active': self.active
            // }
            */
            return default;
        }

        public async Task<TEntity> PriceComputeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price_type, object uom, object currency, object company, object date) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _price_compute(self, price_type, uom=None, currency=None, company=None, date=False):
            // company = company or self.env.company
            // date = date or fields.Date.context_today(self)
            // 
            // self = self.with_company(company)
            // if price_type == 'standard_price':
            //     # standard_price field can only be seen by users in base.group_user
            //     # Thus, in order to compute the sale price from the cost for users not in this group
            //     # We fetch the standard price as the superuser
            //     self = self.sudo()
            // 
            // prices = dict.fromkeys(self.ids, 0.0)
            // for template in self:
            //     price = template[price_type] or 0.0
            //     price_currency = template.currency_id
            //     if price_type == 'standard_price':
            //         if not price and template.product_variant_ids:
            //             price = template.product_variant_ids[0].standard_price
            //         price_currency = template.cost_currency_id
            //     elif price_type == 'list_price':
            //         price += template._get_attributes_extra_price()
            // 
            //     if uom:
            //         price = template.uom_id._compute_price(price, uom)
            // 
            //     # Convert from current user company currency to asked one
            //     # This is right cause a field cannot be in more than one currency
            //     if currency:
            //         price = price_currency._convert(price, currency, company, date)
            // 
            //     prices[template.id] = price
            // return prices
            */
            return default;
        }

        public async Task<TEntity> RatingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _rating_domain(self):
            // """ Only take the published rating into account to compute avg and count """
            // domain = super(Channel, self)._rating_domain()
            // return expression.AND([domain, [('is_internal', '=', False)]])
            */
            return default;
        }

        public async Task<TEntity> ReadGroupCategIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object categories, object domain) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _read_group_categ_id(self, categories, domain):
            // category_ids = self.env.context.get('default_categ_id')
            // if not category_ids and self.env.context.get('group_expand'):
            //     category_ids = categories.sudo()._search([], order=categories._order)
            // return categories.browse(category_ids)
            */
            return default;
        }

        public async Task<TEntity> RemainingSendingCalcInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_badge.py) ---
            // def _remaining_sending_calc(self):
            // """Computes the number of badges remaining the user can send
            // 
            // 0 if not allowed or no remaining
            // integer if limited sending
            // -1 if infinite (should not be displayed)
            // """
            // for badge in self:
            //     if badge._can_grant_badge() != self.CAN_GRANT:
            //         # if the user cannot grant this badge at all, result is 0
            //         badge.remaining_sending = 0
            //     elif not badge.rule_max:
            //         # if there is no limitation, -1 is returned which means 'infinite'
            //         badge.remaining_sending = -1
            //     else:
            //         badge.remaining_sending = badge.rule_max_number - badge.stat_my_monthly_sending
            */
            return default;
        }

        public async Task<TEntity> RemoveMembershipInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _remove_membership(self, partner_ids):
            // """ Karma earned during course progress is kept upon membership removal.
            // This is done because re-joining the course will not allow you to gain the karma again,
            // as we keep your progress """
            // if not partner_ids:
            //     raise ValueError("Do not use this method with an empty partner_id recordset")
            // 
            // removed_channel_partner_domain = expression.OR([
            //     [('partner_id', 'in', partner_ids),
            //      ('channel_id', '=', channel.id)]
            //     for channel in self
            // ])
            // 
            // self.message_unsubscribe(partner_ids=partner_ids)
            // if self:
            //     removed_channel_partner = self.env['slide.channel.partner'].sudo().search(removed_channel_partner_domain)
            //     if removed_channel_partner:
            //         removed_channel_partner.action_archive()
            */
            return default;
        }

        public async Task<TEntity> ResequenceSlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slide, object force_category) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _resequence_slides(self, slide, force_category=False):
            // ids_to_resequence = self.slide_ids.ids
            // index_of_added_slide = ids_to_resequence.index(slide.id)
            // next_category_id = None
            // if self.slide_category_ids:
            //     force_category_id = force_category.id if force_category else slide.category_id.id
            //     index_of_category = self.slide_category_ids.ids.index(force_category_id) if force_category_id else None
            //     if index_of_category is None:
            //         next_category_id = self.slide_category_ids.ids[0]
            //     elif index_of_category < len(self.slide_category_ids.ids) - 1:
            //         next_category_id = self.slide_category_ids.ids[index_of_category + 1]
            // 
            // if next_category_id:
            //     added_slide_id = ids_to_resequence.pop(index_of_added_slide)
            //     index_of_next_category = ids_to_resequence.index(next_category_id)
            //     ids_to_resequence.insert(index_of_next_category, added_slide_id)
            //     for i, record in enumerate(self.env['slide.slide'].browse(ids_to_resequence)):
            //         record.write({'sequence': i + 1})  # start at 1 to make people scream
            // else:
            //     slide.write({
            //         'sequence': self.env['slide.slide'].browse(ids_to_resequence[-1]).sequence + 1
            //     })
            */
            return default;
        }

        public async Task<TEntity> SearchBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _search_barcode(self, operator, value):
            // subquery = self.with_context(active_test=False)._search([
            //     ('product_variant_ids.barcode', operator, value),
            // ])
            // return [('id', 'in', subquery)]
            */
            return default;
        }

        public async Task<TEntity> SearchDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _search_display_name(self, operator, value):
            // domain = super()._search_display_name(operator, value)
            // if self.env.context.get('search_product_product', bool(value)):
            //     combine = expression.OR if operator not in expression.NEGATIVE_TERM_OPERATORS else expression.AND
            //     domain = combine([domain, [('product_variant_ids', operator, value)]])
            // return domain
            */
            return default;
        }

        public async Task<TEntity> SearchGetDetailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website, object order, object options) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def _search_get_detail(self, website, order, options):
            // with_description = options['displayDescription']
            // search_fields = ['name']
            // fetch_fields = ['id', 'name']
            // mapping = {
            //     'name': {'name': 'name', 'type': 'text', 'match': True},
            //     'website_url': {'name': 'website_url', 'type': 'text', 'truncate': False},
            // }
            // if with_description:
            //     search_fields.append('description')
            //     fetch_fields.append('description')
            //     mapping['description'] = {'name': 'description', 'type': 'text', 'match': True}
            // return {
            //     'model': 'forum.forum',
            //     'base_domain': [website.website_domain()],
            //     'search_fields': search_fields,
            //     'fetch_fields': fetch_fields,
            //     'mapping': mapping,
            //     'icon': 'fa-comments-o',
            //     'order': 'name desc, id desc' if 'name desc' in order else 'name asc, id desc',
            // }
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py) ---
            // def _search_get_detail(self, website, order, options):
            // with_description = options['displayDescription']
            // search_fields = ['name']
            // fetch_fields = ['id', 'name']
            // mapping = {
            //     'name': {'name': 'name', 'type': 'text', 'match': True},
            //     'website_url': {'name': 'url', 'type': 'text', 'truncate': False},
            // }
            // if with_description:
            //     search_fields.append('website_description')
            //     fetch_fields.append('website_description')
            //     mapping['description'] = {'name': 'website_description', 'type': 'text', 'match': True, 'html': True}
            // return {
            //     'model': 'product.public.category',
            //     'base_domain': [website.website_domain()],
            //     'search_fields': search_fields,
            //     'fetch_fields': fetch_fields,
            //     'mapping': mapping,
            //     'icon': 'fa-folder-o',
            //     'order': 'name desc, id desc' if 'name desc' in order else 'name asc, id desc',
            // }
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _search_get_detail(self, website, order, options):
            // with_description = options['displayDescription']
            // with_date = options['displayDetail']
            // my = options.get('my')
            // search_tags = options.get('tag')
            // slide_category = options.get('slide_category')
            // domain = [website.website_domain()]
            // if my:
            //     domain.append([('is_member', '=', True)])
            // if search_tags:
            //     ChannelTag = self.env['slide.channel.tag']
            //     try:
            //         tag_ids = list(filter(None, [self.env['ir.http']._unslug(tag)[1] for tag in search_tags.split(',')]))
            //         tags = ChannelTag.search([('id', 'in', tag_ids)]) if tag_ids else ChannelTag
            //     except Exception:
            //         tags = ChannelTag
            //     # Group by group_id
            //     # OR inside a group, AND between groups.
            //     for tags in tags.grouped('group_id').values():
            //         domain.append([('tag_ids', 'in', tags.ids)])
            // if slide_category and 'nbr_%s' % slide_category in self:
            //     domain.append([('nbr_%s' % slide_category, '>', 0)])
            // search_fields = ['name']
            // fetch_fields = ['name', 'website_url']
            // mapping = {
            //     'name': {'name': 'name', 'type': 'text', 'match': True},
            //     'website_url': {'name': 'website_url', 'type': 'text', 'truncate': False},
            // }
            // if with_description:
            //     search_fields.append('description_short')
            //     fetch_fields.append('description_short')
            //     mapping['description'] = {'name': 'description_short', 'type': 'text', 'html': True, 'match': True}
            // if with_date:
            //     fetch_fields.append('slide_last_update')
            //     mapping['detail'] = {'name': 'slide_last_update', 'type': 'date'}
            // return {
            //     'model': 'slide.channel',
            //     'base_domain': domain,
            //     'search_fields': search_fields,
            //     'fetch_fields': fetch_fields,
            //     'mapping': mapping,
            //     'icon': 'fa-graduation-cap',
            // }
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _search_get_detail(self, website, order, options):
            // with_description = options['displayDescription']
            // search_fields = ['name']
            // fetch_fields = ['id', 'name']
            // mapping = {
            //     'name': {'name': 'name', 'type': 'text', 'match': True},
            //     'website_url': {'name': 'url', 'type': 'text', 'truncate': False},
            //     'extra_link': {'name': 'course', 'type': 'text'},
            //     'extra_link_url': {'name': 'course_url', 'type': 'text', 'truncate': False},
            // }
            // if with_description:
            //     search_fields.append('description')
            //     fetch_fields.append('description')
            //     mapping['description'] = {'name': 'description', 'type': 'text', 'html': True, 'match': True}
            // return {
            //     'model': 'slide.slide',
            //     'base_domain': [website.website_domain()],
            //     'search_fields': search_fields,
            //     'fetch_fields': fetch_fields,
            //     'mapping': mapping,
            //     'icon': 'fa-shopping-cart',
            //     'order': 'name desc, id desc' if 'name desc' in order else 'name asc, id desc',
            // }
            */
            return default;
        }

        public async Task<TEntity> SearchIsAvailableAtInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py) ---
            // def _search_is_available_at(self, operator, value):
            // supported_operators = ['in', 'not in', '=', '!=']
            // 
            // if not operator in supported_operators:
            //     return expression.TRUE_DOMAIN
            // 
            // if isinstance(value, int):
            //     value = [value]
            // 
            // if operator in expression.NEGATIVE_TERM_OPERATORS:
            //     return expression.AND([[('supplier_id.available_location_ids', 'not in', value)], [('supplier_id.available_location_ids', '!=', False)]])
            // 
            // return expression.OR([[('supplier_id.available_location_ids', 'in', value)], [('supplier_id.available_location_ids', '=', False)]])
            */
            return default;
        }

        public async Task<TEntity> SearchIsMemberChannelIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invited) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _search_is_member_channel_ids(self, invited=False):
            // return self.env['slide.channel.partner'].sudo()._read_group(
            //     [('partner_id', '=', self.env.user.partner_id.id), ('member_status', '=' if invited else '!=', 'invited'), ('active', '=', True)],
            //     aggregates=['channel_id:array_agg']
            // )[0][0]
            */
            return default;
        }

        public async Task<TEntity> SearchIsMemberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _search_is_member(self, operator, value):
            // if operator not in ['=', '!='] or not isinstance(value, bool):
            //     raise NotImplementedError(_('Operation not supported'))
            // check_has_access = operator == '=' and value or operator == '!=' and not value
            // return [('id', 'in' if check_has_access else 'not in', self._search_is_member_channel_ids())]
            */
            return default;
        }

        public async Task<TEntity> SearchIsMemberInvitedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _search_is_member_invited(self, operator, value):
            // if operator not in ['=', '!='] or not isinstance(value, bool):
            //     raise NotImplementedError(_('Operation not supported'))
            // check_has_access = operator == '=' and value or operator == '!=' and not value
            // return [('id', 'in' if check_has_access else 'not in', self._search_is_member_channel_ids(invited=True))]
            */
            return default;
        }

        public async Task<TEntity> SearchPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _search_partner_ids(self, operator, value):
            // if isinstance(value, int) and operator == 'in':
            //     value = [value]
            // return [(
            //     'channel_partner_ids', '=', self.env['slide.channel.partner'].sudo()._search(
            //         [('partner_id', operator, value),
            //          ('active', '=', True),
            //          ('member_status', '!=', 'invited')],
            //     )
            // )]
            */
            return default;
        }

        public async Task<TEntity> SearchRenderResultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fetch_fields, object mapping, object icon, object limit) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def _search_render_results(self, fetch_fields, mapping, icon, limit):
            // results_data = super()._search_render_results(fetch_fields, mapping, icon, limit)
            // for forum, data in zip(self, results_data):
            //     data['website_url'] = forum._compute_website_url()
            // return results_data
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py) ---
            // def _search_render_results(self, fetch_fields, mapping, icon, limit):
            // results_data = super()._search_render_results(fetch_fields, mapping, icon, limit)
            // for data in results_data:
            //     data['url'] = '/shop/category/%s' % data['id']
            // return results_data
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _search_render_results(self, fetch_fields, mapping, icon, limit):
            // icon_per_category = {
            //     'infographic': 'fa-file-picture-o',
            //     'article': 'fa-file-text',
            //     'presentation': 'fa-file-pdf-o',
            //     'document': 'fa-file-pdf-o',
            //     'video': 'fa-play-circle',
            //     'quiz': 'fa-question-circle',
            //     'link': 'fa-file-code-o', # appears in template "slide_icon"
            // }
            // results_data = super()._search_render_results(fetch_fields, mapping, icon, limit)
            // for slide, data in zip(self, results_data):
            //     data['_fa'] = icon_per_category.get(slide.slide_category, 'fa-file-pdf-o')
            //     data['url'] = slide.website_url
            //     data['course'] = _('Course: %s', slide.channel_id.name)
            //     data['course_url'] = slide.channel_id.website_url
            // return results_data
            */
            return default;
        }

        public async Task<TEntity> SearchStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _search_standard_price(self, operator, value):
            // return [('product_variant_ids.standard_price', operator, value)]
            */
            return default;
        }

        public async Task<TEntity> SendShareEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email, object fullscreen) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _send_share_email(self, emails):
            // """ Share channel through emails."""
            // courses_without_templates = self.filtered(lambda channel: not channel.share_channel_template_id)
            // if courses_without_templates:
            //     raise UserError(_('Impossible to send emails. Select a "Channel Share Template" for courses %(course_names)s first',
            //                          course_names=', '.join(courses_without_templates.mapped('name'))))
            // mail_ids = []
            // for record in self:
            //     template = record.share_channel_template_id.with_context(
            //         user=self.env.user,
            //         email=emails,
            //         base_url=record.get_base_url(),
            //     )
            //     email_values = {'email_to': emails}
            //     if self.env.user._is_portal():
            //         template = template.sudo()
            //         email_values['email_from'] = self.env.company.catchall_formatted or self.env.company.email_formatted
            // 
            //     mail_ids.append(template.send_mail(record.id, email_layout_xmlid='mail.mail_notification_light', email_values=email_values))
            // return mail_ids
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _send_share_email(self, email, fullscreen):
            // courses_without_templates = self.channel_id.filtered(lambda channel: not channel.share_slide_template_id)
            // if courses_without_templates:
            //     raise UserError(_('Impossible to send emails. Select a "Share Template" for courses %(course_names)s first',
            //                          course_names=', '.join(courses_without_templates.mapped('name'))))
            // mail_ids = []
            // for record in self:
            //     template = record.channel_id.share_slide_template_id.with_context(
            //         user=self.env.user,
            //         email=email,
            //         base_url=record.get_base_url(),
            //         fullscreen=fullscreen
            //     )
            //     email_values = {'email_to': email}
            //     if self.env.user._is_portal():
            //         template = template.sudo()
            //         email_values['email_from'] = self.env.company.catchall_formatted or self.env.company.email_formatted
            // 
            //     mail_ids.append(template.send_mail(record.id, email_layout_xmlid='mail.mail_notification_light', email_values=email_values))
            // return mail_ids
            */
            return default;
        }

        public async Task<TEntity> ServiceTrackingBlacklistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _service_tracking_blacklist(self):
            // """ Service tracking field is used to distinguish some specific categories of products.
            // Those products shouldn't be displayed or used in unrelated applications.
            // This method returns a domain targeting all those specific products (events, courses, ...).
            // """
            // return []
            */
            return default;
        }

        public async Task<TEntity> SetBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_barcode(self):
            // self._set_product_variant_field('barcode')
            */
            return default;
        }

        public async Task<TEntity> SetDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_default_code(self):
            // self._set_product_variant_field('default_code')
            */
            return default;
        }

        public async Task<TEntity> SetDefaultFaqInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def _set_default_faq(self):
            // for forum in self:
            //     forum.faq = self.env['ir.ui.view']._render_template('website_forum.faq_accordion', {"forum": forum})
            */
            return default;
        }

        public async Task<TEntity> SetPackagingIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_packaging_ids(self):
            // for p in self:
            //     if len(p.product_variant_ids) == 1:
            //         p.product_variant_ids.packaging_ids = p.packaging_ids
            */
            return default;
        }

        public async Task<TEntity> SetProductVariantFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_product_variant_field(self, fname):
            // """Propagate the value of the given field from the templates to their unique variant.
            // 
            // Only if it's a single variant product.
            // It's used to set fields like barcode, weight, volume..
            // 
            // :param str fname: name of the field whose value should be propagated to the variant.
            //     (field name must be identical between product.product & product.template models)
            // """
            // for template in self:
            //     count = len(template.product_variant_ids)
            //     if count == 1:
            //         template.product_variant_ids[fname] = template[fname]
            //     elif count == 0:
            //         archived_variants = self.with_context(active_test=False).product_variant_ids
            //         if len(archived_variants) == 1:
            //             archived_variants[fname] = template[fname]
            */
            return default;
        }

        public async Task<TEntity> SetStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_standard_price(self):
            // self._set_product_variant_field('standard_price')
            */
            return default;
        }

        public async Task<TEntity> SetVolumeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_volume(self):
            // self._set_product_variant_field('volume')
            */
            return default;
        }

        public async Task<TEntity> SetWeightInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_weight(self):
            // self._set_product_variant_field('weight')
            */
            return default;
        }

        public async Task<TEntity> SyncActiveFromRelatedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py) ---
            // def _sync_active_from_related(self):
            // """ Archive/unarchive product after related field is archived/unarchived """
            // return self.filtered(lambda p: (p.category_id.active and p.supplier_id.active) != p.active).toggle_active()
            */
            return default;
        }

        public async Task<TEntity> TagToWriteValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tags) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def _tag_to_write_vals(self, tags=''):
            // Tag = self.env['forum.tag']
            // post_tags = []
            // existing_keep = []
            // user = self.env.user
            // for tag_id_or_new_name in (tag.strip() for tag in tags.split(',') if tag and tag.strip()):
            //     if tag_id_or_new_name.startswith('_'):  # it's a new tag
            //         tag_name = tag_id_or_new_name[1:]
            //         # check that not already created meanwhile or maybe excluded by the limit on the search
            //         tag_ids = Tag.search([('name', '=', tag_name), ('forum_id', '=', self.id)], limit=1)
            //         if tag_ids:
            //             existing_keep.append(tag_ids.id)
            //         else:
            //             # check if user have Karma needed to create need tag
            //             if user.exists() and user.karma >= self.karma_tag_create and tag_name:
            //                 post_tags.append((0, 0, {'name': tag_name, 'forum_id': self.id}))
            //     else:
            //         existing_keep.append(int(tag_id_or_new_name))
            // post_tags.insert(0, [6, 0, existing_keep])
            // return post_tags
            */
            return default;
        }

        public async Task<TEntity> ToggleActiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py) ---
            // def toggle_active(self):
            // invalid_products = self.filtered(lambda product: not product.active and not product.category_id.active)
            // if invalid_products:
            //     raise UserError(_("The following product categories are archived. You should either unarchive the categories or change the category of the product.\n%s", '\n'.join(invalid_products.category_id.mapped('name'))))
            // invalid_products = self.filtered(lambda product: not product.active and not product.supplier_id.active)
            // if invalid_products:
            //     raise UserError(_("The following suppliers are archived. You should either unarchive the suppliers or change the supplier of the product.\n%s", '\n'.join(invalid_products.supplier_id.mapped('name'))))
            // return super().toggle_active()
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_product_category.py) ---
            // def toggle_active(self):
            // """ Archiving related lunch product """
            // res = super().toggle_active()
            // Product = self.env['lunch.product'].with_context(active_test=False)
            // all_products = Product.search([('category_id', 'in', self.ids)])
            // all_products._sync_active_from_related()
            // return res
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def toggle_active(self):
            // """ Archiving/unarchiving a channel does it on its slides, too.
            // 1. When archiving
            // We want to be archiving the channel FIRST.
            // So that when slides are archived and the recompute is triggered,
            // it does not try to mark the channel as "completed".
            // That happens because it counts slide_done / slide_total, but slide_total
            // will be 0 since all the slides for the course have been archived as well.
            // 
            // 2. When un-archiving
            // We want to archive the channel LAST.
            // So that when it recomputes stats for the channel and completion, it correctly
            // counts the slides_total by counting slides that are already un-archived. """
            // 
            // to_archive = self.filtered(lambda channel: channel.active)
            // to_activate = self.filtered(lambda channel: not channel.active)
            // if to_archive:
            //     super(Channel, to_archive).toggle_active()
            //     to_archive.is_published = False
            //     to_archive.mapped('slide_ids').action_archive()
            // if to_activate:
            //     to_activate.with_context(active_test=False).mapped('slide_ids').action_unarchive()
            //     super(Channel, to_activate).toggle_active()
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def toggle_active(self):
            // # archiving/unarchiving a channel does it on its slides, too
            // to_archive = self.filtered(lambda slide: slide.active)
            // res = super(Slide, self).toggle_active()
            // if to_archive:
            //     to_archive.filtered(lambda slide: not slide.is_category).is_published = False
            // return res
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def unlink(self):
            // self.env['website'].sudo()._update_forum_count()
            // return super().unlink()
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def unlink(self):
            // """" Necessary override to avoid cache issues in the ORM.
            // This signals the ORM to remove slides first to avoid having the SQL cascade the deletion,
            // which attempts to recompute slide statistics of removed slides and creates a cache failure.
            // 
            // Indeed, slides statistics are computed using a read_group which will try to flush the records
            // first and fail with a "Could not find all values of slide.slide.category_id to flush them".
            // (Fix suggested by the ORM team).
            // 
            // (See '_compute_slides_statistics' and '_compute_category_completion_time'). """
            // 
            // self.slide_ids.unlink()
            // return super().unlink()
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def unlink(self):
            // for category in self.filtered(lambda slide: slide.is_category):
            //     category.channel_id._move_category_slides(category, False)
            // channel_partner_ids = self.channel_id.channel_partner_ids
            // res = super(Slide, self).unlink()
            // channel_partner_ids._recompute_completion()
            // return res
            */
            return default;
        }

        public async Task<TEntity> ValidateEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_address, object discuss_channel) where TEntity : IEntity<Guid>, IImageMixinable
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

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_karma_rank.py) ---
            // def write(self, vals):
            // if 'karma_min' in vals:
            //     previous_ranks = self.env['gamification.karma.rank'].search([], order="karma_min DESC").ids
            //     low = min(vals['karma_min'], min(self.mapped('karma_min')))
            //     high = max(vals['karma_min'], max(self.mapped('karma_min')))
            // 
            // res = super(KarmaRank, self).write(vals)
            // 
            // if 'karma_min' in vals:
            //     after_ranks = self.env['gamification.karma.rank'].search([], order="karma_min DESC").ids
            //     if previous_ranks != after_ranks:
            //         users = self.env['res.users'].sudo().search([('karma', '>=', max(low, 1))])
            //     else:
            //         users = self.env['res.users'].sudo().search([('karma', '>=', max(low, 1)), ('karma', '<=', high)])
            //     users._recompute_rank()
            // return res
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // 
            // if 'title' in vals:
            //     self.operator_partner_id.write({'name': vals['title']})
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py) ---
            // def write(self, vals):
            // if 'is_favorite' in vals:
            //     if vals.pop('is_favorite'):
            //         commands = [(4, product.id) for product in self]
            //     else:
            //         commands = [(3, product.id) for product in self]
            //     self.env.user.write({
            //         'favorite_lunch_product_ids': commands,
            //     })
            // 
            // if not vals:
            //     return True
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def write(self, vals):
            // res = super(ProductTemplate, self).write(vals)
            // if self._context.get("create_product_product", True) and 'attribute_line_ids' in vals or (vals.get('active') and len(self.product_variant_ids) == 0):
            //     self._create_variant_ids()
            // if 'active' in vals and not vals.get('active'):
            //     self.with_context(active_test=False).mapped('product_variant_ids').write({'active': vals.get('active')})
            // if 'image_1920' in vals:
            //     self.env['product.product'].invalidate_model([
            //         'image_1920',
            //         'image_1024',
            //         'image_512',
            //         'image_256',
            //         'image_128',
            //         'can_image_1024_be_zoomed',
            //     ])
            // for product_template in self:
            //     if "type" in vals and vals.get("type") != "combo":
            //         product_template.combo_ids = False
            // return res
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def write(self, vals):
            // if 'privacy' in vals:
            //     if vals['privacy'] in ('public', 'connected'):
            //         vals['authorized_group_id'] = False
            // 
            // res = super().write(vals)
            // if 'active' in vals:
            //     # archiving/unarchiving a forum does it on its posts, too
            //     self.env['forum.post'].with_context(active_test=False).search([('forum_id', 'in', self.ids)]).write({'active': vals['active']})
            // 
            // if 'active' in vals or 'website_id' in vals:
            //     self.env['website'].sudo()._update_forum_count()
            // return res
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def write(self, vals):
            // # If description_short wasn't manually modified, there is an implicit link between this field and description.
            // if not is_html_empty(vals.get('description')) and is_html_empty(vals.get('description_short')) and self.description == self.description_short:
            //     vals['description_short'] = vals.get('description')
            // 
            // res = super(Channel, self).write(vals)
            // 
            // if vals.get('user_id'):
            //     self._action_add_members(self.env['res.users'].sudo().browse(vals['user_id']).partner_id)
            //     self.activity_reschedule(['website_slides.mail_activity_data_access_request'], new_user_id=vals.get('user_id'))
            // if 'enroll_group_ids' in vals:
            //     self._add_groups_members()
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def write(self, values):
            // if values.get('is_category'):
            //     values['is_preview'] = True
            //     values['is_published'] = True
            // 
            // # if the slide type is changed, remove incompatible url or html_content
            // # done here to satisfy the SQL constraint
            // # using a stored-computed field in place does not work
            // if 'slide_category' in values:
            //     if values['slide_category'] == 'article':
            //         values = {'url': False, **values}
            //     elif values['slide_category'] != 'article':
            //         values = {'html_content': False, **values}
            // 
            // res = super(Slide, self).write(values)
            // if values.get('is_published'):
            //     self.date_published = datetime.datetime.now()
            //     self._post_publication()
            // 
            // # avoid fetching external metadata when installing the module (i.e. for demo data)
            // # we also support a context key if you don't want to fetch the metadata when modifying a slide
            // if any(values.get(url_param) for url_param in ['url', 'video_url', 'document_google_url', 'image_google_url']) \
            //    and not self.env.context.get('install_mode') \
            //    and not self.env.context.get('website_slides_skip_fetch_metadata'):
            //     slide_metadata, _error = self._fetch_external_metadata()
            //     if slide_metadata:
            //         # only update keys that are not set in the incoming values and for which we don't have a value yet
            //         self.update({
            //             key: value
            //             for key, value in slide_metadata.items()
            //             if key not in values.keys() and not any(slide[key] for slide in self)
            //         })
            // 
            // if 'is_published' in values or 'active' in values:
            //     # recompute the completion for all partners of the channel
            //     self.channel_id.channel_partner_ids._recompute_completion()
            // 
            // return res
            */
            return default;
        }
    }
}