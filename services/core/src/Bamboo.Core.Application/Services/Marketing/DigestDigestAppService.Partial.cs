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
    public partial class DigestDigestAppService
    {

        protected async Task<DigestDigest> ActionSendInternalAsync(object update_periodicity)
        {
            /*
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: _action_send) ---
            */
            return default;
        }

        protected async Task<DigestDigest> ActionSendToUserInternalAsync(object user, object tips_count, object consume_tips)
        {
            /*
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: _action_send_to_user) ---
            */
            return default;
        }

        protected async Task<DigestDigest> ActionSubscribeUsersInternalAsync(object users)
        {
            /*
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: _action_subscribe_users) ---
            */
            return default;
        }

        protected async Task<DigestDigest> ActionUnsubscribeUsersInternalAsync(object users)
        {
            /*
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: _action_unsubscribe_users) ---
            */
            return default;
        }

        protected async Task<DigestDigest> CalculateCompanyBasedKpiInternalAsync(object model, object digest_kpi_field, object date_field, object additional_domain, object sum_field)
        {
            /*
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: _calculate_company_based_kpi) ---
            */
            return default;
        }

        protected async Task<DigestDigest> CheckDailyLogsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: _check_daily_logs) ---
            */
            return default;
        }

        protected async Task<DigestDigest> ComputeAvailableFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: _compute_available_fields) ---
            */
            return default;
        }

        protected async Task<DigestDigest> ComputeIsSubscribedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: _compute_is_subscribed) ---
            */
            return default;
        }

        protected async Task<DigestDigest> ComputeKpiAccountTotalRevenueValueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: digest.py, METHOD: _compute_kpi_account_total_revenue_value) ---
            */
            return default;
        }

        protected async Task<DigestDigest> ComputeKpiCrmLeadCreatedValueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: digest.py, METHOD: _compute_kpi_crm_lead_created_value) ---
            */
            return default;
        }

        protected async Task<DigestDigest> ComputeKpiCrmOpportunitiesWonValueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: digest.py, METHOD: _compute_kpi_crm_opportunities_won_value) ---
            */
            return default;
        }

        protected async Task<DigestDigest> ComputeKpiHrRecruitmentNewColleaguesValueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: digest.py, METHOD: _compute_kpi_hr_recruitment_new_colleagues_value) ---
            */
            return default;
        }

        protected async Task<DigestDigest> ComputeKpiLivechatConversationsValueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: digest.py, METHOD: _compute_kpi_livechat_conversations_value) ---
            */
            return default;
        }

        protected async Task<DigestDigest> ComputeKpiLivechatRatingValueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: digest.py, METHOD: _compute_kpi_livechat_rating_value) ---
            */
            return default;
        }

        protected async Task<DigestDigest> ComputeKpiLivechatResponseValueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: digest.py, METHOD: _compute_kpi_livechat_response_value) ---
            */
            return default;
        }

        protected async Task<DigestDigest> ComputeKpiMailMessageTotalValueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: _compute_kpi_mail_message_total_value) ---
            */
            return default;
        }

        protected async Task<DigestDigest> ComputeKpiPosTotalValueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: digest.py, METHOD: _compute_kpi_pos_total_value) ---
            */
            return default;
        }

        protected async Task<DigestDigest> ComputeKpiResUsersConnectedValueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: _compute_kpi_res_users_connected_value) ---
            */
            return default;
        }

        protected async Task<DigestDigest> ComputeKpiSaleTotalValueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_management, FILE: digest.py, METHOD: _compute_kpi_sale_total_value) ---
            */
            return default;
        }

        protected async Task<DigestDigest> ComputeKpiWebsiteSaleTotalValueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: digest.py, METHOD: _compute_kpi_website_sale_total_value) ---
            */
            return default;
        }

        protected async Task<DigestDigest> ComputeKpisActionsInternalAsync(object company, object user)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: digest.py, METHOD: _compute_kpis_actions) ---
            --- METHOD SOURCE (MODULE: crm, FILE: digest.py, METHOD: _compute_kpis_actions) ---
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: _compute_kpis_actions) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: digest.py, METHOD: _compute_kpis_actions) ---
            --- METHOD SOURCE (MODULE: im_livechat, FILE: digest.py, METHOD: _compute_kpis_actions) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: digest.py, METHOD: _compute_kpis_actions) ---
            --- METHOD SOURCE (MODULE: project, FILE: digest_digest.py, METHOD: _compute_kpis_actions) ---
            --- METHOD SOURCE (MODULE: sale_management, FILE: digest.py, METHOD: _compute_kpis_actions) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: digest.py, METHOD: _compute_kpis_actions) ---
            */
            return default;
        }

        protected async Task<DigestDigest> ComputeKpisInternalAsync(object company, object user)
        {
            /*
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: _compute_kpis) ---
            */
            return default;
        }

        protected async Task<DigestDigest> ComputePreferencesInternalAsync(object company, object user)
        {
            /*
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: _compute_preferences) ---
            */
            return default;
        }

        protected async Task<DigestDigest> ComputeProjectTaskOpenedValueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: digest_digest.py, METHOD: _compute_project_task_opened_value) ---
            */
            return default;
        }

        protected async Task<DigestDigest> ComputeTimeframesInternalAsync(object company)
        {
            /*
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: _compute_timeframes) ---
            */
            return default;
        }

        protected async Task<DigestDigest> ComputeTipsInternalAsync(object company, object user, object tips_count, object consumed)
        {
            /*
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: _compute_tips) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<DigestDigest> CronSendDigestEmailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: _cron_send_digest_email) ---
            */
            return default;
        }

        protected async Task<DigestDigest> FormatCurrencyAmountInternalAsync(object amount, Guid currency_id)
        {
            /*
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: _format_currency_amount) ---
            */
            return default;
        }

        protected async Task<DigestDigest> GetKpiComputeParametersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: _get_kpi_compute_parameters) ---
            */
            return default;
        }

        protected async Task<DigestDigest> GetKpiFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: _get_kpi_fields) ---
            */
            return default;
        }

        protected async Task<DigestDigest> GetMarginValueInternalAsync(object @value, object previous_value)
        {
            /*
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: _get_margin_value) ---
            */
            return default;
        }

        protected async Task<DigestDigest> GetNextPeriodicityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: _get_next_periodicity) ---
            */
            return default;
        }

        protected async Task<DigestDigest> GetNextRunDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: _get_next_run_date) ---
            */
            return default;
        }

        protected async Task<DigestDigest> GetUnsubscribeTokenInternalAsync(Guid user_id)
        {
            /*
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: _get_unsubscribe_token) ---
            */
            return default;
        }

        protected async Task<DigestDigest> OnchangePeriodicityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: _onchange_periodicity) ---
            */
            return default;
        }
    }
}