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
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;

namespace Bamboo.Core.Application.Services
{
    [Module("Project", Depends = new[] { "analytic", "base_setup", "mail", "portal", "rating", "resource", "web", "web_tour", "digest" })]
    public class ProjectUpdateAppService : GenericApplicationService<ProjectUpdate>, IProjectUpdateAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadCcAppService _mailThreadCcAppService;
        public ProjectUpdateAppService(IRepository<ProjectUpdate, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadCcAppService mailThreadCcAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadCcAppService = mailThreadCcAppService;
        }

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
            //     update.name_cropped = (update.name[:57] + '...') if len(update.name) > 60 else update.name
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

        public override async Task<ProjectUpdate> CreateAsync(ProjectUpdate entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: project_update.py) ---
            // def create(self, vals_list):
            // updates = super().create(vals_list)
            // encode_uom = self.env.company.timesheet_encode_uom_id
            // ratio = self.env.ref("uom.product_uom_hour").ratio / encode_uom.ratio
            // for update in updates:
            //     project = update.project_id
            //     project.sudo().last_update_id = update
            //     update.write({
            //         "uom_id": encode_uom,
            //         "allocated_time": round(project.allocated_hours / ratio),
            //         "timesheet_time": round(project.total_timesheet_time / ratio),
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
            return await base.CreateAsync(entity, fields);
        }

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
            // domain = [('project_id', '=', project.id)]
            // if project.last_update_id.create_date:
            //     domain = expression.AND([domain, [('create_date', '>', project.last_update_id.create_date)]])
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

        protected async Task<ProjectUpdate> GetProfitabilityValuesInternalAsync(object project)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_update.py) ---
            // def _get_profitability_values(self, project):
            // costs_revenues = project.account_id and project.allow_billable
            // if not (self.env.user.has_group('project.group_project_manager') and costs_revenues):
            //     return {}
            // profitability_items = project._get_profitability_items(False)
            // if project._get_profitability_sequence_per_invoice_type() and profitability_items and 'revenues' in profitability_items and 'costs' in profitability_items:  # sort the data values
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
            // return {
            //     'account_id': project.account_id,
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
            //     'labels': project._get_profitability_labels(),
            // }
            */
            return default;
        }

        protected async Task<ProjectUpdate> GetTemplateValuesInternalAsync(object project)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_update.py) ---
            // def _get_template_values(self, project):
            // milestones = self._get_milestone_values(project)
            // return {
            //     'user': self.env.user,
            //     'project': project,
            //     'show_activities': milestones['show_section'],
            //     'milestones': milestones,
            //     'format_lang': lambda value, digits: formatLang(self.env, value, digits=digits),
            //     'format_monetary': lambda value: format_amount(self.env, value, project.currency_id),
            // }
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: project_update.py) ---
            // def _get_template_values(self, project):
            // template_values = super(ProjectUpdate, self)._get_template_values(project)
            // profitability_values = self._get_profitability_values(project)
            // show_profitability = bool(profitability_values and profitability_values.get('account_id') and (profitability_values.get('costs') or profitability_values.get('revenues')))
            // return {
            //     **template_values,
            //     'show_profitability': show_profitability,
            //     'show_activities': template_values['show_activities'] or show_profitability,
            //     'profitability': profitability_values,
            //     'format_value': lambda value, is_hour: str(round(value, 2)) if not is_hour else format_duration(value),
            // }
            */
            return default;
        }
    }
}