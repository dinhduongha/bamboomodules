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
    public partial class WebsiteVisitorAppService
    {

        protected async Task<WebsiteVisitor> AddTrackingInternalAsync(object domain, object website_track_values)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_visitor.py, METHOD: _add_tracking) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> AddViewedProductInternalAsync(Guid product_id)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website_visitor.py, METHOD: _add_viewed_product) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> AutoInitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_livechat, FILE: website_visitor.py, METHOD: _auto_init) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> CheckForMessageComposerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_visitor.py, METHOD: _check_for_message_composer) ---
            --- METHOD SOURCE (MODULE: website_crm, FILE: website_visitor.py, METHOD: _check_for_message_composer) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> CheckForSmsComposerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_sms, FILE: website_visitor.py, METHOD: _check_for_sms_composer) ---
            --- METHOD SOURCE (MODULE: website_sms, FILE: website_visitor.py, METHOD: _check_for_sms_composer) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_visitor.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: website_visitor.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> ComputeEmailPhoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_visitor.py, METHOD: _compute_email_phone) ---
            --- METHOD SOURCE (MODULE: website_crm, FILE: website_visitor.py, METHOD: _compute_email_phone) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: website_visitor.py, METHOD: _compute_email_phone) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> ComputeEventRegisteredIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: website_visitor.py, METHOD: _compute_event_registered_ids) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> ComputeEventRegistrationCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: website_visitor.py, METHOD: _compute_event_registration_count) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> ComputeEventTrackWishlistedIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: website_visitor.py, METHOD: _compute_event_track_wishlisted_ids) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> ComputeLastVisitedPageIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_visitor.py, METHOD: _compute_last_visited_page_id) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> ComputeLeadCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm, FILE: website_visitor.py, METHOD: _compute_lead_count) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> ComputeLivechatOperatorIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_livechat, FILE: website_visitor.py, METHOD: _compute_livechat_operator_id) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> ComputePageStatisticsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_visitor.py, METHOD: _compute_page_statistics) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> ComputePartnerIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_visitor.py, METHOD: _compute_partner_id) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> ComputeProductStatisticsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website_visitor.py, METHOD: _compute_product_statistics) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> ComputeSessionCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_livechat, FILE: website_visitor.py, METHOD: _compute_session_count) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> ComputeTimeStatisticsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_visitor.py, METHOD: _compute_time_statistics) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> CronUnlinkOldVisitorsInternalAsync(object batch_size)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_visitor.py, METHOD: _cron_unlink_old_visitors) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> FieldStoreReprInternalAsync(object field_name)
        {
            /*
            --- METHOD SOURCE (MODULE: website_livechat, FILE: website_visitor.py, METHOD: _field_store_repr) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> GetAccessTokenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_visitor.py, METHOD: _get_access_token) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> GetVisitorFromRequestInternalAsync(object force_create, object force_track_values)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_visitor.py, METHOD: _get_visitor_from_request) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> GetVisitorHistoryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_livechat, FILE: website_visitor.py, METHOD: _get_visitor_history) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> GetVisitorTimezoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_visitor.py, METHOD: _get_visitor_timezone) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> HandleWebpageDispatchInternalAsync(object website_page)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_visitor.py, METHOD: _handle_webpage_dispatch) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> InactiveVisitorsDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_visitor.py, METHOD: _inactive_visitors_domain) ---
            --- METHOD SOURCE (MODULE: website_crm, FILE: website_visitor.py, METHOD: _inactive_visitors_domain) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: website_visitor.py, METHOD: _inactive_visitors_domain) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: website_visitor.py, METHOD: _inactive_visitors_domain) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> MergeVisitorInternalAsync(object target)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_visitor.py, METHOD: _merge_visitor) ---
            --- METHOD SOURCE (MODULE: website_crm, FILE: website_visitor.py, METHOD: _merge_visitor) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: website_visitor.py, METHOD: _merge_visitor) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: website_visitor.py, METHOD: _merge_visitor) ---
            --- METHOD SOURCE (MODULE: website_livechat, FILE: website_visitor.py, METHOD: _merge_visitor) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> PrepareMessageComposerContextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_visitor.py, METHOD: _prepare_message_composer_context) ---
            --- METHOD SOURCE (MODULE: website_crm, FILE: website_visitor.py, METHOD: _prepare_message_composer_context) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> PrepareSmsComposerContextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_sms, FILE: website_visitor.py, METHOD: _prepare_sms_composer_context) ---
            --- METHOD SOURCE (MODULE: website_sms, FILE: website_visitor.py, METHOD: _prepare_sms_composer_context) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> SearchEventRegisteredIdsInternalAsync(object @operator, object operand)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: website_visitor.py, METHOD: _search_event_registered_ids) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> SearchEventTrackWishlistedIdsInternalAsync(object @operator, object operand)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: website_visitor.py, METHOD: _search_event_track_wishlisted_ids) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> SearchPageIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_visitor.py, METHOD: _search_page_ids) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> UpdateVisitorLastVisitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_visitor.py, METHOD: _update_visitor_last_visit) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> UpdateVisitorTimezoneInternalAsync(object timezone)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_visitor.py, METHOD: _update_visitor_timezone) ---
            */
            return default;
        }

        protected async Task<WebsiteVisitor> UpsertVisitorInternalAsync(object access_token, object force_track_values)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_visitor.py, METHOD: _upsert_visitor) ---
            --- METHOD SOURCE (MODULE: website_livechat, FILE: website_visitor.py, METHOD: _upsert_visitor) ---
            */
            return default;
        }
    }
}