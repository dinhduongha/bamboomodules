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
    public partial class SurveyQuestionAppService
    {

        protected async Task<SurveyQuestion> CheckQuestionTypeForPagesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _check_question_type_for_pages) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> ComputeAllowedTriggeringQuestionIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _compute_allowed_triggering_question_ids) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> ComputeBackgroundImageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _compute_background_image) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> ComputeBackgroundImageUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _compute_background_image_url) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> ComputeGenerateLeadInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey_crm, FILE: survey_question.py, METHOD: _compute_generate_lead) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> ComputeHasImageOnlySuggestedAnswerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _compute_has_image_only_suggested_answer) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> ComputeIsScoredQuestionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _compute_is_scored_question) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> ComputePageIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _compute_page_id) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> ComputeQuestionIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _compute_question_ids) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> ComputeQuestionPlaceholderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _compute_question_placeholder) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> ComputeQuestionTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _compute_question_type) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> ComputeSaveAsEmailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _compute_save_as_email) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> ComputeSaveAsNicknameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _compute_save_as_nickname) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> ComputeTriggeringQuestionIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _compute_triggering_question_ids) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> ComputeValidationRequiredInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _compute_validation_required) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> GetCorrectAnswersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _get_correct_answers) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> GetStatsDataAnswersInternalAsync(object user_input_lines)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _get_stats_data_answers) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> GetStatsDataInternalAsync(object user_input_lines)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _get_stats_data) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> GetStatsDataScaleInternalAsync(object user_input_lines)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _get_stats_data_scale) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> GetStatsGraphDataMatrixInternalAsync(object user_input_lines)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _get_stats_graph_data_matrix) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> GetStatsSummaryDataChoiceInternalAsync(object user_input_lines)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _get_stats_summary_data_choice) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> GetStatsSummaryDataInternalAsync(object user_input_lines)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _get_stats_summary_data) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> GetStatsSummaryDataNumericalInternalAsync(object user_input_lines, object fname)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _get_stats_summary_data_numerical) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> GetStatsSummaryDataScoredInternalAsync(object user_input_lines)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _get_stats_summary_data_scored) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> IndexInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _index) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> OnchangeValidationParametersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _onchange_validation_parameters) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> PrepareStatisticsInternalAsync(object user_input_lines)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _prepare_statistics) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> UnlinkExceptLiveSessionsInProgressInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _unlink_except_live_sessions_in_progress) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> UpdateTimeLimitFromSurveyInternalAsync(object is_time_limited, object time_limit)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _update_time_limit_from_survey) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> ValidateCharBoxInternalAsync(object answer)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _validate_char_box) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> ValidateChoiceInternalAsync(object answer, object comment)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _validate_choice) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> ValidateDateInternalAsync(object answer)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _validate_date) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> ValidateMatrixInternalAsync(object answers)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _validate_matrix) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> ValidateNumericalBoxInternalAsync(object answer)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _validate_numerical_box) ---
            */
            return default;
        }

        protected async Task<SurveyQuestion> ValidateScaleInternalAsync(object answer)
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_question.py, METHOD: _validate_scale) ---
            */
            return default;
        }
    }
}