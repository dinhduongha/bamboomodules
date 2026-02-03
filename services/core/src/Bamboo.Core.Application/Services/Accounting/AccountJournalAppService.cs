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
    public partial class AccountJournalAppService : GenericAppService<AccountJournal>, IAccountJournalAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailAliasMixinOptionalAppService _mailAliasMixinOptionalAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        private readonly IPortalMixinAppService _portalMixinAppService;
        public AccountJournalAppService(IRepository<AccountJournal, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailAliasMixinOptionalAppService mailAliasMixinOptionalAppService, IMailThreadAppService mailThreadAppService, IPortalMixinAppService portalMixinAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailAliasMixinOptionalAppService = mailAliasMixinOptionalAppService;
            _mailThreadAppService = mailThreadAppService;
            _portalMixinAppService = portalMixinAppService;
        }

        protected async Task<AccountJournal> AliasGetCreationValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _alias_get_creation_values(self):
            // values = super()._alias_get_creation_values()
            // values['alias_model_id'] = self.env['ir.model']._get_id('account.move')
            // if self.id:
            //     values['alias_name'] = self._alias_prepare_alias_name(self.alias_name, self.name, self.code, self.type, self.company_id)
            //     values['alias_defaults'] = defaults = literal_eval(self.alias_defaults or "{}")
            //     defaults['company_id'] = self.company_id.id
            //     defaults['move_type'] = {
            //         'purchase': 'in_invoice',
            //         'sale': 'out_invoice',
            //     }.get(self.type, 'entry')
            //     defaults['journal_id'] = self.id
            // return values
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountJournal> AliasPrepareAliasNameInternalAsync(object alias_name, object name, object code, object jtype, object company)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _alias_prepare_alias_name(self, alias_name, name, code, jtype, company):
            // """ Tool method generating standard journal alias, to ensure uniqueness
            // and readability;  reset for other journals than purchase / sale """
            // if jtype not in ('purchase', 'sale'):
            //     return False
            // 
            // alias_name = next(
            //     (
            //         string for string in (alias_name, name, code, jtype)
            //         if (string and self.env['mail.alias']._is_encodable(string) and
            //             self.env['mail.alias']._sanitize_alias_name(string))
            //     ), False
            // )
            // if company != self.env.ref('base.main_company'):
            //     company_identifier = self.env['mail.alias']._sanitize_alias_name(company.name) if self.env['mail.alias']._is_encodable(company.name) else company.id
            //     if f'-{company_identifier}' not in alias_name:
            //         alias_name = f"{alias_name}-{company_identifier}"
            // return self.env['mail.alias']._sanitize_alias_name(alias_name)
            */
            return default;
        }

        public async Task<AccountJournal> ArchiveAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: account_journal.py) ---
            // def action_archive(self):
            // self._check_no_active_payments()
            // return super().action_archive()
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<AccountJournal> BuildNoJournalErrorMsgInternalAsync(object company_name, object journal_types)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _build_no_journal_error_msg(self, company_name, journal_types):
            // return _(
            //         "No journal could be found in company %(company_name)s for any of those types: %(journal_types)s",
            //         company_name=company_name,
            //         journal_types=', '.join(journal_types),
            //     )
            */
            return default;
        }

        public async Task<AccountJournal> ButtonFetchInEinvoicesAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def button_fetch_in_einvoices(self):
            // # TO OVERRIDE
            // """
            // Abstract method to fetch e-invoices.
            // Should fetch vendor bill invoices synchronously and doesn't return anything.
            // """
            // pass
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: account_journal.py) ---
            // def button_fetch_in_einvoices(self):
            // # EXTENDS 'account'
            // super().button_fetch_in_einvoices()
            // edi_users = self.env['account_edi_proxy_client.user'].search([
            //     ('company_id.account_peppol_proxy_state', '=', 'receiver'),
            //     ('company_id', 'in', self.company_id.ids),
            //     ('proxy_type', '=', 'peppol')
            // ])
            // edi_users._peppol_get_new_documents()
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> ButtonRefreshOutEinvoicesStatusAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def button_refresh_out_einvoices_status(self):
            // # TO OVERRIDE
            // """
            // Abstract method to fetch e-invoice statuses.
            // Should fetch customer invoices statuses synchronously and doesn't return anything.
            // """
            // pass
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: account_journal.py) ---
            // def button_refresh_out_einvoices_status(self):
            // # EXTENDS 'account'
            // super().button_refresh_out_einvoices_status()
            // can_send = self.env['account_edi_proxy_client.user']._get_can_send_domain()
            // edi_users = self.env['account_edi_proxy_client.user'].search([
            //     ('company_id.account_peppol_proxy_state', 'in', can_send),
            //     ('company_id', 'in', self.company_id.ids),
            //     ('proxy_type', '=', 'peppol')
            // ])
            // edi_users._peppol_get_message_status()
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> ButtonUnsubscribeFromInvoiceNotificationsAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def button_unsubscribe_from_invoice_notifications(self):
            // # deprecated, to remove in master
            // self.ensure_one()
            // self.incoming_einvoice_notification_email = False
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<AccountJournal> CheckAutoPostDraftEntriesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _check_auto_post_draft_entries(self):
            // # constraint should be tested just after archiving a journal, but shouldn't be raised when unarchiving a journal containing draft entries
            // for journal in self.filtered(lambda j: not j.active):
            //     pending_moves = self.env['account.move'].search([
            //         ('journal_id', '=', journal.id),
            //         ('state', '=', 'draft')
            //     ], limit=1)
            // 
            //     if pending_moves:
            //         raise ValidationError(_("You can not archive a journal containing draft journal entries.\n\n"
            //                                 "To proceed:\n"
            //                                 "1/ click on the top-right button 'Journal Entries' from this journal form\n"
            //                                 "2/ then filter on 'Draft' entries\n"
            //                                 "3/ select them all and post or delete them through the action menu"))
            */
            return default;
        }

        protected async Task<AccountJournal> CheckBankAccountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _check_bank_account(self):
            // for journal in self:
            //     if journal.type == 'bank' and journal.bank_account_id:
            //         if journal.bank_account_id.company_id and journal.bank_account_id.company_id != journal.company_id:
            //             raise ValidationError(_('The bank account of a bank journal must belong to the same company (%s).', journal.company_id.name))
            //         # A bank account can belong to a customer/supplier, in which case their partner_id is the customer/supplier.
            //         # Or they are part of a bank journal and their partner_id must be the company's partner_id.
            //         if journal.bank_account_id.partner_id != journal.company_id.partner_id:
            //             raise ValidationError(_('The holder of a journal\'s bank account must be the company (%s).', journal.company_id.name))
            */
            return default;
        }

        protected async Task<AccountJournal> CheckCompanyConsistencyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _check_company_consistency(self):
            // for company, journals in groupby(self, lambda journal: journal.company_id):
            //     if self.env['account.move'].search_count([
            //         ('journal_id', 'in', [journal.id for journal in journals]),
            //         '!', ('company_id', 'child_of', company.id)
            //     ], limit=1):
            //         raise UserError(_("You can't change the company of your journal since there are some journal entries linked to it."))
            */
            return default;
        }

        protected async Task<AccountJournal> CheckIncomingEinvoiceNotificationEmailInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _check_incoming_einvoice_notification_email(self):
            // # to remove in master
            // pass
            */
            return default;
        }

        protected async Task<AccountJournal> CheckNoActivePaymentsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: account_journal.py) ---
            // def _check_no_active_payments(self):
            // hanging_journal_entries = self.env['pos.payment'].sudo().search(
            // [
            //     ('payment_method_id', 'in', self.pos_payment_method_ids.ids),
            //     ('session_id.state', '=', 'opened')
            // ], limit=1)
            // if(hanging_journal_entries):
            //     raise ValidationError(_("This journal is associated with payment method %(payment_method)s that is being used by order %(pos_order)s in the active pos session %(pos_session)s",
            //         payment_method=hanging_journal_entries.payment_method_id.name,
            //         pos_order=hanging_journal_entries.pos_order_id.name,
            //         pos_session=hanging_journal_entries.session_id.name))
            */
            return default;
        }

        protected async Task<AccountJournal> CheckPaymentMethodLineIdsMultiplicityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _check_payment_method_line_ids_multiplicity(self):
            // """
            // Check and ensure that the payment method lines multiplicity is respected.
            // """
            // results = self._get_journals_payment_method_information()
            // pay_methods = results['pay_methods']
            // manage_providers = results['manage_providers']
            // method_information_mapping = results['method_information_mapping']
            // providers_per_code = results['providers_per_code']
            // 
            // failing_unicity_payment_methods = self.env['account.payment.method']
            // for journal in self:
            //     company = journal.company_id
            // 
            //     # Exclude the 'unique' / 'electronic' values that are already set on the journal.
            //     protected_provider_ids = set()
            //     protected_payment_method_ids = set()
            //     for payment_type in ('inbound', 'outbound'):
            //         lines = journal[f'{payment_type}_payment_method_line_ids']
            // 
            //         # Ensure you don't have the same payment_method/name combination twice on the same journal.
            //         counter = {}
            //         for line in lines:
            //             if method_information_mapping.get(line.payment_method_id.id, {}).get('mode') not in ('electronic', 'unique'):
            //                 continue
            // 
            //             key = line.payment_method_id.id, line.name
            //             counter.setdefault(key, 0)
            //             counter[key] += 1
            //             if counter[key] > 1:
            //                 raise ValidationError(_(
            //                     "You can't have two payment method lines of the same payment type (%(payment_type)s) "
            //                     "and with the same name (%(name)s) on a single journal.",
            //                     payment_type=payment_type,
            //                     name=line.name,
            //                 ))
            // 
            //         for line in lines:
            //             if line.payment_method_id.id in method_information_mapping:
            //                 protected_payment_method_ids.add(line.payment_method_id.id)
            //                 if manage_providers and method_information_mapping[line.payment_method_id.id]['mode'] == 'electronic':
            //                     protected_provider_ids.add(line.payment_provider_id.id)
            // 
            //     for pay_method in pay_methods:
            //         values = method_information_mapping[pay_method.id]
            // 
            //         if values['mode'] == 'unique':
            //             # 'unique' are linked to a single journal per company.
            //             already_linked_journal_ids = values['company_journals'].get(company.id, [])
            //             if len(already_linked_journal_ids) > 1:
            //                 failing_unicity_payment_methods |= pay_method
            //         elif manage_providers and values['mode'] == 'electronic':
            //             # 'electronic' are linked to a single journal per company per provider.
            //             for provider_id in providers_per_code.get(company.id, {}).get(pay_method.code, set()):
            //                 already_linked_journal_ids = values['company_journals'].get(company.id, {}).get(provider_id, [])
            //                 if len(already_linked_journal_ids) > 1:
            //                     failing_unicity_payment_methods |= pay_method
            // 
            // if failing_unicity_payment_methods:
            //     raise ValidationError(_(
            //         "Some payment methods supposed to be unique already exists somewhere else.\n(%s)",
            //         ', '.join(failing_unicity_payment_methods.mapped('display_name')),
            //     ))
            */
            return default;
        }

        protected async Task<AccountJournal> CheckTypeDefaultAccountIdTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _check_type_default_account_id_type(self):
            // for journal in self:
            //     if journal.type in ('sale', 'purchase') and journal.default_account_id.account_type in ('asset_receivable', 'liability_payable'):
            //         raise ValidationError(_("The type of the journal's default credit/debit account shouldn't be 'receivable' or 'payable'."))
            */
            return default;
        }

        protected async Task<AccountJournal> CheckTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: account_journal.py) ---
            // def _check_type(self):
            // methods = self.env['pos.payment.method'].sudo().search([("journal_id", "in", self.ids)])
            // if methods:
            //     raise ValidationError(_("This journal is associated with a payment method. You cannot modify its type"))
            */
            return default;
        }

        public async Task<AccountJournal> ChecksToPrintAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_check_printing, FILE: account_journal.py) ---
            // def action_checks_to_print(self):
            // payment_method_line_id = self.outbound_payment_method_line_ids.filtered(lambda l: l.code == 'check_printing')[:1].id
            // return {
            //     'name': _('Checks to Print'),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'list,form,graph',
            //     'res_model': 'account.payment',
            //     'context': dict(
            //         self.env.context,
            //         search_default_checks_to_send=1,
            //         journal_id=self.id,
            //         default_journal_id=self.id,
            //         default_payment_type='outbound',
            //         default_payment_method_line_id=payment_method_line_id,
            //     ),
            // }
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<AccountJournal> ComputeAccountingDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_accounting_date(self):
            // move_date = self.env.context.get('move_date') or fields.Date.context_today(self)
            // has_tax = self.env.context.get('has_tax') or False
            // for journal in self:
            //     temp_move = self.env['account.move'].new({'journal_id': journal.id})
            //     journal.accounting_date = temp_move._get_accounting_date(move_date, has_tax)
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeAvailableInvoiceTemplatePdfReportIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_available_invoice_template_pdf_report_ids(self):
            // for journal in self:
            //     journal.available_invoice_template_pdf_report_ids = self.env['account.move']._get_available_invoice_template_pdf_report_ids()
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeAvailablePaymentMethodIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_available_payment_method_ids(self):
            // """
            // Compute the available payment methods id by respecting the following rules:
            //     Methods of mode 'unique' cannot be used twice on the same company.
            //     Methods of mode 'electronic' cannot be used twice on the same company for the same 'payment_provider_id'.
            //     Methods of mode 'multi' can be duplicated on the same journal.
            // """
            // results = self._get_journals_payment_method_information()
            // pay_methods = results['pay_methods']
            // manage_providers = results['manage_providers']
            // method_information_mapping = results['method_information_mapping']
            // providers_per_code = results['providers_per_code']
            // 
            // journal_bank_cash = self.filtered(lambda j: j.type in ('bank', 'cash', 'credit'))
            // journal_other = self - journal_bank_cash
            // journal_other.available_payment_method_ids = False
            // 
            // # Compute the candidates for each bank/cash journal.
            // for journal in journal_bank_cash:
            //     commands = [Command.clear()]
            //     company = journal.company_id
            // 
            //     # Exclude the 'unique' / 'electronic' values that are already set on the journal.
            //     protected_provider_ids = set()
            //     protected_payment_method_ids = set()
            //     for payment_type in ('inbound', 'outbound'):
            //         lines = journal[f'{payment_type}_payment_method_line_ids']
            //         for line in lines:
            //             if line.payment_method_id.id in method_information_mapping:
            //                 protected_payment_method_ids.add(line.payment_method_id.id)
            //                 if manage_providers and method_information_mapping.get(line.payment_method_id.id, {}).get('mode') == 'electronic':
            //                     protected_provider_ids.add(line.payment_provider_id.id)
            // 
            //     for pay_method in pay_methods:
            //         # Check the partial domain of the payment method to make sure the type matches the current journal
            //         if not journal._is_payment_method_available(pay_method.code, complete_domain=False):
            //             continue
            // 
            //         values = method_information_mapping[pay_method.id]
            // 
            //         if values['mode'] == 'unique':
            //             # 'unique' are linked to a single journal per company.
            //             already_linked_journal_ids = set(values['company_journals'].get(company.id, [])) - {journal._origin.id}
            //             if not already_linked_journal_ids and pay_method.id not in protected_payment_method_ids:
            //                 commands.append(Command.link(pay_method.id))
            //         elif manage_providers and values['mode'] == 'electronic':
            //             # 'electronic' are linked to a single journal per company per provider.
            //             for provider_id in providers_per_code.get(company.id, {}).get(pay_method.code, set()):
            //                 already_linked_journal_ids = set(values['company_journals'].get(company.id, {}).get(provider_id, [])) - {journal._origin.id}
            //                 if not already_linked_journal_ids and provider_id not in protected_provider_ids:
            //                     commands.append(Command.link(pay_method.id))
            //         elif values['mode'] == 'multi':
            //             # 'multi' are unlimited.
            //             commands.append(Command.link(pay_method.id))
            // 
            //     journal.available_payment_method_ids = commands
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeCheckNextNumberInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_check_printing, FILE: account_journal.py) ---
            // def _compute_check_next_number(self):
            // for journal in self:
            //     sequence = journal.check_sequence_id
            //     if sequence:
            //         journal.check_next_number = sequence.get_next_char(sequence.number_next_actual)
            //     else:
            //         journal.check_next_number = 1
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_code(self):
            // cache = defaultdict(list)
            // for record in self:
            //     if not record.code and record.type:
            //         record.code = self._get_next_journal_default_code(
            //             record.type,
            //             record.company_id,
            //             cache.get(record.company_id)
            //         )
            //         cache[record.company_id].append(record.code)
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeCompatibleEdiIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_journal.py) ---
            // def _compute_compatible_edi_ids(self):
            // edi_formats = self.env['account.edi.format'].search([])
            // 
            // for journal in self:
            //     compatible_edis = edi_formats.filtered(lambda e: e._is_compatible_with_journal(journal))
            //     journal.compatible_edi_ids = compatible_edis
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeCurrentStatementBalanceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _compute_current_statement_balance(self):
            // query_result = self._get_journal_dashboard_bank_running_balance()
            // for journal in self:
            //     journal.has_statement_lines, journal.current_statement_balance = query_result.get(journal.id)
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeDebitSequenceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_debit_note, FILE: account_journal.py) ---
            // def _compute_debit_sequence(self):
            // for journal in self:
            //     journal.debit_sequence = journal.type in ("sale", "purchase")
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeDefaultAccountTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_default_account_type(self):
            // default_account_id_types = {
            //     'bank': 'asset_cash',
            //     'cash': 'asset_cash',
            //     'sale': 'income%',
            //     'purchase': 'expense%',
            //     'credit': 'liability_credit_card',
            // }
            // 
            // for journal in self:
            //     journal.default_account_type = default_account_id_types.get(journal.type, '%')
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeDisplayAliasFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_display_alias_fields(self):
            // self.display_alias_fields = self.env['mail.alias.domain'].search_count([], limit=1)
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_display_name(self):
            // for journal in self:
            //     name = journal.name
            //     if journal.currency_id and journal.currency_id != journal.company_id.sudo().currency_id:
            //         name = f"{name} ({journal.currency_id.name})"
            //     journal.display_name = name
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeEdiFormatIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_journal.py) ---
            // def _compute_edi_format_ids(self):
            // edi_formats = self.env['account.edi.format'].search([])
            // journal_ids = self.ids
            // 
            // if journal_ids:
            //     self.env.cr.execute('''
            //         SELECT
            //             move.journal_id,
            //             ARRAY_AGG(doc.edi_format_id) AS edi_format_ids
            //         FROM account_edi_document doc
            //         JOIN account_move move ON move.id = doc.move_id
            //         WHERE doc.state IN ('to_cancel', 'to_send')
            //         AND move.journal_id IN %s
            //         GROUP BY move.journal_id
            //     ''', [tuple(journal_ids)])
            //     protected_edi_formats_per_journal = {r[0]: set(r[1]) for r in self.env.cr.fetchall()}
            // else:
            //     protected_edi_formats_per_journal = defaultdict(set)
            // 
            // for journal in self:
            //     enabled_edi_formats = edi_formats.filtered(lambda e: e._is_compatible_with_journal(journal) and
            //                                                          (e._is_enabled_by_default_on_journal(journal)
            //                                                           or (e in journal.edi_format_ids)))
            // 
            //     # The existing edi formats that are already in use so we can't remove it.
            //     protected_edi_format_ids = protected_edi_formats_per_journal.get(journal.id, set())
            //     protected_edi_formats = journal.edi_format_ids.filtered(lambda e: e.id in protected_edi_format_ids)
            // 
            //     journal.edi_format_ids = enabled_edi_formats + protected_edi_formats
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeEntriesCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _compute_entries_count(self):
            // res = {
            //     journal.id: count
            //     for journal, count in self.env['account.move']._read_group(
            //         domain=[
            //             *self.env['account.move']._check_company_domain(self.env.companies),
            //             ('journal_id', 'in', self.ids),
            //         ],
            //         groupby=['journal_id'],
            //         aggregates=['__count'],
            //     )
            // }
            // for journal in self:
            //     journal.entries_count = res.get(journal.id, 0)
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeHasEntriesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _compute_has_entries(self):
            // if not self.ids:
            //     self.has_posted_entries = False
            //     self.has_entries = False
            //     return
            // sql_query = SQL(
            //     """
            //                SELECT j.id,
            //                       has_posted_entries.val,
            //                       has_entries.val
            //                  FROM account_journal j
            //     LEFT JOIN LATERAL (
            //                           SELECT bool(m.id) as val
            //                             FROM account_move m
            //                            WHERE m.journal_id = j.id
            //                              AND m.state = 'posted'
            //                            LIMIT 1
            //                       ) AS has_posted_entries ON true
            //     LEFT JOIN LATERAL (
            //                           SELECT bool(m.id) as val
            //                             FROM account_move m
            //                            WHERE m.journal_id = j.id
            //                            LIMIT 1
            //                       ) AS has_entries ON true
            //                 WHERE j.id in %(journal_ids)s
            //     """,
            //     journal_ids=tuple(self.ids),
            // )
            // self.env.cr.execute(sql_query)
            // res = {journal_id: (has_posted, has_entries) for journal_id, has_posted, has_entries in self.env.cr.fetchall()}
            // for journal in self:
            //     r = res.get(journal.id, (False, False))
            //     journal.has_posted_entries = bool(r[0])
            //     journal.has_entries = bool(r[1])
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeHasInvalidStatementsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_has_invalid_statements(self):
            // journals_with_invalid_statements = self.env['account.bank.statement'].search([
            //     ('journal_id', 'in', self.ids),
            //     '|',
            //     ('is_valid', '=', False),
            //     ('is_complete', '=', False),
            // ]).journal_id
            // journals_with_invalid_statements.has_invalid_statements = True
            // (self - journals_with_invalid_statements).has_invalid_statements = False
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeHasSequenceHolesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _compute_has_sequence_holes(self):
            // has_sequence_holes = set(journal_id for journal_id, _prefix in self._query_has_sequence_holes())
            // for journal in self:
            //     journal.has_sequence_holes = journal.id in has_sequence_holes
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeHasUnhashedEntriesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _compute_has_unhashed_entries(self):
            // for journal in self:
            //     if journal.restrict_mode_hash_table:
            //         journal.has_unhashed_entries = journal._get_moves_to_hash(include_pre_last_hash=False, early_stop=True)
            //     else:
            //         journal.has_unhashed_entries = False
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeInboundPaymentMethodLineIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_inbound_payment_method_line_ids(self):
            // for journal in self:
            //     pay_method_line_ids_commands = [Command.clear()]
            //     if journal.type in ('bank', 'cash', 'credit'):
            //         existing_method_lines = journal.inbound_payment_method_line_ids
            //         default_methods = journal._default_inbound_payment_methods()
            //         for pay_method in default_methods:
            //             payment_account = existing_method_lines.filtered(lambda m: m.payment_method_id == pay_method)[:1].payment_account_id
            //             pay_method_line_ids_commands += [
            //                 Command.create({
            //                     'name': pay_method.name,
            //                     'payment_method_id': pay_method.id,
            //                     'payment_account_id': (
            //                         payment_account.id
            //                         if not payment_account.currency_id or payment_account.currency_id == journal.currency_id
            //                         else False
            //                     ),
            //                 })
            //             ]
            //     journal.inbound_payment_method_line_ids = pay_method_line_ids_commands
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeIncomingEinvoiceNotificationEmailInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_incoming_einvoice_notification_email(self):
            // for journal in self:
            //     if (
            //         journal.type == 'purchase'
            //         and not journal.incoming_einvoice_notification_email
            //         and journal.company_id.email
            //     ):
            //         journal.incoming_einvoice_notification_email = journal.company_id.email
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeLastBankStatementInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _compute_last_bank_statement(self):
            // self.env.cr.execute("""
            //     SELECT journal.id, statement.id
            //       FROM account_journal journal
            //  LEFT JOIN LATERAL (
            //               SELECT id, company_id
            //                 FROM account_bank_statement
            //                WHERE journal_id = journal.id
            //                  AND first_line_index IS NOT NULL
            //             ORDER BY first_line_index DESC
            //                LIMIT 1
            //            ) statement ON TRUE
            //      WHERE journal.id = ANY(%s)
            //        AND statement.company_id = ANY(%s)
            // """, [self.ids, self.env.companies.ids])
            // last_statements = {journal_id: statement_id for journal_id, statement_id in self.env.cr.fetchall()}
            // for journal in self:
            //     journal.last_statement_id = self.env['account.bank.statement'].browse(last_statements.get(journal.id))
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeNamePlaceholderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_name_placeholder(self):
            // type_to_default_name = {
            //     'sale': _('Customer Invoices'),
            //     'purchase': _('Vendor Bills'),
            //     'cash': _('Cash'),
            //     'bank': _('Bank'),
            //     'credit': _('Credit Card'),
            //     'general': _('Miscellaneous Operations'),
            // }
            // for journal in self:
            //     if not journal.type:
            //         journal.name_placeholder = _("Select a type")
            //     else:
            //         match = re.search(r'[0-9]+$', journal.code or '')
            //         code_suffix = match.group() if match else '1'
            //         journal.name_placeholder = f"{type_to_default_name[journal.type]} ({code_suffix})"
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeOutboundPaymentMethodLineIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_outbound_payment_method_line_ids(self):
            // for journal in self:
            //     pay_method_line_ids_commands = [Command.clear()]
            //     if journal.type in ('bank', 'cash', 'credit'):
            //         existing_method_lines = journal.outbound_payment_method_line_ids
            //         default_methods = journal._default_outbound_payment_methods()
            //         for pay_method in default_methods:
            //             payment_account = existing_method_lines.filtered(lambda m: m.payment_method_id == pay_method)[:1].payment_account_id
            //             pay_method_line_ids_commands += [
            //                 Command.create({
            //                     'name': pay_method.name,
            //                     'payment_method_id': pay_method.id,
            //                     'payment_account_id': (
            //                         payment_account.id
            //                         if not payment_account.currency_id or payment_account.currency_id == journal.currency_id
            //                         else False
            //                     ),
            //                 })
            //             ]
            //     journal.outbound_payment_method_line_ids = pay_method_line_ids_commands
            */
            return default;
        }

        protected async Task<AccountJournal> ComputePaymentSequenceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_payment_sequence(self):
            // for journal in self:
            //     journal.payment_sequence = journal.type in ('bank', 'cash', 'credit')
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeRefundSequenceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_refund_sequence(self):
            // for journal in self:
            //     journal.refund_sequence = journal.type in ('sale', 'purchase')
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeSelectedPaymentMethodCodesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_selected_payment_method_codes(self):
            // """
            // Set the selected payment method as a list of comma separated codes like: ,manual,check_printing,...
            // These will be then used to display or not payment method specific fields in the view.
            // """
            // for journal in self:
            //     codes = [line.code for line in journal.inbound_payment_method_line_ids + journal.outbound_payment_method_line_ids if line.code]
            //     journal.selected_payment_method_codes = ',' + ','.join(codes) + ','
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeShowFetchInEinvoicesButtonInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_show_fetch_in_einvoices_button(self):
            // # TO OVERRIDE
            // self.show_fetch_in_einvoices_button = False
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: account_journal.py) ---
            // def _compute_show_fetch_in_einvoices_button(self):
            // # EXTENDS 'account'
            // super()._compute_show_fetch_in_einvoices_button()
            // 
            // self.filtered(lambda j: (
            //     j.is_peppol_journal
            //     and j.account_peppol_proxy_state == 'receiver'
            //     and j.type == 'purchase'
            //     and not j.is_self_billing
            // )).show_fetch_in_einvoices_button = True
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeShowRefreshOutEinvoicesStatusButtonInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_show_refresh_out_einvoices_status_button(self):
            // # TO OVERRIDE
            // self.show_refresh_out_einvoices_status_button = False
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: account_journal.py) ---
            // def _compute_show_refresh_out_einvoices_status_button(self):
            // # EXTENDS 'account'
            // super()._compute_show_refresh_out_einvoices_status_button()
            // sender_states = self.env['account_edi_proxy_client.user']._get_can_send_domain()
            // 
            // self.filtered(lambda j: (
            //     j.account_peppol_proxy_state in sender_states
            //     and (
            //         j.type == 'sale'
            //         or (
            //             j.type == 'purchase'
            //             and j.is_self_billing
            //         )
            //     )
            // )).show_refresh_out_einvoices_status_button = True
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeSuspenseAccountIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_suspense_account_id(self):
            // for journal in self:
            //     if journal.type not in ('bank', 'cash', 'credit'):
            //         journal.suspense_account_id = False
            //     elif journal.suspense_account_id:
            //         journal.suspense_account_id = journal.suspense_account_id
            //     elif journal.company_id.account_journal_suspense_account_id:
            //         journal.suspense_account_id = journal.company_id.account_journal_suspense_account_id
            //     else:
            //         journal.suspense_account_id = False
            */
            return default;
        }

        public async Task<AccountJournal> ConfigureBankJournalAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def action_configure_bank_journal(self):
            // """ This function is called by the "configure" button of bank journals,
            // visible on dashboard if no bank statement source has been defined yet
            // """
            // # We simply call the setup bar function.
            // return self.env['res.company'].with_context(default_linked_journal_id=self.id).setting_init_bank_account_action()
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> CopyDataAsync(AccountJournalCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default)
            // code_by_company_id = {
            //     company_id: set(self.env['account.journal'].with_context(active_test=False)._read_group(
            //         domain=self.env['account.journal']._check_company_domain(company_id),
            //         aggregates=['code:array_agg'],
            //     )[0][0])
            //     for company_id, _ in groupby(vals_list, lambda v: v['company_id'])
            // }
            // for journal, vals in zip(self, vals_list):
            //     # Find a unique code for the copied journal
            //     all_journal_codes = code_by_company_id[vals['company_id']]
            // 
            //     copy_code = vals['code']
            //     code_prefix = re.sub(r'\d+', '', copy_code).strip()
            //     counter = 1
            //     while counter <= len(all_journal_codes) and copy_code in all_journal_codes:
            //         counter_str = str(counter)
            //         copy_prefix = code_prefix[:journal._fields['code'].size - len(counter_str)]
            //         copy_code = "%s%s" % (copy_prefix, counter_str)
            //         counter += 1
            // 
            //     if counter > len(all_journal_codes):
            //         # Should never happen, but put there just in case.
            //         raise UserError(_("Could not compute any code for the copy automatically. Please create it manually."))
            // 
            //     vals.update(
            //         code=copy_code,
            //         name=_("%s (copy)", journal.name or ''))
            // return vals_list
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<AccountJournal> CountResultsAndSumAmountsInternalAsync(object results_dict, object target_currency)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _count_results_and_sum_amounts(self, results_dict, target_currency):
            // """ Loops on a query result to count the total number of invoices and sum
            // their amount_total field (expressed in the given target currency).
            // amount_total must be signed!
            // """
            // if not results_dict:
            //     return 0, 0
            // 
            // total_amount = 0
            // count = 0
            // company = self.env.company
            // today = fields.Date.context_today(self)
            // ResCurrency = self.env['res.currency']
            // ResCompany = self.env['res.company']
            // for result in results_dict:
            //     document_currency = ResCurrency.browse(result.get('currency'))
            //     document_company = ResCompany.browse(result.get('company_id')) or company
            //     date = result.get('invoice_date') or today
            //     count += result.get('count', 1)
            // 
            //     if document_company.currency_id == target_currency:
            //         total_amount += result.get('amount_total_company') or 0
            //     else:
            //         total_amount += document_currency._convert(result.get('amount_total'), target_currency, document_company, date)
            // return count, target_currency.round(total_amount)
            */
            return default;
        }

        public override async Task<AccountJournal> CreateAsync(CreateRequestDto<AccountJournal> input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     # have to keep track of new journal codes when importing
            //     codes = [vals['code'] for vals in vals_list if 'code' in vals] if 'import_file' in self.env.context else False
            //     self._fill_missing_values(vals, protected_codes=codes)
            // 
            // journals = super(AccountJournal, self.with_context(mail_create_nolog=True)).create(vals_list)
            // 
            // for journal, vals in zip(journals, vals_list):
            //     # Create the bank_account_id if necessary
            //     if journal.type == 'bank' and not journal.bank_account_id and vals.get('bank_acc_number'):
            //         journal.set_bank_account(vals.get('bank_acc_number'), vals.get('bank_id'))
            // 
            // return journals
            --- ODOO METHOD SOURCE (MODULE: account_check_printing, FILE: account_journal.py) ---
            // def create(self, vals_list):
            // journals = super().create(vals_list)
            // journals.filtered(lambda j: not j.check_sequence_id)._create_check_sequence()
            // return journals
            */
            return await base.CreateAsync(input);
        }

        public async Task<AccountJournal> CreateBankStatementAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def create_bank_statement(self):
            // """return action to create a bank statements. This button should be called only on journals with type =='bank'"""
            // action = self.env["ir.actions.actions"]._for_xml_id("account.action_bank_statement_tree")
            // action.update({
            //     'views': [[False, 'form']],
            //     'context': "{'default_journal_id': " + str(self.id) + "}",
            // })
            // return action
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<AccountJournal> CreateCheckSequenceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_check_printing, FILE: account_journal.py) ---
            // def _create_check_sequence(self):
            // """ Create a check sequence for the journal """
            // for journal in self:
            //     journal.check_sequence_id = self.env['ir.sequence'].sudo().create({
            //         'name': _("%(journal)s: Check Number Sequence", journal=journal.name),
            //         'implementation': 'no_gap',
            //         'padding': 5,
            //         'number_increment': 1,
            //         'company_id': journal.company_id.id,
            //     })
            */
            return default;
        }

        public async Task<AccountJournal> CreateCustomerPaymentAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def create_customer_payment(self):
            // """return action to create a customer payment"""
            // return self.open_payments_action('inbound', mode='form')
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        protected async Task<AccountJournal> CreateDefaultAccountInternalAsync(object company, object journal_type, object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _create_default_account(self, company, journal_type, vals):
            // # Don't get the digits on 'chart_template' since the chart template could be a custom one.
            // random_account = self.env['account.account'].with_company(company).search(
            //     self.env['account.account']._check_company_domain(company),
            //     limit=1,
            // )
            // digits = len(random_account.code) if random_account else 6
            // 
            // if journal_type in ('bank', 'credit'):
            //     account_prefix = company.bank_account_code_prefix or ''
            // elif journal_type == 'cash':
            //     account_prefix = company.cash_account_code_prefix or company.bank_account_code_prefix or ''
            // else:
            //     account_prefix = ''
            // 
            // start_code = account_prefix.ljust(digits, '0')
            // default_account_code = self.env['account.account'].with_company(company)._search_new_account_code(start_code)
            // 
            // if journal_type in ('bank', 'cash'):
            //     default_account_vals = self._prepare_liquidity_account_vals(company, default_account_code, vals)
            // elif journal_type == 'credit':
            //     default_account_vals = self._prepare_credit_account_vals(company, default_account_code, vals)
            // else:
            //     default_account_vals = {}
            // 
            // default_account = self.env['account.account'].create(default_account_vals)
            // if default_account:
            //     self.env['ir.model.data']._update_xmlids([
            //         {
            //             'xml_id': f"account.{company.id}_{journal_type}_journal_default_account_{default_account.id}",
            //             'record': default_account,
            //             'noupdate': True,
            //         }
            //     ])
            // return default_account.id
            */
            return default;
        }

        public async Task<AccountJournal> CreateDocumentFromAttachmentAsync(AccountJournalCreateDocumentFromAttachmentRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def create_document_from_attachment(self, attachment_ids):
            // """ Create the invoices from files.
            //  :return: A action redirecting to account.move list/form view.
            // """
            // invoices = self._create_document_from_attachment(attachment_ids)
            // action_vals = {
            //     'name': _('Generated Documents'),
            //     'domain': [('id', 'in', invoices.ids)],
            //     'res_model': 'account.move',
            //     'type': 'ir.actions.act_window',
            //     'context': self.env.context
            // }
            // if len(invoices) == 1:
            //     action_vals.update({
            //         'views': [[False, "form"]],
            //         'view_mode': 'form',
            //         'res_id': invoices[0].id,
            //     })
            // else:
            //     action_vals.update({
            //         'views': [[False, "list"], [False, "kanban"], [False, "form"]],
            //         'view_mode': 'list, kanban, form',
            //     })
            // return action_vals
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<AccountJournal> CreateDocumentFromAttachmentInternalAsync(List<Guid> attachment_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _create_document_from_attachment(self, attachment_ids):
            // """ Create the invoices from files."""
            // if not self:
            //     self = self.env['account.journal'].browse(self.env.context.get("default_journal_id"))  # noqa: PLW0642
            // move_type = self.env.context.get("default_move_type", "entry")
            // if not self:
            //     if move_type in self.env['account.move'].get_sale_types(include_receipts=True):
            //         journal_type = "sale"
            //     elif move_type in self.env['account.move'].get_purchase_types(include_receipts=True):
            //         journal_type = "purchase"
            //     else:
            //         raise UserError(_("The journal in which to upload the invoice is not specified. "))
            //     self = self.env['account.journal'].search([  # noqa: PLW0642
            //         *self.env['account.journal']._check_company_domain(self.env.company),
            //         ('type', '=', journal_type),
            //     ], limit=1)
            // 
            // attachments = self.env['ir.attachment'].browse(attachment_ids)
            // if not attachments:
            //     raise UserError(_("No attachment was provided"))
            // 
            // if not self:
            //     raise UserError(self.env['account.journal']._build_no_journal_error_msg(self.env.company.display_name, [journal_type]))
            // 
            // # Create one invoice per group.
            // invoices = self.env['account.move'] \
            //     .with_context(
            //         default_journal_id=self.id,
            //         skip_is_manually_modified=True,
            //     ) \
            //     ._create_records_from_attachments(attachments)
            // 
            // for invoice in invoices:
            //     invoice._autopost_bill()
            // 
            // return invoices
            */
            return default;
        }

        public async Task<AccountJournal> CreateNewAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def action_create_new(self):
            // return {
            //     'name': _('Create invoice/bill'),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'account.move',
            //     'view_id': self.env.ref('account.view_move_form').id,
            //     'context': self._get_move_action_context(),
            // }
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> CreateSupplierPaymentAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def create_supplier_payment(self):
            // """return action to create a supplier payment"""
            // return self.open_payments_action('outbound', mode='form')
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> CreateVendorBillAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def action_create_vendor_bill(self):
            // """ This function is called by the "try our sample" button of Vendor Bills,
            // visible on dashboard if no bill has been created yet.
            // """
            // context = dict(self.env.context)
            // purchase_journal = self.browse(context.get('default_journal_id')) or self.search([('type', '=', 'purchase')], limit=1)
            // if not purchase_journal:
            //     raise UserError(self._build_no_journal_error_msg(self.env.company.display_name, ['purchase']))
            // context['default_move_type'] = 'in_invoice'
            // invoice_date = fields.Date.today() - timedelta(days=12)
            // partner = self.env['res.partner'].search([('name', '=', 'Deco Addict')], limit=1)
            // company = purchase_journal.company_id
            // if not partner:
            //     partner = self.env['res.partner'].create({
            //         'name': 'Deco Addict',
            //         'is_company': True,
            //     })
            // default_expense_account = company.expense_account_id
            // ref = 'DE%s' % invoice_date.strftime('%Y%m')
            // bill = self.env['account.move'].with_context(default_extract_state='done').create({
            //     'move_type': 'in_invoice',
            //     'partner_id': partner.id,
            //     'ref': ref,
            //     'invoice_date': invoice_date,
            //     'invoice_date_due': invoice_date + timedelta(days=30),
            //     'journal_id': purchase_journal.id,
            //     'invoice_line_ids': [
            //         Command.create({
            //             'name': "[FURN_8999] Three-Seat Sofa",
            //             'account_id': purchase_journal.default_account_id.id or default_expense_account.id,
            //             'quantity': 5,
            //             'price_unit': 1500,
            //         }),
            //         Command.create({
            //             'name': "[FURN_8220] Four Person Desk",
            //             'account_id': purchase_journal.default_account_id.id or default_expense_account.id,
            //             'quantity': 5,
            //             'price_unit': 2350,
            //         })
            //     ],
            // })
            // # In case of test environment, don't create the pdf
            // if tools.config['test_enable']:
            //     bill.message_post()
            // else:
            //     addr = [x for x in [
            //         company.street,
            //         company.street2,
            //         ' '.join([x for x in [company.state_id.name, company.zip] if x]),
            //         company.country_id.name,
            //     ] if x]
            // 
            //     html = self.env['ir.qweb']._render('account.bill_preview', {
            //         'company_name': company.name,
            //         'company_street_address': addr,
            //         'invoice_name': 'Invoice ' + ref,
            //         'invoice_ref': ref,
            //         'invoice_date': invoice_date,
            //         'invoice_due_date': invoice_date + timedelta(days=30),
            //     })
            //     bodies = self.env['ir.actions.report']._prepare_html(html)[0]
            //     content = self.env['ir.actions.report']._run_wkhtmltopdf(bodies)
            //     attachment = self.env['ir.attachment'].create({
            //         'type': 'binary',
            //         'name': 'INV-%s-0001.pdf' % invoice_date.strftime('%Y-%m'),
            //         'res_model': 'mail.compose.message',
            //         'datas': base64.encodebytes(content),
            //     })
            //     bill.message_post(attachment_ids=attachment.ids)
            // return {
            //     'name': _('Bills'),
            //     'res_id': bill.id,
            //     'view_mode': 'form',
            //     'res_model': 'account.move',
            //     'views': [[False, "form"]],
            //     'type': 'ir.actions.act_window',
            //     'context': context,
            // }
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<AccountJournal> DefaultDisplayInvoiceTemplatePdfReportIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _default_display_invoice_template_pdf_report_id(self):
            // """ Show PDF template selection if there are more than 1 template available for invoices. """
            // return len(self.available_invoice_template_pdf_report_ids) > 1
            */
            return default;
        }

        protected async Task<AccountJournal> DefaultInboundPaymentMethodsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _default_inbound_payment_methods(self):
            // return self.env.ref('account.account_payment_method_manual_in')
            */
            return default;
        }

        protected async Task<AccountJournal> DefaultInvoiceReferenceModelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _default_invoice_reference_model(self):
            // """Get the invoice reference model according to the company's country."""
            // country_code = self.env.company.country_id.code
            // country_code = country_code and country_code.lower()
            // if country_code:
            //     for model in self._fields['invoice_reference_model'].get_values(self.env):
            //         if model.startswith(country_code):
            //             return model
            // return 'odoo'
            */
            return default;
        }

        protected async Task<AccountJournal> DefaultOutboundPaymentMethodsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _default_outbound_payment_methods(self):
            // return self.env.ref('account.account_payment_method_manual_out')
            --- ODOO METHOD SOURCE (MODULE: account_check_printing, FILE: account_journal.py) ---
            // def _default_outbound_payment_methods(self):
            // res = super()._default_outbound_payment_methods()
            // if self._is_payment_method_available('check_printing'):
            //     res |= self.env.ref('account_check_printing.account_payment_method_check')
            // return res
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountJournal> EnsureCompanyAccountJournalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: account_journal.py) ---
            // def _ensure_company_account_journal(self):
            // journal = self.search([
            //     ('code', '=', 'POSS'),
            //     ('company_id', '=', self.env.company.id),
            // ], limit=1)
            // if not journal:
            //     journal = self.create({
            //         'name': _('Point of Sale'),
            //         'code': 'POSS',
            //         'type': 'general',
            //         'company_id': self.env.company.id,
            //     })
            // return journal
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountJournal> EnsureUniqueAliasInternalAsync(object vals, object company)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _ensure_unique_alias(self, vals, company):
            // """ Check uniqueness of the alias name within the given alias domain.
            // :param vals: the values of the journal.
            // :return: a unique alias name.
            // """
            // alias_name = vals['alias_name']
            // alias_domain_name = company.alias_domain_id.name
            // 
            // domain = [('alias_name', '=', alias_name)]
            // if alias_domain_name:
            //     domain.extend(['|', ('alias_domain', '=', alias_domain_name), ('alias_domain_id', '=', False)])
            // 
            // existing_alias = self.env['mail.alias'].search_count(domain, limit=1)
            // 
            // if existing_alias:
            //     alias_name = f"{alias_name}-{vals.get('code')}"
            // 
            // return self.env['mail.alias']._sanitize_alias_name(alias_name)
            */
            return default;
        }

        protected async Task<AccountJournal> FillBankCashDashboardDataInternalAsync(object dashboard_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _fill_bank_cash_dashboard_data(self, dashboard_data):
            //   """Populate all bank and cash journal's data dict with relevant information for the kanban card."""
            //   bank_cash_journals = self.filtered(lambda journal: journal.type in ('bank', 'cash', 'credit'))
            //   if not bank_cash_journals:
            //       return
            // 
            //   # Number to reconcile
            //   self.env.cr.execute("""
            //       SELECT st_line.journal_id,
            //              COUNT(st_line.id)
            //         FROM account_bank_statement_line st_line
            //         JOIN account_move st_line_move ON st_line_move.id = st_line.move_id
            //        WHERE st_line.journal_id IN %s
            //          AND st_line.company_id IN %s
            //          AND st_line.is_reconciled IS NOT TRUE
            //          AND st_line_move.checked IS TRUE
            //          AND st_line_move.state = 'posted'
            //     GROUP BY st_line.journal_id
            //   """, [tuple(bank_cash_journals.ids), tuple(self.env.companies.ids)])
            //   number_to_reconcile = {
            //       journal_id: count
            //       for journal_id, count in self.env.cr.fetchall()
            //   }
            // 
            //   # Last statement
            //   bank_cash_journals.last_statement_id.mapped(lambda s: s.balance_end_real)  # prefetch
            // 
            //   outstanding_pay_account_balances = bank_cash_journals._get_journal_dashboard_outstanding_payments()
            // 
            //   # Payment with method outstanding account == journal default account
            //   direct_payment_balances = bank_cash_journals._get_direct_bank_payments()
            // 
            //   # Misc Entries (journal items in the default_account not linked to bank.statement.line)
            //   misc_domain = []
            //   for journal in bank_cash_journals:
            //       date_limit = journal.last_statement_id.date or journal.company_id.fiscalyear_lock_date
            //       misc_domain.append(
            //           [('account_id', '=', journal.default_account_id.id), ('date', '>', date_limit)]
            //           if date_limit else
            //           [('account_id', '=', journal.default_account_id.id)]
            //       )
            //   misc_domain = [
            //       *self.env['account.move.line']._check_company_domain(self.env.companies),
            //       ('statement_line_id', '=', False),
            //       ('parent_state', '=', 'posted'),
            //       ('payment_id', '=', False),
            // ] + Domain.OR(misc_domain)
            // 
            //   misc_totals = {
            //       account: (balance, count_lines, currencies)
            //       for account, balance, count_lines, currencies in self.env['account.move.line']._read_group(
            //           domain=misc_domain,
            //           aggregates=['amount_currency:sum', 'id:count', 'currency_id:recordset'],
            //           groupby=['account_id'])
            //   }
            // 
            //   # To check
            //   to_check = {
            //       journal: (amount, count)
            //       for journal, amount, count in self.env['account.bank.statement.line']._read_group(
            //           domain=[
            //               ('journal_id', 'in', bank_cash_journals.ids),
            //               ('move_id.company_id', 'in', self.env.companies.ids),
            //               ('move_id.checked', '=', False),
            //               ('move_id.state', '=', 'posted'),
            //           ],
            //           groupby=['journal_id'],
            //           aggregates=['amount:sum', '__count'],
            //       )
            //   }
            // 
            //   for journal in bank_cash_journals:
            //       # User may have read access on the journal but not on the company
            //       currency = journal.currency_id or self.env['res.currency'].browse(journal.company_id.sudo().currency_id.id)
            //       has_outstanding, outstanding_pay_account_balance = outstanding_pay_account_balances[journal.id]
            //       to_check_balance, number_to_check = to_check.get(journal, (0, 0))
            //       misc_balance, number_misc, misc_currencies = misc_totals.get(journal.default_account_id, (0, 0, currency))
            //       currency_consistent = misc_currencies == currency
            //       accessible = journal.company_id.id in journal.company_id._accessible_branches().ids
            //       nb_direct_payments, direct_payments_balance = direct_payment_balances[journal.id]
            //       drag_drop_settings = {
            //           'image': '/account/static/src/img/bank.svg' if journal.type in ('bank', 'credit') else '/web/static/img/rfq.svg',
            //           'text': _('Drop to import transactions'),
            //       }
            //       last_statement_visible = (
            //           not journal.company_id.fiscalyear_lock_date
            //           or journal.last_statement_id.date
            //           and journal.company_id.fiscalyear_lock_date < journal.last_statement_id.date
            //       )
            // 
            //       dashboard_data[journal.id].update({
            //           'number_to_check': number_to_check,
            //           'to_check_balance': currency.format(to_check_balance),
            //           'number_to_reconcile': number_to_reconcile.get(journal.id, 0),
            //           'account_balance': currency.format(journal.current_statement_balance + direct_payments_balance),
            //           'has_at_least_one_statement': bool(journal.last_statement_id),
            //           'nb_lines_bank_account_balance': (bool(journal.has_statement_lines) or bool(nb_direct_payments)) and accessible,
            //           'outstanding_pay_account_balance': currency.format(outstanding_pay_account_balance),
            //           'nb_lines_outstanding_pay_account_balance': has_outstanding,
            //           'last_balance': currency.format(journal.last_statement_id.balance_end_real),
            //           'last_statement_id': journal.last_statement_id.id,
            //           'last_statement_visible': last_statement_visible,
            //           'has_invalid_statements': journal.has_invalid_statements,
            //           'bank_statements_source': journal.bank_statements_source,
            //           'is_sample_data': journal.has_statement_lines,
            //           'nb_misc_operations': number_misc,
            //           'misc_class': 'text-warning' if not currency_consistent else '',
            //           'misc_operations_balance': currency.format(misc_balance) if currency_consistent else None,
            //           'drag_drop_settings': drag_drop_settings,
            //       })
            */
            return default;
        }

        protected async Task<AccountJournal> FillDashboardDataCountInternalAsync(object dashboard_data, object model, object name, object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _fill_dashboard_data_count(self, dashboard_data, model, name, domain):
            // """Populate the dashboard data with the result of a count.
            // 
            // :param dashboard_data: a mapping between a journal ids and the data needed to display their
            //                        dashboard kanban card.
            // :type dashboard_data: dict[int, dict]
            // :param model: the model on which to perform the count
            // :type model: str
            // :param name: the name of the variable to inject in the dashboard's data
            // :type name: str
            // :param domain: the domain of records to count
            // """
            // res = {
            //     journal.id: count
            //     for journal, count in self.env[model]._read_group(
            //         domain=Domain.AND((
            //             self.env[model]._check_company_domain(self.env.companies),
            //             Domain('journal_id', 'in', self.ids),
            //             domain,
            //         )),
            //         groupby=['journal_id'],
            //         aggregates=['__count'],
            //     )
            // }
            // for journal in self:
            //     dashboard_data[journal.id][name] = res.get(journal.id, 0)
            */
            return default;
        }

        protected async Task<AccountJournal> FillGeneralDashboardDataInternalAsync(object dashboard_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _fill_general_dashboard_data(self, dashboard_data):
            // """Populate all miscelaneous journal's data dict with relevant information for the kanban card."""
            // general_journals = self.filtered(lambda journal: journal.type == 'general')
            // if not general_journals:
            //     return
            // draft_vals = {
            //     journal.id: count
            //     for journal, count in self.env['account.move']._read_group(
            //         domain=[
            //             *self.env['account.move']._check_company_domain(self.env.companies),
            //             ('journal_id', 'in', general_journals.ids),
            //             ('state', '=', 'draft'),
            //             ('auto_post', '=', 'no'),
            //         ],
            //         groupby=['journal_id'],
            //         aggregates=['__count'],
            //     )
            // }
            // for journal in general_journals:
            //     drag_drop_settings = {
            //         'image': '/web/static/img/folder.svg',
            //         'text': _('Drop to create journal entries with attachments.'),
            //         'group': 'account.group_account_user',
            //     }
            // 
            //     dashboard_data[journal.id].update({
            //         'number_draft': draft_vals.get(journal.id, 0),
            //         'drag_drop_settings': drag_drop_settings,
            //     })
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountJournal> FillMissingValuesInternalAsync(object vals, object protected_codes)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _fill_missing_values(self, vals, protected_codes=False):
            // journal_type = vals.get('type')
            // is_import = 'import_file' in self.env.context
            // if is_import and not journal_type:
            //     vals['type'] = journal_type = 'general'
            // 
            // # 'type' field is required.
            // if not journal_type:
            //     return
            // 
            // # === Fill missing company ===
            // company = self.env['res.company'].browse(vals['company_id']) if vals.get('company_id') else self.env.company
            // vals['company_id'] = company.id
            // 
            // if journal_type in ('bank', 'cash'):
            //     has_liquidity_accounts = vals.get('default_account_id')
            //     has_profit_account = vals.get('profit_account_id')
            //     has_loss_account = vals.get('loss_account_id')
            // 
            //     # === Fill missing name ===
            //     vals['name'] = vals.get('name') or vals.get('bank_acc_number') or vals.get('name_placeholder')
            // 
            //     # === Fill missing accounts ===
            //     if not has_liquidity_accounts:
            //         vals['default_account_id'] = self._create_default_account(company, journal_type, vals)
            //     if journal_type in ('cash', 'bank') and not has_profit_account:
            //         vals['profit_account_id'] = company.default_cash_difference_income_account_id.id
            //     if journal_type in ('cash', 'bank') and not has_loss_account:
            //         vals['loss_account_id'] = company.default_cash_difference_expense_account_id.id
            // 
            // if journal_type == 'credit':
            //     if not vals.get('default_account_id'):
            //         default_account_id = self.env['account.account'].with_company(company).search([
            //                 *self.env['account.account']._check_company_domain(company),
            //                 ('account_type', '=', 'liability_credit_card'),
            //             ],
            //             limit=1,
            //         ).id
            //         if not default_account_id:
            //             default_account_id = self._create_default_account(company, journal_type, vals)
            //         vals['default_account_id'] = default_account_id
            // 
            // if is_import and not vals.get('code'):
            //     code = vals['name'][:5]
            //     vals['code'] = code if not protected_codes or code not in protected_codes else self._get_next_journal_default_code(journal_type, company, protected_codes)
            //     if not vals['code']:
            //         raise UserError(_("Cannot generate an unused journal code. Please change the name for journal %s.", vals['name']))
            // 
            // # === Fill missing alias name for sale / purchase, to force alias creation ===
            // if journal_type in {'sale', 'purchase'}:
            //     if 'alias_name' not in vals:
            //         vals['alias_name'] = self._alias_prepare_alias_name(
            //         False, vals.get('name'), vals.get('code'), journal_type, company
            //     )
            //     vals['alias_name'] = self._ensure_unique_alias(vals, company)
            // 
            // if not vals.get('name') and vals.get('name_placeholder'):
            //     vals['name'] = vals['name_placeholder']
            */
            return default;
        }

        protected async Task<AccountJournal> FillOnboardingDataInternalAsync(object dashboard_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _fill_onboarding_data(self, dashboard_data):
            // """ Populate journals with onboarding data if they have no entries"""
            // journal_onboarding_map = {
            //     'sale': 'account_invoice',
            //     'general': 'account_dashboard',
            // }
            // onboarding_data = defaultdict(dict)
            // onboarding_progresses = self.env['onboarding.progress'].sudo().search([
            //     ('onboarding_id.route_name', 'in', [*journal_onboarding_map.values()]),
            //     ('company_id', 'in', self.company_id.ids),
            // ])
            // for progress in onboarding_progresses:
            //     ob = progress.onboarding_id
            //     ob_vals = ob.with_company(progress.company_id)._prepare_rendering_values()
            //     onboarding_data[progress.company_id][ob.route_name] = ob_vals
            //     onboarding_data[progress.company_id][ob.route_name]['current_onboarding_state'] = ob.current_onboarding_state
            //     onboarding_data[progress.company_id][ob.route_name]['steps'] = [
            //         {
            //             'id': step.id,
            //             'title': step.title,
            //             'description': step.description,
            //             'state': ob_vals['state'][step.id],
            //             'action': step.panel_step_open_action_name,
            //         }
            //         for step in ob_vals['steps']
            //     ]
            // for journal in self:
            //     dashboard_data[journal.id]['onboarding'] = onboarding_data[journal.company_id].get(journal_onboarding_map.get(journal.type))
            */
            return default;
        }

        protected async Task<AccountJournal> FillSalePurchaseDashboardDataInternalAsync(object dashboard_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _fill_sale_purchase_dashboard_data(self, dashboard_data):
            // """Populate all sale and purchase journal's data dict with relevant information for the kanban card."""
            // sale_purchase_journals = self.filtered(lambda journal: journal.type in ('sale', 'purchase'))
            // purchase_journals = self.filtered(lambda journal: journal.type == 'purchase')
            // sale_journals = self.filtered(lambda journal: journal.type == 'sale')
            // if not sale_purchase_journals:
            //     return
            // bills_field_list = [
            //     "account_move.journal_id",
            //     "(CASE WHEN account_move.move_type IN ('out_refund', 'in_refund') THEN -1 ELSE 1 END) * account_move.amount_total AS amount_total",
            //     "(CASE WHEN account_move.move_type IN ('in_invoice', 'in_refund', 'in_receipt') THEN -1 ELSE 1 END) * account_move.amount_total_signed AS amount_total_company",
            //     "account_move.currency_id AS currency",
            //     "account_move.move_type",
            //     "account_move.invoice_date",
            //     "account_move.company_id",
            // ]
            // # DRAFTS
            // sql = sale_purchase_journals._get_draft_sales_purchases_query().select(*bills_field_list)
            // query_results_drafts = group_by_journal(self.env.execute_query_dict(sql))
            // 
            // # WAITING AND LATE BILLS AND PAYMENTS
            // query_results_to_pay = {}
            // late_query_results = {}
            // for journal_type, journals in [('sale', sale_journals), ('purchase', purchase_journals)]:
            //     if not journals:
            //         continue
            // 
            //     query, selects = journals._get_open_sale_purchase_query(journal_type)
            //     sql = SQL("""%s
            //             GROUP BY account_move.company_id, account_move.journal_id, account_move.currency_id, late, to_pay""",
            //               query.select(*selects),
            //     )
            //     self.env.cr.execute(sql)
            //     query_result = group_by_journal(self.env.cr.dictfetchall())
            //     for journal in journals:
            //         query_results_to_pay[journal.id] = [r for r in query_result[journal.id] if r['to_pay']]
            //         late_query_results[journal.id] = [r for r in query_result[journal.id] if r['late']]
            // 
            // query, selects = sale_purchase_journals._get_to_check_payment_query()
            // sql = SQL("""%s
            //         GROUP BY account_move.company_id, account_move.journal_id, account_move.currency_id, late, to_pay""",
            //           query.select(*selects),
            //           )
            // self.env.cr.execute(sql)
            // to_check_vals = group_by_journal(self.env.cr.dictfetchall())
            // 
            // self.env.cr.execute(SQL("""
            //     SELECT id, moves_exists
            //     FROM account_journal journal
            //     LEFT JOIN LATERAL (
            //         SELECT EXISTS(SELECT 1
            //                       FROM account_move move
            //                       WHERE move.journal_id = journal.id
            //                       AND move.company_id = ANY (%(companies_ids)s) AND
            //                           move.journal_id = ANY (%(journal_ids)s)) AS moves_exists
            //     ) moves ON TRUE
            //     WHERE journal.id = ANY (%(journal_ids)s);
            // """,
            //     journal_ids=sale_purchase_journals.ids,
            //     companies_ids=self.env.companies.ids,
            // ))
            // is_sample_data_by_journal_id = {row[0]: not row[1] for row in self.env.cr.fetchall()}
            // 
            // for journal in sale_purchase_journals:
            //     # User may have read access on the journal but not on the company
            //     currency = journal.currency_id or self.env['res.currency'].browse(journal.company_id.sudo().currency_id.id)
            //     (number_waiting, sum_waiting) = self._count_results_and_sum_amounts(query_results_to_pay[journal.id], currency)
            //     (number_draft, sum_draft) = self._count_results_and_sum_amounts(query_results_drafts[journal.id], currency)
            //     (number_late, sum_late) = self._count_results_and_sum_amounts(late_query_results[journal.id], currency)
            //     (number_to_check, sum_to_check) = self._count_results_and_sum_amounts(to_check_vals[journal.id], currency)
            // 
            //     if journal.type == 'purchase':
            //         title_has_sequence_holes = _("Irregularities due to draft, cancelled or deleted bills with a sequence number since last lock date.")
            //         drag_drop_settings = {
            //             'image': '/account/static/src/img/bill.svg',
            //             'text': _('Drop and let the AI process your bills automatically.'),
            //         }
            //     else:
            //         title_has_sequence_holes = _("Irregularities due to draft, cancelled or deleted invoices with a sequence number since last lock date.")
            //         drag_drop_settings = {
            //             'image': '/web/static/img/quotation.svg',
            //             'text': _('Drop to import your invoices.'),
            //         }
            // 
            //     dashboard_data[journal.id].update({
            //         'number_to_check': number_to_check,
            //         'to_check_balance': currency.format(sum_to_check),
            //         'title': _('Bills to pay') if journal.type == 'purchase' else _('Invoices owed to you'),
            //         'number_draft': number_draft,
            //         'number_waiting': number_waiting,
            //         'number_late': number_late,
            //         'sum_draft': currency.format(sum_draft),  # sign is already handled by the SQL query
            //         'sum_waiting': currency.format(sum_waiting * (1 if journal.type == 'sale' else -1)),
            //         'sum_late': currency.format(sum_late * (1 if journal.type == 'sale' else -1)),
            //         'has_sequence_holes': journal.has_sequence_holes,
            //         'title_has_sequence_holes': title_has_sequence_holes,
            //         'has_unhashed_entries': journal.has_unhashed_entries,
            //         'is_sample_data': is_sample_data_by_journal_id[journal.id],
            //         'has_entries': not is_sample_data_by_journal_id[journal.id],
            //         'drag_drop_settings': drag_drop_settings,
            //     })
            */
            return default;
        }

        protected async Task<AccountJournal> GetAvailablePaymentMethodLinesInternalAsync(object payment_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _get_available_payment_method_lines(self, payment_type):
            // """
            // This getter is here to allow filtering the payment method lines if needed in other modules.
            // It does NOT serve as a general getter to get the lines.
            // 
            // For example, it'll be extended to filter out lines from inactive payment providers in the payment module.
            // :param payment_type: either inbound or outbound, used to know which lines to return
            // :return: Either the inbound or outbound payment method lines
            // """
            // if not self:
            //     return self.env['account.payment.method.line']
            // self.ensure_one()
            // if payment_type == 'inbound':
            //     return self.inbound_payment_method_line_ids
            // else:
            //     return self.outbound_payment_method_line_ids
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: account_journal.py) ---
            // def _get_available_payment_method_lines(self, payment_type):
            // lines = super()._get_available_payment_method_lines(payment_type)
            // 
            // return lines.filtered(lambda l: l.payment_provider_state != 'disabled')
            */
            return default;
        }

        protected async Task<AccountJournal> GetBankCashGraphDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _get_bank_cash_graph_data(self):
            // """Computes the data used to display the graph for bank and cash journals in the accounting dashboard"""
            // def build_graph_data(date, amount, currency):
            //     #display date in locale format
            //     name = format_date(date, 'd LLLL Y', locale=locale)
            //     short_name = format_date(date, 'd MMM', locale=locale)
            //     return {'x': short_name, 'y': currency.round(amount), 'name': name}
            // 
            // today = datetime.today()
            // last_month = today + timedelta(days=-30)
            // locale = get_lang(self.env).code
            // 
            // query = """
            //     SELECT move.journal_id,
            //            move.date,
            //            SUM(st_line.amount) AS amount
            //       FROM account_bank_statement_line st_line
            //       JOIN account_move move ON move.id = st_line.move_id
            //      WHERE move.journal_id = ANY(%s)
            //        AND move.date > %s
            //        AND move.company_id = ANY(%s)
            //   GROUP BY move.date, move.journal_id
            //   ORDER BY move.date DESC
            // """
            // self.env.cr.execute(query, (self.ids, last_month, self.env.companies.ids))
            // query_result = group_by_journal(self.env.cr.dictfetchall())
            // 
            // result = {}
            // for journal in self:
            //     graph_title, graph_key = journal._graph_title_and_key()
            //     # User may have read access on the journal but not on the company
            //     currency = journal.currency_id or self.env['res.currency'].browse(journal.company_id.sudo().currency_id.id)
            //     journal_result = query_result[journal.id]
            // 
            //     color = '#875A7B' if 'e' in version else '#7c7bad'
            //     is_sample_data = not journal_result and not journal.has_statement_lines
            // 
            //     data = []
            //     if is_sample_data:
            //         for i in range(30, 0, -5):
            //             current_date = today + timedelta(days=-i)
            //             data.append(build_graph_data(current_date, random.randint(-5, 15), currency))
            //             graph_key = _('Sample data')
            //     else:
            //         last_balance = journal.current_statement_balance
            //         # Make sure the last point in the graph is at least today or a future date
            //         if not journal_result or journal_result[0]['date'] < today.date():
            //             data.append(build_graph_data(today, last_balance, currency))
            //         date = today
            //         amount = last_balance
            //         #then we subtract the total amount of bank statement lines per day to get the previous points
            //         #(graph is drawn backward)
            //         for val in journal_result:
            //             date = val['date']
            //             data[:0] = [build_graph_data(date, amount, currency)]
            //             amount -= val['amount']
            // 
            //         # make sure the graph starts 1 month ago
            //         if date.strftime(DF) != last_month.strftime(DF):
            //             data[:0] = [build_graph_data(last_month, amount, currency)]
            // 
            //     result[journal.id] = [{'values': data, 'title': graph_title, 'key': graph_key, 'area': True, 'color': color, 'is_sample_data': is_sample_data}]
            // return result
            */
            return default;
        }

        protected async Task<AccountJournal> GetBankStatementsAvailableSourcesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _get_bank_statements_available_sources(self):
            // return self.__get_bank_statements_available_sources()
            */
            return default;
        }

        protected async Task<AccountJournal> GetCheckPrintingLayoutsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_check_printing, FILE: account_journal.py) ---
            // def _get_check_printing_layouts(self):
            // """ Returns available check printing layouts for the company, excluding disabled options """
            // selection = self.company_id._fields['account_check_printing_layout'].selection
            // return [(value, label) for value, label in selection if value != 'disabled']
            */
            return default;
        }

        protected async Task<AccountJournal> GetDefaultAccountDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _get_default_account_domain(self):
            // return """[
            //     ('account_type', 'in', ('asset_cash', 'liability_credit_card') if type == 'bank'
            //                            else ('liability_credit_card',) if type == 'credit'
            //                            else ('asset_cash',) if type == 'cash'
            //                            else ('income', 'income_other') if type == 'sale'
            //                            else ('expense', 'expense_depreciation', 'expense_direct_cost') if type == 'purchase'
            //                            else ('asset_receivable', 'asset_cash', 'asset_current', 'asset_non_current',
            //                                  'asset_prepayments', 'asset_fixed', 'liability_payable',
            //                                  'liability_credit_card', 'liability_current', 'liability_non_current',
            //                                  'equity', 'equity_unaffected', 'income', 'income_other', 'expense',
            //                                  'expense_depreciation', 'expense_direct_cost', 'off_balance'))
            // ]"""
            */
            return default;
        }

        protected async Task<AccountJournal> GetDirectBankPaymentsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _get_direct_bank_payments(self):
            // self.env.cr.execute("""
            //     SELECT move.journal_id AS journal_id,
            //            move.company_id AS company_id,
            //            move.currency_id AS currency,
            //            SUM(CASE
            //                WHEN payment.payment_type = 'outbound' THEN -payment.amount
            //                ELSE payment.amount
            //            END) AS amount_total,
            //            SUM(amount_company_currency_signed) AS amount_total_company
            //       FROM account_payment payment
            //       JOIN account_move move ON move.origin_payment_id = payment.id
            //       JOIN account_journal journal ON move.journal_id = journal.id
            //      WHERE payment.is_matched IS TRUE
            //        AND move.state = 'posted'
            //        AND payment.journal_id = ANY(%s)
            //        AND payment.company_id = ANY(%s)
            //        AND payment.outstanding_account_id = journal.default_account_id
            //   GROUP BY move.company_id, move.journal_id, move.currency_id
            // """, [self.ids, self.env.companies.ids])
            // query_result = group_by_journal(self.env.cr.dictfetchall())
            // result = {}
            // for journal in self:
            //     # User may have read access on the journal but not on the company
            //     currency = (journal.currency_id or journal.company_id.sudo().currency_id).with_env(self.env)
            //     result[journal.id] = self._count_results_and_sum_amounts(query_result[journal.id], currency)
            // return result
            */
            return default;
        }

        protected async Task<AccountJournal> GetDraftSalesPurchasesQueryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _get_draft_sales_purchases_query(self):
            // return self.env['account.move']._search([
            //     *self.env['account.move']._check_company_domain(self.env.companies),
            //     ('journal_id', 'in', self.ids),
            //     ('state', '=', 'draft'),
            //     ('move_type', 'in', self.env['account.move'].get_invoice_types(include_receipts=True)),
            // ], bypass_access=True)
            */
            return default;
        }

        protected async Task<AccountJournal> GetJournalBankAccountBalanceInternalAsync(object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _get_journal_bank_account_balance(self, domain=None):
            // r''' Get the bank balance of the current journal by filtering the journal items using the journal's accounts.
            // 
            // /!\ The current journal is not part of the applied domain. This is the expected behavior since we only want
            // a logic based on accounts.
            // 
            // :param domain:  An additional domain to be applied on the account.move.line model.
            // :return:        Tuple having balance expressed in journal's currency
            //                 along with the total number of move lines having the same account as of the journal's default account.
            // '''
            // self.ensure_one()
            // nb_lines, balance, amount_currency = self.env['account.move.line']._read_group(
            //     domain=([
            //         ('account_id', 'in', tuple(self.default_account_id.ids)),
            //         ('display_type', 'not in', ('line_section', 'line_subsection', 'line_note')),
            //         ('parent_state', '!=', 'cancel'),
            //     ] + (domain or [])),
            //     aggregates=('__count', 'balance:sum', 'amount_currency:sum'),
            // )[0]
            // 
            // company_currency = self.company_id.currency_id
            // journal_currency = self.currency_id if self.currency_id and self.currency_id != company_currency else False
            // return amount_currency if journal_currency else balance, nb_lines
            */
            return default;
        }

        protected async Task<AccountJournal> GetJournalDashboardBankRunningBalanceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _get_journal_dashboard_bank_running_balance(self):
            // # In order to not recompute everything from the start, we take the last
            // # bank statement and only sum starting from there.
            // self.env.cr.execute("""
            //     SELECT journal.id AS journal_id,
            //            statement.id AS statement_id,
            //            COALESCE(statement.balance_end_real, 0) AS balance_end_real,
            //            without_statement.amount AS unlinked_amount,
            //            without_statement.count AS unlinked_count
            //       FROM account_journal journal
            //  LEFT JOIN LATERAL (  -- select latest statement based on the date
            //                    SELECT id,
            //                           first_line_index,
            //                           balance_end_real
            //                      FROM account_bank_statement
            //                     WHERE journal_id = journal.id
            //                       AND company_id = ANY(%s)
            //                       AND first_line_index IS NOT NULL
            //                  ORDER BY date DESC, id DESC
            //                     LIMIT 1
            //            ) statement ON TRUE
            //  LEFT JOIN LATERAL (  -- sum all the lines not linked to a statement with a higher index than the last line of the statement
            //                    SELECT COALESCE(SUM(stl.amount), 0.0) AS amount,
            //                           COUNT(*)
            //                      FROM account_bank_statement_line stl
            //                      JOIN account_move move ON move.id = stl.move_id
            //                     WHERE stl.statement_id IS NULL
            //                       AND move.state != 'cancel'
            //                       AND stl.journal_id = journal.id
            //                       AND stl.company_id = ANY(%s)
            //                       AND stl.internal_index >= COALESCE(statement.first_line_index, '')
            //                     LIMIT 1
            //            ) without_statement ON TRUE
            //      WHERE journal.id = ANY(%s)
            // """, [self.env.companies.ids, self.env.companies.ids, self.ids])
            // query_res = {res['journal_id']: res for res in self.env.cr.dictfetchall()}
            // result = {}
            // for journal in self:
            //     journal_vals = query_res[journal.id]
            //     result[journal.id] = (
            //         bool(journal_vals['statement_id'] or journal_vals['unlinked_count']),
            //         journal_vals['balance_end_real'] + journal_vals['unlinked_amount'],
            //     )
            // return result
            */
            return default;
        }

        protected async Task<AccountJournal> GetJournalDashboardDataBatchedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _get_journal_dashboard_data_batched(self):
            // self.env['account.move'].flush_model()
            // self.env['account.move.line'].flush_model()
            // self.env['account.payment'].flush_model()
            // dashboard_data = {}  # container that will be filled by functions below
            // for journal in self:
            //     dashboard_data[journal.id] = {
            //         'currency_id': journal.currency_id.id or journal.company_id.sudo().currency_id.id,
            //         'show_company': len(self.env.companies) > 1 or journal.company_id.id != self.env.company.id,
            //         'company_name': journal.company_id.name,
            //     }
            // self._fill_bank_cash_dashboard_data(dashboard_data)
            // self._fill_sale_purchase_dashboard_data(dashboard_data)
            // self._fill_general_dashboard_data(dashboard_data)
            // self._fill_onboarding_data(dashboard_data)
            // return dashboard_data
            --- ODOO METHOD SOURCE (MODULE: account_check_printing, FILE: account_journal.py) ---
            // def _get_journal_dashboard_data_batched(self):
            // dashboard_data = super()._get_journal_dashboard_data_batched()
            // self._fill_dashboard_data_count(dashboard_data, 'account.payment', 'num_checks_to_print', [
            //     ('payment_method_line_id.code', '=', 'check_printing'),
            //     ('state', '=', 'in_process'),
            //     ('is_sent', '=', False),
            // ])
            // return dashboard_data
            */
            return default;
        }

        protected async Task<AccountJournal> GetJournalDashboardOutstandingPaymentsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _get_journal_dashboard_outstanding_payments(self):
            // self.env.cr.execute("""
            //     SELECT payment.journal_id AS journal_id,
            //            payment.company_id AS company_id,
            //            payment.currency_id AS currency,
            //            SUM(CASE
            //                WHEN payment.payment_type = 'outbound' THEN -payment.amount
            //                ELSE payment.amount
            //            END) AS amount_total,
            //            SUM(amount_company_currency_signed) AS amount_total_company
            //       FROM account_payment payment
            //       JOIN account_move move ON move.origin_payment_id = payment.id
            //      WHERE payment.is_matched IS NOT TRUE
            //        AND move.state = 'posted'
            //        AND payment.journal_id = ANY(%s)
            //        AND payment.company_id = ANY(%s)
            //   GROUP BY payment.company_id, payment.journal_id, payment.currency_id
            // """, [self.ids, self.env.companies.ids])
            // query_result = group_by_journal(self.env.cr.dictfetchall())
            // result = {}
            // for journal in self:
            //     # User may have read access on the journal but not on the company
            //     currency = journal.currency_id or self.env['res.currency'].browse(journal.company_id.sudo().currency_id.id)
            //     result[journal.id] = self._count_results_and_sum_amounts(query_result[journal.id], currency)
            // return result
            */
            return default;
        }

        protected async Task<AccountJournal> GetJournalInboundOutstandingPaymentAccountsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _get_journal_inbound_outstanding_payment_accounts(self):
            // """
            // :return: A recordset with all the account.account used by this journal for inbound transactions.
            // """
            // self.ensure_one()
            // account_ids = set()
            // for line in self.inbound_payment_method_line_ids:
            //     account_ids.add(line.payment_account_id.id)
            // return self.env['account.account'].browse(account_ids)
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: account_journal.py) ---
            // def _get_journal_inbound_outstanding_payment_accounts(self):
            // res = super()._get_journal_inbound_outstanding_payment_accounts()
            // account_ids = set(res.ids)
            // for payment_method in self.sudo().pos_payment_method_ids:
            //     account_ids.add(payment_method.outstanding_account_id.id)
            // return self.env['account.account'].browse(account_ids)
            */
            return default;
        }

        protected async Task<AccountJournal> GetJournalNotificationUnsubscribeScopeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _get_journal_notification_unsubscribe_scope(self):
            // return 'account_journal_notification_unsubscribe'
            */
            return default;
        }

        protected async Task<AccountJournal> GetJournalOutboundOutstandingPaymentAccountsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _get_journal_outbound_outstanding_payment_accounts(self):
            // """
            // :return: A recordset with all the account.account used by this journal for outbound transactions.
            // """
            // self.ensure_one()
            // account_ids = set()
            // for line in self.outbound_payment_method_line_ids:
            //     account_ids.add(line.payment_account_id.id)
            // return self.env['account.account'].browse(account_ids)
            */
            return default;
        }

        protected async Task<AccountJournal> GetJournalsPaymentMethodInformationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _get_journals_payment_method_information(self):
            // method_information = self.env['account.payment.method']._get_payment_method_information()
            // unique_electronic_ids = set()
            // electronic_names = set()
            // pay_methods = self.env['account.payment.method'].sudo().search([('code', 'in', list(method_information.keys()))])
            // manage_providers = 'payment_provider_id' in self.env['account.payment.method.line']._fields
            // 
            // # Split the payment method information per id.
            // method_information_mapping = {}
            // for pay_method in pay_methods:
            //     code = pay_method.code
            //     values = method_information_mapping[pay_method.id] = {
            //         **method_information[code],
            //         'payment_method': pay_method,
            //         'company_journals': {},
            //     }
            //     if values['mode'] == 'unique':
            //         unique_electronic_ids.add(pay_method.id)
            //     elif manage_providers and values['mode'] == 'electronic':
            //         unique_electronic_ids.add(pay_method.id)
            //         electronic_names.add(pay_method.code)
            // 
            // # Load the provider to manage 'electronic' payment methods.
            // providers_per_code = {}
            // if manage_providers:
            //     providers = self.env['payment.provider'].sudo().search([
            //         *self.env['payment.provider']._check_company_domain(self.company_id),
            //         ('code', 'in', tuple(electronic_names)),
            //     ])
            //     for provider in providers:
            //         providers_per_code.setdefault(provider.company_id.id, {}).setdefault(provider._get_code(), set()).add(provider.id)
            // 
            // # Collect the existing unique/electronic payment method lines.
            // if unique_electronic_ids:
            //     fnames = ['payment_method_id', 'journal_id']
            //     if manage_providers:
            //         fnames.append('payment_provider_id')
            //     self.env['account.payment.method.line'].flush_model(fnames=fnames)
            // 
            //     self.env.cr.execute(
            //         f'''
            //             SELECT
            //                 apm.id,
            //                 journal.company_id,
            //                 journal.id,
            //                 {'apml.payment_provider_id' if manage_providers else 'NULL'}
            //             FROM account_payment_method_line apml
            //             JOIN account_journal journal ON journal.id = apml.journal_id
            //             JOIN account_payment_method apm ON apm.id = apml.payment_method_id
            //             WHERE apm.id IN %s
            //         ''',
            //         [tuple(unique_electronic_ids)],
            //     )
            //     for pay_method_id, company_id, journal_id, provider_id in self.env.cr.fetchall():
            //         values = method_information_mapping[pay_method_id]
            //         is_electronic = manage_providers and values['mode'] == 'electronic'
            //         if is_electronic:
            //             journal_ids = values['company_journals'].setdefault(company_id, {}).setdefault(provider_id, [])
            //         else:
            //             journal_ids = values['company_journals'].setdefault(company_id, [])
            //         journal_ids.append(journal_id)
            // return {
            //     'pay_methods': pay_methods,
            //     'manage_providers': manage_providers,
            //     'method_information_mapping': method_information_mapping,
            //     'providers_per_code': providers_per_code,
            // }
            */
            return default;
        }

        protected async Task<AccountJournal> GetJsonActivityDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _get_json_activity_data(self):
            //   today = fields.Date.context_today(self)
            //   activities = defaultdict(list)
            //   # search activity on move on the journal
            //   act_type_name = self.env['mail.activity.type']._field_to_sql('act_type', 'name')
            //   sql_query = SQL(
            //       """
            //    SELECT activity.id,
            //           activity.res_id,
            //           activity.res_model,
            //           activity.summary,
            // CASE WHEN activity.date_deadline < %(today)s THEN 'late' ELSE 'future' END as status,
            //           act_type.id as act_type_id,
            //           %(act_type_name)s as act_type_name,
            //           act_type.category as activity_category,
            //           activity.date_deadline,
            //           move.journal_id
            //      FROM account_move move
            //      JOIN mail_activity activity ON activity.res_id = move.id AND activity.res_model = 'account.move'
            // LEFT JOIN mail_activity_type act_type ON activity.activity_type_id = act_type.id
            //     WHERE move.journal_id = ANY(%(ids)s)
            //       AND move.company_id = ANY(%(company_ids)s)
            // 
            // UNION ALL
            // 
            //    SELECT activity.id,
            //           activity.res_id,
            //           activity.res_model,
            //           activity.summary,
            // CASE WHEN activity.date_deadline < %(today)s THEN 'late' ELSE 'future' END as status,
            //           act_type.id as act_type_id,
            //           %(act_type_name)s as act_type_name,
            //           act_type.category as activity_category,
            //           activity.date_deadline,
            //           journal.id as journal_id
            //      FROM account_journal journal
            //      JOIN mail_activity activity ON activity.res_id = journal.id AND activity.res_model = 'account.journal'
            // LEFT JOIN mail_activity_type act_type ON activity.activity_type_id = act_type.id
            //     WHERE journal.id = ANY(%(ids)s)
            //       AND journal.company_id = ANY(%(company_ids)s)
            //       """,
            //       today=today,
            //       act_type_name=act_type_name,
            //       ids=self.ids,
            //       company_ids=self.env.companies.ids,
            //   )
            //   self.env.cr.execute(sql_query)
            //   for activity_data in self.env.cr.dictfetchall():
            //       activities[activity_data['journal_id']].append(self._transform_activity_dict(activity_data))
            //   for journal in self:
            //       journal.json_activity_data = json.dumps({'activities': activities[journal.id]})
            */
            return default;
        }

        protected async Task<AccountJournal> GetMoveActionContextInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _get_move_action_context(self):
            // ctx = self.env.context.copy()
            // journal = self
            // if not ctx.get('default_journal_id'):
            //     ctx['default_journal_id'] = journal.id
            // elif not journal:
            //     journal = self.browse(ctx['default_journal_id'])
            // if journal.type == 'sale':
            //     ctx['default_move_type'] = 'out_refund' if ctx.get('refund') else 'out_invoice'
            // elif journal.type == 'purchase':
            //     ctx['default_move_type'] = 'in_refund' if ctx.get('refund') else 'in_invoice'
            // else:
            //     ctx['default_move_type'] = 'entry'
            //     ctx['view_no_maturity'] = True
            // return ctx
            */
            return default;
        }

        protected async Task<AccountJournal> GetMovesToHashInternalAsync(object include_pre_last_hash, object early_stop)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _get_moves_to_hash(self, include_pre_last_hash, early_stop):
            // """
            // If we have INV/1, INV/2 not hashed, then INV/3, INV/4 hashed, then INV/5 and INV/6 not hashed
            // :param include_pre_last_hash: if True, this will include INV/1 and INV/2. Otherwise not.
            // :param early_stop: if True, stop searching when we found at least one record
            // :return:
            // """
            // return self.env['account.move'].search([
            //     ('restrict_mode_hash_table', '=', True),
            //     ('inalterable_hash', '=', False),
            //     ('journal_id', '=', self.id),
            //     ('date', '>', self.company_id._get_user_fiscal_lock_date(self)),
            // ])._get_chains_to_hash(force_hash=True, raise_if_gap=False, raise_if_no_document=False, early_stop=early_stop, include_pre_last_hash=include_pre_last_hash)
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountJournal> GetNextJournalDefaultCodeInternalAsync(object journal_type, object company, object cache, object protected_codes)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _get_next_journal_default_code(self, journal_type, company, cache=None, protected_codes=False):
            // prefix_map = {
            //     'sale': 'INV',
            //     'purchase': 'BILL',
            //     'cash': 'CSH',
            //     'bank': 'BNK',
            //     'credit': 'CCD',
            //     'general': 'MISC',
            // }
            // journal_code_base = prefix_map.get(journal_type)
            // existing_codes = set(self.env['account.journal'].with_context(active_test=False).search([
            //     *self.env['account.journal']._check_company_domain(company),
            //     ('code', '=like', journal_code_base + '%'),
            // ]).mapped('code') + (cache or []))
            // 
            // for num in range(1, 100):
            //     # journal_code has a maximal size of 5, hence we can enforce the boundary num < 100
            //     journal_code = journal_code_base + str(num)
            //     if journal_code not in existing_codes and (protected_codes and journal_code not in protected_codes or not protected_codes):
            //         return journal_code
            */
            return default;
        }

        protected async Task<AccountJournal> GetOpenSalePurchaseQueryInternalAsync(object journal_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _get_open_sale_purchase_query(self, journal_type):
            // assert journal_type in ('sale', 'purchase')
            // query = self.env['account.move']._search([
            //     *self.env['account.move']._check_company_domain(self.env.companies),
            //     ('journal_id', 'in', self.ids),
            //     ('payment_state', 'in', ('not_paid', 'partial')),
            //     ('move_type', 'in', ('out_invoice', 'out_refund') if journal_type == 'sale' else ('in_invoice', 'in_refund')),
            //     ('state', '=', 'posted'),
            // ], bypass_access=True)
            // selects = [
            //     SQL("journal_id"),
            //     SQL("company_id"),
            //     SQL("currency_id AS currency"),
            //     SQL("invoice_date_due < %s AS late", fields.Date.context_today(self)),
            //     SQL("SUM(amount_residual_signed) AS amount_total_company"),
            //     SQL("SUM((CASE WHEN move_type = 'in_invoice' THEN -1 ELSE 1 END) * amount_residual) AS amount_total"),
            //     SQL("COUNT(*)"),
            //     self._get_to_pay_select(),
            // ]
            // 
            // return query, selects
            */
            return default;
        }

        protected async Task<AccountJournal> GetSalePurchaseGraphDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _get_sale_purchase_graph_data(self):
            // today = fields.Date.today()
            // day_of_week = int(format_datetime(today, 'e', locale=get_lang(self.env).code))
            // first_day_of_week = today + timedelta(days=-day_of_week+1)
            // format_month = lambda d: format_date(d, 'MMM', locale=get_lang(self.env).code)
            // 
            // self.env.cr.execute("""
            //     SELECT move.journal_id,
            //            COALESCE(SUM(move.amount_residual_signed) FILTER (WHERE invoice_date_due < %(start_week1)s), 0) AS total_before,
            //            COALESCE(SUM(move.amount_residual_signed) FILTER (WHERE invoice_date_due >= %(start_week1)s AND invoice_date_due < %(start_week2)s), 0) AS total_week1,
            //            COALESCE(SUM(move.amount_residual_signed) FILTER (WHERE invoice_date_due >= %(start_week2)s AND invoice_date_due < %(start_week3)s), 0) AS total_week2,
            //            COALESCE(SUM(move.amount_residual_signed) FILTER (WHERE invoice_date_due >= %(start_week3)s AND invoice_date_due < %(start_week4)s), 0) AS total_week3,
            //            COALESCE(SUM(move.amount_residual_signed) FILTER (WHERE invoice_date_due >= %(start_week4)s AND invoice_date_due < %(start_week5)s), 0) AS total_week4,
            //            COALESCE(SUM(move.amount_residual_signed) FILTER (WHERE invoice_date_due >= %(start_week5)s), 0) AS total_after
            //       FROM account_move move
            //      WHERE move.journal_id = ANY(%(journal_ids)s)
            //        AND move.state = 'posted'
            //        AND move.payment_state in ('not_paid', 'partial')
            //        AND move.move_type IN %(invoice_types)s
            //        AND move.company_id = ANY(%(company_ids)s)
            //   GROUP BY move.journal_id
            // """, {
            //     'invoice_types': tuple(self.env['account.move'].get_invoice_types(True)),
            //     'journal_ids': self.ids,
            //     'company_ids': self.env.companies.ids,
            //     'start_week1': first_day_of_week + timedelta(days=-7),
            //     'start_week2': first_day_of_week + timedelta(days=0),
            //     'start_week3': first_day_of_week + timedelta(days=7),
            //     'start_week4': first_day_of_week + timedelta(days=14),
            //     'start_week5': first_day_of_week + timedelta(days=21),
            // })
            // query_results = {r['journal_id']: r for r in self.env.cr.dictfetchall()}
            // result = {}
            // for journal in self:
            //     # User may have read access on the journal but not on the company
            //     currency = journal.currency_id or self.env['res.currency'].browse(journal.company_id.sudo().currency_id.id)
            //     graph_title, graph_key = journal._graph_title_and_key()
            //     sign = 1 if journal.type == 'sale' else -1
            //     journal_data = query_results.get(journal.id)
            //     data = []
            //     data.append({'label': _('Due'), 'type': 'past'})
            //     for i in range(-1, 3):
            //         if i == 0:
            //             label = _('This Week')
            //         else:
            //             start_week = first_day_of_week + timedelta(days=i*7)
            //             end_week = start_week + timedelta(days=6)
            //             if start_week.month == end_week.month:
            //                 label = f"{start_week.day} - {end_week.day} {format_month(end_week)}"
            //             else:
            //                 label = f"{start_week.day} {format_month(start_week)} - {end_week.day} {format_month(end_week)}"
            //         data.append({'label': label, 'type': 'past' if i < 0 else 'future'})
            //     data.append({'label': _('Not Due'), 'type': 'future'})
            // 
            //     is_sample_data = not journal_data
            //     if not is_sample_data:
            //         data[0]['value'] = currency.round(sign * journal_data['total_before'])
            //         data[1]['value'] = currency.round(sign * journal_data['total_week1'])
            //         data[2]['value'] = currency.round(sign * journal_data['total_week2'])
            //         data[3]['value'] = currency.round(sign * journal_data['total_week3'])
            //         data[4]['value'] = currency.round(sign * journal_data['total_week4'])
            //         data[5]['value'] = currency.round(sign * journal_data['total_after'])
            //     else:
            //         for index in range(6):
            //             data[index]['type'] = 'o_sample_data'
            //             # we use unrealistic values for the sample data
            //             data[index]['value'] = random.randint(0, 20)
            //             graph_key = _('Sample data')
            // 
            //     result[journal.id] = [{'values': data, 'title': graph_title, 'key': graph_key, 'is_sample_data': is_sample_data}]
            // return result
            */
            return default;
        }

        protected async Task<AccountJournal> GetToCheckPaymentQueryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _get_to_check_payment_query(self):
            // query = self.env['account.move']._search([
            //     *self.env['account.move']._check_company_domain(self.env.companies),
            //     ('journal_id', 'in', self.ids),
            //     ('checked', '=', False),
            //     ('state', '=', 'posted'),
            // ])
            // selects = [
            //     SQL("journal_id"),
            //     SQL("company_id"),
            //     SQL("currency_id AS currency"),
            //     SQL("invoice_date_due < %s AS late", fields.Date.context_today(self)),
            //     SQL("SUM(amount_residual_signed) AS amount_total_company"),
            //     SQL("SUM((CASE WHEN move_type = 'in_invoice' THEN -1 ELSE 1 END) * amount_residual) AS amount_total"),
            //     SQL("COUNT(*)"),
            //     SQL("TRUE AS to_pay")
            // ]
            // return query, selects
            */
            return default;
        }

        protected async Task<AccountJournal> GetToPaySelectInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _get_to_pay_select(self):
            // return SQL("TRUE AS to_pay")
            */
            return default;
        }

        protected async Task<AccountJournal> GraphTitleAndKeyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _graph_title_and_key(self):
            // if self.type in ['sale', 'purchase']:
            //     return ['', _('Residual amount')]
            // elif self.type == 'cash':
            //     return ['', _('Cash: Balance')]
            // elif self.type == 'bank':
            //     return ['', _('Bank: Balance')]
            // elif self.type == 'credit':
            //     return ['', _('Credit Card: Balance')]
            */
            return default;
        }

        protected async Task<AccountJournal> InverseCheckNextNumberInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_check_printing, FILE: account_journal.py) ---
            // def _inverse_check_next_number(self):
            // for journal in self:
            //     next_num = int(journal.check_next_number)
            //     if journal.check_next_number and not re.match(r'^[0-9]+$', journal.check_next_number):
            //         raise ValidationError(_('Next Check Number should only contains numbers.'))
            //     if next_num < journal.check_sequence_id.number_next_actual:
            //         raise ValidationError(_(
            //             "The last check number was %s. In order to avoid a check being rejected "
            //             "by the bank, you can only use a greater number.",
            //             journal.check_sequence_id.number_next_actual
            //         ))
            //     if journal.check_sequence_id:
            //         if next_num > MAX_INT32:
            //             raise ValidationError(_(
            //                 "The check number you entered (%(num)s) exceeds the maximum allowed value of %(max)d. "
            //                 "Please enter a smaller number.",
            //                 num=next_num,
            //                 max=MAX_INT32,
            //             ))
            //         journal.check_sequence_id.sudo().number_next_actual = next_num
            //         journal.check_sequence_id.sudo().padding = len(journal.check_next_number)
            */
            return default;
        }

        protected async Task<AccountJournal> IsPaymentMethodAvailableInternalAsync(object payment_method_code, object complete_domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _is_payment_method_available(self, payment_method_code, complete_domain=True):
            // """ Check if the payment method is available on this journal. """
            // self.ensure_one()
            // method_domain = self.env['account.payment.method']._get_payment_method_domain(
            //     code=payment_method_code,
            //     with_country=complete_domain,
            //     with_currency=complete_domain,
            // )
            // return self.filtered_domain(method_domain)
            */
            return default;
        }

        protected async Task<AccountJournal> KanbanDashboardGraphInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _kanban_dashboard_graph(self):
            // bank_cash_journals = self.filtered(lambda journal: journal.type in ('bank', 'cash', 'credit'))
            // bank_cash_graph_datas = bank_cash_journals._get_bank_cash_graph_data()
            // for journal in bank_cash_journals:
            //     journal.kanban_dashboard_graph = json.dumps(bank_cash_graph_datas[journal.id])
            // 
            // sale_purchase_journals = self.filtered(lambda journal: journal.type in ('sale', 'purchase'))
            // sale_purchase_graph_datas = sale_purchase_journals._get_sale_purchase_graph_data()
            // for journal in sale_purchase_journals:
            //     journal.kanban_dashboard_graph = json.dumps(sale_purchase_graph_datas[journal.id])
            // 
            // (self - bank_cash_journals - sale_purchase_journals).kanban_dashboard_graph = False
            */
            return default;
        }

        protected async Task<AccountJournal> KanbanDashboardInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _kanban_dashboard(self):
            // dashboard_data = self._get_journal_dashboard_data_batched()
            // for journal in self:
            //     journal.kanban_dashboard = json.dumps(dashboard_data[journal.id])
            */
            return default;
        }

        protected async Task<AccountJournal> NotifyEinvoicesReceivedInternalAsync(object moves)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _notify_einvoices_received(self, moves):
            // self.ensure_one()
            // # legacy if module was not upgraded
            // new_mail_template = self.env.ref('account.mail_template_invoice_subscriber', raise_if_not_found=False)
            // if new_mail_template:
            //     # if module was upgraded, this is handled in _notify_invoice_subscribers
            //     return
            // 
            // emails = set(email_normalize_all(self.incoming_einvoice_notification_email or ''))
            // if not moves or not emails:
            //     return
            // 
            // if not (mail_template := self.env.ref('account.mail_template_einvoice_notification', raise_if_not_found=False)):
            //     return
            // 
            // mail_template.with_context(einvoices=moves).send_mail(self.id, force_send=True)
            */
            return default;
        }

        protected async Task<AccountJournal> NotifyInvoiceSubscribersInternalAsync(object invoice, object mail_params)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _notify_invoice_subscribers(self, invoice, mail_params=None):
            // self.ensure_one()
            // invoice.ensure_one()
            // 
            // recipients = set(email_normalize_all(self.incoming_einvoice_notification_email or ''))
            // if not recipients:
            //     return
            // 
            // if not (template := self.env.ref('account.mail_template_invoice_subscriber', raise_if_not_found=False)):
            //     # we add the template in stable, thus this might happen if the module was not upgraded
            //     self._notify_einvoices_received(invoice)
            //     return
            // 
            // base_url = self.get_base_url()
            // for recipient in recipients:
            //     unsubscribe_token = hash_sign(
            //         self.sudo().env,
            //         scope=self._get_journal_notification_unsubscribe_scope(),
            //         message_values={'email_to_unsubscribe': recipient, 'journal_id': self.id},
            //     )
            //     unsubscribe_url = urls.urljoin(base_url, f'/my/journal/{self.id}/unsubscribe?{urlencode({"token": unsubscribe_token})}')
            // 
            //     template.with_context(unsubscribe_url=unsubscribe_url).send_mail(
            //         invoice.id,
            //         email_values={
            //             **(mail_params or {}),
            //             'email_to': recipient,
            //         },
            //         force_send=True,
            //     )
            */
            return default;
        }

        protected async Task<AccountJournal> OnchangeIncomingEinvoiceNotificationEmailInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _onchange_incoming_einvoice_notification_email(self):
            // for journal in self:
            //     journal.incoming_einvoice_notification_email = ', '.join(email_normalize_all(journal.incoming_einvoice_notification_email or ''))
            */
            return default;
        }

        protected async Task<AccountJournal> OnchangeTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _onchange_type(self):
            // self.filtered(lambda journal: journal.type not in {'sale', 'purchase'}).alias_name = False
            // for journal in self.filtered(lambda journal: (
            //     not journal.alias_name and journal.type in {'sale', 'purchase'})
            // ):
            //     journal.alias_name = self._alias_prepare_alias_name(
            //         False, journal.name, journal.code, journal.type, journal.company_id)
            // 
            // for journal in self:
            //     journal.code = False
            //     journal.default_account_id = False
            //     journal.profit_account_id = False
            //     journal.loss_account_id = False
            //     if journal.type == 'sale':
            //         journal.default_account_id = journal.company_id.income_account_id
            //     elif journal.type == 'purchase':
            //         journal.default_account_id = journal.company_id.expense_account_id
            //     elif journal.type in ('cash', 'bank'):
            //         journal.profit_account_id = journal.company_id.default_cash_difference_income_account_id
            //         journal.loss_account_id = journal.company_id.default_cash_difference_expense_account_id
            // 
            // # codes are reset and recomputed whenever the
            // # journal type changes through the form view
            // self._compute_code()
            */
            return default;
        }

        public async Task<AccountJournal> OpenActionAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def open_action(self):
            // """return action based on type for related journals"""
            // self.ensure_one()
            // action_name = self._select_action_to_open()
            // 
            // # Set 'account.' prefix if missing.
            // if not action_name.startswith("account."):
            //     action_name = 'account.%s' % action_name
            // 
            // action = self.env["ir.actions.act_window"]._for_xml_id(action_name)
            // 
            // if 'context' in action and isinstance(action['context'], str):
            //     action_context = ast.literal_eval(action['context'])
            // else:
            //     action_context = action.get('context', {})
            // action['context'] = {
            //     **action_context,
            //     **self.env.context,
            //     'default_journal_id': self.id,
            // }
            // domain_type_field = action['res_model'] == 'account.move.line' and 'move_id.move_type' or 'move_type' # The model can be either account.move or account.move.line
            // 
            // # Override the domain only if the action was not explicitly specified in order to keep the
            // # original action domain.
            // if action.get('domain') and isinstance(action['domain'], str):
            //     action['domain'] = ast.literal_eval(action['domain'] or '[]')
            // if not self.env.context.get('action_name'):
            //     if self.type == 'sale':
            //         action['domain'] = [(domain_type_field, 'in', ('out_invoice', 'out_refund', 'out_receipt', 'entry'))]
            //     elif self.type == 'purchase':
            //         action['domain'] = [(domain_type_field, 'in', ('in_invoice', 'in_refund', 'in_receipt', 'entry'))]
            // 
            // action['domain'] = (action['domain'] or []) + [('journal_id', '=', self.id)]
            // return action
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> OpenBankDifferenceActionAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def open_bank_difference_action(self):
            // self.ensure_one()
            // action = self.env["ir.actions.act_window"]._for_xml_id("account.action_account_moves_all_a")
            // action['context'] = {
            //     'search_default_account_id': self.default_account_id.id,
            //     'search_default_group_by_move': False,
            //     'search_default_no_st_line_id': True,
            //     'search_default_posted': False,
            // }
            // date_from = self.last_statement_id.date or self.company_id.fiscalyear_lock_date
            // if date_from:
            //     action['context'] |= {
            //         'date_from': date_from,
            //         'date_to': fields.Date.context_today(self),
            //         'search_default_date_between': True
            //     }
            // return action
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> OpenInvalidStatementsActionAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def open_invalid_statements_action(self):
            // self.ensure_one()
            // return self.env["ir.actions.act_window"]._for_xml_id('account.action_bank_statement_tree')
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> OpenPaymentsActionAsync(AccountJournalOpenPaymentsActionRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def open_payments_action(self, payment_type=False, mode='list'):
            // if payment_type == 'outbound':
            //     action_ref = 'account.action_account_payments_payable'
            // elif payment_type == 'transfer':
            //     action_ref = 'account.action_account_payments_transfer'
            // elif payment_type == 'inbound':
            //     action_ref = 'account.action_account_payments'
            // else:
            //     action_ref = 'account.action_account_all_payments'
            // action = self.env['ir.actions.act_window']._for_xml_id(action_ref)
            // action['context'] = dict(ast.literal_eval(action.get('context')), default_journal_id=self.id, search_default_journal_id=self.id)
            // if payment_type == 'transfer':
            //     action['context'].update({
            //         'default_partner_id': self.company_id.partner_id.id,
            //         'default_is_internal_transfer': True,
            //     })
            // if mode == 'form':
            //     action['views'] = [[False, 'form']]
            // return action
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> OpenWithContextAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def open_action_with_context(self):
            // action_name = self.env.context.get('action_name', False)
            // if not action_name:
            //     return False
            // ctx = dict(self.env.context, default_journal_id=self.id)
            // if ctx.get('search_default_journal', False):
            //     ctx.update(search_default_journal_id=self.id)
            //     ctx['search_default_journal'] = False  # otherwise it will do a useless groupby in bank statements
            // ctx.pop('group_by', None)
            // action = self.env['ir.actions.act_window']._for_xml_id(f"account.{action_name}")
            // action['context'] = ctx
            // if ctx.get('use_domain', False):
            //     action['domain'] = isinstance(ctx['use_domain'], list) and ctx['use_domain'] or ['|', ('journal_id', '=', self.id), ('journal_id', '=', False)]
            //     action['name'] = _(
            //         "%(action)s for journal %(journal)s",
            //         action=action["name"],
            //         journal=self.name,
            //     )
            // return action
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> PostAllEntriesAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def action_post_all_entries(self):
            // ctx = dict(self.env.context, active_model='account.journal', active_id=self.id)
            // moves_to_validate = self.env['account.move'].search([('journal_id', '=', self.id)])
            // return moves_to_validate.with_context(ctx).action_validate_moves_with_confirmation()
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        protected async Task<AccountJournal> PrepareCreditAccountValsInternalAsync(object company, object code, object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _prepare_credit_account_vals(self, company, code, vals):
            // return {
            //     'name': vals.get('name'),
            //     'code': code,
            //     'account_type': 'liability_credit_card',
            //     'currency_id': vals.get('currency_id'),
            //     'company_ids': [Command.link(company.id)],
            // }
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountJournal> PrepareLiquidityAccountValsInternalAsync(object company, object code, object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _prepare_liquidity_account_vals(self, company, code, vals):
            // return {
            //     'name': vals.get('name'),
            //     'code': code,
            //     'account_type': 'asset_cash',
            //     'currency_id': vals.get('currency_id'),
            //     'company_ids': [Command.link(company.id)],
            // }
            */
            return default;
        }

        protected async Task<AccountJournal> ProcessReferenceForSaleOrderInternalAsync(object order_reference)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _process_reference_for_sale_order(self, order_reference):
            // '''
            // returns the order reference to be used for the payment.
            // Hook to be overriden: see l10n_ch for an example.
            // '''
            // self.ensure_one()
            // return order_reference
            */
            return default;
        }

        protected async Task<AccountJournal> QueryHasSequenceHolesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _query_has_sequence_holes(self):
            // self.env['account.move'].flush_model(['journal_id', 'date', 'sequence_prefix', 'made_sequence_gap'])
            // # A branch company is locked when the parent is locked.
            // # Parent companies of the journal company can not add moves to the journal.
            // # Thus it is good enough to consider all moves in the journal after the journal company lockdate.
            // # This way we find all holes that can still be corrected.
            // to_check = self.grouped(lambda j: j.company_id._get_user_fiscal_lock_date(j, ignore_exceptions=True))
            // queries = []
            // for lock_date, journals in to_check.items():
            //     # We add the companies to the query to benefit from index `account_move_journal_id_company_id_idx`
            //     journal_company_ids = journals.company_id.ids
            //     companies = self.env['res.company'].sudo().search([
            //         ('id', 'child_of', journal_company_ids),
            //     ])
            //     queries.append(SQL(
            //         """
            //             SELECT move.journal_id,
            //                    move.sequence_prefix
            //               FROM account_move move
            //              WHERE move.journal_id = ANY(%(journal_ids)s)
            //                AND move.company_id = ANY(%(company_ids)s)
            //                AND move.made_sequence_gap IS TRUE
            //                AND move.date > %(lock_date)s
            //           GROUP BY move.journal_id, move.sequence_prefix
            //         """,
            //         journal_ids=journals.ids,
            //         company_ids=companies.ids,
            //         lock_date=lock_date,
            //     ))
            // self.env.cr.execute(SQL(' UNION ALL '.join(['%s'] * len(queries)), *queries))
            // return self.env.cr.fetchall()
            */
            return default;
        }

        protected async Task<AccountJournal> SelectActionToOpenInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _select_action_to_open(self):
            // self.ensure_one()
            // if self.env.context.get('action_name'):
            //     return self.env.context.get('action_name')
            // elif self.type == 'bank':
            //     return 'action_bank_statement_tree'
            // elif self.type == 'credit':
            //     return 'action_credit_statement_tree'
            // elif self.type == 'cash':
            //     return 'action_view_bank_statement_tree'
            // elif self.type == 'sale':
            //     return 'action_move_out_invoice_type'
            // elif self.type == 'purchase':
            //     return 'action_move_in_invoice_type'
            // else:
            //     return 'action_move_journal_line'
            */
            return default;
        }

        public async Task<AccountJournal> SetBankAccountAsync(AccountJournalSetBankAccountRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def set_bank_account(self, acc_number, bank_id=None):
            // """ Create a res.partner.bank (if not exists) and set it as value of the field bank_account_id """
            // self.ensure_one()
            // res_partner_bank = self.env['res.partner.bank'].search([
            //     ('sanitized_acc_number', '=', sanitize_account_number(acc_number)),
            //     ('partner_id', '=', self.company_id.partner_id.id),
            // ], limit=1)
            // if res_partner_bank:
            //     self.bank_account_id = res_partner_bank.id
            // else:
            //     self.bank_account_id = self.env['res.partner.bank'].create({
            //         'acc_number': acc_number,
            //         'bank_id': bank_id,
            //         'currency_id': self.currency_id.id,
            //         'partner_id': self.company_id.partner_id.id,
            //         'journal_id': self,
            //     }).id
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> ShowSequenceHolesAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def show_sequence_holes(self):
            // has_sequence_holes = self._query_has_sequence_holes()
            // domain = Domain(self.env['account.move']._check_company_domain(self.env.companies))
            // domain &= Domain.OR(
            //     Domain('journal_id', '=', journal_id)
            //     & Domain('sequence_prefix', '=', prefix)
            //     for journal_id, prefix in has_sequence_holes
            // )
            // action = self._show_sequence_holes(domain)
            // action['context'] = {**self._get_move_action_context(), **action['context']}
            // return action
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<AccountJournal> ShowSequenceHolesInternalAsync(object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _show_sequence_holes(self, domain):
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _("Journal Entries"),
            //     'res_model': 'account.move',
            //     'search_view_id': (self.env.ref('account.view_account_move_with_gaps_in_sequence_filter').id, 'search'),
            //     'view_mode': 'list,form',
            //     'domain': domain,
            //     'context': {
            //         'search_default_group_by_sequence_prefix': 1,
            //         'search_default_irregular_sequences': 1,
            //         'expand': 1,
            //     }
            // }
            */
            return default;
        }

        public async Task<AccountJournal> ShowUnhashedEntriesAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def show_unhashed_entries(self):
            // self.ensure_one()
            // chains_to_hash = self._get_moves_to_hash(include_pre_last_hash=True, early_stop=False)
            // moves = self.env['account.move'].concat(*[chain_moves['moves'] for chain_moves in chains_to_hash])
            // action = {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Journal Entries to Hash'),
            //     'res_model': 'account.move',
            //     'domain': [('id', 'in', moves.ids)],
            //     'views': [(False, 'list'), (False, 'form')],
            // }
            // if len(moves.ids) == 1:
            //     action.update({
            //         'res_id': moves[0].id,
            //         'views': [(False, 'form')],
            //     })
            // return action
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountJournal> ToCheckIdsAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def to_check_ids(self):
            // self.ensure_one()
            // return self.env['account.bank.statement.line'].search([
            //     ('journal_id', '=', self.id),
            //     ('move_id.company_id', 'in', self.env.companies.ids),
            //     ('move_id.checked', '=', False),
            //     ('move_id.state', '=', 'posted'),
            // ])
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<AccountJournal> TransformActivityDictInternalAsync(object activity_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py) ---
            // def _transform_activity_dict(self, activity_data):
            // return {
            //     'id': activity_data['id'],
            //     'res_id': activity_data['res_id'],
            //     'res_model': activity_data['res_model'],
            //     'status': activity_data['status'],
            //     'name': activity_data['summary'] or activity_data['act_type_name'],
            //     'activity_category': activity_data['activity_category'],
            //     'act_type_id': activity_data['act_type_id'],
            //     'date': odoo_format_date(self.env, activity_data['date_deadline']),
            // }
            */
            return default;
        }

        protected async Task<AccountJournal> UnlinkExceptLinkedToPaymentProviderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: account_journal.py) ---
            // def _unlink_except_linked_to_payment_provider(self):
            // linked_providers = self.env['payment.provider'].sudo().search([]).filtered(
            //     lambda p: p.journal_id.id in self.ids and p.state != 'disabled'
            // )
            // if linked_providers:
            //     raise UserError(_(
            //         "You must first deactivate a payment provider before deleting its journal.\n"
            //         "Linked providers: %s", ', '.join(p.display_name for p in linked_providers)
            //     ))
            */
            return default;
        }

        protected async Task<AccountJournal> UnlinkJournalExceptWithActivePaymentsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: account_journal.py) ---
            // def _unlink_journal_except_with_active_payments(self):
            // for journal in self:
            //     journal._check_no_active_payments()
            */
            return default;
        }

        protected async Task<AccountJournal> UnsubscribeInvoiceNotificationEmailInternalAsync(object email_to_remove)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _unsubscribe_invoice_notification_email(self, email_to_remove):
            // self.ensure_one()
            // normalized_to_remove = email_normalize(email_to_remove, strict=False)
            // subscribed_emails = set(email_normalize_all(self.incoming_einvoice_notification_email or ''))
            // if not normalized_to_remove or normalized_to_remove not in subscribed_emails:
            //     return False
            // remaining = subscribed_emails - {normalized_to_remove}
            // self.incoming_einvoice_notification_email = ', '.join(remaining or [])
            // return True
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<AccountJournal> input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def write(self, vals):
            // # for journals, force a readable name instead of a sanitized name e.g. non ascii in journal names
            // if vals.get('alias_name') and 'type' not in vals:
            //     # will raise if writing name on more than 1 record, using self[0] is safe
            //     if (not self.env['mail.alias']._is_encodable(vals['alias_name']) or
            //         not self.env['mail.alias']._sanitize_alias_name(vals['alias_name'])):
            //         vals['alias_name'] = self._alias_prepare_alias_name(
            //             False, vals.get('name', self.name), vals.get('code', self.code), self[0].type, self[0].company_id)
            // 
            // for journal in self:
            //     company = journal.company_id
            //     if ('company_id' in vals and journal.company_id.id != vals['company_id']):
            //         company = self.env['res.company'].browse(vals['company_id'])
            //         if journal.bank_account_id.company_id and journal.bank_account_id.company_id != company:
            //             journal.bank_account_id.write({
            //                 'company_id': company.id,
            //                 'partner_id': company.partner_id.id,
            //             })
            //     if 'currency_id' in vals:
            //         if journal.bank_account_id:
            //             journal.bank_account_id.currency_id = vals['currency_id']
            //     if 'bank_account_id' in vals:
            //         if vals.get('bank_account_id'):
            //             bank_account = self.env['res.partner.bank'].browse(vals['bank_account_id'])
            //             if bank_account.partner_id != company.partner_id:
            //                 raise UserError(_("The partners of the journal's company and the related bank account mismatch."))
            //     if 'restrict_mode_hash_table' in vals and not vals.get('restrict_mode_hash_table'):
            //         domain = self.env['account.move']._get_move_hash_domain(
            //             common_domain=[('journal_id', '=', journal.id), ('inalterable_hash', '!=', False)]
            //         )
            //         journal_entry = self.env['account.move'].sudo().search_count(domain, limit=1)
            //         if journal_entry:
            //             field_string = self._fields['restrict_mode_hash_table'].get_description(self.env)['string']
            //             raise UserError(_("You cannot modify the field %s of a journal that already has accounting entries.", field_string))
            // result = super(AccountJournal, self).write(vals)
            // 
            // # Ensure alias coherency when changing type
            // if 'type' in vals and not self.env.context.get('account_journal_skip_alias_sync'):
            //     for journal in self:
            //         alias_vals = journal._alias_get_creation_values()
            //         alias_vals = {
            //             'alias_defaults': alias_vals['alias_defaults'],
            //             'alias_name': alias_vals['alias_name'],
            //         }
            //         journal.update(alias_vals)
            // 
            // # Ensure the liquidity accounts are sharing the same foreign currency.
            // if 'currency_id' in vals:
            //     for journal in self.filtered(lambda journal: journal.type in ('bank', 'cash', 'credit')):
            //         journal.default_account_id.currency_id = journal.currency_id
            // 
            // # Create the bank_account_id if necessary
            // if 'bank_acc_number' in vals:
            //     for journal in self.filtered(lambda r: r.type == 'bank' and not r.bank_account_id):
            //         journal.set_bank_account(vals.get('bank_acc_number'), vals.get('bank_id'))
            // 
            // return result
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_journal.py) ---
            // def write(self, vals):
            // # OVERRIDE
            // # Don't allow the user to deactivate an edi format having at least one document to be processed.
            // if vals.get('edi_format_ids'):
            //     old_edi_format_ids = self.edi_format_ids
            //     res = super().write(vals)
            //     diff_edi_format_ids = old_edi_format_ids - self.edi_format_ids
            //     documents = self.env['account.edi.document'].search([
            //         ('move_id.journal_id', 'in', self.ids),
            //         ('edi_format_id', 'in', diff_edi_format_ids.ids),
            //         ('state', 'in', ('to_cancel', 'to_send')),
            //     ])
            //     # If the formats we are unchecking do not need a webservice, we don't need them to be correctly sent
            //     if documents.filtered(lambda d: d.edi_format_id._needs_web_services()):
            //         raise UserError(_('Cannot deactivate (%s) on this journal because not all documents are synchronized', ', '.join(documents.edi_format_id.mapped('display_name'))))
            //     # remove these documents which: do not need a web service & are linked to the edi formats we are unchecking
            //     if documents:
            //         documents.unlink()
            //     return res
            // else:
            //     return super().write(vals)
            */
            return await base.WriteAsync(input);
        }

        private async Task<AccountJournal> _GetBankStatementsAvailableSourcesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def __get_bank_statements_available_sources(self):
            // return [('undefined', _('Undefined Yet'))]
            */
            return default;
        }
    }
}