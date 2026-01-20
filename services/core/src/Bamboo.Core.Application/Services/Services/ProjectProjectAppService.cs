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
    [Module("Project", Category = "Services", Depends = new[] { "analytic", "base_setup", "mail", "portal", "rating", "resource", "web", "web_tour", "digest" })]
    public partial class ProjectProjectAppService : GenericApplicationService<ProjectProject>, IProjectProjectAppService
    {
        private readonly IAnalyticPlanFieldsMixinAppService _analyticPlanFieldsMixinAppService;
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailAliasMixinAppService _mailAliasMixinAppService;
        private readonly IMailTrackingDurationMixinAppService _mailTrackingDurationMixinAppService;
        private readonly IPortalMixinAppService _portalMixinAppService;
        private readonly IRatingParentMixinAppService _ratingParentMixinAppService;
        public ProjectProjectAppService(IRepository<ProjectProject, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IAnalyticPlanFieldsMixinAppService analyticPlanFieldsMixinAppService, IMailActivityMixinAppService mailActivityMixinAppService, IMailAliasMixinAppService mailAliasMixinAppService, IMailTrackingDurationMixinAppService mailTrackingDurationMixinAppService, IPortalMixinAppService portalMixinAppService, IRatingParentMixinAppService ratingParentMixinAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
            _analyticPlanFieldsMixinAppService = analyticPlanFieldsMixinAppService;
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailAliasMixinAppService = mailAliasMixinAppService;
            _mailTrackingDurationMixinAppService = mailTrackingDurationMixinAppService;
            _portalMixinAppService = portalMixinAppService;
            _ratingParentMixinAppService = ratingParentMixinAppService;
        }

        protected async Task<ProjectProject> AddCollaboratorsInternalAsync(object partners, object limited_access)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _add_collaborators(self, partners, limited_access=False):
            // self.ensure_one()
            // new_collaborators = self._get_new_collaborators(partners)
            // if not new_collaborators:
            //     # Then we have nothing to do
            //     return
            // self.write({'collaborator_ids': [
            //     Command.create({
            //         'partner_id': collaborator.id,
            //         'limited_access': limited_access,
            //     }) for collaborator in new_collaborators],
            // })
            */
            return default;
        }

        protected async Task<ProjectProject> AddFollowersInternalAsync(object partners)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _add_followers(self, partners):
            // self.ensure_one()
            // self.message_subscribe(partners.ids)
            // 
            // dict_tasks_per_partner = {}
            // dict_partner_ids_to_subscribe_per_partner = {}
            // for task in self.task_ids:
            //     if task.partner_id in dict_tasks_per_partner:
            //         dict_tasks_per_partner[task.partner_id] |= task
            //     else:
            //         partner_ids_to_subscribe = [
            //             partner.id for partner in partners
            //             if partner == task.partner_id or partner in task.partner_id.child_ids
            //         ]
            //         if partner_ids_to_subscribe:
            //             dict_tasks_per_partner[task.partner_id] = task
            //             dict_partner_ids_to_subscribe_per_partner[task.partner_id] = partner_ids_to_subscribe
            // for partner, tasks in dict_tasks_per_partner.items():
            //     tasks.message_subscribe(dict_partner_ids_to_subscribe_per_partner[partner])
            */
            return default;
        }

        protected async Task<ProjectProject> AddInvoiceItemsInternalAsync(object domain, object profitability_items, object with_action)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _add_invoice_items(self, domain, profitability_items, with_action=True):
            // sale_lines = self.env['sale.order.line'].sudo()._read_group(
            //     self._get_profitability_sale_order_items_domain(domain),
            //     [],
            //     ['id:recordset'],
            // )[0][0]
            // items_from_invoices = self._get_items_from_invoices(
            //     excluded_move_line_ids=sale_lines.invoice_lines.ids,
            //     with_action=with_action
            // )
            // profitability_items['revenues']['data'] += items_from_invoices['revenues']['data']
            // profitability_items['revenues']['total']['to_invoice'] += items_from_invoices['revenues']['total']['to_invoice']
            // profitability_items['revenues']['total']['invoiced'] += items_from_invoices['revenues']['total']['invoiced']
            // profitability_items['costs']['data'] += items_from_invoices['costs']['data']
            // profitability_items['costs']['total']['to_bill'] += items_from_invoices['costs']['total']['to_bill']
            // profitability_items['costs']['total']['billed'] += items_from_invoices['costs']['total']['billed']
            */
            return default;
        }

        protected async Task<ProjectProject> AddPurchaseItemsInternalAsync(object profitability_items, object with_action)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_account, FILE: project_project.py) ---
            // def _add_purchase_items(self, profitability_items, with_action=True):
            // domain = self._get_add_purchase_items_domain()
            // with_action = with_action and (
            //     self.env.user.has_group('account.group_account_invoice')
            //     or self.env.user.has_group('account.group_account_readonly')
            // )
            // self._get_costs_items_from_purchase(domain, profitability_items, with_action=with_action)
            --- ODOO METHOD SOURCE (MODULE: project_purchase, FILE: project_project.py) ---
            // def _add_purchase_items(self, profitability_items, with_action=True):
            // return False
            */
            return default;
        }

        protected async Task<ProjectProject> AliasGetCreationValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _alias_get_creation_values(self):
            // values = super()._alias_get_creation_values()
            // values['alias_model_id'] = self.env['ir.model']._get('project.task').id
            // if self.id:
            //     values['alias_defaults'] = defaults = ast.literal_eval(self.alias_defaults or "{}")
            //     defaults['project_id'] = self.id
            // return values
            */
            return default;
        }

        public async Task<ProjectProject> BillableTimeButtonAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def action_billable_time_button(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("sale_timesheet.timesheet_action_from_sales_order_item")
            // action.update({
            //     'context': {
            //         'search_default_groupby_timesheet_invoice_type': True,
            //         'default_project_id': self.id,
            //     },
            //     'domain': [('project_id', '=', self.id)],
            // })
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectProject> ChangePrivacyVisibilityInternalAsync(object new_visibility)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _change_privacy_visibility(self, new_visibility):
            // """
            // Unsubscribe non-internal users from the project and tasks if the project privacy visibility
            // goes from 'portal' to a different value.
            // If the privacy visibility is set to 'portal', subscribe back project and tasks partners.
            // """
            // for project in self:
            //     if project.privacy_visibility == new_visibility:
            //         continue
            //     if new_visibility in ['invited_users', 'portal']:
            //         project.message_subscribe(partner_ids=project.partner_id.ids)
            //         for task in project.task_ids.filtered('partner_id'):
            //             task.message_subscribe(partner_ids=task.partner_id.ids)
            //     elif project.privacy_visibility in ['invited_users', 'portal']:
            //         portal_users = project.message_partner_ids.user_ids.filtered('share')
            //         project.message_unsubscribe(partner_ids=portal_users.partner_id.ids)
            //         project.tasks._unsubscribe_portal_users()
            //         # revoke access_token since the project and its tasks are no longer accessible for portal/public users
            //         project.tasks.access_token = ''
            //         project.access_token = ''
            */
            return default;
        }

        protected async Task<ProjectProject> CheckAccountIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _check_account_id(self):
            // # Overriden from 'analytic.plan.fields.mixin'
            // pass
            */
            return default;
        }

        protected async Task<ProjectProject> CheckAllowTimesheetInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py) ---
            // def _check_allow_timesheet(self):
            // for project in self:
            //     if project.allow_timesheets and not project.account_id and not project.is_template:
            //         project_plan, _other_plans = self.env['account.analytic.plan']._get_all_plans()
            //         raise ValidationError(_(
            //             "To use the timesheets feature, you need an analytic account for your project. Please set one up in the plan '%(plan_name)s' or turn off the timesheets feature.",
            //             plan_name=project_plan.name
            //         ))
            */
            return default;
        }

        public async Task<ProjectProject> CheckFeaturesEnabledAsync(Guid id, ProjectProjectCheckFeaturesEnabledRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def check_features_enabled(self, updated_features=None):
            // if not self.env.user.has_group('project.group_project_user'):
            //     return {}
            // if updated_features:
            //     return {
            //         field_name: self.env.user.has_group(group)
            //         for field_name, group in self._get_project_features_mapping().items()
            //         if field_name in updated_features
            //     }
            // return {
            //     field_name: self.env.user.has_group(group)
            //     for field_name, group in self._get_project_features_mapping().items()
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectProject> CheckProjectGroupAtRemovalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _check_project_group_at_removal(self):
            // self._check_project_group_with_field('allow_task_dependencies', 'project.group_project_task_dependencies')
            // self._check_project_group_with_field('allow_milestones', 'project.group_project_milestone')
            // self._check_project_group_with_field('allow_recurring_tasks', 'project.group_project_recurring_tasks')
            */
            return default;
        }

        protected async Task<ProjectProject> CheckProjectGroupWithFieldInternalAsync(object field_name, object group_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _check_project_group_with_field(self, field_name, group_name):
            // """ Check if the user has the group 'group_name' and if there is a project with the field 'field_name' set to True.
            // If not, remove the group 'group_name' from the user base group.
            // Otherwise, add the group 'group_name' to the user base group.
            // Returns True if the group was added, False if it was removed, None if no change was made.
            // """
            // has_user_group = bool(self.env.user.has_group(group_name))
            // group = self.env.ref(group_name)
            // base_group_user = self.env.ref('base.group_user')
            // has_project_field_set = bool(self.env['project.project'].search_count([(field_name, '=', True)], limit=1))
            // res = None
            // 
            // if not has_user_group and has_project_field_set:
            //     # add the group to the base user group if there is at least one project with field_name=True
            //     base_group_user.sudo().write({
            //         'implied_ids': [Command.link(group.id)]
            //     })
            //     res = True
            // elif has_user_group and not has_project_field_set:
            //     # remove the group from the base user group if there is no project with field_name=True
            //     base_group_user.sudo().write({
            //         'implied_ids': [Command.unlink(group.id)]
            //     })
            //     group.sudo().write({'user_ids': [Command.clear()]})
            //     res = False
            // return res
            */
            return default;
        }

        protected async Task<ProjectProject> CheckProjectSharingAccessInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _check_project_sharing_access(self):
            // self.ensure_one()
            // if self.privacy_visibility not in ['invited_users', 'portal']:
            //     return False
            // if self.env.user._is_portal():
            //     return self.env['project.collaborator'].search([('project_id', '=', self.sudo().id), ('partner_id', '=', self.env.user.partner_id.id)])
            // return self.env.user._is_internal()
            */
            return default;
        }

        protected async Task<ProjectProject> CheckSaleLineTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def _check_sale_line_type(self):
            // for project in self.filtered(lambda project: project.sale_line_id):
            //     if not project.sale_line_id.is_service:
            //         raise ValidationError(_("You cannot link a billable project to a sales order item that is not a service."))
            //     if project.sale_line_id.is_expense:
            //         raise ValidationError(_("You cannot link a billable project to a sales order item that comes from an expense or a vendor bill."))
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeAccessInstructionMessageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_access_instruction_message(self):
            // for project in self:
            //     if project.privacy_visibility == 'portal':
            //         project.access_instruction_message = self.env._('To give portal users access to your project, add them as followers. For task access, add them as followers for each task.')
            //     elif project.privacy_visibility == 'followers':
            //         project.access_instruction_message = self.env._('Grant employees access to your project or tasks by adding them as followers. Employees automatically get access to the tasks they are assigned to.')
            //     elif project.privacy_visibility == 'invited_users':
            //         project.access_instruction_message = self.env._("Grant users access by adding them as followers — either to the project or individual tasks. Internal users automatically gain access to tasks they are assigned to.")
            //     else:
            //         project.access_instruction_message = ''
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeAccessUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_access_url(self):
            // super()._compute_access_url()
            // for project in self:
            //     project.access_url = f'/my/projects/{project.id}'
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeAllowTimesheetsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py) ---
            // def _compute_allow_timesheets(self):
            // without_account = self.filtered(lambda t: t._origin and not t.account_id)
            // without_account.update({'allow_timesheets': False})
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeBillingTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def _compute_billing_type(self):
            // self.filtered(lambda project: (not project.allow_billable or not project.allow_timesheets) and project.billing_type == 'manually').billing_type = 'not_billable'
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeBomCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_mrp, FILE: project_project.py) ---
            // def _compute_bom_count(self):
            // bom_count_per_project = dict(
            //     self.env['mrp.bom']._read_group(
            //         [('project_id', 'in', self.ids)],
            //         ['project_id'], ['__count']
            //     )
            // )
            // for project in self:
            //     project.bom_count = bom_count_per_project.get(project)
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeClosedTaskCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_closed_task_count(self):
            // self.__compute_task_count(
            //     count_field='closed_task_count',
            //     additional_domain=[('state', 'in', [*CLOSED_STATES])],
            // )
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeCollaboratorCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_collaborator_count(self):
            // project_sharings = self.filtered(lambda project: project.privacy_visibility in ['invited_users', 'portal'])
            // collaborator_read_group = self.env['project.collaborator']._read_group(
            //     [('project_id', 'in', project_sharings.ids)],
            //     ['project_id'],
            //     ['__count'],
            // )
            // collaborator_count_by_project = {project.id: count for project, count in collaborator_read_group}
            // for project in self:
            //     project.collaborator_count = collaborator_count_by_project.get(project.id, 0)
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeCompanyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_company_id(self):
            // for project in self:
            //     # if a new restriction is put on the account or the customer, the restriction on the project is updated.
            //     if project.account_id.company_id:
            //         project.company_id = project.account_id.company_id
            //     if not project.company_id and project.partner_id.company_id:
            //         project.company_id = project.partner_id.company_id
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeCurrencyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_currency_id(self):
            // default_currency_id = self.env.company.currency_id
            // for project in self:
            //     project.currency_id = project.company_id.currency_id or default_currency_id
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py) ---
            // def _compute_display_name(self):
            // super()._compute_display_name()
            // if len(self.env.context.get('allowed_company_ids') or []) <= 1:
            //     return
            // 
            // for project in self:
            //     if project.is_internal_project:
            //         project.display_name = f'{project.display_name} - {project.company_id.name}'
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeDisplaySalesStatButtonsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _compute_display_sales_stat_buttons(self):
            // for project in self:
            //     project.display_sales_stat_buttons = project.allow_billable and project.partner_id
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeEncodeUomInDaysInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py) ---
            // def _compute_encode_uom_in_days(self):
            // self.encode_uom_in_days = self.env.company.timesheet_encode_uom_id == self.env.ref('uom.product_uom_day')
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeHasAnySoToInvoiceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _compute_has_any_so_to_invoice(self):
            // """Has any Sale Order whose invoice_status is set as To Invoice"""
            // if not self.ids:
            //     self.has_any_so_to_invoice = False
            //     return
            // 
            // project_to_invoice = self._get_projects_for_invoice_status('to invoice')
            // project_to_invoice.has_any_so_to_invoice = True
            // (self - project_to_invoice).has_any_so_to_invoice = False
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeHasAnySoWithNothingToInvoiceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _compute_has_any_so_with_nothing_to_invoice(self):
            // """Has any Sale Order whose invoice_status is set as No"""
            // if not self.ids:
            //     self.has_any_so_with_nothing_to_invoice = False
            //     return
            // 
            // project_nothing_to_invoice = self._get_projects_for_invoice_status('no')
            // project_nothing_to_invoice.has_any_so_with_nothing_to_invoice = True
            // (self - project_nothing_to_invoice).has_any_so_with_nothing_to_invoice = False
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeInvoiceCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _compute_invoice_count(self):
            // data = self.env['account.move.line']._read_group(
            //     [('move_id.move_type', 'in', ['out_invoice', 'out_refund']), ('analytic_distribution', 'in', self.account_id.ids)],
            //     groupby=['analytic_distribution'],
            //     aggregates=['__count'],
            // )
            // data = {int(account_id): move_count for account_id, move_count in data}
            // for project in self:
            //     project.invoice_count = data.get(project.account_id.id, 0)
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeIsFavoriteInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_is_favorite(self):
            // favorite_project_ids = self.env.user.favorite_project_ids
            // for project in self:
            //     project.is_favorite = project in favorite_project_ids
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeIsInternalProjectInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py) ---
            // def _compute_is_internal_project(self):
            // for project in self:
            //     project.is_internal_project = project == project.company_id.internal_project_id
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeIsMilestoneExceededInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_is_milestone_exceeded(self):
            // today = fields.Date.context_today(self)
            // read_group = self.env['project.milestone']._read_group([
            //     ('project_id', 'in', self.filtered('allow_milestones').ids),
            //     ('is_reached', '=', False),
            //     ('deadline', '<=', today)], ['project_id'], ['__count'])
            // mapped_count = {project.id: count for project, count in read_group}
            // for project in self:
            //     project.is_milestone_exceeded = bool(mapped_count.get(project.id, 0))
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeLastUpdateColorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_last_update_color(self):
            // for project in self:
            //     project.last_update_color = STATUS_COLOR[project.last_update_status]
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeLastUpdateStatusInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_last_update_status(self):
            // for project in self:
            //     project.last_update_status = project.last_update_id.status or 'to_define'
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeMilestoneCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_milestone_count(self):
            // read_group = self.env['project.milestone']._read_group([('project_id', 'in', self.ids)], ['project_id'], ['__count'])
            // mapped_count = {project.id: count for project, count in read_group}
            // for project in self:
            //     project.milestone_count = mapped_count.get(project.id, 0)
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeMilestoneReachedCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_milestone_reached_count(self):
            // read_group = self.env['project.milestone']._read_group(
            //     [('project_id', 'in', self.ids), ('is_reached', '=', True)],
            //     ['project_id'],
            //     ['__count'],
            // )
            // mapped_count = {project.id: count for project, count in read_group}
            // for project in self:
            //     project.milestone_count_reached = mapped_count.get(project.id, 0)
            //     project.milestone_progress = project.milestone_count and project.milestone_count_reached * 100 // project.milestone_count
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeNextMilestoneIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_next_milestone_id(self):
            // milestones_per_project_id = {
            //     project.id: milestones
            //     for project, milestones in self.env['project.milestone']._read_group(
            //         [('project_id', 'in', self.ids), ('is_reached', '=', False)],
            //         ['project_id'],
            //         ['id:recordset'],
            //     )
            // }
            // milestones = self.env['project.milestone'].concat(*milestones_per_project_id.values())
            // task_read_group = self.env['project.task']._read_group(
            //     [('milestone_id', 'in', milestones.ids)],
            //     ['milestone_id', 'state'],
            //     ['__count'],
            // )
            // task_count_per_milestones = defaultdict(lambda: (0, 0))
            // for milestone, state, count in task_read_group:
            //     opened_task_count, closed_task_count = task_count_per_milestones[milestone.id]
            //     if state in CLOSED_STATES:
            //         closed_task_count += count
            //     else:
            //         opened_task_count += count
            //     task_count_per_milestones[milestone.id] = opened_task_count, closed_task_count
            // for project in self:
            //     milestones = milestones_per_project_id.get(project.id, self.env['project.milestone'])
            //     project.next_milestone_id = milestones[:1]
            //     milestone_deadline_exceeded = False
            //     milestone_marked_as_done = False
            //     for m in milestones:
            //         opened_task_count, closed_task_count = task_count_per_milestones[m.id]
            //         if (
            //             not milestone_deadline_exceeded
            //             and m.is_deadline_exceeded
            //             and (opened_task_count > 0 or closed_task_count == 0)
            //         ):
            //             milestone_deadline_exceeded = True
            //             break
            //         if not milestone_marked_as_done and opened_task_count == 0 and closed_task_count > 0:
            //             milestone_marked_as_done = True
            //     project.is_milestone_deadline_exceeded = milestone_deadline_exceeded
            //     project.can_mark_milestone_as_done = milestone_marked_as_done
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeOpenTaskCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_open_task_count(self):
            // self.__compute_task_count(
            //     count_field='open_task_count',
            //     additional_domain=[('state', 'in', self.env['project.task'].OPEN_STATES)],
            // )
            */
            return default;
        }

        protected async Task<ProjectProject> ComputePartnerIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _compute_partner_id(self):
            // for project in self:
            //     # Ensures that the partner_id and its project do not have different companies set
            //     if not project.allow_billable or (project.company_id and project.partner_id.company_id and project.company_id != project.partner_id.company_id):
            //         project.partner_id = False
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def _compute_partner_id(self):
            // billable_projects = self.filtered('allow_billable')
            // for project in billable_projects:
            //     if project.partner_id:
            //         continue
            //     if project.allow_billable and project.allow_timesheets and project.pricing_type != 'task_rate':
            //         sol = project.sale_line_id or project.sale_line_employee_ids.sale_line_id[:1]
            //         project.partner_id = sol.order_partner_id
            // super(ProjectProject, self - billable_projects)._compute_partner_id()
            */
            return default;
        }

        protected async Task<ProjectProject> ComputePricingTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def _compute_pricing_type(self):
            // billable_projects = self.filtered('allow_billable')
            // for project in billable_projects:
            //     if project.sale_line_employee_ids:
            //         project.pricing_type = 'employee_rate'
            //     elif project.sale_line_id:
            //         project.pricing_type = 'fixed_rate'
            //     else:
            //         project.pricing_type = 'task_rate'
            // (self - billable_projects).update({'pricing_type': False})
            */
            return default;
        }

        protected async Task<ProjectProject> ComputePrivacyVisibilityWarningInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_privacy_visibility_warning(self):
            // for project in self:
            //     if not project.ids:
            //         project.privacy_visibility_warning = ''
            //     elif project.privacy_visibility in ['invited_users', 'portal'] and project._origin.privacy_visibility not in ['invited_users', 'portal']:
            //         project.privacy_visibility_warning = _('Customers will be added to the followers of their project and tasks.')
            //     elif project.privacy_visibility not in ['invited_users', 'portal'] and project._origin.privacy_visibility in ['invited_users', 'portal']:
            //         project.privacy_visibility_warning = _('Portal users will be removed from the followers of the project and its tasks.')
            //     else:
            //         project.privacy_visibility_warning = ''
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeProductionCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_mrp, FILE: project_project.py) ---
            // def _compute_production_count(self):
            // production_count_per_project = dict(
            //     self.env['mrp.production']._read_group(
            //         [('project_id', 'in', self.ids)],
            //         ['project_id'], ['__count']
            //     )
            // )
            // for project in self:
            //     project.production_count = production_count_per_project.get(project)
            */
            return default;
        }

        protected async Task<ProjectProject> ComputePurchaseOrdersCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_purchase, FILE: project_project.py) ---
            // def _compute_purchase_orders_count(self):
            // purchase_orders_per_project = dict(
            //     self.env['purchase.order']._read_group(
            //         domain=[
            //             ('project_id', 'in', self.ids),
            //             ('order_line', '!=', False),
            //         ],
            //         groupby=['project_id'],
            //         aggregates=['id:array_agg'],
            //     )
            // )
            // purchase_orders_count_per_project_from_lines = dict(
            //     self.env['purchase.order.line']._read_group(
            //         domain=[
            //             ('order_id', 'not in', [order_id for values in purchase_orders_per_project.values() for order_id in values]),
            //             ('analytic_distribution', 'in', self.account_id.ids),
            //         ],
            //         groupby=['analytic_distribution'],
            //         aggregates=['__count'],
            //     )
            // )
            // 
            // projects_no_account = self.filtered(lambda project: not project.account_id)
            // for project in projects_no_account:
            //     project.purchase_orders_count = len(purchase_orders_per_project.get(project, []))
            // 
            // purchase_orders_per_project = {project.account_id.id: len(orders) for project, orders in purchase_orders_per_project.items()}
            // for project in (self - projects_no_account):
            //     project.purchase_orders_count = purchase_orders_per_project.get(project.account_id.id, 0) + purchase_orders_count_per_project_from_lines.get(project.account_id.id, 0)
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeRemainingHoursInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py) ---
            // def _compute_remaining_hours(self):
            // timesheets_read_group = self.env['account.analytic.line']._read_group(
            //     [('project_id', 'in', self.ids)],
            //     ['project_id'],
            //     ['unit_amount:sum'],
            // )
            // timesheet_time_dict = {project.id: unit_amount_sum for project, unit_amount_sum in timesheets_read_group}
            // for project in self:
            //     project.effective_hours = round(timesheet_time_dict.get(project.id, 0.0), 2)
            //     project.remaining_hours = project.allocated_hours - project.effective_hours
            //     project.is_project_overtime = project.remaining_hours < 0
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeResourceCalendarIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_resource_calendar_id(self):
            // for project in self:
            //     project.resource_calendar_id = project.company_id.resource_calendar_id or self.env.company.resource_calendar_id
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeSaleLineIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _compute_sale_line_id(self):
            // self.filtered(
            //     lambda p:
            //         p.sale_line_id and (
            //             not p.partner_id or p.sale_line_id.order_partner_id.commercial_partner_id != p.partner_id.commercial_partner_id
            //         )
            // ).update({'sale_line_id': False})
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def _compute_sale_line_id(self):
            // super()._compute_sale_line_id()
            // for project in self.filtered(lambda p: not p.sale_line_id and p.partner_id and p.pricing_type == 'employee_rate'):
            //     # Give a SOL by default either the last SOL with service product and remaining_hours > 0
            //     SaleOrderLine = self.env['sale.order.line']
            //     sol = SaleOrderLine.search(Domain.AND([
            //         SaleOrderLine._domain_sale_line_service(),
            //         [('order_partner_id', 'child_of', project.partner_id.commercial_partner_id.id), ('remaining_hours', '>', 0)],
            //     ]), limit=1)
            //     project.sale_line_id = sol or project.sale_line_employee_ids.sale_line_id[:1]
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeSaleOrderCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _compute_sale_order_count(self):
            // sale_order_items_per_project_id = self._fetch_sale_order_items_per_project_id({'project.task': [('is_closed', '=', False)]})
            // for project in self:
            //     sale_order_lines = sale_order_items_per_project_id.get(project.id, self.env['sale.order.line'])
            //     project.sale_order_line_count = len(sale_order_lines)
            // 
            //     # Use sudo to avoid AccessErrors when the SOLs belong to different companies.
            //     project.sale_order_count = len(sale_order_lines.sudo().order_id or project.reinvoiced_sale_order_id)
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def _compute_sale_order_count(self):
            // billable_projects = self.filtered('allow_billable')
            // super(ProjectProject, billable_projects)._compute_sale_order_count()
            // non_billable_projects = self - billable_projects
            // non_billable_projects.sale_order_line_count = 0
            // non_billable_projects.sale_order_count = 0
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeShowRatingsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_show_ratings(self):
            // projects_with_rating_active = self.env['project.task.type'].search_fetch(
            //     domain=[
            //         ('project_ids', 'in', self.ids),
            //         ('rating_active', '=', True),
            //     ],
            //     field_names=['project_ids'],
            // ).project_ids
            // for project in self:
            //     project.show_ratings = project in projects_with_rating_active
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeTaskCompletionPercentageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_task_completion_percentage(self):
            // for task in self:
            //     task.task_completion_percentage = task.task_count and 1 - task.open_task_count / task.task_count
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeTaskCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_task_count(self):
            // self.__compute_task_count()
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeTimesheetEncodeUomIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py) ---
            // def _compute_timesheet_encode_uom_id(self):
            // for project in self:
            //     project.timesheet_encode_uom_id = project.company_id.timesheet_encode_uom_id or self.env.company.timesheet_encode_uom_id
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeTimesheetProductIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def _compute_timesheet_product_id(self):
            // default_product = self.env.ref('sale_timesheet.time_product', False)
            // for project in self:
            //     if not project.allow_timesheets or not project.allow_billable:
            //         project.timesheet_product_id = False
            //     elif not project.timesheet_product_id:
            //         project.timesheet_product_id = default_product
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeTotalTimesheetTimeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py) ---
            // def _compute_total_timesheet_time(self):
            // timesheets_read_group = self.env['account.analytic.line']._read_group(
            //     [('project_id', 'in', self.ids)],
            //     ['project_id', 'product_uom_id'],
            //     ['unit_amount:sum'],
            // )
            // timesheet_time_dict = defaultdict(list)
            // for project, product_uom, unit_amount_sum in timesheets_read_group:
            //     timesheet_time_dict[project.id].append((product_uom, unit_amount_sum))
            // 
            // for project in self:
            //     # Timesheets may be stored in a different unit of measure, so first
            //     # we convert all of them to the reference unit
            //     # if the timesheet has no product_uom_id then we take the one of the project
            //     total_time = 0.0
            //     for product_uom, unit_amount in timesheet_time_dict[project.id]:
            //         factor = (product_uom or project.timesheet_encode_uom_id).factor
            //         total_time += unit_amount * (1.0 if project.encode_uom_in_days else factor)
            //     # Now convert to the proper unit of measure set in the settings
            //     total_time /= project.timesheet_encode_uom_id.factor
            //     project.total_timesheet_time = float_round(total_time, precision_digits=2)
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeTotalUpdateIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_total_update_ids(self):
            // update_count_per_project = dict(
            //     self.env['project.update']._read_group(
            //         [('project_id', 'in', self.ids)],
            //         ['project_id'],
            //         ['id:count'],
            //     )
            // )
            // for project in self:
            //     project.update_count = update_count_per_project.get(project, 0)
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeWarningEmployeeRateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def _compute_warning_employee_rate(self):
            // projects = self.filtered(lambda p: p.allow_billable and p.allow_timesheets and p.pricing_type == 'employee_rate')
            // employees = self.env['account.analytic.line']._read_group(
            //     [('task_id', 'in', projects.task_ids.ids), ('employee_id', '!=', False)],
            //     ['project_id'],
            //     ['employee_id:array_agg'],
            // )
            // dict_project_employee = {project.id: employee_ids for project, employee_ids in employees}
            // for project in projects:
            //     project.warning_employee_rate = any(
            //         x not in project.sale_line_employee_ids.employee_id.ids
            //         for x in dict_project_employee.get(project.id, ())
            //     )
            // 
            // (self - projects).warning_employee_rate = False
            */
            return default;
        }

        protected async Task<ProjectProject> ConvertProjectUomToTimesheetEncodeUomInternalAsync(object time)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py) ---
            // def _convert_project_uom_to_timesheet_encode_uom(self, time):
            // uom_from = self.company_id.project_time_mode_id
            // uom_to = self.env.company.timesheet_encode_uom_id
            // return round(uom_from._compute_quantity(time, uom_to, raise_if_failure=False), 2)
            */
            return default;
        }

        public async Task<ProjectProject> CopyDataAsync(Guid id, ProjectProjectCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // copy_from_template = self.env.context.get('copy_from_template')
            // for project, vals in zip(self, vals_list):
            //     if project.is_template and not copy_from_template:
            //         vals['is_template'] = True
            //     if copy_from_template:
            //         for field in self._get_template_field_blacklist():
            //             if field in vals and field not in default:
            //                 del vals[field]
            //     if copy_from_template or (not project.is_template and vals.get('is_template')):
            //         vals['name'] = default.get('name', project.name)
            //     else:
            //         vals['name'] = default.get('name', self.env._('%s (copy)', project.name))
            // return vals_list
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectProject> CopyEmbeddedActionsConfigInternalAsync(object new_projects, object shared_embedded_actions_mapping)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _copy_embedded_actions_config(self, new_projects, shared_embedded_actions_mapping=None):
            // shared_embedded_actions_mapping = shared_embedded_actions_mapping or {}
            // embedded_action_configs_per_project = dict(
            //     self.env['res.users.settings.embedded.action'].sudo()._read_group(
            //         [('res_id', 'in', self.ids), ('res_model', '=', self._name)],
            //         ['res_id'],
            //         ['id:recordset'],
            //     )
            // )
            // valid_embedded_action_ids = self.env['ir.embedded.actions'].sudo().search(
            //     domain=[
            //         ('parent_res_model', '=', self._name),
            //         ('user_id', '=', False),
            //     ],
            // ).ids + [False]
            // new_embedded_actions_config_vals_list = []
            // for project, new_project in zip(self, new_projects):
            //     configs = embedded_action_configs_per_project.get(project.id, self.env['res.users.settings.embedded.action'])
            //     config_vals_list = configs.copy_data({'res_id': new_project.id})
            //     for config_vals in config_vals_list:
            //         # Apply the mapping of shared embedded actions and filter the visibility and order by excluding the user-specific actions
            //         if config_vals['embedded_actions_visibility']:
            //             embedded_actions_visibility = [
            //                 shared_embedded_actions_mapping.get(action_id, action_id)
            //                 for action_id in [False if x == 'false' else int(x) for x in config_vals['embedded_actions_visibility'].split(',')]
            //                 if action_id in valid_embedded_action_ids
            //             ]
            //             config_vals['embedded_actions_visibility'] = ','.join('false' if action_id is False else str(action_id) for action_id in embedded_actions_visibility)
            //         if config_vals['embedded_actions_order']:
            //             embedded_actions_order = [
            //                 shared_embedded_actions_mapping.get(action_id, action_id)
            //                 for action_id in [False if x == 'false' else int(x) for x in config_vals['embedded_actions_order'].split(',')]
            //                 if action_id in valid_embedded_action_ids
            //             ]
            //             config_vals['embedded_actions_order'] = ','.join('false' if action_id is False else str(action_id) for action_id in embedded_actions_order)
            //         new_embedded_actions_config_vals_list.append(config_vals)
            // # sudo is needed to update the user settings for all users using the projects to duplicate
            // self.env['res.users.settings.embedded.action'].sudo().create(new_embedded_actions_config_vals_list)
            */
            return default;
        }

        protected async Task<ProjectProject> CopySharedEmbeddedActionsInternalAsync(object new_projects)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _copy_shared_embedded_actions(self, new_projects):
            // shared_embedded_actions_per_record = dict(self.env['ir.embedded.actions'].sudo()._read_group(
            //     domain=[
            //         ('parent_res_id', 'in', self.ids),
            //         ('parent_res_model', '=', self._name),
            //         ('user_id', '=', False),
            //     ],
            //     groupby=['parent_res_id'],
            //     aggregates=['id:recordset'],
            // ))
            // shared_embedded_actions_mapping = dict()
            // for project, new_project in zip(self, new_projects):
            //     # Copy the shared embedded actions in the new record
            //     shared_embedded_actions = shared_embedded_actions_per_record.get(project.id)
            //     if shared_embedded_actions:
            //         copy_shared_embedded_actions = shared_embedded_actions.copy({'parent_res_id': new_project.id})
            //         for original_action, copied_action in zip(shared_embedded_actions, copy_shared_embedded_actions):
            //             shared_embedded_actions_mapping[original_action.id] = copied_action.id
            //             copied_action.filter_ids = original_action.filter_ids.copy({'embedded_parent_res_id': new_project.id})
            // return shared_embedded_actions_mapping
            */
            return default;
        }

        protected async Task<ProjectProject> CreateAnalyticAccountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _create_analytic_account(self):
            // analytic_accounts_values = self._get_values_analytic_account_batch(self._read_format(['name', 'company_id', 'partner_id'], None))
            // analytic_accounts = self.env['account.analytic.account'].create(analytic_accounts_values)
            // for project, analytic_account in zip(self, analytic_accounts):
            //     project.account_id = analytic_account
            */
            return default;
        }

        public override async Task<ProjectProject> CreateAsync(ProjectProject entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py) ---
            // def create(self, vals_list):
            // """ Create an analytic account if project allow timesheet and don't provide one
            //     Note: create it before calling super() to avoid raising the ValidationError from _check_allow_timesheet
            // """
            // defaults = self.default_get(['allow_timesheets', 'account_id', 'is_template'])
            // analytic_accounts_vals = [
            //     vals for vals in vals_list
            //     if (
            //         vals.get('allow_timesheets', defaults.get('allow_timesheets')) and
            //         not vals.get('account_id', defaults.get('account_id')) and not vals.get('is_template', defaults.get('is_template'))
            //     )
            // ]
            // 
            // if analytic_accounts_vals:
            //     analytic_accounts = self.env['account.analytic.account'].create(self._get_values_analytic_account_batch(analytic_accounts_vals))
            //     for vals, analytic_account in zip(analytic_accounts_vals, analytic_accounts):
            //         vals['account_id'] = analytic_account.id
            // return super().create(vals_list)
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def create(self, vals_list):
            // # Prevent double project creation
            // self = self.with_context(mail_create_nosubscribe=True)
            // if any('label_tasks' in vals and not vals['label_tasks'] for vals in vals_list):
            //     task_label = _("Tasks")
            //     for vals in vals_list:
            //         if 'label_tasks' in vals and not vals['label_tasks']:
            //             vals['label_tasks'] = task_label
            // if self.env.user.has_group('project.group_project_stages'):
            //     if 'default_stage_id' in self.env.context:
            //         stage = self.env['project.project.stage'].browse(self.env.context['default_stage_id'])
            //         # The project's company_id must be the same as the stage's company_id
            //         if stage.company_id:
            //             for vals in vals_list:
            //                 if vals.get('stage_id'):
            //                     continue
            //                 vals['company_id'] = stage.company_id.id
            //     else:
            //         companies_ids = [vals.get('company_id', False) for vals in vals_list] + [False]
            //         stages = self.env['project.project.stage'].search([('company_id', 'in', companies_ids)])
            //         for vals in vals_list:
            //             if vals.get('stage_id'):
            //                 continue
            //             # Pick the stage with the lowest sequence with no company or project's company
            //             stage_domain = [False] if 'company_id' not in vals else [False, vals.get('company_id')]
            //             stage = stages.filtered(lambda s: s.company_id.id in stage_domain)[:1]
            //             vals['stage_id'] = stage.id
            // 
            // for vals in vals_list:
            //     if vals.pop('is_favorite', False):
            //         vals['favorite_user_ids'] = [self.env.uid]
            // projects = super().create(vals_list)
            // return projects
            --- ODOO METHOD SOURCE (MODULE: project_sms, FILE: project_project.py) ---
            // def create(self, vals_list):
            // projects = super().create(vals_list)
            // projects._send_sms()
            // return projects
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def create(self, vals_list):
            // projects = super().create(vals_list)
            // sol_ids = set()
            // for project, vals in zip(projects, vals_list):
            //     if (vals.get('sale_line_id')):
            //         sol_ids.add(vals['sale_line_id'])
            //     if project.sale_order_id and not project.sale_order_id.project_id:
            //         project.sale_order_id.project_id = project.id
            //     elif project.sudo().reinvoiced_sale_order_id and not project.sudo().reinvoiced_sale_order_id.project_id:
            //         project.sudo().reinvoiced_sale_order_id.project_id = project.id
            // if sol_ids:
            //     projects._ensure_sale_order_linked(list(sol_ids))
            // return projects
            */
            return await base.CreateAsync(entity, fields);
        }

        public async Task<ProjectProject> CreateFromTemplateAsync(Guid id, ProjectProjectCreateFromTemplateRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_create_from_template(self, values=None, role_to_users_mapping=None):
            // self.ensure_one()
            // values = values or {}
            // 
            // if self.date_start and self.date:
            //     if not values.get("date_start"):
            //         values["date_start"] = fields.Date.today()
            //     if not values.get("date"):
            //         values["date"] = values["date_start"] + (self.date - self.date_start)
            // 
            // default = {
            //     key.removeprefix('default_'): value
            //     for key, value in self.env.context.items()
            //     if key.startswith('default_') and key.removeprefix('default_') in self._get_template_default_context_whitelist()
            // } | values
            // project = self.with_context(copy_from_template=True, copy_from_project_template=True).copy(default=default)
            // project.message_post(body=self.env._("Project created from template %(name)s.", name=self.name))
            // 
            // # Tasks dispatching using project roles
            // if role_to_users_mapping and (mapping := role_to_users_mapping.filtered(lambda entry: entry.user_ids)):
            //     for new_task in project.task_ids:
            //         for entry in mapping:
            //             if entry.role_id in new_task.role_ids:
            //                 new_task.user_ids |= entry.user_ids
            // 
            // project.task_ids.role_ids = False
            // return project
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectProject> CreateInvoiceAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def action_create_invoice(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("sale.action_view_sale_advance_payment_inv")
            // so_ids = (self.sale_order_id | self.task_ids.sale_order_id).filtered(lambda so: so.invoice_status in ['to invoice', 'no']).ids
            // action['context'] = {
            //     'active_id': so_ids[0] if len(so_ids) == 1 else False,
            //     'active_ids': so_ids
            // }
            // if not self.has_any_so_to_invoice:
            //     action['context']['default_advance_payment_method'] = 'percentage'
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectProject> CreateTemplateFromProjectAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_create_template_from_project(self):
            // self.ensure_one()
            // template = self.copy(default={"is_template": True, "partner_id": False})
            // template._toggle_template_mode(True)
            // template.message_post(body=self.env._("Template created from %s.", self.name))
            // config = {
            //     "tag": "project_template_show_notification",
            //     "params": {
            //         "project_id": template.id,
            //         "undo_method": "unlink",
            //     },
            // }
            // if callbacks := self._get_template_from_project_undo_callbacks():
            //     config["params"]["callback_data"] = {
            //         "method": "create_template_from_project_undo_callback",
            //         "args": [self.id, callbacks],
            //     }
            // return {
            //     "type": "ir.actions.client",
            //     **config,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectProject> CreateTemplateFromProjectUndoCallbackAsync(Guid id, ProjectProjectCreateTemplateFromProjectUndoCallbackRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def create_template_from_project_undo_callback(self, callbacks):
            // self.ensure_one()
            // if callbacks.get("unarchive_project"):
            //     self.action_unarchive()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectProject> CustomerPreviewAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def action_customer_preview(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_url',
            //     'target': 'self',
            //     'url': self.get_portal_url(),
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<ProjectProject> DefaultGetAsync(List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def default_get(self, fields):
            // defaults = super().default_get(fields)
            // if self.env.context.get('order_state') == 'sale':
            //     order_id = self.env.context.get('order_id')
            //     sale_line_id = self.env['sale.order.line'].search(
            //         [('order_id', '=', order_id), ('is_service', '=', True)],
            //         limit=1).id
            //     defaults.update({
            //         'reinvoiced_sale_order_id': order_id,
            //         'sale_line_id': sale_line_id,
            //     })
            // return defaults
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def default_get(self, fields):
            // """ Pre-fill timesheet product as "Time" data product when creating new project allowing billable tasks by default. """
            // result = super().default_get(fields)
            // if 'timesheet_product_id' in fields and result.get('allow_billable') and result.get('allow_timesheets') and not result.get('timesheet_product_id'):
            //     default_product = self.env.ref('sale_timesheet.time_product', False)
            //     if default_product:
            //         result['timesheet_product_id'] = default_product.id
            // return result
            */
            return await base.DefaultGetAsync(fields);
        }

        protected async Task<ProjectProject> DefaultStageIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _default_stage_id(self):
            // # Since project stages are order by sequence first, this should fetch the one with the lowest sequence number.
            // return self.env['project.project.stage'].search([], limit=1)
            */
            return default;
        }

        protected async Task<ProjectProject> DefaultTimesheetProductIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def _default_timesheet_product_id(self):
            // return self.env.ref('sale_timesheet.time_product', False)
            */
            return default;
        }

        protected async Task<ProjectProject> DomainSaleLineIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _domain_sale_line_id(self):
            // domain = Domain.AND([
            //     self.env['sale.order.line']._sellable_lines_domain(),
            //     self.env['sale.order.line']._domain_sale_line_service(),
            //     [
            //         ('order_partner_id', '=?', unquote("partner_id")),
            //     ],
            // ])
            // return domain
            */
            return default;
        }

        protected async Task<ProjectProject> EnsureSaleOrderLinkedInternalAsync(List<Guid> sol_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _ensure_sale_order_linked(self, sol_ids):
            // """ Orders created from project/task are supposed to be confirmed to match the typical flow from sales, but since
            // we allow SO creation from the project/task itself we want to confirm newly created SOs immediately after creation.
            // However this would leads to SOs being confirmed without a single product, so we'd rather do it on record save.
            // """
            // quotations = self.env['sale.order.line'].sudo()._read_group(
            //     domain=[('state', '=', 'draft'), ('id', 'in', sol_ids)],
            //     aggregates=['order_id:recordset'],
            // )[0][0]
            // if quotations:
            //     quotations.action_confirm()
            */
            return default;
        }

        protected async Task<ProjectProject> EnsureStageHasSameCompanyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _ensure_stage_has_same_company(self):
            // for project in self:
            //     if project.stage_id.company_id and project.stage_id.company_id != project.company_id:
            //         raise UserError(
            //             _('This project is associated with %(project_company)s, whereas the selected stage belongs to %(stage_company)s. '
            //             'There are a couple of options to consider: either remove the company designation '
            //             'from the project or from the stage. Alternatively, you can update the company '
            //             'information for these records to align them under the same company.', project_company=project.company_id.name, stage_company=project.stage_id.company_id.name)
            //             if project.company_id else
            //             _('This project is not associated with any company, while the stage is associated with %s. '
            //             'There are a couple of options to consider: either change the project\'s company '
            //             'to align with the stage\'s company or remove the company designation from the stage', project.stage_id.company_id.name)
            //         )
            */
            return default;
        }

        protected async Task<ProjectProject> FetchProductsLinkedToTemplateInternalAsync(object limit)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _fetch_products_linked_to_template(self, limit=None):
            // self.ensure_one()
            // return self.env['product.template'].search([('project_template_id', '=', self.id)], limit=limit)
            */
            return default;
        }

        protected async Task<ProjectProject> FetchSaleOrderItemIdsInternalAsync(object domain_per_model, object limit, object offset)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _fetch_sale_order_item_ids(self, domain_per_model=None, limit=None, offset=None):
            // if not self or not self.filtered('allow_billable'):
            //     return []
            // query = self._get_sale_order_items_query(domain_per_model)
            // query.limit = limit
            // query.offset = offset
            // return [id_ for id_, in self.env.execute_query(query.select('DISTINCT sale_line_id'))]
            */
            return default;
        }

        protected async Task<ProjectProject> FetchSaleOrderItemsInternalAsync(object domain_per_model, object limit, object offset)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _fetch_sale_order_items(self, domain_per_model=None, limit=None, offset=None):
            // return self.env['sale.order.line'].browse(self._fetch_sale_order_item_ids(domain_per_model, limit, offset))
            */
            return default;
        }

        protected async Task<ProjectProject> FetchSaleOrderItemsPerProjectIdInternalAsync(object domain_per_model)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _fetch_sale_order_items_per_project_id(self, domain_per_model=None):
            // if not self:
            //     return {}
            // if len(self) == 1:
            //     return {self.id: self._fetch_sale_order_items(domain_per_model)}
            // sql = self._get_sale_order_items_query(domain_per_model).select('id', 'ARRAY_AGG(DISTINCT sale_line_id) AS sale_line_ids')
            // sql = SQL("%s GROUP BY id", sql)
            // return {
            //     id_: self.env['sale.order.line'].browse(sale_line_ids)
            //     for id_, sale_line_ids in self.env.execute_query(sql)
            // }
            */
            return default;
        }

        protected async Task<ProjectProject> GetAccountNodeContextInternalAsync(object plan)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_account_node_context(self, plan):
            // return {
            //     **super()._get_account_node_context(plan),
            //     'default_company_id': unquote('company_id'),
            // }
            */
            return default;
        }

        protected async Task<ProjectProject> GetActionForProfitabilitySectionInternalAsync(List<Guid> record_ids, object name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_account, FILE: project_project.py) ---
            // def _get_action_for_profitability_section(self, record_ids, name):
            // self.ensure_one()
            // args = [name, [('id', 'in', record_ids)]]
            // if len(record_ids) == 1:
            //     args.append(record_ids[0])
            // return {'name': 'action_profitability_items', 'type': 'object', 'args': json.dumps(args)}
            */
            return default;
        }

        protected async Task<ProjectProject> GetAddPurchaseItemsDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_account, FILE: project_project.py) ---
            // def _get_add_purchase_items_domain(self):
            // purchase_order_line_invoice_line_ids = self._get_already_included_profitability_invoice_line_ids()
            // return [
            //     ('move_type', 'in', ['in_invoice', 'in_refund']),
            //     ('parent_state', 'in', ['draft', 'posted']),
            //     ('price_subtotal', '>', 0),
            //     ('id', 'not in', purchase_order_line_invoice_line_ids),
            // ]
            --- ODOO METHOD SOURCE (MODULE: project_hr_expense, FILE: project_project.py) ---
            // def _get_add_purchase_items_domain(self):
            // return Domain.AND([
            //     super()._get_add_purchase_items_domain(),
            //     Domain('expense_id', '=', False),
            // ])
            */
            return default;
        }

        protected async Task<ProjectProject> GetAlreadyIncludedProfitabilityInvoiceLineIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_already_included_profitability_invoice_line_ids(self):
            // # To be extended to avoid account.move.line overlap between
            // # profitability reports.
            // return []
            --- ODOO METHOD SOURCE (MODULE: project_hr_expense, FILE: project_project.py) ---
            // def _get_already_included_profitability_invoice_line_ids(self):
            // # As both purchase orders and expenses (paid by employee) create vendor bills,
            // # we need to make sure they are exclusive in the profitability report.
            // move_line_ids = super()._get_already_included_profitability_invoice_line_ids()
            // query = self.env['account.move.line'].sudo()._search([
            //     ('expense_id', '!=', False),
            //     ('id', 'not in', move_line_ids),
            // ])
            // return move_line_ids + list(query)
            --- ODOO METHOD SOURCE (MODULE: project_sale_expense, FILE: project_project.py) ---
            // def _get_already_included_profitability_invoice_line_ids(self):
            // move_line_ids = super()._get_already_included_profitability_invoice_line_ids()
            // expenses_read_group = self.env['hr.expense']._read_group(
            //     [('state', 'in', ['posted', 'in_payment', 'paid']), ('analytic_distribution', 'in', self.account_id.ids)],
            //     groupby=['sale_order_id'],
            //     aggregates=['__count'],
            // )
            // if not expenses_read_group:
            //     return move_line_ids
            // for sale_order, count in expenses_read_group:
            //     move_line_ids.extend(sale_order.invoice_ids.mapped('invoice_line_ids').ids)
            // return move_line_ids
            */
            return default;
        }

        protected async Task<ProjectProject> GetCostsItemsFromPurchaseInternalAsync(object domain, object profitability_items, object with_action)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_account, FILE: project_project.py) ---
            // def _get_costs_items_from_purchase(self, domain, profitability_items, with_action=True):
            // """ This method is used in sale_project and project_purchase. Since project_account is the only common module (except project), we create the method here. """
            // # calculate the cost of bills without a purchase order
            // account_move_lines = self.env['account.move.line'].sudo().search_fetch(
            //     domain + [('analytic_distribution', 'in', self.account_id.ids)],
            //     ['balance', 'parent_state', 'company_currency_id', 'analytic_distribution', 'move_id', 'date'],
            // )
            // if account_move_lines:
            //     # Get conversion rate from currencies to currency of the current company
            //     amount_invoiced = amount_to_invoice = 0.0
            //     for move_line in account_move_lines:
            //         line_balance = move_line.company_currency_id._convert(
            //             from_amount=move_line.balance, to_currency=self.currency_id, date=move_line.date
            //         )
            //         # an analytic account can appear several time in an analytic distribution with different repartition percentage
            //         analytic_contribution = sum(
            //             percentage for ids, percentage in move_line.analytic_distribution.items()
            //             if str(self.account_id.id) in ids.split(',')
            //         ) / 100.
            //         if move_line.parent_state == 'draft':
            //             amount_to_invoice -= line_balance * analytic_contribution
            //         else:  # move_line.parent_state == 'posted'
            //             amount_invoiced -= line_balance * analytic_contribution
            //     # don't display the section if the final values are both 0 (bill -> vendor credit)
            //     if amount_invoiced != 0 or amount_to_invoice != 0:
            //         costs = profitability_items['costs']
            //         section_id = 'other_purchase_costs'
            //         bills_costs = {
            //             'id': section_id,
            //             'sequence': self._get_profitability_sequence_per_invoice_type()[section_id],
            //             'billed': amount_invoiced,
            //             'to_bill': amount_to_invoice,
            //         }
            //         if with_action:
            //             bills_costs['action'] = self._get_action_for_profitability_section(account_move_lines.move_id.ids, section_id)
            //         costs['data'].append(bills_costs)
            //         costs['total']['billed'] += amount_invoiced
            //         costs['total']['to_bill'] += amount_to_invoice
            */
            return default;
        }

        public async Task<ProjectProject> GetCreateEditProjectIdsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py) ---
            // def get_create_edit_project_ids(self):
            // return []
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectProject> GetDomainAalWithNoMoveLineInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_account, FILE: project_project.py) ---
            // def _get_domain_aal_with_no_move_line(self):
            // """ this method is used in order to overwrite the domain in sale_timesheet module. Since the field 'project_id' is added to the "analytic line" model
            // in the hr_timesheet module, we can't add the condition ('project_id', '=', False) here. """
            // return [('account_id', '=', self.account_id.id), ('move_line_id', '=', False)]
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def _get_domain_aal_with_no_move_line(self):
            // # we add the tuple 'project_id = False' in the domain to remove the timesheets from the search.
            // return Domain.AND([
            //     super()._get_domain_aal_with_no_move_line(),
            //     [('project_id', '=', False)]
            // ])
            */
            return default;
        }

        protected async Task<ProjectProject> GetDomainFromSectionIdInternalAsync(Guid section_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _get_domain_from_section_id(self, section_id):
            // #  When the sale_timesheet module is not installed, all service products are grouped under the 'service revenues' section.
            // return self._get_sale_items_domain([('product_type', '!=' if section_id == 'materials' else '=', 'service')])
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def _get_domain_from_section_id(self, section_id):
            // section_domains = {
            //     'materials': [
            //         ('product_id.type', '!=', 'service')
            //     ],
            //     'billable_fixed': [
            //         ('product_id.type', '=', 'service'),
            //         ('product_id.invoice_policy', '=', 'order')
            //     ],
            //     'billable_milestones': [
            //         ('product_id.type', '=', 'service'),
            //         ('product_id.invoice_policy', '=', 'delivery'),
            //         ('product_id.service_type', '=', 'milestones'),
            //     ],
            //     'billable_time': [
            //         ('product_id.type', '=', 'service'),
            //         ('product_id.invoice_policy', '=', 'delivery'),
            //         ('product_id.service_type', '=', 'timesheet'),
            //     ],
            //     'billable_manual': [
            //         ('product_id.type', '=', 'service'),
            //         ('product_id.invoice_policy', '=', 'delivery'),
            //         ('product_id.service_type', '=', 'manual'),
            //     ],
            // }
            // 
            // return self._get_sale_items_domain(section_domains.get(section_id, []))
            */
            return default;
        }

        protected async Task<ProjectProject> GetExpenseActionInternalAsync(object domain, List<Guid> expense_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_hr_expense, FILE: project_project.py) ---
            // def _get_expense_action(self, domain=None, expense_ids=None):
            // if not domain and not expense_ids:
            //     return {}
            // action = self.env["ir.actions.actions"]._for_xml_id("hr_expense.hr_expense_actions_all")
            // action.update({
            //     'display_name': self.env._('Expenses'),
            //     'views': [[False, 'list'], [False, 'form'], [False, 'kanban'], [False, 'graph'], [False, 'pivot']],
            //     'context': {'project_id': self.id},
            //     'domain': domain or [('id', 'in', expense_ids)],
            // })
            // if not self.env.context.get('from_embedded_action') and len(expense_ids) == 1:
            //     action["views"] = [[False, 'form']]
            //     action["res_id"] = expense_ids[0]
            // return action
            */
            return default;
        }

        protected async Task<ProjectProject> GetExpensesProfitabilityItemsInternalAsync(object with_action)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_hr_expense, FILE: project_project.py) ---
            // def _get_expenses_profitability_items(self, with_action=True):
            // if not self.account_id:
            //     return {}
            // can_see_expense = with_action and self.env.user.has_group('hr_expense.group_hr_expense_team_approver')
            // 
            // expenses_read_group = self.env['hr.expense']._read_group(
            //     [
            //         ('state', 'in', ['posted', 'in_payment', 'paid']),
            //         ('analytic_distribution', 'in', self.account_id.ids),
            //     ],
            //     groupby=['currency_id'],
            //     aggregates=['id:array_agg', 'untaxed_amount_currency:sum'],
            // )
            // if not expenses_read_group:
            //     return {}
            // expense_ids = []
            // amount_billed = 0.0
            // for currency, ids, untaxed_amount_currency_sum in expenses_read_group:
            //     if can_see_expense:
            //         expense_ids.extend(ids)
            //     amount_billed += currency._convert(
            //         from_amount=untaxed_amount_currency_sum,
            //         to_currency=self.currency_id,
            //         company=self.company_id,
            //     )
            // 
            // section_id = 'expenses'
            // expense_profitability_items = {
            //     'costs': {'id': section_id, 'sequence': self._get_profitability_sequence_per_invoice_type()[section_id], 'billed': -amount_billed, 'to_bill': 0.0},
            // }
            // if can_see_expense:
            //     args = [section_id, [('id', 'in', expense_ids)]]
            //     if len(expense_ids) == 1:
            //         args.append(expense_ids[0])
            //     action = {'name': 'action_profitability_items', 'type': 'object', 'args': json.dumps(args)}
            //     expense_profitability_items['costs']['action'] = action
            // return expense_profitability_items
            --- ODOO METHOD SOURCE (MODULE: project_sale_expense, FILE: project_project.py) ---
            // def _get_expenses_profitability_items(self, with_action=True):
            // expenses_read_group = self.env['hr.expense']._read_group(
            //     [('state', 'in', ['posted', 'in_payment', 'paid']), ('analytic_distribution', 'in', self.account_id.ids)],
            //     groupby=['sale_order_id', 'product_id', 'currency_id'],
            //     aggregates=['id:array_agg', 'untaxed_amount_currency:sum'],
            // )
            // if not expenses_read_group:
            //     return {}
            // expenses_per_so_id = {}
            // expense_ids = []
            // dict_amount_per_currency = defaultdict(lambda: 0.0)
            // can_see_expense = with_action and self.env.user.has_group('hr_expense.group_hr_expense_team_approver')
            // for sale_order, product, currency, ids, untaxed_amount_currency_sum in expenses_read_group:
            //     expenses_per_so_id.setdefault(sale_order.id, {})[product.id] = ids
            //     if can_see_expense:
            //         expense_ids.extend(ids)
            //     dict_amount_per_currency[currency] += untaxed_amount_currency_sum
            // 
            // amount_billed = 0.0
            // for currency, untaxed_amount_currency_sum in dict_amount_per_currency.items():
            //     amount_billed += currency._convert(untaxed_amount_currency_sum, self.currency_id, self.company_id, round=False)
            // 
            // sol_read_group = self.env['sale.order.line'].sudo()._read_group(
            //     [
            //         ('order_id', 'in', list(expenses_per_so_id.keys())),
            //         ('is_expense', '=', True),
            //         ('state', '=', 'sale'),
            //     ],
            //     ['order_id', 'product_id', 'currency_id'],
            //     ['untaxed_amount_to_invoice:sum', 'untaxed_amount_invoiced:sum'],
            // )
            // 
            // total_amount_expense_invoiced = total_amount_expense_to_invoice = 0.0
            // reinvoice_expense_ids = []
            // dict_invoices_amount_per_currency = defaultdict(lambda: {'to_invoice': 0.0, 'invoiced': 0.0})
            // set_currency_ids = {self.currency_id.id}
            // for order, product, currency, untaxed_amount_to_invoice_sum, untaxed_amount_invoiced_sum in sol_read_group:
            //     expense_data_per_product_id = expenses_per_so_id[order.id]
            //     set_currency_ids.add(currency.id)
            //     product_id = product.id
            //     if product_id in expense_data_per_product_id:
            //         dict_invoices_amount_per_currency[currency]['to_invoice'] += untaxed_amount_to_invoice_sum
            //         dict_invoices_amount_per_currency[currency]['invoiced'] += untaxed_amount_invoiced_sum
            //         reinvoice_expense_ids += expense_data_per_product_id[product_id]
            // for currency, revenues in dict_invoices_amount_per_currency.items():
            //     total_amount_expense_to_invoice += currency._convert(revenues['to_invoice'], self.currency_id, self.company_id)
            //     total_amount_expense_invoiced += currency._convert(revenues['invoiced'], self.currency_id, self.company_id)
            // 
            // section_id = 'expenses'
            // sequence = self._get_profitability_sequence_per_invoice_type()[section_id]
            // expense_data = {
            //     'costs': {
            //         'id': section_id,
            //         'sequence': sequence,
            //         'billed': -amount_billed,
            //         'to_bill': 0.0,
            //     },
            // }
            // if reinvoice_expense_ids:
            //     expense_data['revenues'] = {
            //         'id': section_id,
            //         'sequence': sequence,
            //         'invoiced': total_amount_expense_invoiced,
            //         'to_invoice': total_amount_expense_to_invoice,
            //     }
            // if can_see_expense:
            //     def get_action(res_ids):
            //         args = [section_id, [('id', 'in', res_ids)]]
            //         if len(res_ids) == 1:
            //             args.append(res_ids[0])
            //         return {'name': 'action_profitability_items', 'type': 'object', 'args': json.dumps(args)}
            // 
            //     if reinvoice_expense_ids:
            //         expense_data['revenues']['action'] = get_action(reinvoice_expense_ids)
            //     if expense_ids:
            //         expense_data['costs']['action'] = get_action(expense_ids)
            // return expense_data
            */
            return default;
        }

        protected async Task<ProjectProject> GetFoldableSectionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _get_foldable_section(self):
            // return ['materials', 'service_revenues']
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def _get_foldable_section(self):
            // foldable_section = super()._get_foldable_section()
            // return foldable_section + [
            //     'billable_fixed',
            //     'billable_milestones',
            //     'billable_time',
            //     'billable_manual',
            // ]
            */
            return default;
        }

        protected async Task<ProjectProject> GetHidePartnerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_hide_partner(self):
            // return False
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _get_hide_partner(self):
            // return not self.allow_billable
            */
            return default;
        }

        protected async Task<ProjectProject> GetItemsFromAalInternalAsync(object with_action)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_items_from_aal(self, with_action=True):
            // return {
            //     'revenues': {'data': [], 'total': {'invoiced': 0.0, 'to_invoice': 0.0}},
            //     'costs': {'data': [], 'total': {'billed': 0.0, 'to_bill': 0.0}},
            // }
            --- ODOO METHOD SOURCE (MODULE: project_account, FILE: project_project.py) ---
            // def _get_items_from_aal(self, with_action=True):
            // domain = Domain.AND([
            //     self._get_domain_aal_with_no_move_line(),
            //     Domain('category', 'not in', ['manufacturing_order', 'picking_entry']),
            // ])
            // aal_other_search = self.env['account.analytic.line'].sudo().search_read(domain, ['id', 'amount', 'currency_id'])
            // if not aal_other_search:
            //     return {
            //         'revenues': {'data': [], 'total': {'invoiced': 0.0, 'to_invoice': 0.0}},
            //         'costs': {'data': [], 'total': {'billed': 0.0, 'to_bill': 0.0}},
            //     }
            // # dict of form  { company : {costs : float, revenues: float}}
            // dict_amount_per_currency_id = defaultdict(lambda: {'costs': 0.0, 'revenues': 0.0})
            // set_currency_ids = {self.currency_id.id}
            // cost_ids = []
            // revenue_ids = []
            // for aal in aal_other_search:
            //     set_currency_ids.add(aal['currency_id'][0])
            //     aal_amount = aal['amount']
            //     if aal_amount < 0.0:
            //         dict_amount_per_currency_id[aal['currency_id'][0]]['costs'] += aal_amount
            //         cost_ids.append(aal['id'])
            //     else:
            //         dict_amount_per_currency_id[aal['currency_id'][0]]['revenues'] += aal_amount
            //         revenue_ids.append(aal['id'])
            // 
            // total_revenues = total_costs = 0.0
            // for currency_id, dict_amounts in dict_amount_per_currency_id.items():
            //     currency = self.env['res.currency'].browse(currency_id).with_prefetch(dict_amount_per_currency_id)
            //     total_revenues += currency._convert(dict_amounts['revenues'], self.currency_id, self.company_id)
            //     total_costs += currency._convert(dict_amounts['costs'], self.currency_id, self.company_id)
            // 
            // # we dont know what part of the numbers has already been billed or not, so we have no choice but to put everything under the billed/invoiced columns.
            // # The to bill/to invoice ones will simply remain 0
            // profitability_sequence_per_invoice_type = self._get_profitability_sequence_per_invoice_type()
            // revenues = {'id': 'other_revenues_aal', 'sequence': profitability_sequence_per_invoice_type['other_revenues_aal'], 'invoiced': total_revenues, 'to_invoice': 0.0}
            // costs = {'id': 'other_costs_aal', 'sequence': profitability_sequence_per_invoice_type['other_costs_aal'], 'billed': total_costs, 'to_bill': 0.0}
            // 
            // if with_action and self.env.user.has_group('account.group_account_readonly'):
            //     costs['action'] = self._get_action_for_profitability_section(cost_ids, 'other_costs_aal')
            //     revenues['action'] = self._get_action_for_profitability_section(revenue_ids, 'other_revenues_aal')
            // 
            // return {
            //     'revenues': {'data': [revenues], 'total': {'invoiced': total_revenues, 'to_invoice': 0.0}},
            //     'costs': {'data': [costs], 'total': {'billed': total_costs, 'to_bill': 0.0}},
            // }
            */
            return default;
        }

        protected async Task<ProjectProject> GetItemsFromAalPickingInternalAsync(object with_action)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_stock_account, FILE: project_project.py) ---
            // def _get_items_from_aal_picking(self, with_action=True):
            // domain = Domain(self._get_domain_aal_with_no_move_line()) & Domain('category', '=', 'picking_entry')
            // aal_other_search = self.env['account.analytic.line'].sudo().search_read(domain, ['id', 'amount', 'currency_id'])
            // if not aal_other_search:
            //     return False
            // 
            // dict_amount_per_currency_id = {}
            // set_currency_ids = {self.currency_id.id}
            // cost_ids = []
            // for aal in aal_other_search:
            //     set_currency_ids.add(aal['currency_id'][0])
            //     aal_amount = aal['amount']
            //     if not dict_amount_per_currency_id.get(aal['currency_id'][0]):
            //         dict_amount_per_currency_id[aal['currency_id'][0]] = aal_amount
            //     else:
            //         dict_amount_per_currency_id[aal['currency_id'][0]] += aal_amount
            //     cost_ids.append(aal['id'])
            // 
            // total_costs = 0.0
            // for currency_id, amounts in dict_amount_per_currency_id.items():
            //     currency = self.env['res.currency'].browse(currency_id).with_prefetch(dict_amount_per_currency_id)
            //     total_costs += currency._convert(amounts, self.currency_id, self.company_id)
            // 
            // profitability_sequence_per_invoice_type = self._get_profitability_sequence_per_invoice_type()
            // costs = [{'id': 'other_costs', 'sequence': profitability_sequence_per_invoice_type['other_costs_aal'], 'billed': total_costs, 'to_bill': 0.0}]
            // 
            // if with_action and self.env.user.has_group('account.group_account_readonly'):
            //     costs[0]['action'] = self._get_action_for_profitability_section(cost_ids, 'other_costs_aal')
            // 
            // return costs
            */
            return default;
        }

        protected async Task<ProjectProject> GetItemsFromInvoicesDomainInternalAsync(object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _get_items_from_invoices_domain(self, domain=None):
            // domain = Domain(domain or Domain.TRUE)
            // included_invoice_line_ids = self._get_already_included_profitability_invoice_line_ids()
            // return domain & Domain([
            //     ('move_id.move_type', 'in', self.env['account.move'].get_sale_types()),
            //     ('parent_state', 'in', ['draft', 'posted']),
            //     ('price_subtotal', '!=', 0),
            //     ('is_downpayment', '=', False),
            //     ('id', 'not in', included_invoice_line_ids),
            // ])
            */
            return default;
        }

        protected async Task<ProjectProject> GetItemsFromInvoicesInternalAsync(List<Guid> excluded_move_line_ids, object with_action)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _get_items_from_invoices(self, excluded_move_line_ids=None, with_action=True):
            // """
            // Get all items from invoices, and put them into their own respective section
            // (either costs or revenues)
            // If the final total is 0 for either to_invoice or invoiced (ex: invoice -> credit note),
            // we don't output a new section
            // 
            // :param excluded_move_line_ids a list of 'account.move.line' to ignore
            // when fetching the move lines, for example a list of invoices that were
            // generated from a sales order
            // """
            // if excluded_move_line_ids is None:
            //     excluded_move_line_ids = []
            // aml_fetch_fields = [
            //     'balance', 'parent_state', 'company_currency_id', 'analytic_distribution', 'move_id',
            //     'display_type', 'date',
            // ]
            // invoices_move_lines = self.env['account.move.line'].sudo().search_fetch(
            //     Domain.AND([
            //         self._get_items_from_invoices_domain([('id', 'not in', excluded_move_line_ids)]),
            //         [('analytic_distribution', 'in', self.account_id.ids)]
            //     ]),
            //     aml_fetch_fields,
            // )
            // res = {
            //     'revenues': {
            //         'data': [], 'total': {'invoiced': 0.0, 'to_invoice': 0.0}
            //     },
            //     'costs': {
            //         'data': [], 'total': {'billed': 0.0, 'to_bill': 0.0}
            //     },
            // }
            // # TODO: invoices_move_lines.with_context(prefetch_fields=False).move_id.move_type ??
            // if invoices_move_lines:
            //     revenues_lines = []
            //     cogs_lines = []
            //     for move_line in invoices_move_lines:
            //         if move_line['display_type'] == 'cogs':
            //             cogs_lines.append(move_line)
            //         else:
            //             revenues_lines.append(move_line)
            //     for move_lines, ml_type in ((revenues_lines, 'revenues'), (cogs_lines, 'costs')):
            //         amount_invoiced = amount_to_invoice = 0.0
            //         for move_line in move_lines:
            //             currency = move_line.company_currency_id
            //             line_balance = currency._convert(move_line.balance, self.currency_id, self.company_id, move_line.date)
            //             # an analytic account can appear several time in an analytic distribution with different repartition percentage
            //             analytic_contribution = sum(
            //                 percentage for ids, percentage in move_line.analytic_distribution.items()
            //                 if str(self.account_id.id) in ids.split(',')
            //             ) / 100.
            //             if move_line.parent_state == 'draft':
            //                 amount_to_invoice -= line_balance * analytic_contribution
            //             else:  # move_line.parent_state == 'posted'
            //                 amount_invoiced -= line_balance * analytic_contribution
            //         # don't display the section if the final values are both 0 (invoice -> credit note)
            //         if amount_invoiced != 0 or amount_to_invoice != 0:
            //             section_id = 'other_invoice_revenues' if ml_type == 'revenues' else 'cost_of_goods_sold'
            //             invoices_items = {
            //                 'id': section_id,
            //                 'sequence': self._get_profitability_sequence_per_invoice_type()[section_id],
            //                 'invoiced' if ml_type == 'revenues' else 'billed': amount_invoiced,
            //                 'to_invoice' if ml_type == 'revenues' else 'to_bill': amount_to_invoice,
            //             }
            //             if with_action and (
            //                 self.env.user.has_group('sales_team.group_sale_salesman_all_leads')
            //                 or self.env.user.has_group('account.group_account_invoice')
            //                 or self.env.user.has_group('account.group_account_readonly')
            //             ):
            //                 invoices_items['action'] = self._get_action_for_profitability_section(invoices_move_lines.move_id.ids, section_id)
            //             res[ml_type] = {
            //                 'data': [invoices_items],
            //                 'total': {
            //                     'invoiced' if ml_type == 'revenues' else 'billed': amount_invoiced,
            //                     'to_invoice' if ml_type == 'revenues' else 'to_bill': amount_to_invoice,
            //                 },
            //             }
            // return res
            */
            return default;
        }

        public async Task<ProjectProject> GetLastUpdateOrDefaultAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def get_last_update_or_default(self):
            // self.ensure_one()
            // labels = dict(self._fields['last_update_status']._description_selection(self.env))
            // return {
            //     'status': labels.get(self.last_update_status, _('Set Status')),
            //     'color': self.last_update_color,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectProject> GetListViewAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_get_list_view(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('project.project_milestone_action')
            // action['display_name'] = _("%(name)s's Milestones", name=self.name)
            // return action
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def action_get_list_view(self):
            // action = super().action_get_list_view()
            // if self.allow_billable:
            //     action['views'] = [(self.env.ref('sale_project.project_milestone_view_tree').id, view_type) if view_type == 'list' else (view_id, view_type) for view_id, view_type in action['views']]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectProject> GetMilestonesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def get_milestones(self):
            // if self.env.user.has_group('project.group_project_user'):
            //     return self._get_milestones()
            // return {}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectProject> GetMilestonesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_milestones(self):
            // self.ensure_one()
            // return {
            //     'data': self.milestone_ids._get_data_list(),
            // }
            */
            return default;
        }

        protected async Task<ProjectProject> GetNewCollaboratorsInternalAsync(object partners)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_new_collaborators(self, partners):
            // self.ensure_one()
            // return partners.filtered(
            //     lambda partner:
            //         partner not in self.collaborator_ids.partner_id
            //         and partner.partner_share
            // )
            */
            return default;
        }

        public async Task<ProjectProject> GetPanelDataAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def get_panel_data(self):
            // self.ensure_one()
            // if not self.env.user.has_group('project.group_project_user'):
            //     return {}
            // show_profitability = self._show_profitability()
            // panel_data = {
            //     'user': self._get_user_values(),
            //     'buttons': sorted(self._get_stat_buttons(), key=lambda k: k['sequence']),
            //     'currency_id': self.currency_id.id,
            //     'show_project_profitability_helper': show_profitability and self._show_profitability_helper(),
            //     'show_milestones': self.allow_milestones,
            // }
            // if self.allow_milestones:
            //     panel_data['milestones'] = self._get_milestones()
            // if show_profitability:
            //     profitability_items = self.with_context(active_test=False)._get_profitability_items()
            //     if self._get_profitability_sequence_per_invoice_type() and profitability_items and 'revenues' in profitability_items and 'costs' in profitability_items:  # sort the data values
            //         profitability_items['revenues']['data'] = sorted(profitability_items['revenues']['data'], key=lambda k: k['sequence'])
            //         profitability_items['costs']['data'] = sorted(profitability_items['costs']['data'], key=lambda k: k['sequence'])
            //     panel_data['profitability_items'] = profitability_items
            //     panel_data['profitability_labels'] = self._get_profitability_labels()
            // return panel_data
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def get_panel_data(self):
            // panel_data = super().get_panel_data()
            // foldable_sections = self._get_foldable_section()
            // if self._show_profitability() and 'revenues' in panel_data['profitability_items']:
            //     for section in panel_data['profitability_items']['revenues']['data']:
            //         if section['id'] in foldable_sections:
            //             section['isSectionFoldable'] = True
            // return {
            //     **panel_data,
            //     'show_sale_items': self.allow_billable,
            // }
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def get_panel_data(self):
            // panel_data = super().get_panel_data()
            // return {
            //     **panel_data,
            //     'account_id': self.account_id.id,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectProject> GetPickingActionInternalAsync(object action_name, object picking_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_stock, FILE: project_project.py) ---
            // def _get_picking_action(self, action_name, picking_type=None):
            // domain = Domain('project_id', '=', self.id)
            // context = {'default_project_id': self.id}
            // if picking_type:
            //     domain &= Domain('picking_type_id.code', '=', picking_type)
            //     context['restricted_picking_type_code'] = picking_type
            //     if picking_type == 'outgoing':
            //         context['default_partner_id'] = self.partner_id.id
            // view_mode = "list,kanban,form,calendar"
            // if picking_type != 'outgoing':
            //     view_mode += ",activity"
            // return {
            //     'name': action_name,
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'stock.picking',
            //     'view_mode': view_mode,
            //     'domain': domain,
            //     'context': context,
            //     'help': self.env['ir.ui.view']._render_template(
            //         'stock.help_message_template', {
            //             'picking_type_code': picking_type,
            //         }
            //     ),
            // }
            --- ODOO METHOD SOURCE (MODULE: sale_project_stock, FILE: project_project.py) ---
            // def _get_picking_action(self, action_name, picking_type=None):
            // result = super()._get_picking_action(action_name, picking_type)
            // 
            // if picking_type and (property_warehouse := self.env.user.property_warehouse_id):
            //     if picking_type == 'outgoing':
            //         result['context']['default_picking_type_id'] = property_warehouse.out_type_id.id
            //     elif picking_type == 'incoming':
            //         result['context']['default_picking_type_id'] = property_warehouse.in_type_id.id
            // 
            // return result
            */
            return default;
        }

        protected async Task<ProjectProject> GetPlanDomainInternalAsync(object plan)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_plan_domain(self, plan):
            // return Domain.AND([super()._get_plan_domain(plan), ['|', ('company_id', '=', False), ('company_id', '=?', unquote('company_id'))]])
            */
            return default;
        }

        protected async Task<ProjectProject> GetProfitabilityAalDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_profitability_aal_domain(self):
            // return [('account_id', 'in', self.account_id.ids)]
            --- ODOO METHOD SOURCE (MODULE: project_hr_expense, FILE: project_project.py) ---
            // def _get_profitability_aal_domain(self):
            // return Domain.AND([
            //     super()._get_profitability_aal_domain(),
            //     ['|', ('move_line_id', '=', False), ('move_line_id.expense_id', '=', False)],
            // ])
            --- ODOO METHOD SOURCE (MODULE: project_mrp_account, FILE: project_project.py) ---
            // def _get_profitability_aal_domain(self):
            // return Domain.AND([
            //     super()._get_profitability_aal_domain(),
            //     Domain('category', '!=', 'manufacturing_order'),
            // ])
            --- ODOO METHOD SOURCE (MODULE: project_purchase, FILE: project_project.py) ---
            // def _get_profitability_aal_domain(self):
            // return Domain.AND([
            //     super()._get_profitability_aal_domain(),
            //     ['|', ('move_line_id', '=', False), ('move_line_id.purchase_line_id', '=', False)],
            // ])
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def _get_profitability_aal_domain(self):
            // domain = ['|', ('project_id', 'in', self.ids), ('so_line', 'in', self._fetch_sale_order_item_ids())]
            // return Domain.AND([
            //     super()._get_profitability_aal_domain(),
            //     domain,
            // ])
            */
            return default;
        }

        protected async Task<ProjectProject> GetProfitabilityItemsFromAalInternalAsync(object profitability_items, object with_action)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def _get_profitability_items_from_aal(self, profitability_items, with_action=True):
            // if not self.allow_timesheets:
            //     total_invoiced = total_to_invoice = 0.0
            //     revenue_data = []
            //     for revenue in profitability_items['revenues']['data']:
            //         if revenue['id'] in ['billable_fixed', 'billable_time', 'billable_milestones', 'billable_manual']:
            //             continue
            //         total_invoiced += revenue['invoiced']
            //         total_to_invoice += revenue['to_invoice']
            //         revenue_data.append(revenue)
            //     profitability_items['revenues'] = {
            //         'data': revenue_data,
            //         'total': {'to_invoice': total_to_invoice, 'invoiced': total_invoiced},
            //     }
            //     return profitability_items
            // aa_line_read_group = self.env['account.analytic.line'].sudo()._read_group(
            //     self.sudo()._get_profitability_aal_domain(),
            //     ['timesheet_invoice_type', 'timesheet_invoice_id', 'currency_id', 'category'],
            //     ['amount:sum', 'id:array_agg'],
            // )
            // can_see_timesheets = with_action and len(self) == 1 and self.env.user.has_group('hr_timesheet.group_hr_timesheet_approver')
            // revenues_dict = {}
            // costs_dict = {}
            // total_revenues = {'invoiced': 0.0, 'to_invoice': 0.0}
            // total_costs = {'billed': 0.0, 'to_bill': 0.0}
            // convert_company = self.company_id or self.env.company
            // for timesheet_invoice_type, _dummy, currency, category, amount, ids in aa_line_read_group:
            //     if category == 'vendor_bill':
            //         continue  # This is done to prevent expense duplication with product re-invoice policies
            //     amount = currency._convert(amount, self.currency_id, convert_company)
            //     invoice_type = timesheet_invoice_type
            //     cost = costs_dict.setdefault(invoice_type, {'billed': 0.0, 'to_bill': 0.0})
            //     revenue = revenues_dict.setdefault(invoice_type, {'invoiced': 0.0, 'to_invoice': 0.0})
            //     if amount < 0:  # cost
            //         cost['billed'] += amount
            //         total_costs['billed'] += amount
            //     else:  # revenues
            //         revenue['invoiced'] += amount
            //         total_revenues['invoiced'] += amount
            //     if can_see_timesheets and invoice_type not in ['other_costs', 'other_revenues']:
            //         cost.setdefault('record_ids', []).extend(ids)
            //         revenue.setdefault('record_ids', []).extend(ids)
            // action_name = None
            // if can_see_timesheets:
            //     action_name = 'action_profitability_items'
            // 
            // def get_timesheets_action(invoice_type, record_ids):
            //     args = [invoice_type, [('id', 'in', record_ids)]]
            //     if len(record_ids) == 1:
            //         args.append(record_ids[0])
            //     return {'name': action_name, 'type': 'object', 'args': json.dumps(args)}
            // 
            // sequence_per_invoice_type = self._get_profitability_sequence_per_invoice_type()
            // 
            // def convert_dict_into_profitability_data(d, cost=True):
            //     profitability_data = []
            //     key1, key2 = ['to_bill', 'billed'] if cost else ['to_invoice', 'invoiced']
            //     for invoice_type, vals in d.items():
            //         if not vals[key1] and not vals[key2]:
            //             continue
            //         record_ids = vals.pop('record_ids', [])
            //         data = {'id': invoice_type, 'sequence': sequence_per_invoice_type[invoice_type], **vals}
            //         if record_ids:
            //             if invoice_type not in ['other_costs', 'other_revenues'] and can_see_timesheets:  # action to see the timesheets
            //                 action = get_timesheets_action(invoice_type, record_ids)
            //                 data['action'] = action
            //         profitability_data.append(data)
            //     return profitability_data
            // 
            // def merge_profitability_data(a, b):
            //     return {
            //         'data': a['data'] + b['data'],
            //         'total': {key: a['total'][key] + b['total'][key] for key in a['total'] if key in b['total']}
            //     }
            // 
            // for revenue in profitability_items['revenues']['data']:
            //     revenue_id = revenue['id']
            //     aal_revenue = revenues_dict.pop(revenue_id, {})
            //     revenue['to_invoice'] += aal_revenue.get('to_invoice', 0.0)
            //     revenue['invoiced'] += aal_revenue.get('invoiced', 0.0)
            //     record_ids = aal_revenue.get('record_ids', [])
            //     if can_see_timesheets and record_ids:
            //         action = get_timesheets_action(revenue_id, record_ids)
            //         revenue['action'] = action
            // 
            // for cost in profitability_items['costs']['data']:
            //     cost_id = cost['id']
            //     aal_cost = costs_dict.pop(cost_id, {})
            //     cost['to_bill'] += aal_cost.get('to_bill', 0.0)
            //     cost['billed'] += aal_cost.get('billed', 0.0)
            //     record_ids = aal_cost.get('record_ids', [])
            //     if can_see_timesheets and record_ids:
            //         cost['action'] = get_timesheets_action(cost_id, record_ids)
            // 
            // profitability_items['revenues'] = merge_profitability_data(
            //     profitability_items['revenues'],
            //     {'data': convert_dict_into_profitability_data(revenues_dict, False), 'total': total_revenues},
            // )
            // profitability_items['costs'] = merge_profitability_data(
            //     profitability_items['costs'],
            //     {'data': convert_dict_into_profitability_data(costs_dict), 'total': total_costs},
            // )
            // return profitability_items
            */
            return default;
        }

        protected async Task<ProjectProject> GetProfitabilityItemsInternalAsync(object with_action)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_profitability_items(self, with_action=True):
            // return self._get_items_from_aal(with_action)
            --- ODOO METHOD SOURCE (MODULE: project_hr_expense, FILE: project_project.py) ---
            // def _get_profitability_items(self, with_action=True):
            // profitability_data = super()._get_profitability_items(with_action)
            // expenses_data = self._get_expenses_profitability_items(with_action)
            // if expenses_data:
            //     if 'revenues' in expenses_data:
            //         revenues = profitability_data['revenues']
            //         revenues['data'].append(expenses_data['revenues'])
            //         revenues['total'] = {k: revenues['total'][k] + expenses_data['revenues'][k] for k in ['invoiced', 'to_invoice']}
            //     costs = profitability_data['costs']
            //     costs['data'].append(expenses_data['costs'])
            //     costs['total'] = {k: costs['total'][k] + expenses_data['costs'][k] for k in ['billed', 'to_bill']}
            // return profitability_data
            --- ODOO METHOD SOURCE (MODULE: project_mrp_account, FILE: project_project.py) ---
            // def _get_profitability_items(self, with_action=True):
            // profitability_items = super()._get_profitability_items(with_action)
            // mrp_category = 'manufacturing_order'
            // mrp_aal_read_group = self.env['account.analytic.line'].sudo()._read_group(
            //     [('auto_account_id', 'in', self.account_id.ids), ('category', '=', mrp_category)],
            //     ['currency_id'],
            //     ['amount:sum'],
            // )
            // if mrp_aal_read_group:
            //     can_see_manufactoring_order = with_action and len(self) == 1 and self.env.user.has_group('mrp.group_mrp_user')
            //     total_amount = 0
            //     for currency, amount_summed in mrp_aal_read_group:
            //         total_amount += currency._convert(amount_summed, self.currency_id, self.company_id)
            // 
            //     mrp_costs = {
            //         'id': mrp_category,
            //         'sequence': self._get_profitability_sequence_per_invoice_type()[mrp_category],
            //         'billed': total_amount,
            //         'to_bill': 0.0,
            //     }
            //     if can_see_manufactoring_order:
            //         mrp_costs['action'] = {'name': 'action_view_mrp_production', 'type': 'object'}
            //     costs = profitability_items['costs']
            //     costs['data'].append(mrp_costs)
            //     costs['total']['billed'] += mrp_costs['billed']
            // return profitability_items
            --- ODOO METHOD SOURCE (MODULE: project_purchase, FILE: project_project.py) ---
            // def _get_profitability_items(self, with_action=True):
            // profitability_items = super()._get_profitability_items(with_action)
            // if self.account_id:
            //     purchase_lines = self.env['purchase.order.line'].sudo().search([
            //         ('analytic_distribution', 'in', self.account_id.ids),
            //         ('state', 'in', 'purchase')
            //     ])
            //     purchase_order_line_invoice_line_ids = self._get_already_included_profitability_invoice_line_ids()
            //     with_action = with_action and (
            //         self.env.user.has_group('purchase.group_purchase_user')
            //         or self.env.user.has_group('account.group_account_invoice')
            //         or self.env.user.has_group('account.group_account_readonly')
            //     )
            //     if purchase_lines:
            //         amount_invoiced = amount_to_invoice = 0.0
            //         purchase_order_line_invoice_line_ids.extend(purchase_lines.invoice_lines.ids)
            //         for purchase_line in purchase_lines:
            //             price_subtotal = purchase_line.currency_id._convert(purchase_line.price_subtotal, self.currency_id, self.company_id)
            //             # an analytic account can appear several time in an analytic distribution with different repartition percentage
            //             analytic_contribution = sum(
            //                 percentage for ids, percentage in purchase_line.analytic_distribution.items()
            //                 if str(self.account_id.id) in ids.split(',')
            //             ) / 100.
            //             purchase_line_amount_to_invoice = price_subtotal * analytic_contribution
            //             invoice_lines = purchase_line.invoice_lines.filtered(
            //                 lambda l:
            //                 l.parent_state != 'cancel'
            //                 and l.analytic_distribution
            //                 and any(
            //                     key == str(self.account_id.id)
            //                     or key.startswith(str(self.account_id.id) + ",")
            //                     for key in l.analytic_distribution
            //                 )
            //             )
            //             if invoice_lines:
            //                 invoiced_qty = sum(invoice_lines.filtered(lambda l: not l.is_refund).mapped('quantity'))
            //                 if invoiced_qty < purchase_line.product_qty:
            //                     amount_to_invoice -= purchase_line_amount_to_invoice * ((purchase_line.product_qty - invoiced_qty) / purchase_line.product_qty)
            //                 for line in invoice_lines:
            //                     price_subtotal = line.currency_id._convert(line.price_subtotal, self.currency_id, self.company_id)
            //                     if not line.analytic_distribution:
            //                         continue
            //                     # an analytic account can appear several time in an analytic distribution with different repartition percentage
            //                     analytic_contribution = sum(
            //                         percentage for ids, percentage in line.analytic_distribution.items()
            //                         if str(self.account_id.id) in ids.split(',')
            //                     ) / 100.
            //                     cost = price_subtotal * analytic_contribution * (-1 if line.is_refund else 1)
            //                     if line.parent_state == 'posted':
            //                         amount_invoiced -= cost
            //                     else:
            //                         amount_to_invoice -= cost
            //             else:
            //                 amount_to_invoice -= purchase_line_amount_to_invoice
            // 
            //         costs = profitability_items['costs']
            //         section_id = 'purchase_order'
            //         purchase_order_costs = {'id': section_id, 'sequence': self._get_profitability_sequence_per_invoice_type()[section_id], 'billed': amount_invoiced, 'to_bill': amount_to_invoice}
            //         if with_action:
            //             purchase_order = purchase_lines.order_id
            //             args = [section_id, [('id', 'in', purchase_order.ids)]]
            //             if len(purchase_order) == 1:
            //                 args.append(purchase_order.id)
            //             action = {'name': 'action_profitability_items', 'type': 'object', 'args': json.dumps(args)}
            //             purchase_order_costs['action'] = action
            //         costs['data'].append(purchase_order_costs)
            //         costs['total']['billed'] += amount_invoiced
            //         costs['total']['to_bill'] += amount_to_invoice
            //     domain = [
            //         ('move_id.move_type', 'in', ['in_invoice', 'in_refund']),
            //         ('parent_state', 'in', ['draft', 'posted']),
            //         ('price_subtotal', '!=', 0),
            //         ('id', 'not in', purchase_order_line_invoice_line_ids),
            //     ]
            //     self._get_costs_items_from_purchase(domain, profitability_items, with_action=with_action)
            // return profitability_items
            --- ODOO METHOD SOURCE (MODULE: project_stock_account, FILE: project_project.py) ---
            // def _get_profitability_items(self, with_action=True):
            // profitability_items = super()._get_profitability_items(with_action)
            // aal_from_picking = self._get_items_from_aal_picking(with_action)
            // if aal_from_picking:
            //     profitability_items['costs']['data'] += aal_from_picking
            //     profitability_items['costs']['total']['billed'] += aal_from_picking[0]['billed']
            // return profitability_items
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _get_profitability_items(self, with_action=True):
            // profitability_items = super()._get_profitability_items(with_action)
            // sale_items = self.sudo()._get_sale_order_items()
            // domain = [
            //     ('order_id', 'in', sale_items.order_id.ids),
            //     '|',
            //         '|',
            //             ('project_id', 'in', self.ids),
            //             ('project_id', '=', False),
            //         ('id', 'in', sale_items.ids),
            // ]
            // revenue_items_from_sol = self._get_revenues_items_from_sol(
            //     domain,
            //     with_action,
            // )
            // profitability_items['revenues']['data'] += revenue_items_from_sol['data']
            // profitability_items['revenues']['total']['to_invoice'] += revenue_items_from_sol['total']['to_invoice']
            // profitability_items['revenues']['total']['invoiced'] += revenue_items_from_sol['total']['invoiced']
            // self._add_invoice_items(domain, profitability_items, with_action=with_action)
            // self._add_purchase_items(profitability_items, with_action=with_action)
            // return profitability_items
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def _get_profitability_items(self, with_action=True):
            // return self._get_profitability_items_from_aal(
            //     super()._get_profitability_items(with_action),
            //     with_action
            // )
            */
            return default;
        }

        protected async Task<ProjectProject> GetProfitabilityLabelsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_profitability_labels(self):
            // return {}
            --- ODOO METHOD SOURCE (MODULE: project_account, FILE: project_project.py) ---
            // def _get_profitability_labels(self):
            // return {
            //     **super()._get_profitability_labels(),
            //     'other_purchase_costs': self.env._('Vendor Bills'),
            //     'other_revenues_aal': self.env._('Other Revenues'),
            //     'other_costs_aal': self.env._('Other Costs'),
            // }
            --- ODOO METHOD SOURCE (MODULE: project_hr_expense, FILE: project_project.py) ---
            // def _get_profitability_labels(self):
            // labels = super()._get_profitability_labels()
            // labels['expenses'] = self.env._('Expenses')
            // return labels
            --- ODOO METHOD SOURCE (MODULE: project_mrp_account, FILE: project_project.py) ---
            // def _get_profitability_labels(self):
            // labels = super()._get_profitability_labels()
            // labels['manufacturing_order'] = self.env._('Manufacturing Orders')
            // return labels
            --- ODOO METHOD SOURCE (MODULE: project_purchase, FILE: project_project.py) ---
            // def _get_profitability_labels(self):
            // labels = super()._get_profitability_labels()
            // labels['purchase_order'] = self.env._('Purchase Orders')
            // return labels
            --- ODOO METHOD SOURCE (MODULE: project_stock_account, FILE: project_project.py) ---
            // def _get_profitability_labels(self):
            // return {
            //     **super()._get_profitability_labels(),
            //     'other_costs': _lt('Materials'),
            // }
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _get_profitability_labels(self):
            // return {
            //     **super()._get_profitability_labels(),
            //     'service_revenues': self.env._('Other Services'),
            //     'materials': self.env._('Materials'),
            //     'other_invoice_revenues': self.env._('Customer Invoices'),
            //     'downpayments': self.env._('Down Payments'),
            //     'cost_of_goods_sold': self.env._('Cost of Goods Sold'),
            // }
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def _get_profitability_labels(self):
            // return {
            //     **super()._get_profitability_labels(),
            //     'billable_fixed': self.env._('Timesheets (Fixed Price)'),
            //     'billable_time': self.env._('Timesheets (Billed on Timesheets)'),
            //     'billable_milestones': self.env._('Timesheets (Billed on Milestones)'),
            //     'billable_manual': self.env._('Timesheets (Billed Manually)'),
            //     'non_billable': self.env._('Timesheets (Non-Billable)'),
            //     'timesheet_revenues': self.env._('Timesheets revenues'),
            //     'other_costs': self.env._('Materials'),
            // }
            */
            return default;
        }

        protected async Task<ProjectProject> GetProfitabilitySaleOrderItemsDomainInternalAsync(object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _get_profitability_sale_order_items_domain(self, domain=None):
            // domain = Domain(domain or Domain.TRUE)
            // return Domain([
            //     '|', ('product_id', '!=', False), ('is_downpayment', '=', True),
            //     ('is_expense', '=', False),
            //     ('state', '=', 'sale'),
            //     '|', ('qty_to_invoice', '>', 0), ('qty_invoiced', '>', 0),
            // ]) & domain
            */
            return default;
        }

        protected async Task<ProjectProject> GetProfitabilitySequencePerInvoiceTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_profitability_sequence_per_invoice_type(self):
            // return {}
            --- ODOO METHOD SOURCE (MODULE: project_account, FILE: project_project.py) ---
            // def _get_profitability_sequence_per_invoice_type(self):
            // return {
            //     **super()._get_profitability_sequence_per_invoice_type(),
            //     'other_purchase_costs': 11,
            //     'other_revenues_aal': 14,
            //     'other_costs_aal': 15,
            // }
            --- ODOO METHOD SOURCE (MODULE: project_hr_expense, FILE: project_project.py) ---
            // def _get_profitability_sequence_per_invoice_type(self):
            // sequence_per_invoice_type = super()._get_profitability_sequence_per_invoice_type()
            // sequence_per_invoice_type['expenses'] = 13
            // return sequence_per_invoice_type
            --- ODOO METHOD SOURCE (MODULE: project_mrp_account, FILE: project_project.py) ---
            // def _get_profitability_sequence_per_invoice_type(self):
            // sequence_per_invoice_type = super()._get_profitability_sequence_per_invoice_type()
            // sequence_per_invoice_type['manufacturing_order'] = 12
            // return sequence_per_invoice_type
            --- ODOO METHOD SOURCE (MODULE: project_purchase, FILE: project_project.py) ---
            // def _get_profitability_sequence_per_invoice_type(self):
            // sequence_per_invoice_type = super()._get_profitability_sequence_per_invoice_type()
            // sequence_per_invoice_type['purchase_order'] = 10
            // return sequence_per_invoice_type
            --- ODOO METHOD SOURCE (MODULE: project_stock_account, FILE: project_project.py) ---
            // def _get_profitability_sequence_per_invoice_type(self):
            // return {
            //     **super()._get_profitability_sequence_per_invoice_type(),
            //     'other_costs': 12,
            // }
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _get_profitability_sequence_per_invoice_type(self):
            // return {
            //     **super()._get_profitability_sequence_per_invoice_type(),
            //     'service_revenues': 6,
            //     'materials': 7,
            //     'other_invoice_revenues': 9,
            //     'downpayments': 20,
            //     'cost_of_goods_sold': 21,
            // }
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def _get_profitability_sequence_per_invoice_type(self):
            // return {
            //     **super()._get_profitability_sequence_per_invoice_type(),
            //     'billable_fixed': 1,
            //     'billable_time': 2,
            //     'billable_milestones': 3,
            //     'billable_manual': 4,
            //     'non_billable': 5,
            //     'timesheet_revenues': 6,
            //     'other_costs': 12,
            // }
            */
            return default;
        }

        protected async Task<ProjectProject> GetProfitabilityValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_profitability_values(self):
            // if not self.env.user.has_group('project.group_project_manager'):
            //     return {}, False
            // profitability_items = self._get_profitability_items(False)
            // if profitability_items and 'revenues' in profitability_items and 'costs' in profitability_items:  # sort the data values
            //     profitability_items['revenues']['data'] = sorted(profitability_items['revenues']['data'], key=lambda k: k['sequence'])
            //     profitability_items['costs']['data'] = sorted(profitability_items['costs']['data'], key=lambda k: k['sequence'])
            // costs = sum(profitability_items['costs']['total'].values())
            // revenues = sum(profitability_items['revenues']['total'].values())
            // margin = revenues + costs
            // to_bill_to_invoice = profitability_items['costs']['total']['to_bill'] + profitability_items['revenues']['total']['to_invoice']
            // billed_invoiced = profitability_items['costs']['total']['billed'] + profitability_items['revenues']['total']['invoiced']
            // expected_percentage, to_bill_to_invoice_percentage, billed_invoiced_percentage = 0, 0, 0
            // if revenues:
            //     expected_percentage = formatLang(self.env, (margin / revenues) * 100, digits=0)
            // if profitability_items['revenues']['total']['to_invoice']:
            //     to_bill_to_invoice_percentage = formatLang(self.env, (to_bill_to_invoice / profitability_items['revenues']['total']['to_invoice']) * 100, digits=0)
            // if profitability_items['revenues']['total']['invoiced']:
            //     billed_invoiced_percentage = formatLang(self.env, (billed_invoiced / profitability_items['revenues']['total']['invoiced']) * 100, digits=0)
            // profitability_values_dict = {
            //     'account_id': self.account_id,
            //     'costs': profitability_items['costs'],
            //     'revenues': profitability_items['revenues'],
            //     'expected_percentage': expected_percentage,
            //     'to_bill_to_invoice_percentage': to_bill_to_invoice_percentage,
            //     'billed_invoiced_percentage': billed_invoiced_percentage,
            //     'total': {
            //         'costs': costs,
            //         'revenues': revenues,
            //         'margin': margin,
            //         'margin_percentage': formatLang(self.env,
            //                                         not float_utils.float_is_zero(costs, precision_digits=2) and (margin / -costs) * 100 or 0.0,
            //                                         digits=0),
            //     },
            //     'labels': self._get_profitability_labels(),
            // }
            // show_profitability = bool(profitability_values_dict.get('account_id')
            //     and (profitability_values_dict.get('costs') or profitability_values_dict.get('revenues'))
            // )
            // return profitability_values_dict, show_profitability
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _get_profitability_values(self):
            // if not self.allow_billable:
            //     return {}, False
            // return super()._get_profitability_values()
            */
            return default;
        }

        protected async Task<ProjectProject> GetProjectFeaturesMappingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_project_features_mapping(self):
            // return {
            //     'allow_task_dependencies': 'project.group_project_task_dependencies',
            //     'allow_milestones': 'project.group_project_milestone',
            //     'allow_recurring_tasks': 'project.group_project_recurring_tasks',
            // }
            */
            return default;
        }

        protected async Task<ProjectProject> GetProjectToTemplateWarningsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def _get_project_to_template_warnings(self):
            // res = super()._get_project_to_template_warnings()
            // timesheet_linked_count = self.env['account.analytic.line'].search_count([('project_id', '=', self.id)], limit=1)
            // if timesheet_linked_count:
            //     res.append(self.env._("This project is current linked to timesheet."))
            // return res
            */
            return default;
        }

        protected async Task<ProjectProject> GetProjectsForInvoiceStatusInternalAsync(object invoice_status)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _get_projects_for_invoice_status(self, invoice_status):
            // """ Returns a recordset of project.project that has any Sale Order which invoice_status is the same as the
            //     provided invoice_status.
            // 
            //     :param invoice_status: The invoice status.
            // """
            // result = self.env.execute_query(SQL("""
            //     SELECT id
            //       FROM project_project pp
            //      WHERE pp.active = true
            //        AND (   EXISTS(SELECT 1
            //                         FROM sale_order so
            //                         JOIN project_task pt ON pt.sale_order_id = so.id
            //                        WHERE pt.project_id = pp.id
            //                          AND pt.active = true
            //                          AND so.invoice_status = %(invoice_status)s)
            //             OR EXISTS(SELECT 1
            //                         FROM sale_order so
            //                         JOIN sale_order_line sol ON sol.order_id = so.id
            //                        WHERE sol.id = pp.sale_line_id
            //                          AND so.invoice_status = %(invoice_status)s))
            //        AND id in %(ids)s""", ids=tuple(self.ids), invoice_status=invoice_status))
            // return self.env['project.project'].browse(id_ for id_, in result)
            */
            return default;
        }

        protected async Task<ProjectProject> GetProjectsToMakeBillableDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_projects_to_make_billable_domain(self):
            // return [('partner_id', '!=', False)]
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _get_projects_to_make_billable_domain(self):
            // return Domain.AND([
            //     super()._get_projects_to_make_billable_domain(),
            //     [('allow_billable', '=', False)],
            // ])
            */
            return default;
        }

        protected async Task<ProjectProject> GetRevenuesItemsFromSolInternalAsync(object domain, object with_action)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _get_revenues_items_from_sol(self, domain=None, with_action=True):
            // sale_line_read_group = self.env['sale.order.line'].sudo()._read_group(
            //     self._get_profitability_sale_order_items_domain(domain),
            //     ['currency_id', 'product_id', 'is_downpayment'],
            //     ['id:array_agg', 'untaxed_amount_to_invoice:sum', 'untaxed_amount_invoiced:sum'],
            // )
            // display_sol_action = with_action and len(self) == 1 and self.env.user.has_group('sales_team.group_sale_salesman')
            // revenues_dict = {}
            // total_to_invoice = total_invoiced = 0.0
            // data = []
            // sequence_per_invoice_type = self._get_profitability_sequence_per_invoice_type()
            // if sale_line_read_group:
            //     # Get conversion rate from currencies of the sale order lines to currency of project
            //     convert_company = self.company_id or self.env.company
            // 
            //     sols_per_product = defaultdict(lambda: [0.0, 0.0, []])
            //     downpayment_amount_invoiced = 0
            //     downpayment_sol_ids = []
            //     for currency, product, is_downpayment, sol_ids, untaxed_amount_to_invoice, untaxed_amount_invoiced in sale_line_read_group:
            //         if is_downpayment:
            //             downpayment_amount_invoiced += currency._convert(untaxed_amount_invoiced, convert_company.currency_id, convert_company, round=False)
            //             downpayment_sol_ids += sol_ids
            //         else:
            //             sols_per_product[product.id][0] += currency._convert(untaxed_amount_to_invoice, convert_company.currency_id, convert_company)
            //             sols_per_product[product.id][1] += currency._convert(untaxed_amount_invoiced, convert_company.currency_id, convert_company)
            //             sols_per_product[product.id][2] += sol_ids
            //     if downpayment_amount_invoiced:
            //         downpayments_data = {
            //             'id': 'downpayments',
            //             'sequence': sequence_per_invoice_type['downpayments'],
            //             'invoiced': downpayment_amount_invoiced,
            //             'to_invoice': -downpayment_amount_invoiced,
            //         }
            //         if with_action and (
            //             self.env.user.has_group('sales_team.group_sale_salesman_all_leads,')
            //             or self.env.user.has_group('account.group_account_invoice,')
            //             or self.env.user.has_group('account.group_account_readonly')
            //         ):
            //             invoices = self.env['account.move'].search([('line_ids.sale_line_ids', 'in', downpayment_sol_ids)])
            //             args = ['downpayments', [('id', 'in', invoices.ids)]]
            //             if len(invoices) == 1:
            //                 args.append(invoices.id)
            //             downpayments_data['action'] = {
            //                 'name': 'action_profitability_items',
            //                 'type': 'object',
            //                 'args': json.dumps(args),
            //             }
            //         data += [downpayments_data]
            //         total_invoiced += downpayment_amount_invoiced
            //         total_to_invoice -= downpayment_amount_invoiced
            //     product_read_group = self.env['product.product'].sudo()._read_group(
            //         [('id', 'in', list(sols_per_product))],
            //         ['invoice_policy', 'service_type', 'type'],
            //         ['id:array_agg'],
            //     )
            //     service_policy_to_invoice_type = self._get_service_policy_to_invoice_type()
            //     general_to_service_map = self.env['product.template']._get_general_to_service_map()
            //     for invoice_policy, service_type, type_, product_ids in product_read_group:
            //         service_policy = None
            //         if type_ == 'service':
            //             service_policy = general_to_service_map.get(
            //                 (invoice_policy, service_type),
            //                 'ordered_prepaid')
            //         for product_id, (amount_to_invoice, amount_invoiced, sol_ids) in sols_per_product.items():
            //             if product_id in product_ids:
            //                 invoice_type = service_policy_to_invoice_type.get(service_policy, 'materials')
            //                 revenue = revenues_dict.setdefault(invoice_type, {'invoiced': 0.0, 'to_invoice': 0.0})
            //                 revenue['to_invoice'] += amount_to_invoice
            //                 total_to_invoice += amount_to_invoice
            //                 revenue['invoiced'] += amount_invoiced
            //                 total_invoiced += amount_invoiced
            //                 if display_sol_action and invoice_type in ['service_revenues', 'materials']:
            //                     revenue.setdefault('record_ids', []).extend(sol_ids)
            // 
            //     if display_sol_action:
            //         section_name = 'materials'
            //         materials = revenues_dict.get(section_name, {})
            //         sale_order_items = self.env['sale.order.line'] \
            //             .browse(materials.pop('record_ids', [])) \
            //             ._filtered_access('read')
            //         if sale_order_items:
            //             args = [section_name, [('id', 'in', sale_order_items.ids)]]
            //             if len(sale_order_items) == 1:
            //                 args.append(sale_order_items.id)
            //             action_params = {
            //                 'name': 'action_profitability_items',
            //                 'type': 'object',
            //                 'args': json.dumps(args),
            //             }
            //             if len(sale_order_items) == 1:
            //                 action_params['res_id'] = sale_order_items.id
            //             materials['action'] = action_params
            // sequence_per_invoice_type = self._get_profitability_sequence_per_invoice_type()
            // data += [{
            //     'id': invoice_type,
            //     'sequence': sequence_per_invoice_type[invoice_type],
            //     **vals,
            // } for invoice_type, vals in revenues_dict.items()]
            // return {
            //     'data': data,
            //     'total': {'to_invoice': total_to_invoice, 'invoiced': total_invoiced},
            // }
            */
            return default;
        }

        public async Task<ProjectProject> GetSaleItemsDataAsync(Guid id, ProjectProjectGetSaleItemsDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def get_sale_items_data(self, offset=0, limit=None, with_action=True, section_id=None):
            // if not self.env.user.has_group('project.group_project_user'):
            //     return {}
            // 
            // all_sols = self.env['sale.order.line'].sudo().search(
            //     self._get_domain_from_section_id(section_id),
            //     offset=offset,
            //     limit=limit + 1,
            // )
            // display_load_more = False
            // if len(all_sols) > limit:
            //     all_sols = all_sols - all_sols[limit]
            //     display_load_more = True
            // 
            // # filter to only get the action for the SOLs that the user can read
            // action_per_sol = all_sols.sudo(False)._filtered_access('read')._get_action_per_item() if with_action else {}
            // 
            // def get_action(sol_id):
            //     """ Return the action vals to call it in frontend if the user can access to the SO related """
            //     action, res_id = action_per_sol.get(sol_id, (None, None))
            //     return {'action': {'name': action, 'resId': res_id, 'buttonContext': json.dumps({'active_id': sol_id, 'default_project_id': self.id})}} if action else {}
            // 
            // return {
            //     'sol_items': [{
            //         **sol_read,
            //         **get_action(sol_read['id']),
            //     } for sol_read in all_sols.with_context(with_price_unit=True)._read_format(['display_name', 'product_uom_qty', 'qty_delivered', 'qty_invoiced', 'product_uom_id', 'product_id'])],
            //     'displayLoadMore': display_load_more,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectProject> GetSaleItemsDomainInternalAsync(object additional_domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _get_sale_items_domain(self, additional_domain=None):
            // sale_items = self.sudo()._get_sale_order_items()
            // domain = [
            //     ('order_id', 'in', sale_items.sudo().order_id.ids),
            //     ('is_downpayment', '=', False),
            //     ('state', '=', 'sale'),
            //     ('display_type', '=', False),
            //     '|',
            //         ('project_id', 'in', [*self.ids, False]),
            //         ('id', 'in', sale_items.ids),
            // ]
            // if additional_domain:
            //     domain = Domain.AND([domain, additional_domain])
            // return domain
            */
            return default;
        }

        protected async Task<ProjectProject> GetSaleOrderItemsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _get_sale_order_items(self):
            // return self._fetch_sale_order_items()
            */
            return default;
        }

        protected async Task<ProjectProject> GetSaleOrderItemsQueryInternalAsync(object domain_per_model)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _get_sale_order_items_query(self, domain_per_model=None):
            // if domain_per_model is None:
            //     domain_per_model = {}
            // billable_project_domain = [('allow_billable', '=', True)]
            // project_domain = [('id', 'in', self.ids), ('sale_line_id', '!=', False)]
            // if 'project.project' in domain_per_model:
            //     project_domain = Domain.AND([
            //         domain_per_model['project.project'],
            //         project_domain,
            //         billable_project_domain,
            //     ])
            // project_query = self.env['project.project']._search(project_domain)
            // project_sql = project_query.select(f'{self._table}.id ', f'{self._table}.sale_line_id')
            // 
            // Task = self.env['project.task']
            // task_domain = [('project_id', 'in', self.ids), ('sale_line_id', '!=', False)]
            // if Task._name in domain_per_model:
            //     task_domain = Domain.AND([
            //         domain_per_model[Task._name],
            //         task_domain,
            //     ])
            // task_query = Task._search(task_domain)
            // task_sql = task_query.select(f'{Task._table}.project_id AS id', f'{Task._table}.sale_line_id')
            // 
            // ProjectMilestone = self.env['project.milestone']
            // milestone_domain = [('project_id', 'in', self.ids), ('allow_billable', '=', True), ('sale_line_id', '!=', False)]
            // if ProjectMilestone._name in domain_per_model:
            //     milestone_domain = Domain.AND([
            //         domain_per_model[ProjectMilestone._name],
            //         milestone_domain,
            //         billable_project_domain,
            //     ])
            // milestone_query = ProjectMilestone._search(milestone_domain)
            // milestone_sql = milestone_query.select(
            //     f'{ProjectMilestone._table}.project_id AS id',
            //     f'{ProjectMilestone._table}.sale_line_id',
            // )
            // 
            // SaleOrderLine = self.env['sale.order.line']
            // sale_order_line_domain = [
            //     '&',
            //         ('display_type', '=', False),
            //         ('order_id', 'any', ['|',
            //             ('id', 'in', self.reinvoiced_sale_order_id.ids),
            //             ('project_id', 'in', self.ids),
            //         ]),
            // ]
            // sale_order_line_query = SaleOrderLine._search(sale_order_line_domain, bypass_access=True)
            // sale_order_line_sql = sale_order_line_query.select(
            //     f'{SaleOrderLine._table}.project_id AS id',
            //     f'{SaleOrderLine._table}.id AS sale_line_id',
            // )
            // 
            // return Query(self.env, 'project_sale_order_item', SQL('(%s)', SQL(' UNION ').join([
            //     project_sql, task_sql, milestone_sql, sale_order_line_sql,
            // ])))
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def _get_sale_order_items_query(self, domain_per_model=None):
            // if domain_per_model is None:
            //     domain_per_model = {'project.task': [('allow_billable', '=', True)]}
            // else:
            //     domain_per_model['project.task'] = Domain.AND([
            //         domain_per_model.get('project.task', []),
            //         [('allow_billable', '=', True)],
            //     ])
            // query = super()._get_sale_order_items_query(domain_per_model)
            // 
            // Timesheet = self.env['account.analytic.line']
            // timesheet_domain = [('project_id', 'in', self.ids), ('so_line', '!=', False), ('project_id.allow_billable', '=', True)]
            // if Timesheet._name in domain_per_model:
            //     timesheet_domain = Domain.AND([
            //         domain_per_model.get(Timesheet._name, []),
            //         timesheet_domain,
            //     ])
            // timesheet_query = Timesheet._search(timesheet_domain)
            // timesheet_sql = timesheet_query.select(
            //     f'{Timesheet._table}.project_id AS id',
            //     f'{Timesheet._table}.so_line AS sale_line_id',
            // )
            // 
            // EmployeeMapping = self.env['project.sale.line.employee.map']
            // employee_mapping_domain = [('project_id', 'in', self.ids), ('project_id.allow_billable', '=', True), ('sale_line_id', '!=', False)]
            // if EmployeeMapping._name in domain_per_model:
            //     employee_mapping_domain = Domain.AND([
            //         domain_per_model[EmployeeMapping._name],
            //         employee_mapping_domain,
            //     ])
            // employee_mapping_query = EmployeeMapping._search(employee_mapping_domain)
            // employee_mapping_sql = employee_mapping_query.select(
            //     f'{EmployeeMapping._table}.project_id AS id',
            //     f'{EmployeeMapping._table}.sale_line_id',
            // )
            // 
            // query._tables['project_sale_order_item'] = SQL('(%s)', SQL(' UNION ').join([
            //     query._tables['project_sale_order_item'],
            //     timesheet_sql,
            //     employee_mapping_sql,
            // ]))
            // return query
            */
            return default;
        }

        protected async Task<ProjectProject> GetSaleOrdersDomainInternalAsync(object all_sale_orders)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _get_sale_orders_domain(self, all_sale_orders):
            // return [("id", "in", all_sale_orders.ids)]
            */
            return default;
        }

        protected async Task<ProjectProject> GetSaleOrdersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _get_sale_orders(self):
            // return self._get_sale_order_items().order_id
            */
            return default;
        }

        protected async Task<ProjectProject> GetServicePolicyToInvoiceTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _get_service_policy_to_invoice_type(self):
            // return {
            //     'ordered_prepaid': 'service_revenues',
            //     'delivered_milestones': 'service_revenues',
            //     'delivered_manual': 'service_revenues',
            // }
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def _get_service_policy_to_invoice_type(self):
            // return {
            //     **super()._get_service_policy_to_invoice_type(),
            //     'ordered_prepaid': 'billable_fixed',
            //     'delivered_milestones': 'billable_milestones',
            //     'delivered_timesheet': 'billable_time',
            //     'delivered_manual': 'billable_manual',
            // }
            */
            return default;
        }

        protected async Task<ProjectProject> GetStatButtonsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py) ---
            // def _get_stat_buttons(self):
            // buttons = super()._get_stat_buttons()
            // if not self.allow_timesheets or not self.env.user.has_group("hr_timesheet.group_hr_timesheet_user"):
            //     return buttons
            // 
            // encode_uom = self.env.company.timesheet_encode_uom_id
            // uom_ratio = self.env.ref('uom.product_uom_hour').factor / encode_uom.factor
            // 
            // allocated = self.allocated_hours * uom_ratio
            // effective = self.total_timesheet_time
            // color = ""
            // if allocated:
            //     number = f"{round(effective)} / {round(allocated)} {encode_uom.name}"
            //     success_rate = round(100 * effective / allocated)
            //     if success_rate > 100:
            //         number = self.env._(
            //             "%(effective)s / %(allocated)s %(uom_name)s",
            //             effective=round(effective),
            //             allocated=round(allocated),
            //             uom_name=encode_uom.name,
            //         )
            //         color = "text-danger"
            //     else:
            //         number = self.env._(
            //             "%(effective)s / %(allocated)s %(uom_name)s (%(success_rate)s%%)",
            //             effective=round(effective),
            //             allocated=round(allocated),
            //             uom_name=encode_uom.name,
            //             success_rate=success_rate,
            //         )
            //         if success_rate >= 80:
            //             color = "text-warning"
            //         else:
            //             color = "text-success"
            // else:
            //     number = self.env._(
            //             "%(effective)s %(uom_name)s",
            //             effective=round(effective),
            //             uom_name=encode_uom.name,
            //         )
            // 
            // buttons.append({
            //     "icon": f"clock-o {color}",
            //     "text": self.env._("Timesheets"),
            //     "number": number,
            //     "action_type": "object",
            //     "action": "action_project_timesheets",
            //     "show": True,
            //     "sequence": 2,
            // })
            // if allocated and success_rate > 100:
            //     buttons.append({
            //         "icon": f"warning {color}",
            //         "text": self.env._("Extra Time"),
            //         "number": self.env._(
            //             "%(exceeding_hours)s %(uom_name)s (+%(exceeding_rate)s%%)",
            //             exceeding_hours=round(effective - allocated),
            //             uom_name=encode_uom.name,
            //             exceeding_rate=round(100 * (effective - allocated) / allocated),
            //         ),
            //         "action_type": "object",
            //         "action": "action_project_timesheets",
            //         "show": True,
            //         "sequence": 3,
            //     })
            // 
            // return buttons
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_stat_buttons(self):
            // self.ensure_one()
            // closed_task_count = self.task_count - self.open_task_count
            // if self.task_count:
            //     number = self.env._(
            //         "%(closed_task_count)s / %(task_count)s (%(closed_rate)s%%)",
            //         closed_task_count=closed_task_count,
            //         task_count=self.task_count,
            //         closed_rate=round(100 * closed_task_count / self.task_count),
            //     )
            // else:
            //     number = self.env._(
            //         "%(closed_task_count)s / %(task_count)s",
            //         closed_task_count=closed_task_count,
            //         task_count=self.task_count,
            //     )
            // buttons = [{
            //     'icon': 'check',
            //     'text': self.label_tasks,
            //     'number': number,
            //     'action_type': 'object',
            //     'action': 'action_view_tasks',
            //     'show': True,
            //     'sequence': 1,
            // }]
            // if self.rating_count != 0:
            //     if self.rating_avg >= rating_data.RATING_AVG_TOP:
            //         icon = 'smile-o text-success'
            //     elif self.rating_avg >= rating_data.RATING_AVG_OK:
            //         icon = 'meh-o text-warning'
            //     else:
            //         icon = 'frown-o text-danger'
            //     buttons.append({
            //         'icon': icon,
            //         'text': self.env._('Average Rating'),
            //         'number': f'{int(self.rating_avg) if self.rating_avg.is_integer() else round(self.rating_avg, 1)} / 5',
            //         'action_type': 'object',
            //         'action': 'action_view_all_rating',
            //         'show': self.show_ratings,
            //         'sequence': 15,
            //     })
            // if self.env.user.has_group('project.group_project_user'):
            //     buttons.append({
            //         'icon': 'area-chart',
            //         'text': self.env._('Burndown Chart'),
            //         'action_type': 'action',
            //         'action': 'project.action_project_task_burndown_chart_report',
            //         'additional_context': json.dumps({
            //             'active_id': self.id,
            //             'stage_name_and_sequence_per_id': {
            //                 stage.id: {
            //                     'sequence': stage.sequence,
            //                     'name': stage.name
            //                 } for stage in self.type_ids
            //             },
            //         }),
            //         'show': True,
            //         'sequence': 60,
            //     })
            // return buttons
            --- ODOO METHOD SOURCE (MODULE: project_mrp, FILE: project_project.py) ---
            // def _get_stat_buttons(self):
            // buttons = super()._get_stat_buttons()
            // if self.env.user.has_group('mrp.group_mrp_user'):
            //     buttons.extend([{
            //         'icon': 'flask',
            //         'text': self.env._('Bills of Materials'),
            //         'number': self.bom_count,
            //         'action_type': 'object',
            //         'action': 'action_view_mrp_bom',
            //         'show': self.bom_count > 0,
            //         'sequence': 35,
            //     },
            //     {
            //         'icon': 'wrench',
            //         'text': self.env._('Manufacturing Orders'),
            //         'number': self.production_count,
            //         'action_type': 'object',
            //         'action': 'action_view_mrp_production',
            //         'show': self.production_count > 0,
            //         'sequence': 46,
            //     }])
            // return buttons
            --- ODOO METHOD SOURCE (MODULE: project_purchase, FILE: project_project.py) ---
            // def _get_stat_buttons(self):
            // buttons = super()._get_stat_buttons()
            // if self.env.user.has_group('purchase.group_purchase_user'):
            //     buttons.append({
            //         'icon': 'credit-card',
            //         'text': self.env._('Purchase Orders'),
            //         'number': self.purchase_orders_count,
            //         'action_type': 'object',
            //         'action': 'action_open_project_purchase_orders',
            //         'show': self.purchase_orders_count > 0,
            //         'sequence': 36,
            //     })
            // return buttons
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _get_stat_buttons(self):
            // buttons = super()._get_stat_buttons()
            // if self.env.user.has_group('sales_team.group_sale_salesman_all_leads'):
            //     buttons.append({
            //         'icon': 'dollar',
            //         'text': self.env._('Sales Orders'),
            //         'number': self.sale_order_count,
            //         'action_type': 'object',
            //         'action': 'action_view_sos',
            //         'additional_context': json.dumps({
            //             'create_for_project_id': self.id,
            //         }),
            //         'show': self.display_sales_stat_buttons and self.sale_order_count > 0,
            //         'sequence': 27,
            //     })
            // if self.env.user.has_group('sales_team.group_sale_salesman_all_leads'):
            //     buttons.append({
            //         'icon': 'dollar',
            //         'text': self.env._('Sales Order Items'),
            //         'number': self.sale_order_line_count,
            //         'action_type': 'object',
            //         'action': 'action_view_sols',
            //         'show': self.display_sales_stat_buttons,
            //         'sequence': 28,
            //     })
            // if self.env.user.has_group('account.group_account_readonly'):
            //     buttons.append({
            //         'icon': 'pencil-square-o',
            //         'text': self.env._('Invoices'),
            //         'number': self.invoice_count,
            //         'action_type': 'object',
            //         'action': 'action_open_project_invoices',
            //         'show': bool(self.account_id) and self.invoice_count > 0,
            //         'sequence': 30,
            //     })
            // if self.env.user.has_group('account.group_account_readonly'):
            //     buttons.append({
            //         'icon': 'pencil-square-o',
            //         'text': self.env._('Vendor Bills'),
            //         'number': self.vendor_bill_count,
            //         'action_type': 'object',
            //         'action': 'action_open_project_vendor_bills',
            //         'show': self.vendor_bill_count > 0,
            //         'sequence': 38,
            //     })
            // return buttons
            */
            return default;
        }

        protected async Task<ProjectProject> GetTemplateDefaultContextWhitelistInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_template_default_context_whitelist(self):
            // """
            // Whitelist of fields that can be set through the `default_` context keys when creating a project from a template.
            // """
            // return [
            //     "allow_milestones",
            // ]
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _get_template_default_context_whitelist(self):
            // return [
            //     *super()._get_template_default_context_whitelist(),
            //     'allow_billable',
            //     'from_sale_order_action',
            // ]
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def _get_template_default_context_whitelist(self):
            // return [
            //     *super()._get_template_default_context_whitelist(),
            //     "allow_timesheets",
            // ]
            */
            return default;
        }

        protected async Task<ProjectProject> GetTemplateFieldBlacklistInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_template_field_blacklist(self):
            // """
            // Blacklist of fields to not copy when creating a project from a template.
            // """
            // return [
            //     "partner_id",
            // ]
            */
            return default;
        }

        protected async Task<ProjectProject> GetTemplateFromProjectUndoCallbacksInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_template_from_project_undo_callbacks(self):
            // self.ensure_one()
            // callbacks = {}
            // if self.active:
            //     self.action_archive()
            //     callbacks["unarchive_project"] = True
            // return callbacks
            */
            return default;
        }

        public async Task<ProjectProject> GetTemplateTasksAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def get_template_tasks(self):
            // self.ensure_one()
            // return self.env['project.task'].search_read(
            //     [('project_id', '=', self.id), ('is_template', '=', True)],
            //     ['id', 'name'],
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectProject> GetTemplateToProjectConfirmationCallbacksInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_template_to_project_confirmation_callbacks(self):
            // self.ensure_one()
            // return {}
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _get_template_to_project_confirmation_callbacks(self):
            // callbacks = super()._get_template_to_project_confirmation_callbacks()
            // if self._fetch_products_linked_to_template(limit=1):
            //     callbacks['unlink_template_products'] = True
            // return callbacks
            */
            return default;
        }

        protected async Task<ProjectProject> GetTemplateToProjectWarningsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_template_to_project_warnings(self):
            // self.ensure_one()
            // return []
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _get_template_to_project_warnings(self):
            // self.ensure_one()
            // res = super()._get_template_to_project_warnings()
            // if self.is_template and self._fetch_products_linked_to_template(limit=1):
            //     res.append(self.env._('Converting this template to a regular project will unlink it from its associated products.'))
            // return res
            */
            return default;
        }

        protected async Task<ProjectProject> GetUserValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_user_values(self):
            // return {
            //     'is_project_user': self.env.user.has_group('project.group_project_user'),
            // }
            */
            return default;
        }

        protected async Task<ProjectProject> GetValuesAnalyticAccountBatchInternalAsync(object project_vals_list)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_values_analytic_account_batch(self, project_vals_list):
            // project_plan, _other_plans = self.env['account.analytic.plan']._get_all_plans()
            // return [{
            //     'name': project_vals.get('name', self.env._('Unknown Analytic Account')),
            //     'company_id': project_vals.get('company_id', False),
            //     'partner_id': project_vals.get('partner_id', False),
            //     'plan_id': project_plan.id,
            // } for project_vals in project_vals_list]
            */
            return default;
        }

        protected async Task<ProjectProject> GetViewActionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _get_view_action(self):
            // return self.env["ir.actions.act_window"]._for_xml_id("sale.action_orders")
            */
            return default;
        }

        protected async Task<ProjectProject> GetViewInternalAsync(Guid view_id, object view_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def _get_view(self, view_id=None, view_type='form', **options):
            // arch, view = super()._get_view(view_id, view_type, **options)
            // if view_type == 'form' and self.env.company.timesheet_encode_uom_id == self.env.ref('uom.product_uom_day'):
            //     for node in arch.xpath("//field[@name='display_cost'][not(@string)]"):
            //         node.set('string', 'Daily Cost')
            // return arch, view
            */
            return default;
        }

        protected async Task<ProjectProject> InitDataAnalyticAccountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py) ---
            // def _init_data_analytic_account(self):
            // self.search([('account_id', '=', False), ('allow_timesheets', '=', True), ('is_template', '=', False)])._create_analytic_account()
            */
            return default;
        }

        protected async Task<ProjectProject> InverseAllowMilestonesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _inverse_allow_milestones(self):
            // self._check_project_group_with_field('allow_milestones', 'project.group_project_milestone')
            */
            return default;
        }

        protected async Task<ProjectProject> InverseAllowRecurringTasksInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _inverse_allow_recurring_tasks(self):
            // self._check_project_group_with_field('allow_recurring_tasks', 'project.group_project_recurring_tasks')
            */
            return default;
        }

        protected async Task<ProjectProject> InverseAllowTaskDependenciesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _inverse_allow_task_dependencies(self):
            // """ Reset state for waiting tasks in the project if the feature is disabled
            //     or recompute the tasks with dependencies if the project has the feature enabled again
            // """
            // project_with_task_dependencies_feature = self.filtered('allow_task_dependencies')
            // projects_without_task_dependencies_feature = self - project_with_task_dependencies_feature
            // ProjectTask = self.env['project.task']
            // if (
            //     project_with_task_dependencies_feature
            //     and (
            //         open_tasks_with_dependencies := ProjectTask.search([
            //             ('project_id', 'in', project_with_task_dependencies_feature.ids),
            //             ('depend_on_ids.state', 'in', ProjectTask.OPEN_STATES),
            //             ('state', 'in', ProjectTask.OPEN_STATES),
            //         ])
            //     )
            // ):
            //     open_tasks_with_dependencies.state = '04_waiting_normal'
            // if (
            //     projects_without_task_dependencies_feature
            //     and (
            //         waiting_tasks := ProjectTask.search([
            //             ('project_id', 'in', projects_without_task_dependencies_feature.ids),
            //             ('state', '=', '04_waiting_normal'),
            //         ])
            //     )
            // ):
            //     waiting_tasks.state = '01_in_progress'
            // res = self._check_project_group_with_field('allow_task_dependencies', 'project.group_project_task_dependencies')
            // # Hide/Show task waiting subtype when task dependencies feature is disabled/enabled
            // if res or res is False:
            //     self.env.ref('project.mt_task_waiting').hidden = not res
            //     self.env.ref('project.mt_project_task_waiting').hidden = not res
            */
            return default;
        }

        protected async Task<ProjectProject> InverseCompanyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _inverse_company_id(self):
            // """
            // Ensures that the new company of the project is valid for the account. If not set back the previous company, and raise a user Error.
            // Ensures that the new company of the project is valid for the partner
            // """
            // for project in self:
            //     account = project.account_id
            //     if (
            //         project.partner_id
            //         and project.partner_id.company_id
            //         and project.company_id
            //         and project.company_id != project.partner_id.company_id
            //     ):
            //         raise UserError(_('The project and the associated partner must be linked to the same company.'))
            //     if not account or not account.company_id:
            //         continue
            //     # if the account of the project has more than one company linked to it, or if it has aal, do not update the account, and set back the old company on the project.
            //     if (account.project_count > 1 or account.line_ids) and project.company_id != account.company_id:
            //         raise UserError(
            //             _("The project's company cannot be changed if its analytic account has analytic lines or if more than one project is linked to it."))
            //     account.company_id = project.company_id or project.partner_id.company_id
            */
            return default;
        }

        protected async Task<ProjectProject> MailGetMessageSubtypesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _mail_get_message_subtypes(self):
            // res = super()._mail_get_message_subtypes()
            // if len(self) == 1:
            //     waiting_subtype = self.env.ref('project.mt_project_task_waiting')
            //     if not self.allow_task_dependencies and waiting_subtype in res:
            //         res -= waiting_subtype
            // return res
            */
            return default;
        }

        public async Task<ProjectProject> MapTasksAsync(Guid id, ProjectProjectMapTasksRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def map_tasks(self, new_project_id):
            // """ copy and map tasks from old to new project """
            // project = self.browse(new_project_id)
            // # We want to copy archived task, but do not propagate an active_test context key
            // tasks = self.env['project.task'].with_context(active_test=False).search([('project_id', '=', self.id), ('parent_id', '=', False)])
            // if self.allow_task_dependencies and 'task_mapping' not in self.env.context:
            //     self = self.with_context(task_mapping=dict())
            // # preserve task name and stage, normally altered during copy
            // defaults = self._map_tasks_default_values(project)
            // new_tasks = tasks.with_context(copy_project=True).copy(defaults)
            // all_subtasks = new_tasks._get_all_subtasks()
            // all_subtasks.filtered(
            //     lambda child: child.project_id == self
            // ).write({
            //     'project_id': project.id
            // })
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectProject> MapTasksDefaultValuesInternalAsync(object project)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _map_tasks_default_values(self, project):
            // """ get the default value for the copied task on project duplication.
            // The stage_id, name field will be set for each task in the overwritten copy_data function in project.task """
            // return {
            //     'state': '01_in_progress',
            //     'company_id': project.company_id.id,
            //     'project_id': project.id,
            // }
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _map_tasks_default_values(self, project):
            // defaults = super()._map_tasks_default_values(project)
            // defaults['sale_line_id'] = False
            // return defaults
            */
            return default;
        }

        public async Task<ProjectProject> MessageSubscribeAsync(Guid id, ProjectProjectMessageSubscribeRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def message_subscribe(self, partner_ids=None, subtype_ids=None):
            // """
            // Subscribe to newly created task but not all existing active task when subscribing to a project.
            // User update notification preference of project its propagated to all the tasks that the user is
            // currently following.
            // """
            // res = super().message_subscribe(partner_ids=partner_ids, subtype_ids=subtype_ids)
            // if subtype_ids:
            //     project_subtypes = self.env['mail.message.subtype'].browse(subtype_ids)
            //     task_subtypes = (project_subtypes.mapped('parent_id') | project_subtypes.filtered(lambda sub: sub.internal or sub.default)).ids
            //     if task_subtypes:
            //         for task in self.task_ids:
            //             partners = set(task.message_partner_ids.ids) & set(partner_ids)
            //             if partners:
            //                 task.message_subscribe(partner_ids=list(partners), subtype_ids=task_subtypes)
            //         self.update_ids.message_subscribe(partner_ids=partner_ids, subtype_ids=subtype_ids)
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectProject> MessageUnsubscribeAsync(Guid id, ProjectProjectMessageUnsubscribeRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def message_unsubscribe(self, partner_ids=None):
            // self.task_ids.message_unsubscribe(partner_ids=partner_ids)
            // super().message_unsubscribe(partner_ids=partner_ids)
            // if partner_ids:
            //     self.env['project.collaborator'].search([('partner_id', 'in', partner_ids), ('project_id', 'in', self.ids)]).unlink()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectProject> NotifyGetRecipientsGroupsInternalAsync(object message, object model_description, object msg_vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=False):
            // """ Give access to the portal user/customer if the project visibility is portal. """
            // groups = super()._notify_get_recipients_groups(message, model_description, msg_vals=msg_vals)
            // if not self:
            //     return groups
            // 
            // self.ensure_one()
            // portal_privacy = self.privacy_visibility in ['invited_users', 'portal']
            // for group_name, _group_method, group_data in groups:
            //     if group_name in ['portal', 'portal_customer'] and not portal_privacy:
            //         group_data['has_button_access'] = False
            // return groups
            */
            return default;
        }

        protected async Task<ProjectProject> OnchangeCompanyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _onchange_company_id(self):
            // if (self.env.user.has_group('project.group_project_stages') and self.stage_id.company_id
            //         and self.stage_id.company_id != self.company_id):
            //     self.stage_id = self.env['project.project.stage'].search(
            //         [('company_id', 'in', [self.company_id.id, False])],
            //         order=f"sequence asc, {self.env['project.project.stage']._order}",
            //         limit=1,
            //     ).id
            */
            return default;
        }

        protected async Task<ProjectProject> OnchangeReinvoicedSaleOrderIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _onchange_reinvoiced_sale_order_id(self):
            // if (
            //     not self.sale_line_id
            //     and (service_sols := self.reinvoiced_sale_order_id.order_line.filtered('is_service'))
            // ):
            //     self.sale_line_id = service_sols[0]
            */
            return default;
        }

        protected async Task<ProjectProject> OnchangeSaleLineIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _onchange_sale_line_id(self):
            // if not self.reinvoiced_sale_order_id and self.sale_line_id:
            //     self.reinvoiced_sale_order_id = self.sale_line_id.order_id
            */
            return default;
        }

        public async Task<ProjectProject> OpenAllPickingsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_stock, FILE: project_project.py) ---
            // def action_open_all_pickings(self):
            // self.ensure_one()
            // return self._get_picking_action(_('Stock Moves'))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectProject> OpenAnalyticItemsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_account, FILE: project_project.py) ---
            // def action_open_analytic_items(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('analytic.account_analytic_line_action_entries')
            // action['domain'] = [('account_id', '=', self.account_id.id)]
            // context = literal_eval(action['context'])
            // action['context'] = {
            //     **context,
            //     'create': self.env.context.get('from_embedded_action', False),
            //     'default_account_id': self.account_id.id,
            // }
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectProject> OpenDeliveriesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_stock, FILE: project_project.py) ---
            // def action_open_deliveries(self):
            // self.ensure_one()
            // return self._get_picking_action(_('From WH'), 'outgoing')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectProject> OpenProjectExpensesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_hr_expense, FILE: project_project.py) ---
            // def action_open_project_expenses(self):
            // self.ensure_one()
            // return self._get_expense_action(domain=[('analytic_distribution', 'in', self.account_id.ids)])
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectProject> OpenProjectInvoicesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def action_open_project_invoices(self):
            // move_lines = self.env['account.move.line'].search_fetch(
            //     [
            //         ('move_id.move_type', 'in', ['out_invoice', 'out_refund']),
            //         ('analytic_distribution', 'in', self.account_id.ids),
            //     ],
            //     ['move_id'],
            // )
            // invoice_ids = move_lines.move_id.ids
            // action = {
            //     'name': _('Invoices'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'account.move',
            //     'views': [[False, 'list'], [False, 'form'], [False, 'kanban']],
            //     'domain': [('id', 'in', invoice_ids)],
            //     'context': {
            //         'default_move_type': 'out_invoice',
            //         'default_partner_id': self.partner_id.id,
            //         'project_id': self.id
            //     },
            //     'help': "<p class='o_view_nocontent_smiling_face'>%s</p><p>%s</p>" %
            //     (_("Create a customer invoice"),
            //         _("Create invoices, register payments and keep track of the discussions with your customers."))
            // }
            // if len(invoice_ids) == 1 and not self.env.context.get('from_embedded_action', False):
            //     action['views'] = [[False, 'form']]
            //     action['res_id'] = invoice_ids[0]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectProject> OpenProjectPurchaseOrdersAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_purchase, FILE: project_project.py) ---
            // def action_open_project_purchase_orders(self):
            // purchase_orders = self.env['purchase.order.line'].search([
            //     '|',
            //         ('analytic_distribution', 'in', self.account_id.ids),
            //         ('order_id.project_id', '=', self.id),
            // ]).order_id
            // action_window = {
            //     'name': self.env._('Purchase Orders'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'purchase.order',
            //     'views': [
            //         [False, 'list'], [self.env.ref('purchase.purchase_order_view_kanban_without_dashboard').id, 'kanban'],
            //         [False, 'form'], [False, 'calendar'], [False, 'pivot'], [False, 'graph'], [False, 'activity'],
            //     ],
            //     'domain': [('id', 'in', purchase_orders.ids)],
            //     'context': {
            //         'default_project_id': self.id,
            //     },
            //     'help': "<p class='o_view_nocontent_smiling_face'>%s</p><p>%s</p>" % (
            //         _("No purchase order found. Let's create one."),
            //         _("Once you ordered your products from your supplier, confirm your request for quotation and it will turn "
            //             "into a purchase order."),
            //     ),
            // }
            // if len(purchase_orders) == 1 and not self.env.context.get('from_embedded_action'):
            //     action_window['views'] = [[False, 'form']]
            //     action_window['res_id'] = purchase_orders.id
            // return action_window
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectProject> OpenProjectVendorBillsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def action_open_project_vendor_bills(self):
            // move_lines = self.env['account.move.line'].search_fetch(
            //     [
            //         ('move_id.move_type', 'in', ['in_invoice', 'in_refund']),
            //         ('analytic_distribution', 'in', self.account_id.ids),
            //     ],
            //     ['move_id'],
            // )
            // vendor_bill_ids = move_lines.move_id.ids
            // action_window = {
            //     'name': _('Vendor Bills'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'account.move',
            //     'views': [[False, 'list'], [False, 'form'], [False, 'kanban']],
            //     'domain': [('id', 'in', vendor_bill_ids)],
            //     'context': {
            //         'default_move_type': 'in_invoice',
            //         'project_id': self.id,
            //     },
            //     'help': "<p class='o_view_nocontent_smiling_face'>%s</p><p>%s</p>" % (
            //         _("Create a vendor bill"),
            //         _("Create invoices, register payments and keep track of the discussions with your vendors."),
            //     ),
            // }
            // if not self.env.context.get('from_embedded_action') and len(vendor_bill_ids) == 1:
            //     action_window['views'] = [[False, 'form']]
            //     action_window['res_id'] = vendor_bill_ids[0]
            // return action_window
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectProject> OpenReceiptsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_stock, FILE: project_project.py) ---
            // def action_open_receipts(self):
            // self.ensure_one()
            // return self._get_picking_action(_('To WH'), 'incoming')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectProject> OpenShareProjectWizardAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_open_share_project_wizard(self):
            // template = self.env.ref('project.mail_template_project_sharing', raise_if_not_found=False)
            // 
            // local_context = self.env.context | {
            //     'default_template_id': template.id if template else False,
            //     'default_email_layout_xmlid': 'mail.mail_notification_light',
            //     'active_id': self.id,
            //     'active_model': 'project.project',
            // }
            // action = self.env["ir.actions.actions"]._for_xml_id("project.project_share_wizard_action")
            // if self.env.context.get('default_access_mode'):
            //     action['name'] = _("Share Project")
            // action['context'] = local_context
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectProject> OrderFieldToSqlInternalAsync(object @alias, object field_name, object direction, object nulls, object query)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _order_field_to_sql(self, alias, field_name, direction, nulls, query):
            // if field_name == 'is_favorite':
            //     sql_field = SQL(
            //         "%s IN (SELECT project_id FROM project_favorite_user_rel WHERE user_id = %s)",
            //         SQL.identifier(alias, 'id'), self.env.uid,
            //     )
            //     return SQL("%s %s %s", sql_field, direction, nulls)
            // 
            // return super()._order_field_to_sql(alias, field_name, direction, nulls, query)
            */
            return default;
        }

        public async Task<ProjectProject> ProfitabilityItemsAsync(Guid id, ProjectProjectProfitabilityItemsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_profitability_items(self, section_name, domain=None, res_id=False):
            // return {}
            --- ODOO METHOD SOURCE (MODULE: project_account, FILE: project_project.py) ---
            // def action_profitability_items(self, section_name, domain=None, res_id=False):
            // if section_name in ['other_revenues_aal', 'other_costs_aal', 'other_costs']:
            //     action = self.env["ir.actions.actions"]._for_xml_id("analytic.account_analytic_line_action_entries")
            //     action['domain'] = domain
            //     action['context'] = {
            //         'group_by_date': True,
            //     }
            //     if res_id:
            //         action['views'] = [(False, 'form')]
            //         action['view_mode'] = 'form'
            //         action['res_id'] = res_id
            //     else:
            //         pivot_view_id = self.env['ir.model.data']._xmlid_to_res_id('project_account.project_view_account_analytic_line_pivot')
            //         graph_view_id = self.env['ir.model.data']._xmlid_to_res_id('project_account.project_view_account_analytic_line_graph')
            //         action['views'] = [(pivot_view_id, view_type) if view_type == 'pivot' else (graph_view_id, view_type) if view_type == 'graph' else (view_id, view_type)
            //                            for (view_id, view_type) in action['views']]
            //     return action
            // 
            // if section_name == 'other_purchase_costs':
            //     action = self.env["ir.actions.actions"]._for_xml_id("account.action_move_in_invoice_type")
            //     action['domain'] = domain or []
            //     if res_id:
            //         action['views'] = [(False, 'form')]
            //         action['view_mode'] = 'form'
            //         action['res_id'] = res_id
            //     return action
            // 
            // return super().action_profitability_items(section_name, domain, res_id)
            --- ODOO METHOD SOURCE (MODULE: project_hr_expense, FILE: project_project.py) ---
            // def action_profitability_items(self, section_name, domain=None, res_id=False):
            // if section_name == 'expenses':
            //     return self._get_expense_action(domain, [res_id] if res_id else [])
            // return super().action_profitability_items(section_name, domain, res_id)
            --- ODOO METHOD SOURCE (MODULE: project_purchase, FILE: project_project.py) ---
            // def action_profitability_items(self, section_name, domain=None, res_id=False):
            // if section_name == 'purchase_order':
            //     action = {
            //         'name': self.env._('Purchase Orders'),
            //         'type': 'ir.actions.act_window',
            //         'res_model': 'purchase.order',
            //         'views': [[False, 'list'], [False, 'form']],
            //         'domain': domain,
            //         'context': {
            //             'create': False,
            //             'edit': False,
            //         },
            //     }
            //     if res_id:
            //         action['res_id'] = res_id
            //         if 'views' in action:
            //             action['views'] = [
            //                 (view_id, view_type)
            //                 for view_id, view_type in action['views']
            //                 if view_type == 'form'
            //             ] or [False, 'form']
            //         action['view_mode'] = 'form'
            //     return action
            // return super().action_profitability_items(section_name, domain, res_id)
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def action_profitability_items(self, section_name, domain=None, res_id=False):
            // if section_name in ['service_revenues', 'materials']:
            //     view_types = ['list', 'kanban', 'form']
            //     action = {
            //         'name': _('Sales Order Items'),
            //         'type': 'ir.actions.act_window',
            //         'res_model': 'sale.order.line',
            //         'context': {'create': False, 'edit': False},
            //     }
            //     if res_id:
            //         action['res_id'] = res_id
            //         view_types = ['form']
            //     else:
            //         action['domain'] = domain
            //     action['views'] = [(False, v) for v in view_types]
            //     return action
            // 
            // if section_name in ['other_invoice_revenues', 'downpayments']:
            //     action = self.env["ir.actions.actions"]._for_xml_id("account.action_move_out_invoice_type")
            //     action['domain'] = domain if domain else []
            //     action['context'] = {
            //         **ast.literal_eval(action['context']),
            //         'default_partner_id': self.partner_id.id,
            //         'project_id': self.id,
            //     }
            //     if res_id:
            //         action['views'] = [(False, 'form')]
            //         action['view_mode'] = 'form'
            //         action['res_id'] = res_id
            //     return action
            // 
            // if section_name == 'cost_of_goods_sold':
            //     action = {
            //         'name': _('Cost of Goods Sold Items'),
            //         'type': 'ir.actions.act_window',
            //         'res_model': 'account.move.line',
            //         'views': [[False, 'list'], [False, 'form']],
            //         'domain': [('move_id', '=', res_id), ('display_type', '=', 'cogs')],
            //         'context': {'create': False, 'edit': False},
            //     }
            //     return action
            // 
            // return super().action_profitability_items(section_name, domain, res_id)
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def action_profitability_items(self, section_name, domain=None, res_id=False):
            // self.ensure_one()
            // if section_name in ['billable_fixed', 'billable_time', 'billable_milestones', 'billable_manual', 'non_billable']:
            //     action = self.action_billable_time_button()
            //     if domain:
            //         action['domain'] = Domain.AND([[('project_id', '=', self.id)], domain])
            //     action['context'].update(search_default_groupby_timesheet_invoice_type=False, **self.env.context)
            //     graph_view = False
            //     if section_name == 'billable_time':
            //         graph_view = self.env.ref('sale_timesheet.view_hr_timesheet_line_graph_invoice_employee').id
            //     action['views'] = [
            //         (view_id, view_type) if view_type != 'graph' else (graph_view or view_id, view_type)
            //         for view_id, view_type in action['views']
            //     ]
            //     if res_id:
            //         if 'views' in action:
            //             action['views'] = [
            //                 (view_id, view_type)
            //                 for view_id, view_type in action['views']
            //                 if view_type == 'form'
            //             ] or [False, 'form']
            //         action['view_mode'] = 'form'
            //         action['res_id'] = res_id
            //     return action
            // return super().action_profitability_items(section_name, domain, res_id)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectProject> ProjectTaskBurndownChartReportAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_project_task_burndown_chart_report(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('project.action_project_task_burndown_chart_report')
            // action['display_name'] = _("%(name)s's Burndown Chart", name=self.name)
            // context = action['context'].replace('active_id', str(self.id))
            // context = ast.literal_eval(context)
            // context.update({
            //     'stage_name_and_sequence_per_id': {
            //         stage.id: {
            //             'sequence': stage.sequence,
            //             'name': stage.name
            //         } for stage in self.type_ids
            //     }
            // })
            // action['context'] = context
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectProject> ProjectTimesheetsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py) ---
            // def action_project_timesheets(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('hr_timesheet.act_hr_timesheet_line_by_project')
            // if not self.env.context.get('from_embedded_action'):
            //     action['display_name'] = _("%(name)s's Timesheets", name=self.name)
            // return action
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def action_project_timesheets(self):
            // action = super().action_project_timesheets()
            // if not self.allow_billable:
            //     context = action['context'].replace('active_id', str(self.id))
            //     action['context'] = {
            //         **ast.literal_eval(context),
            //         'hide_so_line': True,
            //     }
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectProject> ProjectUpdateAllActionAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def project_update_all_action(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('project.project_update_all_action')
            // action['display_name'] = _("%(name)s Dashboard", name=self.name)
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectProject> SearchIsFavoriteInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _search_is_favorite(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // return [('favorite_user_ids', 'in', [self.env.uid])]
            */
            return default;
        }

        protected async Task<ProjectProject> SearchIsInternalProjectInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py) ---
            // def _search_is_internal_project(self, operator, value):
            // if operator not in ('in', 'not in'):
            //     return NotImplemented
            // 
            // Company = self.env['res.company']
            // sql = Company._search(
            //     [('internal_project_id', '!=', False)],
            //     active_test=False, bypass_access=True,
            // ).subselect("internal_project_id")
            // return [('id', operator, sql)]
            */
            return default;
        }

        protected async Task<ProjectProject> SearchIsMilestoneExceededInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _search_is_milestone_exceeded(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // 
            // sql = SQL("""(
            //     SELECT P.id
            //       FROM project_project P
            //  LEFT JOIN project_milestone M ON P.id = M.project_id
            //      WHERE M.is_reached IS false
            //        AND P.allow_milestones IS true
            //        AND M.deadline <= CAST(now() AS date)
            // )""")
            // return [('id', 'any', sql)]
            */
            return default;
        }

        protected async Task<ProjectProject> SearchIsProjectOvertimeInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py) ---
            // def _search_is_project_overtime(self, operator, value):
            // if operator not in ('in', 'not in'):
            //     return NotImplemented
            // 
            // sql = SQL("""(
            //     SELECT Project.id
            //       FROM project_project AS Project
            //       JOIN project_task AS Task
            //         ON Project.id = Task.project_id
            //      WHERE Project.allocated_hours > 0
            //        AND Project.allow_timesheets = TRUE
            //        AND Task.parent_id IS NULL
            //        AND Task.state IN ('01_in_progress', '02_changes_requested', '03_approved', '04_waiting_normal')
            //   GROUP BY Project.id
            //     HAVING Project.allocated_hours - SUM(Task.effective_hours) < 0
            // )""")
            // return [('id', operator, sql)]
            */
            return default;
        }

        protected async Task<ProjectProject> SearchPricingTypeInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def _search_pricing_type(self, operator, value):
            // """ Search method for pricing_type field.
            // 
            //     :param operator: the supported operator is either '=' or '!='.
            //     :param value: the value than the field should be is among these values into the following tuple: (False, 'task_rate', 'fixed_rate', 'employee_rate').
            // 
            //     :returns: the domain to find the expected projects.
            // """
            // if operator != 'in':
            //     return NotImplemented
            // domains = []
            // if 'task_rate' in value:
            //     domains.append([('sale_line_employee_ids', '=', False), ('sale_line_id', '=', False), ('allow_billable', '=', True)])
            // if 'fixed_rate' in value:
            //     domains.append([('sale_line_employee_ids', '=', False), ('sale_line_id', '!=', False), ('allow_billable', '=', True)])
            // if 'employee_rate' in value:
            //     domains.append([('sale_line_employee_ids', '!=', False), ('allow_billable', '=', True)])
            // if False in value:
            //     domains.append([('allow_billable', '=', False)])
            // return Domain.OR(domains)
            */
            return default;
        }

        protected async Task<ProjectProject> SendSmsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_sms, FILE: project_project.py) ---
            // def _send_sms(self):
            // for project in self.sudo():
            //     if project.partner_id and project.stage_id and project.stage_id.sms_template_id:
            //         project.with_env(self.env)._message_sms_with_template(
            //             template=project.stage_id.sms_template_id,
            //             partner_ids=project.partner_id.ids,
            //         )
            */
            return default;
        }

        protected async Task<ProjectProject> SetFavoriteUserIdsInternalAsync(object is_favorite)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _set_favorite_user_ids(self, is_favorite):
            // self_sudo = self.sudo() # To allow project users to set projects as favorite
            // if is_favorite:
            //     self_sudo.favorite_user_ids = [Command.link(self.env.uid)]
            // else:
            //     self_sudo.favorite_user_ids = [Command.unlink(self.env.uid)]
            */
            return default;
        }

        protected async Task<ProjectProject> ShowProfitabilityHelperInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _show_profitability_helper(self):
            // return self.env.user.has_group('analytic.group_analytic_accounting')
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _show_profitability_helper(self):
            // return True
            */
            return default;
        }

        protected async Task<ProjectProject> ShowProfitabilityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _show_profitability(self):
            // self.ensure_one()
            // return True
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def _show_profitability(self):
            // self.ensure_one()
            // return self.allow_billable and super()._show_profitability()
            */
            return default;
        }

        public async Task<ProjectProject> TemplateToProjectConfirmationCallbackAsync(Guid id, ProjectProjectTemplateToProjectConfirmationCallbackRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def template_to_project_confirmation_callback(self, callbacks):
            // self.ensure_one()
            // pass
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def template_to_project_confirmation_callback(self, callbacks):
            // super().template_to_project_confirmation_callback(callbacks)
            // if callbacks.get('unlink_template_products'):
            //     self._fetch_products_linked_to_template().project_template_id = False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectProject> ThreadToStoreInternalAsync(object store, object fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _thread_to_store(self, store: Store, fields, *, request_list=None):
            // super()._thread_to_store(store, fields, request_list=request_list)
            // if request_list and "followers" in request_list:
            //     store.add(
            //         self,
            //         {"collaborator_ids": Store.Many(self.collaborator_ids.partner_id, [])},
            //         as_thread=True,
            //     )
            */
            return default;
        }

        public async Task<ProjectProject> ToggleFavoriteAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def toggle_favorite(self):
            // favorite_projects = not_fav_projects = self.env['project.project'].sudo()
            // for project in self:
            //     if self.env.user in project.favorite_user_ids:
            //         favorite_projects |= project
            //     else:
            //         not_fav_projects |= project
            // 
            // # Project User has no write access for project.
            // not_fav_projects.write({'favorite_user_ids': [(4, self.env.uid)]})
            // favorite_projects.write({'favorite_user_ids': [(3, self.env.uid)]})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectProject> ToggleProjectTemplateModeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_toggle_project_template_mode(self):
            // self.ensure_one()
            // config = {
            //     "params": {
            //         "project_id": self.id,
            //     },
            // }
            // if self.is_template:
            //     config["tag"] = "project_template_show_undo_confirmation_dialog"
            //     if callbacks := self._get_template_to_project_confirmation_callbacks():
            //         config["params"]["callback_data"] = {
            //             "method": "template_to_project_confirmation_callback",
            //             "args": [self.id, callbacks],
            //         }
            //     if warning_messages := self._get_template_to_project_warnings():
            //         config["params"]["message"] = self.env._(
            //             "%(warning_messages)s\nAre you sure you want to continue?",
            //             warning_messages="\n".join(warning_messages),
            //         )
            //     else:
            //         config["params"]["message"] = self.env._(
            //             "This project is currently a template. Would you like to convert it back into a regular project?",
            //         )
            // else:
            //     config["tag"] = "project_to_template_redirection_action"
            // return {
            //     "type": "ir.actions.client",
            //     **config,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectProject> ToggleTemplateModeInternalAsync(object is_template)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py) ---
            // def _toggle_template_mode(self, is_template):
            // if not is_template and self.allow_timesheets and not self.account_id:
            //     self._create_analytic_account()
            // super()._toggle_template_mode(is_template)
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _toggle_template_mode(self, is_template):
            // self.ensure_one()
            // self.is_template = is_template
            // if not is_template:
            //     self.task_ids.role_ids = False
            */
            return default;
        }

        protected async Task<ProjectProject> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // if 'stage_id' in init_values:
            //     return self.env.ref('project.mt_project_stage_change')
            // return super()._track_subtype(init_values)
            */
            return default;
        }

        protected async Task<ProjectProject> TrackTemplateInternalAsync(object changes)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _track_template(self, changes):
            // res = super()._track_template(changes)
            // project = self[0]
            // if self.env.user.has_group('project.group_project_stages') and 'stage_id' in changes and project.stage_id.mail_template_id:
            //     res['stage_id'] = (project.stage_id.mail_template_id, {
            //         'auto_delete_keep_log': False,
            //         'subtype_id': self.env['ir.model.data']._xmlid_to_res_id('mail.mt_note'),
            //         'email_layout_xmlid': 'mail.mail_notification_light',
            //     })
            // return res
            */
            return default;
        }

        public async Task<ProjectProject> UndoConvertToTemplateAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_undo_convert_to_template(self):
            // self.ensure_one()
            // self._toggle_template_mode(False)
            // self.message_post(body=self.env._("Template converted back to regular project."))
            // return {
            //     "type": "ir.actions.client",
            //     "tag": "display_notification",
            //     "params": {
            //         "message": self.env._("Template converted back to regular project."),
            //         "next": {
            //             "type": "ir.actions.client",
            //             "tag": "soft_reload",
            //         },
            //     },
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectProject> UnlinkExceptContainsEntriesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py) ---
            // def _unlink_except_contains_entries(self):
            // """
            // If some projects to unlink have some timesheets entries, these
            // timesheets entries must be unlinked first.
            // In this case, a warning message is displayed through a RedirectWarning
            // and allows the user to see timesheets entries to unlink.
            // """
            // projects_with_timesheets = self.filtered(lambda p: p.timesheet_ids)
            // if projects_with_timesheets:
            //     if len(projects_with_timesheets) > 1:
            //         warning_msg = _("These projects have some timesheet entries referencing them. Before removing these projects, you have to remove these timesheet entries.")
            //     else:
            //         warning_msg = _("This project has some timesheet entries referencing it. Before removing this project, you have to remove these timesheet entries.")
            //     raise RedirectWarning(
            //         warning_msg, self.env.ref('hr_timesheet.timesheet_action_project').id,
            //         _('See timesheet entries'), {'active_ids': projects_with_timesheets.ids})
            */
            return default;
        }

        protected async Task<ProjectProject> UpdateTimesheetsSaleLineIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def _update_timesheets_sale_line_id(self):
            // for project in self.filtered(lambda p: p.allow_billable and p.allow_timesheets):
            //     timesheet_ids = project.mapped('timesheet_ids').filtered(lambda t: not t.is_so_line_edited and t._is_updatable_timesheet())
            //     if not timesheet_ids:
            //         continue
            //     for employee_id in project.sale_line_employee_ids.filtered(lambda l: l.project_id == project).employee_id:
            //         sale_line_id = project.sale_line_employee_ids.filtered(lambda l: l.project_id == project and l.employee_id == employee_id).sale_line_id
            //         timesheet_ids.filtered(lambda t: t.employee_id == employee_id).sudo().so_line = sale_line_id
            */
            return default;
        }

        public async Task<ProjectProject> ViewAllRatingAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_view_all_rating(self):
            // """ return the action to see all the rating of the project and activate default filters"""
            // action = self.env['ir.actions.act_window']._for_xml_id('project.rating_rating_action_view_project_rating')
            // action['display_name'] = _("%(name)s's Rating", name=self.name)
            // action_context = ast.literal_eval(action['context']) if action['context'] else {}
            // action_context.update(self.env.context)
            // action_context['search_default_filter_write_date'] = 'custom_write_date_last_30_days'
            // action_context.pop('group_by', None)
            // action['domain'] = [('consumed', '=', True), ('parent_res_model', '=', 'project.project'), ('parent_res_id', '=', self.id)]
            // if self.rating_count == 1:
            //     action.update({
            //         'view_mode': 'form',
            //         'views': [(view_id, view_type) for view_id, view_type in action['views'] if view_type == 'form'],
            //         'res_id': self.rating_ids[0].id, # [0] since rating_ids might be > then rating_count
            //     })
            // return dict(action, context=action_context)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectProject> ViewMrpBomAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_mrp, FILE: project_project.py) ---
            // def action_view_mrp_bom(self):
            // self.ensure_one()
            // action = {
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'mrp.bom',
            //     'domain': [('project_id', '=', self.id)],
            //     'name': self.env._('Bills of Materials'),
            //     'view_mode': 'list,kanban,form',
            //     'context': {'default_project_id': self.id},
            //     'help': "<p class='o_view_nocontent_smiling_face'>%s</p><p>%s</p>" % (
            //         _("No bill of materials found. Let's create one."),
            //         _("Bills of materials allow you to define the list of required raw materials used to make a finished "
            //             "product; through a manufacturing order or a pack of products."),
            //     ),
            // }
            // boms = self.env['mrp.bom'].search([('project_id', '=', self.id)])
            // if not self.env.context.get('from_embedded_action', False) and len(boms) == 1:
            //     action['views'] = [[False, 'form']]
            //     action['res_id'] = boms.id
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectProject> ViewMrpProductionAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_mrp, FILE: project_project.py) ---
            // def action_view_mrp_production(self):
            // self.ensure_one()
            // action = self.env['ir.actions.actions']._for_xml_id('mrp.mrp_production_action')
            // action['domain'] = [('project_id', '=', self.id)]
            // action['context'] = {'default_project_id': self.id, 'from_project_action': True}
            // productions = self.env['mrp.production'].search([('project_id', '=', self.id)])
            // if not self.env.context.get('from_embedded_action', False) and len(productions) == 1:
            //     action['views'] = [[False, 'form']]
            //     action['res_id'] = productions.id
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectProject> ViewSolsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def action_view_sols(self):
            // self.ensure_one()
            // all_sale_order_lines = self._fetch_sale_order_items({'project.task': [('is_closed', '=', False)]})
            // action_window = {
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'sale.order.line',
            //     'name': _("%(name)s's Sales Order Items", name=self.name),
            //     'context': {
            //         'show_sale': True,
            //         'link_to_project': self.id,
            //         'form_view_ref': 'sale_project.sale_order_line_view_form_editable',  # Necessary for some logic in the form view
            //         'action_view_sols': True,
            //         'default_partner_id': self.partner_id.id,
            //         'default_company_id': self.company_id.id,
            //         'default_order_id': self.sale_order_id.id,
            //     },
            //     'views': [(self.env.ref('sale_project.sale_order_line_view_form_editable').id, 'form')],
            // }
            // if len(all_sale_order_lines) <= 1:
            //     action_window['res_id'] = all_sale_order_lines.id
            // else:
            //     action_window.update({
            //         'domain': [('id', 'in', all_sale_order_lines.ids)],
            //         'views': [
            //             (self.env.ref('sale_project.view_order_line_tree_with_create').id, 'list'),
            //             (self.env.ref('sale_project.sale_order_line_view_form_editable').id, 'form'),
            //         ],
            //     })
            // return action_window
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectProject> ViewSosAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def action_view_sos(self):
            // self.ensure_one()
            // all_sale_orders = self._fetch_sale_order_items({'project.task': [('is_closed', '=', False)]}).sudo().order_id
            // embedded_action_context = self.env.context.get('from_embedded_action', False)
            // action_window = self._get_view_action()
            // action_window["display_name"] = self.env._("%(name)s's %(action_name)s", name=self.name, action_name=action_window.get('name'))
            // action_window["domain"] = self._get_sale_orders_domain(all_sale_orders)
            // action_window['context'] = {
            //     **ast.literal_eval(action_window['context']),
            //     "create": self.env.context.get("create_for_project_id", embedded_action_context),
            //     "show_sale": True,
            //     "default_partner_id": self.partner_id.id,
            //     "default_project_id": self.id,
            //     "create_for_project_id": self.id if not embedded_action_context else False,
            //     "from_embedded_action": embedded_action_context,
            // }
            // if len(all_sale_orders) <= 1 and not embedded_action_context:
            //     action_window.update({
            //         "res_id": all_sale_orders.id,
            //         "views": [[False, "form"]],
            //     })
            // return action_window
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectProject> ViewTasksAnalysisAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_view_tasks_analysis(self):
            // """ return the action to see the tasks analysis report of the project """
            // action = self.env['ir.actions.act_window']._for_xml_id('project.action_project_task_user_tree')
            // action['display_name'] = _("%(name)s's Tasks Analysis", name=self.name)
            // action_context = ast.literal_eval(action['context']) if action['context'] else {}
            // action_context['search_default_project_id'] = self.id
            // return dict(action, context=action_context)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectProject> ViewTasksAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py) ---
            // def action_view_tasks(self):
            // # Using the timesheet filter hide context
            // action = super().action_view_tasks()
            // action['context']['allow_timesheets'] = self.allow_timesheets
            // return action
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_view_tasks(self):
            // action = self.env['ir.actions.act_window'].with_context(active_id=self.id)._for_xml_id('project.act_project_project_2_project_task_all')
            // action['display_name'] = self.name
            // context = action['context'].replace('active_id', str(self.id))
            // context = ast.literal_eval(context)
            // context.update({
            //     'create': self.active,
            //     'active_test': self.active,
            //     'active_id': self.id,
            //     'allow_milestones': self.allow_milestones,
            //     'allow_task_dependencies': self.allow_task_dependencies,
            //     })
            // action['context'] = context
            // if self.is_template:
            //     action['context'].update({'template_project': True})
            //     action['views'] = [(view_id, view_type) for view_id, view_type in action['views'] if view_type not in ('pivot', 'graph')]
            // return action
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def action_view_tasks(self):
            // if self.env.context.get('generate_milestone'):
            //     line_id = self.env.context.get('default_sale_line_id')
            //     default_line = self.env['sale.order.line'].browse(line_id)
            //     milestone = self.env['project.milestone'].create({
            //         'name': default_line.name,
            //         'project_id': self.id,
            //         'sale_line_id': line_id,
            //         'quantity_percentage': 1,
            //     })
            //     if default_line.product_id.service_tracking == 'task_in_project':
            //         default_line.task_id.milestone_id = milestone.id
            // 
            // action = super().action_view_tasks()
            // action['context']['hide_partner'] = self._get_hide_partner()
            // action['context']['allow_billable'] = self.allow_billable
            // if self.env.context.get("from_sale_order_action"):
            //     context = dict(action.get("context", {}))
            //     context.pop("search_default_open_tasks", None)
            //     if sale_order_id := self.env.context.get('default_reinvoiced_sale_order_id') or self.reinvoiced_sale_order_id.id:
            //         context["search_default_sale_order_id"] = sale_order_id
            //     if not self.sale_order_id:
            //         sale_order = self.env["sale.order"].browse(self.env.context.get("active_id"))
            //         context["default_sale_order_id"] = sale_order.id
            //     action["context"] = context
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectProject> ViewTasksFromProjectMilestoneAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_view_tasks_from_project_milestone(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('project.project_milestone_action_view_tasks')
            // action['display_name'] = _("Tasks")
            // action['domain'] = [('milestone_id', 'in', self.milestone_ids.ids)]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectProject> ViewTimesheetAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def action_view_timesheet(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Timesheets of %s', self.name),
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

        public override async Task<List<object>> WriteAsync(List<Guid> ids, ProjectProject entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py) ---
            // def write(self, vals):
            // # create the AA for project still allowing timesheet
            // if vals.get('allow_timesheets') and not vals.get('account_id'):
            //     project_wo_account = self.filtered(lambda project: not project.account_id and not project.is_template)
            //     if project_wo_account:
            //         project_wo_account._create_analytic_account()
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def write(self, vals):
            // if vals.get('access_token'):
            //     self.ensure_one()  # We are not supposed to add a single access token to multiple project
            //     if self.privacy_visibility not in ['invited_users', 'portal']:
            //         vals['access_token'] = ''
            // 
            // # Here we modify the project's stage according to the selected company (selecting the first
            // # stage in sequence that is linked to the company).
            // company_id = vals.get('company_id')
            // if self.env.user.has_group('project.group_project_stages') and company_id:
            //     projects_already_with_company = self.filtered(lambda p: p.company_id.id == company_id)
            //     if projects_already_with_company:
            //         projects_already_with_company.write({key: value for key, value in vals.items() if key != 'company_id'})
            //         self -= projects_already_with_company
            //     if company_id not in (None, *self.company_id.ids) and self.stage_id.company_id:
            //         ProjectStage = self.env['project.project.stage']
            //         vals["stage_id"] = ProjectStage.search(
            //             [('company_id', 'in', (company_id, False))],
            //             order=f"sequence asc, {ProjectStage._order}",
            //             limit=1,
            //         ).id
            // 
            // # directly compute is_favorite to dodge allow write access right
            // if 'is_favorite' in vals:
            //     self._set_favorite_user_ids(vals.pop('is_favorite'))
            // 
            // if 'last_update_status' in vals and vals['last_update_status'] != 'to_define':
            //     for project in self:
            //         # This does not benefit from multi create, this is to allow the default description from being built.
            //         # This does seem ok since last_update_status should only be updated on one record at once.
            //         self.env['project.update'].with_context(default_project_id=project.id).create({
            //             'name': _('Status Update - %(date)s', date=fields.Date.today().strftime(get_lang(self.env).date_format)),
            //             'status': vals.get('last_update_status'),
            //         })
            //     vals.pop('last_update_status')
            // if vals.get('privacy_visibility'):
            //     self._change_privacy_visibility(vals['privacy_visibility'])
            // 
            // date_start = vals.get('date_start', True)
            // date_end = vals.get('date', True)
            // if not date_start or not date_end:
            //     vals['date_start'] = False
            //     vals['date'] = False
            // else:
            //     no_current_date_begin = not all(project.date_start for project in self)
            //     no_current_date_end = not all(project.date for project in self)
            //     date_start_update = 'date_start' in vals
            //     date_end_update = 'date' in vals
            //     if (date_start_update and no_current_date_end and not date_end_update):
            //         del vals['date_start']
            //     elif (date_end_update and no_current_date_begin and not date_start_update):
            //         del vals['date']
            // 
            // res = super().write(vals) if vals else True
            // 
            // if 'allow_task_dependencies' in vals and not vals.get('allow_task_dependencies'):
            //     self.env['project.task'].search([('project_id', 'in', self.ids), ('state', '=', '04_waiting_normal')]).write({'state': '01_in_progress'})
            // 
            // if 'allow_recurring_tasks' in vals and not vals['allow_recurring_tasks']:
            //     self.env['project.task'].search([('project_id', 'in', self.ids), ('recurring_task', '=', True)]).write({'recurring_task': False})
            // 
            // if 'active' in vals:
            //     # archiving/unarchiving a project does it on its tasks, too
            //     self.with_context(active_test=False).mapped('tasks').write({'active': vals['active']})
            // if 'name' in vals and self.account_id:
            //     projects_read_group = self.env['project.project']._read_group(
            //         [('account_id', 'in', self.account_id.ids)],
            //         ['account_id'],
            //         having=[('__count', '=', 1)],
            //     )
            //     analytic_account_to_update = self.env['account.analytic.account'].browse([
            //         analytic_account.id for [analytic_account] in projects_read_group
            //     ])
            //     analytic_account_to_update.write({'name': self.name})
            // return res
            --- ODOO METHOD SOURCE (MODULE: project_sms, FILE: project_project.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // if 'stage_id' in vals:
            //     self._send_sms()
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_project.py) ---
            // def write(self, vals):
            // project = super().write(vals)
            // if sol_id := vals.get('sale_line_id'):
            //     self._ensure_sale_order_linked([sol_id])
            // return project
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // if 'allow_billable' in vals and not vals.get('allow_billable'):
            //     self.task_ids._get_timesheet().write({
            //         'so_line': False,
            //     })
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }

        private async Task<ProjectProject> _ComputeTaskCountInternalAsync(object count_field, object additional_domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def __compute_task_count(self, count_field='task_count', additional_domain=None):
            // count_fields = {fname for fname in self._fields if 'count' in fname}
            // if count_field not in count_fields:
            //     raise ValueError(f"Parameter 'count_field' can only be one of {count_fields}, got {count_field} instead.")
            // domain = Domain('project_id', 'in', self.ids) & Domain('is_template', '=', False)
            // if additional_domain:
            //     domain &= Domain(additional_domain)
            // ProjectTask = self.env['project.task'].with_context(active_test=any(project.active for project in self))
            // tasks_count_by_project = dict(ProjectTask._read_group(domain, ['project_id'], ['__count']))
            // for project in self:
            //     project.update({count_field: tasks_count_by_project.get(project, 0)})
            */
            return default;
        }
    }
}