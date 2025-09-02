using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("mail", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public class MailAliasMixinOptionalAppService : ApplicationService, IMailAliasMixinOptionalAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public MailAliasMixinOptionalAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ActionConfigureBankJournalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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
            return default;
        }

        public async Task<TEntity> AliasFilterFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values, object filters) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin_optional.py) ---
            // def _alias_filter_fields(self, values, filters=False):
            // """ Split the vals dict into two dictionnary of vals, one for alias
            // field and the other for other fields """
            // if not filters:
            //     filters = self.env['mail.alias']._fields.keys()
            // alias_values, record_values = {}, {}
            // for fname in values.keys():
            //     if fname in filters:
            //         alias_values[fname] = values.get(fname)
            //     else:
            //         record_values[fname] = values.get(fname)
            // return alias_values, record_values
            */
            return default;
        }

        public async Task<TEntity> AliasGetAliasDomainIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin_optional.py) ---
            // def _alias_get_alias_domain_id(self):
            // """ Return alias domain value to synchronize with owner's company.
            // Implementing it with a compute is complicated, as its 'alias_domain_id'
            // is a field on 'mail.alias' model, coming from 'alias_id' field and due
            // to current implementation of the mixin, notably the create / write
            // overrides, compute is not called in all cases. We therefore use a tool
            // method to call in the mixin. """
            // alias_domain_values = {}
            // record_companies = self._mail_get_companies()
            // for record in self:
            //     record_company = record_companies[record.id]
            //     alias_domain_values[record] = (
            //         record_company.alias_domain_id
            //         or record.alias_domain_id or self.env.company.alias_domain_id
            //     )
            // return alias_domain_values
            */
            return default;
        }

        public async Task<TEntity> AliasGetCreationValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin_optional.py) ---
            // def _alias_get_creation_values(self):
            // """ Return values to create an alias, or to write on the alias after its
            //     creation.
            // """
            // values = {
            //     'alias_parent_thread_id': self.id if self.id else False,
            //     'alias_parent_model_id': self.env['ir.model']._get_id(self._name),
            // }
            // if 'default_alias_domain_id' in self.env.context:
            //     values['alias_domain_id'] = self.env.context['default_alias_domain_id']
            // return values
            */
            return default;
        }

        public async Task<TEntity> AliasPrepareAliasNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object alias_name, object name, object code, object jtype, object company) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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

        public async Task<TEntity> CheckAutoPostDraftEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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

        public async Task<TEntity> CheckBankAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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

        public async Task<TEntity> CheckCompanyConsistencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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

        public async Task<TEntity> CheckPaymentMethodLineIdsMultiplicityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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

        public async Task<TEntity> CheckTypeDefaultAccountIdTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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

        public async Task<TEntity> ComputeAccountingDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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

        public async Task<TEntity> ComputeAliasEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin_optional.py) ---
            // def _compute_alias_email(self):
            // """ Alias email can be used in views, as it is Falsy when having no domain
            // or no name. Alias display name itself contains more info and cannot be
            // used as it is in views. """
            // self.alias_email = False
            // for record in self.filtered(lambda rec: rec.alias_name and rec.alias_domain):
            //     record.alias_email = f"{record.alias_name}@{record.alias_domain}"
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailablePaymentMethodIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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

        public async Task<TEntity> ComputeCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_code(self):
            // cache = defaultdict(list)
            // for record in self:
            //     if not record.code and record.type in ('bank', 'cash', 'credit'):
            //         record.code = self.get_next_bank_cash_default_code(
            //             record.type,
            //             record.company_id,
            //             cache.get(record.company_id)
            //         )
            //         cache[record.company_id].append(record.code)
            */
            return default;
        }

        public async Task<TEntity> ComputeDefaultAccountTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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

        public async Task<TEntity> ComputeDisplayAliasFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_display_alias_fields(self):
            // self.display_alias_fields = self.env['mail.alias.domain'].search_count([], limit=1)
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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

        public async Task<TEntity> ComputeInboundPaymentMethodLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_inbound_payment_method_line_ids(self):
            // for journal in self:
            //     pay_method_line_ids_commands = [Command.clear()]
            //     if journal.type in ('bank', 'cash', 'credit'):
            //         default_methods = journal._default_inbound_payment_methods()
            //         pay_method_line_ids_commands += [Command.create({
            //             'name': pay_method.name,
            //             'payment_method_id': pay_method.id,
            //         }) for pay_method in default_methods]
            //     journal.inbound_payment_method_line_ids = pay_method_line_ids_commands
            */
            return default;
        }

        public async Task<TEntity> ComputeOutboundPaymentMethodLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_outbound_payment_method_line_ids(self):
            // for journal in self:
            //     pay_method_line_ids_commands = [Command.clear()]
            //     if journal.type in ('bank', 'cash', 'credit'):
            //         default_methods = journal._default_outbound_payment_methods()
            //         pay_method_line_ids_commands += [Command.create({
            //             'name': pay_method.name,
            //             'payment_method_id': pay_method.id,
            //         }) for pay_method in default_methods]
            //     journal.outbound_payment_method_line_ids = pay_method_line_ids_commands
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_payment_sequence(self):
            // for journal in self:
            //     journal.payment_sequence = journal.type in ('bank', 'cash', 'credit')
            */
            return default;
        }

        public async Task<TEntity> ComputeRefundSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_refund_sequence(self):
            // for journal in self:
            //     journal.refund_sequence = journal.type in ('sale', 'purchase')
            */
            return default;
        }

        public async Task<TEntity> ComputeSelectedPaymentMethodCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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

        public async Task<TEntity> ComputeSuspenseAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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

        public async Task<TEntity> ConstrainsAccountControlIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _constrains_account_control_ids(self):
            // self.env['account.move.line'].flush_model(['account_id', 'journal_id', 'display_type'])
            // self.flush_recordset(['account_control_ids'])
            // self._cr.execute("""
            //     SELECT aml.id
            //     FROM account_move_line aml
            //     WHERE aml.journal_id in %s
            //     AND EXISTS (SELECT 1 FROM journal_account_control_rel rel WHERE rel.journal_id = aml.journal_id)
            //     AND NOT EXISTS (SELECT 1 FROM journal_account_control_rel rel WHERE rel.account_id = aml.account_id AND rel.journal_id = aml.journal_id)
            //     AND aml.display_type NOT IN ('line_section', 'line_note')
            // """, [tuple(self.ids)])
            // if self._cr.fetchone():
            //     raise ValidationError(_('Some journal items already exist in this journal but with other accounts than the allowed ones.'))
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin_optional.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // not_writable_fields = set(self.env['mail.alias']._fields.keys()) - set(self.ALIAS_WRITEABLE_FIELDS)
            // for vals in vals_list:
            //     for not_writable_field in not_writable_fields:
            //         if not_writable_field in vals:
            //             del vals[not_writable_field]
            // return vals_list
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin_optional.py) ---
            // def create(self, vals_list):
            // """ Create aliases using sudo if an alias is required, notably if its
            // name is given. """
            // # prefetch company information, used for alias domain
            // company_fname = self._mail_get_company_field()
            // if company_fname:
            //     company_id_default = self.default_get([company_fname]).get(company_fname) or self.env.company.id
            //     company_prefetch_ids = {vals[company_fname] for vals in vals_list if vals.get(company_fname)}
            //     company_prefetch_ids.add(company_id_default)
            // else:
            //     company_id_default = self.env.company.id
            //     company_prefetch_ids = {company_id_default}
            // 
            // # prepare all alias values
            // alias_vals_list, record_vals_list = [], []
            // for vals in vals_list:
            //     if vals.get('alias_name'):
            //         vals['alias_name'] = self.env['mail.alias']._sanitize_alias_name(vals['alias_name'])
            //     if self._require_new_alias(vals):
            //         company_id = vals.get(company_fname) or company_id_default
            //         company = self.env['res.company'].with_prefetch(company_prefetch_ids).browse(company_id)
            //         alias_vals, record_vals = self._alias_filter_fields(vals)
            //         # generate record-agnostic base alias values
            //         alias_vals.update(self.env[self._name].with_context(
            //             default_alias_domain_id=alias_vals.get('alias_domain_id', company.alias_domain_id.id),
            //         )._alias_get_creation_values())
            //         alias_vals_list.append(alias_vals)
            //         record_vals_list.append(record_vals)
            // 
            // # create all aliases
            // alias_ids = []
            // if alias_vals_list:
            //     alias_ids = iter(self.env['mail.alias'].sudo().create(alias_vals_list).ids)
            // 
            // # update alias values in create vals directly
            // valid_vals_list = []
            // record_vals_iter = iter(record_vals_list)
            // for vals in vals_list:
            //     if self._require_new_alias(vals):
            //         record_vals = next(record_vals_iter)
            //         record_vals['alias_id'] = next(alias_ids)
            //         valid_vals_list.append(record_vals)
            //     else:
            //         valid_vals_list.append(vals)
            // 
            // records = super().create(valid_vals_list)
            // 
            // # update alias values with values coming from record, post-create to have
            // # access to all its values (notably its ID)
            // records_walias = records.filtered('alias_id')
            // for record in records_walias:
            //     alias_values = record._alias_get_creation_values()
            //     record.alias_id.sudo().write(alias_values)
            // 
            // return records
            */
            return default;
        }

        public async Task<TEntity> CreateDefaultAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object journal_type, object vals) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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

        public async Task<TEntity> CreateDocumentFromAttachmentAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attachment_ids) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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
            //     'context': self._context
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
            return default;
        }

        public async Task<TEntity> CreateDocumentFromAttachmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attachment_ids) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _create_document_from_attachment(self, attachment_ids):
            // """ Create the invoices from files."""
            // if not self:
            //     self = self.env['account.journal'].browse(self._context.get("default_journal_id"))
            // move_type = self._context.get("default_move_type", "entry")
            // if not self:
            //     if move_type in self.env['account.move'].get_sale_types(include_receipts=True):
            //         journal_type = "sale"
            //     elif move_type in self.env['account.move'].get_purchase_types(include_receipts=True):
            //         journal_type = "purchase"
            //     else:
            //         raise UserError(_("The journal in which to upload the invoice is not specified. "))
            //     self = self.env['account.journal'].search([
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
            // # As we are coming from the journal, we assume that each attachments
            // # will create an invoice with a tentative to enhance with EDI / OCR..
            // all_invoices = self.env['account.move']
            // for attachment in attachments:
            //     invoice = self.env['account.move'].with_context(skip_is_manually_modified=True).create({
            //         'journal_id': self.id,
            //         'move_type': move_type,
            //     })
            // 
            //     invoice.with_context(skip_is_manually_modified=True)._extend_with_attachments(attachment, new=True)
            // 
            //     all_invoices |= invoice
            // 
            //     invoice.with_context(
            //         account_predictive_bills_disable_prediction=True,
            //         no_new_invoice=True,
            //     ).message_post(attachment_ids=attachment.ids)
            // 
            //     attachment.write({'res_model': 'account.move', 'res_id': invoice.id})
            //     invoice._autopost_bill()
            // 
            // return all_invoices
            */
            return default;
        }

        public async Task<TEntity> DefaultInboundPaymentMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _default_inbound_payment_methods(self):
            // return self.env.ref('account.account_payment_method_manual_in')
            */
            return default;
        }

        public async Task<TEntity> DefaultInvoiceReferenceModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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

        public async Task<TEntity> DefaultOutboundPaymentMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _default_outbound_payment_methods(self):
            // return self.env.ref('account.account_payment_method_manual_out')
            */
            return default;
        }

        public async Task<TEntity> EnsureUniqueAliasInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object company) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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
            //     domain.append(('alias_domain', '=', alias_domain_name))
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

        public async Task<TEntity> FillMissingValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object protected_codes) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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
            //     vals['name'] = vals.get('name') or vals.get('bank_acc_number')
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
            //     vals['code'] = code if not protected_codes or code not in protected_codes else self.get_next_bank_cash_default_code(journal_type, company, protected_codes)
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
            */
            return default;
        }

        public async Task<TEntity> GetAvailablePaymentMethodLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_type) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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
            */
            return default;
        }

        public async Task<TEntity> GetBankStatementsAvailableSourcesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _get_bank_statements_available_sources(self):
            // return self.__get_bank_statements_available_sources()
            */
            return default;
        }

        public async Task<TEntity> GetDefaultAccountDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _get_default_account_domain(self):
            // return """[
            //     ('deprecated', '=', False),
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

        public async Task<TEntity> GetJournalBankAccountBalanceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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
            //         ('display_type', 'not in', ('line_section', 'line_note')),
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

        public async Task<TEntity> GetJournalInboundOutstandingPaymentAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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
            */
            return default;
        }

        public async Task<TEntity> GetJournalOutboundOutstandingPaymentAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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

        public async Task<TEntity> GetJournalsPaymentMethodInformationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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
            //     self._cr.execute(
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
            //     for pay_method_id, company_id, journal_id, provider_id in self._cr.fetchall():
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

        public async Task<TEntity> GetNextBankCashDefaultCodeAsync<TEntity>(IEnumerable<TEntity> entities, object journal_type, object company, object cache, object protected_codes) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def get_next_bank_cash_default_code(self, journal_type, company, cache=None, protected_codes=False):
            // prefix_map = {'cash': 'CSH', 'general': 'GEN', 'bank': 'BNK', 'credit': 'CCD'}
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

        public async Task<TEntity> InitColumnAliasIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin.py) ---
            // def _init_column_alias_id(self):
            // # both self and the alias model must be present in 'ir.model'
            // child_ctx = {
            //     'active_test': False,       # retrieve all records
            //     'prefetch_fields': False,   # do not prefetch fields on records
            // }
            // child_model = self.sudo().with_context(child_ctx)
            // 
            // for record in child_model.search([('alias_id', '=', False)]):
            //     # create the alias, and link it to the current record
            //     alias = self.env['mail.alias'].sudo().create(record._alias_get_creation_values())
            //     record.with_context(mail_notrack=True).alias_id = alias
            //     _logger.info('Mail alias created for %s %s (id %s)',
            //                  record._name, record.display_name, record.id)
            */
            return default;
        }

        public async Task<TEntity> InitColumnInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin.py) ---
            // def _init_column(self, name):
            // """ Create aliases for existing rows. """
            // super()._init_column(name)
            // if name == 'alias_id':
            //     # as 'mail.alias' records refer to 'ir.model' records, create
            //     # aliases after the reflection of models
            //     self.pool.post_init(self._init_column_alias_id)
            */
            return default;
        }

        public async Task<TEntity> IsPaymentMethodAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_method_code, object complete_domain) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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

        public async Task<TEntity> OnchangeTypeForAliasInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _onchange_type_for_alias(self):
            // self.filtered(lambda journal: journal.type not in {'sale', 'purchase'}).alias_name = False
            // for journal in self.filtered(lambda journal: (
            //     not journal.alias_name and journal.type in {'sale', 'purchase'})
            // ):
            //     journal.alias_name = self._alias_prepare_alias_name(
            //         False, journal.name, journal.code, journal.type, journal.company_id)
            */
            return default;
        }

        public async Task<TEntity> PrepareCreditAccountValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object code, object vals) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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

        public async Task<TEntity> PrepareLiquidityAccountValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object code, object vals) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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

        public async Task<TEntity> ProcessReferenceForSaleOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order_reference) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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

        public async Task<TEntity> RequireNewAliasInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record_vals) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin.py) ---
            // def _require_new_alias(self, record_vals):
            // """ alias_id field is always required, due to inherits """
            // return not record_vals.get('alias_id')
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin_optional.py) ---
            // def _require_new_alias(self, record_vals):
            // """ Create only if no existing alias, and if a name is given, to avoid
            // creating inactive aliases (falsy name). """
            // return not record_vals.get('alias_id') and record_vals.get('alias_name')
            */
            return default;
        }

        public async Task<TEntity> SearchAliasEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin_optional.py) ---
            // def _search_alias_email(self, operator, operand):
            // return [('alias_id.alias_full_name', operator, operand)]
            */
            return default;
        }

        public async Task<TEntity> SetBankAccountAsync<TEntity>(IEnumerable<TEntity> entities, object acc_number, Guid bank_id) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def unlink(self):
            // bank_accounts = self.env['res.partner.bank'].browse()
            // for bank_account in self.mapped('bank_account_id'):
            //     accounts = self.search([('bank_account_id', '=', bank_account.id)])
            //     if accounts <= self:
            //         bank_accounts += bank_account
            // self.env['account.payment.method.line'].search([('journal_id', 'in', self.ids)]).unlink()
            // ret = super(AccountJournal, self).unlink()
            // bank_accounts.unlink()
            // return ret
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin_optional.py) ---
            // def unlink(self):
            // """ Delete the given records, and cascade-delete their corresponding alias. """
            // aliases = self.mapped('alias_id')
            // res = super().unlink()
            // aliases.sudo().unlink()
            // return res
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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
            // if 'type' in vals and not self._context.get('account_journal_skip_alias_sync'):
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
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin_optional.py) ---
            // def write(self, vals):
            // """ Split writable fields of mail.alias and other fields alias fields will
            // write with sudo and the other normally. Also handle alias_domain_id
            // update. If alias does not exist and we try to set a name, create the
            // alias automatically. """
            // # create missing aliases
            // if vals.get('alias_name'):
            //     alias_create_values = [
            //         dict(
            //             record._alias_get_creation_values(),
            //             alias_name=self.env['mail.alias']._sanitize_alias_name(vals['alias_name']),
            //         )
            //         for record in self.filtered(lambda rec: not rec.alias_id)
            //     ]
            //     if alias_create_values:
            //         aliases = self.env['mail.alias'].sudo().create(alias_create_values)
            //         for record, alias in zip(self.filtered(lambda rec: not rec.alias_id), aliases):
            //             record.alias_id = alias.id
            // 
            // alias_vals, record_vals = self._alias_filter_fields(vals, filters=self.ALIAS_WRITEABLE_FIELDS)
            // if record_vals:
            //     super().write(record_vals)
            // 
            // # synchronize alias domain if company environment changed
            // company_fname = self._mail_get_company_field()
            // if company_fname in vals:
            //     alias_domain_values = self.filtered('alias_id')._alias_get_alias_domain_id()
            //     for record, alias_domain_id in alias_domain_values.items():
            //         record.sudo().alias_domain_id = alias_domain_id.id
            // 
            // if alias_vals and (record_vals or self.browse().has_access('write')):
            //     self.mapped('alias_id').sudo().write(alias_vals)
            // 
            // return True
            */
            return default;
        }

        public async Task<TEntity> _GetBankStatementsAvailableSourcesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
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