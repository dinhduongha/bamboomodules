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
    [Module("Project", Depends = new[] { "analytic", "base_setup", "mail", "portal", "rating", "resource", "web", "web_tour", "digest" })]
    public class ProjectMilestoneAppService : GenericApplicationService<ProjectMilestone>, IProjectMilestoneAppService
    {
        private readonly IMailThreadAppService _mailThreadAppService;
        public ProjectMilestoneAppService(IRepository<ProjectMilestone, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailThreadAppService = mailThreadAppService;
        }

        protected async Task<ProjectMilestone> ComputeCanBeMarkedAsDoneInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_milestone.py) ---
            // def _compute_can_be_marked_as_done(self):
            // if not any(self._ids):
            //     for milestone in self:
            //         milestone.can_be_marked_as_done = not milestone.is_reached and all(milestone.task_ids.mapped(lambda t: t.is_closed))
            //     return
            // 
            // unreached_milestones = self.filtered(lambda milestone: not milestone.is_reached)
            // (self - unreached_milestones).can_be_marked_as_done = False
            // task_read_group = self.env['project.task']._read_group(
            //     [('milestone_id', 'in', unreached_milestones.ids)],
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
            // for milestone in unreached_milestones:
            //     opened_task_count, closed_task_count = task_count_per_milestones[milestone.id]
            //     milestone.can_be_marked_as_done = closed_task_count > 0 and not opened_task_count
            */
            return default;
        }

        protected async Task<ProjectMilestone> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_milestone.py) ---
            // def _compute_display_name(self):
            // super()._compute_display_name()
            // if not self._context.get('display_milestone_deadline'):
            //     return
            // for milestone in self:
            //     if milestone.deadline:
            //         milestone.display_name = f'{milestone.display_name} - {format_date(self.env, milestone.deadline)}'
            */
            return default;
        }

        protected async Task<ProjectMilestone> ComputeIsDeadlineExceededInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_milestone.py) ---
            // def _compute_is_deadline_exceeded(self):
            // today = fields.Date.context_today(self)
            // for ms in self:
            //     ms.is_deadline_exceeded = not ms.is_reached and ms.deadline and ms.deadline < today
            */
            return default;
        }

        protected async Task<ProjectMilestone> ComputeIsDeadlineFutureInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_milestone.py) ---
            // def _compute_is_deadline_future(self):
            // for ms in self:
            //     ms.is_deadline_future = ms.deadline and ms.deadline > fields.Date.context_today(self)
            */
            return default;
        }

        protected async Task<ProjectMilestone> ComputeProductUomQtyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_milestone.py) ---
            // def _compute_product_uom_qty(self):
            // for milestone in self:
            //     if milestone.quantity_percentage:
            //         milestone.product_uom_qty = milestone.quantity_percentage * milestone.sale_line_id.product_uom_qty
            //     else:
            //         milestone.product_uom_qty = milestone.sale_line_id.product_uom_qty
            */
            return default;
        }

        protected async Task<ProjectMilestone> ComputeQuantityPercentageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_milestone.py) ---
            // def _compute_quantity_percentage(self):
            // for milestone in self:
            //     milestone.quantity_percentage = milestone.sale_line_id.product_uom_qty and milestone.product_uom_qty / milestone.sale_line_id.product_uom_qty
            */
            return default;
        }

        protected async Task<ProjectMilestone> ComputeReachedDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_milestone.py) ---
            // def _compute_reached_date(self):
            // for ms in self:
            //     ms.reached_date = ms.is_reached and fields.Date.context_today(self)
            */
            return default;
        }

        protected async Task<ProjectMilestone> ComputeTaskCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_milestone.py) ---
            // def _compute_task_count(self):
            // all_and_done_task_count_per_milestone = {
            //     milestone.id: (count, sum(state in CLOSED_STATES for state in state_list))
            //     for milestone, count, state_list in self.env['project.task']._read_group(
            //         [('milestone_id', 'in', self.ids), ('allow_milestones', '=', True)],
            //         ['milestone_id'], ['__count', 'state:array_agg'],
            //     )
            // }
            // for milestone in self:
            //     milestone.task_count, milestone.done_task_count = all_and_done_task_count_per_milestone.get(milestone.id, (0, 0))
            */
            return default;
        }

        protected async Task<ProjectMilestone> DefaultSaleLineIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_milestone.py) ---
            // def _default_sale_line_id(self):
            // project_id = self._context.get('default_project_id')
            // if not project_id:
            //     return []
            // project = self.env['project.project'].browse(project_id)
            // return self.env['sale.order.line'].search([
            //     ('order_id', '=', project.sale_order_id.id),
            //     ('qty_delivered_method', '=', 'milestones'),
            // ], limit=1)
            */
            return default;
        }

        protected async Task<ProjectMilestone> GetDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_milestone.py) ---
            // def _get_data(self):
            // self.ensure_one()
            // return {field: self[field] for field in self._get_fields_to_export()}
            */
            return default;
        }

        protected async Task<ProjectMilestone> GetDataListInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_milestone.py) ---
            // def _get_data_list(self):
            // return [ms._get_data() for ms in self]
            */
            return default;
        }

        protected async Task<ProjectMilestone> GetDefaultProjectIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_milestone.py) ---
            // def _get_default_project_id(self):
            // return self.env.context.get('default_project_id') or self.env.context.get('active_id')
            */
            return default;
        }

        protected async Task<ProjectMilestone> GetFieldsToExportInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_milestone.py) ---
            // def _get_fields_to_export(self):
            // return ['id', 'name', 'deadline', 'is_reached', 'reached_date', 'is_deadline_exceeded', 'is_deadline_future', 'can_be_marked_as_done']
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_milestone.py) ---
            // def _get_fields_to_export(self):
            // return super()._get_fields_to_export() + ['allow_billable', 'quantity_percentage', 'sale_line_display_name']
            */
            return default;
        }

        public async Task<ProjectMilestone> ToggleIsReachedAsync(Guid id, ProjectMilestoneToggleIsReachedRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_milestone.py) ---
            // def toggle_is_reached(self, is_reached):
            // self.ensure_one()
            // self.update({'is_reached': is_reached})
            // return self._get_data()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectMilestone> ViewSaleOrderAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_milestone.py) ---
            // def action_view_sale_order(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Sales Order'),
            //     'res_model': 'sale.order',
            //     'res_id': self.sale_line_id.order_id.id,
            //     'view_mode': 'form',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ProjectMilestone> ViewTasksAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_milestone.py) ---
            // def action_view_tasks(self):
            // self.ensure_one()
            // action = self.env['ir.actions.act_window']._for_xml_id('project.action_view_task_from_milestone')
            // action['context'] = {'default_project_id': self.project_id.id, 'default_milestone_id': self.id}
            // if self.task_count == 1:
            //     action['view_mode'] = 'form'
            //     action['res_id'] = self.task_ids.id
            //     if 'views' in action:
            //         action['views'] = [(view_id, view_type) for view_id, view_type in action['views'] if view_type == 'form']
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}