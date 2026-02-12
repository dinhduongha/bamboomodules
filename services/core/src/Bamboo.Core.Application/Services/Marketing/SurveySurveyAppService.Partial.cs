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
    public partial class SurveySurveyAppService
    {

        protected async Task<SurveySurvey> CanGoBackInternalAsync(object answer, object page_or_question)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _can_go_back) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> CheckAnswerCreationInternalAsync(object user, object partner, object email, object test_entry, object check_attempts, object invite_token)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _check_answer_creation) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> CheckScoringAfterPageAvailabilityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _check_scoring_after_page_availability) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> CheckSurveyResponsibleAccessInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _check_survey_responsible_access) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> ComputeAllowedSurveyTypesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_survey, FILE: survey_survey.py, METHOD: _compute_allowed_survey_types) ---
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_allowed_survey_types) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> ComputeAnswerDurationAvgInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_answer_duration_avg) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> ComputeBackgroundImageUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_background_image_url) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> ComputeCertificationGiveBadgeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_certification_give_badge) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> ComputeCertificationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_certification) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> ComputeGenerateLeadInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey_crm, FILE: survey_survey.py, METHOD: _compute_generate_lead) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> ComputeHasConditionalQuestionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_has_conditional_questions) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> ComputeIsAttemptsLimitedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_is_attempts_limited) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> ComputeLeadCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey_crm, FILE: survey_survey.py, METHOD: _compute_lead_count) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> ComputePageAndQuestionIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_page_and_question_ids) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> ComputeScoringMaxObtainableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_scoring_max_obtainable) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> ComputeScoringTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_scoring_type) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> ComputeSessionAnswerCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_session_answer_count) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> ComputeSessionAvailableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_session_available) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> ComputeSessionCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_session_code) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> ComputeSessionLinkInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_session_link) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> ComputeSessionQuestionAnswerCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_session_question_answer_count) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> ComputeSessionShowLeaderboardInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_session_show_leaderboard) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> ComputeSlideChannelDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides_survey, FILE: survey_survey.py, METHOD: _compute_slide_channel_data) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> ComputeSurveyStatisticInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_survey_statistic) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> ComputeUsersCanSignupInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_users_can_signup) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> CreateAnswerInternalAsync(object user, object partner, object email, object test_entry, object check_attempts)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _create_answer) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> CreateCertificationBadgeTriggerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _create_certification_badge_trigger) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> GenerateSessionCodesInternalAsync(object code_count, object excluded_codes)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _generate_session_codes) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> GetConditionalMapsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _get_conditional_maps) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SurveySurvey> GetDefaultAccessTokenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _get_default_access_token) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> GetNextPageOrQuestionInternalAsync(object user_input, Guid page_or_question_id, object go_back)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _get_next_page_or_question) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> GetNumberOfAttemptsLeftsInternalAsync(object partner, object email, object invite_token)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _get_number_of_attempts_lefts) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> GetPagesAndQuestionsToShowInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _get_pages_and_questions_to_show) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SurveySurvey> GetPagesOrQuestionsInternalAsync(object user_input)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _get_pages_or_questions) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> GetSessionMostVotedAnswersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _get_session_most_voted_answers) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> GetSessionNextQuestionInternalAsync(object go_back)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _get_session_next_question) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> GetSupportedLangCodesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _get_supported_lang_codes) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> GetSurveyQuestionsInternalAsync(object answer, Guid page_id, Guid question_id)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _get_survey_questions) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> GetSurveyTemplateValuesInternalAsync(object template_key)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _get_survey_template_values) ---
            --- METHOD SOURCE (MODULE: survey_crm, FILE: survey_survey.py, METHOD: _get_survey_template_values) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> HandleCertificationBadgesInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _handle_certification_badges) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> HasAttemptsLeftInternalAsync(object partner, object email, object invite_token)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _has_attempts_left) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> IsFirstPageOrQuestionInternalAsync(object page_or_question)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _is_first_page_or_question) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> IsLastPageOrQuestionInternalAsync(object user_input, object page_or_question)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _is_last_page_or_question) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> OnchangeRestrictUserIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _onchange_restrict_user_ids) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> OnchangeSessionSpeedRatingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _onchange_session_speed_rating) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> OnchangeSurveyTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _onchange_survey_type) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SurveySurvey> PrepareAssessmentTemplateValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _prepare_assessment_template_values) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> PrepareChallengeCategoryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _prepare_challenge_category) ---
            --- METHOD SOURCE (MODULE: website_slides_survey, FILE: survey_survey.py, METHOD: _prepare_challenge_category) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SurveySurvey> PrepareLeadQualificationTemplateValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey_crm, FILE: survey_survey.py, METHOD: _prepare_lead_qualification_template_values) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> PrepareLeaderboardValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _prepare_leaderboard_values) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SurveySurvey> PrepareLiveSessionTemplateValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _prepare_live_session_template_values) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> PrepareStatisticsInternalAsync(object user_input_lines)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _prepare_statistics) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SurveySurvey> PrepareSurveyTemplateValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _prepare_survey_template_values) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> PrepareUserInputPredefinedQuestionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _prepare_user_input_predefined_questions) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> SessionOpenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _session_open) ---
            */
            return default;
        }

        protected async Task<SurveySurvey> UnlinkExceptLinkedToCourseInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides_survey, FILE: survey_survey.py, METHOD: _unlink_except_linked_to_course) ---
            */
            return default;
        }
    }
}