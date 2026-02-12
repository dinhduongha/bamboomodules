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
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("hr_skills", Category = "HumanResources", Depends = new[] { "hr" })]
    public partial class HrIndividualSkillMixinAppService : ApplicationService, IHrIndividualSkillMixinAppService
    {

        public HrIndividualSkillMixinAppService() 
        {

        }

        public async Task<TEntity> ActionSaveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee_skill.py, METHOD: action_save) ---
            */
            return default;
        }

        public async Task<TEntity> CanEditCertificationValidityPeriodInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_individual_skill_mixin.py, METHOD: _can_edit_certification_validity_period) ---
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_job_skill.py, METHOD: _can_edit_certification_validity_period) ---
            */
            return default;
        }

        public async Task<TEntity> CheckDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_individual_skill_mixin.py, METHOD: _check_date) ---
            */
            return default;
        }

        public async Task<TEntity> CheckNotOverlappingRegularSkillInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_individual_skill_mixin.py, METHOD: _check_not_overlapping_regular_skill) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSkillLevelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_individual_skill_mixin.py, METHOD: _check_skill_level) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSkillTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_individual_skill_mixin.py, METHOD: _check_skill_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCertificationSkillTypeCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_individual_skill_mixin.py, METHOD: _compute_certification_skill_type_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_individual_skill_mixin.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSkillIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_individual_skill_mixin.py, METHOD: _compute_skill_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSkillLevelIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_individual_skill_mixin.py, METHOD: _compute_skill_level_id) ---
            */
            return default;
        }

        public async Task<TEntity> CreateIndividualSkillsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_individual_skill_mixin.py, METHOD: _create_individual_skills) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultSkillTypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_individual_skill_mixin.py, METHOD: _default_skill_type_id) ---
            */
            return default;
        }

        public async Task<TEntity> ExpireIndividualSkillsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_individual_skill_mixin.py, METHOD: _expire_individual_skills) ---
            */
            return default;
        }

        public async Task<TEntity> GetCurrentSkillsByApplicantInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_applicant_skill.py, METHOD: _get_current_skills_by_applicant) ---
            */
            return default;
        }

        public async Task<TEntity> GetCurrentSkillsByEmployeeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee_skill.py, METHOD: get_current_skills_by_employee) ---
            */
            return default;
        }

        public async Task<TEntity> GetOverlappingIndividualSkillInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_individual_skill_mixin.py, METHOD: _get_overlapping_individual_skill) ---
            */
            return default;
        }

        public async Task<TEntity> GetPassiveFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_individual_skill_mixin.py, METHOD: _get_passive_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetTransformedCommandsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object commands, object individuals) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_individual_skill_mixin.py, METHOD: _get_transformed_commands) ---
            */
            return default;
        }

        public async Task<TEntity> LinkedFieldNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_applicant_skill.py, METHOD: _linked_field_name) ---
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee_skill.py, METHOD: _linked_field_name) ---
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_individual_skill_mixin.py, METHOD: _linked_field_name) ---
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_job_skill.py, METHOD: _linked_field_name) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeIsCertificationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_individual_skill_mixin.py, METHOD: _onchange_is_certification) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeValidDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_individual_skill_mixin.py, METHOD: _onchange_valid_date) ---
            */
            return default;
        }

        public async Task<TEntity> OpenHrEmployeeSkillModalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee_skill.py, METHOD: open_hr_employee_skill_modal) ---
            */
            return default;
        }

        public async Task<TEntity> WriteIndividualSkillsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object commands) where TEntity : IEntity<Guid>, IHrIndividualSkillMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_individual_skill_mixin.py, METHOD: _write_individual_skills) ---
            */
            return default;
        }
    }
}