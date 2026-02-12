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
    public partial class HrApplicantAppService
    {

        protected async Task<HrApplicant> CheckInterviewerAccessInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _check_interviewer_access) ---
            */
            return default;
        }

        protected async Task<HrApplicant> CheckTalentPoolRequiredInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _check_talent_pool_required) ---
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeApplicationCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_application_count) ---
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeApplicationStatusInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_application_status) ---
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeCompanyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_company) ---
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeCurrentApplicantSkillIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_applicant.py, METHOD: _compute_current_applicant_skill_ids) ---
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeDateClosedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_date_closed) ---
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeDayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_day) ---
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeDelayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_delay) ---
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeDepartmentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_department) ---
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeIsApplicantInPoolInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_is_applicant_in_pool) ---
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeIsPoolInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_is_pool) ---
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeMatchingSkillIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_applicant.py, METHOD: _compute_matching_skill_ids) ---
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeMeetingDisplayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_meeting_display) ---
            */
            return default;
        }

        protected async Task<HrApplicant> ComputePartnerPhoneEmailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_partner_phone_email) ---
            */
            return default;
        }

        protected async Task<HrApplicant> ComputePartnerPhoneSanitizedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_partner_phone_sanitized) ---
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeSkillIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_applicant.py, METHOD: _compute_skill_ids) ---
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeStageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_stage) ---
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeTalentPoolCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_talent_pool_count) ---
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeUserInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_user) ---
            */
            return default;
        }

        protected async Task<HrApplicant> CreationSubtypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _creation_subtype) ---
            */
            return default;
        }

        protected async Task<HrApplicant> GetAttachmentNumberInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _get_attachment_number) ---
            */
            return default;
        }

        protected async Task<HrApplicant> GetCustomerInformationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _get_customer_information) ---
            */
            return default;
        }

        protected async Task<HrApplicant> GetDurationFromTrackingInternalAsync(object trackings)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _get_duration_from_tracking) ---
            */
            return default;
        }

        protected async Task<HrApplicant> GetEmployeeCreateValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _get_employee_create_vals) ---
            --- METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_applicant.py, METHOD: _get_employee_create_vals) ---
            */
            return default;
        }

        protected async Task<HrApplicant> GetRottingDependsFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _get_rotting_depends_fields) ---
            */
            return default;
        }

        protected async Task<HrApplicant> GetRottingDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _get_rotting_domain) ---
            */
            return default;
        }

        protected async Task<HrApplicant> GetSimilarApplicantsDomainInternalAsync(object ignore_talent, object only_talent)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _get_similar_applicants_domain) ---
            */
            return default;
        }

        protected async Task<HrApplicant> InversePartnerEmailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _inverse_partner_email) ---
            */
            return default;
        }

        protected async Task<HrApplicant> MapApplicantSkillIdsToTalentSkillIdsInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_applicant.py, METHOD: _map_applicant_skill_ids_to_talent_skill_ids) ---
            */
            return default;
        }

        protected async Task<HrApplicant> MessagePostAfterHookInternalAsync(object message, object msg_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _message_post_after_hook) ---
            */
            return default;
        }

        protected async Task<HrApplicant> NotifyGetReplyToInternalAsync(object @default, Guid author_id)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _notify_get_reply_to) ---
            */
            return default;
        }

        protected async Task<HrApplicant> PhoneGetNumberFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _phone_get_number_fields) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrApplicant> ReadGroupStageIdsInternalAsync(object stages, object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _read_group_stage_ids) ---
            */
            return default;
        }

        protected async Task<HrApplicant> SearchApplicationStatusInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _search_application_status) ---
            */
            return default;
        }

        protected async Task<HrApplicant> SearchIsApplicantInPoolInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _search_is_applicant_in_pool) ---
            */
            return default;
        }

        protected async Task<HrApplicant> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        protected async Task<HrApplicant> TrackTemplateInternalAsync(object changes)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _track_template) ---
            */
            return default;
        }
    }
}