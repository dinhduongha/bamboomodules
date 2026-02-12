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
    [Module("base", Category = "Base")]
    public partial class IrHttpAppService : ApplicationService, IIrHttpAppService
    {

        public IrHttpAppService() 
        {

        }

        [ApiModel]
        public async Task<TEntity> AddPublicKeyToSessionInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object session_info) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- METHOD SOURCE (MODULE: google_recaptcha, FILE: ir_http.py, METHOD: _add_public_key_to_session_info) ---
            */
            return default;
        }

        protected async Task<object> AuthMethodBearerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_http.py, METHOD: _auth_method_bearer) ---
            */
            return default;
        }

        protected async Task<object> AuthMethodCalendarInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: ir_http.py, METHOD: _auth_method_calendar) ---
            */
            return default;
        }

        protected async Task<object> AuthMethodNoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_http.py, METHOD: _auth_method_none) ---
            */
            return default;
        }

        protected async Task<object> AuthMethodOutlookInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail_plugin, FILE: ir_http.py, METHOD: _auth_method_outlook) ---
            */
            return default;
        }

        protected async Task<object> AuthMethodPublicInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_http.py, METHOD: _auth_method_public) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_http.py, METHOD: _auth_method_public) ---
            */
            return default;
        }

        protected async Task<object> AuthMethodUserInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_http.py, METHOD: _auth_method_user) ---
            */
            return default;
        }

        protected async Task<object> AuthenticateExplicitInternalAsync(object auth)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_http.py, METHOD: _authenticate_explicit) ---
            */
            return default;
        }

        protected async Task<object> AuthenticateInternalAsync(object endpoint)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: ir_http.py, METHOD: _authenticate) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_http.py, METHOD: _authenticate) ---
            */
            return default;
        }

        protected async Task<object> CheckIdentityInternalAsync(object credential)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: ir_http.py, METHOD: _check_identity) ---
            */
            return default;
        }

        public async Task<TEntity> ColorSchemeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: ir_http.py, METHOD: color_scheme) ---
            */
            return default;
        }

        protected async Task<object> DispatchInternalAsync(object endpoint)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_http.py, METHOD: _dispatch) ---
            */
            return default;
        }

        protected async Task<object> FrontendPreDispatchInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py, METHOD: _frontend_pre_dispatch) ---
            --- METHOD SOURCE (MODULE: website, FILE: ir_http.py, METHOD: _frontend_pre_dispatch) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: ir_http.py, METHOD: _frontend_pre_dispatch) ---
            */
            return default;
        }

        public async Task<TEntity> GcSessionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_http.py, METHOD: _gc_sessions) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateRoutingRulesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object modules, object converters) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_http.py, METHOD: _generate_routing_rules) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_http.py, METHOD: _generate_routing_rules) ---
            */
            return default;
        }

        protected async Task<object> GeoipResolveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_http.py, METHOD: _geoip_resolve) ---
            */
            return default;
        }

        protected async Task<object> GetConvertersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py, METHOD: _get_converters) ---
            --- METHOD SOURCE (MODULE: website, FILE: ir_http.py, METHOD: _get_converters) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_http.py, METHOD: _get_converters) ---
            */
            return default;
        }

        public async Task<TEntity> GetCurrenciesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: ir_http.py, METHOD: get_currencies) ---
            */
            return default;
        }

        protected async Task<object> GetDefaultLangInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py, METHOD: _get_default_lang) ---
            --- METHOD SOURCE (MODULE: website, FILE: ir_http.py, METHOD: _get_default_lang) ---
            */
            return default;
        }

        protected async Task<object> GetEditorContextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_http.py, METHOD: _get_editor_context) ---
            --- METHOD SOURCE (MODULE: website, FILE: ir_http.py, METHOD: _get_editor_context) ---
            */
            return default;
        }

        protected async Task<object> GetErrorHtmlInternalAsync(object env, object code, object values)
        {
            /*
            --- METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py, METHOD: _get_error_html) ---
            --- METHOD SOURCE (MODULE: website, FILE: ir_http.py, METHOD: _get_error_html) ---
            */
            return default;
        }

        protected async Task<object> GetExceptionCodeValuesInternalAsync(object exception)
        {
            /*
            --- METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py, METHOD: _get_exception_code_values) ---
            --- METHOD SOURCE (MODULE: website, FILE: ir_http.py, METHOD: _get_exception_code_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetFrontendSessionInfoAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: ir_http.py, METHOD: get_frontend_session_info) ---
            --- METHOD SOURCE (MODULE: bus, FILE: ir_http.py, METHOD: get_frontend_session_info) ---
            --- METHOD SOURCE (MODULE: google_recaptcha, FILE: ir_http.py, METHOD: get_frontend_session_info) ---
            --- METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py, METHOD: get_frontend_session_info) ---
            --- METHOD SOURCE (MODULE: web, FILE: ir_http.py, METHOD: get_frontend_session_info) ---
            --- METHOD SOURCE (MODULE: website, FILE: ir_http.py, METHOD: get_frontend_session_info) ---
            --- METHOD SOURCE (MODULE: website_cf_turnstile, FILE: ir_http.py, METHOD: get_frontend_session_info) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: ir_http.py, METHOD: get_frontend_session_info) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetNearestLangAsync<TEntity>(IEnumerable<TEntity> entities, object lang_code) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py, METHOD: get_nearest_lang) ---
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: ir_http.py, METHOD: get_nearest_lang) ---
            --- METHOD SOURCE (MODULE: survey, FILE: ir_http.py, METHOD: get_nearest_lang) ---
            --- METHOD SOURCE (MODULE: website, FILE: ir_http.py, METHOD: get_nearest_lang) ---
            */
            return default;
        }

        protected async Task<object> GetPublicUsersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_http.py, METHOD: _get_public_users) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_http.py, METHOD: _get_public_users) ---
            */
            return default;
        }

        public async Task<TEntity> GetRewritesInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid website_id) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_http.py, METHOD: _get_rewrites) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetTimesheetUomsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: ir_http.py, METHOD: get_timesheet_uoms) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<List<string>> GetTranslationFrontendModulesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py, METHOD: get_translation_frontend_modules) ---
            */
            return default;
        }

        protected async Task<List<object>> GetTranslationFrontendModulesDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py, METHOD: _get_translation_frontend_modules_domain) ---
            */
            return default;
        }

        protected async Task<object> GetTranslationFrontendModulesNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_password_policy_portal, FILE: ir_http.py, METHOD: _get_translation_frontend_modules_name) ---
            --- METHOD SOURCE (MODULE: auth_password_policy_signup, FILE: ir_http.py, METHOD: _get_translation_frontend_modules_name) ---
            --- METHOD SOURCE (MODULE: delivery, FILE: ir_http.py, METHOD: _get_translation_frontend_modules_name) ---
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_http.py, METHOD: _get_translation_frontend_modules_name) ---
            --- METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py, METHOD: _get_translation_frontend_modules_name) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: ir_http.py, METHOD: _get_translation_frontend_modules_name) ---
            --- METHOD SOURCE (MODULE: payment, FILE: ir_http.py, METHOD: _get_translation_frontend_modules_name) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: ir_http.py, METHOD: _get_translation_frontend_modules_name) ---
            --- METHOD SOURCE (MODULE: portal, FILE: ir_http.py, METHOD: _get_translation_frontend_modules_name) ---
            --- METHOD SOURCE (MODULE: portal_rating, FILE: ir_http.py, METHOD: _get_translation_frontend_modules_name) ---
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: ir_http.py, METHOD: _get_translation_frontend_modules_name) ---
            --- METHOD SOURCE (MODULE: survey, FILE: ir_http.py, METHOD: _get_translation_frontend_modules_name) ---
            --- METHOD SOURCE (MODULE: website, FILE: ir_http.py, METHOD: _get_translation_frontend_modules_name) ---
            --- METHOD SOURCE (MODULE: website_livechat, FILE: ir_http.py, METHOD: _get_translation_frontend_modules_name) ---
            --- METHOD SOURCE (MODULE: website_mail, FILE: ir_http.py, METHOD: _get_translation_frontend_modules_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetTranslationsForWebclientInternalAsync<TEntity>(IEnumerable<TEntity> entities, object modules, object lang) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- METHOD SOURCE (MODULE: base_import_module, FILE: ir_http.py, METHOD: _get_translations_for_webclient) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_http.py, METHOD: _get_translations_for_webclient) ---
            */
            return default;
        }

        public async Task<object> GetUtmDomainCookiesAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: utm, FILE: ir_http.py, METHOD: get_utm_domain_cookies) ---
            */
            return default;
        }

        protected async Task<object> GetValues500ErrorInternalAsync(object env, object values, object exception)
        {
            /*
            --- METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py, METHOD: _get_values_500_error) ---
            --- METHOD SOURCE (MODULE: website, FILE: ir_http.py, METHOD: _get_values_500_error) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetWebTranslationsHashInternalAsync<TEntity>(IEnumerable<TEntity> entities, object modules, object lang) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_http.py, METHOD: _get_web_translations_hash) ---
            */
            return default;
        }

        protected async Task<object> HandleDebugInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: ir_http.py, METHOD: _handle_debug) ---
            */
            return default;
        }

        protected async Task<object> HandleErrorInternalAsync(object exception)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: ir_http.py, METHOD: _handle_error) ---
            --- METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py, METHOD: _handle_error) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_http.py, METHOD: _handle_error) ---
            */
            return default;
        }

        public async Task<object> IsABotAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: ir_http.py, METHOD: is_a_bot) ---
            */
            return default;
        }

        protected async Task<object> IsAllowedCookieInternalAsync(object cookie_type)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_http.py, METHOD: _is_allowed_cookie) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_http.py, METHOD: _is_allowed_cookie) ---
            */
            return default;
        }

        protected async Task<bool> IsMultilangUrlInternalAsync(string local_url, object lang_url_codes)
        {
            /*
            --- METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py, METHOD: _is_multilang_url) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> IsSurveyFrontendInternalAsync<TEntity>(IEnumerable<TEntity> entities, object path) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: ir_http.py, METHOD: _is_survey_frontend) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LazySessionInfoAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: ir_http.py, METHOD: lazy_session_info) ---
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: ir_http.py, METHOD: lazy_session_info) ---
            --- METHOD SOURCE (MODULE: web, FILE: ir_http.py, METHOD: lazy_session_info) ---
            */
            return default;
        }

        protected async Task<object> MatchInternalAsync(object path_info)
        {
            /*
            --- METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py, METHOD: _match) ---
            --- METHOD SOURCE (MODULE: website, FILE: ir_http.py, METHOD: _match) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_http.py, METHOD: _match) ---
            */
            return default;
        }

        protected async Task<object> MustCheckIdentityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: ir_http.py, METHOD: _must_check_identity) ---
            */
            return default;
        }

        protected async Task<object> PostDispatchInternalAsync(object response)
        {
            /*
            --- METHOD SOURCE (MODULE: utm, FILE: ir_http.py, METHOD: _post_dispatch) ---
            --- METHOD SOURCE (MODULE: website, FILE: ir_http.py, METHOD: _post_dispatch) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_http.py, METHOD: _post_dispatch) ---
            */
            return default;
        }

        protected async Task<object> PostLogoutInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: ir_http.py, METHOD: _post_logout) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_http.py, METHOD: _post_logout) ---
            */
            return default;
        }

        protected async Task<object> PreDispatchInternalAsync(object rule, object args)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: ir_http.py, METHOD: _pre_dispatch) ---
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_http.py, METHOD: _pre_dispatch) ---
            --- METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py, METHOD: _pre_dispatch) ---
            --- METHOD SOURCE (MODULE: web, FILE: ir_http.py, METHOD: _pre_dispatch) ---
            --- METHOD SOURCE (MODULE: website, FILE: ir_http.py, METHOD: _pre_dispatch) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: ir_http.py, METHOD: _pre_dispatch) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_http.py, METHOD: _pre_dispatch) ---
            */
            return default;
        }

        protected async Task<object> RedirectInternalAsync(object location, object code)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_http.py, METHOD: _redirect) ---
            */
            return default;
        }

        protected async Task<object> RegisterWebsiteTrackInternalAsync(object response)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_http.py, METHOD: _register_website_track) ---
            */
            return default;
        }

        public async Task<int> RewriteLenInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid website_id) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_http.py, METHOD: _rewrite_len) ---
            */
            return default;
        }

        public async Task<TEntity> RoutingMapAsync<TEntity>(IEnumerable<TEntity> entities, object key) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_http.py, METHOD: routing_map) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_http.py, METHOD: routing_map) ---
            */
            return default;
        }

        protected async Task<object> SanitizeCookiesInternalAsync(object cookies)
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: ir_http.py, METHOD: _sanitize_cookies) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_http.py, METHOD: _sanitize_cookies) ---
            */
            return default;
        }

        protected async Task<object> ServeFallbackInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_http.py, METHOD: _serve_fallback) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_http.py, METHOD: _serve_fallback) ---
            */
            return default;
        }

        protected async Task<object> ServePageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_http.py, METHOD: _serve_page) ---
            --- METHOD SOURCE (MODULE: website_crm_iap_reveal, FILE: ir_http.py, METHOD: _serve_page) ---
            */
            return default;
        }

        protected async Task<object> ServeRedirectInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_http.py, METHOD: _serve_redirect) ---
            */
            return default;
        }

        public async Task<TEntity> SessionInfoAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: ir_http.py, METHOD: session_info) ---
            --- METHOD SOURCE (MODULE: barcodes, FILE: ir_http.py, METHOD: session_info) ---
            --- METHOD SOURCE (MODULE: barcodes_gs1_nomenclature, FILE: ir_http.py, METHOD: session_info) ---
            --- METHOD SOURCE (MODULE: base_setup, FILE: ir_http.py, METHOD: session_info) ---
            --- METHOD SOURCE (MODULE: bus, FILE: ir_http.py, METHOD: session_info) ---
            --- METHOD SOURCE (MODULE: cloud_storage, FILE: ir_http.py, METHOD: session_info) ---
            --- METHOD SOURCE (MODULE: google_recaptcha, FILE: ir_http.py, METHOD: session_info) ---
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: ir_http.py, METHOD: session_info) ---
            --- METHOD SOURCE (MODULE: mail, FILE: ir_http.py, METHOD: session_info) ---
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: ir_http.py, METHOD: session_info) ---
            --- METHOD SOURCE (MODULE: spreadsheet, FILE: ir_http.py, METHOD: session_info) ---
            --- METHOD SOURCE (MODULE: web, FILE: ir_http.py, METHOD: session_info) ---
            --- METHOD SOURCE (MODULE: web_tour, FILE: ir_http.py, METHOD: session_info) ---
            */
            return default;
        }

        public async Task<TEntity> SessionInfoCommonAuthTimeoutInternalAsync<TEntity>(IEnumerable<TEntity> entities, object session_info) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: ir_http.py, METHOD: _session_info_common_auth_timeout) ---
            */
            return default;
        }

        public async Task<TEntity> SetSessionInactivityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object session, object inactivity_period, object force) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: ir_http.py, METHOD: _set_session_inactivity) ---
            */
            return default;
        }

        protected async Task<object> SetUtmInternalAsync(object response)
        {
            /*
            --- METHOD SOURCE (MODULE: utm, FILE: ir_http.py, METHOD: _set_utm) ---
            */
            return default;
        }

        protected async Task<string> SlugInternalAsync(object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py, METHOD: _slug) ---
            --- METHOD SOURCE (MODULE: website, FILE: ir_http.py, METHOD: _slug) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_http.py, METHOD: _slug) ---
            */
            return default;
        }

        protected async Task<object> SlugMatchingInternalAsync(object adapter, object endpoint)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_http.py, METHOD: _slug_matching) ---
            */
            return default;
        }

        protected async Task<string> SlugifyInternalAsync(string @value, int max_length, bool path)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_http.py, METHOD: _slugify) ---
            */
            return default;
        }

        protected async Task<string> SlugifyOneInternalAsync(string @value, int max_length)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_http.py, METHOD: _slugify_one) ---
            */
            return default;
        }

        protected async Task<object> UnslugInternalAsync(string @value)
        {
            /*
            --- METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py, METHOD: _unslug) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_http.py, METHOD: _unslug) ---
            */
            return default;
        }

        protected async Task<string> UnslugUrlInternalAsync(string @value)
        {
            /*
            --- METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py, METHOD: _unslug_url) ---
            */
            return default;
        }

        protected async Task<string> UrlForInternalAsync(string url_from, object lang_code)
        {
            /*
            --- METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py, METHOD: _url_for) ---
            --- METHOD SOURCE (MODULE: website, FILE: ir_http.py, METHOD: _url_for) ---
            */
            return default;
        }

        protected async Task<string> UrlLangInternalAsync(string path_or_uri, object lang_code)
        {
            /*
            --- METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py, METHOD: _url_lang) ---
            */
            return default;
        }

        protected async Task<string> UrlLocalizedInternalAsync(object url, object lang_code, object canonical_domain, bool prefetch_langs, bool force_default_lang)
        {
            /*
            --- METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py, METHOD: _url_localized) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> UrlRewriteAsync<TEntity>(IEnumerable<TEntity> entities, object path, object query_args) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py, METHOD: url_rewrite) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> VerifyRecaptchaTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object ip_addr, object token, object action) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- METHOD SOURCE (MODULE: google_recaptcha, FILE: ir_http.py, METHOD: _verify_recaptcha_token) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> VerifyRequestRecaptchaTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, string action) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- METHOD SOURCE (MODULE: google_recaptcha, FILE: ir_http.py, METHOD: _verify_request_recaptcha_token) ---
            --- METHOD SOURCE (MODULE: website_cf_turnstile, FILE: ir_http.py, METHOD: _verify_request_recaptcha_token) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_http.py, METHOD: _verify_request_recaptcha_token) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> VerifyTurnstileTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object ip_addr, object token, object action) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- METHOD SOURCE (MODULE: website_cf_turnstile, FILE: ir_http.py, METHOD: _verify_turnstile_token) ---
            */
            return default;
        }

        public async Task<TEntity> WebclientRenderingContextAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: ir_http.py, METHOD: webclient_rendering_context) ---
            */
            return default;
        }
    }
}