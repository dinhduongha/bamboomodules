using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Services;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;

namespace Bamboo.Core.Application.Services
{
    [Module("PointOfSale", Depends = new[] { "stock_account", "barcodes", "web_editor", "digest", "phone_validation" })]
    public class PosConfigAppService : GenericApplicationService<PosConfig>, IPosConfigAppService
    {
        private readonly IPosBusMixinAppService _posBusMixinAppService;
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public PosConfigAppService(IRepository<PosConfig, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IPosBusMixinAppService posBusMixinAppService, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _posBusMixinAppService = posBusMixinAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        protected async Task<PosConfig> ActionToOpenUiInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _action_to_open_ui(self):
            // if not self.current_session_id:
            //     self.env['pos.session'].create({'user_id': self.env.uid, 'config_id': self.id})
            // path = '/pos/web' if self._force_http() else '/pos/ui'
            // pos_url = path + '?config_id=%d&from_backend=True' % self.id
            // debug = request and request.session.debug
            // if debug:
            //     pos_url += '&debug=%s' % debug
            // return {
            //     'type': 'ir.actions.act_url',
            //     'url': pos_url,
            //     'target': 'self',
            // }
            */
            return default;
        }

        protected async Task<PosConfig> AddTrustedConfigIdInternalAsync(Guid config_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _add_trusted_config_id(self, config_id):
            // self.trusted_config_ids += config_id
            */
            return default;
        }

