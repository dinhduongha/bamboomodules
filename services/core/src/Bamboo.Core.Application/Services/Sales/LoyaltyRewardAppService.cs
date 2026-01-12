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
    public class LoyaltyRewardAppService : GenericApplicationService<LoyaltyReward>, ILoyaltyRewardAppService
    {
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public LoyaltyRewardAppService(IRepository<LoyaltyReward, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        protected async Task<LoyaltyReward> CheckRewardProductIdNoComboInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py) ---
            // def _check_reward_product_id_no_combo(self):
            // if any(reward.reward_product_id.type == 'combo' for reward in self):
            //     raise ValidationError(_("A reward product can't be of type \"combo\"."))
            */
            return default;
        }

        protected async Task<LoyaltyReward> ComputeAllDiscountProductIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py) ---
            // def _compute_all_discount_product_ids(self):
            // compute_all_discount_product = self.env['ir.config_parameter'].sudo().get_param('loyalty.compute_all_discount_product_ids', 'enabled')
            // for reward in self:
            //     if compute_all_discount_product == 'enabled':
            //         reward.all_discount_product_ids = self.env['product.product'].search(reward._get_discount_product_domain())
            //     else:
            //         reward.all_discount_product_ids = self.env['product.product']
            */
            return default;
        }

        protected async Task<LoyaltyReward> ComputeDescriptionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py) ---
            // def _compute_description(self):
            // for reward in self:
            //     reward_string = ""
            //     if reward.program_type == 'gift_card':
            //         reward_string = _("Gift Card")
            //     elif reward.program_type == 'ewallet':
            //         reward_string = _("eWallet")
            //     elif reward.reward_type == 'product':
            //         products = reward.reward_product_ids
            //         if len(products) == 0:
            //             reward_string = _("Free Product")
            //         elif len(products) == 1:
            //             reward_string = _("Free Product - %s", reward.reward_product_id.with_context(display_default_code=False).display_name)
            //         else:
            //             reward_string = _("Free Product - [%s]", ', '.join(products.with_context(display_default_code=False).mapped('display_name')))
            //     elif reward.reward_type == 'discount':
            //         format_string = "%(amount)g %(symbol)s"
            //         if reward.currency_id.position == 'before':
            //             format_string = "%(symbol)s %(amount)g"
            //         formatted_amount = format_string % {'amount': reward.discount, 'symbol': reward.currency_id.symbol}
            //         if reward.discount_mode == 'percent':
            //             reward_string = _("%g%% on ", reward.discount)
            //         elif reward.discount_mode == 'per_point':
            //             reward_string = _("%s per point on ", formatted_amount)
            //         elif reward.discount_mode == 'per_order':
            //             reward_string = _("%s on ", formatted_amount)
            //         if reward.discount_applicability == 'order':
            //             reward_string += _("your order")
            //         elif reward.discount_applicability == 'cheapest':
            //             reward_string += _("the cheapest product")
            //         elif reward.discount_applicability == 'specific':
            //             product_available = self.env['product.product'].search(reward._get_discount_product_domain(), limit=2)
            //             if len(product_available) == 1:
            //                 reward_string += product_available.with_context(display_default_code=False).display_name
            //             else:
            //                 reward_string += _("specific products")
            //         if reward.discount_max_amount:
            //             format_string = "%(amount)g %(symbol)s"
            //             if reward.currency_id.position == 'before':
            //                 format_string = "%(symbol)s %(amount)g"
            //             formatted_amount = format_string % {'amount': reward.discount_max_amount, 'symbol': reward.currency_id.symbol}
            //             reward_string += _(" (Max %s)", formatted_amount)
            //     reward.description = reward_string
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty_delivery, FILE: loyalty_reward.py) ---
            // def _compute_description(self):
            // shipping_rewards = self.filtered(lambda r: r.reward_type == 'shipping')
            // super(LoyaltyReward, self - shipping_rewards)._compute_description()
            // shipping_rewards.description = _('Free shipping')
            // for reward in shipping_rewards:
            //     if reward.discount_max_amount:
            //         format_string = '%(amount)g %(symbol)s'
            //         if reward.currency_id.position == 'before':
            //             format_string = '%(symbol)s %(amount)g'
            //         formatted_amount = format_string % {'amount': reward.discount_max_amount, 'symbol': reward.currency_id.symbol}
            //         reward.description += _(' (Max %s)', formatted_amount)
            */
            return default;
        }

        protected async Task<LoyaltyReward> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py) ---
            // def _compute_display_name(self):
            // for reward in self:
            //     reward.display_name = f"{reward.program_id.name} - {reward.description}"
            */
            return default;
        }

        protected async Task<LoyaltyReward> ComputeIsGlobalDiscountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py) ---
            // def _compute_is_global_discount(self):
            // for reward in self:
            //     reward.is_global_discount = (
            //         reward.reward_type == 'discount'
            //         and reward.discount_applicability == 'order'
            //         and reward.discount_mode in ['per_order', 'percent']
            //     )
            */
            return default;
        }

        protected async Task<LoyaltyReward> ComputeMultiProductInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py) ---
            // def _compute_multi_product(self):
            // for reward in self:
            //     products = reward.reward_product_id + reward.reward_product_tag_id.product_ids.filtered(
            //         lambda product: product.type != 'combo'
            //     )
            //     reward.multi_product = reward.reward_type == 'product' and len(products) > 1
            //     reward.reward_product_ids = reward.reward_type == 'product' and products or self.env['product.product']
            */
            return default;
        }

        protected async Task<LoyaltyReward> ComputeRewardProductDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py) ---
            // def _compute_reward_product_domain(self):
            // compute_all_discount_product = self.env['ir.config_parameter'].sudo().get_param('loyalty.compute_all_discount_product_ids', 'enabled')
            // for reward in self:
            //     if compute_all_discount_product == 'enabled':
            //         reward.reward_product_domain = "null"
            //     else:
            //         reward.reward_product_domain = json.dumps(list(reward._get_discount_product_domain()))
            */
            return default;
        }

        protected async Task<LoyaltyReward> ComputeRewardProductUomIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py) ---
            // def _compute_reward_product_uom_id(self):
            // for reward in self:
            //     reward.reward_product_uom_id = reward.reward_product_ids.product_tmpl_id.uom_id[:1]
            */
            return default;
        }

        protected async Task<LoyaltyReward> ComputeUserHasDebugInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py) ---
            // def _compute_user_has_debug(self):
            // self.user_has_debug = self.env.user.has_group('base.group_no_one')
            */
            return default;
        }

        protected async Task<LoyaltyReward> CreateMissingDiscountLineProductsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py) ---
            // def _create_missing_discount_line_products(self):
            // # Make sure we create the product that will be used for our discounts
            // rewards = self.filtered(lambda r: not r.discount_line_product_id)
            // products = self.env['product.product'].create(rewards._get_discount_product_values())
            // for reward, product in zip(rewards, products):
            //     reward.discount_line_product_id = product
            */
            return default;
        }

        protected async Task<LoyaltyReward> FindAllCategoryChildrenInternalAsync(Guid category_id, List<Guid> child_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py) ---
            // def _find_all_category_children(self, category_id, child_ids):
            // if len(category_id.child_id) > 0:
            //     for child_id in category_id.child_id:
            //         child_ids.append(child_id.id)
            //         self._find_all_category_children(child_id, child_ids)
            // return child_ids
            */
            return default;
        }

        protected async Task<LoyaltyReward> GetActiveProductsDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py) ---
            // def _get_active_products_domain(self):
            // return [
            //     '|',
            //         ('reward_type', '!=', 'product'),
            //         '&',
            //             ('reward_type', '=', 'product'),
            //             '|',
            //                 '&',
            //                     ('reward_product_tag_id', '=', False),
            //                     ('reward_product_id.active', '=', True),
            //                 '&',
            //                     ('reward_product_tag_id', '!=', False),
            //                     ('reward_product_ids.active', '=', True)
            // ]
            */
            return default;
        }

        protected async Task<LoyaltyReward> GetDiscountModeSelectInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py) ---
            // def _get_discount_mode_select(self):
            // # The value is provided in the loyalty program's view since we may not have a program_id yet
            // #  and makes sure to display the currency related to the program instead of the company's.
            // symbol = self.env.context.get('currency_symbol', self.env.company.currency_id.symbol)
            // return [
            //     ('percent', "%"),
            //     ('per_order', symbol),
            //     ('per_point', _("%s per point", symbol)),
            // ]
            */
            return default;
        }

        protected async Task<LoyaltyReward> GetDiscountProductDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py) ---
            // def _get_discount_product_domain(self):
            // self.ensure_one()
            // constrains = []
            // if self.discount_product_ids:
            //     constrains.append([('id', 'in', self.discount_product_ids.ids)])
            // if self.discount_product_category_id:
            //     product_category_ids = self._find_all_category_children(self.discount_product_category_id, [])
            //     product_category_ids.append(self.discount_product_category_id.id)
            //     constrains.append([('categ_id', 'in', product_category_ids)])
            // if self.discount_product_tag_id:
            //     constrains.append([('all_product_tag_ids', 'in', self.discount_product_tag_id.id)])
            // domain = Domain.OR(constrains) if constrains else Domain.TRUE
            // if self.discount_product_domain and self.discount_product_domain != '[]':
            //     domain &= Domain(ast.literal_eval(self.discount_product_domain))
            // return domain
            */
            return default;
        }

        protected async Task<LoyaltyReward> GetDiscountProductValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py) ---
            // def _get_discount_product_values(self):
            // return [{
            //     'name': reward.description,
            //     'type': 'service',
            //     'sale_ok': False,
            //     'purchase_ok': False,
            //     'lst_price': 0,
            // } for reward in self]
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_reward.py) ---
            // def _get_discount_product_values(self):
            // res = super()._get_discount_product_values()
            // for vals in res:
            //     vals.update({'taxes_id': False})
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: loyalty_reward.py) ---
            // def _get_discount_product_values(self):
            // res = super()._get_discount_product_values()
            // for vals in res:
            //     vals.update({
            //         'taxes_id': False,
            //         'supplier_taxes_id': False,
            //         'invoice_policy': 'order',
            //     })
            // return res
            */
            return default;
        }

        protected async Task<LoyaltyReward> GetRewardProductDomainFieldsInternalAsync(object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_reward.py) ---
            // def _get_reward_product_domain_fields(self, config):
            // fields = set()
            // search_domain = [('program_id', 'in', config._get_program_ids().ids)]
            // domains = self.search_read(search_domain, fields=['reward_product_domain'], load=False)
            // for domain in filter(lambda d: d['reward_product_domain'] != "null", domains):
            //     domain = json.loads(domain['reward_product_domain'])
            //     for condition in self._parse_domain(domain).values():
            //         field_name, _, _ = condition
            //         fields.add(field_name)
            // return fields
            */
            return default;
        }

        protected async Task<LoyaltyReward> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_reward.py) ---
            // def _load_pos_data_domain(self, data, config):
            // return [('program_id', 'in', config._get_program_ids().ids)]
            */
            return default;
        }

        protected async Task<LoyaltyReward> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_reward.py) ---
            // def _load_pos_data_fields(self, config):
            // return ['description', 'program_id', 'reward_type', 'required_points', 'clear_wallet', 'currency_id',
            //         'discount', 'discount_mode', 'discount_applicability', 'all_discount_product_ids', 'is_global_discount',
            //         'discount_max_amount', 'discount_line_product_id', 'reward_product_id',
            //         'multi_product', 'reward_product_ids', 'reward_product_qty', 'reward_product_uom_id', 'reward_product_domain']
            */
            return default;
        }

        protected async Task<LoyaltyReward> LoadPosDataReadInternalAsync(object records, object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_reward.py) ---
            // def _load_pos_data_read(self, records, config):
            // read_records = super()._load_pos_data_read(records, config)
            // for reward in read_records:
            //     reward['reward_product_domain'] = self._replace_ilike_with_in(reward['reward_product_domain'])
            // return read_records
            */
            return default;
        }

        protected async Task<LoyaltyReward> ParseDomainInternalAsync(object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_reward.py) ---
            // def _parse_domain(self, domain):
            // parsed_domain = {}
            // 
            // for index, condition in enumerate(domain):
            //     if isinstance(condition, (list, tuple)) and len(condition) == 3:
            //         parsed_domain[index] = condition
            // return parsed_domain
            */
            return default;
        }

        protected async Task<LoyaltyReward> ReplaceIlikeWithInInternalAsync(object domain_str)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_reward.py) ---
            // def _replace_ilike_with_in(self, domain_str):
            // if domain_str == "null":
            //     return domain_str
            // 
            // domain = json.loads(domain_str)
            // 
            // for index, condition in self._parse_domain(domain).items():
            //     field_name, operator, value = condition
            //     field = self.env['product.product']._fields.get(field_name)
            // 
            //     if field and field.type == 'many2one' and operator in ('ilike', 'not ilike'):
            //         comodel = self.env[field.comodel_name]
            //         matching_ids = list(comodel._search([('display_name', 'ilike', value)]))
            // 
            //         new_operator = 'in' if operator == 'ilike' else 'not in'
            //         domain[index] = [field_name, new_operator, matching_ids]
            // 
            // return json.dumps(domain)
            */
            return default;
        }

        protected async Task<LoyaltyReward> SearchRewardProductIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py) ---
            // def _search_reward_product_ids(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // return [
            //     '&', ('reward_type', '=', 'product'),
            //     '|', ('reward_product_id', operator, value),
            //     ('reward_product_tag_id.product_ids', operator, value)
            // ]
            */
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py) ---
            // def unlink(self):
            // programs = self.program_id
            // res = super().unlink()
            // # Not guaranteed to trigger the constraint
            // programs._constrains_reward_ids()
            // return res
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_reward.py) ---
            // def unlink(self):
            // if len(self) == 1 and self.env['pos.order.line'].sudo().search_count([('reward_id', 'in', self.ids)], limit=1):
            //     return self.action_archive()
            // return super().unlink()
            --- ODOO METHOD SOURCE (MODULE: sale_loyalty, FILE: loyalty_reward.py) ---
            // def unlink(self):
            // if len(self) == 1 and self.env['sale.order.line'].sudo().search_count([('reward_id', 'in', self.ids)], limit=1):
            //     return self.action_archive()
            // return super().unlink()
            */
            return await base.UnlinkAsync(ids);
        }
    }
}