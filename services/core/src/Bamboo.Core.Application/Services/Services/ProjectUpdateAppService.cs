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
    public partial class ProjectUpdateAppService : GenericAppService<ProjectUpdate>, IProjectUpdateAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadCcAppService _mailThreadCcAppService;
        public ProjectUpdateAppService(IRepository<ProjectUpdate, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadCcAppService mailThreadCcAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadCcAppService = mailThreadCcAppService;
        }

        [ApiModel]
        protected async Task<ProjectUpdate> BuildDescriptionInternalAsync(object project)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_update.py) ---
            // def _build_description(self, project):
            // return self.env['ir.qweb']._render('project.project_update_default_description', self._get_template_values(project))
            */
            return default;
        }

        protected async Task<ProjectUpdate> ComputeClosedTaskPercentageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_update.py) ---
            // def _compute_closed_task_percentage(self):
            // for update in self:
            //     update.closed_task_percentage = update.task_count and round(update.closed_task_count * 100 / update.task_count)
            */
            return default;
        }

        protected async Task<ProjectUpdate> ComputeColorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_update.py) ---
            // def _compute_color(self):
            // for update in self:
            //     update.color = STATUS_COLOR[update.status]
            */
            return default;
        }

        protected async Task<ProjectUpdate> ComputeDisplayTimesheetStatsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_update.py) ---
            // def _compute_display_timesheet_stats(self):
            // for update in self:
            //     update.display_timesheet_stats = update.project_id.allow_timesheets
            */
            return default;
        }

        protected async Task<ProjectUpdate> ComputeNameCroppedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_update.py) ---
            // def _compute_name_cropped(self):
            // for update in self:
            //     update.name_cropped = (update.name[:57] + '...') if update.name and len(update.name) > 60 else update.name
            */
            return default;
        }

        protected async Task<ProjectUpdate> ComputeProgressPercentageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_update.py) ---
            // def _compute_progress_percentage(self):
            // for update in self:
            //     update.progress_percentage = update.progress / 100
            */
            return default;
        }

        protected async Task<ProjectUpdate> ComputeTimesheetPercentageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_update.py) ---
            // def _compute_timesheet_percentage(self):
            // for update in self:
            //     update.timesheet_percentage = update.allocated_time and round(update.timesheet_time * 100 / update.allocated_time)
            */
            return default;
        }

        public override async Task<ProjectUpdate> CreateAsync(CreateRequestDto<ProjectUpdate> input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_update.py) ---
            // def create(self, vals_list):
            // updates = super().create(vals_list)
            // encode_uom = self.env.company.timesheet_encode_uom_id
            // ratio = self.env.ref("uom.product_uom_hour").factor / encode_uom.factor
            // for update in updates:
            //     project = update.project_id
            //     project.sudo().last_update_id = update
            //     update.write({
            //         "uom_id": encode_uom,
            //         "allocated_time": round(project.allocated_hours * ratio),
            //         "timesheet_time": round(project.sudo().total_timesheet_time),
            //     })
            // return updates
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_update.py) ---
            // def create(self, vals_list):
            // updates = super().create(vals_list)
            // for update in updates:
            //     project = update.project_id
            //     project.sudo().last_update_id = update
            //     update.write({
            //         "task_count": project.task_count,
            //         "closed_task_count": project.task_count - project.open_task_count,
            //     })
            // return updates
            */
            return await base.CreateAsync(input);
        }

        [ApiModel]
        protected async Task<ProjectUpdate> GetLastUpdatedMilestoneInternalAsync(object project)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_update.py) ---
            // def _get_last_updated_milestone(self, project):
            // query = """
            //     SELECT DISTINCT pm.id as milestone_id,
            //                     pm.deadline as deadline,
            //                     FIRST_VALUE(old_value_datetime::date) OVER w_partition as old_value,
            //                     pm.deadline as new_value
            //                FROM mail_message mm
            //          INNER JOIN mail_tracking_value mtv
            //                  ON mm.id = mtv.mail_message_id
            //          INNER JOIN ir_model_fields imf
            //                  ON mtv.field_id = imf.id
            //                 AND imf.model = 'project.milestone'
            //                 AND imf.name = 'deadline'
            //          INNER JOIN project_milestone pm
            //                  ON mm.res_id = pm.id
            //               WHERE mm.model = 'project.milestone'
            //                 AND mm.message_type = 'notification'
            //                 AND pm.project_id = %(project_id)s
            //  """
            // if project.last_update_id.create_date:
            //     query = query + "AND mm.date > %(last_update_date)s"
            // query = query + """
            //              WINDOW w_partition AS (
            //                      PARTITION BY pm.id
            //                      ORDER BY mm.date ASC
            //                     )
            //            ORDER BY pm.deadline ASC
            //            LIMIT 1;
            // """
            // query_params = {'project_id': project.id}
            // if project.last_update_id.create_date:
            //     query_params['last_update_date'] = project.last_update_id.create_date
            // self.env.cr.execute(query, query_params)
            // results = self.env.cr.dictfetchall()
            // mapped_result = {res['milestone_id']: {'new_value': res['new_value'], 'old_value': res['old_value']} for res in results}
            // milestones = self.env['project.milestone'].search([('id', 'in', list(mapped_result.keys()))])
            // return [{
            //     **milestone._get_data(),
            //     'new_value': mapped_result[milestone.id]['new_value'],
            //     'old_value': mapped_result[milestone.id]['old_value'],
            // } for milestone in milestones]
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectUpdate> GetMilestoneValuesInternalAsync(object project)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_update.py) ---
            // def _get_milestone_values(self, project):
            // Milestone = self.env['project.milestone']
            // if not project.allow_milestones:
            //     return {
            //         'show_section': False,
            //         'list': [],
            //         'updated': [],
            //         'last_update_date': None,
            //         'created': []
            //     }
            // list_milestones = Milestone.search(
            //     [('project_id', '=', project.id),
            //      '|', ('deadline', '<', fields.Date.context_today(self) + relativedelta(years=1)), ('deadline', '=', False)])._get_data_list()
            // updated_milestones = self._get_last_updated_milestone(project)
            // domain = Domain('project_id', '=', project.id)
            // if project.last_update_id.create_date:
            //     domain &= Domain('create_date', '>', project.last_update_id.create_date)
            // created_milestones = Milestone.search(domain)._get_data_list()
            // return {
            //     'show_section': (list_milestones or updated_milestones or created_milestones) and True or False,
            //     'list': list_milestones,
            //     'updated': updated_milestones,
            //     'last_update_date': project.last_update_id.create_date or None,
            //     'created': created_milestones,
            // }
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectUpdate> GetTemplateValuesInternalAsync(object project)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_update.py) ---
            // def _get_template_values(self, project):
            // milestones = self._get_milestone_values(project)
            // profitability_values, show_profitability = project._get_profitability_values()
            // return {
            //     'user': self.env.user,
            //     'project': project,
            //     'profitability': profitability_values,
            //     'show_profitability': show_profitability,
            //     'show_activities': milestones['show_section'],
            //     'milestones': milestones,
            //     'format_lang': lambda value, digits: formatLang(self.env, value, digits=digits),
            //     'format_monetary': lambda value: format_amount(self.env, value, project.currency_id, trailing_zeroes=False),
            // }
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: project_update.py) ---
            // def _get_template_values(self, project):
            // template_values = super()._get_template_values(project)
            // profitability_values = template_values.get('profitability')
            // if profitability_values and 'revenues' in profitability_values and 'data' in profitability_values['revenues']:
            //     for section in profitability_values['revenues']['data']:
            //         all_sols = self.env['sale.order.line'].sudo().search(
            //             project._get_domain_from_section_id(section["id"]),
            //         )
            //         sols = all_sols.with_context(with_price_unit=True)._read_format([
            //             'name', 'product_uom_qty', 'qty_delivered', 'qty_invoiced', 'product_uom_id', 'product_id'
            //         ])
            //         for sol in sols:
            //             if sol['product_uom_id'][1] == 'Hours':
            //                 sol['product_uom_qty'] = format_duration(sol['product_uom_qty'])
            //                 sol['qty_delivered'] = format_duration(sol['qty_delivered'])
            //                 sol['qty_invoiced'] = format_duration(sol['qty_invoiced'])
            //         section["sol"] = sols
            // return template_values
            */
            return default;
        }
    }
}