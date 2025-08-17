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
    public class WebsiteSearchableMixinAppService : ApplicationService, IWebsiteSearchableMixinAppService
    {

        public WebsiteSearchableMixinAppService() 
        {

        }

        public async Task<TEntity> ActionAddMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_partners, object member_status, object raise_on_access) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ActionChannelOpenInviteWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mail_template, object enroll_mode) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ActionLoadRecruitmentScenarioInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _action_load_recruitment_scenario(self):
            // 
            // convert_file(
            //     self.sudo().env,
            //     "hr_recruitment",
            //     "data/scenarios/hr_recruitment_scenario.xml",
            //     None,
            //     mode="init",
            //     kind="data",
            // )
            // 
            // return {
            //     "type": "ir.actions.client",
            //     "tag": "reload",
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionMarkCompletedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ActionRequestAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ActionSetQuizDoneInternalAsync<TEntity>(IEnumerable<TEntity> entities, object completed) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ActionSetViewedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_partner, object quiz_attempts_inc) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ActionVoteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object upvote) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> AddGroupsMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _add_groups_members(self):
            // for channel in self:
            //     channel._action_add_members(channel.mapped('enroll_group_ids.users.partner_id'))
            */
            return default;
        }

        public async Task<TEntity> AddressIdDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _address_id_domain(self):
            // return ['|', '&', '&', ('type', '!=', 'contact'), ('type', '!=', 'private'),
            //         ('id', 'in', self.sudo().env.companies.partner_id.child_ids.ids),
            //         ('id', 'in', self.sudo().env.companies.partner_id.ids)]
            */
            return default;
        }

        public async Task<TEntity> AliasGetCreationValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _alias_get_creation_values(self):
            // values = super()._alias_get_creation_values()
            // values['alias_model_id'] = self.env['ir.model']._get('hr.applicant').id
            // if self.id:
            //     values['alias_defaults'] = defaults = ast.literal_eval(self.alias_defaults or "{}")
            //     defaults.update({
            //         'job_id': self.id,
            //         'department_id': self.department_id.id,
            //         'company_id': self.department_id.company_id.id if self.department_id else self.company_id.id,
            //         'user_id': self.user_id.id,
            //     })
            // return values
            */
            return default;
        }

        public async Task<TEntity> AllTagsAsync<TEntity>(IEnumerable<TEntity> entities, object @join, object min_limit) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ApplyTaxesToPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price, object currency, object product_taxes, object taxes, object product_or_template, object website) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _apply_taxes_to_price(
            //     self, price, currency, product_taxes, taxes, product_or_template,
            //     website=None,
            // ):
            //     website = website or self.env['website'].get_current_website()
            //     price = self.env['product.product']._get_tax_included_unit_price_from_price(
            //         price,
            //         product_taxes,
            //         product_taxes_after_fp=taxes,
            //     )
            //     show_tax = website.show_line_subtotals_tax_selection
            //     tax_display = 'total_excluded' if show_tax == 'tax_excluded' else 'total_included'
            // 
            //     # The list_price is always the price of one.
            //     return taxes.compute_all(
            //         price, currency, 1, product_or_template, self.env.user.partner_id
            //     )[tax_display]
            */
            return default;
        }

        public async Task<TEntity> ArchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def action_archive(self):
            // filtered_products = self.env['mrp.bom.line'].search([('product_id', 'in', self.product_variant_ids.ids), ('bom_id.active', '=', True)]).product_id.mapped('display_name')
            // res = super().action_archive()
            // if filtered_products:
            //     return {
            //         'type': 'ir.actions.client',
            //         'tag': 'display_notification',
            //         'params': {
            //         'title': _("Note that product(s): '%s' is/are still linked to active Bill of Materials, "
            //                     "which means that the product can still be used on it/them.", filtered_products),
            //         'type': 'warning',
            //         'sticky': True,  #True/False will display for few seconds if false
            //         'next': {'type': 'ir.actions.act_window_close'},
            //         },
            //     }
            // return res
            */
            return default;
        }

        public async Task<TEntity> AutoInitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: product_template.py) ---
            // def _auto_init(self):
            // if not column_exists(self.env.cr, "product_template", "can_be_expensed"):
            //     create_column(self.env.cr, "product_template", "can_be_expensed", "boolean")
            //     self.env.cr.execute(
            //         """
            //         UPDATE product_template
            //         SET can_be_expensed = false
            //         WHERE type NOT IN ('consu', 'service')
            //         """
            //     )
            // return super()._auto_init()
            */
            return default;
        }

        public async Task<TEntity> BomCostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: product.py) ---
            // def action_bom_cost(self):
            // templates = self.filtered(lambda t: t.product_variant_count == 1 and t.bom_count > 0)
            // if templates:
            //     return templates.mapped('product_variant_id').action_bom_cost()
            */
            return default;
        }

        public async Task<TEntity> ButtonBomCostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: product.py) ---
            // def button_bom_cost(self):
            // templates = self.filtered(lambda t: t.product_variant_count == 1 and t.bom_count > 0)
            // if templates:
            //     return templates.mapped('product_variant_id').button_bom_cost()
            */
            return default;
        }

        public async Task<TEntity> CanBeAddedToCartInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _can_be_added_to_cart(self):
            // """
            // Pre-check to `_is_add_to_cart_possible` to know if product can be sold.
            // """
            // return self.sale_ok
            */
            return default;
        }

        public async Task<TEntity> CartesianProductInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_template_attribute_values_per_line, object parent_combination) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ChannelEnrollAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_channel_enroll(self):
            // template = self.env.ref('website_slides.mail_template_slide_channel_enroll', raise_if_not_found=False)
            // return self._action_channel_open_invite_wizard(template, enroll_mode=True)
            */
            return default;
        }

        public async Task<TEntity> ChannelInviteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_channel_invite(self):
            // template = self.env.ref('website_slides.mail_template_slide_channel_invite', raise_if_not_found=False)
            // return self._action_channel_open_invite_wizard(template)
            */
            return default;
        }

        public async Task<TEntity> CheckBarcodeUniquenessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _check_barcode_uniqueness(self):
            // for template in self:
            //     template.product_variant_ids._check_barcode_uniqueness()
            */
            return default;
        }

        public async Task<TEntity> CheckClosingDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> CheckComboIdsNotEmptyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> CheckComboInclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product.py) ---
            // def _check_combo_inclusions(self):
            // for product in self:
            //     if not product.available_in_pos:
            //         combo_name = self.env['product.combo.item'].sudo().search([('product_id', 'in', product.product_variant_ids.ids)], limit=1).combo_id.name
            //         if combo_name:
            //             raise UserError(_('You must first remove this product from the %s combo', combo_name))
            */
            return default;
        }

        public async Task<TEntity> CheckForPublicationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> CheckIncompatibleTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _check_incompatible_types(self):
            // incompatible_types = self._get_incompatible_types()
            // if len(incompatible_types) < 2:
            //     return
            // fields = self.env['ir.model.fields'].sudo().search_read(
            //     [('model', '=', 'product.template'), ('name', 'in', incompatible_types)],
            //     ['name', 'field_description'])
            // field_descriptions = {v['name']: v['field_description'] for v in fields}
            // field_list = incompatible_types + ['name']
            // values = self.read(field_list)
            // for val in values:
            //     incompatible_fields = [f for f in incompatible_types if val[f]]
            //     if len(incompatible_fields) > 1:
            //         raise ValidationError(_(
            //             "The product (%(product)s) has incompatible values: %(value_list)s",
            //             product=val['name'],
            //             value_list=format_list(self.env, [field_descriptions[v] for v in incompatible_fields]),
            //         ))
            */
            return default;
        }

        public async Task<TEntity> CheckParentIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py) ---
            // def check_parent_id(self):
            // if self._has_cycle():
            //     raise ValueError(self.env._("Error! You cannot create recursive categories."))
            */
            return default;
        }

        public async Task<TEntity> CheckParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _check_parent_id(self):
            // if self._has_cycle():
            //     raise ValidationError(_('You cannot create recursive forum posts.'))
            */
            return default;
        }

        public async Task<TEntity> CheckPrintImagesAreSetBeforePublishingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_gelato, FILE: product_template.py) ---
            // def _check_print_images_are_set_before_publishing(self):
            // for product in self.filtered('gelato_template_ref'):
            //     if product.is_published and product.gelato_missing_images:
            //         raise ValidationError(
            //             _("Print images must be set on products before they can be published.")
            //         )
            */
            return default;
        }

        public async Task<TEntity> CheckProjectAndTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _check_project_and_template(self):
            // """ NOTE 'service_tracking' should be in decorator parameters but since ORM check constraints twice (one after setting
            //     stored fields, one after setting non stored field), the error is raised when company-dependent fields are not set.
            //     So, this constraints does cover all cases and inconsistent can still be recorded until the ORM change its behavior.
            // """
            // for product in self:
            //     if product.service_tracking == 'no' and (product.project_id or product.project_template_id):
            //         raise ValidationError(_('The product %s should not have a project nor a project template since it will not generate project.', product.name))
            //     elif product.service_tracking == 'task_global_project' and product.project_template_id:
            //         raise ValidationError(_('The product %s should not have a project template since it will generate a task in a global project.', product.name))
            //     elif product.service_tracking in ['task_in_project', 'project_only'] and product.project_id:
            //         raise ValidationError(_('The product %s should not have a global project since it will generate a project.', product.name))
            */
            return default;
        }

        public async Task<TEntity> CheckSaleComboIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> CheckSaleProductCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _check_sale_product_company(self):
            // """Ensure the product is not being restricted to a single company while
            // having been sold in another one in the past, as this could cause issues."""
            // products_by_compagny = defaultdict(lambda: self.env['product.template'])
            // for product in self:
            //     if not product.product_variant_ids or not product.company_id:
            //         # No need to check if the product has just being created (`product_variant_ids` is
            //         # still empty) or if we're writing `False` on its company (should always work.)
            //         continue
            //     products_by_compagny[product.company_id] |= product
            // 
            // for target_company, products in products_by_compagny.items():
            //     subquery_products = self.env['product.product'].sudo().with_context(active_test=False)._search([('product_tmpl_id', 'in', products.ids)])
            //     so_lines = self.env['sale.order.line'].sudo().search_read(
            //         [('product_id', 'in', subquery_products), '!', ('company_id', 'child_of', target_company.id)],
            //         fields=['id', 'product_id'])
            //     if so_lines:
            //         used_products = [sol['product_id'][1] for sol in so_lines]
            //         raise ValidationError(_('The following products cannot be restricted to the company'
            //                                 ' %(company)s because they have already been used in quotations or '
            //                                 'sales orders in another company:\n%(used_products)s\n'
            //                                 'You can archive these products and recreate them '
            //                                 'with your company restriction instead, or leave them as '
            //                                 'shared product.', company=target_company.name, used_products=', '.join(used_products)))
            */
            return default;
        }

        public async Task<TEntity> CheckSeatsAvailabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object minimal_availability) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> CheckServiceToPurchaseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_purchase, FILE: product_template.py) ---
            // def _check_service_to_purchase(self):
            // for template in self:
            //     if template.service_to_purchase:
            //         if template.type != 'service':
            //             raise ValidationError(_("Product that is not a service can not create RFQ."))
            //         template._check_vendor_for_service_to_purchase(template.seller_ids)
            */
            return default;
        }

        public async Task<TEntity> CheckUomInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _check_uom(self):
            // if any(template.uom_id and template.uom_po_id and template.uom_id.category_id != template.uom_po_id.category_id for template in self):
            //     raise ValidationError(_('The default Unit of Measure and the purchase Unit of Measure must be in the same category.'))
            */
            return default;
        }

        public async Task<TEntity> CheckUomNotInInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _check_uom_not_in_invoice(self):
            // self.env['product.template'].flush_model(['uom_id'])
            // self._cr.execute("""
            //     SELECT prod_template.id
            //       FROM account_move_line line
            //       JOIN product_product prod_variant ON line.product_id = prod_variant.id
            //       JOIN product_template prod_template ON prod_variant.product_tmpl_id = prod_template.id
            //       JOIN uom_uom template_uom ON prod_template.uom_id = template_uom.id
            //       JOIN uom_category template_uom_cat ON template_uom.category_id = template_uom_cat.id
            //       JOIN uom_uom line_uom ON line.product_uom_id = line_uom.id
            //       JOIN uom_category line_uom_cat ON line_uom.category_id = line_uom_cat.id
            //      WHERE prod_template.id IN %s
            //        AND line.parent_state = 'posted'
            //        AND template_uom_cat.id != line_uom_cat.id
            //      LIMIT 1
            // """, [tuple(self.ids)])
            // if self._cr.fetchall():
            //     raise ValidationError(_(
            //         "This product is already being used in posted Journal Entries.\n"
            //         "If you want to change its Unit of Measure, please archive this product and create a new one."
            //     ))
            */
            return default;
        }

        public async Task<TEntity> CheckUserHasModelAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_controller_page.py) ---
            // def _check_user_has_model_access(self):
            // for record in self:
            //     self.env[record.model_id.model].check_access('read')
            */
            return default;
        }

        public async Task<TEntity> CheckVendorForServiceToPurchaseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sellers) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_purchase, FILE: product_template.py) ---
            // def _check_vendor_for_service_to_purchase(self, sellers):
            // if not sellers:
            //     raise ValidationError(_("Please define the vendor from whom you would like to purchase this service automatically."))
            */
            return default;
        }

        public async Task<TEntity> CheckWebsiteIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ClonePageAsync<TEntity>(IEnumerable<TEntity> entities, Guid page_id, object page_name, object clone_menu) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def clone_page(self, page_id, page_name=None, clone_menu=True):
            // """ Clone a page, given its identifier
            //     :param page_id : website.page identifier
            // """
            // page = self.browse(int(page_id))
            // copy_param = dict(name=page_name or page.name, website_id=self.env['website'].get_current_website().id)
            // if page_name:
            //     url = '/' + self.env['ir.http']._slugify(page_name, max_length=1024, path=True)
            //     copy_param['url'] = self.env['website'].get_unique_path(url)
            // 
            // new_page = page.copy(copy_param)
            // # Should not clone menu if the page was cloned from one website to another
            // # Eg: Cloning a generic page (no website) will create a page with a website, we can't clone menu (not same container)
            // if clone_menu and new_page.website_id == page.website_id:
            //     menu = self.env['website.menu'].search([('page_id', '=', page_id)], limit=1)
            //     if menu:
            //         # If the page being cloned has a menu, clone it too
            //         menu.copy({'url': new_page.url, 'name': new_page.name, 'page_id': new_page.id})
            // 
            // return new_page.url
            */
            return default;
        }

        public async Task<TEntity> CloseAsync<TEntity>(IEnumerable<TEntity> entities, Guid reason_id) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def close(self, reason_id):
            // if any(post.parent_id for post in self):
            //     return False
            // 
            // reason_offensive = self.env.ref('website_forum.reason_7').id
            // reason_spam = self.env.ref('website_forum.reason_8').id
            // if reason_id in (reason_offensive, reason_spam):
            //     for post in self:
            //         _logger.info('Downvoting user <%s> for posting spam/offensive contents',
            //                      post.create_uid)
            //         karma = post.forum_id.karma_gen_answer_flagged
            //         if reason_id == reason_spam:
            //             # If first post, increase the karma to remove
            //             count_post = post.search_count([('parent_id', '=', False), ('forum_id', '=', post.forum_id.id), ('create_uid', '=', post.create_uid.id)])
            //             if count_post == 1:
            //                 karma *= 10
            //         message = (
            //             _('Post is closed and marked as spam')
            //             if reason_id == reason_spam else
            //             _('Post is closed and marked as offensive content')
            //         )
            //         post.create_uid.sudo()._add_karma(karma, post, message)
            // 
            // self.write({
            //     'state': 'close',
            //     'closed_uid': self._uid,
            //     'closed_date': datetime.today().strftime(tools.DEFAULT_SERVER_DATETIME_FORMAT),
            //     'closed_reason_id': reason_id,
            // })
            // return True
            */
            return default;
        }

        public async Task<TEntity> CloseDialogAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def close_dialog(self):
            // return {'type': 'ir.actions.act_window_close'}
            */
            return default;
        }

        public async Task<TEntity> CompleteInverseExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object exclusions) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeActionRightsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeActivitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_activities(self):
            // self.env.cr.execute("""
            //     SELECT
            //         app.job_id,
            //         COUNT(*) AS act_count,
            //         CASE
            //             WHEN %(today)s::date - act.date_deadline::date = 0 THEN 'today'
            //             WHEN %(today)s::date - act.date_deadline::date > 0 THEN 'overdue'
            //         END AS act_state
            //      FROM mail_activity act
            //      JOIN hr_applicant app ON app.id = act.res_id
            //      JOIN hr_recruitment_stage sta ON app.stage_id = sta.id
            //     WHERE act.user_id = %(user_id)s AND act.res_model = 'hr.applicant'
            //       AND act.date_deadline <= %(today)s::date AND app.active
            //       AND app.job_id IN %(job_ids)s
            //       AND sta.hired_stage IS NOT TRUE
            //     GROUP BY app.job_id, act_state
            // """, {
            //     'today': fields.Date.context_today(self),
            //     'user_id': self.env.uid,
            //     'job_ids': tuple(self.ids),
            // })
            // job_activities = defaultdict(dict)
            // for activity in self.env.cr.dictfetchall():
            //     job_activities[activity['job_id']][activity['act_state']] = activity['act_count']
            // for job in self:
            //     job.activities_overdue = job_activities[job.id].get('overdue', 0)
            //     job.activities_today = job_activities[job.id].get('today', 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeAddressInlineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeAddressSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_address_search(self):
            // for event in self:
            //     event.address_search = event.address_id
            */
            return default;
        }

        public async Task<TEntity> ComputeAllApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_all_application_count(self):
            // read_group_result = self.env['hr.applicant'].with_context(active_test=False)._read_group([
            //     ('job_id', 'in', self.ids),
            //     '|',
            //         ('active', '=', True),
            //         '&',
            //         ('active', '=', False), ('refuse_reason_id', '!=', False),
            // ], ['job_id'], ['__count'])
            // result = {job.id: count for job, count in read_group_result}
            // for job in self:
            //     job.all_application_count = result.get(job.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicantHiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_applicant_hired(self):
            // hired_stages = self.env['hr.recruitment.stage'].search([('hired_stage', '=', True)])
            // hired_data = self.env['hr.applicant']._read_group([
            //     ('job_id', 'in', self.ids),
            //     ('stage_id', 'in', hired_stages.ids),
            // ], ['job_id'], ['__count'])
            // job_hires = {job.id: count for job, count in hired_data}
            // for job in self:
            //     job.applicant_hired = job_hires.get(job.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_application_count(self):
            // read_group_result = self.env['hr.applicant']._read_group([('job_id', 'in', self.ids)], ['job_id'], ['__count'])
            // result = {job.id: count for job, count in read_group_result}
            // for job in self:
            //     job.application_count = result.get(job.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_barcode(self):
            // self._compute_template_field_from_variant_field('barcode')
            */
            return default;
        }

        public async Task<TEntity> ComputeBaseUnitCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _compute_base_unit_count(self):
            // self.base_unit_count = 0
            // for template in self.filtered(lambda template: len(template.product_variant_ids) == 1):
            //     template.base_unit_count = template.product_variant_ids.base_unit_count
            */
            return default;
        }

        public async Task<TEntity> ComputeBaseUnitIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _compute_base_unit_id(self):
            // self.base_unit_id = self.env['website.base.unit']
            // for template in self.filtered(lambda template: len(template.product_variant_ids) == 1):
            //     template.base_unit_id = template.product_variant_ids.base_unit_id
            */
            return default;
        }

        public async Task<TEntity> ComputeBaseUnitNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _compute_base_unit_name(self):
            // for template in self:
            //     template.base_unit_name = template.base_unit_id.name or template.uom_name
            */
            return default;
        }

        public async Task<TEntity> ComputeBaseUnitPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _compute_base_unit_price(self):
            // for template in self:
            //     template.base_unit_price = template._get_base_unit_price(template.list_price)
            */
            return default;
        }

        public async Task<TEntity> ComputeBlogPostCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _compute_blog_post_count(self):
            // for record in self:
            //     record.blog_post_count = len(record.blog_post_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeBomCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _compute_bom_count(self):
            // for product in self:
            //     product.bom_count = self.env['mrp.bom'].search_count(['|', ('product_tmpl_id', '=', product.id), ('byproduct_ids.product_id.product_tmpl_id', '=', product.id)])
            */
            return default;
        }

        public async Task<TEntity> ComputeBoothMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeCanBeExpensedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: product_template.py) ---
            // def _compute_can_be_expensed(self):
            // self.filtered(lambda p: p.type not in ['consu', 'service'] or not p.purchase_ok).update({'can_be_expensed': False})
            */
            return default;
        }

        public async Task<TEntity> ComputeCanImage1024BeZoomedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_can_image_1024_be_zoomed(self):
            // for template in self.with_context(bin_size=False):
            //     template.can_image_1024_be_zoomed = template.image_1920 and is_image_size_above(template.image_1920, template.image_1024)
            */
            return default;
        }

        public async Task<TEntity> ComputeCanModerateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def _compute_can_moderate(self):
            // for forum in self:
            //     forum.can_moderate = self.env.user.karma >= forum.karma_moderate
            */
            return default;
        }

        public async Task<TEntity> ComputeCanPublishInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _compute_can_publish(self):
            // if self.env.user.has_group('website.group_website_designer'):
            //     for record in self:
            //         record.can_publish = True
            // # FIXME this makes it so no-rights internal users *see* the publish
            // # button for website pages (although they cannot use it)
            // else:
            //     super()._compute_can_publish()
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

        public async Task<TEntity> ComputeCanUploadInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeCategoryAndSlideIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeCategoryCompletedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeCategoryCompletionTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeCategoryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeChildCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _compute_child_count(self):
            // for post in self:
            //     post.child_count = len(post.child_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product.py) ---
            // def _compute_color(self):
            // """Automatically set the color field based on the selected category."""
            // for product in self:
            //     if product.pos_categ_ids:
            //         product.color = product.pos_categ_ids[0].color
            */
            return default;
        }

        public async Task<TEntity> ComputeCommentsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_comments_count(self):
            // for slide in self:
            //     slide.comments_count = len(slide.website_message_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeCommunityMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeCostCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeCountFlaggedPostsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeCountPostsWaitingValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeDateBeginTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeDateEndTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeDateTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_default_code(self):
            // self._compute_template_field_from_variant_field('default_code')
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py) ---
            // def _compute_display_name(self):
            // for category in self:
            //     category.display_name = " / ".join(category.parents_and_self.mapped(
            //         lambda cat: cat.name or self.env._("New")
            //     ))
            */
            return default;
        }

        public async Task<TEntity> ComputeDocumentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_document_ids(self):
            // applicants = self.mapped('application_ids').filtered(lambda self: not self.employee_id)
            // app_to_job = dict((applicant.id, applicant.job_id.id) for applicant in applicants)
            // attachments = self.env['ir.attachment'].search([
            //     '|',
            //     '&', ('res_model', '=', 'hr.job'), ('res_id', 'in', self.ids),
            //     '&', ('res_model', '=', 'hr.applicant'), ('res_id', 'in', applicants.ids)])
            // result = dict.fromkeys(self.ids, self.env['ir.attachment'])
            // for attachment in attachments:
            //     if attachment.res_model == 'hr.applicant':
            //         result[app_to_job[attachment.res_id]] |= attachment
            //     else:
            //         result[attachment.res_id] |= attachment
            // 
            // for job in self:
            //     job.document_ids = result.get(job.id, False)
            //     job.documents_count = len(job.document_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeEmbedCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeEmbedCountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeEmployeesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_job.py) ---
            // def _compute_employees(self):
            // employee_data = self.env['hr.employee']._read_group([('job_id', 'in', self.ids)], ['job_id'], ['__count'])
            // result = {job.id: count for job, count in employee_data}
            // for job in self:
            //     job.no_of_employee = result.get(job.id, 0)
            //     job.expected_employees = result.get(job.id, 0) + job.no_of_recruitment
            */
            return default;
        }

        public async Task<TEntity> ComputeEnrollInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_enroll(self):
            // self.filtered(lambda channel: channel.visibility == 'members').enroll = 'invite'
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothCategoryAvailableIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_event.py) ---
            // def _compute_event_booth_category_available_ids(self):
            // for event in self:
            //     event.event_booth_category_available_ids = event.event_booth_ids.filtered(lambda booth: booth.is_available).mapped('booth_category_id')
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothCategoryIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_event.py) ---
            // def _compute_event_booth_category_ids(self):
            // for event in self:
            //     event.event_booth_category_ids = event.event_booth_ids.mapped('booth_category_id')
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeEventBoothIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeEventMailIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeEventRegisterUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_event_register_url(self):
            // for event in self:
            //     event.event_register_url = werkzeug.urls.url_join(event.get_base_url(), f"{event.website_url}/register")
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegistrationsOpenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeEventRegistrationsSoldOutInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeEventRegistrationsStartedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeEventTicketIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeExhibitorMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeExpensePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _compute_expense_policy(self):
            // self.filtered(lambda t: not t.sale_ok).expense_policy = 'no'
            --- ODOO METHOD SOURCE (MODULE: sale_expense, FILE: product_template.py) ---
            // def _compute_expense_policy(self):
            // super()._compute_expense_policy()
            // self.filtered(lambda t: not t.can_be_expensed).expense_policy = 'no'
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: product_template.py) ---
            // def _compute_expense_policy(self):
            // super()._compute_expense_policy()
            // self.filtered(lambda t: t.is_storable).expense_policy = 'no'
            */
            return default;
        }

        public async Task<TEntity> ComputeExpensePolicyTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_expense, FILE: product_template.py) ---
            // def _compute_expense_policy_tooltip(self):
            // for product_template in self:
            //     if not product_template.can_be_expensed or not product_template.expense_policy:
            //         product_template.expense_policy_tooltip = False
            //     elif product_template.expense_policy == 'no':
            //         product_template.expense_policy_tooltip = _(
            //             "Expenses of this category may not be added to a Sales Order."
            //         )
            //     elif product_template.expense_policy == 'cost':
            //         product_template.expense_policy_tooltip = _(
            //             "Expenses will be added to the Sales Order at their actual cost when posted."
            //         )
            //     elif product_template.expense_policy == 'sales_price':
            //         product_template.expense_policy_tooltip = _(
            //             "Expenses will be added to the Sales Order at their sales price (product price, pricelist, etc.) when posted."
            //         )
            */
            return default;
        }

        public async Task<TEntity> ComputeExtendedInterviewerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_extended_interviewer_ids(self):
            // # Use SUPERUSER_ID as the search_read is protected in hr_referral
            // results_raw = self.env['hr.applicant'].with_user(SUPERUSER_ID).search_read([
            //     ('job_id', 'in', self.ids),
            //     ('interviewer_ids', '!=', False)
            // ], ['interviewer_ids', 'job_id'])
            // interviewers_by_job = defaultdict(set)
            // for result_raw in results_raw:
            //     interviewers_by_job[result_raw['job_id'][0]] |= set(result_raw['interviewer_ids'])
            // for job in self:
            //     job.extended_interviewer_ids = [(6, 0, list(interviewers_by_job[job.id]))]
            */
            return default;
        }

        public async Task<TEntity> ComputeFavoriteCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _compute_favorite_count(self):
            // for post in self:
            //     post.favourite_count = len(post.favourite_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeFieldIsOneDayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeFiscalCountryCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _compute_fiscal_country_codes(self):
            // for record in self:
            //     allowed_companies = record.company_id or self.env.companies
            //     record.fiscal_country_codes = ",".join(allowed_companies.mapped('account_fiscal_country_id.code'))
            */
            return default;
        }

        public async Task<TEntity> ComputeForumStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeFullUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def _compute_full_url(self):
            // for job in self:
            //     job.full_url = url_join(job.get_base_url(), (job.website_url or '/jobs'))
            */
            return default;
        }

        public async Task<TEntity> ComputeGelatoMissingImagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py) ---
            // def _compute_gelato_missing_images(self):
            // for product in self:
            //     product.gelato_missing_images = any(
            //         not image.datas for image in product.gelato_image_ids
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeGelatoProductUidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py) ---
            // def _compute_gelato_product_uid(self):
            // self._compute_template_field_from_variant_field('gelato_product_uid')
            */
            return default;
        }

        public async Task<TEntity> ComputeGoogleDriveIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeHasAvailableRouteIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_has_available_route_ids(self):
            // self.has_available_route_ids = self.env['stock.route'].search_count([('product_selectable', '=', True)])
            */
            return default;
        }

        public async Task<TEntity> ComputeHasConfigurableAttributesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeHasLeadRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeHasPendingPostInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeHasRequestedAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeHasValidatedAnswerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _compute_has_validated_answer(self):
            // for post in self:
            //     post.has_validated_answer = any(answer.is_correct for answer in post.child_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeImage1920InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeInvoicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _compute_invoice_policy(self):
            // self.filtered(lambda t: t.type == 'consu' or not t.invoice_policy).invoice_policy = 'order'
            */
            return default;
        }

        public async Task<TEntity> ComputeIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_is_favorite(self):
            // for job in self:
            //     job.is_favorite = self.env.user in job.favorite_user_ids
            */
            return default;
        }

        public async Task<TEntity> ComputeIsFinishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeIsHomepageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _compute_is_homepage(self):
            // website = self.env['website'].get_current_website()
            // for page in self:
            //     page.is_homepage = page.url == (website.homepage_url or page.website_id == website and '/')
            */
            return default;
        }

        public async Task<TEntity> ComputeIsKitsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _compute_is_kits(self):
            // domain = [('product_tmpl_id', 'in', self.ids), ('type', '=', 'phantom'), '|', ('company_id', '=', False), ('company_id', '=', self.env.company.id)]
            // bom_mapping = self.env['mrp.bom'].sudo().search_read(domain, ['product_tmpl_id'])
            // kits_ids = set(b['product_tmpl_id'][0] for b in bom_mapping)
            // for template in self:
            //     template.is_kits = (template.id in kits_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeIsNewSlideInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_is_new_slide(self):
            // for slide in self:
            //     slide.is_new_slide = slide.date_published > fields.Datetime.now() - relativedelta(days=7) if slide.is_published else False
            */
            return default;
        }

        public async Task<TEntity> ComputeIsOngoingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeIsParticipatingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeIsProductVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_is_product_variant(self):
            // self.is_product_variant = False
            */
            return default;
        }

        public async Task<TEntity> ComputeIsStorableAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def compute_is_storable(self):
            // self.filtered(lambda t: t.type != 'consu' and t.is_storable).is_storable = False
            */
            return default;
        }

        public async Task<TEntity> ComputeIsVisibleOnWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeItemCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeKanbanStateLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeL10nEgEtaCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_eg_edi_eta, FILE: product_template.py) ---
            // def _compute_l10n_eg_eta_code(self):
            // self.l10n_eg_eta_code = False
            // for template in self:
            //     if len(template.product_variant_ids) == 1:
            //         template.l10n_eg_eta_code = template.product_variant_ids.l10n_eg_eta_code
            */
            return default;
        }

        public async Task<TEntity> ComputeL10nIdProductCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_id_efaktur_coretax, FILE: product_template.py) ---
            // def _compute_l10n_id_product_code(self):
            // # used for setting default product code depending on product being goods/service
            // # 000000 is default for both general goods/service
            // for record in self:
            //     if record.type == 'service':
            //         record.l10n_id_product_code = self.env.ref('l10n_id_efaktur_coretax.product_code_000000_service', raise_if_not_found=False)
            //     else:
            //         record.l10n_id_product_code = self.env.ref('l10n_id_efaktur_coretax.product_code_000000_goods', raise_if_not_found=False)
            */
            return default;
        }

        public async Task<TEntity> ComputeL10nInHsnWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_in, FILE: product_template.py) ---
            // def _compute_l10n_in_hsn_warning(self):
            // digit_suffixes = {
            //     '4': _("either 4, 6 or 8"),
            //     '6': _("either 6 or 8"),
            //     '8': _("8")
            // }
            // active_hsn_code_digit_len = max(
            //     int(company.l10n_in_hsn_code_digit)
            //     for company in self.env.companies
            // )
            // for record in self:
            //     check_hsn = record.sale_ok and record.l10n_in_hsn_code and active_hsn_code_digit_len
            //     if check_hsn and (not re.match(r'^\d{4}$|^\d{6}$|^\d{8}$', record.l10n_in_hsn_code) or len(record.l10n_in_hsn_code) < active_hsn_code_digit_len):
            //         record.l10n_in_hsn_warning = _(
            //             "HSN code field must consist solely of digits and be %s in length.",
            //             digit_suffixes.get(str(active_hsn_code_digit_len))
            //         )
            //         continue
            //     record.l10n_in_hsn_warning = False
            */
            return default;
        }

        public async Task<TEntity> ComputeLastPostIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeLeadCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeLikeInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeLotValuatedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _compute_lot_valuated(self):
            // for product in self:
            //     if product.tracking == 'none':
            //         product.lot_valuated = False
            */
            return default;
        }

        public async Task<TEntity> ComputeMarkCompleteActionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeMeetingRoomAllowCreationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeMeetingRoomCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeMembersCountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeMembershipValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeMrpProductQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _compute_mrp_product_qty(self):
            // for template in self:
            //     template.mrp_product_qty = float_round(sum(template.mapped('product_variant_ids').mapped('mrp_product_qty')), precision_rounding=template.uom_id.rounding)
            */
            return default;
        }

        public async Task<TEntity> ComputeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_controller_page.py) ---
            // def _compute_name(self):
            // for rec in self:
            //     rec.name = rec.view_id.name
            */
            return default;
        }

        public async Task<TEntity> ComputeNameSlugifiedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_controller_page.py) ---
            // def _compute_name_slugified(self):
            // for rec in self:
            //     if not rec.model_id:
            //         rec.name_slugified = False
            //         continue
            //     rec.name_slugified = self.env['ir.http']._slugify(rec.name or '')
            */
            return default;
        }

        public async Task<TEntity> ComputeNbrMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_nbr_moves(self):
            // res = defaultdict(lambda: {'moves_in': 0, 'moves_out': 0})
            // incoming_moves = self.env['stock.move.line']._read_group([
            //         ('product_id.product_tmpl_id', 'in', self.ids),
            //         ('state', '=', 'done'),
            //         ('picking_code', '=', 'incoming'),
            //         ('date', '>=', fields.Datetime.now() - relativedelta(years=1))
            //     ], ['product_id'], ['__count'])
            // outgoing_moves = self.env['stock.move.line']._read_group([
            //         ('product_id.product_tmpl_id', 'in', self.ids),
            //         ('state', '=', 'done'),
            //         ('picking_code', '=', 'outgoing'),
            //         ('date', '>=', fields.Datetime.now() - relativedelta(years=1))
            //     ], ['product_id'], ['__count'])
            // for product, count in incoming_moves:
            //     product_tmpl_id = product.product_tmpl_id.id
            //     res[product_tmpl_id]['moves_in'] += count
            // for product, count in outgoing_moves:
            //     product_tmpl_id = product.product_tmpl_id.id
            //     res[product_tmpl_id]['moves_out'] += count
            // for template in self:
            //     template.nbr_moves_in = res[template.id]['moves_in']
            //     template.nbr_moves_out = res[template.id]['moves_out']
            */
            return default;
        }

        public async Task<TEntity> ComputeNbrReorderingRulesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_nbr_reordering_rules(self):
            // res = {k: {'nbr_reordering_rules': 0, 'reordering_min_qty': 0, 'reordering_max_qty': 0} for k in self.ids}
            // product_data = self.env['stock.warehouse.orderpoint']._read_group([('product_id.product_tmpl_id', 'in', self.ids)], ['product_id'], ['__count', 'product_min_qty:sum', 'product_max_qty:sum'])
            // for product, count, product_min_qty, product_max_qty in product_data:
            //     product_tmpl_id = product.product_tmpl_id.id
            //     res[product_tmpl_id]['nbr_reordering_rules'] += count
            //     res[product_tmpl_id]['reordering_min_qty'] = product_min_qty
            //     res[product_tmpl_id]['reordering_max_qty'] = product_max_qty
            // for template in self:
            //     if not template.id:
            //         template.nbr_reordering_rules = 0
            //         template.reordering_min_qty = 0
            //         template.reordering_max_qty = 0
            //         continue
            //     template.nbr_reordering_rules = res[template.id]['nbr_reordering_rules']
            //     template.reordering_min_qty = res[template.id]['reordering_min_qty']
            //     template.reordering_max_qty = res[template.id]['reordering_max_qty']
            */
            return default;
        }

        public async Task<TEntity> ComputeNewApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_new_application_count(self):
            // self.env.cr.execute(
            //     """
            //         WITH job_stage AS (
            //             SELECT DISTINCT ON (j.id) j.id AS job_id, s.id AS stage_id, s.sequence AS sequence
            //               FROM hr_job j
            //          LEFT JOIN hr_job_hr_recruitment_stage_rel rel
            //                 ON rel.hr_job_id = j.id
            //               JOIN hr_recruitment_stage s
            //                 ON s.id = rel.hr_recruitment_stage_id
            //                 OR s.id NOT IN (
            //                                 SELECT "hr_recruitment_stage_id"
            //                                   FROM "hr_job_hr_recruitment_stage_rel"
            //                                  WHERE "hr_recruitment_stage_id" IS NOT NULL
            //                                 )
            //              WHERE j.id in %s
            //           ORDER BY 1, 3 asc
            //         )
            //         SELECT s.job_id, COUNT(a.id) AS new_applicant
            //           FROM hr_applicant a
            //           JOIN job_stage s
            //             ON s.job_id = a.job_id
            //            AND a.stage_id = s.stage_id
            //            AND a.active IS TRUE
            //          WHERE a.company_id in %s
            //             OR a.company_id is NULL
            //       GROUP BY s.job_id
            //     """, [tuple(self.ids), tuple(self.env.companies.ids)]
            // )
            // 
            // new_applicant_count = dict(self.env.cr.fetchall())
            // for job in self:
            //     job.new_application_count = new_applicant_count.get(job.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeNoOfHiredEmployeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_no_of_hired_employee(self):
            // counts = dict(self.env['hr.applicant']._read_group(
            //     domain=[
            //         ('job_id', 'in', self.ids),
            //         ('date_closed', '!=', False),
            //         '|',
            //             ('active', '=', False),
            //             ('active', '=', True),
            //     ],
            //     groupby=['job_id'],
            //     aggregates=['__count']))
            // for job in self:
            //     job.no_of_hired_employee = counts.get(job, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeNoteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeOldApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_old_application_count(self):
            // for job in self:
            //     job.old_application_count = job.application_count - job.new_application_count
            */
            return default;
        }

        public async Task<TEntity> ComputePackagingIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeParentsAndSelfInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputePartnerHasNewContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputePartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputePlainContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _compute_plain_content(self):
            // for post in self:
            //     post.plain_content = tools.html2plaintext(post.content)[0:500] if post.content else False
            */
            return default;
        }

        public async Task<TEntity> ComputePostDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputePostKarmaRightsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _compute_post_karma_rights(self):
            // user = self.env.user
            // is_admin = self.env.is_admin()
            // # sudoed recordset instead of individual posts so values can be
            // # prefetched in bulk
            // for post, post_sudo in zip(self, self.sudo()):
            //     is_creator = post.create_uid == user
            // 
            //     post.karma_accept = post.forum_id.karma_answer_accept_own if post.parent_id.create_uid == user else post.forum_id.karma_answer_accept_all
            //     post.karma_edit = post.forum_id.karma_edit_own if is_creator else post.forum_id.karma_edit_all
            //     post.karma_close = post.forum_id.karma_close_own if is_creator else post.forum_id.karma_close_all
            //     post.karma_unlink = post.forum_id.karma_unlink_own if is_creator else post.forum_id.karma_unlink_all
            //     post.karma_comment = post.forum_id.karma_comment_own if is_creator else post.forum_id.karma_comment_all
            //     post.karma_comment_convert = post.forum_id.karma_comment_convert_own if is_creator else post.forum_id.karma_comment_convert_all
            //     post.karma_flag = post.forum_id.karma_flag
            // 
            //     post.can_ask = is_admin or user.karma >= post.forum_id.karma_ask
            //     post.can_answer = is_admin or user.karma >= post.forum_id.karma_answer
            //     post.can_accept = is_admin or user.karma >= post.karma_accept
            //     post.can_edit = is_admin or user.karma >= post.karma_edit
            //     post.can_close = is_admin or user.karma >= post.karma_close
            //     post.can_unlink = is_admin or user.karma >= post.karma_unlink
            //     post.can_upvote = is_admin or user.karma >= post.forum_id.karma_upvote or post.user_vote == -1
            //     post.can_downvote = is_admin or user.karma >= post.forum_id.karma_downvote or post.user_vote == 1
            //     post.can_comment = is_admin or user.karma >= post.karma_comment
            //     post.can_comment_convert = is_admin or user.karma >= post.karma_comment_convert
            //     post.can_view = post.can_close or post_sudo.active and (post_sudo.create_uid.karma > 0 or post_sudo.create_uid == user)
            //     post.can_display_biography = is_admin or (post_sudo.create_uid.karma >= post.forum_id.karma_user_bio and post_sudo.create_uid.website_published)
            //     post.can_post = is_admin or user.karma >= post.forum_id.karma_post
            //     post.can_flag = is_admin or user.karma >= post.forum_id.karma_flag
            //     post.can_moderate = is_admin or user.karma >= post.forum_id.karma_moderate
            //     post.can_use_full_editor = is_admin or user.karma >= post.forum_id.karma_editor
            */
            return default;
        }

        public async Task<TEntity> ComputePostsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_tag.py) ---
            // def _compute_posts_count(self):
            // for tag in self:
            //     tag.posts_count = len(tag.post_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputePrerequisiteUserHasCompletedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeProductDocumentCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeProductTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_product_tooltip(self):
            // self.product_tooltip = False
            // for template in self:
            //     template.product_tooltip = template._prepare_tooltip()
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _compute_product_tooltip(self):
            // super()._compute_product_tooltip()
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _compute_product_tooltip(self):
            // super()._compute_product_tooltip()
            */
            return default;
        }

        public async Task<TEntity> ComputeProductVariantCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_product_variant_count(self):
            // for template in self:
            //     template.product_variant_count = len(template.product_variant_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeProductVariantIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_product_variant_id(self):
            // for p in self:
            //     p.product_variant_id = p.product_variant_ids[:1].id
            */
            return default;
        }

        public async Task<TEntity> ComputePublishedDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def _compute_published_date(self):
            // for job in self:
            //     job.published_date = job.website_published and fields.Date.today()
            */
            return default;
        }

        public async Task<TEntity> ComputePurchaseMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: product.py) ---
            // def _compute_purchase_method(self):
            // default_purchase_method = self.env['product.template'].default_get(['purchase_method']).get('purchase_method', 'receive')
            // for product in self:
            //     if product.type == 'service':
            //         product.purchase_method = 'purchase'
            //     else:
            //         product.purchase_method = default_purchase_method
            */
            return default;
        }

        public async Task<TEntity> ComputePurchaseOkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: product_template.py) ---
            // def _compute_purchase_ok(self):
            // for record in self:
            //     if record.can_be_expensed:
            //         record.purchase_ok = True
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_purchase_ok(self):
            // pass
            */
            return default;
        }

        public async Task<TEntity> ComputePurchasedProductQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: product.py) ---
            // def _compute_purchased_product_qty(self):
            // for template in self.with_context(active_test=False):
            //     template.purchased_product_qty = float_round(sum(p.purchased_product_qty for
            //         p in template.product_variant_ids), precision_rounding=template.uom_id.rounding
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeQuantitiesDictInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_quantities_dict(self):
            // variants_available = {
            //     p['id']: p for p in self.product_variant_ids._origin.read(['qty_available', 'virtual_available', 'incoming_qty', 'outgoing_qty'])
            // }
            // prod_available = {}
            // for template in self:
            //     qty_available = 0
            //     virtual_available = 0
            //     incoming_qty = 0
            //     outgoing_qty = 0
            //     for p in template.product_variant_ids._origin:
            //         qty_available += variants_available[p.id]["qty_available"]
            //         virtual_available += variants_available[p.id]["virtual_available"]
            //         incoming_qty += variants_available[p.id]["incoming_qty"]
            //         outgoing_qty += variants_available[p.id]["outgoing_qty"]
            //     prod_available[template.id] = {
            //         "qty_available": qty_available,
            //         "virtual_available": virtual_available,
            //         "incoming_qty": incoming_qty,
            //         "outgoing_qty": outgoing_qty,
            //     }
            // return prod_available
            */
            return default;
        }

        public async Task<TEntity> ComputeQuantitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_quantities(self):
            // res = self._compute_quantities_dict()
            // for template in self:
            //     template.qty_available = res[template.id]['qty_available']
            //     template.virtual_available = res[template.id]['virtual_available']
            //     template.incoming_qty = res[template.id]['incoming_qty']
            //     template.outgoing_qty = res[template.id]['outgoing_qty']
            */
            return default;
        }

        public async Task<TEntity> ComputeQuestionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeQuestionsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_questions_count(self):
            // for slide in self:
            //     slide.questions_count = len(slide.question_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeQuizInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_partner, object quiz_done) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeRatingStatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeRelevancyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _compute_relevancy(self):
            // for post in self:
            //     if post.create_date:
            //         days = (datetime.today() - post.create_date).days
            //         post.relevancy = math.copysign(1, post.vote_count) * (abs(post.vote_count - 1) ** post.forum_id.relevancy_post_vote / (days + 2) ** post.forum_id.relevancy_time_decay)
            //     else:
            //         post.relevancy = 0
            */
            return default;
        }

        public async Task<TEntity> ComputeSalePriceSubtotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeSalesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _compute_sales_count(self):
            // for product in self:
            //     product.sales_count = float_round(sum([p.sales_count for p in product.with_context(active_test=False).product_variant_ids]), precision_rounding=product.uom_id.rounding)
            */
            return default;
        }

        public async Task<TEntity> ComputeSeatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeSeatsLimitedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeSeatsMaxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeSelfReplyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _compute_self_reply(self):
            // for post in self:
            //     post.self_reply = post.parent_id.create_uid == post.create_uid
            */
            return default;
        }

        public async Task<TEntity> ComputeServicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _compute_service_policy(self):
            // for product in self:
            //     product.service_policy = self._get_general_to_service(product.invoice_policy, product.service_type)
            //     if not product.service_policy and product.type == 'service':
            //         product.service_policy = 'ordered_prepaid'
            */
            return default;
        }

        public async Task<TEntity> ComputeServiceTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_service_tracking(self):
            // self.filtered(lambda product: product.type != 'service').service_tracking = 'no'
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _compute_service_tracking(self):
            // super()._compute_service_tracking()
            // self.filtered(lambda pt: not pt.sale_ok).service_tracking = 'no'
            */
            return default;
        }

        public async Task<TEntity> ComputeServiceTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _compute_service_type(self):
            // self.filtered(lambda t: t.type == 'consu' or not t.service_type).service_type = 'manual'
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: product_template.py) ---
            // def _compute_service_type(self):
            // super()._compute_service_type()
            // self.filtered(lambda t: t.is_storable).service_type = 'manual'
            */
            return default;
        }

        public async Task<TEntity> ComputeServiceUpsellThresholdRatioInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def _compute_service_upsell_threshold_ratio(self):
            // product_uom_hour = self.env.ref('uom.product_uom_hour')
            // uom_unit = self.env.ref('uom.product_uom_unit')
            // company_uom = self.env.company.timesheet_encode_uom_id
            // for record in self:
            //     if not record.uom_id or record.uom_id != uom_unit or\
            //        product_uom_hour.factor == record.uom_id.factor or\
            //        record.uom_id.category_id not in [product_uom_hour.category_id, uom_unit.category_id]:
            //         record.service_upsell_threshold_ratio = False
            //         continue
            //     else:
            //         timesheet_encode_uom = record.company_id.timesheet_encode_uom_id or company_uom
            //         record.service_upsell_threshold_ratio = f'(1 {record.uom_id.name} = {timesheet_encode_uom.factor / product_uom_hour.factor:.2f} {timesheet_encode_uom.name})'
            */
            return default;
        }

        public async Task<TEntity> ComputeShowQtyStatusButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _compute_show_qty_status_button(self):
            // super()._compute_show_qty_status_button()
            // for template in self:
            //     if template.is_kits:
            //         template.show_on_hand_qty_status_button = template.product_variant_count <= 1
            //         template.show_forecasted_qty_status_button = False
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_show_qty_status_button(self):
            // for template in self:
            //     template.show_on_hand_qty_status_button = template.is_storable
            //     template.show_forecasted_qty_status_button = template.is_storable
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideIconClassInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeSlideLastUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_slide_last_update(self):
            // for record in self:
            //     record.slide_last_update = fields.Date.today()
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeSlideViewsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeSlidesStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeSponsorCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeStartSaleDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeTagIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeTagIdsUsageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeTaxStringInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _compute_tax_string(self):
            // for record in self:
            //     record.tax_string = record._construct_tax_string(record.list_price)
            */
            return default;
        }

        public async Task<TEntity> ComputeTeaserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def _compute_teaser(self):
            // for forum in self:
            //     forum.teaser = textwrap.shorten(forum.description, width=180, placeholder='...') if forum.description else ""
            */
            return default;
        }

        public async Task<TEntity> ComputeTemplateFieldFromVariantFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname, object @default) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeTicketInstructionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeTimeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def _compute_total(self):
            // for record in self:
            //     record.total_views = record.slide_views + record.public_views
            */
            return default;
        }

        public async Task<TEntity> ComputeTrackCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _compute_tracking(self):
            // self.filtered(lambda t: not t.is_storable and t.tracking != 'none').tracking = 'none'
            */
            return default;
        }

        public async Task<TEntity> ComputeTracksTagIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def _compute_tracks_tag_ids(self):
            // for event in self:
            //     event.tracks_tag_ids = event.track_ids.mapped('tag_ids').filtered(lambda tag: tag.color != 0).ids
            */
            return default;
        }

        public async Task<TEntity> ComputeUidHasAnsweredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _compute_uid_has_answered(self):
            // for post in self:
            //     post.uid_has_answered = post._uid in post.child_ids.create_uid.ids
            */
            return default;
        }

        public async Task<TEntity> ComputeUomPoIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeUrlDemoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_controller_page.py) ---
            // def _compute_url_demo(self):
            // for rec in self:
            //     if not rec.name_slugified:
            //         rec.url_demo = ""
            //         continue
            //     url = ["", "model", rec.name_slugified]
            //     rec.url_demo = "/".join(url)
            */
            return default;
        }

        public async Task<TEntity> ComputeUseBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeUsedInBomCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _compute_used_in_bom_count(self):
            // for template in self:
            //     template.used_in_bom_count = self.env['mrp.bom'].search_count(
            //         [('bom_line_ids.product_tmpl_id', '=', template.id)])
            */
            return default;
        }

        public async Task<TEntity> ComputeUserFavouriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _compute_user_favourite(self):
            // for post in self:
            //     post.user_favourite = post._uid in post.favourite_ids.ids
            */
            return default;
        }

        public async Task<TEntity> ComputeUserMembershipIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeUserStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeUserVoteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _compute_user_vote(self):
            // votes = self.env['forum.post.vote'].search_read([('post_id', 'in', self._ids), ('user_id', '=', self._uid)], ['vote', 'post_id'])
            // mapped_vote = dict([(v['post_id'][0], v['vote']) for v in votes])
            // for vote in self:
            //     vote.user_vote = mapped_vote.get(vote.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeValidProductTemplateAttributeLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeVideoSourceTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeVimeoIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeVisibleExpensePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _compute_visible_expense_policy(self):
            // visibility = self.env.user.has_group('analytic.group_analytic_accounting')
            // for product_template in self:
            //     product_template.visible_expense_policy = visibility and product_template.purchase_ok
            --- ODOO METHOD SOURCE (MODULE: sale_expense, FILE: product_template.py) ---
            // def _compute_visible_expense_policy(self):
            // expense_products = self.filtered(lambda p: p.can_be_expensed)
            // super(ProductTemplate, self - expense_products)._compute_visible_expense_policy()
            // visibility = self.env.user.has_group('hr_expense.group_hr_expense_user')
            // for product_template in expense_products:
            //     if not product_template.visible_expense_policy:
            //         product_template.visible_expense_policy = visibility
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def _compute_visible_expense_policy(self):
            // visibility = self.env.user.has_group('project.group_project_user')
            // for product_template in self:
            //     if not product_template.visible_expense_policy:
            //         product_template.visible_expense_policy = visibility
            // return super()._compute_visible_expense_policy()
            */
            return default;
        }

        public async Task<TEntity> ComputeVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _compute_visible(self):
            // for page in self:
            //     page.is_visible = page.website_published and (
            //         not page.date_publish or page.date_publish < fields.Datetime.now()
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeVolumeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_volume(self):
            // self._compute_template_field_from_variant_field('volume')
            */
            return default;
        }

        public async Task<TEntity> ComputeVolumeUomNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_volume_uom_name(self):
            // self.volume_uom_name = self._get_volume_uom_name_from_ir_config_parameter()
            */
            return default;
        }

        public async Task<TEntity> ComputeVoteCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _compute_vote_count(self):
            // read_group_res = self.env['forum.post.vote']._read_group([('post_id', 'in', self._ids)], ['post_id', 'vote'], ['__count'])
            // result = dict.fromkeys(self._ids, 0)
            // for post, vote, count in read_group_res:
            //     result[post.id] += count * int(vote)
            // for post in self:
            //     post.vote_count = result[post.id]
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteDefaultBackgroundImageUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _compute_website_default_background_image_url(self):
            // for channel in self:
            //     channel.website_default_background_image_url = f'website_slides/static/src/img/channel-{channel.channel_type}-default.jpg'
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteMenuDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeWebsiteMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _compute_website_menu(self):
            // for page in self:
            //     page.is_in_menu = bool(page.menu_ids)
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

        public async Task<TEntity> ComputeWebsiteShareUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeWebsiteTrackInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeWebsiteTrackProposalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ComputeWebsiteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _compute_website_url(self):
            // for page in self:
            //     page.website_url = page.url
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
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def _compute_website_url(self):
            // if not self.id:
            //     return False
            // return f'/forum/{self.env["ir.http"]._slug(self)}'
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _compute_website_url(self):
            // self.website_url = False
            // for post in self.filtered(lambda post: post.id):
            //     anchor = f'#answer_{post.id}' if post.parent_id else ''
            //     post.website_url = f'/forum/{self.env["ir.http"]._slug(post.forum_id)}/{self.env["ir.http"]._slug(post)}{anchor}'
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_tag.py) ---
            // def _compute_website_url(self):
            // for tag in self:
            //     tag.website_url = f'/forum/{self.env["ir.http"]._slug(tag.forum_id)}/tag/{self.env["ir.http"]._slug(tag)}/questions'
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def _compute_website_url(self):
            // super(Job, self)._compute_website_url()
            // for job in self:
            //     job.website_url = f'/jobs/{self.env["ir.http"]._slug(job)}'
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _compute_website_url(self):
            // super()._compute_website_url()
            // for product in self:
            //     if product.id:
            //         product.website_url = "/shop/%s" % self.env['ir.http']._slug(product)
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

        public async Task<TEntity> ComputeWeightInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_weight(self):
            // self._compute_template_field_from_variant_field('weight')
            */
            return default;
        }

        public async Task<TEntity> ComputeWeightUomNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _compute_weight_uom_name(self):
            // self.weight_uom_name = self._get_weight_uom_name_from_ir_config_parameter()
            */
            return default;
        }

        public async Task<TEntity> ComputeYoutubeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ConstructTaxStringInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _construct_tax_string(self, price):
            // currency = self.currency_id
            // res = self.taxes_id.filtered(lambda t: t.company_id == self.env.company).compute_all(
            //     price, product=self, partner=self.env['res.partner']
            // )
            // joined = []
            // included = res['total_included']
            // if currency.compare_amounts(included, price):
            //     joined.append(_('%(amount)s Incl. Taxes', amount=format_amount(self.env, included, currency)))
            // excluded = res['total_excluded']
            // if currency.compare_amounts(excluded, price):
            //     joined.append(_('%(amount)s Excl. Taxes', amount=format_amount(self.env, excluded, currency)))
            // if joined:
            //     tax_string = f"(= {', '.join(joined)})"
            // else:
            //     tax_string = " "
            // return tax_string
            --- ODOO METHOD SOURCE (MODULE: l10n_account_withholding_tax, FILE: product_template.py) ---
            // def _construct_tax_string(self, price):
            // """ Updates the tax string computation to include the withheld amount when withholding taxes are involved. """
            // # OVERRIDE 'account'
            // company_taxes = self.taxes_id.filtered(lambda t: t.company_id == self.env.company)
            // 
            // def _get_withheld_amount():
            //     if not company_taxes:
            //         return 0.0
            // 
            //     base_line = company_taxes._prepare_base_line_for_taxes_computation(
            //         None,
            //         partner_id=self.env["res.partner"],
            //         currency_id=self.env.company.currency_id,
            //         product_id=self,
            //         quantity=1.0,
            //         tax_ids=company_taxes,
            //         price_unit=price,
            //         calculate_withholding_taxes=True,
            //     )
            //     company_taxes._add_tax_details_in_base_line(base_line, self.env.company)
            //     company_taxes._round_base_lines_tax_details([base_line], self.env.company)
            //     company_taxes._add_accounting_data_to_base_line_tax_details(
            //         base_line,
            //         self.env.company,
            //     )
            //     tax_details = base_line['tax_details']
            //     wth_total = 0.0
            //     for tax_data in tax_details['taxes_data']:
            //         if tax_data['tax'].is_withholding_tax_on_payment:
            //             wth_total -= tax_data['tax_amount_currency']
            //     return wth_total
            // 
            // # Reimplement the tax string by taking into account the withholding taxes.
            // # First step; compute the amounts excluding withholding taxes.
            // res = company_taxes.compute_all(
            //     price, product=self, partner=self.env['res.partner']
            // )
            // joined = []
            // included = res['total_included']
            // excluded = res['total_excluded']
            // # Second step, compute the withholding tax amounts
            // withheld_amount = _get_withheld_amount()
            // 
            // currency = self.currency_id
            // if currency.compare_amounts(included, price):
            //     joined.append(self.env._('%(amount)s Incl. Taxes', amount=format_amount(self.env, included, currency)))
            // if currency.compare_amounts(excluded, price):
            //     joined.append(self.env._('%(amount)s Excl. Taxes', amount=format_amount(self.env, excluded, currency)))
            // if not currency.is_zero(withheld_amount):
            //     joined.append(self.env._('%(amount)s Tax Withheld', amount=format_amount(self.env, withheld_amount, currency)))
            // if joined:
            //     tax_string = f"(= {', '.join(joined)})"
            // else:
            //     tax_string = " "
            // return tax_string
            */
            return default;
        }

        public async Task<TEntity> ConvertAnswerToCommentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def convert_answer_to_comment(self):
            // """ Tools to convert an answer (forum.post) to a comment (mail.message).
            // The original post is unlinked and a new comment is posted on the question
            // using the post create_uid as the comment's author. """
            // self.ensure_one()
            // if not self.parent_id:
            //     return self.env['mail.message']
            // 
            // # karma-based action check: use the post field that computed own/all value
            // if not self.can_comment_convert:
            //     raise AccessError(_('%d karma required to convert an answer to a comment.', self.karma_comment_convert))
            // 
            // # post the message
            // question = self.parent_id
            // self_sudo = self.sudo()
            // values = {
            //     'author_id': self_sudo.create_uid.partner_id.id,  # use sudo here because of access to res.users model
            //     'email_from': self_sudo.create_uid.email_formatted,  # use sudo here because of access to res.users model
            //     'body': tools.html_sanitize(self.content, sanitize_attributes=True, strip_style=True, strip_classes=True),
            //     'message_type': 'comment',
            //     'subtype_xmlid': 'mail.mt_comment',
            //     'date': self.create_date,
            // }
            // # done with the author user to have create_uid correctly set
            // new_message = question.with_user(self_sudo.create_uid.id).with_context(mail_create_nosubscribe=True).sudo().message_post(**values).sudo(False)
            // 
            // # unlink the original answer, using SUPERUSER_ID to avoid karma issues
            // self.sudo().unlink()
            // 
            // return new_message
            */
            return default;
        }

        public async Task<TEntity> ConvertCommentToAnswerAsync<TEntity>(IEnumerable<TEntity> entities, Guid message_id) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def convert_comment_to_answer(self, message_id):
            // """ Tool to convert a comment (mail.message) into an answer (forum.post).
            // The original comment is unlinked and a new answer from the comment's author
            // is created. Nothing is done if the comment's author already answered the
            // question. """
            // comment_sudo = self.env['mail.message'].sudo().browse(message_id)
            // post = self.browse(comment_sudo.res_id)
            // if not comment_sudo.author_id or not comment_sudo.author_id.user_ids:  # only comment posted by users can be converted
            //     return False
            // 
            // # karma-based action check: must check the message's author to know if own / all
            // is_author = comment_sudo.author_id.id == self.env.user.partner_id.id
            // karma_own = post.forum_id.karma_comment_convert_own
            // karma_all = post.forum_id.karma_comment_convert_all
            // karma_convert = is_author and karma_own or karma_all
            // can_convert = self.env.user.karma >= karma_convert
            // if not can_convert:
            //     if is_author and karma_own < karma_all:
            //         raise AccessError(_('%d karma required to convert your comment to an answer.', karma_own))
            //     else:
            //         raise AccessError(_('%d karma required to convert a comment to an answer.', karma_all))
            // 
            // # check the message's author has not already an answer
            // question = post.parent_id if post.parent_id else post
            // post_create_uid = comment_sudo.author_id.user_ids[0]
            // if any(answer.create_uid.id == post_create_uid.id for answer in question.child_ids):
            //     return False
            // 
            // # create the new post
            // post_values = {
            //     'forum_id': question.forum_id.id,
            //     'content': comment_sudo.body,
            //     'parent_id': question.id,
            //     'name': _('Re: %s', question.name or ''),
            // }
            // # done with the author user to have create_uid correctly set
            // new_post = self.with_user(post_create_uid).sudo().create(post_values).sudo(False)
            // 
            // # delete comment
            // comment_sudo.unlink()
            // 
            // return new_post
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
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
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def copy(self, default=None):
            // new_products = super().copy(default=default)
            // # Since we don't copy product variants directly, we need to match the newly
            // # created product variants with the old one, and copy the storage category
            // # capacity from them.
            // new_product_dict = {}
            // for product in new_products.product_variant_ids:
            //     product_attribute_value = product.product_template_attribute_value_ids.product_attribute_value_id
            //     new_product_dict[product_attribute_value] = product.id
            // storage_category_capacity_vals = []
            // for storage_category_capacity in self.product_variant_ids.storage_category_capacity_ids:
            //     product_attribute_value = storage_category_capacity.product_id.product_template_attribute_value_ids.product_attribute_value_id
            //     storage_category_capacity_vals.append(storage_category_capacity.copy_data({'product_id': new_product_dict[product_attribute_value]})[0])
            // self.env['stock.storage.category.capacity'].create(storage_category_capacity_vals)
            // return new_products
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // if not default:
            //     return vals_list
            // for page, vals in zip(self, vals_list):
            //     if not default.get('view_id'):
            //         new_view = page.view_id.copy({'website_id': default.get('website_id')})
            //         vals['view_id'] = new_view.id
            //         vals['key'] = new_view.key
            //     vals['url'] = default.get('url', self.env['website'].get_unique_path(page.url))
            // return vals_list
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

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def create(self, vals_list):
            // forums = super(
            //     Forum,
            //     self.with_context(mail_create_nolog=True, mail_create_nosubscribe=True)
            // ).create(vals_list)
            // self.env['website'].sudo()._update_forum_count()
            // forums._set_default_faq()
            // return forums
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def create(self, vals_list):
            // defaults_to_check = self.default_get(['content', 'forum_id'])
            // for vals in vals_list:
            //     content = vals.get('content', defaults_to_check.get('content'))
            //     if content:
            //         forum_id = vals.get('forum_id', defaults_to_check.get('forum_id'))
            //         vals['content'] = self._update_content(content, forum_id)
            // 
            // posts = super(Post, self.with_context(mail_create_nolog=True)).create(vals_list)
            // 
            // for post in posts:
            //     # deleted or closed questions
            //     if post.parent_id and (post.parent_id.state == 'close' or post.parent_id.active is False):
            //         raise UserError(_('Posting answer on a [Deleted] or [Closed] question is not possible.'))
            //     # karma-based access
            //     if not post.parent_id and not post.can_ask:
            //         raise AccessError(_('%d karma required to create a new question.', post.forum_id.karma_ask))
            //     elif post.parent_id and not post.can_answer:
            //         raise AccessError(_('%d karma required to answer a question.', post.forum_id.karma_answer))
            //     if not post.parent_id and not post.can_post:
            //         post.sudo().state = 'pending'
            // 
            //     # add karma for posting new questions
            //     if not post.parent_id and post.state == 'active':
            //         post.create_uid.sudo()._add_karma(post.forum_id.karma_gen_question_new, post, _('Ask a new question'))
            // posts.sudo()._notify_state_update()
            // return posts
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_tag.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     forum = self.env['forum.forum'].browse(vals.get('forum_id'))
            //     if self.env.user.karma < forum.karma_tag_create and not self.env.is_admin():
            //         raise AccessError(_('%d karma required to create a new Tag.', forum.karma_tag_create))
            // return super(Tags, self.with_context(mail_create_nolog=True, mail_create_nosubscribe=True)).create(vals_list)
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

        public async Task<TEntity> CreateAttributesFromGelatoInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_info) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py) ---
            // def _create_attributes_from_gelato_info(self, template_info):
            // """ Create attributes for the current product template.
            // 
            // :param dict template_info: The template information fetched from Gelato.
            // :return: None
            // """
            // if len(template_info['variants']) == 1:  # The template has no attribute.
            //     self.gelato_product_uid = template_info['variants'][0]['productUid']
            // else:  # The template has multiple attributes.
            //     # Iterate over the variants to find and create the possible attributes.
            //     for variant_data in template_info['variants']:
            //         current_variant_pavs = self.env['product.attribute.value']
            //         for attribute_data in variant_data['variantOptions']:  # Attribute name and value.
            //             # Search for the existing attribute with the proper variant creation policy and
            //             # create it if not found.
            //             attribute = self.env['product.attribute'].search(
            //                 [('name', '=', attribute_data['name']), ('create_variant', '=', 'always')],
            //                 limit=1,
            //             )
            //             if not attribute:
            //                 attribute = self.env['product.attribute'].create({
            //                     'name': attribute_data['name']
            //                 })
            // 
            //             # Search for the existing attribute value and create it if not found.
            //             attribute_value = self.env['product.attribute.value'].search([
            //                 ('name', '=', attribute_data['value']),
            //                 ('attribute_id', '=', attribute.id),
            //             ], limit=1)
            //             if not attribute_value:
            //                 attribute_value = self.env['product.attribute.value'].create({
            //                     'name': attribute_data['value'],
            //                     'attribute_id': attribute.id
            //                 })
            //             current_variant_pavs += attribute_value
            // 
            //             # Search for the existing PTAL and create it if not found.
            //             ptal = self.env['product.template.attribute.line'].search(
            //                 [('product_tmpl_id', '=', self.id), ('attribute_id', '=', attribute.id)],
            //                 limit=1,
            //             )
            //             if not ptal:
            //                 self.env['product.template.attribute.line'].create({
            //                     'product_tmpl_id': self.id,
            //                     'attribute_id': attribute.id,
            //                     'value_ids': [Command.link(attribute_value.id)]
            //                 })
            //             else:  # The PTAL already exists.
            //                 ptal.value_ids = [Command.link(attribute_value.id)]  # Link the value.
            // 
            //         # Find the variant that was automatically created and set the Gelato UID.
            //         for variant in self.product_variant_ids:
            //             corresponding_ptavs = variant.product_template_attribute_value_ids
            //             corresponding_pavs = corresponding_ptavs.product_attribute_value_id
            //             if corresponding_pavs == current_variant_pavs:
            //                 variant.gelato_product_uid = variant_data['productUid']
            //                 break
            // 
            //     # Delete the incompatible variants that were created but not allowed by Gelato.
            //     variants_without_gelato = self.env['product.product'].search([
            //         ('product_tmpl_id', '=', self.id),
            //         ('gelato_product_uid', '=', False)
            //     ])
            //     variants_without_gelato.unlink()
            --- ODOO METHOD SOURCE (MODULE: website_sale_gelato, FILE: product_template.py) ---
            // def _create_attributes_from_gelato_info(self, template_info):
            // """ Override of `sale_gelato` to set the eCommerce description. """
            // self.description_ecommerce = template_info['description']
            // return super()._create_attributes_from_gelato_info(template_info)
            */
            return default;
        }

        public async Task<TEntity> CreateFirstProductVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities, object log_warning) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> CreateMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sequence, object name, object url, Guid xml_id, object menu_type) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> CreatePrintImagesFromGelatoInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_info) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py) ---
            // def _create_print_images_from_gelato_info(self, template_info):
            // """ Create print image for the current product template.
            // 
            // :param dict template_info: The template information fetched from Gelato.
            // :return: None
            // """
            // # Iterate over the print image data listed in the info of the first variant, as we don't
            // # support varying image placements between variants.
            // for print_image_data in template_info['variants'][0]['imagePlaceholders']:
            //     # Gelato might send image placements that are named '1' or 'front' that are not accepted
            //     # by their API when placing order.
            //     if print_image_data['printArea'].lower() in ('1', 'front'):
            //         print_image_data['printArea'] = 'default'  # Use 'default' which is accepted.
            // 
            //     # Gelato might send several print images for the same placement if several layers were
            //     # defined, but we keep only one because their API only accepts one image per placement.
            //     print_image_found = bool(self.env['product.document'].search_count([
            //         ('name', 'ilike', print_image_data['printArea']),
            //         ('res_id', '=', self.id),
            //         ('res_model', '=', 'product.template'),
            //         ('is_gelato', '=', True),  # Avoid finding regular documents with the same name.
            //     ]))
            //     if not print_image_found:
            //         self.gelato_image_ids = [Command.create({
            //             'name': print_image_data['printArea'].lower(),
            //             'res_id': self.id,
            //             'res_model': 'product.template',
            //             'is_gelato': True,
            //         })]
            */
            return default;
        }

        public async Task<TEntity> CreateProductVariantAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> product_template_attribute_value_ids) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def create_product_variant(self, product_template_attribute_value_ids):
            // """ Create if necessary and possible and return the id of the product
            // variant matching the given combination for this template.
            // 
            // Note AWA: Known "exploit" issues with this method:
            // 
            // - This method could be used by an unauthenticated user to generate a
            //     lot of useless variants. Unfortunately, after discussing the
            //     matter with ODO, there's no easy and user-friendly way to block
            //     that behavior.
            // 
            //     We would have to use captcha/server actions to clean/... that
            //     are all not user-friendly/overkill mechanisms.
            // 
            // - This method could be used to try to guess what product variant ids
            //     are created in the system and what product template ids are
            //     configured as "dynamic", but that does not seem like a big deal.
            // 
            // The error messages are identical on purpose to avoid giving too much
            // information to a potential attacker:
            //     - returning 0 when failing
            //     - returning the variant id whether it already existed or not
            // 
            // :param product_template_attribute_value_ids: the combination for which
            //     to get or create variant
            // :type product_template_attribute_value_ids: list of id
            //     of `product.template.attribute.value`
            // 
            // :return: id of the product variant matching the combination or 0
            // :rtype: int
            // """
            // combination = self.env['product.template.attribute.value'].browse(
            //     product_template_attribute_value_ids)
            // 
            // return self._create_product_variant(combination, log_warning=True).id or 0
            */
            return default;
        }

        public async Task<TEntity> CreateProductVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, object log_warning) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> CreateProductVariantsFromGelatoTemplateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_gelato, FILE: product_template.py) ---
            // def action_create_product_variants_from_gelato_template(self):
            // """ Override of `sale_gelato` to unpublish products for which the synchronization with
            // Gelato led to new print images being created. """
            // image_count_before_sync = len(self.gelato_image_ids)
            // res = super().action_create_product_variants_from_gelato_template()
            // if image_count_before_sync < len(self.gelato_image_ids):
            //     self.is_published = False
            // return res
            */
            return default;
        }

        public async Task<TEntity> CreateVariantIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> CreationSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _creation_subtype(self):
            // return self.env.ref('hr_recruitment.mt_job_new')
            */
            return default;
        }

        public async Task<TEntity> DefaultAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _default_access_token(self):
            // return str(uuid.uuid4())
            */
            return default;
        }

        public async Task<TEntity> DefaultAddressIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _default_address_id(self):
            // last_used_address = self.env['hr.job'].search([('company_id', 'in', self.env.companies.ids)], order='id desc', limit=1)
            // if last_used_address:
            //     return last_used_address.address_id
            // else:
            //     return self.env.company.partner_id
            */
            return default;
        }

        public async Task<TEntity> DefaultContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> DefaultCoverPropertiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
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

        public async Task<TEntity> DefaultDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> DefaultEventMailIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _default_event_mail_ids(self):
            // return self.env['event.type']._default_event_mail_type_ids()
            */
            return default;
        }

        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields_list) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> DefaultIsPublishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_controller_page.py) ---
            // def _default_is_published(self):
            // return False
            */
            return default;
        }

        public async Task<TEntity> DefaultQuestionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _default_question_ids(self):
            // return self.env['event.type']._default_question_ids()
            */
            return default;
        }

        public async Task<TEntity> DefaultSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> DefaultWebsiteMetaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _default_website_meta(self):
            // res = super(Post, self)._default_website_meta()
            // res['default_opengraph']['og:title'] = res['default_twitter']['twitter:title'] = self.name
            // res['default_opengraph']['og:description'] = res['default_twitter']['twitter:description'] = self.plain_content
            // res['default_opengraph']['og:image'] = res['default_twitter']['twitter:image'] = self.env['website'].image_url(self.create_uid, 'image_1024')
            // res['default_twitter']['twitter:card'] = 'summary'
            // res['default_meta_description'] = self.plain_content
            // return res
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _default_website_meta(self):
            // res = super()._default_website_meta()
            // res['default_opengraph']['og:description'] = res['default_twitter']['twitter:description'] = self.description_sale
            // res['default_opengraph']['og:title'] = res['default_twitter']['twitter:title'] = self.name
            // res['default_opengraph']['og:image'] = res['default_twitter']['twitter:image'] = self.env['website'].image_url(self, 'image_1024')
            // res['default_meta_description'] = self.description_sale
            // return res
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

        public async Task<TEntity> DefaultWebsiteSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _default_website_sequence(self):
            // """ We want new product to be the last (highest seq).
            // Every product should ideally have an unique sequence.
            // Default sequence (10000) should only be used for DB first product.
            // As we don't resequence the whole tree (as `sequence` does), this field
            // might have negative value.
            // """
            // self.env.cr.execute('SELECT MAX(website_sequence) FROM %s' % self._table)
            // max_sequence = self.env.cr.fetchone()[0]
            // if max_sequence is None:
            //     return 10000
            // return max_sequence + 5
            */
            return default;
        }

        public async Task<TEntity> DemoConfigureVariantsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> DislikeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def action_dislike(self):
            // self.check_access('read')
            // return self._action_vote(upvote=False)
            */
            return default;
        }

        public async Task<TEntity> EditDialogAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def edit_dialog(self):
            // form_view = self.env.ref('hr.view_hr_job_form')
            // return {
            //     'name': _('Job'),
            //     'res_model': 'hr.job',
            //     'res_id': self.id,
            //     'views': [(form_view.id, 'form')],
            //     'type': 'ir.actions.act_window',
            //     'target': 'inline'
            // }
            */
            return default;
        }

        public async Task<TEntity> EmbedIncrementInternalAsync<TEntity>(IEnumerable<TEntity> entities, object url) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> FetchExternalMetadataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object image_url_only) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> FetchGoogleDriveMetadataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object image_url_only) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> FetchIsParticipatingEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> FetchVimeoMetadataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object image_url_only) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> FetchYoutubeMetadataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object image_url_only) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> FilterAddMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_partners, object raise_on_access) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> FilterCombinationsImpossibleByConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination_tuples, object ignore_no_variant) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> FlagInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _flag(self):
            // res = []
            // for post in self:
            //     if not post.can_flag:
            //         raise AccessError(_('%d karma required to flag a post.', post.forum_id.karma_flag))
            //     if post.state == 'flagged':
            //        res.append({'error': 'post_already_flagged'})
            //     elif post.state == 'active':
            //         # TODO: potential performance bottleneck, can be batched
            //         post.write({
            //             'state': 'flagged',
            //             'flag_user_id': self.env.user.id,
            //         })
            //         res.append(
            //             post.can_moderate and
            //             {'success': 'post_flagged_moderator'} or
            //             {'success': 'post_flagged_non_moderator'}
            //         )
            //     else:
            //         res.append({'error': 'post_non_flaggable'})
            // return res
            */
            return default;
        }

        public async Task<TEntity> ForceDefaultPurchaseTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object companies) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _force_default_purchase_tax(self, companies):
            // default_supplier_taxes = companies.filtered('account_purchase_tax_id').account_purchase_tax_id
            // for product_grouped_by_tax in self.grouped('supplier_taxes_id').values():
            //     product_grouped_by_tax.supplier_taxes_id += default_supplier_taxes
            // self.invalidate_recordset(['supplier_taxes_id'])
            */
            return default;
        }

        public async Task<TEntity> ForceDefaultSaleTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object companies) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _force_default_sale_tax(self, companies):
            // default_customer_taxes = companies.filtered('account_sale_tax_id').account_sale_tax_id
            // for product_grouped_by_tax in self.grouped('taxes_id').values():
            //     product_grouped_by_tax.taxes_id += default_customer_taxes
            // self.invalidate_recordset(['taxes_id'])
            */
            return default;
        }

        public async Task<TEntity> ForceDefaultTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object companies) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _force_default_tax(self, companies):
            // self._force_default_sale_tax(companies)
            // self._force_default_purchase_tax(companies)
            */
            return default;
        }

        public async Task<TEntity> GcMarkEventsDoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GenerateLeadsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GenerateSignedTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetAccessActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid, object force_website) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _get_access_action(self, access_uid=None, force_website=False):
            // """ Instead of the classic form view, redirect to the post on the website directly """
            // self.ensure_one()
            // if not force_website and not self.state == 'active':
            //     return super(Post, self)._get_access_action(access_uid=access_uid, force_website=force_website)
            // return {
            //     'type': 'ir.actions.act_url',
            //     'url': '/forum/%s/%s' % (self.forum_id.id, self.id),
            //     'target': 'self',
            //     'target_type': 'public',
            //     'res_id': self.id,
            // }
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

        public async Task<TEntity> GetActionViewRelatedPutawayRulesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _get_action_view_related_putaway_rules(self, domain):
            // return {
            //     'name': _('Putaway Rules'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'stock.putaway.rule',
            //     'view_mode': 'list',
            //     'domain': domain,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetAdditionalConfiguratorDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_or_template, object date, object currency, object pricelist) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_additional_configurator_data(
            //     self, product_or_template, date, currency, pricelist, **kwargs
            // ):
            //     """ Override of `sale` to append tracking data.
            // 
            //     :param product.product|product.template product_or_template: The product for which to get
            //         additional data.
            //     :param datetime date: The date to use to compute prices.
            //     :param res.currency currency: The currency to use to compute prices.
            //     :param product.pricelist pricelist: The pricelist to use to compute prices.
            //     :param dict kwargs: Locally unused data passed to `super`.
            //     :rtype: dict
            //     :return: A dict containing additional data about the specified product.
            //     """
            //     data = super()._get_additional_configurator_data(
            //         product_or_template, date, currency, pricelist, **kwargs
            //     )
            // 
            //     if ir_http.get_request_website():
            //         data.update({
            //             # The following fields are needed for tracking.
            //             'category_name': product_or_template.categ_id.name,
            //             'currency_name': currency.name,
            //         })
            //     return data
            */
            return default;
        }

        public async Task<TEntity> GetAdditionnalCombinationInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_or_template, object quantity, object date, object website) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_additionnal_combination_info(self, product_or_template, quantity, date, website):
            // """Computes additional combination info, based on given parameters
            // 
            // :param product_or_template: `product.product` or `product.template` record
            //     as variant values must take precedence over template values (when we have a variant)
            // :param float quantity:
            // :param date date: today's date, avoids useless calls to today/context_today and harmonize
            //     behavior
            // :param website: `website` record holding the current website of the request (if any),
            //     or the contextual website (tests, ...)
            // :returns: additional product/template information
            // :rtype: dict
            // """
            // pricelist = website.pricelist_id
            // currency = website.currency_id
            // 
            // # Pricelist price doesn't have to be converted
            // pricelist_price, pricelist_rule_id = pricelist._get_product_price_rule(
            //     product=product_or_template,
            //     quantity=quantity,
            //     target_currency=currency,
            // )
            // 
            // price_before_discount = pricelist_price
            // pricelist_item = self.env['product.pricelist.item'].browse(pricelist_rule_id)
            // if pricelist_item._show_discount_on_shop():
            //     price_before_discount = pricelist_item._compute_price_before_discount(
            //         product=product_or_template,
            //         quantity=quantity or 1.0,
            //         date=date,
            //         uom=product_or_template.uom_id,
            //         currency=currency,
            //     )
            // 
            // has_discounted_price = price_before_discount > pricelist_price
            // combination_info = {
            //     'list_price': max(pricelist_price, price_before_discount),
            //     'price': pricelist_price,
            //     'has_discounted_price': has_discounted_price,
            // }
            // 
            // comparison_price = None
            // if (
            //     not has_discounted_price
            //     and product_or_template.compare_list_price
            //     and self.env.user.has_group('website_sale.group_product_price_comparison')
            // ):
            //     comparison_price = product_or_template.currency_id._convert(
            //         from_amount=product_or_template.compare_list_price,
            //         to_currency=currency,
            //         company=self.env.company,
            //         date=date,
            //         round=False)
            // combination_info['compare_list_price'] = comparison_price
            // 
            // combination_info['price_extra'] = product_or_template.currency_id._convert(
            //     from_amount=product_or_template._get_attributes_extra_price(),
            //     to_currency=currency,
            //     company=self.env.company,
            //     date=date,
            //     round=False,
            // )
            // 
            // # Apply taxes
            // fiscal_position = website.fiscal_position_id.sudo()
            // 
            // product_taxes = product_or_template.sudo().taxes_id._filter_taxes_by_company(self.env.company)
            // taxes = self.env['account.tax']
            // if product_taxes:
            //     taxes = fiscal_position.map_tax(product_taxes)
            //     # We do not apply taxes on the compare_list_price value because it's meant to be
            //     # a strict value displayed as is.
            //     for price_key in ('price', 'list_price', 'price_extra'):
            //         combination_info[price_key] = self._apply_taxes_to_price(
            //             combination_info[price_key],
            //             currency,
            //             product_taxes,
            //             taxes,
            //             product_or_template,
            //             website=website,
            //         )
            // 
            // combination_info.update({
            //     'prevent_zero_price_sale': website.prevent_zero_price_sale and float_is_zero(
            //         combination_info['price'],
            //         precision_rounding=currency.rounding,
            //     ),
            // 
            //     'base_unit_name': product_or_template.base_unit_name,
            //     'base_unit_price': product_or_template._get_base_unit_price(combination_info['price']),
            // 
            //     # additional info to simplify overrides
            //     'currency': currency,  # displayed currency
            //     'date': date,
            //     'product_taxes': product_taxes,  # taxes before fpos mapping
            //     'taxes': taxes,  # taxes after fpos mapping
            // })
            // 
            // if combination_info['prevent_zero_price_sale']:
            //     combination_info['compare_list_price'] = 0
            // 
            // return combination_info
            */
            return default;
        }

        public async Task<TEntity> GetAlternativeProductFilterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_alternative_product_filter(self):
            // return self.env.ref('website_sale.dynamic_filter_cross_selling_alternative_products').id
            */
            return default;
        }

        public async Task<TEntity> GetAssetAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _get_asset_accounts(self):
            // res = {}
            // res['stock_input'] = False
            // res['stock_output'] = False
            // return res
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: product.py) ---
            // def _get_asset_accounts(self):
            // res = super(ProductTemplate, self)._get_asset_accounts()
            // if self.asset_category_id:
            //     res['stock_input'] = self.property_account_expense_id
            // if self.deferred_revenue_category_id:
            //     res['stock_output'] = self.property_account_income_id
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetAttribValuesDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attribute_values) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_attrib_values_domain(self, attribute_values):
            // attribute_id = None
            // attribute_value_ids = []
            // domains = []
            // for value in attribute_values:
            //     if not attribute_id:
            //         attribute_id = value[0]
            //         attribute_value_ids.append(value[1])
            //     elif value[0] == attribute_id:
            //         attribute_value_ids.append(value[1])
            //     else:
            //         domains.append([('attribute_line_ids.value_ids', 'in', attribute_value_ids)])
            //         attribute_id = value[0]
            //         attribute_value_ids = [value[1]]
            // if attribute_id:
            //     domains.append([('attribute_line_ids.value_ids', 'in', attribute_value_ids)])
            // return domains
            */
            return default;
        }

        public async Task<TEntity> GetAttributeExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination, object parent_name, List<Guid> combination_ids) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetAttributesExtraPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetBackendMenuIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def get_backend_menu_id(self):
            // return self.env.ref('event.event_main_menu').id
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def get_backend_menu_id(self):
            // return self.env.ref('hr_recruitment.menu_hr_recruitment_root').id
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def get_backend_menu_id(self):
            // return self.env.ref('website_slides.website_slides_menu_root').id
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def get_backend_menu_id(self):
            // return self.env.ref('website_slides.website_slides_menu_root').id
            */
            return default;
        }

        public async Task<TEntity> GetBackendRootMenuIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _get_backend_root_menu_ids(self):
            // return super()._get_backend_root_menu_ids() + [self.env.ref('mrp.menu_mrp_root').id]
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: product.py) ---
            // def _get_backend_root_menu_ids(self):
            // return super()._get_backend_root_menu_ids() + [self.env.ref('purchase.menu_purchase_root').id]
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _get_backend_root_menu_ids(self):
            // return super()._get_backend_root_menu_ids() + [self.env.ref('sale.sale_menu_root').id]
            */
            return default;
        }

        public async Task<TEntity> GetBaseUnitPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_base_unit_price(self, price):
            // self.ensure_one()
            // return self.base_unit_count and price / self.base_unit_count
            */
            return default;
        }

        public async Task<TEntity> GetBoothStatCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetBuyRouteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: product.py) ---
            // def _get_buy_route(self):
            // buy_route = self.env.ref('purchase_stock.route_warehouse0_buy', raise_if_not_found=False)
            // if buy_route:
            //     return self.env['stock.route'].search([('id', '=', buy_route.id)]).ids
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetCanPublishErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetCategorizedSlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_domain, object order, object force_void, object limit, object offset) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetClosestPossibleCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetClosestPossibleCombinationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetCombinationInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, Guid product_id, object add_qty, object parent_combination, object only_template) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_combination_info(
            //     self, combination=False, product_id=False, add_qty=1.0,
            //     parent_combination=False, only_template=False,
            // ):
            //     """ Return info about a given combination.
            // 
            //     Note: this method does not take into account whether the combination is
            //     actually possible.
            // 
            //     :param combination: recordset of `product.template.attribute.value`
            // 
            //     :param int product_id: `product.product` id. If no `combination`
            //         is set, the method will try to load the variant `product_id` if
            //         it exists instead of finding a variant based on the combination.
            // 
            //         If there is no combination, that means we definitely want a
            //         variant and not something that will have no_variant set.
            // 
            //     :param float add_qty: the quantity for which to get the info,
            //         indeed some pricelist rules might depend on it.
            // 
            //     :param parent_combination: if no combination and no product_id are
            //         given, it will try to find the first possible combination, taking
            //         into account parent_combination (if set) for the exclusion rules.
            // 
            //     :param only_template: boolean, if set to True, get the info for the
            //         template only: ignore combination and don't try to find variant
            // 
            //     :return: dict with product/combination info:
            // 
            //         - product_id: the variant id matching the combination (if it exists)
            // 
            //         - product_template_id: the current template id
            // 
            //         - display_name: the name of the combination
            // 
            //         - price: the computed price of the combination, take the catalog
            //             price if no pricelist is given
            // 
            //         - price_extra: the computed extra price of the combination
            // 
            //         - list_price: the catalog price of the combination, but this is
            //             not the "real" list_price, it has price_extra included (so
            //             it's actually more closely related to `lst_price`), and it
            //             is converted to the pricelist currency (if given)
            // 
            //         - has_discounted_price: True if the pricelist discount policy says
            //             the price does not include the discount and there is actually a
            //             discount applied (price < list_price), else False
            //     """
            //     self.ensure_one()
            // 
            //     combination = combination or self.env['product.template.attribute.value']
            //     parent_combination = parent_combination or self.env['product.template.attribute.value']
            //     website = self.env['website'].get_current_website().with_context(self.env.context)
            // 
            //     if not product_id and not combination and not only_template:
            //         combination = self._get_first_possible_combination(parent_combination)
            // 
            //     if only_template:
            //         product = self.env['product.product']
            //     elif product_id:
            //         product = self.env['product.product'].browse(product_id)
            //         if (combination - product.product_template_attribute_value_ids):
            //             # If the combination is not fully represented in the given product
            //             #   make sure to fetch the right product for the given combination
            //             product = self._get_variant_for_combination(combination)
            //     else:
            //         product = self._get_variant_for_combination(combination)
            // 
            //     product_or_template = product or self
            //     combination = combination or product.product_template_attribute_value_ids
            // 
            //     display_name = product_or_template.with_context(display_default_code=False).display_name
            //     if not product:
            //         combination_name = combination._get_combination_name()
            //         if combination_name:
            //             display_name = f"{display_name} ({combination_name})"
            // 
            //     price_context = product_or_template._get_product_price_context(combination)
            //     product_or_template = product_or_template.with_context(**price_context)
            // 
            //     combination_info = {
            //         'combination': combination,
            //         'product_id': product.id,
            //         'product_template_id': self.id,
            //         'display_name': display_name,
            //         'display_image': bool(product_or_template.image_128),
            //         'is_combination_possible': self._is_combination_possible(combination=combination, parent_combination=parent_combination),
            //         'parent_exclusions': self._get_parent_attribute_exclusions(parent_combination=parent_combination),
            // 
            //         **self._get_additionnal_combination_info(
            //             product_or_template=product_or_template,
            //             quantity=add_qty or 1.0,
            //             date=fields.Date.context_today(self),
            //             website=website,
            //         )
            //     }
            // 
            //     if website.google_analytics_key:
            //         combination_info['product_tracking_info'] = self._get_google_analytics_data(
            //             product,
            //             combination_info,
            //         )
            // 
            //     if (
            //         product_or_template.type == 'combo'
            //         and website.show_line_subtotals_tax_selection == 'tax_included'
            //         and not all(
            //             tax.price_include
            //             for tax
            //             in product_or_template.combo_ids.sudo().combo_item_ids.product_id.taxes_id
            //         )
            //     ):
            //         combination_info['tax_disclaimer'] = _(
            //             "Final price may vary based on selection. Tax will be calculated at checkout."
            //         )
            // 
            //     return combination_info
            */
            return default;
        }

        public async Task<TEntity> GetCompletionTimePdfInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data_bytes) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetConfiguratorDisplayPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_or_template, object quantity, object date, object currency, object pricelist) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_configurator_display_price(
            //     self, product_or_template, quantity, date, currency, pricelist, **kwargs
            // ):
            //     """ Override of `sale` to apply taxes.
            // 
            //     :param product.product|product.template product_or_template: The product for which to get
            //         the price.
            //     :param int quantity: The quantity of the product.
            //     :param datetime date: The date to use to compute the price.
            //     :param res.currency currency: The currency to use to compute the price.
            //     :param product.pricelist pricelist: The pricelist to use to compute the price.
            //     :param dict kwargs: Locally unused data passed to `super`.
            //     :rtype: tuple(float, int or False)
            //     :return: The specified product's display price (and the applied pricelist rule)
            //     """
            //     price, pricelist_rule_id = super()._get_configurator_display_price(
            //         product_or_template, quantity, date, currency, pricelist, **kwargs
            //     )
            // 
            //     if website := ir_http.get_request_website():
            //         product_taxes = product_or_template.sudo().taxes_id._filter_taxes_by_company(
            //             self.env.company
            //         )
            //         if product_taxes:
            //             fiscal_position = website.fiscal_position_id.sudo()
            //             taxes = fiscal_position.map_tax(product_taxes)
            //             return self._apply_taxes_to_price(
            //                 price, currency, product_taxes, taxes, product_or_template, website=website
            //             ), pricelist_rule_id
            //     return price, pricelist_rule_id
            */
            return default;
        }

        public async Task<TEntity> GetConfiguratorPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_or_template, object quantity, object date, object currency, object pricelist) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _get_configurator_price(
            //     self, product_or_template, quantity, date, currency, pricelist, **kwargs
            // ):
            //     """ Return the specified product's price, to be used by the product and combo configurators.
            // 
            //     This is a hook meant to customize the price computation in overriding modules.
            // 
            //     This hook has been extracted from `_get_configurator_display_price` because the price
            //     computation can be overridden in 2 ways:
            // 
            //     - Either by transforming super's price (e.g. in `website_sale`, we apply taxes to the
            //       price),
            //     - Or by computing a different price (e.g. in `sale_subscription`, we ignore super when
            //       computing subscription prices).
            //     In some cases, the order of the overrides matters, which is why we need 2 separate methods
            //     (e.g. in `website_sale_subscription`, we must compute the subscription price before applying
            //     taxes).
            // 
            //     :param product.product|product.template product_or_template: The product for which to get
            //         the price.
            //     :param int quantity: The quantity of the product.
            //     :param datetime date: The date to use to compute the price.
            //     :param res.currency currency: The currency to use to compute the price.
            //     :param product.pricelist pricelist: The pricelist to use to compute the price.
            //     :param dict kwargs: Locally unused data passed to `_get_product_price`.
            //     :rtype: tuple(float, int or False)
            //     :return: The specified product's price (and the applied pricelist rule)
            //     """
            //     return pricelist._get_product_price_rule(
            //         product_or_template, quantity=quantity, currency=currency, date=date, **kwargs
            //     )
            */
            return default;
        }

        public async Task<TEntity> GetContextualPriceAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def get_contextual_price(self, product=None):
            // return self._get_contextual_price(product=product)
            */
            return default;
        }

        public async Task<TEntity> GetContextualPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetContextualPricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_contextual_pricelist(self):
            // """ Override to fallback on website current pricelist """
            // pricelist = super()._get_contextual_pricelist()
            // if not pricelist:
            //     website = ir_http.get_request_website()
            //     if website:
            //         return website.pricelist_id
            // return pricelist
            */
            return default;
        }

        public async Task<TEntity> GetDateRangeStrInternalAsync<TEntity>(IEnumerable<TEntity> entities, object lang_code) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetDefaultCategoryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_default_category_id(self):
            // # Deletion forbidden (at least through unlink)
            // return self.env.ref('product.product_category_all')
            */
            return default;
        }

        public async Task<TEntity> GetDefaultEnrollMsgInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _get_default_enroll_msg(self):
            // return _('Contact Responsible')
            */
            return default;
        }

        public async Task<TEntity> GetDefaultFavoriteUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _get_default_favorite_user_ids(self):
            // return [(6, 0, [self.env.uid])]
            */
            return default;
        }

        public async Task<TEntity> GetDefaultJobDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def _get_default_job_details(self):
            // return _("""
            //     <span class="text-muted small">Time to Answer</span>
            //     <h6>2 open days</h6>
            //     <span class="text-muted small">Process</span>
            //     <h6>1 Phone Call</h6>
            //     <h6>1 Onsite Interview</h6>
            //     <span class="text-muted small">Days to get an Offer</span>
            //     <h6>4 Days after Interview</h6>
            // """)
            */
            return default;
        }

        public async Task<TEntity> GetDefaultStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_default_stage_id(self):
            // return self.env['event.stage'].search([], limit=1)
            */
            return default;
        }

        public async Task<TEntity> GetDefaultUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_default_uom_id(self):
            // # Deletion forbidden (at least through unlink)
            // return self.env.ref('uom.product_uom_unit')
            */
            return default;
        }

        public async Task<TEntity> GetDefaultWebsiteDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def _get_default_website_description(self):
            // return self.env['ir.qweb']._render("website_hr_recruitment.default_website_description", raise_if_not_found=False)
            */
            return default;
        }

        public async Task<TEntity> GetDefaultWelcomeMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetEarnedKarmaInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetEmptyListHelpAsync<TEntity>(IEnumerable<TEntity> entities, object help_message) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetEventPrintDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetEventResourceUrlsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetEventTimeframeStringInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetExternalDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetFirstPossibleCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination, object necessary_values) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetFirstPossibleVariantIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetFirstStageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _get_first_stage(self):
            // self.ensure_one()
            // return self.env['hr.recruitment.stage'].search([
            //     '|',
            //     ('job_ids', '=', False),
            //     ('job_ids', '=', self.id)], order='sequence asc', limit=1)
            */
            return default;
        }

        public async Task<TEntity> GetGeneralToServiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_policy, object service_type) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _get_general_to_service(self, invoice_policy, service_type):
            // general_to_service = self._get_general_to_service_map()
            // return general_to_service.get((invoice_policy, service_type), False)
            */
            return default;
        }

        public async Task<TEntity> GetGeneralToServiceMapInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _get_general_to_service_map(self):
            // return {v: k for k, v in self._get_service_to_general_map().items()}
            */
            return default;
        }

        public async Task<TEntity> GetGoogleAnalyticsDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product, object combination_info) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_google_analytics_data(self, product, combination_info):
            // self.ensure_one()
            // return {
            //     'item_id': product.barcode or product.id,
            //     'item_name': combination_info['display_name'],
            //     'item_category': self.categ_id.name,
            //     'currency': combination_info['currency'].name,
            //     'price': combination_info['list_price'],
            // }
            */
            return default;
        }

        public async Task<TEntity> GetIcsFileInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetImageHolderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_image_holder(self):
            // """Returns the holder of the image to use as default representation.
            // If the product template has an image it is the product template,
            // otherwise if the product has variants it is the first variant
            // 
            // :return: this product template or the first product variant
            // :rtype: recordset of 'product.template' or recordset of 'product.product'
            // """
            // self.ensure_one()
            // if self.image_128:
            //     return self
            // variant = self.env['product.product'].browse(self._get_first_possible_variant_id())
            // # if the variant has no image anyway, spare some queries by using template
            // return variant if variant.image_variant_128 else self
            */
            return default;
        }

        public async Task<TEntity> GetImagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_images(self):
            // """Return a list of records implementing `image.mixin` to
            // display on the carousel on the website for this template.
            // 
            // This returns a list and not a recordset because the records might be
            // from different models (template and image).
            // 
            // It contains in this order: the main image of the template and the
            // Template Extra Images.
            // """
            // self.ensure_one()
            // return [self] + list(self.product_template_image_ids)
            */
            return default;
        }

        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Products'),
            //     'template': '/product/static/xls/product_template.xls'
            // }]
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: product.py) ---
            // def get_import_templates(self):
            // res = super(ProductTemplate, self).get_import_templates()
            // if self.env.context.get('purchase_product_template'):
            //     return [{
            //         'label': _('Import Template for Products'),
            //         'template': '/purchase/static/xls/product_purchase.xls'
            //     }]
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def get_import_templates(self):
            // res = super(ProductTemplate, self).get_import_templates()
            // if self.env.context.get('sale_multi_pricelist_product_template'):
            //     if self.env.user.has_group('product.group_product_pricelist'):
            //         return [{
            //             'label': _("Import Template for Products"),
            //             'template': '/product/static/xls/product_template.xls'
            //         }]
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetIncompatibleTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _get_incompatible_types(self):
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetKioskUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def get_kiosk_url(self):
            // return self.get_base_url() + "/odoo/registration-desk"
            */
            return default;
        }

        public async Task<TEntity> GetLengthUomIdFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetLengthUomNameFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_length_uom_name_from_ir_config_parameter(self):
            // return self._get_length_uom_id_from_ir_config_parameter().display_name
            */
            return default;
        }

        public async Task<TEntity> GetListPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _get_list_price(self, price):
            // """ Get the product sales price from a public price based on taxes defined on the product """
            // self.ensure_one()
            // if not self.taxes_id:
            //     return super()._get_list_price(price)
            // computed_price = self.taxes_id.compute_all(price, self.currency_id)
            // total_included = computed_price["total_included"]
            // 
            // if price == total_included:
            //     # Tax is configured as price included
            //     return total_included
            // # calculate base from tax
            // included_computed_price = self.taxes_id.with_context(force_price_include=True).compute_all(price, self.currency_id)
            // return included_computed_price['total_excluded']
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_list_price(self, price):
            // """ Get the product sales price from a public price based on taxes defined on the product.
            // To be overridden in accounting module."""
            // self.ensure_one()
            // return price
            */
            return default;
        }

        public async Task<TEntity> GetMailMessageAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object operation, object model_name) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _get_mail_message_access(self, res_ids, operation, model_name=None):
            // # XDO FIXME: to be correctly fixed with new _get_mail_message_access and filter access rule
            // if operation in ('write', 'unlink') and (not model_name or model_name == 'forum.post'):
            //     # Make sure only author or moderator can edit/delete messages
            //     for post in self.browse(res_ids):
            //         if not post.can_edit:
            //             raise AccessError(_('%d karma required to edit a post.', post.karma_edit))
            // return super(Post, self)._get_mail_message_access(res_ids, operation, model_name=model_name)
            */
            return default;
        }

        public async Task<TEntity> GetMappedAttributeNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetMenuTypeFieldMatchingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetMenuUpdateFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetMenusUpdateByFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object menus_state_by_field, object force_update) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetMicrodataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _get_microdata(self):
            // """
            // Generate structured data (microdata) for the post.
            // 
            // Returns:
            //     str or None: Microdata in JSON format representing the post, or None
            //     if not applicable.
            // """
            // self.ensure_one()
            // # Return if it's not a question.
            // if self.parent_id:
            //     return None
            // correct_posts = self.child_ids.filtered(lambda post: post.is_correct)
            // suggested_posts = self.child_ids.filtered(lambda post: not post.is_correct)[:5]
            // # A QAPage schema must have one accepted answer or at least one suggested answer
            // if not suggested_posts and not correct_posts:
            //     return None
            // 
            // structured_data = {
            //     "@context": "https://schema.org",
            //     "@type": "QAPage",
            //     "mainEntity": self._get_structured_data(post_type="question"),
            // }
            // if correct_posts:
            //     structured_data["mainEntity"]["acceptedAnswer"] = correct_posts[0]._get_structured_data()
            // if suggested_posts:
            //     structured_data["mainEntity"]["suggestedAnswer"] = [
            //         suggested_post._get_structured_data()
            //         for suggested_post in suggested_posts
            //     ]
            // return json_safe.dumps(structured_data, indent=2)
            */
            return default;
        }

        public async Task<TEntity> GetMostSpecificPagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _get_most_specific_pages(self):
            // ''' Returns the most specific pages in self. '''
            // ids = []
            // previous_page = None
            // page_keys = self.sudo().search(
            //     self.env['website'].website_domain(website_id=self._context.get('website_id'))
            // ).mapped('key')
            // # Iterate a single time on the whole list sorted on specific-website first.
            // for page in self.sorted(key=lambda p: (p.url, not p.website_id)):
            //     if (
            //         (not previous_page or page.url != previous_page.url)
            //         # If a generic page (niche case) has been COWed and that COWed
            //         # page received a URL change, it should not let you access the
            //         # generic page anymore, despite having a different URL.
            //         and (page.website_id or page_keys.count(page.key) == 1)
            //     ):
            //         ids.append(page.id)
            //     previous_page = page
            // return self.browse(ids)
            */
            return default;
        }

        public async Task<TEntity> GetNextCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetOnchangeServicePolicyUpdatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service_tracking, object service_policy, Guid project_id, Guid project_template_id) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def _get_onchange_service_policy_updates(self, service_tracking, service_policy, project_id, project_template_id):
            // vals = {}
            // if service_tracking != 'no' and service_policy == 'delivered_timesheet':
            //     if project_id and not project_id.allow_timesheets:
            //         vals['project_id'] = False
            //     elif project_template_id and not project_template_id.allow_timesheets:
            //         vals['project_template_id'] = False
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetOwnAttributeExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> combination_ids) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetParentAttributeExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetPlaceholderFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
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

        public async Task<TEntity> GetPossibleCombinationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination, object necessary_values) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetPossibleVariantsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetPossibleVariantsSortedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_possible_variants_sorted(self, parent_combination=None):
            // """Return the sorted recordset of variants that are possible.
            // 
            // The order is based on the order of the attributes and their values.
            // 
            // See `_get_possible_variants` for the limitations of this method with
            // dynamic or no_variant attributes, and also for a warning about
            // performances.
            // 
            // :param parent_combination: combination from which `self` is an
            //     optional or accessory product
            // :type parent_combination: recordset `product.template.attribute.value`
            // 
            // :return: the sorted variants that are possible
            // :rtype: recordset of `product.product`
            // """
            // self.ensure_one()
            // 
            // def _sort_key_attribute_value(value):
            //     # if you change this order, keep it in sync with _order from `product.attribute`
            //     return (value.attribute_id.sequence, value.attribute_id.id)
            // 
            // def _sort_key_variant(variant):
            //     """
            //         We assume all variants will have the same attributes, with only one value for each.
            //             - first level sort: same as "product.attribute"._order
            //             - second level sort: same as "product.attribute.value"._order
            //     """
            //     keys = []
            //     for attribute in variant.product_template_attribute_value_ids.sorted(_sort_key_attribute_value):
            //         # if you change this order, keep it in sync with _order from `product.attribute.value`
            //         keys.append(attribute.product_attribute_value_id.sequence)
            //         keys.append(attribute.id)
            //     return keys
            // 
            // return self._get_possible_variants(parent_combination).sorted(_sort_key_variant)
            */
            return default;
        }

        public async Task<TEntity> GetPrintingSponsorTextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_printing_sponsor_text(self):
            // sponsor_text = self.env['ir.config_parameter'].sudo().get_param('event.badge_printing_sponsor_text')
            // return sponsor_text or "Powered by Odoo"
            */
            return default;
        }

        public async Task<TEntity> GetProductAccountsAsync<TEntity>(IEnumerable<TEntity> entities, object fiscal_pos) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def get_product_accounts(self, fiscal_pos=None):
            // return {
            //     key: (fiscal_pos or self.env['account.fiscal.position']).map_account(account)
            //     for key, account in self._get_product_accounts().items()
            // }
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def get_product_accounts(self, fiscal_pos=None):
            // """ Add the stock journal related to product to the result of super()
            // @return: dictionary which contains all needed information regarding stock accounts and journal and super (income+expense accounts)
            // """
            // accounts = super(ProductTemplate, self).get_product_accounts(fiscal_pos=fiscal_pos)
            // accounts.update({'stock_journal': self.categ_id.property_stock_journal or False})
            // return accounts
            */
            return default;
        }

        public async Task<TEntity> GetProductAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _get_product_accounts(self):
            // return {
            //     'income': self.property_account_income_id or self.categ_id.property_account_income_categ_id,
            //     'expense': self.property_account_expense_id or self.categ_id.property_account_expense_categ_id
            // }
            --- ODOO METHOD SOURCE (MODULE: l10n_de, FILE: datev.py) ---
            // def _get_product_accounts(self):
            // """ As taxes with a different rate need a different income/expense account, we add this logic in case people only use
            //  invoicing to not be blocked by the above constraint"""
            // result = super(ProductTemplate, self)._get_product_accounts()
            // company = self.env.company
            // if company.account_fiscal_country_id.code == "DE":
            //     if not self.property_account_income_id:
            //         taxes = self.taxes_id.filtered_domain(self.env['account.tax']._check_company_domain(company))
            //         if not result['income'] or (result['income'].tax_ids and taxes and taxes[0] not in result['income'].tax_ids):
            //             result_income = self.env['account.account'].with_company(company).search([
            //                 *self.env['account.account']._check_company_domain(company),
            //                 ('internal_group', '=', 'income'),
            //                 ('deprecated', '=', False),
            //                 ('tax_ids', 'in', taxes.ids)
            //             ], limit=1)
            //             result['income'] = result_income or result['income']
            //     if not self.property_account_expense_id:
            //         supplier_taxes = self.supplier_taxes_id.filtered_domain(self.env['account.tax']._check_company_domain(company))
            //         if not result['expense'] or (result['expense'].tax_ids and supplier_taxes and supplier_taxes[0] not in result['expense'].tax_ids):
            //             result_expense = self.env['account.account'].with_company(company).search([
            //                 *self.env['account.account']._check_company_domain(company),
            //                 ('internal_group', '=', 'expense'),
            //                 ('deprecated', '=', False),
            //                 ('tax_ids', 'in', supplier_taxes.ids),
            //             ], limit=1)
            //             result['expense'] = result_expense or result['expense']
            // return result
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: product.py) ---
            // def _get_product_accounts(self):
            // accounts = super()._get_product_accounts()
            // accounts.update({
            //     'production': self.categ_id.property_stock_account_production_cost_id,
            // })
            // return accounts
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _get_product_accounts(self):
            // product_accounts = super()._get_product_accounts()
            // product_accounts['downpayment'] = self.categ_id.property_account_downpayment_categ_id
            // return product_accounts
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _get_product_accounts(self):
            // """ Add the stock accounts related to product to the result of super()
            // @return: dictionary which contains information regarding stock accounts and super (income+expense accounts)
            // """
            // accounts = super(ProductTemplate, self)._get_product_accounts()
            // res = self._get_asset_accounts()
            // accounts.update({
            //     'stock_input': res['stock_input'] or self.categ_id.property_stock_account_input_categ_id,
            //     'stock_output': res['stock_output'] or self.categ_id.property_stock_account_output_categ_id,
            //     'stock_valuation': self.categ_id.property_stock_valuation_account_id,
            // })
            // return accounts
            */
            return default;
        }

        public async Task<TEntity> GetProductDocumentDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py) ---
            // def _get_product_document_domain(self):
            // """ Override of `product` to filter out gelato print images. """
            // domain = super()._get_product_document_domain()
            // return expression.AND([domain, [('is_gelato', '=', False)]])
            */
            return default;
        }

        public async Task<TEntity> GetProductPriceContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetProductTypesAllowZeroPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_product_types_allow_zero_price(self):
            // """
            // Returns a list of service_tracking (`product.template.service_tracking`) that can ignore the
            // `prevent_zero_price_sale` rule when buying products on a website.
            // """
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetRelatedFieldsVariantTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_related_fields_variant_template(self):
            // """ Return a list of fields present on template and variants models and that are related"""
            // return ['barcode', 'default_code', 'standard_price', 'volume', 'weight', 'packaging_ids', 'product_properties']
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py) ---
            // def _get_related_fields_variant_template(self):
            // """ Override of `product` to add `gelato_product_uid` as a related field. """
            // return super()._get_related_fields_variant_template() + ['gelato_product_uid']
            */
            return default;
        }

        public async Task<TEntity> GetRelatedPostsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object limit) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _get_related_posts(self, limit=5):
            // """Return at most a list of {limit} posts related to the main post, based on tag
            // Jaccard similarity. It computes similarity of sets based on ratio of sets
            // intersection divided by sets union (and thus varies from 0 to 1, 1 being
            // identical sets)."""
            // 
            // self.ensure_one()
            // 
            // if not self.tag_ids:
            //     return self.env['forum.post']
            // 
            // self.env.cr.execute(SQL("""
            //     SELECT forum_post.id,
            //       -- Jaccard similarity
            //            (COUNT(DISTINCT intersection_tag_rel.forum_tag_id))::DECIMAL
            //            / COUNT(DISTINCT union_tag_rel.forum_tag_id)::DECIMAL AS similarity
            //       FROM forum_post
            //       -- common tags (intersection)
            //       JOIN forum_tag_rel AS intersection_tag_rel
            //         ON intersection_tag_rel.forum_post_id = forum_post.id
            //        AND intersection_tag_rel.forum_tag_id = ANY(%(tag_ids)s)
            //       -- union tags
            // RIGHT JOIN forum_tag_rel AS union_tag_rel
            //         ON union_tag_rel.forum_post_id = forum_post.id
            //         OR union_tag_rel.forum_post_id = %(current_post_id)s
            //      WHERE id != %(current_post_id)s
            //   GROUP BY forum_post.id
            //   ORDER BY similarity DESC,
            //            forum_post.last_activity_date DESC
            //      LIMIT %(limit)s
            // """, current_post_id=self.id, tag_ids=self.tag_ids.ids, limit=limit))
            // 
            // result = self.env.cr.dictfetchall()
            // return self.browse([r["id"] for r in result])
            */
            return default;
        }

        public async Task<TEntity> GetSaleableTrackingTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _get_saleable_tracking_types(self):
            // """Return list of salealbe service_tracking types.
            // 
            // :rtype: list
            // """
            // return ['no']
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _get_saleable_tracking_types(self):
            // return super()._get_saleable_tracking_types() + [
            //     'task_global_project',
            //     'task_in_project',
            //     'project_only',
            // ]
            */
            return default;
        }

        public async Task<TEntity> GetSalesPricesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_sales_prices(self, website):
            // if not self:
            //     return {}
            // 
            // pricelist = website.pricelist_id
            // currency = website.currency_id
            // fiscal_position = website.fiscal_position_id.sudo()
            // date = fields.Date.context_today(self)
            // 
            // pricelist_prices = pricelist._compute_price_rule(self, 1.0)
            // comparison_prices_enabled = self.env.user.has_group('website_sale.group_product_price_comparison')
            // 
            // res = {}
            // for template in self:
            //     pricelist_price, pricelist_rule_id = pricelist_prices[template.id]
            // 
            //     product_taxes = template.sudo().taxes_id._filter_taxes_by_company(self.env.company)
            //     taxes = fiscal_position.map_tax(product_taxes)
            // 
            //     base_price = None
            //     template_price_vals = {
            //         'price_reduce': self._apply_taxes_to_price(
            //             pricelist_price, currency, product_taxes, taxes, template, website=website,
            //         ),
            //     }
            //     pricelist_item = template.env['product.pricelist.item'].browse(pricelist_rule_id)
            //     if pricelist_item._show_discount_on_shop():
            //         pricelist_base_price = pricelist_item._compute_price_before_discount(
            //             product=template,
            //             quantity=1.0,
            //             date=date,
            //             uom=template.uom_id,
            //             currency=currency,
            //         )
            //         if currency.compare_amounts(pricelist_base_price, pricelist_price) == 1:
            //             base_price = pricelist_base_price
            //             template_price_vals['base_price'] = self._apply_taxes_to_price(
            //                 base_price, currency, product_taxes, taxes, template, website=website,
            //             )
            // 
            //     if not base_price and comparison_prices_enabled and template.compare_list_price:
            //         template_price_vals['base_price'] = template.currency_id._convert(
            //             template.compare_list_price,
            //             currency,
            //             self.env.company,
            //             date,
            //             round=False,
            //         )
            // 
            //     res[template.id] = template_price_vals
            // 
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetServiceToGeneralInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service_policy) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _get_service_to_general(self, service_policy):
            // return self._get_service_to_general_map().get(service_policy, (False, False))
            */
            return default;
        }

        public async Task<TEntity> GetServiceToGeneralMapInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _get_service_to_general_map(self):
            // return {
            //     # service_policy: (invoice_policy, service_type)
            //     'ordered_prepaid': ('order', 'manual'),
            //     'delivered_milestones': ('delivery', 'milestones'),
            //     'delivered_manual': ('delivery', 'manual'),
            // }
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def _get_service_to_general_map(self):
            // return {
            //     **super()._get_service_to_general_map(),
            //     'delivered_timesheet': ('delivery', 'timesheet'),
            //     'ordered_prepaid': ('order', 'timesheet'),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetSingleProductVariantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def get_single_product_variant(self):
            // """ Method used by the product configurator to check if the product is configurable or not.
            // 
            // We need to open the product configurator if the product:
            // - is configurable (see has_configurable_attributes)
            // - has optional products """
            // res = super().get_single_product_variant()
            // if res.get('product_id', False):
            //     has_optional_products = False
            //     for optional_product in self.product_variant_id.optional_product_ids:
            //         if optional_product.has_dynamic_attributes() or optional_product._get_possible_variants(
            //             self.product_variant_id.product_template_attribute_value_ids
            //         ):
            //             has_optional_products = True
            //             break
            //     res.update({
            //         'has_optional_products': has_optional_products,
            //         'is_combo': self.type == 'combo',
            //     })
            // if self.sale_line_warn != 'no-message':
            //     res['sale_warning'] = {
            //         'type': self.sale_line_warn,
            //         'title': _("Warning for %s", self.name),
            //         'message': self.sale_line_warn_msg,
            //     }
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale_product_matrix, FILE: product_template.py) ---
            // def get_single_product_variant(self):
            // res = super().get_single_product_variant()
            // if self.has_configurable_attributes:
            //     res['mode'] = self.product_add_mode
            // else:
            //     res['mode'] = 'configurator'
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetStructuredDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object post_type) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _get_structured_data(self, post_type="answer"):
            // """
            // Generate structured data (microdata) for an answer or a question.
            // 
            // Returns:
            //     dict: microdata.
            // """
            // res = {
            //     "upvoteCount": self.vote_count,
            //     "datePublished": self.create_date.isoformat() + 'Z',
            //     "url": self.env['ir.http']._url_for(self.website_url),
            //     "author": {
            //         "@type": "Person",
            //         "name": self.create_uid.sudo().name,
            //     },
            // }
            // if post_type == "answer":
            //     res["@type"] = "Answer"
            //     res["text"] = self.plain_content
            // else:
            //     res["@type"] = "Question"
            //     res["name"] = self.name
            //     res["text"] = self.plain_content or self.name
            //     res["answerCount"] = self.child_count
            // if self.create_uid.sudo().website_published:
            //     res["author"]["url"] = self.env['ir.http']._url_for(f"/forum/user/{ self.create_uid.sudo().id }")
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetSuitableImageSizeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object columns, object x_size, object y_size) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_suitable_image_size(self, columns, x_size, y_size):
            // if x_size == 1 and y_size == 1 and columns >= 3:
            //     return 'image_512'
            // return 'image_1024'
            */
            return default;
        }

        public async Task<TEntity> GetTagsFirstCharInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tags) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetTemplateMatrixInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product_matrix, FILE: product_template.py) ---
            // def _get_template_matrix(self, **kwargs):
            // self.ensure_one()
            // company_id = kwargs.get('company_id', None) or self.company_id or self.env.company
            // currency_id = kwargs.get('currency_id', None) or self.currency_id
            // display_extra = kwargs.get('display_extra_price', False)
            // attribute_lines = self.valid_product_template_attribute_line_ids
            // 
            // Attrib = self.env['product.template.attribute.value']
            // first_line_attributes = attribute_lines[0].product_template_value_ids._only_active()
            // attribute_ids_by_line = [line.product_template_value_ids._only_active().ids for line in attribute_lines]
            // 
            // header = [{"name": self.display_name}] + [
            //     attr._grid_header_cell(
            //         fro_currency=self.currency_id,
            //         to_currency=currency_id,
            //         company=company_id,
            //         display_extra=display_extra
            //     ) for attr in first_line_attributes]
            // 
            // result = [[]]
            // for pool in attribute_ids_by_line:
            //     result = [x + [y] for y in pool for x in result]
            // args = [iter(result)] * len(first_line_attributes)
            // rows = itertools.zip_longest(*args)
            // 
            // matrix = []
            // for row in rows:
            //     row_attributes = Attrib.browse(row[0][1:])
            //     row_header_cell = row_attributes._grid_header_cell(
            //         fro_currency=self.currency_id,
            //         to_currency=currency_id,
            //         company=company_id,
            //         display_extra=display_extra)
            //     result = [row_header_cell]
            // 
            //     for cell in row:
            //         combination = Attrib.browse(cell)
            //         is_possible_combination = self._is_combination_possible(combination)
            //         cell.sort()
            //         result.append({
            //             "ptav_ids": cell,
            //             "qty": 0,
            //             "is_possible_combination": is_possible_combination
            //         })
            //     matrix.append(result)
            // 
            // return {
            //     "header": header,
            //     "matrix": matrix,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetTicketsAccessHashInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> registration_ids) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetVariantForCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetVariantIdForCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object filtered_combination) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetVolumeUomIdFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetVolumeUomNameFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_volume_uom_name_from_ir_config_parameter(self):
            // return self._get_volume_uom_id_from_ir_config_parameter().display_name
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteAccessoryProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_website_accessory_product(self):
            // domain = self.env['website'].sale_product_domain()
            // if not self.env.user._is_internal():
            //     domain = expression.AND([domain, [('is_published', '=', True)]])
            // return self.accessory_product_ids.filtered_domain(domain)
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteAlternativeProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _get_website_alternative_product(self):
            // domain = self.env['website'].sale_product_domain()
            // return self.alternative_product_ids.filtered_domain(domain)
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteMenuEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetWebsiteMetaAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def get_website_meta(self):
            // self.ensure_one()
            // return self.view_id.get_website_meta()
            */
            return default;
        }

        public async Task<TEntity> GetWeightUomIdFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GetWeightUomNameFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _get_weight_uom_name_from_ir_config_parameter(self):
            // return self._get_weight_uom_id_from_ir_config_parameter().display_name
            */
            return default;
        }

        public async Task<TEntity> GoToWebsiteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def go_to_website(self):
            // self.ensure_one()
            // website_url = self._compute_website_url()
            // if not website_url:
            //     return False
            // return self.env['website'].get_client_action(self._compute_website_url())
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def go_to_website(self):
            // self.ensure_one()
            // if not self.website_url:
            //     return False
            // return self.env['website'].get_client_action(self.website_url)
            */
            return default;
        }

        public async Task<TEntity> GoogleMapLinkAsync<TEntity>(IEnumerable<TEntity> entities, object zoom) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def google_map_link(self, zoom=8):
            // """ Temporary method for stable """
            // return self._google_map_link(zoom=zoom)
            */
            return default;
        }

        public async Task<TEntity> GoogleMapLinkInternalAsync<TEntity>(IEnumerable<TEntity> entities, object zoom) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> GrantAccessAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> HasDynamicAttributesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> HasIsCustomValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _has_is_custom_values(self):
            // self.ensure_one()
            // """Return whether this `product.template` has at least one is_custom
            // attribute value.
            // 
            // :return: True if at least one is_custom attribute value, False otherwise
            // :rtype: bool
            // """
            // return any(v.is_custom for v in self.valid_product_template_attribute_line_ids.product_template_value_ids._only_active())
            */
            return default;
        }

        public async Task<TEntity> HasNoVariantAttributesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _has_no_variant_attributes(self):
            // """Return whether this `product.template` has at least one no_variant
            // attribute.
            // 
            // :return: True if at least one no_variant attribute, False otherwise
            // :rtype: bool
            // """
            // self.ensure_one()
            // return any(a.create_variant == 'no_variant' for a in self.valid_product_template_attribute_line_ids.attribute_id)
            */
            return default;
        }

        public async Task<TEntity> InitColumnInternalAsync<TEntity>(IEnumerable<TEntity> entities, object column_name) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _init_column(self, column_name):
            // # to avoid generating a single default website_sequence when installing the module,
            // # we need to set the default row by row for this column
            // if column_name == "website_sequence":
            //     _logger.debug("Table '%s': setting default value of new column %s to unique values for each row", self._table, column_name)
            //     self.env.cr.execute("SELECT id FROM %s WHERE website_sequence IS NULL" % self._table)
            //     prod_tmpl_ids = self.env.cr.dictfetchall()
            //     max_seq = self._default_website_sequence()
            //     query = """
            //         UPDATE {table}
            //         SET website_sequence = p.web_seq
            //         FROM (VALUES %s) AS p(p_id, web_seq)
            //         WHERE id = p.p_id
            //     """.format(table=self._table)
            //     values_args = [(prod_tmpl['id'], max_seq + i * 5) for i, prod_tmpl in enumerate(prod_tmpl_ids)]
            //     self.env.cr.execute_values(query, values_args)
            // else:
            //     super()._init_column(column_name)
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

        public async Task<TEntity> InverseGelatoProductUidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py) ---
            // def _inverse_gelato_product_uid(self):
            // self._set_product_variant_field('gelato_product_uid')
            */
            return default;
        }

        public async Task<TEntity> InverseIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _inverse_is_favorite(self):
            // unfavorited_jobs = favorited_jobs = self.env['hr.job']
            // for job in self:
            //     if self.env.user in job.favorite_user_ids:
            //         unfavorited_jobs |= job
            //     else:
            //         favorited_jobs |= job
            // favorited_jobs.write({'favorite_user_ids': [(4, self.env.uid)]})
            // unfavorited_jobs.write({'favorite_user_ids': [(3, self.env.uid)]})
            */
            return default;
        }

        public async Task<TEntity> InverseNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_controller_page.py) ---
            // def _inverse_name(self):
            // for rec in self:
            //     if rec.view_id:
            //         rec.view_id.name = rec.name
            */
            return default;
        }

        public async Task<TEntity> InverseNameSlugifiedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_controller_page.py) ---
            // def _inverse_name_slugified(self):
            // for rec in self:
            //     rec.name_slugified = self.env['ir.http']._slugify(rec.name_slugified)
            */
            return default;
        }

        public async Task<TEntity> InverseServicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _inverse_service_policy(self):
            // for product in self:
            //     if product.service_policy:
            //         product.invoice_policy, product.service_type = self._get_service_to_general(product.service_policy)
            */
            return default;
        }

        public async Task<TEntity> InviteContactsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> IsAddToCartPossibleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _is_add_to_cart_possible(self, parent_combination=None):
            // """
            // It's possible to add to cart (potentially after configuration) if
            // there is at least one possible combination.
            // 
            // :param parent_combination: the combination from which `self` is an
            //     optional or accessory product.
            // :type parent_combination: recordset `product.template.attribute.value`
            // 
            // :return: True if it's possible to add to cart, else False
            // :rtype: bool
            // """
            // self.ensure_one()
            // if not self.active or not self._can_be_added_to_cart():
            //     # for performance: avoid calling `_get_possible_combinations`
            //     return False
            // return next(self._get_possible_combinations(parent_combination), False) is not False
            */
            return default;
        }

        public async Task<TEntity> IsCombinationPossibleByConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, object ignore_no_variant) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> IsCombinationPossibleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, object parent_combination, object ignore_no_variant) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> IsInWishlistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_wishlist, FILE: product_wishlist.py) ---
            // def _is_in_wishlist(self):
            // self.ensure_one()
            // return self in self.env['product.wishlist'].current().mapped('product_id.product_tmpl_id')
            */
            return default;
        }

        public async Task<TEntity> IsSoldOutInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock, FILE: product_template.py) ---
            // def _is_sold_out(self):
            // return self.is_storable and self.product_variant_id._is_sold_out()
            */
            return default;
        }

        public async Task<TEntity> LangGetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _lang_get(self):
            // return self.env['res.lang'].get_installed()
            */
            return default;
        }

        public async Task<TEntity> LikeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py) ---
            // def action_like(self):
            // self.check_access('read')
            // return self._action_vote(upvote=True)
            */
            return default;
        }

        public async Task<TEntity> LoadPosDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: event_event.py) ---
            // def _load_pos_data_domain(self, data):
            // return [('event_ticket_ids', 'in', [ticket['id'] for ticket in data['event.event.ticket']['data']])]
            */
            return default;
        }

        public async Task<TEntity> LoadPosDataFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid config_id) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: event_event.py) ---
            // def _load_pos_data_fields(self, config_id):
            // return ['id', 'name', 'seats_available', 'event_ticket_ids', 'registration_ids', 'seats_limited', 'write_date',
            //         'question_ids', 'general_question_ids', 'specific_question_ids', 'badge_format']
            */
            return default;
        }

        public async Task<TEntity> MailAttendeesAsync<TEntity>(IEnumerable<TEntity> entities, Guid template_id, object force_send, object filter_func) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> MailGetPartnerFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> MarkAsOffensiveBatchAsync<TEntity>(IEnumerable<TEntity> entities, object key, object values) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def mark_as_offensive_batch(self, key, values):
            // spams = self.browse()
            // if key == 'create_uid':
            //     spams = self.filtered(lambda x: x.create_uid.id in values)
            // elif key == 'country_id':
            //     spams = self.filtered(lambda x: x.create_uid.country_id.id in values)
            // elif key == 'post_id':
            //     spams = self.filtered(lambda x: x.id in values)
            // 
            // reason_id = self.env.ref('website_forum.reason_8').id
            // _logger.info('User %s marked as spams (in batch): %s' % (self.env.uid, spams))
            // return spams._mark_as_offensive(reason_id)
            */
            return default;
        }

        public async Task<TEntity> MarkAsOffensiveInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid reason_id) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _mark_as_offensive(self, reason_id):
            // for post in self:
            //     if not post.can_moderate:
            //         raise AccessError(_('%d karma required to mark a post as offensive.', post.forum_id.karma_moderate))
            //     # remove some karma
            //     _logger.info('Downvoting user <%s> for posting spam/offensive contents', post.create_uid)
            //     post.create_uid.sudo()._add_karma(post.forum_id.karma_gen_answer_flagged, post, _('Downvote for posting offensive contents'))
            //     # TODO: potential bottleneck, could be done in batch
            //     post.write({
            //         'state': 'offensive',
            //         'moderator_id': self.env.user.id,
            //         'closed_date': fields.Datetime.now(),
            //         'closed_reason_id': reason_id,
            //         'active': False,
            //     })
            // return True
            */
            return default;
        }

        public async Task<TEntity> MarkCompletedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> MarkUncompletedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> MassMailingAttendeesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> MassMailingTrackSpeakersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> MessagePostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def message_post(self, *, message_type='notification', **kwargs):
            // if self.ids and message_type == 'comment':  # user comments have a restriction on karma
            //     # add followers of comments on the parent post
            //     if self.parent_id:
            //         partner_ids = kwargs.get('partner_ids', [])
            //         comment_subtype = self.sudo().env.ref('mail.mt_comment')
            //         question_followers = self.env['mail.followers'].sudo().search([
            //             ('res_model', '=', self._name),
            //             ('res_id', '=', self.parent_id.id),
            //             ('partner_id', '!=', False),
            //         ]).filtered(lambda fol: comment_subtype in fol.subtype_ids).mapped('partner_id')
            //         partner_ids += question_followers.ids
            //         kwargs['partner_ids'] = partner_ids
            // 
            //     self.ensure_one()
            //     if not self.can_comment:
            //         raise AccessError(_('%d karma required to comment.', self.karma_comment))
            //     if not kwargs.get('record_name') and self.parent_id:
            //         kwargs['record_name'] = self.parent_id.name
            // return super(Post, self).message_post(message_type=message_type, **kwargs)
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

        public async Task<TEntity> MoveCategorySlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object category, object new_category) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> NameSearchAsync<TEntity>(IEnumerable<TEntity> entities, object name, object args, object @operator, object limit) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> NewSurveyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment_survey, FILE: hr_job.py) ---
            // def action_new_survey(self):
            // self.ensure_one()
            // survey = self.env['survey.survey'].create({
            //     'title': _("Interview Form: %s", self.name),
            // })
            // self.write({'survey_id': survey.id})
            // 
            // action = {
            //         'name': _('Survey'),
            //         'view_mode': 'form,list',
            //         'res_model': 'survey.survey',
            //         'type': 'ir.actions.act_window',
            //         'res_id': survey.id,
            //     }
            // 
            // return action
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=None):
            // """ Add access button to everyone if the document is active. """
            // groups = super()._notify_get_recipients_groups(
            //     message, model_description, msg_vals=msg_vals
            // )
            // if not self:
            //     return groups
            // 
            // self.ensure_one()
            // if self.state == 'active':
            //     for _group_name, _group_method, group_data in groups:
            //         group_data['has_button_access'] = True
            // 
            // return groups
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

        public async Task<TEntity> NotifyStateUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _notify_state_update(self):
            // for post in self:
            //     tag_partners = post.tag_ids.sudo().mapped('message_partner_ids')
            // 
            //     if post.state == 'active' and post.parent_id:
            //         post.parent_id.message_post_with_source(
            //             'website_forum.forum_post_template_new_answer',
            //             subject=_('Re: %s', post.parent_id.name),
            //             partner_ids=tag_partners.ids,
            //             subtype_xmlid='website_forum.mt_answer_new',
            //         )
            //     elif post.state == 'active' and not post.parent_id:
            //         post.message_post_with_source(
            //             'website_forum.forum_post_template_new_question',
            //             subject=post.name,
            //             partner_ids=tag_partners.ids,
            //             subtype_xmlid='website_forum.mt_question_new',
            //         )
            //     elif post.state == 'pending' and not post.parent_id:
            //         # TDE FIXME: in master, you should probably use a subtype;
            //         # however here we remove subtype but set partner_ids
            //         partners = post.sudo().message_partner_ids | tag_partners
            //         partners = partners.filtered(lambda partner: partner.user_ids and any(user.karma >= post.forum_id.karma_moderate for user in partner.user_ids))
            // 
            //         post.message_post_with_source(
            //             'website_forum.forum_post_template_validation',
            //             subject=post.name,
            //             partner_ids=partners.ids,
            //             subtype_xmlid='mail.mt_note',
            //         )
            // return True
            */
            return default;
        }

        public async Task<TEntity> NotifyThreadByInboxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object recipients_data, object msg_vals) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _notify_thread_by_inbox(self, message, recipients_data, msg_vals=False, **kwargs):
            // """ Override to avoid keeping all notified recipients of a comment.
            // We avoid tracking needaction on post comments. Only emails should be
            // sufficient. """
            // if msg_vals is None:
            //     msg_vals = {}
            // if msg_vals.get('message_type', message.message_type) == 'comment':
            //     return
            // return super(Post, self)._notify_thread_by_inbox(message, recipients_data, msg_vals=msg_vals, **kwargs)
            */
            return default;
        }

        public async Task<TEntity> OnChangeAvailableInPosInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py) ---
            // def _on_change_available_in_pos(self):
            // for record in self:
            //     if not record.available_in_pos:
            //         record.self_order_available = False
            */
            return default;
        }

        public async Task<TEntity> OnChangeDocumentBinaryContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> OnChangeSlideCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> OnChangeUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> OnchangeAvailableInPosInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product.py) ---
            // def _onchange_available_in_pos(self):
            // if self.available_in_pos and not self.sale_ok:
            //     self.sale_ok = True
            */
            return default;
        }

        public async Task<TEntity> OnchangeDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> OnchangeSaleOkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product.py) ---
            // def _onchange_sale_ok(self):
            // if not self.sale_ok:
            //     self.available_in_pos = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeServiceFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def _onchange_service_fields(self):
            // for record in self:
            //     default_uom_id = self.env['ir.default']._get_model_defaults('product.template').get('uom_id')
            //     default_uom = self.env['uom.uom'].browse(default_uom_id)
            //     if record.type == 'service' and record.service_type == 'timesheet' and \
            //        not (record._origin.service_policy and record.service_policy == record._origin.service_policy):
            //         if default_uom and default_uom.category_id == self.env.ref('uom.uom_categ_wtime'):
            //             record.uom_id = default_uom
            //         else:
            //             record.uom_id = self.env.ref('uom.product_uom_hour')
            //     elif record._origin.uom_id:
            //         record.uom_id = record._origin.uom_id
            //     elif default_uom:
            //         record.uom_id = default_uom
            //     else:
            //         record.uom_id = self.default_get(['uom_id']).get('uom_id')
            //     record.uom_po_id = record.uom_id
            */
            return default;
        }

        public async Task<TEntity> OnchangeServicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def _onchange_service_policy(self):
            // self._inverse_service_policy()
            // vals = self._get_onchange_service_policy_updates(self.service_tracking,
            //                                                 self.service_policy,
            //                                                 self.project_id,
            //                                                 self.project_template_id)
            // if vals:
            //     self.update(vals)
            */
            return default;
        }

        public async Task<TEntity> OnchangeServiceToPurchaseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_purchase, FILE: product_template.py) ---
            // def _onchange_service_to_purchase(self):
            // products_template = self.filtered(lambda p: p.type != 'service' or p.expense_policy != 'no')
            // products_template.service_to_purchase = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeServiceTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _onchange_service_tracking(self):
            // if self.service_tracking == 'no':
            //     self.project_id = False
            //     self.project_template_id = False
            // elif self.service_tracking == 'task_global_project':
            //     self.project_template_id = False
            // elif self.service_tracking in ['task_in_project', 'project_only']:
            //     self.project_id = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: product.py) ---
            // def _onchange_standard_price(self):
            //         if self.lot_valuated and any(p.quantity_svl for p in self.product_variant_ids):
            //             return {
            //                 'warning': {
            //                     'title': _("Warning"),
            //                     'message': _("This product is valuated by lot/serial number. Changing the cost \
            // will update the cost of every lot/serial number in stock."),
            //                 }
            //             }
            */
            return default;
        }

        public async Task<TEntity> OnchangeTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _onchange_tracking(self):
            // return self.mapped('product_variant_ids')._onchange_tracking()
            */
            return default;
        }

        public async Task<TEntity> OnchangeTypeEventBoothInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth_sale, FILE: product_template.py) ---
            // def _onchange_type_event_booth(self):
            // if self.service_tracking == 'event_booth':
            //     self.invoice_policy = 'order'
            */
            return default;
        }

        public async Task<TEntity> OnchangeTypeEventInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: product_template.py) ---
            // def _onchange_type_event(self):
            // if self.service_tracking == 'event':
            //     self.invoice_policy = 'order'
            */
            return default;
        }

        public async Task<TEntity> OnchangeTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: product.py) ---
            // def _onchange_type(self):
            // if self.type == 'combo':
            //     self.taxes_id = False
            //     self.supplier_taxes_id = False
            // return super()._onchange_type()
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
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _onchange_type(self):
            // res = super()._onchange_type()
            // if self._origin and self.sales_count > 0:
            //     res['warning'] = {
            //         'title': _("Warning"),
            //         'message': _("You cannot change the product's type because it is already used in sales orders.")
            //     }
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _onchange_type(self):
            // # Return a warning when trying to change the product type
            // res = super()._onchange_type()
            // if self.ids and self.product_variant_ids.ids and self.env['stock.move.line'].sudo().search_count([
            //     ('product_id', 'in', self.product_variant_ids.ids), ('state', '!=', 'cancel')
            // ]):
            //     res['warning'] = {
            //         'title': _('Warning!'),
            //         'message': _(
            //             'This product has been used in at least one inventory movement. '
            //             'It is not advised to change the Product Type since it can lead to inconsistencies. '
            //             'A better solution could be to archive the product and create a new one instead.'
            //         )
            //     }
            // return res
            */
            return default;
        }

        public async Task<TEntity> OnchangeUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _onchange_uom_id(self):
            // if self.uom_id:
            //     self.uom_po_id = self.uom_id.id
            */
            return default;
        }

        public async Task<TEntity> OnchangeWebsitePublishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def _onchange_website_published(self):
            // if self.website_published:
            //     self.is_published = True
            // else:
            //     self.is_published = False
            */
            return default;
        }

        public async Task<TEntity> OpenActivitiesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def action_open_activities(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("hr_recruitment.action_hr_job_applications")
            // views = ['activity'] + [view for view in action['view_mode'].split(',') if view != 'activity']
            // action['view_mode'] = ','.join(views)
            // action['views'] = [(False, view) for view in views]
            // return action
            */
            return default;
        }

        public async Task<TEntity> OpenAttachmentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def action_open_attachments(self):
            // return {
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'ir.attachment',
            //     'name': _('Documents'),
            //     'context': {
            //         'default_res_model': self._name,
            //         'default_res_id': self.ids[0],
            //         'show_partner_name': 1,
            //     },
            //     'view_mode': 'list',
            //     'views': [
            //         (self.env.ref('hr_recruitment.ir_attachment_hr_recruitment_list_view').id, 'list')
            //     ],
            //     'search_view_id': self.env.ref('hr_recruitment.ir_attachment_view_search_inherit_hr_recruitment').ids,
            //     'domain': ['|',
            //         '&', ('res_model', '=', 'hr.job'), ('res_id', 'in', self.ids),
            //         '&', ('res_model', '=', 'hr.applicant'), ('res_id', 'in', self.application_ids.ids),
            //     ],
            // }
            */
            return default;
        }

        public async Task<TEntity> OpenDocumentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> OpenLabelLayoutAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> OpenLateActivitiesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def action_open_late_activities(self):
            // action = self.action_open_activities()
            // action['context'] = {
            //     'default_job_id': self.id,
            //     'search_default_job_id': self.id,
            //     'search_default_activities_overdue': True,
            //     'search_default_running_applicant_activities': True,
            // }
            // return action
            */
            return default;
        }

        public async Task<TEntity> OpenPricelistRulesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> OpenProductLotAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_open_product_lot(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("stock.action_product_production_lot_form")
            // action['domain'] = [
            //     ('product_id.product_tmpl_id', '=', self.id),
            //     '|', ('location_id', '=', False),
            //          ('location_id', 'any', self.env['stock.location']._check_company_domain(self._context['allowed_company_ids']))
            // ]
            // action['context'] = {
            //     'default_product_tmpl_id': self.id,
            //     'search_default_group_by_location': True,
            // }
            // if self.product_variant_count == 1:
            //     action['context'].update({
            //         'default_product_id': self.product_variant_id.id,
            //     })
            // return action
            */
            return default;
        }

        public async Task<TEntity> OpenQuantsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_open_quants(self):
            // if 'product_variant' in self.env.context:
            //     return self.env['product.product'].browse(self.env.context['default_product_id']).action_open_quants()
            // return self.product_variant_ids.filtered(lambda p: p.active or p.qty_available != 0).action_open_quants()
            */
            return default;
        }

        public async Task<TEntity> OpenRoutesDiagramAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_open_routes_diagram(self):
            // products = False
            // if self.env.context.get('default_product_id'):
            //     products = self.env['product.product'].browse(self.env.context['default_product_id'])
            // if not products and self.env.context.get('default_product_tmpl_id'):
            //     products = self.env['product.template'].browse(self.env.context['default_product_tmpl_id']).product_variant_ids
            // if not self.env.user.has_group('stock.group_stock_multi_warehouses') and len(products) == 1:
            //     company = products.company_id or self.env.company
            //     warehouse = self.env['stock.warehouse'].search([('company_id', '=', company.id)], limit=1)
            //     return self.env.ref('stock.action_report_stock_rule').report_action(None, data={
            //         'product_id': products.id,
            //         'warehouse_ids': warehouse.ids,
            //     }, config=False)
            // action = self.env["ir.actions.actions"]._for_xml_id("stock.action_stock_rules_report")
            // action['context'] = self.env.context
            // return action
            */
            return default;
        }

        public async Task<TEntity> OpenTodayActivitiesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def action_open_today_activities(self):
            // action = self.action_open_activities()
            // action['context'] = {
            //     'default_job_id': self.id,
            //     'search_default_job_id': self.id,
            //     'search_default_activities_today': True,
            // }
            // return action
            */
            return default;
        }

        public async Task<TEntity> OpenWebsiteUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: test_website, FILE: model.py) ---
            // def open_website_url(self):
            // self.ensure_one()
            // return self.env['website'].get_client_action(f'/test_model/{self.id}')
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_controller_page.py) ---
            // def open_website_url(self):
            // url = f"/model/{self.name_slugified}"
            // return {
            //     "type": "ir.actions.act_url",
            //     "url": url
            // }
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

        public async Task<TEntity> OrderFieldToSqlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @alias, object field_name, object direction, object nulls, object query) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _order_field_to_sql(self, alias, field_name, direction, nulls, query):
            // if field_name == 'is_favorite':
            //     sql_field = SQL(
            //         "%s IN (SELECT job_id FROM job_favorite_user_rel WHERE user_id = %s)",
            //         SQL.identifier(alias, 'id'), self.env.uid,
            //     )
            //     return SQL("%s %s %s", sql_field, direction, nulls)
            // 
            // return super()._order_field_to_sql(alias, field_name, direction, nulls, query)
            */
            return default;
        }

        public async Task<TEntity> PageDebugViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def action_page_debug_view(self):
            // return {
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'ir.ui.view',
            //     'res_id': self.view_id.id,
            //     'view_mode': 'form',
            //     'view_id': self.env.ref('website.view_view_form_extend').id,
            // }
            */
            return default;
        }

        public async Task<TEntity> PostPublicationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> PrepareInvoicingTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _prepare_invoicing_tooltip(self):
            // if self.invoice_policy == 'delivery':
            //     return _("Invoice after delivery, based on quantities delivered, not ordered.")
            // elif self.invoice_policy == 'order':
            //     if self.type == 'consu':
            //         return _("You can invoice goods before they are delivered.")
            //     elif self.type == 'service':
            //         return _("Invoice ordered quantities as soon as this service is sold.")
            // return ""
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _prepare_invoicing_tooltip(self):
            // if self.service_policy == 'delivered_milestones':
            //     return _("Invoice your milestones when they are reached.")
            // # ordered_prepaid and delivered_manual are handled in the super call, according to the
            // # corresponding value in the `invoice_policy` field (delivered/ordered quantities)
            // return super()._prepare_invoicing_tooltip()
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def _prepare_invoicing_tooltip(self):
            // if self.service_policy == 'delivered_timesheet':
            //     return _("Invoice based on timesheets (delivered quantity).")
            // return super()._prepare_invoicing_tooltip()
            */
            return default;
        }

        public async Task<TEntity> PrepareServiceTrackingTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth_sale, FILE: product_template.py) ---
            // def _prepare_service_tracking_tooltip(self):
            // if self.service_tracking == 'event_booth':
            //     return _("Mark the selected Booth as Unavailable.")
            // return super()._prepare_service_tracking_tooltip()
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: product_template.py) ---
            // def _prepare_service_tracking_tooltip(self):
            // if self.service_tracking == 'event':
            //     return _("Create an Attendee for the selected Event.")
            // return super()._prepare_service_tracking_tooltip()
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _prepare_service_tracking_tooltip(self):
            // return ""
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _prepare_service_tracking_tooltip(self):
            // if self.service_tracking == 'task_global_project':
            //     return _("Create a task in an existing project to track the time spent.")
            // elif self.service_tracking == 'project_only':
            //     return _(
            //         "Create an empty project for the order to track the time spent."
            //     )
            // elif self.service_tracking == 'task_in_project':
            //     return _(
            //         "Create a project for the order with a task for each sales order line "
            //         "to track the time spent."
            //     )
            // elif self.service_tracking == 'no':
            //     return _(
            //         "Create projects or tasks later, and link them to order to track the time spent."
            //     )
            // return super()._prepare_service_tracking_tooltip()
            --- ODOO METHOD SOURCE (MODULE: website_sale_slides, FILE: product_template.py) ---
            // def _prepare_service_tracking_tooltip(self):
            // if self.service_tracking == 'course':
            //     return _("Grant access to the eLearning course linked to this product.")
            // return super()._prepare_service_tracking_tooltip()
            */
            return default;
        }

        public async Task<TEntity> PrepareTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def _prepare_tooltip(self):
            // tooltip = super()._prepare_tooltip()
            // if not self.sale_ok:
            //     return tooltip
            // 
            // invoicing_tooltip = self._prepare_invoicing_tooltip()
            // 
            // tooltip = f'{tooltip} {invoicing_tooltip}' if tooltip else invoicing_tooltip
            // 
            // if self.type == 'service':
            //     additional_tooltip = self._prepare_service_tracking_tooltip()
            //     tooltip = f'{tooltip} {additional_tooltip}' if additional_tooltip else tooltip
            // 
            // return tooltip
            */
            return default;
        }

        public async Task<TEntity> PrepareVariantValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _prepare_variant_values(self, combination):
            // variant_dict = super()._prepare_variant_values(combination)
            // variant_dict['base_unit_count'] = self.base_unit_count
            // return variant_dict
            */
            return default;
        }

        public async Task<TEntity> PriceComputeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price_type, object uom, object currency, object company, object date) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ProductTmplForecastReportAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_product_tmpl_forecast_report(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id('stock.stock_forecasted_product_template_action')
            // return action
            */
            return default;
        }

        public async Task<TEntity> RatingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _rating_domain(self):
            // """ Only take the published rating into account to compute avg and count """
            // domain = super()._rating_domain()
            // return expression.AND([domain, [('is_internal', '=', False)]])
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def _rating_domain(self):
            // """ Only take the published rating into account to compute avg and count """
            // domain = super(Channel, self)._rating_domain()
            // return expression.AND([domain, [('is_internal', '=', False)]])
            */
            return default;
        }

        public async Task<TEntity> ReadGroupCategIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object categories, object domain) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> RedirectToCompletedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_redirect_to_completed_members(self):
            // return self.action_redirect_to_members('completed')
            */
            return default;
        }

        public async Task<TEntity> RedirectToEngagedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_redirect_to_engaged_members(self):
            // return self.action_redirect_to_members('engaged')
            */
            return default;
        }

        public async Task<TEntity> RedirectToInvitedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py) ---
            // def action_redirect_to_invited_members(self):
            // return self.action_redirect_to_members('invited')
            */
            return default;
        }

        public async Task<TEntity> RedirectToMembersAsync<TEntity>(IEnumerable<TEntity> entities, object status_filter) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> RefuseAccessAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> RefuseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _refuse(self):
            // for post in self:
            //     if not post.can_moderate:
            //         raise AccessError(_('%d karma required to refuse a post.', post.forum_id.karma_moderate))
            //     post.moderator_id = self.env.user
            // return True
            */
            return default;
        }

        public async Task<TEntity> RemoveMembershipInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ReopenAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def reopen(self):
            // if any(post.parent_id or post.state != 'close' for post in self):
            //     return False
            // 
            // reason_offensive = self.env.ref('website_forum.reason_7')
            // reason_spam = self.env.ref('website_forum.reason_8')
            // for post in self:
            //     if post.closed_reason_id in (reason_offensive, reason_spam):
            //         _logger.info('Upvoting user <%s>, reopening spam/offensive question',
            //                      post.create_uid)
            // 
            //         karma = post.forum_id.karma_gen_answer_flagged
            //         if post.closed_reason_id == reason_spam:
            //             # If first post, increase the karma to add
            //             count_post = post.search_count([('parent_id', '=', False), ('forum_id', '=', post.forum_id.id), ('create_uid', '=', post.create_uid.id)])
            //             if count_post == 1:
            //                 karma *= 10
            //         post.create_uid.sudo()._add_karma(karma * -1, post, _('Reopen a banned question'))
            // 
            // self.sudo().write({'state': 'active'})
            */
            return default;
        }

        public async Task<TEntity> RequestAccessAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ResequenceSlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slide, object force_category) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> SearchAddressSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> SearchBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> SearchBuildDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> SearchBuildDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain_list, object search, object fields, object extra) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: mixins.py) ---
            // def _search_build_domain(self, domain_list, search, fields, extra=None):
            // """
            // Builds a search domain AND-combining a base domain with partial matches of each term in
            // the search expression in any of the fields.
            // 
            // :param domain_list: base domain list combined in the search expression
            // :param search: search expression string
            // :param fields: list of field names to match the terms of the search expression with
            // :param extra: function that returns an additional subdomain for a search term
            // 
            // :return: domain limited to the matches of the search expression
            // """
            // domains = domain_list.copy()
            // if search:
            //     for search_term in search.split(' '):
            //         subdomains = [[(field, 'ilike', escape_psql(search_term))] for field in fields]
            //         if extra:
            //             subdomains.append(extra(self.env, search_term))
            //         domains.append(expression.OR(subdomains))
            // return expression.AND(domains)
            */
            return default;
        }

        public async Task<TEntity> SearchCanViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _search_can_view(self, operator, value):
            // if operator not in ('=', '!=', '<>'):
            //     raise ValueError('Invalid operator: %s' % (operator,))
            // 
            // if not value:
            //     operator = '!=' if operator == '=' else '='
            // 
            // user = self.env.user
            // # Won't impact sitemap, search() in converter is forced as public user
            // if self.env.is_admin():
            //     return [(1, '=', 1)]
            // 
            // sql = SQL("""(
            //     SELECT p.id
            //     FROM forum_post p
            //            LEFT JOIN res_users u ON p.create_uid = u.id
            //            LEFT JOIN forum_forum f ON p.forum_id = f.id
            //     WHERE
            //         (p.create_uid = %(user_id)s and f.karma_close_own <= %(karma)s)
            //         or (p.create_uid != %(user_id)s and f.karma_close_all <= %(karma)s)
            //         or (
            //             u.karma > 0
            //             and (p.active or p.create_uid = %(user_id)s)
            //         )
            // )""", user_id=user.id, karma=user.karma)
            // op = 'in' if operator == '=' else "not in"
            // return [('id', op, sql)]
            */
            return default;
        }

        public async Task<TEntity> SearchDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> SearchFetchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object search_detail, object search, object limit, object order) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: mixins.py) ---
            // def _search_fetch(self, search_detail, search, limit, order):
            // fields = search_detail['search_fields']
            // base_domain = search_detail['base_domain']
            // domain = self._search_build_domain(base_domain, search, fields, search_detail.get('search_extra'))
            // model = self.sudo() if search_detail.get('requires_sudo') else self
            // results = model.search(
            //     domain,
            //     limit=limit,
            //     order=search_detail.get('order', order)
            // )
            // count = model.search_count(domain)
            // return results, count
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _search_fetch(self, search_detail, search, limit, order):
            // with_description = 'description' in search_detail['mapping']
            // # Cannot rely on the super's _search_fetch because the search must be
            // # performed among the most specific pages only.
            // fields = search_detail['search_fields']
            // base_domain = search_detail['base_domain']
            // domain = self._search_build_domain(base_domain, search, fields, search_detail.get('search_extra'))
            // most_specific_pages = self.env['website']._get_website_pages(
            //     domain=expression.AND(base_domain), order=order
            // )
            // results = most_specific_pages.filtered_domain(domain)  # already sudo
            // v_arch_db = self.env['ir.ui.view']._field_to_sql('v', 'arch_db')
            // 
            // if with_description and search and most_specific_pages:
            //     # Perform search in translations
            //     # TODO Remove when domains will support xml_translate fields
            //     self.env.cr.execute(SQL(
            //         """
            //         SELECT DISTINCT %(table)s.id
            //         FROM %(table)s
            //         LEFT JOIN ir_ui_view v ON %(table)s.view_id = v.id
            //         WHERE (v.name ILIKE %(search)s
            //         OR %(v_arch_db)s ILIKE %(search)s)
            //         AND %(table)s.id IN %(ids)s
            //         LIMIT %(limit)s
            //         """,
            //         table=SQL.identifier(self._table),
            //         search=f"%{escape_psql(search)}%",
            //         v_arch_db=v_arch_db,
            //         ids=tuple(most_specific_pages.ids),
            //         limit=len(most_specific_pages.ids),
            //     ))
            //     ids = {row[0] for row in self.env.cr.fetchall()}
            //     if ids:
            //         ids.update(results.ids)
            //         domains = search_detail['base_domain'].copy()
            //         domains.append([('id', 'in', list(ids))])
            //         domain = expression.AND(domains)
            //         model = self.sudo() if search_detail.get('requires_sudo') else self
            //         results = model.search(
            //             domain,
            //             limit=len(ids),
            //             order=search_detail.get('order', order)
            //         )
            // 
            // def filter_page(search, page, all_pages):
            //     # Search might have matched words in the xml tags and parameters therefore we make
            //     # sure the terms actually appear inside the text.
            //     text = '%s %s %s' % (page.name, page.url, text_from_html(page.arch))
            //     pattern = '|'.join([re.escape(search_term) for search_term in search.split()])
            //     return re.findall('(%s)' % pattern, text, flags=re.I) if pattern else False
            // if search and with_description:
            //     results = results.filtered(lambda result: filter_page(search, result, results))
            // return results[:limit], len(results)
            */
            return default;
        }

        public async Task<TEntity> SearchGetDetailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website, object order, object options) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: test_website, FILE: model.py) ---
            // def _search_get_detail(self, website, order, options):
            // return {
            //     'model': 'test.model',
            //     'base_domain': [],
            //     'search_fields': ['name', 'submodel_ids.name', 'submodel_ids.tag_id.name'],
            //     'fetch_fields': ['name'],
            //     'mapping': {
            //         'name': {'name': 'name', 'type': 'text', 'match': True},
            //         'website_url': {'name': 'name', 'type': 'text', 'truncate': False},
            //     },
            //     'icon': 'fa-check-square-o',
            //     'order': 'name asc, id desc',
            // }
            --- ODOO METHOD SOURCE (MODULE: website, FILE: mixins.py) ---
            // def _search_get_detail(self, website, order, options):
            // """
            // Returns indications on how to perform the searches
            // 
            // :param website: website within which the search is done
            // :param order: order in which the results are to be returned
            // :param options: search options
            // 
            // :return: search detail as expected in elements of the result of website._search_get_details()
            //     These elements contain the following fields:
            //     - model: name of the searched model
            //     - base_domain: list of domains within which to perform the search
            //     - search_fields: fields within which the search term must be found
            //     - fetch_fields: fields from which data must be fetched
            //     - mapping: mapping from the results towards the structure used in rendering templates.
            //         The mapping is a dict that associates the rendering name of each field
            //         to a dict containing the 'name' of the field in the results list and the 'type'
            //         that must be used for rendering the value
            //     - icon: name of the icon to use if there is no image
            // 
            // This method must be implemented by all models that inherit this mixin.
            // """
            // raise NotImplementedError()
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def _search_get_detail(self, website, order, options):
            // with_description = options['displayDescription']
            // # Read access on website.page requires sudo.
            // requires_sudo = True
            // domain = [website.website_domain()]
            // if not self.env.user.has_group('website.group_website_designer'):
            //     # Rule must be reinforced because of sudo.
            //     domain.append([('website_published', '=', True)])
            // 
            // search_fields = ['name', 'url']
            // fetch_fields = ['id', 'name', 'url']
            // mapping = {
            //     'name': {'name': 'name', 'type': 'text', 'match': True},
            //     'website_url': {'name': 'url', 'type': 'text', 'truncate': False},
            // }
            // if with_description:
            //     search_fields.append('arch_db')
            //     fetch_fields.append('arch')
            //     mapping['description'] = {'name': 'arch', 'type': 'text', 'html': True, 'match': True}
            // return {
            //     'model': 'website.page',
            //     'base_domain': domain,
            //     'requires_sudo': requires_sudo,
            //     'search_fields': search_fields,
            //     'fetch_fields': fetch_fields,
            //     'mapping': mapping,
            //     'icon': 'fa-file-o',
            // }
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
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _search_get_detail(self, website, order, options):
            // with_description = options['displayDescription']
            // with_date = options['displayDetail']
            // search_fields = ['name']
            // fetch_fields = ['id', 'name', 'website_url']
            // mapping = {
            //     'name': {'name': 'name', 'type': 'text', 'match': True},
            //     'website_url': {'name': 'website_url', 'type': 'text', 'truncate': False},
            // }
            // 
            // domain = website.website_domain()
            // domain = expression.AND([domain, [('state', '=', 'active'), ('can_view', '=', True)]])
            // include_answers = options.get('include_answers', False)
            // if not include_answers:
            //     domain = expression.AND([domain, [('parent_id', '=', False)]])
            // forum = options.get('forum')
            // if forum:
            //     domain = expression.AND([domain, [('forum_id', '=', self.env['ir.http']._unslug(forum)[1])]])
            // tags = options.get('tag')
            // if tags:
            //     domain = expression.AND([domain, [('tag_ids', 'in', [self.env['ir.http']._unslug(tag)[1] for tag in tags.split(',')])]])
            // filters = options.get('filters')
            // if filters == 'unanswered':
            //     domain = expression.AND([domain, [('child_ids', '=', False)]])
            // elif filters == 'solved':
            //     domain = expression.AND([domain, [('has_validated_answer', '=', True)]])
            // elif filters == 'unsolved':
            //     domain = expression.AND([domain, [('has_validated_answer', '=', False)]])
            // user = self.env.user
            // my = options.get('my')
            // create_uid = user.id if my == 'mine' else options.get('create_uid')
            // if create_uid:
            //     domain = expression.AND([domain, [('create_uid', '=', create_uid)]])
            // if my == 'followed':
            //     domain = expression.AND([domain, [('message_partner_ids', '=', user.partner_id.id)]])
            // elif my == 'tagged':
            //     domain = expression.AND([domain, [('tag_ids.message_partner_ids', '=', user.partner_id.id)]])
            // elif my == 'favourites':
            //     domain = expression.AND([domain, [('favourite_ids', '=', user.id)]])
            // elif my == 'upvoted':
            //     domain = expression.AND([domain, [('vote_ids.user_id', '=', user.id)]])
            // 
            // # 'sorting' from the form's "Order by" overrides order during auto-completion
            // order = options.get('sorting', order)
            // if 'is_published' in order:
            //     parts = [part for part in order.split(',') if 'is_published' not in part]
            //     order = ','.join(parts)
            // 
            // if with_description:
            //     search_fields.append('content')
            //     fetch_fields.append('content')
            //     mapping['description'] = {'name': 'content', 'type': 'text', 'html': True, 'match': True}
            // if with_date:
            //     fetch_fields.append('write_date')
            //     mapping['detail'] = {'name': 'date', 'type': 'html'}
            // return {
            //     'model': 'forum.post',
            //     'base_domain': [domain],
            //     'search_fields': search_fields,
            //     'fetch_fields': fetch_fields,
            //     'mapping': mapping,
            //     'icon': 'fa-comment-o',
            //     'order': order,
            // }
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_tag.py) ---
            // def _search_get_detail(self, website, order, options):
            // search_fields = ['name']
            // fetch_fields = ['id', 'name', 'website_url']
            // mapping = {
            //     'name': {'name': 'name', 'type': 'text', 'match': True},
            //     'website_url': {'name': 'website_url', 'type': 'text', 'truncate': False},
            // }
            // base_domain = []
            // if forum := options.get("forum"):
            //     forum_ids = (self.env['ir.http']._unslug(forum)[1],) if isinstance(forum, str) else forum.ids
            //     search_domain = options.get("domain")
            //     base_domain = [search_domain if search_domain is not None else [('forum_id', 'in', forum_ids)]]
            // return {
            //     'model': 'forum.tag',
            //     'base_domain': base_domain,
            //     'search_fields': search_fields,
            //     'fetch_fields': fetch_fields,
            //     'mapping': mapping,
            //     'icon': 'fa-tag',
            //     'order': ','.join(filter(lambda f: 'is_published' not in f, order.split(','))),
            // }
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def _search_get_detail(self, website, order, options):
            // requires_sudo = False
            // with_description = options['displayDescription']
            // country_id = options.get('country_id')
            // department_id = options.get('department_id')
            // office_id = options.get('office_id')
            // contract_type_id = options.get('contract_type_id')
            // is_remote = options.get('is_remote')
            // is_other_department = options.get('is_other_department')
            // is_untyped = options.get('is_untyped')
            // 
            // domain = [website.website_domain()]
            // if country_id:
            //     domain.append([('address_id.country_id', '=', int(country_id))])
            //     requires_sudo = True
            // if department_id:
            //     domain.append([('department_id', '=', int(department_id))])
            // elif is_other_department:
            //     domain.append([('department_id', '=', None)])
            // if office_id:
            //     domain.append([('address_id', '=', int(office_id))])
            // elif is_remote:
            //     domain.append([('address_id', '=', None)])
            // if contract_type_id:
            //     domain.append([('contract_type_id', '=', int(contract_type_id))])
            // elif is_untyped:
            //     domain.append([('contract_type_id', '=', None)])
            // 
            // if requires_sudo and not self.env.user.has_group('hr_recruitment.group_hr_recruitment_user'):
            //     # Rule must be reinforced because of sudo.
            //     domain.append([('website_published', '=', True)])
            // 
            // 
            // search_fields = ['name']
            // fetch_fields = ['name', 'website_url']
            // mapping = {
            //     'name': {'name': 'name', 'type': 'text', 'match': True},
            //     'website_url': {'name': 'website_url', 'type': 'text', 'truncate':  False},
            // }
            // if with_description:
            //     search_fields.append('description')
            //     fetch_fields.append('description')
            //     mapping['description'] = {'name': 'description', 'type': 'text', 'html': True, 'match': True}
            // return {
            //     'model': 'hr.job',
            //     'requires_sudo': requires_sudo,
            //     'base_domain': domain,
            //     'search_fields': search_fields,
            //     'fetch_fields': fetch_fields,
            //     'mapping': mapping,
            //     'icon': 'fa-briefcase',
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
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _search_get_detail(self, website, order, options):
            // with_image = options['displayImage']
            // with_description = options['displayDescription']
            // with_category = options['displayExtraLink']
            // with_price = options['displayDetail']
            // domains = [website.sale_product_domain()]
            // category = options.get('category')
            // tags = options.get('tags')
            // min_price = options.get('min_price')
            // max_price = options.get('max_price')
            // attrib_values = options.get('attrib_values')
            // if category:
            //     domains.append([('public_categ_ids', 'child_of', self.env['ir.http']._unslug(category)[1])])
            // if tags:
            //     if isinstance(tags, str):
            //         tags = tags.split(',')
            //     domains.append([('product_variant_ids.all_product_tag_ids', 'in', tags)])
            // if min_price:
            //     domains.append([('list_price', '>=', min_price)])
            // if max_price:
            //     domains.append([('list_price', '<=', max_price)])
            // if attrib_values:
            //     domains.extend(self._get_attrib_values_domain(attrib_values))
            // search_fields = ['name', 'default_code', 'product_variant_ids.default_code']
            // fetch_fields = ['id', 'name', 'website_url']
            // mapping = {
            //     'name': {'name': 'name', 'type': 'text', 'match': True},
            //     'default_code': {'name': 'default_code', 'type': 'text', 'match': True},
            //     'product_variant_ids.default_code': {'name': 'product_variant_ids.default_code', 'type': 'text', 'match': True},
            //     'website_url': {'name': 'website_url', 'type': 'text', 'truncate': False},
            // }
            // if with_image:
            //     mapping['image_url'] = {'name': 'image_url', 'type': 'html'}
            // if with_description:
            //     # Internal note is not part of the rendering.
            //     search_fields.append('description')
            //     fetch_fields.append('description')
            //     search_fields.append('description_sale')
            //     fetch_fields.append('description_sale')
            //     mapping['description'] = {'name': 'description_sale', 'type': 'text', 'match': True}
            // if with_price:
            //     mapping['detail'] = {'name': 'price', 'type': 'html', 'display_currency': options['display_currency']}
            //     mapping['detail_strike'] = {'name': 'list_price', 'type': 'html', 'display_currency': options['display_currency']}
            // if with_category:
            //     mapping['extra_link'] = {'name': 'category', 'type': 'html'}
            // return {
            //     'model': 'product.template',
            //     'base_domain': domains,
            //     'search_fields': search_fields,
            //     'fetch_fields': fetch_fields,
            //     'mapping': mapping,
            //     'icon': 'fa-shopping-cart',
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

        public async Task<TEntity> SearchIncomingQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _search_incoming_qty(self, operator, value):
            // domain = [('incoming_qty', operator, value)]
            // product_variant_query = self.env['product.product']._search(domain)
            // return [('product_variant_ids', 'in', product_variant_query)]
            */
            return default;
        }

        public async Task<TEntity> SearchIsFinishedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> SearchIsKitsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def _search_is_kits(self, operator, value):
            // assert operator in ('=', '!='), 'Unsupported operator'
            // bom_tmpl_query = self.env['mrp.bom'].sudo()._search(
            //     [('company_id', 'in', [False] + self.env.companies.ids),
            //      ('type', '=', 'phantom'), ('active', '=', True)])
            // neg = ''
            // if (operator == '=' and not value) or (operator == '!=' and value):
            //     neg = 'not '
            // return [('id', neg + 'in', bom_tmpl_query.subselect('product_tmpl_id'))]
            */
            return default;
        }

        public async Task<TEntity> SearchIsMemberChannelIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invited) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> SearchIsMemberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> SearchIsMemberInvitedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> SearchIsOngoingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> SearchIsParticipatingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> SearchIsVisibleOnWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> SearchMatchingCandidatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_job.py) ---
            // def action_search_matching_candidates(self):
            // self.ensure_one()
            // help_message_1 = _("No Matching Candidates")
            // help_message_2 = _("We do not have any candidates who meet the skill requirements for this job position in the database at the moment.")
            // action = self.env['ir.actions.actions']._for_xml_id('hr_recruitment.action_hr_candidate')
            // context = literal_eval(action['context'])
            // context['active_id'] = self.id
            // matching_candidates = self.env['hr.candidate'].search([('skill_ids', 'in', self.skill_ids.ids)]).filtered(lambda c: self.id not in c.applicant_ids.job_id.ids)
            // action.update({
            //     'name': _("Matching Candidates"),
            //     'views': [
            //         (self.env.ref('hr_recruitment_skills.hr_candidate_view_tree').id, 'list'),
            //         (False, 'form'),
            //     ],
            //     'context': context,
            //     'domain': [('id', 'in', matching_candidates.ids)],
            //     'help': Markup("<p class='o_view_nocontent_empty_folder'>%s</p><p>%s</p>") % (help_message_1, help_message_2),
            // })
            // return action
            */
            return default;
        }

        public async Task<TEntity> SearchOutgoingQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _search_outgoing_qty(self, operator, value):
            // domain = [('outgoing_qty', operator, value)]
            // product_variant_query = self.env['product.product']._search(domain)
            // return [('product_variant_ids', 'in', product_variant_query)]
            */
            return default;
        }

        public async Task<TEntity> SearchPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> SearchQtyAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _search_qty_available(self, operator, value):
            // domain = [('qty_available', operator, value)]
            // product_variant_query = self.env['product.product']._search(domain)
            // return [('product_variant_ids', 'in', product_variant_query)]
            */
            return default;
        }

        public async Task<TEntity> SearchRenderResultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fetch_fields, object mapping, object icon, object limit) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: mixins.py) ---
            // def _search_render_results(self, fetch_fields, mapping, icon, limit):
            // results_data = self.read(fetch_fields)[:limit]
            // for result in results_data:
            //     result['_fa'] = icon
            //     result['_mapping'] = mapping
            // html_fields = [config['name'] for config in mapping.values() if config.get('html')]
            // if html_fields:
            //     for result, data in zip(self, results_data):
            //         for html_field in html_fields:
            //             if data[html_field]:
            //                 if html_field == 'arch':
            //                     # Undo second escape of text nodes from wywsiwyg.js _getEscapedElement.
            //                     data[html_field] = re.sub(r'&amp;(?=\w+;)', '&', data[html_field])
            //                 text = text_from_html(data[html_field], True)
            //                 data[html_field] = text
            // return results_data
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
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def _search_render_results(self, fetch_fields, mapping, icon, limit):
            // results_data = super()._search_render_results(fetch_fields, mapping, icon, limit)
            // for forum, data in zip(self, results_data):
            //     data['website_url'] = forum._compute_website_url()
            // return results_data
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _search_render_results(self, fetch_fields, mapping, icon, limit):
            // with_date = 'detail' in mapping
            // results_data = super()._search_render_results(fetch_fields, mapping, icon, limit)
            // for post, data in zip(self, results_data):
            //     if with_date:
            //         data['date'] = self.env['ir.qweb.field.date'].record_to_html(post, 'write_date', {})
            // return results_data
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py) ---
            // def _search_render_results(self, fetch_fields, mapping, icon, limit):
            // results_data = super()._search_render_results(fetch_fields, mapping, icon, limit)
            // for data in results_data:
            //     data['url'] = '/shop/category/%s' % data['id']
            // return results_data
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _search_render_results(self, fetch_fields, mapping, icon, limit):
            // with_image = 'image_url' in mapping
            // with_category = 'extra_link' in mapping
            // with_price = 'detail' in mapping
            // results_data = super()._search_render_results(fetch_fields, mapping, icon, limit)
            // current_website = self.env['website'].get_current_website()
            // for product, data in zip(self, results_data):
            //     categ_ids = product.public_categ_ids.filtered(lambda c: not c.website_id or c.website_id == current_website)
            //     if with_price:
            //         combination_info = product._get_combination_info(only_template=True)
            //         data['price'], list_price = self._search_render_results_prices(
            //             mapping, combination_info
            //         )
            //         if list_price:
            //             data['list_price'] = list_price
            // 
            //     if with_image:
            //         data['image_url'] = '/web/image/product.template/%s/image_128' % data['id']
            //     if with_category and categ_ids:
            //         data['category'] = self.env['ir.ui.view'].sudo()._render_template(
            //             "website_sale.product_category_extra_link",
            //             {'categories': categ_ids, 'slug': self.env['ir.http']._slug}
            //         )
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

        public async Task<TEntity> SearchRenderResultsPricesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mapping, object combination_info) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _search_render_results_prices(self, mapping, combination_info):
            // if combination_info.get('prevent_zero_price_sale'):
            //     website = self.env['website'].get_current_website()
            //     return website.prevent_zero_price_sale_text, None
            // 
            // monetary_options = {'display_currency': mapping['detail']['display_currency']}
            // price = self.env['ir.qweb.field.monetary'].value_to_html(
            //     combination_info['price'], monetary_options
            // )
            // list_price = None
            // if combination_info['has_discounted_price']:
            //     list_price = self.env['ir.qweb.field.monetary'].value_to_html(
            //         combination_info['list_price'], monetary_options
            //     )
            // if combination_info['compare_list_price']:
            //     list_price = self.env['ir.qweb.field.monetary'].value_to_html(
            //         combination_info['compare_list_price'], monetary_options
            //     )
            // 
            // return price, list_price
            */
            return default;
        }

        public async Task<TEntity> SearchStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _search_standard_price(self, operator, value):
            // return [('product_variant_ids.standard_price', operator, value)]
            */
            return default;
        }

        public async Task<TEntity> SearchVirtualAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def _search_virtual_available(self, operator, value):
            // domain = [('virtual_available', operator, value)]
            // product_variant_query = self.env['product.product']._search(domain)
            // return [('product_variant_ids', 'in', product_variant_query)]
            */
            return default;
        }

        public async Task<TEntity> SelectionServicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: product_template.py) ---
            // def _selection_service_policy(self):
            // service_policies = [
            //     # (service_policy, string)
            //     ('ordered_prepaid', _('Prepaid/Fixed Price')),
            //     ('delivered_manual', _('Based on Delivered Quantity (Manual)')),
            // ]
            // 
            // user = self.env['res.users'].sudo().browse(SUPERUSER_ID)
            // if (self.env.user.has_group('project.group_project_milestone') or
            //         (self.env.user.has_group('base.group_public') and user.has_group('project.group_project_milestone'))
            // ):
            //     service_policies.insert(1, ('delivered_milestones', _('Based on Milestones')))
            // return service_policies
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def _selection_service_policy(self):
            // service_policies = super()._selection_service_policy()
            // service_policies.insert(1, ('delivered_timesheet', _('Based on Timesheets')))
            // return service_policies
            */
            return default;
        }

        public async Task<TEntity> SendShareEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email, object fullscreen) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ServiceTrackingBlacklistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth_sale, FILE: product_template.py) ---
            // def _service_tracking_blacklist(self):
            // return super()._service_tracking_blacklist() + ['event_booth']
            --- ODOO METHOD SOURCE (MODULE: event_product, FILE: product_template.py) ---
            // def _service_tracking_blacklist(self):
            // return super()._service_tracking_blacklist() + ['event']
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _service_tracking_blacklist(self):
            // """ Service tracking field is used to distinguish some specific categories of products.
            // Those products shouldn't be displayed or used in unrelated applications.
            // This method returns a domain targeting all those specific products (events, courses, ...).
            // """
            // return []
            --- ODOO METHOD SOURCE (MODULE: website_sale_slides, FILE: product_template.py) ---
            // def _service_tracking_blacklist(self):
            // return super()._service_tracking_blacklist() + ['course']
            */
            return default;
        }

        public async Task<TEntity> SetBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_barcode(self):
            // self._set_product_variant_field('barcode')
            */
            return default;
        }

        public async Task<TEntity> SetBaseUnitCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _set_base_unit_count(self):
            // for template in self:
            //     if len(template.product_variant_ids) == 1:
            //         template.product_variant_ids.base_unit_count = template.base_unit_count
            */
            return default;
        }

        public async Task<TEntity> SetBaseUnitIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _set_base_unit_id(self):
            // for template in self:
            //     if len(template.product_variant_ids) == 1:
            //         template.product_variant_ids.base_unit_id = template.base_unit_id
            */
            return default;
        }

        public async Task<TEntity> SetDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_default_code(self):
            // self._set_product_variant_field('default_code')
            */
            return default;
        }

        public async Task<TEntity> SetDefaultFaqInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def _set_default_faq(self):
            // for forum in self:
            //     forum.faq = self.env['ir.ui.view']._render_template('website_forum.faq_accordion', {"forum": forum})
            */
            return default;
        }

        public async Task<TEntity> SetDoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> SetL10nEgEtaCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_eg_edi_eta, FILE: product_template.py) ---
            // def _set_l10n_eg_eta_code(self):
            // if len(self.product_variant_ids) == 1:
            //     self.product_variant_ids.l10n_eg_eta_code = self.l10n_eg_eta_code
            */
            return default;
        }

        public async Task<TEntity> SetOpenAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def set_open(self):
            // self.write({'website_published': False})
            // return super(Job, self).set_open()
            */
            return default;
        }

        public async Task<TEntity> SetPackagingIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> SetPostDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> SetProductVariantFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> SetSequenceBottomAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def set_sequence_bottom(self):
            // max_sequence = self.sudo().search([], order='website_sequence DESC', limit=1)
            // self.website_sequence = max_sequence.website_sequence + 5
            */
            return default;
        }

        public async Task<TEntity> SetSequenceDownAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def set_sequence_down(self):
            // next_prodcut_tmpl = self.search([
            //     ('website_sequence', '>', self.website_sequence),
            //     ('website_published', '=', self.website_published),
            // ], order='website_sequence ASC', limit=1)
            // if next_prodcut_tmpl:
            //     next_prodcut_tmpl.website_sequence, self.website_sequence = self.website_sequence, next_prodcut_tmpl.website_sequence
            // else:
            //     return self.set_sequence_bottom()
            */
            return default;
        }

        public async Task<TEntity> SetSequenceTopAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def set_sequence_top(self):
            // min_sequence = self.sudo().search([], order='website_sequence ASC', limit=1)
            // self.website_sequence = min_sequence.website_sequence - 5
            */
            return default;
        }

        public async Task<TEntity> SetSequenceUpAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def set_sequence_up(self):
            // previous_product_tmpl = self.sudo().search([
            //     ('website_sequence', '<', self.website_sequence),
            //     ('website_published', '=', self.website_published),
            // ], order='website_sequence DESC', limit=1)
            // if previous_product_tmpl:
            //     previous_product_tmpl.website_sequence, self.website_sequence = self.website_sequence, previous_product_tmpl.website_sequence
            // else:
            //     self.set_sequence_top()
            */
            return default;
        }

        public async Task<TEntity> SetStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_standard_price(self):
            // self._set_product_variant_field('standard_price')
            */
            return default;
        }

        public async Task<TEntity> SetTeaserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> SetTzContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _set_tz_context(self):
            // self.ensure_one()
            // return self.with_context(tz=self.date_tz or 'UTC')
            */
            return default;
        }

        public async Task<TEntity> SetViewedAsync<TEntity>(IEnumerable<TEntity> entities, object quiz_attempts_inc) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> SetViewedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _set_viewed(self):
            // self.ensure_one()
            // return sql.increment_fields_skiplock(self, 'views')
            */
            return default;
        }

        public async Task<TEntity> SetVolumeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_volume(self):
            // self._set_product_variant_field('volume')
            */
            return default;
        }

        public async Task<TEntity> SetWeightInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_template.py) ---
            // def _set_weight(self):
            // self._set_product_variant_field('weight')
            */
            return default;
        }

        public async Task<TEntity> SplitMenusStateByFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> SyncGelatoTemplateInfoAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py) ---
            // def action_sync_gelato_template_info(self):
            // """ Fetch the template information from Gelato and update the product template accordingly.
            // 
            // :return: The action to display a toast notification to the user.
            // :rtype: dict
            // """
            // # Fetch the template info from Gelato.
            // try:
            //     endpoint = f'templates/{self.gelato_template_ref}'
            //     template_info = utils.make_request(
            //         self.env.company.sudo().gelato_api_key, 'ecommerce', 'v1', endpoint, method='GET'
            //     )  # In sudo mode to read the API key from the company.
            // except UserError as e:
            //     return {
            //         'type': 'ir.actions.client',
            //         'tag': 'display_notification',
            //         'params': {
            //             'type': 'danger',
            //             'title': _("Could not synchronize with Gelato"),
            //             'message': str(e),
            //             'sticky': True,
            //         }
            //     }
            // 
            // # Apply the necessary changes on the product template.
            // self._create_attributes_from_gelato_info(template_info)
            // self._create_print_images_from_gelato_info(template_info)
            // 
            // # Display a toaster notification to the user if all went well.
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'type': 'success',
            //         'title': _("Successfully synchronized with Gelato"),
            //         'message': _("Missing product variants and images have been successfully created."),
            //         'sticky': False,
            //         'next': {
            //             'type': 'ir.actions.client',
            //             'tag': 'soft_reload'
            //         }
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> TagToWriteValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tags) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> TestSurveyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment_survey, FILE: hr_job.py) ---
            // def action_test_survey(self):
            // self.ensure_one()
            // action = self.survey_id.action_test_survey()
            // return action
            */
            return default;
        }

        public async Task<TEntity> ToggleActiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def toggle_active(self):
            // self.filtered('active').website_published = False
            // return super().toggle_active()
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

        public async Task<TEntity> ToggleBoothMenuAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_booth, FILE: event_event.py) ---
            // def toggle_booth_menu(self, val):
            // self.booth_menu = val
            */
            return default;
        }

        public async Task<TEntity> ToggleExhibitorMenuAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py) ---
            // def toggle_exhibitor_menu(self, val):
            // self.exhibitor_menu = val
            */
            return default;
        }

        public async Task<TEntity> ToggleWebsiteMenuAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def toggle_website_menu(self, val):
            // self.website_menu = val
            */
            return default;
        }

        public async Task<TEntity> ToggleWebsiteTrackAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def toggle_website_track(self, val):
            // self.website_track = val
            */
            return default;
        }

        public async Task<TEntity> ToggleWebsiteTrackProposalAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def toggle_website_track_proposal(self, val):
            // self.website_track_proposal = val
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_controller_page.py) ---
            // def unlink(self):
            // # When a website_controller_page is deleted, the ORM does not delete its
            // # ir_ui_view. So we got to delete it ourself, but only if the
            // # ir_ui_view is not used by another website_page.
            // views_to_delete = self.view_id.filtered(
            //     lambda v: v.controller_page_ids <= self and not v.inherit_children_ids
            // )
            // # Rebind self to avoid unlink already deleted records from `ondelete="cascade"`
            // self = self - views_to_delete.controller_page_ids
            // views_to_delete.unlink()
            // 
            // # Make sure website._get_menu_ids() will be recomputed
            // self.env.registry.clear_cache()
            // return super().unlink()
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def unlink(self):
            // # When a website_page is deleted, the ORM does not delete its
            // # ir_ui_view. So we got to delete it ourself, but only if the
            // # ir_ui_view is not used by another website_page.
            // views_to_delete = self.view_id.filtered(
            //     lambda v: v.page_ids <= self and not v.inherit_children_ids
            // )
            // # Rebind self to avoid unlink already deleted records from `ondelete="cascade"`
            // self = self - views_to_delete.page_ids
            // views_to_delete.unlink()
            // 
            // # Make sure website._get_menu_ids() will be recomputed
            // self.env.registry.clear_cache()
            // return super().unlink()
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def unlink(self):
            // self.env['website'].sudo()._update_forum_count()
            // return super().unlink()
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def unlink(self):
            // # if unlinking an answer with accepted answer: remove provided karma
            // for post in self:
            //     if post.is_correct:
            //         post.create_uid.sudo()._add_karma(post.forum_id.karma_gen_answer_accepted * -1, post, _('The accepted answer is deleted'))
            //         self.env.user.sudo()._add_karma(post.forum_id.karma_gen_answer_accepted * -1, post, _('Delete the accepted answer'))
            // return super(Post, self).unlink()
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

        public async Task<TEntity> UnlinkCommentAsync<TEntity>(IEnumerable<TEntity> entities, Guid message_id) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def unlink_comment(self, message_id):
            // comment_sudo = self.env['mail.message'].sudo().browse(message_id)
            // if comment_sudo.model != 'forum.post':
            //     return [False] * len(self)
            // 
            // user_karma = self.env.user.karma
            // result = []
            // for post in self:
            //     if comment_sudo.res_id != post.id:
            //         result.append(False)
            //         continue
            //     # karma-based action check: must check the message's author to know if own or all
            //     karma_required = (
            //         post.forum_id.karma_comment_unlink_own
            //         if comment_sudo.author_id.id == self.env.user.partner_id.id
            //         else post.forum_id.karma_comment_unlink_all
            //     )
            //     if user_karma < karma_required:
            //         raise AccessError(_('%d karma required to delete a comment.', karma_required))
            //     result.append(comment_sudo.unlink())
            // return result
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptLoyaltyProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: product_template.py) ---
            // def _unlink_except_loyalty_products(self):
            // product_data = [
            //     self.env.ref('loyalty.gift_card_product_50', False),
            //     self.env.ref('loyalty.ewallet_product_50', False),
            // ]
            // for product in self.filtered(lambda p: p.product_variant_id in product_data):
            //     raise UserError(_(
            //         "You cannot delete %(name)s as it is used in 'Coupons & Loyalty'."
            //         " Please archive it instead.",
            //         name=product.with_context(display_default_code=False).display_name
            //     ))
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptMasterDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py) ---
            // def _unlink_except_master_data(self):
            // time_product = self.env.ref('sale_timesheet.time_product')
            // if time_product.product_tmpl_id in self:
            //     raise ValidationError(_('The %s product is required by the Timesheets app and cannot be archived nor deleted.', time_product.name))
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptOpenSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: product.py) ---
            // def _unlink_except_open_session(self):
            // product_ctx = dict(self.env.context or {}, active_test=False)
            // if self.with_context(product_ctx).search_count([('id', 'in', self.ids), ('available_in_pos', '=', True)]):
            //     if self.env['pos.session'].sudo().search_count([('state', '!=', 'closed')]):
            //         raise UserError(_(
            //             "To delete a product, make sure all point of sale sessions are closed.\n\n"
            //             "Deleting a product available in a session would be like attempting to snatch a hamburger from a customer’s hand mid-bite; chaos will ensue as ketchup and mayo go flying everywhere!",
            //         ))
            */
            return default;
        }

        public async Task<TEntity> UnlinkIfEnoughKarmaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _unlink_if_enough_karma(self):
            // for post in self:
            //     if not post.can_unlink:
            //         raise AccessError(_('%d karma required to unlink a post.', post.karma_unlink))
            */
            return default;
        }

        public async Task<TEntity> UpdateContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object content, Guid forum_id) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _update_content(self, content, forum_id):
            // forum = self.env['forum.forum'].browse(forum_id)
            // if content and self.env.user.karma < forum.karma_dofollow:
            //     for match in re.findall(r'<a\s.*href=".*?">', content):
            //         escaped_match = re.escape(match)  # replace parenthesis or special char in regex
            //         url_match = re.match(r'^.*href="(.*)".*', match) # extracting the link allows to rebuild a clean link tag
            //         url = url_match.group(1)
            //         content = re.sub(escaped_match, f'<a rel="nofollow" href="{url}">', content)
            // 
            // if self.env.user.karma < forum.karma_editor:
            //     filter_regexp = r'(<img.*?>)|(<a[^>]*?href[^>]*?>)|(<[a-z|A-Z]+[^>]*style\s*=\s*[\'"][^\'"]*\s*background[^:]*:[^url;]*url)'
            //     content_match = re.search(filter_regexp, content, re.I)
            //     if content_match:
            //         raise AccessError(_('%d karma required to post an image or link.', forum.karma_editor))
            // return content
            */
            return default;
        }

        public async Task<TEntity> UpdateLastActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def _update_last_activity(self):
            // self.ensure_one()
            // return self.sudo().write({'last_activity_date': fields.Datetime.now()})
            */
            return default;
        }

        public async Task<TEntity> UpdateQuantityOnHandAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_update_quantity_on_hand(self):
            // advanced_option_groups = [
            //     'stock.group_stock_multi_locations',
            //     'stock.group_tracking_owner',
            //     'stock.group_tracking_lot'
            // ]
            // if any(self.env.user.has_group(g) for g in advanced_option_groups) or self.tracking != 'none':
            //     return self.action_open_quants()
            // else:
            //     default_product_id = self.env.context.get('default_product_id', len(self.product_variant_ids) == 1 and self.product_variant_id.id)
            //     action = self.env["ir.actions.actions"]._for_xml_id("stock.action_change_product_quantity")
            //     action['context'] = dict(
            //         self.env.context,
            //         default_product_id=default_product_id,
            //         default_product_tmpl_id=self.id
            //     )
            //     return action
            */
            return default;
        }

        public async Task<TEntity> UpdateWebsiteMenuEntryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname_bool, object fname_o2m, object fmenu_type) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> UpdateWebsiteMenusInternalAsync<TEntity>(IEnumerable<TEntity> entities, object menus_update_by_field) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> UsedInBomAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def action_used_in_bom(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("mrp.mrp_bom_form_action")
            // action['domain'] = [('bom_line_ids.product_tmpl_id', '=', self.id)]
            // return action
            */
            return default;
        }

        public async Task<TEntity> ValidateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def validate(self):
            // for post in self:
            //     if not post.can_moderate:
            //         raise AccessError(_('%d karma required to validate a post.', post.forum_id.karma_moderate))
            //     # if state == pending, no karma previously added for the new question
            //     if post.state == 'pending':
            //         post.create_uid.sudo()._add_karma(
            //             post.forum_id.karma_gen_question_new,
            //             post,
            //             _('Ask a question'),
            //         )
            //     post.write({
            //         'state': 'active',
            //         'active': True,
            //         'moderator_id': self.env.user.id,
            //     })
            //     post.sudo()._notify_state_update()
            // return True
            */
            return default;
        }

        public async Task<TEntity> ViewEmbedsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ViewLinkedOrdersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ViewMosAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: product.py) ---
            // def action_view_mos(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("mrp.mrp_production_action")
            // action['domain'] = [('state', '=', 'done'), ('product_tmpl_id', 'in', self.ids)]
            // action['context'] = {
            //     'search_default_filter_plan_date': 1,
            // }
            // return action
            */
            return default;
        }

        public async Task<TEntity> ViewOrderpointsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_view_orderpoints(self):
            // return self.product_variant_ids.action_view_orderpoints()
            */
            return default;
        }

        public async Task<TEntity> ViewPoAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: product.py) ---
            // def action_view_po(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("purchase.action_purchase_history")
            // action['domain'] = [
            //     ('state', 'in', ['purchase', 'done']),
            //     ('product_id', 'in', self.with_context(active_test=False).product_variant_ids.ids),
            // ]
            // action['display_name'] = _("Purchase History for %s", self.display_name)
            // return action
            */
            return default;
        }

        public async Task<TEntity> ViewRatingsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ViewRelatedPutawayRulesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_view_related_putaway_rules(self):
            // self.ensure_one()
            // domain = [
            //     '|',
            //         ('product_id.product_tmpl_id', '=', self.id),
            //         ('category_id', '=', self.categ_id.id),
            // ]
            // return self._get_action_view_related_putaway_rules(domain)
            */
            return default;
        }

        public async Task<TEntity> ViewSalesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: product_template.py) ---
            // def action_view_sales(self):
            // action = self.env['ir.actions.actions']._for_xml_id('sale.report_all_channels_sales_action')
            // action['domain'] = [('product_tmpl_id', 'in', self.ids)]
            // action['context'] = {
            //     'pivot_measures': ['product_uom_qty'],
            //     'active_id': self._context.get('active_id'),
            //     'active_model': 'sale.report',
            //     'search_default_Sales': 1,
            //     'search_default_filter_order_date': 1,
            //     'search_default_group_by_date': 1,
            // }
            // return action
            */
            return default;
        }

        public async Task<TEntity> ViewSlidesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
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

        public async Task<TEntity> ViewStockMoveLinesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_view_stock_move_lines(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("stock.stock_move_line_action")
            // action['domain'] = [('product_id.product_tmpl_id', 'in', self.ids)]
            // return action
            */
            return default;
        }

        public async Task<TEntity> ViewStorageCategoryCapacityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: product.py) ---
            // def action_view_storage_category_capacity(self):
            // self.ensure_one()
            // return self.product_variant_ids.action_view_storage_category_capacity()
            */
            return default;
        }

        public async Task<TEntity> VoteAsync<TEntity>(IEnumerable<TEntity> entities, object upvote) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def vote(self, upvote=True):
            // self.ensure_one()
            // Vote = self.env['forum.post.vote']
            // existing_vote = Vote.search([('post_id', '=', self.id), ('user_id', '=', self._uid)])
            // new_vote_value = '1' if upvote else '-1'
            // if existing_vote:
            //     if upvote:
            //         new_vote_value = '0' if existing_vote.vote == '-1' else '1'
            //     else:
            //         new_vote_value = '0' if existing_vote.vote == '1' else '-1'
            //     existing_vote.vote = new_vote_value
            // else:
            //     Vote.create({'post_id': self.id, 'vote': new_vote_value})
            // return {'vote_count': self.vote_count, 'user_vote': new_vote_value}
            */
            return default;
        }

        public async Task<TEntity> WebsiteShowQuickAddInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def _website_show_quick_add(self):
            // self.ensure_one()
            // # TODO VFE pass website as param and avoid existence check
            // website = self.env['website'].get_current_website()
            // return self.sale_ok and (not website.prevent_zero_price_sale or self._get_contextual_price())
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_controller_page.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // for rec in self:
            //     rec.menu_ids.write({
            //         "url": f"/model/{rec.name_slugified}",
            //         "name": rec.name,
            //     })
            // return res
            --- ODOO METHOD SOURCE (MODULE: website, FILE: website_page.py) ---
            // def write(self, vals):
            // for page in self:
            //     website_id = False
            //     if vals.get('website_id') or page.website_id:
            //         website_id = vals.get('website_id') or page.website_id.id
            // 
            //     # If URL has been edited, slug it
            //     if 'url' in vals:
            //         url = vals['url'] or ''
            //         url = '/' + self.env['ir.http']._slugify(url, max_length=1024, path=True)
            //         if page.url != url:
            //             url = self.env['website'].with_context(website_id=website_id).get_unique_path(url)
            //             page.menu_ids.write({'url': url})
            //             # Sync website's homepage URL
            //             website = self.env['website'].get_current_website()
            //             page_url_normalized = {'homepage_url': page.url}
            //             website._handle_homepage_url(page_url_normalized)
            //             if website.homepage_url == page_url_normalized['homepage_url']:
            //                 website.homepage_url = url
            //         vals['url'] = url
            // 
            //     # If name has changed, check for key uniqueness
            //     if 'name' in vals and page.name != vals['name']:
            //         vals['key'] = self.env['website'].with_context(website_id=website_id).get_unique_key(self.env['ir.http']._slugify(vals['name'] or ''))
            //     if 'visibility' in vals:
            //         if vals['visibility'] != 'restricted_group':
            //             vals['groups_id'] = False
            // self.env.registry.clear_cache()  # write on page == write on view that invalid cache
            // return super(Page, self).write(vals)
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
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py) ---
            // def write(self, vals):
            // trusted_keys = ['active', 'is_correct', 'tag_ids']  # fields where security is checked manually
            // if 'forum_id' in vals:
            //     forum = self.env['forum.forum'].browse(vals['forum_id'])
            //     forum.check_access('write')
            // if 'content' in vals:
            //     vals['content'] = self._update_content(vals['content'], self.forum_id.id)
            // 
            // tag_ids = False
            // if 'tag_ids' in vals:
            //     tag_ids = set(self.new({'tag_ids': vals['tag_ids']}).tag_ids.ids)
            // 
            // for post in self:
            //     if 'state' in vals:
            //         if vals['state'] in ['active', 'close']:
            //             if not post.can_close:
            //                 raise AccessError(_('%d karma required to close or reopen a post.', post.karma_close))
            //             trusted_keys += ['state', 'closed_uid', 'closed_date', 'closed_reason_id']
            //         elif vals['state'] == 'flagged':
            //             if not post.can_flag:
            //                 raise AccessError(_('%d karma required to flag a post.', post.forum_id.karma_flag))
            //             trusted_keys += ['state', 'flag_user_id']
            //     if 'active' in vals:
            //         if not post.can_unlink:
            //             raise AccessError(_('%d karma required to delete or reactivate a post.', post.karma_unlink))
            //     if 'is_correct' in vals:
            //         if not post.can_accept:
            //             raise AccessError(_('%d karma required to accept or refuse an answer.', post.karma_accept))
            //         # update karma except for self-acceptance
            //         mult = 1 if vals['is_correct'] else -1
            //         if vals['is_correct'] != post.is_correct and post.create_uid.id != self._uid:
            //             post.create_uid.sudo()._add_karma(post.forum_id.karma_gen_answer_accepted * mult, post,
            //                                               _('User answer accepted') if mult > 0 else _('Accepted answer removed'))
            //             self.env.user.sudo()._add_karma(post.forum_id.karma_gen_answer_accept * mult, post,
            //                                             _('Validate an answer') if mult > 0 else _('Remove validated answer'))
            //     if tag_ids:
            //         if set(post.tag_ids.ids) != tag_ids and self.env.user.karma < post.forum_id.karma_edit_retag:
            //             raise AccessError(_('%d karma required to retag.', post.forum_id.karma_edit_retag))
            //     if any(key not in trusted_keys for key in vals) and not post.can_edit:
            //         raise AccessError(_('%d karma required to edit a post.', post.karma_edit))
            // 
            // res = super(Post, self).write(vals)
            // 
            // # if post content modify, notify followers
            // if 'content' in vals or 'name' in vals:
            //     for post in self:
            //         if post.parent_id:
            //             body, subtype_xmlid = _('Answer Edited'), 'website_forum.mt_answer_edit'
            //             obj_id = post.parent_id
            //         else:
            //             body, subtype_xmlid = _('Question Edited'), 'website_forum.mt_question_edit'
            //             obj_id = post
            //         obj_id.message_post(body=body, subtype_xmlid=subtype_xmlid)
            // if 'active' in vals:
            //     answers = self.env['forum.post'].with_context(active_test=False).search([('parent_id', 'in', self.ids)])
            //     if answers:
            //         answers.write({'active': vals['active']})
            // return res
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_template.py) ---
            // def write(self, vals):
            // # Clear empty ecommerce description content to avoid side-effects on product pages
            // # when there is no content to display anyway.
            // if vals.get('description_ecommerce') and is_html_empty(vals['description_ecommerce']):
            //     vals['description_ecommerce'] = ''
            // return super().write(vals)
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