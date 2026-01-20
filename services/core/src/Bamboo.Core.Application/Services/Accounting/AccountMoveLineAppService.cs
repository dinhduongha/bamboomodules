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
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Account", Category = "Accounting", Depends = new[] { "base_setup", "onboarding", "product", "analytic", "portal", "digest" })]
    public partial class AccountMoveLineAppService : GenericApplicationService<AccountMoveLine>, IAccountMoveLineAppService
    {
        private readonly IAnalyticMixinAppService _analyticMixinAppService;
        public AccountMoveLineAppService(IRepository<AccountMoveLine, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IAnalyticMixinAppService analyticMixinAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
            _analyticMixinAppService = analyticMixinAppService;
        }

        public async Task<AccountMoveLine> AddFromCatalogAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def action_add_from_catalog(self):
            // """ Will open the catalog view """
            // move = self.env['account.move'].browse(self.env.context.get('order_id'))
            // return move.with_context(child_field='line_ids').action_add_from_catalog()
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

        protected async Task<AccountMoveLine> ApplyIrRulesInternalAsync(object query, object mode)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: accounting_pdf_reports, FILE: account_move_line.py) ---
            // def _apply_ir_rules(self, query, mode='read'):
            // """Add what's missing in ``query`` to implement all appropriate ir.rules
            //   (using the ``model_name``'s rules or the current model's rules if ``model_name`` is None)
            // 
            // :param query: the current query object
            // """
            // if self.env.su:
            //     return
            // 
            // # apply main rules on the object
            // Rule = self.env['ir.rule']
            // domain = Rule._compute_domain(self._name, mode)
            // if domain:
            //     expression.expression(domain, self.sudo(), self._table, query)
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
            // not_reconciled_partial_matching_numbers = set(self
            //     .filtered(lambda aml: not aml.reconciled and aml.matching_number and aml.matching_number.startswith('P'))
            //     .mapped('matching_number')
            // )
            // self = self.filtered(lambda aml: not aml.reconciled or aml.matching_number not in not_reconciled_partial_matching_numbers)
            // 
            // if not self:
            //     return
            // 
            // if any(aml.reconciled for aml in self):
            //     raise UserError(_("You are trying to reconcile some entries that are already reconciled."))
            // if any(aml.parent_state == 'cancel' for aml in self):
            //     raise UserError(_("You can not reconcile cancelled entries."))
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
            // for line in self.filtered(lambda x: x.display_type not in ('line_section', 'line_subsection', 'line_note')):
            //     account = line.account_id
            //     journal = line.move_id.journal_id
            // 
            //     if not (account.active or line.is_imported or self.env.context.get('skip_account_deprecation_check')):
            //         raise UserError(_('The account %(name)s (%(code)s) is archived.', name=account.name, code=account.code))
            // 
            //     account_currency = account.currency_id
            //     if account_currency and account_currency != line.company_currency_id and account_currency != line.currency_id:
            //         raise UserError(_('The account selected on your journal entry forces to provide a secondary currency. You should remove the secondary currency on the account.'))
            // 
            //     if account in (journal.default_account_id, journal.suspense_account_id):
            //         continue
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
            // super(AccountMoveLine, self.filtered(lambda line: line.expense_id.payment_mode != 'company_account'))._check_payable_receivable()
            */
            return default;
        }

        protected async Task<AccountMoveLine> CheckReconciliationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _check_reconciliation(self):
            // for line in self.filtered(lambda x: x.parent_state == 'posted'):
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
            //                AND account.active = 't'
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
            //         )
            //         if account_id:
            //             line.account_id = account_id
            // for line in self:
            //     if not line.account_id and line.display_type not in ('line_section', 'line_subsection', 'line_note'):
            //         previous_two_accounts = line.move_id.line_ids.filtered(
            //             lambda l: l.account_id and l.display_type == line.display_type
            //         )[-2:].account_id
            //         if len(previous_two_accounts) == 1 and len(line.move_id.line_ids) > 2:
            //             line.account_id = previous_two_accounts
            //         else:
            //             line.account_id = line.move_id.journal_id.default_account_id
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move_line.py) ---
            // def _compute_account_id(self):
            // super()._compute_account_id()
            // for line in self:
            //     if not line.move_id.is_purchase_document():
            //         continue
            //     if not line._eligible_for_stock_account():
            //         continue
            //     fiscal_position = line.move_id.fiscal_position_id
            //     accounts = line.with_company(line.company_id).product_id.product_tmpl_id.get_product_accounts(fiscal_pos=fiscal_position)
            // 
            //     if line.product_id.valuation == 'real_time' and accounts['stock_valuation']:
            //         line.account_id = accounts['stock_valuation']
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeAllowedUomIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_allowed_uom_ids(self):
            // for line in self:
            //     line.allowed_uom_ids = line.product_id.uom_id | line.product_id.uom_ids
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
            //     if line.currency_id == line.company_id.currency_id and not line.move_id.is_invoice(True):
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
            //     self.env.cr.execute('''
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
            //             list({int(account_id) for ids in related_distribution for account_id in ids.split(',') if account_id.strip()})
            //         ).exists().root_plan_id
            // 
            //         arguments = frozendict(line._get_analytic_distribution_arguments(root_plans))
            //         if arguments not in cache:
            //             cache[arguments] = self.env['account.analytic.distribution.model']._get_distribution(arguments)
            //         line.analytic_distribution = related_distribution | cache[arguments] or line.analytic_distribution
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: account_move_line.py) ---
            // def _compute_analytic_distribution(self):
            // # when a project creates an aml, it adds an analytic account to it. the following filter is to save this
            // # analytic account from being overridden by analytic default rules and lack thereof
            // project_amls = self.filtered(lambda aml: aml.analytic_distribution and any(aml.sale_line_ids.project_id))
            // super(AccountMoveLine, self - project_amls)._compute_analytic_distribution()
            // project_id = self.env.context.get('project_id', False)
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
            //     if line.display_type in ('line_section', 'line_subsection', 'line_note'):
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
            // query = self._search(self.env.context.get('domain_cumulated_balance') or [], bypass_access=True)
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
            //         line.currency_rate = line.move_id.invoice_currency_rate or 1.0
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

        protected async Task<AccountMoveLine> ComputeHasInvalidAnalyticsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_has_invalid_analytics(self):
            // SKIPPED_ACCOUNT_TYPES = {'asset_receivable', 'liability_payable', 'asset_cash', 'liability_credit_card'}
            // lines_to_validate = self.filtered(lambda line: (
            //     line.display_type == 'product' and
            //     line.account_id.account_type not in SKIPPED_ACCOUNT_TYPES
            // ))
            // (self - lines_to_validate).has_invalid_analytics = False
            // for line in lines_to_validate:
            //     line.has_invalid_analytics = False
            //     try:
            //         business_domain = (
            //             'invoice' if line.move_id.is_sale_document(True)
            //             else 'bill' if line.move_id.is_purchase_document(True)
            //             else 'general'
            //         )
            //         line.with_context(validate_analytic=True)._validate_distribution(
            //             company_id=line.company_id.id,
            //             product=line.product_id.id,
            //             account=line.account_id.id,
            //             business_domain=business_domain,
            //         )
            //     except ValidationError:
            //         line.has_invalid_analytics = True
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
            //             # If we have both purchase and sale taxes on a line (which can happen in bank rec).
            //             # We choose invoice by default
            //             tax_type = line.tax_ids.mapped('type_tax_use')
            //             if 'sale' in tax_type and 'purchase' in tax_type:
            //                 is_refund = line.credit == 0
            //             else:
            //                 tax_type = line.tax_ids[:1].type_tax_use
            //                 if (tax_type == 'sale' and line.credit == 0) or (tax_type == 'purchase' and line.debit == 0):
            //                     is_refund = True
            // 
            //             if line.tax_ids and line.move_id.reversed_entry_id:
            //                 is_refund = not is_refund
            //     line.is_refund = is_refund
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeIsStornoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_is_storno(self):
            // for line in self:
            //     if not line.company_id.account_storno:
            //         continue
            //     line.is_storno = (line.is_storno or line.move_id.is_storno) and line.move_type not in ('in_invoice', 'out_invoice')
            // 
            //     # For invoice lines, we want to set is_storno based on the sign of the line if the entire move is not storno (not refund)
            //     # This allows setting is_storno to true or false depending on quantity and price_unit
            //     if not line.move_id.is_storno and line in line.move_id.invoice_line_ids and line.quantity * line.price_unit:
            //         line.is_storno = line.quantity * line.price_unit < 0
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move_line.py) ---
            // def _compute_is_storno(self):
            // # EXTENDS 'account'
            // super()._compute_is_storno()
            // for line in self:
            //     if line.is_downpayment:
            //         # Normal downpayments have a negative balance (credit on customer invoice)
            //         # Positive balance indicate reversal lines for previous downpayments,
            //         # which should be treated as storno line if storno accounting is enabled.
            //         line.is_storno = line.company_id.account_storno and line.balance > 0.0
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
            //         if name:
            //             line.name = name
            //     if not line.product_id or line.display_type in ('line_section', 'line_subsection', 'line_note'):
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

        protected async Task<AccountMoveLine> ComputeNoFollowupInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_no_followup(self):
            // for aml in self:
            //     aml.no_followup = aml.move_id.is_entry() and not aml.move_id.origin_payment_id
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeParentIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_parent_id(self):
            // parent_id_vals_to_lines = defaultdict(list)
            // for move, lines in self.grouped('move_id').items():
            //     if not move:
            //         parent_id_vals_to_lines[False].extend(lines._ids)
            //         continue
            //     last_section = False
            //     last_sub = False
            //     for line in move.line_ids.sorted('sequence'):
            //         value = False
            //         if line.display_type == 'line_section':
            //             last_section = line
            //             value = False
            //             last_sub = False
            //         elif line.display_type == 'line_subsection':
            //             value = last_section
            //             last_sub = line
            //         elif line.display_type in {'line_note', 'product'}:
            //             value = last_sub or last_section
            //         else:
            //             value = False
            //         parent_id_vals_to_lines[value].append(line.id)
            // 
            // for val, record_ids in parent_id_vals_to_lines.items():
            //     self.browse(record_ids).parent_id = val
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
            //     if not line.product_id or line.display_type in ('line_section', 'line_subsection', 'line_note') or line.is_imported:
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
            //         seller_ids = line.product_id.seller_ids._get_filtered_supplier(line.company_id, line.product_id, False)
            //         line.product_uom_id = seller_ids[:1].product_uom_id or line.product_id.uom_id
            //     else:
            //         line.product_uom_id = line.product_id.uom_id
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputePurchaseLineWarnMsgInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def _compute_purchase_line_warn_msg(self):
            // has_group = self.env.user.has_group('purchase.group_warning_purchase')
            // for line in self:
            //     line.purchase_line_warn_msg = line.product_id.purchase_line_warn_msg if has_group else ""
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

        protected async Task<AccountMoveLine> ComputeReconciledLinesExcludingExchangeDiffIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_reconciled_lines_excluding_exchange_diff_ids(self):
            // for line in self:
            //     all_lines = line.matched_debit_ids.debit_move_id + line.matched_credit_ids.credit_move_id
            //     excluded_ids = (
            //         line.matched_debit_ids.exchange_move_id.line_ids +
            //         line.matched_credit_ids.exchange_move_id.line_ids
            //     )
            //     line.reconciled_lines_excluding_exchange_diff_ids = all_lines - excluded_ids
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeReconciledLinesIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_reconciled_lines_ids(self):
            // for line in self:
            //     line.reconciled_lines_ids = line.matched_debit_ids.debit_move_id + line.matched_credit_ids.credit_move_id
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeSaleLineWarnMsgInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move_line.py) ---
            // def _compute_sale_line_warn_msg(self):
            // has_warning_group = self.env.user.has_group('sale.group_warning_sale')
            // for line in self:
            //     line.sale_line_warn_msg = line.product_id.sale_line_warn_msg if has_warning_group else ""
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
            //     if line.display_type in ('line_section', 'line_subsection', 'line_note', 'payment_term') or line.is_imported:
            //         continue
            //     # /!\ Don't remove existing taxes if there is no explicit taxes set on the account.
            //     if line.product_id or (line.display_type != 'discount' and (line.account_id.tax_ids or not line.tax_ids)):
            //         line.tax_ids = line._get_computed_taxes()
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
            //     if line.display_type not in ('product', 'cogs', 'non_deductible_product', 'non_deductible_product_total') or not line.move_id:
            //         line.price_total = line.price_subtotal = False
            //         continue
            // 
            //     company = line.company_id or self.env.company
            //     base_line = line.move_id._prepare_product_base_line_for_taxes_computation(line)
            //     AccountTax._add_tax_details_in_base_line(base_line, company)
            //     AccountTax._round_base_lines_tax_details([base_line], company)
            //     line.price_subtotal = base_line['tax_details']['total_excluded_currency']
            //     line.price_total = base_line['tax_details']['total_included_currency']
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

        protected async Task<AccountMoveLine> ConstrainsDeductibleAmountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _constrains_deductible_amount(self):
            // for line in self:
            //     if not line.move_id.is_purchase_document() and float_compare(line.deductible_amount, 100, precision_digits=2):
            //         raise ValidationError(_("Only vendor bills allow for deductibility of product/services."))
            //     if line.deductible_amount < 0 or line.deductible_amount > 100:
            //         raise ValidationError(_("The deductibility must be a value between 0 and 100."))
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
            //     if line.display_type in ('line_section', 'line_subsection', 'line_note'):
            //         del vals['balance']
            //         del vals['account_id']
            //     # Will be recomputed from the price_unit
            //     if line.display_type == 'product' and line.move_id.is_invoice(True):
            //         del vals['balance']
            //     if self.env.context.get('include_business_fields'):
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
            // super()._copy_data_extend_business_fields(values)
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
            // # early return to prevent endless recursive computation of reconcile plan
            // if not exchange_diff_values_list:
            //     return self.env['account.move']
            // 
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
            // # ==== Create the moves ====
            // exchange_moves = self.env['account.move'].with_context(no_exchange_difference=True).create(exchange_move_values_list)
            // # The reconciliation of exchange moves is now dealt thanks to the reconciled_lines_ids field
            // 
            // # ==== See if the exchange moves need to be posted or not ====
            // exchange_moves_to_post = self.env['account.move']
            // for exchange_move, vals in zip(exchange_moves, exchange_diff_values_list):
            //     if vals['to_post']:
            //         exchange_moves_to_post |= exchange_move
            // 
            // if exchange_moves_to_post:
            //     exchange_moves_to_post._post(soft=False)
            // 
            // return exchange_moves
            */
            return default;
        }

        public override async Task<AccountMoveLine> DefaultGetAsync(List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def default_get(self, fields):
            // defaults = super().default_get(fields)
            // quick_encode_suggestion = self.env.context.get('quick_encoding_vals')
            // if quick_encode_suggestion and self.env.context.get('default_display_type') not in ('line_section', 'line_subsection', 'line_note'):
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

        protected async Task<AccountMoveLine> EligibleForStockAccountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move_line.py) ---
            // def _eligible_for_stock_account(self):
            // self.ensure_one()
            // if not self.product_id.is_storable:
            //     return False
            // moves = self._get_stock_moves()
            // return all(not m.is_dropship for m in moves)
            --- ODOO METHOD SOURCE (MODULE: stock_landed_costs, FILE: account_move.py) ---
            // def _eligible_for_stock_account(self):
            // return super()._eligible_for_stock_account() or (
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

        protected async Task<object> FieldToSqlInternalAsync(string @alias, string field_expr, object query)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _field_to_sql(self, alias: str, field_expr: str, query: (Query | None) = None) -> SQL:
            // fname, property_name = fields.parse_field_expr(field_expr)
            // if fname != 'payment_date':
            //     return super()._field_to_sql(alias, field_expr, query)
            // sql = SQL("""
            //     CASE
            //          WHEN %(discount_date)s >= %(today)s THEN %(discount_date)s
            //          ELSE %(date_maturity)s
            //     END""",
            //     today=fields.Date.context_today(self),
            //     discount_date=super()._field_to_sql(alias, "discount_date", query),
            //     date_maturity=super()._field_to_sql(alias, "date_maturity", query),
            // )
            // if property_name:
            //     sql = self._field[fname].property_to_sql(sql, property_name, self, alias, query)
            // return sql
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
            // # We ignore Import matching numbers as they are not truly reconciled yet
            // matching_numbers = [n for n in set(self.mapped('matching_number')) if n and not n.startswith('I')]
            // 
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

        protected async Task<AccountMoveLine> GetAmlValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_aml_values(self, **kwargs):
            // self.ensure_one()
            // return {
            //     'name': self.name,
            //     'account_id': self.account_id.id,
            //     'currency_id': self.currency_id.id,
            //     'amount_currency': self.amount_currency,
            //     'balance': self.balance,
            //     'reconcile_model_id': self.reconcile_model_id.id,
            //     'analytic_distribution': self.analytic_distribution,
            //     'tax_repartition_line_id': self.tax_repartition_line_id.id,
            //     'tax_ids': [Command.set(self.tax_ids.ids)] + kwargs.pop('tax_ids', []),
            //     'tax_tag_ids': [Command.set(self.tax_tag_ids.ids)],
            //     'group_tax_id': self.group_tax_id.id,
            //     'partner_id': self.partner_id.id,
            //     **kwargs,
            // }
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetAnalyticDistributionArgumentsInternalAsync(object root_plans)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_analytic_distribution_arguments(self, root_plans):
            // """
            // Get arguments to determine analytic distribution.
            // This function aims to be overridden by partner submodules
            // :param root_plans: account.analytic.plan recordset
            // :return: dict
            // """
            // arguments = {
            //     "product_id": self.product_id.id,
            //     "product_categ_id": self.product_id.categ_id.id,
            //     "partner_id": self.partner_id.id,
            //     "partner_category_id": self.partner_id.category_id.ids,
            //     "account_prefix": self.account_id.code,
            //     "company_id": self.company_id.id,
            //     "related_root_plan_ids": root_plans,
            // }
            // return arguments
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

        protected async Task<AccountMoveLine> GetAttachmentByRecordInternalAsync(object id_model2attachments, object move_line)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_attachment_by_record(self, id_model2attachments, move_line):
            // return (
            //     id_model2attachments.get(('account.move', move_line.move_id.id))
            //     or id_model2attachments.get(('account.bank.statement', move_line.statement_id.id))
            //     or id_model2attachments.get(('account.payment', move_line.payment_id.id))
            // )
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: account_move_line.py) ---
            // def _get_attachment_by_record(self, id_model2attachments, move_line):
            // return (
            //     super()._get_attachment_by_record(id_model2attachments, move_line)
            //     or id_model2attachments.get(('hr.expense', move_line.expense_id.id))
            // )
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetAttachmentDomainsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_attachment_domains(self):
            // domains = [[
            //     ('res_model', '=', 'account.move'),
            //     ('res_id', 'in', self.move_id.ids),
            //     ('res_field', 'in', (False, 'invoice_pdf_report_file')),
            // ]]
            // if self.statement_id:
            //     domains.append([('res_model', '=', 'account.bank.statement'), ('res_id', 'in', self.statement_id.ids)])
            // if self.payment_id:
            //     domains.append([('res_model', '=', 'account.payment'), ('res_id', 'in', self.payment_id.ids)])
            // return domains
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: account_move_line.py) ---
            // def _get_attachment_domains(self):
            // attachment_domains = super(AccountMoveLine, self)._get_attachment_domains()
            // if self.expense_id:
            //     attachment_domains.append([('res_model', '=', 'hr.expense'), ('res_id', 'in', self.expense_id.ids)])
            // return attachment_domains
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetChildLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_child_lines(self):
            // """
            // Return a tax-wise summary of account move lines linked to section.
            // Groups lines by their tax IDs and computes subtotal and total for each group.
            // """
            // self.ensure_one()
            // 
            // section_lines = self.move_id.invoice_line_ids.filtered(lambda l: (l.parent_id == self or l.parent_id.parent_id == self))
            // result = []
            // for taxes, lines_for_tax_group in groupby(section_lines, key=lambda l: l.tax_ids):
            //     lines_for_tax_group = sum(lines_for_tax_group, start=self.env['account.move.line'])
            //     tax_labels = [tax.tax_label for tax in taxes if tax.tax_label]
            //     for section_line, move_lines in lines_for_tax_group.sorted('sequence').grouped('parent_id').items():
            //         lines_to_sum = move_lines if section_line != self else lines_for_tax_group
            //         subtotal = sum(l.price_subtotal for l in lines_to_sum)
            //         total = sum(l.price_total for l in lines_to_sum)
            //         if not subtotal and not tax_labels:
            //             continue
            //         elif section_line.collapse_composition or section_line.parent_id.collapse_composition:
            //             result.append({
            //                 'name': section_line.name,
            //                 'taxes': tax_labels if not section_line.parent_id.collapse_prices else [],
            //                 'price_subtotal': subtotal,
            //                 'price_total': total,
            //                 'display_type': 'product',
            //                 'quantity': 1,
            //                 'line_uom': False,
            //                 'product_uom': False,
            //                 'discount': 0.0,
            //             })
            //         else:
            //             for line in (section_line | move_lines):
            //                 result.append({
            //                     'name': line.name,
            //                     'taxes': tax_labels if line == self else [],
            //                     'price_subtotal': subtotal if line == section_line else line.price_subtotal,
            //                     'price_total': total if line == section_line else line.price_total,
            //                     'display_type': line.display_type,
            //                     'quantity': line.quantity,
            //                     'line_uom': line.product_uom_id,
            //                     'product_uom': line.product_id.uom_id,
            //                     'discount': line.discount,
            //                 })
            // 
            // return result or [{
            //     'name': self.name,
            //     'taxes': [],
            //     'price_subtotal': 0.0,
            //     'price_total': 0.0,
            //     'quantity': 0,
            //     'display_type': 'product',
            // }]
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetCogsValueInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: account_move.py) ---
            // def _get_cogs_value(self):
            // self.ensure_one()
            // if not self.product_id:
            //     return self.price_unit
            // price_unit = super()._get_cogs_value()
            // sudo_order = self.move_id.sudo().pos_order_ids
            // if sudo_order:
            //     price_unit = sudo_order._get_pos_anglo_saxon_price_unit(self.product_id, self.move_id.partner_id.id, self.quantity)
            // return price_unit
            --- ODOO METHOD SOURCE (MODULE: sale_mrp, FILE: account_move.py) ---
            // def _get_cogs_value(self):
            // price_unit = super()._get_cogs_value()
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
            //         account_moves = so_line.invoice_lines.move_id.filtered(lambda m: m.state == 'posted' and bool(m.reversed_entry_id) == is_line_reversing)
            //         posted_invoice_lines = account_moves.line_ids.filtered(lambda l: l.display_type == 'cogs' and l.product_id == self.product_id and l.balance > 0)
            //         qty_invoiced = sum([x.product_uom_id._compute_quantity(x.quantity, x.product_id.uom_id) for x in posted_invoice_lines])
            //         reversal_cogs = posted_invoice_lines.move_id.reversal_move_ids.line_ids.filtered(lambda l: l.display_type == 'cogs' and l.product_id == self.product_id and l.balance > 0)
            //         qty_invoiced -= sum([line.product_uom_id._compute_quantity(line.quantity, line.product_id.uom_id) for line in reversal_cogs])
            // 
            //         moves = so_line.move_ids
            //         average_price_unit = 0
            //         # Components quantities for 1 'unit' in the product's base uom
            //         components_qty = so_line._get_bom_component_qty(bom)
            //         storable_components = self.env['product.product'].search([('id', 'in', list(components_qty.keys())), ('is_storable', '=', True)])
            //         for product in storable_components:
            //             factor = components_qty[product.id]['qty']
            //             prod_moves = moves.filtered(lambda m: m.product_id == product)
            //             product = product.with_company(self.company_id)
            //             average_price_unit += factor * prod_moves._get_price_unit()
            //         price_unit = average_price_unit / bom.product_qty or price_unit
            // return price_unit
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move_line.py) ---
            // def _get_cogs_value(self):
            // """ Get the COGS price unit in the product's default unit of measure.
            // """
            // self.ensure_one()
            // 
            // if not self.product_id:
            //     return self.price_unit
            // 
            // original_line = self.move_id.reversed_entry_id.line_ids.filtered(
            //     lambda l: l.display_type == 'cogs' and l.product_id == self.product_id and
            //     l.product_uom_id == self.product_uom_id and l.price_unit >= 0)
            // original_line = original_line and original_line[0]
            // if original_line:
            //     return original_line.price_unit
            // 
            // if self.product_id.cost_method in ['standard', 'average']:
            //     return self.product_id.standard_price
            // 
            // # FIFO
            // moves = self._get_stock_moves().filtered(lambda m: m.state == 'done')
            // if not moves:
            //     return self.product_id._run_fifo(self.quantity)
            // 
            // price_unit = moves._get_price_unit()
            // valuation_account = self.product_id.product_tmpl_id.get_product_accounts(fiscal_pos=self.move_id.fiscal_position_id)['stock_valuation']
            // posted_cogs_value = - sum(self.sale_line_ids.order_id.invoice_ids.line_ids.filtered(
            //     lambda line: line.product_id == self.product_id and line.display_type == 'cogs' and line.account_id == valuation_account
            // ).mapped('balance'))
            // posted_cogs_qty = sum(self.sale_line_ids.order_id.invoice_ids.line_ids.filtered(
            //     lambda line: line.product_id == self.product_id and line.display_type == 'cogs' and line.account_id == valuation_account
            // ).mapped('quantity'))
            // total_qty = posted_cogs_qty + self.quantity
            // return (price_unit * total_qty - posted_cogs_value) / self.quantity
            */
            return default;
        }

        public async Task<AccountMoveLine> GetColumnToExcludeForColspanCalculationAsync(Guid id, AccountMoveLineGetColumnToExcludeForColspanCalculationRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def get_column_to_exclude_for_colspan_calculation(self, taxes=None):
            // return False
            */
            var entity = await Repository.GetAsync(id); return entity;
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
            // elif self.env.context.get('account_default_taxes'):
            //     tax_ids = self.account_id.tax_ids
            // 
            // else:
            //     tax_ids = False if self.env.context.get('skip_computed_taxes') or self.move_id.is_entry() else self.account_id.tax_ids
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

        protected async Task<AccountMoveLine> GetDefaultReadFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_default_read_fields(self):
            // weirdos = {'term_key', 'epd_key', 'epd_needed', 'discount_allocation_key', 'discount_allocation_needed'}
            // return [fname for fname in self.fields_get(attributes=()) if fname not in weirdos]
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
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetExchangeJournalInternalAsync(object company)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_exchange_journal(self, company):
            // return company.currency_exchange_journal_id
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
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move_line.py) ---
            // def _get_gross_unit_price(self):
            // if self.product_uom_id.is_zero(self.quantity):
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
            // term_lines = self.sorted(key=lambda line: (line.date_maturity or date.max, line.date))
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
            // hash_version = self.env.context.get('hash_version', MAX_HASH_VERSION)
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
            // return name if not display_name or display_name in name else f"{display_name}\n{name}"
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

        protected async Task<AccountMoveLine> GetMatchedMoveIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_matched_move_ids(self):
            // """ Return a record set with both self.matched_debit_ids & self.matched_credit_ids """
            // return self.matched_debit_ids | self.matched_credit_ids
            */
            return default;
        }

        public async Task<AccountMoveLine> GetParentSectionLineAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def get_parent_section_line(self):
            // if self.display_type == 'product' and self.parent_id.display_type == 'line_subsection':
            //     return self.parent_id.parent_id
            // 
            // return self.parent_id
            */
            var entity = await Repository.GetAsync(id); return entity;
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
            //     components_cost = sum(subcontract_production.move_raw_ids.mapped('value'))
            //     qty = sum(mo.product_uom_id._compute_quantity(mo.qty_producing, self.product_uom_id) for mo in subcontract_production if mo.state == 'done')
            //     if not self.product_uom_id.is_zero(qty):
            //         price_unit_val_dif = price_unit_val_dif + components_cost / qty
            // return price_unit_val_dif, relevant_qty
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: account_move_line.py) ---
            // def _get_price_unit_val_dif_and_relevant_qty(self):
            // self.ensure_one()
            // 
            // # Valuation_price unit is always expressed in invoice currency, so that it can always be computed with the good rate
            // valuation_price_unit = self.product_id.uom_id._compute_price(self.product_id.standard_price, self.product_uom_id)
            // valuation_price_unit = -valuation_price_unit if self.move_id.move_type == 'in_refund' else valuation_price_unit
            // 
            // price_unit = self._get_gross_unit_price()
            // 
            // price_unit_val_dif = price_unit - valuation_price_unit
            // # If there are some valued moves, we only consider their quantity already used
            // relevant_qty = self.quantity
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
            //         'uomDisplayName': len(self) == 1 and self.product_uom_id.display_name or self.product_id.uom_id.display_name,
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
            // query = self.env['account.move.line']._search(domain)
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
            //                 (tax.analytic IS NOT TRUE AND tax_rep.use_in_tax_closing IS TRUE)
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

        protected async Task<AccountMoveLine> GetSectionLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_section_lines(self):
            // self.ensure_one()
            // return self.move_id.invoice_line_ids.filtered(self._is_line_in_section)
            */
            return default;
        }

        public async Task<AccountMoveLine> GetSectionSubtotalAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def get_section_subtotal(self):
            // section_lines = self._get_section_lines()
            // return sum(section_lines.mapped('price_subtotal'))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMoveLine> GetSoMappingDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: account_move_line.py) ---
            // def _get_so_mapping_domain(self):
            // return Domain.OR(
            //     Domain.AND(
            //         Domain(self.env['account.analytic.account'].browse(int(account_id)).root_plan_id._column_name(), "=", int(account_id))
            //         for account_id in key.split(",")
            //     )
            //     for line in self
            //     for key in line.analytic_distribution or []
            // )
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

        protected async Task<AccountMoveLine> GetStockMovesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: account_move_line.py) ---
            // def _get_stock_moves(self):
            // moves = super()._get_stock_moves()
            // finished_moves = set()
            // for m in moves:
            //     if mo := m._get_subcontract_production():
            //         finished_moves.add(mo.move_finished_ids.filtered(lambda mf: mf.product_id == m.product_id).id)
            // return moves | self.env['stock.move'].browse(finished_moves)
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: account_move_line.py) ---
            // def _get_stock_moves(self):
            // return super()._get_stock_moves() | self.purchase_line_id.move_ids
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: account_move.py) ---
            // def _get_stock_moves(self):
            // return super()._get_stock_moves() | self.sale_line_ids.move_ids
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move_line.py) ---
            // def _get_stock_moves(self):
            // return self.env['stock.move']
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
            // return Domain([
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
            // ])
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
            // old_distributions = dict(self.env.execute_query(SQL(
            //     "SELECT id, analytic_distribution FROM account_move_line WHERE id = ANY(%s)",
            //     self.ids,
            // )))
            // for line in self:
            //     line.analytic_distribution = self._merge_distribution(
            //         old_distribution=old_distributions.get(line._origin.id) or {},
            //         new_distribution=line.analytic_distribution or {},
            //     )
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
            //     line.is_storno = line.credit < 0
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
            //     line.is_storno = line.debit < 0
            //     if line.debit:
            //         line.credit = 0
            //     line.balance = line.debit - line.credit
            */
            return default;
        }

        protected async Task<AccountMoveLine> InverseNoFollowupInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _inverse_no_followup(self):
            // # If one line of an invoice gets excluded from or included in the follow up report, we want all
            // # payable/receivable lines of that invoice to do the same.
            // for aml in self:
            //     move = aml.move_id
            //     if move.is_invoice():
            //         move.no_followup = aml.no_followup
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
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move_line.py) ---
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

        protected async Task<AccountMoveLine> InverseReconciledLinesIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _inverse_reconciled_lines_ids(self):
            // self._reconcile_plan([
            //     line + line.reconciled_lines_ids
            //     for line in self
            // ])
            */
            return default;
        }

        protected async Task<AccountMoveLine> IsLineInSectionInternalAsync(object line)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _is_line_in_section(self, line):
            // """Return whether the line is a direct or indirect child of the section."""
            // self.ensure_one()
            // is_direct_child = line.parent_id == self
            // is_indirect_child = (
            //     self.display_type == 'line_section'
            //     and line.parent_id
            //     and line.parent_id.display_type == 'line_subsection'
            //     and line.parent_id.parent_id == self
            // )
            // return is_direct_child or is_indirect_child
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
            //     if self.env.context.get('reduced_line_sorting'):
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
            //     'user_id': self.move_id.invoice_user_id.id or self.env.uid,
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
            //         if not self.company_currency_id.is_zero(line_values.get('amount')):
            //             analytic_line_vals.append(line_values)
            // 
            //     self._round_analytic_distribution_line(analytic_line_vals)
            // return analytic_line_vals
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move_line.py) ---
            // def _prepare_analytic_lines(self):
            // """ Note: This method is called only on the move.line that having an analytic distribution, and
            //     so that should create analytic entries.
            // """
            // values_list = super()._prepare_analytic_lines()
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
            //     if res_vals['display_type'] in ('line_section', 'line_subsection', 'line_note'):
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
            // for line, amounts in zip(self, amounts_list):
            // 
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
            //             'reconciled_lines_ids': [Command.set(line.ids)],
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
            //         'product_uom_id': line.product_uom_id.id,
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
            //     if forced_rate := self.env.context.get('forced_rate_from_register_payment'):
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
            //     if len(remaining_amls.mapped('partner_id')) > 1:
            //         remaining_amls = remaining_amls.sorted(lambda aml: (aml.partner_id and aml.partner_id.id) or False)
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
            //         partial_amount = min(remaining_debit_amount, -remaining_credit_amount)
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
            // if not self.env.context.get('no_exchange_difference') and not self.env.context.get('no_exchange_difference_no_recursive'):
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
            //         res['exchange_values']['to_post'] = debit_aml.parent_state == 'posted' and credit_aml.parent_state == 'posted'
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
            // context = dict(self.env.context or {})
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
            //         'parent_state': aml.parent_state,
            //     }
            //     for aml in all_amls
            // }
            // 
            // # ==== Prepare the partials ====
            // partials_values_list = []
            // exchange_diff_values_list = []
            // all_plan_results = []
            // for plan in plan_list:
            //     plan_results = self\
            //         .with_context(
            //             no_exchange_difference=self.env.context.get('no_exchange_difference'),
            //             no_exchange_difference_no_recursive=self.env.context.get('no_exchange_difference_no_recursive', False),
            //         )\
            //         ._prepare_reconciliation_plan(plan, aml_values_map)
            //     all_plan_results.append(plan_results)
            //     for results in plan_results:
            //         partials_values_list.append(results['partial_values'])
            //         if results.get('exchange_values') and results['exchange_values']['move_values']['line_ids']:
            //             exchange_diff_values_list.append(results['exchange_values'])
            // 
            // # ==== Create the partials ====
            // # Link the newly created partials to the plan. There are needed later for caba exchange entries.
            // partials = self.env['account.partial.reconcile'].create(partials_values_list)
            // if self.env.context.get('add_caba_vals'):
            //     partials._set_draft_caba_move_vals()
            // start_range = 0
            // for plan_results, plan in zip(all_plan_results, plan_list):
            //     size = len(plan_results)
            //     plan['partials'] = partials[start_range:start_range + size]
            //     start_range += size
            // 
            // # ==== Create the partial exchange journal entries ====
            // exchange_moves = self._create_exchange_difference_moves(exchange_diff_values_list)
            // used_exchange_moves = set()
            // used_partials = set()
            // 
            // for partial in partials:
            //     for exchange_move in exchange_moves:
            //         linked_move_lines = exchange_move.line_ids.reconciled_lines_ids
            // 
            //         if (
            //             any(line == partial.debit_move_id or line == partial.credit_move_id for line in linked_move_lines)
            //             and exchange_move not in used_exchange_moves
            //             and partial not in used_partials
            //         ):
            //             partial.exchange_move_id = exchange_move
            //             used_exchange_moves.add(exchange_move)
            //             used_partials.add(partial)
            // 
            // # ==== Create entries for cash basis taxes ====
            // def is_cash_basis_needed(amls):
            //     return any(amls.company_id.mapped('tax_exigibility')) \
            //         and amls.account_id.account_type in ('asset_receivable', 'liability_payable')
            // 
            // if not self.env.context.get('move_reverse_cancel') and not self.env.context.get('no_cash_basis'):
            //     for plan in plan_list:
            //         if is_cash_basis_needed(plan['amls']):
            //             plan['partials'].with_context(no_exchange_difference_no_recursive=False)._create_tax_cash_basis_moves()
            //             plan['partials']._set_draft_caba_move_vals()
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
            //     for (_dummy, account, repartition_line), amls_to_reconcile in caba_lines_to_reconcile.items():
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
            //     return {number: lines.with_env(self.env) for number, lines in self.sudo()._read_group(
            //         domain=[('matching_number', 'in', matching_numbers)],
            //         groupby=['matching_number'],
            //         aggregates=['id:recordset'],
            //     )}
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

        protected async Task<AccountMoveLine> RoundAnalyticDistributionLineInternalAsync(object analytic_lines_vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _round_analytic_distribution_line(self, analytic_lines_vals):
            // """ Round the analytic lines amount, and cancel the rounding error. """
            // if not analytic_lines_vals:
            //     return
            // 
            // rounding_error = 0
            // for line in analytic_lines_vals:
            //     rounded_amount = self.company_currency_id.round(line['amount'])
            //     rounding_error += rounded_amount - line['amount']
            //     line['amount'] = rounded_amount
            // 
            // # distributing the rounding error
            // for line in analytic_lines_vals:
            //     if self.company_currency_id.is_zero(rounding_error):
            //         break
            //     amt = max(
            //         self.company_currency_id.rounding,
            //         abs(self.company_currency_id.round(rounding_error / len(analytic_lines_vals)))
            //     )
            //     if rounding_error < 0.0:
            //         line['amount'] += amt
            //         rounding_error += amt
            //     else:
            //         line['amount'] -= amt
            //         rounding_error -= amt
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
            // uom_precision_digits = self.env['decimal.precision'].precision_get('Product Unit')
            // return float_compare(self.credit or 0.0, self.debit or 0.0, precision_digits=uom_precision_digits) != 1 and self.product_id.expense_policy not in [False, 'no']
            --- ODOO METHOD SOURCE (MODULE: sale_expense, FILE: account_move_line.py) ---
            // def _sale_can_be_reinvoice(self):
            // """ determine if the generated analytic line should be reinvoiced or not.
            //     For Expense flow, if the product has a 'reinvoice policy' and a Sales Order is set on the expense, then we will reinvoice the AAL
            // """
            // self.ensure_one()
            // if self.expense_id:  # expense flow is different from vendor bill reinvoice flow
            //     return (
            //         self.expense_id.product_id.expense_policy in {'sales_price', 'cost'}
            //         and self.expense_id.sale_order_id
            //         and self.display_type == 'product'
            //     )
            // return super()._sale_can_be_reinvoice()
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: account_move.py) ---
            // def _sale_can_be_reinvoice(self):
            // self.ensure_one()
            // return self.move_type != 'entry' and self.display_type != 'cogs' and super()._sale_can_be_reinvoice()
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
            // # EXTENDS sale
            // # We force each reinvoiced expense to be on their own sale order line,
            // # else we cannot properly edit the quantities if the user manually override anything
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
            // # EXTENDS sale
            // # For move lines created from expense, we override the normal behavior.
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
            // uom_precision_digits = self.env['decimal.precision'].precision_get('Product Unit')
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
            //     'tax_ids': [x.id for x in taxes],
            //     'discount': 0.0,
            //     'product_id': self.product_id.id,
            //     'product_uom_id': self.product_uom_id.id,
            //     'product_uom_qty': self.quantity,
            //     'is_expense': True,
            //     'analytic_distribution': self.analytic_distribution,
            // }
            --- ODOO METHOD SOURCE (MODULE: sale_expense, FILE: account_move_line.py) ---
            // def _sale_prepare_sale_line_values(self, order, price):
            // # EXTENDS sale
            // # Add expense quantity to sales order line and update the sales order price because it will be charged to the customer in the end.
            // res = super()._sale_prepare_sale_line_values(order, price)
            // if self.expense_id:
            //     res.update({
            //         'name': self.name,
            //         'expense_ids': [Command.set(self.expense_id.ids)],
            //         'product_uom_qty': self.expense_id.quantity,
            //         'analytic_distribution': self.analytic_distribution,
            //     })
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
            // 
            //     # This is used for negative amounts in debit/credit for manual inputs (to stay in same debit/credit as input)
            //     if vals.get('move_id') and self.env['account.move'].browse(vals['move_id']).company_id.account_storno:
            //         vals['is_storno'] = vals.get('is_storno', False) or (vals.get('debit', 0) < 0 or vals.get('credit', 0) < 0)
            // 
            //     debit = vals.pop('debit', 0)
            //     credit = vals.pop('credit', 0)
            //     if 'balance' not in vals:
            //         vals['balance'] = debit - credit
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

        protected async Task<AccountMoveLine> SearchAccountIdInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _search_account_id(self, operator, value):
            // """
            // Search method that can be a drop-in replacement for searching on `account_id`.
            // Resolves the domain and inlines the resulting ids to yield better final queries
            // and avoids joining on the `account.account` model.
            // This should be a net positive on average, under the assertion that the cardinality of
            // `account.account` doesn't grow too large. (e.g. <10k rows)
            // """
            // if (
            //     operator in ('in', 'not in', 'any', 'not any')
            //     and not isinstance(value, (tuple, list, OrderedSet))
            // ):
            //     if operator in ('any', 'not any'):
            //         operator = {'any': 'in', 'not any': 'not in'}[operator]
            // 
            //     if isinstance(value, (Query, SQL)):
            //         query_value = value.select() if isinstance(value, Query) else value
            //         value = [row[0] for row in self.env.execute_query(query_value)]
            //     else:  # isinstance(value, Domain) is True
            //         # sudo reason: ignore ir.rules, `account_id` is with `bypass_search_access=True`
            //         value = self.env['account.account'].sudo()._search(value).get_result_ids()
            // 
            // return [('account_id', operator, value)]
            */
            return default;
        }

        public async Task<AccountMoveLine> SearchFetchAsync(Guid id, AccountMoveLineSearchFetchRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def search_fetch(self, domain, field_names=None, offset=0, limit=None, order=None):
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
            // return self.env['account.move']._search_journal_group_id(operator, value)
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
            // domain = Domain(domain)
            // if domain.is_false():
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
            // if operator == 'in':
            //     # recursive call with operator '='
            //     return Domain.OR(self._search_payment_date('=', v) for v in value)
            // if operator in Domain.NEGATIVE_OPERATORS:
            //     return NotImplemented
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
            //         (changed('balance') or changed('move_type'))
            //          and not self.env.is_protected(self._fields['amount_currency'], line)
            //          and (not changed('amount_currency') or (line not in before and not line.amount_currency))
            //          and line.currency_id == line.company_id.currency_id
            //     ):
            //         line.amount_currency = line.balance
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
            // self.remove_move_reconcile()
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
            // if not self.env.context.get('force_delete') and any(m.state == 'posted' for m in self.move_id):
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
            // active_ids = self.env.context.get('active_ids')
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
            //         if line.balance else 100
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

        protected async Task<AccountMoveLine> WhereCalcInternalAsync(object domain, object active_test)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: accounting_pdf_reports, FILE: account_move_line.py) ---
            // def _where_calc(self, domain, active_test=True):
            // """Computes the WHERE clause needed to implement an OpenERP domain.
            // 
            // :param list domain: the domain to compute
            // :param bool active_test: whether the default filtering of records with
            //     ``active`` field set to ``False`` should be applied.
            // :return: the query expressing the given domain as provided in domain
            // :rtype: Query
            // """
            // # if the object has an active field ('active', 'x_active'), filter out all
            // # inactive records unless they were explicitly asked for
            // if self._active_name and active_test and self.env.context.get('active_test', True):
            //     # the item[0] trick below works for domain items and '&'/'|'/'!'
            //     # operators too
            //     if not any(item[0] == self._active_name for item in domain):
            //         domain = [(self._active_name, '=', 1)] + domain
            // 
            // if domain:
            //     return expression.expression(domain, self).query
            // else:
            //     return Query(self.env, self._table, self._table_sql)
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
            // # Check writing a archived account.
            // if account_to_write and not account_to_write.active:
            //     raise UserError(_('You cannot use an archived account.'))
            // 
            // inalterable_fields = set(self._get_integrity_hash_fields()).union({'inalterable_hash'})
            // hashed_moves = self.move_id.filtered('inalterable_hash')
            // violated_fields = set(vals) & inalterable_fields
            // if hashed_moves and violated_fields:
            //     raise UserError(_(
            //         "You cannot edit the following fields: %(fields)s.\n"
            //         "The following entries are already hashed:\n%(entries)s",
            //         fields=[f['string'] for f in self.fields_get(violated_fields).values()],
            //         entries='\n'.join(hashed_moves.mapped('name')),
            //     ))
            // 
            // line_to_write = self
            // vals = self._sanitize_vals(vals)
            // matching2lines = None  # lazy cache
            // lines_to_unreconcile = self.env['account.move.line']
            // st_lines_to_unreconcile = self.env['account.bank.statement.line']
            // tax_lock_check_ids = []
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
            //         tax_lock_check_ids.append(line.id)
            // 
            //     # Break the reconciliation.
            //     if (
            //         line.matching_number
            //         and (changing_fields := {
            //             field_name
            //             for field_name in protected_fields['reconciliation']
            //             if self.env['account.move']._field_will_change(line, vals, field_name)
            //         })
            //     ):
            //         matching2lines = self._reconciled_by_number() if matching2lines is None else matching2lines
            //         if (
            //             # allow changing the account on all the lines of a reconciliation together
            //             changing_fields - {'account_id'}
            //             or not all(reconciled_line in self for reconciled_line in matching2lines[line.matching_number])
            //         ):
            //             lines_to_unreconcile += line
            //             st_lines_to_unreconcile += (line.matched_debit_ids.debit_move_id + line.matched_credit_ids.credit_move_id).statement_line_id
            // 
            // lines_to_unreconcile.remove_move_reconcile()
            // for st_line in st_lines_to_unreconcile:
            //     try:
            //         st_line.move_id._check_fiscal_lock_dates()
            //         st_line.move_id.line_ids._check_tax_lock_date()
            //     except UserError:
            //         st_lines_to_unreconcile -= st_line
            // st_lines_to_unreconcile.action_undo_reconciliation()
            // 
            // self.browse(tax_lock_check_ids)._check_tax_lock_date()
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
            //     # double check modified lines in case a tax field was changed on a line that didn't previously affect tax
            //     self.browse(tax_lock_check_ids)._check_tax_lock_date()
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
            //     if 'analytic_line_ids' in vals:
            //         self.filtered(lambda l: l.parent_state == 'draft').analytic_line_ids.with_context(skip_analytic_sync=True).unlink()
            // 
            // return result
            --- ODOO METHOD SOURCE (MODULE: account_fleet, FILE: account_move.py) ---
            // def write(self, vals):
            // if 'vehicle_id' in vals and not vals['vehicle_id']:
            //     self.sudo().vehicle_log_service_ids.with_context(ignore_linked_bill_constraint=True).unlink()
            // return super().write(vals)
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}