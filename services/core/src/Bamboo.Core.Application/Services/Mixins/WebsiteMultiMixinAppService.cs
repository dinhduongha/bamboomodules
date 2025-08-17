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
    public class WebsiteMultiMixinAppService : ApplicationService, IWebsiteMultiMixinAppService
    {

        public WebsiteMultiMixinAppService() 
        {

        }

        public async Task<TEntity> AllTagsAsync<TEntity>(IEnumerable<TEntity> entities, object @join, object min_limit) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
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

        public async Task<TEntity> CanAccessFromCurrentWebsiteAsync<TEntity>(IEnumerable<TEntity> entities, Guid website_id) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: mixins.py) ---
            // def can_access_from_current_website(self, website_id=False):
            // can_access = True
            // for record in self:
            //     if (website_id or record.website_id.id) not in (False, request.env['website'].get_current_website().id):
            //         can_access = False
            //         continue
            // return can_access
            */
            return default;
        }

        public async Task<TEntity> CheckDateFromDateToInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def _check_date_from_date_to(self):
            // if any(p.date_to and p.date_from and p.date_from > p.date_to for p in self):
            //     raise UserError(_(
            //         "The validity period's start date must be anterior or equal to its end date."
            //     ))
            */
            return default;
        }

        public async Task<TEntity> CheckParentIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py) ---
            // def check_parent_id(self):
            // if self._has_cycle():
            //     raise ValueError(self.env._("Error! You cannot create recursive categories."))
            */
            return default;
        }

        public async Task<TEntity> CheckPricelistCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def _check_pricelist_currency(self):
            // if any(
            //     pricelist.currency_id != program.currency_id
            //     for program in self
            //     for pricelist in program.pricelist_ids
            // ):
            //     raise UserError(_(
            //         "The loyalty program's currency must be the same as all it's pricelists ones."
            //     ))
            */
            return default;
        }

        public async Task<TEntity> ComputeBlogPostCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _compute_blog_post_count(self):
            // for record in self:
            //     record.blog_post_count = len(record.blog_post_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeCanModerateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def _compute_can_moderate(self):
            // for forum in self:
            //     forum.can_moderate = self.env.user.karma >= forum.karma_moderate
            */
            return default;
        }

        public async Task<TEntity> ComputeCountFlaggedPostsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
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

        public async Task<TEntity> ComputeCountPostsWaitingValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
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

        public async Task<TEntity> ComputeCouponCountDisplayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def _compute_coupon_count_display(self):
            // program_items_name = self._program_items_name()
            // for program in self:
            //     program.coupon_count_display = "%i %s" % (program.coupon_count or 0, program_items_name[program.program_type] or '')
            */
            return default;
        }

        public async Task<TEntity> ComputeCouponCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def _compute_coupon_count(self):
            // read_group_data = self.env['loyalty.card']._read_group([('program_id', 'in', self.ids)], ['program_id'], ['__count'])
            // count_per_program = {program.id: count for program, count in read_group_data}
            // for program in self:
            //     program.coupon_count = count_per_program.get(program.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def _compute_currency_id(self):
            // for program in self:
            //     program.currency_id = program.company_id.currency_id or program.currency_id
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
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

        public async Task<TEntity> ComputeForumStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
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

        public async Task<TEntity> ComputeFromProgramTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def _compute_from_program_type(self):
            // program_type_defaults = self._program_type_default_values()
            // grouped_programs = defaultdict(lambda: self.env['loyalty.program'])
            // for program in self:
            //     grouped_programs[program.program_type] |= program
            // for program_type, programs in grouped_programs.items():
            //     if program_type in program_type_defaults:
            //         programs.write(program_type_defaults[program_type])
            */
            return default;
        }

        public async Task<TEntity> ComputeHasPendingPostInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
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

        public async Task<TEntity> ComputeIsNominativeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def _compute_is_nominative(self):
            // for program in self:
            //     program.is_nominative = program.applies_on == 'both' or\
            //         (program.program_type in ('ewallet', 'loyalty') and program.applies_on == 'future')
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPaymentProgramInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def _compute_is_payment_program(self):
            // for program in self:
            //     program.is_payment_program = program.program_type in ('gift_card', 'ewallet')
            */
            return default;
        }

        public async Task<TEntity> ComputeLastPostIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
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

        public async Task<TEntity> ComputeMailTemplateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def _compute_mail_template_id(self):
            // for program in self:
            //     program.mail_template_id = program.communication_plan_ids.mail_template_id[:1]
            */
            return default;
        }

        public async Task<TEntity> ComputeOrderCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: loyalty_program.py) ---
            // def _compute_order_count(self):
            // # An order should count only once PER program but may appear in multiple programs
            // read_group_res = self.env['sale.order.line']._read_group(
            //     [('reward_id', 'in', self.reward_ids.ids)], ['order_id'], ['reward_id:array_agg'])
            // for program in self:
            //     program_reward_ids = program.reward_ids.ids
            //     program.order_count = sum(
            //         any(id_ in reward_ids for id_ in program_reward_ids)
            //         for __, reward_ids in read_group_res
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeParentsAndSelfInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
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

        public async Task<TEntity> ComputePaymentProgramDiscountProductIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def _compute_payment_program_discount_product_id(self):
            // for program in self:
            //     if program.is_payment_program:
            //         program.payment_program_discount_product_id = program.reward_ids[:1].discount_line_product_id
            //     else:
            //         program.payment_program_discount_product_id = False
            */
            return default;
        }

        public async Task<TEntity> ComputePortalPointNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def _compute_portal_point_name(self):
            // for program in self:
            //     if program.program_type not in ('ewallet', 'gift_card'):
            //         continue
            //     program.portal_point_name = program.currency_id.symbol or ''
            */
            return default;
        }

        public async Task<TEntity> ComputePosConfigIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_program.py) ---
            // def _compute_pos_config_ids(self):
            // for program in self:
            //     if not program.pos_ok:
            //         program.pos_config_ids = False
            */
            return default;
        }

        public async Task<TEntity> ComputePosOrderCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_program.py) ---
            // def _compute_pos_order_count(self):
            // query = """
            //     SELECT program.id, SUM(orders_count)
            //     FROM loyalty_program program
            //         JOIN loyalty_reward reward ON reward.program_id = program.id
            //         JOIN LATERAL (
            //             SELECT COUNT(DISTINCT orders.id) AS orders_count
            //             FROM pos_order orders
            //                 JOIN pos_order_line order_lines ON order_lines.order_id = orders.id
            //                 WHERE order_lines.reward_id = reward.id
            //         ) agg ON TRUE
            //         WHERE program.id = ANY(%s)
            //             GROUP BY program.id
            //         """
            // self._cr.execute(query, (self.ids,))
            // res = self._cr.dictfetchall()
            // res = {k['id']: k['sum'] for k in res}
            // 
            // for rec in self:
            //     rec.pos_order_count = res.get(rec.id) or 0
            */
            return default;
        }

        public async Task<TEntity> ComputePosReportPrintIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_program.py) ---
            // def _compute_pos_report_print_id(self):
            // for program in self:
            //     program.pos_report_print_id = program.communication_plan_ids.pos_report_print_id[:1]
            */
            return default;
        }

        public async Task<TEntity> ComputeProductIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_tag.py) ---
            // def _compute_product_ids(self):
            // for tag in self:
            //     tag.product_ids = tag.product_template_ids.product_variant_ids | tag.product_product_ids
            */
            return default;
        }

        public async Task<TEntity> ComputeTagIdsUsageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
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

        public async Task<TEntity> ComputeTeaserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def _compute_teaser(self):
            // for forum in self:
            //     forum.teaser = textwrap.shorten(forum.description, width=180, placeholder='...') if forum.description else ""
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalOrderCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def _compute_total_order_count(self):
            // self.total_order_count = 0
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_program.py) ---
            // def _compute_total_order_count(self):
            // super()._compute_total_order_count()
            // for program in self:
            //     program.total_order_count += program.pos_order_count
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: loyalty_program.py) ---
            // def _compute_total_order_count(self):
            // super()._compute_total_order_count()
            // for program in self:
            //     program.total_order_count += program.order_count
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsitePublishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
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

        public async Task<TEntity> ComputeWebsiteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def _compute_website_url(self):
            // if not self.id:
            //     return False
            // return f'/forum/{self.env["ir.http"]._slug(self)}'
            */
            return default;
        }

        public async Task<TEntity> ConstrainsRewardIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def _constrains_reward_ids(self):
            // if self.env.context.get('loyalty_skip_reward_check'):
            //     return
            // if any(not program.reward_ids for program in self):
            //     raise ValidationError(_('A program must have at least one reward.'))
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_tag.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, name=self.env._("%s (copy)", tag.name)) for tag, vals in zip(self, vals_list)]
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def create(self, vals_list):
            // forums = super(
            //     Forum,
            //     self.with_context(mail_create_nolog=True, mail_create_nosubscribe=True)
            // ).create(vals_list)
            // self.env['website'].sudo()._update_forum_count()
            // forums._set_default_faq()
            // return forums
            */
            return default;
        }

        public async Task<TEntity> CreateFromTemplateAsync<TEntity>(IEnumerable<TEntity> entities, Guid template_id) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def create_from_template(self, template_id):
            // '''
            // Creates the program from the template id defined in `get_program_templates`.
            // 
            // Returns an action leading to that new record.
            // '''
            // template_values = self._get_template_values()
            // if template_id not in template_values:
            //     return False
            // program = self.create(template_values[template_id])
            // action = {}
            // if self.env.context.get('menu_type') == 'gift_ewallet':
            //     action = self.env['ir.actions.act_window']._for_xml_id('loyalty.loyalty_program_gift_ewallet_action')
            //     action['views'] = [[False, 'form']]
            // else:
            //     action = self.env['ir.actions.act_window']._for_xml_id('loyalty.loyalty_program_discount_loyalty_action')
            //     view_id = self.env.ref('loyalty.loyalty_program_view_form').id
            //     action['views'] = [[view_id, 'form']]
            // action['view_mode'] = 'form'
            // action['res_id'] = program.id
            // return action
            */
            return default;
        }

        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields_list) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def default_get(self, fields_list):
            // defaults = super().default_get(fields_list)
            // program_type = defaults.get('program_type')
            // if program_type:
            //     program_default_values = self._program_type_default_values()
            //     if program_type in program_default_values:
            //         default_values = program_default_values[program_type]
            //         defaults.update({k: v for k, v in default_values.items() if k in fields_list})
            // return defaults
            */
            return default;
        }

        public async Task<TEntity> DefaultSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
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

        public async Task<TEntity> GetDefaultTemplateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_tag.py) ---
            // def _get_default_template_id(self):
            // return self.env['product.template'].browse(self.env.context.get('product_template_id'))
            */
            return default;
        }

        public async Task<TEntity> GetDefaultVariantIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_tag.py) ---
            // def _get_default_variant_id(self):
            // return self.env['product.product'].browse(self.env.context.get('product_variant_id'))
            */
            return default;
        }

        public async Task<TEntity> GetDefaultWelcomeMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
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

        public async Task<TEntity> GetProgramTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def get_program_templates(self):
            // '''
            // Returns the templates to be used for promotional programs.
            // '''
            // ctx_menu_type = self.env.context.get('menu_type')
            // if ctx_menu_type == 'gift_ewallet':
            //     return {
            //         'gift_card': {
            //             'title': _("Gift Card"),
            //             'description': _("Sell Gift Cards, that allows to purchase products"),
            //             'icon': 'gift_card',
            //         },
            //         'ewallet': {
            //             'title': _("eWallet"),
            //             'description': _("Fill in your eWallet, to pay future orders"),
            //             'icon': 'ewallet',
            //         },
            //     }
            // return {
            //     'promotion': {
            //         'title': _("Promotional Program"),
            //         'description': _("Automatic promo: 10% off on orders higher than $50"),
            //         'icon': 'promotional_program',
            //     },
            //     'promo_code': {
            //         'title': _("Promo Code"),
            //         'description': _("Get 10% off on some products, with a code"),
            //         'icon': 'promo_code',
            //     },
            //     'buy_x_get_y': {
            //         'title': _("Buy X Get Y"),
            //         'description': _("Buy 2 products and get a third one for free"),
            //         'icon': '2_plus_1',
            //     },
            //     'next_order_coupons': {
            //         'title': _("Next Order Coupon"),
            //         'description': _("Send a coupon after an order, valid for next purchase"),
            //         'icon': 'coupons',
            //     },
            //     'loyalty': {
            //         'title': _("Loyalty Card"),
            //         'description': _("Win points with each purchase, and claim gifts"),
            //         'icon': 'loyalty_cards',
            //     },
            //     'coupons': {
            //         'title': _("Coupon"),
            //         'description': _("Generate and share unique coupons with your customers"),
            //         'icon': 'coupons',
            //     },
            //     'fidelity': {
            //         'title': _("Fidelity Card"),
            //         'description': _("Buy 10 products to get 10$ off on the 11th one"),
            //         'icon': 'fidelity_cards',
            //     },
            // }
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty_delivery, FILE: loyalty_program.py) ---
            // def get_program_templates(self):
            // # Override 'promotion' template to say free shipping
            // res = super().get_program_templates()
            // if 'promotion' in res:
            //     res['promotion']['description'] = _("Automatic promotion: free shipping on orders higher than $50")
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetTagsFirstCharInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tags) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
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

        public async Task<TEntity> GetTemplateValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def _get_template_values(self):
            // '''
            // Returns the values to create a program using the template keys defined above.
            // '''
            // program_type_defaults = self._program_type_default_values()
            // # For programs that require a product get the first sellable.
            // product = self.env['product.product'].search([('sale_ok', '=', True)], limit=1)
            // return {
            //     'gift_card': {
            //         'name': _('Gift Card'),
            //         'program_type': 'gift_card',
            //         **program_type_defaults['gift_card']
            //     },
            //     'ewallet': {
            //         'name': _('eWallet'),
            //         'program_type': 'ewallet',
            //         **program_type_defaults['ewallet'],
            //     },
            //     'loyalty': {
            //         'name': _('Loyalty Cards'),
            //         'program_type': 'loyalty',
            //         **program_type_defaults['loyalty'],
            //     },
            //     'coupons': {
            //         'name': _('Coupons'),
            //         'program_type': 'coupons',
            //         **program_type_defaults['coupons'],
            //     },
            //     'promotion': {
            //         'name': _('Promotional Program'),
            //         'program_type': 'promotion',
            //         **program_type_defaults['promotion'],
            //     },
            //     'promo_code': {
            //         'name': _('Discount code'),
            //         'program_type': 'promo_code',
            //         **program_type_defaults['promo_code'],
            //     },
            //     'buy_x_get_y': {
            //         'name': _('2+1 Free'),
            //         'program_type': 'buy_x_get_y',
            //         **program_type_defaults['buy_x_get_y'],
            //     },
            //     'next_order_coupons': {
            //         'name': _('Next Order Coupons'),
            //         'program_type': 'next_order_coupons',
            //         **program_type_defaults['next_order_coupons'],
            //     },
            //     'fidelity': {
            //         'name': _('Fidelity Cards'),
            //         'program_type': 'loyalty',
            //         'applies_on': 'both',
            //         'trigger': 'auto',
            //         'rule_ids': [(0, 0, {
            //             'reward_point_mode': 'unit',
            //             'product_ids': product,
            //         })],
            //         'reward_ids': [(0, 0, {
            //             'discount_mode': 'per_order',
            //             'required_points': 11,
            //             'discount_applicability': 'specific',
            //             'discount_product_ids': product,
            //             'discount': 10,
            //         })]
            //     },
            // }
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty_delivery, FILE: loyalty_program.py) ---
            // def _get_template_values(self):
            // res = super()._get_template_values()
            // if 'promotion' in res:
            //     res['promotion']['reward_ids'] = [(5, 0, 0), (0, 0, {
            //         'reward_type': 'shipping',
            //     })]
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetValidProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def _get_valid_products(self, products):
            // '''
            // Returns a dict containing the products that match per rule of the program
            // '''
            // rule_products = dict()
            // for rule in self.rule_ids:
            //     domain = rule._get_valid_product_domain()
            //     if domain:
            //         rule_products[rule] = products.filtered_domain(domain)
            //     elif not domain and rule.program_type != "gift_card":
            //         rule_products[rule] = products
            //     else:
            //         continue
            // return rule_products
            */
            return default;
        }

        public async Task<TEntity> GoToWebsiteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
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

        public async Task<TEntity> InverseMailTemplateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def _inverse_mail_template_id(self):
            // for program in self:
            //     if program.program_type not in ("gift_card", "ewallet"):
            //         continue
            //     if not program.mail_template_id:
            //         program.communication_plan_ids = [(5, 0, 0)]
            //     elif not program.communication_plan_ids:
            //         program.communication_plan_ids = self.env['loyalty.mail'].create({
            //             'program_id': program.id,
            //             'trigger': 'create',
            //             'mail_template_id': program.mail_template_id.id,
            //         })
            //     else:
            //         program.communication_plan_ids.write({
            //             'trigger': 'create',
            //             'mail_template_id': program.mail_template_id.id,
            //         })
            */
            return default;
        }

        public async Task<TEntity> InversePosReportPrintIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_program.py) ---
            // def _inverse_pos_report_print_id(self):
            // for program in self:
            //     if program.program_type not in ("gift_card", "ewallet"):
            //         continue
            // 
            //     if program.pos_report_print_id:
            //         if not program.mail_template_id:
            //             mail_template_label = program._fields.get('mail_template_id').get_description(self.env)['string']
            //             pos_report_print_label = program._fields.get('pos_report_print_id').get_description(self.env)['string']
            //             raise UserError(_(
            //                 "You must set '%(mail_template)s' before setting '%(report)s'.",
            //                 mail_template=mail_template_label,
            //                 report=pos_report_print_label,
            //             ))
            //         else:
            //             if not program.communication_plan_ids:
            //                 program.communication_plan_ids = self.env['loyalty.mail'].create({
            //                     'program_id': program.id,
            //                     'trigger': 'create',
            //                     'mail_template_id': program.mail_template_id.id,
            //                     'pos_report_print_id': program.pos_report_print_id.id,
            //                 })
            //             else:
            //                 program.communication_plan_ids.write({
            //                     'trigger': 'create',
            //                     'pos_report_print_id': program.pos_report_print_id.id,
            //                 })
            */
            return default;
        }

        public async Task<TEntity> InverseWebsitePublishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: mixins.py) ---
            // def _inverse_website_published(self):
            // for record in self:
            //     record.is_published = record.website_published
            */
            return default;
        }

        public async Task<TEntity> LoadPosDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_program.py) ---
            // def _load_pos_data_domain(self, data):
            // config_id = self.env['pos.config'].browse(data['pos.config']['data'][0]['id'])
            // return [('id', 'in', config_id._get_program_ids().ids)]
            */
            return default;
        }

        public async Task<TEntity> LoadPosDataFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid config_id) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_program.py) ---
            // def _load_pos_data_fields(self, config_id):
            // return [
            //     'name', 'trigger', 'applies_on', 'program_type', 'pricelist_ids', 'date_from',
            //     'date_to', 'limit_usage', 'max_usage', 'total_order_count', 'is_nominative',
            //     'portal_visible', 'portal_point_name', 'trigger_product_ids', 'rule_ids', 'reward_ids'
            // ]
            */
            return default;
        }

        public async Task<TEntity> LoadPosDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_program.py) ---
            // def _load_pos_data(self, data):
            // domain = self._load_pos_data_domain(data)
            // fields = self._load_pos_data_fields(data['pos.config']['data'][0]['id'])
            // return {
            //     'data': self.sudo().search_read(domain, fields, load=False),
            //     'fields': fields,
            // }
            */
            return default;
        }

        public async Task<TEntity> MessagePostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
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
            */
            return default;
        }

        public async Task<TEntity> OpenLoyaltyCardsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def action_open_loyalty_cards(self):
            // self.ensure_one()
            // action = self.env['ir.actions.act_window']._for_xml_id("loyalty.loyalty_card_action")
            // action['name'] = self._program_items_name()[self.program_type]
            // action['display_name'] = action['name']
            // action['context'] = {
            //     'program_type': self.program_type,
            //     'program_item_name': self._program_items_name()[self.program_type],
            //     'default_program_id': self.id,
            //     # For the wizard
            //     'default_mode': self.program_type == 'ewallet' and 'selected' or 'anonymous',
            // }
            // return action
            */
            return default;
        }

        public async Task<TEntity> OpenWebsiteUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
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
            */
            return default;
        }

        public async Task<TEntity> ProgramItemsNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def _program_items_name(self):
            // return {
            //     'coupons': _('Coupons'),
            //     'promotion': _('Promos'),
            //     'gift_card': _('Gift Cards'),
            //     'loyalty': _('Loyalty Cards'),
            //     'ewallet': _('eWallets'),
            //     'promo_code': _('Discounts'),
            //     'buy_x_get_y': _('Promos'),
            //     'next_order_coupons': _('Coupons'),
            // }
            */
            return default;
        }

        public async Task<TEntity> ProgramShareAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_loyalty, FILE: loyalty_program.py) ---
            // def action_program_share(self):
            // self.ensure_one()
            // return self.env['coupon.share'].create_share_action(program=self)
            */
            return default;
        }

        public async Task<TEntity> ProgramTypeDefaultValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def _program_type_default_values(self):
            // # All values to change when program_type changes
            // # NOTE: any field used in `rule_ids`, `reward_ids` and `communication_plan_ids` MUST be present in the kanban view for it to work properly.
            // first_sale_product = self.env['product.product'].search([('company_id', 'in', [False, self.env.company.id]), ('sale_ok', '=', True)], limit=1)
            // return {
            //     'coupons': {
            //         'applies_on': 'current',
            //         'trigger': 'with_code',
            //         'portal_visible': False,
            //         'portal_point_name': _('Coupon point(s)'),
            //         'rule_ids': [(5, 0, 0)],
            //         'reward_ids': [(5, 0, 0), (0, 0, {
            //             'required_points': 1,
            //             'discount': 10,
            //         })],
            //         'communication_plan_ids': [(5, 0, 0), (0, 0, {
            //             'trigger': 'create',
            //             'mail_template_id': (self.env.ref('loyalty.mail_template_loyalty_card', raise_if_not_found=False) or self.env['mail.template']).id,
            //         })],
            //     },
            //     'promotion': {
            //         'applies_on': 'current',
            //         'trigger': 'auto',
            //         'portal_visible': False,
            //         'portal_point_name': _('Promo point(s)'),
            //         'rule_ids': [(5, 0, 0), (0, 0, {
            //             'reward_point_amount': 1,
            //             'reward_point_mode': 'order',
            //             'minimum_amount': 50,
            //             'minimum_qty': 0,
            //         })],
            //         'reward_ids': [(5, 0, 0), (0, 0, {
            //             'required_points': 1,
            //             'discount': 10,
            //         })],
            //         'communication_plan_ids': [(5, 0, 0)],
            //     },
            //     'gift_card': {
            //         'applies_on': 'future',
            //         'trigger': 'auto',
            //         'portal_visible': True,
            //         'portal_point_name': self.env.company.currency_id.symbol,
            //         'rule_ids': [(5, 0, 0), (0, 0, {
            //             'reward_point_amount': 1,
            //             'reward_point_mode': 'money',
            //             'reward_point_split': True,
            //             'product_ids': self.env.ref('loyalty.gift_card_product_50', raise_if_not_found=False),
            //             'minimum_qty': 0,
            //         })],
            //         'reward_ids': [(5, 0, 0), (0, 0, {
            //             'reward_type': 'discount',
            //             'discount_mode': 'per_point',
            //             'discount': 1,
            //             'discount_applicability': 'order',
            //             'required_points': 1,
            //             'description': _('Gift Card'),
            //         })],
            //         'communication_plan_ids': [(5, 0, 0), (0, 0, {
            //             'trigger': 'create',
            //             'mail_template_id': (self.env.ref('loyalty.mail_template_gift_card', raise_if_not_found=False) or self.env['mail.template']).id,
            //         })],
            //     },
            //     'loyalty': {
            //         'applies_on': 'both',
            //         'trigger': 'auto',
            //         'portal_visible': True,
            //         'portal_point_name': _('Loyalty point(s)'),
            //         'rule_ids': [(5, 0, 0), (0, 0, {
            //             'reward_point_mode': 'money',
            //         })],
            //         'reward_ids': [(5, 0, 0), (0, 0, {
            //             'discount': 5,
            //             'required_points': 200,
            //         })],
            //         'communication_plan_ids': [(5, 0, 0)],
            //     },
            //     'ewallet': {
            //         'trigger': 'auto',
            //         'applies_on': 'future',
            //         'portal_visible': True,
            //         'portal_point_name': self.env.company.currency_id.symbol,
            //         'rule_ids': [(5, 0, 0), (0, 0, {
            //             'reward_point_amount': '1',
            //             'reward_point_mode': 'money',
            //             'reward_point_split': False,
            //             'product_ids': self.env.ref('loyalty.ewallet_product_50', raise_if_not_found=False),
            //         })],
            //         'reward_ids': [(5, 0, 0), (0, 0, {
            //             'reward_type': 'discount',
            //             'discount_mode': 'per_point',
            //             'discount': 1,
            //             'discount_applicability': 'order',
            //             'required_points': 1,
            //             'description': _('eWallet'),
            //         })],
            //         'communication_plan_ids': [(5, 0, 0)],
            //     },
            //     'promo_code': {
            //         'applies_on': 'current',
            //         'trigger': 'with_code',
            //         'portal_visible': False,
            //         'portal_point_name': _('Discount point(s)'),
            //         'rule_ids': [(5, 0, 0), (0, 0, {
            //             'mode': 'with_code',
            //             'code': 'PROMO_CODE_' + str(uuid4())[:4], # We should try not to trigger any unicity constraint
            //             'minimum_qty': 0,
            //         })],
            //         'reward_ids': [(5, 0, 0), (0, 0, {
            //             'discount_applicability': 'specific',
            //             'discount_product_ids': first_sale_product,
            //             'discount_mode': 'percent',
            //             'discount': 10,
            //         })],
            //         'communication_plan_ids': [(5, 0, 0)],
            //     },
            //     'buy_x_get_y': {
            //         'applies_on': 'current',
            //         'trigger': 'auto',
            //         'portal_visible': False,
            //         'portal_point_name': _('Credit(s)'),
            //         'rule_ids': [(5, 0, 0), (0, 0, {
            //             'reward_point_mode': 'unit',
            //             'product_ids': first_sale_product,
            //             'minimum_qty': 2,
            //         })],
            //         'reward_ids': [(5, 0, 0), (0, 0, {
            //             'reward_type': 'product',
            //             'reward_product_id': first_sale_product.id,
            //             'required_points': 2,
            //         })],
            //         'communication_plan_ids': [(5, 0, 0)],
            //     },
            //     'next_order_coupons': {
            //         'applies_on': 'future',
            //         'trigger': 'auto',
            //         'portal_visible': True,
            //         'portal_point_name': _('Coupon point(s)'),
            //         'rule_ids': [(5, 0, 0), (0, 0, {
            //             'minimum_amount': 100,
            //             'minimum_qty': 0,
            //         })],
            //         'reward_ids': [(5, 0, 0), (0, 0, {
            //             'reward_type': 'discount',
            //             'discount_mode': 'percent',
            //             'discount': 15,
            //             'discount_applicability': 'order',
            //         })],
            //         'communication_plan_ids': [(5, 0, 0), (0, 0, {
            //             'trigger': 'create',
            //             'mail_template_id': (
            //                 self.env.ref('loyalty.mail_template_loyalty_card', raise_if_not_found=False)
            //                 or self.env['mail.template']
            //             ).id,
            //         })],
            //     },
            // }
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty_delivery, FILE: loyalty_program.py) ---
            // def _program_type_default_values(self):
            // res = super()._program_type_default_values()
            // # Add a loyalty reward for free shipping
            // if 'loyalty' in res:
            //     res['loyalty']['reward_ids'].append((0, 0, {
            //         'reward_type': 'shipping',
            //         'required_points': 100,
            //     }))
            // return res
            */
            return default;
        }

        public async Task<TEntity> SearchGetDetailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website, object order, object options) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
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
            */
            return default;
        }

        public async Task<TEntity> SearchProductIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: product_tag.py) ---
            // def _search_product_ids(self, operator, operand):
            // if operator in expression.NEGATIVE_TERM_OPERATORS:
            //     return [('product_template_ids.product_variant_ids', operator, operand), ('product_product_ids', operator, operand)]
            // return ['|', ('product_template_ids.product_variant_ids', operator, operand), ('product_product_ids', operator, operand)]
            */
            return default;
        }

        public async Task<TEntity> SearchRenderResultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fetch_fields, object mapping, object icon, object limit) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py) ---
            // def _search_render_results(self, fetch_fields, mapping, icon, limit):
            // results_data = super()._search_render_results(fetch_fields, mapping, icon, limit)
            // for data in results_data:
            //     data['url'] = '/blog/%s' % data['id']
            // return results_data
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
            */
            return default;
        }

        public async Task<TEntity> SearchWebsitePublishedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
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

        public async Task<TEntity> SetDefaultFaqInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def _set_default_faq(self):
            // for forum in self:
            //     forum.faq = self.env['ir.ui.view']._render_template('website_forum.faq_accordion', {"forum": forum})
            */
            return default;
        }

        public async Task<TEntity> TagToWriteValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tags) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
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

        public async Task<TEntity> ToggleActiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def toggle_active(self):
            // res = super().toggle_active()
            // # Propagate active state to children
            // for program in self.with_context(active_test=False):
            //     program.rule_ids.active = program.active
            //     program.reward_ids.active = program.active
            //     program.communication_plan_ids.active = program.active
            //     program.reward_ids.with_context(active_test=True).discount_line_product_id.active = program.active
            // return res
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py) ---
            // def unlink(self):
            // self.env['website'].sudo()._update_forum_count()
            // return super().unlink()
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptActiveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def _unlink_except_active(self):
            // if any(program.active for program in self):
            //     raise UserError(_('You can not delete a program in an active state'))
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
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
            */
            return default;
        }
    }
}