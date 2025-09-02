using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class ResUsersController
    {
        
        [HttpPost]
        [Route("{id}/action-archive")]
        public async Task<IActionResult> ActionArchiveAsync(Guid id)
        {
            var result = await _appService.ArchiveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-create-employee")]
        public async Task<IActionResult> ActionCreateEmployeeAsync(Guid id)
        {
            var result = await _appService.CreateEmployeeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-create-passkey")]
        public async Task<IActionResult> ActionCreatePasskeyAsync(Guid id)
        {
            var result = await _appService.CreatePasskeyAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-get")]
        public async Task<IActionResult> ActionGetAsync(Guid id)
        {
            var result = await _appService.GetAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-karma-report")]
        public async Task<IActionResult> ActionKarmaReportAsync(Guid id)
        {
            var result = await _appService.KarmaReportAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-employee-cars")]
        public async Task<IActionResult> ActionOpenEmployeeCarsAsync(Guid id)
        {
            var result = await _appService.OpenEmployeeCarsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-employees")]
        public async Task<IActionResult> ActionOpenEmployeesAsync(Guid id)
        {
            var result = await _appService.OpenEmployeesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-last-month-attendances")]
        public async Task<IActionResult> ActionOpenLastMonthAttendancesAsync(Guid id)
        {
            var result = await _appService.OpenLastMonthAttendancesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-last-month-overtime")]
        public async Task<IActionResult> ActionOpenLastMonthOvertimeAsync(Guid id)
        {
            var result = await _appService.OpenLastMonthOvertimeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-my-account-settings")]
        public async Task<IActionResult> ActionOpenMyAccountSettingsAsync(Guid id)
        {
            var result = await _appService.OpenMyAccountSettingsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-reset-password")]
        public async Task<IActionResult> ActionResetPasswordAsync(Guid id)
        {
            var result = await _appService.ResetPasswordAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-revoke-all-devices")]
        public async Task<IActionResult> ActionRevokeAllDevicesAsync(Guid id)
        {
            var result = await _appService.RevokeAllDevicesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-show-accesses")]
        public async Task<IActionResult> ActionShowAccessesAsync(Guid id)
        {
            var result = await _appService.ShowAccessesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-show-groups")]
        public async Task<IActionResult> ActionShowGroupsAsync(Guid id)
        {
            var result = await _appService.ShowGroupsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-show-rules")]
        public async Task<IActionResult> ActionShowRulesAsync(Guid id)
        {
            var result = await _appService.ShowRulesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-totp-disable")]
        public async Task<IActionResult> ActionTotpDisableAsync(Guid id)
        {
            var result = await _appService.TotpDisableAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-totp-enable-wizard")]
        public async Task<IActionResult> ActionTotpEnableWizardAsync(Guid id)
        {
            var result = await _appService.TotpEnableWizardAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-totp-invite")]
        public async Task<IActionResult> ActionTotpInviteAsync(Guid id)
        {
            var result = await _appService.TotpInviteAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/api-key-wizard")]
        public async Task<IActionResult> ApiKeyWizardAsync(Guid id)
        {
            var result = await _appService.ApiKeyWizardAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/auth-oauth")]
        public async Task<IActionResult> AuthOauthAsync(Guid id, [FromBody] ResUsersAuthOauthRequestDto input)
        {
            var result = await _appService.AuthOauthAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/authenticate")]
        public async Task<IActionResult> AuthenticateAsync(Guid id, [FromBody] ResUsersAuthenticateRequestDto input)
        {
            var result = await _appService.AuthenticateAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/change-password")]
        public async Task<IActionResult> ChangePasswordAsync(Guid id, [FromBody] ResUsersChangePasswordRequestDto input)
        {
            var result = await _appService.ChangePasswordAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check")]
        public async Task<IActionResult> CheckAsync(Guid id, [FromBody] ResUsersCheckRequestDto input)
        {
            var result = await _appService.CheckAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-calendar-credentials")]
        public async Task<IActionResult> CheckCalendarCredentialsAsync(Guid id)
        {
            var result = await _appService.CheckCalendarCredentialsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-synchronization-status")]
        public async Task<IActionResult> CheckSynchronizationStatusAsync(Guid id)
        {
            var result = await _appService.CheckSynchronizationStatusAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/context-get")]
        public async Task<IActionResult> ContextGetAsync(Guid id)
        {
            var result = await _appService.ContextGetAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] ResUsersCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-company-currency-id")]
        public async Task<IActionResult> GetCompanyCurrencyIdAsync(Guid id)
        {
            var result = await _appService.GetCompanyCurrencyIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-gamification-redirection-data")]
        public async Task<IActionResult> GetGamificationRedirectionDataAsync(Guid id)
        {
            var result = await _appService.GetGamificationRedirectionDataAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-password-policy")]
        public async Task<IActionResult> GetPasswordPolicyAsync(Guid id)
        {
            var result = await _appService.GetPasswordPolicyAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-selected-calendars-partner-ids")]
        public async Task<IActionResult> GetSelectedCalendarsPartnerIdsAsync(Guid id, [FromBody] ResUsersGetSelectedCalendarsPartnerIdsRequestDto input)
        {
            var result = await _appService.GetSelectedCalendarsPartnerIdsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-totp-invite-url")]
        public async Task<IActionResult> GetTotpInviteUrlAsync(Guid id)
        {
            var result = await _appService.GetTotpInviteUrlAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-view")]
        public async Task<IActionResult> GetViewAsync(Guid id, [FromBody] ResUsersGetViewRequestDto input)
        {
            var result = await _appService.GetViewAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-views")]
        public async Task<IActionResult> GetViewsAsync(Guid id, [FromBody] ResUsersGetViewsRequestDto input)
        {
            var result = await _appService.GetViewsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/has-group")]
        public async Task<IActionResult> HasGroupAsync(Guid id, [FromBody] ResUsersHasGroupRequestDto input)
        {
            var result = await _appService.HasGroupAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/has-groups")]
        public async Task<IActionResult> HasGroupsAsync(Guid id, [FromBody] ResUsersHasGroupsRequestDto input)
        {
            var result = await _appService.HasGroupsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/init")]
        public async Task<IActionResult> InitAsync(Guid id)
        {
            var result = await _appService.InitAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/is-google-calendar-synced")]
        public async Task<IActionResult> IsGoogleCalendarSyncedAsync(Guid id)
        {
            var result = await _appService.IsGoogleCalendarSyncedAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/new")]
        public async Task<IActionResult> NewAsync(Guid id, [FromBody] ResUsersNewRequestDto input)
        {
            var result = await _appService.NewAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/on-change-login")]
        public async Task<IActionResult> OnChangeLoginAsync(Guid id)
        {
            var result = await _appService.OnChangeLoginAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-parent-id")]
        public async Task<IActionResult> OnchangeParentIdAsync(Guid id)
        {
            var result = await _appService.OnchangeParentIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-website-url")]
        public async Task<IActionResult> OpenWebsiteUrlAsync(Guid id)
        {
            var result = await _appService.OpenWebsiteUrlAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/pause-google-synchronization")]
        public async Task<IActionResult> PauseGoogleSynchronizationAsync(Guid id)
        {
            var result = await _appService.PauseGoogleSynchronizationAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/pause-microsoft-synchronization")]
        public async Task<IActionResult> PauseMicrosoftSynchronizationAsync(Guid id)
        {
            var result = await _appService.PauseMicrosoftSynchronizationAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/preference-change-password")]
        public async Task<IActionResult> PreferenceChangePasswordAsync(Guid id)
        {
            var result = await _appService.PreferenceChangePasswordAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/preference-save")]
        public async Task<IActionResult> PreferenceSaveAsync(Guid id)
        {
            var result = await _appService.PreferenceSaveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/reset-password")]
        public async Task<IActionResult> ResetPasswordAsync(Guid id, [FromBody] ResUsersResetPasswordRequestDto input)
        {
            var result = await _appService.ResetPasswordAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/restart-google-synchronization")]
        public async Task<IActionResult> RestartGoogleSynchronizationAsync(Guid id)
        {
            var result = await _appService.RestartGoogleSynchronizationAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/restart-microsoft-synchronization")]
        public async Task<IActionResult> RestartMicrosoftSynchronizationAsync(Guid id)
        {
            var result = await _appService.RestartMicrosoftSynchronizationAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/revoke-all-devices")]
        public async Task<IActionResult> RevokeAllDevicesAsync(Guid id)
        {
            var result = await _appService.RevokeAllDevicesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/s-e-l-f-r-e-a-d-a-b-l-e-f-i-e-l-d-s")]
        public async Task<IActionResult> SELFREADABLEFIELDSAsync(Guid id)
        {
            var result = await _appService.SELFREADABLEFIELDSAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/s-e-l-f-w-r-i-t-e-a-b-l-e-f-i-e-l-d-s")]
        public async Task<IActionResult> SELFWRITEABLEFIELDSAsync(Guid id)
        {
            var result = await _appService.SELFWRITEABLEFIELDSAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/send-unregistered-user-reminder")]
        public async Task<IActionResult> SendUnregisteredUserReminderAsync(Guid id)
        {
            var result = await _appService.SendUnregisteredUserReminderAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/signup")]
        public async Task<IActionResult> SignupAsync(Guid id, [FromBody] ResUsersSignupRequestDto input)
        {
            var result = await _appService.SignupAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/stop-google-synchronization")]
        public async Task<IActionResult> StopGoogleSynchronizationAsync(Guid id)
        {
            var result = await _appService.StopGoogleSynchronizationAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/stop-microsoft-synchronization")]
        public async Task<IActionResult> StopMicrosoftSynchronizationAsync(Guid id)
        {
            var result = await _appService.StopMicrosoftSynchronizationAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/switch-tour-enabled")]
        public async Task<IActionResult> SwitchTourEnabledAsync(Guid id, [FromBody] ResUsersSwitchTourEnabledRequestDto input)
        {
            var result = await _appService.SwitchTourEnabledAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/toggle-active")]
        public async Task<IActionResult> ToggleActiveAsync(Guid id)
        {
            var result = await _appService.ToggleActiveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/unpause-google-synchronization")]
        public async Task<IActionResult> UnpauseGoogleSynchronizationAsync(Guid id)
        {
            var result = await _appService.UnpauseGoogleSynchronizationAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/unpause-microsoft-synchronization")]
        public async Task<IActionResult> UnpauseMicrosoftSynchronizationAsync(Guid id)
        {
            var result = await _appService.UnpauseMicrosoftSynchronizationAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/web-create-users")]
        public async Task<IActionResult> WebCreateUsersAsync(Guid id, [FromBody] ResUsersWebCreateUsersRequestDto input)
        {
            var result = await _appService.WebCreateUsersAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/website-publish-button")]
        public async Task<IActionResult> WebsitePublishButtonAsync(Guid id)
        {
            var result = await _appService.WebsitePublishButtonAsync(id);
            return Ok(result);
        }
    }
}