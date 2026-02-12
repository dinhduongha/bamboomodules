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
    public partial class HrCandidateAppService
    {

        protected async Task<HrCandidate> CheckInterviewerAccessInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py, METHOD: _check_interviewer_access) ---
            */
            return default;
        }

        protected async Task<HrCandidate> ComputeApplicationCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py, METHOD: _compute_application_count) ---
            */
            return default;
        }

        protected async Task<HrCandidate> ComputeApplicationsCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py, METHOD: _compute_applications_count) ---
            */
            return default;
        }

        protected async Task<HrCandidate> ComputeAttachmentCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py, METHOD: _compute_attachment_count) ---
            */
            return default;
        }

        protected async Task<HrCandidate> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<HrCandidate> ComputeMatchingSkillIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_candidate.py, METHOD: _compute_matching_skill_ids) ---
            */
            return default;
        }

        protected async Task<HrCandidate> ComputeMeetingDisplayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py, METHOD: _compute_meeting_display) ---
            */
            return default;
        }

        protected async Task<HrCandidate> ComputePartnerPhoneEmailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py, METHOD: _compute_partner_phone_email) ---
            */
            return default;
        }

        protected async Task<HrCandidate> ComputePartnerPhoneSanitizedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py, METHOD: _compute_partner_phone_sanitized) ---
            */
            return default;
        }

        protected async Task<HrCandidate> ComputePriorityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py, METHOD: _compute_priority) ---
            */
            return default;
        }

        protected async Task<HrCandidate> ComputeSimilarCandidatesCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py, METHOD: _compute_similar_candidates_count) ---
            */
            return default;
        }

        protected async Task<HrCandidate> ComputeSkillIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_candidate.py, METHOD: _compute_skill_ids) ---
            */
            return default;
        }

        protected async Task<HrCandidate> GetEmployeeCreateValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py, METHOD: _get_employee_create_vals) ---
            --- METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_candidate.py, METHOD: _get_employee_create_vals) ---
            */
            return default;
        }

        protected async Task<HrCandidate> GetSimilarCandidatesDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py, METHOD: _get_similar_candidates_domain) ---
            */
            return default;
        }

        protected async Task<HrCandidate> InversePartnerEmailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py, METHOD: _inverse_partner_email) ---
            */
            return default;
        }

        protected async Task<HrCandidate> PhoneGetNumberFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py, METHOD: _phone_get_number_fields) ---
            */
            return default;
        }

        protected async Task<HrCandidate> UnlinkExceptLinkedEmployeeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py, METHOD: _unlink_except_linked_employee) ---
            */
            return default;
        }
    }
}