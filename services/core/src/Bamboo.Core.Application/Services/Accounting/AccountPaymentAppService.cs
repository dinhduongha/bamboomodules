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
    public class AccountPaymentAppService : GenericApplicationService<AccountPayment>, IAccountPaymentAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadMainAttachmentAppService _mailThreadMainAttachmentAppService;
        public AccountPaymentAppService(IRepository<AccountPayment, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadMainAttachmentAppService mailThreadMainAttachmentAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadMainAttachmentAppService = mailThreadMainAttachmentAppService;
        }

        protected async Task<AccountPayment> AutoInitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py) ---
            // def _auto_init(self):
            // """
            // Create compute stored field check_number
            // here to avoid MemoryError on large databases.
            // """
            // if not column_exists(self.env.cr, 'account_payment', 'check_number'):
            //     create_column(self.env.cr, 'account_payment', 'check_number', 'varchar')
            // 
            // return super()._auto_init()
            */
            return default;
        }

        public async Task<AccountPayment> ButtonOpenBillsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def button_open_bills(self):
            // ''' Redirect the user to the bill(s) paid by this payment.
            // :return:    An action on account.move.
            // '''
            // self.ensure_one()
            // 
            // action = {
            //     'name': _("Paid Bills"),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'account.move',
            //     'context': {'create': False},
            // }
            // if len(self.reconciled_bill_ids) == 1:
            //     action.update({
            //         'view_mode': 'form',
            //         'res_id': self.reconciled_bill_ids.id,
            //     })
            // else:
            //     action.update({
            //         'view_mode': 'list,form',
            //         'domain': [('id', 'in', self.reconciled_bill_ids.ids)],
            //     })
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountPayment> ButtonOpenInvoicesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def button_open_invoices(self):
            // ''' Redirect the user to the invoice(s) paid by this payment.
            // :return:    An action on account.move.
            // '''
            // self.ensure_one()
            // return (self.invoice_ids | self.reconciled_invoice_ids).with_context(
            //     create=False
            // )._get_records_action(
            //     name=_("Paid Invoices"),
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountPayment> ButtonOpenJournalEntryAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def button_open_journal_entry(self):
            // ''' Redirect the user to this payment journal.
            // :return:    An action on account.move.
            // '''
            // self.ensure_one()
            // return {
            //     'name': _("Journal Entry"),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'account.move',
            //     'context': {'create': False},
            //     'view_mode': 'form',
            //     'res_id': self.move_id.id,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountPayment> ButtonOpenStatementLinesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def button_open_statement_lines(self):
            // ''' Redirect the user to the statement line(s) reconciled to this payment.
            // :return:    An action on account.move.
            // '''
            // self.ensure_one()
            // 
            // action = {
            //     'name': _("Matched Transactions"),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'account.bank.statement.line',
            //     'context': {'create': False},
            // }
            // if len(self.reconciled_statement_line_ids) == 1:
            //     action.update({
            //         'view_mode': 'form',
            //         'res_id': self.reconciled_statement_line_ids.id,
            //     })
            // else:
            //     action.update({
            //         'view_mode': 'list,form',
            //         'domain': [('id', 'in', self.reconciled_statement_line_ids.ids)],
            //     })
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountPayment> ButtonRequestCancelAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def button_request_cancel(self):
            // return self.move_id.button_request_cancel()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountPayment> CancelAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def action_cancel(self):
            // self.state = 'canceled'
            // draft_moves = self.move_id.filtered(lambda m: m.state == 'draft')
            // draft_moves.unlink()
            // (self.move_id - draft_moves).button_cancel()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountPayment> CheckBuildPageInfoInternalAsync(object i, object p)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py) ---
            // def _check_build_page_info(self, i, p):
            // multi_stub = self.company_id.account_check_printing_multi_stub
            // return {
            //     'sequence_number': self.check_number,
            //     'manual_sequencing': self.journal_id.check_manual_sequencing,
            //     'date': format_date(self.env, self.date),
            //     'partner_id': self.partner_id,
            //     'partner_name': self.partner_id.name,
            //     'company': self.company_id.name,
            //     'currency': self.currency_id,
            //     'state': self.state,
            //     'amount': formatLang(self.env, self.amount, currency_obj=self.currency_id) if i == 0 else 'VOID',
            //     'amount_in_word': self._check_fill_line(self.check_amount_in_words) if i == 0 else 'VOID',
            //     'memo': self.memo,
            //     'stub_cropped': not multi_stub and len(self.move_id._get_reconciled_invoices()) > INV_LINES_PER_STUB,
            //     # If the payment does not reference an invoice, there is no stub line to display
            //     'stub_lines': p,
            // }
            */
            return default;
        }

        protected async Task<AccountPayment> CheckFillLineInternalAsync(object amount_str)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py) ---
            // def _check_fill_line(self, amount_str):
            // return amount_str and (amount_str + ' ').ljust(200, '*') or ''
            */
            return default;
        }

        protected async Task<AccountPayment> CheckGetPagesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py) ---
            // def _check_get_pages(self):
            // """ Returns the data structure used by the template: a list of dicts containing what to print on pages.
            // """
            // stub_pages = self._check_make_stub_pages() or [False]
            // pages = []
            // for i, p in enumerate(stub_pages):
            //     pages.append(self._check_build_page_info(i, p))
            // return pages
            */
            return default;
        }

        protected async Task<AccountPayment> CheckMakeStubPagesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py) ---
            // def _check_make_stub_pages(self):
            // """ The stub is the summary of paid invoices. It may spill on several pages, in which case only the check on
            //     first page is valid. This function returns a list of stub lines per page.
            // """
            // self.ensure_one()
            // 
            // def prepare_vals(invoice, partials=None, current_amount=0):
            //     invoice_name = invoice.name or '/'
            //     number = ' - '.join([invoice_name, invoice.ref] if invoice.ref else [invoice_name])
            // 
            //     if invoice.is_outbound() or invoice.move_type == 'in_receipt':
            //         invoice_sign = 1
            //         partial_field = 'debit_amount_currency'
            //     else:
            //         invoice_sign = -1
            //         partial_field = 'credit_amount_currency'
            // 
            //     amount_residual = invoice.amount_residual - current_amount
            //     if invoice.currency_id.is_zero(amount_residual):
            //         amount_residual_str = '-'
            //     else:
            //         amount_residual_str = formatLang(self.env, invoice_sign * amount_residual, currency_obj=invoice.currency_id)
            //     amount_paid = current_amount if current_amount else sum(partials.mapped(partial_field))
            // 
            //     return {
            //         'due_date': format_date(self.env, invoice.invoice_date_due),
            //         'number': number,
            //         'amount_total': formatLang(self.env, invoice_sign * invoice.amount_total, currency_obj=invoice.currency_id),
            //         'amount_residual': amount_residual_str,
            //         'amount_paid': formatLang(self.env, invoice_sign * amount_paid, currency_obj=self.currency_id),
            //         'currency': invoice.currency_id,
            //     }
            // 
            // if self.move_id:
            //     # Decode the reconciliation to keep only invoices.
            //     term_lines = self.move_id.line_ids.filtered(lambda line: line.account_id.account_type in ('asset_receivable', 'liability_payable'))
            //     invoices = (term_lines.matched_debit_ids.debit_move_id.move_id + term_lines.matched_credit_ids.credit_move_id.move_id)\
            //         .filtered(lambda x: x.is_outbound(include_receipts=True))
            // 
            //     # Group partials by invoices.
            //     invoice_map = {invoice: self.env['account.partial.reconcile'] for invoice in invoices}
            //     for partial in term_lines.matched_debit_ids:
            //         invoice = partial.debit_move_id.move_id
            //         if invoice in invoice_map:
            //             invoice_map[invoice] |= partial
            //     for partial in term_lines.matched_credit_ids:
            //         invoice = partial.credit_move_id.move_id
            //         if invoice in invoice_map:
            //             invoice_map[invoice] |= partial
            // else:
            //     invoices = self.invoice_ids.filtered(lambda x: x.is_outbound(include_receipts=True))
            //     remaining = self.amount
            // 
            // stub_lines = []
            // type_groups = {
            //     ('in_invoice', 'in_receipt'): _("Bills"),
            //     ('out_refund',): _("Refunds"),
            // }
            // invoices_grouped = invoices.grouped(lambda i: next(group for group in type_groups if i.move_type in group))
            // for type_group, invoices in invoices_grouped.items():
            //     invoices = iter(invoices.sorted(lambda x: x.invoice_date_due or x.date))
            //     if len(invoices_grouped) > 1:
            //         stub_lines += [{'header': True, 'name': type_groups[type_group]}]
            //     if self.move_id:
            //         stub_lines += [
            //             prepare_vals(invoice, partials=invoice_map[invoice])
            //             for invoice in invoices
            //         ]
            //     else:
            //         while remaining and (invoice := next(invoices, None)):
            //             current_amount = min(remaining, invoice.currency_id._convert(
            //                 from_amount=invoice.amount_residual,
            //                 to_currency=self.currency_id,
            //             ))
            //             stub_lines += [prepare_vals(invoice, current_amount=current_amount)]
            //             remaining -= current_amount
            // 
            // # Crop the stub lines or split them on multiple pages
            // if not self.company_id.account_check_printing_multi_stub:
            //     # If we need to crop the stub, leave place for an ellipsis line
            //     num_stub_lines = len(stub_lines) > INV_LINES_PER_STUB and INV_LINES_PER_STUB - 1 or INV_LINES_PER_STUB
            //     stub_pages = [stub_lines[:num_stub_lines]]
            // else:
            //     stub_pages = []
            //     i = 0
            //     while i < len(stub_lines):
            //         # Make sure we don't start the credit section at the end of a page
            //         if len(stub_lines) >= i + INV_LINES_PER_STUB and stub_lines[i + INV_LINES_PER_STUB - 1].get('header'):
            //             num_stub_lines = INV_LINES_PER_STUB - 1 or INV_LINES_PER_STUB
            //         else:
            //             num_stub_lines = INV_LINES_PER_STUB
            //         stub_pages.append(stub_lines[i:i + num_stub_lines])
            //         i += num_stub_lines
            // 
            // return stub_pages
            */
            return default;
        }

        protected async Task<AccountPayment> CheckMoveIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _check_move_id(self):
            // for payment in self:
            //     if (
            //         payment.state not in ('draft', 'canceled')
            //         and not payment.move_id
            //         and payment.outstanding_account_id
            //     ):
            //         raise ValidationError(_("A payment with an outstanding account cannot be confirmed without having a journal entry."))
            */
            return default;
        }

        protected async Task<AccountPayment> CheckPaymentMethodLineIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _check_payment_method_line_id(self):
            // ''' Ensure the 'payment_method_line_id' field is not null.
            // Can't be done using the regular 'required=True' because the field is a computed editable stored one.
            // '''
            // for pay in self:
            //     if not pay.payment_method_line_id:
            //         raise ValidationError(_("Please define a payment method line on your payment."))
            //     elif pay.payment_method_line_id.journal_id and pay.payment_method_line_id.journal_id != pay.journal_id:
            //         raise ValidationError(_("The selected payment method is not available for this payment, please select the payment method again."))
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeAmountAvailableForRefundInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: account_payment.py) ---
            // def _compute_amount_available_for_refund(self):
            // for payment in self:
            //     tx_sudo = payment.payment_transaction_id.sudo()
            //     payment_method = (
            //         tx_sudo.payment_method_id.primary_payment_method_id
            //         or tx_sudo.payment_method_id
            //     )
            //     if (
            //         tx_sudo  # The payment was created by a transaction.
            //         and tx_sudo.provider_id.support_refund != 'none'
            //         and payment_method.support_refund != 'none'
            //         and tx_sudo.operation != 'refund'
            //     ):
            //         # Only consider refund transactions that are confirmed by summing the amounts of
            //         # payments linked to such refund transactions. Indeed, should a refund transaction
            //         # be stuck forever in a transient state (due to webhook failure, for example), the
            //         # user would never be allowed to refund the source transaction again.
            //         refund_payments = self.search([('source_payment_id', '=', payment.id)])
            //         refunded_amount = abs(sum(refund_payments.mapped('amount')))
            //         payment.amount_available_for_refund = payment.amount - refunded_amount
            //     else:
            //         payment.amount_available_for_refund = 0
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeAmountCompanyCurrencySignedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_amount_company_currency_signed(self):
            // for payment in self:
            //     if payment.move_id:
            //         liquidity_lines = payment._seek_for_lines()[0]
            //         payment.amount_company_currency_signed = sum(liquidity_lines.mapped('balance'))
            //     else:
            //         payment.amount_company_currency_signed = payment.currency_id._convert(
            //             from_amount=payment.amount_signed,
            //             to_currency=payment.company_currency_id,
            //             company=payment.company_id,
            //             date=payment.date,
            //         )
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeAmountSignedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_amount_signed(self):
            // for payment in self:
            //     if payment.payment_type == 'outbound':
            //         payment.amount_signed = -payment.amount
            //     else:
            //         payment.amount_signed = payment.amount
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeAvailableJournalIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_available_journal_ids(self):
            // """
            // Get all journals having at least one payment method for inbound/outbound depending on the payment_type.
            // """
            // journals = self.env['account.journal'].search([
            //     '|',
            //     ('company_id', 'parent_of', self.env.company.id),
            //     ('company_id', 'child_of', self.env.company.id),
            //     ('type', 'in', ('bank', 'cash', 'credit')),
            // ])
            // for pay in self:
            //     if pay.payment_type == 'inbound':
            //         pay.available_journal_ids = journals.filtered('inbound_payment_method_line_ids')
            //     else:
            //         pay.available_journal_ids = journals.filtered('outbound_payment_method_line_ids')
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeAvailablePartnerBankIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_available_partner_bank_ids(self):
            // for pay in self:
            //     if pay.payment_type == 'inbound':
            //         pay.available_partner_bank_ids = pay.journal_id.bank_account_id
            //     else:
            //         pay.available_partner_bank_ids = pay.partner_id.bank_ids\
            //                 .filtered(lambda x: x.company_id.id in (False, pay.company_id.id))._origin
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeCheckAmountInWordsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py) ---
            // def _compute_check_amount_in_words(self):
            // for pay in self:
            //     if pay.currency_id:
            //         pay.check_amount_in_words = pay.currency_id.amount_to_text(pay.amount)
            //     else:
            //         pay.check_amount_in_words = False
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeCheckNumberInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py) ---
            // def _compute_check_number(self):
            // for pay in self:
            //     if pay.journal_id.check_manual_sequencing and pay.payment_method_code == 'check_printing':
            //         sequence = pay.journal_id.check_sequence_id
            //         pay.check_number = sequence.get_next_char(sequence.number_next_actual)
            //     else:
            //         pay.check_number = False
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeCompanyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_company_id(self):
            // for payment in self:
            //     if payment.journal_id.company_id not in payment.company_id.parent_ids:
            //         payment.company_id = (payment.journal_id.company_id or self.env.company)._accessible_branches()[:1]
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeCurrencyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_currency_id(self):
            // for pay in self:
            //     pay.currency_id = pay.journal_id.currency_id or pay.journal_id.company_id.currency_id
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeDestinationAccountIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_destination_account_id(self):
            // self.destination_account_id = False
            // for pay in self:
            //     if pay.partner_type == 'customer':
            //         # Receive money from invoice or send money to refund it.
            //         if pay.partner_id:
            //             pay.destination_account_id = pay.partner_id.with_company(pay.company_id).property_account_receivable_id
            //         else:
            //             pay.destination_account_id = self.env['account.account'].with_company(pay.company_id).search([
            //                 *self.env['account.account']._check_company_domain(pay.company_id),
            //                 ('account_type', '=', 'asset_receivable'),
            //                 ('deprecated', '=', False),
            //             ], limit=1)
            //     elif pay.partner_type == 'supplier':
            //         # Send money to pay a bill or receive money to refund it.
            //         if pay.partner_id:
            //             pay.destination_account_id = pay.partner_id.with_company(pay.company_id).property_account_payable_id
            //         else:
            //             pay.destination_account_id = self.env['account.account'].with_company(pay.company_id).search([
            //                 *self.env['account.account']._check_company_domain(pay.company_id),
            //                 ('account_type', '=', 'liability_payable'),
            //                 ('deprecated', '=', False),
            //             ], limit=1)
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_display_name(self):
            // for payment in self:
            //     payment.display_name = payment.name or _('Draft Payment')
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeDuplicatePaymentIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_duplicate_payment_ids(self):
            // """ Retrieve move ids with same partner_id, amount and date as the current payment """
            // payment_to_duplicate_move = self._fetch_duplicate_reference()
            // for payment in self:
            //     # Uses payment._origin.id to handle records in edition/existing records and 0 for new records
            //     payment.duplicate_payment_ids = payment_to_duplicate_move.get(payment._origin.id, self.env['account.payment'])
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeJournalIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_journal_id(self):
            // for payment in self:
            //     # default customer payment method logic
            //     partner = payment.partner_id
            //     payment_type = payment.payment_type if payment.payment_type in ('inbound', 'outbound') else None
            //     if not bool(payment._origin) and (partner or payment_type):
            //         field_name = f'property_{payment_type}_payment_method_line_id'
            //         default_payment_method_line = payment.partner_id.with_company(payment.company_id)[field_name]
            //         journal = default_payment_method_line.journal_id
            //         if journal:
            //             payment.journal_id = journal
            //             continue
            // 
            //     company = payment.company_id or self.env.company
            //     if not payment.journal_id or company != payment.journal_id.company_id:
            //         payment.journal_id = self.env['account.journal'].search([
            //             *self.env['account.journal']._check_company_domain(company),
            //             ('type', 'in', ['bank', 'cash', 'credit']),
            //         ], limit=1)
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_name(self):
            // for payment in self:
            //     if payment.id and (not payment.name or payment.move_id and payment.name != payment.move_id.name) and payment.state in ('in_process', 'paid'):
            //         payment.name = (
            //             payment.move_id.name
            //             or self.env['ir.sequence'].with_company(payment.company_id).next_by_code(
            //                 'account.payment',
            //                 sequence_date=payment.date,
            //             )
            //         )
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeOutstandingAccountIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_outstanding_account_id(self):
            // for pay in self:
            //     pay.outstanding_account_id = pay.payment_method_line_id.payment_account_id
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: account_payment.py) ---
            // def _compute_outstanding_account_id(self):
            // # EXTENDS account
            // expense_company_payments = self.filtered(lambda payment: payment.expense_sheet_id.payment_mode == 'company_account')
            // for payment in expense_company_payments:
            //     payment.outstanding_account_id = payment.expense_sheet_id._get_expense_account_destination()
            // super(AccountPayment, self - expense_company_payments)._compute_outstanding_account_id()
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: account_payment.py) ---
            // def _compute_outstanding_account_id(self):
            // """When force_outstanding_account_id is set, we use it as the outstanding_account_id."""
            // super()._compute_outstanding_account_id()
            // for payment in self:
            //     if payment.force_outstanding_account_id:
            //         payment.outstanding_account_id = payment.force_outstanding_account_id
            */
            return default;
        }

        protected async Task<AccountPayment> ComputePartnerBankIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_partner_bank_id(self):
            // ''' The default partner_bank_id will be the first available on the partner. '''
            // for pay in self:
            //     if pay.partner_bank_id not in pay.available_partner_bank_ids:
            //         pay.partner_bank_id = pay.available_partner_bank_ids[:1]._origin
            */
            return default;
        }

        protected async Task<AccountPayment> ComputePartnerIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_partner_id(self):
            // for pay in self:
            //     if pay.partner_id == pay.journal_id.company_id.partner_id:
            //         pay.partner_id = False
            //     else:
            //         pay.partner_id = pay.partner_id
            */
            return default;
        }

        protected async Task<AccountPayment> ComputePaymentMethodLineFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_payment_method_line_fields(self):
            // for pay in self:
            //     pay.available_payment_method_line_ids = pay.journal_id._get_available_payment_method_lines(pay.payment_type)
            //     to_exclude = pay._get_payment_method_codes_to_exclude()
            //     if to_exclude:
            //         pay.available_payment_method_line_ids = pay.available_payment_method_line_ids.filtered(lambda x: x.code not in to_exclude)
            */
            return default;
        }

        protected async Task<AccountPayment> ComputePaymentMethodLineIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_payment_method_line_id(self):
            // ''' Compute the 'payment_method_line_id' field.
            // This field is not computed in '_compute_payment_method_line_fields' because it's a stored editable one.
            // '''
            // for pay in self:
            //     available_payment_method_lines = pay.available_payment_method_line_ids
            //     inbound_payment_method = pay.partner_id.property_inbound_payment_method_line_id
            //     outbound_payment_method = pay.partner_id.property_outbound_payment_method_line_id
            //     if pay.payment_type == 'inbound' and inbound_payment_method.id in available_payment_method_lines.ids:
            //         pay.payment_method_line_id = inbound_payment_method
            //     elif pay.payment_type == 'outbound' and outbound_payment_method.id in available_payment_method_lines.ids:
            //         pay.payment_method_line_id = outbound_payment_method
            //     elif pay.payment_method_line_id.id in available_payment_method_lines.ids:
            //         pay.payment_method_line_id = pay.payment_method_line_id
            //     elif available_payment_method_lines:
            //         pay.payment_method_line_id = available_payment_method_lines[0]._origin
            //     else:
            //         pay.payment_method_line_id = False
            */
            return default;
        }

        protected async Task<AccountPayment> ComputePaymentReceiptTitleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_payment_receipt_title(self):
            // """ To override in order to change the title displayed on the payment receipt report """
            // self.payment_receipt_title = _('Payment Receipt')
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeQrCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_qr_code(self):
            // for pay in self:
            //     if pay.state in ('draft', 'in_process') \
            //         and pay.partner_bank_id \
            //         and pay.partner_bank_id.allow_out_payment \
            //         and pay.payment_method_line_id.code == 'manual' \
            //         and pay.payment_type == 'outbound' \
            //         and pay.currency_id:
            // 
            //         if pay.partner_bank_id:
            //             qr_code = pay.partner_bank_id.build_qr_code_base64(pay.amount, pay.memo, pay.memo, pay.currency_id, pay.partner_id)
            //         else:
            //             qr_code = None
            // 
            //         if qr_code:
            //             pay.qr_code = '''
            //                 <br/>
            //                 <img class="border border-dark rounded" src="{qr_code}"/>
            //                 <br/>
            //                 <strong class="text-center">{txt}</strong>
            //                 '''.format(txt = _('Scan me with your banking app.'),
            //                            qr_code = qr_code)
            //             continue
            // 
            //     pay.qr_code = None
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeReconciliationStatusInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_reconciliation_status(self):
            // ''' Compute the field indicating if the payments are already reconciled with something.
            // This field is used for display purpose (e.g. display the 'reconcile' button redirecting to the reconciliation
            // widget).
            // '''
            // for pay in self:
            //     liquidity_lines, counterpart_lines, writeoff_lines = pay._seek_for_lines()
            // 
            //     if not pay.outstanding_account_id:
            //         pay.is_reconciled = False
            //         pay.is_matched = pay.state == 'paid'
            //     elif not pay.currency_id or not pay.id or not pay.move_id:
            //         pay.is_reconciled = False
            //         pay.is_matched = False
            //     elif pay.currency_id.is_zero(pay.amount):
            //         pay.is_reconciled = True
            //         pay.is_matched = True
            //     else:
            //         residual_field = 'amount_residual' if pay.currency_id == pay.company_id.currency_id else 'amount_residual_currency'
            //         if pay.journal_id.default_account_id and pay.journal_id.default_account_id in liquidity_lines.account_id:
            //             # Allow user managing payments without any statement lines by using the bank account directly.
            //             # In that case, the user manages transactions only using the register payment wizard.
            //             pay.is_matched = True
            //         else:
            //             pay.is_matched = pay.currency_id.is_zero(sum(liquidity_lines.mapped(residual_field)))
            // 
            //         reconcile_lines = (counterpart_lines + writeoff_lines).filtered(lambda line: line.account_id.reconcile)
            //         pay.is_reconciled = pay.currency_id.is_zero(sum(reconcile_lines.mapped(residual_field)))
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeRefundsCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: account_payment.py) ---
            // def _compute_refunds_count(self):
            // rg_data = self.env['account.payment']._read_group(
            //     domain=[
            //         ('source_payment_id', 'in', self.ids),
            //         ('payment_transaction_id.operation', '=', 'refund')
            //     ],
            //     groupby=['source_payment_id'],
            //     aggregates=['__count']
            // )
            // data = {source_payment.id: count for source_payment, count in rg_data}
            // for payment in self:
            //     payment.refunds_count = data.get(payment.id, 0)
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeShowCheckNumberInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py) ---
            // def _compute_show_check_number(self):
            // for payment in self:
            //     payment.show_check_number = (
            //         payment.payment_method_line_id.code == 'check_printing'
            //         and payment.check_number
            //     )
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeShowRequirePartnerBankInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_show_require_partner_bank(self):
            // """ Computes if the destination bank account must be displayed in the payment form view. By default, it
            // won't be displayed but some modules might change that, depending on the payment type."""
            // for payment in self:
            //     if payment.journal_id.type == 'cash':
            //         payment.show_partner_bank_account = False
            //     else:
            //         payment.show_partner_bank_account = payment.payment_method_code in self._get_method_codes_using_bank_account()
            //     payment.require_partner_bank_account = payment.state == 'draft' and payment.payment_method_code in self._get_method_codes_needing_bank_account()
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeStatButtonsFromReconciliationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_stat_buttons_from_reconciliation(self):
            // ''' Retrieve the invoices reconciled to the payments through the reconciliation (account.partial.reconcile). '''
            // stored_payments = self.filtered('id')
            // if not stored_payments:
            //     self.reconciled_invoice_ids = False
            //     self.reconciled_invoices_count = 0
            //     self.reconciled_invoices_type = False
            //     self.reconciled_bill_ids = False
            //     self.reconciled_bills_count = 0
            //     self.reconciled_statement_line_ids = False
            //     self.reconciled_statement_lines_count = 0
            //     return
            // 
            // self.env['account.payment'].flush_model(fnames=['move_id', 'outstanding_account_id'])
            // self.env['account.move'].flush_model(fnames=['move_type', 'origin_payment_id', 'statement_line_id'])
            // self.env['account.move.line'].flush_model(fnames=['move_id', 'account_id', 'statement_line_id'])
            // self.env['account.partial.reconcile'].flush_model(fnames=['debit_move_id', 'credit_move_id'])
            // 
            // self._cr.execute('''
            //     SELECT
            //         payment.id,
            //         ARRAY_AGG(DISTINCT invoice.id) AS invoice_ids,
            //         invoice.move_type
            //     FROM account_payment payment
            //     JOIN account_move move ON move.id = payment.move_id
            //     JOIN account_move_line line ON line.move_id = move.id
            //     JOIN account_partial_reconcile part ON
            //         part.debit_move_id = line.id
            //         OR
            //         part.credit_move_id = line.id
            //     JOIN account_move_line counterpart_line ON
            //         part.debit_move_id = counterpart_line.id
            //         OR
            //         part.credit_move_id = counterpart_line.id
            //     JOIN account_move invoice ON invoice.id = counterpart_line.move_id
            //     JOIN account_account account ON account.id = line.account_id
            //     WHERE account.account_type IN ('asset_receivable', 'liability_payable')
            //         AND payment.id IN %(payment_ids)s
            //         AND line.id != counterpart_line.id
            //         AND invoice.move_type in ('out_invoice', 'out_refund', 'in_invoice', 'in_refund', 'out_receipt', 'in_receipt')
            //     GROUP BY payment.id, invoice.move_type
            // ''', {
            //     'payment_ids': tuple(stored_payments.ids)
            // })
            // query_res = self._cr.dictfetchall()
            // 
            // for pay in self:
            //     pay.reconciled_invoice_ids = pay.invoice_ids.filtered(lambda m: m.is_sale_document(True))
            //     pay.reconciled_bill_ids = pay.invoice_ids.filtered(lambda m: m.is_purchase_document(True))
            // 
            // for res in query_res:
            //     pay = self.browse(res['id'])
            //     if res['move_type'] in self.env['account.move'].get_sale_types(True):
            //         pay.reconciled_invoice_ids |= self.env['account.move'].browse(res.get('invoice_ids', []))
            //     else:
            //         pay.reconciled_bill_ids |= self.env['account.move'].browse(res.get('invoice_ids', []))
            // 
            // for pay in self:
            //     pay.reconciled_invoices_count = len(pay.reconciled_invoice_ids)
            //     pay.reconciled_bills_count = len(pay.reconciled_bill_ids)
            // 
            // self._cr.execute('''
            //     SELECT
            //         payment.id,
            //         ARRAY_AGG(DISTINCT counterpart_line.statement_line_id) AS statement_line_ids
            //     FROM account_payment payment
            //     JOIN account_move move ON move.id = payment.move_id
            //     JOIN account_move_line line ON line.move_id = move.id
            //     JOIN account_account account ON account.id = line.account_id
            //     JOIN account_partial_reconcile part ON
            //         part.debit_move_id = line.id
            //         OR
            //         part.credit_move_id = line.id
            //     JOIN account_move_line counterpart_line ON
            //         part.debit_move_id = counterpart_line.id
            //         OR
            //         part.credit_move_id = counterpart_line.id
            //     WHERE account.id = payment.outstanding_account_id
            //         AND payment.id IN %(payment_ids)s
            //         AND line.id != counterpart_line.id
            //         AND counterpart_line.statement_line_id IS NOT NULL
            //     GROUP BY payment.id
            // ''', {
            //     'payment_ids': tuple(stored_payments.ids)
            // })
            // query_res = dict((payment_id, statement_line_ids) for payment_id, statement_line_ids in self._cr.fetchall())
            // 
            // for pay in self:
            //     statement_line_ids = query_res.get(pay.id, [])
            //     pay.reconciled_statement_line_ids = [Command.set(statement_line_ids)]
            //     pay.reconciled_statement_lines_count = len(statement_line_ids)
            //     if len(pay.reconciled_invoice_ids.mapped('move_type')) == 1 and pay.reconciled_invoice_ids[0].move_type == 'out_refund':
            //         pay.reconciled_invoices_type = 'credit_note'
            //     else:
            //         pay.reconciled_invoices_type = 'invoice'
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_state(self):
            // for payment in self:
            //     if not payment.state:
            //         payment.state = 'draft'
            //     # in_process --> paid
            //     if (move := payment.move_id) and payment.state in ('paid', 'in_process'):
            //         liquidity, _counterpart, _writeoff = payment._seek_for_lines()
            //         payment.state = (
            //             'paid'
            //             if move.company_currency_id.is_zero(sum(liquidity.mapped('amount_residual'))) or not any(liquidity.account_id.mapped('reconcile')) else
            //             'in_process'
            //         )
            //     if payment.state == 'in_process' and payment.invoice_ids and all(invoice.payment_state == 'paid' for invoice in payment.invoice_ids):
            //         payment.state = 'paid'
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeSuitablePaymentTokenIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: account_payment.py) ---
            // def _compute_suitable_payment_token_ids(self):
            // for payment in self:
            //     if payment.use_electronic_payment_method:
            //         payment.suitable_payment_token_ids = self.env['payment.token'].sudo().search([
            //             *self.env['payment.token']._check_company_domain(payment.company_id),
            //             ('provider_id.capture_manually', '=', False),
            //             ('partner_id', '=', payment.partner_id.id),
            //             ('provider_id', '=', payment.payment_method_line_id.payment_provider_id.id),
            //         ])
            //     else:
            //         payment.suitable_payment_token_ids = [Command.clear()]
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeUseElectronicPaymentMethodInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: account_payment.py) ---
            // def _compute_use_electronic_payment_method(self):
            // for payment in self:
            //     # Get a list of all electronic payment method codes.
            //     # These codes are comprised of 'electronic' and the providers of each payment provider.
            //     codes = [key for key in dict(self.env['payment.provider']._fields['code']._description_selection(self.env))]
            //     payment.use_electronic_payment_method = payment.payment_method_code in codes
            */
            return default;
        }

        protected async Task<AccountPayment> ConstrainsCheckNumberInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py) ---
            // def _constrains_check_number(self):
            // for payment_check in self.filtered('check_number'):
            //     if not payment_check.check_number.isdecimal():
            //         raise ValidationError(_('Check numbers can only consist of digits'))
            */
            return default;
        }

        protected async Task<AccountPayment> ConstrainsCheckNumberUniqueInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py) ---
            // def _constrains_check_number_unique(self):
            // payment_checks = self.filtered('check_number')
            // if not payment_checks:
            //     return
            // self.env.flush_all()
            // self.env.cr.execute("""
            //     SELECT payment.check_number, move.journal_id
            //       FROM account_payment payment
            //       JOIN account_move move ON move.id = payment.move_id
            //       JOIN account_journal journal ON journal.id = move.journal_id,
            //            account_payment other_payment
            //       JOIN account_move other_move ON other_move.id = other_payment.move_id
            //      WHERE payment.check_number::BIGINT = other_payment.check_number::BIGINT
            //        AND move.journal_id = other_move.journal_id
            //        AND payment.id != other_payment.id
            //        AND payment.id IN %(ids)s
            //        AND move.state = 'posted'
            //        AND other_move.state = 'posted'
            //        AND payment.check_number IS NOT NULL
            //        AND other_payment.check_number IS NOT NULL
            // """, {
            //     'ids': tuple(payment_checks.ids),
            // })
            // res = self.env.cr.dictfetchall()
            // if res:
            //     raise ValidationError(_(
            //         'The following numbers are already used:\n%s',
            //         '\n'.join(_(
            //             '%(number)s in journal %(journal)s',
            //             number=r['check_number'],
            //             journal=self.env['account.journal'].browse(r['journal_id']).display_name,
            //         ) for r in res)
            //     ))
            */
            return default;
        }

        public async Task<AccountPayment> CopyDataAsync(Guid id, AccountPaymentCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default)
            // for payment, vals in zip(self, vals_list):
            //     vals.update({
            //         'journal_id': payment.journal_id.id,
            //         'payment_method_line_id': payment.payment_method_line_id.id,
            //         **(vals or {}),
            //     })
            // return vals_list
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountPayment> CreatePaymentTransactionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: account_payment.py) ---
            // def _create_payment_transaction(self, **extra_create_values):
            // for payment in self:
            //     if payment.payment_transaction_id:
            //         raise ValidationError(_(
            //             "A payment transaction with reference %s already exists.",
            //             payment.payment_transaction_id.reference
            //         ))
            //     elif not payment.payment_token_id:
            //         raise ValidationError(_("A token is required to create a new payment transaction."))
            // 
            // transactions = self.env['payment.transaction']
            // for payment in self:
            //     transaction_vals = payment._prepare_payment_transaction_vals(**extra_create_values)
            //     transaction = self.env['payment.transaction'].create(transaction_vals)
            //     transactions += transaction
            //     payment.payment_transaction_id = transaction  # Link the transaction to the payment
            // return transactions
            */
            return default;
        }

        protected async Task<AccountPayment> CreationMessageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: account_payment.py) ---
            // def _creation_message(self):
            // # EXTENDS mail
            // self.ensure_one()
            // if self.move_id.expense_sheet_id:
            //     return _("Payment created for: %s", self.move_id.expense_sheet_id._get_html_link())
            // return super()._creation_message()
            */
            return default;
        }

        public async Task<AccountPayment> DoPrintChecksAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py) ---
            // def do_print_checks(self):
            // check_layout = self.journal_id.bank_check_printing_layout or self.company_id.account_check_printing_layout
            // redirect_action = self.env.ref('account.action_account_config')
            // if not check_layout or check_layout == 'disabled':
            //     msg = _("You have to choose a check layout. For this, go in Invoicing/Accounting Settings, search for 'Checks layout' and set one.")
            //     raise RedirectWarning(msg, redirect_action.id, _('Go to the configuration panel'))
            // report_action = self.env.ref(check_layout, False)
            // if not report_action:
            //     msg = _("Something went wrong with Check Layout, please select another layout in Invoicing/Accounting Settings and try again.")
            //     raise RedirectWarning(msg, redirect_action.id, _('Go to the configuration panel'))
            // self.write({'is_sent': 'True'})
            // return report_action.report_action(self)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountPayment> DraftAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def action_draft(self):
            // self.state = 'draft'
            // self.move_id.button_draft()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountPayment> FetchDuplicateReferenceInternalAsync(object matching_states)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _fetch_duplicate_reference(self, matching_states=('draft', 'in_process')):
            // """ Retrieve move ids for possible duplicates of payments. Duplicates moves:
            // - Have the same partner_id, amount and date as the payment
            // - Are not reconciled
            // - Represent a credit in the same account receivable or a debit in the same account payable as the payment, or
            // - Represent a credit in outstanding receipts or debit in outstanding payments, so bank statement lines with an
            //  outstanding counterpart can be matched, or
            // - Are in the suspense account
            // """
            // # Does not perform unnecessary check if partner_id or amount are not set, nor if payment is posted
            // payments = self.filtered(lambda p: p.partner_id and p.amount and p.state != 'in_process')
            // if not payments:
            //     return {}
            // 
            // # Update tables involved in the query
            // used_fields = ("company_id", "partner_id", "date", "state", "amount", 'payment_type')
            // self.flush_model(used_fields)
            // 
            // payment_table_and_alias = SQL("account_payment AS payment")
            // if not self[0].id:  # if record is under creation/edition in UI, safely inject values in the query
            //     # Necessary since new record aren't searchable in the DB and record in edition aren't up to date yet
            //     values = {
            //         field_name: self._fields[field_name].convert_to_write(self[field_name], self) or None
            //         for field_name in used_fields
            //     }
            //     values["id"] = self._origin.id or 0
            //     # The amount total depends on the field line_ids and is calculated upon saving, we needed a way to get it even when the
            //     # invoices has not been saved yet.
            //     casted_values = SQL(', ').join(
            //         SQL("%s::%s", value, SQL.identifier(self._fields[field_name].column_type[0]))
            //         for field_name, value in values.items()
            //     )
            //     column_names = SQL(', ').join(SQL.identifier(field_name) for field_name in values)
            //     payment_table_and_alias = SQL("(VALUES (%s)) AS payment(%s)", casted_values, column_names)
            // 
            // query = SQL(
            //     """
            //         SELECT payment.id AS payment_id,
            //                ARRAY_AGG(DISTINCT duplicate_payment.id) AS duplicate_payment_ids
            //           FROM %(payment_table_and_alias)s
            //           JOIN account_payment AS duplicate_payment ON payment.id != duplicate_payment.id
            //                                                    AND payment.partner_id = duplicate_payment.partner_id
            //                                                    AND payment.company_id = duplicate_payment.company_id
            //                                                    AND payment.date = duplicate_payment.date
            //                                                    AND payment.payment_type = duplicate_payment.payment_type
            //                                                    AND payment.amount = duplicate_payment.amount
            //                                                    AND duplicate_payment.state IN %(matching_states)s
            //          WHERE payment.id = ANY(%(payments)s)
            //       GROUP BY payment.id
            //     """,
            //     payment_table_and_alias=payment_table_and_alias,
            //     matching_states=tuple(matching_states),
            //     payments=payments.ids or [0],
            // )
            // 
            // return {
            //     payment_id: self.env['account.payment'].browse(duplicate_ids)
            //     for payment_id, duplicate_ids in self.env.execute_query(query)
            // }
            */
            return default;
        }

        public override async Task<Dictionary<string, Dictionary<string, object>>> FieldsGetAsync(List<string> fields = null, Dictionary<string, List<string>> attributes = null)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py) ---
            // def fields_get(self, allfields=None, attributes=None):
            // result = super().fields_get(allfields, attributes)
            // # pretend the field 'check_number' to be readonly
            // field_desc = result.get('check_number') or {}
            // if 'readonly' in field_desc:
            //     field_desc['readonly'] = True
            // return result
            */
            return await base.FieldsGetAsync(fields, attributes);
        }

        protected async Task<AccountPayment> GenerateJournalEntryInternalAsync(object write_off_line_vals, object force_balance, List<Guid> line_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _generate_journal_entry(self, write_off_line_vals=None, force_balance=None, line_ids=None):
            // need_move = self.filtered(lambda p: not p.move_id and p.outstanding_account_id)
            // assert len(self) == 1 or (not write_off_line_vals and not force_balance and not line_ids)
            // 
            // move_vals = [
            //     pay._generate_move_vals(write_off_line_vals, force_balance, line_ids)
            //     for pay in need_move
            // ]
            // moves = self.env['account.move'].create(move_vals)
            // for pay, move in zip(need_move, moves):
            //     pay.write({'move_id': move.id, 'state': 'in_process'})
            */
            return default;
        }

        protected async Task<AccountPayment> GenerateMoveValsInternalAsync(object write_off_line_vals, object force_balance, List<Guid> line_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _generate_move_vals(self, write_off_line_vals=None, force_balance=None, line_ids=None):
            // """ Prepare the values needed to create a move for self. """
            // self.ensure_one()
            // return {
            //     'move_type': 'entry',
            //     'ref': self.memo,
            //     'date': self.date,
            //     'journal_id': self.journal_id.id,
            //     'company_id': self.company_id.id,
            //     'partner_id': self.partner_id.id,
            //     'currency_id': self.currency_id.id,
            //     'partner_bank_id': self.partner_bank_id.id,
            //     'line_ids': line_ids or [
            //         Command.create(line_vals)
            //         for line_vals in self._prepare_move_line_default_vals(
            //             write_off_line_vals=write_off_line_vals,
            //             force_balance=force_balance,
            //         )
            //     ],
            //     'origin_payment_id': self.id,
            // }
            */
            return default;
        }

        protected async Task<AccountPayment> GetAmlDefaultDisplayNameListInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _get_aml_default_display_name_list(self):
            // """ Hook allowing custom values when constructing the default label to set on the journal items.
            // 
            // :return: A list of terms to concatenate all together. E.g.
            //     [
            //         ('label', "Greg's Card"),
            //         ('sep', ": "),
            //         ('memo', "New Computer"),
            //     ]
            // """
            // self.ensure_one()
            // label = self.payment_method_line_id.name if self.payment_method_line_id else _("No Payment Method")
            // 
            // if self.memo:
            //     return [
            //         ('label', label),
            //         ('sep', ": "),
            //         ('memo', self.memo),
            //     ]
            // return [
            //     ('label', label),
            // ]
            --- ODOO METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py) ---
            // def _get_aml_default_display_name_list(self):
            // # Extends 'account'
            // self.ensure_one()
            // 
            // if not self.check_number:
            //     return super()._get_aml_default_display_name_list()
            // 
            // result = [
            //     ('label', _("Checks")),
            //     ('sep', ' - '),
            //     ('check_number', self.check_number),
            // ]
            // 
            // if self.memo:
            //     result += [
            //         ('sep', ': '),
            //         ('memo', self.memo),
            //     ]
            // 
            // return result
            */
            return default;
        }

        protected async Task<AccountPayment> GetMethodCodesNeedingBankAccountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _get_method_codes_needing_bank_account(self):
            // return []
            */
            return default;
        }

        protected async Task<AccountPayment> GetMethodCodesUsingBankAccountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _get_method_codes_using_bank_account(self):
            // return ['manual']
            */
            return default;
        }

        protected async Task<AccountPayment> GetOutstandingAccountInternalAsync(object payment_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _get_outstanding_account(self, payment_type):
            // account_ref = 'account_journal_payment_debit_account_id' if payment_type == 'inbound' else 'account_journal_payment_credit_account_id'
            // chart_template = self.with_context(allowed_company_ids=self.company_id.root_id.ids).env['account.chart.template']
            // outstanding_account = (
            //     chart_template.ref(account_ref, raise_if_not_found=False)
            //     or self.company_id.transfer_account_id
            // )
            // if not outstanding_account:
            //     raise UserError(_("No outstanding account could be found to make the payment"))
            // return outstanding_account
            */
            return default;
        }

        protected async Task<AccountPayment> GetPaymentMethodCodesToExcludeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _get_payment_method_codes_to_exclude(self):
            // # can be overriden to exclude payment methods based on the payment characteristics
            // self.ensure_one()
            // return []
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: account_payment.py) ---
            // def _get_payment_method_codes_to_exclude(self):
            // res = super()._get_payment_method_codes_to_exclude()
            // 
            // # Sepa Credit Transfer is an outgoing payment method. It requires a partner and bank
            // # account. In the context of PoS orders, you can make refunds that are not linked to
            // # a specific customer. We ensure that account.payment are not created using the sepa_ct
            // # account.payment.method.line. If not, closing the session would not be possible unless
            // # having an account.payment.method.line with a smaller sequence than sepa_ct.
            // account_sepa = self.env['ir.module.module'].search([('name', '=', 'account_iso20022')])
            // if account_sepa.state == 'installed':
            //     sepa_ct = self.env.ref('account_iso20022.account_payment_method_sepa_ct', raise_if_not_found=False)
            //     if sepa_ct and 'pos_payment' in self.env.context and sepa_ct.code not in res:
            //         res.append(sepa_ct.code)
            // return res
            */
            return default;
        }

        protected async Task<AccountPayment> GetPaymentReceiptReportValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _get_payment_receipt_report_values(self):
            // """ Get the extra values when rendering the Payment Receipt PDF report.
            // 
            // :return: A dictionary:
            //     * display_invoices: Display the invoices table.
            //     * display_payment_method: Display the payment method value.
            // """
            // self.ensure_one()
            // return {
            //     'display_invoices': True,
            //     'display_payment_method': True,
            // }
            */
            return default;
        }

        protected async Task<AccountPayment> GetPaymentRefundWizardValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: account_payment.py) ---
            // def _get_payment_refund_wizard_values(self):
            // self.ensure_one()
            // return {
            //     'transaction_id': self.payment_transaction_id.id,
            //     'payment_amount': self.amount,
            //     'amount_available_for_refund': self.amount_available_for_refund,
            // }
            */
            return default;
        }

        protected async Task<AccountPayment> GetTriggerFieldsToSynchronizeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _get_trigger_fields_to_synchronize(self):
            // return (
            //     'date', 'amount', 'payment_type', 'partner_type', 'payment_reference',
            //     'currency_id', 'partner_id', 'destination_account_id', 'partner_bank_id', 'journal_id'
            // )
            */
            return default;
        }

        protected async Task<AccountPayment> GetValidLiquidityAccountsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _get_valid_liquidity_accounts(self):
            // return (
            //     self.journal_id.default_account_id |
            //     self.payment_method_line_id.payment_account_id |
            //     self.journal_id.inbound_payment_method_line_ids.payment_account_id |
            //     self.journal_id.outbound_payment_method_line_ids.payment_account_id |
            //     self.outstanding_account_id
            // )
            */
            return default;
        }

        protected async Task<AccountPayment> GetValidPaymentAccountTypesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _get_valid_payment_account_types(self):
            // return ['asset_receivable', 'liability_payable']
            */
            return default;
        }

        public async Task<AccountPayment> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def init(self):
            // super().init()
            // create_index(
            //     self.env.cr,
            //     indexname='account_payment_journal_id_company_id_idx',
            //     tablename='account_payment',
            //     expressions=['journal_id', 'company_id']
            // )
            // create_index(
            //     self.env.cr,
            //     indexname='account_payment_unmatched_idx',
            //     tablename='account_payment',
            //     expressions=['journal_id', 'company_id'],
            //     where="NOT is_matched OR is_matched IS NULL"
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountPayment> InverseCheckNumberInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py) ---
            // def _inverse_check_number(self):
            // for payment in self:
            //     if payment.check_number:
            //         sequence = payment.journal_id.check_sequence_id.sudo()
            //         sequence.padding = len(payment.check_number)
            */
            return default;
        }

        protected async Task<AccountPayment> InversePartnerIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _inverse_partner_id(self):
            // # todo: remove in master
            // pass
            */
            return default;
        }

        public async Task<AccountPayment> MarkAsSentAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def mark_as_sent(self):
            // self.write({'is_sent': True})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountPayment> MessageMailAfterHookInternalAsync(object mails)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _message_mail_after_hook(self, mails):
            // for payment, mail in zip(self, mails):
            //     if (
            //         not payment.message_main_attachment_id
            //         and (attachments_to_link := mail.attachment_ids.filtered(lambda a: a.res_model == 'mail.message'))
            //     ):
            //         attachments_to_link.write({'res_model': self._name, 'res_id': payment.id})
            // return super()._message_mail_after_hook(mails)
            */
            return default;
        }

        protected async Task<AccountPayment> MustDeleteAllExpensePaymentsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: account_payment.py) ---
            // def _must_delete_all_expense_payments(self):
            // if self.expense_sheet_id and self.expense_sheet_id.account_move_ids.payment_ids - self:  # If not all the payments are to be deleted
            //     raise UserError(_("You cannot delete only some payments linked to an expense report. All payments must be deleted at the same time."))
            */
            return default;
        }

        protected async Task<AccountPayment> OnchangeSetPaymentTokenIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: account_payment.py) ---
            // def _onchange_set_payment_token_id(self):
            // codes = [key for key in dict(self.env['payment.provider']._fields['code']._description_selection(self.env))]
            // if not (self.payment_method_code in codes and self.partner_id and self.journal_id):
            //     self.payment_token_id = False
            //     return
            // 
            // self.payment_token_id = self.env['payment.token'].sudo().search([
            //     *self.env['payment.token']._check_company_domain(self.company_id),
            //     ('partner_id', '=', self.partner_id.id),
            //     ('provider_id.capture_manually', '=', False),
            //     ('provider_id', '=', self.payment_method_line_id.payment_provider_id.id),
            //  ], limit=1)
            */
            return default;
        }

        public async Task<AccountPayment> OpenBusinessDocAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def action_open_business_doc(self):
            // return {
            //     'name': _("Payment"),
            //     'type': 'ir.actions.act_window',
            //     'views': [(False, 'form')],
            //     'res_model': 'account.payment',
            //     'res_id': self.id,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountPayment> OpenExpenseReportAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: account_payment.py) ---
            // def action_open_expense_report(self):
            // self.ensure_one()
            // return {
            //     'name': self.expense_sheet_id.name,
            //     'type': 'ir.actions.act_window',
            //     'view_type': 'form',
            //     'view_mode': 'form',
            //     'views': [(False, 'form')],
            //     'res_model': 'hr.expense.sheet',
            //     'res_id': self.expense_sheet_id.id
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountPayment> PostAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def action_post(self):
            // ''' draft -> posted '''
            // # Do not allow posting if the account is required but not trusted
            // for payment in self:
            //     if (
            //         payment.require_partner_bank_account
            //         and not payment.partner_bank_id.allow_out_payment
            //         and payment.payment_type == 'outbound'
            //     ):
            //         raise UserError(_(
            //             "To record payments with %(method_name)s, the recipient bank account must be manually validated. "
            //             "You should go on the partner bank account of %(partner)s in order to validate it.",
            //             method_name=self.payment_method_line_id.name,
            //             partner=payment.partner_id.display_name,
            //         ))
            // self.filtered(lambda pay: pay.outstanding_account_id.account_type == 'asset_cash').state = 'paid'
            // # Avoid going back one state when clicking on the confirm action in the payment list view and having paid expenses selected
            // # We need to set values to each payment to avoid recomputation later
            // self.filtered(lambda pay: pay.state in {False, 'draft', 'in_process'}).state = 'in_process'
            --- ODOO METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py) ---
            // def action_post(self):
            // payment_method_check = self.env.ref('account_check_printing.account_payment_method_check')
            // for payment in self.filtered(lambda p: p.payment_method_id == payment_method_check and p.check_manual_sequencing):
            //     sequence = payment.journal_id.check_sequence_id
            //     payment.check_number = sequence.next_by_id()
            // return super(AccountPayment, self).action_post()
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: account_payment.py) ---
            // def action_post(self):
            // # Post the payments "normally" if no transactions are needed.
            // # If not, let the provider update the state.
            // 
            // payments_need_tx = self.filtered(
            //     lambda p: p.payment_token_id and not p.payment_transaction_id
            // )
            // # creating the transaction require to access data on payment providers, not always accessible to users
            // # able to create payments
            // transactions = payments_need_tx.sudo()._create_payment_transaction()
            // 
            // res = super(AccountPayment, self - payments_need_tx).action_post()
            // 
            // for tx in transactions:  # Process the transactions with a payment by token
            //     tx._send_payment_request()
            // 
            // # Post payments for issued transactions
            // transactions._post_process()
            // payments_tx_done = payments_need_tx.filtered(
            //     lambda p: p.payment_transaction_id.state == 'done'
            // )
            // super(AccountPayment, payments_tx_done).action_post()
            // payments_tx_not_done = payments_need_tx.filtered(
            //     lambda p: p.payment_transaction_id.state != 'done'
            // )
            // payments_tx_not_done.action_cancel()
            // 
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountPayment> PrepareMoveLineDefaultValsInternalAsync(object write_off_line_vals, object force_balance)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _prepare_move_line_default_vals(self, write_off_line_vals=None, force_balance=None):
            // ''' Prepare the dictionary to create the default account.move.lines for the current payment.
            // :param write_off_line_vals: Optional list of dictionaries to create a write-off account.move.line easily containing:
            //     * amount:       The amount to be added to the counterpart amount.
            //     * name:         The label to set on the line.
            //     * account_id:   The account on which create the write-off.
            // :param force_balance: Optional balance.
            // :return: A list of python dictionary to be passed to the account.move.line's 'create' method.
            // '''
            // self.ensure_one()
            // write_off_line_vals = write_off_line_vals or []
            // 
            // if not self.outstanding_account_id:
            //     raise UserError(_(
            //         "You can't create a new payment without an outstanding payments/receipts account set either on the company or the %(payment_method)s payment method in the %(journal)s journal.",
            //         payment_method=self.payment_method_line_id.name, journal=self.journal_id.display_name))
            // 
            // # Compute amounts.
            // write_off_line_vals_list = write_off_line_vals or []
            // write_off_amount_currency = sum(x['amount_currency'] for x in write_off_line_vals_list)
            // write_off_balance = sum(x['balance'] for x in write_off_line_vals_list)
            // 
            // if self.payment_type == 'inbound':
            //     # Receive money.
            //     liquidity_amount_currency = self.amount
            // elif self.payment_type == 'outbound':
            //     # Send money.
            //     liquidity_amount_currency = -self.amount
            // else:
            //     liquidity_amount_currency = 0.0
            // 
            // if not write_off_line_vals and force_balance is not None:
            //     sign = 1 if liquidity_amount_currency > 0 else -1
            //     liquidity_balance = sign * abs(force_balance)
            // else:
            //     liquidity_balance = self.currency_id._convert(
            //         liquidity_amount_currency,
            //         self.company_id.currency_id,
            //         self.company_id,
            //         self.date,
            //     )
            // counterpart_amount_currency = -liquidity_amount_currency - write_off_amount_currency
            // counterpart_balance = -liquidity_balance - write_off_balance
            // currency_id = self.currency_id.id
            // 
            // # Compute a default label to set on the journal items.
            // liquidity_line_name = ''.join(x[1] for x in self._get_aml_default_display_name_list() if x[1])
            // counterpart_line_name = liquidity_line_name
            // 
            // line_vals_list = [
            //     # Liquidity line.
            //     {
            //         'name': liquidity_line_name,
            //         'date_maturity': self.date,
            //         'amount_currency': liquidity_amount_currency,
            //         'currency_id': currency_id,
            //         'debit': liquidity_balance if liquidity_balance > 0.0 else 0.0,
            //         'credit': -liquidity_balance if liquidity_balance < 0.0 else 0.0,
            //         'partner_id': self.partner_id.id,
            //         'account_id': self.outstanding_account_id.id,
            //     },
            //     # Receivable / Payable.
            //     {
            //         'name': counterpart_line_name,
            //         'date_maturity': self.date,
            //         'amount_currency': counterpart_amount_currency,
            //         'currency_id': currency_id,
            //         'debit': counterpart_balance if counterpart_balance > 0.0 else 0.0,
            //         'credit': -counterpart_balance if counterpart_balance < 0.0 else 0.0,
            //         'partner_id': self.partner_id.id,
            //         'account_id': self.destination_account_id.id,
            //     },
            // ]
            // return line_vals_list + write_off_line_vals_list
            */
            return default;
        }

        protected async Task<AccountPayment> PreparePaymentTransactionValsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: account_payment.py) ---
            // def _prepare_payment_transaction_vals(self, **extra_create_values):
            // self.ensure_one()
            // if self._context.get('active_model', '') == 'account.move':
            //     invoice_ids = self._context.get('active_ids', [])
            // elif self._context.get('active_model', '') == 'account.move.line':
            //     invoice_ids = self.env['account.move'].search([('line_ids', '=', self._context.get('active_ids'))]).ids
            // else:
            //     invoice_ids = []
            // return {
            //     'provider_id': self.payment_token_id.provider_id.id,
            //     'payment_method_id': self.payment_token_id.payment_method_id.id,
            //     'reference': self.env['payment.transaction']._compute_reference(
            //         self.payment_token_id.provider_id.code, prefix=self.memo
            //     ),
            //     'amount': self.amount,
            //     'currency_id': self.currency_id.id,
            //     'partner_id': self.partner_id.id,
            //     'token_id': self.payment_token_id.id,
            //     'operation': 'offline',
            //     'payment_id': self.id,
            //     'invoice_ids': [Command.set(invoice_ids)],
            //     **extra_create_values,
            // }
            */
            return default;
        }

        public async Task<AccountPayment> PrintChecksAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py) ---
            // def print_checks(self):
            // """ Check that the recordset is valid, set the payments state to sent and call print_checks() """
            // # Since this method can be called via a client_action_multi, we need to make sure the received records are what we expect
            // valid_payments = self.filtered(lambda r: r.payment_method_line_id.code == 'check_printing' and not r.is_sent)
            // 
            // if len(valid_payments) == 0:
            //     raise UserError(_("Payments to print as a checks must have 'Check' selected as payment method and "
            //                       "not have already been reconciled"))
            // if any(payment.journal_id != valid_payments[0].journal_id for payment in valid_payments):
            //     raise UserError(_("In order to print multiple checks at once, they must belong to the same bank journal."))
            // 
            // if not valid_payments[0].journal_id.check_manual_sequencing:
            //     # The wizard asks for the number printed on the first pre-printed check
            //     # so payments are attributed the number of the check the'll be printed on.
            //     self.env.cr.execute("""
            //           SELECT payment.check_number
            //             FROM account_payment payment
            //            WHERE payment.journal_id = %(journal_id)s
            //              AND payment.check_number IS NOT NULL
            //         ORDER BY payment.check_number::BIGINT DESC
            //            LIMIT 1
            //     """, {
            //         'journal_id': self.journal_id.id,
            //     })
            //     last_check_number = (self.env.cr.fetchone() or (False,))[0]
            //     number_len = len(last_check_number or "")
            //     next_check_number = f'{int(last_check_number) + 1:0{number_len}}'
            // 
            //     return {
            //         'name': _('Print Pre-numbered Checks'),
            //         'type': 'ir.actions.act_window',
            //         'res_model': 'print.prenumbered.checks',
            //         'view_mode': 'form',
            //         'target': 'new',
            //         'context': {
            //             'payment_ids': valid_payments.ids,
            //             'default_next_check_number': next_check_number,
            //         }
            //     }
            // else:
            //     valid_payments.filtered(lambda r: r.state == 'draft').action_post()
            //     return valid_payments.do_print_checks()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountPayment> RefundWizardAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: account_payment.py) ---
            // def action_refund_wizard(self):
            // self.ensure_one()
            // return {
            //     'name': _("Refund"),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'payment.refund.wizard',
            //     'target': 'new',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountPayment> RejectAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def action_reject(self):
            // self.state = 'rejected'
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountPayment> SeekForLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _seek_for_lines(self):
            // ''' Helper used to dispatch the journal items between:
            // - The lines using the temporary liquidity account.
            // - The lines using the counterpart account.
            // - The lines being the write-off lines.
            // :return: (liquidity_lines, counterpart_lines, writeoff_lines)
            // '''
            // self.ensure_one()
            // 
            // # liquidity_lines, counterpart_lines, writeoff_lines
            // lines = [self.env['account.move.line'] for _dummy in range(3)]
            // valid_account_types = self._get_valid_payment_account_types()
            // for line in self.move_id.line_ids:
            //     if line.account_id in self._get_valid_liquidity_accounts():
            //         lines[0] += line  # liquidity_lines
            //     elif line.account_id.account_type in valid_account_types or line.account_id == line.company_id.transfer_account_id:
            //         lines[1] += line  # counterpart_lines
            //     else:
            //         lines[2] += line  # writeoff_lines
            // 
            // # In some case, there is no liquidity or counterpart line (after changing an outstanding account on the journal for example)
            // # In that case, and if there is one writeoff line, we take this line and set it as liquidity/counterpart line
            // if len(lines[2]) == 1:
            //     for i in (0, 1):
            //         if not lines[i]:
            //             lines[i] = lines[2]
            //             lines[2] -= lines[2]
            // 
            // return lines
            */
            return default;
        }

        protected async Task<AccountPayment> SynchronizeToMovesInternalAsync(object changed_fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _synchronize_to_moves(self, changed_fields):
            // '''
            //     Update the account.move regarding the modified account.payment.
            //     :param changed_fields: A list containing all modified fields on account.payment.
            // '''
            // if not any(field_name in changed_fields for field_name in self._get_trigger_fields_to_synchronize()):
            //     return
            // 
            // for pay in self:
            //     liquidity_lines, counterpart_lines, writeoff_lines = pay._seek_for_lines()
            //     # Make sure to preserve the write-off amount.
            //     # This allows to create a new payment with custom 'line_ids'.
            //     write_off_line_vals = []
            //     if liquidity_lines and counterpart_lines and writeoff_lines:
            //         write_off_line_vals.append({
            //             'name': writeoff_lines[0].name,
            //             'account_id': writeoff_lines[0].account_id.id,
            //             'partner_id': writeoff_lines[0].partner_id.id,
            //             'currency_id': writeoff_lines[0].currency_id.id,
            //             'amount_currency': sum(writeoff_lines.mapped('amount_currency')),
            //             'balance': sum(writeoff_lines.mapped('balance')),
            //         })
            //     line_vals_list = pay._prepare_move_line_default_vals(write_off_line_vals=write_off_line_vals)
            //     line_ids_commands = [
            //         Command.update(liquidity_lines.id, line_vals_list[0]) if liquidity_lines else Command.create(line_vals_list[0]),
            //         Command.update(counterpart_lines.id, line_vals_list[1]) if counterpart_lines else Command.create(line_vals_list[1])
            //     ]
            //     for line in writeoff_lines:
            //         line_ids_commands.append((2, line.id))
            //     for extra_line_vals in line_vals_list[2:]:
            //         line_ids_commands.append((0, 0, extra_line_vals))
            //     # Update the existing journal items.
            //     # If dealing with multiple write-off lines, they are dropped and a new one is generated.
            //     to_write = {
            //         'date': pay.date,
            //         'partner_id': pay.partner_id.id,
            //         'currency_id': pay.currency_id.id,
            //         'partner_bank_id': pay.partner_bank_id.id,
            //         'line_ids': line_ids_commands,
            //     }
            //     if 'journal_id' in changed_fields:
            //         to_write.update({
            //             'name': '/',  # Set the name to '/' to allow it to be changed
            //             'journal_id': pay.journal_id.id
            //         })
            //     pay.move_id.with_context(skip_invoice_sync=True).write(to_write)
            */
            return default;
        }

        public async Task<AccountPayment> UnmarkAsSentAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def unmark_as_sent(self):
            // self.write({'is_sent': False})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountPayment> ValidateAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def action_validate(self):
            // self.state = 'paid'
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountPayment> ViewPosOrderAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment, FILE: account_payment.py) ---
            // def action_view_pos_order(self):
            // """ Return the action for the view of the pos order linked to the payment.
            // """
            // self.ensure_one()
            // 
            // action = {
            //     'name': _("POS Order"),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'pos.order',
            //     'target': 'current',
            //     'res_id': self.pos_order_id.id,
            //     'view_mode': 'form'
            // }
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountPayment> ViewRefundsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: account_payment.py) ---
            // def action_view_refunds(self):
            // self.ensure_one()
            // action = {
            //     'name': _("Refund"),
            //     'res_model': 'account.payment',
            //     'type': 'ir.actions.act_window',
            // }
            // if self.refunds_count == 1:
            //     refund_tx = self.env['account.payment'].search([
            //         ('source_payment_id', '=', self.id)
            //     ], limit=1)
            //     action['res_id'] = refund_tx.id
            //     action['view_mode'] = 'form'
            // else:
            //     action['view_mode'] = 'list,form'
            //     action['domain'] = [('source_payment_id', '=', self.id)]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountPayment> VoidCheckAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py) ---
            // def action_void_check(self):
            // self.action_draft()
            // self.action_cancel()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, AccountPayment entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def write(self, vals):
            // if vals.get('state') in ('in_process', 'paid') and not vals.get('move_id'):
            //     self.filtered(lambda p: not p.move_id)._generate_journal_entry()
            //     self.move_id.filtered(lambda m: m.state == 'draft').action_post()
            // 
            // res = super().write(vals)
            // if self.move_id:
            //     self._synchronize_to_moves(set(vals.keys()))
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: account_payment.py) ---
            // def write(self, vals):
            // trigger_fields = {
            //     'date', 'amount', 'payment_type', 'partner_type', 'payment_reference',
            //     'currency_id', 'partner_id', 'destination_account_id', 'partner_bank_id', 'journal_id'
            //     'ref', 'expense_sheet_id', 'payment_method_line_id'
            // }
            // if self.expense_sheet_id and any(field_name in trigger_fields for field_name in vals):
            //     raise UserError(_("You cannot do this modification since the payment is linked to an expense report."))
            // return super().write(vals)
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}