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

namespace Bamboo.Core.Application.Services
{
    [Module("OmAccountBudget", Depends = new[] { "account" })]
    public class CrossoveredBudgetLinesAppService : GenericApplicationService<CrossoveredBudgetLines>, ICrossoveredBudgetLinesAppService
    {

        public CrossoveredBudgetLinesAppService(IRepository<CrossoveredBudgetLines, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<CrossoveredBudgetLines> ComputeLineNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py) ---
            // def _compute_line_name(self):
            // #just in case someone opens the budget line in form view
            // for line in self:
            //     computed_name = line.crossovered_budget_id.name
            //     if line.general_budget_id:
            //         computed_name += ' - ' + line.general_budget_id.name
            //     if line.analytic_account_id:
            //         computed_name += ' - ' + line.analytic_account_id.name
            //     line.name = computed_name
            */
            return default;
        }

        protected async Task<CrossoveredBudgetLines> ComputePercentageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py) ---
            // def _compute_percentage(self):
            // for line in self:
            //     if line.theoritical_amount != 0.00:
            //         line.percentage = float((line.practical_amount or 0.0) / line.theoritical_amount)
            //     else:
            //         line.percentage = 0.00
            */
            return default;
        }

        protected async Task<CrossoveredBudgetLines> ComputePracticalAmountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py) ---
            // def _compute_practical_amount(self):
            // for line in self:
            //     acc_ids = line.general_budget_id.account_ids.ids
            //     date_to = line.date_to
            //     date_from = line.date_from
            //     if line.analytic_account_id.id:
            //         analytic_line_obj = self.env['account.analytic.line']
            //         domain = [('account_id', '=', line.analytic_account_id.id),
            //                   ('date', '>=', date_from),
            //                   ('date', '<=', date_to),
            //                   ]
            //         if acc_ids:
            //             domain += [('general_account_id', 'in', acc_ids)]
            // 
            //         where_query = analytic_line_obj._where_calc(domain)
            //         analytic_line_obj._apply_ir_rules(where_query, 'read')
            //         from_string, from_params = where_query.from_clause
            //         where_string, where_params = where_query.where_clause
            //         from_clause, where_clause, where_clause_params = from_string, where_string, from_params + where_params
            // 
            //         select = "SELECT SUM(amount) from " + from_clause + " where " + where_clause
            // 
            //     else:
            //         aml_obj = self.env['account.move.line']
            //         domain = [('account_id', 'in',
            //                    line.general_budget_id.account_ids.ids),
            //                   ('date', '>=', date_from),
            //                   ('date', '<=', date_to)
            //                   ]
            //         where_query = aml_obj._where_calc(domain)
            //         aml_obj._apply_ir_rules(where_query, 'read')
            //         from_string, from_params = where_query.from_clause
            //         where_string, where_params = where_query.where_clause
            //         from_clause, where_clause, where_clause_params = from_string, where_string, from_params + where_params
            // 
            //         select = "SELECT sum(credit)-sum(debit) from " + from_clause + " where " + where_clause
            // 
            //     self.env.cr.execute(select, where_clause_params)
            //     line.practical_amount = self.env.cr.fetchone()[0] or 0.0
            */
            return default;
        }

        protected async Task<CrossoveredBudgetLines> ComputeTheoriticalAmountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py) ---
            // def _compute_theoritical_amount(self):
            // # beware: 'today' variable is mocked in the python tests and thus, its implementation matter
            // today = fields.Date.today()
            // for line in self:
            //     if line.paid_date:
            //         if today <= line.paid_date:
            //             theo_amt = 0.00
            //         else:
            //             theo_amt = line.planned_amount
            //     else:
            //         line_timedelta = line.date_to - line.date_from
            //         elapsed_timedelta = today - line.date_from
            // 
            //         if elapsed_timedelta.days < 0:
            //             # If the budget line has not started yet, theoretical amount should be zero
            //             theo_amt = 0.00
            //         elif line_timedelta.days > 0 and today < line.date_to:
            //             # If today is between the budget line date_from and date_to
            //             theo_amt = (elapsed_timedelta.total_seconds() / line_timedelta.total_seconds()) * line.planned_amount
            //         else:
            //             theo_amt = line.planned_amount
            //     line.theoritical_amount = theo_amt
            */
            return default;
        }

        protected async Task<CrossoveredBudgetLines> IsAboveBudgetInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py) ---
            // def _is_above_budget(self):
            // for line in self:
            //     if line.theoritical_amount >= 0:
            //         line.is_above_budget = line.practical_amount > line.theoritical_amount
            //     else:
            //         line.is_above_budget = line.practical_amount < line.theoritical_amount
            */
            return default;
        }

        protected async Task<CrossoveredBudgetLines> LineDatesBetweenBudgetDatesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py) ---
            // def _line_dates_between_budget_dates(self):
            // for rec in self:
            //     budget_date_from = rec.crossovered_budget_id.date_from
            //     budget_date_to = rec.crossovered_budget_id.date_to
            //     if rec.date_from:
            //         date_from = rec.date_from
            //         if date_from < budget_date_from or date_from > budget_date_to:
            //             raise ValidationError(_('"Start Date" of the budget line should be included in the Period of the budget'))
            //     if rec.date_to:
            //         date_to = rec.date_to
            //         if date_to < budget_date_from or date_to > budget_date_to:
            //             raise ValidationError(_('"End Date" of the budget line should be included in the Period of the budget'))
            */
            return default;
        }

        protected async Task<CrossoveredBudgetLines> MustHaveAnalyticalOrBudgetaryOrBothInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py) ---
            // def _must_have_analytical_or_budgetary_or_both(self):
            // if not self.analytic_account_id and not self.general_budget_id:
            //     raise ValidationError(
            //         _("You have to enter at least a budgetary position or analytic account on a budget line."))
            */
            return default;
        }

        public async Task<CrossoveredBudgetLines> OpenBudgetEntriesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py) ---
            // def action_open_budget_entries(self):
            // if self.analytic_account_id:
            //     # if there is an analytic account, then the analytic items are loaded
            //     action = self.env['ir.actions.act_window']._for_xml_id('analytic.account_analytic_line_action_entries')
            //     action['domain'] = [('account_id', '=', self.analytic_account_id.id),
            //                         ('date', '>=', self.date_from),
            //                         ('date', '<=', self.date_to)
            //                         ]
            //     if self.general_budget_id:
            //         action['domain'] += [('general_account_id', 'in', self.general_budget_id.account_ids.ids)]
            // else:
            //     # otherwise the journal entries booked on the accounts of the budgetary postition are opened
            //     action = self.env['ir.actions.act_window']._for_xml_id('account.action_account_moves_all_a')
            //     action['domain'] = [('account_id', 'in',
            //                          self.general_budget_id.account_ids.ids),
            //                         ('date', '>=', self.date_from),
            //                         ('date', '<=', self.date_to)
            //                         ]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}