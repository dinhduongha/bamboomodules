using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/base/ResUsers")]
    public partial class ResUsersController : AbpController
    {
        protected readonly IResUsersAppService _appService;
        public ResUsersController(IResUsersAppService appService) { _appService = appService; }


        [HttpPost]
        [Route("action-archive")]
        public async Task<IActionResult> ArchiveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ArchiveAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("action-change-password-wizard")]
        public async Task<IActionResult> ChangePasswordWizardAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ChangePasswordWizardAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("action-create-employee")]
        public async Task<IActionResult> CreateEmployeeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateEmployeeAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("action-create-passkey")]
        public async Task<IActionResult> CreatePasskeyAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreatePasskeyAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("action-get")]
        public async Task<IActionResult> GetAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("action-karma-report")]
        public async Task<IActionResult> KarmaReportAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.KarmaReportAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("action-open-employees")]
        public async Task<IActionResult> OpenEmployeesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenEmployeesAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("action-open-my-account-settings")]
        public async Task<IActionResult> OpenMyAccountSettingsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenMyAccountSettingsAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("action-related-contact")]
        public async Task<IActionResult> RelatedContactAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RelatedContactAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("action-reset-password")]
        public async Task<IActionResult> ResetPasswordAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ResetPasswordAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("action-revoke-all-devices")]
        public async Task<IActionResult> RevokeAllDevicesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RevokeAllDevicesAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("action-setup-outgoing-mail-server")]
        public async Task<IActionResult> SetupOutgoingMailServerAsync([FromBody] ResUsersSetupOutgoingMailServerRequestDto input)
        {
            var result = await _appService.SetupOutgoingMailServerAsync(input);
            return Ok(result);
        }

        [HttpPost]
        [Route("action-show-accesses")]
        public async Task<IActionResult> ShowAccessesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ShowAccessesAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("action-show-groups")]
        public async Task<IActionResult> ShowGroupsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ShowGroupsAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("action-show-rules")]
        public async Task<IActionResult> ShowRulesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ShowRulesAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("action-test-outgoing-mail-server")]
        public async Task<IActionResult> TestOutgoingMailServerAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.TestOutgoingMailServerAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("action-totp-disable")]
        public async Task<IActionResult> TotpDisableAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.TotpDisableAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("action-totp-enable-wizard")]
        public async Task<IActionResult> TotpEnableWizardAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.TotpEnableWizardAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("action-totp-invite")]
        public async Task<IActionResult> TotpInviteAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.TotpInviteAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("api-key-wizard")]
        public async Task<IActionResult> ApiKeyWizardAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ApiKeyWizardAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("auth-oauth")]
        public async Task<IActionResult> AuthOauthAsync([FromBody] ResUsersAuthOauthRequestDto input)
        {
            var result = await _appService.AuthOauthAsync(input);
            return Ok(result);
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> AuthenticateAsync([FromBody] ResUsersAuthenticateRequestDto input)
        {
            var result = await _appService.AuthenticateAsync(input);
            return Ok(result);
        }

        [HttpPost]
        [Route("change-password")]
        public async Task<IActionResult> ChangePasswordAsync([FromBody] ResUsersChangePasswordRequestDto input)
        {
            var result = await _appService.ChangePasswordAsync(input);
            return Ok(result);
        }

        [HttpPost]
        [Route("check-calendar-credentials")]
        public async Task<IActionResult> CheckCalendarCredentialsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CheckCalendarCredentialsAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("check-synchronization-status")]
        public async Task<IActionResult> CheckSynchronizationStatusAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CheckSynchronizationStatusAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("context-get")]
        public async Task<IActionResult> ContextGetAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ContextGetAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] ResUsersCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }

        [HttpPost]
        [Route("get-company-currency-id")]
        public async Task<IActionResult> GetCompanyCurrencyIdAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetCompanyCurrencyIdAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("get-formview-action")]
        public async Task<IActionResult> GetFormviewActionAsync([FromBody] ResUsersGetFormviewActionRequestDto input)
        {
            var result = await _appService.GetFormviewActionAsync(input);
            return Ok(result);
        }

        [HttpPost]
        [Route("get-gamification-redirection-data")]
        public async Task<IActionResult> GetGamificationRedirectionDataAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetGamificationRedirectionDataAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("get-password-policy")]
        public async Task<IActionResult> GetPasswordPolicyAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetPasswordPolicyAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("get-selected-calendars-partner-ids")]
        public async Task<IActionResult> GetSelectedCalendarsPartnerIdsAsync([FromBody] ResUsersGetSelectedCalendarsPartnerIdsRequestDto input)
        {
            var result = await _appService.GetSelectedCalendarsPartnerIdsAsync(input);
            return Ok(result);
        }

        [HttpPost]
        [Route("get-totp-invite-url")]
        public async Task<IActionResult> GetTotpInviteUrlAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetTotpInviteUrlAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("get-view")]
        public async Task<IActionResult> GetViewAsync([FromBody] ResUsersGetViewRequestDto input)
        {
            var result = await _appService.GetViewAsync(input);
            return Ok(result);
        }

        [HttpPost]
        [Route("get-views")]
        public async Task<IActionResult> GetViewsAsync([FromBody] ResUsersGetViewsRequestDto input)
        {
            var result = await _appService.GetViewsAsync(input);
            return Ok(result);
        }

        [HttpPost]
        [Route("has-group")]
        public async Task<IActionResult> HasGroupAsync([FromBody] ResUsersHasGroupRequestDto input)
        {
            var result = await _appService.HasGroupAsync(input);
            return Ok(result);
        }

        [HttpPost]
        [Route("has-groups")]
        public async Task<IActionResult> HasGroupsAsync([FromBody] ResUsersHasGroupsRequestDto input)
        {
            var result = await _appService.HasGroupsAsync(input);
            return Ok(result);
        }

        [HttpPost]
        [Route("init")]
        public async Task<IActionResult> InitAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.InitAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("is-google-calendar-synced")]
        public async Task<IActionResult> IsGoogleCalendarSyncedAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.IsGoogleCalendarSyncedAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> NewAsync([FromBody] ResUsersNewRequestDto input)
        {
            var result = await _appService.NewAsync(input);
            return Ok(result);
        }

        [HttpPost]
        [Route("on-change-login")]
        public async Task<IActionResult> OnChangeLoginAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OnChangeLoginAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("onchange-parent-id")]
        public async Task<IActionResult> OnchangeParentIdAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OnchangeParentIdAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("open-website-url")]
        public async Task<IActionResult> OpenWebsiteUrlAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenWebsiteUrlAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("pause-google-synchronization")]
        public async Task<IActionResult> PauseGoogleSynchronizationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PauseGoogleSynchronizationAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("pause-microsoft-synchronization")]
        public async Task<IActionResult> PauseMicrosoftSynchronizationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PauseMicrosoftSynchronizationAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("preference-change-password")]
        public async Task<IActionResult> PreferenceChangePasswordAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PreferenceChangePasswordAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("preference-save")]
        public async Task<IActionResult> PreferenceSaveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PreferenceSaveAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("remove-oauth-access-token")]
        public async Task<IActionResult> RemoveOauthAccessTokenAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RemoveOauthAccessTokenAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("reset-password")]
        public async Task<IActionResult> ResetPasswordAsync([FromBody] ResUsersResetPasswordRequestDto input)
        {
            var result = await _appService.ResetPasswordAsync(input);
            return Ok(result);
        }

        [HttpPost]
        [Route("restart-google-synchronization")]
        public async Task<IActionResult> RestartGoogleSynchronizationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RestartGoogleSynchronizationAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("restart-microsoft-synchronization")]
        public async Task<IActionResult> RestartMicrosoftSynchronizationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RestartMicrosoftSynchronizationAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("revoke-all-devices")]
        public async Task<IActionResult> RevokeAllDevicesActionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RevokeAllDevicesActionAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("s-e-l-f-r-e-a-d-a-b-l-e-f-i-e-l-d-s")]
        public async Task<IActionResult> SELFREADABLEFIELDSAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SELFREADABLEFIELDSAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("s-e-l-f-w-r-i-t-e-a-b-l-e-f-i-e-l-d-s")]
        public async Task<IActionResult> SELFWRITEABLEFIELDSAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SELFWRITEABLEFIELDSAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("send-unregistered-user-reminder")]
        public async Task<IActionResult> SendUnregisteredUserReminderAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SendUnregisteredUserReminderAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignupAsync([FromBody] ResUsersSignupRequestDto input)
        {
            var result = await _appService.SignupAsync(input);
            return Ok(result);
        }

        [HttpPost]
        [Route("stop-google-synchronization")]
        public async Task<IActionResult> StopGoogleSynchronizationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.StopGoogleSynchronizationAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("stop-microsoft-synchronization")]
        public async Task<IActionResult> StopMicrosoftSynchronizationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.StopMicrosoftSynchronizationAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("switch-tour-enabled")]
        public async Task<IActionResult> SwitchTourEnabledAsync([FromBody] ResUsersSwitchTourEnabledRequestDto input)
        {
            var result = await _appService.SwitchTourEnabledAsync(input);
            return Ok(result);
        }

        [HttpPost]
        [Route("unpause-google-synchronization")]
        public async Task<IActionResult> UnpauseGoogleSynchronizationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UnpauseGoogleSynchronizationAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("unpause-microsoft-synchronization")]
        public async Task<IActionResult> UnpauseMicrosoftSynchronizationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UnpauseMicrosoftSynchronizationAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("web-create-users")]
        public async Task<IActionResult> WebCreateUsersAsync([FromBody] ResUsersWebCreateUsersRequestDto input)
        {
            var result = await _appService.WebCreateUsersAsync(input);
            return Ok(result);
        }

        [HttpPost]
        [Route("website-publish-button")]
        public async Task<IActionResult> WebsitePublishButtonAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.WebsitePublishButtonAsync(ids);
            return Ok(result);
        }
    }

}