using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class SurveySurveyController
    {
        
        [HttpPost]
        [Route("{id}/action-archive")]
        public async Task<IActionResult> ActionArchiveAsync(Guid id)
        {
            var result = await _appService.ArchiveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-end-session")]
        public async Task<IActionResult> ActionEndSessionAsync(Guid id)
        {
            var result = await _appService.EndSessionAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-load-sample-custom")]
        public async Task<IActionResult> ActionLoadSampleCustomAsync(Guid id)
        {
            var result = await _appService.LoadSampleCustomAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-load-survey-template-sample")]
        public async Task<IActionResult> ActionLoadSurveyTemplateSampleAsync(Guid id, [FromBody] SurveySurveyLoadSurveyTemplateSampleRequestDto input)
        {
            var result = await _appService.LoadSurveyTemplateSampleAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-session-manager")]
        public async Task<IActionResult> ActionOpenSessionManagerAsync(Guid id)
        {
            var result = await _appService.OpenSessionManagerAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-print-survey")]
        public async Task<IActionResult> ActionPrintSurveyAsync(Guid id, [FromBody] SurveySurveyPrintSurveyRequestDto input)
        {
            var result = await _appService.PrintSurveyAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-result-survey")]
        public async Task<IActionResult> ActionResultSurveyAsync(Guid id)
        {
            var result = await _appService.ResultSurveyAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-send-survey")]
        public async Task<IActionResult> ActionSendSurveyAsync(Guid id)
        {
            var result = await _appService.SendSurveyAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-show-sample")]
        public async Task<IActionResult> ActionShowSampleAsync(Guid id)
        {
            var result = await _appService.ShowSampleAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-start-session")]
        public async Task<IActionResult> ActionStartSessionAsync(Guid id)
        {
            var result = await _appService.StartSessionAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-start-survey")]
        public async Task<IActionResult> ActionStartSurveyAsync(Guid id, [FromBody] SurveySurveyStartSurveyRequestDto input)
        {
            var result = await _appService.StartSurveyAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-survey-preview-certification-template")]
        public async Task<IActionResult> ActionSurveyPreviewCertificationTemplateAsync(Guid id)
        {
            var result = await _appService.SurveyPreviewCertificationTemplateAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-survey-see-leads")]
        public async Task<IActionResult> ActionSurveySeeLeadsAsync(Guid id)
        {
            var result = await _appService.SurveySeeLeadsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-survey-user-input")]
        public async Task<IActionResult> ActionSurveyUserInputAsync(Guid id)
        {
            var result = await _appService.SurveyUserInputAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-survey-user-input-certified")]
        public async Task<IActionResult> ActionSurveyUserInputCertifiedAsync(Guid id)
        {
            var result = await _appService.SurveyUserInputCertifiedAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-survey-user-input-completed")]
        public async Task<IActionResult> ActionSurveyUserInputCompletedAsync(Guid id)
        {
            var result = await _appService.SurveyUserInputCompletedAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-survey-view-slide-channels")]
        public async Task<IActionResult> ActionSurveyViewSlideChannelsAsync(Guid id)
        {
            var result = await _appService.SurveyViewSlideChannelsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-test-survey")]
        public async Task<IActionResult> ActionTestSurveyAsync(Guid id)
        {
            var result = await _appService.TestSurveyAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-unarchive")]
        public async Task<IActionResult> ActionUnarchiveAsync(Guid id)
        {
            var result = await _appService.UnarchiveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-validity")]
        public async Task<IActionResult> CheckValidityAsync(Guid id)
        {
            var result = await _appService.CheckValidityAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] SurveySurveyCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-formview-id")]
        public async Task<IActionResult> GetFormviewIdAsync(Guid id, [FromBody] SurveySurveyGetFormviewIdRequestDto input)
        {
            var result = await _appService.GetFormviewIdAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-print-url")]
        public async Task<IActionResult> GetPrintUrlAsync(Guid id)
        {
            var result = await _appService.GetPrintUrlAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-start-short-url")]
        public async Task<IActionResult> GetStartShortUrlAsync(Guid id)
        {
            var result = await _appService.GetStartShortUrlAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-start-url")]
        public async Task<IActionResult> GetStartUrlAsync(Guid id)
        {
            var result = await _appService.GetStartUrlAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-survey-templates-data")]
        public async Task<IActionResult> GetSurveyTemplatesDataAsync(Guid id)
        {
            var result = await _appService.GetSurveyTemplatesDataAsync(id);
            return Ok(result);
        }
    }
}