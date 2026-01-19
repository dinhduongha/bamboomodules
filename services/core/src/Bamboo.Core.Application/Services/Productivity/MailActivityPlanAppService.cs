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
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Mail", Category = "Productivity", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public partial class MailActivityPlanAppService : GenericApplicationService<MailActivityPlan>, IMailActivityPlanAppService
    {

        public MailActivityPlanAppService(IRepository<MailActivityPlan, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<MailActivityPlan> CheckCompatibilityWithModelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: mail_activity_plan.py) ---
            // def _check_compatibility_with_model(self):
            // """ Check that when the model is updated to a model different from employee,
            // there are no remaining specific values to employee. """
            // plan_tocheck = self.filtered(lambda plan: not plan.department_assignable)
            // failing_plans = plan_tocheck.filtered('department_id')
            // if failing_plans:
            //     raise UserError(
            //         _('Plan %(plan_names)s cannot use a department as it is used only for some HR plans.',
            //           plan_names=', '.join(failing_plans.mapped('name')))
            //     )
            // plan_tocheck = self.filtered(lambda plan: plan.res_model != 'hr.employee')
            // failing_templates = plan_tocheck.template_ids.filtered(
            //     lambda tpl: tpl.responsible_type in {'coach', 'manager', 'employee'}
            // )
            // if failing_templates:
            //     raise UserError(
            //         _('Plan activities %(template_names)s cannot use coach, manager or employee responsible as it is used only for employee plans.',
            //           template_names=', '.join(failing_templates.mapped('activity_type_id.name')))
            //     )
            */
            return default;
        }

        protected async Task<MailActivityPlan> CheckResModelCompatibilityWithTemplatesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_activity_plan.py) ---
            // def _check_res_model_compatibility_with_templates(self):
            // self.template_ids._check_activity_type_res_model()
            */
            return default;
        }

        protected async Task<MailActivityPlan> ComputeDepartmentAssignableInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: mail_activity_plan.py) ---
            // def _compute_department_assignable(self):
            // for plan in self:
            //     plan.department_assignable = plan.res_model == 'hr.employee'
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: mail_activity_plan.py) ---
            // def _compute_department_assignable(self):
            // super()._compute_department_assignable()
            // for plan in self:
            //     if not plan.department_assignable:
            //         plan.department_assignable = plan.res_model == 'hr.applicant'
            */
            return default;
        }

        protected async Task<MailActivityPlan> ComputeDepartmentIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: mail_activity_plan.py) ---
            // def _compute_department_id(self):
            // for plan in self.filtered(lambda plan: not plan.department_assignable):
            //     plan.department_id = False
            */
            return default;
        }

        protected async Task<MailActivityPlan> ComputeHasUserOnDemandInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_activity_plan.py) ---
            // def _compute_has_user_on_demand(self):
            // self.has_user_on_demand = False
            // for plan in self.filtered('template_ids'):
            //     plan.has_user_on_demand = any(template.responsible_type == 'on_demand' for template in plan.template_ids)
            */
            return default;
        }

        protected async Task<MailActivityPlan> ComputeResModelIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_activity_plan.py) ---
            // def _compute_res_model_id(self):
            // for plan in self:
            //     if plan.res_model:
            //         # New records may not have the required "res_model" field set yet
            //         # (in onchange)
            //         plan.res_model_id = self.env['ir.model']._get_id(plan.res_model)
            //     else:
            //         plan.res_model_id = False
            */
            return default;
        }

        protected async Task<MailActivityPlan> ComputeStepsCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_activity_plan.py) ---
            // def _compute_steps_count(self):
            // for plan in self:
            //     plan.steps_count = len(plan.template_ids)
            */
            return default;
        }

        public async Task<MailActivityPlan> CopyDataAsync(Guid id, MailActivityPlanCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_activity_plan.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // if 'name' not in default:
            //     for plan, vals in zip(self, vals_list):
            //         vals['name'] = _("%s (copy)", plan.name)
            // return vals_list
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MailActivityPlan> GetModelSelectionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_activity_plan.py) ---
            // def _get_model_selection(self):
            // return [
            //     (model.model, model.name)
            //     for model in self.env['ir.model'].sudo().search(
            //         ['&', ('is_mail_activity', '=', True), ('transient', '=', False)])
            // ]
            */
            return default;
        }
    }
}