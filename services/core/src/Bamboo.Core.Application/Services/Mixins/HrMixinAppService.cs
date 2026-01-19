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
    [Module("hr", Category = "HumanResources", Depends = new[] { "base_setup", "digest", "phone_validation", "resource_mail", "web" })]
    public partial class HrMixinAppService : ApplicationService, IHrMixinAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public HrMixinAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ActionCloseKioskSessionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def action_close_kiosk_session(self):
            // if self.current_session_id and self.current_session_id.order_ids:
            //     self.current_session_id.order_ids.filtered(lambda o: o.state == 'draft').unlink()
            // 
            // self._notify('STATUS', {'status': 'closed'})
            // return self.current_session_id.action_pos_session_closing_control()
            */
            return default;
        }

        public async Task<TEntity> ActionOpenWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def action_open_wizard(self):
            // self.ensure_one()
            // 
            // if not self.current_session_id:
            //     res = self._check_before_creating_new_session()
            //     if res:
            //         return res
            //     session = self.env['pos.session'].create({'user_id': self.env.uid, 'config_id': self.id})
            //     session.set_opening_control(0, "")
            //     self._notify('STATUS', {'status': 'open'})
            // 
            // return {
            //     'type': 'ir.actions.act_url',
            //     'name': _('Self Order'),
            //     'target': 'new',
            //     'url': self.get_kiosk_url(),
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionPosConfigModalEditAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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
            return default;
        }

        public async Task<TEntity> ActionToOpenUiInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _action_to_open_ui(self):
            // if not self.current_session_id:
            //     self.env['pos.session'].create({'user_id': self.env.uid, 'config_id': self.id})
            // pos_url = '/pos/ui/%d?from_backend=True' % self.id
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

        public async Task<TEntity> AddTrustedConfigIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid config_id) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _add_trusted_config_id(self, config_id):
            // self.trusted_config_ids += config_id
            */
            return default;
        }

        public async Task<TEntity> CheckAdyenAskCustomerForTipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> CheckBeforeCreatingNewSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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
            //     raise UserError(f"{prefix_error_msg}\n{invalid_reward_products_msg}")  # pylint: disable=missing-gettext
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

        public async Task<TEntity> CheckCompaniesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> CheckCompanyHasFiscalCountryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_company_has_fiscal_country(self):
            // self.ensure_one()
            // if not self.company_id.account_fiscal_country_id:
            //     raise ValidationError(_("The company must have a fiscal country set."))
            */
            return default;
        }

        public async Task<TEntity> CheckCompanyHasTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> CheckCompanyPaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> CheckCurrenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> CheckDefaultUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> CheckGroupsImpliedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> CheckHeaderFooterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_header_footer(self, values):
            // if not self.env.is_admin() and {'is_header_or_footer', 'receipt_header', 'receipt_footer'} & values.keys():
            //     raise AccessError(_('Only administrators can edit receipt headers and footers'))
            */
            return default;
        }

        public async Task<TEntity> CheckModulesToInstallInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> CheckOnlinePaymentMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> CheckPaymentMethodIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> CheckPaymentMethodIdsJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_payment_method_ids_journal(self):
            // for config in self:
            //     for cash_method in config.payment_method_ids.filtered(lambda m: m.journal_id.type == 'cash'):
            //         if self.env['pos.config'].search_count([('id', '!=', config.id), ('payment_method_ids', 'in', cash_method.ids)], limit=1):
            //             raise ValidationError(_("This cash payment method is already used in another Point of Sale.\n"
            //                                     "A new cash payment method should be created for this Point of Sale."))
            //         if len(cash_method.journal_id.pos_payment_method_ids) > 1:
            //             raise ValidationError(_("You cannot use the same journal on multiples cash payment methods."))
            */
            return default;
        }

        public async Task<TEntity> CheckPricelistsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> CheckProfitLossCashJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> CheckRoundingMethodStrategyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> CheckSelfOrderOnlinePaymentMethodIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> CheckTrustedConfigIdsCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> CloseUiAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def close_ui(self):
            // return self.open_ui()
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def close_ui(self):
            // if self.self_ordering_mode == "kiosk":
            //     return self.action_close_kiosk_session()
            // return super().close_ui()
            */
            return default;
        }

        public async Task<TEntity> ComputeCashControlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _compute_cash_control(self):
            // for config in self:
            //     config.cash_control = bool(config.payment_method_ids.filtered('is_cash_count'))
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyHasTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _compute_company_has_template(self):
            // for config in self:
            //     config.company_has_template = config.company_id.root_id.sudo()._existing_accounting() or config.company_id.chart_template
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> ComputeCurrentSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> ComputeCurrentSessionUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> ComputeFastPaymentMethodIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _compute_fast_payment_method_ids(self):
            // for config in self:
            //     config.fast_payment_method_ids = config.fast_payment_method_ids.filtered(lambda pm: pm.id in config.payment_method_ids.ids)
            //     if not config.fast_payment_method_ids:
            //         config.use_fast_payment = False
            */
            return default;
        }

        public async Task<TEntity> ComputeIsInstalledAccountAccountantInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> ComputeLastSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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
            //         timezone = self.env.tz
            //         pos_config.last_session_closing_date = session[0]['stop_at'].astimezone(timezone).date()
            //         pos_config.last_session_closing_cash = session[0]['cash_register_balance_end_real']
            //     else:
            //         pos_config.last_session_closing_cash = 0
            //         pos_config.last_session_closing_date = False
            */
            return default;
        }

        public async Task<TEntity> ComputeLocalDataIntegrityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _compute_local_data_integrity(self):
            // self.last_data_change = self.env.cr.now()
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py) ---
            // def _compute_local_data_integrity(self):
            // super()._compute_local_data_integrity()
            */
            return default;
        }

        public async Task<TEntity> ComputeSelectionPayAfterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> ComputeSelfOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> ComputeSelfOrderingUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _compute_self_ordering_url(self):
            // for record in self:
            //     record.self_ordering_url = record.get_base_url() + record._get_self_order_route()
            */
            return default;
        }

        public async Task<TEntity> ComputeStatisticsForSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _compute_statistics_for_session(self):
            // for config in self:
            //     session = config.session_ids.filtered(lambda s: s.state != 'closed' and not s.rescue)
            //     session_record = session[0] if session else None
            //     if not session_record or not session_record.exists():
            //         config.statistics_for_current_session = False
            //         continue
            //     config.statistics_for_current_session = config.get_statistics_for_session(session_record)
            */
            return default;
        }

        public async Task<TEntity> ComputeStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _compute_status(self):
            // for record in self:
            //     record.status = 'active' if record.has_active_session else 'inactive'
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_mixin.py) ---
            // def create(self, vals_list):
            // special_self = self.with_context(_allow_read_hr_employee=_ALLOW_READ_HR_EMPLOYEE)
            // records = super(HrMixin, special_self).create(vals_list)
            // return records.with_env(self.env)
            */
            return default;
        }

        public async Task<TEntity> CreateCashPaymentMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object cash_journal_vals) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> CreateJournalAndPaymentMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object cash_ref, object cash_journal_vals) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> CreateSequencesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _create_sequences(self):
            // for pos_config in self:
            //     sequence_vals = {
            //         'padding': 6,
            //         'code': "pos.order",
            //         'company_id': pos_config.company_id.id,
            //         'implementation': 'no_gap',
            //     }
            // 
            //     # Create sequences for all orders
            //     pos_config.order_seq_id = self.env['ir.sequence'].sudo().create({
            //         **sequence_vals,
            //         'name': _('POS order from config #%s', pos_config.id),
            //     })
            // 
            //     # Create sequences for order that are created from self ore backend
            //     pos_config.order_backend_seq_id = self.env['ir.sequence'].sudo().create({
            //         **sequence_vals,
            //         'name': _('POS order backend from config #%s', pos_config.id),
            //     })
            // 
            //     # Create sequences for all order lines
            //     pos_config.order_line_seq_id = self.env['ir.sequence'].sudo().create({
            //         **sequence_vals,
            //         'name': _('POS order line from config #%s', pos_config.id),
            //     })
            // 
            //     # Create sequences for devices
            //     pos_config.device_seq_id = self.env['ir.sequence'].sudo().create({
            //         **sequence_vals,
            //         'name': _('POS device from config #%s', pos_config.id),
            //         'padding': 0,
            //     })
            */
            return default;
        }

        public async Task<TEntity> DefaultDiscountValueOnModuleInstallInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> DefaultInvoiceJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> DefaultPaymentMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> DefaultPickingTypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _default_picking_type_id(self):
            // return self.env['stock.warehouse'].with_context(active_test=False).search(self.env['stock.warehouse']._check_company_domain(self.env.company), limit=1).pos_type_id.id
            */
            return default;
        }

        public async Task<TEntity> DefaultSaleJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _default_sale_journal(self):
            // journal = self.env['account.journal']._ensure_company_account_journal()
            // return journal
            */
            return default;
        }

        public async Task<TEntity> DefaultWarehouseIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _default_warehouse_id(self):
            // return self.env['stock.warehouse'].search(self.env['stock.warehouse']._check_company_domain(self.env.company), limit=1).id
            */
            return default;
        }

        public async Task<TEntity> EmployeeDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_hr, FILE: pos_config.py) ---
            // def _employee_domain(self, user_id):
            // domain = self._check_company_domain(self.company_id)
            // if len(self.basic_employee_ids) > 0:
            //     domain = Domain.AND([
            //         domain,
            //         ['|', ('user_id', '=', user_id), ('id', 'in', self.basic_employee_ids.ids + self.advanced_employee_ids.ids + self.minimal_employee_ids.ids)]
            //     ])
            // return domain
            */
            return default;
        }

        public async Task<TEntity> EnsureDownpaymentProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> EnsurePublicAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _ensure_public_attachments(self):
            // self.self_ordering_image_background_ids.write({"public": True})
            // self.self_ordering_image_home_ids.write({"public": True})
            */
            return default;
        }

        public async Task<TEntity> EnvWithCleanContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _env_with_clean_context(self):
            // safe_context = {}
            // if 'allowed_company_ids' in self.env.context:
            //     safe_context['allowed_company_ids'] = self.env.context['allowed_company_ids']
            // return self.env(context=safe_context)
            */
            return default;
        }

        public async Task<TEntity> ExecuteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def execute(self):
            // return {
            //      'type': 'ir.actions.client',
            //      'tag': 'reload',
            //  }
            */
            return default;
        }

        public async Task<TEntity> GenerateSingleQrCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object url) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _generate_single_qr_code__(self, url):  # noqa: PLW3201
            // qr = qrcode.QRCode(
            //     version=1,
            //     error_correction=qrcode.constants.ERROR_CORRECT_L,
            //     box_size=10,
            //     border=4,
            // )
            // qr.add_data(url)
            // qr.make(fit=True)
            // return {
            //     'png': qr.make_image(fill_color="black", back_color="transparent"),
            //     'svg': qr.make_image(fill_color="black", back_color="transparent", image_factory=qrcode.image.svg.SvgImage),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetAvailablePricelistsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_available_pricelists(self):
            // self.ensure_one()
            // return self.available_pricelist_ids + self.pricelist_id if self.use_pricelist else self.pricelist_id
            */
            return default;
        }

        public async Task<TEntity> GetCashierOnlinePaymentMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_config.py) ---
            // def _get_cashier_online_payment_method(self):
            // self.ensure_one()
            // return self.payment_method_ids.filtered('is_online_payment')[:1]
            */
            return default;
        }

        public async Task<TEntity> GetCustomerDisplayDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_customer_display_data(self):
            // self.ensure_one()
            // return {
            //     'config_id': self.id,
            //     'access_token': self.access_token,
            //     'has_bg_img': bool(self.customer_display_bg_img),
            //     'company_id': self.company_id.id,
            //     'proxy_ip': self._get_display_device_ip(),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetDefaultDemoDataXmlIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_default_demo_data_xml_id(self):
            // return 'point_of_sale.pos_config_main'
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py) ---
            // def _get_default_demo_data_xml_id(self):
            // if self.module_pos_restaurant:
            //     return 'pos_restaurant.pos_config_main_restaurant'
            // return super()._get_default_demo_data_xml_id()
            */
            return default;
        }

        public async Task<TEntity> GetDefaultTipProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> GetDemoDataLoaderMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_demo_data_loader_methods(self):
            // return {
            //     'point_of_sale.pos_config_clothes': self._load_onboarding_clothes_demo_data,
            //     'point_of_sale.pos_config_bakery': self._load_onboarding_bakery_demo_data,
            //     'point_of_sale.pos_config_main': self._load_onboarding_furniture_demo_data,
            // }
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py) ---
            // def _get_demo_data_loader_methods(self):
            // mapping = super()._get_demo_data_loader_methods()
            // mapping.update({
            //     'pos_restaurant.pos_config_main_restaurant': self._load_restaurant_demo_data,
            //     'pos_restaurant.pos_config_main_bar': self._load_bar_demo_data,
            // })
            // return mapping
            */
            return default;
        }

        public async Task<TEntity> GetDisplayDeviceIpInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_display_device_ip(self):
            // self.ensure_one()
            // return self.proxy_ip
            */
            return default;
        }

        public async Task<TEntity> GetForbiddenChangeFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_forbidden_change_fields(self):
            // return ['module_pos_restaurant', 'payment_method_ids']
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py) ---
            // def _get_forbidden_change_fields(self):
            // forbidden_keys = super(PosConfig, self)._get_forbidden_change_fields()
            // forbidden_keys.append('floor_ids')
            // return forbidden_keys
            */
            return default;
        }

        public async Task<TEntity> GetGroupPosManagerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_group_pos_manager(self):
            // return self.env.ref('point_of_sale.group_pos_manager')
            */
            return default;
        }

        public async Task<TEntity> GetGroupPosUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_group_pos_user(self):
            // return self.env.ref('point_of_sale.group_pos_user')
            */
            return default;
        }

        public async Task<TEntity> GetKioskUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def get_kiosk_url(self):
            // return self.self_ordering_url
            */
            return default;
        }

        public async Task<TEntity> GetLimitedPartnerCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_limited_partner_count(self):
            // config_param = self.env['ir.config_parameter'].sudo().get_param('point_of_sale.limited_customer_count', DEFAULT_LIMIT_LOAD_PARTNER)
            // try:
            //     return int(config_param)
            // except (TypeError, ValueError, OverflowError):
            //     return DEFAULT_LIMIT_LOAD_PARTNER
            */
            return default;
        }

        public async Task<TEntity> GetLimitedPartnersLoadingAsync<TEntity>(IEnumerable<TEntity> entities, object offset) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def get_limited_partners_loading(self, offset=0):
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
            //               NAME limit %s offset %s;
            // """, self.company_id.id, self._get_limited_partner_count(), offset))
            */
            return default;
        }

        public async Task<TEntity> GetLimitedProductCountAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def get_limited_product_count(self):
            // config_param = self.env['ir.config_parameter'].sudo().get_param('point_of_sale.limited_product_count', DEFAULT_LIMIT_LOAD_PRODUCT)
            // try:
            //     return int(config_param)
            // except (TypeError, ValueError, OverflowError):
            //     return DEFAULT_LIMIT_LOAD_PRODUCT
            */
            return default;
        }

        public async Task<TEntity> GetNextOrderRefsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object device_identifier) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_next_order_refs(self, device_identifier='0'):
            // next_number = self.order_backend_seq_id._next()
            // year_2_digits = str(datetime.now().year)[-2:]
            // tracking_number = f"{int(next_number) % 1000}"
            // return f"{year_2_digits}{device_identifier}-{self.id}-{next_number}", tracking_number
            */
            return default;
        }

        public async Task<TEntity> GetPaymentMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_type) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> GetPosKanbanViewStateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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
            return default;
        }

        public async Task<TEntity> GetPosQrOrderDataAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def get_pos_qr_order_data(self):
            // 
            // url_form = "https://www.odoo.com/app/point-of-sale-restaurant-qr-code"
            // 
            // table_data = []
            // if self.self_ordering_mode not in ['mobile', 'consultation']:
            //     return {
            //         'success': False,
            //         'error': 'INVALID_SELF_ORDERING_MODE',
            //     }
            // 
            // table_ids = None
            // if self.module_pos_restaurant:
            //     table_ids = self.floor_ids.table_ids
            // 
            // if table_ids and self.self_ordering_mode == 'mobile':
            //     for table in table_ids:
            //         url = self._get_self_order_url(table.id)
            //         table_data.append({
            //             'url': url,
            //             'name': f"{table.floor_id.name} - {table.table_number}",
            //             'images': self._generate_single_qr_code__(unquote(url)),
            //         })
            // else:
            //     url = self._get_self_order_url()
            //     table_data.append({
            //         'url': url,
            //         'name': "generic",
            //         'images': self._generate_single_qr_code__(unquote(url)),
            //     })
            // 
            // zip_buffer = BytesIO()
            // with zipfile.ZipFile(zip_buffer, "w", 0) as zip_file:
            //     for index, qr_data in enumerate(table_data):
            //         with zip_file.open(f"{qr_data['name']} ({index + 1}).png", "w") as buf:
            //             qr_data['images']['png'].save(buf, format="PNG")
            //         with zip_file.open(f"{qr_data['name']} ({index + 1}).svg", "w") as buf:
            //             buf.write(qr_data['images']['svg'].to_string())
            // zip_buffer.seek(0)
            // 
            // return {
            //     'success': True,
            //     'table_data': table_data,
            //     'self_ordering_mode': self.self_ordering_mode,
            //     'db_name': self.env.cr.dbname,
            //     'redirect_url': url_form,
            //     'zip_archive': base64.b64encode(zip_buffer.read()).decode('utf-8'),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetProgramIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> GetQrCodeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> GetRecordByRefAsync<TEntity>(IEnumerable<TEntity> entities, object recordRefs) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def get_record_by_ref(self, recordRefs):
            // # filters out unavailable external id
            // return [self.env.ref(record).id for record in recordRefs if self.env.ref(record, raise_if_not_found=False)]
            */
            return default;
        }

        public async Task<string> GetSelfOrderRouteInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid table_id) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<string> GetSelfOrderUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid table_id) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _get_self_order_url(self, table_id: Optional[int] = None) -> str:
            // self.ensure_one()
            // long_url = self.get_base_url() + self._get_self_order_route(table_id)
            // return self.env['link.tracker'].search_or_create([{
            //     'url': long_url,
            //     'title': f"Self Order {self.name}" if not table_id else f"Self Order {self.name} - Table id {table_id}",
            // }]).short_url
            */
            return default;
        }

        public async Task<TEntity> GetSelfOrderingAttachmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object images) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> GetSelfOrderingDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> GetSpecialProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> GetStatisticsForSessionAsync<TEntity>(IEnumerable<TEntity> entities, object session) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def get_statistics_for_session(self, session):
            // self.ensure_one()
            // currency = self.currency_id
            // timezone = pytz.timezone(self.env.context.get('tz') or self.env.user.tz or 'UTC')
            // statistics = {
            //     'cash': {
            //         'raw_opening_cash': session.cash_register_balance_start,
            //         'opening_cash': currency.format(session.cash_register_balance_start)
            //     },
            //     'date': {
            //         'is_started': bool(session.start_at),
            //         'start_date': session.start_at.astimezone(timezone).strftime('%b %d') if session.start_at else False,
            //     },
            //     'orders': {
            //         'paid': False,
            //         'draft': False,
            //     },
            // }
            // 
            // all_paid_orders = session.order_ids.filtered(lambda o: o.state == 'paid')
            // refund_orders = all_paid_orders.filtered(lambda o: o.is_refund)
            // draft_orders = session.order_ids.filtered(lambda o: o.state == 'draft')
            // non_refund_orders = all_paid_orders - refund_orders
            // 
            // # calculate total refunded amount per original order for refund count check
            // refund_totals = defaultdict(float)
            // for refund in refund_orders:
            //     if refund.refunded_order_id:
            //         refund_totals[refund.refunded_order_id.id] += abs(refund.amount_total)
            // 
            // # count paid orders that are not completely refunded
            // paid_order_count = sum(
            //     1 for order in non_refund_orders
            //     if refund_totals.get(order.id, 0.0) != order.amount_total
            // )
            // 
            // if paid_order_count:
            //     total_paid = sum(all_paid_orders.mapped('amount_total'))
            //     statistics['orders']['paid'] = {
            //         'amount': total_paid,
            //         'count': paid_order_count,
            //         'display': f"{currency.format(total_paid)} ({paid_order_count} {'order' if paid_order_count == 1 else 'orders'})"
            //     }
            // 
            // if draft_orders:
            //     total_draft = sum(draft_orders.mapped('amount_total'))
            //     count_draft = len(draft_orders)
            //     statistics['orders']['draft'] = {
            //         'amount': total_draft,
            //         'count': count_draft,
            //         'display': f"{currency.format(total_draft)} ({count_draft} {'order' if count_draft == 1 else 'orders'})"
            //     }
            // 
            // return statistics
            */
            return default;
        }

        public async Task<TEntity> GetSuffixedRefNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object ref_name) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> GetUrlToCacheInternalAsync<TEntity>(IEnumerable<TEntity> entities, object debug) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_url_to_cache(self, debug):
            // url_to_cache = [
            //     f"/pos/ui/{self.id}?from_backend=True",
            //     f"/pos/ui/{self.id}",
            // ]
            // return self.env["ir.qweb"]._get_asset_links("point_of_sale.assets_prod", debug=debug) + url_to_cache
            */
            return default;
        }

        public async Task<TEntity> HasValidSelfPaymentMethodAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment_self_order, FILE: pos_config.py) ---
            // def has_valid_self_payment_method(self):
            // res = super().has_valid_self_payment_method()
            // if self.self_ordering_mode == 'mobile':
            //     return res or bool(self.self_order_online_payment_method_id)
            // return res or any(pm.is_online_payment for pm in self.payment_method_ids)
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def has_valid_self_payment_method(self):
            // """ Checks if the POS config has a valid payment method (terminal or online). """
            // self.ensure_one()
            // if self.self_ordering_mode == 'mobile':
            //     return False
            // return any(pm.use_payment_terminal in self._supported_kiosk_payment_terminal() for pm in self.payment_method_ids)
            */
            return default;
        }

        public async Task<TEntity> InstallPosRestaurantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def install_pos_restaurant(self):
            // pos_restaurant_module = self.env['ir.module.module'].search([('name', '=', 'pos_restaurant')])
            // pos_restaurant_module.button_immediate_install()
            // return {'installed_with_demo': pos_restaurant_module.demo}
            */
            return default;
        }

        public async Task<TEntity> IsJournalExistInternalAsync<TEntity>(IEnumerable<TEntity> entities, object journal_code, object name, Guid company_id) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> IsPosPmExistInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, Guid journal_id, Guid company_id) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> IsQuantitiesSetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _is_quantities_set(self):
            // return self.is_closing_entry_by_product
            */
            return default;
        }

        public async Task<TEntity> KeepNewValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> LinkSameNonCashPaymentMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object source_config) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> LoadBarDemoDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_demo_data) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py) ---
            // def _load_bar_demo_data(self, with_demo_data=True):
            // self.ensure_one()
            // convert.convert_file(self._env_with_clean_context(), 'pos_restaurant', 'data/scenarios/bar_category_data.xml', idref=None, mode='init', noupdate=True)
            // if with_demo_data:
            //     convert.convert_file(self._env_with_clean_context(), 'pos_restaurant', 'data/scenarios/bar_demo_data.xml', idref=None, mode='init', noupdate=True)
            // bar_categories = self.get_record_by_ref([
            //     'pos_restaurant.pos_category_cocktails',
            //     'pos_restaurant.pos_category_soft_drinks',
            // ])
            // if bar_categories:
            //     self.limit_categories = True
            //     self.iface_available_categ_ids = bar_categories
            */
            return default;
        }

        public async Task<TEntity> LoadDataParamsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def load_data_params(self):
            // response = {}
            // fields = self._load_pos_self_data_fields(self)
            // response['pos.config'] = {
            //     'fields': fields,
            //     'relations': self.env['pos.session']._load_pos_data_relations('pos.config', fields)
            // }
            // 
            // for model in self._load_self_data_models():
            //     fields = self.env[model]._load_pos_self_data_fields(self)
            //     response[model] = {
            //         'fields': fields,
            //         'relations': self.env['pos.session']._load_pos_data_relations(model, fields)
            //     }
            // 
            // return response
            */
            return default;
        }

        public async Task<TEntity> LoadDemoDataAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def load_demo_data(self):
            // self = self.with_context(bypass_categories_forbidden_change=True)
            // xml_id = self.get_external_id().get(self.id) or self._get_default_demo_data_xml_id()
            // loaders = self._get_demo_data_loader_methods()
            // for prefix, loader in loaders.items():
            //     if xml_id.startswith(prefix):
            //         return loader(True)
            // return loaders.get(self._get_default_demo_data_xml_id(), self._load_onboarding_furniture_demo_data)(True)
            */
            return default;
        }

        public async Task<TEntity> LoadOnboardingBakeryDemoDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_demo_data) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _load_onboarding_bakery_demo_data(self, with_demo_data=True):
            // self.ensure_one()
            // convert.convert_file(self._env_with_clean_context(), 'point_of_sale', 'data/scenarios/bakery_category_data.xml', idref=None, mode='init', noupdate=True)
            // if with_demo_data:
            //     convert.convert_file(self._env_with_clean_context(), 'point_of_sale', 'data/scenarios/bakery_data.xml', idref=None, mode='init', noupdate=True)
            // 
            // bakery_categories = self.get_record_by_ref([
            //     'point_of_sale.pos_category_breads',
            //     'point_of_sale.pos_category_pastries',
            // ])
            // if bakery_categories:
            //     self.limit_categories = True
            //     self.iface_available_categ_ids = bakery_categories
            */
            return default;
        }

        public async Task<TEntity> LoadOnboardingBakeryScenarioAsync<TEntity>(IEnumerable<TEntity> entities, object with_demo_data) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def load_onboarding_bakery_scenario(self, with_demo_data=True):
            // journal, payment_methods_ids = self._create_journal_and_payment_methods(
            //     cash_journal_vals={'name': _('Cash Bakery'), 'show_on_dashboard': False})
            // config = self.env['pos.config'].create({
            //     'name': _('Bakery Shop'),
            //     'company_id': self.env.company.id,
            //     'journal_id': journal.id,
            //     'payment_method_ids': payment_methods_ids
            // })
            // self.env['ir.model.data']._update_xmlids([{
            //     'xml_id': self._get_suffixed_ref_name('point_of_sale.pos_config_bakery'),
            //     'record': config,
            //     'noupdate': True,
            // }])
            // config._load_onboarding_bakery_demo_data(with_demo_data)
            // return {'config_id': config.id}
            */
            return default;
        }

        public async Task<TEntity> LoadOnboardingBarScenarioAsync<TEntity>(IEnumerable<TEntity> entities, object with_demo_data) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py) ---
            // def load_onboarding_bar_scenario(self, with_demo_data=True):
            // journal, payment_methods_ids = self._create_journal_and_payment_methods(cash_journal_vals={'name': 'Cash Bar', 'show_on_dashboard': False})
            // config = self.env['pos.config'].create({
            //     'name': 'Bar',
            //     'company_id': self.env.company.id,
            //     'journal_id': journal.id,
            //     'payment_method_ids': payment_methods_ids,
            //     'iface_splitbill': True,
            //     'module_pos_restaurant': True,
            //     'default_screen': 'register'
            // })
            // self.env['ir.model.data']._update_xmlids([{
            //     'xml_id': self._get_suffixed_ref_name('pos_restaurant.pos_config_main_bar'),
            //     'record': config,
            //     'noupdate': True,
            // }])
            // if not self.env.ref('pos_restaurant.floor_main', raise_if_not_found=False):
            //     convert.convert_file(self._env_with_clean_context(), 'pos_restaurant', 'data/scenarios/restaurant_floor.xml', idref=None, mode='init', noupdate=True)
            // config_floors = [(5, 0)]
            // if (floor_main := self.env.ref('pos_restaurant.floor_main', raise_if_not_found=False)):
            //     config_floors += [(4, floor_main.id)]
            // if (floor_patio := self.env.ref('pos_restaurant.floor_patio', raise_if_not_found=False)):
            //     config_floors += [(4, floor_patio.id)]
            // config.update({'floor_ids': config_floors})
            // config._load_bar_demo_data(with_demo_data)
            // return {'config_id': config.id}
            */
            return default;
        }

        public async Task<TEntity> LoadOnboardingClothesDemoDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_demo_data) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _load_onboarding_clothes_demo_data(self, with_demo_data=True):
            // self.ensure_one()
            // convert.convert_file(self._env_with_clean_context(), 'point_of_sale', 'data/scenarios/clothes_category_data.xml', idref=None, mode='init', noupdate=True)
            // if with_demo_data:
            //     product_module = self.env['ir.module.module'].search([('name', '=', 'product')])
            //     if not product_module.demo:
            //         convert.convert_file(self._env_with_clean_context(), 'product', 'data/product_attribute_demo.xml', idref=None, mode='init', noupdate=True)
            //     convert.convert_file(self._env_with_clean_context(), 'point_of_sale', 'data/scenarios/clothes_data.xml', idref=None, mode='init', noupdate=True)
            // clothes_categories = self.get_record_by_ref([
            //     'point_of_sale.pos_category_upper',
            //     'point_of_sale.pos_category_lower',
            //     'point_of_sale.pos_category_others'
            // ])
            // if clothes_categories:
            //     self.limit_categories = True
            //     self.iface_available_categ_ids = clothes_categories
            */
            return default;
        }

        public async Task<TEntity> LoadOnboardingClothesScenarioAsync<TEntity>(IEnumerable<TEntity> entities, object with_demo_data) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def load_onboarding_clothes_scenario(self, with_demo_data=True):
            // journal, payment_methods_ids = self._create_journal_and_payment_methods(
            //     cash_journal_vals={'name': _('Cash Clothes Shop'), 'show_on_dashboard': False})
            // config = self.env['pos.config'].create([{
            //     'name': _('Clothes Shop'),
            //     'company_id': self.env.company.id,
            //     'journal_id': journal.id,
            //     'payment_method_ids': payment_methods_ids
            // }])
            // self.env['ir.model.data']._update_xmlids([{
            //     'xml_id': self._get_suffixed_ref_name('point_of_sale.pos_config_clothes'),
            //     'record': config,
            //     'noupdate': True,
            // }])
            // config._load_onboarding_clothes_demo_data(with_demo_data)
            // return {'config_id': config.id}
            */
            return default;
        }

        public async Task<TEntity> LoadOnboardingFurnitureDemoDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_demo_data) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _load_onboarding_furniture_demo_data(self, with_demo_data=False):
            // self.ensure_one()
            // convert.convert_file(self._env_with_clean_context(), 'point_of_sale', 'data/scenarios/furniture_category_data.xml', idref=None, mode='init', noupdate=True)
            // if with_demo_data:
            //     product_module = self.env['ir.module.module'].search([('name', '=', 'product')])
            //     if not product_module.demo:
            //         convert.convert_file(self._env_with_clean_context(), 'product', 'data/product_category_demo.xml', idref=None, mode='init', noupdate=True)
            //         convert.convert_file(self._env_with_clean_context(), 'product', 'data/product_attribute_demo.xml', idref=None, mode='init', noupdate=True)
            //         convert.convert_file(self._env_with_clean_context(), 'product', 'data/product_demo.xml', idref=None, mode='init', noupdate=True)
            //     convert.convert_file(self._env_with_clean_context(), 'point_of_sale', 'data/scenarios/furniture_data.xml', idref=None, mode='init', noupdate=True)
            // 
            // furniture_categories = self.get_record_by_ref([
            //     'point_of_sale.pos_category_miscellaneous',
            //     'point_of_sale.pos_category_desks',
            //     'point_of_sale.pos_category_chairs'
            // ])
            // if furniture_categories:
            //     self.limit_categories = True
            //     self.iface_available_categ_ids = furniture_categories
            */
            return default;
        }

        public async Task<TEntity> LoadOnboardingFurnitureScenarioAsync<TEntity>(IEnumerable<TEntity> entities, object with_demo_data) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def load_onboarding_furniture_scenario(self, with_demo_data=True):
            // journal, payment_methods_ids = self._create_journal_and_payment_methods(
            //     cash_ref='point_of_sale.cash_payment_method_furniture',
            //     cash_journal_vals={'name': _("Cash Furn. Shop"), 'show_on_dashboard': False},
            // )
            // config = self.env['pos.config'].create([{
            //     'name': _('Furniture Shop'),
            //     'company_id': self.env.company.id,
            //     'journal_id': journal.id,
            //     'payment_method_ids': payment_methods_ids
            // }])
            // self.env['ir.model.data']._update_xmlids([{
            //     'xml_id': self._get_suffixed_ref_name('point_of_sale.pos_config_main'),
            //     'record': config,
            //     'noupdate': True,
            // }])
            // config._load_onboarding_furniture_demo_data(with_demo_data)
            // existing_session = self.env.ref('point_of_sale.pos_closed_session_2', raise_if_not_found=False)
            // if with_demo_data and self.env.company.id == self.env.ref('base.main_company').id and not existing_session:
            //     convert.convert_file(self._env_with_clean_context(), 'point_of_sale', 'data/orders_demo.xml', idref=None, mode='init', noupdate=True)
            // return {'config_id': config.id}
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: pos_config.py) ---
            // def load_onboarding_furniture_scenario(self, with_demo_data=True):
            // res = super().load_onboarding_furniture_scenario(with_demo_data)
            // self._ensure_downpayment_product()
            // return res
            */
            return default;
        }

        public async Task<TEntity> LoadOnboardingKioskScenarioAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def load_onboarding_kiosk_scenario(self):
            // if not bool(self.env.company.chart_template):
            //     return False
            // 
            // journal, payment_methods_ids = self._create_journal_and_payment_methods()
            // restaurant_categories = self.get_record_by_ref([
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
            //     'self_ordering_pay_after': 'each',
            // })
            */
            return default;
        }

        public async Task<TEntity> LoadOnboardingRestaurantScenarioAsync<TEntity>(IEnumerable<TEntity> entities, object with_demo_data) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py) ---
            // def load_onboarding_restaurant_scenario(self, with_demo_data=True):
            // journal, payment_methods_ids = self._create_journal_and_payment_methods(cash_journal_vals={'name': _('Cash Restaurant'), 'show_on_dashboard': False})
            // presets = self.get_record_by_ref([
            //     'pos_restaurant.pos_takein_preset',
            //     'pos_restaurant.pos_takeout_preset',
            //     'pos_restaurant.pos_delivery_preset',
            // ]) + self.env['pos.preset'].search([]).ids
            // config = self.env['pos.config'].create({
            //     'name': _('Restaurant'),
            //     'company_id': self.env.company.id,
            //     'journal_id': journal.id,
            //     'payment_method_ids': payment_methods_ids,
            //     'iface_splitbill': True,
            //     'module_pos_restaurant': True,
            //     'use_presets': bool(presets),
            //     'default_preset_id': presets[0] if presets else False,
            //     'available_preset_ids': [(6, 0, presets)],
            // })
            // self.env['ir.model.data']._update_xmlids([{
            //     'xml_id': self._get_suffixed_ref_name('pos_restaurant.pos_config_main_restaurant'),
            //     'record': config,
            //     'noupdate': True,
            // }])
            // if bool(presets):
            //     # Ensure the "Presets" menu is visible when installing the restaurant scenario
            //     self.env.ref("point_of_sale.group_pos_preset").implied_by_ids |= self.env.ref("base.group_user")
            // if not self.env.ref('pos_restaurant.floor_main', raise_if_not_found=False):
            //     convert.convert_file(self._env_with_clean_context(), 'pos_restaurant', 'data/scenarios/restaurant_floor.xml', idref=None, mode='init', noupdate=True)
            // config_floors = [(5, 0)]
            // if (floor_main := self.env.ref('pos_restaurant.floor_main', raise_if_not_found=False)):
            //     config_floors += [(4, floor_main.id)]
            // if (floor_patio := self.env.ref('pos_restaurant.floor_patio', raise_if_not_found=False)):
            //     config_floors += [(4, floor_patio.id)]
            // config.update({'floor_ids': config_floors})
            // config._load_restaurant_demo_data(with_demo_data)
            // existing_session = self.env.ref('pos_restaurant.pos_closed_session_3', raise_if_not_found=False)
            // if with_demo_data and self.env.company.id == self.env.ref('base.main_company').id and not existing_session:
            //     convert.convert_file(self._env_with_clean_context(), 'pos_restaurant', 'data/scenarios/restaurant_demo_session.xml', idref=None, mode='init', noupdate=True)
            // return {'config_id': config.id}
            */
            return default;
        }

        public async Task<TEntity> LoadOnboardingRetailScenarioAsync<TEntity>(IEnumerable<TEntity> entities, object with_demo_data) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def load_onboarding_retail_scenario(self, with_demo_data=False):
            // journal, payment_methods_ids = self._create_journal_and_payment_methods(
            //     cash_journal_vals={'name': _("Cash %s", self.env.company.name), 'show_on_dashboard': False},
            // )
            // config = self.env['pos.config'].create([{
            //     'name': self.env.company.name,
            //     'company_id': self.env.company.id,
            //     'journal_id': journal.id,
            //     'payment_method_ids': payment_methods_ids
            // }])
            // self.env['ir.model.data']._update_xmlids([{
            //     'xml_id': self._get_suffixed_ref_name('point_of_sale.pos_config_retail'),
            //     'record': config,
            //     'noupdate': True,
            // }])
            // return {'config_id': config.id}
            */
            return default;
        }

        public async Task<TEntity> LoadPosDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _load_pos_data_domain(self, data, config):
            // return [('id', '=', config.id)]
            */
            return default;
        }

        public async Task<TEntity> LoadPosDataReadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object records, object config) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _load_pos_data_read(self, records, config):
            // read_records = super()._load_pos_data_read(records, config)
            // if not read_records:
            //     return read_records
            // 
            // record = read_records[0]
            // record['_server_version'] = exp_version()
            // record['_base_url'] = self.get_base_url()
            // record['_data_server_date'] = self.env.context.get('pos_last_server_date') or self.env.cr.now()
            // record['_has_cash_move_perm'] = self.env.user.has_group('account.group_account_invoice')
            // record['_has_cash_delete_perm'] = self.env.user.has_group('account.group_account_basic')
            // record['_pos_special_products_ids'] = self.env['pos.config']._get_special_products().ids
            // 
            // # Add custom fields for 'formula' taxes.
            // # We can ignore data for _load_pos_data_domain since isn't needed in the domain computation of account.tax
            // taxes = self.env['account.tax'].search(self.env['account.tax']._load_pos_data_domain({}, config))
            // product_fields = taxes._eval_taxes_computation_prepare_product_fields()
            // record['_product_default_values'] = \
            //     self.env['account.tax']._eval_taxes_computation_prepare_product_default_values(product_fields)
            // 
            // if not record['use_pricelist']:
            //     record['pricelist_id'] = False
            // record['_IS_VAT'] = self.env.company.country_id.id in self.env.ref("base.europe").country_ids.ids
            // return read_records
            */
            return default;
        }

        public async Task<TEntity> LoadPosSelfDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _load_pos_self_data_domain(self, data, config):
            // return [('id', '=', config.id)]
            */
            return default;
        }

        public async Task<TEntity> LoadPosSelfDataReadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object records, object config) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _load_pos_self_data_read(self, records, config):
            // read_records = super()._load_pos_data_read(records, config)
            // if not read_records:
            //     return read_records
            // record = read_records[0]
            // record['_self_ordering_image_home_ids'] = config.self_ordering_image_home_ids.ids
            // record['_self_ordering_image_background_ids'] = config.self_ordering_image_background_ids.ids
            // record['_pos_special_products_ids'] = config._get_special_products().ids
            // record['_self_ordering_style'] = {
            //     'primaryBgColor': self.env.company.email_secondary_color,
            //     'primaryTextColor': self.env.company.email_primary_color,
            // }
            // record['_self_order_pos'] = True
            // return read_records
            */
            return default;
        }

        public async Task<TEntity> LoadRestaurantDemoDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_demo_data) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py) ---
            // def _load_restaurant_demo_data(self, with_demo_data=True):
            // self.ensure_one()
            // convert.convert_file(self._env_with_clean_context(), 'pos_restaurant', 'data/scenarios/restaurant_category_data.xml', idref=None, mode='init', noupdate=True)
            // if with_demo_data:
            //     convert.convert_file(self._env_with_clean_context(), 'pos_restaurant', 'data/scenarios/restaurant_demo_data.xml', idref=None, mode='init', noupdate=True)
            // restaurant_categories = self.get_record_by_ref([
            //     'pos_restaurant.food',
            //     'pos_restaurant.drinks',
            // ])
            // if restaurant_categories:
            //     self.limit_categories = True
            //     self.iface_available_categ_ids = restaurant_categories
            */
            return default;
        }

        public async Task<TEntity> LoadSelfDataAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def load_self_data(self):
            // response = {}
            // response['pos.config'] = self.env['pos.config']._load_pos_self_data_search_read(response, self)
            // 
            // for model in self._load_self_data_models():
            //     try:
            //         response[model] = self.env[model]._load_pos_self_data_search_read(response, self)
            //     except AccessError:
            //         response[model] = []
            // 
            // return response
            */
            return default;
        }

        public async Task<TEntity> LoadSelfDataModelsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _load_self_data_models(self):
            // return ['pos.session', 'pos.preset', 'resource.calendar.attendance', 'pos.order', 'pos.order.line', 'pos.payment', 'pos.payment.method', 'res.partner',
            //     'res.currency', 'pos.category', 'product.template', 'product.product', 'product.combo', 'product.combo.item', 'res.company', 'account.tax',
            //     'account.tax.group', 'pos.printer', 'res.country', 'product.category', 'product.pricelist', 'product.pricelist.item', 'account.fiscal.position',
            //     'res.lang', 'product.attribute', 'product.attribute.custom.value', 'product.template.attribute.line', 'product.template.attribute.value', 'product.tag',
            //     'decimal.precision', 'uom.uom', 'pos.printer', 'pos_self_order.custom_link', 'restaurant.floor', 'restaurant.table', 'account.cash.rounding',
            //     'res.country', 'res.country.state', 'mail.template']
            */
            return default;
        }

        public async Task<TEntity> NotifySynchronisationAsync<TEntity>(IEnumerable<TEntity> entities, Guid session_id, object device_identifier, object records) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def notify_synchronisation(self, session_id, device_identifier, records={}):
            // self.ensure_one()
            // static_records = {}
            // 
            // for model, ids in records.items():
            //     records = self.env[model].browse(ids).exists()
            //     static_records[model] = self.env[model]._load_pos_data_read(records, self)
            // 
            // self._notify('SYNCHRONISATION', {
            //     'static_records': static_records,
            //     'session_id': session_id,
            //     'device_identifier': device_identifier,
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
            return default;
        }

        public async Task<TEntity> OnchangeAdvancedEmployeeIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_hr, FILE: pos_config.py) ---
            // def _onchange_advanced_employee_ids(self):
            // for employee in self.advanced_employee_ids:
            //     if employee in self.basic_employee_ids:
            //         self.basic_employee_ids -= employee
            //     if employee in self.minimal_employee_ids:
            //         self.minimal_employee_ids -= employee
            */
            return default;
        }

        public async Task<TEntity> OnchangeBasicEmployeeIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_hr, FILE: pos_config.py) ---
            // def _onchange_basic_employee_ids(self):
            // for employee in self.basic_employee_ids:
            //     if employee.user_id._has_group('point_of_sale.group_pos_manager'):
            //         self.basic_employee_ids -= employee
            //     elif employee in self.advanced_employee_ids:
            //         self.advanced_employee_ids -= employee
            //     elif employee in self.minimal_employee_ids:
            //         self.minimal_employee_ids -= employee
            */
            return default;
        }

        public async Task<TEntity> OnchangeEpsonPrinterIpInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _onchange_epson_printer_ip(self):
            // for rec in self:
            //     if rec.epson_printer_ip:
            //         rec.epson_printer_ip = format_epson_certified_domain(rec.epson_printer_ip)
            */
            return default;
        }

        public async Task<TEntity> OnchangeMinimalEmployeeIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_hr, FILE: pos_config.py) ---
            // def _onchange_minimal_employee_ids(self):
            // for employee in self.minimal_employee_ids:
            //     if employee.user_id._has_group('point_of_sale.group_pos_manager'):
            //         self.minimal_employee_ids -= employee
            //     elif employee in self.basic_employee_ids:
            //         self.basic_employee_ids -= employee
            //     elif employee in self.advanced_employee_ids:
            //         self.advanced_employee_ids -= employee
            */
            return default;
        }

        public async Task<TEntity> OnchangePaymentMethodIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _onchange_payment_method_ids(self):
            // if any(record.self_ordering_mode == 'kiosk' and any(pm.is_cash_count for pm in record.payment_method_ids) for record in self):
            //     raise ValidationError(_("You cannot add cash payment methods in kiosk mode."))
            */
            return default;
        }

        public async Task<TEntity> OpenExistingSessionCbAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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
            return default;
        }

        public async Task<TEntity> OpenOpenedRescueSessionFormAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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
            return default;
        }

        public async Task<TEntity> OpenSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid session_id) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> OpenUiAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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
            //     res = self._check_before_creating_new_session()
            //     if res:
            //         return res
            // self._validate_fields(self._fields)
            // 
            // self._check_company_has_fiscal_country()
            // return self._action_to_open_ui()
            --- ODOO METHOD SOURCE (MODULE: pos_discount, FILE: pos_config.py) ---
            // def open_ui(self):
            // for config in self:
            //     if not self.current_session_id and config.module_pos_discount and not config.discount_product_id:
            //         raise UserError(_('A discount product is needed to use the Global Discount feature. Go to Point of Sale > Configuration > Settings to set it.'))
            // return super().open_ui()
            */
            return default;
        }

        public async Task<TEntity> PrepareSelfOrderCustomBtnInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> PrepareSelfOrderSplashScreenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list, object is_new) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _prepare_self_order_splash_screen(self, vals_list, is_new=False):
            // for vals in vals_list:
            //     if not vals.get('self_ordering_mode'):
            //         return True
            // 
            //     if not vals.get('self_ordering_image_home_ids'):
            //         vals['self_ordering_image_home_ids'] = [(0, 0, {
            //             'name': image_name,
            //             'type': 'url',
            //             'url': f'/pos_self_order/static/img/{image_name}',
            //             'res_model': 'pos.config',
            //         }) for image_name in ['landing_01.jpg', 'landing_02.jpg', 'landing_03.jpg']]
            // 
            //     if is_new and not vals.get('self_ordering_image_background_ids'):
            //         vals['self_ordering_image_background_ids'] = [(0, 0, {
            //             'name': "background.jpg",
            //             'type': 'url',
            //             'url': '/pos_self_order/static/img/kiosk_background.jpg',
            //             'res_model': 'pos.config',
            //         })]
            // 
            // return True
            */
            return default;
        }

        public async Task<TEntity> PreprocessX2manyValsFromSettingsViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> PreviewSelfOrderAppAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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
            return default;
        }

        public async Task<TEntity> ReadConfigOpenOrdersAsync<TEntity>(IEnumerable<TEntity> entities, object domain, List<Guid> record_ids) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def read_config_open_orders(self, domain, record_ids=[]):
            // delete_record_ids = {}
            // dynamic_records = {}
            // 
            // for model, dom in domain.items():
            //     ids = record_ids.get(model, [])
            //     browsed = self.env[model].browse(ids)
            // 
            //     dynamic_records[model] = self.env[model].search(dom)
            //     delete_record_ids[model] = browsed.filtered(lambda r: not r.exists()).ids
            //     # Cancelled orders must be forced deleted from the user interface.
            //     if model == "pos.order":
            //         delete_record_ids[model] += browsed.filtered(lambda r: r.state == "cancel").ids
            // 
            // pos_order_data = dynamic_records.get('pos.order') or self.env['pos.order']
            // data = pos_order_data.read_pos_data([], self)
            // 
            // for key, records in dynamic_records.items():
            //     fields = self.env[key]._load_pos_data_fields(self)
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
            return default;
        }

        public async Task<TEntity> RegisterNewDeviceIdentifierAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def register_new_device_identifier(self):
            // self.ensure_one()
            // identifier = self.device_seq_id._next()
            // return {
            //     'device_identifier': identifier,
            // }
            */
            return default;
        }

        public async Task<TEntity> RemoveTrustedConfigIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid config_id) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _remove_trusted_config_id(self, config_id):
            // self.trusted_config_ids -= config_id
            */
            return default;
        }

        public async Task<TEntity> ResetDefaultOnValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> SelfOrderDefaultUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> SelfOrderKioskDefaultLanguagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _self_order_kiosk_default_languages(self):
            // return self.env["res.lang"].get_installed()
            */
            return default;
        }

        public async Task<TEntity> SetDefaultPosLoadLimitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _set_default_pos_load_limit(self):
            // param_model = self.env["ir.config_parameter"]
            // if not param_model.get_param("point_of_sale.limited_product_count"):
            //     param_model.set_param("point_of_sale.limited_product_count", DEFAULT_LIMIT_LOAD_PRODUCT)
            // 
            // if not param_model.get_param("point_of_sale.limited_customer_count"):
            //     param_model.set_param("point_of_sale.limited_customer_count", DEFAULT_LIMIT_LOAD_PARTNER)
            */
            return default;
        }

        public async Task<TEntity> SetFiscalPositionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> SetupDefaultFloorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object pos_config) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<List<Dictionary<string, object>>> SplitQrCodesListInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Dictionary<string, object>> floors, int cols) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _split_qr_codes_list(self, floors: List[Dict], cols: int) -> List[Dict]:
            // """
            // :param floors: the list of floors
            // :param cols: the number of qr codes per row
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

        public async Task<TEntity> SupportedKioskPaymentTerminalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _supported_kiosk_payment_terminal(self):
            // return ['adyen', 'razorpay', 'stripe', 'pine_labs']
            --- ODOO METHOD SOURCE (MODULE: pos_self_order_qfpay, FILE: pos_config.py) ---
            // def _supported_kiosk_payment_terminal(self):
            // res = super()._supported_kiosk_payment_terminal()
            // res.append('qfpay')
            // return res
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def unlink(self):
            // # Delete the pos.config records first then delete the sequences linked to them
            // sequences_to_delete = self.order_line_seq_id | self.device_seq_id
            // res = super(PosConfig, self).unlink()
            // sequences_to_delete.unlink()
            // return res
            */
            return default;
        }

        public async Task<TEntity> UpdateAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py) ---
            // def _update_access_token(self):
            // self.access_token = uuid.uuid4().hex[:16]
            // self.floor_ids.table_ids._update_identifier()
            */
            return default;
        }

        public async Task<TEntity> UpdateCustomerDisplayAsync<TEntity>(IEnumerable<TEntity> entities, object order, object device_uuid) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def update_customer_display(self, order, device_uuid):
            // self.ensure_one()
            // self._notify(f"UPDATE_CUSTOMER_DISPLAY-{device_uuid}", order)
            */
            return default;
        }

        public async Task<TEntity> UpdateEventsSeatsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object events) where TEntity : IEntity<Guid>, IHrMixinable
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
            //         } for ticket in event.event_ticket_ids],
            //         'event_slot_ids': [{
            //             'slot_id': slot.id,
            //             'seats_available': slot.seats_available
            //         } for slot in event.event_slot_ids]
            //     })
            // 
            // for record in self:
            //     record._notify('UPDATE_AVAILABLE_SEATS', data)
            */
            return default;
        }

        public async Task<TEntity> UpdatePreparationPrintersMenuitemVisibilityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
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

        public async Task<TEntity> UseCouponCodeAsync<TEntity>(IEnumerable<TEntity> entities, object code, object creation_date, Guid partner_id, Guid pricelist_id) where TEntity : IEntity<Guid>, IHrMixinable
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
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_mixin.py) ---
            // def write(self, vals):
            // special_self = self.with_context(_allow_read_hr_employee=_ALLOW_READ_HR_EMPLOYEE)
            // return super(HrMixin, special_self).write(vals)
            --- ODOO METHOD SOURCE (MODULE: pos_hr, FILE: pos_config.py) ---
            // def write(self, vals):
            // if 'advanced_employee_ids' not in vals:
            //     vals['advanced_employee_ids'] = []
            // vals['advanced_employee_ids'] += [(4, emp_id) for emp_id in self._get_group_pos_manager().user_ids.employee_id.ids]
            // 
            // # write employees in sudo, because we have no access to these corecords
            // sudo_vals = {
            //     field_name: value
            //     for field_name in ('minimal_employee_ids', 'basic_employee_ids', 'advanced_employee_ids')
            //     if not self.env.su
            //     if (value := vals.pop(field_name, ()))
            // }
            // 
            // res = super().write(vals)
            // if sudo_vals:
            //     super(PosConfig, self.sudo()).write(sudo_vals)
            // return res
            */
            return default;
        }
    }
}