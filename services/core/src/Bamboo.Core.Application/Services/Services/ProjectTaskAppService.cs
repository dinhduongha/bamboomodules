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
    public partial class ProjectTaskAppService : GenericApplicationService<ProjectTask>, IProjectTaskAppService
    {
        private readonly IHtmlFieldHistoryMixinAppService _htmlFieldHistoryMixinAppService;
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadCcAppService _mailThreadCcAppService;
        private readonly IMailTrackingDurationMixinAppService _mailTrackingDurationMixinAppService;
        private readonly IPortalMixinAppService _portalMixinAppService;
        private readonly IRatingMixinAppService _ratingMixinAppService;
        public ProjectTaskAppService(IRepository<ProjectTask, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IHtmlFieldHistoryMixinAppService htmlFieldHistoryMixinAppService, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadCcAppService mailThreadCcAppService, IMailTrackingDurationMixinAppService mailTrackingDurationMixinAppService, IPortalMixinAppService portalMixinAppService, IRatingMixinAppService ratingMixinAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
            _htmlFieldHistoryMixinAppService = htmlFieldHistoryMixinAppService;
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadCcAppService = mailThreadCcAppService;
            _mailTrackingDurationMixinAppService = mailTrackingDurationMixinAppService;
            _portalMixinAppService = portalMixinAppService;
            _ratingMixinAppService = ratingMixinAppService;
        }

        public async Task<ProjectTask> ArchiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_archive(self):
            // child_tasks = self.child_ids.filtered(lambda child_task: not child_task.display_in_project)
            // if child_tasks:
            //     child_tasks.action_archive()
            // return super().action_archive()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectTask> CheckNoCyclicDependenciesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _check_no_cyclic_dependencies(self):
            // if self._has_cycle('depend_on_ids'):
            //     raise ValidationError(_("Two tasks cannot depend on each other."))
            */
            return default;
        }

        protected async Task<ProjectTask> CheckParentIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _check_parent_id(self):
            // if self._has_cycle():
            //     raise ValidationError(_('Error! You cannot create a recursive hierarchy of tasks.'))
            */
            return default;
        }

        protected async Task<ProjectTask> CheckProjectRootInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py) ---
            // def _check_project_root(self):
            // private_tasks = self.filtered(lambda t: not t.project_id)
            // if private_tasks and self.env['account.analytic.line'].sudo().search_count([('task_id', 'in', private_tasks.ids)], limit=1):
            //     raise UserError(_("This task cannot be private because there are some timesheets linked to it."))
            */
            return default;
        }

        protected async Task<ProjectTask> CheckSaleLineTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_task.py) ---
            // def _check_sale_line_type(self):
            // for task in self.sudo():
            //     if task.sale_line_id:
            //         if not task.sale_line_id.is_service or task.sale_line_id.is_expense:
            //             raise ValidationError(_(
            //                 'You cannot link the order item %(order_id)s - %(product_id)s to this task because it is a re-invoiced expense.',
            //                 order_id=task.sale_line_id.order_id.name,
            //                 product_id=task.sale_line_id.product_id.display_name,
            //             ))
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeAccessUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_access_url(self):
            // super()._compute_access_url()
            // for task in self:
            //     task.access_url = f'/my/tasks/{task.id}'
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeAllowTimesheetsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py) ---
            // def _compute_allow_timesheets(self):
            // for task in self:
            //     task.allow_timesheets = task.project_id.allow_timesheets
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeAttachmentIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_attachment_ids(self):
            // for task in self:
            //     attachment_ids = self.env['ir.attachment'].search(task._get_attachments_search_domain()).ids
            //     message_attachment_ids = task.mapped('message_ids.attachment_ids').ids  # from mail_thread
            //     task.attachment_ids = [(6, 0, list(set(attachment_ids) - set(message_attachment_ids)))]
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeCompanyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_company_id(self):
            // for task in self:
            //     if not task.parent_id and not task.project_id:
            //         continue
            //     task.company_id = task.project_id.company_id or task.parent_id.company_id
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeCurrentUserSameCompanyPartnerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_current_user_same_company_partner(self):
            // commercial_partner_id = self.env.user.partner_id.commercial_partner_id
            // for task in self:
            //     task.current_user_same_company_partner = task.partner_id and commercial_partner_id == task.partner_id.commercial_partner_id
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeDependOnCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_depend_on_count(self):
            // tasks_with_dependency = self.filtered('allow_task_dependencies')
            // tasks_without_dependency = self - tasks_with_dependency
            // tasks_without_dependency.depend_on_count = 0
            // tasks_without_dependency.closed_depend_on_count = 0
            // if not any(self._ids):
            //     for task in self:
            //         task.depend_on_count = len(task.depend_on_ids)
            //         task.closed_depend_on_count = len(task.depend_on_ids.filtered(lambda r: r.state in CLOSED_STATES))
            //     return
            // if tasks_with_dependency:
            //     # need the sudo for project sharing
            //     total_and_closed_depend_on_count = {
            //         dependent_on.id: (count, sum(s in CLOSED_STATES for s in states))
            //         for dependent_on, states, count in self.env['project.task']._read_group(
            //             [('dependent_ids', 'in', tasks_with_dependency.ids)],
            //             ['dependent_ids'],
            //             ['state:array_agg', '__count'],
            //         )
            //     }
            //     for task in tasks_with_dependency:
            //         task.depend_on_count, task.closed_depend_on_count = total_and_closed_depend_on_count.get(task._origin.id or task.id, (0, 0))
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeDependentTasksCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_dependent_tasks_count(self):
            // tasks_with_dependency = self.filtered('allow_task_dependencies')
            // (self - tasks_with_dependency).dependent_tasks_count = 0
            // if tasks_with_dependency:
            //     group_dependent = self.env['project.task']._read_group([
            //         ('depend_on_ids', 'in', tasks_with_dependency.ids),
            //         ('is_closed', '=', False),
            //     ], ['depend_on_ids'], ['__count'])
            //     dependent_tasks_count_dict = {
            //         depend_on.id: count
            //         for depend_on, count in group_dependent
            //     }
            //     for task in tasks_with_dependency:
            //         task.dependent_tasks_count = dependent_tasks_count_dict.get(task.id, 0)
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeDisplayFollowButtonInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_display_follow_button(self):
            // if not self.env.user.share:
            //     self.display_follow_button = False
            //     return
            // project_collaborator_read_group = self.env['project.collaborator']._read_group(
            //     [('project_id', 'in', self.project_id.ids), ('partner_id', '=', self.env.user.partner_id.id)],
            //     ['project_id'],
            //     ['limited_access:bool_and'],
            // )
            // limited_access_per_project_id = dict(project_collaborator_read_group)
            // for task in self:
            //     task.display_follow_button = not limited_access_per_project_id.get(task.project_id, True)
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeDisplayInProjectInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_display_in_project(self):
            // for record in self:
            //     record.display_in_project = not record.project_id or (
            //             not record.parent_id or record.project_id != record.parent_id.project_id
            //     )
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py) ---
            // def _compute_display_name(self):
            // super()._compute_display_name()
            // if self.env.context.get('hr_timesheet_display_remaining_hours'):
            //     for task in self:
            //         if task.allow_timesheets and task.allocated_hours > 0 and task.encode_uom_in_days:
            //             days_left = _("(%s days remaining)", task._convert_hours_to_days(task.remaining_hours))
            //             task.display_name = task.display_name + "\u00A0" + days_left
            //         elif task.allow_timesheets and task.allocated_hours > 0:
            //             hours, mins = (str(int(duration)).rjust(2, '0') for duration in divmod(abs(task.remaining_hours) * 60, 60))
            //             hours_left = _(
            //                 "(%(sign)s%(hours)s:%(minutes)s remaining)",
            //                 sign='-' if task.remaining_hours < 0 else '',
            //                 hours=hours,
            //                 minutes=mins,
            //             )
            //             task.display_name = task.display_name + "\u00A0" + hours_left
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeDisplayParentTaskButtonInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_display_parent_task_button(self):
            // accessible_parent_tasks = self.parent_id.with_user(self.env.user)._filtered_access('read')
            // for task in self:
            //     task.display_parent_task_button = task.parent_id in accessible_parent_tasks
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeDisplaySaleOrderButtonInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_task.py) ---
            // def _compute_display_sale_order_button(self):
            // if not self.sale_order_id:
            //     self.display_sale_order_button = False
            //     return
            // try:
            //     sale_orders = self.env['sale.order'].search([('id', 'in', self.sale_order_id.ids)])
            //     for task in self:
            //         task.display_sale_order_button = task.sale_order_id in sale_orders
            // except AccessError:
            //     self.display_sale_order_button = False
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeEffectiveHoursInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py) ---
            // def _compute_effective_hours(self):
            // if not any(self._ids):
            //     for task in self:
            //         task.effective_hours = sum(task.timesheet_ids.mapped('unit_amount'))
            //     return
            // timesheet_read_group = self.env['account.analytic.line']._read_group([('task_id', 'in', self.ids)], ['task_id'], ['unit_amount:sum'])
            // timesheets_per_task = {task.id: amount for task, amount in timesheet_read_group}
            // for task in self:
            //     task.effective_hours = timesheets_per_task.get(task.id, 0.0)
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeElapsedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_elapsed(self):
            // task_linked_to_calendar = self.filtered(
            //     lambda task: task.project_id.resource_calendar_id and task.create_date
            // )
            // for task in task_linked_to_calendar:
            //     dt_create_date = fields.Datetime.from_string(task.create_date)
            // 
            //     if task.date_assign:
            //         dt_date_assign = fields.Datetime.from_string(task.date_assign)
            //         duration_data = task.project_id.resource_calendar_id.get_work_duration_data(dt_create_date, dt_date_assign, compute_leaves=True)
            //         task.working_hours_open = duration_data['hours']
            //         task.working_days_open = duration_data['days']
            //     else:
            //         task.working_hours_open = 0.0
            //         task.working_days_open = 0.0
            // 
            //     if task.date_end:
            //         dt_date_end = fields.Datetime.from_string(task.date_end)
            //         duration_data = task.project_id.resource_calendar_id.get_work_duration_data(dt_create_date, dt_date_end, compute_leaves=True)
            //         task.working_hours_close = duration_data['hours']
            //         task.working_days_close = duration_data['days']
            //     else:
            //         task.working_hours_close = 0.0
            //         task.working_days_close = 0.0
            // 
            // (self - task_linked_to_calendar).update(dict.fromkeys(
            //     ['working_hours_open', 'working_hours_close', 'working_days_open', 'working_days_close'], 0.0))
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeEncodeUomInDaysInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py) ---
            // def _compute_encode_uom_in_days(self):
            // self.encode_uom_in_days = self._uom_in_days()
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeHasLateAndUnreachedMilestoneInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_has_late_and_unreached_milestone(self):
            // if all(not task.allow_milestones for task in self):
            //     self.has_late_and_unreached_milestone = False
            //     return
            // late_milestones = self.env['project.milestone'].sudo()._search([  # sudo is needed for the portal user in Project Sharing.
            //     ('id', 'in', self.milestone_id.ids),
            //     ('is_reached', '=', False),
            //     ('deadline', '<=', fields.Date.today()),
            // ])
            // for task in self:
            //     task.has_late_and_unreached_milestone = task.allow_milestones and task.milestone_id.id in late_milestones
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeHasMultiSolInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_task.py) ---
            // def _compute_has_multi_sol(self):
            // for task in self:
            //     task.has_multi_sol = task.timesheet_ids and task.timesheet_ids.so_line != task.sale_line_id
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeHasTemplateAncestorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_has_template_ancestor(self):
            // for task in self:
            //     task.has_template_ancestor = task.is_template or (task.parent_id and task.parent_id.sudo().has_template_ancestor)
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeIsClosedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_is_closed(self):
            // for task in self:
            //     task.is_closed = task.state in CLOSED_STATES
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeIsProjectMapEmptyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_task.py) ---
            // def _compute_is_project_map_empty(self):
            // for task in self:
            //     task.is_project_map_empty = not bool(task.sudo().project_id.sale_line_employee_ids)
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeIsTimeoffTaskInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: project_task.py) ---
            // def _compute_is_timeoff_task(self):
            // timeoff_tasks = self.filtered(lambda task: task.leave_types_count or task.company_id.leave_timesheet_task_id == task)
            // timeoff_tasks.is_timeoff_task = True
            // (self - timeoff_tasks).is_timeoff_task = False
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeLastSolOfCustomerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_task.py) ---
            // def _compute_last_sol_of_customer(self):
            // sol_per_domain = dict()
            // for task in self:
            //     domain = tuple(task._get_last_sol_of_customer_domain())
            //     if not domain:
            //         task.last_sol_of_customer = False
            //         continue
            //     if domain not in sol_per_domain:
            //         sol_per_domain[domain] = self.env['sale.order.line'].search(domain, limit=1)
            //     task.last_sol_of_customer = sol_per_domain[domain]
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeLeaveTypesCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: project_task.py) ---
            // def _compute_leave_types_count(self):
            // timesheet_read_group = self.env['account.analytic.line']._read_group(
            //     [('task_id', 'in', self.ids), '|', ('holiday_id', '!=', False), ('global_leave_id', '!=', False)],
            //     ['task_id'],
            //     ['__count'],
            // )
            // timesheet_count_per_task = {timesheet_task.id: count for timesheet_task, count in timesheet_read_group}
            // for task in self:
            //     task.leave_types_count = timesheet_count_per_task.get(task.id, 0)
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeLinkPreviewNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_link_preview_name(self):
            // for task in self:
            //     link_preview_name = task.display_name
            //     if task.project_id:
            //         link_preview_name += f' | {task.project_id.sudo().name}'
            //     task.link_preview_name = link_preview_name
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeMilestoneIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_milestone_id(self):
            // for task in self:
            //     if task.project_id != task.milestone_id.project_id:
            //         task.milestone_id = task.parent_id.project_id == task.project_id and task.parent_id.milestone_id
            */
            return default;
        }

        protected async Task<ProjectTask> ComputePartnerIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_partner_id(self):
            // """ Compute the partner_id when the tasks have no partner_id.
            // 
            //     Use the project partner_id if any, or else the parent task partner_id.
            // """
            // for task in self:
            //     if task.has_template_ancestor:
            //         continue
            //     if task.partner_id and not (task.project_id or task.parent_id):
            //         task.partner_id = False
            //         continue
            //     if not task.partner_id:
            //         task.partner_id = self._get_default_partner_id(task.project_id, task.parent_id)
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_task.py) ---
            // def _compute_partner_id(self):
            // billable_task = self.filtered(lambda t: t.allow_billable or (not self._origin and t.parent_id.allow_billable))
            // (self - billable_task).partner_id = False
            // super(ProjectTask, billable_task)._compute_partner_id()
            */
            return default;
        }

        protected async Task<ProjectTask> ComputePartnerPhoneInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_partner_phone(self):
            // for task in self:
            //     task.partner_phone = task.partner_id.phone or False
            */
            return default;
        }

        protected async Task<ProjectTask> ComputePersonalStageIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_personal_stage_id(self):
            // # An user may only access his own 'personal stage' and there can only be one pair (user, task_id)
            // personal_stages = self.env['project.task.stage.personal'].search([('user_id', '=', self.env.uid), ('task_id', 'in', self.ids)])
            // self.personal_stage_id = False
            // for personal_stage in personal_stages:
            //     personal_stage.task_id.personal_stage_id = personal_stage
            */
            return default;
        }

        protected async Task<ProjectTask> ComputePortalUserNamesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_portal_user_names(self):
            // """ This compute method allows to see all the names of assigned users to each task contained in `self`.
            // 
            //     When we are in the project sharing feature, the `user_ids` contains only the users if we are a portal user.
            //     That is, only the users in the same company of the current user.
            //     So this compute method is a related of `user_ids.name` but with more records that the portal user
            //     can normally see.
            //     (In other words, this compute is only used in project sharing views to see all assignees for each task)
            // """
            // if self._origin:
            //     # fetch 'user_ids' in superuser mode (and override value in cache
            //     # browse is useful to avoid miscache because of the newIds contained in self
            //     self.invalidate_recordset(fnames=['user_ids'])
            //     self._origin.fetch(['user_ids'])
            // for task in self.with_context(prefetch_fields=False):
            //     task.portal_user_names = format_list(self.env, task.user_ids.mapped('name'))
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeProgressHoursInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py) ---
            // def _compute_progress_hours(self):
            // for task in self:
            //     if (task.allocated_hours > 0.0):
            //         task_total_hours = task.effective_hours + task.subtask_effective_hours
            //         task.overtime = max(task_total_hours - task.allocated_hours, 0)
            //         task.progress = round(task_total_hours / task.allocated_hours, 2)
            //     else:
            //         task.progress = 0.0
            //         task.overtime = 0
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeProjectIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_project_id(self):
            // self.env.remove_to_compute(self._fields['display_in_project'], self)
            // for task in self:
            //     if not task.display_in_project and task.parent_id and task.parent_id.project_id != task.project_id:
            //         task.project_id = task.parent_id.project_id
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeRecurringCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_recurring_count(self):
            // self.recurring_count = 0
            // recurring_tasks = self.filtered(lambda l: l.recurrence_id)
            // count = self.env['project.task']._read_group([('recurrence_id', 'in', recurring_tasks.recurrence_id.ids)], ['recurrence_id'], ['__count'])
            // tasks_count = {recurrence.id: count for recurrence, count in count}
            // for task in recurring_tasks:
            //     task.recurring_count = tasks_count.get(task.recurrence_id.id, 0)
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeRemainingHoursInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py) ---
            // def _compute_remaining_hours(self):
            // for task in self:
            //     if not task.allocated_hours:
            //         task.remaining_hours = 0.0
            //     else:
            //         task.remaining_hours = task.allocated_hours - task.effective_hours - task.subtask_effective_hours
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeRemainingHoursPercentageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py) ---
            // def _compute_remaining_hours_percentage(self):
            // for task in self:
            //     if task.allocated_hours > 0.0:
            //         task.remaining_hours_percentage = task.remaining_hours / task.allocated_hours
            //     else:
            //         task.remaining_hours_percentage = 0.0
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeRemainingHoursSoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_task.py) ---
            // def _compute_remaining_hours_so(self):
            // # TODO This is not yet perfectly working as timesheet.so_line stick to its old value although changed
            // #      in the task From View.
            // timesheets = self.timesheet_ids.filtered(lambda t: t.task_id.sale_line_id in (t.so_line, t._origin.so_line) and t.so_line.remaining_hours_available)
            // 
            // mapped_remaining_hours = {task._origin.id: task.sale_line_id and task.sale_line_id.remaining_hours or 0.0 for task in self}
            // uom_hour = self.env.ref('uom.product_uom_hour')
            // for timesheet in timesheets:
            //     delta = 0
            //     if timesheet._origin.so_line == timesheet.task_id.sale_line_id:
            //         delta += timesheet._origin.unit_amount
            //     if timesheet.so_line == timesheet.task_id.sale_line_id:
            //         delta -= timesheet.unit_amount
            //     if delta:
            //         mapped_remaining_hours[timesheet.task_id._origin.id] += timesheet.product_uom_id._compute_quantity(delta, uom_hour)
            // 
            // for task in self:
            //     task.remaining_hours_so = mapped_remaining_hours[task._origin.id]
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeRepeatInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_repeat(self):
            // rec_fields = self._get_recurrence_fields()
            // defaults = self.default_get(rec_fields)
            // for task in self:
            //     for f in rec_fields:
            //         if task.recurrence_id:
            //             task[f] = task.recurrence_id.sudo()[f]
            //         else:
            //             if task.recurring_task:
            //                 task[f] = defaults.get(f)
            //             else:
            //                 task[f] = False
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeSaleLineInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_task.py) ---
            // def _compute_sale_line(self):
            // for task in self:
            //     if not (task.allow_billable or task.parent_id.allow_billable):
            //         task.sale_line_id = False
            //         continue
            //     if not task.sale_line_id:
            //         # if the project_id is set then it means the task is classic task or a subtask with another project than its parent.
            //         # To determine the sale_line_id, we first need to look at the parent before the project to manage the case of subtasks.
            //         # Two sub-tasks in the same project do not necessarily have the same sale_line_id (need to look at the parent task).
            //         sale_line = False
            //         if task.parent_id.sale_line_id and task.parent_id.partner_id.commercial_partner_id == task.partner_id.commercial_partner_id:
            //             sale_line = task.parent_id.sale_line_id
            //         elif task.milestone_id.sale_line_id:
            //             sale_line = task.milestone_id.sale_line_id
            //         elif task.project_id.sale_line_id and task.project_id.partner_id.commercial_partner_id == task.partner_id.commercial_partner_id:
            //             sale_line = task.project_id.sale_line_id
            //         task.sale_line_id = sale_line
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_task.py) ---
            // def _compute_sale_line(self):
            // super()._compute_sale_line()
            // for task in self:
            //     if task.allow_billable and not task.sale_line_id:
            //         task.sale_line_id = task.last_sol_of_customer
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeSaleOrderIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_task.py) ---
            // def _compute_sale_order_id(self):
            // for task in self:
            //     if not task.allow_billable:
            //         task.sale_order_id = False
            //         continue
            //     sale_order = (
            //         task.sale_line_id.order_id
            //         or task.project_id.sale_order_id
            //         or task.project_id.reinvoiced_sale_order_id
            //         or task.sale_order_id
            //     )
            //     if sale_order and not task.partner_id:
            //         task.partner_id = sale_order.partner_id
            //     consistent_partners = (
            //         sale_order.partner_id
            //         | sale_order.partner_invoice_id
            //         | sale_order.partner_shipping_id
            //     ).commercial_partner_id
            //     if task.partner_id.commercial_partner_id in consistent_partners:
            //         task.sale_order_id = sale_order
            //     else:
            //         task.sale_order_id = False
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeStageIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_stage_id(self):
            // for task in self:
            //     project = task.project_id or task.parent_id.project_id
            //     if project:
            //         if project not in task.stage_id.project_ids:
            //             task.stage_id = task.stage_find(project.id, [('fold', '=', False)])
            //     else:
            //         task.stage_id = False
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_state(self):
            // for task in self:
            //     dependent_open_tasks = []
            //     if task.allow_task_dependencies:
            //         dependent_open_tasks = [dependent_task for dependent_task in task.depend_on_ids if
            //                                 dependent_task.state not in CLOSED_STATES]
            //     # if one of the blocking task is in a blocking state
            //     if dependent_open_tasks:
            //         # here we check that the blocked task is not already in a closed state (if the task is already done we don't put it in waiting state)
            //         if task.state not in CLOSED_STATES:
            //             task.state = '04_waiting_normal'
            //     # if the task as no blocking dependencies and is in waiting_normal, the task goes back to in progress
            //     elif task.state not in CLOSED_STATES:
            //         task.state = '01_in_progress'
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeSubtaskAllocatedHoursInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_subtask_allocated_hours(self):
            // for task in self:
            //     task.subtask_allocated_hours = sum(task.child_ids.mapped('allocated_hours'))
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeSubtaskCompletionPercentageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_subtask_completion_percentage(self):
            // for task in self:
            //     task.subtask_completion_percentage = task.subtask_count and task.closed_subtask_count / task.subtask_count
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeSubtaskCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_subtask_count(self):
            // if not any(self._ids):
            //     for task in self:
            //         task.subtask_count, task.closed_subtask_count = len(task.child_ids), len(task.child_ids.filtered(lambda r: r.state in CLOSED_STATES))
            //     return
            // total_and_closed_subtask_count_per_parent_id = {
            //     parent.id: (count, sum(s in CLOSED_STATES for s in states))
            //     for parent, states, count in self.env['project.task']._read_group(
            //         [('parent_id', 'in', self.ids)],
            //         ['parent_id'],
            //         ['state:array_agg', '__count'],
            //     )
            // }
            // for task in self:
            //     task.subtask_count, task.closed_subtask_count = total_and_closed_subtask_count_per_parent_id.get(task.id, (0, 0))
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeSubtaskEffectiveHoursInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py) ---
            // def _compute_subtask_effective_hours(self):
            // for task in self.with_context(active_test=False):
            //     task.subtask_effective_hours = sum(child_task.effective_hours + child_task.subtask_effective_hours for child_task in task.child_ids)
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeTaskToInvoiceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_task.py) ---
            // def _compute_task_to_invoice(self):
            // for task in self:
            //     if task.sale_order_id:
            //         task.task_to_invoice = bool(task.sale_order_id.invoice_status not in ('no', 'invoiced'))
            //     else:
            //         task.task_to_invoice = False
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeTotalHoursSpentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py) ---
            // def _compute_total_hours_spent(self):
            // for task in self:
            //     task.total_hours_spent = task.effective_hours + task.subtask_effective_hours
            */
            return default;
        }

        protected async Task<ProjectTask> ConvertHoursToDaysInternalAsync(object time)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py) ---
            // def _convert_hours_to_days(self, time):
            // uom_hour = self.env.ref('uom.product_uom_hour')
            // uom_day = self.env.ref('uom.product_uom_day')
            // return round(uom_hour._compute_quantity(time, uom_day, raise_if_failure=False), 2)
            */
            return default;
        }

        public async Task<ProjectTask> ConvertToSubtaskAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_convert_to_subtask(self):
            // self.ensure_one()
            // if self.project_id:
            //     return {
            //         'name': _('Convert to Task/Sub-Task'),
            //         'type': 'ir.actions.act_window',
            //         'res_model': 'project.task',
            //         'res_id': self.id,
            //         'views': [(self.env.ref('project.project_task_convert_to_subtask_view_form', False).id, 'form')],
            //         'target': 'new',
            //     }
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'type': 'danger',
            //         'message': _('Private tasks cannot be converted into sub-tasks. Please set a project on the task to gain access to this feature.'),
            //     }
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectTask> ConvertToTaskAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_todo, FILE: project_task.py) ---
            // def action_convert_to_task(self):
            // self.ensure_one()
            // self.company_id = self.project_id.company_id
            // return {
            //     'view_mode': 'form',
            //     'res_model': 'project.task',
            //     'res_id': self.id,
            //     'type': 'ir.actions.act_window',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectTask> ConvertToTemplateAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_convert_to_template(self):
            // self.ensure_one()
            // if not self.project_id:
            //     return {
            //         'type': 'ir.actions.client',
            //         'tag': 'display_notification',
            //         'params': {
            //             'type': 'danger',
            //             'message': _('Private tasks cannot be converted into templates'),
            //         },
            //     }
            // if self.is_template:
            //     return {
            //         'type': 'ir.actions.client',
            //         'tag': 'project_show_template_undo_confirmation_dialog',
            //         'params': {
            //             'task_id': self.id,
            //         },
            //     }
            // self.is_template = True
            // self.role_ids = False
            // self.message_post(body=_("Task converted to template"))
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'project_show_template_notification',
            //     'params': {
            //         'task_id': self.id,
            //         'next': {
            //             'type': 'ir.actions.client',
            //             'tag': 'soft_reload',
            //         },
            //     },
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectTask> CopyDataAsync(Guid id, ProjectTaskCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // default.update({
            //     'depend_on_ids': False,
            //     'dependent_ids': False,
            // })
            // vals_list = super().copy_data(default=default)
            // # filter only readable fields
            // vals_list = [
            //     {
            //         k: v
            //         for k, v in vals.items()
            //         if self._has_field_access(self._fields[k], 'read')
            //     }
            //     for vals in vals_list
            // ]
            // 
            // active_users = self.env['res.users']
            // has_default_users = 'user_ids' in default
            // if not has_default_users:
            //     active_users = self.user_ids.filtered('active')
            // milestone_mapping = self.env.context.get('milestone_mapping', {})
            // for task, vals in zip(self, vals_list):
            // 
            //     if not default.get('stage_id'):
            //         vals['stage_id'] = task.stage_id.id
            //     if 'active' not in default and not task['active'] and not self.env.context.get('copy_project'):
            //         vals['active'] = True
            //     if not default.get('name'):
            //         vals['name'] = task.name if self.env.context.get('copy_project') or self.env.context.get('copy_from_template') else _("%s (copy)", task.name)
            //     if task.recurrence_id and not default.get('recurrence_id'):
            //         vals['recurrence_id'] = task.recurrence_id.copy().id
            //     if task.allow_milestones:
            //         vals['milestone_id'] = milestone_mapping.get(vals['milestone_id'], vals['milestone_id'])
            //     if not default.get('child_ids') and task.child_ids:
            //         default = {
            //             'parent_id': False,
            //         }
            //         current_task = task
            //         if self.env.context.get('copy_from_template'):
            //             current_task = current_task.with_context(active_test=True)
            //         child_ids = current_task.child_ids
            //         vals['child_ids'] = [Command.create(child_id.copy_data(default)[0]) for child_id in child_ids]
            //     if not has_default_users and vals['user_ids']:
            //         task_active_users = task.user_ids & active_users
            //         vals['user_ids'] = [Command.set(task_active_users.ids)]
            //     if self.env.context.get('copy_from_template') and not self.env.context.get('copy_from_project_template'):
            //         vals['is_template'] = False
            //     if self.env.context.get('copy_from_template'):
            //         for field in set(self._get_template_field_blacklist()) & set(vals.keys()):
            //             del vals[field]
            // return vals_list
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<ProjectTask> CreateAsync(ProjectTask entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def create(self, vals_list):
            // # Some values are determined by this override and must be written as
            // # sudo for portal users, because they do not have access to these
            // # fields. Other values must not be written as sudo.
            // additional_vals_list = [{} for _ in vals_list]
            // 
            // new_context = dict(self.env.context)
            // default_personal_stage = new_context.pop('default_personal_stage_type_ids', False)
            // default_project_id = new_context.pop('default_project_id', False)
            // if not default_project_id:
            //     parent_task = self.browse({parent_id for vals in vals_list if (parent_id := vals.get('parent_id'))})
            //     if len(parent_task) == 1:
            //         default_project_id = parent_task.sudo().project_id.id
            // # (portal) users that don't have write access can still create a task
            // # in the project that will be checked using record rules
            // new_context["default_create_in_project_id"] = default_project_id
            // if not self._has_field_access(self._fields['user_ids'], 'write'):
            //     # remove user_ids if we have no access to it
            //     new_context.pop('default_user_ids', False)
            // self_ctx = self.with_context(new_context)
            // 
            // self_ctx.browse().check_access('create')
            // default_stage = dict()
            // for vals, additional_vals in zip(vals_list, additional_vals_list):
            //     project_id = vals.get('project_id') or default_project_id
            // 
            //     if vals.get('user_ids'):
            //         additional_vals['date_assign'] = fields.Datetime.now()
            //         if not (vals.get('parent_id') or project_id):
            //             user_ids = self_ctx._fields['user_ids'].convert_to_cache(vals.get('user_ids', []), self_ctx.env['project.task'])
            //             if self_ctx.env.user.id not in list(user_ids) + [SUPERUSER_ID]:
            //                 additional_vals['user_ids'] = [Command.set(list(user_ids) + [self_ctx.env.user.id])]
            //     if default_personal_stage and 'personal_stage_type_id' not in vals:
            //         additional_vals['personal_stage_type_id'] = default_personal_stage[0]
            //     if not vals.get('name') and vals.get('display_name'):
            //         vals['name'] = vals['display_name']
            // 
            //     if self_ctx.env.user._is_portal() and not self_ctx.env.su:
            //         self_ctx._ensure_fields_write(vals, defaults=True)
            // 
            //     if project_id and not "company_id" in vals:
            //         additional_vals["company_id"] = self_ctx.env["project.project"].browse(
            //             project_id
            //         ).company_id.id
            //     if not project_id and ("stage_id" in vals or self_ctx.env.context.get('default_stage_id')):
            //         vals["stage_id"] = False
            // 
            //     if project_id and "stage_id" not in vals:
            //         # 1) Allows keeping the batch creation of tasks
            //         # 2) Ensure the defaults are correct (and computed once by project),
            //         # by using default get (instead of _get_default_stage_id or _stage_find),
            //         if project_id not in default_stage:
            //             default_stage[project_id] = self_ctx.with_context(
            //                 default_project_id=project_id
            //             ).default_get(['stage_id']).get('stage_id')
            //         vals["stage_id"] = default_stage[project_id]
            // 
            //     # Stage change: Update date_end if folded stage and date_last_stage_update
            //     if vals.get('stage_id'):
            //         additional_vals.update(self_ctx.update_date_end(vals['stage_id']))
            //         additional_vals['date_last_stage_update'] = fields.Datetime.now()
            //     # recurrence
            //     rec_fields = vals.keys() & self_ctx._get_recurrence_fields()
            //     if rec_fields and vals.get('recurring_task') is True:
            //         rec_values = {rec_field: vals[rec_field] for rec_field in rec_fields}
            //         recurrence = self_ctx.env['project.task.recurrence'].create(rec_values)
            //         vals['recurrence_id'] = recurrence.id
            // 
            // # create the task, write computed inaccessible fields in sudo
            // for vals, computed_vals in zip(vals_list, additional_vals_list):
            //     for field_name in list(computed_vals):
            //         if self_ctx._has_field_access(self_ctx._fields[field_name], 'write'):
            //             vals[field_name] = computed_vals.pop(field_name)
            // # no track when the portal user create a task to avoid using during tracking
            // # process since the portal does not have access to tracking models
            // tasks = super(ProjectTask, self_ctx.with_context(mail_create_nosubscribe=True, mail_notrack=not self_ctx.env.su and self_ctx.env.user._is_portal())).create(vals_list)
            // for task, computed_vals in zip(tasks.sudo(), additional_vals_list):
            //     if computed_vals:
            //         task.write(computed_vals)
            // tasks.sudo()._populate_missing_personal_stages()
            // self_ctx._task_message_auto_subscribe_notify({task: task.user_ids - self_ctx.env.user for task in tasks})
            // 
            // current_partner = self_ctx.env.user.partner_id
            // 
            // all_partner_emails = []
            // for task in tasks.sudo():
            //     all_partner_emails += tools.email_normalize_all(task.email_cc)
            // partners = self_ctx.env['res.partner'].search([('email', 'in', all_partner_emails)])
            // partner_per_email = {
            //     partner.email: partner
            //     for partner in partners
            //     if not all(u.share for u in partner.user_ids)
            // }
            // if tasks.project_id:
            //     tasks.sudo()._set_stage_on_project_from_task()
            // for task in tasks.sudo():
            //     if task.project_id.privacy_visibility in ['invited_users', 'portal']:
            //         task._portal_ensure_token()
            //     for follower in task.parent_id.message_follower_ids:
            //         task.message_subscribe(follower.partner_id.ids, follower.subtype_ids.ids)
            //     if current_partner not in task.message_partner_ids:
            //         task.message_subscribe(current_partner.ids)
            //     if task.email_cc:
            //         partners_with_internal_user = self_ctx.env['res.partner']
            //         for email in tools.email_normalize_all(task.email_cc):
            //             new_partner = partner_per_email.get(email)
            //             if new_partner:
            //                 partners_with_internal_user |= new_partner
            //         if not partners_with_internal_user:
            //             continue
            //         task._send_email_notify_to_cc(partners_with_internal_user)
            //         task.message_subscribe(partners_with_internal_user.ids)
            // return tasks
            --- ODOO METHOD SOURCE (MODULE: project_sms, FILE: project_task.py) ---
            // def create(self, vals_list):
            // tasks = super().create(vals_list)
            // tasks._send_sms()
            // return tasks
            --- ODOO METHOD SOURCE (MODULE: project_todo, FILE: project_task.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if not vals.get('name') and not vals.get('project_id') and not vals.get('parent_id'):
            //         if vals.get('description'):
            //             # Generating name from first line of the description
            //             text = html2plaintext(vals['description'])
            //             name = text.strip().replace('*', '').partition("\n")[0]
            //             vals['name'] = (name[:97] + '...') if len(name) > 100 else name
            //         else:
            //             vals['name'] = self.env._('Untitled to-do')
            // return super().create(vals_list)
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_task.py) ---
            // def create(self, vals_list):
            // tasks = super().create(vals_list)
            // sol_ids = {
            //     vals['sale_line_id']
            //     for vals in vals_list
            //     if vals.get('sale_line_id')
            // }
            // if sol_ids:
            //     tasks._ensure_sale_order_linked(list(sol_ids))
            // return tasks
            */
            return await base.CreateAsync(entity, fields);
        }

        public async Task<ProjectTask> CreateFromTemplateAsync(Guid id, ProjectTaskCreateFromTemplateRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_create_from_template(self, values=None):
            // self.ensure_one()
            // values = values or {}
            // default = {
            //               key[8:]: value
            //               for key, value in self.env.context.items()
            //               if key.startswith('default_') and key[8:] in self._get_template_default_context_whitelist()
            //           } | {
            //               field: False
            //               for field in self._get_template_field_blacklist()
            //           } | values
            // return self.with_context(copy_from_template=True).copy(default=default).id
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectTask> CreateTaskMappingInternalAsync(object copied_tasks)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _create_task_mapping(self, copied_tasks):
            // """
            // Thanks to the way create and command.create is handled, when a task with 2 children is copied, we have the guarantee that the children of the
            // copied task will have the same index in the child_ids recordset. We can use this behavior to create a mapping containing all the original tasks and their copy.
            // :return:
            //     task_mapping: a dict containing the mapping of the original task ids and their copied task (k: original_task.id, v: new_task)
            //     task_dependencies: a dict containing the ids of the dependencies of the original task when they have one.
            //     (k: original_task_id, v: [original_task.depend_on_ids.ids, original_task.dependent_ids.ids]
            // """
            // task_mapping, task_dependencies = {}, {}
            // for original_task, copied_task in zip(self, copied_tasks):
            //     task_mapping[original_task.id] = copied_task
            //     if original_task.allow_task_dependencies and (original_task.depend_on_ids or original_task.dependent_ids):
            //         task_dependencies[original_task.id] = [original_task.depend_on_ids.ids, original_task.dependent_ids.ids]
            //     if original_task.child_ids:
            //         # If the task has children, we have to call the method create_task_mapping to get their ids and dependencies mapping too.
            //         children_mapping, children_dependencies = original_task.child_ids._create_task_mapping(copied_task.child_ids)
            //         task_mapping.update(children_mapping)
            //         task_dependencies.update(children_dependencies)
            // return task_mapping, task_dependencies
            */
            return default;
        }

        protected async Task<ProjectTask> CreationMessageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _creation_message(self):
            // self.ensure_one()
            // if self.project_id:
            //     return _('A new task has been created in the "%(project_name)s" project.',
            //              project_name=self.project_id.display_name)
            // return _('A new task has been created and is not part of any project.')
            */
            return default;
        }

        protected async Task<ProjectTask> CreationSubtypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _creation_subtype(self):
            // return self.env.ref('project.mt_task_new')
            */
            return default;
        }

        protected async Task<ProjectTask> DefaultCompanyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _default_company_id(self):
            // if self.env.context.get('default_project_id'):
            //     return self.env['project.project'].browse(self.env.context['default_project_id']).company_id
            // return False
            */
            return default;
        }

        public override async Task<ProjectTask> DefaultGetAsync(List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def default_get(self, fields):
            // vals = super().default_get(fields)
            // 
            // if project_id := self.env.context.get('default_create_in_project_id'):
            //     vals['project_id'] = project_id
            // 
            // # prevent creating new task in the waiting state
            // if 'state' in fields and vals.get('state') == '04_waiting_normal':
            //     vals['state'] = '01_in_progress'
            // 
            // if 'repeat_until' in fields:
            //     vals['repeat_until'] = Date.today() + timedelta(days=7)
            // 
            // if 'partner_id' in vals and not vals['partner_id']:
            //     # if the default_partner_id=False or no default_partner_id then we search the partner based on the project and parent
            //     project_id = vals.get('project_id')
            //     parent_id = vals.get('parent_id', self.env.context.get('default_parent_id'))
            //     if project_id or parent_id:
            //         partner_id = self._get_default_partner_id(
            //             project_id and self.env['project.project'].browse(project_id),
            //             parent_id and self.env['project.task'].browse(parent_id)
            //         )
            //         if partner_id:
            //             vals['partner_id'] = partner_id
            // project_id = vals.get('project_id', self.env.context.get('default_project_id'))
            // if project_id:
            //     project = self.env['project.project'].browse(project_id)
            //     if 'company_id' in fields and 'default_project_id' not in self.env.context:
            //         vals['company_id'] = project.sudo().company_id.id
            // elif 'default_user_ids' not in self.env.context and 'user_ids' in fields:
            //     user_ids = vals.get('user_ids', [])
            //     user_ids.append(Command.link(self.env.user.id))
            //     vals['user_ids'] = user_ids
            // 
            // parent_id = vals.get('parent_id', self.env.context.get('default_parent_id'))
            // if parent_id:
            //     parent = self.env['project.task'].browse(parent_id)
            //     if not vals.get('tag_ids'):
            //         vals['tag_ids'] = parent.tag_ids
            // 
            // return vals
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_task.py) ---
            // def default_get(self, fields):
            // default = super().default_get(fields)
            // if self.env.context.get("from_sale_order_action"):
            //     sol = self.env['sale.order.line'].search([
            //         ("order_id", "=", self.env.context.get("default_sale_order_id")),
            //         ("project_id", "=", self.env.context.get("active_id")),
            //     ], limit=1)
            //     if sol:
            //         default["sale_line_id"] = sol.id
            // return default
            */
            return await base.DefaultGetAsync(fields);
        }

        protected async Task<ProjectTask> DefaultUserIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _default_user_ids(self):
            // return self.env.user.ids if any(key in self.env.context for key in ('default_personal_stage_type_ids', 'default_personal_stage_type_id')) else ()
            */
            return default;
        }

        public async Task<ProjectTask> DependentTasksAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_dependent_tasks(self):
            // self.ensure_one()
            // return {
            //     'res_model': 'project.task',
            //     'type': 'ir.actions.act_window',
            //     'context': {**self.env.context, 'default_depend_on_ids': [Command.link(self.id)], 'show_project_update': False, 'search_default_open_tasks': True},
            //     'domain': [('depend_on_ids', '=', self.id)],
            //     'name': _('Dependent Tasks'),
            //     'view_mode': 'list,form,kanban,calendar,pivot,graph,activity',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectTask> DomainSaleLineIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_task.py) ---
            // def _domain_sale_line_id(self):
            // domain = Domain.AND([
            //     self.env['sale.order.line']._sellable_lines_domain(),
            //     self.env['sale.order.line']._domain_sale_line_service(),
            //     [
            //         '|',
            //         ('order_partner_id.commercial_partner_id.id', 'parent_of', unquote('partner_id if partner_id else []')),
            //         ('order_partner_id', '=?', unquote('partner_id')),
            //     ],
            // ])
            // return domain
            */
            return default;
        }

        protected async Task<ProjectTask> EnsureCompanyConsistencyWithPartnerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _ensure_company_consistency_with_partner(self):
            // """ Ensures that the company of the task is valid for the partner. """
            // for task in self:
            //     if task.partner_id and task.partner_id.company_id and task.company_id and task.company_id != task.partner_id.company_id:
            //         raise ValidationError(_('The task and the associated partner must be linked to the same company.'))
            */
            return default;
        }

        protected async Task<ProjectTask> EnsureFieldsWriteInternalAsync(object vals, object defaults)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _ensure_fields_write(self, vals, defaults=False):
            // if defaults:
            //     vals = {
            //         **{
            //             key[8:]: value
            //             for key, value in self.env.context.items()
            //             if key.startswith("default_") and key[8:] in self._fields
            //         },
            //         **vals
            //     }
            // 
            // for fname, value in vals.items():
            //     field = self._fields.get(fname)
            //     if field and field.type == 'many2one':
            //         self.env[field.comodel_name].browse(value).check_access('read')
            */
            return default;
        }

        protected async Task<ProjectTask> EnsureSaleOrderLinkedInternalAsync(List<Guid> sol_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_task.py) ---
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

        protected async Task<ProjectTask> EnsureSuperTaskIsNotPrivateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _ensure_super_task_is_not_private(self):
            // """ Ensures that the company of the task is valid for the partner. """
            // for task in self:
            //     if not task.project_id and task.subtask_count:
            //         raise ValidationError(_('This task has sub-tasks, so it can\'t be private.'))
            */
            return default;
        }

        protected async Task<ProjectTask> ExtractAllocatedHoursInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py) ---
            // def _extract_allocated_hours(self):
            // allocated_hours_group = self._get_group_pattern()['allocated_hours']
            // if self.allow_timesheets:
            //     self.allocated_hours = sum(float(num) for num in re.findall(allocated_hours_group, self.display_name))
            //     self.display_name, dummy = re.subn(allocated_hours_group, '', self.display_name)
            */
            return default;
        }

        protected async Task<ProjectTask> ExtractPriorityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _extract_priority(self):
            // priority_group = self._get_group_pattern()['priority']
            // match = re.search(priority_group, self.display_name)
            // if match:
            //     self.priority = str(min(len(match.group(1)), 3))
            //     self.display_name, _dummy = re.subn(priority_group, '', self.display_name)
            */
            return default;
        }

        protected async Task<ProjectTask> ExtractTagsAndUsersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _extract_tags_and_users(self):
            // tags = []
            // users = []
            // tags_and_users_group = self._get_group_pattern()['tags_and_users']
            // for word in re.findall(tags_and_users_group % '', self.display_name):
            //     (tags if word.startswith('#') else users).append(word[1:])
            // users_to_keep = []
            // user_ids = []
            // for user in users:
            //     matched_users = self.env['res.users'].name_search(user)
            //     if len(matched_users) == 1:
            //         user_ids.append(Command.link(matched_users[0][0]))
            //     else:
            //         users_to_keep.append(r'%s\b' % user)
            // self.user_ids = user_ids
            // if tags:
            //     domain = Domain.OR(Domain('name', '=ilike', tag) for tag in tags)
            //     existing_tags = self.env['project.tags'].search(domain)
            //     existing_tags_names = {tag.name.lower() for tag in existing_tags}
            //     new_tags_names = {tag for tag in tags if tag.lower() not in existing_tags_names}
            //     self.tag_ids = [Command.set(existing_tags.ids)] + [Command.create({'name': name}) for name in new_tags_names]
            // pattern = tags_and_users_group % ('(?!%s)' % ('|').join(users_to_keep) if users_to_keep else '')
            // self.display_name, _ = re.subn(pattern, '', self.display_name)
            */
            return default;
        }

        protected async Task<ProjectTask> FindInternalUsersFromAddressMailInternalAsync(object emails, Guid project_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _find_internal_users_from_address_mail(self, emails, project_id=False):
            // sanitized_email_dict = self._mail_cc_sanitized_raw_dict(emails)
            // matched_partners = self.env['res.partner']._find_or_create_from_emails(
            //     sanitized_email_dict.keys(),
            //     no_create=True
            // )
            // partners = self.env['res.partner'].concat(*matched_partners)
            // unresolved_emails = set(sanitized_email_dict) - set(partners.mapped("email"))
            // if project_id:
            //     project = self.env["project.project"].browse(project_id)
            //     project_alias_address = project.alias_name + "@" + project.alias_domain_id.name
            //     # Removing project alias from unresolved_emails as this will be added to cc_mail address and when
            //     # a mail is sent unnecessary partner is created in the name of project_alias
            //     unresolved_emails.discard(project_alias_address)
            // unmatched_partner_emails = [sanitized_email_dict.get(email) for email in unresolved_emails]
            // 
            // users = partners.user_ids
            // internal_user_ids = users.filtered(lambda u: not u.share).ids
            // 
            // partner_emails_without_internal_users = (partners - users.partner_id).mapped("email_formatted")
            // 
            // return internal_user_ids, partner_emails_without_internal_users, unmatched_partner_emails
            */
            return default;
        }

        protected async Task<ProjectTask> GetActionViewSoIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_task.py) ---
            // def _get_action_view_so_ids(self):
            // return self.sale_order_id.ids
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_task.py) ---
            // def _get_action_view_so_ids(self):
            // return list(set((self.sale_order_id + self.timesheet_ids.so_line.order_id).ids))
            */
            return default;
        }

        protected async Task<ProjectTask> GetAllSubtasksInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_all_subtasks(self):
            // return self.browse(set.union(set(), *self._get_subtask_ids_per_task_id().values()))
            */
            return default;
        }

        protected async Task<ProjectTask> GetAllowedAccessParamsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_allowed_access_params(self):
            // return super()._get_allowed_access_params() | {'project_sharing_id'}
            */
            return default;
        }

        protected async Task<ProjectTask> GetAttachmentsSearchDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_attachments_search_domain(self):
            // self.ensure_one()
            // return [('res_id', '=', self.id), ('res_model', '=', 'project.task')]
            */
            return default;
        }

        protected async Task<ProjectTask> GetCannotStartWithPatternsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py) ---
            // def _get_cannot_start_with_patterns(self):
            // return super()._get_cannot_start_with_patterns() + [r'(?!\d+(?:\.\d+)?(?:h|H))']
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_cannot_start_with_patterns(self):
            // return [r'(?![#!@\s])']
            */
            return default;
        }

        protected async Task<ProjectTask> GetDefaultPartnerIdInternalAsync(object project, object parent)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_default_partner_id(self, project=None, parent=None):
            // if parent and parent.partner_id:
            //     return parent.partner_id.id
            // if project and project.partner_id:
            //     return project.partner_id.id
            // return False
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_task.py) ---
            // def _get_default_partner_id(self, project=None, parent=None):
            // res = super()._get_default_partner_id(project, parent)
            // if not res and project:
            //     # project in sudo if the current user is a portal user.
            //     related_project = project
            //     if self.env.user._is_portal() and not self.env.user._is_internal():
            //         related_project = related_project.sudo()
            //     if related_project.pricing_type == 'employee_rate':
            //         return related_project.sale_line_employee_ids.sale_line_id.order_partner_id[:1]
            // return res
            */
            return default;
        }

        protected async Task<ProjectTask> GetDefaultPersonalStageCreateValsInternalAsync(Guid user_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_default_personal_stage_create_vals(self, user_id):
            // return [
            //     {'sequence': 1, 'name': _('Inbox'), 'user_id': user_id, 'fold': False},
            //     {'sequence': 2, 'name': _('Today'), 'user_id': user_id, 'fold': False},
            //     {'sequence': 3, 'name': _('This Week'), 'user_id': user_id, 'fold': False},
            //     {'sequence': 4, 'name': _('This Month'), 'user_id': user_id, 'fold': False},
            //     {'sequence': 5, 'name': _('Later'), 'user_id': user_id, 'fold': False},
            //     {'sequence': 6, 'name': _('Done'), 'user_id': user_id, 'fold': True},
            //     {'sequence': 7, 'name': _('Cancelled'), 'user_id': user_id, 'fold': True},
            // ]
            */
            return default;
        }

        protected async Task<ProjectTask> GetDefaultStageIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_default_stage_id(self):
            // """ Gives default stage_id """
            // project_id = self.env.context.get('default_project_id')
            // if not project_id:
            //     return False
            // return self.stage_find(project_id, order="fold, sequence, id")
            */
            return default;
        }

        public async Task<ProjectTask> GetEmptyListHelpAsync(Guid id, ProjectTaskGetEmptyListHelpRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def get_empty_list_help(self, help_message):
            // tname = _("task")
            // project_id = self.env.context.get('default_project_id', False)
            // if project_id:
            //     name = self.env['project.project'].browse(project_id).label_tasks
            //     if name: tname = name.lower()
            // 
            // self = self.with_context(
            //     empty_list_help_id=self.env.context.get('default_project_id'),
            //     empty_list_help_model='project.project',
            //     empty_list_help_document_name=tname,
            // )
            // return super().get_empty_list_help(help_message)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectTask> GetGroupPatternInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py) ---
            // def _get_group_pattern(self):
            // return {
            //     **super()._get_group_pattern(),
            //     'allocated_hours': r'\s(\d+(?:\.\d+)?)[hH]',
            // }
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_group_pattern(self):
            // return {
            //     'tags_and_users': r'\s([#@]%s[^\s]+)',
            //     'priority': r'(?:^|\s)(!{1,3})(?=\s|$)',
            // }
            */
            return default;
        }

        protected async Task<ProjectTask> GetGroupsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py) ---
            // def _get_groups(self):
            // return [lambda task: task._extract_allocated_hours()] + super()._get_groups()
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_groups(self):
            // return [
            //     lambda task: task._extract_tags_and_users(),
            //     lambda task: task._extract_priority(),
            // ]
            */
            return default;
        }

        protected async Task<ProjectTask> GetGroupsPatternsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_groups_patterns(self):
            // return [
            //     r'(?:%s)*' % ('|').join(self._prepare_pattern_groups()),
            // ]
            */
            return default;
        }

        public async Task<ProjectTask> GetImportTemplatesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Tasks'),
            //     'template': '/project/static/xls/tasks_import_template.xlsx',
            // }]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectTask> GetLastSolOfCustomerDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_task.py) ---
            // def _get_last_sol_of_customer_domain(self):
            // # Get the domain of the last SOL made for the customer in the current task where we need to compute
            // self.ensure_one()
            // if not self.partner_id.commercial_partner_id or not self.allow_billable:
            //     return []
            // SaleOrderLine = self.env['sale.order.line']
            // domain = Domain.AND([
            //     SaleOrderLine._domain_sale_line_service(),
            //     [
            //         ('company_id', '=?', self.company_id.id),
            //         ('order_partner_id', 'child_of', self.partner_id.commercial_partner_id.id),
            //         ('remaining_hours', '>', 0),
            //     ],
            // ])
            // if self.project_id.pricing_type != 'task_rate' and self.project_sale_order_id and self.partner_id.commercial_partner_id == self.project_id.partner_id.commercial_partner_id:
            //     domain &= Domain('order_id', '=', self.project_sale_order_id.id)
            // return domain
            */
            return default;
        }

        public async Task<ProjectTask> GetMentionSuggestionsAsync(Guid id, ProjectTaskGetMentionSuggestionsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def get_mention_suggestions(self, search, limit=8):
            // """Return the 'limit'-first followers of the given task or followers of its project matching
            // a 'search' string as a list of partner data (returned by `_to_store()`).
            // See similar method for all partners `get_mention_suggestions()`.
            // """
            // self.ensure_one()
            // project = self.project_id
            // if not (
            //     project
            //     and project._check_project_sharing_access()
            //     and project._get_thread_with_access(project.id)
            // ):
            //     return {}
            // # sudo: mail.followers - reading message_follower_ids on accessible task/project is allowed
            // followers = project.sudo().message_follower_ids | self.sudo().message_follower_ids
            // domain = (
            //     Domain(self.env["res.partner"]._get_mention_suggestions_domain(search))
            //     & Domain("id", "in", followers.partner_id.ids)
            // )
            // partners = self.env["res.partner"].sudo()._search_mention_suggestions(domain, limit)
            // return (
            //     Store()
            //     .add(partners, ["email", "im_status", "name", *partners._get_store_mention_fields()])
            //     .get_result()
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectTask> GetPortalTotalHoursDictInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py) ---
            // def _get_portal_total_hours_dict(self):
            // if not (timesheetable_tasks := self.filtered('allow_timesheets')):
            //     return {}
            // return {
            //     'allocated_hours': sum(timesheetable_tasks.mapped('allocated_hours')),
            //     'effective_hours': sum(timesheetable_tasks.mapped('effective_hours')),
            // }
            */
            return default;
        }

        protected async Task<ProjectTask> GetProjectsToMakeBillableDomainInternalAsync(object additional_domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_projects_to_make_billable_domain(self, additional_domain=None):
            // return Domain('partner_id', '!=', False) & Domain(additional_domain or Domain.TRUE)
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_task.py) ---
            // def _get_projects_to_make_billable_domain(self, additional_domain=None):
            // return Domain.AND([
            //     super()._get_projects_to_make_billable_domain(additional_domain),
            //     [
            //         ('partner_id', '!=', False),
            //         ('allow_billable', '=', False),
            //         ('project_id', '!=', False),
            //     ],
            // ])
            */
            return default;
        }

        protected async Task<ProjectTask> GetRecurrenceFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_recurrence_fields(self):
            // return [
            //     'repeat_interval',
            //     'repeat_unit',
            //     'repeat_type',
            //     'repeat_until',
            // ]
            */
            return default;
        }

        protected async Task<ProjectTask> GetRottingDependsFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_rotting_depends_fields(self):
            // return super()._get_rotting_depends_fields() + ['is_closed']
            */
            return default;
        }

        protected async Task<ProjectTask> GetRottingDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_rotting_domain(self):
            // return super()._get_rotting_domain() & Domain('is_closed', '=', False)
            */
            return default;
        }

        protected async Task<ProjectTask> GetSubtaskIdsPerTaskIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_subtask_ids_per_task_id(self):
            // if not self:
            //     return {}
            // 
            // res = {id_: [] for id_ in self._ids}
            // if all(self._ids):
            //     self.env.cr.execute(
            //         """
            //  WITH RECURSIVE task_tree
            //              AS (
            //              SELECT id, id as supertask_id
            //                FROM project_task
            //               WHERE id IN %(ancestor_ids)s
            //               UNION
            //                  SELECT t.id, tree.supertask_id
            //                    FROM project_task t
            //                    JOIN task_tree tree
            //                      ON tree.id = t.parent_id
            //                     AND t.active in (TRUE, %(active)s)
            //                   WHERE t.parent_id IS NOT NULL
            //        ) SELECT supertask_id, ARRAY_AGG(id)
            //            FROM task_tree
            //           WHERE id != supertask_id
            //        GROUP BY supertask_id
            //         """,
            //         {
            //             "ancestor_ids": tuple(self.ids),
            //             "active": self.env.context.get('active_test', True),
            //         }
            //     )
            //     res.update(dict(self.env.cr.fetchall()))
            // else:
            //     res.update({
            //         task.id: task._get_subtasks_recursively().ids
            //         for task in self
            //     })
            // return res
            */
            return default;
        }

        protected async Task<ProjectTask> GetSubtasksRecursivelyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_subtasks_recursively(self):
            // children = self.child_ids
            // if not children:
            //     return self.env['project.task']
            // return children + children._get_subtasks_recursively()
            */
            return default;
        }

        protected async Task<ProjectTask> GetTemplateDefaultContextWhitelistInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_template_default_context_whitelist(self):
            // """
            // Whitelist of fields that can be set through the `default_` context keys when creating a task from a template.
            // """
            // return [
            //     "parent_id",
            // ]
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_task.py) ---
            // def _get_template_default_context_whitelist(self):
            // return [
            //     *super()._get_template_default_context_whitelist(),
            //     'sale_line_id',
            //     'from_sale_order_action',
            // ]
            */
            return default;
        }

        protected async Task<ProjectTask> GetTemplateFieldBlacklistInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_template_field_blacklist(self):
            // """
            // Blacklist of fields to not copy when creating a task from a template.
            // """
            // return [
            //     "partner_id",
            // ]
            */
            return default;
        }

        protected async Task<ProjectTask> GetThreadWithAccessInternalAsync(Guid thread_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_thread_with_access(self, thread_id, *, project_sharing_id=None, token=None, **kwargs):
            // if project_sharing_id:
            //     if token := ProjectSharingChatter._check_project_access_and_get_token(
            //         self, project_sharing_id, self._name, thread_id, token
            //     ):
            //         token = token
            // return super()._get_thread_with_access(thread_id, project_sharing_id=project_sharing_id, token=token, **kwargs)
            */
            return default;
        }

        protected async Task<ProjectTask> GetTimesheetInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py) ---
            // def _get_timesheet(self):
            // # Is override in sale_timesheet
            // return self.timesheet_ids
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_task.py) ---
            // def _get_timesheet(self):
            // # return not invoiced timesheet and timesheet without so_line or so_line linked to task
            // timesheet_ids = super()._get_timesheet()
            // return timesheet_ids.filtered(lambda t: t._is_not_billed())
            */
            return default;
        }

        protected async Task<ProjectTask> GetTimesheetReportDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py) ---
            // def _get_timesheet_report_data(self):
            // subtasks = self._get_all_subtasks()
            // timesheets_read_group = self.env['account.analytic.line']._read_group(
            //     [('task_id', 'in', (self | subtasks).ids)],
            //     ['task_id'],
            //     ['id:recordset'],
            // )
            // timesheets_per_task = dict(timesheets_read_group)
            // subtask_ids_per_task_id = defaultdict(list)
            // for subtask in subtasks:
            //     subtask_ids_per_task_id[subtask.parent_id.id].append(subtask.id)
            // return {
            //     'subtask_ids_per_task_id': subtask_ids_per_task_id,
            //     'timesheets_per_task': timesheets_per_task,
            // }
            */
            return default;
        }

        public async Task<ProjectTask> GetTodoViewsIdAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_todo, FILE: project_task.py) ---
            // def get_todo_views_id(self):
            // """ Returns the ids of the main views used in the To-Do app.
            // 
            // :return: a list of views id and views type
            //          e.g. [(kanban_view_id, "kanban"), (list_view_id, "list"), ...]
            // :rtype: list(tuple())
            // """
            // return [
            //     (self.env['ir.model.data']._xmlid_to_res_id("project_todo.project_task_view_todo_kanban"), "kanban"),
            //     (self.env['ir.model.data']._xmlid_to_res_id("project_todo.project_task_view_todo_tree"), "list"),
            //     (self.env['ir.model.data']._xmlid_to_res_id("project_todo.project_task_view_todo_form"), "form"),
            //     (self.env['ir.model.data']._xmlid_to_res_id("project_todo.project_task_view_todo_calendar"), "calendar"),
            //     (self.env['ir.model.data']._xmlid_to_res_id("project_todo.project_task_view_todo_activity"), "activity"),
            // ]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectTask> GetUnusualDaysAsync(Guid id, ProjectTaskGetUnusualDaysRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def get_unusual_days(self, date_from, date_to=None):
            // calendar = self.env.company.resource_calendar_id
            // return calendar._get_unusual_days(
            //     datetime.combine(fields.Date.from_string(date_from), time.min).replace(tzinfo=UTC),
            //     datetime.combine(fields.Date.from_string(date_to), time.max).replace(tzinfo=UTC)
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectTask> GetVersionedFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_versioned_fields(self):
            // return [ProjectTask.description.name]
            */
            return default;
        }

        protected async Task<ProjectTask> GetViewCacheKeyInternalAsync(Guid view_id, object view_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_view_cache_key(self, view_id=None, view_type='form', **options):
            // """The override of fields_get making fields readonly for portal users
            // makes the view cache dependent on the fact the user has the group portal or not"""
            // key = super()._get_view_cache_key(view_id, view_type, **options)
            // return key + (self.env.user._is_portal(),)
            */
            return default;
        }

        protected async Task<ProjectTask> GroupExpandSalesOrderInternalAsync(object sales_orders, object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_task.py) ---
            // def _group_expand_sales_order(self, sales_orders, domain):
            // start_date = self.env.context.get('gantt_start_date')
            // scale = self.env.context.get('gantt_scale')
            // if not (start_date and scale):
            //     return sales_orders
            // search_on_comodel = self._search_on_comodel(domain, "sale_order_id", "sale.order")
            // if search_on_comodel:
            //     return search_on_comodel
            // return sales_orders
            */
            return default;
        }

        protected async Task<ProjectTask> HasFieldAccessInternalAsync(object field, object operation)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _has_field_access(self, field, operation):
            // if not super()._has_field_access(field, operation):
            //     return False
            // if not self.env.su and self.env.user._is_portal():
            //     # additional checks for portal users
            //     readable, writeable = self._portal_accessible_fields()
            //     if operation == 'read':
            //         return field.name in readable
            //     if operation == 'write':
            //         return field.name in writeable
            // return True
            */
            return default;
        }

        protected async Task<ProjectTask> InverseDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _inverse_display_name(self):
            // for task in self:
            //     if not task.display_name:
            //         continue
            //     pattern = re.compile(r'^%s.+?%s$' % (
            //         ('').join(task._get_cannot_start_with_patterns()),
            //         ('').join(task._get_groups_patterns()))
            //     )
            //     match = pattern.match(task.display_name)
            //     if match:
            //         for group, extract_data in enumerate(task._get_groups(), start=1):
            //             if match.group(group):
            //                 extract_data(task)
            //         task.name = task.display_name.strip()
            */
            return default;
        }

        protected async Task<ProjectTask> InverseParentIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _inverse_parent_id(self):
            // for task in self.sudo():
            //     if not task.parent_id:
            //         task.display_in_project = True
            //     elif task.display_in_project and task.project_id == task.parent_id.sudo().project_id:
            //         task.display_in_project = False
            */
            return default;
        }

        protected async Task<ProjectTask> InversePartnerIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_task.py) ---
            // def _inverse_partner_id(self):
            // for task in self:
            //     # check that sale_line_id/sale_order_id and customer are consistent
            //     consistent_partners = (
            //         task.sale_order_id.partner_id
            //         | task.sale_order_id.partner_invoice_id
            //         | task.sale_order_id.partner_shipping_id
            //     ).commercial_partner_id
            //     if task.sale_order_id and task.partner_id.commercial_partner_id not in consistent_partners:
            //         task.sale_order_id = task.sale_line_id = False
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_task.py) ---
            // def _inverse_partner_id(self):
            // super()._inverse_partner_id()
            // for task in self:
            //     if task.allow_billable and not task.sale_line_id:
            //         task.sale_line_id = task.sudo().last_sol_of_customer
            */
            return default;
        }

        protected async Task<ProjectTask> InversePartnerPhoneInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _inverse_partner_phone(self):
            // for task in self:
            //     if task.partner_id:
            //         task.partner_id.phone = task.partner_phone
            */
            return default;
        }

        protected async Task<ProjectTask> InverseStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _inverse_state(self):
            // last_task_id_per_recurrence_id = self.recurrence_id._get_last_task_id_per_recurrence_id()
            // tasks = self.filtered(lambda task: task.state in CLOSED_STATES and task.id == last_task_id_per_recurrence_id.get(task.recurrence_id.id))
            // self.env['project.task.recurrence']._create_next_occurrences(tasks)
            */
            return default;
        }

        public async Task<ProjectTask> IsBlockedByDependencesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def is_blocked_by_dependences(self):
            // return any(blocking_task.state not in CLOSED_STATES for blocking_task in self.depend_on_ids)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectTask> IsRecurrenceValidInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _is_recurrence_valid(self):
            // self.ensure_one()
            // return self.repeat_interval > 0 and\
            //         (self.repeat_type != 'until' or self.repeat_until and self.repeat_until > fields.Date.today())
            */
            return default;
        }

        protected async Task<ProjectTask> LoadRecordsCreateInternalAsync(object vals_list)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _load_records_create(self, vals_list):
            // for vals in vals_list:
            //     if vals.get('recurring_task'):
            //         if not vals.get('recurrence_id'):
            //             default_val = self.default_get(self._get_recurrence_fields())
            //             vals.update(**default_val)
            //     project_id = vals.get('project_id')
            //     if project_id:
            //         self = self.with_context(default_project_id=project_id)
            // tasks = super()._load_records_create(vals_list)
            // 
            // return tasks
            */
            return default;
        }

        protected async Task<ProjectTask> MailGetMessageSubtypesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _mail_get_message_subtypes(self):
            // res = super()._mail_get_message_subtypes()
            // if not self.stage_id.rating_active:
            //     res -= self.env.ref('project.mt_task_rating')
            // if len(self) == 1:
            //     waiting_subtype = self.env.ref('project.mt_task_waiting')
            //     if ((self.project_id and not self.project_id.allow_task_dependencies)\
            //         or (not self.project_id and not self.env.user.has_group('project.group_project_task_dependencies')))\
            //         and waiting_subtype in res:
            //         res -= waiting_subtype
            // return res
            */
            return default;
        }

        protected async Task<ProjectTask> MessageAutoSubscribeFollowersInternalAsync(object updated_values, List<Guid> default_subtype_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _message_auto_subscribe_followers(self, updated_values, default_subtype_ids):
            // if 'user_ids' not in updated_values:
            //     return []
            // # Since the changes to user_ids becoming a m2m, the default implementation of this function
            // #  could not work anymore, override the function to keep the functionality.
            // new_followers = []
            // # Normalize input to tuple of ids
            // value = self._fields['user_ids'].convert_to_cache(updated_values.get('user_ids', []), self.env['project.task'], validate=False)
            // users = self.env['res.users'].browse(value)
            // for user in users:
            //     try:
            //         if user.partner_id:
            //             # The you have been assigned notification is handled separately
            //             new_followers.append((user.partner_id.id, default_subtype_ids, False))
            //     except Exception:
            //         pass
            // return new_followers
            */
            return default;
        }

        public async Task<ProjectTask> MessageNewAsync(Guid id, ProjectTaskMessageNewRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def message_new(self, msg_dict, custom_values=None):
            // # remove default author when going through the mail gateway. Indeed we
            // # do not want to explicitly set user_id to False; however we do not
            // # want the gateway user to be responsible if no other responsible is
            // # found.
            // create_context = dict(self.env.context or {})
            // create_context['default_user_ids'] = False
            // if custom_values is None:
            //     custom_values = {}
            // # Auto create partner if not existent when the task is created from email
            // if not msg_dict.get('author_id') and msg_dict.get('email_from'):
            //     author = self.env['mail.thread']._partner_find_from_emails_single([msg_dict['email_from']], no_create=False)
            //     msg_dict['author_id'] = author.id
            // 
            // defaults = {
            //     'name': msg_dict.get('subject') or _("No Subject"),
            //     'allocated_hours': 0.0,
            //     'partner_id': msg_dict.get('author_id'),
            //     'email_cc': ", ".join(self._mail_cc_sanitized_raw_dict(msg_dict.get('cc')).values()) if custom_values.get('project_id') else ""
            // 
            // }
            // defaults.update(custom_values)
            // 
            // # users having email address matched from emails recepients are filtered out and added as assignees to the task
            // if msg_dict.get('to'):
            //     internal_users, partner_emails_without_users, unmatched_partner_emails = self._find_internal_users_from_address_mail(msg_dict.get('to'), defaults.get('project_id'))
            //     # set only internal users as assignees
            //     defaults['user_ids'] = defaults.get('user_ids', []) + internal_users
            //     if custom_values.get("project_id") and (partner_emails_without_users or unmatched_partner_emails):
            //         defaults["email_cc"] = defaults.get("email_cc", "") + ", " + ", ".join(partner_emails_without_users + unmatched_partner_emails)
            // task = super(ProjectTask, self.with_context(create_context)).message_new(msg_dict, custom_values=defaults)
            // partners = task._partner_find_from_emails_single(tools.email_split((msg_dict.get('to') or '') + ',' + (msg_dict.get('cc') or '')), no_create=True)
            // if task.project_id:
            //     task.message_subscribe(partners.ids)
            // return task
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectTask> MessagePostAfterHookInternalAsync(object message, object msg_vals)
        {
            #if PYTHON_CODE
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _message_post_after_hook(self, message, msg_vals):
            // if message.attachment_ids and not self.displayed_image_id:
            //     image_attachments = message.attachment_ids.filtered(lambda a: a.mimetype == 'image')
            //     if image_attachments:
            //         self.displayed_image_id = image_attachments[0]
            // 
            // # use the sanitized body of the email from the message thread to populate the task's description
            // if (
            //    not self.description
            //    and message.subtype_id == self._creation_subtype()
            //    and self.partner_id == message.author_id
            //    and msg_vals['message_type'] == 'email'
            //    and msg_vals.get('body')
            // ):
            //     # Remove the signature from the email body
            //     source_html = msg_vals.get('body')
            //     doc = html.fromstring(source_html)
            // 
            //     signature_xpath = (
            //         '//*[@id="Signature"] | '
            //         '//*[@data-smartmail="gmail_signature"] | '
            //         '//span[normalize-space(.) = "--"]'
            //     )
            // 
            //     for element in doc.xpath(signature_xpath):
            //         element.getparent().remove(element)
            // 
            //     cleaned_html = html.tostring(doc, encoding='unicode').strip()
            //     self.description = html_sanitize(cleaned_html)
            // 
            // return super()._message_post_after_hook(message, msg_vals)
            #endif
            return default;
        }

        public async Task<ProjectTask> MessageSubscribeAsync(Guid id, ProjectTaskMessageSubscribeRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def message_subscribe(self, partner_ids=None, subtype_ids=None):
            // # Set task notification based on project notification preference if user follow the project
            // if not subtype_ids:
            //     project_followers = self.project_id.sudo().message_follower_ids.filtered(lambda f: f.partner_id.id in partner_ids)
            //     for project_follower in project_followers:
            //         project_subtypes = project_follower.subtype_ids
            //         task_subtypes = (project_subtypes.mapped('parent_id') | project_subtypes.filtered(lambda sub: sub.internal or sub.default)).ids if project_subtypes else None
            //         partner_ids.remove(project_follower.partner_id.id)
            //         super().message_subscribe(project_follower.partner_id.ids, task_subtypes)
            // return super().message_subscribe(partner_ids, subtype_ids)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectTask> MessageUpdateAsync(Guid id, ProjectTaskMessageUpdateRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def message_update(self, msg_dict, update_vals=None):
            // for task in self:
            //     partners = task._partner_find_from_emails_single(tools.email_split((msg_dict.get('to') or '') + ',' + (msg_dict.get('cc') or '')), no_create=True)
            //     task.message_subscribe(partners.ids)
            // return super().message_update(msg_dict, update_vals=update_vals)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectTask> NotifyByEmailGetHeadersInternalAsync(object headers)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _notify_by_email_get_headers(self, headers=None):
            // headers = super()._notify_by_email_get_headers(headers=headers)
            // if self.project_id:
            //     current_objects = [h for h in headers.get('X-Odoo-Objects', '').split(',') if h]
            //     current_objects.insert(0, 'project.project-%s, ' % self.project_id.id)
            //     headers['X-Odoo-Objects'] = ','.join(current_objects)
            // if self.tag_ids:
            //     headers['X-Odoo-Tags'] = ','.join(self.tag_ids.mapped('name'))
            // return headers
            */
            return default;
        }

        protected async Task<ProjectTask> NotifyByEmailPrepareRenderingContextInternalAsync(object message, object msg_vals, object model_description, object force_email_company, object force_email_lang, object force_record_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _notify_by_email_prepare_rendering_context(self, message, msg_vals=False, model_description=False,
            //                                            force_email_company=False, force_email_lang=False,
            //                                            force_record_name=False):
            // render_context = super()._notify_by_email_prepare_rendering_context(
            //     message, msg_vals=msg_vals, model_description=model_description,
            //     force_email_company=force_email_company, force_email_lang=force_email_lang,
            //     force_record_name=force_record_name,
            // )
            // project_name = self.project_id.sudo().name
            // stage_name = self.stage_id.name
            // subtitles = ""
            // if project_name and stage_name:
            //     subtitles = _('Project: %(project_name)s, Stage: %(stage_name)s', project_name=project_name, stage_name=stage_name)
            // elif project_name:
            //     subtitles = _('Project: %(project_name)s', project_name=project_name)
            // elif stage_name:
            //     subtitles = _('Stage: %(stage_name)s', stage_name=stage_name)
            // if subtitles:
            //     render_context['subtitles'].append(subtitles)
            // return render_context
            */
            return default;
        }

        protected async Task<ProjectTask> NotifyGetRecipientsGroupsInternalAsync(object message, object model_description, object msg_vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=False):
            // # Handle project users and managers recipients that can assign
            // # tasks and create new one directly from notification emails. Also give
            // # access button to portal users and portal customers. If they are notified
            // # they should probably have access to the document.
            // groups = super()._notify_get_recipients_groups(
            //     message, model_description, msg_vals=msg_vals
            // )
            // if not self:
            //     return groups
            // 
            // self.ensure_one()
            // 
            // project_user_group_id = self.env.ref('project.group_project_user').id
            // new_group = ('group_project_user', lambda pdata: pdata['type'] == 'user' and project_user_group_id in pdata['groups'], {})
            // groups = [new_group] + groups
            // 
            // if self.project_privacy_visibility in ['invited_users', 'portal']:
            //     groups.insert(0, (
            //         'allowed_portal_users',
            //         lambda pdata: pdata['type'] in ['invited_users', 'portal'],
            //         {
            //             'active': True,
            //             'has_button_access': True,
            //         }
            //     ))
            // portal_privacy = self.project_id.privacy_visibility in ['invited_users', 'portal']
            // for group_name, _group_method, group_data in groups:
            //     if group_name in ('customer', 'user') or group_name == 'portal_customer' and not portal_privacy:
            //         group_data['has_button_access'] = False
            //     elif group_name == 'portal_customer' and portal_privacy:
            //         group_data['has_button_access'] = True
            // 
            // return groups
            */
            return default;
        }

        protected async Task<ProjectTask> NotifyGetReplyToInternalAsync(object @default, Guid author_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _notify_get_reply_to(self, default=None, author_id=False):
            // # Override to set alias of tasks to their project if any
            // aliases = self.sudo().mapped('project_id')._notify_get_reply_to(default=default, author_id=author_id)
            // res = {task.id: aliases.get(task.project_id.id) for task in self}
            // leftover = self.filtered(lambda rec: not rec.project_id)
            // if leftover:
            //     res.update(super(ProjectTask, leftover)._notify_get_reply_to(default=default, author_id=author_id))
            // return res
            */
            return default;
        }

        public async Task<ProjectTask> OPENSTATESAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def OPEN_STATES(self):
            // """ Return a list of the technical names complementing the CLOSED_STATES, a.k.a the open states """
            // return list(set(self._fields['state'].get_values(self.env)) - set(CLOSED_STATES))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectTask> OnchangePartnerIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_task.py) ---
            // def _onchange_partner_id(self):
            // if not self.partner_id and self.sale_line_id:
            //     self.partner_id = self.sale_line_id.order_partner_id
            */
            return default;
        }

        protected async Task<ProjectTask> OnchangeProjectIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _onchange_project_id(self):
            // if self.state != '04_waiting_normal':
            //     self.state = '01_in_progress'
            */
            return default;
        }

        protected async Task<ProjectTask> OnchangeTaskCompanyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _onchange_task_company(self):
            // if self.project_id.company_id and self.project_id.company_id != self.company_id:
            //     self.project_id = False
            */
            return default;
        }

        public async Task<ProjectTask> OpenParentTaskAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_open_parent_task(self):
            // return {
            //     'name': _('Parent Task'),
            //     'view_mode': 'form',
            //     'res_model': 'project.task',
            //     'res_id': self.parent_id.id,
            //     'type': 'ir.actions.act_window',
            //     'context': self.env.context
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectTask> OpenRatingsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_open_ratings(self):
            // self.ensure_one()
            // action = self.env['ir.actions.act_window']._for_xml_id('project.rating_rating_action_task')
            // if self.rating_count == 1:
            //     action['view_mode'] = 'form'
            //     action['res_id'] = self.rating_ids[0].id
            //     action['views'] = [[self.env.ref('project.rating_rating_view_form_project').id, 'form']]
            //     return action
            // else:
            //     return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectTask> OpenTaskAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_open_task(self):
            // return {
            //     'view_mode': 'form',
            //     'res_model': 'project.task',
            //     'res_id': self.id,
            //     'type': 'ir.actions.act_window',
            //     'context': self.env.context
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectTask> PlanTaskInCalendarAsync(Guid id, ProjectTaskPlanTaskInCalendarRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def plan_task_in_calendar(self, vals):
            // self.ensure_one()
            // return self.write(vals)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectTask> PopulateMissingPersonalStagesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _populate_missing_personal_stages(self):
            // # Assign the default personal stage for those that are missing
            // personal_stages_without_stage = self.env['project.task.stage.personal'].sudo().search([('task_id', 'in', self.ids), ('stage_id', '=', False)])
            // if personal_stages_without_stage:
            //     user_ids = personal_stages_without_stage.user_id
            //     personal_stage_by_user = defaultdict(lambda: self.env['project.task.stage.personal'])
            //     for personal_stage in personal_stages_without_stage:
            //         personal_stage_by_user[personal_stage.user_id] |= personal_stage
            //     for user_id in user_ids:
            //         stage = self.env['project.task.type'].sudo().search([('user_id', '=', user_id.id)], limit=1)
            //         # In the case no stages have been found, we create the default stages for the user
            //         if not stage:
            //             stages = self.env['project.task.type'].sudo().with_context(lang=user_id.partner_id.lang, default_project_ids=False).create(
            //                 self.with_context(lang=user_id.partner_id.lang)._get_default_personal_stage_create_vals(user_id.id)
            //             )
            //             stage = stages[0]
            //         personal_stage_by_user[user_id].sudo().write({'stage_id': stage.id})
            */
            return default;
        }

        protected async Task<ProjectTask> PortalAccessibleFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _portal_accessible_fields(self) -> tuple[frozenset[str], frozenset[str]]:
            // """Readable and writable fields by portal users."""
            // readable = frozenset(self.TASK_PORTAL_READABLE_FIELDS)
            // writeable = frozenset(self.TASK_PORTAL_WRITABLE_FIELDS)
            // return readable | writeable, writeable
            */
            return default;
        }

        protected async Task<ProjectTask> PortalGetParentHashTokenInternalAsync(object pid)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _portal_get_parent_hash_token(self, pid):
            // return self.project_id._sign_token(pid)
            */
            return default;
        }

        protected async Task<ProjectTask> PreparePatternGroupsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py) ---
            // def _prepare_pattern_groups(self):
            // return [self._get_group_pattern()['allocated_hours']] + super()._prepare_pattern_groups()
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _prepare_pattern_groups(self):
            // group = self._get_group_pattern()
            // return [
            //     group['tags_and_users'] % '',
            //     group['priority'],
            // ]
            */
            return default;
        }

        public async Task<ProjectTask> ProjectSharingOpenBlockingAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_project_sharing_open_blocking(self):
            // self.ensure_one()
            // blockings = self.dependent_ids
            // action = self.env['ir.actions.act_window']._for_xml_id('project.project_sharing_project_task_action_blocking_tasks')
            // if len(blockings) == 1:
            //     action['view_mode'] = 'form'
            //     action['views'] = [(view_id, view_type) for view_id, view_type in action['views'] if view_type == 'form']
            //     action['res_id'] = blockings.id
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectTask> ProjectSharingOpenSubtasksAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_project_sharing_open_subtasks(self):
            // self.ensure_one()
            // subtasks = self.env['project.task'].search([('id', 'child_of', self.id), ('id', '!=', self.id)])
            // if subtasks.project_id == self.project_id:
            //     action = self.env['ir.actions.act_window']._for_xml_id('project.project_sharing_project_task_action_sub_task')
            //     if len(subtasks) == 1:
            //         action['view_mode'] = 'form'
            //         action['views'] = [(view_id, view_type) for view_id, view_type in action['views'] if view_type == 'form']
            //         action['res_id'] = subtasks.id
            //     return action
            // return {
            //     'name': 'Portal Sub-tasks',
            //     'type': 'ir.actions.act_url',
            //     'url': f'/my/projects/{self.project_id.id}/task/{self.id}/subtasks' if len(subtasks) > 1 else subtasks.get_portal_url(query_string='project_sharing=1'),
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectTask> ProjectSharingOpenTaskAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_project_sharing_open_task(self):
            // action = self.action_open_task()
            // action['views'] = [[self.env.ref('project.project_sharing_project_task_view_form').id, 'form']]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectTask> ProjectSharingRecurringTasksAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_project_sharing_recurring_tasks(self):
            // self.ensure_one()
            // recurrent_tasks = self.env['project.task'].search([('recurrence_id', 'in', self.recurrence_id.ids)])
            // # If all the recurrent tasks are in the same project, open the list view in sharing mode.
            // if recurrent_tasks.project_id == self.project_id:
            //     action = self.env['ir.actions.act_window']._for_xml_id('project.project_sharing_project_task_recurring_tasks_action')
            //     action.update({
            //         'context': {'default_project_id': self.project_id.id},
            //         'domain': [
            //             ('project_id', '=', self.project_id.id),
            //             ('recurrence_id', 'in', self.recurrence_id.ids)
            //         ]
            //     })
            //     return action
            // # If at least one recurrent task belong to another project, open the portal page
            // return {
            //     'name': 'Portal Recurrent Tasks',
            //     'type': 'ir.actions.act_url',
            //     'url':  f'/my/projects/{self.project_id.id}/task/{self.id}/recurrent_tasks',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectTask> ProjectSharingToggleIsFollowerAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def project_sharing_toggle_is_follower(self):
            // self.ensure_one()
            // self.check_access('write')
            // is_follower = self.message_is_follower
            // if is_follower:
            //     self.sudo().message_unsubscribe(self.env.user.partner_id.ids)
            // else:
            //     self.sudo().message_subscribe(self.env.user.partner_id.ids)
            // return not is_follower
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectTask> ProjectSharingViewParentTaskAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_project_sharing_view_parent_task(self):
            // if self.parent_id.project_id != self.project_id and self.env.user._is_portal():
            //     project = self.parent_id.project_id._filtered_access('read')
            //     if project:
            //         url = f"/my/projects/{self.parent_id.project_id.id}/task/{self.parent_id.id}"
            //         if project._check_project_sharing_access():
            //             url = f"/my/projects/{self.parent_id.project_id.id}?task_id={self.parent_id.id}"
            //         return {
            //             "name": "Portal Parent Task",
            //             "type": "ir.actions.act_url",
            //             "url": url,
            //         }
            //     elif self.display_parent_task_button:
            //         return self.parent_id.get_portal_url()
            //     # The portal user has no access to the parent task, so normally the button should be invisible.
            //     return {}
            // action = self.with_context({
            //     'search_view_ref': 'project.project_sharing_project_task_view_search',
            // }).action_open_parent_task()
            // action['views'] = [(self.env.ref('project.project_sharing_project_task_view_form').id, 'form')]
            // action['search_view_id'] = self.env.ref("project.project_sharing_project_task_view_search").id
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectTask> ProjectSharingViewSoAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_task.py) ---
            // def action_project_sharing_view_so(self):
            // self.ensure_one()
            // if not self.display_sale_order_button:
            //     return {}
            // return {
            //     "name": self.env._("Portal Sale Order"),
            //     "type": "ir.actions.act_url",
            //     "url": self.sale_order_id.access_url,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectTask> RatingApplyAsync(Guid id, ProjectTaskRatingApplyRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def rating_apply(self, rate, token=None, rating=None, feedback=None,
            //              subtype_xmlid=None, notify_delay_send=False):
            // rating = super().rating_apply(
            //     rate, token=token, rating=rating, feedback=feedback,
            //     subtype_xmlid=subtype_xmlid, notify_delay_send=notify_delay_send)
            // if self.stage_id and self.stage_id.auto_validation_state:
            //     state = '03_approved' if rating.rating >= rating_data.RATING_LIMIT_SATISFIED else '02_changes_requested'
            //     self.write({'state': state})
            // return rating
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectTask> RatingApplyGetDefaultSubtypeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _rating_apply_get_default_subtype_id(self):
            // return self.env['ir.model.data']._xmlid_to_res_id("project.mt_task_rating")
            */
            return default;
        }

        protected async Task<ProjectTask> RatingGetOperatorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _rating_get_operator(self):
            // """ Overwrite since we have user_ids and not user_id """
            // tasks_with_one_user = self.filtered(lambda task: len(task.user_ids) == 1 and task.user_ids.partner_id)
            // return tasks_with_one_user.user_ids.partner_id or self.env['res.partner']
            */
            return default;
        }

        protected async Task<ProjectTask> RatingGetParentFieldNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _rating_get_parent_field_name(self):
            // return 'project_id'
            */
            return default;
        }

        protected async Task<ProjectTask> RatingGetPartnerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _rating_get_partner(self):
            // res = super()._rating_get_partner()
            // if not res and self.project_id.partner_id:
            //     return self.project_id.partner_id
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_task.py) ---
            // def _rating_get_partner(self):
            // partner = self.partner_id or self.sale_line_id.order_id.partner_id
            // return partner or super()._rating_get_partner()
            */
            return default;
        }

        protected async Task<List<object>> ReadGroupInternalAsync(object domain, object groupby, object aggregates, object having, object offset, object limit, object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _read_group(self, domain, groupby=(), aggregates=(), having=(), offset=0, limit=None, order=None) -> list[tuple]:
            // # A _read_group cannot be performed if records are grouped by personal_stage_type_id
            // # as it is a computed field. personal_stage_type_ids behaves like a M2O from the point
            // # of view of the user, we therefore use this field instead.
            // if 'personal_stage_type_id' in groupby:
            //     # limitation: problem when both personal_stage_type_id and personal_stage_type_ids
            //     # appear in read_group, but this has no functional utility
            //     groupby = ['personal_stage_type_ids' if fname == 'personal_stage_type_id' else fname for fname in groupby]
            //     if order:
            //         order = order.replace('personal_stage_type_id', 'personal_stage_type_ids')
            // return super()._read_group(domain, groupby, aggregates, having, offset, limit, order)
            */
            return default;
        }

        protected async Task<ProjectTask> ReadGroupPersonalStageTypeIdsInternalAsync(object stages, object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _read_group_personal_stage_type_ids(self, stages, domain):
            // return stages.search(['|', ('id', 'in', stages.ids), ('user_id', '=', self.env.user.id)])
            */
            return default;
        }

        protected async Task<ProjectTask> ReadGroupStageIdsInternalAsync(object stages, object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _read_group_stage_ids(self, stages, domain):
            // search_domain = [('id', 'in', stages.ids)]
            // if 'default_project_id' in self.env.context and not self.env.context.get(
            //         'subtask_action') and 'project_kanban' in self.env.context:
            //     search_domain = ['|', ('project_ids', '=', self.env.context['default_project_id'])] + search_domain
            // 
            // stage_ids = stages._search(search_domain, order=stages._order)
            // return stages.browse(stage_ids)
            */
            return default;
        }

        public async Task<ProjectTask> RecurringTasksAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_recurring_tasks(self):
            // return {
            //     'name': _('Tasks in Recurrence'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'project.task',
            //     'view_mode': 'list,form,kanban,calendar,pivot,graph,activity',
            //     'context': {'create': False},
            //     'domain': [('recurrence_id', 'in', self.recurrence_id.ids)],
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectTask> RedirectToProjectTaskFormAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_redirect_to_project_task_form(self):
            // menu_id = self.env.ref('project.menu_project_management_all_tasks').id
            // return {
            //     'type': 'ir.actions.act_url',
            //     'url': f"/odoo/{self.project_id.id}/action-project.act_project_project_2_project_task_all/{self.id}?menu_id={menu_id}",
            //     'target': 'new',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectTask> ResolveCopiedDependenciesInternalAsync(object copied_tasks)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _resolve_copied_dependencies(self, copied_tasks):
            // task_mapping, task_dependencies = self._create_task_mapping(copied_tasks)
            // 
            // for original_task_id, (depend_on_ids, dependant_ids) in task_dependencies.items():
            //     # If one of the task_id in the dependencies mapping is also a key of the task_mapping, it means that this task was copied too.
            //     # In this case, we should exchange this id with the id of the corresponding copied task
            //     task_mapping[original_task_id].depend_on_ids = [
            //         task_id if task_id not in task_mapping else task_mapping[task_id].id
            //         for task_id in depend_on_ids
            //     ]
            //     task_mapping[original_task_id].dependent_ids = [
            //         task_id if task_id not in task_mapping else task_mapping[task_id].id
            //         for task_id in dependant_ids
            //     ]
            */
            return default;
        }

        protected async Task<ProjectTask> SearchAllowTimesheetsInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py) ---
            // def _search_allow_timesheets(self, operator, value):
            // query = self.env['project.project'].sudo()._search([
            //     ('allow_timesheets', operator, value),
            // ])
            // return [('project_id', 'in', query)]
            */
            return default;
        }

        protected async Task<ProjectTask> SearchHasLateAndUnreachedMilestoneInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _search_has_late_and_unreached_milestone(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // return [
            //     ('allow_milestones', '=', True),
            //     ('milestone_id', 'any', [
            //         ('is_reached', '=', False),
            //         ('deadline', '<', fields.Date.today()),
            //     ]),
            // ]
            */
            return default;
        }

        protected async Task<ProjectTask> SearchHasTemplateAncestorInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _search_has_template_ancestor(self, operator, value):
            // if operator not in ['=', '!='] or not isinstance(value, bool):
            //     return NotImplemented
            // template_tasks = self.env['project.task'].with_context(active_test=False).sudo().search([('is_template', '=', True)])
            // domain = [('id', 'child_of', template_tasks.ids)]
            // if (operator == "=") != value:
            //     domain = ['!', ('id', 'child_of', template_tasks.ids)]
            // return domain
            */
            return default;
        }

        protected async Task<ProjectTask> SearchIsClosedInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _search_is_closed(self, operator, value):
            // if operator == 'in':
            //     searched_states = list(CLOSED_STATES.keys())
            // elif operator == 'not in':
            //     searched_states = self.OPEN_STATES
            // else:
            //     return NotImplemented
            // return [('state', 'in', searched_states)]
            */
            return default;
        }

        protected async Task<ProjectTask> SearchIsTimeoffTaskInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: project_task.py) ---
            // def _search_is_timeoff_task(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // 
            // timeoff_tasks_ids = {row[0] for row in self.env.execute_query(
            //     self.env['account.analytic.line']._search(
            //         [('task_id', '!=', False), '|', ('holiday_id', '!=', False), ('global_leave_id', '!=', False)],
            //     ).select('DISTINCT task_id')
            // )}
            // 
            // if self.env.company.leave_timesheet_task_id:
            //     timeoff_tasks_ids.add(self.env.company.leave_timesheet_task_id.id)
            // 
            // return Domain('id', 'in', tuple(timeoff_tasks_ids))
            */
            return default;
        }

        protected async Task<ProjectTask> SearchOnComodelInternalAsync(object domain, object field, object comodel, object additional_domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _search_on_comodel(self, domain, field, comodel, additional_domain=None):
            // """ This method is called by `group_expand` methods, whose purpose is to add empty groups to the `read_group`
            //     (which otherwise returns groups containing records that match the domain).
            //     When specifically filtering on a comodel's field, the result of the `read_group` should contain all matching groups.
            //     However, if the search isn't filtered on any comodel's field, the result shouldn't be affected,
            //     which explains why we return `False` if `filtered_domain` is empty.
            // 
            //     Returns:
            //         False or recordset of the comodel given in parameter.
            // """
            // def _change_operator(domain):
            //     new_domain = []
            //     for dom in domain:
            //         if len(dom) == 3:
            //             _, op, value = dom
            //             if op in ("any", "not any"):
            //                 new_op = "in" if op == "any" else "not in"
            //                 ids = [val[2] for val in value if isinstance(val, (tuple, list)) and isinstance(val[2], int)]
            //                 new_domain.append(("id", new_op, ids))
            //                 continue
            //             op = "ilike" if op == "child_of" else op
            //             if isinstance(value, list) and all(isinstance(val, int) for val in value):
            //                 new_domain.append(("id", op, value))
            //             elif isinstance(value, str) or (isinstance(value, list) and not all(isinstance(val, str) for val in value)):
            //                 new_domain.append(("name", op, value))
            //             if isinstance(value, int):
            //                 if op == "=":
            //                     op = "in"
            //                 if op == "!=":
            //                     op = "not in"
            //                 new_domain.append(("id", op, [value]))
            //         else:
            //             new_domain.append(dom)
            //     return Domain(new_domain)
            // 
            // filtered_domain = filter_domain_leaf(domain, lambda field_to_check: field_to_check in [
            //     field,
            //     f"{field}.id",
            //     f"{field}.name",
            // ], {
            //     field: "name",
            //     f"{field}.id": "id",
            //     f"{field}.name": "name",
            // })
            // if filtered_domain.is_true():
            //     return self.env[comodel]
            // filtered_domain = _change_operator(filtered_domain)
            // if additional_domain:
            //     filtered_domain &= Domain(additional_domain)
            // return self.env[comodel].search(filtered_domain)
            */
            return default;
        }

        protected async Task<ProjectTask> SearchPersonalStageIdInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _search_personal_stage_id(self, operator, value):
            // if operator in Domain.NEGATIVE_OPERATORS:
            //     return NotImplemented
            // field_name = 'display_name' if any(isinstance(v, str) for v in value) or value == '' else 'id'  # noqa: PLC1901
            // domain = Domain(field_name, operator, value) & Domain('user_id', '=', self.env.uid)
            // personal_stages = self.env['project.task.stage.personal']._search(domain)
            // return Domain('id', 'in', personal_stages.subselect('task_id'))
            */
            return default;
        }

        protected async Task<ProjectTask> SearchPortalUserNamesInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _search_portal_user_names(self, operator, value):
            // if operator != 'ilike' or not isinstance(value, str):
            //     return NotImplemented
            // 
            // sql = SQL("""(
            //     SELECT task_user.task_id
            //       FROM project_task_user_rel task_user
            // INNER JOIN res_users users ON task_user.user_id = users.id
            // INNER JOIN res_partner partners ON partners.id = users.partner_id
            //      WHERE partners.name ILIKE %s
            // )""", f"%{value}%")
            // return [('id', 'in', sql)]
            */
            return default;
        }

        protected async Task<ProjectTask> SearchRemainingHoursPercentageInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py) ---
            // def _search_remaining_hours_percentage(self, operator, value):
            // if operator not in OPERATOR_MAPPING:
            //     return NotImplemented
            // if operator in ('in', 'not in'):
            //     value = tuple(value)
            // sql = SQL("""(
            //     SELECT id
            //       FROM %s
            //      WHERE remaining_hours > 0
            //        AND allocated_hours > 0
            //        AND remaining_hours / allocated_hours %s %s
            // )""", SQL.identifier(self._table), SQL(operator), value)
            // return [('id', 'in', sql)]
            */
            return default;
        }

        protected async Task<ProjectTask> SearchRemainingHoursSoInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_task.py) ---
            // def _search_remaining_hours_so(self, operator, value):
            // return [('sale_line_id.remaining_hours', operator, value)]
            */
            return default;
        }

        protected async Task<ProjectTask> SearchTaskToInvoiceInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_task.py) ---
            // def _search_task_to_invoice(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // sql = SQL("""(
            //     SELECT so.id
            //     FROM sale_order so
            //     WHERE so.invoice_status != 'invoiced'
            //         AND so.invoice_status != 'no'
            // )""")
            // return [('sale_order_id', 'in', sql)]
            */
            return default;
        }

        protected async Task<ProjectTask> SendEmailNotifyToCcInternalAsync(object partners_to_notify)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _send_email_notify_to_cc(self, partners_to_notify):
            // # TDE TODO: this should be removed with email-like recipients management
            // self.ensure_one()
            // template_id = self.env['ir.model.data']._xmlid_to_res_id('project.task_invitation_follower', raise_if_not_found=False)
            // if not template_id:
            //     return
            // task_model_description = self.env['ir.model']._get(self._name).display_name
            // values = {
            //     'object': self,
            // }
            // for partner in partners_to_notify:
            //     values['partner_name'] = partner.name
            //     assignation_msg = self.env['ir.qweb']._render('project.task_invitation_follower', values, minimal_qcontext=True)
            //     self.message_notify(
            //         subject=_('You have been invited to follow %s', self.display_name),
            //         body=assignation_msg,
            //         partner_ids=partner.ids,
            //         email_layout_xmlid='mail.mail_notification_layout',
            //         model_description=task_model_description,
            //         mail_auto_delete=True,
            //     )
            */
            return default;
        }

        protected async Task<ProjectTask> SendSmsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_sms, FILE: project_task.py) ---
            // def _send_sms(self):
            // for task in self:
            //     if task.partner_id and task.stage_id and task.stage_id.sms_template_id and not task.is_template:
            //         task._message_sms_with_template(
            //             template=task.stage_id.sms_template_id,
            //             partner_ids=task.partner_id.ids,
            //         )
            */
            return default;
        }

        protected async Task<ProjectTask> SendTaskRatingMailInternalAsync(object force_send)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _send_task_rating_mail(self, force_send=False):
            // for task in self:
            //     rating_template = task.stage_id.rating_template_id
            //     partner = task.partner_id
            //     if rating_template and partner and partner != self.env.user.partner_id and not task.is_template:
            //         task.rating_send_request(rating_template, lang=task.partner_id.lang, force_send=force_send)
            */
            return default;
        }

        protected async Task<ProjectTask> SetStageOnProjectFromTaskInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _set_stage_on_project_from_task(self):
            // stage_ids_per_project = defaultdict(list)
            // for task in self:
            //     if task.stage_id and task.stage_id not in task.project_id.type_ids and task.stage_id.id not in stage_ids_per_project[task.project_id]:
            //         stage_ids_per_project[task.project_id].append(task.stage_id.id)
            // 
            // for project, stage_ids in stage_ids_per_project.items():
            //     project.write({'type_ids': [Command.link(stage_id) for stage_id in stage_ids]})
            */
            return default;
        }

        public async Task<ProjectTask> StageFindAsync(Guid id, ProjectTaskStageFindRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def stage_find(self, section_id, domain=[], order='sequence, id'):
            // """ Override of the base.stage method
            // Parameter of the stage search taken from the lead:
            // 
            // :param section_id: if set, stages must belong to this section or
            //     be a default stage; if not set, stages must be default stages
            // """
            // # collect all section_ids
            // section_ids = []
            // if section_id:
            //     section_ids.append(section_id)
            // section_ids.extend(self.mapped('project_id').ids)
            // search_domain = []
            // if section_ids:
            //     search_domain = [('|')] * (len(section_ids) - 1)
            //     for section_id in section_ids:
            //         search_domain.append(('project_ids', '=', section_id))
            // search_domain += list(domain)
            // # perform search, return the first found
            // return self.env['project.task.type'].search(search_domain, order=order, limit=1).id
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectTask> TASKPORTALREADABLEFIELDSAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py) ---
            // def TASK_PORTAL_READABLE_FIELDS(self):
            // return super().TASK_PORTAL_READABLE_FIELDS | PROJECT_TASK_READABLE_FIELDS
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def TASK_PORTAL_READABLE_FIELDS(self):
            // return PROJECT_TASK_READABLE_FIELDS
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_task.py) ---
            // def TASK_PORTAL_READABLE_FIELDS(self):
            // return super().TASK_PORTAL_READABLE_FIELDS | {'allow_billable', 'sale_order_id', 'sale_line_id', 'display_sale_order_button'}
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_task.py) ---
            // def TASK_PORTAL_READABLE_FIELDS(self):
            // return super().TASK_PORTAL_READABLE_FIELDS | {
            //     'remaining_hours_available',
            //     'remaining_hours_so',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectTask> TASKPORTALWRITABLEFIELDSAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def TASK_PORTAL_WRITABLE_FIELDS(self):
            // return PROJECT_TASK_WRITABLE_FIELDS
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectTask> TaskMessageAutoSubscribeNotifyInternalAsync(object users_per_task)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _task_message_auto_subscribe_notify(self, users_per_task):
            // if self.env.context.get('mail_auto_subscribe_no_notify'):
            //     return
            // # Utility method to send assignation notification upon writing/creation.
            // template_id = self.env['ir.model.data']._xmlid_to_res_id('project.project_message_user_assigned', raise_if_not_found=False)
            // if not template_id:
            //     return
            // task_model_description = self.env['ir.model']._get(self._name).display_name
            // for task, users in users_per_task.items():
            //     if not users:
            //         continue
            //     values = {
            //         'object': task,
            //         'model_description': task_model_description,
            //         'access_link': task._notify_get_action_link('view'),
            //     }
            //     for user in users:
            //         values.update(assignee_name=user.sudo().name)
            //         assignation_msg = self.env['ir.qweb']._render('project.project_message_user_assigned', values, minimal_qcontext=True)
            //         assignation_msg = self.env['mail.render.mixin']._replace_local_links(assignation_msg)
            //         task.message_notify(
            //             subject=_('You have been assigned to %s', task.display_name),
            //             body=assignation_msg,
            //             partner_ids=user.partner_id.ids,
            //             email_layout_xmlid='mail.mail_notification_layout',
            //             model_description=task_model_description,
            //             mail_auto_delete=False,
            //         )
            */
            return default;
        }

        protected async Task<ProjectTask> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // mail_message_subtype_per_state = {
            //     '1_done': 'project.mt_task_done',
            //     '1_canceled': 'project.mt_task_canceled',
            //     '01_in_progress': 'project.mt_task_in_progress',
            //     '03_approved': 'project.mt_task_approved',
            //     '02_changes_requested': 'project.mt_task_changes_requested',
            //     '04_waiting_normal': 'project.mt_task_waiting',
            // }
            // 
            // if 'stage_id' in init_values:
            //     return self.env.ref('project.mt_task_stage')
            // elif 'state' in init_values and self.state in mail_message_subtype_per_state:
            //     return self.env.ref(mail_message_subtype_per_state[self.state])
            // return super()._track_subtype(init_values)
            */
            return default;
        }

        protected async Task<ProjectTask> TrackTemplateInternalAsync(object changes)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _track_template(self, changes):
            // res = super()._track_template(changes)
            // test_task = self[0]
            // if 'stage_id' in changes and test_task.stage_id.mail_template_id and not test_task.is_template:
            //     res['stage_id'] = (test_task.stage_id.mail_template_id, {
            //         'auto_delete_keep_log': False,
            //         'subtype_id': self.env['ir.model.data']._xmlid_to_res_id('mail.mt_note'),
            //         'email_layout_xmlid': 'mail.mail_notification_light'
            //     })
            // return res
            */
            return default;
        }

        public async Task<ProjectTask> UndoConvertToTemplateAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_undo_convert_to_template(self):
            // self.ensure_one()
            // self.is_template = False
            // self.message_post(body=_("Template converted back to regular task"))
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'type': 'success',
            //         'message': _('Template converted back to regular task'),
            //         'next': {
            //             'type': 'ir.actions.client',
            //             'tag': 'soft_reload',
            //         },
            //     },
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectTask> UnlinkExceptContainsEntriesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py) ---
            // def _unlink_except_contains_entries(self):
            // """
            // If some tasks to unlink have some timesheets entries, these
            // timesheets entries must be unlinked first.
            // In this case, a warning message is displayed through a RedirectWarning
            // and allows the user to see timesheets entries to unlink.
            // """
            // timesheet_data = self.env['account.analytic.line'].sudo()._read_group(
            //     [('task_id', 'in', self.ids)],
            //     ['task_id'],
            // )
            // task_with_timesheets_ids = [task.id for task, in timesheet_data]
            // if not task_with_timesheets_ids:
            //     return
            // # Fetch task IDs with timesheets that the user has read access.
            // inaccessible_task_ids = set(task_with_timesheets_ids) - set(
            //     self.env['account.analytic.line'].search([
            //         ('task_id', 'in', task_with_timesheets_ids)
            //     ]).mapped('task_id.id')
            // )
            // if inaccessible_task_ids:
            //     raise UserError(
            //         _("This task can’t be deleted because it’s linked to timesheets. Please contact someone with higher access to remove the timesheets first, "
            //         "and then you’ll be able to delete the task.")
            //     )
            // if len(task_with_timesheets_ids) > 1:
            //     warning_msg = _("Some timesheet entries are weighing down these tasks! Remove them first, then you’ll be able to delete the tasks!")
            // else:
            //     warning_msg = _("Some timesheet entries are weighing down these tasks! Remove them first, then you’ll be able to delete the tasks!")
            // raise RedirectWarning(
            //     warning_msg, self.env.ref('hr_timesheet.timesheet_action_task').id,
            //     _('See timesheet entries'), {'active_ids': task_with_timesheets_ids})
            */
            return default;
        }

        public async Task<ProjectTask> UnlinkRecurrenceAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_unlink_recurrence(self):
            // self.recurrence_id.task_ids.recurring_task = False
            // self.recurrence_id.unlink()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProjectTask> UnsubscribePortalUsersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _unsubscribe_portal_users(self):
            // self.message_unsubscribe(partner_ids=self.message_partner_ids.filtered('user_ids.share').ids)
            */
            return default;
        }

        protected async Task<ProjectTask> UomInDaysInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py) ---
            // def _uom_in_days(self):
            // return self.env.company.timesheet_encode_uom_id == self.env.ref('uom.product_uom_day')
            */
            return default;
        }

        public async Task<ProjectTask> UpdateDateEndAsync(Guid id, ProjectTaskUpdateDateEndRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def update_date_end(self, stage_id):
            // project_task_type = self.env['project.task.type'].browse(stage_id)
            // if project_task_type.fold:
            //     return {'date_end': fields.Datetime.now()}
            // return {'date_end': False}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectTask> ViewSoAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_task.py) ---
            // def action_view_so(self):
            // so_ids = self._get_action_view_so_ids()
            // action_window = {
            //     "type": "ir.actions.act_window",
            //     "res_model": "sale.order",
            //     "name": _("Sales Order"),
            //     "views": [[False, "list"], [False, "kanban"], [False, "form"]],
            //     "context": {"create": False, "show_sale": True},
            //     "domain": [["id", "in", so_ids]],
            // }
            // if len(so_ids) == 1:
            //     action_window["views"] = [[False, "form"]]
            //     action_window["res_id"] = so_ids[0]
            // 
            // return action_window
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectTask> ViewSubtaskTimesheetAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py) ---
            // def action_view_subtask_timesheet(self):
            // self.ensure_one()
            // is_internal_user = self.env.user.has_group('base.group_user')
            // task_ids = self.with_context(active_test=False)._get_subtask_ids_per_task_id().get(self.id, [])
            // action = self.env["ir.actions.actions"]._for_xml_id("hr_timesheet.timesheet_action_all")
            // graph_view_id = self.env.ref("hr_timesheet.view_hr_timesheet_line_graph_by_employee").id
            // new_views = []
            // for view in action['views']:
            //     if (not is_internal_user or self.env.context.get('is_project_sharing')) and view[1] not in ['tree', 'kanban', 'form']:
            //         continue
            //     if not is_internal_user:
            //         if view[1] == 'list':
            //             tree_view_id = self.env['ir.model.data']._xmlid_to_res_id('hr_timesheet.hr_timesheet_line_portal_tree')
            //             if tree_view_id:
            //                 new_views.insert(0, (tree_view_id, 'list'))
            //                 continue
            //         elif view[1] == 'form':
            //             form_view_id = self.env['ir.model.data']._xmlid_to_res_id('hr_timesheet.timesheet_view_form_portal_user')
            //             if form_view_id:
            //                 new_views.append((form_view_id, 'form'))
            //                 continue
            //         elif view[1] == 'kanban':
            //             kanban_view_id = self.env['ir.model.data']._xmlid_to_res_id('hr_timesheet.view_kanban_account_analytic_line_portal_user')
            //             if kanban_view_id:
            //                 new_views.append((kanban_view_id, 'kanban'))
            //                 continue
            //     if view[1] == 'graph':
            //         view = (graph_view_id, 'graph')
            //     new_views.insert(0, view) if view[1] == 'list' else new_views.append(view)
            // 
            // action.update({
            //     'display_name': _('Timesheets'),
            //     'context': {'default_project_id': self.project_id.id},
            //     'domain': [('project_id', '!=', False), ('task_id', 'in', task_ids)],
            //     'views': new_views,
            // })
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, ProjectTask entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def write(self, vals):
            // self.check_access('write')
            // if len(self) == 1:
            //     handle_history_divergence(self, 'description', vals)
            // partner_ids = []
            // 
            // # Some values are determined by this override and must be written as
            // # sudo for portal users, because they do not have access to these
            // # fields. Other values must not be written as sudo.
            // additional_vals = {}
            // if self.env.user._is_portal() and not self.env.su:
            //     self._ensure_fields_write(vals, defaults=False)
            // 
            // if 'milestone_id' in vals:
            //     # WARNING: has to be done after 'project_id' vals is written on subtasks
            //     milestone = self.env['project.milestone'].browse(vals['milestone_id'])
            // 
            //     # 1. Task for which the milestone is unvalid -> milestone_id is reset
            //     if 'project_id' not in vals:
            //         unvalid_milestone_tasks = self.filtered(lambda task: task.project_id != milestone.project_id) if vals['milestone_id'] else self.env['project.task']
            //     else:
            //         unvalid_milestone_tasks = self if not vals['milestone_id'] or milestone.project_id.id != vals['project_id'] else self.env['project.task']
            //     valid_milestone_tasks = self - unvalid_milestone_tasks
            //     if unvalid_milestone_tasks:
            //         unvalid_milestone_tasks.sudo().write({'milestone_id': False})
            //         if valid_milestone_tasks:
            //             valid_milestone_tasks.sudo().write({'milestone_id': vals['milestone_id']})
            //         del vals['milestone_id']
            // 
            //     # 2. Parent's milestone is set to subtask with no milestone recursively
            //     subtasks_to_update = valid_milestone_tasks.child_ids.filtered(
            //         lambda task: (task not in self and
            //                       not task.milestone_id and
            //                       task.project_id == milestone.project_id and
            //                       task.state not in CLOSED_STATES))
            // 
            //     # 3. If parent and child task share the same milestone, child task's milestone is updated when the parent one is changed
            //     # No need to check if state is changed in vals as it won't affect the subtasks selected for update
            //     if 'project_id' not in vals:
            //         subtasks_to_update |= valid_milestone_tasks.child_ids.filtered(
            //             lambda task: (task not in self and
            //                           task.milestone_id == task.parent_id.milestone_id and
            //                           task.state not in CLOSED_STATES))
            //     else:
            //         subtasks_to_update |= valid_milestone_tasks.child_ids.filtered(
            //             lambda task: (task not in self and
            //                           (not task.display_in_project or task.project_id.id == vals['project_id']) and
            //                           task.milestone_id == task.parent_id.milestone_id and
            //                           task.state not in CLOSED_STATES))
            //     if subtasks_to_update:
            //         subtasks_to_update.sudo().write({'milestone_id': vals['milestone_id']})
            // 
            // if vals.get('parent_id') in self.ids:
            //     raise UserError(_("Sorry. You can't set a task as its parent task."))
            // 
            // # stage change: update date_last_stage_update
            // now = fields.Datetime.now()
            // if 'stage_id' in vals:
            //     if not 'project_id' in vals and self.filtered(lambda t: not t.project_id):
            //         raise UserError(_('You can only set a personal stage on a private task.'))
            // 
            //     additional_vals.update(self.update_date_end(vals['stage_id']))
            //     additional_vals['date_last_stage_update'] = now
            // task_ids_without_user_set = set()
            // if 'user_ids' in vals and 'date_assign' not in vals:
            //     # prepare update of date_assign after super call
            //     task_ids_without_user_set = {task.id for task in self if not task.user_ids}
            // 
            // # recurrence fields
            // rec_fields = vals.keys() & self._get_recurrence_fields()
            // if rec_fields:
            //     rec_values = {rec_field: vals[rec_field] for rec_field in rec_fields}
            //     for task in self:
            //         if task.recurrence_id:
            //             task.recurrence_id.write(rec_values)
            //         elif vals.get('recurring_task'):
            //             recurrence = self.env['project.task.recurrence'].create(rec_values)
            //             task.recurrence_id = recurrence.id
            // 
            // if not vals.get('recurring_task', True) and self.recurrence_id:
            //     tasks_in_recurrence = self.recurrence_id.task_ids
            //     self.recurrence_id.unlink()
            //     tasks_in_recurrence.write({'recurring_task': False})
            // 
            // # Track user_ids to send assignment notifications
            // old_user_ids = {t: t.user_ids for t in self.sudo()}
            // 
            // if "personal_stage_type_id" in vals and not vals['personal_stage_type_id']:
            //     del vals['personal_stage_type_id']
            // 
            // # sends an email to the 'Task Creation' subtype subscribers
            // # When project_id is changed
            // project_link_per_task_id = {}
            // if vals.get('project_id'):
            //     project = self.env['project.project'].browse(vals.get('project_id'))
            //     notification_subtype_id = self.env['ir.model.data']._xmlid_to_res_id('project.mt_project_task_new')
            //     partner_ids = project.message_follower_ids.filtered(lambda follower: notification_subtype_id in follower.subtype_ids.ids).partner_id.ids
            //     if partner_ids:
            //         link_per_project_id = {}
            //         for task in self:
            //             if task.project_id:
            //                 project_link = link_per_project_id.get(task.project_id.id)
            //                 if not project_link:
            //                     project_link = link_per_project_id[task.project_id.id] = task.project_id._get_html_link(title=task.project_id.display_name)
            //                 project_link_per_task_id[task.id] = project_link
            // if vals.get('parent_id') is False:
            //     additional_vals['display_in_project'] = True
            // if 'description' in vals:
            //     # the portal user cannot access to html_field_history and so it would be
            //     # better to write in sudo for description field to avoid giving access to html_field_history
            //     additional_vals['description'] = vals.pop('description')
            // 
            //     # write changes
            // if self.env.su or not self.env.user._is_portal():
            //     vals.update(additional_vals)
            // elif additional_vals:
            //     super(ProjectTask, self.sudo()).write(additional_vals)
            // result = super().write(vals)
            // 
            // if 'user_ids' in vals:
            //     self._populate_missing_personal_stages()
            // 
            // # user_ids change: update date_assign
            // if 'user_ids' in vals:
            //     for task in self.sudo():
            //         if not task.user_ids and task.date_assign:
            //             task.date_assign = False
            //         elif 'date_assign' not in vals and task.id in task_ids_without_user_set:
            //             task.date_assign = now
            // 
            // # rating on stage
            // if 'stage_id' in vals and vals.get('stage_id'):
            //     self.sudo().filtered(lambda x: x.stage_id.rating_active and x.stage_id.rating_status == 'stage')._send_task_rating_mail(force_send=True)
            // 
            // if 'state' in vals:
            //     # specific use case: when the blocked task goes from 'forced' done state to a not closed state, we fix the state back to waiting
            //     for task in self.sudo():
            //         if task.allow_task_dependencies:
            //             if task.is_blocked_by_dependences() and vals['state'] not in CLOSED_STATES and vals['state'] != '04_waiting_normal':
            //                 task.state = '04_waiting_normal'
            //         task.date_last_stage_update = now
            // elif 'project_id' in vals:
            //     self.filtered(lambda t: t.state != '04_waiting_normal').state = '01_in_progress'
            // 
            // # Do not recompute the state when changing the parent (to avoid resetting the state)
            // if 'parent_id' in vals:
            //     self.env.remove_to_compute(self._fields['state'], self)
            // 
            // self._task_message_auto_subscribe_notify({task: task.user_ids - old_user_ids[task] - self.env.user for task in self})
            // 
            // if partner_ids:
            //     for task in self:
            //         project_link = project_link_per_task_id.get(task.id)
            //         if project_link:
            //             body = _(
            //                 'Task Transferred from Project %(source_project)s to %(destination_project)s',
            //                 source_project=project_link,
            //                 destination_project=task.project_id._get_html_link(title=task.project_id.display_name),
            //             )
            //         else:
            //             body = _('Task Converted from To-Do')
            //         task.message_notify(
            //             body=body,
            //             partner_ids=partner_ids,
            //             email_layout_xmlid='mail.mail_notification_layout',
            //             notify_author_mention=False,
            //        )
            // return result
            --- ODOO METHOD SOURCE (MODULE: project_sms, FILE: project_task.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // 
            // if 'stage_id' in vals:
            //     # sudo as sms template model is protected
            //     self.sudo()._send_sms()
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_task.py) ---
            // def write(self, vals):
            // task = super().write(vals)
            // if sol_id := vals.get('sale_line_id'):
            //     self._ensure_sale_order_linked([sol_id])
            // return task
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}