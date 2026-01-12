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
    [Module("Loyalty", Category = "Sales", Depends = new[] { "product", "portal", "account" })]
    public class LoyaltyProgramAppService : GenericApplicationService<LoyaltyProgram>, ILoyaltyProgramAppService
    {
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        private readonly IWebsiteMultiMixinAppService _websiteMultiMixinAppService;
        public LoyaltyProgramAppService(IRepository<LoyaltyProgram, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IPosLoadMixinAppService posLoadMixinAppService, IWebsiteMultiMixinAppService websiteMultiMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
            _websiteMultiMixinAppService = websiteMultiMixinAppService;
        }

        protected async Task<LoyaltyProgram> CheckDateFromDateToInternalAsync()
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

        protected async Task<LoyaltyProgram> CheckPricelistCurrencyInternalAsync()
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

        protected async Task<LoyaltyProgram> ComputeCouponCountDisplayInternalAsync()
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

        protected async Task<LoyaltyProgram> ComputeCouponCountInternalAsync()
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

        protected async Task<LoyaltyProgram> ComputeCurrencyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def _compute_currency_id(self):
            // for program in self:
            //     program.currency_id = program.company_id.currency_id or program.currency_id
            */
            return default;
        }

        protected async Task<LoyaltyProgram> ComputeFromProgramTypeInternalAsync()
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

        protected async Task<LoyaltyProgram> ComputeIsNominativeInternalAsync()
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

        protected async Task<LoyaltyProgram> ComputeIsPaymentProgramInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def _compute_is_payment_program(self):
            // for program in self:
            //     program.is_payment_program = program.program_type in ('gift_card', 'ewallet')
            */
            return default;
        }

        protected async Task<LoyaltyProgram> ComputeMailTemplateIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def _compute_mail_template_id(self):
            // for program in self:
            //     program.mail_template_id = program.communication_plan_ids.mail_template_id[:1]
            */
            return default;
        }

        protected async Task<LoyaltyProgram> ComputeOrderCountInternalAsync()
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

        protected async Task<LoyaltyProgram> ComputePaymentProgramDiscountProductIdInternalAsync()
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

        protected async Task<LoyaltyProgram> ComputePortalPointNameInternalAsync()
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

        protected async Task<LoyaltyProgram> ComputePosConfigIdsInternalAsync()
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

        protected async Task<LoyaltyProgram> ComputePosOrderCountInternalAsync()
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
            // self.env.cr.execute(query, (self.ids,))
            // res = self.env.cr.dictfetchall()
            // res = {k['id']: k['sum'] for k in res}
            // 
            // for rec in self:
            //     rec.pos_order_count = res.get(rec.id) or 0
            */
            return default;
        }

        protected async Task<LoyaltyProgram> ComputePosReportPrintIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_program.py) ---
            // def _compute_pos_report_print_id(self):
            // for program in self:
            //     program.pos_report_print_id = program.communication_plan_ids.pos_report_print_id[:1]
            */
            return default;
        }

        protected async Task<LoyaltyProgram> ComputeShowNonPublishedProductWarningInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_loyalty, FILE: loyalty_program.py) ---
            // def _compute_show_non_published_product_warning(self):
            // for program in self:
            //     program.show_non_published_product_warning = (
            //         program.program_type == 'ewallet'
            //         and any(not product.website_published for product in program.trigger_product_ids)
            //     )
            */
            return default;
        }

        protected async Task<LoyaltyProgram> ComputeTotalOrderCountInternalAsync()
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

        protected async Task<LoyaltyProgram> ConstrainsRewardIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def _constrains_reward_ids(self):
            // if self.env.context.get('loyalty_skip_reward_check'):
            //     return
            // if any(not program.reward_ids for program in self):
            //     raise ValidationError(_("A program must have at least one reward."))
            */
            return default;
        }

        public async Task<LoyaltyProgram> CreateFromTemplateAsync(Guid id, LoyaltyProgramCreateFromTemplateRequestDto input)
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
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<LoyaltyProgram> GetProgramTemplatesAsync(Guid id)
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
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<LoyaltyProgram> GetTemplateValuesInternalAsync()
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
            //         'name': _("Gift Card"),
            //         'program_type': 'gift_card',
            //         **program_type_defaults['gift_card']
            //     },
            //     'ewallet': {
            //         'name': _("eWallet"),
            //         'program_type': 'ewallet',
            //         **program_type_defaults['ewallet'],
            //     },
            //     'loyalty': {
            //         'name': _("Loyalty Cards"),
            //         'program_type': 'loyalty',
            //         **program_type_defaults['loyalty'],
            //     },
            //     'coupons': {
            //         'name': _("Coupons"),
            //         'program_type': 'coupons',
            //         **program_type_defaults['coupons'],
            //     },
            //     'promotion': {
            //         'name': _("Promotional Program"),
            //         'program_type': 'promotion',
            //         **program_type_defaults['promotion'],
            //     },
            //     'promo_code': {
            //         'name': _("Discount code"),
            //         'program_type': 'promo_code',
            //         **program_type_defaults['promo_code'],
            //     },
            //     'buy_x_get_y': {
            //         'name': _("2+1 Free"),
            //         'program_type': 'buy_x_get_y',
            //         **program_type_defaults['buy_x_get_y'],
            //     },
            //     'next_order_coupons': {
            //         'name': _("Next Order Coupons"),
            //         'program_type': 'next_order_coupons',
            //         **program_type_defaults['next_order_coupons'],
            //     },
            //     'fidelity': {
            //         'name': _("Fidelity Cards"),
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

        protected async Task<LoyaltyProgram> GetValidProductsInternalAsync(object products)
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
            //     elif not domain and rule.program_type != 'gift_card':
            //         rule_products[rule] = products
            //     else:
            //         continue
            // return rule_products
            */
            return default;
        }

        protected async Task<LoyaltyProgram> InverseMailTemplateIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def _inverse_mail_template_id(self):
            // for program in self:
            //     if program.program_type not in ('gift_card', 'ewallet'):
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

        protected async Task<LoyaltyProgram> InversePosReportPrintIdInternalAsync()
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

        protected async Task<LoyaltyProgram> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_program.py) ---
            // def _load_pos_data_domain(self, data, config):
            // return [('id', 'in', config._get_program_ids().ids)]
            */
            return default;
        }

        protected async Task<LoyaltyProgram> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_program.py) ---
            // def _load_pos_data_fields(self, config):
            // return [
            //     'name', 'trigger', 'applies_on', 'program_type', 'pricelist_ids', 'date_from',
            //     'date_to', 'limit_usage', 'max_usage', 'total_order_count', 'is_nominative',
            //     'portal_visible', 'portal_point_name', 'trigger_product_ids', 'rule_ids', 'reward_ids'
            // ]
            */
            return default;
        }

        protected async Task<LoyaltyProgram> LoadPosDataReadInternalAsync(object records, object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_program.py) ---
            // def _load_pos_data_read(self, records, config):
            // return super()._load_pos_data_read(records.sudo(), config)
            */
            return default;
        }

        public async Task<LoyaltyProgram> OpenLoyaltyCardsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def action_open_loyalty_cards(self):
            // self.ensure_one()
            // action = self.env['ir.actions.act_window']._for_xml_id('loyalty.loyalty_card_action')
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
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<LoyaltyProgram> ProgramItemsNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def _program_items_name(self):
            // return {
            //     'coupons': _("Coupons"),
            //     'promotion': _("Promos"),
            //     'gift_card': _("Gift Cards"),
            //     'loyalty': _("Loyalty Cards"),
            //     'ewallet': _("eWallets"),
            //     'promo_code': _("Discounts"),
            //     'buy_x_get_y': _("Promos"),
            //     'next_order_coupons': _("Coupons"),
            // }
            */
            return default;
        }

        public async Task<LoyaltyProgram> ProgramShareAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_loyalty, FILE: loyalty_program.py) ---
            // def action_program_share(self):
            // self.ensure_one()
            // return self.env['coupon.share'].create_share_action(program=self)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<LoyaltyProgram> ProgramTypeDefaultValuesInternalAsync()
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
            //         'portal_point_name': _("Coupon point(s)"),
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
            //         'portal_point_name': _("Promo point(s)"),
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
            //             'description': _("Gift Card"),
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
            //         'portal_point_name': _("Loyalty point(s)"),
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
            //             'description': _("eWallet"),
            //         })],
            //         'communication_plan_ids': [(5, 0, 0)],
            //     },
            //     'promo_code': {
            //         'applies_on': 'current',
            //         'trigger': 'with_code',
            //         'portal_visible': False,
            //         'portal_point_name': _("Discount point(s)"),
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
            //         'portal_point_name': _("Credit(s)"),
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
            //         'portal_point_name': _("Coupon point(s)"),
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

        protected async Task<LoyaltyProgram> UnlinkExceptActiveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py) ---
            // def _unlink_except_active(self):
            // if any(program.active for program in self):
            //     raise UserError(_("You can not delete a program in an active state"))
            */
            return default;
        }

        protected async Task<LoyaltyProgram> UnrelevantRecordsInternalAsync(object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_program.py) ---
            // def _unrelevant_records(self, config):
            // valid_record = config._get_program_ids()
            // return self.filtered(lambda record: record.id not in valid_record.ids).ids
            */
            return default;
        }
    }
}