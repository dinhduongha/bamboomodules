using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Domain.Shared.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("website", Depends = new[] { "digest", "web", "web_editor", "html_editor", "http_routing", "portal", "social_media", "auth_signup", "mail", "google_recaptcha", "utm" })]
    public class WebsiteCoverPropertiesMixinAppService : ApplicationService, IWebsiteCoverPropertiesMixinAppService
    {

        public WebsiteCoverPropertiesMixinAppService() 
        {

        }

        public async Task<TEntity> ActionAddMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_partners, object member_status, object raise_on_access) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> ActionChannelOpenInviteWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mail_template, object enroll_mode) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> ActionRequestAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> AddGroupsMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _add_groups_members(self):
            // for channel in self:
            //     channel._action_add_members(channel.mapped('enroll_group_ids.users.partner_id'))
            */
            return default;
        }

        public async Task<TEntity> AllTagsAsync<TEntity>(IEnumerable<TEntity> entities, object @join, object min_limit) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def all_tags(self, join=False, min_limit=1):
            // BlogTag = self.env['blog.tag']
            // req = """
            //     SELECT
            //         p.blog_id, count(*), r.blog_tag_id
            //     FROM
            //         blog_post_blog_tag_rel r
            //             join blog_post p on r.blog_post_id=p.id
            //     WHERE
            //         p.blog_id in %s
            //     GROUP BY
            //         p.blog_id,
            //         r.blog_tag_id
            //     ORDER BY
            //         count(*) DESC
            // """
            // self._cr.execute(req, [tuple(self.ids)])
            // tag_by_blog = {i.id: [] for i in self}
            // all_tags = set()
            // for blog_id, freq, tag_id in self._cr.fetchall():
            //     if freq >= min_limit:
            //         if join:
            //             all_tags.add(tag_id)
            //         else:
            //             tag_by_blog[blog_id].append(tag_id)
            // 
            // if join:
            //     return BlogTag.browse(all_tags)
            // 
            // for blog_id in tag_by_blog:
            //     tag_by_blog[blog_id] = BlogTag.browse(tag_by_blog[blog_id])
            // 
            // return tag_by_blog
            */
            return default;
        }

        public async Task<TEntity> ChannelEnrollAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_channel_enroll(self):
            // template = self.env.ref('website_slides.mail_template_slide_channel_enroll', raise_if_not_found=False)
            // return self._action_channel_open_invite_wizard(template, enroll_mode=True)
            */
            return default;
        }

        public async Task<TEntity> ChannelInviteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_channel_invite(self):
            // template = self.env.ref('website_slides.mail_template_slide_channel_invite', raise_if_not_found=False)
            // return self._action_channel_open_invite_wizard(template)
            */
            return default;
        }

        public async Task<TEntity> CheckClosingDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _check_closing_date(self):
            // for event in self:
            //     if event.date_end < event.date_begin:
            //         raise ValidationError(_('The closing date cannot be earlier than the beginning date.'))
            */
            return default;
        }

        public async Task<TEntity> CheckForPublicationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _check_for_publication(self, vals):
            // if vals.get('is_published'):
            //     for post in self.filtered(lambda p: p.active):
            //         post.blog_id.message_post_with_source(
            //             'website_blog.blog_post_template_new_post',
            //             subject=post.name,
            //             render_values={'post': post},
            //             subtype_xmlid='website_blog.mt_blog_blog_published',
            //         )
            //     return True
            // return False
            */
            return default;
        }

        public async Task<TEntity> CheckSeatsAvailabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object minimal_availability) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _check_seats_availability(self, minimal_availability=0):
            // sold_out_events = []
            // for event in self:
            //     if event.seats_limited and event.seats_max and event.seats_available < minimal_availability:
            //         sold_out_events.append(_(
            //             '- "%(event_name)s": Missing %(nb_too_many)i seats.',
            //             event_name=event.name,
            //             nb_too_many=minimal_availability - event.seats_available,
            //         ))
            // if sold_out_events:
            //     raise ValidationError(_('There are not enough seats available for:')
            //                           + '\n%s\n' % '\n'.join(sold_out_events))
            */
            return default;
        }

        public async Task<TEntity> CheckWebsiteIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _check_website_id(self):
            // for event in self:
            //     if event.website_id and event.website_id.company_id != event.company_id:
            //         raise ValidationError(_("The website must be from the same company as the event."))
            */
            return default;
        }

        public async Task<TEntity> ComputeActionRightsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> ComputeAddressInlineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_address_inline(self):
            // """Use venue address if available, otherwise its name, finally ''. """
            // for event in self:
            //     if (event.address_id.contact_address or '').strip():
            //         event.address_inline = ', '.join(
            //             frag.strip()
            //             for frag in event.address_id.contact_address.split('\n') if frag.strip()
            //         )
            //     else:
            //         event.address_inline = event.address_id.name or ''
            */
            return default;
        }

        public async Task<TEntity> ComputeAddressSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_address_search(self):
            // for event in self:
            //     event.address_search = event.address_id
            */
            return default;
        }

        public async Task<TEntity> ComputeBlogPostCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _compute_blog_post_count(self):
            // for record in self:
            //     record.blog_post_count = len(record.blog_post_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeBoothMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_booth, FILE: event_event.py) ---
            // def _compute_booth_menu(self):
            // for event in self:
            //     if event.event_type_id and event.event_type_id != event._origin.event_type_id:
            //         event.booth_menu = event.event_type_id.booth_menu
            //     elif event.website_menu and (event.website_menu != event._origin.website_menu or not event.booth_menu):
            //         event.booth_menu = True
            //     elif not event.website_menu:
            //         event.booth_menu = False
            */
            return default;
        }

        public async Task<TEntity> ComputeCanPublishInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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
            */
            return default;
        }

        public async Task<TEntity> ComputeCanUploadInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> ComputeCategoryAndSlideIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> ComputeCommunityMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_community_menu(self):
            // """ Set False in base module. Sub modules will add their own logic
            // (meet or track_quiz). """
            // for event in self:
            //     event.community_menu = False
            */
            return default;
        }

        public async Task<TEntity> ComputeDateBeginTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_date_begin_tz(self):
            // for event in self:
            //     if event.date_begin:
            //         event.date_begin_located = format_datetime(
            //             self.env, event.date_begin, tz=event.date_tz, dt_format='medium')
            //     else:
            //         event.date_begin_located = False
            */
            return default;
        }

        public async Task<TEntity> ComputeDateEndTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_date_end_tz(self):
            // for event in self:
            //     if event.date_end:
            //         event.date_end_located = format_datetime(
            //             self.env, event.date_end, tz=event.date_tz, dt_format='medium')
            //     else:
            //         event.date_end_located = False
            */
            return default;
        }

        public async Task<TEntity> ComputeDateTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_date_tz(self):
            // for event in self:
            //     if event.event_type_id.default_timezone:
            //         event.date_tz = event.event_type_id.default_timezone
            //     if not event.date_tz:
            //         event.date_tz = self.env.user.tz or 'UTC'
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_display_name(self):
            // """Adds ticket seats availability if requested by context."""
            // if not self.env.context.get('name_with_seats_availability'):
            //     return super()._compute_display_name()
            // for event in self:
            //     # event or its tickets are sold out
            //     if event.event_registrations_sold_out:
            //         name = _('%(event_name)s (Sold out)', event_name=event.name)
            //     elif event.seats_limited and event.seats_max:
            //         name = _(
            //             '%(event_name)s (%(count)s seats remaining)',
            //             event_name=event.name,
            //             count=formatLang(self.env, event.seats_available, digits=0),
            //         )
            //     else:
            //         name = event.name
            //     event.display_name = name
            */
            return default;
        }

        public async Task<TEntity> ComputeEnrollInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_enroll(self):
            // self.filtered(lambda channel: channel.visibility == 'members').enroll = 'invite'
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothCategoryAvailableIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_event.py) ---
            // def _compute_event_booth_category_available_ids(self):
            // for event in self:
            //     event.event_booth_category_available_ids = event.event_booth_ids.filtered(lambda booth: booth.is_available).mapped('booth_category_id')
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothCategoryIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_event.py) ---
            // def _compute_event_booth_category_ids(self):
            // for event in self:
            //     event.event_booth_category_ids = event.event_booth_ids.mapped('booth_category_id')
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_event.py) ---
            // def _compute_event_booth_count(self):
            // if self.ids and all(bool(event.id) for event in self):  # no new/onchange mode -> optimized
            //     booths_available_count, booths_total_count = self._get_booth_stat_count()
            //     for event in self:
            //         event.event_booth_count_available = booths_available_count.get(event.id, 0)
            //         event.event_booth_count = booths_total_count.get(event.id, 0)
            // else:
            //     for event in self:
            //         event.event_booth_count = len(event.event_booth_ids)
            //         event.event_booth_count_available = len(event.event_booth_ids.filtered(lambda booth: booth.is_available))
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_event.py) ---
            // def _compute_event_booth_ids(self):
            // """ Update event configuration from its event type. Depends are set only
            // on event_type_id itself, not its sub fields. Purpose is to emulate an
            // onchange: if event type is changed, update event configuration. Changing
            // event type content itself should not trigger this method.
            // 
            // When synchronizing booths:
            // 
            //   * lines that are available are removed;
            //   * template lines are added;
            // """
            // for event in self:
            //     if not event.event_type_id and not event.event_booth_ids:
            //         event.event_booth_ids = False
            //         continue
            // 
            //     # booths to keep: those that are not available
            //     booths_to_remove = event.event_booth_ids.filtered(lambda booth: booth.is_available)
            //     command = [Command.unlink(booth.id) for booth in booths_to_remove]
            //     if event.event_type_id.event_type_booth_ids:
            //         command += [
            //             Command.create({
            //                 attribute_name: line[attribute_name] if not isinstance(line[attribute_name], models.BaseModel) else line[attribute_name].id
            //                 for attribute_name in self.env['event.type.booth']._get_event_booth_fields_whitelist()
            //             }) for line in event.event_type_id.event_type_booth_ids
            //         ]
            //     event.event_booth_ids = command
            */
            return default;
        }

        public async Task<TEntity> ComputeEventMailIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_event_mail_ids(self):
            // """ Update event configuration from its event type. Depends are set only
            // on event_type_id itself, not its sub fields. Purpose is to emulate an
            // onchange: if event type is changed, update event configuration. Changing
            // event type content itself should not trigger this method.
            // 
            // When synchronizing mails:
            // 
            //   * lines that are not sent and have no registrations linked are remove;
            //   * type lines are added;
            // """
            // for event in self:
            //     if not event.event_type_id and not event.event_mail_ids:
            //         event.event_mail_ids = self._default_event_mail_ids()
            //         continue
            // 
            //     # lines to keep: those with already sent emails or registrations
            //     mails_to_remove = event.event_mail_ids.filtered(
            //         lambda mail: not(mail._origin.mail_done) and not(mail._origin.mail_registration_ids)
            //     )
            //     command = [Command.unlink(mail.id) for mail in mails_to_remove]
            // 
            //     # lines to add: those which do not have the exact copy available in lines to keep
            //     if event.event_type_id.event_type_mail_ids:
            //         mails_to_keep_vals = {frozendict(mail._prepare_event_mail_values()) for mail in event.event_mail_ids - mails_to_remove}
            //         for mail in event.event_type_id.event_type_mail_ids:
            //             mail_values = frozendict(mail._prepare_event_mail_values())
            //             if mail_values not in mails_to_keep_vals:
            //                 command.append(Command.create(mail_values))
            //     if command:
            //         event.event_mail_ids = command
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegisterUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_event_register_url(self):
            // for event in self:
            //     event.event_register_url = werkzeug.urls.url_join(event.get_base_url(), f"{event.website_url}/register")
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegistrationsOpenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_event_registrations_open(self):
            // """ Compute whether people may take registrations for this event
            // 
            //   * event.date_end -> if event is done, registrations are not open anymore;
            //   * event.start_sale_datetime -> lowest start date of tickets (if any; start_sale_datetime
            //     is False if no ticket are defined, see _compute_start_sale_date);
            //   * any ticket is available for sale (seats available) if any;
            //   * seats are unlimited or seats are available;
            // """
            // for event in self:
            //     event = event._set_tz_context()
            //     current_datetime = fields.Datetime.context_timestamp(event, fields.Datetime.now())
            //     date_end_tz = event.date_end.astimezone(pytz.timezone(event.date_tz or 'UTC')) if event.date_end else False
            //     event.event_registrations_open = event.event_registrations_started and \
            //         (date_end_tz >= current_datetime if date_end_tz else True) and \
            //         (not event.seats_limited or not event.seats_max or event.seats_available) and \
            //         (not event.event_ticket_ids or any(ticket.sale_available for ticket in event.event_ticket_ids))
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegistrationsSoldOutInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_event_registrations_sold_out(self):
            // """Note that max seats limits for events and sum of limits for all its tickets may not be
            // equal to enable flexibility.
            // E.g. max 20 seats for ticket A, 20 seats for ticket B
            //     * With max 20 seats for the event
            //     * Without limit set on the event (=40, but the customer didn't explicitly write 40)
            // """
            // for event in self:
            //     event.event_registrations_sold_out = (
            //         (event.seats_limited and event.seats_max and not event.seats_available)
            //         or (event.event_ticket_ids and all(ticket.is_sold_out for ticket in event.event_ticket_ids))
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegistrationsStartedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_event_registrations_started(self):
            // for event in self:
            //     event = event._set_tz_context()
            //     if event.start_sale_datetime:
            //         current_datetime = fields.Datetime.context_timestamp(event, fields.Datetime.now())
            //         start_sale_datetime = fields.Datetime.context_timestamp(event, event.start_sale_datetime)
            //         event.event_registrations_started = (current_datetime >= start_sale_datetime)
            //     else:
            //         event.event_registrations_started = True
            */
            return default;
        }

        public async Task<TEntity> ComputeEventTicketIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_event_ticket_ids(self):
            // """ Update event configuration from its event type. Depends are set only
            // on event_type_id itself, not its sub fields. Purpose is to emulate an
            // onchange: if event type is changed, update event configuration. Changing
            // event type content itself should not trigger this method.
            // 
            // When synchronizing tickets:
            // 
            //   * lines that have no registrations linked are remove;
            //   * type lines are added;
            // 
            // Note that updating event_ticket_ids triggers _compute_start_sale_date
            // (start_sale_datetime computation) so ensure result to avoid cache miss.
            // """
            // for event in self:
            //     if not event.event_type_id and not event.event_ticket_ids:
            //         event.event_ticket_ids = False
            //         continue
            // 
            //     # lines to keep: those with existing registrations
            //     tickets_to_remove = event.event_ticket_ids.filtered(lambda ticket: not ticket._origin.registration_ids)
            //     command = [Command.unlink(ticket.id) for ticket in tickets_to_remove]
            //     if event.event_type_id.event_type_ticket_ids:
            //         command += [
            //             Command.create({
            //                 attribute_name: line[attribute_name] if not isinstance(line[attribute_name], models.BaseModel) else line[attribute_name].id
            //                 for attribute_name in self.env['event.type.ticket']._get_event_ticket_fields_whitelist()
            //             }) for line in event.event_type_id.event_type_ticket_ids
            //         ]
            //     event.event_ticket_ids = command
            */
            return default;
        }

        public async Task<TEntity> ComputeExhibitorMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py) ---
            // def _compute_exhibitor_menu(self):
            // for event in self:
            //     if event.event_type_id and event.event_type_id != event._origin.event_type_id:
            //         event.exhibitor_menu = event.event_type_id.exhibitor_menu
            //     elif event.website_menu and (event.website_menu != event._origin.website_menu or not event.exhibitor_menu):
            //         event.exhibitor_menu = True
            //     elif not event.website_menu:
            //         event.exhibitor_menu = False
            */
            return default;
        }

        public async Task<TEntity> ComputeFieldIsOneDayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_field_is_one_day(self):
            // for event in self:
            //     # Need to localize because it could begin late and finish early in
            //     # another timezone
            //     event = event._set_tz_context()
            //     begin_tz = fields.Datetime.context_timestamp(event, event.date_begin)
            //     end_tz = fields.Datetime.context_timestamp(event, event.date_end)
            //     event.is_one_day = (begin_tz.date() == end_tz.date())
            */
            return default;
        }

        public async Task<TEntity> ComputeHasLeadRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_event.py) ---
            // def _compute_has_lead_request(self):
            // lead_requests_data = self.env['event.lead.request']._read_group(
            //     [('event_id', 'in', self.ids)],
            //     ['event_id'], ['__count'],
            // )
            // mapped_data = {event.id: count for event, count in lead_requests_data}
            // for event in self:
            //     event.has_lead_request = mapped_data.get(event.id, 0) != 0
            */
            return default;
        }

        public async Task<TEntity> ComputeHasRequestedAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> ComputeIsFinishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_is_finished(self):
            // for event in self:
            //     if not event.date_end:
            //         event.is_finished = False
            //         continue
            //     event = event._set_tz_context()
            //     current_datetime = fields.Datetime.context_timestamp(event, fields.Datetime.now())
            //     datetime_end = fields.Datetime.context_timestamp(event, event.date_end)
            //     event.is_finished = datetime_end <= current_datetime
            */
            return default;
        }

        public async Task<TEntity> ComputeIsOngoingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_is_ongoing(self):
            // now = fields.Datetime.now()
            // for event in self:
            //     event.is_ongoing = event.date_begin <= now < event.date_end
            */
            return default;
        }

        public async Task<TEntity> ComputeIsParticipatingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_is_participating(self):
            // participating_events = self._fetch_is_participating_events()
            // participating_events.is_participating = True
            // (self - participating_events).is_participating = False
            */
            return default;
        }

        public async Task<TEntity> ComputeIsVisibleOnWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_is_visible_on_website(self):
            // if all(event.website_visibility == 'public' for event in self):
            //     self.is_visible_on_website = True
            //     return
            // for event in self:
            //     if event.website_visibility == 'public' or event.is_participating:
            //         event.is_visible_on_website = True
            //     elif not self.env.user._is_public() and event.website_visibility == 'logged_users':
            //         event.is_visible_on_website = True
            //     else:
            //         event.is_visible_on_website = False
            */
            return default;
        }

        public async Task<TEntity> ComputeKanbanStateLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_kanban_state_label(self):
            // for event in self:
            //     if event.kanban_state == 'normal':
            //         event.kanban_state_label = event.stage_id.legend_normal
            //     elif event.kanban_state == 'blocked':
            //         event.kanban_state_label = event.stage_id.legend_blocked
            //     else:
            //         event.kanban_state_label = event.stage_id.legend_done
            */
            return default;
        }

        public async Task<TEntity> ComputeLeadCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_event.py) ---
            // def _compute_lead_count(self):
            // lead_data = self.env['crm.lead']._read_group(
            //     [('event_id', 'in', self.ids)],
            //     ['event_id'], ['__count'],
            // )
            // mapped_data = {event.id: count for event, count in lead_data}
            // for event in self:
            //     event.lead_count = mapped_data.get(event.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeMeetingRoomAllowCreationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_meet, FILE: event_event.py) ---
            // def _compute_meeting_room_allow_creation(self):
            // for event in self:
            //     if event.event_type_id and event.event_type_id != event._origin.event_type_id:
            //         event.meeting_room_allow_creation = event.event_type_id.meeting_room_allow_creation
            //     elif event.community_menu and event.community_menu != event._origin.community_menu:
            //         event.meeting_room_allow_creation = True
            //     elif not event.community_menu or not event.meeting_room_allow_creation:
            //         event.meeting_room_allow_creation = False
            */
            return default;
        }

        public async Task<TEntity> ComputeMeetingRoomCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_meet, FILE: event_event.py) ---
            // def _compute_meeting_room_count(self):
            // meeting_room_count = self.env["event.meeting.room"].sudo()._read_group(
            //     domain=[("event_id", "in", self.ids)],
            //     groupby=['event_id'],
            //     aggregates=['__count'],
            // )
            // 
            // meeting_room_count = {
            //     event.id: count
            //     for event, count in meeting_room_count
            // }
            // 
            // for event in self:
            //     event.meeting_room_count = meeting_room_count.get(event.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeMembersCountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> ComputeMembershipValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> ComputeNoteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_note(self):
            // for event in self:
            //     if event.event_type_id and not is_html_empty(event.event_type_id.note):
            //         event.note = event.event_type_id.note
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerHasNewContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> ComputePartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> ComputePostDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _compute_post_date(self):
            // for blog_post in self:
            //     if blog_post.published_date:
            //         blog_post.post_date = blog_post.published_date
            //     else:
            //         blog_post.post_date = blog_post.create_date
            */
            return default;
        }

        public async Task<TEntity> ComputePrerequisiteUserHasCompletedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> ComputeQuestionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_question_ids(self):
            // """ Update event questions from its event type. Depends are set only on
            // event_type_id itself to emulate an onchange. Changing event type content
            // itself should not trigger this method.
            // 
            // When synchronizing questions:
            // 
            //   * lines with no registered answers are removed;
            //   * type lines are added;
            // """
            // if self._origin.question_ids:
            //     # lines to keep: those with already given answers
            //     questions_tokeep_ids = self.env['event.registration.answer'].search(
            //         [('question_id', 'in', self._origin.question_ids.ids)]
            //     ).question_id.ids
            // else:
            //     questions_tokeep_ids = []
            // for event in self:
            //     if not event.event_type_id and not event.question_ids:
            //         event.question_ids = self._default_question_ids()
            //         continue
            // 
            //     if questions_tokeep_ids:
            //         questions_toremove = event._origin.question_ids.filtered(
            //             lambda question: question.id not in questions_tokeep_ids)
            //         command = [(3, question.id) for question in questions_toremove]
            //     else:
            //         command = [(5, 0)]
            //     event.question_ids = command
            // 
            //     # copy questions so changes in the event don't affect the event type
            //     event.question_ids += event.event_type_id.question_ids.copy({
            //         'event_type_id': False,
            //     })
            */
            return default;
        }

        public async Task<TEntity> ComputeRatingStatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> ComputeSalePriceSubtotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: event_event.py) ---
            // def _compute_sale_price_subtotal(self):
            // """ Takes all the sale.order.lines related to this event and converts amounts
            // from the currency of the sale order to the currency of the event company.
            // 
            // To avoid extra overhead, we use conversion rates as of 'today'.
            // Meaning we have a number that can change over time, but using the conversion rates
            // at the time of the related sale.order would mean thousands of extra requests as we would
            // have to do one conversion per sale.order (and a sale.order is created every time
            // we sell a single event ticket). """
            // date_now = fields.Datetime.now()
            // event_subtotals = self.env['sale.order.line']._read_group(
            //     [('event_id', 'in', self.ids), ('price_subtotal', '!=', 0), ('state', '!=', 'cancel')],
            //     ['event_id', 'currency_id'],
            //     ['price_subtotal:sum'],
            // )
            // event_subtotals_mapping = dict.fromkeys(self._origin, 0)
            // for event, currency, sum_price_subtotal in event_subtotals:
            //     event_subtotals_mapping[event] += event.currency_id._convert(
            //         sum_price_subtotal,
            //         currency,
            //         event.company_id or self.env.company,
            //         date_now,
            //     )
            // 
            // for event in self:
            //     event.sale_price_subtotal = event_subtotals_mapping.get(event._origin, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeSeatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_seats(self):
            // """ Determine available, reserved, used and taken seats. """
            // # initialize fields to 0
            // for event in self:
            //     event.seats_reserved = event.seats_used = event.seats_available = 0
            // # aggregate registrations by event and by state
            // state_field = {
            //     'open': 'seats_reserved',
            //     'done': 'seats_used',
            // }
            // base_vals = dict((fname, 0) for fname in state_field.values())
            // results = dict((event_id, dict(base_vals)) for event_id in self.ids)
            // if self.ids:
            //     query = """ SELECT event_id, state, count(event_id)
            //                 FROM event_registration
            //                 WHERE event_id IN %s AND state IN ('open', 'done') AND active = true
            //                 GROUP BY event_id, state
            //             """
            //     self.env['event.registration'].flush_model(['event_id', 'state', 'active'])
            //     self._cr.execute(query, (tuple(self.ids),))
            //     res = self._cr.fetchall()
            //     for event_id, state, num in res:
            //         results[event_id][state_field[state]] = num
            // 
            // # compute seats_available and expected
            // for event in self:
            //     event.update(results.get(event._origin.id or event.id, base_vals))
            //     if event.seats_max > 0:
            //         event.seats_available = event.seats_max - (event.seats_reserved + event.seats_used)
            // 
            //     event.seats_taken = event.seats_reserved + event.seats_used
            */
            return default;
        }

        public async Task<TEntity> ComputeSeatsLimitedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_seats_limited(self):
            // """ Update event configuration from its event type. Depends are set only
            // on event_type_id itself, not its sub fields. Purpose is to emulate an
            // onchange: if event type is changed, update event configuration. Changing
            // event type content itself should not trigger this method. """
            // for event in self:
            //     if event.event_type_id.has_seats_limitation != event.seats_limited:
            //         event.seats_limited = event.event_type_id.has_seats_limitation
            //     if not event.seats_limited:
            //         event.seats_limited = False
            */
            return default;
        }

        public async Task<TEntity> ComputeSeatsMaxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_seats_max(self):
            // """ Update event configuration from its event type. Depends are set only
            // on event_type_id itself, not its sub fields. Purpose is to emulate an
            // onchange: if event type is changed, update event configuration. Changing
            // event type content itself should not trigger this method. """
            // for event in self:
            //     if not event.event_type_id:
            //         event.seats_max = event.seats_max or 0
            //     else:
            //         event.seats_max = event.event_type_id.seats_max or 0
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideLastUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_slide_last_update(self):
            // for record in self:
            //     record.slide_last_update = fields.Date.today()
            */
            return default;
        }

        public async Task<TEntity> ComputeSlidesStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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
            */
            return default;
        }

        public async Task<TEntity> ComputeSponsorCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py) ---
            // def _compute_sponsor_count(self):
            // data = self.env['event.sponsor']._read_group([('event_id', 'in', self.ids)], ['event_id'], ['__count'])
            // result = {event.id: count for event, count in data}
            // for event in self:
            //     event.sponsor_count = result.get(event.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeStartSaleDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_start_sale_date(self):
            // """ Compute the start sale date of an event. Currently lowest starting sale
            // date of tickets if they are used, of False. """
            // for event in self:
            //     start_dates = [ticket.start_sale_datetime for ticket in event.event_ticket_ids if not ticket.is_expired]
            //     event.start_sale_datetime = min(start_dates) if start_dates and all(start_dates) else False
            */
            return default;
        }

        public async Task<TEntity> ComputeTagIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_tag_ids(self):
            // """ Update event configuration from its event type. Depends are set only
            // on event_type_id itself, not its sub fields. Purpose is to emulate an
            // onchange: if event type is changed, update event configuration. Changing
            // event type content itself should not trigger this method. """
            // for event in self:
            //     if not event.tag_ids and event.event_type_id.tag_ids:
            //         event.tag_ids = event.event_type_id.tag_ids
            */
            return default;
        }

        public async Task<TEntity> ComputeTeaserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _compute_teaser(self):
            // for blog_post in self:
            //     if blog_post.teaser_manual:
            //         blog_post.teaser = blog_post.teaser_manual
            //     else:
            //         content = text_from_html(blog_post.content, True)
            //         blog_post.teaser = content[:200] + '...'
            */
            return default;
        }

        public async Task<TEntity> ComputeTicketInstructionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_ticket_instructions(self):
            // for event in self:
            //     if is_html_empty(event.ticket_instructions) and not \
            //        is_html_empty(event.event_type_id.ticket_instructions):
            //         event.ticket_instructions = event.event_type_id.ticket_instructions
            */
            return default;
        }

        public async Task<TEntity> ComputeTimeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_time_data(self):
            // """ Compute start and remaining time. Do everything in UTC as we compute only
            // time deltas here. """
            // now_utc = utc.localize(fields.Datetime.now().replace(microsecond=0))
            // for event in self:
            //     date_begin_utc = utc.localize(event.date_begin, is_dst=False)
            //     date_end_utc = utc.localize(event.date_end, is_dst=False)
            //     event.is_ongoing = date_begin_utc <= now_utc <= date_end_utc
            //     event.is_done = now_utc > date_end_utc
            //     event.start_today = date_begin_utc.date() == now_utc.date()
            //     if date_begin_utc >= now_utc:
            //         td = date_begin_utc - now_utc
            //         event.start_remaining = int(td.total_seconds() / 60)
            //     else:
            //         event.start_remaining = 0
            */
            return default;
        }

        public async Task<TEntity> ComputeTrackCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def _compute_track_count(self):
            // data = self.env['event.track']._read_group([('stage_id.is_cancel', '!=', True)], ['event_id'], ['__count'])
            // result = {event.id: count for event, count in data}
            // for event in self:
            //     event.track_count = result.get(event.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeTracksTagIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def _compute_tracks_tag_ids(self):
            // for event in self:
            //     event.tracks_tag_ids = event.track_ids.mapped('tag_ids').filtered(lambda tag: tag.color != 0).ids
            */
            return default;
        }

        public async Task<TEntity> ComputeUseBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_use_barcode(self):
            // use_barcode = self.env['ir.config_parameter'].sudo().get_param('event.use_event_barcode') == 'True'
            // for record in self:
            //     record.use_barcode = use_barcode
            */
            return default;
        }

        public async Task<TEntity> ComputeUserStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> ComputeWebsiteDefaultBackgroundImageUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_website_default_background_image_url(self):
            // for channel in self:
            //     channel.website_default_background_image_url = f'website_slides/static/src/img/channel-{channel.channel_type}-default.jpg'
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteMenuDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_website_menu_data(self):
            // """ Synchronize with website_menu at change and let people update them
            // at will afterwards. """
            // for event in self:
            //     event.introduction_menu = event.website_menu
            //     event.location_menu = event.website_menu
            //     event.register_menu = event.website_menu
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_website_menu(self):
            // """ Also ensure a value for website_menu as it is a trigger notably for
            // track related menus. """
            // for event in self:
            //     if event.event_type_id and event.event_type_id != event._origin.event_type_id:
            //         event.website_menu = event.event_type_id.website_menu
            //     elif not event.website_menu:
            //         event.website_menu = False
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteTrackInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def _compute_website_track(self):
            // """ Propagate event_type configuration (only at change); otherwise propagate
            // website_menu updated value. Also force True is track_proposal changes. """
            // for event in self:
            //     if event.event_type_id and event.event_type_id != event._origin.event_type_id:
            //         event.website_track = event.event_type_id.website_track
            //     elif event.website_menu and (event.website_menu != event._origin.website_menu or not event.website_track):
            //         event.website_track = True
            //     elif not event.website_menu:
            //         event.website_track = False
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteTrackProposalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def _compute_website_track_proposal(self):
            // """ Propagate event_type configuration (only at change); otherwise propagate
            // website_track updated value (both together True or False at update). """
            // for event in self:
            //     if event.event_type_id and event.event_type_id != event._origin.event_type_id:
            //         event.website_track_proposal = event.event_type_id.website_track_proposal
            //     elif event.website_track != event._origin.website_track or not event.website_track or not event.website_track_proposal:
            //         event.website_track_proposal = event.website_track
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _compute_website_url(self):
            // super(BlogPost, self)._compute_website_url()
            // for blog_post in self:
            //     if blog_post.id:
            //         blog_post.website_url = "/blog/%s/%s" % (self.env['ir.http']._slug(blog_post.blog_id), self.env['ir.http']._slug(blog_post))
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_website_url(self):
            // super(Event, self)._compute_website_url()
            // for event in self:
            //     if event.id:  # avoid to perform a slug on a not yet saved record in case of an onchange.
            //         event.website_url = '/event/%s' % self.env['ir.http']._slug(event)
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_website_url(self):
            // super(Channel, self)._compute_website_url()
            // for channel in self:
            //     if channel.id:  # avoid to perform a slug on a not yet saved record in case of an onchange.
            //         base_url = channel.get_base_url()
            //         channel.website_url = '%s/slides/%s' % (base_url, self.env['ir.http']._slug(channel))
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, name=self.env._("%s (copy)", blog.name)) for blog, vals in zip(self, vals_list)]
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
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def create(self, vals_list):
            // posts = super(BlogPost, self.with_context(mail_create_nolog=True)).create(vals_list)
            // for post, vals in zip(posts, vals_list):
            //     post._check_for_publication(vals)
            // return posts
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def create(self, vals_list):
            // events = super().create(vals_list)
            // events._update_website_menus()
            // return events
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
            */
            return default;
        }

        public async Task<TEntity> CreateMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sequence, object name, object url, Guid xml_id, object menu_type) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _create_menu(self, sequence, name, url, xml_id, menu_type):
            // """ Create a new menu for the current event.
            // 
            // If url: create a website menu. Menu leads directly to the URL that
            // should be a valid route.
            // 
            // If xml_id: create a new page using the qweb template given by its
            // xml_id. Take its url back thanks to new_page of website, then link
            // it to a menu. Template is duplicated and linked to a new url, meaning
            // each menu will have its own copy of the template. This is currently
            // limited to two menus: introduction and location.
            // 
            // :param menu_type: type of menu. Mainly used for inheritance purpose
            //   allowing more fine-grain tuning of menus.
            // """
            // self.browse().check_access('write')
            // view_id = False
            // if not url:
            //     # add_menu=False, ispage=False -> simply create a new ir.ui.view with name
            //     # and template
            //     page_result = self.env['website'].sudo().new_page(
            //         name=f'{name} {self.name}', template=xml_id,
            //         add_menu=False, ispage=False)
            //     view_id = page_result['view_id']
            //     view = self.env["ir.ui.view"].browse(view_id)
            //     url = f"/event/{self.env['ir.http']._slug(self)}/page/{view.key.split('.')[-1]}"  # url contains starting "/"
            // 
            // website_menu = self.env['website.menu'].sudo().create({
            //     'name': name,
            //     'url': url,
            //     'parent_id': self.menu_id.id,
            //     'sequence': sequence,
            //     'website_id': self.website_id.id,
            // })
            // self.env['website.event.menu'].create({
            //     'menu_id': website_menu.id,
            //     'event_id': self.id,
            //     'menu_type': menu_type,
            //     'view_id': view_id,
            // })
            // return website_menu
            */
            return default;
        }

        public async Task<TEntity> DefaultAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _default_access_token(self):
            // return str(uuid.uuid4())
            */
            return default;
        }

        public async Task<TEntity> DefaultContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _default_content(self):
            // text = html_escape(_("Start writing here..."))
            // return """
            //     <p class="o_default_snippet_text">%(text)s</p>
            // """ % {"text": text}
            */
            return default;
        }

        public async Task<TEntity> DefaultCoverPropertiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: mixins.py) ---
            // def _default_cover_properties(self):
            // return {
            //     "background_color_class": "o_cc3",
            //     "background-image": "none",
            //     "opacity": "0.2",
            //     "resize_class": "o_half_screen_height",
            // }
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _default_cover_properties(self):
            // res = super()._default_cover_properties()
            // res.update({
            //     'background-image': "url('/website_event/static/src/img/event_cover_4.jpg')",
            //     'opacity': '0.4',
            //     'resize_class': 'cover_auto'
            // })
            // return res
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

        public async Task<TEntity> DefaultDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _default_description(self):
            // # avoid template branding with rendering_bundle=True
            // return self.env['ir.ui.view'].with_context(rendering_bundle=True) \
            //     ._render_template('event.event_default_descripton')
            */
            return default;
        }

        public async Task<TEntity> DefaultEventMailIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _default_event_mail_ids(self):
            // return self.env['event.type']._default_event_mail_type_ids()
            */
            return default;
        }

        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields_list) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def default_get(self, fields_list):
            // result = super().default_get(fields_list)
            // if 'date_begin' in fields_list and 'date_begin' not in result:
            //     now = fields.Datetime.now()
            //     # Round the datetime to the nearest half hour (e.g. 08:17 => 08:30 and 08:37 => 09:00)
            //     result['date_begin'] = now.replace(second=0, microsecond=0) + timedelta(minutes=-now.minute % 30)
            // if 'date_end' in fields_list and 'date_end' not in result and result.get('date_begin'):
            //     result['date_end'] = result['date_begin'] + timedelta(days=1)
            // return result
            */
            return default;
        }

        public async Task<TEntity> DefaultQuestionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _default_question_ids(self):
            // return self.env['event.type']._default_question_ids()
            */
            return default;
        }

        public async Task<TEntity> DefaultWebsiteMetaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _default_website_meta(self):
            // res = super(BlogPost, self)._default_website_meta()
            // res['default_opengraph']['og:description'] = res['default_twitter']['twitter:description'] = self.subtitle
            // res['default_opengraph']['og:type'] = 'article'
            // res['default_opengraph']['article:published_time'] = self.post_date
            // res['default_opengraph']['article:modified_time'] = self.write_date
            // res['default_opengraph']['article:tag'] = self.tag_ids.mapped('name')
            // # background-image might contain single quotes eg `url('/my/url')`
            // res['default_opengraph']['og:image'] = res['default_twitter']['twitter:image'] = json_scriptsafe.loads(self.cover_properties).get('background-image', 'none')[4:-1].strip("'")
            // res['default_opengraph']['og:title'] = res['default_twitter']['twitter:title'] = self.name
            // res['default_meta_description'] = self.subtitle
            // return res
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _default_website_meta(self):
            // res = super(Event, self)._default_website_meta()
            // event_cover_properties = json.loads(self.cover_properties)
            // # background-image might contain single quotes eg `url('/my/url')`
            // res['default_opengraph']['og:image'] = res['default_twitter']['twitter:image'] = event_cover_properties.get('background-image', 'none')[4:-1].strip("'")
            // res['default_opengraph']['og:title'] = res['default_twitter']['twitter:title'] = self.name
            // res['default_opengraph']['og:description'] = res['default_twitter']['twitter:description'] = self.subtitle
            // res['default_twitter']['twitter:card'] = 'summary'
            // res['default_meta_description'] = self.subtitle
            // return res
            */
            return default;
        }

        public async Task<TEntity> FetchIsParticipatingEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _fetch_is_participating_events(self):
            // """Heuristic
            // 
            //   * public, no visitor: not participating as we have no information;
            //   * check only confirmed and attended registrations, a draft registration
            //     does not make the attendee participating;
            //   * public and visitor: check visitor is linked to a registration. As
            //     visitors are merged on the top parent, current visitor check is
            //     sufficient even for successive visits;
            //   * logged, no visitor: check partner is linked to a registration. Do
            //     not check the email as it is not really secure;
            //   * logged as visitor: check partner or visitor are linked to a
            //     registration;
            // """
            // current_visitor = self.env['website.visitor']._get_visitor_from_request()
            // if self.env.user._is_public() and not current_visitor:
            //     return self.env['event.event']
            // 
            // base_domain = [('state', 'in', ['open', 'done'])]
            // if self:
            //     base_domain = expression.AND([[('event_id', 'in', self.ids)], base_domain])
            // 
            // visitor_domain = []
            // partner_id = self.env.user.partner_id
            // if current_visitor:
            //     visitor_domain = [('visitor_id', '=', current_visitor.id)]
            //     partner_id = current_visitor.partner_id
            // if partner_id:
            //     visitor_domain = expression.OR([visitor_domain, [('partner_id', '=', partner_id.id)]])
            // 
            // registrations_events = self.env['event.registration'].sudo()._read_group(
            //     expression.AND([visitor_domain, base_domain]),
            //     ['event_id'], ['__count'])
            // return self.env['event.event'].browse([event.id for event, _reg_count in registrations_events])
            */
            return default;
        }

        public async Task<TEntity> FilterAddMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_partners, object raise_on_access) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> GcMarkEventsDoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _gc_mark_events_done(self):
            // """ move every ended events in the next 'ended stage' """
            // ended_events = self.env['event.event'].search([
            //     ('date_end', '<', fields.Datetime.now()),
            //     ('stage_id.pipe_end', '=', False),
            // ])
            // if ended_events:
            //     ended_events.action_set_done()
            */
            return default;
        }

        public async Task<TEntity> GenerateLeadsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_event.py) ---
            // def action_generate_leads(self):
            // """ Re-generate leads based on event.lead.rules.
            // The method is ran synchronously if there is a low amount of registrations, otherwise it
            // goes through a CRON job that runs in batches. """
            // 
            // if not self.env.user.has_group('event.group_event_manager'):
            //     raise UserError(_("Only Event Managers are allowed to re-generate all leads."))
            // 
            // self.ensure_one()
            // registrations_count = self.env['event.registration'].search_count([
            //     ('event_id', '=', self.id),
            //     ('state', 'not in', ['draft', 'cancel']),
            // ])
            // 
            // if registrations_count <= self.env['event.lead.request']._REGISTRATIONS_BATCH_SIZE:
            //     leads = self.env['event.registration'].search([
            //         ('event_id', '=', self.id),
            //         ('state', 'not in', ['draft', 'cancel']),
            //     ])._apply_lead_generation_rules()
            //     if leads:
            //         notification = _("Yee-ha, %(leads_count)s Leads have been created!", leads_count=len(leads))
            //     else:
            //         notification = _("Aww! No Leads created, check your Lead Generation Rules and try again.")
            // else:
            //     self.env['event.lead.request'].sudo().create({'event_id': self.id})
            //     self.env.ref('event_crm.ir_cron_generate_leads')._trigger()
            //     notification = _("Got it! We've noted your request. Your leads will be created soon!")
            // 
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'type': 'info',
            //         'sticky': False,
            //         'message': notification,
            //         'next': {'type': 'ir.actions.act_window_close'},  # force a form reload
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> GetAccessActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid, object force_website) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _get_access_action(self, access_uid=None, force_website=False):
            // """ Instead of the classic form view, redirect to the post on website
            // directly if user is an employee or if the post is published. """
            // self.ensure_one()
            // user = self.env['res.users'].sudo().browse(access_uid) if access_uid else self.env.user
            // if not force_website and user.share and not self.sudo().website_published:
            //     return super(BlogPost, self)._get_access_action(access_uid=access_uid, force_website=force_website)
            // return {
            //     'type': 'ir.actions.act_url',
            //     'url': self.website_url,
            //     'target': 'self',
            //     'target_type': 'public',
            //     'res_id': self.id,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetBackendMenuIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def get_backend_menu_id(self):
            // return self.env.ref('event.event_main_menu').id
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def get_backend_menu_id(self):
            // return self.env.ref('website_slides.website_slides_menu_root').id
            */
            return default;
        }

        public async Task<TEntity> GetBackgroundInternalAsync<TEntity>(IEnumerable<TEntity> entities, object height, object width) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: mixins.py) ---
            // def _get_background(self, height=None, width=None):
            // self.ensure_one()
            // properties = json_safe.loads(self.cover_properties)
            // img = properties.get('background-image', "none")
            // 
            // if img.startswith('url(/web/image/'):
            //     suffix = ""
            //     if height is not None:
            //         suffix += "&height=%s" % height
            //     if width is not None:
            //         suffix += "&width=%s" % width
            //     if suffix:
            //         suffix = '?' not in img and "?%s" % suffix or suffix
            //         img = img[:-1] + suffix + ')'
            // return img
            */
            return default;
        }

        public async Task<TEntity> GetBoothStatCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_event.py) ---
            // def _get_booth_stat_count(self):
            // elements = self.env['event.booth'].sudo()._read_group(
            //     [('event_id', 'in', self.ids)],
            //     ['event_id', 'state'], ['__count']
            // )
            // elements_total_count = defaultdict(int)
            // elements_available_count = dict()
            // for event, state, count in elements:
            //     if state == 'available':
            //         elements_available_count[event.id] = count
            //     elements_total_count[event.id] += count
            // return elements_available_count, elements_total_count
            */
            return default;
        }

        public async Task<TEntity> GetCanPublishErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _get_can_publish_error_message(self):
            // return _("Publishing is restricted to the responsible of training courses or members of the publisher group for documentation courses")
            */
            return default;
        }

        public async Task<TEntity> GetCategorizedSlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_domain, object order, object force_void, object limit, object offset) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> GetDateRangeStrInternalAsync<TEntity>(IEnumerable<TEntity> entities, object lang_code) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_date_range_str(self, lang_code=False):
            // self.ensure_one()
            // today_tz = pytz.utc.localize(fields.Datetime.now()).astimezone(pytz.timezone(self.date_tz))
            // event_date_tz = pytz.utc.localize(self.date_begin).astimezone(pytz.timezone(self.date_tz))
            // diff = (event_date_tz.date() - today_tz.date())
            // if diff.days <= 0:
            //     return _('today')
            // if diff.days == 1:
            //     return _('tomorrow')
            // if (diff.days < 7):
            //     return _('in %d days', diff.days)
            // if (diff.days < 14):
            //     return _('next week')
            // if event_date_tz.month == (today_tz + relativedelta(months=+1)).month:
            //     return _('next month')
            // return _('on %(date)s', date=format_date(self.env, self.date_begin, lang_code=lang_code, date_format='medium'))
            */
            return default;
        }

        public async Task<TEntity> GetDefaultEnrollMsgInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _get_default_enroll_msg(self):
            // return _('Contact Responsible')
            */
            return default;
        }

        public async Task<TEntity> GetDefaultStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_default_stage_id(self):
            // return self.env['event.stage'].search([], limit=1)
            */
            return default;
        }

        public async Task<TEntity> GetEarnedKarmaInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> GetEventPrintDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_event_print_details(self):
            // self.ensure_one()
            // return {
            //     'name': self.name,
            //     'badge_image': self.badge_image,
            //     'timeframe': self._get_event_timeframe_string(),
            //     'address': self.address_id.name if self.address_id else None,
            //     'logo': self.company_id.logo,
            //     'sponsor_text': self._get_printing_sponsor_text()
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEventResourceUrlsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _get_event_resource_urls(self):
            // url_date_start = self.date_begin.astimezone(timezone(self.date_tz)).strftime('%Y%m%dT%H%M%S')
            // url_date_stop = self.date_end.astimezone(timezone(self.date_tz)).strftime('%Y%m%dT%H%M%S')
            // params = {
            //     'action': 'TEMPLATE',
            //     'text': self.name,
            //     'dates': f'{url_date_start}/{url_date_stop}',
            //     'ctz': self.date_tz,
            //     'details': self._get_external_description(),
            // }
            // if self.address_id:
            //     params.update(location=self.address_inline)
            // encoded_params = werkzeug.urls.url_encode(params)
            // google_url = GOOGLE_CALENDAR_URL + encoded_params
            // iCal_url = f'/event/{self.id:d}/ics?{encoded_params}'
            // return {'google_url': google_url, 'iCal_url': iCal_url}
            */
            return default;
        }

        public async Task<TEntity> GetEventTimeframeStringInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_event_timeframe_string(self):
            // self.ensure_one()
            // start_datetime = format_datetime(self.env, self.date_begin, self.date_tz, "short")
            // if self.is_one_day:
            //     end_datetime = format_time(self.env, self.date_end, self.date_tz, "short")
            // else:
            //     end_datetime = format_datetime(self.env, self.date_end, self.date_tz, "short")
            // return _("%(start_date)s to %(end_date)s", start_date=start_datetime, end_date=end_datetime)
            */
            return default;
        }

        public async Task<TEntity> GetExternalDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _get_external_description(self):
            // """ Adding the URL of the event into the description """
            // self.ensure_one()
            // event_url = f'<a href="{self.event_register_url}">{self.name}</a>'
            // description = event_url + '\n' + super()._get_external_description()
            // return description
            */
            return default;
        }

        public async Task<TEntity> GetIcsFileInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_ics_file(self):
            // """ Returns iCalendar file for the event invitation.
            //     :returns a dict of .ics file content for each event
            // """
            // result = {}
            // if not vobject:
            //     return result
            // 
            // for event in self:
            //     cal = vobject.iCalendar()
            //     cal_event = cal.add('vevent')
            // 
            //     cal_event.add('created').value = fields.Datetime.now().replace(tzinfo=pytz.timezone('UTC'))
            //     cal_event.add('dtstart').value = event.date_begin.astimezone(pytz.timezone(event.date_tz))
            //     cal_event.add('dtend').value = event.date_end.astimezone(pytz.timezone(event.date_tz))
            //     cal_event.add('summary').value = event.name
            //     cal_event.add('description').value = event._get_external_description()
            //     if event.address_id:
            //         cal_event.add('location').value = event.address_inline
            // 
            //     result[event.id] = cal.serialize().encode('utf-8')
            // return result
            */
            return default;
        }

        public async Task<TEntity> GetKioskUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def get_kiosk_url(self):
            // return self.get_base_url() + "/odoo/registration-desk"
            */
            return default;
        }

        public async Task<TEntity> GetMailMessageAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object operation, object model_name) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_mail_message_access(self, res_ids, operation, model_name=None):
            // if (
            //     operation == 'create'
            //     and self.env.user.has_group('event.group_event_registration_desk')
            //     and (not model_name or model_name == 'event.event')
            // ):
            //     # allow the registration desk users to post messages on Event
            //     # can not be done with "_mail_post_access" otherwise public user will be
            //     # able to post on published Event (see website_event)
            //     return 'read'
            // return super(EventEvent, self)._get_mail_message_access(res_ids, operation, model_name)
            */
            return default;
        }

        public async Task<TEntity> GetMenuTypeFieldMatchingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _get_menu_type_field_matching(self):
            // return {
            //     'community': 'community_menu',
            //     'introduction': 'introduction_menu',
            //     'location': 'location_menu',
            //     'register': 'register_menu',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetMenuUpdateFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _get_menu_update_fields(self):
            // """" Return a list of fields triggering a split of menu to activate /
            // menu to de-activate. Due to saas-13.3 improvement of menu management
            // this is done using side-methods to ease inheritance.
            // 
            // :return list: list of fields, each of which triggering a menu update
            //   like website_menu, website_track, ... """
            // return ['community_menu', 'introduction_menu', 'location_menu', 'register_menu']
            */
            return default;
        }

        public async Task<TEntity> GetMenusUpdateByFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object menus_state_by_field, object force_update) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _get_menus_update_by_field(self, menus_state_by_field, force_update=None):
            // """ For each field linked to a menu, get the set of events requiring
            // this menu to be activated or de-activated based on previous recorded
            // value.
            // 
            // :param menus_state_by_field: see ``_split_menus_state_by_field``;
            // :param force_update: list of field to which we force update of menus. This
            //   is used notably when a direct write to a stored editable field messes with
            //   its pre-computed value, notably in a transient mode (aka demo for example);
            // 
            // :return dict: key = name of field triggering a website menu update, get {
            //   'activated': subset of self having its menu toggled to True
            //   'deactivated': subset of self having its menu toggled to False
            // } """
            // menus_update_by_field = dict()
            // for fname in self._get_menu_update_fields():
            //     if fname in force_update:
            //         menus_update_by_field[fname] = self
            //     else:
            //         menus_update_by_field[fname] = self.env['event.event']
            //         menus_update_by_field[fname] |= menus_state_by_field[fname]['activated'].filtered(lambda event: not event[fname])
            //         menus_update_by_field[fname] |= menus_state_by_field[fname]['deactivated'].filtered(lambda event: event[fname])
            // return menus_update_by_field
            */
            return default;
        }

        public async Task<TEntity> GetPlaceholderFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _get_placeholder_filename(self, field):
            // image_fields = ['image_%s' % size for size in [1920, 1024, 512, 256, 128]]
            // if field in image_fields:
            //     return self.website_default_background_image_url
            // return super()._get_placeholder_filename(field)
            */
            return default;
        }

        public async Task<TEntity> GetPrintingSponsorTextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_printing_sponsor_text(self):
            // sponsor_text = self.env['ir.config_parameter'].sudo().get_param('event.badge_printing_sponsor_text')
            // return sponsor_text or "Powered by Odoo"
            */
            return default;
        }

        public async Task<TEntity> GetTicketsAccessHashInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> registration_ids) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_tickets_access_hash(self, registration_ids):
            // """ Returns the ground truth hash for accessing the tickets in route /event/<int:event_id>/my_tickets.
            // The dl links are always made event-dependant, hence the method linked to the record in self.
            // """
            // self.ensure_one()
            // return tools.hmac(self.env(su=True), 'event-registration-ticket-report-access', (self.id, sorted(registration_ids)))
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteMenuEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _get_website_menu_entries(self):
            // """ Method returning menu entries to display on the website view of the
            // event, possibly depending on some options in inheriting modules.
            // 
            // Each menu entry is a tuple containing :
            //   * name: menu item name
            //   * url: if set, url to a route (do not use xml_id in that case);
            //   * xml_id: template linked to the page (do not use url in that case);
            //   * sequence: specific sequence of menu entry to be set on the menu;
            //   * menu_type: type of menu entry (used in inheriting modules to ease
            //     menu management; not used in this module in 13.3 due to technical
            //     limitations);
            // """
            // self.ensure_one()
            // return [
            //     (_('Introduction'), False, 'website_event.template_intro', 1, 'introduction'),
            //     (_('Location'), False, 'website_event.template_location', 50, 'location'),
            //     (_('Info'), '/event/%s/register' % self.env['ir.http']._slug(self), False, 100, 'register'),
            //     (_('Community'), '/event/%s/community' % self.env['ir.http']._slug(self), False, 80, 'community'),
            // ]
            */
            return default;
        }

        public async Task<TEntity> GoogleMapLinkAsync<TEntity>(IEnumerable<TEntity> entities, object zoom) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def google_map_link(self, zoom=8):
            // """ Temporary method for stable """
            // return self._google_map_link(zoom=zoom)
            */
            return default;
        }

        public async Task<TEntity> GoogleMapLinkInternalAsync<TEntity>(IEnumerable<TEntity> entities, object zoom) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _google_map_link(self, zoom=8):
            // self.ensure_one()
            // if self.address_id:
            //     return self.sudo().address_id.google_map_link(zoom=zoom)
            // return None
            */
            return default;
        }

        public async Task<TEntity> GrantAccessAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> InitColumnInternalAsync<TEntity>(IEnumerable<TEntity> entities, object column_name) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> InviteContactsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_event, FILE: event_event.py) ---
            // def action_invite_contacts(self):
            // return {
            //     'name': 'Mass Mail Invitation',
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'mailing.mailing',
            //     'view_mode': 'form',
            //     'target': 'current',
            //     'context': {
            //         'default_mailing_model_id': self.env.ref('base.model_res_partner').id,
            //         'default_subject': _("Event: %s", self.name),
            //     },
            // }
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_event_sms, FILE: event.py) ---
            // def action_invite_contacts(self):
            // # Minimal override: set form view being the one mixing sms and mail (not prioritized one)
            // action = super(Event, self).action_invite_contacts()
            // action['view_id'] = self.env.ref('mass_mailing_sms.mailing_mailing_view_form_mixed').id
            // return action
            */
            return default;
        }

        public async Task<TEntity> LangGetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _lang_get(self):
            // return self.env['res.lang'].get_installed()
            */
            return default;
        }

        public async Task<TEntity> LoadPosDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: event_event.py) ---
            // def _load_pos_data_domain(self, data):
            // return [('event_ticket_ids', 'in', [ticket['id'] for ticket in data['event.event.ticket']['data']])]
            */
            return default;
        }

        public async Task<TEntity> LoadPosDataFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid config_id) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: event_event.py) ---
            // def _load_pos_data_fields(self, config_id):
            // return ['id', 'name', 'seats_available', 'event_ticket_ids', 'registration_ids', 'seats_limited', 'write_date',
            //         'question_ids', 'general_question_ids', 'specific_question_ids', 'badge_format']
            */
            return default;
        }

        public async Task<TEntity> MailAttendeesAsync<TEntity>(IEnumerable<TEntity> entities, Guid template_id, object force_send, object filter_func) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def mail_attendees(self, template_id, force_send=False, filter_func=lambda self: self.state not in ('cancel', 'draft')):
            // for event in self:
            //     for attendee in event.registration_ids.filtered(filter_func):
            //         self.env['mail.template'].browse(template_id).send_mail(attendee.id, force_send=force_send)
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnerFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _mail_get_partner_fields(self, introspect_fields=False):
            // return []
            */
            return default;
        }

        public async Task<TEntity> MassMailingAttendeesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_event, FILE: event_event.py) ---
            // def action_mass_mailing_attendees(self):
            // return {
            //     'name': 'Mass Mail Attendees',
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'mailing.mailing',
            //     'view_mode': 'form',
            //     'target': 'current',
            //     'context': {
            //         'default_mailing_model_id': self.env.ref('event.model_event_registration').id,
            //         'default_mailing_domain': repr([('event_id', 'in', self.ids), ('state', 'not in', ['cancel', 'draft'])]),
            //         'default_subject': _("Event: %s", self.name),
            //     },
            // }
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_event_sms, FILE: event.py) ---
            // def action_mass_mailing_attendees(self):
            // # Minimal override: set form view being the one mixing sms and mail (not prioritized one)
            // action = super(Event, self).action_mass_mailing_attendees()
            // action['view_id'] = self.env.ref('mass_mailing_sms.mailing_mailing_view_form_mixed').id
            // return action
            */
            return default;
        }

        public async Task<TEntity> MassMailingTrackSpeakersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_event_track, FILE: event_event.py) ---
            // def action_mass_mailing_track_speakers(self):
            // mass_mailing_action = dict(
            //     name='Mass Mail Attendees',
            //     type='ir.actions.act_window',
            //     res_model='mailing.mailing',
            //     view_mode='form',
            //     target='current',
            //     context=dict(
            //         default_mailing_model_id=self.env.ref('website_event_track.model_event_track').id,
            //         default_mailing_domain=repr([('event_id', 'in', self.ids), ('stage_id.is_cancel', '!=', True)]),
            //         default_subject=_("Event: %s", self.name),
            //     ),
            // )
            // return mass_mailing_action
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_event_track_sms, FILE: event.py) ---
            // def action_mass_mailing_track_speakers(self):
            // # Minimal override: set form view being the one mixing sms and mail (not prioritized one)
            // action = super(Event, self).action_mass_mailing_track_speakers()
            // action['view_id'] = self.env.ref('mass_mailing_sms.mailing_mailing_view_form_mixed').id
            // return action
            */
            return default;
        }

        public async Task<TEntity> MessagePostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def message_post(self, *, parent_id=False, subtype_id=False, **kwargs):
            // """ Temporary workaround to avoid spam. If someone replies on a channel
            // through the 'Presentation Published' email, it should be considered as a
            // note as we don't want all channel followers to be notified of this answer. """
            // self.ensure_one()
            // if parent_id:
            //     parent_message = self.env['mail.message'].sudo().browse(parent_id)
            //     if parent_message.subtype_id and parent_message.subtype_id == self.env.ref('website_blog.mt_blog_blog_published'):
            //         subtype_id = self.env.ref('mail.mt_note').id
            // return super(Blog, self).message_post(parent_id=parent_id, subtype_id=subtype_id, **kwargs)
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
            */
            return default;
        }

        public async Task<TEntity> MoveCategorySlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object category, object new_category) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=None):
            // """ Add access button to everyone if the document is published. """
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

        public async Task<TEntity> NotifyThreadByInboxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object recipients_data, object msg_vals) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _notify_thread_by_inbox(self, message, recipients_data, msg_vals=False, **kwargs):
            // """ Override to avoid keeping all notified recipients of a comment.
            // We avoid tracking needaction on post comments. Only emails should be
            // sufficient. """
            // if msg_vals is None:
            //     msg_vals = {}
            // if msg_vals.get('message_type', message.message_type) == 'comment':
            //     return
            // return super(BlogPost, self)._notify_thread_by_inbox(message, recipients_data, msg_vals=msg_vals, **kwargs)
            */
            return default;
        }

        public async Task<TEntity> OpenWebsiteUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def open_website_url(self):
            // """ Overridden to use a relative URL instead of an absolute when website_id is False. """
            // if self.website_id:
            //     return super().open_website_url()
            // return self.env['website'].get_client_action(f'/slides/{self.env["ir.http"]._slug(self)}')
            */
            return default;
        }

        public async Task<TEntity> RatingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> RedirectToCompletedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_redirect_to_completed_members(self):
            // return self.action_redirect_to_members('completed')
            */
            return default;
        }

        public async Task<TEntity> RedirectToEngagedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_redirect_to_engaged_members(self):
            // return self.action_redirect_to_members('engaged')
            */
            return default;
        }

        public async Task<TEntity> RedirectToInvitedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_redirect_to_invited_members(self):
            // return self.action_redirect_to_members('invited')
            */
            return default;
        }

        public async Task<TEntity> RedirectToMembersAsync<TEntity>(IEnumerable<TEntity> entities, object status_filter) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> RefuseAccessAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> RemoveMembershipInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> RequestAccessAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> ResequenceSlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slide, object force_category) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> SearchAddressSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _search_address_search(self, operator, value):
            // if operator != 'ilike' or not isinstance(value, str):
            //     raise NotImplementedError(_('Operation not supported.'))
            // 
            // return expression.OR([
            //     [('address_id.name', 'ilike', value)],
            //     [('address_id.street', 'ilike', value)],
            //     [('address_id.street2', 'ilike', value)],
            //     [('address_id.city', 'ilike', value)],
            //     [('address_id.zip', 'ilike', value)],
            //     [('address_id.state_id', 'ilike', value)],
            //     [('address_id.country_id', 'ilike', value)],
            // ])
            */
            return default;
        }

        public async Task<TEntity> SearchBuildDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _search_build_dates(self):
            // today = fields.Datetime.today()
            // 
            // def sdn(date):
            //     return fields.Datetime.to_string(date.replace(hour=23, minute=59, second=59))
            // 
            // def sd(date):
            //     return fields.Datetime.to_string(date)
            // 
            // def get_month_filter_domain(filter_name, months_delta):
            //     first_day_of_the_month = today.replace(day=1)
            //     filter_string = _('This month') if months_delta == 0 \
            //         else format_date(self.env, value=today + relativedelta(months=months_delta),
            //             date_format='LLLL', lang_code=get_lang(self.env).code).capitalize()
            //     return [filter_name, filter_string, [
            //         ("date_end", ">=", sd(first_day_of_the_month + relativedelta(months=months_delta))),
            //         ("date_begin", "<", sd(first_day_of_the_month + relativedelta(months=months_delta+1)))],
            //         0]
            // 
            // return [
            //     ['upcoming', _('Upcoming Events'), [("date_end", ">", sd(today))], 0],
            //     ['today', _('Today'), [
            //         ("date_end", ">", sd(today)),
            //         ("date_begin", "<", sdn(today))],
            //         0],
            //     get_month_filter_domain('month', 0),
            //     ['old', _('Past Events'), [
            //         ("date_end", "<", sd(today))],
            //         0],
            //     ['all', _('All Events'), [], 0]
            // ]
            */
            return default;
        }

        public async Task<TEntity> SearchGetDetailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website, object order, object options) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _search_get_detail(self, website, order, options):
            // with_description = options['displayDescription']
            // search_fields = ['name']
            // fetch_fields = ['id', 'name']
            // mapping = {
            //     'name': {'name': 'name', 'type': 'text', 'match': True},
            //     'website_url': {'name': 'url', 'type': 'text', 'truncate': False},
            // }
            // if with_description:
            //     search_fields.append('subtitle')
            //     fetch_fields.append('subtitle')
            //     mapping['description'] = {'name': 'subtitle', 'type': 'text', 'match': True}
            // return {
            //     'model': 'blog.blog',
            //     'base_domain': [website.website_domain()],
            //     'search_fields': search_fields,
            //     'fetch_fields': fetch_fields,
            //     'mapping': mapping,
            //     'icon': 'fa-rss-square',
            //     'order': 'name desc, id desc' if 'name desc' in order else 'name asc, id desc',
            // }
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _search_get_detail(self, website, order, options):
            // with_description = options['displayDescription']
            // with_date = options['displayDetail']
            // blog = options.get('blog')
            // tags = options.get('tag')
            // date_begin = options.get('date_begin')
            // date_end = options.get('date_end')
            // state = options.get('state')
            // domain = [website.website_domain()]
            // if blog:
            //     domain.append([('blog_id', '=', self.env['ir.http']._unslug(blog)[1])])
            // if tags:
            //     active_tag_ids = [self.env['ir.http']._unslug(tag)[1] for tag in tags.split(',')] or []
            //     if active_tag_ids:
            //         domain.append([('tag_ids', 'in', active_tag_ids)])
            // if date_begin and date_end:
            //     domain.append([("post_date", ">=", date_begin), ("post_date", "<=", date_end)])
            // if self.env.user.has_group('website.group_website_designer'):
            //     if state == "published":
            //         domain.append([("website_published", "=", True), ("post_date", "<=", fields.Datetime.now())])
            //     elif state == "unpublished":
            //         domain.append(['|', ("website_published", "=", False), ("post_date", ">", fields.Datetime.now())])
            // else:
            //     domain.append([("post_date", "<=", fields.Datetime.now())])
            // search_fields = ['name', 'author_name']
            // def search_in_tags(env, search_term):
            //     tags_like_search = env['blog.tag'].search([('name', 'ilike', search_term)])
            //     return [('tag_ids', 'in', tags_like_search.ids)]
            // fetch_fields = ['name', 'website_url']
            // mapping = {
            //     'name': {'name': 'name', 'type': 'text', 'match': True},
            //     'website_url': {'name': 'website_url', 'type': 'text', 'truncate': False},
            // }
            // if with_description:
            //     search_fields.append('content')
            //     fetch_fields.append('content')
            //     mapping['description'] = {'name': 'content', 'type': 'text', 'html': True, 'match': True}
            // if with_date:
            //     fetch_fields.append('published_date')
            //     mapping['detail'] = {'name': 'published_date', 'type': 'date'}
            // return {
            //     'model': 'blog.post',
            //     'base_domain': domain,
            //     'search_fields': search_fields,
            //     'search_extra': search_in_tags,
            //     'fetch_fields': fetch_fields,
            //     'mapping': mapping,
            //     'icon': 'fa-rss',
            // }
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _search_get_detail(self, website, order, options):
            // with_description = options['displayDescription']
            // with_date = options['displayDetail']
            // date = options.get('date', 'all')
            // country = options.get('country')
            // tags = options.get('tags')
            // event_type = options.get('type', 'all')
            // 
            // domain = [website.website_domain()]
            // domain.append([('is_visible_on_website', '=', True)])
            // 
            // if event_type != 'all':
            //     domain.append([("event_type_id", "=", int(event_type))])
            // search_tags = self.env['event.tag']
            // if tags:
            //     try:
            //         tag_ids = literal_eval(tags)
            //     except SyntaxError:
            //         pass
            //     else:
            //         # perform a search to filter on existing / valid tags implicitely + apply rules on color
            //         search_tags = self.env['event.tag'].search([('id', 'in', tag_ids)])
            // 
            //     # Example: You filter on age: 10-12 and activity: football.
            //     # Doing it this way allows to only get events who are tagged "age: 10-12" AND "activity: football".
            //     # Add another tag "age: 12-15" to the search and it would fetch the ones who are tagged:
            //     # ("age: 10-12" OR "age: 12-15") AND "activity: football
            //     for tags in search_tags.grouped('category_id').values():
            //         domain.append([('tag_ids', 'in', tags.ids)])
            // 
            // no_country_domain = domain.copy()
            // if country:
            //     if country == 'online':
            //         domain.append([("country_id", "=", False)])
            //     elif country != 'all':
            //         domain.append([("country_id", "=", int(country))])
            // 
            // no_date_domain = domain.copy()
            // dates = self._search_build_dates()
            // current_date = None
            // for date_details in dates:
            //     if date == date_details[0]:
            //         domain.append(date_details[2])
            //         no_country_domain.append(date_details[2])
            //         if date_details[0] != 'upcoming':
            //             current_date = date_details[1]
            // 
            // search_fields = ['name']
            // fetch_fields = ['name', 'website_url', 'address_name']
            // mapping = {
            //     'name': {'name': 'name', 'type': 'text', 'match': True},
            //     'website_url': {'name': 'website_url', 'type': 'text', 'truncate': False},
            //     'address_name': {'name': 'address_name', 'type': 'text', 'match': True},
            // }
            // if with_description:
            //     search_fields.append('subtitle')
            //     fetch_fields.append('subtitle')
            //     mapping['description'] = {'name': 'subtitle', 'type': 'text', 'match': True}
            // if with_date:
            //     mapping['detail'] = {'name': 'range', 'type': 'html'}
            // 
            // # Bypassing the access rigths of partner to search the address.
            // def search_in_address(env, search_term):
            //     ret = env['event.event'].sudo()._search([
            //        ('address_search', 'ilike', search_term),
            //     ])
            //     return [('id', 'in', ret)]
            // 
            // return {
            //     'model': 'event.event',
            //     'base_domain': domain,
            //     'search_fields': search_fields,
            //     'search_extra': search_in_address,
            //     'fetch_fields': fetch_fields,
            //     'mapping': mapping,
            //     'icon': 'fa-ticket',
            //     # for website_event main controller:
            //     'dates': dates,
            //     'current_date': current_date,
            //     'search_tags': search_tags,
            //     'no_date_domain': no_date_domain,
            //     'no_country_domain': no_country_domain,
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
            */
            return default;
        }

        public async Task<TEntity> SearchIsFinishedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _search_is_finished(self, operator, value):
            // if operator not in ['=', '!=']:
            //     raise ValueError(_('This operator is not supported'))
            // if not isinstance(value, bool):
            //     raise ValueError(_('Value should be True or False (not %s)'), value)
            // now = fields.Datetime.now()
            // if (operator == '=' and value) or (operator == '!=' and not value):
            //     domain = [('date_end', '<=', now)]
            // else:
            //     domain = [('date_end', '>', now)]
            // return domain
            */
            return default;
        }

        public async Task<TEntity> SearchIsMemberChannelIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invited) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> SearchIsMemberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> SearchIsMemberInvitedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> SearchIsOngoingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _search_is_ongoing(self, operator, value):
            // if operator not in ['=', '!=']:
            //     raise UserError(_('This operator is not supported'))
            // if not isinstance(value, bool):
            //     raise UserError(_('Value should be True or False (not %s)', value))
            // now = fields.Datetime.now()
            // if (operator == '=' and value) or (operator == '!=' and not value):
            //     domain = [('date_begin', '<=', now), ('date_end', '>', now)]
            // else:
            //     domain = ['|', ('date_begin', '>', now), ('date_end', '<=', now)]
            // return domain
            */
            return default;
        }

        public async Task<TEntity> SearchIsParticipatingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _search_is_participating(self, operator, value):
            // if operator not in ['=', '!=']:
            //     raise NotImplementedError(_('This operator is not supported'))
            // if not isinstance(value, bool):
            //     raise UserError(_('Value should be True or False (not %)', value))
            // check_is_participating = operator == '=' and value or operator == '!=' and not value
            // 
            // return [('id', 'in' if check_is_participating else 'not in', self._fetch_is_participating_events().ids)]
            */
            return default;
        }

        public async Task<TEntity> SearchIsVisibleOnWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _search_is_visible_on_website(self, operator, value):
            // if operator not in ['=', '!=']:
            //     raise NotImplementedError(_('This operator is not supported'))
            // if not isinstance(value, bool):
            //     raise UserError(_('Value should be True or False (not %)', value))
            // check_is_visible_on_website = operator == '=' and value or operator == '!=' and not value
            // user = self.env.user
            // domain = [('is_participating', '=', True)]
            // 
            // if not user._is_public():
            //     domain = expression.OR([domain, [('website_visibility', 'in', ['public', 'logged_users'])]])
            // else:
            //     domain = expression.OR([domain, [('website_visibility', '=', 'public')]])
            // 
            // event_ids = self.env['event.event']._search(domain)
            // return [('id', 'in' if check_is_visible_on_website else 'not in', event_ids)]
            */
            return default;
        }

        public async Task<TEntity> SearchPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> SearchRenderResultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fetch_fields, object mapping, object icon, object limit) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _search_render_results(self, fetch_fields, mapping, icon, limit):
            // results_data = super()._search_render_results(fetch_fields, mapping, icon, limit)
            // for data in results_data:
            //     data['url'] = '/blog/%s' % data['id']
            // return results_data
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _search_render_results(self, fetch_fields, mapping, icon, limit):
            // with_date = 'detail' in mapping
            // results_data = super()._search_render_results(fetch_fields, mapping, icon, limit)
            // if with_date:
            //     for event, data in zip(self, results_data):
            //         begin = self.env['ir.qweb.field.date'].record_to_html(event, 'date_begin', {})
            //         end = self.env['ir.qweb.field.date'].record_to_html(event, 'date_end', {})
            //         data['range'] = (
            //             Markup('{} <i class="fa fa-long-arrow-right"></i> {}').format(begin, end)
            //             if begin != end else begin
            //         )
            // return results_data
            */
            return default;
        }

        public async Task<TEntity> SendShareEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object emails) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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
            */
            return default;
        }

        public async Task<TEntity> SetDoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def action_set_done(self):
            // """
            // Action which will move the events
            // into the first next (by sequence) stage defined as "Ended"
            // (if they are not already in an ended stage)
            // """
            // first_ended_stage = self.env['event.stage'].search([('pipe_end', '=', True)], limit=1, order='sequence')
            // if first_ended_stage:
            //     self.write({'stage_id': first_ended_stage.id})
            */
            return default;
        }

        public async Task<TEntity> SetPostDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _set_post_date(self):
            // for blog_post in self:
            //     blog_post.published_date = blog_post.post_date
            //     if not blog_post.published_date:
            //         blog_post.post_date = blog_post.create_date
            */
            return default;
        }

        public async Task<TEntity> SetTeaserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _set_teaser(self):
            // for blog_post in self:
            //     if not blog_post.with_context(lang='en_US').teaser_manual:
            //         # By default, if no teaser is set in english, it will use the
            //         # first 200 characters of the content. We don't want to break
            //         # that when adding a manual teaser in a translation.
            //         # That's how the ORM work: when setting a translation value, if
            //         # there is no source value, the source will also receive the
            //         # translation value
            //         blog_post.update_field_translations('teaser_manual', {'en_US': ''})
            //     blog_post.teaser_manual = blog_post.teaser
            */
            return default;
        }

        public async Task<TEntity> SetTzContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _set_tz_context(self):
            // self.ensure_one()
            // return self.with_context(tz=self.date_tz or 'UTC')
            */
            return default;
        }

        public async Task<TEntity> SplitMenusStateByFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _split_menus_state_by_field(self):
            // """ For each field linked to a menu, get the set of events having this
            // menu activated and de-activated. Purpose is to find those whose value
            // changed and update the underlying menus.
            // 
            // :return dict: key = name of field triggering a website menu update, get {
            //   'activated': subset of self having its menu currently set to True
            //   'deactivated': subset of self having its menu currently set to False
            // } """
            // menus_state_by_field = dict()
            // for fname in self._get_menu_update_fields():
            //     activated = self.filtered(lambda event: event[fname])
            //     menus_state_by_field[fname] = {
            //         'activated': activated,
            //         'deactivated': self - activated,
            //     }
            // return menus_state_by_field
            */
            return default;
        }

        public async Task<TEntity> ToggleActiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
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
            */
            return default;
        }

        public async Task<TEntity> ToggleBoothMenuAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_booth, FILE: event_event.py) ---
            // def toggle_booth_menu(self, val):
            // self.booth_menu = val
            */
            return default;
        }

        public async Task<TEntity> ToggleExhibitorMenuAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py) ---
            // def toggle_exhibitor_menu(self, val):
            // self.exhibitor_menu = val
            */
            return default;
        }

        public async Task<TEntity> ToggleWebsiteMenuAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def toggle_website_menu(self, val):
            // self.website_menu = val
            */
            return default;
        }

        public async Task<TEntity> ToggleWebsiteTrackAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def toggle_website_track(self, val):
            // self.website_track = val
            */
            return default;
        }

        public async Task<TEntity> ToggleWebsiteTrackProposalAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def toggle_website_track_proposal(self, val):
            // self.website_track_proposal = val
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // if init_values.keys() & {'is_published', 'website_published'}:
            //     if self.is_published:
            //         return self.env.ref('website_event.mt_event_published', raise_if_not_found=False)
            //     return self.env.ref('website_event.mt_event_unpublished', raise_if_not_found=False)
            // return super(Event, self)._track_subtype(init_values)
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
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
            */
            return default;
        }

        public async Task<TEntity> UpdateWebsiteMenuEntryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname_bool, object fname_o2m, object fmenu_type) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _update_website_menu_entry(self, fname_bool, fname_o2m, fmenu_type):
            // """ Generic method to create menu entries based on a flag on event. This
            // method is a bit obscure, but is due to preparation of adding new menus
            // entries and pages for event in a stable version, leading to some constraints
            // while developing.
            // 
            // :param fname_bool: field name (e.g. website_track)
            // :param fname_o2m: o2m linking towards website.event.menu matching the
            //   boolean fields (normally an entry of website.event.menu with type matching
            //   the boolean field name)
            // :param method_name: method returning menu entries information: url, sequence, ...
            // """
            // self.ensure_one()
            // new_menu = None
            // 
            // menu_data = [menu_info for menu_info in self._get_website_menu_entries()
            //              if menu_info[4] == fmenu_type]
            // if self[fname_bool] and not self[fname_o2m]:
            //     # menus not found but boolean True: get menus to create
            //     for name, url, xml_id, menu_sequence, menu_type in menu_data:
            //         new_menu = self._create_menu(menu_sequence, name, url, xml_id, menu_type)
            // elif not self[fname_bool]:
            //     # will cascade delete to the website.event.menu
            //     self[fname_o2m].mapped('menu_id').sudo().unlink()
            // 
            // return new_menu
            */
            return default;
        }

        public async Task<TEntity> UpdateWebsiteMenusInternalAsync<TEntity>(IEnumerable<TEntity> entities, object menus_update_by_field) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _update_website_menus(self, menus_update_by_field=None):
            // """ Synchronize event configuration and its menu entries for frontend.
            // 
            // :param menus_update_by_field: see ``_get_menus_update_by_field``"""
            // for event in self:
            //     if event.menu_id and not event.website_menu:
            //         # do not rely on cascade, as it is done in SQL -> not calling override and
            //         # letting some ir.ui.views in DB
            //         (event.menu_id + event.menu_id.child_id).sudo().unlink()
            //     elif event.website_menu and not event.menu_id:
            //         root_menu = self.env['website.menu'].sudo().create({'name': event.name, 'website_id': event.website_id.id})
            //         event.menu_id = root_menu
            //     if event.menu_id and (not menus_update_by_field or event in menus_update_by_field.get('community_menu')):
            //         event._update_website_menu_entry('community_menu', 'community_menu_ids', 'community')
            //     if event.menu_id and (not menus_update_by_field or event in menus_update_by_field.get('introduction_menu')):
            //         event._update_website_menu_entry('introduction_menu', 'introduction_menu_ids', 'introduction')
            //     if event.menu_id and (not menus_update_by_field or event in menus_update_by_field.get('location_menu')):
            //         event._update_website_menu_entry('location_menu', 'location_menu_ids', 'location')
            //     if event.menu_id and (not menus_update_by_field or event in menus_update_by_field.get('register_menu')):
            //         event._update_website_menu_entry('register_menu', 'register_menu_ids', 'register')
            */
            return default;
        }

        public async Task<TEntity> ViewLinkedOrdersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: event_event.py) ---
            // def action_view_linked_orders(self):
            // """ Redirects to the orders linked to the current events """
            // sale_order_action = self.env["ir.actions.actions"]._for_xml_id("sale.action_orders")
            // sale_order_action.update({
            //     'domain': [('state', '!=', 'cancel'), ('order_line.event_id', 'in', self.ids)],
            //     'context': {'create': 0},
            // })
            // return sale_order_action
            */
            return default;
        }

        public async Task<TEntity> ViewRatingsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> ViewSlidesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
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

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: mixins.py) ---
            // def write(self, vals):
            // if 'cover_properties' not in vals:
            //     return super().write(vals)
            // 
            // cover_properties = json_safe.loads(vals['cover_properties'])
            // resize_classes = cover_properties.get('resize_class', '').split()
            // classes = ['o_half_screen_height', 'o_full_screen_height', 'cover_auto']
            // if not set(resize_classes).isdisjoint(classes):
            //     # Updating cover properties and the given 'resize_class' set is
            //     # valid, normal write.
            //     return super().write(vals)
            // 
            // # If we do not receive a valid resize_class via the cover_properties, we
            // # keep the original one (prevents updates on list displays from
            // # destroying resize_class).
            // copy_vals = dict(vals)
            // for item in self:
            //     old_cover_properties = json_safe.loads(item.cover_properties)
            //     cover_properties['resize_class'] = old_cover_properties.get('resize_class', classes[0])
            //     copy_vals['cover_properties'] = json_safe.dumps(cover_properties)
            //     super(WebsiteCoverPropertiesMixin, item).write(copy_vals)
            // return True
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def write(self, vals):
            // res = super(Blog, self).write(vals)
            // if 'active' in vals:
            //     # archiving/unarchiving a blog does it on its posts, too
            //     post_ids = self.env['blog.post'].with_context(active_test=False).search([
            //         ('blog_id', 'in', self.ids)
            //     ])
            //     for blog_post in post_ids:
            //         blog_post.active = vals['active']
            // return res
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def write(self, vals):
            // result = True
            // # archiving a blog post, unpublished the blog post
            // if 'active' in vals and not vals['active']:
            //     vals['is_published'] = False
            // for post in self:
            //     copy_vals = dict(vals)
            //     published_in_vals = set(vals.keys()) & {'is_published', 'website_published'}
            //     if (published_in_vals and 'published_date' not in vals and
            //             (not post.published_date or post.published_date <= fields.Datetime.now())):
            //         copy_vals['published_date'] = vals[list(published_in_vals)[0]] and fields.Datetime.now() or False
            //     result &= super(BlogPost, post).write(copy_vals)
            // self._check_for_publication(vals)
            // return result
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def write(self, vals):
            // menus_state_by_field = self._split_menus_state_by_field()
            // res = super(Event, self).write(vals)
            // menus_update_by_field = self._get_menus_update_by_field(menus_state_by_field, force_update=vals.keys())
            // self._update_website_menus(menus_update_by_field=menus_update_by_field)
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
            */
            return default;
        }
    }
}