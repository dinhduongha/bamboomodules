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
    public partial class HrJobAppService
    {

        [ApiModel]
        protected async Task<HrJob> ActionLoadRecruitmentScenarioInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _action_load_recruitment_scenario) ---
            */
            return default;
        }

        protected async Task<HrJob> AddressIdDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _address_id_domain) ---
            */
            return default;
        }

        protected async Task<HrJob> AliasGetCreationValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _alias_get_creation_values) ---
            */
            return default;
        }

        protected async Task<HrJob> ComputeActivitiesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_activities) ---
            */
            return default;
        }

        protected async Task<HrJob> ComputeAllApplicationCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_all_application_count) ---
            */
            return default;
        }

        protected async Task<HrJob> ComputeAllowedUserIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_job.py, METHOD: _compute_allowed_user_ids) ---
            */
            return default;
        }

        protected async Task<HrJob> ComputeApplicantHiredInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_applicant_hired) ---
            */
            return default;
        }

        protected async Task<HrJob> ComputeApplicantMatchingScoreInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_job.py, METHOD: _compute_applicant_matching_score) ---
            */
            return default;
        }

        protected async Task<HrJob> ComputeApplicationCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_application_count) ---
            */
            return default;
        }

        protected async Task<HrJob> ComputeCurrentJobSkillIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_job.py, METHOD: _compute_current_job_skill_ids) ---
            */
            return default;
        }

        protected async Task<HrJob> ComputeDocumentIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_document_ids) ---
            */
            return default;
        }

        protected async Task<HrJob> ComputeEmployeeCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_employee_count) ---
            */
            return default;
        }

        protected async Task<HrJob> ComputeEmployeesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_job.py, METHOD: _compute_employees) ---
            */
            return default;
        }

        protected async Task<HrJob> ComputeExtendedInterviewerIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_extended_interviewer_ids) ---
            */
            return default;
        }

        protected async Task<HrJob> ComputeFullUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _compute_full_url) ---
            */
            return default;
        }

        protected async Task<HrJob> ComputeIsFavoriteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_is_favorite) ---
            */
            return default;
        }

        protected async Task<HrJob> ComputeNewApplicationCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_new_application_count) ---
            */
            return default;
        }

        protected async Task<HrJob> ComputeNoOfHiredEmployeeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_no_of_hired_employee) ---
            */
            return default;
        }

        protected async Task<HrJob> ComputeOldApplicationCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_old_application_count) ---
            */
            return default;
        }

        protected async Task<HrJob> ComputeOpenApplicationCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_open_application_count) ---
            */
            return default;
        }

        protected async Task<HrJob> ComputePublishedDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _compute_published_date) ---
            */
            return default;
        }

        protected async Task<HrJob> ComputeSkillIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_job.py, METHOD: _compute_skill_ids) ---
            */
            return default;
        }

        protected async Task<HrJob> ComputeWebsiteUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _compute_website_url) ---
            */
            return default;
        }

        protected async Task<HrJob> CreationSubtypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _creation_subtype) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrJob> DefaultAddressIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _default_address_id) ---
            */
            return default;
        }

        protected async Task<HrJob> GetDefaultFavoriteUserIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _get_default_favorite_user_ids) ---
            */
            return default;
        }

        protected async Task<HrJob> GetDefaultJobDetailsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _get_default_job_details) ---
            */
            return default;
        }

        protected async Task<HrJob> GetDefaultWebsiteDescriptionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _get_default_website_description) ---
            */
            return default;
        }

        protected async Task<HrJob> GetFirstStageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _get_first_stage) ---
            */
            return default;
        }

        protected async Task<HrJob> InverseIsFavoriteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _inverse_is_favorite) ---
            */
            return default;
        }

        protected async Task<HrJob> OnchangeWebsitePublishedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _onchange_website_published) ---
            */
            return default;
        }

        protected async Task<HrJob> OrderFieldToSqlInternalAsync(object @alias, object field_name, object direction, object nulls, object query)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _order_field_to_sql) ---
            */
            return default;
        }

        protected async Task<HrJob> SearchCurrentJobSkillIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_job.py, METHOD: _search_current_job_skill_ids) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrJob> SearchGetDetailInternalAsync(object website, object order, object options)
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _search_get_detail) ---
            */
            return default;
        }
    }
}