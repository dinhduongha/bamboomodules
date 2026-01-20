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
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Account", Category = "Accounting", Depends = new[] { "base_setup", "onboarding", "product", "analytic", "portal", "digest" })]
    public partial class AccountBankStatementAppService : GenericApplicationService<AccountBankStatement>, IAccountBankStatementAppService
    {

        public AccountBankStatementAppService(IRepository<AccountBankStatement, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        protected async Task<AccountBankStatement> CheckAttachmentsInternalAsync(object container, object values_list)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_bank_statement.py) ---
            // def _check_attachments(self, container, values_list):
            // attachments_to_fix_list = []
            // for values in values_list:
            //     attachment_ids = set()
            //     for orm_command in values.get('attachment_ids', []):
            //         if orm_command[0] == Command.LINK:
            //             attachment_ids.add(orm_command[1])
            //         elif orm_command[0] == Command.SET:
            //             for attachment_id in orm_command[2]:
            //                 attachment_ids.add(attachment_id)
            // 
            //     attachments = self.env['ir.attachment'].browse(list(attachment_ids))
            //     attachments_to_fix_list.append(attachments)
            // 
            // yield
            // 
            // for stmt, attachments in zip(container['records'], attachments_to_fix_list):
            //     attachments.write({'res_id': stmt.id, 'res_model': stmt._name})
            */
            return default;
        }

        protected async Task<AccountBankStatement> ComputeBalanceEndInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_bank_statement.py) ---
            // def _compute_balance_end(self):
            // for stmt in self:
            //     lines = stmt.line_ids.filtered(lambda x: x.state == 'posted')
            //     stmt.balance_end = stmt.balance_start + sum(lines.mapped('amount'))
            */
            return default;
        }

        protected async Task<AccountBankStatement> ComputeBalanceEndRealInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_bank_statement.py) ---
            // def _compute_balance_end_real(self):
            // for stmt in self:
            //     stmt.balance_end_real = stmt.balance_end
            */
            return default;
        }

        protected async Task<AccountBankStatement> ComputeBalanceStartInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_bank_statement.py) ---
            // def _compute_balance_start(self):
            // for stmt in self.sorted(lambda x: x.first_line_index or '0'):
            //     journal_id = stmt.journal_id.id or stmt.line_ids.journal_id.id
            //     previous_line_with_statement = self.env['account.bank.statement.line'].search([
            //         ('internal_index', '<', stmt.first_line_index),
            //         ('journal_id', '=', journal_id),
            //         ('state', '=', 'posted'),
            //         ('statement_id', '!=', False),
            //     ], limit=1)
            //     balance_start = previous_line_with_statement.statement_id.balance_end_real
            // 
            //     lines_in_between_domain = [
            //         ('internal_index', '<', stmt.first_line_index),
            //         ('journal_id', '=', journal_id),
            //         ('state', '=', 'posted'),
            //     ]
            //     if previous_line_with_statement:
            //         lines_in_between_domain.append(('internal_index', '>', previous_line_with_statement.internal_index))
            //         # remove lines from previous statement (when multi-editing a line already in another statement)
            //         previous_st_lines = previous_line_with_statement.statement_id.line_ids
            //         lines_in_common = previous_st_lines.filtered(lambda l: l.id in stmt.line_ids._origin.ids)
            //         balance_start -= sum(lines_in_common.mapped('amount'))
            // 
            //     lines_in_between = self.env['account.bank.statement.line'].search(lines_in_between_domain)
            //     balance_start += sum(lines_in_between.mapped('amount'))
            // 
            //     stmt.balance_start = balance_start
            */
            return default;
        }

        protected async Task<AccountBankStatement> ComputeCurrencyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_bank_statement.py) ---
            // def _compute_currency_id(self):
            // for statement in self:
            //     statement.currency_id = statement.journal_id.currency_id or statement.company_id.currency_id
            */
            return default;
        }

        protected async Task<AccountBankStatement> ComputeDateIndexInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_bank_statement.py) ---
            // def _compute_date_index(self):
            // for stmt in self:
            //     # When we create lines manually from the form view, they don't have any `internal_index` set yet.
            //     sorted_lines = stmt.line_ids.filtered("internal_index").sorted('internal_index')
            //     stmt.first_line_index = sorted_lines[:1].internal_index
            //     stmt.date = sorted_lines.filtered(lambda l: l.state == 'posted')[-1:].date
            */
            return default;
        }

        protected async Task<AccountBankStatement> ComputeIsCompleteInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_bank_statement.py) ---
            // def _compute_is_complete(self):
            // for stmt in self:
            //     stmt.is_complete = stmt.line_ids.filtered(lambda l: l.state == 'posted') and stmt.currency_id.compare_amounts(
            //         stmt.balance_end, stmt.balance_end_real) == 0
            */
            return default;
        }

        protected async Task<AccountBankStatement> ComputeIsValidInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_bank_statement.py) ---
            // def _compute_is_valid(self):
            // # we extract the invalid statements, the statements with no lines and the first statement are not in the query
            // # because they don't have a previous statement, so they are excluded from the join, and we consider them valid.
            // # if we have extracted the valid ones, we would have to mark above-mentioned statements valid manually
            // # For new statements, a sql query can't be used
            // if len(self) == 1:
            //     self.is_valid = self._get_statement_validity()
            // else:
            //     invalids = self.filtered(lambda s: s.id in self._get_invalid_statement_ids())
            //     invalids.is_valid = False
            //     (self - invalids).is_valid = True
            */
            return default;
        }

        protected async Task<AccountBankStatement> ComputeJournalIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_bank_statement.py) ---
            // def _compute_journal_id(self):
            // for statement in self:
            //     statement.journal_id = statement.line_ids.journal_id
            */
            return default;
        }

        protected async Task<AccountBankStatement> ComputeNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_bank_statement.py) ---
            // def _compute_name(self):
            // for stmt in self:
            //     name = ''
            //     if stmt.journal_id:
            //         name = stmt.journal_id.code + ' '
            //     stmt.name = name +_("Statement %(date)s", date=stmt.date or fields.Date.to_date(stmt.create_date))
            */
            return default;
        }

        protected async Task<AccountBankStatement> ComputeProblemDescriptionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_bank_statement.py) ---
            // def _compute_problem_description(self):
            // for stmt in self:
            //     description = None
            //     if not stmt.is_valid:
            //         description = _("The starting balance doesn't match the ending balance of the previous statement, or an earlier statement is missing.")
            //     elif not stmt.is_complete:
            //         description = _("The running balance (%s) doesn't match the specified ending balance.", formatLang(self.env, stmt.balance_end, currency_obj=stmt.currency_id))
            //     stmt.problem_description = description
            */
            return default;
        }

        protected async Task<AccountBankStatement> GetInvalidStatementIdsInternalAsync(object all_statements)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_bank_statement.py) ---
            // def _get_invalid_statement_ids(self, all_statements=None):
            // """ Returns the statements that are invalid for _compute and _search methods."""
            // 
            // self.env['account.bank.statement.line'].flush_model(['statement_id', 'internal_index'])
            // self.env['account.bank.statement'].flush_model(['balance_start', 'balance_end_real', 'first_line_index'])
            // 
            // self.env.cr.execute(f"""
            //     SELECT st.id
            //       FROM account_bank_statement st
            //  LEFT JOIN res_company co ON st.company_id = co.id
            //  LEFT JOIN account_journal j ON st.journal_id = j.id
            //  LEFT JOIN res_currency currency ON COALESCE(j.currency_id, co.currency_id) = currency.id,
            //            LATERAL (
            //                SELECT balance_end_real
            //                  FROM account_bank_statement st_lookup
            //                 WHERE st_lookup.first_line_index < st.first_line_index
            //                   AND st_lookup.journal_id = st.journal_id
            //              ORDER BY st_lookup.first_line_index desc
            //                 LIMIT 1
            //            ) prev
            //      WHERE ROUND(prev.balance_end_real, currency.decimal_places) != ROUND(st.balance_start, currency.decimal_places)
            //        {"" if all_statements else "AND st.id IN %(ids)s"}
            // """, {
            //     'ids': tuple(self.ids)
            // })
            // res = self.env.cr.fetchall()
            // return [r[0] for r in res]
            */
            return default;
        }

        protected async Task<AccountBankStatement> GetStatementValidityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_bank_statement.py) ---
            // def _get_statement_validity(self):
            // """ Compares the balance_start to the previous statements balance_end_real """
            // self.ensure_one()
            // previous = self.env['account.bank.statement'].search(
            //     [
            //         ('first_line_index', '<', self.first_line_index),
            //         ('journal_id', '=', self.journal_id.id),
            //     ],
            //     limit=1,
            //     order='first_line_index DESC',
            // )
            // return not previous or self.currency_id.compare_amounts(self.balance_start, previous.balance_end_real) == 0
            */
            return default;
        }

        public async Task<AccountBankStatement> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_bank_statement.py) ---
            // def init(self):
            // super().init()
            // create_index(self.env.cr,
            //              indexname='account_bank_statement_journal_id_date_desc_id_desc_idx',
            //              tablename='account_bank_statement',
            //              expressions=['journal_id', 'date DESC', 'id DESC'])
            // create_index(
            //     self.env.cr,
            //     indexname='account_bank_statement_first_line_index_idx',
            //     tablename='account_bank_statement',
            //     expressions=['journal_id', 'first_line_index'],
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountBankStatement> SearchIsValidInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_bank_statement.py) ---
            // def _search_is_valid(self, operator, value):
            // if operator not in ('=', '!=', '<>'):
            //     raise UserError(_('Operation not supported'))
            // invalid_ids = self._get_invalid_statement_ids(all_statements=True)
            // if operator in ('!=', '<>') and value or operator == '=' and not value:
            //     return [('id', 'in', invalid_ids)]
            // return [('id', 'not in', invalid_ids)]
            */
            return default;
        }
    }
}