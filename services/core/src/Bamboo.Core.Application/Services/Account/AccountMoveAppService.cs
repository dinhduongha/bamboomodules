using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Bamboo.Core.Application.Services
{
    [Module("Account", Depends = new[] { "base_setup", "onboarding", "product", "analytic", "portal", "digest" })]
    public class AccountMoveAppService : GenericApplicationService<AccountMove>, IAccountMoveAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadMainAttachmentAppService _mailThreadMainAttachmentAppService;
        private readonly IPortalMixinAppService _portalMixinAppService;
        private readonly IProductCatalogMixinAppService _productCatalogMixinAppService;
        private readonly ISequenceMixinAppService _sequenceMixinAppService;
        private readonly IUtmMixinAppService _utmMixinAppService;
        public AccountMoveAppService(IRepository<AccountMove, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadMainAttachmentAppService mailThreadMainAttachmentAppService, IPortalMixinAppService portalMixinAppService, IProductCatalogMixinAppService productCatalogMixinAppService, ISequenceMixinAppService sequenceMixinAppService, IUtmMixinAppService utmMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadMainAttachmentAppService = mailThreadMainAttachmentAppService;
            _portalMixinAppService = portalMixinAppService;
            _productCatalogMixinAppService = productCatalogMixinAppService;
            _sequenceMixinAppService = sequenceMixinAppService;
            _utmMixinAppService = utmMixinAppService;
        }

        protected async Task<AccountMove> ActionInvoiceReadyToBeSentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _action_invoice_ready_to_be_sent(self):
            // """ Hook allowing custom code when an invoice becomes ready to be sent by mail to the customer.
            // For example, when an EDI document must be sent to the government and be signed by it.
            // """
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move.py) ---
            // def _action_invoice_ready_to_be_sent(self):
            // # OVERRIDE
            // # Make sure the send invoice CRON is called when an invoice becomes ready to be sent by mail.
            // res = super()._action_invoice_ready_to_be_sent()
            // 
            // send_invoice_cron = self.env.ref('sale.send_invoice_cron', raise_if_not_found=False)
            // if send_invoice_cron:
            //     send_invoice_cron._trigger()
            // 
            // return res
            */
            return default;
        }

        public async Task<AccountMove> ActivateCurrencyAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_activate_currency(self):
            // self.currency_id.filtered(lambda currency: not currency.active).write({'active': True})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> AddFromCatalogAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_add_from_catalog(self):
            // res = super().action_add_from_catalog()
            // if res['context'].get('product_catalog_order_model') == 'account.move':
            //     res['search_view_id'] = [self.env.ref('account.product_view_search_catalog').id, 'search']
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> AddPurchaseOrderLinesInternalAsync(object purchase_order_lines)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def _add_purchase_order_lines(self, purchase_order_lines):
            // """ Creates new invoice lines from purchase order lines """
            // self.ensure_one()
            // new_line_ids = self.env['account.move.line']
            // 
            // for po_line in purchase_order_lines:
            //     new_line_values = po_line._prepare_account_move_line(self)
            //     new_line_ids += self.env['account.move.line'].new(new_line_values)
            // 
            // self.invoice_line_ids += new_line_ids
            */
            return default;
        }

        protected async Task<AccountMove> AffectTaxReportInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _affect_tax_report(self):
            // return any(line._affect_tax_report() for line in (self.line_ids | self.invoice_line_ids))
            */
            return default;
        }

        protected async Task<AccountMove> ApplyDeltaRecurringEntriesInternalAsync(object date, object date_origin, object period)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _apply_delta_recurring_entries(self, date, date_origin, period):
            // '''Advances date by `period` months, maintaining original day of the month if possible.'''
            // deltas = {'monthly': 1, 'quarterly': 3, 'yearly': 12}
            // prev_months = (date.year - date_origin.year) * 12 + date.month - date_origin.month
            // return date_origin + relativedelta(months=deltas[period] + prev_months)
            */
            return default;
        }

        protected async Task<AccountMove> AutoInitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _auto_init(self):
            // super()._auto_init()
            // if not index_exists(self.env.cr, 'account_move_checked_idx'):
            //     self.env.cr.execute("""
            //         CREATE INDEX account_move_checked_idx
            //                   ON account_move(journal_id)
            //                WHERE checked = false
            //     """)
            // if not index_exists(self.env.cr, 'account_move_payment_idx'):
            //     self.env.cr.execute("""
            //         CREATE INDEX account_move_payment_idx
            //                   ON account_move(journal_id, state, payment_state, move_type, date)
            //     """)
            // if not index_exists(self.env.cr, 'account_move_unique_name'):
            //     self.env.cr.execute("""
            //         CREATE UNIQUE INDEX account_move_unique_name
            //                          ON account_move(name, journal_id)
            //                       WHERE (state = 'posted' AND name != '/')
            //     """)
            // 
            // if not column_exists(self.env.cr, "account_move", "preferred_payment_method_line_id"):
            //     create_column(self.env.cr, "account_move", "preferred_payment_method_line_id", "int4")
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: account_move.py) ---
            // def _auto_init(self):
            // if not column_exists(self.env.cr, "account_move", "website_id"):
            //     # Creating the column via `_auto_init` prevents a MemoryError in databases where many
            //     # invoices exist when `website_sale` is installed, as it skips the computation of the
            //     # `website_id` field.
            //     create_column(self.env.cr, "account_move", "website_id", "int4")
            // super()._auto_init()
            */
            return default;
        }

        protected async Task<AccountMove> AutopostBillInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _autopost_bill(self):
            // # Verify if the bill should be autoposted, if so, post it
            // self.ensure_one()
            // if (
            //     self.company_id.autopost_bills
            //     and self.partner_id
            //     and self.is_purchase_document(include_receipts=True)
            //     and self.partner_id.autopost_bills == 'always'
            //     and not self.abnormal_amount_warning
            //     and not self.restrict_mode_hash_table
            // ):
            //     if self.duplicated_ref_ids:
            //         self.message_post(body=_("Auto-post was disabled on this invoice because a potential duplicate was detected."))
            //     else:
            //         self.action_post()
            */
            return default;
        }

        protected async Task<AccountMove> AutopostDraftEntriesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _autopost_draft_entries(self):
            // ''' This method is called from a cron job.
            // It is used to post entries such as those created by the module
            // account_asset and recurring entries created in _post().
            // '''
            // moves = self.search([
            //     ('state', '=', 'draft'),
            //     ('date', '<=', fields.Date.context_today(self)),
            //     ('auto_post', '!=', 'no'),
            //     '|', ('checked', '=', True), ('journal_id.autocheck_on_post', '=', True)
            // ], limit=100)
            // 
            // try:  # try posting in batch
            //     with self.env.cr.savepoint():
            //         moves._post()
            // except UserError:  # if at least one move cannot be posted, handle moves one by one
            //     for move in moves:
            //         try:
            //             with self.env.cr.savepoint():
            //                 move._post()
            //         except UserError as e:
            //             move.checked = False
            //             move.auto_post = 'no'
            //             msg = _('The move could not be posted for the following reason: %(error_message)s', error_message=e)
            //             move.message_post(body=msg, message_type='comment')
            // 
            // if len(moves) == 100:  # assumes there are more whenever search hits limit
            //     self.env.ref('account.ir_cron_auto_post_draft_entry')._trigger()
            */
            return default;
        }

        protected async Task<AccountMove> BuildCreditWarningMessageInternalAsync(object record, object current_amount, object exclude_current, object exclude_amount)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _build_credit_warning_message(self, record, current_amount=0.0, exclude_current=False, exclude_amount=0.0):
            // """ Build the warning message that will be displayed in a yellow banner on top of the current record
            //     if the partner exceeds a credit limit (set on the company or the partner itself).
            //     :param record:                  The record where the warning will appear (Invoice, Sales Order...).
            //     :param current_amount (float):  The partner's outstanding credit amount from the current document.
            //     :param exclude_current (bool):  DEPRECATED in favor of parameter `exclude_amount`:
            //                                     Whether to exclude `current_amount` from the credit to invoice.
            //     :param exclude_amount (float):  The amount to subtract from the partner's `credit_to_invoice`.
            //                                     Consider the warning on a draft invoice created from a sales order.
            //                                     After confirming the invoice the (partial) amount (on the invoice)
            //                                     stemming from sales orders will be substracted from the `credit_to_invoice`.
            //                                     This will reduce the total credit of the partner.
            //                                     This parameter is used to reflect this amount.
            //     :return (str):                  The warning message to be showed.
            // """
            // partner_id = record.partner_id.commercial_partner_id
            // credit_to_invoice = partner_id.credit_to_invoice - exclude_amount
            // total_credit = partner_id.credit + credit_to_invoice + current_amount
            // if not partner_id.credit_limit or total_credit <= partner_id.credit_limit:
            //     return ''
            // msg = _(
            //     '%(partner_name)s has reached its credit limit of: %(credit_limit)s',
            //     partner_name=partner_id.name,
            //     credit_limit=formatLang(self.env, partner_id.credit_limit, currency_obj=record.company_id.currency_id)
            // )
            // total_credit_formatted = formatLang(self.env, total_credit, currency_obj=record.company_id.currency_id)
            // if credit_to_invoice > 0 and current_amount > 0:
            //     return msg + '\n' + _(
            //         'Total amount due (including sales orders and this document): %(total_credit)s',
            //         total_credit=total_credit_formatted
            //     )
            // elif credit_to_invoice > 0:
            //     return msg + '\n' + _(
            //         'Total amount due (including sales orders): %(total_credit)s',
            //         total_credit=total_credit_formatted
            //     )
            // elif current_amount > 0:
            //     return msg + '\n' + _(
            //         'Total amount due (including this document): %(total_credit)s',
            //         total_credit=total_credit_formatted
            //     )
            // else:
            //     return msg + '\n' + _(
            //         'Total amount due: %(total_credit)s',
            //         total_credit=total_credit_formatted
            //     )
            */
            return default;
        }

        public async Task<AccountMove> ButtonAbandonCancelPostedPostedMovesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def button_abandon_cancel_posted_posted_moves(self):
            // '''Cancel the request for cancellation of the EDI.
            // '''
            // documents = self.env['account.edi.document']
            // for move in self:
            //     is_move_marked = False
            //     for doc in move.edi_document_ids:
            //         move_applicability = doc.edi_format_id._get_move_applicability(move)
            //         if doc.state == 'to_cancel' and move_applicability and move_applicability.get('cancel'):
            //             documents |= doc
            //             is_move_marked = True
            //     if is_move_marked:
            //         move.message_post(body=_("A request for cancellation of the EDI has been called off."))
            // 
            // documents.write({'state': 'sent', 'error': False, 'blocking_level': False})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> ButtonCancelAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def button_cancel(self):
            // # Shortcut to move from posted to cancelled directly. This is useful for E-invoices that must not be changed
            // # when sent to the government.
            // moves_to_reset_draft = self.filtered(lambda x: x.state == 'posted')
            // if moves_to_reset_draft:
            //     moves_to_reset_draft.button_draft()
            // 
            // if any(move.state != 'draft' for move in self):
            //     raise UserError(_("Only draft journal entries can be cancelled."))
            // 
            // self.payment_ids.state = "canceled"
            // self.write({'auto_post': 'no', 'state': 'cancel'})
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def button_cancel(self):
            // # OVERRIDE
            // # Set the electronic document to be canceled and cancel immediately for synchronous formats.
            // res = super().button_cancel()
            // 
            // self.edi_document_ids.filtered(lambda doc: doc.state != 'sent').write({'state': 'cancelled', 'error': False, 'blocking_level': False})
            // self.edi_document_ids.filtered(lambda doc: doc.state == 'sent').write({'state': 'to_cancel', 'error': False, 'blocking_level': False})
            // self.edi_document_ids._process_documents_no_web_services()
            // self.env.ref('account_edi.ir_cron_edi_network')._trigger()
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: account_move.py) ---
            // def button_cancel(self):
            // # EXTENDS account
            // # We need to override this method to remove the link with the move, else we cannot reimburse them anymore.
            // # And cancelling the move != cancelling the expense
            // res = super().button_cancel()
            // with_expense = self.filtered('expense_sheet_id')
            // # Only clear reference for moves with expense sheets.
            // with_expense.write({'expense_sheet_id': False, 'ref': False})
            // return res
            --- ODOO METHOD SOURCE (MODULE: membership, FILE: account_move.py) ---
            // def button_cancel(self):
            // # OVERRIDE to update the cancel date.
            // res = super(AccountMove, self).button_cancel()
            // for move in self:
            //     if move.move_type == 'out_invoice':
            //         self.env['membership.membership_line'].search([
            //             ('account_invoice_line', 'in', move.mapped('invoice_line_ids').ids)
            //         ]).write({'date_cancel': fields.Date.today()})
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move.py) ---
            // def button_cancel(self):
            // res = super().button_cancel()
            // 
            // self.line_ids.filtered('is_downpayment').sale_line_ids.filtered(
            //     lambda sol: not sol.display_type)._compute_name()
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move.py) ---
            // def button_cancel(self):
            // # OVERRIDE
            // res = super(AccountMove, self).button_cancel()
            // 
            // # Unlink the COGS lines generated during the 'post' method.
            // # In most cases it shouldn't be necessary since they should be unlinked with 'button_draft'.
            // # However, since it can be called in RPC, better be safe.
            // self.mapped('line_ids').filtered(lambda line: line.display_type == 'cogs').unlink()
            // return res
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account.py) ---
            // def button_cancel(self):
            // for move in self:
            //     for line in move.asset_depreciation_ids:
            //         line.move_posted_check = False
            // return super(AccountMove, self).button_cancel()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> ButtonCancelPostedMovesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def button_cancel_posted_moves(self):
            // '''Mark the edi.document related to this move to be canceled.
            // '''
            // to_cancel_documents = self.env['account.edi.document']
            // for move in self:
            //     move._check_fiscal_lock_dates()
            //     is_move_marked = False
            //     for doc in move.edi_document_ids:
            //         move_applicability = doc.edi_format_id._get_move_applicability(move)
            //         if doc.edi_format_id._needs_web_services() \
            //                 and doc.state == 'sent' \
            //                 and move_applicability \
            //                 and move_applicability.get('cancel'):
            //             to_cancel_documents |= doc
            //             is_move_marked = True
            //     if is_move_marked:
            //         move.message_post(body=_("A cancellation of the EDI has been requested."))
            // 
            // to_cancel_documents.write({'state': 'to_cancel', 'error': False, 'blocking_level': False})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> ButtonCreateLandedCostsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_landed_costs, FILE: account_move.py) ---
            // def button_create_landed_costs(self):
            // """Create a `stock.landed.cost` record associated to the account move of `self`, each
            // `stock.landed.costs` lines mirroring the current `account.move.line` of self.
            // """
            // self.ensure_one()
            // landed_costs_lines = self.line_ids.filtered(lambda line: line.is_landed_costs_line)
            // 
            // sign = -1 if self.move_type in ['in_refund'] else 1
            // landed_costs = self.env['stock.landed.cost'].with_company(self.company_id).create({
            //     'vendor_bill_id': self.id,
            //     'cost_lines': [(0, 0, {
            //         'product_id': l.product_id.id,
            //         'name': l.product_id.name,
            //         'account_id': l.product_id.product_tmpl_id.get_product_accounts()['stock_input'].id,
            //         'price_unit': sign * l.currency_id._convert(l.price_subtotal, l.company_currency_id, l.company_id, self.invoice_date or fields.Date.context_today(l)),
            //         'split_method': l.product_id.split_method_landed_cost or 'equal',
            //     }) for l in landed_costs_lines],
            // })
            // action = self.env["ir.actions.actions"]._for_xml_id("stock_landed_costs.action_stock_landed_cost")
            // return dict(action, view_mode='form', res_id=landed_costs.id, views=[(False, 'form')])
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> ButtonDraftAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def button_draft(self):
            // if any(move.state not in ('cancel', 'posted') for move in self):
            //     raise UserError(_("Only posted/cancelled journal entries can be reset to draft."))
            // if any(move.need_cancel_request for move in self):
            //     raise UserError(_("You can't reset to draft those journal entries. You need to request a cancellation instead."))
            // 
            // self._check_draftable()
            // # We remove all the analytics entries for this journal
            // self.line_ids.analytic_line_ids.with_context(skip_analytic_sync=True).unlink()
            // self.mapped('line_ids').remove_move_reconcile()
            // self.state = 'draft'
            // 
            // self._detach_attachments()
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def button_draft(self):
            // # OVERRIDE
            // for move in self:
            //     if not move._edi_allow_button_draft():
            //         raise UserError(_(
            //             "You can't edit the following journal entry %s because an electronic document has already been "
            //             "sent. Please use the 'Request EDI Cancellation' button instead.",
            //             move.display_name))
            // 
            // res = super().button_draft()
            // 
            // self.edi_document_ids.write({'error': False, 'blocking_level': False})
            // self.edi_document_ids.filtered(lambda doc: doc.state == 'to_send').unlink()
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: membership, FILE: account_move.py) ---
            // def button_draft(self):
            // # OVERRIDE to update the cancel date.
            // res = super(AccountMove, self).button_draft()
            // for move in self:
            //     if move.move_type == 'out_invoice':
            //         self.env['membership.membership_line'].search([
            //             ('account_invoice_line', 'in', move.mapped('invoice_line_ids').ids)
            //         ]).write({'date_cancel': False})
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move.py) ---
            // def button_draft(self):
            // res = super().button_draft()
            // 
            // self.line_ids.filtered('is_downpayment').sale_line_ids.filtered(
            //     lambda sol: not sol.display_type)._compute_name()
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale_expense, FILE: account_move_line.py) ---
            // def button_draft(self):
            // res = super().button_draft()
            // self.expense_sheet_id._sale_expense_reset_sol_quantities()
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move.py) ---
            // def button_draft(self):
            // res = super(AccountMove, self).button_draft()
            // 
            // # Unlink the COGS lines generated during the 'post' method.
            // self.mapped('line_ids').filtered(lambda line: line.display_type == 'cogs').unlink()
            // return res
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_move.py) ---
            // def button_draft(self):
            // res = super(AccountMove, self).button_draft()
            // for move in self:
            //     if any(asset_id.state != 'draft' for asset_id in move.asset_ids):
            //         raise ValidationError(_(
            //             'You cannot reset to draft for an entry having a posted asset'))
            //     if move.asset_ids:
            //         move.asset_ids.sudo().write({'active': False})
            //         for asset in move.asset_ids:
            //             asset.sudo().message_post(body=_("Vendor bill cancelled."))
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> ButtonForceCancelAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def button_force_cancel(self):
            // """ Cancel the invoice without waiting for the cancellation request to succeed.
            // """
            // for move in self:
            //     to_cancel_edi_documents = move.edi_document_ids.filtered(lambda doc: doc.state == 'to_cancel')
            //     move.message_post(body=_("This invoice was canceled while the EDIs %s still had a pending cancellation request.", ", ".join(to_cancel_edi_documents.mapped('edi_format_id.name'))))
            // self.button_cancel()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> ButtonHashAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def button_hash(self):
            // self._hash_moves(force_hash=True)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> ButtonProcessEdiWebServicesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def button_process_edi_web_services(self):
            // self.ensure_one()
            // self.action_process_edi_web_services(with_commit=False)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> ButtonRequestCancelAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def button_request_cancel(self):
            // """ Hook allowing the localizations to request a cancellation from the government before cancelling the invoice. """
            // self.ensure_one()
            // if not self.need_cancel_request:
            //     raise UserError(_("You can only request a cancellation for invoice sent to the government."))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> ButtonSetCheckedAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def button_set_checked(self):
            // for move in self:
            //     move.checked = True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> CalculateHashesInternalAsync(object previous_hash)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _calculate_hashes(self, previous_hash):
            // """
            // :return: dict of move_id: hash
            // """
            // hash_version = self._context.get('hash_version', MAX_HASH_VERSION)
            // 
            // def _getattrstring(obj, field_name):
            //     field_value = obj[field_name]
            //     if obj._fields[field_name].type == 'many2one':
            //         field_value = field_value.id
            //     if obj._fields[field_name].type == 'monetary' and hash_version >= 3:
            //         return float_repr(field_value, obj.currency_id.decimal_places)
            //     return str(field_value)
            // 
            // move2hash = {}
            // previous_hash = previous_hash or ''
            // 
            // for move in self:
            //     if previous_hash and previous_hash.startswith("$"):
            //         previous_hash = previous_hash.split("$")[2]  # The hash version is not used for the computation of the next hash
            //     values = {}
            //     for fname in move._get_integrity_hash_fields():
            //         values[fname] = _getattrstring(move, fname)
            // 
            //     for line in move.line_ids:
            //         for fname in line._get_integrity_hash_fields():
            //             k = 'line_%d_%s' % (line.id, fname)
            //             values[k] = _getattrstring(line, fname)
            //     current_record = dumps(values, sort_keys=True, ensure_ascii=True, indent=None, separators=(',', ':'))
            //     hash_string = sha256((previous_hash + current_record).encode('utf-8')).hexdigest()
            //     move2hash[move] = f"${hash_version}${hash_string}" if hash_version >= 4 else hash_string
            //     previous_hash = move2hash[move]
            // return move2hash
            */
            return default;
        }

        protected async Task<AccountMove> CanBeUnlinkedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _can_be_unlinked(self):
            // self.ensure_one()
            // lock_date = self.company_id._get_user_fiscal_lock_date(self.journal_id)
            // return not self.inalterable_hash and self.date > lock_date
            */
            return default;
        }

        protected async Task<AccountMove> CanCommitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _can_commit():
            // """ Helper to know if we can commit the current transaction or not.
            // 
            // :returns: True if commit is acceptable, False otherwise.
            // """
            // return not tools.config['test_enable'] and not modules.module.current_test
            */
            return default;
        }

        protected async Task<AccountMove> CanForceCancelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _can_force_cancel(self):
            // """ Hook to indicate whether it should be possible to force-cancel this invoice,
            // that is, cancel it without waiting for the cancellation request to succeed.
            // """
            // self.ensure_one()
            // return False
            */
            return default;
        }

        public async Task<AccountMove> CancelAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_move.py) ---
            // def action_cancel(self):
            // res = super(AccountMove, self).action_cancel()
            // assets = self.env['account.asset.asset'].sudo().search(
            //     [('invoice_id', 'in', self.ids)])
            // if assets:
            //     assets.sudo().write({'active': False})
            //     for asset in assets:
            //         asset.sudo().message_post(body=_("Vendor bill cancelled."))
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> CancelPeppolDocumentsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: account_move.py) ---
            // def action_cancel_peppol_documents(self):
            // # if the peppol_move_state is processing/done
            // # then it means it has been already sent to peppol proxy and we can't cancel
            // if any(move.peppol_move_state in {'processing', 'done'} for move in self):
            //     raise UserError(_("Cannot cancel an entry that has already been sent to PEPPOL"))
            // self.peppol_move_state = False
            // self.sending_data = False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> CheckAndDecodeAttachmentInternalAsync(object attachments)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _check_and_decode_attachment(self, attachments):
            // if not attachments or self.env.context.get('no_new_invoice'):
            //     return False
            // if self.state != 'draft':
            //     self.with_user(SUPERUSER_ID).message_post(
            //         body=_('The invoice is not a draft, it was not updated from the attachment.'),
            //         message_type='comment',
            //     )
            //     return False
            // 
            // # As we are coming from the mail, we assume that ONE of the attachments
            // # will enhance the invoice thanks to EDI / OCR / .. capabilities
            // move_per_decodable_attachment = self._extend_with_attachments(attachments, new=bool(self._context.get('from_alias')))
            // if self.invoice_line_ids and not move_per_decodable_attachment:
            //     self.with_user(SUPERUSER_ID).message_post(
            //         body=_('The invoice already contains lines, it was not updated from the attachment.'),
            //         message_type='comment',
            //     )
            //     return False
            // attachments_in_invoices = self.env['ir.attachment']
            // for attachment in move_per_decodable_attachment:
            //     attachments_in_invoices += attachment
            // # Unlink the unused attachments (prevents storing marketing images sent with emails)
            // if self._context.get('from_alias'):
            //     (attachments - attachments_in_invoices).unlink()
            // return move_per_decodable_attachment
            */
            return default;
        }

        protected async Task<AccountMove> CheckBalancedInternalAsync(object container)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _check_balanced(self, container):
            // ''' Assert the move is fully balanced debit = credit.
            // An error is raised if it's not the case.
            // '''
            // with self._disable_recursion(container, 'check_move_validity', default=True, target=False) as disabled:
            //     yield
            //     if disabled:
            //         return
            // 
            // if unbalanced_moves := self._get_unbalanced_moves(container):
            //     if len(unbalanced_moves) == 1:
            //         raise UserError("The entry is not balanced.")
            // 
            //     error_msg = _("The following entries are unbalanced:\n\n")
            //     for move in unbalanced_moves:
            //         error_msg += f"  - {self.browse(move[0]).name}\n"
            //         raise UserError(error_msg)
            */
            return default;
        }

        protected async Task<AccountMove> CheckDraftableInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _check_draftable(self):
            // exchange_move_ids = set()
            // if self:
            //     self.env['account.full.reconcile'].flush_model(['exchange_move_id'])
            //     self.env['account.partial.reconcile'].flush_model(['exchange_move_id'])
            //     sql = SQL(
            //         """
            //             SELECT DISTINCT sub.exchange_move_id
            //             FROM (
            //                 SELECT exchange_move_id
            //                 FROM account_full_reconcile
            //                 WHERE exchange_move_id IN %s
            // 
            //                 UNION ALL
            // 
            //                 SELECT exchange_move_id
            //                 FROM account_partial_reconcile
            //                 WHERE exchange_move_id IN %s
            //             ) AS sub
            //         """,
            //         tuple(self.ids), tuple(self.ids),
            //     )
            //     exchange_move_ids = {id_ for id_, in self.env.execute_query(sql)}
            // 
            // for move in self:
            //     if move.id in exchange_move_ids:
            //         raise UserError(_('You cannot reset to draft an exchange difference journal entry.'))
            //     if move.tax_cash_basis_rec_id or move.tax_cash_basis_origin_move_id:
            //         # If the reconciliation was undone, move.tax_cash_basis_rec_id will be empty;
            //         # but we still don't want to allow setting the caba entry to draft
            //         # (it'll have been reversed automatically, so no manual intervention is required),
            //         # so we also check tax_cash_basis_origin_move_id, which stays unchanged
            //         # (we need both, as tax_cash_basis_origin_move_id did not exist in older versions).
            //         raise UserError(_('You cannot reset to draft a tax cash basis journal entry.'))
            //     if move.inalterable_hash:
            //         raise UserError(_('You cannot reset to draft a locked journal entry.'))
            */
            return default;
        }

        protected async Task<AccountMove> CheckEdiDocumentsForResetToDraftInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _check_edi_documents_for_reset_to_draft(self):
            // self.ensure_one()
            // for doc in self.edi_document_ids:
            //     move_applicability = doc.edi_format_id._get_move_applicability(self)
            //     if doc.edi_format_id._needs_web_services() \
            //         and doc.state in ('sent', 'to_cancel') \
            //         and move_applicability \
            //         and move_applicability.get('cancel'):
            //         return False
            // return True
            */
            return default;
        }

        protected async Task<AccountMove> CheckFiscalLockDatesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _check_fiscal_lock_dates(self):
            // if self.env.context.get('bypass_lock_check') is BYPASS_LOCK_CHECK:
            //     return
            // for move in self:
            //     journal = move.journal_id
            //     violated_lock_dates = move.company_id._get_lock_date_violations(
            //         move.date,
            //         fiscalyear=True,
            //         sale=journal and journal.type == 'sale',
            //         purchase=journal and journal.type == 'purchase',
            //         tax=False,
            //         hard=True,
            //     )
            //     if violated_lock_dates:
            //         message = _("You cannot add/modify entries prior to and inclusive of: %(lock_date_info)s.",
            //                     lock_date_info=self.env['res.company']._format_lock_dates(violated_lock_dates))
            //         raise UserError(message)
            // return True
            */
            return default;
        }

        protected async Task<AccountMove> CheckJournalMoveTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _check_journal_move_type(self):
            // for move in self:
            //     if move.is_purchase_document(include_receipts=True) and move.journal_id.type != 'purchase':
            //         raise ValidationError(_("Cannot create a purchase document in a non purchase journal"))
            //     if move.is_sale_document(include_receipts=True) and move.journal_id.type != 'sale':
            //         raise ValidationError(_("Cannot create a sale document in a non sale journal"))
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: account_move.py) ---
            // def _check_journal_move_type(self):
            // return super(AccountMove, self.filtered(lambda x: not x.expense_sheet_id))._check_journal_move_type()
            */
            return default;
        }

        public async Task<AccountMove> CheckMoveSequenceChainAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def check_move_sequence_chain(self):
            // return self.filtered(lambda move: move.name != '/')._is_end_of_seq_chain()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> CheckTotalAmountInternalAsync(object amount_total)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _check_total_amount(self, amount_total):
            // """
            // Verifies that the total amount corresponds to the quick total amount chosen as some
            // rounding errors may appear. In such a case, we round up the tax such that the total
            // is equal to the quick total amount set
            // E.g.: 100€ including 21% tax: base = 82.64, tax = 17.35, total = 99.99
            // The tax will be set to 17.36 in order to have a total of 100.00
            // """
            // if not self.tax_totals or not amount_total:
            //     return
            // totals = self.tax_totals
            // tax_amount_rounding_error = amount_total - totals['total_amount_currency']
            // if not float_is_zero(tax_amount_rounding_error, precision_rounding=self.currency_id.rounding):
            //     for subtotal in totals['subtotals']:
            //         if _('Untaxed Amount') == subtotal['name']:
            //             if subtotal['tax_groups']:
            //                 subtotal['tax_groups'][0]['tax_amount_currency'] += tax_amount_rounding_error
            //             totals['total_amount_currency'] = amount_total
            //             self.tax_totals = totals
            //             break
            */
            return default;
        }

        protected async Task<AccountMove> CleanupWriteOrmValuesInternalAsync(object record, object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _cleanup_write_orm_values(self, record, vals):
            // cleaned_vals = dict(vals)
            // for field_name in vals.keys():
            //     if not self._field_will_change(record, vals, field_name):
            //         del cleaned_vals[field_name]
            // return cleaned_vals
            */
            return default;
        }

        protected async Task<AccountMove> CollectTaxCashBasisValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _collect_tax_cash_basis_values(self):
            // ''' Collect all information needed to create the tax cash basis journal entries:
            // - Determine if a tax cash basis journal entry is needed.
            // - Compute the lines to be processed and the amounts needed to compute a percentage.
            // :return: A dictionary:
            //     * move:                     The current account.move record passed as parameter.
            //     * to_process_lines:         A tuple (caba_treatment, line) where:
            //                                     - caba_treatment is either 'tax' or 'base', depending on what should
            //                                       be considered on the line when generating the caba entry.
            //                                       For example, a line with tax_ids=caba and tax_line_id=non_caba
            //                                       will have a 'base' caba treatment, as we only want to treat its base
            //                                       part in the caba entry (the tax part is already exigible on the invoice)
            // 
            //                                     - line is an account.move.line record being not exigible on the tax report.
            //     * currency:                 The currency on which the percentage has been computed.
            //     * total_balance:            sum(payment_term_lines.mapped('balance').
            //     * total_residual:           sum(payment_term_lines.mapped('amount_residual').
            //     * total_amount_currency:    sum(payment_term_lines.mapped('amount_currency').
            //     * total_residual_currency:  sum(payment_term_lines.mapped('amount_residual_currency').
            //     * is_fully_paid:            A flag indicating the current move is now fully paid.
            // '''
            // self.ensure_one()
            // 
            // values = {
            //     'move': self,
            //     'to_process_lines': [],
            //     'total_balance': 0.0,
            //     'total_residual': 0.0,
            //     'total_amount_currency': 0.0,
            //     'total_residual_currency': 0.0,
            // }
            // 
            // currencies = set()
            // has_term_lines = False
            // for line in self.line_ids:
            //     if line.account_type in ('asset_receivable', 'liability_payable'):
            //         sign = 1 if line.balance > 0.0 else -1
            // 
            //         currencies.add(line.currency_id)
            //         has_term_lines = True
            //         values['total_balance'] += sign * line.balance
            //         values['total_residual'] += sign * line.amount_residual
            //         values['total_amount_currency'] += sign * line.amount_currency
            //         values['total_residual_currency'] += sign * line.amount_residual_currency
            // 
            //     elif line.tax_line_id.tax_exigibility == 'on_payment':
            //         values['to_process_lines'].append(('tax', line))
            //         currencies.add(line.currency_id)
            // 
            //     elif 'on_payment' in line.tax_ids.flatten_taxes_hierarchy().mapped('tax_exigibility'):
            //         values['to_process_lines'].append(('base', line))
            //         currencies.add(line.currency_id)
            // 
            // if not values['to_process_lines'] or not has_term_lines:
            //     return None
            // 
            // # Compute the currency on which made the percentage.
            // if len(currencies) == 1:
            //     values['currency'] = list(currencies)[0]
            // else:
            //     # Don't support the case where there is multiple involved currencies.
            //     return None
            // 
            // # Determine whether the move is now fully paid.
            // values['is_fully_paid'] = self.company_id.currency_id.is_zero(values['total_residual']) \
            //                           or values['currency'].is_zero(values['total_residual_currency'])
            // 
            // return values
            */
            return default;
        }

        protected async Task<AccountMove> ComputeAbnormalWarningsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_abnormal_warnings(self):
            // """Assign warning fields based on historical data.
            // 
            // The last invoices (between 10 and 30) are used to compute the normal distribution.
            // If the amount or days between invoices of the current invoice falls outside of the boundaries
            // of the Bell curve, we warn the user.
            // """
            // if self.env.context.get('disable_abnormal_invoice_detection'):
            //     draft_invoices = self.browse()
            // else:
            //     draft_invoices = self.filtered(lambda m:
            //         m.is_purchase_document()
            //         and m.state == 'draft'
            //         and m.amount_total
            //         and not (m.partner_id.ignore_abnormal_invoice_date and m.partner_id.ignore_abnormal_invoice_amount)
            //     )
            // other_moves = self - draft_invoices
            // other_moves.abnormal_amount_warning = False
            // other_moves.abnormal_date_warning = False
            // if not draft_invoices:
            //     return
            // draft_invoices.flush_recordset(['invoice_date', 'date', 'amount_total', 'partner_id', 'move_type', 'company_id'])
            // today = fields.Date.context_today(self)
            // self.env.cr.execute("""
            //     WITH previous_invoices AS (
            //           SELECT this.id,
            //                  other.invoice_date,
            //                  other.amount_total,
            //                  LAG(other.invoice_date) OVER invoice - other.invoice_date AS date_diff
            //             FROM account_move this
            //             JOIN account_move other USING (partner_id, move_type, company_id, currency_id)
            //            WHERE other.state = 'posted'
            //              AND other.invoice_date <= COALESCE(this.invoice_date, this.date, %(today)s)
            //              AND this.id = ANY(%(move_ids)s)
            //              AND this.id != other.id
            //           WINDOW invoice AS (PARTITION BY this.id ORDER BY other.invoice_date DESC)
            //     ), stats AS (
            //           SELECT id,
            //                  MAX(invoice_date)          OVER invoice AS last_invoice_date,
            //                  AVG(date_diff)             OVER invoice AS date_diff_mean,
            //                  STDDEV_SAMP(date_diff)     OVER invoice AS date_diff_deviation,
            //                  AVG(amount_total)          OVER invoice AS amount_mean,
            //                  STDDEV_SAMP(amount_total)  OVER invoice AS amount_deviation,
            //                  ROW_NUMBER()               OVER invoice AS row_number
            //             FROM previous_invoices
            //           WINDOW invoice AS (PARTITION BY id ORDER BY invoice_date DESC)
            //     )
            //       SELECT id, last_invoice_date, date_diff_mean, date_diff_deviation, amount_mean, amount_deviation
            //         FROM stats
            //        WHERE row_number BETWEEN 10 AND 30
            //     ORDER BY row_number ASC
            // """, {
            //     'today': today,
            //     'move_ids': draft_invoices.ids,
            // })
            // result = {invoice: vals for invoice, *vals in self.env.cr.fetchall()}
            // for move in draft_invoices:
            //     invoice_date = move.invoice_date or today
            //     (
            //         last_invoice_date, date_diff_mean, date_diff_deviation,
            //         amount_mean, amount_deviation,
            //     ) = result.get(move._origin.id, (invoice_date, 0, 10000000000, 0, 10000000000))
            // 
            //     if date_diff_mean > 25:
            //         # Correct for varying days per month and leap years
            //         # If we have a recurring invoice every month, the mean will be ~30.5 days, and the deviation ~1 day.
            //         # We need to add some wiggle room for the month of February otherwise it will trigger because 28 days is outside of the range
            //         date_diff_deviation += 1
            // 
            //     wiggle_room_date = 2 * date_diff_deviation
            //     move.abnormal_date_warning = (
            //         not move.partner_id.ignore_abnormal_invoice_date
            //         and (invoice_date - last_invoice_date).days < int(date_diff_mean - wiggle_room_date)
            //     ) and _(
            //         "The billing frequency for %(partner_name)s appears unusual. Based on your historical data, "
            //         "the expected next invoice date is not before %(expected_date)s (every %(mean)s (± %(wiggle)s) days).\n"
            //         "Please verify if this date is accurate.",
            //         partner_name=move.partner_id.display_name,
            //         expected_date=format_date(self.env, fields.Date.add(last_invoice_date, days=int(date_diff_mean - wiggle_room_date))),
            //         mean=int(date_diff_mean),
            //         wiggle=int(wiggle_room_date),
            //     )
            // 
            //     wiggle_room_amount = 2 * amount_deviation
            //     move.abnormal_amount_warning = (
            //         not move.partner_id.ignore_abnormal_invoice_amount
            //         and not (amount_mean - wiggle_room_amount <= move.amount_total <= amount_mean + wiggle_room_amount)
            //     ) and _(
            //         "The amount for %(partner_name)s appears unusual. Based on your historical data, the expected amount is %(mean)s (± %(wiggle)s).\n"
            //         "Please verify if this amount is accurate.",
            //         partner_name=move.partner_id.display_name,
            //         mean=move.currency_id.format(amount_mean),
            //         wiggle=move.currency_id.format(wiggle_room_amount),
            //     )
            */
            return default;
        }

        protected async Task<AccountMove> ComputeAccessUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_access_url(self):
            // super()._compute_access_url()
            // for move in self.filtered(lambda move: move.is_invoice()):
            //     move.access_url = '/my/invoices/%s' % (move.id)
            */
            return default;
        }

        protected async Task<AccountMove> ComputeAlwaysTaxExigibleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_always_tax_exigible(self):
            // for record in self.with_context(prefetch_fields=False):
            //     # We need to check is_invoice as well because always_tax_exigible is used to
            //     # set the tags as well, during the encoding. So, if no receivable/payable
            //     # line has been created yet, the invoice would be detected as always exigible,
            //     # and set the tags on some lines ; which would be wrong.
            //     record.always_tax_exigible = not record.is_invoice(True) \
            //                                  and not record._collect_tax_cash_basis_values()
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: account_move.py) ---
            // def _compute_always_tax_exigible(self):
            // super()._compute_always_tax_exigible()
            // # The pos closing move does not create caba entries (anymore); we set the tax values directly on the closing move.
            // # (But there may still be old closing moves that used caba entries from previous versions.)
            // for move in self:
            //     if move.always_tax_exigible or move.tax_cash_basis_created_move_ids:
            //         continue
            //     if move.pos_session_ids:
            //         move.always_tax_exigible = True
            */
            return default;
        }

        protected async Task<AccountMove> ComputeAmountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_amount(self):
            // for move in self:
            //     total_untaxed, total_untaxed_currency = 0.0, 0.0
            //     total_tax, total_tax_currency = 0.0, 0.0
            //     total_residual, total_residual_currency = 0.0, 0.0
            //     total, total_currency = 0.0, 0.0
            // 
            //     for line in move.line_ids:
            //         if move.is_invoice(True):
            //             # === Invoices ===
            //             if line.display_type == 'tax' or (line.display_type == 'rounding' and line.tax_repartition_line_id):
            //                 # Tax amount.
            //                 total_tax += line.balance
            //                 total_tax_currency += line.amount_currency
            //                 total += line.balance
            //                 total_currency += line.amount_currency
            //             elif line.display_type in ('product', 'rounding'):
            //                 # Untaxed amount.
            //                 total_untaxed += line.balance
            //                 total_untaxed_currency += line.amount_currency
            //                 total += line.balance
            //                 total_currency += line.amount_currency
            //             elif line.display_type == 'payment_term':
            //                 # Residual amount.
            //                 total_residual += line.amount_residual
            //                 total_residual_currency += line.amount_residual_currency
            //         else:
            //             # === Miscellaneous journal entry ===
            //             if line.debit:
            //                 total += line.balance
            //                 total_currency += line.amount_currency
            // 
            //     sign = move.direction_sign
            //     move.amount_untaxed = sign * total_untaxed_currency
            //     move.amount_tax = sign * total_tax_currency
            //     move.amount_total = sign * total_currency
            //     move.amount_residual = -sign * total_residual_currency
            //     move.amount_untaxed_signed = -total_untaxed
            //     move.amount_untaxed_in_currency_signed = -total_untaxed_currency
            //     move.amount_tax_signed = -total_tax
            //     move.amount_total_signed = abs(total) if move.move_type == 'entry' else -total
            //     move.amount_residual_signed = total_residual
            //     move.amount_total_in_currency_signed = abs(move.amount_total) if move.move_type == 'entry' else -(sign * move.amount_total)
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: account_move.py) ---
            // def _compute_amount(self):
            // super()._compute_amount()
            // for move in self:
            //     if move.move_type == 'entry' and move.reversed_pos_order_id:
            //         move.amount_total_signed = move.amount_total_signed * -1
            */
            return default;
        }

        protected async Task<AccountMove> ComputeAmountPaidInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: account_move.py) ---
            // def _compute_amount_paid(self):
            // """ Sum all the transaction amount for which state is in 'authorized' or 'done'
            // """
            // for invoice in self:
            //     invoice.amount_paid = sum(
            //         invoice.transaction_ids.filtered(
            //             lambda tx: tx.state in ('authorized', 'done')
            //         ).mapped('amount')
            //     )
            */
            return default;
        }

        protected async Task<AccountMove> ComputeAmountTotalWordsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_amount_total_words(self):
            // for move in self:
            //     move.amount_total_words = move.currency_id.amount_to_text(move.amount_total).replace(',', '')
            */
            return default;
        }

        protected async Task<AccountMove> ComputeAuthorizedTransactionIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: account_move.py) ---
            // def _compute_authorized_transaction_ids(self):
            // for invoice in self:
            //     invoice.authorized_transaction_ids = invoice.transaction_ids.filtered(
            //         lambda tx: tx.state == 'authorized'
            //     )
            */
            return default;
        }

        protected async Task<AccountMove> ComputeAutoPostUntilInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_auto_post_until(self):
            // for record in self:
            //     if record.auto_post in ('no', 'at_date'):
            //         record.auto_post_until = False
            */
            return default;
        }

        protected async Task<AccountMove> ComputeBankPartnerIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_bank_partner_id(self):
            // for move in self:
            //     if move.is_inbound():
            //         move.bank_partner_id = move.company_id.partner_id
            //     else:
            //         move.bank_partner_id = move.commercial_partner_id
            */
            return default;
        }

        protected async Task<AccountMove> ComputeCommercialPartnerIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_commercial_partner_id(self):
            // for move in self:
            //     move.commercial_partner_id = move.partner_id.commercial_partner_id
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: account_move.py) ---
            // def _compute_commercial_partner_id(self):
            // own_expense_moves = self.filtered(lambda move: move.sudo().expense_sheet_id.payment_mode == 'own_account')
            // for move in own_expense_moves:
            //     if move.expense_sheet_id.payment_mode == 'own_account':
            //         move.commercial_partner_id = (
            //             move.partner_id.commercial_partner_id
            //             if move.partner_id.commercial_partner_id != move.company_id.partner_id
            //             else move.partner_id
            //         )
            // super(AccountMove, self - own_expense_moves)._compute_commercial_partner_id()
            */
            return default;
        }

        protected async Task<AccountMove> ComputeCompanyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_company_id(self):
            // for move in self:
            //     if move.journal_id.company_id not in move.company_id.parent_ids:
            //         move.company_id = (move.journal_id.company_id or self.env.company)._accessible_branches()[:1]
            */
            return default;
        }

        protected async Task<AccountMove> ComputeCurrencyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_currency_id(self):
            // for invoice in self:
            //     currency = (
            //         invoice.statement_line_id.foreign_currency_id
            //         or invoice.journal_id.currency_id
            //         or invoice.currency_id
            //         or invoice.journal_id.company_id.currency_id
            //     )
            //     invoice.currency_id = currency
            */
            return default;
        }

        protected async Task<AccountMove> ComputeDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_date(self):
            // for move in self:
            //     if not move.invoice_date or not move.is_invoice(include_receipts=True):
            //         if not move.date:
            //             move.date = fields.Date.context_today(self)
            //         continue
            //     accounting_date = move.invoice_date
            //     if not move.is_sale_document(include_receipts=True):
            //         accounting_date = move._get_accounting_date(move.invoice_date, move._affect_tax_report())
            //     if accounting_date and accounting_date != move.date:
            //         move.date = accounting_date
            //         # _affect_tax_report may trigger premature recompute of line_ids.date
            //         self.env.add_to_compute(move.line_ids._fields['date'], move.line_ids)
            //         # might be protected because `_get_accounting_date` requires the `name`
            //         self.env.add_to_compute(self._fields['name'], move)
            */
            return default;
        }

        protected async Task<AccountMove> ComputeDebitCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_debit_note, FILE: account_move.py) ---
            // def _compute_debit_count(self):
            // debit_data = self.env['account.move']._read_group([('debit_origin_id', 'in', self.ids)],
            //                                                 ['debit_origin_id'], ['__count'])
            // data_map = {debit_origin.id: count for debit_origin, count in debit_data}
            // for inv in self:
            //     inv.debit_note_count = data_map.get(inv.id, 0.0)
            */
            return default;
        }

        protected async Task<AccountMove> ComputeDeliveryDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_delivery_date(self):
            // pass
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: account_move.py) ---
            // def _compute_delivery_date(self):
            // # EXTENDS 'account'
            // super()._compute_delivery_date()
            // for move in self:
            //     sale_order_effective_date = list(filter(None, move.line_ids.sale_line_ids.order_id.mapped('effective_date')))
            //     effective_date_res = max(sale_order_effective_date) if sale_order_effective_date else False
            //     # if multiple sale order we take the bigger effective_date
            //     if effective_date_res:
            //         move.delivery_date = effective_date_res
            */
            return default;
        }

        protected async Task<AccountMove> ComputeDirectionSignInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_direction_sign(self):
            // for invoice in self:
            //     if invoice.move_type == 'entry' or invoice.is_outbound():
            //         invoice.direction_sign = 1
            //     else:
            //         invoice.direction_sign = -1
            */
            return default;
        }

        protected async Task<AccountMove> ComputeDisplayInactiveCurrencyWarningInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_display_inactive_currency_warning(self):
            // for move in self.with_context(active_test=False):
            //     move.display_inactive_currency_warning = move.state == 'draft' and move.currency_id and not move.currency_id.active
            */
            return default;
        }

        protected async Task<AccountMove> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_display_name(self):
            // for move in self:
            //     move.display_name = move._get_move_display_name(show_ref=True)
            */
            return default;
        }

        protected async Task<AccountMove> ComputeDisplayQrCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_display_qr_code(self):
            // for move in self:
            //     move.display_qr_code = (
            //         move.move_type in ('out_invoice', 'out_receipt', 'in_invoice', 'in_receipt')
            //         and move.company_id.qr_code
            //     )
            */
            return default;
        }

        protected async Task<AccountMove> ComputeDuplicatedRefIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_duplicated_ref_ids(self):
            // move_to_duplicate_move = self._fetch_duplicate_reference()
            // for move in self:
            //     # Uses move._origin.id to handle records in edition/existing records and 0 for new records
            //     move.duplicated_ref_ids = move_to_duplicate_move.get(move._origin, self.env['account.move'])
            */
            return default;
        }

        protected async Task<AccountMove> ComputeEdiErrorCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _compute_edi_error_count(self):
            // for move in self:
            //     move.edi_error_count = len(move.edi_document_ids.filtered(lambda d: d.error))
            */
            return default;
        }

        protected async Task<AccountMove> ComputeEdiErrorMessageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _compute_edi_error_message(self):
            // for move in self:
            //     if move.edi_error_count == 0:
            //         move.edi_error_message = None
            //         move.edi_blocking_level = None
            //     elif move.edi_error_count == 1:
            //         error_doc = move.edi_document_ids.filtered(lambda d: d.error)
            //         move.edi_error_message = error_doc.error
            //         move.edi_blocking_level = error_doc.blocking_level
            //     else:
            //         error_levels = set([doc.blocking_level for doc in move.edi_document_ids])
            //         count = str(move.edi_error_count)
            //         if 'error' in error_levels:
            //             move.edi_error_message = _("%(count)s Electronic invoicing error(s)", count=count)
            //             move.edi_blocking_level = 'error'
            //         elif 'warning' in error_levels:
            //             move.edi_error_message = _("%(count)s Electronic invoicing warning(s)", count=count)
            //             move.edi_blocking_level = 'warning'
            //         else:
            //             move.edi_error_message = _("%(count)s Electronic invoicing info(s)", count=count)
            //             move.edi_blocking_level = 'info'
            */
            return default;
        }

        protected async Task<AccountMove> ComputeEdiShowAbandonCancelButtonInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _compute_edi_show_abandon_cancel_button(self):
            // for move in self:
            //     move.edi_show_abandon_cancel_button = False
            //     for doc in move.sudo().edi_document_ids:
            //         move_applicability = doc.edi_format_id._get_move_applicability(move)
            //         if doc.edi_format_id._needs_web_services() \
            //             and doc.state == 'to_cancel' \
            //             and move_applicability \
            //             and move_applicability.get('cancel'):
            //             move.edi_show_abandon_cancel_button = True
            //             break
            */
            return default;
        }

        protected async Task<AccountMove> ComputeEdiShowCancelButtonInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _compute_edi_show_cancel_button(self):
            // for move in self:
            //     if move.state != 'posted':
            //         move.edi_show_cancel_button = False
            //         continue
            // 
            //     move.edi_show_cancel_button = False
            //     for doc in move.edi_document_ids:
            //         move_applicability = doc.edi_format_id._get_move_applicability(move)
            //         if doc.edi_format_id._needs_web_services() \
            //             and doc.state == 'sent' \
            //             and move_applicability \
            //             and move_applicability.get('cancel'):
            //             move.edi_show_cancel_button = True
            //             break
            */
            return default;
        }

        protected async Task<AccountMove> ComputeEdiShowForceCancelButtonInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _compute_edi_show_force_cancel_button(self):
            // for move in self:
            //     move.edi_show_force_cancel_button = move._can_force_cancel()
            */
            return default;
        }

        protected async Task<AccountMove> ComputeEdiStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _compute_edi_state(self):
            // for move in self:
            //     all_states = set(move.edi_document_ids.filtered(lambda d: d.edi_format_id._needs_web_services()).mapped('state'))
            //     if all_states == {'sent'}:
            //         move.edi_state = 'sent'
            //     elif all_states == {'cancelled'}:
            //         move.edi_state = 'cancelled'
            //     elif 'to_send' in all_states:
            //         move.edi_state = 'to_send'
            //     elif 'to_cancel' in all_states:
            //         move.edi_state = 'to_cancel'
            //     else:
            //         move.edi_state = False
            */
            return default;
        }

        protected async Task<AccountMove> ComputeEdiWebServicesToProcessInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _compute_edi_web_services_to_process(self):
            // for move in self:
            //     to_process = move.edi_document_ids.filtered(lambda d: d.state in ['to_send', 'to_cancel'] and d.blocking_level != 'error')
            //     format_web_services = to_process.edi_format_id.filtered(lambda f: f._needs_web_services())
            //     move.edi_web_services_to_process = ', '.join(f.name for f in format_web_services)
            */
            return default;
        }

        protected async Task<AccountMove> ComputeExpectedCurrencyRateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_expected_currency_rate(self):
            // for move in self:
            //     if move.currency_id:
            //         move.expected_currency_rate = move.env['res.currency']._get_conversion_rate(
            //             from_currency=move.company_currency_id,
            //             to_currency=move.currency_id,
            //             company=move.company_id,
            //             date=move._get_invoice_currency_rate_date(),
            //         )
            //     else:
            //         move.expected_currency_rate = 1
            */
            return default;
        }

        protected async Task<AccountMove> ComputeFiscalPositionIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_fiscal_position_id(self):
            // for move in self:
            //     delivery_partner = self.env['res.partner'].browse(
            //         move.partner_shipping_id.id
            //         or move.partner_id.address_get(['delivery'])['delivery']
            //     )
            //     move.fiscal_position_id = self.env['account.fiscal.position'].with_company(move.company_id)._get_fiscal_position(
            //         move.partner_id, delivery=delivery_partner)
            */
            return default;
        }

        protected async Task<AccountMove> ComputeHasReconciledEntriesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_has_reconciled_entries(self):
            // for move in self:
            //     move.has_reconciled_entries = len(move.line_ids._reconciled_lines()) > 1
            */
            return default;
        }

        protected async Task<AccountMove> ComputeHidePostButtonInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_hide_post_button(self):
            // for record in self:
            //     record.hide_post_button = record.state != 'draft' \
            //         or record.auto_post != 'no' and \
            //         record.date and record.date > fields.Date.context_today(record)
            */
            return default;
        }

        protected async Task<AccountMove> ComputeHighestNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_highest_name(self):
            // for record in self:
            //     record.highest_name = record._get_last_sequence()
            */
            return default;
        }

        protected async Task<AccountMove> ComputeIncotermLocationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_incoterm_location(self):
            // pass
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: account_invoice.py) ---
            // def _compute_incoterm_location(self):
            // super()._compute_incoterm_location()
            // for move in self:
            //     purchase_locations = move.line_ids.purchase_line_id.order_id.mapped('incoterm_location')
            //     incoterm_res = next((incoterm for incoterm in purchase_locations if incoterm), False)
            //     # if multiple purchase order we take an incoterm that is not false
            //     if incoterm_res:
            //         move.incoterm_location = incoterm_res
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: account_move.py) ---
            // def _compute_incoterm_location(self):
            // super()._compute_incoterm_location()
            // for move in self:
            //     sale_locations = move.line_ids.sale_line_ids.order_id.mapped('incoterm_location')
            //     incoterm_res = next((incoterm for incoterm in sale_locations if incoterm), False)
            //     # if multiple purchase order we take an incoterm that is not false
            //     if incoterm_res:
            //         move.incoterm_location = incoterm_res
            */
            return default;
        }

        protected async Task<AccountMove> ComputeInvoiceCurrencyRateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_invoice_currency_rate(self):
            // for move in self:
            //     if move.is_invoice(include_receipts=True):
            //         move.invoice_currency_rate = move.expected_currency_rate
            */
            return default;
        }

        protected async Task<AccountMove> ComputeInvoiceDateDueInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_invoice_date_due(self):
            // today = fields.Date.context_today(self)
            // for move in self:
            //     move.invoice_date_due = move.needed_terms and max(
            //         (k['date_maturity'] for k in move.needed_terms.keys() if k),
            //         default=False,
            //     ) or move.invoice_date_due or today
            */
            return default;
        }

        protected async Task<AccountMove> ComputeInvoiceDefaultSalePersonInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_invoice_default_sale_person(self):
            // # We want to modify the sale person only when we don't have one and if the move type corresponds to this condition
            // # If the move doesn't correspond, we remove the sale person
            // for move in self:
            //     if move.is_sale_document(include_receipts=True):
            //         if move.partner_id:
            //             move.invoice_user_id = (
            //                 move.invoice_user_id
            //                 or move.partner_id.user_id
            //                 or move.partner_id.commercial_partner_id.user_id
            //                 or self.env.user
            //             )
            //     else:
            //         move.invoice_user_id = False
            */
            return default;
        }

        protected async Task<AccountMove> ComputeInvoiceFilterTypeDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_invoice_filter_type_domain(self):
            // for move in self:
            //     if move.is_sale_document(include_receipts=True):
            //         move.invoice_filter_type_domain = 'sale'
            //     elif move.is_purchase_document(include_receipts=True):
            //         move.invoice_filter_type_domain = 'purchase'
            //     else:
            //         move.invoice_filter_type_domain = False
            */
            return default;
        }

        protected async Task<AccountMove> ComputeInvoicePartnerDisplayInfoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_invoice_partner_display_info(self):
            // for move in self:
            //     vendor_display_name = move.partner_id.display_name
            //     if not vendor_display_name:
            //         if move.invoice_source_email:
            //             vendor_display_name = _('@From: %(email)s', email=move.invoice_source_email)
            //         else:
            //             vendor_display_name = _('#Created by: %s', move.sudo().create_uid.name or self.env.user.name)
            //     move.invoice_partner_display_name = vendor_display_name
            */
            return default;
        }

        protected async Task<AccountMove> ComputeInvoicePaymentTermIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_invoice_payment_term_id(self):
            // for move in self:
            //     move = move.with_company(move.company_id)
            //     if move.is_sale_document(include_receipts=True) and move.partner_id.property_payment_term_id:
            //         move.invoice_payment_term_id = move.partner_id.property_payment_term_id
            //     elif move.is_purchase_document(include_receipts=True) and move.partner_id.property_supplier_payment_term_id:
            //         move.invoice_payment_term_id = move.partner_id.property_supplier_payment_term_id
            //     else:
            //         move.invoice_payment_term_id = False
            */
            return default;
        }

        protected async Task<AccountMove> ComputeIsBeingSentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_is_being_sent(self):
            // for move in self:
            //     move.is_being_sent = bool(move.sending_data)
            */
            return default;
        }

        protected async Task<AccountMove> ComputeIsPurchaseMatchedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def _compute_is_purchase_matched(self):
            // for move in self:
            //     if any(il.display_type == 'product' and not bool(il.purchase_line_id) for il in move.invoice_line_ids):
            //         move.is_purchase_matched = False
            //         continue
            //     move.is_purchase_matched = True
            */
            return default;
        }

        protected async Task<AccountMove> ComputeIsStornoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_is_storno(self):
            // for move in self:
            //     move.is_storno = move.is_storno or (move.move_type in ('out_refund', 'in_refund') and move.company_id.account_storno)
            */
            return default;
        }

        protected async Task<AccountMove> ComputeJournalIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_journal_id(self):
            // for move in self.filtered(lambda r: r.journal_id.type not in r._get_valid_journal_types()):
            //     move.journal_id = move._search_default_journal()
            */
            return default;
        }

        protected async Task<AccountMove> ComputeLandedCostsVisibleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_landed_costs, FILE: account_move.py) ---
            // def _compute_landed_costs_visible(self):
            // for account_move in self:
            //     if account_move.landed_costs_ids:
            //         account_move.landed_costs_visible = False
            //     else:
            //         account_move.landed_costs_visible = any(line.is_landed_costs_line for line in account_move.line_ids)
            */
            return default;
        }

        protected async Task<AccountMove> ComputeLinkedAttachmentIdInternalAsync(object attachment_field, object binary_field)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_linked_attachment_id(self, attachment_field, binary_field):
            // """Helper to retreive Attachment from Binary fields
            // This is needed because fields.Many2one('ir.attachment') makes all
            // attachments available to the user.
            // """
            // attachments = self.env['ir.attachment'].search([
            //     ('res_model', '=', self._name),
            //     ('res_id', 'in', self.ids),
            //     ('res_field', '=', binary_field)
            // ])
            // move_vals = {att.res_id: att for att in attachments}
            // for move in self:
            //     move[attachment_field] = move_vals.get(move._origin.id, False)
            */
            return default;
        }

        protected async Task<AccountMove> ComputeMadeSequenceGapInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_made_sequence_gap(self):
            // unposted = self.filtered(lambda move: move.sequence_number != 0 and move.state != 'posted')
            // unposted.made_sequence_gap = True
            // for (journal, prefix), moves in (self - unposted).grouped(lambda m: (m.journal_id, m.sequence_prefix)).items():
            //     previous_numbers = set(self.env['account.move'].sudo().search([
            //         ('journal_id', '=', journal.id),
            //         ('sequence_prefix', '=', prefix),
            //         ('sequence_number', '>=', min(moves.mapped('sequence_number')) - 1),
            //         ('sequence_number', '<=', max(moves.mapped('sequence_number')) - 1),
            //     ]).mapped('sequence_number'))
            //     for move in moves:
            //         move.made_sequence_gap = move.sequence_number > 1 and (move.sequence_number - 1) not in previous_numbers
            */
            return default;
        }

        public async Task<AccountMove> ComputeMoveSentValuesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def compute_move_sent_values(self):
            // for move in self:
            //     move.move_sent_values = 'sent' if move.is_move_sent else 'not_sent'
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> ComputeNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_name(self):
            // self = self.sorted(lambda m: (m.date, m.ref or '', m._origin.id))
            // 
            // for move in self:
            //     if move.state == 'cancel':
            //         continue
            // 
            //     move_has_name = move.name and move.name != '/'
            //     if not move.posted_before and not move._sequence_matches_date():
            //         # The name does not match the date and the move is not the first in the period:
            //         # Reset to draft
            //         move.name = False
            //         continue
            //     if move.date and not move_has_name and move.state != 'draft':
            //         move._set_next_sequence()
            // 
            // self._inverse_name()
            */
            return default;
        }

        protected async Task<AccountMove> ComputeNamePlaceholderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_name_placeholder(self):
            // for move in self:
            //     if (not move.name or move.name == '/') and move.date and not move._get_last_sequence():
            //         sequence_format_string, sequence_format_values = move._get_next_sequence_format()
            //         sequence_format_values['seq'] = sequence_format_values['seq'] + 1
            //         move.name_placeholder = sequence_format_string.format(**sequence_format_values)
            //     else:
            //         move.name_placeholder = False
            */
            return default;
        }

        protected async Task<AccountMove> ComputeNarrationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_narration(self):
            // use_invoice_terms = self.env['ir.config_parameter'].sudo().get_param('account.use_invoice_terms')
            // invoice_to_update_terms = self.filtered(lambda m: use_invoice_terms and m.is_sale_document(include_receipts=True))
            // for move in invoice_to_update_terms:
            //     lang = move.partner_id.lang or self.env.user.lang
            //     if move.company_id.terms_type != 'html':
            //         narration = move.company_id.with_context(lang=lang).invoice_terms if not is_html_empty(move.company_id.invoice_terms) else ''
            //     else:
            //         baseurl = self.env.company.get_base_url() + '/terms'
            //         context = {'lang': lang}
            //         narration = _('Terms & Conditions: %s', baseurl)
            //         del context
            //     move.narration = narration or False
            */
            return default;
        }

        protected async Task<AccountMove> ComputeNeedCancelRequestInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_need_cancel_request(self):
            // for move in self:
            //     move.need_cancel_request = move._need_cancel_request()
            */
            return default;
        }

        protected async Task<AccountMove> ComputeNeededTermsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_needed_terms(self):
            // AccountTax = self.env['account.tax']
            // for invoice in self.with_context(bin_size=False):
            //     is_draft = invoice.id != invoice._origin.id
            //     invoice.needed_terms = {}
            //     invoice.needed_terms_dirty = True
            //     sign = 1 if invoice.is_inbound(include_receipts=True) else -1
            //     if invoice.is_invoice(True) and invoice.invoice_line_ids:
            //         if invoice.invoice_payment_term_id:
            //             if is_draft:
            //                 tax_amount_currency = 0.0
            //                 tax_amount = tax_amount_currency
            //                 untaxed_amount_currency = 0.0
            //                 untaxed_amount = untaxed_amount_currency
            //                 sign = invoice.direction_sign
            //                 base_lines, _tax_lines = invoice._get_rounded_base_and_tax_lines(round_from_tax_lines=False)
            //                 AccountTax._add_accounting_data_in_base_lines_tax_details(base_lines, invoice.company_id, include_caba_tags=invoice.always_tax_exigible)
            //                 tax_results = AccountTax._prepare_tax_lines(base_lines, invoice.company_id)
            //                 for base_line, to_update in tax_results['base_lines_to_update']:
            //                     untaxed_amount_currency += sign * to_update['amount_currency']
            //                     untaxed_amount += sign * to_update['balance']
            //                 for tax_line_vals in tax_results['tax_lines_to_add']:
            //                     tax_amount_currency += sign * tax_line_vals['amount_currency']
            //                     tax_amount += sign * tax_line_vals['balance']
            //             else:
            //                 tax_amount_currency = invoice.amount_tax * sign
            //                 tax_amount = invoice.amount_tax_signed
            //                 untaxed_amount_currency = invoice.amount_untaxed * sign
            //                 untaxed_amount = invoice.amount_untaxed_signed
            //             invoice_payment_terms = invoice.invoice_payment_term_id._compute_terms(
            //                 date_ref=invoice.invoice_date or invoice.date or fields.Date.context_today(invoice),
            //                 currency=invoice.currency_id,
            //                 tax_amount_currency=tax_amount_currency,
            //                 tax_amount=tax_amount,
            //                 untaxed_amount_currency=untaxed_amount_currency,
            //                 untaxed_amount=untaxed_amount,
            //                 company=invoice.company_id,
            //                 cash_rounding=invoice.invoice_cash_rounding_id,
            //                 sign=sign
            //             )
            //             for term_line in invoice_payment_terms['line_ids']:
            //                 key = frozendict({
            //                     'move_id': invoice.id,
            //                     'date_maturity': fields.Date.to_date(term_line.get('date')),
            //                     'discount_date': invoice_payment_terms.get('discount_date'),
            //                 })
            //                 values = {
            //                     'balance': term_line['company_amount'],
            //                     'amount_currency': term_line['foreign_amount'],
            //                     'discount_date': invoice_payment_terms.get('discount_date'),
            //                     'discount_balance': invoice_payment_terms.get('discount_balance') or 0.0,
            //                     'discount_amount_currency': invoice_payment_terms.get('discount_amount_currency') or 0.0,
            //                 }
            //                 if key not in invoice.needed_terms:
            //                     invoice.needed_terms[key] = values
            //                 else:
            //                     invoice.needed_terms[key]['balance'] += values['balance']
            //                     invoice.needed_terms[key]['amount_currency'] += values['amount_currency']
            //         else:
            //             invoice.needed_terms[frozendict({
            //                 'move_id': invoice.id,
            //                 'date_maturity': fields.Date.to_date(invoice.invoice_date_due),
            //                 'discount_date': False,
            //                 'discount_balance': 0.0,
            //                 'discount_amount_currency': 0.0
            //             })] = {
            //                 'balance': invoice.amount_total_signed,
            //                 'amount_currency': invoice.amount_total_in_currency_signed,
            //             }
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: account_move.py) ---
            // def _compute_needed_terms(self):
            // # EXTENDS account
            // # We want to set the account destination based on the 'payment_mode'.
            // super()._compute_needed_terms()
            // for move in self:
            //     if move.expense_sheet_id and move.expense_sheet_id.payment_mode == 'company_account':
            //         term_lines = move.line_ids.filtered(lambda l: l.display_type != 'payment_term')
            //         move.needed_terms = {
            //             frozendict(
            //                 {
            //                     "move_id": move.id,
            //                     "date_maturity": move.expense_sheet_id.accounting_date or fields.Date.context_today(move.expense_sheet_id),
            //                 }
            //             ): {
            //                 "balance": -sum(term_lines.mapped("balance")),
            //                 "amount_currency": -sum(term_lines.mapped("amount_currency")),
            //                 "name": "",
            //                 "account_id": move.expense_sheet_id._get_expense_account_destination(),
            //             }
            //         }
            */
            return default;
        }

        protected async Task<AccountMove> ComputeNextPaymentDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_next_payment_date(self):
            // for move in self:
            //     move.next_payment_date = min([line.payment_date for line in move.line_ids.filtered(lambda l: l.payment_date and not l.reconciled)], default=False)
            */
            return default;
        }

        protected async Task<AccountMove> ComputeOriginPoCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def _compute_origin_po_count(self):
            // for move in self:
            //     move.purchase_order_count = len(move.line_ids.purchase_line_id.order_id)
            */
            return default;
        }

        protected async Task<AccountMove> ComputeOriginSoCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move.py) ---
            // def _compute_origin_so_count(self):
            // for move in self:
            //     move.sale_order_count = len(move.line_ids.sale_line_ids.order_id)
            */
            return default;
        }

        protected async Task<AccountMove> ComputePartnerBankIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_partner_bank_id(self):
            // for move in self:
            //     # This will get the bank account from the partner in an order with the trusted first
            //     bank_ids = move.bank_partner_id.bank_ids.filtered(
            //         lambda bank: not bank.company_id or bank.company_id == move.company_id
            //     ).sorted(lambda bank: not bank.allow_out_payment)
            //     move.partner_bank_id = bank_ids[:1]
            */
            return default;
        }

        protected async Task<AccountMove> ComputePartnerCreditInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_partner_credit(self):
            // for move in self:
            //     move.partner_credit = move.partner_id.commercial_partner_id.credit
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move.py) ---
            // def _compute_partner_credit(self):
            // super()._compute_partner_credit()
            // for move in self.filtered(lambda m: m.is_invoice(include_receipts=True)):
            //     sale_orders = move.line_ids.sale_line_ids.order_id
            //     amount_total_currency = move.tax_totals['total_amount_currency']
            //     amount_to_invoice_currency = sum(
            //         sale_order.currency_id._convert(
            //             sale_order.amount_to_invoice,
            //             move.company_currency_id,
            //             move.company_id,
            //             move.date
            //         ) for sale_order in sale_orders
            //     )
            //     move.partner_credit += max(amount_total_currency - amount_to_invoice_currency, 0.0)
            */
            return default;
        }

        protected async Task<AccountMove> ComputePartnerCreditWarningInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_partner_credit_warning(self):
            // for move in self:
            //     move.with_company(move.company_id)
            //     move.partner_credit_warning = ''
            //     show_warning = move.state == 'draft' and \
            //                    move.move_type == 'out_invoice' and \
            //                    move.company_id.account_use_credit_limit
            //     if show_warning:
            //         total_field = 'total_amount_currency' if move.currency_id == move.company_currency_id else 'total_amount'
            //         current_amount = move.tax_totals[total_field]
            //         move.partner_credit_warning = self._build_credit_warning_message(
            //             move,
            //             current_amount=current_amount,
            //             exclude_amount=move._get_partner_credit_warning_exclude_amount(),
            //         )
            */
            return default;
        }

        protected async Task<AccountMove> ComputePartnerShippingIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_partner_shipping_id(self):
            // for move in self:
            //     if move.is_invoice(include_receipts=True):
            //         addr = move.partner_id.address_get(['delivery'])
            //         move.partner_shipping_id = addr and addr.get('delivery')
            //     else:
            //         move.partner_shipping_id = False
            */
            return default;
        }

        protected async Task<AccountMove> ComputePaymentCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_payment_count(self):
            // for invoice in self:
            //     invoice.payment_count = len(invoice.matched_payment_ids)
            */
            return default;
        }

        protected async Task<AccountMove> ComputePaymentReferenceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_payment_reference(self):
            // for move in self.filtered(lambda m: (
            //     m.state == 'posted'
            //     and m.move_type == 'out_invoice'
            //     and not m.payment_reference
            // )):
            //     move.payment_reference = move._get_invoice_computed_reference()
            // self._inverse_payment_reference()
            */
            return default;
        }

        protected async Task<AccountMove> ComputePaymentStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_payment_state(self):
            // groups = self.grouped(lambda move:
            //     'legacy' if move.payment_state == 'invoicing_legacy' else
            //     'posted_invoice' if move.state == 'posted' and move.is_invoice(True) else
            //     'blocked' if move.payment_state == 'blocked' else
            //     'unpaid'
            // )
            // groups.get('unpaid', self.browse()).payment_state = 'not_paid'
            // posted_invoices = groups.get('posted_invoice', self.browse())
            // 
            // stored_ids = tuple(posted_invoices.ids)
            // if stored_ids:
            //     self.env['account.partial.reconcile'].flush_model()
            //     self.env['account.payment'].flush_model(['is_matched'])
            // 
            //     queries = []
            //     for source_field, counterpart_field in (
            //         ('debit_move_id', 'credit_move_id'),
            //         ('credit_move_id', 'debit_move_id'),
            //     ):
            //         queries.append(SQL('''
            //             SELECT
            //                 source_line.id AS source_line_id,
            //                 source_line.move_id AS source_move_id,
            //                 account.account_type AS source_line_account_type,
            //                 ARRAY_AGG(counterpart_move.move_type) AS counterpart_move_types,
            //                 COALESCE(BOOL_AND(COALESCE(pay.is_matched, FALSE))
            //                     FILTER (WHERE counterpart_move.origin_payment_id IS NOT NULL), TRUE) AS all_payments_matched,
            //                 BOOL_OR(COALESCE(BOOL(pay.id), FALSE)) as has_payment,
            //                 BOOL_OR(COALESCE(BOOL(counterpart_move.statement_line_id), FALSE)) as has_st_line
            //             FROM account_partial_reconcile part
            //             JOIN account_move_line source_line ON source_line.id = part.%s
            //             JOIN account_account account ON account.id = source_line.account_id
            //             JOIN account_move_line counterpart_line ON counterpart_line.id = part.%s
            //             JOIN account_move counterpart_move ON counterpart_move.id = counterpart_line.move_id
            //             LEFT JOIN account_payment pay ON pay.id = counterpart_move.origin_payment_id
            //             WHERE source_line.move_id IN %s AND counterpart_line.move_id != source_line.move_id
            //             GROUP BY source_line.id, source_line.move_id, account.account_type
            //         ''', SQL.identifier(source_field), SQL.identifier(counterpart_field), stored_ids))
            // 
            //     payment_data = defaultdict(list)
            //     for row in self.env.execute_query_dict(SQL(" UNION ALL ").join(queries)):
            //         payment_data[row['source_move_id']].append(row)
            // else:
            //     payment_data = {}
            // 
            // for invoice in posted_invoices:
            //     currencies = invoice._get_lines_onchange_currency().currency_id
            //     currency = currencies if len(currencies) == 1 else invoice.company_id.currency_id
            //     reconciliation_vals = payment_data.get(invoice.id, [])
            // 
            //     # Restrict on 'receivable'/'payable' lines for invoices/expense entries.
            //     reconciliation_vals = [x for x in reconciliation_vals if x['source_line_account_type'] in ('asset_receivable', 'liability_payable')]
            // 
            //     new_pmt_state = 'not_paid'
            //     if currency.is_zero(invoice.amount_residual):
            //         if any(x['has_payment'] or x['has_st_line'] for x in reconciliation_vals):
            // 
            //             # Check if the invoice/expense entry is fully paid or 'in_payment'.
            //             if all(x['all_payments_matched'] for x in reconciliation_vals):
            //                 new_pmt_state = 'paid'
            //             else:
            //                 new_pmt_state = invoice._get_invoice_in_payment_state()
            // 
            //         else:
            //             new_pmt_state = 'paid'
            // 
            //             reverse_move_types = set()
            //             for x in reconciliation_vals:
            //                 for move_type in x['counterpart_move_types']:
            //                     reverse_move_types.add(move_type)
            // 
            //             in_reverse = (invoice.move_type in ('in_invoice', 'in_receipt')
            //                             and (reverse_move_types == {'in_refund'} or reverse_move_types == {'in_refund', 'entry'}))
            //             out_reverse = (invoice.move_type in ('out_invoice', 'out_receipt')
            //                             and (reverse_move_types == {'out_refund'} or reverse_move_types == {'out_refund', 'entry'}))
            //             misc_reverse = (invoice.move_type in ('entry', 'out_refund', 'in_refund')
            //                             and reverse_move_types == {'entry'})
            //             if in_reverse or out_reverse or misc_reverse:
            //                 new_pmt_state = 'reversed'
            //     elif invoice.matched_payment_ids.filtered(lambda p: not p.move_id and p.state == 'in_process'):
            //         new_pmt_state = invoice._get_invoice_in_payment_state()
            //     elif reconciliation_vals:
            //         new_pmt_state = 'partial'
            //     elif invoice.matched_payment_ids.filtered(lambda p: not p.move_id and p.state == 'paid'):
            //         new_pmt_state = invoice._get_invoice_in_payment_state()
            //     invoice.payment_state = new_pmt_state
            */
            return default;
        }

        protected async Task<AccountMove> ComputePaymentTermDetailsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_payment_term_details(self):
            // '''
            // Returns an [] containing the payment term's information to be displayed on the invoice's PDF.
            // '''
            // for invoice in self:
            //     invoice.payment_term_details = False
            //     if invoice.show_payment_term_details:
            //         sign = 1 if invoice.is_inbound(include_receipts=True) else -1
            //         payment_term_details = []
            //         for line in invoice.line_ids.filtered(lambda l: l.display_type == 'payment_term').sorted('date_maturity'):
            //             payment_term_details.append({
            //                 'date': format_date(self.env, line.date_maturity),
            //                 'amount': sign * line.amount_currency,
            //             })
            //         invoice.payment_term_details = payment_term_details
            */
            return default;
        }

        protected async Task<AccountMove> ComputePaymentsWidgetReconciledInfoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_payments_widget_reconciled_info(self):
            // for move in self:
            //     payments_widget_vals = {'title': _('Less Payment'), 'outstanding': False, 'content': []}
            // 
            //     if move.state == 'posted' and move.is_invoice(include_receipts=True):
            //         reconciled_vals = []
            //         reconciled_partials = move.sudo()._get_all_reconciled_invoice_partials()
            //         for reconciled_partial in reconciled_partials:
            //             counterpart_line = reconciled_partial['aml']
            //             if counterpart_line.move_id.ref:
            //                 reconciliation_ref = '%s (%s)' % (counterpart_line.move_id.name, counterpart_line.move_id.ref)
            //             else:
            //                 reconciliation_ref = counterpart_line.move_id.name
            //             if counterpart_line.amount_currency and counterpart_line.currency_id != counterpart_line.company_id.currency_id:
            //                 foreign_currency = counterpart_line.currency_id
            //             else:
            //                 foreign_currency = False
            // 
            //             reconciled_vals.append({
            //                 'name': counterpart_line.name,
            //                 'journal_name': counterpart_line.journal_id.name,
            //                 'company_name': counterpart_line.journal_id.company_id.name if counterpart_line.journal_id.company_id != move.company_id else False,
            //                 'amount': reconciled_partial['amount'],
            //                 'currency_id': move.company_id.currency_id.id if reconciled_partial['is_exchange'] else reconciled_partial['currency'].id,
            //                 'date': counterpart_line.date,
            //                 'partial_id': reconciled_partial['partial_id'],
            //                 'account_payment_id': counterpart_line.payment_id.id,
            //                 'payment_method_name': counterpart_line.payment_id.payment_method_line_id.name,
            //                 'move_id': counterpart_line.move_id.id,
            //                 'is_refund': counterpart_line.move_id.move_type in ['in_refund', 'out_refund'],
            //                 'ref': reconciliation_ref,
            //                 # these are necessary for the views to change depending on the values
            //                 'is_exchange': reconciled_partial['is_exchange'],
            //                 'amount_company_currency': formatLang(self.env, abs(counterpart_line.balance), currency_obj=counterpart_line.company_id.currency_id),
            //                 'amount_foreign_currency': foreign_currency and formatLang(self.env, abs(counterpart_line.amount_currency), currency_obj=foreign_currency)
            //             })
            //         payments_widget_vals['content'] = reconciled_vals
            // 
            //     if payments_widget_vals['content']:
            //         move.invoice_payments_widget = payments_widget_vals
            //     else:
            //         move.invoice_payments_widget = False
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: account_move.py) ---
            // def _compute_payments_widget_reconciled_info(self):
            // """Add pos_payment_name field in the reconciled vals to be able to show the payment method in the invoice."""
            // super()._compute_payments_widget_reconciled_info()
            // for move in self:
            //     if move.invoice_payments_widget:
            //         if move.state == 'posted' and move.is_invoice(include_receipts=True):
            //             reconciled_partials = move._get_all_reconciled_invoice_partials()
            //             for i, reconciled_partial in enumerate(reconciled_partials):
            //                 counterpart_line = reconciled_partial['aml']
            //                 pos_payment = counterpart_line.move_id.sudo().pos_payment_ids[:1]
            //                 move.invoice_payments_widget['content'][i].update({
            //                     'pos_payment_name': pos_payment.payment_method_id.name,
            //                 })
            */
            return default;
        }

        protected async Task<AccountMove> ComputePaymentsWidgetToReconcileInfoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_payments_widget_to_reconcile_info(self):
            // for move in self:
            //     move.invoice_outstanding_credits_debits_widget = False
            //     move.invoice_has_outstanding = False
            // 
            //     if move.state != 'posted' \
            //             or move.payment_state not in ('not_paid', 'partial') \
            //             or not move.is_invoice(include_receipts=True):
            //         continue
            // 
            //     pay_term_lines = move.line_ids\
            //         .filtered(lambda line: line.account_id.account_type in ('asset_receivable', 'liability_payable'))
            // 
            //     domain = [
            //         ('account_id', 'in', pay_term_lines.account_id.ids),
            //         ('parent_state', '=', 'posted'),
            //         ('partner_id', '=', move.commercial_partner_id.id),
            //         ('reconciled', '=', False),
            //         '|', ('amount_residual', '!=', 0.0), ('amount_residual_currency', '!=', 0.0),
            //     ]
            // 
            //     payments_widget_vals = {'outstanding': True, 'content': [], 'move_id': move.id}
            // 
            //     if move.is_inbound():
            //         domain.append(('balance', '<', 0.0))
            //         payments_widget_vals['title'] = _('Outstanding credits')
            //     else:
            //         domain.append(('balance', '>', 0.0))
            //         payments_widget_vals['title'] = _('Outstanding debits')
            // 
            //     for line in self.env['account.move.line'].search(domain):
            // 
            //         if line.currency_id == move.currency_id:
            //             # Same foreign currency.
            //             amount = abs(line.amount_residual_currency)
            //         else:
            //             # Different foreign currencies.
            //             amount = line.company_currency_id._convert(
            //                 abs(line.amount_residual),
            //                 move.currency_id,
            //                 move.company_id,
            //                 line.date,
            //             )
            // 
            //         if move.currency_id.is_zero(amount):
            //             continue
            // 
            //         payments_widget_vals['content'].append({
            //             'journal_name': line.ref or line.move_id.name,
            //             'amount': amount,
            //             'currency_id': move.currency_id.id,
            //             'id': line.id,
            //             'move_id': line.move_id.id,
            //             'date': fields.Date.to_string(line.date),
            //             'account_payment_id': line.payment_id.id,
            //         })
            // 
            //     if not payments_widget_vals['content']:
            //         continue
            // 
            //     move.invoice_outstanding_credits_debits_widget = payments_widget_vals
            //     move.invoice_has_outstanding = True
            */
            return default;
        }

        protected async Task<AccountMove> ComputePeppolMoveStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: account_move.py) ---
            // def _compute_peppol_move_state(self):
            // can_send = self.env['account_edi_proxy_client.user']._get_can_send_domain()
            // for move in self:
            //     if all([
            //         move.company_id.account_peppol_proxy_state in can_send,
            //         move.commercial_partner_id.peppol_verification_state == 'valid',
            //         move.state == 'posted',
            //         move.is_sale_document(include_receipts=True),
            //         not move.peppol_move_state,
            //     ]):
            //         move.peppol_move_state = 'ready'
            //     elif (
            //         move.state == 'draft'
            //         and move.is_sale_document(include_receipts=True)
            //         and move.peppol_move_state not in ('processing', 'done')
            //     ):
            //         move.peppol_move_state = False
            //     else:
            //         move.peppol_move_state = move.peppol_move_state
            */
            return default;
        }

        protected async Task<AccountMove> ComputePreferredPaymentMethodLineIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_preferred_payment_method_line_id(self):
            // for move in self:
            //     partner = move.partner_id.with_company(move.company_id)
            //     if move.is_sale_document():
            //         move.preferred_payment_method_line_id = partner.property_inbound_payment_method_line_id
            //     else:
            //         move.preferred_payment_method_line_id = partner.property_outbound_payment_method_line_id
            */
            return default;
        }

        protected async Task<AccountMove> ComputePurchaseOrderNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def _compute_purchase_order_name(self):
            // for move in self:
            //     if move.purchase_order_count == 1:
            //         move.purchase_order_name = move.invoice_line_ids.purchase_order_id.display_name
            //     else:
            //         move.purchase_order_name = False
            */
            return default;
        }

        protected async Task<AccountMove> ComputeQuickEditModeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_quick_edit_mode(self):
            // for move in self:
            //     quick_edit_mode = move.company_id.quick_edit_mode
            //     if move.journal_id.type == 'sale':
            //         move.quick_edit_mode = quick_edit_mode in ('out_invoices', 'out_and_in_invoices')
            //     elif move.journal_id.type == 'purchase':
            //         move.quick_edit_mode = quick_edit_mode in ('in_invoices', 'out_and_in_invoices')
            //     else:
            //         move.quick_edit_mode = False
            */
            return default;
        }

        protected async Task<AccountMove> ComputeQuickEncodingValsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_quick_encoding_vals(self):
            // for move in self:
            //     move.quick_encoding_vals = move._get_quick_edit_suggestions()
            */
            return default;
        }

        protected async Task<AccountMove> ComputeSecuredInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_secured(self):
            // for move in self:
            //     move.secured = bool(move.inalterable_hash)
            */
            return default;
        }

        protected async Task<AccountMove> ComputeShowCommercialPartnerWarningInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: account_move.py) ---
            // def _compute_show_commercial_partner_warning(self):
            // for move in self:
            //     move.show_commercial_partner_warning = (
            //             move.commercial_partner_id == self.env.company.partner_id
            //             and move.move_type == 'in_invoice'
            //             and move.partner_id.sudo().employee_ids
            //     )
            */
            return default;
        }

        protected async Task<AccountMove> ComputeShowDeliveryDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_show_delivery_date(self):
            // for move in self:
            //     move.show_delivery_date = move.delivery_date and move.is_sale_document()
            */
            return default;
        }

        protected async Task<AccountMove> ComputeShowPaymentTermDetailsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_show_payment_term_details(self):
            // '''
            // Determines :
            // - whether or not an additional table should be added at the end of the invoice to display the various
            // - whether or not there is an early pay discount in this invoice that should be displayed
            // '''
            // for invoice in self:
            //     if invoice.move_type in ('out_invoice', 'out_receipt', 'in_invoice', 'in_receipt') and invoice.payment_state in ('not_paid', 'partial'):
            //         payment_term_lines = invoice.line_ids.filtered(lambda l: l.display_type == 'payment_term')
            //         invoice.show_discount_details = invoice.invoice_payment_term_id.early_discount
            //         invoice.show_payment_term_details = len(payment_term_lines) > 1 or invoice.show_discount_details
            //     else:
            //         invoice.show_discount_details = False
            //         invoice.show_payment_term_details = False
            */
            return default;
        }

        protected async Task<AccountMove> ComputeShowResetToDraftButtonInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_show_reset_to_draft_button(self):
            // for move in self:
            //     move.show_reset_to_draft_button = (
            //         not self._is_move_restricted(move) \
            //         and not move.inalterable_hash
            //         and (move.state == 'cancel' or (move.state == 'posted' and not move.need_cancel_request))
            //     )
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _compute_show_reset_to_draft_button(self):
            // # OVERRIDE
            // super()._compute_show_reset_to_draft_button()
            // for move in self:
            //     if not move._check_edi_documents_for_reset_to_draft():
            //         move.show_reset_to_draft_button = False
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move.py) ---
            // def _compute_show_reset_to_draft_button(self):
            // super()._compute_show_reset_to_draft_button()
            // for move in self:
            //     if move.sudo().line_ids.stock_valuation_layer_ids:
            //         move.show_reset_to_draft_button = False
            */
            return default;
        }

        protected async Task<AccountMove> ComputeStatusInPaymentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_status_in_payment(self):
            // for move in self:
            //     move.status_in_payment = move.state if move.state in ('draft', 'cancel') else move.payment_state
            */
            return default;
        }

        protected async Task<AccountMove> ComputeSuitableJournalIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_suitable_journal_ids(self):
            // for m in self:
            //     journal_type = m.invoice_filter_type_domain or 'general'
            //     company = m.company_id or self.env.company
            //     m.suitable_journal_ids = self.env['account.journal'].search([
            //         *self.env['account.journal']._check_company_domain(company),
            //         ('type', '=', journal_type),
            //     ])
            */
            return default;
        }

        protected async Task<AccountMove> ComputeTaxCountryCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_tax_country_code(self):
            // for record in self:
            //     record.tax_country_code = record.tax_country_id.code
            */
            return default;
        }

        protected async Task<AccountMove> ComputeTaxCountryIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_tax_country_id(self):
            // foreign_vat_records = self.filtered(lambda r: r.fiscal_position_id.foreign_vat)
            // for fiscal_position_id, record_group in groupby(foreign_vat_records, key=lambda r: r.fiscal_position_id):
            //     self.env['account.move'].concat(*record_group).tax_country_id = fiscal_position_id.country_id
            // for company_id, record_group in groupby((self-foreign_vat_records), key=lambda r: r.company_id):
            //     self.env['account.move'].concat(*record_group).tax_country_id = company_id.account_fiscal_country_id
            */
            return default;
        }

        protected async Task<AccountMove> ComputeTaxLockDateMessageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_tax_lock_date_message(self):
            // for move in self:
            //     accounting_date = move.date or fields.Date.context_today(move)
            //     affects_tax_report = move._affect_tax_report()
            //     move.tax_lock_date_message = move._get_lock_date_message(accounting_date, affects_tax_report)
            */
            return default;
        }

        protected async Task<AccountMove> ComputeTaxTotalsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_tax_totals(self):
            // """ Computed field used for custom widget's rendering.
            //     Only set on invoices.
            // """
            // for move in self:
            //     if move.is_invoice(include_receipts=True):
            //         base_lines, _tax_lines = move._get_rounded_base_and_tax_lines()
            //         move.tax_totals = self.env['account.tax']._get_tax_totals_summary(
            //             base_lines=base_lines,
            //             currency=move.currency_id,
            //             company=move.company_id,
            //             cash_rounding=move.invoice_cash_rounding_id,
            //         )
            //         move.tax_totals['display_in_company_currency'] = (
            //             move.company_id.display_invoice_tax_company_currency
            //             and move.company_currency_id != move.currency_id
            //             and move.tax_totals['has_tax_groups']
            //             and move.is_sale_document(include_receipts=True)
            //         )
            //     else:
            //         # Non-invoice moves don't support that field (because of multicurrency: all lines of the invoice share the same currency)
            //         move.tax_totals = None
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: account_move.py) ---
            // def _compute_tax_totals(self):
            // return super(AccountMove, self.with_context(linked_to_pos=bool(self.sudo().pos_order_ids)))._compute_tax_totals()
            */
            return default;
        }

        protected async Task<AccountMove> ComputeTaxesLegalNotesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_taxes_legal_notes(self):
            // for move in self:
            //     move.taxes_legal_notes = ''.join(
            //         tax.invoice_legal_notes
            //         for tax in OrderedSet(move.line_ids.tax_ids)
            //         if not is_html_empty(tax.invoice_legal_notes)
            //     )
            */
            return default;
        }

        protected async Task<AccountMove> ComputeTeamIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move.py) ---
            // def _compute_team_id(self):
            // sale_moves = self.filtered(lambda move: move.is_sale_document(include_receipts=True))
            // for ((user_id, company_id), moves) in groupby(
            //     sale_moves,
            //     key=lambda m: (m.invoice_user_id.id, m.company_id.id)
            // ):
            //     self.env['account.move'].concat(*moves).team_id = self.env['crm.team'].with_context(
            //         allowed_company_ids=[company_id],
            //     )._get_default_team_id(
            //         user_id=user_id,
            //     )
            */
            return default;
        }

        protected async Task<AccountMove> ComputeTimesheetCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: account_move.py) ---
            // def _compute_timesheet_count(self):
            // timesheet_data = self.env['account.analytic.line']._read_group([('timesheet_invoice_id', 'in', self.ids)], ['timesheet_invoice_id'], ['__count'])
            // mapped_data = {timesheet_invoice.id: count for timesheet_invoice, count in timesheet_data}
            // for invoice in self:
            //     invoice.timesheet_count = mapped_data.get(invoice.id, 0)
            */
            return default;
        }

        protected async Task<AccountMove> ComputeTimesheetTotalDurationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: account_move.py) ---
            // def _compute_timesheet_total_duration(self):
            // if not self.env.user.has_group('hr_timesheet.group_hr_timesheet_user'):
            //     self.timesheet_total_duration = 0
            //     return
            // group_data = self.env['account.analytic.line']._read_group([
            //     ('timesheet_invoice_id', 'in', self.ids)
            // ], ['timesheet_invoice_id'], ['unit_amount:sum'])
            // timesheet_unit_amount_dict = defaultdict(float)
            // timesheet_unit_amount_dict.update({timesheet_invoice.id: amount for timesheet_invoice, amount in group_data})
            // for invoice in self:
            //     total_time = invoice.company_id.project_time_mode_id._compute_quantity(
            //         timesheet_unit_amount_dict[invoice.id],
            //         invoice.timesheet_encode_uom_id,
            //         rounding_method='HALF-UP',
            //     )
            //     invoice.timesheet_total_duration = round(total_time)
            */
            return default;
        }

        protected async Task<AccountMove> ComputeTransactionCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: account_move.py) ---
            // def _compute_transaction_count(self):
            // for invoice in self:
            //     invoice.transaction_count = len(invoice.transaction_ids)
            */
            return default;
        }

        protected async Task<AccountMove> ComputeTypeNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_type_name(self):
            // type_name_mapping = dict(
            //     self._fields['move_type']._description_selection(self.env),
            //     out_invoice=_('Invoice'),
            //     out_refund=_('Credit Note'),
            // )
            // 
            // for record in self:
            //     record.type_name = type_name_mapping[record.move_type]
            */
            return default;
        }

        protected async Task<AccountMove> ComputeWebsiteIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: account_move.py) ---
            // def _compute_website_id(self):
            // for move in self:
            //     source_websites = move.line_ids.sale_line_ids.order_id.website_id
            //     if len(source_websites) == 1:
            //         move.website_id = source_websites
            //     else:
            //         move.website_id = False
            */
            return default;
        }

        protected async Task<AccountMove> ComputeWipProductionCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: account_move.py) ---
            // def _compute_wip_production_count(self):
            // for account in self:
            //     account.wip_production_count = len(account.wip_production_ids)
            */
            return default;
        }

        protected async Task<AccountMove> ConditionalAddToComputeInternalAsync(object fname, object condition)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _conditional_add_to_compute(self, fname, condition):
            // field = self._fields[fname]
            // to_reset = self.filtered(lambda move:
            //     condition(move)
            //     and not self.env.is_protected(field, move._origin)
            //     and (move._origin or not move[fname])
            // )
            // to_reset.invalidate_recordset([fname])
            // self.env.add_to_compute(field, to_reset)
            */
            return default;
        }

        public async Task<AccountMove> CopyDataAsync(Guid id, AccountMoveCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default)
            // default_date = fields.Date.to_date(default.get('date'))
            // for move, vals in zip(self, vals_list):
            //     if move.move_type in ('out_invoice', 'in_invoice'):
            //         vals['line_ids'] = [
            //             (command, _id, line_vals)
            //             for command, _id, line_vals in vals['line_ids']
            //             if command == Command.CREATE
            //         ]
            //     elif move.move_type == 'entry':
            //         if 'partner_id' not in vals:
            //             vals['partner_id'] = False
            //     user_fiscal_lock_date = move.company_id._get_user_fiscal_lock_date(move.journal_id)
            //     if (default_date or move.date) <= user_fiscal_lock_date:
            //         vals['date'] = user_fiscal_lock_date + timedelta(days=1)
            //     if not move.journal_id.active and 'journal_id' in vals:
            //         del vals['journal_id']
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move.py) ---
            // def copy_data(self, default=None):
            // # Don't keep anglo-saxon lines when copying a journal entry.
            // vals_list = super().copy_data(default=default)
            // 
            // if not self._context.get('move_reverse_cancel'):
            //     for vals in vals_list:
            //         if 'line_ids' in vals:
            //             vals['line_ids'] = [line_vals for line_vals in vals['line_ids']
            //                                      if line_vals[0] != 0 or line_vals[2].get('display_type') != 'cogs']
            // return vals_list
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> CopyRecurringEntriesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _copy_recurring_entries(self):
            // ''' Creates a copy of a recurring (periodic) entry and adjusts its dates for the next period.
            // Meant to be called right after posting a periodic entry.
            // Copies extra fields as defined by _get_fields_to_copy_recurring_entries().
            // '''
            // for record in self:
            //     record.auto_post_origin_id = record.auto_post_origin_id or record  # original entry references itself
            //     next_date = self._apply_delta_recurring_entries(record.date, record.auto_post_origin_id.date, record.auto_post)
            // 
            //     if not record.auto_post_until or next_date <= record.auto_post_until:  # recurrence continues
            //         record.copy(default=record._get_fields_to_copy_recurring_entries({'date': next_date}))
            */
            return default;
        }

        public override async Task<AccountMove> CreateAsync(AccountMove entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def create(self, vals_list):
            // if any('state' in vals and vals.get('state') == 'posted' for vals in vals_list):
            //     raise UserError(_('You cannot create a move already in the posted state. Please create a draft move and post it after.'))
            // container = {'records': self}
            // with self._check_balanced(container):
            //     with ExitStack() as exit_stack, self._sync_dynamic_lines(container):
            //         for vals in vals_list:
            //             self._sanitize_vals(vals)
            //         stolen_moves = self.browse(set(move for vals in vals_list for move in self._stolen_move(vals)))
            //         moves = super().create(vals_list)
            //         exit_stack.enter_context(self.env.protecting([protected for vals, move in zip(vals_list, moves) for protected in self._get_protected_vals(vals, move)]))
            //         container['records'] = moves | stolen_moves
            //     for move, vals in zip(moves, vals_list):
            //         if 'tax_totals' in vals:
            //             move.tax_totals = vals['tax_totals']
            //     moves.is_manually_modified = False
            // return moves
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def create(self, vals_list):
            // # OVERRIDE
            // moves = super(AccountMove, self).create(vals_list)
            // for move in moves:
            //     if move.reversed_entry_id:
            //         continue
            //     purchases = move.line_ids.purchase_line_id.order_id
            //     if not purchases:
            //         continue
            //     refs = [purchase._get_html_link() for purchase in purchases]
            //     message = _("This vendor bill has been created from: ") + Markup(',').join(refs)
            //     move.message_post(body=message)
            // return moves
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<AccountMove> CreationMessageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _creation_message(self):
            // # EXTENDS mail mail.thread
            // if not self.is_invoice(include_receipts=True):
            //     return super()._creation_message()
            // return {
            //     'out_invoice': _('Invoice Created'),
            //     'out_refund': _('Credit Note Created'),
            //     'in_invoice': _('Vendor Bill Created'),
            //     'in_refund': _('Refund Created'),
            //     'out_receipt': _('Sales Receipt Created'),
            //     'in_receipt': _('Purchase Receipt Created'),
            // }[self.move_type]
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: account_move.py) ---
            // def _creation_message(self):
            // if self.expense_sheet_id:
            //     return _("Expense entry created from: %s", self.expense_sheet_id._get_html_link())
            // return super()._creation_message()
            */
            return default;
        }

        protected async Task<AccountMove> CreationSubtypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _creation_subtype(self):
            // # EXTENDS mail mail.thread
            // if self.move_type in ('out_invoice', 'out_receipt'):
            //     return self.env.ref('account.mt_invoice_created')
            // else:
            //     return super()._creation_subtype()
            */
            return default;
        }

        protected async Task<AccountMove> CronAccountMoveSendInternalAsync(object job_count)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _cron_account_move_send(self, job_count=10):
            // """ Process invoices generation and sending asynchronously.
            // :param job_count: maximum number of jobs to process if specified.
            // """
            // def get_account_notification(moves, is_success: bool):
            //     _ = self.env._
            //     return [
            //         'account_notification',
            //         {
            //             'type': 'success' if is_success else 'warning',
            //             'title': _('Invoices sent') if is_success else _('Invoices in error'),
            //             'message': _('Invoices sent successfully.') if is_success else _(
            //                 "One or more invoices couldn't be processed."),
            //             'action_button': {
            //                 'name': _('Open'),
            //                 'action_name': _('Sent invoices') if is_success else _('Invoices in error'),
            //                 'model': 'account.move',
            //                 'res_ids': moves.ids,
            //             },
            //         },
            //     ]
            // 
            // limit = job_count + 1
            // to_process = self.env['account.move'].search(
            //     [('sending_data', '!=', False)],
            //     limit=limit,
            // )
            // total_to_process = self.env['account.move'].search_count(
            //     [('sending_data', '!=', False)],
            // )
            // 
            // need_retrigger = len(to_process) > job_count
            // if not to_process:
            //     return
            // 
            // to_process = to_process[:job_count]
            // if not self.env['res.company']._with_locked_records(to_process, allow_raising=False):
            //     return
            // 
            // # Collect moves by res.partner that executed the Send & Print wizard, must be done before the _process
            // # that modify sending_data.
            // moves_by_partner = to_process.grouped(lambda m: m.sending_data['author_partner_id'])
            // 
            // self.env['account.move.send']._generate_and_send_invoices(
            //     to_process,
            //     from_cron=True,
            // )
            // self.env['ir.cron']._notify_progress(done=len(to_process),
            //                                      remaining=total_to_process - len(to_process))
            // 
            // for partner_id, partner_moves in moves_by_partner.items():
            //     partner = self.env['res.partner'].browse(partner_id)
            //     partner_moves_error = partner_moves.filtered(lambda m: m.sending_data and m.sending_data.get('error'))
            //     if partner_moves_error:
            //         partner._bus_send(*get_account_notification(partner_moves_error, False))
            //     partner_moves_success = partner_moves - partner_moves_error
            //     if partner_moves_success:
            //         partner._bus_send(*get_account_notification(partner_moves_success, True))
            //     partner_moves_error.sending_data = False
            // 
            // if need_retrigger:
            //     self.env.ref('account.ir_cron_account_move_send')._trigger()
            */
            return default;
        }

        public async Task<AccountMove> DebitNoteAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_debit_note, FILE: account_move.py) ---
            // def action_debit_note(self):
            // action = self.env.ref('account_debit_note.action_view_account_move_debit')._get_action_dict()
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> DefaultOrderLineValuesInternalAsync(object child_field)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _default_order_line_values(self, child_field=False):
            // default_data = super()._default_order_line_values(child_field)
            // new_default_data = self.env['account.move.line']._get_product_catalog_lines_data()
            // return {**default_data, **new_default_data}
            */
            return default;
        }

        protected async Task<AccountMove> DetachAttachmentsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _detach_attachments(self):
            // """
            // Called by button_draft to detach specific attachments for the current journal entries to allow regeneration.
            // """
            // files_to_detach = self.sudo().env['ir.attachment'].search([
            //     ('res_model', '=', 'account.move'),
            //     ('res_id', 'in', self.ids),
            //     ('res_field', 'in', self._get_fields_to_detach()),
            // ])
            // if files_to_detach:
            //     files_to_detach.res_field = False
            //     today = format_date(self.env, fields.Date.context_today(self))
            //     for attachment in files_to_detach:
            //         attachment_name, attachment_extension = os.path.splitext(attachment.name)
            //         attachment.name = _(
            //             '%(attachment_name)s (detached by %(user)s on %(date)s)%(attachment_extension)s',
            //             attachment_name=attachment_name,
            //             attachment_extension=attachment_extension,
            //             user=self.env.user.name,
            //             date=today,
            //         )
            */
            return default;
        }

        protected async Task<AccountMove> DisableDiscountPrecisionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _disable_discount_precision(self):
            // """Disable the user defined precision for discounts.
            // 
            // This is useful for importing documents coming from other softwares and providers.
            // The reasonning is that if the document that we are importing has a discount, it
            // shouldn't be rounded to the local settings.
            // """
            // with self._disable_recursion({'records': self}, 'ignore_discount_precision'):
            //     yield
            */
            return default;
        }

        protected async Task<AccountMove> DisableRecursionInternalAsync(object container, object key, object @default, object target)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _disable_recursion(self, container, key, default=None, target=True):
            // """Apply the context key to all environments inside this context manager.
            // 
            // If the value linked to the key is the same as the target, yield `True`.
            // Check for the key both in the record's context and in the recursion stack.
            // 
            // :param container: deprecated, not used anymore
            // :param key: The context key to apply to the recordsets.
            // :param default: the default value of the context key, if it isn't defined
            //                 yet in the context
            // :param target: the value of the context key meaning that we shouldn't
            //                recurse
            // :return: True iff we should just exit the context manager
            // """
            // 
            // stack = self.env.cr.cache.setdefault('account_disable_recursion_stack', StackMap())
            // try:
            //     current_val = stack[key]
            // except KeyError:
            //     current_val = self.env.context.get(key, default)
            // 
            // disabled = current_val == target
            // stack.pushmap({key: target})
            // try:
            //     yield disabled
            // finally:
            //     stack.popmap()
            */
            return default;
        }

        public async Task<AccountMove> DuplicateAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_duplicate(self):
            // # offer the possibility to duplicate thanks to a button instead of a hidden menu, which is more visible
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("account.action_move_journal_line")
            // action['context'] = dict(self.env.context)
            // action['context']['view_no_maturity'] = False
            // action['views'] = [(self.env.ref('account.view_move_form').id, 'form')]
            // action['res_id'] = self.copy().id
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> EdiAllowButtonDraftInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _edi_allow_button_draft(self):
            // self.ensure_one()
            // return not self.edi_show_cancel_button
            */
            return default;
        }

        protected async Task<AccountMove> ExtendWithAttachmentsInternalAsync(object attachments, object @new)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _extend_with_attachments(self, attachments, new=False):
            // """Main entry point to extend/enhance invoices with attachments.
            // 
            // Either coming from:
            // - The chatter when the user drops an attachment on an existing invoice.
            // - The journal when the user drops one or multiple attachments from the dashboard.
            // - The server mail alias when an alias is configured on the journal.
            // 
            // It will unwrap all attachments by priority then try to decode until it succeed.
            // 
            // :param attachments: A recordset of ir.attachment.
            // :param new:         Indicate if the current invoice is a fresh one or an existing one.
            // :returns:           True if at least one document is successfully imported
            // """
            // def close_file(file_data):
            //     if file_data.get('on_close'):
            //         file_data['on_close']()
            // 
            // def add_file_data_results(file_data, invoice):
            //     passed_file_data_list.append(file_data)
            //     attachment = file_data.get('attachment') or file_data.get('originator_pdf')
            //     if attachment:
            //         if attachments_by_invoice.get(attachment):
            //             attachments_by_invoice[attachment] |= invoice
            //         else:
            //             attachments_by_invoice[attachment] = invoice
            //         if not attachment.res_id:
            //             attachment.write({
            //                 'res_id': invoice.id,
            //                 'res_model': invoice._name,
            //             })
            // 
            // file_data_list = attachments._unwrap_edi_attachments()
            // attachments_by_invoice = {}
            // invoices = self
            // current_invoice = self
            // passed_file_data_list = []
            // for file_data in file_data_list:
            // 
            //     # Rogue binaries from mail alias are skipped and unlinked.
            //     if (
            //         file_data['type'] == 'binary'
            //         and self._context.get('from_alias')
            //         and not attachments_by_invoice.get(file_data['attachment'])
            //         and file_data['attachment'].mimetype not in ALLOWED_MIMETYPES
            //     ):
            //         close_file(file_data)
            //         continue
            // 
            //     # The invoice has already been decoded by an embedded file.
            //     if attachments_by_invoice.get(file_data['attachment']):
            //         add_file_data_results(file_data, attachments_by_invoice[file_data['attachment']])
            //         close_file(file_data)
            //         continue
            // 
            //     # When receiving multiple files, if they have a different type, we supposed they are all linked
            //     # to the same invoice.
            //     if (
            //         passed_file_data_list
            //         and passed_file_data_list[-1]['filename'] != file_data['filename']
            //         and passed_file_data_list[-1]['sort_weight'] != file_data['sort_weight']
            //     ):
            //         add_file_data_results(file_data, invoices[-1])
            //         close_file(file_data)
            //         continue
            // 
            //     if passed_file_data_list and not new:
            //         add_file_data_results(file_data, invoices[-1])
            //         close_file(file_data)
            //         continue
            // 
            //     extend_with_existing_lines = file_data.get('process_if_existing_lines', False)
            //     if current_invoice.invoice_line_ids and not extend_with_existing_lines:
            //         continue
            // 
            //     decoder = (current_invoice or current_invoice.new(self.default_get(['move_type', 'journal_id'])))._get_edi_decoder(file_data, new=new)
            //     current_invoice.flush_recordset()
            //     if decoder or file_data['type'] in ('pdf', 'binary'):
            //         try:
            //             with self.env.cr.savepoint():
            //                 invoice = current_invoice or self.create({})
            //                 existing_lines = invoice.invoice_line_ids
            //                 if not decoder and file_data['type'] in ('pdf', 'binary'):
            //                     success = False
            //                 else:
            //                     success = decoder(invoice, file_data, new)
            // 
            //                 if success or file_data['type'] == 'pdf' or file_data['attachment'].mimetype in ALLOWED_MIMETYPES:
            //                     (invoice.invoice_line_ids - existing_lines).is_imported = True
            //                     if not extend_with_existing_lines:
            //                         invoice._link_bill_origin_to_purchase_orders(timeout=4)
            //                     invoices |= invoice
            //                     current_invoice = self.env['account.move']
            //                     add_file_data_results(file_data, invoice)
            // 
            //         except RedirectWarning:
            //             raise
            //         except Exception as e:
            //             message = _(
            //                 "Error importing attachment '%(file_name)s' as invoice (decoder=%(decoder)s)",
            //                 file_name=file_data['filename'],
            //                 decoder=decoder.__name__,
            //             )
            //             _logger.exception(message)
            //             if isinstance(e, UserError):
            //                 message = Markup("%s<br/><br/>%s<br/>%s") % (
            //                     message,
            //                     _("This specific error occurred during the import:"),
            //                     str(e),
            //                 )
            //             current_invoice.sudo().message_post(body=message)
            // 
            //     passed_file_data_list.append(file_data)
            //     close_file(file_data)
            // 
            // return attachments_by_invoice
            */
            return default;
        }

        protected async Task<AccountMove> FetchDuplicateReferenceInternalAsync(object matching_states)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _fetch_duplicate_reference(self, matching_states=('draft', 'posted')):
            // moves = self.filtered(lambda m: m.is_sale_document() or m.is_purchase_document() and m.ref)
            // 
            // if not moves:
            //     return {}
            // 
            // used_fields = ("company_id", "partner_id", "commercial_partner_id", "ref", "move_type", "invoice_date", "state", "amount_total")
            // 
            // self.env["account.move"].flush_model(used_fields)
            // 
            // move_table_and_alias = SQL("account_move AS move")
            // if not moves[0].id:  # check if record is under creation/edition in UI
            //     # New record aren't searchable in the DB and record in edition aren't up to date yet
            //     # Replace the table by safely injecting the values in the query
            //     values = {
            //         field_name: moves._fields[field_name].convert_to_write(moves[field_name], moves) or None
            //         for field_name in used_fields
            //     }
            //     values["id"] = moves._origin.id or 0
            //     # The amount total depends on the field line_ids and is calculated upon saving, we needed a way to get it even when the
            //     # invoices has not been saved yet.
            //     values['amount_total'] = self.tax_totals.get('total_amount_currency', 0)
            //     casted_values = SQL(', ').join(
            //         SQL("%s::%s", value, SQL.identifier(moves._fields[field_name].column_type[0]))
            //         for field_name, value in values.items()
            //     )
            //     column_names = SQL(', ').join(SQL.identifier(field_name) for field_name in values)
            //     move_table_and_alias = SQL("(VALUES (%s)) AS move(%s)", casted_values, column_names)
            // 
            // to_query = []
            // out_moves = moves.filtered(lambda m: m.move_type in ('out_invoice', 'out_refund'))
            // if out_moves:
            //     out_moves_sql_condition = SQL("""
            //         move.move_type in ('out_invoice', 'out_refund')
            //         AND (
            //            move.amount_total = duplicate_move.amount_total
            //            AND move.invoice_date = duplicate_move.invoice_date
            //         )
            //     """)
            //     to_query.append((out_moves, out_moves_sql_condition))
            // 
            // in_moves = moves.filtered(lambda m: m.move_type in ('in_invoice', 'in_refund'))
            // if in_moves:
            //     in_moves_sql_condition = SQL("""
            //         move.move_type in ('in_invoice', 'in_refund')
            //         AND duplicate_move.move_type in ('in_invoice', 'in_refund')
            //         AND (
            //            move.ref = duplicate_move.ref
            //            AND (
            //                move.invoice_date IS NULL
            //                OR
            //                duplicate_move.invoice_date IS NULL
            //                OR
            //                date_part('year', move.invoice_date) = date_part('year', duplicate_move.invoice_date)
            //            )
            //         )
            //     """)
            //     to_query.append((in_moves, in_moves_sql_condition))
            // 
            // result = []
            // for moves, move_type_sql_condition in to_query:
            //     result.extend(self.env.execute_query(SQL("""
            //         SELECT move.id AS move_id,
            //                array_agg(duplicate_move.id) AS duplicate_ids
            //           FROM %(move_table_and_alias)s
            //           JOIN account_move AS duplicate_move
            //             ON move.company_id = duplicate_move.company_id
            //            AND move.id != duplicate_move.id
            //            AND duplicate_move.state IN %(matching_states)s
            //            AND move.move_type = duplicate_move.move_type
            //            AND (
            //                    move.commercial_partner_id = duplicate_move.commercial_partner_id
            //                    OR (move.commercial_partner_id IS NULL AND duplicate_move.state = 'draft')
            //                )
            //            AND (%(move_type_sql_condition)s)
            //          WHERE move.id IN %(moves)s
            //          GROUP BY move.id
            //         """,
            //         matching_states=tuple(matching_states),
            //         moves=tuple(moves.ids or [0]),
            //         move_table_and_alias=move_table_and_alias,
            //         move_type_sql_condition=move_type_sql_condition,
            //     )))
            // return {
            //     self.env['account.move'].browse(move_id): self.env['account.move'].browse(duplicate_ids)
            //     for move_id, duplicate_ids in result
            // }
            */
            return default;
        }

        protected async Task<AccountMove> FieldWillChangeInternalAsync(object record, object vals, object field_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _field_will_change(self, record, vals, field_name):
            // if field_name not in vals:
            //     return False
            // field = record._fields[field_name]
            // if field.type == 'many2one':
            //     return record[field_name].id != vals[field_name]
            // if field.type == 'many2many':
            //     current_ids = set(record[field_name].ids)
            //     after_write_ids = set(record.new({field_name: vals[field_name]})[field_name].ids)
            //     return current_ids != after_write_ids
            // if field.type == 'one2many':
            //     return True
            // if field.type == 'monetary' and record[field.get_currency_field(record)]:
            //     return not record[field.get_currency_field(record)].is_zero(record[field_name] - vals[field_name])
            // if field.type == 'float':
            //     record_value = field.convert_to_cache(record[field_name], record)
            //     to_write_value = field.convert_to_cache(vals[field_name], record)
            //     return record_value != to_write_value
            // return record[field_name] != vals[field_name]
            */
            return default;
        }

        protected async Task<AccountMove> FindAndSetPurchaseOrdersInternalAsync(object po_references, Guid partner_id, object amount_total, object from_ocr, object timeout)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _find_and_set_purchase_orders(self, po_references, partner_id, amount_total, from_ocr=False, timeout=10):
            // # hook to be used with purchase, so that vendor bills are sync/autocompleted with purchase orders
            // self.ensure_one()
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def _find_and_set_purchase_orders(self, po_references, partner_id, amount_total, from_ocr=False, timeout=10):
            // """Finds related purchase orders that (partially) match the vendor bill and links the matching lines on this
            // vendor bill.
            // 
            // :param po_references: a list of potential purchase order references/names
            // :param partner_id: the vendor id matched on the vendor bill
            // :param amount_total: the total amount of the vendor bill
            // :param from_ocr: indicates whether this vendor bill was created from an OCR scan (less reliable)
            // :param timeout: the max time the line matching algorithm can take before timing out
            // """
            // self.ensure_one()
            // 
            // method, matched_po_lines, matched_inv_lines = self._match_purchase_orders(
            //     po_references, partner_id, amount_total, from_ocr, timeout
            // )
            // 
            // if method in ('total_match', 'po_match'):
            //     # The purchase order reference(s) and total amounts match perfectly or there is only one purchase order
            //     # reference that matches with an OCR invoice. We replace the invoice lines with the purchase order lines.
            //     self._set_purchase_orders(matched_po_lines.order_id, force_write=True)
            // 
            // elif method == 'subset_total_match':
            //     # A subset of the referenced purchase order lines matches the total amount of this invoice.
            //     # We keep the invoice lines, but add all the lines from the partially matched purchase orders:
            //     #   * "naively" matched purchase order lines keep their quantity
            //     #   * unmatched purchase order lines are added with their quantity set to 0
            //     self._set_purchase_orders(matched_po_lines.order_id, force_write=False)
            // 
            //     with self._get_edi_creation() as invoice:
            //         unmatched_lines = invoice.invoice_line_ids.filtered(
            //             lambda l: l.purchase_line_id and l.purchase_line_id not in matched_po_lines)
            //         invoice.invoice_line_ids = [Command.update(line.id, {'quantity': 0}) for line in unmatched_lines]
            // 
            // elif method == 'subset_match':
            //     # A subset of the referenced purchase order lines matches a subset of the invoice lines.
            //     # We add the purchase order lines, but adjust the quantity to the quantities in the invoice.
            //     # The original invoice lines that correspond with a purchase order line are removed.
            //     self._set_purchase_orders(matched_po_lines.order_id, force_write=False)
            // 
            //     with self._get_edi_creation() as invoice:
            //         unmatched_lines = invoice.invoice_line_ids.filtered(
            //             lambda l: l.purchase_line_id and l.purchase_line_id not in matched_po_lines)
            //         invoice.invoice_line_ids = [Command.delete(line.id) for line in unmatched_lines]
            // 
            //         # We remove the original matched invoice lines and apply their quantities and taxes to the matched
            //         # purchase order lines.
            //         inv_and_po_lines = list(map(lambda line: (
            //                 invoice.invoice_line_ids.filtered(
            //                     lambda l: l.purchase_line_id and l.purchase_line_id.id == line[0]),
            //                 invoice.invoice_line_ids.filtered(
            //                     lambda l: l in line[1])
            //             ),
            //             matched_inv_lines
            //         ))
            //         invoice.invoice_line_ids = [
            //             Command.update(po_line.id, {'quantity': inv_line.quantity, 'tax_ids': inv_line.tax_ids})
            //             for po_line, inv_line in inv_and_po_lines
            //         ]
            //         invoice.invoice_line_ids = [Command.delete(inv_line.id) for dummy, inv_line in inv_and_po_lines]
            // 
            //         # If there are lines left not linked to a purchase order, we add a header
            //         unmatched_lines = invoice.invoice_line_ids.filtered(lambda l: not l.purchase_line_id)
            //         if len(unmatched_lines) > 0:
            //             invoice.invoice_line_ids = [Command.create({
            //                 'display_type': 'line_section',
            //                 'name': _('From Electronic Document'),
            //                 'sequence': -1,
            //             })]
            */
            return default;
        }

        protected async Task<AccountMove> FindMatchingPoAndInvLinesInternalAsync(object po_lines, object inv_lines, object timeout)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def _find_matching_po_and_inv_lines(self, po_lines, inv_lines, timeout):
            // """Finds purchase order lines that match some of the invoice lines.
            // 
            // We try to find a purchase order line for every invoice line matching on the unit price and having at least
            // the same quantity to invoice.
            // 
            // :param po_lines: list of purchase order lines that can be matched
            // :param inv_lines: list of invoice lines to be matched
            // :param timeout: how long this function can run before we consider it too long
            // :return: a tuple (list, list) containing:
            //     * matched 'purchase.order.line'
            //     * tuple of purchase order line ids and their matched 'account.move.line'
            // """
            // # Sort the invoice lines by unit price and quantity to speed up matching
            // invoice_lines = sorted(inv_lines, key=lambda line: (line.price_unit, line.quantity), reverse=True)
            // # Sort the purchase order lines by unit price and remaining quantity to speed up matching
            // purchase_lines = sorted(
            //     po_lines,
            //     key=lambda line: (line.price_unit, line.product_qty - line.qty_invoiced),
            //     reverse=True
            // )
            // matched_po_lines = []
            // matched_inv_lines = []
            // try:
            //     start_time = time.time()
            //     for invoice_line in invoice_lines:
            //         # There are no purchase order lines left. We are done matching.
            //         if not purchase_lines:
            //             break
            //         # A dict of purchase lines mapping to a diff score for the name
            //         purchase_line_candidates = {}
            //         for purchase_line in purchase_lines:
            //             if time.time() - start_time > timeout:
            //                 raise TimeoutError
            // 
            //             # The lists are sorted by unit price descendingly.
            //             # When the unit price of the purchase line is lower than the unit price of the invoice line,
            //             # we cannot get a match anymore.
            //             if purchase_line.price_unit < invoice_line.price_unit:
            //                 break
            // 
            //             if (invoice_line.price_unit == purchase_line.price_unit
            //                     and invoice_line.quantity <= purchase_line.product_qty - purchase_line.qty_invoiced):
            //                 # The current purchase line is a possible match for the current invoice line.
            //                 # We calculate the name match ratio and continue with other possible matches.
            //                 #
            //                 # We could match on more fields coming from an EDI invoice, but that requires extending the
            //                 # account.move.line model with the extra matching fields and extending the EDI extraction
            //                 # logic to fill these new fields.
            //                 purchase_line_candidates[purchase_line] = difflib.SequenceMatcher(
            //                     None, invoice_line.name, purchase_line.name).ratio()
            // 
            //         if len(purchase_line_candidates) > 0:
            //             # We take the best match based on the name.
            //             purchase_line_match = max(purchase_line_candidates, key=purchase_line_candidates.get)
            //             if purchase_line_match:
            //                 # We found a match. We remove the purchase order line so it does not get matched twice.
            //                 purchase_lines.remove(purchase_line_match)
            //                 matched_po_lines.append(purchase_line_match)
            //                 matched_inv_lines.append((purchase_line_match.id, invoice_line))
            // 
            //     return (matched_po_lines, matched_inv_lines)
            // 
            // except TimeoutError:
            //     _logger.warning('Timed out during search of matching purchase order lines')
            //     return ([], [])
            */
            return default;
        }

        protected async Task<AccountMove> FindMatchingSubsetPoLinesInternalAsync(object po_lines_with_amount, object goal_total, object timeout)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def _find_matching_subset_po_lines(self, po_lines_with_amount, goal_total, timeout):
            // """Finds the purchase order lines adding up to the goal amount.
            // 
            // The problem of finding the subset of `po_lines_with_amount` which sums up to `goal_total` reduces to
            // the 0-1 Knapsack problem. The dynamic programming approach to solve this problem is most of the time slower
            // than this because identical sub-problems don't arise often enough. It returns the list of purchase order lines
            // which sum up to `goal_total` or an empty list if multiple or no solutions were found.
            // 
            // :param po_lines_with_amount: a dict (str: float|recordset) containing:
            //     * line: an `purchase.order.line`
            //     * amount_to_invoice: the remaining amount to be invoiced of the line
            // :param goal_total: the total amount to match with a subset of purchase order lines
            // :param timeout: the max time the line matching algorithm can take before timing out
            // :return: list of `purchase.order.line` whose remaining sum matches `goal_total`
            // """
            // def find_matching_subset_po_lines(lines, goal):
            //     if time.time() - start_time > timeout:
            //         raise TimeoutError
            //     solutions = []
            //     for i, line in enumerate(lines):
            //         if line['amount_to_invoice'] < goal - TOLERANCE:
            //             # The amount to invoice of the current purchase order line is less than the amount we still need on
            //             # the vendor bill.
            //             # We try finding purchase order lines that match the remaining vendor bill amount minus the amount
            //             # to invoice of the current purchase order line. We only look in the purchase order lines that we
            //             # haven't passed yet.
            //             sub_solutions = find_matching_subset_po_lines(lines[i + 1:], goal - line['amount_to_invoice'])
            //             # We add all possible sub-solutions' purchase order lines in a tuple together with our current
            //             # purchase order line.
            //             solutions.extend((line['line'], *solution) for solution in sub_solutions)
            //         elif goal - TOLERANCE <= line['amount_to_invoice'] <= goal + TOLERANCE:
            //             # The amount to invoice of the current purchase order line matches the remaining vendor bill amount.
            //             # We add this purchase order line to our list of solutions.
            //             solutions.append([line['line']])
            //         if len(solutions) > 1:
            //             # More than one solution was found. We can't know for sure which is the correct one, so we don't
            //             # return any solution.
            //             return []
            //     return solutions
            // start_time = time.time()
            // try:
            //     subsets = find_matching_subset_po_lines(
            //         sorted(po_lines_with_amount, key=lambda line: line['amount_to_invoice'], reverse=True),
            //         goal_total
            //     )
            //     return subsets[0] if subsets else []
            // except TimeoutError:
            //     _logger.warning("Timed out during search of a matching subset of purchase order lines")
            //     return []
            */
            return default;
        }

        public async Task<AccountMove> ForceRegisterPaymentAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_force_register_payment(self):
            // if any(m.move_type == 'entry' for m in self):
            //     raise UserError(_("You cannot register payments for miscellaneous entries."))
            // return self.line_ids.action_register_payment()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> GenerateAndSendInternalAsync(object force_synchronous, object allow_fallback_pdf)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _generate_and_send(self, force_synchronous=True, allow_fallback_pdf=True, **custom_settings):
            // """ Generate the pdf and electronic format(s) for the current invoices and send them given default settings
            // (on partner or company) or given provided custom_settings.
            // :param force_synchronous: whether to process (as)synchronously (! only relevant for batch sending (multiple invoices))
            // :param allow_fallback_pdf:  In case of error when generating the documents for invoices, generate a
            //                             proforma PDF report instead.
            // :param custom_settings: custom settings to create the wizard (! only relevant for single sending (one invoice))
            // (Since default settings are use for batch sending.
            // If you are looking for something more flexible, directly call env[account.move.send]._generate_and_send_invoices method.)
            // """
            // if not self:
            //     return
            // if len(self) == 1:
            //     wizard = self.env['account.move.send.wizard'].with_context(
            //         active_model='account.move',
            //         active_ids=self.ids,
            //     ).create(custom_settings)
            //     wizard.action_send_and_print(allow_fallback_pdf=allow_fallback_pdf)
            // else:
            //     wizard = self.env['account.move.send.batch.wizard'].with_context(
            //         active_model='account.move',
            //         active_ids=self.ids,
            //     ).create({})
            //     wizard.action_send_and_print(force_synchronous=force_synchronous)
            // return wizard
            */
            return default;
        }

        protected async Task<AccountMove> GenerateQrCodeInternalAsync(object silent_errors)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _generate_qr_code(self, silent_errors=False):
            // """ Generates and returns a QR-code generation URL for this invoice,
            // raising an error message if something is misconfigured.
            // 
            // The chosen QR generation method is the one set in qr_method field if there is one,
            // or the first eligible one found. If this search had to be performed and
            // and eligible method was found, qr_method field is set to this method before
            // returning the URL. If no eligible QR method could be found, we return None.
            // """
            // self.ensure_one()
            // 
            // if not self.display_qr_code:
            //     return None
            // 
            // qr_code_method = self.qr_code_method
            // if qr_code_method:
            //     # If the user set a qr code generator manually, we check that we can use it
            //     error_msg = self.partner_bank_id._get_error_messages_for_qr(self.qr_code_method, self.partner_id, self.currency_id)
            //     if error_msg:
            //         raise UserError(error_msg)
            // else:
            //     # Else we find one that's eligible and assign it to the invoice
            //     for candidate_method, _candidate_name in self.env['res.partner.bank'].get_available_qr_methods_in_sequence():
            //         error_msg = self.partner_bank_id._get_error_messages_for_qr(candidate_method, self.partner_id, self.currency_id)
            //         if not error_msg:
            //             qr_code_method = candidate_method
            //             break
            // 
            // if not qr_code_method:
            //     # No eligible method could be found; we can't generate the QR-code
            //     return None
            // 
            // unstruct_ref = self.ref if self.ref else self.name
            // rslt = self.partner_bank_id.build_qr_code_base64(self.amount_residual, unstruct_ref, self.payment_reference, self.currency_id, self.partner_id, qr_code_method, silent_errors=silent_errors)
            // 
            // # We only set qr_code_method after generating the url; otherwise, it
            // # could be set even in case of a failure in the QR code generation
            // # (which would change the field, but not refresh UI, making the displayed data inconsistent with db)
            // self.qr_code_method = qr_code_method
            // 
            // return rslt
            */
            return default;
        }

        protected async Task<AccountMove> GetAccountingDateInternalAsync(object invoice_date, object has_tax, object lock_dates)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_accounting_date(self, invoice_date, has_tax, lock_dates=None):
            // """Get correct accounting date for previous periods, taking tax lock date and affected journal into account.
            // When registering an invoice in the past, we still want the sequence to be increasing.
            // We then take the last day of the period, depending on the sequence format.
            // 
            // If there is a tax lock date and there are taxes involved, we register the invoice at the
            // last date of the first open period.
            // :param invoice_date (datetime.date): The invoice date
            // :param has_tax (bool): Iff any taxes are involved in the lines of the invoice
            // :param lock_dates: Like result from `_get_violated_lock_dates`;
            //                    Can be used to avoid recomputing them in case they are already known.
            // :return (datetime.date):
            // """
            // self.ensure_one()
            // lock_dates = lock_dates or self._get_violated_lock_dates(invoice_date, has_tax)
            // today = fields.Date.context_today(self)
            // highest_name = self.highest_name or self._get_last_sequence(relaxed=True)
            // number_reset = self._deduce_sequence_number_reset(highest_name)
            // if lock_dates:
            //     invoice_date = lock_dates[-1][0] + timedelta(days=1)
            // if self.is_sale_document(include_receipts=True):
            //     if lock_dates:
            //         if not highest_name or number_reset == 'month':
            //             return min(today, date_utils.get_month(invoice_date)[1])
            //         elif number_reset == 'year':
            //             return min(today, date_utils.end_of(invoice_date, 'year'))
            // else:
            //     if not highest_name or number_reset in ('month', 'year_range_month'):
            //         if (today.year, today.month) > (invoice_date.year, invoice_date.month):
            //             return date_utils.get_month(invoice_date)[1]
            //         else:
            //             return max(invoice_date, today)
            //     elif number_reset == 'year':
            //         if today.year > invoice_date.year:
            //             return date(invoice_date.year, 12, 31)
            //         else:
            //             return max(invoice_date, today)
            // return invoice_date
            */
            return default;
        }

        protected async Task<AccountMove> GetActionAddFromCatalogExtraContextInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_action_add_from_catalog_extra_context(self):
            // res = super()._get_action_add_from_catalog_extra_context()
            // if self.is_purchase_document() and self.partner_id:
            //     res['search_default_seller_ids'] = self.partner_id.name
            // 
            // res['product_catalog_currency_id'] = self.currency_id.id
            // res['product_catalog_digits'] = self.line_ids._fields['price_unit'].get_digits(self.env)
            // return res
            */
            return default;
        }

        protected async Task<AccountMove> GetActionPerItemInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: account_move.py) ---
            // def _get_action_per_item(self):
            // action = self.env.ref('account.action_move_out_invoice_type').id
            // return {invoice.id: action for invoice in self}
            */
            return default;
        }

        protected async Task<AccountMove> GetAllReconciledInvoicePartialsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_all_reconciled_invoice_partials(self):
            // self.ensure_one()
            // reconciled_lines = self.line_ids.filtered(lambda line: line.account_id.account_type in ('asset_receivable', 'liability_payable'))
            // if not reconciled_lines:
            //     return {}
            // 
            // self.env['account.partial.reconcile'].flush_model([
            //     'credit_amount_currency', 'credit_move_id', 'debit_amount_currency',
            //     'debit_move_id', 'exchange_move_id',
            // ])
            // sql = SQL('''
            //     SELECT
            //         part.id,
            //         part.exchange_move_id,
            //         part.debit_amount_currency AS amount,
            //         part.credit_move_id AS counterpart_line_id
            //     FROM account_partial_reconcile part
            //     WHERE part.debit_move_id IN %(line_ids)s
            // 
            //     UNION ALL
            // 
            //     SELECT
            //         part.id,
            //         part.exchange_move_id,
            //         part.credit_amount_currency AS amount,
            //         part.debit_move_id AS counterpart_line_id
            //     FROM account_partial_reconcile part
            //     WHERE part.credit_move_id IN %(line_ids)s
            // ''', line_ids=tuple(reconciled_lines.ids))
            // 
            // partial_values_list = []
            // counterpart_line_ids = set()
            // exchange_move_ids = set()
            // for values in self.env.execute_query_dict(sql):
            //     partial_values_list.append({
            //         'aml_id': values['counterpart_line_id'],
            //         'partial_id': values['id'],
            //         'amount': values['amount'],
            //         'currency': self.currency_id,
            //     })
            //     counterpart_line_ids.add(values['counterpart_line_id'])
            //     if values['exchange_move_id']:
            //         exchange_move_ids.add(values['exchange_move_id'])
            // 
            // if exchange_move_ids:
            //     self.env['account.move.line'].flush_model(['move_id'])
            //     sql = SQL('''
            //         SELECT
            //             part.id,
            //             part.credit_move_id AS counterpart_line_id
            //         FROM account_partial_reconcile part
            //         JOIN account_move_line credit_line ON credit_line.id = part.credit_move_id
            //         WHERE credit_line.move_id IN %(exchange_move_ids)s AND part.debit_move_id IN %(counterpart_line_ids)s
            // 
            //         UNION ALL
            // 
            //         SELECT
            //             part.id,
            //             part.debit_move_id AS counterpart_line_id
            //         FROM account_partial_reconcile part
            //         JOIN account_move_line debit_line ON debit_line.id = part.debit_move_id
            //         WHERE debit_line.move_id IN %(exchange_move_ids)s AND part.credit_move_id IN %(counterpart_line_ids)s
            //     ''', exchange_move_ids=tuple(exchange_move_ids), counterpart_line_ids=tuple(counterpart_line_ids))
            // 
            //     for part_id, line_ids in self.env.execute_query(sql):
            //         counterpart_line_ids.add(line_ids)
            //         partial_values_list.append({
            //             'aml_id': line_ids,
            //             'partial_id': part_id,
            //             'currency': self.company_id.currency_id,
            //         })
            // 
            // counterpart_lines = {x.id: x for x in self.env['account.move.line'].browse(counterpart_line_ids)}
            // for partial_values in partial_values_list:
            //     partial_values['aml'] = counterpart_lines[partial_values['aml_id']]
            //     partial_values['is_exchange'] = partial_values['aml'].move_id.id in exchange_move_ids
            //     if partial_values['is_exchange']:
            //         partial_values['amount'] = abs(partial_values['aml'].balance)
            // 
            // return partial_values_list
            */
            return default;
        }

        protected async Task<AccountMove> GetAngloSaxonPriceCtxInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: account_move.py) ---
            // def _get_anglo_saxon_price_ctx(self):
            // ctx = super()._get_anglo_saxon_price_ctx()
            // move_is_downpayment = self.invoice_line_ids.filtered(
            //     lambda line: any(line.sale_line_ids.mapped("is_downpayment"))
            // )
            // return dict(ctx, move_is_downpayment=move_is_downpayment)
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move.py) ---
            // def _get_anglo_saxon_price_ctx(self):
            // """ To be overriden in modules overriding _stock_account_get_anglo_saxon_price_unit
            // to optimize computations that only depend on account.move and not account.move.line
            // """
            // return self.env.context
            */
            return default;
        }

        protected async Task<AccountMove> GetAutomaticBalancingAccountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_automatic_balancing_account(self):
            // """ Small helper for special cases where we want to auto balance a move with a specific account. """
            // self.ensure_one()
            // if self.journal_id.default_account_id:
            //     return self.journal_id.default_account_id.id
            // return self.company_id.account_journal_suspense_account_id.id
            */
            return default;
        }

        protected async Task<AccountMove> GetChainInfoInternalAsync(object force_hash, object include_pre_last_hash, object early_stop)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_chain_info(self, force_hash=False, include_pre_last_hash=False, early_stop=False):
            // """All records in `self` must belong to the same journal and sequence_prefix
            // """
            // if not self:
            //     return False
            // last_move_in_chain = max(self, key=lambda m: m.sequence_number)
            // journal = last_move_in_chain.journal_id
            // if not self._is_move_restricted(last_move_in_chain, force_hash=force_hash):
            //     return False
            // 
            // common_domain = [
            //     ('journal_id', '=', journal.id),
            //     ('sequence_prefix', '=', last_move_in_chain.sequence_prefix),
            // ]
            // last_move_hashed = self.env['account.move'].search([
            //     *common_domain,
            //     ('inalterable_hash', '!=', False),
            // ], order='sequence_number desc', limit=1)
            // 
            // domain = self.env['account.move']._get_move_hash_domain([
            //     *common_domain,
            //     ('sequence_number', '<=', last_move_in_chain.sequence_number),
            //     ('inalterable_hash', '=', False),
            // ], force_hash=True)
            // if last_move_hashed and not include_pre_last_hash:
            //     # Hash moves only after the last hashed move, not the ones that may have been posted before the journal was set on restrict mode
            //     domain.extend([('sequence_number', '>', last_move_hashed.sequence_number)])
            // 
            // # On the accounting dashboard, we are only interested on whether there are documents to hash or not
            // # so we can stop the computation early if we find at least one document to hash
            // if early_stop:
            //     return self.env['account.move'].sudo().search_count(domain, limit=1)
            // moves_to_hash = self.env['account.move'].sudo().search(domain, order='sequence_number')
            // warnings = set()
            // if moves_to_hash:
            //     # gap warning
            //     if last_move_hashed:
            //         first = last_move_hashed.sequence_number
            //         difference = len(moves_to_hash)
            //     else:
            //         first = moves_to_hash[0].sequence_number
            //         difference = len(moves_to_hash) - 1
            //     last = moves_to_hash[-1].sequence_number
            //     if first + difference != last:
            //         warnings.add('gap')
            // 
            //     # unreconciled warning
            //     unreconciled = False in moves_to_hash.statement_line_ids.mapped('is_reconciled')
            //     if unreconciled:
            //         warnings.add('unreconciled')
            // else:
            //     warnings.add('no_document')
            // moves = moves_to_hash.sudo(False)
            // return {
            //     'previous_hash': last_move_hashed.inalterable_hash,
            //     'last_move_hashed': last_move_hashed,
            //     'moves': moves,
            //     'remaining_moves': self - moves,
            //     'warnings': warnings,
            // }
            */
            return default;
        }

        protected async Task<AccountMove> GetChainsToHashInternalAsync(object force_hash, object raise_if_gap, object raise_if_no_document, object include_pre_last_hash, object early_stop)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_chains_to_hash(self, force_hash=False, raise_if_gap=True, raise_if_no_document=True, include_pre_last_hash=False, early_stop=False):
            // """
            // From a recordset of moves, retrieve the chains of moves that need to be hashed by taking
            // into account the last move of each chain of the recordset.
            // So if we have INV/1, INV/2, INV/3, INV4 that are not hashed yet in the database
            // but self contains INV/2, INV/3, we will return INV/1, INV/2 and INV/3. Not INV/4.
            // :param force_hash: if True, we'll check all moves posted, independently of journal settings
            // :param raise_if_gap: if True, we'll raise an error if a gap is detected in the sequence
            // :param raise_if_no_document: if True, we'll raise an error if no document needs to be hashed
            // :param include_pre_last_hash: if True, we'll include the moves not hashed that are previous to the last hashed move
            // :param early_stop: if True, we'll stop the computation as soon as we find at least one document to hash
            // :return bool when early_stop else a list of dictionaries (each dict generated by `_get_chain_info`)
            // """
            // res = []
            // for journal, journal_moves in self.grouped('journal_id').items():
            //     for chain_moves in journal_moves.grouped('sequence_prefix').values():
            //         chain_info = chain_moves._get_chain_info(
            //             force_hash=force_hash, include_pre_last_hash=include_pre_last_hash, early_stop=early_stop
            //         )
            // 
            //         if not chain_info:
            //             continue
            //         if early_stop:
            //             return True
            //         chain_info['journal_restrict_mode'] = journal.restrict_mode_hash_table
            // 
            //         if 'unreconciled' in chain_info['warnings']:
            //             raise UserError(_("An error occurred when computing the inalterability. All entries have to be reconciled."))
            // 
            //         if raise_if_no_document and 'no_document' in chain_info['warnings']:
            //             raise UserError(_(
            //                 "This move could not be locked either because "
            //                 "some move with the same sequence prefix has a higher number. You may need to resequence it."
            //             ))
            //         if raise_if_gap and 'gap' in chain_info['warnings']:
            //             raise UserError(_(
            //                 "An error occurred when computing the inalterability. A gap has been detected in the sequence."
            //             ))
            // 
            //         res.append(chain_info)
            // if early_stop:
            //     return False
            // return res
            */
            return default;
        }

        public async Task<AccountMove> GetCurrencyRateAsync(Guid id, AccountMoveGetCurrencyRateRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_currency_rate(self, company_id, to_currency_id, date):
            // company = self.env['res.company'].browse(company_id)
            // to_currency = self.env['res.currency'].browse(to_currency_id)
            // 
            // return self.env['res.currency']._get_conversion_rate(
            //     from_currency=company.currency_id,
            //     to_currency=to_currency,
            //     company=company,
            //     date=date,
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> GetDefaultPaymentLinkValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: account_move.py) ---
            // def _get_default_payment_link_values(self):
            // next_payment_values = self._get_invoice_next_payment_values()
            // amount_max = next_payment_values.get('amount_due')
            // additional_info = {}
            // open_installments = []
            // installment_state = next_payment_values.get('installment_state')
            // next_amount_to_pay = next_payment_values.get('next_amount_to_pay')
            // if installment_state in ('next', 'overdue'):
            //     open_installments = []
            //     for installment in next_payment_values.get('not_reconciled_installments'):
            //         data = {
            //             'type': installment['type'],
            //             'number': installment['number'],
            //             'amount': installment['amount_residual_currency_unsigned'],
            //             'date_maturity': format_date(self.env, installment['date_maturity']),
            //         }
            //         open_installments.append(data)
            // 
            // elif installment_state == 'epd':
            //     amount_max = next_amount_to_pay  # with epd, next_amount_to_pay is the invoice amount residual
            //     additional_info.update({
            //         'has_eligible_epd': True,
            //         'discount_date': next_payment_values.get('discount_date')
            //     })
            // 
            // return {
            //     'currency_id': self.currency_id.id,
            //     'partner_id': self.partner_id.id,
            //     'open_installments': open_installments,
            //     'amount': next_amount_to_pay,
            //     'amount_max': amount_max,
            //     **additional_info
            // }
            */
            return default;
        }

        protected async Task<AccountMove> GetDiscountAllocationAccountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_discount_allocation_account(self):
            // if self.is_sale_document(include_receipts=True) and self.company_id.account_discount_expense_allocation_id:
            //     return self.company_id.account_discount_expense_allocation_id
            // if self.is_purchase_document(include_receipts=True) and self.company_id.account_discount_income_allocation_id:
            //     return self.company_id.account_discount_income_allocation_id
            // return None
            */
            return default;
        }

        protected async Task<AccountMove> GetEdiAttachmentInternalAsync(object edi_format)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _get_edi_attachment(self, edi_format):
            // return self._get_edi_document(edi_format).sudo().attachment_id
            */
            return default;
        }

        protected async Task<AccountMove> GetEdiCreationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_edi_creation(self):
            // """Get an environment to import documents from other sources.
            // 
            // Allow to edit the current move or create a new one.
            // This will prevent computing the dynamic lines at each invoice line added and only
            // compute everything at the end.
            // """
            // container = {'records': self}
            // with self._check_balanced(container),\
            //      self._disable_discount_precision(),\
            //      self._sync_dynamic_lines(container):
            //     move = self or self.create({})
            //     yield move
            //     container['records'] = move
            */
            return default;
        }

        protected async Task<AccountMove> GetEdiDecoderInternalAsync(object file_data, object @new)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_edi_decoder(self, file_data, new=False):
            // """To be extended with decoding capabilities.
            // :returns:  Function to be later used to import the file.
            //            Function' args:
            //            - invoice: account.move
            //            - file_data: attachemnt information / value
            //            - new: whether the invoice is newly created
            //            returns True if was able to process the invoice
            // """
            // return None
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py) ---
            // def _get_edi_decoder(self, file_data, new=False):
            // # EXTENDS 'account'
            // if file_data['type'] == 'xml':
            //     if etree.QName(file_data['xml_tree']).localname == 'AttachedDocument':
            //         file_data['xml_tree'] = self._ubl_parse_attached_document(file_data['xml_tree'])
            //     ubl_cii_xml_builder = self._get_ubl_cii_builder_from_xml_tree(file_data['xml_tree'])
            //     if ubl_cii_xml_builder is not None:
            //         return ubl_cii_xml_builder._import_invoice_ubl_cii
            // 
            // return super()._get_edi_decoder(file_data, new=new)
            */
            return default;
        }

        protected async Task<AccountMove> GetEdiDocumentInternalAsync(object edi_format)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _get_edi_document(self, edi_format):
            // return self.edi_document_ids.filtered(lambda d: d.edi_format_id == edi_format)
            */
            return default;
        }

        public async Task<AccountMove> GetExtraPrintItemsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_extra_print_items(self):
            // """ Helper to dynamically add items in the 'Print' menu of list and form of account.move.
            // This is necessary to avoid the re-generation of the PDF through the action_report.
            // Indeed, once a legal PDF is generated, it should be used and not re-generated.
            // """
            // return [{
            //     'key': 'download_pdf',
            //     'description': _('PDF'),
            //     **self.action_invoice_download_pdf()
            // }]
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py) ---
            // def get_extra_print_items(self):
            // print_items = super().get_extra_print_items()
            // if self.ubl_cii_xml_id:
            //     print_items.append({
            //         'key': 'download_ubl',
            //         'description': _('XML UBL'),
            //         **self.action_invoice_download_ubl(),
            //     })
            // return print_items
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> GetFieldsToCopyRecurringEntriesInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_fields_to_copy_recurring_entries(self, values):
            // ''' Determines which extra fields to copy when copying a recurring entry.
            // To be extended by modules that add fields with copy=False (implicit or explicit)
            // whenever the opposite behavior is expected for recurring invoices.
            // '''
            // values.update({
            //     'auto_post': self.auto_post,  # copy=False to avoid mistakes but should be the same in recurring copies
            //     'auto_post_until': self.auto_post_until,  # same as above
            //     'auto_post_origin_id': self.auto_post_origin_id.id,  # same as above
            //     'invoice_user_id': self.invoice_user_id.id,  # otherwise user would be OdooBot
            // })
            // if self.invoice_date:
            //     values.update({'invoice_date': self._apply_delta_recurring_entries(self.invoice_date, self.auto_post_origin_id.invoice_date, self.auto_post)})
            // if not self.invoice_payment_term_id and self.invoice_date_due:
            //     # no payment terms: maintain timedelta between due date and accounting date
            //     values.update({'invoice_date_due': values['date'] + (self.invoice_date_due - self.date)})
            // return values
            */
            return default;
        }

        protected async Task<AccountMove> GetFieldsToDetachInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_fields_to_detach(self):
            // """"
            // Returns a list of field names to detach on resetting an invoice to draft. Can be overridden by other modules to
            // add more fields.
            // """
            // return ['invoice_pdf_report_file']
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py) ---
            // def _get_fields_to_detach(self):
            // # EXTENDS account
            // fields_list = super()._get_fields_to_detach()
            // fields_list.append("ubl_cii_xml_file")
            // return fields_list
            */
            return default;
        }

        protected async Task<AccountMove> GetFrequentAccountAndTaxesInternalAsync(Guid company_id, Guid partner_id, object move_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_frequent_account_and_taxes(self, company_id, partner_id, move_type):
            // """
            // Returns the most used accounts and taxes for a given partner and company,
            // eventually filtered according to the move type.
            // """
            // if not partner_id:
            //     return 0, False, False
            // domain = [
            //     *self.env['account.move.line']._check_company_domain(company_id),
            //     ('partner_id', '=', partner_id),
            //     ('account_id.deprecated', '=', False),
            //     ('date', '>=', date.today() - timedelta(days=365 * 2)),
            // ]
            // if move_type in self.env['account.move'].get_inbound_types(include_receipts=True):
            //     domain.append(('account_id.internal_group', '=', 'income'))
            // elif move_type in self.env['account.move'].get_outbound_types(include_receipts=True):
            //     domain.append(('account_id.internal_group', '=', 'expense'))
            // 
            // query = self.env['account.move.line']._where_calc(domain)
            // account_code = self.env['account.account']._field_to_sql('account_move_line__account_id', 'code', query)
            // rows = self.env.execute_query(SQL("""
            //     SELECT COUNT(foo.id), foo.account_id, foo.taxes
            //       FROM (
            //                  SELECT account_move_line__account_id.id AS account_id,
            //                         %(account_code)s AS code,
            //                         account_move_line.id,
            //                         ARRAY_AGG(tax_rel.account_tax_id) FILTER (WHERE tax_rel.account_tax_id IS NOT NULL) AS taxes
            //                    FROM %(from_clause)s
            //               LEFT JOIN account_move_line_account_tax_rel tax_rel ON account_move_line.id = tax_rel.account_move_line_id
            //                   WHERE %(where_clause)s
            //                GROUP BY account_move_line__account_id.id,
            //                         %(account_code)s,
            //                         account_move_line.id
            //            ) AS foo
            //   GROUP BY foo.account_id, foo.taxes
            //   ORDER BY COUNT(foo.id) DESC, taxes ASC NULLS LAST
            //      LIMIT 1
            //     """,
            //     account_code=account_code,
            //     from_clause=query.from_clause,
            //     where_clause=query.where_clause or SQL("TRUE"),
            // ))
            // return rows[0] if rows else (0, False, False)
            */
            return default;
        }

        public async Task<AccountMove> GetInboundTypesAsync(Guid id, AccountMoveGetInboundTypesRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_inbound_types(self, include_receipts=True):
            // return ['out_invoice', 'in_refund'] + (include_receipts and ['out_receipt'] or [])
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> GetInstallmentsDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_installments_data(self):
            // self.ensure_one()
            // term_lines = self.line_ids.filtered(lambda l: l.display_type == 'payment_term')
            // return term_lines._get_installments_data()
            */
            return default;
        }

        protected async Task<AccountMove> GetIntegrityHashFieldsAndSubfieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_integrity_hash_fields_and_subfields(self):
            // return self._get_integrity_hash_fields() + [f'line_ids.{subfield}' for subfield in self.line_ids._get_integrity_hash_fields()]
            */
            return default;
        }

        protected async Task<AccountMove> GetIntegrityHashFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_integrity_hash_fields(self):
            // # Use the latest hash version by default, but keep the old one for backward compatibility when generating the integrity report.
            // hash_version = self._context.get('hash_version', MAX_HASH_VERSION)
            // if hash_version == 1:
            //     return ['date', 'journal_id', 'company_id']
            // elif hash_version in (2, 3, 4):
            //     return ['name', 'date', 'journal_id', 'company_id']
            // raise NotImplementedError(f"hash_version={hash_version} doesn't exist")
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoiceComputedReferenceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_computed_reference(self):
            // self.ensure_one()
            // if self.journal_id.invoice_reference_type == 'none':
            //     return ''
            // ref_function = getattr(self, f'_get_invoice_reference_{self.journal_id.invoice_reference_model}_{self.journal_id.invoice_reference_type}', None)
            // if ref_function is None:
            //     raise UserError(_("The combination of reference model and reference type on the journal is not implemented"))
            // return ref_function()
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoiceCounterpartAmlsForEarlyPaymentDiscountInternalAsync(object aml_values_list, object open_balance)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_counterpart_amls_for_early_payment_discount(self, aml_values_list, open_balance):
            // """ Helper to get the values to create the counterpart journal items on the register payment wizard and the
            // bank reconciliation widget in case of an early payment discount by taking care of the payment term lines we
            // are matching and the exchange difference in case of multi-currencies.
            // 
            // :param aml_values_list: A list of dictionaries containing:
            //     * aml:              The payment term line we match.
            //     * amount_currency:  The matched amount_currency for this line.
            //     * balance:          The matched balance for this line (could be different in case of multi-currencies).
            // :param open_balance:    The current open balance to be covered by the early payment discount.
            // :return: A list of values to create the counterpart journal items split in 3 categories:
            //     * term_lines:       The journal items containing the discount amounts for each receivable line when the
            //                         discount computation is excluded / mixed.
            //     * tax_lines:        The journal items acting as tax lines when the discount computation is included.
            //     * base_lines:       The journal items acting as base for tax lines when the discount computation is included.
            //     * exchange_lines:   The journal items representing the exchange differences in case of multi-currencies.
            // """
            // res = {
            //     'base_lines': {},
            //     'tax_lines': {},
            //     'term_lines': {},
            //     'exchange_lines': {},
            // }
            // 
            // res_per_invoice = {}
            // for aml_values in aml_values_list:
            //     aml = aml_values['aml']
            //     invoice = aml.move_id
            // 
            //     if invoice not in res_per_invoice:
            //         res_per_invoice[invoice] = invoice._get_invoice_counterpart_amls_for_early_payment_discount_per_payment_term_line()
            // 
            //     for key in ('base_lines', 'tax_lines', 'term_lines'):
            //         for grouping_dict, vals in res_per_invoice[invoice][key][aml].items():
            //             line_vals = res[key].setdefault(grouping_dict, {
            //                 **vals,
            //                 'amount_currency': 0.0,
            //                 'balance': 0.0,
            //                 'display_type': 'epd',  # Used to compute tax_tag_invert for early payment discount lines
            //             })
            //             line_vals['amount_currency'] += vals['amount_currency']
            //             line_vals['balance'] += vals['balance']
            // 
            //             # Track the balance to handle the exchange difference.
            //             open_balance -= vals['balance']
            // 
            // exchange_diff_sign = aml.company_currency_id.compare_amounts(open_balance, 0.0)
            // if exchange_diff_sign != 0.0:
            // 
            //     if exchange_diff_sign > 0.0:
            //         exchange_line_account = aml.company_id.expense_currency_exchange_account_id
            //     else:
            //         exchange_line_account = aml.company_id.income_currency_exchange_account_id
            // 
            //     grouping_dict = {
            //         'account_id': exchange_line_account.id,
            //         'currency_id': aml.currency_id.id,
            //         'partner_id': aml.partner_id.id,
            //     }
            //     line_vals = res['exchange_lines'].setdefault(frozendict(grouping_dict), {
            //         **grouping_dict,
            //         'name': _("Early Payment Discount (Exchange Difference)"),
            //         'amount_currency': 0.0,
            //         'balance': 0.0,
            //     })
            //     line_vals['balance'] += open_balance
            // 
            // return {
            //     key: [
            //         {
            //             **grouping_dict,
            //             **vals,
            //         }
            //         for grouping_dict, vals in mapping.items()
            //     ]
            //     for key, mapping in res.items()
            // }
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoiceCounterpartAmlsForEarlyPaymentDiscountPerPaymentTermLineInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_counterpart_amls_for_early_payment_discount_per_payment_term_line(self):
            // """ Helper to get the values to create the counterpart journal items on the register payment wizard and the
            // bank reconciliation widget in case of an early payment discount. When the early payment discount computation
            // is included, we need to compute the base amounts / tax amounts for each receivable / payable but we need to
            // take care about the rounding issues. For others computations, we need to balance the discount you get.
            // 
            // :return: A list of values to create the counterpart journal items split in 3 categories:
            //     * term_lines:   The journal items containing the discount amounts for each receivable line when the
            //                     discount computation is excluded / mixed.
            //     * tax_lines:    The journal items acting as tax lines when the discount computation is included.
            //     * base_lines:   The journal items acting as base for tax lines when the discount computation is included.
            // """
            // self.ensure_one()
            // 
            // def inverse_tax_rep(tax_rep):
            //     tax = tax_rep.tax_id
            //     index = list(tax.invoice_repartition_line_ids).index(tax_rep)
            //     return tax.refund_repartition_line_ids[index]
            // 
            // company = self.company_id
            // payment_term_line = self.line_ids.filtered(lambda x: x.display_type == 'payment_term')
            // tax_lines = self.line_ids.filtered('tax_repartition_line_id')
            // invoice_lines = self.line_ids.filtered(lambda x: x.display_type == 'product')
            // payment_term = self.invoice_payment_term_id
            // early_pay_discount_computation = payment_term.early_pay_discount_computation
            // discount_percentage = payment_term.discount_percentage
            // 
            // res = {
            //     'term_lines': defaultdict(lambda: {}),
            //     'tax_lines': defaultdict(lambda: {}),
            //     'base_lines': defaultdict(lambda: {}),
            // }
            // if not discount_percentage:
            //     return res
            // 
            // # Get the current tax amounts in the current invoice.
            // tax_amounts = {
            //     inverse_tax_rep(line.tax_repartition_line_id).id: {
            //         'amount_currency': line.amount_currency,
            //         'balance': line.balance,
            //     }
            //     for line in tax_lines
            // }
            // 
            // base_lines = [
            //     {
            //         **self._prepare_product_base_line_for_taxes_computation(line),
            //         'is_refund': True,
            //     }
            //     for line in invoice_lines
            // ]
            // for base_line in base_lines:
            //     base_line['tax_ids'] = base_line['tax_ids'].filtered(lambda t: t.amount_type != 'fixed')
            // 
            //     if early_pay_discount_computation == 'included':
            //         remaining_part_to_consider = (100 - discount_percentage) / 100.0
            //         base_line['price_unit'] *= remaining_part_to_consider
            // AccountTax = self.env['account.tax']
            // AccountTax._add_tax_details_in_base_lines(base_lines, self.company_id)
            // AccountTax._round_base_lines_tax_details(base_lines, self.company_id)
            // AccountTax._add_accounting_data_in_base_lines_tax_details(base_lines, self.company_id)
            // 
            // if self.is_inbound(include_receipts=True):
            //     cash_discount_account = company.account_journal_early_pay_discount_loss_account_id
            // else:
            //     cash_discount_account = company.account_journal_early_pay_discount_gain_account_id
            // 
            // bases_details = {}
            // 
            // term_amount_currency = payment_term_line.amount_currency - payment_term_line.discount_amount_currency
            // term_balance = payment_term_line.balance - payment_term_line.discount_balance
            // if early_pay_discount_computation == 'included' and invoice_lines.tax_ids:
            //     # Compute the base amounts.
            //     resulting_delta_base_details = {}
            //     resulting_delta_tax_details = {}
            //     for base_line in base_lines:
            //         tax_details = base_line['tax_details']
            //         invoice_line = base_line['record']
            // 
            //         grouping_dict = {
            //             'tax_ids': [Command.set(base_line['tax_ids'].ids)],
            //             'tax_tag_ids': [Command.set(base_line['tax_tag_ids'].ids)],
            //             'partner_id': base_line['partner_id'].id,
            //             'currency_id': base_line['currency_id'].id,
            //             'account_id': cash_discount_account.id,
            //             'analytic_distribution': base_line['analytic_distribution'],
            //         }
            //         base_detail = resulting_delta_base_details.setdefault(frozendict(grouping_dict), {
            //             'balance': 0.0,
            //             'amount_currency': 0.0,
            //         })
            // 
            //         amount_currency = self.currency_id\
            //             .round(self.direction_sign * tax_details['total_excluded_currency'] - invoice_line.amount_currency)
            //         balance = self.company_currency_id\
            //             .round(self.direction_sign * tax_details['total_excluded'] - invoice_line.balance)
            // 
            //         base_detail['balance'] += balance
            //         base_detail['amount_currency'] += amount_currency
            // 
            //         bases_details[frozendict(grouping_dict)] = base_detail
            // 
            //     # Compute the tax amounts.
            //     tax_results = AccountTax._prepare_tax_lines(base_lines, self.company_id)
            //     for tax_line_vals in tax_results['tax_lines_to_add']:
            //         tax_amount_without_epd = tax_amounts.get(tax_line_vals['tax_repartition_line_id'])
            //         if tax_amount_without_epd:
            //             resulting_delta_tax_details[tax_line_vals['tax_repartition_line_id']] = {
            //                 **tax_line_vals,
            //                 'amount_currency': tax_line_vals['amount_currency'] - tax_amount_without_epd['amount_currency'],
            //                 'balance': tax_line_vals['balance'] - tax_amount_without_epd['balance'],
            //             }
            // 
            //     # Multiply the amount by the percentage
            //     percentage_paid = abs(payment_term_line.amount_residual_currency / self.amount_total)
            //     for tax_line_vals in resulting_delta_tax_details.values():
            //         tax_rep = self.env['account.tax.repartition.line'].browse(tax_line_vals['tax_repartition_line_id'])
            //         tax = tax_rep.tax_id
            // 
            //         grouping_dict = {
            //             'account_id': tax_line_vals['account_id'],
            //             'partner_id': tax_line_vals['partner_id'],
            //             'currency_id': tax_line_vals['currency_id'],
            //             'analytic_distribution': tax_line_vals['analytic_distribution'],
            //             'tax_repartition_line_id': tax_rep.id,
            //             'tax_ids': tax_line_vals['tax_ids'],
            //             'tax_tag_ids': tax_line_vals['tax_tag_ids'],
            //             'group_tax_id': tax_line_vals['group_tax_id'],
            //         }
            // 
            //         res['tax_lines'][payment_term_line][frozendict(grouping_dict)] = {
            //             'name': _("Early Payment Discount (%s)", tax.name),
            //             'amount_currency': payment_term_line.currency_id.round(tax_line_vals['amount_currency'] * percentage_paid),
            //             'balance': payment_term_line.company_currency_id.round(tax_line_vals['balance'] * percentage_paid),
            //         }
            // 
            //     for grouping_dict, base_detail in bases_details.items():
            //         res['base_lines'][payment_term_line][grouping_dict] = {
            //             'name': _("Early Payment Discount"),
            //             'amount_currency': payment_term_line.currency_id.round(base_detail['amount_currency'] * percentage_paid),
            //             'balance': payment_term_line.company_currency_id.round(base_detail['balance'] * percentage_paid),
            //         }
            // 
            //     # Fix the rounding issue if any.
            //     delta_amount_currency = term_amount_currency \
            //                             - sum(x['amount_currency'] for x in res['base_lines'][payment_term_line].values()) \
            //                             - sum(x['amount_currency'] for x in res['tax_lines'][payment_term_line].values())
            //     delta_balance = term_balance \
            //                     - sum(x['balance'] for x in res['base_lines'][payment_term_line].values()) \
            //                     - sum(x['balance'] for x in res['tax_lines'][payment_term_line].values())
            // 
            //     biggest_base_line = max(list(res['base_lines'][payment_term_line].values()), key=lambda x: x['amount_currency'])
            //     biggest_base_line['amount_currency'] += delta_amount_currency
            //     biggest_base_line['balance'] += delta_balance
            // 
            // else:
            //     grouping_dict = {'account_id': cash_discount_account.id}
            // 
            //     res['term_lines'][payment_term_line][frozendict(grouping_dict)] = {
            //         'name': _("Early Payment Discount"),
            //         'partner_id': payment_term_line.partner_id.id,
            //         'currency_id': payment_term_line.currency_id.id,
            //         'amount_currency': term_amount_currency,
            //         'balance': term_balance,
            //     }
            // 
            // return res
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoiceCurrencyRateDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_currency_rate_date(self):
            // self.ensure_one()
            // return self.invoice_date or fields.Date.context_today(self)
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoiceInPaymentStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_in_payment_state(self):
            // ''' Hook to give the state when the invoice becomes fully paid. This is necessary because the users working
            // with only invoicing don't want to see the 'in_payment' state. Then, this method will be overridden in the
            // accountant module to enable the 'in_payment' state. '''
            // return 'paid'
            --- ODOO METHOD SOURCE (MODULE: om_account_accountant, FILE: account_move.py) ---
            // def _get_invoice_in_payment_state(self):
            // return 'in_payment'
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoiceLegalDocumentsAllInternalAsync(object allow_fallback)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_legal_documents_all(self, allow_fallback=False):
            // """ Retrieve the invoice legal attachments: PDF, XML, ...
            // :param bool allow_fallback: if True, returns a Proforma if the PDF invoice doesn't exist.
            // :return list: a list of the attachments data such as
            // [{'filename': 'INV_2024_0001.pdf', 'filetype': 'pdf', 'content': ...}, ...]
            // """
            // self.ensure_one()
            // if self.invoice_pdf_report_id:
            //     attachments = self.env['account.move.send']._get_invoice_extra_attachments(self)
            //     return [
            //         {
            //             'filename': attachment.name,
            //             'filetype': attachment.mimetype,
            //             'content': attachment.raw,
            //         }
            //         for attachment in attachments
            //     ]
            // elif allow_fallback:
            //     return [self._get_invoice_pdf_proforma()]
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoiceLegalDocumentsInternalAsync(object filetype, object allow_fallback)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_legal_documents(self, filetype, allow_fallback=False):
            // """ Retrieve the invoice legal document of type filetype.
            // :param filetype: the type of legal document to retrieve. Example: 'pdf', 'all'.
            // :param bool allow_fallback: if True, returns a Proforma if the PDF invoice doesn't exist.
            // :return dict: the invoice PDF data such as
            // {'filename': 'INV_2024_0001.pdf', 'filetype': 'pdf', 'content':...}
            // To extend to add more supported filetypes.
            // """
            // self.ensure_one()
            // if filetype == 'pdf':
            //     if invoice_pdf := self.invoice_pdf_report_id:
            //         return {
            //             'filename': invoice_pdf.name,
            //             'filetype': invoice_pdf.mimetype,
            //             'content': invoice_pdf.raw,
            //         }
            //     elif allow_fallback:
            //         return self._get_invoice_pdf_proforma()
            // elif filetype == 'all':
            //     return self._get_invoice_legal_documents_all(allow_fallback=allow_fallback)
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py) ---
            // def _get_invoice_legal_documents(self, filetype, allow_fallback=False):
            // # EXTENDS account
            // if filetype == 'ubl':
            //     if ubl_attachment := self.ubl_cii_xml_id:
            //         return {
            //             'filename': ubl_attachment.name,
            //             'filetype': 'xml',
            //             'content': ubl_attachment.raw,
            //         }
            // return super()._get_invoice_legal_documents(filetype, allow_fallback=allow_fallback)
            */
            return default;
        }

        public async Task<AccountMove> GetInvoiceLocalisationFieldsRequiredToInvoiceAsync(Guid id, AccountMoveGetInvoiceLocalisationFieldsRequiredToInvoiceRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_invoice_localisation_fields_required_to_invoice(self, country_id):
            // """ Returns the list of fields that needs to be filled when creating an invoice for the selected country.
            // This is required for some flows that would allow a user to request an invoice from the portal.
            // Using these, we can get their information and dynamically create form inputs based for the fields required legally for the company country_id.
            // The returned fields must be of type ir.model.fields in order to handle translations
            // 
            // :param country_id: The country for which we want the fields.
            // :return: an array of ir.model.fields for which the user should provide values.
            // """
            // return []
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> GetInvoiceNextPaymentValuesInternalAsync(object custom_amount)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_next_payment_values(self, custom_amount=None):
            // self.ensure_one()
            // term_lines = self.line_ids.filtered(lambda line: line.display_type == 'payment_term')
            // if not term_lines:
            //     return {}
            // installments = term_lines._get_installments_data()
            // not_reconciled_installments = [x for x in installments if not x['reconciled']]
            // overdue_installments = [x for x in not_reconciled_installments if x['type'] == 'overdue']
            // # Early payment discounts can only have one installment at most
            // epd_installment = next((installment for installment in installments if installment['type'] == 'early_payment_discount'), {})
            // show_installments = len(installments) > 1
            // additional_info = {}
            // 
            // if show_installments and overdue_installments:
            //     installment_state = 'overdue'
            //     amount_due = self.amount_residual
            //     next_amount_to_pay = sum(x['amount_residual_currency_unsigned'] for x in overdue_installments)
            //     next_payment_reference = f"{self.name}-{overdue_installments[0]['number']}"
            //     next_due_date = overdue_installments[0]['date_maturity']
            // elif show_installments and not_reconciled_installments:
            //     installment_state = 'next'
            //     amount_due = self.amount_residual
            //     next_amount_to_pay = not_reconciled_installments[0]['amount_residual_currency_unsigned']
            //     next_payment_reference = f"{self.name}-{not_reconciled_installments[0]['number']}"
            //     next_due_date = not_reconciled_installments[0]['date_maturity']
            // elif epd_installment:
            //     installment_state = 'epd'
            //     amount_due = epd_installment['amount_residual_currency_unsigned']
            //     next_amount_to_pay = self.amount_residual
            //     next_payment_reference = self.name
            //     next_due_date = epd_installment['date_maturity']
            //     discount_date = epd_installment['line'].discount_date or fields.Date.context_today(self)
            //     discount_amount_currency = epd_installment['discount_amount_currency']
            //     days_left = max(0, (discount_date - fields.Date.context_today(self)).days)  # should never be lower than 0 since epd is valid
            //     if days_left > 0:
            //         discount_msg = _(
            //             "Discount of %(amount)s if paid within %(days)s days",
            //             amount=self.currency_id.format(discount_amount_currency),
            //             days=days_left,
            //         )
            //     else:
            //         discount_msg = _(
            //             "Discount of %(amount)s if paid today",
            //             amount=self.currency_id.format(discount_amount_currency),
            //         )
            // 
            //     additional_info.update({
            //         'epd_discount_amount_currency': discount_amount_currency,
            //         'epd_discount_amount': epd_installment['discount_amount'],
            //         'discount_date': fields.Date.to_string(discount_date),
            //         'epd_days_left': days_left,
            //         'epd_line': epd_installment['line'],
            //         'epd_discount_msg': discount_msg,
            //     })
            // else:
            //     installment_state = None
            //     amount_due = self.amount_residual
            //     next_amount_to_pay = self.amount_residual
            //     next_payment_reference = self.name
            //     next_due_date = self.invoice_date_due
            // 
            // if custom_amount is not None:
            //     is_custom_amount_same_as_next_amount = self.currency_id.is_zero(custom_amount - next_amount_to_pay)
            //     is_custom_amount_same_as_epd_discounted_amount = installment_state == 'epd' and self.currency_id.is_zero(custom_amount - amount_due)
            //     if not is_custom_amount_same_as_next_amount and not is_custom_amount_same_as_epd_discounted_amount:
            //         installment_state = 'next'
            //         next_amount_to_pay = custom_amount
            //         next_payment_reference = self.name
            //         next_due_date = installments[0]['date_maturity']
            // 
            // return {
            //     'payment_state': self.payment_state,
            //     'installment_state': installment_state,
            //     'next_amount_to_pay': next_amount_to_pay,
            //     'next_payment_reference': next_payment_reference,
            //     'amount_paid': self.amount_total - self.amount_residual,
            //     'amount_due': amount_due,
            //     'next_due_date': next_due_date,
            //     'due_date': self.invoice_date_due,
            //     'not_reconciled_installments': not_reconciled_installments,
            //     'is_last_installment': len(not_reconciled_installments) == 1,
            //     **additional_info,
            // }
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoicePdfProformaInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_pdf_proforma(self):
            // """ Generate the Proforma of the invoice.
            // :return dict: the Proforma's data such as
            // {'filename': 'INV_2024_0001_proforma.pdf', 'filetype': 'pdf', 'content': ...}
            // """
            // self.ensure_one()
            // filename = self._get_invoice_proforma_pdf_report_filename()
            // content, report_type = self.env['ir.actions.report']._pre_render_qweb_pdf('account.account_invoices', self.ids, data={'proforma': True})
            // content_by_id = self.env['ir.actions.report']._get_splitted_report('account.account_invoices', content, report_type)
            // return {
            //     'filename': filename,
            //     'filetype': 'pdf',
            //     'content': content_by_id[self.id],
            // }
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoicePortalExtraValuesInternalAsync(object custom_amount)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_portal_extra_values(self, custom_amount=None):
            // self.ensure_one()
            // return {
            //     'invoice': self,
            //     'currency': self.currency_id,
            //     **self._get_invoice_next_payment_values(custom_amount=custom_amount),
            // }
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoiceProformaPdfReportFilenameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_proforma_pdf_report_filename(self):
            // """ Get the filename of the generated proforma PDF invoice report. """
            // self.ensure_one()
            // return f"{self._get_move_display_name().replace(' ', '_').replace('/', '_')}_proforma.pdf"
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoiceReferenceEuroInvoiceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_reference_euro_invoice(self):
            // """ This computes the reference based on the RF Creditor Reference.
            //     The data of the reference is the database id number of the invoice.
            //     For instance, if an invoice is issued with id 43, the check number
            //     is 07 so the reference will be 'RF07 43'.
            // """
            // self.ensure_one()
            // return format_structured_reference_iso(self.id)
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoiceReferenceEuroPartnerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_reference_euro_partner(self):
            // """ This computes the reference based on the RF Creditor Reference.
            //     The data of the reference is the user defined reference of the
            //     partner or the database id number of the parter.
            //     For instance, if an invoice is issued for the partner with internal
            //     reference 'food buyer 654', the digits will be extracted and used as
            //     the data. This will lead to a check number equal to 00 and the
            //     reference will be 'RF00 654'.
            //     If no reference is set for the partner, its id in the database will
            //     be used.
            // """
            // self.ensure_one()
            // partner_ref = self.partner_id.ref
            // partner_ref_nr = re.sub(r'\D', '', partner_ref or '')[-21:] or str(self.partner_id.id)[-21:]
            // partner_ref_nr = partner_ref_nr[-21:]
            // return format_structured_reference_iso(partner_ref_nr)
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoiceReferenceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def _get_invoice_reference(self):
            // self.ensure_one()
            // vendor_refs = [ref for ref in set(self.invoice_line_ids.mapped('purchase_line_id.order_id.partner_ref')) if ref]
            // if self.ref:
            //     return [ref for ref in self.ref.split(', ') if ref and ref not in vendor_refs] + vendor_refs
            // return vendor_refs
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoiceReferenceOdooInvoiceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_reference_odoo_invoice(self):
            // """ This computes the reference based on the Odoo format.
            //     We simply return the number of the invoice, defined on the journal
            //     sequence.
            // """
            // self.ensure_one()
            // return self.name
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoiceReferenceOdooPartnerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_reference_odoo_partner(self):
            // """ This computes the reference based on the Odoo format.
            //     The data used is the reference set on the partner or its database
            //     id otherwise. For instance if the reference of the customer is
            //     'dumb customer 97', the reference will be 'CUST/dumb customer 97'.
            // """
            // ref = self.partner_id.ref or str(self.partner_id.id)
            // prefix = _('CUST')
            // return '%s/%s' % (prefix, ref)
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoiceReportFilenameInternalAsync(object extension)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_report_filename(self, extension='pdf'):
            // """ Get the filename of the generated invoice report with extension file. """
            // self.ensure_one()
            // return f"{self.name.replace('/', '_')}.{extension}"
            */
            return default;
        }

        public async Task<AccountMove> GetInvoiceTypesAsync(Guid id, AccountMoveGetInvoiceTypesRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_invoice_types(self, include_receipts=False):
            // return self.get_sale_types(include_receipts) + self.get_purchase_types(include_receipts)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> GetInvoicedLotValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: account_move.py) ---
            // def _get_invoiced_lot_values(self):
            // self.ensure_one()
            // 
            // lot_values = super(AccountMove, self)._get_invoiced_lot_values()
            // 
            // if self.state == 'draft':
            //     return lot_values
            // 
            // # user may not have access to POS orders, but it's ok if they have
            // # access to the invoice
            // for order in self.sudo().pos_order_ids:
            //     for line in order.lines:
            //         lots = line.pack_lot_ids or False
            //         if lots:
            //             for lot in lots:
            //                 lot_values.append({
            //                     'product_name': lot.product_id.name,
            //                     'quantity': line.qty if lot.product_id.tracking == 'lot' else 1.0,
            //                     'uom_name': line.product_uom_id.name,
            //                     'lot_name': lot.lot_name,
            //                     'pos_lot_id': lot.id,
            //                 })
            // 
            // return lot_values
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: account_move.py) ---
            // def _get_invoiced_lot_values(self):
            // """ Get and prepare data to show a table of invoiced lot on the invoice's report. """
            // self.ensure_one()
            // 
            // res = super(AccountMove, self)._get_invoiced_lot_values()
            // 
            // if self.state == 'draft' or not self.invoice_date or self.move_type not in ('out_invoice', 'out_refund'):
            //     return res
            // 
            // current_invoice_amls = self.invoice_line_ids.filtered(lambda aml: aml.display_type == 'product' and aml.product_id and aml.product_id.type == 'consu' and aml.quantity)
            // all_invoices_amls = current_invoice_amls.sale_line_ids.invoice_lines.filtered(lambda aml: aml._filter_aml_lot_valuation()).sorted(lambda aml: (aml.date, aml.move_name, aml.id))
            // index = all_invoices_amls.ids.index(current_invoice_amls[:1].id) if current_invoice_amls[:1] in all_invoices_amls else 0
            // previous_amls = all_invoices_amls[:index]
            // invoiced_qties = current_invoice_amls._get_invoiced_qty_per_product()
            // invoiced_products = invoiced_qties.keys()
            // 
            // if self.move_type == 'out_invoice':
            //     # filter out the invoices that have been fully refund and re-invoice otherwise, the quantities would be
            //     # consumed by the reversed invoice and won't be print on the new draft invoice
            //     previous_amls = previous_amls.filtered(lambda aml: aml.move_id.payment_state != 'reversed')
            // 
            // previous_qties_invoiced = previous_amls._get_invoiced_qty_per_product()
            // 
            // if self.move_type == 'out_refund':
            //     # we swap the sign because it's a refund, and it would print negative number otherwise
            //     for p in previous_qties_invoiced:
            //         previous_qties_invoiced[p] = -previous_qties_invoiced[p]
            //     for p in invoiced_qties:
            //         invoiced_qties[p] = -invoiced_qties[p]
            // 
            // qties_per_lot = defaultdict(float)
            // previous_qties_delivered = defaultdict(float)
            // stock_move_lines = current_invoice_amls.sale_line_ids.move_ids.move_line_ids.filtered(lambda sml: sml.state == 'done' and sml.lot_id).sorted(lambda sml: (sml.date, sml.id))
            // for sml in stock_move_lines:
            //     if sml.product_id not in invoiced_products or not sml._should_show_lot_in_invoice():
            //         continue
            //     product = sml.product_id
            //     product_uom = product.uom_id
            //     quantity = sml.product_uom_id._compute_quantity(sml.quantity, product_uom)
            // 
            //     # is it a stock return considering the document type (should it be it thought of as positively or negatively?)
            //     is_stock_return = (
            //             self.move_type == 'out_invoice' and (sml.location_id.usage, sml.location_dest_id.usage) == ('customer', 'internal')
            //             or
            //             self.move_type == 'out_refund' and (sml.location_id.usage, sml.location_dest_id.usage) == ('internal', 'customer')
            //     )
            //     if is_stock_return:
            //         returned_qty = min(qties_per_lot[sml.lot_id], quantity)
            //         qties_per_lot[sml.lot_id] -= returned_qty
            //         quantity = returned_qty - quantity
            // 
            //     previous_qty_invoiced = previous_qties_invoiced[product]
            //     previous_qty_delivered = previous_qties_delivered[product]
            //     # If we return more than currently delivered (i.e., quantity < 0), we remove the surplus
            //     # from the previously delivered (and quantity becomes zero). If it's a delivery, we first
            //     # try to reach the previous_qty_invoiced
            //     if float_compare(quantity, 0, precision_rounding=product_uom.rounding) < 0 or \
            //             float_compare(previous_qty_delivered, previous_qty_invoiced, precision_rounding=product_uom.rounding) < 0:
            //         previously_done = quantity if is_stock_return else min(previous_qty_invoiced - previous_qty_delivered, quantity)
            //         previous_qties_delivered[product] += previously_done
            //         quantity -= previously_done
            // 
            //     qties_per_lot[sml.lot_id] += quantity
            // 
            // for lot, qty in qties_per_lot.items():
            //     # access the lot as a superuser in order to avoid an error
            //     # when a user prints an invoice without having the stock access
            //     lot = lot.sudo()
            //     if float_is_zero(invoiced_qties[lot.product_id], precision_rounding=lot.product_uom_id.rounding) \
            //             or float_compare(qty, 0, precision_rounding=lot.product_uom_id.rounding) <= 0:
            //         continue
            //     invoiced_lot_qty = min(qty, invoiced_qties[lot.product_id])
            //     invoiced_qties[lot.product_id] -= invoiced_lot_qty
            //     res.append({
            //         'product_name': lot.product_id.display_name,
            //         'quantity': formatLang(self.env, invoiced_lot_qty, dp='Product Unit of Measure'),
            //         'uom_name': lot.product_uom_id.name,
            //         'lot_name': lot.name,
            //         # The lot id is needed by localizations to inherit the method and add custom fields on the invoice's report.
            //         'lot_id': lot.id,
            //     })
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move.py) ---
            // def _get_invoiced_lot_values(self):
            // return []
            */
            return default;
        }

        protected async Task<AccountMove> GetLastSequenceDomainInternalAsync(object relaxed)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_last_sequence_domain(self, relaxed=False):
            // #pylint: disable=sql-injection
            // # EXTENDS account sequence.mixin
            // self.ensure_one()
            // if not self.date or not self.journal_id:
            //     return "WHERE FALSE", {}
            // where_string = "WHERE journal_id = %(journal_id)s AND name != '/'"
            // param = {'journal_id': self.journal_id.id}
            // is_payment = self.origin_payment_id or self.env.context.get('is_payment')
            // 
            // if not relaxed:
            //     domain = [('journal_id', '=', self.journal_id.id), ('id', '!=', self.id or self._origin.id), ('name', 'not in', ('/', '', False))]
            //     if self.journal_id.refund_sequence:
            //         refund_types = ('out_refund', 'in_refund')
            //         domain += [('move_type', 'in' if self.move_type in refund_types else 'not in', refund_types)]
            //     if self.journal_id.payment_sequence:
            //         domain += [('origin_payment_id', '!=' if is_payment else '=', False)]
            //     reference_move_name = self.sudo().search(domain + [('date', '<=', self.date)], order='date desc', limit=1).name
            //     if not reference_move_name:
            //         reference_move_name = self.sudo().search(domain, order='date asc', limit=1).name
            //     sequence_number_reset = self._deduce_sequence_number_reset(reference_move_name)
            //     date_start, date_end, *_ = self._get_sequence_date_range(sequence_number_reset)
            //     where_string += """ AND date BETWEEN %(date_start)s AND %(date_end)s"""
            //     param['date_start'] = date_start
            //     param['date_end'] = date_end
            // 
            //     # Some regex are catching more sequence formats than we want, so we
            //     # need to exclude them:
            //     #
            //     #                    |                 Regex type                                 |
            //     # Move Name Format   | Fixed | Yearly | Monthly | Year Range | Year range Monthly |
            //     # ------------------ | ----- | ------ | ------- | ---------- | ------------------ |
            //     # Fixed              |   X   |        |         |            |                    |
            //     # Yearly             |   X   |   X    |         |            |                    |
            //     # Monthly            |   X   |   X    |    X    |     X      |                    |
            //     # Year Range         |   X   |   X    |         |     X      |                    |
            //     # Year range Monthly |   X   |   X    |    X    |     X      |          X         |
            //     if sequence_number_reset in ('year', 'year_range'):
            //         param['anti_regex'] = self._make_regex_non_capturing(self._sequence_monthly_regex.split('(?P<seq>')[0]) + '$'
            //     elif sequence_number_reset == 'never':
            //         # Excluding yearly will also exclude "monthly", "year range" and
            //         # "year range monthly"
            //         param['anti_regex'] = self._make_regex_non_capturing(self._sequence_yearly_regex.split('(?P<seq>')[0]) + '$'
            // 
            //     if param.get('anti_regex') and not self.journal_id.sequence_override_regex:
            //         where_string += " AND sequence_prefix !~ %(anti_regex)s "
            // 
            // if self.journal_id.refund_sequence:
            //     if self.move_type in ('out_refund', 'in_refund'):
            //         where_string += " AND move_type IN ('out_refund', 'in_refund') "
            //     else:
            //         where_string += " AND move_type NOT IN ('out_refund', 'in_refund') "
            // elif self.journal_id.payment_sequence:
            //     if is_payment:
            //         where_string += " AND origin_payment_id IS NOT NULL "
            //     else:
            //         where_string += " AND origin_payment_id IS NULL "
            // 
            // return where_string, param
            --- ODOO METHOD SOURCE (MODULE: account_debit_note, FILE: account_move.py) ---
            // def _get_last_sequence_domain(self, relaxed=False):
            // where_string, param = super()._get_last_sequence_domain(relaxed)
            // if self.journal_id.debit_sequence:
            //     where_string += " AND debit_origin_id IS " + ("NOT NULL" if self.debit_origin_id else "NULL")
            // return where_string, param
            */
            return default;
        }

        protected async Task<AccountMove> GetLineValsListInternalAsync(object lines_vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py) ---
            // def _get_line_vals_list(self, lines_vals):
            // """ Get invoice line values list.
            // 
            // param list line_vals: List of values [name, qty, price, tax].
            // :return: List of invoice line values.
            // """
            // return [{
            //     'sequence': 0,  # be sure to put these lines above the 'real' invoice lines
            //     'name': name,
            //     'quantity': quantity,
            //     'price_unit': price_unit,
            //     'tax_ids': [Command.set(tax_ids)],
            // } for name, quantity, price_unit, tax_ids in lines_vals]
            */
            return default;
        }

        protected async Task<AccountMove> GetLinesOnchangeCurrencyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_lines_onchange_currency(self):
            // # Override needed for COGS
            // return self.line_ids
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move.py) ---
            // def _get_lines_onchange_currency(self):
            // # OVERRIDE
            // return self.line_ids.filtered(lambda l: l.display_type != 'cogs')
            */
            return default;
        }

        protected async Task<AccountMove> GetLockDateMessageInternalAsync(object invoice_date, object has_tax)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_lock_date_message(self, invoice_date, has_tax):
            // """Get a message describing the latest lock date affecting the specified date.
            // :param invoice_date: The date to be checked
            // :param has_tax: If any taxes are involved in the lines of the invoice
            // :return: a message describing the latest lock date affecting this move and the date it will be
            //          accounted on if posted, or False if no lock dates affect this move.
            // """
            // lock_dates = self._get_violated_lock_dates(invoice_date, has_tax)
            // if lock_dates:
            //     invoice_date = self._get_accounting_date(invoice_date, has_tax, lock_dates=lock_dates)
            //     tax_lock_date_message = _(
            //         "The date is being set prior to: %(lock_date_info)s. "
            //         "The Journal Entry will be accounted on %(invoice_date)s upon posting.",
            //         lock_date_info=self.env['res.company']._format_lock_dates(lock_dates),
            //         invoice_date=format_date(self.env, invoice_date))
            //     return tax_lock_date_message
            // return False
            */
            return default;
        }

        protected async Task<AccountMove> GetMailTemplateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_mail_template(self):
            // """
            // :return: the correct mail template based on the current move type
            // """
            // return self.env.ref(
            //     'account.email_template_edi_credit_note'
            //     if all(move.move_type == 'out_refund' for move in self)
            //     else 'account.email_template_edi_invoice'
            // )
            */
            return default;
        }

        protected async Task<AccountMove> GetMailThreadDataAttachmentsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_mail_thread_data_attachments(self):
            // res = super()._get_mail_thread_data_attachments()
            // # else, attachments with 'res_field' get excluded
            // return res | self.env['account.move.send']._get_invoice_extra_attachments(self)
            */
            return default;
        }

        protected async Task<AccountMove> GetMoveDisplayNameInternalAsync(object show_ref)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_move_display_name(self, show_ref=False):
            // ''' Helper to get the display name of an invoice depending of its type.
            // :param show_ref:    A flag indicating of the display name must include or not the journal entry reference.
            // :return:            A string representing the invoice.
            // '''
            // self.ensure_one()
            // if self.env.context.get('name_as_amount_total'):
            //     currency_amount = self.currency_id.format(self.amount_total)
            //     if self.state == 'posted':
            //         return _("%(ref)s (%(currency_amount)s)", ref=(self.ref or self.name), currency_amount=currency_amount)
            //     else:
            //         return _("Draft (%(currency_amount)s)", currency_amount=currency_amount)
            // name = ''
            // if self.state == 'draft':
            //     name += {
            //         'out_invoice': _('Draft Invoice'),
            //         'out_refund': _('Draft Credit Note'),
            //         'in_invoice': _('Draft Bill'),
            //         'in_refund': _('Draft Vendor Credit Note'),
            //         'out_receipt': _('Draft Sales Receipt'),
            //         'in_receipt': _('Draft Purchase Receipt'),
            //         'entry': _('Draft Entry'),
            //     }[self.move_type]
            // if self.name and self.name != '/':
            //     name = f"{name} {self.name}".strip()
            //     if self.env.context.get('input_full_display_name'):
            //         if self.partner_id:
            //             name += f', {self.partner_id.name}'
            //         if self.date:
            //             name += f', {format_date(self.env, self.date)}'
            // return name + (f" ({shorten(self.ref, width=50)})" if show_ref and self.ref else '')
            */
            return default;
        }

        protected async Task<AccountMove> GetMoveHashDomainInternalAsync(object common_domain, object force_hash)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_move_hash_domain(self, common_domain=False, force_hash=False):
            // """
            // Returns a search domain on model account.move checking whether they should be hashed.
            // :param common_domain: a search domain that will be included in the returned domain in any case
            // :param force_hash: if True, we'll check all moves posted, independently of journal settings
            // """
            // common_domain = expression.AND([
            //     common_domain or [],
            //     [('state', '=', 'posted')],
            // ])
            // if force_hash:
            //     return common_domain
            // return expression.AND([
            //     common_domain,
            //     [('restrict_mode_hash_table', '=', True)],
            // ])
            */
            return default;
        }

        protected async Task<AccountMove> GetNameInvoiceReportInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_name_invoice_report(self):
            // """ This method need to be inherit by the localizations if they want to print a custom invoice report instead of
            // the default one. For example please review the l10n_ar module """
            // self.ensure_one()
            // return 'account.report_invoice_document'
            */
            return default;
        }

        protected async Task<AccountMove> GetOnlinePaymentErrorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: account_move.py) ---
            // def _get_online_payment_error(self):
            // """
            // Returns the appropriate error message to be displayed if _has_to_be_paid() method returns False.
            // """
            // self.ensure_one()
            // transactions = self.transaction_ids.filtered(lambda tx: tx.state in ('pending', 'authorized', 'done'))
            // pending_transactions = transactions.filtered(
            //     lambda tx: tx.state in {'pending', 'authorized'}
            //                and tx.provider_code not in {'none', 'custom'})
            // enabled_feature = str2bool(
            //     self.env['ir.config_parameter'].sudo().get_param(
            //         'account_payment.enable_portal_payment'
            //     )
            // )
            // errors = []
            // if not enabled_feature:
            //     errors.append(_("This invoice cannot be paid online."))
            // if transactions or self.currency_id.is_zero(self.amount_residual):
            //     errors.append(_("There is no amount to be paid."))
            // if self.state != 'posted':
            //     errors.append(_("This invoice isn't posted."))
            // if self.currency_id.is_zero(self.amount_residual):
            //     errors.append(_("This invoice has already been paid."))
            // if self.move_type != 'out_invoice':
            //     errors.append(_("This is not an outgoing invoice."))
            // if pending_transactions:
            //     errors.append(_("There are pending transactions for this invoice."))
            // return '\n'.join(errors)
            */
            return default;
        }

        public async Task<AccountMove> GetOutboundTypesAsync(Guid id, AccountMoveGetOutboundTypesRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_outbound_types(self, include_receipts=True):
            // return ['in_invoice', 'out_refund'] + (include_receipts and ['in_receipt'] or [])
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> GetPartnerCreditWarningExcludeAmountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_partner_credit_warning_exclude_amount(self):
            // # to extend in module 'sale'; see there for details
            // self.ensure_one()
            // return 0
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move.py) ---
            // def _get_partner_credit_warning_exclude_amount(self):
            // # EXTENDS module 'account'
            // # Consider the warning on a draft invoice created from a sales order.
            // # After confirming the invoice the (partial) amount (on the invoice)
            // # stemming from sales orders will be substracted from the credit_to_invoice.
            // # This will reduce the total credit of the partner.
            // # The computation should reflect the change of credit_to_invoice from 'res.partner'.
            // # (see _compute_credit_to_invoice and _compute_amount_to_invoice from 'sale.order' )
            // exclude_amount = super()._get_partner_credit_warning_exclude_amount()
            // for order in self.line_ids.sale_line_ids.order_id:
            //     order_amount = min(self._get_sale_order_invoiced_amount(order), order.amount_to_invoice)
            //     order_amount_company = order.currency_id._convert(
            //         max(order_amount, 0),
            //         self.company_id.currency_id,
            //         self.company_id,
            //         fields.Date.context_today(self)
            //     )
            //     exclude_amount += order_amount_company
            // return exclude_amount
            */
            return default;
        }

        public async Task<AccountMove> GetPortalLastTransactionAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: account_move.py) ---
            // def get_portal_last_transaction(self):
            // self.ensure_one()
            // return self.with_context(active_test=False).transaction_ids.sudo()._get_last()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> GetProductCatalogDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_product_catalog_domain(self):
            // if self.is_sale_document():
            //     return expression.AND([super()._get_product_catalog_domain(), [('sale_ok', '=', True)]])
            // elif self.is_purchase_document():
            //     return expression.AND([super()._get_product_catalog_domain(), [('purchase_ok', '=', True)]])
            // else:  # In case of an entry
            //     return super()._get_product_catalog_domain()
            */
            return default;
        }

        protected async Task<AccountMove> GetProductCatalogOrderDataInternalAsync(object products)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_product_catalog_order_data(self, products, **kwargs):
            // product_catalog = super()._get_product_catalog_order_data(products, **kwargs)
            // for product in products:
            //     product_catalog[product.id] |= self._get_product_price_and_data(product)
            // return product_catalog
            */
            return default;
        }

        protected async Task<AccountMove> GetProductCatalogRecordLinesInternalAsync(List<Guid> product_ids, object child_field)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_product_catalog_record_lines(self, product_ids, child_field=False):
            // grouped_lines = defaultdict(lambda: self.env['account.move.line'])
            // for line in self.line_ids:
            //     if line.display_type == 'product' and line.product_id.id in product_ids:
            //         grouped_lines[line.product_id] |= line
            // return grouped_lines
            */
            return default;
        }

        protected async Task<AccountMove> GetProductPriceAndDataInternalAsync(object product)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_product_price_and_data(self, product):
            // """
            //     This function will return a dict containing the price of the product. If the product is a sale document then
            //     we return the list price (which is the "Sales Price" in a product) otherwise we return the standard_price
            //     (which is the "Cost" in a product).
            //     In case of a purchase document, it's possible that we have special price for certain partner.
            //     We will check the sellers set on the product and update the price and min_qty for it if needed.
            // """
            // self.ensure_one()
            // product_infos = {'price': product.list_price if self.is_sale_document() else product.standard_price}
            // 
            // # Check if there is a price and a minimum quantity for the order's vendor.
            // if self.is_purchase_document() and self.partner_id:
            //     seller = product._select_seller(
            //         partner_id=self.partner_id,
            //         quantity=None,
            //         date=self.invoice_date,
            //         uom_id=product.uom_id,
            //         ordered_by='min_qty',
            //         params={'order_id': self}
            //     )
            //     if seller:
            //         product_infos.update(
            //             price=seller.price,
            //             min_qty=seller.min_qty,
            //         )
            // return product_infos
            */
            return default;
        }

        protected async Task<AccountMove> GetProtectedValsInternalAsync(object vals, object records)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_protected_vals(self, vals, records):
            // protected = set()
            // for fname in vals:
            //     field = records._fields[fname]
            //     if field.inverse or (field.compute and not field.readonly):
            //         protected.update(self.pool.field_computed.get(field, [field]))
            // return [(protected, rec) for rec in records] if protected else []
            */
            return default;
        }

        public async Task<AccountMove> GetPurchaseTypesAsync(Guid id, AccountMoveGetPurchaseTypesRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_purchase_types(self, include_receipts=False):
            // return ['in_invoice', 'in_refund'] + (include_receipts and ['in_receipt'] or [])
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> GetQuickEditSuggestionsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_quick_edit_suggestions(self):
            // """
            // Returns a dictionnary containing the suggested values when creating a new
            // line with the quick_edit_total_amount set. We will compute the price_unit
            // that has to be set with the correct that in order to match this total amount.
            // If the vendor/customer is set, we will suggest the most frequently used account
            // for that partner as the default one, otherwise the default of the journal.
            // """
            // self.ensure_one()
            // if not self.quick_edit_mode or not self.quick_edit_total_amount:
            //     return False
            // count, account_id, tax_ids = self._get_frequent_account_and_taxes(
            //     self.company_id.id,
            //     self.partner_id.id,
            //     self.move_type,
            // )
            // if count:
            //     taxes = self.env['account.tax'].browse(tax_ids)
            // else:
            //     account_id = self.journal_id.default_account_id.id
            //     if self.is_sale_document(include_receipts=True):
            //         taxes = self.journal_id.default_account_id.tax_ids.filtered(lambda tax: tax.type_tax_use == 'sale')
            //     else:
            //         taxes = self.journal_id.default_account_id.tax_ids.filtered(lambda tax: tax.type_tax_use == 'purchase')
            //     if not taxes:
            //         taxes = (
            //             self.journal_id.company_id.account_sale_tax_id
            //             if self.journal_id.type == 'sale' else
            //             self.journal_id.company_id.account_purchase_tax_id
            //         )
            //     taxes = self.fiscal_position_id.map_tax(taxes)
            // 
            // # When a payment term has an early payment discount with the epd computation set to 'mixed', recomputing
            // # the untaxed amount should take in consideration the discount percentage otherwise we'd get a wrong value.
            // # We check that we have only one percentage tax as computing from multiple taxes with different types can get complicated.
            // # In one example: let's say: base = 100, discount = 2%, tax = 21%
            // # the total will be calculated as: total = base + (base * (1 - discount)) * tax
            // # If we manipulate the equation to get the base from the total, we'll have base = total / ((1 - discount) * tax + 1)
            // term = self.invoice_payment_term_id
            // discount_percentage = term.discount_percentage if term.early_discount else 0
            // remaining_amount = self.quick_edit_total_amount - self.tax_totals['total_amount_currency']
            // 
            // if (
            //         discount_percentage
            //         and term.early_pay_discount_computation == 'mixed'
            //         and len(taxes) == 1
            //         and taxes.amount_type == 'percent'
            // ):
            //     price_untaxed = self.currency_id.round(
            //         remaining_amount / (((1.0 - discount_percentage / 100.0) * (taxes.amount / 100.0)) + 1.0))
            // else:
            //     price_untaxed = taxes.with_context(force_price_include=True).compute_all(remaining_amount)['total_excluded']
            // return {'account_id': account_id, 'tax_ids': taxes.ids, 'price_unit': price_untaxed}
            */
            return default;
        }

        protected async Task<AccountMove> GetRangeDatesInternalAsync(object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: account_move.py) ---
            // def _get_range_dates(self, order):
            // # A method that can be overridden
            // # to set the start and end dates according to order values
            // return None, None
            */
            return default;
        }

        protected async Task<AccountMove> GetReconciledAmlsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_reconciled_amls(self):
            // """Helper used to retrieve the reconciled move lines on this journal entry"""
            // reconciled_lines = self.line_ids.filtered(lambda line: line.account_id.account_type in ('asset_receivable', 'liability_payable'))
            // return reconciled_lines.mapped('matched_debit_ids.debit_move_id') + reconciled_lines.mapped('matched_credit_ids.credit_move_id')
            */
            return default;
        }

        protected async Task<AccountMove> GetReconciledInvoicesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_reconciled_invoices(self):
            // """Helper used to retrieve the reconciled invoices on this journal entry"""
            // return self._get_reconciled_amls().move_id.filtered(lambda move: move.is_invoice(include_receipts=True))
            */
            return default;
        }

        protected async Task<AccountMove> GetReconciledInvoicesPartialsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_reconciled_invoices_partials(self):
            // ''' Helper to retrieve the details about reconciled invoices.
            // :return A list of tuple (partial, amount, invoice_line).
            // '''
            // self.ensure_one()
            // pay_term_lines = self.line_ids\
            //     .filtered(lambda line: line.account_type in ('asset_receivable', 'liability_payable'))
            // invoice_partials = []
            // exchange_diff_moves = []
            // 
            // for partial in pay_term_lines.matched_debit_ids:
            //     invoice_partials.append((partial, partial.credit_amount_currency, partial.debit_move_id))
            //     if partial.exchange_move_id:
            //         exchange_diff_moves.append(partial.exchange_move_id.id)
            // for partial in pay_term_lines.matched_credit_ids:
            //     invoice_partials.append((partial, partial.debit_amount_currency, partial.credit_move_id))
            //     if partial.exchange_move_id:
            //         exchange_diff_moves.append(partial.exchange_move_id.id)
            // return invoice_partials, exchange_diff_moves
            */
            return default;
        }

        protected async Task<AccountMove> GetReconciledPaymentsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_reconciled_payments(self):
            // """Helper used to retrieve the reconciled payments on this journal entry"""
            // return self._get_reconciled_amls().move_id.origin_payment_id
            */
            return default;
        }

        protected async Task<AccountMove> GetReconciledStatementLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_reconciled_statement_lines(self):
            // """Helper used to retrieve the reconciled statement lines on this journal entry"""
            // return self._get_reconciled_amls().move_id.statement_line_id
            */
            return default;
        }

        protected async Task<AccountMove> GetReportBaseFilenameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_report_base_filename(self):
            // return self._get_move_display_name()
            */
            return default;
        }

        protected async Task<AccountMove> GetRoundedBaseAndTaxLinesInternalAsync(object round_from_tax_lines)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_rounded_base_and_tax_lines(self, round_from_tax_lines=True):
            // """ Small helper to extract the base and tax lines for the taxes computation from the current move.
            // The move could be stored or not and could have some features generating extra journal items acting as
            // base lines for the taxes computation (e.g. epd, rounding lines).
            // 
            // :param round_from_tax_lines:    Indicate if the manual tax amounts of tax journal items should be kept or not.
            //                                 It only works when the move is stored.
            // :return:                        A tuple <base_lines, tax_lines> for the taxes computation.
            // """
            // self.ensure_one()
            // AccountTax = self.env['account.tax']
            // is_invoice = self.is_invoice(include_receipts=True)
            // 
            // if self.id or not is_invoice:
            //     base_amls = self.line_ids.filtered(lambda line: line.display_type == 'product')
            // else:
            //     base_amls = self.invoice_line_ids.filtered(lambda line: line.display_type == 'product')
            // base_lines = [self._prepare_product_base_line_for_taxes_computation(line) for line in base_amls]
            // 
            // tax_lines = []
            // if self.id:
            //     # The move is stored so we can add the early payment discount lines directly to reduce the
            //     # tax amount without touching the untaxed amount.
            //     epd_amls = self.line_ids.filtered(lambda line: line.display_type == 'epd')
            //     base_lines += [self._prepare_epd_base_line_for_taxes_computation(line) for line in epd_amls]
            //     cash_rounding_amls = self.line_ids \
            //         .filtered(lambda line: line.display_type == 'rounding' and not line.tax_repartition_line_id)
            //     base_lines += [self._prepare_cash_rounding_base_line_for_taxes_computation(line) for line in cash_rounding_amls]
            //     AccountTax._add_tax_details_in_base_lines(base_lines, self.company_id)
            //     tax_amls = self.line_ids.filtered('tax_repartition_line_id')
            //     tax_lines = [self._prepare_tax_line_for_taxes_computation(tax_line) for tax_line in tax_amls]
            //     AccountTax._round_base_lines_tax_details(base_lines, self.company_id, tax_lines=tax_lines if round_from_tax_lines else [])
            // else:
            //     # The move is not stored yet so the only thing we have is the invoice lines.
            //     base_lines += self._prepare_epd_base_lines_for_taxes_computation_from_base_lines(base_amls)
            //     AccountTax._add_tax_details_in_base_lines(base_lines, self.company_id)
            //     AccountTax._round_base_lines_tax_details(base_lines, self.company_id)
            // return base_lines, tax_lines
            */
            return default;
        }

        protected async Task<AccountMove> GetSaleOrderInvoicedAmountInternalAsync(object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move.py) ---
            // def _get_sale_order_invoiced_amount(self, order):
            // """
            // Consider all lines on any invoice in self that stem from the sales order `order`. (All those invoices belong to order.company_id)
            // This function returns the sum of the totals of all those lines.
            // Note that this amount may be bigger than `order.amount_total`.
            // """
            // order_amount = 0
            // for invoice in self:
            //     prices = sum(invoice.line_ids.filtered(lambda x: order in x.sale_line_ids.order_id).mapped('price_total'))
            //     order_amount += invoice.currency_id._convert(
            //         prices * -invoice.direction_sign,
            //         order.currency_id,
            //         invoice.company_id,
            //         invoice.date,
            //     )
            // return order_amount
            */
            return default;
        }

        public async Task<AccountMove> GetSaleTypesAsync(Guid id, AccountMoveGetSaleTypesRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_sale_types(self, include_receipts=False):
            // return ['out_invoice', 'out_refund'] + (include_receipts and ['out_receipt'] or [])
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> GetSequenceDateRangeInternalAsync(object reset)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_sequence_date_range(self, reset):
            // if reset not in ('year_range', 'year_range_month'):
            //     return super()._get_sequence_date_range(reset)
            // 
            // fiscalyear_last_day = self.company_id.fiscalyear_last_day
            // fiscalyear_last_month = int(self.company_id.fiscalyear_last_month)
            // date_start, date_end = date_utils.get_fiscal_year(self.date, day=fiscalyear_last_day, month=fiscalyear_last_month)
            // 
            // if reset == 'year_range':
            //     return (date_start, date_end) + (None, None)
            // 
            // forced_year_range = (date_start.year, date_end.year)
            // month_range = date_utils.get_month(self.date)
            // fiscalyear_last_month_max_day = calendar.monthrange(self.date.year, fiscalyear_last_month)[1]
            // # We need to truncate the month if:
            // # - the fiscal year does not end on the last day of the month
            // # - and the move date is part of that month
            // # The sequence date range will be something like 2020-11-01 to
            // # 2020-11-30. But the sequence should be 2019-2020/11/0001 (or
            // # 2020-2021/11/0001), not 2020-2020/11/0001.
            // if fiscalyear_last_day < fiscalyear_last_month_max_day and fiscalyear_last_month == self.date.month:
            //     if self.date.day <= fiscalyear_last_day:
            //         return (month_range[0], month_range[1].replace(day=fiscalyear_last_day)) + forced_year_range
            //     else:
            //         return (month_range[0].replace(day=fiscalyear_last_day + 1), month_range[1]) + forced_year_range
            // else:
            //     return month_range + forced_year_range
            */
            return default;
        }

        protected async Task<AccountMove> GetSpecificTaxInternalAsync(object name, object amount_type, object amount, object tax_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py) ---
            // def _get_specific_tax(self, name, amount_type, amount, tax_type):
            // AccountMoveLine = self.env['account.move.line']
            // if hasattr(AccountMoveLine, '_predict_specific_tax'):
            //     # company check is already done in the prediction query
            //     predicted_tax_id = AccountMoveLine._predict_specific_tax(
            //         self, name, self.partner_id, amount_type, amount, tax_type,
            //     )
            //     return self.env['account.tax'].browse(predicted_tax_id)
            // return self.env['account.tax']
            */
            return default;
        }

        protected async Task<AccountMove> GetStartingSequenceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_starting_sequence(self):
            // # EXTENDS account sequence.mixin
            // self.ensure_one()
            // move_date = self.date or self.invoice_date or fields.Date.context_today(self)
            // year_part = "%04d" % move_date.year
            // last_day = int(self.company_id.fiscalyear_last_day)
            // last_month = int(self.company_id.fiscalyear_last_month)
            // is_staggered_year = last_month != 12 or last_day != 31
            // if is_staggered_year:
            //     max_last_day = calendar.monthrange(move_date.year, last_month)[1]
            //     last_day = min(last_day, max_last_day)
            //     if move_date > date(move_date.year, last_month, last_day):
            //         year_part = "%s-%s" % (move_date.strftime('%y'), (move_date + relativedelta(years=1)).strftime('%y'))
            //     else:
            //         year_part = "%s-%s" % ((move_date + relativedelta(years=-1)).strftime('%y'), move_date.strftime('%y'))
            // # Arbitrarily use annual sequence for sales documents, but monthly
            // # sequence for other documents
            // if self.journal_id.type in ['sale', 'bank', 'cash', 'credit']:
            //     # We reduce short code to 4 characters (0000) in case of staggered
            //     # year to avoid too long sequences (see Indian GST rule 46(b) for
            //     # example). Note that it's already the case for monthly sequences.
            //     starting_sequence = "%s/%s/%s" % (self.journal_id.code, year_part, '0000' if is_staggered_year else '00000')
            // else:
            //     starting_sequence = "%s/%s/%02d/0000" % (self.journal_id.code, year_part, move_date.month)
            // if self.journal_id.refund_sequence and self.move_type in ('out_refund', 'in_refund'):
            //     starting_sequence = "R" + starting_sequence
            // if self.journal_id.payment_sequence and self.origin_payment_id or self.env.context.get('is_payment'):
            //     starting_sequence = "P" + starting_sequence
            // return starting_sequence
            --- ODOO METHOD SOURCE (MODULE: account_debit_note, FILE: account_move.py) ---
            // def _get_starting_sequence(self):
            // starting_sequence = super()._get_starting_sequence()
            // if (
            //     self.journal_id.debit_sequence
            //     and self.debit_origin_id
            //     and self.move_type in ("in_invoice", "out_invoice")
            // ):
            //     starting_sequence = "D" + starting_sequence
            // return starting_sequence
            */
            return default;
        }

        protected async Task<AccountMove> GetUblCiiBuilderFromXmlTreeInternalAsync(object tree)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py) ---
            // def _get_ubl_cii_builder_from_xml_tree(self, tree):
            // customization_id = tree.find('{*}CustomizationID')
            // if tree.tag == '{urn:un:unece:uncefact:data:standard:CrossIndustryInvoice:100}CrossIndustryInvoice':
            //     return self.env['account.edi.xml.cii']
            // ubl_version = tree.find('{*}UBLVersionID')
            // if ubl_version is not None:
            //     if ubl_version.text == '2.0':
            //         return self.env['account.edi.xml.ubl_20']
            //     if ubl_version.text in ('2.1', '2.2', '2.3'):
            //         return self.env['account.edi.xml.ubl_21']
            // if customization_id is not None:
            //     if 'xrechnung' in customization_id.text:
            //         return self.env['account.edi.xml.ubl_de']
            //     if customization_id.text == 'urn:cen.eu:en16931:2017#compliant#urn:fdc:nen.nl:nlcius:v1.0':
            //         return self.env['account.edi.xml.ubl_nl']
            //     if customization_id.text == 'urn:cen.eu:en16931:2017#conformant#urn:fdc:peppol.eu:2017:poacc:billing:international:aunz:3.0':
            //         return self.env['account.edi.xml.ubl_a_nz']
            //     if customization_id.text == 'urn:cen.eu:en16931:2017#conformant#urn:fdc:peppol.eu:2017:poacc:billing:international:sg:3.0':
            //         return self.env['account.edi.xml.ubl_sg']
            //     if 'urn:cen.eu:en16931:2017' in customization_id.text:
            //         return self.env['account.edi.xml.ubl_bis3']
            */
            return default;
        }

        protected async Task<AccountMove> GetUnbalancedMovesInternalAsync(object container)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_unbalanced_moves(self, container):
            // moves = container['records'].filtered(lambda move: move.line_ids)
            // if not moves:
            //     return
            // 
            // # /!\ As this method is called in create / write, we can't make the assumption the computed stored fields
            // # are already done. Then, this query MUST NOT depend on computed stored fields.
            // # It happens as the ORM calls create() with the 'no_recompute' statement.
            // self.env['account.move.line'].flush_model(['debit', 'credit', 'balance', 'currency_id', 'move_id'])
            // return self.env.execute_query(SQL('''
            //     SELECT line.move_id,
            //            ROUND(SUM(line.debit), currency.decimal_places) debit,
            //            ROUND(SUM(line.credit), currency.decimal_places) credit
            //       FROM account_move_line line
            //       JOIN account_move move ON move.id = line.move_id
            //       JOIN res_company company ON company.id = move.company_id
            //       JOIN res_currency currency ON currency.id = company.currency_id
            //      WHERE line.move_id IN %s
            //   GROUP BY line.move_id, currency.decimal_places
            //     HAVING ROUND(SUM(line.balance), currency.decimal_places) != 0
            // ''', tuple(moves.ids)))
            */
            return default;
        }

        protected async Task<AccountMove> GetUnlinkLoggerMessageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_unlink_logger_message(self):
            // """ Before unlink, get a log message for audit trail if it's enabled.
            // Logger is added here because in api ondelete, account.move.line is deleted, and we can't get total amount """
            // if not self._context.get('force_delete'):
            //     pass
            // 
            // moves_details = []
            // for move in self.filtered(lambda m: m.posted_before and m.company_id.check_account_audit_trail):
            //     entry_details = f"{move.name} ({move.id}) amount {move.amount_total} {move.currency_id.name} and partner {move.partner_id.display_name}"
            //     account_balances_per_account = defaultdict(float)
            //     for line in move.line_ids:
            //         account_balances_per_account[line.account_id] += line.balance
            //     account_details = "\n".join(
            //         f"- {account.name} ({account.id}) with balance {balance} {move.currency_id.name}"
            //         for account, balance in account_balances_per_account.items()
            //     )
            //     moves_details.append(f"{entry_details}\n{account_details}")
            // 
            // if moves_details:
            //     return "\nForce deleted Journal Entries by {user_name} ({user_id})\nEntries\n{moves_details}".format(
            //         user_name=self.env.user.name,
            //         user_id=self.env.user.id,
            //         moves_details="\n".join(moves_details),
            //     )
            */
            return default;
        }

        protected async Task<AccountMove> GetValidJournalTypesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_valid_journal_types(self):
            // if self.is_sale_document(include_receipts=True):
            //     return ['sale']
            // elif self.is_purchase_document(include_receipts=True):
            //     return ['purchase']
            // elif self.origin_payment_id or self.statement_line_id or self.env.context.get('is_payment') or self.env.context.get('is_statement_line'):
            //     return ['bank', 'cash', 'credit']
            // return ['general']
            */
            return default;
        }

        protected async Task<AccountMove> GetViewInternalAsync(Guid view_id, object view_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_view(self, view_id=None, view_type='form', **options):
            // arch, view = super()._get_view(view_id, view_type, **options)
            // if view_type == 'form':
            //     if name_node := arch.xpath("""//field[@name="name"][@invisible="name == '/' and not posted_before and not quick_edit_mode"]"""):
            //         name_node[0].set('invisible', "not (name or name_placeholder or quick_edit_mode)")
            //     if draft_node := arch.xpath("""//span[@invisible="name == '/' and not posted_before and not quick_edit_mode"]"""):
            //         draft_node[0].set('invisible', "name or name_placeholder or quick_edit_mode")
            // return arch, view
            */
            return default;
        }

        protected async Task<AccountMove> GetViolatedLockDatesInternalAsync(object invoice_date, object has_tax)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_violated_lock_dates(self, invoice_date, has_tax):
            // """Get all the lock dates affecting the current invoice_date.
            // :param invoice_date: The invoice date
            // :param has_tax: If any taxes are involved in the lines of the invoice
            // :return: a list of tuples containing the lock dates affecting this move, ordered chronologically.
            // """
            // self.ensure_one()
            // return self.company_id._get_violated_lock_dates(invoice_date, has_tax, self.journal_id)
            */
            return default;
        }

        protected async Task<AccountMove> HasToBePaidInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: account_move.py) ---
            // def _has_to_be_paid(self):
            // self.ensure_one()
            // transactions = self.transaction_ids.filtered(lambda tx: tx.state in ('pending', 'authorized', 'done'))
            // pending_transactions = transactions.filtered(
            //     lambda tx: tx.state in {'pending', 'authorized'}
            //                and tx.provider_code not in {'none', 'custom'})
            // enabled_feature = str2bool(
            //     self.env['ir.config_parameter'].sudo().get_param(
            //         'account_payment.enable_portal_payment'
            //     )
            // )
            // return enabled_feature and bool(
            //     (self.amount_residual or not transactions)
            //     and self.state == 'posted'
            //     and self.payment_state in ('not_paid', 'in_payment', 'partial')
            //     and not self.currency_id.is_zero(self.amount_residual)
            //     and self.amount_total
            //     and self.move_type == 'out_invoice'
            //     and not pending_transactions
            // )
            */
            return default;
        }

        protected async Task<AccountMove> HashMovesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _hash_moves(self, **kwargs):
            // chains_to_hash = self._get_chains_to_hash(**kwargs)
            // grant_secure_group_access = False
            // for chain in chains_to_hash:
            //     move_hashes = chain['moves']._calculate_hashes(chain['previous_hash'])
            //     for move, move_hash in move_hashes.items():
            //         move.inalterable_hash = move_hash
            //     # If any secured entries belong to journals without 'hash on post', the user should be granted access rights
            //     if not chain['journal_restrict_mode']:
            //         grant_secure_group_access = True
            //     chain['moves']._message_log_batch(bodies={m.id: self.env._("This journal entry has been secured.") for m in chain['moves']})
            // if grant_secure_group_access:
            //     self.env['res.groups']._activate_group_account_secured()
            */
            return default;
        }

        public async Task<AccountMove> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def init(self):
            // super().init()
            // create_index(self.env.cr,
            //              indexname='account_move_journal_id_company_id_idx',
            //              tablename='account_move',
            //              expressions=['journal_id', 'company_id', 'date'])
            // create_index(
            //     self.env.cr,
            //     indexname='account_move_made_gaps',
            //     tablename='account_move',
            //     expressions=['journal_id', 'company_id', 'date'],
            //     where="made_sequence_gap = TRUE",
            // )  # used in <account.journal>._query_has_sequence_holes
            // create_index(
            //     self.env.cr,
            //     indexname='account_move_duplicate_bills_idx',
            //     tablename='account_move',
            //     expressions=['ref'],
            //     where="move_type IN ('in_invoice', 'in_refund')",
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> InverseAmountTotalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _inverse_amount_total(self):
            // for move in self:
            //     if len(move.line_ids) != 2 or move.is_invoice(include_receipts=True):
            //         continue
            // 
            //     to_write = []
            // 
            //     amount_currency = abs(move.amount_total)
            //     balance = move.currency_id._convert(amount_currency, move.company_currency_id, move.company_id, move.invoice_date or move.date)
            // 
            //     for line in move.line_ids:
            //         if not line.currency_id.is_zero(balance - abs(line.balance)):
            //             to_write.append((1, line.id, {
            //                 'debit': line.balance > 0.0 and balance or 0.0,
            //                 'credit': line.balance < 0.0 and balance or 0.0,
            //                 'amount_currency': line.balance > 0.0 and amount_currency or -amount_currency,
            //             }))
            // 
            //     move.write({'line_ids': to_write})
            */
            return default;
        }

        protected async Task<AccountMove> InverseCompanyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _inverse_company_id(self):
            // for move in self:
            //     # This can't be caught by a python constraint as it is only triggered at save and the compute method that
            //     # needs this data to be set correctly before saving
            //     if not move.company_id:
            //         raise ValidationError(_("We can't leave this document without any company. Please select a company for this document."))
            // self._conditional_add_to_compute('journal_id', lambda m: (
            //     not m.journal_id.filtered_domain(self.env['account.journal']._check_company_domain(m.company_id))
            // ))
            */
            return default;
        }

        protected async Task<AccountMove> InverseCurrencyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _inverse_currency_id(self):
            // (self.line_ids | self.invoice_line_ids)._conditional_add_to_compute('currency_id', lambda l: (
            //     l.move_id.is_invoice(True)
            //     and l.move_id.currency_id != l.currency_id
            // ))
            */
            return default;
        }

        protected async Task<AccountMove> InverseInvoicePaymentTermIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _inverse_invoice_payment_term_id(self):
            // self.line_ids._conditional_add_to_compute('name', lambda l: (
            //     l.display_type == 'payment_term'
            // ))
            */
            return default;
        }

        protected async Task<AccountMove> InverseJournalIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _inverse_journal_id(self):
            // self._conditional_add_to_compute('company_id', lambda m: (
            //     not m.company_id
            //     or m.company_id != m.journal_id.company_id
            // ))
            // self._conditional_add_to_compute('currency_id', lambda m: (
            //     not m.currency_id
            //     or m.journal_id.currency_id and m.currency_id != m.journal_id.currency_id
            // ))
            */
            return default;
        }

        protected async Task<AccountMove> InverseNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _inverse_name(self):
            // self._conditional_add_to_compute('payment_reference', lambda move: (
            //     move.name and move.name != '/'
            // ))
            // self._set_next_made_sequence_gap(False)
            */
            return default;
        }

        protected async Task<AccountMove> InversePartnerIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _inverse_partner_id(self):
            // for invoice in self:
            //     if invoice.is_invoice(True):
            //         for line in invoice.line_ids + invoice.invoice_line_ids:
            //             if line.partner_id != invoice.commercial_partner_id:
            //                 line.partner_id = invoice.commercial_partner_id
            //                 line._inverse_partner_id()
            */
            return default;
        }

        protected async Task<AccountMove> InversePaymentReferenceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _inverse_payment_reference(self):
            // self.line_ids._conditional_add_to_compute('name', lambda line: (
            //     line.display_type == 'payment_term'
            // ))
            */
            return default;
        }

        protected async Task<AccountMove> InverseTaxTotalsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _inverse_tax_totals(self):
            // with self._disable_recursion({'records': self}, 'skip_invoice_sync') as disabled:
            //     if disabled:
            //         return
            // with self._sync_dynamic_line(
            //     existing_key_fname='term_key',
            //     needed_vals_fname='needed_terms',
            //     needed_dirty_fname='needed_terms_dirty',
            //     line_type='payment_term',
            //     container={'records': self},
            // ):
            //     for move in self:
            //         if not move.is_invoice(include_receipts=True):
            //             continue
            //         invoice_totals = move.tax_totals
            // 
            //         for subtotal in invoice_totals['subtotals']:
            //             for tax_group in subtotal['tax_groups']:
            //                 tax_lines = move.line_ids.filtered(lambda line: line.tax_group_id.id == tax_group['id'])
            // 
            //                 if tax_lines:
            //                     first_tax_line = tax_lines[0]
            //                     tax_group_old_amount = sum(tax_lines.mapped('amount_currency'))
            //                     sign = -1 if move.is_inbound() else 1
            //                     delta_amount = tax_group_old_amount * sign - tax_group['tax_amount_currency']
            // 
            //                     if not move.currency_id.is_zero(delta_amount):
            //                         first_tax_line.amount_currency -= delta_amount * sign
            //     self._compute_amount()
            */
            return default;
        }

        public async Task<AccountMove> InvoiceDownloadPdfAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_invoice_download_pdf(self):
            // return {
            //     'type': 'ir.actions.act_url',
            //     'url': f'/account/download_invoice_documents/{",".join(map(str, self.ids))}/pdf',
            //     'target': 'download',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> InvoiceDownloadUblAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py) ---
            // def action_invoice_download_ubl(self):
            // if invoices_with_ubl := self.filtered('ubl_cii_xml_id'):
            //     return {
            //         'type': 'ir.actions.act_url',
            //         'url': f'/account/download_invoice_documents/{",".join(map(str, invoices_with_ubl.ids))}/ubl',
            //         'target': 'download',
            //     }
            // return False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> InvoicePaidHookInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _invoice_paid_hook(self):
            // ''' Hook to be overrided called when the invoice moves to the paid state. '''
            --- ODOO METHOD SOURCE (MODULE: event_booth_sale, FILE: account_move.py) ---
            // def _invoice_paid_hook(self):
            // """ When an invoice linked to a sales order selling registrations is
            // paid, update booths accordingly as they are booked when invoice is paid.
            // """
            // res = super(AccountMove, self)._invoice_paid_hook()
            // self.mapped('line_ids.sale_line_ids')._update_event_booths(set_paid=True)
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move.py) ---
            // def _invoice_paid_hook(self):
            // # OVERRIDE
            // res = super(AccountMove, self)._invoice_paid_hook()
            // todo = set()
            // for invoice in self.filtered(lambda move: move.is_invoice()):
            //     for line in invoice.invoice_line_ids:
            //         for sale_line in line.sale_line_ids:
            //             todo.add((sale_line.order_id, invoice.name))
            // for (order, name) in todo:
            //     order.message_post(body=_("Invoice %s paid", name))
            // return res
            */
            return default;
        }

        public async Task<AccountMove> InvoiceSentAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_invoice_sent(self):
            // """ Open a window to compose an email, with the edi invoice template
            //     message loaded by default
            // """
            // self.ensure_one()
            // 
            // report_action = self.action_send_and_print()
            // if self.env.is_admin() and not self.env.company.external_report_layout_id and not self.env.context.get('discard_logo_check'):
            //     report_action = self.env['ir.actions.report']._action_configure_external_report_layout(report_action, "account.action_base_document_layout_configurator")
            //     report_action['context']['default_from_invoice'] = self.move_type == 'out_invoice'
            // 
            // return report_action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> InvoiceValidateSendEmailAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product_email_template, FILE: account_move.py) ---
            // def invoice_validate_send_email(self):
            // if self.env.su:
            //     # sending mail in sudo was meant for it being sent from superuser
            //     self = self.with_user(SUPERUSER_ID)
            // for invoice in self.filtered(lambda x: x.move_type == 'out_invoice'):
            //     # send template only on customer invoice
            //     # subscribe the partner to the invoice
            //     if invoice.partner_id not in invoice.message_partner_ids:
            //         invoice.message_subscribe([invoice.partner_id.id])
            //     comment_subtype_id = self.env['ir.model.data']._xmlid_to_res_id('mail.mt_comment')
            //     for line in invoice.invoice_line_ids:
            //         if line.product_id.email_template_id:
            //             invoice.message_post_with_source(
            //                 line.product_id.email_template_id,
            //                 email_layout_xmlid="mail.mail_notification_light",
            //                 subtype_id=comment_subtype_id,
            //             )
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> IsDownpaymentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _is_downpayment(self):
            // ''' Return true if the invoice is a downpayment.
            // Down-payments can be created from a sale order. This method is overridden in the sale order module.
            // '''
            // return False
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move.py) ---
            // def _is_downpayment(self):
            // # OVERRIDE
            // self.ensure_one()
            // return self.line_ids.sale_line_ids and all(sale_line.is_downpayment for sale_line in self.line_ids.sale_line_ids) or False
            */
            return default;
        }

        protected async Task<AccountMove> IsEligibleForEarlyPaymentDiscountInternalAsync(object currency, object reference_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _is_eligible_for_early_payment_discount(self, currency, reference_date):
            // self.ensure_one()
            // payment_terms = self.line_ids.filtered(lambda line: line.display_type == 'payment_term')
            // return self.currency_id == currency \
            //     and self.move_type in ('out_invoice', 'out_receipt', 'in_invoice', 'in_receipt') \
            //     and self.invoice_payment_term_id.early_discount \
            //     and (
            //         not reference_date
            //         or not self.invoice_date
            //         or reference_date <= self.invoice_payment_term_id._get_last_discount_date(self.invoice_date)
            //     ) \
            //     and not (payment_terms.sudo().matched_debit_ids + payment_terms.sudo().matched_credit_ids)
            */
            return default;
        }

        public async Task<AccountMove> IsEntryAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_entry(self):
            // return self.move_type == 'entry'
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> IsInboundAsync(Guid id, AccountMoveIsInboundRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_inbound(self, include_receipts=True):
            // return self.move_type in self.get_inbound_types(include_receipts)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> IsInvoiceAsync(Guid id, AccountMoveIsInvoiceRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_invoice(self, include_receipts=False):
            // return self.is_sale_document(include_receipts) or self.is_purchase_document(include_receipts)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> IsMoveRestrictedInternalAsync(object move, object force_hash)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _is_move_restricted(self, move, force_hash=False):
            // """
            // Returns whether a move should be hashed (depending on journal settings)
            // :param move: the account.move we check
            // :param force_hash: if True, we'll check all moves posted, independently of journal settings
            // """
            // return move.filtered_domain(self._get_move_hash_domain(force_hash=force_hash))
            */
            return default;
        }

        public async Task<AccountMove> IsOutboundAsync(Guid id, AccountMoveIsOutboundRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_outbound(self, include_receipts=True):
            // return self.move_type in self.get_outbound_types(include_receipts)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> IsProtectedByAuditTrailInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _is_protected_by_audit_trail(self):
            // return any(move.posted_before and move.company_id.check_account_audit_trail for move in self)
            */
            return default;
        }

        public async Task<AccountMove> IsPurchaseDocumentAsync(Guid id, AccountMoveIsPurchaseDocumentRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_purchase_document(self, include_receipts=False):
            // return self.move_type in self.get_purchase_types(include_receipts)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> IsReadonlyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _is_readonly(self):
            // """
            //     Check if the move has been canceled
            // """
            // self.ensure_one()
            // return self.state == 'cancel'
            */
            return default;
        }

        protected async Task<AccountMove> IsReadyToBeSentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _is_ready_to_be_sent(self):
            // """ Helper telling if a journal entry is ready to be sent by mail to the customer.
            // 
            // :return: True if the invoice is ready, False otherwise.
            // """
            // self.ensure_one()
            // return True
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _is_ready_to_be_sent(self):
            // # OVERRIDE
            // # Prevent a mail to be sent to the customer if the EDI document is not sent.
            // res = super()._is_ready_to_be_sent()
            // 
            // if not res:
            //     return False
            // 
            // edi_documents_to_send = self.edi_document_ids.filtered(lambda x: x.state == 'to_send')
            // return not bool(edi_documents_to_send)
            */
            return default;
        }

        public async Task<AccountMove> IsSaleDocumentAsync(Guid id, AccountMoveIsSaleDocumentRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_sale_document(self, include_receipts=False):
            // return self.move_type in self.get_sale_types(include_receipts)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> JsAssignOutstandingLineAsync(Guid id, AccountMoveJsAssignOutstandingLineRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def js_assign_outstanding_line(self, line_id):
            // ''' Called by the 'payment' widget to reconcile a suggested journal item to the present
            // invoice.
            // 
            // :param line_id: The id of the line to reconcile with the current invoice.
            // '''
            // self.ensure_one()
            // lines = self.env['account.move.line'].browse(line_id)
            // lines += self.line_ids.filtered(lambda line: line.account_id == lines[0].account_id and not line.reconciled)
            // return lines.reconcile()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> JsRemoveOutstandingPartialAsync(Guid id, AccountMoveJsRemoveOutstandingPartialRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def js_remove_outstanding_partial(self, partial_id):
            // ''' Called by the 'payment' widget to remove a reconciled entry to the present invoice.
            // 
            // :param partial_id: The id of an existing partial reconciled with the current invoice.
            // '''
            // self.ensure_one()
            // partial = self.env['account.partial.reconcile'].browse(partial_id)
            // return partial.unlink()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> LinkBillOriginToPurchaseOrdersInternalAsync(object timeout)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _link_bill_origin_to_purchase_orders(self, timeout=10):
            // for move in self.filtered(lambda m: m.move_type in self.get_purchase_types()):
            //     references = [move.invoice_origin] if move.invoice_origin else []
            //     move._find_and_set_purchase_orders(references, move.partner_id.id, move.amount_total, timeout=timeout)
            // return self
            */
            return default;
        }

        protected async Task<AccountMove> LinkTimesheetsToInvoiceInternalAsync(object start_date, object end_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: account_move.py) ---
            // def _link_timesheets_to_invoice(self, start_date=None, end_date=None):
            // """ Search timesheets from given period and link this timesheets to the invoice
            // 
            //     When we create an invoice from a sale order, we need to
            //     link the timesheets in this sale order to the invoice.
            //     Then, we can know which timesheets are invoiced in the sale order.
            //     :param start_date: the start date of the period
            //     :param end_date: the end date of the period
            // """
            // for line in self.filtered(lambda i: i.move_type == 'out_invoice' and i.state == 'draft').invoice_line_ids:
            //     sale_line_delivery = line.sale_line_ids.filtered(lambda sol: sol.product_id.invoice_policy == 'delivery' and sol.product_id.service_type == 'timesheet')
            //     if not start_date and not end_date:
            //         start_date, end_date = self._get_range_dates(sale_line_delivery.order_id)
            //     if sale_line_delivery:
            //         domain = line._timesheet_domain_get_invoiced_lines(sale_line_delivery)
            //         if start_date:
            //             domain = expression.AND([domain, [('date', '>=', start_date)]])
            //         if end_date:
            //             domain = expression.AND([domain, [('date', '<=', end_date)]])
            //         timesheets = self.env['account.analytic.line'].sudo().search(domain)
            //         timesheets.write({'timesheet_invoice_id': line.move_id.id})
            */
            return default;
        }

        protected async Task<AccountMove> MailingGetDefaultDomainInternalAsync(object mailing)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _mailing_get_default_domain(self, mailing):
            // return ['&', ('move_type', '=', 'out_invoice'), ('state', '=', 'posted')]
            */
            return default;
        }

        protected async Task<AccountMove> MatchPurchaseOrdersInternalAsync(object po_references, Guid partner_id, object amount_total, object from_ocr, object timeout)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def _match_purchase_orders(self, po_references, partner_id, amount_total, from_ocr, timeout):
            // """Tries to match open purchase order lines with this invoice given the information we have.
            // 
            // :param po_references: a list of potential purchase order references/names
            // :param partner_id: the vendor id inferred from the vendor bill
            // :param amount_total: the total amount of the vendor bill
            // :param from_ocr: indicates whether this vendor bill was created from an OCR scan (less reliable)
            // :param timeout: the max time the line matching algorithm can take before timing out
            // :return: tuple (str, recordset, dict) containing:
            //     * the match method:
            //         * `total_match`: purchase order reference(s) and total amounts match perfectly
            //         * `subset_total_match`: a subset of the referenced purchase orders' lines matches the total amount of
            //             this invoice (OCR only)
            //         * `po_match`: only the purchase order reference matches (OCR only)
            //         * `subset_match`: a subset of the referenced purchase orders' lines matches a subset of the invoice
            //             lines based on unit prices (EDI only)
            //         * `no_match`: no result found
            //     * recordset of `purchase.order.line` containing purchase order lines matched with an invoice line
            //     * list of tuple containing every `purchase.order.line` id and its related `account.move.line`
            // """
            // 
            // common_domain = [
            //     ('company_id', '=', self.company_id.id),
            //     ('state', 'in', ('purchase', 'done')),
            //     ('invoice_status', 'in', ('to invoice', 'no'))
            // ]
            // 
            // matching_purchase_orders = self.env['purchase.order']
            // 
            // # We have purchase order references in our vendor bill and a total amount.
            // if po_references and amount_total:
            //     # We first try looking for purchase orders whose names match one of the purchase order references in the
            //     # vendor bill.
            //     matching_purchase_orders |= self.env['purchase.order'].search(
            //         common_domain + [('name', 'in', po_references)])
            // 
            //     if not matching_purchase_orders:
            //         # If not found, we try looking for purchase orders whose `partner_ref` field matches one of the
            //         # purchase order references in the vendor bill.
            //         matching_purchase_orders |= self.env['purchase.order'].search(
            //             common_domain + [('partner_ref', 'in', po_references)])
            // 
            //     if matching_purchase_orders:
            //         # We found matching purchase orders and are extracting all purchase order lines together with their
            //         # amounts still to be invoiced.
            //         po_lines = [line for line in matching_purchase_orders.order_line if line.product_qty]
            //         po_lines_with_amount = [{
            //             'line': line,
            //             'amount_to_invoice': (1 - line.qty_invoiced / line.product_qty) * line.price_total,
            //         } for line in po_lines]
            // 
            //         # If the sum of all remaining amounts to be invoiced for these purchase orders' lines is within a
            //         # tolerance from the vendor bill total, we have a total match. We return all purchase order lines
            //         # summing up to this vendor bill's total (could be from multiple purchase orders).
            //         if (amount_total - TOLERANCE
            //                 < sum(line['amount_to_invoice'] for line in po_lines_with_amount)
            //                 < amount_total + TOLERANCE):
            //             return 'total_match', matching_purchase_orders.order_line, None
            // 
            //         elif from_ocr:
            //             # The invoice comes from an OCR scan.
            //             # We try to match the invoice total with purchase order lines.
            //             matching_po_lines = self._find_matching_subset_po_lines(
            //                 po_lines_with_amount, amount_total, timeout)
            //             if matching_po_lines:
            //                 return 'subset_total_match', self.env['purchase.order.line'].union(*matching_po_lines), None
            //             else:
            //                 # We did not find a match for the invoice total.
            //                 # We return all purchase order lines based only on the purchase order reference(s) in the
            //                 # vendor bill.
            //                 return 'po_match', matching_purchase_orders.order_line, None
            // 
            //         else:
            //             # We have an invoice from an EDI document, so we try to match individual invoice lines with
            //             # individual purchase order lines from referenced purchase orders.
            //             matching_po_lines, matching_inv_lines = self._find_matching_po_and_inv_lines(
            //                 po_lines, self.invoice_line_ids, timeout)
            // 
            //             if matching_po_lines:
            //                 # We found a subset of purchase order lines that match a subset of the vendor bill lines.
            //                 # We return the matching purchase order lines and vendor bill lines.
            //                 return ('subset_match',
            //                         self.env['purchase.order.line'].union(*matching_po_lines),
            //                         matching_inv_lines)
            // 
            // # As a last resort we try matching a purchase order by vendor and total amount.
            // if partner_id and amount_total:
            //     purchase_id_domain = common_domain + [
            //         ('partner_id', 'child_of', [partner_id]),
            //         ('amount_total', '>=', amount_total - TOLERANCE),
            //         ('amount_total', '<=', amount_total + TOLERANCE)
            //     ]
            //     matching_purchase_orders = self.env['purchase.order'].search(purchase_id_domain)
            //     if len(matching_purchase_orders) == 1:
            //         # We found exactly one match on vendor and total amount (within tolerance).
            //         # We return all purchase order lines of the purchase order whose total amount matched our vendor bill.
            //         return 'total_match', matching_purchase_orders.order_line, None
            // 
            // # We couldn't find anything, so we return no lines.
            // return ('no_match', matching_purchase_orders.order_line, None)
            */
            return default;
        }

        public async Task<AccountMove> MessageNewAsync(Guid id, AccountMoveMessageNewRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def message_new(self, msg_dict, custom_values=None):
            // # EXTENDS mail mail.thread
            // # Add custom behavior when receiving a new invoice through the mail's gateway.
            // if (custom_values or {}).get('move_type', 'entry') not in ('out_invoice', 'in_invoice', 'entry'):
            //     return super().message_new(msg_dict, custom_values=custom_values)
            // 
            // self = self.with_context(skip_is_manually_modified=True)  # noqa: PLW0642
            // 
            // company = self.env['res.company'].browse(custom_values['company_id']) if custom_values.get('company_id') else self.env.company
            // 
            // def is_internal_partner(partner):
            //     # Helper to know if the partner is an internal one.
            //     return (
            //             company.partner_id in (partner | partner.parent_id)
            //             or (partner.user_ids and all(user._is_internal() for user in partner.user_ids))
            //     )
            // 
            // extra_domain = False
            // if custom_values.get('company_id'):
            //     extra_domain = ['|', ('company_id', '=', custom_values['company_id']), ('company_id', '=', False)]
            // 
            // # Search for partners in copy.
            // cc_mail_addresses = email_split(msg_dict.get('cc', ''))
            // followers = [partner for partner in self._mail_find_partner_from_emails(cc_mail_addresses, extra_domain=extra_domain) if partner]
            // 
            // # Search for partner that sent the mail.
            // from_mail_addresses = email_split(msg_dict.get('from', ''))
            // senders = partners = [partner for partner in self._mail_find_partner_from_emails(from_mail_addresses, extra_domain=extra_domain) if partner]
            // 
            // # Search for partners using the user.
            // if not senders:
            //     senders = partners = list(self._mail_search_on_user(from_mail_addresses))
            // 
            // if partners:
            //     # Check we are not in the case when an internal user forwarded the mail manually.
            //     if is_internal_partner(partners[0]):
            //         # Search for partners in the mail's body.
            //         body_mail_addresses = set(email_re.findall(msg_dict.get('body')))
            //         partners = [
            //             partner
            //             for partner in self._mail_find_partner_from_emails(body_mail_addresses, extra_domain=extra_domain)
            //             if not is_internal_partner(partner) and partner.company_id.id in (False, company.id)
            //         ]
            // # Little hack: Inject the mail's subject in the body.
            // if msg_dict.get('subject') and msg_dict.get('body'):
            //     msg_dict['body'] = Markup('<div><div><h3>%s</h3></div>%s</div>') % (msg_dict['subject'], msg_dict['body'])
            // 
            // # Create the invoice.
            // values = {
            //     'name': '/',  # we have to give the name otherwise it will be set to the mail's subject
            //     'invoice_source_email': from_mail_addresses[0],
            //     'partner_id': partners and partners[0].id or False,
            // }
            // move_ctx = self.with_context(default_move_type=custom_values['move_type'], default_journal_id=custom_values['journal_id'])
            // move = super(AccountMove, move_ctx).message_new(msg_dict, custom_values=values)
            // move._compute_name()  # because the name is given, we need to recompute in case it is the first invoice of the journal
            // 
            // # Assign followers.
            // all_followers_ids = set(partner.id for partner in followers + senders + partners if is_internal_partner(partner))
            // move.message_subscribe(list(all_followers_ids))
            // return move
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> MessagePostAfterHookInternalAsync(object new_message, object message_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _message_post_after_hook(self, new_message, message_values):
            // # EXTENDS mail mail.thread
            // # When posting a message, check the attachment to see if it's an invoice and update with the imported data.
            // res = super()._message_post_after_hook(new_message, message_values)
            // if not self.env.user._is_internal():
            //     return res
            // 
            // attachments = new_message.attachment_ids
            // attachments_per_invoice = defaultdict(lambda: self.env['ir.attachment'])
            // 
            // checked_attachment = self._check_and_decode_attachment(attachments)
            // if not checked_attachment:
            //     return res
            // 
            // for attachment_in_res, invoices in checked_attachment.items():
            //     invoices = invoices or self
            //     for invoice in invoices:
            //         attachments_per_invoice[invoice] |= attachment_in_res
            // 
            // for invoice, attachments in attachments_per_invoice.items():
            //     if invoice == self:
            //         invoice.attachment_ids |= attachments
            //         new_message.attachment_ids = attachments.ids
            //         message_values.update({'res_id': self.id, 'attachment_ids': [Command.link(attachment.id) for attachment in attachments]})
            //         super(AccountMove, invoice)._message_post_after_hook(new_message, message_values)
            //     else:
            //         sub_new_message = new_message.copy({'attachment_ids': attachments.ids})
            //         sub_message_values = {
            //             **message_values,
            //             'res_id': invoice.id,
            //             'attachment_ids': [Command.link(attachment.id) for attachment in attachments],
            //         }
            //         invoice.attachment_ids |= attachments
            //         invoice.message_ids = [Command.set(sub_new_message.id)]
            //         super(AccountMove, invoice)._message_post_after_hook(sub_new_message, sub_message_values)
            // 
            // return res
            */
            return default;
        }

        protected async Task<AccountMove> MessageSetMainAttachmentIdInternalAsync(object attachments, object force, object filter_xml)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _message_set_main_attachment_id(self, attachments, force=False, filter_xml=True):
            // if not force and len(attachments) > 1 and self.message_main_attachment_id in self.edi_document_ids.attachment_id:
            //     force = True
            // super()._message_set_main_attachment_id(attachments, force=force, filter_xml=filter_xml)
            */
            return default;
        }

        protected async Task<AccountMove> MoveDictToPreviewValsInternalAsync(object move_vals, Guid currency_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _move_dict_to_preview_vals(self, move_vals, currency_id=None):
            // preview_vals = {
            //     'group_name': "%s, %s" % (format_date(self.env, move_vals['date']) or _('[Not set]'), move_vals['ref']),
            //     'items_vals': move_vals['line_ids'],
            // }
            // for line in preview_vals['items_vals']:
            //     if 'partner_id' in line[2]:
            //         # sudo is needed to compute display_name in a multi companies environment
            //         line[2]['partner_id'] = self.env['res.partner'].browse(line[2]['partner_id']).sudo().display_name
            //     line[2]['account_id'] = self.env['account.account'].browse(line[2]['account_id']).display_name or _('Destination Account')
            //     line[2]['debit'] = currency_id and formatLang(self.env, line[2]['debit'], currency_obj=currency_id) or line[2]['debit']
            //     line[2]['credit'] = currency_id and formatLang(self.env, line[2]['credit'], currency_obj=currency_id) or line[2]['debit']
            // return preview_vals
            */
            return default;
        }

        protected async Task<AccountMove> MustCheckConstrainsDateSequenceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _must_check_constrains_date_sequence(self):
            // # OVERRIDES sequence.mixin
            // return self.state == 'posted' and not self.quick_edit_mode
            */
            return default;
        }

        protected async Task<AccountMove> MustDeleteAllExpenseEntriesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: account_move.py) ---
            // def _must_delete_all_expense_entries(self):
            // if self.expense_sheet_id and self.expense_sheet_id.account_move_ids - self:  # If not all the payments are to be deleted
            //     raise UserError(_("You cannot delete only some entries linked to an expense report. All entries must be deleted at the same time."))
            */
            return default;
        }

        protected async Task<AccountMove> NeedCancelRequestInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _need_cancel_request(self):
            // """ Hook allowing a localization to prevent the user to reset draft an invoice that has been already sent
            // to the government and thus, must remain untouched except if its cancellation is approved.
            // 
            // :return: True if the cancel button is displayed instead of draft button, False otherwise.
            // """
            // self.ensure_one()
            // return False
            */
            return default;
        }

        protected async Task<AccountMove> NeedUblCiiXmlInternalAsync(object ubl_cii_format)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py) ---
            // def _need_ubl_cii_xml(self, ubl_cii_format):
            // self.ensure_one()
            // return not self.ubl_cii_xml_id \
            //     and self.is_sale_document() \
            //     and ubl_cii_format in self.env['res.partner']._get_ubl_cii_formats()
            */
            return default;
        }

        protected async Task<AccountMove> NotifyByEmailPrepareRenderingContextInternalAsync(object message, object msg_vals, object model_description, object force_email_company, object force_email_lang)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _notify_by_email_prepare_rendering_context(self, message, msg_vals=False, model_description=False,
            //                                            force_email_company=False, force_email_lang=False):
            // # EXTENDS mail mail.thread
            // render_context = super()._notify_by_email_prepare_rendering_context(
            //     message, msg_vals, model_description=model_description,
            //     force_email_company=force_email_company, force_email_lang=force_email_lang
            // )
            // record = render_context['record']
            // subtitles = [f"{record.name} - {record.partner_id.name}" if record.partner_id else record.name]
            // if self.is_invoice(include_receipts=True):
            //     # Only show the amount in emails for non-miscellaneous moves. It might confuse recipients otherwise.
            //     if self.invoice_date_due and self.payment_state not in ('in_payment', 'paid'):
            //         subtitles.append(_(
            //             '%(amount)s due\N{NO-BREAK SPACE}%(date)s',
            //             amount=format_amount(self.env, self.amount_total, self.currency_id, lang_code=render_context.get('lang')),
            //             date=format_date(self.env, self.invoice_date_due, lang_code=render_context.get('lang')),
            //         ))
            //     else:
            //         subtitles.append(format_amount(self.env, self.amount_total, self.currency_id, lang_code=render_context.get('lang')))
            // render_context['subtitles'] = subtitles
            // return render_context
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: account_move.py) ---
            // def _notify_by_email_prepare_rendering_context(self, message, msg_vals=False, model_description=False,
            //                                            force_email_company=False, force_email_lang=False):
            // render_context = super()._notify_by_email_prepare_rendering_context(
            //     message, msg_vals=msg_vals, model_description=model_description,
            //     force_email_company=force_email_company, force_email_lang=force_email_lang
            // )
            // invoice = render_context['record']
            // invoice_country = invoice.commercial_partner_id.country_code
            // company_country = invoice.company_id.country_code
            // can_send = self.env['account_edi_proxy_client.user']._get_can_send_domain()
            // company_on_peppol = invoice.company_id.account_peppol_proxy_state in can_send
            // if company_on_peppol and company_country in PEPPOL_MAILING_COUNTRIES and invoice_country in PEPPOL_MAILING_COUNTRIES:
            //     render_context['peppol_info'] = {
            //         'peppol_country': invoice_country,
            //         'is_peppol_sent': invoice.peppol_move_state in ('processing', 'done'),
            //         'partner_on_peppol': invoice.commercial_partner_id.peppol_verification_state in ('valid', 'not_valid_format'),
            //     }
            // return render_context
            */
            return default;
        }

        protected async Task<AccountMove> NotifyGetRecipientsGroupsInternalAsync(object message, object model_description, object msg_vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=None):
            // groups = super()._notify_get_recipients_groups(message, model_description, msg_vals=msg_vals)
            // self.ensure_one()
            // 
            // if self.move_type != 'entry':
            //     local_msg_vals = dict(msg_vals or {})
            //     partner_ids = local_msg_vals.get('partner_ids', []) if 'partner_ids' in local_msg_vals else message.partner_ids.ids
            //     self._portal_ensure_token()
            //     access_link = self._notify_get_action_link('view', **local_msg_vals, access_token=self.access_token)
            // 
            //     # Create a new group for partners that have been manually added as recipients.
            //     # Those partners should have access to the invoice.
            //     button_access = {'url': access_link} if access_link else {}
            //     recipient_group = (
            //         'additional_intended_recipient',
            //         lambda pdata: pdata['id'] in partner_ids and pdata['id'] != self.partner_id.id and pdata['type'] != 'user',
            //         {
            //             'has_button_access': True,
            //             'button_access': button_access,
            //         }
            //     )
            //     groups.insert(0, recipient_group)
            // 
            // return groups
            */
            return default;
        }

        protected async Task<AccountMove> OnchangeDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _onchange_date(self):
            // if not self.is_invoice(True):
            //     self.line_ids._inverse_amount_currency()
            */
            return default;
        }

        protected async Task<AccountMove> OnchangeFposIdShowUpdateFposInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _onchange_fpos_id_show_update_fpos(self):
            // self.show_update_fpos = self.line_ids and self._origin.fiscal_position_id != self.fiscal_position_id
            */
            return default;
        }

        protected async Task<AccountMove> OnchangeInvoiceCashRoundingIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _onchange_invoice_cash_rounding_id(self):
            // for move in self:
            //     if move.invoice_cash_rounding_id.strategy == 'add_invoice_line' and not move.invoice_cash_rounding_id.profit_account_id:
            //         return {'warning': {
            //             'title': _("Warning for Cash Rounding Method: %s", move.invoice_cash_rounding_id.name),
            //             'message': _("You must specify the Profit Account (company dependent)")
            //         }}
            */
            return default;
        }

        protected async Task<AccountMove> OnchangeInvoiceVendorBillInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _onchange_invoice_vendor_bill(self):
            // if self.invoice_vendor_bill_id:
            //     # Copy invoice lines.
            //     for line in self.invoice_vendor_bill_id.invoice_line_ids:
            //         copied_vals = line.copy_data()[0]
            //         self.invoice_line_ids += self.env['account.move.line'].new(copied_vals)
            // 
            //     self.currency_id = self.invoice_vendor_bill_id.currency_id
            //     self.fiscal_position_id = self.invoice_vendor_bill_id.fiscal_position_id
            // 
            //     # Reset
            //     self.invoice_vendor_bill_id = False
            */
            return default;
        }

        protected async Task<AccountMove> OnchangeJournalIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _onchange_journal_id(self):
            // if not self.quick_edit_mode:
            //     self.name = False
            //     self._compute_name()
            */
            return default;
        }

        protected async Task<AccountMove> OnchangeNameWarningInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _onchange_name_warning(self):
            // if self.name and self.name != '/' and self.name <= (self.highest_name or '') and not self.quick_edit_mode:
            //     self.show_name_warning = True
            // else:
            //     self.show_name_warning = False
            // 
            // origin_name = self._origin.name
            // if not origin_name or origin_name == '/':
            //     origin_name = self.highest_name
            // if (
            //     self.name and self.name != '/'
            //     and origin_name and origin_name != '/'
            //     and self.date == self._origin.date
            //     and self.journal_id == self._origin.journal_id
            // ):
            //     new_format, new_format_values = self._get_sequence_format_param(self.name)
            //     origin_format, origin_format_values = self._get_sequence_format_param(origin_name)
            // 
            //     if (
            //         new_format != origin_format
            //         or dict(new_format_values, year=0, month=0, seq=0) != dict(origin_format_values, year=0, month=0, seq=0)
            //     ):
            //         changed = _(
            //             "It was previously '%(previous)s' and it is now '%(current)s'.",
            //             previous=origin_name,
            //             current=self.name,
            //         )
            //         reset = self._deduce_sequence_number_reset(self.name)
            //         if reset == 'month':
            //             detected = _(
            //                 "The sequence will restart at 1 at the start of every month.\n"
            //                 "The year detected here is '%(year)s' and the month is '%(month)s'.\n"
            //                 "The incrementing number in this case is '%(formatted_seq)s'."
            //             )
            //         elif reset == 'year':
            //             detected = _(
            //                 "The sequence will restart at 1 at the start of every year.\n"
            //                 "The year detected here is '%(year)s'.\n"
            //                 "The incrementing number in this case is '%(formatted_seq)s'."
            //             )
            //         elif reset == 'year_range':
            //             detected = _(
            //                 "The sequence will restart at 1 at the start of every financial year.\n"
            //                 "The financial start year detected here is '%(year)s'.\n"
            //                 "The financial end year detected here is '%(year_end)s'.\n"
            //                 "The incrementing number in this case is '%(formatted_seq)s'."
            //             )
            //         elif reset == 'year_range_month':
            //             detected = _(
            //                 "The sequence will restart at 1 at the start of every month.\n"
            //                 "The financial start year detected here is '%(year)s'.\n"
            //                 "The financial end year detected here is '%(year_end)s'.\n"
            //                 "The month detected here is '%(month)s'.\n"
            //                 "The incrementing number in this case is '%(formatted_seq)s'."
            //             )
            //         else:
            //             detected = _(
            //                 "The sequence will never restart.\n"
            //                 "The incrementing number in this case is '%(formatted_seq)s'."
            //             )
            //         new_format_values['formatted_seq'] = "{seq:0{seq_length}d}".format(**new_format_values)
            //         detected = detected % new_format_values
            //         return {'warning': {
            //             'title': _("The sequence format has changed."),
            //             'message': "%s\n\n%s" % (changed, detected)
            //         }}
            */
            return default;
        }

        protected async Task<AccountMove> OnchangePartnerIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _onchange_partner_id(self):
            // self = self.with_company((self.journal_id.company_id or self.env.company)._accessible_branches()[:1])
            // 
            // warning = {}
            // if self.partner_id:
            //     rec_account = self.partner_id.property_account_receivable_id
            //     pay_account = self.partner_id.property_account_payable_id
            //     if not rec_account and not pay_account:
            //         action = self.env.ref('account.action_account_config')
            //         msg = _('Cannot find a chart of accounts for this company, You should configure it. \nPlease go to Account Configuration.')
            //         raise RedirectWarning(msg, action.id, _('Go to the configuration panel'))
            //     p = self.partner_id
            //     if p.invoice_warn == 'no-message' and p.parent_id:
            //         p = p.parent_id
            //     if p.invoice_warn and p.invoice_warn != 'no-message':
            //         # Block if partner only has warning but parent company is blocked
            //         if p.invoice_warn != 'block' and p.parent_id and p.parent_id.invoice_warn == 'block':
            //             p = p.parent_id
            //         warning = {
            //             'title': _("Warning for %s", p.name),
            //             'message': p.invoice_warn_msg
            //         }
            //         if p.invoice_warn == 'block':
            //             self.partner_id = False
            //         return {'warning': warning}
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def _onchange_partner_id(self):
            // res = super(AccountMove, self)._onchange_partner_id()
            // 
            // currency_id = (
            //         self.partner_id.property_purchase_currency_id
            //         or self.env['res.currency'].browse(self.env.context.get("default_currency_id"))
            //         or self.currency_id
            // )
            // 
            // if self.partner_id and self.move_type in ['in_invoice', 'in_refund'] and self.currency_id != currency_id:
            //     if not self.env.context.get('default_journal_id'):
            //         journal_domain = [
            //             *self.env['account.journal']._check_company_domain(self.company_id),
            //             ('type', '=', 'purchase'),
            //             ('currency_id', '=', currency_id.id),
            //         ]
            //         default_journal_id = self.env['account.journal'].search(journal_domain, limit=1)
            //         if default_journal_id:
            //             self.journal_id = default_journal_id
            // 
            //     self.currency_id = currency_id
            // 
            // return res
            */
            return default;
        }

        protected async Task<AccountMove> OnchangePurchaseAutoCompleteInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def _onchange_purchase_auto_complete(self):
            // r''' Load from either an old purchase order, either an old vendor bill.
            // 
            // When setting a 'purchase.bill.union' in 'purchase_vendor_bill_id':
            // * If it's a vendor bill, 'invoice_vendor_bill_id' is set and the loading is done by '_onchange_invoice_vendor_bill'.
            // * If it's a purchase order, 'purchase_id' is set and this method will load lines.
            // 
            // /!\ All this not-stored fields must be empty at the end of this function.
            // '''
            // if self.purchase_vendor_bill_id.vendor_bill_id:
            //     self.invoice_vendor_bill_id = self.purchase_vendor_bill_id.vendor_bill_id
            //     self._onchange_invoice_vendor_bill()
            // elif self.purchase_vendor_bill_id.purchase_order_id:
            //     self.purchase_id = self.purchase_vendor_bill_id.purchase_order_id
            // self.purchase_vendor_bill_id = False
            // 
            // if not self.purchase_id:
            //     return
            // 
            // # Copy data from PO
            // invoice_vals = self.purchase_id.with_company(self.purchase_id.company_id)._prepare_invoice()
            // has_invoice_lines = bool(self.invoice_line_ids.filtered(lambda x: x.display_type not in ('line_note', 'line_section')))
            // new_currency_id = self.currency_id if has_invoice_lines else invoice_vals.get('currency_id')
            // del invoice_vals['ref'], invoice_vals['payment_reference']
            // del invoice_vals['company_id']  # avoid recomputing the currency
            // if self.move_type == invoice_vals['move_type']:
            //     del invoice_vals['move_type'] # no need to be updated if it's same value, to avoid recomputes
            // self.update(invoice_vals)
            // self.currency_id = new_currency_id
            // 
            // # Copy purchase lines.
            // po_lines = self.purchase_id.order_line - self.invoice_line_ids.mapped('purchase_line_id')
            // self._add_purchase_order_lines(po_lines)
            // 
            // # Compute invoice_origin.
            // origins = set(self.invoice_line_ids.mapped('purchase_line_id.order_id.name'))
            // self.invoice_origin = ','.join(list(origins))
            // 
            // # Compute ref.
            // refs = self._get_invoice_reference()
            // self.ref = ', '.join(refs)
            // 
            // # Compute payment_reference.
            // if not self.payment_reference:
            //     if len(refs) == 1:
            //         self.payment_reference = refs[0]
            //     elif len(refs) > 1:
            //         self.payment_reference = refs[-1]
            // 
            // # Copy company_id (only changes if the id is of a child company (branch))
            // if self.company_id != self.purchase_id.company_id:
            //     self.company_id = self.purchase_id.company_id
            // 
            // self.purchase_id = False
            */
            return default;
        }

        protected async Task<AccountMove> OnchangeQuickEditLineIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _onchange_quick_edit_line_ids(self):
            // quick_encode_suggestion = self.env.context.get('quick_encoding_vals')
            // if (
            //     not self.quick_edit_total_amount
            //     or not self.quick_edit_mode
            //     or not self.invoice_line_ids
            //     or not quick_encode_suggestion
            //     or not quick_encode_suggestion['price_unit'] == self.invoice_line_ids[-1].price_unit
            // ):
            //     return
            // self._check_total_amount(self.quick_edit_total_amount)
            */
            return default;
        }

        protected async Task<AccountMove> OnchangeQuickEditTotalAmountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _onchange_quick_edit_total_amount(self):
            // """
            // Creates a new line with the suggested values (for the account, the price_unit,
            // and the tax) such that the total amount matches the quick total amount.
            // """
            // if (
            //     not self.quick_edit_total_amount
            //     or not self.quick_edit_mode
            //     or len(self.invoice_line_ids) > 0
            // ):
            //     return
            // suggestions = self.quick_encoding_vals
            // self.invoice_line_ids = [Command.clear()]
            // self.invoice_line_ids += self.env['account.move.line'].new({
            //     'partner_id': self.partner_id,
            //     'account_id': suggestions['account_id'],
            //     'currency_id': self.currency_id.id,
            //     'price_unit': suggestions['price_unit'],
            //     'tax_ids': [Command.set(suggestions['tax_ids'])],
            // })
            // self._check_total_amount(self.quick_edit_total_amount)
            */
            return default;
        }

        public async Task<AccountMove> OpenBusinessDocAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_open_business_doc(self):
            // self.ensure_one()
            // if self.origin_payment_id:
            //     name = _("Payment")
            //     res_model = 'account.payment'
            //     res_id = self.origin_payment_id.id
            // elif self.statement_line_id:
            //     name = _("Bank Transaction")
            //     res_model = 'account.bank.statement.line'
            //     res_id = self.statement_line_id.id
            // else:
            //     name = _("Journal Entry")
            //     res_model = 'account.move'
            //     res_id = self.id
            // 
            // return {
            //     'name': name,
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'views': [(False, 'form')],
            //     'res_model': res_model,
            //     'res_id': res_id,
            //     'target': 'current',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> OpenCreatedCabaEntriesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def open_created_caba_entries(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _("Cash Basis Entries"),
            //     'res_model': 'account.move',
            //     'view_mode': 'form',
            //     'domain': [('id', 'in', self.tax_cash_basis_created_move_ids.ids)],
            //     'views': [(self.env.ref('account.view_move_tree').id, 'list'), (False, 'form')],
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> OpenExpenseReportAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: account_move.py) ---
            // def action_open_expense_report(self):
            // self.ensure_one()
            // return {
            //     'name': self.expense_sheet_id.name,
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'views': [(False, 'form')],
            //     'res_model': 'hr.expense.sheet',
            //     'res_id': self.expense_sheet_id.id
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> OpenPaymentsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def open_payments(self):
            // return self.matched_payment_ids._get_records_action(name=_("Payments"))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> OpenReconcileViewAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def open_reconcile_view(self):
            // return self.line_ids.open_reconcile_view()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> PaymentCaptureAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: account_move.py) ---
            // def payment_action_capture(self):
            // """ Capture all transactions linked to this invoice. """
            // self.ensure_one()
            // payment_utils.check_rights_on_recordset(self)
            // 
            // # In sudo mode to bypass the checks on the rights on the transactions.
            // return self.transaction_ids.sudo().action_capture()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> PaymentVoidAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: account_move.py) ---
            // def payment_action_void(self):
            // """ Void all transactions linked to this invoice. """
            // payment_utils.check_rights_on_recordset(self)
            // 
            // # In sudo mode to bypass the checks on the rights on the transactions.
            // self.authorized_transaction_ids.sudo().action_void()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> PostAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_post(self):
            // # Disabled by default to avoid breaking automated action flow
            // if (
            //     not self.env.context.get('disable_abnormal_invoice_detection', True)
            //     and self.filtered(lambda m: m.abnormal_amount_warning or m.abnormal_date_warning)
            // ):
            //     wizard = self.env['validate.account.move'].create({
            //         'move_ids': [Command.set(self.ids)],
            //     })
            //     return {
            //         'name': _("Confirm Entries"),
            //         'type': 'ir.actions.act_window',
            //         'res_model': 'validate.account.move',
            //         'res_id': wizard.id,
            //         'view_mode': 'form',
            //         'target': 'new',
            //     }
            // if self:
            //     self._post(soft=False)
            // if autopost_bills_wizard := self._show_autopost_bills_wizard():
            //     return autopost_bills_wizard
            // return False
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move.py) ---
            // def action_post(self):
            // # inherit of the function from account.move to validate a new tax and the priceunit of a downpayment
            // res = super(AccountMove, self).action_post()
            // 
            // # We cannot change lines content on locked SO, changes on invoices are not forwarded to the SO if the SO is locked
            // dp_lines = self.line_ids.sale_line_ids.filtered(lambda l: l.is_downpayment and not l.display_type)
            // dp_lines._compute_name()  # Update the description of DP lines (Draft -> Posted)
            // downpayment_lines = dp_lines.filtered(lambda sol: not sol.order_id.locked)
            // other_so_lines = downpayment_lines.order_id.order_line - downpayment_lines
            // real_invoices = set(other_so_lines.invoice_lines.move_id)
            // for so_dpl in downpayment_lines:
            //     so_dpl.price_unit = so_dpl._get_downpayment_line_price_unit(real_invoices)
            //     so_dpl.tax_id = so_dpl.invoice_lines.tax_ids
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account.py) ---
            // def action_post(self):
            // for move in self:
            //     for depreciation_line in move.asset_depreciation_ids:
            //         depreciation_line.post_lines_and_close_asset()
            // return super(AccountMove, self).action_post()
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_move.py) ---
            // def action_post(self):
            // result = super(AccountMove, self).action_post()
            // for inv in self:
            //     context = dict(self.env.context)
            //     context.pop('default_type', None)
            //     for mv_line in inv.invoice_line_ids:
            //         mv_line.with_context(context).asset_create()
            // return result
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> PostInternalAsync(object soft)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _post(self, soft=True):
            // """Post/Validate the documents.
            // 
            // Posting the documents will give it a number, and check that the document is
            // complete (some fields might not be required if not posted but are required
            // otherwise).
            // If the journal is locked with a hash table, it will be impossible to change
            // some fields afterwards.
            // 
            // :param soft (bool): if True, future documents are not immediately posted,
            //     but are set to be auto posted automatically at the set accounting date.
            //     Nothing will be performed on those documents before the accounting date.
            // :return Model<account.move>: the documents that have been posted
            // """
            // if not self.env.su and not self.env.user.has_group('account.group_account_invoice'):
            //     raise AccessError(_("You don't have the access rights to post an invoice."))
            // 
            // # Avoid marking is_manually_modified as True when posting an invoice
            // self = self.with_context(skip_is_manually_modified=True)  # noqa: PLW0642
            // 
            // validation_msgs = set()
            // 
            // for invoice in self.filtered(lambda move: move.is_invoice(include_receipts=True)):
            //     if (
            //         invoice.quick_edit_mode
            //         and invoice.quick_edit_total_amount
            //         and invoice.currency_id.compare_amounts(invoice.quick_edit_total_amount, invoice.amount_total) != 0
            //     ):
            //         validation_msgs.add(_(
            //             "The current total is %(current_total)s but the expected total is %(expected_total)s. In order to post the invoice/bill, "
            //             "you can adjust its lines or the expected Total (tax inc.).",
            //             current_total=formatLang(self.env, invoice.amount_total, currency_obj=invoice.currency_id),
            //             expected_total=formatLang(self.env, invoice.quick_edit_total_amount, currency_obj=invoice.currency_id),
            //         ))
            //     if invoice.partner_bank_id and not invoice.partner_bank_id.active:
            //         validation_msgs.add(_(
            //             "The recipient bank account linked to this invoice is archived.\n"
            //             "So you cannot confirm the invoice."
            //         ))
            //     if float_compare(invoice.amount_total, 0.0, precision_rounding=invoice.currency_id.rounding) < 0:
            //         validation_msgs.add(_(
            //             "You cannot validate an invoice with a negative total amount. "
            //             "You should create a credit note instead. "
            //             "Use the action menu to transform it into a credit note or refund."
            //         ))
            // 
            //     if not invoice.partner_id:
            //         if invoice.is_sale_document():
            //             validation_msgs.add(_("The field 'Customer' is required, please complete it to validate the Customer Invoice."))
            //         elif invoice.is_purchase_document():
            //             validation_msgs.add(_("The field 'Vendor' is required, please complete it to validate the Vendor Bill."))
            // 
            //     # Handle case when the invoice_date is not set. In that case, the invoice_date is set at today and then,
            //     # lines are recomputed accordingly.
            //     if not invoice.invoice_date:
            //         if invoice.is_sale_document(include_receipts=True):
            //             invoice.invoice_date = fields.Date.context_today(self)
            //         elif invoice.is_purchase_document(include_receipts=True):
            //             validation_msgs.add(_("The Bill/Refund date is required to validate this document."))
            // 
            // for move in self:
            //     if move.state in ['posted', 'cancel']:
            //         validation_msgs.add(_('The entry %(name)s (id %(id)s) must be in draft.', name=move.name, id=move.id))
            //     if not move.line_ids.filtered(lambda line: line.display_type not in ('line_section', 'line_note')):
            //         validation_msgs.add(_('You need to add a line before posting.'))
            //     if not soft and move.auto_post != 'no' and move.date > fields.Date.context_today(self):
            //         date_msg = move.date.strftime(get_lang(self.env).date_format)
            //         validation_msgs.add(_("This move is configured to be auto-posted on %(date)s", date=date_msg))
            //     if not move.journal_id.active:
            //         validation_msgs.add(_(
            //             "You cannot post an entry in an archived journal (%(journal)s)",
            //             journal=move.journal_id.display_name,
            //         ))
            //     if move.display_inactive_currency_warning:
            //         validation_msgs.add(_(
            //             "You cannot validate a document with an inactive currency: %s",
            //             move.currency_id.name
            //         ))
            // 
            //     if move.line_ids.account_id.filtered(lambda account: account.deprecated) and not self._context.get('skip_account_deprecation_check'):
            //         validation_msgs.add(_("A line of this move is using a deprecated account, you cannot post it."))
            // 
            //     # If the field autocheck_on_post is set, we want the checked field on the move to be checked
            //     if move.journal_id.autocheck_on_post:
            //         move.checked = move.journal_id.autocheck_on_post
            // 
            // if validation_msgs:
            //     msg = "\n".join([line for line in validation_msgs])
            //     raise UserError(msg)
            // 
            // if soft:
            //     future_moves = self.filtered(lambda move: move.date > fields.Date.context_today(self))
            //     for move in future_moves:
            //         if move.auto_post == 'no':
            //             move.auto_post = 'at_date'
            //         msg = _('This move will be posted at the accounting date: %(date)s', date=format_date(self.env, move.date))
            //         move.message_post(body=msg)
            //     to_post = self - future_moves
            // else:
            //     to_post = self
            // 
            // for move in to_post:
            //     affects_tax_report = move._affect_tax_report()
            //     lock_dates = move._get_violated_lock_dates(move.date, affects_tax_report)
            //     if lock_dates:
            //         move.date = move._get_accounting_date(move.invoice_date or move.date, affects_tax_report, lock_dates=lock_dates)
            // 
            // # Create the analytic lines in batch is faster as it leads to less cache invalidation.
            // to_post.line_ids._create_analytic_lines()
            // 
            // # Trigger copying for recurring invoices
            // to_post.filtered(lambda m: m.auto_post not in ('no', 'at_date'))._copy_recurring_entries()
            // 
            // for invoice in to_post:
            //     # Fix inconsistencies that may occure if the OCR has been editing the invoice at the same time of a user. We force the
            //     # partner on the lines to be the same as the one on the move, because that's the only one the user can see/edit.
            //     wrong_lines = invoice.is_invoice() and invoice.line_ids.filtered(lambda aml:
            //         aml.partner_id != invoice.commercial_partner_id
            //         and aml.display_type not in ('line_note', 'line_section')
            //     )
            //     if wrong_lines:
            //         wrong_lines.write({'partner_id': invoice.commercial_partner_id.id})
            // 
            // # reconcile if state is in draft and move has reversal_entry_id set
            // draft_reverse_moves = to_post.filtered(lambda move: move.reversed_entry_id and move.reversed_entry_id.state == 'posted')
            // 
            // to_post.write({
            //     'state': 'posted',
            //     'posted_before': True,
            // })
            // 
            // draft_reverse_moves.reversed_entry_id._reconcile_reversed_moves(draft_reverse_moves, self._context.get('move_reverse_cancel', False))
            // to_post.line_ids._reconcile_marked()
            // 
            // for invoice in to_post:
            //     partner_id = invoice.partner_id
            //     subscribers = [partner_id.id] if partner_id and partner_id not in invoice.sudo().message_partner_ids else None
            //     invoice.message_subscribe(subscribers)
            // 
            // customer_count, supplier_count = defaultdict(int), defaultdict(int)
            // for invoice in to_post:
            //     if invoice.is_sale_document():
            //         customer_count[invoice.partner_id] += 1
            //     elif invoice.is_purchase_document():
            //         supplier_count[invoice.partner_id] += 1
            //     elif invoice.move_type == 'entry':
            //         sale_amls = invoice.line_ids.filtered(lambda line: line.partner_id and line.account_id.account_type == 'asset_receivable')
            //         for partner in sale_amls.mapped('partner_id'):
            //             customer_count[partner] += 1
            //         purchase_amls = invoice.line_ids.filtered(lambda line: line.partner_id and line.account_id.account_type == 'liability_payable')
            //         for partner in purchase_amls.mapped('partner_id'):
            //             supplier_count[partner] += 1
            // for partner, count in customer_count.items():
            //     (partner | partner.commercial_partner_id)._increase_rank('customer_rank', count)
            // for partner, count in supplier_count.items():
            //     (partner | partner.commercial_partner_id)._increase_rank('supplier_rank', count)
            // 
            // # Trigger action for paid invoices if amount is zero
            // to_post.filtered(
            //     lambda m: m.is_invoice(include_receipts=True) and m.currency_id.is_zero(m.amount_total)
            // )._invoice_paid_hook()
            // 
            // return to_post
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _post(self, soft=True):
            // # OVERRIDE
            // # Set the electronic document to be posted and post immediately for synchronous formats.
            // posted = super()._post(soft=soft)
            // 
            // edi_document_vals_list = []
            // for move in posted:
            //     for edi_format in move.journal_id.edi_format_ids:
            //         move_applicability = edi_format._get_move_applicability(move)
            // 
            //         if move_applicability:
            //             errors = edi_format._check_move_configuration(move)
            //             if errors:
            //                 raise UserError(_("Invalid invoice configuration:\n\n%s", '\n'.join(errors)))
            // 
            //             existing_edi_document = move.edi_document_ids.filtered(lambda x: x.edi_format_id == edi_format)
            //             if existing_edi_document:
            //                 existing_edi_document.sudo().write({
            //                     'state': 'to_send',
            //                     'attachment_id': False,
            //                 })
            //             else:
            //                 edi_document_vals_list.append({
            //                     'edi_format_id': edi_format.id,
            //                     'move_id': move.id,
            //                     'state': 'to_send',
            //                 })
            // 
            // self.env['account.edi.document'].create(edi_document_vals_list)
            // posted.edi_document_ids._process_documents_no_web_services()
            // if not self.env.context.get('skip_account_edi_cron_trigger'):
            //     self.env.ref('account_edi.ir_cron_edi_network')._trigger()
            // return posted
            --- ODOO METHOD SOURCE (MODULE: account_fleet, FILE: account_move.py) ---
            // def _post(self, soft=True):
            // vendor_bill_service = self.env.ref('account_fleet.data_fleet_service_type_vendor_bill', raise_if_not_found=False)
            // if not vendor_bill_service:
            //     return super()._post(soft)
            // 
            // val_list = []
            // log_list = []
            // posted = super()._post(soft)  # We need the move name to be set, but we also need to know which move are posted for the first time.
            // for line in posted.line_ids:
            //     if not line.vehicle_id or line.vehicle_log_service_ids\
            //             or line.move_id.move_type != 'in_invoice'\
            //             or line.display_type != 'product':
            //         continue
            //     val = line._prepare_fleet_log_service()
            //     log = _('Service Vendor Bill: %s', line.move_id._get_html_link())
            //     val_list.append(val)
            //     log_list.append(log)
            // log_service_ids = self.env['fleet.vehicle.log.services'].create(val_list)
            // for log_service_id, log in zip(log_service_ids, log_list):
            //     log_service_id.message_post(body=log)
            // return posted
            --- ODOO METHOD SOURCE (MODULE: product_email_template, FILE: account_move.py) ---
            // def _post(self, soft=True):
            // # OVERRIDE
            // posted = super()._post(soft)
            // posted.invoice_validate_send_email()
            // return posted
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: account_invoice.py) ---
            // def _post(self, soft=True):
            // if not self._context.get('move_reverse_cancel'):
            //     self.env['account.move.line'].create(self._stock_account_prepare_anglo_saxon_in_lines_vals())
            // 
            // # Create correction layer and impact accounts if invoice price is different
            // stock_valuation_layers = self.env['stock.valuation.layer'].sudo()
            // valued_lines = self.env['account.move.line'].sudo()
            // for invoice in self:
            //     if invoice.sudo().stock_valuation_layer_ids:
            //         continue
            //     if invoice.move_type in ('in_invoice', 'in_refund', 'in_receipt'):
            //         valued_lines |= invoice.invoice_line_ids.filtered(
            //             lambda l: l.product_id and l.product_id.cost_method != 'standard')
            // if valued_lines:
            //     svls, _amls = valued_lines._apply_price_difference()
            //     stock_valuation_layers |= svls
            // 
            // for (product, company), dummy in groupby(stock_valuation_layers, key=lambda svl: (svl.product_id, svl.company_id)):
            //     product = product.with_company(company.id)
            //     if not float_is_zero(product.quantity_svl, precision_rounding=product.uom_id.rounding):
            //         product.sudo().with_context(disable_auto_svl=True).write({'standard_price': product.value_svl / product.quantity_svl})
            // 
            // for (lot, company), dummy in groupby(stock_valuation_layers, key=lambda svl: (svl.lot_id, svl.company_id)):
            //     if not lot:
            //         continue
            //     lot = lot.with_company(company.id)
            //     if not float_is_zero(lot.quantity_svl, precision_rounding=lot.product_id.uom_id.rounding):
            //         lot.sudo().with_context(disable_auto_svl=True).write({'standard_price': lot.value_svl / lot.quantity_svl})
            // 
            // posted = super(AccountMove, self.with_context(skip_cogs_reconciliation=True))._post(soft)
            // 
            // # The invoice reference is set during the super call
            // for layer in stock_valuation_layers:
            //     description = f"{layer.account_move_line_id.move_id.display_name} - {layer.product_id.display_name}"
            //     layer.description = description
            // 
            // if stock_valuation_layers:
            //     stock_valuation_layers._validate_accounting_entries()
            // 
            // self._stock_account_anglo_saxon_reconcile_valuation()
            // 
            // return posted
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move.py) ---
            // def _post(self, soft=True):
            // # OVERRIDE
            // # Auto-reconcile the invoice with payments coming from transactions.
            // # It's useful when you have a "paid" sale order (using a payment transaction) and you invoice it later.
            // posted = super()._post(soft)
            // 
            // for invoice in posted.filtered(lambda move: move.is_invoice()):
            //     payments = invoice.mapped('transaction_ids.payment_id').filtered(lambda x: x.state == 'in_process')
            //     move_lines = payments.move_id.line_ids.filtered(lambda line: line.account_type in ('asset_receivable', 'liability_payable') and not line.reconciled)
            //     for line in move_lines:
            //         invoice.js_assign_outstanding_line(line.id)
            // return posted
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move.py) ---
            // def _post(self, soft=True):
            // # OVERRIDE
            // 
            // # Don't change anything on moves used to cancel another ones.
            // if self._context.get('move_reverse_cancel'):
            //     return super()._post(soft)
            // 
            // # Create additional COGS lines for customer invoices.
            // self.env['account.move.line'].create(self._stock_account_prepare_anglo_saxon_out_lines_vals())
            // 
            // # Post entries.
            // posted = super()._post(soft)
            // 
            // # Reconcile COGS lines in case of anglo-saxon accounting with perpetual valuation.
            // if not self.env.context.get('skip_cogs_reconciliation'):
            //     posted._stock_account_anglo_saxon_reconcile_valuation()
            // return posted
            --- ODOO METHOD SOURCE (MODULE: stock_landed_costs, FILE: account_move.py) ---
            // def _post(self, soft=True):
            // posted = super()._post(soft)
            // posted.sudo().landed_costs_ids.reconcile_landed_cost()
            // return posted
            */
            return default;
        }

        protected async Task<AccountMove> PrepareCashRoundingBaseLineForTaxesComputationInternalAsync(object cash_rounding_line)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _prepare_cash_rounding_base_line_for_taxes_computation(self, cash_rounding_line):
            // """ Convert an account.move.line having display_type='rounding' into a base line for the taxes computation.
            // 
            // :param cash_rounding_line: An account.move.line.
            // :return: A base line returned by '_prepare_base_line_for_taxes_computation'.
            // """
            // self.ensure_one()
            // sign = self.direction_sign
            // rate = self.invoice_currency_rate
            // 
            // return self.env['account.tax']._prepare_base_line_for_taxes_computation(
            //     cash_rounding_line,
            //     price_unit=sign * cash_rounding_line.amount_currency,
            //     quantity=1.0,
            //     sign=sign,
            //     special_mode='total_excluded',
            //     special_type='cash_rounding',
            // 
            //     is_refund=self.move_type in ('out_refund', 'in_refund'),
            //     rate=rate,
            // )
            */
            return default;
        }

        protected async Task<AccountMove> PrepareEdiTaxDetailsInternalAsync(object filter_to_apply, object filter_invl_to_apply, object grouping_key_generator)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _prepare_edi_tax_details(self, filter_to_apply=None, filter_invl_to_apply=None, grouping_key_generator=None):
            // ''' Compute amounts related to taxes for the current invoice.
            // 
            // :param filter_to_apply:         Optional filter to exclude some tax values from the final results.
            //                                 The filter is defined as a method getting a dictionary as parameter
            //                                 representing the tax values for a single repartition line.
            //                                 This dictionary contains:
            // 
            //     'base_line_id':             An account.move.line record.
            //     'tax_id':                   An account.tax record.
            //     'tax_repartition_line_id':  An account.tax.repartition.line record.
            //     'base_amount':              The tax base amount expressed in company currency.
            //     'tax_amount':               The tax amount expressed in company currency.
            //     'base_amount_currency':     The tax base amount expressed in foreign currency.
            //     'tax_amount_currency':      The tax amount expressed in foreign currency.
            // 
            //                                 If the filter is returning False, it means the current tax values will be
            //                                 ignored when computing the final results.
            // 
            // :param filter_invl_to_apply:    Optional filter to exclude some invoice lines.
            // 
            // :param grouping_key_generator:  Optional method used to group tax values together. By default, the tax values
            //                                 are grouped by tax. This parameter is a method getting a dictionary as parameter
            //                                 (same signature as 'filter_to_apply').
            // 
            //                                 This method must returns a dictionary where values will be used to create the
            //                                 grouping_key to aggregate tax values together. The returned dictionary is added
            //                                 to each tax details in order to retrieve the full grouping_key later.
            // 
            // :return:                        The full tax details for the current invoice and for each invoice line
            //                                 separately. The returned dictionary is the following:
            // 
            //     'base_amount':              The total tax base amount in company currency for the whole invoice.
            //     'tax_amount':               The total tax amount in company currency for the whole invoice.
            //     'base_amount_currency':     The total tax base amount in foreign currency for the whole invoice.
            //     'tax_amount_currency':      The total tax amount in foreign currency for the whole invoice.
            //     'tax_details':              A mapping of each grouping key (see 'grouping_key_generator') to a dictionary
            //                                 containing:
            // 
            //         'base_amount':              The tax base amount in company currency for the current group.
            //         'tax_amount':               The tax amount in company currency for the current group.
            //         'base_amount_currency':     The tax base amount in foreign currency for the current group.
            //         'tax_amount_currency':      The tax amount in foreign currency for the current group.
            //         'group_tax_details':        The list of all tax values aggregated into this group.
            // 
            //     'tax_details_per_record': A mapping of each invoice line to a dictionary containing:
            // 
            //         'base_amount':          The total tax base amount in company currency for the whole invoice line.
            //         'tax_amount':           The total tax amount in company currency for the whole invoice line.
            //         'base_amount_currency': The total tax base amount in foreign currency for the whole invoice line.
            //         'tax_amount_currency':  The total tax amount in foreign currency for the whole invoice line.
            //         'tax_details':          A mapping of each grouping key (see 'grouping_key_generator') to a dictionary
            //                                 containing:
            // 
            //             'base_amount':          The tax base amount in company currency for the current group.
            //             'tax_amount':           The tax amount in company currency for the current group.
            //             'base_amount_currency': The tax base amount in foreign currency for the current group.
            //             'tax_amount_currency':  The tax amount in foreign currency for the current group.
            //             'group_tax_details':    The list of all tax values aggregated into this group.
            // 
            // '''
            // return self._prepare_invoice_aggregated_taxes(
            //     filter_invl_to_apply=filter_invl_to_apply,
            //     filter_tax_values_to_apply=filter_to_apply,
            //     grouping_key_generator=grouping_key_generator,
            // )
            */
            return default;
        }

        protected async Task<AccountMove> PrepareEdiValsToExportInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _prepare_edi_vals_to_export(self):
            // ''' The purpose of this helper is to prepare values in order to export an invoice through the EDI system.
            // This includes the computation of the tax details for each invoice line that could be very difficult to
            // handle regarding the computation of the base amount.
            // 
            // :return: A python dict containing default pre-processed values.
            // '''
            // self.ensure_one()
            // 
            // res = {
            //     'record': self,
            //     'balance_multiplicator': -1 if self.is_inbound() else 1,
            //     'invoice_line_vals_list': [],
            // }
            // 
            // # Invoice lines details.
            // for index, line in enumerate(self.invoice_line_ids.filtered(lambda line: line.display_type == 'product'), start=1):
            //     line_vals = line._prepare_edi_vals_to_export()
            //     line_vals['index'] = index
            //     res['invoice_line_vals_list'].append(line_vals)
            // 
            // # Totals.
            // res.update({
            //     'total_price_subtotal_before_discount': sum(x['price_subtotal_before_discount'] for x in res['invoice_line_vals_list']),
            //     'total_price_discount': sum(x['price_discount'] for x in res['invoice_line_vals_list']),
            // })
            // 
            // return res
            */
            return default;
        }

        protected async Task<AccountMove> PrepareEpdBaseLineForTaxesComputationInternalAsync(object epd_line)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _prepare_epd_base_line_for_taxes_computation(self, epd_line):
            // """ Convert an account.move.line having display_type='epd' into a base line for the taxes computation.
            // 
            // :param epd_line: An account.move.line.
            // :return: A base line returned by '_prepare_base_line_for_taxes_computation'.
            // """
            // self.ensure_one()
            // sign = self.direction_sign
            // rate = self.invoice_currency_rate
            // 
            // return self.env['account.tax']._prepare_base_line_for_taxes_computation(
            //     epd_line,
            //     price_unit=sign * epd_line.amount_currency,
            //     quantity=1.0,
            //     sign=sign,
            //     special_mode='total_excluded',
            //     special_type='early_payment',
            // 
            //     is_refund=self.move_type in ('out_refund', 'in_refund'),
            //     rate=rate,
            // )
            */
            return default;
        }

        protected async Task<AccountMove> PrepareEpdBaseLinesForTaxesComputationFromBaseLinesInternalAsync(object base_lines)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _prepare_epd_base_lines_for_taxes_computation_from_base_lines(self, base_lines):
            // """ Anticipate the epd lines to be generated from the base lines passed as parameter.
            // When the record is in draft (not saved), the accounting items are not there so we can't
            // call '_prepare_epd_base_line_for_taxes_computation'.
            // 
            // :param base_lines: The base lines generated by '_prepare_product_base_line_for_taxes_computation'.
            // :return: A list of base lines representing the epd lines.
            // """
            // self.ensure_one()
            // aggregated_results = self._sync_dynamic_line_needed_values(base_lines.mapped('epd_needed'))
            // sign = self.direction_sign
            // rate = self.invoice_currency_rate
            // epd_lines = []
            // for grouping_key, values in aggregated_results.items():
            //     all_values = {**grouping_key, **values}
            //     epd_lines.append(self.env['account.tax']._prepare_base_line_for_taxes_computation(
            //         all_values,
            //         id=grouping_key,
            //         tax_ids=self.env['account.tax'].browse(all_values['tax_ids'][0][2]),
            //         price_unit=sign * values['amount_currency'],
            //         quantity=1.0,
            //         currency_id=self.currency_id,
            //         sign=1,
            //         special_mode='total_excluded',
            //         special_type='early_payment',
            // 
            //         partner_id=self.commercial_partner_id,
            //         account_id=self.env['account.account'].browse(all_values['account_id']),
            //         is_refund=self.move_type in ('out_refund', 'in_refund'),
            //         rate=rate,
            //     ))
            // return epd_lines
            */
            return default;
        }

        protected async Task<AccountMove> PrepareInvoiceAggregatedTaxesInternalAsync(object filter_invl_to_apply, object filter_tax_values_to_apply, object grouping_key_generator, object round_from_tax_lines, object postfix_function)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _prepare_invoice_aggregated_taxes(
            //     self,
            //     filter_invl_to_apply=None,
            //     filter_tax_values_to_apply=None,
            //     grouping_key_generator=None,
            //     round_from_tax_lines=None,
            //     postfix_function=None,
            // ):
            //     """ This method is deprecated and will be removed in the next version.
            //     Use the following pattern instead:
            // 
            //     base_amls = self.line_ids.filtered(lambda x: x.display_type == 'product')
            //     base_lines = [self._prepare_product_base_line_for_taxes_computation(x) for x in base_amls]
            //     tax_amls = self.line_ids.filtered('tax_repartition_line_id')
            //     tax_lines = [self._prepare_tax_line_for_taxes_computation(x) for x in tax_amls]
            //     AccountTax._add_tax_details_in_base_lines(base_lines, self.company_id)
            //     AccountTax._round_base_lines_tax_details(base_lines, self.company_id, tax_lines=tax_lines)
            // 
            //     def grouping_function(base_line, tax_data):
            //         ...
            // 
            //     base_lines_aggregated_values = self._aggregate_base_lines_tax_details(base_lines, grouping_function)
            //     values_per_grouping_key = self._aggregate_base_lines_aggregated_values(base_lines_aggregated_values)
            //     """
            //     self.ensure_one()
            //     AccountTax = self.env['account.tax']
            //     if round_from_tax_lines is None:
            //         round_from_tax_lines = filter_tax_values_to_apply or filter_invl_to_apply
            // 
            //     base_amls = self.line_ids.filtered(lambda x: x.display_type == 'product' and (not filter_invl_to_apply or filter_invl_to_apply(x)))
            //     base_lines = [self._prepare_product_base_line_for_taxes_computation(x) for x in base_amls]
            //     tax_amls = self.line_ids.filtered('tax_repartition_line_id')
            //     tax_lines = self._prepare_tax_lines_for_taxes_computation(tax_amls, round_from_tax_lines)
            //     AccountTax._add_tax_details_in_base_lines(base_lines, self.company_id)
            //     if postfix_function:
            //         postfix_function(base_lines)
            //     AccountTax._round_base_lines_tax_details(base_lines, self.company_id, tax_lines=tax_lines)
            // 
            //     # Retro-compatibility with previous aggregator.
            //     results = {
            //         'base_amount_currency': 0.0,
            //         'base_amount': 0.0,
            //         'tax_amount_currency': 0.0,
            //         'tax_amount': 0.0,
            //         'tax_details_per_record': defaultdict(lambda: {
            //             'base_amount_currency': 0.0,
            //             'base_amount': 0.0,
            //             'tax_amount_currency': 0.0,
            //             'tax_amount': 0.0,
            //         }),
            //         'base_lines': base_lines,
            //     }
            // 
            //     def total_grouping_function(base_line, tax_data):
            //         if tax_data:
            //             return not filter_tax_values_to_apply or filter_tax_values_to_apply(base_line, tax_data)
            // 
            //     # Report the total amounts.
            //     base_lines_aggregated_values = AccountTax._aggregate_base_lines_tax_details(base_lines, total_grouping_function)
            //     for base_line, aggregated_values in base_lines_aggregated_values:
            //         record = base_line['record']
            //         base_line_results = results['tax_details_per_record'][record]
            //         base_line_results['base_line'] = base_line
            //         for grouping_key, values in aggregated_values.items():
            //             if grouping_key:
            //                 for key in ('base_amount', 'base_amount_currency', 'tax_amount', 'tax_amount_currency'):
            //                     base_line_results[key] += values[key]
            // 
            //     values_per_grouping_key = AccountTax._aggregate_base_lines_aggregated_values(base_lines_aggregated_values)
            //     for grouping_key, values in values_per_grouping_key.items():
            //         if grouping_key:
            //             for key in ('base_amount', 'base_amount_currency', 'tax_amount', 'tax_amount_currency'):
            //                 results[key] += values[key]
            // 
            //     # Same with the custom grouping_key passed as parameter.
            //     def tax_details_grouping_function(base_line, tax_data):
            //         if not total_grouping_function(base_line, tax_data):
            //             return None
            //         if grouping_key_generator:
            //             grouping_key = grouping_key_generator(base_line, tax_data)
            //             assert grouping_key is not None  # None must be kept for inner-grouping.
            //             return grouping_key
            //         return tax_data['tax']
            // 
            //     base_lines_aggregated_values = AccountTax._aggregate_base_lines_tax_details(base_lines, tax_details_grouping_function)
            //     for base_line, aggregated_values in base_lines_aggregated_values:
            //         record = base_line['record']
            //         base_line_results = results['tax_details_per_record'][record]
            //         base_line_results['tax_details'] = tax_details = {}
            //         for grouping_key, values in aggregated_values.items():
            //             if not grouping_key:
            //                 continue
            //             if isinstance(grouping_key, dict):
            //                 values.update(grouping_key)
            //             tax_details[grouping_key] = values
            // 
            //     values_per_grouping_key = AccountTax._aggregate_base_lines_aggregated_values(base_lines_aggregated_values)
            //     results['tax_details'] = tax_details = {}
            //     for grouping_key, values in values_per_grouping_key.items():
            //         if not grouping_key:
            //             continue
            //         if isinstance(grouping_key, dict):
            //             values.update(grouping_key)
            //         tax_details[grouping_key] = values
            // 
            //     return results
            */
            return default;
        }

        protected async Task<AccountMove> PrepareProductBaseLineForTaxesComputationInternalAsync(object product_line)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _prepare_product_base_line_for_taxes_computation(self, product_line):
            // """ Convert an account.move.line having display_type='product' into a base line for the taxes computation.
            // 
            // :param product_line: An account.move.line.
            // :return: A base line returned by '_prepare_base_line_for_taxes_computation'.
            // """
            // self.ensure_one()
            // is_invoice = self.is_invoice(include_receipts=True)
            // sign = self.direction_sign if is_invoice else 1
            // if is_invoice:
            //     rate = self.invoice_currency_rate
            // else:
            //     rate = (abs(product_line.amount_currency) / abs(product_line.balance)) if product_line.balance else 0.0
            // 
            // return self.env['account.tax']._prepare_base_line_for_taxes_computation(
            //     product_line,
            //     price_unit=product_line.price_unit if is_invoice else product_line.amount_currency,
            //     quantity=product_line.quantity if is_invoice else 1.0,
            //     discount=product_line.discount if is_invoice else 0.0,
            //     rate=rate,
            //     sign=sign,
            //     special_mode=False if is_invoice else 'total_excluded',
            // )
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: account_move.py) ---
            // def _prepare_product_base_line_for_taxes_computation(self, product_line):
            // # EXTENDS 'account'
            // results = super()._prepare_product_base_line_for_taxes_computation(product_line)
            // if product_line.expense_id:
            //     results['special_mode'] = 'total_included'
            // return results
            */
            return default;
        }

        protected async Task<AccountMove> PrepareTaxLineForTaxesComputationInternalAsync(object tax_line)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _prepare_tax_line_for_taxes_computation(self, tax_line):
            // """ Convert an account.move.line having display_type='tax' into a tax line for the taxes computation.
            // 
            // :param tax_line: An account.move.line.
            // :return: A tax line returned by '_prepare_tax_line_for_taxes_computation'.
            // """
            // self.ensure_one()
            // return self.env['account.tax']._prepare_tax_line_for_taxes_computation(
            //     tax_line,
            //     sign=self.direction_sign,
            // )
            */
            return default;
        }

        protected async Task<AccountMove> PrepareTaxLinesForTaxesComputationInternalAsync(object tax_amls, object round_from_tax_lines)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _prepare_tax_lines_for_taxes_computation(self, tax_amls, round_from_tax_lines):
            // if round_from_tax_lines:
            //     return [self._prepare_tax_line_for_taxes_computation(x) for x in tax_amls]
            // return []
            */
            return default;
        }

        public async Task<AccountMove> PreviewInvoiceAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def preview_invoice(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_url',
            //     'target': 'self',
            //     'url': self.get_portal_url(),
            // }
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: account_move.py) ---
            // def preview_invoice(self):
            // action = super().preview_invoice()
            // if action['url'].startswith('/'):
            //     # URL should always be relative, safety check
            //     action['url'] = f'/@{action["url"]}'
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> PrintPdfAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_print_pdf(self):
            // self.ensure_one()
            // return self.env.ref('account.account_invoices').report_action(self.id)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> ProcessAttachmentsForTemplatePostInternalAsync(object mail_template)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _process_attachments_for_template_post(self, mail_template):
            // """ Add Edi attachments to templates. """
            // result = super()._process_attachments_for_template_post(mail_template)
            // for move in self.filtered('edi_document_ids'):
            //     move_result = result.setdefault(move.id, {})
            //     for edi_doc in move.edi_document_ids:
            //         edi_attachments = edi_doc._filter_edi_attachments_for_mailing()
            //         move_result.setdefault('attachment_ids', []).extend(edi_attachments.get('attachment_ids', []))
            //         move_result.setdefault('attachments', []).extend(edi_attachments.get('attachments', []))
            // return result
            */
            return default;
        }

        public async Task<AccountMove> ProcessEdiWebServicesAsync(Guid id, AccountMoveProcessEdiWebServicesRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def action_process_edi_web_services(self, with_commit=True):
            // docs = self.edi_document_ids.filtered(lambda d: d.state in ('to_send', 'to_cancel') and d.blocking_level != 'error')
            // docs._process_documents_web_services(with_commit=with_commit)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> PurchaseMatchingAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def action_purchase_matching(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _("Purchase Matching"),
            //     'res_model': 'purchase.bill.line.match',
            //     'domain': [
            //         ('partner_id', 'in', (self.partner_id | self.partner_id.commercial_partner_id).ids),
            //         ('company_id', 'in', self.env.company.ids),
            //         ('account_move_id', 'in', [self.id, False]),
            //     ],
            //     'views': [(self.env.ref('purchase.purchase_bill_line_match_tree').id, 'list')],
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> QuickEditModeSuggestInvoiceDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _quick_edit_mode_suggest_invoice_date(self):
            // """Suggest the Customer Invoice/Vendor Bill date based on previous invoice and lock dates"""
            // for record in self:
            //     if record.quick_edit_mode and not record.invoice_date:
            //         invoice_date = fields.Date.context_today(self)
            //         prev_move = self.search([('state', '=', 'posted'),
            //                                  ('journal_id', '=', record.journal_id.id),
            //                                  ('company_id', '=', record.company_id.id),
            //                                  ('invoice_date', '!=', False)],
            //                                 limit=1)
            //         if prev_move:
            //             invoice_date = self._get_accounting_date(prev_move.invoice_date, False)
            //         record.invoice_date = invoice_date
            */
            return default;
        }

        protected async Task<AccountMove> RecomputeCashRoundingLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _recompute_cash_rounding_lines(self):
            // ''' Handle the cash rounding feature on invoices.
            // 
            // In some countries, the smallest coins do not exist. For example, in Switzerland, there is no coin for 0.01 CHF.
            // For this reason, if invoices are paid in cash, you have to round their total amount to the smallest coin that
            // exists in the currency. For the CHF, the smallest coin is 0.05 CHF.
            // 
            // There are two strategies for the rounding:
            // 
            // 1) Add a line on the invoice for the rounding: The cash rounding line is added as a new invoice line.
            // 2) Add the rounding in the biggest tax amount: The cash rounding line is added as a new tax line on the tax
            // having the biggest balance.
            // '''
            // self.ensure_one()
            // def _compute_cash_rounding(self, total_amount_currency):
            //     ''' Compute the amount differences due to the cash rounding.
            //     :param self:                    The current account.move record.
            //     :param total_amount_currency:   The invoice's total in invoice's currency.
            //     :return:                        The amount differences both in company's currency & invoice's currency.
            //     '''
            //     difference = self.invoice_cash_rounding_id.compute_difference(self.currency_id, total_amount_currency)
            //     if self.currency_id == self.company_id.currency_id:
            //         diff_amount_currency = diff_balance = difference
            //     else:
            //         diff_amount_currency = difference
            //         diff_balance = self.currency_id._convert(diff_amount_currency, self.company_id.currency_id, self.company_id, self.invoice_date or self.date)
            //     return diff_balance, diff_amount_currency
            // 
            // def _apply_cash_rounding(self, diff_balance, diff_amount_currency, cash_rounding_line):
            //     ''' Apply the cash rounding.
            //     :param self:                    The current account.move record.
            //     :param diff_balance:            The computed balance to set on the new rounding line.
            //     :param diff_amount_currency:    The computed amount in invoice's currency to set on the new rounding line.
            //     :param cash_rounding_line:      The existing cash rounding line.
            //     :return:                        The newly created rounding line.
            //     '''
            //     rounding_line_vals = {
            //         'balance': diff_balance,
            //         'amount_currency': diff_amount_currency,
            //         'partner_id': self.partner_id.id,
            //         'move_id': self.id,
            //         'currency_id': self.currency_id.id,
            //         'company_id': self.company_id.id,
            //         'company_currency_id': self.company_id.currency_id.id,
            //         'display_type': 'rounding',
            //     }
            // 
            //     if self.invoice_cash_rounding_id.strategy == 'biggest_tax':
            //         biggest_tax_line = None
            //         for tax_line in self.line_ids.filtered('tax_repartition_line_id'):
            //             if not biggest_tax_line or abs(tax_line.balance) > abs(biggest_tax_line.balance):
            //                 biggest_tax_line = tax_line
            // 
            //         # No tax found.
            //         if not biggest_tax_line:
            //             return
            // 
            //         rounding_line_vals.update({
            //             'name': _("%(tax_name)s (rounding)", tax_name=biggest_tax_line.name),
            //             'account_id': biggest_tax_line.account_id.id,
            //             'tax_repartition_line_id': biggest_tax_line.tax_repartition_line_id.id,
            //             'tax_tag_ids': [(6, 0, biggest_tax_line.tax_tag_ids.ids)],
            //             'tax_ids': [Command.set(biggest_tax_line.tax_ids.ids)]
            //         })
            // 
            //     elif self.invoice_cash_rounding_id.strategy == 'add_invoice_line':
            //         if diff_balance > 0.0 and self.invoice_cash_rounding_id.loss_account_id:
            //             account_id = self.invoice_cash_rounding_id.loss_account_id.id
            //         else:
            //             account_id = self.invoice_cash_rounding_id.profit_account_id.id
            //         rounding_line_vals.update({
            //             'name': self.invoice_cash_rounding_id.name,
            //             'account_id': account_id,
            //             'tax_ids': [Command.clear()]
            //         })
            // 
            //     # Create or update the cash rounding line.
            //     if cash_rounding_line:
            //         cash_rounding_line.write(rounding_line_vals)
            //     else:
            //         cash_rounding_line = self.env['account.move.line'].create(rounding_line_vals)
            // 
            // existing_cash_rounding_line = self.line_ids.filtered(lambda line: line.display_type == 'rounding')
            // 
            // # The cash rounding has been removed.
            // if not self.invoice_cash_rounding_id:
            //     existing_cash_rounding_line.unlink()
            //     # self.line_ids -= existing_cash_rounding_line
            //     return
            // 
            // # The cash rounding strategy has changed.
            // if self.invoice_cash_rounding_id and existing_cash_rounding_line:
            //     strategy = self.invoice_cash_rounding_id.strategy
            //     old_strategy = 'biggest_tax' if existing_cash_rounding_line.tax_line_id else 'add_invoice_line'
            //     if strategy != old_strategy:
            //         # self.line_ids -= existing_cash_rounding_line
            //         existing_cash_rounding_line.unlink()
            //         existing_cash_rounding_line = self.env['account.move.line']
            // 
            // others_lines = self.line_ids.filtered(lambda line: line.account_id.account_type not in ('asset_receivable', 'liability_payable'))
            // others_lines -= existing_cash_rounding_line
            // total_amount_currency = sum(others_lines.mapped('amount_currency'))
            // 
            // diff_balance, diff_amount_currency = _compute_cash_rounding(self, total_amount_currency)
            // 
            // # The invoice is already rounded.
            // if self.currency_id.is_zero(diff_balance) and self.currency_id.is_zero(diff_amount_currency):
            //     existing_cash_rounding_line.unlink()
            //     # self.line_ids -= existing_cash_rounding_line
            //     return
            // 
            // # No update needed
            // if existing_cash_rounding_line \
            //     and float_compare(existing_cash_rounding_line.balance, diff_balance, precision_rounding=self.currency_id.rounding) == 0 \
            //     and float_compare(existing_cash_rounding_line.amount_currency, diff_amount_currency, precision_rounding=self.currency_id.rounding) == 0:
            //     return
            // 
            // _apply_cash_rounding(self, diff_balance, diff_amount_currency, existing_cash_rounding_line)
            */
            return default;
        }

        protected async Task<AccountMove> ReconcileReversedMovesInternalAsync(object reverse_moves, object move_reverse_cancel)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _reconcile_reversed_moves(self, reverse_moves, move_reverse_cancel):
            // ''' Reconciles moves in self and reverse moves
            // :param move_reverse_cancel: parameter used when lines are reconciled
            //                             will determine whether the tax cash basis journal entries should be created
            // :param reverse_moves:       An account.move recordset, reverse of the current self.
            // :return:                    An account.move recordset, reverse of the current self.
            // '''
            // for move, reverse_move in zip(self, reverse_moves):
            //     group = (move.line_ids + reverse_move.line_ids) \
            //         .filtered(lambda l: not l.reconciled) \
            //         .sorted(lambda l: l.account_type not in ('asset_receivable', 'liability_payable')) \
            //         .grouped(lambda l: (l.account_id, l.currency_id))
            //     for (account, _currency), lines in group.items():
            //         if (
            //             all(not line.reconciled for line in lines) # if it was reconciled due to a previous group
            //             and account.reconcile or account.account_type in ('asset_cash', 'liability_credit_card')
            //         ):
            //             lines.with_context(move_reverse_cancel=move_reverse_cancel).reconcile()
            // return reverse_moves
            */
            return default;
        }

        public async Task<AccountMove> RefreshInvoiceCurrencyRateAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def refresh_invoice_currency_rate(self):
            // for move in self:
            //     move.invoice_currency_rate = move.expected_currency_rate
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> RefundCleanupLinesInternalAsync(object lines)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_move.py) ---
            // def _refund_cleanup_lines(self, lines):
            // result = super(AccountMove, self)._refund_cleanup_lines(lines)
            // for i, line in enumerate(lines):
            //     for name, field in line._fields.items():
            //         if name == 'asset_category_id':
            //             result[i][2][name] = False
            //             break
            // return result
            */
            return default;
        }

        protected async Task<AccountMove> RefundsOriginRequiredInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _refunds_origin_required(self):
            // return False
            */
            return default;
        }

        public async Task<AccountMove> RegisterPaymentAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_register_payment(self):
            // if any(m.state != 'posted' for m in self):
            //     raise UserError(_("You can only register payment for posted journal entries."))
            // return self.action_force_register_payment()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> RequireBillDateForAutopostInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _require_bill_date_for_autopost(self):
            // """Vendor bills must have an invoice date set to be posted. Require it for auto-posted bills."""
            // for record in self:
            //     if record.auto_post != 'no' and record.is_purchase_document() and not record.invoice_date:
            //         raise ValidationError(_("For this entry to be automatically posted, it required a bill date."))
            */
            return default;
        }

        public async Task<AccountMove> RetryEdiDocumentsErrorAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def action_retry_edi_documents_error(self):
            // self._retry_edi_documents_error_hook()
            // self.edi_document_ids.write({'error': False, 'blocking_level': False})
            // self.action_process_edi_web_services()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> RetryEdiDocumentsErrorHookInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _retry_edi_documents_error_hook(self):
            // ''' Hook called when edi_documents are retried. For example, when it's needed to clean a field.
            // TO OVERRIDE
            // '''
            // return
            */
            return default;
        }

        public async Task<AccountMove> ReverseAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_reverse(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("account.action_view_account_move_reversal")
            // 
            // if self.is_invoice():
            //     action['name'] = _('Credit Note')
            // 
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> ReverseMovesInternalAsync(object default_values_list, object cancel)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _reverse_moves(self, default_values_list=None, cancel=False):
            // ''' Reverse a recordset of account.move.
            // If cancel parameter is true, the reconcilable or liquidity lines
            // of each original move will be reconciled with its reverse's.
            // :param default_values_list: A list of default values to consider per move.
            //                             ('type' & 'reversed_entry_id' are computed in the method).
            // :return:                    An account.move recordset, reverse of the current self.
            // '''
            // if not default_values_list:
            //     default_values_list = [{} for move in self]
            // 
            // if cancel:
            //     lines = self.mapped('line_ids')
            //     # Avoid maximum recursion depth.
            //     if lines:
            //         lines.remove_move_reconcile()
            // 
            // reverse_moves = self.env['account.move']
            // for move, default_values in zip(self, default_values_list):
            //     default_values.update({
            //         'move_type': TYPE_REVERSE_MAP[move.move_type],
            //         'reversed_entry_id': move.id,
            //         'partner_id': move.partner_id.id,
            //     })
            //     reverse_moves += move.with_context(
            //         move_reverse_cancel=cancel,
            //         include_business_fields=True,
            //         skip_invoice_sync=move.move_type == 'entry',
            //     ).copy(default_values)
            // 
            // reverse_moves.with_context(skip_invoice_sync=cancel).write({'line_ids': [
            //     Command.update(line.id, {
            //         'balance': -line.balance,
            //         'amount_currency': -line.amount_currency,
            //     })
            //     for line in reverse_moves.line_ids
            //     if line.move_id.move_type == 'entry' or line.display_type == 'cogs'
            // ]})
            // 
            // # Reconcile moves together to cancel the previous one.
            // if cancel:
            //     reverse_moves.with_context(move_reverse_cancel=cancel)._post(soft=False)
            // 
            // return reverse_moves
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: account_move.py) ---
            // def _reverse_moves(self, default_values_list=None, cancel=False):
            // # EXTENDS account
            // own_expense_moves = self.filtered(lambda move: move.expense_sheet_id.payment_mode == 'own_account')
            // own_expense_moves.write({'expense_sheet_id': False, 'ref': False})
            // # else, when restarting the expense flow we get duplicate issue on vendor.bill
            // return super()._reverse_moves(default_values_list=default_values_list, cancel=cancel)
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move.py) ---
            // def _reverse_moves(self, default_values_list=None, cancel=False):
            // # OVERRIDE
            // if not default_values_list:
            //     default_values_list = [{} for move in self]
            // for move, default_values in zip(self, default_values_list):
            //     default_values.update({
            //         'campaign_id': move.campaign_id.id,
            //         'medium_id': move.medium_id.id,
            //         'source_id': move.source_id.id,
            //     })
            // return super()._reverse_moves(default_values_list=default_values_list, cancel=cancel)
            --- ODOO METHOD SOURCE (MODULE: sale_expense, FILE: account_move_line.py) ---
            // def _reverse_moves(self, default_values_list=None, cancel=False):
            // self.expense_sheet_id._sale_expense_reset_sol_quantities()
            // res = super()._reverse_moves(default_values_list, cancel)
            // return res
            */
            return default;
        }

        protected async Task<AccountMove> RoutingCheckRouteInternalAsync(object message, object message_dict, object route, object raise_exception)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _routing_check_route(self, message, message_dict, route, raise_exception=True):
            // if route[0] == 'account.move' and len(message_dict['attachments']) < 1:
            //     # Don't create the move if no attachment.
            //     body = self.env['ir.qweb']._render('account.email_template_mail_gateway_failed', {
            //         'company_email': self.env.company.email,
            //         'company_name': self.env.company.name,
            //     })
            //     self._routing_create_bounce_email(
            //         message_dict['from'], body, message,
            //         references=f'{message_dict["message_id"]} {generate_tracking_message_id("loop-detection-bounce-email")}')
            //     return ()
            // return super()._routing_check_route(message, message_dict, route, raise_exception=raise_exception)
            */
            return default;
        }

        protected async Task<AccountMove> SanitizeValsInternalAsync(object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sanitize_vals(self, vals):
            // if vals.get('invoice_line_ids') and vals.get('line_ids'):
            //     # values can sometimes be in only one of the two fields, sometimes in
            //     # both fields, sometimes one field can be explicitely empty while the other
            //     # one is not, sometimes not...
            //     update_vals = {
            //         line_id: line_vals[0]
            //         for command, line_id, *line_vals in vals['invoice_line_ids']
            //         if command == Command.UPDATE
            //     }
            //     for command, line_id, *line_vals in vals['line_ids']:
            //         if command == Command.UPDATE and line_id in update_vals:
            //             line_vals[0].update(update_vals.pop(line_id))
            //     for line_id, line_vals in update_vals.items():
            //         vals['line_ids'] += [Command.update(line_id, line_vals)]
            //     for command, line_id, *line_vals in vals['invoice_line_ids']:
            //         assert command not in (Command.SET, Command.CLEAR)
            //         if [command, line_id, *line_vals] not in vals['line_ids']:
            //             vals['line_ids'] += [(command, line_id, *line_vals)]
            //     del vals['invoice_line_ids']
            // return vals
            */
            return default;
        }

        protected async Task<AccountMove> SearchDefaultJournalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _search_default_journal(self):
            // if self.statement_line_ids.statement_id.journal_id:
            //     return self.statement_line_ids.statement_id.journal_id[:1]
            // 
            // journal_types = self._get_valid_journal_types()
            // company = self.company_id or self.env.company
            // domain = [
            //     *self.env['account.journal']._check_company_domain(company),
            //     ('type', 'in', journal_types),
            // ]
            // 
            // journal = None
            // # the currency is not a hard dependence, it triggers via manual add_to_compute
            // # avoid computing the currency before all it's dependences are set (like the journal...)
            // if self.env.cache.contains(self, self._fields['currency_id']):
            //     currency_id = self.currency_id.id or self._context.get('default_currency_id')
            //     if currency_id and currency_id != company.currency_id.id:
            //         currency_domain = domain + [('currency_id', '=', currency_id)]
            //         journal = self.env['account.journal'].search(currency_domain, limit=1)
            // 
            // if not journal:
            //     journal = self.env['account.journal'].search(domain, limit=1)
            // 
            // if not journal:
            //     error_msg = self.env['account.journal']._build_no_journal_error_msg(company.display_name, journal_types)
            //     raise UserError(error_msg)
            // 
            // return journal
            */
            return default;
        }

        protected async Task<AccountMove> SearchJournalGroupIdInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _search_journal_group_id(self, operator, value):
            // field = 'name' if 'like' in operator else 'id'
            // journal_groups = self.env['account.journal.group'].search([(field, operator, value)])
            // return [('journal_id', 'not in', journal_groups.excluded_journal_ids.ids)]
            */
            return default;
        }

        protected async Task<AccountMove> SearchNextPaymentDateInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _search_next_payment_date(self, operator, value):
            // if operator not in ('=', '<', '<='):
            //     raise UserError(self.env._('Operation not supported'))
            // return [('line_ids', 'any', [('reconciled', '=', False), ('payment_date', operator, value)])]
            */
            return default;
        }

        protected async Task<AccountMove> SearchSecuredInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _search_secured(self, operator, value):
            // if operator not in ['=', '!='] or value not in [True, False]:
            //     raise UserError(_('Operation not supported'))
            // 
            // want_secured = (operator == '=') == value
            // return [('inalterable_hash', '!=' if want_secured else '=', False)]
            */
            return default;
        }

        public async Task<AccountMove> SendAndPrintAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_send_and_print(self):
            // self.env['account.move.send']._check_move_constrains(self)
            // return {
            //     'name': _("Print & Send"),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'account.move.send.wizard' if len(self) == 1 else 'account.move.send.batch.wizard',
            //     'target': 'new',
            //     'context': {
            //         'active_model': 'account.move',
            //         'active_ids': self.ids,
            //     },
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> SendOnlyWhenReadyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _send_only_when_ready(self):
            // moves_not_ready = self.filtered(lambda x: not x._is_ready_to_be_sent())
            // 
            // try:
            //     yield
            // finally:
            //     moves_now_ready = moves_not_ready.filtered(lambda x: x._is_ready_to_be_sent())
            //     if moves_now_ready:
            //         moves_now_ready._action_invoice_ready_to_be_sent()
            */
            return default;
        }

        protected async Task<AccountMove> SequenceFixedRegexInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sequence_fixed_regex(self):
            // return self.journal_id.sequence_override_regex or super()._sequence_fixed_regex
            */
            return default;
        }

        protected async Task<AccountMove> SequenceMonthlyRegexInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sequence_monthly_regex(self):
            // return self.journal_id.sequence_override_regex or super()._sequence_monthly_regex
            */
            return default;
        }

        protected async Task<AccountMove> SequenceYearRangeMonthlyRegexInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sequence_year_range_monthly_regex(self):
            // return self.journal_id.sequence_override_regex or super()._sequence_year_range_monthly_regex
            */
            return default;
        }

        protected async Task<AccountMove> SequenceYearRangeRegexInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sequence_year_range_regex(self):
            // return self.journal_id.sequence_override_regex or super()._sequence_year_range_regex
            */
            return default;
        }

        protected async Task<AccountMove> SequenceYearlyRegexInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sequence_yearly_regex(self):
            // return self.journal_id.sequence_override_regex or super()._sequence_yearly_regex
            */
            return default;
        }

        protected async Task<AccountMove> SetNextMadeSequenceGapInternalAsync(bool made_gap)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _set_next_made_sequence_gap(self, made_gap: bool):
            // """Update the field made_sequence_gap on the next moves of the current ones.
            // 
            // Either:
            // - we changed something related to the sequence on the current moves, so we need to set the
            //   sequence as broken on the next moves before updating (made_gap=True)
            // - we are filling a gap, so we need to update the next move to remove the flag (made_gap=False)
            // """
            // next_moves = self.browse()
            // named = self.filtered(lambda m: m.name and m.name != '/')
            // for (journal, prefix), moves in named.grouped(lambda move: (move.journal_id, move.sequence_prefix)).items():
            //     next_moves += self.env['account.move'].sudo().search([
            //         ('journal_id', '=', journal.id),
            //         ('sequence_prefix', '=', prefix),
            //         ('sequence_number', 'in', [move.sequence_number + 1 for move in moves]),
            //     ])
            // next_moves.made_sequence_gap = made_gap
            */
            return default;
        }

        protected async Task<AccountMove> SetPurchaseOrdersInternalAsync(object purchase_orders, object force_write)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def _set_purchase_orders(self, purchase_orders, force_write=True):
            // """Link the given purchase orders to this vendor bill and add their lines as invoice lines.
            // 
            // :param purchase_orders: a list of purchase orders to be linked to this vendor bill
            // :param force_write: whether to delete all existing invoice lines before adding the vendor bill lines
            // """
            // with self.env.cr.savepoint():
            //     with self._get_edi_creation() as invoice:
            //         if force_write and invoice.line_ids:
            //             invoice.invoice_line_ids = [Command.clear()]
            //         for purchase_order in purchase_orders:
            //             invoice.invoice_line_ids = [Command.create({
            //                 'display_type': 'line_section',
            //                 'name': _('From %s', purchase_order.name)
            //             })]
            //             invoice.purchase_id = purchase_order
            //             invoice._onchange_purchase_auto_complete()
            */
            return default;
        }

        protected async Task<AccountMove> SetReversedEntryInternalAsync(object credit_note)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _set_reversed_entry(self, credit_note):
            // """ Try to find the original invoice for a single credit_note. """
            // if len(credit_note) != 1 or credit_note.move_type != 'out_refund':
            //     return
            // 
            // original_invoice = self.filtered(lambda inv: inv.move_type == 'out_invoice'
            //                                  and credit_note.invoice_line_ids.sale_line_ids in inv.invoice_line_ids.sale_line_ids)
            // if len(original_invoice) == 1 and original_invoice._refunds_origin_required():
            //     credit_note.reversed_entry_id = original_invoice.id
            */
            return default;
        }

        protected async Task<AccountMove> ShowAutopostBillsWizardInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _show_autopost_bills_wizard(self):
            // if (
            //     len(self) != 1
            //     or self.state != "posted"
            //     or not self.is_purchase_document(include_receipts=True)
            //     or self.restrict_mode_hash_table
            //     or all(not l.is_imported for l in self.line_ids)
            //     or not self.partner_id
            //     or self.partner_id.autopost_bills != "ask"
            //     or not self.company_id.autopost_bills
            //     or self.is_manually_modified
            // ):
            //     return False
            // prev_bills_same_partner = self.search([
            //     ('id', '!=', self.id),
            //     ('partner_id', '=', self.partner_id.id),
            //     ('state', '=', 'posted'),
            //     ('move_type', 'in', self.get_purchase_types(include_receipts=True)),
            // ], order="create_date DESC", limit=10)
            // nb_unmodified_bills = 1  # +1 for current bill that hasn't been modified either
            // for move in prev_bills_same_partner:
            //     if move.is_manually_modified:
            //         break
            //     nb_unmodified_bills += 1
            // if nb_unmodified_bills < 3:
            //     return False
            // wizard = self.env['account.autopost.bills.wizard'].create({
            //     'partner_id': self.partner_id.id,
            //     'nb_unmodified_bills': nb_unmodified_bills,
            // })
            // return {
            //     'name': _("Autopost Bills"),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'account.autopost.bills.wizard',
            //     'res_id': wizard.id,
            //     'views': [(False, 'form')],
            //     'target': 'new',
            // }
            */
            return default;
        }

        protected async Task<AccountMove> StockAccountAngloSaxonReconcileValuationInternalAsync(object product)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move.py) ---
            // def _stock_account_anglo_saxon_reconcile_valuation(self, product=False):
            // """ Reconciles the entries made in the interim accounts in anglosaxon accounting,
            // reconciling stock valuation move lines with the invoice's.
            // """
            // reconcile_plan = []
            // no_exchange_reconcile_plan = []
            // for move in self:
            //     if not move.is_invoice():
            //         continue
            //     if not move.company_id.anglo_saxon_accounting:
            //         continue
            // 
            //     stock_moves = move._stock_account_get_last_step_stock_moves()
            //     # In case we return a return, we have to provide the related AMLs so all can be reconciled
            //     stock_moves |= stock_moves.origin_returned_move_id
            // 
            //     if not stock_moves:
            //         continue
            // 
            //     products = product or move.mapped('invoice_line_ids.product_id')
            //     for prod in products:
            //         if prod.valuation != 'real_time':
            //             continue
            // 
            //         # We first get the invoices move lines (taking the invoice and the previous ones into account)...
            //         product_accounts = prod.product_tmpl_id._get_product_accounts()
            //         if move.is_sale_document():
            //             product_interim_account = product_accounts['stock_output']
            //         else:
            //             product_interim_account = product_accounts['stock_input']
            // 
            //         if product_interim_account.reconcile:
            //             # Search for anglo-saxon lines linked to the product in the journal entry.
            //             product_account_moves = move.line_ids.filtered(
            //                 lambda line: line.product_id == prod and line.account_id == product_interim_account and not line.reconciled)
            // 
            //             # Search for anglo-saxon lines linked to the product in the stock moves.
            //             product_stock_moves = stock_moves._get_all_related_sm(prod)
            //             product_account_moves |= product_stock_moves._get_all_related_aml().filtered(
            //                 lambda line: line.account_id == product_interim_account and not line.reconciled and line.move_id.state == "posted"
            //             )
            // 
            //             correction_amls = product_account_moves.filtered(
            //                 lambda aml: aml.move_id.sudo().stock_valuation_layer_ids.stock_valuation_layer_id or (aml.display_type == 'cogs' and not aml.quantity)
            //             )
            //             invoice_aml = product_account_moves.filtered(lambda aml: aml not in correction_amls and aml.move_id == move)
            //             stock_aml = product_account_moves - correction_amls - invoice_aml
            // 
            //             # Reconcile:
            //             # In case there is a move with correcting lines that has not been posted
            //             # (e.g., it's dated for some time in the future) we should defer any
            //             # reconciliation with exchange difference.
            //             if correction_amls or 'draft' in move.line_ids.sudo().stock_valuation_layer_ids.account_move_id.mapped('state'):
            //                 if sum(correction_amls.mapped('balance')) > 0 or all(aml.is_same_currency for aml in correction_amls):
            //                     no_exchange_reconcile_plan += [product_account_moves]
            //                 else:
            //                     no_exchange_reconcile_plan += [invoice_aml | correction_amls]
            //                     moves_to_reconcile = (invoice_aml.filtered(lambda aml: not aml.reconciled) | stock_aml)
            //                     if moves_to_reconcile:
            //                         no_exchange_reconcile_plan += [moves_to_reconcile]
            //             else:
            //                 reconcile_plan += [product_account_moves]
            // self.env['account.move.line']._reconcile_plan(reconcile_plan)
            // no_exchange_reconcile_plan = [amls.filtered(lambda aml: not aml.reconciled) for amls in no_exchange_reconcile_plan]
            // self.env['account.move.line'].with_context(no_exchange_difference=True)._reconcile_plan(no_exchange_reconcile_plan)
            */
            return default;
        }

        protected async Task<AccountMove> StockAccountGetLastStepStockMovesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: account_move.py) ---
            // def _stock_account_get_last_step_stock_moves(self):
            // stock_moves = super(AccountMove, self)._stock_account_get_last_step_stock_moves()
            // for invoice in self.filtered(lambda x: x.move_type == 'out_invoice'):
            //     stock_moves += invoice.sudo().mapped('pos_order_ids.picking_ids.move_ids').filtered(lambda x: x.state == 'done' and x.location_dest_id.usage == 'customer')
            // for invoice in self.filtered(lambda x: x.move_type == 'out_refund'):
            //     stock_moves += invoice.sudo().mapped('pos_order_ids.picking_ids.move_ids').filtered(lambda x: x.state == 'done' and x.location_id.usage == 'customer')
            // return stock_moves
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: account_invoice.py) ---
            // def _stock_account_get_last_step_stock_moves(self):
            // """ Overridden from stock_account.
            // Returns the stock moves associated to this invoice."""
            // rslt = super(AccountMove, self)._stock_account_get_last_step_stock_moves()
            // for invoice in self.filtered(lambda x: x.move_type == 'in_invoice'):
            //     rslt += invoice.mapped('invoice_line_ids.purchase_line_id.move_ids').filtered(lambda x: x.state == 'done' and x.location_id.usage == 'supplier')
            // for invoice in self.filtered(lambda x: x.move_type == 'in_refund'):
            //     rslt += invoice.mapped('invoice_line_ids.purchase_line_id.move_ids').filtered(lambda x: x.state == 'done' and x.location_dest_id.usage == 'supplier')
            // return rslt
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: account_move.py) ---
            // def _stock_account_get_last_step_stock_moves(self):
            // """ Overridden from stock_account.
            // Returns the stock moves associated to this invoice."""
            // rslt = super(AccountMove, self)._stock_account_get_last_step_stock_moves()
            // for invoice in self:
            //     if invoice.move_type not in ['out_invoice', 'out_refund']:
            //         continue
            //     if (invoice.move_type == 'out_invoice' or (
            //         invoice.move_type == 'out_refund' and any(invoice.invoice_line_ids.sale_line_ids.mapped('is_downpayment')))
            //     ):
            //         rslt += invoice.mapped('invoice_line_ids.sale_line_ids.move_ids').filtered(lambda x: x.state == 'done' and x.location_dest_id.usage == 'customer')
            //     else:
            //         rslt += invoice.mapped('reversed_entry_id.invoice_line_ids.sale_line_ids.move_ids').filtered(lambda x: x.state == 'done' and x.location_id.usage == 'customer')
            //         # Add refunds generated from the SO
            //         rslt += invoice.mapped('invoice_line_ids.sale_line_ids.move_ids').filtered(lambda x: x.state == 'done' and x.location_id.usage == 'customer')
            // return rslt
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move.py) ---
            // def _stock_account_get_last_step_stock_moves(self):
            // """ To be overridden for customer invoices and vendor bills in order to
            // return the stock moves related to the invoices in self.
            // """
            // return self.env['stock.move']
            */
            return default;
        }

        protected async Task<AccountMove> StockAccountPrepareAngloSaxonInLinesValsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: account_invoice.py) ---
            // def _stock_account_prepare_anglo_saxon_in_lines_vals(self):
            // ''' Prepare values used to create the journal items (account.move.line) corresponding to the price difference
            //  lines for vendor bills. It only concerns the quantities that have been delivered before the bill
            // Example:
            // Buy a product having a cost of 9 and a supplier price of 10 and being a storable product and having a perpetual
            // valuation in FIFO. Deliver the product and then post the bill. The vendor bill's journal entries looks like:
            // Account                                     | Debit | Credit
            // ---------------------------------------------------------------
            // 101120 Stock Interim Account (Received)     | 10.0  |
            // ---------------------------------------------------------------
            // 101100 Account Payable                      |       | 10.0
            // ---------------------------------------------------------------
            // This method computes values used to make two additional journal items:
            // ---------------------------------------------------------------
            // 101120 Stock Interim Account (Received)     |       | 1.0
            // ---------------------------------------------------------------
            // xxxxxx Expenses                             | 1.0   |
            // ---------------------------------------------------------------
            // :return: A list of Python dictionary to be passed to env['account.move.line'].create.
            // '''
            // lines_vals_list = []
            // price_unit_prec = self.env['decimal.precision'].precision_get('Product Price')
            // 
            // for move in self:
            //     if move.move_type not in ('in_invoice', 'in_refund', 'in_receipt') or not move.company_id.anglo_saxon_accounting:
            //         continue
            // 
            //     move = move.with_company(move.company_id)
            //     for line in move.invoice_line_ids:
            //         # Filter out lines being not eligible for price difference.
            //         # Moreover, this function is used for standard cost method only.
            //         if not line._eligible_for_cogs() or line.product_id.cost_method != 'standard':
            //             continue
            // 
            //         # Retrieve accounts needed to generate the price difference.
            //         debit_pdiff_account = False
            //         if line.product_id.cost_method == 'standard':
            //             debit_pdiff_account = line.product_id.property_account_creditor_price_difference \
            //                 or line.product_id.categ_id.property_account_creditor_price_difference_categ
            //             debit_pdiff_account = move.fiscal_position_id.map_account(debit_pdiff_account)
            //         else:
            //             debit_pdiff_account = line.product_id.product_tmpl_id.get_product_accounts(fiscal_pos=move.fiscal_position_id)['expense']
            //         if not debit_pdiff_account:
            //             continue
            // 
            //         price_unit_val_dif, relevant_qty = line._get_price_unit_val_dif_and_relevant_qty()
            //         price_subtotal = relevant_qty * price_unit_val_dif
            // 
            //         # We consider there is a price difference if the subtotal is not zero. In case a
            //         # discount has been applied, we can't round the price unit anymore, and hence we
            //         # can't compare them.
            //         if (
            //             not move.currency_id.is_zero(price_subtotal)
            //             and float_compare(line["price_unit"], line.price_unit, precision_digits=price_unit_prec) == 0
            //         ):
            // 
            //             # Add price difference account line.
            //             vals = {
            //                 'name': line.name[:64],
            //                 'move_id': move.id,
            //                 'partner_id': line.partner_id.id or move.commercial_partner_id.id,
            //                 'currency_id': line.currency_id.id,
            //                 'product_id': line.product_id.id,
            //                 'product_uom_id': line.product_uom_id.id,
            //                 'quantity': relevant_qty,
            //                 'price_unit': price_unit_val_dif,
            //                 'price_subtotal': relevant_qty * price_unit_val_dif,
            //                 'amount_currency': relevant_qty * price_unit_val_dif * line.move_id.direction_sign,
            //                 'balance': line.currency_id._convert(
            //                     relevant_qty * price_unit_val_dif * line.move_id.direction_sign,
            //                     line.company_currency_id,
            //                     line.company_id, fields.Date.today(),
            //                 ),
            //                 'account_id': debit_pdiff_account.id,
            //                 'analytic_distribution': line.analytic_distribution,
            //                 'display_type': 'cogs',
            //             }
            //             lines_vals_list.append(vals)
            // 
            //             # Correct the amount of the current line.
            //             vals = {
            //                 'name': line.name[:64],
            //                 'move_id': move.id,
            //                 'partner_id': line.partner_id.id or move.commercial_partner_id.id,
            //                 'currency_id': line.currency_id.id,
            //                 'product_id': line.product_id.id,
            //                 'product_uom_id': line.product_uom_id.id,
            //                 'quantity': relevant_qty,
            //                 'price_unit': -price_unit_val_dif,
            //                 'price_subtotal': relevant_qty * -price_unit_val_dif,
            //                 'amount_currency': relevant_qty * -price_unit_val_dif * line.move_id.direction_sign,
            //                 'balance': line.currency_id._convert(
            //                     relevant_qty * -price_unit_val_dif * line.move_id.direction_sign,
            //                     line.company_currency_id,
            //                     line.company_id, fields.Date.today(),
            //                 ),
            //                 'account_id': line.account_id.id,
            //                 'analytic_distribution': line.analytic_distribution,
            //                 'display_type': 'cogs',
            //             }
            //             lines_vals_list.append(vals)
            // return lines_vals_list
            */
            return default;
        }

        protected async Task<AccountMove> StockAccountPrepareAngloSaxonOutLinesValsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move.py) ---
            // def _stock_account_prepare_anglo_saxon_out_lines_vals(self):
            // ''' Prepare values used to create the journal items (account.move.line) corresponding to the Cost of Good Sold
            // lines (COGS) for customer invoices.
            // 
            // Example:
            // 
            // Buy a product having a cost of 9 being a storable product and having a perpetual valuation in FIFO.
            // Sell this product at a price of 10. The customer invoice's journal entries looks like:
            // 
            // Account                                     | Debit | Credit
            // ---------------------------------------------------------------
            // 200000 Product Sales                        |       | 10.0
            // ---------------------------------------------------------------
            // 101200 Account Receivable                   | 10.0  |
            // ---------------------------------------------------------------
            // 
            // This method computes values used to make two additional journal items:
            // 
            // ---------------------------------------------------------------
            // 220000 Expenses                             | 9.0   |
            // ---------------------------------------------------------------
            // 101130 Stock Interim Account (Delivered)    |       | 9.0
            // ---------------------------------------------------------------
            // 
            // Note: COGS are only generated for customer invoices except refund made to cancel an invoice.
            // 
            // :return: A list of Python dictionary to be passed to env['account.move.line'].create.
            // '''
            // lines_vals_list = []
            // price_unit_prec = self.env['decimal.precision'].precision_get('Product Price')
            // for move in self:
            //     # Make the loop multi-company safe when accessing models like product.product
            //     move = move.with_company(move.company_id)
            // 
            //     if not move.is_sale_document(include_receipts=True) or not move.company_id.anglo_saxon_accounting:
            //         continue
            // 
            //     anglo_saxon_price_ctx = move._get_anglo_saxon_price_ctx()
            // 
            //     for line in move.invoice_line_ids:
            // 
            //         # Filter out lines being not eligible for COGS.
            //         if not line._eligible_for_cogs():
            //             continue
            // 
            //         # Retrieve accounts needed to generate the COGS.
            //         accounts = line.product_id.product_tmpl_id.get_product_accounts(fiscal_pos=move.fiscal_position_id)
            //         debit_interim_account = accounts['stock_output']
            //         credit_expense_account = accounts['expense'] or move.journal_id.default_account_id
            //         if not debit_interim_account or not credit_expense_account:
            //             continue
            // 
            //         # Compute accounting fields.
            //         sign = -1 if move.move_type == 'out_refund' else 1
            //         price_unit = line.with_context(anglo_saxon_price_ctx)._stock_account_get_anglo_saxon_price_unit()
            //         amount_currency = sign * line.quantity * price_unit
            // 
            //         if move.currency_id.is_zero(amount_currency) or float_is_zero(price_unit, precision_digits=price_unit_prec):
            //             continue
            // 
            //         # Add interim account line.
            //         lines_vals_list.append({
            //             'name': line.name[:64],
            //             'move_id': move.id,
            //             'partner_id': move.commercial_partner_id.id,
            //             'product_id': line.product_id.id,
            //             'product_uom_id': line.product_uom_id.id,
            //             'quantity': line.quantity,
            //             'price_unit': price_unit,
            //             'amount_currency': -amount_currency,
            //             'account_id': debit_interim_account.id,
            //             'display_type': 'cogs',
            //             'tax_ids': [],
            //             'cogs_origin_id': line.id,
            //         })
            // 
            //         # Add expense account line.
            //         lines_vals_list.append({
            //             'name': line.name[:64],
            //             'move_id': move.id,
            //             'partner_id': move.commercial_partner_id.id,
            //             'product_id': line.product_id.id,
            //             'product_uom_id': line.product_uom_id.id,
            //             'quantity': line.quantity,
            //             'price_unit': -price_unit,
            //             'amount_currency': amount_currency,
            //             'account_id': credit_expense_account.id,
            //             'analytic_distribution': line.analytic_distribution,
            //             'display_type': 'cogs',
            //             'tax_ids': [],
            //             'cogs_origin_id': line.id,
            //         })
            // return lines_vals_list
            */
            return default;
        }

        protected async Task<AccountMove> StolenMoveInternalAsync(object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _stolen_move(self, vals):
            // for command in vals.get('line_ids', ()):
            //     if command[0] == Command.LINK:
            //         yield self.env['account.move.line'].browse(command[1]).move_id.id
            //     if command[0] == Command.SET:
            //         yield from self.env['account.move.line'].browse(command[2]).move_id.ids
            */
            return default;
        }

        public async Task<AccountMove> SwitchMoveTypeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_switch_move_type(self):
            // if any(move.posted_before for move in self):
            //     raise ValidationError(_("You cannot switch the type of a document which has been posted once."))
            // if any(move.move_type == "entry" for move in self):
            //     raise ValidationError(_("This action isn't available for this document."))
            // 
            // for move in self:
            //     in_out, old_move_type = move.move_type.split('_')
            //     new_move_type = f"{in_out}_{'invoice' if old_move_type == 'refund' else 'refund'}"
            //     move.name = False
            //     move.write({
            //         'move_type': new_move_type,
            //         'currency_id': move.currency_id.id,
            //         'fiscal_position_id': move.fiscal_position_id.id,
            //     })
            //     if move.amount_total < 0:
            //         move.write({
            //             'line_ids': [
            //                 Command.update(line.id, {'quantity': -line.quantity})
            //                 for line in move.line_ids
            //                 if line.display_type == 'product'
            //             ]
            //         })
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> SyncDynamicLineInternalAsync(object existing_key_fname, object needed_vals_fname, object needed_dirty_fname, object line_type, object container)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sync_dynamic_line(self, existing_key_fname, needed_vals_fname, needed_dirty_fname, line_type, container):
            // def existing():
            //     return {
            //         line: line[existing_key_fname]
            //         for line in container['records'].line_ids
            //         if line[existing_key_fname]
            //     }
            // 
            // def needed():
            //     return self._sync_dynamic_line_needed_values(container['records'].mapped(needed_vals_fname))
            // 
            // def dirty():
            //     *path, dirty_fname = needed_dirty_fname.split('.')
            //     eligible_recs = container['records'].mapped('.'.join(path))
            //     if eligible_recs._name == 'account.move.line':
            //         eligible_recs = eligible_recs.filtered(lambda l: l.display_type != 'cogs')
            //     dirty_recs = eligible_recs.filtered(dirty_fname)
            //     return dirty_recs, dirty_fname
            // 
            // def filter_trivial(mapping):
            //     return {k: v for k, v in mapping.items() if 'id' not in v}
            // 
            // inv_existing_before = existing()
            // needed_before = needed()
            // dirty_recs_before, dirty_fname = dirty()
            // dirty_recs_before[dirty_fname] = False
            // yield
            // dirty_recs_after, dirty_fname = dirty()
            // if not dirty_recs_after:  # TODO improve filter
            //     return
            // inv_existing_after = existing()
            // needed_after = needed()
            // 
            // # Filter out deleted lines from `needed_before` to not recompute lines if not necessary or wanted
            // line_ids = set(self.env['account.move.line'].browse(k['id'] for k in needed_before if 'id' in k).exists().ids)
            // needed_before = {k: v for k, v in needed_before.items() if 'id' not in k or k['id'] in line_ids}
            // 
            // # old key to new key for the same line
            // before2after = {
            //     before: inv_existing_after[bline]
            //     for bline, before in inv_existing_before.items()
            //     if bline in inv_existing_after
            // }
            // 
            // if needed_after == needed_before:
            //     return  # do not modify user input if nothing changed in the needs
            // if not needed_before and (filter_trivial(inv_existing_after) != filter_trivial(inv_existing_before)):
            //     return  # do not modify user input if already created manually
            // 
            // existing_after = defaultdict(list)
            // for k, v in inv_existing_after.items():
            //     existing_after[v].append(k)
            // to_delete = [
            //     line.id
            //     for line, key in inv_existing_before.items()
            //     if key not in needed_after
            //     and key in existing_after
            //     and before2after[key] not in needed_after
            // ]
            // to_delete_set = set(to_delete)
            // to_delete.extend(line.id
            //     for line, key in inv_existing_after.items()
            //     if key not in needed_after and line.id not in to_delete_set
            // )
            // to_create = {
            //     key: values
            //     for key, values in needed_after.items()
            //     if key not in existing_after
            // }
            // to_write = {
            //     line: values
            //     for key, values in needed_after.items()
            //     for line in existing_after[key]
            //     if any(
            //         self.env['account.move.line']._fields[fname].convert_to_write(line[fname], self)
            //         != values[fname]
            //         for fname in values
            //     )
            // }
            // 
            // while to_delete and to_create:
            //     key, values = to_create.popitem()
            //     line_id = to_delete.pop()
            //     self.env['account.move.line'].browse(line_id).write(
            //         {**key, **values, 'display_type': line_type}
            //     )
            // if to_delete:
            //     self.env['account.move.line'].browse(to_delete).with_context(dynamic_unlink=True).unlink()
            // if to_create:
            //     self.env['account.move.line'].with_context(clean_context(self.env.context)).create([
            //         {**key, **values, 'display_type': line_type}
            //         for key, values in to_create.items()
            //     ])
            // if to_write:
            //     for line, values in to_write.items():
            //         line.write(values)
            */
            return default;
        }

        protected async Task<AccountMove> SyncDynamicLineNeededValuesInternalAsync(object values_list)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sync_dynamic_line_needed_values(self, values_list):
            // res = {}
            // for computed_needed in values_list:
            //     if computed_needed is False:
            //         continue  # there was an invalidation, let's hope nothing needed to be changed...
            //     for key, values in computed_needed.items():
            //         if key not in res:
            //             res[key] = dict(values)
            //         else:
            //             ignore = True
            //             for fname in res[key]:
            //                 if self.env['account.move.line']._fields[fname].type == 'monetary':
            //                     res[key][fname] += values[fname]
            //                     if res[key][fname]:
            //                         ignore = False
            //             if ignore:
            //                 del res[key]
            // 
            // # Convert float values to their "ORM cache" one to prevent different rounding calculations
            // for key, values in res.items():
            //     move_id = key.get('move_id')
            //     if not move_id:
            //         continue
            //     record = self.env['account.move'].browse(move_id)
            //     for fname, current_value in values.items():
            //         field = self.env['account.move.line']._fields[fname]
            //         if isinstance(current_value, float):
            //             values[fname] = field.convert_to_cache(current_value, record)
            // 
            // return res
            */
            return default;
        }

        protected async Task<AccountMove> SyncDynamicLinesInternalAsync(object container)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sync_dynamic_lines(self, container):
            // with self._disable_recursion(container, 'skip_invoice_sync') as disabled:
            //     if disabled:
            //         yield
            //         return
            //     def update_containers():
            //         # Only invoice-like and journal entries in "auto tax mode" are synced
            //         tax_container['records'] = container['records'].filtered(lambda m: m.is_invoice(True) or m.line_ids.tax_ids or m.line_ids.tax_repartition_line_id)
            //         invoice_container['records'] = container['records'].filtered(lambda m: m.is_invoice(True))
            //         misc_container['records'] = container['records'].filtered(lambda m: m.is_entry() and not m.tax_cash_basis_origin_move_id)
            // 
            //     tax_container, invoice_container, misc_container = ({} for __ in range(3))
            //     update_containers()
            //     with ExitStack() as stack:
            //         stack.enter_context(self._sync_dynamic_line(
            //             existing_key_fname='term_key',
            //             needed_vals_fname='needed_terms',
            //             needed_dirty_fname='needed_terms_dirty',
            //             line_type='payment_term',
            //             container=invoice_container,
            //         ))
            //         stack.enter_context(self._sync_unbalanced_lines(misc_container))
            //         stack.enter_context(self._sync_rounding_lines(invoice_container))
            //         stack.enter_context(self._sync_dynamic_line(
            //             existing_key_fname='discount_allocation_key',
            //             needed_vals_fname='line_ids.discount_allocation_needed',
            //             needed_dirty_fname='line_ids.discount_allocation_dirty',
            //             line_type='discount',
            //             container=invoice_container,
            //         ))
            //         stack.enter_context(self._sync_tax_lines(tax_container))
            //         stack.enter_context(self._sync_dynamic_line(
            //             existing_key_fname='epd_key',
            //             needed_vals_fname='line_ids.epd_needed',
            //             needed_dirty_fname='line_ids.epd_dirty',
            //             line_type='epd',
            //             container=invoice_container,
            //         ))
            //         stack.enter_context(self._sync_invoice(invoice_container))
            //         line_container = {'records': self.line_ids}
            //         with self.line_ids._sync_invoice(line_container):
            //             yield
            //             line_container['records'] = self.line_ids
            //         update_containers()
            */
            return default;
        }

        protected async Task<AccountMove> SyncInvoiceInternalAsync(object container)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sync_invoice(self, container):
            // def existing():
            //     return {
            //         move: {
            //             'commercial_partner_id': move.commercial_partner_id,
            //         }
            //         for move in container['records'].filtered(lambda m: m.is_invoice(True))
            //     }
            // 
            // def changed(fname):
            //     return move not in before or before[move][fname] != after[move][fname]
            // 
            // before = existing()
            // yield
            // after = existing()
            // 
            // for move in after:
            //     if changed('commercial_partner_id'):
            //         move.line_ids.partner_id = after[move]['commercial_partner_id']
            */
            return default;
        }

        protected async Task<AccountMove> SyncRoundingLinesInternalAsync(object container)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sync_rounding_lines(self, container):
            // yield
            // for invoice in container['records']:
            //     if invoice.state != 'posted':
            //         invoice._recompute_cash_rounding_lines()
            */
            return default;
        }

        protected async Task<AccountMove> SyncTaxLinesInternalAsync(object container)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sync_tax_lines(self, container):
            // AccountTax = self.env['account.tax']
            // fake_base_line = AccountTax._prepare_base_line_for_taxes_computation(None)
            // 
            // def get_base_lines(move):
            //     return move.line_ids.filtered(lambda line: line.display_type in ('product', 'epd', 'rounding', 'cogs'))
            // 
            // def get_tax_lines(move):
            //     return move.line_ids.filtered('tax_repartition_line_id')
            // 
            // def get_value(record, field):
            //     return self.env['account.move.line']._fields[field].convert_to_write(record[field], record)
            // 
            // def get_tax_line_tracked_fields(line):
            //     return ('amount_currency', 'balance', 'analytic_distribution')
            // 
            // def get_base_line_tracked_fields(line):
            //     grouping_key = AccountTax._prepare_base_line_grouping_key(fake_base_line)
            //     if line.move_id.is_invoice(include_receipts=True):
            //         extra_fields = ['price_unit', 'quantity', 'discount']
            //     else:
            //         extra_fields = ['amount_currency']
            //     return list(grouping_key.keys()) + extra_fields
            // 
            // def field_has_changed(values, record, field):
            //     return get_value(record, field) != values.get(record, {}).get(field)
            // 
            // def get_changed_lines(values, records, fields=None):
            //     return (
            //         record
            //         for record in records
            //         if record not in values
            //         or any(field_has_changed(values, record, field) for field in values[record] if not fields or field in fields)
            //     )
            // 
            // def any_field_has_changed(values, records, fields=None):
            //     return any(record for record in get_changed_lines(values, records, fields))
            // 
            // def is_write_needed(line, values):
            //     return any(
            //         self.env['account.move.line']._fields[fname].convert_to_write(line[fname], self) != values[fname]
            //         for fname in values
            //     )
            // 
            // moves_values_before = {
            //     move: {
            //         field: get_value(move, field)
            //         for field in ('currency_id', 'partner_id', 'move_type')
            //     }
            //     for move in container['records']
            //     if move.state == 'draft'
            // }
            // base_lines_values_before = {
            //     move: {
            //         line: {
            //             field: get_value(line, field)
            //             for field in get_base_line_tracked_fields(line)
            //         }
            //         for line in get_base_lines(move)
            //     }
            //     for move in container['records']
            // }
            // tax_lines_values_before = {
            //     move: {
            //         line: {
            //             field: get_value(line, field)
            //             for field in get_tax_line_tracked_fields(line)
            //         }
            //         for line in get_tax_lines(move)
            //     }
            //     for move in container['records']
            // }
            // yield
            // 
            // to_delete = []
            // to_create = []
            // for move in container['records']:
            //     if move.state != 'draft':
            //         continue
            // 
            //     tax_lines = get_tax_lines(move)
            //     base_lines = get_base_lines(move)
            //     move_tax_lines_values_before = tax_lines_values_before.get(move, {})
            //     move_base_lines_values_before = base_lines_values_before.get(move, {})
            //     if (
            //         move.is_invoice(include_receipts=True)
            //         and (
            //             field_has_changed(moves_values_before, move, 'currency_id')
            //             or field_has_changed(moves_values_before, move, 'move_type')
            //         )
            //     ):
            //         # Changing the type of an invoice using 'switch to refund' feature or just changing the currency.
            //         round_from_tax_lines = False
            //     elif changed_lines := list(get_changed_lines(move_base_lines_values_before, base_lines)):
            //         # A base line has been modified.
            //         round_from_tax_lines = (
            //             # The changed lines don't affect the taxes.
            //             all(
            //                 not line.tax_ids and not move_base_lines_values_before.get(line, {}).get('tax_ids')
            //                 for line in changed_lines
            //             )
            //             # Keep the tax lines amounts if an amount has been manually computed.
            //             or (
            //                 list(move_tax_lines_values_before) != list(tax_lines)
            //                 or any(
            //                     self.env.is_protected(line._fields[fname], line)
            //                     for line in tax_lines
            //                     for fname in move_tax_lines_values_before[line]
            //                 )
            //             )
            //         )
            // 
            //         # If the move has been created with all lines including the tax ones and the balance/amount_currency are provided on
            //         # base lines, we don't need to recompute anything.
            //         if (
            //             round_from_tax_lines
            //             and any(line[field] for line in changed_lines for field in ('amount_currency', 'balance'))
            //         ):
            //             continue
            //     elif any(line not in base_lines for line, values in move_base_lines_values_before.items() if values['tax_ids']):
            //         # Removed a base line affecting the taxes.
            //         round_from_tax_lines = any_field_has_changed(move_tax_lines_values_before, tax_lines)
            //     else:
            //         continue
            // 
            //     base_lines_values, tax_lines_values = move._get_rounded_base_and_tax_lines(round_from_tax_lines=round_from_tax_lines)
            //     AccountTax._add_accounting_data_in_base_lines_tax_details(base_lines_values, move.company_id, include_caba_tags=move.always_tax_exigible)
            //     tax_results = AccountTax._prepare_tax_lines(base_lines_values, move.company_id, tax_lines=tax_lines_values)
            // 
            //     for base_line, to_update in tax_results['base_lines_to_update']:
            //         line = base_line['record']
            //         if is_write_needed(line, to_update):
            //             line.write(to_update)
            // 
            //     for tax_line_vals in tax_results['tax_lines_to_delete']:
            //         to_delete.append(tax_line_vals['record'].id)
            // 
            //     for tax_line_vals in tax_results['tax_lines_to_add']:
            //         to_create.append({
            //             **tax_line_vals,
            //             'display_type': 'tax',
            //             'move_id': move.id,
            //         })
            // 
            //     for tax_line_vals, grouping_key, to_update in tax_results['tax_lines_to_update']:
            //         line = tax_line_vals['record']
            //         if is_write_needed(line, to_update):
            //             line.write(to_update)
            // 
            // if to_delete:
            //     self.env['account.move.line'].browse(to_delete).with_context(dynamic_unlink=True).unlink()
            // if to_create:
            //     self.env['account.move.line'].create(to_create)
            */
            return default;
        }

        protected async Task<AccountMove> SyncUnbalancedLinesInternalAsync(object container)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sync_unbalanced_lines(self, container):
            // def has_tax(move):
            //     return bool(move.line_ids.tax_ids)
            // 
            // move_had_tax = {move: has_tax(move) for move in container['records']}
            // yield
            // # Skip posted moves.
            // for move in (x for x in container['records'] if x.state != 'posted'):
            //     if not has_tax(move) and not move_had_tax.get(move):
            //         continue  # only manage automatically unbalanced when taxes are involved
            //     if move_had_tax.get(move) and not has_tax(move):
            //         # taxes have been removed, the tax sync is deactivated so we need to clear everything here
            //         move.line_ids.filtered('tax_line_id').unlink()
            //         move.line_ids.tax_tag_ids = [Command.set([])]
            // 
            //     # Set the balancing line's balance and amount_currency to zero,
            //     # so that it does not interfere with _get_unbalanced_moves() below.
            //     balance_name = _('Automatic Balancing Line')
            //     existing_balancing_line = move.line_ids.filtered(lambda line: line.name == balance_name)
            //     if existing_balancing_line:
            //         existing_balancing_line.balance = existing_balancing_line.amount_currency = 0.0
            // 
            //     # Create an automatic balancing line to make sure the entry can be saved/posted.
            //     # If such a line already exists, we simply update its amounts.
            //     unbalanced_moves = self._get_unbalanced_moves({'records': move})
            //     if isinstance(unbalanced_moves, list) and len(unbalanced_moves) == 1:
            //         dummy, debit, credit = unbalanced_moves[0]
            // 
            //         vals = {'balance': credit - debit}
            //         if existing_balancing_line:
            //             existing_balancing_line.write(vals)
            //         else:
            //             vals.update({
            //                 'name': balance_name,
            //                 'move_id': move.id,
            //                 'account_id': move._get_automatic_balancing_account(),
            //                 'currency_id': move.currency_id.id,
            //                 # A balancing line should never have default taxes applied to it, it doesn't work well and wouldn't make much sense.
            //                 'tax_ids': False,
            //             })
            //             self.env['account.move.line'].create(vals)
            */
            return default;
        }

        protected async Task<AccountMove> SynchronizeBusinessModelsInternalAsync(object changed_fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _synchronize_business_models(self, changed_fields):
            // ''' Ensure the consistency between:
            // account.payment & account.move
            // account.bank.statement.line & account.move
            // 
            // The idea is to call the method performing the synchronization of the business
            // models regarding their related journal entries. To avoid cycling, the
            // 'skip_account_move_synchronization' key is used through the context.
            // 
            // :param changed_fields: A set containing all modified fields on account.move.
            // '''
            // if self._context.get('skip_account_move_synchronization'):
            //     return
            // 
            // self_sudo = self.sudo()
            // self_sudo.statement_line_id._synchronize_from_moves(changed_fields)
            */
            return default;
        }

        public async Task<AccountMove> ToggleBlockPaymentAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_toggle_block_payment(self):
            // self.ensure_one()
            // if self.payment_state == 'blocked':
            //     self.payment_state = 'not_paid'
            //     self.env.add_to_compute(self._fields['payment_state'], self)
            // else:
            //     if self.payment_state in ('paid', 'in_payment'):
            //         raise UserError(_("You can't block a paid invoice."))
            //     self.payment_state = 'blocked'
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _track_subtype(self, init_values):
            // # EXTENDS mail mail.thread
            // # add custom subtype depending of the state.
            // self.ensure_one()
            // 
            // if not self.is_invoice(include_receipts=True):
            //     if self.origin_payment_id and 'state' in init_values:
            //         self.origin_payment_id._message_track(['state'], {self.origin_payment_id.id: init_values})
            //     return super()._track_subtype(init_values)
            // 
            // if 'payment_state' in init_values and self.payment_state == 'paid':
            //     return self.env.ref('account.mt_invoice_paid')
            // elif 'state' in init_values and self.state == 'posted' and self.is_sale_document(include_receipts=True):
            //     return self.env.ref('account.mt_invoice_validated')
            // return super()._track_subtype(init_values)
            */
            return default;
        }

        protected async Task<AccountMove> UblParseAttachedDocumentInternalAsync(object tree)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py) ---
            // def _ubl_parse_attached_document(self, tree):
            // """
            // In UBL, an AttachedDocument file is a wrapper around multiple different UBL files.
            // According to the specifications the original document is stored within the top most
            // Attachment node either as an Attachment/EmbeddedDocumentBinaryObject or (in special cases)
            // a CDATA string stored in Attachment/ExternalReference/Description.
            // 
            // We must parse this before passing the original file to the decoder to figure out how best
            // to handle it.
            // """
            // attachment_node = tree.find('{*}Attachment')
            // if attachment_node is None:
            //     return tree
            // 
            // attachment_binary_data = attachment_node.find('./{*}EmbeddedDocumentBinaryObject')
            // if attachment_binary_data is not None \
            //         and attachment_binary_data.attrib.get('mimeCode') in ('application/xml', 'text/xml'):
            //     with suppress(etree.XMLSyntaxError, binascii.Error):
            //         text = b64decode(attachment_binary_data.text)
            //         return etree.fromstring(text)
            // 
            // external_reference = attachment_node.find('./{*}ExternalReference')
            // if external_reference is not None:
            //     description = external_reference.findtext('./{*}Description')
            //     mime_code = external_reference.findtext('./{*}MimeCode')
            // 
            //     if description and mime_code in ('application/xml', 'text/xml'):
            //         with suppress(etree.XMLSyntaxError):
            //             return etree.fromstring(description.encode('utf-8'))
            // return tree
            */
            return default;
        }

        protected async Task<AccountMove> UnlinkAccountAuditTrailExceptOncePostInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _unlink_account_audit_trail_except_once_post(self):
            // if not self._context.get('force_delete') and any(
            //         move.posted_before and move.company_id.check_account_audit_trail
            //         for move in self
            // ):
            //     raise UserError(_(
            //         "To keep the audit trail, you can not delete journal entries once they have been posted.\n"
            //         "Instead, you can cancel the journal entry."
            //     ))
            */
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def unlink(self):
            // self._set_next_made_sequence_gap(True)
            // self = self.with_context(skip_invoice_sync=True, dynamic_unlink=True)  # no need to sync to delete everything
            // logger_message = self._get_unlink_logger_message()
            // self.line_ids.unlink()
            // res = super().unlink()
            // if logger_message:
            //     _logger.info(logger_message)
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move.py) ---
            // def unlink(self):
            // downpayment_lines = self.mapped('line_ids.sale_line_ids').filtered(lambda line: line.is_downpayment and line.invoice_lines <= self.mapped('line_ids'))
            // res = super(AccountMove, self).unlink()
            // if downpayment_lines:
            //     downpayment_lines.unlink()
            // return res
            */
            return await base.UnlinkAsync(ids);
        }

        protected async Task<AccountMove> UnlinkForbidPartsOfChainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _unlink_forbid_parts_of_chain(self):
            // """ For a user with Billing/Bookkeeper rights, when the fidu mode is deactivated,
            // moves with a sequence number can only be deleted if they are the last element of a chain of sequence.
            // If they are not, deleting them would create a gap. If the user really wants to do this, he still can
            // explicitly empty the 'name' field of the move; but we discourage that practice.
            // If a user is a Billing Administrator/Accountant or if fidu mode is activated, we show a warning,
            // but they can delete the moves even if it creates a sequence gap.
            // """
            // if not (
            //     self.env.user.has_group('account.group_account_manager')
            //     or any(self.company_id.mapped('quick_edit_mode'))
            //     or self._context.get('force_delete')
            //     or self.check_move_sequence_chain()
            // ):
            //     raise UserError(_(
            //         "You cannot delete this entry, as it has already consumed a sequence number and is not the last one in the chain. "
            //         "You should probably revert it instead."
            //     ))
            */
            return default;
        }

        protected async Task<AccountMove> UnlinkOrReverseInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _unlink_or_reverse(self):
            // if not self:
            //     return
            // to_unlink = self.env['account.move']
            // to_cancel = self.env['account.move']
            // to_reverse = self.env['account.move']
            // for move in self:
            //     if not move._can_be_unlinked():
            //         to_reverse += move
            //     elif move._is_protected_by_audit_trail():
            //         to_cancel += move
            //     else:
            //         to_unlink += move
            // to_unlink.filtered(lambda m: m.state in ('posted', 'cancel')).button_draft()
            // to_unlink.filtered(lambda m: m.state == 'draft').unlink()
            // to_cancel.button_cancel()
            // return to_reverse._reverse_moves(cancel=True)
            */
            return default;
        }

        public async Task<AccountMove> UpdateFposValuesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_update_fpos_values(self):
            // self.invoice_line_ids._compute_price_unit()
            // self.invoice_line_ids._compute_tax_ids()
            // self.line_ids._compute_account_id()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountMove> UpdateOrderLineInfoInternalAsync(Guid product_id, object quantity)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _update_order_line_info(self, product_id, quantity, **kwargs):
            // """ Update account_move_line information for a given product or create a
            // new one if none exists yet.
            // :param int product_id: The product, as a `product.product` id.
            // :param int quantity: The quantity selected in the catalog
            // :return: The unit price of the product, based on the pricelist of the
            //          sale order and the quantity selected.
            // :rtype: float
            // """
            // move_line = self.line_ids.filtered(lambda line: line.product_id.id == product_id)
            // if move_line:
            //     if quantity != 0:
            //         move_line.quantity = quantity
            //     elif self.state in {'draft', 'sent'}:
            //         price_unit = self._get_product_price_and_data(move_line.product_id)['price']
            //         # The catalog is designed to allow the user to select products quickly.
            //         # Therefore, sometimes they may select the wrong product or decide to remove
            //         # some of them from the quotation. The unlink is there for that reason.
            //         move_line.unlink()
            //         return price_unit
            //     else:
            //         move_line.quantity = 0
            // elif quantity > 0:
            //     move_line = self.env['account.move.line'].create({
            //         'move_id': self.id,
            //         'quantity': quantity,
            //         'product_id': product_id,
            //     })
            // return move_line.price_unit
            --- ODOO METHOD SOURCE (MODULE: stock_landed_costs, FILE: account_move.py) ---
            // def _update_order_line_info(self, product_id, quantity, **kwargs):
            // price_unit = super()._update_order_line_info(product_id, quantity, **kwargs)
            // move_line = self.line_ids.filtered(lambda line: line.product_id.id == product_id)
            // if move_line:
            //     move_line.is_landed_costs_line = move_line.product_id.landed_cost_ok
            // return price_unit
            */
            return default;
        }

        protected async Task<AccountMove> ValidateTaxesCountryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _validate_taxes_country(self):
            // """ By playing with the fiscal position in the form view, it is possible to keep taxes on the invoices from
            // a different country than the one allowed by the fiscal country or the fiscal position.
            // This contrains ensure such account.move cannot be kept, as they could generate inconsistencies in the reports.
            // """
            // self._compute_tax_country_id() # We need to ensure this field has been computed, as we use it in our check
            // for record in self:
            //     amls = record.line_ids
            //     impacted_countries = amls.tax_ids.country_id | amls.tax_line_id.country_id
            //     if impacted_countries and impacted_countries != record.tax_country_id:
            //         if record.fiscal_position_id and impacted_countries != record.fiscal_position_id.country_id:
            //             raise ValidationError(_("This entry contains taxes that are not compatible with your fiscal position. Check the country set in fiscal position and in your tax configuration."))
            //         raise ValidationError(_("This entry contains one or more taxes that are incompatible with your fiscal country. Check company fiscal country in the settings and tax country in taxes configuration."))
            */
            return default;
        }

        public async Task<AccountMove> ViewDebitNotesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_debit_note, FILE: account_move.py) ---
            // def action_view_debit_notes(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Debit Notes'),
            //     'res_model': 'account.move',
            //     'view_mode': 'list,form',
            //     'domain': [('debit_origin_id', '=', self.id)],
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> ViewLandedCostsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_landed_costs, FILE: account_move.py) ---
            // def action_view_landed_costs(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("stock_landed_costs.action_stock_landed_cost")
            // domain = [('id', 'in', self.landed_costs_ids.ids)]
            // context = dict(self.env.context, default_vendor_bill_id=self.id)
            // views = [(self.env.ref('stock_landed_costs.view_stock_landed_cost_tree2').id, 'list'), (False, 'form'), (False, 'kanban')]
            // return dict(action, domain=domain, context=context, views=views)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> ViewPaymentTransactionsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: account_move.py) ---
            // def action_view_payment_transactions(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('payment.action_payment_transaction')
            // 
            // if len(self.transaction_ids) == 1:
            //     action['view_mode'] = 'form'
            //     action['res_id'] = self.transaction_ids.id
            //     action['views'] = []
            // else:
            //     action['domain'] = [('id', 'in', self.transaction_ids.ids)]
            // 
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> ViewSourcePurchaseOrdersAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def action_view_source_purchase_orders(self):
            // self.ensure_one()
            // source_orders = self.line_ids.purchase_line_id.order_id
            // result = self.env['ir.actions.act_window']._for_xml_id('purchase.purchase_form_action')
            // if len(source_orders) > 1:
            //     result['domain'] = [('id', 'in', source_orders.ids)]
            // elif len(source_orders) == 1:
            //     result['views'] = [(self.env.ref('purchase.purchase_order_form', False).id, 'form')]
            //     result['res_id'] = source_orders.id
            // else:
            //     result = {'type': 'ir.actions.act_window_close'}
            // return result
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> ViewSourceSaleOrdersAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move.py) ---
            // def action_view_source_sale_orders(self):
            // self.ensure_one()
            // source_orders = self.line_ids.sale_line_ids.order_id
            // result = self.env['ir.actions.act_window']._for_xml_id('sale.action_orders')
            // if len(source_orders) > 1:
            //     result['domain'] = [('id', 'in', source_orders.ids)]
            // elif len(source_orders) == 1:
            //     result['views'] = [(self.env.ref('sale.view_order_form', False).id, 'form')]
            //     result['res_id'] = source_orders.id
            // else:
            //     result = {'type': 'ir.actions.act_window_close'}
            // return result
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> ViewTimesheetAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: account_move.py) ---
            // def action_view_timesheet(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Timesheets'),
            //     'domain': [('project_id', '!=', False)],
            //     'res_model': 'account.analytic.line',
            //     'view_id': False,
            //     'view_mode': 'list,form',
            //     'help': _("""
            //         <p class="o_view_nocontent_smiling_face">
            //             Record timesheets
            //         </p><p>
            //             You can register and track your workings hours by project every
            //             day. Every time spent on a project will become a cost and can be re-invoiced to
            //             customers if required.
            //         </p>
            //     """),
            //     'limit': 80,
            //     'context': {
            //         'default_project_id': self.id,
            //         'search_default_project_id': [self.id]
            //     }
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountMove> ViewWipProductionAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: account_move.py) ---
            // def action_view_wip_production(self):
            // self.ensure_one()
            // action = {
            //     'res_model': 'mrp.production',
            //     'type': 'ir.actions.act_window',
            // }
            // if len(self.wip_production_ids) == 1:
            //     action.update({
            //         'view_mode': 'form',
            //         'res_id': self.wip_production_ids.id,
            //     })
            // else:
            //     action.update({
            //         'name': _("WIP MOs of %s", self.name),
            //         'domain': [('id', 'in', self.wip_production_ids.ids)],
            //         'view_mode': 'list,form',
            //     })
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, AccountMove entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def write(self, vals):
            // if not vals:
            //     return True
            // self._sanitize_vals(vals)
            // 
            // for move in self:
            //     violated_fields = set(vals).intersection(move._get_integrity_hash_fields() + ['inalterable_hash'])
            //     if move.inalterable_hash and violated_fields:
            //         raise UserError(_(
            //             "This document is protected by a hash. "
            //             "Therefore, you cannot edit the following fields: %s.",
            //             ', '.join(f['string'] for f in self.fields_get(violated_fields).values())
            //         ))
            //     if (
            //             move.posted_before
            //             and 'journal_id' in vals and move.journal_id.id != vals['journal_id']
            //             and not (move.name == '/' or not move.name or ('name' in vals and (vals['name'] == '/' or not vals['name'])))
            //     ):
            //         raise UserError(_('You cannot edit the journal of an account move if it has been posted once, unless the name is removed or set to "/". This might create a gap in the sequence.'))
            //     if (
            //             move.name and move.name != '/'
            //             and move.sequence_number not in (0, 1)
            //             and 'journal_id' in vals and move.journal_id.id != vals['journal_id']
            //             and not move.quick_edit_mode
            //             and not ('name' in vals and (vals['name'] == '/' or not vals['name']))
            //     ):
            //         raise UserError(_('You cannot edit the journal of an account move with a sequence number assigned, unless the name is removed or set to "/". This might create a gap in the sequence.'))
            // 
            //     # You can't change the date or name of a move being inside a locked period.
            //     if move.state == "posted" and (
            //             ('name' in vals and move.name != vals['name'])
            //             or ('date' in vals and move.date != vals['date'])
            //     ):
            //         move._check_fiscal_lock_dates()
            //         move.line_ids._check_tax_lock_date()
            // 
            //     # You can't post subtract a move to a locked period.
            //     if 'state' in vals and move.state == 'posted' and vals['state'] != 'posted':
            //         move._check_fiscal_lock_dates()
            //         move.line_ids._check_tax_lock_date()
            // 
            //     # Disallow modifying readonly fields on a posted move
            //     move_state = vals.get('state', move.state)
            //     unmodifiable_fields = (
            //         'invoice_line_ids', 'line_ids', 'invoice_date', 'date', 'partner_id',
            //         'invoice_payment_term_id', 'currency_id', 'fiscal_position_id', 'invoice_cash_rounding_id')
            //     readonly_fields = [val for val in vals if val in unmodifiable_fields]
            //     if not self._context.get('skip_readonly_check') and move_state == "posted" and readonly_fields:
            //         raise UserError(_("You cannot modify the following readonly fields on a posted move: %s", ', '.join(readonly_fields)))
            // 
            //     if move.journal_id.sequence_override_regex and vals.get('name') and vals['name'] != '/' and not re.match(move.journal_id.sequence_override_regex, vals['name']):
            //         if not self.env.user.has_group('account.group_account_manager'):
            //             raise UserError(_('The Journal Entry sequence is not conform to the current format. Only the Accountant can change it.'))
            //         move.journal_id.sequence_override_regex = False
            // 
            // if {'sequence_prefix', 'sequence_number', 'journal_id', 'name'} & vals.keys():
            //     self._set_next_made_sequence_gap(True)
            // 
            // stolen_moves = self.browse(set(move for move in self._stolen_move(vals)))
            // container = {'records': self | stolen_moves}
            // with self.env.protecting(self._get_protected_vals(vals, self)), self._check_balanced(container):
            //     with self._sync_dynamic_lines(container):
            //         if 'is_manually_modified' not in vals and not self.env.context.get('skip_is_manually_modified'):
            //             vals['is_manually_modified'] = True
            // 
            //         res = super(AccountMove, self.with_context(
            //             skip_account_move_synchronization=True,
            //         )).write(vals)
            // 
            //         # Reset the name of draft moves when changing the journal.
            //         # Protected against holes in the pre-validation checks.
            //         if 'journal_id' in vals and 'name' not in vals:
            //             draft_move = self.filtered(lambda m: not m.posted_before)
            //             draft_move.name = False
            //             draft_move._compute_name()
            // 
            //         # You can't change the date of a not-locked move to a locked period.
            //         # You can't post a new journal entry inside a locked period.
            //         if 'date' in vals or 'state' in vals:
            //             posted_move = self.filtered(lambda m: m.state == 'posted')
            //             posted_move._check_fiscal_lock_dates()
            //             posted_move.line_ids._check_tax_lock_date()
            // 
            //         if vals.get('state') == 'posted':
            //             self.flush_recordset()  # Ensure that the name is correctly computed
            //             self._hash_moves()
            // 
            //     self._synchronize_business_models(set(vals.keys()))
            // 
            //     # Apply the rounding on the Quick Edit mode only when adding a new line
            //     for move in self:
            //         if 'tax_totals' in vals:
            //             super(AccountMove, move).write({'tax_totals': vals['tax_totals']})
            // 
            // if any(field in vals for field in ['journal_id', 'currency_id']):
            //     self.line_ids._check_constrains_account_id_journal_id()
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: membership, FILE: account_move.py) ---
            // def write(self, vals):
            // # OVERRIDE to write the partner on the membership lines.
            // res = super(AccountMove, self).write(vals)
            // if 'partner_id' in vals:
            //     self.env['membership.membership_line'].search([
            //         ('account_invoice_line', 'in', self.mapped('invoice_line_ids').ids)
            //     ]).write({'partner': vals['partner_id']})
            // return res
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def write(self, vals):
            // # OVERRIDE
            // old_purchases = [move.mapped('line_ids.purchase_line_id.order_id') for move in self]
            // res = super(AccountMove, self).write(vals)
            // for i, move in enumerate(self):
            //     new_purchases = move.mapped('line_ids.purchase_line_id.order_id')
            //     if not new_purchases:
            //         continue
            //     diff_purchases = new_purchases - old_purchases[i]
            //     if diff_purchases:
            //         refs = [purchase._get_html_link() for purchase in diff_purchases]
            //         message = _("This vendor bill has been modified from: ") + Markup(',').join(refs)
            //         move.message_post(body=message)
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}