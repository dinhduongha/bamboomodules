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
    [Module("website", Depends = new[] { "digest", "web", "web_editor", "html_editor", "http_routing", "portal", "social_media", "auth_signup", "mail", "google_recaptcha", "utm" })]
    public class WebsitePublishedMixinAppService : ApplicationService, IWebsitePublishedMixinAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public WebsitePublishedMixinAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ActionDislikeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def action_dislike(self):
            // self.check_access('read')
            // return self._action_vote(upvote=False)
            */
            return default;
        }

        public async Task<TEntity> ActionJoinAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def action_join(self):
            // self.ensure_one()
            // self.user_ids = [Command.link(self.env.user.id)]
            // self.env.user._bus_send_store(self, fields=["are_you_inside", "name"])
            */
            return default;
        }

        public async Task<TEntity> ActionLikeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def action_like(self):
            // self.check_access('read')
            // return self._action_vote(upvote=True)
            */
            return default;
        }

        public async Task<TEntity> ActionMarkCompletedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> ActionMarkCompletedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> ActionMarkUncompletedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> ActionQuitAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def action_quit(self):
            // self.ensure_one()
            // self.user_ids = [Command.unlink(self.env.user.id)]
            // self.env.user._bus_send_store(self, fields=["are_you_inside", "name"])
            */
            return default;
        }

        public async Task<TEntity> ActionSetQuizDoneInternalAsync<TEntity>(IEnumerable<TEntity> entities, object completed) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> ActionSetViewedAsync<TEntity>(IEnumerable<TEntity> entities, object quiz_attempts_inc) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> ActionSetViewedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_partner, object quiz_attempts_inc) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> ActionViewChatbotScriptsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def action_view_chatbot_scripts(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('im_livechat.chatbot_script_action')
            // chatbot_script_ids = self.env['im_livechat.channel.rule'].search(
            //     [('channel_id', 'in', self.ids)]).mapped('chatbot_script_id')
            // if len(chatbot_script_ids) == 1:
            //     action['res_id'] = chatbot_script_ids.id
            //     action['view_mode'] = 'form'
            //     action['views'] = [(False, 'form')]
            // else:
            //     action['domain'] = [('id', 'in', chatbot_script_ids.ids)]
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionViewEmbedsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> ActionViewRatingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def action_view_rating(self):
            // """ Action to display the rating relative to the channel, so all rating of the
            //     sessions of the current channel
            //     :returns : the ir.action 'action_view_rating' with the correct context
            // """
            // self.ensure_one()
            // action = self.env['ir.actions.act_window']._for_xml_id('im_livechat.rating_rating_action_livechat')
            // action['context'] = {'search_default_parent_res_name': self.name}
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionVoteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object upvote) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> ArchiveMeetingRoomsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_meet, FILE: event_meeting_room.py) ---
            // def _archive_meeting_rooms(self):
            // """Archive all non-pinned room with 0 participant if nobody has joined it for a moment."""
            // self.sudo().search([
            //     ("is_pinned", "=", False),
            //     ("active", "=", True),
            //     ("room_participant_count", "=", 0),
            //     ("room_last_activity", "<", fields.Datetime.now() - self._DELAY_CLEAN),
            // ]).active = False
            */
            return default;
        }

        public async Task<TEntity> AreYouInsideInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _are_you_inside(self):
            // for channel in self:
            //     channel.are_you_inside = self.env.user in channel.user_ids
            */
            return default;
        }

        public async Task<TEntity> CanGrantBadgeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> CheckGrantingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> ComputeAvailableOperatorIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _compute_available_operator_ids(self):
            // for record in self:
            //     record.available_operator_ids = record.user_ids.filtered(lambda user: user._is_user_available())
            */
            return default;
        }

        public async Task<TEntity> ComputeCanPublishInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: mixins.py) ---
            // def _compute_can_publish(self):
            // """ This method can be overridden if you need more complex rights
            // management than just write access to the model.
            // The publish widget will be hidden and the user won't be able to change
            // the 'website_published' value if this method sets can_publish False """
            // for record in self:
            //     try:
            //         # Some main_record might be in sudo because their content needs
            //         # to be rendered by a template even if they were not supposed
            //         # to be accessible
            //         plain_record = record.sudo(flag=False) if self._context.get('can_publish_unsudo_main_object', False) else record
            //         self.env['website'].get_current_website()._check_user_can_modify(plain_record)
            //         record.can_publish = True
            //     except AccessError:
            //         record.can_publish = False
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_can_publish(self):
            // for record in self:
            //     record.can_publish = record.channel_id.can_publish
            */
            return default;
        }

        public async Task<TEntity> ComputeCategoryCompletedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> ComputeCategoryCompletionTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> ComputeCategoryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> ComputeChatbotScriptCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _compute_chatbot_script_count(self):
            // data = self.env['im_livechat.channel.rule']._read_group(
            //     [('channel_id', 'in', self.ids)], ['channel_id'], ['chatbot_script_id:count_distinct'])
            // mapped_data = {channel.id: count_distinct for channel, count_distinct in data}
            // for channel in self:
            //     channel.chatbot_script_count = mapped_data.get(channel.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeCommentsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_comments_count(self):
            // for slide in self:
            //     slide.comments_count = len(slide.website_message_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeContactEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def _compute_contact_email(self):
            // for track in self:
            //     if track.partner_id:
            //         track.contact_email = track.partner_id.email
            */
            return default;
        }

        public async Task<TEntity> ComputeContactPhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def _compute_contact_phone(self):
            // for track in self:
            //     if track.partner_id:
            //         track.contact_phone = track.partner_id.phone
            */
            return default;
        }

        public async Task<TEntity> ComputeCountryFlagUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _compute_country_flag_url(self):
            // for sponsor in self:
            //     if sponsor.partner_id.country_id:
            //         sponsor.country_flag_url = sponsor.partner_id.country_id.image_url
            //     else:
            //         sponsor.country_flag_url = False
            */
            return default;
        }

        public async Task<TEntity> ComputeCtaTimeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def _compute_cta_time_data(self):
            // """ Compute start and remaining time for track itself. Do everything in
            // UTC as we compute only time deltas here. """
            // now_utc = utc.localize(fields.Datetime.now().replace(microsecond=0))
            // for track in self:
            //     if not track.website_cta:
            //         track.is_website_cta_live = track.website_cta_start_remaining = False
            //         continue
            // 
            //     date_begin_utc = utc.localize(track.date, is_dst=False) + timedelta(minutes=track.website_cta_delay or 0)
            //     date_end_utc = utc.localize(track.date_end, is_dst=False)
            //     track.is_website_cta_live = date_begin_utc <= now_utc <= date_end_utc
            //     if date_begin_utc >= now_utc:
            //         td = date_begin_utc - now_utc
            //         track.website_cta_start_remaining = int(td.total_seconds())
            //     else:
            //         track.website_cta_start_remaining = 0
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _compute_email(self):
            // self._synchronize_with_partner('email')
            */
            return default;
        }

        public async Task<TEntity> ComputeEmbedCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
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

        public async Task<TEntity> ComputeEmbedCountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> ComputeEndDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def _compute_end_date(self):
            // for track in self:
            //     if track.date:
            //         delta = timedelta(minutes=60 * track.duration)
            //         track.date_end = track.date + delta
            //     else:
            //         track.date_end = False
            */
            return default;
        }

        public async Task<TEntity> ComputeGoogleDriveIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> ComputeGrantedEmployeesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_gamification, FILE: gamification.py) ---
            // def _compute_granted_employees_count(self):
            // for badge in self:
            //     badge.granted_employees_count = self.env['gamification.badge.user'].search_count([
            //         ('badge_id', '=', badge.id),
            //         ('employee_id', '!=', False)
            //     ])
            */
            return default;
        }

        public async Task<TEntity> ComputeImage1920InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> ComputeImage512InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _compute_image_512(self):
            // self._synchronize_with_partner('image_512')
            */
            return default;
        }

        public async Task<TEntity> ComputeIsInOpeningHoursInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _compute_is_in_opening_hours(self):
            // """ Opening hours: hour_from and hour_to are given within event TZ or UTC.
            // Now() must therefore be computed based on that TZ. """
            // for sponsor in self:
            //     if not sponsor.event_id.is_ongoing:
            //         sponsor.is_in_opening_hours = False
            //     elif sponsor.hour_from is False or sponsor.hour_to is False:
            //         sponsor.is_in_opening_hours = True
            //     else:
            //         event_tz = timezone(sponsor.event_id.date_tz)
            //         # localize now, begin and end datetimes in event tz
            //         dt_begin = sponsor.event_id.date_begin.astimezone(event_tz)
            //         dt_end = sponsor.event_id.date_end.astimezone(event_tz)
            //         now_utc = utc.localize(fields.Datetime.now().replace(microsecond=0))
            //         now_tz = now_utc.astimezone(event_tz)
            // 
            //         # compute opening hours
            //         opening_from_tz = event_tz.localize(datetime.combine(now_tz.date(), float_to_time(sponsor.hour_from)))
            //         opening_to_tz = event_tz.localize(datetime.combine(now_tz.date(), float_to_time(sponsor.hour_to)))
            //         if sponsor.hour_to == 0:
            //             # when closing 'at midnight', we consider it's at midnight the next day
            //             opening_to_tz = opening_to_tz + timedelta(days=1)
            // 
            //         opening_from = max([dt_begin, opening_from_tz])
            //         opening_to = min([dt_end, opening_to_tz])
            // 
            //         sponsor.is_in_opening_hours = opening_from <= now_tz < opening_to
            */
            return default;
        }

        public async Task<TEntity> ComputeIsNewSlideInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_is_new_slide(self):
            // for slide in self:
            //     slide.is_new_slide = slide.date_published > fields.Datetime.now() - relativedelta(days=7) if slide.is_published else False
            */
            return default;
        }

        public async Task<TEntity> ComputeIsReminderOnInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def _compute_is_reminder_on(self):
            // current_visitor = self.env['website.visitor']._get_visitor_from_request()
            // if self.env.user._is_public() and not current_visitor:
            //     for track in self:
            //         track.is_reminder_on = track.wishlisted_by_default
            // else:
            //     if self.env.user._is_public():
            //         domain = [('visitor_id', '=', current_visitor.id)]
            //     elif current_visitor:
            //         domain = [
            //             '|',
            //             ('partner_id', '=', self.env.user.partner_id.id),
            //             ('visitor_id', '=', current_visitor.id)
            //         ]
            //     else:
            //         domain = [('partner_id', '=', self.env.user.partner_id.id)]
            // 
            //     event_track_visitors = self.env['event.track.visitor'].sudo().search_read(
            //         expression.AND([
            //             domain,
            //             [('track_id', 'in', self.ids)]
            //         ]), fields=['track_id', 'is_wishlisted', 'is_blacklisted']
            //     )
            // 
            //     wishlist_map = {
            //         track_visitor['track_id'][0]: {
            //             'is_wishlisted': track_visitor['is_wishlisted'],
            //             'is_blacklisted': track_visitor['is_blacklisted']
            //         } for track_visitor in event_track_visitors
            //     }
            //     for track in self:
            //         if wishlist_map.get(track.id):
            //             track.is_reminder_on = wishlist_map.get(track.id)['is_wishlisted'] or (track.wishlisted_by_default and not wishlist_map[track.id]['is_blacklisted'])
            //         else:
            //             track.is_reminder_on = track.wishlisted_by_default
            */
            return default;
        }

        public async Task<TEntity> ComputeKanbanStateLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def _compute_kanban_state_label(self):
            // for track in self:
            //     if track.kanban_state == 'normal':
            //         track.kanban_state_label = track.stage_id.legend_normal
            //     elif track.kanban_state == 'blocked':
            //         track.kanban_state_label = track.stage_id.legend_blocked
            //     else:
            //         track.kanban_state_label = track.stage_id.legend_done
            */
            return default;
        }

        public async Task<TEntity> ComputeLikeInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> ComputeMarkCompleteActionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> ComputeMobileInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _compute_mobile(self):
            // self._synchronize_with_partner('mobile')
            */
            return default;
        }

        public async Task<TEntity> ComputeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _compute_name(self):
            // self._synchronize_with_partner('name')
            */
            return default;
        }

        public async Task<TEntity> ComputeNbrChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _compute_nbr_channel(self):
            // data = self.env['discuss.channel']._read_group([
            //     ('livechat_channel_id', 'in', self.ids),
            // ], ['livechat_channel_id'], ['__count'])
            // channel_count = {livechat_channel.id: count for livechat_channel, count in data}
            // for record in self:
            //     record.nbr_channel = channel_count.get(record.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerBiographyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def _compute_partner_biography(self):
            // for track in self:
            //     if not track.partner_biography:
            //         track.partner_biography = track.partner_id.website_description
            //     elif track.partner_id and is_html_empty(track.partner_biography) and \
            //         not is_html_empty(track.partner_id.website_description):
            //         track.partner_biography = track.partner_id.website_description
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerCompanyNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def _compute_partner_company_name(self):
            // for track in self:
            //     if track.partner_id.company_type == 'company':
            //         track.partner_company_name = track.partner_id.name
            //     elif not track.partner_company_name:
            //         track.partner_company_name = track.partner_id.parent_id.name
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def _compute_partner_email(self):
            // for track in self:
            //     if track.partner_id and not track.partner_email:
            //         track.partner_email = track.partner_id.email
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerFunctionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def _compute_partner_function(self):
            // for track in self:
            //     if track.partner_id and not track.partner_function:
            //         track.partner_function = track.partner_id.function
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerImageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def _compute_partner_image(self):
            // for track in self:
            //     if not track.image:
            //         track.image = track.partner_id.image_256
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def _compute_partner_name(self):
            // for track in self:
            //     if track.partner_id and not track.partner_name:
            //         track.partner_name = track.partner_id.name
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerPhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def _compute_partner_phone(self):
            // for track in self:
            //     if track.partner_id and not track.partner_phone:
            //         track.partner_phone = track.partner_id.phone
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerTagLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def _compute_partner_tag_line(self):
            // for track in self:
            //     if not track.partner_name:
            //         track.partner_tag_line = False
            //         continue
            // 
            //     tag_line = track.partner_name
            //     if track.partner_function:
            //         if track.partner_company_name:
            //             tag_line = _('%(name)s, %(function)s at %(company)s',
            //                          name=track.partner_name,
            //                          function=track.partner_function,
            //                          company=track.partner_company_name
            //                         )
            //         else:
            //             tag_line = '%s, %s' % (track.partner_name, track.partner_function)
            //     elif track.partner_company_name:
            //         tag_line = _('%(name)s from %(company)s',
            //                      name=tag_line,
            //                      company=track.partner_company_name
            //                     )
            //     track.partner_tag_line = tag_line
            */
            return default;
        }

        public async Task<TEntity> ComputePhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _compute_phone(self):
            // self._synchronize_with_partner('phone')
            */
            return default;
        }

        public async Task<TEntity> ComputeQuestionsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_questions_count(self):
            // for slide in self:
            //     slide.questions_count = len(slide.question_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeQuizInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_partner, object quiz_done) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> ComputeScriptExternalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _compute_script_external(self):
            // values = {
            //     "dbname": self._cr.dbname,
            // }
            // for record in self:
            //     values["channel_id"] = record.id
            //     values["url"] = record.get_base_url()
            //     record.script_external = self.env['ir.qweb']._render('im_livechat.external_loader', values) if record.id else False
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideIconClassInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> ComputeSlideTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> ComputeSlideViewsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> ComputeSlidesStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
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

        public async Task<TEntity> ComputeSurveyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: badge.py) ---
            // def _compute_survey_id(self):
            // for badge in self:
            //     badge.survey_id = badge.survey_ids[0] if badge.survey_ids else None
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_total(self):
            // for record in self:
            //     record.total_views = record.slide_views + record.public_views
            */
            return default;
        }

        public async Task<TEntity> ComputeTrackTimeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def _compute_track_time_data(self):
            // """ Compute start and remaining time for track itself. Do everything in
            // UTC as we compute only time deltas here. """
            // now_utc = utc.localize(fields.Datetime.now().replace(microsecond=0))
            // for track in self:
            //     if not track.date:
            //         track.is_track_live = track.is_track_soon = track.is_track_today = track.is_track_upcoming = track.is_track_done = False
            //         track.track_start_relative = track.track_start_remaining = 0
            //         continue
            //     date_begin_utc = utc.localize(track.date, is_dst=False)
            //     date_end_utc = utc.localize(track.date_end, is_dst=False)
            //     track.is_track_live = date_begin_utc <= now_utc < date_end_utc
            //     track.is_track_soon = (date_begin_utc - now_utc).total_seconds() < 30*60 if date_begin_utc > now_utc else False
            //     track.is_track_today = date_begin_utc.date() == now_utc.date()
            //     track.is_track_upcoming = date_begin_utc > now_utc
            //     track.is_track_done = date_end_utc <= now_utc
            //     if date_begin_utc >= now_utc:
            //         track.track_start_relative = int((date_begin_utc - now_utc).total_seconds())
            //         track.track_start_remaining = track.track_start_relative
            //     else:
            //         track.track_start_relative = int((now_utc - date_begin_utc).total_seconds())
            //         track.track_start_remaining = 0
            */
            return default;
        }

        public async Task<TEntity> ComputeUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _compute_url(self):
            // for sponsor in self:
            //     if sponsor.partner_id.website or not sponsor.url:
            //         sponsor.url = sponsor.partner_id.website
            */
            return default;
        }

        public async Task<TEntity> ComputeUserMembershipIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> ComputeVideoSourceTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> ComputeVimeoIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> ComputeWebPageLinkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _compute_web_page_link(self):
            // for record in self:
            //     record.web_page = "%s/im_livechat/support/%i" % (record.get_base_url(), record.id) if record.id else False
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _compute_website_description(self):
            // for sponsor in self:
            //     if is_html_empty(sponsor.website_description):
            //         sponsor.website_description = sponsor.partner_id.website_description
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteImageUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _compute_website_image_url(self):
            // for sponsor in self:
            //     if sponsor.image_512:
            //         # image_512 is stored, image_256 is derived from it dynamically
            //         sponsor.website_image_url = self.env['website'].image_url(sponsor, 'image_256', size=256)
            //     elif sponsor.partner_id.image_256:
            //         sponsor.website_image_url = self.env['website'].image_url(sponsor.partner_id, 'image_256', size=256)
            //     else:
            //         sponsor.website_image_url = '/website_event_exhibitor/static/src/img/event_sponsor_default.svg'
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def _compute_website_image_url(self):
            // for track in self:
            //     if track.website_image:
            //         track.website_image_url = self.env['website'].image_url(track, 'website_image', size=1024)
            //     else:
            //         track.website_image_url = '/website_event_track/static/src/img/event_track_default_%d.jpeg' % (track.id % 2)
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsitePublishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: mixins.py) ---
            // def _compute_website_published(self):
            // current_website_id = self._context.get('website_id')
            // for record in self:
            //     if current_website_id:
            //         record.website_published = record.is_published and (not record.website_id or record.website_id.id == current_website_id)
            //     else:
            //         record.website_published = record.is_published
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteShareUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> ComputeWebsiteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: mixins.py) ---
            // def _compute_website_url(self):
            // for record in self:
            //     record.website_url = '#'
            --- ODOO METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner_grade.py) ---
            // def _compute_website_url(self):
            // super(ResPartnerGrade, self)._compute_website_url()
            // for grade in self:
            //     grade.website_url = "/partners/grade/%s" % (self.env['ir.http']._slug(grade))
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _compute_website_url(self):
            // super(Sponsor, self)._compute_website_url()
            // for sponsor in self:
            //     if sponsor.id:  # avoid to perform a slug on a not yet saved record in case of an onchange.
            //         base_url = sponsor.event_id.get_base_url()
            //         sponsor.website_url = '%s/event/%s/exhibitor/%s' % (base_url, self.env["ir.http"]._slug(sponsor.event_id), self.env["ir.http"]._slug(sponsor))
            --- ODOO METHOD SOURCE (MODULE: website_event_meet, FILE: event_meeting_room.py) ---
            // def _compute_website_url(self):
            // super(EventMeetingRoom, self)._compute_website_url()
            // for meeting_room in self:
            //     if meeting_room.id:
            //         base_url = meeting_room.event_id.get_base_url()
            //         meeting_room.website_url = '%s/event/%s/meeting_room/%s' % (base_url, self.env["ir.http"]._slug(meeting_room.event_id), self.env["ir.http"]._slug(meeting_room))
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def _compute_website_url(self):
            // super(Track, self)._compute_website_url()
            // for track in self:
            //     if track.id:
            //         track.website_url = '/event/%s/track/%s' % (self.env['ir.http']._slug(track.event_id), self.env['ir.http']._slug(track))
            --- ODOO METHOD SOURCE (MODULE: website_livechat, FILE: im_livechat.py) ---
            // def _compute_website_url(self):
            // super(ImLivechatChannel, self)._compute_website_url()
            // for channel in self:
            //     channel.website_url = "/livechat/channel/%s" % (self.env['ir.http']._slug(channel),)
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

        public async Task<TEntity> ComputeWishlistVisitorIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def _compute_wishlist_visitor_ids(self):
            // results = self.env['event.track.visitor']._read_group(
            //     [('track_id', 'in', self.ids), ('is_wishlisted', '=', True)],
            //     ['track_id'],
            //     ['visitor_id:array_agg'],
            // )
            // visitor_ids_map = {track.id: visitor_ids for track, visitor_ids in results}
            // for track in self:
            //     track.wishlist_visitor_ids = visitor_ids_map.get(track.id, [])
            //     track.wishlist_visitor_count = len(visitor_ids_map.get(track.id, []))
            */
            return default;
        }

        public async Task<TEntity> ComputeYoutubeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
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

        public async Task<TEntity> CreateAndGetWebsiteUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: mixins.py) ---
            // def create_and_get_website_url(self, **kwargs):
            // return self.create(kwargs).website_url
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: mixins.py) ---
            // def create(self, vals_list):
            // records = super(WebsitePublishedMixin, self).create(vals_list)
            // if any(record.is_published and not record.can_publish for record in records):
            //     raise AccessError(self._get_can_publish_error_message())
            // 
            // return records
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def create(self, values_list):
            // for values in values_list:
            //     if values.get('is_exhibitor') and not values.get('room_name'):
            //         exhibitor_name = values['name'] if values.get('name') else self.env['res.partner'].browse(values['partner_id']).name
            //         name = 'odoo-exhibitor-%s' % exhibitor_name or 'sponsor'
            //         values['room_name'] = name
            // return super(Sponsor, self).create(values_list)
            --- ODOO METHOD SOURCE (MODULE: website_event_meet, FILE: event_meeting_room.py) ---
            // def create(self, values_list):
            // for values in values_list:
            //     if not values.get("chat_room_id") and not values.get('room_name'):
            //         values['room_name'] = 'odoo-room-%s' % (values['name'])
            // return super(EventMeetingRoom, self).create(values_list)
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def create(self, vals_list):
            // for values in vals_list:
            //     if values.get('website_cta_url'):
            //         values['website_cta_url'] = self.env['res.partner']._clean_website(values['website_cta_url'])
            // 
            // tracks = super(Track, self).create(vals_list)
            // 
            // post_values = {} if self.env.user.email else {'email_from': self.env.company.catchall_formatted}
            // for track in tracks:
            //     track.event_id.message_post_with_source(
            //         'website_event_track.event_track_template_new',
            //         render_values={
            //             'track': track,
            //             'is_html_empty': is_html_empty,
            //         },
            //         subtype_xmlid='website_event_track.mt_event_track',
            //         **post_values,
            //     )
            //     track._synchronize_with_stage(track.stage_id)
            // 
            // return tracks
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

        public async Task<TEntity> DefaultButtonTextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _default_button_text(self):
            // return _('Have a Question? Chat with us.')
            */
            return default;
        }

        public async Task<TEntity> DefaultDefaultMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _default_default_message(self):
            // return _('How may I help you?')
            */
            return default;
        }

        public async Task<TEntity> DefaultIsPublishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: mixins.py) ---
            // def _default_is_published(self):
            // return False
            --- ODOO METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner_grade.py) ---
            // def _default_is_published(self):
            // return True
            --- ODOO METHOD SOURCE (MODULE: website_customer, FILE: res_partner.py) ---
            // def _default_is_published(self):
            // return True
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel_tag.py) ---
            // def _default_is_published(self):
            // return True
            */
            return default;
        }

        public async Task<TEntity> DefaultSponsorTypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _default_sponsor_type_id(self):
            // return self.env['event.sponsor.type'].search([], order="sequence desc", limit=1).id
            */
            return default;
        }

        public async Task<TEntity> DefaultUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _default_user_ids(self):
            // return [(6, 0, [self._uid])]
            */
            return default;
        }

        public async Task<TEntity> DefaultWebsiteMetaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> EmbedIncrementInternalAsync<TEntity>(IEnumerable<TEntity> entities, object url) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> FetchExternalMetadataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object image_url_only) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> FetchGoogleDriveMetadataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object image_url_only) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> FetchVimeoMetadataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object image_url_only) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> FetchYoutubeMetadataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object image_url_only) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> GenerateSignedTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> GetAccessActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid, object force_website) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> GetBackendMenuIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def get_backend_menu_id(self):
            // return self.env.ref('event.event_main_menu').id
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def get_backend_menu_id(self):
            // return self.env.ref('event.event_main_menu').id
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def get_backend_menu_id(self):
            // return self.env.ref('website_slides.website_slides_menu_root').id
            */
            return default;
        }

        public async Task<TEntity> GetBadgeUserStatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> GetCanPublishErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: mixins.py) ---
            // def _get_can_publish_error_message(self):
            // """ Override this method to customize the error message shown when the user doesn't
            // have the rights to publish/unpublish. """
            // return _("You do not have the rights to publish/unpublish")
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _get_can_publish_error_message(self):
            // return _("Publishing is restricted to the responsible of training courses or members of the publisher group for documentation courses")
            */
            return default;
        }

        public async Task<TEntity> GetChannelInfosInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _get_channel_infos(self):
            // self.ensure_one()
            // 
            // return {
            //     'header_background_color': self.header_background_color,
            //     'button_background_color': self.button_background_color,
            //     'title_color': self.title_color,
            //     'button_text_color': self.button_text_color,
            //     'button_text': self.button_text,
            //     'input_placeholder': self.input_placeholder,
            //     'default_message': self.default_message,
            //     "channel_name": self.name,
            //     "channel_id": self.id,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCompletionTimePdfInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data_bytes) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> GetDefaultStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def _get_default_stage_id(self):
            // return self.env['event.track.stage'].search([], limit=1).id
            */
            return default;
        }

        public async Task<TEntity> GetEventTrackVisitorsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_create) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def _get_event_track_visitors(self, force_create=False):
            // self.ensure_one()
            // 
            // force_visitor_create = self.env.user._is_public()
            // visitor_sudo = self.env['website.visitor']._get_visitor_from_request(force_create=force_visitor_create)
            // if visitor_sudo:
            //     visitor_sudo._update_visitor_last_visit()
            // 
            // if self.env.user._is_public():
            //     domain = [('visitor_id', '=', visitor_sudo.id)]
            // elif visitor_sudo:
            //     domain = [
            //         '|',
            //         ('partner_id', '=', self.env.user.partner_id.id),
            //         ('visitor_id', '=', visitor_sudo.id)
            //     ]
            // else:
            //     domain = [('partner_id', '=', self.env.user.partner_id.id)]
            // 
            // track_visitors = self.env['event.track.visitor'].sudo().search(
            //     expression.AND([domain, [('track_id', 'in', self.ids)]])
            // )
            // missing = self - track_visitors.track_id
            // if missing and force_create:
            //     track_visitors += self.env['event.track.visitor'].sudo().create([{
            //         'visitor_id': visitor_sudo.id,
            //         'partner_id': self.env.user.partner_id.id if not self.env.user._is_public() else False,
            //         'track_id': track.id,
            //     } for track in missing])
            // 
            // return track_visitors
            */
            return default;
        }

        public async Task<TEntity> GetGrantedEmployeesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_gamification, FILE: gamification.py) ---
            // def get_granted_employees(self):
            // employee_ids = self.mapped('owner_ids.employee_id').ids
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': 'Granted Employees',
            //     'view_mode': 'kanban,list,form',
            //     'res_model': 'hr.employee.public',
            //     'domain': [('id', 'in', employee_ids)]
            // }
            */
            return default;
        }

        public async Task<TEntity> GetLessActiveOperatorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object operator_statuses, object operators) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _get_less_active_operator(self, operator_statuses, operators):
            // """ Retrieve the most available operator based on the following criteria:
            // - Lowest number of active chats.
            // - Not in  a call.
            // - If an operator is in a call and has two or more active chats, don't
            //   give priority over an operator with more conversations who is not in a
            //   call.
            // 
            // :param operator_statuses: list of dictionaries containing the operator's
            //     id, the number of active chats and a boolean indicating if the
            //     operator is in a call. The list is ordered by the number of active
            //     chats (ascending) and whether the operator is in a call
            //     (descending).
            // :param operators: recordset of :class:`ResUsers` operators to choose from.
            // :return: the :class:`ResUsers` record for the chosen operator
            // """
            // if not operators:
            //     return False
            // 
            // # 1) only consider operators in the list to choose from
            // operator_statuses = [
            //     s for s in operator_statuses if s['livechat_operator_id'] in set(operators.partner_id.ids)
            // ]
            // 
            // # 2) try to select an inactive op, i.e. one w/ no active status (no recent chat)
            // active_op_partner_ids = {s['livechat_operator_id'] for s in operator_statuses}
            // candidates = operators.filtered(lambda o: o.partner_id.id not in active_op_partner_ids)
            // if candidates:
            //     return random.choice(candidates)
            // 
            // # 3) otherwise select least active ops, based on status ordering (count + in_call)
            // best_status = operator_statuses[0]
            // best_status_op_partner_ids = {
            //     s['livechat_operator_id']
            //     for s in operator_statuses
            //     if (s['count'], s['in_call']) == (best_status['count'], best_status['in_call'])
            // }
            // candidates = operators.filtered(lambda o: o.partner_id.id in best_status_op_partner_ids)
            // return random.choice(candidates)
            */
            return default;
        }

        public async Task<TEntity> GetLivechatDiscussChannelValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object anonymous_name, Guid previous_operator_id, object chatbot_script, Guid user_id, Guid country_id, object lang) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _get_livechat_discuss_channel_vals(
            //     self, anonymous_name, previous_operator_id=None, chatbot_script=None, user_id=None, country_id=None, lang=None
            // ):
            //     user_operator = False
            //     if chatbot_script:
            //         if chatbot_script.id not in self.browse(self.ids).mapped('rule_ids.chatbot_script_id.id'):
            //             return False
            //     else:
            //         user_operator = self._get_operator(previous_operator_id=previous_operator_id, lang=lang, country_id=country_id)
            //         if not user_operator:
            //             # no one available
            //             return False
            //     # partner to add to the discuss.channel
            //     operator_partner_id = user_operator.partner_id.id if user_operator else chatbot_script.operator_partner_id.id
            //     members_to_add = [
            //         Command.create({
            //             # making sure the unpin_dt is always later than the last_interest_dt
            //             # so that the channel is always unpinned at first
            //             'last_interest_dt': fields.Datetime.now() - timedelta(seconds=30),
            //             'partner_id': operator_partner_id,
            //             'unpin_dt': fields.Datetime.now(),
            //         })
            //     ]
            //     visitor_user = False
            //     if user_id:
            //         visitor_user = self.env['res.users'].browse(user_id)
            //         if visitor_user and visitor_user.active and user_operator and visitor_user != user_operator:  # valid session user (not public)
            //             members_to_add.append(Command.create({'partner_id': visitor_user.partner_id.id}))
            // 
            //     if chatbot_script:
            //         name = chatbot_script.title
            //     else:
            //         name = ' '.join([
            //             visitor_user.display_name if visitor_user else anonymous_name,
            //             user_operator.livechat_username or user_operator.name
            //         ])
            // 
            //     return {
            //         'channel_member_ids': members_to_add,
            //         'livechat_active': True,
            //         'livechat_operator_id': operator_partner_id,
            //         'livechat_channel_id': self.id,
            //         'chatbot_current_step_id': chatbot_script._get_welcome_steps()[-1].id if chatbot_script else False,
            //         'anonymous_name': False if user_id else anonymous_name,
            //         'country_id': country_id,
            //         'channel_type': 'livechat',
            //         'name': name,
            //     }
            --- ODOO METHOD SOURCE (MODULE: website_livechat, FILE: im_livechat_channel.py) ---
            // def _get_livechat_discuss_channel_vals(self, anonymous_name, previous_operator_id=None, chatbot_script=None, user_id=None, country_id=None, lang=None):
            // discuss_channel_vals = super(ImLivechatChannel, self)._get_livechat_discuss_channel_vals(
            //     anonymous_name, previous_operator_id, chatbot_script, user_id=user_id, country_id=country_id, lang=lang
            // )
            // if not discuss_channel_vals:
            //     return False
            // visitor_sudo = self.env['website.visitor']._get_visitor_from_request()
            // if visitor_sudo:
            //     discuss_channel_vals['livechat_visitor_id'] = visitor_sudo.id
            //     # As chat requested by the visitor, delete the chat requested by an operator if any to avoid conflicts between two flows
            //     # TODO DBE : Move this into the proper method (open or init mail channel)
            //     chat_request_channel = self.env['discuss.channel'].sudo().search([('livechat_visitor_id', '=', visitor_sudo.id), ('livechat_active', '=', True)])
            //     for discuss_channel in chat_request_channel:
            //         operator = discuss_channel.livechat_operator_id
            //         operator_name = operator.user_livechat_username or operator.name
            //         discuss_channel._close_livechat_session(cancel=True, operator=operator_name)
            // 
            // return discuss_channel_vals
            */
            return default;
        }

        public async Task<TEntity> GetLivechatInfoAsync<TEntity>(IEnumerable<TEntity> entities, object username) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def get_livechat_info(self, username=None):
            // self.ensure_one()
            // 
            // if username is None:
            //     username = _('Visitor')
            // info = {}
            // info['available'] = self.chatbot_script_count or len(self.available_operator_ids) > 0
            // info['server_url'] = self.get_base_url()
            // info["websocket_worker_version"] = WebsocketConnectionHandler._VERSION
            // if info['available']:
            //     info['options'] = self._get_channel_infos()
            //     info['options']["default_username"] = username
            // return info
            */
            return default;
        }

        public async Task<TEntity> GetNextCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> GetOperatorInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid previous_operator_id, object lang, Guid country_id) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _get_operator(self, previous_operator_id=None, lang=None, country_id=None):
            // """ Return an operator for a livechat. Try to return the previous
            // operator if available. If not, one of the most available operators be
            // returned.
            // 
            // A livechat is considered 'active' if it has at least one message within
            // the 30 minutes. This method will try to match the given lang and
            // country_id.
            // 
            // (Some annoying conversions have to be made on the fly because this model
            // holds 'res.users' as available operators and the discuss_channel model
            // stores the partner_id of the randomly selected operator)
            // 
            // :param previous_operator_id: id of the previous operator with whom the
            //     visitor was chatting.
            // :param lang: code of the preferred lang of the visitor.
            // :param country_id: id of the country of the visitor.
            // :return : user
            // :rtype : res.users
            // """
            // if not self.available_operator_ids:
            //     return False
            // # FIXME: remove inactive call sessions so operators no longer in call are available
            // # sudo: required to use garbage collecting function.
            // self.env["discuss.channel.rtc.session"].sudo()._gc_inactive_sessions()
            // self.env.cr.execute("""
            //     WITH operator_rtc_session AS (
            //         SELECT COUNT(DISTINCT s.id) as nbr, member.partner_id as partner_id
            //           FROM discuss_channel_rtc_session s
            //           JOIN discuss_channel_member member ON (member.id = s.channel_member_id)
            //           GROUP BY member.partner_id
            //     )
            //     SELECT COUNT(DISTINCT c.id), COALESCE(rtc.nbr, 0) > 0 as in_call, c.livechat_operator_id
            //     FROM discuss_channel c
            //     LEFT OUTER JOIN mail_message m ON c.id = m.res_id AND m.model = 'discuss.channel'
            //     LEFT OUTER JOIN operator_rtc_session rtc ON rtc.partner_id = c.livechat_operator_id
            //     WHERE c.channel_type = 'livechat' AND c.create_date > ((now() at time zone 'UTC') - interval '24 hours')
            //     AND (
            //         c.livechat_active IS TRUE
            //         OR m.create_date > ((now() at time zone 'UTC') - interval '30 minutes')
            //     )
            //     AND c.livechat_operator_id in %s
            //     GROUP BY c.livechat_operator_id, rtc.nbr
            //     ORDER BY COUNT(DISTINCT c.id) < 2 OR rtc.nbr IS NULL DESC, COUNT(DISTINCT c.id) ASC, rtc.nbr IS NULL DESC""",
            //     (tuple(self.available_operator_ids.partner_id.ids),)
            // )
            // operator_statuses = self.env.cr.dictfetchall()
            // operator = None
            // # Try to match the previous operator
            // if previous_operator_id in self.available_operator_ids.partner_id.ids:
            //     previous_operator_status = next(
            //         (status for status in operator_statuses if status['livechat_operator_id'] == previous_operator_id),
            //         None
            //     )
            //     if not previous_operator_status or previous_operator_status['count'] < 2 or not previous_operator_status['in_call']:
            //         previous_operator_user = next(
            //             available_user
            //             for available_user in self.available_operator_ids
            //             if available_user.partner_id.id == previous_operator_id
            //         )
            //         return previous_operator_user
            // # Try to match an operator with the same main lang as the visitor
            // # If no operator with the same lang, try to match an operator with the addition lang
            // if lang:
            //     same_lang_operator_ids = self.available_operator_ids.filtered(lambda operator: operator.partner_id.lang == lang)
            //     if same_lang_operator_ids:
            //         operator = self._get_less_active_operator(operator_statuses, same_lang_operator_ids)
            //     else:
            //         addition_lang_operator_ids = self.available_operator_ids.filtered(lambda operator: lang in operator.res_users_settings_id.livechat_lang_ids.mapped('code'))
            //         if addition_lang_operator_ids:
            //             operator = self._get_less_active_operator(operator_statuses, addition_lang_operator_ids)
            // # Try to match an operator with the same country as the visitor
            // if country_id and not operator:
            //     same_country_operator_ids = self.available_operator_ids.filtered(lambda operator: operator.partner_id.country_id.id == country_id)
            //     if same_country_operator_ids:
            //         operator = self._get_less_active_operator(operator_statuses, same_country_operator_ids)
            // # Try to get a random operator, regardless of the lang or the country
            // if not operator:
            //     operator = self._get_less_active_operator(operator_statuses, self.available_operator_ids)
            // return operator
            */
            return default;
        }

        public async Task<TEntity> GetOwnersInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> GetPlaceholderFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _get_placeholder_filename(self, field):
            // return self.channel_id._get_placeholder_filename(field)
            */
            return default;
        }

        public async Task<TEntity> GetSelectionClassAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_customer, FILE: res_partner.py) ---
            // def get_selection_class(self):
            // classname = ['info', 'primary', 'success', 'warning', 'danger']
            // return [(x, str.title(x)) for x in classname]
            */
            return default;
        }

        public async Task<TEntity> GetTrackSuggestionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object restrict_domain, object limit) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def _get_track_suggestions(self, restrict_domain=None, limit=None):
            // """ Returns the next tracks suggested after going to the current one
            // given by self. Tracks always belong to the same event.
            // 
            // Heuristic is
            // 
            //   * live first;
            //   * then ordered by start date, finished being sent to the end;
            //   * wishlisted (manually or by default);
            //   * tag matching with current track;
            //   * location matching with current track;
            //   * finally a random to have an "equivalent wave" randomly given;
            // 
            // :param restrict_domain: an additional domain to restrict candidates;
            // :param limit: number of tracks to return;
            // """
            // self.ensure_one()
            // 
            // base_domain = [
            //     '&',
            //     ('event_id', '=', self.event_id.id),
            //     ('id', '!=', self.id),
            // ]
            // if restrict_domain:
            //     base_domain = expression.AND([
            //         base_domain,
            //         restrict_domain
            //     ])
            // 
            // track_candidates = self.search(base_domain, limit=None, order='date asc')
            // if not track_candidates:
            //     return track_candidates
            // 
            // track_candidates = track_candidates.sorted(
            //     lambda track:
            //         (track.is_published,
            //          track.track_start_remaining == 0  # First get the tracks that started less than 10 minutes ago ...
            //          and track.track_start_relative < (10 * 60)
            //          and not track.is_track_done,  # ... AND not finished
            //          track.track_start_remaining > 0,  # Then the one that will begin later (the sooner come first)
            //          -1 * track.track_start_remaining,
            //          track.is_reminder_on,
            //          not track.wishlisted_by_default,
            //          len(track.tag_ids & self.tag_ids),
            //          track.location_id == self.location_id,
            //          randint(0, 20),
            //         ), reverse=True
            // )
            // 
            // return track_candidates[:limit]
            */
            return default;
        }

        public async Task<TEntity> InverseWebsitePublishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: mixins.py) ---
            // def _inverse_website_published(self):
            // for record in self:
            //     record.is_published = record.website_published
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnerFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _mail_get_partner_fields(self, introspect_fields=False):
            // return []
            */
            return default;
        }

        public async Task<TEntity> MailGetTimezoneWithDefaultInternalAsync<TEntity>(IEnumerable<TEntity> entities, object default_tz) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def _mail_get_timezone_with_default(self, default_tz=True):
            // tz = None
            // if self:
            //     tz = self.event_id._mail_get_timezone_with_default(default_tz=default_tz)
            // return tz or super()._mail_get_timezone_with_default(default_tz=default_tz)
            */
            return default;
        }

        public async Task<TEntity> MessageGetDefaultRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def _message_get_default_recipients(self):
            // return {
            //     track.id: {
            //         'partner_ids': [],
            //         'email_to': ','.join(tools.email_normalize_all(track.contact_email or track.partner_email)) or track.contact_email or track.partner_email,
            //         'email_cc': False
            //     } for track in self
            // }
            */
            return default;
        }

        public async Task<TEntity> MessageGetSuggestedRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _message_get_suggested_recipients(self):
            // recipients = super()._message_get_suggested_recipients()
            // if self.partner_id:
            //     self._message_add_suggested_recipient(
            //         recipients,
            //         partner=self.partner_id,
            //         reason=_('Sponsor')
            //     )
            // return recipients
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def _message_get_suggested_recipients(self):
            // recipients = super()._message_get_suggested_recipients()
            // if self.partner_id:
            //     if self.partner_id not in recipients:
            //         self._message_add_suggested_recipient(recipients, partner=self.partner_id, reason=_('Contact'))
            // else:
            //     #  Priority: contact information then speaker information
            //     if self.contact_email and self.contact_email != self.partner_id.email:
            //         self._message_add_suggested_recipient(recipients, email=self.contact_email, reason=_('Contact Email'))
            //     if not self.contact_email and self.partner_email and self.partner_email != self.partner_id.email:
            //         self._message_add_suggested_recipient(recipients, email=self.partner_email, reason=_('Speaker Email'))
            // return recipients
            */
            return default;
        }

        public async Task<TEntity> MessagePostAfterHookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def _message_post_after_hook(self, message, msg_vals):
            // #  OVERRIDE
            // #  If no partner is set on track when sending a message, then we create one from suggested contact selected.
            // #  If one or more have been created from chatter (Suggested Recipients) we search for the expected one and write the partner_id on track.
            // if msg_vals.get('partner_ids') and not self.partner_id:
            //     #  Contact(s) created from chatter set on track : we verify if at least one is the expected contact
            //     #  linked to the track. (created from contact_email if any, then partner_email if any)
            //     main_email = self.contact_email or self.partner_email
            //     main_email_normalized = tools.email_normalize(main_email)
            //     new_partner = message.partner_ids.filtered(
            //         lambda partner: partner.email == main_email or (main_email_normalized and partner.email_normalized == main_email_normalized)
            //     )
            //     if new_partner:
            //         mail_email_fname = 'contact_email' if self.contact_email else 'partner_email'
            //         if new_partner[0].email_normalized:
            //             email_domain = (mail_email_fname, 'in', [new_partner[0].email, new_partner[0].email_normalized])
            //         else:
            //             email_domain = (mail_email_fname, '=', new_partner[0].email)
            //         self.search([
            //             ('partner_id', '=', False), email_domain, ('stage_id.is_cancel', '=', False),
            //         ]).write({'partner_id': new_partner[0].id})
            // return super(Track, self)._message_post_after_hook(message, msg_vals)
            */
            return default;
        }

        public async Task<TEntity> MessagePostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def message_post(self, *, message_type='notification', **kwargs):
            // self.ensure_one()
            // if message_type == 'comment' and not self.channel_id.can_comment:  # user comments have a restriction on karma
            //     raise AccessError(_('Not enough karma to comment'))
            // return super(Slide, self).message_post(message_type=message_type, **kwargs)
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> OnChangeDocumentBinaryContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> OnChangeSlideCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> OnChangeUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> OnchangeExhibitorTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _onchange_exhibitor_type(self):
            // """ Keep an explicit onchange to allow configuration of room names, even
            // if this field is normally a related on chat_room_id.name. It is not a real
            // computed field, an onchange used in form view is sufficient. """
            // for sponsor in self:
            //     if sponsor.exhibitor_type == 'online' and not sponsor.room_name:
            //         if sponsor.name:
            //             room_name = "odoo-exhibitor-%s" % sponsor.name
            //         else:
            //             room_name = self.env['chat.room']._default_name(objname='exhibitor')
            //         sponsor.room_name = self._jitsi_sanitize_name(room_name)
            //     if sponsor.exhibitor_type == 'online' and not sponsor.room_max_capacity:
            //         sponsor.room_max_capacity = '8'
            */
            return default;
        }

        public async Task<TEntity> OpenTrackSpeakersListAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def open_track_speakers_list(self):
            // return {
            //     'name': _('Speakers'),
            //     'domain': [('id', 'in', self.mapped('partner_id').ids)],
            //     'view_mode': 'kanban,form',
            //     'res_model': 'res.partner',
            //     'view_id': False,
            //     'type': 'ir.actions.act_window',
            // }
            */
            return default;
        }

        public async Task<TEntity> OpenWebsiteUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: mixins.py) ---
            // def open_website_url(self):
            // return self.env['website'].get_client_action(self.website_url)
            --- ODOO METHOD SOURCE (MODULE: website, FILE: mixins.py) ---
            // def open_website_url(self):
            // website_id = False
            // if self.website_id:
            //     website_id = self.website_id.id
            //     if self.website_id.domain:
            //         client_action_url = self.env['website'].get_client_action_url(self.website_url)
            //         client_action_url = f'{client_action_url}&website_id={website_id}'
            //         return {
            //             'type': 'ir.actions.act_url',
            //             'url': url_join(self.website_id.domain, client_action_url),
            //             'target': 'self',
            //         }
            // return self.env['website'].get_client_action(self.website_url, False, website_id)
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def open_website_url(self):
            // """ Overridden to use a relative URL instead of an absolute when website_id is False. """
            // if self.event_id.website_id:
            //     return super().open_website_url()
            // return self.env['website'].get_client_action(f'/event/{self.env["ir.http"]._slug(self.event_id)}/exhibitor/{self.env["ir.http"]._slug(self)}')
            --- ODOO METHOD SOURCE (MODULE: website_event_meet, FILE: event_meeting_room.py) ---
            // def open_website_url(self):
            // """ Overridden to use a relative URL instead of an absolute when website_id is False. """
            // if self.event_id.website_id:
            //     return super().open_website_url()
            // return self.env['website'].get_client_action(f'/event/{self.env["ir.http"]._slug(self.event_id)}/meeting_room/{self.env["ir.http"]._slug(self)}')
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def open_website_url(self):
            // """ Overridden to use a relative URL instead of an absolute when website_id is False. """
            // if self.website_id:
            //     return super().open_website_url()
            // return self.env['website'].get_client_action(f'/slides/slide/{self.env["ir.http"]._slug(self)}')
            */
            return default;
        }

        public async Task<TEntity> PostPublicationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> RemainingSendingCalcInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
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

        public async Task<TEntity> SearchGetDetailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website, object order, object options) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
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

        public async Task<TEntity> SearchRenderResultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fetch_fields, object mapping, object icon, object limit) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
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

        public async Task<TEntity> SearchWebsitePublishedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: mixins.py) ---
            // def _search_website_published(self, operator, value):
            // if not isinstance(value, bool) or operator not in ('=', '!='):
            //     logger.warning('unsupported search on website_published: %s, %s', operator, value)
            //     return [()]
            // 
            // if operator in expression.NEGATIVE_TERM_OPERATORS:
            //     value = not value
            // 
            // current_website_id = self._context.get('website_id')
            // is_published = [('is_published', '=', value)]
            // if current_website_id:
            //     on_current_website = self.env['website'].website_domain(current_website_id)
            //     return (['!'] if value is False else []) + expression.AND([is_published, on_current_website])
            // else:  # should be in the backend, return things that are published anywhere
            //     return is_published
            */
            return default;
        }

        public async Task<TEntity> SearchWishlistVisitorIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def _search_wishlist_visitor_ids(self, operator, operand):
            // if operator == "not in":
            //     raise NotImplementedError(self.env._("Unsupported 'Not In' operation on track wishlist visitors"))
            // 
            // track_visitors = self.env['event.track.visitor'].sudo().search([
            //     ('visitor_id', operator, operand),
            //     ('is_wishlisted', '=', True)
            // ])
            // return [('id', 'in', track_visitors.track_id.ids)]
            */
            return default;
        }

        public async Task<TEntity> SendShareEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email, object fullscreen) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
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

        public async Task<TEntity> SynchronizeWithPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _synchronize_with_partner(self, fname):
            // """ Synchronize with partner if not set. Setting a value does not write
            // on partner as this may be event-specific information. """
            // for sponsor in self:
            //     if not sponsor[fname]:
            //         sponsor[fname] = sponsor.partner_id[fname]
            */
            return default;
        }

        public async Task<TEntity> SynchronizeWithStageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stage) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def _synchronize_with_stage(self, stage):
            // if stage.is_fully_accessible:
            //     self.is_published = True
            // elif stage.is_cancel:
            //     self.is_published = False
            */
            return default;
        }

        protected async Task<object> ToStoreInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _to_store(self, store: Store, /, *, fields=None):
            // if fields is None:
            //     fields = []
            // store.add(self._name, self._read_format(fields))
            */
            return default;
        }

        public async Task<TEntity> ToggleActiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
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

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // if 'kanban_state' in init_values and self.kanban_state == 'blocked':
            //     return self.env.ref('website_event_track.mt_track_blocked')
            // elif 'kanban_state' in init_values and self.kanban_state == 'done':
            //     return self.env.ref('website_event_track.mt_track_ready')
            // return super(Track, self)._track_subtype(init_values)
            */
            return default;
        }

        public async Task<TEntity> TrackTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changes) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def _track_template(self, changes):
            // res = super(Track, self)._track_template(changes)
            // track = self[0]
            // if 'stage_id' in changes and track.stage_id.mail_template_id:
            //     res['stage_id'] = (track.stage_id.mail_template_id, {
            //         'auto_delete_keep_log': False,
            //         'composition_mode': 'comment',
            //         'email_layout_xmlid': 'mail.mail_notification_light',
            //         'subtype_id': self.env['ir.model.data']._xmlid_to_res_id('mail.mt_note'),
            //     })
            // return res
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
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

        public async Task<TEntity> WebsitePublishButtonAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: mixins.py) ---
            // def website_publish_button(self):
            // self.ensure_one()
            // value = not self.website_published
            // self.write({'website_published': value})
            // return value
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IWebsitePublishedMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: mixins.py) ---
            // def write(self, values):
            // if 'is_published' in values and any(not record.can_publish for record in self):
            //     raise AccessError(self._get_can_publish_error_message())
            // 
            // return super(WebsitePublishedMixin, self).write(values)
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def write(self, values):
            // toupdate = self.env['event.sponsor']
            // if values.get('is_exhibitor') and not values.get('chat_room_id') and not values.get('room_name'):
            //     toupdate = self.filtered(lambda exhibitor: not exhibitor.chat_room_id)
            //     # go into sequential update in order to create a custom room name for each sponsor
            //     for exhibitor in toupdate:
            //         values['room_name'] = 'odoo-exhibitor-%s' % exhibitor.name
            //         super(Sponsor, exhibitor).write(values)
            // return super(Sponsor, self - toupdate).write(values)
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py) ---
            // def write(self, vals):
            // if vals.get('website_cta_url'):
            //     vals['website_cta_url'] = self.env['res.partner']._clean_website(vals['website_cta_url'])
            // if 'stage_id' in vals and 'kanban_state' not in vals:
            //     vals['kanban_state'] = 'normal'
            // if vals.get('stage_id'):
            //     stage = self.env['event.track.stage'].browse(vals['stage_id'])
            //     self._synchronize_with_stage(stage)
            // res = super(Track, self).write(vals)
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