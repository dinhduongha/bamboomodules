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
    [Module("BaseModule", Category = "Base")]
    public partial class ResUsersAppService : GenericAppService<ResUsers>, IResUsersAppService
    {
        protected readonly IBusListenerMixinAppService _busListenerMixinAppService;
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public ResUsersAppService(IRepository<ResUsers, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IBusListenerMixinAppService busListenerMixinAppService, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _busListenerMixinAppService = busListenerMixinAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public async Task<ResUsers> ApiKeyWizardAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: api_key_wizard) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> ArchiveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: action_archive) ---
            --- METHOD SOURCE (MODULE: sales_team, FILE: res_users.py, METHOD: action_archive) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResUsers> AuthOauthAsync(ResUsersAuthOauthRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_oauth, FILE: res_users.py, METHOD: auth_oauth) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> AuthenticateAsync(ResUsersAuthenticateRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py, METHOD: authenticate) ---
            --- METHOD SOURCE (MODULE: website, FILE: res_users.py, METHOD: authenticate) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: authenticate) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResUsers> ChangePasswordAsync(ResUsersChangePasswordRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_ldap, FILE: res_users.py, METHOD: change_password) ---
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: change_password) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: change_password) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> ChangePasswordWizardAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: action_change_password_wizard) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResUsers> CheckCalendarCredentialsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_users.py, METHOD: check_calendar_credentials) ---
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: check_calendar_credentials) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: check_calendar_credentials) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> CheckSynchronizationStatusAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_users.py, METHOD: check_synchronization_status) ---
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: check_synchronization_status) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: check_synchronization_status) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResUsers> ContextGetAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: context_get) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<ResUsers> CopyAsync(CopyRequestDto<ResUsers> input)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py, METHOD: copy) ---
            */
            return await base.CopyAsync(input);
        }

        public async Task<ResUsers> CopyDataAsync(ResUsersCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<ResUsers> CreateAsync(CreateRequestDto<ResUsers> input)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: calendar, FILE: res_users.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: digest, FILE: res_users.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: gamification, FILE: res_users.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: res_users.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: project, FILE: res_users.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: res_users.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<ResUsers> CreateEmployeeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: action_create_employee) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> CreatePasskeyAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_passkey, FILE: res_users.py, METHOD: action_create_passkey) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResUsers> GetAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: action_get) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: action_get) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResUsers> GetCompanyCurrencyIdAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: get_company_currency_id) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> GetFormviewActionAsync(ResUsersGetFormviewActionRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: get_formview_action) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> GetGamificationRedirectionDataAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: res_users.py, METHOD: get_gamification_redirection_data) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: res_users.py, METHOD: get_gamification_redirection_data) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: res_users.py, METHOD: get_gamification_redirection_data) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResUsers> GetPasswordPolicyAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_password_policy, FILE: res_users.py, METHOD: get_password_policy) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> GetSelectedCalendarsPartnerIdsAsync(ResUsersGetSelectedCalendarsPartnerIdsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_users.py, METHOD: get_selected_calendars_partner_ids) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> GetTotpInviteUrlAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py, METHOD: get_totp_invite_url) ---
            --- METHOD SOURCE (MODULE: auth_totp_portal, FILE: res_users.py, METHOD: get_totp_invite_url) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResUsers> GetViewAsync(ResUsersGetViewRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: get_view) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResUsers> GetViewsAsync(ResUsersGetViewsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: get_views) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<bool> HasGroupAsync(ResUsersHasGroupRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: has_group) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<bool> HasGroupsAsync(ResUsersHasGroupsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: has_groups) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> InitAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: init) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: init) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> IsGoogleCalendarSyncedAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: is_google_calendar_synced) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> KarmaReportAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: res_users.py, METHOD: action_karma_report) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public override async Task<List<(Guid Id, string Name)>> NameSearchAsync(NameSearchRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: res_users.py, METHOD: name_search) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: name_search) ---
            */
            return await base.NameSearchAsync(input);
        }

        [ApiModel]
        public async Task<ResUsers> NewAsync(ResUsersNewRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: new) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> OnChangeLoginAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: on_change_login) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> OnchangeParentIdAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: onchange_parent_id) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> OpenEmployeesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: action_open_employees) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> OpenMyAccountSettingsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py, METHOD: action_open_my_account_settings) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> OpenWebsiteUrlAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: res_users.py, METHOD: open_website_url) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> PauseGoogleSynchronizationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: pause_google_synchronization) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> PauseMicrosoftSynchronizationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: pause_microsoft_synchronization) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> PreferenceChangePasswordAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: preference_change_password) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> PreferenceSaveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: preference_save) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> RelatedContactAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: action_related_contact) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> RemoveOauthAccessTokenAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_oauth, FILE: res_users.py, METHOD: remove_oauth_access_token) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> ResetPasswordAsync(ResUsersResetPasswordRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py, METHOD: reset_password) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> ResetPasswordAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py, METHOD: action_reset_password) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> RestartGoogleSynchronizationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: restart_google_synchronization) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> RestartMicrosoftSynchronizationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: restart_microsoft_synchronization) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> RevokeAllDevicesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: revoke_all_devices) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> RevokeAllDevicesActionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: action_revoke_all_devices) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> SELFREADABLEFIELDSAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_oauth, FILE: res_users.py, METHOD: SELF_READABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: auth_passkey, FILE: res_users.py, METHOD: SELF_READABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: SELF_READABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: calendar, FILE: res_users.py, METHOD: SELF_READABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: SELF_READABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: res_users.py, METHOD: SELF_READABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: hr_homeworking, FILE: res_users.py, METHOD: SELF_READABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py, METHOD: SELF_READABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: SELF_READABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: mail_bot, FILE: res_users.py, METHOD: SELF_READABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: res_users.py, METHOD: SELF_READABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: website_profile, FILE: res_users.py, METHOD: SELF_READABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: SELF_READABLE_FIELDS) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> SELFWRITEABLEFIELDSAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_users.py, METHOD: SELF_WRITEABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: SELF_WRITEABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: hr_homeworking, FILE: res_users.py, METHOD: SELF_WRITEABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py, METHOD: SELF_WRITEABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: SELF_WRITEABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: res_users.py, METHOD: SELF_WRITEABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: website_profile, FILE: res_users.py, METHOD: SELF_WRITEABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: SELF_WRITEABLE_FIELDS) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> SendUnregisteredUserReminderAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py, METHOD: send_unregistered_user_reminder) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResUsers> SetupOutgoingMailServerAsync(ResUsersSetupOutgoingMailServerRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: action_setup_outgoing_mail_server) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> ShowAccessesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: action_show_accesses) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> ShowGroupsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: action_show_groups) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> ShowRulesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: action_show_rules) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResUsers> SignupAsync(ResUsersSignupRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py, METHOD: signup) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> StopGoogleSynchronizationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: stop_google_synchronization) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> StopMicrosoftSynchronizationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: stop_microsoft_synchronization) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResUsers> SwitchTourEnabledAsync(ResUsersSwitchTourEnabledRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: web_tour, FILE: res_users.py, METHOD: switch_tour_enabled) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResUsers> TestOutgoingMailServerAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: action_test_outgoing_mail_server) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> TotpDisableAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: action_totp_disable) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> TotpEnableWizardAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py, METHOD: action_totp_enable_wizard) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> TotpInviteAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py, METHOD: action_totp_invite) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: unlink) ---
            */
            return await base.UnlinkAsync(ids);
        }

        public async Task<ResUsers> UnpauseGoogleSynchronizationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py, METHOD: unpause_google_synchronization) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> UnpauseMicrosoftSynchronizationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py, METHOD: unpause_microsoft_synchronization) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResUsers> WebCreateUsersAsync(ResUsersWebCreateUsersRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py, METHOD: web_create_users) ---
            --- METHOD SOURCE (MODULE: base_setup, FILE: res_users.py, METHOD: web_create_users) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsers> WebsitePublishButtonAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_users.py, METHOD: website_publish_button) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<ResUsers> input)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: calendar, FILE: res_users.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: gamification, FILE: res_users.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr, FILE: res_users.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_users.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: resource, FILE: res_users.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: res_users.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}