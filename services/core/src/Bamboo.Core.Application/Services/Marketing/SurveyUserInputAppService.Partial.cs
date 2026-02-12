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
    public partial class SurveyUserInputAppService
    {

        protected async Task<SurveyUserInput> CheckForFailedAttemptInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides_survey, FILE: survey_user.py, METHOD: _check_for_failed_attempt) ---
            */
            return default;
        }

        protected async Task<SurveyUserInput> ClearInactiveConditionalAnswersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _clear_inactive_conditional_answers) ---
            */
            return default;
        }

        protected async Task<SurveyUserInput> ComputeAttemptsInfoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _compute_attempts_info) ---
            */
            return default;
        }

        protected async Task<SurveyUserInput> ComputeQuestionTimeLimitReachedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _compute_question_time_limit_reached) ---
            */
            return default;
        }

        protected async Task<SurveyUserInput> ComputeScoringSuccessInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _compute_scoring_success) ---
            */
            return default;
        }

        protected async Task<SurveyUserInput> ComputeScoringValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _compute_scoring_values) ---
            */
            return default;
        }

        protected async Task<SurveyUserInput> ComputeSurveyTimeLimitReachedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _compute_survey_time_limit_reached) ---
            */
            return default;
        }

        protected async Task<SurveyUserInput> CreateLeadsFromGenerativeAnswersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey_crm, FILE: survey_user_input.py, METHOD: _create_leads_from_generative_answers) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SurveyUserInput> GenerateInviteTokenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _generate_invite_token) ---
            */
            return default;
        }

        protected async Task<SurveyUserInput> GetConditionalValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _get_conditional_values) ---
            */
            return default;
        }

        protected async Task<SurveyUserInput> GetInactiveConditionalQuestionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _get_inactive_conditional_questions) ---
            */
            return default;
        }

        protected async Task<SurveyUserInput> GetLineAnswerValuesInternalAsync(object question, object answer, object answer_type)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _get_line_answer_values) ---
            */
            return default;
        }

        protected async Task<SurveyUserInput> GetLineCommentValuesInternalAsync(object question, object comment)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _get_line_comment_values) ---
            */
            return default;
        }

        protected async Task<SurveyUserInput> GetNextSkippedPageOrQuestionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _get_next_skipped_page_or_question) ---
            */
            return default;
        }

        protected async Task<SurveyUserInput> GetPrintQuestionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _get_print_questions) ---
            */
            return default;
        }

        protected async Task<SurveyUserInput> GetSelectedSuggestedAnswersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _get_selected_suggested_answers) ---
            */
            return default;
        }

        protected async Task<SurveyUserInput> GetSkippedQuestionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _get_skipped_questions) ---
            */
            return default;
        }

        protected async Task<SurveyUserInput> IsLastSkippedPageOrQuestionInternalAsync(object page_or_question)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _is_last_skipped_page_or_question) ---
            */
            return default;
        }

        protected async Task<SurveyUserInput> MarkDoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_survey, FILE: survey_user_input.py, METHOD: _mark_done) ---
            --- METHOD SOURCE (MODULE: hr_skills_survey, FILE: survey_user.py, METHOD: _mark_done) ---
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _mark_done) ---
            --- METHOD SOURCE (MODULE: survey_crm, FILE: survey_user_input.py, METHOD: _mark_done) ---
            */
            return default;
        }

        protected async Task<SurveyUserInput> MarkInProgressInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _mark_in_progress) ---
            */
            return default;
        }

        protected async Task<SurveyUserInput> MultipleChoiceQuestionAnswerResultInternalAsync(object user_input_lines, object question_correct_suggested_answers)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _multiple_choice_question_answer_result) ---
            */
            return default;
        }

        protected async Task<SurveyUserInput> NotifyNewParticipationSubscribersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _notify_new_participation_subscribers) ---
            */
            return default;
        }

        protected async Task<SurveyUserInput> PrepareCommonSurveyLeadValuesInternalAsync(object survey)
        {
            /*
            --- METHOD SOURCE (MODULE: survey_crm, FILE: survey_user_input.py, METHOD: _prepare_common_survey_lead_values) ---
            */
            return default;
        }

        protected async Task<SurveyUserInput> PrepareLeadValuesFromUserInputLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey_crm, FILE: survey_user_input.py, METHOD: _prepare_lead_values_from_user_input_lines) ---
            */
            return default;
        }

        protected async Task<SurveyUserInput> PrepareStatisticsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _prepare_statistics) ---
            */
            return default;
        }

        protected async Task<SurveyUserInput> PrepareUserInputLeadValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey_crm, FILE: survey_user_input.py, METHOD: _prepare_user_input_lead_values) ---
            */
            return default;
        }

        protected async Task<SurveyUserInput> SaveLineChoiceInternalAsync(object question, object old_answers, object answers, object comment)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _save_line_choice) ---
            */
            return default;
        }

        protected async Task<SurveyUserInput> SaveLineMatrixInternalAsync(object question, object old_answers, object answers, object comment)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _save_line_matrix) ---
            */
            return default;
        }

        protected async Task<SurveyUserInput> SaveLineSimpleAnswerInternalAsync(object question, object old_answers, object answer)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _save_line_simple_answer) ---
            */
            return default;
        }

        protected async Task<SurveyUserInput> SaveLinesInternalAsync(object question, object answer, object comment, object overwrite_existing)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _save_lines) ---
            */
            return default;
        }

        protected async Task<SurveyUserInput> SimpleChoiceQuestionAnswerResultInternalAsync(object user_input_line, object question_correct_suggested_answers, object question_incorrect_scored_answers)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _simple_choice_question_answer_result) ---
            */
            return default;
        }

        protected async Task<SurveyUserInput> SimpleQuestionAnswerResultInternalAsync(object user_input_line)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _simple_question_answer_result) ---
            */
            return default;
        }
    }
}