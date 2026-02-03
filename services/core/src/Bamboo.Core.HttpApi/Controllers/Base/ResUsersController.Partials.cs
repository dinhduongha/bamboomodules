using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ResUsersController
    {
        
        [HttpPost]
        [Route("action-archive")]
        public async Task<IActionResult> ActionArchiveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ArchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-change-password-wizard")]
        public async Task<IActionResult> ActionChangePasswordWizardAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ChangePasswordWizardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-create-employee")]
        public async Task<IActionResult> ActionCreateEmployeeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CreateEmployeeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-create-passkey")]
        public async Task<IActionResult> ActionCreatePasskeyAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CreatePasskeyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-get")]
        public async Task<IActionResult> ActionGetAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-karma-report")]
        public async Task<IActionResult> ActionKarmaReportAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.KarmaReportAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-employees")]
        public async Task<IActionResult> ActionOpenEmployeesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenEmployeesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-my-account-settings")]
        public async Task<IActionResult> ActionOpenMyAccountSettingsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenMyAccountSettingsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-related-contact")]
        public async Task<IActionResult> ActionRelatedContactAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RelatedContactAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-reset-password")]
        public async Task<IActionResult> ActionResetPasswordAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ResetPasswordAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-revoke-all-devices")]
        public async Task<IActionResult> ActionRevokeAllDevicesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RevokeAllDevicesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-setup-outgoing-mail-server")]
        public async Task<IActionResult> ActionSetupOutgoingMailServerAsync(ResUsersSetupOutgoingMailServerRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SetupOutgoingMailServerAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-show-accesses")]
        public async Task<IActionResult> ActionShowAccessesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ShowAccessesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-show-groups")]
        public async Task<IActionResult> ActionShowGroupsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ShowGroupsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-show-rules")]
        public async Task<IActionResult> ActionShowRulesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ShowRulesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-test-outgoing-mail-server")]
        public async Task<IActionResult> ActionTestOutgoingMailServerAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.TestOutgoingMailServerAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-totp-disable")]
        public async Task<IActionResult> ActionTotpDisableAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.TotpDisableAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-totp-enable-wizard")]
        public async Task<IActionResult> ActionTotpEnableWizardAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.TotpEnableWizardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-totp-invite")]
        public async Task<IActionResult> ActionTotpInviteAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.TotpInviteAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("api-key-wizard")]
        public async Task<IActionResult> ApiKeyWizardAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ApiKeyWizardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("auth-oauth")]
        public async Task<IActionResult> AuthOauthAsync(ResUsersAuthOauthRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.AuthOauthAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(ResUsersAuthenticateRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.AuthenticateAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("change-password")]
        public async Task<IActionResult> ChangePasswordAsync(ResUsersChangePasswordRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ChangePasswordAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-calendar-credentials")]
        public async Task<IActionResult> CheckCalendarCredentialsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CheckCalendarCredentialsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-synchronization-status")]
        public async Task<IActionResult> CheckSynchronizationStatusAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CheckSynchronizationStatusAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("context-get")]
        public async Task<IActionResult> ContextGetAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ContextGetAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(ResUsersCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-company-currency-id")]
        public async Task<IActionResult> GetCompanyCurrencyIdAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetCompanyCurrencyIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-formview-action")]
        public async Task<IActionResult> GetFormviewActionAsync(ResUsersGetFormviewActionRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetFormviewActionAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-gamification-redirection-data")]
        public async Task<IActionResult> GetGamificationRedirectionDataAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetGamificationRedirectionDataAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-password-policy")]
        public async Task<IActionResult> GetPasswordPolicyAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetPasswordPolicyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-selected-calendars-partner-ids")]
        public async Task<IActionResult> GetSelectedCalendarsPartnerIdsAsync(ResUsersGetSelectedCalendarsPartnerIdsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetSelectedCalendarsPartnerIdsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-totp-invite-url")]
        public async Task<IActionResult> GetTotpInviteUrlAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetTotpInviteUrlAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-view")]
        public async Task<IActionResult> GetViewAsync(ResUsersGetViewRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetViewAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-views")]
        public async Task<IActionResult> GetViewsAsync(ResUsersGetViewsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetViewsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("has-group")]
        public async Task<IActionResult> HasGroupAsync(ResUsersHasGroupRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.HasGroupAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("has-groups")]
        public async Task<IActionResult> HasGroupsAsync(ResUsersHasGroupsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.HasGroupsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("init")]
        public async Task<IActionResult> InitAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.InitAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("is-google-calendar-synced")]
        public async Task<IActionResult> IsGoogleCalendarSyncedAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.IsGoogleCalendarSyncedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> NewAsync(ResUsersNewRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.NewAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("on-change-login")]
        public async Task<IActionResult> OnChangeLoginAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OnChangeLoginAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-parent-id")]
        public async Task<IActionResult> OnchangeParentIdAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OnchangeParentIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-website-url")]
        public async Task<IActionResult> OpenWebsiteUrlAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenWebsiteUrlAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("pause-google-synchronization")]
        public async Task<IActionResult> PauseGoogleSynchronizationAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PauseGoogleSynchronizationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("pause-microsoft-synchronization")]
        public async Task<IActionResult> PauseMicrosoftSynchronizationAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PauseMicrosoftSynchronizationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("preference-change-password")]
        public async Task<IActionResult> PreferenceChangePasswordAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PreferenceChangePasswordAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("preference-save")]
        public async Task<IActionResult> PreferenceSaveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PreferenceSaveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("remove-oauth-access-token")]
        public async Task<IActionResult> RemoveOauthAccessTokenAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RemoveOauthAccessTokenAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("reset-password")]
        public async Task<IActionResult> ResetPasswordAsync(ResUsersResetPasswordRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ResetPasswordAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("restart-google-synchronization")]
        public async Task<IActionResult> RestartGoogleSynchronizationAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RestartGoogleSynchronizationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("restart-microsoft-synchronization")]
        public async Task<IActionResult> RestartMicrosoftSynchronizationAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RestartMicrosoftSynchronizationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("revoke-all-devices")]
        public async Task<IActionResult> RevokeAllDevicesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RevokeAllDevicesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("s-e-l-f-r-e-a-d-a-b-l-e-f-i-e-l-d-s")]
        public async Task<IActionResult> SELFREADABLEFIELDSAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SELFREADABLEFIELDSAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("s-e-l-f-w-r-i-t-e-a-b-l-e-f-i-e-l-d-s")]
        public async Task<IActionResult> SELFWRITEABLEFIELDSAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SELFWRITEABLEFIELDSAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("send-unregistered-user-reminder")]
        public async Task<IActionResult> SendUnregisteredUserReminderAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SendUnregisteredUserReminderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignupAsync(ResUsersSignupRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SignupAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("stop-google-synchronization")]
        public async Task<IActionResult> StopGoogleSynchronizationAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.StopGoogleSynchronizationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("stop-microsoft-synchronization")]
        public async Task<IActionResult> StopMicrosoftSynchronizationAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.StopMicrosoftSynchronizationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("switch-tour-enabled")]
        public async Task<IActionResult> SwitchTourEnabledAsync(ResUsersSwitchTourEnabledRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SwitchTourEnabledAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("unpause-google-synchronization")]
        public async Task<IActionResult> UnpauseGoogleSynchronizationAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UnpauseGoogleSynchronizationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("unpause-microsoft-synchronization")]
        public async Task<IActionResult> UnpauseMicrosoftSynchronizationAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UnpauseMicrosoftSynchronizationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("web-create-users")]
        public async Task<IActionResult> WebCreateUsersAsync(ResUsersWebCreateUsersRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.WebCreateUsersAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("website-publish-button")]
        public async Task<IActionResult> WebsitePublishButtonAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.WebsitePublishButtonAsync(ids);
            return Ok(result);
        }
    }
}