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
    public class AccountAccountAppService : GenericApplicationService<AccountAccount>, IAccountAccountAppService
    {
        private readonly IMailThreadAppService _mailThreadAppService;
        public AccountAccountAppService(IRepository<AccountAccount, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailThreadAppService = mailThreadAppService;
        }

        protected async Task<AccountAccount> ActionUnmergeGetUserConfirmationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _action_unmerge_get_user_confirmation(self):
            // """ Open a RedirectWarning asking the user whether to proceed with the merge. """
            // if self.env.context.get('account_unmerge_confirm'):
            //     return
            // 
            // msg = _("Are you sure? This will perform the following operations:\n")
            // for account in self:
            //     msg += _(
            //         "Account %(account)s will be split in %(num_accounts)s, one for each company:\n",
            //         account=account.display_name,
            //         num_accounts=len(account.company_ids),
            //     )
            //     msg += ''.join(f'    - {company.name}: {account.with_company(company).display_name}\n' for company in account.company_ids)
            //     action = self.env['ir.actions.actions']._for_xml_id('account.action_unmerge_accounts')
            // raise RedirectWarning(msg, action, _("Unmerge"), additional_context={**self.env.context, 'account_unmerge_confirm': True})
            */
            return default;
        }

        protected async Task<AccountAccount> ActionUnmergeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _action_unmerge(self):
            // """ Unmerge `self` into one account per company in `self.company_ids`.
            // This will modify:
            //     - the many2many and company-dependent fields on `self`
            //     - the records with relational fields pointing to `self`
            // """
            // 
            // def _get_query_company_id(model):
            //     """ Get a query giving the `company_id` of a model.
            // 
            //         Uses _field_to_sql, so works even in some cases where `company_id`
            //         isn't stored, e.g. if it is a related field.
            // 
            //         Returns None if we cannot identify the company_id that corresponds to
            //         each record, (e.g. if there is no company_id field, or company_id
            //         is computed non-stored and _field_to_sql isn't implemented for it).
            //     """
            //     if model == 'res.company':
            //         company_id_field = 'id'
            //     elif 'company_id' in self.env[model]:
            //         company_id_field = 'company_id'
            //     else:
            //         return
            //     # We would get a ValueError if the _field_to_sql is not implemented. In that case, we return None.
            //     with contextlib.suppress(ValueError):
            //         query = Query(self.env, self.env[model]._table, self.env[model]._table_sql)
            //         return query.select(
            //             SQL('%s AS id', self.env[model]._field_to_sql(query.table, 'id')),
            //             SQL('%s AS company_id', self.env[model]._field_to_sql(query.table, company_id_field, query)),
            //         )
            // 
            // # Step 1: Check access rights.
            // self._check_action_unmerge_possible()
            // 
            // # Step 2: Create new accounts.
            // base_company = self.env.company if self.env.company in self.company_ids else self.company_ids[0]
            // companies_to_update = self.company_ids - base_company
            // check_company_fields = {fname for fname, field in self._fields.items() if field.relational and field.check_company}
            // new_account_by_company = {
            //     company: self.copy(default={
            //         'name': self.name,
            //         'company_ids': [Command.set(company.ids)],
            //         **{
            //             fname: self[fname].filtered(lambda record: record.company_id == company)
            //             for fname in check_company_fields
            //         }
            //     })
            //     for company in companies_to_update
            // }
            // new_accounts = self.env['account.account'].union(*new_account_by_company.values())
            // 
            // # Step 3: Update foreign keys in DB.
            // 
            // # Invalidate cache
            // self.env.invalidate_all()
            // 
            // new_account_id_by_company_id = {str(company.id): new_account.id for company, new_account in new_account_by_company.items()}
            // new_account_id_by_company_id_json = json.dumps(new_account_id_by_company_id)
            // (self | new_accounts).invalidate_recordset()
            // 
            // # 3.1: Update fields on other models that reference account.account
            // many2x_fields = self.env['ir.model.fields'].search([
            //     ('ttype', 'in', ('many2one', 'many2many')),
            //     ('relation', '=', 'account.account'),
            //     ('store', '=', True),
            //     ('company_dependent', '=', False),
            // ])
            // for field_to_update in many2x_fields:
            //     model = field_to_update.model
            //     if not self.env[model]._auto:
            //         continue
            //     if not (query_company_id := _get_query_company_id(model)):
            //         continue
            //     if field_to_update.ttype == 'many2one':
            //         table = self.env[model]._table
            //         account_column = field_to_update.name
            //         model_column = 'id'
            //     else:
            //         table = field_to_update.relation_table
            //         account_column = field_to_update.column2
            //         model_column = field_to_update.column1
            //     self.env.cr.execute(SQL(
            //         """
            //          UPDATE %(table)s
            //             SET %(account_column)s = (
            //                     %(new_account_id_by_company_id_json)s::jsonb->>
            //                     table_with_company_id.company_id::text
            //                 )::int
            //            FROM (%(query_company_id)s) table_with_company_id
            //           WHERE table_with_company_id.id = %(model_column)s
            //             AND %(table)s.%(account_column)s = %(account_id)s
            //             AND table_with_company_id.company_id IN %(company_ids_to_update)s
            //         """,
            //         table=SQL.identifier(table),
            //         account_column=SQL.identifier(account_column),
            //         new_account_id_by_company_id_json=new_account_id_by_company_id_json,
            //         query_company_id=query_company_id,
            //         model_column=SQL.identifier(table, model_column),
            //         account_id=self.id,
            //         company_ids_to_update=tuple(new_account_id_by_company_id),
            //     ))
            // for field in self.env.registry.many2one_company_dependents[self._name]:
            //     self.env.cr.execute(SQL(
            //         """
            //         UPDATE %(table)s
            //         SET %(column)s = (
            //             SELECT jsonb_object_agg(key,
            //                 CASE
            //                     WHEN value::int = %(account_id)s AND %(new_account_id_by_company_id_json)s ? key
            //                     THEN (%(new_account_id_by_company_id_json)s::jsonb->>key)::int
            //                     ELSE value::int
            //                 END
            //             )
            //             FROM jsonb_each_text(%(column)s)
            //         )
            //         WHERE %(column)s IS NOT NULL
            //         """,
            //         table=SQL.identifier(self.env[field.model_name]._table),
            //         column=SQL.identifier(field.name),
            //         new_account_id_by_company_id_json=new_account_id_by_company_id_json,
            //         account_id=self.id,
            //     ))
            // 
            // # 3.2: Update Reference fields that reference account.account
            // reference_fields = self.env['ir.model.fields'].search([('ttype', '=', 'reference'), ('store', '=', True)])
            // for field_to_update in reference_fields:
            //     model = field_to_update.model
            //     if not self.env[model]._auto:
            //         continue
            //     if not (query_company_id := _get_query_company_id(model)):
            //         continue
            //     self.env.cr.execute(SQL(
            //         """
            //          UPDATE %(table)s
            //             SET %(column)s = 'account.account,' || (%(new_account_id_by_company_id_json)s::jsonb->>table_with_company_id.company_id::text)
            //            FROM (%(query_company_id)s) table_with_company_id
            //           WHERE table_with_company_id.id = %(table)s.id
            //             AND %(column)s = %(value_to_update)s
            //             AND table_with_company_id.company_id IN %(company_ids_to_update)s
            //         """,
            //         table=SQL.identifier(self.env[model]._table),
            //         column=SQL.identifier(field_to_update.name),
            //         new_account_id_by_company_id_json=new_account_id_by_company_id_json,
            //         query_company_id=query_company_id,
            //         value_to_update=f'account.account,{self.id}',
            //         company_ids_to_update=tuple(new_account_id_by_company_id),
            //     ))
            // 
            // # 3.3: Update Many2OneReference fields that reference account.account
            // many2one_reference_fields = self.env['ir.model.fields'].search([
            //     ('ttype', '=', 'many2one_reference'),
            //     ('store', '=', True),
            //     '!', '&', ('model', '=', 'studio.approval.request'),  # A weird Many2oneReference which doesn't have its model field on the model.
            //               ('name', '=', 'res_id'),
            // ])
            // for field_to_update in many2one_reference_fields:
            //     model = field_to_update.model
            //     model_field = self.env[model]._fields[field_to_update.name]._related_model_field
            //     if not self.env[model]._auto or not self.env[model]._fields[model_field].store:
            //         continue
            //     if not (query_company_id := _get_query_company_id(model)):
            //         continue
            //     self.env.cr.execute(SQL(
            //         """
            //          UPDATE %(table)s
            //             SET %(column)s = (%(new_account_id_by_company_id_json)s::jsonb->>table_with_company_id.company_id::text)::int
            //            FROM (%(query_company_id)s) table_with_company_id
            //           WHERE table_with_company_id.id = %(table)s.id
            //             AND %(column)s = %(account_id)s
            //             AND %(model_column)s = 'account.account'
            //             AND table_with_company_id.company_id IN %(company_ids_to_update)s
            //         """,
            //         table=SQL.identifier(self.env[model]._table),
            //         column=SQL.identifier(field_to_update.name),
            //         new_account_id_by_company_id_json=new_account_id_by_company_id_json,
            //         query_company_id=query_company_id,
            //         account_id=self.id,
            //         model_column=SQL.identifier(model_field),
            //         company_ids_to_update=tuple(new_account_id_by_company_id),
            //     ))
            // 
            // # 3.4: Update company_dependent fields
            // # Dispatch the values of the existing account to the new accounts.
            // self.env.cr.execute(SQL(
            //     """
            //     WITH new_account_company AS (
            //         SELECT key AS company_id, value::int AS account_id
            //         FROM json_each_text(%(new_account_id_by_company_id_json)s)
            //     )
            //     UPDATE %(table)s new
            //     SET %(migrate_fields)s
            //     FROM %(table)s old, new_account_company a2c
            //     WHERE old.id = %(old_id)s
            //     AND a2c.account_id = new.id
            //     AND new.id IN %(new_ids)s
            //     """,
            //     new_account_id_by_company_id_json=new_account_id_by_company_id_json,
            //     table=SQL.identifier(self._table),
            //     migrate_fields=SQL(', ').join(
            //         SQL(
            //             """
            //             %(field)s = CASE WHEN old.%(field)s ? a2c.company_id
            //                         THEN jsonb_build_object(a2c.company_id, old.%(field)s->a2c.company_id)
            //                         ELSE NULL END
            //             """,
            //             field=SQL.identifier(field_name),
            //         )
            //         for field_name, field in self._fields.items()
            //         if field.company_dependent
            //     ),
            //     old_id=self.id,
            //     new_ids=tuple(new_accounts.ids)
            // ))
            // # On the original account, remove values for other companies
            // self.env.cr.execute(SQL(
            //     "UPDATE %(table)s SET %(fields_drop_company_ids)s WHERE id = %(id)s",
            //     table=SQL.identifier(self._table),
            //     fields_drop_company_ids=SQL(', ').join(
            //         SQL(
            //             "%(field)s = NULLIF(%(field)s - %(company_ids)s, '{}'::jsonb)",
            //             field=SQL.identifier(field_name),
            //             company_ids=list(new_account_id_by_company_id)
            //         )
            //         for field_name, field in self._fields.items()
            //         if field.company_dependent
            //     ),
            //     id=self.id
            // ))
            // 
            // # 3.5. Split account xmlids based on the company_id that is present within the xmlid
            // self.env['ir.model.data'].invalidate_model()
            // account_id_by_company_id_json = json.dumps({**new_account_id_by_company_id, str(base_company.id): self.id})
            // self.env.cr.execute(SQL(
            //     """
            //      UPDATE ir_model_data
            //         SET res_id = (
            //                 %(account_id_by_company_id_json)s::jsonb->>
            //                 substring(name, %(xmlid_regex)s)
            //             )::int
            //       WHERE module = 'account'
            //         AND model = 'account.account'
            //         AND res_id = %(account_id)s
            //         AND name ~ %(xmlid_regex)s
            //     """,
            //     account_id_by_company_id_json=account_id_by_company_id_json,
            //     xmlid_regex=r'([\d]+)_.*',
            //     account_id=self.id,
            // ))
            // 
            // # Clear ir.model.data ormcache
            // self.env.registry.clear_cache()
            // 
            // # Step 4: Change check_company fields to only keep values compatible with the account's company, and update company_ids on account.
            // write_vals = {'company_ids': [Command.set(base_company.ids)]}
            // check_company_fields = {field for field in self._fields.values() if field.relational and field.check_company}
            // for field in check_company_fields:
            //     corecord = self[field.name]
            //     filtered_corecord = corecord.filtered_domain(corecord._check_company_domain(base_company))
            //     write_vals[field.name] = filtered_corecord.id if field.type == 'many2one' else [Command.set(filtered_corecord.ids)]
            // 
            // self.write(write_vals)
            // 
            // # Step 5: Put a log in the chatter of the newly-created accounts
            // msg_body = _(
            //     "This account was split off from %(account_name)s (%(company_name)s).",
            //     account_name=self._get_html_link(title=self.display_name),
            //     company_name=base_company.name,
            // )
            // new_accounts._message_log_batch(bodies={a.id: msg_body for a in new_accounts})
            // 
            // return new_accounts
            */
            return default;
        }

        protected async Task<AccountAccount> BuildSpreadsheetFormulaDomainInternalAsync(object formula_params, object default_accounts)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet_account, FILE: account.py) ---
            // def _build_spreadsheet_formula_domain(self, formula_params, default_accounts=False):
            // codes = [code for code in formula_params["codes"] if code]
            // 
            // default_domain = expression.FALSE_DOMAIN
            // if not codes:
            //     if not default_accounts:
            //         return default_domain
            //     default_domain = [('account_type', 'in', ['liability_payable', 'asset_receivable'])]
            // 
            // company_id = formula_params["company_id"] or self.env.company.id
            // company = self.env["res.company"].browse(company_id)
            // start, end = self._get_date_period_boundaries(
            //     formula_params["date_range"], company
            // )
            // balance_domain = [
            //     ("account_id.include_initial_balance", "=", True),
            //     ("date", "<=", end),
            // ]
            // pnl_domain = [
            //     ("account_id.include_initial_balance", "=", False),
            //     ("date", ">=", start),
            //     ("date", "<=", end),
            // ]
            // # It is more optimized to (like) search for code directly in account.account than in account_move_line
            // code_domain = expression.OR(
            //     [
            //         ("code", "=like", f"{code}%"),
            //     ]
            //     for code in codes
            // )
            // account_domain = expression.OR([code_domain, default_domain])
            // account_ids = self.env["account.account"].with_company(company_id).search(account_domain).ids
            // code_domain = [("account_id", "in", account_ids)]
            // period_domain = expression.OR([balance_domain, pnl_domain])
            // domain = expression.AND([code_domain, period_domain, [("company_id", "=", company_id)]])
            // if formula_params["include_unposted"]:
            //     domain = expression.AND(
            //         [domain, [("move_id.state", "!=", "cancel")]]
            //     )
            // else:
            //     domain = expression.AND(
            //         [domain, [("move_id.state", "=", "posted")]]
            //     )
            // partner_ids = [int(partner_id) for partner_id in formula_params.get('partner_ids', []) if partner_id]
            // if partner_ids:
            //     domain = expression.AND(
            //         [domain, [("partner_id", "in", partner_ids)]]
            //     )
            // return domain
            */
            return default;
        }

        protected async Task<AccountAccount> CheckAccountCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _check_account_code(self):
            // for account in self:
            //     if account.code and not re.match(ACCOUNT_CODE_REGEX, account.code):
            //         raise ValidationError(_(
            //             "The account code can only contain alphanumeric characters and dots."
            //         ))
            */
            return default;
        }

        protected async Task<AccountAccount> CheckAccountIsBankJournalBankAccountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _check_account_is_bank_journal_bank_account(self):
            // self.env['account.account'].flush_model(['account_type'])
            // self.env['account.journal'].flush_model(['type', 'default_account_id'])
            // self._cr.execute('''
            //     SELECT journal.id
            //       FROM account_journal journal
            //       JOIN account_account account ON journal.default_account_id = account.id
            //      WHERE account.account_type IN ('asset_receivable', 'liability_payable')
            //        AND account.id IN %s
            //      LIMIT 1;
            // ''', [tuple(self.ids)])
            // 
            // if self._cr.fetchone():
            //     raise ValidationError(_("You cannot change the type of an account set as Bank Account on a journal to Receivable or Payable."))
            */
            return default;
        }

        protected async Task<AccountAccount> CheckAccountTypeSalesPurchaseJournalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _check_account_type_sales_purchase_journal(self):
            // if not self:
            //     return
            // 
            // self.env['account.account'].flush_model(['account_type'])
            // self.env['account.journal'].flush_model(['type', 'default_account_id'])
            // self._cr.execute('''
            //     SELECT account.id
            //     FROM account_account account
            //     JOIN account_journal journal ON journal.default_account_id = account.id
            //     WHERE account.id IN %s
            //     AND account.account_type IN ('asset_receivable', 'liability_payable')
            //     AND journal.type IN ('sale', 'purchase')
            //     LIMIT 1;
            // ''', [tuple(self.ids)])
            // 
            // if self._cr.fetchone():
            //     raise ValidationError(_("The account is already in use in a 'sale' or 'purchase' journal. This means that the account's type couldn't be 'receivable' or 'payable'."))
            */
            return default;
        }

        protected async Task<AccountAccount> CheckAccountTypeUniqueCurrentYearEarningInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _check_account_type_unique_current_year_earning(self):
            // result = self._read_group(
            //     domain=[('account_type', '=', 'equity_unaffected')],
            //     groupby=['company_ids'],
            //     aggregates=['id:recordset'],
            //     having=[('__count', '>', 1)],
            // )
            // for _company, account_unaffected_earnings in result:
            //     raise ValidationError(_('You cannot have more than one account with "Current Year Earnings" as type. (accounts: %s)', [a.code for a in account_unaffected_earnings]))
            */
            return default;
        }

        protected async Task<AccountAccount> CheckActionUnmergePossibleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _check_action_unmerge_possible(self):
            // """ Raises an error if the recordset `self` cannot be unmerged. """
            // self.check_access('write')
            // 
            // if forbidden_companies := (self.sudo().company_ids - self.env.user.company_ids):
            //     raise UserError(_(
            //         "You do not have the right to perform this operation as you do not have access to the following companies: %s.",
            //         ", ".join(c.name for c in forbidden_companies)
            //     ))
            // for account in self:
            //     if len(account.company_ids) == 1:
            //         raise UserError(_(
            //             "Account %s cannot be unmerged as it already belongs to a single company. "
            //             "The unmerge operation only splits an account based on its companies.",
            //             account.display_name,
            //         ))
            */
            return default;
        }

        protected async Task<AccountAccount> CheckCompanyConsistencyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _check_company_consistency(self):
            // if accounts_without_company := self.filtered(lambda a: not a.sudo().company_ids):
            //     raise ValidationError(
            //         _("The following accounts must be assigned to at least one company:")
            //         + "\n" + "\n".join(f"- {account.display_name}" for account in accounts_without_company)
            //     )
            // if self.filtered(lambda a: a.account_type == 'asset_cash' and len(a.company_ids) > 1):
            //     raise ValidationError(_("Bank & Cash accounts cannot be shared between companies."))
            // 
            // for companies, accounts in self.grouped(lambda a: a.company_ids).items():
            //     if self.env['account.move.line'].sudo().search_count([
            //         ('account_id', 'in', accounts.ids),
            //         '!', ('company_id', 'child_of', companies.ids)
            //     ], limit=1):
            //         raise UserError(_("You can't unlink this company from this account since there are some journal items linked to it."))
            */
            return default;
        }

        protected async Task<AccountAccount> CheckJournalConsistencyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _check_journal_consistency(self):
            // ''' Ensure the currency set on the journal is the same as the currency set on the
            // linked accounts.
            // '''
            // if not self:
            //     return
            // 
            // self.env['account.account'].flush_model(['currency_id'])
            // self.env['account.journal'].flush_model([
            //     'currency_id',
            //     'default_account_id',
            //     'suspense_account_id',
            // ])
            // self.env['account.payment.method'].flush_model(['payment_type'])
            // self.env['account.payment.method.line'].flush_model(['payment_method_id', 'payment_account_id'])
            // 
            // self._cr.execute('''
            //     SELECT
            //         account.id,
            //         journal.id
            //     FROM account_journal journal
            //     JOIN res_company company ON company.id = journal.company_id
            //     JOIN account_account account ON account.id = journal.default_account_id
            //     WHERE journal.currency_id IS NOT NULL
            //     AND journal.currency_id != company.currency_id
            //     AND account.currency_id != journal.currency_id
            //     AND account.id IN %(accounts)s
            // 
            //     UNION ALL
            // 
            //     SELECT
            //         account.id,
            //         journal.id
            //     FROM account_journal journal
            //     JOIN res_company company ON company.id = journal.company_id
            //     JOIN account_payment_method_line apml ON apml.journal_id = journal.id
            //     JOIN account_payment_method apm on apm.id = apml.payment_method_id
            //     JOIN account_account account ON account.id = apml.payment_account_id
            //     WHERE journal.currency_id IS NOT NULL
            //     AND journal.currency_id != company.currency_id
            //     AND account.currency_id != journal.currency_id
            //     AND apm.payment_type = 'inbound'
            //     AND account.id IN %(accounts)s
            // 
            //     UNION ALL
            // 
            //     SELECT
            //         account.id,
            //         journal.id
            //     FROM account_journal journal
            //     JOIN res_company company ON company.id = journal.company_id
            //     JOIN account_payment_method_line apml ON apml.journal_id = journal.id
            //     JOIN account_payment_method apm on apm.id = apml.payment_method_id
            //     JOIN account_account account ON account.id = apml.payment_account_id
            //     WHERE journal.currency_id IS NOT NULL
            //     AND journal.currency_id != company.currency_id
            //     AND account.currency_id != journal.currency_id
            //     AND apm.payment_type = 'outbound'
            //     AND account.id IN %(accounts)s
            // ''', {
            //     'accounts': tuple(self.ids)
            // })
            // res = self._cr.fetchone()
            // if res:
            //     account = self.env['account.account'].browse(res[0])
            //     journal = self.env['account.journal'].browse(res[1])
            //     raise ValidationError(_(
            //         "The foreign currency set on the journal '%(journal)s' and the account '%(account)s' must be the same.",
            //         journal=journal.display_name,
            //         account=account.display_name
            //     ))
            */
            return default;
        }

        protected async Task<AccountAccount> CheckReconcileInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _check_reconcile(self):
            // for account in self:
            //     if account.account_type in ('asset_receivable', 'liability_payable') and not account.reconcile:
            //         raise ValidationError(_('You cannot have a receivable/payable account that is not reconcilable. (account code: %s)', account.code))
            */
            return default;
        }

        protected async Task<AccountAccount> CheckUsedAsJournalDefaultDebitCreditAccountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _check_used_as_journal_default_debit_credit_account(self):
            // accounts = self.filtered(lambda a: not a.reconcile)
            // if not accounts:
            //     return
            // 
            // self.env['account.journal'].flush_model(['company_id', 'default_account_id'])
            // self.env['account.payment.method.line'].flush_model(['journal_id', 'payment_account_id'])
            // 
            // self._cr.execute('''
            //     SELECT journal.id
            //     FROM account_journal journal
            //     JOIN res_company company on journal.company_id = company.id
            //     LEFT JOIN account_payment_method_line apml ON journal.id = apml.journal_id
            //     WHERE (
            //         apml.payment_account_id IN %(accounts)s
            //         AND apml.payment_account_id != journal.default_account_id
            //     )
            // ''', {
            //     'accounts': tuple(accounts.ids),
            // })
            // 
            // rows = self._cr.fetchall()
            // if rows:
            //     journals = self.env['account.journal'].browse([r[0] for r in rows])
            //     raise ValidationError(_(
            //         "This account is configured in %(journal_names)s journal(s) (ids %(journal_ids)s) as payment debit or credit account. This means that this account's type should be reconcilable.",
            //         journal_names=journals.mapped('display_name'),
            //         journal_ids=journals.ids
            //     ))
            */
            return default;
        }

        protected async Task<AccountAccount> ComputeAccountGroupInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _compute_account_group(self):
            // accounts_with_code = self.filtered(lambda a: a.code)
            // 
            // (self - accounts_with_code).group_id = False
            // 
            // if not accounts_with_code:
            //     return
            // 
            // codes = accounts_with_code.mapped('code')
            // account_code_values = SQL(','.join(['(%s)'] * len(codes)), *codes)
            // results = self.env.execute_query(SQL(
            //     """
            //          SELECT DISTINCT ON (account_code.code)
            //                 account_code.code,
            //                 agroup.id AS group_id
            //            FROM (VALUES %(account_code_values)s) AS account_code (code)
            //       LEFT JOIN account_group agroup
            //              ON agroup.code_prefix_start <= LEFT(account_code.code, char_length(agroup.code_prefix_start))
            //                 AND agroup.code_prefix_end >= LEFT(account_code.code, char_length(agroup.code_prefix_end))
            //                 AND agroup.company_id = %(root_company_id)s
            //        ORDER BY account_code.code, char_length(agroup.code_prefix_start) DESC, agroup.id
            //     """,
            //     account_code_values=account_code_values,
            //     root_company_id=self.env.company.root_id.id,
            // ))
            // group_by_code = dict(results)
            // 
            // for account in accounts_with_code:
            //     account.group_id = group_by_code[account.code]
            */
            return default;
        }

        protected async Task<AccountAccount> ComputeAccountRootInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _compute_account_root(self):
            // for record in self:
            //     record.root_id = self.env['account.root']._from_account_code(record.placeholder_code)
            */
            return default;
        }

        protected async Task<AccountAccount> ComputeAccountTagsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _compute_account_tags(self):
            // accounts_to_process = self.filtered(lambda account: account.code and not account.tag_ids)
            // self._get_closest_parent_account(accounts_to_process, 'tag_ids', default_value=[])
            */
            return default;
        }

        protected async Task<AccountAccount> ComputeAccountTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _compute_account_type(self):
            // accounts_to_process = self.filtered(lambda account: account.code and not account.account_type)
            // self._get_closest_parent_account(accounts_to_process, 'account_type', default_value='asset_current')
            */
            return default;
        }

        protected async Task<AccountAccount> ComputeCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _compute_code(self):
            // for record, record_root in zip(self, self.with_company(self.env.company.root_id).sudo()):
            //     # Need to set record.code with `company = self.env.company`, not `self.env.company.root_id`
            //     record.code = record_root.code_store
            */
            return default;
        }

        protected async Task<AccountAccount> ComputeCompanyCurrencyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _compute_company_currency_id(self):
            // self.company_currency_id = self.env.company.currency_id
            */
            return default;
        }

        protected async Task<AccountAccount> ComputeCompanyFiscalCountryCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _compute_company_fiscal_country_code(self):
            // self.company_fiscal_country_code = self.env.company.account_fiscal_country_id.code
            */
            return default;
        }

        protected async Task<AccountAccount> ComputeCurrentBalanceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _compute_current_balance(self):
            // balances = {
            //     account.id: balance
            //     for account, balance in self.env['account.move.line']._read_group(
            //         domain=[('account_id', 'in', self.ids), ('parent_state', '=', 'posted'), ('company_id', '=', self.env.company.id)],
            //         groupby=['account_id'],
            //         aggregates=['balance:sum'],
            //     )
            // }
            // for record in self:
            //     record.current_balance = balances.get(record.id, 0)
            */
            return default;
        }

        protected async Task<AccountAccount> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _compute_display_name(self):
            // for account in self:
            //     account.display_name = f"{account.code} {account.name}" if account.code else account.name
            */
            return default;
        }

        protected async Task<AccountAccount> ComputeIncludeInitialBalanceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _compute_include_initial_balance(self):
            // for account in self:
            //     account.include_initial_balance = account.internal_group not in ['income', 'expense']
            */
            return default;
        }

        protected async Task<AccountAccount> ComputeInternalGroupInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _compute_internal_group(self):
            // for account in self:
            //     account.internal_group = account.account_type and account._get_internal_group(account.account_type)
            */
            return default;
        }

        protected async Task<AccountAccount> ComputeOpeningDebitCreditInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _compute_opening_debit_credit(self):
            // self.opening_debit = 0
            // self.opening_credit = 0
            // self.opening_balance = 0
            // opening_move = self.env.company.account_opening_move_id
            // if not self.ids or not opening_move:
            //     return
            // self.env.cr.execute(SQL(
            //     """
            //     SELECT line.account_id,
            //            SUM(line.balance) AS balance,
            //            SUM(line.debit) AS debit,
            //            SUM(line.credit) AS credit
            //       FROM account_move_line line
            //      WHERE line.move_id = %(opening_move_id)s
            //        AND line.account_id IN %(account_ids)s
            //      GROUP BY line.account_id
            //     """,
            //     account_ids=tuple(self.ids),
            //     opening_move_id=opening_move.id,
            // ))
            // result = {r['account_id']: r for r in self.env.cr.dictfetchall()}
            // for record in self:
            //     res = result.get(record.id) or {'debit': 0, 'credit': 0, 'balance': 0}
            //     record.opening_debit = res['debit']
            //     record.opening_credit = res['credit']
            //     record.opening_balance = res['balance']
            */
            return default;
        }

        protected async Task<AccountAccount> ComputePlaceholderCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _compute_placeholder_code(self):
            // self.placeholder_code = False
            // for record in self:
            //     if record.code:
            //         record.placeholder_code = record.code
            //     elif authorized_companies := (record.company_ids & self.env['res.company'].browse(self.env.user._get_company_ids())).sorted('id'):
            //         company = authorized_companies[0]
            //         if code := record.with_company(company).code:
            //             record.placeholder_code = f'{code} ({company.name})'
            */
            return default;
        }

        protected async Task<AccountAccount> ComputeReconcileInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _compute_reconcile(self):
            // for account in self:
            //     if account.internal_group in ('income', 'expense', 'equity'):
            //         account.reconcile = False
            //     elif account.account_type in ('asset_receivable', 'liability_payable'):
            //         account.reconcile = True
            //     elif account.account_type in ('asset_cash', 'liability_credit_card', 'off_balance'):
            //         account.reconcile = False
            */
            return default;
        }

        protected async Task<AccountAccount> ComputeRelatedTaxesAmountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _compute_related_taxes_amount(self):
            // for record in self:
            //     record.related_taxes_amount = self.env['account.tax'].search_count([
            //         *self.env['account.tax']._check_company_domain(self.env.company),
            //         ('repartition_line_ids.account_id', '=', record.id),
            //     ])
            */
            return default;
        }

        protected async Task<AccountAccount> ComputeUsedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _compute_used(self):
            // ids = set(self._search_used('=', True)[0][2])
            // for record in self:
            //     record.used = record.id in ids
            */
            return default;
        }

        protected async Task<AccountAccount> ConstrainsAllowedJournalIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _constrains_allowed_journal_ids(self):
            // self.env['account.move.line'].flush_model(['account_id', 'journal_id'])
            // self.flush_recordset(['allowed_journal_ids'])
            // self._cr.execute("""
            //     SELECT aml.id
            //     FROM account_move_line aml
            //     WHERE aml.account_id in %s
            //     AND EXISTS (SELECT 1 FROM account_account_account_journal_rel WHERE account_account_id = aml.account_id)
            //     AND NOT EXISTS (SELECT 1 FROM account_account_account_journal_rel WHERE account_account_id = aml.account_id AND account_journal_id = aml.journal_id)
            // """, [tuple(self.ids)])
            // ids = self._cr.fetchall()
            // if ids:
            //     raise ValidationError(_('Some journal items already exist with this account but in other journals than the allowed ones.'))
            */
            return default;
        }

        protected async Task<AccountAccount> ConstrainsReconcileInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _constrains_reconcile(self):
            // for record in self:
            //     if record.account_type == 'off_balance':
            //         if record.reconcile:
            //             raise UserError(_('An Off-Balance account can not be reconcilable'))
            //         if record.tax_ids:
            //             raise UserError(_('An Off-Balance account can not have taxes'))
            */
            return default;
        }

        public async Task<AccountAccount> CopyDataAsync(Guid id, object @default)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default)
            // default = default or {}
            // cache = defaultdict(set)
            // 
            // for account, vals in zip(self, vals_list):
            //     company_ids = self._fields['company_ids'].convert_to_cache(vals['company_ids'], self.browse())
            //     companies = self.env['res.company'].browse(company_ids)
            // 
            //     if 'code_mapping_ids' not in default and ('code' not in default or len(companies) > 1):
            //         companies_to_get_new_account_codes = companies if 'code' not in default else companies[1:]
            //         vals['code_mapping_ids'] = []
            // 
            //         for company in companies_to_get_new_account_codes:
            //             start_code = account.with_company(company).code or account.with_company(account.company_ids[0]).code
            //             new_code = account.with_company(company)._search_new_account_code(start_code, cache[company.id])
            //             vals['code_mapping_ids'].append(Command.create({'company_id': company.id, 'code': new_code}))
            //             cache[company.id].add(new_code)
            // 
            //     if 'name' not in default:
            //         vals['name'] = self.env._("%s (copy)", account.name or '')
            // 
            // return vals_list
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountAccount> CopyTranslationsAsync(Guid id, object @new, object excluded)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def copy_translations(self, new, excluded=()):
            // super().copy_translations(new, excluded=tuple(excluded)+('name',))
            // if new.name == self.env._('%s (copy)', self.name):
            //     name_field = self._fields['name']
            //     self.env.cache.update_raw(new, name_field, [{
            //         lang: self.env._('%s (copy)', tr)
            //         for lang, tr in name_field._get_stored_translations(self).items()
            //     }], dirty=True)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<AccountAccount> CreateAsync(AccountAccount entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def create(self, vals_list):
            // records_list = []
            // 
            // for company_ids, vals_list_for_company in itertools.groupby(vals_list, lambda v: v.get('company_ids', [])):
            //     cache = set()
            //     vals_list_for_company = list(vals_list_for_company)
            // 
            //     # Determine the companies the new accounts will have.
            //     company_ids = self._fields['company_ids'].convert_to_cache(company_ids, self.browse())
            //     companies = self.env['res.company'].browse(company_ids)
            //     if self.env.company in companies or not companies:
            //         companies = self.env.company | companies  # The currently active company comes first.
            // 
            //     for vals in vals_list_for_company:
            //         if 'prefix' in vals:
            //             prefix, digits = vals.pop('prefix'), vals.pop('code_digits')
            //             start_code = prefix.ljust(digits - 1, '0') + '1' if len(prefix) < digits else prefix
            //             vals['code'] = self.with_company(companies[0])._search_new_account_code(start_code, cache)
            //             cache.add(vals['code'])
            // 
            //         if 'code' not in vals:  # prepopulate the code for precomputed fields depending on it
            //             for mapping_command in vals.get('code_mapping_ids', []):
            //                 match mapping_command:
            //                     case Command.CREATE, _, {'company_id': company_id, 'code': code} if company_id == companies[0].id:
            //                         vals['code'] = code
            //                         break
            // 
            //     new_accounts = super(AccountAccount, self.with_context(
            //         allowed_company_ids=companies.ids,
            //         defer_account_code_checks=True,
            //         # Don't get a default value for `code_mapping_ids` from default_get
            //         default_code_mapping_ids=self.env.context.get('default_code_mapping_ids', []),
            //     )).create(vals_list_for_company)
            // 
            //     records_list.append(new_accounts)
            // 
            // records = self.env['account.account'].union(*records_list)
            // records._ensure_code_is_unique()
            // return records
            --- ODOO METHOD SOURCE (MODULE: l10n_mx, FILE: account_account.py) ---
            // def create(self, vals_list):
            // # EXTENDS account - ensure there is a tag on created MX accounts
            // # The computation is a bit naive and might not be correct in all cases.
            // accounts = super().create(vals_list)
            // debit_tag = self.env.ref('l10n_mx.tag_debit_balance_account', raise_if_not_found=False)
            // credit_tag = self.env.ref('l10n_mx.tag_credit_balance_account', raise_if_not_found=False)
            // if not debit_tag or not credit_tag:
            //     return accounts
            // mx_account_no_tags = accounts.filtered(lambda a: 'MX' in a.company_ids.mapped('country_code') and not a.tag_ids & (credit_tag + debit_tag))
            // DEBIT_CODES = ['1', '5', '6', '7']  # all other codes are considered "credit"
            // for account in mx_account_no_tags:
            //     tag_id = debit_tag.id if account.code[0] in DEBIT_CODES else credit_tag.id
            //     account.tag_ids = [Command.link(tag_id)]
            // return accounts
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<AccountAccount> EnsureCodeIsUniqueInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _ensure_code_is_unique(self):
            // """ Check account codes per companies. These are the checks:
            // 
            //     1. Check that the code is set for each of the account's companies.
            // 
            //     2. Check that no child or parent companies have another account with the same code
            //        as the account.
            // 
            //        The definition of availability is the same as the one used by _search_new_account_code
            //        and both methods need to be kept in sync.
            // """
            // # Check 1: Check that the code is set.
            // for account in self.sudo():
            //     for company in account.company_ids.root_id:
            //         if not account.with_company(company).code:
            //             raise ValidationError(_("The code must be set for every company to which this account belongs."))
            // 
            // # Check 2: Check that no child or parent companies have an account with the same code.
            // 
            // # Do a grouping by companies in `company_ids`.
            // account_ids_to_check_by_company = defaultdict(list)
            // for account in self.sudo():
            //     companies_to_check = account.company_ids
            //     for company in companies_to_check:
            //         account_ids_to_check_by_company[company].append(account.id)
            // 
            // for company, account_ids in account_ids_to_check_by_company.items():
            //     accounts = self.browse(account_ids).with_prefetch(self.ids).sudo()
            // 
            //     # Check 2.1: Check that there are no duplicates in the given recordset.
            //     accounts_by_code = accounts.with_company(company).grouped('code')
            //     duplicate_codes = None
            //     if len(accounts_by_code) < len(accounts):
            //         duplicate_codes = [code for code, accounts in accounts_by_code.items() if len(accounts) > 1]
            // 
            //     # Check 2.2: Check that there are no duplicates in database
            //     elif duplicates := self.with_company(company).sudo().search_fetch(
            //         [
            //             ('code', 'in', list(accounts_by_code)),
            //             ('id', 'not in', self.ids),
            //             '|',
            //             ('company_ids', 'parent_of', company.ids),
            //             ('company_ids', 'child_of', company.ids),
            //         ],
            //         ['code_store'],
            //     ):
            //         duplicate_codes = duplicates.mapped('code')
            //     if duplicate_codes:
            //         raise ValidationError(
            //             _("Account codes must be unique. You can't create accounts with these duplicate codes: %s", ", ".join(duplicate_codes))
            //         )
            */
            return default;
        }

        protected async Task<object> FieldToSqlInternalAsync(string @alias, string fname, object query, bool flush)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _field_to_sql(self, alias: str, fname: str, query: (Query | None) = None, flush: bool = True) -> SQL:
            // if fname == 'internal_group':
            //     return SQL("split_part(%s, '_', 1)", self._field_to_sql(alias, 'account_type', query, flush))
            // if fname == 'code':
            //     return self.with_company(self.env.company.root_id).sudo()._field_to_sql(alias, 'code_store', query, flush)
            // if fname == 'placeholder_code':
            //     if 'account_first_company' not in query._joins:
            //         # When multiple accounts are selected, ``placeholder_code`` is used for all of them
            //         # as it is in the default ``_order`` (e.g., for ``account_asset_id`` and
            //         # ``account_depreciation_id`` in ``account_assets``).
            // 
            //         # As ``placeholder_code`` represents the account's code in the first active company
            //         # to which the account belongs in the hierarchy, we must ensure that we do not introduce
            //         # a second ``JOIN`` to the account-company relation to avoid redundancy in joins.
            //         query.add_join(
            //             'LEFT JOIN',
            //             'account_first_company',
            //             SQL(
            //                 """(
            //                     SELECT DISTINCT ON (rel.account_account_id)
            //                         rel.account_account_id AS account_id,
            //                         rel.res_company_id AS company_id,
            //                         SPLIT_PART(res_company.parent_path, '/', 1) AS root_company_id,
            //                         res_company.name AS company_name
            //                     FROM account_account_res_company_rel rel
            //                     JOIN res_company
            //                         ON res_company.id = rel.res_company_id
            //                     WHERE rel.res_company_id IN %(authorized_company_ids)s
            //                 ORDER BY rel.account_account_id, company_id
            //                 )""",
            //                 authorized_company_ids=self.env.user._get_company_ids(),
            //                 to_flush=self._fields['company_ids'],
            //             ),
            //             SQL('account_first_company.account_id = %(account_id)s', account_id=SQL.identifier(alias, 'id')),
            //         )
            // 
            //     return SQL(
            //         """
            //             COALESCE(
            //                 %(code_store)s->>%(active_company_root_id)s,
            //                 %(code_store)s->>%(account_first_company_root_id)s || ' (' || %(account_first_company_name)s || ')'
            //             )
            //         """,
            //         code_store=SQL.identifier(alias, 'code_store'),
            //         active_company_root_id=str(self.env.company.root_id.id),
            //         account_first_company_name=SQL.identifier('account_first_company', 'company_name'),
            //         account_first_company_root_id=SQL.identifier('account_first_company', 'root_company_id'),
            //         to_flush=self._fields['code_store'],
            //     )
            // if fname == 'root_id':
            //     return SQL(
            //         "SUBSTRING(%(placeholder_code)s, 1, 2)",
            //         placeholder_code=self._field_to_sql(alias, 'placeholder_code', query, flush),
            //     )
            // 
            // return super()._field_to_sql(alias, fname, query, flush)
            */
            return default;
        }

        public async Task<AccountAccount> GetAccountGroupAsync(Guid id, object account_types)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet_account, FILE: account.py) ---
            // def get_account_group(self, account_types):
            // data = self._read_group(
            //     [
            //         *self._check_company_domain(self.env.company),
            //         ("account_type", "in", account_types),
            //     ],
            //     ['account_type'],
            //     ['code:array_agg'],
            // )
            // mapped = dict(data)
            // return [mapped.get(account_type, []) for account_type in account_types]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountAccount> GetClosestParentAccountInternalAsync(object accounts_to_process, object field_name, object default_value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _get_closest_parent_account(self, accounts_to_process, field_name, default_value):
            // """
            //     This helper function retrieves the closest parent account based on account codes
            //     for the given accounts to process and assigns the value of the parent to the specified field.
            // 
            //     :param accounts_to_process: Records of accounts to be processed.
            //     :param field_name: Name of the field to be updated with the closest parent account value.
            //     :param default_value: Default value to be assigned if no parent account is found.
            // """
            // assert field_name in self._fields
            // 
            // all_accounts = self.search_read(
            //     domain=self._check_company_domain(self.env.company),
            //     fields=['code', field_name],
            //     order='code',
            // )
            // accounts_with_codes = {}
            // # We want to group accounts by company to only search for account codes of the current company
            // for account in all_accounts:
            //     accounts_with_codes[account['code']] = account[field_name]
            // for account in accounts_to_process:
            //     codes_list = list(accounts_with_codes.keys())
            //     closest_index = bisect_left(codes_list, account.code) - 1
            //     account[field_name] = accounts_with_codes[codes_list[closest_index]] if closest_index != -1 else default_value
            */
            return default;
        }

        protected async Task<AccountAccount> GetDatePeriodBoundariesInternalAsync(object date_period, object company)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet_account, FILE: account.py) ---
            // def _get_date_period_boundaries(self, date_period, company):
            // period_type = date_period["range_type"]
            // year = date_period.get("year")
            // month = date_period.get("month")
            // quarter = date_period.get("quarter")
            // day = date_period.get("day")
            // if period_type == "year":
            //     fiscal_day = company.fiscalyear_last_day
            //     fiscal_month = int(company.fiscalyear_last_month)
            //     if not (fiscal_day == 31 and fiscal_month == 12):
            //         year += 1
            //     max_day = calendar.monthrange(year, fiscal_month)[1]
            //     current = date(year, fiscal_month, min(fiscal_day, max_day))
            //     start, end = date_utils.get_fiscal_year(current, fiscal_day, fiscal_month)
            // elif period_type == "month":
            //     start = date(year, month, 1)
            //     end = start + relativedelta(months=1, days=-1)
            // elif period_type == "quarter":
            //     first_month = quarter * 3 - 2
            //     start = date(year, first_month, 1)
            //     end = start + relativedelta(months=3, days=-1)
            // elif period_type == "day":
            //     fiscal_day = company.fiscalyear_last_day
            //     fiscal_month = int(company.fiscalyear_last_month)
            //     end = date(year, month, day)
            //     start, _ = date_utils.get_fiscal_year(end, fiscal_day, fiscal_month)
            // return start, end
            */
            return default;
        }

        public async Task<AccountAccount> GetImportTemplatesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Chart of Accounts'),
            //     'template': '/account/static/xls/coa_import_template.xlsx'
            // }]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountAccount> GetInternalGroupInternalAsync(object account_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _get_internal_group(self, account_type):
            // return account_type.split('_', maxsplit=1)[0]
            */
            return default;
        }

        protected async Task<AccountAccount> GetMostFrequentAccountForPartnerInternalAsync(Guid company_id, Guid partner_id, object move_type, Guid journal_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _get_most_frequent_account_for_partner(self, company_id, partner_id, move_type=None, journal_id=None):
            // most_frequent_account = self._get_most_frequent_accounts_for_partner(company_id, partner_id, move_type, filter_never_user_accounts=True, limit=1, journal_id=journal_id)
            // return most_frequent_account[0] if most_frequent_account else False
            */
            return default;
        }

        protected async Task<AccountAccount> GetMostFrequentAccountsForPartnerInternalAsync(Guid company_id, Guid partner_id, object move_type, object filter_never_user_accounts, object limit, Guid journal_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _get_most_frequent_accounts_for_partner(self, company_id, partner_id, move_type, filter_never_user_accounts=False, limit=None, journal_id=None):
            // """
            // Returns the accounts ordered from most frequent to least frequent for a given partner
            // and filtered according to the move type
            // :param company_id: the company id
            // :param partner_id: the partner id for which we want to retrieve the most frequent accounts
            // :param move_type: the type of the move to know which type of accounts to retrieve
            // :param filter_never_user_accounts: True if we should filter out accounts never used for the partner
            // :param limit: the maximum number of accounts to retrieve
            // :param journal_id: only return accounts allowed on this journal id
            // :returns: List of account ids, ordered by frequency (from most to least frequent)
            // """
            // domain = [
            //     *self.env['account.move.line']._check_company_domain(company_id),
            //     ('partner_id', '=', partner_id),
            //     ('account_id.deprecated', '=', False),
            //     ('date', '>=', fields.Date.add(fields.Date.today(), days=-365 * 2)),
            // ]
            // if journal_id:
            //     domain += ['|', ('account_id.allowed_journal_ids', '=', journal_id), ('account_id.allowed_journal_ids', '=', False)]
            // if move_type in self.env['account.move'].get_inbound_types(include_receipts=True):
            //     domain.append(('account_id.internal_group', '=', 'income'))
            // elif move_type in self.env['account.move'].get_outbound_types(include_receipts=True):
            //     domain.append(('account_id.internal_group', '=', 'expense'))
            // 
            // query = self.env['account.move.line']._where_calc(domain)
            // if not filter_never_user_accounts:
            //     _kind, rhs_table, condition = query._joins['account_move_line__account_id']
            //     query._joins['account_move_line__account_id'] = (SQL("RIGHT JOIN"), rhs_table, condition)
            // 
            // company = self.env['res.company'].browse(company_id)
            // code_sql = self.with_company(company)._field_to_sql('account_move_line__account_id', 'code', query)
            // 
            // return [r[0] for r in self.env.execute_query(SQL(
            //     """
            //         SELECT account_move_line__account_id.id
            //           FROM %(from_clause)s
            //          WHERE %(where_clause)s
            //       GROUP BY account_move_line__account_id.id
            //       ORDER BY COUNT(account_move_line.id) DESC, MAX(%(code_sql)s)
            //         %(limit_clause)s
            //     """,
            //     from_clause=query.from_clause,
            //     where_clause=query.where_clause or SQL("TRUE"),
            //     code_sql=code_sql,
            //     limit_clause=SQL("LIMIT %s", limit) if limit else SQL(),
            // ))]
            */
            return default;
        }

        protected async Task<AccountAccount> InverseCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _inverse_code(self):
            // for record, record_root in zip(self, self.with_company(self.env.company.root_id).sudo()):
            //     # Need to set record.code with `company = self.env.company`, not `self.env.company.root_id`
            //     record_root.code_store = record.code
            // 
            // # Changing the code for one company should also change it for all the companies which share the same root_id.
            // # The simplest way of achieving this is invalidating it for all companies here.
            // # We re-compute it right away for the active company, as it is used by constraints while `code` is still protected.
            // self.invalidate_recordset(fnames=['code'], flush=False)
            // self._compute_code()
            */
            return default;
        }

        protected async Task<AccountAccount> LoadPrecommitUpdateOpeningMoveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _load_precommit_update_opening_move(self):
            // """ precommit callback to recompute the opening move according the opening balances that changed.
            // This is particularly useful when importing a csv containing the 'opening_balance' column.
            // In that case, we don't want to use the inverse method set on field since it will be
            // called for each account separately. That would be quite costly in terms of performances.
            // Instead, the opening balances are collected and this method is called once at the end
            // to update the opening move accordingly.
            // """
            // data = self._cr.precommit.data.pop('import_account_opening_balance', {})
            // 
            // for company_id, account_values in data.items():
            //     self.env['res.company'].browse(company_id)._update_opening_move({
            //         self.env['account.account'].browse(account_id): values
            //         for account_id, values in account_values.items()
            //     })
            // 
            // self.env.flush_all()
            */
            return default;
        }

        protected async Task<AccountAccount> LoadRecordsWriteInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _load_records_write(self, values):
            // if 'prefix' in values:
            //     del values['code_digits']
            //     del values['prefix']
            // super()._load_records_write(values)
            */
            return default;
        }

        protected async Task<AccountAccount> MergeMethodInternalAsync(object destination, object source)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _merge_method(self, destination, source):
            // raise UserError(_("You cannot merge accounts."))
            */
            return default;
        }

        protected async Task<AccountAccount> OnchangeAccountTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _onchange_account_type(self):
            // if self.account_type == 'off_balance':
            //     self.tax_ids = False
            */
            return default;
        }

        protected async Task<AccountAccount> OnchangeNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _onchange_name(self):
            // code, name = self._split_code_name(self.name)
            // if code and not self.code:
            //     self.name = name
            //     self.code = code
            */
            return default;
        }

        public async Task<AccountAccount> OpenRelatedTaxesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def action_open_related_taxes(self):
            // related_taxes_ids = self.env['account.tax'].search([
            //     ('repartition_line_ids.account_id', '=', self.id),
            // ]).ids
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Taxes'),
            //     'res_model': 'account.tax',
            //     'views': [[False, 'list'], [False, 'form']],
            //     'domain': [('id', 'in', related_taxes_ids)],
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountAccount> OrderAccountsByFrequencyForPartnerInternalAsync(Guid company_id, Guid partner_id, object move_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _order_accounts_by_frequency_for_partner(self, company_id, partner_id, move_type=None):
            // return self._get_most_frequent_accounts_for_partner(company_id, partner_id, move_type)
            */
            return default;
        }

        protected async Task<AccountAccount> SearchAccountRootInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _search_account_root(self, operator, value):
            // if operator in ['=', 'child_of']:
            //     root = self.env['account.root'].browse(value)
            //     return [('placeholder_code', '=ilike', root.name + ('' if operator == '=' and not root.parent_id else '%'))]
            // raise NotImplementedError
            */
            return default;
        }

        protected async Task<AccountAccount> SearchCodeInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _search_code(self, operator, value):
            // return [('id', 'in', self.with_company(self.env.company.root_id).sudo()._search([('code_store', operator, value)]))]
            */
            return default;
        }

        protected async Task<AccountAccount> SearchDisplayNameInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _search_display_name(self, operator, value):
            // name = value or ''
            // if operator in ('=', '!='):
            //     domain = ['|', ('code', '=', name.split(' ')[0]), ('name', operator, name)]
            // else:
            //     domain = ['|', ('code', '=like', name.split(' ')[0] + '%'), ('name', operator, name)]
            // if operator in expression.NEGATIVE_TERM_OPERATORS:
            //     domain = ['&', '!'] + domain[1:]
            // return domain
            */
            return default;
        }

        protected async Task<AccountAccount> SearchIncludeInitialBalanceInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _search_include_initial_balance(self, operator, value):
            // if operator not in ['=', '!='] or not isinstance(value, bool):
            //     raise UserError(_('Operation not supported'))
            // if operator != '=':
            //     value = not value
            // return [('internal_group', 'not in' if value else 'in', ['income', 'expense'])]
            */
            return default;
        }

        protected async Task<AccountAccount> SearchInternalGroupInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _search_internal_group(self, operator, value):
            // if operator not in ['=', 'in', '!=', 'not in']:
            //     raise UserError(_('Operation not supported'))
            // domain = expression.OR([[('account_type', '=like', group)] for group in {
            //     self._get_internal_group(v) + '%'
            //     for v in (value if isinstance(value, (list, tuple)) else [value])
            // }])
            // if operator in ('!=', 'not in'):
            //     return ['!'] + expression.normalize_domain(domain)
            // return domain
            */
            return default;
        }

        protected async Task<AccountAccount> SearchNewAccountCodeInternalAsync(object start_code, object cache)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _search_new_account_code(self, start_code, cache=None):
            // """ Get an account code that is available for creating a new account in the active
            //     company by starting from an existing code and incrementing it.
            // 
            //     Examples:
            //         |  start_code  |  codes checked for availability                            |
            //         +--------------+------------------------------------------------------------+
            //         |    102100    |  102101, 102102, 102103, 102104, ...                       |
            //         |     1598     |  1599, 1600, 1601, 1602, ...                               |
            //         |   10.01.08   |  10.01.09, 10.01.10, 10.01.11, 10.01.12, ...               |
            //         |   10.01.97   |  10.01.98, 10.01.99, 10.01.97.copy2, 10.01.97.copy3, ...   |
            //         |    1021A     |  1021A, 1022A, 1023A, 1024A, ...                           |
            //         |    hello     |  hello.copy, hello.copy2, hello.copy3, hello.copy4, ...    |
            //         |     9998     |  9999, 9998.copy, 9998.copy2, 9998.copy3, ...              |
            // 
            //     :param start_code str: the code to increment until an available one is found
            //     :param set[str] cache: a set of codes which you know are already used
            //                             (optional, to speed up the method).
            //                             If none is given, the method will use cache = {start_code}.
            //                             i.e. the method will return the first available code
            //                             *strictly* greater than start_code.
            //                             If you want the method to start at start_code, you should
            //                             explicitly pass cache={}.
            // 
            //     :return str: an available new account code for the active company.
            //                  It will normally have length `len(start_code)`.
            //                  If incrementing the last digits starting from `start_code` does
            //                  not work, the method will try as a fallback
            //                  '{start_code}.copy', '{start_code}.copy2', ... '{start_code}.copy99'.
            // """
            // if cache is None:
            //     cache = {start_code}
            // 
            // def code_is_available(new_code):
            //     """ Determine whether `new_code` is available in the active company.
            // 
            //         A code is available for creating a new account in a company if no account
            //         with the same code belongs to a parent or a child company.
            // 
            //         We use the same definition of availability in `_ensure_code_is_unique`
            //         and both methods need to be kept in sync.
            //     """
            //     return (
            //         new_code not in cache
            //         and not self.sudo().search_count([
            //             ('code', '=', new_code),
            //             '|',
            //             ('company_ids', 'parent_of', self.env.company.id),
            //             ('company_ids', 'child_of', self.env.company.id),
            //         ], limit=1)
            //     )
            // 
            // if code_is_available(start_code):
            //     return start_code
            // 
            // start_str, digits_str, end_str = ACCOUNT_CODE_NUMBER_REGEX.match(start_code).groups()
            // 
            // if digits_str != '':
            //     d, n = len(digits_str), int(digits_str)
            //     for num in range(n+1, 10**d):
            //         if code_is_available(new_code := f'{start_str}{num:0{d}}{end_str}'):
            //             return new_code
            // 
            // for num in range(99):
            //     if code_is_available(new_code := f'{start_code}.copy{num and num + 1 or ""}'):
            //         return new_code
            // 
            // raise UserError(_('Cannot generate an unused account code.'))
            */
            return default;
        }

        protected async Task<AccountAccount> SearchPanelDomainImageInternalAsync(object field_name, object domain, object set_count, object limit)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _search_panel_domain_image(self, field_name, domain, set_count=False, limit=False):
            // if field_name != 'root_id' or set_count:
            //     return super()._search_panel_domain_image(field_name, domain, set_count, limit)
            // 
            // if expression.is_false(self, domain):
            //     return {}
            // 
            // query_account = self.env['account.account']._search(domain, limit=limit)
            // placeholder_code_alias = self.env['account.account']._field_to_sql('account_account', 'code', query_account)
            // 
            // placeholder_codes = self.env.execute_query(query_account.select(placeholder_code_alias))
            // return {
            //     (root := self.env['account.root']._from_account_code(code)).id: {'id': root.id, 'display_name': root.display_name}
            //     for code, in placeholder_codes if code
            // }
            */
            return default;
        }

        protected async Task<AccountAccount> SearchPlaceholderCodeInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _search_placeholder_code(self, operator, value):
            // if operator != '=ilike':
            //     raise NotImplementedError
            // query = Query(self.env, 'account_account')
            // placeholder_code_sql = self.env['account.account']._field_to_sql('account_account', 'placeholder_code', query)
            // query.add_where(SQL("%s ILIKE %s", placeholder_code_sql, value))
            // return [('id', 'in', query)]
            */
            return default;
        }

        protected async Task<AccountAccount> SearchUsedInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _search_used(self, operator, value):
            // if operator not in ['=', '!='] or not isinstance(value, bool):
            //     raise UserError(_('Operation not supported'))
            // if operator != '=':
            //     value = not value
            // self._cr.execute("""
            //     SELECT id FROM account_account account
            //     WHERE EXISTS (SELECT 1 FROM account_move_line aml WHERE aml.account_id = account.id LIMIT 1)
            // """)
            // return [('id', 'in' if value else 'not in', [r[0] for r in self._cr.fetchall()])]
            */
            return default;
        }

        protected async Task<AccountAccount> SetOpeningBalanceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _set_opening_balance(self):
            // # Tracking of the balances to be used after the import to populate the opening move in batch.
            // for account in self:
            //     balance = account.opening_balance
            //     account._set_opening_debit_credit(abs(balance) if balance > 0.0 else 0.0, 'debit')
            //     account._set_opening_debit_credit(abs(balance) if balance < 0.0 else 0.0, 'credit')
            */
            return default;
        }

        protected async Task<AccountAccount> SetOpeningCreditInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _set_opening_credit(self):
            // for record in self:
            //     record._set_opening_debit_credit(record.opening_credit, 'credit')
            */
            return default;
        }

        protected async Task<AccountAccount> SetOpeningDebitCreditInternalAsync(object amount, object field)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _set_opening_debit_credit(self, amount, field):
            // """ Generic function called by both opening_debit and opening_credit's
            // inverse function. 'Amount' parameter is the value to be set, and field
            // either 'debit' or 'credit', depending on which one of these two fields
            // got assigned.
            // """
            // self.ensure_one()
            // if 'import_account_opening_balance' not in self._cr.precommit.data:
            //     data = self._cr.precommit.data['import_account_opening_balance'] = {}
            //     self._cr.precommit.add(self._load_precommit_update_opening_move)
            // else:
            //     data = self._cr.precommit.data['import_account_opening_balance']
            // data.setdefault(self.env.company.id, {}).setdefault(self.id, [None, None])
            // index = 0 if field == 'debit' else 1
            // data[self.env.company.id][self.id][index] = amount
            */
            return default;
        }

        protected async Task<AccountAccount> SetOpeningDebitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _set_opening_debit(self):
            // for record in self:
            //     record._set_opening_debit_credit(record.opening_debit, 'debit')
            */
            return default;
        }

        protected async Task<AccountAccount> SplitCodeNameInternalAsync(object code_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _split_code_name(self, code_name):
            // # We only want to split the name on the first word if there is a digit in it
            // code, name = ACCOUNT_REGEX.match(code_name or '').groups()
            // return code, name.strip()
            */
            return default;
        }

        public async Task<AccountAccount> SpreadsheetFetchDebitCreditAsync(Guid id, object args_list)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet_account, FILE: account.py) ---
            // def spreadsheet_fetch_debit_credit(self, args_list):
            // """Fetch data for ODOO.CREDIT, ODOO.DEBIT and ODOO.BALANCE formulas
            // The input list looks like this:
            // [{
            //     date_range: {
            //         range_type: "year"
            //         year: int
            //     },
            //     company_id: int
            //     codes: str[]
            //     include_unposted: bool
            // }]
            // """
            // results = []
            // for args in args_list:
            //     company_id = args["company_id"] or self.env.company.id
            //     domain = self._build_spreadsheet_formula_domain(args)
            //     MoveLines = self.env["account.move.line"].with_company(company_id)
            //     [(debit, credit)] = MoveLines._read_group(domain, aggregates=['debit:sum', 'credit:sum'])
            //     results.append({'debit': debit or 0, 'credit': credit or 0})
            // 
            // return results
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountAccount> SpreadsheetFetchPartnerBalanceAsync(Guid id, object args_list)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet_account, FILE: account.py) ---
            // def spreadsheet_fetch_partner_balance(self, args_list):
            // """Fetch data for ODOO.PARTNER.BALANCE formulas
            // The input list looks like this:
            // [{
            //     date_range: {
            //         range_type: "year"
            //         year: int
            //     },
            //     company_id: int
            //     codes: str[]
            //     include_unposted: bool
            //     partner_ids: int[]
            // }]
            // """
            // results = []
            // for args in args_list:
            //     partner_ids = [partner_id for partner_id in args.get('partner_ids', []) if partner_id]
            //     if not partner_ids:
            //         results.append({'balance': 0})
            //         continue
            // 
            //     company_id = args["company_id"] or self.env.company.id
            //     domain = self._build_spreadsheet_formula_domain(args, default_accounts=True)
            //     MoveLines = self.env["account.move.line"].with_company(company_id)
            //     [(balance,)] = MoveLines._read_group(domain, aggregates=['balance:sum'])
            //     results.append({'balance': balance or 0})
            // 
            // return results
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountAccount> SpreadsheetFetchResidualAmountAsync(Guid id, object args_list)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet_account, FILE: account.py) ---
            // def spreadsheet_fetch_residual_amount(self, args_list):
            // """Fetch data for ODOO.RESUDUAL formulas
            // The input list looks like this:
            // [{
            //     date_range: {
            //         range_type: "year"
            //         year: int
            //     },
            //     company_id: int
            //     codes: str[]
            //     include_unposted: bool
            // }]
            // """
            // results = []
            // for args in args_list:
            //     company_id = args["company_id"] or self.env.company.id
            //     domain = self._build_spreadsheet_formula_domain(args, default_accounts=True)
            //     MoveLines = self.env["account.move.line"].with_company(company_id)
            //     [(amount_residual,)] = MoveLines._read_group(domain, aggregates=['amount_residual:sum'])
            //     results.append({'amount_residual': amount_residual or 0})
            // 
            // return results
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountAccount> SpreadsheetMoveLineActionAsync(Guid id, object args)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet_account, FILE: account.py) ---
            // def spreadsheet_move_line_action(self, args):
            // domain = self._build_spreadsheet_formula_domain(args, default_accounts=True)
            // return {
            //     "type": "ir.actions.act_window",
            //     "res_model": "account.move.line",
            //     "view_mode": "list",
            //     "views": [[False, "list"]],
            //     "target": "current",
            //     "domain": domain,
            //     "name": _("Cell Audit"),
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountAccount> ToggleReconcileToFalseInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _toggle_reconcile_to_false(self):
            // '''Toggle the `reconcile´ boolean from True -> False
            // 
            // Note that it is disallowed if some lines are partially reconciled.
            // '''
            // if not self.ids:
            //     return None
            // partial_lines_count = self.env['account.move.line'].search_count([
            //     ('account_id', 'in', self.ids),
            //     ('full_reconcile_id', '=', False),
            //     ('|'),
            //     ('matched_debit_ids', '!=', False),
            //     ('matched_credit_ids', '!=', False),
            // ])
            // if partial_lines_count > 0:
            //     raise UserError(_('You cannot switch an account to prevent the reconciliation '
            //                       'if some partial reconciliations are still pending.'))
            // 
            // self.env['account.move.line'].invalidate_model(['amount_residual', 'amount_residual_currency'])
            // query = """
            //     UPDATE account_move_line
            //         SET amount_residual = 0, amount_residual_currency = 0
            //     WHERE full_reconcile_id IS NULL AND account_id IN %s
            // """
            // self.env.cr.execute(query, [tuple(self.ids)])
            */
            return default;
        }

        protected async Task<AccountAccount> ToggleReconcileToTrueInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _toggle_reconcile_to_true(self):
            // '''Toggle the `reconcile´ boolean from False -> True
            // 
            // Note that: lines with debit = credit = amount_currency = 0 are set to `reconciled´ = True
            // '''
            // if not self.ids:
            //     return None
            // self.env['account.move.line'].invalidate_model(['amount_residual', 'amount_residual_currency', 'reconciled'])
            // query = """
            //     UPDATE account_move_line SET
            //         reconciled = CASE WHEN debit = 0 AND credit = 0 AND amount_currency = 0
            //             THEN true ELSE false END,
            //         amount_residual = (debit-credit),
            //         amount_residual_currency = amount_currency
            //     WHERE full_reconcile_id IS NULL and account_id IN %s
            // """
            // self.env.cr.execute(query, [tuple(self.ids)])
            */
            return default;
        }

        protected async Task<AccountAccount> UnlinkBankCashAccountsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_dk, FILE: account_account.py) ---
            // def _unlink_bank_cash_accounts(self):
            // nb_account_to_delete_per_company = defaultdict(self.env['account.account'].browse)
            // for account in self:
            //     for company in account.company_ids:
            //         if company.country_code == 'DK':
            //             nb_account_to_delete_per_company[company] |= account
            // 
            // if not nb_account_to_delete_per_company:
            //     return
            // 
            // grouped_counts = self.read_group(
            //     domain=[('company_ids.account_fiscal_country_id.code', '=', 'DK'), ('account_type', '=', 'asset_cash')],
            //     fields=['company_ids', 'id:count'],
            //     groupby=['company_ids'],
            // )
            // nb_account_per_company = {self.env['res.company'].browse(entry['company_ids'][0]): entry['company_ids_count'] for entry in grouped_counts}
            // 
            // for company_id, count in nb_account_per_company.items():
            //     nb_to_delete = sum(1 for account in nb_account_to_delete_per_company.get(company_id) if account.account_type == 'asset_cash')
            //     if count - nb_to_delete < 1:
            //         raise UserError(_("You must keep at least one bank and cash account for %(company)s!", company=company_id.name))
            */
            return default;
        }

        protected async Task<AccountAccount> UnlinkExceptContainsJournalItemsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _unlink_except_contains_journal_items(self):
            // if self.env['account.move.line'].search_count([('account_id', 'in', self.ids)], limit=1):
            //     raise UserError(_('You cannot perform this action on an account that contains journal items.'))
            */
            return default;
        }

        protected async Task<AccountAccount> UnlinkExceptLinkedToFiscalPositionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _unlink_except_linked_to_fiscal_position(self):
            // if self.env['account.fiscal.position.account'].search_count(['|', ('account_src_id', 'in', self.ids), ('account_dest_id', 'in', self.ids)], limit=1):
            //     raise UserError(_('You cannot remove/deactivate the accounts "%s" which are set on the account mapping of a fiscal position.', ', '.join(f"{a.code} - {a.name}" for a in self)))
            */
            return default;
        }

        protected async Task<AccountAccount> UnlinkExceptLinkedToTaxRepartitionLineInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def _unlink_except_linked_to_tax_repartition_line(self):
            // if self.env['account.tax.repartition.line'].search_count([('account_id', 'in', self.ids)], limit=1):
            //     raise UserError(_('You cannot remove/deactivate the accounts "%s" which are set on a tax repartition line.', ', '.join(f"{a.code} - {a.name}" for a in self)))
            */
            return default;
        }

        public async Task<AccountAccount> UnmergeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def action_unmerge(self):
            // """ Split the account `self` into several accounts, one per company.
            // The original account's codes are assigned respectively to the account created in each company.
            // 
            // From an accounting perspective, this does not change anything to the journal items, since their
            // account codes will remain unchanged. """
            // 
            // self._check_action_unmerge_possible()
            // 
            // self._action_unmerge_get_user_confirmation()
            // 
            // # Keep active company
            // for account in self.with_context({'allowed_company_ids': (self.env.company | self.env.user.company_ids).ids}):
            //     account._action_unmerge()
            // 
            // return {'type': 'ir.actions.client', 'tag': 'soft_reload'}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, AccountAccount entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_account.py) ---
            // def write(self, vals):
            // if 'reconcile' in vals:
            //     if vals['reconcile']:
            //         self.filtered(lambda r: not r.reconcile)._toggle_reconcile_to_true()
            //     else:
            //         self.filtered(lambda r: r.reconcile)._toggle_reconcile_to_false()
            // 
            // if vals.get('currency_id'):
            //     for account in self:
            //         if self.env['account.move.line'].search_count([('account_id', '=', account.id), ('currency_id', 'not in', (False, vals['currency_id']))]):
            //             raise UserError(_('You cannot set a currency on this account as it already has some journal entries having a different foreign currency.'))
            // 
            // if vals.get('deprecated') and self.env["account.tax.repartition.line"].search_count([('account_id', 'in', self.ids)], limit=1):
            //     raise UserError(_("You cannot deprecate an account that is used in a tax distribution."))
            // 
            // res = super(AccountAccount, self.with_context(defer_account_code_checks=True, prefetch_fields=any(field in vals for field in ['code', 'account_type']))).write(vals)
            // 
            // if not self.env.context.get('defer_account_code_checks') and {'company_ids', 'code', 'code_mapping_ids'} & vals.keys():
            //     self._ensure_code_is_unique()
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: l10n_de, FILE: account_account.py) ---
            // def write(self, vals):
            // if (
            //     'code' in vals
            //     and self.env.company.account_fiscal_country_id.code == 'DE'
            //     and any(
            //         self.env.company in a.company_ids and a.code != vals['code']
            //         for a in self
            //     )
            // ):
            //     if self.env['account.move.line'].search_count([('account_id', 'in', self.ids)], limit=1):
            //         raise UserError(_("You can not change the code of an account."))
            // return super().write(vals)
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}