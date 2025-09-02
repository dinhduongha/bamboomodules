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
    [Module("Analytic", Depends = new[] { "base", "mail", "uom" })]
    public class AccountAnalyticPlanAppService : GenericApplicationService<AccountAnalyticPlan>, IAccountAnalyticPlanAppService
    {

        public AccountAnalyticPlanAppService(IRepository<AccountAnalyticPlan, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<AccountAnalyticPlan> AutoInitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py) ---
            // def _auto_init(self):
            // super()._auto_init()
            // def precommit():
            //     self.env['ir.default'].set(
            //         self._name,
            //         'default_applicability',
            //         'optional',
            //     )
            // self.env.cr.precommit.add(precommit)
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> CalculateDistributionAmountInternalAsync(object amount, object percentage, object total_percentage, object distribution_on_each_plan)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: analytic_account.py) ---
            // def _calculate_distribution_amount(self, amount, percentage, total_percentage, distribution_on_each_plan):
            // """
            // Ensures that the total amount distributed across all lines always adds up to exactly `amount` per
            // plan. We try to correct for compounding rounding errors by assigning the exact outstanding amount when
            // we detect that a line will close out a plan's total percentage. However, since multiple plans can be
            // assigned to a line, with different prior distributions, there is the possible edge case that one line
            // closes out two (or more) tallies with different compounding errors. This means there is no one correct
            // amount that we can assign to a line that will correctly close out both all plans. This is described in
            // more detail in the commit message, under "concurrent closing line edge case".
            // """
            // decimal_precision = self.env['decimal.precision'].precision_get('Percentage Analytic')
            // distributed_percentage, distributed_amount = distribution_on_each_plan.get(self, (0, 0))
            // allocated_percentage = distributed_percentage + percentage
            // if float_compare(allocated_percentage, total_percentage, precision_digits=decimal_precision) == 0:
            //     calculated_amount = (amount * total_percentage / 100) - distributed_amount
            // else:
            //     calculated_amount = amount * percentage / 100
            // distributed_amount += float_round(calculated_amount, precision_digits=decimal_precision)
            // distribution_on_each_plan[self] = (allocated_percentage, distributed_amount)
            // return calculated_amount
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> ColumnNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py) ---
            // def _column_name(self):
            // return self.root_id._strict_column_name()
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> ComputeAllAnalyticAccountCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py) ---
            // def _compute_all_analytic_account_count(self):
            // # Get all children_ids from each plan
            // self.env.cr.execute("""
            //     SELECT parent.id,
            //            array_agg(child.id) as children_ids
            //       FROM account_analytic_plan parent
            //       JOIN account_analytic_plan child ON child.parent_path LIKE parent.parent_path || '%%'
            //      WHERE parent.id IN %s
            //   GROUP BY parent.id
            // """, [tuple(self.ids)])
            // all_children_ids = dict(self.env.cr.fetchall())
            // 
            // plans_count = dict(
            //     self.env['account.analytic.account']._read_group(
            //         domain=[('plan_id', 'child_of', self.ids)],
            //         aggregates=['id:count'],
            //         groupby=['plan_id']
            //     )
            // )
            // plans_count = {k.id: v for k, v in plans_count.items()}
            // for plan in self:
            //     plan.all_account_count = sum(plans_count.get(child_id, 0) for child_id in all_children_ids.get(plan.id, []))
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> ComputeAnalyticAccountCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py) ---
            // def _compute_analytic_account_count(self):
            // for plan in self:
            //     plan.account_count = len(plan.account_ids)
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> ComputeChildrenCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py) ---
            // def _compute_children_count(self):
            // for plan in self:
            //     plan.children_count = len(plan.children_ids)
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> ComputeCompleteNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py) ---
            // def _compute_complete_name(self):
            // for plan in self:
            //     if plan.parent_id:
            //         plan.complete_name = '%s / %s' % (plan.parent_id.complete_name, plan.name)
            //     else:
            //         plan.complete_name = plan.name
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> ComputeRootIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py) ---
            // def _compute_root_id(self):
            // for plan in self.sudo():
            //     plan.root_id = int(plan.parent_path[:-1].split('/')[0]) if plan.parent_path else plan
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> DefaultColorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py) ---
            // def _default_color(self):
            // return randint(1, 11)
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> FindPlanColumnInternalAsync(object model)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py) ---
            // def _find_plan_column(self, model=False):
            // domain = [('name', 'in', [plan._strict_column_name() for plan in self])]
            // if model:
            //     domain.append(('model', '=', model))
            // return self.env['ir.model.fields'].sudo().search(domain)
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> FindRelatedFieldInternalAsync(object model)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py) ---
            // def _find_related_field(self, model=False):
            // domain = [('name', 'in', [plan._hierarchy_name()[1] for plan in self])]
            // if model:
            //     domain.append(('model', '=', model))
            // return self.env['ir.model.fields'].sudo().search(domain)
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> GetAllPlansInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py) ---
            // def _get_all_plans(self):
            // return map(self.browse, self.__get_all_plans())
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> GetApplicabilityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py) ---
            // def _get_applicability(self, **kwargs):
            // """ Returns the applicability of the best applicability line or the default applicability """
            // self.ensure_one()
            // if 'applicability' in kwargs:
            //     # For models for example, we want all plans to be visible, so we force the applicability
            //     return kwargs['applicability']
            // else:
            //     score = 0
            //     applicability = self.default_applicability
            //     for applicability_rule in self.applicability_ids.filtered(
            //             lambda rule:
            //             not rule.company_id
            //             or not kwargs.get('company_id')
            //             or rule.company_id.id == kwargs.get('company_id')
            //     ):
            //         score_rule = applicability_rule._get_score(**kwargs)
            //         if score_rule > score:
            //             applicability = applicability_rule.applicability
            //             score = score_rule
            //     return applicability
            */
            return default;
        }

        public async Task<AccountAnalyticPlan> GetRelevantPlansAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py) ---
            // def get_relevant_plans(self, **kwargs):
            // """ Returns the list of plans that should be available.
            //     This list is computed based on the applicabilities of root plans. """
            // record_account_ids = kwargs.get('existing_account_ids', [])
            // project_plan, other_plans = self.env['account.analytic.plan']._get_all_plans()
            // root_plans = (project_plan + other_plans).filtered(lambda p: (
            //     p.all_account_count > 0
            //     and not p.parent_id
            //     and p._get_applicability(**kwargs) != 'unavailable'
            // ))
            // # If we have accounts that are already selected (before the applicability rules changed or from a model),
            // # we want the plans that were unavailable to be shown in the list (and in optional, because the previous
            // # percentage could be different from 0)
            // forced_plans = self.env['account.analytic.account'].browse(record_account_ids).exists().mapped(
            //     'root_plan_id') - root_plans
            // return [
            //     {
            //         "id": plan.id,
            //         "name": plan.name,
            //         "color": plan.color,
            //         "applicability": plan._get_applicability(**kwargs) if plan in root_plans else 'optional',
            //         "all_account_count": plan.all_account_count,
            //         "column_name": plan._column_name(),
            //     }
            //     for plan in (root_plans + forced_plans).sorted('sequence')
            // ]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountAnalyticPlan> HierarchyNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py) ---
            // def _hierarchy_name(self):
            // depth = self.parent_path.count('/') - 1
            // fname = f"{self._column_name()}_{depth}"
            // if fname.startswith('account_id'):
            //     fname = f'x_{fname}'
            // return depth, fname
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> InverseNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py) ---
            // def _inverse_name(self):
            // self._sync_all_plan_column()
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> InverseParentIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py) ---
            // def _inverse_parent_id(self):
            // self._sync_all_plan_column()
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> IsSubplanFieldUsedInternalAsync(object field)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py) ---
            // def _is_subplan_field_used(self, field):
            // """Return `True` if there are analytic plans still on the same hierarchy level as what the field was created for.
            // 
            // :param field: the recordset of a field created to group by sub plan
            // :rtype: bool
            // """
            // assert '_id_' in field.name
            // root_name, depth = field.name.rsplit('_', maxsplit=1)
            // plan_id_match = re.search(r'\d+', root_name)
            // plan_id = int(plan_id_match.group() if plan_id_match else next(self._get_all_plans()))
            // return bool(self.env['account.analytic.plan'].search([
            //     ('root_id', '=', plan_id),
            //     ('parent_path', 'like', '%'.join('/' * (int(depth) + 1))),
            // ]))
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> OnchangeParentIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py) ---
            // def _onchange_parent_id(self):
            // project_plan, __ = self._get_all_plans()
            // if self._origin.id == project_plan.id:
            //     raise UserError(_("You cannot add a parent to the base plan '%s'", project_plan.name))
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> SearchRootIdInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py) ---
            // def _search_root_id(self, operator, value):
            // if operator != '=':
            //     return NotImplemented
            // return [('parent_path', '=like', f'{value}/%')]
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> StrictColumnNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py) ---
            // def _strict_column_name(self):
            // self.ensure_one()
            // project_plan, _other_plans = self._get_all_plans()
            // return 'account_id' if self == project_plan else f"x_plan{self.id}_id"
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> SyncAllPlanColumnInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py) ---
            // def _sync_all_plan_column(self):
            // model_names = self.env.registry.descendants(['analytic.plan.fields.mixin'], '_inherit') - {'analytic.plan.fields.mixin'}
            // for model in model_names:
            //     self._sync_plan_column(model)
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> SyncPlanColumnInternalAsync(object model)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py) ---
            // def _sync_plan_column(self, model):
            // # Create/delete a new field/column on related models for this plan, and keep the name in sync.
            // for plan in self:
            //     prev_stored = plan._find_plan_column(model)
            //     depth, name_related = plan._hierarchy_name()
            //     prev_related = plan._find_related_field(model)
            //     if plan.parent_id:
            //         # If there is a parent, we just need to make sure there is a field to group by the hierarchy level
            //         # of this plan, allowing to group by sub plan
            //         if prev_stored:
            //             prev_stored.with_context({MODULE_UNINSTALL_FLAG: True}).unlink()
            //         description = f"{plan.root_id.name} ({depth})"
            //         if not prev_related:
            //             self.env['ir.model.fields'].with_context(update_custom_fields=True).sudo().create({
            //                 'name': name_related,
            //                 'field_description': description,
            //                 'state': 'manual',
            //                 'model': model,
            //                 'model_id': self.env['ir.model']._get_id(model),
            //                 'ttype': 'many2one',
            //                 'relation': 'account.analytic.plan',
            //                 'related': plan._column_name() + '.plan_id' + '.parent_id' * (depth - 1),
            //                 'store': False,
            //                 'readonly': True,
            //             })
            //         else:
            //             prev_related.field_description = description
            //     else:
            //         # If there is no parent, then we need to create a new stored field as this is the root plan
            //         if prev_related:
            //             prev_related.with_context({MODULE_UNINSTALL_FLAG: True}).unlink()
            //         description = plan.name
            //         if not prev_stored:
            //             column = plan._strict_column_name()
            //             field = self.env['ir.model.fields'].with_context(update_custom_fields=True).sudo().create({
            //                 'name': column,
            //                 'field_description': description,
            //                 'state': 'manual',
            //                 'model': model,
            //                 'model_id': self.env['ir.model']._get_id(model),
            //                 'ttype': 'many2one',
            //                 'relation': 'account.analytic.account',
            //                 'copied': True,
            //                 'on_delete': 'restrict',
            //             })
            //             Model = self.env[model]
            //             if Model._auto:
            //                 tablename = Model._table
            //                 indexname = make_index_name(tablename, column)
            //                 create_index(self.env.cr, indexname, tablename, [column], 'btree', f'{column} IS NOT NULL')
            //                 field['index'] = True
            //         else:
            //             prev_stored.field_description = description
            // if self.children_ids:
            //     self.children_ids._sync_plan_column(model)
            */
            return default;
        }

        public async Task<AccountAnalyticPlan> ViewAnalyticalAccountsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py) ---
            // def action_view_analytical_accounts(self):
            // result = {
            //     "type": "ir.actions.act_window",
            //     "res_model": "account.analytic.account",
            //     "domain": [('plan_id', "child_of", self.id)],
            //     "context": {'default_plan_id': self.id},
            //     "name": _("Analytical Accounts"),
            //     'view_mode': 'list,form',
            // }
            // return result
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountAnalyticPlan> ViewChildrenPlansAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py) ---
            // def action_view_children_plans(self):
            // result = {
            //     "type": "ir.actions.act_window",
            //     "res_model": "account.analytic.plan",
            //     "domain": [('parent_id', '=', self.id)],
            //     "context": {'default_parent_id': self.id,
            //                 'default_color': self.color},
            //     "name": _("Analytical Plans"),
            //     'view_mode': 'list,form',
            // }
            // return result
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        private async Task<AccountAnalyticPlan> _GetAllPlansInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py) ---
            // def __get_all_plans(self):
            // project_plan = self.browse(int(self.env['ir.config_parameter'].sudo().get_param('analytic.project_plan', 0)))
            // if not project_plan:
            //     raise UserError(_("A 'Project' plan needs to exist and its id needs to be set as `analytic.project_plan` in the system variables"))
            // other_plans = self.sudo().search([('parent_id', '=', False)]) - project_plan
            // return project_plan.id, other_plans.ids
            */
            return default;
        }
    }
}