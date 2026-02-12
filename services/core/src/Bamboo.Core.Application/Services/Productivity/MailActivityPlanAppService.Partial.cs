using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
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
    public partial class MailActivityPlanAppService
    {

        protected async Task<MailActivityPlan> CheckCompatibilityWithModelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: mail_activity_plan.py, METHOD: _check_compatibility_with_model) ---
            */
            return default;
        }

        protected async Task<MailActivityPlan> CheckResModelCompatibilityWithTemplatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity_plan.py, METHOD: _check_res_model_compatibility_with_templates) ---
            */
            return default;
        }

        protected async Task<MailActivityPlan> ComputeDepartmentAssignableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: mail_activity_plan.py, METHOD: _compute_department_assignable) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: mail_activity_plan.py, METHOD: _compute_department_assignable) ---
            */
            return default;
        }

        protected async Task<MailActivityPlan> ComputeDepartmentIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: mail_activity_plan.py, METHOD: _compute_department_id) ---
            */
            return default;
        }

        protected async Task<MailActivityPlan> ComputeHasUserOnDemandInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity_plan.py, METHOD: _compute_has_user_on_demand) ---
            */
            return default;
        }

        protected async Task<MailActivityPlan> ComputeResModelIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity_plan.py, METHOD: _compute_res_model_id) ---
            */
            return default;
        }

        protected async Task<MailActivityPlan> ComputeStepsCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity_plan.py, METHOD: _compute_steps_count) ---
            */
            return default;
        }

        protected async Task<MailActivityPlan> GetModelSelectionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_activity_plan.py, METHOD: _get_model_selection) ---
            */
            return default;
        }
    }
}