        protected async Task<PosConfig> CheckAdyenAskCustomerForTipInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_adyen, FILE: pos_config.py) ---
            // def _check_adyen_ask_customer_for_tip(self):
            // for config in self:
            //     if config.adyen_ask_customer_for_tip and (not config.tip_product_id or not config.iface_tipproduct):
            //         raise ValidationError(_("Please configure a tip product for POS %s to support tipping with Adyen.", config.name))
            */
            return default;
        }

        protected async Task<PosConfig> CheckBeforeCreatingNewSessionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_before_creating_new_session(self):
            // self._check_company_has_template()
            // self._check_pricelists()
            // self._check_company_payment()
            // self._check_currencies()
            // self._check_profit_loss_cash_journal()
            // self._check_payment_method_ids()
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: pos_config.py) ---
            // def _check_before_creating_new_session(self):
            // self.ensure_one()
            // # Check validity of programs before opening a new session
            // invalid_reward_products_msg = ''
            // for reward in self._get_program_ids().reward_ids:
            //     if reward.reward_type == 'product':
            //         for product in reward.reward_product_ids:
            //             if product.available_in_pos:
            //                 continue
            //             invalid_reward_products_msg += "\n\t"
            //             invalid_reward_products_msg += _(
            //                 "Program: %(name)s, Reward Product: `%(reward_product)s`",
            //                 name=reward.program_id.name,
            //                 reward_product=product.name,
            //             )
            // gift_card_programs = self._get_program_ids().filtered(lambda p: p.program_type == 'gift_card')
            // for product in gift_card_programs.mapped('rule_ids.valid_product_ids'):
            //     if product.available_in_pos:
            //         continue
            //     invalid_reward_products_msg += "\n\t"
            //     invalid_reward_products_msg += _(
            //         "Program: %(name)s, Rule Product: `%(rule_product)s`",
            //         name=reward.program_id.name,
            //         rule_product=product.name,
            //     )
            // 
            // if invalid_reward_products_msg:
            //     prefix_error_msg = _("To continue, make the following reward products available in Point of Sale.")
            //     raise UserError(f"{prefix_error_msg}\n{invalid_reward_products_msg}")
            // if gift_card_programs:
            //     for gc_program in gift_card_programs:
            //         # Do not allow a gift card program with more than one rule or reward, and check that they make sense
            //         if len(gc_program.reward_ids) > 1:
            //             raise UserError(_('Invalid gift card program. More than one reward.'))
            //         elif len(gc_program.rule_ids) > 1:
            //             raise UserError(_('Invalid gift card program. More than one rule.'))
            //         rule = gc_program.rule_ids
            //         if rule.reward_point_amount != 1 or rule.reward_point_mode != 'money':
            //             raise UserError(_('Invalid gift card program rule. Use 1 point per currency spent.'))
            //         reward = gc_program.reward_ids
            //         if reward.reward_type != 'discount' or reward.discount_mode != 'per_point' or reward.discount != 1:
            //             raise UserError(_('Invalid gift card program reward. Use 1 currency per point discount.'))
            //         if not gc_program.mail_template_id:
            //             raise UserError(_('There is no email template on the gift card program and your pos is set to print them.'))
            //         if not gc_program.pos_report_print_id:
            //             raise UserError(_('There is no print report on the gift card program and your pos is set to print them.'))
            // 
            // return super()._check_before_creating_new_session()
            */
            return default;
        }

        protected async Task<PosConfig> CheckCompaniesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_companies(self):
            // for config in self:
            //     if any(pricelist.company_id.id not in [False, config.company_id.id] for pricelist in config.available_pricelist_ids):
            //         raise ValidationError(_("The selected pricelists must belong to no company or the company of the point of sale."))
            */
            return default;
        }

        protected async Task<PosConfig> CheckCompanyHasTemplateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_company_has_template(self):
            // self.ensure_one()
            // if not self.company_has_template:
            //     raise ValidationError(_("No chart of account configured, go to the \"configuration / settings\" menu, and "
            //                             "install one from the Invoicing tab."))
            */
            return default;
        }

        protected async Task<PosConfig> CheckCompanyPaymentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_company_payment(self):
            // for config in self:
            //     if self.env['pos.payment.method'].search_count([('id', 'in', config.payment_method_ids.ids), ('company_id', '!=', config.company_id.id)]):
            //         raise ValidationError(_("The payment methods for the point of sale %s must belong to its company.", self.name))
            */
            return default;
        }

        protected async Task<PosConfig> CheckCurrenciesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_currencies(self):
            // for config in self:
            //     if config.use_pricelist and config.pricelist_id and config.pricelist_id not in config.available_pricelist_ids:
            //         raise ValidationError(_("The default pricelist must be included in the available pricelists."))
            // 
            //     # Check if the config's payment methods are compatible with its currency
            //     for pm in config.payment_method_ids:
            //         if pm.journal_id and pm.journal_id.currency_id and pm.journal_id.currency_id != config.currency_id:
            //             raise ValidationError(_("All payment methods must be in the same currency as the Sales Journal or the company currency if that is not set."))
            // 
            //     if config.use_pricelist and any(config.available_pricelist_ids.mapped(lambda pricelist: pricelist.currency_id != config.currency_id)):
            //         raise ValidationError(_("All available pricelists must be in the same currency as the company or"
            //                                 " as the Sales Journal set on this point of sale if you use"
            //                                 " the Accounting application."))
            //     if config.invoice_journal_id.currency_id and config.invoice_journal_id.currency_id != config.currency_id:
            //         raise ValidationError(_("The invoice journal must be in the same currency as the Sales Journal or the company currency if that is not set."))
            */
            return default;
        }

        protected async Task<PosConfig> CheckCustomerDisplayTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_customer_display_type(self):
            // for config in self:
            //     if config.customer_display_type == 'proxy' and (not config.is_posbox or not config.proxy_ip):
            //         raise UserError(_("You must set the iot box's IP address to use an IoT-connected screen. You'll find the field under the 'IoT Box' option."))
            */
            return default;
        }

        protected async Task<PosConfig> CheckDefaultUserInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _check_default_user(self):
            // for record in self:
            //     if (
            //         record.self_ordering_mode != 'nothing' and (
            //         not record.self_ordering_default_user_id or (
            //         record.self_ordering_default_user_id
            //         and not record.self_ordering_default_user_id.sudo().has_group("point_of_sale.group_pos_user")
            //         and not record.self_ordering_default_user_id.sudo().has_group("point_of_sale.group_pos_manager")))
            //     ):
            //         raise UserError(_("The Self-Order default user must be a POS user"))
            */
            return default;
        }

        protected async Task<PosConfig> CheckGroupsImpliedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_groups_implied(self):
            // for pos_config in self:
            //     for field_name in [f for f in pos_config._fields if f.startswith('group_')]:
            //         field = pos_config._fields[field_name]
            //         if field.type in ('boolean', 'selection') and hasattr(field, 'implied_group'):
            //             field_group_xmlids = getattr(field, 'group', 'base.group_user').split(',')
            //             field_groups = self.env['res.groups'].concat(*(self.env.ref(it) for it in field_group_xmlids))
            //             field_groups.write({'implied_ids': [(4, self.env.ref(field.implied_group).id)]})
            */
            return default;
        }

        protected async Task<PosConfig> CheckHeaderFooterInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_header_footer(self, values):
            // if not self.env.is_admin() and {'is_header_or_footer', 'receipt_header', 'receipt_footer'} & values.keys():
            //     raise AccessError(_('Only administrators can edit receipt headers and footers'))
            */
            return default;
        }

        protected async Task<PosConfig> CheckModulesToInstallInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_modules_to_install(self):
            // # determine modules to install
            // expected = [
            //     fname[7:]           # 'module_account' -> 'account'
            //     for fname in self._fields
            //     if fname.startswith('module_')
            //     if any(pos_config[fname] for pos_config in self)
            // ]
            // if expected:
            //     STATES = ('installed', 'to install', 'to upgrade')
            //     modules = self.env['ir.module.module'].sudo().search([('name', 'in', expected)])
            //     modules = modules.filtered(lambda module: module.state not in STATES)
            //     if modules:
            //         modules.button_immediate_install()
            //         # just in case we want to do something if we install a module. (like a refresh ...)
            //         return True
            // return False
            */
            return default;
        }

        protected async Task<PosConfig> CheckOnlinePaymentMethodsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_config.py) ---
            // def _check_online_payment_methods(self):
            // """ Checks the journal currency with _get_online_payment_providers(..., error_if_invalid=True)"""
            // for config in self:
            //     opm_amount = 0
            //     for pm in config.payment_method_ids:
            //         if pm.is_online_payment:
            //             opm_amount += 1
            //             if opm_amount > 1:
            //                 raise ValidationError(_("A POS config cannot have more than one online payment method."))
            //             if not pm._get_online_payment_providers(config.id, error_if_invalid=True):
            //                 raise ValidationError(_("To use an online payment method in a POS config, it must have at least one published payment provider supporting the currency of that POS config."))
            */
            return default;
        }

        protected async Task<PosConfig> CheckPaymentMethodIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_payment_method_ids(self):
            // self.ensure_one()
            // if not self.payment_method_ids:
            //     raise ValidationError(
            //         _("You must have at least one payment method configured to launch a session.")
            //     )
            */
            return default;
        }

        protected async Task<PosConfig> CheckPaymentMethodIdsJournalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_payment_method_ids_journal(self):
            // for cash_method in self.payment_method_ids.filtered(lambda m: m.journal_id.type == 'cash'):
            //     if self.env['pos.config'].search_count([('id', '!=', self.id), ('payment_method_ids', 'in', cash_method.ids)], limit=1):
            //         raise ValidationError(_("This cash payment method is already used in another Point of Sale.\n"
            //                                 "A new cash payment method should be created for this Point of Sale."))
            //     if len(cash_method.journal_id.pos_payment_method_ids) > 1:
            //         raise ValidationError(_("You cannot use the same journal on multiples cash payment methods."))
            */
            return default;
        }

        protected async Task<PosConfig> CheckPricelistsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_pricelists(self):
            // self._check_companies()
            // self = self.sudo()
            // if self.pricelist_id.company_id and self.pricelist_id.company_id != self.company_id:
            //     raise ValidationError(
            //         _("The default pricelist must belong to no company or the company of the point of sale."))
            */
            return default;
        }

        protected async Task<PosConfig> CheckProfitLossCashJournalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_profit_loss_cash_journal(self):
            // if self.cash_control and self.payment_method_ids:
            //     for method in self.payment_method_ids:
            //         if method.is_cash_count and (not method.journal_id.loss_account_id or not method.journal_id.profit_account_id):
            //             raise ValidationError(_("You need a loss and profit account on your cash journal."))
            */
            return default;
        }

        protected async Task<PosConfig> CheckRoundingMethodStrategyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_rounding_method_strategy(self):
            // for config in self:
            //     if config.cash_rounding and config.rounding_method.strategy != 'add_invoice_line':
            //         selection_value = "Add a rounding line"
            //         for key, val in self.env["account.cash.rounding"]._fields["strategy"]._description_selection(config.env):
            //             if key == "add_invoice_line":
            //                 selection_value = val
            //                 break
            //         raise ValidationError(_(
            //             "The cash rounding strategy of the point of sale %(pos)s must be: '%(value)s'",
            //             pos=config.name,
            //             value=selection_value,
            //         ))
            */
            return default;
        }

        protected async Task<PosConfig> CheckSelfOrderOnlinePaymentMethodIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment_self_order, FILE: pos_config.py) ---
            // def _check_self_order_online_payment_method_id(self):
            // for config in self:
            //     if config.self_ordering_mode == 'mobile' and config.self_ordering_service_mode == 'each' and config.self_order_online_payment_method_id and not config.self_order_online_payment_method_id._get_online_payment_providers(config.id, error_if_invalid=True):
            //         raise ValidationError(_("The online payment method used for self-order in a POS config must have at least one published payment provider supporting the currency of that POS config."))
            */
            return default;
        }

        protected async Task<PosConfig> CheckTrustedConfigIdsCurrencyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_trusted_config_ids_currency(self):
            // for config in self:
            //     for trusted_config in config.trusted_config_ids:
            //         if trusted_config.currency_id != config.currency_id:
            //             raise ValidationError(_("You cannot share open orders with configuration that does not use the same currency."))
            */
            return default;
        }

        public async Task<PosConfig> CloseKioskSessionAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def action_close_kiosk_session(self):
            // if self.current_session_id and self.current_session_id.order_ids:
            //     self.current_session_id.order_ids.filtered(lambda o: o.state not in ['paid', 'invoiced']).unlink()
            // 
            // self._notify('STATUS', {'status': 'closed'})
            // return self.current_session_id.action_pos_session_closing_control()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosConfig> ComputeCashControlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _compute_cash_control(self):
            // for config in self:
            //     config.cash_control = bool(config.payment_method_ids.filtered('is_cash_count'))
            */
            return default;
        }

        protected async Task<PosConfig> ComputeCompanyHasTemplateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _compute_company_has_template(self):
            // for config in self:
            //     config.company_has_template = config.company_id.root_id.sudo()._existing_accounting() or config.company_id.chart_template
            */
            return default;
        }

        protected async Task<PosConfig> ComputeCurrencyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _compute_currency(self):
            // for pos_config in self:
            //     if pos_config.journal_id:
            //         pos_config.currency_id = pos_config.journal_id.currency_id.id or pos_config.journal_id.company_id.sudo().currency_id.id
            //     else:
            //         pos_config.currency_id = pos_config.company_id.sudo().currency_id.id
            */
            return default;
        }

        protected async Task<PosConfig> ComputeCurrentSessionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _compute_current_session(self):
            // """If there is an open session, store it to current_session_id / current_session_State.
            // """
            // self.session_ids.fetch(["state"])
            // for pos_config in self:
            //     opened_sessions = pos_config.session_ids.filtered(lambda s: s.state != 'closed')
            //     rescue_sessions = opened_sessions.filtered('rescue')
            //     session = pos_config.session_ids.filtered(lambda s: s.state != 'closed' and not s.rescue)
            //     # sessions ordered by id desc
            //     pos_config.has_active_session = opened_sessions and True or False
            //     pos_config.current_session_id = session and session[0].id or False
            //     pos_config.current_session_state = session and session[0].state or False
            //     pos_config.number_of_rescue_session = len(rescue_sessions)
            */
            return default;
        }

        protected async Task<PosConfig> ComputeCurrentSessionUserInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _compute_current_session_user(self):
            // for pos_config in self:
            //     session = pos_config.session_ids.filtered(lambda s: s.state in ['opening_control', 'opened', 'closing_control'] and not s.rescue)
            //     if session:
            //         pos_config.pos_session_username = session[0].user_id.sudo().name
            //         pos_config.pos_session_state = session[0].state
            //         pos_config.pos_session_duration = (
            //             datetime.now() - session[0].start_at
            //         ).days if session[0].start_at else 0
            //         pos_config.current_user_id = session[0].user_id
            //     else:
            //         pos_config.pos_session_username = False
            //         pos_config.pos_session_state = False
            //         pos_config.pos_session_duration = 0
            //         pos_config.current_user_id = False
            */
            return default;
        }

        protected async Task<PosConfig> ComputeIsInstalledAccountAccountantInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _compute_is_installed_account_accountant(self):
            // account_accountant = self.env['ir.module.module'].sudo().search([('name', '=', 'account_accountant'), ('state', '=', 'installed')])
            // for pos_config in self:
            //     pos_config.is_installed_account_accountant = account_accountant and account_accountant.id
            */
            return default;
        }

        protected async Task<PosConfig> ComputeLastSessionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _compute_last_session(self):
            // PosSession = self.env['pos.session']
            // for pos_config in self:
            //     session = PosSession.search_read(
            //         [('config_id', '=', pos_config.id), ('state', '=', 'closed')],
            //         ['cash_register_balance_end_real', 'stop_at'],
            //         order="stop_at desc", limit=1)
            //     if session:
            //         timezone = pytz.timezone(self._context.get('tz') or self.env.user.tz or 'UTC')
            //         pos_config.last_session_closing_date = session[0]['stop_at'].astimezone(timezone).date()
            //         pos_config.last_session_closing_cash = session[0]['cash_register_balance_end_real']
            //     else:
            //         pos_config.last_session_closing_cash = 0
            //         pos_config.last_session_closing_date = False
            */
            return default;
        }

        protected async Task<PosConfig> ComputeSelectionPayAfterInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _compute_selection_pay_after(self):
            // selection_each_label = _("Each Order")
            // version_info = service.common.exp_version()['server_version_info']
            // if version_info[-1] == '':
            //     selection_each_label = f"{selection_each_label} {_('(require Odoo Enterprise)')}"
            // return [("meal", _("Meal")), ("each", selection_each_label)]
            */
            return default;
        }

        protected async Task<PosConfig> ComputeSelfOrderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _compute_self_order(self):
            // for record in self:
            //     if not record.module_pos_restaurant and record.self_ordering_mode != 'kiosk':
            //         record.self_ordering_mode = 'nothing'
            */
            return default;
        }

        protected async Task<PosConfig> ComputeSelfOrderingUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _compute_self_ordering_url(self):
            // for record in self:
            //     record.self_ordering_url = record.get_base_url() + record._get_self_order_route()
            */
            return default;
        }

        protected async Task<PosConfig> ComputeStatusInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _compute_status(self):
            // for record in self:
            //     record.status = 'active' if record.has_active_session else 'inactive'
            */
            return default;
        }

        protected async Task<PosConfig> ConfigSequenceImplementationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _config_sequence_implementation(self):
            // return 'standard'
            */
            return default;
        }

        public override async Task<PosConfig> CreateAsync(PosConfig entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     self._check_header_footer(vals)
            //     IrSequence = self.env['ir.sequence'].sudo()
            //     val = {
            //         'name': _('POS Order %s', vals['name']),
            //         'padding': 4,
            //         'prefix': "%s/" % vals['name'],
            //         'code': "pos.order",
            //         'company_id': vals.get('company_id', False),
            //         'implementation': self._config_sequence_implementation(),
            //     }
            //     # force sequence_id field to new pos.order sequence
            //     vals['sequence_id'] = IrSequence.create(val).id
            // 
            //     val.update(name=_('POS order line %s', vals['name']), code='pos.order.line')
            //     vals['sequence_line_id'] = IrSequence.create(val).id
            // pos_configs = super().create(vals_list)
            // pos_configs.sudo()._check_modules_to_install()
            // pos_configs.sudo()._check_groups_implied()
            // pos_configs._update_preparation_printers_menuitem_visibility()
            // # If you plan to add something after this, use a new environment. The one above is no longer valid after the modules install.
            // return pos_configs
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     is_restaurant = 'module_pos_restaurant' in vals and vals['module_pos_restaurant']
            //     if is_restaurant and 'iface_splitbill' not in vals:
            //         vals['iface_splitbill'] = True
            //     if not is_restaurant or not vals.get('iface_tipproduct', False):
            //         vals['set_tip_after_payment'] = False
            // pos_configs = super().create(vals_list)
            // for config in pos_configs:
            //     if config.module_pos_restaurant:
            //         self._setup_default_floor(config)
            // return pos_configs
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def create(self, vals_list):
            // self._prepare_self_order_splash_screen(vals_list)
            // pos_config_ids = super().create(vals_list)
            // pos_config_ids._prepare_self_order_custom_btn()
            // return pos_config_ids
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<PosConfig> CreateCashPaymentMethodInternalAsync(object cash_journal_vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _create_cash_payment_method(self, cash_journal_vals=None):
            // if cash_journal_vals is None:
            //     cash_journal_vals = {}
            // journal_vals = {
            //     'name': _('Cash'),
            //     'type': 'cash',
            //     'company_id': self.env.company.id,
            //     **cash_journal_vals,
            // }
            // 
            // default_cash_account = self.env['account.account'].with_context(lang='en_US').search([
            //     ('account_type', '=', 'asset_cash'),
            //     ('name', '=', 'Cash'),
            //     ('company_ids', 'in', self.env.company.root_id.id)
            // ], limit=1)
            // 
            // if default_cash_account:
            //     journal_vals['default_account_id'] = default_cash_account.id
            // 
            // cash_journal = self.env['account.journal'].create(journal_vals)
            // return self.env['pos.payment.method'].create({
            //     'name': _('Cash'),
            //     'journal_id': cash_journal.id,
            //     'company_id': self.env.company.id,
            // })
            */
            return default;
        }

        protected async Task<PosConfig> CreateJournalAndPaymentMethodsInternalAsync(object cash_ref, object cash_journal_vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _create_journal_and_payment_methods(self, cash_ref=None, cash_journal_vals=None):
            // """This should only be called at creation of a new pos.config."""
            // 
            // journal = self.env['account.journal']._ensure_company_account_journal()
            // payment_methods = self.env['pos.payment.method']
            // 
            // # create cash payment method per config
            // cash_pm_from_ref = cash_ref and self.env.ref(cash_ref, raise_if_not_found=False)
            // if cash_pm_from_ref:
            //     try:
            //         cash_pm_from_ref.check_access('read')
            //         cash_pm = cash_pm_from_ref
            //     except AccessError:
            //         cash_pm = self._create_cash_payment_method(cash_journal_vals)
            // else:
            //     cash_pm = self._create_cash_payment_method(cash_journal_vals)
            // 
            // if cash_ref and cash_pm != cash_pm_from_ref:
            //     self.env['ir.model.data']._update_xmlids([{
            //         'xml_id': cash_ref,
            //         'record': cash_pm,
            //         'noupdate': True,
            //     }])
            // 
            // payment_methods |= cash_pm
            // 
            // # only create bank and customer account payment methods per company
            // bank_pm = self.env['pos.payment.method'].search([('journal_id.type', '=', 'bank'), ('company_id', 'in', self.env.company.parent_ids.ids)])
            // if not bank_pm:
            //     bank_journal = self.env['account.journal'].search([('type', '=', 'bank'), ('company_id', 'in', self.env.company.parent_ids.ids)], limit=1)
            //     if not bank_journal:
            //         raise UserError(_('Ensure that there is an existing bank journal. Check if chart of accounts is installed in your company.'))
            //     bank_pm = self.env['pos.payment.method'].create({
            //         'name': _('Card'),
            //         'journal_id': bank_journal.id,
            //         'company_id': self.env.company.id,
            //         'sequence': 1,
            //     })
            // 
            // payment_methods |= bank_pm
            // 
            // pay_later_pm = self.env['pos.payment.method'].search([('journal_id', '=', False), ('company_id', 'in', self.env.company.parent_ids.ids)])
            // if not pay_later_pm:
            //     pay_later_pm = self.env['pos.payment.method'].create({
            //         'name': _('Customer Account'),
            //         'company_id': self.env.company.id,
            //         'split_transactions': True,
            //         'sequence': 2,
            //     })
            // 
            // payment_methods |= pay_later_pm
            // 
            // return journal, payment_methods.ids
            */
            return default;
        }

        protected async Task<PosConfig> DefaultDiscountValueOnModuleInstallInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_discount, FILE: pos_config.py) ---
            // def _default_discount_value_on_module_install(self):
            // configs = self.env['pos.config'].search([])
            // open_configs = (
            //     self.env['pos.session']
            //     .search(['|', ('state', '!=', 'closed'), ('rescue', '=', True)])
            //     .mapped('config_id')
            // )
            // # Do not modify configs where an opened session exists.
            // product = self.env.ref("pos_discount.product_product_consumable", raise_if_not_found=False)
            // for conf in (configs - open_configs):
            //     conf.discount_product_id = product if conf.module_pos_discount and product and (not product.company_id or product.company_id == conf.company_id) else False
            */
            return default;
        }

        protected async Task<PosConfig> DefaultInvoiceJournalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _default_invoice_journal(self):
            // return self.env['account.journal'].search([
            //     *self.env['account.journal']._check_company_domain(self.env.company),
            //     ('type', '=', 'sale'),
            // ], limit=1)
            */
            return default;
        }

        protected async Task<PosConfig> DefaultPaymentMethodsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _default_payment_methods(self):
            // """ Should only default to payment methods that are compatible to this config's company and currency.
            // """
            // domain = [
            //     *self.env['pos.payment.method']._check_company_domain(self.env.company),
            //     ('split_transactions', '=', False),
            //     '|',
            //         ('journal_id', '=', False),
            //         ('journal_id.currency_id', 'in', (False, self.env.company.currency_id.id)),
            // ]
            // non_cash_pm = self.env['pos.payment.method'].search(domain + [('is_cash_count', '=', False)])
            // available_cash_pm = self.env['pos.payment.method'].search(domain + [('is_cash_count', '=', True),
            //                                                                     ('config_ids', '=', False)], limit=1)
            // if not (non_cash_pm or available_cash_pm):
            //     _dummy, payment_methods = self._create_journal_and_payment_methods()
            //     return self.env['pos.payment.method'].browse(payment_methods)
            // return non_cash_pm | available_cash_pm
            */
            return default;
        }

        protected async Task<PosConfig> DefaultPickingTypeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _default_picking_type_id(self):
            // return self.env['stock.warehouse'].search(self.env['stock.warehouse']._check_company_domain(self.env.company), limit=1).pos_type_id.id
            */
            return default;
        }

        protected async Task<PosConfig> DefaultSaleJournalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _default_sale_journal(self):
            // journal = self.env['account.journal']._ensure_company_account_journal()
            // return journal
            */
            return default;
        }

        protected async Task<PosConfig> DefaultWarehouseIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _default_warehouse_id(self):
            // warehouse = self.env['stock.warehouse'].search(self.env['stock.warehouse']._check_company_domain(self.env.company), limit=1).id
            // if not warehouse:
            //     self.env['stock.warehouse']._warehouse_redirect_warning()
            // return warehouse
            */
            return default;
        }

        protected async Task<PosConfig> EmployeeDomainInternalAsync(Guid user_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_hr, FILE: pos_config.py) ---
            // def _employee_domain(self, user_id):
            // domain = self._check_company_domain(self.company_id)
            // if len(self.basic_employee_ids) > 0:
            //     domain = AND([
            //         domain,
            //         ['|', ('user_id', '=', user_id), ('id', 'in', self.basic_employee_ids.ids + self.advanced_employee_ids.ids)]
            //     ])
            // return domain
            */
            return default;
        }

        protected async Task<PosConfig> EnsureDownpaymentProductInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: pos_config.py) ---
            // def _ensure_downpayment_product(self):
            // pos_config = self.env.ref('point_of_sale.pos_config_main', raise_if_not_found=False)
            // downpayment_product = self.env.ref('pos_sale.default_downpayment_product', raise_if_not_found=False)
            // if pos_config and downpayment_product:
            //     pos_config.write({'down_payment_product_id': downpayment_product.id})
            */
            return default;
        }

        public async Task<PosConfig> ExecuteAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def execute(self):
            // return {
            //      'type': 'ir.actions.client',
            //      'tag': 'reload',
            //  }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosConfig> ForceHttpInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _force_http(self):
            // enforce_https = self.env['ir.config_parameter'].sudo().get_param('point_of_sale.enforce_https')
            // if not enforce_https and (self.other_devices or self.printer_ids.filtered(lambda pt: pt.printer_type == 'epson_epos')):
            //     return True
            // return False
            --- ODOO METHOD SOURCE (MODULE: pos_six, FILE: pos_config.py) ---
            // def _force_http(self):
            // enforce_https = self.env['ir.config_parameter'].sudo().get_param('point_of_sale.enforce_https')
            // if not enforce_https and self.payment_method_ids.filtered(lambda pm: pm.use_payment_terminal == 'six'):
            //     return True
            // return super(PosConfig, self)._force_http()
            */
            return default;
        }

        protected async Task<PosConfig> GetAvailableCategoriesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_available_categories(self):
            // return (
            //     self.env["pos.category"]
            //     .search(
            //         [
            //             *(
            //                 self.limit_categories
            //                 and self.iface_available_categ_ids
            //                 and [("id", "in", self.iface_available_categ_ids._get_descendants().ids)]
            //                 or []
            //             ),
            //         ],
            //         order="sequence",
            //     )
            // )
            */
            return default;
        }

        protected async Task<PosConfig> GetAvailablePricelistsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_available_pricelists(self):
            // self.ensure_one()
            // return self.available_pricelist_ids if self.use_pricelist else self.pricelist_id
            */
            return default;
        }

        protected async Task<PosConfig> GetAvailableProductDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_available_product_domain(self):
            // domain = [
            //     *self.env['product.product']._check_company_domain(self.company_id),
            //     ('active', '=', True),
            //     ('available_in_pos', '=', True),
            //     ('sale_ok', '=', True),
            // ]
            // if self.limit_categories and self.iface_available_categ_ids:
            //     domain.append(('pos_categ_ids', 'in', self._get_available_categories().ids))
            // return domain
            */
            return default;
        }

        protected async Task<PosConfig> GetCashierOnlinePaymentMethodInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_config.py) ---
            // def _get_cashier_online_payment_method(self):
            // self.ensure_one()
            // return self.payment_method_ids.filtered('is_online_payment')[:1]
            */
            return default;
        }

        public async Task<PosConfig> GetCategoriesAsync(Guid id, PosConfigGetCategoriesRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def get_categories(self, categories):
            // # filters out unavailable external id
            // return [self.env.ref(category).id for category in categories if self.env.ref(category, raise_if_not_found=False)]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosConfig> GetCustomerDisplayDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_customer_display_data(self):
            // self.ensure_one()
            // return {
            //     'config_id': self.id,
            //     'access_token': self.access_token,
            //     'type': self.customer_display_type,
            //     'has_bg_img': bool(self.customer_display_bg_img),
            //     'company_id': self.company_id.id,
            //     **({'proxy_ip': self._get_display_device_ip()} if self.customer_display_type != 'none' else {}),
            // }
            */
            return default;
        }

        protected async Task<PosConfig> GetCustomerDisplayTypesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_customer_display_types(self):
            // return [('none', 'None'), ('local', 'The same device'), ('remote', 'Another device'), ('proxy', 'An IOT-connected screen')]
            */
            return default;
        }

        protected async Task<PosConfig> GetDefaultTipProductInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_default_tip_product(self):
            // tip_product_id = self.env.ref("point_of_sale.product_product_tip", raise_if_not_found=False)
            // if not tip_product_id or (tip_product_id.sudo().company_id and tip_product_id.sudo().company_id != self.env.company):
            //     tip_product_id = self.env['product.product'].search([('default_code', '=', 'TIPS')], limit=1)
            // return tip_product_id
            */
            return default;
        }

        protected async Task<PosConfig> GetDisplayDeviceIpInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_display_device_ip(self):
            // self.ensure_one()
            // return self.proxy_ip
            */
            return default;
        }

        protected async Task<PosConfig> GetForbiddenChangeFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_forbidden_change_fields(self):
            // forbidden_keys = ['module_pos_hr', 'module_pos_restaurant', 'available_pricelist_ids',
            //                   'limit_categories', 'iface_available_categ_ids', 'use_pricelist', 'module_pos_discount',
            //                   'payment_method_ids', 'iface_tipproduc']
            // return forbidden_keys
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py) ---
            // def _get_forbidden_change_fields(self):
            // forbidden_keys = super(PosConfig, self)._get_forbidden_change_fields()
            // forbidden_keys.append('floor_ids')
            // return forbidden_keys
            */
            return default;
        }

        protected async Task<PosConfig> GetGroupPosManagerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_group_pos_manager(self):
            // return self.env.ref('point_of_sale.group_pos_manager')
            */
            return default;
        }

        protected async Task<PosConfig> GetGroupPosUserInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_group_pos_user(self):
            // return self.env.ref('point_of_sale.group_pos_user')
            */
            return default;
        }

        public async Task<PosConfig> GetKioskUrlAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def get_kiosk_url(self):
            // return self.self_ordering_url
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosConfig> GetLimitedPartnerCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_limited_partner_count(self):
            // default_limit = 100
            // config_param = self.env['ir.config_parameter'].sudo().get_param('point_of_sale.limited_customer_count', default_limit)
            // try:
            //     return int(config_param)
            // except (TypeError, ValueError, OverflowError):
            //     return default_limit
            */
            return default;
        }

        public async Task<PosConfig> GetLimitedPartnersLoadingAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def get_limited_partners_loading(self):
            // return self.env.execute_query(SQL("""
            //     WITH pm AS
            //     (
            //              SELECT   partner_id,
            //                       Count(partner_id) order_count
            //              FROM     pos_order
            //              GROUP BY partner_id)
            //     SELECT    id
            //     FROM      res_partner AS partner
            //     LEFT JOIN pm
            //     ON        (
            //                         partner.id = pm.partner_id)
            //     WHERE (
            //         partner.company_id=%s OR partner.company_id IS NULL
            //     )
            //     ORDER BY  COALESCE(pm.order_count, 0) DESC,
            //               NAME limit %s;
            // """, self.company_id.id, self._get_limited_partner_count()))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosConfig> GetLimitedProductCountAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def get_limited_product_count(self):
            // default_limit = 20000
            // config_param = self.env['ir.config_parameter'].sudo().get_param('point_of_sale.limited_product_count', default_limit)
            // try:
            //     return int(config_param)
            // except (TypeError, ValueError, OverflowError):
            //     return default_limit
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosConfig> GetLimitedProductsLoadingAsync(Guid id, PosConfigGetLimitedProductsLoadingRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def get_limited_products_loading(self, fields):
            // query = self.env['product.product']._where_calc(
            //     self._get_available_product_domain()
            // )
            // sql = SQL(
            //     """
            //     WITH pm AS (
            //           SELECT product_id,
            //                  MAX(write_date) date
            //             FROM stock_move_line
            //         GROUP BY product_id
            //     )
            //        SELECT product_product.id
            //          FROM %s
            //     LEFT JOIN pm ON product_product.id=pm.product_id
            //         WHERE %s
            //      ORDER BY product_product__product_tmpl_id.is_favorite DESC,
            //               CASE WHEN product_product__product_tmpl_id.type = 'service' THEN 1 ELSE 0 END DESC,
            //               pm.date DESC NULLS LAST,
            //               product_product.write_date DESC
            //         LIMIT %s
            //     """,
            //     query.from_clause,
            //     query.where_clause or SQL("TRUE"),
            //     self.get_limited_product_count(),
            // )
            // product_ids = [r[0] for r in self.env.execute_query(sql)]
            // product_ids.extend(self._get_special_products().ids)
            // products = self.env['product.product'].search([('id', 'in', product_ids)])
            // # sort products by product_ids order
            // id_to_index = {pid: index for index, pid in enumerate(product_ids)}
            // products = products.sorted(key=lambda p: id_to_index[p.id])
            // product_combo = products.filtered(lambda p: p['type'] == 'combo')
            // product_in_combo = product_combo.combo_ids.combo_item_ids.product_id
            // products_available = products | product_in_combo
            // return products_available.read(fields, load=False)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosConfig> GetPaymentMethodInternalAsync(object payment_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_payment_method(self, payment_type):
            // for pm in self.payment_method_ids:
            //     if pm.type == payment_type:
            //         return pm
            // return False
            */
            return default;
        }

        public async Task<PosConfig> GetPosKanbanViewStateAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def get_pos_kanban_view_state(self):
            // has_pos_config = bool(self.env['pos.config'].search_count(
            //     self._check_company_domain(self.env.company)
            // ))
            // has_chart_template = bool(self.env.company.chart_template)
            // main_company = self.env.ref('base.main_company', raise_if_not_found=False)
            // return {
            //     "has_pos_config": has_pos_config,
            //     "has_chart_template": has_chart_template,
            //     "is_restaurant_installed": bool(self.env['ir.module.module'].search_count([('name', '=', 'pos_restaurant'), ('state', '=', 'installed')])),
            //     "is_main_company": main_company and self.env.company.id == main_company.id or False
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosConfig> GetProgramIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: pos_config.py) ---
            // def _get_program_ids(self):
            // today = fields.Date.context_today(self)
            // return self.env['loyalty.program'].search([
            //     ('pos_ok', '=', True),
            //     '|', ('pos_config_ids', '=', self.id), ('pos_config_ids', '=', False),
            //     '|', ('date_from', '=', False), ('date_from', '<=', today),
            //     '|', ('date_to', '=', False), ('date_to', '>=', today)
            // ]).filtered(lambda p: not p.limit_usage or p.sudo().total_order_count < p.max_usage)
            */
            return default;
        }

        protected async Task<PosConfig> GetQrCodeDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _get_qr_code_data(self):
            // self.ensure_one()
            // 
            // table_qr_code = []
            // if self.self_ordering_mode == 'mobile' and self.module_pos_restaurant and self.self_ordering_service_mode == 'table':
            //     table_qr_code.extend([{
            //             'name': floor.name,
            //             'type': 'table',
            //             'tables': [
            //                 {
            //                     'identifier': table.identifier,
            //                     'id': table.id,
            //                     'name': table.table_number,
            //                     'url': self._get_self_order_url(table.id),
            //                 }
            //                 for table in floor.table_ids.filtered("active")
            //             ]
            //         }
            //         for floor in self.floor_ids]
            //     )
            // else:
            //     # Here we use "range" to determine the number of QR codes to generate from
            //     # this list, which will then be inserted into a PDF.
            //     table_qr_code.extend([{
            //         'name': _('Generic'),
            //         'type': 'default',
            //         'tables': [{
            //             'id': i,
            //             'url': self._get_self_order_url(),
            //         } for i in range(0, 6)]
            //     }])
            // 
            // return table_qr_code
            */
            return default;
        }

        public async Task<PosConfig> GetRecordsAsync(Guid id, PosConfigGetRecordsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def get_records(self, data):
            // records = {}
            // for model, ids in data.items():
            //     records[model] = self.env[model].browse(ids).read(self.env[model]._load_pos_data_fields(self.id), load=False)
            // return records
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<string> GetSelfOrderRouteInternalAsync(Guid table_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _get_self_order_route(self, table_id: Optional[int] = None) -> str:
            // self.ensure_one()
            // base_route = f"/pos-self/{self.id}"
            // table_route = ""
            // 
            // if self.self_ordering_mode == 'consultation':
            //     return base_route
            // 
            // if self.self_ordering_mode == 'mobile':
            //     table = self.env["restaurant.table"].search(
            //         [("active", "=", True), ("id", "=", table_id)], limit=1
            //     )
            // 
            //     if table:
            //         table_route = f"&table_identifier={table.identifier}"
            // 
            // return f"{base_route}?access_token={self.access_token}{table_route}"
            */
            return default;
        }

        protected async Task<string> GetSelfOrderUrlInternalAsync(Guid table_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _get_self_order_url(self, table_id: Optional[int] = None) -> str:
            // self.ensure_one()
            // return url_quote(self.get_base_url() + self._get_self_order_route(table_id))
            */
            return default;
        }

        protected async Task<PosConfig> GetSelfOrderingAttachmentInternalAsync(object images)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _get_self_ordering_attachment(self, images):
            // encoded_images = []
            // for image in images:
            //     encoded_images.append({
            //         'id': image.id,
            //         'data': image.sudo().datas.decode('utf-8'),
            //     })
            // return encoded_images
            */
            return default;
        }

        protected async Task<PosConfig> GetSelfOrderingDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment_self_order, FILE: pos_config.py) ---
            // def _get_self_ordering_data(self):
            // res = super()._get_self_ordering_data()
            // payment_methods = self._get_self_ordering_payment_methods_data(self.self_order_online_payment_method_id)
            // res['pos_payment_methods'] += payment_methods
            // return res
            */
            return default;
        }

        protected async Task<PosConfig> GetSpecialProductsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_special_products(self):
            // return self.env.ref('point_of_sale.product_product_tip', raise_if_not_found=False) or self.env['product.product']
            --- ODOO METHOD SOURCE (MODULE: pos_discount, FILE: pos_config.py) ---
            // def _get_special_products(self):
            // res = super()._get_special_products()
            // default_discount_product = self.env.ref('pos_discount.product_product_consumable', raise_if_not_found=False) or self.env['product.product']
            // return res | self.env['pos.config'].search([]).mapped('discount_product_id') | default_discount_product
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: pos_config.py) ---
            // def _get_special_products(self):
            // res = super()._get_special_products()
            // return res | self.env['pos.config'].search([]).mapped('down_payment_product_id')
            */
            return default;
        }

        protected async Task<PosConfig> GetSuffixedRefNameInternalAsync(object ref_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_suffixed_ref_name(self, ref_name):
            // """Suffix the given ref_name with the id of the current company if it's not the main company."""
            // main_company = self.env.ref('base.main_company', raise_if_not_found=False)
            // if main_company and self.env.company.id == main_company.id:
            //     return ref_name
            // else:
            //     return f"{ref_name}_{self.env.company.id}"
            */
            return default;
        }

        public async Task<PosConfig> InstallPosRestaurantAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def install_pos_restaurant(self):
            // pos_restaurant_module = self.env['ir.module.module'].search([('name', '=', 'pos_restaurant')])
            // pos_restaurant_module.button_immediate_install()
            // return {'installed_with_demo': pos_restaurant_module.demo}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosConfig> IsJournalExistInternalAsync(object journal_code, object name, Guid company_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _is_journal_exist(self, journal_code, name, company_id):
            // account_journal = self.env['account.journal']
            // existing_journal = account_journal.search([
            //     ('name', '=', name),
            //     ('code', '=', journal_code),
            //     ('company_id', '=', company_id),
            // ], limit=1)
            // 
            // return existing_journal.id or account_journal.create({
            //     'name': name,
            //     'code': journal_code,
            //     'type': 'cash',
            //     'company_id': company_id,
            // }).id
            */
            return default;
        }

        protected async Task<PosConfig> IsPosPmExistInternalAsync(object name, Guid journal_id, Guid company_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _is_pos_pm_exist(self, name, journal_id, company_id):
            // pos_payment = self.env['pos.payment.method']
            // existing_pos_cash_pm = pos_payment.search([
            //     ('name', '=', name),
            //     ('journal_id', '=', journal_id),
            //     ('company_id', '=', company_id),
            // ], limit=1)
            // 
            // return existing_pos_cash_pm.id or pos_payment.create({
            //     'name': name,
            //     'journal_id': journal_id,
            //     'company_id': company_id,
            // }).id
            */
            return default;
        }

        protected async Task<PosConfig> KeepNewValsInternalAsync(object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _keep_new_vals(self, vals):
            // """ Keep values in vals that are different than
            // self's values.
            // """
            // from_settings_view = self.env.context.get('from_settings_view')
            // if not from_settings_view:
            //     return vals
            // new_vals = {}
            // for field, val in vals.items():
            //     config_field = self._fields.get(field)
            //     if config_field:
            //         cache_value = config_field.convert_to_cache(val, self)
            //         record_value = config_field.convert_to_record(cache_value, self)
            //         if record_value != self[field]:
            //             new_vals[field] = val
            // return new_vals
            */
            return default;
        }

        protected async Task<PosConfig> LinkSameNonCashPaymentMethodsInternalAsync(object source_config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _link_same_non_cash_payment_methods(self, source_config):
            // pms = source_config.payment_method_ids.filtered(lambda pm: not pm.is_cash_count)
            // if pms:
            //     self.payment_method_ids = [Command.link(pm.id) for pm in pms]
            */
            return default;
        }

        protected async Task<PosConfig> LoadBarDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py) ---
            // def _load_bar_data(self):
            // convert.convert_file(self.env, 'pos_restaurant', 'data/scenarios/bar_data.xml', None, noupdate=True, mode='init', kind='data')
            */
            return default;
        }

        protected async Task<PosConfig> LoadFurnitureDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _load_furniture_data(self):
            // if not self.env.user.has_group('base.group_system'):
            //     raise AccessError(_("You must have 'Administration Settings' access to load furniture data."))
            // product_module = self.env['ir.module.module'].search([('name', '=', 'product')])
            // if not product_module.demo:
            //     convert.convert_file(self.env, 'product', 'data/product_category_demo.xml', None, noupdate=True, mode='init', kind='data')
            //     convert.convert_file(self.env, 'product', 'data/product_attribute_demo.xml', None, noupdate=True, mode='init', kind='data')
            //     convert.convert_file(self.env, 'product', 'data/product_demo.xml', None, noupdate=True, mode='init', kind='data')
            // 
            // convert.convert_file(self.env, 'point_of_sale', 'data/scenarios/furniture_data.xml', None, noupdate=True, mode='init', kind='data')
            */
            return default;
        }

        public async Task<PosConfig> LoadOnboardingBakeryScenarioAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def load_onboarding_bakery_scenario(self):
            // ref_name = 'point_of_sale.pos_config_bakery'
            // if not self.env.ref(ref_name, raise_if_not_found=False):
            //     convert.convert_file(self.env, 'point_of_sale', 'data/scenarios/bakery_data.xml', None, mode='init', noupdate=True, kind='data')
            // 
            // journal, payment_methods_ids = self._create_journal_and_payment_methods(cash_journal_vals={'name': _("Cash Bakery"), 'show_on_dashboard': False})
            // bakery_categories = self.get_categories([
            //     'point_of_sale.pos_category_breads',
            //     'point_of_sale.pos_category_pastries',
            // ])
            // config = self.env['pos.config'].create({
            //     'name': _('Bakery Shop'),
            //     'company_id': self.env.company.id,
            //     'journal_id': journal.id,
            //     'payment_method_ids': payment_methods_ids,
            //     'limit_categories': True,
            //     'iface_available_categ_ids': bakery_categories,
            // })
            // self.env['ir.model.data']._update_xmlids([{
            //     'xml_id': self._get_suffixed_ref_name(ref_name),
            //     'record': config,
            //     'noupdate': True,
            // }])
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosConfig> LoadOnboardingBarScenarioAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py) ---
            // def load_onboarding_bar_scenario(self):
            // ref_name = 'pos_restaurant.pos_config_main_bar'
            // if not self.env.ref(ref_name, raise_if_not_found=False):
            //     self._load_bar_data()
            // journal, payment_methods_ids = self._create_journal_and_payment_methods(cash_journal_vals={'name': 'Cash Bar', 'show_on_dashboard': False})
            // bar_categories = self.get_categories([
            //     'pos_restaurant.pos_category_cocktails',
            //     'pos_restaurant.pos_category_soft_drinks',
            // ])
            // config = self.env['pos.config'].create({
            //     'name': 'Bar',
            //     'company_id': self.env.company.id,
            //     'journal_id': journal.id,
            //     'payment_method_ids': payment_methods_ids,
            //     'limit_categories': True,
            //     'iface_available_categ_ids': bar_categories,
            //     'iface_splitbill': True,
            //     'module_pos_restaurant': True,
            // })
            // self.env['ir.model.data']._update_xmlids([{
            //     'xml_id': self._get_suffixed_ref_name(ref_name),
            //     'record': config,
            //     'noupdate': True,
            // }])
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosConfig> LoadOnboardingClothesScenarioAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def load_onboarding_clothes_scenario(self):
            // if not self.env.user.has_group('base.group_system'):
            //     raise AccessError(_("You must have 'Administration Settings' access to load clothes data."))
            // ref_name = 'point_of_sale.pos_config_clothes'
            // if not self.env.ref(ref_name, raise_if_not_found=False):
            //     convert.convert_file(self.env, 'point_of_sale', 'data/scenarios/clothes_data.xml', None, noupdate=True, mode='init', kind='data')
            // 
            // clothes_categories = self.get_categories([
            //     'point_of_sale.pos_category_upper',
            //     'point_of_sale.pos_category_lower',
            //     'point_of_sale.pos_category_others'
            // ])
            // journal, payment_methods_ids = self._create_journal_and_payment_methods(cash_journal_vals={'name': _("Cash Clothes Shop"), 'show_on_dashboard': False})
            // config = self.env['pos.config'].create([{
            //     'name': _('Clothes Shop'),
            //     'company_id': self.env.company.id,
            //     'journal_id': journal.id,
            //     'payment_method_ids': payment_methods_ids,
            //     'limit_categories': True,
            //     'iface_available_categ_ids': clothes_categories,
            // }])
            // self.env['ir.model.data']._update_xmlids([{
            //     'xml_id': self._get_suffixed_ref_name(ref_name),
            //     'record': config,
            //     'noupdate': True,
            // }])
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosConfig> LoadOnboardingFurnitureScenarioAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def load_onboarding_furniture_scenario(self):
            // ref_name = 'point_of_sale.pos_config_main'
            // if not self.env.ref(ref_name, raise_if_not_found=False):
            //     self._load_furniture_data()
            // 
            // journal, payment_methods_ids = self._create_journal_and_payment_methods(
            //     cash_ref='point_of_sale.cash_payment_method_furniture',
            //     cash_journal_vals={'name': _("Cash Furn. Shop"), 'show_on_dashboard': False},
            // )
            // furniture_categories = self.get_categories([
            //     'point_of_sale.pos_category_miscellaneous',
            //     'point_of_sale.pos_category_desks',
            //     'point_of_sale.pos_category_chairs'
            // ])
            // config = self.env['pos.config'].create([{
            //     'name': _('Furniture Shop'),
            //     'company_id': self.env.company.id,
            //     'journal_id': journal.id,
            //     'payment_method_ids': payment_methods_ids,
            //     'limit_categories': True,
            //     'iface_available_categ_ids': furniture_categories,
            // }])
            // self.env['ir.model.data']._update_xmlids([{
            //     'xml_id': self._get_suffixed_ref_name(ref_name),
            //     'record': config,
            //     'noupdate': True,
            // }])
            // if self.env.company.id == self.env.ref('base.main_company').id:
            //     existing_session = self.env.ref('point_of_sale.pos_closed_session_2', raise_if_not_found=False)
            //     if not existing_session:
            //         convert.convert_file(self.env, 'point_of_sale', 'data/orders_demo.xml', None, noupdate=True, mode='init', kind='data')
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: pos_config.py) ---
            // def load_onboarding_furniture_scenario(self):
            // super().load_onboarding_furniture_scenario()
            // self._ensure_downpayment_product()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosConfig> LoadOnboardingKioskScenarioAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def load_onboarding_kiosk_scenario(self):
            // if not bool(self.env.company.chart_template):
            //     return False
            // 
            // journal, payment_methods_ids = self._create_journal_and_payment_methods()
            // restaurant_categories = self.get_categories([
            //     'pos_restaurant.food',
            //     'pos_restaurant.drinks',
            // ])
            // not_cash_payment_methods_ids = self.env['pos.payment.method'].search([
            //     ('is_cash_count', '=', False),
            //     ('id', 'in', payment_methods_ids),
            // ]).ids
            // self.env['pos.config'].create({
            //     'name': _('Kiosk'),
            //     'company_id': self.env.company.id,
            //     'journal_id': journal.id,
            //     'payment_method_ids': not_cash_payment_methods_ids,
            //     'limit_categories': True,
            //     'iface_available_categ_ids': restaurant_categories,
            //     'iface_splitbill': True,
            //     'module_pos_restaurant': True,
            //     'self_ordering_mode': 'kiosk',
            // })
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosConfig> LoadOnboardingRestaurantScenarioAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py) ---
            // def load_onboarding_restaurant_scenario(self):
            // ref_name = 'pos_restaurant.pos_config_main_restaurant'
            // if not self.env.ref(ref_name, raise_if_not_found=False):
            //     self._load_restaurant_data()
            // 
            // journal, payment_methods_ids = self._create_journal_and_payment_methods(cash_journal_vals={'name': 'Cash Restaurant', 'show_on_dashboard': False})
            // restaurant_categories = self.get_categories([
            //     'pos_restaurant.food',
            //     'pos_restaurant.drinks',
            // ])
            // config = self.env['pos.config'].create({
            //     'name': _('Restaurant'),
            //     'company_id': self.env.company.id,
            //     'journal_id': journal.id,
            //     'payment_method_ids': payment_methods_ids,
            //     'limit_categories': True,
            //     'iface_available_categ_ids': restaurant_categories,
            //     'iface_splitbill': True,
            //     'module_pos_restaurant': True,
            // })
            // self.env['ir.model.data']._update_xmlids([{
            //     'xml_id': self._get_suffixed_ref_name(ref_name),
            //     'record': config,
            //     'noupdate': True,
            // }])
            // if self.env.company.id == self.env.ref('base.main_company').id:
            //     existing_session = self.env.ref('pos_restaurant.pos_closed_session_3', raise_if_not_found=False)
            //     if not existing_session:
            //         convert.convert_file(self.env, 'pos_restaurant', 'data/restaurant_session_floor.xml', None, noupdate=True, mode='init', kind='data')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosConfig> LoadPosDataDomainInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _load_pos_data_domain(self, data):
            // return [('id', '=', data['pos.session']['data'][0]['config_id'])]
            */
            return default;
        }

        protected async Task<PosConfig> LoadPosDataInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _load_pos_data(self, data):
            // domain = self._load_pos_data_domain(data)
            // fields = self._load_pos_data_fields(self.id)
            // data = self.search_read(domain, fields, load=False)
            // 
            // if not data[0]['use_pricelist']:
            //     data[0]['pricelist_id'] = False
            // 
            // return {
            //     'data': data,
            //     'fields': fields,
            // }
            */
            return default;
        }

        protected async Task<PosConfig> LoadRestaurantDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py) ---
            // def _load_restaurant_data(self):
            // convert.convert_file(self.env, 'pos_restaurant', 'data/scenarios/restaurant_data.xml', None, noupdate=True, mode='init', kind='data')
            */
            return default;
        }

        public async Task<PosConfig> LoadSelfDataAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def load_self_data(self):
            // # Init our first record, in case of self_order is pos_config
            // config_fields = self._load_pos_self_data_fields(self.id)
            // response = {
            //     'pos.config': {
            //         'data': self.env['pos.config'].search_read([('id', '=', self.id)], config_fields, load=False),
            //         'fields': config_fields,
            //     }
            // }
            // response['pos.config']['data'][0]['_self_ordering_image_home_ids'] = self._get_self_ordering_attachment(self.self_ordering_image_home_ids)
            // response['pos.config']['data'][0]['_pos_special_products_ids'] = self._get_special_products().ids
            // self.env['pos.session']._load_pos_data_relations('pos.config', response)
            // 
            // # Classic data loading
            // for model in self._load_self_data_models():
            //     try:
            //         response[model] = self.env[model]._load_pos_self_data(response)
            //         self.env['pos.session']._load_pos_data_relations(model, response)
            //     except AccessError as e:
            //         response[model] = {
            //             'data': [],
            //             'fields': self.env[model]._load_pos_self_data_fields(self.id),
            //             'error': e.args[0]
            //         }
            // 
            //         self.env['pos.session']._load_pos_data_relations(model, response)
            // 
            // return response
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosConfig> LoadSelfDataModelsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _load_self_data_models(self):
            // return ['pos.session', 'pos.order', 'pos.order.line', 'pos.payment', 'pos.payment.method', 'res.currency', 'pos.category', 'product.product', 'product.combo', 'product.combo.item',
            //     'res.company', 'account.tax', 'account.tax.group', 'pos.printer', 'res.country', 'product.pricelist', 'product.pricelist.item', 'account.fiscal.position', 'account.fiscal.position.tax',
            //     'res.lang', 'product.template.attribute.line', 'product.attribute', 'product.attribute.custom.value', 'product.template.attribute.value',
            //     'decimal.precision', 'uom.uom', 'pos.printer', 'pos_self_order.custom_link', 'restaurant.floor', 'restaurant.table', 'account.cash.rounding']
            */
            return default;
        }

        public async Task<PosConfig> NotifySynchronisationAsync(Guid id, PosConfigNotifySynchronisationRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def notify_synchronisation(self, session_id, login_number, records={}):
            // static_records = {}
            // 
            // for model, ids in records.items():
            //     fields = self.env[model]._load_pos_data_fields(self.id)
            //     static_records[model] = self.env[model].browse(ids).read(fields, load=False)
            // 
            // self._notify('SYNCHRONISATION', {
            //     'static_records': static_records,
            //     'session_id': session_id,
            //     'login_number': login_number,
            //     'records': records
            // })
            // 
            // for config in self.trusted_config_ids:
            //     config._notify('SYNCHRONISATION', {
            //         'static_records': static_records,
            //         'session_id': config.current_session_id.id,
            //         'login_number': 0,
            //         'records': records
            //     })
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosConfig> OnchangeAdvancedEmployeeIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_hr, FILE: pos_config.py) ---
            // def _onchange_advanced_employee_ids(self):
            // for employee in self.advanced_employee_ids:
            //     if employee in self.basic_employee_ids:
            //         self.basic_employee_ids -= employee
            */
            return default;
        }

        protected async Task<PosConfig> OnchangeBasicEmployeeIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_hr, FILE: pos_config.py) ---
            // def _onchange_basic_employee_ids(self):
            // for employee in self.basic_employee_ids:
            //     if employee in self.advanced_employee_ids:
            //         if employee.user_id._has_group('point_of_sale.group_pos_manager'):
            //             self.basic_employee_ids -= employee
            //         else:
            //             self.advanced_employee_ids -= employee
            */
            return default;
        }

        protected async Task<PosConfig> OnchangePaymentMethodIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _onchange_payment_method_ids(self):
            // if any(record.self_ordering_mode == 'kiosk' and any(pm.is_cash_count for pm in record.payment_method_ids) for record in self):
            //     raise ValidationError(_("You cannot add cash payment methods in kiosk mode."))
            */
            return default;
        }

        public async Task<PosConfig> OpenExistingSessionCbAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def open_existing_session_cb(self):
            // """ close session button
            // 
            // access session form to validate entries
            // """
            // self.ensure_one()
            // return self._open_session(self.current_session_id.id)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosConfig> OpenOpenedRescueSessionFormAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def open_opened_rescue_session_form(self):
            // rescue_session_ids = self.session_ids.filtered(lambda s: s.state != 'closed' and s.rescue)
            // 
            // if len(rescue_session_ids) == 1:
            //     return {
            //         'res_model': 'pos.session',
            //         'view_mode': 'form',
            //         'res_id': rescue_session_ids.id,
            //         'type': 'ir.actions.act_window',
            //     }
            // else:
            //     return {
            //         'name': _('Rescue Sessions'),
            //         'res_model': 'pos.session',
            //         'view_mode': 'list,form',
            //         'domain': [('id', 'in', rescue_session_ids.ids)],
            //         'type': 'ir.actions.act_window',
            //     }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosConfig> OpenSessionInternalAsync(Guid session_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _open_session(self, session_id):
            // self._check_pricelists()  # The pricelist company might have changed after the first opening of the session
            // return {
            //     'name': _('Session'),
            //     'view_mode': 'form,list',
            //     'res_model': 'pos.session',
            //     'res_id': session_id,
            //     'view_id': False,
            //     'type': 'ir.actions.act_window',
            // }
            */
            return default;
        }

        public async Task<PosConfig> OpenUiAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def open_ui(self):
            // """Open the pos interface with config_id as an extra argument.
            // 
            // In vanilla PoS each user can only have one active session, therefore it was not needed to pass the config_id
            // on opening a session. It is also possible to login to sessions created by other users.
            // 
            // :returns: dict
            // """
            // self.ensure_one()
            // # In case of test environment, don't create the pdf
            // if self.env.uid == SUPERUSER_ID and not tools.config['test_enable']:
            //     raise UserError(_("You do not have permission to open a POS session. Please try opening a session with a different user"))
            // 
            // if not self.current_session_id:
            //     self._check_before_creating_new_session()
            // self._validate_fields(self._fields)
            // 
            // return self._action_to_open_ui()
            --- ODOO METHOD SOURCE (MODULE: pos_discount, FILE: pos_config.py) ---
            // def open_ui(self):
            // for config in self:
            //     if not self.current_session_id and config.module_pos_discount and not config.discount_product_id:
            //         raise UserError(_('A discount product is needed to use the Global Discount feature. Go to Point of Sale > Configuration > Settings to set it.'))
            // return super().open_ui()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosConfig> OpenWizardAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def action_open_wizard(self):
            // self.ensure_one()
            // 
            // if not self.current_session_id:
            //     self._check_before_creating_new_session()
            //     session = self.env['pos.session'].create({'user_id': self.env.uid, 'config_id': self.id})
            //     session.set_opening_control(0, "")
            //     self._notify('STATUS', {'status': 'open'})
            // 
            // ctx = dict(self._context, app_id='pos_self_order', footer=False)
            // 
            // return {
            //     'res_model': 'pos.config',
            //     'type': 'ir.actions.client',
            //     'tag': 'install_kiosk_pwa',
            //     'target': 'new',
            //     'context': ctx
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosConfig> PosConfigModalEditAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def action_pos_config_modal_edit(self):
            // return {
            //     'view_mode': 'form',
            //     'res_model': 'pos.config',
            //     'type': 'ir.actions.act_window',
            //     'target': 'new',
            //     'res_id': self.id,
            //     'context': {'pos_config_open_modal': True},
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosConfig> PrepareSelfOrderCustomBtnInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _prepare_self_order_custom_btn(self):
            // for record in self:
            //     exists = record.env['pos_self_order.custom_link'].search_count([
            //         ('pos_config_ids', 'in', record.id),
            //         ('url', '=', f'/pos-self/{record.id}/products')
            //     ])
            // 
            //     if not exists:
            //         record.env['pos_self_order.custom_link'].create({
            //             'name': _('Order Now'),
            //             'url': f'/pos-self/{record.id}/products',
            //             'pos_config_ids': [(4, record.id)],
            //         })
            */
            return default;
        }

        protected async Task<PosConfig> PrepareSelfOrderSplashScreenInternalAsync(object vals_list)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _prepare_self_order_splash_screen(self, vals_list):
            // for vals in vals_list:
            //     if not vals.get('self_ordering_mode'):
            //         return True
            // 
            //     if not vals.get('self_ordering_image_home_ids'):
            //         vals['self_ordering_image_home_ids'] = [(0, 0, {
            //             'name': image_name,
            //             'datas': base64.b64encode(file_open(opj("pos_self_order/static/img", image_name), "rb").read()),
            //             'res_model': 'pos.config',
            //             'type': 'binary',
            //         }) for image_name in ['landing_01.jpg', 'landing_02.jpg', 'landing_03.jpg']]
            // 
            // return True
            */
            return default;
        }

        protected async Task<PosConfig> PreprocessX2manyValsFromSettingsViewInternalAsync(object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _preprocess_x2many_vals_from_settings_view(self, vals):
            // """ From the res.config.settings view, changes in the x2many fields always result to an array of link commands or a single set command.
            //     - As a result, the items that should be unlinked are not properly unlinked.
            //     - So before doing the write, we inspect the commands to determine which records should be unlinked.
            //     - We only care about the link command.
            //     - We can consider set command as absolute as it will replace all.
            // """
            // from_settings_view = self.env.context.get('from_settings_view')
            // if not from_settings_view:
            //     # If vals is not from the settings view, we don't need to preprocess.
            //     return
            // 
            // # Only ensure one when write is from settings view.
            // self.ensure_one()
            // 
            // fields_to_preprocess = []
            // for f in self.fields_get([]).values():
            //     if f['type'] in ['many2many', 'one2many']:
            //         fields_to_preprocess.append(f['name'])
            // 
            // for x2many_field in fields_to_preprocess:
            //     if x2many_field in vals:
            //         linked_ids = set(self[x2many_field].ids)
            // 
            //         for command in vals[x2many_field]:
            //             if command[0] == 4:
            //                 _id = command[1]
            //                 if _id in linked_ids:
            //                     linked_ids.remove(_id)
            // 
            //         # Remaining items in linked_ids should be unlinked.
            //         unlink_commands = [Command.unlink(_id) for _id in linked_ids]
            // 
            //         vals[x2many_field] = unlink_commands + vals[x2many_field]
            */
            return default;
        }

        public async Task<PosConfig> PreviewSelfOrderAppAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def preview_self_order_app(self):
            // self.ensure_one()
            // return {
            //     "type": "ir.actions.act_url",
            //     "url": self._get_self_order_route(),
            //     "target": "new",
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosConfig> ReadConfigOpenOrdersAsync(Guid id, PosConfigReadConfigOpenOrdersRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def read_config_open_orders(self, domain, record_ids=[]):
            // delete_record_ids = {}
            // dynamic_records = {}
            // 
            // for model, domain in domain.items():
            //     ids = record_ids[model]
            //     delete_record_ids[model] = [id for id in ids if not self.env[model].browse(id).exists()]
            //     dynamic_records[model] = self.env[model].search(domain)
            // 
            // pos_order_data = dynamic_records.get('pos.order') or self.env['pos.order']
            // data = pos_order_data.read_pos_data([], self.id)
            // 
            // for key, records in dynamic_records.items():
            //     fields = self.env[key]._load_pos_data_fields(self.id)
            //     ids = list(set(records.ids + [record['id'] for record in data.get(key, [])]))
            //     dynamic_records[key] = self.env[key].browse(ids).read(fields, load=False)
            // 
            // for key, value in data.items():
            //     if key not in dynamic_records:
            //         dynamic_records[key] = value
            // 
            // return {
            //     'dynamic_records': dynamic_records,
            //     'deleted_record_ids': delete_record_ids,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosConfig> RemoveTrustedConfigIdInternalAsync(Guid config_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _remove_trusted_config_id(self, config_id):
            // self.trusted_config_ids -= config_id
            */
            return default;
        }

        protected async Task<PosConfig> ResetDefaultOnValsInternalAsync(object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _reset_default_on_vals(self, vals):
            // if 'tip_product_id' in vals and not vals['tip_product_id'] and 'iface_tipproduct' in vals and vals['iface_tipproduct']:
            //     default_product = self.env.ref('point_of_sale.product_product_tip', False)
            //     if default_product:
            //         vals['tip_product_id'] = default_product.id
            //     else:
            //         raise UserError(_('The default tip product is missing. Please manually specify the tip product. (See Tips field.)'))
            */
            return default;
        }

        protected async Task<PosConfig> SelfOrderDefaultUserInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _self_order_default_user(self):
            // users = self.env["res.users"].search(['|', ('company_ids', 'in', self.env.company.id), ('company_id', '=', False)])
            // for user in users:
            //     if user.sudo().has_group("point_of_sale.group_pos_manager"):
            //         return user
            */
            return default;
        }

        protected async Task<PosConfig> SelfOrderKioskDefaultLanguagesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _self_order_kiosk_default_languages(self):
            // return self.env["res.lang"].get_installed()
            */
            return default;
        }

        protected async Task<PosConfig> SetDefaultPosLoadLimitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _set_default_pos_load_limit(self):
            // param_model = self.env["ir.config_parameter"]
            // if not param_model.get_param("point_of_sale.limited_product_count"):
            //     param_model.set_param("point_of_sale.limited_product_count", 20000)
            // 
            // if not param_model.get_param("point_of_sale.limited_customer_count"):
            //     param_model.set_param("point_of_sale.limited_customer_count", 100)
            */
            return default;
        }

        protected async Task<PosConfig> SetFiscalPositionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _set_fiscal_position(self):
            // for config in self:
            //     if config.tax_regime_selection and config.default_fiscal_position_id and (config.default_fiscal_position_id.id not in config.fiscal_position_ids.ids):
            //         config.fiscal_position_ids = [(4, config.default_fiscal_position_id.id)]
            //     elif not config.tax_regime_selection and config.fiscal_position_ids.ids:
            //         config.fiscal_position_ids = [(5, 0, 0)]
            */
            return default;
        }

        protected async Task<PosConfig> SetupDefaultFloorInternalAsync(object pos_config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py) ---
            // def _setup_default_floor(self, pos_config):
            // if not pos_config.floor_ids:
            //     main_floor = self.env['restaurant.floor'].create({
            //         'name': pos_config.company_id.name,
            //         'pos_config_ids': [(4, pos_config.id)],
            //     })
            //     self.env['restaurant.table'].create({
            //         'table_number': 1,
            //         'floor_id': main_floor.id,
            //         'seats': 1,
            //         'position_h': 100,
            //         'position_v': 100,
            //         'width': 130,
            //         'height': 130,
            //     })
            */
            return default;
        }

        protected async Task<List<Dictionary<string, object>>> SplitQrCodesListInternalAsync(List<Dictionary<string, object>> floors, int cols)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _split_qr_codes_list(self, floors: List[Dict], cols: int) -> List[Dict]:
            // """
            // :floors: the list of floors
            // :cols: the number of qr codes per row
            // """
            // self.ensure_one()
            // return [
            //     {
            //         "name": floor.get("name"),
            //         "rows_of_tables": list(split_every(cols, floor["tables"], list)),
            //     }
            //     for floor in floors
            // ]
            */
            return default;
        }

        protected async Task<PosConfig> UpdateAccessTokenInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _update_access_token(self):
            // self.access_token = uuid.uuid4().hex[:16]
            // self.floor_ids.table_ids._update_identifier()
            */
            return default;
        }

        public async Task<PosConfig> UpdateCustomerDisplayAsync(Guid id, PosConfigUpdateCustomerDisplayRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def update_customer_display(self, order, access_token):
            // self.ensure_one()
            // if not access_token or not secrets.compare_digest(self.access_token, access_token):
            //     return
            // self._notify("UPDATE_CUSTOMER_DISPLAY", order)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosConfig> UpdateEventsSeatsInternalAsync(object events)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: pos_config.py) ---
            // def _update_events_seats(self, events):
            // data = []
            // for event in events:
            //     data.append({
            //         'event_id': event.id,
            //         'seats_available': event.seats_available,
            //         'event_ticket_ids': [{
            //             'ticket_id': ticket.id,
            //             'seats_available': ticket.seats_available
            //         } for ticket in event.event_ticket_ids]
            //     })
            // 
            // for record in self:
            //     record._notify('UPDATE_AVAILABLE_SEATS', data)
            */
            return default;
        }

        protected async Task<PosConfig> UpdatePreparationPrintersMenuitemVisibilityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _update_preparation_printers_menuitem_visibility(self):
            // prepa_printers_menuitem = self.sudo().env.ref('point_of_sale.menu_pos_preparation_printer', raise_if_not_found=False)
            // if prepa_printers_menuitem:
            //     prepa_printers_menuitem.active = self.sudo().env['pos.config'].search_count([('is_order_printer', '=', True)], limit=1) > 0
            */
            return default;
        }

        public async Task<PosConfig> UseCouponCodeAsync(Guid id, PosConfigUseCouponCodeRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_loyalty, FILE: pos_config.py) ---
            // def use_coupon_code(self, code, creation_date, partner_id, pricelist_id):
            // self.ensure_one()
            // # Points desc so that in coupon mode one could use a coupon multiple times
            // coupon = self.env['loyalty.card'].search(
            //     [('program_id', 'in', self._get_program_ids().ids),
            //      '|', ('partner_id', 'in', (False, partner_id)), ('program_type', '=', 'gift_card'),
            //      ('code', '=', code)],
            //     order='partner_id, points desc', limit=1)
            // program = coupon.program_id
            // if not coupon or not program.active:
            //     return {
            //         'successful': False,
            //         'payload': {
            //             'error_message': _('This coupon is invalid (%s).', code),
            //         },
            //     }
            // check_date = fields.Date.from_string(creation_date[:11])
            // today_date = fields.Date.context_today(self)
            // error_message = False
            // if (
            //     (coupon.expiration_date and coupon.expiration_date < check_date)
            //     or (program.date_to and program.date_to < today_date)
            //     or (program.limit_usage and program.sudo().total_order_count >= program.max_usage)
            // ):
            //     error_message = _("This coupon is expired (%s).", code)
            // elif program.date_from and program.date_from > today_date:
            //     error_message = _("This coupon is not yet valid (%s).", code)
            // elif (
            //     not program.reward_ids or
            //     not any(r.required_points <= coupon.points for r in program.reward_ids)
            // ):
            //     error_message = _("No reward can be claimed with this coupon.")
            // elif program.pricelist_ids and pricelist_id not in program.pricelist_ids.ids:
            //     error_message = _("This coupon is not available with the current pricelist.")
            // elif coupon and program.program_type == 'promo_code':
            //     error_message = _("This programs requires a code to be applied.")
            // 
            // if error_message:
            //     return {
            //         'successful': False,
            //         'payload': {
            //             'error_message': error_message,
            //         },
            //     }
            // 
            // return {
            //     'successful': True,
            //     'payload': {
            //         'program_id': program.id,
            //         'coupon_id': coupon.id,
            //         'coupon_partner_id': coupon.partner_id.id,
            //         'points': coupon.points,
            //         'has_source_order': coupon._has_source_order(),
            //     },
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, PosConfig entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def write(self, vals):
            // self._check_header_footer(vals)
            // self._reset_default_on_vals(vals)
            // if ('is_order_printer' in vals and not vals['is_order_printer']):
            //     vals['printer_ids'] = [fields.Command.clear()]
            // 
            // bypass_categories_forbidden_change = self.env.context.get('bypass_categories_forbidden_change', False)
            // bypass_payment_method_ids_forbidden_change = self.env.context.get('bypass_payment_method_ids_forbidden_change', False)
            // 
            // self._preprocess_x2many_vals_from_settings_view(vals)
            // vals = self._keep_new_vals(vals)
            // opened_session = self.mapped('session_ids').filtered(lambda s: s.state != 'closed')
            // if opened_session:
            //     forbidden_fields = []
            //     for key in self._get_forbidden_change_fields():
            //         if key in vals.keys():
            //             if bypass_categories_forbidden_change and key in ('limit_categories', 'iface_available_categ_ids'):
            //                 continue
            //             if bypass_payment_method_ids_forbidden_change and key == 'payment_method_ids':
            //                 continue
            //             if key == 'use_pricelist' and vals[key]:
            //                 continue
            //             if key == 'available_pricelist_ids':
            //                 will_unlink_a_pricelist = \
            //                     (
            //                         (not isinstance(vals[key], list) or len(vals[key]) == 0)
            //                         and self.available_pricelist_ids
            //                     ) or (
            //                         isinstance(vals[key], list) and any(
            //                             (
            //                                 len(cmd) >= 1
            //                                 and cmd[0] == Command.CLEAR
            //                                 and self.available_pricelist_ids
            //                             ) or (
            //                                 len(cmd) >= 2
            //                                 and cmd[0] in {Command.UNLINK, Command.DELETE}
            //                                 and cmd[1] in self.available_pricelist_ids.ids
            //                             ) or (
            //                                 len(cmd) == 3
            //                                 and cmd[0] == Command.SET
            //                                 and set(self.available_pricelist_ids.ids) - set(cmd[2])
            //                             )
            //                             for cmd in vals[key]
            //                         )
            //                     )
            // 
            //                 if not will_unlink_a_pricelist:
            //                     continue
            //             field_name = self._fields[key].get_description(self.env)["string"]
            //             forbidden_fields.append(field_name)
            //     if len(forbidden_fields) > 0:
            //         raise UserError(_(
            //             "Unable to modify this PoS Configuration because you can't modify %s while a session is open.",
            //             ", ".join(forbidden_fields)
            //         ))
            // 
            // result = super(PosConfig, self).write(vals)
            // 
            // self.sudo()._set_fiscal_position()
            // self.sudo()._check_modules_to_install()
            // self.sudo()._check_groups_implied()
            // if 'is_order_printer' in vals:
            //     self._update_preparation_printers_menuitem_visibility()
            // return result
            --- ODOO METHOD SOURCE (MODULE: pos_hr, FILE: pos_config.py) ---
            // def write(self, vals):
            // if 'advanced_employee_ids' not in vals:
            //     vals['advanced_employee_ids'] = []
            // vals['advanced_employee_ids'] += [(4, emp_id) for emp_id in self._get_group_pos_manager().users.employee_id.ids]
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py) ---
            // def write(self, vals):
            // if ('module_pos_restaurant' in vals and vals['module_pos_restaurant'] is False):
            //     vals['floor_ids'] = [(5, 0, 0)]
            // 
            // if ('module_pos_restaurant' in vals and not vals['module_pos_restaurant']) or ('iface_tipproduct' in vals and not vals['iface_tipproduct']):
            //     vals['set_tip_after_payment'] = False
            // 
            // if ('module_pos_restaurant' in vals and vals['module_pos_restaurant']):
            //     self._setup_default_floor(self)
            // 
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def write(self, vals):
            // self._prepare_self_order_splash_screen([vals])
            // 
            // for record in self:
            //     if vals.get('self_ordering_mode') == 'kiosk' or (vals.get('pos_self_ordering_mode') == 'mobile' and vals.get('pos_self_ordering_service_mode') == 'counter'):
            //         vals['self_ordering_pay_after'] = 'each'
            // 
            //     if (not vals.get('module_pos_restaurant') and not record.module_pos_restaurant) and vals.get('self_ordering_mode') == 'mobile':
            //         vals['self_ordering_pay_after'] = 'each'
            // 
            //     if (vals.get('self_ordering_service_mode') == 'counter' or record.self_ordering_service_mode == 'counter') and vals.get('self_ordering_mode') == 'mobile':
            //         vals['self_ordering_pay_after'] = 'each'
            // 
            //     if vals.get('self_ordering_mode') == 'mobile' and vals.get('self_ordering_pay_after') == 'meal':
            //         vals['self_ordering_service_mode'] = 'table'
            // 
            // res = super().write(vals)
            // self._prepare_self_order_custom_btn()
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}