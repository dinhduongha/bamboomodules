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
    public partial class ResUsersAppService
    {

        protected async Task<ResUsers> ActionResetPasswordInternalAsync(object signup_type)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py, METHOD: _action_reset_password) ---
            */
            return default;
        }

        protected async Task<ResUsers> ActionRevokeAllDevicesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _action_revoke_all_devices) ---
            */
            return default;
        }

        protected async Task<ResUsers> ActionShowInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _action_show) ---
            */
            return default;
        }

        protected async Task<ResUsers> AddKarmaBatchInternalAsync(object values_per_user)
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: res_users.py, METHOD: _add_karma_batch) ---
            */
            return default;
        }

        protected async Task<ResUsers> AddKarmaInternalAsync(object gain, object source, object reason)
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: res_users.py, METHOD: _add_karma) ---
            */
            return default;
        }

        protected async Task<ResUsers> AssertCanAuthInternalAsync(object user)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _assert_can_auth) ---
            */
            return default;
        }

        protected async Task<ResUsers> AuthOauthRpcInternalAsync(object endpoint, object access_token)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_oauth, FILE: res_users.py, METHOD: _auth_oauth_rpc) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResUsers> AuthOauthSigninInternalAsync(object provider, object validation, object @params)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_oauth, FILE: res_users.py, METHOD: _auth_oauth_signin) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResUsers> AuthOauthValidateInternalAsync(object provider, object access_token)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_oauth, FILE: res_users.py, METHOD: _auth_oauth_validate) ---
            */
            return default;
        }

        protected async Task<ResUsers> BusChannelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: bus, FILE: res_users.py, METHOD: _bus_channel) ---
            */
            return default;
        }

        protected async Task<ResUsers> CanImportRemoteUrlsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_import, FILE: base_import.py, METHOD: _can_import_remote_urls) ---
            */
            return default;
        }

        protected async Task<ResUsers> CanManageUnsplashSettingsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: web_unsplash, FILE: res_users.py, METHOD: _can_manage_unsplash_settings) ---
            */
            return default;
        }

        protected async Task<ResUsers> ChangePasswordInternalAsync(object new_passwd)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _change_password) ---
            */
            return default;
        }

        protected async Task<ResUsers> CheckActionIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _check_action_id) ---
            */
            return default;
        }

        protected async Task<ResUsers> CheckAtLeastOneAdministratorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _check_at_least_one_administrator) ---
            */
            return default;
        }

        protected async Task<ResUsers> CheckCompanyDomainInternalAsync(object companies)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _check_company_domain) ---
            */
            return default;
        }

        protected async Task<ResUsers> CheckCredentialsInternalAsync(object credential, object env)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_ldap, FILE: res_users.py, METHOD: _check_credentials) ---
            --- METHOD SOURCE (MODULE: auth_oauth, FILE: res_users.py, METHOD: _check_credentials) ---
            --- METHOD SOURCE (MODULE: auth_passkey, FILE: res_users.py, METHOD: _check_credentials) ---
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: _check_credentials) ---
            --- METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py, METHOD: _check_credentials) ---
            --- METHOD SOURCE (MODULE: website_sale_wishlist, FILE: res_users.py, METHOD: _check_credentials) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _check_credentials) ---
            */
            return default;
        }

        protected async Task<ResUsers> CheckDisjointGroupsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_users.py, METHOD: _check_disjoint_groups) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _check_disjoint_groups) ---
            */
            return default;
        }

        protected async Task<ResUsers> CheckLoginInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_users.py, METHOD: _check_login) ---
            */
            return default;
        }

        protected async Task<ResUsers> CheckPasswordPolicyInternalAsync(object passwords)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_password_policy, FILE: res_users.py, METHOD: _check_password_policy) ---
            */
            return default;
        }

        protected async Task<ResUsers> CheckPendingOdooRecordsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: _check_pending_odoo_records) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResUsers> CheckUidPasswdInternalAsync(object uid, object passwd)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _check_uid_passwd) ---
            */
            return default;
        }

        protected async Task<ResUsers> CheckUserCompanyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _check_user_company) ---
            */
            return default;
        }

        protected async Task<ResUsers> CleanAttendanceOfficersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: res_users.py, METHOD: _clean_attendance_officers) ---
            */
            return default;
        }

        protected async Task<ResUsers> CleanLeaveResponsibleUsersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: res_users.py, METHOD: _clean_leave_responsible_users) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeAccessesCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _compute_accesses_count) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeAllGroupIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _compute_all_group_ids) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeCalendarDefaultPrivacyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_users.py, METHOD: _compute_calendar_default_privacy) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeCanEditRoleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _compute_can_edit_role) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeCompaniesCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _compute_companies_count) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeCompanyEmployeeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: _compute_company_employee) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeCrmTeamIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: res_users.py, METHOD: _compute_crm_team_ids) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: res_users.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: res_users.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeEmailDomainPlaceholderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _compute_email_domain_placeholder) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeEmployeeCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: _compute_employee_count) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeHasAccessLivechatInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py, METHOD: _compute_has_access_livechat) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeHasExternalMailServerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _compute_has_external_mail_server) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeHasOauthAccessTokenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_oauth, FILE: res_users.py, METHOD: _compute_has_oauth_access_token) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeImStatusInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: res_users.py, METHOD: _compute_im_status) ---
            --- METHOD SOURCE (MODULE: hr_homeworking, FILE: res_users.py, METHOD: _compute_im_status) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _compute_im_status) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeIsHrUserInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: _compute_is_hr_user) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeIsOutOfOfficeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _compute_is_out_of_office) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeIsSystemInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: _compute_is_system) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeKarmaInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: res_users.py, METHOD: _compute_karma) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeLivechatExpertiseIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py, METHOD: _compute_livechat_expertise_ids) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeLivechatIsInCallInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py, METHOD: _compute_livechat_is_in_call) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeLivechatLangIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py, METHOD: _compute_livechat_lang_ids) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeLivechatOngoingSessionCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py, METHOD: _compute_livechat_ongoing_session_count) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeLivechatUsernameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py, METHOD: _compute_livechat_username) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeNotificationTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _compute_notification_type) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeOutgoingMailServerIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _compute_outgoing_mail_server_id) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputePasswordInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _compute_password) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeResUsersSettingsIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _compute_res_users_settings_id) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeRoleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _compute_role) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeSaleTeamIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: res_users.py, METHOD: _compute_sale_team_id) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeSessionTokenInternalAsync(object sid)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _compute_session_token) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeShareInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _compute_share) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeSignatureInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _compute_signature) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py, METHOD: _compute_state) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeTotpEnabledInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: _compute_totp_enabled) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeTotpSecretInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: _compute_totp_secret) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeTourEnabledInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: web_tour, FILE: res_users.py, METHOD: _compute_tour_enabled) ---
            */
            return default;
        }

        protected async Task<ResUsers> ComputeTzOffsetInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _compute_tz_offset) ---
            */
            return default;
        }

        protected async Task<ResUsers> CreateRecruitmentInterviewersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: res_users.py, METHOD: _create_recruitment_interviewers) ---
            */
            return default;
        }

        protected async Task<ResUsers> CreateUserFromTemplateInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py, METHOD: _create_user_from_template) ---
            */
            return default;
        }

        protected async Task<ResUsers> CryptContextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _crypt_context) ---
            */
            return default;
        }

        protected async Task<ResUsers> DeactivatePortalUserInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _deactivate_portal_user) ---
            --- METHOD SOURCE (MODULE: phone_validation, FILE: res_users.py, METHOD: _deactivate_portal_user) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _deactivate_portal_user) ---
            */
            return default;
        }

        protected async Task<ResUsers> DefaultGroupsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _default_groups) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResUsers> DefaultUserCalendarDefaultPrivacyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_users.py, METHOD: _default_user_calendar_default_privacy) ---
            */
            return default;
        }

        protected async Task<ResUsers> DefaultViewGroupHierarchyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _default_view_group_hierarchy) ---
            */
            return default;
        }

        protected async Task<ResUsers> EmployeeIdsDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: _employee_ids_domain) ---
            */
            return default;
        }

        protected async Task<ResUsers> GcPersonalMailServersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _gc_personal_mail_servers) ---
            */
            return default;
        }

        protected async Task<ResUsers> GenerateOnboardingTodoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project_todo, FILE: res_users.py, METHOD: _generate_onboarding_todo) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResUsers> GenerateProfileTokenInternalAsync(Guid user_id, object email)
        {
            /*
            --- METHOD SOURCE (MODULE: website_profile, FILE: res_users.py, METHOD: _generate_profile_token) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResUsers> GenerateSignupValuesInternalAsync(object provider, object validation, object @params)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_oauth, FILE: res_users.py, METHOD: _generate_signup_values) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResUsers> GetActivityGroupsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_users.py, METHOD: _get_activity_groups) ---
            --- METHOD SOURCE (MODULE: contacts, FILE: res_users.py, METHOD: _get_activity_groups) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _get_activity_groups) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: res_users.py, METHOD: _get_activity_groups) ---
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: res_users.py, METHOD: _get_activity_groups) ---
            --- METHOD SOURCE (MODULE: project_todo, FILE: res_users.py, METHOD: _get_activity_groups) ---
            */
            return default;
        }

        protected async Task<ResUsers> GetAuthMethodsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_users.py, METHOD: _get_auth_methods) ---
            */
            return default;
        }

        protected async Task<ResUsers> GetCompanyIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _get_company_ids) ---
            */
            return default;
        }

        protected async Task<ResUsers> GetDefaultWarehouseIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: res_users.py, METHOD: _get_default_warehouse_id) ---
            --- METHOD SOURCE (MODULE: stock, FILE: res_users.py, METHOD: _get_default_warehouse_id) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResUsers> GetEmailDomainInternalAsync(object email)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_users.py, METHOD: _get_email_domain) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _get_email_domain) ---
            */
            return default;
        }

        protected async Task<ResUsers> GetEmployeeFieldsToSyncInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: _get_employee_fields_to_sync) ---
            --- METHOD SOURCE (MODULE: hr_homeworking, FILE: res_users.py, METHOD: _get_employee_fields_to_sync) ---
            */
            return default;
        }

        protected async Task<ResUsers> GetGoogleCalendarTokenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: _get_google_calendar_token) ---
            */
            return default;
        }

        protected async Task<ResUsers> GetGoogleSyncStatusInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: _get_google_sync_status) ---
            */
            return default;
        }

        protected async Task<ResUsers> GetGroupIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _get_group_ids) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResUsers> GetInvalidationFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _get_invalidation_fields) ---
            */
            return default;
        }

        protected async Task<ResUsers> GetKarmaPositionInternalAsync(object user_domain)
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: res_users.py, METHOD: _get_karma_position) ---
            */
            return default;
        }

        protected async Task<ResUsers> GetLockTimeoutInactivityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_users.py, METHOD: _get_lock_timeout_inactivity) ---
            */
            return default;
        }

        protected async Task<ResUsers> GetLockTimeoutsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_users.py, METHOD: _get_lock_timeouts) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResUsers> GetLoginDomainInternalAsync(object login)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_users.py, METHOD: _get_login_domain) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _get_login_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResUsers> GetLoginOrderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_users.py, METHOD: _get_login_order) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _get_login_order) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResUsers> GetMailServerSetupEndActionInternalAsync(object smtp_server)
        {
            /*
            --- METHOD SOURCE (MODULE: google_gmail, FILE: res_users.py, METHOD: _get_mail_server_setup_end_action) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _get_mail_server_setup_end_action) ---
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: res_users.py, METHOD: _get_mail_server_setup_end_action) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResUsers> GetMailServerValuesInternalAsync(object server_type)
        {
            /*
            --- METHOD SOURCE (MODULE: google_gmail, FILE: res_users.py, METHOD: _get_mail_server_values) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _get_mail_server_values) ---
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: res_users.py, METHOD: _get_mail_server_values) ---
            */
            return default;
        }

        protected async Task<ResUsers> GetMicrosoftCalendarTokenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: _get_microsoft_calendar_token) ---
            */
            return default;
        }

        protected async Task<ResUsers> GetMicrosoftSyncStatusInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: _get_microsoft_sync_status) ---
            */
            return default;
        }

        protected async Task<ResUsers> GetNextRankInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: res_users.py, METHOD: _get_next_rank) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResUsers> GetOnLeaveIdsInternalAsync(object partner)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: res_users.py, METHOD: _get_on_leave_ids) ---
            */
            return default;
        }

        protected async Task<ResUsers> GetPersonalInfoPartnerIdsToNotifyInternalAsync(object employee)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: _get_personal_info_partner_ids_to_notify) ---
            */
            return default;
        }

        protected async Task<ResUsers> GetPortalAccessUpdateBodyInternalAsync(object access_granted)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _get_portal_access_update_body) ---
            */
            return default;
        }

        protected async Task<ResUsers> GetSessionTokenFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_oauth, FILE: res_users.py, METHOD: _get_session_token_fields) ---
            --- METHOD SOURCE (MODULE: auth_passkey, FILE: res_users.py, METHOD: _get_session_token_fields) ---
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: _get_session_token_fields) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _get_session_token_fields) ---
            */
            return default;
        }

        protected async Task<ResUsers> GetSessionTokenQueryParamsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_passkey, FILE: res_users.py, METHOD: _get_session_token_query_params) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _get_session_token_query_params) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResUsers> GetSignupInvitationScopeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py, METHOD: _get_signup_invitation_scope) ---
            --- METHOD SOURCE (MODULE: website, FILE: res_users.py, METHOD: _get_signup_invitation_scope) ---
            */
            return default;
        }

        protected async Task<ResUsers> GetStoreAvatarCardFieldsInternalAsync(object target)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _get_store_avatar_card_fields) ---
            */
            return default;
        }

        protected async Task<ResUsers> GetTotpMailCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py, METHOD: _get_totp_mail_code) ---
            */
            return default;
        }

        protected async Task<ResUsers> GetTotpMailKeyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py, METHOD: _get_totp_mail_key) ---
            */
            return default;
        }

        protected async Task<ResUsers> GetTrackingKarmaGainPositionInternalAsync(object user_domain, object from_date, object to_date)
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: res_users.py, METHOD: _get_tracking_karma_gain_position) ---
            */
            return default;
        }

        protected async Task<ResUsers> GetUserBadgeLevelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: res_users.py, METHOD: _get_user_badge_level) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<List<string>> GetUserCalendarConfigurationFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_users.py, METHOD: _get_user_calendar_configuration_fields) ---
            */
            return default;
        }

        protected async Task<ResUsers> GetViewPostprocessedInternalAsync(object view, object arch)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _get_view_postprocessed) ---
            */
            return default;
        }

        protected async Task<ResUsers> HasAnyActiveSynchronizationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_users.py, METHOD: _has_any_active_synchronization) ---
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: _has_any_active_synchronization) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: _has_any_active_synchronization) ---
            */
            return default;
        }

        protected async Task<ResUsers> HasFieldAccessInternalAsync(object field, object operation)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _has_field_access) ---
            */
            return default;
        }

        protected async Task<bool> HasGroupInternalAsync(Guid group_ext_id)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _has_group) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResUsers> HasSetupCredentialsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: _has_setup_credentials) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResUsers> HasSetupMicrosoftCredentialsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: _has_setup_microsoft_credentials) ---
            */
            return default;
        }

        protected async Task<ResUsers> InitMessagingInternalAsync(object store)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _init_messaging) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _init_messaging) ---
            */
            return default;
        }

        protected async Task<ResUsers> InitOdoobotInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail_bot, FILE: res_users.py, METHOD: _init_odoobot) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResUsers> InitStoreDataInternalAsync(object store)
        {
            /*
            --- METHOD SOURCE (MODULE: crm_livechat, FILE: res_users.py, METHOD: _init_store_data) ---
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py, METHOD: _init_store_data) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _init_store_data) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _init_store_data) ---
            */
            return default;
        }

        protected async Task<ResUsers> InverseCalendarResUsersSettingsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_users.py, METHOD: _inverse_calendar_res_users_settings) ---
            */
            return default;
        }

        protected async Task<ResUsers> InverseLivechatExpertiseIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py, METHOD: _inverse_livechat_expertise_ids) ---
            */
            return default;
        }

        protected async Task<ResUsers> InverseLivechatLangIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py, METHOD: _inverse_livechat_lang_ids) ---
            */
            return default;
        }

        protected async Task<ResUsers> InverseLivechatUsernameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py, METHOD: _inverse_livechat_username) ---
            */
            return default;
        }

        protected async Task<ResUsers> InverseNotificationTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _inverse_notification_type) ---
            */
            return default;
        }

        protected async Task<ResUsers> InverseTokenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: _inverse_token) ---
            */
            return default;
        }

        protected async Task<ResUsers> IsAdminInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _is_admin) ---
            */
            return default;
        }

        protected async Task<ResUsers> IsInternalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _is_internal) ---
            */
            return default;
        }

        protected async Task<ResUsers> IsMicrosoftCalendarValidInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: _is_microsoft_calendar_valid) ---
            */
            return default;
        }

        protected async Task<ResUsers> IsPortalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _is_portal) ---
            */
            return default;
        }

        protected async Task<ResUsers> IsPublicInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _is_public) ---
            */
            return default;
        }

        protected async Task<ResUsers> IsSuperuserInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _is_superuser) ---
            */
            return default;
        }

        protected async Task<ResUsers> IsSystemInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _is_system) ---
            */
            return default;
        }

        protected async Task<ResUsers> LegacySessionTokenHashComputeInternalAsync(object sid)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _legacy_session_token_hash_compute) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResUsers> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_users.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResUsers> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_users.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResUsers> LoadPosDataReadInternalAsync(object records, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_users.py, METHOD: _load_pos_data_read) ---
            */
            return default;
        }

        protected async Task<ResUsers> LoginInternalAsync(object credential, object user_agent_env)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_ldap, FILE: res_users.py, METHOD: _login) ---
            --- METHOD SOURCE (MODULE: auth_passkey, FILE: res_users.py, METHOD: _login) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _login) ---
            */
            return default;
        }

        protected async Task<ResUsers> MfaTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: _mfa_type) ---
            --- METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py, METHOD: _mfa_type) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _mfa_type) ---
            */
            return default;
        }

        protected async Task<ResUsers> MfaUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: _mfa_url) ---
            --- METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py, METHOD: _mfa_url) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _mfa_url) ---
            */
            return default;
        }

        protected async Task<ResUsers> MicrosoftCalendarAuthenticatedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: _microsoft_calendar_authenticated) ---
            */
            return default;
        }

        protected async Task<ResUsers> NotifyInviterInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py, METHOD: _notify_inviter) ---
            */
            return default;
        }

        protected async Task<ResUsers> NotifySecurityNewConnectionInternalAsync(object auth_info)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py, METHOD: _notify_security_new_connection) ---
            */
            return default;
        }

        protected async Task<ResUsers> NotifySecuritySettingUpdateInternalAsync(object subject, object content, object mail_values)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _notify_security_setting_update) ---
            */
            return default;
        }

        protected async Task<ResUsers> NotifySecuritySettingUpdatePrepareValuesInternalAsync(object content)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py, METHOD: _notify_security_setting_update_prepare_values) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _notify_security_setting_update_prepare_values) ---
            */
            return default;
        }

        protected async Task<ResUsers> OnLoginCooldownInternalAsync(object failures, object previous)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _on_login_cooldown) ---
            */
            return default;
        }

        protected async Task<ResUsers> OnWebclientBootstrapInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail_bot, FILE: res_users.py, METHOD: _on_webclient_bootstrap) ---
            --- METHOD SOURCE (MODULE: web, FILE: res_users.py, METHOD: _on_webclient_bootstrap) ---
            */
            return default;
        }

        protected async Task<ResUsers> OnboardUsersIntoProjectInternalAsync(object users)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: res_users.py, METHOD: _onboard_users_into_project) ---
            --- METHOD SOURCE (MODULE: project_todo, FILE: res_users.py, METHOD: _onboard_users_into_project) ---
            */
            return default;
        }

        protected async Task<ResUsers> OnchangePrivateStateIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: _onchange_private_state_id) ---
            */
            return default;
        }

        protected async Task<ResUsers> OnchangeRoleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _onchange_role) ---
            */
            return default;
        }

        protected async Task<ResUsers> OndeleteSignupCancelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py, METHOD: _ondelete_signup_cancel) ---
            */
            return default;
        }

        protected async Task<ResUsers> ProcessProfileValidationTokenInternalAsync(object token, object email)
        {
            /*
            --- METHOD SOURCE (MODULE: website_profile, FILE: res_users.py, METHOD: _process_profile_validation_token) ---
            */
            return default;
        }

        protected async Task<ResUsers> RankChangedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: res_users.py, METHOD: _rank_changed) ---
            */
            return default;
        }

        protected async Task<ResUsers> RecomputeRankBulkInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: res_users.py, METHOD: _recompute_rank_bulk) ---
            */
            return default;
        }

        protected async Task<ResUsers> RecomputeRankInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: res_users.py, METHOD: _recompute_rank) ---
            */
            return default;
        }

        protected async Task<ResUsers> RefreshMicrosoftCalendarTokenInternalAsync(object service)
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: _refresh_microsoft_calendar_token) ---
            */
            return default;
        }

        protected async Task<ResUsers> RegisterHookInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _register_hook) ---
            */
            return default;
        }

        protected async Task<ResUsers> RemoveRecruitmentInterviewersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: res_users.py, METHOD: _remove_recruitment_interviewers) ---
            */
            return default;
        }

        protected async Task<ResUsers> RevokeAllDevicesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: _revoke_all_devices) ---
            */
            return default;
        }

        protected async Task<ResUsers> RpcApiKeysOnlyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: _rpc_api_keys_only) ---
            --- METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py, METHOD: _rpc_api_keys_only) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _rpc_api_keys_only) ---
            */
            return default;
        }

        protected async Task<ResUsers> SearchAllGroupIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _search_all_group_ids) ---
            */
            return default;
        }

        protected async Task<ResUsers> SearchCompanyEmployeeInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: _search_company_employee) ---
            */
            return default;
        }

        protected async Task<ResUsers> SearchCrmTeamIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: res_users.py, METHOD: _search_crm_team_ids) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResUsers> SearchDisplayNameInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _search_display_name) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResUsers> SearchResUsersSettingsIdInternalAsync(object @operator, object operand)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _search_res_users_settings_id) ---
            */
            return default;
        }

        protected async Task<ResUsers> SearchStateInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py, METHOD: _search_state) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResUsers> SelfAccessibleFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _self_accessible_fields) ---
            */
            return default;
        }

        protected async Task<ResUsers> SendProfileValidationEmailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_profile, FILE: res_users.py, METHOD: _send_profile_validation_email) ---
            */
            return default;
        }

        protected async Task<ResUsers> SendTotpMailCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py, METHOD: _send_totp_mail_code) ---
            */
            return default;
        }

        protected async Task<ResUsers> SessionTokenGetValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _session_token_get_values) ---
            */
            return default;
        }

        protected async Task<ResUsers> SessionTokenHashComputeInternalAsync(object sid, object field_values)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _session_token_hash_compute) ---
            */
            return default;
        }

        protected async Task<ResUsers> SetEmptyPasswordInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_ldap, FILE: res_users.py, METHOD: _set_empty_password) ---
            */
            return default;
        }

        protected async Task<ResUsers> SetEncryptedPasswordInternalAsync(object uid, object pw)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _set_encrypted_password) ---
            */
            return default;
        }

        protected async Task<ResUsers> SetICPFirstSynchronizationDateInternalAsync(object now)
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: _set_ICP_first_synchronization_date) ---
            */
            return default;
        }

        protected async Task<ResUsers> SetMicrosoftAuthTokensInternalAsync(object access_token, object refresh_token, object ttl)
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_account, FILE: res_users.py, METHOD: _set_microsoft_auth_tokens) ---
            */
            return default;
        }

        protected async Task<ResUsers> SetNewPasswordInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _set_new_password) ---
            */
            return default;
        }

        protected async Task<ResUsers> SetPasswordInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_password_policy, FILE: res_users.py, METHOD: _set_password) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _set_password) ---
            */
            return default;
        }

        protected async Task<ResUsers> ShouldCaptchaLoginInternalAsync(object credential)
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: res_users.py, METHOD: _should_captcha_login) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResUsers> SignupCreateUserInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py, METHOD: _signup_create_user) ---
            --- METHOD SOURCE (MODULE: website, FILE: res_users.py, METHOD: _signup_create_user) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResUsers> SyncAllGoogleCalendarInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: _sync_all_google_calendar) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResUsers> SyncAllMicrosoftCalendarInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: _sync_all_microsoft_calendar) ---
            */
            return default;
        }

        protected async Task<ResUsers> SyncGoogleCalendarInternalAsync(object calendar_service)
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: _sync_google_calendar) ---
            */
            return default;
        }

        protected async Task<ResUsers> SyncMicrosoftCalendarInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: _sync_microsoft_calendar) ---
            */
            return default;
        }

        protected async Task<ResUsers> SyncRequestInternalAsync(object calendar_service, Guid event_id)
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: _sync_request) ---
            */
            return default;
        }

        protected async Task<ResUsers> SyncSingleEventInternalAsync(object calendar_service, object odoo_event, Guid event_id)
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: _sync_single_event) ---
            */
            return default;
        }

        protected async Task<ResUsers> SystrayGetCalendarEventDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_users.py, METHOD: _systray_get_calendar_event_domain) ---
            */
            return default;
        }

        protected async Task<ResUsers> TotpEnableSearchInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: _totp_enable_search) ---
            */
            return default;
        }

        protected async Task<ResUsers> TotpRateLimitInternalAsync(object limit_type)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: _totp_rate_limit) ---
            */
            return default;
        }

        protected async Task<ResUsers> TotpRateLimitPurgeInternalAsync(object limit_type)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: _totp_rate_limit_purge) ---
            */
            return default;
        }

        protected async Task<ResUsers> TotpTrySettingInternalAsync(object secret, object code)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: _totp_try_setting) ---
            */
            return default;
        }

        protected async Task<ResUsers> UnlinkExceptMasterDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _unlink_except_master_data) ---
            */
            return default;
        }

        protected async Task<ResUsers> UnsubscribeFromNonPublicChannelsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: _unsubscribe_from_non_public_channels) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResUsers> UpdateLastLoginInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _update_last_login) ---
            */
            return default;
        }
    }
}