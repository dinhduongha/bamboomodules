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
    [Module("Account", Category = "Accounting", Depends = new[] { "base_setup", "onboarding", "product", "analytic", "portal", "digest" })]
    public class AccountMoveLineAppService : GenericApplicationService<AccountMoveLine>, IAccountMoveLineAppService
    {
        private readonly IAnalyticMixinAppService _analyticMixinAppService;
        public AccountMoveLineAppService(IRepository<AccountMoveLine, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IAnalyticMixinAppService analyticMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _analyticMixinAppService = analyticMixinAppService;
        }

        protected async Task<AccountMoveLine> AddExchangeDifferenceCashBasisValsInternalAsync(object exchange_diff_vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _add_exchange_difference_cash_basis_vals(self, exchange_diff_vals):
            // """ Generate the exchange difference values used to create the journal items
            // in order to fix the cash basis lines using the transfer account in a multi-currencies
            // environment when this account is not a reconcile one.
            // When the tax cash basis journal entries are generated and all involved
            // transfer account set on taxes are all reconcilable, the account balance
            // will be reset to zero by the exchange difference journal items generated
            // above. However, this mechanism will not work if there is any transfer
            // accounts that are not reconcile and we are generating the cash basis
            // journal items in a foreign currency. In that specific case, we need to
            // generate extra journal items at the generation of the exchange difference
            // journal entry to ensure this balance is reset to zero and then, will not
            // appear on the tax report leading to erroneous tax base amount / tax amount.
            // :param exchange_diff_vals:  The current vals of the exchange difference journal entry created by the
            //                             '_prepare_exchange_difference_move_vals' method.
            // """
            // caba_lines_to_reconcile = defaultdict(lambda: self.env['account.move.line']) # in the form {(move, account, repartition_line): move_lines}
            // move_vals = exchange_diff_vals['move_values']
            // for move in self.move_id:
            //     account_vals_to_fix = {}
            // 
            //     move_values = move._collect_tax_cash_basis_values()
            // 
            //     # The cash basis doesn't need to be handled for this move because there is another payment term
            //     # line that is not yet fully paid.
            //     if not move_values or not move_values['is_fully_paid']:
            //         continue
            // 
            //     # ==========================================================================
            //     # Add the balance of all tax lines of the current move in order in order
            //     # to compute the residual amount for each of them.
            //     # ==========================================================================
            // 
            //     caba_rounding_diff_label = _("Cash basis rounding difference")
            //     move_vals['date'] = max(move_vals['date'], move.date)
            //     move_vals['journal_id'] = self.company_id.tax_cash_basis_journal_id.id
            //     for caba_treatment, line in move_values['to_process_lines']:
            // 
            //         vals = {
            //             'name': caba_rounding_diff_label,
            //             'currency_id': line.currency_id.id,
            //             'partner_id': line.partner_id.id,
            //             'tax_ids': [Command.set(line.tax_ids.ids)],
            //             'tax_tag_ids': [Command.set(line.tax_tag_ids.ids)],
            //             'debit': line.debit,
            //             'credit': line.credit,
            //             'amount_currency': line.amount_currency,
            //         }
            // 
            //         if caba_treatment == 'tax':
            //             # Tax line.
            //             grouping_key = self.env['account.partial.reconcile']._get_cash_basis_tax_line_grouping_key_from_record(line)
            //             if grouping_key in account_vals_to_fix:
            //                 debit = account_vals_to_fix[grouping_key]['debit'] + vals['debit']
            //                 credit = account_vals_to_fix[grouping_key]['credit'] + vals['credit']
            //                 balance = debit - credit
            // 
            //                 account_vals_to_fix[grouping_key].update({
            //                     'debit': balance if balance > 0 else 0,
            //                     'credit': -balance if balance < 0 else 0,
            //                     'tax_base_amount': account_vals_to_fix[grouping_key]['tax_base_amount'] + line.tax_base_amount,
            //                     'amount_currency': account_vals_to_fix[grouping_key]['amount_currency'] + line.amount_currency,
            //                 })
            //             else:
            //                 account_vals_to_fix[grouping_key] = {
            //                     **vals,
            //                     'account_id': line.account_id.id,
            //                     'tax_base_amount': line.tax_base_amount,
            //                     'tax_repartition_line_id': line.tax_repartition_line_id.id,
            //                 }
            // 
            //             if line.account_id.reconcile:
            //                 caba_lines_to_reconcile[(move, line.account_id, line.tax_repartition_line_id)] |= line
            // 
            //         elif caba_treatment == 'base':
            //             # Base line.
            //             account_to_fix = line.company_id.account_cash_basis_base_account_id
            //             if not account_to_fix:
            //                 continue
            // 
            //             grouping_key = self.env['account.partial.reconcile']._get_cash_basis_base_line_grouping_key_from_record(line, account=account_to_fix)
            // 
            //             if grouping_key not in account_vals_to_fix:
            //                 account_vals_to_fix[grouping_key] = {
            //                     **vals,
            //                     'account_id': account_to_fix.id,
            //                 }
            //             else:
            //                 # Multiple base lines could share the same key, if the same
            //                 # cash basis tax is used alone on several lines of the invoices
            //                 account_vals_to_fix[grouping_key]['debit'] += vals['debit']
            //                 account_vals_to_fix[grouping_key]['credit'] += vals['credit']
            //                 account_vals_to_fix[grouping_key]['amount_currency'] += vals['amount_currency']
            // 
            //     # ==========================================================================
            //     # Subtract the balance of all previously generated cash basis journal entries
            //     # in order to retrieve the residual balance of each involved transfer account.
            //     # ==========================================================================
            // 
            //     cash_basis_moves = self.env['account.move'].search([('tax_cash_basis_origin_move_id', '=', move.id)])
            //     caba_transition_accounts = self.env['account.account']
            //     for line in cash_basis_moves.line_ids:
            //         grouping_key = None
            //         if line.tax_repartition_line_id:
            //             # Tax line.
            //             transition_account = line.tax_line_id.cash_basis_transition_account_id
            //             grouping_key = self.env['account.partial.reconcile']._get_cash_basis_tax_line_grouping_key_from_record(
            //                 line,
            //                 account=transition_account,
            //             )
            //             caba_transition_accounts |= transition_account
            //         elif line.tax_ids:
            //             # Base line.
            //             grouping_key = self.env['account.partial.reconcile']._get_cash_basis_base_line_grouping_key_from_record(
            //                 line,
            //                 account=line.company_id.account_cash_basis_base_account_id,
            //             )
            // 
            //         if grouping_key not in account_vals_to_fix:
            //             continue
            // 
            //         account_vals_to_fix[grouping_key]['debit'] -= line.debit
            //         account_vals_to_fix[grouping_key]['credit'] -= line.credit
            //         account_vals_to_fix[grouping_key]['amount_currency'] -= line.amount_currency
            // 
            //     # Collect the caba lines affecting the transition account.
            //     for transition_line in filter(lambda x: x.account_id in caba_transition_accounts, cash_basis_moves.line_ids):
            //         caba_reconcile_key = (transition_line.move_id, transition_line.account_id, transition_line.tax_repartition_line_id)
            //         caba_lines_to_reconcile[caba_reconcile_key] |= transition_line
            // 
            //     # ==========================================================================
            //     # Generate the exchange difference journal items:
            //     # - to reset the balance of all transfer account to zero.
            //     # - fix rounding issues on the tax account/base tax account.
            //     # ==========================================================================
            // 
            //     currency = move_values['currency']
            // 
            //     # To know which rate to use for the adjustment, get the rate used by the most recent cash basis move
            //     last_caba_move = max(cash_basis_moves, key=lambda m: m.date) if cash_basis_moves else self.env['account.move']
            //     currency_line = last_caba_move.line_ids.filtered(lambda x: x.currency_id == currency)[:1]
            //     currency_rate = currency_line.balance / currency_line.amount_currency if currency_line.amount_currency else 1.0
            // 
            //     existing_line_vals_list = move_vals['line_ids']
            //     next_sequence = len(existing_line_vals_list)
            //     for grouping_key, values in account_vals_to_fix.items():
            // 
            //         if currency.is_zero(values['amount_currency']):
            //             continue
            // 
            //         # There is a rounding error due to multiple payments on the foreign currency amount
            //         balance = currency.round(currency_rate * values['amount_currency'])
            // 
            //         if values.get('tax_repartition_line_id'):
            //             # Tax line
            //             tax_repartition_line = self.env['account.tax.repartition.line'].browse(values['tax_repartition_line_id'])
            //             account = tax_repartition_line.account_id or self.env['account.account'].browse(values['account_id'])
            // 
            //             existing_line_vals_list.extend([
            //                 Command.create({
            //                     **values,
            //                     'debit': balance if balance > 0.0 else 0.0,
            //                     'credit': -balance if balance < 0.0 else 0.0,
            //                     'amount_currency': values['amount_currency'],
            //                     'account_id': account.id,
            //                     'sequence': next_sequence,
            //                 }),
            //                 Command.create({
            //                     **values,
            //                     'debit': -balance if balance < 0.0 else 0.0,
            //                     'credit': balance if balance > 0.0 else 0.0,
            //                     'amount_currency': -values['amount_currency'],
            //                     'account_id': values['account_id'],
            //                     'tax_ids': [],
            //                     'tax_tag_ids': [],
            //                     'tax_base_amount': 0,
            //                     'tax_repartition_line_id': False,
            //                     'sequence': next_sequence + 1,
            //                 }),
            //             ])
            //         else:
            //             # Base line
            //             existing_line_vals_list.extend([
            //                 Command.create({
            //                     **values,
            //                     'debit': balance if balance > 0.0 else 0.0,
            //                     'credit': -balance if balance < 0.0 else 0.0,
            //                     'amount_currency': values['amount_currency'],
            //                     'sequence': next_sequence,
            //                 }),
            //                 Command.create({
            //                     **values,
            //                     'debit': -balance if balance < 0.0 else 0.0,
            //                     'credit': balance if balance > 0.0 else 0.0,
            //                     'amount_currency': -values['amount_currency'],
            //                     'tax_ids': [],
            //                     'tax_tag_ids': [],
            //                     'sequence': next_sequence + 1,
            //                 }),
            //             ])
            // 
            //         next_sequence += 2
            // 
            // return caba_lines_to_reconcile
            */
            return default;
        }

        public async Task<AccountMoveLine> AddFromCatalogAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def action_add_from_catalog(self):
            // """ Will open the catalog view """
            // move = self.env['account.move'].browse(self.env.context.get('order_id'))
            // return move.action_add_from_catalog()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMoveLine> AffectTaxReportInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _affect_tax_report(self):
            // self.ensure_one()
            // return self.tax_ids or self.tax_line_id or self.tax_tag_ids.filtered(lambda x: x.applicability == "taxes")
            */
            return default;
        }

        protected async Task<AccountMoveLine> AllReconciledLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _all_reconciled_lines(self):
            // """Get all the the lines matched with the lines in self."""
            // return self._filter_reconciled_by_number(self._reconciled_by_number())
            */
            return default;
        }

        protected async Task<AccountMoveLine> ApplyPriceDifferenceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: account_move_line.py) ---
            // def _apply_price_difference(self):
            // svl_vals_list = []
            // aml_vals_list = []
            // for line in self:
            //     line = line.with_company(line.company_id)
            //     po_line = line.purchase_line_id
            //     uom = line.product_uom_id or line.product_id.uom_id
            // 
            //     # Don't create value for more quantity than received
            //     quantity = po_line.qty_received - (po_line.qty_invoiced - line.quantity)
            //     quantity = max(min(line.quantity, quantity), 0)
            //     if float_is_zero(quantity, precision_rounding=uom.rounding):
            //         continue
            // 
            //     layers = line._get_valued_in_moves().stock_valuation_layer_ids.filtered(lambda svl: svl.product_id == line.product_id and not svl.stock_valuation_layer_id)
            //     if not layers:
            //         continue
            // 
            //     new_svl_vals_list, new_aml_vals_list = line._generate_price_difference_vals(layers)
            //     svl_vals_list += new_svl_vals_list
            //     aml_vals_list += new_aml_vals_list
            // return self.env['stock.valuation.layer'].sudo().create(svl_vals_list), self.env['account.move.line'].sudo().create(aml_vals_list)
            */
            return default;
        }

        public async Task<AccountMoveLine> AssetCreateAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_move.py) ---
            // def asset_create(self):
            // if self.asset_category_id:
            //     price_subtotal = self.currency_id._convert(
            //         self.price_subtotal,
            //         self.company_currency_id,
            //         self.company_id,
            //         self.move_id.invoice_date or fields.Date.context_today(
            //             self))
            //     vals = {
            //         'name': self.name,
            //         'code': self.name or False,
            //         'category_id': self.asset_category_id.id,
            //         'value': price_subtotal,
            //         'partner_id': self.move_id.partner_id.id,
            //         'company_id': self.move_id.company_id.id,
            //         'currency_id': self.move_id.company_currency_id.id,
            //         'date': self.move_id.invoice_date or self.move_id.date,
            //         'invoice_id': self.move_id.id,
            //     }
            //     changed_vals = self.env['account.asset.asset'].onchange_category_id_values(vals['category_id'])
            //     vals.update(changed_vals['value'])
            //     asset = self.env['account.asset.asset'].create(vals)
            //     if self.asset_category_id.open_asset:
            //         if asset.date_first_depreciation == 'manual':
            //             asset.first_depreciation_manual_date = asset.date
            //         asset.validate()
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMoveLine> AutomaticEntryAsync(Guid id, AccountMoveLineAutomaticEntryRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def action_automatic_entry(self, default_action=None):
            // action = self.env['ir.actions.act_window']._for_xml_id('account.account_automatic_entry_wizard_action')
            // # Force the values of the move line in the context to avoid issues
            // ctx = dict(self.env.context)
            // ctx.pop('active_id', None)
            // ctx.pop('default_journal_id', None)
            // ctx['active_ids'] = self.ids
            // ctx['active_model'] = 'account.move.line'
            // if default_action:
            //     ctx['default_action'] = default_action
            // action['context'] = ctx
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMoveLine> CheckAmlsExigibilityForReconciliationInternalAsync(object shadowed_aml_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _check_amls_exigibility_for_reconciliation(self, shadowed_aml_values=None):
            // """ Ensure the current journal items are eligible to be reconciled together.
            // :param shadowed_aml_values: A mapping aml -> dictionary to replace some original aml values to something else.
            //                             This is usefull if you want to preview the reconciliation before doing some changes
            //                             on amls like changing a date or an account.
            // """
            // if not self:
            //     return
            // 
            // if any(aml.reconciled for aml in self):
            //     raise UserError(_("You are trying to reconcile some entries that are already reconciled."))
            // if any(aml.parent_state != 'posted' for aml in self):
            //     raise UserError(_("You can only reconcile posted entries."))
            // accounts = self.mapped(lambda x: x._get_reconciliation_aml_field_value('account_id', shadowed_aml_values))
            // if len(accounts) > 1:
            //     raise UserError(_(
            //         "Entries are not from the same account: %s",
            //         ", ".join(accounts.mapped('display_name')),
            //     ))
            // if len(self.company_id.root_id) > 1:
            //     raise UserError(_(
            //         "Entries don't belong to the same company: %s",
            //         ", ".join(self.company_id.mapped('display_name')),
            //     ))
            // if not accounts.reconcile and accounts.account_type not in ('asset_cash', 'liability_credit_card'):
            //     raise UserError(_(
            //         "Account %s does not allow reconciliation. First change the configuration of this account "
            //         "to allow it.",
            //         accounts.display_name,
            //     ))
            */
            return default;
        }

        protected async Task<AccountMoveLine> CheckCabaNonCabaSharedTagsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _check_caba_non_caba_shared_tags(self):
            // """ When mixing cash basis and non cash basis taxes, it is important
            // that those taxes don't share tags on the repartition creating
            // a single account.move.line.
            // 
            // Shared tags in this context cannot work, as the tags would need to
            // be present on both the invoice and cash basis move, leading to the same
            // base amount to be taken into account twice; which is wrong.This is
            // why we don't support that. A workaround may be provided by the use of
            // a group of taxes, whose children are type_tax_use=None, and only one
            // of them uses the common tag.
            // 
            // Note that taxes of the same exigibility are allowed to share tags.
            // """
            // def get_base_repartition(base_aml, taxes):
            //     if not taxes:
            //         return self.env['account.tax.repartition.line']
            // 
            //     is_refund = base_aml.is_refund
            //     repartition_field = is_refund and 'refund_repartition_line_ids' or 'invoice_repartition_line_ids'
            //     return taxes.mapped(repartition_field)
            // 
            // for aml in self:
            //     caba_taxes = aml.tax_ids.filtered(lambda x: x.tax_exigibility == 'on_payment')
            //     non_caba_taxes = aml.tax_ids - caba_taxes
            // 
            //     caba_base_tags = get_base_repartition(aml, caba_taxes).filtered(lambda x: x.repartition_type == 'base').tag_ids
            //     non_caba_base_tags = get_base_repartition(aml, non_caba_taxes).filtered(lambda x: x.repartition_type == 'base').tag_ids
            // 
            //     common_tags = caba_base_tags & non_caba_base_tags
            // 
            //     if not common_tags:
            //         # When a tax is affecting another one with different tax exigibility, tags cannot be shared either.
            //         tax_tags = aml.tax_repartition_line_id.tag_ids
            //         comparison_tags = non_caba_base_tags if aml.tax_repartition_line_id.tax_id.tax_exigibility == 'on_payment' else caba_base_tags
            //         common_tags = tax_tags & comparison_tags
            // 
            //     if common_tags:
            //         raise ValidationError(_("Taxes exigible on payment and on invoice cannot be mixed on the same journal item if they share some tag."))
            */
            return default;
        }

        protected async Task<AccountMoveLine> CheckConstrainsAccountIdJournalIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _check_constrains_account_id_journal_id(self):
            // # Avoid using api.constrains for fields journal_id and account_id as in case of a write on
            // # account move and account move line in the same operation, the check would be done
            // # before all write are complete, causing a false positive
            // for line in self.filtered(lambda x: x.display_type not in ('line_section', 'line_note')):
            //     account = line.account_id
            //     journal = line.move_id.journal_id
            // 
            //     if account.deprecated and not self.env.context.get('skip_account_deprecation_check'):
            //         raise UserError(_('The account %(name)s (%(code)s) is deprecated.', name=account.name, code=account.code))
            // 
            //     account_currency = account.currency_id
            //     if account_currency and account_currency != line.company_currency_id and account_currency != line.currency_id:
            //         raise UserError(_('The account selected on your journal entry forces to provide a secondary currency. You should remove the secondary currency on the account.'))
            // 
            //     if account.allowed_journal_ids and journal not in account.allowed_journal_ids:
            //         raise UserError(_('You cannot use this account (%s) in this journal, check the field \'Allowed Journals\' on the related account.', account.display_name))
            // 
            //     if account in (journal.default_account_id, journal.suspense_account_id):
            //         continue
            // 
            //     is_account_control_ok = not journal.account_control_ids or account in journal.account_control_ids
            // 
            //     if not is_account_control_ok:
            //         raise UserError(_("You cannot use this account (%s) in this journal, check the section 'Control-Access' under "
            //                           "tab 'Advanced Settings' on the related journal.", account.display_name))
            */
            return default;
        }

        protected async Task<AccountMoveLine> CheckEdiLineTaxRequiredInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _check_edi_line_tax_required(self):
            // return self.product_id.type != 'combo'
            */
            return default;
        }

        protected async Task<AccountMoveLine> CheckOffBalanceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _check_off_balance(self):
            // for line in self.move_id.line_ids:
            //     if line.account_id.account_type == 'off_balance':
            //         if any(a.account_type != line.account_id.account_type for a in line.move_id.line_ids.account_id):
            //             raise UserError(_('If you want to use "Off-Balance Sheet" accounts, all the accounts of the journal entry must be of this type'))
            //         if line.tax_ids or line.tax_line_id:
            //             raise UserError(_('You cannot use taxes on lines with an Off-Balance account'))
            //         if line.reconciled:
            //             raise UserError(_('Lines from "Off-Balance Sheet" accounts cannot be reconciled'))
            */
            return default;
        }

        protected async Task<AccountMoveLine> CheckPayableReceivableInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _check_payable_receivable(self):
            // for line in self:
            //     account_type = line.account_id.account_type
            //     if line.move_id.is_sale_document(include_receipts=True):
            //         if account_type == 'liability_payable':
            //             raise UserError(_("Account %s is of payable type, but is used in a sale operation.", line.account_id.code))
            //         if (line.display_type == 'payment_term') ^ (account_type == 'asset_receivable'):
            //             raise UserError(_("Any journal item on a receivable account must have a due date and vice versa."))
            //     if line.move_id.is_purchase_document(include_receipts=True):
            //         if account_type == 'asset_receivable':
            //             raise UserError(_("Account %s is of receivable type, but is used in a purchase operation.", line.account_id.code))
            //         if (line.display_type == 'payment_term') ^ (account_type == 'liability_payable'):
            //             raise UserError(_("Any journal item on a payable account must have a due date and vice versa."))
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: account_move_line.py) ---
            // def _check_payable_receivable(self):
            // super(AccountMoveLine, self.filtered(lambda line: line.move_id.expense_sheet_id.payment_mode != 'company_account'))._check_payable_receivable()
            */
            return default;
        }

        protected async Task<AccountMoveLine> CheckProductUomCategoryIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _check_product_uom_category_id(self):
            // for line in self:
            //     if line.product_uom_id and line.product_id and line.product_uom_id.category_id != line.product_id.product_tmpl_id.uom_id.category_id:
            //         raise UserError(_(
            //             "The Unit of Measure (UoM) '%(uom)s' you have selected for product '%(product)s', "
            //             "is incompatible with its category : %(category)s.",
            //             uom=line.product_uom_id.name,
            //             product=line.product_id.name,
            //             category=line.product_id.product_tmpl_id.uom_id.category_id.name
            //         ))
            */
            return default;
        }

        protected async Task<AccountMoveLine> CheckReconciliationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _check_reconciliation(self):
            // for line in self:
            //     if line.matched_debit_ids or line.matched_credit_ids:
            //         raise UserError(_("You cannot do this modification on a reconciled journal entry. "
            //                           "You can just change some non legal fields or you must unreconcile first.\n"
            //                           "Journal Entry (id): %(entry)s (%(id)s)", entry=line.move_id.name, id=line.move_id.id))
            */
            return default;
        }

        protected async Task<AccountMoveLine> CheckTaxLockDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _check_tax_lock_date(self):
            // for line in self:
            //     move = line.move_id
            //     if move.state != 'posted':
            //         continue
            //     violated_lock_dates = move.company_id._get_lock_date_violations(
            //         move.date,
            //         fiscalyear=False,
            //         sale=False,
            //         purchase=False,
            //         tax=True,
            //         hard=True,
            //     )
            //     if violated_lock_dates and line._affect_tax_report():
            //         raise UserError(_("The operation is refused as it would impact an already issued tax statement. "
            //                           "Please change the journal entry date or the following lock dates to proceed: %(lock_date_info)s.",
            //                           lock_date_info=self.env['res.company']._format_lock_dates(violated_lock_dates)))
            // return True
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeAccountIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_account_id(self):
            // term_lines = self.filtered(lambda line: line.display_type == 'payment_term')
            // if term_lines:
            //     moves = term_lines.move_id
            //     self.env.cr.execute("""
            //         WITH previous AS (
            //             SELECT DISTINCT ON (line.move_id)
            //                    'account.move' AS model,
            //                    line.move_id AS id,
            //                    NULL AS account_type,
            //                    line.account_id AS account_id
            //               FROM account_move_line line
            //              WHERE line.move_id = ANY(%(move_ids)s)
            //                AND line.display_type = 'payment_term'
            //                AND line.id != ANY(%(current_ids)s)
            //         ),
            //         fallback AS (
            //             SELECT DISTINCT ON (account_companies.res_company_id, account.account_type)
            //                    'res.company' AS model,
            //                    account_companies.res_company_id AS id,
            //                    account.account_type AS account_type,
            //                    account.id AS account_id
            //               FROM account_account account
            //               JOIN account_account_res_company_rel account_companies
            //                    ON account_companies.account_account_id = account.id
            //              WHERE account_companies.res_company_id = ANY(%(company_ids)s)
            //                AND account.account_type IN ('asset_receivable', 'liability_payable')
            //                AND account.deprecated = 'f'
            //         )
            //         SELECT * FROM previous
            //         UNION ALL
            //         SELECT * FROM fallback
            //     """, {
            //         'company_ids': moves.company_id.ids,
            //         'move_ids': moves.ids,
            //         'partners': [f'res.partner,{pid}' for pid in moves.commercial_partner_id.ids],
            //         'current_ids': term_lines.ids
            //     })
            //     accounts = {
            //         (model, id, account_type): account_id
            //         for model, id, account_type, account_id in self.env.cr.fetchall()
            //     }
            //     for line in term_lines:
            //         account_type = 'asset_receivable' if line.move_id.is_sale_document(include_receipts=True) else 'liability_payable'
            //         move = line.move_id
            //         account_id = (
            //             accounts.get(('account.move', move.id, None))
            //             or move.with_company(move.company_id).commercial_partner_id['property_account_receivable_id' if account_type == 'asset_receivable' else 'property_account_payable_id'].id
            //             or move.with_company(move.company_id).company_id.partner_id['property_account_receivable_id' if account_type == 'asset_receivable' else 'property_account_payable_id'].id
            //             or accounts.get(('res.company', move.company_id.id, account_type))
            //         )
            //         if line.move_id.fiscal_position_id:
            //             account_id = line.move_id.fiscal_position_id.map_account(self.env['account.account'].browse(account_id))
            //         line.account_id = account_id
            // 
            // product_lines = self.filtered(lambda line: line.display_type == 'product' and line.move_id.is_invoice(True))
            // for line in product_lines:
            //     if line.product_id:
            //         fiscal_position = line.move_id.fiscal_position_id
            //         accounts = line.with_company(line.company_id).product_id\
            //             .product_tmpl_id.get_product_accounts(fiscal_pos=fiscal_position)
            //         if line.move_id.is_sale_document(include_receipts=True):
            //             line.account_id = accounts['income'] or line.account_id
            //         elif line.move_id.is_purchase_document(include_receipts=True):
            //             line.account_id = accounts['expense'] or line.account_id
            //     elif line.partner_id:
            //         account_id = self.env['account.account']._get_most_frequent_account_for_partner(
            //             company_id=line.company_id.id,
            //             partner_id=line.partner_id.id,
            //             move_type=line.move_id.move_type,
            //             journal_id=line.journal_id.id,
            //         )
            //         if account_id:
            //             line.account_id = account_id
            // for line in self:
            //     if not line.account_id and line.display_type not in ('line_section', 'line_note'):
            //         previous_two_accounts = line.move_id.line_ids.filtered(
            //             lambda l: l.account_id and l.display_type == line.display_type
            //         )[-2:].account_id
            //         if len(previous_two_accounts) == 1 and len(line.move_id.line_ids) > 2:
            //             line.account_id = previous_two_accounts
            //         else:
            //             line.account_id = line.move_id.journal_id.default_account_id
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move.py) ---
            // def _compute_account_id(self):
            // super()._compute_account_id()
            // input_lines = self.filtered(lambda line: (
            //     line._eligible_for_cogs()
            //     and line.move_id.company_id.anglo_saxon_accounting
            //     and line.move_id.is_purchase_document()
            // ))
            // for line in input_lines:
            //     fiscal_position = line.move_id.fiscal_position_id
            //     accounts = line.with_company(line.company_id).product_id.product_tmpl_id.get_product_accounts(fiscal_pos=fiscal_position)
            //     if accounts['stock_input']:
            //         line.account_id = accounts['stock_input']
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeAmountCurrencyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_amount_currency(self):
            // for line in self:
            //     if line.amount_currency is False:
            //         line.amount_currency = line.currency_id.round(line.balance * line.currency_rate)
            //     if line.currency_id == line.company_id.currency_id:
            //         line.amount_currency = line.balance
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeAmountResidualInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_amount_residual(self):
            // """ Computes the residual amount of a move line from a reconcilable account in the company currency and the line's currency.
            //     This amount will be 0 for fully reconciled lines or lines from a non-reconcilable account, the original line amount
            //     for unreconciled lines, and something in-between for partially reconciled lines.
            // """
            // need_residual_lines = self.filtered(lambda x: x.account_id.reconcile or x.account_id.account_type in ('asset_cash', 'liability_credit_card'))
            // # Run the residual amount computation on all lines stored in the db. By
            // # using _origin, new records (with a NewId) are excluded and the
            // # computation works automagically for virtual onchange records as well.
            // stored_lines = need_residual_lines._origin
            // 
            // if stored_lines:
            //     self.env['account.partial.reconcile'].flush_model()
            //     self.env['res.currency'].flush_model(['decimal_places'])
            // 
            //     aml_ids = tuple(stored_lines.ids)
            //     self._cr.execute('''
            //         SELECT
            //             part.debit_move_id AS line_id,
            //             'debit' AS flag,
            //             COALESCE(SUM(part.amount), 0.0) AS amount,
            //             ROUND(SUM(part.debit_amount_currency), curr.decimal_places) AS amount_currency
            //         FROM account_partial_reconcile part
            //         JOIN res_currency curr ON curr.id = part.debit_currency_id
            //         WHERE part.debit_move_id IN %s
            //         GROUP BY part.debit_move_id, curr.decimal_places
            //         UNION ALL
            //         SELECT
            //             part.credit_move_id AS line_id,
            //             'credit' AS flag,
            //             COALESCE(SUM(part.amount), 0.0) AS amount,
            //             ROUND(SUM(part.credit_amount_currency), curr.decimal_places) AS amount_currency
            //         FROM account_partial_reconcile part
            //         JOIN res_currency curr ON curr.id = part.credit_currency_id
            //         WHERE part.credit_move_id IN %s
            //         GROUP BY part.credit_move_id, curr.decimal_places
            //     ''', [aml_ids, aml_ids])
            //     amounts_map = {
            //         (line_id, flag): (amount, amount_currency)
            //         for line_id, flag, amount, amount_currency in self.env.cr.fetchall()
            //     }
            // else:
            //     amounts_map = {}
            // 
            // # Lines that can't be reconciled with anything since the account doesn't allow that.
            // for line in self - need_residual_lines:
            //     line.amount_residual = 0.0
            //     line.amount_residual_currency = 0.0
            //     line.reconciled = False
            // 
            // for line in need_residual_lines:
            //     # Since this part could be call on 'new' records, 'company_currency_id'/'currency_id' could be not set.
            //     comp_curr = line.company_currency_id or self.env.company.currency_id
            //     foreign_curr = line.currency_id or comp_curr
            // 
            //     # Retrieve the amounts in both foreign/company currencies. If the record is 'new', the amounts_map is empty.
            //     debit_amount, debit_amount_currency = amounts_map.get((line._origin.id, 'debit'), (0.0, 0.0))
            //     credit_amount, credit_amount_currency = amounts_map.get((line._origin.id, 'credit'), (0.0, 0.0))
            // 
            //     # Subtract the values from the account.partial.reconcile to compute the residual amounts.
            //     line.amount_residual = comp_curr.round(line.balance - debit_amount + credit_amount)
            //     line.amount_residual_currency = foreign_curr.round(line.amount_currency - debit_amount_currency + credit_amount_currency)
            //     line.reconciled = (
            //         comp_curr.is_zero(line.amount_residual)
            //         and foreign_curr.is_zero(line.amount_residual_currency)
            //     )
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeAnalyticDistributionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_analytic_distribution(self):
            // cache = {}
            // for line in self:
            //     if line.display_type == 'product' or not line.move_id.is_invoice(include_receipts=True):
            //         related_distribution = line._related_analytic_distribution()
            //         root_plans = self.env['account.analytic.account'].browse(
            //             list({int(account_id) for ids in related_distribution for account_id in ids.split(',')})
            //         ).exists().root_plan_id
            // 
            //         arguments = frozendict({
            //             "product_id": line.product_id.id,
            //             "product_categ_id": line.product_id.categ_id.id,
            //             "partner_id": line.partner_id.id,
            //             "partner_category_id": line.partner_id.category_id.ids,
            //             "account_prefix": line.account_id.code,
            //             "company_id": line.company_id.id,
            //             "related_root_plan_ids": root_plans,
            //         })
            //         if arguments not in cache:
            //             cache[arguments] = self.env['account.analytic.distribution.model']._get_distribution(arguments)
            //         line.analytic_distribution = related_distribution | cache[arguments] or line.analytic_distribution
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: account_move_line.py) ---
            // def _compute_analytic_distribution(self):
            // # when a project creates an aml, it adds an analytic account to it. the following filter is to save this
            // # analytic account from being overridden by analytic default rules and lack thereof
            // project_amls = self.filtered(lambda aml: aml.analytic_distribution and any(aml.sale_line_ids.project_id))
            // super(AccountMoveLine, self - project_amls)._compute_analytic_distribution()
            // project_id = self._context.get('project_id', False)
            // if project_id:
            //     project = self.env['project.project'].browse(project_id)
            //     lines = self.filtered(lambda line: line.account_type not in ['asset_receivable', 'liability_payable'])
            //     lines.analytic_distribution = project._get_analytic_distribution()
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeBalanceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_balance(self):
            // for line in self:
            //     if line.display_type in ('line_section', 'line_note'):
            //         line.balance = False
            //     elif not line.move_id.is_invoice(include_receipts=True):
            //         # Only act as a default value when none of balance/debit/credit is specified
            //         # balance is always the written field because of `_sanitize_vals`.
            //         # Virtual record holds just the differences coming from the onchange
            //         # so we need to recover balance of stored lines to calculate correctly the
            //         # new line balance.
            //         active_line_ids = [lid for lid in self.env.context.get('line_ids', []) if isinstance(lid, int)]
            //         existing_lines = self.env['account.move.line'].browse(active_line_ids)
            //         outdated_lines = line.move_id.line_ids._origin
            //         new_lines = line.move_id.line_ids - line
            //         line.balance = -sum((existing_lines - outdated_lines + new_lines).mapped('balance'))
            //     else:
            //         line.balance = 0
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeCumulatedBalanceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_cumulated_balance(self):
            // if not self.env.context.get('order_cumulated_balance'):
            //     # We do not come from search_fetch, so we are not in a list view, so it doesn't make any sense to compute the cumulated balance
            //     self.cumulated_balance = 0
            //     return
            // 
            // # get the where clause
            // query = self._where_calc(list(self.env.context.get('domain_cumulated_balance') or []))
            // sql_order = self._order_to_sql(self.env.context.get('order_cumulated_balance'), query, reverse=True)
            // result = dict(self.env.execute_query(query.select(
            //     SQL.identifier(query.table, "id"),
            //     SQL(
            //         "SUM(%s) OVER (ORDER BY %s ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW)",
            //         SQL.identifier(query.table, "balance"),
            //         sql_order,
            //     ),
            // )))
            // for record in self:
            //     record.cumulated_balance = result[record.id]
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeCurrencyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_currency_id(self):
            // for line in self:
            //     if line.display_type == 'cogs':
            //         line.currency_id = line.company_currency_id
            //     elif line.move_id.is_invoice(include_receipts=True):
            //         line.currency_id = line.move_id.currency_id
            //     else:
            //         line.currency_id = line.currency_id or line.company_id.currency_id
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeCurrencyRateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_currency_rate(self):
            // for line in self:
            //     if line.move_id.is_invoice(include_receipts=True):
            //         line.currency_rate = line.move_id.invoice_currency_rate
            //     elif line.currency_id:
            //         line.currency_rate = self.env['res.currency']._get_conversion_rate(
            //             from_currency=line.company_currency_id,
            //             to_currency=line.currency_id,
            //             company=line.company_id,
            //             date=line.move_id.invoice_date or line.move_id.date or fields.Date.context_today(line),
            //         )
            //     else:
            //         line.currency_rate = 1
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeDebitCreditInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_debit_credit(self):
            // for line in self:
            //     if not line.is_storno:
            //         line.debit = line.balance if line.balance > 0.0 else 0.0
            //         line.credit = -line.balance if line.balance < 0.0 else 0.0
            //     else:
            //         line.debit = line.balance if line.balance < 0.0 else 0.0
            //         line.credit = -line.balance if line.balance > 0.0 else 0.0
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeDiscountAllocationKeyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_discount_allocation_key(self):
            // for line in self:
            //     if line.display_type == 'discount':
            //         line.discount_allocation_key = frozendict({
            //             'account_id': line.account_id.id,
            //             'move_id': line.move_id.id,
            //             'currency_rate': line.currency_rate,
            //         })
            //     else:
            //         line.discount_allocation_key = False
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeDiscountAllocationNeededInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_discount_allocation_needed(self):
            // line2discounted_amount = {
            //     line: [
            //         (line.account_id, amount),
            //         (discount_allocation_account, -amount),
            //     ]
            //     for line in self.move_id.line_ids
            //     if line.display_type == 'product'
            //     and (discount_allocation_account := line.move_id._get_discount_allocation_account())
            //     and line.account_id != discount_allocation_account
            //     and (amount := line.currency_id.round(
            //         line.move_id.direction_sign * line.quantity * line.price_unit * line.discount / 100
            //     ))
            // }
            // 
            // distribution_totals = defaultdict(lambda: defaultdict(float))
            // for line, discounted_amounts in line2discounted_amount.items():
            //     for account, amount in discounted_amounts:
            //         for analytic_account_id in line.analytic_distribution or {}:
            //             distribution_totals[frozendict({
            //                 'move_id': line.move_id.id,
            //                 'account_id': account.id,
            //                 'currency_rate': line.currency_rate,
            //             })][analytic_account_id] += amount
            // 
            // for line in self:
            //     line.discount_allocation_dirty = True
            //     if line not in line2discounted_amount:
            //         line.discount_allocation_needed = False
            //         continue
            // 
            //     discount_allocation_needed = {}
            //     for account, amount in line2discounted_amount[line]:
            //         key = frozendict({
            //             'move_id': line.move_id.id,
            //             'account_id': account.id,
            //             'currency_rate': line.currency_rate,
            //         })
            //         dist = distribution_totals[key]
            //         total = sum(dist.values()) or 1  # avoid division by zero
            //         discount_allocation_needed[key] = frozendict({
            //             'display_type': 'discount',
            //             'name': _("Discount"),
            //             'amount_currency': amount,
            //             'analytic_distribution': {
            //                 account_id: 100 * value / total
            //                 for account_id, value in dist.items()
            //             }
            //         })
            //     line.discount_allocation_needed = discount_allocation_needed
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_display_name(self):
            // for line in self:
            //     line.display_name = line._format_aml_name(line.name or line.product_id.display_name, line.ref, line.move_id.name)
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeDisplayTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_display_type(self):
            // for line in self.filtered(lambda l: not l.display_type):
            //     # avoid cyclic dependencies with _compute_account_id
            //     account_set = self.env.cache.contains(line, line._fields['account_id'])
            //     tax_set = self.env.cache.contains(line, line._fields['tax_line_id'])
            //     line.display_type = (
            //         'tax' if tax_set and line.tax_line_id else
            //         'payment_term' if account_set and line.account_id.account_type in ['asset_receivable', 'liability_payable'] else
            //         'product'
            //     ) if line.move_id.is_invoice() else 'product'
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeEpdKeyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_epd_key(self):
            // for line in self:
            //     pay_term = line.move_id.invoice_payment_term_id
            //     if line.display_type == 'epd' and pay_term.early_discount and pay_term.early_pay_discount_computation == 'mixed':
            //         line.epd_key = frozendict({
            //             'account_id': line.account_id.id,
            //             'analytic_distribution': line.analytic_distribution,
            //             'tax_ids': [Command.set(line.tax_ids.ids)],
            //             'tax_tag_ids': [Command.set(line.tax_tag_ids.ids)],
            //             'move_id': line.move_id.id,
            //         })
            //     else:
            //         line.epd_key = False
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeEpdNeededInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_epd_needed(self):
            // # TODO: The computation of early payment is weird because based on the 'price_subtotal'
            // # that already have it's own taxes computation (by design because the sync_dynamic lines only
            // # work when saving the record).
            // # However, the early payment lines also have some taxes and the sync_dynamic_line will compute the tax lines based on
            // # product base lines + epd base lines that could lead to a different amount when using the round globally.
            // for line in self:
            //     line.epd_dirty = True
            //     line.epd_needed = False
            //     has_epd = line.move_id.invoice_payment_term_id.early_discount
            //     discount_percentage = line.move_id.invoice_payment_term_id.discount_percentage
            // 
            //     if not has_epd or line.display_type != 'product' or not line.tax_ids.ids or line.move_id.invoice_payment_term_id.early_pay_discount_computation != 'mixed':
            //         continue
            //     discount_percentage_name = f"{discount_percentage}%"
            //     epd_needed = {}
            //     percentage = discount_percentage / 100
            //     taxes = line.tax_ids.filtered(lambda t: t.amount_type != 'fixed')
            //     epd_needed_vals = epd_needed.setdefault(
            //         frozendict({
            //             'move_id': line.move_id.id,
            //             'account_id': line.account_id.id,
            //             'analytic_distribution': line.analytic_distribution,
            //             'tax_ids': [Command.set(taxes.ids)],
            //             'display_type': 'epd',
            //         }),
            //         {
            //             'name': _("Early Payment Discount (%s)", discount_percentage_name),
            //             'amount_currency': 0.0,
            //             'balance': 0.0,
            //         },
            //     )
            //     sign = line.move_id.direction_sign
            //     rate = line.move_id.invoice_currency_rate
            //     amount_currency = line.currency_id.round(sign * line.price_subtotal * percentage)
            //     balance = line.company_currency_id.round(sign * line.price_subtotal * percentage / rate) if rate else 0.0
            //     epd_needed_vals['amount_currency'] -= amount_currency
            //     epd_needed_vals['balance'] -= balance
            //     epd_needed_vals = epd_needed.setdefault(
            //         frozendict({
            //             'move_id': line.move_id.id,
            //             'account_id': line.account_id.id,
            //             'display_type': 'epd',
            //         }),
            //         {
            //             'name': _("Early Payment Discount (%s)", discount_percentage_name),
            //             'amount_currency': 0.0,
            //             'balance': 0.0,
            //             'tax_ids': [Command.clear()],
            //         },
            //     )
            //     epd_needed_vals['amount_currency'] += amount_currency
            //     epd_needed_vals['balance'] += balance
            //     line.epd_needed = {k: frozendict(v) for k, v in epd_needed.items()}
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeIsRefundInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_is_refund(self):
            // for line in self:
            //     is_refund = False
            //     if line.move_id.move_type in ('out_refund', 'in_refund'):
            //         is_refund = True
            //     elif line.move_id.move_type == 'entry':
            //         if line.tax_repartition_line_id:
            //             is_refund = line.tax_repartition_line_id.document_type == 'refund'
            //         else:
            //             tax_type = line.tax_ids[:1].type_tax_use
            //             if tax_type == 'sale' and line.credit == 0:
            //                 is_refund = True
            //             elif tax_type == 'purchase' and line.debit == 0:
            //                 is_refund = True
            // 
            //             if line.tax_ids and line.move_id.reversed_entry_id:
            //                 is_refund = not is_refund
            //     line.is_refund = is_refund
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_name(self):
            // def get_name(line):
            //     values = []
            //     if line.partner_id.lang:
            //         product = line.product_id.with_context(lang=line.partner_id.lang)
            //     else:
            //         product = line.product_id
            //     if not product:
            //         return False
            // 
            //     if line.journal_id.type == 'sale':
            //         values.append(product.display_name)
            //         if product.description_sale:
            //             values.append(product.description_sale)
            //     elif line.journal_id.type == 'purchase':
            //         values.append(product.display_name)
            //         if product.description_purchase:
            //             values.append(product.description_purchase)
            //     return '\n'.join(values) if values else False
            // 
            // term_by_move = (self.move_id.line_ids | self).filtered(lambda l: l.display_type == 'payment_term').sorted(lambda l: l.date_maturity or date.max).grouped('move_id')
            // for line in self.filtered(lambda l: l.move_id.inalterable_hash is False):
            //     if line.display_type == 'payment_term':
            //         term_lines = term_by_move.get(line.move_id, self.env['account.move.line'])
            //         n_terms = len(line.move_id.invoice_payment_term_id.line_ids)
            //         if line.move_id.payment_reference and line.move_id.ref and line.move_id.payment_reference != line.move_id.ref:
            //             name = f'{line.move_id.ref} - {line.move_id.payment_reference}'
            //         else:
            //             name = line.move_id.payment_reference or False
            // 
            //         if n_terms > 1:
            //             index = term_lines._ids.index(line.id) if line in term_lines else len(term_lines)
            // 
            //             name = _('%(name)s installment #%(number)s', name=name if name else '', number=index + 1).lstrip()
            //         if n_terms > 1 or not line.name or line._origin.name == line._origin.move_id.payment_reference or (
            //             line._origin.move_id.payment_reference and line._origin.move_id.ref
            //             and line._origin.name == f'{line._origin.move_id.ref} - {line._origin.move_id.payment_reference}'
            //         ):
            //             line.name = name
            //     if not line.product_id or line.display_type in ('line_section', 'line_note'):
            //         continue
            // 
            //     if not line.name or line._origin.name == get_name(line._origin):
            //         line.name = get_name(line)
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: account_move.py) ---
            // def _compute_name(self):
            // amls = self.filtered(lambda l: not l.move_id.pos_session_ids)
            // super(AccountMoveLine, amls)._compute_name()
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeNeedVehicleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_fleet, FILE: account_move.py) ---
            // def _compute_need_vehicle(self):
            // self.need_vehicle = False
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputePartnerIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_partner_id(self):
            // for line in self:
            //     line.partner_id = line.move_id.partner_id.commercial_partner_id
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputePaymentDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_payment_date(self):
            // for line in self:
            //     line.payment_date = line.discount_date if line.discount_date and date.today() <= line.discount_date else line.date_maturity
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputePriceUnitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_price_unit(self):
            // for line in self:
            //     if not line.product_id or line.display_type in ('line_section', 'line_note') or line.is_imported:
            //         continue
            //     if line.move_id.is_sale_document(include_receipts=True):
            //         document_type = 'sale'
            //     elif line.move_id.is_purchase_document(include_receipts=True):
            //         document_type = 'purchase'
            //     else:
            //         document_type = 'other'
            //     line.price_unit = line.product_id._get_tax_included_unit_price(
            //         line.move_id.company_id,
            //         line.move_id.currency_id,
            //         line.move_id.date,
            //         document_type,
            //         fiscal_position=line.move_id.fiscal_position_id,
            //         product_uom=line.product_uom_id,
            //     )
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeProductUomIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_product_uom_id(self):
            // for line in self.filtered(lambda l: l.parent_state == 'draft'):
            //     # vendor bills should have the product purchase UOM
            //     if line.move_id.is_purchase_document():
            //         line.product_uom_id = line.product_id.uom_po_id
            //     else:
            //         line.product_uom_id = line.product_id.uom_id
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeQuantityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_quantity(self):
            // for line in self:
            //     if line.display_type == 'product':
            //         line.quantity = line.quantity if line.quantity else 1
            //     else:
            //         line.quantity = False
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeSameCurrencyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_same_currency(self):
            // for record in self:
            //     record.is_same_currency = record.currency_id == record.company_currency_id
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeSequenceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_sequence(self):
            // seq_map = {
            //     'tax': 10000,
            //     'rounding': 11000,
            //     'payment_term': 12000,
            // }
            // for line in self:
            //     line.sequence = seq_map.get(line.display_type, 100)
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeTaxIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_tax_ids(self):
            // for line in self:
            //     if line.display_type in ('line_section', 'line_note', 'payment_term') or line.is_imported:
            //         continue
            //     # /!\ Don't remove existing taxes if there is no explicit taxes set on the account.
            //     if line.product_id or (line.display_type != 'discount' and (line.account_id.tax_ids or not line.tax_ids)):
            //         line.tax_ids = line._get_computed_taxes()
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeTaxTagInvertInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_tax_tag_invert(self):
            // for record in self:
            //     origin_move_id = record.move_id.tax_cash_basis_origin_move_id or record.move_id
            //     if not record.tax_repartition_line_id and not record.tax_ids:
            //         # Invoices imported from other softwares might only have kept the tags, not the taxes.
            //         record.tax_tag_invert = record.tax_tag_ids and origin_move_id.is_inbound()
            // 
            //     elif origin_move_id.move_type == 'entry':
            //         # For misc operations, cash basis entries and write-offs from the bank reconciliation widget
            //         tax = record.tax_repartition_line_id.tax_id or record.tax_ids[:1]
            //         is_refund = record.is_refund
            //         tax_type = tax.type_tax_use
            //         if record.display_type == 'epd':  # In case of early payment, tax_tag_invert is independent of the balance of the line
            //             record.tax_tag_invert = tax_type == 'purchase'
            //         else:
            //             record.tax_tag_invert = (tax_type == 'purchase' and is_refund) or (tax_type == 'sale' and not is_refund)
            //     else:
            //         # For invoices with taxes
            //         record.tax_tag_invert = origin_move_id.is_inbound()
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeTermKeyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_term_key(self):
            // for line in self:
            //     if line.display_type == 'payment_term':
            //         line.term_key = frozendict({
            //             'move_id': line.move_id.id,
            //             'date_maturity': fields.Date.to_date(line.date_maturity),
            //             'discount_date': line.discount_date,
            //         })
            //     else:
            //         line.term_key = False
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeTotalsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_totals(self):
            // """ Compute 'price_subtotal' / 'price_total' outside of `_sync_tax_lines` because those values must be visible for the
            // user on the UI with draft moves and the dynamic lines are synchronized only when saving the record.
            // """
            // AccountTax = self.env['account.tax']
            // for line in self:
            //     # TODO remove the need of cogs lines to have a price_subtotal/price_total
            //     if line.display_type not in ('product', 'cogs'):
            //         line.price_total = line.price_subtotal = False
            //         continue
            // 
            //     base_line = line.move_id._prepare_product_base_line_for_taxes_computation(line)
            //     AccountTax._add_tax_details_in_base_line(base_line, line.company_id)
            //     line.price_subtotal = base_line['tax_details']['raw_total_excluded_currency']
            //     line.price_total = base_line['tax_details']['raw_total_included_currency']
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: account_move_line.py) ---
            // def _compute_totals(self):
            // expenses = self.filtered('expense_id')
            // super(AccountMoveLine, expenses.with_context(force_price_include=True))._compute_totals()
            // super(AccountMoveLine, self - expenses)._compute_totals()
            */
            return default;
        }

        protected async Task<AccountMoveLine> ConditionalAddToComputeInternalAsync(object fname, object condition)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _conditional_add_to_compute(self, fname, condition):
            // field = self._fields[fname]
            // to_reset = self.filtered(lambda line:
            //     condition(line)
            //     and not self.env.is_protected(field, line)
            // )
            // to_reset.invalidate_recordset([fname])
            // self.env.add_to_compute(field, to_reset)
            */
            return default;
        }

        protected async Task<AccountMoveLine> ConstrainsMatchingNumberInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _constrains_matching_number(self):
            // for line in self:
            //     if line.matching_number:
            //         if not re.match(r'^((P?\d+)|(I.+))$', line.matching_number):
            //             raise Exception("Invalid matching number format")
            //         elif line.matching_number.startswith('I') and (line.matched_debit_ids or line.matched_credit_ids):
            //             raise ValidationError(_("A temporary number can not be used in a real matching"))
            //         elif line.matching_number.startswith('P') and not (line.matched_debit_ids or line.matched_credit_ids):
            //             raise Exception("Should have partials")
            //         elif line.matching_number.startswith('P') and line.full_reconcile_id:
            //             raise Exception("Should not be partial number")
            //         elif line.matching_number.isdecimal() and not line.full_reconcile_id:
            //             raise Exception("Should not be full number")
            //         elif line.full_reconcile_id and line.matching_number != str(line.full_reconcile_id.id):
            //             raise Exception("Matching number should be the full reconcile")
            //     elif line.matched_debit_ids or line.matched_credit_ids:
            //         raise Exception("Should have number")
            */
            return default;
        }

        public async Task<AccountMoveLine> CopyDataAsync(Guid id, AccountMoveLineCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // 
            // for line, vals in zip(self, vals_list):
            //     # Don't copy the name of a payment term line.
            //     if line.display_type == 'payment_term' and line.move_id.is_invoice(True):
            //         del vals['name']
            //     # Don't copy restricted fields of notes
            //     if line.display_type in ('line_section', 'line_note'):
            //         del vals['balance']
            //         del vals['account_id']
            //     # Will be recomputed from the price_unit
            //     if line.display_type == 'product' and line.move_id.is_invoice(True):
            //         del vals['balance']
            //     if self._context.get('include_business_fields'):
            //         line._copy_data_extend_business_fields(vals)
            // return vals_list
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMoveLine> CopyDataExtendBusinessFieldsInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _copy_data_extend_business_fields(self, values):
            // self.ensure_one()
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def _copy_data_extend_business_fields(self, values):
            // # OVERRIDE to copy the 'purchase_line_id' field as well.
            // super(AccountMoveLine, self)._copy_data_extend_business_fields(values)
            // values['purchase_line_id'] = self.purchase_line_id.id
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move_line.py) ---
            // def _copy_data_extend_business_fields(self, values):
            // # OVERRIDE to copy the 'sale_line_ids' field as well.
            // super(AccountMoveLine, self)._copy_data_extend_business_fields(values)
            // values['sale_line_ids'] = [(6, None, self.sale_line_ids.ids)]
            */
            return default;
        }

        protected async Task<AccountMoveLine> CreateAnalyticLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _create_analytic_lines(self):
            // """ Create analytic items upon validation of an account.move.line having an analytic distribution.
            // """
            // self._validate_analytic_distribution()
            // analytic_line_vals = []
            // for line in self:
            //     analytic_line_vals.extend(line._prepare_analytic_lines())
            // 
            // context = dict(self.env.context)
            // context.pop('default_account_id', None)
            // context['skip_analytic_sync'] = True
            // self.env['account.analytic.line'].with_context(context).create(analytic_line_vals)
            */
            return default;
        }

        public override async Task<AccountMoveLine> CreateAsync(AccountMoveLine entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def create(self, vals_list):
            // moves = self.env['account.move'].browse({vals['move_id'] for vals in vals_list})
            // container = {'records': self}
            // move_container = {'records': moves}
            // with moves._check_balanced(move_container),\
            //      ExitStack() as exit_stack,\
            //      moves._sync_dynamic_lines(move_container),\
            //      self._sync_invoice(container):
            //     lines = super().create([self._sanitize_vals(vals) for vals in vals_list])
            //     exit_stack.enter_context(self.env.protecting([protected for vals, line in zip(vals_list, lines) for protected in self.env['account.move']._get_protected_vals(vals, line)]))
            //     container['records'] = lines
            // 
            // lines._check_tax_lock_date()
            // 
            // if not self.env.context.get('tracking_disable'):
            //     # Log changes to move lines on each move
            //     tracked_fields = [fname for fname, f in self._fields.items() if hasattr(f, 'tracking') and f.tracking and not (hasattr(f, 'related') and f.related)]
            //     ref_fields = self.env['account.move.line'].fields_get(tracked_fields)
            //     empty_values = dict.fromkeys(tracked_fields)
            //     for move_id, modified_lines in lines.grouped('move_id').items():
            //         if not move_id.posted_before:
            //             continue
            //         for line in modified_lines:
            //             if tracking_value_ids := line._mail_track(ref_fields, empty_values)[1]:
            //                 line.move_id._message_log(
            //                     body=_("Journal Item %s created", line._get_html_link(title=f"#{line.id}")),
            //                     tracking_value_ids=tracking_value_ids
            //                 )
            // 
            // lines.move_id._synchronize_business_models(['line_ids'])
            // lines._check_constrains_account_id_journal_id()
            // return lines
            --- ODOO METHOD SOURCE (MODULE: membership, FILE: account_move.py) ---
            // def create(self, vals_list):
            // # OVERRIDE
            // lines = super(AccountMoveLine, self).create(vals_list)
            // to_process = lines.filtered(lambda line: line.move_id.move_type == 'out_invoice' and line.product_id.membership)
            // 
            // # Nothing to process, break.
            // if not to_process:
            //     return lines
            // 
            // existing_memberships = self.env['membership.membership_line'].search([
            //     ('account_invoice_line', 'in', to_process.ids)])
            // to_process = to_process - existing_memberships.mapped('account_invoice_line')
            // 
            // # All memberships already exist, break.
            // if not to_process:
            //     return lines
            // 
            // memberships_vals = []
            // for line in to_process:
            //     date_from = line.product_id.membership_date_from
            //     date_to = line.product_id.membership_date_to
            //     if (date_from and date_from < (line.move_id.invoice_date or date.min) < (date_to or date.min)):
            //         date_from = line.move_id.invoice_date
            //     memberships_vals.append({
            //         'partner': line.move_id.partner_id.id,
            //         'membership_id': line.product_id.id,
            //         'member_price': line.price_unit,
            //         'date': fields.Date.today(),
            //         'date_from': date_from,
            //         'date_to': date_to,
            //         'account_invoice_line': line.id,
            //     })
            // self.env['membership.membership_line'].create(memberships_vals)
            // return lines
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<AccountMoveLine> CreateExchangeDifferenceMovesInternalAsync(object exchange_diff_values_list)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _create_exchange_difference_moves(self, exchange_diff_values_list):
            // """ Create the exchange difference journal entry on the current journal items.
            // 
            // :param exchange_diff_values_list:   A list of values to create and reconcile the exchange differences
            //                                     See the '_prepare_exchange_difference_move_vals' method.
            // :return: An account.move recordset.
            // """
            // exchange_move_values_list = []
            // journal_ids = set()
            // for exchange_diff_values in exchange_diff_values_list:
            //     move_vals = exchange_diff_values['move_values']
            //     exchange_move_values_list.append(move_vals)
            // 
            //     if not move_vals['journal_id']:
            //         raise UserError(_(
            //             "You have to configure the 'Exchange Gain or Loss Journal' in your company settings, to manage"
            //             " automatically the booking of accounting entries related to differences between exchange rates."
            //         ))
            // 
            //     journal_ids.add(move_vals['journal_id'])
            // 
            // if not exchange_move_values_list:
            //     return self.env['account.move']
            // 
            // # ==== Check the config ====
            // journals = self.env['account.journal'].browse(list(journal_ids))
            // for journal in journals:
            //     if not journal.company_id.expense_currency_exchange_account_id:
            //         raise UserError(_(
            //             "You should configure the 'Loss Exchange Rate Account' in your company settings, to manage"
            //             " automatically the booking of accounting entries related to differences between exchange rates."
            //         ))
            //     if not journal.company_id.income_currency_exchange_account_id.id:
            //         raise UserError(_(
            //             "You should configure the 'Gain Exchange Rate Account' in your company settings, to manage"
            //             " automatically the booking of accounting entries related to differences between exchange rates."
            //         ))
            // 
            // # ==== Create the move ====
            // exchange_moves = self.env['account.move'].create(exchange_move_values_list)
            // exchange_moves._post(soft=False)
            // 
            // # ==== Reconcile ====
            // reconciliation_plan = []
            // for exchange_move, exchange_diff_values in zip(exchange_moves, exchange_diff_values_list):
            //     for source_line, sequence in exchange_diff_values['to_reconcile']:
            //         exchange_diff_line = exchange_move.line_ids[sequence]
            //         reconciliation_plan.append((source_line + exchange_diff_line))
            // 
            // self\
            //     .with_context(no_exchange_difference=True)\
            //     ._reconcile_plan(reconciliation_plan)
            // 
            // return exchange_moves
            */
            return default;
        }

        protected async Task<AccountMoveLine> CreateReconciliationPartialsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _create_reconciliation_partials(self):
            // '''create the partial reconciliation between all the records in self
            //  :return: A recordset of account.partial.reconcile.
            // '''
            // partials_vals_list, exchange_data = self._prepare_reconciliation_partials([
            //     {
            //         'aml': line,
            //         'amount_residual': line.amount_residual,
            //         'amount_residual_currency': line.amount_residual_currency,
            //     }
            //     for line in self
            // ])
            // partials = self.env['account.partial.reconcile'].create(partials_vals_list)
            // 
            // # ==== Create exchange difference moves ====
            // for index, exchange_values in exchange_data.items():
            //     partials[index].exchange_move_id = self._create_exchange_difference_move(exchange_values)
            // 
            // return partials
            */
            return default;
        }

        public override async Task<AccountMoveLine> DefaultGetAsync(List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def default_get(self, fields_list):
            // defaults = super().default_get(fields_list)
            // quick_encode_suggestion = self.env.context.get('quick_encoding_vals')
            // if quick_encode_suggestion and self.env.context.get('default_display_type') not in ('line_section', 'line_note'):
            //     defaults['account_id'] = quick_encode_suggestion['account_id']
            //     defaults['price_unit'] = quick_encode_suggestion['price_unit']
            //     defaults['tax_ids'] = [Command.set(quick_encode_suggestion['tax_ids'])]
            // elif (journal := self.env['account.journal'].browse(self.env.context.get('journal_id'))) and journal.default_account_id:
            //     defaults['account_id'] = journal.default_account_id
            // return defaults
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_move.py) ---
            // def default_get(self, fields):
            // res = super(AccountMoveLine, self).default_get(fields)
            // if self.env.context.get('create_bill') and not self.asset_category_id:
            //     if self.product_id and self.move_id.move_type == 'out_invoice' and \
            //             self.product_id.product_tmpl_id.deferred_revenue_category_id:
            //         self.asset_category_id = self.product_id.product_tmpl_id.deferred_revenue_category_id.id
            //     elif self.product_id and self.product_id.product_tmpl_id.asset_category_id and \
            //             self.move_id.move_type == 'in_invoice':
            //         self.asset_category_id = self.product_id.product_tmpl_id.asset_category_id.id
            //     self.onchange_asset_category_id()
            // return res
            */
            return await base.DefaultGetAsync(fields);
        }

        protected async Task<AccountMoveLine> EligibleForCogsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move.py) ---
            // def _eligible_for_cogs(self):
            // self.ensure_one()
            // return self.product_id.is_storable and self.product_id.valuation == 'real_time'
            --- ODOO METHOD SOURCE (MODULE: stock_landed_costs, FILE: account_move.py) ---
            // def _eligible_for_cogs(self):
            // return super()._eligible_for_cogs() or (
            //     self.product_id.type == "service"
            //     and self.product_id.landed_cost_ok
            //     and self.product_id.valuation == "real_time"
            // )
            */
            return default;
        }

        protected async Task<AccountMoveLine> ExceptHashedEntryLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _except_hashed_entry_lines(self):
            // """ Lines belonginig to a hashed (locked) entry should not be allowed to be deleted in order to protect the
            // hash chain.
            // """
            // for line in self:
            //     if line.move_id.inalterable_hash:
            //         raise UserError(_('You cannot delete journal items belonging to a locked journal entry.'))
            */
            return default;
        }

        protected async Task<object> FieldToSqlInternalAsync(string @alias, string fname, object query, bool flush)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _field_to_sql(self, alias: str, fname: str, query: (Query | None) = None, flush: bool = True) -> SQL:
            // if fname != 'payment_date':
            //     return super()._field_to_sql(alias, fname, query, flush)
            // return SQL("""
            //     CASE
            //          WHEN %(discount_date)s >= %(today)s THEN %(discount_date)s
            //          ELSE %(date_maturity)s
            //     END""",
            //     today=fields.Date.context_today(self),
            //     discount_date=super()._field_to_sql(alias, "discount_date", query, flush),
            //     date_maturity=super()._field_to_sql(alias, "date_maturity", query, flush),
            // )
            */
            return default;
        }

        protected async Task<AccountMoveLine> FilterAmlLotValuationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _filter_aml_lot_valuation(self):
            // """ Method used to filter the aml taken into account when computing the invoiced lot value in get_invoiced_lot_values
            // Intended to be overriden in localization.
            // """
            // self.ensure_one()
            // return self.move_id.state == 'posted'
            */
            return default;
        }

        protected async Task<AccountMoveLine> FilterReconciledByNumberInternalAsync(Dictionary<string, object> mapping)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _filter_reconciled_by_number(self, mapping: dict):
            // """Get all the the lines matched with the lines in self.
            // 
            // Uses a mapping built with `_reconciled_by_number` to avoid multiple calls to the database.
            // """
            // matching_numbers = [n for n in set(self.mapped('matching_number')) if n]
            // return self | self.browse([_id for number in matching_numbers for _id in mapping[number].ids])
            */
            return default;
        }

        public async Task<AccountMoveLine> FlushModelAsync(Guid id, AccountMoveLineFlushModelRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def flush_model(self, fnames=None):
            // return super().flush_model(self._parse_flush_fnames(fnames))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMoveLine> FlushRecordsetAsync(Guid id, AccountMoveLineFlushRecordsetRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def flush_recordset(self, fnames=None):
            // return super().flush_recordset(self._parse_flush_fnames(fnames))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMoveLine> FormatAmlNameInternalAsync(object line_name, object move_ref, object move_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _format_aml_name(self, line_name, move_ref, move_name=None):
            // ''' Format the display of an account.move.line record. As its very costly to fetch the account.move.line
            // records, only line_name, move_ref, move_name are passed as parameters to deal with sql-queries more easily.
            // 
            // :param line_name:   The name of the account.move.line record.
            // :param move_ref:    The reference of the account.move record.
            // :param move_name:   The name of the account.move record.
            // :return:            The formatted name of the account.move.line record.
            // '''
            // names = []
            // if move_name and move_name != '/':
            //     names.append(move_name)
            // if move_ref and move_ref != '/':
            //     names.append(f"({move_ref})")
            // if line_name and line_name not in ['/', move_name, f"{move_ref} - {move_name}"]:
            //     names.append(line_name)
            // name = ' '.join(names)
            // return name or _('Draft Entry')
            */
            return default;
        }

        protected async Task<AccountMoveLine> GeneratePriceDifferenceValsInternalAsync(object layers)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: account_move_line.py) ---
            // def _generate_price_difference_vals(self, layers):
            // """
            // The method will determine which layers are impacted by the AML (`self`) and, in case of a price difference, it
            // will then return the values of the new AMLs and SVLs
            // """
            // self.ensure_one()
            // po_line = self.purchase_line_id
            // product_uom = self.product_id.uom_id
            // 
            // # `history` is a list of tuples: (time, aml, layer)
            // # aml and layer will never be both defined
            // # we use this to get an order between posted AML and layers
            // history = [(layer.create_date, False, layer) for layer in layers]
            // am_state_field = self.env['ir.model.fields'].search([('model', '=', 'account.move'), ('name', '=', 'state')], limit=1)
            // for aml in po_line.invoice_lines:
            //     move = aml.move_id
            //     if move.state != 'posted':
            //         continue
            //     state_trackings = move.message_ids.tracking_value_ids.filtered(lambda t: t.field_id == am_state_field).sorted('id')
            //     time = state_trackings[-1:].create_date or move.create_date  # `or` in case it has been created in posted state
            //     history.append((time, aml, False))
            // # Sort history based on the datetime. In case of equality, the prority is given to SVLs, then to IDs.
            // # That way, we ensure a deterministic behaviour
            // history.sort(key=lambda item: (item[0], bool(item[1]), (item[1] or item[2]).id))
            // 
            // # Replay the whole history: we want to know what are the links between each layer and each invoice,
            // # and then the links between `self` and the layers
            // qty_to_invoice_per_layer, layers_and_invoices_qties = self._replay_history(layers, history)
            // 
            // # Now we know what layers does `self` use, let's check if we have to create a pdiff SVL
            // # (or cancel such an SVL in case of a refund)
            // invoice = self.move_id
            // svl_vals_list = []
            // aml_vals_list = []
            // for layer in layers:
            //     # use the link between `self` and `layer` (i.e. the qty of `layer` billed by `self`)
            //     invoicing_layer_qty = layers_and_invoices_qties[(layer, invoice)][1]
            //     if float_is_zero(invoicing_layer_qty, precision_rounding=product_uom.rounding):
            //         continue
            // 
            //     # We will only consider the total quantity to invoice of the layer because we don't
            //     # want to invoice a part of the layer that has not been invoiced and that has been
            //     # returned in the meantime
            //     total_layer_qty_to_invoice = qty_to_invoice_per_layer[layer][0]
            //     remaining_qty = layer.remaining_qty
            //     out_layer_qty = total_layer_qty_to_invoice - remaining_qty
            //     if self.is_refund:
            //         sign = -1
            //         reversed_invoice = invoice.reversed_entry_id
            //         if not reversed_invoice:
            //             # this is a refund for a returned quantity, we don't have anything to do
            //             continue
            //         initial_invoiced_qty = layers_and_invoices_qties[(layer, reversed_invoice)][0]
            //         initial_pdiff_svl = layer.stock_valuation_layer_ids.filtered(lambda svl: svl.account_move_line_id.move_id == reversed_invoice)
            //         if not initial_pdiff_svl or float_is_zero(initial_invoiced_qty, precision_rounding=product_uom.rounding):
            //             continue
            //         # We have an already-out quantity: we must skip the part already invoiced. So, first,
            //         # let's compute the already invoiced quantity...
            //         previously_invoiced_qty = 0
            //         for item in history:
            //             previous_aml = item[1]
            //             if not previous_aml or previous_aml.is_refund:
            //                 continue
            //             previous_invoice = previous_aml.move_id
            //             if previous_invoice == reversed_invoice:
            //                 break
            //             previously_invoiced_qty += layers_and_invoices_qties[(layer, previous_invoice,)][1]
            //         # ... Second, skip it:
            //         out_qty_to_invoice = max(0, out_layer_qty - previously_invoiced_qty)
            //         qty_to_correct = max(0, invoicing_layer_qty - out_qty_to_invoice)
            //         if out_qty_to_invoice:
            //             # In case the out qty is different from the one posted by the initial bill, we should compensate
            //             # this quantity with debit/credit between stock_in and expense, but we are reversing an initial
            //             # invoice and don't want to do more than the original one
            //             out_qty_to_invoice = 0
            //         aml = initial_pdiff_svl.account_move_line_id
            //         parent_layer = initial_pdiff_svl.stock_valuation_layer_id
            //         layer_price_unit = parent_layer._get_layer_price_unit()
            //     else:
            //         sign = 1
            //         # get the invoiced qty of the layer without considering `self`
            //         invoiced_layer_qty = total_layer_qty_to_invoice - qty_to_invoice_per_layer[layer][1] - invoicing_layer_qty
            //         remaining_out_qty_to_invoice = max(0, out_layer_qty - invoiced_layer_qty)
            //         out_qty_to_invoice = min(remaining_out_qty_to_invoice, invoicing_layer_qty)
            //         qty_to_correct = invoicing_layer_qty - out_qty_to_invoice
            //         layer_price_unit = layer._get_layer_price_unit()
            // 
            //         returned_move = layer.stock_move_id.origin_returned_move_id
            //         if returned_move and returned_move._is_out() and returned_move._is_returned(valued_type='out'):
            //             # Odd case! The user receives a product, then returns it. The returns are processed as classic
            //             # output, so the value of the returned product can be different from the initial one. The user
            //             # then receives again the returned product (that's where we are here) -> the SVL is based on
            //             # the returned one, the accounting entries are already compensated, and we don't want to impact
            //             # the stock valuation. So, let's fake the layer price unit with the POL one as everything is
            //             # already ok
            //             layer_price_unit = po_line.currency_id._convert(
            //                 po_line._get_gross_price_unit(),
            //                 layer.currency_id,
            //                 layer.company_id,
            //                 layer.create_date.date(),
            //                 round=False
            //             )
            //         aml = self
            // 
            //     svl_vals, aml_vals = self._prepare_pdiff_vals(layer, aml, layer_price_unit, out_qty_to_invoice, sign * qty_to_correct)
            //     svl_vals_list.extend(svl_vals)
            //     aml_vals_list.extend(aml_vals)
            // 
            // return svl_vals_list, aml_vals_list
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetAssetDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_move.py) ---
            // def _get_asset_date(self):
            // for rec in self:
            //     rec.asset_mrr = 0
            //     rec.asset_start_date = False
            //     rec.asset_end_date = False
            //     cat = rec.asset_category_id
            //     if cat:
            //         if cat.method_number == 0 or cat.method_period == 0:
            //             raise UserError(_('The number of depreciations or the period length of '
            //                               'your asset category cannot be 0.'))
            //         months = cat.method_number * cat.method_period
            //         if rec.move_id.move_type in ['out_invoice', 'out_refund']:
            //             price_subtotal = self.currency_id._convert(
            //                 self.price_subtotal,
            //                 self.company_currency_id,
            //                 self.company_id,
            //                 self.move_id.invoice_date or fields.Date.context_today(
            //                     self))
            // 
            //             rec.asset_mrr = price_subtotal / months
            //         if rec.move_id.invoice_date:
            //             start_date = rec.move_id.invoice_date.replace(day=1)
            //             end_date = (start_date + relativedelta(months=months, days=-1))
            //             rec.asset_start_date = start_date
            //             rec.asset_end_date = end_date
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetAttachmentDomainsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_attachment_domains(self):
            // self.ensure_one()
            // domains = [[
            //     ('res_model', '=', 'account.move'),
            //     ('res_id', '=', self.move_id.id),
            //     ('res_field', 'in', (False, 'invoice_pdf_report_file')),
            // ]]
            // if self.statement_id:
            //     domains.append([('res_model', '=', 'account.bank.statement'), ('res_id', '=', self.statement_id.id)])
            // if self.payment_id:
            //     domains.append([('res_model', '=', 'account.payment'), ('res_id', '=', self.payment_id.id)])
            // return domains
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: account_move_line.py) ---
            // def _get_attachment_domains(self):
            // attachment_domains = super(AccountMoveLine, self)._get_attachment_domains()
            // if self.expense_id:
            //     attachment_domains.append([('res_model', '=', 'hr.expense'), ('res_id', '=', self.expense_id.id)])
            // return attachment_domains
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetComputedTaxesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_computed_taxes(self):
            // self.ensure_one()
            // 
            // company_domain = self.env['account.tax']._check_company_domain(self.move_id.company_id)
            // if self.move_id.is_sale_document(include_receipts=True):
            //     # Out invoice.
            //     filtered_taxes_id = self.product_id.taxes_id.filtered_domain(company_domain)
            //     tax_ids = filtered_taxes_id or self.account_id.tax_ids.filtered(lambda tax: tax.type_tax_use == 'sale')
            // 
            // elif self.move_id.is_purchase_document(include_receipts=True):
            //     # In invoice.
            //     filtered_supplier_taxes_id = self.product_id.supplier_taxes_id.filtered_domain(company_domain)
            //     tax_ids = filtered_supplier_taxes_id or self.account_id.tax_ids.filtered(lambda tax: tax.type_tax_use == 'purchase')
            // 
            // else:
            //     tax_ids = False if self.env.context.get('skip_computed_taxes') else self.account_id.tax_ids
            // 
            // if self.company_id and tax_ids:
            //     tax_ids = tax_ids._filter_taxes_by_company(self.company_id)
            // 
            // if tax_ids and self.move_id.fiscal_position_id:
            //     tax_ids = self.move_id.fiscal_position_id.map_tax(tax_ids)
            // 
            // return tax_ids
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetDownpaymentLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_downpayment_lines(self):
            // ''' Return the downpayment move lines associated with the move line.
            // This method is overridden in the sale order module.
            // '''
            // return self.env['account.move.line']
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move_line.py) ---
            // def _get_downpayment_lines(self):
            // # OVERRIDE
            // return self.sale_line_ids.filtered('is_downpayment').invoice_lines.filtered(lambda line: line.move_id._is_downpayment())
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetExchangeAccountInternalAsync(object company, object amount)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_exchange_account(self, company, amount):
            // if amount > 0.0:
            //     return company.expense_currency_exchange_account_id
            // return company.income_currency_exchange_account_id
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move.py) ---
            // def _get_exchange_account(self, company, amount):
            // if (
            //     self and self.move_id.sudo().stock_valuation_layer_ids and
            //     self.product_id.categ_id.property_valuation == 'real_time'
            // ):
            //     return self.product_id.categ_id.property_stock_valuation_account_id
            // return super()._get_exchange_account(company, amount)
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetExchangeJournalInternalAsync(object company)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_exchange_journal(self, company):
            // return company.currency_exchange_journal_id
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move.py) ---
            // def _get_exchange_journal(self, company):
            // if (
            //     self and self.move_id.sudo().stock_valuation_layer_ids and
            //     self.product_id.categ_id.property_valuation == 'real_time'
            // ):
            //     return self.product_id.categ_id.property_stock_journal
            // return super()._get_exchange_journal(company)
            */
            return default;
        }

        protected async Task<object> GetExtraQueryBaseTaxLineMappingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line_tax_details.py) ---
            // def _get_extra_query_base_tax_line_mapping(self) -> SQL:
            // #TO OVERRIDE
            // return SQL()
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: account_move_line.py) ---
            // def _get_extra_query_base_tax_line_mapping(self) -> SQL:
            // return SQL(' AND (base_line.expense_id IS NULL OR account_move_line.expense_id = base_line.expense_id)')
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetGrossUnitPriceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move.py) ---
            // def _get_gross_unit_price(self):
            // if float_is_zero(self.quantity, precision_rounding=self.product_uom_id.rounding):
            //     return self.price_unit
            // 
            // if self.discount != 100:
            //     if not any(t.price_include for t in self.tax_ids) and self.discount:
            //         price_unit = self.price_unit * (1 - self.discount / 100)
            //     else:
            //         price_unit = self.price_subtotal / self.quantity
            // else:
            //     price_unit = self.price_unit
            // 
            // return -price_unit if self.move_id.move_type == 'in_refund' else price_unit
            */
            return default;
        }

        public async Task<AccountMoveLine> GetImportTemplatesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Journal Items'),
            //     'template': '/account/static/xls/aml_import_template.xlsx'
            // }]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMoveLine> GetInstallmentsDataInternalAsync(object payment_currency, object payment_date, object next_payment_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_installments_data(self, payment_currency=None, payment_date=None, next_payment_date=None):
            // move = self.move_id
            // move.ensure_one()
            // 
            // payment_date = payment_date or fields.Date.context_today(self)
            // 
            // term_lines = self.sorted(key=lambda line: (line.date_maturity, line.date))
            // sign = move.direction_sign
            // installments = []
            // first_installment_mode = False
            // current_installment_mode = False
            // for i, line in enumerate(term_lines, start=1):
            //     installment = {
            //         'number': i,
            //         'line': line,
            //         'date_maturity': line.date_maturity or line.date,
            //         'amount_residual_currency': line.amount_residual_currency,
            //         'amount_residual': line.amount_residual,
            //         'amount_residual_currency_unsigned': -sign * line.amount_residual_currency,
            //         'amount_residual_unsigned': -sign * line.amount_residual,
            //         'type': 'other',
            //         'reconciled': line.reconciled,
            //     }
            //     installments.append(installment)
            // 
            //     # Already reconciled.
            //     if line.reconciled:
            //         continue
            // 
            //     # Early payment discount.
            //     # In that case, we want to report the difference of the epd and display it on the UI.
            //     if move._is_eligible_for_early_payment_discount(payment_currency or line.currency_id, payment_date):
            //         installment.update({
            //             'amount_residual_currency': line.discount_amount_currency,
            //             'amount_residual': line.discount_balance,
            //             'amount_residual_currency_unsigned': -sign * line.discount_amount_currency,
            //             'amount_residual_unsigned': -sign * line.discount_balance,
            //             'discount_amount_currency': line.amount_currency - line.discount_amount_currency,
            //             'discount_amount': line.balance - line.discount_balance,
            //             'type': 'early_payment_discount',
            //         })
            //         continue
            // 
            //     # Installments.
            //     # In case of overdue, all of them are sum as a default amount to be paid.
            //     # The next installment is added for the difference.
            //     if line.display_type == 'payment_term':
            //         if next_payment_date and (line.date_maturity or line.date) <= next_payment_date:
            //             current_installment_mode = 'before_date'
            //         elif (line.date_maturity or line.date) < payment_date:
            //             # Collect all overdue installments.
            //             first_installment_mode = current_installment_mode = 'overdue'
            //         elif not first_installment_mode:
            //             # Suggest the next installment in case of no overdue.
            //             first_installment_mode = 'next'
            //             current_installment_mode = 'next'
            //         elif current_installment_mode == 'overdue':
            //             # After an overdue, just add the next installment for the difference.
            //             current_installment_mode = 'next'
            //         installment['type'] = current_installment_mode
            // 
            // return installments
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetIntegrityHashFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_integrity_hash_fields(self):
            // # Use the new hash version by default, but keep the old one for backward compatibility when generating the integrity report.
            // hash_version = self._context.get('hash_version', MAX_HASH_VERSION)
            // if hash_version == 1:
            //     return ['debit', 'credit', 'account_id', 'partner_id']
            // elif hash_version in (2, 3, 4):
            //     return ['name', 'debit', 'credit', 'account_id', 'partner_id']
            // raise NotImplementedError(f"hash_version={hash_version} doesn't exist")
            */
            return default;
        }

        public async Task<AccountMoveLine> GetInvoiceLineAccountAsync(Guid id, AccountMoveLineGetInvoiceLineAccountRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_move.py) ---
            // def get_invoice_line_account(self, type, product, fpos, company):
            // return product.asset_category_id.account_asset_id or super(AccountMoveLine, self).get_invoice_line_account(type, product, fpos, company)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMoveLine> GetInvoicedQtyPerProductInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_invoiced_qty_per_product(self):
            // qties = defaultdict(float)
            // for aml in self:
            //     qty = aml.product_uom_id._compute_quantity(aml.quantity, aml.product_id.uom_id)
            //     if aml.move_id.move_type == 'out_invoice':
            //         qties[aml.product_id] += qty
            //     elif aml.move_id.move_type == 'out_refund':
            //         qties[aml.product_id] -= qty
            // return qties
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: account_move.py) ---
            // def _get_invoiced_qty_per_product(self):
            // # Replace the kit-type products with their components
            // qties = defaultdict(float)
            // res = super()._get_invoiced_qty_per_product()
            // invoiced_products = self.env['product.product'].concat(*res.keys())
            // bom_kits = self.env['mrp.bom']._bom_find(invoiced_products, company_id=self.company_id[:1].id, bom_type='phantom')
            // for product, qty in res.items():
            //     bom_kit = bom_kits[product]
            //     if bom_kit:
            //         invoiced_qty = product.uom_id._compute_quantity(qty, bom_kit.product_uom_id, round=False)
            //         factor = invoiced_qty / bom_kit.product_qty
            //         dummy, bom_sub_lines = bom_kit.explode(product, factor)
            //         for bom_line, bom_line_data in bom_sub_lines:
            //             qties[bom_line.product_id] += bom_line.product_uom_id._compute_quantity(bom_line_data['qty'], bom_line.product_id.uom_id)
            //     else:
            //         qties[product] += qty
            // return qties
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetJournalItemsFullNameInternalAsync(object name, object display_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_journal_items_full_name(self, name, display_name):
            // return name if not display_name or display_name in name else f"{display_name} {name}"
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetLockDateProtectedFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_lock_date_protected_fields(self):
            // """ Returns the names of the fields that should be protected by the accounting fiscal year and tax lock dates
            // """
            // tax_fnames = ['balance', 'tax_line_id', 'tax_ids', 'tax_tag_ids']
            // fiscal_fnames = tax_fnames + ['account_id', 'journal_id', 'amount_currency', 'currency_id', 'partner_id']
            // reconciliation_fnames = ['account_id', 'date', 'balance', 'amount_currency', 'currency_id']
            // return {
            //     'tax': tax_fnames,
            //     'fiscal': fiscal_fnames,
            //     'reconciliation': reconciliation_fnames,
            // }
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetOutAndNotInvoicedQtyInternalAsync(object in_moves)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: account_move_line.py) ---
            // def _get_out_and_not_invoiced_qty(self, in_moves):
            // self.ensure_one()
            // if not in_moves:
            //     return 0
            // aml_qty = self.product_uom_id._compute_quantity(self.quantity, self.product_id.uom_id)
            // invoiced_qty = sum(line.product_uom_id._compute_quantity(line.quantity, line.product_id.uom_id)
            //                    for line in self.purchase_line_id.invoice_lines - self)
            // layers = in_moves.stock_valuation_layer_ids
            // layers_qty = sum(layers.mapped('quantity'))
            // out_qty = layers_qty - sum(layers.mapped('remaining_qty'))
            // total_out_and_not_invoiced_qty = max(0, out_qty - invoiced_qty)
            // out_and_not_invoiced_qty = min(aml_qty, total_out_and_not_invoiced_qty)
            // return self.product_id.uom_id._compute_quantity(out_and_not_invoiced_qty, self.product_uom_id)
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetPriceUnitValDifAndRelevantQtyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: account_move_line.py) ---
            // def _get_price_unit_val_dif_and_relevant_qty(self):
            // price_unit_val_dif, relevant_qty = super()._get_price_unit_val_dif_and_relevant_qty()
            // if self.product_id.cost_method == 'standard' and self.purchase_line_id:
            //     components_cost = 0
            //     subcontract_production = self.purchase_line_id.move_ids._get_subcontract_production()
            //     components_cost -= sum(subcontract_production.move_raw_ids.stock_valuation_layer_ids.mapped('value'))
            //     qty = sum(mo.product_uom_id._compute_quantity(mo.qty_producing, self.product_uom_id) for mo in subcontract_production if mo.state == 'done')
            //     if not float_is_zero(qty, precision_rounding=self.product_uom_id.rounding):
            //         price_unit_val_dif = price_unit_val_dif + components_cost / qty
            // return price_unit_val_dif, relevant_qty
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: account_move_line.py) ---
            // def _get_price_unit_val_dif_and_relevant_qty(self):
            // self.ensure_one()
            // # Retrieve stock valuation moves.
            // valuation_stock_moves = self.env['stock.move'].search([
            //     ('purchase_line_id', '=', self.purchase_line_id.id),
            //     ('state', '=', 'done'),
            //     ('product_qty', '!=', 0.0),
            // ]) if self.purchase_line_id else self.env['stock.move']
            // 
            // if self.product_id.cost_method != 'standard' and self.purchase_line_id:
            //     if self.move_type == 'in_refund':
            //         valuation_stock_moves = valuation_stock_moves.filtered(lambda stock_move: stock_move._is_out())
            //     else:
            //         valuation_stock_moves = valuation_stock_moves.filtered(lambda stock_move: stock_move._is_in())
            // 
            //     if not valuation_stock_moves:
            //         return 0, 0
            // 
            //     valuation_price_unit_total, valuation_total_qty = valuation_stock_moves._get_valuation_price_and_qty(self, self.move_id.currency_id)
            //     valuation_price_unit = valuation_price_unit_total / valuation_total_qty
            //     valuation_price_unit = self.product_id.uom_id._compute_price(valuation_price_unit, self.product_uom_id)
            // else:
            //     # Valuation_price unit is always expressed in invoice currency, so that it can always be computed with the good rate
            //     price_unit = self.product_id.uom_id._compute_price(self.product_id.standard_price, self.product_uom_id)
            //     price_unit = -price_unit if self.move_id.move_type == 'in_refund' else price_unit
            //     valuation_date = valuation_stock_moves and max(valuation_stock_moves.mapped('date')) or self.date
            //     valuation_price_unit = self.company_currency_id._convert(
            //         price_unit, self.currency_id,
            //         self.company_id, valuation_date, round=False
            //     )
            // 
            // price_unit = self._get_gross_unit_price()
            // 
            // price_unit_val_dif = price_unit - valuation_price_unit
            // # If there are some valued moves, we only consider their quantity already used
            // if self.product_id.cost_method == 'standard':
            //     relevant_qty = self.quantity
            // else:
            //     relevant_qty = self._get_out_and_not_invoiced_qty(valuation_stock_moves)
            // 
            // return price_unit_val_dif, relevant_qty
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetProductCatalogLinesDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_product_catalog_lines_data(self, **kwargs):
            // """
            // Return information about account_move_line in `self`.
            // If `self` is empty, this method returns only the default value(s) needed for the product
            // catalog. In this case, the quantity that equals 0.
            // Otherwise, it returns a quantity and a price based on the product of the move line(s) and whether
            // the product is read-only or not.
            // A product is considered read-only if the order is considered read-only or if `self` contains multiple records.
            // Note: This method cannot be called with multiple records that have different products linked.
            // 
            // :param products: Recordset of `product.product`.
            // :param dict kwargs: additional values given for inherited models.
            // :rtype: dict
            // :return: A dict with the following structure:
            //     {
            //         'quantity': float,
            //         'price': float,
            //         'readOnly': bool,
            //         'min_qty': int, (optional)
            //     }
            // """
            // if self:
            //     self.product_id.ensure_one()
            //     return {
            //         **self[0].move_id._get_product_price_and_data(self[0].product_id),
            //         'quantity': sum(
            //             self.mapped(
            //                 lambda line: line.product_uom_id._compute_quantity(
            //                     qty=line.quantity,
            //                     to_unit=line.product_id.uom_id,
            //                 )
            //             )
            //         ),
            //         'readOnly': self.move_id._is_readonly() or len(self) > 1,
            //     }
            // return {
            //     'quantity': 0,
            // }
            */
            return default;
        }

        protected async Task<object> GetQueryTaxDetailsFromDomainInternalAsync(object domain, object fallback)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line_tax_details.py) ---
            // def _get_query_tax_details_from_domain(self, domain, fallback=True) -> SQL:
            // """ Create the tax details sub-query based on the orm domain passed as parameter.
            // 
            // :param domain:      An orm domain on account.move.line.
            // :param fallback:    Fallback on an approximated mapping if the mapping failed.
            // :return:            query as SQL object
            // """
            // self.env['account.move.line'].check_access('read')
            // 
            // query = self.env['account.move.line']._where_calc(domain)
            // 
            // # Wrap the query with 'company_id IN (...)' to avoid bypassing company access rights.
            // self.env['account.move.line']._apply_ir_rules(query)
            // 
            // return self._get_query_tax_details(query.from_clause, query.where_clause, fallback=fallback)
            */
            return default;
        }

        protected async Task<object> GetQueryTaxDetailsInternalAsync(object table_references, object search_condition, object fallback)
        {
            #if PYTHON_CODE
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line_tax_details.py) ---
            // def _get_query_tax_details(self, table_references, search_condition, fallback=True) -> SQL:
            // """ Create the tax details sub-query based on the orm domain passed as parameter.
            // 
            // :param table_references:    The query to inject after the FROM, as an SQL object.
            // :param search_condition:    The query to inject in the WHERE clause, as an SQL object.
            // :param fallback:            Fallback on an approximated mapping if the mapping failed.
            // :return:                    query as an SQL object
            // """
            // group_taxes = self.env['account.tax'].search([('amount_type', '=', 'group')])
            // 
            // group_taxes_query_list = []
            // for group_tax in group_taxes:
            //     children_taxes = group_tax.children_tax_ids
            //     if not children_taxes:
            //         continue
            // 
            //     children_taxes_in_query = SQL(','.join('%s' for dummy in children_taxes),
            //                                   *children_taxes.ids)
            //     group_taxes_query_list.append(SQL('WHEN tax.id = %s THEN ARRAY[%s]', group_tax.id, children_taxes_in_query))
            // 
            // if group_taxes_query_list:
            //     group_taxes_query = SQL('''UNNEST(CASE %s ELSE ARRAY[tax.id] END)''', SQL(' ').join(group_taxes_query_list))
            // else:
            //     group_taxes_query = SQL('tax.id')
            // 
            // if fallback:
            //     fallback_query = SQL(
            //         '''
            //         UNION ALL
            // 
            //         SELECT
            //             account_move_line.id AS tax_line_id,
            //             base_line.id AS base_line_id,
            //             base_line.id AS src_line_id,
            //             base_line.balance AS base_amount,
            //             base_line.amount_currency AS base_amount_currency
            //         FROM %(table_references)s
            //         LEFT JOIN base_tax_line_mapping ON
            //             base_tax_line_mapping.tax_line_id = account_move_line.id
            //         JOIN account_move_line_account_tax_rel tax_rel ON
            //             tax_rel.account_tax_id = COALESCE(account_move_line.group_tax_id, account_move_line.tax_line_id)
            //         JOIN account_move_line base_line ON
            //             base_line.id = tax_rel.account_move_line_id
            //             AND base_line.tax_repartition_line_id IS NULL
            //             AND base_line.move_id = account_move_line.move_id
            //             AND base_line.currency_id = account_move_line.currency_id
            //         WHERE base_tax_line_mapping.tax_line_id IS NULL
            //         AND %(search_condition)s
            //         ''',
            //         table_references=table_references,
            //         search_condition=search_condition,
            //     )
            // else:
            //     fallback_query = SQL()
            // 
            // extra_query_base_tax_line_mapping = self._get_extra_query_base_tax_line_mapping()
            // 
            // return SQL(
            //     '''
            //     /*
            //     As example to explain the different parts of the query, we'll consider a move with the following lines:
            //     Name            Tax_line_id         Tax_ids                 Debit       Credit      Base lines
            //     ---------------------------------------------------------------------------------------------------
            //     base_line_1                         10_affect_base, 20      1000
            //     base_line_2                         10_affect_base, 5       2000
            //     base_line_3                         10_affect_base, 5       3000
            //     tax_line_1      10_affect_base      20                                  100         base_line_1
            //     tax_line_2      20                                                      220         base_line_1
            //     tax_line_3      10_affect_base      5                                   500         base_line_2/3
            //     tax_line_4      5                                                       275         base_line_2/3
            //     */
            // 
            //     WITH base_tax_line_mapping AS (
            // 
            //         /*
            //         Create the mapping of each tax lines with their corresponding base lines.
            // 
            //         In the example, it will give the following values:
            //             base_line_id     tax_line_id    base_amount
            //             -------------------------------------------
            //             base_line_1      tax_line_1         1000
            //             base_line_1      tax_line_2         1000
            //             base_line_2      tax_line_3         2000
            //             base_line_2      tax_line_4         2000
            //             base_line_3      tax_line_3         3000
            //             base_line_3      tax_line_4         3000
            //         */
            // 
            //         SELECT
            //             account_move_line.id AS tax_line_id,
            //             base_line.id AS base_line_id,
            //             base_line.balance AS base_amount,
            //             base_line.amount_currency AS base_amount_currency
            // 
            //         FROM %(table_references)s
            //         JOIN account_tax_repartition_line tax_rep ON
            //             tax_rep.id = account_move_line.tax_repartition_line_id
            //         JOIN account_tax tax ON
            //             tax.id = account_move_line.tax_line_id
            //         JOIN account_move_line_account_tax_rel tax_rel ON
            //             tax_rel.account_tax_id = COALESCE(account_move_line.group_tax_id, account_move_line.tax_line_id)
            //         JOIN account_move move ON
            //             move.id = account_move_line.move_id
            //         JOIN account_move_line base_line ON
            //             base_line.id = tax_rel.account_move_line_id
            //             AND base_line.tax_repartition_line_id IS NULL
            //             AND base_line.move_id = account_move_line.move_id
            //             AND (
            //                 move.move_type != 'entry'
            //                 OR
            //                 sign(account_move_line.balance) = sign(base_line.balance * tax.amount * tax_rep.factor_percent)
            //             )
            //             AND COALESCE(base_line.partner_id, 0) = COALESCE(account_move_line.partner_id, 0)
            //             AND base_line.currency_id = account_move_line.currency_id
            //             AND (
            //                 COALESCE(tax_rep.account_id, base_line.account_id) = account_move_line.account_id
            //                 OR (tax.tax_exigibility = 'on_payment' AND tax.cash_basis_transition_account_id IS NOT NULL)
            //             )
            //             AND (
            //                 (tax.analytic IS NULL OR tax.analytic = FALSE)
            //                 OR (base_line.analytic_distribution IS NULL AND account_move_line.analytic_distribution IS NULL)
            //                 OR base_line.analytic_distribution = account_move_line.analytic_distribution
            //             )
            //             %(extra_query_base_tax_line_mapping)s
            //         JOIN res_currency curr ON
            //             curr.id = account_move_line.currency_id
            //         JOIN res_currency comp_curr ON
            //             comp_curr.id = account_move_line.company_currency_id
            //         LEFT JOIN LATERAL (
            //             /*
            //                 This table builds a reference table based on the tax_ids field, with the following changes:
            //                   - flatten the group of taxes
            //                   - exclude the taxes having 'is_base_affected' set to False.
            //                 Those allow to match only base_line_1 when finding the base lines of tax_line_1, as we need to find
            //                 base lines having a 'affecting_base_tax_ids' ending with [10_affect_base, 20], not only containing
            //                 '10_affect_base'. Otherwise, base_line_2/3 would also be matched.
            //                 In our example, as all the taxes are set to be affected by previous ones affecting the base, the
            //                 result is similar to the table 'account_move_line_account_tax_rel':
            //                 Id                 Tax_ids
            //                 -------------------------------------------
            //                 base_line_1        [10_affect_base, 20]
            //                 base_line_2        [10_affect_base, 5]
            //                 base_line_3        [10_affect_base, 5]
            //             */
            //             SELECT ARRAY_AGG(sub.tax_id ORDER BY sub.sequence, sub.tax_id) AS tax_ids
            //             FROM (
            //                 SELECT
            //                     %(group_taxes_query)s AS tax_id,
            //                     tax.sequence
            //                 FROM account_move_line_account_tax_rel tax_rel
            //                 JOIN account_tax tax ON tax.id = tax_rel.account_tax_id
            //                 WHERE tax.is_base_affected
            //                 AND tax_rel.account_move_line_id = account_move_line.id
            //             ) AS sub
            //         ) tax_line_tax_ids ON TRUE
            //         LEFT JOIN LATERAL (
            //             SELECT ARRAY_AGG(sub.tax_id ORDER BY sub.sequence, sub.tax_id) AS tax_ids
            //             FROM (
            //                 SELECT
            //                     %(group_taxes_query)s AS tax_id,
            //                     tax.sequence
            //                 FROM account_move_line_account_tax_rel tax_rel
            //                 JOIN account_tax tax ON tax.id = tax_rel.account_tax_id
            //                 WHERE tax.is_base_affected
            //                 AND tax_rel.account_move_line_id = base_line.id
            //             ) AS sub
            //         ) base_line_tax_ids ON TRUE
            //         WHERE account_move_line.tax_repartition_line_id IS NOT NULL
            //             AND %(search_condition)s
            //             AND (
            //                 -- keeping only the rows from affecting_base_tax_lines that end with the same taxes applied (see comment in tax_line_tax_ids)
            //                 NOT tax.include_base_amount
            //                 OR base_line_tax_ids.tax_ids[ARRAY_LENGTH(base_line_tax_ids.tax_ids, 1) - COALESCE(ARRAY_LENGTH(tax_line_tax_ids.tax_ids, 1), 0):ARRAY_LENGTH(base_line_tax_ids.tax_ids, 1)]
            //                     = ARRAY[account_move_line.tax_line_id] || COALESCE(tax_line_tax_ids.tax_ids, ARRAY[]::INTEGER[])
            //             )
            //     ),
            // 
            // 
            //     tax_amount_affecting_base_to_dispatch AS (
            // 
            //         /*
            //         Computes the total amount to dispatch in case of tax lines affecting the base of subsequent taxes.
            //         Such tax lines are an additional base amount for others lines, that will be truly dispatch in next
            //         CTE.
            // 
            //         In the example:
            //             - tax_line_1 is an additional base of 100.0 from base_line_1 for tax_line_2.
            //             - tax_line_3 is an additional base of 2/5 * 500.0 = 200.0 from base_line_2 for tax_line_4.
            //             - tax_line_3 is an additional base of 3/5 * 500.0 = 300.0 from base_line_3 for tax_line_4.
            // 
            //             src_line_id    base_line_id     tax_line_id    total_base_amount
            //             -------------------------------------------------------------
            //             tax_line_1     base_line_1      tax_line_2         1000
            //             tax_line_3     base_line_2      tax_line_4         5000
            //             tax_line_3     base_line_3      tax_line_4         5000
            //         */
            // 
            //         SELECT
            //             tax_line.id AS tax_line_id,
            //             base_line.id AS base_line_id,
            //             account_move_line.id AS src_line_id,
            // 
            //             tax_line.company_id,
            //             comp_curr.id AS company_currency_id,
            //             comp_curr.decimal_places AS comp_curr_prec,
            //             curr.id AS currency_id,
            //             curr.decimal_places AS curr_prec,
            // 
            //             tax_line.tax_line_id AS tax_id,
            // 
            //             base_line.balance AS base_amount,
            //             SUM(
            //                 CASE WHEN tax.amount_type = 'fixed'
            //                 THEN CASE WHEN base_line.balance < 0 THEN -1 ELSE 1 END * ABS(COALESCE(base_line.quantity, 1.0))
            //                 ELSE base_line.balance
            //                 END
            //             ) OVER (PARTITION BY tax_line.id, account_move_line.id ORDER BY tax_line.tax_line_id, base_line.id) AS cumulated_base_amount,
            //             SUM(
            //                 CASE WHEN tax.amount_type = 'fixed'
            //                 THEN CASE WHEN base_line.balance < 0 THEN -1 ELSE 1 END * ABS(COALESCE(base_line.quantity, 1.0))
            //                 ELSE base_line.balance
            //                 END
            //             ) OVER (PARTITION BY tax_line.id, account_move_line.id) AS total_base_amount,
            //             account_move_line.balance AS total_tax_amount,
            // 
            //             base_line.amount_currency AS base_amount_currency,
            //             SUM(
            //                 CASE WHEN tax.amount_type = 'fixed'
            //                 THEN CASE WHEN base_line.amount_currency < 0 THEN -1 ELSE 1 END * ABS(COALESCE(base_line.quantity, 1.0))
            //                 ELSE base_line.amount_currency
            //                 END
            //             ) OVER (PARTITION BY tax_line.id, account_move_line.id ORDER BY tax_line.tax_line_id, base_line.id) AS cumulated_base_amount_currency,
            //             SUM(
            //                 CASE WHEN tax.amount_type = 'fixed'
            //                 THEN CASE WHEN base_line.amount_currency < 0 THEN -1 ELSE 1 END * ABS(COALESCE(base_line.quantity, 1.0))
            //                 ELSE base_line.amount_currency
            //                 END
            //             ) OVER (PARTITION BY tax_line.id, account_move_line.id) AS total_base_amount_currency,
            //             account_move_line.amount_currency AS total_tax_amount_currency
            // 
            //         FROM %(table_references)s
            //         JOIN account_tax tax_include_base_amount ON
            //             tax_include_base_amount.include_base_amount
            //             AND tax_include_base_amount.id = account_move_line.tax_line_id
            //         JOIN base_tax_line_mapping base_tax_line_mapping ON
            //             base_tax_line_mapping.tax_line_id = account_move_line.id
            //         JOIN account_move_line_account_tax_rel tax_rel ON
            //             tax_rel.account_move_line_id = base_tax_line_mapping.tax_line_id
            //         JOIN account_tax tax ON
            //             tax.id = tax_rel.account_tax_id
            //         JOIN base_tax_line_mapping tax_line_matching ON
            //             tax_line_matching.base_line_id = base_tax_line_mapping.base_line_id
            //         JOIN account_move_line tax_line ON
            //             tax_line.id = tax_line_matching.tax_line_id
            //             AND tax_line.tax_line_id = tax_rel.account_tax_id
            //         JOIN res_currency curr ON
            //             curr.id = tax_line.currency_id
            //         JOIN res_currency comp_curr ON
            //             comp_curr.id = tax_line.company_currency_id
            //         JOIN account_move_line base_line ON
            //             base_line.id = base_tax_line_mapping.base_line_id
            //         WHERE %(search_condition)s
            //     ),
            // 
            // 
            //     base_tax_matching_base_amounts AS (
            // 
            //         /*
            //         Build here the full mapping tax lines <=> base lines containing the final base amounts.
            //         This is done in a 3-parts union.
            // 
            //         Note: src_line_id is used only to build a unique ID.
            //         */
            // 
            //         /*
            //         PART 1: raw mapping computed in base_tax_line_mapping.
            //         */
            // 
            //         SELECT
            //             tax_line_id,
            //             base_line_id,
            //             base_line_id AS src_line_id,
            //             base_amount,
            //             base_amount_currency
            //         FROM base_tax_line_mapping
            // 
            //         UNION ALL
            // 
            //         /*
            //         PART 2: Dispatch the tax amount of tax lines affecting the base of subsequent ones, using
            //         tax_amount_affecting_base_to_dispatch.
            // 
            //         This will effectively add the following rows:
            //         base_line_id    tax_line_id     src_line_id     base_amount
            //         -------------------------------------------------------------
            //         base_line_1     tax_line_2      tax_line_1      100
            //         base_line_2     tax_line_4      tax_line_3      200
            //         base_line_3     tax_line_4      tax_line_3      300
            //         */
            // 
            //         SELECT
            //             sub.tax_line_id,
            //             sub.base_line_id,
            //             sub.src_line_id,
            // 
            //             ROUND(
            //                 COALESCE(SIGN(sub.cumulated_base_amount) * sub.total_tax_amount * ABS(sub.cumulated_base_amount) / NULLIF(sub.total_base_amount, 0.0), 0.0),
            //                 sub.comp_curr_prec
            //             )
            //             - LAG(ROUND(
            //                 COALESCE(SIGN(sub.cumulated_base_amount) * sub.total_tax_amount * ABS(sub.cumulated_base_amount) / NULLIF(sub.total_base_amount, 0.0), 0.0),
            //                 sub.comp_curr_prec
            //             ), 1, 0.0)
            //             OVER (
            //                 PARTITION BY sub.tax_line_id, sub.src_line_id ORDER BY sub.tax_id, sub.base_line_id
            //             ) AS base_amount,
            // 
            //             ROUND(
            //                 COALESCE(SIGN(sub.cumulated_base_amount_currency) * sub.total_tax_amount_currency * ABS(sub.cumulated_base_amount_currency) / NULLIF(sub.total_base_amount_currency, 0.0), 0.0),
            //                 sub.curr_prec
            //             )
            //             - LAG(ROUND(
            //                 COALESCE(SIGN(sub.cumulated_base_amount_currency) * sub.total_tax_amount_currency * ABS(sub.cumulated_base_amount_currency) / NULLIF(sub.total_base_amount_currency, 0.0), 0.0),
            //                 sub.curr_prec
            //             ), 1, 0.0)
            //             OVER (
            //                 PARTITION BY sub.tax_line_id, sub.src_line_id ORDER BY sub.tax_id, sub.base_line_id
            //             ) AS base_amount_currency
            //         FROM tax_amount_affecting_base_to_dispatch sub
            //         JOIN account_move_line tax_line ON
            //             tax_line.id = sub.tax_line_id
            // 
            //         /*
            //         PART 3: In case of the matching failed because the configuration changed or some journal entries
            //         have been imported, construct a simple mapping as a fallback. This mapping is super naive and only
            //         build based on the 'tax_ids' and 'tax_line_id' fields, nothing else. Hence, the mapping will not be
            //         exact but will give an acceptable approximation.
            // 
            //         Skipped if the 'fallback' method parameter is False.
            //         */
            //         %(fallback_query)s
            //     ),
            // 
            // 
            //     base_tax_matching_all_amounts AS (
            // 
            //         /*
            //         Complete base_tax_matching_base_amounts with the tax amounts (prorata):
            //         base_line_id    tax_line_id     src_line_id     base_amount     tax_amount
            //         --------------------------------------------------------------------------
            //         base_line_1     tax_line_1      base_line_1     1000            100
            //         base_line_1     tax_line_2      base_line_1     1000            (1000 / 1100) * 220 = 200
            //         base_line_1     tax_line_2      tax_line_1      100             (100 / 1100) * 220 = 20
            //         base_line_2     tax_line_3      base_line_2     2000            (2000 / 5000) * 500 = 200
            //         base_line_2     tax_line_4      base_line_2     2000            (2000 / 5500) * 275 = 100
            //         base_line_2     tax_line_4      tax_line_3      200             (200 / 5500) * 275 = 10
            //         base_line_3     tax_line_3      base_line_3     3000            (3000 / 5000) * 500 = 300
            //         base_line_3     tax_line_4      base_line_3     3000            (3000 / 5500) * 275 = 150
            //         base_line_3     tax_line_4      tax_line_3      300             (300 / 5500) * 275 = 15
            //         */
            // 
            //         SELECT
            //             sub.tax_line_id,
            //             sub.base_line_id,
            //             sub.src_line_id,
            // 
            //             tax_line.tax_line_id AS tax_id,
            //             tax_line.group_tax_id,
            //             tax_line.tax_repartition_line_id,
            //             tax_line.analytic_distribution,
            // 
            //             tax_line.company_id,
            //             tax_line.display_type AS display_type,
            //             comp_curr.id AS company_currency_id,
            //             comp_curr.decimal_places AS comp_curr_prec,
            //             curr.id AS currency_id,
            //             curr.decimal_places AS curr_prec,
            //             (
            //                 tax.tax_exigibility != 'on_payment'
            //                 OR tax_move.tax_cash_basis_rec_id IS NOT NULL
            //                 OR tax_move.always_tax_exigible
            //             ) AS tax_exigible,
            //             base_line.account_id AS base_account_id,
            // 
            //             sub.base_amount,
            //             SUM(
            //                 CASE WHEN tax.amount_type = 'fixed'
            //                 THEN CASE WHEN base_line.balance < 0 THEN -1 ELSE 1 END * ABS(COALESCE(base_line.quantity, 1.0))
            //                 ELSE sub.base_amount
            //                 END
            //             ) OVER (PARTITION BY tax_line.id ORDER BY tax_line.tax_line_id, sub.base_line_id, sub.src_line_id) AS cumulated_base_amount,
            //             SUM(
            //                 CASE WHEN tax.amount_type = 'fixed'
            //                 THEN CASE WHEN base_line.balance < 0 THEN -1 ELSE 1 END * ABS(COALESCE(base_line.quantity, 1.0))
            //                 ELSE sub.base_amount
            //                 END
            //             ) OVER (PARTITION BY tax_line.id) AS total_base_amount,
            //             tax_line.balance AS total_tax_amount,
            // 
            //             sub.base_amount_currency,
            //             SUM(
            //                 CASE WHEN tax.amount_type = 'fixed'
            //                 THEN CASE WHEN base_line.amount_currency < 0 THEN -1 ELSE 1 END * ABS(COALESCE(base_line.quantity, 1.0))
            //                 ELSE sub.base_amount_currency
            //                 END
            //             ) OVER (PARTITION BY tax_line.id ORDER BY tax_line.tax_line_id, sub.base_line_id, sub.src_line_id) AS cumulated_base_amount_currency,
            //             SUM(
            //                 CASE WHEN tax.amount_type = 'fixed'
            //                 THEN CASE WHEN base_line.amount_currency < 0 THEN -1 ELSE 1 END * ABS(COALESCE(base_line.quantity, 1.0))
            //                 ELSE sub.base_amount_currency
            //                 END
            //             ) OVER (PARTITION BY tax_line.id) AS total_base_amount_currency,
            //             tax_line.amount_currency AS total_tax_amount_currency
            // 
            //         FROM base_tax_matching_base_amounts sub
            //         JOIN account_move_line tax_line ON
            //             tax_line.id = sub.tax_line_id
            //         JOIN account_move tax_move ON
            //             tax_move.id = tax_line.move_id
            //         JOIN account_move_line base_line ON
            //             base_line.id = sub.base_line_id
            //         JOIN account_tax tax ON
            //             tax.id = tax_line.tax_line_id
            //         JOIN res_currency curr ON
            //             curr.id = tax_line.currency_id
            //         JOIN res_currency comp_curr ON
            //             comp_curr.id = tax_line.company_currency_id
            // 
            //     )
            // 
            // 
            //    /* Final select that makes sure to deal with rounding errors, using LAG to dispatch the last cents. */
            // 
            //     SELECT
            //         sub.tax_line_id || '-' || sub.base_line_id || '-' || sub.src_line_id AS id,
            // 
            //         sub.base_line_id,
            //         sub.tax_line_id,
            //         sub.display_type,
            //         sub.src_line_id,
            //         sub.analytic_distribution,
            // 
            //         sub.tax_id,
            //         sub.group_tax_id,
            //         sub.tax_exigible,
            //         sub.base_account_id,
            //         sub.tax_repartition_line_id,
            // 
            //         sub.base_amount,
            //         COALESCE(
            //             ROUND(
            //                 COALESCE(SIGN(sub.cumulated_base_amount) * sub.total_tax_amount * ABS(sub.cumulated_base_amount) / NULLIF(sub.total_base_amount, 0.0), 0.0),
            //                 sub.comp_curr_prec
            //             )
            //             - LAG(ROUND(
            //                 COALESCE(SIGN(sub.cumulated_base_amount) * sub.total_tax_amount * ABS(sub.cumulated_base_amount) / NULLIF(sub.total_base_amount, 0.0), 0.0),
            //                 sub.comp_curr_prec
            //             ), 1, 0.0)
            //             OVER (
            //                 PARTITION BY sub.tax_line_id ORDER BY sub.tax_id, sub.base_line_id
            //             ),
            //             0.0
            //         ) AS tax_amount,
            // 
            //         sub.base_amount_currency,
            //         COALESCE(
            //             ROUND(
            //                 COALESCE(SIGN(sub.cumulated_base_amount_currency) * sub.total_tax_amount_currency * ABS(sub.cumulated_base_amount_currency) / NULLIF(sub.total_base_amount_currency, 0.0), 0.0),
            //                 sub.curr_prec
            //             )
            //             - LAG(ROUND(
            //                 COALESCE(SIGN(sub.cumulated_base_amount_currency) * sub.total_tax_amount_currency * ABS(sub.cumulated_base_amount_currency) / NULLIF(sub.total_base_amount_currency, 0.0), 0.0),
            //                 sub.curr_prec
            //             ), 1, 0.0)
            //             OVER (
            //                 PARTITION BY sub.tax_line_id ORDER BY sub.tax_id, sub.base_line_id
            //             ),
            //             0.0
            //         ) AS tax_amount_currency
            //     FROM base_tax_matching_all_amounts sub
            //     ''',
            //     extra_query_base_tax_line_mapping=extra_query_base_tax_line_mapping,
            //     group_taxes_query=group_taxes_query,
            //     search_condition=search_condition,
            //     table_references=table_references,
            //     fallback_query=fallback_query,
            // )
            #endif
            return default;
        }

        protected async Task<AccountMoveLine> GetRateDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_rate_date(self):
            // self.ensure_one()
            // return self.move_id.invoice_date or self.move_id.date or fields.Date.context_today(self)
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetReconciliationAmlFieldValueInternalAsync(object field, object shadowed_aml_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_reconciliation_aml_field_value(self, field, shadowed_aml_values):
            // self.ensure_one()
            // if shadowed_aml_values and field in shadowed_aml_values.get(self, {}):
            //     return shadowed_aml_values[self][field]
            // else:
            //     return self[field]
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetResultInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: account_move.py) ---
            // def _get_result(self):
            // for aml in self:
            //     aml.result = aml.debit - aml.credit
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetSoMappingDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: account_move_line.py) ---
            // def _get_so_mapping_domain(self):
            // return OR([
            //     OR([
            //         AND([
            //             [(self.env['account.analytic.account'].browse(int(account_id)).root_plan_id._column_name(), "=", int(account_id))]
            //             for account_id in key.split(",")
            //         ])
            //         for key in line.analytic_distribution or []
            //     ])
            //     for line in self
            // ])
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetSoMappingFromExpenseInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_expense, FILE: account_move_line.py) ---
            // def _get_so_mapping_from_expense(self):
            // mapping_from_expense = {}
            // for move_line in self.filtered(lambda move_line: move_line.expense_id):
            //     mapping_from_expense[move_line.id] = move_line.expense_id.sale_order_id or None
            // return mapping_from_expense
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetSoMappingFromProjectInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: account_move_line.py) ---
            // def _get_so_mapping_from_project(self):
            // """ Get the mapping of move.line with the sale.order record on which its analytic entries should be reinvoiced.
            //     A sale.order matches a move.line if the sale.order's project contains all the same analytic accounts
            //     as the ones in the distribution of the move.line.
            //     :return a dict where key is the move line id, and value is sale.order record (or None).
            // """
            // mapping = {}
            // projects = self.env['project.project'].search(domain=self._get_so_mapping_domain())
            // orders_per_project = dict(self.env['sale.order']._read_group(
            //     domain=[('project_id', 'in', projects.ids)],
            //     groupby=['project_id'],
            //     aggregates=['id:recordset']
            // ))
            // project_per_accounts = {
            //     next(iter(project._get_analytic_distribution())): project
            //     for project in projects
            // }
            // 
            // for move_line in self:
            //     analytic_distribution = move_line.analytic_distribution
            //     if not analytic_distribution:
            //         continue
            // 
            //     for accounts in analytic_distribution:
            //         project = project_per_accounts.get(accounts)
            //     if not project:
            //         continue
            // 
            //     orders = orders_per_project.get(project)
            //     if not orders:
            //         continue
            //     orders = orders.sorted('create_date')
            //     in_sale_state_orders = orders.filtered(lambda s: s.state == 'sale')
            // 
            //     mapping[move_line.id] = in_sale_state_orders[0] if in_sale_state_orders else orders[0]
            // 
            // # map the move line index with the SO on which it needs to be reinvoiced. May be empty if no SO found
            // return mapping
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetStockValuationLayersInternalAsync(object move)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_mrp, FILE: account_move.py) ---
            // def _get_stock_valuation_layers(self, move):
            // """ Do not handle the invoice correction for kit. It has to be done
            // manually """
            // layers = super()._get_stock_valuation_layers(move)
            // return layers.filtered(lambda svl: svl.product_id == self.product_id)
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move.py) ---
            // def _get_stock_valuation_layers(self, move):
            // valued_moves = self._get_valued_in_moves()
            // if move.move_type == 'in_refund':
            //     valued_moves = valued_moves.filtered(lambda stock_move: stock_move._is_out())
            // else:
            //     valued_moves = valued_moves.filtered(lambda stock_move: stock_move._is_in())
            // return valued_moves.stock_valuation_layer_ids
            --- ODOO METHOD SOURCE (MODULE: stock_landed_costs, FILE: account_move.py) ---
            // def _get_stock_valuation_layers(self, move):
            // layers = super()._get_stock_valuation_layers(move)
            // return layers.filtered(lambda svl: not svl.stock_landed_cost_id)
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetTaxExigibleDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_tax_exigible_domain(self):
            // """ Returns a domain to be used to identify the move lines that are allowed
            // to be taken into account in the tax report.
            // """
            // return [
            //     # Lines on moves without any payable or receivable line are always exigible
            //     '|', ('move_id.always_tax_exigible', '=', True),
            // 
            //     # Lines with only tags are always exigible
            //     '|', '&', ('tax_line_id', '=', False), ('tax_ids', '=', False),
            // 
            //     # Lines from CABA entries are always exigible
            //     '|', ('move_id.tax_cash_basis_rec_id', '!=', False),
            // 
            //     # Lines from non-CABA taxes are always exigible
            //     '|', ('tax_line_id.tax_exigibility', '!=', 'on_payment'),
            //     ('tax_ids.tax_exigibility', '!=', 'on_payment'), # So: exigible if at least one tax from tax_ids isn't on_payment
            // ]
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetValuedInMovesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: account_move_line.py) ---
            // def _get_valued_in_moves(self):
            // res = super()._get_valued_in_moves()
            // # subcontracted move valuations are not linked to the PO move but its orig move (the MO finished move)
            // res |= res.filtered(lambda m: m.is_subcontract).move_orig_ids
            // return res
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: account_move_line.py) ---
            // def _get_valued_in_moves(self):
            // self.ensure_one()
            // return self.purchase_line_id.move_ids.filtered(
            //     lambda m: m.state == 'done' and m.product_qty != 0)
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move.py) ---
            // def _get_valued_in_moves(self):
            // return self.env['stock.move']
            */
            return default;
        }

        public async Task<AccountMoveLine> GetViewsAsync(Guid id, AccountMoveLineGetViewsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def get_views(self, views, options=None):
            // res = super().get_views(views, options)
            // if res['views'].get('list') and self.env['ir.ui.view'].sudo().browse(res['views']['list']['id']).name == "account.move.line.payment.list":
            //     if toolbar := res['views']['list'].get('toolbar'):
            //         # We dont want any additionnal action in the "account.move.line.payment.list" view toolbar
            //         toolbar['action'] = []
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMoveLine> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def init(self):
            // """ change index on partner_id to a multi-column index on (partner_id, ref), the new index will behave in the
            //     same way when we search on partner_id, with the addition of being optimal when having a query that will
            //     search on partner_id and ref at the same time (which is the case when we open the bank reconciliation widget)
            // """
            // create_index(self._cr, 'account_move_line_partner_id_ref_idx', 'account_move_line', ["partner_id", "ref"])
            // create_index(self._cr, 'account_move_line_date_name_id_idx', 'account_move_line', ["date desc", "move_name desc", "id"])
            // # Match exactly how the ORM converts domains to ensure the query planner uses it
            // create_index(self._cr, 'account_move_line__unreconciled_index', 'account_move_line', ['account_id', 'partner_id'],
            //              where="(reconciled IS NULL OR reconciled = false OR reconciled IS NOT true) AND parent_state = 'posted'")
            // create_index(self.env.cr,
            //              indexname='account_move_line_journal_id_neg_amnt_residual_idx',
            //              tablename='account_move_line',
            //              expressions=['journal_id'],
            //              where="amount_residual < 0 AND parent_state = 'posted'")
            // # covers the standard index on account_id
            // create_index(self.env.cr,
            //              indexname='account_move_line_account_id_date_idx',
            //              tablename='account_move_line',
            //              expressions=['account_id', 'date'])
            // super().init()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMoveLine> InvalidateModelAsync(Guid id, AccountMoveLineInvalidateModelRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def invalidate_model(self, fnames=None, flush=True):
            // # Invalidate cache of related moves
            // if fnames is None or 'move_id' in fnames:
            //     field = self._fields['move_id']
            //     lines = self.env.cache.get_records(self, field)
            //     move_ids = {id_ for id_ in self.env.cache.get_values(lines, field) if id_}
            //     if move_ids:
            //         self.env['account.move'].browse(move_ids).invalidate_recordset()
            // return super().invalidate_model(fnames, flush)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMoveLine> InvalidateRecordsetAsync(Guid id, AccountMoveLineInvalidateRecordsetRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def invalidate_recordset(self, fnames=None, flush=True):
            // # Invalidate cache of related moves
            // if fnames is None or 'move_id' in fnames:
            //     field = self._fields['move_id']
            //     move_ids = {id_ for id_ in self.env.cache.get_values(self, field) if id_}
            //     if move_ids:
            //         self.env['account.move'].browse(move_ids).invalidate_recordset()
            // return super().invalidate_recordset(fnames, flush)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMoveLine> InverseAccountIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _inverse_account_id(self):
            // self._inverse_analytic_distribution()
            // self._conditional_add_to_compute('tax_ids', lambda line: (
            //     line.account_id.tax_ids
            //     and not line.product_id.taxes_id.filtered(lambda tax: tax.company_id == line.company_id)
            // ))
            */
            return default;
        }

        protected async Task<AccountMoveLine> InverseAmountCurrencyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _inverse_amount_currency(self):
            // for line in self:
            //     if line.currency_id == line.company_id.currency_id and line.balance != line.amount_currency:
            //         line.balance = line.amount_currency
            //     elif (
            //         line.currency_id != line.company_id.currency_id
            //         and not line.move_id.is_invoice(True)
            //         and not self.env.is_protected(self._fields['balance'], line)
            //     ):
            //         line.balance = line.company_id.currency_id.round(line.amount_currency / line.currency_rate)
            */
            return default;
        }

        protected async Task<AccountMoveLine> InverseAnalyticDistributionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _inverse_analytic_distribution(self):
            // """ Unlink and recreate analytic_lines when modifying the distribution."""
            // if self.env.context.get('skip_analytic_sync'):
            //     return
            // lines_to_modify = self.env['account.move.line'].browse([
            //     line.id for line in self if line.parent_state == "posted"
            // ]).with_context(skip_analytic_sync=True)
            // lines_to_modify.analytic_line_ids.unlink()
            // lines_to_modify._create_analytic_lines()
            */
            return default;
        }

        protected async Task<AccountMoveLine> InverseCreditInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _inverse_credit(self):
            // for line in self:
            //     if line.credit:
            //         line.debit = 0
            //     line.balance = line.debit - line.credit
            */
            return default;
        }

        protected async Task<AccountMoveLine> InverseDebitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _inverse_debit(self):
            // for line in self:
            //     if line.debit:
            //         line.credit = 0
            //     line.balance = line.debit - line.credit
            */
            return default;
        }

        protected async Task<AccountMoveLine> InversePartnerIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _inverse_partner_id(self):
            // self._conditional_add_to_compute('account_id', lambda line: (
            //     line.display_type == 'payment_term'  # recompute based on settings
            // ))
            */
            return default;
        }

        protected async Task<AccountMoveLine> InverseProductIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _inverse_product_id(self):
            // if self.product_id or not self.account_id:
            //     self._conditional_add_to_compute('account_id', lambda line: (
            //         line.display_type == 'product' and line.move_id.is_invoice(True)
            //     ))
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move.py) ---
            // def _inverse_product_id(self):
            // super(AccountMoveLine, self.filtered(lambda l: l.display_type != 'cogs'))._inverse_product_id()
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_move.py) ---
            // def _inverse_product_id(self):
            // res = super(AccountMoveLine, self)._inverse_product_id()
            // for rec in self:
            //     if rec.product_id:
            //         if rec.move_id.move_type == 'out_invoice':
            //             rec.asset_category_id = rec.product_id.product_tmpl_id.deferred_revenue_category_id.id
            //         elif rec.move_id.move_type == 'in_invoice':
            //             rec.asset_category_id = rec.product_id.product_tmpl_id.asset_category_id.id
            */
            return default;
        }

        public async Task<AccountMoveLine> OnchangeAssetCategoryIdAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_move.py) ---
            // def onchange_asset_category_id(self):
            // if self.move_id.move_type == 'out_invoice' and self.asset_category_id:
            //     self.account_id = self.asset_category_id.account_asset_id.id
            // elif self.move_id.move_type == 'in_invoice' and self.asset_category_id:
            //     self.account_id = self.asset_category_id.account_asset_id.id
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMoveLine> OnchangeIsLandedCostsLineInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_landed_costs, FILE: account_move.py) ---
            // def _onchange_is_landed_costs_line(self):
            // if self.is_landed_costs_line and self.product_id and self.product_type != 'service':
            //     self.is_landed_costs_line = False
            */
            return default;
        }

        protected async Task<AccountMoveLine> OnchangeProductIdLandedCostsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_landed_costs, FILE: account_move.py) ---
            // def _onchange_product_id_landed_costs(self):
            // if self.product_id.landed_cost_ok:
            //     self.is_landed_costs_line = True
            // else:
            //     self.is_landed_costs_line = False
            */
            return default;
        }

        public async Task<AccountMoveLine> OpenBusinessDocAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def action_open_business_doc(self):
            // return self.move_id.action_open_business_doc()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMoveLine> OpenReconcileViewAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def open_reconcile_view(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('account.action_account_moves_all_grouped_matching')
            // ids = self._all_reconciled_lines().filtered(lambda l: l.matched_debit_ids or l.matched_credit_ids).ids
            // action['domain'] = [('id', 'in', ids)]
            // return clean_action(action, self.env)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMoveLine> OptimizeReconciliationPlanInternalAsync(object reconciliation_plan, object shadowed_aml_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _optimize_reconciliation_plan(self, reconciliation_plan, shadowed_aml_values=None):
            // """ Decode the initial reconciliation plan passed as parameter and converted it into a list of tree depicting
            // the way the reconciliation should be done.
            // Also, this method is responsible sorting the amls and splitting them by currency.
            // Then, this method checks the parameter to ensure we are not going to perform any invalid reconciliation like
            // a cross-account/cross-company partial.
            // 
            // The split by currencies is made as follows.
            // Suppose account.move.line(1, 2) are expressed in currency1 and account.move.line(3, 4) are expressed
            // in currency2.
            // If the reconciliation plan is [account.move.line(1, 2, 3, 4)], the optimizer will convert it into:
            // [[account.move.line(1, 2), account.move.line(3, 4)]]
            // 
            // :param reconciliation_plan: A list of reconciliation to perform.
            // :param shadowed_aml_values: A mapping aml -> dictionary to replace some original aml values to something else.
            //                             This is usefull if you want to preview the reconciliation before doing some changes
            //                             on amls like changing a date or an account.
            // :return: A list of dictionaries containing:
            //     * amls: A recordset.
            //     * aml_ids: The recordset ids.
            //     * nodes: A list of sub-nodes.
            // """
            // 
            // def process_amls(amls):
            //     if self._context.get('reduced_line_sorting'):
            //         sorted_amls = amls.sorted(key=lambda aml: (
            //             aml._get_reconciliation_aml_field_value('date_maturity', shadowed_aml_values)
            //                 or aml._get_reconciliation_aml_field_value('date', shadowed_aml_values),
            //             aml._get_reconciliation_aml_field_value('currency_id', shadowed_aml_values),
            //         ))
            //     else:
            //         sorted_amls = amls.sorted(key=lambda aml: (
            //             aml._get_reconciliation_aml_field_value('date_maturity', shadowed_aml_values)
            //                 or aml._get_reconciliation_aml_field_value('date', shadowed_aml_values),
            //             aml._get_reconciliation_aml_field_value('currency_id', shadowed_aml_values),
            //             aml._get_reconciliation_aml_field_value('amount_currency', shadowed_aml_values),
            //             aml._get_reconciliation_aml_field_value('balance', shadowed_aml_values),
            //         ))
            //     currencies = sorted_amls.mapped(lambda x: x._get_reconciliation_aml_field_value('currency_id', shadowed_aml_values))
            //     results = {
            //         'amls': sorted_amls,
            //         'aml_ids': set(sorted_amls.ids),
            //     }
            // 
            //     if len(currencies) != 1:
            //         nodes = results['nodes'] = []
            //         for currency in currencies:
            //             amls_in_currency = sorted_amls\
            //                 .filtered(lambda x: x._get_reconciliation_aml_field_value('currency_id', shadowed_aml_values) == currency)
            //             nodes.append({
            //                 'amls': amls_in_currency,
            //                 'aml_ids': set(amls_in_currency.ids),
            //             })
            //     return results
            // 
            // def process_children(children):
            //     node = {
            //         'nodes': [],
            //         'aml_ids': set(),
            //     }
            //     for child in children:
            //         results = process_leaf(child)
            //         if results:
            //             node['nodes'].append(results)
            //             node['aml_ids'].update(results['aml_ids'])
            //     node['amls'] = self.browse(node['aml_ids'])
            //     return node
            // 
            // def process_leaf(item):
            //     if not item:
            //         return
            // 
            //     if isinstance(item, models.BaseModel):
            //         # Group of amls to evaluate.
            //         return process_amls(item)
            //     else:
            //         # Sub plan to evaluate.
            //         return process_children(item)
            // 
            // plan_list = []
            // all_aml_ids = set()
            // for item in reconciliation_plan:
            //     plan_node = process_leaf(item)
            //     if not plan_node or not plan_node.get('amls'):
            //         continue
            // 
            //     # Check the amls to be reconciled all together.
            //     amls = plan_node['amls']
            //     amls._check_amls_exigibility_for_reconciliation(shadowed_aml_values=shadowed_aml_values)
            //     plan_list.append(plan_node)
            //     all_aml_ids.update(plan_node['aml_ids'])
            // 
            // return plan_list, self.browse(all_aml_ids)
            */
            return default;
        }

        protected async Task<AccountMoveLine> ParseFlushFnamesInternalAsync(object fnames)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _parse_flush_fnames(self, fnames):
            // if fnames and {'balance', 'amount_currency'} & set(fnames):
            //     # flush the amount currency to avoid triggering check_amount_currency_balance_sign
            //     fnames = {'balance', 'amount_currency'} | set(fnames)
            // return fnames
            */
            return default;
        }

        public async Task<AccountMoveLine> PaymentItemsRegisterPaymentAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def action_payment_items_register_payment(self):
            // return self.action_register_payment(ctx={'default_group_payment': True})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMoveLine> PrepareAnalyticDistributionLineInternalAsync(object distribution, List<Guid> account_ids, object distribution_on_each_plan)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _prepare_analytic_distribution_line(self, distribution, account_ids, distribution_on_each_plan):
            // """ Prepare the values used to create() an account.analytic.line upon validation of an account.move.line having
            //     analytic tags with analytic distribution.
            // """
            // self.ensure_one()
            // account_field_values = {}
            // decimal_precision = self.env['decimal.precision'].precision_get('Percentage Analytic')
            // amount = 0
            // for account in self.env['account.analytic.account'].browse(map(int, account_ids.split(","))).exists():
            //     distribution_plan = distribution_on_each_plan.get(account.root_plan_id, 0) + distribution
            //     if float_compare(distribution_plan, 100, precision_digits=decimal_precision) == 0:
            //         amount = -self.balance * (100 - distribution_on_each_plan.get(account.root_plan_id, 0)) / 100.0
            //     else:
            //         amount = -self.balance * distribution / 100.0
            //     distribution_on_each_plan[account.root_plan_id] = distribution_plan
            //     account_field_values[account.plan_id._column_name()] = account.id
            // default_name = self.name or (self.ref or '/' + ' -- ' + (self.partner_id and self.partner_id.name or '/'))
            // return {
            //     'name': default_name,
            //     'date': self.date,
            //     **account_field_values,
            //     'partner_id': self.partner_id.id,
            //     'unit_amount': self.quantity,
            //     'product_id': self.product_id and self.product_id.id or False,
            //     'product_uom_id': self.product_uom_id and self.product_uom_id.id or False,
            //     'amount': amount,
            //     'general_account_id': self.account_id.id,
            //     'ref': self.ref,
            //     'move_line_id': self.id,
            //     'user_id': self.move_id.invoice_user_id.id or self._uid,
            //     'company_id': self.company_id.id or self.env.company.id,
            //     'category': 'invoice' if self.move_id.is_sale_document() else 'vendor_bill' if self.move_id.is_purchase_document() else 'other',
            // }
            */
            return default;
        }

        protected async Task<AccountMoveLine> PrepareAnalyticLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _prepare_analytic_lines(self):
            // self.ensure_one()
            // analytic_line_vals = []
            // if self.analytic_distribution:
            //     # distribution_on_each_plan corresponds to the proportion that is distributed to each plan to be able to
            //     # give the real amount when we achieve a 100% distribution
            //     distribution_on_each_plan = {}
            //     for account_ids, distribution in self.analytic_distribution.items():
            //         line_values = self._prepare_analytic_distribution_line(float(distribution), account_ids, distribution_on_each_plan)
            //         if not self.currency_id.is_zero(line_values.get('amount')):
            //             analytic_line_vals.append(line_values)
            // return analytic_line_vals
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move_line.py) ---
            // def _prepare_analytic_lines(self):
            // """ Note: This method is called only on the move.line that having an analytic distribution, and
            //     so that should create analytic entries.
            // """
            // values_list = super(AccountMoveLine, self)._prepare_analytic_lines()
            // 
            // # filter the move lines that can be reinvoiced: a cost (negative amount) analytic line without SO line but with a product can be reinvoiced
            // move_to_reinvoice = self.env['account.move.line']
            // if len(values_list) > 0:
            //     for index, move_line in enumerate(self):
            //         values = values_list[index]
            //         if 'so_line' not in values:
            //             if move_line._sale_can_be_reinvoice():
            //                 move_to_reinvoice |= move_line
            // 
            // # insert the sale line in the create values of the analytic entries
            // if move_to_reinvoice.filtered(lambda aml: not aml.move_id.reversed_entry_id and aml.product_id):  # only if the move line is not a reversal one
            //     map_sale_line_per_move = move_to_reinvoice._sale_create_reinvoice_sale_line()
            //     for values in values_list:
            //         sale_line = map_sale_line_per_move.get(values.get('move_line_id'))
            //         if sale_line:
            //             values['so_line'] = sale_line.id
            // 
            // return values_list
            */
            return default;
        }

        protected async Task<AccountMoveLine> PrepareCreateValuesInternalAsync(object vals_list)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _prepare_create_values(self, vals_list):
            // result_vals_list = super()._prepare_create_values(vals_list)
            // for init_vals, res_vals in zip(vals_list, result_vals_list):
            //     # Allow computing the balance based on the amount_currency if it wasn't specified in the create vals.
            //     if (
            //         'amount_currency' in init_vals
            //         and 'balance' not in init_vals
            //         and 'debit' not in init_vals
            //         and 'credit' not in init_vals
            //     ):
            //         res_vals.pop('balance', 0)
            //         res_vals.pop('debit', 0)
            //         res_vals.pop('credit', 0)
            // 
            //     if res_vals['display_type'] in ('line_section', 'line_note'):
            //         res_vals.pop('account_id')
            // 
            // return result_vals_list
            */
            return default;
        }

        protected async Task<AccountMoveLine> PrepareEdiValsToExportInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _prepare_edi_vals_to_export(self):
            // ''' The purpose of this helper is the same as '_prepare_edi_vals_to_export' but for a single invoice line.
            // This includes the computation of the tax details for each invoice line or the management of the discount.
            // Indeed, in some EDI, we need to provide extra values depending the discount such as:
            // - the discount as an amount instead of a percentage.
            // - the price_unit but after subtraction of the discount.
            // 
            // :return: A python dict containing default pre-processed values.
            // '''
            // self.ensure_one()
            // 
            // if self.discount == 100.0:
            //     gross_price_subtotal = self.currency_id.round(self.price_unit * self.quantity)
            // else:
            //     gross_price_subtotal = self.currency_id.round(self.price_subtotal / (1 - self.discount / 100.0))
            // 
            // res = {
            //     'line': self,
            //     'price_unit_after_discount': self.currency_id.round(self.price_unit * (1 - (self.discount / 100.0))),
            //     'price_subtotal_before_discount': gross_price_subtotal,
            //     'price_subtotal_unit': self.currency_id.round(self.price_subtotal / self.quantity) if self.quantity else 0.0,
            //     'price_total_unit': self.currency_id.round(self.price_total / self.quantity) if self.quantity else 0.0,
            //     'price_discount': gross_price_subtotal - self.price_subtotal,
            //     'price_discount_unit': (gross_price_subtotal - self.price_subtotal) / self.quantity if self.quantity else 0.0,
            //     'gross_price_total_unit': self.currency_id.round(gross_price_subtotal / self.quantity) if self.quantity else 0.0,
            //     'unece_uom_code': self.product_id.product_tmpl_id.uom_id._get_unece_code(),
            // }
            // return res
            */
            return default;
        }

        protected async Task<AccountMoveLine> PrepareExchangeDifferenceMoveValsInternalAsync(object amounts_list, object company, object exchange_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _prepare_exchange_difference_move_vals(self, amounts_list, company=None, exchange_date=None, **kwargs):
            // """ Prepare values to create later the exchange difference journal entry.
            // The exchange difference journal entry is there to fix the debit/credit of lines when the journal items are
            // fully reconciled in foreign currency.
            // :param amounts_list:    A list of dict, one for each aml.
            // :param company:         The company in case there is no aml in self.
            // :param exchange_date:   Optional date object providing the date to consider for the exchange difference.
            // :return:                A python dictionary containing:
            //     * move_vals:    A dictionary to be passed to the account.move.create method.
            //     * to_reconcile: A list of tuple <move_line, sequence> in order to perform the reconciliation after the move
            //                     creation.
            // """
            // company = (
            //     (self.move_id.filtered(lambda m: m.is_invoice(True)) or self.move_id).company_id
            //     or company
            // )[:1]
            // if not company:
            //     return
            // 
            // journal = self._get_exchange_journal(company)
            // accounting_exchange_date = journal.with_context(move_date=exchange_date).accounting_date if journal else date.min
            // 
            // move_vals = {
            //     'move_type': 'entry',
            //     'name': '/', # do not trigger the compute name before posting as it will most likely be posted immediately after
            //     'date': accounting_exchange_date,
            //     'journal_id': journal.id,
            //     'line_ids': [],
            //     'always_tax_exigible': True,
            // }
            // to_reconcile = []
            // 
            // for line, amounts in zip(self, amounts_list):
            //     move_vals['date'] = max(move_vals['date'], line.date)
            // 
            //     if 'amount_residual' in amounts:
            //         amount_residual = amounts['amount_residual']
            //         amount_residual_currency = 0.0
            //         if line.currency_id == line.company_id.currency_id:
            //             amount_residual_currency = amount_residual
            //         amount_residual_to_fix = amount_residual
            //         if line.company_currency_id.is_zero(amount_residual):
            //             continue
            //     elif 'amount_residual_currency' in amounts:
            //         amount_residual = 0.0
            //         amount_residual_currency = amounts['amount_residual_currency']
            //         amount_residual_to_fix = amount_residual_currency
            //         if line.currency_id.is_zero(amount_residual_currency):
            //             continue
            //     else:
            //         continue
            // 
            //     exchange_line_account = self._get_exchange_account(company, amount_residual_to_fix)
            // 
            //     sequence = len(move_vals['line_ids'])
            //     line_vals = [
            //         {
            //             'name': _('Currency exchange rate difference'),
            //             'debit': -amount_residual if amount_residual < 0.0 else 0.0,
            //             'credit': amount_residual if amount_residual > 0.0 else 0.0,
            //             'amount_currency': -amount_residual_currency,
            //             'full_reconcile_id': line.full_reconcile_id.id,
            //             'account_id': line.account_id.id,
            //             'currency_id': line.currency_id.id,
            //             'partner_id': line.partner_id.id,
            //             'sequence': sequence,
            //         },
            //         {
            //             'name': _('Currency exchange rate difference'),
            //             'debit': amount_residual if amount_residual > 0.0 else 0.0,
            //             'credit': -amount_residual if amount_residual < 0.0 else 0.0,
            //             'amount_currency': amount_residual_currency,
            //             'account_id': exchange_line_account.id,
            //             'currency_id': line.currency_id.id,
            //             'partner_id': line.partner_id.id,
            //             'sequence': sequence + 1,
            //         },
            //     ]
            // 
            //     if kwargs.get('exchange_analytic_distribution'):
            //         line_vals[1].update({'analytic_distribution': kwargs['exchange_analytic_distribution']})
            // 
            //     move_vals['line_ids'] += [Command.create(vals) for vals in line_vals]
            //     to_reconcile.append((line, sequence))
            // 
            // return {'move_values': move_vals, 'to_reconcile': to_reconcile}
            */
            return default;
        }

        protected async Task<AccountMoveLine> PrepareFleetLogServiceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_fleet, FILE: account_move.py) ---
            // def _prepare_fleet_log_service(self):
            // vendor_bill_service = self.env.ref('account_fleet.data_fleet_service_type_vendor_bill', raise_if_not_found=False)
            // return {
            //     'service_type_id': vendor_bill_service.id,
            //     'vehicle_id': self.vehicle_id.id,
            //     'vendor_id': self.partner_id.id,
            //     'description': self.name,
            //     'account_move_line_id': self.id,
            // }
            */
            return default;
        }

        protected async Task<AccountMoveLine> PrepareLineValuesForPurchaseInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def _prepare_line_values_for_purchase(self):
            // return [
            //     {
            //         'product_id': line.product_id.id,
            //         'product_qty': line.quantity,
            //         'product_uom': line.product_uom_id.id,
            //         'price_unit': line.price_unit,
            //         'discount': line.discount,
            //     }
            //     for line in self
            // ]
            */
            return default;
        }

        protected async Task<AccountMoveLine> PrepareMoveLineResidualAmountsInternalAsync(object aml_values, object counterpart_currency, object shadowed_aml_values, object other_aml_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _prepare_move_line_residual_amounts(self, aml_values, counterpart_currency, shadowed_aml_values=None, other_aml_values=None):
            // """ Prepare the available residual amounts for each currency.
            // :param aml_values: The values of account.move.line to consider.
            // :param counterpart_currency: The currency of the opposite line this line will be reconciled with.
            // :param shadowed_aml_values: A mapping aml -> dictionary to replace some original aml values to something else.
            //                             This is usefull if you want to preview the reconciliation before doing some changes
            //                             on amls like changing a date or an account.
            // :param other_aml_values:    The other aml values to be reconciled with the current one.
            // :return: A mapping currency -> dictionary containing:
            //     * residual: The residual amount left for this currency.
            //     * rate:     The rate applied regarding the company's currency.
            // """
            // 
            // def is_payment(aml):
            //     return aml.move_id.origin_payment_id or aml.move_id.statement_line_id
            // 
            // def get_odoo_rate(aml, other_aml, currency):
            //     if forced_rate := self._context.get('forced_rate_from_register_payment'):
            //         return forced_rate
            //     if other_aml and not is_payment(aml) and is_payment(other_aml):
            //         return get_accounting_rate(other_aml, currency)
            //     if aml.move_id.is_invoice(include_receipts=True):
            //         exchange_rate_date = aml.move_id.invoice_date
            //     else:
            //         exchange_rate_date = aml._get_reconciliation_aml_field_value('date', shadowed_aml_values)
            //     return currency._get_conversion_rate(aml.company_currency_id, currency, aml.company_id, exchange_rate_date)
            // 
            // def get_accounting_rate(aml, currency):
            //     balance = aml._get_reconciliation_aml_field_value('balance', shadowed_aml_values)
            //     amount_currency = aml._get_reconciliation_aml_field_value('amount_currency', shadowed_aml_values)
            //     if not aml.company_currency_id.is_zero(balance) and not currency.is_zero(amount_currency):
            //         return abs(amount_currency / balance)
            // 
            // aml = aml_values['aml']
            // other_aml = (other_aml_values or {}).get('aml')
            // remaining_amount_curr = aml_values['amount_residual_currency']
            // remaining_amount = aml_values['amount_residual']
            // company_currency = aml.company_currency_id
            // currency = aml._get_reconciliation_aml_field_value('currency_id', shadowed_aml_values)
            // account = aml._get_reconciliation_aml_field_value('account_id', shadowed_aml_values)
            // has_zero_residual = company_currency.is_zero(remaining_amount)
            // has_zero_residual_currency = currency.is_zero(remaining_amount_curr)
            // is_rec_pay_account = account.account_type in ('asset_receivable', 'liability_payable')
            // 
            // available_residual_per_currency = {}
            // 
            // if not has_zero_residual:
            //     available_residual_per_currency[company_currency] = {
            //         'residual': remaining_amount,
            //         'rate': 1,
            //     }
            // if currency != company_currency and not has_zero_residual_currency:
            //     available_residual_per_currency[currency] = {
            //         'residual': remaining_amount_curr,
            //         'rate': get_accounting_rate(aml, currency),
            //     }
            // 
            // if currency == company_currency \
            //     and is_rec_pay_account \
            //     and not has_zero_residual \
            //     and counterpart_currency != company_currency:
            //     rate = get_odoo_rate(aml, other_aml, counterpart_currency)
            //     residual_in_foreign_curr = counterpart_currency.round(remaining_amount * rate)
            //     if not counterpart_currency.is_zero(residual_in_foreign_curr):
            //         available_residual_per_currency[counterpart_currency] = {
            //             'residual': residual_in_foreign_curr,
            //             'rate': rate,
            //         }
            // elif currency == counterpart_currency \
            //     and currency != company_currency \
            //     and not has_zero_residual_currency:
            //     available_residual_per_currency[counterpart_currency] = {
            //         'residual': remaining_amount_curr,
            //         'rate': get_accounting_rate(aml, currency),
            //     }
            // return available_residual_per_currency
            */
            return default;
        }

        protected async Task<AccountMoveLine> PreparePdiffAmlValsInternalAsync(object qty, object unit_valuation_difference)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: account_move_line.py) ---
            // def _prepare_pdiff_aml_vals(self, qty, unit_valuation_difference):
            // self.ensure_one()
            // vals_list = []
            // 
            // sign = self.move_id.direction_sign
            // expense_account = self.product_id.product_tmpl_id.get_product_accounts(fiscal_pos=self.move_id.fiscal_position_id)['expense']
            // if not expense_account:
            //     return vals_list
            // 
            // for price, account in [
            //     (unit_valuation_difference, expense_account),
            //     (-unit_valuation_difference, self.account_id),
            // ]:
            //     vals_list.append({
            //         'name': self.name[:64],
            //         'move_id': self.move_id.id,
            //         'partner_id': self.partner_id.id or self.move_id.commercial_partner_id.id,
            //         'currency_id': self.currency_id.id,
            //         'product_id': self.product_id.id,
            //         'product_uom_id': self.product_uom_id.id,
            //         'balance': self.company_id.currency_id.round((qty * price * sign) / self.currency_rate),
            //         'account_id': account.id,
            //         'analytic_distribution': self.analytic_distribution,
            //         'display_type': 'cogs',
            //     })
            // return vals_list
            */
            return default;
        }

        protected async Task<AccountMoveLine> PreparePdiffSvlValsInternalAsync(object corrected_layer, object quantity, object unit_cost, object pdiff)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: account_move_line.py) ---
            // def _prepare_pdiff_svl_vals(self, corrected_layer, quantity, unit_cost, pdiff):
            // self.ensure_one()
            // common_svl_vals = {
            //     'account_move_id': self.move_id.id,
            //     'account_move_line_id': self.id,
            //     'company_id': self.company_id.id,
            //     'product_id': self.product_id.id,
            //     'quantity': 0,
            //     'unit_cost': 0,
            //     'remaining_qty': 0,
            //     'remaining_value': 0,
            //     'description': self.move_id.name and '%s - %s' % (self.move_id.name, self.product_id.name) or self.product_id.name,
            // }
            // return {
            //     **self.product_id._prepare_in_svl_vals(quantity, unit_cost, corrected_layer.lot_id),
            //     **common_svl_vals,
            //     'stock_valuation_layer_id': corrected_layer.id,
            //     'price_diff_value': self.currency_id.round(pdiff * quantity),
            // }
            */
            return default;
        }

        protected async Task<AccountMoveLine> PreparePdiffValsInternalAsync(object layer, object aml, object layer_price_unit, object out_qty_to_invoice, object qty_to_correct)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: account_move_line.py) ---
            // def _prepare_pdiff_vals(self, layer, aml, layer_price_unit, out_qty_to_invoice, qty_to_correct):
            // svl_vals_list = []
            // aml_vals_list = []
            // 
            // aml_gross_price_unit = aml._get_gross_unit_price()
            // # convert from aml currency to company currency
            // aml_price_unit = aml_gross_price_unit / aml.currency_rate
            // aml_price_unit = aml.product_uom_id._compute_price(aml_price_unit, self.product_id.uom_id)
            // 
            // unit_valuation_difference = aml_price_unit - layer_price_unit
            // 
            // # Generate the AML values for the already out quantities
            // # convert from company currency to aml currency
            // unit_valuation_difference_curr = unit_valuation_difference * self.currency_rate
            // unit_valuation_difference_curr = self.product_id.uom_id._compute_price(unit_valuation_difference_curr, self.product_uom_id)
            // out_qty_to_invoice = self.product_id.uom_id._compute_quantity(out_qty_to_invoice, self.product_uom_id)
            // if (
            //     not self.currency_id.is_zero(unit_valuation_difference_curr * out_qty_to_invoice) and
            //     self.product_id.valuation == 'real_time'
            // ):
            //     aml_vals_list += self._prepare_pdiff_aml_vals(out_qty_to_invoice, unit_valuation_difference_curr)
            // 
            // # Generate the SVL values for the on hand quantities (and impact the parent layer)
            // po_pu_curr = self.purchase_line_id.currency_id._convert(
            //     self.purchase_line_id.price_unit,
            //     self.currency_id,
            //     self.company_id,
            //     self.move_id.invoice_date or self.date or fields.Date.context_today(self),
            //     round=False
            // )
            // price_difference_curr = po_pu_curr - aml_gross_price_unit
            // if not float_is_zero(unit_valuation_difference * qty_to_correct, precision_rounding=self.company_id.currency_id.rounding):
            //     svl_vals = self._prepare_pdiff_svl_vals(layer, qty_to_correct, unit_valuation_difference, price_difference_curr)
            //     layer.remaining_value += svl_vals['value']
            //     svl_vals_list.append(svl_vals)
            // 
            // return svl_vals_list, aml_vals_list
            */
            return default;
        }

        protected async Task<AccountMoveLine> PrepareReconciliationAmlsInternalAsync(object values_list, object shadowed_aml_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _prepare_reconciliation_amls(self, values_list, shadowed_aml_values=None):
            // """ Prepare the partials on the current journal items to perform the reconciliation.
            // Note: The order of records in self is important because the journal items will be reconciled using this order.
            // 
            // :param values_list: A list of dictionaries, one for each aml.
            // :param shadowed_aml_values: A mapping aml -> dictionary to replace some original aml values to something else.
            //                             This is usefull if you want to preview the reconciliation before doing some changes
            //                             on amls like changing a date or an account.
            // :return: a tuple of
            //     1) list of vals for partial reconciliation creation,
            //     2) the list of vals for the exchange difference entries to be created
            // """
            // debit_values_list = iter([
            //     x
            //     for x in values_list
            //     if x['aml']._get_reconciliation_aml_field_value('balance', shadowed_aml_values) > 0.0
            //        or x['aml']._get_reconciliation_aml_field_value('amount_currency', shadowed_aml_values) > 0.0
            // ])
            // credit_values_list = iter([
            //     x
            //     for x in values_list
            //     if x['aml']._get_reconciliation_aml_field_value('balance', shadowed_aml_values) < 0.0
            //        or x['aml']._get_reconciliation_aml_field_value('amount_currency', shadowed_aml_values) < 0.0
            // ])
            // debit_values = None
            // credit_values = None
            // fully_reconciled_aml_ids = set()
            // 
            // all_results = []
            // while True:
            // 
            //     # ==== Find the next available lines ====
            //     # For performance reasons, the partials are created all at once meaning the residual amounts can't be
            //     # trusted from one iteration to another. That's the reason why all residual amounts are kept as variables
            //     # and reduced "manually" every time we append a dictionary to 'partials_values_list'.
            // 
            //     # Move to the next available debit line.
            //     if not debit_values:
            //         debit_values = next(debit_values_list, None)
            //         if not debit_values:
            //             break
            // 
            //     # Move to the next available credit line.
            //     if not credit_values:
            //         credit_values = next(credit_values_list, None)
            //         if not credit_values:
            //             break
            // 
            //     # ==== Compute the amounts to reconcile ====
            // 
            //     results = self._prepare_reconciliation_single_partial(
            //         debit_values,
            //         credit_values,
            //         shadowed_aml_values=shadowed_aml_values,
            //     )
            //     if results.get('partial_values'):
            //         all_results.append(results)
            //     if results['debit_values'] is None:
            //         fully_reconciled_aml_ids.add(debit_values['aml'].id)
            //         debit_values = None
            //     if results['credit_values'] is None:
            //         fully_reconciled_aml_ids.add(credit_values['aml'].id)
            //         credit_values = None
            // 
            // return all_results, fully_reconciled_aml_ids
            */
            return default;
        }

        protected async Task<AccountMoveLine> PrepareReconciliationPlanInternalAsync(object plan, object amls_values_map, object shadowed_aml_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _prepare_reconciliation_plan(self, plan, amls_values_map, shadowed_aml_values=None):
            // """ Perform virtually the reconciliation of the plan passed as parameter.
            // 
            // :param plan: The plan to know which lines to reconcile in which order.
            // :param amls_values_map: A mapping aml => amount_residual/amount_residual_currency
            // :param shadowed_aml_values: A mapping aml -> dictionary to replace some original aml values to something else.
            //                             This is usefull if you want to preview the reconciliation before doing some changes
            //                             on amls like changing a date or an account.
            // :return: A list of all results returned by the '_prepare_reconciliation_amls' method.
            // """
            // all_fully_reconciled_aml_ids = set()
            // all_results = []
            // 
            // def process_amls(amls):
            //     remaining_amls = amls.filtered(lambda aml: aml.id not in all_fully_reconciled_aml_ids)
            //     amls_results, fully_reconciled_aml_ids = self._prepare_reconciliation_amls(
            //         [
            //             amls_values_map[aml]
            //             for aml in remaining_amls
            //         ],
            //         shadowed_aml_values=shadowed_aml_values,
            //     )
            //     all_fully_reconciled_aml_ids.update(fully_reconciled_aml_ids)
            //     for amls_result in amls_results:
            //         all_results.append(amls_result)
            // 
            // def process_leaf(plan_node):
            //     # Sub plan to evaluate.
            //     for child_node in plan_node.get('nodes', []):
            //         process_leaf(child_node)
            // 
            //     # Group of amls to evaluate.
            //     process_amls(plan_node['amls'])
            // 
            // process_leaf(plan)
            // return all_results
            */
            return default;
        }

        protected async Task<AccountMoveLine> PrepareReconciliationSinglePartialInternalAsync(object debit_values, object credit_values, object shadowed_aml_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _prepare_reconciliation_single_partial(self, debit_values, credit_values, shadowed_aml_values=None):
            // """ Prepare the values to create an account.partial.reconcile later when reconciling the dictionaries passed
            // as parameters, each one representing an account.move.line.
            // :param debit_values:  The values of account.move.line to consider for a debit line.
            // :param credit_values: The values of account.move.line to consider for a credit line.
            // :param shadowed_aml_values: A mapping aml -> dictionary to replace some original aml values to something else.
            //                             This is usefull if you want to preview the reconciliation before doing some changes
            //                             on amls like changing a date or an account.
            // :return: A dictionary:
            //     * debit_values:     None if the line has nothing left to reconcile.
            //     * credit_values:    None if the line has nothing left to reconcile.
            //     * partial_values:   The newly computed values for the partial.
            //     * exchange_values:  The values to create an exchange difference linked to this partial.
            // """
            // # ==== Determine the currency in which the reconciliation will be done ====
            // # In this part, we retrieve the residual amounts, check if they are zero or not and determine in which
            // # currency and at which rate the reconciliation will be done.
            // res = {
            //     'debit_values': debit_values,
            //     'credit_values': credit_values,
            // }
            // debit_aml = debit_values['aml']
            // credit_aml = credit_values['aml']
            // debit_currency = debit_aml._get_reconciliation_aml_field_value('currency_id', shadowed_aml_values)
            // credit_currency = credit_aml._get_reconciliation_aml_field_value('currency_id', shadowed_aml_values)
            // company_currency = debit_aml.company_currency_id
            // 
            // remaining_debit_amount_curr = debit_values['amount_residual_currency']
            // remaining_credit_amount_curr = credit_values['amount_residual_currency']
            // remaining_debit_amount = debit_values['amount_residual']
            // remaining_credit_amount = credit_values['amount_residual']
            // 
            // debit_available_residual_amounts = self._prepare_move_line_residual_amounts(
            //     debit_values,
            //     credit_currency,
            //     shadowed_aml_values=shadowed_aml_values,
            //     other_aml_values=credit_values,
            // )
            // credit_available_residual_amounts = self._prepare_move_line_residual_amounts(
            //     credit_values,
            //     debit_currency,
            //     shadowed_aml_values=shadowed_aml_values,
            //     other_aml_values=debit_values,
            // )
            // 
            // if debit_currency != company_currency \
            //     and debit_currency in debit_available_residual_amounts \
            //     and debit_currency in credit_available_residual_amounts:
            //     recon_currency = debit_currency
            // elif credit_currency != company_currency \
            //     and credit_currency in debit_available_residual_amounts \
            //     and credit_currency in credit_available_residual_amounts:
            //     recon_currency = credit_currency
            // else:
            //     recon_currency = company_currency
            // 
            // debit_recon_values = debit_available_residual_amounts.get(recon_currency)
            // credit_recon_values = credit_available_residual_amounts.get(recon_currency)
            // 
            // # Check if there is something left to reconcile. Move to the next loop iteration if not.
            // skip_reconciliation = False
            // if not debit_recon_values:
            //     res['debit_values'] = None
            //     skip_reconciliation = True
            // if not credit_recon_values:
            //     res['credit_values'] = None
            //     skip_reconciliation = True
            // if skip_reconciliation:
            //     return res
            // 
            // recon_debit_amount = debit_recon_values['residual']
            // recon_credit_amount = -credit_recon_values['residual']
            // 
            // # ==== Match both lines together and compute amounts to reconcile ====
            // 
            // # Special case for exchange difference lines. In that case, both lines are sharing the same foreign
            // # currency but at least one has no amount in foreign currency.
            // # In that case, we don't want a rate for the opposite line because the exchange difference is supposed
            // # to reduce only the amount in company currency but not the foreign one.
            // exchange_line_mode = \
            //     recon_currency == company_currency \
            //     and debit_currency == credit_currency \
            //     and (
            //         not debit_available_residual_amounts.get(debit_currency)
            //         or not credit_available_residual_amounts.get(credit_currency)
            //     )
            // 
            // # Determine which line is fully matched by the other.
            // compare_amounts = recon_currency.compare_amounts(recon_debit_amount, recon_credit_amount)
            // min_recon_amount = min(recon_debit_amount, recon_credit_amount)
            // debit_fully_matched = compare_amounts <= 0
            // credit_fully_matched = compare_amounts >= 0
            // 
            // def get_amount_range_after_rate(currency_from, currency_to, amount, rate):
            //     # Suppose balance=1000, rate=12.
            //     # 1000.0 could be the result of a rounding of [999.995, 1000.0049999999999].
            //     # Let's say the target currency could be [999.995 * 12, 1000.005 * 12] = [11999.94, 12000.06]
            //     # instead of just 120000.
            //     if not rate:
            //         return 0.0, 0.0, 0.0
            //     half_rounding = currency_from.rounding / 2
            //     return (
            //         currency_to.round((amount - half_rounding) * rate),
            //         currency_to.round(amount * rate),
            //         currency_to.round((amount + half_rounding) * rate),
            //     )
            // 
            // # ==== Computation of partial amounts ====
            // if recon_currency == company_currency:
            //     if exchange_line_mode:
            //         debit_rate = None
            //         credit_rate = None
            //     else:
            //         debit_rate = debit_available_residual_amounts.get(debit_currency, {}).get('rate')
            //         credit_rate = credit_available_residual_amounts.get(credit_currency, {}).get('rate')
            // 
            //     # Compute the partial amount expressed in company currency.
            //     partial_amount = min_recon_amount
            // 
            //     # Compute the partial amount expressed in foreign currency.
            //     if debit_rate:
            //         partial_debit_amount_currency = debit_currency.round(debit_rate * min_recon_amount)
            //         partial_debit_amount_currency = min(partial_debit_amount_currency, remaining_debit_amount_curr)
            //     else:
            //         partial_debit_amount_currency = 0.0
            //     if credit_rate:
            //         partial_credit_amount_currency = credit_currency.round(credit_rate * min_recon_amount)
            //         partial_credit_amount_currency = min(partial_credit_amount_currency, -remaining_credit_amount_curr)
            //     else:
            //         partial_credit_amount_currency = 0.0
            // 
            // else:
            //     # recon_currency != company_currency
            //     if exchange_line_mode:
            //         debit_rate = None
            //         credit_rate = None
            //     else:
            //         debit_rate = debit_recon_values['rate']
            //         credit_rate = credit_recon_values['rate']
            // 
            //     # Compute the partial amount expressed in foreign currency.
            //     partial_debit_amount_range = get_amount_range_after_rate(
            //         currency_from=debit_currency,
            //         currency_to=company_currency,
            //         amount=min_recon_amount,
            //         rate=(1 / debit_rate) if debit_rate else 0.0,
            //     )
            //     partial_debit_amount = partial_debit_amount_range[1]
            //     partial_debit_amount = min(partial_debit_amount, remaining_debit_amount)
            //     partial_credit_amount_range = get_amount_range_after_rate(
            //         currency_from=credit_currency,
            //         currency_to=company_currency,
            //         amount=min_recon_amount,
            //         rate=(1 / credit_rate) if credit_rate else 0.0,
            //     )
            //     partial_credit_amount = partial_credit_amount_range[1]
            //     partial_credit_amount = min(partial_credit_amount, -remaining_credit_amount)
            //     partial_amount = min(partial_debit_amount, partial_credit_amount)
            // 
            //     # Prevent exchange differences if amounts are close enough to be a rounding issue
            //     # after applying the exchange rate and then, rounding amounts to store them into
            //     # the monetary fields.
            //     # Suppose 2 lines:
            //     # l1: balance=377554.0, amount_currency=20000.0
            //     # l2: balance=-5314.62, amount_currency=-281.53
            //     # ... computing min_recon_amount = min(20000.0, 281.53) = 281.53 in foreign currency to reconcile.
            //     # The equivalent of 281.53 for l1 in company currency is 5314.64 that could be the result of rounding any value
            //     # between [5314.54, 5314.7300000000005]
            //     # ... considering the rate of 0.05297255491929631 and the rounding applied to reach this value.
            //     # For l2, it will be 5314.62 in the range [5314.53, 5314.71].
            //     #
            //     # ---------
            //     # | 5314.73         ---------       <- max amount
            //     # |                 5314.71  |
            //     # |                          |
            //     # | 5314.64                  |
            //     # |                 5314.62  |      Every number between the min and the max are considered as valid to be the partial amount.
            //     # |                          |      Depending on the one we choose, we can avoid to create an exchange difference entry or
            //     # |                          |      we could also prevent to let an unnecessary open residual amount.
            //     # | 5314.54                  |
            //     # ---------         5314.53  |      <- min amount
            //     #                   ---------
            //     if (
            //         company_currency.compare_amounts(partial_debit_amount, partial_credit_amount_range[2]) <= 0
            //         and company_currency.compare_amounts(partial_debit_amount, partial_credit_amount_range[0]) >= 0
            //         and company_currency.compare_amounts(partial_credit_amount, partial_debit_amount_range[2]) <= 0
            //         and company_currency.compare_amounts(partial_credit_amount, partial_debit_amount_range[0]) >= 0
            //     ):
            //         if debit_fully_matched:
            //             partial_amount = remaining_debit_amount
            //         else:
            //             partial_amount = -remaining_credit_amount
            //         partial_debit_amount = partial_amount
            //         partial_credit_amount = partial_amount
            // 
            //     # Compute the partial amount expressed in foreign currency.
            //     # Take care to handle the case when a line expressed in company currency is mimicking the foreign
            //     # currency of the opposite line.
            //     if debit_currency == company_currency:
            //         partial_debit_amount_currency = partial_amount
            //     else:
            //         partial_debit_amount_currency = min_recon_amount
            //     if credit_currency == company_currency:
            //         partial_credit_amount_currency = partial_amount
            //     else:
            //         partial_credit_amount_currency = min_recon_amount
            // 
            // # Computation of the partial exchange difference. You can skip this part using the
            // # `no_exchange_difference` context key (when reconciling an exchange difference for example).
            // if not self._context.get('no_exchange_difference') and not self._context.get('no_exchange_difference_no_recursive'):
            //     exchange_lines_to_fix = self.env['account.move.line']
            //     amounts_list = []
            //     if recon_currency == company_currency:
            //         if debit_fully_matched:
            //             debit_exchange_amount = remaining_debit_amount_curr - partial_debit_amount_currency
            //             if not debit_currency.is_zero(debit_exchange_amount):
            //                 exchange_lines_to_fix += debit_aml
            //                 amounts_list.append({'amount_residual_currency': debit_exchange_amount})
            //                 remaining_debit_amount_curr -= debit_exchange_amount
            //         if credit_fully_matched:
            //             credit_exchange_amount = remaining_credit_amount_curr + partial_credit_amount_currency
            //             if not credit_currency.is_zero(credit_exchange_amount):
            //                 exchange_lines_to_fix += credit_aml
            //                 amounts_list.append({'amount_residual_currency': credit_exchange_amount})
            //                 remaining_credit_amount_curr += credit_exchange_amount
            // 
            //     else:
            //         if debit_fully_matched:
            //             # Create an exchange difference on the remaining amount expressed in company's currency.
            //             debit_exchange_amount = remaining_debit_amount - partial_amount
            //             if not company_currency.is_zero(debit_exchange_amount):
            //                 exchange_lines_to_fix += debit_aml
            //                 amounts_list.append({'amount_residual': debit_exchange_amount})
            //                 remaining_debit_amount -= debit_exchange_amount
            //                 if debit_currency == company_currency:
            //                     remaining_debit_amount_curr -= debit_exchange_amount
            //         else:
            //             # Create an exchange difference ensuring the rate between the residual amounts expressed in
            //             # both foreign and company's currency is still consistent regarding the rate between
            //             # 'amount_currency' & 'balance'.
            //             debit_exchange_amount = partial_debit_amount - partial_amount
            //             if company_currency.compare_amounts(debit_exchange_amount, 0.0) > 0:
            //                 exchange_lines_to_fix += debit_aml
            //                 amounts_list.append({'amount_residual': debit_exchange_amount})
            //                 remaining_debit_amount -= debit_exchange_amount
            //                 if debit_currency == company_currency:
            //                     remaining_debit_amount_curr -= debit_exchange_amount
            // 
            //         if credit_fully_matched:
            //             # Create an exchange difference on the remaining amount expressed in company's currency.
            //             credit_exchange_amount = remaining_credit_amount + partial_amount
            //             if not company_currency.is_zero(credit_exchange_amount):
            //                 exchange_lines_to_fix += credit_aml
            //                 amounts_list.append({'amount_residual': credit_exchange_amount})
            //                 remaining_credit_amount -= credit_exchange_amount
            //                 if credit_currency == company_currency:
            //                     remaining_credit_amount_curr -= credit_exchange_amount
            //         else:
            //             # Create an exchange difference ensuring the rate between the residual amounts expressed in
            //             # both foreign and company's currency is still consistent regarding the rate between
            //             # 'amount_currency' & 'balance'.
            //             credit_exchange_amount = partial_amount - partial_credit_amount
            //             if company_currency.compare_amounts(credit_exchange_amount, 0.0) < 0:
            //                 exchange_lines_to_fix += credit_aml
            //                 amounts_list.append({'amount_residual': credit_exchange_amount})
            //                 remaining_credit_amount -= credit_exchange_amount
            //                 if credit_currency == company_currency:
            //                     remaining_credit_amount_curr -= credit_exchange_amount
            // 
            //     if exchange_lines_to_fix:
            //         res['exchange_values'] = exchange_lines_to_fix._prepare_exchange_difference_move_vals(
            //             amounts_list,
            //             exchange_date=max(
            //                 debit_aml._get_reconciliation_aml_field_value('date', shadowed_aml_values),
            //                 credit_aml._get_reconciliation_aml_field_value('date', shadowed_aml_values),
            //             ),
            //         )
            // 
            // # ==== Create partials ====
            // 
            // remaining_debit_amount -= partial_amount
            // remaining_credit_amount += partial_amount
            // remaining_debit_amount_curr -= partial_debit_amount_currency
            // remaining_credit_amount_curr += partial_credit_amount_currency
            // 
            // res['partial_values'] = {
            //     'amount': partial_amount,
            //     'debit_amount_currency': partial_debit_amount_currency,
            //     'credit_amount_currency': partial_credit_amount_currency,
            //     'debit_move_id': debit_aml.id,
            //     'credit_move_id': credit_aml.id,
            // }
            // 
            // debit_values['amount_residual'] = remaining_debit_amount
            // debit_values['amount_residual_currency'] = remaining_debit_amount_curr
            // credit_values['amount_residual'] = remaining_credit_amount
            // credit_values['amount_residual_currency'] = remaining_credit_amount_curr
            // 
            // if (
            //     debit_currency.is_zero(debit_values['amount_residual_currency'])
            //     and company_currency.is_zero(debit_values['amount_residual'])
            // ):
            //     res['debit_values'] = None
            // if (
            //     credit_currency.is_zero(credit_values['amount_residual_currency'])
            //     and company_currency.is_zero(credit_values['amount_residual'])
            // ):
            //     res['credit_values'] = None
            // return res
            */
            return default;
        }

        protected async Task<AccountMoveLine> PreventAutomaticLineDeletionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _prevent_automatic_line_deletion(self):
            // if not self.env.context.get('dynamic_unlink'):
            //     for line in self:
            //         if line.display_type == 'tax' and line.move_id.line_ids.tax_ids:
            //             raise ValidationError(_(
            //                 "You cannot delete a tax line as it would impact the tax report"
            //             ))
            //         elif line.display_type == 'payment_term':
            //             raise ValidationError(_(
            //                 "You cannot delete a payable/receivable line as it would not be consistent "
            //                 "with the payment terms"
            //             ))
            */
            return default;
        }

        protected async Task<AccountMoveLine> QueryGetInternalAsync(object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: accounting_pdf_reports, FILE: account_move_line.py) ---
            // def _query_get(self, domain=None):
            // self.check_access('read')
            // 
            // context = dict(self._context or {})
            // domain = domain or []
            // if not isinstance(domain, (list, tuple)):
            //     domain = ast.literal_eval(domain)
            // 
            // date_field = 'date'
            // if context.get('aged_balance'):
            //     date_field = 'date_maturity'
            // if context.get('date_to'):
            //     domain += [(date_field, '<=', context['date_to'])]
            // if context.get('date_from'):
            //     if not context.get('strict_range'):
            //         domain += ['|', (date_field, '>=', context['date_from']), ('account_id.include_initial_balance', '=', True)]
            //     elif context.get('initial_bal'):
            //         domain += [(date_field, '<', context['date_from'])]
            //     else:
            //         domain += [(date_field, '>=', context['date_from'])]
            // 
            // if context.get('journal_ids'):
            //     domain += [('journal_id', 'in', context['journal_ids'])]
            // 
            // state = context.get('state')
            // if state and state.lower() != 'all':
            //     domain += [('parent_state', '=', state)]
            // 
            // if context.get('company_id'):
            //     domain += [('company_id', '=', context['company_id'])]
            // elif context.get('allowed_company_ids'):
            //     domain += [('company_id', 'in', self.env.companies.ids)]
            // else:
            //     domain += [('company_id', '=', self.env.company.id)]
            // 
            // if context.get('reconcile_date'):
            //     domain += ['|', ('reconciled', '=', False), '|', ('matched_debit_ids.max_date', '>', context['reconcile_date']), ('matched_credit_ids.max_date', '>', context['reconcile_date'])]
            // 
            // if context.get('account_tag_ids'):
            //     domain += [('account_id.tag_ids', 'in', context['account_tag_ids'].ids)]
            // 
            // if context.get('account_ids'):
            //     domain += [('account_id', 'in', context['account_ids'].ids)]
            // 
            // if context.get('analytic_tag_ids'):
            //     domain += [('analytic_tag_ids', 'in', context['analytic_tag_ids'].ids)]
            // 
            // if context.get('analytic_account_ids'):
            //     domain += [('analytic_distribution', 'in', context['analytic_account_ids'].ids)]
            // 
            // if context.get('partner_ids'):
            //     domain += [('partner_id', 'in', context['partner_ids'].ids)]
            // 
            // if context.get('partner_categories'):
            //     domain += [('partner_id.category_id', 'in', context['partner_categories'].ids)]
            // 
            // where_clause = ""
            // where_clause_params = []
            // tables = ''
            // if domain:
            //     domain.append(('display_type', 'not in', ('line_section', 'line_note')))
            //     domain.append(('parent_state', '!=', 'cancel'))
            // 
            //     query = self._where_calc(domain)
            //     self._apply_ir_rules(query)
            //     from_string, from_params = query.from_clause
            //     where_string, where_params = query.where_clause
            //     tables, where_clause, where_clause_params = from_string, where_string, from_params + where_params
            // return tables, where_clause, where_clause_params
            */
            return default;
        }

        public async Task<AccountMoveLine> ReconcileAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def reconcile(self):
            // """ Reconcile the current move lines all together. """
            // return self._reconcile_plan([self])
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMoveLine> ReconcileMarkedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _reconcile_marked(self):
            // """Process the pending reconciliation of entries marked (i.e. uring imports).
            // 
            // The entries can be marked using the string `I*` as matching number where `*` can be anything.
            // Once all the entries using identical numbers are posted, this function proceeds to do the real matching.
            // """
            // temp_numbers = list({
            //     line.matching_number
            //     for line in self
            //     if line.matching_number and line.matching_number.startswith('I')
            // })
            // if temp_numbers:
            //     for _matching_number, account, lines in self._read_group(
            //         domain=[('matching_number', 'in', temp_numbers)],
            //         groupby=['matching_number', 'account_id'],
            //         aggregates=['id:recordset'],
            //     ):
            //         if all(move.state == 'posted' for move in lines.move_id):
            //             if not account.reconcile:
            //                 _logger.info("%s has reconciled lines, changing the config", account.display_name)
            //                 account.reconcile = True
            //             lines.with_context(no_exchange_difference=True, no_cash_basis=True).reconcile()
            */
            return default;
        }

        protected async Task<AccountMoveLine> ReconcilePlanInternalAsync(object reconciliation_plan)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _reconcile_plan(self, reconciliation_plan):
            // """ Reconcile the amls following the reconciliation plan.
            // The plan passed as parameter is a list of either a recordset of amls, either another plan.
            // 
            // For example:
            // [account.move.line(1, 2), account.move.line(3, 4)] means:
            // - account.move.line(1, 2) will be reconciled first.
            // - account.move.line(3, 4) will be reconciled after.
            // 
            // [[account.move.line(1, 2), account.move.line(3, 4)]] means:
            // - account.move.line(1, 2) will be reconciled first.
            // - account.move.line(3, 4) will be reconciled after.
            // - account.move.line(1, 2, 3, 4).filtered(lambda x: not x.reconciled) will be reconciled at the end.
            // 
            // :param reconciliation_plan: A list of reconciliation to perform.
            // """
            // # ==== Prepare the reconciliation ====
            // # Batch the amls all together to know what should be reconciled and when.
            // plan_list, all_amls = self._optimize_reconciliation_plan(reconciliation_plan)
            // move_container = {'records': all_amls.move_id}
            // with all_amls.move_id._check_balanced(move_container),\
            //      all_amls.move_id._sync_dynamic_lines(move_container):
            //     self._reconcile_plan_with_sync(plan_list, all_amls)
            */
            return default;
        }

        protected async Task<AccountMoveLine> ReconcilePlanWithSyncInternalAsync(object plan_list, object all_amls)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _reconcile_plan_with_sync(self, plan_list, all_amls):
            // # Parameter allowing to disable the exchange journal entries on partials.
            // disable_partial_exchange_diff = bool(self.env['ir.config_parameter'].sudo().get_param('account.disable_partial_exchange_diff'))
            // 
            // # ==== Prefetch the fields all at once to speedup the reconciliation ====
            // # All of those fields will be cached by the orm. Since the amls are split into multiple batches, the orm is not
            // # able to prefetch the data for all of them at once. For that reason, we force the orm to populate the cache
            // # before doing anything.
            // all_amls.move_id
            // all_amls.matched_debit_ids
            // all_amls.matched_credit_ids
            // 
            // # ==== Track the invoice's state to call the hook when they become paid ====
            // pre_hook_data = all_amls._reconcile_pre_hook()
            // 
            // # ==== Collect amls data ====
            // # All residual amounts are collected and updated until the creation of partials in batch.
            // # This is done that way to minimize the orm time for fields invalidation/mark as recompute and
            // # recomputation.
            // aml_values_map = {
            //     aml: {
            //         'aml': aml,
            //         'amount_residual': aml.amount_residual,
            //         'amount_residual_currency': aml.amount_residual_currency,
            //     }
            //     for aml in all_amls
            // }
            // 
            // # ==== Prepare the partials ====
            // partials_values_list = []
            // exchange_diff_values_list = []
            // exchange_diff_partial_index = []
            // all_plan_results = []
            // partial_index = 0
            // for plan in plan_list:
            //     plan_results = self\
            //         .with_context(
            //             no_exchange_difference=self._context.get('no_exchange_difference') or disable_partial_exchange_diff,
            //             no_exchange_difference_no_recursive=self._context.get('no_exchange_difference_no_recursive', False),
            //         )\
            //         ._prepare_reconciliation_plan(plan, aml_values_map)
            //     all_plan_results.append(plan_results)
            //     for results in plan_results:
            //         partials_values_list.append(results['partial_values'])
            //         if results.get('exchange_values') and results['exchange_values']['move_values']['line_ids']:
            //             exchange_diff_values_list.append(results['exchange_values'])
            //             exchange_diff_partial_index.append(partial_index)
            //             partial_index += 1
            // 
            // # ==== Create the partials ====
            // # Link the newly created partials to the plan. There are needed later for caba exchange entries.
            // partials = self.env['account.partial.reconcile'].create(partials_values_list)
            // start_range = 0
            // for plan_results, plan in zip(all_plan_results, plan_list):
            //     size = len(plan_results)
            //     plan['partials'] = partials[start_range:start_range + size]
            //     start_range += size
            // 
            // # ==== Create the partial exchange journal entries ====
            // exchange_moves = self._create_exchange_difference_moves(exchange_diff_values_list)
            // for index, exchange_move in zip(exchange_diff_partial_index, exchange_moves):
            //     partials[index].exchange_move_id = exchange_move
            // 
            // # ==== Create entries for cash basis taxes ====
            // def is_cash_basis_needed(amls):
            //     return any(amls.company_id.mapped('tax_exigibility')) \
            //         and amls.account_id.account_type in ('asset_receivable', 'liability_payable')
            // 
            // if not self._context.get('move_reverse_cancel') and not self._context.get('no_cash_basis'):
            //     for plan in plan_list:
            //         if is_cash_basis_needed(plan['amls']):
            //             plan['partials'].with_context(no_exchange_difference_no_recursive=False)._create_tax_cash_basis_moves()
            // 
            // # ==== Prepare full reconcile creation ====
            // # First, we need to find all sub-set of amls that are candidates for a full.
            // 
            // def is_line_reconciled(aml, has_multiple_currencies):
            //     # Check if the journal item passed as parameter is now fully reconciled.
            //     if aml.reconciled:
            //         return True
            //     if not aml.matched_debit_ids and not aml.matched_credit_ids:
            //         # Suppose a journal item having balance = 0 but an amount_currency like an exchange difference.
            //         return False
            //     if has_multiple_currencies:
            //         return aml.company_currency_id.is_zero(aml.amount_residual)
            //     else:
            //         return aml.currency_id.is_zero(aml.amount_residual_currency)
            // 
            // full_batches = []
            // all_aml_ids = set()
            // number2lines = all_amls._reconciled_by_number()
            // for plan in plan_list:
            //     for aml in plan['amls']:
            //         if 'full_batch_index' in aml_values_map[aml]:
            //             continue
            // 
            //         involved_amls = plan['amls']._filter_reconciled_by_number(number2lines)
            //         all_aml_ids.update(involved_amls.ids)
            //         full_batch_index = len(full_batches)
            //         has_multiple_currencies = len(involved_amls.currency_id) > 1
            //         is_fully_reconciled = all(
            //             is_line_reconciled(involved_aml, has_multiple_currencies)
            //             for involved_aml in involved_amls
            //         )
            //         full_batches.append({
            //             'amls': involved_amls,
            //             'is_fully_reconciled': is_fully_reconciled,
            //         })
            //         for involved_aml in involved_amls:
            //             if aml_values_map.get(involved_aml):
            //                 aml_values_map[involved_aml]['full_batch_index'] = full_batch_index
            // 
            // # ==== Prefetch the fields all at once to speedup the reconciliation ====
            // # Again, we do the same optimization for the prefetching. We need to do it again since most of the values have
            // # been invalidated with the creation of the account.partial.reconcile records.
            // all_amls = self.browse(list(all_aml_ids))
            // all_amls.move_id
            // all_amls.matched_debit_ids
            // all_amls.matched_credit_ids
            // 
            // # ==== Prepare the full exchange journal entries ====
            // # This part could be bypassed using the 'no_exchange_difference' key inside the context. This is useful
            // # when importing a full accounting including the reconciliation like Winbooks.
            // 
            // exchange_diff_values_list = []
            // exchange_diff_full_batch_index = []
            // if not self._context.get('no_exchange_difference'):
            //     for full_batch_index, full_batch in enumerate(full_batches):
            //         involved_amls = full_batch['amls']
            //         if not full_batch['is_fully_reconciled']:
            //             continue
            // 
            //         # In normal cases, the exchange differences are already generated by the partial at this point meaning
            //         # there is no journal item left with a zero amount residual in one currency but not in the other.
            //         # However, after a migration coming from an older version with an older partial reconciliation or due to
            //         # some rounding issues (when dealing with different decimal places for example), we could need an extra
            //         # exchange difference journal entry to handle them.
            //         exchange_lines_to_fix = self.env['account.move.line']
            //         amounts_list = []
            //         exchange_max_date = date.min
            //         for aml in involved_amls:
            //             if not aml.company_currency_id.is_zero(aml.amount_residual):
            //                 exchange_lines_to_fix += aml
            //                 amounts_list.append({'amount_residual': aml.amount_residual})
            //             elif not aml.currency_id.is_zero(aml.amount_residual_currency):
            //                 exchange_lines_to_fix += aml
            //                 amounts_list.append({'amount_residual_currency': aml.amount_residual_currency})
            //             exchange_max_date = max(exchange_max_date, aml.date)
            //         exchange_diff_values = exchange_lines_to_fix._prepare_exchange_difference_move_vals(
            //             amounts_list,
            //             company=involved_amls.company_id,
            //             exchange_date=exchange_max_date,
            //         )
            // 
            //         # Exchange difference for cash basis entries.
            //         # If we are fully reversing the entry, no need to fix anything since the journal entry
            //         # is exactly the mirror of the source journal entry.
            //         caba_lines_to_reconcile = None
            //         if is_cash_basis_needed(involved_amls) and not self._context.get('move_reverse_cancel') and not self._context.get('no_cash_basis'):
            //             caba_lines_to_reconcile = involved_amls._add_exchange_difference_cash_basis_vals(exchange_diff_values)
            // 
            //         # Prepare the exchange difference.
            //         if exchange_diff_values['move_values']['line_ids']:
            //             exchange_diff_full_batch_index.append(full_batch_index)
            //             exchange_diff_values_list.append(exchange_diff_values)
            //             full_batch['caba_lines_to_reconcile'] = caba_lines_to_reconcile
            // 
            // # ==== Create the full exchange journal entries ====
            // exchange_moves = self._create_exchange_difference_moves(exchange_diff_values_list)
            // for full_batch_index, exchange_move in zip(exchange_diff_full_batch_index, exchange_moves):
            //     full_batch = full_batches[full_batch_index]
            //     amls = full_batch['amls']
            //     full_batch['exchange_move'] = exchange_move
            //     exchange_move_lines = exchange_move.line_ids.filtered(lambda line: line.account_id == amls.account_id)
            //     full_batch['amls'] |= exchange_move_lines
            // 
            // # ==== Create the full reconcile ====
            // # Note we are using Command.link and not Command.set because Command.set is triggering an unlink that is
            // # slowing down the assignation of the co-fields. Indeed, unlink is forcing a flush.
            // full_reconcile_values_list = []
            // full_reconcile_full_batch_index = []
            // for full_batch_index, full_batch in enumerate(full_batches):
            //     amls = full_batch['amls']
            //     involved_partials = amls.matched_debit_ids + amls.matched_credit_ids
            //     if full_batch['is_fully_reconciled']:
            //         full_reconcile_values_list.append({
            //             'exchange_move_id': full_batch.get('exchange_move') and full_batch['exchange_move'].id,
            //             'partial_reconcile_ids': [Command.link(partial.id) for partial in involved_partials],
            //             'reconciled_line_ids': [Command.link(aml.id) for aml in amls],
            //         })
            //         full_reconcile_full_batch_index.append(full_batch_index)
            // 
            // self.env['account.full.reconcile'].create(full_reconcile_values_list)
            // 
            // # === Cash basis rounding autoreconciliation ===
            // # In case a cash basis rounding difference line got created for the transition account, we reconcile it with the corresponding lines
            // # on the cash basis moves (so that it reaches full reconciliation and creates an exchange difference entry for this account as well)
            // for full_batch in full_batches:
            //     if not full_batch.get('caba_lines_to_reconcile'):
            //         continue
            // 
            //     caba_lines_to_reconcile = full_batch['caba_lines_to_reconcile']
            //     exchange_move = full_batch['exchange_move']
            //     for (dummy, account, repartition_line), amls_to_reconcile in caba_lines_to_reconcile.items():
            //         if not account.reconcile:
            //             continue
            // 
            //         exchange_line = exchange_move.line_ids.filtered(
            //             lambda l: l.account_id == account and l.tax_repartition_line_id == repartition_line
            //         )
            // 
            //         (exchange_line + amls_to_reconcile)\
            //             .filtered(lambda l: not l.reconciled)\
            //             .reconcile()
            // 
            // all_amls._reconcile_post_hook(pre_hook_data)
            */
            return default;
        }

        protected async Task<AccountMoveLine> ReconcilePostHookInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _reconcile_post_hook(self, data):
            // (
            //     data['not_paid_invoices'].filtered(lambda inv: inv.payment_state in ('paid', 'in_payment'))
            //     + data['in_payment_invoices'].filtered(lambda inv: inv.payment_state == 'paid')
            // )._invoice_paid_hook()
            */
            return default;
        }

        protected async Task<AccountMoveLine> ReconcilePreHookInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _reconcile_pre_hook(self):
            // invoices = self.move_id.filtered(lambda move: move.is_invoice(include_receipts=True))
            // return {
            //     'not_paid_invoices': invoices.filtered(lambda inv: inv.payment_state not in ('paid', 'in_payment')),
            //     'in_payment_invoices': invoices.filtered(lambda inv: inv.payment_state == 'in_payment'),
            // }
            */
            return default;
        }

        protected async Task<Dictionary<string, object>> ReconciledByNumberInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _reconciled_by_number(self) -> dict:
            // """Get the mapping of all the lines matched with the lines in self grouped by matching number."""
            // matching_numbers = [n for n in set(self.mapped('matching_number')) if n]
            // if matching_numbers:
            //     return dict(self._read_group(
            //         domain=[('matching_number', 'in', matching_numbers)],
            //         groupby=['matching_number'],
            //         aggregates=['id:recordset'],
            //     ))
            // return {}
            */
            return default;
        }

        protected async Task<AccountMoveLine> ReconciledLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _reconciled_lines(self):
            // ids = []
            // for aml in self.filtered('reconciled'):
            //     ids.extend([r.debit_move_id.id for r in aml.matched_debit_ids] if aml.credit > 0 else [r.credit_move_id.id for r in aml.matched_credit_ids])
            //     ids.append(aml.id)
            // return ids
            */
            return default;
        }

        public async Task<AccountMoveLine> RegisterPaymentAsync(Guid id, AccountMoveLineRegisterPaymentRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def action_register_payment(self, ctx=None):
            // ''' Open the account.payment.register wizard to pay the selected journal items.
            // :return: An action opening the account.payment.register wizard.
            // '''
            // context = {
            //     'active_model': 'account.move.line',
            //     'active_ids': self.ids,
            // }
            // if ctx:
            //     context.update(ctx)
            // return {
            //     'name': _('Pay'),
            //     'res_model': 'account.payment.register',
            //     'view_mode': 'form',
            //     'views': [[False, 'form']],
            //     'context': context,
            //     'target': 'new',
            //     'type': 'ir.actions.act_window',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMoveLine> RelatedAnalyticDistributionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _related_analytic_distribution(self):
            // """ Returns the analytic distribution set on the record which triggered the creation of this line. """
            // return {}
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def _related_analytic_distribution(self):
            // # EXTENDS 'account'
            // vals = super()._related_analytic_distribution()
            // if self.purchase_line_id and not self.analytic_distribution:
            //     vals |= self.purchase_line_id.analytic_distribution or {}
            // return vals
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move_line.py) ---
            // def _related_analytic_distribution(self):
            // # EXTENDS 'account'
            // vals = super()._related_analytic_distribution()
            // if self.sale_line_ids and not self.analytic_distribution:
            //     vals |= self.sale_line_ids[0].analytic_distribution or {}
            // return vals
            */
            return default;
        }

        public async Task<AccountMoveLine> RemoveMoveReconcileAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def remove_move_reconcile(self):
            // """ Undo a reconciliation """
            // (self.matched_debit_ids + self.matched_credit_ids).unlink()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMoveLine> ReplayHistoryInternalAsync(object layers, object history)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: account_move_line.py) ---
            // def _replay_history(self, layers, history):
            // history.append((False, self, False))  # time was only usefull for the sorting
            // 
            // # the next dict is a matrix [layer L, invoice I] where each cell gives two info:
            // # [initial qty of L invoiced by I, remaining invoiced qty]
            // # the second info is usefull in case of a refund
            // layers_and_invoices_qties = defaultdict(lambda: [0, 0])
            // 
            // # the next dict will also provide two info:
            // # [total qty to invoice, remaining qty to invoice]
            // # we need the total qty to invoice, so we will be able to deduce the invoiced qty before `self`
            // qty_to_invoice_per_layer = defaultdict(lambda: [0, 0])
            // for _time, aml, layer in history:
            //     if layer:
            //         total_layer_qty_to_invoice = abs(layer.quantity)
            //         initial_layer = layer.stock_move_id.origin_returned_move_id.stock_valuation_layer_ids
            //         # Filter out revaluation layers (Landed Cost)
            //         initial_layer = initial_layer.filtered(lambda svl: not svl.stock_valuation_layer_id)
            //         if initial_layer:
            //             # `layer` is a return. We will cancel the qty to invoice of the returned layer
            //             # /!\ we will cancel the qty not yet invoiced only
            //             initial_layer_remaining_qty = qty_to_invoice_per_layer[initial_layer][1]
            //             common_qty = min(initial_layer_remaining_qty, total_layer_qty_to_invoice)
            //             qty_to_invoice_per_layer[initial_layer][0] -= common_qty
            //             qty_to_invoice_per_layer[initial_layer][1] -= common_qty
            //             total_layer_qty_to_invoice = max(0, total_layer_qty_to_invoice - common_qty)
            //         if float_compare(total_layer_qty_to_invoice, 0, precision_rounding=self.product_id.uom_id.rounding) > 0:
            //             qty_to_invoice_per_layer[layer] = [total_layer_qty_to_invoice, total_layer_qty_to_invoice]
            //     else:
            //         invoice = aml.move_id
            //         impacted_invoice = False
            //         aml_qty = aml.product_uom_id._compute_quantity(aml.quantity, self.product_id.uom_id)
            //         if aml.is_refund:
            //             reversed_invoice = aml.move_id.reversed_entry_id
            //             if reversed_invoice:
            //                 sign = -1
            //                 impacted_invoice = reversed_invoice
            //                 # it's a refund, therefore we can only consume the quantities invoiced by
            //                 # the initial invoice (`reversed_invoice`)
            //                 layers_to_consume = []
            //                 for layer in layers:
            //                     remaining_invoiced_qty = layers_and_invoices_qties[layer, reversed_invoice][1]
            //                     layers_to_consume.append((layer, remaining_invoiced_qty))
            //             else:
            //                 # the refund has been generated because of a stock return, let's find and use it
            //                 sign = 1
            //                 layers_to_consume = []
            //                 for layer in qty_to_invoice_per_layer:
            //                     if layer.stock_move_id._is_out():
            //                         layers_to_consume.append((layer, qty_to_invoice_per_layer[layer][1]))
            //         else:
            //             # classic case, we are billing a received quantity so let's use the incoming SVLs
            //             sign = 1
            //             layers_to_consume = []
            //             for layer in qty_to_invoice_per_layer:
            //                 if layer.stock_move_id._is_in():
            //                     layers_to_consume.append((layer, qty_to_invoice_per_layer[layer][1]))
            //         while float_compare(aml_qty, 0, precision_rounding=self.product_id.uom_id.rounding) > 0 and layers_to_consume:
            //             layer, total_layer_qty_to_invoice = layers_to_consume[0]
            //             layers_to_consume = layers_to_consume[1:]
            //             if float_is_zero(total_layer_qty_to_invoice, precision_rounding=self.product_id.uom_id.rounding):
            //                 continue
            //             common_qty = min(aml_qty, total_layer_qty_to_invoice)
            //             aml_qty -= common_qty
            //             qty_to_invoice_per_layer[layer][1] -= sign * common_qty
            //             layers_and_invoices_qties[layer, invoice] = [common_qty, common_qty]
            //             layers_and_invoices_qties[layer, impacted_invoice][1] -= common_qty
            // 
            // return qty_to_invoice_per_layer, layers_and_invoices_qties
            */
            return default;
        }

        protected async Task<AccountMoveLine> SaleCanBeReinvoiceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move_line.py) ---
            // def _sale_can_be_reinvoice(self):
            // """ determine if the generated analytic line should be reinvoiced or not.
            //     For Vendor Bill flow, if the product has a 'erinvoice policy' and is a cost, then we will find the SO on which reinvoice the AAL
            // """
            // self.ensure_one()
            // if self.sale_line_ids:
            //     return False
            // uom_precision_digits = self.env['decimal.precision'].precision_get('Product Unit of Measure')
            // return float_compare(self.credit or 0.0, self.debit or 0.0, precision_digits=uom_precision_digits) != 1 and self.product_id.expense_policy not in [False, 'no']
            --- ODOO METHOD SOURCE (MODULE: sale_expense, FILE: account_move_line.py) ---
            // def _sale_can_be_reinvoice(self):
            // """ determine if the generated analytic line should be reinvoiced or not.
            //     For Expense flow, if the product has a 'reinvoice policy' and a Sales Order is set on the expense, then we will reinvoice the AAL
            // """
            // self.ensure_one()
            // if self.expense_id:  # expense flow is different from vendor bill reinvoice flow
            //     return self.expense_id.product_id.expense_policy in {'sales_price', 'cost'} and self.expense_id.sale_order_id
            // return super()._sale_can_be_reinvoice()
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: account_move.py) ---
            // def _sale_can_be_reinvoice(self):
            // self.ensure_one()
            // return self.move_type != 'entry' and self.display_type != 'cogs' and super(AccountMoveLine, self)._sale_can_be_reinvoice()
            */
            return default;
        }

        protected async Task<AccountMoveLine> SaleCreateReinvoiceSaleLineInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move_line.py) ---
            // def _sale_create_reinvoice_sale_line(self):
            // 
            // sale_order_map = self._sale_determine_order()
            // 
            // sale_line_values_to_create = []  # the list of creation values of sale line to create.
            // existing_sale_line_cache = {}  # in the sales_price-delivery case, we can reuse the same sale line. This cache will avoid doing a search each time the case happen
            // # `map_move_sale_line` is map where
            // #   - key is the move line identifier
            // #   - value is either a sale.order.line record (existing case), or an integer representing the index of the sale line to create in
            // #     the `sale_line_values_to_create` (not existing case, which will happen more often than the first one).
            // map_move_sale_line = {}
            // 
            // for move_line in self:
            //     sale_order = sale_order_map.get(move_line.id)
            // 
            //     # no reinvoice as no sales order was found
            //     if not sale_order:
            //         continue
            // 
            //     # raise if the sale order is not currently open
            //     if sale_order.state in ('draft', 'sent'):
            //         raise UserError(_(
            //             "The Sales Order %(order)s to be reinvoiced must be validated before registering expenses.",
            //             order=sale_order.name,
            //         ))
            //     elif sale_order.state == 'cancel':
            //         raise UserError(_(
            //             "The Sales Order %(order)s to be reinvoiced is cancelled."
            //             " You cannot register an expense on a cancelled Sales Order.",
            //             order=sale_order.name,
            //         ))
            //     elif sale_order.locked:
            //         raise UserError(_(
            //             "The Sales Order %(order)s to be reinvoiced is currently locked."
            //             " You cannot register an expense on a locked Sales Order.",
            //             order=sale_order.name,
            //         ))
            // 
            //     price = move_line._sale_get_invoice_price(sale_order)
            // 
            //     # find the existing sale.line or keep its creation values to process this in batch
            //     sale_line = None
            //     if (
            //         move_line.product_id.expense_policy == 'sales_price'
            //         and move_line.product_id.invoice_policy == 'delivery'
            //         and not self.env.context.get('force_split_lines')
            //     ):
            //         # for those case only, we can try to reuse one
            //         map_entry_key = (sale_order.id, move_line.product_id.id, price)  # cache entry to limit the call to search
            //         sale_line = existing_sale_line_cache.get(map_entry_key)
            //         if sale_line:  # already search, so reuse it. sale_line can be sale.order.line record or index of a "to create values" in `sale_line_values_to_create`
            //             map_move_sale_line[move_line.id] = sale_line
            //             existing_sale_line_cache[map_entry_key] = sale_line
            //         else:  # search for existing sale line
            //             sale_line = self.env['sale.order.line'].search([
            //                 ('order_id', '=', sale_order.id),
            //                 ('price_unit', '=', price),
            //                 ('product_id', '=', move_line.product_id.id),
            //                 ('is_expense', '=', True),
            //             ], limit=1)
            //             if sale_line:  # found existing one, so keep the browse record
            //                 map_move_sale_line[move_line.id] = existing_sale_line_cache[map_entry_key] = sale_line
            //             else:  # should be create, so use the index of creation values instead of browse record
            //                 # save value to create it
            //                 sale_line_values_to_create.append(move_line._sale_prepare_sale_line_values(sale_order, price))
            //                 # store it in the cache of existing ones
            //                 existing_sale_line_cache[map_entry_key] = len(sale_line_values_to_create) - 1  # save the index of the value to create sale line
            //                 # store it in the map_move_sale_line map
            //                 map_move_sale_line[move_line.id] = len(sale_line_values_to_create) - 1  # save the index of the value to create sale line
            // 
            //     else:  # save its value to create it anyway
            //         sale_line_values_to_create.append(move_line._sale_prepare_sale_line_values(sale_order, price))
            //         map_move_sale_line[move_line.id] = len(sale_line_values_to_create) - 1  # save the index of the value to create sale line
            // 
            // # create the sale lines in batch
            // new_sale_lines = self.env['sale.order.line'].create(sale_line_values_to_create)
            // 
            // # build result map by replacing index with newly created record of sale.order.line
            // result = {}
            // for move_line_id, unknown_sale_line in map_move_sale_line.items():
            //     if isinstance(unknown_sale_line, int):  # index of newly created sale line
            //         result[move_line_id] = new_sale_lines[unknown_sale_line]
            //     elif isinstance(unknown_sale_line, models.BaseModel):  # already record of sale.order.line
            //         result[move_line_id] = unknown_sale_line
            // return result
            --- ODOO METHOD SOURCE (MODULE: sale_expense, FILE: account_move_line.py) ---
            // def _sale_create_reinvoice_sale_line(self):
            // expensed_lines = self.filtered('expense_id')
            // res = super(AccountMoveLine, self - expensed_lines)._sale_create_reinvoice_sale_line()
            // res.update(super(AccountMoveLine, expensed_lines.with_context({'force_split_lines': True}))._sale_create_reinvoice_sale_line())
            // return res
            */
            return default;
        }

        protected async Task<AccountMoveLine> SaleDetermineOrderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_sale_expense, FILE: account_move_line.py) ---
            // def _sale_determine_order(self):
            // """ For move lines created from expense, we override the normal behavior.
            //     Note: if no SO but an AA is given on the expense, we will determine anyway the SO from its project's AAs linked,
            //     using the same mecanism as in Vendor Bills.
            // """
            // mapping_from_project = self._get_so_mapping_from_project()
            // mapping_from_expense = self._get_so_mapping_from_expense()
            // mapping_from_project.update(mapping_from_expense)
            // return mapping_from_project
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move_line.py) ---
            // def _sale_determine_order(self):
            // """ Get the mapping of move.line with the sale.order record on which its analytic entries should be reinvoiced
            //     :return a dict where key is the move line id, and value is sale.order record (or None).
            // """
            // return {}
            --- ODOO METHOD SOURCE (MODULE: sale_expense, FILE: account_move_line.py) ---
            // def _sale_determine_order(self):
            // """ For move lines created from expense, we override the normal behavior.
            // """
            // mapping_from_invoice = super()._sale_determine_order()
            // mapping_from_invoice.update(self._get_so_mapping_from_expense())
            // return mapping_from_invoice
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: account_move_line.py) ---
            // def _sale_determine_order(self):
            // mapping_from_invoice = super()._sale_determine_order()
            // mapping_from_invoice.update(self._get_so_mapping_from_project())
            // return mapping_from_invoice
            */
            return default;
        }

        protected async Task<AccountMoveLine> SaleGetInvoicePriceInternalAsync(object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move_line.py) ---
            // def _sale_get_invoice_price(self, order):
            // """ Based on the current move line, compute the price to reinvoice the analytic line that is going to be created (so the
            //     price of the sale line).
            // """
            // self.ensure_one()
            // 
            // unit_amount = self.quantity
            // amount = (self.credit or 0.0) - (self.debit or 0.0)
            // 
            // if self.product_id.expense_policy == 'sales_price':
            //     return order.pricelist_id._get_product_price(
            //         self.product_id,
            //         1.0,
            //         uom=self.product_uom_id,
            //         date=order.date_order,
            //     )
            // 
            // uom_precision_digits = self.env['decimal.precision'].precision_get('Product Unit of Measure')
            // if float_is_zero(unit_amount, precision_digits=uom_precision_digits):
            //     return 0.0
            // 
            // # Prevent unnecessary currency conversion that could be impacted by exchange rate
            // # fluctuations
            // if self.company_id.currency_id and amount and self.company_id.currency_id == order.currency_id:
            //     return self.company_id.currency_id.round(abs(amount / unit_amount))
            // 
            // price_unit = abs(amount / unit_amount)
            // currency_id = self.company_id.currency_id
            // if currency_id and currency_id != order.currency_id:
            //     price_unit = currency_id._convert(price_unit, order.currency_id, order.company_id, order.date_order or fields.Date.today())
            // return price_unit
            */
            return default;
        }

        protected async Task<AccountMoveLine> SalePrepareSaleLineValuesInternalAsync(object order, object price)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move_line.py) ---
            // def _sale_prepare_sale_line_values(self, order, price):
            // """ Generate the sale.line creation value from the current move line """
            // self.ensure_one()
            // last_so_line = self.env['sale.order.line'].search([('order_id', '=', order.id)], order='sequence desc', limit=1)
            // last_sequence = last_so_line.sequence + 1 if last_so_line else 100
            // 
            // fpos = order.fiscal_position_id or order.fiscal_position_id._get_fiscal_position(order.partner_id)
            // product_taxes = self.product_id.taxes_id._filter_taxes_by_company(order.company_id)
            // taxes = fpos.map_tax(product_taxes)
            // 
            // return {
            //     'order_id': order.id,
            //     'name': self.name,
            //     'sequence': last_sequence,
            //     'price_unit': price,
            //     'tax_id': [x.id for x in taxes],
            //     'discount': 0.0,
            //     'product_id': self.product_id.id,
            //     'product_uom': self.product_uom_id.id,
            //     'product_uom_qty': self.quantity,
            //     'is_expense': True,
            //     'analytic_distribution': self.analytic_distribution,
            // }
            --- ODOO METHOD SOURCE (MODULE: sale_expense, FILE: account_move_line.py) ---
            // def _sale_prepare_sale_line_values(self, order, price):
            // # Add expense quantity to sales order line and update the sales order price because it will be charged to the customer in the end.
            // res = super()._sale_prepare_sale_line_values(order, price)
            // if self.expense_id:
            //     res['name'] = self.name
            //     res['product_uom_qty'] = self.expense_id.quantity
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale_expense_margin, FILE: account_move_line.py) ---
            // def _sale_prepare_sale_line_values(self, order, price):
            // res = super()._sale_prepare_sale_line_values(order, price)
            // if self.expense_id:
            //     res['expense_id'] = self.expense_id.id
            // return res
            */
            return default;
        }

        protected async Task<AccountMoveLine> SanitizeValsInternalAsync(object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _sanitize_vals(self, vals):
            // if 'debit' in vals or 'credit' in vals:
            //     vals = vals.copy()
            //     if 'balance' in vals:
            //         vals.pop('debit', None)
            //         vals.pop('credit', None)
            //     else:
            //         vals['balance'] = vals.pop('debit', 0) - vals.pop('credit', 0)
            // if (
            //     vals.get('matching_number')
            //     and not vals['matching_number'].startswith('I')
            //     and not self.env.context.get('skip_matching_number_check')
            // ):
            //     vals['matching_number'] = f"I{vals['matching_number']}"
            // 
            // return vals
            */
            return default;
        }

        public async Task<AccountMoveLine> SearchFetchAsync(Guid id, AccountMoveLineSearchFetchRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def search_fetch(self, domain, field_names, offset=0, limit=None, order=None):
            // def to_tuple(t):
            //     return tuple(map(to_tuple, t)) if isinstance(t, (list, tuple)) else t
            // order = (order or self._order)
            // if not re.search(r'\bid\b', order):
            //     # Make an explicit order because we will need to reverse it
            //     order += ', id'
            // # Add the domain and order by in order to compute the cumulated balance in _compute_cumulated_balance
            // contextualized = self.with_context(
            //     domain_cumulated_balance=to_tuple(domain or []),
            //     order_cumulated_balance=order,
            // )
            // return super(AccountMoveLine, contextualized).search_fetch(domain, field_names, offset, limit, order)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMoveLine> SearchJournalGroupIdInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _search_journal_group_id(self, operator, value):
            // field = 'name' if 'like' in operator else 'id'
            // journal_groups = self.env['account.journal.group'].search([(field, operator, value)])
            // return [('journal_id', 'not in', journal_groups.excluded_journal_ids.ids)]
            */
            return default;
        }

        protected async Task<AccountMoveLine> SearchPanelDomainImageInternalAsync(object field_name, object domain, object set_count, object limit)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _search_panel_domain_image(self, field_name, domain, set_count=False, limit=False):
            // if field_name != 'account_root_id' or set_count:
            //     return super()._search_panel_domain_image(field_name, domain, set_count, limit)
            // 
            // # if domain is logically equivalent to false
            // if expression.is_false(self, domain):
            //     return {}
            // 
            // # Override in order to not read the complete move line table and use the index instead
            // query_account = self.env['account.account']._search([('company_ids', 'in', self.env.companies.ids), ('code', '!=', False)])
            // account_code_alias = self.env['account.account']._field_to_sql('account_account', 'code', query_account)
            // 
            // query_line = self._search(domain, limit=1)
            // query_line.add_where('account_account.id = account_move_line.account_id')
            // 
            // account_codes = self.env.execute_query(SQL(
            //     """
            //     SELECT %(account_code_alias)s AS code
            //       FROM %(account_table)s
            //      WHERE EXISTS(%(line_select)s)
            //        AND %(where_clause)s
            //     """,
            //     account_code_alias=account_code_alias,
            //     account_table=query_account.from_clause,
            //     line_select=query_line.select(),
            //     where_clause=query_account.where_clause,
            // ))
            // return {
            //     (root := self.env['account.root']._from_account_code(code)).id: {'id': root.id, 'display_name': root.display_name}
            //     for code, in account_codes
            // }
            */
            return default;
        }

        protected async Task<AccountMoveLine> SearchPaymentDateInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _search_payment_date(self, operator, value):
            // if operator == '=':
            //     operator = '<='
            // return [
            //         '|',
            //         '|',
            //         '&', ('discount_date', '>=', str(date.today())), ('discount_date', operator, value),
            //         '&', ('discount_date', '<', str(date.today())), ('date_maturity', operator, value),
            //         '&', ('discount_date', '=', False), ('date_maturity', operator, value),
            //     ]
            */
            return default;
        }

        protected async Task<AccountMoveLine> StockAccountGetAngloSaxonPriceUnitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: account_move.py) ---
            // def _stock_account_get_anglo_saxon_price_unit(self):
            // self.ensure_one()
            // if not self.product_id:
            //     return self.price_unit
            // price_unit = super(AccountMoveLine, self)._stock_account_get_anglo_saxon_price_unit()
            // sudo_order = self.move_id.sudo().pos_order_ids
            // if sudo_order:
            //     price_unit = sudo_order._get_pos_anglo_saxon_price_unit(self.product_id, self.move_id.partner_id.id, self.quantity)
            // return price_unit
            --- ODOO METHOD SOURCE (MODULE: sale_mrp, FILE: account_move.py) ---
            // def _stock_account_get_anglo_saxon_price_unit(self):
            // price_unit = super(AccountMoveLine, self)._stock_account_get_anglo_saxon_price_unit()
            // 
            // so_line = self.sale_line_ids and self.sale_line_ids[-1] or False
            // if so_line:
            //     # We give preference to the bom in the stock moves for the sale order lines
            //     # If there are changes in BOMs between the stock moves creation and the
            //     # invoice validation a wrong price will be taken
            //     boms = so_line.move_ids.filtered(lambda m: m.state != 'cancel').mapped('bom_line_id.bom_id').filtered(lambda b: b.type == 'phantom')
            //     if boms:
            //         bom = boms.filtered(lambda b: b.product_id == so_line.product_id or b.product_tmpl_id == so_line.product_id.product_tmpl_id)
            //         if not bom:
            //             # In the case where the product has no direct component in its bom, it won't be present in the stock moves boms.
            //             # We then take the first bom of the product.
            //             bom = self.env['mrp.bom']._bom_find(products=so_line.product_id, company_id=so_line.company_id.id, bom_type='phantom')[so_line.product_id]
            //         is_line_reversing = self.move_id.move_type == 'out_refund'
            //         qty_to_invoice = self.product_uom_id._compute_quantity(self.quantity, self.product_id.uom_id)
            //         account_moves = so_line.invoice_lines.move_id.filtered(lambda m: m.state == 'posted' and bool(m.reversed_entry_id) == is_line_reversing)
            //         posted_invoice_lines = account_moves.line_ids.filtered(lambda l: l.display_type == 'cogs' and l.product_id == self.product_id and l.balance > 0)
            //         qty_invoiced = sum([x.product_uom_id._compute_quantity(x.quantity, x.product_id.uom_id) for x in posted_invoice_lines])
            //         reversal_cogs = posted_invoice_lines.move_id.reversal_move_ids.line_ids.filtered(lambda l: l.display_type == 'cogs' and l.product_id == self.product_id and l.balance > 0)
            //         qty_invoiced -= sum([line.product_uom_id._compute_quantity(line.quantity, line.product_id.uom_id) for line in reversal_cogs])
            // 
            //         moves = so_line.move_ids
            //         average_price_unit = 0
            //         components_qty = so_line._get_bom_component_qty(bom)
            //         storable_components = self.env['product.product'].search([('id', 'in', list(components_qty.keys())), ('is_storable', '=', True)])
            //         for product in storable_components:
            //             factor = components_qty[product.id]['qty']
            //             prod_moves = moves.filtered(lambda m: m.product_id == product)
            //             prod_qty_invoiced = factor * qty_invoiced
            //             prod_qty_to_invoice = factor * qty_to_invoice
            //             product = product.with_company(self.company_id)
            //             average_price_unit += factor * product._compute_average_price(prod_qty_invoiced, prod_qty_to_invoice, prod_moves, is_returned=is_line_reversing)
            //         price_unit = average_price_unit / bom.product_qty or price_unit
            //         price_unit = self.product_id.uom_id._compute_price(price_unit, self.product_uom_id)
            // return price_unit
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: account_move.py) ---
            // def _stock_account_get_anglo_saxon_price_unit(self):
            // self.ensure_one()
            // price_unit = super(AccountMoveLine, self)._stock_account_get_anglo_saxon_price_unit()
            // 
            // so_line = self.sale_line_ids and self.sale_line_ids[-1] or False
            // move_is_downpayment = self.env.context.get("move_is_downpayment")
            // if move_is_downpayment is None:
            //     move_is_downpayment = self.move_id.invoice_line_ids.filtered(
            //     lambda line: any(line.sale_line_ids.mapped("is_downpayment"))
            // )
            // if so_line:
            //     is_line_reversing = False
            //     if self.move_id.move_type == 'out_refund' and not move_is_downpayment:
            //         is_line_reversing = True
            //     qty_to_invoice = self.product_uom_id._compute_quantity(self.quantity, self.product_id.uom_id)
            //     if self.move_id.move_type == 'out_refund' and move_is_downpayment:
            //         qty_to_invoice = -qty_to_invoice
            //     account_moves = so_line.invoice_lines.move_id.filtered(lambda m: m.state == 'posted' and bool(m.reversed_entry_id) == is_line_reversing)
            // 
            //     posted_cogs = self.env['account.move.line'].search([
            //         ('move_id', 'in', account_moves.ids),
            //         ('display_type', '=', 'cogs'),
            //         ('product_id', '=', self.product_id.id),
            //         ('balance', '>', 0),
            //     ])
            //     posted_cogs = posted_cogs.filtered(lambda l: so_line in l.cogs_origin_id.sale_line_ids)
            //     qty_invoiced = 0
            //     product_uom = self.product_id.uom_id
            //     for line in posted_cogs:
            //         if float_compare(line.quantity, 0, precision_rounding=product_uom.rounding) and line.move_id.move_type == 'out_refund' and any(line.move_id.invoice_line_ids.sale_line_ids.mapped('is_downpayment')):
            //             qty_invoiced += line.product_uom_id._compute_quantity(abs(line.quantity), line.product_id.uom_id)
            //         else:
            //             qty_invoiced += line.product_uom_id._compute_quantity(line.quantity, line.product_id.uom_id)
            //     value_invoiced = sum(posted_cogs.mapped('balance'))
            //     reversal_moves = self.env['account.move']._search([('reversed_entry_id', 'in', posted_cogs.move_id.ids)])
            //     reversal_cogs = self.env['account.move.line'].search([
            //         ('move_id', 'in', reversal_moves),
            //         ('display_type', '=', 'cogs'),
            //         ('product_id', '=', self.product_id.id),
            //         ('balance', '>', 0)
            //     ])
            //     for line in reversal_cogs:
            //         if float_compare(line.quantity, 0, precision_rounding=product_uom.rounding) and line.move_id.move_type == 'out_refund' and any(line.move_id.invoice_line_ids.sale_line_ids.mapped('is_downpayment')):
            //             qty_invoiced -= line.product_uom_id._compute_quantity(abs(line.quantity), line.product_id.uom_id)
            //         else:
            //             qty_invoiced -= line.product_uom_id._compute_quantity(line.quantity, line.product_id.uom_id)
            //     value_invoiced -= sum(reversal_cogs.mapped('balance'))
            // 
            //     product = self.product_id.with_company(self.company_id).with_context(value_invoiced=value_invoiced)
            //     average_price_unit = product._compute_average_price(qty_invoiced, qty_to_invoice, so_line.move_ids, is_returned=is_line_reversing)
            //     price_unit = self.product_id.uom_id.with_company(self.company_id)._compute_price(average_price_unit, self.product_uom_id)
            // return price_unit
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move.py) ---
            // def _stock_account_get_anglo_saxon_price_unit(self):
            // self.ensure_one()
            // if not self.product_id:
            //     return self.price_unit
            // original_line = self.move_id.reversed_entry_id.line_ids.filtered(
            //     lambda l: l.display_type == 'cogs' and l.product_id == self.product_id and
            //     l.product_uom_id == self.product_uom_id and l.price_unit >= 0)
            // original_line = original_line and original_line[0]
            // return original_line.price_unit if original_line \
            //     else self.product_id.with_company(self.company_id)._stock_account_get_anglo_saxon_price_unit(uom=self.product_uom_id)
            */
            return default;
        }

        protected async Task<AccountMoveLine> SyncInvoiceInternalAsync(object container)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _sync_invoice(self, container):
            // if container['records'].env.context.get('skip_invoice_line_sync'):
            //     yield
            //     return  # avoid infinite recursion
            // 
            // def existing():
            //     return {
            //         line: {
            //             'amount_currency': line.currency_id.round(line.amount_currency),
            //             'balance': line.company_id.currency_id.round(line.balance),
            //             'currency_rate': line.currency_rate,
            //             'price_subtotal': line.currency_id.round(line.price_subtotal),
            //             'move_type': line.move_id.move_type,
            //         } for line in container['records'].with_context(
            //             skip_invoice_line_sync=True,
            //         ).filtered(lambda l: l.move_id.is_invoice(True))
            //     }
            // 
            // def changed(fname):
            //     return line not in before or before[line][fname] != after[line][fname]
            // 
            // before = existing()
            // yield
            // after = existing()
            // for line in after:
            //     if (
            //         (changed('amount_currency') or changed('currency_rate') or changed('move_type'))
            //         and not self.env.is_protected(self._fields['balance'], line)
            //         and (not changed('balance') or (line not in before and not line.balance))
            //     ):
            //         balance = line.company_id.currency_id.round(line.amount_currency / line.currency_rate)
            //         line.balance = balance
            // 
            // # Since this method is called during the sync, inside of `create`/`write`, these fields
            // # already have been computed and marked as so. But this method should re-trigger it since
            // # it changes the dependencies.
            // self.env.add_to_compute(self._fields['debit'], container['records'])
            // self.env.add_to_compute(self._fields['credit'], container['records'])
            */
            return default;
        }

        protected async Task<AccountMoveLine> TimesheetDomainGetInvoicedLinesInternalAsync(object sale_line_delivery)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: account_move_line.py) ---
            // def _timesheet_domain_get_invoiced_lines(self, sale_line_delivery):
            // """ Get the domain for the timesheet to link to the created invoice
            //     :param sale_line_delivery: recordset of sale.order.line to invoice
            //     :return a normalized domain
            // """
            // return [
            //     ('so_line', 'in', sale_line_delivery.ids),
            //     ('project_id', '!=', False),
            //     '|', '|',
            //         ('timesheet_invoice_id', '=', False),
            //         '&',
            //             ('timesheet_invoice_id.state', '=', 'cancel'),
            //             ('timesheet_invoice_id.payment_state', '!=', 'invoicing_legacy'),
            //         ('timesheet_invoice_id.payment_state', '=', 'reversed')
            // ]
            */
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def unlink(self):
            // if not self:
            //     return True
            // 
            // # Check the lines are not reconciled (partially or not).
            // self._check_reconciliation()
            // 
            // # Check the lock date. (Only relevant if the move is posted)
            // self.move_id.filtered(lambda m: m.state == 'posted')._check_fiscal_lock_dates()
            // 
            // # Check the tax lock date.
            // self._check_tax_lock_date()
            // 
            // if not self.env.context.get('tracking_disable'):
            //     # Log changes to move lines on each move
            //     tracked_fields = [fname for fname, f in self._fields.items() if hasattr(f, 'tracking') and f.tracking and not (hasattr(f, 'related') and f.related)]
            //     ref_fields = self.env['account.move.line'].fields_get(tracked_fields)
            //     empty_line = self.browse([False])  # all falsy fields but not failing `ensure_one` checks
            //     for move_id, modified_lines in self.grouped('move_id').items():
            //         if not move_id.posted_before:
            //             continue
            //         for line in modified_lines:
            //             if tracking_value_ids := empty_line._mail_track(ref_fields, line)[1]:
            //                 line.move_id._message_log(
            //                     body=_("Journal Item %s deleted", line._get_html_link(title=f"#{line.id}")),
            //                     tracking_value_ids=tracking_value_ids
            //                 )
            // 
            // move_container = {'records': self.move_id}
            // with self.move_id._check_balanced(move_container),\
            //      self.move_id._sync_dynamic_lines(move_container):
            //     res = super().unlink()
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: account_fleet, FILE: account_move.py) ---
            // def unlink(self):
            // self.sudo().vehicle_log_service_ids.with_context(ignore_linked_bill_constraint=True).unlink()
            // return super().unlink()
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: account_move_line.py) ---
            // def unlink(self):
            // move_line_read_group = self.env['account.move.line'].search_read([
            //     ('move_id.move_type', '=', 'out_invoice'),
            //     ('move_id.state', '=', 'draft'),
            //     ('sale_line_ids.product_id.invoice_policy', '=', 'delivery'),
            //     ('sale_line_ids.product_id.service_type', '=', 'timesheet'),
            //     ('id', 'in', self.ids)],
            //     ['move_id', 'sale_line_ids'])
            // 
            // sale_line_ids_per_move = defaultdict(lambda: self.env['sale.order.line'])
            // for move_line in move_line_read_group:
            //     sale_line_ids_per_move[move_line['move_id'][0]] += self.env['sale.order.line'].browse(move_line['sale_line_ids'])
            // 
            // timesheet_read_group = self.sudo().env['account.analytic.line']._read_group([
            //     ('timesheet_invoice_id.move_type', '=', 'out_invoice'),
            //     ('timesheet_invoice_id.state', '=', 'draft'),
            //     ('timesheet_invoice_id', 'in', self.move_id.ids)],
            //     ['timesheet_invoice_id', 'so_line'],
            //     ['id:array_agg'])
            // 
            // timesheet_ids = []
            // for timesheet_invoice, so_line, ids in timesheet_read_group:
            //     if so_line.id in sale_line_ids_per_move[timesheet_invoice.id].ids:
            //         timesheet_ids += ids
            // 
            // self.sudo().env['account.analytic.line'].browse(timesheet_ids).write({'timesheet_invoice_id': False})
            // return super().unlink()
            */
            return await base.UnlinkAsync(ids);
        }

        protected async Task<AccountMoveLine> UnlinkExceptPostedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _unlink_except_posted(self):
            // # Prevent deleting lines on posted entries
            // if not self._context.get('force_delete') and any(m.state == 'posted' for m in self.move_id):
            //     raise UserError(_("You can't delete a posted journal item. Don’t play games with your accounting records; reset the journal entry to draft before deleting it."))
            */
            return default;
        }

        public async Task<AccountMoveLine> UnreconcileMatchEntriesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def action_unreconcile_match_entries(self):
            // """ This method will do the unreconcile action in the list view of the moves """
            // active_ids = self._context.get('active_ids')
            // if active_ids:
            //     move_lines = self.env['account.move.line'].browse(active_ids)._all_reconciled_lines()
            //     move_lines.remove_move_reconcile()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMoveLine> UpdateAnalyticDistributionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _update_analytic_distribution(self):
            // if self.env.context.get('skip_analytic_sync'):
            //     return
            // for line in self:
            //     line.with_context(skip_analytic_sync=True).analytic_distribution = {
            //         analytic_line._get_distribution_key(): -analytic_line.amount / line.balance * 100
            //         for analytic_line in line.analytic_line_ids
            //     }
            */
            return default;
        }

        protected async Task<AccountMoveLine> ValidFieldParameterInternalAsync(object field, object name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _valid_field_parameter(self, field, name):
            // # EXTENDS models
            // return name == 'tracking' or super()._valid_field_parameter(field, name)
            */
            return default;
        }

        protected async Task<AccountMoveLine> ValidateAnalyticDistributionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _validate_analytic_distribution(self):
            // lines_with_missing_analytic_distribution = self.env['account.move.line']
            // for line in self.filtered(lambda line: line.display_type == 'product'):
            //     try:
            //         line._validate_distribution(
            //             company_id=line.company_id.id,
            //             product=line.product_id.id,
            //             account=line.account_id.id,
            //             business_domain=(
            //                 'invoice' if line.move_id.is_sale_document(True)
            //                 else 'bill' if line.move_id.is_purchase_document(True)
            //                 else 'general'
            //             ),
            //         )
            //     except ValidationError:
            //         lines_with_missing_analytic_distribution += line
            // if lines_with_missing_analytic_distribution:
            //     msg = _("One or more lines require a 100% analytic distribution.")
            //     if len(self.move_id) == 1:
            //         raise ValidationError(msg)
            //     raise RedirectWarning(
            //         message=msg,
            //         action={
            //             'view_mode': 'list',
            //             'name': _('Items With Missing Analytic Distribution'),
            //             'res_model': 'account.move.line',
            //             'type': 'ir.actions.act_window',
            //             'domain': [('id', 'in', lines_with_missing_analytic_distribution.ids)],
            //             'views': [(self.env.ref('account.view_move_line_tree').id, 'list')],
            //         },
            //         button_text=_("See items"),
            //     )
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, AccountMoveLine entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def write(self, vals):
            // if not vals:
            //     return True
            // protected_fields = self._get_lock_date_protected_fields()
            // account_to_write = self.env['account.account'].browse(vals['account_id']) if 'account_id' in vals else None
            // 
            // # Check writing a deprecated account.
            // if account_to_write and account_to_write.deprecated:
            //     raise UserError(_('You cannot use a deprecated account.'))
            // 
            // inalterable_fields = set(self._get_integrity_hash_fields()).union({'inalterable_hash'})
            // hashed_moves = self.move_id.filtered('inalterable_hash')
            // violated_fields = set(vals) & inalterable_fields
            // if hashed_moves and violated_fields:
            //     raise UserError(_(
            //         "You cannot edit the following fields: %(fields)s.\n"
            //         "The following entries are already hashed:\n%(entries)s",
            //         fields=format_list(self.env, [f['string'] for f in self.fields_get(violated_fields).values()]),
            //         entries='\n'.join(hashed_moves.mapped('name')),
            //     ))
            // 
            // line_to_write = self
            // vals = self._sanitize_vals(vals)
            // matching2lines = None
            // for line in self:
            //     if not any(self.env['account.move']._field_will_change(line, vals, field_name) for field_name in vals):
            //         line_to_write -= line
            //         continue
            // 
            //     if line.parent_state == 'posted' and any(self.env['account.move']._field_will_change(line, vals, field_name) for field_name in ('tax_ids', 'tax_line_id')):
            //         raise UserError(_('You cannot modify the taxes related to a posted journal item, you should reset the journal entry to draft to do so.'))
            // 
            //     # Check the lock date.
            //     if line.parent_state == 'posted' and any(self.env['account.move']._field_will_change(line, vals, field_name) for field_name in protected_fields['fiscal']):
            //         line.move_id._check_fiscal_lock_dates()
            // 
            //     # Check the tax lock date.
            //     if line.parent_state == 'posted' and any(self.env['account.move']._field_will_change(line, vals, field_name) for field_name in protected_fields['tax']):
            //         line._check_tax_lock_date()
            // 
            //     # Check the reconciliation.
            //     if changing_fields := {
            //         field_name
            //         for field_name in protected_fields['reconciliation']
            //         if self.env['account.move']._field_will_change(line, vals, field_name)
            //     }:
            //         matching2lines = dict(self.env['account.move.line'].sudo()._read_group(
            //             domain=[('matching_number', 'in', [n for n in self.mapped('matching_number') if n])],
            //             groupby=['matching_number'],
            //             aggregates=['id:recordset']
            //         )) if matching2lines is None and line.matching_number else matching2lines
            //         if (
            //             # allow changing the account on all the lines of a reconciliation together
            //             changing_fields - {'account_id'}
            //             or line.matching_number and not all(reconciled_line in self for reconciled_line in matching2lines[line.matching_number])
            //         ):
            //             line._check_reconciliation()
            // 
            // move_container = {'records': self.move_id}
            // with self.move_id._check_balanced(move_container),\
            //      self.env.protecting(self.env['account.move']._get_protected_vals(vals, self)),\
            //      self.move_id._sync_dynamic_lines(move_container),\
            //      self._sync_invoice({'records': self}):
            //     self = line_to_write
            //     if not self:
            //         return True
            //     # Tracking stuff can be skipped for perfs using tracking_disable context key
            //     if not self.env.context.get('tracking_disable', False):
            //         # Get all tracked fields (without related fields because these fields must be manage on their own model)
            //         tracking_fields = []
            //         for value in vals:
            //             field = self._fields[value]
            //             if hasattr(field, 'related') and field.related:
            //                 continue # We don't want to track related field.
            //             if hasattr(field, 'tracking') and field.tracking:
            //                 tracking_fields.append(value)
            //         ref_fields = self.env['account.move.line'].fields_get(tracking_fields)
            // 
            //         # Get initial values for each line
            //         move_initial_values = {}
            //         for line in self.filtered(lambda l: l.move_id.posted_before): # Only lines with posted once move.
            //             for field in tracking_fields:
            //                 # Group initial values by move_id
            //                 if line.move_id.id not in move_initial_values:
            //                     move_initial_values[line.move_id.id] = {}
            //                 move_initial_values[line.move_id.id].update({field: line[field]})
            // 
            //     result = super().write(vals)
            //     self.move_id._synchronize_business_models(['line_ids'])
            //     if any(field in vals for field in ['account_id', 'currency_id']):
            //         self._check_constrains_account_id_journal_id()
            // 
            //     if not self.env.context.get('tracking_disable', False):
            //         # Log changes to move lines on each move
            //         for move_id, modified_lines in move_initial_values.items():
            //             for line in self.filtered(lambda l: l.move_id.id == move_id):
            //                 tracking_value_ids = line._mail_track(ref_fields, modified_lines)[1]
            //                 if tracking_value_ids:
            //                     msg = _("Journal Item %s updated", line._get_html_link(title=f"#{line.id}"))
            //                     line.move_id._message_log(
            //                         body=msg,
            //                         tracking_value_ids=tracking_value_ids
            //                     )
            // 
            // return result
            --- ODOO METHOD SOURCE (MODULE: account_fleet, FILE: account_move.py) ---
            // def write(self, vals):
            // if 'vehicle_id' in vals and not vals['vehicle_id']:
            //     self.sudo().vehicle_log_service_ids.with_context(ignore_linked_bill_constraint=True).unlink()
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: membership, FILE: account_move.py) ---
            // def write(self, vals):
            // # OVERRIDE
            // res = super(AccountMoveLine, self).write(vals)
            // 
            // to_process = self.filtered(lambda line: line.move_id.move_type == 'out_invoice' and line.product_id.membership)
            // 
            // # Nothing to process, break.
            // if not to_process:
            //     return res
            // 
            // existing_memberships = self.env['membership.membership_line'].search([
            //     ('account_invoice_line', 'in', to_process.ids)])
            // to_process = to_process - existing_memberships.mapped('account_invoice_line')
            // 
            // # All memberships already exist, break.
            // if not to_process:
            //     return res
            // 
            // memberships_vals = []
            // for line in to_process:
            //     date_from = line.product_id.membership_date_from
            //     date_to = line.product_id.membership_date_to
            //     if (date_from and date_from < (line.move_id.invoice_date or date.min) < (date_to or date.min)):
            //         date_from = line.move_id.invoice_date
            //     memberships_vals.append({
            //         'partner': line.move_id.partner_id.id,
            //         'membership_id': line.product_id.id,
            //         'member_price': line.price_unit,
            //         'date': fields.Date.today(),
            //         'date_from': date_from,
            //         'date_to': date_to,
            //         'account_invoice_line': line.id,
            //     })
            // self.env['membership.membership_line'].create(memberships_vals)
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}