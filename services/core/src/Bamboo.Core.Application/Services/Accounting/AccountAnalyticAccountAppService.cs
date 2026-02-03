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
    [Module("Analytic", Category = "Accounting", Depends = new[] { "base", "mail", "uom" })]
    public partial class AccountAnalyticAccountAppService : GenericAppService<AccountAnalyticAccount>, IAccountAnalyticAccountAppService
    {
        private readonly IMailThreadAppService _mailThreadAppService;
        public AccountAnalyticAccountAppService(IRepository<AccountAnalyticAccount, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
            _mailThreadAppService = mailThreadAppService;
        }

        protected async Task<AccountAnalyticAccount> CheckCompanyConsistencyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_account.py) ---
            // def _check_company_consistency(self):
            // for company, accounts in groupby(self, lambda account: account.company_id):
            //     if company and self.env['account.analytic.line'].sudo().search_count([
            //         ('auto_account_id', 'in', [account.id for account in accounts]),
            //         '!', ('company_id', 'child_of', company.id),
            //     ], limit=1):
            //         raise UserError(_("You can't change the company of an analytic account that already has analytic items! It's a recipe for an analytical disaster!"))
            */
            return default;
        }

        protected async Task<AccountAnalyticAccount> ComputeBomCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: analytic_account.py) ---
            // def _compute_bom_count(self):
            // for account in self:
            //     account.bom_count = len(account.bom_ids)
            */
            return default;
        }

        protected async Task<AccountAnalyticAccount> ComputeDebitCreditBalanceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_account.py) ---
            // def _compute_debit_credit_balance(self):
            // def convert(amount, from_currency):
            //     return from_currency._convert(
            //         from_amount=amount,
            //         to_currency=self.env.company.currency_id,
            //         company=self.env.company,
            //         date=fields.Date.today(),
            //     )
            // 
            // domain = [('company_id', 'in', [False] + self.env.companies.ids)]
            // if self.env.context.get('from_date', False):
            //     domain.append(('date', '>=', self.env.context['from_date']))
            // if self.env.context.get('to_date', False):
            //     domain.append(('date', '<=', self.env.context['to_date']))
            // 
            // for plan, accounts in self.grouped('plan_id').items():
            //     if not plan:
            //         accounts.debit = accounts.credit = accounts.balance = 0
            //         continue
            //     credit_groups = self.env['account.analytic.line']._read_group(
            //         domain=domain + [(plan._column_name(), 'in', self.ids), ('amount', '>=', 0.0)],
            //         groupby=[plan._column_name(), 'currency_id'],
            //         aggregates=['amount:sum'],
            //     )
            //     data_credit = defaultdict(float)
            //     for account, currency, amount_sum in credit_groups:
            //         data_credit[account.id] += convert(amount_sum, currency)
            // 
            //     debit_groups = self.env['account.analytic.line']._read_group(
            //         domain=domain + [(plan._column_name(), 'in', self.ids), ('amount', '<', 0.0)],
            //         groupby=[plan._column_name(), 'currency_id'],
            //         aggregates=['amount:sum'],
            //     )
            //     data_debit = defaultdict(float)
            //     for account, currency, amount_sum in debit_groups:
            //         data_debit[account.id] += convert(amount_sum, currency)
            // 
            //     for account in accounts:
            //         account.debit = -data_debit.get(account.id, 0.0)
            //         account.credit = data_credit.get(account.id, 0.0)
            //         account.balance = account.credit - account.debit
            */
            return default;
        }

        protected async Task<AccountAnalyticAccount> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_account.py) ---
            // def _compute_display_name(self):
            // for analytic in self:
            //     name = analytic.name
            //     if analytic.code:
            //         name = f'[{analytic.code}] {name}'
            //     if analytic.partner_id.commercial_partner_id.name:
            //         name = f'{name} - {analytic.partner_id.commercial_partner_id.name}'
            //     analytic.display_name = name
            */
            return default;
        }

        protected async Task<AccountAnalyticAccount> ComputeInvoiceCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_analytic_account.py) ---
            // def _compute_invoice_count(self):
            // sale_types = self.env['account.move'].get_sale_types(include_receipts=True)
            // data = self.env['account.move.line']._read_group(
            //     [
            //         ('parent_state', '=', 'posted'),
            //         ('move_id.move_type', 'in', sale_types),
            //         ('analytic_distribution', 'in', self.ids),
            //     ],
            //     ['analytic_distribution'],
            //     ['__count'],
            // )
            // data = {int(account_id): move_count for account_id, move_count in data}
            // for account in self:
            //     account.invoice_count = data.get(account.id, 0)
            */
            return default;
        }

        protected async Task<AccountAnalyticAccount> ComputeProductionCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: analytic_account.py) ---
            // def _compute_production_count(self):
            // for account in self:
            //     account.production_count = len(account.production_ids)
            */
            return default;
        }

        protected async Task<AccountAnalyticAccount> ComputeProjectCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: account_analytic_account.py) ---
            // def _compute_project_count(self):
            // project_data = self.env['project.project']._read_group([('account_id', 'in', self.ids)], ['account_id'], ['__count'])
            // mapping = {analytic_account.id: count for analytic_account, count in project_data}
            // for account in self:
            //     account.project_count = mapping.get(account.id, 0)
            */
            return default;
        }

        protected async Task<AccountAnalyticAccount> ComputePurchaseOrderCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: analytic_account.py) ---
            // def _compute_purchase_order_count(self):
            // for account in self:
            //     account.purchase_order_count = self.env['purchase.order'].search_count([
            //         ('order_line.invoice_lines.analytic_line_ids.account_id', 'in', account.ids)
            //     ])
            */
            return default;
        }

        protected async Task<AccountAnalyticAccount> ComputeVendorBillCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_analytic_account.py) ---
            // def _compute_vendor_bill_count(self):
            // purchase_types = self.env['account.move'].get_purchase_types(include_receipts=True)
            // data = self.env['account.move.line']._read_group(
            //     [
            //         ('parent_state', '=', 'posted'),
            //         ('move_id.move_type', 'in', purchase_types),
            //         ('analytic_distribution', 'in', self.ids),
            //     ],
            //     ['analytic_distribution'],
            //     ['__count'],
            // )
            // data = {int(account_id): move_count for account_id, move_count in data}
            // for account in self:
            //     account.vendor_bill_count = data.get(account.id, 0)
            */
            return default;
        }

        protected async Task<AccountAnalyticAccount> ComputeWorkorderCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: analytic_account.py) ---
            // def _compute_workorder_count(self):
            // for account in self:
            //     account.workorder_count = len(account.workcenter_ids.order_ids | account.production_ids.workorder_ids)
            */
            return default;
        }

        public async Task<AccountAnalyticAccount> CopyDataAsync(AccountAnalyticAccountCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_account.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // if 'name' not in default:
            //     for account, vals in zip(self, vals_list):
            //         vals['name'] = _("%s (copy)", account.name)
            // return vals_list
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<AccountAnalyticAccount> PerformAnalyticDistributionInternalAsync(object distribution, object amount, object unit_amount, object lines, object obj, object additive)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: analytic_account.py) ---
            // def _perform_analytic_distribution(self, distribution, amount, unit_amount, lines, obj, additive=False):
            // """
            // Redistributes the analytic lines to match the given distribution:
            //     - For account_ids where lines already exist, the amount and unit_amount of these lines get updated,
            //       lines where the updated amount becomes zero get unlinked.
            //     - For account_ids where lines don't exist yet, the line values to create them are returned,
            //       lines where the amount becomes zero are not included.
            // 
            // :param distribution:    the desired distribution to match the analytic lines to
            // :param amount:          the total amount to distribute over the analytic lines
            // :param unit_amount:     the total unit amount (will not be distributed)
            // :param lines:           the (current) analytic account lines that need to be matched to the new distribution
            // :param obj:             the object on which _prepare_analytic_line_values(account_id, amount, unit_amount) will be
            //                         called to get the template for the values of new analytic line objects
            // :param additive:        if True, the unit_amount and (distributed) amount get added to the existing lines
            // 
            // :returns: a list of dicts containing the values for new analytic lines that need to be created
            // :rtype:   dict
            // """
            // if not distribution:
            //     lines.unlink()
            //     return []
            // 
            // # Does this: {'15': 40, '14,16': 60} -> { account(15): 40, account(14,16): 60 }
            // distribution = {
            //     self.env['account.analytic.account'].browse(map(int, ids.split(','))).exists(): percentage
            //     for ids, percentage in distribution.items()
            // }
            // 
            // plans = self.env['account.analytic.plan']
            // plans = sum(plans._get_all_plans(), plans)
            // line_columns = [p._column_name() for p in plans]
            // 
            // lines_to_link = []
            // distribution_on_each_plan = {}
            // total_percentages = {}
            // 
            // for accounts, percentage in distribution.items():
            //     for plan in accounts.root_plan_id:
            //         total_percentages[plan] = total_percentages.get(plan, 0) + percentage
            // 
            // for existing_aal in lines:
            //     # TODO: recommend something better for this line in review, please
            //     accounts = sum(map(existing_aal.mapped, line_columns), self.env['account.analytic.account'])
            //     if accounts in distribution:
            //         # Update the existing AAL for this account
            //         percentage = distribution[accounts]
            //         new_amount = 0
            //         new_unit_amount = unit_amount
            //         for account in accounts:
            //             plan = account.root_plan_id
            //             new_amount = plan._calculate_distribution_amount(amount, percentage, total_percentages[plan], distribution_on_each_plan)
            //         if additive:
            //             new_amount += existing_aal.amount
            //             new_unit_amount += existing_aal.unit_amount
            //         currency = accounts[0].currency_id or obj.company_id.currency_id
            //         if float_is_zero(new_amount, precision_rounding=currency.rounding):
            //             existing_aal.unlink()
            //         else:
            //             existing_aal.amount = new_amount
            //             existing_aal.unit_amount = new_unit_amount
            //         # Prevent this distribution from being applied again
            //         del distribution[accounts]
            //     else:
            //         # Delete the existing AAL if it is no longer present in the new distribution
            //         existing_aal.unlink()
            // # Create new lines from remaining distributions
            // for accounts, percentage in distribution.items():
            //     if not accounts:
            //         continue
            //     account_field_values = {}
            //     for account in accounts:
            //         new_amount = account.root_plan_id._calculate_distribution_amount(amount, percentage, total_percentages[plan], distribution_on_each_plan)
            //         account_field_values[account.plan_id._column_name()] = account.id
            //     currency = account.currency_id or obj.company_id.currency_id
            //     if not float_is_zero(new_amount, precision_rounding=currency.rounding):
            //         lines_to_link.append(obj._prepare_analytic_line_values(account_field_values, new_amount, unit_amount))
            // return lines_to_link
            */
            return default;
        }

        protected async Task<AccountAnalyticAccount> ReadGroupPostprocessAggregateInternalAsync(object aggregate_spec, object raw_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_account.py) ---
            // def _read_group_postprocess_aggregate(self, aggregate_spec, raw_values):
            // if aggregate_spec in (
            //     'balance:sum',
            //     'balance:sum_currency',
            //     'debit:sum',
            //     'debit:sum_currency',
            //     'credit:sum',
            //     'credit:sum_currency',
            // ):
            //     field_name, op = aggregate_spec.split(':')
            //     column = super()._read_group_postprocess_aggregate('id:recordset', raw_values)
            //     if op == 'sum':
            //         return (sum(records.mapped(field_name)) for records in column)
            //     if op == 'sum_currency':
            //         return (sum(record.currency_id._convert(
            //             from_amount=record[field_name],
            //             to_currency=self.env.company.currency_id,
            //         ) for record in records) for records in column)
            // return super()._read_group_postprocess_aggregate(aggregate_spec, raw_values)
            */
            return default;
        }

        protected async Task<AccountAnalyticAccount> ReadGroupSelectInternalAsync(object aggregate_spec, object query)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_account.py) ---
            // def _read_group_select(self, aggregate_spec, query):
            // # flag balance/debit/credit as aggregatable, and manually sum the values
            // # from the records in the group
            // if aggregate_spec in (
            //     'balance:sum',
            //     'balance:sum_currency',
            //     'debit:sum',
            //     'debit:sum_currency',
            //     'credit:sum',
            //     'credit:sum_currency',
            // ):
            //     return super()._read_group_select('id:recordset', query)
            // return super()._read_group_select(aggregate_spec, query)
            */
            return default;
        }

        protected async Task<AccountAnalyticAccount> UnlinkExceptAccountInAnalyticDistributionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: analytic.py) ---
            // def _unlink_except_account_in_analytic_distribution(self):
            // self.env.cr.execute(
            //     SQL(
            //         r"""
            //         SELECT id FROM hr_expense
            //             WHERE %s && %s
            //         LIMIT 1
            //         """,
            //         [str(account_id) for account_id in self.ids],
            //         self.env['hr.expense']._query_analytic_accounts(),
            //     )
            // )
            // expense_ids = self.env.cr.fetchall()
            // if expense_ids:
            //     raise UserError(_("You cannot delete an analytic account that is used in an expense."))
            */
            return default;
        }

        protected async Task<AccountAnalyticAccount> UnlinkExceptExistingTasksInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: account_analytic_account.py) ---
            // def _unlink_except_existing_tasks(self):
            // has_tasks = self.env['project.task'].search_count(
            //     [('project_id.account_id', 'in', self.ids)],
            //     limit=1,
            // )
            // if has_tasks:
            //     raise UserError(_("Before we can bid farewell to these accounts, you need to tidy up the projects linked to them by removing their existing tasks!"))
            */
            return default;
        }

        protected async Task<AccountAnalyticAccount> UpdateAccountsInAnalyticLinesInternalAsync(object new_fname, object current_fname, object accounts)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_account.py) ---
            // def _update_accounts_in_analytic_lines(self, new_fname, current_fname, accounts):
            // if current_fname != new_fname:
            //     domain = [
            //         (new_fname, 'not in', accounts.ids + [False]),
            //         (current_fname, 'in', accounts.ids),
            //     ]
            //     if self.env['account.analytic.line'].sudo().search_count(domain, limit=1):
            //         list_view = self.env.ref('analytic.view_account_analytic_line_tree', raise_if_not_found=False)
            //         raise RedirectWarning(
            //             message=_("Whoa there! Making this change would wipe out your current data. Let's avoid that, shall we?"),
            //             action={
            //                 'res_model': 'account.analytic.line',
            //                 'type': 'ir.actions.act_window',
            //                 'domain': domain,
            //                 'target': 'new',
            //                 'views': [(list_view and list_view.id, 'list')]
            //             },
            //             button_text=_("See them"),
            //         )
            //     self.env.cr.execute(SQL(
            //         """
            //         UPDATE account_analytic_line
            //            SET %(new_fname)s = %(current_fname)s,
            //                %(current_fname)s = NULL
            //          WHERE %(current_fname)s = ANY(%(account_ids)s)
            //         """,
            //         new_fname=SQL.identifier(new_fname),
            //         current_fname=SQL.identifier(current_fname),
            //         account_ids=accounts.ids,
            //     ))
            //     self.env['account.analytic.line'].invalidate_model()
            */
            return default;
        }

        public async Task<AccountAnalyticAccount> ViewInvoiceAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_analytic_account.py) ---
            // def action_view_invoice(self):
            // self.ensure_one()
            // account_move_lines = self.env['account.move.line'].search_fetch([
            //     ('move_id.move_type', 'in', self.env['account.move'].get_sale_types()),
            //     ('analytic_distribution', 'in', self.ids),
            // ], ['move_id'])
            // return {
            //     "type": "ir.actions.act_window",
            //     "res_model": "account.move",
            //     "domain": [('id', 'in', account_move_lines.move_id.ids)],
            //     "context": {"create": False, 'default_move_type': 'out_invoice'},
            //     "name": _("Customer Invoices"),
            //     'view_mode': 'list,form',
            // }
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAnalyticAccount> ViewMrpBomAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: analytic_account.py) ---
            // def action_view_mrp_bom(self):
            // self.ensure_one()
            // result = {
            //     "type": "ir.actions.act_window",
            //     "res_model": "mrp.bom",
            //     "domain": [['id', 'in', self.bom_ids.ids]],
            //     "name": _("Bills of Materials"),
            //     'view_mode': 'list,form',
            //     "context": {'default_analytic_account_id': self.id},
            // }
            // if self.bom_count == 1:
            //     result['view_mode'] = 'form'
            //     result['res_id'] = self.bom_ids.id
            // return result
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAnalyticAccount> ViewMrpProductionAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: analytic_account.py) ---
            // def action_view_mrp_production(self):
            // self.ensure_one()
            // result = {
            //     "type": "ir.actions.act_window",
            //     "res_model": "mrp.production",
            //     "domain": [['id', 'in', self.production_ids.ids]],
            //     "name": _("Manufacturing Orders"),
            //     'view_mode': 'list,form',
            //     "context": {'default_analytic_account_id': self.id},
            // }
            // if len(self.production_ids) == 1:
            //     result['view_mode'] = 'form'
            //     result['res_id'] = self.production_ids.id
            // return result
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAnalyticAccount> ViewProjectsAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: account_analytic_account.py) ---
            // def action_view_projects(self):
            // kanban_view_id = self.env.ref('project.view_project_kanban').id
            // result = {
            //     "type": "ir.actions.act_window",
            //     "res_model": "project.project",
            //     "views": [[kanban_view_id, "kanban"], [False, "form"]],
            //     "domain": [['account_id', '=', self.id]],
            //     "context": {"create": False},
            //     "name": _("Projects"),
            // }
            // if len(self.project_ids) == 1:
            //     result['views'] = [(False, "form")]
            //     result['res_id'] = self.project_ids.id
            // return result
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAnalyticAccount> ViewPurchaseOrdersAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: analytic_account.py) ---
            // def action_view_purchase_orders(self):
            // self.ensure_one()
            // purchase_orders = self.env['purchase.order'].search([
            //     ('order_line.invoice_lines.analytic_line_ids.account_id', '=', self.id)
            // ])
            // result = {
            //     "type": "ir.actions.act_window",
            //     "res_model": "purchase.order",
            //     "domain": [['id', 'in', purchase_orders.ids]],
            //     "name": _("Purchase Orders"),
            //     'view_mode': 'list,form',
            // }
            // if len(purchase_orders) == 1:
            //     result['view_mode'] = 'form'
            //     result['res_id'] = purchase_orders.id
            // return result
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAnalyticAccount> ViewVendorBillAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_analytic_account.py) ---
            // def action_view_vendor_bill(self):
            // self.ensure_one()
            // account_move_lines = self.env['account.move.line'].search_fetch([
            //     ('move_id.move_type', 'in', self.env['account.move'].get_purchase_types(include_receipts=True)),
            //     ('analytic_distribution', 'in', self.ids),
            // ], ['move_id'])
            // return {
            //     "type": "ir.actions.act_window",
            //     "res_model": "account.move",
            //     "domain": [('id', 'in', account_move_lines.move_id.ids)],
            //     "context": {"create": False, 'default_move_type': 'in_invoice'},
            //     "name": _("Vendor Bills"),
            //     'view_mode': 'list,form',
            // }
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountAnalyticAccount> ViewWorkorderAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: analytic_account.py) ---
            // def action_view_workorder(self):
            // self.ensure_one()
            // result = {
            //     "type": "ir.actions.act_window",
            //     "res_model": "mrp.workorder",
            //     "domain": [['id', 'in', (self.workcenter_ids.order_ids | self.production_ids.workorder_ids).ids]],
            //     "context": {"create": False},
            //     "name": _("Work Orders"),
            //     'view_mode': 'list',
            // }
            // return result
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<List<Dictionary<string, object>>> WebReadAsync(AccountAnalyticAccountWebReadRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_account.py) ---
            // def web_read(self, specification: dict[str, dict]) -> list[dict]:
            // self_context = self
            // if len(self) == 1:
            //     self_context = self.with_context(analytic_plan_id=self.plan_id.id)
            // return super(AccountAnalyticAccount, self_context).web_read(specification)
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}